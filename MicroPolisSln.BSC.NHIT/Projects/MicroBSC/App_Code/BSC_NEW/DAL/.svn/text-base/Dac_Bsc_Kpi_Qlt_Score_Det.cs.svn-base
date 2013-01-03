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
    /// Class 명		@ Dac_Bsc_Kpi_Qlt_Score_Det Dac 클래스
    /// Class 내용		@ Bsc_Kpi_Qlt_Score_Det Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Qlt_Score_Det : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _iestterm_ref_id     ;
        private int      _igroup_ref_id       ;
        private int      _ikpi_ref_id         ;
        private int      _iest_emp_id         ;
        private int      _iest_level          ;    
        private string   _iymd                ;
        private int      _iquestion_ref_id    ;
        private double   _iscore              ;
        private string   _iscore_grade        ;
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

        public int Iquestion_ref_id
        {
            get
            {
                return _iquestion_ref_id;
            }
            set
            {
                _iquestion_ref_id = value;
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

        public string Iscore_grade
        {
            get
            {
                return _iscore_grade;
            }
            set
            {
                _iscore_grade = value;
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
        public Dac_Bsc_Kpi_Qlt_Score_Det() { }
        public Dac_Bsc_Kpi_Qlt_Score_Det(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, iquestion_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id      = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0   : Convert.ToInt32 (dr["ESTTERM_REF_ID"]);
                _igroup_ref_id        = (dr["GROUP_REF_ID"]    == DBNull.Value) ? 0   : Convert.ToInt32 (dr["GROUP_REF_ID"]);
                _ikpi_ref_id          = (dr["KPI_REF_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["KPI_REF_ID"]);
                _iest_emp_id          = (dr["EST_EMP_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EST_EMP_ID"]);
                _iest_level           = (dr["EST_LEVEL"]       == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EST_LEVEL"]);
                _iymd                 = (dr["YMD"]             == DBNull.Value) ? ""  : Convert.ToString (dr["YMD"]);
                _iquestion_ref_id     = (dr["QUESTION_REF_ID"] == DBNull.Value) ? 0   : Convert.ToInt32 (dr["QUESTION_REF_ID"]);
                _iscore               = (dr["SCORE"]           == DBNull.Value) ? 0   : Convert.ToDouble (dr["SCORE"]);
                _iscore_grade         = (dr["SCORE_GRADE"]     == DBNull.Value) ? ""  : Convert.ToString (dr["GRADE_GRADE"]);
                _create_user          = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date          = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user          = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date          = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                                              double iscore, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = iquestion_ref_id;
	        paramArray[8] 		        = CreateDataParameter("@iSCORE", SqlDbType.Decimal);
	        paramArray[8].Value 	    = iscore;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                                              double iscore, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = iquestion_ref_id;
	        paramArray[8] 		        = CreateDataParameter("@iSCORE", SqlDbType.Decimal);
	        paramArray[8].Value 	    = iscore;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = iquestion_ref_id;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 평가항목 점수평가
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="iquestion_ref_id"></param>
        /// <param name="iscore"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int EstQuestionItem_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                                              double iscore, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "EQ";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = iquestion_ref_id;
	        paramArray[8] 		        = CreateDataParameter("@iSCORE", SqlDbType.Decimal);
	        paramArray[8].Value 	    = iscore;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_EST_QUESTION_ITEM"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int EstQuestionItemGrade_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                                              string iscore_grade, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "UQ";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = iquestion_ref_id;
	        paramArray[8] 		        = CreateDataParameter("@iSCORE_GRADE", SqlDbType.VarChar);
	        paramArray[8].Value 	    = iscore_grade;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_EST_QUESTION_GRADE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 평가점수확정
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int EstConfirm_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "EC";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_EST_CONFIRM"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 평가점수 확정 취소
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int EstCancel_Dac(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "EL";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_EST_CANCEL"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_SELECT_ALL"), "BSC_KPI_QLT_SCORE_DET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = ikpi_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iEST_EMP_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_emp_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[6].Value 	    = iest_level;
	        paramArray[7] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = iquestion_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_SELECT_ONE"), "BSC_KPI_QLT_SCORE_DET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가자별 평가항목조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="iest_level"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetQuestionListPerEstEmp(int iestterm_ref_id, int igroup_ref_id, int iest_level, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SP";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = igroup_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_SELECT_ITEM_PER_ESTEMP"), "BSC_KPI_QLT_SCORE_DET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가자별 
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iresult_input_type"></param>
        /// <param name="ikpi_code"></param>
        /// <param name="ikpi_name"></param>
        /// <param name="ichampion_name"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="ikpi_group_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetQLTEstListPerEstEmp(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string ichampion_name, int iest_dept_ref_id, string iymd, string ikpi_group_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SQ";
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_SCORE_DET", "PKG_BSC_KPI_QLT_SCORE_DET.PROC_SELECT_KPI_QLT_PER_ESTEMP"), "BSC_KPI_QLT_SCORE_DET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
}