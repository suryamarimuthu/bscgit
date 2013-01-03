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
/// Dac_Com_Code_Info의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.Biz.Common.Dac
{
public class Dac_Com_Code_Info : DbAgentBase
{
        #region ============================== [Fields] ==============================
        private string 	 _itype;
        private int 	 _icode_info_id;
        private string 	 _icategory_code;
        private string 	 _ietc_code;
        private string 	 _icode_name;
        private string 	 _icode_desc;
        private int 	 _isort_order;
        private string 	 _iuse_yn;
        private string   _isegment1;
        private string   _isegment2;
        private string   _isegment3;
        private string   _isegment4;
        private string   _isegment5;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result; // 처리결과여부(Y,N)

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Itype
        {
	        get 
	        {
		        return _itype;
	        }
	        set
	        {
		        _itype = ( value==null ? "" : value );
	        }
        }
         
        public int Icode_info_id
        {
	        get 
	        {
		        return _icode_info_id;
	        }
	        set
	        {
		        _icode_info_id = value;
	        }
        }
         
        public string Icategory_code
        {
	        get 
	        {
		        return _icategory_code;
	        }
	        set
	        {
		        _icategory_code = ( value==null ? "" : value );
	        }
        }
         
        public string Ietc_code
        {
	        get 
	        {
		        return _ietc_code;
	        }
	        set
	        {
		        _ietc_code = ( value==null ? "" : value );
	        }
        }
         
        public string Icode_name
        {
	        get 
	        {
		        return _icode_name;
	        }
	        set
	        {
		        _icode_name = ( value==null ? "" : value );
	        }
        }
         
        public string Icode_desc
        {
	        get 
	        {
		        return _icode_desc;
	        }
	        set
	        {
		        _icode_desc = ( value==null ? "" : value );
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

        public string Isegment1
        {
	        get 
	        {
		        return _isegment1;
	        }
	        set
	        {
		        _isegment1 = ( value==null ? "" : value );
	        }
        }

        public string Isegment2
        {
	        get 
	        {
		        return _isegment2;
	        }
	        set
	        {
		        _isegment2 = ( value==null ? "" : value );
	        }
        }

        public string Isegment3
        {
	        get 
	        {
		        return _isegment3;
	        }
	        set
	        {
		        _isegment3 = ( value==null ? "" : value );
	        }
        }

        public string Isegment4
        {
	        get 
	        {
		        return _isegment4;
	        }
	        set
	        {
		        _isegment4 = ( value==null ? "" : value );
	        }
        }
         
        public string Isegment5
        {
	        get 
	        {
		        return _isegment5;
	        }
	        set
	        {
		        _isegment5 = ( value==null ? "" : value );
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
        public Dac_Com_Code_Info() { }
        public Dac_Com_Code_Info(Int32 icode_info_id) 
        {
            DataSet ds = this.GetOneList(icode_info_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
		        _icode_info_id  = (dr["CODE_INFO_ID"]   == DBNull.Value) ? 0  : Convert.ToInt32(dr["CODE_INFO_ID"]);
		        _icategory_code = (dr["CATEGORY_CODE"]  == DBNull.Value) ? "" : Convert.ToString(dr["CATEGORY_CODE"]);
		        _ietc_code      = (dr["ETC_CODE"]       == DBNull.Value) ? "" : Convert.ToString(dr["ETC_CODE"]);
		        _icode_name     = (dr["CODE_NAME"]      == DBNull.Value) ? "" : Convert.ToString(dr["CODE_NAME"]);
		        _icode_desc     = (dr["CODE_DESC"]      == DBNull.Value) ? "" : Convert.ToString(dr["CODE_DESC"]);
		        _isort_order    = (dr["SORT_ORDER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["SORT_ORDER"]);
		        _iuse_yn        = (dr["USE_YN"]         == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _isegment1      = (dr["SEGMENT1"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT1"]);
                _isegment2      = (dr["SEGMENT2"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT2"]);
                _isegment3      = (dr["SEGMENT3"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT3"]);
                _isegment4      = (dr["SEGMENT4"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT4"]);
                _isegment5      = (dr["SEGMENT5"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT5"]);
		        _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
		        _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0  : Convert.ToInt32( dr["CREATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0  : Convert.ToInt32( dr["UPDATE_USER"]);
            }
        }

        public Dac_Com_Code_Info(string icategory_code, string ietc_code)
        {
            DataSet ds = this.GetOneCodePerCategory(icategory_code, ietc_code);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
		        _icode_info_id  = (dr["CODE_INFO_ID"]   == DBNull.Value) ? 0  : Convert.ToInt32(dr["CODE_INFO_ID"]);
		        _icategory_code = (dr["CATEGORY_CODE"]  == DBNull.Value) ? "" : Convert.ToString(dr["CATEGORY_CODE"]);
		        _ietc_code      = (dr["ETC_CODE"]       == DBNull.Value) ? "" : Convert.ToString(dr["ETC_CODE"]);
		        _icode_name     = (dr["CODE_NAME"]      == DBNull.Value) ? "" : Convert.ToString(dr["CODE_NAME"]);
		        _icode_desc     = (dr["CODE_DESC"]      == DBNull.Value) ? "" : Convert.ToString(dr["CODE_DESC"]);
		        _isort_order    = (dr["SORT_ORDER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["SORT_ORDER"]);
		        _iuse_yn        = (dr["USE_YN"]         == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _isegment1      = (dr["SEGMENT1"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT1"]);
                _isegment2      = (dr["SEGMENT2"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT2"]);
                _isegment3      = (dr["SEGMENT3"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT3"]);
                _isegment4      = (dr["SEGMENT4"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT4"]);
                _isegment5      = (dr["SEGMENT5"]       == DBNull.Value) ? "" : Convert.ToString(dr["SEGMENT5"]);
		        _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
		        _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0  : Convert.ToInt32( dr["CREATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0  : Convert.ToInt32( dr["UPDATE_USER"]);
            }
        }

        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int icode_info_id, string icategory_code, string ietc_code, string icode_name, string icode_desc, int isort_order, string iuse_yn
                                             ,string isegment1,string isegment2,string isegment3,string isegment4,string isegment5, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(16);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = icode_info_id;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_code;
	        paramArray[3] 		        = CreateDataParameter("@iETC_CODE", SqlDbType.VarChar);
	        paramArray[3].Value 	    = ietc_code;
	        paramArray[4] 		        = CreateDataParameter("@iCODE_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	    = icode_name;
	        paramArray[5] 		        = CreateDataParameter("@iCODE_DESC", SqlDbType.VarChar);
	        paramArray[5].Value 	    = icode_desc;
	        paramArray[6] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[6].Value 	    = isort_order;
	        paramArray[7] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char,1);
	        paramArray[7].Value 	    = iuse_yn;
	        paramArray[8] 		        = CreateDataParameter("@iSEGMENT1", SqlDbType.VarChar);
	        paramArray[8].Value 	    = isegment1;
	        paramArray[9] 		        = CreateDataParameter("@iSEGMENT2", SqlDbType.VarChar);
	        paramArray[9].Value 	    = isegment2;
	        paramArray[10] 		        = CreateDataParameter("@iSEGMENT3", SqlDbType.VarChar);
	        paramArray[10].Value 	    = isegment3;
	        paramArray[11] 		        = CreateDataParameter("@iSEGMENT4", SqlDbType.VarChar);
	        paramArray[11].Value 	    = isegment4;
	        paramArray[12] 		        = CreateDataParameter("@iSEGMENT5", SqlDbType.VarChar);
	        paramArray[12].Value 	    = isegment5;
	        paramArray[13] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[13].Value 	    = itxr_user;
	        paramArray[14] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[14].Direction 	= ParameterDirection.Output ;
	        paramArray[15] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[15].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_INSERT_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int icode_info_id, string icategory_code, string ietc_code, string icode_name, string icode_desc, int isort_order, string iuse_yn
                                             ,string isegment1,string isegment2,string isegment3,string isegment4,string isegment5, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(16);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = icode_info_id;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_code;
	        paramArray[3] 		        = CreateDataParameter("@iETC_CODE", SqlDbType.VarChar);
	        paramArray[3].Value 	    = ietc_code;
	        paramArray[4] 		        = CreateDataParameter("@iCODE_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	    = icode_name;
	        paramArray[5] 		        = CreateDataParameter("@iCODE_DESC", SqlDbType.VarChar);
	        paramArray[5].Value 	    = icode_desc;
	        paramArray[6] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[6].Value 	    = isort_order;
	        paramArray[7] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[7].Value 	    = iuse_yn;
	        paramArray[8] 		        = CreateDataParameter("@iSEGMENT1", SqlDbType.VarChar);
	        paramArray[8].Value 	    = isegment1;
	        paramArray[9] 		        = CreateDataParameter("@iSEGMENT2", SqlDbType.VarChar);
	        paramArray[9].Value 	    = isegment2;
	        paramArray[10] 		        = CreateDataParameter("@iSEGMENT3", SqlDbType.VarChar);
	        paramArray[10].Value 	    = isegment3;
	        paramArray[11] 		        = CreateDataParameter("@iSEGMENT4", SqlDbType.VarChar);
	        paramArray[11].Value 	    = isegment4;
	        paramArray[12] 		        = CreateDataParameter("@iSEGMENT5", SqlDbType.VarChar);
	        paramArray[12].Value 	    = isegment5;
	        paramArray[13] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[13].Value 	    = itxr_user;
	        paramArray[14] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[14].Direction 	= ParameterDirection.Output ;
	        paramArray[15] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[15].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_INSERT_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int icode_info_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = icode_info_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_ALL"), "COM_CODE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(Int32 icode_info_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);
            paramArray[1].Value         = icode_info_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_ONE"), "COM_CODE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetCodeListPerCategory(string strCatCode, string iUseYn)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CA";
            paramArray[1]               = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = strCatCode;
            paramArray[2]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar,1);
            paramArray[2].Value         = iUseYn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_CAT"), "COM_CODE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneCodePerCategory(string strCatCode, string ietc_code)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SD";
            paramArray[1]               = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = strCatCode;
	        paramArray[2] 		        = CreateDataParameter("@iETC_CODE", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ietc_code;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_DET"), "COM_CODE_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        
        #endregion
    }
}
