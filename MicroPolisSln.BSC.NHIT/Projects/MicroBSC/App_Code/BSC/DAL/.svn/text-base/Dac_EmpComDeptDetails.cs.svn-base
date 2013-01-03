using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_EmpComDeptDetails : DbAgentBase
    {
        public DataSet GetEmpComdeptdetail(int emp_ref_id, int dept_ref_id)
        {
            string query = @"SELECT	EMP_REF_ID
	                               ,DEPT_REF_ID
                               FROM	BSC_EMP_COM_DEPT_DETAIL 
	                          WHERE	(EMP_REF_ID	 = @EMP_REF_ID  OR @EMP_REF_ID  = 0)
		                        AND	(DEPT_REF_ID = @DEPT_REF_ID OR @DEPT_REF_ID = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = dept_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EMPCOMDEPTDETAILGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool IsEmpComDeptDetail(int emp_ref_id, int dept_ref_id) 
        {
            string query = @"SELECT COUNT(*) 
                               FROM BSC_EMP_COM_DEPT_DETAIL
				              WHERE	EMP_REF_ID	= @EMP_REF_ID
					            AND	DEPT_REF_ID = @DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = dept_ref_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAccessRightEstDept(int estterm_ref_id, int est_dept_ref_id, int emp_ref_id) 
        {
            string query = @"SELECT COUNT(DEPT_REF_ID)
                               FROM BSC_EMP_COM_DEPT_DETAIL 
                              WHERE EMP_REF_ID  = @EMP_REF_ID
                                AND DEPT_REF_ID IN (SELECT DEPT_REF_ID
                                                     FROM EST_DEPT_INFO
                                                    WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                      AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID)";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;


            int affectedRow = 0;
            try
            {
                DataSet rDs = DbAgentObj.Fill(query, paramArray, CommandType.Text);

                if (rDs.Tables.Count > 0)
                {
                    affectedRow = int.Parse(rDs.Tables[0].Rows[0][0].ToString());
                }

                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool AddEmpComDeptDetail(IDbConnection conn
                                        , IDbTransaction trx
                                        , int emp_ref_id
                                        , int dept_ref_id
                                        , int create_user)
        {
            string query = @"INSERT INTO BSC_EMP_COM_DEPT_DETAIL(EMP_REF_ID
		                                                        ,DEPT_REF_ID
                                                                ,CREATE_USER
                                                                ,CREATE_DATE
                                                                ,UPDATE_USER
                                                                ,UPDATE_DATE

		                                                        )
	                                                            VALUES 
                                                                (@EMP_REF_ID
		                                                        ,@DEPT_REF_ID
                                                                ,@CREATE_USER
                                                                ,GETDATE()
                                                                ,@CREATE_USER
                                                                ,GETDATE()
		                                                        )";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = dept_ref_id;
            paramArray[2]               = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[2].Value         = create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx,GetQueryStringReplace(query), paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddEmpComDeptDetail(  int emp_ref_id
                                        , int dept_ref_id
                                        , int create_user)
        {
            string query = @"INSERT INTO BSC_EMP_COM_DEPT_DETAIL(EMP_REF_ID
		                                                        ,DEPT_REF_ID
                                                                ,CREATE_USER
                                                                ,CREATE_DATE
                                                                ,UPDATE_USER
                                                                ,UPDATE_DATE

		                                                        )
	                                                            VALUES 
                                                                (@EMP_REF_ID
		                                                        ,@DEPT_REF_ID
                                                                ,@CREATE_USER
                                                                ,GETDATE()
                                                                ,@CREATE_USER
                                                                ,GETDATE()
		                                                        )";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = dept_ref_id;
            paramArray[2]               = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[2].Value         = create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringReplace(query), paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveEmpComDeptDetail(IDbConnection conn, IDbTransaction trx, int emp_ref_id)
        {
            string query = @"DELETE	BSC_EMP_COM_DEPT_DETAIL
	                          WHERE	EMP_REF_ID	= @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveEmpComDeptDetail(int emp_ref_id)
        {
            string query = @"DELETE	BSC_EMP_COM_DEPT_DETAIL
	                          WHERE	EMP_REF_ID	= @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 기간별 권한있는 부서의 최소값에 해당하는 평가부서
        /// </summary>
        /// <param name="estterm_ref_id"></param>
        /// <param name="emp_ref_id"></param>
        /// <returns></returns>
        public int GetTopEstDeptPerEesterm(int estterm_ref_id, int emp_ref_id)
        {
            string query = @"SELECT EST_DEPT_REF_ID
                               FROM EST_DEPT_INFO
                              WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND DEPT_REF_ID =
                                    (
                                     SELECT MIN(DEPT_REF_ID)
                                       FROM BSC_EMP_COM_DEPT_DETAIL 
                                      WHERE EMP_REF_ID  = @EMP_REF_ID
                                        AND DEPT_REF_ID IN (SELECT DEPT_REF_ID
                                                              FROM EST_DEPT_INFO
                                                             WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID)
                                    )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;

            try
            {
                DataSet ds = DbAgentObj.FillDataSet(query, "EMPCOMDEPTDETAILGET", null, paramArray, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()));
                }
                
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
        }
    }
}
