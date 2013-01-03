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
    public class Dac_BiasTypes : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string bias_type_id
                        , string bias_type_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_BIAS_TYPE
		                        SET	 BIAS_TYPE_NAME  = @BIAS_TYPE_NAME
			                        ,UPDATE_DATE     = @UPDATE_DATE
			                        ,UPDATE_USER     = @UPDATE_USER
		                        WHERE	BIAS_TYPE_ID = @BIAS_TYPE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = bias_type_id;
            paramArray[1]       = CreateDataParameter("@BIAS_TYPE_NAME", SqlDbType.NVarChar, 200);
            paramArray[1].Value = bias_type_name;
            paramArray[2]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = update_date;
            paramArray[3]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[3].Value = update_user;

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

        public DataSet Select(string bias_type_id)
        {
            string query = @"SELECT	 BIAS_TYPE_ID
		                            ,BIAS_TYPE_NAME
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
                            FROM	EST_BIAS_TYPE 
                                WHERE	(BIAS_TYPE_ID = @BIAS_TYPE_ID OR @BIAS_TYPE_ID       =''     )
                            ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = bias_type_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "COLUMNSTYLEGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string bias_type_id
                        , string bias_type_name
                        , DateTime create_date
                        , int create_user)
        {

            string query = @"INSERT INTO EST_BIAS_TYPE(BIAS_TYPE_ID
		                                                ,BIAS_TYPE_NAME
		                                                ,CREATE_DATE
		                                                ,CREATE_USER
		                                                ,UPDATE_DATE
		                                                ,UPDATE_USER
		                                                )
	                                                VALUES	(@BIAS_TYPE_ID
		                                                ,@BIAS_TYPE_NAME
		                                                ,@CREATE_DATE
		                                                ,@CREATE_USER
		                                                ,NULL
		                                                ,NULL
		                                                )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = bias_type_id;
            paramArray[1]       = CreateDataParameter("@BIAS_TYPE_NAME", SqlDbType.NVarChar, 200);
            paramArray[1].Value = bias_type_name;
            paramArray[2]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = create_date;
            paramArray[3]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user;

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
                        , string bias_type_id)
        {
            string query = @"DELETE	EST_BIAS_TYPE
                            	WHERE	BIAS_TYPE_ID = @BIAS_TYPE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = bias_type_id;

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

        public int Count(string bias_type_id)
        {
            string query = @"SELECT	COUNT(BIAS_TYPE_ID) 
		                        FROM	EST_BIAS_TYPE 
                                    WHERE	(BIAS_TYPE_ID = @BIAS_TYPE_ID OR @BIAS_TYPE_ID       =''   )";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = bias_type_id;

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