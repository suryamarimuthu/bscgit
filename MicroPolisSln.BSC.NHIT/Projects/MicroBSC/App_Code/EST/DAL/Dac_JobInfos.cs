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
    public class Dac_JobInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , string est_job_id
                        , string est_job_name
                        , string est_job_depen_ids
                        , string var_map_key
                        , string mng_page_yn
                        , string year_yn
                        , string merge_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_JOB_INFO
	                            SET	 EST_JOB_NAME						= @EST_JOB_NAME
		                            ,EST_JOB_DEPEN_IDS					= @EST_JOB_DEPEN_IDS
                                    ,VAR_MAP_KEY                        = @VAR_MAP_KEY
                                    ,MNG_PAGE_YN				        = @MNG_PAGE_YN
		                            ,YEAR_YN							= @YEAR_YN
		                            ,MERGE_YN							= @MERGE_YN
		                            ,UPDATE_DATE						= @UPDATE_DATE
		                            ,UPDATE_USER						= @UPDATE_USER
	                            WHERE	EST_JOB_ID                      = @EST_JOB_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_job_id;
	        paramArray[1] 		= CreateDataParameter("@EST_JOB_NAME", SqlDbType.NVarChar, 400);
	        paramArray[1].Value = est_job_name;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_DEPEN_IDS", SqlDbType.NVarChar, 2000);
	        paramArray[2].Value = est_job_depen_ids;
            paramArray[3] 		= CreateDataParameter("@VAR_MAP_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = var_map_key;
            paramArray[4] 		= CreateDataParameter("@MNG_PAGE_YN", SqlDbType.NChar);
	        paramArray[4].Value = mng_page_yn;
	        paramArray[5] 		= CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
	        paramArray[5].Value= year_yn;
	        paramArray[6] 		= CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
	        paramArray[6].Value= merge_yn;
	        paramArray[7] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[7].Value= update_date;
	        paramArray[8] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[8].Value= update_user;
         
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
         
        public DataSet Select(string est_job_id, string mng_page_yn)
        {
            string query = @"SELECT 	 EST_JOB_ID
		                                ,EST_JOB_NAME
		                                ,EST_JOB_DEPEN_IDS
                                        ,VAR_MAP_KEY
                                        ,MNG_PAGE_YN
		                                ,YEAR_YN
		                                ,MERGE_YN
                                        ,SORT_ORDER
                                        ,SORT_COLUMN
                                        ,USE_YN
		                                ,CREATE_DATE
		                                ,CREATE_USER
		                                ,UPDATE_DATE
		                                ,UPDATE_USER
	                                FROM	EST_JOB_INFO 
		                                WHERE	(EST_JOB_ID     = @EST_JOB_ID   OR @EST_JOB_ID    =''   )
                                            AND (MNG_PAGE_YN    = @MNG_PAGE_YN  OR @MNG_PAGE_YN   =''   )
                                            AND USE_YN          = 'Y'
                                        ORDER BY SORT_ORDER, EST_JOB_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_job_id;
            paramArray[1] 		= CreateDataParameter("@MNG_PAGE_YN", SqlDbType.NChar, 2);
	        paramArray[1].Value = mng_page_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "JOBINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectInEstJobMap(string est_job_id
                                        , string mng_page_yn
                                        , int comp_id
                                        , string est_id)
        {
            string query = @"SELECT 	 EST_JOB_ID
		                                ,EST_JOB_NAME
		                                ,EST_JOB_DEPEN_IDS
                                        ,VAR_MAP_KEY
                                        ,MNG_PAGE_YN
		                                ,YEAR_YN
		                                ,MERGE_YN
		                                ,CREATE_DATE
		                                ,CREATE_USER
		                                ,UPDATE_DATE
		                                ,UPDATE_USER
	                                FROM	EST_JOB_INFO 
		                                WHERE	(EST_JOB_ID     = @EST_JOB_ID   OR @EST_JOB_ID  =''    )
                                            AND (MNG_PAGE_YN    = @MNG_PAGE_YN  OR @MNG_PAGE_YN =''    )
                                            AND USE_YN          = 'Y'
                                            AND EST_JOB_ID IN (SELECT EST_JOB_ID FROM EST_JOB_EST_MAP
                                                                    WHERE   COMP_ID = @COMP_ID
                                                                        AND EST_ID  = @EST_ID)";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_job_id;
            paramArray[1] 		= CreateDataParameter("@MNG_PAGE_YN", SqlDbType.NChar, 2);
	        paramArray[1].Value = mng_page_yn;
            paramArray[2] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[2].Value = comp_id;
            paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
	        paramArray[3].Value = est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "JOBINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , string est_job_id
                        , string est_job_name
                        , string est_job_depen_ids
                        , string var_map_key
                        , string mng_page_yn
                        , string year_yn
                        , string merge_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_JOB_INFO(EST_JOB_ID
		                                            ,EST_JOB_NAME
		                                            ,EST_JOB_DEPEN_IDS
                                                    ,VAR_MAP_KEY
                                                    ,MNG_PAGE_YN
		                                            ,YEAR_YN
		                                            ,MERGE_YN
		                                            ,CREATE_DATE
		                                            ,CREATE_USER
		                                            ,UPDATE_DATE
		                                            ,UPDATE_USER
		                                            )
	                                            VALUES	(@EST_JOB_ID
		                                            ,@EST_JOB_NAME
		                                            ,@EST_JOB_DEPEN_IDS
                                                    ,@VAR_MAP_KEY
                                                    ,@MNG_PAGE_YN
		                                            ,@YEAR_YN
		                                            ,@MERGE_YN
		                                            ,@CREATE_DATE
		                                            ,@CREATE_USER
		                                            ,NULL
		                                            ,NULL
		                                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_job_id;
	        paramArray[1] 		= CreateDataParameter("@EST_JOB_NAME", SqlDbType.NVarChar, 400);
	        paramArray[1].Value = est_job_name;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_DEPEN_IDS", SqlDbType.NVarChar, 2000);
	        paramArray[2].Value = est_job_depen_ids;
            paramArray[3] 		= CreateDataParameter("@VAR_MAP_KEY", SqlDbType.NVarChar);
	        paramArray[3].Value = var_map_key;
            paramArray[4] 		= CreateDataParameter("@MNG_PAGE_YN", SqlDbType.NChar);
	        paramArray[4].Value = mng_page_yn;
	        paramArray[5] 		= CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
	        paramArray[5].Value = year_yn;
	        paramArray[6] 		= CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
	        paramArray[6].Value = merge_yn;
	        paramArray[7] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[7].Value = create_date;
	        paramArray[8] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[8].Value= create_user;
         
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
                        , string est_job_id)
        {
            string query = @"DELETE	EST_JOB_INFO
	                            WHERE	EST_JOB_ID = @EST_JOB_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = est_job_id;
         
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
