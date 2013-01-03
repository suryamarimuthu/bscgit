using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_QuestionComments : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
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
            string query = @"UPDATE	EST_QUESTION_COMMENT
	                            SET	 COMMENT			= @COMMENT
		                            ,EST_TGT_TYPE		= @EST_TGT_TYPE
		                            ,CONFIRM_TYPE		= @CONFIRM_TYPE
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		                            AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID
		                            AND	EST_DEPT_ID		= @EST_DEPT_ID
		                            AND	EST_EMP_ID		= @EST_EMP_ID
		                            AND	TGT_DEPT_ID		= @TGT_DEPT_ID
		                            AND	TGT_EMP_ID		= @TGT_EMP_ID
		                            AND	SEQ				= @SEQ";

	        IDbDataParameter[] paramArray = CreateDataParameters(15);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
	        paramArray[5].Value = est_dept_id;
	        paramArray[6] 		= CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value = est_emp_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_dept_id;
	        paramArray[8] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[8].Value = tgt_emp_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[9].Value = seq;
	        paramArray[10] 		= CreateDataParameter("@COMMENT", SqlDbType.NVarChar, 4000);
	        paramArray[10].Value= comment;
	        paramArray[11] 		= CreateDataParameter("@EST_TGT_TYPE", SqlDbType.NVarChar, 6);
	        paramArray[11].Value= est_tgt_type;
	        paramArray[12] 		= CreateDataParameter("@CONFIRM_TYPE", SqlDbType.NVarChar, 6);
	        paramArray[12].Value= confirm_type;
	        paramArray[13] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[13].Value= update_date;
	        paramArray[14] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[14].Value= update_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , int comp_id
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
            string query = @"SELECT	 COMP_ID
		                            ,EST_ID
		                            ,ESTTERM_REF_ID
		                            ,ESTTERM_SUB_ID
		                            ,ESTTERM_STEP_ID
		                            ,EST_DEPT_ID
		                            ,EST_EMP_ID
		                            ,TGT_DEPT_ID
		                            ,TGT_EMP_ID
		                            ,SEQ
		                            ,COMMENT
		                            ,EST_TGT_TYPE
		                            ,CONFIRM_TYPE
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_QUESTION_COMMENT 
		                            WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
			                            AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
			                            AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
			                            AND	(ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
			                            AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID = 0)
			                            AND	(EST_DEPT_ID	= @EST_DEPT_ID		OR @EST_DEPT_ID		= 0)
			                            AND	(EST_EMP_ID		= @EST_EMP_ID		OR @EST_EMP_ID		= 0)
			                            AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
			                            AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
			                            AND	(SEQ			= @SEQ				OR @SEQ				= 0)
                                    ORDER BY SEQ";

	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
	        paramArray[5].Value = est_dept_id;
	        paramArray[6] 		= CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value = est_emp_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_dept_id;
	        paramArray[8] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[8].Value = tgt_emp_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[9].Value = seq;
         
	        DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONCOMMENTGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
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
            string query = @"INSERT INTO EST_QUESTION_COMMENT(COMP_ID
								                            ,EST_ID
								                            ,ESTTERM_REF_ID
								                            ,ESTTERM_SUB_ID
								                            ,ESTTERM_STEP_ID
								                            ,EST_DEPT_ID
								                            ,EST_EMP_ID
								                            ,TGT_DEPT_ID
								                            ,TGT_EMP_ID
								                            ,SEQ
								                            ,COMMENT
								                            ,EST_TGT_TYPE
								                            ,CONFIRM_TYPE
								                            ,CREATE_DATE
								                            ,CREATE_USER
								                            ,UPDATE_DATE
								                            ,UPDATE_USER
								                            )
							                            VALUES	(@COMP_ID
								                            ,@EST_ID
								                            ,@ESTTERM_REF_ID
								                            ,@ESTTERM_SUB_ID
								                            ,@ESTTERM_STEP_ID
								                            ,@EST_DEPT_ID
								                            ,@EST_EMP_ID
								                            ,@TGT_DEPT_ID
								                            ,@TGT_EMP_ID
								                            ,@SEQ
								                            ,@COMMENTS
								                            ,@EST_TGT_TYPE
								                            ,@CONFIRM_TYPE
								                            ,@CREATE_DATE
								                            ,@CREATE_USER
								                            ,NULL
								                            ,NULL
								                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(15);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
	        paramArray[5].Value = est_dept_id;
	        paramArray[6] 		= CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value = est_emp_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_dept_id;
	        paramArray[8] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[8].Value = tgt_emp_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[9].Value = seq;
	        paramArray[10] 		= CreateDataParameter("@COMMENTS", SqlDbType.NVarChar, 4000);
	        paramArray[10].Value= comment;
	        paramArray[11] 		= CreateDataParameter("@EST_TGT_TYPE", SqlDbType.NVarChar, 6);
	        paramArray[11].Value= est_tgt_type;
	        paramArray[12] 		= CreateDataParameter("@CONFIRM_TYPE", SqlDbType.NVarChar, 6);
	        paramArray[12].Value= confirm_type;
	        paramArray[13] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[13].Value= create_date;
	        paramArray[14] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[14].Value= create_user;

	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object seq)
        {
            string query = @"DELETE	EST_QUESTION_COMMENT
	                            WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
		                            AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                            AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
		                            AND	(ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
		                            AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID = 0)
		                            AND	(EST_DEPT_ID	= @EST_DEPT_ID		OR @EST_DEPT_ID		= 0)
		                            AND	(EST_EMP_ID		= @EST_EMP_ID		OR @EST_EMP_ID		= 0)
		                            AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
		                            AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
		                            AND	(SEQ			= @SEQ				OR @SEQ				= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
	        paramArray[5].Value = est_dept_id;
	        paramArray[6] 		= CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value = est_emp_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_dept_id;
	        paramArray[8] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[8].Value = tgt_emp_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[9].Value = seq;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        public int Count( IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
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
            string query = @"SELECT COUNT(*) FROM EST_QUESTION_COMMENT
                                WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
		                            AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                            AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
		                            AND	(ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
		                            AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID = 0)
		                            AND	(EST_DEPT_ID	= @EST_DEPT_ID		OR @EST_DEPT_ID		= 0)
		                            AND	(EST_EMP_ID		= @EST_EMP_ID		OR @EST_EMP_ID		= 0)
		                            AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
		                            AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
		                            AND	(SEQ			= @SEQ				OR @SEQ				= 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
	        paramArray[5].Value = est_dept_id;
	        paramArray[6] 		= CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value = est_emp_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_dept_id;
	        paramArray[8] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[8].Value = tgt_emp_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[9].Value = seq;

            try
            {
               int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
