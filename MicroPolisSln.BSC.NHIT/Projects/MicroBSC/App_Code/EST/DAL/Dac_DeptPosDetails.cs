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
    public class Dac_DeptPosDetails : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object dept_ref_id
                        , object est_id
                        , object seq
                        , object seq_new
                        , object pos_id
                        , object pos_value
                        , object weight
                        , object update_date
                        , object update_user )
        {
            string query = @"UPDATE	EST_DEPT_POS_DETAIL
                                SET	 SEQ			    = CASE WHEN @SEQ_NEW      IS NULL THEN SEQ               ELSE @SEQ_NEW      END
                                    ,POS_ID				= CASE WHEN @POS_ID       IS NULL THEN POS_ID            ELSE @POS_ID       END
                                    ,POS_VALUE			= CASE WHEN @POS_VALUE    IS NULL THEN POS_VALUE         ELSE @POS_VALUE    END
                                    ,WEIGHT				= CASE WHEN @WEIGHT       IS NULL THEN WEIGHT            ELSE @WEIGHT       END
                                    ,UPDATE_DATE		= CASE WHEN @UPDATE_DATE  IS NULL THEN UPDATE_DATE       ELSE @UPDATE_DATE  END
                                    ,UPDATE_USER		= CASE WHEN @UPDATE_USER  IS NULL THEN UPDATE_USER       ELSE @UPDATE_USER  END
                                WHERE	(COMP_ID		 = @COMP_ID	            OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(DEPT_REF_ID     = @DEPT_REF_ID         OR @DEPT_REF_ID     = 0)
                                    AND	(EST_ID			 = @EST_ID              OR @EST_ID              =''    )
                                    AND	(SEQ			 = @SEQ	                OR @SEQ             = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[4].Value = seq;
            paramArray[5]       = CreateDataParameter("@SEQ_NEW", SqlDbType.Int);
            paramArray[5].Value = seq_new;
            paramArray[6]       = CreateDataParameter("@POS_ID", SqlDbType.NVarChar, 6);
            paramArray[6].Value = pos_id;
            paramArray[7]       = CreateDataParameter("@POS_VALUE", SqlDbType.NVarChar, 6);
            paramArray[7].Value = pos_value;
            paramArray[8]       = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[8].Value = weight;
            paramArray[9]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value = update_date;
            paramArray[10]      = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[10].Value= update_user;

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
                        , object seq
                        , object pos_id
                        , object pos_value
                        , object weight
                        , object update_date
                        , object update_user )
        {
            return Update(conn
                        , trx
                        , comp_id
                        , estterm_ref_id
                        , dept_ref_id
                        , est_id
                        , seq
                        , DBNull.Value
                        , pos_id
                        , pos_value
                        , weight
                        , update_date
                        , update_user );
        }

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , int comp_id
                            , int estterm_ref_id
                            , int dept_ref_id
                            , string est_id)
        {
            string query = @"SELECT	 COMP_ID
                                    ,ESTTERM_REF_ID
	                                ,DEPT_REF_ID
	                                ,EST_ID
	                                ,SEQ
	                                ,POS_ID
	                                ,POS_VALUE
	                                ,WEIGHT
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_DEPT_POS_DETAIL 
                                    WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                        AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                        AND	(DEPT_REF_ID     = @DEPT_REF_ID     OR @DEPT_REF_ID     = 0)
                                        AND	(EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    ORDER BY SEQ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter( "@ESTTERM_REF_ID", SqlDbType.Int );
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter( "@DEPT_REF_ID", SqlDbType.Int );
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter( "@EST_ID", SqlDbType.NVarChar );
            paramArray[3].Value = est_id;

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "DEPTPOSDETAILGET", null, paramArray, CommandType.Text );
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object estterm_ref_id
                        , object dept_ref_id
                        , object est_id
                        , object seq
                        , object pos_id
                        , object pos_value
                        , object weight
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO	EST_DEPT_POS_DETAIL( COMP_ID
                                                                ,ESTTERM_REF_ID
			                                                    ,DEPT_REF_ID
			                                                    ,EST_ID
			                                                    ,SEQ
			                                                    ,POS_ID
			                                                    ,POS_VALUE
			                                                    ,WEIGHT
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
		                                                    VALUES	(@COMP_ID
                                                                ,@ESTTERM_REF_ID
			                                                    ,@DEPT_REF_ID
			                                                    ,@EST_ID
			                                                    ,@SEQ
			                                                    ,@POS_ID
			                                                    ,@POS_VALUE
			                                                    ,@WEIGHT
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
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[4].Value = seq;
            paramArray[5]       = CreateDataParameter("@POS_ID", SqlDbType.NVarChar, 6);
            paramArray[5].Value = pos_id;
            paramArray[6]       = CreateDataParameter("@POS_VALUE", SqlDbType.NVarChar, 6);
            paramArray[6].Value = pos_value;
            paramArray[7]       = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[7].Value = weight;
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

        public int InsertDataFromTo(  IDbConnection conn
                                    , IDbTransaction trx
                                    , object comp_id
                                    , object estterm_ref_id_from
                                    , object estterm_ref_id_to
                                    , object create_date
                                    , object create_user)
        {
            string query = @"INSERT INTO	EST_DEPT_POS_DETAIL( COMP_ID
                                                                ,ESTTERM_REF_ID
			                                                    ,DEPT_REF_ID
			                                                    ,EST_ID
			                                                    ,SEQ
			                                                    ,POS_ID
			                                                    ,POS_VALUE
			                                                    ,WEIGHT
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
		                                              SELECT  @COMP_ID
		                                                    , @ESTTERM_REF_ID_TO
		                                                    , DEPT_REF_ID
		                                                    , EST_ID
		                                                    , SEQ
		                                                    , POS_ID
		                                                    , POS_VALUE
		                                                    , WEIGHT
		                                                    , @CREATE_DATE
		                                                    , @CREATE_USER
		                                                    , NULL
		                                                    , NULL
	                                                    FROM EST_DEPT_POS_DETAIL
		                                                    WHERE   COMP_ID			= @COMP_ID
			                                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID_FROM";

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
                        , string est_id
						, int seq )
        {
            string query = @"DELETE	EST_DEPT_POS_DETAIL
                                WHERE	(COMP_ID		 = @COMP_ID	            OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(DEPT_REF_ID     = @DEPT_REF_ID         OR @DEPT_REF_ID     = 0)
                                    AND	(EST_ID			 = @EST_ID              OR @EST_ID              =''    )
                                    AND	(SEQ			 = @SEQ	                OR @SEQ             = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[3].Value = est_id;
            paramArray[4]       = CreateDataParameter("@SEQ", SqlDbType.Int);
            paramArray[4].Value = seq;

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
						, int seq
						, string pos_id 
						, string pos_value )
        {
            string query = @"SELECT COUNT(*) FROM EST_DEPT_POS_DETAIL
                                WHERE	(COMP_ID		 = @COMP_ID	            OR @COMP_ID         = 0)
                                    AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(DEPT_REF_ID     = @DEPT_REF_ID         OR @DEPT_REF_ID     = 0)
                                    AND	(EST_ID			 = @EST_ID              OR @EST_ID              =''    )
                                    AND	(SEQ			 = @SEQ	                OR @SEQ             = 0)
                                    AND	(POS_ID		     = @POS_ID	            OR @POS_ID              =''    )
                                    AND	(POS_VALUE       = @POS_VALUE	        OR @POS_VALUE           =''    )";

			IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
			paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
			paramArray[1].Value = estterm_ref_id;
			paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
			paramArray[2].Value = dept_ref_id;
			paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
			paramArray[3].Value = est_id;
			paramArray[4]       = CreateDataParameter("@SEQ", SqlDbType.Int);
			paramArray[4].Value = seq;
			paramArray[5]       = CreateDataParameter("@POS_ID", SqlDbType.NVarChar);
			paramArray[5].Value = pos_id;
			paramArray[6]       = CreateDataParameter("@POS_VALUE", SqlDbType.NVarChar);
			paramArray[6].Value = pos_value;

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

        public int NewIdx(int comp_id, int estterm_ref_id, int dept_ref_id, string est_id)
        {
            string query = @"SELECT MAX(SEQ) FROM EST_DEPT_POS_DETAIL
                                WHERE	COMP_ID         = @COMP_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND	DEPT_REF_ID     = @DEPT_REF_ID
                                    AND	EST_ID          = @EST_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = dept_ref_id;
            paramArray[3]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[3].Value = est_id;

			try
			{
				object max = DbAgentObj.ExecuteScalar( query, paramArray, CommandType.Text );

				if ( max == DBNull.Value )
					return 1;

				return DataTypeUtility.GetToInt32(max) + 1;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
        }
    }
}