using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_EstDept_LoadMap의 요약 설명입니다.
    /// </summary>
    /// 
    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Est_Dept_Grade Dac 클래스
    /// Class 내용		@ Kpi_Pool Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Est_Dept_Grade : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int      _iestterm_ref_id ;
        private int      _iest_dept_type  ;
        private int      _igrade_ref_id   ;
        private string   _igrade_name     ;
        private double   _imin_value      ;
        private double   _imax_value      ;
        private int      _isort_order     ;
        private string   _iuse_yn         ;
        private Int32    _itxr_user;
        private int 	 _create_user;
        private DateTime _create_date;
        private int 	 _update_user;
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
        public int Iest_dept_type
        {
            get
            {
                return _iest_dept_type;
            }
            set
            {
                _iest_dept_type = value;
            }
        }
        public int Igrade_ref_id
        { 
            get
            {
                return _igrade_ref_id;
            }
            set
            {
                _igrade_ref_id = value;
            }
        }
         
        public string Igrade_name
        {
            get 
            {
	            return _igrade_name;
            }
            set
            {
	            _igrade_name = ( value==null ? "" : value );
            }
        }

        public double Imin_value
        { 
            get
            {
                return _imin_value;
            }
            set
            {
                _imin_value = value;
            }
        }

        public double Imax_value
        { 
            get
            {
                return _imax_value;
            }
            set
            {
                _imax_value = value;
            }
        }

        public int Isort_order
        {
            get 
            {
	            return _isort_order;
            }
            set
            {
	            _isort_order = value;
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
	            _iuse_yn = ( value==null ? "" : value );
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

        public int Create_user
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
         
        public int Update_user
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

        #region ====================== [ Constructor ] ======================
        public Dac_Bsc_Est_Dept_Grade() { }
        public Dac_Bsc_Est_Dept_Grade(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, iest_dept_type, igrade_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id         = (dr["ESTTERM_REF_ID"]  == DBNull.Value ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]));
                _iest_dept_type          = (dr["EST_DEPT_TYPE"]   == DBNull.Value ? 0  : Convert.ToInt32(dr["EST_DEPT_TYPE"]));
                _igrade_ref_id           = (dr["GRADE_REF_ID"]    == DBNull.Value ? 0  : Convert.ToInt32(dr["GRADE_REF_ID"]));
                _igrade_name             = (dr["GRADE_NAME"]      == DBNull.Value ? "" : Convert.ToString(dr["GRADE_NAME"]));
                _imin_value              = (dr["MIN_VALUE"]       == DBNull.Value ? 0  : Convert.ToDouble(dr["MIN_VALUE"]));
                _imax_value              = (dr["MAX_VALUE"]       == DBNull.Value ? 0  : Convert.ToDouble(dr["MAX_VALUE"]));
                _isort_order             = (dr["SORT_ORDER"]      == DBNull.Value ? 0  : Convert.ToInt32(dr["SORT_ORDER"]));
                _iuse_yn                 = (dr["USE_YN"]          == DBNull.Value ? "N" : Convert.ToString(dr["USE_YN"]));
                _create_user             = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ====================== [ Method ] ======================
        internal protected int InsertData_Dac(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id, string igrade_name
                                            , double imin_value, double imax_value, string imid_grade_yn, int isort_order, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_TYPE", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_type;
	        paramArray[3] 		        = CreateDataParameter("@iGRADE_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igrade_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iGRADE_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	    = igrade_name ;
	        paramArray[5] 		        = CreateDataParameter("@iMIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value 	    = imin_value;
	        paramArray[6] 		        = CreateDataParameter("@iMAX_VALUE", SqlDbType.Decimal);
	        paramArray[6].Value 	    = imax_value;
            paramArray[7]               = CreateDataParameter("@iMID_GRADE_YN", SqlDbType.VarChar);
            paramArray[7].Value         = imid_grade_yn;
	        paramArray[8] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[8].Value 	    = isort_order;
	        paramArray[9] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[9].Value 	    = iuse_yn;
	        paramArray[10] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[10].Value 	    = itxr_user;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_EST_DEPT_GRADE", "PKG_BSC_EST_DEPT_GRADE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            //this.Igrade_ref_id = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oLIST_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id, string igrade_name
                                            , double imin_value, double imax_value, string imid_grade_yn, int isort_order, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_TYPE", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_type;
	        paramArray[3] 		        = CreateDataParameter("@iGRADE_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igrade_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iGRADE_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	    = igrade_name ;
	        paramArray[5] 		        = CreateDataParameter("@iMIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value 	    = imin_value;
	        paramArray[6] 		        = CreateDataParameter("@iMAX_VALUE", SqlDbType.Decimal);
	        paramArray[6].Value 	    = imax_value;
            paramArray[7]               = CreateDataParameter("@iMID_GRADE_YN", SqlDbType.VarChar);
            paramArray[7].Value         = imid_grade_yn;
	        paramArray[8] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[8].Value 	    = isort_order;
	        paramArray[9] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[9].Value 	    = iuse_yn;
	        paramArray[10] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[10].Value 	    = itxr_user;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_EST_DEPT_GRADE", "PKG_BSC_EST_DEPT_GRADE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_TYPE", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_type;
	        paramArray[3] 		        = CreateDataParameter("@iGRADE_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igrade_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_EST_DEPT_GRADE", "PKG_BSC_EST_DEPT_GRADE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_TYPE", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_EST_DEPT_GRADE", "PKG_BSC_EST_DEPT_GRADE.PROC_SELECT_ALL"), "BSC_EST_DEPT_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_TYPE", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_type;
	        paramArray[3] 		        = CreateDataParameter("@iGRADE_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = igrade_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_EST_DEPT_GRADE", "PKG_BSC_EST_DEPT_GRADE.PROC_SELECT_ONE"), "BSC_EST_DEPT_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    
    }
}