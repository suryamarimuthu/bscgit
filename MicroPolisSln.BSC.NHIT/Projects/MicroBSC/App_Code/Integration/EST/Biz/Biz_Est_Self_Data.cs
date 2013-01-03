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
    public class Biz_Est_Self_Data
    {
        Dac_Est_Self_Data _data;

        public Biz_Est_Self_Data()
	    {
            _data = new Dac_Est_Self_Data();
	    }

        public DataTable Get_Self_Est_Question(int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id)
        {
            DataTable dt = _data.Select_Self_Est_Question(comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , estterm_step_id
                                                        , tgt_dept_id
                                                        , tgt_emp_id);

            return dt;        
        }



        public bool Add_Self_Est_Question(IDbConnection conn, IDbTransaction trx
                                        , int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int self_top_id
                                        , int self_mid_id
                                        , string self_comment
                                        , int create_user_ref_id)
        {
            int affectedRow = _data.Insert_Self_Est_Question(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , tgt_dept_id
                                                            , tgt_emp_id
                                                            , self_top_id
                                                            , self_mid_id
                                                            , self_comment
                                                            , create_user_ref_id);

            return affectedRow > 0 ? true : false;
        }
        public bool Add_Self_Est_Question(IDbConnection conn, IDbTransaction trx, DataTable dt, int create_user_ref_id)
        {
            int affectedRow = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                int comp_id = DataTypeUtility.GetToInt32(dt.Rows[i]["COMP_ID"]);
                string est_id = DataTypeUtility.GetString(dt.Rows[i]["EST_ID"]);
                int estterm_ref_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_REF_ID"]);
                int estterm_sub_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_SUB_ID"]);
                int estterm_step_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_STEP_ID"]);
                int tgt_dept_id = DataTypeUtility.GetToInt32(dt.Rows[i]["TGT_DEPT_ID"]);
                int tgt_emp_id = DataTypeUtility.GetToInt32(dt.Rows[i]["TGT_EMP_ID"]);
                int self_top_id = DataTypeUtility.GetToInt32(dt.Rows[i]["SELF_TOP_ID"]);
                int self_mid_id = DataTypeUtility.GetToInt32(dt.Rows[i]["SELF_MID_ID"]);
                string self_comment = DataTypeUtility.GetString(dt.Rows[i]["SELF_COMMENT"]);

                affectedRow += _data.Insert_Self_Est_Question(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , tgt_dept_id
                                                            , tgt_emp_id
                                                            , self_top_id
                                                            , self_mid_id
                                                            , self_comment
                                                            , create_user_ref_id);
            }

            return affectedRow > 0 ? true : false;
        }



        public bool Remove_Self_Est_Question(IDbConnection conn, IDbTransaction trx
                                            , int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id)
        {
            int affectedRow = _data.Delete_Self_Est_Question(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , tgt_emp_id);

            return affectedRow > 0 ? true : false;
        }
        public bool Remove_Self_Est_Question(IDbConnection conn, IDbTransaction trx, DataTable dt)
        {
            int affectedRow = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int comp_id = DataTypeUtility.GetToInt32(dt.Rows[i]["COMP_ID"]);
                string est_id = DataTypeUtility.GetString(dt.Rows[i]["EST_ID"]);
                int estterm_ref_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_REF_ID"]);
                int estterm_sub_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_SUB_ID"]);
                int estterm_step_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_STEP_ID"]);
                int tgt_emp_id = DataTypeUtility.GetToInt32(dt.Rows[i]["TGT_EMP_ID"]);

                affectedRow += _data.Delete_Self_Est_Question(conn, trx
                                                            , comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , tgt_emp_id);
            }

            return affectedRow > 0 ? true : false;
        }



        public bool Save_Self_Est(DataTable dt_EstData, DataTable dt_QuestionData, DataTable dt_EstSelfData, int user_ref_id)
        {
            MicroBSC.Estimation.Biz.Biz_QuestionDatas questionDatas = new MicroBSC.Estimation.Biz.Biz_QuestionDatas();
            bool result = false;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();
            

            try
            {
                questionDatas.SaveQuestionData(conn, trx, dt_QuestionData, dt_EstData);


                Remove_Self_Est_Question(conn, trx, dt_EstSelfData);
                Add_Self_Est_Question(conn, trx, dt_EstSelfData, user_ref_id);

                trx.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                trx.Rollback();
                result = false;
            }
            finally
            {
                conn.Close();
            }


            return result;
        }
    }
}