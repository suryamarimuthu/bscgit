using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Category_Top에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Kpi_Category_Top Dac 클래스
    /// Class 내용		@ Dac_Bsc_Kpi_Category_Top Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Category_Top : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _icategory_top_ref_id ;
        private string   _icategory_top_name   ;
        private string   _icategory_desc       ;
        private string   _iuse_yn              ;
        private Int32    _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
        #endregion

        #region ------------------------ [ Property ] ------------------------
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

        public string Icategory_top_name
        {
            get
            {
                return _icategory_top_name;
            }
            set
            {
                _icategory_top_name = (value == null ? "" : value);
            }
        }

        public string Icategory_desc
        {
            get
            {
                return _icategory_desc;
            }
            set
            {
                _icategory_desc = (value == null ? "" : value);
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
        public Dac_Bsc_Kpi_Category_Top() { }
        public Dac_Bsc_Kpi_Category_Top(int icategory_top_ref_id) 
        {
            DataSet ds = this.GetOneList(icategory_top_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _icategory_top_ref_id = (dr["CATEGORY_TOP_REF_ID"] == DBNull.Value ) ? 0   : Convert.ToInt32(dr["CATEGORY_TOP_REF_ID"]);
                _icategory_top_name   = (dr["CATEGORY_TOP_NAME"]   == DBNull.Value ) ? ""  : Convert.ToString(dr["CATEGORY_TOP_NAME"]);
                _icategory_desc       = (dr["CATEGORY_DESC"]       == DBNull.Value ) ? ""  : Convert.ToString(dr["CATEGORY_DESC"]);
                _iuse_yn              = (dr["USE_YN"]              == DBNull.Value ) ? "N" : Convert.ToString(dr["USE_YN"]);
                _create_user          = (dr["CREATE_USER"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date          = (dr["CREATE_DATE"]         == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user          = (dr["UPDATE_USER"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date          = (dr["UPDATE_DATE"]         == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(string icategory_name, string icategory_desc , string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_NAME", SqlDbType.VarChar);
	        paramArray[1].Value 	    = icategory_name;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_DESC", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_desc;
	        paramArray[3] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iuse_yn;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
            paramArray[7]               = CreateDataParameter("@oCATEGORY_TOP_REF_ID", SqlDbType.Int);
            paramArray[7].Direction    = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_CATEGORY_TOP", "PKG_BSC_KPI_CATEGORY_TOP.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Icategory_top_ref_id   = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oCATEGORY_TOP_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int icategory_top_ref_id, string icategory_name, string icategory_desc , string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = icategory_top_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_name;
	        paramArray[3] 		        = CreateDataParameter("@iCATEGORY_DESC", SqlDbType.VarChar);
	        paramArray[3].Value 	    = icategory_desc;
	        paramArray[4] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iuse_yn;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_CATEGORY_TOP", "PKG_BSC_KPI_CATEGORY_TOP.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int icategory_top_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = icategory_top_ref_id;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[4].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_CATEGORY_TOP", "PKG_BSC_KPI_CATEGORY_TOP.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_CATEGORY_TOP", "PKG_BSC_KPI_CATEGORY_TOP.PROC_SELECT_ALL"), "BSC_KPI_CATEGORY_TOP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllActiveList(string use_yn)
        {
            string strQuery = @"
SELECT   CATEGORY_TOP_REF_ID
        ,CATEGORY_NAME       AS     CATEGORY_TOP_NAME
        ,CATEGORY_DESC      
        ,USE_YN
        ,CREATE_USER        
        ,CREATE_DATE        
        ,UPDATE_USER        
        ,UPDATE_DATE        
FROM    BSC_KPI_CATEGORY_TOP
WHERE   (USE_YN = @USE_YN)
ORDER BY CATEGORY_TOP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@USE_YN", SqlDbType.Char);
            paramArray[0].Value = use_yn;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "CATEGORYTOPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetOneList(int icategory_top_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_TOP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = icategory_top_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_CATEGORY_TOP", "PKG_BSC_KPI_CATEGORY_TOP.PROC_SELECT_ONE"), "BSC_KPI_CATEGORY_TOP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
}
