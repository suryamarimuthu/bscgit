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
    public class Dac_Scopes : DbAgentBase
    {
        public int Update(IDbConnection conn
						, IDbTransaction trx
                        , int comp_id
						, string est_id
						, string grade_id
						, string scale_id
						, float start_scope
						, float end_scope
						, string scope_unit_id
						, float grade_to_point
						, DateTime update_date
						, int update_user )
        {
            string query = @"UPDATE	EST_SCOPE
                                    SET	START_SCOPE     = @START_SCOPE
	                                    ,END_SCOPE      = @END_SCOPE
	                                    ,SCOPE_UNIT_ID  = @SCOPE_UNIT_ID
	                                    ,GRADE_TO_POINT = @GRADE_TO_POINT
	                                    ,UPDATE_DATE    = @UPDATE_DATE
	                                    ,UPDATE_USER    = @UPDATE_USER
                                    WHERE	COMP_ID     = @COMP_ID
                                        AND EST_ID      = @EST_ID
                                        AND	GRADE_ID    = @GRADE_ID
                                        AND	SCALE_ID    = @SCALE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[2].Value = grade_id;
            paramArray[3]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = scale_id;
            paramArray[4]       = CreateDataParameter("@START_SCOPE", SqlDbType.Float);
            paramArray[4].Value = start_scope;
            paramArray[5]       = CreateDataParameter("@END_SCOPE", SqlDbType.Float);
            paramArray[5].Value = end_scope;
            paramArray[6]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 3 );
            paramArray[6].Value = scope_unit_id;
            paramArray[7]       = CreateDataParameter("@GRADE_TO_POINT", SqlDbType.Float);
            paramArray[7].Value = grade_to_point;
            paramArray[8]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = update_date;
            paramArray[9]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[9].Value = update_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select(int comp_id
                            , string est_id
							, string grade_id
							, string scale_id )
        {
            string query = @"SELECT	 COMP_ID
                                    ,EST_ID
	                                ,GRADE_ID
	                                ,SCALE_ID
	                                ,START_SCOPE
	                                ,END_SCOPE
	                                ,SCOPE_UNIT_ID
	                                ,GRADE_TO_POINT
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_SCOPE 
                                    WHERE	(COMP_ID   = @COMP_ID  OR @COMP_ID     = 0)
                                        AND (EST_ID    = @EST_ID   OR @EST_ID          =''    )
                                        AND	(GRADE_ID  = @GRADE_ID OR @GRADE_ID        =''    )
                                        AND	(SCALE_ID  = @SCALE_ID OR @SCALE_ID        =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[2].Value = grade_id;
            paramArray[3]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = scale_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "SCOPEGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectJoinGrade(   int comp_id
                                        , string est_id
									    , string grade_id
									    , string scale_id )
        {
            string query = @"SELECT   SCO.COMP_ID
                                    , SCO.EST_ID
									, SCO.GRADE_ID
									, SCO.SCALE_ID
									, SCO.START_SCOPE
									, SCO.END_SCOPE
									, SCO.SCOPE_UNIT_ID
									, SCO.GRADE_TO_POINT
									, GRA.GRADE_ID
									, GRA.GRADE_DESC
								FROM                EST_GRADE   GRA
								    LEFT OUTER JOIN EST_SCOPE   SCO     ON (SCO.GRADE_ID = GRA.GRADE_ID)
								WHERE	( SCO.COMP_ID   = @COMP_ID  OR @COMP_ID     = 0)
                                    AND ( SCO.EST_ID    = @EST_ID   OR @EST_ID          =''    )
								    AND	( SCO.GRADE_ID  = @GRADE_ID OR @GRADE_ID        =''    )
								    AND	( SCO.SCALE_ID  = @SCALE_ID OR @SCALE_ID        =''    )
                                ORDER BY GRA.SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar);
            paramArray[2].Value = grade_id;
            paramArray[3]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar);
            paramArray[3].Value = scale_id;

            DataSet ds = DbAgentObj.FillDataSet( query, "SCOPEJOINGRADE", null, paramArray, CommandType.Text );

            return ds;
        }

        public int Insert(IDbConnection conn
						, IDbTransaction trx
                        , int comp_id
						, string est_id
						, string grade_id
						, string scale_id
						, float start_scope
						, float end_scope
						, string scope_unit_id
						, float grade_to_point
						, DateTime create_date
						, int create_user )
        {
            string query = @"INSERT INTO EST_SCOPE(  COMP_ID
                                                    ,EST_ID
			                                        ,GRADE_ID
			                                        ,SCALE_ID
			                                        ,START_SCOPE
			                                        ,END_SCOPE
			                                        ,SCOPE_UNIT_ID
			                                        ,GRADE_TO_POINT
			                                        ,CREATE_DATE
			                                        ,CREATE_USER
			                                        ,UPDATE_DATE
			                                        ,UPDATE_USER
			                                        )
		                                        VALUES	(@COMP_ID
                                                    ,@EST_ID
			                                        ,@GRADE_ID
			                                        ,@SCALE_ID
			                                        ,@START_SCOPE
			                                        ,@END_SCOPE
			                                        ,@SCOPE_UNIT_ID
			                                        ,@GRADE_TO_POINT
			                                        ,@CREATE_DATE
			                                        ,@CREATE_USER
			                                        ,NULL
			                                        ,NULL
			                                        )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[2].Value = grade_id;
            paramArray[3]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = scale_id;
            paramArray[4]       = CreateDataParameter("@START_SCOPE", SqlDbType.Float);
            paramArray[4].Value = start_scope;
            paramArray[5]       = CreateDataParameter("@END_SCOPE", SqlDbType.Float);
            paramArray[5].Value = end_scope;
            paramArray[6]       = CreateDataParameter("@SCOPE_UNIT_ID", SqlDbType.NVarChar, 3 );
            paramArray[6].Value = scope_unit_id;
            paramArray[7]       = CreateDataParameter("@GRADE_TO_POINT", SqlDbType.Float);
            paramArray[7].Value = grade_to_point;
            paramArray[8]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = create_date;
            paramArray[9]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray );
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
						, string est_id
						, string grade_id
						, string scale_id )
        {

            string query = @"DELETE	EST_SCOPE
                                WHERE	(COMP_ID   = @COMP_ID  OR @COMP_ID     = 0)
                                    AND (EST_ID    = @EST_ID   OR @EST_ID          =''    )
                                    AND	(GRADE_ID  = @GRADE_ID OR @GRADE_ID        =''    )
                                    AND	(SCALE_ID  = @SCALE_ID OR @SCALE_ID        =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[2].Value = grade_id;
            paramArray[3]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = scale_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count( int comp_id
                        , string est_id
                        , string grade_id
                        , string scale_id)
        {

            string query = @"SELECT COUNT(*) FROM EST_SCOPE
                                WHERE	COMP_ID     = @COMP_ID
                                    AND EST_ID      = @EST_ID
                                    AND	GRADE_ID    = @GRADE_ID
                                    AND	SCALE_ID    = @SCALE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[2].Value = grade_id;
            paramArray[3]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = scale_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
