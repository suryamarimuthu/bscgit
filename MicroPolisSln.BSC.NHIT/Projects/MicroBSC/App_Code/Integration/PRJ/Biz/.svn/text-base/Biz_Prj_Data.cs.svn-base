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
    public class Biz_Prj_Data
    {
        Dac_Prj_Data _data;

        public Biz_Prj_Data()
        {
            _data = new Dac_Prj_Data();
        }



        /// <summary>
        /// PMS_INFO에서 프로젝트 투입인원 평가 및 프로젝트 평가 바탕 정보를 추가
        /// </summary>
        public int Add_Prj_Data(IDbConnection conn, IDbTransaction trx
                                , string PRJ_ID
                                , int COMP_ID
                                , string EST_ID
                                , int ESTTERM_REF_ID
                                , int ESTTERM_SUB_ID
                                , int ESTTERM_STEP_ID
                                , int USER_REF_ID)
        {
            MicroBSC.Integration.PMS.Dac.Dac_Pms_Info dacPmsInfo = new MicroBSC.Integration.PMS.Dac.Dac_Pms_Info();
            MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp dacRelDeptEmp = new MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp();
            Dac_Prj_Info dacPrjInfo = new Dac_Prj_Info();

            DataTable PmsInfo = dacPmsInfo.Select_Prj_Detail(conn, trx, PRJ_ID);


            int affectedRow = 0;

            int prj_ref_id = dacPrjInfo.Select_Prj_Ref_Id(conn, trx, PRJ_ID);
            _data.Delete_Prj_Data(conn, trx, prj_ref_id);



            for (int i = 0; i < PmsInfo.Rows.Count; i++)
            {
                string est_dept_id = PmsInfo.Rows[i]["TEAM_BSC_DEPT_ID"].ToString();
                string est_emp_id = PmsInfo.Rows[i]["PM_BSC_EMP_ID"].ToString();


                string tgt_emp_id = PmsInfo.Rows[i]["EMPLOYEE_BSC_EMP_ID"].ToString();
                string tgt_dept_id = dacRelDeptEmp.Select_Dept_ID_of_Emp_ID(conn, trx, tgt_emp_id);


                string STATUS_ID = "N";



                //PM이 피평가자로 설정되어있는 경우는 프로젝트 평가로 입력
                if (tgt_emp_id.Equals(est_emp_id))
                {
                    tgt_dept_id = "-1";
                    tgt_emp_id = "-1";

                    affectedRow += _data.Insert_Prj_Data(conn, trx
                                                        , COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , est_dept_id
                                                        , est_emp_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id
                                                        , prj_ref_id.ToString()
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , STATUS_ID
                                                        , USER_REF_ID);
                }
                else
                {
                    affectedRow += _data.Insert_Prj_Data(conn, trx
                                                        , COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , est_dept_id
                                                        , est_emp_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id
                                                        , prj_ref_id.ToString()
                                                        , DBNull.Value
                                                        , DBNull.Value
                                                        , STATUS_ID
                                                        , USER_REF_ID);
                }
            }


            return affectedRow;
        }



        public DataTable GetPjtInfo_DB(int estterm_ref_id
                                       ,int estterm_sub_id
                                       ,int est_emp_id
                                       ,int tgt_emp_id
                                       ,string status_id)
        {
            MicroBSC.Integration.PRJ.Dac.Dac_Prj_Data dacPrjData = new Dac_Prj_Data();
            return dacPrjData.SelectPrjInfo_DB(estterm_ref_id
                                             , estterm_sub_id
                                             , est_emp_id
                                             , tgt_emp_id
                                             , status_id);
        }



        public DataTable Get_Prj_Data_List(int PRJ_REF_ID
                                        , int COMP_ID
                                        , string EST_ID
                                        , int ESTTERM_REF_ID
                                        , int ESTTERM_SUB_ID
                                        , int ESTTERM_STEP_ID
                                        , int EST_DEPT_ID
                                        , int EST_EMP_ID
                                        , int TGT_DEPT_ID
                                        , int TGT_EMP_ID
                                        , string STATUS_ID)
        {
            DataTable DT = _data.Select_Prj_Data(PRJ_REF_ID, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
                                , EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, STATUS_ID);

            return DT;
        }


        public DataTable Get_Prj_Data_List(int PRJ_REF_ID
                                        , int COMP_ID
                                        , string EST_ID
                                        , int ESTTERM_REF_ID
                                        , int ESTTERM_SUB_ID
                                        , int ESTTERM_STEP_ID)
        {
            DataTable DT = Get_Prj_Data_List(PRJ_REF_ID, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
                                , 0, 0, 0, 0, "");

            return DT;
        }



        public bool Modify_Prj_Data_Point(int PRJ_REF_ID
                                        , int TGT_DEPT_ID
                                        , int TGT_EMP_ID
                                        , double POINT
                                        , int LOGIN_USER_REF_ID)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

            try
            {
                affectedRow += _data.Update_Prj_Data_Point(conn, trx, PRJ_REF_ID, TGT_DEPT_ID, TGT_EMP_ID, POINT, LOGIN_USER_REF_ID);
                affectedRow += _data.Update_Prj_Data_StatusID(conn, trx, PRJ_REF_ID, TGT_DEPT_ID, TGT_EMP_ID, "P", LOGIN_USER_REF_ID);

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



        public bool Modify_Prj_Data_Est_Status(int PRJ_REF_ID
                                        , int TGT_DEPT_ID
                                        , int TGT_EMP_ID
                                        , string EST_STATUS
                                        , int LOGIN_USER_REF_ID)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

            try
            {
                affectedRow += _data.Update_Prj_Data_StatusID(conn, trx, PRJ_REF_ID, TGT_DEPT_ID, TGT_EMP_ID, EST_STATUS, LOGIN_USER_REF_ID);

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





        public DataTable Get_Sum_Work_Time(IDbConnection conn, IDbTransaction trx
                                            , int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , DataTable dt_prj_ref_id
                                            , DataTable dt_emp_ref_id)
        {
            string prj_ref_id_list = "";
            for (int i = 0; i < dt_prj_ref_id.Rows.Count; i++)
            {
                if (prj_ref_id_list.Length > 0)
                    prj_ref_id_list += " , ";
                prj_ref_id_list += dt_prj_ref_id.Rows[i]["PRJ_REF_ID"].ToString();
            }
            if (prj_ref_id_list.Length == 0)
                prj_ref_id_list = "''";


            string emp_ref_id_list = "";
            for (int i = 0; i < dt_emp_ref_id.Rows.Count; i++)
            {
                if (emp_ref_id_list.Length > 0)
                    emp_ref_id_list += " , ";
                emp_ref_id_list += dt_emp_ref_id.Rows[i]["EMP_REF_ID"].ToString();
            }
            if (emp_ref_id_list.Length == 0)
                emp_ref_id_list = "''";


            DataTable dt = _data.Select_Sum_Work_Time(conn, trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , prj_ref_id_list
                                                    , emp_ref_id_list);

            return dt;
        }




        public DataTable Get_Sum_Suspend_Time(IDbConnection conn, IDbTransaction trx
                                            , DataTable dt_emp_ref_id
                                            , string start_yearmonth
                                            , string end_yearmonth)
        {
            string emp_ref_id_list = "";
            for (int i = 0; i < dt_emp_ref_id.Rows.Count; i++)
            {
                if (emp_ref_id_list.Length > 0)
                    emp_ref_id_list += " , ";
                emp_ref_id_list += dt_emp_ref_id.Rows[i]["EMP_REF_ID"].ToString();
            }
            if (emp_ref_id_list.Length == 0)
                emp_ref_id_list = "''";


            DataTable dt = _data.Select_Sum_Suspend_Time(conn, trx
                                                    , start_yearmonth
                                                    , end_yearmonth
                                                    , emp_ref_id_list);

            return dt;
        }



        public DataTable Get_Sum_Work_Suspend_Time(IDbConnection conn, IDbTransaction trx
                                                , int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id
                                                , DataTable dt_prj_ref_id
                                                , DataTable dt_emp_ref_id)
        {
            MicroBSC.Integration.EST.Biz.Biz_Est_Term_Info bizEstTermInfo = new MicroBSC.Integration.EST.Biz.Biz_Est_Term_Info();
            DataTable dtYearMonth = bizEstTermInfo.Get_Start_End_YearMonth(comp_id, estterm_ref_id, estterm_sub_id);
            string start_YearMonth = "";
            string end_YearMonth = "";

            DataTable result = new DataTable();

            if (dtYearMonth.Rows.Count == 1)
            {
                start_YearMonth = dtYearMonth.Rows[0]["START_YEARMONTH"].ToString();
                end_YearMonth = dtYearMonth.Rows[0]["END_YEARMONTH"].ToString();

                //직원의 근무시간 합계
                DataTable dtSum_Worktime = Get_Sum_Work_Time(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , dt_prj_ref_id
                                                            , dt_emp_ref_id);
                
                //직원의 대기시간 합계
                DataTable dtSum_Suspendtime = Get_Sum_Suspend_Time(conn, trx
                                                                , dt_emp_ref_id
                                                                , start_YearMonth
                                                                , end_YearMonth);

                for (int i = 0; i < dtSum_Suspendtime.Rows.Count; i++)
                {
                    dtSum_Worktime.ImportRow(dtSum_Suspendtime.Rows[i]);
                }

                result = dtSum_Worktime;
            }

            return result;
        }





        public double Get_Avg_Prj_Point(IDbConnection conn, IDbTransaction trx
                                        , int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , DataTable dt_prj_ref_id)
        {
            string prj_ref_id_list = "";
            for (int i = 0; i < dt_prj_ref_id.Rows.Count; i++)
            {
                if (prj_ref_id_list.Length > 0)
                    prj_ref_id_list += " , ";
                prj_ref_id_list += dt_prj_ref_id.Rows[i]["PRJ_REF_ID"].ToString();
            }
            if (prj_ref_id_list.Length == 0)
                prj_ref_id_list = "''";

            double Result = _data.Select_Avg_Prj_Point(conn, trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , prj_ref_id_list);

            return Result;
        }




        public double Get_Avg_Prj_Emp_Point(IDbConnection conn, IDbTransaction trx
                                            , int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , DataTable dt_emp_ref_id)
        {
            string emp_ref_id_list = "";
            for (int i = 0; i < dt_emp_ref_id.Rows.Count; i++)
            {
                if (emp_ref_id_list.Length > 0)
                    emp_ref_id_list += " , ";
                emp_ref_id_list += dt_emp_ref_id.Rows[i]["EMP_REF_ID"].ToString();
            }
            if (emp_ref_id_list.Length == 0)
                emp_ref_id_list = "''";

            double Result = _data.Select_Avg_Prj_Emp_Point(conn, trx
                                                        , comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , estterm_step_id
                                                        , emp_ref_id_list);

            return Result;
        }




        /// <summary>
        /// 해당기간의 평가 종료된 프로젝트 목록
        /// </summary>
        public DataTable Get_Ended_Prj_Est(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id)
        {
            DataTable dt = _data.Select_Prj_Gubun(null, null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , "E");

            return dt;
        }



        public DataTable Get_TgtEmp_Prj_Gubun(IDbConnection conn, IDbTransaction trx
            , int comp_id
            , string est_id
            , int estterm_ref_id
            , int estterm_sub_id
            , int estterm_step_id
            , int tgt_dept_id
            , int tgt_emp_id
            , string prj_ref_id_list)
        {
            DataTable dt = _data.Select_TgtEmp_Prj_Gubun(conn, trx
                                                        , comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , estterm_step_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id
                                                        , prj_ref_id_list);

            return dt;
        }
    }
}