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

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Result_Expect
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Kpi_Result_Expect
    /// Class Func     : BSC_KPI_RESULT_EXPECT Table Data Access
    /// CREATE DATE    : 2008-07-12 오전 9:37:37
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Result_Expect : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _iestterm_ref_id;
        private Int32          _ikpi_ref_id;
        private String         _iymd;
        private Decimal        _iresult_ms;
        private Decimal        _iresult_ts;
        private String         _iexpect_reason_ms;
        private String         _iexpect_reason_ts;
        private String         _iexpect_reason_file_id;
        private String         _iresult_diff_cause;
        private String         _iresult_diff_file_id;
        private DateTime       _icreate_date;
        private Int32          _icreate_user;
        private DateTime       _iupdate_date;
        private Int32          _iupdate_user;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public int IEstterm_Ref_Id
        {
            get { return _iestterm_ref_id; }
            set { _iestterm_ref_id = value; }
        }
        public int IKpi_Ref_Id
        {
            get { return _ikpi_ref_id; }
            set { _ikpi_ref_id = value; }
        }
        public string IYmd
        {
            get { return _iymd; }
            set { _iymd = value; }
        }
        public decimal IResult_Ms
        {
            get { return _iresult_ms; }
            set { _iresult_ms = value; }
        }
        public decimal IResult_Ts
        {
            get { return _iresult_ts; }
            set { _iresult_ts = value; }
        }
        public string IExpect_Reason_Ms
        {
            get { return _iexpect_reason_ms; }
            set { _iexpect_reason_ms = value; }
        }
        public string IExpect_Reason_Ts
        {
            get { return _iexpect_reason_ts; }
            set { _iexpect_reason_ts = value; }
        }
        public string IExpect_Reason_File_Id
        {
            get { return _iexpect_reason_file_id; }
            set { _iexpect_reason_file_id = value; }
        }
        public string IResult_Diff_Cause
        {
            get { return _iresult_diff_cause; }
            set { _iresult_diff_cause = value; }
        }
        public string IResult_Diff_File_Id
        {
            get { return _iresult_diff_file_id; }
            set { _iresult_diff_file_id = value; }
        }
        public System.DateTime ICreate_Date
        {
            get { return _icreate_date; }
            set { _icreate_date = value; }
        }
        public int ICreate_User
        {
            get { return _icreate_user; }
            set { _icreate_user = value; }
        }
        public System.DateTime IUpdate_Date
        {
            get { return _iupdate_date; }
            set { _iupdate_date = value; }
        }
        public int IUpdate_User
        {
            get { return _iupdate_user; }
            set { _iupdate_user = value; }
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
		public Dac_Bsc_Kpi_Result_Expect() { }
        public Dac_Bsc_Kpi_Result_Expect(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            DataSet ds = this.GetOneList( iestterm_ref_id,  ikpi_ref_id,  iymd);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iestterm_ref_id             = (dr["ESTTERM_REF_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id                 = (dr["KPI_REF_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _iymd                        = (dr["YMD"]                   == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _iresult_ms                  = (dr["RESULT_MS"]             == DBNull.Value) ? 0 : Convert.ToDecimal(dr["RESULT_MS"]);
                _iresult_ts                  = (dr["RESULT_TS"]             == DBNull.Value) ? 0 : Convert.ToDecimal(dr["RESULT_TS"]);
                _iexpect_reason_ms           = (dr["EXPECT_REASON_MS"]      == DBNull.Value) ? "" : Convert.ToString(dr["EXPECT_REASON_MS"]);
                _iexpect_reason_ts           = (dr["EXPECT_REASON_TS"]      == DBNull.Value) ? "" : Convert.ToString(dr["EXPECT_REASON_TS"]);
                _iexpect_reason_file_id      = (dr["EXPECT_REASON_FILE_ID"] == DBNull.Value) ? "" : Convert.ToString(dr["EXPECT_REASON_FILE_ID"]);
                _iresult_diff_cause          = (dr["RESULT_DIFF_CAUSE"]     == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_DIFF_CAUSE"]);
                _iresult_diff_file_id        = (dr["RESULT_DIFF_FILE_ID"]   == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_DIFF_FILE_ID"]);
                _icreate_date                = (dr["CREATE_DATE"]           == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _icreate_user                = (dr["CREATE_USER"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"]           == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);;
			}
            else
            {
                _iestterm_ref_id        = iestterm_ref_id;
                _ikpi_ref_id            = ikpi_ref_id;
                _iymd                   = iymd;
                _iresult_ms             = 0;
                _iresult_ts             = 0;
                _iexpect_reason_ms      = "";
                _iexpect_reason_ts      = "";
                _iexpect_reason_file_id = "";
                _iresult_diff_cause     = "";
                _iresult_diff_file_id   = "";
            }
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iestterm_ref_id, int ikpi_ref_id, string iymd, decimal iresult_ms, decimal iresult_ts, string iexpect_reason_ms, string iexpect_reason_ts, string iexpect_reason_file_id, string iresult_diff_cause, string iresult_diff_file_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iRESULT_MS", SqlDbType.Decimal);
            paramArray[4].Value         = iresult_ms;
            paramArray[5]               = CreateDataParameter("@iRESULT_TS", SqlDbType.Decimal);
            paramArray[5].Value         = iresult_ts;
            paramArray[6]               = CreateDataParameter("@iEXPECT_REASON_MS", SqlDbType.VarChar);
            paramArray[6].Value         = iexpect_reason_ms;
            paramArray[7]               = CreateDataParameter("@iEXPECT_REASON_TS", SqlDbType.VarChar);
            paramArray[7].Value         = iexpect_reason_ts;
            paramArray[8]               = CreateDataParameter("@iEXPECT_REASON_FILE_ID", SqlDbType.VarChar);
            paramArray[8].Value         = iexpect_reason_file_id;
            paramArray[9]               = CreateDataParameter("@iRESULT_DIFF_CAUSE", SqlDbType.VarChar);
            paramArray[9].Value         = iresult_diff_cause;
            paramArray[10]              = CreateDataParameter("@iRESULT_DIFF_FILE_ID", SqlDbType.VarChar);
            paramArray[10].Value        = iresult_diff_file_id;
            paramArray[11]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value        = itxr_user;
            paramArray[12]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[12].Direction    = ParameterDirection.Output;
            paramArray[13]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[13].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT_EXPECT", "PKG_BSC_KPI_RESULT_EXPECT.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (int iestterm_ref_id, int ikpi_ref_id, string iymd, decimal iresult_ms, decimal iresult_ts, string iexpect_reason_ms, string iexpect_reason_ts, string iexpect_reason_file_id, string iresult_diff_cause, string iresult_diff_file_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iRESULT_MS", SqlDbType.Decimal);
            paramArray[4].Value         = iresult_ms;
            paramArray[5]               = CreateDataParameter("@iRESULT_TS", SqlDbType.Decimal);
            paramArray[5].Value         = iresult_ts;
            paramArray[6]               = CreateDataParameter("@iEXPECT_REASON_MS", SqlDbType.VarChar);
            paramArray[6].Value         = iexpect_reason_ms;
            paramArray[7]               = CreateDataParameter("@iEXPECT_REASON_TS", SqlDbType.VarChar);
            paramArray[7].Value         = iexpect_reason_ts;
            paramArray[8]               = CreateDataParameter("@iEXPECT_REASON_FILE_ID", SqlDbType.VarChar);
            paramArray[8].Value         = iexpect_reason_file_id;
            paramArray[9]               = CreateDataParameter("@iRESULT_DIFF_CAUSE", SqlDbType.VarChar);
            paramArray[9].Value         = iresult_diff_cause;
            paramArray[10]              = CreateDataParameter("@iRESULT_DIFF_FILE_ID", SqlDbType.VarChar);
            paramArray[10].Value        = iresult_diff_file_id;
            paramArray[11]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value        = itxr_user;
            paramArray[12]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[12].Direction    = ParameterDirection.Output;
            paramArray[13]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[13].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT_EXPECT", "PKG_BSC_KPI_RESULT_EXPECT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT_EXPECT", "PKG_BSC_KPI_RESULT_EXPECT.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT_EXPECT", "PKG_BSC_KPI_RESULT_EXPECT.PROC_SELECT_ONE"), "BSC_KPI_RESULT_EXPECT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT_EXPECT", "PKG_BSC_KPI_RESULT_EXPECT.PROC_SELECT_ALL"), "BSC_KPI_RESULT_EXPECT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetResultExpect(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        { 
	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "RE";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT_EXPECT", "PKG_BSC_KPI_RESULT_EXPECT.PROC_SELECT_RESULT_EXPECT"), "BSC_KPI_RESULT_EXPECT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}