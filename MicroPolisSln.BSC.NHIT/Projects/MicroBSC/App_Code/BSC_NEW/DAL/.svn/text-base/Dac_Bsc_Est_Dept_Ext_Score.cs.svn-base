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
    public class Dac_Bsc_Est_Dept_Ext_Score: DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int      _iestterm_ref_id  ;
        private string   _iymd             ;
        private int      _iest_dept_ref_id ;
        private double   _iweight_inr      ;
        private double   _iweight_ext      ;
        private double   _ipoints_ext      ;
        private string   _iuse_yn          ;
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

        public string Iymd
        {
            get 
            {
	            return _iymd;
            }
            set
            {
	            _iymd = ( value==null ? "" : value );
            }
        }
 
        public int Iest_dept_ref_id
        { 
            get
            {
                return _iest_dept_ref_id;
            }
            set
            {
                _iest_dept_ref_id = value;
            }
        }

        public double Iweight_inr
        { 
            get
            {
                return _iweight_inr;
            }
            set
            {
                _iweight_inr = value;
            }
        }

        public double Iweight_ext
        { 
            get
            {
                return _iweight_ext;
            }
            set
            {
                _iweight_ext = value;
            }
        }

        public double Ipoints_ext
        { 
            get
            {
                return _ipoints_ext;
            }
            set
            {
                _ipoints_ext = value;
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
        public Dac_Bsc_Est_Dept_Ext_Score() { }
        public Dac_Bsc_Est_Dept_Ext_Score(int iestterm_ref_id, string iymd, int iest_dept_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, iymd, iest_dept_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id         = (dr["ESTTERM_REF_ID"]  == DBNull.Value ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]));
                _iymd                    = (dr["YMD"]             == DBNull.Value ? "" : Convert.ToString(dr["YMD"]));
                _iest_dept_ref_id        = (dr["EST_DEPT_REF_ID"] == DBNull.Value ? 0  : Convert.ToInt32(dr["EST_DEPT_REF_ID"]));
                _iweight_inr             = (dr["WEIGHT_INR"]      == DBNull.Value ? 0  : Convert.ToDouble(dr["WEIGHT_INR"]));
                _iweight_ext             = (dr["WEIGHT_EXT"]      == DBNull.Value ? 0  : Convert.ToDouble(dr["WEIGHT_EXT"]));
                _ipoints_ext             = (dr["POINTS_EXT"]      == DBNull.Value ? 0  : Convert.ToDouble(dr["POINTS_EXT"]));
                _iuse_yn                 = (dr["USE_YN"]          == DBNull.Value ? "N" : Convert.ToString(dr["USE_YN"]));
                _create_user             = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ====================== [ Method ] ======================
        internal protected int InsertData_Dac(int iestterm_ref_id, string iymd, int iest_dept_ref_id
                                            , double iweight_inr, double iweight_ext, double ipoints_ext, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd ;
	        paramArray[3] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_dept_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iWEIGHT_INR", SqlDbType.Decimal);
	        paramArray[4].Value 	    = iweight_inr;
	        paramArray[5] 		        = CreateDataParameter("@iWEIGHT_EXT", SqlDbType.Decimal);
	        paramArray[5].Value 	    = iweight_ext;
	        paramArray[6] 		        = CreateDataParameter("@iPOINTS_EXT", SqlDbType.Decimal);
	        paramArray[6].Value 	    = ipoints_ext;
            paramArray[7] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[7].Value 	    = iuse_yn;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_EST_DEPT_EXT_SCORE", "PKG_BSC_EST_DEPT_EXT_SCORE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, string iymd, int iest_dept_ref_id
                                            , double iweight_inr, double iweight_ext, double ipoints_ext, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd ;
	        paramArray[3] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_dept_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iWEIGHT_INR", SqlDbType.Decimal);
	        paramArray[4].Value 	    = iweight_inr;
	        paramArray[5] 		        = CreateDataParameter("@iWEIGHT_EXT", SqlDbType.Decimal);
	        paramArray[5].Value 	    = iweight_ext;
	        paramArray[6] 		        = CreateDataParameter("@iPOINTS_EXT", SqlDbType.Decimal);
	        paramArray[6].Value 	    = ipoints_ext;
            paramArray[7] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[7].Value 	    = iuse_yn;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_EST_DEPT_EXT_SCORE", "PKG_BSC_EST_DEPT_EXT_SCORE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd ;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value 	    = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_EST_DEPT_EXT_SCORE", "PKG_BSC_EST_DEPT_EXT_SCORE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, string iymd, int idept_type_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd ;
	        paramArray[3] 		        = CreateDataParameter("@iDEPT_TYPE_ID", SqlDbType.VarChar);
	        paramArray[3].Value 	    = idept_type_id ;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_EST_DEPT_EXT_SCORE", "PKG_BSC_EST_DEPT_EXT_SCORE.PROC_SELECT_ALL"), "BSC_EST_DEPT_EXT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, string iymd, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd ;
	        paramArray[3] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_EST_DEPT_EXT_SCORE", "PKG_BSC_EST_DEPT_EXT_SCORE.PROC_SELECT_ONE"), "BSC_EST_DEPT_EXT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

    }

}