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
    public class Dac_OuterDataProcInfos : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , string proc_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_OUTER_DATA_PROC_INFO
	                            SET	 PROC_NAME		= @PROC_NAME
		                            ,UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	COMP_ID		= @COMP_ID
		                            AND	EST_ID		= @EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@PROC_NAME", SqlDbType.NVarChar, 2000);
	        paramArray[2].Value = proc_name;
	        paramArray[3] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = update_date;
	        paramArray[4] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[4].Value = update_user;
         
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
         
        public DataSet Select(int comp_id, string est_id)
        {
            string query = @"SELECT	 COMP_ID
	                                ,EST_ID
	                                ,PROC_NAME
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_OUTER_DATA_PROC_INFO 
	                                WHERE	(COMP_ID	= @COMP_ID	OR @COMP_ID = 0)
		                                AND	(EST_ID		= @EST_ID	OR @EST_ID	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "OUTERDATAPROCINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , string proc_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_OUTER_DATA_PROC_INFO(COMP_ID
		                                                        ,EST_ID
		                                                        ,PROC_NAME
		                                                        ,CREATE_DATE
		                                                        ,CREATE_USER
		                                                        ,UPDATE_DATE
		                                                        ,UPDATE_USER
		                                                        )
	                                                        VALUES	(@COMP_ID
		                                                        ,@EST_ID
		                                                        ,@PROC_NAME
		                                                        ,@CREATE_DATE
		                                                        ,@CREATE_USER
		                                                        ,NULL
		                                                        ,NULL
		                                                        )";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@PROC_NAME", SqlDbType.NVarChar, 2000);
	        paramArray[2].Value = proc_name;
	        paramArray[3] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = create_date;
	        paramArray[4] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[4].Value = create_user;
         
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
                        , string est_id)
        {
            string query = @"DELETE	EST_OUTER_DATA_PROC_INFO
	                            WHERE	COMP_ID = @COMP_ID
		                            AND	EST_ID	= @EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
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

        public int GetData(   int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string proc_name)
        {
            string query = proc_name;

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@iCOMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@iEST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@iESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@iESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.StoredProcedure);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
