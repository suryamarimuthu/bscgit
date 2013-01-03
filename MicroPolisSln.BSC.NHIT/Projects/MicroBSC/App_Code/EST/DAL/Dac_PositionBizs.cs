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
    public class Dac_PositionBizs : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string pos_biz_id
                        , string pos_biz_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_POSITION_BIZ
	                            SET	 POS_BIZ_NAME	= @POS_BIZ_NAME
		                            ,UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	POS_BIZ_ID	= @POS_BIZ_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 12);
	        paramArray[0].Value = pos_biz_id;
	        paramArray[1] 		= CreateDataParameter("@POS_BIZ_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = pos_biz_name;
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
         
        public DataSet Select( string pos_biz_id)
        {
            string query = @"SELECT	 POS_BIZ_ID
		                            ,POS_BIZ_NAME
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_POSITION_BIZ 
		                            WHERE	(POS_BIZ_ID = @POS_BIZ_ID OR @POS_BIZ_ID     =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 12);
	        paramArray[0].Value = pos_biz_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "POSITIONBIZGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string pos_biz_id
                        , string pos_biz_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_POSITION_BIZ(POS_BIZ_ID
		                                                ,POS_BIZ_NAME
		                                                ,CREATE_DATE
		                                                ,CREATE_USER
		                                                ,UPDATE_DATE
		                                                ,UPDATE_USER
		                                                )
	                                                VALUES	(@POS_BIZ_ID
		                                                ,@POS_BIZ_NAME
		                                                ,@CREATE_DATE
		                                                ,@CREATE_USER
		                                                ,NULL
		                                                ,NULL
		                                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 12);
	        paramArray[0].Value = pos_biz_id;
	        paramArray[1] 		= CreateDataParameter("@POS_BIZ_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = pos_biz_name;
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
                        , string pos_biz_id)
        {
            string query = @"DELETE	EST_POSITION_BIZ
	                            WHERE	POS_BIZ_ID = @POS_BIZ_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 12);
	        paramArray[0].Value = pos_biz_id;
         
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
