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
    public class Biz_Mul_Est_Target_Pool
    {
        private Dac_Mul_Est_Target_Pool _data = new Dac_Mul_Est_Target_Pool();

        public Biz_Mul_Est_Target_Pool()
        {

        }

        
        
        public DataTable Get_MulEmpCnt_Join_MulPoolEmpCnt(int comp_id
                                                        , string est_id
                                                        , int estterm_ref_id
                                                        , int estterm_sub_id)
        {
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            DataTable DT = _data.Select_MulEmpCnt_Join_MulPoolEmpCnt(comp_id, est_id, estterm_ref_id, estterm_sub_id);

            return DT;
        }




        public DataTable Get_MulTgtEmp_List(int comp_id
                                        , int dept_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id)
        {
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            DataTable DT = _data.Select_MulPoolTgtEmp_List(comp_id, dept_id, est_id, estterm_ref_id, estterm_sub_id);

            return DT;
        }





        public DataTable Get_MulEstEmp_List(int comp_id
                                        , int tgt_emp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id)
        {
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            DataTable DT = _data.Select_MulPoolEstEmp_List(comp_id, tgt_emp_id, est_id, estterm_ref_id, estterm_sub_id);

            return DT;
        }

        public DataTable GetMulEstTargetPool_DB(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int tgt_emp_id
                                        , string select_yn)
        {
            MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp dacMulEstEmp = new MicroBSC.Integration.MUL.Dac.Dac_Mul_Est_Emp();

            DataTable DT = _data.Select_BaseEstEmptable(comp_id
                                                      , est_id
                                                      , estterm_ref_id
                                                      , estterm_sub_id
                                                      , tgt_emp_id
                                                      , select_yn);

            return DT;
        }


        public int Add_Tgt_Emp_Pool(DataTable DT_dept_id
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int create_user_ref_id)
        {
            MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp dacRelDeptEmp = new MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp();
            Dac_Mul_Est_Emp dacEstEmp = new Dac_Mul_Est_Emp();


            
            DataTable DT_est_emp_id = dacEstEmp.SelectEstEmp_DB(comp_id, est_id, estterm_ref_id, estterm_sub_id, 0, "EST");


            int affectedRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();


            try
            {
                //부서 갯수만큼 루프
                for (int i = 0; i < DT_dept_id.Rows.Count; i++)
                {
                    string dept_ref_id = DT_dept_id.Rows[i]["DEPT_ID"].ToString();

                    DataTable DT_tgt_emp_id = dacEstEmp.SelectRelDeptEmp(0
                                                                        , comp_id
                                                                        , dept_ref_id
                                                                        , est_id
                                                                        , estterm_ref_id
                                                                        , estterm_sub_id
                                                                        , "TGT").Tables[0];
                    //해당 부서의 직원 수만큼 루프
                    for (int j = 0; j < DT_tgt_emp_id.Rows.Count; j++)
                    {
                        string tgt_emp_id = DT_tgt_emp_id.Rows[j]["EMP_REF_ID"].ToString();


                        //셀렉트한 결과 모두 인서트
                        
                        //전체 평가자
                        //affectedRow += _data.Insert_Pool_Data(conn, trx
                        //                                    , comp_id
                        //                                    , est_id
                        //                                    , estterm_ref_id
                        //                                    , estterm_sub_id
                        //                                    , tgt_emp_id
                        //                                    , create_user_ref_id);

                        //피평가자의 부서에 해당하는 평가자
                        affectedRow += _data.Insert_Pool_Data_Dept(conn, trx
                                                                , comp_id
                                                                , est_id
                                                                , estterm_ref_id
                                                                , estterm_sub_id
                                                                , dept_ref_id
                                                                , tgt_emp_id
                                                                , create_user_ref_id);
                    }

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

            return affectedRow;
        }


        public int Remove_Tgt_Emp_Pool(DataTable DT_dept_id
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id)
        {
            MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp dacRelDeptEmp = new MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp();
            Dac_Mul_Est_Emp dacEstEmp = new Dac_Mul_Est_Emp();



            int affectedRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                //부서갯수만큼 루프
                for (int i = 0; i < DT_dept_id.Rows.Count; i++)
                {
                    string dept_ref_id = DT_dept_id.Rows[i]["DEPT_ID"].ToString();

                    DataTable DT_tgt_emp_id = dacRelDeptEmp.SelectRelDeptEmp_DB(0
                                                                            , comp_id
                                                                            , dept_ref_id
                                                                            , est_id
                                                                            , estterm_ref_id
                                                                            , estterm_sub_id).Tables[0];

                    affectedRow += _data.Delete_Pool_Data(conn, trx
                                                        , comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , DT_tgt_emp_id);
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

            return affectedRow;
        }



        /// <summary>
        /// DT_tgt_emp_id에 해당하는 평가자 리스트를 풀에서 조회
        /// 평가자에 tgt_emp_id는 제외됨
        /// 사용되지 않았던 평가자
        /// </summary>
        public DataTable Get_BaseEstEmpList(int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , DataTable DT_tgt_emp_id)
        {
            DataTable DT = _data.Select_BaseEstEmptable(comp_id, est_id, estterm_ref_id, estterm_sub_id, DT_tgt_emp_id, "N");

            return DT;
        }
    }
}