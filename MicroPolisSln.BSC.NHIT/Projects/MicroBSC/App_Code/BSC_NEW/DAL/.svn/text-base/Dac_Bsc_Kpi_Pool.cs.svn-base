using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;


namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_mgr_svr3203에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Kpi_Pool Dac 클래스
    /// Class 내용		@ Kpi_Pool Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Pool : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int 	 _ikpi_pool_ref_id;
        private string 	 _ikpi_name;
        private string 	 _ikpi_desc;
        private string 	 _ikpi_type;
        private string 	 _ikpi_type_name;
        private string 	 _ikpi_external_type;
        private string 	 _ikpi_external_type_name;
        private string   _ibasis_use_yn;
        private string   _ivaluation_basis;
        private int      _icategory_top_ref_id;
        private int      _icategory_mid_ref_id;
        private int      _icategory_low_ref_id;
        private string 	 _iuse_yn;
        private Int32    _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
        private int _stg_ref_id;
        #endregion
         
        #region ------------------------ [ Property ] ------------------------
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

        public string Ikpi_desc
        {
            get
            {
                return _ikpi_desc;
            }
            set
            {
                _ikpi_desc = (value == null ? "" : value);
            }
        }

        public string Ikpi_type
        {
            get
            {
                return _ikpi_type;
            }
            set
            {
                _ikpi_type = (value == null ? "" : value);
            }
        }

        public string Ikpi_type_name
        {
            get
            {
                return _ikpi_type_name;
            }
            set
            {
                _ikpi_type_name = (value == null ? "" : value);
            }
        }

        public string Ikpi_external_type
        {
            get
            {
                return _ikpi_external_type;
            }
            set
            {
                _ikpi_external_type = (value == null ? "" : value);
            }
        }

        public string Ikpi_external_type_name
        {
            get
            {
                return _ikpi_external_type_name;
            }
            set
            {
                _ikpi_external_type_name = (value == null ? "" : value);
            }
        }

        public string Ibasis_use_yn
        {
            get
            { 
                return _ibasis_use_yn;
            }
            set
            { 
                _ibasis_use_yn = (value == null ? "" : value);
            }
        }

        public string Ivaluation_basis
        {
            get
            {
                return _ivaluation_basis;
            }
            set
            {
                _ivaluation_basis = (value == null ? "" : value);
            }
        }

   
        public int Icategory_top_ref_id
        {
            get
            {
                return _icategory_top_ref_id;
            }
            set
            {
                _icategory_top_ref_id = value;
            }
        }

        public int Icategory_mid_ref_id
        {
            get
            {
                return _icategory_mid_ref_id;
            }
            set
            {
                _icategory_mid_ref_id = value;
            }
        }

        public int Icategory_low_ref_id
        {
            get
            {
                return _icategory_low_ref_id;
            }
            set
            {
                _icategory_low_ref_id = value;
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

        public int STG_REF_ID
        {
            get
            {
                return _stg_ref_id;
            }
            set
            {
                _stg_ref_id = value;
            }
        }
        #endregion
         
        #region ------------------------ [ Constructor ] ------------------------
        public Dac_Bsc_Kpi_Pool() { }
        public Dac_Bsc_Kpi_Pool(int ikpi_pool_ref_id) 
        {
            DataSet ds = this.GetOneList(ikpi_pool_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

		        _ikpi_pool_ref_id        = (dr["KPI_POOL_REF_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_POOL_REF_ID"]);
		        _ikpi_name               = (dr["KPI_NAME"]               == DBNull.Value) ? "" : Convert.ToString(dr["KPI_NAME"]);
		        _ikpi_desc               = (dr["KPI_DESC"]               == DBNull.Value) ? "" : Convert.ToString(dr["KPI_DESC"]);
		        _ikpi_type               = (dr["KPI_GROUP_REF_ID"]       == DBNull.Value) ? "" : Convert.ToString(dr["KPI_GROUP_REF_ID"]);
                _ikpi_type_name          = (dr["KPI_GROUP_NAME"]         == DBNull.Value) ? "" : Convert.ToString(dr["KPI_GROUP_NAME"]);
		        _ikpi_external_type      = (dr["KPI_EXTERNAL_TYPE"]      == DBNull.Value) ? "" : Convert.ToString(dr["KPI_EXTERNAL_TYPE"]);
                _ikpi_external_type_name = (dr["KPI_EXTERNAL_TYPE_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["KPI_EXTERNAL_TYPE_NAME"]);
                _ibasis_use_yn           = (dr["BASIS_USE_YN"]           == DBNull.Value) ? "N" : Convert.ToString(dr["BASIS_USE_YN"]);
                _ivaluation_basis        = (dr["VALUATION_BASIS"]        == DBNull.Value) ? "" : Convert.ToString(dr["VALUATION_BASIS"]);
                _stg_ref_id = (dr["STG_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
              
                _icategory_top_ref_id    = (dr["CATEGORY_TOP_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CATEGORY_TOP_REF_ID"]);
                _icategory_mid_ref_id    = (dr["CATEGORY_MID_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CATEGORY_MID_REF_ID"]);
                _icategory_low_ref_id    = (dr["CATEGORY_LOW_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CATEGORY_LOW_REF_ID"]);
		        _iuse_yn                 = (dr["USE_YN"]                 == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user             = (dr["CREATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis,  int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(15);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
	        paramArray[1].Value 	    = ikpi_name;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_DESC", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ikpi_desc;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[3].Value 	    = ikpi_type;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
	        paramArray[4].Value 	    = ikpi_external_type;
	        paramArray[5] 		        = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
	        paramArray[5].Value 	    = ibasis_use_yn;
	        paramArray[6] 		        = CreateDataParameter("@iVALUATION_BASIS", SqlDbType.Text);
	        paramArray[6].Value 	    = ivaluation_basis;
	        paramArray[7] 		        = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = icategory_top_ref_id;
	        paramArray[8] 		        = CreateDataParameter("@iCATEGORY_MID_REF_ID", SqlDbType.Int);
	        paramArray[8].Value 	    = icategory_mid_ref_id;
	        paramArray[9] 		        = CreateDataParameter("@iCATEGORY_LOW_REF_ID", SqlDbType.Int);
	        paramArray[9].Value 	    = icategory_low_ref_id;
	        paramArray[10] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[10].Value 	    = iuse_yn;
	        paramArray[11] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[11].Value 	    = itxr_user;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
	        paramArray[13] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[13].Direction 	= ParameterDirection.Output ;
            paramArray[14]              = CreateDataParameter("@oRTN_KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[14].Direction    = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Ikpi_pool_ref_id       = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_KPI_POOL_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int InsertData_Dac(string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis, int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user, int stg_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[1].Value = ikpi_name;
            paramArray[2] = CreateDataParameter("@iKPI_DESC", SqlDbType.VarChar);
            paramArray[2].Value = ikpi_desc;
            paramArray[3] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_type;
            paramArray[4] = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = ikpi_external_type;
            paramArray[5] = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
            paramArray[5].Value = ibasis_use_yn;
            paramArray[6] = CreateDataParameter("@iVALUATION_BASIS", SqlDbType.Text);
            paramArray[6].Value = ivaluation_basis;
            paramArray[7] = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[7].Value = icategory_top_ref_id;
            paramArray[8] = CreateDataParameter("@iCATEGORY_MID_REF_ID", SqlDbType.Int);
            paramArray[8].Value = icategory_mid_ref_id;
            paramArray[9] = CreateDataParameter("@iCATEGORY_LOW_REF_ID", SqlDbType.Int);
            paramArray[9].Value = icategory_low_ref_id;
            paramArray[10] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[10].Value = iuse_yn;
            paramArray[11] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value = itxr_user;
            paramArray[12] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[12].Value = stg_ref_id;
            paramArray[13] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[13].Direction = ParameterDirection.Output;
            paramArray[14] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[14].Direction = ParameterDirection.Output;
            paramArray[15] = CreateDataParameter("@oRTN_KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[15].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_INSERT1"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Ikpi_pool_ref_id = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_KPI_POOL_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int ikpi_pool_ref_id, string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis,  int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(15);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ikpi_pool_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ikpi_name;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_DESC", SqlDbType.VarChar);
	        paramArray[3].Value 	    = ikpi_desc;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[4].Value 	    = ikpi_type;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
	        paramArray[5].Value 	    = ikpi_external_type;
	        paramArray[6] 		        = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
	        paramArray[6].Value 	    = ibasis_use_yn;
	        paramArray[7] 		        = CreateDataParameter("@iVALUATION_BASIS", SqlDbType.Text);
	        paramArray[7].Value 	    = ivaluation_basis;
	        paramArray[8] 		        = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
	        paramArray[8].Value 	    = icategory_top_ref_id;
	        paramArray[9] 		        = CreateDataParameter("@iCATEGORY_MID_REF_ID", SqlDbType.Int);
	        paramArray[9].Value 	    = icategory_mid_ref_id;
	        paramArray[10] 		        = CreateDataParameter("@iCATEGORY_LOW_REF_ID", SqlDbType.Int);
	        paramArray[10].Value 	    = icategory_low_ref_id;
	        paramArray[11] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[11].Value 	    = iuse_yn;
	        paramArray[12] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[12].Value 	    = itxr_user;
	        paramArray[13] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[13].Direction 	= ParameterDirection.Output ;
	        paramArray[14] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[14].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int ikpi_pool_ref_id, string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis, int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user, int stg_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1] = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value = ikpi_pool_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[2].Value = ikpi_name;
            paramArray[3] = CreateDataParameter("@iKPI_DESC", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_desc;
            paramArray[4] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[4].Value = ikpi_type;
            paramArray[5] = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = ikpi_external_type;
            paramArray[6] = CreateDataParameter("@iBASIS_USE_YN", SqlDbType.VarChar);
            paramArray[6].Value = ibasis_use_yn;
            paramArray[7] = CreateDataParameter("@iVALUATION_BASIS", SqlDbType.Text);
            paramArray[7].Value = ivaluation_basis;
            paramArray[8] = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[8].Value = icategory_top_ref_id;
            paramArray[9] = CreateDataParameter("@iCATEGORY_MID_REF_ID", SqlDbType.Int);
            paramArray[9].Value = icategory_mid_ref_id;
            paramArray[10] = CreateDataParameter("@iCATEGORY_LOW_REF_ID", SqlDbType.Int);
            paramArray[10].Value = icategory_low_ref_id;
            paramArray[11] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[11].Value = iuse_yn;
            paramArray[12] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value = itxr_user;
            paramArray[13] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[13].Value = stg_ref_id;
            paramArray[14] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[14].Direction = ParameterDirection.Output;
            paramArray[15] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[15].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_UPDATE1"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }



        internal protected int DeleteData_Dac(int ikpi_pool_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_pool_ref_id;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[4].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        internal protected int ReUsedData_Dac(int ikpi_pool_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value = ikpi_pool_ref_id;
            paramArray[2] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(string ikpi_name, string iKpiType, string iuse_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = ikpi_name;
            paramArray[2]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value         = iKpiType;
            paramArray[3]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[3].Value         = iuse_yn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_SELECT_ALL"), "BSC_KPI_POOL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int ikpi_pool_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_pool_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_SELECT_ONE"), "BSC_KPI_POOL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetDetailAllList(string ikpi_name, string iKpiType, string ikpi_external_type, int icategory_top_ref_id,
                                        int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = ikpi_name;
            paramArray[2]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value         = iKpiType;
            paramArray[3]               = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = ikpi_external_type;
            paramArray[4]               = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = icategory_top_ref_id;
            paramArray[5]               = CreateDataParameter("@iCATEGORY_MID_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = icategory_mid_ref_id;
            paramArray[6]               = CreateDataParameter("@iCATEGORY_LOW_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = icategory_low_ref_id;
            paramArray[7]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[7].Value         = iuse_yn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_BSC_KPI_POOL.PROC_SELECT_DETAIL_ALL"), "BSC_KPI_POOL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
    
}


