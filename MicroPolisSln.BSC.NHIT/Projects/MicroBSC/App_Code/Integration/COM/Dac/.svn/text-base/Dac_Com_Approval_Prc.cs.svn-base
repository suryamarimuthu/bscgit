using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Approval_Prc : DbAgentBase
    {
        public enum ApprovalStatus
        {
            None = 0
            ,
            Created = 1
          ,
            Pending = 2
          , Ended = 3
        }

        public Dac_Com_Approval_Prc()
        {
        }

        public Dac_Com_Approval_Prc(int app_ref_id, int app_step)
        {
            DataSet ds = GetApprovalPrc(app_ref_id, app_step);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _app_ref_id = Convert.ToInt32(dr["APP_REF_ID"]);
                _app_step = Convert.ToInt32(dr["APP_STEP"]);
                _app_step_status = Convert.ToInt32(dr["APP_STEP_STATUS"]);
                _app_status = Convert.ToString(dr["APP_STATUS"]);
                _app_date = Convert.ToDateTime(dr["APP_DATE"]);
                _app_flag = Convert.ToInt16(dr["APP_FLAG"]);
                _app_remark = Convert.ToString(dr["APP_REMARK"]);
                _app_emp_id = Convert.ToInt32(dr["APP_EMP_ID"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _app_ref_id;
        private int _app_step;
        private int _app_step_status;
        private string _app_status;
        private DateTime _app_date;
        private short _app_flag;
        private string _app_remark;
        private int _app_emp_id;
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

        public int App_Step
        {
            get
            {
                return _app_step;
            }
            set
            {
                _app_step = value;
            }
        }

        public int App_Step_Status
        {
            get
            {
                return _app_step_status;
            }
            set
            {
                _app_step_status = value;
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

        public DateTime App_Date
        {
            get
            {
                return _app_date;
            }
            set
            {
                _app_date = value;
            }
        }

        public short App_Flag
        {
            get
            {
                return _app_flag;
            }
            set
            {
                _app_flag = value;
            }
        }

        public string App_remark
        {
            get
            {
                return _app_remark;
            }
            set
            {
                _app_remark = (value == null ? "" : value);
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
        #endregion

        #region ------------------------필드 데이터 삽입 ------------------------
        
        #endregion

        public bool ModifyApprovalPrc(int app_ref_id, int app_step, int app_step_status, string app_status, DateTime app_date, short app_flag, string app_remark, int app_emp_id)
        {
            string query = @"UPDATE	COM_APPROVAL_PRC
                                SET	APP_STEP_STATUS = @APP_STEP_STATUS
	                                ,APP_STATUS     = @APP_STATUS
	                                ,APP_DATE       = @APP_DATE
	                                ,APP_FLAG       = @APP_FLAG
	                                ,APP_REMARK     = @APP_REMARK
	                                ,APP_EMP_ID     = @APP_EMP_ID
                                WHERE	APP_REF_ID  = @APP_REF_ID
                                AND	APP_STEP        = @APP_STEP";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;
            paramArray[1]               = CreateDataParameter("@APP_STEP", SqlDbType.Int);
            paramArray[1].Value         = app_step;
            paramArray[2]               = CreateDataParameter("@APP_STEP_STATUS", SqlDbType.Int);
            paramArray[2].Value         = app_step_status;
            paramArray[3]               = CreateDataParameter("@APP_STATUS", SqlDbType.Char);
            paramArray[3].Value         = app_status;
            paramArray[4]               = CreateDataParameter("@APP_DATE", SqlDbType.DateTime);
            paramArray[4].Value         = app_date;
            paramArray[5]               = CreateDataParameter("@APP_FLAG", SqlDbType.SmallInt);
            paramArray[5].Value         = app_flag;
            paramArray[6]               = CreateDataParameter("@APP_REMARK", SqlDbType.VarChar);
            paramArray[6].Value         = app_remark;
            paramArray[7]               = CreateDataParameter("@APP_EMP_ID", SqlDbType.Int);
            paramArray[7].Value         = app_emp_id;

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

        public DataSet GetApprovalPrc(int app_ref_id, int app_step)
        {
            string query = @"SELECT	T1.APP_REF_ID
	                            ,T1.APP_STEP
	                            ,T1.APP_STEP_STATUS
	                            ,T1.APP_STATUS
	                            ,T1.APP_DATE
	                            ,T1.APP_FLAG
	                            ,T1.APP_REMARK
	                            ,T1.APP_EMP_ID
                            FROM	COM_APPROVAL_PRC T1
                            WHERE	T1.APP_REF_ID = @APP_REF_ID
                            AND	T1.APP_STEP = @APP_STEP";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;
            paramArray[1]               = CreateDataParameter("@APP_STEP", SqlDbType.Int);
            paramArray[1].Value         = app_step;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "APPROVALPRCGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetApprovalPrc_InfoByEmpID(int emp_ref_id, ApprovalStatus status)
        {
            string query = @"SELECT * FROM COM_APPROVAL_PRC WHERE (APP_STATUS = @APP_STATUS OR @APP_STATUS='*') and APP_EMP_ID = @APP_EMP_ID";

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

        public DataSet GetAllApprovalPrc(int app_ref_id, int app_step)
        {
            string query = @"SELECT	T1.APP_REF_ID
	                            ,T1.APP_STEP
	                            ,T1.APP_STEP_STATUS
	                            ,T1.APP_STATUS
	                            ,T1.APP_DATE
	                            ,T1.APP_FLAG
	                            ,T1.APP_REMARK
	                            ,T1.APP_EMP_ID
                            FROM	COM_APPROVAL_PRC T1";

            DataSet ds = DbAgentObj.FillDataSet(query, "APPROVALPRCGETAll", null, null, CommandType.Text);
            return ds;
        }

        public int InsertApprovalPrc_DB(IDbConnection conn
                                        , IDbTransaction trx
                                        , object app_ref_id
                                        , object version_no
                                        , object line_step
                                        , object app_emp_id
                                        , object complete_yn
                                        , object comments
                                        , object return_reason
                                        , object line_type
                                        , object app_method
                                        , object create_user
                                        , object create_date)
        {
            string query = @"
INSERT INTO COM_APPROVAL_PRC(
     APP_REF_ID
    ,VERSION_NO
    ,LINE_STEP
    ,APP_EMP_ID
    ,COMPLETE_YN
    ,COMMENTS
    ,RETURN_REASON
    ,LINE_TYPE
, APP_METHOD
, CREATE_USER
, CREATE_DATE
, UPDATE_USER
, UPDATE_DATE
    )
VALUES	(
@APP_REF_ID
    ,@VERSION_NO
    ,@LINE_STEP
    ,@APP_EMP_ID
    ,@COMPLETE_YN
    ,@COMMENTS
    ,@RETURN_REASON
    ,@LINE_TYPE
, @APP_METHOD
, @CREATE_USER
, @CREATE_DATE
, NULL
, NULL
    )";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;
            paramArray[1]               = CreateDataParameter("@VERSION_NO", SqlDbType.Int);
            paramArray[1].Value = version_no;
            paramArray[2] = CreateDataParameter("@LINE_STEP", SqlDbType.VarChar);
            paramArray[2].Value = line_step;
            paramArray[3] = CreateDataParameter("@APP_EMP_ID", SqlDbType.Int);
            paramArray[3].Value = app_emp_id;
            paramArray[4] = CreateDataParameter("@COMPLETE_YN", SqlDbType.VarChar);
            paramArray[4].Value = complete_yn;
            paramArray[5] = CreateDataParameter("@COMMENTS", SqlDbType.VarChar);
            paramArray[5].Value = comments;
            paramArray[6] = CreateDataParameter("@RETURN_REASON", SqlDbType.VarChar);
            paramArray[6].Value = return_reason;
            paramArray[7] = CreateDataParameter("@LINE_TYPE", SqlDbType.VarChar);
            paramArray[7].Value = line_type;
            paramArray[8] = CreateDataParameter("@APP_METHOD", SqlDbType.VarChar);
            paramArray[8].Value = app_method;
            paramArray[9] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user;
            paramArray[10] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[10].Value = create_date;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }

        public bool RemoveApprovalPrc(int app_ref_id, int app_step)
        {
            string query = @"DELETE	COM_APPROVAL_PRC
                                WHERE	APP_REF_ID  = @APP_REF_ID
                                    AND	APP_STEP    = @APP_STEP";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = app_ref_id;
            paramArray[1]               = CreateDataParameter("@APP_STEP", SqlDbType.Int);
            paramArray[1].Value         = app_step;

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
    }
}
