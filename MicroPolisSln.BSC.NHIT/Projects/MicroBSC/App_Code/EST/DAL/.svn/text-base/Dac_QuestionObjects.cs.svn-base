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
    public class Dac_QuestionObjects : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string q_obj_id
                        , string q_obj_name
                        , string q_obj_title
                        , string q_obj_preface
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_QUESTION_OBJECT
                                SET	 Q_OBJ_NAME     = @Q_OBJ_NAME
	                                ,Q_OBJ_TITLE    = @Q_OBJ_TITLE
	                                ,Q_OBJ_PREFACE  = @Q_OBJ_PREFACE
	                                ,UPDATE_DATE    = @UPDATE_DATE
	                                ,UPDATE_USER    = @UPDATE_USER
                                WHERE	Q_OBJ_ID    = @Q_OBJ_ID";
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = q_obj_id;
	        paramArray[1] 		= CreateDataParameter("@Q_OBJ_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = q_obj_name;
	        paramArray[2] 		= CreateDataParameter("@Q_OBJ_TITLE", SqlDbType.NVarChar, 200);
	        paramArray[2].Value = q_obj_title;
	        paramArray[3] 		= CreateDataParameter("@Q_OBJ_PREFACE", SqlDbType.NVarChar, 2000);
	        paramArray[3].Value = q_obj_preface;
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

        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx 
                            , string est_id
                            , string q_obj_id)
        {
            string query = @"SELECT	 QEM.EST_ID
                                    ,INF.EST_NAME
                                    ,OBJ.Q_OBJ_ID
                                    ,OBJ.Q_OBJ_NAME
                                    ,OBJ.Q_OBJ_TITLE
                                    ,OBJ.Q_OBJ_PREFACE
                                    ,OBJ.CREATE_DATE
                                    ,OBJ.CREATE_USER
                                    ,OBJ.UPDATE_DATE
                                    ,OBJ.UPDATE_USER
                                FROM	 EST_QUESTION_OBJECT    OBJ
	                                JOIN EST_QUESTION_EST_MAP   QEM ON (QEM.Q_OBJ_ID    = OBJ.Q_OBJ_ID)
                                    JOIN EST_INFO               INF ON (INF.EST_ID      = QEM.EST_ID)
                                WHERE     (QEM.EST_ID      = @EST_ID   OR @EST_ID       =''    )
                                      AND (OBJ.Q_OBJ_ID    = @Q_OBJ_ID OR @Q_OBJ_ID     =''    )
                                    ORDER BY OBJ.Q_OBJ_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 10);
            paramArray[0].Value     = est_id;
	        paramArray[1] 		    = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value 	= q_obj_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "QUESTIONOBJECTGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet Select(string est_id
                            , string q_obj_id)
        {
            return Select(null, null , est_id, q_obj_id);
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , string q_obj_id
                        , string q_obj_name
                        , string q_obj_title
                        , string q_obj_preface
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_QUESTION_OBJECT(Q_OBJ_ID
			                                                ,Q_OBJ_NAME
			                                                ,Q_OBJ_TITLE
			                                                ,Q_OBJ_PREFACE
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@Q_OBJ_ID
			                                                ,@Q_OBJ_NAME
			                                                ,@Q_OBJ_TITLE
			                                                ,@Q_OBJ_PREFACE
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = q_obj_id;
	        paramArray[1] 		= CreateDataParameter("@Q_OBJ_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = q_obj_name;
	        paramArray[2] 		= CreateDataParameter("@Q_OBJ_TITLE", SqlDbType.NVarChar, 200);
	        paramArray[2].Value = q_obj_title;
	        paramArray[3] 		= CreateDataParameter("@Q_OBJ_PREFACE", SqlDbType.NVarChar, 2000);
	        paramArray[3].Value = q_obj_preface;
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
 
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string q_obj_id)
        {
            string query = @"DELETE	EST_QUESTION_OBJECT
                                WHERE	Q_OBJ_ID = @Q_OBJ_ID";
	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
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

        public int Count(string q_obj_id)
        {
            string query = @"SELECT COUNT(Q_OBJ_ID) FROM EST_QUESTION_OBJECT
                                WHERE (Q_OBJ_ID = @Q_OBJ_ID OR @Q_OBJ_ID     =''    )";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar, 20);
            paramArray[0].Value = q_obj_id;

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
