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

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_Com_Approval_Prc
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Com_Approval_Prc
    /// Class Func     : COM_APPROVAL_PRC Table Data Access
    /// CREATE DATE    : 2008-05-17 오후 11:37:09
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    /// 
    public class Dac_Com_Approval_Prc : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private decimal        _iapp_ref_id;
        private Int32          _iversion_no;
        private Int32          _iline_step;
        private Int32          _iapp_emp_id;
        private String         _iapp_emp_name;
        private Int32          _iapp_dept_id;
        private String         _iapp_dept_name;
        private String         _icomplete_yn;
        private String         _icomments;
        private String         _ireturn_reason;
        private String         _iline_type;
        private String         _iapp_method;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private Int32 	       _itxr_user;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public decimal IApp_Ref_Id
        {
            get { return _iapp_ref_id; }
            set { _iapp_ref_id = value; }
        }
        public int IVersion_No
        {
            get { return _iversion_no; }
            set { _iversion_no = value; }
        }
        public int ILine_Step
        {
            get { return _iline_step; }
            set { _iline_step = value; }
        }
        public int IApp_Emp_Id
        {
            get { return _iapp_emp_id; }
            set { _iapp_emp_id = value; }
        }
        public string IApp_Emp_Name
        {
            get { return _iapp_emp_name; }
            set { _iapp_emp_name = value; }
        }
        public int IApp_Dept_Id
        {
            get { return _iapp_dept_id; }
            set { _iapp_dept_id = value; }
        }
        public string IApp_Dept_Name
        {
            get { return _iapp_dept_name; }
            set { _iapp_dept_name = value; }
        }
        public string IComplete_Yn
        {
            get { return _icomplete_yn; }
            set { _icomplete_yn = value; }
        }
        public string IComments
        {
            get { return _icomments; }
            set { _icomments = value; }
        }
        public string IReturn_Reason
        {
            get { return _ireturn_reason; }
            set { _ireturn_reason = value; }
        }
        public string ILine_Type
        {
            get { return _iline_type; }
            set { _iline_type = value; }
        }
        public string IApp_Method
        {
            get { return _iapp_method; }
            set { _iapp_method = value; }
        }
        public int ICreate_User
        {
            get { return _icreate_user; }
            set { _icreate_user = value; }
        }
        public System.DateTime ICreate_Date
        {
            get { return _icreate_date; }
            set { _icreate_date = value; }
        }
        public int IUpdate_User
        {
            get { return _iupdate_user; }
            set { _iupdate_user = value; }
        }
        public System.DateTime IUpdate_Date
        {
            get { return _iupdate_date; }
            set { _iupdate_date = value; }
        }
        public int Itxr_user
        {
            get { return _itxr_user; }
            set { _itxr_user = value; }
        }
        public String Transaction_Message
        {
            get { return _txr_message; }
            set { _txr_message = value; }
        }
        public String Transaction_Result
        {
            get { return _txr_result; }
            set { _txr_result = value; }
        }
        #endregion
		
		#region ============================== [Constructor] ==============================
		public Dac_Com_Approval_Prc() { }
        public Dac_Com_Approval_Prc(decimal iapp_ref_id, int iversion_no, int iline_step)
        {
            DataSet ds = this.GetOneList( iapp_ref_id,  iversion_no,  iline_step);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iapp_ref_id                 = (dr["APP_REF_ID"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["APP_REF_ID"]);
                _iversion_no                 = (dr["VERSION_NO"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                _iline_step                  = (dr["LINE_STEP"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["LINE_STEP"]);
                _iapp_emp_id                 = (dr["APP_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["APP_EMP_ID"]);
                _iapp_emp_name               = (dr["EMP_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EMP_NAME"]);
                _iapp_dept_id                = (dr["DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
                _iapp_dept_name              = (dr["DEPT_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_NAME"]);
                _icomplete_yn                = (dr["COMPLETE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["COMPLETE_YN"]);
                _icomments                   = (dr["COMMENTS"] == DBNull.Value) ? "" : Convert.ToString(dr["COMMENTS"]);
                _ireturn_reason              = (dr["RETURN_REASON"] == DBNull.Value) ? "" : Convert.ToString(dr["RETURN_REASON"]);
                _iline_type                  = (dr["LINE_TYPE"] == DBNull.Value) ? "" : Convert.ToString(dr["LINE_TYPE"]);
                _iapp_method                 = (dr["APP_METHOD"] == DBNull.Value) ? "" : Convert.ToString(dr["APP_METHOD"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, int iapp_emp_id, string icomplete_yn, string icomments, string ireturn_reason, string iline_type, string iapp_method, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value         = iversion_no;
            paramArray[3]               = CreateDataParameter("@iLINE_STEP", SqlDbType.Int);
            paramArray[3].Value         = iline_step;
            paramArray[4]               = CreateDataParameter("@iAPP_EMP_ID", SqlDbType.Int);
            paramArray[4].Value         = iapp_emp_id;
            paramArray[5]               = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[5].Value         = icomplete_yn;
            paramArray[6]               = CreateDataParameter("@iCOMMENTS", SqlDbType.VarChar);
            paramArray[6].Value         = icomments;
            paramArray[7]               = CreateDataParameter("@iRETURN_REASON", SqlDbType.VarChar);
            paramArray[7].Value         = ireturn_reason;
            paramArray[8]               = CreateDataParameter("@iLINE_TYPE", SqlDbType.VarChar);
            paramArray[8].Value         = iline_type;
            paramArray[9]               = CreateDataParameter("@iAPP_METHOD", SqlDbType.VarChar);
            paramArray[9].Value         = iapp_method;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[11].Direction    = ParameterDirection.Output;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[12].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, int iapp_emp_id, string icomplete_yn, string icomments, string ireturn_reason, string iline_type, string iapp_method, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value         = iversion_no;
            paramArray[3]               = CreateDataParameter("@iLINE_STEP", SqlDbType.Int);
            paramArray[3].Value         = iline_step;
            paramArray[4]               = CreateDataParameter("@iAPP_EMP_ID", SqlDbType.Int);
            paramArray[4].Value         = iapp_emp_id;
            paramArray[5]               = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[5].Value         = icomplete_yn;
            paramArray[6]               = CreateDataParameter("@iCOMMENTS", SqlDbType.VarChar);
            paramArray[6].Value         = icomments;
            paramArray[7]               = CreateDataParameter("@iRETURN_REASON", SqlDbType.VarChar);
            paramArray[7].Value         = ireturn_reason;
            paramArray[8]               = CreateDataParameter("@iLINE_TYPE", SqlDbType.VarChar);
            paramArray[8].Value         = iline_type;
            paramArray[9]               = CreateDataParameter("@iAPP_METHOD", SqlDbType.VarChar);
            paramArray[9].Value         = iapp_method;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[11].Direction    = ParameterDirection.Output;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[12].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "D";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value        = iversion_no;
            paramArray[3]              = CreateDataParameter("@iLINE_STEP", SqlDbType.Int);
            paramArray[3].Value        = iline_step;
            paramArray[4]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction    = ParameterDirection.Output;
            paramArray[5]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "DV";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value        = iversion_no;
            paramArray[3]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction    = ParameterDirection.Output;
            paramArray[4]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_DELETE_VERSION"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 결재상신
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iversion_no"></param>
        /// <param name="iline_step"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int Approval_Dac
                 (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, string icomments, int itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "AP";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value        = iversion_no;
            paramArray[3]              = CreateDataParameter("@iLINE_STEP", SqlDbType.Int);
            paramArray[3].Value        = iline_step;
            paramArray[4]              = CreateDataParameter("@iCOMMENTS", SqlDbType.VarChar);
            paramArray[4].Value        = icomments;
            paramArray[5]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value        = itxr_user;
            paramArray[6]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[6].Direction    = ParameterDirection.Output;
            paramArray[7]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[7].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_APPROVAL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 반려처리
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iversion_no"></param>
        /// <param name="iline_step"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int Return_Dac
                 (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int iline_step, string ireturn_reason, int itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "RT";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value        = iversion_no;
            paramArray[3]              = CreateDataParameter("@iLINE_STEP", SqlDbType.Int);
            paramArray[3].Value        = iline_step;
            paramArray[4]              = CreateDataParameter("@iRETURN_REASON", SqlDbType.VarChar);
            paramArray[4].Value        = ireturn_reason;
            paramArray[5]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value        = itxr_user;
            paramArray[6]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[6].Direction    = ParameterDirection.Output;
            paramArray[7]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[7].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_RETURN"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 수정결재 요청
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int RequestModifyDraft_Dac(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "MD";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value        = itxr_user;
            paramArray[3]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction    = ParameterDirection.Output;
            paramArray[4]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_MODITY_DRAFT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 결재회수 처리
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int RecallDraft_Dac(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "RC";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value        = iversion_no;
            paramArray[3]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value        = itxr_user;
            paramArray[4]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction    = ParameterDirection.Output;
            paramArray[5]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_RECALL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(decimal iapp_ref_id, int iversion_no, int iline_step)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "SO";
			paramArray[1]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value        = iapp_ref_id;
            paramArray[2]              = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value        = iversion_no;
            paramArray[3]              = CreateDataParameter("@iLINE_STEP", SqlDbType.Int);
            paramArray[3].Value        = iline_step;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_SELECT_ONE"), "COM_APPROVAL_PRC", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(decimal iapp_ref_id, int iversion_no)
        {
            string strQuery = @"
SELECT  AP.APP_REF_ID
       ,AP.VERSION_NO
       ,AP.LINE_STEP
       ,AP.APP_EMP_ID       as EMP_REF_ID
       ,EC.EMP_NAME
       ,EC.COM_DEPT_REF_ID  as DEPT_REF_ID
       ,EC.COM_DEPT_NAME    as DEPT_NAME
       ,AP.COMPLETE_YN
       ,AP.COMMENTS
       ,AP.RETURN_REASON
       ,AP.LINE_TYPE
       ,(C4.CODE_NAME)   as LINE_TYPE_NAME
       ,AP.APP_METHOD               
       ,AP.CREATE_USER
       ,AP.CREATE_DATE
       ,AP.UPDATE_USER
       {0}
       ,CASE WHEN AP.LINE_TYPE = 'D' THEN 'Y'
             WHEN AP.APP_EMP_ID = AB.EMP_REF_ID THEN 'Y'
             ELSE 'N'
        END as DEFAULT_YN     -- 기안자이거나 필수결재자이면 
       ,CE.EMP_EMAIL
FROM COM_APPROVAL_PRC AP
    LEFT JOIN (SELECT ETC_CODE, CODE_NAME FROM COM_CODE_INFO WHERE CATEGORY_CODE = 'CM004') C4
      ON AP.LINE_TYPE   = C4.ETC_CODE 
    LEFT JOIN viw_EMP_COMDEPT EC
      ON AP.APP_EMP_ID = EC.EMP_REF_ID  
    LEFT JOIN COM_APPROVAL_INFO AI
      ON AP.APP_REF_ID = AI.APP_REF_ID
     AND AP.VERSION_NO = AI.VERSION_NO 
    LEFT JOIN COM_APPROVAL_LINE_BASE AB
      ON AI.BIZ_TYPE = AB.BIZ_TYPE
     AND AB.EMP_REF_ID = AP.APP_EMP_ID
    LEFT JOIN COM_EMP_INFO CE
      ON AP.APP_EMP_ID = CE.EMP_REF_ID
WHERE AP.APP_REF_ID = @iAPP_REF_ID
AND AP.VERSION_NO = @iVERSION_NO
ORDER BY AP.LINE_STEP
";

            string sqlQuery = string.Format(strQuery, " ,CONVERT(VARCHAR(10),AP.UPDATE_DATE,120)   AS TXR_DATE  ");

            string orclQuery = string.Format(strQuery, " ,TO_CHAR(AP.UPDATE_DATE,'YYYY-MM-DD')   AS TXR_DATE  ");

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[0].Value         = iapp_ref_id;
            paramArray[1]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[1].Value         = iversion_no;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_SELECT_ALL"), "COM_APPROVAL_PRC", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(sqlQuery,orclQuery), "COM_APPROVAL_LINE_LIST", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 내가 결재할 문서 리스트
        /// </summary>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetToDraftList(int itxr_user, string ibiz_type, int idept_ref_id, DateTime isdate, DateTime iedate)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "TD";
            paramArray[1]       = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value = ibiz_type;
            paramArray[2]       = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = idept_ref_id;
            paramArray[3]       = CreateDataParameter("@iSDATE", SqlDbType.DateTime);
            paramArray[3].Value = isdate;
            paramArray[4]       = CreateDataParameter("@iEDate", SqlDbType.DateTime);
            paramArray[4].Value = iedate;
            paramArray[5]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_SELECT_TO_DRAFT_LIST"), "COM_APPROVAL_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetToDraftList(int itxr_user, string ibiz_type)
        {
            return GetToDraftList(itxr_user, ibiz_type, 0, DateTime.MinValue.AddYears(1800), DateTime.MaxValue);
        }

        /// <summary>
        /// 내가 상신한 문서리스트
        /// </summary>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetMyDraftList(int itxr_user, string ibiz_type, int idept_ref_id, DateTime isdate, DateTime iedate)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ML";
            paramArray[1]       = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value = ibiz_type;
            paramArray[2]       = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = idept_ref_id;
            paramArray[3]       = CreateDataParameter("@iSDATE", SqlDbType.DateTime);
            paramArray[3].Value = isdate;
            paramArray[4]       = CreateDataParameter("@iEDate", SqlDbType.DateTime);
            paramArray[4].Value = iedate;
            paramArray[5]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_SELECT_MY_DRAFT_LIST"), "COM_APPROVAL_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMyDraftList(int itxr_user, string ibiz_type)
        {
            return GetMyDraftList(itxr_user, ibiz_type, 0, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 결재 완료된 문서
        /// </summary>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetCompletedList(int itxr_user, string iapp_status, string ibiz_type, string ititle, DateTime isdate, DateTime iedate)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CL";
            paramArray[1]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[1].Value         = itxr_user;
            paramArray[2]               = CreateDataParameter("@iAPP_STATUS", SqlDbType.VarChar);
            paramArray[2].Value         = iapp_status;
            paramArray[3]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = ibiz_type;
            paramArray[4]               = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[4].Value         = ititle;
            paramArray[5]               = CreateDataParameter("@iSDATE", SqlDbType.DateTime);
            paramArray[5].Value         = isdate;
            paramArray[6]               = CreateDataParameter("@iEDate", SqlDbType.DateTime);
            paramArray[6].Value         = iedate;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_PRC", "PKG_COM_APPROVAL_PRC.PROC_SELECT_COMPLETED_LIST"), "COM_APPROVAL_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

		#endregion
    }
}