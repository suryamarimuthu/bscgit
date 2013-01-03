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
	public class Dac_ScheDetails : DbAgentBase
	{
		public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
						, object estterm_sub_id
						, object est_sche_id
						, object start_date
						, object end_date
						, object status_id
						, object update_date
						, object update_user )
		{
			string query = @"UPDATE	EST_SCHE_DETAIL
                                SET	 START_DATE         = @START_DATE
                                    ,END_DATE           = @END_DATE
                                    ,STATUS_ID          = @STATUS_ID
                                    ,UPDATE_DATE        = @UPDATE_DATE
                                    ,UPDATE_USER        = @UPDATE_USER
                                WHERE   COMP_ID         = @COMP_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                    AND	EST_SCHE_ID     = @EST_SCHE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(9);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_sub_id;
			paramArray[3] 		= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20 );
			paramArray[3].Value = est_sche_id;
			paramArray[4] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
			paramArray[4].Value = start_date;
			paramArray[5] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
			paramArray[5].Value = end_date;
			paramArray[6] 		= CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
			paramArray[6].Value = status_id;
			paramArray[7] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
			paramArray[7].Value = update_date;
			paramArray[8] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int );
			paramArray[8].Value = update_user;

			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
        }

		public DataSet Select(int comp_id
                            , int estterm_ref_id
							, int estterm_sub_id
							, string est_sche_id )
		{
			string query = @"SELECT	 COMP_ID
                                    ,ESTTERM_REF_ID
									,ESTTERM_SUB_ID
									,EST_SCHE_ID
									,START_DATE
									,END_DATE
									,STATUS_ID
									,CREATE_DATE
									,CREATE_USER
									,UPDATE_DATE
									,UPDATE_USER
                                FROM EST_SCHE_DETAIL 
                                    WHERE   COMP_ID         = @COMP_ID
                                        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
	                                    AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
	                                    AND	EST_SCHE_ID     = @EST_SCHE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(4);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_sub_id;
			paramArray[3] 		= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20);
			paramArray[3].Value = est_sche_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "SCHEDETAIL" , null, paramArray, CommandType.Text );
	        return ds;
		}


		public DataSet SelectINFO( int comp_id
                                 , int estterm_ref_id
                                 , int estterm_sub_id )
		{
			string query = @"SELECT   INF.EST_SCHE_ID
									, INF.UP_EST_SCHE_ID
									, INF.EST_SCHE_NAME
									, INF.EST_SCHE_DESC
									, INF.EST_ID
									, DET.ESTTERM_REF_ID
									, DET.ESTTERM_SUB_ID
									, DET.START_DATE
									, DET.END_DATE
									, DET.STATUS_ID
								FROM     EST_SCHE_INFO   INF 
									JOIN EST_SCHE_DETAIL DET ON (INF.COMP_ID     = DET.COMP_ID
                                                             AND INF.EST_SCHE_ID = DET.EST_SCHE_ID)
								WHERE   (DET.COMP_ID        = @COMP_ID          OR @COMP_ID         = 0 )
                                    AND (DET.ESTTERM_REF_ID = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID      =''    )
									AND (DET.ESTTERM_SUB_ID = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID      =''    )
								ORDER BY INF.SORT_ORDER";

			IDbDataParameter[] paramArray = CreateDataParameters(3);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_sub_id;

	        DataSet ds = DbAgentObj.FillDataSet( query, "SCHEDETAILINFO" , null, paramArray, CommandType.Text );
	        return ds;
		}


		public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
						, object estterm_sub_id
						, object est_sche_id
						, object start_date
						, object end_date
						, object status_id
						, object create_date
						, object create_user )
		{
			string query = @"INSERT INTO EST_SCHE_DETAIL(COMP_ID
                                                        ,ESTTERM_REF_ID
														,ESTTERM_SUB_ID
														,EST_SCHE_ID
														,START_DATE
														,END_DATE
														,STATUS_ID
														,CREATE_DATE
														,CREATE_USER
														)
												VALUES	(@COMP_ID
                                                        ,@ESTTERM_REF_ID
														,@ESTTERM_SUB_ID
														,@EST_SCHE_ID
														,@START_DATE
														,@END_DATE
														,@STATUS_ID
														,@CREATE_DATE
														,@CREATE_USER
														)";

			IDbDataParameter[] paramArray = CreateDataParameters(9);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_sub_id;
			paramArray[3] 		= CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20);
			paramArray[3].Value = est_sche_id;
			paramArray[4] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
			paramArray[4].Value = start_date;
			paramArray[5] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
			paramArray[5].Value = end_date;
			paramArray[6] 		= CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
			paramArray[6].Value = status_id;
			paramArray[7] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime );
			paramArray[7].Value = create_date;
			paramArray[8] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int );
			paramArray[8].Value = create_user;
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}


		public int InsertSelect(  IDbConnection conn
						        , IDbTransaction trx
                                , int comp_id
						        , int estterm_ref_id
						        , int estterm_sub_id
                                , DateTime start_date
                                , DateTime end_date
						        , DateTime create_date
						        , int create_user )
		{
			string query = @"INSERT INTO EST_SCHE_DETAIL (COMP_ID
                                                        , ESTTERM_REF_ID
														, ESTTERM_SUB_ID
														, EST_SCHE_ID 
                                                        , START_DATE
                                                        , END_DATE
														)
										        SELECT @COMP_ID
                                                     , @ESTTERM_REF_ID
													 , @ESTTERM_SUB_ID
													 , EST_SCHE_ID
                                                     , @START_DATE
                                                     , @END_DATE
										            FROM EST_SCHE_INFO";

			IDbDataParameter[] paramArray = CreateDataParameters(5);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_sub_id;
            paramArray[3] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
			paramArray[3].Value = start_date;
            paramArray[4] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
			paramArray[4].Value = end_date;

			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_ref_id
						, int estterm_sub_id
						, string est_sche_id )
        {
            string query = @"DELETE	EST_SCHE_DETAIL
							    WHERE	COMP_ID         = @COMP_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
								    AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
								    AND	(EST_SCHE_ID    = @EST_SCHE_ID OR @EST_SCHE_ID     =''    )";

			IDbDataParameter[] paramArray = CreateDataParameters(4);
		 
            paramArray[0] 		= CreateDataParameter( "@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter( "@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2] 		= CreateDataParameter( "@ESTTERM_SUB_ID", SqlDbType.Int);
			paramArray[2].Value = estterm_sub_id;
			paramArray[3] 		= CreateDataParameter( "@EST_SCHE_ID", SqlDbType.NVarChar, 20);
			paramArray[3].Value = est_sche_id;
		 
			try
			{
				int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
				return affectedRow;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
        }

        public int Count(int comp_id
                      , int estterm_ref_id
                      , int estterm_sub_id
                      , string est_sche_id )
        {
            string query = @"SELECT COUNT(*) FROM EST_SCHE_DETAIL
							    WHERE	COMP_ID         = @COMP_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
								    AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
								    AND	EST_SCHE_ID     = @EST_SCHE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@EST_SCHE_ID", SqlDbType.NVarChar, 20);
            paramArray[3].Value = est_sche_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}