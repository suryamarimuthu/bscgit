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
    public class Dac_CtrlGradeDatas : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int ctrl_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int ctrl_seq
                        , string ctrl_grade_id
                        , string ctrl_opinion
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_CTRL_GRADE_DATA
	                            SET	 CTRL_GRADE_ID		= @CTRL_GRADE_ID
                                    ,CTRL_OPINION       = @CTRL_OPINION
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
                                    AND	ESTTERM_STEP_ID	= @ESTTERM_STEP_ID
		                            AND	CTRL_EMP_ID		= @CTRL_EMP_ID
                                    AND	TGT_DEPT_ID		= @TGT_DEPT_ID
		                            AND	TGT_EMP_ID		= @TGT_EMP_ID
		                            AND	CTRL_SEQ		= @CTRL_SEQ";

	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
	        paramArray[8] 		= CreateDataParameter("@CTRL_SEQ", SqlDbType.Int);
	        paramArray[8].Value = ctrl_seq;
	        paramArray[9] 		= CreateDataParameter("@CTRL_GRADE_ID", SqlDbType.NVarChar);
	        paramArray[9].Value = ctrl_grade_id;
            paramArray[10] 		= CreateDataParameter("@CTRL_OPINION", SqlDbType.NVarChar);
	        paramArray[10].Value= ctrl_opinion;
	        paramArray[11] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[11].Value= update_date;
	        paramArray[12] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[12].Value= update_user;
         
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

        public int UpdateConfirmCtrl( IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int ctrl_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int ctrl_seq
                                    , string before_grade_id
                                    , DateTime update_date
                                    , int update_user)
        {
            string query = @"UPDATE	EST_CTRL_GRADE_DATA
	                            SET	 CTRL_YN			= 'Y'
                                    ,BEFORE_GRADE_ID    = @BEFORE_GRADE_ID
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
                                    AND	ESTTERM_STEP_ID	= @ESTTERM_STEP_ID
		                            AND	CTRL_EMP_ID		= @CTRL_EMP_ID
                                    AND	TGT_DEPT_ID		= @TGT_DEPT_ID
		                            AND	TGT_EMP_ID		= @TGT_EMP_ID
		                            AND	CTRL_SEQ		= @CTRL_SEQ";

	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
	        paramArray[8] 		= CreateDataParameter("@CTRL_SEQ", SqlDbType.Int);
	        paramArray[8].Value = ctrl_seq;
	        paramArray[9] 		= CreateDataParameter("@BEFORE_GRADE_ID", SqlDbType.NVarChar);
	        paramArray[9].Value = before_grade_id;
	        paramArray[10] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[10].Value= update_date;
	        paramArray[11] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[11].Value= update_user;
         
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

        public int UpdateInitCtrlYN(  IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int ctrl_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
        {
            string query = @"UPDATE	EST_CTRL_POINT_DATA
	                            SET	 CTRL_YN			= 'N'
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
                                    AND	ESTTERM_STEP_ID	= @ESTTERM_STEP_ID
		                            AND	CTRL_EMP_ID		= @CTRL_EMP_ID
                                    AND	TGT_DEPT_ID		= @TGT_DEPT_ID
		                            AND	TGT_EMP_ID		= @TGT_EMP_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
         
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
                            , int ctrl_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , int ctrl_seq)
        {
            string query = @"SELECT	 CGD.COMP_ID
	                                ,CGD.EST_ID
	                                ,CGD.ESTTERM_REF_ID
	                                ,CGD.ESTTERM_SUB_ID
                                    ,CGD.ESTTERM_STEP_ID
	                                ,CGD.CTRL_EMP_ID
	                                ,CE1.EMP_NAME       AS CTRL_EMP_NAME
                                    ,CGD.TGT_DEPT_ID
                                    ,EDI.DEPT_NAME      AS TGT_DEPT_NAME
	                                ,CGD.TGT_EMP_ID
                                    ,CE1.EMP_NAME       AS TGT_EMP_NAME
	                                ,CGD.CTRL_SEQ
	                                ,CGD.CTRL_GRADE_ID
                                    ,EG.GRADE_NAME      AS CTRL_GRADE_NAME
                                    ,CGD.CTRL_OPINION
                                    ,CGD.CTRL_YN
                                    ,CGD.BEFORE_GRADE_ID
	                                ,CGD.CREATE_DATE
	                                ,CGD.CREATE_USER
	                                ,CGD.UPDATE_DATE
	                                ,CGD.UPDATE_USER
                                FROM	            EST_CTRL_GRADE_DATA CGD
                                    JOIN            EST_GRADE           EG     ON (CGD.COMP_ID         = EG.COMP_ID
                                                                               AND CGD.CTRL_GRADE_ID   = EG.GRADE_ID)
                                    JOIN            COM_EMP_INFO        CE1    ON (CGD.CTRL_EMP_ID     = CE1.EMP_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO        CE2    ON (CGD.TGT_EMP_ID      = CE2.EMP_REF_ID)
                                    JOIN            COM_DEPT_INFO       EDI    ON (CGD.TGT_DEPT_ID     = EDI.DEPT_REF_ID)
                                WHERE	(CGD.COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
	                                AND	(CGD.EST_ID			= @EST_ID			OR @EST_ID			    =''    )
	                                AND	(CGD.ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
	                                AND	(CGD.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
                                    AND	(CGD.ESTTERM_STEP_ID= @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID	= 0)
	                                AND	(CGD.CTRL_EMP_ID	= @CTRL_EMP_ID		OR @CTRL_EMP_ID		= 0)
                                    AND	(CGD.TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
	                                AND	(CGD.TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
	                                AND	(CGD.CTRL_SEQ		= @CTRL_SEQ			OR @CTRL_SEQ		= 0)
                                ORDER BY CGD.CTRL_SEQ";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
	        paramArray[8] 		= CreateDataParameter("@CTRL_SEQ", SqlDbType.Int);
	        paramArray[8].Value = ctrl_seq;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "CTRLGRADEDATAGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int ctrl_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int ctrl_seq
                        , string ctrl_grade_id
                        , string ctrl_opinion
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_CTRL_GRADE_DATA(COMP_ID
								                            ,EST_ID
								                            ,ESTTERM_REF_ID
								                            ,ESTTERM_SUB_ID
                                                            ,ESTTERM_STEP_ID
								                            ,CTRL_EMP_ID
                                                            ,TGT_DEPT_ID
								                            ,TGT_EMP_ID
								                            ,CTRL_SEQ
								                            ,CTRL_GRADE_ID
                                                            ,CTRL_OPINION
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
								                            ,@CTRL_EMP_ID
                                                            ,@TGT_DEPT_ID
								                            ,@TGT_EMP_ID
								                            ,@CTRL_SEQ
								                            ,@CTRL_GRADE_ID
                                                            ,@CTRL_OPINION
								                            ,@CREATE_DATE
								                            ,@CREATE_USER
								                            ,NULL
								                            ,NULL
								                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
	        paramArray[8] 		= CreateDataParameter("@CTRL_SEQ", SqlDbType.Int);
	        paramArray[8].Value = ctrl_seq;
	        paramArray[9] 		= CreateDataParameter("@CTRL_GRADE_ID", SqlDbType.NVarChar);
	        paramArray[9].Value = ctrl_grade_id;
            paramArray[10] 		= CreateDataParameter("@CTRL_OPINION", SqlDbType.NVarChar);
	        paramArray[10].Value = ctrl_opinion;
	        paramArray[11] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[11].Value = create_date;
	        paramArray[12] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[12].Value = create_user;
         
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
                        , int ctrl_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int ctrl_seq)
        {
            string query = @"DELETE	EST_CTRL_GRADE_DATA
	                            WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
		                            AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                            AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
		                            AND	(ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
                                    AND	(ESTTERM_STEP_ID= @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID	= 0)
		                            AND	(CTRL_EMP_ID	= @CTRL_EMP_ID		OR @CTRL_EMP_ID		= 0)
                                    AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
		                            AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
		                            AND	(CTRL_SEQ		= @CTRL_SEQ			OR @CTRL_SEQ		= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
	        paramArray[8] 		= CreateDataParameter("@CTRL_SEQ", SqlDbType.Int);
	        paramArray[8].Value = ctrl_seq;
         
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

        public int Count( int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int ctrl_emp_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , int ctrl_seq)
        {
            string query = @"SELECT COUNT(*) FROM EST_CTRL_GRADE_DATA
	                            WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
		                            AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                            AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
		                            AND	(ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
                                    AND	(ESTTERM_STEP_ID= @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID	= 0)
		                            AND	(CTRL_EMP_ID	= @CTRL_EMP_ID		OR @CTRL_EMP_ID		= 0)
                                    AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
		                            AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
		                            AND	(CTRL_SEQ		= @CTRL_SEQ			OR @CTRL_SEQ		= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@CTRL_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = ctrl_emp_id;
            paramArray[6] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[6].Value = tgt_dept_id;
	        paramArray[7] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value = tgt_emp_id;
	        paramArray[8] 		= CreateDataParameter("@CTRL_SEQ", SqlDbType.Int);
	        paramArray[8].Value = ctrl_seq;
         
	        try
	        {
		        return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
