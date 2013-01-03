using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MicroBSC.Integration.EST.Dac;

using MicroBSC.Data;

/// <summary>
/// Summary description for Biz_Est_Question_Data
/// </summary>
namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Question_Data
    {
        Dac_Est_Question_Data _data;

        public Biz_Est_Question_Data()
        {
            _data = new Dac_Est_Question_Data();
        }

        public DataTable SelectEstQuestionDataSelfPoint(string q_obj_id, string q_sbj_id)
        {
            DataTable dt = new Dac_Est_Question_Data().SelectEstQuestionDataSelfPoint(q_obj_id, q_sbj_id);

            return dt;
        }

        public DataTable SelectEstQuestionDataSelfPointResultCount(int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            string Q_OBJ_ID, int TGT_EMP_ID, string EST_ID)
        {
            DataTable dt = new Dac_Est_Question_Data().SelectEstQuestionDataSelfPointResultCount(ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID,
                Q_OBJ_ID, TGT_EMP_ID, EST_ID);
            return dt;
        }

        public DataTable SelectEstQuestionDataSelfPointResultPoint(int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
           string Q_OBJ_ID, int TGT_EMP_ID, string EST_ID)
        {
            DataTable dt = new Dac_Est_Question_Data().SelectEstQuestionDataSelfPointResultPoint(ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
                , Q_OBJ_ID, TGT_EMP_ID, EST_ID); ;
            return dt;
        }

        public int Insert(string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_SBJ_ID, string Q_ITM_ID, int POINT, int EMP_NO)
        {
            return new Dac_Est_Question_Data().Insert(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID,
            EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, Q_OBJ_ID, Q_SBJ_ID, Q_ITM_ID, POINT, EMP_NO);
        }


        public int Remove_EstQuestion(string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_SBJ_ID, string Q_ITM_ID)
        {
            return _data.Delete(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID
                , Q_OBJ_ID, Q_SBJ_ID, Q_ITM_ID);
        }


        public int Add_EstQuestionData(DataTable dt, int create_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    _data.Delete(conn, trx
                                , DataTypeUtility.GetString(dr["COMP_ID"])
                                , DataTypeUtility.GetString(dr["EST_ID"])
                                , DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"])
                                , DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"])
                                , DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"])
                                , DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"])
                                , DataTypeUtility.GetToInt32(dr["EST_EMP_ID"])
                                , DataTypeUtility.GetToInt32(dr["TGT_DEPT_ID"])
                                , DataTypeUtility.GetToInt32(dr["TGT_EMP_ID"])
                                , ""
                                , ""
                                , "");

                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    _data.Insert(conn, trx
                                , DataTypeUtility.GetString(dr["COMP_ID"])
                                , DataTypeUtility.GetString(dr["EST_ID"])
                                , DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"])
                                , DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"])
                                , DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"])
                                , DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"])
                                , DataTypeUtility.GetToInt32(dr["EST_EMP_ID"])
                                , DataTypeUtility.GetToInt32(dr["TGT_DEPT_ID"])
                                , DataTypeUtility.GetToInt32(dr["TGT_EMP_ID"])
                                , DataTypeUtility.GetString(dr["Q_OBJ_ID"])
                                , DataTypeUtility.GetString(dr["Q_DFN_ID"])
                                , DataTypeUtility.GetString(dr["Q_SBJ_ID"])
                                , DataTypeUtility.GetString(dr["Q_ITM_ID"])
                                , DataTypeUtility.GetToInt32(dr["POINT"])
                                , create_user_ref_id);

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


        public DataTable Get_Est_QuestionSbj_Point(int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id
                                                , int est_dept_id
                                                , int est_emp_id
                                                , int tgt_dept_id
                                                , int tgt_emp_id)
        {
            DataTable dt = _data.Select_Est_QuestionSbj_Point(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , est_dept_id
                                                            , est_emp_id
                                                            , tgt_dept_id
                                                            , tgt_emp_id);

            return dt;
        }
    }
}
