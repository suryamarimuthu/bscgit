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
    public class Dac_JobColumnMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , string est_job_id
                        , string col_key
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_JOB_COLUMN_MAP
	                            SET	 UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	COMP_ID     = @COMP_ID
                                    AND EST_ID		= @EST_ID
		                            AND	EST_JOB_ID	= @EST_JOB_ID
                                    AND COL_KEY     = @COL_KEY";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
            paramArray[3] 		= CreateDataParameter("@COL_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = col_key;
	        paramArray[4] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = update_date;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[5].Value = update_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public DataSet Select(int comp_id
                            , string est_id
                            , string est_job_id
                            , string col_key)
        {
            string query = @"SELECT	 EJE.COMP_ID
                                    ,EJE.EST_ID
		                            ,EJE.EST_JOB_ID
                                    ,EJI.EST_JOB_NAME
                                    ,EJE.COL_KEY
		                            ,EJE.CREATE_DATE
		                            ,EJE.CREATE_USER
		                            ,EJE.UPDATE_DATE
		                            ,EJE.UPDATE_USER
	                            FROM	 EST_JOB_COLUMN_MAP EJE
                                    JOIN EST_JOB_INFO       EJI  ON (EJE.EST_JOB_ID = EJI.EST_JOB_ID)
		                            WHERE	(EJE.COMP_ID	= @COMP_ID		OR @COMP_ID		= 0 )
                                        AND (EJE.EST_ID		= @EST_ID		OR @EST_ID		='' )
			                            AND	(EJE.EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	='' )
                                        AND	(EJE.COL_KEY	= @COL_KEY	    OR @COL_KEY	    ='' )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
            paramArray[3] 		= CreateDataParameter("@COL_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = col_key;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "JOBESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectNotIn(int comp_id
                                , string est_id
                                , string est_job_id
                                , string col_key)
        {
            string query = @"SELECT	 EJE.COMP_ID
                                    ,EJE.EST_ID
		                            ,EJE.EST_JOB_ID
                                    ,EJI.EST_JOB_NAME
                                    ,EJE.COL_KEY
		                            ,EJE.CREATE_DATE
		                            ,EJE.CREATE_USER
		                            ,EJE.UPDATE_DATE
		                            ,EJE.UPDATE_USER
	                            FROM	 EST_JOB_COLUMN_MAP EJE
                                    JOIN EST_JOB_INFO       EJI  ON (EJE.EST_JOB_ID = EJI.EST_JOB_ID)l
	                            WHERE	(EJE.COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                    AND (EJE.EST_ID		= @EST_ID		OR @EST_ID		=''    )
		                            AND	(EJE.EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	=''    )
                                    AND	(EJE.COL_KEY	= @COL_KEY	    OR @COL_KEY	    =''    )
                                    AND EJE.EST_JOB_ID NOT IN (SELECT EST_JOB_ID FROM EST_JOB_COLUMN_MAP
                                                                WHERE   (EJE.COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                                                    AND (EJE.EST_ID		= @EST_ID		OR @EST_ID		=''    )
                                                                    AND	(EJE.COL_KEY	= @COL_KEY	    OR @COL_KEY	    =''    ))";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
            paramArray[3] 		= CreateDataParameter("@COL_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = col_key;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "JOBESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , string est_job_id
                        , string col_key
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_JOB_COLUMN_MAP(COMP_ID
                                                        ,EST_ID
							                            ,EST_JOB_ID
                                                        ,COL_KEY
							                            ,CREATE_DATE
							                            ,CREATE_USER
							                            ,UPDATE_DATE
							                            ,UPDATE_USER
							                            )
						                            VALUES	(@COMP_ID
                                                        ,@EST_ID
							                            ,@EST_JOB_ID
                                                        ,@COL_KEY
							                            ,@CREATE_DATE
							                            ,@CREATE_USER
							                            ,NULL
							                            ,NULL
							                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
            paramArray[3] 		= CreateDataParameter("@COL_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = col_key;
	        paramArray[4] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = create_date;
	        paramArray[5] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[5].Value = create_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
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
                        , string est_job_id
                        , string col_key)
        {
            string query = @"DELETE	EST_JOB_COLUMN_MAP
	                            WHERE	(COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                    AND (EST_ID		= @EST_ID		OR @EST_ID		=''    )
		                            AND	(EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	=''    )
                                    AND	(COL_KEY	= @COL_KEY	    OR @COL_KEY	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
            paramArray[3] 		= CreateDataParameter("@COL_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = col_key;
         
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
                        , string est_job_id
                        , string col_key)
        {
            string query = @"SELECT	 COUNT(*)
	                            FROM	EST_JOB_COLUMN_MAP 
		                            WHERE	(COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                        AND (EST_ID		= @EST_ID		OR @EST_ID		=''    )
			                            AND	(EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	=''    )
                                        AND	(COL_KEY	= @COL_KEY	    OR @COL_KEY	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
            paramArray[3] 		= CreateDataParameter("@COL_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = col_key;
         
	        return Convert.ToInt32(DbAgentObj.ExecuteScalar(query , paramArray, CommandType.Text).ToString());
        }
    }
}
