using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_Com_Approval_Line_Base
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Com_Approval_Line_Base
    /// Class Func     : COM_APPROVAL_LINE_BASE Table Data Access
    /// CREATE DATE    : 2008-08-20 오전 11:52:58
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Com_Approval_Line_Base : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private string         _ibiz_type;
        private Int32          _iemp_ref_id;
        private Int32          _isort_order;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public string IBiz_Type
        {
            get { return _ibiz_type; }
            set { _ibiz_type = value; }
        }
        public int IEmp_Ref_Id
        {
            get { return _iemp_ref_id; }
            set { _iemp_ref_id = value; }
        }
        public int ISort_Order
        {
            get { return _isort_order; }
            set { _isort_order = value; }
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
		public Dac_Com_Approval_Line_Base() { }
        public Dac_Com_Approval_Line_Base(string ibiz_type, int iemp_ref_id)
        {
            DataSet ds = this.GetOneList( ibiz_type,  iemp_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_ibiz_type                   = (dr["BIZ_TYPE"]    == DBNull.Value) ? "" : Convert.ToString(dr["BIZ_TYPE"]);
                _iemp_ref_id                 = (dr["EMP_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["EMP_REF_ID"]);
                _isort_order                 = (dr["SORT_ORDER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, string ibiz_type, int iemp_ref_id, int isort_order, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "A";
			paramArray[1]              = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value        = ibiz_type;
            paramArray[2]              = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value        = iemp_ref_id;
            paramArray[3]              = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[3].Value        = isort_order;
            paramArray[4]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value        = itxr_user;
            paramArray[5]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction    = ParameterDirection.Output;
            paramArray[6]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_COM_APPROVAL_LINE_BASE", "PKG_COM_APPROVAL_LINE_BASE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, string ibiz_type, int iemp_ref_id, int isort_order, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "U";
			paramArray[1]              = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value        = ibiz_type;
            paramArray[2]              = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value        = iemp_ref_id;
            paramArray[3]              = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[3].Value        = isort_order;
            paramArray[4]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value        = itxr_user;
            paramArray[5]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction    = ParameterDirection.Output;
            paramArray[6]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_COM_APPROVAL_LINE_BASE", "PKG_COM_APPROVAL_LINE_BASE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, string ibiz_type, int iemp_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "D";
			paramArray[1]              = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value        = ibiz_type;
            paramArray[2]              = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value        = iemp_ref_id;
            paramArray[3]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value        = itxr_user;
            paramArray[4]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction    = ParameterDirection.Output;
            paramArray[5]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_COM_APPROVAL_LINE_BASE", "PKG_COM_APPROVAL_LINE_BASE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(string ibiz_type, int iemp_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "SO";
			paramArray[1]              = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value        = ibiz_type;
            paramArray[2]              = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value        = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_LINE_BASE", "PKG_COM_APPROVAL_LINE_BASE.PROC_SELECT_ONE"), "COM_APPROVAL_LINE_BASE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(string ibiz_type, int iemp_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	   = "SA";
	        paramArray[1]              = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value        = ibiz_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_LINE_BASE", "PKG_COM_APPROVAL_LINE_BASE.PROC_SELECT_ALL"), "COM_APPROVAL_LINE_BASE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetBaseAppLine(string ibiz_type, int iemp_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	   = "SB";
	        paramArray[1]              = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value        = ibiz_type;
            paramArray[2]              = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value        = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_LINE_BASE", "PKG_COM_APPROVAL_LINE_BASE.PROC_SELECT_BASE_LINE"), "COM_APPROVAL_LINE_BASE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}