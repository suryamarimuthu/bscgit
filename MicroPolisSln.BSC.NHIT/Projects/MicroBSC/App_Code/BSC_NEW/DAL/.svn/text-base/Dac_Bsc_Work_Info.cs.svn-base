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
/// Dac_Bsc_Work_Info의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Work_Info에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Work_Info Dac 클래스
    /// Class 내용		@ Work_info Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 서대원
    /// 최초작성일		@ 2011.09.21
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------

    public class Dac_Bsc_Work_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;  //평가기간 id
        private string _iestterm_ref_id_name;
        private int 	 _iest_dept_ref_id; //평가부서 id
        private string _iest_dept_ref_id_name;
        private int      _iwork_ref_id;     //중점과제 id
        private int _iwork_pool_ref_id;
        private string   _iwork_code = "";       //중점과제 코드
        private string   _iwork_name;       //중점과제 명칭
        private string   _iwork_desc;       //중점과제 설명
        private int      _iwork_emp_id;     //중점과제 관리자
        private string _iwork_emp_id_name;
        private int _iwork_emp_id_dept_id;
        private string _iwork_emp_id_dept_id_name;
        private string _iwork_priority;
        private string _iwork_priority_name;
        private string   _iwork_type;
        private string _iwork_type_name;
        private string   _iwork_issue;
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
                _iestterm_ref_id = value;
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
                _iestterm_ref_id_name = value;
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
                _iest_dept_ref_id = value;
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
                _iest_dept_ref_id_name = value;
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
                _iwork_ref_id = value;
            }
        }

        public int Iwork_pool_ref_id
        {
            get
            {
                return _iwork_pool_ref_id;
            }
            set
            {
                _iwork_pool_ref_id = value;
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
                _iwork_code = (value == null ? "" : value);
            }
        }

        public string Iwork_name
        {
            get
            {
                return _iwork_name;
            }
            set
            {
                _iwork_name = value;
            }
        }

        public string Iwork_desc
        {
            get
            {
                return _iwork_desc;
            }
            set
            {
                _iwork_desc = ( value == null ? "":value);
            }
        }

        public int Iwork_emp_id
        {
            get
            {
                return _iwork_emp_id;
            }
            set
            {
                _iwork_emp_id = (value == null ? 0 : value);
            }
        }

        public string Iwork_emp_id_name
        {
            get
            {
                return _iwork_emp_id_name;
            }
            set
            {
                _iwork_emp_id_name = (value == null ? "" : value);
            }
        }

        public int Iwork_emp_id_dept_id
        {
            get
            {
                return _iwork_emp_id_dept_id;
            }
            set
            {
                _iwork_emp_id_dept_id = (value == null ? 0 : value);
            }
        }

        public string Iwork_emp_id_dept_id_name
        {
            get
            {
                return _iwork_emp_id_dept_id_name;
            }
            set
            {
                _iwork_emp_id_dept_id_name = (value == null ? "" : value);
            }
        }

        public string Iwork_priority
        {
            get
            {
                return _iwork_priority;
            }
            set
            {
                _iwork_priority = (value == null ? "" : value);
            }
        }

        public string Iwork_priority_name
        {
            get
            {
                return _iwork_priority_name;
            }
            set
            {
                _iwork_priority_name = (value == null ? "" : value);
            }
        }

        public string Iwork_type
        {
            get
            {
                return _iwork_type;
            }
            set
            {
                _iwork_type = value;
            }
        }

        public string Iwork_type_name
        {
            get
            {
                return _iwork_type_name;
            }
            set
            {
                _iwork_type_name = value;
            }
        }

        public string Iwork_issue
        {
            get
            {
                return _iwork_issue;
            }
            set
            {
                _iwork_issue = value;
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
        public Dac_Bsc_Work_Info() { }

        public Dac_Bsc_Work_Info(int Iestterm_ref_id, int Iest_dept_ref_id, int Iwork_ref_id)
        {
            DataSet ds = this.GetOneList(Iestterm_ref_id, Iest_dept_ref_id, Iwork_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iestterm_ref_id_name = (dr["ESTTERM_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_REF_ID_NAME"]);
                _iest_dept_ref_id = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_ref_id_name = (dr["EST_DEPT_REF_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_REF_ID_NAME"]);
                _iwork_ref_id = (dr["WORK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_REF_ID"]);
                _iwork_pool_ref_id = (dr["WORK_POOL_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_POOL_REF_ID"]);
                _iwork_code = (dr["WORK_CODE"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_CODE"]);
                _iwork_name = (dr["WORK_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_NAME"]);
                _iwork_desc = (dr["WORK_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_DESC"]);
                _iwork_emp_id = (dr["WORK_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_EMP_ID"]);
                _iwork_emp_id_name = (dr["WORK_EMP_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_EMP_ID_NAME"]);
                _iwork_emp_id_dept_id = (dr["WORK_EMP_ID_DEPT_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_EMP_ID_DEPT_ID"]);
                _iwork_emp_id_dept_id_name = (dr["WORK_EMP_ID_DEPT_ID_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_EMP_ID_DEPT_ID_NAME"]);
                _iwork_priority = (dr["WORK_PRIORITY"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_PRIORITY"]);
                _iwork_priority_name = (dr["WORK_PRIORITY_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_PRIORITY_NAME"]);
                _iwork_type = (dr["WORK_TYPE"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_TYPE"]);
                _iwork_type_name = (dr["WORK_TYPE_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_TYPE_NAME"]);
                _iwork_issue = (dr["WORK_ISSUE"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_ISSUE"]);
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
                (int iestterm_ref_id,       int iest_dept_ref_id,       int iwork_ref_id,       int iwork_pool_ref_id,  string iwork_code,      string iwork_name, 
                 string iwork_desc,         int iwork_emp_id,           string iwork_priority,  string iwork_type,      string iwork_issue, 
                 string iadd_file,         decimal iapp_ref_id,        string iuse_yn,        string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(20);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iwork_pool_ref_id;

            paramArray[5] = CreateDataParameter("@iWORK_CODE", SqlDbType.VarChar);
            paramArray[5].Value         = iwork_code;
            
            paramArray[6]               = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar,100);
            paramArray[6].Value         = iwork_name;
            
            paramArray[7]               = CreateDataParameter("@iWORK_DESC", SqlDbType.VarChar,1000);
            paramArray[7].Value         = iwork_desc;
            
            paramArray[8]               = CreateDataParameter("@iWORK_EMP_ID", SqlDbType.Int);
            paramArray[8].Value         = iwork_emp_id;
            
            paramArray[9]               = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.VarChar);
            paramArray[9].Value         = iwork_priority;

            paramArray[10]               = CreateDataParameter("@iWORK_TYPE", SqlDbType.VarChar);
            paramArray[10].Value         = iwork_type;

            paramArray[11]              = CreateDataParameter("@iWORK_ISSUE", SqlDbType.VarChar,1000);
            paramArray[11].Value        = iwork_issue;

            paramArray[12] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[12].Value        = iadd_file;

            paramArray[13]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[13].Value        = iapp_ref_id;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[15].Value = icomplete_yn;

            paramArray[16] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[16].Value        = itxr_user;

            paramArray[17]              = CreateDataParameter("@oRTN_WORK_REF_ID", SqlDbType.Int);
            paramArray[17].Direction    = ParameterDirection.Output;
            paramArray[18]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[18].Direction    = ParameterDirection.Output;
            paramArray[19]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[19].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Iwork_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_WORK_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name,
                 string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue,
                 string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iwork_pool_ref_id;

            paramArray[5] = CreateDataParameter("@iWORK_CODE", SqlDbType.VarChar);
            paramArray[5].Value = iwork_code;

            paramArray[6] = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar, 100);
            paramArray[6].Value = iwork_name;

            paramArray[7] = CreateDataParameter("@iWORK_DESC", SqlDbType.VarChar, 1000);
            paramArray[7].Value = iwork_desc;

            paramArray[8] = CreateDataParameter("@iWORK_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = iwork_emp_id;

            paramArray[9] = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.VarChar);
            paramArray[9].Value = iwork_priority;

            paramArray[10] = CreateDataParameter("@iWORK_TYPE", SqlDbType.VarChar);
            paramArray[10].Value = iwork_type;

            paramArray[11] = CreateDataParameter("@iWORK_ISSUE", SqlDbType.VarChar, 1000);
            paramArray[11].Value = iwork_issue;

            paramArray[12] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[12].Value = iadd_file;

            paramArray[13] = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[13].Value = iapp_ref_id;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[15].Value = icomplete_yn;

            paramArray[16] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[16].Value = itxr_user;

            paramArray[17]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[17].Direction    = ParameterDirection.Output;
            paramArray[18]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[18].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3]               = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iwork_ref_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name,
                 string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue,
                 string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(20);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iwork_pool_ref_id;

            paramArray[5] = CreateDataParameter("@iWORK_CODE", SqlDbType.VarChar);
            paramArray[5].Value = iwork_code;

            paramArray[6] = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar, 100);
            paramArray[6].Value = iwork_name;

            paramArray[7] = CreateDataParameter("@iWORK_DESC", SqlDbType.VarChar, 1000);
            paramArray[7].Value = iwork_desc;

            paramArray[8] = CreateDataParameter("@iWORK_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = iwork_emp_id;

            paramArray[9] = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.VarChar);
            paramArray[9].Value = iwork_priority;

            paramArray[10] = CreateDataParameter("@iWORK_TYPE", SqlDbType.VarChar);
            paramArray[10].Value = iwork_type;

            paramArray[11] = CreateDataParameter("@iWORK_ISSUE", SqlDbType.VarChar, 1000);
            paramArray[11].Value = iwork_issue;

            paramArray[12] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[12].Value = iadd_file;

            paramArray[13] = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[13].Value = iapp_ref_id;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[15].Value = icomplete_yn;

            paramArray[16] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[16].Value = itxr_user;

            paramArray[17]              = CreateDataParameter("@oRTN_WORK_REF_ID", SqlDbType.Int);
            paramArray[17].Direction    = ParameterDirection.Output;
            paramArray[18]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[18].Direction    = ParameterDirection.Output;
            paramArray[19]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[19].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Iwork_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_WORK_REF_ID").ToString());



            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name,
                 string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue,
                 string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            paramArray[4] = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iwork_pool_ref_id;

            paramArray[5] = CreateDataParameter("@iWORK_CODE", SqlDbType.VarChar);
            paramArray[5].Value = iwork_code;

            paramArray[6] = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar, 100);
            paramArray[6].Value = iwork_name;

            paramArray[7] = CreateDataParameter("@iWORK_DESC", SqlDbType.VarChar, 1000);
            paramArray[7].Value = iwork_desc;

            paramArray[8] = CreateDataParameter("@iWORK_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = iwork_emp_id;

            paramArray[9] = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.VarChar);
            paramArray[9].Value = iwork_priority;

            paramArray[10] = CreateDataParameter("@iWORK_TYPE", SqlDbType.VarChar);
            paramArray[10].Value = iwork_type;

            paramArray[11] = CreateDataParameter("@iWORK_ISSUE", SqlDbType.VarChar, 1000);
            paramArray[11].Value = iwork_issue;

            paramArray[12] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[12].Value = iadd_file;

            paramArray[13] = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[13].Value = iapp_ref_id;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[15].Value = iuse_yn;

            paramArray[16] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[16].Value = itxr_user;
            paramArray[17] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[17].Direction    = ParameterDirection.Output;
            paramArray[18]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[18].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user; 
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReCompleteData_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RC";
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

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_RECOMPLETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, Int32 itxr_user)
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
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, Int32 itxr_user)
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
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        internal protected int SetWorkConirm_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id,Int32 iest_dept_ref_id, Int32 iwork_ref_id, Int32 itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CA";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iwork_ref_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int SetWorkCancel_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CE";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iwork_ref_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction =    ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_CANCEL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SE";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_SELECT_ALL"), "BSC_WORK_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(int estterm_ref_id, int est_dept_ref_id, string workEmpName, string workCode, string workName, string workPriority, string work_type, string use_yn)
        {

            string strQuery = @"
SELECT   WI.ESTTERM_REF_ID
		,ETI.ESTTERM_NAME AS ESTTERM_REF_ID_NAME
		,WI.EST_DEPT_REF_ID
		,CDI.DEPT_NAME AS EST_DEPT_REF_ID_NAME
		,WI.WORK_REF_ID
        ,WI.WORK_POOL_REF_ID
        ,WI.WORK_CODE
		,WI.WORK_NAME
		,WI.WORK_DESC
		,WI.WORK_EMP_ID
		,CEI.EMP_NAME AS WORK_EMP_ID_NAME
		,TD.DEPT_REF_ID AS WORK_EMP_ID_DEPT_ID
		,TD.DEPT_NAME AS WORK_EMP_ID_DEPT_ID_NAME
		,WI.WORK_PRIORITY
		,ISNULL(CI.CODE_NAME,'') as WORK_PRIORITY_NAME
		,WI.WORK_TYPE
		,ISNULL(C2.CODE_NAME,'') as WORK_TYPE_NAME
		,WI.WORK_ISSUE
		,WI.ADD_FILE
		,WI.APP_REF_ID
		,WI.USE_YN
		,WI.COMPLETE_YN 
		,(
			SELECT COUNT(*) AS E_COUNT
			FROM BSC_WORK_EXEC D0
			WHERE D0.ESTTERM_REF_ID = WI.ESTTERM_REF_ID
			  AND D0.EST_DEPT_REF_ID = WI.EST_DEPT_REF_ID 
			  AND D0.WORK_REF_ID = WI.WORK_REF_ID 
		) AS EXEC_COUNT
		,(
			SELECT COUNT(*) AS S_COUNT
			FROM BSC_MAP_SK_IE D1
			WHERE D1.WORK_REF_ID = WI.WORK_REF_ID 
			  AND D1.KPI_REF_ID = 0
			) AS STG_COUNT 
		,(
			SELECT COUNT(*) AS K_COUNT
			FROM BSC_MAP_SK_IE D2
			WHERE D2.WORK_REF_ID = WI.WORK_REF_ID 
			  AND D2.KPI_REF_ID <> 0
			) AS KPI_COUNT 
		,WI.CREATE_USER
		,WI.CREATE_DATE
		,WI.UPDATE_USER
		,WI.UPDATE_DATE
FROM BSC_WORK_INFO WI
LEFT JOIN EST_TERM_INFO ETI
    ON WI.ESTTERM_REF_ID = ETI.ESTTERM_REF_ID
LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='PM001') CI
    ON WI.WORK_PRIORITY = CI.ETC_CODE
LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='PM002') C2
    ON WI.WORK_TYPE = C2.ETC_CODE
LEFT JOIN (SELECT * FROM COM_EMP_INFO) CEI
    ON WI.WORK_EMP_ID = CEI.EMP_REF_ID
LEFT JOIN (SELECT * FROM COM_DEPT_INFO) CDI
    ON WI.EST_DEPT_REF_ID = CDI.DEPT_REF_ID
LEFT JOIN (			   
		   SELECT TA.EMP_REF_ID, TB.EMP_NAME, TA.DEPT_REF_ID, TC.DEPT_NAME 
			FROM BSC_EMP_COM_DEPT_DETAIL TA
		   LEFT JOIN COM_EMP_INFO TB
		   ON TA.EMP_REF_ID = TB.EMP_REF_ID
		   LEFT JOIN COM_DEPT_INFO TC
		   ON TA.DEPT_REF_ID = TC.DEPT_REF_ID ) TD
    ON WI.WORK_EMP_ID = TD.EMP_REF_ID 
LEFT JOIN BSC_WORK_POOL WP
    ON WP.WORK_POOL_REF_ID = WI.WORK_POOL_REF_ID 
WHERE WI.ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND (WI.EST_DEPT_REF_ID = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)
/*
    AND WP.USE_YN           LIKE (@USE_YN + '%')
    AND CEI.EMP_NAME        LIKE (@WORK_EMP_NAME + '%')
    AND WI.WORK_CODE        LIKE (@WORK_CODE + '%')
    AND WI.WORK_NAME        LIKE (@WORK_NAME + '%')
    AND WI.WORK_TYPE        LIKE (@WORK_TYPE + '%')
    AND WI.WORK_PRIORITY    LIKE (@WORK_PRIORITY + '%')
*/
    AND (WP.USE_YN           LIKE (@USE_YN + '%') OR  @USE_YN  ='' )
    AND (CEI.EMP_NAME        LIKE (@WORK_EMP_NAME + '%') OR  @WORK_EMP_NAME  ='' )
    AND (WI.WORK_CODE        LIKE (@WORK_CODE + '%') OR  @WORK_CODE  ='' )
    AND (WI.WORK_NAME        LIKE (@WORK_NAME + '%') OR  @WORK_NAME  ='' )
    AND (WI.WORK_TYPE        LIKE (@WORK_TYPE + '%') OR  @WORK_TYPE  ='' )
    AND (WI.WORK_PRIORITY    LIKE (@WORK_PRIORITY + '%') OR  @WORK_PRIORITY  ='' )
ORDER BY WI.ESTTERM_REF_ID ,WI.EST_DEPT_REF_ID ,WI.WORK_CODE
";
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@WORK_EMP_NAME", SqlDbType.VarChar);
            paramArray[2].Value = workEmpName;
            paramArray[3] = CreateDataParameter("@WORK_CODE", SqlDbType.VarChar);
            paramArray[3].Value = workCode;
            paramArray[4] = CreateDataParameter("@WORK_NAME", SqlDbType.VarChar);
            paramArray[4].Value = workName;
            paramArray[5] = CreateDataParameter("@WORK_PRIORITY", SqlDbType.VarChar);
            paramArray[5].Value = workPriority;
            paramArray[6] = CreateDataParameter("@WORK_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = work_type;
            paramArray[7] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[7].Value = use_yn;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_WORK_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iwork_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_SELECT_ONE"), "BSC_WORK_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetWorkCode(int iestterm_ref_id, string iwork_code)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SC";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iWORK_CODE", SqlDbType.VarChar );
            paramArray[2].Value = iwork_code;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_SELECT_CODE"), "BSC_WORK_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetWorkStatus(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SS";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iwork_ref_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_INFO", "PKG_BSC_WORK_INFO.PROC_SELECT_WORK_STATUS"), "BSC_WORK_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetViewStg(int estterm_ref_id
                            , int est_dept_ref_id
                            , int work_ref_id)
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
	      AND A.WORK_REF_ID = @iWORK_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = work_ref_id ;

            return DbAgentObj.FillDataSet(strQuery, "BSC_VIEWSTG", null, paramArray, CommandType.Text);
        }

        #endregion

    }
}