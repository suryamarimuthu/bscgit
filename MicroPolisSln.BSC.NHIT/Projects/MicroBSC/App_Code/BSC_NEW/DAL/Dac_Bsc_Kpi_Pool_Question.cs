using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;


namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Pool_Question에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Kpi_Pool_Question Dac 클래스
    /// Class 내용		@ Bsc_Kpi_Pool_Question Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2007.10.11
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Pool_Question : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _ikpi_pool_ref_id;
        private int      _iquestion_ref_id;
        private string   _iitem_name      ;
        private double   _iweight         ;
        private int      _iquestion_order ;
        private string 	 _iuse_yn;
        private Int32    _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
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

        public string Iitem_name
        {
            get
            {
                return _iitem_name;
            }
            set
            {
                _iitem_name = (value == null ? "" : value);
            }
        }

        private double Iweight
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

        public int Iquestion_order
        {
            get
            { 
                return _iquestion_order;
            }
            set
            { 
                _iquestion_order = value;
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
         
        #region ------------------------ [ Constructor ] ------------------------
        public Dac_Bsc_Kpi_Pool_Question() { }
        public Dac_Bsc_Kpi_Pool_Question(int ikpi_pool_ref_id, int iquestion_ref_id) 
        {
            DataSet ds = this.GetOneList(ikpi_pool_ref_id, iquestion_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

		        _ikpi_pool_ref_id        = (dr["KPI_POOL_REF_ID"]    == DBNull.Value) ? 0  : Convert.ToInt32(dr["KPI_POOL_REF_ID"]);
		        _iquestion_ref_id        = (dr["QUESTION_REF_ID"]    == DBNull.Value) ? 0  : Convert.ToInt32(dr["QUESTION_REF_ID"]);
		        _iitem_name              = (dr["ITEM_NAME"]          == DBNull.Value) ? "" : Convert.ToString(dr["ITEM_NAME"]);
		        _iweight                 = (dr["WEIGHT"]             == DBNull.Value) ? 0  : Convert.ToDouble(dr["WEIGHT"]);
                _iquestion_order         = (dr["QUESTION_ORDER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["QUESTION_ORDER"]);
		        _iuse_yn                 = (dr["USE_YN"]             == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user             = (dr["CREATE_USER"]        == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int ikpi_pool_ref_id, string iitem_name, double iweight, int iquestion_order, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ikpi_pool_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iITEM_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iitem_name;
	        paramArray[3] 		        = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
	        paramArray[3].Value 	    = iweight;
	        paramArray[4] 		        = CreateDataParameter("@iQUESTION_ORDER", SqlDbType.Int);
	        paramArray[4].Value 	    = iquestion_order;
	        paramArray[5] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iuse_yn;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
            paramArray[9]               = CreateDataParameter("@oRTN_QUESTION_REF_ID", SqlDbType.Int);
            paramArray[9].Direction     = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL_QUESTION", "PKG_BSC_KPI_POOL_QUESTION.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Iquestion_ref_id       = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_QUESTION_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int ikpi_pool_ref_id, int iquestion_ref_id, string iitem_name, double iweight, int iquestion_order, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ikpi_pool_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iquestion_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iITEM_NAME", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iitem_name;
	        paramArray[4] 		        = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
	        paramArray[4].Value 	    = iweight;
	        paramArray[5] 		        = CreateDataParameter("@iQUESTION_ORDER", SqlDbType.Int);
	        paramArray[5].Value 	    = iquestion_order;
	        paramArray[6] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iuse_yn;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL_QUESTION", "PKG_BSC_KPI_POOL_QUESTION.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int ikpi_pool_ref_id, int iquestion_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ikpi_pool_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iquestion_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL_QUESTION", "PKG_BSC_KPI_POOL_QUESTION.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int ikpi_pool_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ikpi_pool_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_POOL_QUESTION", "PKG_BSC_KPI_POOL_QUESTION.PROC_SELECT_ALL"), "BSC_KPI_POOL_QUESTION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int ikpi_pool_ref_id, int iquestion_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_pool_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iQUESTION_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iquestion_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_POOL_QUESTION", "PKG_BSC_KPI_POOL_QUESTION.PROC_SELECT_ONE"), "BSC_KPI_POOL_QUESTION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
    
}


