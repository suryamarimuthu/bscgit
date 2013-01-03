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
using System.Transactions;

using MicroBSC.Data;
//using MicroBSC.BSC.Dac;
using MicroBSC.Biz.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Info에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Kpi_Info Biz 클래스
    /// Class 내용		: Bsc_Kpi_Info Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2007.04.26
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Info : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Info
    {
        public Biz_Bsc_Kpi_Info() { }
        public Biz_Bsc_Kpi_Info(int iestterm_ref_id, int ikpi_ref_id) : base(iestterm_ref_id, ikpi_ref_id) { }

        public int InsertData
              (int iestterm_ref_id,         string ikpi_code,               int ikpi_pool_ref_id,               string iword_definition, 
               string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
               int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
               string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
               int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,     
               string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user)
        {
            return base.InsertData_Dac
              (iestterm_ref_id,      ikpi_code,                ikpi_pool_ref_id,           iword_definition, 
               imeasurement_purpose, icalc_form_ms,            icalc_form_ts,              irelated_issue,           iadd_file, 
               ichampion_emp_id,     imeasurement_emp_id,      iapproval_emp_id,           idata_gethering_method,   iresult_term_type, 
               iresult_input_type,   iresult_achievement_type, iresult_ts_calc_type,       iresult_measurement_step, imeasurement_grade_type, 
               iunit_type_ref_id,    ikpi_target_version_id,   ikpi_target_setting_reason, ikpi_target_reason_file,  iapproval_status,     
               igraph_type,          iapp_ref_id,              iexcel_dnuse,               iis_team_kpi,             iuse_yn,                  itxr_user);
        }

        public int UpdateData
              (int iestterm_ref_id,         int ikpi_ref_id,                 string ikpi_code,                  int ikpi_pool_ref_id,            string iword_definition, 
               string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
               int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
               string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
               int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,     
               string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user)
        {
            return base.UpdateData_Dac
              (iestterm_ref_id,      ikpi_ref_id,              ikpi_code,                  ikpi_pool_ref_id,         iword_definition, 
               imeasurement_purpose, icalc_form_ms,            icalc_form_ts,              irelated_issue,           iadd_file, 
               ichampion_emp_id,     imeasurement_emp_id,      iapproval_emp_id,           idata_gethering_method,   iresult_term_type, 
               iresult_input_type,   iresult_achievement_type, iresult_ts_calc_type,       iresult_measurement_step, imeasurement_grade_type, 
               iunit_type_ref_id,    ikpi_target_version_id,   ikpi_target_setting_reason, ikpi_target_reason_file,  iapproval_status,     
               igraph_type,          iapp_ref_id,              iexcel_dnuse,               iis_team_kpi,             iuse_yn,    itxr_user);
        }

        public int SetKpiParent(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 iup_kpi_ref_id, double iup_kpi_weight, string irollup_target_yn, string irollup_score_yn, Int32 itxr_user)
        {
            return base.SetKpiParent_Dac(iestterm_ref_id
                                       , ikpi_ref_id
                                       , iup_kpi_ref_id
                                       , iup_kpi_weight
                                       , irollup_target_yn
                                       , irollup_score_yn
                                       , itxr_user);
        }

        public int RemoveKpiParent(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        { 
            return base.RemoveKpiParent_Dac(iestterm_ref_id
                                          , ikpi_ref_id
                                          , itxr_user);
        }

        public bool TxrKPIMaster
              (string iType,
               int iestterm_ref_id,         int ikpi_ref_id,                 string ikpi_code,                  int ikpi_pool_ref_id,            string iword_definition, 
               string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
               int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
               string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
               int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,     
               string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user,               DataSet iDs,                     out string oTxrMessage)
        {
            int intRow = 0;
            int intCol = 0;
            int intTxrCnt = 0;
            Dac_ctl_ctl2100_Role dacRoleInfo = new Dac_ctl_ctl2100_Role();
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();

            /* 2011-05-24 수정 : 챔피언의 권한그룹을 조회하여 챔피언 권한의 존재여부를 조회한다 */
            bool hasChapionAuth = true;
            DataSet dsRole = dacRoleInfo.GetRoleInfo(ichampion_emp_id);
            if (dsRole != null)
            {
                if (dsRole.Tables.Count > 0)
                {
                    DataRow [] dataRowArray = dsRole.Tables[0].Select("ROLE_REF_ID = 3");

                    if (dataRowArray.Length > 0)
                    {
                        hasChapionAuth = false;
                    }
                }
            }
            /* 2011-05-24 수정 완료 ***************************************************************/
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                ////////////////////////////////////////////////////
                // KPI KPI MASTER 
                ////////////////////////////////////////////////////
                if (iType == "A")
                {
                    intTxrCnt += base.InsertData_Dac
                    (conn, trx,
                     iestterm_ref_id,      ikpi_code,                ikpi_pool_ref_id,           iword_definition,
                     imeasurement_purpose, icalc_form_ms,            icalc_form_ts,              irelated_issue,           iadd_file,
                     ichampion_emp_id,     imeasurement_emp_id,      iapproval_emp_id,           idata_gethering_method,   iresult_term_type,
                     iresult_input_type,   iresult_achievement_type, iresult_ts_calc_type,       iresult_measurement_step, imeasurement_grade_type,
                     iunit_type_ref_id,    ikpi_target_version_id,   ikpi_target_setting_reason, ikpi_target_reason_file,  iapproval_status,     
                     igraph_type,          iapp_ref_id,              iexcel_dnuse,               iis_team_kpi,             iuse_yn,                  itxr_user
                    );

                    /* 2011-05-24 수정 : 챔피언 권한을 가지고 있지 않은 경우에는 챔피언 권한을 강제로 부여한다. */
                    if (hasChapionAuth == false)
                    {
                        dacRoleInfo.AddRoleInfo(ichampion_emp_id, 3);
                    }
                    /* 2011-05-24 수정 완료 **********************************************************************/

                    if (this.Transaction_Result == "N")
                    {
                        oTxrMessage = this.Transaction_Message;
                        trx.Rollback();
                        return false;
                    }
                }
                else if (iType == "U")
                {
                    intTxrCnt += base.UpdateData_Dac
                   (conn, trx,
                    iestterm_ref_id,      ikpi_ref_id,              ikpi_code,                  ikpi_pool_ref_id,         iword_definition, 
                    imeasurement_purpose, icalc_form_ms,            icalc_form_ts,              irelated_issue,           iadd_file, 
                    ichampion_emp_id,     imeasurement_emp_id,      iapproval_emp_id,           idata_gethering_method,   iresult_term_type, 
                    iresult_input_type,   iresult_achievement_type, iresult_ts_calc_type,       iresult_measurement_step, imeasurement_grade_type, 
                    iunit_type_ref_id,    ikpi_target_version_id,   ikpi_target_setting_reason, ikpi_target_reason_file,  iapproval_status,     
                    igraph_type,          iapp_ref_id,              iexcel_dnuse,               iis_team_kpi,             iuse_yn,                  itxr_user);

                    /* 2011-05-24 수정 : 챔피언 권한을 가지고 있지 않은 경우에는 챔피언 권한을 강제로 부여한다. */
                    if (hasChapionAuth == false)
                    {
                        dacRoleInfo.AddRoleInfo(ichampion_emp_id, 3);
                    }
                    /* 2011-05-24 수정 완료 **********************************************************************/

                    if (this.Transaction_Result == "N")
                    {
                        oTxrMessage = this.Transaction_Message;
                        trx.Rollback();
                        return false;
                    }

                    base.Ikpi_ref_id = ikpi_ref_id;
                }
                else if (iType == "D")
                {
                    intTxrCnt += base.DeleteData_Dac
                    (conn, trx, iestterm_ref_id, ikpi_ref_id, itxr_user);
                    oTxrMessage = base.Transaction_Message;

                    if (base.Transaction_Result == "Y")
                    {
                        trx.Commit();
                        return true;
                    }
                    else
                    {
                        trx.Rollback();
                        return true;
                    }
                }
                else if (iType == "RU")
                {
                    intTxrCnt += base.ReUsedData_Dac
                    (conn, trx, iestterm_ref_id, ikpi_ref_id, itxr_user);
                    oTxrMessage = base.Transaction_Message;
                    if (base.Transaction_Result == "Y")
                    {
                        trx.Commit();
                        return true;
                    }
                    else
                    {
                        trx.Rollback();
                        return true;
                    }
                }

                ////////////////////////////////////////////////////
                // KPI DATA SOURCE 
                ////////////////////////////////////////////////////
                DataTable rDT1 = iDs.Tables["BSC_KPI_DATASOURCE"];

                intRow = rDT1.Rows.Count;
                intCol = rDT1.Columns.Count;
                Biz_Bsc_Kpi_Datasource objBSC1 = new Biz_Bsc_Kpi_Datasource();
                for (int i = 0; i < intRow; i++)
                {
                    if (rDT1.Rows[i]["ITYPE"].ToString() == "A")
                    {
                        intTxrCnt += objBSC1.InsertData
                                     (conn, trx,
                                      int.Parse(rDT1.Rows[i]["ESTTERM_REF_ID"].ToString())
                                    , base.Ikpi_ref_id
                                    , rDT1.Rows[i]["LEVEL1"].ToString()
                                    , rDT1.Rows[i]["LEVEL2"].ToString()
                                    , rDT1.Rows[i]["LEVEL3"].ToString()
                                    , rDT1.Rows[i]["RESULT_SOURCE"].ToString()
                                    , rDT1.Rows[i]["TARGET_SOURCE"].ToString()
                                    , rDT1.Rows[i]["RESULT_CREATE_TIME"].ToString()
                                    , int.Parse(rDT1.Rows[i]["UNIT_TYPE_REF_ID"].ToString())
                                    , itxr_user);
                    }
                    else if (rDT1.Rows[i]["ITYPE"].ToString() == "U")
                    {
                        intTxrCnt += objBSC1.UpdateData
                                     (conn, trx,
                                      int.Parse(rDT1.Rows[i]["ESTTERM_REF_ID"].ToString())
                                    , base.Ikpi_ref_id
                                    , int.Parse(rDT1.Rows[i]["DATASOURCE_ID"].ToString())
                                    , rDT1.Rows[i]["LEVEL1"].ToString()
                                    , rDT1.Rows[i]["LEVEL2"].ToString()
                                    , rDT1.Rows[i]["LEVEL3"].ToString()
                                    , rDT1.Rows[i]["RESULT_SOURCE"].ToString()
                                    , rDT1.Rows[i]["TARGET_SOURCE"].ToString()
                                    , rDT1.Rows[i]["RESULT_CREATE_TIME"].ToString()
                                    , int.Parse(rDT1.Rows[i]["UNIT_TYPE_REF_ID"].ToString())
                                    , itxr_user);
                    }
                    else if (rDT1.Rows[i]["ITYPE"].ToString() == "D")
                    {
                        intTxrCnt += objBSC1.DeleteData
                                     (conn
                                    , trx
                                    , int.Parse(rDT1.Rows[i]["ESTTERM_REF_ID"].ToString())
                                    , base.Ikpi_ref_id
                                    , int.Parse(rDT1.Rows[i]["DATASOURCE_ID"].ToString())
                                    , itxr_user);
                    }
                }

                ////////////////////////////////////////////////////
                // KPI TERM 
                ////////////////////////////////////////////////////
                DataTable rDT2 = iDs.Tables["BSC_KPI_TERM"];

                intRow = rDT2.Rows.Count;
                intCol = rDT2.Columns.Count;
                Biz_Bsc_Kpi_Term objBSC2 = new Biz_Bsc_Kpi_Term();

                for (int i = 0; i < intRow; i++)
                {
                    if (rDT2.Rows[i]["ITYPE"].ToString() == "A")
                    {
                        intTxrCnt += objBSC2.InsertData
                                    (conn
                                   , trx
                                   , iestterm_ref_id
                                   , base.Ikpi_ref_id
                                   , rDT2.Rows[i]["YMD"].ToString()
                                   , rDT2.Rows[i]["CHECK_YN"].ToString()
                                   , rDT2.Rows[i]["REPORT_YN"].ToString()
                                   , "N"
                                   , itxr_user
                                    );
                    }
                    else if (rDT2.Rows[i]["ITYPE"].ToString() == "U")
                    {
                        intTxrCnt += objBSC2.UpdateData
                                    (conn
                                   , trx
                                   , iestterm_ref_id
                                   , base.Ikpi_ref_id
                                   , rDT2.Rows[i]["YMD"].ToString()
                                   , rDT2.Rows[i]["CHECK_YN"].ToString()
                                   , rDT2.Rows[i]["REPORT_YN"].ToString()
                                   , "N"
                                   , itxr_user
                                    );
                    }
                }

                ////////////////////////////////////////////////////
                // KPI TARGET 
                ////////////////////////////////////////////////////
                DataTable rDT3 = iDs.Tables["BSC_KPI_TARGET"];

                intRow = rDT3.Rows.Count;
                intCol = rDT3.Columns.Count;
                Biz_Bsc_Kpi_Target objBSC3 = new Biz_Bsc_Kpi_Target();

                for (int i = 0; i < intRow; i++)
                {
                    if (rDT3.Rows[i]["ITYPE"].ToString() == "A")
                    {
                        intTxrCnt += objBSC3.InsertData
                                    (conn
                                   , trx
                                   , iestterm_ref_id
                                   , base.Ikpi_ref_id
                                   , int.Parse(rDT3.Rows[i]["KPI_TARGET_VERSION_ID"].ToString())
                                   , rDT3.Rows[i]["YMD"].ToString()
                                   , double.Parse(rDT3.Rows[i]["TARGET_MS"].ToString())
                                   , double.Parse(rDT3.Rows[i]["TARGET_TS"].ToString())
                                   , itxr_user
                                    );
                    }
                    else if (rDT3.Rows[i]["ITYPE"].ToString() == "U")
                    {
                        intTxrCnt += objBSC3.UpdateData
                                    (conn
                                   , trx
                                   , iestterm_ref_id
                                   , base.Ikpi_ref_id
                                   , int.Parse(rDT3.Rows[i]["KPI_TARGET_VERSION_ID"].ToString())
                                   , rDT3.Rows[i]["YMD"].ToString()
                                   , double.Parse(rDT3.Rows[i]["TARGET_MS"].ToString())
                                   , double.Parse(rDT3.Rows[i]["TARGET_TS"].ToString())
                                   , itxr_user
                                    );
                    }
                }

                ////////////////////////////////////////////////////
                // KPI THRESHOLD 
                ////////////////////////////////////////////////////
                DataTable rDT4 = iDs.Tables["BSC_KPI_THRESHOLD_INFO"];

                intRow = rDT4.Rows.Count;
                intCol = rDT4.Columns.Count;
                Biz_Bsc_Kpi_Threshold_Info objBSC4 = new Biz_Bsc_Kpi_Threshold_Info();

                int intRtn = objBSC4.DeleteAllData(conn, trx, iestterm_ref_id, base.Ikpi_ref_id, itxr_user);

                for (int i = 0; i < intRow; i++)
                {
                    if (rDT4.Rows[i]["ITYPE"].ToString() == "A")
                    {
                        intTxrCnt += objBSC4.InsertData
                                    (conn
                                   , trx
                                   , iestterm_ref_id
                                   , base.Ikpi_ref_id
                                   , int.Parse(rDT4.Rows[i]["THRESHOLD_REF_ID"].ToString())
                                   , rDT4.Rows[i]["THRESHOLD_LEVEL"].ToString()
                                   , double.Parse(rDT4.Rows[i]["SET_MIN_VALUE"].ToString())
                                   , double.Parse(rDT4.Rows[i]["SET_MAX_VALUE"].ToString())
                                   , double.Parse(rDT4.Rows[i]["ACHIEVE_RATE"].ToString())
                                   , itxr_user
                                    );
                    }
                    else if (rDT4.Rows[i]["ITYPE"].ToString() == "U")
                    {
                        intTxrCnt += objBSC4.UpdateData
                                    (conn
                                   , trx
                                   , iestterm_ref_id
                                   , base.Ikpi_ref_id
                                   , int.Parse(rDT4.Rows[i]["THRESHOLD_REF_ID"].ToString())
                                   , rDT4.Rows[i]["THRESHOLD_LEVEL"].ToString()
                                   , double.Parse(rDT4.Rows[i]["SET_MIN_VALUE"].ToString())
                                   , double.Parse(rDT4.Rows[i]["SET_MAX_VALUE"].ToString())
                                   , double.Parse(rDT4.Rows[i]["ACHIEVE_RATE"].ToString())
                                   , itxr_user
                                    );
                    }
                }

                ////////////////////////////////////////////////////
                // KPI INITIATIVE
                ////////////////////////////////////////////////////
                DataTable rDT5 = iDs.Tables["BSC_KPI_INITIATIVE"];

                intRow = rDT5.Rows.Count;
                intCol = rDT5.Columns.Count;
                Biz_Bsc_Kpi_Initiative objBSC5 = new Biz_Bsc_Kpi_Initiative();

                for (int i = 0; i < intRow; i++)
                {
                    intTxrCnt += objBSC5.InsertData
                                (iestterm_ref_id
                               , base.Ikpi_ref_id
                               , rDT5.Rows[i]["YMD"].ToString()
                               , rDT5.Rows[i]["INITIATIVE_PLAN"].ToString()
                               , rDT5.Rows[i]["INITIATIVE_DO"].ToString()
                               , rDT5.Rows[i]["INITIATIVE_DESC"].ToString()
                               , itxr_user
                                );
                }

                ////////////////////////////////////////////////////
                // BSC_KPI_QLT_TERM_WEIGHT
                ////////////////////////////////////////////////////
                DataTable rDT6 = iDs.Tables["BSC_KPI_QLT_TERM_WEIGHT"];

                intRow = rDT6.Rows.Count;
                intCol = rDT6.Columns.Count;
                Biz_Bsc_Kpi_Qlt_Term_Weight objBSC6 = new Biz_Bsc_Kpi_Qlt_Term_Weight();

                for (int i = 0; i < intRow; i++)
                {
                    intTxrCnt += objBSC6.InsertData
                                (iestterm_ref_id
                               , base.Ikpi_ref_id
                               , rDT6.Rows[i]["YMD"].ToString()
                               , Convert.ToInt32(rDT6.Rows[i]["EST_LEVEL"].ToString())
                               , Convert.ToDouble(rDT6.Rows[i]["WEIGHT"].ToString())
                               , itxr_user
                                );
                }

                oTxrMessage = "정상적으로 처리되었습니다.";
                trx.Commit();
            }
            catch(Exception e)
            {
                oTxrMessage = e.Message.Replace("'", "").Replace("\\r\\n", "\\n");
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public int DeleteData(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, itxr_user);
        }

        /// <summary>
        /// KPI 정의서 확정
        /// </summary>
        /// <param name="iDt">Datatable Col1:ESTTERM_REF_ID-int, Col2:KPI_REF_ID-int, Col3:TXR_USER-int</param>
        /// <returns></returns>
        public int SetKpiConirm(DataTable iDt)
        {
            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                DataRow dr;
                for (int i = 0; i < iDt.Rows.Count; i++)
                {
                    dr = iDt.Rows[i];
                    base.Iestterm_ref_id = int.Parse(dr["ESTTERM_REF_ID"].ToString());
                    base.Ikpi_ref_id     = int.Parse(dr["KPI_REF_ID"].ToString());
                    base.Itxr_user       = int.Parse(dr["TXR_USER"].ToString());
                    intTxrCnt += base.SetKpiConirm_Dac(conn, trx, base.Iestterm_ref_id, base.Ikpi_ref_id, base.Itxr_user);
                }

                trx.Commit();
            }
            catch
            {
                trx.Rollback();
                return 0;
            }
            finally 
            {
                conn.Close();
            }

            return intTxrCnt;
        }

        public int UseYNMBO(int estterm_ref_id
                            , int kpi_ref_id
                            , string use_yn)
        {
            int rtnCtn = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnCtn = base.UseYNMBO(conn
                                        , trx
                                        , estterm_ref_id
                                        , kpi_ref_id
                                        , use_yn);
                if (rtnCtn > 0)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
                rtnCtn = 0;
            }
            finally
            {
                conn.Close();
            }
            return rtnCtn;
        }

        /// <summary>
        /// MBO 정의서
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public int InsertMBO(int estterm_ref_id
                            , int kpi_ref_id
                            , string kpi_code
                            , int kpi_pool_ref_id
                            , string word_definition
                            , string calc_form_ms
                            , int champion_emp_id
                            , string result_achievement_type
                            , string result_ts_calc_type
                            , string result_input_type
                            , string result_measurement_step
                            , string measurement_grade_type
                            , int unit_type_ref_id
                            , string kpi_target_version_id
                            , string kpi_target_setting_reason
                            , string kpi_target_reason_file
                            , string approval_status
                            , string excel_dnuse
                            , string is_team_kpi
                            , int create_user
                            , DataSet addDS)
        {
            int intRtnKpiRefID = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                intRtnKpiRefID = base.InsertMBO(conn
                                        , trx
                                        , estterm_ref_id
                                        , kpi_ref_id
                                        , kpi_code
                                        , kpi_pool_ref_id
                                        , word_definition
                                        , calc_form_ms
                                        , champion_emp_id
                                        , result_achievement_type
                                        , result_ts_calc_type
                                        , result_input_type
                                        , result_measurement_step
                                        , measurement_grade_type
                                        , unit_type_ref_id
                                        , kpi_target_version_id
                                        , kpi_target_setting_reason
                                        , kpi_target_reason_file
                                        , approval_status
                                        , excel_dnuse
                                        , create_user
                                        , addDS);
                if (intRtnKpiRefID > 0)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
                intRtnKpiRefID = 0;
            }
            finally
            {
                conn.Close();
            }

            return intRtnKpiRefID;
        }


        

        public int ConfirmMBO(int estterm_ref_id
                            , int kpi_ref_id
                            , bool isConfirm)
        {
            int rtnCtn = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnCtn = base.ConfirmMBO(conn
                                        , trx
                                        , estterm_ref_id
                                        , kpi_ref_id
                                        , isConfirm);
                if (rtnCtn > 0)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
                rtnCtn = 0;
            }
            finally
            {
                conn.Close();
            }
            return rtnCtn;
        }

        /// <summary>
        /// KPI 정의서 확정취소
        /// </summary>
        /// <param name="iDt">Datatable Col1:ESTTERM_REF_ID-int, Col2:KPI_REF_ID-int, Col3:TXR_USER-int</param>
        /// <returns>처리행수</returns>
        public int SetKpiCancel(DataTable iDt)
        {
            int intTxrCnt = 0;
            DataRow dr;
            for (int i = 0; i < iDt.Rows.Count; i++)
            {
                dr = iDt.Rows[i];
                base.Iestterm_ref_id = int.Parse(dr["ESTTERM_REF_ID"].ToString());
                base.Ikpi_ref_id     = int.Parse(dr["KPI_REF_ID"].ToString());
                base.Itxr_user       = int.Parse(dr["TXR_USER"].ToString());
                intTxrCnt += base.SetKpiCancel_Dac(base.Iestterm_ref_id, base.Ikpi_ref_id, base.Itxr_user);
            }

            return intTxrCnt;
        }

        /// <summary>
        /// 지표복사
        /// </summary>
        /// <param name="iDt">Datatable Col1:ESTTERM_REF_ID_FR-int, Col2:KPI_REF_ID-int, Col3:ESTTERM_REF_ID_TO-int, Col4:TXR_USER-int</param>
        /// <returns></returns>
        public int CopyKpiToAnotherTerm(DataTable iDt)
        { 
            int intTxrCnt = 0;
            int estterm_ref_id_fr = 0;
            int kpi_ref_id        = 0;
            int estterm_ref_id_to = 0;
            int loginid           = 0;
            int affRow            = 0;
            DataRow dr;
            for (int i = 0; i < iDt.Rows.Count; i++)
            {
                dr = iDt.Rows[i];
                estterm_ref_id_fr = int.Parse(dr["ESTTERM_REF_ID_FR"].ToString());
                kpi_ref_id        = int.Parse(dr["KPI_REF_ID"].ToString());
                estterm_ref_id_to = int.Parse(dr["ESTTERM_REF_ID_TO"].ToString());
                loginid           = int.Parse(dr["TXR_USER"].ToString());

                intTxrCnt = base.CopyKpiToAnotherTerm_Dac
                                ( estterm_ref_id_fr
                                , kpi_ref_id
                                , estterm_ref_id_to
                                , loginid);

                if (base.Transaction_Result == "Y")
                {
                    affRow += 1;
                }
            }

            return affRow;
        }

        public void MakeKpiTree(TreeView iTreeView, int estterm_ref_id, int kpi_ref_id, bool search_from_top)
        {
            iTreeView.Nodes.Clear();
            iTreeView.ShowLines = false;
            DataSet dsTree      = base.GetKpiTree(estterm_ref_id, kpi_ref_id, search_from_top);

            string strSfId              = "";       // 부서 ID
            string strPtId              = "";       // 부모 부서 ID
            string strDept              = "";       // 부서명
            string strLevel             = "";       // 부서레벨
            string strDeptNm            = "";       // 부서명
            string strWeight            = "0";
            int intIdx                  = 0;
            int intRow                  = dsTree.Tables[0].Rows.Count;


            TreeNode[] arrNodeList      = new TreeNode[intRow];
            string[] arrSelfNdID        = new string[intRow];
            bool blnSW                  = false;

            iTreeView.Nodes.Clear();
            foreach (DataRow dr in dsTree.Tables[0].Rows)
            {
                strSfId                 = dr["KPI_REF_ID"].ToString();
                strPtId                 = dr["UP_KPI_REF_ID"].ToString();
                strDept                 = dr["KPI_NAME"].ToString();
                strLevel                = dr["KPI_LEVEL"].ToString();
                strDeptNm               = dr["COM_DEPT_NAME"].ToString();
                strWeight               = dr["UP_KPI_WEIGHT"].ToString();

                TreeNode trnDept;
                trnDept                 = new TreeNode();
                
                //strDept, strSfId
                trnDept.Value           = strSfId;
                trnDept.Text            = strDept+"("+strDeptNm+")";
                arrNodeList[intIdx]     = trnDept;
                arrSelfNdID[intIdx]     = strSfId;

                int k;
                for (k = 0; k < arrSelfNdID.Length; k++)
                {
                    if (strPtId == arrSelfNdID[k])
                    {
                        arrNodeList[k].ChildNodes.Add(trnDept);
                        blnSW           = true;
                        break;
                    }
                }

                if (!blnSW)
                {
                    iTreeView.Nodes.Add(trnDept);
                    blnSW               = false;
                }

                trnDept.ImageUrl        = "~/images/icon/0" + strLevel + "_2.gif";
                intIdx                  += 1;
            }
        }

        /// <summary>
        /// 조직KPI를 MBO로 복사
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public bool CopyKpiToMbo(int estterm_ref_id
                            , object[] objList
                            , int emp_ref_id
                            , string estYear
                            , string class_type)
        {
            bool rtnValue = false;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.CopyKpiToMbo(conn
                                        , trx
                                        , estterm_ref_id
                                        , objList
                                        , emp_ref_id
                                        , estYear
                                        , class_type);
                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                this.Transaction_Message = ex.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }


        

        /// <summary>
        /// 조직KPI에서 복사한 MBO를 삭제
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public bool DeleteMboToKpi(int estterm_ref_id
                            , object[] objList
                            , int emp_ref_id)
        {
            bool rtnValue = false;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                rtnValue = base.DeleteMboToKpi(conn
                                        , trx
                                        , estterm_ref_id
                                        , objList
                                        , emp_ref_id);
                if (rtnValue)
                    trx.Commit();
                else
                {
                    trx.Rollback();
                }
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }

        /// <summary>
        /// 조직KPI에서 복사한 MBO를 삭제
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public DataSet GetKpiForMboResult(int estterm_ref_id, int kpi_ref_id, int emp_ref_id, string ymd)
        {
            return base.GetKpiForMboResult(estterm_ref_id, kpi_ref_id, emp_ref_id, ymd);
        }

        public DataSet GetMBOForDeptKpi(int estterm_ref_id
                                        , string kpi_code
                                        , string kpi_name
                                        , string champion_emp_name
                                        , string kpi_group_ref_id
                                        , int com_dept_ref_id
                                        , int category_top_ref_id
                                        , int category_mid_ref_id
                                        , int category_low_ref_id
                                        , int emp_ref_id
                                        , int is_admin
                                        , int dept_id)
        {
            return base.GetMBOForDeptKpi(estterm_ref_id
                                        , kpi_code
                                        , kpi_name
                                        , champion_emp_name
                                        , kpi_group_ref_id
                                        , com_dept_ref_id
                                        , category_top_ref_id
                                        , category_mid_ref_id
                                        , category_low_ref_id
                                        , emp_ref_id
                                        , is_admin
                                        , dept_id);
        }

        

        #region ========================== 멀티 DB 작업 ============================
        /// <summary>
        /// 조직KPI를 MBO로 복사(멀티DB 적용)
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string CopyKpiToMbo_NW(int estterm_ref_id
                            , object[] objList
                            , int emp_ref_id
                            , string estYear
                            , string class_type)
        {
            string returnStr = string.Empty;
            bool rtnValue = false;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                string filter = string.Empty;
                foreach (object obj in objList)
                {
                    filter += string.Format(",{0}", obj);
                }

                if (filter.Length > 1)
                {
                    filter = string.Format(" AND ORG_KPI_REF_ID IN ({0}) ", filter.Remove(0, 1));
                }

                DataTable dtBscMboKpiClassification = base.SelectBscMboKpiClassification_DB(estterm_ref_id
                                                                                        , emp_ref_id
                                                                                        , 0
                                                                                        , filter);

                if (dtBscMboKpiClassification.Rows.Count > 0)
                {
                    rtnValue = false;
                    returnStr = "이미 MBO에 등록된 조직KPI 있습니다.";

                    return returnStr;
                }

                int okCnt = 0;
                foreach (object obj in objList)
                {
                    okCnt = CopyBscKpiInfo_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , emp_ref_id
                                            , obj);

                    if (okCnt > 0)
                    {
                        int newKpiRefID = SelectMaxBscKpiInfo_DB(conn, trx);
                        okCnt = DeleteBscKpiTargetVersion_DB(conn
                                                            , trx
                                                            , estterm_ref_id
                                                            , newKpiRefID);

                        okCnt = InsertBscKpiTargetVersion_DB(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , newKpiRefID
                                                           , emp_ref_id);

                        okCnt = DeleteBscKpiResult_DB(conn
                                                   , trx
                                                   , estterm_ref_id
                                                   , newKpiRefID);

                        okCnt = CopyBscTermDetailToBscKpiResult_DB(conn
                                                                   , trx
                                                                   , estterm_ref_id
                                                                   , newKpiRefID
                                                                   , emp_ref_id);

                        okCnt = UpdateBscKpiInfo_DB(conn
                                                  , trx
                                                  , estterm_ref_id
                                                  , newKpiRefID
                                                  , 0);

                        Dac_ctl_ctl2100_Role dacRole = new Dac_ctl_ctl2100_Role();

                        okCnt = dacRole.DelRoleInfo(conn
                                                     , trx
                                                     , emp_ref_id
                                                     , 3);

                        okCnt = dacRole.AddRoleInfo(conn
                                                     , trx
                                                     , emp_ref_id
                                                     , 3);

                        //okCnt = DeleteComEmpRoleRel_DB(conn
                        //                             , trx
                        //                             , emp_ref_id);

                        //okCnt = InsertComEmpRoleRel_DB(conn
                        //                             , trx
                        //                             , emp_ref_id);

                        okCnt = InsertBscMboKpiClassification_DB(conn
                                                               , trx
                                                               , estterm_ref_id
                                                               , newKpiRefID
                                                               , emp_ref_id
                                                               , obj
                                                               , class_type);

                        rtnValue = base.CopyKpiToMbo_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj
                                            , emp_ref_id
                                            , newKpiRefID
                                            , estYear
                                            , "PRS");
                    }
                }


                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch (Exception ex)
            {
                returnStr = ex.Message;
                this.Transaction_Message = ex.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return returnStr;
        }


        /// <summary>
        /// MBO 정의서 등록
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public int AddMBO_NW(int estterm_ref_id
                            , int kpi_ref_id
                            , string kpi_code
                            , int kpi_pool_ref_id
                            , string word_definition
                            , string calc_form_ms
                            , int champion_emp_id
                            , string result_achievement_type
                            , string result_ts_calc_type
                            , string result_input_type
                            , string result_measurement_step
                            , string measurement_grade_type
                            , int unit_type_ref_id
                            , string kpi_target_version_id
                            , string kpi_target_setting_reason
                            , string kpi_target_reason_file
                            , string approval_status
                            , string excel_dnuse
                            , string is_team_kpi
                            , int create_user
                            , DataSet addDS
                            , ref string returnMsg)
        {
            
            int newKpiRefID = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {

                int okCnt = base.InsertBscKpiInfo_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , kpi_ref_id
                                                        , kpi_code
                                                        , kpi_pool_ref_id
                                                        , word_definition
                                                        , calc_form_ms
                                                        , champion_emp_id
                                                        , result_achievement_type
                                                        , result_ts_calc_type
                                                        , result_input_type
                                                        , result_measurement_step
                                                        , measurement_grade_type
                                                        , unit_type_ref_id
                                                        , kpi_target_version_id
                                                        , kpi_target_setting_reason
                                                        , kpi_target_reason_file
                                                        , approval_status
                                                        , excel_dnuse
                                                        , create_user);

                if (okCnt > 0)
                {
                    newKpiRefID = SelectMaxBscKpiInfo_DB(conn
                                                        , trx);

                    okCnt = DeleteBscKpiTargetVersion_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , newKpiRefID);

                    okCnt = InsertBscKpiTargetVersion_DB(conn
                                                       , trx
                                                       , estterm_ref_id
                                                       , newKpiRefID
                                                       , champion_emp_id);

                    okCnt = DeleteBscKpiResult_DB(conn
                                               , trx
                                               , estterm_ref_id
                                               , newKpiRefID);

                    okCnt = CopyBscTermDetailToBscKpiResult_DB(conn
                                                               , trx
                                                               , estterm_ref_id
                                                               , newKpiRefID
                                                               , champion_emp_id);

                    okCnt = UpdateBscKpiInfo_DB(conn
                                              , trx
                                              , estterm_ref_id
                                              , newKpiRefID
                                              , 0);

                    Dac_ctl_ctl2100_Role dacRole = new Dac_ctl_ctl2100_Role();

                    okCnt = dacRole.DelRoleInfo(conn
                                                 , trx
                                                 , champion_emp_id
                                                 , 3);

                    okCnt = dacRole.AddRoleInfo(conn
                                                 , trx
                                                 , champion_emp_id
                                                 , 3);

                    okCnt = InsertBscMboKpiClassification_DB(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , newKpiRefID
                                                           , champion_emp_id
                                                           , champion_emp_id
                                                           , "PRS");

                    DataTable dtBscKpiTerm = addDS.Tables["BSC_KPI_TERM"];

                    for (int i = 0; i < dtBscKpiTerm.Rows.Count; i++)
                    {
                        DataRow dr = dtBscKpiTerm.Rows[i];

                        MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term dacBscKpiTerm = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term();
                        MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target dacBscKpiTarget = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target();

                        okCnt = dacBscKpiTerm.InsertData_DB(conn
                                                       , trx
                                                       , estterm_ref_id
                                                       , newKpiRefID
                                                       , dr["YMD"]
                                                       , dr["CHECK_YN"]
                                                       , "N"
                                                       , "N"
                                                       , create_user);



                        okCnt = dacBscKpiTarget.InsertData_DB(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , newKpiRefID
                                                           , kpi_target_version_id
                                                           , dr["YMD"]
                                                           , dr["MS_PLAN"]
                                                           , dr["TS_PLAN"]
                                                           , create_user);


                    }

                    DataTable dtBscKpiThresholdInfo = addDS.Tables["BSC_KPI_THRESHOLD_INFO"];

                    MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info dacBscKpiThresholdInfo = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info();

                    okCnt = dacBscKpiThresholdInfo.DeleteData_DB(conn
                                                               , trx
                                                               , estterm_ref_id
                                                               , newKpiRefID);

                    for (int i = 0; i < dtBscKpiThresholdInfo.Rows.Count; i++)
                    {
                        DataRow dr = dtBscKpiThresholdInfo.Rows[i];

                        okCnt = dacBscKpiThresholdInfo.InsertData_DB(conn
                                                                   , trx
                                                                   , estterm_ref_id
                                                                   , newKpiRefID
                                                                   , dr["THRESHOLD_REF_ID"]
                                                                   , dr["THRESHOLD_LEVEL"]
                                                                   , dr["SET_MIN_VALUE"]
                                                                   , dr["SET_TXT_VALUE"]
                                                                   , dr["SET_MAX_VALUE"]
                                                                   , dr["ACHIEVE_RATE"]
                                                                   , create_user);
                    }

                    DataTable dtBscKpiInitiative = addDS.Tables["BSC_KPI_INITIATIVE"];

                    for (int i = 0; i < dtBscKpiInitiative.Rows.Count; i++)
                    {
                        DataRow dr = dtBscKpiInitiative.Rows[i];

                        MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative();


                        okCnt = dacBscKpiInitiative.InsertData_DB(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , newKpiRefID
                                                           , dr["YMD"]
                                                           , dr["INITIATIVE_PLAN"]
                                                           , dr["INITIATIVE_DO"]
                                                           , dr["INITIATIVE_DESC"]
                                                           , create_user);

                    }
                }



                if (newKpiRefID > 0)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                newKpiRefID = 0;
                returnMsg = ex.Message;

                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return newKpiRefID;
        }


        /// <summary>
        /// MBO 정의서 등록
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public int ModifyMBO_NW(int estterm_ref_id
                            , int kpi_ref_id
                            , string kpi_code
                            , int kpi_pool_ref_id
                            , string word_definition
                            , string calc_form_ms
                            , int champion_emp_id
                            , string result_achievement_type
                            , string result_ts_calc_type
                            , string result_input_type
                            , string result_measurement_step
                            , string measurement_grade_type
                            , int unit_type_ref_id
                            , string kpi_target_version_id
                            , string kpi_target_setting_reason
                            , string kpi_target_reason_file
                            , string approval_status
                            , string excel_dnuse
                            , string is_team_kpi
                            , int create_user
                            , DataSet addDS
                            , ref string returnMsg)
        {
            int returnKpiRefID = 0;

            DataTable dtKpiRefID = base.SelectDuplicationBscKpiInfo_DB(estterm_ref_id
                                                                    , kpi_ref_id
                                                                    , kpi_code);

            int cnt = DataTypeUtility.GetToInt32(dtKpiRefID.Rows[0][0]);




            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (cnt.Equals(0))
                {

                    Dac_ctl_ctl2100_Role dacRole = new Dac_ctl_ctl2100_Role();

                    int okCnt = dacRole.DelRoleInfo(conn
                                                 , trx
                                                 , champion_emp_id
                                                 , 3);

                    okCnt = dacRole.AddRoleInfo(conn
                                                 , trx
                                                 , champion_emp_id
                                                 , 3);

                    //int okCnt = DeleteComEmpRoleRel_DB(conn
                    //                                 , trx
                    //                                 , champion_emp_id);

                    //okCnt = InsertComEmpRoleRel_DB(conn
                    //                             , trx
                    //                             , champion_emp_id);

                    okCnt = UpdateBscKpiInfo_DB(conn
                                                , trx
                                                , estterm_ref_id
                                                , kpi_ref_id
                                                , kpi_code
                                                , kpi_pool_ref_id
                                                , word_definition
                                                , calc_form_ms
                                                , champion_emp_id
                                                , result_achievement_type
                                                , result_ts_calc_type
                                                , result_input_type
                                                , result_measurement_step
                                                , measurement_grade_type
                                                , unit_type_ref_id
                                                , kpi_target_version_id
                                                , kpi_target_setting_reason
                                                , kpi_target_reason_file
                                                , approval_status
                                                , excel_dnuse
                                                , create_user);

                    DataTable dtBscKpiInfo = SelectBscKpiInfo_DB(estterm_ref_id
                                                               , kpi_ref_id
                                                               , string.Empty);


                    if (dtBscKpiInfo.Rows.Count > 0)
                    {
                        returnKpiRefID = DataTypeUtility.GetToInt32(dtBscKpiInfo.Rows[0]["KPI_REF_ID"]);
                    }

                    if (returnKpiRefID > 0)
                    {
                        DataTable dtBscKpiTerm = addDS.Tables["BSC_KPI_TERM"];

                        MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term dacBscKpiTerm = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term();
                        MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target dacBscKpiTarget = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target();


                        for (int i = 0; i < dtBscKpiTerm.Rows.Count; i++)
                        {
                            DataRow dr = dtBscKpiTerm.Rows[i];

                            okCnt = dacBscKpiTerm.UpdateData_DB(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , returnKpiRefID
                                                           , dr["YMD"]
                                                           , dr["CHECK_YN"]
                                                           , create_user);

                            okCnt = dacBscKpiTarget.UpdateData_DB(conn
                                                           , trx
                                                           , estterm_ref_id
                                                           , returnKpiRefID
                                                           , kpi_target_version_id
                                                           , dr["YMD"]
                                                           , dr["MS_PLAN"]
                                                           , dr["TS_PLAN"]
                                                           , create_user);
                        }


                        DataTable dtBscKpiThresholdInfo = addDS.Tables["BSC_KPI_THRESHOLD_INFO"];

                        MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info dacBscKpiThresholdInfo = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info();
                        okCnt = dacBscKpiThresholdInfo.DeleteData_DB(conn
                                                                       , trx
                                                                       , estterm_ref_id
                                                                       , returnKpiRefID);

                        for (int i = 0; i < dtBscKpiThresholdInfo.Rows.Count; i++)
                        {
                            DataRow dr = dtBscKpiThresholdInfo.Rows[i];

                            okCnt = dacBscKpiThresholdInfo.InsertData_DB(conn
                                                                       , trx
                                                                       , estterm_ref_id
                                                                       , returnKpiRefID
                                                                       , dr["THRESHOLD_REF_ID"]
                                                                       , dr["THRESHOLD_LEVEL"]
                                                                       , dr["SET_MIN_VALUE"]
                                                                       , dr["SET_TXT_VALUE"]
                                                                       , dr["SET_MAX_VALUE"]
                                                                       , dr["ACHIEVE_RATE"]
                                                                       , create_user);
                        }

                        DataTable dtBscKpiInitiative = addDS.Tables["BSC_KPI_INITIATIVE"];

                        for (int i = 0; i < dtBscKpiInitiative.Rows.Count; i++)
                        {
                            DataRow dr = dtBscKpiInitiative.Rows[i];

                            MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative();


                            okCnt = dacBscKpiInitiative.UpdateData_DB(conn
                                                                   , trx
                                                                   , estterm_ref_id
                                                                   , returnKpiRefID
                                                                   , dr["YMD"]
                                                                   , dr["INITIATIVE_PLAN"]
                                                                   , dr["INITIATIVE_DO"]
                                                                   , dr["INITIATIVE_DESC"]
                                                                   , create_user);

                        }

                    }

                }
                if (returnKpiRefID > 0)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch(Exception ex)
            {
                returnKpiRefID = 0;
                returnMsg = ex.Message;

                trx.Rollback();
                
            }
            finally
            {
                conn.Close();
            }

            return returnKpiRefID;
        }


        /// <summary>
        /// 조직KPI에서 복사한 MBO를 삭제
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string RemoveMboToKpi_NW(int estterm_ref_id
                            , object[] objList
                            , int emp_ref_id)
        {
            string returnStr = string.Empty;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                int okCnt = 0;
                foreach (object obj in objList)
                {
                    okCnt = DeleteBscKpiResult_DB(conn
                                                , trx
                                                , estterm_ref_id
                                                , obj);

                    MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info dacBscKpiInfo = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info();
                    okCnt = dacBscKpiInfo.Delete_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , obj);

                    MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Target_Version dacBscKpiTargetVersion = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Target_Version();
                    okCnt = dacBscKpiTargetVersion.DeleteData_DB(conn
                                                                , trx
                                                                , estterm_ref_id
                                                                , obj);
                    

                    MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term dacBscKpiTerm = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term();
                    okCnt = dacBscKpiTerm.DeleteData_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , obj);

                    MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target dacBscKpiTarget = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target();
                    okCnt = dacBscKpiTarget.Delete_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , obj);

                    MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info dacBscKpiThresholdInfo = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info();
                    okCnt = dacBscKpiThresholdInfo.DeleteData_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , obj);


                    MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative();
                    okCnt = dacBscKpiInitiative.DeleteData_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , obj);

                    MicroBSC.BSC.Dac.Dac_Bsc_Mbo_Kpi_Weight dacBscMboKpiWeight = new MicroBSC.BSC.Dac.Dac_Bsc_Mbo_Kpi_Weight();
                    okCnt = dacBscMboKpiWeight.DeleteData_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , obj);


                }
               
                if (returnStr.Equals(string.Empty))
                    trx.Commit();
                else
                {
                    trx.Rollback();
                }
            }
            catch(Exception ex)
            {
                returnStr = ex.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return returnStr;
        }

        #endregion
    }
}
