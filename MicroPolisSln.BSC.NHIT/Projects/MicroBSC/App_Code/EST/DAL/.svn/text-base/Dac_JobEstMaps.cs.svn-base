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
    public class Dac_JobEstMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , string est_job_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_JOB_EST_MAP
	                            SET	 UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	COMP_ID     = @COMP_ID
                                    AND EST_ID		= @EST_ID
		                            AND	EST_JOB_ID	= @EST_JOB_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
	        paramArray[3] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = update_date;
	        paramArray[4] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[4].Value = update_user;
         
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
         
        public DataSet Select(int comp_id
                            , string est_id
                            , string est_job_id)
        {
            string query = @"SELECT	 EJE.COMP_ID
                                    ,EJE.EST_ID
		                            ,EJE.EST_JOB_ID
                                    ,EJI.EST_JOB_NAME
		                            ,EJE.CREATE_DATE
		                            ,EJE.CREATE_USER
		                            ,EJE.UPDATE_DATE
		                            ,EJE.UPDATE_USER
	                            FROM	 EST_JOB_EST_MAP EJE
                                    JOIN EST_JOB_INFO    EJI  ON (EJE.EST_JOB_ID = EJI.EST_JOB_ID)
		                            WHERE	(EJE.COMP_ID	= @COMP_ID		OR @COMP_ID		   = 0)
                                        AND (EJE.EST_ID		= @EST_ID		OR @EST_ID		   =''     )
			                            AND	(EJE.EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	   =''     )";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "JOBESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectNotIn(int comp_id
                                , string est_id
                                , string est_job_id)
        {
            string query = @"SELECT	 EJE.COMP_ID
                                    ,EJE.EST_ID
		                            ,EJE.EST_JOB_ID
                                    ,EJI.EST_JOB_NAME
		                            ,EJE.CREATE_DATE
		                            ,EJE.CREATE_USER
		                            ,EJE.UPDATE_DATE
		                            ,EJE.UPDATE_USER
	                            FROM	 EST_JOB_EST_MAP EJE
                                    JOIN EST_JOB_INFO    EJI  ON (EJE.EST_JOB_ID = EJI.EST_JOB_ID)l
	                            WHERE	(EJE.COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                    AND (EJE.EST_ID		= @EST_ID		OR @EST_ID		=''     )
		                            AND	(EJE.EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	=''     )
                                    AND EJE.EST_JOB_ID NOT IN (SELECT EST_JOB_ID FROM EST_JOB_EST_MAP
                                                                WHERE   (EJE.COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                                                    AND (EJE.EST_ID		= @EST_ID		OR @EST_ID		=''        ))";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "JOBESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , string est_job_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_JOB_EST_MAP(COMP_ID
                                                        ,EST_ID
							                            ,EST_JOB_ID
							                            ,CREATE_DATE
							                            ,CREATE_USER
							                            ,UPDATE_DATE
							                            ,UPDATE_USER
							                            )
						                            VALUES	(@COMP_ID
                                                        ,@EST_ID
							                            ,@EST_JOB_ID
							                            ,@CREATE_DATE
							                            ,@CREATE_USER
							                            ,NULL
							                            ,NULL
							                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
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
                        , int comp_id
                        , string est_id
                        , string est_job_id)
        {
            string query = @"DELETE	EST_JOB_EST_MAP
	                            WHERE	(COMP_ID	= @COMP_ID		OR @COMP_ID		  = 0)
                                    AND (EST_ID		= @EST_ID		OR @EST_ID		  =''     )
		                            AND	(EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	  =''     )";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
         
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

        public int Count( int comp_id
                        , string est_id
                        , string est_job_id)
        {
            string query = @"SELECT	 COUNT(*)
	                            FROM	EST_JOB_EST_MAP 
		                            WHERE	(COMP_ID	= @COMP_ID		OR @COMP_ID		= 0)
                                        AND (EST_ID		= @EST_ID		OR @EST_ID		=''      )
			                            AND	(EST_JOB_ID	= @EST_JOB_ID	OR @EST_JOB_ID	=''      )";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_job_id;
         
	        return Convert.ToInt32(DbAgentObj.ExecuteScalar(query , paramArray, CommandType.Text).ToString());
        }

        #region ========================= 평가기간별 일정등록 ========================

        public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , string est_job_id)
        {
            string query = @"
                            SELECT	 EJE.COMP_ID
                                    ,EJD.ESTTERM_STEP_ID
                                    ,EJE.EST_ID
                                    ,EJE.EST_JOB_ID
                                    ,EJI.EST_JOB_NAME     
                                    ,EJD.START_DATE
                                    ,EJD.END_DATE
                                    ,EJD.STATUS_YN
                                    ,EJD.CREATE_DATE
                                    ,EJD.UPDATE_DATE
                                FROM	       EST_JOB_EST_MAP EJE
                                          JOIN EST_JOB_INFO    EJI  ON (EJE.EST_JOB_ID = EJI.EST_JOB_ID)
                               LEFT OUTER JOIN EST_JOB_DETAIL  EJD  ON (EJD.COMP_ID         = EJE.COMP_ID
                                                                    AND EJD.EST_ID          = EJE.EST_ID
                                                                    AND EJD.EST_JOB_ID      = EJE.EST_JOB_ID
                                                                    AND EJD.EST_JOB_ID      = EJI.EST_JOB_ID
                                                                    AND EJD.ESTTERM_REF_ID	= @ESTTERM_REF_ID
                                                                    AND EJD.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID) 
		                            WHERE	(EJE.COMP_ID	    = @COMP_ID		    OR @COMP_ID		    = 0)
                                        AND (EJE.EST_ID		    = @EST_ID		    OR @EST_ID		    =''   )			                                                                    
                                        AND	(EJE.EST_JOB_ID	    = @EST_JOB_ID	    OR @EST_JOB_ID	    =''   ) 
                                        AND (EJI.MNG_PAGE_YN    = 'N') 
                             ORDER BY EJI.SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
            paramArray[4].Value = est_job_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "JOBESTMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        #endregion
    }
}
