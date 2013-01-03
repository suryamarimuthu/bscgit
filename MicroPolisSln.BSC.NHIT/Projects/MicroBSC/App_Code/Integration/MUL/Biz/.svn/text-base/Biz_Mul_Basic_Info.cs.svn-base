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
    public class Biz_Mul_Basic_Info
    {
        private Dac_Mul_Basic_Info _data;

        public Biz_Mul_Basic_Info()
        {
            _data = new Dac_Mul_Basic_Info();
        }



        public bool Add_Mul_Basic_Info(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int max_est_emp_cnt
                                        , int mid_est_emp_cnt
                                        , int min_est_emp_cnt
                                        , int create_user_ref_id)
        {
            int affectedRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Insert_Mul_Est_Basic_Info(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , max_est_emp_cnt
                                                            , mid_est_emp_cnt
                                                            , min_est_emp_cnt
                                                            , create_user_ref_id);
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




        public bool Remove_Mul_Basic_Info(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id)
        {
            int affectedRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Delete_Mul_Est_Basic_Info(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id);

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




        public DataTable Get_Mul_Basic_Info(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id)
        {
            DataTable DT = _data.Select_Mul_Basic_Info(comp_id, est_id, estterm_ref_id, estterm_sub_id);

            return DT;
        }
    }
}