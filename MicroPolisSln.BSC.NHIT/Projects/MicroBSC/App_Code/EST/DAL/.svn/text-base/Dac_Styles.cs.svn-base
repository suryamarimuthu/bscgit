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
    public class Dac_Styles : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string est_style_id
                        , string est_style_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_STYLE
	                            SET	 EST_STYLE_NAME	 = @EST_STYLE_NAME
		                            ,UPDATE_DATE	 = @UPDATE_DATE
		                            ,UPDATE_USER	 = @UPDATE_USER
	                            WHERE	EST_STYLE_ID = @EST_STYLE_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_style_id;
	        paramArray[1] 		= CreateDataParameter("@EST_STYLE_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = est_style_name;
	        paramArray[2] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[2].Value = update_date;
	        paramArray[3] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
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
         
        public DataSet Select( string est_style_id)
        {
            string query = @"SELECT	 EST_STYLE_ID
		                            ,EST_STYLE_NAME
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_STYLE 
		                            WHERE	(EST_STYLE_ID = @EST_STYLE_ID OR @EST_STYLE_ID     =''     )
                                ORDER BY SORT_ORDER";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_style_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "STYLEGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string est_style_id
                        , string est_style_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_STYLE(EST_STYLE_ID
			                                    ,EST_STYLE_NAME
			                                    ,CREATE_DATE
			                                    ,CREATE_USER
			                                    ,UPDATE_DATE
			                                    ,UPDATE_USER
			                                    )
		                                    VALUES	(@EST_STYLE_ID
			                                    ,@EST_STYLE_NAME
			                                    ,@CREATE_DATE
			                                    ,@CREATE_USER
			                                    ,NULL
			                                    ,NULL
			                                    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_style_id;
	        paramArray[1] 		= CreateDataParameter("@EST_STYLE_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = est_style_name;
	        paramArray[2] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[2].Value = create_date;
	        paramArray[3] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
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
                        , string est_style_id)
        {
            string query = @"DELETE	EST_STYLE
	                            WHERE	EST_STYLE_ID = @EST_STYLE_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_style_id;
         
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

        public int Count( string est_style_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_STYLE
	                            WHERE	(EST_STYLE_ID = @EST_STYLE_ID OR @EST_STYLE_ID     =''     )";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_style_id;
         
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
