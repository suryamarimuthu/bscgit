
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
	public class Dac_ScheInfos : DbAgentBase
	{
		public int Update( IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
						, string est_sche_id
						, object up_est_sche_id
						, string est_sche_name
						, string est_sche_desc
						, int sort_order
						, string est_id
						, DateTime update_date
						, int update_user)
		{
			string query = @"UPDATE	EST_SCHE_INFO
                                SET	 UP_EST_SCHE_ID = @UP_EST_SCHE_ID
                                    ,EST_SCHE_NAME  = @EST_SCHE_NAME
                                    ,EST_SCHE_DESC  = @EST_SCHE_DESC
                                    ,SORT_ORDER     = @SORT_ORDER
                                    ,EST_ID         = @EST_ID
                                    ,UPDATE_DATE    = @UPDATE_DATE
                                    ,UPDATE_USER    = @UPDATE_USER
                                WHERE	COMP_ID     = @COMP_ID
                                    AND EST_SCHE_ID = @EST_SCHE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(9);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int );
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar );
			paramArray[1].Value = est_sche_id;
			paramArray[2] 		= CreateDataParameter("@UP_EST_SCHE_ID", SqlDbType.NVarChar );
			paramArray[2].Value = ( up_est_sche_id.Equals( string.Empty ) ) ? DBNull.Value : up_est_sche_id;
			paramArray[3] 		= CreateDataParameter("@EST_SCHE_NAME", SqlDbType.NVarChar );
			paramArray[3].Value = est_sche_name;
			paramArray[4] 		= CreateDataParameter("@EST_SCHE_DESC", SqlDbType.NVarChar );
			paramArray[4].Value = est_sche_desc;
			paramArray[5] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.Int );
			paramArray[5].Value = sort_order;
			paramArray[6] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar );
			paramArray[6].Value = est_id;
			paramArray[7] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime );
			paramArray[7].Value = update_date;
			paramArray[8] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int );
			paramArray[8].Value = update_user;

			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
        }

		public DataSet Select(int comp_id, string est_sche_id )
		{
			string query = @"SELECT	 COMP_ID
                                    ,EST_SCHE_ID	
									,UP_EST_SCHE_ID	
                                    ,''             AS UP_EST_SCHE_NAME
									,EST_SCHE_NAME	
									,EST_SCHE_DESC	
									,SORT_ORDER
									,EST_ID	
									,CREATE_DATE	
									,CREATE_USER	
									,UPDATE_DATE	
									,UPDATE_USER
							FROM	 EST_SCHE_INFO A 
							        WHERE	(COMP_ID      = @COMP_ID      OR @COMP_ID     = 0)
                                        AND (EST_SCHE_ID  = @EST_SCHE_ID  OR @EST_SCHE_ID     =''    )";

			IDbDataParameter[] paramArray = CreateDataParameters(2);
		 
            paramArray[0] 			= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value 	= comp_id;
			paramArray[1] 			= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20 );
			paramArray[1].Value 	= est_sche_id;

	        DataSet ds = DbAgentObj.FillDataSet( query, "SCHEINFO" , null, paramArray, CommandType.Text );

	        return ds;
		}


		public int Insert( IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
						, string est_sche_id
						, object up_est_sche_id
						, string est_sche_name
						, string est_sche_desc
						, int sort_order
						, string est_id
						, DateTime create_date
						, int create_user)
		{
			string query = @"INSERT INTO EST_SCHE_INFO(COMP_ID
                                                    ,EST_SCHE_ID
													,UP_EST_SCHE_ID
													,EST_SCHE_NAME
													,EST_SCHE_DESC
													,SORT_ORDER
													,EST_ID
													,CREATE_DATE
													,CREATE_USER
													)
											 VALUES	(@COMP_ID
                                                    ,@EST_SCHE_ID
													,@UP_EST_SCHE_ID
													,@EST_SCHE_NAME
													,@EST_SCHE_DESC
													,@SORT_ORDER
													,@EST_ID
													,@CREATE_DATE
													,@CREATE_USER
													)";

			IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]		= CreateDataParameter( "@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1]		= CreateDataParameter( "@EST_SCHE_ID", SqlDbType.NVarChar, 20 );
			paramArray[1].Value = est_sche_id;
			paramArray[2]		= CreateDataParameter( "@UP_EST_SCHE_ID", SqlDbType.NVarChar, 20 );
			paramArray[2].Value = ( up_est_sche_id.Equals( string.Empty ) ) ? DBNull.Value : up_est_sche_id;
			paramArray[3]		= CreateDataParameter( "@EST_SCHE_NAME", SqlDbType.NVarChar, 100 );
			paramArray[3].Value = est_sche_name;
			paramArray[4]		= CreateDataParameter( "@EST_SCHE_DESC", SqlDbType.NVarChar, 1000 );
			paramArray[4].Value = est_sche_desc;
			paramArray[5]		= CreateDataParameter( "@SORT_ORDER", SqlDbType.Int );
			paramArray[5].Value = sort_order;
			paramArray[6]		= CreateDataParameter( "@EST_ID", SqlDbType.NVarChar );
			paramArray[6].Value = est_id;
			paramArray[7]		= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
			paramArray[7].Value = create_date;
			paramArray[8]		= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
			paramArray[8].Value = create_user;

			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
				return affectedRow;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

        public int Delete( IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
						, string est_sche_id )
        {
            string query = @"DELETE	EST_SCHE_INFO
							    WHERE	COMP_ID     = @COMP_ID
                                    AND EST_SCHE_ID = @EST_SCHE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20 );
			paramArray[1].Value = est_sche_id;
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
				return affectedRow;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
        }

        public int Count(int comp_id, string est_sche_id )
		{
			string query = @"SELECT	COUNT(*)
							    FROM EST_SCHE_INFO 
							        WHERE   (COMP_ID        = @COMP_ID      OR @COMP_ID     = 0)
                                        AND (EST_SCHE_ID    = @EST_SCHE_ID  OR @EST_SCHE_ID     =''    )";

			IDbDataParameter[] paramArray = CreateDataParameters(2);
		 
            paramArray[0] 		    = CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value     = comp_id;
			paramArray[1] 			= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20 );
			paramArray[1].Value 	= est_sche_id;

	        return Convert.ToInt32(DbAgentObj.ExecuteScalar( query, paramArray, CommandType.Text ).ToString());
		}
	}
}