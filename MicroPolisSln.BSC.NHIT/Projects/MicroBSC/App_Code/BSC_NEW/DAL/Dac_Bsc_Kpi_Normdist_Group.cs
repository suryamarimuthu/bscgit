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
    /// Class 명		@ Dac_Bsc_Kpi_Normdist_Group Dac 클래스
    /// Class 내용		@ Bsc_Kpi_Normdist_Group Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2007.04.25
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Normdist_Group : DbAgentBase
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
        private int 	 _iapp_ref_id;
        private string 	 _iexcel_dnuse;
        private string 	 _iuse_yn;

        private string _iNormdistGroup;
        private string _iNormdist_Use_YN;


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

        public int Iapp_ref_id
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

        public string INormdistGroup
        {
            get
            {
                return _iNormdistGroup;
            }
            set
            {
                _iNormdistGroup = (value == null ? "" : value);
            }
        }


        public string INormdist_Use_YN
        {
            get
            {
                return _iNormdist_Use_YN;
            }
            set
            {
                _iNormdist_Use_YN = (value == null ? "" : value);
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
        public Dac_Bsc_Kpi_Normdist_Group() { }
       
        #endregion

        #region ============================== [Method] ==============================


        internal protected DataSet GetNormdistList_Dac(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, string ikpi_group_ref_id, string iNormadist_group, string iNormdist_use_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "KN";
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
            paramArray[9] = CreateDataParameter("@iNORMDIST_GROUP", SqlDbType.VarChar);
            paramArray[9].Value = iNormadist_group;
            paramArray[10] = CreateDataParameter("@iNORMDIST_USE_YN", SqlDbType.VarChar);
            paramArray[10].Value = iNormdist_use_yn;
            paramArray[11] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_NORMDIST_GROUP", "PKG_BSC_KPI_NORMDIST_GROUP.PROC_SELECT_KPI_NORMDIST_LIST"), "BSC_KPI_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        internal protected int InsertData_Dac
              (int iestterm_ref_id, int ikpi_ref_code, string inormdist_group, string inormdist_use_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_code;
            paramArray[3] = CreateDataParameter("@iNORMDIST_GROUP", SqlDbType.VarChar);
            paramArray[3].Value = inormdist_group;
            paramArray[4] = CreateDataParameter("@iNORMDIST_USE_YN", SqlDbType.Char);
            paramArray[4].Value = inormdist_use_yn;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;
            paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction = ParameterDirection.Output;
            paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_NORMDIST_GROUP", "PKG_BSC_KPI_NORMDIST_GROUP.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
         
            return affectedRow;
        }

        internal protected int UpdateData_Dac
            (int iestterm_ref_id, int ikpi_ref_code, string inormdist_group, string inormdist_use_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_code;
            paramArray[3] = CreateDataParameter("@iNORMDIST_GROUP", SqlDbType.VarChar);
            paramArray[3].Value = inormdist_group;
            paramArray[4] = CreateDataParameter("@iNORMDIST_USE_YN", SqlDbType.Char);
            paramArray[4].Value = inormdist_use_yn;
            paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value = itxr_user;
            paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[6].Direction = ParameterDirection.Output;
            paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[7].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_NORMDIST_GROUP", "PKG_BSC_KPI_NORMDIST_GROUP.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        #endregion
    }
}
