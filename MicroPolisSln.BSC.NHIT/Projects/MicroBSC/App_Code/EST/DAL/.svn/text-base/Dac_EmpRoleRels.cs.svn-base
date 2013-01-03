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
    public class Dac_EmpRoleRels : DbAgentBase
    {
	    public DataSet Select(IDbConnection conn
                            , IDbTransaction trx
                            , int emp_ref_id
                            , int role_ref_id)
        {
            string query = @"SELECT	 EMP_REF_ID
		                            ,ROLE_REF_ID
                            FROM	COM_EMP_ROLE_REL 
	                            WHERE	(EMP_REF_ID	 = @EMP_REF_ID	OR @EMP_REF_ID  = 0)
		                            AND	(ROLE_REF_ID = @ROLE_REF_ID OR @ROLE_REF_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;
	        paramArray[1] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = role_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "EMPROLERELGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int emp_ref_id
                        , int role_ref_id)
        {
            string query = @"INSERT INTO COM_EMP_ROLE_REL(EMP_REF_ID
			                                            ,ROLE_REF_ID
			                                            )
		                                            VALUES	(@EMP_REF_ID
			                                            ,@ROLE_REF_ID
			                                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;
	        paramArray[1] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = role_ref_id;
         
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
                        , int emp_ref_id
                        , int role_ref_id)
        {
            string query = @"DELETE	COM_EMP_ROLE_REL
	                            WHERE	(EMP_REF_ID	 = @EMP_REF_ID	OR @EMP_REF_ID  = 0)
		                            AND	(ROLE_REF_ID = @ROLE_REF_ID OR @ROLE_REF_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;
	        paramArray[1] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = role_ref_id;
         
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
