using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;


namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Work_Pool에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Work_Pool Dac 클래스
    /// Class 내용		@ Work_Pool Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 서대원
    /// 최초작성일		@ 2011.09.27
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Work_Pool : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int 	 _iwork_pool_ref_id;
        private string 	 _iwork_name;
        private string 	 _iwork_desc;
        private string   _iwork_priority;
        private string   _iwork_type;
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
        public int Iwork_pool_ref_id
        {
            get
            {
                return _iwork_pool_ref_id;
            }
            set
            {
                _iwork_pool_ref_id = value;
            }
        }

        public string Iwork_name
        {
            get
            {
                return _iwork_name;
            }
            set
            {
                _iwork_name = (value == null ? "" : value);
            }
        }

        public string Iwork_desc
        {
            get
            {
                return _iwork_desc;
            }
            set
            {
                _iwork_desc = (value == null ? "" : value);
            }
        }

        public string Iwork_priority 
        {
            get
            {
                return _iwork_priority;
            }
            set
            {
                _iwork_priority = (value == null ? "" : value);
            }
        }

        public string Iwork_type
        {
            get
            {
                return _iwork_type;
            }
            set
            {
                _iwork_type = (value == null ? "" : value);
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
        public Dac_Bsc_Work_Pool() { }
        public Dac_Bsc_Work_Pool(int iwork_pool_ref_id) 
        {
            DataSet ds = this.GetOneList(iwork_pool_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iwork_pool_ref_id      = (dr["WORK_POOL_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_POOL_REF_ID"]);
                _iwork_name             = (dr["WORK_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_NAME"]);
                _iwork_desc             = (dr["WORK_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_DESC"]);
		        _iuse_yn                 = (dr["USE_YN"]                 == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user             = (dr["CREATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(string iwork_name, string iwork_desc,  string iwork_priority, string iwork_type, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar); 
	        paramArray[0].Value 	    = "A";
            paramArray[1] = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar);
	        paramArray[1].Value 	    = iwork_name;
            paramArray[2] = CreateDataParameter("@iWORK_DESC", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iwork_desc;
            paramArray[3] = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.Text);
            paramArray[3].Value = iwork_priority;
            paramArray[4] = CreateDataParameter("@iWORK_TYPE", SqlDbType.Text);
            paramArray[4].Value = iwork_type;
            paramArray[5] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iuse_yn;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
            paramArray[9]              = CreateDataParameter("@oRTN_WORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[9].Direction    = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Iwork_pool_ref_id      = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_WORK_POOL_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iwork_pool_ref_id, string iwork_name, string iwork_desc, string iwork_priority, string iwork_type, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iwork_pool_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iwork_name;
	        paramArray[3] 		        = CreateDataParameter("@iWORK_DESC", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iwork_desc;
            paramArray[4] = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.Text);
            paramArray[4].Value = iwork_priority;
            paramArray[5] = CreateDataParameter("@iWORK_TYPE", SqlDbType.Text);
            paramArray[5].Value = iwork_type;
            paramArray[6] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iuse_yn;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iwork_pool_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iwork_pool_ref_id;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[4].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        internal protected int ReUsedData_Dac(int iwork_pool_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iwork_pool_ref_id;
            paramArray[2] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(string iwork_name, string iwork_type, string iuse_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1] = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar);
            paramArray[1].Value = iwork_name;
            paramArray[2] = CreateDataParameter("@iWORK_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = iwork_type;
            paramArray[3] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[3].Value         = iuse_yn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_SELECT_ALL"), "BSC_WORK_POOL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(string work_name, string work_type, string work_priority, string use_yn)
        {
            string strQuery = @"
SELECT   WP.WORK_POOL_REF_ID
		,WP.WORK_NAME
		,WP.WORK_DESC
		,WP.WORK_PRIORITY
		,ISNULL(CI.CODE_NAME,'') as WORK_PRIORITY_NAME
		,WP.WORK_TYPE
		,ISNULL(C2.CODE_NAME,'') as WORK_TYPE_NAME
		,WP.USE_YN
		,WP.CREATE_USER
		,WP.CREATE_DATE
		,WP.UPDATE_USER
		,WP.UPDATE_DATE
FROM BSC_WORK_POOL WP
LEFT OUTER JOIN COM_CODE_INFO CI
    ON CI.CATEGORY_CODE='PM001' AND WP.WORK_PRIORITY = CI.ETC_CODE
LEFT JOIN COM_CODE_INFO C2
    ON C2.CATEGORY_CODE='PM002' AND WP.WORK_TYPE = C2.ETC_CODE
/*
WHERE WP.WORK_NAME LIKE @WORK_NAME + '%'
  AND WP.USE_YN   LIKE @USE_YN   + '%'
  AND WP.WORK_TYPE LIKE @WORK_TYPE + '%'
  AND WP.WORK_PRIORITY LIKE @WORK_PRIORITY + '%'
*/

WHERE (WP.WORK_NAME     LIKE (@WORK_NAME + '%') OR  @WORK_NAME  ='' )
  AND (WP.USE_YN        LIKE (@USE_YN   + '%') OR  @USE_YN  ='' )
  AND (WP.WORK_TYPE     LIKE (@WORK_TYPE + '%') OR  @WORK_TYPE  ='' )
  AND (WP.WORK_PRIORITY LIKE (@WORK_PRIORITY + '%')  OR  @WORK_PRIORITY  ='' )

ORDER BY WP.WORK_NAME
";
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@WORK_NAME", SqlDbType.VarChar);
            paramArray[0].Value = work_name;
            paramArray[1] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[1].Value = use_yn;
            paramArray[2] = CreateDataParameter("@WORK_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = work_type;
            paramArray[3] = CreateDataParameter("@WORK_PRIORITY", SqlDbType.VarChar);
            paramArray[3].Value = work_priority;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_WORK_POOL", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetOneList(int iwork_pool_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iWORK_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iwork_pool_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_SELECT_ONE"), "BSC_WORK_POOL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetDetailAllList(string iwork_name, string iwork_priority, string iwork_type, string iuse_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1] = CreateDataParameter("@iWORK_NAME", SqlDbType.VarChar);
            paramArray[1].Value = iwork_name;
            paramArray[2] = CreateDataParameter("@iWORK_PRIORITY", SqlDbType.VarChar);
            paramArray[2].Value = iwork_priority;
            paramArray[3] = CreateDataParameter("@iWORK_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = iwork_type;
            paramArray[4] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[4].Value         = iuse_yn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_POOL", "PKG_BSC_WORK_POOL.PROC_SELECT_DETAIL_ALL"), "BSC_WORK_POOL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
    
}