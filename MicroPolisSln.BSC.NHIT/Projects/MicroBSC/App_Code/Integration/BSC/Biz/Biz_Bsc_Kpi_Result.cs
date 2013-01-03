using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Integration.COM.Dac;

using MicroBSC.Data;

/// <summary>
/// Biz_Bsc_Kpi_Result의 요약 설명입니다.
/// </summary>

/// <summary>
/// Biz_Bsc_Kpi_Result의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_Result Biz 클래스
/// Class 내용		: Bsc_Kpi_Result Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Result : MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result
    {
        public Biz_Bsc_Kpi_Result() { }
      


        #region ========================== 멀티 DB 작업 ============================

        public DataTable GetBscKpiTargetGoalTong_DB(int estterm_ref_id
                                              , int kpi_ref_id
                                              , string ymd)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dacBscKpiResult = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();
            return dacBscKpiResult.Select_DB(estterm_ref_id, kpi_ref_id, ymd).Tables[0];
        }

        public bool UpdateKpiResultDataByAdmin(DataTable dataTable)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dac = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += dac.UpdateKpiResultDataByAdmin(conn
                                                                , trx
                                                                , dataRow["ESTTERM_REF_ID"]
                                                                , dataRow["KPI_REF_ID"]
                                                                , dataRow["YMD"]
                                                                , dataRow["RESULT_MS"]
                                                                , dataRow["RESULT_TS"]
                                                                , dataRow["CAUSE_TEXT_MS"]
                                                                , dataRow["CAUSE_TEXT_TS"]
                                                                , dataRow["MEASURE_TEXT_MS"]
                                                                , dataRow["MEASURE_TEXT_TS"]
                                                                , dataRow["CHECKSTATUS"]
                                                                , dataRow["UPDATE_DATE"]
                                                                , dataRow["UPDATE_USER"]);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }

        public string ModifyKpiResultDataBulker_DB(DataTable dt
                                            , string title
                                            , int create_user
                                            , string create_date)
        {
            string returnVal = string.Empty;

            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    object estterm_ref_id   = row["ESTTERM_REF_ID"];
                    object kpi_ref_id       = row["KPI_REF_ID"];
                    object ymd              = row["YMD"];
                    object result_ms        = row["RESULT_MS"];
                    object result_ts        = row["RESULT_TS"];
                    object checkstatus      = "Y";
                    bool check_Apping_yn  = DataTypeUtility.GetYNToBoolean(DataTypeUtility.GetValue(row["CHECK_APPING_YN"]));

                    int app_ref_id = DataTypeUtility.GetToInt32(row["APP_REF_ID"]);


                    if (check_Apping_yn)
                    {

                        MicroBSC.Integration.COM.Dac.Dac_Com_Approval_Info dacApprovalInfo = new MicroBSC.Integration.COM.Dac.Dac_Com_Approval_Info();

                        app_ref_id = dacApprovalInfo.SelectMaxAppRefID(conn, trx);
                        int app_version_id = 1;

                        string biz_type = "KRA";
                        string app_code = string.Format("{0}-{1}-{2}", biz_type, app_ref_id, app_version_id);
                        string active_yn = "Y";
                        string app_status = "CFT";
                        string draft_status = "FD";

                        affectedRow = dacApprovalInfo.InsertApprovalinfo_DB(conn
                                                                          , trx
                                                                          , app_ref_id
                                                                          , app_version_id
                                                                          , app_code
                                                                          , active_yn
                                                                          , DBNull.Value
                                                                          , title
                                                                          , biz_type
                                                                          , app_status
                                                                          , draft_status
                                                                          , create_user
                                                                          , create_date);

                        MicroBSC.Integration.COM.Dac.Dac_Com_Approval_Prc dacApprovalPrc = new MicroBSC.Integration.COM.Dac.Dac_Com_Approval_Prc();

                        affectedRow = dacApprovalPrc.InsertApprovalPrc_DB(conn
                                                                          , trx
                                                                          , app_ref_id
                                                                          , app_version_id
                                                                          , 1
                                                                          , create_user
                                                                          , "Y"
                                                                          , title
                                                                          , DBNull.Value
                                                                          , "D"
                                                                          , "NAME"
                                                                          , create_user
                                                                          , create_date);

                    }

                    MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dacBscKpiResult = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();
                    affectedRow = dacBscKpiResult.UpdataData_DB(conn
                                                              , trx
                                                              , estterm_ref_id
                                                              , kpi_ref_id
                                                              , ymd 
                                                              , result_ms
                                                              , result_ts
                                                              , app_ref_id
                                                              , checkstatus
                                                              , create_user
                                                              , create_date);
                }


                //trx.Rollback();
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                returnVal = ex.Message;
                return returnVal;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }

        public string AddKpiResult_DB(int iestterm_ref_id
                                    , int ikpi_ref_id
                                    , string iymd
                                    , double iresult_ms
                                    , double iresult_ts
                                    , int isequence
                                    , double ical_result_ms
                                    , double ical_result_ts
                                    , string ical_apply_yn
                                    , string ical_apply_reason
                                    , string icause_text_ms
                                    , string icause_text_ts
                                    , string icause_file_id
                                    , string imeasure_text_ms
                                    , string imeasure_text_ts
                                    , string imeasure_file_id
                                    , string iremark
                                    , string initiative_do
                                    , string do_file
                                    , DateTime create_date
                                    , int create_user)
        {
            string returnVal = string.Empty;

            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Initiative();

            DataTable dtBscKpiInitiative = dacBscKpiInitiative.SelectData_DB(iestterm_ref_id
                                                                            , ikpi_ref_id
                                                                            , iymd).Tables[0];

            try
            {
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dacBscKpiResult = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();

                affectedRow = dacBscKpiResult.InsertData_DB(conn
                                                          , trx
                                                          , iestterm_ref_id
                                                          , ikpi_ref_id
                                                          , iymd
                                                          , iresult_ms
                                                          , iresult_ts
                                                          , isequence
                                                          , ical_result_ms
                                                          , ical_result_ts
                                                          , ical_apply_yn
                                                          , ical_apply_reason
                                                          , icause_text_ms
                                                          , icause_text_ts
                                                          , icause_file_id
                                                          , imeasure_text_ms
                                                          , imeasure_text_ts
                                                          , imeasure_file_id
                                                          , iremark
                                                          , create_date
                                                          , create_user);



                if (dtBscKpiInitiative.Rows.Count > 0)
                {
                    affectedRow = dacBscKpiInitiative.UpdateDo_DB(conn
                                                                  , trx
                                                                  , iestterm_ref_id
                                                                  , ikpi_ref_id
                                                                  , iymd
                                                                  , initiative_do
                                                                  , do_file
                                                                  , create_date
                                                                  , create_user);
                }
                else
                {
                    affectedRow = dacBscKpiInitiative.InsertData_DB(conn
                                                                  , trx
                                                                  , iestterm_ref_id
                                                                  , ikpi_ref_id
                                                                  , iymd
                                                                  , DBNull.Value
                                                                  , initiative_do
                                                                  , do_file
                                                                  , DBNull.Value
                                                                  , create_user);
                }

            


                //trx.Rollback();
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                returnVal = ex.Message;
                return returnVal;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }

        public string ModifyKpiResult_DB(int iestterm_ref_id
                                        , int ikpi_ref_id
                                        , string iymd
                                        , double iresult_ms
                                        , double iresult_ts
                                        , int isequence
                                        , double ical_result_ms
                                        , double ical_result_ts
                                        , string cal_apply_yn
                                        , string cal_apply_reason
                                        , string cause_text_ms
                                        , string cause_text_ts
                                        , string cause_file_id
                                        , string imeasure_text_ms
                                        , string imeasure_text_ts
                                        , string imeasure_file_id
                                        , string iremark
                                        , string initiative_do
                                        , string do_file
                                        , DateTime create_date
                                        , int create_user)
        {
            string returnVal = string.Empty;

            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Initiative();

            DataTable dtBscKpiInitiative = dacBscKpiInitiative.SelectData_DB(iestterm_ref_id
                                                                            , ikpi_ref_id
                                                                            , iymd).Tables[0];

            try
            {
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dacBscKpiResult = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();

                affectedRow = dacBscKpiResult.UpdataData_DB(conn
                                                          , trx
                                                          , iestterm_ref_id
                                                          , ikpi_ref_id
                                                          , iymd
                                                          , iresult_ms
                                                          , iresult_ts
                                                          , isequence
                                                          , "Y"
                                                          , ical_result_ms
                                                          , ical_result_ts
                                                          , cal_apply_yn
                                                          , cal_apply_reason
                                                          , cause_text_ms
                                                          , cause_text_ts
                                                          , cause_file_id
                                                          , imeasure_text_ms
                                                          , imeasure_text_ts
                                                          , imeasure_file_id
                                                          , iremark
                                                          , create_user
                                                          , create_date);


                if (dtBscKpiInitiative.Rows.Count > 0)
                {
                    affectedRow = dacBscKpiInitiative.UpdateDo_DB(conn
                                                                  , trx
                                                                  , iestterm_ref_id
                                                                  , ikpi_ref_id
                                                                  , iymd
                                                                  , initiative_do
                                                                  , do_file
                                                                  , create_date
                                                                  , create_user);
                }
                else
                {
                    affectedRow = dacBscKpiInitiative.InsertData_DB(conn
                                                                  , trx
                                                                  , iestterm_ref_id
                                                                  , ikpi_ref_id
                                                                  , iymd
                                                                  , DBNull.Value
                                                                  , initiative_do
                                                                  , do_file
                                                                  , DBNull.Value
                                                                  , create_user);
                }




                //trx.Rollback();
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                returnVal = ex.Message;
                return returnVal;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }

        #endregion



        /// <summary>
        /// 프로젝트 평가점수와 KPI실적 연계
        /// </summary>
        /// <param name="est_id">조직KPI:3A, 개인KPI:3GA</param>
        /// <param name="ymd">KPI 기간 yyyyMM</param>
        public bool Modify_Point_Rel_Prj_Kpi(IDbConnection conn, IDbTransaction trx
                                            , int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int est_dept_id
                                            , int est_emp_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id
                                            , int kpi_ref_id
                                            , string ymd
                                            , int update_user_ref_id)
        {
            bool result = false;
            int affectedRow = 0;


            Dac_Est_Data dacEstData = new Dac_Est_Data();
            Dac_Bsc_Kpi_Result dacBscKpiResult = new Dac_Bsc_Kpi_Result();
            Dac_Com_Approval_Info dacComApprovalInfo = new Dac_Com_Approval_Info();
            Dac_Com_Approval_Prc dacComApprovalPrc = new Dac_Com_Approval_Prc();


            string bizType = "";
            if(est_id.Equals("3A"))
                bizType = "KRA";
            else if(est_id.Equals("3GA"))
                bizType = "TRA";


            DataTable dtEstData = dacEstData.Select_Est_Data_Join_Est_Esu(conn, trx
                                                                        , comp_id
                                                                        , est_id
                                                                        , estterm_ref_id
                                                                        , estterm_sub_id
                                                                        , 1                 //estterm_step_id
                                                                        , est_dept_id
                                                                        , est_emp_id
                                                                        , tgt_dept_id
                                                                        , tgt_emp_id
                                                                        , ""
                                                                        , ""
                                                                        , OwnerType.All).Tables[0];


            if (dtEstData.Rows.Count > 0 && bizType.Length >0)
            {
                try
                {
                    string prj_point = DataTypeUtility.GetString(dtEstData.Rows[0]["POINT"]);

                    int app_ref_id = dacComApprovalInfo.SelectMaxAppRefID(conn, trx);

                    affectedRow += dacComApprovalInfo.InsertApprovalinfo_DB(conn, trx
                                                                            , app_ref_id
                                                                            , 1                 //VERSION_NO
                                                                            , ""                //APP_CODE
                                                                            , "Y"               //ACTIVE_YN
                                                                            , ""                //ORI_DOC
                                                                            , "프로젝트 평가"   //TITLE
                                                                            , bizType
                                                                            , "CFT"             //APP_STATUS
                                                                            , "FD"              //DRAFT_STATUS : FD, MD, RD
                                                                            , update_user_ref_id
                                                                            , System.DateTime.Now.ToString("yyyy-MM-dd"));

                    affectedRow += dacComApprovalPrc.InsertApprovalPrc_DB(conn, trx
                                                                        , app_ref_id
                                                                        , 1                     //VERSION_NO
                                                                        , 1                     //LINE_STEP
                                                                        , update_user_ref_id    //APP_EMP_ID
                                                                        , "Y"                   //COMPLETE_TN
                                                                        , ""                    //COMMENTS
                                                                        , ""                    //RETURN_REASON
                                                                        , "D"                   //LINE_TYPE
                                                                        , "NAME"                //APP_METHOD
                                                                        , update_user_ref_id
                                                                        , System.DateTime.Now.ToString("yyyy-MM-dd"));

                    affectedRow += dacBscKpiResult.UpdateData_DB(conn, trx
                                                                , estterm_ref_id
                                                                , kpi_ref_id
                                                                , ymd
                                                                , prj_point
                                                                , prj_point
                                                                , app_ref_id
                                                                , update_user_ref_id);

                    if (affectedRow == 3)
                    {
                        trx.Commit();
                        result = true;
                    }
                    else
                    {
                        trx.Rollback();
                        affectedRow = 0;
                    }
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    affectedRow = 0;
                }
                finally
                {
                    conn.Close();
                }
            }


            return result;
        }
    }
}
