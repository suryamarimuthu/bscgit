using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.MUL.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.MUL.Biz
{
    public class Biz_Mul_Est_Data
    {
        Dac_Mul_Est_Data _data;

        public Biz_Mul_Est_Data()
        {
            _data = new Dac_Mul_Est_Data();
        }



        /// <summary>
        /// 부서별 미평가/평가완료 현황
        /// </summary>
        public DataTable Get_Est_Status_By_Dept(string EST_ID
                                                , string ESTTERM_REF_ID
                                                , string ESTTERM_SUB_ID)
        {
            DataTable DT = _data.Select_Est_Stat_GroupByDept(EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

            return DT;
        }



        /// <summary>
        /// 직원별 미평가/평가완료 현황
        /// </summary>
        public DataTable Get_Est_Status_By_Emp(string EST_ID
                                                , string ESTTERM_REF_ID
                                                , string ESTTERM_SUB_ID
                                                , string TGT_DEPT_ID)
        {
            DataTable DT = _data.Select_Est_Stat_GroupByEmp(EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, TGT_DEPT_ID);

            return DT;
        }




        /// <summary>
        /// 피평가자 부서, 이름, 평균점수
        /// </summary>
        public DataTable Get_Est_Tgt_Emp_Info(string TGT_DEPT_ID, string TGT_EMP_ID)
        {
            DataTable DT = _data.Select_Est_Emp_Info(TGT_DEPT_ID, TGT_EMP_ID);

            return DT;
        }



        /// <summary>
        /// 피평가자에 대한 평가자 리스트
        /// </summary>
        public DataTable Get_Est_Emp_List(string TGT_DEPT_ID, string TGT_EMP_ID)
        {
            DataTable DT = _data.Select_Est_Emp_List(TGT_DEPT_ID, TGT_EMP_ID);

            return DT;
        }




        /// <summary>
        /// 다면평가 결과를 평균 점수 꼐산 후 STEP_ID를 1로 인서트
        /// </summary>
        /// <returns></returns>
        public int Merge_Est_Data(int admin_dept_ref_id
                                , int admin_emp_ref_id
                                , int comp_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int tgt_dept_id
                                , int tgt_emp_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new MicroBSC.Integration.EST.Dac.Dac_Est_Data();


            int affectedRow = 0;
            int delCnt = 0;

            string est_id = "3O";
            int estterm_step_id = 1;
            string direction_type = "";


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                delCnt = dacEstData.Delete(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , tgt_emp_id
                                            , direction_type);

                affectedRow = _data.Insert_Sum_Point(conn, trx, admin_dept_ref_id, admin_emp_ref_id, comp_id, estterm_ref_id, estterm_sub_id, tgt_dept_id, tgt_emp_id);

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
    }
}