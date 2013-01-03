using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_External_Score
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Kpi_External_Score
    /// Class Func     : BSC_KPI_EXTERNAL_SCORE Table Data Access
    /// CREATE DATE    : 2009-02-04 오후 5:38:08
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_External_Score : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _iestterm_ref_id;
        private String         _iymd;
        private Int32          _ikpi_ref_id;
        private Decimal        _iweight_inr;
        private Decimal        _iweight_ext;
        private Decimal        _itarget_ext;
        private Decimal        _iresult_ext;
        private Decimal        _ipoints_ext;
        private String         _igrade_ext;
        private String         _iopinion_ext;
        private String         _iaction_inr;
        private String         _iopinion_file;
        private String         _iuse_yn;
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
        public string IYmd
        {
            get { return _iymd; }
            set { _iymd = value; }
        }
        public int IKpi_Ref_Id
        {
            get { return _ikpi_ref_id; }
            set { _ikpi_ref_id = value; }
        }
        public decimal IWeight_Inr
        {
            get { return _iweight_inr; }
            set { _iweight_inr = value; }
        }
        public decimal IWeight_Ext
        {
            get { return _iweight_ext; }
            set { _iweight_ext = value; }
        }
        public decimal ITarget_Ext
        {
            get { return _itarget_ext; }
            set { _itarget_ext = value; }
        }
        public decimal IResult_Ext
        {
            get { return _iresult_ext; }
            set { _iresult_ext = value; }
        }
        public decimal IPoints_Ext
        {
            get { return _ipoints_ext; }
            set { _ipoints_ext = value; }
        }
        public string IGrade_Ext
        {
            get { return _igrade_ext; }
            set { _igrade_ext = value; }
        }
        public string IOpinion_Ext
        {
            get { return _iopinion_ext; }
            set { _iopinion_ext = value; }
        }
        public string IAction_Inr
        {
            get { return _iaction_inr; }
            set { _iaction_inr = value; }
        }
        public string IOpinion_File
        {
            get { return _iopinion_file; }
            set { _iopinion_file = value; }
        }
        public string IUse_Yn
        {
            get { return _iuse_yn; }
            set { _iuse_yn = value; }
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
		public Dac_Bsc_Kpi_External_Score() { }
        public Dac_Bsc_Kpi_External_Score(int iestterm_ref_id, string iymd, int ikpi_ref_id)
        {
            DataSet ds = this.GetOneList( iestterm_ref_id,  iymd,  ikpi_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iestterm_ref_id         = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iymd                    = (dr["YMD"]            == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _ikpi_ref_id             = (dr["KPI_REF_ID"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["KPI_REF_ID"]);
                _iweight_inr             = (dr["WEIGHT_INR"]     == DBNull.Value) ? 0  : Convert.ToDecimal(dr["WEIGHT_INR"]);
                _iweight_ext             = (dr["WEIGHT_EXT"]     == DBNull.Value) ? 0  : Convert.ToDecimal(dr["WEIGHT_EXT"]);
                _itarget_ext             = (dr["TARGET_EXT"]     == DBNull.Value) ? 0 : Convert.ToDecimal(dr["TARGET_EXT"]);
                _iresult_ext             = (dr["RESULT_EXT"]     == DBNull.Value) ? 0 : Convert.ToDecimal(dr["RESULT_EXT"]);
                _ipoints_ext             = (dr["POINTS_EXT"]     == DBNull.Value) ? 0  : Convert.ToDecimal(dr["POINTS_EXT"]);
                _igrade_ext              = (dr["GRADE_EXT"]      == DBNull.Value) ? "" : Convert.ToString(dr["GRADE_EXT"]);
                _iopinion_ext            = (dr["OPINION_EXT"]    == DBNull.Value) ? "" : Convert.ToString(dr["OPINION_EXT"]);
                _iaction_inr             = (dr["ACTION_INR"]     == DBNull.Value) ? "" : Convert.ToString(dr["ACTION_INR"]);
                _iopinion_file           = (dr["OPINION_FILE"]   == DBNull.Value) ? "" : Convert.ToString(dr["OPINION_FILE"]);
                _iuse_yn                 = (dr["USE_YN"]         == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icreate_user            = (dr["CREATE_USER"]    == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date            = (dr["CREATE_DATE"]    == DBNull.Value) ?      DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user            = (dr["UPDATE_USER"]    == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date            = (dr["UPDATE_DATE"]    == DBNull.Value) ?      DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, string iymd, int ikpi_ref_id, decimal iweight_inr, decimal iweight_ext
                 , decimal itarget_ext, decimal iresult_ext, decimal ipoints_ext, string igrade_ext, string iopinion_ext, string iaction_inr, string iopinion_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@iWEIGHT_INR", SqlDbType.Decimal);
            paramArray[4].Value         = iweight_inr;
            paramArray[5]               = CreateDataParameter("@iWEIGHT_EXT", SqlDbType.Decimal);
            paramArray[5].Value         = iweight_ext;
            paramArray[6]               = CreateDataParameter("@iTARGET_EXT", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ext;
            paramArray[7]               = CreateDataParameter("@iRESULT_EXT", SqlDbType.Decimal);
            paramArray[7].Value         = iresult_ext;
            paramArray[8]               = CreateDataParameter("@iPOINTS_EXT", SqlDbType.Decimal);
            paramArray[8].Value         = ipoints_ext;
            paramArray[9]               = CreateDataParameter("@iGRADE_EXT", SqlDbType.VarChar);
            paramArray[9].Value         = igrade_ext;
            paramArray[10]              = CreateDataParameter("@iOPINION_EXT", SqlDbType.VarChar);
            paramArray[10].Value        = iopinion_ext;
            paramArray[11]              = CreateDataParameter("@iACTION_INR", SqlDbType.VarChar);
            paramArray[11].Value        = iaction_inr;
            paramArray[12]              = CreateDataParameter("@iOPINION_FILE", SqlDbType.VarChar);
            paramArray[12].Value        = iopinion_file;
            paramArray[13]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[13].Value        = iuse_yn;
	        paramArray[14] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[14].Value 	    = itxr_user;
            paramArray[15]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[16].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_KPI_EXTERNAL_SCORE", "PKG_BSC_KPI_EXTERNAL_SCORE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, string iymd, int ikpi_ref_id, decimal iweight_inr, decimal iweight_ext
                , decimal itarget_ext, decimal iresult_ext, decimal ipoints_ext, string igrade_ext, string iopinion_ext, string iaction_inr, string iopinion_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@iWEIGHT_INR", SqlDbType.Decimal);
            paramArray[4].Value         = iweight_inr;
            paramArray[5]               = CreateDataParameter("@iWEIGHT_EXT", SqlDbType.Decimal);
            paramArray[5].Value         = iweight_ext;
            paramArray[6]               = CreateDataParameter("@iTARGET_EXT", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ext;
            paramArray[7]               = CreateDataParameter("@iRESULT_EXT", SqlDbType.Decimal);
            paramArray[7].Value         = iresult_ext;
            paramArray[8]               = CreateDataParameter("@iPOINTS_EXT", SqlDbType.Decimal);
            paramArray[8].Value         = ipoints_ext;
            paramArray[9]               = CreateDataParameter("@iGRADE_EXT", SqlDbType.VarChar);
            paramArray[9].Value         = igrade_ext;
            paramArray[10]              = CreateDataParameter("@iOPINION_EXT", SqlDbType.VarChar);
            paramArray[10].Value        = iopinion_ext;
            paramArray[11]              = CreateDataParameter("@iACTION_INR", SqlDbType.VarChar);
            paramArray[11].Value        = iaction_inr;
            paramArray[12]              = CreateDataParameter("@iOPINION_FILE", SqlDbType.VarChar);
            paramArray[12].Value        = iopinion_file;
            paramArray[13]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[13].Value        = iuse_yn;
	        paramArray[14] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[14].Value 	    = itxr_user;
            paramArray[15]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[16].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_KPI_EXTERNAL_SCORE", "PKG_BSC_KPI_EXTERNAL_SCORE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, int iestterm_ref_id, string iymd, int ikpi_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_KPI_EXTERNAL_SCORE", "PKG_BSC_KPI_EXTERNAL_SCORE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int iestterm_ref_id, string iymd, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_EXTERNAL_SCORE", "PKG_BSC_KPI_EXTERNAL_SCORE.PROC_SELECT_ONE"), "BSC_KPI_EXTERNAL_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(int iestterm_ref_id, string iymd, int ikpi_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_EXTERNAL_SCORE", "PKG_BSC_KPI_EXTERNAL_SCORE.PROC_SELECT_ALL"), "BSC_KPI_EXTERNAL_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiExternalScore(int iestterm_ref_id, string iymd, string ikpi_code, string ikpi_name, int idept_ref_id, string ikpi_group_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SE";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = idept_ref_id;
            paramArray[6]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[6].Value         = ikpi_group_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_EXTERNAL_SCORE", "PKG_BSC_KPI_EXTERNAL_SCORE.PROC_SELECT_KPI_EXT_SCORE"), "BSC_KPI_EXTERNAL_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}