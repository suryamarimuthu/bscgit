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
    public class Dac_Bsc_Kpi_Qlt_Score_Had : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _iestterm_ref_id     ;
        private string   _iymd                ;
        private int      _ikpi_ref_id         ;
        private int      _igroup_ref_id       ;
        private int      _iest_level          ;      
        private int      _iest_emp_id         ;      
        private double   _iscore              ;
        private string   _istatus             ;
        private string   _iopinion            ;
        private string   _ireview_file_id     ;
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

        public string Iymd
        {
            get
            { 
                return _iymd;
            }
            set
            { 
                _iymd = value;
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

        public int Iest_emp_id
        {
            get
            {
                return _iest_emp_id;
            }
            set
            {
                _iest_emp_id = value;
            }
        }

        public double Iscore
        {
            get
            {
                return _iscore;
            }
            set
            {
                _iscore = value;
            }
        }

        public string Istatus
        {
            get
            { 
                return _istatus;
            }
            set
            { 
                _istatus = value;
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

        public string Ireview_file_id
        {
            get
            {
                return _ireview_file_id;
            }
            set
            {
                _ireview_file_id = value;
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

        #region ------------------------ [ Constructor ] ------------------------
        public Dac_Bsc_Kpi_Qlt_Score_Had() { }
        public Dac_Bsc_Kpi_Qlt_Score_Had(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, iymd, igroup_ref_id, ikpi_ref_id, iest_level, iest_emp_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id      = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0   : Convert.ToInt32 (dr["ESTTERM_REF_ID"]);
                _iymd                 = (dr["YMD"]             == DBNull.Value) ? "0000" : Convert.ToString  (dr["YMD"]);
                _igroup_ref_id        = (dr["GROUP_REF_ID"]    == DBNull.Value) ? 0   : Convert.ToInt32 (dr["GROUP_REF_ID"]);
                _ikpi_ref_id          = (dr["KPI_REF_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["KPI_REF_ID"]);
                _iest_level           = (dr["EST_LEVEL"]       == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EST_LEVEL"]);
                _iest_emp_id          = (dr["EST_EMP_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EST_EMP_ID"]);
                _iscore               = (dr["SCORE"]           == DBNull.Value) ? 0   : Convert.ToDouble(dr["SCORE"]);
                _istatus              = (dr["STATUS"]          == DBNull.Value) ? "N" : Convert.ToString  (dr["STATUS"]);
                _iopinion             = (dr["OPINION"]         == DBNull.Value) ? ""  : Convert.ToString  (dr["OPINION"]);
                _ireview_file_id      = (dr["REVIEW_FILE_ID"]  == DBNull.Value) ? ""  : Convert.ToString  (dr["REVIEW_FILE_ID"]);
                _create_user          = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date          = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user          = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date          = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion


        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, double iscore,
                                              string istatus,  string iopinion, string ireview_file_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(14);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_level;
	        paramArray[6] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_emp_id;
	        paramArray[7] 		        = CreateDataParameter("@iSCORE", SqlDbType.Decimal);
	        paramArray[7].Value 	    = iscore;
	        paramArray[8] 		        = CreateDataParameter("@iSTATUS", SqlDbType.VarChar);
	        paramArray[8].Value 	    = istatus;
	        paramArray[9] 		        = CreateDataParameter("@iOPINION", SqlDbType.VarChar);
	        paramArray[9].Value 	    = iopinion;
	        paramArray[10] 		        = CreateDataParameter("@iREVIEW_FILE_ID", SqlDbType.VarChar);
	        paramArray[10].Value 	    = ireview_file_id;
	        paramArray[11] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[11].Value 	    = itxr_user;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
	        paramArray[13] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[13].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, double iscore,
                                              string istatus,  string iopinion, string ireview_file_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(14);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_level;
	        paramArray[6] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_emp_id;
	        paramArray[7] 		        = CreateDataParameter("@iSCORE", SqlDbType.Decimal);
	        paramArray[7].Value 	    = iscore;
	        paramArray[8] 		        = CreateDataParameter("@iSTATUS", SqlDbType.VarChar);
	        paramArray[8].Value 	    = istatus;
	        paramArray[9] 		        = CreateDataParameter("@iOPINION", SqlDbType.VarChar);
	        paramArray[9].Value 	    = iopinion;
	        paramArray[10] 		        = CreateDataParameter("@iREVIEW_FILE_ID", SqlDbType.VarChar);
	        paramArray[10].Value 	    = ireview_file_id;
	        paramArray[11] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[11].Value 	    = itxr_user;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
	        paramArray[13] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[13].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_level;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ConfirmOpinion_Dac(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "EC";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_level;
	        paramArray[6] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_emp_id;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_EST_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int CancelOpinion_Dac(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "EL";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_level;
	        paramArray[6] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_emp_id;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_EST_CANCEL"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_ALL"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_level;
	        paramArray[6] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_ONE"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
               

        /// <summary>
        /// 평가자별 지표 리스트
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="iest_level"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public DataSet GetKpiTargetListPerEstUser(int iestterm_ref_id, string iymd, int igroup_ref_id, int iest_level, int iest_emp_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_level;
	        paramArray[5] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_emp_id;
	        paramArray[6] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_KPI_LIST_PER_USER"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가자별 평가지표 대상 리스트
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="iest_level"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public DataSet GetKpiTargetList(int iestterm_ref_id, string iymd, int igroup_ref_id, int iest_level, int iest_emp_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KT";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_level;
	        paramArray[5] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iest_emp_id;
	        paramArray[6] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_KPI_LIST_TARGET"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가된 지표리스트
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public DataSet GetKpiEstCompleteList(int iestterm_ref_id, string iymd, int igroup_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "AE";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igroup_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_KPI_AFTER_EST"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가자별 Bias 조정결과 현황그래프조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <returns></returns>
        public DataSet GetEstEmpBiasGraphList(int iestterm_ref_id, string iymd, int iest_level, int igroup_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "AD";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = igroup_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_EST_ADJUST"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 지표별 Bias조정 결과 현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <returns></returns>
        public DataSet GetKpiEstAdjustList(int iestterm_ref_id, string iymd, int iest_level, int igroup_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "EB";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = igroup_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_HAD", "PKG_BSC_KPI_QLT_SCORE_HAD.PROC_SELECT_EST_BIAS"), "BSC_KPI_QLT_SCORE_HAD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion
    }
}