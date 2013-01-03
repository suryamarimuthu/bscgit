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
    public class Dac_JobDetails : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_job_id
                        , object start_date
                        , object end_date
                        , object status_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_JOB_DETAIL
	                            SET	 START_DATE		    = CASE WHEN @START_DATE IS NULL THEN START_DATE ELSE @START_DATE    END
                                    ,END_DATE		    = CASE WHEN @END_DATE   IS NULL THEN END_DATE   ELSE @END_DATE      END  
                                    ,STATUS_YN			= CASE WHEN @STATUS_YN  IS NULL THEN STATUS_YN  ELSE @STATUS_YN     END
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		                            AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID
		                            AND	EST_JOB_ID		= @EST_JOB_ID";

//            string queryTemp = @"UPDATE	EST_JOB_DETAIL
//	                            SET	 START_DATE		    = CASE WHEN NULL IS NULL THEN START_DATE ELSE NULL    END
//                                    ,END_DATE		    = CASE WHEN NULL   IS NULL THEN END_DATE   ELSE NULL      END  
//                                    ,STATUS_YN			= CASE WHEN 'Y'  IS NULL THEN STATUS_YN  ELSE 'Y'     END
//		                            ,UPDATE_DATE		= TO_DATE('2010-08-12 16:00:42', 'YYYY-MM-DD hh24:mi:ss')
//		                            ,UPDATE_USER		= 1000
//	                            WHERE	COMP_ID			= 1
//		                            AND	EST_ID			= '3A'
//		                            AND	ESTTERM_REF_ID	= 1000
//		                            AND	ESTTERM_SUB_ID	= 2
//		                            AND	ESTTERM_STEP_ID = 1
//		                            AND	EST_JOB_ID		= 'JOB12'";

	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[5].Value = est_job_id;
            paramArray[6] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
	        paramArray[6].Value = start_date;
            paramArray[7] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
	        paramArray[7].Value = end_date;
	        paramArray[8] 		= CreateDataParameter("@STATUS_YN", SqlDbType.NChar);
	        paramArray[8].Value = status_yn;
	        paramArray[9] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[9].Value = update_date;
	        paramArray[10] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[10].Value= update_user;
         
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

        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , object[] temp)
        {
            string query = @"UPDATE	EST_JOB_DETAIL
	                            SET	 START_DATE		    = CASE WHEN @START_DATE IS NULL THEN START_DATE ELSE @START_DATE    END
                                    ,END_DATE		    = CASE WHEN @END_DATE   IS NULL THEN END_DATE   ELSE @END_DATE      END  
                                    ,STATUS_YN			= CASE WHEN @STATUS_YN  IS NULL THEN STATUS_YN  ELSE @STATUS_YN     END
		                            ,UPDATE_DATE		= GETDATE()
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		                            AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID
		                            AND	EST_JOB_ID		= @EST_JOB_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = temp[0];
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = temp[1];
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = temp[2];
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = temp[3];
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = temp[4];
	        paramArray[5] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[5].Value = temp[5];
            paramArray[6] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
	        paramArray[6].Value = DataTypeUtility.GetToDateTime(temp[6]);
            paramArray[7] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
	        paramArray[7].Value = DataTypeUtility.GetToDateTime(temp[7]);
	        paramArray[8] 		= CreateDataParameter("@STATUS_YN", SqlDbType.NChar);
	        paramArray[8].Value = temp[8];	        
	        paramArray[9] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[9].Value = temp[9];

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
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string est_job_id)
        {
            string query = @"SELECT	 EJD.COMP_ID
		                            ,EJD.EST_ID
		                            ,EJD.ESTTERM_REF_ID
		                            ,EJD.ESTTERM_SUB_ID
		                            ,EJD.ESTTERM_STEP_ID
		                            ,EJD.EST_JOB_ID
                                    ,EJI.EST_JOB_NAME
                                    ,EJD.START_DATE
                                    ,EJD.END_DATE
		                            ,EJD.STATUS_YN
		                            ,EJD.CREATE_DATE
		                            ,EJD.CREATE_USER
		                            ,EJD.UPDATE_DATE
		                            ,EJD.UPDATE_USER
	                            FROM	 EST_JOB_DETAIL EJD
                                    JOIN EST_JOB_INFO   EJI ON (EJD.EST_JOB_ID = EJI.EST_JOB_ID)
	                            WHERE	(EJD.COMP_ID			= @COMP_ID          OR @COMP_ID         = 0)
		                            AND	(EJD.EST_ID			    = @EST_ID           OR @EST_ID              =''    )
		                            AND	(EJD.ESTTERM_REF_ID	    = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
		                            AND	(EJD.ESTTERM_SUB_ID	    = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
		                            AND	(EJD.ESTTERM_STEP_ID    = @ESTTERM_STEP_ID  OR @ESTTERM_STEP_ID = 0)
		                            AND	(EJD.EST_JOB_ID		    = @EST_JOB_ID       OR @EST_JOB_ID          =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[5].Value = est_job_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "JOBDETAILGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string est_job_id
                        , string status_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_JOB_DETAIL( COMP_ID
							                            ,EST_ID
							                            ,ESTTERM_REF_ID
							                            ,ESTTERM_SUB_ID
							                            ,ESTTERM_STEP_ID
							                            ,EST_JOB_ID
							                            ,STATUS_YN
							                            ,CREATE_DATE
							                            ,CREATE_USER
							                            ,UPDATE_DATE
							                            ,UPDATE_USER
							                            )
						                            VALUES	(@COMP_ID
							                            ,@EST_ID
							                            ,@ESTTERM_REF_ID
							                            ,@ESTTERM_SUB_ID
							                            ,@ESTTERM_STEP_ID
							                            ,@EST_JOB_ID
							                            ,@STATUS_YN
							                            ,@CREATE_DATE
							                            ,@CREATE_USER
							                            ,NULL
							                            ,NULL
							                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[5].Value = est_job_id;
	        paramArray[6] 		= CreateDataParameter("@STATUS_YN", SqlDbType.NChar);
	        paramArray[6].Value = status_yn;
	        paramArray[7] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[7].Value = create_date;
	        paramArray[8] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[8].Value = create_user;
         
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

        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , object[] temp)
        {
            string query = @"INSERT INTO EST_JOB_DETAIL( COMP_ID
							                            , EST_ID
							                            , ESTTERM_REF_ID
							                            , ESTTERM_SUB_ID
							                            , ESTTERM_STEP_ID
							                            , EST_JOB_ID
                                                        , START_DATE
                                                        , END_DATE
							                            , STATUS_YN
							                            , CREATE_DATE
							                            , CREATE_USER
							                            , UPDATE_DATE
							                            , UPDATE_USER
							                            )
						                            VALUES	(@COMP_ID
							                            , @EST_ID
							                            , @ESTTERM_REF_ID
							                            , @ESTTERM_SUB_ID
							                            , @ESTTERM_STEP_ID
							                            , @EST_JOB_ID
                                                        , @START_DATE
                                                        , @END_DATE
							                            , @STATUS_YN
							                            , GETDATE()
							                            , @CREATE_USER
							                            , NULL
							                            , NULL
							                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
            paramArray[6] = CreateDataParameter("@START_DATE", SqlDbType.DateTime);
            paramArray[7] = CreateDataParameter("@END_DATE", SqlDbType.DateTime);
            paramArray[8] = CreateDataParameter("@STATUS_YN", SqlDbType.NChar);
            paramArray[9] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

	        paramArray[0].Value = temp[0];            
	        paramArray[1].Value = temp[1];
	        paramArray[2].Value = temp[2];
	        paramArray[3].Value = temp[3];
	        paramArray[4].Value = temp[4];
	        paramArray[5].Value = temp[5];
            paramArray[6].Value = temp[6];
            paramArray[7].Value = temp[7];
            paramArray[8].Value = temp[8];
            paramArray[9].Value = temp[9];
         
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
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string est_job_id)
        {
            string query = @"DELETE	EST_JOB_DETAIL
	                            WHERE	(COMP_ID			= @COMP_ID          OR @COMP_ID         = 0)
		                            AND	(EST_ID			    = @EST_ID           OR @EST_ID              =''    )
		                            AND	(ESTTERM_REF_ID	    = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
		                            AND	(ESTTERM_SUB_ID	    = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
		                            AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID  OR @ESTTERM_STEP_ID = 0)
		                            AND	(EST_JOB_ID		    = @EST_JOB_ID       OR @EST_JOB_ID          =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[5].Value = est_job_id;
         
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

        public int Count( int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string est_job_id)
        {
            string query = @"SELECT	 COUNT(*)
	                            FROM	EST_JOB_DETAIL 
		                            WHERE	(COMP_ID			= @COMP_ID          OR @COMP_ID         = 0)
			                            AND	(EST_ID			    = @EST_ID           OR @EST_ID              =''    )
			                            AND	(ESTTERM_REF_ID	    = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
			                            AND	(ESTTERM_SUB_ID	    = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
			                            AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID )
			                            AND	(EST_JOB_ID		    = @EST_JOB_ID       OR @EST_JOB_ID          =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_JOB_ID", SqlDbType.NVarChar, 20);
	        paramArray[5].Value = est_job_id;
         
	        return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
        }
    }
}
