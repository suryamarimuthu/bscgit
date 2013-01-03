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
    public class Dac_BoardCategories : DbAgentBase
    {
    	public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string board_category_id
                        , string board_categroy_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_BOARD_CATEGORY
	                            SET	BOARD_CATEGROY_NAME		= @BOARD_CATEGROY_NAME
		                            ,UPDATE_DATE			= @UPDATE_DATE
		                            ,UPDATE_USER			= @UPDATE_USER
	                            WHERE	BOARD_CATEGORY_ID	= @BOARD_CATEGORY_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_category_id;
	        paramArray[1] 		= CreateDataParameter("@BOARD_CATEGROY_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = board_categroy_name;
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
         
        public DataSet Select(string board_category_id)
        {
            string query = @"SELECT	 BOARD_CATEGORY_ID
		                            ,BOARD_CATEGROY_NAME
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_BOARD_CATEGORY 
		                            WHERE	(BOARD_CATEGORY_ID = @BOARD_CATEGORY_ID OR @BOARD_CATEGORY_ID     =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_category_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "BOARDCATEGORYGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string board_category_id
                        , string board_categroy_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_BOARD_CATEGORY(BOARD_CATEGORY_ID
			                                                ,BOARD_CATEGROY_NAME
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@BOARD_CATEGORY_ID
			                                                ,@BOARD_CATEGROY_NAME
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_category_id;
	        paramArray[1] 		= CreateDataParameter("@BOARD_CATEGROY_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = board_categroy_name;
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
                        , string board_category_id)
        {
            string query = @"DELETE	EST_BOARD_CATEGORY
	                            WHERE BOARD_CATEGORY_ID = @BOARD_CATEGORY_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_category_id;
         
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
