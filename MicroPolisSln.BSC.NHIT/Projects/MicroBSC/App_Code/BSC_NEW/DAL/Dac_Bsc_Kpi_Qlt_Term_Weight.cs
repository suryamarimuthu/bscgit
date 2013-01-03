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
    public class Dac_Bsc_Kpi_Qlt_Term_Weight : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _iestterm_ref_id     ;      
        private int      _ikpi_ref_id         ;      
        private int      _iest_level          ;    
        private string   _iymd                ;
        private double   _iweight              ;
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

        private string Iymd
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
        public Dac_Bsc_Kpi_Qlt_Term_Weight() { }
        public Dac_Bsc_Kpi_Qlt_Term_Weight(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, iymd, iest_level);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id      = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0   : Convert.ToInt32 (dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id          = (dr["KPI_REF_ID"]      == DBNull.Value) ? 0   : Convert.ToInt32 (dr["KPI_REF_ID"]);
                _iest_level           = (dr["EST_LEVEL"]       == DBNull.Value) ? 0   : Convert.ToInt32 (dr["EST_LEVEL"]);
                _iymd                 = (dr["YMD"]             == DBNull.Value) ? ""  : Convert.ToString (dr["YMD"]);
                _iweight              = (dr["WEIGHT"]          == DBNull.Value) ? 0   : Convert.ToDouble (dr["WEIGHT"]);
                _create_user          = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date          = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user          = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date          = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion


        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level, 
                                              double iweight, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_level;
	        paramArray[5] 		        = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
	        paramArray[5].Value 	    = iweight;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_TERM_WEIGHT", "PKG_BSC_KPI_QLT_TERM_WEIGHT.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level, 
                                              double iweight, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_level;
	        paramArray[5] 		        = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
	        paramArray[5].Value 	    = iweight;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_TERM_WEIGHT", "PKG_BSC_KPI_QLT_TERM_WEIGHT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_level;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_QLT_TERM_WEIGHT", "PKG_BSC_KPI_QLT_TERM_WEIGHT.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_TERM_WEIGHT", "PKG_BSC_KPI_QLT_TERM_WEIGHT.PROC_SELECT_ALL"), "BSC_KPI_QLT_TERM_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[4].Value 	    = iest_level;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_TERM_WEIGHT", "PKG_BSC_KPI_QLT_TERM_WEIGHT.PROC_SELECT_ONE"), "BSC_KPI_QLT_TERM_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 정성지표 평가주기별 가중치 설정
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <returns></returns>
        public DataSet GetKpiQualityTermWeight(int iestterm_ref_id, int ikpi_ref_id, int iest_level)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "ST";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iEST_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	    = iest_level;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_QLT_TERM_WEIGHT", "PKG_BSC_KPI_QLT_TERM_WEIGHT.PROC_SELECT_KPI_QLT_TERM"), "BSC_KPI_QLT_TERM_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

    }
}