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
    public class Dac_TermSubEstMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , int estterm_sub_id
                        , double weight
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_TERM_SUB_EST_MAP
	                            SET	 WEIGHT             = @WEIGHT
                                    ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID         = @COMP_ID
                                    AND EST_ID			= @EST_ID
		                            AND	ESTTERM_SUB_ID  = @ESTTERM_SUB_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
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
                            , int estterm_sub_id
                            , string year_yn)
        {
            string query = @"SELECT	 EM.COMP_ID
                                    ,EM.EST_ID
		                            ,EM.ESTTERM_SUB_ID
                                    ,EM.WEIGHT
                                    ,TS.ESTTERM_SUB_NAME
		                            ,EM.CREATE_DATE
		                            ,EM.CREATE_USER
		                            ,EM.UPDATE_DATE
		                            ,EM.UPDATE_USER
                            FROM	    EST_TERM_SUB_EST_MAP EM
                                JOIN    EST_TERM_SUB         TS ON (EM.COMP_ID          = TS.COMP_ID
                                                                AND EM.ESTTERM_SUB_ID   = TS.ESTTERM_SUB_ID)
                            WHERE	(EM.COMP_ID			= @COMP_ID			OR @COMP_ID			= 0)
                                AND (EM.EST_ID			= @EST_ID			OR @EST_ID			    =''    )
	                            AND	(EM.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID  = 0)
                                AND (TS.YEAR_YN         = @YEAR_YN          OR @YEAR_YN         = N'')
                                AND TS.USE_YN           = 'Y'";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
            paramArray[3] 		= CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
			paramArray[3].Value = year_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "TERMSTEPESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_sub_id
                        , object weight
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_TERM_SUB_EST_MAP(COMP_ID
                                                            ,EST_ID
		                                                    ,ESTTERM_SUB_ID
                                                            ,WEIGHT
		                                                    ,CREATE_DATE
		                                                    ,CREATE_USER
		                                                    ,UPDATE_DATE
		                                                    ,UPDATE_USER
		                                                    )
	                                                    VALUES	(@COMP_ID
                                                            ,@EST_ID
		                                                    ,@ESTTERM_SUB_ID
                                                            ,@WEIGHT
		                                                    ,@CREATE_DATE
		                                                    ,@CREATE_USER
		                                                    ,NULL
		                                                    ,NULL
		                                                    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@WEIGHT", SqlDbType.Decimal);
            paramArray[3].Value = weight;
	        paramArray[4] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = create_date;
	        paramArray[5] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[5].Value = create_user;
         
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
                        , int estterm_sub_id )
        {
            string query = @"DELETE	EST_TERM_SUB_EST_MAP
	                            WHERE	( COMP_ID        = @COMP_ID	        OR @COMP_ID         = 0 )
                                    AND ( EST_ID		 = @EST_ID			OR @EST_ID              =''    )
		                            AND	( ESTTERM_SUB_ID = @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID  = 0 )";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_sub_id;
         
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
