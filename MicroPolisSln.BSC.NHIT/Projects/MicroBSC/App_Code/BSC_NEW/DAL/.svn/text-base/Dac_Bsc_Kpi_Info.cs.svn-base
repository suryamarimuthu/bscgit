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
/// Dac_Bsc_Kpi_Info의 요약 설명입니다.
/// </summary>
namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Info에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Kpi_Info Dac 클래스
    /// Class 내용		@ Kpi_Pool Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2007.04.25
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;
        private int 	 _ikpi_ref_id;
        private string 	 _ikpi_code;
        private int 	 _ikpi_pool_ref_id;
        private string   _ikpi_name;
        private string 	 _iword_definition;
        private string 	 _imeasurement_purpose;
        private string 	 _icalc_form_ms;
        private string 	 _icalc_form_ts;
        private string 	 _irelated_issue;
        private string 	 _iadd_file;
        private int 	 _ichampion_emp_id;
        private string   _ichampion_emp_name;
        private int 	 _imeasurement_emp_id;
        private string   _imeasurement_emp_name;
        private int 	 _iapproval_emp_id;
        private string   _iapproval_emp_name;
        private string 	 _idata_gethering_method;
        private string 	 _iresult_term_type;
        private string   _iresult_term_type_name;
        private string 	 _iresult_input_type;
        private string 	 _iresult_input_type_name;
        private string 	 _iresult_achievement_type;
        private string   _iresult_achievement_type_name;
        private string 	 _iresult_ts_calc_type;
        private string   _iresult_ts_calc_type_name;
        private string 	 _iresult_measurement_step;
        private string   _iresult_measurement_step_name;
        private string 	 _imeasurement_grade_type;
        private string   _imeasurement_grade_type_name;
        private int 	 _iunit_type_ref_id;
        private string   _iunit_name;
        private string 	 _ikpi_target_version_id;
        private string 	 _ikpi_target_setting_reason;
        private string 	 _ikpi_target_reason_file;
        private string 	 _iapproval_status;
        private string 	 _igraph_type;
        private decimal  _iapp_ref_id;
        private string   _iis_team_kpi;
        private string 	 _iexcel_dnuse;
        private string 	 _iuse_yn;
        private int 	 _itxr_user;
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

        public string Ikpi_code
        {
            get
            {
                return _ikpi_code;
            }
            set
            {
                _ikpi_code = (value == null ? "" : value);
            }
        }

        public int Ikpi_pool_ref_id
        {
            get
            {
                return _ikpi_pool_ref_id;
            }
            set
            {
                _ikpi_pool_ref_id = value;
            }
        }

        public string Ikpi_name
        {
            get
            {
                return _ikpi_name;
            }
            set
            {
                _ikpi_name = (value == null ? "" : value);
            }
        }

        public string Iword_definition
        {
            get
            {
                return _iword_definition;
            }
            set
            {
                _iword_definition = (value == null ? "" : value);
            }
        }

        public string Imeasurement_purpose
        {
            get
            {
                return _imeasurement_purpose;
            }
            set
            {
                _imeasurement_purpose = (value == null ? "" : value);
            }
        }

        public string Icalc_form_ms
        {
            get
            {
                return _icalc_form_ms;
            }
            set
            {
                _icalc_form_ms = (value == null ? "" : value);
            }
        }

        public string Icalc_form_ts
        {
            get
            {
                return _icalc_form_ts;
            }
            set
            {
                _icalc_form_ts = (value == null ? "" : value);
            }
        }

        public string Irelated_issue
        {
            get
            {
                return _irelated_issue;
            }
            set
            {
                _irelated_issue = (value == null ? "" : value);
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
                _iadd_file = (value == null ? "" : value);
            }
        }

        public int Ichampion_emp_id
        {
            get
            {
                return _ichampion_emp_id;
            }
            set
            {
                _ichampion_emp_id = value;
            }
        }

        public string Ichampion_emp_name
        {
            get
            {
                return _ichampion_emp_name;
            }
            set
            {
                _ichampion_emp_name = (value == null ? "" : value);
            }
        }

        public int Imeasurement_emp_id
        {
            get
            {
                return _imeasurement_emp_id;
            }
            set
            {
                _imeasurement_emp_id = value;
            }
        }

        public string Imeasurement_emp_name
        {
            get
            {
                return _imeasurement_emp_name;
            }
            set
            {
                _imeasurement_emp_name = (value == null ? "" : value);
            }
        }

        public int Iapproval_emp_id
        {
            get
            {
                return _iapproval_emp_id;
            }
            set
            {
                _iapproval_emp_id = value;
            }
        }

        public string Iapproval_emp_name
        {
            get
            {
                return _iapproval_emp_name;
            }
            set
            {
                _iapproval_emp_name = (value == null ? "" : value);
            }
        }

        public string Idata_gethering_method
        {
            get
            {
                return _idata_gethering_method;
            }
            set
            {
                _idata_gethering_method = (value == null ? "" : value);
            }
        }

        public string Iresult_term_type
        {
            get
            {
                return _iresult_term_type;
            }
            set
            {
                _iresult_term_type = (value == null ? "" : value);
            }
        }

        public string Iresult_term_type_name
        {
            get
            {
                return _iresult_term_type_name;
            }
            set
            {
                _iresult_term_type_name = (value == null ? "" : value);
            }
        }

        public string Iresult_input_type
        {
            get
            {
                return _iresult_input_type;
            }
            set
            {
                _iresult_input_type = (value == null ? "" : value);
            }
        }

        public string Iresult_input_type_name
        {
            get
            {
                return _iresult_input_type_name;
            }
            set
            {
                _iresult_input_type_name = (value == null ? "" : value);
            }
        }

        public string Iresult_achievement_type
        {
            get
            {
                return _iresult_achievement_type;
            }
            set
            {
                _iresult_achievement_type = (value == null ? "" : value);
            }
        }

        public string Iresult_achievement_type_name
        {
            get
            {
                return _iresult_achievement_type_name;
            }
            set
            {
                _iresult_achievement_type_name = (value == null ? "" : value);
            }
        }

        public string Iresult_ts_calc_type
        {
            get
            {
                return _iresult_ts_calc_type;
            }
            set
            {
                _iresult_ts_calc_type = (value == null ? "" : value);
            }
        }

        public string Iresult_ts_calc_type_name
        {
            get
            {
                return _iresult_ts_calc_type_name;
            }
            set
            {
                _iresult_ts_calc_type_name = (value == null ? "" : value);
            }
        }

        public string Iresult_measurement_step
        {
            get
            {
                return _iresult_measurement_step;
            }
            set
            {
                _iresult_measurement_step = (value == null ? "" : value);
            }
        }

        public string Iresult_measurement_step_name
        {
            get
            {
                return _iresult_measurement_step_name;
            }
            set
            {
                _iresult_measurement_step_name = (value == null ? "" : value);
            }
        }

        public string Imeasurement_grade_type
        {
            get
            {
                return _imeasurement_grade_type;
            }
            set
            {
                _imeasurement_grade_type = (value == null ? "" : value);
            }
        }

        public string Imeasurement_grade_type_name
        {
            get
            {
                return _imeasurement_grade_type_name;
            }
            set
            {
                _imeasurement_grade_type_name = (value == null ? "" : value);
            }
        }

        public int Iunit_type_ref_id
        {
            get
            {
                return _iunit_type_ref_id;
            }
            set
            {
                _iunit_type_ref_id = value;
            }
        }

        public string Iunit_name
        {
            get
            {
                return _iunit_name;
            }
            set
            {
                _iunit_name = (value == null ? "" : value);
            }
        }

        public string Ikpi_target_version_id
        {
            get
            {
                return _ikpi_target_version_id;
            }
            set
            {
                _ikpi_target_version_id = (value == null ? "" : value);
            }
        }

        public string Ikpi_target_setting_reason
        {
            get
            {
                return _ikpi_target_setting_reason;
            }
            set
            {
                _ikpi_target_setting_reason = (value == null ? "" : value);
            }
        }

        public string Ikpi_target_reason_file
        {
            get
            {
                return _ikpi_target_reason_file;
            }
            set
            {
                _ikpi_target_reason_file = (value == null ? "" : value);
            }
        }

        public string Iapproval_status
        {
            get
            {
                return _iapproval_status;
            }
            set
            {
                _iapproval_status = (value == null ? "" : value);
            }
        }

        public string Igraph_type
        {
            get
            {
                return _igraph_type;
            }
            set
            {
                _igraph_type = (value == null ? "" : value);
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

        public string Iexcel_dnuse
        {
            get
            {
                return _iexcel_dnuse;
            }
            set
            {
                _iexcel_dnuse = (value == null ? "" : value);
            }
        }

        public string Iis_team_kpi
        {
            get
            {
                return _iis_team_kpi;
            }
            set
            {
                _iis_team_kpi = (value == null ? "" : value);
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
                _iuse_yn = (value == null ? "" : value);
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
        public Dac_Bsc_Kpi_Info() { }
        public Dac_Bsc_Kpi_Info(int iestterm_ref_id, int Ikpi_ref_id)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, Ikpi_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id               = (dr["ESTTERM_REF_ID"] == DBNull.Value)               ? 0 :  Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id                   = (dr["KPI_REF_ID"] == DBNull.Value)                   ? 0 :  Convert.ToInt32(dr["KPI_REF_ID"]);
                _ikpi_code                     = (dr["KPI_CODE"] == DBNull.Value)                     ? "" : Convert.ToString(dr["KPI_CODE"]);
                _ikpi_pool_ref_id              = (dr["KPI_POOL_REF_ID"] == DBNull.Value)              ? 0 :  Convert.ToInt32(dr["KPI_POOL_REF_ID"]);
                _ikpi_name                     = (dr["KPI_NAME"] == DBNull.Value)                     ? "" : Convert.ToString(dr["KPI_NAME"]);
                _iword_definition              = (dr["WORD_DEFINITION"] == DBNull.Value)              ? "" : Convert.ToString(dr["WORD_DEFINITION"]);
                _imeasurement_purpose          = (dr["MEASUREMENT_PURPOSE"] == DBNull.Value)          ? "" : Convert.ToString(dr["MEASUREMENT_PURPOSE"]);
                _icalc_form_ms                 = (dr["CALC_FORM_MS"] == DBNull.Value)                 ? "" : Convert.ToString(dr["CALC_FORM_MS"]);
                _icalc_form_ts                 = (dr["CALC_FORM_TS"] == DBNull.Value)                 ? "" : Convert.ToString(dr["CALC_FORM_TS"]);
                _irelated_issue                = (dr["RELATED_ISSUE"] == DBNull.Value)                ? "" : Convert.ToString(dr["RELATED_ISSUE"]);
                _iadd_file                     = (dr["ADD_FILE"] == DBNull.Value)                     ? "" : Convert.ToString(dr["ADD_FILE"]);
                _ichampion_emp_id              = (dr["CHAMPION_EMP_ID"] == DBNull.Value)              ? 0 :  Convert.ToInt32(dr["CHAMPION_EMP_ID"]);
                _ichampion_emp_name            = (dr["CHAMPION_EMP_NAME"] == DBNull.Value)            ? "" : Convert.ToString(dr["CHAMPION_EMP_NAME"]);
                _imeasurement_emp_id           = (dr["MEASUREMENT_EMP_ID"] == DBNull.Value)           ? 0 :  Convert.ToInt32(dr["MEASUREMENT_EMP_ID"]);
                _imeasurement_emp_name         = (dr["MEASUREMENT_EMP_NAME"] == DBNull.Value)         ? "" : Convert.ToString(dr["MEASUREMENT_EMP_NAME"]);
                _iapproval_emp_id              = (dr["APPROVAL_EMP_ID"] == DBNull.Value)              ? 0 :  Convert.ToInt32(dr["APPROVAL_EMP_ID"]);
                _iapproval_emp_name            = (dr["APPROVAL_EMP_NAME"] == DBNull.Value)            ? "" : Convert.ToString(dr["APPROVAL_EMP_NAME"]);
                _idata_gethering_method        = (dr["DATA_GETHERING_METHOD"] == DBNull.Value)        ? "" : Convert.ToString(dr["DATA_GETHERING_METHOD"]);
                _iresult_term_type             = (dr["RESULT_TERM_TYPE"] == DBNull.Value)             ? "" : Convert.ToString(dr["RESULT_TERM_TYPE"]);
                _iresult_term_type_name        = (dr["RESULT_TERM_TYPE_NAME"] == DBNull.Value)        ? "" : Convert.ToString(dr["RESULT_TERM_TYPE_NAME"]);                
                _iresult_input_type            = (dr["RESULT_INPUT_TYPE"] == DBNull.Value)            ? "" : Convert.ToString(dr["RESULT_INPUT_TYPE"]);
                _iresult_input_type_name       = (dr["RESULT_INPUT_TYPE_NAME"] == DBNull.Value)       ? "" : Convert.ToString(dr["RESULT_INPUT_TYPE_NAME"]);
                _iresult_achievement_type      = (dr["RESULT_ACHIEVEMENT_TYPE"] == DBNull.Value)      ? "" : Convert.ToString(dr["RESULT_ACHIEVEMENT_TYPE"]);
                _iresult_achievement_type_name = (dr["RESULT_ACHIEVEMENT_TYPE_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_ACHIEVEMENT_TYPE_NAME"]);                
                _iresult_ts_calc_type          = (dr["RESULT_TS_CALC_TYPE"] == DBNull.Value)          ? "" : Convert.ToString(dr["RESULT_TS_CALC_TYPE"]);
                _iresult_ts_calc_type_name     = (dr["RESULT_TS_CALC_TYPE_NAME"] == DBNull.Value)     ? "" : Convert.ToString(dr["RESULT_TS_CALC_TYPE_NAME"]);
                _iresult_measurement_step      = (dr["RESULT_MEASUREMENT_STEP"] == DBNull.Value)      ? "" : Convert.ToString(dr["RESULT_MEASUREMENT_STEP"]);
                _iresult_measurement_step_name = (dr["RESULT_MEASUREMENT_STEP_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_MEASUREMENT_STEP_NAME"]);                
                _imeasurement_grade_type       = (dr["MEASUREMENT_GRADE_TYPE"] == DBNull.Value)       ? "" : Convert.ToString(dr["MEASUREMENT_GRADE_TYPE"]);
                _imeasurement_grade_type_name  = (dr["MEASUREMENT_GRADE_TYPE_NAME"] == DBNull.Value)  ? "" : Convert.ToString(dr["MEASUREMENT_GRADE_TYPE_NAME"]);
                _iunit_type_ref_id             = (dr["UNIT_TYPE_REF_ID"] == DBNull.Value)             ? 0 :  Convert.ToInt32(dr["UNIT_TYPE_REF_ID"]);
                _iunit_name                    = (dr["UNIT_NAME"] == DBNull.Value)                    ? "" : Convert.ToString(dr["UNIT_NAME"]);
                _ikpi_target_version_id        = (dr["KPI_TARGET_VERSION_ID"] == DBNull.Value)        ? "" : Convert.ToString(dr["KPI_TARGET_VERSION_ID"]);
		        _ikpi_target_setting_reason    = (dr["KPI_TARGET_SETTING_REASON"]  == DBNull.Value)   ? "" : Convert.ToString(dr["KPI_TARGET_SETTING_REASON"]);
		        _ikpi_target_reason_file       = (dr["KPI_TARGET_REASON_FILE"]  == DBNull.Value)      ? "" : Convert.ToString(dr["KPI_TARGET_REASON_FILE"]);
                _iapproval_status              = (dr["APPROVAL_STATUS"] == DBNull.Value)              ? "" : Convert.ToString(dr["APPROVAL_STATUS"]);
                _igraph_type                   = (dr["GRAPH_TYPE"] == DBNull.Value)                   ? "" : Convert.ToString(dr["GRAPH_TYPE"]);
                _iapp_ref_id                   = (dr["APP_REF_ID"] == DBNull.Value)                   ? 0 :  Convert.ToDecimal(dr["APP_REF_ID"]);
                _iexcel_dnuse                  = (dr["EXCEL_DNUSE"] == DBNull.Value)                  ? "" : Convert.ToString(dr["EXCEL_DNUSE"]);
                _iis_team_kpi                  = (dr["IS_TEAM_KPI"] == DBNull.Value)                  ? "Y" : Convert.ToString(dr["IS_TEAM_KPI"]);
                _iuse_yn                       = (dr["USE_YN"] == DBNull.Value)                       ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user                   = (dr["CREATE_USER"] == DBNull.Value)                  ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date                   = (dr["CREATE_DATE"] == DBNull.Value)                  ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user                   = (dr["UPDATE_USER"] == DBNull.Value)                  ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date                   = (dr["UPDATE_DATE"] == DBNull.Value)                  ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iestterm_ref_id,         string ikpi_code,                int ikpi_pool_ref_id,              string iword_definition, 
                 string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
                 int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
                 string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
                 int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,    
                 string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(34);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value         = ikpi_code;
            paramArray[3]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_pool_ref_id;
            paramArray[4]               = CreateDataParameter("@iWORD_DEFINITION", SqlDbType.VarChar);
            paramArray[4].Value         = iword_definition;
            paramArray[5]               = CreateDataParameter("@iMEASUREMENT_PURPOSE", SqlDbType.VarChar);
            paramArray[5].Value         = imeasurement_purpose;
            paramArray[6]               = CreateDataParameter("@iCALC_FORM_MS", SqlDbType.VarChar);
            paramArray[6].Value         = icalc_form_ms;
            paramArray[7]               = CreateDataParameter("@iCALC_FORM_TS", SqlDbType.VarChar);
            paramArray[7].Value         = icalc_form_ts;
            paramArray[8]               = CreateDataParameter("@iRELATED_ISSUE", SqlDbType.VarChar);
            paramArray[8].Value         = irelated_issue;
            paramArray[9]               = CreateDataParameter("@iADD_FILE", SqlDbType.VarChar);
            paramArray[9].Value         = iadd_file;
            paramArray[10]              = CreateDataParameter("@iCHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[10].Value        = ichampion_emp_id;
            paramArray[11]              = CreateDataParameter("@iMEASUREMENT_EMP_ID", SqlDbType.Int);
            paramArray[11].Value        = imeasurement_emp_id;
            paramArray[12]              = CreateDataParameter("@iAPPROVAL_EMP_ID", SqlDbType.Int);
            paramArray[12].Value        = iapproval_emp_id;
            paramArray[13]              = CreateDataParameter("@iDATA_GETHERING_METHOD", SqlDbType.VarChar);
            paramArray[13].Value        = idata_gethering_method;
            paramArray[14]              = CreateDataParameter("@iRESULT_TERM_TYPE", SqlDbType.VarChar);
            paramArray[14].Value        = iresult_term_type;
            paramArray[15]              = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[15].Value        = iresult_input_type;
            paramArray[16]              = CreateDataParameter("@iRESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[16].Value        = iresult_achievement_type;
            paramArray[17]              = CreateDataParameter("@iRESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[17].Value        = iresult_ts_calc_type;
            paramArray[18]              = CreateDataParameter("@iRESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[18].Value        = iresult_measurement_step;
            paramArray[19]              = CreateDataParameter("@iMEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[19].Value        = imeasurement_grade_type;
            paramArray[20]              = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[20].Value        = iunit_type_ref_id;
            paramArray[21]              = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.VarChar);
            paramArray[21].Value        = ikpi_target_version_id;
            paramArray[22]              = CreateDataParameter("@iKPI_TARGET_SETTING_REASON", SqlDbType.Text);
            paramArray[22].Value        = ikpi_target_setting_reason;
            paramArray[23]              = CreateDataParameter("@iKPI_TARGET_REASON_FILE", SqlDbType.VarChar);
            paramArray[23].Value        = ikpi_target_reason_file;
            paramArray[24]              = CreateDataParameter("@iAPPROVAL_STATUS", SqlDbType.Char);
            paramArray[24].Value        = iapproval_status;
            paramArray[25]              = CreateDataParameter("@iGRAPH_TYPE", SqlDbType.VarChar);
            paramArray[25].Value        = igraph_type;
            paramArray[26]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[26].Value        = iapp_ref_id;
            paramArray[27]              = CreateDataParameter("@iEXCEL_DNUSE", SqlDbType.Char);
            paramArray[27].Value        = iexcel_dnuse;
            paramArray[28]              = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[28].Value        = iis_team_kpi;
            paramArray[29]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[29].Value        = iuse_yn;
            paramArray[30]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[30].Value        = itxr_user;
            paramArray[31]              = CreateDataParameter("@oRTN_KPI_REF_ID", SqlDbType.Int);
            paramArray[31].Direction    = ParameterDirection.Output;
            paramArray[32]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[32].Direction    = ParameterDirection.Output;
            paramArray[33]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[33].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Ikpi_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_KPI_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iestterm_ref_id,         int ikpi_ref_id,                 string ikpi_code,                  int ikpi_pool_ref_id,            string iword_definition, 
                 string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
                 int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
                 string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
                 int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,     
                 string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(34);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = ikpi_pool_ref_id;
            paramArray[5]               = CreateDataParameter("@iWORD_DEFINITION", SqlDbType.VarChar);
            paramArray[5].Value         = iword_definition;
            paramArray[6]               = CreateDataParameter("@iMEASUREMENT_PURPOSE", SqlDbType.VarChar);
            paramArray[6].Value         = imeasurement_purpose;
            paramArray[7]               = CreateDataParameter("@iCALC_FORM_MS", SqlDbType.VarChar);
            paramArray[7].Value         = icalc_form_ms;
            paramArray[8]               = CreateDataParameter("@iCALC_FORM_TS", SqlDbType.VarChar);
            paramArray[8].Value         = icalc_form_ts;
            paramArray[9]               = CreateDataParameter("@iRELATED_ISSUE", SqlDbType.VarChar);
            paramArray[9].Value         = irelated_issue;
            paramArray[10]              = CreateDataParameter("@iADD_FILE", SqlDbType.VarChar);
            paramArray[10].Value        = iadd_file;
            paramArray[11]              = CreateDataParameter("@iCHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[11].Value        = ichampion_emp_id;
            paramArray[12]              = CreateDataParameter("@iMEASUREMENT_EMP_ID", SqlDbType.Int);
            paramArray[12].Value        = imeasurement_emp_id;
            paramArray[13]              = CreateDataParameter("@iAPPROVAL_EMP_ID", SqlDbType.Int);
            paramArray[13].Value        = iapproval_emp_id;
            paramArray[14]              = CreateDataParameter("@iDATA_GETHERING_METHOD", SqlDbType.VarChar);
            paramArray[14].Value        = idata_gethering_method;
            paramArray[15]              = CreateDataParameter("@iRESULT_TERM_TYPE", SqlDbType.VarChar);
            paramArray[15].Value        = iresult_term_type;
            paramArray[16]              = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[16].Value        = iresult_input_type;
            paramArray[17]              = CreateDataParameter("@iRESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[17].Value        = iresult_achievement_type;
            paramArray[18]              = CreateDataParameter("@iRESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[18].Value        = iresult_ts_calc_type;
            paramArray[19]              = CreateDataParameter("@iRESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[19].Value        = iresult_measurement_step;
            paramArray[20]              = CreateDataParameter("@iMEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[20].Value        = imeasurement_grade_type;
            paramArray[21]              = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[21].Value        = iunit_type_ref_id;
            paramArray[22]              = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.VarChar);
            paramArray[22].Value        = ikpi_target_version_id;
            paramArray[23]              = CreateDataParameter("@iKPI_TARGET_SETTING_REASON", SqlDbType.Text);
            paramArray[23].Value        = ikpi_target_setting_reason;
            paramArray[24]              = CreateDataParameter("@iKPI_TARGET_REASON_FILE", SqlDbType.VarChar);
            paramArray[24].Value        = ikpi_target_reason_file;
            paramArray[25]              = CreateDataParameter("@iAPPROVAL_STATUS", SqlDbType.Char);
            paramArray[25].Value        = iapproval_status;
            paramArray[26]              = CreateDataParameter("@iGRAPH_TYPE", SqlDbType.VarChar);
            paramArray[26].Value        = igraph_type;
            paramArray[27]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Int);
            paramArray[27].Value        = iapp_ref_id;
            paramArray[28]              = CreateDataParameter("@iEXCEL_DNUSE", SqlDbType.Char);
            paramArray[28].Value        = iexcel_dnuse;
            paramArray[29]              = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[29].Value        = iis_team_kpi;
            paramArray[30]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[30].Value        = iuse_yn;
            paramArray[31]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[31].Value        = itxr_user;
            paramArray[32]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[32].Direction    = ParameterDirection.Output;
            paramArray[33]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[33].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        internal protected int InsertData_Dac
                (IDbConnection conn, IDbTransaction trx, 
                 int iestterm_ref_id,         string ikpi_code,               int ikpi_pool_ref_id,               string iword_definition, 
                 string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
                 int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
                 string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
                 int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,     
                 string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(34);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value         = ikpi_code;
            paramArray[3]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_pool_ref_id;
            paramArray[4]               = CreateDataParameter("@iWORD_DEFINITION", SqlDbType.VarChar);
            paramArray[4].Value         = iword_definition;
            paramArray[5]               = CreateDataParameter("@iMEASUREMENT_PURPOSE", SqlDbType.VarChar);
            paramArray[5].Value         = imeasurement_purpose;
            paramArray[6]               = CreateDataParameter("@iCALC_FORM_MS", SqlDbType.VarChar);
            paramArray[6].Value         = icalc_form_ms;
            paramArray[7]               = CreateDataParameter("@iCALC_FORM_TS", SqlDbType.VarChar);
            paramArray[7].Value         = icalc_form_ts;
            paramArray[8]               = CreateDataParameter("@iRELATED_ISSUE", SqlDbType.VarChar);
            paramArray[8].Value         = irelated_issue;
            paramArray[9]               = CreateDataParameter("@iADD_FILE", SqlDbType.VarChar);
            paramArray[9].Value         = iadd_file;
            paramArray[10]              = CreateDataParameter("@iCHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[10].Value        = ichampion_emp_id;
            paramArray[11]              = CreateDataParameter("@iMEASUREMENT_EMP_ID", SqlDbType.Int);
            paramArray[11].Value        = imeasurement_emp_id;
            paramArray[12]              = CreateDataParameter("@iAPPROVAL_EMP_ID", SqlDbType.Int);
            paramArray[12].Value        = iapproval_emp_id;
            paramArray[13]              = CreateDataParameter("@iDATA_GETHERING_METHOD", SqlDbType.VarChar);
            paramArray[13].Value        = idata_gethering_method;
            paramArray[14]              = CreateDataParameter("@iRESULT_TERM_TYPE", SqlDbType.VarChar);
            paramArray[14].Value        = iresult_term_type;
            paramArray[15]              = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[15].Value        = iresult_input_type;
            paramArray[16]              = CreateDataParameter("@iRESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[16].Value        = iresult_achievement_type;
            paramArray[17]              = CreateDataParameter("@iRESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[17].Value        = iresult_ts_calc_type;
            paramArray[18]              = CreateDataParameter("@iRESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[18].Value        = iresult_measurement_step;
            paramArray[19]              = CreateDataParameter("@iMEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[19].Value        = imeasurement_grade_type;
            paramArray[20]              = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[20].Value        = iunit_type_ref_id;
            paramArray[21]              = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.VarChar);
            paramArray[21].Value        = ikpi_target_version_id;
            paramArray[22]              = CreateDataParameter("@iKPI_TARGET_SETTING_REASON", SqlDbType.Text);
            paramArray[22].Value        = ikpi_target_setting_reason;
            paramArray[23]              = CreateDataParameter("@iKPI_TARGET_REASON_FILE", SqlDbType.VarChar);
            paramArray[23].Value        = ikpi_target_reason_file;
            paramArray[24]              = CreateDataParameter("@iAPPROVAL_STATUS", SqlDbType.Char);
            paramArray[24].Value        = iapproval_status;
            paramArray[25]              = CreateDataParameter("@iGRAPH_TYPE", SqlDbType.VarChar);
            paramArray[25].Value        = igraph_type;
            paramArray[26]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Int);
            paramArray[26].Value        = iapp_ref_id;
            paramArray[27]              = CreateDataParameter("@iEXCEL_DNUSE", SqlDbType.Char);
            paramArray[27].Value        = iexcel_dnuse;
            paramArray[28]              = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[28].Value        = iis_team_kpi;
            paramArray[29]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[29].Value        = iuse_yn;
            paramArray[30]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[30].Value        = itxr_user;
            paramArray[31]              = CreateDataParameter("@oRTN_KPI_REF_ID", SqlDbType.Int);
            paramArray[31].Direction    = ParameterDirection.Output;
            paramArray[32]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[32].Direction    = ParameterDirection.Output;
            paramArray[33]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[33].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Ikpi_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_KPI_REF_ID").ToString());


            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection conn, IDbTransaction trx, 
                 int iestterm_ref_id,         int ikpi_ref_id,                 string ikpi_code,                  int ikpi_pool_ref_id,            string iword_definition, 
                 string imeasurement_purpose, string icalc_form_ms,            string icalc_form_ts,              string irelated_issue,           string iadd_file, 
                 int ichampion_emp_id,        int imeasurement_emp_id,         int iapproval_emp_id,              string idata_gethering_method,   string iresult_term_type, 
                 string iresult_input_type,   string iresult_achievement_type, string iresult_ts_calc_type,       string iresult_measurement_step, string imeasurement_grade_type, 
                 int iunit_type_ref_id,       string ikpi_target_version_id,   string ikpi_target_setting_reason, string ikpi_target_reason_file,  string iapproval_status,     
                 string igraph_type,          decimal iapp_ref_id,             string iexcel_dnuse,               string iis_team_kpi,             string iuse_yn,                  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(34);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = ikpi_pool_ref_id;
            paramArray[5]               = CreateDataParameter("@iWORD_DEFINITION", SqlDbType.VarChar);
            paramArray[5].Value         = iword_definition;
            paramArray[6]               = CreateDataParameter("@iMEASUREMENT_PURPOSE", SqlDbType.VarChar);
            paramArray[6].Value         = imeasurement_purpose;
            paramArray[7]               = CreateDataParameter("@iCALC_FORM_MS", SqlDbType.VarChar);
            paramArray[7].Value         = icalc_form_ms;
            paramArray[8]               = CreateDataParameter("@iCALC_FORM_TS", SqlDbType.VarChar);
            paramArray[8].Value         = icalc_form_ts;
            paramArray[9]               = CreateDataParameter("@iRELATED_ISSUE", SqlDbType.VarChar);
            paramArray[9].Value         = irelated_issue;
            paramArray[10]              = CreateDataParameter("@iADD_FILE", SqlDbType.VarChar);
            paramArray[10].Value        = iadd_file;
            paramArray[11]              = CreateDataParameter("@iCHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[11].Value        = ichampion_emp_id;
            paramArray[12]              = CreateDataParameter("@iMEASUREMENT_EMP_ID", SqlDbType.Int);
            paramArray[12].Value        = imeasurement_emp_id;
            paramArray[13]              = CreateDataParameter("@iAPPROVAL_EMP_ID", SqlDbType.Int);
            paramArray[13].Value        = iapproval_emp_id;
            paramArray[14]              = CreateDataParameter("@iDATA_GETHERING_METHOD", SqlDbType.VarChar);
            paramArray[14].Value        = idata_gethering_method;
            paramArray[15]              = CreateDataParameter("@iRESULT_TERM_TYPE", SqlDbType.VarChar);
            paramArray[15].Value        = iresult_term_type;
            paramArray[16]              = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[16].Value        = iresult_input_type;
            paramArray[17]              = CreateDataParameter("@iRESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[17].Value        = iresult_achievement_type;
            paramArray[18]              = CreateDataParameter("@iRESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[18].Value        = iresult_ts_calc_type;
            paramArray[19]              = CreateDataParameter("@iRESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[19].Value        = iresult_measurement_step;
            paramArray[20]              = CreateDataParameter("@iMEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[20].Value        = imeasurement_grade_type;
            paramArray[21]              = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[21].Value        = iunit_type_ref_id;
            paramArray[22]              = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.VarChar);
            paramArray[22].Value        = ikpi_target_version_id;
            paramArray[23]              = CreateDataParameter("@iKPI_TARGET_SETTING_REASON", SqlDbType.Text);
            paramArray[23].Value        = ikpi_target_setting_reason;
            paramArray[24]              = CreateDataParameter("@iKPI_TARGET_REASON_FILE", SqlDbType.VarChar);
            paramArray[24].Value        = ikpi_target_reason_file;
            paramArray[25]              = CreateDataParameter("@iAPPROVAL_STATUS", SqlDbType.Char);
            paramArray[25].Value        = iapproval_status;
            paramArray[26]              = CreateDataParameter("@iGRAPH_TYPE", SqlDbType.VarChar);
            paramArray[26].Value        = igraph_type;
            paramArray[27]              = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Int);
            paramArray[27].Value        = iapp_ref_id;
            paramArray[28]              = CreateDataParameter("@iEXCEL_DNUSE", SqlDbType.Char);
            paramArray[28].Value        = iexcel_dnuse;
            paramArray[29]              = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[29].Value        = iis_team_kpi;
            paramArray[30]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[30].Value        = iuse_yn;
            paramArray[31]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[31].Value        = itxr_user;
            paramArray[32]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[32].Direction    = ParameterDirection.Output;
            paramArray[33]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[33].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        internal protected int SetKpiConirm_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int SetKpiCancel_Dac(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CE";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction =    ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_CANCEL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int SetKpiParent_Dac(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 iup_kpi_ref_id, double iup_kpi_weight, string irollup_target_yn, string irollup_score_yn, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SP";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iUP_KPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iup_kpi_ref_id;
            paramArray[4]               = CreateDataParameter("@iUP_KPI_WEIGHT", SqlDbType.Decimal);
            paramArray[4].Value         = iup_kpi_weight;
            paramArray[5]               = CreateDataParameter("@iROLLUP_TARGET_YN", SqlDbType.VarChar);
            paramArray[5].Value         = irollup_target_yn;
            paramArray[6]               = CreateDataParameter("@iROLLUP_SCORE_YN", SqlDbType.VarChar);
            paramArray[6].Value         = irollup_score_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[9].Direction =    ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SET_PARENT_KPI"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int RemoveKpiParent_Dac(Int32 iestterm_ref_id, Int32 ikpi_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "OP";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction =    ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_OFF_PARENT_KPI"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 지표복사
        /// </summary>
        /// <param name="iestterm_ref_id_fr">평가기간 (FROM)</param>
        /// <param name="ikpi_ref_id">지표 (FROM)</param>
        /// <param name="iestterm_ref_id_to">평가기간 (TO)</param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int CopyKpiToAnotherTerm_Dac(Int32 iestterm_ref_id_fr, Int32 ikpi_ref_id, Int32 iestterm_ref_id_to, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CK";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID_FR", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id_fr;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID_FR", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iESTTERM_REF_ID_TO", SqlDbType.Int);
            paramArray[3].Value         = iestterm_ref_id_to;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction =    ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_COPY_KPI"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_ALL"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_ONE"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 사용자별 정의서 리스트 조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iresult_input_type"></param>
        /// <param name="ikpi_code"></param>
        /// <param name="ikpi_name"></param>
        /// <param name="iuse_yn"></param>
        /// <param name="ichampion_name"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetKpiListPerUser(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, string ikpi_group_ref_id, string iis_team_kpi, int itxr_user)
        {
            string strQuery = @"
SELECT KI.ESTTERM_REF_ID          
        ,KI.KPI_REF_ID
        ,KI.KPI_CODE                
        ,KI.KPI_POOL_REF_ID         
        ,ISNULL(KP.KPI_NAME,'') as KPI_NAME
        ,KI.WORD_DEFINITION         
        ,KI.MEASUREMENT_PURPOSE     
        ,KI.CALC_FORM_MS            
        ,KI.CALC_FORM_TS            
        ,KI.RELATED_ISSUE           
        ,KI.ADD_FILE                
        ,KI.CHAMPION_EMP_ID
        ,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME
        ,KI.MEASUREMENT_EMP_ID
        ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME
        ,KI.APPROVAL_EMP_ID
        ,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME
        ,KI.DATA_GETHERING_METHOD	 
        ,KI.RESULT_TERM_TYPE
        ,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
        ,KI.RESULT_INPUT_TYPE
        ,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME
        ,KI.RESULT_ACHIEVEMENT_TYPE 
        ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME
        ,KI.RESULT_TS_CALC_TYPE
        ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME
        ,KI.RESULT_MEASUREMENT_STEP
        ,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME
        ,KI.MEASUREMENT_GRADE_TYPE
        ,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
        ,KI.UNIT_TYPE_REF_ID
        ,ISNULL(CU.UNIT,'-') as UNIT_NAME
        ,KI.KPI_TARGET_VERSION_ID   
        ,KI.APPROVAL_STATUS         
        ,KI.GRAPH_TYPE              
        ,KI.EXCEL_DNUSE   
        ,KI.IS_TEAM_KPI          
        ,KI.USE_YN                  
        ,KI.ISDELETE
        ,VEE.COM_DEPT_NAME as OP_DEPT_NAME
        ,KP.KPI_GROUP_REF_ID
        ,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
        ,KI.APP_REF_ID
        ,ISNULL(AI.APP_STATUS,'NFT') as APP_STATUS
        ,ISNULL(CC2.CODE_NAME,'') as APP_STATUS_NAME
        ,KI.CREATE_DATE             
        ,KI.CREATE_USER             
        ,KI.UPDATE_DATE             
        ,KI.UPDATE_USER   
        ,bvi.view_name, bsi.stg_name, ISNULL(BMK.WEIGHT,0) AS WEIGHT, BVI.VIEW_REF_ID, BSI.STG_REF_ID
        ,DEPT2.DEPT_NAME, DEPT2.EST_DEPT_REF_ID
FROM BSC_KPI_INFO KI 
LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS001') CA1 
    ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS002') CA2
    ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS003') CA3
    ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS004') CA4
    ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS005') CA5
    ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS006') CA6
    ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'BS009') CA9
    ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
LEFT JOIN viw_EMP_COMDEPT VEE
    ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID
LEFT JOIN COM_APPROVAL_INFO AI
    ON KI.APP_REF_ID = AI.APP_REF_ID
   AND AI.ACTIVE_YN = 'Y'
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
          FROM COM_CODE_INFO 
         WHERE CATEGORY_CODE = 'CM002') CC2
    ON AI.APP_STATUS = CC2.ETC_CODE              -- KPI DRAFT STATUS
 LEFT OUTER JOIN BSC_MAP_KPI BMK ON bmk.estterm_ref_id = ki.estterm_ref_id AND bmk.kpi_ref_id = ki.kpi_ref_id and bmk.est_dept_ref_id = @iEST_DEPT_REF_ID
 LEFT OUTER JOIN BSC_STG_INFO BSI ON bmk.estterm_ref_id = bsi.estterm_ref_id AND bmk.stg_ref_id = bsi.stg_ref_id
 LEFT OUTER JOIN BSC_VIEW_INFO BVI ON bsi.view_ref_id = bvi.view_ref_id
 LEFT JOIN REL_DEPT_EMP DEPT1 ON CE1.EMP_REF_ID = DEPT1.EMP_REF_ID
 LEFT JOIN EST_DEPT_INFO DEPT2 ON DEPT1.DEPT_REF_ID = DEPT2.DEPT_REF_ID
WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
     AND KI.ISDELETE       = 'N'
     --AND KI.USE_YN         = 'Y'
     --AND KI.RESULT_INPUT_TYPE IN ('SYS', 'MAN')
    /*
     AND KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%')
     AND KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%')
     AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
     AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
     AND KI.USE_YN            LIKE ( @iUSE_YN            + '%')
     AND KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
     AND CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%')
    */
 
     AND (KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%') OR  @iKPI_CODE  ='' )
     AND (KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%') OR  @iKPI_NAME  ='' )
     AND (KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%') OR  @iKPI_GROUP_REF_ID  ='' )
     AND (KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%') OR  @iRESULT_INPUT_TYPE  ='' )
     AND (KI.USE_YN            LIKE ( @iUSE_YN            + '%') OR  @iUSE_YN  ='' )
     AND (KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%') OR  @iIS_TEAM_KPI  ='' )
     AND (CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%') OR  @iCHAMPION_NAME  ='' )

     AND VEE.COM_DEPT_REF_ID = CASE WHEN @iEST_DEPT_REF_ID < 1 THEN 
                                         VEE.COM_DEPT_REF_ID 
                                    ELSE @iEST_DEPT_REF_ID 
                               END
     AND VEE.COM_DEPT_REF_ID IN (SELECT ED.DEPT_REF_ID
                                   FROM BSC_EMP_COM_DEPT_DETAIL DD
                                        INNER JOIN COM_DEPT_INFO ED
                                           ON DD.DEPT_REF_ID = ED.DEPT_REF_ID
                                 WHERE DD.EMP_REF_ID     = @iTXR_USER)                     
ORDER BY VEE.COM_DEPT_REF_ID, CE1.EMP_NAME, bvi.view_SEQ, bsi.stg_name, KP.KPI_NAME
";
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            //paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            //paramArray[0].Value         = "SK";
            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[1].Value         = iresult_input_type;
            paramArray[2]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value         = ikpi_code;
            paramArray[3]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_name;
            paramArray[4] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[4].Value = iuse_yn;
            paramArray[5] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value = ichampion_name;
            paramArray[6] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iest_dept_ref_id;
            paramArray[7] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[7].Value = ikpi_group_ref_id;
            paramArray[8] = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[8].Value = iis_team_kpi;
            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_LIST_FOR_OWNER"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("EST_DEPT_NAME", typeof(string));

                string kpilist = string.Empty;
                foreach (DataRow dr in ds.Tables[0].Rows)
                    kpilist += dr["KPI_REF_ID"].ToString() + ",";

                kpilist = kpilist.Substring(0, kpilist.Length - 1);

                DataSet dsEstName = GetEstDeptNameForKpiList(iestterm_ref_id, kpilist);

                if (dsEstName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow[] drr = dsEstName.Tables[0].Select("KPI_REF_ID = " + dr["KPI_REF_ID"]);
                        foreach (DataRow drs in drr)
                            dr["EST_DEPT_NAME"] += (dr["EST_DEPT_NAME"].ToString().Equals("") ? drs["EST_DEPT_NAME"].ToString() : ", " + drs["EST_DEPT_NAME"].ToString());
                    }
                }
            }
            return ds;
        }

        public DataSet GetEstDeptNameForKpiList(int estterm_ref_id, string kpilist)
        {
            string strQuery = @"
SELECT  DISTINCT A.ESTTERM_REF_ID, A.KPI_REF_ID, ISNULL(B.DEPT_NAME, '') AS EST_DEPT_NAME
FROM    BSC_MAP_KPI A
LEFT OUTER JOIN EST_DEPT_INFO B ON B.EST_DEPT_REF_ID = A.EST_DEPT_REF_ID
WHERE   A.ESTTERM_REF_ID = @ESTTERM_REF_ID AND A.KPI_REF_ID IN ({0})
    AND A.MAP_VERSION_ID = (SELECT MAX(MAP_VERSION_ID) FROM BSC_MAP_INFO WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = A.EST_DEPT_REF_ID AND USE_YN='Y')
ORDER BY A.ESTTERM_REF_ID, A.KPI_REF_ID
";
            string strQueryOra = @"
SELECT  DISTINCT A.ESTTERM_REF_ID, A.KPI_REF_ID, NVL(B.DEPT_NAME, ' ') AS EST_DEPT_NAME
FROM    BSC_MAP_KPI A
LEFT OUTER JOIN EST_DEPT_INFO B ON B.EST_DEPT_REF_ID = A.EST_DEPT_REF_ID
WHERE   A.ESTTERM_REF_ID = @ESTTERM_REF_ID AND A.KPI_REF_ID IN ({0})
    AND A.MAP_VERSION_ID = (SELECT MAX(MAP_VERSION_ID) FROM BSC_MAP_INFO WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = A.EST_DEPT_REF_ID AND USE_YN='Y')
ORDER BY A.ESTTERM_REF_ID, A.KPI_REF_ID
";
            strQuery = string.Format(strQuery, kpilist);
            strQueryOra = string.Format(strQueryOra, kpilist);

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;

            return DbAgentObj.FillDataSet(GetQueryStringByDb(strQuery, strQueryOra), "BSC_MAP_KPI_FOR_ESTDEPTNAME", null, paramArray, CommandType.Text);
        }

        public DataSet GetKpiResultListForBatchDraft(int iestterm_ref_id, string iymd, string iresult_input_type, string ikpi_group_ref_id, string iis_team_kpi, int itxr_user, string kpilist)
        {
            string strQueryMS = @"
SELECT   KI.ESTTERM_REF_ID,KI.KPI_REF_ID,KR.YMD,KI.KPI_CODE,KI.KPI_POOL_REF_ID         
        ,ISNULL(KP.KPI_NAME,'') as KPI_NAME,KI.WORD_DEFINITION,KI.MEASUREMENT_PURPOSE,KI.CALC_FORM_MS,KI.CALC_FORM_TS
        ,KI.RELATED_ISSUE,KI.ADD_FILE,KI.CHAMPION_EMP_ID,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME,KI.MEASUREMENT_EMP_ID
        ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME,KI.APPROVAL_EMP_ID,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME,KI.DATA_GETHERING_METHOD,KI.RESULT_TERM_TYPE,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
        ,KI.RESULT_INPUT_TYPE,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME,KI.RESULT_ACHIEVEMENT_TYPE ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME,KI.RESULT_TS_CALC_TYPE
        ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME,KI.RESULT_MEASUREMENT_STEP,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME,KI.MEASUREMENT_GRADE_TYPE,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
        ,KI.UNIT_TYPE_REF_ID,ISNULL(CU.UNIT,'-') as UNIT_NAME,KI.KPI_TARGET_VERSION_ID   ,KI.APPROVAL_STATUS         ,KI.GRAPH_TYPE              
        ,KI.EXCEL_DNUSE         ,KI.IS_TEAM_KPI    ,KI.USE_YN                  
        ,KI.ISDELETE,VEE.COM_DEPT_NAME as OP_DEPT_NAME
        ,KT.CHECK_YN,KR.CHECKSTATUS,KR.CONFIRMSTATUS,KP.KPI_GROUP_REF_ID,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
        ,KR.APP_REF_ID,ISNULL(AI.APP_STATUS,'NFT') as APP_STATUS,ISNULL(CC2.CODE_NAME,'') as APP_STATUS_NAME,KI.CREATE_DATE             ,KI.CREATE_USER             
        ,KI.UPDATE_DATE             ,KI.UPDATE_USER   
        ,KR.RESULT_MS
        ,dbo.fn_BSC_KPI_RESULT_TS(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD) as RESULT_TS
        ,dbo.fn_BSC_KPI_INDICATOR_IMG_PRE(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, 'MS') AS SIGNAL_MS
        ,dbo.fn_BSC_KPI_INDICATOR_IMG_PRE(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, 'TS') AS SIGNAL_TS
FROM BSC_KPI_INFO KI 
LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
LEFT JOIN BSC_KPI_TERM KT
 ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KT.KPI_REF_ID
AND KT.YMD            = @iYMD
LEFT JOIN BSC_KPI_RESULT KR 
 ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KR.KPI_REF_ID
AND KR.YMD            = @iYMD
LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS001') CA1 
	  ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS002') CA2
	  ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS003') CA3
	  ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS004') CA4
	  ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS005') CA5
	  ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS006') CA6
	  ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS009') CA9
	  ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
LEFT JOIN viw_EMP_COMDEPT VEE
	  ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
LEFT JOIN COM_APPROVAL_INFO AK
	  ON KI.APP_REF_ID = AK.APP_REF_ID
	 AND AK.ACTIVE_YN      = 'Y' 
LEFT JOIN COM_APPROVAL_INFO AI
	  ON KR.APP_REF_ID = AI.APP_REF_ID
	 AND AI.ACTIVE_YN      = 'Y'
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'CM002') CC2
	  ON AI.APP_STATUS = CC2.ETC_CODE              -- KPI DRAFT STATUS                         
WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
    AND KI.ISDELETE       = 'N'
    AND KI.USE_YN         = 'Y'
    AND ISNULL(AK.APP_STATUS, '')     = {1}
    AND ISNULL(AI.APP_STATUS,'NFT') IN ('NFT', 'MFT', 'AFT', 'RFT')
/*
    AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
    AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
    AND KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
*/
    AND (KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%') OR  @iKPI_GROUP_REF_ID  ='' )
    AND (KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%') OR  @iRESULT_INPUT_TYPE  ='' )
    AND (KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%') OR  @iIS_TEAM_KPI  ='' )

    AND KI.CHAMPION_EMP_ID = @iTXR_USER
    AND ISNULL(KT.CHECK_YN, 'N') = 'Y'
    AND ISNULL(KR.CHECKSTATUS, 'N') = 'Y'
{0}
ORDER BY VEE.COM_DEPT_REF_ID, KT.CHECK_YN DESC, KR.CHECKSTATUS DESC, KR.CONFIRMSTATUS DESC, CE1.EMP_NAME, KP.KPI_NAME
";
            string strQueryOra = @"
SELECT   KI.ESTTERM_REF_ID,KI.KPI_REF_ID,KR.YMD,KI.KPI_CODE,KI.KPI_POOL_REF_ID         
        ,ISNULL(KP.KPI_NAME,'') as KPI_NAME,KI.WORD_DEFINITION,KI.MEASUREMENT_PURPOSE,KI.CALC_FORM_MS,KI.CALC_FORM_TS
        ,KI.RELATED_ISSUE,KI.ADD_FILE,KI.CHAMPION_EMP_ID,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME,KI.MEASUREMENT_EMP_ID
        ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME,KI.APPROVAL_EMP_ID,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME,KI.DATA_GETHERING_METHOD,KI.RESULT_TERM_TYPE,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
        ,KI.RESULT_INPUT_TYPE,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME,KI.RESULT_ACHIEVEMENT_TYPE ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME,KI.RESULT_TS_CALC_TYPE
        ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME,KI.RESULT_MEASUREMENT_STEP,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME,KI.MEASUREMENT_GRADE_TYPE,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
        ,KI.UNIT_TYPE_REF_ID,ISNULL(CU.UNIT,'-') as UNIT_NAME,KI.KPI_TARGET_VERSION_ID   ,KI.APPROVAL_STATUS         ,KI.GRAPH_TYPE              
        ,KI.EXCEL_DNUSE         ,KI.IS_TEAM_KPI    ,KI.USE_YN                  
        ,KI.ISDELETE,VEE.COM_DEPT_NAME as OP_DEPT_NAME
        ,KT.CHECK_YN,KR.CHECKSTATUS,KR.CONFIRMSTATUS,KP.KPI_GROUP_REF_ID,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
        ,KR.APP_REF_ID,ISNULL(AI.APP_STATUS,'NFT') as APP_STATUS,ISNULL(CC2.CODE_NAME,'') as APP_STATUS_NAME,KI.CREATE_DATE             ,KI.CREATE_USER             
        ,KI.UPDATE_DATE             ,KI.UPDATE_USER   
        ,KR.RESULT_MS
        ,fn_BSC_KPI_RESULT_TS(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD) as RESULT_TS
        ,fn_BSC_KPI_INDICATOR_IMG_PRE(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, 'MS') AS SIGNAL_MS
        ,fn_BSC_KPI_INDICATOR_IMG_PRE(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, 'TS') AS SIGNAL_TS
FROM BSC_KPI_INFO KI 
LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
LEFT JOIN BSC_KPI_TERM KT
 ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KT.KPI_REF_ID
AND KT.YMD            = @iYMD
LEFT JOIN BSC_KPI_RESULT KR 
 ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KR.KPI_REF_ID
AND KR.YMD            = @iYMD
LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS001') CA1 
	  ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS002') CA2
	  ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS003') CA3
	  ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS004') CA4
	  ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS005') CA5
	  ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS006') CA6
	  ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS009') CA9
	  ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
LEFT JOIN viw_EMP_COMDEPT VEE
	  ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
LEFT JOIN COM_APPROVAL_INFO AK
	  ON KI.APP_REF_ID = AK.APP_REF_ID
	 AND AK.ACTIVE_YN      = 'Y' 
LEFT JOIN COM_APPROVAL_INFO AI
	  ON KR.APP_REF_ID = AI.APP_REF_ID
	 AND AI.ACTIVE_YN      = 'Y'
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'CM002') CC2
	  ON AI.APP_STATUS = CC2.ETC_CODE              -- KPI DRAFT STATUS                         
WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
    AND KI.ISDELETE       = 'N'
    AND KI.USE_YN         = 'Y'
    AND NVL(AK.APP_STATUS, ' ')     = {1}
    AND ISNULL(AI.APP_STATUS,'NFT') IN ('NFT', 'MFT', 'AFT', 'RFT')
/*
    AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
    AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')    
    AND KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
*/

    AND (KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%') OR  @iKPI_GROUP_REF_ID  ='' )
    AND (KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%') OR  @iRESULT_INPUT_TYPE  ='' )
    AND (KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%') OR  @iIS_TEAM_KPI  ='' )

    AND KI.CHAMPION_EMP_ID = @iTXR_USER
    AND ISNULL(KT.CHECK_YN, 'N') = 'Y'
    AND ISNULL(KR.CHECKSTATUS, 'N') = 'Y'
{0}
ORDER BY VEE.COM_DEPT_REF_ID, KT.CHECK_YN DESC, KR.CHECKSTATUS DESC, KR.CONFIRMSTATUS DESC, CE1.EMP_NAME, KP.KPI_NAME
";
            if (!kpilist.Equals(""))
            {
                strQueryMS = string.Format(strQueryMS, "    AND KI.KPI_REF_ID IN(" + kpilist + ")", (iis_team_kpi == "Y" ? "'CFT'" : "ISNULL(AK.APP_STATUS, '')") );
                strQueryOra = string.Format(strQueryOra, "    AND KI.KPI_REF_ID IN(" + kpilist + ")", (iis_team_kpi == "Y" ? "'CFT'" : "NVL(AK.APP_STATUS, ' ')"));
            }
            else
            {
                strQueryMS = string.Format(strQueryMS, "", (iis_team_kpi == "Y" ? "'CFT'" : "ISNULL(AK.APP_STATUS, '')"));
                strQueryOra = string.Format(strQueryOra, "", (iis_team_kpi == "Y" ? "'CFT'" : "NVL(AK.APP_STATUS, ' ')"));
            }
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[1].Value = iymd;
            paramArray[2] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = iresult_input_type;
            paramArray[3] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_group_ref_id;
            paramArray[4] = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[4].Value = iis_team_kpi;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(strQueryMS, strQueryOra), "BSC_KPI_RESULT_FOR_BACHDRAFT", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("EST_DEPT_NAME", typeof(string));

                string kpilist2 = string.Empty;
                foreach (DataRow dr in ds.Tables[0].Rows)
                    kpilist2 += dr["KPI_REF_ID"].ToString() + ",";

                kpilist2 = kpilist2.Substring(0, kpilist2.Length - 1);

                DataSet dsEstName = GetEstDeptNameForKpiList(iestterm_ref_id, kpilist2);

                if (dsEstName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow[] drr = dsEstName.Tables[0].Select("KPI_REF_ID = " + dr["KPI_REF_ID"]);
                        foreach (DataRow drs in drr)
                            dr["EST_DEPT_NAME"] += (dr["EST_DEPT_NAME"].ToString().Equals("") ? drs["EST_DEPT_NAME"].ToString() : ", " + drs["EST_DEPT_NAME"].ToString());
                    }
                }
            }

            return ds;
        }

        public DataSet GetKpiListForBatchApproval(string app_ref_id, int emp_ref_id)
        {
            string strQuery = @"
SELECT   A.BIZ_TYPE, A.APP_REF_ID, B.CODE_NAME AS BIZ_TYPE_NAME, RA.YMD, A.VERSION_NO, C.LINE_STEP
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.ESTTERM_REF_ID ELSE RA.ESTTERM_REF_ID END AS ESTTERM_REF_ID
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.KPI_REF_ID ELSE RA.KPI_REF_ID END AS KPI_REF_ID
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.KPI_CODE ELSE RB.KPI_CODE END AS KPI_CODE   
        ,ISNULL(SB.KPI_NAME,'') AS KPI_NAME
        ,ISNULL(SC.EMP_NAME,'') AS CHAMPION_EMP_NAME
        ,SD.CODE_NAME as RESULT_INPUT_TYPE_NAME
        ,ISNULL(SE.UNIT,'-') AS UNIT_NAME
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.APPROVAL_STATUS ELSE RB.APPROVAL_STATUS END AS APPROVAL_STATUS
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.IS_TEAM_KPI   ELSE RB.IS_TEAM_KPI END AS IS_TEAM_KPI        
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.USE_YN     ELSE RB.USE_YN END AS USE_YN                        
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.ISDELETE     ELSE RB.ISDELETE END AS ISDELETE  
        ,SF.COM_DEPT_NAME AS OP_DEPT_NAME
        ,ISNULL(SG.CODE_NAME,'') AS KPI_GROUP_NAME
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.APP_REF_ID     ELSE RA.APP_REF_ID END AS APP_REF_ID  
        ,ISNULL(SH.APP_STATUS,'NFT') AS APP_STATUS
        ,ISNULL(SI.CODE_NAME,'') AS APP_STATUS_NAME
        ,RA.RESULT_MS
        ,dbo.fn_BSC_KPI_RESULT_TS(RA.ESTTERM_REF_ID, RA.KPI_REF_ID, RA.YMD) as RESULT_TS
        ,dbo.fn_BSC_KPI_INDICATOR_IMG_PRE(RA.ESTTERM_REF_ID, RA.KPI_REF_ID, RA.YMD, 'MS') AS SIGNAL_MS
        ,dbo.fn_BSC_KPI_INDICATOR_IMG_PRE(RA.ESTTERM_REF_ID, RA.KPI_REF_ID, RA.YMD, 'TS') AS SIGNAL_TS
FROM COM_APPROVAL_INFO A
INNER JOIN (SELECT ETC_CODE, CODE_NAME FROM COM_CODE_INFO WHERE CATEGORY_CODE = 'CM003') B ON A.BIZ_TYPE   = B.ETC_CODE 
INNER JOIN (SELECT APP_REF_ID, VERSION_NO, MAX(LINE_STEP) AS LINE_STEP
            FROM COM_APPROVAL_PRC 
            WHERE COMPLETE_YN = 'N'
            GROUP BY APP_REF_ID, VERSION_NO) C ON A.APP_REF_ID = C.APP_REF_ID AND A.VERSION_NO = C.VERSION_NO
INNER JOIN COM_APPROVAL_PRC D ON C.APP_REF_ID = D.APP_REF_ID AND C.VERSION_NO = D.VERSION_NO AND C.LINE_STEP  = D.LINE_STEP
INNER JOIN COM_APPROVAL_PRC E ON E.LINE_TYPE   = 'D' AND E.COMPLETE_YN = 'Y' AND A.APP_REF_ID = E.APP_REF_ID AND A.VERSION_NO = E.VERSION_NO
LEFT OUTER JOIN BSC_KPI_INFO SA ON SA.APP_REF_ID = A.APP_REF_ID AND SA.ISDELETE = 'N' AND SA.USE_YN = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT RA ON RA.APP_REF_ID = A.APP_REF_ID AND RA.CHECKSTATUS = 'Y'
LEFT OUTER JOIN BSC_KPI_INFO RB ON RA.ESTTERM_REF_ID = RA.ESTTERM_REF_ID AND RA.KPI_REF_ID = RB.KPI_REF_ID
LEFT JOIN BSC_KPI_POOL          SB ON SB.KPI_POOL_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.KPI_POOL_REF_ID ELSE RB.KPI_POOL_REF_ID END
LEFT JOIN COM_EMP_INFO          SC ON SC.EMP_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.CHAMPION_EMP_ID ELSE RB.CHAMPION_EMP_ID END
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS001') SD ON SD.ETC_CODE = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.RESULT_INPUT_TYPE ELSE RB.RESULT_INPUT_TYPE END
LEFT JOIN COM_UNIT_TYPE_INFO    SE ON SE.UNIT_TYPE_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.UNIT_TYPE_REF_ID ELSE RB.UNIT_TYPE_REF_ID END
LEFT JOIN viw_EMP_COMDEPT       SF ON SF.EMP_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.CHAMPION_EMP_ID ELSE RB.CHAMPION_EMP_ID END
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS009') SG ON SB.KPI_GROUP_REF_ID = SG.ETC_CODE
LEFT JOIN COM_APPROVAL_INFO     SH ON SH.APP_REF_ID =  CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.APP_REF_ID ELSE RA.APP_REF_ID END AND SH.ACTIVE_YN = 'Y'
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'CM002') SI ON SI.ETC_CODE = SH.APP_STATUS
WHERE   A.ACTIVE_YN   = 'Y'
    AND A.APP_STATUS IN ('DFT', 'OFT') -- 기안, 결재중인 문서만
    AND D.APP_EMP_ID  = @EMP_REF_ID
{0}
ORDER BY A.BIZ_TYPE, SB.KPI_NAME
";

            string strQueryOra = @"
SELECT   A.BIZ_TYPE, A.APP_REF_ID, B.CODE_NAME AS BIZ_TYPE_NAME, RA.YMD, A.VERSION_NO, C.LINE_STEP
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.ESTTERM_REF_ID ELSE RA.ESTTERM_REF_ID END AS ESTTERM_REF_ID
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.KPI_REF_ID ELSE RA.KPI_REF_ID END AS KPI_REF_ID
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.KPI_CODE ELSE RB.KPI_CODE END AS KPI_CODE   
        ,ISNULL(SB.KPI_NAME,'') AS KPI_NAME
        ,ISNULL(SC.EMP_NAME,'') AS CHAMPION_EMP_NAME
        ,SD.CODE_NAME as RESULT_INPUT_TYPE_NAME
        ,ISNULL(SE.UNIT,'-') AS UNIT_NAME
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.APPROVAL_STATUS ELSE RB.APPROVAL_STATUS END AS APPROVAL_STATUS
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.IS_TEAM_KPI   ELSE RB.IS_TEAM_KPI END AS IS_TEAM_KPI        
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.USE_YN     ELSE RB.USE_YN END AS USE_YN                        
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.ISDELETE     ELSE RB.ISDELETE END AS ISDELETE  
        ,SF.COM_DEPT_NAME AS OP_DEPT_NAME
        ,ISNULL(SG.CODE_NAME,'') AS KPI_GROUP_NAME
        ,CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.APP_REF_ID     ELSE RA.APP_REF_ID END AS APP_REF_ID  
        ,ISNULL(SH.APP_STATUS,'NFT') AS APP_STATUS
        ,ISNULL(SI.CODE_NAME,'') AS APP_STATUS_NAME
        ,RA.RESULT_MS
        ,fn_BSC_KPI_RESULT_TS(RA.ESTTERM_REF_ID, RA.KPI_REF_ID, RA.YMD) as RESULT_TS
        ,fn_BSC_KPI_INDICATOR_IMG_PRE(RA.ESTTERM_REF_ID, RA.KPI_REF_ID, RA.YMD, 'MS') AS SIGNAL_MS
        ,fn_BSC_KPI_INDICATOR_IMG_PRE(RA.ESTTERM_REF_ID, RA.KPI_REF_ID, RA.YMD, 'TS') AS SIGNAL_TS
FROM COM_APPROVAL_INFO A
INNER JOIN (SELECT ETC_CODE, CODE_NAME FROM COM_CODE_INFO WHERE CATEGORY_CODE = 'CM003') B ON A.BIZ_TYPE   = B.ETC_CODE 
INNER JOIN (SELECT APP_REF_ID, VERSION_NO, MAX(LINE_STEP) AS LINE_STEP
            FROM COM_APPROVAL_PRC 
            WHERE COMPLETE_YN = 'N'
            GROUP BY APP_REF_ID, VERSION_NO) C ON A.APP_REF_ID = C.APP_REF_ID AND A.VERSION_NO = C.VERSION_NO
INNER JOIN COM_APPROVAL_PRC D ON C.APP_REF_ID = D.APP_REF_ID AND C.VERSION_NO = D.VERSION_NO AND C.LINE_STEP  = D.LINE_STEP
INNER JOIN COM_APPROVAL_PRC E ON E.LINE_TYPE   = 'D' AND E.COMPLETE_YN = 'Y' AND A.APP_REF_ID = E.APP_REF_ID AND A.VERSION_NO = E.VERSION_NO
LEFT OUTER JOIN BSC_KPI_INFO SA ON SA.APP_REF_ID = A.APP_REF_ID AND SA.ISDELETE = 'N' AND SA.USE_YN = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT RA ON RA.APP_REF_ID = A.APP_REF_ID AND RA.CHECKSTATUS = 'Y'
LEFT OUTER JOIN BSC_KPI_INFO RB ON RA.ESTTERM_REF_ID = RA.ESTTERM_REF_ID AND RA.KPI_REF_ID = RB.KPI_REF_ID
LEFT JOIN BSC_KPI_POOL          SB ON SB.KPI_POOL_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.KPI_POOL_REF_ID ELSE RB.KPI_POOL_REF_ID END
LEFT JOIN COM_EMP_INFO          SC ON SC.EMP_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.CHAMPION_EMP_ID ELSE RB.CHAMPION_EMP_ID END
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS001') SD ON SD.ETC_CODE = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.RESULT_INPUT_TYPE ELSE RB.RESULT_INPUT_TYPE END
LEFT JOIN COM_UNIT_TYPE_INFO    SE ON SE.UNIT_TYPE_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.UNIT_TYPE_REF_ID ELSE RB.UNIT_TYPE_REF_ID END
LEFT JOIN viw_EMP_COMDEPT       SF ON SF.EMP_REF_ID = CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.CHAMPION_EMP_ID ELSE RB.CHAMPION_EMP_ID END
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS009') SG ON SB.KPI_GROUP_REF_ID = SG.ETC_CODE
LEFT JOIN COM_APPROVAL_INFO     SH ON SH.APP_REF_ID =  CASE WHEN A.BIZ_TYPE = 'KDA' THEN SA.APP_REF_ID ELSE RA.APP_REF_ID END AND SH.ACTIVE_YN = 'Y'
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'CM002') SI ON SI.ETC_CODE = SH.APP_STATUS
WHERE   A.ACTIVE_YN   = 'Y'
    AND A.APP_STATUS IN ('DFT', 'OFT') -- 기안, 결재중인 문서만
    AND D.APP_EMP_ID  = @EMP_REF_ID
{0}
ORDER BY A.BIZ_TYPE, SB.KPI_NAME
";
            if (!app_ref_id.Equals(""))
            {
                strQuery = string.Format(strQuery, "    AND A.APP_REF_ID IN(" + app_ref_id + ")");
                strQueryOra = string.Format(strQueryOra, "    AND A.APP_REF_ID IN(" + app_ref_id + ")");
            }
            else
            {
                strQuery = string.Format(strQuery, "");
            }
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(strQuery, strQueryOra), "BSC_KPILIST_FOR_BACHAPPROVAL", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiListForBatchDraft(int iestterm_ref_id, string iresult_input_type, string ikpi_group_ref_id, string iis_team_kpi, int itxr_user, string kpilist)
        {
            string strQuery = @"
SELECT   A.ESTTERM_REF_ID          
        ,A.KPI_REF_ID
        ,A.KPI_CODE                
        ,ISNULL(B.KPI_NAME,'') AS KPI_NAME
        ,ISNULL(C.EMP_NAME,'') AS CHAMPION_EMP_NAME
        ,D.CODE_NAME as RESULT_INPUT_TYPE_NAME
        ,ISNULL(E.UNIT,'-') AS UNIT_NAME
        ,A.APPROVAL_STATUS         
        ,A.IS_TEAM_KPI          
        ,A.USE_YN                  
        ,A.ISDELETE
        ,F.COM_DEPT_NAME AS OP_DEPT_NAME
        ,ISNULL(G.CODE_NAME,'') AS KPI_GROUP_NAME
        ,A.APP_REF_ID
        ,ISNULL(H.APP_STATUS,'NFT') AS APP_STATUS
        ,ISNULL(I.CODE_NAME,'') AS APP_STATUS_NAME
FROM BSC_KPI_INFO A
LEFT JOIN BSC_KPI_POOL          B ON A.KPI_POOL_REF_ID   = B.KPI_POOL_REF_ID
LEFT JOIN COM_EMP_INFO          C ON A.CHAMPION_EMP_ID   = C.EMP_REF_ID
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS001') D ON A.RESULT_INPUT_TYPE = D.ETC_CODE
LEFT JOIN COM_UNIT_TYPE_INFO    E ON A.UNIT_TYPE_REF_ID = E.UNIT_TYPE_REF_ID
LEFT JOIN viw_EMP_COMDEPT       F ON A.CHAMPION_EMP_ID = F.EMP_REF_ID
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS009') G ON B.KPI_GROUP_REF_ID = G.ETC_CODE
LEFT JOIN COM_APPROVAL_INFO     H ON A.APP_REF_ID = H.APP_REF_ID AND H.ACTIVE_YN = 'Y'
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'CM002') I ON H.APP_STATUS = I.ETC_CODE
WHERE   A.ESTTERM_REF_ID    = @iESTTERM_REF_ID
    AND A.ISDELETE          = 'N'
    AND A.USE_YN            = 'Y'
    AND A.CHAMPION_EMP_ID   = @iTXR_USER
/*
    AND B.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
    AND A.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
    AND A.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
*/

    AND (B.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')  OR  @iKPI_GROUP_REF_ID  ='' )
    AND (A.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')  OR  @iRESULT_INPUT_TYPE  ='' )
    AND (A.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')  OR  @iIS_TEAM_KPI  ='' )

    AND ISNULL(H.APP_STATUS,'NFT') IN ('NFT', 'MFT', 'AFT', 'RFT')
{0}
ORDER BY B.KPI_NAME
";
            if (!kpilist.Equals(""))
                strQuery = string.Format(strQuery, "    AND A.KPI_REF_ID IN(" + kpilist + ")");
            else
                strQuery = string.Format(strQuery, "");
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[1].Value = iresult_input_type;
            paramArray[2] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value = ikpi_group_ref_id;
            paramArray[3] = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[3].Value = iis_team_kpi;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO_FOR_BACHDRAFT", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 지표 사용자별 실적입력 대상조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iresult_input_type"></param>
        /// <param name="ikpi_code"></param>
        /// <param name="ikpi_name"></param>
        /// <param name="ichampion_name"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetKpiListForResultInput(  int iestterm_ref_id
                                                , string iresult_input_type
                                                , string ikpi_code
                                                , string ikpi_name
                                                , string ichampion_name
                                                , int iest_dept_ref_id
                                                , string iymd
                                                , string ikpi_group_ref_id
                                                , string iis_team_kpi
                                                , int itxr_user
                                                )
        { 
//            string query = @"SELECT    KI.ESTTERM_REF_ID          
//                                      ,KI.KPI_REF_ID
//                                      ,KR.YMD
//                                      ,KI.KPI_CODE                
//                                      ,KI.KPI_POOL_REF_ID         
//                                      ,ISNULL(KP.KPI_NAME,'') as KPI_NAME
//                                      ,KI.WORD_DEFINITION         
//                                      ,KI.MEASUREMENT_PURPOSE     
//                                      ,KI.CALC_FORM_MS            
//                                      ,KI.CALC_FORM_TS            
//                                      ,KI.RELATED_ISSUE           
//                                      ,KI.ADD_FILE                
//                                      ,KI.CHAMPION_EMP_ID
//                                      ,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME
//                                      ,KI.MEASUREMENT_EMP_ID
//                                      ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME
//                                      ,KI.APPROVAL_EMP_ID
//                                      ,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME
//                                      ,KI.DATA_GETHERING_METHOD	 
//                                      ,KI.RESULT_TERM_TYPE
//                                      ,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
//                                      ,KI.RESULT_INPUT_TYPE
//                                      ,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME
//                                      ,KI.RESULT_ACHIEVEMENT_TYPE 
//                                      ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME
//                                      ,KI.RESULT_TS_CALC_TYPE
//                                      ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME
//                                      ,KI.RESULT_MEASUREMENT_STEP
//                                      ,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME
//                                      ,KI.MEASUREMENT_GRADE_TYPE
//                                      ,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
//                                      ,KI.UNIT_TYPE_REF_ID
//                                      ,ISNULL(CU.UNIT,'-') as UNIT_NAME
//                                      ,KI.KPI_TARGET_VERSION_ID   
//                                      ,KI.APPROVAL_STATUS         
//                                      ,KI.GRAPH_TYPE              
//                                      ,KI.EXCEL_DNUSE         
//                                      ,KI.IS_TEAM_KPI    
//                                      ,KI.USE_YN                  
//                                      ,KI.ISDELETE
//                                      ,VEE.COM_DEPT_NAME as OP_DEPT_NAME
//                                      ,KT.CHECK_YN
//                                      ,KR.CHECKSTATUS
//                                      ,KR.CONFIRMSTATUS
//                                      ,KP.KPI_GROUP_REF_ID
//                                      ,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
//                                      ,KR.APP_REF_ID
//                                      ,ISNULL(AI.APP_STATUS,'NFT') as APP_STATUS
//                                      ,ISNULL(CC2.CODE_NAME,'') as APP_STATUS_NAME
//                                      ,KI.CREATE_DATE             
//                                      ,KI.CREATE_USER             
//                                      ,KI.UPDATE_DATE             
//                                      ,KI.UPDATE_USER   
//                                  FROM BSC_KPI_INFO KI 
//                                       LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
//                                       LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
//                                       LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
//                                       LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
//                                       LEFT JOIN BSC_KPI_TERM KT
//                                         ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
//                                        AND KI.KPI_REF_ID     = KT.KPI_REF_ID
//                                        AND KT.YMD            = @iYMD
//                                       LEFT JOIN BSC_KPI_RESULT KR 
//                                         ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
//                                        AND KI.KPI_REF_ID     = KR.KPI_REF_ID
//                                        AND KR.YMD            = @iYMD
//                                       LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS001') CA1 
//                                              ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS002') CA2
//                                              ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS003') CA3
//                                              ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS004') CA4
//                                              ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS005') CA5
//                                              ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS006') CA6
//                                              ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'BS009') CA9
//                                              ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
//                                       LEFT JOIN viw_EMP_COMDEPT VEE
//                                              ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
//                                       LEFT JOIN COM_APPROVAL_INFO AK
//                                              ON KI.APP_REF_ID = AK.APP_REF_ID
//                                             AND AK.ACTIVE_YN      = 'Y' 
//                                       LEFT JOIN COM_APPROVAL_INFO AI
//                                              ON KR.APP_REF_ID = AI.APP_REF_ID
//                                             AND AI.ACTIVE_YN      = 'Y'
//                                       LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
//                                                    FROM COM_CODE_INFO 
//                                                   WHERE CATEGORY_CODE = 'CM002') CC2
//                                              ON AI.APP_STATUS = CC2.ETC_CODE              -- KPI DRAFT STATUS                         
//                                 WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
//                                   AND KI.ISDELETE       = 'N'
//                                   AND KI.USE_YN         = 'Y'
//                                   AND AK.APP_STATUS     = 'CFT'
//                                   --AND KI.APPROVAL_STATUS = 'Y'
//                                   --AND KI.RESULT_INPUT_TYPE IN ('SYS', 'MAN')
//                                   AND KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%')
//                                   AND KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%')
//                                   AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
//                                   AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
//                                   AND CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%')
//                                   AND KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
//                                   AND VEE.COM_DEPT_REF_ID = CASE WHEN @iEST_DEPT_REF_ID < 1 THEN 
//                                                                       VEE.COM_DEPT_REF_ID 
//                                                                  ELSE @iEST_DEPT_REF_ID 
//                                                             END
//                                   AND VEE.COM_DEPT_REF_ID IN (SELECT ED.DEPT_REF_ID
//                                                                 FROM BSC_EMP_COM_DEPT_DETAIL DD
//                                                                      INNER JOIN COM_DEPT_INFO ED
//                                                                         ON DD.DEPT_REF_ID = ED.DEPT_REF_ID
//                                                               WHERE DD.EMP_REF_ID     = @iTXR_USER)
//			                       ";

//            if(iis_team_kpi.Equals("N"))
//                query += " AND CE1.EMP_REF_ID = @iTXR_USER";

//            query += " ORDER BY VEE.COM_DEPT_REF_ID, KT.CHECK_YN DESC, KR.CHECKSTATUS DESC, KR.CONFIRMSTATUS DESC, CE1.EMP_NAME, KP.KPI_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SR";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = iresult_input_type;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ichampion_name;
            paramArray[6]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = iest_dept_ref_id;
            paramArray[7]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[7].Value         = iymd;
            paramArray[8]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value         = ikpi_group_ref_id;
            paramArray[9]               = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[9].Value         = iis_team_kpi;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_LIST_FOR_RSLT"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            //DataSet ds = DbAgentObj.FillDataSet(query, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiListForResultInput(int iestterm_ref_id
                                                , string iresult_input_type
                                                , string ikpi_code
                                                , string ikpi_name
                                                , string ichampion_name
                                                , int iest_dept_ref_id
                                                , string iymd
                                                , string ikpi_group_ref_id
                                                , string iis_team_kpi
                                                , int itxr_user
                                                , int iAdminUser)
        {
            string strQuery = string.Empty;
            if (iAdminUser == 0)
                strQuery = @"
SELECT   
 KI.ESTTERM_REF_ID
,KI.KPI_REF_ID
,KR.YMD
,KI.KPI_CODE
,KI.KPI_POOL_REF_ID         
,ISNULL(KP.KPI_NAME,'') as KPI_NAME
,KI.WORD_DEFINITION
,KI.MEASUREMENT_PURPOSE
,KI.CALC_FORM_MS
,KI.CALC_FORM_TS
,KI.RELATED_ISSUE
,KI.ADD_FILE
,KI.CHAMPION_EMP_ID
,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME
,KI.MEASUREMENT_EMP_ID
,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME
,KI.APPROVAL_EMP_ID
,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME
,KI.DATA_GETHERING_METHOD
,KI.RESULT_TERM_TYPE
,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
,KI.RESULT_INPUT_TYPE
,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME
,KI.RESULT_ACHIEVEMENT_TYPE 
,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME
,KI.RESULT_TS_CALC_TYPE
,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME
,KI.RESULT_MEASUREMENT_STEP
,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME
,KI.MEASUREMENT_GRADE_TYPE
,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
,KI.UNIT_TYPE_REF_ID
,ISNULL(CU.UNIT,'-') as UNIT_NAME
,KI.KPI_TARGET_VERSION_ID   
,KI.APPROVAL_STATUS         
,KI.GRAPH_TYPE              
,KI.EXCEL_DNUSE         
,KI.IS_TEAM_KPI    
,KI.USE_YN                  
,KI.ISDELETE
,VEE.COM_DEPT_NAME as OP_DEPT_NAME
,KT.CHECK_YN
,KR.CHECKSTATUS
,KR.CONFIRMSTATUS
,KP.KPI_GROUP_REF_ID
,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
,KR.APP_REF_ID
,ISNULL(AI.APP_STATUS,'NFT') as APP_STATUS
,ISNULL(CC2.CODE_NAME,'') as APP_STATUS_NAME
,KI.CREATE_DATE             
,KI.CREATE_USER             
,KI.UPDATE_DATE             
,KI.UPDATE_USER   
,BSI.STG_NAME, BVI.VIEW_NAME, BR.RESULT_MS, BT.TARGET_MS, ISNULL(BMK.WEIGHT,0) AS WEIGHT, BR.RESULT_TS, BT.TARGET_TS, BTG.TARGET_MS AS TARGET_MS_G, BTG.TARGET_TS AS TARGET_TS_G
FROM BSC_KPI_INFO KI 
LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
LEFT JOIN BSC_KPI_TERM KT
 ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KT.KPI_REF_ID
AND KT.YMD            = @iYMD
LEFT JOIN BSC_KPI_RESULT KR 
 ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KR.KPI_REF_ID
AND KR.YMD            = @iYMD
LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS001') CA1 
	  ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS002') CA2
	  ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS003') CA3
	  ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS004') CA4
	  ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS005') CA5
	  ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS006') CA6
	  ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS009') CA9
	  ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
LEFT JOIN viw_EMP_COMDEPT VEE
	  ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
LEFT JOIN COM_APPROVAL_INFO AK
	  ON KI.APP_REF_ID = AK.APP_REF_ID
	 AND AK.ACTIVE_YN      = 'Y' 
LEFT JOIN COM_APPROVAL_INFO AI
	  ON KR.APP_REF_ID = AI.APP_REF_ID
	 AND AI.ACTIVE_YN      = 'Y'
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'CM002') CC2
	  ON AI.APP_STATUS = CC2.ETC_CODE              -- KPI DRAFT STATUS  

LEFT OUTER JOIN BSC_MAP_KPI BMK ON bmk.estterm_ref_id = ki.estterm_ref_id AND bmk.kpi_ref_id = ki.kpi_ref_id AND BMK.EST_DEPT_REF_ID = VEE.COM_DEPT_REF_ID
LEFT OUTER JOIN BSC_STG_INFO BSI ON KI.estterm_ref_id = bsi.estterm_ref_id AND KP.stg_ref_id = bsi.stg_ref_id 
LEFT OUTER JOIN BSC_VIEW_INFO BVI ON BSI.view_ref_id = bvi.view_ref_id
LEFT OUTER JOIN BSC_KPI_TARGET BT ON BT.KPI_REF_ID = KI.KPI_REF_ID AND BT.YMD = @iYMD  
LEFT OUTER JOIN BSC_KPI_RESULT BR ON BR.KPI_REF_ID = KI.KPI_REF_ID AND BR.YMD = @iYMD                     
LEFT OUTER JOIN BSC_KPI_TARGET_GOAL BTG ON BTG.KPI_REF_ID = KI.KPI_REF_ID AND BTG.YMD = @iYMD  

WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
    AND KI.ISDELETE       = 'N'
    AND KI.USE_YN         = 'Y'
    AND AK.APP_STATUS     = 'CFT'
    --AND KI.APPROVAL_STATUS = 'Y'
    --AND KI.RESULT_INPUT_TYPE IN ('SYS', 'MAN')

/*
    AND KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%')
    AND KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%')
    AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
    AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
    AND CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%')
    AND KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
*/
    AND (KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%') OR  @iKPI_CODE  ='' )
    AND (KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%') OR  @iKPI_NAME  ='' )
    AND (KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%') OR  @iKPI_GROUP_REF_ID  ='' )
    AND (KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%') OR  @iRESULT_INPUT_TYPE  ='' )
    AND (CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%') OR  @iCHAMPION_NAME  ='' )
    AND (KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%') OR  @iIS_TEAM_KPI  ='' )

    AND VEE.COM_DEPT_REF_ID = CASE WHEN @iEST_DEPT_REF_ID < 1 THEN VEE.COM_DEPT_REF_ID ELSE @iEST_DEPT_REF_ID END
    AND VEE.COM_DEPT_REF_ID IN (SELECT ED.DEPT_REF_ID
							     FROM BSC_EMP_COM_DEPT_DETAIL DD
								      INNER JOIN COM_DEPT_INFO ED
									     ON DD.DEPT_REF_ID = ED.DEPT_REF_ID
						       WHERE DD.EMP_REF_ID     = @iTXR_USER)
    AND KI.CHAMPION_EMP_ID = (CASE WHEN @iIS_TEAM_KPI='Y' THEN KI.CHAMPION_EMP_ID ELSE @iTXR_USER END)
ORDER BY VEE.COM_DEPT_REF_ID, KT.CHECK_YN DESC, KR.CHECKSTATUS DESC, KR.CONFIRMSTATUS DESC, CE1.EMP_NAME, KP.KPI_NAME
";
            else
                strQuery = @"
SELECT   KI.ESTTERM_REF_ID          
        ,KI.KPI_REF_ID
        ,KR.YMD
        ,KI.KPI_CODE                
        ,KI.KPI_POOL_REF_ID         
        ,ISNULL(KP.KPI_NAME,'') as KPI_NAME
        ,KI.WORD_DEFINITION         
        ,KI.MEASUREMENT_PURPOSE     
        ,KI.CALC_FORM_MS            
        ,KI.CALC_FORM_TS            
        ,KI.RELATED_ISSUE           
        ,KI.ADD_FILE                
        ,KI.CHAMPION_EMP_ID
        ,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME
        ,KI.MEASUREMENT_EMP_ID
        ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME
        ,KI.APPROVAL_EMP_ID
        ,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME
        ,KI.DATA_GETHERING_METHOD	 
        ,KI.RESULT_TERM_TYPE
        ,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
        ,KI.RESULT_INPUT_TYPE
        ,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME
        ,KI.RESULT_ACHIEVEMENT_TYPE 
        ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME
        ,KI.RESULT_TS_CALC_TYPE
        ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME
        ,KI.RESULT_MEASUREMENT_STEP
        ,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME
        ,KI.MEASUREMENT_GRADE_TYPE
        ,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
        ,KI.UNIT_TYPE_REF_ID
        ,ISNULL(CU.UNIT,'-') as UNIT_NAME
        ,KI.KPI_TARGET_VERSION_ID   
        ,KI.APPROVAL_STATUS         
        ,KI.GRAPH_TYPE              
        ,KI.EXCEL_DNUSE         
        ,KI.IS_TEAM_KPI    
        ,KI.USE_YN                  
        ,KI.ISDELETE
        ,VEE.COM_DEPT_NAME as OP_DEPT_NAME
        ,KT.CHECK_YN
        ,KR.CHECKSTATUS
        ,KR.CONFIRMSTATUS
        ,KP.KPI_GROUP_REF_ID
        ,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
        ,KR.APP_REF_ID
        ,ISNULL(AI.APP_STATUS,'NFT') as APP_STATUS
        ,ISNULL(CC2.CODE_NAME,'') as APP_STATUS_NAME
        ,KI.CREATE_DATE             
        ,KI.CREATE_USER             
        ,KI.UPDATE_DATE             
        ,KI.UPDATE_USER   
        ,BSI.STG_NAME, BVI.VIEW_NAME, BR.RESULT_MS, BT.TARGET_MS, ISNULL(BMK.WEIGHT,0) AS WEIGHT, BR.RESULT_TS, BT.TARGET_TS, BTG.TARGET_MS AS TARGET_MS_G, BTG.TARGET_TS AS TARGET_TS_G
FROM BSC_KPI_INFO KI 
LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
LEFT JOIN BSC_KPI_TERM KT
 ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KT.KPI_REF_ID
AND KT.YMD            = @iYMD
LEFT JOIN BSC_KPI_RESULT KR 
 ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
AND KI.KPI_REF_ID     = KR.KPI_REF_ID
AND KR.YMD            = @iYMD
LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS001') CA1 
	  ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS002') CA2
	  ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS003') CA3
	  ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS004') CA4
	  ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS005') CA5
	  ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS006') CA6
	  ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'BS009') CA9
	  ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
LEFT JOIN viw_EMP_COMDEPT VEE
	  ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
LEFT JOIN COM_APPROVAL_INFO AK
	  ON KI.APP_REF_ID = AK.APP_REF_ID
	 AND AK.ACTIVE_YN      = 'Y' 
LEFT JOIN COM_APPROVAL_INFO AI
	  ON KR.APP_REF_ID = AI.APP_REF_ID
	 AND AI.ACTIVE_YN      = 'Y'
LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
			FROM COM_CODE_INFO 
		   WHERE CATEGORY_CODE = 'CM002') CC2
	  ON AI.APP_STATUS = CC2.ETC_CODE              -- KPI DRAFT STATUS  

LEFT OUTER JOIN BSC_MAP_KPI BMK ON bmk.estterm_ref_id = ki.estterm_ref_id AND bmk.kpi_ref_id = ki.kpi_ref_id AND BMK.EST_DEPT_REF_ID = VEE.COM_DEPT_REF_ID
LEFT OUTER JOIN BSC_STG_INFO BSI ON KI.estterm_ref_id = bsi.estterm_ref_id AND KP.stg_ref_id = bsi.stg_ref_id 
LEFT OUTER JOIN BSC_VIEW_INFO BVI ON BSI.view_ref_id = bvi.view_ref_id
LEFT OUTER JOIN BSC_KPI_TARGET BT ON BT.KPI_REF_ID = KI.KPI_REF_ID AND BT.YMD = @iYMD  
LEFT OUTER JOIN BSC_KPI_RESULT BR ON BR.KPI_REF_ID = KI.KPI_REF_ID AND BR.YMD = @iYMD 
LEFT OUTER JOIN BSC_KPI_TARGET_GOAL BTG ON BTG.KPI_REF_ID = KI.KPI_REF_ID AND BTG.YMD = @iYMD       
                       
WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
    AND KI.ISDELETE       = 'N'
    AND KI.USE_YN         = 'Y'
    AND AK.APP_STATUS     = 'CFT'
    --AND KI.APPROVAL_STATUS = 'Y'
    --AND KI.RESULT_INPUT_TYPE IN ('SYS', 'MAN')
/*
    AND KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%') 
    AND KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%')
    AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
    AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
    AND CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%')
    AND KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%')
*/

    AND (KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%') OR  @iKPI_CODE  ='' )
    AND (KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%') OR  @iKPI_NAME  ='' )
    AND (KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%') OR  @iKPI_GROUP_REF_ID  ='' )
    AND (KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%') OR  @iRESULT_INPUT_TYPE  ='' )
    AND (CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%') OR  @iCHAMPION_NAME  ='' )
    AND (KI.IS_TEAM_KPI       LIKE ( @iIS_TEAM_KPI       + '%') OR  @iIS_TEAM_KPI  ='' )
    AND VEE.COM_DEPT_REF_ID = CASE WHEN @iEST_DEPT_REF_ID < 1 THEN 
				   VEE.COM_DEPT_REF_ID 
			  ELSE @iEST_DEPT_REF_ID
		 END
ORDER BY VEE.COM_DEPT_REF_ID, KT.CHECK_YN DESC, KR.CHECKSTATUS DESC, KR.CONFIRMSTATUS DESC, CE1.EMP_NAME, KP.KPI_NAME
";

            IDbDataParameter[] paramArray = null;

            if (iAdminUser == 0)
            {
                paramArray = CreateDataParameters(10);
            }
            else
            {
                paramArray = CreateDataParameters(9);
            }

            //paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            //paramArray[0].Value = "SR";
            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int); 
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[1].Value = iresult_input_type;
            paramArray[2] = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value = ikpi_code;
            paramArray[3] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_name;
            paramArray[4] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[4].Value = ichampion_name;
            paramArray[5] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = iest_dept_ref_id;
            paramArray[6] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[6].Value = iymd;
            paramArray[7] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[7].Value = ikpi_group_ref_id;
            paramArray[8] = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[8].Value = iis_team_kpi;

            if (iAdminUser == 0)
            {
                paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
                paramArray[9].Value = itxr_user;
            }

            //paramArray[10] = CreateDataParameter("@iADMIN_USER", SqlDbType.Int);
            //paramArray[10].Value = iAdminUser;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_LIST_FOR_RSLT"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("EST_DEPT_NAME", typeof(string));

                string kpilist = string.Empty;
                foreach (DataRow dr in ds.Tables[0].Rows)
                    kpilist += dr["KPI_REF_ID"].ToString() + ",";

                kpilist = kpilist.Substring(0, kpilist.Length - 1);

                DataSet dsEstName = GetEstDeptNameForKpiList(iestterm_ref_id, kpilist);

                if (dsEstName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow[] drr = dsEstName.Tables[0].Select("KPI_REF_ID = " + dr["KPI_REF_ID"]);
                        foreach (DataRow drs in drr)
                            dr["EST_DEPT_NAME"] += (dr["EST_DEPT_NAME"].ToString().Equals("") ? drs["EST_DEPT_NAME"].ToString() : ", " + drs["EST_DEPT_NAME"].ToString());
                    }
                }
            }

            return ds;
        }

        /// <summary>
        /// 지표 승인자별 승인 대상조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iresult_input_type"></param>
        /// <param name="ikpi_code"></param>
        /// <param name="ikpi_name"></param>
        /// <param name="ichampion_name"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetKpiListForApproval(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string ichampion_name, int iest_dept_ref_id, string iymd, string ikpi_group_ref_id, int itxr_user)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SL";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = iresult_input_type;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ichampion_name;
            paramArray[6]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = iest_dept_ref_id;
            paramArray[7]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[7].Value         = iymd;
            paramArray[8]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value         = ikpi_group_ref_id;
            paramArray[9]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_LIST_FOR_APPL"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiStatus(int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SS";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_STATUS"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListForResultAnalysis(int iestterm_ref_id, string iymd, string iresult_input_type, string ikpi_code, string ikpi_name,
                                                   string ichampion_name, int iest_dept_ref_id, int ithreshold_ref_id, string isum_type
                                                 , string ikpi_group_ref_id, string ikpi_external_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SN";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar,20);
            paramArray[3].Value         = iresult_input_type;
            paramArray[4]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_code;
            paramArray[5]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ikpi_name;
            paramArray[6]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ichampion_name;
            paramArray[7]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = iest_dept_ref_id;
            paramArray[8]               = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[8].Value         = ithreshold_ref_id;
            paramArray[9]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[9].Value         = isum_type;
            paramArray[10]              = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[10].Value        = ikpi_group_ref_id;
            paramArray[11]              = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[11].Value        = ikpi_external_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_ANALYSIS"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListForResultAnalysisNew(int iestterm_ref_id, string iymd, string iresult_input_type, string ikpi_code, string ikpi_name,
                                                   string ichampion_name, int iest_dept_ref_id, int ithreshold_ref_id, string isum_type
                                                 , object ikpi_group_ref_id, string ikpi_external_type, int group_code, string estYN, string goaltongYN)
        {
            string strQuery = @"
SELECT  TA.ESTTERM_REF_ID
        ,TA.KPI_REF_ID                       
        ,TA.YMD                              
        ,TA.KPI_CODE                         
        ,TA.KPI_POOL_REF_ID                  
        ,TA.KPI_NAME                         
        ,TA.WORD_DEFINITION                  
        ,TA.MEASUREMENT_PURPOSE              
        ,TA.CALC_FORM_MS                     
        ,TA.CALC_FORM_TS                     
        ,TA.RELATED_ISSUE                    
        ,TA.ADD_FILE                         
        ,TA.CHAMPION_EMP_ID                  
        ,TA.CHAMPION_EMP_NAME                
        ,TA.MEASUREMENT_EMP_ID               
        ,TA.MEASUREMENT_EMP_NAME             
        ,TA.APPROVAL_EMP_ID                  
        ,TA.APPROVAL_EMP_NAME                
        ,TA.DATA_GETHERING_METHOD            
        ,TA.RESULT_TERM_TYPE                 
        ,TA.RESULT_TERM_TYPE_NAME            
        ,TA.RESULT_INPUT_TYPE                
        ,TA.RESULT_INPUT_TYPE_NAME           
        ,TA.RESULT_ACHIEVEMENT_TYPE          
        ,TA.RESULT_ACHIEVEMENT_TYPE_NAME     
        ,TA.RESULT_TS_CALC_TYPE              
        ,TA.RESULT_TS_CALC_TYPE_NAME         
        ,TA.RESULT_MEASUREMENT_STEP          
        ,TA.RESULT_MEASUREMENT_STEP_NAME     
        ,TA.MEASUREMENT_GRADE_TYPE           
        ,TA.MEASUREMENT_GRADE_TYPE_NAME      
        ,TA.UNIT_TYPE_REF_ID                 
        ,TA.UNIT_NAME                        
        ,TA.KPI_TARGET_VERSION_ID            
        ,TA.APPROVAL_STATUS                  
        ,TA.GRAPH_TYPE                       
        ,TA.APP_REF_ID                       
        ,TA.EXCEL_DNUSE
        ,TA.USE_YN
        ,TA.ISDELETE
        ,TA.OP_DEPT_NAME
        ,TA.CHECK_YN
        ,TA.CHECKSTATUS
        ,TA.CONFIRMSTATUS
        ,TA.RESULT
        ,TA.TARGET
        ,TA.THRESHOLD_REF_ID
        ,TC.IMAGE_FILE_NAME as SIGNAL_IMAGE
        ,TA.TREND
        ,TA.ACHIEVE_RATE
       ,CASE WHEN (TA.RESULT_ACHIEVEMENT_TYPE='ATY' AND CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')) >=100) THEN CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')) 
             WHEN (TA.RESULT_ACHIEVEMENT_TYPE='ATY' AND CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')) < 100) THEN CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0'))-100
             ELSE (100-CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')))
        END as ACHIEVE_RATE_DIFF
        ,TA.KPI_GROUP_REF_ID
        ,TA.KPI_GROUP_NAME
        ,TA.CREATE_DATE
        ,TA.CREATE_USER
        ,TA.UPDATE_DATE
        ,TA.UPDATE_USER
FROM ( 
      SELECT KI.ESTTERM_REF_ID          
            ,KI.KPI_REF_ID
            ,KR.YMD
            ,KI.KPI_CODE                
            ,KI.KPI_POOL_REF_ID         
            ,ISNULL(KP.KPI_NAME,'') as KPI_NAME
            ,KI.WORD_DEFINITION         
            ,KI.MEASUREMENT_PURPOSE     
            ,KI.CALC_FORM_MS            
            ,KI.CALC_FORM_TS            
            ,KI.RELATED_ISSUE           
            ,KI.ADD_FILE                
            ,KI.CHAMPION_EMP_ID
            ,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME
            ,KI.MEASUREMENT_EMP_ID
            ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME
            ,KI.APPROVAL_EMP_ID
            ,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME
            ,KI.DATA_GETHERING_METHOD	 
            ,KI.RESULT_TERM_TYPE
            ,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
            ,KI.RESULT_INPUT_TYPE
            ,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME
            ,KI.RESULT_ACHIEVEMENT_TYPE 
            ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME
            ,KI.RESULT_TS_CALC_TYPE
            ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME
            ,KI.RESULT_MEASUREMENT_STEP
            ,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME
            ,KI.MEASUREMENT_GRADE_TYPE
            ,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
            ,KI.UNIT_TYPE_REF_ID
            ,ISNULL(CU.UNIT,'-') as UNIT_NAME
            ,KI.KPI_TARGET_VERSION_ID   
            ,KI.APPROVAL_STATUS         
            ,KI.GRAPH_TYPE              
            ,KI.APP_REF_ID
            ,KI.EXCEL_DNUSE             
            ,KI.USE_YN                  
            ,KI.ISDELETE
            ,VEE.COM_DEPT_NAME as OP_DEPT_NAME
            ,KT.CHECK_YN
            ,KR.CHECKSTATUS
            ,KR.CONFIRMSTATUS
            ,CASE WHEN @iSUM_TYPE='MS' THEN KR.RESULT_MS ELSE dbo.fn_BSC_KPI_RESULT_TS(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD) END as RESULT
            ,CASE WHEN @iSUM_TYPE='MS' THEN BT.TARGET_MS ELSE dbo.fn_BSC_KPI_TARGET_TS(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD) END as TARGET
            ,dbo.fn_BSC_KPI_INDICATOR_ID(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, @iSUM_TYPE) as THRESHOLD_REF_ID
            ,dbo.fn_BSC_KPI_TREND(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, @iSUM_TYPE) as TREND
            ,dbo.fn_BSC_KPI_ACHEVE_RATE(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, @iSUM_TYPE) as ACHIEVE_RATE
            ,KP.KPI_GROUP_REF_ID
            ,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
            ,KI.CREATE_DATE             
            ,KI.CREATE_USER             
            ,KI.UPDATE_DATE             
            ,KI.UPDATE_USER   
        FROM BSC_KPI_INFO KI 
             LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
             LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
             LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
             LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID     = KP.KPI_POOL_REF_ID
             LEFT JOIN BSC_KPI_TERM KT
               ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
              AND KI.KPI_REF_ID     = KT.KPI_REF_ID
              AND KT.YMD            = @iYMD
             LEFT JOIN BSC_KPI_RESULT KR 
               ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
              AND KI.KPI_REF_ID     = KR.KPI_REF_ID
              AND KR.YMD            = @iYMD
             LEFT JOIN BSC_KPI_TARGET BT
               ON KR.ESTTERM_REF_ID        = BT.ESTTERM_REF_ID
              AND KR.KPI_REF_ID            = BT.KPI_REF_ID
              AND KR.YMD                   = BT.YMD
            INNER JOIN BSC_KPI_TARGET_VERSION KV
               ON BT.ESTTERM_REF_ID        = KV.ESTTERM_REF_ID
              AND BT.KPI_REF_ID            = KV.KPI_REF_ID
              AND BT.KPI_TARGET_VERSION_ID = KV.KPI_TARGET_VERSION_ID
             LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS001') CA1 
                    ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS002') CA2
                    ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS003') CA3
                    ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS004') CA4
                    ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS005') CA5
                    ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS006') CA6
                    ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS009') CA9
                    ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
             LEFT JOIN viw_EMP_COMDEPT VEE
                    ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
             LEFT JOIN COM_APPROVAL_INFO AI
                    ON KI.APP_REF_ID = AI.APP_REF_ID
                   AND AI.ACTIVE_YN = 'Y'
             LEFT OUTER JOIN BSC_KPI_GROUP_MAP KM
                    ON KM.ESTTERM_REF_ID = KI.ESTTERM_REF_ID
                   AND KM.KPI_REF_ID     = KI.KPI_REF_ID
             LEFT OUTER JOIN BSC_KPI_ISSUE_GROUP KG
                    ON KG.ESTTERM_REF_ID = KM.ESTTERM_REF_ID
                   AND KG.GROUP_CODE     = KM.GROUP_CODE
       WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
         AND KV.USE_YN         = 'Y'
         AND KI.ISDELETE       = 'N'
         AND KI.IS_TEAM_KPI    = 'Y'
         AND KI.USE_YN = 'Y'
         AND ((KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%')) OR  @iKPI_CODE  ='' )
         AND ((KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%')) OR  @iKPI_NAME  ='' )
         AND ((KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')) OR  @iKPI_GROUP_REF_ID  ='' )
         AND ((KP.KPI_EXTERNAL_TYPE LIKE ( @iKPI_EXTERNAL_TYPE + '%')) OR  @iKPI_EXTERNAL_TYPE  ='' )
         AND ((KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')) OR  @iRESULT_INPUT_TYPE  ='' )
         AND ((CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%')) OR  @iCHAMPION_NAME  ='' )
         AND ((ISNULL(KT.CHECK_YN, 'N') LIKE ( @EST_YN     + '%') ) OR  @EST_YN  ='' )
         AND VEE.COM_DEPT_REF_ID = CASE WHEN @iEST_DEPT_REF_ID < 1 THEN 
                                             VEE.COM_DEPT_REF_ID 
                                        ELSE @iEST_DEPT_REF_ID 
                                   END
         AND ((ISNULL(KG.GROUP_CODE, 0) = @GROUP_CODE ) OR @GROUP_CODE = 0)
      ) TA 
      LEFT JOIN BSC_THRESHOLD_CODE TC
        ON TA.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
WHERE TC.THRESHOLD_REF_ID = CASE WHEN (@iTHRESHOLD_REF_ID < 1 OR @iTHRESHOLD_REF_ID IS NULL) THEN TC.THRESHOLD_REF_ID
                                ELSE @iTHRESHOLD_REF_ID
                           END
ORDER BY TA.KPI_NAME
";

            if (goaltongYN.Equals("Y"))
                strQuery = strQuery.Replace("fn_BSC_KPI_ACHEVE_RATE", "fn_BSC_KPI_ACHEVE_RATE_GOAL").Replace("fn_BSC_KPI_TARGET_TS", "fn_BSC_KPI_TARGET_GOAL_TS").Replace("LEFT JOIN BSC_KPI_TARGET BT","LEFT JOIN BSC_KPI_TARGET_GOAL BT");


            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[1].Value = iymd;
            paramArray[2] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar, 20);
            paramArray[2].Value = iresult_input_type;
            paramArray[3] = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_code;
            paramArray[4] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value = ikpi_name;
            paramArray[5] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value = ichampion_name;
            paramArray[6] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iest_dept_ref_id;
            paramArray[7] = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[7].Value = ithreshold_ref_id;
            paramArray[8] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[8].Value = isum_type;
            paramArray[9] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[9].Value = ikpi_group_ref_id;
            paramArray[10] = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[10].Value = ikpi_external_type;
            paramArray[11] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[11].Value = group_code;
            paramArray[12] = CreateDataParameter("@EST_YN", SqlDbType.VarChar);
            paramArray[12].Value = estYN;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiChildList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KC";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_CHILD_LIST"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiChildTargetList(int iestterm_ref_id, int ikpi_ref_id, string ikpi_code, string ikpi_name, string ichampion_name, string ikpi_group_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CT";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ichampion_name;
            paramArray[6]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[6].Value         = ikpi_group_ref_id;
            paramArray[7]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_CHILD_TARGET"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 하위지표 결재상태
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <returns></returns>
        public bool GetKpiChildAppStatus(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;                                        

            string AppYn = Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_CHILD_APP_YN"), paramArray, CommandType.StoredProcedure));
            return (AppYn == "Y") ? true : false;
        }

        public DataSet GetKpiCodeForInsert(int iestterm_ref_id, string ikpi_code)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "EK";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value         = ikpi_code;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_EXISTS_KPICODE"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiTree(int iestterm_ref_id, int ikpi_ref_id, bool search_from_top)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KT";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iSEARCH_FROM_TOP", SqlDbType.Char, 1);
            paramArray[3].Value         = (search_from_top) ? "Y" : "N" ;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_TREE"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetDashBoardKpiList(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, string ikpi_group_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "KD";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = iresult_input_type;
            paramArray[3] = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_code;
            paramArray[4] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value = ikpi_name;
            paramArray[5] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[5].Value = iuse_yn;
            paramArray[6] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value = ichampion_name;
            paramArray[7] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iest_dept_ref_id;
            paramArray[8] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value = ikpi_group_ref_id;
            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INFO", "PKG_BSC_KPI_INFO.PROC_SELECT_KPI_DASHBOARD"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion

        public int ConfirmMBO(IDbConnection idc
                            , IDbTransaction idt
                            , object estterm_ref_id
                            , object kpi_ref_id
                            , object isconfirm)
        {
            int rtnValue = 0;
            string strQuery = @"
UPDATE BSC_KPI_INFO
SET  APPROVAL_STATUS   = @APPROVAL_STATUS
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@APPROVAL_STATUS", SqlDbType.Char);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = (DataTypeUtility.GetToBoolean(isconfirm) == true ? "Y" : "N");

            try
            {
                rtnValue = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rtnValue;
        }

        public int UseYNMBO(IDbConnection idc
                            , IDbTransaction idt
                            , object estterm_ref_id
                            , object kpi_ref_id
                            , object use_yn)
        {
            int rtnValue = 0;

            string strQuery = @"
UPDATE BSC_KPI_INFO
SET  ISDELETE   = 'N'
    ,USE_YN     = @USE_YN
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@USE_YN", SqlDbType.Char);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = use_yn;

            try
            {
                rtnValue = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rtnValue;
        }

        public int InsertMBO(IDbConnection idc
                            , IDbTransaction idt
                            , object estterm_ref_id
                            , object kpi_ref_id
                            , object kpi_code
                            , object kpi_pool_ref_id
                            , object word_definition
                            , object calc_form_ms
                            , object champion_emp_id
                            , object result_achievement_type
                            , object result_ts_calc_type
                            , object result_input_type
                            , object result_measurement_step
                            , object measurement_grade_type
                            , object unit_type_ref_id
                            , object kpi_target_version_id
                            , object kpi_target_setting_reason
                            , object kpi_target_reason_file
                            , object approval_status
                            , object excel_dnuse
                            , object create_user
                            , DataSet addDS)
        {
            int rtnValue = 0;
            int rtnCnt = 0;
            string strQuery = string.Empty;
            string strQuery2 = string.Empty;
            IDbDataParameter[] paramArray = null;
            IDbDataParameter[] paramArray2 = null;

            bool isInsert = (DataTypeUtility.GetToInt32(kpi_ref_id) == 0 ? true : false); //신규입력여부
            //신규저장 : kpi_ref_id를 -999로 모든 테이블 저장 후 id를 생성하여 Update한다.
            if (isInsert)
            {
                // 새로운 KPI ID를 부여할때 평가기간에 관계없이 KPI ID를 부여한다 즉, 삭제시 구멍 방지
                strQuery = @"
-- KPI INFO INSERT
INSERT INTO BSC_KPI_INFO    
    (ESTTERM_REF_ID,            KPI_REF_ID,             KPI_CODE,                   KPI_POOL_REF_ID,            WORD_DEFINITION
    ,CALC_FORM_MS,              CHAMPION_EMP_ID,        RESULT_INPUT_TYPE,          RESULT_ACHIEVEMENT_TYPE,    RESULT_TS_CALC_TYPE      
    ,RESULT_MEASUREMENT_STEP,   MEASUREMENT_GRADE_TYPE, UNIT_TYPE_REF_ID,           KPI_TARGET_VERSION_ID,      KPI_TARGET_SETTING_REASON
    ,KPI_TARGET_REASON_FILE,    APPROVAL_STATUS,        EXCEL_DNUSE,                IS_TEAM_KPI                 ,USE_YN
    ,CREATE_DATE,               CREATE_USER)
VALUES  
    (@ESTTERM_REF_ID,           @KPI_REF_ID,            @KPI_CODE,                  @KPI_POOL_REF_ID,           @WORD_DEFINITION
    ,@CALC_FORM_MS,             @CHAMPION_EMP_ID,       @RESULT_INPUT_TYPE,         @RESULT_ACHIEVEMENT_TYPE,   @RESULT_TS_CALC_TYPE
    ,@RESULT_MEASUREMENT_STEP,  @MEASUREMENT_GRADE_TYPE,@UNIT_TYPE_REF_ID,          @KPI_TARGET_VERSION_ID,     @KPI_TARGET_SETTING_REASON
    ,@KPI_TARGET_REASON_FILE,   @APPROVAL_STATUS,       @EXCEL_DNUSE,               @IS_TEAM_KPI,               @USE_YN
    ,GETDATE(),                 @CREATE_USER)

SELECT @RTN_KPI_REF_ID = ISNULL(MAX(KPI_REF_ID),1000)+1
FROM BSC_KPI_INFO

-- KPI TARGET VERSION INSERT
DELETE FROM BSC_KPI_TARGET_VERSION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @RTN_KPI_REF_ID
                          
INSERT INTO BSC_KPI_TARGET_VERSION
    (ESTTERM_REF_ID,        KPI_REF_ID,         KPI_TARGET_VERSION_ID,      VERSION_NAME,       VERSION_DESC         
    ,VERSION_NUMBER,        UPDATE_TERM,        USE_YN,                     CREATE_DATE,        CREATE_USER)
VALUES 
    (@ESTTERM_REF_ID,       @RTN_KPI_REF_ID,    1,                          '당초계획',         '당초계획(자동생성)'
    ,1,                     12,                 'Y',                        GETDATE(),          @CREATE_USER) 

-- KPI RESULT INSERT
DELETE FROM BSC_KPI_RESULT
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @RTN_KPI_REF_ID

INSERT INTO BSC_KPI_RESULT
    (ESTTERM_REF_ID,    KPI_REF_ID,         YMD,            RESULT_MS,      RESULT_TS       
    ,SEQUENCE,          CHECKSTATUS,        CONFIRMSTATUS,  CAL_RESULT_MS,  CAL_RESULT_TS   
    ,CAL_APPLY_YN,      CAL_APPLY_REASON,   REMARK,         APP_REF_ID,     CREATE_DATE     
    ,CREATE_USER)
SELECT  ESTTERM_REF_ID,     @RTN_KPI_REF_ID,    YMD,            0.00,           0.00
        ,CONVERT(INT, YMD), 'N',                'N',            0.00,           0.00
        ,'N',               '',                 '',             0,              GETDATE()
        ,@CREATE_USER
FROM    BSC_TERM_DETAIL
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID

UPDATE BSC_KPI_INFO
SET
    KPI_REF_ID = @RTN_KPI_REF_ID, KPI_CODE = CONVERT(VARCHAR(20), @RTN_KPI_REF_ID)
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

-- Champion Role Insert
DELETE FROM COM_EMP_ROLE_REL WHERE EMP_REF_ID = @CHAMPION_EMP_ID AND ROLE_REF_ID = 3
INSERT INTO COM_EMP_ROLE_REL (EMP_REF_ID, ROLE_REF_ID) VALUES (@CHAMPION_EMP_ID, 3)

-- 지표구분테이블에 일상업무정보 추가 BSC_MBO_KPI_CLASSIFICATION
INSERT INTO BSC_MBO_KPI_CLASSIFICATION
    (ESTTERM_REF_ID
    ,EMP_REF_ID
    ,KPI_REF_ID
    ,ORG_KPI_REF_ID
    ,KPI_CLASS_REF_ID
    ,CREATE_DATE
    ,CREATE_USER)
    VALUES
    (@ESTTERM_REF_ID
    ,@CHAMPION_EMP_ID
    ,@RTN_KPI_REF_ID
    ,@RTN_KPI_REF_ID
    ,'PRS'
    ,GETDATE()
    ,@CREATE_USER)

SELECT @RTN_KPI_REF_ID
";
                paramArray = CreateDataParameters(22);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID",                 SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID",                     SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@KPI_CODE",                       SqlDbType.VarChar);
                paramArray[3] = CreateDataParameter("@KPI_POOL_REF_ID",                SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@WORD_DEFINITION",                SqlDbType.VarChar);

                paramArray[5] = CreateDataParameter("@CALC_FORM_MS",                   SqlDbType.VarChar);
                paramArray[6] = CreateDataParameter("@CHAMPION_EMP_ID",                SqlDbType.Int);
                paramArray[7] = CreateDataParameter("@RESULT_INPUT_TYPE",              SqlDbType.VarChar);
                paramArray[8] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE",        SqlDbType.VarChar);
                paramArray[9] = CreateDataParameter("@RESULT_TS_CALC_TYPE",            SqlDbType.VarChar);
                paramArray[10] = CreateDataParameter("@RESULT_MEASUREMENT_STEP",       SqlDbType.VarChar);

                paramArray[11] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE",        SqlDbType.VarChar);
                paramArray[12] = CreateDataParameter("@UNIT_TYPE_REF_ID",              SqlDbType.Int);
                paramArray[13] = CreateDataParameter("@KPI_TARGET_VERSION_ID",         SqlDbType.VarChar);
                paramArray[14] = CreateDataParameter("@KPI_TARGET_SETTING_REASON",     SqlDbType.Text);
                paramArray[15] = CreateDataParameter("@KPI_TARGET_REASON_FILE",        SqlDbType.VarChar);

                paramArray[16] = CreateDataParameter("@APPROVAL_STATUS",               SqlDbType.Char);
                paramArray[17] = CreateDataParameter("@EXCEL_DNUSE",                   SqlDbType.Char);
                paramArray[18] = CreateDataParameter("@IS_TEAM_KPI",                   SqlDbType.Char);
                paramArray[19] = CreateDataParameter("@USE_YN",                        SqlDbType.Char);
                paramArray[20] = CreateDataParameter("@CREATE_USER",                   SqlDbType.Int);
                paramArray[21] = CreateDataParameter("@RTN_KPI_REF_ID",                SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = 0;
                paramArray[2].Value = "MicroPolis_0";
                paramArray[3].Value = kpi_pool_ref_id;         
                paramArray[4].Value = word_definition;

                paramArray[5].Value = calc_form_ms;          
                paramArray[6].Value = champion_emp_id;
                paramArray[7].Value = result_input_type;
                paramArray[8].Value = result_achievement_type;
                paramArray[9].Value = result_ts_calc_type;
                paramArray[10].Value = result_measurement_step;

                paramArray[11].Value = measurement_grade_type;
                paramArray[12].Value = unit_type_ref_id;
                paramArray[13].Value = kpi_target_version_id;
                paramArray[14].Value = kpi_target_setting_reason;
                paramArray[15].Value = kpi_target_reason_file;

                paramArray[16].Value = approval_status;
                paramArray[17].Value = excel_dnuse;
                paramArray[18].Value = "N";
                paramArray[19].Value = "Y";
                paramArray[20].Value = create_user;
                paramArray[21].Value = 0;

                try
                {
                    object rntObj = DbAgentObj.ExecuteScalar(idc, idt, strQuery, paramArray, CommandType.Text);
                    rtnValue = DataTypeUtility.GetToInt32(rntObj);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                int rtnExist = 0;
                string strExist = @"
SELECT CASE WHEN ISNULL(SUM(KPI_REF_ID), 0) > 0 THEN 1 ELSE 0 END
FROM BSC_KPI_INFO
WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND KPI_CODE       = @KPI_CODE
    AND KPI_REF_ID    != @KPI_REF_ID
";
                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID",                 SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID",                     SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@KPI_CODE",                       SqlDbType.VarChar);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = kpi_ref_id;
                paramArray[2].Value = kpi_code;

                try
                {
                    rtnExist = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strExist, paramArray, CommandType.Text));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (rtnExist > 0) // 동일한 KPI코드 존재
                    return 0;

                strQuery = @"
-- Champion Role Insert
DELETE FROM COM_EMP_ROLE_REL WHERE EMP_REF_ID = @CHAMPION_EMP_ID AND ROLE_REF_ID = 3
INSERT INTO COM_EMP_ROLE_REL (EMP_REF_ID, ROLE_REF_ID) VALUES (@CHAMPION_EMP_ID, 3)

-- KPI INFO UPDATE
UPDATE BSC_KPI_INFO
SET
     KPI_POOL_REF_ID            = @KPI_POOL_REF_ID
    ,WORD_DEFINITION            = @WORD_DEFINITION
    ,CALC_FORM_MS               = @CALC_FORM_MS
    ,CHAMPION_EMP_ID            = @CHAMPION_EMP_ID
    ,RESULT_INPUT_TYPE          = @RESULT_INPUT_TYPE
    ,RESULT_ACHIEVEMENT_TYPE    = @RESULT_ACHIEVEMENT_TYPE
    ,RESULT_TS_CALC_TYPE        = @RESULT_TS_CALC_TYPE
    ,RESULT_MEASUREMENT_STEP    = @RESULT_MEASUREMENT_STEP
    ,MEASUREMENT_GRADE_TYPE     = @MEASUREMENT_GRADE_TYPE
    ,UNIT_TYPE_REF_ID           = @UNIT_TYPE_REF_ID
    ,KPI_TARGET_VERSION_ID      = @KPI_TARGET_VERSION_ID
    ,KPI_TARGET_SETTING_REASON  = @KPI_TARGET_SETTING_REASON
    ,KPI_TARGET_REASON_FILE     = @KPI_TARGET_REASON_FILE
    ,EXCEL_DNUSE                = @EXCEL_DNUSE
    ,UPDATE_DATE                = GETDATE()
    ,UPDATE_USER                = @UPDATE_USER
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

SELECT KPI_REF_ID 
FROM BSC_KPI_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(17);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@WORD_DEFINITION", SqlDbType.VarChar);
                paramArray[4] = CreateDataParameter("@CALC_FORM_MS", SqlDbType.VarChar);

                paramArray[5] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@RESULT_INPUT_TYPE", SqlDbType.VarChar);
                paramArray[7] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
                paramArray[8] = CreateDataParameter("@RESULT_TS_CALC_TYPE", SqlDbType.VarChar);
                paramArray[9] = CreateDataParameter("@RESULT_MEASUREMENT_STEP", SqlDbType.VarChar);

                paramArray[10] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
                paramArray[11] = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
                paramArray[12] = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.VarChar);
                paramArray[13] = CreateDataParameter("@KPI_TARGET_SETTING_REASON", SqlDbType.Text);
                paramArray[14] = CreateDataParameter("@KPI_TARGET_REASON_FILE", SqlDbType.VarChar);

                paramArray[15] = CreateDataParameter("@EXCEL_DNUSE", SqlDbType.Char);
                paramArray[16] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = kpi_ref_id;
                paramArray[2].Value = kpi_pool_ref_id;
                paramArray[3].Value = word_definition;
                paramArray[4].Value = calc_form_ms;

                paramArray[5].Value = champion_emp_id;
                paramArray[6].Value = result_input_type;
                paramArray[7].Value = result_achievement_type;
                paramArray[8].Value = result_ts_calc_type;
                paramArray[9].Value = result_measurement_step;

                paramArray[10].Value = measurement_grade_type;
                paramArray[11].Value = unit_type_ref_id;
                paramArray[12].Value = kpi_target_version_id;
                paramArray[13].Value = kpi_target_setting_reason;
                paramArray[14].Value = kpi_target_reason_file;

                paramArray[15].Value = excel_dnuse;
                paramArray[16].Value = create_user;

                try
                {
                    rtnValue = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strQuery, paramArray, CommandType.Text));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (rtnValue == 0) // 수정된 내역 없음
                    return 0;

                rtnValue = DataTypeUtility.GetToInt32(kpi_ref_id);
            }
            
            if (rtnValue > 0)
            {
                // KPI DATA SOURCE(NO)
                // KPI TERM && TARGET
                DataTable rDT = addDS.Tables["BSC_KPI_TERM"];
                if (isInsert)
                {
                    strQuery = @"
INSERT INTO BSC_KPI_TERM
(ESTTERM_REF_ID,    KPI_REF_ID,     YMD,    CHECK_YN,   CREATE_DATE,    CREATE_USER)
VALUES
(@ESTTERM_REF_ID,   @KPI_REF_ID,    @YMD,   @CHECK_YN,  GETDATE(),      @CREATE_USER)
";
                }
                else
                {
                    strQuery = @"
UPDATE BSC_KPI_TERM
    SET  YMD            = @YMD        
        ,CHECK_YN       = @CHECK_YN   
		,UPDATE_DATE    = GETDATE()
		,UPDATE_USER    = @CREATE_USER
WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND KPI_REF_ID     = @KPI_REF_ID    
    AND YMD            = @YMD
";
                }

                foreach (DataRow dr in rDT.Rows)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(5);
                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                    paramArray[3] = CreateDataParameter("@CHECK_YN", SqlDbType.Char);
                    paramArray[4] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    if (isInsert)
                        paramArray[1].Value = rtnValue;
                    else
                        paramArray[1].Value = kpi_ref_id;
                    paramArray[2].Value = dr["YMD"].ToString();
                    paramArray[3].Value = dr["CHECK_YN"].ToString();
                    paramArray[4].Value = create_user;

                    rtnCnt = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);

                    paramArray2 = null;
                    paramArray2 = CreateDataParameters(10);
                    paramArray2[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
                    paramArray2[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
                    paramArray2[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
                    paramArray2[3] = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
                    paramArray2[4] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
                    paramArray2[5] = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
                    paramArray2[6] = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
                    paramArray2[7] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
                    paramArray2[8] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
                    paramArray2[9] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);

                    if (isInsert)
                    {
                        paramArray2[0].Value = "A";
                        paramArray2[2].Value = rtnValue;
                    }
                    else
                    {
                        paramArray2[0].Value = "U";
                        paramArray2[2].Value = kpi_ref_id;
                    }
                    paramArray2[1].Value = estterm_ref_id;
                    
                    paramArray2[3].Value = kpi_target_version_id;
                    paramArray2[4].Value = dr["YMD"].ToString();
                    paramArray2[5].Value = DataTypeUtility.GetToDouble(dr["MS_PLAN"]);
                    paramArray2[6].Value = DataTypeUtility.GetToDouble(dr["TS_PLAN"]);
                    paramArray2[7].Value = create_user;
                    paramArray2[8].Direction = ParameterDirection.Output;
                    paramArray2[9].Direction = ParameterDirection.Output;

                    IDataParameterCollection col;

                    int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray2, CommandType.StoredProcedure, out col);

                    //this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
                    //this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
                    string rtnMSG = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

                    if (rtnMSG == "N")
                        return 0;
                }

                ////////////////////////////////////////////////////
                // KPI THRESHOLD 
                ////////////////////////////////////////////////////

                strQuery = @"
DELETE FROM BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID   = @ESTTERM_REF_ID
AND KPI_REF_ID       = @KPI_REF_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(2);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = rtnValue;

                rtnCnt = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);

                strQuery = @"
INSERT INTO BSC_KPI_THRESHOLD_INFO
(ESTTERM_REF_ID,    KPI_REF_ID,     THRESHOLD_REF_ID,   THRESHOLD_LEVEL
,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       CREATE_DATE,    CREATE_USER)
VALUES
(@ESTTERM_REF_ID,   @KPI_REF_ID,    @THRESHOLD_REF_ID,  @THRESHOLD_LEVEL
,@SET_MIN_VALUE,    @SET_TXT_VALUE, @SET_MAX_VALUE,     @ACHIEVE_RATE,      GETDATE(),      @CREATE_USER)
";

                rDT = addDS.Tables["BSC_KPI_THRESHOLD_INFO"];
                foreach (DataRow dr in rDT.Rows)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(9);

                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
                    paramArray[4] = CreateDataParameter("@SET_MIN_VALUE", SqlDbType.Decimal);
                    paramArray[5] = CreateDataParameter("@SET_TXT_VALUE", SqlDbType.VarChar);
                    paramArray[6] = CreateDataParameter("@SET_MAX_VALUE", SqlDbType.Decimal);
                    paramArray[7] = CreateDataParameter("@ACHIEVE_RATE", SqlDbType.Decimal);
                    paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    if (isInsert)
                        paramArray[1].Value = rtnValue;
                    else
                        paramArray[1].Value = kpi_ref_id;
                    paramArray[2].Value = dr["THRESHOLD_REF_ID"];
                    paramArray[3].Value = dr["THRESHOLD_LEVEL"].ToString();
                    paramArray[4].Value = DataTypeUtility.GetToDouble(dr["SET_MIN_VALUE"]);
                    paramArray[5].Value = dr["SET_TXT_VALUE"].ToString();
                    paramArray[6].Value = DataTypeUtility.GetToDouble(dr["SET_MAX_VALUE"]);
                    paramArray[7].Value = DataTypeUtility.GetToDouble(dr["ACHIEVE_RATE"]);
                    paramArray[8].Value = create_user;

                    rtnCnt = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                }

                
                // KPI INITIATIVE
                rDT = addDS.Tables["BSC_KPI_INITIATIVE"];

                if (isInsert)
                    strQuery = @"
INSERT INTO BSC_KPI_INITIATIVE
(ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
VALUES
(@ESTTERM_REF_ID,   @KPI_REF_ID,    @YMD,           @INITIATIVE_PLAN,   @INITIATIVE_DO, @INITIATIVE_DESC,   @CREATE_USER,   GETDATE())
";
                else
                    strQuery = @"
UPDATE BSC_KPI_INITIATIVE
    SET INITIATIVE_PLAN     = @INITIATIVE_PLAN               
        , INITIATIVE_DO     = @INITIATIVE_DO                 
        , INITIATIVE_DESC   = @INITIATIVE_DESC               
        , UPDATE_USER       = @CREATE_USER
        , UPDATE_DATE       = GETDATE()                   
WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID                
    AND KPI_REF_ID    = @KPI_REF_ID                    
    AND YMD           = @YMD
";

                foreach (DataRow dr in rDT.Rows)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(7);

                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                    paramArray[3] = CreateDataParameter("@INITIATIVE_PLAN", SqlDbType.VarChar);
                    paramArray[4] = CreateDataParameter("@INITIATIVE_DO", SqlDbType.VarChar);
                    paramArray[5] = CreateDataParameter("@INITIATIVE_DESC", SqlDbType.VarChar);
                    paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    if (isInsert)
                        paramArray[1].Value = rtnValue;
                    else
                        paramArray[1].Value = kpi_ref_id;
                    paramArray[2].Value = dr["YMD"].ToString();
                    paramArray[3].Value = dr["INITIATIVE_PLAN"].ToString();
                    paramArray[4].Value = dr["INITIATIVE_DO"].ToString();
                    paramArray[5].Value = dr["INITIATIVE_DESC"].ToString();
                    paramArray[6].Value = create_user;

                    rtnCnt = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                }
                
            }
            return rtnValue;
        }

        public DataSet GetDeptKpiForMBO(int estterm_ref_id
                                            , int com_dept_ref_id
                                            , string kpi_code
                                            , string kpi_name
                                            , string champion_emp_name
                                            , int emp_ref_id
                                            , int is_admin)
        {
            string strQuery = @"
SELECT   A.KPI_CODE
        ,D.KPI_NAME
        ,E.COM_DEPT_REF_ID
        ,E.COM_DEPT_NAME
        ,C.EMP_NAME         AS CHAMPION_EMP_NAME
        ,A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,ISNULL(H.APP_STATUS, '') AS APP_STATUS
        ,E.COM_DEPT_REF_ID
        ,D.KPI_POOL_REF_ID
FROM BSC_KPI_INFO                           A
LEFT OUTER JOIN BSC_MBO_KPI_CLASSIFICATION  B   ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                                AND B.ORG_KPI_REF_ID    = A.KPI_REF_ID
                                                AND B.EMP_REF_ID        = @EMP_REF_ID
LEFT OUTER JOIN COM_EMP_INFO                C   ON  C.EMP_REF_ID        = A.CHAMPION_EMP_ID
LEFT OUTER JOIN BSC_KPI_POOL                D   ON  D.KPI_POOL_REF_ID   = A.KPI_POOL_REF_ID
LEFT OUTER JOIN viw_EMP_COMDEPT             E   ON  E.EMP_REF_ID        = A.CHAMPION_EMP_ID
LEFT OUTER JOIN COM_APPROVAL_INFO           H   ON  H.APP_REF_ID        = A.APP_REF_ID
                                                AND H.ACTIVE_YN         = 'Y'
LEFT OUTER JOIN REL_DEPT_EMP                I   ON  I.EMP_REF_ID        = @EMP_REF_ID
                                                AND I.REL_STATUS        = 1
WHERE   A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND A.ISDELETE      = 'N'
    AND A.USE_YN        = 'Y'
    AND A.IS_TEAM_KPI   = 'Y'
    AND B.KPI_REF_ID    IS NULL
/*
    AND A.KPI_CODE      LIKE    (@KPI_CODE + '%')
    AND D.KPI_NAME      LIKE    (@KPI_NAME + '%')
    AND C.EMP_NAME      LIKE    (@CHAMPION_EMP_NAME + '%')
*/

    AND (A.KPI_CODE      LIKE    (@KPI_CODE + '%') OR  @KPI_CODE  ='' )
    AND (D.KPI_NAME      LIKE    (@KPI_NAME + '%') OR  @KPI_NAME  ='' )
    AND (C.EMP_NAME      LIKE    (@CHAMPION_EMP_NAME + '%') OR  @CHAMPION_EMP_NAME  ='' )

    AND E.COM_DEPT_REF_ID = CASE WHEN @COM_DEPT_REF_ID < 1 THEN 
                                E.COM_DEPT_REF_ID
                            ELSE @COM_DEPT_REF_ID
                            END
    AND E.COM_DEPT_REF_ID = CASE WHEN @IS_ADMIN = 1 THEN 
            E.COM_DEPT_REF_ID
        ELSE
            I.DEPT_REF_ID
        END
ORDER BY LEN(A.KPI_CODE), A.KPI_CODE, E.COM_DEPT_REF_ID, C.EMP_NAME, D.KPI_NAME
";
    
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@COM_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = com_dept_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value = kpi_code;
            paramArray[3] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[3].Value = kpi_name;
            paramArray[4] = CreateDataParameter("@CHAMPION_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = champion_emp_name;
            paramArray[5] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value = emp_ref_id;
            paramArray[6] = CreateDataParameter("@IS_ADMIN", SqlDbType.Int);
            paramArray[6].Value = is_admin;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO_FOR_MBO", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetDeptMboForMBO(int estterm_ref_id
                                            , int com_dept_ref_id
                                            , string kpi_code
                                            , string kpi_name
                                            , string champion_emp_name
                                            , int emp_ref_id
                                            , int is_admin)
        {
            string strQuery = @"
SELECT   A.KPI_CODE
        ,D.KPI_NAME
        ,E.COM_DEPT_REF_ID
        ,E.COM_DEPT_NAME
        ,C.EMP_NAME         AS CHAMPION_EMP_NAME
        ,A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,'CFT' AS APP_STATUS
        ,E.COM_DEPT_REF_ID
FROM BSC_KPI_INFO                           A
INNER JOIN BSC_MBO_KPI_CLASSIFICATION  B   ON  B.ESTTERM_REF_ID         = A.ESTTERM_REF_ID
                                                AND B.KPI_REF_ID        = A.KPI_REF_ID
                                                AND B.EMP_REF_ID        <> @EMP_REF_ID
                                                AND B.KPI_CLASS_REF_ID  = 'PRS'
LEFT OUTER JOIN COM_EMP_INFO                C   ON  C.EMP_REF_ID        = A.CHAMPION_EMP_ID
LEFT OUTER JOIN BSC_KPI_POOL                D   ON  D.KPI_POOL_REF_ID   = A.KPI_POOL_REF_ID
LEFT OUTER JOIN viw_EMP_COMDEPT             E   ON  E.EMP_REF_ID        = A.CHAMPION_EMP_ID
LEFT OUTER JOIN REL_DEPT_EMP                I   ON  I.EMP_REF_ID        = @EMP_REF_ID
                                                AND I.REL_STATUS        = 1
LEFT OUTER JOIN BSC_MBO_KPI_CLASSIFICATION  F   ON  F.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                                AND F.ORG_KPI_REF_ID    = A.KPI_REF_ID
                                                AND F.EMP_REF_ID        = @EMP_REF_ID
                                                AND F.KPI_CLASS_REF_ID  = 'PRS'
WHERE   A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND A.ISDELETE      = 'N'
    AND A.USE_YN        = 'Y'
    AND A.IS_TEAM_KPI   = 'N'
    AND ISNULL(A.APPROVAL_STATUS, 'N')  = 'Y'
/*
    AND A.KPI_CODE      LIKE    (@KPI_CODE + '%')
    AND D.KPI_NAME      LIKE    (@KPI_NAME + '%')
    AND C.EMP_NAME      LIKE    (@CHAMPION_EMP_NAME + '%')
*/

    AND (A.KPI_CODE      LIKE    (@KPI_CODE + '%') OR  @KPI_CODE  ='' )
    AND (D.KPI_NAME      LIKE    (@KPI_NAME + '%') OR  @KPI_NAME  ='' )
    AND (C.EMP_NAME      LIKE    (@CHAMPION_EMP_NAME + '%') OR  @CHAMPION_EMP_NAME  ='' )

    AND E.COM_DEPT_REF_ID = CASE WHEN @COM_DEPT_REF_ID < 1 THEN 
                                E.COM_DEPT_REF_ID
                            ELSE @COM_DEPT_REF_ID
                            END
    AND E.COM_DEPT_REF_ID = CASE WHEN @IS_ADMIN = 1 THEN 
            E.COM_DEPT_REF_ID
        ELSE
            I.DEPT_REF_ID
        END
    AND F.KPI_REF_ID IS NULL
ORDER BY LEN(A.KPI_CODE), A.KPI_CODE, E.COM_DEPT_REF_ID, C.EMP_NAME, D.KPI_NAME
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@COM_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = com_dept_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[2].Value = kpi_code;
            paramArray[3] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[3].Value = kpi_name;
            paramArray[4] = CreateDataParameter("@CHAMPION_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = champion_emp_name;
            paramArray[5] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value = emp_ref_id;
            paramArray[6] = CreateDataParameter("@IS_ADMIN", SqlDbType.Int);
            paramArray[6].Value = is_admin;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO_FOR_MBO", null, paramArray, CommandType.Text);
            return ds;
        }

//        public DataSet GetMBOForDeptKpi(int estterm_ref_id
//                                        , string kpi_code
//                                        , string kpi_name
//                                        , string champion_emp_name
//                                        , string kpi_group_ref_id
//                                        , int com_dept_ref_id
//                                        , int category_top_ref_id
//                                        , int category_mid_ref_id
//                                        , int category_low_ref_id
//                                        , int emp_ref_id
//                                        , int is_admin
//                                        , int dept_id)
//        {
//            string strQueryAdd = string.Empty;
//            if (category_top_ref_id > 0)
//                strQueryAdd += "  AND D.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID";
//            if (category_mid_ref_id > 0)
//                strQueryAdd += "  AND D.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID";
//            if (category_low_ref_id > 0)
//                strQueryAdd += "  AND D.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID";
//            string strQuery = @"
//SELECT   A.KPI_CODE
//        ,D.KPI_NAME
//        ,E.COM_DEPT_REF_ID
//        ,E.COM_DEPT_NAME
//        ,C.EMP_NAME             AS CHAMPION_EMP_NAME
//        ,ISNULL(F.CODE_NAME,'') AS KPI_GROUP_NAME
//        ,G.CODE_NAME            AS CLASS_NAME
//        ,ISNULL(H.CATEGORY_NAME, ' ') + '/' + ISNULL(I.CATEGORY_NAME, ' ')  + '/' + ISNULL(J.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
//        ,ISNULL(K.UNIT, '-')    AS UNIT_NAME
//        ,A.USE_YN
//        ,ISNULL(A.APPROVAL_STATUS, 'N') AS APPROVAL_STATUS
//        ,A.ESTTERM_REF_ID
//        ,A.KPI_REF_ID
//        ,ISNULL(B.KPI_CLASS_REF_ID, '') AS KPI_CLASS_REF_ID
//        ,A.CHAMPION_EMP_ID
//        ,E.COM_DEPT_REF_ID
//        ,CASE WHEN ISNULL(B.KPI_CLASS_REF_ID, '') <> 'STG' OR ISNULL(A.APPROVAL_STATUS, 'N') = 'Y' OR A.CHAMPION_EMP_ID <> @EMP_REF_ID OR E.COM_DEPT_REF_ID <> @DEPT_ID THEN 'N' ELSE 'Y' END   AS CHECK_YN
//FROM BSC_KPI_INFO                                   A
//LEFT OUTER JOIN BSC_MBO_KPI_CLASSIFICATION          B   ON  B.ESTTERM_REF_ID        = A.ESTTERM_REF_ID
//                                                        AND B.KPI_REF_ID            = A.KPI_REF_ID
//LEFT OUTER JOIN COM_EMP_INFO                        C   ON  C.EMP_REF_ID            = A.CHAMPION_EMP_ID
//LEFT OUTER JOIN BSC_KPI_POOL                        D   ON  D.KPI_POOL_REF_ID       = A.KPI_POOL_REF_ID
//LEFT OUTER JOIN viw_EMP_COMDEPT                     E   ON  E.EMP_REF_ID            = A.CHAMPION_EMP_ID
//LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
//                    FROM COM_CODE_INFO 
//                    WHERE CATEGORY_CODE = 'BS009')  F   ON  F.ETC_CODE              = D.KPI_GROUP_REF_ID
//LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
//                    FROM COM_CODE_INFO 
//                    WHERE CATEGORY_CODE = 'BS0014')  G   ON  G.ETC_CODE              = B.KPI_CLASS_REF_ID
//LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                H   ON  H.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
//LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                I   ON  I.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
//                                                        AND I.CATEGORY_MID_REF_ID   = D.CATEGORY_MID_REF_ID
//LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                J   ON  J.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
//                                                        AND J.CATEGORY_MID_REF_ID   = D.CATEGORY_MID_REF_ID
//                                                        AND J.CATEGORY_LOW_REF_ID   = D.CATEGORY_LOW_REF_ID
//LEFT OUTER JOIN COM_UNIT_TYPE_INFO                  K   ON  K.UNIT_TYPE_REF_ID      = A.UNIT_TYPE_REF_ID
//LEFT OUTER JOIN REL_DEPT_EMP                        L   ON  L.EMP_REF_ID            = @EMP_REF_ID
//                                                        AND L.REL_STATUS            = 1
//WHERE   A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
//    AND A.IS_TEAM_KPI       = 'N'
//    AND B.KPI_REF_ID        IS NOT NULL
//    AND A.KPI_CODE          LIKE    (@KPI_CODE + '%')
//    AND D.KPI_NAME          LIKE    (@KPI_NAME + '%')
//    AND C.EMP_NAME          LIKE    (@CHAMPION_EMP_NAME + '%')
//    AND D.KPI_GROUP_REF_ID  LIKE    (@KPI_GROUP_REF_ID + '%')
//    AND E.COM_DEPT_REF_ID = CASE WHEN @COM_DEPT_REF_ID < 1 THEN 
//                                E.COM_DEPT_REF_ID
//                            ELSE @COM_DEPT_REF_ID
//                            END
//    AND E.COM_DEPT_REF_ID IN (  SELECT A2.DEPT_REF_ID
//                                FROM BSC_EMP_COM_DEPT_DETAIL A1
//                                INNER JOIN COM_DEPT_INFO A2  ON A2.DEPT_REF_ID = A1.DEPT_REF_ID
//                                WHERE A1.EMP_REF_ID     = @EMP_REF_ID)
//    AND E.COM_DEPT_REF_ID = CASE WHEN @IS_ADMIN = 1 THEN 
//            E.COM_DEPT_REF_ID
//        ELSE
//            L.DEPT_REF_ID
//        END
//    {0}
//ORDER BY E.COM_DEPT_REF_ID, C.EMP_NAME, D.KPI_NAME
//";

//            strQuery = string.Format(strQuery, strQueryAdd);
//            IDbDataParameter[] paramArray = CreateDataParameters(12);

//            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
//            paramArray[0].Value = estterm_ref_id;
//            paramArray[1] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
//            paramArray[1].Value = kpi_code;
//            paramArray[2] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
//            paramArray[2].Value = kpi_name;
//            paramArray[3] = CreateDataParameter("@CHAMPION_EMP_NAME", SqlDbType.VarChar);
//            paramArray[3].Value = champion_emp_name;
//            paramArray[4] = CreateDataParameter("@KPI_GROUP_REF_ID", SqlDbType.VarChar);
//            paramArray[4].Value = kpi_group_ref_id;
//            paramArray[5] = CreateDataParameter("@COM_DEPT_REF_ID", SqlDbType.Int);
//            paramArray[5].Value = com_dept_ref_id;
//            paramArray[6] = CreateDataParameter("@CATEGORY_TOP_REF_ID", SqlDbType.Int);
//            paramArray[6].Value = category_top_ref_id;
//            paramArray[7] = CreateDataParameter("@CATEGORY_MID_REF_ID", SqlDbType.Int);
//            paramArray[7].Value = category_mid_ref_id;
//            paramArray[8] = CreateDataParameter("@CATEGORY_LOW_REF_ID", SqlDbType.Int);
//            paramArray[8].Value = category_low_ref_id;
//            paramArray[9] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
//            paramArray[9].Value = emp_ref_id;
//            paramArray[10] = CreateDataParameter("@IS_ADMIN", SqlDbType.Int);
//            paramArray[10].Value = is_admin;
//            paramArray[11] = CreateDataParameter("@DEPT_ID", SqlDbType.Int);
//            paramArray[11].Value = dept_id;


//            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO_FOR_MBO", null, paramArray, CommandType.Text);
//            return ds;
//        }


        public DataSet GetMBOForDeptKpi(int estterm_ref_id
                                        , string kpi_code
                                        , string kpi_name
                                        , string champion_emp_name
                                        , string kpi_group_ref_id
                                        , int com_dept_ref_id
                                        , int category_top_ref_id
                                        , int category_mid_ref_id
                                        , int category_low_ref_id
                                        , int emp_ref_id
                                        , int is_admin
                                        , int dept_id)
        {
            return GetMBOForDeptKpi(estterm_ref_id
                                    , kpi_code
                                    , kpi_name
                                    , champion_emp_name
                                    , kpi_group_ref_id
                                    , com_dept_ref_id
                                    , category_top_ref_id
                                    , category_mid_ref_id
                                    , category_low_ref_id
                                    , emp_ref_id
                                    , is_admin
                                    , dept_id
                                    , "");
        }

        public DataSet GetMBOForDeptKpi(int estterm_ref_id
                                        , string kpi_code
                                        , string kpi_name
                                        , string champion_emp_name
                                        , string kpi_group_ref_id
                                        , int com_dept_ref_id
                                        , int category_top_ref_id
                                        , int category_mid_ref_id
                                        , int category_low_ref_id
                                        , int emp_ref_id
                                        , int is_admin
                                        , int dept_id
                                        , string use_yn)
        {
            //string strQueryAdd = string.Empty;
            //if (category_top_ref_id > 0)
            //    strQueryAdd += "  AND D.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID";
            //if (category_mid_ref_id > 0)
            //    strQueryAdd += "  AND D.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID";
            //if (category_low_ref_id > 0)
            //    strQueryAdd += "  AND D.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID";
            string strQuery = @"
SELECT   A.KPI_CODE
        ,D.KPI_NAME
        ,E.COM_DEPT_REF_ID
        ,E.COM_DEPT_NAME
        ,C.EMP_NAME             AS CHAMPION_EMP_NAME
        ,ISNULL(F.CODE_NAME,'') AS KPI_GROUP_NAME
        ,G.CODE_NAME            AS CLASS_NAME
        ,ISNULL(H.CATEGORY_NAME, ' ') + '/' + ISNULL(I.CATEGORY_NAME, ' ')  + '/' + ISNULL(J.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(K.UNIT, '-')    AS UNIT_NAME
        ,A.USE_YN
        ,ISNULL(A.APPROVAL_STATUS, 'N') AS APPROVAL_STATUS
        ,A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,ISNULL(B.KPI_CLASS_REF_ID, '') AS KPI_CLASS_REF_ID
        ,A.CHAMPION_EMP_ID
        ,E.COM_DEPT_REF_ID
        ,CASE WHEN ISNULL(B.KPI_CLASS_REF_ID, '') <> 'STG' OR ISNULL(A.APPROVAL_STATUS, 'N') = 'Y' OR A.CHAMPION_EMP_ID <> @EMP_REF_ID OR E.COM_DEPT_REF_ID <> @DEPT_ID THEN 'N' ELSE 'Y' END   AS CHECK_YN
        ,D.KPI_POOL_REF_ID 
        ,A.IS_TEAM_KPI
        ,GG.CODE_NAME
FROM BSC_KPI_INFO                                   A
LEFT OUTER JOIN BSC_MBO_KPI_CLASSIFICATION          B   ON  B.ESTTERM_REF_ID        = A.ESTTERM_REF_ID
                                                        AND B.KPI_REF_ID            = A.KPI_REF_ID
LEFT OUTER JOIN COM_EMP_INFO                        C   ON  C.EMP_REF_ID            = A.CHAMPION_EMP_ID
LEFT OUTER JOIN BSC_KPI_POOL                        D   ON  D.KPI_POOL_REF_ID       = A.KPI_POOL_REF_ID
LEFT OUTER JOIN viw_EMP_COMDEPT                     E   ON  E.EMP_REF_ID            = A.CHAMPION_EMP_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  F   ON  F.ETC_CODE              = D.KPI_GROUP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014')  G   ON  G.ETC_CODE              = B.KPI_CLASS_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014')  GG   ON  GG.ETC_CODE              = B.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                H   ON  H.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                I   ON  I.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
                                                        AND I.CATEGORY_MID_REF_ID   = D.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                J   ON  J.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
                                                        AND J.CATEGORY_MID_REF_ID   = D.CATEGORY_MID_REF_ID
                                                        AND J.CATEGORY_LOW_REF_ID   = D.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO                  K   ON  K.UNIT_TYPE_REF_ID      = A.UNIT_TYPE_REF_ID
LEFT OUTER JOIN REL_DEPT_EMP                        L   ON  L.EMP_REF_ID            = @EMP_REF_ID
                                                        AND L.REL_STATUS            = 1
WHERE   A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND A.IS_TEAM_KPI       = 'N'
    AND B.KPI_REF_ID        IS NOT NULL
/*
    AND A.KPI_CODE          LIKE    (@KPI_CODE + '%')
    AND D.KPI_NAME          LIKE    (@KPI_NAME + '%')
    AND C.EMP_NAME          LIKE    (@CHAMPION_EMP_NAME + '%')
    AND D.KPI_GROUP_REF_ID  LIKE    (@KPI_GROUP_REF_ID + '%')
*/
    AND (A.KPI_CODE      LIKE    (@KPI_CODE + '%') OR  @KPI_CODE  ='' )
    AND (D.KPI_NAME      LIKE    (@KPI_NAME + '%') OR  @KPI_NAME  ='' )
    AND (C.EMP_NAME      LIKE    (@CHAMPION_EMP_NAME + '%') OR  @CHAMPION_EMP_NAME  ='' )
    AND (D.KPI_GROUP_REF_ID  LIKE    (@KPI_GROUP_REF_ID + '%') OR  @KPI_GROUP_REF_ID  ='' )

    AND E.COM_DEPT_REF_ID = CASE WHEN @COM_DEPT_REF_ID < 1 THEN 
                                E.COM_DEPT_REF_ID
                            ELSE @COM_DEPT_REF_ID
                            END
    AND E.COM_DEPT_REF_ID IN (  SELECT A2.DEPT_REF_ID
                                FROM BSC_EMP_COM_DEPT_DETAIL A1
                                INNER JOIN COM_DEPT_INFO A2  ON A2.DEPT_REF_ID = A1.DEPT_REF_ID
                                WHERE A1.EMP_REF_ID     = @EMP_REF_ID)
    AND E.COM_DEPT_REF_ID = CASE WHEN @IS_ADMIN = 1 THEN 
            E.COM_DEPT_REF_ID
        ELSE
            L.DEPT_REF_ID
        END
    AND (D.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID   OR  @CATEGORY_TOP_REF_ID = 0)
    AND (D.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID   OR  @CATEGORY_MID_REF_ID = 0)
    AND (D.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID   OR  @CATEGORY_LOW_REF_ID = 0)
    AND (A.USE_YN    =   @USE_YN    OR  @USE_YN ='')
ORDER BY E.COM_DEPT_REF_ID, C.EMP_NAME, D.KPI_NAME
";

            

            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[1].Value = kpi_code;
            paramArray[2] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[2].Value = kpi_name;
            paramArray[3] = CreateDataParameter("@CHAMPION_EMP_NAME", SqlDbType.VarChar);
            paramArray[3].Value = champion_emp_name;
            paramArray[4] = CreateDataParameter("@KPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[4].Value = kpi_group_ref_id;
            paramArray[5] = CreateDataParameter("@COM_DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = com_dept_ref_id;
            
            paramArray[6] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[6].Value = emp_ref_id;
            paramArray[7] = CreateDataParameter("@IS_ADMIN", SqlDbType.Int);
            paramArray[7].Value = is_admin;
            paramArray[8] = CreateDataParameter("@DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = dept_id;

            paramArray[9] = CreateDataParameter("@CATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[9].Value = category_top_ref_id;
            paramArray[10] = CreateDataParameter("@CATEGORY_MID_REF_ID", SqlDbType.Int);
            paramArray[10].Value = category_mid_ref_id;
            paramArray[11] = CreateDataParameter("@CATEGORY_LOW_REF_ID", SqlDbType.Int);
            paramArray[11].Value = category_low_ref_id;

            paramArray[12] = CreateDataParameter("@USE_YN", SqlDbType.NVarChar);
            paramArray[12].Value = use_yn;


            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO_FOR_MBO", null, paramArray, CommandType.Text);
            return ds;
        }


        public bool CopyKpiToMbo(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object[] objList
                                , object emp_ref_id
                                , object estYear
                                , object class_type)
        {
            int affectedRow = 0;
            int tranValue = 0;
            string strQuery1 = string.Empty;
            string strQuery2 = string.Empty;
            string strQuery3 = string.Empty;
            string strQuery4 = string.Empty;
            string strQuery5 = string.Empty;
            string strQuery6 = string.Empty;

            strQuery1 = @"
SELECT  ESTTERM_REF_ID
FROM    BSC_MBO_KPI_CLASSIFICATION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND EMP_REF_ID      = @EMP_REF_ID
    AND ORG_KPI_REF_ID  = @ORG_KPI_REF_ID
";
            IDbDataParameter[] paramArray;
            for (int i = 0; i < objList.Length; i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(3);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = emp_ref_id;
                paramArray[2].Value = DataTypeUtility.GetToInt32(objList[i]);

                if (DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strQuery1, paramArray, CommandType.Text)) > 0)
                {
                    this.Transaction_Message = "이미 MBO에 등록된 조직KPI입니다.";
                    return false;
                }
            }

            // 새로운 KPI ID를 부여할때 평가기간에 관계없이 KPI ID를 부여한다 즉, 삭제시 구멍 방지
            strQuery1 = @"
-- KPI INFO COPY
INSERT INTO BSC_KPI_INFO    
    (ESTTERM_REF_ID,            KPI_REF_ID,             KPI_CODE,                   KPI_POOL_REF_ID,            WORD_DEFINITION
    ,CALC_FORM_MS,              CHAMPION_EMP_ID,        RESULT_INPUT_TYPE,          RESULT_ACHIEVEMENT_TYPE,    RESULT_TS_CALC_TYPE      
    ,RESULT_MEASUREMENT_STEP,   MEASUREMENT_GRADE_TYPE, UNIT_TYPE_REF_ID,           KPI_TARGET_VERSION_ID,      KPI_TARGET_SETTING_REASON
    ,KPI_TARGET_REASON_FILE,    APPROVAL_STATUS,        EXCEL_DNUSE,                IS_TEAM_KPI                 ,USE_YN
    ,CREATE_DATE,               CREATE_USER)
SELECT
    @ESTTERM_REF_ID,            @KPI_REF_ID,            @KPI_CODE,                  KPI_POOL_REF_ID,            WORD_DEFINITION
    ,CALC_FORM_MS,              @EMP_REF_ID,            RESULT_INPUT_TYPE,          RESULT_ACHIEVEMENT_TYPE,    RESULT_TS_CALC_TYPE
    ,RESULT_MEASUREMENT_STEP,   MEASUREMENT_GRADE_TYPE, UNIT_TYPE_REF_ID,           '1',                        KPI_TARGET_SETTING_REASON
    ,'',                        'N',                    EXCEL_DNUSE,                'N',                        'Y'
    ,GETDATE(),                 @EMP_REF_ID
FROM    BSC_KPI_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID

-- MAX KPI_REF_ID
SELECT @RTN_KPI_REF_ID = ISNULL(MAX(KPI_REF_ID),1000)+1
FROM BSC_KPI_INFO

-- KPI TARGET VERSION INSERT
DELETE FROM BSC_KPI_TARGET_VERSION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @RTN_KPI_REF_ID
                          
INSERT INTO BSC_KPI_TARGET_VERSION
    (ESTTERM_REF_ID,        KPI_REF_ID,         KPI_TARGET_VERSION_ID,      VERSION_NAME,       VERSION_DESC         
    ,VERSION_NUMBER,        UPDATE_TERM,        USE_YN,                     CREATE_DATE,        CREATE_USER)
VALUES 
    (@ESTTERM_REF_ID,       @RTN_KPI_REF_ID,    1,                          '당초계획',         '당초계획(자동생성)'
    ,1,                     12,                 'Y',                        GETDATE(),          @EMP_REF_ID) 

-- KPI RESULT INSERT
DELETE FROM BSC_KPI_RESULT
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @RTN_KPI_REF_ID

INSERT INTO BSC_KPI_RESULT
    (ESTTERM_REF_ID,    KPI_REF_ID,         YMD,            RESULT_MS,      RESULT_TS       
    ,SEQUENCE,          CHECKSTATUS,        CONFIRMSTATUS,  CAL_RESULT_MS,  CAL_RESULT_TS   
    ,CAL_APPLY_YN,      CAL_APPLY_REASON,   REMARK,         APP_REF_ID,     CREATE_DATE     
    ,CREATE_USER)
SELECT  ESTTERM_REF_ID,     @RTN_KPI_REF_ID,    YMD,            0.00,           0.00
        ,CONVERT(INT, YMD), 'N',                'N',            0.00,           0.00
        ,'N',               '',                 '',             0,              GETDATE()
        ,@EMP_REF_ID
FROM    BSC_TERM_DETAIL
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID

UPDATE BSC_KPI_INFO
SET
    KPI_REF_ID = @RTN_KPI_REF_ID, KPI_CODE = CONVERT(VARCHAR(20), @RTN_KPI_REF_ID)
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

-- Champion Role Insert
DELETE FROM COM_EMP_ROLE_REL WHERE EMP_REF_ID = @EMP_REF_ID AND ROLE_REF_ID = 3
INSERT INTO COM_EMP_ROLE_REL (EMP_REF_ID, ROLE_REF_ID) VALUES (@EMP_REF_ID, 3)

-- 지표구분테이블에 일상업무정보 추가 BSC_MBO_KPI_CLASSIFICATION
INSERT INTO BSC_MBO_KPI_CLASSIFICATION
    (ESTTERM_REF_ID,        EMP_REF_ID,         KPI_REF_ID,         ORG_KPI_REF_ID
    ,KPI_CLASS_REF_ID,      CREATE_DATE,        CREATE_USER)
    VALUES
    (@ESTTERM_REF_ID,       @EMP_REF_ID,        @RTN_KPI_REF_ID,    @ORG_KPI_REF_ID
    ,@CLASS_TYPE,                 GETDATE(),          @EMP_REF_ID)

SELECT @RTN_KPI_REF_ID
";

            strQuery2 = @"
INSERT INTO BSC_KPI_TERM
    (ESTTERM_REF_ID,    KPI_REF_ID,     YMD,    CHECK_YN,   CREATE_DATE,    CREATE_USER)
SELECT
    @ESTTERM_REF_ID,   @KPI_REF_ID,     YMD,    CHECK_YN,   GETDATE(),      @EMP_REF_ID
FROM    BSC_KPI_TERM
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            strQuery3 = @"
DELETE FROM BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID   = @ESTTERM_REF_ID
    AND KPI_REF_ID       = @KPI_REF_ID
";
            strQuery4 = @"
INSERT INTO BSC_KPI_THRESHOLD_INFO
    (ESTTERM_REF_ID,    KPI_REF_ID,     THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       CREATE_DATE,    CREATE_USER)
SELECT
    @ESTTERM_REF_ID,    @KPI_REF_ID,    THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,0,                 '',             0,                  0,                  GETDATE(),      @EMP_REF_ID
FROM    BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";
            if (class_type.ToString() == "PRS")
                strQuery4 = @"
INSERT INTO BSC_KPI_THRESHOLD_INFO
    (ESTTERM_REF_ID,    KPI_REF_ID,     THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       CREATE_DATE,    CREATE_USER)
SELECT
    @ESTTERM_REF_ID,    @KPI_REF_ID,    THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       GETDATE(),      @EMP_REF_ID
FROM    BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            strQuery5 = @"
INSERT INTO BSC_KPI_INITIATIVE
    (ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
VALUES
    (@ESTTERM_REF_ID,   @KPI_REF_ID,    @YMD,           '',                 '',             '',                 @EMP_REF_ID,    GETDATE())
";
            if (class_type.ToString() == "PRS")
                strQuery5 = @"
INSERT INTO BSC_KPI_INITIATIVE
        (ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
SELECT  @ESTTERM_REF_ID,   @KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    @EMP_REF_ID,    GETDATE()
FROM    BSC_KPI_INITIATIVE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            strQuery6 = @"
INSERT INTO BSC_KPI_TARGET
        (ESTTERM_REF_ID, KPI_REF_ID, KPI_TARGET_VERSION_ID, YMD, TARGET_MS, TARGET_TS, CREATE_DATE, CREATE_USER)
    SELECT
         ESTTERM_REF_ID, @KPI_REF_ID, KPI_TARGET_VERSION_ID, YMD, TARGET_MS, TARGET_TS, GETDATE(), @EMP_REF_ID
    FROM BSC_KPI_TARGET
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            for (int i = 0; i < objList.Length; i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(7);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
                paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[4] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                paramArray[5] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);
                paramArray[6] = CreateDataParameter("@CLASS_TYPE", SqlDbType.VarChar);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = 0;
                paramArray[2].Value = "MicroPolis_0";
                paramArray[3].Value = emp_ref_id;
                paramArray[4].Value = DataTypeUtility.GetToInt32(objList[i]);
                paramArray[5].Value = 0;
                paramArray[6].Value = class_type;

                try
                {
                    object rtnObj = DbAgentObj.ExecuteScalar(idc, idt, strQuery1, paramArray, CommandType.Text);
                    tranValue = DataTypeUtility.GetToInt32(rtnObj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (tranValue > 0)
                {
                    // KPI DATA SOURCE(NO)
                    // KPI TERM && TARGET

                    paramArray = null;
                    paramArray = CreateDataParameters(4);
                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    paramArray[1].Value = tranValue;
                    paramArray[2].Value = DataTypeUtility.GetToInt32(objList[i]);
                    paramArray[3].Value = emp_ref_id;

                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery2, paramArray, CommandType.Text);

                    if (affectedRow != 12)
                    {
                        this.Transaction_Message = "계획일정 저장중 오류가 발생하였습니다.";
                        return false;
                    }

                    if (class_type.ToString() == "PRS")
                    {
                        paramArray = null;
                        paramArray = CreateDataParameters(4);
                        paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                        paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                        paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                        paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                        paramArray[0].Value = estterm_ref_id;
                        paramArray[1].Value = tranValue;
                        paramArray[2].Value = DataTypeUtility.GetToInt32(objList[i]);
                        paramArray[3].Value = emp_ref_id;

                        affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery6, paramArray, CommandType.Text);
                    }
                    else
                    {
                        for (int j = 1; j < 13; j++)
                        {
                            paramArray = null;
                            paramArray = CreateDataParameters(10);
                            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
                            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
                            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
                            paramArray[3] = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
                            paramArray[4] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
                            paramArray[5] = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
                            paramArray[6] = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
                            paramArray[7] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
                            paramArray[8] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
                            paramArray[9] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);

                            paramArray[0].Value = "A";
                            paramArray[1].Value = estterm_ref_id;
                            paramArray[2].Value = tranValue;
                            paramArray[3].Value = 1;
                            paramArray[4].Value = estYear.ToString() + ("0" + j.ToString()).Substring((j.ToString().Length == 1 ? 0 : 1), 2);
                            paramArray[5].Value = 0;
                            paramArray[6].Value = 0;
                            paramArray[7].Value = emp_ref_id;
                            paramArray[8].Direction = ParameterDirection.Output;
                            paramArray[9].Direction = ParameterDirection.Output;

                            IDataParameterCollection col;
                            affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

                            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
                            //this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
                            string rtnMSG = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

                            if (rtnMSG == "N")
                                return false;
                        }
                    }

                    ////////////////////////////////////////////////////
                    // KPI THRESHOLD 
                    ////////////////////////////////////////////////////

                    paramArray = null;
                    paramArray = CreateDataParameters(2);
                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[0].Value = estterm_ref_id;
                    paramArray[1].Value = tranValue;

                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery3, paramArray, CommandType.Text);

                    paramArray = null;
                    paramArray = CreateDataParameters(4);

                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    paramArray[1].Value = tranValue;
                    paramArray[2].Value = emp_ref_id;
                    paramArray[3].Value = DataTypeUtility.GetToInt32(objList[i]);

                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery4, paramArray, CommandType.Text);

                    // KPI INITIATIVE

                    if (class_type.ToString() == "PRS")
                    {
                        paramArray = null;
                        paramArray = CreateDataParameters(4);

                        paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                        paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                        paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                        paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                        paramArray[0].Value = estterm_ref_id;
                        paramArray[1].Value = tranValue;
                        paramArray[2].Value = DataTypeUtility.GetToInt32(objList[i]);
                        paramArray[3].Value = emp_ref_id;

                        affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery5, paramArray, CommandType.Text);
                    }
                    else
                    {
                        affectedRow = 0;
                        for (int j = 1; j < 13; j++)
                        {
                            paramArray = null;
                            paramArray = CreateDataParameters(4);

                            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                            paramArray[0].Value = estterm_ref_id;
                            paramArray[1].Value = tranValue;
                            paramArray[2].Value = estYear.ToString() + ("0" + j.ToString()).Substring((j.ToString().Length == 1 ? 0 : 1), 2);
                            paramArray[3].Value = emp_ref_id;

                            affectedRow += DbAgentObj.ExecuteNonQuery(idc, idt, strQuery5, paramArray, CommandType.Text);
                        }
                    }
                }
                else
                {
                    this.Transaction_Message = "KPI ID를 생성하지 못하였습니다.";
                    return false;
                }
            }

            if (tranValue > 0)
                return true;
            else
                return false;
        }

        public bool DeleteMboToKpi(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object[] objList
                                , object emp_ref_id)
        {
            int affectedRow = 0;
            string strQuery = string.Empty;

            strQuery = @"
SELECT  ESTTERM_REF_ID
FROM    BSC_KPI_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
    AND APPROVAL_STATUS = 'Y'
";
            IDbDataParameter[] paramArray;
            for (int i = 0; i < objList.Length; i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(2);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = DataTypeUtility.GetToInt32(objList[i]);

                if (DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strQuery, paramArray, CommandType.Text)) > 0)
                {
                    this.Transaction_Message = "이미 확정된 MBO입니다.";
                    return false;
                }
            }

            strQuery = @"
-- KPI INFO DELETE
DELETE FROM BSC_KPI_INFO    
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

-- KPI TARGET VERSION DELETE
DELETE FROM BSC_KPI_TARGET_VERSION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @KPI_REF_ID
                          
-- KPI RESULT DELETE
DELETE FROM BSC_KPI_RESULT
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @KPI_REF_ID

-- KPI DATA SOURCE(NO)
-- KPI TERM DELETE
DELETE FROM BSC_KPI_TERM
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

-- KPI TARGET DELETE
DELETE FROM BSC_KPI_TARGET
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

--THRESHOLD DELETE
DELETE FROM BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID   = @ESTTERM_REF_ID
    AND KPI_REF_ID       = @KPI_REF_ID

--INITIATIVE DELETE
DELETE FROM BSC_KPI_INITIATIVE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

-- 지표구분테이블에 전략업무삭제한 이력 남김
DELETE FROM BSC_MBO_KPI_CLASSIFICATION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";

            for (int i = 0; i < objList.Length; i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = DataTypeUtility.GetToInt32(objList[i]);
                paramArray[2].Value = emp_ref_id;

                try
                {
                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);
                    if (affectedRow < 1)
                    {
                        this.Transaction_Message = "삭제할 KPI정보가 없습니다.";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return true;
        }

        public DataSet GetMBOForWeight(int estterm_ref_id
                                        , string kpi_code
                                        , string kpi_name
                                        , string champion_emp_name
                                        , int com_dept_ref_id
                                        , string kpi_group_ref_id
                                        , string mbo_type
                                        , int category_top_ref_id
                                        , int category_mid_ref_id
                                        , int category_low_ref_id
                                        , int emp_ref_id
                                        , bool isAdmin)
        {
            string strQueryAdd = string.Empty;
            //if (category_top_ref_id > 0)
            //    strQueryAdd += "  AND D.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID";
            //if (category_mid_ref_id > 0)
            //    strQueryAdd += "  AND D.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID";
            //if (category_low_ref_id > 0)
            //    strQueryAdd += "  AND D.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID";

            if (!isAdmin)
                strQueryAdd += "    AND A.EMP_REF_ID    = @EMP_REF_ID";
            string strQuery = @"
SELECT   AA.KPI_CODE
        ,E.COM_DEPT_NAME
        ,D.KPI_NAME
        ,C.EMP_NAME             AS CHAMPION_EMP_NAME
        ,ISNULL(F.CODE_NAME,'') AS KPI_GROUP_NAME
        ,G.CODE_NAME            AS CLASS_NAME
        ,ISNULL(H.CATEGORY_NAME, ' ') + '/' + ISNULL(I.CATEGORY_NAME, ' ')  + '/' + ISNULL(J.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(K.UNIT, '-')    AS UNIT_NAME
        ,ISNULL(A.WEIGHT, 0)      AS WEIGHT
        ,CASE WHEN ISNULL(AA.IS_TEAM_KPI, 'N') = 'Y' THEN
            CASE WHEN ISNULL(O.APP_STATUS, '') = 'CFT' THEN 'Y' ELSE 'N' END
         ELSE
            ISNULL(AA.APPROVAL_STATUS, 'N')
         END AS APPROVAL_STATUS
        ,A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,ISNULL(B.KPI_CLASS_REF_ID, '') AS KPI_CLASS_REF_ID
        ,AA.IS_TEAM_KPI
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '01' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH01
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '02' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH02
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '03' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH03
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '04' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH04
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '05' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH05
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '06' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH06
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '07' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH07
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '08' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH08
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '09' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH09
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '10' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH10
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '11' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH11
        ,SUM(ISNULL(CASE WHEN SUBSTRING(N.YMD, 5, 2) = '12' THEN N.TARGET_TS ELSE 0 END, 0)) AS MONTH12
FROM BSC_MBO_KPI_WEIGHT                             A
INNER JOIN BSC_KPI_INFO                             AA  ON  AA.ESTTERM_REF_ID       = A.ESTTERM_REF_ID
                                                        --AND AA.CHAMPION_EMP_ID           = CASE WHEN AA.IS_TEAM_KPI = 'Y' THEN AA.CHAMPION_EMP_ID ELSE A.EMP_REF_ID END
                                                        AND AA.KPI_REF_ID           = A.KPI_REF_ID
                                                        AND AA.USE_YN               = 'Y'
LEFT OUTER JOIN BSC_MBO_KPI_CLASSIFICATION          B   ON  B.ESTTERM_REF_ID        = A.ESTTERM_REF_ID
                                                        AND B.KPI_REF_ID            = A.KPI_REF_ID
                                                        AND B.EMP_REF_ID            = A.EMP_REF_ID
LEFT OUTER JOIN COM_EMP_INFO                        C   ON  C.EMP_REF_ID            = A.EMP_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL                        D   ON  D.KPI_POOL_REF_ID       = AA.KPI_POOL_REF_ID
LEFT OUTER JOIN viw_EMP_COMDEPT                     E   ON  E.EMP_REF_ID            = A.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  F   ON  F.ETC_CODE              = D.KPI_GROUP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014')  G   ON  G.ETC_CODE              = B.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                H   ON  H.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                I   ON  I.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
                                                        AND I.CATEGORY_MID_REF_ID   = D.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                J   ON  J.CATEGORY_TOP_REF_ID   = D.CATEGORY_TOP_REF_ID
                                                        AND J.CATEGORY_MID_REF_ID   = D.CATEGORY_MID_REF_ID
                                                        AND J.CATEGORY_LOW_REF_ID   = D.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO                  K   ON  K.UNIT_TYPE_REF_ID      = AA.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION              M   ON  M.ESTTERM_REF_ID        = AA.ESTTERM_REF_ID
                                                        AND M.KPI_REF_ID            = AA.KPI_REF_ID
                                                        AND M.USE_YN                = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET                      N   ON  N.ESTTERM_REF_ID        = M.ESTTERM_REF_ID
                                                        AND N.KPI_REF_ID            = M.KPI_REF_ID
                                                        AND N.KPI_TARGET_VERSION_ID = M.KPI_TARGET_VERSION_ID
LEFT OUTER JOIN COM_APPROVAL_INFO                   O   ON  O.APP_REF_ID            = AA.APP_REF_ID
                                                        AND O.ACTIVE_YN             = 'Y'
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.USE_YN            = 'Y'
    --AND (AA.IS_TEAM_KPI = 'Y' OR (AA.IS_TEAM_KPI = 'N' AND ISNULL(AA.APPROVAL_STATUS, 'N') = 'Y'))
/*    
    AND (B.KPI_CLASS_REF_ID  = @MBO_TYPE    OR @MBO_TYPE        =''    )
    AND AA.KPI_CODE         LIKE    (@KPI_CODE + '%')
    AND D.KPI_NAME          LIKE    (@KPI_NAME + '%')
    AND C.EMP_NAME          LIKE    (@CHAMPION_EMP_NAME + '%')
    AND D.KPI_GROUP_REF_ID  LIKE    (@KPI_GROUP_REF_ID + '%')
*/

    AND (B.KPI_CLASS_REF_ID  LIKE    (@MBO_TYPE + '%') OR  @MBO_TYPE  ='' )
    AND (AA.KPI_CODE         LIKE    (@KPI_CODE + '%') OR  @KPI_CODE  ='' )
    AND (D.KPI_NAME          LIKE    (@KPI_NAME + '%') OR  @KPI_NAME  ='' )
    AND (C.EMP_NAME          LIKE    (@CHAMPION_EMP_NAME + '%') OR  @CHAMPION_EMP_NAME  ='' )
    AND (D.KPI_GROUP_REF_ID  LIKE    (@KPI_GROUP_REF_ID + '%') OR  @KPI_GROUP_REF_ID  ='' )


    AND E.COM_DEPT_REF_ID = CASE WHEN @COM_DEPT_REF_ID < 1 THEN 
                                E.COM_DEPT_REF_ID
                            ELSE @COM_DEPT_REF_ID
                            END
    AND (D.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID   OR  @CATEGORY_TOP_REF_ID = 0)
    AND (D.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID   OR  @CATEGORY_MID_REF_ID = 0)
    AND (D.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID   OR  @CATEGORY_LOW_REF_ID = 0)
{0}
GROUP BY AA.KPI_CODE
        ,E.COM_DEPT_NAME
        ,D.KPI_NAME
        ,C.EMP_NAME
        ,ISNULL(F.CODE_NAME,'')
        ,G.CODE_NAME
        ,ISNULL(H.CATEGORY_NAME, ' ') + '/' + ISNULL(I.CATEGORY_NAME, ' ')  + '/' + ISNULL(J.CATEGORY_NAME, ' ')
        ,ISNULL(K.UNIT, '-')
        ,ISNULL(A.WEIGHT, 0)
        ,CASE WHEN ISNULL(AA.IS_TEAM_KPI, 'N') = 'Y' THEN
            CASE WHEN ISNULL(O.APP_STATUS, '') = 'CFT' THEN 'Y' ELSE 'N' END
         ELSE
            ISNULL(AA.APPROVAL_STATUS, 'N')
         END
        ,A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,ISNULL(B.KPI_CLASS_REF_ID, '')
        ,AA.IS_TEAM_KPI
        ,E.COM_DEPT_REF_ID
ORDER BY E.COM_DEPT_REF_ID, C.EMP_NAME, D.KPI_NAME

";

            int paramCnt = 10;

            if (!isAdmin)
                paramCnt++;

            strQuery = string.Format(strQuery, strQueryAdd);
            IDbDataParameter[] paramArray = CreateDataParameters(paramCnt);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[1].Value = kpi_code;
            paramArray[2] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[2].Value = kpi_name;
            paramArray[3] = CreateDataParameter("@CHAMPION_EMP_NAME", SqlDbType.VarChar);
            paramArray[3].Value = champion_emp_name;
            paramArray[4] = CreateDataParameter("@KPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[4].Value = kpi_group_ref_id;
            paramArray[5] = CreateDataParameter("@COM_DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = com_dept_ref_id;
            paramArray[6] = CreateDataParameter("@CATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[6].Value = category_top_ref_id;
            paramArray[7] = CreateDataParameter("@CATEGORY_MID_REF_ID", SqlDbType.Int);
            paramArray[7].Value = category_mid_ref_id;
            paramArray[8] = CreateDataParameter("@CATEGORY_LOW_REF_ID", SqlDbType.Int);
            paramArray[8].Value = category_low_ref_id;
            
            paramArray[9] = CreateDataParameter("@MBO_TYPE", SqlDbType.VarChar);
            paramArray[9].Value = mbo_type;

            if (!isAdmin)
            {
                paramArray[10] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[10].Value = emp_ref_id;
            }

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO_FOR_MBO", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet GetMBOForWeight_Approval(int estterm_ref_id
                                              , int emp_ref_id)
        {
            string query = @"
--결재상태
SELECT   ISNULL(B.APP_STATUS,'NFT') AS APP_STATUS
        ,ISNULL(C.CODE_NAME,'')     AS APP_STATUS_NAME
        ,ISNULL(A.APP_REF_ID, 0)    AS APP_REF_ID
FROM                BSC_MBO_KPI_TARGET_AGREEMENT    A
LEFT OUTER JOIN     COM_APPROVAL_INFO               B   ON  B.APP_REF_ID    = A.APP_REF_ID     
                                                        AND B.ACTIVE_YN     = 'Y'
LEFT OUTER JOIN     (   SELECT ETC_CODE, CODE_NAME
                        FROM COM_CODE_INFO 
                        WHERE CATEGORY_CODE = 'CM002') C  ON C.ETC_CODE     = B.APP_STATUS
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EMP_REF_ID        = @EMP_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "BSC_KPI_INFO_FOR_MBO_APP", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetMboListForResultInput(object estterm_ref_id
                                                , object ymd
                                                , object kpi_code
                                                , object kpi_name
                                                , object champion_emp_name
                                                , object dept_ref_id
                                                , object kpi_group_ref_id
                                                , object category_top_ref_id
                                                , object category_mid_ref_id
                                                , object category_low_ref_id
                                                , object emp_ref_id
                                                , object isadmin
                                                , object isteammanager
                                                , object user_dept_ref_id)
        {
            string strQueryAdd = string.Empty;
            //if (DataTypeUtility.GetToInt32(category_top_ref_id) > 0)
            //    strQueryAdd += "  AND C.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID";
            //if (DataTypeUtility.GetToInt32(category_mid_ref_id) > 0)
            //    strQueryAdd += "  AND C.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID";
            //if (DataTypeUtility.GetToInt32(category_low_ref_id) > 0)
            //    strQueryAdd += "  AND C.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID";

            if (!(bool)isadmin)
            {
                if (!(bool)isteammanager)
                {
                    strQueryAdd += "    AND A.CHAMPION_EMP_ID   = @EMP_REF_ID";
                }
                else
                {
//                    strQueryAdd += @"
//    AND A.CHAMPION_EMP_ID IN (
//            SELECT DISTINCT B.EMP_REF_ID
//            FROM FN_COM_DEPT_INFO_BYTREE(@USER_DEPT_REF_ID) A
//            LEFT OUTER JOIN REL_DEPT_EMP B ON B.DEPT_REF_ID = A.DEPT_ID
//        )
//";
                    strQueryAdd += @"
    AND A.CHAMPION_EMP_ID IN (
            SELECT EMP_REF_ID FROM REL_DEPT_EMP 
             WHERE DEPT_REF_ID = :USER_DEPT_REF_ID
        )
";

                }
            }

            string strQuery = @"
SELECT   A.KPI_CODE
        ,M.COM_DEPT_NAME
		,ISNULL(C.KPI_NAME, '')     AS  KPI_NAME
        ,D.EMP_NAME                 AS  CHAMPION_EMP_NAME
        ,E.CODE_NAME                AS  KPI_GROUP_NAME
        ,G.CODE_NAME                AS  CLASS_NAME
        ,ISNULL(H.CATEGORY_NAME, ' ') + '/' + ISNULL(I.CATEGORY_NAME, ' ')  + '/' + ISNULL(J.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,K.CHECK_YN
        ,B.CHECKSTATUS
        ,ISNULL(L.APP_STATUS,'NFT') AS APP_STATUS
        ,A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,K.YMD, ISNULL(N.WEIGHT,0) AS WEIGHT, BR.RESULT_MS, BT.TARGET_MS,ISNULL(KK.UNIT, '-')    AS UNIT_NAME
FROM            BSC_KPI_INFO    A
LEFT OUTER JOIN BSC_KPI_RESULT  B   ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.KPI_REF_ID        = A.KPI_REF_ID
                                    AND B.YMD               = @YMD
LEFT OUTER JOIN BSC_KPI_POOL    C   ON  C.KPI_POOL_REF_ID   = A.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_EMP_INFO    D   ON  D.EMP_REF_ID        = A.CHAMPION_EMP_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  E   ON  E.ETC_CODE  = C.KPI_GROUP_REF_ID
LEFT OUTER JOIN BSC_MBO_KPI_CLASSIFICATION          F   ON  F.ESTTERM_REF_ID        = A.ESTTERM_REF_ID
                                                        AND F.KPI_REF_ID            = A.KPI_REF_ID
                                                        AND F.EMP_REF_ID            = A.CHAMPION_EMP_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') G   ON  G.ETC_CODE  = F.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                H   ON  H.CATEGORY_TOP_REF_ID   = C.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                I   ON  I.CATEGORY_TOP_REF_ID   = C.CATEGORY_TOP_REF_ID
                                                        AND I.CATEGORY_MID_REF_ID   = C.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                J   ON  J.CATEGORY_TOP_REF_ID   = C.CATEGORY_TOP_REF_ID
                                                        AND J.CATEGORY_MID_REF_ID   = C.CATEGORY_MID_REF_ID
                                                        AND J.CATEGORY_LOW_REF_ID   = C.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN BSC_KPI_TERM    K  ON   K.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND K.KPI_REF_ID        = A.KPI_REF_ID
                                    AND K.YMD               = @YMD
LEFT OUTER JOIN COM_APPROVAL_INFO   L   ON  L.APP_REF_ID    = B.APP_REF_ID
                                        AND L.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN viw_EMP_COMDEPT     M   ON  M.EMP_REF_ID    = A.CHAMPION_EMP_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT  N   ON  N.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                        AND N.EMP_REF_ID        = A.CHAMPION_EMP_ID
                                        AND N.KPI_REF_ID        = A.KPI_REF_ID
                                        AND N.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_MBO_KPI_TARGET_AGREEMENT    O   ON  O.ESTTERM_REF_ID    = N.ESTTERM_REF_ID
                                                    AND O.EMP_REF_ID        = N.EMP_REF_ID
LEFT OUTER JOIN COM_APPROVAL_INFO               P   ON  P.APP_REF_ID        = O.APP_REF_ID
							                        AND P.ACTIVE_YN      = 'Y' 
LEFT OUTER JOIN BSC_KPI_TARGET BT ON BT.KPI_REF_ID = A.KPI_REF_ID AND BT.YMD = @YMD
LEFT OUTER JOIN BSC_KPI_RESULT BR ON BR.KPI_REF_ID = A.KPI_REF_ID AND BR.YMD = @YMD
LEFT OUTER JOIN COM_UNIT_TYPE_INFO                  KK   ON  KK.UNIT_TYPE_REF_ID      = A.UNIT_TYPE_REF_ID
WHERE   A.ESTTERM_REF_ID                = @ESTTERM_REF_ID
    AND A.ISDELETE                      = 'N'
    AND A.USE_YN                        = 'Y'
    AND A.IS_TEAM_KPI                   = 'N'
    AND ISNULL(A.APPROVAL_STATUS, 'N')  = 'Y'
/*
    AND A.KPI_CODE                      LIKE ( @KPI_CODE            + '%')
    AND C.KPI_NAME                      LIKE ( @KPI_NAME            + '%')
    AND C.KPI_GROUP_REF_ID              LIKE ( @KPI_GROUP_REF_ID    + '%')
    AND D.EMP_NAME                      LIKE ( @CHAMPION_EMP_NAME   + '%')
*/

    AND (A.KPI_CODE                      LIKE ( @KPI_CODE            + '%') OR  @KPI_CODE  ='' )
    AND (C.KPI_NAME                      LIKE ( @KPI_NAME            + '%') OR  @KPI_NAME  ='' )
    AND (C.KPI_GROUP_REF_ID              LIKE ( @KPI_GROUP_REF_ID    + '%') OR  @KPI_GROUP_REF_ID  ='' )
    AND (D.EMP_NAME                      LIKE ( @CHAMPION_EMP_NAME   + '%') OR  @CHAMPION_EMP_NAME  ='' )
    AND M.COM_DEPT_REF_ID               = CASE WHEN @DEPT_REF_ID < 1 THEN 
                                            M.COM_DEPT_REF_ID 
                                          ELSE 
                                            @DEPT_REF_ID 
                                          END
    AND M.COM_DEPT_REF_ID IN    (   SELECT  BB.DEPT_REF_ID
									FROM    BSC_EMP_COM_DEPT_DETAIL AA
									INNER JOIN COM_DEPT_INFO BB ON  BB.DEPT_REF_ID = AA.DEPT_REF_ID
									WHERE AA.EMP_REF_ID     = @EMP_REF_ID)

    AND (N.ESTTERM_REF_ID IS NULL OR (N.ESTTERM_REF_ID IS NOT NULL AND P.APP_STATUS = 'CFT'))
    AND (C.CATEGORY_TOP_REF_ID   = @CATEGORY_TOP_REF_ID   OR  @CATEGORY_TOP_REF_ID = 0)
    AND (C.CATEGORY_MID_REF_ID   = @CATEGORY_MID_REF_ID   OR  @CATEGORY_MID_REF_ID = 0)
    AND (C.CATEGORY_LOW_REF_ID   = @CATEGORY_LOW_REF_ID   OR  @CATEGORY_LOW_REF_ID = 0)
{0}
ORDER BY M.COM_DEPT_REF_ID, K.CHECK_YN DESC, B.CHECKSTATUS DESC, B.CONFIRMSTATUS DESC, D.EMP_NAME, C.KPI_NAME
";


            int paramCnt = 11;

            if (!(bool)isadmin)
            {
                if ((bool)isteammanager)
                {
                    paramCnt++;
                }
            }

            strQuery = string.Format(strQuery, strQueryAdd);

            IDbDataParameter[] paramArray = CreateDataParameters(paramCnt);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@CHAMPION_EMP_NAME", SqlDbType.VarChar);

            paramArray[5] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@KPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@CATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[8] = CreateDataParameter("@CATEGORY_MID_REF_ID", SqlDbType.Int);
            paramArray[9] = CreateDataParameter("@CATEGORY_LOW_REF_ID", SqlDbType.Int);
            paramArray[10] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            if (!(bool)isadmin)
            {
                if ((bool)isteammanager)
                {
                    paramArray[11] = CreateDataParameter("@USER_DEPT_REF_ID", SqlDbType.Int);
                    paramArray[11].Value = user_dept_ref_id;
                }
            }

            

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = ymd;
            paramArray[2].Value = kpi_code;
            paramArray[3].Value = kpi_name;
            paramArray[4].Value = champion_emp_name;

            paramArray[5].Value = dept_ref_id;
            paramArray[6].Value = kpi_group_ref_id;
            paramArray[7].Value = category_top_ref_id;
            paramArray[8].Value = category_mid_ref_id;
            paramArray[9].Value = category_low_ref_id;
            paramArray[10].Value = emp_ref_id;
            

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "MBO_FOR_RESULT", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiForMboResult(object estterm_ref_id
                                        , object kpi_ref_id
                                        , object emp_ref_id
                                        , object ymd)
        {
            string sqlQuery1 = @"
--kpi info
SELECT   A.CHAMPION_EMP_ID
        ,A.KPI_CODE
        ,A.RESULT_TS_CALC_TYPE
        ,A.KPI_POOL_REF_ID
        ,A.RESULT_INPUT_TYPE
        ,ISNULL(B.KPI_NAME, '')         AS KPI_NAME
        ,S1.CODE_NAME                   AS RESULT_ACHIEVEMENT_TYPE_NAME
        ,S2.CODE_NAME                   AS RESULT_TS_CALC_TYPE_NAME
        ,ISNULL(S4.CATEGORY_NAME, ' ') + '/' + ISNULL(S5.CATEGORY_NAME, ' ')  + '/' + ISNULL(S6.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(S3.UNIT, '-')           AS UNIT_NAME
        ,C.CONFIRMSTATUS
        ,C.YMD
FROM            BSC_KPI_INFO        A
LEFT OUTER JOIN BSC_KPI_POOL        B   ON B.KPI_POOL_REF_ID    = A.KPI_POOL_REF_ID
           JOIN BSC_KPI_RESULT      C   ON (    A.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                            AND A.KPI_REF_ID        = C.KPI_REF_ID
                                            AND C.YMD               = :YMD)
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS003')  S1  ON S1.ETC_CODE      = A.RESULT_ACHIEVEMENT_TYPE
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS002')  S2  ON S2.ETC_CODE      = A.RESULT_TS_CALC_TYPE
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  S3  ON S3.UNIT_TYPE_REF_ID  = A.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP    S4  ON  S4.CATEGORY_TOP_REF_ID   = B.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID    S5  ON  S5.CATEGORY_TOP_REF_ID   = B.CATEGORY_TOP_REF_ID
                                            AND S5.CATEGORY_MID_REF_ID   = B.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW    S6  ON  S6.CATEGORY_TOP_REF_ID   = B.CATEGORY_TOP_REF_ID
                                            AND S6.CATEGORY_MID_REF_ID   = B.CATEGORY_MID_REF_ID
                                            AND S6.CATEGORY_LOW_REF_ID   = B.CATEGORY_LOW_REF_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ISDELETE          = 'N'
    AND A.KPI_REF_ID        = @KPI_REF_ID
";

//kpi status
            string sqlQuery2 = @"
SELECT   CASE WHEN A.CHAMPION_EMP_ID = @EMP_REF_ID THEN 'Y' ELSE 'N' END                    AS CHAMPION_EMP_YN
        ,CASE WHEN B.YEARLY_CLOSE_YN = 1 THEN 'Y' ELSE 'N' END                              AS YEARLY_CLOSE_YN
        ,CASE WHEN ISNULL(B.PRE_CLOSE_DAY, 0) < DAY(GETDATE()) THEN 'Y' ELSE 'N' END        AS IS_PASS_PRE_CLOSE_DAY
        ,CASE WHEN ISNULL(B.MONTHLY_CLOSE_DAY, 0) < DAY(GETDATE()) THEN 'Y' ELSE 'N' END    AS IS_PASS_CLOSE_DAY 
        ,CASE WHEN ISNULL(B.KPI_QLT_CLOSE_DAY, 0) < DAY(GETDATE()) THEN 'Y' ELSE 'N' END    AS IS_PASS_QLT_CLOSE_DAY 
        ,CASE WHEN ISNULL(COUNT(C.KPI_REF_ID), 0) = 0 THEN 'N' ELSE 'Y' END                 AS HAVE_INITIATIVE_YN
FROM        BSC_KPI_INFO    A
INNER JOIN  EST_TERM_INFO   B   ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
INNER JOIN  BSC_KPI_TARGET_VERSION D    ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                        AND D.KPI_REF_ID        = A.KPI_REF_ID
                                        AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_PRJ C   ON  C.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                AND C.KPI_REF_ID        = A.KPI_REF_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.KPI_REF_ID        = @KPI_REF_ID
GROUP BY CASE WHEN A.CHAMPION_EMP_ID = @EMP_REF_ID THEN 'Y' ELSE 'N' END
        ,CASE WHEN B.YEARLY_CLOSE_YN = 1 THEN 'Y' ELSE 'N' END
        ,CASE WHEN ISNULL(B.PRE_CLOSE_DAY, 0) < DAY(GETDATE()) THEN 'Y' ELSE 'N' END
        ,CASE WHEN ISNULL(B.MONTHLY_CLOSE_DAY, 0) < DAY(GETDATE()) THEN 'Y' ELSE 'N' END
        ,CASE WHEN ISNULL(B.KPI_QLT_CLOSE_DAY, 0) < DAY(GETDATE()) THEN 'Y' ELSE 'N' END

";

            string orclQuery2 = @"
SELECT   CASE WHEN A.CHAMPION_EMP_ID = @EMP_REF_ID THEN 'Y' ELSE 'N' END                    AS CHAMPION_EMP_YN
        ,CASE WHEN B.YEARLY_CLOSE_YN = 1 THEN 'Y' ELSE 'N' END                              AS YEARLY_CLOSE_YN
        ,CASE WHEN ISNULL(B.PRE_CLOSE_DAY, 0)     < TO_NUMBER(TRANSLATE(TO_CHAR(SYSDATE, 'DD'), '0', ' ')) THEN 'Y' ELSE 'N' END        AS IS_PASS_PRE_CLOSE_DAY
        ,CASE WHEN ISNULL(B.MONTHLY_CLOSE_DAY, 0) < TO_NUMBER(TRANSLATE(TO_CHAR(SYSDATE, 'DD'), '0', ' ')) THEN 'Y' ELSE 'N' END    AS IS_PASS_CLOSE_DAY 
        ,CASE WHEN ISNULL(B.KPI_QLT_CLOSE_DAY, 0) < TO_NUMBER(TRANSLATE(TO_CHAR(SYSDATE, 'DD'), '0', ' ')) THEN 'Y' ELSE 'N' END    AS IS_PASS_QLT_CLOSE_DAY 
        ,CASE WHEN ISNULL(COUNT(C.KPI_REF_ID), 0) = 0 THEN 'N' ELSE 'Y' END                 AS HAVE_INITIATIVE_YN
FROM        BSC_KPI_INFO    A
INNER JOIN  EST_TERM_INFO   B   ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
INNER JOIN  BSC_KPI_TARGET_VERSION D    ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                        AND D.KPI_REF_ID        = A.KPI_REF_ID
                                        AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_PRJ C   ON  C.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                AND C.KPI_REF_ID        = A.KPI_REF_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.KPI_REF_ID        = @KPI_REF_ID
GROUP BY CASE WHEN A.CHAMPION_EMP_ID = @EMP_REF_ID THEN 'Y' ELSE 'N' END
        ,CASE WHEN B.YEARLY_CLOSE_YN = 1 THEN 'Y' ELSE 'N' END
        ,CASE WHEN ISNULL(B.PRE_CLOSE_DAY, 0)     < TO_NUMBER(TRANSLATE(TO_CHAR(SYSDATE, 'DD'), '0', ' ')) THEN 'Y' ELSE 'N' END
        ,CASE WHEN ISNULL(B.MONTHLY_CLOSE_DAY, 0) < TO_NUMBER(TRANSLATE(TO_CHAR(SYSDATE, 'DD'), '0', ' ')) THEN 'Y' ELSE 'N' END
        ,CASE WHEN ISNULL(B.KPI_QLT_CLOSE_DAY, 0) < TO_NUMBER(TRANSLATE(TO_CHAR(SYSDATE, 'DD'), '0', ' ')) THEN 'Y' ELSE 'N' END

";



            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(sqlQuery1, "BSC_KPI_INFO_MBO_FOR_RESULT", null, paramArray, CommandType.Text).Tables[0].DataSet;

            paramArray = null;
            paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = emp_ref_id;

            DbAgentObj.FillDataSet(GetQueryStringByDb(sqlQuery2, orclQuery2), "BSC_KPI_INFO_MBO_FOR_RESULT_APP", ds, paramArray, CommandType.Text);

            return ds;
        }

        


        #region ========================== 멀티 DB 작업 ============================


        public bool CopyKpiToMbo_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object objList
                                , object emp_ref_id
                                , object kpi_ref_id
                                , object estYear
                                , object class_type)
        {
            int affectedRow = 0;
            string strQuery1 = string.Empty;
            string strQuery2 = string.Empty;
            string strQuery3 = string.Empty;
            string strQuery4 = string.Empty;
            string strQuery5 = string.Empty;
            string strQuery6 = string.Empty;

            IDbDataParameter[] paramArray;

            strQuery2 = @"
INSERT INTO BSC_KPI_TERM
    (ESTTERM_REF_ID,    KPI_REF_ID,     YMD,    CHECK_YN,   CREATE_DATE,    CREATE_USER)
SELECT
    @ESTTERM_REF_ID,   @KPI_REF_ID,     YMD,    CHECK_YN,   GETDATE(),      @EMP_REF_ID
FROM    BSC_KPI_TERM
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            strQuery3 = @"
DELETE FROM BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID   = @ESTTERM_REF_ID
    AND KPI_REF_ID       = @KPI_REF_ID
";
            strQuery4 = @"
INSERT INTO BSC_KPI_THRESHOLD_INFO
    (ESTTERM_REF_ID,    KPI_REF_ID,     THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       CREATE_DATE,    CREATE_USER)
SELECT
    @ESTTERM_REF_ID,    @KPI_REF_ID,    THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,0,                 '',             0,                  0,                  GETDATE(),      @EMP_REF_ID
FROM    BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";
            if (class_type.ToString() == "PRS")
                strQuery4 = @"
INSERT INTO BSC_KPI_THRESHOLD_INFO
    (ESTTERM_REF_ID,    KPI_REF_ID,     THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       CREATE_DATE,    CREATE_USER)
SELECT
    @ESTTERM_REF_ID,    @KPI_REF_ID,    THRESHOLD_REF_ID,   THRESHOLD_LEVEL
    ,SET_MIN_VALUE,     SET_TXT_VALUE,  SET_MAX_VALUE,      ACHIEVE_RATE,       GETDATE(),      @EMP_REF_ID
FROM    BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            strQuery5 = @"
INSERT INTO BSC_KPI_INITIATIVE
    (ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
VALUES
    (@ESTTERM_REF_ID,   @KPI_REF_ID,    @YMD,           '',                 '',             '',                 @EMP_REF_ID,    GETDATE())
";
            if (class_type.ToString() == "PRS")
                strQuery5 = @"
INSERT INTO BSC_KPI_INITIATIVE
        (ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
SELECT  @ESTTERM_REF_ID,   @KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    @EMP_REF_ID,    GETDATE()
FROM    BSC_KPI_INITIATIVE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            strQuery6 = @"
INSERT INTO BSC_KPI_TARGET
        (ESTTERM_REF_ID, KPI_REF_ID, KPI_TARGET_VERSION_ID, YMD, TARGET_MS, TARGET_TS, CREATE_DATE, CREATE_USER)
    SELECT
         ESTTERM_REF_ID, @KPI_REF_ID, KPI_TARGET_VERSION_ID, YMD, TARGET_MS, TARGET_TS, GETDATE(), @EMP_REF_ID
    FROM BSC_KPI_TARGET
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID      = @ORG_KPI_REF_ID
";


            if (DataTypeUtility.GetToInt32(kpi_ref_id) > 0)
            {
                // KPI DATA SOURCE(NO)
                // KPI TERM && TARGET

                paramArray = null;
                paramArray = CreateDataParameters(4);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = kpi_ref_id;
                paramArray[2].Value = DataTypeUtility.GetToInt32(objList);
                paramArray[3].Value = emp_ref_id;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery2, paramArray, CommandType.Text);

                if (affectedRow != 12)
                {
                    this.Transaction_Message = "계획일정 저장중 오류가 발생하였습니다.";
                    return false;
                }

                if (class_type.ToString() == "PRS")
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(4);
                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    paramArray[1].Value = kpi_ref_id;
                    paramArray[2].Value = DataTypeUtility.GetToInt32(objList);
                    paramArray[3].Value = emp_ref_id;

                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery6, paramArray, CommandType.Text);
                }
                else
                {
                    for (int j = 1; j < 13; j++)
                    {
                        paramArray = null;
                        paramArray = CreateDataParameters(10);
                        paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
                        paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
                        paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
                        paramArray[3] = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
                        paramArray[4] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
                        paramArray[5] = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
                        paramArray[6] = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
                        paramArray[7] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
                        paramArray[8] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
                        paramArray[9] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);

                        paramArray[0].Value = "A";
                        paramArray[1].Value = estterm_ref_id;
                        paramArray[2].Value = kpi_ref_id;
                        paramArray[3].Value = 1;
                        paramArray[4].Value = estYear.ToString() + ("0" + j.ToString()).Substring((j.ToString().Length == 1 ? 0 : 1), 2);
                        paramArray[5].Value = 0;
                        paramArray[6].Value = 0;
                        paramArray[7].Value = emp_ref_id;
                        paramArray[8].Direction = ParameterDirection.Output;
                        paramArray[9].Direction = ParameterDirection.Output;

                        IDataParameterCollection col;
                        affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

                        this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
                        //this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
                        string rtnMSG = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

                        if (rtnMSG == "N")
                            return false;
                    }
                }

                ////////////////////////////////////////////////////
                // KPI THRESHOLD 
                ////////////////////////////////////////////////////

                paramArray = null;
                paramArray = CreateDataParameters(2);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = kpi_ref_id;

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery3, paramArray, CommandType.Text);

                paramArray = null;
                paramArray = CreateDataParameters(4);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[3] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);

                paramArray[0].Value = estterm_ref_id;
                paramArray[1].Value = kpi_ref_id;
                paramArray[2].Value = emp_ref_id;
                paramArray[3].Value = DataTypeUtility.GetToInt32(objList);

                affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery4, paramArray, CommandType.Text);

                // KPI INITIATIVE

                if (class_type.ToString() == "PRS")
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(4);

                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                    paramArray[0].Value = estterm_ref_id;
                    paramArray[1].Value = kpi_ref_id;
                    paramArray[2].Value = DataTypeUtility.GetToInt32(objList);
                    paramArray[3].Value = emp_ref_id;

                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery5, paramArray, CommandType.Text);
                }
                else
                {
                    affectedRow = 0;
                    for (int j = 1; j < 13; j++)
                    {
                        paramArray = null;
                        paramArray = CreateDataParameters(4);

                        paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                        paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                        paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                        paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

                        paramArray[0].Value = estterm_ref_id;
                        paramArray[1].Value = kpi_ref_id;
                        paramArray[2].Value = estYear.ToString() + ("0" + j.ToString()).Substring((j.ToString().Length == 1 ? 0 : 1), 2);
                        paramArray[3].Value = emp_ref_id;

                        affectedRow += DbAgentObj.ExecuteNonQuery(idc, idt, strQuery5, paramArray, CommandType.Text);
                    }
                }
            }
            else
            {
                this.Transaction_Message = "KPI ID를 생성하지 못하였습니다.";
                return false;
            }

            if (DataTypeUtility.GetToInt32(kpi_ref_id) > 0)
                return true;
            else
                return false;
        }




        public DataTable SelectBscMboKpiClassification_DB(object estterm_ref_id
                                                  , object emp_ref_id
                                                  , object org_kpi_ref_id
                                                  , string filter)
        {
            string query = @"
SELECT  ESTTERM_REF_ID
FROM    BSC_MBO_KPI_CLASSIFICATION
WHERE   (ESTTERM_REF_ID  = @ESTTERM_REF_ID     OR   @ESTTERM_REF_ID  =0)
    AND (EMP_REF_ID      = @EMP_REF_ID         OR   @EMP_REF_ID      =0)
    AND (ORG_KPI_REF_ID  = @ORG_KPI_REF_ID     OR   @ORG_KPI_REF_ID  =0)

";

            if (filter.Length > 0)
            {
                query += filter;
            }

            query += " ORDER BY ESTTERM_REF_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = emp_ref_id;
            paramArray[2].Value = org_kpi_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_MBO_KPI_CLASSIFICATION", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public int CopyBscKpiInfo_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object emp_ref_id
                                , object org_kpi_ref_id)
        {
            string query = @"
-- KPI INFO COPY
INSERT INTO BSC_KPI_INFO    
    (ESTTERM_REF_ID,            KPI_REF_ID,             KPI_CODE,                   KPI_POOL_REF_ID,            WORD_DEFINITION
    ,CALC_FORM_MS,              CHAMPION_EMP_ID,        RESULT_INPUT_TYPE,          RESULT_ACHIEVEMENT_TYPE,    RESULT_TS_CALC_TYPE      
    ,RESULT_MEASUREMENT_STEP,   MEASUREMENT_GRADE_TYPE, UNIT_TYPE_REF_ID,           KPI_TARGET_VERSION_ID,      KPI_TARGET_SETTING_REASON
    ,KPI_TARGET_REASON_FILE,    APPROVAL_STATUS,        EXCEL_DNUSE,                IS_TEAM_KPI                 ,USE_YN
    ,CREATE_DATE,               CREATE_USER)
SELECT
    @ESTTERM_REF_ID,            @KPI_REF_ID,            @KPI_CODE,                  KPI_POOL_REF_ID,            WORD_DEFINITION
    ,CALC_FORM_MS,              @EMP_REF_ID,            RESULT_INPUT_TYPE,          RESULT_ACHIEVEMENT_TYPE,    RESULT_TS_CALC_TYPE
    ,RESULT_MEASUREMENT_STEP,   MEASUREMENT_GRADE_TYPE, UNIT_TYPE_REF_ID,           '1',                        KPI_TARGET_SETTING_REASON
    ,'',                        'N',                    EXCEL_DNUSE,                'N',                        'Y'
    ,GETDATE(),                 @EMP_REF_ID
FROM    BSC_KPI_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = 0;
            paramArray[2].Value = "MicroPolis_0";
            paramArray[3].Value = emp_ref_id;
            paramArray[4].Value = org_kpi_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int SelectMaxBscKpiInfo_DB()
        {
            int returnMax = 1001;

            string query = @"
-- MAX KPI_REF_ID
SELECT ISNULL(MAX(KPI_REF_ID),1000) AS KPI_REF_ID
FROM BSC_KPI_INFO
";

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_INFO", null, null, CommandType.Text).Tables[0];

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    returnMax = DataTypeUtility.GetToInt32(dt.Rows[0][0]) + 1;
                }
            }
            
            return returnMax;
        }

        public int SelectMaxBscKpiInfo_DB(IDbConnection idc
                                        , IDbTransaction idt)
        {
            int returnMax = 1001;

            string sqlQuery = @"
-- MAX KPI_REF_ID
SELECT ISNULL(MAX(KPI_REF_ID),1000) +1 AS KPI_REF_ID
FROM BSC_KPI_INFO
";

            string orclQuery = @"

SELECT SEQ_BSC_KPI_INFO.NEXTVAL  AS KPI_REF_ID FROM DUAL

";



            DataTable dt = DbAgentObj.FillDataSet(idc, idt, GetQueryStringByDb(sqlQuery, orclQuery), "BSC_KPI_INFO", null, null, CommandType.Text).Tables[0];

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    returnMax = DataTypeUtility.GetToInt32(dt.Rows[0][0]);
                }
            }

            return returnMax;
        }


        public int DeleteBscKpiTargetVersion_DB(IDbConnection idc
                                            , IDbTransaction idt
                                            , object estterm_ref_id
                                            , object kpi_ref_id)
        {
            string query = @"

-- KPI TARGET VERSION INSERT
DELETE FROM BSC_KPI_TARGET_VERSION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @RTN_KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int InsertBscKpiTargetVersion_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object emp_ref_id)
        {
            string query = @"
                 
INSERT INTO BSC_KPI_TARGET_VERSION
    (ESTTERM_REF_ID,        KPI_REF_ID,         KPI_TARGET_VERSION_ID,      VERSION_NAME,       VERSION_DESC         
    ,VERSION_NUMBER,        UPDATE_TERM,        USE_YN,                     CREATE_DATE,        CREATE_USER)
VALUES 
    (@ESTTERM_REF_ID,       @RTN_KPI_REF_ID,    1,                          '당초계획',         '당초계획(자동생성)'
    ,1,                     12,                 'Y',                        GETDATE(),          @EMP_REF_ID) 

";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = emp_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int DeleteBscKpiResult_DB(IDbConnection idc
                                    , IDbTransaction idt
                                    , object estterm_ref_id
                                    , object kpi_ref_id)
        {
            string query = @"

-- KPI RESULT INSERT
DELETE FROM BSC_KPI_RESULT
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @RTN_KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int CopyBscTermDetailToBscKpiResult_DB(IDbConnection idc
                                                    , IDbTransaction idt
                                                    , object estterm_ref_id
                                                    , object kpi_ref_id
                                                    , object emp_ref_id)
        {
            string query = @"

INSERT INTO BSC_KPI_RESULT
    (ESTTERM_REF_ID,    KPI_REF_ID,         YMD,            RESULT_MS,      RESULT_TS       
    ,SEQUENCE,          CHECKSTATUS,        CONFIRMSTATUS,  CAL_RESULT_MS,  CAL_RESULT_TS   
    ,CAL_APPLY_YN,      CAL_APPLY_REASON,   REMARK,         APP_REF_ID,     CREATE_DATE     
    ,CREATE_USER)
SELECT  ESTTERM_REF_ID,     @RTN_KPI_REF_ID,    YMD,            0.00,           0.00
        ,CAST(YMD AS INT), 'N',                'N',            0.00,           0.00
        ,'N',               '',                 '',             0,              GETDATE()
        ,@EMP_REF_ID
FROM    BSC_TERM_DETAIL
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = emp_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int UpdateBscKpiInfo_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object new_kpi_ref_id
                                , object kpi_ref_id)
        {
            string query = @"

UPDATE BSC_KPI_INFO
SET KPI_REF_ID = @RTN_KPI_REF_ID
  , KPI_CODE = CAST(@RTN_KPI_REF_ID AS VARCHAR(20))
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = new_kpi_ref_id;
            paramArray[2].Value = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int InsertBscMboKpiClassification_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object emp_ref_id
                                , object org_kpi_ref_id
                                , object class_type)
        {
            string query = @"
          
-- 지표구분테이블에 일상업무정보 추가 BSC_MBO_KPI_CLASSIFICATION
INSERT INTO BSC_MBO_KPI_CLASSIFICATION
    (ESTTERM_REF_ID,                KPI_REF_ID,   EMP_REF_ID,       ORG_KPI_REF_ID
    ,KPI_CLASS_REF_ID,      CREATE_DATE,        CREATE_USER)
    VALUES
    (@ESTTERM_REF_ID,              @KPI_REF_ID,  @EMP_REF_ID,   @ORG_KPI_REF_ID
    ,@CLASS_TYPE,                 GETDATE(),          @EMP_REF_ID)
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@CLASS_TYPE", SqlDbType.VarChar);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = emp_ref_id;
            paramArray[3].Value = org_kpi_ref_id;
            paramArray[4].Value = class_type;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }

        public int InsertBscKpiInfo_DB(IDbConnection idc
                                    , IDbTransaction idt
                                    , object estterm_ref_id
                                    , object kpi_ref_id
                                    , object kpi_code
                                    , object kpi_pool_ref_id
                                    , object word_definition
                                    , object calc_form_ms
                                    , object champion_emp_id
                                    , object result_achievement_type
                                    , object result_ts_calc_type
                                    , object result_input_type
                                    , object result_measurement_step
                                    , object measurement_grade_type
                                    , object unit_type_ref_id
                                    , object kpi_target_version_id
                                    , object kpi_target_setting_reason
                                    , object kpi_target_reason_file
                                    , object approval_status
                                    , object excel_dnuse
                                    , object create_user)
        {
            string query = @"
-- KPI INFO INSERT
INSERT INTO BSC_KPI_INFO    
    (ESTTERM_REF_ID,            KPI_REF_ID,             KPI_CODE,                   KPI_POOL_REF_ID,            WORD_DEFINITION
    ,CALC_FORM_MS,              CHAMPION_EMP_ID,        RESULT_INPUT_TYPE,          RESULT_ACHIEVEMENT_TYPE,    RESULT_TS_CALC_TYPE      
    ,RESULT_MEASUREMENT_STEP,   MEASUREMENT_GRADE_TYPE, UNIT_TYPE_REF_ID,           KPI_TARGET_VERSION_ID,      KPI_TARGET_SETTING_REASON
    ,KPI_TARGET_REASON_FILE,    APPROVAL_STATUS,        EXCEL_DNUSE,                IS_TEAM_KPI                 ,USE_YN
    ,CREATE_DATE,               CREATE_USER)
VALUES  
    (@ESTTERM_REF_ID,           @KPI_REF_ID,            @KPI_CODE,                  @KPI_POOL_REF_ID,           @WORD_DEFINITION
    ,@CALC_FORM_MS,             @CHAMPION_EMP_ID,       @RESULT_INPUT_TYPE,         @RESULT_ACHIEVEMENT_TYPE,   @RESULT_TS_CALC_TYPE
    ,@RESULT_MEASUREMENT_STEP,  @MEASUREMENT_GRADE_TYPE,@UNIT_TYPE_REF_ID,          @KPI_TARGET_VERSION_ID,     @KPI_TARGET_SETTING_REASON
    ,@KPI_TARGET_REASON_FILE,   @APPROVAL_STATUS,       @EXCEL_DNUSE,               @IS_TEAM_KPI,               @USE_YN
    ,GETDATE(),                 @CREATE_USER)
";

            IDbDataParameter[] paramArray = CreateDataParameters(21);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@WORD_DEFINITION", SqlDbType.VarChar);

            paramArray[5] = CreateDataParameter("@CALC_FORM_MS", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[7] = CreateDataParameter("@RESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[9] = CreateDataParameter("@RESULT_TS_CALC_TYPE", SqlDbType.VarChar);

            paramArray[10] = CreateDataParameter("@RESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[11] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[12] = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[13] = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.VarChar);
            paramArray[14] = CreateDataParameter("@KPI_TARGET_SETTING_REASON", SqlDbType.Text);

            paramArray[15] = CreateDataParameter("@KPI_TARGET_REASON_FILE", SqlDbType.VarChar);
            paramArray[16] = CreateDataParameter("@APPROVAL_STATUS", SqlDbType.Char);
            paramArray[17] = CreateDataParameter("@EXCEL_DNUSE", SqlDbType.Char);
            paramArray[18] = CreateDataParameter("@IS_TEAM_KPI", SqlDbType.Char);
            paramArray[19] = CreateDataParameter("@USE_YN", SqlDbType.Char);

            paramArray[20] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = 0;
            paramArray[2].Value = "MicroPolis_0";
            paramArray[3].Value = kpi_pool_ref_id;
            paramArray[4].Value = word_definition;

            paramArray[5].Value = calc_form_ms;
            paramArray[6].Value = champion_emp_id;
            paramArray[7].Value = result_input_type;
            paramArray[8].Value = result_achievement_type;
            paramArray[9].Value = result_ts_calc_type;

            paramArray[10].Value = result_measurement_step;
            paramArray[11].Value = measurement_grade_type;
            paramArray[12].Value = unit_type_ref_id;
            paramArray[13].Value = kpi_target_version_id;
            paramArray[14].Value = kpi_target_setting_reason;

            paramArray[15].Value = kpi_target_reason_file;
            paramArray[16].Value = approval_status;
            paramArray[17].Value = excel_dnuse;
            paramArray[18].Value = "N";
            paramArray[19].Value = "Y";

            paramArray[20].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }





        public DataTable SelectBscKpiInfo_DB(object estterm_ref_id
                                           , object kpi_ref_id
                                           , object approval_status)
        {

            string query = @"

SELECT  KPI_REF_ID 
     , UP_KPI_REF_ID
     , ROLLUP_TARGET_YN 
     , RESULT_TS_CALC_TYPE
FROM BSC_KPI_INFO
WHERE (ESTTERM_REF_ID  = @ESTTERM_REF_ID   OR  @ESTTERM_REF_ID   = 0)
  AND (KPI_REF_ID      = @KPI_REF_ID       OR  @KPI_REF_ID       = 0)
  AND (APPROVAL_STATUS = @APPROVAL_STATUS  OR  @APPROVAL_STATUS  ='')

";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@APPROVAL_STATUS", SqlDbType.VarChar);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = approval_status;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_INFO", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }

        public DataTable SelectDuplicationBscKpiInfo_DB(object estterm_ref_id
                                             , object kpi_ref_id
                                             , object kpi_code)
        {

            string query = @"

SELECT CASE WHEN ISNULL(SUM(KPI_REF_ID), 0) > 0 THEN 1 ELSE 0 END AS CNT
FROM BSC_KPI_INFO
WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND KPI_CODE       = @KPI_CODE
    AND KPI_REF_ID    != @KPI_REF_ID 

";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = kpi_code;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_INFO", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }


        public int UpdateBscKpiInfo_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object kpi_code
                                , object kpi_pool_ref_id
                                , object word_definition
                                , object calc_form_ms
                                , object champion_emp_id
                                , object result_achievement_type
                                , object result_ts_calc_type
                                , object result_input_type
                                , object result_measurement_step
                                , object measurement_grade_type
                                , object unit_type_ref_id
                                , object kpi_target_version_id
                                , object kpi_target_setting_reason
                                , object kpi_target_reason_file
                                , object approval_status
                                , object excel_dnuse
                                , object create_user)
        {
            string query = @"

UPDATE BSC_KPI_INFO
SET
     KPI_POOL_REF_ID            = @KPI_POOL_REF_ID
    ,WORD_DEFINITION            = @WORD_DEFINITION
    ,CALC_FORM_MS               = @CALC_FORM_MS
    ,CHAMPION_EMP_ID            = @CHAMPION_EMP_ID
    ,RESULT_INPUT_TYPE          = @RESULT_INPUT_TYPE
    ,RESULT_ACHIEVEMENT_TYPE    = @RESULT_ACHIEVEMENT_TYPE
    ,RESULT_TS_CALC_TYPE        = @RESULT_TS_CALC_TYPE
    ,RESULT_MEASUREMENT_STEP    = @RESULT_MEASUREMENT_STEP
    ,MEASUREMENT_GRADE_TYPE     = @MEASUREMENT_GRADE_TYPE
    ,UNIT_TYPE_REF_ID           = @UNIT_TYPE_REF_ID
    ,KPI_TARGET_VERSION_ID      = @KPI_TARGET_VERSION_ID
    ,KPI_TARGET_SETTING_REASON  = @KPI_TARGET_SETTING_REASON
    ,KPI_TARGET_REASON_FILE     = @KPI_TARGET_REASON_FILE
    ,EXCEL_DNUSE                = @EXCEL_DNUSE
    ,UPDATE_DATE                = GETDATE()
    ,UPDATE_USER                = @UPDATE_USER
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID


";

            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@WORD_DEFINITION", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@CALC_FORM_MS", SqlDbType.VarChar);

            paramArray[5] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[6] = CreateDataParameter("@RESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@RESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[9] = CreateDataParameter("@RESULT_MEASUREMENT_STEP", SqlDbType.VarChar);

            paramArray[10] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[11] = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[12] = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.VarChar);
            paramArray[13] = CreateDataParameter("@KPI_TARGET_SETTING_REASON", SqlDbType.Text);
            paramArray[14] = CreateDataParameter("@KPI_TARGET_REASON_FILE", SqlDbType.VarChar);

            paramArray[15] = CreateDataParameter("@EXCEL_DNUSE", SqlDbType.Char);
            paramArray[16] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = kpi_pool_ref_id;
            paramArray[3].Value = word_definition;
            paramArray[4].Value = calc_form_ms;

            paramArray[5].Value = champion_emp_id;
            paramArray[6].Value = result_input_type;
            paramArray[7].Value = result_achievement_type;
            paramArray[8].Value = result_ts_calc_type;
            paramArray[9].Value = result_measurement_step;

            paramArray[10].Value = measurement_grade_type;
            paramArray[11].Value = unit_type_ref_id;
            paramArray[12].Value = kpi_target_version_id;
            paramArray[13].Value = kpi_target_setting_reason;
            paramArray[14].Value = kpi_target_reason_file;

            paramArray[15].Value = excel_dnuse;
            paramArray[16].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        #endregion
    }
}




