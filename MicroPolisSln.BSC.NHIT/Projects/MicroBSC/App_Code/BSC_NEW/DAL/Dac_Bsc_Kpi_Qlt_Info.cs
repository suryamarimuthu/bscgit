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
    public class Dac_Bsc_Kpi_Qlt_Info : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _iestterm_ref_id     ;
        private int      _iest_level          ;
        private string   _iest_level_name     ;
        private string   _isettle_mean_yn     ;
        private string   _isettle_deviation_yn;
        private double   _iweight             ;
        private int      _iest_order          ;
        private string   _idescriptions       ;
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

        public string Iest_level_name
        {
            get
            {
                return _iest_level_name;
            }
            set
            {
                _iest_level_name = value;
            }
        }

        public string Isettle_mean_yn
        {
            get
            {
                return _isettle_mean_yn;
            }
            set
            {
                _isettle_mean_yn = value;
            }
        }

        public string Isettle_deviation_yn
        {
            get
            {
                return _isettle_deviation_yn;
            }
            set
            {
                _isettle_deviation_yn = value;
            }
        }

        public double Iweight
        {
            get
            { 
                return _iweight;
            }
            set
            { 
                _iweight = value;
            }
        }

        public int Iest_order
        {
            get
            { 
                return _iest_order;
            }
            set
            { 
                _iest_order = value;
            }
        }

        public string Idescriptions
        {
            get
            { 
                return _idescriptions;
            }
            set
            { 
                _idescriptions = value;
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
        public Dac_Bsc_Kpi_Qlt_Info() { }
        public Dac_Bsc_Kpi_Qlt_Info(int iestterm_ref_id, int iest_level) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, iest_level);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

		        _iestterm_ref_id         = (dr["ESTTERM_REF_ID"]      == DBNull.Value) ? 0  : Convert.ToInt32 (dr["ESTTERM_REF_ID"]);
                _iest_level              = (dr["EST_LEVEL"]           == DBNull.Value) ? 0  : Convert.ToInt32(dr["EST_LEVEL"]);
		        _iest_level_name         = (dr["EST_LEVEL_NAME"]      == DBNull.Value) ? "" : Convert.ToString(dr["EST_LEVEL_NAME"]);
		        _isettle_mean_yn         = (dr["SETTLE_MEAN_YN"]      == DBNull.Value) ? "" : Convert.ToString(dr["SETTLE_MEAN_YN"]);
                _isettle_deviation_yn    = (dr["SETTLE_DEVIATION_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["SETTLE_DEVIATION_YN"]);
                _iweight                 = (dr["WEIGHT"]              == DBNull.Value) ? 0  : Convert.ToDouble(dr["WEIGHT"]);
                _iest_order              = (dr["EST_ORDER"]           == DBNull.Value) ? 0  : Convert.ToInt32(dr["EST_ORDER"]);
                _idescriptions           = (dr["DESCRIPTIONS"]        == DBNull.Value) ? "" : Convert.ToString(dr["DESCRIPTIONS"]);
                _create_user             = (dr["CREATE_USER"]         == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]         == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]         == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]         == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int iestterm_ref_id, int iest_level, string iest_level_name, string isettle_mean_yn, string isettle_deviation_yn, double iweight, int iest_order, string idescriptions, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_level;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL_NAME", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iest_level_name;
	        paramArray[4] 		        = CreateDataParameter("@iSETTLE_MEAN_YN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = isettle_mean_yn;
	        paramArray[5] 		        = CreateDataParameter("@iSETTLE_DEVIATION_YN", SqlDbType.VarChar);
	        paramArray[5].Value 	    = isettle_deviation_yn;
	        paramArray[6] 		        = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
	        paramArray[6].Value 	    = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iEST_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = iest_order;
	        paramArray[8] 		        = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.VarChar);
	        paramArray[8].Value 	    = idescriptions;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_INFO", "PKG_BSC_KPI_QLT_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int iest_level, string iest_level_name, string isettle_mean_yn, string isettle_deviation_yn, double iweight, int iest_order, string idescriptions, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_level;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL_NAME", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iest_level_name;
	        paramArray[4] 		        = CreateDataParameter("@iSETTLE_MEAN_YN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = isettle_mean_yn;
	        paramArray[5] 		        = CreateDataParameter("@iSETTLE_DEVIATION_YN", SqlDbType.VarChar);
	        paramArray[5].Value 	    = isettle_deviation_yn;
	        paramArray[6] 		        = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
	        paramArray[6].Value 	    = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iEST_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = iest_order;
	        paramArray[8] 		        = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.VarChar);
	        paramArray[8].Value 	    = idescriptions;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_INFO", "PKG_BSC_KPI_QLT_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_level,  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_level;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value 	    = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_INFO", "PKG_BSC_KPI_QLT_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_INFO", "PKG_BSC_KPI_QLT_INFO.PROC_SELECT_ALL"), "BSC_KPI_GROUP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_level)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_level;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_INFO", "PKG_BSC_KPI_QLT_INFO.PROC_SELECT_ONE"), "BSC_KPI_GROUP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
}