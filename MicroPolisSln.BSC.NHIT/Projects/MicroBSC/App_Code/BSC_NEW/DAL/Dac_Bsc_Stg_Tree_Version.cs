using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Stg_Tree_Version
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Stg_Tree_Version
    /// Class Func     : BSC_STG_TREE_VERSION Table Data Access
    /// CREATE DATE    : 2008-12-12 오후 5:45:17
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Stg_Tree_Version : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _iestterm_ref_id;
        private Int32          _iversion_ref_id;
        private String         _iversion_name;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public int IEstterm_Ref_Id
        {
            get { return _iestterm_ref_id; }
            set { _iestterm_ref_id = value; }
        }
        public int IVersion_Ref_Id
        {
            get { return _iversion_ref_id; }
            set { _iversion_ref_id = value; }
        }
        public string IVersion_Name
        {
            get { return _iversion_name; }
            set { _iversion_name = value; }
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
		public Dac_Bsc_Stg_Tree_Version() { }
        public Dac_Bsc_Stg_Tree_Version(int iestterm_ref_id, int iversion_ref_id)
        {
            DataSet ds = this.GetOneList( iestterm_ref_id,  iversion_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iestterm_ref_id             = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iversion_ref_id             = (dr["VERSION_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_REF_ID"]);
                _iversion_name               = (dr["VERSION_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["VERSION_NAME"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx,int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;
            paramArray[3]               = CreateDataParameter("@iVERSION_NAME", SqlDbType.VarChar);
            paramArray[3].Value         = iversion_name;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oVERSION_REF_ID", SqlDbType.Int);
            paramArray[7].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE_VERSION", "PKG_BSC_STG_TREE_VERSION.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IVersion_Ref_Id        = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oVERSION_REF_ID").ToString());

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, string iversion_name, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;
            paramArray[3]               = CreateDataParameter("@iVERSION_NAME", SqlDbType.VarChar);
            paramArray[3].Value         = iversion_name;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oVERSION_REF_ID", SqlDbType.Int);
            paramArray[7].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE_VERSION", "PKG_BSC_STG_TREE_VERSION.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IVersion_Ref_Id        = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oVERSION_REF_ID").ToString());

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE_VERSION", "PKG_BSC_STG_TREE_VERSION.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int iestterm_ref_id, int iversion_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_TREE_VERSION", "PKG_BSC_STG_TREE_VERSION.PROC_SELECT_ONE"), "BSC_STG_TREE_VERSION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(int iestterm_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_TREE_VERSION", "PKG_BSC_STG_TREE_VERSION.PROC_SELECT_ALL"), "BSC_STG_TREE_VERSION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}