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
    public class Dac_QuestionPageStyles : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string q_style_id
                        , string q_style_name
                        , string q_style_desc
                        , string q_style_page_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_PAGE_STYLE
							    SET	  Q_STYLE_NAME	     = @Q_STYLE_NAME
                                    , Q_STYLE_DESC       = @Q_STYLE_DESC
                                    , Q_STYLE_PAGE_NAME  = @Q_STYLE_PAGE_NAME
							        , UPDATE_DATE	     = @UPDATE_DATE
							        , UPDATE_USER	     = @UPDATE_USER
							    WHERE Q_STYLE_ID         = @Q_STYLE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
            paramArray[0].Value = q_style_id;
            paramArray[1]       = CreateDataParameter("@Q_STYLE_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = q_style_name;
            paramArray[2]       = CreateDataParameter("@Q_STYLE_DESC", SqlDbType.NVarChar);
            paramArray[2].Value = q_style_desc;
            paramArray[3]       = CreateDataParameter("@Q_STYLE_PAGE_NAME", SqlDbType.NVarChar);
            paramArray[3].Value = q_style_page_name;
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

        public DataSet Select(string q_style_id)
        {
            string query = @"SELECT  Q_STYLE_ID
									,Q_STYLE_NAME
                                    ,Q_STYLE_DESC
                                    ,Q_STYLE_PAGE_NAME
                                    ,Q_YN
                                    ,SORT_ORDER
									,CREATE_DATE
									,CREATE_USER
									,UPDATE_DATE
									,UPDATE_USER 
                                FROM EST_QUESTION_PAGE_STYLE
                                    WHERE (Q_STYLE_ID =  @Q_STYLE_ID OR @Q_STYLE_ID   =''   )
                                ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
            paramArray[0].Value = q_style_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "LAYOUTTYPE", null, paramArray, CommandType.Text);

            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string q_style_id
                        , string q_style_name
                        , string q_style_desc
                        , string q_style_page_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_PAGE_STYLE(Q_STYLE_ID
												                ,Q_STYLE_NAME
                                                                ,Q_STYLE_DESC
                                                                ,Q_STYLE_PAGE_NAME
												                ,CREATE_DATE
												                ,CREATE_USER)
											            VALUES	( @Q_STYLE_ID
													            ,@Q_STYLE_NAME
                                                                ,@Q_STYLE_DESC
                                                                ,@Q_STYLE_PAGE_NAME
													            ,@CREATE_DATE
													            ,@CREATE_USER
													            )";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
            paramArray[0].Value = q_style_id;
            paramArray[1]       = CreateDataParameter("@Q_STYLE_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = q_style_name;
            paramArray[2]       = CreateDataParameter("@Q_STYLE_DESC", SqlDbType.NVarChar);
            paramArray[2].Value = q_style_desc;
            paramArray[3]       = CreateDataParameter("@Q_STYLE_PAGE_NAME", SqlDbType.NVarChar);
            paramArray[3].Value = q_style_page_name;
            paramArray[4]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[4].Value = create_date;
            paramArray[5]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
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


        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string q_style_id)
        {
            string query = @"DELETE	EST_QUESTION_PAGE_STYLE
							    WHERE	Q_STYLE_ID = @Q_STYLE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
            paramArray[0].Value = q_style_id;

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

        public int Count(string q_style_id)
        {
            string query = @"SELECT COUNT(Q_STYLE_ID) FROM EST_QUESTION_PAGE_STYLE
                                WHERE ( Q_STYLE_ID = @Q_STYLE_ID OR @Q_STYLE_ID       =''   )";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
            paramArray[0].Value = q_style_id;

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