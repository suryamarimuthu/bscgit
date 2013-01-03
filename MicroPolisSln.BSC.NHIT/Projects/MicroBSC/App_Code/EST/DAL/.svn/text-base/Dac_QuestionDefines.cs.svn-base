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
    public class Dac_QuestionDefines : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string q_dfn_id
                        , string num
                        , string q_dfn_name
                        , string q_dfn_define
                        , string q_dfn_notice
                        , string q_dfn_desc
                        , string est_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_DEFINE
                                SET	NUM           = @NUM
	                                ,Q_DFN_NAME   = @Q_DFN_NAME
	                                ,Q_DFN_DEFINE = @Q_DFN_DEFINE
	                                ,Q_DFN_NOTICE = @Q_DFN_NOTICE
	                                ,Q_DFN_DESC   = @Q_DFN_DESC
	                                ,EST_ID       = @EST_ID
	                                ,UPDATE_DATE  = @UPDATE_DATE
	                                ,UPDATE_USER  = @UPDATE_USER
                                WHERE	Q_DFN_ID  = @Q_DFN_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_dfn_id;
            paramArray[1]       = CreateDataParameter("@NUM", SqlDbType.NVarChar,10);
            paramArray[1].Value = num;
            paramArray[2]       = CreateDataParameter("@Q_DFN_NAME", SqlDbType.NVarChar, 200);
            paramArray[2].Value = q_dfn_name;
            paramArray[3]       = CreateDataParameter("@Q_DFN_DEFINE", SqlDbType.NVarChar, 4000);
            paramArray[3].Value = q_dfn_define;
            paramArray[4]       = CreateDataParameter("@Q_DFN_NOTICE", SqlDbType.NVarChar, 4000);
            paramArray[4].Value = q_dfn_notice;
            paramArray[5]       = CreateDataParameter("@Q_DFN_DESC", SqlDbType.NVarChar, 2000);
            paramArray[5].Value = q_dfn_desc;
            paramArray[6]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[6].Value = est_id;
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

        public DataSet Select(string q_dfn_id, string est_id)
        {
            string query = @"SELECT  QD.Q_DFN_ID
                                    ,QD.NUM
                                    ,QD.NUM + ' ' + QD.Q_DFN_NAME AS Q_DFN_NAME
                                    ,QD.Q_DFN_DEFINE
                                    ,QD.Q_DFN_NOTICE
                                    ,QD.Q_DFN_DESC
                                    ,QD.EST_ID
                                    ,EI.EST_NAME
                                    ,QD.CREATE_DATE
                                    ,QD.CREATE_USER
                                    ,QD.UPDATE_DATE
                                    ,QD.UPDATE_USER
                                FROM	 EST_QUESTION_DEFINE    QD
                                    JOIN EST_INFO               EI ON (QD.EST_ID = EI.EST_ID)
                                WHERE	(QD.Q_DFN_ID = @Q_DFN_ID OR @Q_DFN_ID      =''    )
                                    AND (QD.EST_ID   = @EST_ID   OR @EST_ID        =''    )
                                ORDER BY QD.NUM";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_dfn_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = est_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONDEFINEGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string q_dfn_id
                        , string num
                        , string q_dfn_name
                        , string q_dfn_define
                        , string q_dfn_notice
                        , string q_dfn_desc
                        , string est_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_DEFINE(Q_DFN_ID
			                                                ,NUM
			                                                ,Q_DFN_NAME
			                                                ,Q_DFN_DEFINE
			                                                ,Q_DFN_NOTICE
			                                                ,Q_DFN_DESC
			                                                ,EST_ID
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@Q_DFN_ID
			                                                ,@NUM
			                                                ,@Q_DFN_NAME
			                                                ,@Q_DFN_DEFINE
			                                                ,@Q_DFN_NOTICE
			                                                ,@Q_DFN_DESC
			                                                ,@EST_ID
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_dfn_id;
            paramArray[1]       = CreateDataParameter("@NUM", SqlDbType.NVarChar,10);
            paramArray[1].Value = num;
            paramArray[2]       = CreateDataParameter("@Q_DFN_NAME", SqlDbType.NVarChar, 200);
            paramArray[2].Value = q_dfn_name;
            paramArray[3]       = CreateDataParameter("@Q_DFN_DEFINE", SqlDbType.NVarChar, 4000);
            paramArray[3].Value = q_dfn_define;
            paramArray[4]       = CreateDataParameter("@Q_DFN_NOTICE", SqlDbType.NVarChar, 4000);
            paramArray[4].Value = q_dfn_notice;
            paramArray[5]       = CreateDataParameter("@Q_DFN_DESC", SqlDbType.NVarChar, 2000);
            paramArray[5].Value = q_dfn_desc;
            paramArray[6]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[6].Value = est_id;
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
                        , string q_dfn_id)
        {
            string query = @"DELETE	EST_QUESTION_DEFINE
                                WHERE Q_DFN_ID = @Q_DFN_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_dfn_id;

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

        public int Count(string q_dfn_id)
        {
            string query = @"SELECT COUNT(Q_DFN_ID) FROM EST_QUESTION_DEFINE
                                WHERE (Q_DFN_ID = @Q_DFN_ID OR @Q_DFN_ID     =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_DFN_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_dfn_id;

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
