using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_QuestionComments
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private int 	_estterm_sub_id;
        private int 	_estterm_step_id;
        private int 	_est_dept_id;
        private int 	_est_emp_id;
        private int 	_tgt_dept_id;
        private int 	_tgt_emp_id;
        private int 	_seq;
        private string 	_comment;
        private string 	_est_tgt_type;
        private string 	_confirm_type;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_QuestionComments _questionComment = new Dac_QuestionComments();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public int Comp_ID
        {
	        get 
	        {
		        return _comp_id;
	        }
	        set
	        {
		        _comp_id = value;
	        }
        }
         
        public string Est_ID
        {
	        get 
	        {
		        return _est_id;
	        }
	        set
	        {
		        _est_id = ( value==null ? "" : value );
	        }
        }
         
        public int EstTerm_Ref_ID
        {
	        get 
	        {
		        return _estterm_ref_id;
	        }
	        set
	        {
		        _estterm_ref_id = value;
	        }
        }
         
        public int EstTerm_Sub_ID
        {
	        get 
	        {
		        return _estterm_sub_id;
	        }
	        set
	        {
		        _estterm_sub_id = value;
	        }
        }
         
        public int EstTerm_Step_ID
        {
	        get 
	        {
		        return _estterm_step_id;
	        }
	        set
	        {
		        _estterm_step_id = value;
	        }
        }
         
        public int Est_Dept_ID
        {
	        get 
	        {
		        return _est_dept_id;
	        }
	        set
	        {
		        _est_dept_id = value;
	        }
        }
         
        public int Est_Emp_ID
        {
	        get 
	        {
		        return _est_emp_id;
	        }
	        set
	        {
		        _est_emp_id = value;
	        }
        }
         
        public int Tgt_Dept_ID
        {
	        get 
	        {
		        return _tgt_dept_id;
	        }
	        set
	        {
		        _tgt_dept_id = value;
	        }
        }
         
        public int Tgt_Emp_ID
        {
	        get 
	        {
		        return _tgt_emp_id;
	        }
	        set
	        {
		        _tgt_emp_id = value;
	        }
        }
         
        public int Seq
        {
	        get 
	        {
		        return _seq;
	        }
	        set
	        {
		        _seq = value;
	        }
        }
         
        public string Comment
        {
	        get 
	        {
		        return _comment;
	        }
	        set
	        {
		        _comment = ( value==null ? "" : value );
	        }
        }
         
        public string Est_Tgt_Type
        {
	        get 
	        {
		        return _est_tgt_type;
	        }
	        set
	        {
		        _est_tgt_type = ( value==null ? "" : value );
	        }
        }
         
        public string Confirm_Type
        {
	        get 
	        {
		        return _confirm_type;
	        }
	        set
	        {
		        _confirm_type = ( value==null ? "" : value );
	        }
        }
         
        public DateTime Update_Date
        {
	        get 
	        {
		        return _update_date;
	        }
	        set
	        {
		        _update_date = value;
	        }
        }
         
        public int Update_User
        {
	        get 
	        {
		        return _update_user;
	        }
	        set
	        {
		        _update_user = value;
	        }
        }
        #endregion

	    public Biz_QuestionComments()
	    {
		    
	    }

        public Biz_QuestionComments(  int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq)
	    {
            DataSet ds = _questionComment.Select( null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq);
		    DataRow dr;
 
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
		        _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
		        _estterm_step_id    = (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
		        _est_dept_id        = (dr["EST_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_ID"]);
		        _est_emp_id         = (dr["EST_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_EMP_ID"]);
		        _tgt_dept_id        = (dr["TGT_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
		        _tgt_emp_id         = (dr["TGT_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
		        _seq                = (dr["SEQ"]                == DBNull.Value) ? 0 : Convert.ToInt32(dr["SEQ"]);
		        _comment            = (dr["COMMENT"]            == DBNull.Value) ? "" : (string) dr["COMMENT"];
		        _est_tgt_type       = (dr["EST_TGT_TYPE"]       == DBNull.Value) ? "" : (string) dr["EST_TGT_TYPE"];
		        _confirm_type       = (dr["CONFIRM_TYPE"]       == DBNull.Value) ? "" : (string) dr["CONFIRM_TYPE"];
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }

        public bool ModifyQuestionComment(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq
                                        , string comment
                                        , string est_tgt_type
                                        , string confirm_type
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _questionComment.Update(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , comment
                                                , est_tgt_type
                                                , confirm_type
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionComment(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
            return _questionComment.Select(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_dept_id
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id
                                        , 0);
        }
         
        public DataSet GetQuestionComment(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq)
        {
            return _questionComment.Select(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_dept_id
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id
                                        , seq);
        }
         
        public bool AddQuestionComment(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int seq
                                    , string comment
                                    , string est_tgt_type
                                    , string confirm_type
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _questionComment.Insert(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq
                                                , comment
                                                , est_tgt_type
                                                , confirm_type
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool AddQuestionComment(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string comment
                                    , string est_tgt_type
                                    , string confirm_type
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                int cnt = _questionComment.Count( conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , 0);


                affectedRow = _questionComment.Insert(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , est_dept_id
                                                    , est_emp_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id
                                                    , cnt + 1
                                                    , comment
                                                    , est_tgt_type
                                                    , confirm_type
                                                    , create_date
                                                    , create_user);

				trx.Commit();
			}
			catch ( Exception ex )
			{
				trx.Rollback();
				return false;
			}
			finally
			{
				conn.Close();
			}

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveQuestionComment(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , int seq)
        {
	        int affectedRow = 0;

            affectedRow = _questionComment.Delete(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , seq);

            return (affectedRow > 0) ? true : false;
        }
    }
}
