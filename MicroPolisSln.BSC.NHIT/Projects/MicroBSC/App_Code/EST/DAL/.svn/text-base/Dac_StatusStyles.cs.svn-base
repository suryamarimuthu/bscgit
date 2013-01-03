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
	public class Dac_StatusStyles : DbAgentBase
	{
		public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , string status_style_id
						, string status_style_name
						, string status_style_desc
						, DateTime update_date
						, int update_user )
		{
			string query = @"UPDATE	EST_STATUS_STYLE
                                SET	 STATUS_STYLE_NAME		= @STATUS_STYLE_NAME
                                    ,STATUS_STYLE_DESC	    = @STATUS_STYLE_DESC
                                    ,UPDATE_DATE	= @UPDATE_DATE
                                    ,UPDATE_USER	= @UPDATE_USER
                                WHERE STATUS_STYLE_ID      = @STATUS_STYLE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(5);
		 
			paramArray[0] 		= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar );
			paramArray[0].Value = status_style_id;
			paramArray[1] 		= CreateDataParameter( "@STATUS_STYLE_NAME", SqlDbType.NVarChar );
			paramArray[1].Value = status_style_name;
			paramArray[2] 		= CreateDataParameter( "@STATUS_STYLE_DESC", SqlDbType.NVarChar );
			paramArray[2].Value = status_style_desc;
			paramArray[3] 		= CreateDataParameter( "@UPDATE_DATE", SqlDbType.DateTime );
			paramArray[3].Value = update_date;
			paramArray[4] 		= CreateDataParameter( "@UPDATE_USER", SqlDbType.Int );
			paramArray[4].Value = update_user;

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

		public DataSet Select(string status_style_id)
		{
			string query = @"SELECT  STATUS_STYLE_ID
									,STATUS_STYLE_NAME
									,STATUS_STYLE_DESC
									,CREATE_DATE
									,CREATE_USER
									,UPDATE_DATE
									,UPDATE_USER 
                                FROM EST_STATUS_STYLE
                                    WHERE (STATUS_STYLE_ID = @STATUS_STYLE_ID OR @STATUS_STYLE_ID     =''    )";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
			paramArray[0] 		= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar);
			paramArray[0].Value = status_style_id;
                 
	        DataSet ds = DbAgentObj.FillDataSet( query, "STATUS_STYLE" , null, paramArray, CommandType.Text );

	        return ds;
		}

		public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object status_style_id
						, object status_style_name
						, object status_style_desc
						, object create_date
						, object create_user)
		{
			string query = @"INSERT INTO EST_STATUS_STYLE(  STATUS_STYLE_ID
													,STATUS_STYLE_NAME
													,STATUS_STYLE_DESC
													,CREATE_DATE
													,CREATE_USER
													)
											VALUES	(@STATUS_STYLE_ID
													,@STATUS_STYLE_NAME
													,@STATUS_STYLE_DESC
													,@CREATE_DATE
													,@CREATE_USER
													)";

			IDbDataParameter[] paramArray = CreateDataParameters(5);
		 
			paramArray[0] 		= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar );
			paramArray[0].Value = status_style_id;
			paramArray[1] 		= CreateDataParameter( "@STATUS_STYLE_NAME", SqlDbType.NVarChar );
			paramArray[1].Value = status_style_name;
			paramArray[2] 		= CreateDataParameter( "@STATUS_STYLE_DESC", SqlDbType.NVarChar );
			paramArray[2].Value = status_style_desc;
			paramArray[3] 		= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
			paramArray[3].Value	= create_date;
			paramArray[4] 		= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
			paramArray[4].Value	= create_user; 
		 
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

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string status_style_id )
        {
            string query = @"DELETE	EST_STATUS_STYLE
							    WHERE	STATUS_STYLE_ID = @STATUS_STYLE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
			paramArray[0] 			= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar );
			paramArray[0].Value 	= status_style_id;
		 
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

        public int Count(string status_style_id)
        {
            string query = @"SELECT COUNT(STATUS_STYLE_ID) FROM EST_STATUS_STYLE
							    WHERE	STATUS_STYLE_ID = @STATUS_STYLE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@STATUS_STYLE_ID", SqlDbType.NVarChar);
            paramArray[0].Value = status_style_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}