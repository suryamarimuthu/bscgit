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
/// Dac_Bsc_Kpi_Datasource에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Threshold_Info Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.30
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Threshold_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;
        private int 	 _ikpi_ref_id;
        private int 	 _ithreshold_ref_id;
        private string 	 _ithreshold_level;
        private double 	 _iset_min_value;
        private double 	 _iset_max_value;
        private double 	 _iachieve_rate;
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
         
        public int Ithreshold_ref_id
        {
	        get 
	        {
		        return _ithreshold_ref_id;
	        }
	        set
	        {
		        _ithreshold_ref_id = value;
	        }
        }
         
        public string Ithreshold_level
        {
	        get 
	        {
		        return _ithreshold_level;
	        }
	        set
	        {
		        _ithreshold_level = ( value==null ? "" : value );
	        }
        }
         
        public double Iset_min_value
        {
	        get 
	        {
		        return _iset_min_value;
	        }
	        set
	        {
		        _iset_min_value = value;
	        }
        }
         
        public double Iset_max_value
        {
	        get 
	        {
		        return _iset_max_value;
	        }
	        set
	        {
		        _iset_max_value = value;
	        }
        }
         
        public double Iachieve_rate
        {
	        get 
	        {
		        return _iachieve_rate;
	        }
	        set
	        {
		        _iachieve_rate = value;
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
        public Dac_Bsc_Kpi_Threshold_Info() { }

        public Dac_Bsc_Kpi_Threshold_Info(int iestterm_ref_id, int ikpi_ref_id, int ithreshold_ref_id, string ithreshold_level)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, ithreshold_ref_id, ithreshold_level);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
		        _iestterm_ref_id   = (dr["ESTTERM_REF_ID"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _ikpi_ref_id       = (dr["KPI_REF_ID"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
		        _ithreshold_ref_id = (dr["THRESHOLD_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["THRESHOLD_REF_ID"]);
		        _ithreshold_level  = (dr["THRESHOLD_LEVEL"]  == DBNull.Value) ? "" : Convert.ToString(dr["THRESHOLD_LEVEL"]);
		        _iset_min_value    = (dr["SET_MIN_VALUE"]    == DBNull.Value) ? 0 : Convert.ToDouble(dr["SET_MIN_VALUE"]);
		        _iset_max_value    = (dr["SET_MAX_VALUE"]    == DBNull.Value) ? 0 : Convert.ToDouble(dr["SET_MAX_VALUE"]);
		        _iachieve_rate     = (dr["ACHIEVE_RATE"]     == DBNull.Value) ? 0 : Convert.ToDouble(dr["ACHIEVE_RATE"]);
                _create_user       = (dr["CREATE_USER"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date       = (dr["CREATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user       = (dr["UPDATE_USER"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date       = (dr["UPDATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
	        }

        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac( int    iestterm_ref_id,  int    ikpi_ref_id,    int    ithreshold_ref_id, 
                                               string ithreshold_level, double iset_min_value, double iset_max_value, 
                                               double iachieve_rate,    int    itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@iSET_MIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value         = iset_min_value;
	        paramArray[6] 		        = CreateDataParameter("@iSET_MAX_VALUE", SqlDbType.Decimal);
	        paramArray[6].Value         = iset_max_value;
	        paramArray[7] 		        = CreateDataParameter("@iACHIEVE_RATE", SqlDbType.Decimal);
	        paramArray[7].Value         = iachieve_rate;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value         = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;

        }

        internal protected int UpdateData_Dac( int    iestterm_ref_id,  int    ikpi_ref_id,    int    ithreshold_ref_id, 
                                               string ithreshold_level, double iset_min_value, double iset_max_value, 
                                               double iachieve_rate,    int    itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@iSET_MIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value         = iset_min_value;
	        paramArray[6] 		        = CreateDataParameter("@iSET_MAX_VALUE", SqlDbType.Decimal);
	        paramArray[6].Value         = iset_max_value;
	        paramArray[7] 		        = CreateDataParameter("@iACHIEVE_RATE", SqlDbType.Decimal);
	        paramArray[7].Value         = iachieve_rate;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value         = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac( int    iestterm_ref_id,  int    ikpi_ref_id,    int    ithreshold_ref_id, 
                                               string ithreshold_level, int    itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value         = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteAllData_Dac( int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value         = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);
          
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int InsertData_Dac( IDbConnection conn, IDbTransaction trx, 
                                               int    iestterm_ref_id,  int    ikpi_ref_id,    int    ithreshold_ref_id, 
                                               string ithreshold_level, double iset_min_value, double iset_max_value, 
                                               double iachieve_rate,    int    itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@iSET_MIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value         = iset_min_value;
	        paramArray[6] 		        = CreateDataParameter("@iSET_MAX_VALUE", SqlDbType.Decimal);
	        paramArray[6].Value         = iset_max_value;
	        paramArray[7] 		        = CreateDataParameter("@iACHIEVE_RATE", SqlDbType.Decimal);
	        paramArray[7].Value         = iachieve_rate;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value         = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);


            this.Transaction_Message =  GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result =   GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;

        }

        internal protected int UpdateData_Dac( IDbConnection conn, IDbTransaction trx, 
                                               int    iestterm_ref_id,  int    ikpi_ref_id,    int    ithreshold_ref_id, 
                                               string ithreshold_level, double iset_min_value, double iset_max_value, 
                                               double iachieve_rate,    int    itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@iSET_MIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value         = iset_min_value;
	        paramArray[6] 		        = CreateDataParameter("@iSET_MAX_VALUE", SqlDbType.Decimal);
	        paramArray[6].Value         = iset_max_value;
	        paramArray[7] 		        = CreateDataParameter("@iACHIEVE_RATE", SqlDbType.Decimal);
	        paramArray[7].Value         = iachieve_rate;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value         = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, 
                                               int    iestterm_ref_id,  int    ikpi_ref_id,    int    ithreshold_ref_id, 
                                               string ithreshold_level, int    itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value         = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);            
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteAllData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "DA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value         = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);
           
            
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_SELECT_ALL"), "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, int ithreshold_ref_id, string ithreshold_level)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ithreshold_ref_id;
            paramArray[4]               = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[4].Value         = ithreshold_level;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_SELECT_ONE"), "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

//        /// <summary>
//        /// 지표별 등급구간조회
//        /// </summary>
//        /// <param name="iestterm_ref_id"></param>
//        /// <param name="ikpi_ref_id"></param>
//        /// <param name="ithreshold_level"></param>
//        /// <returns></returns>
//        public DataSet GetSignalListPerKpi(int iestterm_ref_id, int ikpi_ref_id, string ithreshold_level)
//        {
//            //IDbDataParameter[] paramArray = CreateDataParameters(4);

//            //paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
//            //paramArray[0].Value         = "SK";
//            //paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
//            //paramArray[1].Value         = iestterm_ref_id;
//            //paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
//            //paramArray[2].Value         = ikpi_ref_id;
//            //paramArray[3]               = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
//            //paramArray[3].Value         = ithreshold_level;

//            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_SELECT_SIGNAL"), "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.StoredProcedure);
//            //return ds;

//            string strQuery = @"
//IF EXISTS(SELECT * FROM BSC_KPI_THRESHOLD_INFO WHERE    ESTTERM_REF_ID  = @iESTTERM_REF_ID 
//                                                    AND KPI_REF_ID      = @iKPI_REF_ID     
//                                                    AND THRESHOLD_LEVEL = @iTHRESHOLD_LEVEL )
//BEGIN
//    SELECT  TC.THRESHOLD_ENAME            as SIGNAL
//           ,TC.IMAGE_FILE_NAME            as IMAG_PATH
//           ,TC.THRESHOLD_KNAME            as THRS_DESC
//           ,KT.SET_MIN_VALUE              as SET_MIN_VALUE
//           ,ROUND(KT.ACHIEVE_RATE,2)      as ACHIEVE_RATE 
//           ,ROUND(TS.POINT,0)             as POINT
//           --,ROUND(KT.SET_MIN_VALUE,2)     as SET_MIN_VALUE
//           --,ROUND(KT.ACHIEVE_RATE,2)      as ACHIEVE_RATE 
//           --,ROUND(TS.POINT,0)             as POINT
//           ,TS.BASE_LINE_YN               as BASE_LINE_YN
//           ,KT.KPI_REF_ID                 as KPI_REF_ID
//           ,KT.THRESHOLD_REF_ID           as THRESHOLD_REF_ID
//           ,KT.THRESHOLD_LEVEL            as THRESHOLD_LEVEL
//           FROM BSC_KPI_THRESHOLD_INFO KT
//                LEFT JOIN BSC_THRESHOLD_STEP TS
//                  ON KT.THRESHOLD_REF_ID = TS.THRESHOLD_REF_ID
//                 AND KT.THRESHOLD_LEVEL  = TS.THRESHOLD_LEVEL
//                LEFT JOIN BSC_THRESHOLD_CODE TC
//                  ON KT.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
//          WHERE KT.ESTTERM_REF_ID   = @iESTTERM_REF_ID
//            AND KT.KPI_REF_ID       = @iKPI_REF_ID
//            AND TS.THRESHOLD_LEVEL  = @iTHRESHOLD_LEVEL    
//          ORDER BY KT.ESTTERM_REF_ID, 
//                   KT.KPI_REF_ID, 
//                   TC.SEQUENCE   
//    END
// ELSE
//    BEGIN
//         SELECT TC.THRESHOLD_ENAME   as SIGNAL
//               ,TC.IMAGE_FILE_NAME   as IMAG_PATH
//               ,TC.THRESHOLD_KNAME   as THRS_DESC
//               ,0                    as SET_MIN_VALUE
//               ,0.00                 as ACHIEVE_RATE 
//               ,TS.POINT             as POINT
//               ,TS.BASE_LINE_YN      as BASE_LINE_YN
//               ,@iKPI_REF_ID         as KPI_REF_ID
//               ,TC.THRESHOLD_REF_ID  as THRESHOLD_REF_ID
//               ,TS.THRESHOLD_LEVEL   as THRESHOLD_LEVEL
//           FROM BSC_THRESHOLD_CODE TC
//                LEFT JOIN BSC_THRESHOLD_STEP TS
//                  ON TC.THRESHOLD_REF_ID = TS.THRESHOLD_REF_ID
//          WHERE TS.THRESHOLD_LEVEL       = @iTHRESHOLD_LEVEL  
//          ORDER BY TS.SEQUENCE
//    END
//";
//            IDbDataParameter[] paramArray = CreateDataParameters(3);

//            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
//            paramArray[0].Value = iestterm_ref_id;
//            paramArray[1] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
//            paramArray[1].Value = ikpi_ref_id;
//            paramArray[2] = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
//            paramArray[2].Value = ithreshold_level;

//            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
//            return ds;
//        }




        /// <summary>
        /// 지표별 등급구간 조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="ithreshold_level"></param>
        /// <returns></returns>
        public DataSet SelectSignalListPerKpiWithStepCode(int iestterm_ref_id, int ikpi_ref_id, string ithreshold_level)
        {
            
            string strQuery = @"

    SELECT  TC.THRESHOLD_ENAME            as SIGNAL
           ,TC.IMAGE_FILE_NAME            as IMAG_PATH
           ,TC.THRESHOLD_KNAME            as THRS_DESC
           ,KT.SET_MIN_VALUE              as SET_MIN_VALUE
           ,ROUND(KT.ACHIEVE_RATE,2)      as ACHIEVE_RATE 
           ,ROUND(TS.POINT,0)             as POINT
           --,ROUND(KT.SET_MIN_VALUE,2)     as SET_MIN_VALUE
           --,ROUND(KT.ACHIEVE_RATE,2)      as ACHIEVE_RATE 
           --,ROUND(TS.POINT,0)             as POINT
           ,TS.BASE_LINE_YN               as BASE_LINE_YN
           ,KT.KPI_REF_ID                 as KPI_REF_ID
           ,KT.THRESHOLD_REF_ID           as THRESHOLD_REF_ID
           ,KT.THRESHOLD_LEVEL            as THRESHOLD_LEVEL
           FROM BSC_KPI_THRESHOLD_INFO KT
                LEFT JOIN BSC_THRESHOLD_STEP TS
                  ON KT.THRESHOLD_REF_ID = TS.THRESHOLD_REF_ID
                 AND KT.THRESHOLD_LEVEL  = TS.THRESHOLD_LEVEL
                LEFT JOIN BSC_THRESHOLD_CODE TC
                  ON KT.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
          WHERE KT.ESTTERM_REF_ID   = @iESTTERM_REF_ID
            AND KT.KPI_REF_ID       = @iKPI_REF_ID
            AND TS.THRESHOLD_LEVEL  = @iTHRESHOLD_LEVEL    
          ORDER BY KT.ESTTERM_REF_ID, 
                   KT.KPI_REF_ID, 
                   TC.SEQUENCE   
    
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = ikpi_ref_id;
            paramArray[2] = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[2].Value = ithreshold_level;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 지표별 등급구간 조회
        /// 결과 조회 불가로 쿼리 수정 후 오버로딩(BSC0302M1.asox)
        /// 원래코드는 아래에 있음
        /// </summary>
        public DataSet SelectSignalListPerKpiWithStep(int ikpi_ref_id, string ithreshold_level, int iestterm_ref_id)
        {

            string strQuery = @"

   
         SELECT TC.THRESHOLD_ENAME   as SIGNAL
               ,TC.IMAGE_FILE_NAME   as IMAG_PATH
               ,TC.THRESHOLD_KNAME   as THRS_DESC
               ,KT.SET_MIN_VALUE              as SET_MIN_VALUE
               ,ROUND(KT.ACHIEVE_RATE,2)      as ACHIEVE_RATE 
               --,0                  as SET_MIN_VALUE
               --,0.00               as ACHIEVE_RATE 
               ,TS.POINT             as POINT
               ,TS.BASE_LINE_YN      as BASE_LINE_YN
               ,@iKPI_REF_ID         as KPI_REF_ID
               ,TC.THRESHOLD_REF_ID  as THRESHOLD_REF_ID
               ,TS.THRESHOLD_LEVEL   as THRESHOLD_LEVEL
           FROM BSC_THRESHOLD_CODE TC
                LEFT JOIN BSC_THRESHOLD_STEP TS
                  ON TC.THRESHOLD_REF_ID = TS.THRESHOLD_REF_ID
                LEFT JOIN BSC_KPI_THRESHOLD_INFO KT
                  ON Tc.THRESHOLD_REF_ID = KT.THRESHOLD_REF_ID
          WHERE TS.THRESHOLD_LEVEL       = @iTHRESHOLD_LEVEL  
            AND KT.KPI_REF_ID            = @iKPI_REF_ID
            AND ( KT.ESTTERM_REF_ID      = @iESTTERM_REF_ID   OR  @iESTTERM_REF_ID    =   0  )
          ORDER BY TS.SEQUENCE
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = ikpi_ref_id;
            paramArray[1] = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value = ithreshold_level;
            paramArray[2] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }
        /// <summary>
        /// 원래 코드
        /// </summary>
        public DataSet SelectSignalListPerKpiWithStep(int ikpi_ref_id, string ithreshold_level)
        {
            string strQuery = @"

   
         SELECT TC.THRESHOLD_ENAME   as SIGNAL
               ,TC.IMAGE_FILE_NAME   as IMAG_PATH
               ,TC.THRESHOLD_KNAME   as THRS_DESC
               ,0                    as SET_MIN_VALUE
               ,0.00                 as ACHIEVE_RATE 
               ,TS.POINT             as POINT
               ,TS.BASE_LINE_YN      as BASE_LINE_YN
               ,@iKPI_REF_ID         as KPI_REF_ID
               ,TC.THRESHOLD_REF_ID  as THRESHOLD_REF_ID
               ,TS.THRESHOLD_LEVEL   as THRESHOLD_LEVEL
           FROM BSC_THRESHOLD_CODE TC
                LEFT JOIN BSC_THRESHOLD_STEP TS
                  ON TC.THRESHOLD_REF_ID = TS.THRESHOLD_REF_ID
          WHERE TS.THRESHOLD_LEVEL       = @iTHRESHOLD_LEVEL  
          ORDER BY TS.SEQUENCE
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = ikpi_ref_id;
            paramArray[1] = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value = ithreshold_level;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }






        /// <summary>
        /// 지표별 등급구간조회  데이터 확인
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="ithreshold_level"></param>
        /// <returns></returns>
        public DataSet SelectkpiThresholdInfo(int iestterm_ref_id
                                         , int ikpi_ref_id
                                         , string ithreshold_level)
        {

            string strQuery = @"
SELECT ESTTERM_REF_ID 
     , KPI_REF_ID
     , THRESHOLD_REF_ID
     , THRESHOLD_LEVEL
     , SET_MIN_VALUE
     , SET_MAX_VALUE
     , ACHIEVE_RATE
     , CREATE_DATE
     , CREATE_USER
     , UPDATE_DATE
     , UPDATE_USER
FROM BSC_KPI_THRESHOLD_INFO WHERE   ESTTERM_REF_ID  = @iESTTERM_REF_ID 
                                AND KPI_REF_ID      = @iKPI_REF_ID     
                                AND THRESHOLD_LEVEL = @iTHRESHOLD_LEVEL
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = ikpi_ref_id;
            paramArray[2] = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[2].Value = ithreshold_level;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet GetMBOSignalListPerKpi(int estterm_ref_id, int kpi_ref_id, string threshold_level)
        {
            string strQuery = @"
SELECT    A.THRESHOLD_ENAME AS SIGNAL
        , A.IMAGE_FILE_NAME AS IMAG_PATH
        , A.THRESHOLD_KNAME AS THRS_DESC
        , ISNULL(ROUND(B.SET_MIN_VALUE, 2), 0) AS SET_MIN_VALUE
        , ISNULL(B.SET_TXT_VALUE, '') AS SET_TXT_VALUE
        , ISNULL(ROUND(B.ACHIEVE_RATE, 2), 0.00) AS ACHIEVE_RATE
        , ROUND(C.POINT, 0) AS POINT
        , C.BASE_LINE_YN
        , ISNULL(B.KPI_REF_ID, @KPI_REF_ID) AS KPI_REF_ID
        , ISNULL(B.THRESHOLD_REF_ID, A.THRESHOLD_REF_ID) AS THRESHOLD_REF_ID
        , ISNULL(B.THRESHOLD_LEVEL, C.THRESHOLD_LEVEL) AS THRESHOLD_LEVEL
FROM    BSC_THRESHOLD_CODE              A
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  B ON    B.ESTTERM_REF_ID    = @ESTTERM_REF_ID   
                                            AND B.KPI_REF_ID        = @KPI_REF_ID   
                                            AND B.THRESHOLD_REF_ID  = A.THRESHOLD_REF_ID
                                            AND B.THRESHOLD_LEVEL   = @THRESHOLD_LEVEL
LEFT OUTER JOIN BSC_THRESHOLD_STEP      C ON    C.THRESHOLD_REF_ID  = A.THRESHOLD_REF_ID
                                            AND C.THRESHOLD_LEVEL   = @THRESHOLD_LEVEL
WHERE   C.THRESHOLD_LEVEL = @THRESHOLD_LEVEL
ORDER BY C.SEQUENCE
";
                               
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[2].Value = threshold_level;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_THRESHOLD", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 5년간 등급구간 추이 (그래프)
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="startYY"></param>
        /// <returns></returns>
        public DataSet GetTargetPerGrade(int iestterm_ref_id, int ikpi_ref_id, out int startYY)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SH";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@oSTART_YY", SqlDbType.VarChar, 4);
            paramArray[3].Direction         = ParameterDirection.Output;

            IDataParameterCollection col;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_SELECT_HIS_SIGNAL"), "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.StoredProcedure, out col);
            startYY    = (GetOutputParameterValueBySP(col,"@oSTART_YY").ToString()=="") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oSTART_YY").ToString());

            return ds;
        }

        /// <summary>
        /// 5년간 목표/실적현황(그리드)
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="startYY"></param>
        /// <returns></returns>
        public DataSet GetTargetResultPerYear(int iestterm_ref_id, int ikpi_ref_id, out int startYY)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "TR";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@oSTART_YY", SqlDbType.VarChar, 4);
            paramArray[3].Direction         = ParameterDirection.Output;

            IDataParameterCollection col;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_THRESHOLD_INFO", "PKG_BSC_KPI_THRESHOLD_INFO.PROC_SELECT_TR_STATUS"), "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.StoredProcedure, out col);
            startYY    = (GetOutputParameterValueBySP(col,"@oSTART_YY").ToString()=="") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oSTART_YY").ToString());

            return ds;
        }
        #endregion






        #region ========================== 멀티 DB 작업 ============================


        public int InsertData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object ithreshold_ref_id
                                , object ithreshold_level
                                , object iset_min_value
                                , object iset_txt_value
                                , object iset_max_value
                                , object iachieve_rate
                                , object itxr_user)
        {

            string query = @"

INSERT INTO BSC_KPI_THRESHOLD_INFO
    (ESTTERM_REF_ID
,   KPI_REF_ID
,   THRESHOLD_REF_ID
,   THRESHOLD_LEVEL
,   SET_MIN_VALUE
,   SET_TXT_VALUE
,   SET_MAX_VALUE
,   ACHIEVE_RATE
,   CREATE_DATE
,   CREATE_USER)
VALUES
    (@ESTTERM_REF_ID
,   @KPI_REF_ID
,   @THRESHOLD_REF_ID
,   @THRESHOLD_LEVEL
,   @SET_MIN_VALUE
,   @SET_TXT_VALUE
,   @SET_MAX_VALUE
,   @ACHIEVE_RATE
,   GETDATE()
,   @TXR_USER)

";

	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = ithreshold_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
	        paramArray[4].Value         = ithreshold_level;
	        paramArray[5] 		        = CreateDataParameter("@SET_MIN_VALUE", SqlDbType.Decimal);
	        paramArray[5].Value         = iset_min_value;
            paramArray[6] 		        = CreateDataParameter("@SET_TXT_VALUE", SqlDbType.Decimal);
            paramArray[6].Value         = iset_txt_value;
	        paramArray[7] 		        = CreateDataParameter("@SET_MAX_VALUE", SqlDbType.Decimal);
	        paramArray[7].Value         = iset_max_value;
	        paramArray[8] 		        = CreateDataParameter("@ACHIEVE_RATE", SqlDbType.Decimal);
	        paramArray[8].Value         = iachieve_rate;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;

        }

        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object estterm_ref_id
                                , object kpi_ref_id)
        {

            string query = @"
DELETE FROM BSC_KPI_THRESHOLD_INFO
WHERE   ESTTERM_REF_ID   = @ESTTERM_REF_ID
AND KPI_REF_ID       = @KPI_REF_ID

";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[0].Value         = estterm_ref_id;
	        paramArray[1] 		        = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;

        }

        #endregion


    }
}
