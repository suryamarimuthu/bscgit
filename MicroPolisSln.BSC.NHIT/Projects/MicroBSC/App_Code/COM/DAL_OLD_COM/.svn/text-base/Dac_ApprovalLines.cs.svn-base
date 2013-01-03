using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class ApprovalLines : DbAgentBase
    {
        public ApprovalLines()
        {

        }

        public DataSet GetApprovalLine(string biz_type_code, int rep_emp_id)
        {
            string query = @"
                                SELECT A.*, B.* 
	                                FROM V_COM_EMPINFO_DETAIL A 
		                                JOIN COM_APPROVAL_LINE B ON A.EMP_REF_ID = B.APP_EMP_ID
	                                WHERE B.BIZ_TYPE_CODE = @BIZ_TYPE_CODE AND B.REP_EMP_ID = @REP_EMP_ID
                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;
            paramArray[1]               = CreateDataParameter("@REP_EMP_ID", SqlDbType.Int);
            paramArray[1].Value         = rep_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "APPROVALLINEGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool AddApprovaLline(int app_step, string biz_type_code, int rep_emp_id, int app_emp_id)
        {
            string query = @"
                            IF EXISTS	(SELECT * FROM COM_APPROVAL_LINE
			                             WHERE APP_STEP = @APP_STEP
			                             AND BIZ_TYPE_CODE = @BIZ_TYPE_CODE
	                                     AND REP_EMP_ID = @REP_EMP_ID
	                                     AND APP_EMP_ID = @APP_EMP_ID)
                            BEGIN
	                            DELETE FROM COM_APPROVAL_LINE
	                            WHERE APP_STEP = @APP_STEP
	                            AND BIZ_TYPE_CODE = @BIZ_TYPE_CODE
	                            AND REP_EMP_ID = @REP_EMP_ID
	                            AND APP_EMP_ID = @APP_EMP_ID	

	                            IF @@ERROR <> 0 RETURN
                            END

                            INSERT INTO	COM_APPROVAL_LINE(APP_STEP
			                            ,BIZ_TYPE_CODE
			                            ,REP_EMP_ID
			                            ,APP_EMP_ID
			                            )
		                            VALUES	(@APP_STEP
			                            ,@BIZ_TYPE_CODE
			                            ,@REP_EMP_ID
			                            ,@APP_EMP_ID
			                            )

                            IF @@ERROR <> 0 RETURN";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@APP_STEP", SqlDbType.Int);
            paramArray[0].Value         = app_step;
            paramArray[1]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = biz_type_code;
            paramArray[2]               = CreateDataParameter("@REP_EMP_ID", SqlDbType.Int);
            paramArray[2].Value         = rep_emp_id;
            paramArray[3]               = CreateDataParameter("@APP_EMP_ID", SqlDbType.Int);
            paramArray[3].Value         = app_emp_id;

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

        public bool RemoveApprovalLine(string biz_type_code, int rep_emp_id)
        {
            string query = @"DELETE	COM_APPROVAL_LINE
                                WHERE	
	                                BIZ_TYPE_CODE   = @BIZ_TYPE_CODE
                                AND	REP_EMP_ID      = @REP_EMP_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;
            paramArray[1]               = CreateDataParameter("@REP_EMP_ID", SqlDbType.Int);
            paramArray[1].Value         = rep_emp_id;

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

        public DataSet ApprovalLineEmpList(string biz_type_code, string emp_name, int dept_ref_id)
        {
            string query = @"SELECT A.*, 
	                        (SELECT BIZ_TYPE_CODE FROM COM_BIZ_INFO WHERE BIZ_TYPE_CODE = @BIZ_TYPE_CODE) AS BIZ_TYPE_CODE,
	                        (SELECT BIZ_TYPE_NAME FROM COM_BIZ_INFO WHERE BIZ_TYPE_CODE = @BIZ_TYPE_CODE) AS BIZ_TYPE_NAME,
	                        ISNULL(B.APP_CNT,0) AS APP_CNT,  A.EMP_REF_ID AS REP_EMP_ID
	                        FROM V_COM_EMPINFO_DETAIL A,
	                        (SELECT BIZ_TYPE_CODE, REP_EMP_ID, COUNT(*) AS APP_CNT 
                               FROM COM_APPROVAL_LINE 
	                          WHERE BIZ_TYPE_CODE=@BIZ_TYPE_CODE
	                          GROUP BY BIZ_TYPE_CODE, REP_EMP_ID) B,
	                        COM_EMP_ROLE_REL C
	                        WHERE A.EMP_REF_ID *= B.REP_EMP_ID
	                        AND C.ROLE_REF_ID = '3'
	                        AND A.EMP_REF_ID = C.EMP_REF_ID
	                        AND (A.EMP_NAME LIKE (@EMP_NAME + '%') OR @EMP_NAME ='')
	                        AND (A.DEPT_REF_ID=@DEPT_REF_ID OR @DEPT_REF_ID =0)
	                        ORDER BY A.DEPT_REF_ID, A.EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;
            paramArray[1]               = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = emp_name;
            paramArray[2]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "APPROVALEMPLIST", null, paramArray, CommandType.Text);
            return ds;
        }
    }
}
