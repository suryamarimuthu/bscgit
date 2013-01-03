using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;


/// <summary>
/// Dac_Bsc_Work_Exec의 요약 설명입니다.
/// </summary>

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Work_Exec에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Work_Exec Dac 클래스
    /// Class 내용		@ Work_Exec Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 서대원
    /// 최초작성일		@ 2011.09.21
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------


    public class Dac_Bsc_Work_Exec : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;  //평가기간 id
        private string _iestterm_ref_id_name;
        private int 	 _iest_dept_ref_id; //평가부서 id
        private string _iest_dept_ref_id_name;
        private int      _iwork_ref_id;     //중점과제 id
        private string _iwork_ref_id_name;
        private string _iwork_code;
        private int _iexec_ref_id;     //실행과제 id
        private string _iexec_code;       //실행과제 코드
        private string _iexec_name;       //실행과제 명칭
        private string _iexec_desc;       //실행과제 설명
        private int _iexec_emp_id;     //실행과제 관리자
        private string _iexec_emp_id_name;
        private int _iexec_emp_id_dept_id;
        private string _iexec_emp_id_dept_id_name;
        private string   _iexec_issue;
        private string   _iadd_file;
        private decimal  _iapp_ref_id;
        private string _iuse_yn;
        private string _icomplete_yn;
        private int _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
 
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
        #endregion

        #region ============================== [Properties] ==============================

        public int Iestterm_ref_id
        {
            get
            {
                return _iestterm_ref_id;
            }
            set
            {
                _iestterm_ref_id = (value == null ? 0 : value);
            }
        }

        public string Iestterm_ref_id_name
        {
            get
            {
                return _iestterm_ref_id_name;
            }
            set
            {
                _iestterm_ref_id_name = (value == null ? "" : value);
            }
        }

        public int Iest_dept_ref_id
        {
            get
            {
                return _iest_dept_ref_id;
            }
            set
            {
                _iest_dept_ref_id = (value == null ? 0 : value);
            }
        }

        public string Iest_dept_ref_id_name
        {
            get
            {
                return _iest_dept_ref_id_name;
            }
            set
            {
                _iest_dept_ref_id_name = (value == null ? "" : value);
            }
        }

        public int Iwork_ref_id
        {
            get
            {
                return _iwork_ref_id;
            }
            set
            {
                _iwork_ref_id = (value == null ? 0 : value);
            }
        }

        public string Iwork_ref_id_name
        {
            get
            {
                return _iwork_ref_id_name;
            }
            set
            {
                _iwork_ref_id_name = (value == null ? "" : value);
            }

        }

        public string Iwork_code
        {
            get
            {
                return _iwork_code;
            }
            set
            {
                _iwork_code = (value == null ? "":value);
            }
        }
        public int Iexec_ref_id
        {
            get
            {
                return _iexec_ref_id;
            }
            set
            {
                _iexec_ref_id = (value == null ? 0 : value);
            }

        }
        public string Iexec_code
        {
            get
            {
                return _iexec_code;
            }
            set
            {
                _iexec_code = (value == null ? "" : value);
            }
        }

        public string Iexec_name
        {
            get
            {
                return _iexec_name;
            }
            set
            {
                _iexec_name = (value == null ? "" : value);
            }
        }

        public string Iexec_desc
        {
            get
            {
                return _iexec_desc;
            }
            set
            {
                _iexec_desc = ( value == null ? "":value);
            }
        }

        public int Iexec_emp_id
        {
            get
            {
                return _iexec_emp_id;
            }
            set
            {
                _iexec_emp_id = (value == null ? 0 : value);
            }
        }

        public string Iexec_emp_id_name
        {
            get
            {
                return _iexec_emp_id_name;
            }
            set
            {
                _iexec_emp_id_name = (value == null ? "" : value);
            }
        }

        public int Iexec_emp_id_dept_id
        {
            get
            {
                return _iexec_emp_id_dept_id;
            }
            set
            {
                _iexec_emp_id_dept_id = (value == null ? 0 : value);
            }
        }

        public string Iexec_emp_id_dept_id_name
        {
            get
            {
                return _iexec_emp_id_dept_id_name;
            }
            set
            {
                _iexec_emp_id_dept_id_name = (value == null ? "" : value);
            }
        }

        public string Iexec_issue
        {
            get
            {
                return _iexec_issue;
            }
            set
            {
                _iexec_issue = value;
            }
        }

        public string Iadd_file
        {
            get
            {
                return _iadd_file;
            }
            set
            {
                _iadd_file = value;
            }
        }

        public decimal Iapp_ref_id
        {
            get
            {
                return _iapp_ref_id;
            }
            set
            {
                _iapp_ref_id = value;
            }
        }

        public string Iuse_yn
        {
            get
            {
                return _iuse_yn;
            }
            set
            {
                _iuse_yn = value;
            }
        }

        public string Icomplete_yn
        {
            get
            {
                return _icomplete_yn;
            }
            set
            {
                _icomplete_yn = value;
            }
        }

        public int Itxr_user
        {
            get
            {
                return _itxr_user;
            }
            set
            {
                _itxr_user = value;
            }
        }

        public Int32 Create_user
        {
            get
            {
                return _create_user;
            }
            set
            {
                _create_user = value;
            }
        }

        public DateTime Create_date
        {
            get
            {
                return _create_date;
            }
            set
            {
                _create_date = value;
            }
        }

        public Int32 Update_user
        {
            get
            {
                return _update_user;
            }
            set
            {
                _update_user = value;
            }
        }

        public DateTime Update_date
        {
            get
            {
                return _update_date;
            }
            set
            {
                _update_date = value;
            }
        }

        public String Transaction_Message
        {
            get
            {
                return _txr_message;
            }
            set
            {
                _txr_message = value;
            }
        }

        public String Transaction_Result
        {
            get
            {
                return _txr_result;
            }
            set
            {
                _txr_result = value;
            }
        }
        #endregion

        #region ============================== [Constructor] ==============================
        public Dac_Bsc_Work_Exec() { }
        public Dac_Bsc_Work_Exec(int Iestterm_ref_id, string Iexec_code)
        {
            DataSet ds = this.GetExecCode(Iestterm_ref_id, Iexec_code);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 0)
            {
                _iexec_code = "";
            }

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iestterm_ref_id_name = (dr["ESTTERM_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_REF_ID_NAME"]);
                _iest_dept_ref_id = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_ref_id_name = (dr["EST_DEPT_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_REF_ID_NAME"]);
                _iwork_ref_id = (dr["WORK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_REF_ID"]);
                _iwork_ref_id_name = (dr["WORK_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_REF_ID_NAME"]);
                _iwork_code = (dr["WORK_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_CODE"]);
                _iexec_ref_id = (dr["EXEC_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_REF_ID"]);
                _iexec_code = (dr["EXEC_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_CODE"]);
                _iexec_name = (dr["EXEC_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_NAME"]);
                _iexec_desc = (dr["EXEC_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_DESC"]);
                _iexec_emp_id = (dr["EXEC_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_EMP_ID"]);
                _iexec_emp_id_name = (dr["EXEC_EMP_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_EMP_ID_NAME"]);
                _iexec_emp_id_dept_id = (dr["EXEC_EMP_ID_DEPT_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_EMP_ID_DEPT_ID"]);
                _iexec_emp_id_dept_id_name = (dr["EXEC_EMP_ID_DEPT_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_EMP_ID_DEPT_ID_NAME"]);
                _iexec_issue = (dr["EXEC_ISSUE"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_ISSUE"]);
                _iadd_file = (dr["ADD_FILE"] == DBNull.Value) ? "" : Convert.ToString(dr["ADD_FILE"]);
                _iapp_ref_id = (dr["APP_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["APP_REF_ID"]);
                _iuse_yn = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icomplete_yn = (dr["COMPLETE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["COMPLETE_YN"]);
                _create_user = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        public Dac_Bsc_Work_Exec(int Iestterm_ref_id, int Iexec_ref_id)
        {
            DataSet ds = this.GetExecRefId(Iestterm_ref_id, Iexec_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 0)
            {
                _iexec_ref_id = 0;
            }

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iestterm_ref_id_name = (dr["ESTTERM_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_REF_ID_NAME"]);
                _iest_dept_ref_id = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_ref_id_name = (dr["EST_DEPT_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_REF_ID_NAME"]);
                _iwork_ref_id = (dr["WORK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_REF_ID"]);
                _iwork_ref_id_name = (dr["WORK_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_REF_ID_NAME"]);
                _iwork_code = (dr["WORK_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_CODE"]);
                _iexec_ref_id = (dr["EXEC_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_REF_ID"]);
                _iexec_code = (dr["EXEC_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_CODE"]);
                _iexec_name = (dr["EXEC_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_NAME"]);
                _iexec_desc = (dr["EXEC_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_DESC"]);
                _iexec_emp_id = (dr["EXEC_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_EMP_ID"]);
                _iexec_emp_id_name = (dr["EXEC_EMP_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_EMP_ID_NAME"]);
                _iexec_emp_id_dept_id = (dr["EXEC_EMP_ID_DEPT_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_EMP_ID_DEPT_ID"]);
                _iexec_emp_id_dept_id_name = (dr["EXEC_EMP_ID_DEPT_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_EMP_ID_DEPT_ID_NAME"]);
                _iexec_issue = (dr["EXEC_ISSUE"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_ISSUE"]);
                _iadd_file = (dr["ADD_FILE"] == DBNull.Value) ? "" : Convert.ToString(dr["ADD_FILE"]);
                _iapp_ref_id = (dr["APP_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["APP_REF_ID"]);
                _iuse_yn = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icomplete_yn = (dr["COMPLETE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["COMPLETE_YN"]);
                _create_user = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }

        public Dac_Bsc_Work_Exec(int Iestterm_ref_id, int Iest_dept_ref_id, int Iwork_ref_id, int Iwork_exec_ref_id)
        {
            DataSet ds = this.GetOneList(Iestterm_ref_id, Iest_dept_ref_id, Iwork_ref_id, Iwork_exec_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iestterm_ref_id_name = (dr["ESTTERM_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_REF_ID_NAME"]);
                _iest_dept_ref_id = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_ref_id_name = (dr["EST_DEPT_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_REF_ID_NAME"]);
                _iwork_ref_id = (dr["WORK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_REF_ID"]);
                _iwork_ref_id_name = (dr["WORK_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_REF_ID_NAME"]);
                _iwork_code = (dr["WORK_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_CODE"]);
                _iexec_ref_id = (dr["EXEC_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_REF_ID"]);
                _iexec_code = (dr["EXEC_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_CODE"]);
                _iexec_name = (dr["EXEC_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_NAME"]);
                _iexec_desc = (dr["EXEC_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_DESC"]);
                _iexec_emp_id = (dr["EXEC_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_EMP_ID"]);
                _iexec_emp_id_name = (dr["EXEC_EMP_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_EMP_ID_NAME"]);
                _iexec_emp_id_dept_id = (dr["EXEC_EMP_ID_DEPT_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_EMP_ID_DEPT_ID"]);
                _iexec_emp_id_dept_id_name = (dr["EXEC_EMP_ID_DEPT_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_EMP_ID_DEPT_ID_NAME"]);
                _iexec_issue = (dr["EXEC_ISSUE"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_ISSUE"]);
                _iadd_file = (dr["ADD_FILE"] == DBNull.Value) ? "" : Convert.ToString(dr["ADD_FILE"]);
                _iapp_ref_id = (dr["APP_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["APP_REF_ID"]);
                _iuse_yn = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icomplete_yn = (dr["COMPLETE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["COMPLETE_YN"]);
                _create_user = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iestterm_ref_id,       int iest_dept_ref_id,       int iwork_ref_id,       int iexec_ref_id,       string iexec_code,      string iexec_name, 
                 string iexec_desc,         int iexec_emp_id,           string iexec_issue, 
                 string iadd_file,         decimal iapp_ref_id,        string iuse_yn,         string icomplete_yn,     int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;

            paramArray[5] = CreateDataParameter("@iEXEC_CODE", SqlDbType.VarChar);
            paramArray[5].Value         = iexec_code;
            
            paramArray[6]               = CreateDataParameter("@iEXEC_NAME", SqlDbType.VarChar,100);
            paramArray[6].Value         = iexec_name;
            
            paramArray[7]               = CreateDataParameter("@iEXEC_DESC", SqlDbType.VarChar,1000);
            paramArray[7].Value         = iexec_desc;
            
            paramArray[8]               = CreateDataParameter("@iEXEC_EMP_ID", SqlDbType.Int);
            paramArray[8].Value         = iexec_emp_id;
            
            paramArray[9]              = CreateDataParameter("@iEXEC_ISSUE", SqlDbType.VarChar,1000);
            paramArray[9].Value        = iexec_issue;

            paramArray[10]              = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar ,200);
            paramArray[10].Value        = iadd_file;

            paramArray[11]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Value        = iapp_ref_id;

            paramArray[12] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[12].Value = iuse_yn;
            
            paramArray[13] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[13].Value = icomplete_yn;

            paramArray[14]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[14].Value        = itxr_user;

            paramArray[15]              = CreateDataParameter("@oRTN_EXEC_REF_ID", SqlDbType.Int);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[16].Direction    = ParameterDirection.Output;
            paramArray[17]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[17].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Iexec_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_EXEC_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id, string iexec_code, string iexec_name,
                 string iexec_desc, int iexec_emp_id, string iexec_issue,
                 string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;

            paramArray[5] = CreateDataParameter("@iEXEC_CODE", SqlDbType.VarChar);
            paramArray[5].Value = iexec_code;

            paramArray[6] = CreateDataParameter("@iEXEC_NAME", SqlDbType.VarChar, 100);
            paramArray[6].Value = iexec_name;

            paramArray[7] = CreateDataParameter("@iEXEC_DESC", SqlDbType.VarChar, 1000);
            paramArray[7].Value = iexec_desc;

            paramArray[8] = CreateDataParameter("@iEXEC_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = iexec_emp_id;

            paramArray[9] = CreateDataParameter("@iEXEC_ISSUE", SqlDbType.VarChar, 1000);
            paramArray[9].Value = iexec_issue;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11] = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Value = iapp_ref_id;

            paramArray[12] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[12].Value = iuse_yn;

            paramArray[13] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[13].Value = icomplete_yn;

            paramArray[14] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[14].Value = itxr_user;

            paramArray[15]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[16].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;
            paramArray[6]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[7].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id, string iexec_code, string iexec_name,
                 string iexec_desc, int iexec_emp_id, string iexec_issue,
                 string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;

            paramArray[5] = CreateDataParameter("@iEXEC_CODE", SqlDbType.VarChar);
            paramArray[5].Value = iexec_code;

            paramArray[6] = CreateDataParameter("@iEXEC_NAME", SqlDbType.VarChar, 100);
            paramArray[6].Value = iexec_name;

            paramArray[7] = CreateDataParameter("@iEXEC_DESC", SqlDbType.VarChar, 1000);
            paramArray[7].Value = iexec_desc;

            paramArray[8] = CreateDataParameter("@iEXEC_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = iexec_emp_id;

            paramArray[9] = CreateDataParameter("@iEXEC_ISSUE", SqlDbType.VarChar, 1000);
            paramArray[9].Value = iexec_issue;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11] = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Value = iapp_ref_id;

            paramArray[12] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[12].Value = iuse_yn;

            paramArray[13] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[13].Value = icomplete_yn;

            paramArray[14] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[14].Value = itxr_user;

            paramArray[15] = CreateDataParameter("@oRTN_EXEC_REF_ID", SqlDbType.Int);
            paramArray[15].Direction = ParameterDirection.Output;
            paramArray[16] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[16].Direction = ParameterDirection.Output;
            paramArray[17] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[17].Direction = ParameterDirection.Output;
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Iexec_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_EXEC_REF_ID").ToString());



            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id, string iexec_code, string iexec_name,
                 string iexec_desc, int iexec_emp_id, string iexec_issue,
                 string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;

            paramArray[5] = CreateDataParameter("@iEXEC_CODE", SqlDbType.VarChar);
            paramArray[5].Value = iexec_code;

            paramArray[6] = CreateDataParameter("@iEXEC_NAME", SqlDbType.VarChar, 100);
            paramArray[6].Value = iexec_name;

            paramArray[7] = CreateDataParameter("@iEXEC_DESC", SqlDbType.VarChar, 1000);
            paramArray[7].Value = iexec_desc;

            paramArray[8] = CreateDataParameter("@iEXEC_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = iexec_emp_id;

            paramArray[9] = CreateDataParameter("@iEXEC_ISSUE", SqlDbType.VarChar, 1000);
            paramArray[9].Value = iexec_issue;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11] = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Value = iapp_ref_id;

            paramArray[12] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[12].Value = iuse_yn;

            paramArray[13] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[13].Value = icomplete_yn;

            paramArray[14] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[14].Value = itxr_user;
            paramArray[15] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[16].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id,
            Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user; 
            paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UnUsedData_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "UU";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_UNUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReCompleteData_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RC";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;
            paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction = ParameterDirection.Output;
            paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_RECOMPLETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;
            paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction = ParameterDirection.Output;
            paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;
            paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction = ParameterDirection.Output;
            paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        internal protected int SetExecConirm_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id,Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CA";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;
            paramArray[6]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int SetExecCancel_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id,  Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CE";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;
            paramArray[6]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction =    ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_CANCEL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SE";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_SELECT_ALL"), "BSC_WORK_EXEC", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_SELECT_ONE"), "BSC_WORK_EXEC", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetExecCode(int iestterm_ref_id, string iexec_code)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SC";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEXEC_CODE", SqlDbType.VarChar);
            paramArray[2].Value = iexec_code;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_SELECT_CODE"), "BSC_WORK_EXEC", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetExecRefId(int iestterm_ref_id, int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SI";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iexec_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_SELECT_REF_ID"), "BSC_WORK_EXEC", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetExecStatus(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iexec_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SS";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iexec_ref_id;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_SELECT_WORK_STATUS"), "BSC_WORK_EXEC", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetViewStg(int estterm_ref_id
                            , int est_dept_ref_id
                            , int work_ref_id
                            ,int exec_ref_id)
        {
            string strQuery = @"

		SELECT	
				A.EST_DEPT_REF_ID,
				D.DEPT_NAME AS EST_DEPT_REF_ID_NAME,
				A.STG_REF_ID,
				( SELECT STG_NAME 
				    FROM BSC_STG_INFO 
				   WHERE ESTTERM_REF_ID = A.ESTTERM_REF_ID 
				     AND STG_REF_ID = A.STG_REF_ID) STG_REF_ID_NAME,
				( SELECT VIEW_REF_ID
					FROM BSC_MAP_STG
				   WHERE ESTTERM_REF_ID = A.ESTTERM_REF_ID
				     AND EST_DEPT_REF_ID = A.EST_DEPT_REF_ID
				     AND MAP_VERSION_ID  = ( SELECT MAX(MAP_VERSION_ID) AS TMAP_VERSION_ID 
					                           FROM BSC_MAP_STG 
					                          WHERE ESTTERM_REF_ID = A.ESTTERM_REF_ID 
					                            AND EST_DEPT_REF_ID = A.EST_DEPT_REF_ID )
				     AND STG_REF_ID      = A.STG_REF_ID) VIEW_REF_ID,
				( SELECT VIEW_NAME 
				    FROM BSC_VIEW_INFO
				   WHERE VIEW_REF_ID = (  SELECT VIEW_REF_ID
											FROM BSC_MAP_STG
										   WHERE ESTTERM_REF_ID = A.ESTTERM_REF_ID
											 AND EST_DEPT_REF_ID = A.EST_DEPT_REF_ID
											 AND MAP_VERSION_ID  = ( SELECT MAX(MAP_VERSION_ID) AS TMAP_VERSION_ID 
																	   FROM BSC_MAP_STG 
																	  WHERE ESTTERM_REF_ID = A.ESTTERM_REF_ID 
																		AND EST_DEPT_REF_ID = A.EST_DEPT_REF_ID )
											 AND STG_REF_ID      = A.STG_REF_ID) ) VIEW_REF_ID_NAME    
		FROM	BSC_MAP_SK_IE A
			LEFT JOIN COM_DEPT_INFO D
			    ON  A.EST_DEPT_REF_ID = D.DEPT_REF_ID
			
	    WHERE A.ESTTERM_REF_ID = @iESTTERM_REF_ID  
	      AND A.EST_DEPT_REF_ID = @iEST_DEPT_REF_ID 
	      --AND A.WORK_REF_ID = @iWORK_REF_ID
          AND A.EXEC_REF_ID = @iEXEC_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = work_ref_id;
            paramArray[3] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[3].Value = exec_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_VIEWSTG", null, paramArray, CommandType.Text);
        }

        #endregion

    }
}