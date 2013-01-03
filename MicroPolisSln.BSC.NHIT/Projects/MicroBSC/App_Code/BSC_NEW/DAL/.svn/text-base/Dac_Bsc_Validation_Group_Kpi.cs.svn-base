using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;


namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Qlt_Info에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Kpi_Qlt_Info Dac 클래스
    /// Class 내용		@ Bsc_Kpi_Qlt_Info Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Validation_Group_Kpi : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _iestterm_ref_id     ;
        private int      _igroup_ref_id       ;
        private int      _iest_level          ;
        private int      _iemp_ref_id         ;
        private int      _ikpi_ref_id         ;
        private string   _iopinion            ;
        private string   _icomplete_yn        ; 
        private DateTime _iwrite_date         ;
        private Int32    _itxr_user           ;
        private Int32    _create_user         ;
        private DateTime _create_date         ;
        private Int32    _update_user         ;
        private DateTime _update_date         ;
        private String   _txr_message         ; // 처리결과메시지
        private String   _txr_result          ; // 처리결과여부(Y,N)
        #endregion

        #region ------------------------ [ Property ] ------------------------

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

        public int Igroup_ref_id
        {
            get
            {
                return _igroup_ref_id;
            }
            set
            {
                _igroup_ref_id = value;
            }
        }

        public int Iest_level
        {
            get
            {
                return _iest_level;
            }
            set
            {
                _iest_level = value;
            }
        }

        public int Iemp_ref_id
        {
            get
            {
                return _iemp_ref_id;
            }
            set
            {
                _iemp_ref_id = value;
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

        public string Iopinion
        {
            get
            {
                return _iopinion;
            }
            set
            {
                _iopinion = value;
            }
        }

        public string Icomplete_yn
        {
            get
            {
                return _icomplete_yn;
            }
            set
            {
                _icomplete_yn = value;
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

        public DateTime Iwrite_date
        {
            get
            {
                return _iwrite_date;
            }
            set
            {
                _iwrite_date = value;
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

        #region ------------------------ [ Constructor ] ------------------------
        public Dac_Bsc_Validation_Group_Kpi() { }
        public Dac_Bsc_Validation_Group_Kpi(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, igroup_ref_id, iest_level, iemp_ref_id, ikpi_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id      = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0   : Convert.ToInt32 (dr["ESTTERM_REF_ID"]);
                _igroup_ref_id        = (dr["GROUP_REF_ID"]    == DBNull.Value) ? 0   : Convert.ToInt32 (dr["GROUP_REF_ID"]);
                _iest_level           = (dr["EST_LEVEL"]       == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EST_LEVEL"]);
                _iemp_ref_id          = (dr["EMP_REF_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EMP_REF_ID"]);
                _ikpi_ref_id          = (dr["KPI_REF_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["KPI_REF_ID"]);
                _iopinion             = (dr["OPINION"]         == DBNull.Value) ? ""  : Convert.ToString (dr["OPINION"]);
                _icomplete_yn         = (dr["COMPLETE_YN"]     == DBNull.Value) ? ""   : Convert.ToString (dr["COMPLETE_YN"]);
                _iwrite_date          = (dr["WRITE_DATE"]      == DBNull.Value) ? DateTime.MinValue  : Convert.ToDateTime(dr["WRITE_DATE"]);
                _create_user          = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date          = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user          = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date          = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion
        
        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int iestterm_ref_id, int  igroup_ref_id, int iest_level,  int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iemp_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iOPINION", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iopinion;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iemp_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iOPINION", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iopinion;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ConfirmOpnion_Dac(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "CO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iemp_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iOPINION", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iopinion;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_CONFIRM_OPNION"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iemp_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int CopyValuationKpiList_Dac(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int ifrom_emp_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "KC";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ifrom_emp_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_KPI_COPY"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_ALL"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iemp_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_ONE"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOpinionListPerKpi(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_KPI_OPINION"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListPerValidationUser(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, int igroup_ref_id, int iest_level, int ivalidation_user_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KL";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = iresult_input_type;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[5].Value         = iuse_yn;
            paramArray[6]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ichampion_name;
            paramArray[7]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = iest_dept_ref_id;
            paramArray[8]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[8].Value         = igroup_ref_id;
            paramArray[9]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[9].Value         = iest_level;
            paramArray[10]               = CreateDataParameter("@iVALIDATION_USER_ID", SqlDbType.Int);
            paramArray[10].Value         = ivalidation_user_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_KPI_LIST_PER_USER"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListPerValidationTarget(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, 
                                                     int igroup_ref_id, int iest_level, int ivalidation_user_id, string ikpi_group_ref_id, string ibasis_use_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KT";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = iresult_input_type;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[5].Value         = iuse_yn;
            paramArray[6]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ichampion_name;
            paramArray[7]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = iest_dept_ref_id;
            paramArray[8]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[8].Value         = igroup_ref_id;
            paramArray[9]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[9].Value         = iest_level;
            paramArray[10]              = CreateDataParameter("@iVALIDATION_USER_ID", SqlDbType.Int);
            paramArray[10].Value        = ivalidation_user_id;
            paramArray[11]              = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[11].Value        = ikpi_group_ref_id;
            paramArray[12]              = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
            paramArray[12].Value        = ibasis_use_yn;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_KPI_LIST_TARGET"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListNotAllocate(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, 
                                                     int igroup_ref_id, int iest_level, int ivalidation_user_id, string ikpi_group_ref_id, string ibasis_use_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "MA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = iresult_input_type;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[5].Value         = iuse_yn;
            paramArray[6]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ichampion_name;
            paramArray[7]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = iest_dept_ref_id;
            paramArray[8]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[8].Value         = igroup_ref_id;
            paramArray[9]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[9].Value         = iest_level;
            paramArray[10]              = CreateDataParameter("@iVALIDATION_USER_ID", SqlDbType.Int);
            paramArray[10].Value        = ivalidation_user_id;
            paramArray[11]              = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[11].Value        = ikpi_group_ref_id;
            paramArray[12]              = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
            paramArray[12].Value        = ibasis_use_yn;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_KPI_MUST_ALLOC"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiOpinionList(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, int igroup_ref_id, int iest_level, string ikpi_group_ref_id, string ibasis_use_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "AE";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = iresult_input_type;
            paramArray[3]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_code;
            paramArray[4]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_name;
            paramArray[5]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[5].Value         = iuse_yn;
            paramArray[6]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ichampion_name;
            paramArray[7]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = iest_dept_ref_id;
            paramArray[8]               = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
            paramArray[8].Value         = igroup_ref_id;
            paramArray[9]               = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
            paramArray[9].Value         = iest_level;
	        paramArray[10] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[10].Value 	    = ikpi_group_ref_id;
	        paramArray[11] 		        = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
	        paramArray[11].Value 	    = ibasis_use_yn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP_KPI", "PKG_BSC_VALIDATION_GROUP_KPI.PROC_SELECT_KPI_AFTER_EST"), "BSC_VALIDATION_GROUP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        #endregion
    }
}
