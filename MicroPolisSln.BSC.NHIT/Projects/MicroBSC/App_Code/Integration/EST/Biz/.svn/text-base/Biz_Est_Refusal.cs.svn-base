using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Refusal
    {
        Dac_Est_Refusal _data;

        public Biz_Est_Refusal()
	    {
            _data = new Dac_Est_Refusal();
	    }


        public bool Add_Est_Refusal(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string refusal_comment
                                    , string grade_id
                                    , int create_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Insert_Est_Refusal(conn, trx
                                                        , comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , estterm_step_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id
                                                        , refusal_comment
                                                        , grade_id
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



        public bool Modify_Est_Refusal_Comment(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id
                                            , string refusal_comment
                                            , int update_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Update_Est_Refusal_Comment(conn, trx
                                                                , comp_id
                                                                , est_id
                                                                , estterm_ref_id
                                                                , estterm_sub_id
                                                                , estterm_step_id
                                                                , tgt_dept_id
                                                                , tgt_emp_id
                                                                , refusal_comment
                                                                , update_user_ref_id);

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



        public bool Modify_Est_Refusal_Reply(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id
                                            , int reply_emp_id
                                            , string reply_comment
                                            , int update_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _data.Update_Est_Refusal_Reply(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , tgt_dept_id
                                                            , tgt_emp_id
                                                            , reply_emp_id
                                                            , reply_comment
                                                            , update_user_ref_id);

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


        public DataTable Get_Est_Refusal_Data(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id)
        {
            DataTable dt = _data.Select_Est_Refusal(comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id);

            return dt;
        }
    }
}