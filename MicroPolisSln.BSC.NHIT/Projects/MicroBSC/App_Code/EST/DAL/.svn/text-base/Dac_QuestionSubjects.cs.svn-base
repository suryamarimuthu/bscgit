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
    public class Dac_QuestionSubjects : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string q_sbj_id
                        , string q_obj_id
                        , string q_dfn_id
                        , int num
                        , string q_sbj_name
                        , double weight
                        , string q_sbj_define
                        , string q_sbj_desc
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_SUBJECT
                                SET	Q_OBJ_ID        = @Q_OBJ_ID
                                    ,Q_DFN_ID       = @Q_DFN_ID
	                                ,NUM            = @NUM
	                                ,Q_SBJ_NAME     = @Q_SBJ_NAME
	                                ,WEIGHT         = @WEIGHT
                                    ,Q_SBJ_DEFINE   = @Q_SBJ_DEFINE
                                    ,Q_SBJ_DESC     = @Q_SBJ_DESC
	                                ,UPDATE_DATE    = @UPDATE_DATE
	                                ,UPDATE_USER    = @UPDATE_USER
                                WHERE	Q_SBJ_ID    = @Q_SBJ_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_sbj_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;
            paramArray[2]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[2].Value = q_dfn_id;
            paramArray[3]       = CreateDataParameter("@NUM", SqlDbType.Int);
            paramArray[3].Value = num;
            paramArray[4]       = CreateDataParameter("@Q_SBJ_NAME", SqlDbType.NVarChar, 2000);
            paramArray[4].Value = q_sbj_name;
            paramArray[5]       = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[5].Value = weight;
            paramArray[6]       = CreateDataParameter("@Q_SBJ_DEFINE", SqlDbType.NVarChar, 2000);
            paramArray[6].Value = q_sbj_define;
            paramArray[7]       = CreateDataParameter("@Q_SBJ_DESC", SqlDbType.NVarChar, 1000);
            paramArray[7].Value = q_sbj_desc;
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

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , string q_sbj_id
                            , string q_obj_id
                            , string q_dfn_id)
        {
            string query = @"SELECT	 QS.Q_SBJ_ID
                                    ,QS.Q_OBJ_ID
                                    ,QO.Q_OBJ_NAME
                                    ,QS.Q_DFN_ID
                                    --,QD.NUM + ' ' + QD.Q_DFN_NAME AS Q_DFN_NAME
                                    , QD.Q_DFN_NAME AS Q_DFN_NAME
                                    ,QS.NUM
                                    ,QS.Q_SBJ_NAME
                                    ,QS.WEIGHT
                                    ,QS.Q_SBJ_DEFINE
                                    ,QS.Q_SBJ_DESC
                                    ,QS.CREATE_DATE
                                    ,QS.CREATE_USER
                                    ,QS.UPDATE_DATE
                                    ,QS.UPDATE_USER
                                FROM	        EST_QUESTION_SUBJECT    QS
                                JOIN	        EST_QUESTION_OBJECT     QO ON (QO.Q_OBJ_ID = QS.Q_OBJ_ID)
                                LEFT OUTER JOIN	EST_QUESTION_DEFINE     QD ON (QS.Q_DFN_ID = QD.Q_DFN_ID)
                                    WHERE	(QS.Q_SBJ_ID = @Q_SBJ_ID OR @Q_SBJ_ID     =''    )
                                        AND (QS.Q_OBJ_ID = @Q_OBJ_ID OR @Q_OBJ_ID     =''    )
                                        AND (QS.Q_DFN_ID = @Q_DFN_ID OR @Q_DFN_ID     =''    )
                                    ORDER BY QD.NUM + ' ' + QD.Q_DFN_NAME, QS.NUM, QO.Q_OBJ_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_sbj_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 10);
            paramArray[1].Value = q_obj_id;
            paramArray[2]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 10);
            paramArray[2].Value = q_dfn_id;

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONSUBJECTGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectByTgt(IDbConnection conn
                                , IDbTransaction trx
                                , int comp_id
                                , string est_id
                                , int tgt_emp_id
                                , string q_dfn_id)
        {
            string query = @"SELECT	 QS.Q_SBJ_ID
                                    ,''                             AS Q_OBJ_ID
                                    ,QS.Q_DFN_ID
                                    ,QD.NUM + ' ' + QD.Q_DFN_NAME   AS Q_DFN_NAME
                                    ,QS.NUM
                                    ,QS.Q_SBJ_NAME
                                    ,QS.WEIGHT
                                    ,QS.Q_SBJ_DEFINE
                                    ,QS.Q_SBJ_DESC
                                    ,QS.CREATE_DATE
                                    ,QS.CREATE_USER
                                    ,QS.UPDATE_DATE
                                    ,QS.UPDATE_USER
                                FROM	        EST_QUESTION_SUBJECT    QS
                                LEFT OUTER JOIN	EST_QUESTION_DEFINE     QD ON (QS.Q_DFN_ID = QD.Q_DFN_ID)
                                    WHERE	QS.Q_SBJ_ID IN (SELECT QS.Q_SBJ_ID FROM	 EST_EMP_POS_BIZ_MAP   PB
													                            JOIN EST_POS_BIZ_Q_SBJ_MAP QS ON (PB.POS_BIZ_ID = QS.POS_BIZ_ID)
											                            WHERE   QS.COMP_ID		= @COMP_ID
												                            AND QS.EST_ID		= @EST_ID
												                            AND PB.EMP_REF_ID	= @TGT_EMP_ID
											                            GROUP BY QS.Q_SBJ_ID)
			                            AND (QS.Q_DFN_ID = @Q_DFN_ID OR @Q_DFN_ID     =''    )
                                    ORDER BY QD.NUM + ' ' + QD.Q_DFN_NAME, QS.NUM";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 10);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[2].Value = tgt_emp_id;
            paramArray[3]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 10);
            paramArray[3].Value = q_dfn_id;
            
            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONSUBJECTGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select(string q_sbj_id, string q_obj_id, string q_dfn_id)
        {
            return Select(null, null, q_sbj_id, q_obj_id, q_dfn_id);
        }
       
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string q_sbj_id
                        , string q_obj_id
                        , string q_dfn_id
                        , int num
                        , string q_sbj_name
                        , double weight
                        , string q_sbj_define
                        , string q_sbj_desc
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_SUBJECT(Q_SBJ_ID
			                                                ,Q_OBJ_ID
                                                            ,Q_DFN_ID
			                                                ,NUM
			                                                ,Q_SBJ_NAME
			                                                ,WEIGHT
                                                            ,Q_SBJ_DEFINE
                                                            ,Q_SBJ_DESC
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@Q_SBJ_ID
			                                                ,@Q_OBJ_ID
                                                            ,@Q_DFN_ID
			                                                ,@NUM
			                                                ,@Q_SBJ_NAME
			                                                ,@WEIGHT
                                                            ,@Q_SBJ_DEFINE
                                                            ,@Q_SBJ_DESC
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_sbj_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;
            paramArray[2]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[2].Value = q_dfn_id;
            paramArray[3]       = CreateDataParameter("@NUM", SqlDbType.Int);
            paramArray[3].Value = num;
            paramArray[4]       = CreateDataParameter("@Q_SBJ_NAME", SqlDbType.NVarChar, 2000);
            paramArray[4].Value = q_sbj_name;
            paramArray[5]       = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[5].Value = weight;
            paramArray[6]       = CreateDataParameter("@Q_SBJ_DEFINE", SqlDbType.NVarChar, 2000);
            paramArray[6].Value = q_sbj_define;
            paramArray[7]       = CreateDataParameter("@Q_SBJ_DESC", SqlDbType.NVarChar, 1000);
            paramArray[7].Value = q_sbj_desc;
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

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string q_sbj_id
                        , string q_obj_id)
        {
            string query = @"DELETE	EST_QUESTION_SUBJECT
                                WHERE	(Q_SBJ_ID = @Q_SBJ_ID OR @Q_SBJ_ID     =''    )
                                    AND (Q_OBJ_ID = @Q_OBJ_ID OR @Q_OBJ_ID     =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_sbj_id;
            paramArray[1]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = q_obj_id;

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

        public int Count(string q_sbj_id)
        {
            string query = @"SELECT COUNT(Q_SBJ_ID) FROM EST_QUESTION_SUBJECT
                                WHERE (Q_SBJ_ID = @Q_SBJ_ID OR @Q_SBJ_ID     =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_sbj_id;

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
