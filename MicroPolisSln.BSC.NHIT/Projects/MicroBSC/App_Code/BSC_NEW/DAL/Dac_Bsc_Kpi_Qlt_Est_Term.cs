using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Qlt_Est_Term
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Kpi_Qlt_Est_Term
    /// Class Func     : BSC_KPI_QLT_EST_TERM Table Data Access
    /// CREATE DATE    : 2009-03-24 오후 3:55:45
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Qlt_Est_Term : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _iestterm_ref_id;
        private Int32          _igroup_ref_id;
        private Int32          _iest_level;
        private String         _iymd;
        private String         _iest_yn;
        private String         _ibias_yn;
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
        public int IGroup_Ref_Id
        {
            get { return _igroup_ref_id; }
            set { _igroup_ref_id = value; }
        }
        public int IEst_Level
        {
            get { return _iest_level; }
            set { _iest_level = value; }
        }
        public string IYmd
        {
            get { return _iymd; }
            set { _iymd = value; }
        }
        public string IBias_Yn
        {
            get { return _ibias_yn; }
            set { _ibias_yn = value; }
        }
        public string IEst_Yn
        {
            get { return _iest_yn; }
            set { _iest_yn = value; }
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
		public Dac_Bsc_Kpi_Qlt_Est_Term() { }
        public Dac_Bsc_Kpi_Qlt_Est_Term(int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd)
        {
            DataSet ds = this.GetOneList( iestterm_ref_id,  igroup_ref_id,  iest_level,  iymd);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iestterm_ref_id             = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _igroup_ref_id               = (dr["GROUP_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["GROUP_REF_ID"]);
                _iest_level                  = (dr["EST_LEVEL"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_LEVEL"]);
                _iymd                        = (dr["YMD"] == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _iest_yn                     = (dr["EST_YN"]  == DBNull.Value) ? "" : Convert.ToString(dr["EST_YN"]);
                _ibias_yn                    = (dr["BIAS_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["BIAS_YN"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd, string iest_yn, string ibias_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = igroup_ref_id;
            paramArray[3]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[3].Value         = iest_level;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iEST_YN", SqlDbType.Char);
            paramArray[5].Value         = iest_yn;
            paramArray[6]               = CreateDataParameter("@iBIAS_YN", SqlDbType.Char);
            paramArray[6].Value         = ibias_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_KPI_QLT_EST_TERM", "PKG_BSC_KPI_QLT_EST_TERM.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd, string iest_yn, string ibias_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = igroup_ref_id;
            paramArray[3]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[3].Value         = iest_level;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iEST_YN", SqlDbType.Char);
            paramArray[5].Value         = iest_yn;
            paramArray[6]               = CreateDataParameter("@iBIAS_YN", SqlDbType.Char);
            paramArray[6].Value         = ibias_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_KPI_QLT_EST_TERM", "PKG_BSC_KPI_QLT_EST_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = igroup_ref_id;
            paramArray[3]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[3].Value         = iest_level;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_KPI_QLT_EST_TERM", "PKG_BSC_KPI_QLT_EST_TERM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = igroup_ref_id;
            paramArray[3]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[3].Value         = iest_level;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_EST_TERM", "PKG_BSC_KPI_QLT_EST_TERM.PROC_SELECT_ONE"), "BSC_KPI_QLT_EST_TERM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(int iestterm_ref_id, int igroup_ref_id, int iest_level)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = igroup_ref_id;
            paramArray[3]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[3].Value         = iest_level;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_EST_TERM", "PKG_BSC_KPI_QLT_EST_TERM.PROC_SELECT_ALL"), "BSC_KPI_QLT_EST_TERM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}