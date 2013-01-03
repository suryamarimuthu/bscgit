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
    public class Dac_QuestionDatas : DbAgentBase
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
                        , string q_obj_id
                        , string q_sbj_id
                        , string q_itm_id
                        , float point
                        , string grade_id
                        , string text_value
                        , string opinion
                        , string attach_no
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_DATA
		                        SET	 Q_OBJ_ID           = @Q_OBJ_ID
			                        ,Q_ITM_ID           = @Q_ITM_ID
			                        ,POINT              = @POINT
			                        ,GRADE_ID           = @GRADE_ID
			                        ,TEXT_VALUE         = @TEXT_VALUE
			                        ,OPINION            = @OPINION
			                        ,ATTACH_NO          = @ATTACH_NO
			                        ,UPDATE_DATE        = GETDATE()
			                        ,UPDATE_USER        = @UPDATE_USER
		                        WHERE	COMP_ID         = @COMP_ID
                                    AND EST_ID          = @EST_ID
		                            AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
		                            AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID
		                            AND	EST_DEPT_ID     = @EST_DEPT_ID
		                            AND	EST_EMP_ID      = @EST_EMP_ID
		                            AND	TGT_DEPT_ID     = @TGT_DEPT_ID
		                            AND	TGT_EMP_ID      = @TGT_EMP_ID
		                            AND	Q_SBJ_ID        = @Q_SBJ_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[9].Value = q_obj_id;
            paramArray[10] = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[10].Value = q_sbj_id;
            paramArray[11] = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 20);
            paramArray[11].Value = q_itm_id;
            paramArray[12] = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[12].Value = point;
            paramArray[13] = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[13].Value = grade_id;
            paramArray[14] = CreateDataParameter("@TEXT_VALUE", SqlDbType.NVarChar, 1000);
            paramArray[14].Value = text_value;
            paramArray[15] = CreateDataParameter("@OPINION", SqlDbType.NVarChar, 1000);
            paramArray[15].Value = opinion;
            paramArray[16] = CreateDataParameter("@ATTACH_NO", SqlDbType.NVarChar, 60);
            paramArray[16].Value = attach_no;
            paramArray[17] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[17].Value = update_user;

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

        public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , string q_sbj_id)
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
	                                ,Q_OBJ_ID
	                                ,Q_SBJ_ID
	                                ,Q_ITM_ID
	                                ,POINT
	                                ,GRADE_ID
	                                ,TEXT_VALUE
	                                ,OPINION
	                                ,ATTACH_NO
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_QUESTION_DATA 
                                    WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                        AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                        AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                        AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                        AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                        AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                        AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                        AND	(TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                        AND	(TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                        AND	(Q_SBJ_ID        = @Q_SBJ_ID        OR @Q_SBJ_ID            =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[9].Value = q_sbj_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONDATAGET", null, paramArray, CommandType.Text);
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
                        , string q_obj_id
                        , string q_sbj_id
                        , string q_itm_id
                        , float point
                        , string grade_id
                        , string text_value
                        , string opinion
                        , string attach_no
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_DATA(COMP_ID
                                                        ,EST_ID
			                                            ,ESTTERM_REF_ID
			                                            ,ESTTERM_SUB_ID
			                                            ,ESTTERM_STEP_ID
			                                            ,EST_DEPT_ID
			                                            ,EST_EMP_ID
			                                            ,TGT_DEPT_ID
			                                            ,TGT_EMP_ID
			                                            ,Q_OBJ_ID
			                                            ,Q_SBJ_ID
			                                            ,Q_ITM_ID
			                                            ,POINT
			                                            ,GRADE_ID
			                                            ,TEXT_VALUE
			                                            ,OPINION
			                                            ,ATTACH_NO
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
			                                            ,@Q_OBJ_ID
			                                            ,@Q_SBJ_ID
			                                            ,@Q_ITM_ID
			                                            ,@POINT
			                                            ,@GRADE_ID
			                                            ,@TEXT_VALUE
			                                            ,@OPINION
			                                            ,@ATTACH_NO
			                                            ,GETDATE()
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[9].Value = q_obj_id;
            paramArray[10]      = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[10].Value= q_sbj_id;
            paramArray[11]      = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 20);
            paramArray[11].Value= q_itm_id;
            paramArray[12]      = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[12].Value= point;
            paramArray[13]      = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[13].Value= grade_id;
            paramArray[14]      = CreateDataParameter("@TEXT_VALUE", SqlDbType.NVarChar, 1000);
            paramArray[14].Value= text_value;
            paramArray[15]      = CreateDataParameter("@OPINION", SqlDbType.NVarChar, 1000);
            paramArray[15].Value= opinion;
            paramArray[16]      = CreateDataParameter("@ATTACH_NO", SqlDbType.NVarChar, 60);
            paramArray[16].Value= attach_no;
            paramArray[17]      = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[17].Value= create_user;

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
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , string q_sbj_id)
        {
            string query = @"DELETE	EST_QUESTION_DATA
                                WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND	(Q_SBJ_ID        = @Q_SBJ_ID        OR @Q_SBJ_ID            =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);
            
            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[9].Value = q_sbj_id;

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
                        , string q_sbj_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_QUESTION_DATA
                                WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND	(Q_SBJ_ID        = @Q_SBJ_ID        OR @Q_SBJ_ID            =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[9].Value = q_sbj_id;

            try
            {
                return Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
