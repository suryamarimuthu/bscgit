using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Interface_Kpi_Query
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Interface_Kpi_Query
    /// Class Func     : BSC_INTERFACE_KPI_QUERY Table Data Access
    /// CREATE DATE    : 2008-07-27 오후 3:47:20
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Interface_Kpi_Query : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _ikpi_ref_id;
        private String         _idicode;
        private Int32          _iversion_no;
        private String         _iactive_yn;
        private String         _iresult_field_al;
        private String         _iresult_where_al;
        private String         _iresult_field_ms;
        private String         _iresult_where_ms;
        private String         _iresult_field_ts;
        private String         _iresult_where_ts;
        private String         _iquery_al;
        private String         _iquery_ms;
        private String         _iquery_ts;
        private String         _iisvalid_query;
        private String         _imodify_reason;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public int IKpi_Ref_Id
        {
            get { return _ikpi_ref_id; }
            set { _ikpi_ref_id = value; }
        }
        public string IDicode
        {
            get { return _idicode; }
            set { _idicode = value; }
        }
        public int IVersion_No
        {
            get { return _iversion_no; }
            set { _iversion_no = value; }
        }
        public string IActive_Yn
        {
            get { return _iactive_yn; }
            set { _iactive_yn = value; }
        }
        public string IResult_Field_Al
        {
            get { return _iresult_field_al; }
            set { _iresult_field_al = value; }
        }
        public string IResult_Where_Al
        {
            get { return _iresult_where_al; }
            set { _iresult_where_al = value; }
        }
        public string IResult_Field_Ms
        {
            get { return _iresult_field_ms; }
            set { _iresult_field_ms = value; }
        }
        public string IResult_Where_Ms
        {
            get { return _iresult_where_ms; }
            set { _iresult_where_ms = value; }
        }
        public string IResult_Field_Ts
        {
            get { return _iresult_field_ts; }
            set { _iresult_field_ts = value; }
        }
        public string IResult_Where_Ts
        {
            get { return _iresult_where_ts; }
            set { _iresult_where_ts = value; }
        }
        public string IQuery_Al
        {
            get { return _iquery_al; }
            set { _iquery_al = value; }
        }
        public string IQuery_Ms
        {
            get { return _iquery_ms; }
            set { _iquery_ms = value; }
        }
        public string IQuery_Ts
        {
            get { return _iquery_ts; }
            set { _iquery_ts = value; }
        }
        public string IIsvalid_Query
        {
            get { return _iisvalid_query; }
            set { _iisvalid_query = value; }
        }
        public string IModify_Reason
        {
            get { return _imodify_reason; }
            set { _imodify_reason = value; }
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
		public Dac_Bsc_Interface_Kpi_Query() { }
        public Dac_Bsc_Interface_Kpi_Query(int ikpi_ref_id, string idicode)
        {
            DataSet ds = this.GetOneList( ikpi_ref_id,  idicode);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_ikpi_ref_id                 = (dr["KPI_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _idicode                     = (dr["DICODE"] == DBNull.Value) ? "" : Convert.ToString(dr["DICODE"]);
                _iversion_no                 = (dr["VERSION_NO"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                _iactive_yn                  = (dr["ACTIVE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["ACTIVE_YN"]);
                _iresult_field_al            = (dr["RESULT_FIELD_AL"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_FIELD_AL"]);
                _iresult_where_al            = (dr["RESULT_WHERE_AL"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_WHERE_AL"]);
                _iresult_field_ms            = (dr["RESULT_FIELD_MS"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_FIELD_MS"]);
                _iresult_where_ms            = (dr["RESULT_WHERE_MS"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_WHERE_MS"]);
                _iresult_field_ts            = (dr["RESULT_FIELD_TS"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_FIELD_TS"]);
                _iresult_where_ts            = (dr["RESULT_WHERE_TS"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_WHERE_TS"]);
                _iquery_al                   = (dr["QUERY_AL"] == DBNull.Value) ? "" : Convert.ToString(dr["QUERY_AL"]);
                _iquery_ms                   = (dr["QUERY_MS"] == DBNull.Value) ? "" : Convert.ToString(dr["QUERY_MS"]);
                _iquery_ts                   = (dr["QUERY_TS"] == DBNull.Value) ? "" : Convert.ToString(dr["QUERY_TS"]);
                _iisvalid_query              = (dr["ISVALID_QUERY"] == DBNull.Value) ? "" : Convert.ToString(dr["ISVALID_QUERY"]);
                _imodify_reason              = (dr["MODIFY_REASON"] == DBNull.Value) ? "" : Convert.ToString(dr["MODIFY_REASON"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, int ikpi_ref_id, string idicode, int iversion_no, string iactive_yn, string iresult_field_al, string iresult_where_al, string iresult_field_ms, string iresult_where_ms, string iresult_field_ts, string iresult_where_ts, string iquery_al, string iquery_ms, string iquery_ts, string iisvalid_query, string imodify_reason, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[2].Value         = idicode;
            paramArray[3]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[3].Value         = iversion_no;
            paramArray[4]               = CreateDataParameter("@iACTIVE_YN", SqlDbType.Char);
            paramArray[4].Value         = iactive_yn;
            paramArray[5]               = CreateDataParameter("@iRESULT_FIELD_AL", SqlDbType.NVarChar);
            paramArray[5].Value         = iresult_field_al;
            paramArray[6]               = CreateDataParameter("@iRESULT_WHERE_AL", SqlDbType.NVarChar);
            paramArray[6].Value         = iresult_where_al;
            paramArray[7]               = CreateDataParameter("@iRESULT_FIELD_MS", SqlDbType.NVarChar);
            paramArray[7].Value         = iresult_field_ms;
            paramArray[8]               = CreateDataParameter("@iRESULT_WHERE_MS", SqlDbType.NVarChar);
            paramArray[8].Value         = iresult_where_ms;
            paramArray[9]               = CreateDataParameter("@iRESULT_FIELD_TS", SqlDbType.NVarChar);
            paramArray[9].Value         = iresult_field_ts;
            paramArray[10]               = CreateDataParameter("@iRESULT_WHERE_TS", SqlDbType.NVarChar);
            paramArray[10].Value         = iresult_where_ts;
            paramArray[11]               = CreateDataParameter("@iQUERY_AL", SqlDbType.NText);
            paramArray[11].Value         = iquery_al;
            paramArray[12]               = CreateDataParameter("@iQUERY_MS", SqlDbType.NText);
            paramArray[12].Value         = iquery_ms;
            paramArray[13]               = CreateDataParameter("@iQUERY_TS", SqlDbType.NText);
            paramArray[13].Value         = iquery_ts;
            paramArray[14]               = CreateDataParameter("@iISVALID_QUERY", SqlDbType.Char);
            paramArray[14].Value         = iisvalid_query;
            paramArray[15]               = CreateDataParameter("@iMODIFY_REASON", SqlDbType.NVarChar);
            paramArray[15].Value         = imodify_reason;
            paramArray[16]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[16].Value         = itxr_user;
            paramArray[17]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[17].Direction     = ParameterDirection.Output;
            paramArray[18]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[18].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_KPI_QUERY", "PKG_BSC_INTERFACE_KPI_QUERY.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, int ikpi_ref_id, string idicode, int iversion_no, string iactive_yn, string iresult_field_al, string iresult_where_al, string iresult_field_ms, string iresult_where_ms, string iresult_field_ts, string iresult_where_ts, string iquery_al, string iquery_ms, string iquery_ts, string iisvalid_query, string imodify_reason, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[2].Value         = idicode;
            paramArray[3]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[3].Value         = iversion_no;
            paramArray[4]               = CreateDataParameter("@iACTIVE_YN", SqlDbType.Char);
            paramArray[4].Value         = iactive_yn;
            paramArray[5]               = CreateDataParameter("@iRESULT_FIELD_AL", SqlDbType.NVarChar);
            paramArray[5].Value         = iresult_field_al;
            paramArray[6]               = CreateDataParameter("@iRESULT_WHERE_AL", SqlDbType.NVarChar);
            paramArray[6].Value         = iresult_where_al;
            paramArray[7]               = CreateDataParameter("@iRESULT_FIELD_MS", SqlDbType.NVarChar);
            paramArray[7].Value         = iresult_field_ms;
            paramArray[8]               = CreateDataParameter("@iRESULT_WHERE_MS", SqlDbType.NVarChar);
            paramArray[8].Value         = iresult_where_ms;
            paramArray[9]               = CreateDataParameter("@iRESULT_FIELD_TS", SqlDbType.NVarChar);
            paramArray[9].Value         = iresult_field_ts;
            paramArray[10]              = CreateDataParameter("@iRESULT_WHERE_TS", SqlDbType.NVarChar);
            paramArray[10].Value        = iresult_where_ts;
            paramArray[11]              = CreateDataParameter("@iQUERY_AL", SqlDbType.NText);
            paramArray[11].Value        = iquery_al;
            paramArray[12]              = CreateDataParameter("@iQUERY_MS", SqlDbType.NText);
            paramArray[12].Value        = iquery_ms;
            paramArray[13]              = CreateDataParameter("@iQUERY_TS", SqlDbType.NText);
            paramArray[13].Value        = iquery_ts;
            paramArray[14]              = CreateDataParameter("@iISVALID_QUERY", SqlDbType.Char);
            paramArray[14].Value        = iisvalid_query;
            paramArray[15]              = CreateDataParameter("@iMODIFY_REASON", SqlDbType.NVarChar);
            paramArray[15].Value        = imodify_reason;
            paramArray[16]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[16].Value        = itxr_user;
            paramArray[17]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[17].Direction    = ParameterDirection.Output;
            paramArray[18]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[18].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_KPI_QUERY", "PKG_BSC_INTERFACE_KPI_QUERY.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, int ikpi_ref_id, string idicode, int iversion_no, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[2].Value         = idicode;
            paramArray[3]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[3].Value         = iversion_no;
            paramArray[4]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction    = ParameterDirection.Output;
            paramArray[5]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_KPI_QUERY", "PKG_BSC_INTERFACE_KPI_QUERY.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int ikpi_ref_id, string idicode)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[2].Value         = idicode;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_KPI_QUERY", "PKG_BSC_INTERFACE_KPI_QUERY.PROC_SELECT_ONE"), "BSC_INTERFACE_KPI_QUERY", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(int ikpi_ref_id, string idicode)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[2].Value         = idicode;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_KPI_QUERY", "PKG_BSC_INTERFACE_KPI_QUERY.PROC_SELECT_ALL"), "BSC_INTERFACE_KPI_QUERY", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetQueryMappingStatus(int iestterm_ref_id, string idicode, string ikpi_code, string ikpi_name, string ichampion_name, string iis_team_kpi
                                           , string iuse_yn, string iis_set_query)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SM";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[2].Value         = idicode;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ichampion_name;
            paramArray[6]               = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[6].Value         = iis_team_kpi;
            paramArray[7]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[7].Value         = iuse_yn;
            paramArray[8]               = CreateDataParameter("@iIS_SET_QUERY", SqlDbType.VarChar);
            paramArray[8].Value         = iis_set_query;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_KPI_QUERY", "PKG_BSC_INTERFACE_KPI_QUERY.PROC_SELECT_QRY_MAPPING"), "BSC_INTERFACE_KPI_QUERY", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

		#endregion
	}
}