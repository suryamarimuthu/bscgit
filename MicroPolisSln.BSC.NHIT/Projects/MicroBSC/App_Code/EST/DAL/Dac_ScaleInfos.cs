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
    public class Dac_ScaleInfos : DbAgentBase
    {
        public int Update(    IDbConnection conn
                            , IDbTransaction trx
                            , int comp_id
                            , string scale_id
                            , string scale_name
                            , string use_yn
                            , DateTime update_date
                            , int update_user)
        {
            string query = @"UPDATE	EST_SCALE_INFO
	                                SET	 SCALE_NAME		= @SCALE_NAME
		                                ,USE_YN			= @USE_YN
		                                ,UPDATE_DATE	= @UPDATE_DATE
		                                ,UPDATE_USER	= @UPDATE_USER
	                                WHERE	COMP_ID     = @COMP_ID
                                        AND SCALE_ID	= @SCALE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 6);
            paramArray[1].Value = scale_id;
            paramArray[2]       = CreateDataParameter("@SCALE_NAME", SqlDbType.NVarChar, 200);
            paramArray[2].Value = scale_name;
            paramArray[3]       = CreateDataParameter("@USE_YN", SqlDbType.NChar);
            paramArray[3].Value = use_yn;
            paramArray[4]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[4].Value = update_date;
            paramArray[5]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
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

        public DataSet Select(int comp_id, string scale_id, string use_yn)
        {
            string query = @"SELECT	 COMP_ID
                                    ,SCALE_ID
		                            ,SCALE_NAME
		                            ,USE_YN
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
                            FROM	EST_SCALE_INFO 
	                            WHERE	(COMP_ID    = @COMP_ID  OR @COMP_ID     = 0)
                                    AND (SCALE_ID   = @SCALE_ID OR @SCALE_ID        =''    )
                                    AND (USE_YN     = @USE_YN   OR @USE_YN          =''    )";

            IDbDataParameter[] paramArray   = CreateDataParameters(3);

            paramArray[0]                   = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value             = comp_id;
            paramArray[1]                   = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar);
            paramArray[1].Value             = scale_id;
            paramArray[2]                   = CreateDataParameter("@USE_YN", SqlDbType.NVarChar);
            paramArray[2].Value             = use_yn;

            DataSet ds = DbAgentObj.FillDataSet(query, "SCALEINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string scale_id
                        , string scale_name
                        , string use_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_SCALE_INFO( COMP_ID
                                                        ,SCALE_ID
			                                            ,SCALE_NAME
			                                            ,USE_YN
			                                            ,CREATE_DATE
			                                            ,CREATE_USER
			                                            ,UPDATE_DATE
			                                            ,UPDATE_USER
			                                            )
		                                            VALUES	(@COMP_ID
                                                        ,@SCALE_ID
			                                            ,@SCALE_NAME
			                                            ,@USE_YN
			                                            ,@CREATE_DATE
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray   = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 6);
            paramArray[1].Value = scale_id;
            paramArray[2]       = CreateDataParameter("@SCALE_NAME", SqlDbType.NVarChar, 200);
            paramArray[2].Value = scale_name;
            paramArray[3]       = CreateDataParameter("@USE_YN", SqlDbType.NChar);
            paramArray[3].Value = use_yn;
            paramArray[4]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[4].Value = create_date;
            paramArray[5]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[5].Value = create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
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
                        , string scale_id)
        {
            string query = @"DELETE	EST_SCALE_INFO
	                            WHERE	COMP_ID     = @COMP_ID
                                    AND SCALE_ID    = @SCALE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 6);
            paramArray[1].Value = scale_id;

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

        public int Count(int comp_id, string scale_id)
        {
            string query = @"SELECT COUNT(SCALE_ID) FROM EST_SCALE_INFO
	                             WHERE	(COMP_ID  = @COMP_ID  OR @COMP_ID  = 0)
                                    AND (SCALE_ID = @SCALE_ID OR @SCALE_ID     =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 6);
            paramArray[1].Value = scale_id;

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
