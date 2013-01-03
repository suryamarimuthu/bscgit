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
	public class Dac_Positions : DbAgentBase
	{
		public int Update(IDbConnection conn
						, IDbTransaction trx
						, string strPosTableName
						, string strPos
						, string posID
						, string posName
						, DateTime update_date
						, int update_user )
		{
			string query =	string.Format( @"UPDATE {0}
									            SET	POS_{1}_NAME      = @POS_NAME
										            , UPDATE_DATE       = @UPDATE_DATE
										            , UPDATE_USER       = @UPDATE_USER
									                WHERE POS_{1}_ID    = @POS_ID", strPosTableName, strPos );

			IDbDataParameter[] paramArray = CreateDataParameters(4);

			paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
			paramArray[0].Value = posID;
			paramArray[1] 		= CreateDataParameter( "@POS_NAME", SqlDbType.NVarChar );
			paramArray[1].Value = posName;		 
			paramArray[2] 		= CreateDataParameter( "@UPDATE_DATE", SqlDbType.DateTime );
			paramArray[2].Value = update_date;
			paramArray[3] 		= CreateDataParameter( "@UPDATE_USER", SqlDbType.Int );
			paramArray[3].Value = update_user;

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

		public DataSet Select( string strPosTableName
							, string strPos
							, object posID )
		{
			string query = string.Format(@"SELECT '{1}' AS POS
												, POS_{1}_ID    AS POS_ID
												, POS_{1}_NAME  AS POS_NAME
												
									        FROM {0}
									            WHERE	(POS_{1}_ID = @POS_ID	OR @POS_ID		    =''    )", strPosTableName, strPos);

			IDbDataParameter[] paramArray = CreateDataParameters(1);

			paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
			paramArray[0].Value = posID;

	        DataSet ds = DbAgentObj.FillDataSet( query, "POSITIONSGET" , null, paramArray, CommandType.Text );
	        return ds;
		}

		public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string strPosTableName
						, string strPos
						, object posID
						, object posName
						, object create_date
						, object create_user)
		{
			string query = string.Format(@"INSERT INTO {0} ( POS_{1}_ID
															,POS_{1}_NAME
															,CREATE_DATE
															,CREATE_USER
															)
													VALUES	(@POS_ID
															,@POS_NAME
															,@CREATE_DATE
															,@CREATE_USER
															)", strPosTableName, strPos );

			IDbDataParameter[] paramArray = CreateDataParameters(4);

			paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
			paramArray[0].Value = posID;
			paramArray[1] 		= CreateDataParameter( "@POS_NAME", SqlDbType.NVarChar );
			paramArray[1].Value = posName;		 
			paramArray[2] 		= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
			paramArray[2].Value = create_date;
			paramArray[3] 		= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
			paramArray[3].Value = create_user;
		 
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
                        , string strPosTableName
						, string strPos
						, object posID )
        {
            string query = string.Format(@"DELETE {0}
									        WHERE POS_{1}_ID = @POS_ID", strPosTableName, strPos );

			IDbDataParameter[] paramArray = CreateDataParameters(1);

			paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
			paramArray[0].Value = posID;
		 
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

        public int Count( string strPosTableName
						, string strPos
						, string strPosID )
        {
            string query = string.Format(@"SELECT COUNT(*) FROM {0}
									        WHERE POS_{1}_ID = @POS_ID", strPosTableName, strPos );

            IDbDataParameter[] paramArray = CreateDataParameters(1);

			paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
			paramArray[0].Value = strPosID;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar( query, paramArray, CommandType.Text ).ToString());
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}