using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Dac_Bsc_Kpi_Result의 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Result Dac 클래스
/// Class 내용		@ Bsc_Kpi_Result Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Result : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int      _iestterm_ref_id;
        private int      _ikpi_ref_id;
        private string   _iymd;
        private double   _iresult_ms;
        private double   _iresult_ts;
        private int      _isequence;
        private string   _icheckstatus;
        private DateTime _icheck_date;
        private string   _iconfirmstatus;
        private DateTime _iconfirm_date;
        private double   _ical_result_ms;
        private double   _ical_result_ts;
        private string   _ical_apply_yn;
        private string   _ical_apply_reason;
        private string   _icause_text_ms;
        private string   _icause_text_ts;
        private string   _icause_file_id;
        private string   _imeasure_text_ms;
        private string   _imeasure_text_ts;
        private string   _imeasure_file_id;
        private string   _iremark;
        private decimal  _iapp_ref_id;
        private string   _iapp_status;
        private int      _itxr_user;
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

        public int Ikpi_ref_id
        {
            get
            {
                return _ikpi_ref_id;
            }
            set
            {
                _ikpi_ref_id = value;
            }
        }

        public string Iymd
        {
            get
            {
                return _iymd;
            }
            set
            {
                _iymd = (value == null ? "" : value);
            }
        }

        public double Iresult_ms
        {
            get
            {
                return _iresult_ms;
            }
            set
            {
                _iresult_ms = value;
            }
        }

        public double Iresult_ts
        {
            get
            {
                return _iresult_ts;
            }
            set
            {
                _iresult_ts = value;
            }
        }

        public int Isequence
        {
            get
            {
                return _isequence;
            }
            set
            {
                _isequence = value;
            }
        }

        public string Icheckstatus
        {
            get
            {
                return _icheckstatus;
            }
            set
            {
                _icheckstatus = (value == null ? "" : value);
            }
        }

        public DateTime Icheck_date
        {
            get
            {
                return _icheck_date;
            }
            set
            {
                _icheck_date = value;
            }
        }

        public string Iconfirmstatus
        {
            get
            {
                return _iconfirmstatus;
            }
            set
            {
                _iconfirmstatus = (value == null ? "" : value);
            }
        }

        public DateTime Iconfirm_date
        {
            get
            {
                return _iconfirm_date;
            }
            set
            {
                _iconfirm_date = value;
            }
        }

        public double Ical_result_ms
        {
            get
            {
                return _ical_result_ms;
            }
            set
            {
                _ical_result_ms = value;
            }
        }

        public double Ical_result_ts
        {
            get
            {
                return _ical_result_ts;
            }
            set
            {
                _ical_result_ts = value;
            }
        }

        public string Ical_apply_yn
        {
            get
            {
                return _ical_apply_yn;
            }
            set
            {
                _ical_apply_yn = (value == null ? "" : value);
            }
        }

        public string Ical_apply_reason
        {
            get
            {
                return _ical_apply_reason;
            }
            set
            {
                _ical_apply_reason = (value == null ? "" : value);
            }
        }

        public string Icause_text_ms
        {
            get
            {
                return _icause_text_ms;
            }
            set
            {
                _icause_text_ms = (value == null ? "" : value);
            }
        }

        public string Icause_text_ts
        {
            get
            {
                return _icause_text_ts;
            }
            set
            {
                _icause_text_ts = (value == null ? "" : value);
            }
        }

        public string Icause_file_id
        {
            get
            {
                return _icause_file_id;
            }
            set
            {
                _icause_file_id = (value == null ? "" : value);
            }
        }

        public string Imeasure_text_ms
        {
            get
            {
                return _imeasure_text_ms;
            }
            set
            {
                _imeasure_text_ms = (value == null ? "" : value);
            }
        }

        public string Imeasure_text_ts
        {
            get
            {
                return _imeasure_text_ts;
            }
            set
            {
                _imeasure_text_ts = (value == null ? "" : value);
            }
        }

        public string Imeasure_file_id
        {
            get
            {
                return _imeasure_file_id;
            }
            set
            {
                _imeasure_file_id = (value == null ? "" : value);
            }
        }

        public string Iremark
        {
            get
            {
                return _iremark;
            }
            set
            {
                _iremark = (value == null ? "" : value);
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

        public string Iapp_status
        {
            get
            {
                return _iapp_status;
            }
            set
            {
                _iapp_status = value;
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
        public Dac_Bsc_Kpi_Result() { }

        public Dac_Bsc_Kpi_Result(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, iymd);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id   = (dr["ESTTERM_REF_ID"]   == DBNull.Value) ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id       = (dr["KPI_REF_ID"]       == DBNull.Value) ? 0  : Convert.ToInt32(dr["KPI_REF_ID"]);
                _iymd              = (dr["YMD"]              == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _iresult_ms        = (dr["RESULT_MS"]        == DBNull.Value) ? 0  : Convert.ToDouble(dr["RESULT_MS"]);
                _iresult_ts        = (dr["RESULT_TS"]        == DBNull.Value) ? 0  : Convert.ToDouble(dr["RESULT_TS"]);
                _isequence         = (dr["SEQUENCE"]         == DBNull.Value) ? 0  : Convert.ToInt32(dr["SEQUENCE"]);
                _icheckstatus      = (dr["CHECKSTATUS"]      == DBNull.Value) ? "" : Convert.ToString(dr["CHECKSTATUS"]);
                _icheck_date       = (dr["CHECK_DATE"]       == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CHECK_DATE"]);
                _iconfirmstatus    = (dr["CONFIRMSTATUS"]    == DBNull.Value) ? "" : Convert.ToString(dr["CONFIRMSTATUS"]);
                _iconfirm_date     = (dr["CONFIRM_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CONFIRM_DATE"]);
                _ical_result_ms    = (dr["CAL_RESULT_MS"]    == DBNull.Value) ? 0  : Convert.ToDouble(dr["CAL_RESULT_MS"]);
                _ical_result_ts    = (dr["CAL_RESULT_TS"]    == DBNull.Value) ? 0  : Convert.ToDouble(dr["CAL_RESULT_TS"]);
                _ical_apply_yn     = (dr["CAL_APPLY_YN"]     == DBNull.Value) ? "" : Convert.ToString(dr["CAL_APPLY_YN"]);
                _ical_apply_reason = (dr["CAL_APPLY_REASON"] == DBNull.Value) ? "" : Convert.ToString(dr["CAL_APPLY_REASON"]);
		        _icause_text_ms    = (dr["CAUSE_TEXT_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["CAUSE_TEXT_MS"]);
		        _icause_text_ts    = (dr["CAUSE_TEXT_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["CAUSE_TEXT_TS"]);
		        _icause_file_id    = (dr["CAUSE_FILE_ID"]    == DBNull.Value) ? "" : Convert.ToString(dr["CAUSE_FILE_ID"]);
		        _imeasure_text_ms  = (dr["MEASURE_TEXT_MS"]  == DBNull.Value) ? "" : Convert.ToString(dr["MEASURE_TEXT_MS"]);
		        _imeasure_text_ts  = (dr["MEASURE_TEXT_TS"]  == DBNull.Value) ? "" : Convert.ToString(dr["MEASURE_TEXT_TS"]);
		        _imeasure_file_id  = (dr["MEASURE_FILE_ID"]  == DBNull.Value) ? "" : Convert.ToString(dr["MEASURE_FILE_ID"]);
                _iremark           = (dr["REMARK"]           == DBNull.Value) ? "" : Convert.ToString(dr["REMARK"]);
                _iapp_ref_id       = (dr["APP_REF_ID"]       == DBNull.Value) ? 0  : Convert.ToDecimal(dr["APP_REF_ID"]);
                _iapp_status       = (dr["APP_STATUS"]       == DBNull.Value) ? "" : Convert.ToString(dr["APP_STATUS"]);
                _create_user       = (dr["CREATE_USER"]      == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date       = (dr["CREATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user       = (dr["UPDATE_USER"]      == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date       = (dr["UPDATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                                  int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                                  string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id, 
                                  string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(21);

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
            paramArray[6]               = CreateDataParameter("@iSEQUENCE", SqlDbType.Int);
            paramArray[6].Value         = isequence;
            paramArray[7]               = CreateDataParameter("@iCAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[7].Value         = ical_result_ms;
            paramArray[8]               = CreateDataParameter("@iCAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[8].Value         = ical_result_ts;
            paramArray[9]               = CreateDataParameter("@iCAL_APPLY_YN", SqlDbType.Char);
            paramArray[9].Value         = ical_apply_yn;
            paramArray[10]              = CreateDataParameter("@iCAL_APPLY_REASON", SqlDbType.VarChar);
            paramArray[10].Value        = ical_apply_reason;
            paramArray[11]              = CreateDataParameter("@iCAUSE_TEXT_MS", SqlDbType.NText);
            paramArray[11].Value        = icause_text_ms;
            paramArray[12]              = CreateDataParameter("@iCAUSE_TEXT_TS", SqlDbType.NText);
            paramArray[12].Value        = icause_text_ts;
            paramArray[13]              = CreateDataParameter("@iCAUSE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[13].Value        = icause_file_id;
            paramArray[14]              = CreateDataParameter("@iMEASURE_TEXT_MS", SqlDbType.Text);
            paramArray[14].Value        = imeasure_text_ms;
            paramArray[15]              = CreateDataParameter("@iMEASURE_TEXT_TS", SqlDbType.Text);
            paramArray[15].Value        = imeasure_text_ts;
            paramArray[16]              = CreateDataParameter("@iMEASURE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[16].Value        = imeasure_file_id;
            paramArray[17]              = CreateDataParameter("@iREMARK", SqlDbType.VarChar);
            paramArray[17].Value        = iremark;
            paramArray[18]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[18].Value        = itxr_user;
            paramArray[19]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[19].Direction    = ParameterDirection.Output;
            paramArray[20]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[20].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                                  int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                                  string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                                  string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
           
            IDbDataParameter[] paramArray = CreateDataParameters(21);

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
            paramArray[6]               = CreateDataParameter("@iSEQUENCE", SqlDbType.Int);
            paramArray[6].Value         = isequence;
            paramArray[7]               = CreateDataParameter("@iCAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[7].Value         = ical_result_ms;
            paramArray[8]               = CreateDataParameter("@iCAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[8].Value         = ical_result_ts;
            paramArray[9]               = CreateDataParameter("@iCAL_APPLY_YN", SqlDbType.Char);
            paramArray[9].Value         = ical_apply_yn;
            paramArray[10]              = CreateDataParameter("@iCAL_APPLY_REASON", SqlDbType.VarChar);
            paramArray[10].Value        = ical_apply_reason;
            paramArray[11]              = CreateDataParameter("@iCAUSE_TEXT_MS", SqlDbType.Text);
            paramArray[11].Value        = icause_text_ms;
            paramArray[12]              = CreateDataParameter("@iCAUSE_TEXT_TS", SqlDbType.Text);
            paramArray[12].Value        = icause_text_ts;
            paramArray[13]              = CreateDataParameter("@iCAUSE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[13].Value        = icause_file_id;
            paramArray[14]              = CreateDataParameter("@iMEASURE_TEXT_MS", SqlDbType.Text);
            paramArray[14].Value        = imeasure_text_ms;
            paramArray[15]              = CreateDataParameter("@iMEASURE_TEXT_TS", SqlDbType.Text);
            paramArray[15].Value        = imeasure_text_ts;
            paramArray[16]              = CreateDataParameter("@iMEASURE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[16].Value        = imeasure_file_id;
            paramArray[17]              = CreateDataParameter("@iREMARK", SqlDbType.VarChar);
            paramArray[17].Value        = iremark;
            paramArray[18]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[18].Value        = itxr_user;
            paramArray[19]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[19].Direction    = ParameterDirection.Output;
            paramArray[20]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[20].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteAllData_Dac(int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "DA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int Result_Confirm_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RF";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_RESULT_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int Result_Cancel_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RC";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_RESULT_CANCEL"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        // Transaction
        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx,
                                  int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                                  int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                                  string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                                  string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(21);

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
            paramArray[6]               = CreateDataParameter("@iSEQUENCE", SqlDbType.Int);
            paramArray[6].Value         = isequence;
            paramArray[7]               = CreateDataParameter("@iCAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[7].Value         = ical_result_ms;
            paramArray[8]               = CreateDataParameter("@iCAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[8].Value         = ical_result_ts;
            paramArray[9]               = CreateDataParameter("@iCAL_APPLY_YN", SqlDbType.Char);
            paramArray[9].Value         = ical_apply_yn;
            paramArray[10]              = CreateDataParameter("@iCAL_APPLY_REASON", SqlDbType.VarChar);
            paramArray[10].Value        = ical_apply_reason;
            paramArray[11]              = CreateDataParameter("@iCAUSE_TEXT_MS", SqlDbType.Text);
            paramArray[11].Value        = icause_text_ms;
            paramArray[12]              = CreateDataParameter("@iCAUSE_TEXT_TS", SqlDbType.Text);
            paramArray[12].Value        = icause_text_ts;
            paramArray[13]              = CreateDataParameter("@iCAUSE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[13].Value        = icause_file_id;
            paramArray[14]              = CreateDataParameter("@iMEASURE_TEXT_MS", SqlDbType.Text);
            paramArray[14].Value        = imeasure_text_ms;
            paramArray[15]              = CreateDataParameter("@iMEASURE_TEXT_TS", SqlDbType.Text);
            paramArray[15].Value        = imeasure_text_ts;
            paramArray[16]              = CreateDataParameter("@iMEASURE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[16].Value        = imeasure_file_id;
            paramArray[17]              = CreateDataParameter("@iREMARK", SqlDbType.VarChar);
            paramArray[17].Value        = iremark;
            paramArray[18]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[18].Value        = itxr_user;
            paramArray[19]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[19].Direction    = ParameterDirection.Output;
            paramArray[20]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[20].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx,
                                  int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                                  int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                                  string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                                  string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(21);

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
            paramArray[6]               = CreateDataParameter("@iSEQUENCE", SqlDbType.Int);
            paramArray[6].Value         = isequence;
            paramArray[7]               = CreateDataParameter("@iCAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[7].Value         = ical_result_ms;
            paramArray[8]               = CreateDataParameter("@iCAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[8].Value         = ical_result_ts;
            paramArray[9]               = CreateDataParameter("@iCAL_APPLY_YN", SqlDbType.Char);
            paramArray[9].Value         = ical_apply_yn;
            paramArray[10]              = CreateDataParameter("@iCAL_APPLY_REASON", SqlDbType.VarChar);
            paramArray[10].Value        = ical_apply_reason;
            paramArray[11]              = CreateDataParameter("@iCAUSE_TEXT_MS", SqlDbType.Text);
            paramArray[11].Value        = icause_text_ms;
            paramArray[12]              = CreateDataParameter("@iCAUSE_TEXT_TS", SqlDbType.Text);
            paramArray[12].Value        = icause_text_ts;
            paramArray[13]              = CreateDataParameter("@iCAUSE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[13].Value        = icause_file_id;
            paramArray[14]              = CreateDataParameter("@iMEASURE_TEXT_MS", SqlDbType.Text);
            paramArray[14].Value        = imeasure_text_ms;
            paramArray[15]              = CreateDataParameter("@iMEASURE_TEXT_TS", SqlDbType.Text);
            paramArray[15].Value        = imeasure_text_ts;
            paramArray[16]              = CreateDataParameter("@iMEASURE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[16].Value        = imeasure_file_id;
            paramArray[17]              = CreateDataParameter("@iREMARK", SqlDbType.VarChar);
            paramArray[17].Value        = iremark;
            paramArray[18]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[18].Value        = itxr_user;
            paramArray[19]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[19].Direction    = ParameterDirection.Output;
            paramArray[20]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[20].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx,GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
          
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
           
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteAllData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
           
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "DA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);
          
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int Result_Confirm_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RF";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_RESULT_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);          
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int Result_Cancel_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RC";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_RESULT_CANCEL"), paramArray, CommandType.StoredProcedure, out col);    
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_SELECT_ALL"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT","PKG_BSC_KPI_RESULT.PROC_SELECT_ONE"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetResultListPerMonth(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SR";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_SELECT_MONTHLY_RESULT"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetResultAnalysisList(int iestterm_ref_id, int ikpi_ref_id, string iymd, string goaltongYN)
        {
            string strQuery = @"
SELECT A.KPI_REF_ID
                ,A.YMD
                ,A.YMD_DESC
                ,A.MM
                ,A.TARGET_MS
                ,A.RESULT_MS
                ,A.TARGET_TS
                ,A.RESULT_TS
                ,A.CAUSE_TEXT_MS
                ,A.CAUSE_TEXT_TS
                ,A.CAUSE_FILE_ID
                ,A.MEASURE_TEXT_MS
                ,A.MEASURE_TEXT_TS
                ,A.MEASURE_FILE_ID
                ,A.AC_RATE_MS
                ,A.AC_RATE_TS
                ,A.SIGNAL_MS
                ,A.SIGNAL_TS
                ,A.TREND_MS
                ,A.TREND_TS
                ,A.POINTS_MS
                ,A.POINTS_TS
                ,A.REMARK
                ,TC1.THRESHOLD_KNAME AS THRESHOLD_KNAME_MS
                ,TC1.IMAGE_FILE_NAME AS IMAGE_FILE_NAME_MS
                ,TC2.THRESHOLD_KNAME AS THRESHOLD_KNAME_TS
                ,TC2.IMAGE_FILE_NAME AS IMAGE_FILE_NAME_TS
                ,A.TREND_MS AS TREND_MS_NAME
                ,A.TREND_TS AS TREND_TS_NAME
            FROM
            (
                  SELECT ED.ESTTERM_REF_ID
                        ,ISNULL(MS.KPI_REF_ID, @iKPI_REF_ID)                                             as KPI_REF_ID
                        ,ISNULL(MS.YMD, @iYMD)                                                           as YMD
                        ,(ED.YY + '/' + ED.MM)                                                           as YMD_DESC
                        ,ED.MM                                                                           as MM
                        ,ISNULL(MT.TARGET_MS,0)                                                          as TARGET_MS
                        ,ISNULL(MS.RESULT_MS,0)                                                          as RESULT_MS
                        ,dbo.fn_BSC_KPI_TARGET_TS(ED.ESTTERM_REF_ID, @iKPI_REF_ID, ED.YMD)               as TARGET_TS
                        ,CASE WHEN @iYMD < ED.YMD THEN 0 ELSE dbo.fn_BSC_KPI_RESULT_TS(ED.ESTTERM_REF_ID, @iKPI_REF_ID, ED.YMD) END               as RESULT_TS --20120416 박효동: 허성덕과장요청으로 조회월 이후누적실적은 0으로
                        ,ISNULL(MS.CAUSE_TEXT_MS,'')                                                     as CAUSE_TEXT_MS
                        ,ISNULL(MS.CAUSE_TEXT_TS,'')                                                     as CAUSE_TEXT_TS
                        ,ISNULL(MS.CAUSE_FILE_ID,'')                                                     as CAUSE_FILE_ID
                        ,ISNULL(MS.MEASURE_TEXT_MS,'')                                                   as MEASURE_TEXT_MS
                        ,ISNULL(MS.MEASURE_TEXT_TS,'')                                                   as MEASURE_TEXT_TS
                        ,ISNULL(MS.MEASURE_FILE_ID,'')                                                   as MEASURE_FILE_ID
                        ,dbo.fn_BSC_KPI_ACHEVE_RATE (ED.ESTTERM_REF_ID, @iKPI_REF_ID, MS.YMD, 'MS')      as AC_RATE_MS
                        ,dbo.fn_BSC_KPI_ACHEVE_RATE (ED.ESTTERM_REF_ID, @iKPI_REF_ID, MS.YMD, 'TS')      as AC_RATE_TS
                        ,dbo.fn_BSC_KPI_INDICATOR_ID(ED.ESTTERM_REF_ID, @iKPI_REF_ID, MS.YMD, 'MS')      as SIGNAL_MS
                        ,dbo.fn_BSC_KPI_INDICATOR_ID(ED.ESTTERM_REF_ID, @iKPI_REF_ID, MS.YMD, 'TS')      as SIGNAL_TS
                        ,dbo.fn_BSC_KPI_TREND(ED.ESTTERM_REF_ID, @iKPI_REF_ID, MS.YMD, 'MS')             as TREND_MS
                        ,dbo.fn_BSC_KPI_TREND(ED.ESTTERM_REF_ID, @iKPI_REF_ID, MS.YMD, 'TS')             as TREND_TS
                        ,ISNULL(KS.POINTS_MS, '-') as POINTS_MS
                        ,ISNULL(KS.POINTS_TS, '-') as POINTS_TS
                        ,MS.REMARK
                    FROM BSC_TERM_DETAIL ED
                         LEFT JOIN BSC_KPI_RESULT MS
                           ON ED.ESTTERM_REF_ID = MS.ESTTERM_REF_ID
                          AND ED.YMD            = MS.YMD
                          AND MS.KPI_REF_ID     = @iKPI_REF_ID
                          AND MS.YMD           <= @iYMD
--                          AND ED.CLOSE_YN       = 'Y' --2012.04.12 허성덕과장 요청으로 마감여부 풀어버림 : 박효동
                         LEFT JOIN BSC_KPI_TARGET MT
                           ON ED.ESTTERM_REF_ID = MT.ESTTERM_REF_ID
                          AND ED.YMD            = MT.YMD
                          AND MT.KPI_REF_ID     = @iKPI_REF_ID
                         LEFT JOIN BSC_KPI_TARGET_VERSION KV
                           ON MT.ESTTERM_REF_ID        = KV.ESTTERM_REF_ID
                          AND MT.KPI_TARGET_VERSION_ID = KV.KPI_TARGET_VERSION_ID
                          AND KV.KPI_REF_ID            = @iKPI_REF_ID
                         LEFT JOIN BSC_KPI_SCORE KS
                           ON MS.ESTTERM_REF_ID        = KS.ESTTERM_REF_ID
                          AND MS.YMD                   = KS.YMD
                          AND KS.KPI_REF_ID            = @iKPI_REF_ID
                    WHERE ED.ESTTERM_REF_ID = @iESTTERM_REF_ID
                      AND KV.USE_YN = 'Y') A
                     LEFT JOIN BSC_THRESHOLD_CODE TC1
                       ON TC1.THRESHOLD_REF_ID = A.SIGNAL_MS
                     LEFT JOIN BSC_THRESHOLD_CODE TC2
                       ON TC2.THRESHOLD_REF_ID = A.SIGNAL_TS
                    ORDER BY  A.MM
";


            if (goaltongYN.Equals("Y"))
                strQuery = strQuery.Replace("fn_BSC_KPI_ACHEVE_RATE", "fn_BSC_KPI_ACHEVE_RATE_GOAL").Replace("fn_BSC_KPI_TARGET_TS", "fn_BSC_KPI_TARGET_GOAL_TS").Replace("LEFT JOIN BSC_KPI_TARGET MT", "LEFT JOIN BSC_KPI_TARGET_GOAL MT");


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            //paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            //paramArray[0].Value         = "SD";
            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_SELECT_MONTHLY_ANALY"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_RESULT", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetResultPaReportList(int iestterm_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SP";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_SELECT_MONTHLY_REPORT"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetResultTotalData(object estterm_ref_id
                                        , object kpi_ref_id)
        {
            string query = @"
SELECT    B.ESTTERM_REF_ID
        , B.KPI_REF_ID
        , A.YMD
        , C.RESULT_MS, C.RESULT_TS
        , C.CAUSE_TEXT_MS, C.CAUSE_TEXT_TS, C.MEASURE_TEXT_MS, C.MEASURE_TEXT_TS
        , CASE WHEN A.YMD <= D.YMD THEN 'Y' ELSE 'N' END AS OPEN_YN
        , ISNULL(B.CHECK_YN, 'N')   AS CHECK_YN
FROM    BSC_TERM_DETAIL A   
INNER JOIN BSC_KPI_TERM         B   ON  A.ESTTERM_REF_ID            = B.ESTTERM_REF_ID
						            AND	A.YMD                       = B.YMD
LEFT OUTER JOIN BSC_KPI_RESULT  C   ON  B.ESTTERM_REF_ID            = C.ESTTERM_REF_ID
								    AND	B.KPI_REF_ID                = C.KPI_REF_ID
								    AND B.YMD                       = C.YMD
LEFT OUTER JOIN BSC_TERM_DETAIL D   ON  A.ESTTERM_REF_ID            = D.ESTTERM_REF_ID
								    AND	ISNULL(D.RELEASE_YN, 'N')   = 'Y'
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
	AND B.KPI_REF_ID        = @KPI_REF_ID
ORDER BY A.YMD
";

            query = GetQueryStringReplace(query);
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 하위지표 실적 조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public DataSet GetChildKpiResultList(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CK";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.SELT_CHILD_KPI_RTN"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 목표/실적 현황 조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public DataSet GetChildKpiStatustList(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CT";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.SELT_CHILD_KPI_RTN"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 하위지표 결재상태
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public bool GetKpiChildAppStatus(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            //string AppYn = Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_SELECT_KPI_CHILD_APP_YN"), paramArray, CommandType.StoredProcedure));

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_SELECT_KPI_CHILD_APP_YN"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            if (ds.Tables.Count < 1)
            {
                return false;
            }

            if (ds.Tables[0].Rows[0][0].ToString() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetIsNewDraftPerUser(int iestterm_ref_id, string iymd, int iemp_ref_id)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "DC";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_RESULT", "PKG_BSC_KPI_RESULT.PROC_NEW_DRAFT_COUNT"), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            
            int intRtn = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            if (intRtn > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet SelectKpiList(int iestterm_ref_id, int iest_dept_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SD";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value = iymd;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("USP_BSC_KPI_RESULT_V2", ""), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
     
        
        public int UpdateKpiResult(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user, double iresult_ms, double iresult_ts)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "UO";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value = iymd;
            paramArray[4] = CreateDataParameter("@iRESULT_MS", SqlDbType.Float);
            paramArray[4].Value = iresult_ms;
            paramArray[5] = CreateDataParameter("@iRESULT_TS", SqlDbType.Float);
            paramArray[5].Value = iresult_ts;
            paramArray[6] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value = itxr_user;
            paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[7].Direction = ParameterDirection.Output;
            paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[8].Direction = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("USP_BSC_KPI_RESULT_V2", ""), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet SelectKpiTargetList(int iestterm_ref_id, int iest_dept_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ST";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value = iymd;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("USP_BSC_KPI_RESULT_V2", ""), "BSC_KPI_RESULT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        
        public int UpdateKpiTarget(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user, int itarget_version, double icalc_ms, double icalc_ts)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "UT";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value = iymd;

            paramArray[4] = CreateDataParameter("@iTARGET_VERSION", SqlDbType.Int);
            paramArray[4].Value = itarget_version;

            paramArray[5] = CreateDataParameter("@iCALC_MS", SqlDbType.Float);
            paramArray[5].Value = icalc_ms;
            paramArray[6] = CreateDataParameter("@iCALC_TS", SqlDbType.Float);
            paramArray[6].Value = icalc_ts;
            paramArray[7] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value = itxr_user;
            paramArray[8] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[8].Direction = ParameterDirection.Output;
            paramArray[9] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[9].Direction = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("USP_BSC_KPI_RESULT_V2", ""), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /* 2011-03-15 종료 ****************************************************************************************/
        #endregion

    }
}
