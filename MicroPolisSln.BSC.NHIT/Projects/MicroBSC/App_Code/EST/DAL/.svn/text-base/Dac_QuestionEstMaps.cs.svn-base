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
    public class Dac_QuestionEstMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string est_id
                        , string q_obj_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_EST_MAP
                                SET	 UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                        WHERE	EST_ID      = @EST_ID
                                            AND	Q_OBJ_ID    = @Q_OBJ_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;
            paramArray[2]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = update_date;
            paramArray[3]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[3].Value = update_user;

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

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , string est_id
                            , string q_obj_id)
        {
            string query = @"SELECT	MAP.EST_ID
	                                ,MAP.Q_OBJ_ID
                                FROM	                EST_QUESTION_EST_MAP    MAP
                                    LEFT OUTER JOIN     EST_QUESTION_OBJECT     OBJ
                                        ON  MAP.Q_OBJ_ID    =   OBJ.Q_OBJ_ID
                                    WHERE	(MAP.EST_ID     = @EST_ID   OR @EST_ID          =''    )
                                        AND	(MAP.Q_OBJ_ID   = @Q_OBJ_ID OR @Q_OBJ_ID    ='')
                                ORDER BY OBJ.Q_OBJ_NAME ASC";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;
          

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONESTMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , string est_id)
        {
            string query = @"SELECT	 QM.EST_ID
                                    ,QM.Q_OBJ_ID
		                            ,QO.Q_OBJ_NAME
                                    ,QS.Q_SBJ_ID
		                            ,QS.Q_SBJ_NAME
                                FROM	 EST_QUESTION_EST_MAP QM
		                            JOIN EST_QUESTION_OBJECT  QO ON (QM.Q_OBJ_ID = QO.Q_OBJ_ID)
		                            JOIN EST_QUESTION_SUBJECT QS ON (QO.Q_OBJ_ID = QS.Q_OBJ_ID)
	                            WHERE QM.EST_ID = @EST_ID
		                            ORDER BY QO.Q_OBJ_NAME, QS.NUM";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = est_id;

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONESTMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select(string est_id
                            , string q_obj_id)
        {
            return Select(null, null, est_id, q_obj_id);
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string est_id
                        , string q_obj_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_EST_MAP(EST_ID
			                                                ,Q_OBJ_ID
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@EST_ID
			                                                ,@Q_OBJ_ID
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;
            paramArray[2]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = create_date;
            paramArray[3]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user;

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
                        , string est_id
                        , string q_obj_id)
        {
            string query = @"DELETE	EST_QUESTION_EST_MAP
                                WHERE	(EST_ID     = @EST_ID   OR @EST_ID          =''    )
                                    AND	(Q_OBJ_ID   = @Q_OBJ_ID OR @Q_OBJ_ID        =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx,query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count(string est_id, string q_obj_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_QUESTION_EST_MAP
                                WHERE	EST_ID = @EST_ID
                                AND	Q_OBJ_ID = @Q_OBJ_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = est_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;

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
