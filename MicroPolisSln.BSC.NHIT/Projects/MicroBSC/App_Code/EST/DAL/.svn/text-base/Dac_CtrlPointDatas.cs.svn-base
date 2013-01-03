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
    public class Dac_CtrlPointDatas : DbAgentBase
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
                        , float ctrl_point
                        , string ctrl_opinion
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_CTRL_POINT_DATA
	                            SET	 CTRL_POINT			= @CTRL_POINT
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
	        paramArray[9] 		= CreateDataParameter("@CTRL_POINT", SqlDbType.Float);
	        paramArray[9].Value = ctrl_point;
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
                                    , float before_point
                                    , DateTime update_date
                                    , int update_user)
        {
            string query = @"UPDATE	EST_CTRL_POINT_DATA
	                            SET	 CTRL_YN			= 'Y'
                                    ,BEFORE_POINT       = @BEFORE_POINT
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
	        paramArray[9] 		= CreateDataParameter("@BEFORE_POINT", SqlDbType.Float);
	        paramArray[9].Value = before_point;
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
	                            SET	        CTRL_YN			= 'N'
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
            string query = @"SELECT	 CPD.COMP_ID
	                                ,CPD.EST_ID
	                                ,CPD.ESTTERM_REF_ID
	                                ,CPD.ESTTERM_SUB_ID
                                    ,CPD.ESTTERM_STEP_ID
	                                ,CPD.CTRL_EMP_ID
                                    ,CE1.EMP_NAME       AS CTRL_EMP_NAME
                                    ,CPD.TGT_DEPT_ID
                                    ,EDI.DEPT_NAME      AS TGT_DEPT_NAME
	                                ,CPD.TGT_EMP_ID
                                    ,CE1.EMP_NAME       AS TGT_EMP_NAME
	                                ,CPD.CTRL_SEQ
	                                ,CPD.CTRL_POINT
                                    ,CPD.CTRL_OPINION
                                    ,CPD.CTRL_YN
                                    ,CPD.BEFORE_POINT
	                                ,CPD.CREATE_DATE
	                                ,CPD.CREATE_USER
	                                ,CPD.UPDATE_DATE
	                                ,CPD.UPDATE_USER
                                FROM	            EST_CTRL_POINT_DATA CPD
                                    JOIN            COM_EMP_INFO        CE1    ON (CPD.CTRL_EMP_ID = CE1.EMP_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO        CE2    ON (CPD.TGT_EMP_ID  = CE2.EMP_REF_ID)
                                    JOIN            COM_DEPT_INFO       EDI    ON (CPD.TGT_DEPT_ID = EDI.DEPT_REF_ID)
                                WHERE	(CPD.COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
	                                AND	(CPD.EST_ID			= @EST_ID			OR @EST_ID			    =''    )
	                                AND	(CPD.ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
	                                AND	(CPD.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
                                    AND	(CPD.ESTTERM_STEP_ID= @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID	= 0)
	                                AND	(CPD.CTRL_EMP_ID	= @CTRL_EMP_ID		OR @CTRL_EMP_ID		= 0)
                                    AND	(CPD.TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
	                                AND	(CPD.TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
	                                AND	(CPD.CTRL_SEQ		= @CTRL_SEQ			OR @CTRL_SEQ		= 0)
                                ORDER BY CPD.CTRL_SEQ";

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
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "CTRLPOINTDATAGET" , null, paramArray, CommandType.Text);
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
                        , float ctrl_point
                        , string ctrl_opinion
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_CTRL_POINT_DATA(COMP_ID
								                            ,EST_ID
								                            ,ESTTERM_REF_ID
								                            ,ESTTERM_SUB_ID
                                                            ,ESTTERM_STEP_ID
								                            ,CTRL_EMP_ID
                                                            ,TGT_DEPT_ID
								                            ,TGT_EMP_ID
								                            ,CTRL_SEQ
								                            ,CTRL_POINT
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
								                            ,@CTRL_POINT
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
	        paramArray[9] 		= CreateDataParameter("@CTRL_POINT", SqlDbType.Float);
	        paramArray[9].Value = ctrl_point;
            paramArray[10] 		= CreateDataParameter("@CTRL_OPINION", SqlDbType.NVarChar);
	        paramArray[10].Value= ctrl_opinion;
	        paramArray[11] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[11].Value= create_date;
	        paramArray[12] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[12].Value= create_user;
         
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
            string query = @"DELETE	EST_CTRL_POINT_DATA
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
            string query = @"SELECT COUNT(*) FROM EST_CTRL_POINT_DATA
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
