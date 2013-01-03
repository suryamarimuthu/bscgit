using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_DeptGroupInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int est_dept_group_id
                        , string est_dept_group_name)
        {
            string query = @"UPDATE	EST_DEPT_GROUP_INFO
	                            SET	EST_DEPT_GROUP_NAME	= @EST_DEPT_GROUP_NAME
		                      WHERE	EST_DEPT_GROUP_ID	= @EST_DEPT_GROUP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_GROUP_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_group_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_GROUP_NAME", SqlDbType.VarChar, 50);
            paramArray[1].Value = est_dept_group_name;

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

        public DataSet Select(int est_dept_group_id)
        {
            string query = @"SELECT	EST_DEPT_GROUP_ID, EST_DEPT_GROUP_NAME
	                           FROM	EST_DEPT_GROUP_INFO 
		                      WHERE	(EST_DEPT_GROUP_ID = @EST_DEPT_GROUP_ID OR @EST_DEPT_GROUP_ID = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_GROUP_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_group_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTGROUPINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int est_dept_group_id
                        , string est_dept_group_name)
        {
            string query = @"INSERT INTO EST_DEPT_GROUP_INFO(EST_DEPT_GROUP_ID
			                                                ,EST_DEPT_GROUP_NAME
			                                                )
		                                                VALUES	(@EST_DEPT_GROUP_ID
			                                                ,@EST_DEPT_GROUP_NAME
			                                                )
                                                ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_GROUP_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_group_id;
            paramArray[1]       = CreateDataParameter("@EST_DEPT_GROUP_NAME", SqlDbType.VarChar, 50);
            paramArray[1].Value = est_dept_group_name;

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
                        , int est_dept_group_id)
        {
            string query = @"DELETE	EST_DEPT_GROUP_INFO
	                          WHERE EST_DEPT_GROUP_ID = @EST_DEPT_GROUP_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@EST_DEPT_GROUP_ID", SqlDbType.Int);
            paramArray[0].Value = est_dept_group_id;

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
    }
}
