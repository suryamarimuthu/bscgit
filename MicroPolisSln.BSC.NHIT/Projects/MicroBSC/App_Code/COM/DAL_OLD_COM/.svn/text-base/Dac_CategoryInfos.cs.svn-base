using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class CategoryInfos : DbAgentBase
    {
        #region ------------------------ 필드 ------------------------
        private string _TYPE = "";
        private string _CATEGORY_CODE = "";
        private string _CATEGORY_NAME = "";
        private string _CATEGORY_DESC = "";
        private string _SYSTEM_YN     = "";
        private string _USE_YN        = "N";
        private int    _TXR_USER      = 0;
        private string _RTN_MSG       = "";
        private string _RTN_FLAG      = "";

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

        public string CategoryName
        {
            get
            {
                return _CATEGORY_NAME;
            }
            set
            {
                _CATEGORY_NAME = value;
            }
        }

        public string CategoryDesc
        {
            get
            {
                return _CATEGORY_DESC;
            }
            set
            {
                _CATEGORY_DESC = value;
            }
        }

        public string SystemYn
        {
            get
            {
                return _SYSTEM_YN;
            }
            set
            {
                _SYSTEM_YN = value;
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


        public CategoryInfos()
        {

        }

        public CategoryInfos(string iType, string strCatCode)
        {

            IDbDataParameter[] arrSpm = CreateDataParameters(2);
            arrSpm[0]               = CreateDataParameter("@I_TYPE", SqlDbType.Char);
            arrSpm[1]               = CreateDataParameter("@I_CATEGORY_CODE", SqlDbType.VarChar);

            arrSpm[0].Value         = iType;
            arrSpm[1].Value         = strCatCode;

            DataSet dsRtn = DbAgentObj.FillDataSet("usp_COM_CATEGORY_INFO", "rtnTbl", null, arrSpm, CommandType.StoredProcedure);
            DataRow drRtn;

            if (dsRtn.Tables.Count > 0)
            {
                if (dsRtn.Tables[0].Rows.Count == 1)
                {
                     drRtn = dsRtn.Tables[0].Rows[0];
                    
                    _CATEGORY_CODE = (drRtn["CATEGORY_CODE"] == DBNull.Value) ? ""  : drRtn["CATEGORY_CODE"].ToString();
                    _CATEGORY_NAME = (drRtn["CATEGORY_NAME"] == DBNull.Value) ? ""  : drRtn["CATEGORY_NAME"].ToString();
                    _CATEGORY_DESC = (drRtn["CATEGORY_DESC"] == DBNull.Value) ? ""  : drRtn["CATEGORY_DESC"].ToString();
                    _SYSTEM_YN     = (drRtn["SYSTEM_YN"]     == DBNull.Value) ? ""  : drRtn["SYSTEM_YN"].ToString();
                    _USE_YN        = (drRtn["USE_YN"]        == DBNull.Value) ? "N" : drRtn["USE_YN"].ToString();
                    _TXR_USER      = (drRtn["UPDATE_USER"]   == DBNull.Value) ? 0   : Convert.ToInt32(drRtn["UPDATE_USER"].ToString());
                }
            }
        }

        public void InsertUpdateCode()
        {
            IDbDataParameter[] arrSpm   = CreateDataParameters(9);

            arrSpm[0]                 = CreateDataParameter("@I_TYPE", SqlDbType.Char);
            arrSpm[1]                 = CreateDataParameter("@I_CATEGORY_CODE", SqlDbType.VarChar);
            arrSpm[2]                 = CreateDataParameter("@I_CATEGORY_NAME", SqlDbType.VarChar);
            arrSpm[3]                 = CreateDataParameter("@I_CATEGORY_DESC", SqlDbType.VarChar);
            arrSpm[4]                 = CreateDataParameter("@I_SYSTEM_YN", SqlDbType.VarChar);
            arrSpm[5]                 = CreateDataParameter("@I_USE_YN", SqlDbType.Char);
            arrSpm[6]                 = CreateDataParameter("@I_TXR_USER", SqlDbType.Int);
            arrSpm[7]                 = CreateDataParameter("@I_RTN_MSG", SqlDbType.VarChar);
            arrSpm[7].Direction       = ParameterDirection.Output;
            arrSpm[8]                 = CreateDataParameter("@I_RTN_FLAG", SqlDbType.VarChar);
            arrSpm[8].Direction       = ParameterDirection.Output;

            arrSpm[0].Value         = _TYPE;
            arrSpm[1].Value         = _CATEGORY_CODE;
            arrSpm[2].Value         = _CATEGORY_NAME;
            arrSpm[3].Value         = _CATEGORY_DESC;
            arrSpm[4].Value         = _SYSTEM_YN;
            arrSpm[5].Value         = _USE_YN;
            arrSpm[6].Value         = _TXR_USER;

            int intRtn              = DbAgentObj.ExecuteNonQuery("usp_COM_CATEGORY_INFO", arrSpm, CommandType.StoredProcedure);
            _RTN_MSG                = arrSpm[7].Value.ToString();
            _RTN_FLAG               = arrSpm[8].Value.ToString();
        }

        public DataSet getAllCodeList()
        {
            IDbDataParameter[] arrSpm = CreateDataParameters(1);
            arrSpm[0]               = CreateDataParameter("@I_TYPE", SqlDbType.Char);
            arrSpm[0].Value         = "S1";

            DataSet dsRtn           = DbAgentObj.FillDataSet("usp_COM_CATEGORY_INFO", "rtnTbl", null, arrSpm, CommandType.StoredProcedure);
            return dsRtn;
        }

        #endregion

    }
}
