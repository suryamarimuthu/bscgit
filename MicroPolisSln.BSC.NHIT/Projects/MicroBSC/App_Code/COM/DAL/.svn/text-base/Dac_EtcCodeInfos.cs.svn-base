using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    public class Dac_EtcCodeInfos : DbAgentBase
    {
        #region ------------------------ 필드 ------------------------
        private string _TYPE           = "";
        private int    _CODE_INFO_ID   = 0;
        private string _CATEGORY_CODE  = "";
        private string _ETC_CODE       = "";
        private string _CODE_NAME      = "";
        private string _CODE_DESC      = "";
        private int    _SORT_ORDER     = 0;
        private string _USE_YN         = "";
        private int    _TXR_USER       = 0;
        private string _RTN_MSG        = "";
        private string _RTN_FLAG       = "";
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String _txr_message; // 처리결과메시지
        private String _txr_result;  // 처리결과여부(Y,N)
        #endregion

        #region ------------------------ 프로퍼티 ------------------------
        public string iType
        {
            get
            {
                return _TYPE;
            }
            set
            {
                _TYPE = value;
            }
        }

        public int CodeInfoID
        {
            get
            {
                return _CODE_INFO_ID;
            }
            set
            {
                _CODE_INFO_ID = value;
            }
        }

        public string CategoryCode
        {
            get
            {
                return _CATEGORY_CODE;
            }
            set
            {
                _CATEGORY_CODE = value;
            }
        }

        public string EtcCode
        {
            get
            {
                return _ETC_CODE;
            }
            set
            {
                _ETC_CODE = value;
            }
        }

        public string CodeName
        {
            get
            {
                return _CODE_NAME;
            }
            set
            {
                _CODE_NAME = value;
            }
        }

        public string CodeDesc
        {
            get
            {
                return _CODE_DESC;
            }
            set
            {
                _CODE_DESC = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return _SORT_ORDER;
            }
            set
            {
                _SORT_ORDER = value;
            }
        }

        public string UseYN
        {
            get
            {
                return _USE_YN;
            }
            set
            {
                _USE_YN = value;
            }
        }

        public int TxrUser
        {
            get
            {
                return _TXR_USER;
            }
            set
            {
                _TXR_USER = value;
            }
        }

        public string RtnMsg
        {
            get
            {
                return _RTN_MSG;
            }
        }

        public string RtnFlag
        {
            get
            {
                return _RTN_FLAG;
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


        public Dac_EtcCodeInfos()
        {
            
        }

        public Dac_EtcCodeInfos(string iType, int intCodeRefId)
        {
            IDbDataParameter[] arrSpm = CreateDataParameters(2);
            arrSpm[0] = CreateDataParameter("@iTYPE", SqlDbType.Char);
            arrSpm[1] = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);

            arrSpm[0].Value = iType;
            arrSpm[1].Value = intCodeRefId;

            DataSet dsRtn = DbAgentObj.FillDataSet("usp_COM_CODE_INFO", "rtnTbl", null, arrSpm, CommandType.StoredProcedure);
            DataRow drRtn;

            if (dsRtn.Tables.Count > 0)
            {
                if (dsRtn.Tables[0].Rows.Count == 1)
                {
                    drRtn = dsRtn.Tables[0].Rows[0];
                    _CODE_INFO_ID  = (drRtn["CODE_INFO_ID"]   == DBNull.Value) ? 0   : Convert.ToInt32(drRtn["CODE_INFO_ID"].ToString());
                    _CATEGORY_CODE = (drRtn["CATEGORY_CODE"]  == DBNull.Value) ? ""  : drRtn["CATEGORY_CODE"].ToString();
                    _ETC_CODE      = (drRtn["ETC_CODE"]       == DBNull.Value) ? ""  : drRtn["ETC_CODE"].ToString();
                    _CODE_NAME     = (drRtn["CODE_NAME"]      == DBNull.Value) ? ""  : drRtn["CODE_NAME"].ToString();
                    _CODE_DESC     = (drRtn["CODE_DESC"]      == DBNull.Value) ? ""  : drRtn["CODE_DESC"].ToString();
                    _SORT_ORDER    = (drRtn["SORT_ORDER"]     == DBNull.Value) ? 0   : Convert.ToInt32(drRtn["SORT_ORDER"].ToString());
                    _USE_YN        = (drRtn["USE_YN"]         == DBNull.Value) ? "N" : drRtn["USE_YN"].ToString();
                    _TXR_USER      = (drRtn["UPDATE_USER"]    == DBNull.Value) ? 0   : Convert.ToInt32(drRtn["UPDATE_USER"].ToString());
                }
            }
        }

        public void InsertUpdateCode()
        {
            IDbDataParameter[] arrSpm = CreateDataParameters(11);

            arrSpm[0] = CreateDataParameter("@iTYPE", SqlDbType.Char);
            arrSpm[1] = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);
            arrSpm[2] = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
            arrSpm[3] = CreateDataParameter("@iETC_CODE", SqlDbType.VarChar);
            arrSpm[4] = CreateDataParameter("@iCODE_NAME", SqlDbType.VarChar);
            arrSpm[5] = CreateDataParameter("@iCODE_DESC", SqlDbType.VarChar);
            arrSpm[6] = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            arrSpm[7] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            arrSpm[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            arrSpm[9] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            arrSpm[9].Direction = ParameterDirection.Output;
            arrSpm[10] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar);
            arrSpm[10].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            arrSpm[0].Value = _TYPE;
            arrSpm[1].Value = _CODE_INFO_ID;
            arrSpm[2].Value = _CATEGORY_CODE;
            arrSpm[3].Value = _ETC_CODE;
            arrSpm[4].Value = _CODE_NAME;
            arrSpm[5].Value = _CODE_DESC;
            arrSpm[6].Value = _SORT_ORDER;
            arrSpm[7].Value = _USE_YN;
            arrSpm[8].Value = _TXR_USER;

            int intRtn = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_INSERT_UPDATE"), arrSpm, CommandType.StoredProcedure, out col);

            _RTN_FLAG = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            _RTN_MSG = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
        }

        public int InsertData_Dac(string icategory_code, string ietc_code, string icode_name, string icode_desc, string isort_order, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[1].Value 	    = icategory_code;
	        paramArray[2] 		        = CreateDataParameter("@iETC_CODE", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ietc_code;
	        paramArray[3] 		        = CreateDataParameter("@iCODE_NAME", SqlDbType.VarChar);
	        paramArray[3].Value 	    = icode_name;
	        paramArray[4] 		        = CreateDataParameter("@iCODE_DESC", SqlDbType.VarChar);
	        paramArray[4].Value 	    = icode_desc;
	        paramArray[5] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[5].Value 	    = isort_order;
	        paramArray[6] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iuse_yn;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
            paramArray[10]              = CreateDataParameter("@oCODE_INFO_ID", SqlDbType.Int);
            paramArray[10].Direction    = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_COM_CODE_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this._CODE_INFO_ID          = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oCODE_INFO_ID").ToString());

            return affectedRow;
        }

        public int UpdateData_Dac(int icode_info_id, string icategory_code, string ietc_code, string icode_name, string icode_desc, string isort_order, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
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
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_COM_CODE_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public int DeleteData_Dac(int icode_info_id, string icategory_code, string ietc_code, string icode_name, string icode_desc, string isort_order, string iuse_yn, int itxr_user)
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

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_POOL", "PKG_COM_CODE_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet getAllCodeList()
        {
            IDbDataParameter[] arrSpm = CreateDataParameters(1);
            arrSpm[0] = CreateDataParameter("@iTYPE", SqlDbType.Char);
            arrSpm[0].Value = "SA";

            DataSet dsRtn = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_ALL"), "rtnTbl", null, arrSpm, CommandType.StoredProcedure);
            return dsRtn;
        }

        public DataSet getCatCodeList(string strCatCode, string iUseYn)
        {
            IDbDataParameter[] arrSpm = CreateDataParameters(3);
            arrSpm[0] = CreateDataParameter("@iTYPE", SqlDbType.Char);
            arrSpm[1] = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
            arrSpm[2] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);

            arrSpm[0].Value = "CA";
            arrSpm[1].Value = strCatCode;
            arrSpm[2].Value = iUseYn;

            DataSet dsRtn = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_CAT"), "rtnTbl", null, arrSpm, CommandType.StoredProcedure);
            return dsRtn;
        }

        public void getOneCode(string iType, int intCodeRefId)
        {
            IDbDataParameter[] arrSpm = CreateDataParameters(2);
            arrSpm[0] = CreateDataParameter("@iTYPE", SqlDbType.Char);
            arrSpm[1] = CreateDataParameter("@iCODE_INFO_ID", SqlDbType.Int);

            arrSpm[0].Value = iType;
            arrSpm[1].Value = intCodeRefId;

            DataSet dsRtn = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_CODE_INFO", "PKG_COM_CODE_INFO.PROC_SELECT_ONE"), "rtnTbl", null, arrSpm, CommandType.StoredProcedure);
            DataRow drRtn;

            if (dsRtn.Tables.Count > 0)
            {
                if (dsRtn.Tables[0].Rows.Count == 1)
                {
                    drRtn = dsRtn.Tables[0].Rows[0];
                    _CODE_INFO_ID  = (drRtn["CODE_INFO_ID"]  == DBNull.Value) ? 0  : Convert.ToInt32(drRtn["CODE_INFO_ID"].ToString());
                    _CATEGORY_CODE = (drRtn["CATEGORY_CODE"] == DBNull.Value) ? "" : drRtn["CATEGORY_CODE"].ToString();
                    _ETC_CODE      = (drRtn["ETC_CODE"]      == DBNull.Value) ? "" : drRtn["ETC_CODE"].ToString();
                    _CODE_NAME     = (drRtn["CODE_NAME"]     == DBNull.Value) ? "" : drRtn["CODE_NAME"].ToString();
                    _CODE_DESC     = (drRtn["CODE_DESC"]     == DBNull.Value) ? "" : drRtn["CODE_DESC"].ToString();
                    _SORT_ORDER    = (drRtn["SORT_ORDER"]    == DBNull.Value) ? 0  : Convert.ToInt32(drRtn["SORT_ORDER"].ToString());
                    _USE_YN        = (drRtn["USE_YN"]        == DBNull.Value) ? "N": drRtn["USE_YN"].ToString();
                    _TXR_USER      = (drRtn["UPDATE_USER"]   == DBNull.Value) ? 0  : Convert.ToInt32(drRtn["UPDATE_USER"].ToString());
                }
            }
        }
      #endregion
    }
}
