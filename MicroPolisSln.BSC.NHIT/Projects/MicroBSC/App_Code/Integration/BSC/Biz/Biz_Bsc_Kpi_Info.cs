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

using MicroBSC.Integration.COM.Dac;
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Data;

/// <summary>
/// Biz_Bsc_Kpi_Term의 요약 설명입니다.
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
/// </summary>
/// 
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Info
    {
        #region Past Code
        Dac_Bsc_Kpi_Info _data;

        public Biz_Bsc_Kpi_Info()
        {
            _data = new Dac_Bsc_Kpi_Info();
        }

        public DataTable Get_GoalTongDashboard(int estterm_ref_id
                                             , int est_dept_ref_id)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info dacBscKpiInfo = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info();
            return dacBscKpiInfo.Select_GoalTongDashboard(estterm_ref_id
                                                         , est_dept_ref_id);
        }

        /// <summary>
        /// 조직KPI에서 복사한 MBO를 삭제
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string RemoveMboToKpi_DB(int estterm_ref_id
                                    , string[] objList)
        {
            string rtnValue = string.Empty;

            int okCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info dacBscKpiInfo = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target_Version dacBscKpiTargetVersion = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target_Version();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dacBscKpiResult = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Term dacBscKpiTerm = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Term();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target dacBscKpiTarget = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Target();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info dacBscKpiThresholdInfo = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Threshold_Info();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Initiative();
                MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Classification dacBscKpiClassification = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Classification();


                foreach (string obj in objList)
                {
                    okCnt = dacBscKpiInfo.Delete_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiTargetVersion.Delete_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiResult.DeleteData_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiTerm.Delete_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiTarget.Delete_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiThresholdInfo.Delete_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiInitiative.DeleteData_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                    okCnt = dacBscKpiClassification.Delete_DB(conn
                                            , trx
                                            , estterm_ref_id
                                            , obj);

                }

                trx.Commit();

            }
            catch (Exception ex)
            {
                rtnValue = ex.Message;
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }

            return rtnValue;
        }





        public bool CopyKpiToMbo(int estterm_ref_id
                                , object[] objList
                                , int emp_ref_id
                                , string estYear
                                , string class_type)
        {
            Dac_Bsc_Mbo_Kpi_Classification dacBscMboKpiClassification = new Dac_Bsc_Mbo_Kpi_Classification();
            Dac_Bsc_Kpi_Target_Version dacBscKpiTargetVersion = new Dac_Bsc_Kpi_Target_Version();
            Dac_Bsc_Kpi_Result dacBscKpiResult = new Dac_Bsc_Kpi_Result();
            Dac_Com_Emp_Role_Rel dacEmpRoleRel = new Dac_Com_Emp_Role_Rel();
            Dac_Bsc_Kpi_Term dacBscKpiTerm = new Dac_Bsc_Kpi_Term();
            Dac_Bsc_Kpi_Target dacBscKpiTarget = new Dac_Bsc_Kpi_Target();
            Dac_Bsc_Kpi_Threshold_Info dacBscKpiThresholdInfo = new Dac_Bsc_Kpi_Threshold_Info();
            Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new Dac_Bsc_Kpi_Initiative();

            int rtn_kpi_ref_id = 0;
            int affectedRow;
            bool Result;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();


            try
            {
                for (int i = 0; i < objList.Length; i++)
                {
                    DataTable dt = dacBscMboKpiClassification.Select_DB(conn, trx, estterm_ref_id, emp_ref_id, 0, objList[i], "");
                    if (dt.Rows.Count > 0 && DataTypeUtility.GetToInt32(dt.Rows[0]["ESTTERM_REF_ID"]) > 0)
                        return false;

                }


                for (int i = 0; i < objList.Length; i++)
                {



                    #region 기존 코드에서 strQuery1
                    //KPI INFO COPY
                    _data.Insert_DB_From_Bsc_Kpi_Info(conn, trx
                                                    , estterm_ref_id
                                                    , 0
                                                    , "MicroPolis_0"
                                                    , emp_ref_id
                                                    , DataTypeUtility.GetToInt32(objList[i]));

                    //MAX KPI_REF_ID
                    //rtn_kpi_ref_id = _data.Select_Max_Kpi_Ref_Id(conn, trx);

                    MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Info dac = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Info();
                    rtn_kpi_ref_id = dac.SelectMaxBscKpiInfo_DB(conn, trx);


                    //KPI TARGET VERSION INSERT
                    dacBscKpiTargetVersion.Delete_DB(conn, trx, estterm_ref_id, rtn_kpi_ref_id);
                    dacBscKpiTargetVersion.Insert_DB(conn, trx
                                                    , estterm_ref_id
                                                    , rtn_kpi_ref_id
                                                    , 1
                                                    , "당초계획"
                                                    , "당초계획(자동생성)"
                                                    , 1
                                                    , 12
                                                    , "Y"
                                                    , emp_ref_id);

                    //KPI RESULT INSERT    
                    dacBscKpiResult.DeleteData_DB(conn, trx, estterm_ref_id, rtn_kpi_ref_id);
                    dacBscKpiResult.Insert_DB_From_Estterm_Detail(conn, trx
                                                                , estterm_ref_id
                                                                , rtn_kpi_ref_id
                                                                , emp_ref_id);
                    _data.Update_Bsc_Kpi_Info(conn, trx
                                                , 0
                                                , estterm_ref_id
                                                , rtn_kpi_ref_id);

                    //Champion Role Insert
                    dacEmpRoleRel.Delete_DB(conn, trx, emp_ref_id, 3);
                    dacEmpRoleRel.Insert_DB(conn, trx, emp_ref_id, 3);


                    //지표구분테이블에 일상업무정보 추가 BSC_MBO_KPI_CLASSIFICATION
                    dacBscMboKpiClassification.Insert_DB(conn, trx
                                                        , estterm_ref_id
                                                        , emp_ref_id
                                                        , rtn_kpi_ref_id
                                                        , DataTypeUtility.GetToInt32(objList[i])
                                                        , class_type
                                                        , emp_ref_id);
                    #endregion




                    if (rtn_kpi_ref_id > 0)
                    {


                        #region 기존코드에서 strQuery2
                        affectedRow = dacBscKpiTerm.Insert_DB_From_Bsc_Kpi_Term(conn, trx
                                                                            , estterm_ref_id
                                                                            , rtn_kpi_ref_id
                                                                            , DataTypeUtility.GetToInt32(objList[i])
                                                                            , emp_ref_id);

                        if (affectedRow != 12)
                            return false;
                        #endregion




                        if (class_type.ToString().Equals("PRS"))
                        {
                            //기존코드에서 strQuery6
                            dacBscKpiTarget.InsertData_DB_From_BSC_KPI_TARGET(conn, trx
                                                                            , estterm_ref_id
                                                                            , DataTypeUtility.GetToInt32(objList[i])
                                                                            , rtn_kpi_ref_id
                                                                            , emp_ref_id);
                        }
                        else
                        {
                            for (int j = 0; j < 13; j++)
                            {
                                Result = dacBscKpiTarget.Proc_Update(conn, trx
                                                                    , "A"
                                                                    , estterm_ref_id
                                                                    , rtn_kpi_ref_id
                                                                    , 1
                                                                    , estYear.ToString() + j.ToString().PadLeft(2, '0')
                                                                    , 0
                                                                    , 0
                                                                    , emp_ref_id);

                                if (!Result)
                                    return false;

                            }
                        }


                        ////////////////////////////////////////////////////
                        // KPI THRESHOLD 
                        ////////////////////////////////////////////////////

                        //기존코드에서 strQuery3
                        dacBscKpiThresholdInfo.Delete_DB(conn, trx
                                                        , estterm_ref_id
                                                        , rtn_kpi_ref_id);

                        //기존코드에서 strQuery4
                        dacBscKpiThresholdInfo.Insert_DB_From_Bsc_Kpi_Threshold_Info(conn, trx
                                                                                    , class_type
                                                                                    , estterm_ref_id
                                                                                    , rtn_kpi_ref_id
                                                                                    , DataTypeUtility.GetToInt32(objList[i])
                                                                                    , emp_ref_id);




                        #region 기존코드에서 strQuery5
                        if (class_type.ToString().Equals("PRS"))
                        {
                            dacBscKpiInitiative.InsertData_DB_From_Bsc_Kpi_Initiative(conn, trx
                                                                                    , estterm_ref_id
                                                                                    , DataTypeUtility.GetToInt32(objList[i])
                                                                                    , rtn_kpi_ref_id
                                                                                    , emp_ref_id);
                        }
                        else
                        {
                            affectedRow = 0;

                            for (int j = 1; j < 13; j++)
                            {
                                dacBscKpiInitiative.InsertData_DB(conn, trx
                                                                , estterm_ref_id
                                                                , rtn_kpi_ref_id
                                                                , estYear.ToString() + j.ToString().PadLeft(2, '0')
                                                                , DBNull.Value
                                                                , DBNull.Value
                                                                , DBNull.Value
                                                                , DBNull.Value
                                                                , emp_ref_id);
                            }
                        }
                        #endregion



                    }
                    else
                    {
                        return false;
                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                rtn_kpi_ref_id = 0;
            }
            finally
            {
                conn.Close();
            }


            return rtn_kpi_ref_id > 0 ? true : false;
        }




        // 탬플릿을 이용한 kpi 복사
        public string CopyKpiToMboUsingTemplete(int estterm_ref_id
                                            , object[] objKpiPoolList
                                            , string templete_id
                                            , string templete_name
                                            , int emp_ref_id
                                            , string nowDate
                                            , string result_measurement_step
                                            , int unit_type_ref_id
                                            , string class_type
                                            , DataTable dtBscThresholdStep)
        {
            string reVal = string.Empty;

            MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Info dac = new MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Info();

            Dac_Bsc_Mbo_Kpi_Classification dacBscMboKpiClassification = new Dac_Bsc_Mbo_Kpi_Classification();
            Dac_Bsc_Kpi_Target_Version dacBscKpiTargetVersion = new Dac_Bsc_Kpi_Target_Version();
            Dac_Bsc_Kpi_Result dacBscKpiResult = new Dac_Bsc_Kpi_Result();
            Dac_Com_Emp_Role_Rel dacEmpRoleRel = new Dac_Com_Emp_Role_Rel();
            Dac_Bsc_Kpi_Term dacBscKpiTerm = new Dac_Bsc_Kpi_Term();
            Dac_Bsc_Kpi_Target dacBscKpiTarget = new Dac_Bsc_Kpi_Target();
            Dac_Bsc_Kpi_Threshold_Info dacBscKpiThresholdInfo = new Dac_Bsc_Kpi_Threshold_Info();
            Dac_Bsc_Kpi_Initiative dacBscKpiInitiative = new Dac_Bsc_Kpi_Initiative();

            int rtn_kpi_ref_id = 0;
            int affectedRow = 0;
            bool Result;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();


            try
            {
                //for (int i = 0; i < objList.Length; i++)
                //{
                //    DataTable dt = dacBscMboKpiClassification.Select_DB(conn, trx, estterm_ref_id, emp_ref_id, 0, objList[i], "");
                //    if (dt.Rows.Count > 0 && DataTypeUtility.GetToInt32(dt.Rows[0]["ESTTERM_REF_ID"]) > 0)
                //        return false;

                //}

                MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new Biz_Bsc_Kpi_Result();

                for (int i = 0; i < objKpiPoolList.Length; i++)
                {

                    rtn_kpi_ref_id = dac.SelectMaxBscKpiInfo_DB(conn, trx);

                    object kpi_pool_ref_id = objKpiPoolList[i];

                    #region 기존 코드에서 strQuery1
                    //KPI INFO COPY
                    int okCnt = _data.InsertData_DB(conn
                                                    , trx
                                                    , estterm_ref_id
                                                    , rtn_kpi_ref_id
                                                    , rtn_kpi_ref_id
                                                    , kpi_pool_ref_id
                                                    , string.Format("{0}_{1}", templete_id, templete_name)
                                                    , ""
                                                    , emp_ref_id
                                                    , "MAN"
                                                    , "ATY"
                                                    , "ETC"
                                                    , result_measurement_step
                                                    , "RATE"
                                                    , unit_type_ref_id
                                                    , 1
                                                    , ""
                                                    , ""
                                                    , "N"
                                                    , "N"
                                                    , "N"
                                                    , "Y"
                                                    , nowDate
                                                    , emp_ref_id);

                    //MAX KPI_REF_ID
                    //rtn_kpi_ref_id = _data.Select_Max_Kpi_Ref_Id(conn, trx);




                    //KPI TARGET VERSION INSERT
                    dacBscKpiTargetVersion.Insert_DB(conn, trx
                                                    , estterm_ref_id
                                                    , rtn_kpi_ref_id
                                                    , 1
                                                    , "당초계획"
                                                    , "당초계획(자동생성)"
                                                    , 1
                                                    , 12
                                                    , "Y"
                                                    , emp_ref_id);

                    //Champion Role Insert
                    dacEmpRoleRel.Delete_DB(conn, trx, emp_ref_id, 3);
                    dacEmpRoleRel.Insert_DB(conn, trx, emp_ref_id, 3);


                    //지표구분테이블에 일상업무정보 추가 BSC_MBO_KPI_CLASSIFICATION
                    dacBscMboKpiClassification.Insert_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , emp_ref_id
                                                        , rtn_kpi_ref_id
                                                        , rtn_kpi_ref_id
                                                        , class_type
                                                        , emp_ref_id);
                    #endregion



                    affectedRow = 0;
                    if (rtn_kpi_ref_id > 0)
                    {

                        string year = DateTime.Now.Year.ToString();

                        #region 기존코드에서 strQuery2
                        for (int k = 1; k < 13; k++)
                        {

                            string month = k.ToString().PadLeft(2, '0');
                            string ymd = year + month;

                            //KPI RESULT INSERT    
                            affectedRow += bizBscKpiResult.InsertData_DB(conn
                                                        , trx
                                                        , estterm_ref_id
                                                        , rtn_kpi_ref_id
                                                        , ymd
                                                        , 0
                                                        , 0
                                                        , ymd
                                                        , 0
                                                        , 0
                                                        , "N"
                                                        , ""
                                                        , ""
                                                        , ""
                                                        , ""
                                                        , ""
                                                        , ""
                                                        , ""
                                                        , ""
                                                        , nowDate
                                                        , emp_ref_id);

                            dacBscKpiTerm.Insert_DB(conn
                                                                 , trx
                                                                 , estterm_ref_id
                                                                 , rtn_kpi_ref_id
                                                                 , ymd
                                                                 , "N"
                                                                 , "N"
                                                                 , "N"
                                                                 , emp_ref_id);

                            dacBscKpiTarget.InsertData_DB(conn
                                                         , trx
                                                         , estterm_ref_id
                                                         , rtn_kpi_ref_id
                                                         , 1
                                                         , ymd
                                                         , 0
                                                         , 0
                                                         , emp_ref_id);

                            dacBscKpiInitiative.InsertData_DB(conn
                                                            , trx
                                                            , estterm_ref_id
                                                            , rtn_kpi_ref_id
                                                            , ymd
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , DBNull.Value
                                                            , emp_ref_id);
                        }


                        if (affectedRow != 12)
                            return "false";
                        #endregion



                        ////////////////////////////////////////////////////
                        // KPI THRESHOLD 
                        ////////////////////////////////////////////////////

                        for (int k = 0; k < dtBscThresholdStep.Rows.Count; k++)
                        {
                            string threshold_ref_id = DataTypeUtility.GetValue(dtBscThresholdStep.Rows[k]["THRESHOLD_REF_ID"]);
                            dacBscKpiThresholdInfo.InsertData_DB(conn
                                                               , trx
                                                               , estterm_ref_id
                                                               , rtn_kpi_ref_id
                                                               , threshold_ref_id
                                                               , result_measurement_step
                                                               , 0
                                                               , 0
                                                               , 0
                                                               , 0
                                                               , nowDate
                                                               , emp_ref_id);
                        }


                    }

                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                reVal = ex.Message;
                trx.Rollback();
                rtn_kpi_ref_id = 0;
            }
            finally
            {
                conn.Close();
            }


            return reVal;
        }

        public int KpiWeightUpdate(double WEIGHT, int ESTTERM_REF_ID, int EST_DEPT_REF_ID, int MAP_VERSION_ID,
            int STG_REF_ID, int KPI_REF_ID)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info().KpiWeightUpdate(WEIGHT, ESTTERM_REF_ID, EST_DEPT_REF_ID, MAP_VERSION_ID,
            STG_REF_ID, KPI_REF_ID);
        } 

        public int KpiWeightUpdate(int WEIGHT, int ESTTERM_REF_ID, int EST_DEPT_REF_ID, int MAP_VERSION_ID,
            int STG_REF_ID, int KPI_REF_ID)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info().KpiWeightUpdate(WEIGHT, ESTTERM_REF_ID, EST_DEPT_REF_ID, MAP_VERSION_ID,
            STG_REF_ID, KPI_REF_ID);
        } 
        #endregion

        public int KpiAutoInsert(int ESTTERM_REF_ID, int VIEW_REF_ID, int STG_REF_ID, int KPI_POOL_REF_ID, int EST_DEPT_REF_ID, int TXR_USER)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info().KpiAutoInsert(ESTTERM_REF_ID, VIEW_REF_ID, STG_REF_ID, KPI_POOL_REF_ID, EST_DEPT_REF_ID, TXR_USER);
        }

        public int KpiInfoExsistCheck(int KPI_POOL_REF_ID, int CHAMPION_EMP_ID, int ESTTERM_REF_ID)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info().KpiInfoExsistCheck(KPI_POOL_REF_ID, CHAMPION_EMP_ID, ESTTERM_REF_ID);
        }

        public int KpiInfoExsistCheckPerson(int KPI_POOL_REF_ID, int CHAMPION_EMP_ID, int ESTTERM_REF_ID)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info().KpiInfoExsistCheckPerson(KPI_POOL_REF_ID, CHAMPION_EMP_ID, ESTTERM_REF_ID);
        }
        public int KpiInfoChampionChange(int kpi_ref_id, int champion_emp_id, int estterm_ref_id)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Info().KpiInfoChampionChange(kpi_ref_id, champion_emp_id, estterm_ref_id);
        }

    }
}
