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
    public class Dac_DeptOpinionTgtEmps : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , string tgt_opinion_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_DEPT_OPINION_TGT_EMP
	                            SET	 TGT_OPINION_YN = @TGT_OPINION_YN
		                            ,UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	COMP_ID		= @COMP_ID
		                            AND	EST_ID		= @EST_ID
		                            AND	TGT_DEPT_ID = @TGT_DEPT_ID
		                            AND	TGT_EMP_ID	= @TGT_EMP_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value 	= comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 100);
	        paramArray[1].Value 	= est_id;
	        paramArray[2] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[2].Value 	= tgt_dept_id;
	        paramArray[3] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[3].Value 	= tgt_emp_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_OPINION_YN", SqlDbType.NChar);
	        paramArray[4].Value 	= tgt_opinion_yn;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[5].Value 	= update_date;
	        paramArray[6] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[6].Value 	= update_user;
         
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
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , string tgt_opinion_yn)
        {
            string query = @"SELECT	 OE.COMP_ID
		                            ,OE.EST_ID
		                            ,OE.TGT_DEPT_ID
                                    ,CD.DEPT_NAME       AS TGT_DEPT_NAME
		                            ,OE.TGT_EMP_ID
                                    ,EI.EMP_NAME        AS TGT_EMP_NAME
		                            ,OE.TGT_OPINION_YN
		                            ,OE.CREATE_DATE
		                            ,OE.CREATE_USER
		                            ,OE.UPDATE_DATE
		                            ,OE.UPDATE_USER
	                            FROM	 EST_DEPT_OPINION_TGT_EMP   OE
                                    JOIN COM_DEPT_INFO              CD ON (OE.TGT_DEPT_ID   = CD.DEPT_REF_ID)
                                    JOIN COM_EMP_INFO               EI ON (OE.TGT_EMP_ID    = EI.EMP_REF_ID)
                                WHERE	(OE.COMP_ID		    = @COMP_ID			OR @COMP_ID			= 0)
	                                AND	(OE.EST_ID			= @EST_ID			OR @EST_ID			='')
	                                AND	(OE.TGT_DEPT_ID	    = @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
	                                AND	(OE.TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)
	                                AND (OE.TGT_OPINION_YN  = @TGT_OPINION_YN	OR @TGT_OPINION_YN	='')";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 100);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[2].Value = tgt_dept_id;
	        paramArray[3] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[3].Value = tgt_emp_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_OPINION_YN", SqlDbType.NChar);
	        paramArray[4].Value = tgt_opinion_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "DEPTOPINIONTGTEMPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int tgt_dept_id
                        , int tgt_emp_id
                        , string tgt_opinion_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_DEPT_OPINION_TGT_EMP(COMP_ID
								                                ,EST_ID
								                                ,TGT_DEPT_ID
								                                ,TGT_EMP_ID
								                                ,TGT_OPINION_YN
								                                ,CREATE_DATE
								                                ,CREATE_USER
								                                ,UPDATE_DATE
								                                ,UPDATE_USER
								                                )
							                                VALUES	(@COMP_ID
								                                ,@EST_ID
								                                ,@TGT_DEPT_ID
								                                ,@TGT_EMP_ID
								                                ,@TGT_OPINION_YN
								                                ,@CREATE_DATE
								                                ,@CREATE_USER
								                                ,NULL
								                                ,NULL
								                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 100);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[2].Value = tgt_dept_id;
	        paramArray[3] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[3].Value = tgt_emp_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_OPINION_YN", SqlDbType.NChar);
	        paramArray[4].Value = tgt_opinion_yn;
	        paramArray[5] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[5].Value = create_date;
	        paramArray[6] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[6].Value = create_user;
         
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
                        , int tgt_dept_id
                        , int tgt_emp_id)
        {
            string query = @"DELETE	EST_DEPT_OPINION_TGT_EMP
	                            WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
	                                AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
	                                AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
	                                AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 100);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[2].Value = tgt_dept_id;
	        paramArray[3] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[3].Value = tgt_emp_id;
         
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
    }
}
