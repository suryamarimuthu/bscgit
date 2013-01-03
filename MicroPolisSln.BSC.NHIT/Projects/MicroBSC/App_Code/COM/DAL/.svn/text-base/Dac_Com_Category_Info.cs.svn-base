using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Dac_Com_Category_Info의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.Biz.Common.Dac
{
    public class Dac_Com_Category_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================

        private string _itype;
        private string _icategory_code;
        private string _icategory_name;
        private string _icategory_desc;
        private string _isystem_yn;
        private string _iuse_yn;
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
                _itype = (value == null ? "" : value);
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
                _icategory_code = (value == null ? "" : value);
            }
        }

        public string Icategory_name
        {
            get
            {
                return _icategory_name;
            }
            set
            {
                _icategory_name = (value == null ? "" : value);
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

        public string Isystem_yn
        {
            get
            {
                return _isystem_yn;
            }
            set
            {
                _isystem_yn = (value == null ? "" : value);
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
        public Dac_Com_Category_Info() { }
        public Dac_Com_Category_Info(string icategory_code) 
        {
            DataSet ds = this.GetOneList(icategory_code);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _icategory_code = (dr["CATEGORY_CODE"] == DBNull.Value) ? "" : (string)dr["CATEGORY_CODE"];
                _icategory_name = (dr["CATEGORY_NAME"] == DBNull.Value) ? "" : (string)dr["CATEGORY_NAME"];
                _icategory_desc = (dr["CATEGORY_DESC"] == DBNull.Value) ? "" : (string)dr["CATEGORY_DESC"];
                _isystem_yn     = (dr["SYSTEM_YN"]     == DBNull.Value) ? "" : (string)dr["SYSTEM_YN"];
                _iuse_yn        = (dr["USE_YN"]        == DBNull.Value) ? "" : (string)dr["USE_YN"];
		        _create_date = (dr["CREATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
		        _create_user = (dr["CREATE_USER"]      == DBNull.Value) ? 0  : Convert.ToInt32( dr["CREATE_USER"] );
		        _update_date = (dr["UPDATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
		        _update_user = (dr["UPDATE_USER"]      == DBNull.Value) ? 0  : Convert.ToInt32( dr["UPDATE_USER"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(string icategory_code, string icategory_name, string icategory_desc, string isystem_yn, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[1].Value 	    = icategory_code;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_name;
	        paramArray[3] 		        = CreateDataParameter("@iCATEGORY_DESC", SqlDbType.VarChar);
	        paramArray[3].Value 	    = icategory_desc;
	        paramArray[4] 		        = CreateDataParameter("@iSYSTEM_YN", SqlDbType.Char,1);
	        paramArray[4].Value 	    = isystem_yn;
	        paramArray[5] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char,1);
	        paramArray[5].Value 	    = iuse_yn;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CATEGORY_INFO", "PKG_COM_CATEGORY_INFO.PROC_INSERT_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(string icategory_code, string icategory_name, string icategory_desc, string isystem_yn, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[1].Value 	    = icategory_code;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_name;
	        paramArray[3] 		        = CreateDataParameter("@iCATEGORY_DESC", SqlDbType.VarChar);
	        paramArray[3].Value 	    = icategory_desc;
	        paramArray[4] 		        = CreateDataParameter("@iSYSTEM_YN", SqlDbType.Char);
	        paramArray[4].Value 	    = isystem_yn;
	        paramArray[5] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[5].Value 	    = iuse_yn;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CATEGORY_INFO", "PKG_COM_CATEGORY_INFO.PROC_INSERT_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int icategory_code, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[1].Value 	    = icategory_code;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CATEGORY_INFO", "PKG_COM_CATEGORY_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CATEGORY_INFO", "PKG_COM_CATEGORY_INFO.PROC_SELECT_ALL"), "COM_CATEGORY_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(string icategory_code)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = icategory_code;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CATEGORY_INFO", "PKG_COM_CATEGORY_INFO.PROC_SELECT_ONE"), "COM_CATEGORY_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

    }
}
