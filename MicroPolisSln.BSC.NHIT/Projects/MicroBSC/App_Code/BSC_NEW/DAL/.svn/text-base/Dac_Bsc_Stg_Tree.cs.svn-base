using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Stg_Tree
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Stg_Tree
    /// Class Func     : BSC_STG_TREE Table Data Access
    /// CREATE DATE    : 2008-12-12 오후 4:49:08
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Stg_Tree : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private Decimal        _iidx;
        private Int32          _iestterm_ref_id;
        private Int32          _iversion_ref_id;
        private Int32          _istg_ref_id;
        private Decimal        _iparent_idx;
        private Int32          _isort_order;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public decimal IIdx
        {
            get { return _iidx; }
            set { _iidx = value; }
        }
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
        public int IStg_Ref_Id
        {
            get { return _istg_ref_id; }
            set { _istg_ref_id = value; }
        }
        public decimal IParent_Idx
        {
            get { return _iparent_idx; }
            set { _iparent_idx = value; }
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
		public Dac_Bsc_Stg_Tree() { }
        public Dac_Bsc_Stg_Tree(decimal iidx)
        {
            DataSet ds = this.GetOneList( iidx);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iidx                        = (dr["IDX"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["IDX"]);
                _iestterm_ref_id             = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iversion_ref_id             = (dr["VERSION_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_REF_ID"]);
                _istg_ref_id                 = (dr["STG_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
                _iparent_idx                 = (dr["PARENT_IDX"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["PARENT_IDX"]);
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
                (IDbConnection con, IDbTransaction trx,int iestterm_ref_id, int iversion_ref_id, int istg_ref_id, decimal iparent_idx, int isort_order, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;
            paramArray[3]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = istg_ref_id;
            paramArray[4]               = CreateDataParameter("@iPARENT_IDX", SqlDbType.Int);
            paramArray[4].Value         = iparent_idx;
            paramArray[5]               = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[5].Value         = isort_order;
            paramArray[6]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value         = itxr_user;
            paramArray[7]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[7].Direction     = ParameterDirection.Output;
            paramArray[8]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oIDX", SqlDbType.Int);
            paramArray[9].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IIdx                   = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oIDX").ToString());

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, decimal iidx, int iestterm_ref_id, int iversion_ref_id, int istg_ref_id, decimal iparent_idx, int isort_order, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iIDX", SqlDbType.Decimal);
            paramArray[1].Value         = iidx;
            paramArray[2]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iestterm_ref_id;
            paramArray[3]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iversion_ref_id;
            paramArray[4]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = istg_ref_id;
            paramArray[5]               = CreateDataParameter("@iPARENT_IDX", SqlDbType.Int);
            paramArray[5].Value         = iparent_idx;
            paramArray[6]               = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[6].Value         = isort_order;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oIDX", SqlDbType.Int);
            paramArray[10].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IIdx = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oIDX").ToString());

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, decimal iidx, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iIDX", SqlDbType.Decimal);
            paramArray[1].Value         = iidx;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int iversion_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "DV";
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

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_DELETE_VERSION"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(decimal iidx)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iIDX", SqlDbType.Decimal);
            paramArray[1].Value         = iidx;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_SELECT_ONE"), "BSC_STG_TREE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iversion_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_SELECT_ALL"), "BSC_STG_TREE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetUsedStgCount(int iestterm_ref_id, int iversion_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "ST";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iversion_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_TREE", "PKG_BSC_STG_TREE.PROC_SELECT_TREE_USED_STG"), "BSC_STG_TREE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}