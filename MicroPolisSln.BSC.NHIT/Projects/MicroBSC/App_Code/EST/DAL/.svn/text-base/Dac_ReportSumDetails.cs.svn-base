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
    public class Dac_ReportSumDetails : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string est_id
                        , int sort_order
                        , string use_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_REPORT_SUM_DETAIL
	                            SET	 SORT_ORDER			= @SORT_ORDER
		                            ,USE_YN				= @USE_YN
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		                            AND	EST_ID			= @EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = estterm_ref_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
	        paramArray[4].Value = sort_order;
	        paramArray[5] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[5].Value = use_yn;
	        paramArray[6] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[6].Value = update_date;
	        paramArray[7] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[7].Value = update_user;
         
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
         
        public DataSet Select(int comp_id
                            , int estterm_ref_id
                            , int estterm_sub_id)
        {
            string query = @"SELECT	 COMP_ID
		                            ,ESTTERM_REF_ID
		                            ,ESTTERM_SUB_ID
                                    ,ESTTERM_STEP_ID
		                            ,EST_ID
                                    ,YEAR_YN
                                    ,MERGE_YN
                                    ,OWNER_TYPE
                                    ,TITLE_IMG_URL
                                    ,TITLE_NAME
		                            ,SORT_ORDER
		                            ,USE_YN
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_REPORT_SUM_DETAIL 
	                                WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
		                                AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
		                                AND	(ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID	= 0)
		                                --AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                                AND USE_YN			= 'Y'
                                    ORDER BY SORT_ORDER";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = estterm_ref_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "REPORTSUMDETAILGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string est_id
                        , int sort_order
                        , string use_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_REPORT_SUM_DETAIL(COMP_ID
							                                ,ESTTERM_REF_ID
							                                ,ESTTERM_SUB_ID
							                                ,EST_ID
							                                ,SORT_ORDER
							                                ,USE_YN
							                                ,CREATE_DATE
							                                ,CREATE_USER
							                                ,UPDATE_DATE
							                                ,UPDATE_USER
							                                )
						                                VALUES	(@COMP_ID
							                                ,@ESTTERM_REF_ID
							                                ,@ESTTERM_SUB_ID
							                                ,@EST_ID
							                                ,@SORT_ORDER
							                                ,@USE_YN
							                                ,@CREATE_DATE
							                                ,@CREATE_USER
							                                ,NULL
							                                ,NULL
							                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = estterm_ref_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
	        paramArray[4].Value = sort_order;
	        paramArray[5] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[5].Value = use_yn;
	        paramArray[6] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[6].Value = create_date;
	        paramArray[7] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[7].Value = create_user;
         
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
                        , int comp_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string est_id)
        {
            string query = @"DELETE	EST_REPORT_SUM_DETAIL
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		                            AND	EST_ID			= @EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = estterm_ref_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
         
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
