using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class Approval_Infos : DbAgentBase
    {
        public enum ApprovalStatus 
        {
            None = 0
            , Created = 1
            , Pending = 2
            , Ended = 3
        }

        public Approval_Infos()
        {

        }

        public Approval_Infos(int app_ref_id)
        {
            DataSet ds = GetApproval_Info(app_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _app_ref_id     = Convert.ToInt32(dr["APP_REF_ID"]);
                _app_code       = Convert.ToString(dr["APP_CODE"]);
                _rep_emp_id     = Convert.ToInt32(dr["REP_EMP_ID"]);
                _app_doc_no     = Convert.ToString(dr["APP_DOC_NO"]);
                _app_status     = Convert.ToString(dr["APP_STATUS"]);
                _app_step_count = Convert.ToInt32(dr["APP_STEP_COUNT"]);
                _rep_title      = Convert.ToString(dr["REP_TITLE"]);
                _rep_desc       = Convert.ToString(dr["REP_DESC"]);
                _rep_date       = Convert.ToDateTime(dr["REP_DATE"]);
                _app_compdate   = Convert.ToDateTime(dr["APP_COMPDATE"]);
                //_app_emp_id   = Convert.ToInt32(dr["APP_EMP_ID"]);
                _appterm_ref_id = Convert.ToInt32(dr["APPTERM_REF_ID"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _app_ref_id ;
        private string _app_code;
        private int _rep_emp_id;
        private string _app_doc_no;
        private string _app_status;
        private int _app_step_count;
        private string _rep_title;
        private string _rep_desc;
        private DateTime _rep_date;
        private DateTime _app_compdate;
        private int _app_emp_id;
        private int _appterm_ref_id;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int App_Ref_ID
        {
            get
            {
                return _app_ref_id;
            }
            set
            {
                _app_ref_id = value;
            }
        }

        public string App_Code
        {
            get
            {
                return _app_code;
            }
            set
            {
                _app_code = (value == null ? "" : value);
            }
        }

        public int Rep_Emp_ID
        {
            get
            {
                return _rep_emp_id;
            }
            set
            {
                _rep_emp_id = value;
            }
        }

        public string App_Doc_No
        {
            get
            {
                return _app_doc_no;
            }
            set
            {
                _app_doc_no = (value == null ? "" : value);
            }
        }

        public string App_Status
        {
            get
            {
                return _app_status;
            }
            set
            {
                _app_status = (value == null ? "" : value);
            }
        }

        public int App_Step_Count
        {
            get
            {
                return _app_step_count;
            }
            set
            {
                _app_step_count = value;
            }
        }

        public string Rep_Title
        {
            get
            {
                return _rep_title;
            }
            set
            {
                _rep_title = (value == null ? "" : value);
            }
        }

        public string Rep_Desc
        {
            get
            {
                return _rep_desc;
            }
            set
            {
                _rep_desc = (value == null ? "" : value);
            }
        }

        public DateTime Rep_Date
        {
            get
            {
                return _rep_date;
            }
            set
            {
                _rep_date = value;
            }
        }

        public DateTime App_Compdate
        {
            get
            {
                return _app_compdate;
            }
            set
            {
                _app_compdate = value;
            }
        }

        public int App_Emp_ID
        {
            get
            {
                return _app_emp_id;
            }
            set
            {
                _app_emp_id = value;
            }
        }

        public int Appterm_Ref_ID
        {
            get
            {
                return _appterm_ref_id;
            }
            set
            {
                _appterm_ref_id = value;
            }
        }
        #endregion

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

        public bool AddApprovalinfo(int app_ref_id, int appterm_ref_id, string app_code, string app_doc_no, int app_step_count, string app_status, int rep_emp_id, int app_emp_id, string rep_title, string rep_desc, DateTime rep_date, DateTime app_compdate)
        {
            string query = @"INSERT INTO COM_APPROVAL_INFO(APP_REF_ID
			                                                ,APP_CODE
			                                                ,REP_EMP_ID
			                                                ,APP_DOC_NO
			                                                ,APP_STATUS
			                                                ,APP_STEP_COUNT
			                                                ,REP_TITLE
			                                                ,REP_DESC
			                                                ,REP_DATE
			                                                ,APP_COMPDATE
			                                                ,APP_EMP_ID
			                                                ,APPTERM_REF_ID
			                                                )
		                                                VALUES	(@APP_REF_ID
			                                                ,@APP_CODE
			                                                ,@REP_EMP_ID
			                                                ,@APP_DOC_NO
			                                                ,@APP_STATUS
			                                                ,@APP_STEP_COUNT
			                                                ,@REP_TITLE
			                                                ,@REP_DESC
			                                                ,@REP_DATE
			                                                ,@APP_COMPDATE
			                                                ,@APP_EMP_ID
			                                                ,@APPTERM_REF_ID
			                                                )";

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

        public int GetDeptID(int emp_ref_id) 
        {
            string query = @"SELECT 
	                                CASE A.DEPT_LEVEL 
		                                WHEN 4 THEN
                                                (SELECT EST_DEPT_REF_ID FROM EST_DEPT_INFO 
                                                        WHERE EST_DEPT_REF_ID = A.UP_EST_DEPT_ID)
                                                        ELSE
                                                           A.EST_DEPT_REF_ID
                                                        END AS EST_DEPT_REF_ID
                                                        , UP_EST_DEPT_ID
                                                FROM 
                                                      EST_DEPT_INFO A
                                                    , REL_DEPT_EMP  B 
                                                WHERE A.DEPT_REF_ID     = B.DEPT_REF_ID 
                                                    AND B.EMP_REF_ID    = @EMP_REF_ID
                                                ORDER BY A.ESTTERM_REF_ID DESC";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DEPT", null, paramArray, CommandType.Text);

            int dept_id                 = 0;
            
            if(ds.Tables[0].Rows.Count > 0)
                dept_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            
            return dept_id;
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
