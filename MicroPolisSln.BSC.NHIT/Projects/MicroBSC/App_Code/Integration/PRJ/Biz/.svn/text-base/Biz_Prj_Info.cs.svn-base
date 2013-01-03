using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.PRJ.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.PRJ.Biz
{
    public class Biz_Prj_Info
    {
        Dac_Prj_Info _data;



        public Biz_Prj_Info()
        {
            _data = new Dac_Prj_Info();
        }



        /// <summary>
        /// PMS_INFO에서 PRJ_INFO로 프로젝트 정보를 추가
        /// </summary>
        public int Add_Prj_Info(IDbConnection conn, IDbTransaction trx, string PRJ_ID, int USER_REF_ID)
        { 
            MicroBSC.Integration.PMS.Dac.Dac_Pms_Info dacPmsInfo = new MicroBSC.Integration.PMS.Dac.Dac_Pms_Info();
            MicroBSC.Integration.COM.Dac.Dac_Com_Dept_Info dacDeptInfo = new MicroBSC.Integration.COM.Dac.Dac_Com_Dept_Info();

            DataTable PmsInfo = dacPmsInfo.Select_Prj_List(conn, trx, PRJ_ID);

            int affectedRow = 0;

            if (PmsInfo.Rows.Count > 0)
            {
                _data.Delete_Prj_Info(conn, trx, PRJ_ID);

                string PRJ_CODE = PRJ_ID;
                string PRJ_NAME = PmsInfo.Rows[0]["PROJECTNAME"].ToString();
                string DEFINITION = PRJ_NAME;
                string OWNER_DEPT_ID = DataTypeUtility.GetToInt32(PmsInfo.Rows[0]["TEAM_BSC_DEPT_ID"]).ToString();
                string OWNER_EMP_ID = PmsInfo.Rows[0]["PM_BSC_EMP_ID"].ToString();
                //string PLAN_START_DATE = PmsInfo.Rows[0]["PLN_STR_DATE"].ToString();
                //string PLAN_END_DATE = PmsInfo.Rows[0]["PLN_END_DATE"].ToString();
                
                
                string ACTUAL_START_DATE = Convert.ToDateTime(PmsInfo.Rows[0]["PROJECTSTARTDATE"].ToString()).ToString("yyyy-MM-dd");
                string ACTUAL_END_DATE = Convert.ToDateTime(PmsInfo.Rows[0]["PROJECTENDDATE"].ToString()).ToString("yyyy-MM-dd");


                affectedRow = _data.Insert_Prj_Info(conn, trx
                                        , PRJ_CODE
                                        , PRJ_NAME
                                        , DBNull.Value
                                        , DEFINITION
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , OWNER_DEPT_ID
                                        , OWNER_EMP_ID.Length==0? DBNull.Value : (object)OWNER_EMP_ID
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value//PLAN_START_DATE
                                        , DBNull.Value//PLAN_END_DATE
                                        , ACTUAL_START_DATE
                                        , ACTUAL_END_DATE
                                        , USER_REF_ID);
            }

            return affectedRow;
        }



        public DataTable Get_Pms_Info_Join_PRj_Info_List(string sDate, string eDate, string PRJ_NAME, int est_emp_id, string gubun)
        {
            Dac_Prj_Info.EST_GUBUN GUBUN = new Dac_Prj_Info.EST_GUBUN();

            if (gubun.Equals("TOTAL"))
                GUBUN = Dac_Prj_Info.EST_GUBUN.TOTAL;
            else if (gubun.Equals("INCLUDE"))
                GUBUN = Dac_Prj_Info.EST_GUBUN.INCLUDED_PRJ_INFO;
            else
                GUBUN = Dac_Prj_Info.EST_GUBUN.EXCLUDED_PRJ_INFO;

            DataTable DT = _data.Select_Pms_Info_Join_Prj_Info(sDate, eDate, PRJ_NAME, est_emp_id, GUBUN    );

            return DT;
        }


        public DataTable Get_Pms_Info_Join_PRj_Info_List(string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, string PRJ_NAME, int est_emp_id, string gubun)
        {
            Dac_Prj_Info.EST_GUBUN GUBUN = new Dac_Prj_Info.EST_GUBUN();

            if (gubun.Equals("TOTAL"))
                GUBUN = Dac_Prj_Info.EST_GUBUN.TOTAL;
            else if (gubun.Equals("INCLUDE"))
                GUBUN = Dac_Prj_Info.EST_GUBUN.INCLUDED_PRJ_INFO;
            else
                GUBUN = Dac_Prj_Info.EST_GUBUN.EXCLUDED_PRJ_INFO;

            DataTable DT = _data.Select_Pms_Info_Join_Prj_Info(est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, PRJ_NAME, est_emp_id, GUBUN);

            return DT;
        }



        public bool Set_Est_Target(DataTable PRJ_IDs
                                    , int COMP_ID
                                    , string EST_ID
                                    , int ESTTERM_REF_ID
                                    , int ESTTERM_SUB_ID
                                    , int ESTTERM_STEP_ID
                                    , int USER_REF_ID)
        {
            Biz_Prj_Data bizPrjData = new Biz_Prj_Data();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

            try
            {
                for (int i = 0; i < PRJ_IDs.Rows.Count; i++)
                { 
                    string prj_id = PRJ_IDs.Rows[i]["PRJ_ID"].ToString();

                    affectedRow += Add_Prj_Info(conn, trx, prj_id, USER_REF_ID);

                    affectedRow += bizPrjData.Add_Prj_Data(conn, trx
                                                            , prj_id
                                                            , COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , USER_REF_ID);
                }


                trx.Commit();
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

            return affectedRow > 0 ? true : false;

        }



        public int UnSet_Est_Target(DataTable PRJ_IDs)
        {
            Dac_Prj_Data dacPrjData = new Dac_Prj_Data();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 1;
            string prj_ref_id_list = "";

            try
            {
                for (int i = 0; i < PRJ_IDs.Rows.Count; i++)
                {
                    string PRJ_ID = PRJ_IDs.Rows[i]["PRJ_ID"].ToString();
                    int PRJ_REF_ID = _data.Select_Prj_Ref_Id(conn, trx, PRJ_ID);

                    if (prj_ref_id_list.Length > 0)
                        prj_ref_id_list += ", ";
                    prj_ref_id_list += PRJ_REF_ID;

                    _data.Delete_Prj_Info(conn, trx, PRJ_ID);

                    dacPrjData.Delete_Prj_Data(conn, trx, PRJ_REF_ID);
                }

                //프로젝트 평가 질의 매핑 삭제
                Biz_Prj_Question_Prj_Map bizPrjQuestionPrjMap = new Biz_Prj_Question_Prj_Map();
                bizPrjQuestionPrjMap.Remove_Question_Prj_Map_Data(conn, trx, 0, "", 0, 0, 0, prj_ref_id_list);


                trx.Commit();
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

            return affectedRow;
        }



        /// <summary>
        /// 프로젝트 평가 질의에 매핑되지 않은 프로젝트 목록
        /// </summary>
        public DataTable Get_Prj_Info_Not_In_Question_Map(int comp_id
                                                        , string est_id
                                                        , int estterm_ref_id
                                                        , int estterm_sub_id
                                                        , int estterm_step_id)
        {
            DataTable dt = _data.Select_Prj_Info_Join_Question_Map(comp_id
                                                                    , est_id
                                                                    , estterm_ref_id
                                                                    , estterm_sub_id
                                                                    , estterm_step_id
                                                                    , 0
                                                                    , "");

            return DataTypeUtility.FilterSortDataTable(dt, "MAP_PRJ_REF_ID IS NULL");
        }
    }
}