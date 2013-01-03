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
    public class Dac_ButtonCommandInfos : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string command_name
                        , string biz_type
                        , string command_desc
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_BUTTON_COMMAND_INFO
	                            SET	 BIZ_TYPE			= @BIZ_TYPE
		                            ,COMMAND_DESC		= @COMMAND_DESC
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMMAND_NAME	= @COMMAND_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar, 200);
	        paramArray[0].Value = command_name;
	        paramArray[1] 		= CreateDataParameter("@BIZ_TYPE", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = biz_type;
	        paramArray[2] 		= CreateDataParameter("@COMMAND_DESC", SqlDbType.NVarChar, 2000);
	        paramArray[2].Value = command_desc;
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
         
        public DataSet Select( string command_name, string biz_type)
        {
            string query = @"SELECT	 COMMAND_NAME
		                            ,BIZ_TYPE
		                            ,COMMAND_DESC
                                    ,BUTTON_NAME
                                    ,SORT_ORDER
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_BUTTON_COMMAND_INFO 
		                            WHERE	(COMMAND_NAME	= @COMMAND_NAME OR @COMMAND_NAME	    =''    )
			                            AND (BIZ_TYPE		= @BIZ_TYPE		OR @BIZ_TYPE		    =''    )
                                    ORDER BY SORT_ORDER";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar, 200);
	        paramArray[0].Value = command_name;
	        paramArray[1] 		= CreateDataParameter("@BIZ_TYPE", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = biz_type;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "BUTTONCOMMANDINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string command_name
                        , string biz_type
                        , string command_desc
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_BUTTON_COMMAND_INFO(COMMAND_NAME
								                                ,BIZ_TYPE
								                                ,COMMAND_DESC
								                                ,CREATE_DATE
								                                ,CREATE_USER
								                                ,UPDATE_DATE
								                                ,UPDATE_USER
								                                )
							                                VALUES	(@COMMAND_NAME
								                                ,@BIZ_TYPE
								                                ,@COMMAND_DESC
								                                ,@CREATE_DATE
								                                ,@CREATE_USER
								                                ,NULL
								                                ,NULL
								                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar, 200);
	        paramArray[0].Value = command_name;
	        paramArray[1] 		= CreateDataParameter("@BIZ_TYPE", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = biz_type;
	        paramArray[2] 		= CreateDataParameter("@COMMAND_DESC", SqlDbType.NVarChar, 2000);
	        paramArray[2].Value = command_desc;
	        paramArray[3] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = create_date;
	        paramArray[4] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[4].Value = create_user;
         
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
                        , string command_name)
        {
            string query = @"DELETE	EST_BUTTON_COMMAND_INFO
	                            WHERE	COMMAND_NAME = @COMMAND_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar, 200);
	        paramArray[0].Value = command_name;
         
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
    }
}
