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
	public class Dac_TermSteps : DbAgentBase
	{
		public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_step_id
						, object estterm_step_name
                        , object weight
                        , object merge_yn
                        , object sort_order
                        , object use_yn
						, object update_date
						, object update_user)
		{
			string query = @"UPDATE	EST_TERM_STEP
							    SET	  ESTTERM_STEP_NAME	= @ESTTERM_STEP_NAME
                                    , WEIGHT            = @WEIGHT
                                    , MERGE_YN          = @MERGE_YN
                                    , SORT_ORDER        = @SORT_ORDER
                                    , USE_YN            = @USE_YN
								    , UPDATE_DATE		= @UPDATE_DATE
								    , UPDATE_USER		= @UPDATE_USER
							    WHERE   COMP_ID         = @COMP_ID
                                    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(9);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int );
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int );
			paramArray[1].Value = estterm_step_id;
			paramArray[2] 		= CreateDataParameter("@ESTTERM_STEP_NAME", SqlDbType.NVarChar );
			paramArray[2].Value = estterm_step_name;
            paramArray[3] 		= CreateDataParameter("@WEIGHT", SqlDbType.NVarChar );
			paramArray[3].Value = weight;
            paramArray[4] 		= CreateDataParameter("@MERGE_YN", SqlDbType.NChar );
			paramArray[4].Value = merge_yn;
            paramArray[5] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.NVarChar );
			paramArray[5].Value = sort_order;
            paramArray[6] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar );
			paramArray[6].Value = use_yn;
			paramArray[7] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime );
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
                            , int estterm_step_id
                            , string merge_yn
                            , string use_yn)
		{
			string query = @"SELECT   COMP_ID
                                    , ESTTERM_STEP_ID
									, ESTTERM_STEP_NAME
                                    , WEIGHT
                                    , MERGE_YN
                                    , SORT_ORDER
                                    , USE_YN
									, CREATE_DATE
									, CREATE_USER
									, UPDATE_DATE
									, UPDATE_USER 
								FROM EST_TERM_STEP
                                    WHERE   (COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                        AND (ESTTERM_STEP_ID    = @ESTTERM_STEP_ID  OR @ESTTERM_STEP_ID = 0)
                                        AND (MERGE_YN           = @MERGE_YN         OR @MERGE_YN            =''    )
                                        AND (USE_YN             = @USE_YN           OR @USE_YN              =''    )
                                        AND ESTTERM_STEP_ID     > 0
                                    ORDER BY SORT_ORDER";

			IDbDataParameter[] paramArray = CreateDataParameters(4);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int );
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int );
			paramArray[1].Value = estterm_step_id;
            paramArray[2]       = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
			paramArray[2].Value = merge_yn;
            paramArray[3]       = CreateDataParameter("@USE_YN", SqlDbType.NChar);
			paramArray[3].Value = use_yn;
		                
	        DataSet ds = DbAgentObj.FillDataSet( query, "ESTTERMSTEPGET" , null, paramArray, CommandType.Text );

	        return ds;
		}

		public int Insert(    IDbConnection conn
                            , IDbTransaction trx
                            , object comp_id
                            , object estterm_step_id
						    , object estterm_step_name
                            , object weight
                            , object merge_yn
                            , object sort_order
                            , object use_yn
						    , object create_date
						    , object create_user)
		{
			string query = @"INSERT INTO EST_TERM_STEP( COMP_ID
                                                    ,ESTTERM_STEP_ID
													,ESTTERM_STEP_NAME
                                                    ,WEIGHT
                                                    ,MERGE_YN
                                                    ,SORT_ORDER
                                                    ,USE_YN
													,CREATE_DATE
													,CREATE_USER
													)
											VALUES	(@COMP_ID
                                                    ,@ESTTERM_STEP_ID
													,@ESTTERM_STEP_NAME
                                                    ,@WEIGHT
                                                    ,@MERGE_YN
                                                    ,@SORT_ORDER
                                                    ,@USE_YN
													,@CREATE_DATE
													,@CREATE_USER
													)";

			IDbDataParameter[] paramArray = CreateDataParameters(9);
		 
            paramArray[0] 			= CreateDataParameter( "@COMP_ID", SqlDbType.Int );
			paramArray[0].Value 	= comp_id;
			paramArray[1] 			= CreateDataParameter( "@ESTTERM_STEP_ID", SqlDbType.Int );
			paramArray[1].Value 	= estterm_step_id;
			paramArray[2] 			= CreateDataParameter( "@ESTTERM_STEP_NAME", SqlDbType.NVarChar );
			paramArray[2].Value 	= estterm_step_name;
            paramArray[3] 			= CreateDataParameter( "@WEIGHT", SqlDbType.NVarChar );
			paramArray[3].Value 	= weight;
            paramArray[4] 			= CreateDataParameter( "@MERGE_YN", SqlDbType.NChar );
			paramArray[4].Value 	= merge_yn;
            paramArray[5] 			= CreateDataParameter( "@SORT_ORDER", SqlDbType.NVarChar );
			paramArray[5].Value 	= sort_order;
            paramArray[6] 			= CreateDataParameter( "@USE_YN", SqlDbType.NChar );
			paramArray[6].Value 	= use_yn;
			paramArray[7] 			= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
			paramArray[7].Value	    = create_date;
			paramArray[8] 			= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
			paramArray[8].Value	    = create_user; 
		 
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

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , int estterm_step_id )
        {
            string query = @"DELETE	EST_TERM_STEP
							    WHERE ESTTERM_STEP_ID = @ESTTERM_STEP_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
			paramArray[0] 			= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int );
			paramArray[0].Value 	= estterm_step_id;
		 
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

        public int Count(int comp_id, int estterm_step_id)
		{
			string query = @"SELECT   COUNT(*)
								FROM EST_TERM_STEP
                                    WHERE   (COMP_ID         = @COMP_ID         OR @COMP            = 0)
                                        AND (ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
            paramArray[0] 		= CreateDataParameter( "@COMP_ID", SqlDbType.Int );
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter( "@ESTTERM_STEP_ID", SqlDbType.Int );
			paramArray[1].Value = estterm_step_id;
		                
	        return (int) DbAgentObj.ExecuteNonQuery( query, paramArray);
		}
	}
}