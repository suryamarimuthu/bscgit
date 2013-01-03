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
	public class Dac_Grades : DbAgentBase
	{
		public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string grade_id
						, string grade_name
						, string grade_desc
						, DateTime update_date
						, int update_user )
		{
			string query = @"UPDATE	EST_GRADE
                                SET	 GRADE_NAME		= @GRADE_NAME
                                    ,GRADE_DESC	    = @GRADE_DESC
                                    ,UPDATE_DATE	= @UPDATE_DATE
                                    ,UPDATE_USER	= @UPDATE_USER
                                WHERE   COMP_ID     = @COMP_ID
                                    AND GRADE_ID    = @GRADE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(6);
		 
            paramArray[0] 		= CreateDataParameter( "@COMP_ID", SqlDbType.Int );
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter( "@GRADE_ID", SqlDbType.NVarChar );
			paramArray[1].Value = grade_id;
			paramArray[2] 		= CreateDataParameter( "@GRADE_NAME", SqlDbType.NVarChar );
			paramArray[2].Value = grade_name;
			paramArray[3] 		= CreateDataParameter( "@GRADE_DESC", SqlDbType.NVarChar );
			paramArray[3].Value = grade_desc;
			paramArray[4] 		= CreateDataParameter( "@UPDATE_DATE", SqlDbType.DateTime );
			paramArray[4].Value = update_date;
			paramArray[5] 		= CreateDataParameter( "@UPDATE_USER", SqlDbType.Int );
			paramArray[5].Value = update_user;

			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
        }

		public DataSet Select(int comp_id, string grade_id)
		{
			string query = @"SELECT  COMP_ID
                                    ,GRADE_ID
									,GRADE_NAME
									,GRADE_DESC
                                    ,SORT_ORDER
									,CREATE_DATE
									,CREATE_USER
									,UPDATE_DATE
									,UPDATE_USER 
                                FROM EST_GRADE
                                    WHERE   (COMP_ID    = @COMP_ID  OR @COMP_ID         =''    )
                                        AND (GRADE_ID   = @GRADE_ID OR @GRADE_ID        =''    )
                                ORDER BY SORT_ORDER";

			IDbDataParameter[] paramArray = CreateDataParameters(2);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar);
			paramArray[1].Value = grade_id;
                 
	        DataSet ds = DbAgentObj.FillDataSet( query, "GRADE" , null, paramArray, CommandType.Text );
	        return ds;
		}

		public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object grade_id
						, object grade_name
						, object grade_desc
						, object create_date
						, object create_user)
		{
			string query = @"INSERT INTO EST_GRADE(  COMP_ID
                                                    ,GRADE_ID
													,GRADE_NAME
													,GRADE_DESC
													,CREATE_DATE
													,CREATE_USER
													)
											VALUES	(@COMP_ID
                                                    ,@GRADE_ID
													,@GRADE_NAME
													,@GRADE_DESC
													,@CREATE_DATE
													,@CREATE_USER
													)";

			IDbDataParameter[] paramArray = CreateDataParameters(6);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar);
			paramArray[1].Value = grade_id;
			paramArray[2] 		= CreateDataParameter("@GRADE_NAME", SqlDbType.NVarChar);
			paramArray[2].Value = grade_name;
			paramArray[3] 		= CreateDataParameter("@GRADE_DESC", SqlDbType.NVarChar);
			paramArray[3].Value = grade_desc;
			paramArray[4] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
			paramArray[4].Value	= create_date;
			paramArray[5] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
			paramArray[5].Value	= create_user; 
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string grade_id )
        {
            string query = @"DELETE	EST_GRADE
							    WHERE	COMP_ID     = @COMP_ID
                                    AND GRADE_ID    = @GRADE_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(2);
		 
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
			paramArray[1] 		= CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar);
			paramArray[1].Value = grade_id;
		 
			try
			{
				int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
				return affectedRow;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
        }

        public int Count(int comp_id, string grade_id)
        {
            string query = @"SELECT COUNT(GRADE_ID) FROM EST_GRADE
							    WHERE	COMP_ID     = @COMP_ID
                                    AND GRADE_ID    = @GRADE_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
			paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar);
            paramArray[1].Value = grade_id;

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