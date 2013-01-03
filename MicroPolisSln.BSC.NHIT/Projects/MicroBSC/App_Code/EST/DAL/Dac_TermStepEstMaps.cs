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
    public class Dac_TermStepEstMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_step_id
                        , double weight
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_TERM_STEP_EST_MAP
	                            SET	 WEIGHT             = @WEIGHT
                                    ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID         = @COMP_ID
                                    AND EST_ID			= @EST_ID
		                            AND	ESTTERM_STEP_ID = @ESTTERM_STEP_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_step_id;
            paramArray[3]       = CreateDataParameter("@WEIGHT", SqlDbType.Decimal);
            paramArray[3].Value = weight;
	        paramArray[4] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = update_date;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[5].Value = update_user;
         
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
                            , string est_id
                            , int estterm_step_id
                            , string fixed_weight_yn)
        {
            string query = @"SELECT	 EM.COMP_ID
                                    ,EM.EST_ID
		                            ,EM.ESTTERM_STEP_ID
                                    ,EM.WEIGHT
                                    ,EM.FIXED_WEIGHT_YN
                                    ,TS.ESTTERM_STEP_NAME
		                            ,EM.CREATE_DATE
		                            ,EM.CREATE_USER
		                            ,EM.UPDATE_DATE
		                            ,EM.UPDATE_USER
                            FROM	    EST_TERM_STEP_EST_MAP EM
                                JOIN    EST_TERM_STEP         TS ON (EM.COMP_ID          = TS.COMP_ID
                                                                 AND EM.ESTTERM_STEP_ID  = TS.ESTTERM_STEP_ID)
                            WHERE	(EM.COMP_ID	        = @COMP_ID	        OR @COMP_ID         = 0)
                                AND (EM.EST_ID			= @EST_ID			OR @EST_ID			    =''    )
	                            AND	(EM.ESTTERM_STEP_ID	= @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID = 0)
                                AND (EM.FIXED_WEIGHT_YN = @FIXED_WEIGHT_YN  OR @FIXED_WEIGHT_YN     =''    )
                                AND TS.USE_YN           = 'Y'";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_step_id;
            paramArray[3] 		= CreateDataParameter("@FIXED_WEIGHT_YN", SqlDbType.NVarChar);
	        paramArray[3].Value = fixed_weight_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "TERMSTEPESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_step_id
                        , object fixed_weight_yn
                        , object weight
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_TERM_STEP_EST_MAP(  COMP_ID
                                                                ,EST_ID
			                                                    ,ESTTERM_STEP_ID
                                                                ,FIXED_WEIGHT_YN
                                                                ,WEIGHT
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
		                                                    VALUES	(@COMP_ID
                                                                ,@EST_ID
			                                                    ,@ESTTERM_STEP_ID
                                                                ,@FIXED_WEIGHT_YN
                                                                ,@WEIGHT
			                                                    ,@CREATE_DATE
			                                                    ,@CREATE_USER
			                                                    ,NULL
			                                                    ,NULL
			                                                    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_step_id;
            paramArray[3]       = CreateDataParameter("@FIXED_WEIGHT_YN", SqlDbType.NChar);
            paramArray[3].Value = fixed_weight_yn;
            paramArray[4]       = CreateDataParameter("@WEIGHT", SqlDbType.Decimal);
            paramArray[4].Value = weight;
	        paramArray[5] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[5].Value = create_date;
	        paramArray[6] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[6].Value = create_user;
         
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
         
        public int Delete( IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_step_id )
        {
            string query = @"DELETE	EST_TERM_STEP_EST_MAP
	                            WHERE	(COMP_ID	        = @COMP_ID	        OR @COMP_ID         = 0)
                                    AND (EST_ID		        = @EST_ID			OR @EST_ID              =''    )
		                            AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID	OR @ESTTERM_STEP_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_step_id;
         
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
