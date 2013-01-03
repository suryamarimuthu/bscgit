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
    public class Dac_DeptEstDetails : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object dept_ref_id
                        , object est_id
                        , object scale_id
                        , object est_grp_id
                        , object weight
                        , object weight_type
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	EST_DEPT_EST_DETAIL
                                    SET	 SCALE_ID           = CASE WHEN @SCALE_ID       IS NULL THEN SCALE_ID       ELSE @SCALE_ID      END
	                                    ,EST_GRP_ID         = CASE WHEN @EST_GRP_ID     IS NULL THEN EST_GRP_ID     ELSE @EST_GRP_ID    END
	                                    ,WEIGHT             = CASE WHEN @WEIGHT         IS NULL THEN WEIGHT         ELSE @WEIGHT        END
	                                    ,WEIGHT_TYPE        = CASE WHEN @WEIGHT_TYPE    IS NULL THEN WEIGHT_TYPE    ELSE @WEIGHT_TYPE   END
	                                    ,UPDATE_DATE        = CASE WHEN @UPDATE_DATE    IS NULL THEN UPDATE_DATE    ELSE @UPDATE_DATE   END
	                                    ,UPDATE_USER        = CASE WHEN @UPDATE_USER    IS NULL THEN UPDATE_USER    ELSE @UPDATE_USER   END
                                    WHERE	COMP_ID         = @COMP_ID
                                        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                        AND	DEPT_REF_ID     = @DEPT_REF_ID
                                        AND	EST_ID          = @EST_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[4].Value = scale_id;
            paramArray[5]       = CreateDataParameter("@EST_GRP_ID", SqlDbType.Int);
            paramArray[5].Value = est_grp_id;
            paramArray[6]       = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[6].Value = weight;
            paramArray[7]       = CreateDataParameter("@WEIGHT_TYPE", SqlDbType.NChar);
            paramArray[7].Value = weight_type;
            paramArray[8]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = update_date;
            paramArray[9]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[9].Value = update_user;

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

        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object dept_ref_id
                        , object est_id
                        , object scale_id
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	EST_DEPT_EST_DETAIL
                                    SET	 SCALE_ID           = @SCALE_ID      
	                                    ,UPDATE_DATE        = @UPDATE_DATE   
	                                    ,UPDATE_USER        = @UPDATE_USER   
                                    WHERE	COMP_ID         = @COMP_ID
                                        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                        AND	DEPT_REF_ID     = @DEPT_REF_ID
                                        AND	EST_ID          = @EST_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[4].Value = scale_id;
            paramArray[5]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[5].Value = update_date;
            paramArray[6]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[6].Value = update_user;

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

        public DataSet Select(int comp_id, int estterm_ref_id, int dept_ref_id, string est_id)
        {
            string query = @"SELECT	 COMP_ID
                                    ,ESTTERM_REF_ID
                                    ,DEPT_REF_ID
                                    ,EST_ID
                                    ,SCALE_ID
                                    ,EST_GRP_ID
                                    ,WEIGHT
                                    ,WEIGHT_TYPE
                                    ,CREATE_DATE
                                    ,CREATE_USER
                                    ,UPDATE_DATE
                                    ,UPDATE_USER
                                FROM	EST_DEPT_EST_DETAIL 
                                    WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                        AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                        AND	(DEPT_REF_ID     = @DEPT_REF_ID     OR @DEPT_REF_ID     = 0)
                                        AND	(EST_ID          = @EST_ID          OR @EST_ID              =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTESTDETAILGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object dept_ref_id
                        , object est_id
                        , object scale_id
                        , object est_grp_id
                        , object weight
                        , object weight_type
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_DEPT_EST_DETAIL(COMP_ID
                                                            ,ESTTERM_REF_ID
			                                                ,DEPT_REF_ID
			                                                ,EST_ID
			                                                ,SCALE_ID
			                                                ,EST_GRP_ID
			                                                ,WEIGHT
			                                                ,WEIGHT_TYPE
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@COMP_ID
                                                            ,@ESTTERM_REF_ID
			                                                ,@DEPT_REF_ID
			                                                ,@EST_ID
			                                                ,@SCALE_ID
			                                                ,@EST_GRP_ID
			                                                ,@WEIGHT
			                                                ,@WEIGHT_TYPE
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar, 12);
            paramArray[4].Value = scale_id;
            paramArray[5]       = CreateDataParameter("@EST_GRP_ID", SqlDbType.Int);
            paramArray[5].Value = est_grp_id;
            paramArray[6]       = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[6].Value = weight;
            paramArray[7]       = CreateDataParameter("@WEIGHT_TYPE", SqlDbType.NChar);
            paramArray[7].Value = weight_type;
            paramArray[8]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value = create_date;
            paramArray[9]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user;

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

        public int InsertDataFromTo(IDbConnection conn
                                , IDbTransaction trx
                                , object comp_id
                                , object estterm_ref_id_from
                                , object estterm_ref_id_to
                                , object create_date
                                , object create_user)
        {
            string query = @"INSERT INTO EST_DEPT_EST_DETAIL(COMP_ID
                                                            ,ESTTERM_REF_ID
			                                                ,DEPT_REF_ID
			                                                ,EST_ID
			                                                ,SCALE_ID
			                                                ,EST_GRP_ID
			                                                ,WEIGHT
			                                                ,WEIGHT_TYPE
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                        SELECT    @COMP_ID
		                                                , @ESTTERM_REF_ID_TO
		                                                , DEPT_REF_ID
		                                                , EST_ID
		                                                , SCALE_ID
		                                                , EST_GRP_ID
		                                                , WEIGHT
		                                                , WEIGHT_TYPE
		                                                , @CREATE_DATE
		                                                , @CREATE_USER
		                                                , NULL
		                                                , NULL
	                                                FROM EST_DEPT_EST_DETAIL
		                                                WHERE   COMP_ID			= @COMP_ID
			                                                AND ESTTERM_REF_ID  = @ESTTERM_REF_ID_FROM ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID_FROM", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id_from;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID_TO", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id_to;
            paramArray[3]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[3].Value = create_date;
            paramArray[4]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value = create_user;

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
                        , int dept_ref_id
                        , string est_id)
        {
            string query = @"DELETE	EST_DEPT_EST_DETAIL
                                WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(DEPT_REF_ID     = @DEPT_REF_ID     OR @DEPT_REF_ID     = 0)
                                    AND	(EST_ID          = @EST_ID          OR @EST_ID              =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
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


        public int Count( int comp_id
                        , int estterm_ref_id
                        , int dept_ref_id
                        , string est_id
                        , string scale_id)

        {
            string query = @"SELECT COUNT(*) FROM EST_DEPT_EST_DETAIL
                                WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(DEPT_REF_ID     = @DEPT_REF_ID     OR @DEPT_REF_ID     = 0)
                                    AND	(EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(SCALE_ID        = @SCALE_ID        OR @SCALE_ID            =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SCALE_ID", SqlDbType.NVarChar);
            paramArray[4].Value = scale_id;

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