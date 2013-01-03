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
    public class Dac_ReportItems : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string rpt_itm_id
                        , string prt_itm_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_REPORT_ITEM
	                            SET	 PRT_ITM_NAME   = @PRT_ITM_NAME
		                            ,UPDATE_DATE    = @UPDATE_DATE
		                            ,UPDATE_USER    = @UPDATE_USER
	                            WHERE	RPT_ITM_ID  = @RPT_ITM_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_ITM_ID", SqlDbType.NVarChar, 120);
	        paramArray[0].Value = rpt_itm_id;
	        paramArray[1] 		= CreateDataParameter("@PRT_ITM_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = prt_itm_name;
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
         
        public DataSet Select( string rpt_itm_id)
        {
            string query = @"SELECT	 RPT_ITM_ID
		                            ,PRT_ITM_NAME
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_REPORT_ITEM 
		                            WHERE	(RPT_ITM_ID = @RPT_ITM_ID OR @RPT_ITM_ID     =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_ITM_ID", SqlDbType.NVarChar, 120);
	        paramArray[0].Value = rpt_itm_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "REPORTITEMGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string rpt_itm_id
                        , string prt_itm_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_REPORT_ITEM(RPT_ITM_ID
							                            ,PRT_ITM_NAME
							                            ,CREATE_DATE
							                            ,CREATE_USER
							                            ,UPDATE_DATE
							                            ,UPDATE_USER
							                            )
						                            VALUES	(@RPT_ITM_ID
							                            ,@PRT_ITM_NAME
							                            ,@CREATE_DATE
							                            ,@CREATE_USER
							                            ,NULL
							                            ,NULL
							                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_ITM_ID", SqlDbType.NVarChar, 120);
	        paramArray[0].Value = rpt_itm_id;
	        paramArray[1] 		= CreateDataParameter("@PRT_ITM_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = prt_itm_name;
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
                        , string rpt_itm_id)
        {
            string query = @"DELETE	EST_REPORT_ITEM
	                            WHERE	RPT_ITM_ID = @RPT_ITM_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_ITM_ID", SqlDbType.NVarChar, 120);
	        paramArray[0].Value = rpt_itm_id;
         
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
