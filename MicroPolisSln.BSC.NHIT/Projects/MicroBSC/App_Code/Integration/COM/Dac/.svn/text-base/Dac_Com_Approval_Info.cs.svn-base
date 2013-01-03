using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Approval_Info : DbAgentBase
    {
        public enum ApprovalStatus 
        {
            None = 0
            , Created = 1
            , Pending = 2
            , Ended = 3
        }

        public Dac_Com_Approval_Info()
        {

        }

        public bool ModifyApproval_Info(int app_ref_id, int appterm_ref_id, string app_code, string app_doc_no, int app_step_count, string app_status, int rep_emp_id, int app_emp_id, string rep_title, string rep_desc, DateTime rep_date, DateTime app_compdate)
        {
            string query = @"UPDATE	COM_APPROVAL_INFO
                                SET	APP_CODE        = @APP_CODE
	                                ,REP_EMP_ID     = @REP_EMP_ID
	                                ,APP_DOC_NO     = @APP_DOC_NO
	                                ,APP_STATUS     = @APP_STATUS
	                                ,APP_STEP_COUNT = @APP_STEP_COUNT
	                                ,REP_TITLE      = @REP_TITLE
	                                ,REP_DESC       = @REP_DESC
	                                ,REP_DATE       = @REP_DATE
	                                ,APP_COMPDATE   = @APP_COMPDATE
	                                ,APP_EMP_ID     = @APP_EMP_ID
	                                ,APPTERM_REF_ID = @APPTERM_REF_ID
                                WHERE	APP_REF_ID  = @APP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;
            paramArray[1]               = CreateDataParameter("@APP_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = app_code;
            paramArray[2]               = CreateDataParameter("@REP_EMP_ID", SqlDbType.Int);
            paramArray[2].Value         = rep_emp_id;
            paramArray[3]               = CreateDataParameter("@APP_DOC_NO", SqlDbType.VarChar);
            paramArray[3].Value         = app_doc_no;
            paramArray[4]               = CreateDataParameter("@APP_STATUS", SqlDbType.Char);
            paramArray[4].Value         = app_status;
            paramArray[5]               = CreateDataParameter("@APP_STEP_COUNT", SqlDbType.Int);
            paramArray[5].Value         = app_step_count;
            paramArray[6]               = CreateDataParameter("@REP_TITLE", SqlDbType.VarChar);
            paramArray[6].Value         = rep_title;
            paramArray[7]               = CreateDataParameter("@REP_DESC", SqlDbType.VarChar);
            paramArray[7].Value         = rep_desc;
            paramArray[8]               = CreateDataParameter("@REP_DATE", SqlDbType.DateTime);
            paramArray[8].Value         = rep_date;
            paramArray[9]               = CreateDataParameter("@APP_COMPDATE", SqlDbType.DateTime);
            paramArray[9].Value         = app_compdate;
            paramArray[10]              = CreateDataParameter("@APP_EMP_ID", SqlDbType.Int);
            paramArray[10].Value        = app_emp_id;
            paramArray[11]              = CreateDataParameter("@APPTERM_REF_ID", SqlDbType.Int);
            paramArray[11].Value        = appterm_ref_id;

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

        public DataSet GetApproval_Info(int app_ref_id)
        {
            string query = @"SELECT	T1.APP_REF_ID
	                            ,T1.APP_CODE
	                            ,T1.REP_EMP_ID
	                            ,T1.APP_DOC_NO
	                            ,T1.APP_STATUS
	                            ,T1.APP_STEP_COUNT
	                            ,T1.REP_TITLE
	                            ,T1.REP_DESC
	                            ,T1.REP_DATE
	                            ,T1.APP_COMPDATE
	                            ,T1.APP_EMP_ID
	                            ,T1.APPTERM_REF_ID
                            FROM	COM_APPROVAL_INFO T1
                            WHERE	T1.APP_REF_ID = @APP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "APPROVALINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetApproval_InfoByEmpID(int emp_ref_id, ApprovalStatus status)
        {
            string query = @"SELECT * FROM COM_APPROVAL_INFO WHERE (APP_STATUS = @APP_STATUS OR @APP_STATUS='*') and APP_EMP_ID = @APP_EMP_ID";

            string app_status = null;

            if (status == ApprovalStatus.None)
                app_status = "*";
            else if (status == ApprovalStatus.Created)
                app_status = "C";
            else if (status == ApprovalStatus.Pending)
                app_status = "P";
            else if (status == ApprovalStatus.Ended)
                app_status = "E";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@APP_EMP_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@APP_STATUS", SqlDbType.Char);
            paramArray[1].Value         = app_status;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "APPROVALINFOGET_1", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllApproval_Info()
        {
            string query = @"SELECT	T1.APP_REF_ID
	                            ,T1.APP_CODE
	                            ,T1.REP_EMP_ID
	                            ,T1.APP_DOC_NO
	                            ,T1.APP_STATUS
	                            ,T1.APP_STEP_COUNT
	                            ,T1.REP_TITLE
	                            ,T1.REP_DESC
	                            ,T1.REP_DATE
	                            ,T1.APP_COMPDATE
	                            ,T1.APP_EMP_ID
	                            ,T1.APPTERM_REF_ID
                            FROM	COM_APPROVAL_INFO T1";

            DataSet ds = DbAgentObj.FillDataSet(query, "APPROVALINFOGETALL", null, null, CommandType.Text);
            return ds;
        }


        public int SelectMaxAppRefID(IDbConnection conn
                                        , IDbTransaction trx)
        {
            int reVal = 1;

            string query = @"SELECT	MAX(APP_REF_ID) FROM	COM_APPROVAL_INFO ";

            object objMax = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            if (objMax != DBNull.Value)
            {
                reVal = DataTypeUtility.GetToInt32(objMax) + 1;
            }

            return reVal;
        }

        public int InsertApprovalinfo_DB(IDbConnection conn
                                        , IDbTransaction trx
                                        , object app_ref_id
                                        , object version_no
                                        , object app_code
                                        , object active_yn
                                        , object ori_doc
                                        , object title
                                        , object biz_type
                                        , object app_status
                                        , object draft_status
                                        , object create_user
                                        , object create_date)
        {
            string query = @"
INSERT INTO COM_APPROVAL_INFO
(APP_REF_ID
, VERSION_NO
, APP_CODE
, ACTIVE_YN
, TITLE
, BIZ_TYPE
, APP_STATUS
, DRAFT_STATUS
, CREATE_USER
, CREATE_DATE
, UPDATE_USER
, UPDATE_DATE)
VALUES
(@APP_REF_ID
, @VERSION_NO
, @APP_CODE
, @ACTIVE_YN
, @TITLE
, @BIZ_TYPE
, @APP_STATUS
, @DRAFT_STATUS
, @CREATE_USER
, @CREATE_DATE
, null
, null)

";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;
            paramArray[1]               = CreateDataParameter("@VERSION_NO", SqlDbType.Int);
            paramArray[1].Value         = version_no;
            paramArray[2]               = CreateDataParameter("@APP_CODE", SqlDbType.VarChar);
            paramArray[2].Value = app_code;
            paramArray[3] = CreateDataParameter("@ACTIVE_YN", SqlDbType.VarChar);
            paramArray[3].Value = active_yn;
            paramArray[4] = CreateDataParameter("@TITLE", SqlDbType.VarChar);
            paramArray[4].Value = title;
            paramArray[5] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = biz_type;
            paramArray[6] = CreateDataParameter("@APP_STATUS", SqlDbType.VarChar);
            paramArray[6].Value = app_status;
            paramArray[7] = CreateDataParameter("@DRAFT_STATUS", SqlDbType.VarChar);
            paramArray[7].Value = draft_status;
            paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user;
            paramArray[9] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value = create_date;

            int affectedRow         = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }

        public bool RemoveApprovalinfo(int app_ref_id)
        {
            string query = @"DELETE	COM_APPROVAL_INFO
                                WHERE	APP_REF_ID = @APP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public bool IsApproved(int emp_ref_id) 
        {

            string query = @" SELECT A.RESULT_MS
                                FROM   BSC_KPI_RESULT  A
                                        JOIN BSC_KPI_INFO B ON (A.KPI_REF_ID = B.KPI_REF_ID)
                                WHERE  (B.APPROVAL_EMP_ID       = @EMP_REF_ID OR @EMP_REF_ID = 0)
                                    AND A.CHECKSTATUS   = 'Y'
                                    AND A.CONFIRMSTATUS = 'Y'";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Approve", null, paramArray, CommandType.Text);

            if(ds.Tables[0].Rows.Count > 0)
                return true;
            
            return false;
        }

        public bool IsApproved() 
        {
            return IsApproved(0);
        }
    }
}
