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
    public class Dac_QuestionItems : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string q_itm_id
                        , string q_sbj_id
                        , int num
                        , string q_item_name
                        , double point
                        , string comment
                        , string subject_item_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"
UPDATE	EST_QUESTION_ITEM 
    SET	Q_SBJ_ID          = @Q_SBJ_ID
        , NUM             = @NUM
        , Q_ITEM_NAME     = @Q_ITEM_NAME
        , POINT           = @POINT
        , COMMENT         = @COMMENT_TEXT
        , SUBJECT_ITEM_YN = @SUBJECT_ITEM_YN
        , UPDATE_DATE     = @UPDATE_DATE
        , UPDATE_USER     = @UPDATE_USER
    WHERE
        Q_ITM_ID          = @Q_ITM_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_itm_id;
            paramArray[1]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_sbj_id;
            paramArray[2]       = CreateDataParameter("@NUM", SqlDbType.Int);
            paramArray[2].Value = num;
            paramArray[3]       = CreateDataParameter("@Q_ITEM_NAME", SqlDbType.NVarChar, 200);
            paramArray[3].Value = q_item_name;
            paramArray[4]       = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[4].Value = point;
            paramArray[5]       = CreateDataParameter("@COMMENT_TEXT", SqlDbType.NVarChar);
            paramArray[5].Value = comment;
            paramArray[6]       = CreateDataParameter("@SUBJECT_ITEM_YN", SqlDbType.NChar);
            paramArray[6].Value = subject_item_yn;
            paramArray[7]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[7].Value = update_date;
            paramArray[8]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[8].Value = update_user;

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
                            , string q_itm_id
                            , string q_sbj_id
                            , string q_obj_id)
        {
            string query = @"SELECT  QO.Q_OBJ_ID
                                    ,QO.Q_OBJ_NAME
                                    ,QS.Q_SBJ_NAME	 
                                    ,QI.Q_ITM_ID
                                    ,QI.Q_SBJ_ID
                                    ,QI.NUM
                                    ,QI.Q_ITEM_NAME
                                    ,QI.Q_ITEM_NAME + CASE WHEN QI.COMMENT = '' THEN '' ELSE ' (' + QI.COMMENT + ')' END AS Q_ITEM_DESC
                                    ,QD.Q_DFN_NAME
                                    ,QI.POINT
                                    ,QS.WEIGHT
                                    ,QI.COMMENT
                                    ,QI.SUBJECT_ITEM_YN
                                    ,QS.Q_DFN_ID
                                    ,QI.CREATE_DATE
                                    ,QI.CREATE_USER
                                    ,QI.UPDATE_DATE
                                    ,QI.UPDATE_USER
                                FROM	            EST_QUESTION_ITEM       QI 
                                    JOIN	        EST_QUESTION_SUBJECT    QS ON (QS.Q_SBJ_ID = QI.Q_SBJ_ID)
                                    LEFT OUTER JOIN	EST_QUESTION_DEFINE     QD ON (QS.Q_DFN_ID = QD.Q_DFN_ID)
                                    JOIN            EST_QUESTION_OBJECT     QO ON (QO.Q_OBJ_ID = QS.Q_OBJ_ID)
                                WHERE	(QI.Q_ITM_ID = @Q_ITM_ID OR @Q_ITM_ID     =''    )
                                    AND (QI.Q_SBJ_ID = @Q_SBJ_ID OR @Q_SBJ_ID     =''    )
                                    AND (QO.Q_OBJ_ID = @Q_OBJ_ID OR @Q_OBJ_ID     =''    )
                                ORDER BY QO.Q_OBJ_NAME, QD.Q_DFN_NAME, QS.Q_SBJ_NAME, QI.NUM desc";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 10);
            paramArray[0].Value = q_itm_id;
            paramArray[1]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 10);
            paramArray[1].Value = q_sbj_id;
            paramArray[2]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 10);
            paramArray[2].Value = q_obj_id;

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONITEMGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select(string q_itm_id, string q_sbj_id, string q_obj_id)
        {
            return Select(null, null, q_itm_id, q_sbj_id, q_obj_id);
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string q_itm_id
                        , string q_sbj_id
                        , int num
                        , string q_item_name
                        , double point
                        , string comment
                        , string subject_item_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_ITEM(Q_ITM_ID
			                                                ,Q_SBJ_ID
			                                                ,NUM
			                                                ,Q_ITEM_NAME
			                                                ,POINT
			                                                ,COMMENT
			                                                ,SUBJECT_ITEM_YN
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@Q_ITM_ID
			                                                ,@Q_SBJ_ID
			                                                ,@NUM
			                                                ,@Q_ITEM_NAME
			                                                ,@POINT
			                                                ,@COMMENT_TEXT
			                                                ,@SUBJECT_ITEM_YN
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_itm_id;
            paramArray[1]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_sbj_id;
            paramArray[2]       = CreateDataParameter("@NUM", SqlDbType.Int);
            paramArray[2].Value = num;
            paramArray[3]       = CreateDataParameter("@Q_ITEM_NAME", SqlDbType.NVarChar, 200);
            paramArray[3].Value = q_item_name;
            paramArray[4]       = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[4].Value = point;
            paramArray[5]       = CreateDataParameter("@COMMENT_TEXT", SqlDbType.NVarChar, 2000);
            paramArray[5].Value = comment;
            paramArray[6]       = CreateDataParameter("@SUBJECT_ITEM_YN", SqlDbType.NChar);
            paramArray[6].Value = subject_item_yn;
            paramArray[7]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[7].Value = create_date;
            paramArray[8]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user;

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
                        , string q_itm_id
                        , string q_sbj_id)
        {
            string query = @"DELETE	EST_QUESTION_ITEM
                                WHERE   (Q_ITM_ID = @Q_ITM_ID OR @Q_ITM_ID     =''    )
                                    AND (Q_SBJ_ID = @Q_SBJ_ID OR @Q_SBJ_ID     =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_itm_id;
            paramArray[1]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_sbj_id;

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

        public int DeleteByQObjID(IDbConnection conn
                                , IDbTransaction trx
                                , string q_obj_id)
        {
            string query = @"DELETE EST_QUESTION_ITEM
                                WHERE Q_SBJ_ID IN (SELECT Q_SBJ_ID FROM EST_QUESTION_SUBJECT
                                                        WHERE Q_OBJ_ID = @Q_OBJ_ID)";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_obj_id;

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

        public int Count(string q_itm_id)
        {
            string query = @"SELECT COUNT(Q_ITM_ID) FROM EST_QUESTION_ITEM
                                WHERE	Q_ITM_ID = @Q_ITM_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_itm_id;

            try
            {
                return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}