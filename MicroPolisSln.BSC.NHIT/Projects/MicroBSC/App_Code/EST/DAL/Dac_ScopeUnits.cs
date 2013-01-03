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
    public class Dac_ScopeUnits : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string scope_unit_id
                        , string scale_id
                        , string scope_unit_name
                        , string scope_unit_desc
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_SCOPE_UNIT
                                SET	SCALE_ID            = @SCALE_ID
                                    ,SCOPE_UNIT_NAME    = @SCOPE_UNIT_NAME
                                    ,SCOPE_UNIT_DESC    = @SCOPE_UNIT_DESC
                                    ,UPDATE_DATE        = @UPDATE_DATE
                                    ,UPDATE_USER        = @UPDATE_USER
                                WHERE	SCOPE_UNIT_ID   = @SCOPE_UNIT_ID";


            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
            paramArray[0].Value = scope_unit_id;
            paramArray[1]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = scale_id;
            paramArray[2]       = CreateDataParameter("@SCOPE_UNIT_NAME", SqlDbType.NVarChar, 200);
            paramArray[2].Value = scope_unit_name;
            paramArray[3]       = CreateDataParameter("@SCOPE_UNIT_DESC", SqlDbType.NVarChar, 2000);
            paramArray[3].Value = scope_unit_desc;
            paramArray[4]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[4].Value = update_date;
            paramArray[5]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[5].Value = update_user;

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

        public DataSet Select(string scope_unit_id)
        {
            string query = @"SELECT	 SCOPE_UNIT_ID
	                                ,SCALE_ID
	                                ,SCOPE_UNIT_NAME
	                                ,SCOPE_UNIT_DESC
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_SCOPE_UNIT 
                                    WHERE	(SCOPE_UNIT_ID = @SCOPE_UNIT_ID OR @SCOPE_UNIT_ID ='')";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
            paramArray[0].Value = scope_unit_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "SCOPEUNITGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectByScaleID(string scale_id)
        {
            string query = @"SELECT	 SCOPE_UNIT_ID
	                                ,SCALE_ID
	                                ,SCOPE_UNIT_NAME
	                                ,SCOPE_UNIT_DESC
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_SCOPE_UNIT 
                                    WHERE	(SCALE_ID = @SCALE_ID OR @SCALE_ID ='')";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 6);
            paramArray[0].Value = scale_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "SCOPEUNITGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string scope_unit_id
                        , string scale_id
                        , string scope_unit_name
                        , string scope_unit_desc
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_SCOPE_UNIT(SCOPE_UNIT_ID
			                                            ,SCALE_ID
			                                            ,SCOPE_UNIT_NAME
			                                            ,SCOPE_UNIT_DESC
			                                            ,CREATE_DATE
			                                            ,CREATE_USER
			                                            ,UPDATE_DATE
			                                            ,UPDATE_USER
			                                            )
		                                            VALUES	(@SCOPE_UNIT_ID
			                                            ,@SCALE_ID
			                                            ,@SCOPE_UNIT_NAME
			                                            ,@SCOPE_UNIT_DESC
			                                            ,@CREATE_DATE
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
            paramArray[0].Value = scope_unit_id;
            paramArray[1]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = scale_id;
            paramArray[2]       = CreateDataParameter("@SCOPE_UNIT_NAME", SqlDbType.NVarChar, 200);
            paramArray[2].Value = scope_unit_name;
            paramArray[3]       = CreateDataParameter("@SCOPE_UNIT_DESC", SqlDbType.NVarChar, 2000);
            paramArray[3].Value = scope_unit_desc;
            paramArray[4]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[4].Value = create_date;
            paramArray[5]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[5].Value = create_user;

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
                        , string scope_unit_id)
        {
            string query = @"DELETE	EST_SCOPE_UNIT
                                WHERE	SCOPE_UNIT_ID = @SCOPE_UNIT_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
            paramArray[0].Value = scope_unit_id;

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

        public int Count(string scope_unit_id)
        {
            string query = @"SELECT COUNT(SCOPE_UNIT_ID) FROM EST_SCOPE_UNIT
                                WHERE	SCOPE_UNIT_ID = @SCOPE_UNIT_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 6);
            paramArray[0].Value = scope_unit_id;

            try
            {
              int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
