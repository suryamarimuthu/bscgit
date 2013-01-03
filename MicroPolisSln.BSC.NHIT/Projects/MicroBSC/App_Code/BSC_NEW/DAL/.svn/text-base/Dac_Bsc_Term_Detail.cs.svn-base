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
/// Bsc_Term_Detail의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Term_Detail : DbAgentBase
    {
    #region ============================== [Fields] ==============================
        private string      _itype;
        private int         _iestterm_ref_id;
        private string      _iestterm_name;
        private string      _iymd;
        private string      _iyy;
        private string      _imm;
        private string      _idd;
        private string      _irelease_yn;
        private string      _iclose_yn;
        private string      _inormdist_yn;
        private string      _iapply_ext_score_yn;
        private string      _iclose_desc;
        private string      _iclosing_date;
        private string      _interface_yn;
        private string      _interface_date;
        private string      _interface_desc;
        private int         _create_user;
        private DateTime    _create_date;
        private string      _create_user_name;
        private int         _update_user;
        private DateTime    _update_date;
        private string      _update_user_name;
        private string      _txr_message; // 처리결과메시지
        private string      _txr_result; // 처리결과여부(Y,N)
    #endregion
    #region ============================== [Properties] ==========================

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

        public string Iestterm_name
        {
            get
            {
                return _iestterm_name;
            }
            set
            {
                _iestterm_name = (value == null ? "" : value);
            }
        }

        public string Iymd
        {
            get 
            {
                return _iymd;
            }
            set 
            {
                _iymd = ( value==null ? "" : value );
            }
        }

        public string Iyy
        {
            get 
            {
                return _iyy;
            }
            set 
            {
                _iyy = ( value==null ? "" : value );
            }
        }

        public string Imm
        {
            get 
            {
                return _imm;
            }
            set 
            {
                _imm = ( value==null ? "" : value );
            }
        }

        public string Idd
        {
            get 
            {
                return _idd;
            }
            set 
            {
                _idd = ( value==null ? "" : value );
            }
        }

        public string Irelease_yn
        {
            get 
            {
                return _irelease_yn;
            }
            set 
            {
                _irelease_yn = ( value==null ? "" : value );
            }
        }

        public string Iclose_yn
        {
            get 
            {
                return _iclose_yn;
            }
            set 
            {
                _iclose_yn = ( value==null ? "" : value );
            }
        }

        public string Inormdist_yn
        {
            get
            {
                return _inormdist_yn;
            }
            set
            {
                _inormdist_yn = (value == null ? "" : value);
            }
        }

        public string Iapply_ext_score_yn
        {
            get
            {
                return _iapply_ext_score_yn;
            }
            set
            {
                _iapply_ext_score_yn = (value == null ? "" : value);
            }
        }

        public string Iclose_desc
        {
            get 
            {
                return _iclose_desc;
            }
            set 
            {
                _iclose_desc = ( value==null ? "" : value );
            }
        }

        public string Iclosing_date
        {
            get 
            {
                return _iclosing_date;
            }
            set 
            {
                _iclosing_date = (value == null ? "" : value);
            }
        }

        public string Iinterface_yn
        {
            get
            {
                return _interface_yn;
            }
            set
            {
                _interface_yn = (value == null ? "" : value);
            }
        }

        public string Iinterface_date
        {
            get
            {
                return _interface_date;
            }
            set
            {
                _interface_date = (value == null ? "" : value);
            }
        }

        public string Iinterface_desc
        {
            get
            {
                return _interface_desc;
            }
            set
            {
                _interface_desc = (value == null ? "" : value);
            }
        }
        
        public int Create_user
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

        public string ICreate_user_name
        {
            get
            {
                return _create_user_name;
            }
            set
            {
                _create_user_name = (value == null ? "" : value);
            }
        }

        public int Update_user
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

        public string IUpdate_user_name
        {
            get
            {
                return _update_user_name;
            }
            set
            {
                _update_user_name = (value == null ? "" : value);
            }
        }

        public string Transaction_Message
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

        public string Transaction_Result
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
    #region ============================== [Constructor] =========================
        public Dac_Bsc_Term_Detail() { }

        public Dac_Bsc_Term_Detail(int pIestterm_ref_id, string pIymd)
        {
            DataSet ds = this.GetOneList(pIestterm_ref_id, pIymd);
            DataRow dr;
            if(ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id   = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ?  0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iestterm_name     = (dr["ESTTERM_NAME"]       == DBNull.Value) ? "": Convert.ToString(dr["ESTTERM_NAME"]);
                _iymd              = (dr["YMD"]                == DBNull.Value) ? "": Convert.ToString(dr["YMD"]);
                _iyy               = (dr["YY"]                 == DBNull.Value) ? "": Convert.ToString(dr["YY"]);
                _imm               = (dr["MM"]                 == DBNull.Value) ? "": Convert.ToString(dr["MM"]);
                _idd               = (dr["DD"]                 == DBNull.Value) ? "": Convert.ToString(dr["DD"]);
                _irelease_yn       = (dr["RELEASE_YN"]         == DBNull.Value) ? "": Convert.ToString(dr["RELEASE_YN"]);
                _iclose_yn         = (dr["CLOSE_YN"]           == DBNull.Value) ? "": Convert.ToString(dr["CLOSE_YN"]);
                _inormdist_yn      = (dr["NORMDIST_YN"]        == DBNull.Value) ? "": Convert.ToString(dr["NORMDIST_YN"]);
                _iapply_ext_score_yn = (dr["APPLY_EXT_SCORE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["APPLY_EXT_SCORE_YN"]);
                _iclose_yn         = (dr["CLOSE_YN"]           == DBNull.Value) ? "": Convert.ToString(dr["CLOSE_YN"]);
                _iclose_desc       = (dr["CLOSE_DESC"]         == DBNull.Value) ? "": Convert.ToString(dr["CLOSE_DESC"]);
                _iclosing_date     = (dr["CLOSING_DATE"]       == DBNull.Value) ? "": Convert.ToString(dr["CLOSING_DATE"]);
                _interface_yn      = (dr["INTERFACE_YN"]       == DBNull.Value) ? "": Convert.ToString(dr["INTERFACE_YN"]);
                _interface_desc    = (dr["INTERFACE_DESC"]     == DBNull.Value) ? "": Convert.ToString(dr["INTERFACE_DESC"]);
                _interface_date    = (dr["INTERFACE_DATE"]     == DBNull.Value) ? "": Convert.ToString(dr["INTERFACE_DATE"]);
                _create_user       = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date       = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _create_user_name  = (dr["CREATE_USER_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["CREATE_USER_NAME"]);
                _update_user       = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date       = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _update_user_name  = (dr["UPDATE_USER_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["UPDATE_USER_NAME"]);
            }
       }
    #endregion
    #region ============================== [Method] ==============================
        internal protected int InsertData(int pIestterm_ref_id, string pIymd, string pIyy, string pImm, string pIdd, 
                                          string pIrelease_yn, string pIclose_yn, string pIclose_desc, DateTime pIclosing_date, int pItxr_user, 
                                          string pIrtn_msg, string pIrtn_complete_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iYY", SqlDbType.Char);
            paramArray[3].Value         = pIyy;
            paramArray[4]               = CreateDataParameter("@iMM", SqlDbType.Char);
            paramArray[4].Value         = pImm;
            paramArray[5]               = CreateDataParameter("@iDD", SqlDbType.Char);
            paramArray[5].Value         = pIdd;
            paramArray[6]               = CreateDataParameter("@iRELEASE_YN", SqlDbType.Char);
            paramArray[6].Value         = pIrelease_yn;
            paramArray[7]               = CreateDataParameter("@iCLOSE_YN", SqlDbType.Char);
            paramArray[7].Value         = pIclose_yn;
            paramArray[8]               = CreateDataParameter("@iCLOSE_DESC", SqlDbType.VarChar);
            paramArray[8].Value         = pIclose_desc;
            paramArray[9]               = CreateDataParameter("@iCLOSING_DATE", SqlDbType.DateTime);
            paramArray[9].Value         = pIclosing_date;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = pItxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[11].Direction 	= ParameterDirection.Output ;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[12].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData(int pIestterm_ref_id, string pIymd, string pIclose_desc, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iCLOSE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = pIclose_desc;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = pItxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@iRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@iRTN_COMPLETE_YN").ToString();
            
            return affectedRow;
        }

        internal protected int DeleteData(int pIestterm_ref_id, string pIymd, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = pItxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InterfaceData_Dac(int pIestterm_ref_id, string pIymd, string pInterface_desc, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "IF";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iINTERFACE_YN", SqlDbType.VarChar);
            paramArray[3].Value         = "Y";
            paramArray[4]               = CreateDataParameter("@iINTERFACE_DESC", SqlDbType.VarChar);
            paramArray[4].Value         = pInterface_desc;
            paramArray[5]               = CreateDataParameter("@iINTERFACE_DATE", SqlDbType.DateTime);
            paramArray[5].Value         = System.DateTime.Now;
            paramArray[6]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value         = pItxr_user;
            paramArray[7]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[7].Direction     = ParameterDirection.Output;
            paramArray[8]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[8].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_INTERFACE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            
            return affectedRow;
        }

        internal protected int OpenTermDetailMonth_Dac(int pIestterm_ref_id, string pIymd, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RS";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = pItxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_RELEASE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int ApplyNormDist_Dac(int pIestterm_ref_id, string pIymd, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "NR";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = pItxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_NORMDIST"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int ApplyExtScore_Dac(int pIestterm_ref_id, string pIymd, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "AE";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = pItxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_APPLY_EXT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        public DataSet GetAllList(int pIestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_SELECT_ALL"), "BSC_TERM_DETAIL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int pIestterm_ref_id, string pIymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_SELECT_ONE"), "BSC_TERM_DETAIL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 실적입력중인 월 구하기
        /// </summary>
        /// <returns></returns>
        public string GetReleasedMonth()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S1";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_SELECT_MONTH"), "BSC_TERM_DETAIL", null, paramArray, CommandType.StoredProcedure);

            string strYMD = "000000";
            if (ds.Tables[0].Rows.Count > 0)
            {
                strYMD = ds.Tables[0].Rows[0]["YMD"].ToString();
            }

            return strYMD;
        }

        /// <summary>
        /// 평가시작월 구하기
        /// </summary>
        /// <returns></returns>
        public string GetStartEstMonth()
        {
            string cYMD = this.GetReleasedMonth();

            cYMD = cYMD.Substring(0, 4) + "01";

            return cYMD;
        }

        public string GetStartEstMonth(int iEstterm_ref_id)
        {
            string sQry = "SELECT YMD FROM BSC_TERM_DETAIL WHERE ESTTERM_REF_ID = @iESTTERM_REF_ID ORDER BY YMD";
            string sYMD = "999999";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iEstterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(sQry, "BSC_TERM_DETAIL", null, paramArray, CommandType.Text);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sYMD = ds.Tables[0].Rows[0][0].ToString();
                }
            }

            return sYMD;
        }

        /// <summary>
        /// 평가기간 개시여부
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <returns></returns>
        public bool GetIsOpenTerm(int iestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S2";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_SELECT_IS_CLOSE_TERM"), "BSC_TERM_DETAIL", null, paramArray, CommandType.StoredProcedure);

            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
            {
                return false;
            }
            else
            {
                return true;  
            }

            return false;
        }

        /// <summary>
        /// 현재 배포된 평가기간 ID
        /// </summary>
        /// <returns></returns>
        public int GetOpenEstTermID()
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S3";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_DETAIL", "PKG_BSC_TERM_DETAIL.PROC_SELECT_OPEN_ESTTERM_ID"), "BSC_TERM_DETAIL", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()));
            }
            else
            {
                return (0);  
            }

            return (0);
        }

        public bool CalcTermMonth(IDbConnection conn, IDbTransaction trx, int estterm_ref_id, string ymd, int txr_user)
        {
            string strQuery = @"
DECLARE  @pSCORE_TYPE     VARCHAR(12)                -- 점수계산방식(STA:계단식, SLP:기울기식)
        ,@pCNTKPI_RESULT  INTEGER 
        ,@pCNTKPI_EST     INTEGER 
        ,@pCNT_CLOSE      INTEGER 

SET @pCNTKPI_RESULT = 0
SET @pCNTKPI_EST    = 0
SET @pCNT_CLOSE     = 0
          
-- 평가기간 마감체크
IF EXISTS (SELECT ESTTERM_REF_ID FROM EST_TERM_INFO WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID AND YEARLY_CLOSE_YN = 1)
 BEGIN
      SELECT 'N' as RtnFlag, '해당평가 기간은 이미 마감되었습니다. 계산 할 수 없습니다.' as RtnMsg
      RETURN
 END

-- 계산월 이전월 미마감건 체크       
SELECT @pCNT_CLOSE = COUNT(ESTTERM_REF_ID)
FROM BSC_TERM_DETAIL
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND YMD            < @YMD
    AND CLOSE_YN       = 'N'
             
IF (@pCNT_CLOSE > 0) 
    BEGIN
        SELECT 'N' as RtnFlag, '해당월이전에 마감되지 않은 데이터가 존재합니다. 계산할 수 없습니다.' as RtnMsg
        RETURN
    END
          
-- 마감율이 100%인지 여부에 따라서 월마감여부 결정
SELECT @pCNT_CLOSE = COUNT(*)
FROM EST_TERM_INFO
WHERE ESTTERM_REF_ID         = @ESTTERM_REF_ID
AND CLOSE_RATE_COMPLETE_YN = 1;
             
IF (dbo.fn_BSC_MONTHLY_CLOSE_RATE(@ESTTERM_REF_ID,@YMD) < 100 AND @pCNT_CLOSE > 0)
    BEGIN
        SELECT 'N' as RtnFlag, '모든 KPI가 확정되지 않았으므로 계산할 수 없습니다.' as RtnMsg
        RETURN
    END
          
-- 점수평가방식 - 
SELECT @pSCORE_TYPE   = SCORE_VALUATION_TYPE
FROM EST_TERM_INFO
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
          
DECLARE  @pALL_KPI_REF_ID     INTEGER 
        ,@pRESULT_KPI_REF_ID  INTEGER 
        ,@pYMD                VARCHAR(8)
        ,@pDEFAULT_IMG_ID     INT
        ,@pRESULT_INPUT_TYPE  VARCHAR(20)
                             
SELECT @pDEFAULT_IMG_ID = THRESHOLD_REF_ID
FROM BSC_THRESHOLD_CODE
WHERE DEFAULT_IMG_YN = 'Y'
                             
------------------------------------------------------------------
-- 모든 지표를 대상으로 점수를 구한다
-- 지표풀의 모든지표(미사용, 삭제, 결재미완료)를 대상으로 평가한다
-- 모든지표중 사용중, 미삭제, 결재완료된 건들만 실적을 평가한다.
------------------------------------------------------------------ 
DELETE FROM BSC_KPI_SCORE WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND YMD = @YMD
INSERT INTO BSC_KPI_SCORE 
    (
         ESTTERM_REF_ID, KPI_REF_ID, YMD
        ,THRESHOLD_REF_ID_MS, THRESHOLD_REF_ID_TS
        ,POINTS_MS, POINTS_TS, CALC_DATE
    )
SELECT   TB.ESTTERM_REF_ID,TB.ALL_KPI_REF_ID,TB.YMD
         ,CASE WHEN TB.RESULT_KPI_REF_ID=-999999 THEN @pDEFAULT_IMG_ID
          ELSE dbo.fn_BSC_KPI_INDICATOR_ID(TB.ESTTERM_REF_ID, TB.RESULT_KPI_REF_ID, TB.YMD, 'MS')
          END as SINAL_MS
         ,dbo.fn_BSC_KPI_INDICATOR_ID(TB.ESTTERM_REF_ID, TB.ALL_KPI_REF_ID, TB.YMD, 'TS') as SIGNAL_TS
         ,CASE WHEN TB.RESULT_KPI_REF_ID = -999999 THEN '-'
          ELSE CASE @pSCORE_TYPE
                    WHEN 'SLP' THEN CONVERT(VARCHAR(50),dbo.fn_BSC_KPI_SCORE_SLOPE(TB.ESTTERM_REF_ID, TB.RESULT_KPI_REF_ID,TB.YMD,'MS'))
                    WHEN 'STA' THEN CONVERT(VARCHAR(50),dbo.fn_BSC_KPI_SCORE_STAIR(TB.ESTTERM_REF_ID, TB.RESULT_KPI_REF_ID,TB.YMD,'MS'))
                    WHEN 'NON' THEN CONVERT(VARCHAR(50),dbo.fn_BSC_KPI_SCORE_EACH (TB.ESTTERM_REF_ID, TB.RESULT_KPI_REF_ID,TB.YMD,'MS'))
               ELSE '-'
               END
          END
         ,CASE @pSCORE_TYPE
                WHEN 'SLP' THEN CONVERT(VARCHAR(50),dbo.fn_BSC_KPI_SCORE_SLOPE(TB.ESTTERM_REF_ID, TB.ALL_KPI_REF_ID, TB.YMD, 'TS'))
                WHEN 'STA' THEN CONVERT(VARCHAR(50),dbo.fn_BSC_KPI_SCORE_STAIR(TB.ESTTERM_REF_ID, TB.ALL_KPI_REF_ID, TB.YMD, 'TS'))
                WHEN 'NON' THEN CONVERT(VARCHAR(50),dbo.fn_BSC_KPI_SCORE_EACH (TB.ESTTERM_REF_ID, TB.RESULT_KPI_REF_ID,TB.YMD,'TS'))
          ELSE '-'
          END
         ,GETDATE()
FROM (
    SELECT  TA.ESTTERM_REF_ID
            ,TA.ALL_KPI_REF_ID
            ,CASE WHEN (TA.RESULT_KPI_REF_ID = -999999 OR TA.COMP_KPI = -999999) THEN -999999 
             ELSE TA.RESULT_KPI_REF_ID
             END as RESULT_KPI_REF_ID
            ,TA.YMD
    FROM (
        SELECT  A.ESTTERM_REF_ID
               ,A.KPI_REF_ID                   as ALL_KPI_REF_ID
               ,ISNULL(B.KPI_REF_ID,-999999)   as RESULT_KPI_REF_ID 
               ,ISNULL(C.KPI_REF_ID,-999999)   as COMP_KPI
               ,ISNULL(B.YMD, @YMD)           as YMD
        FROM BSC_KPI_INFO A 
        LEFT JOIN BSC_KPI_TERM B ON A.ESTTERM_REF_ID = B.ESTTERM_REF_ID
                                AND A.KPI_REF_ID     = B.KPI_REF_ID
                                AND B.YMD            = @YMD
                                AND B.CHECK_YN       = 'Y'
        LEFT JOIN (
            SELECT ESTTERM_REF_ID, KPI_REF_ID
            FROM BSC_KPI_INFO KI
            INNER JOIN COM_APPROVAL_INFO AI ON KI.APP_REF_ID = AI.APP_REF_ID
            WHERE   KI.ISDELETE       = 'N'
                AND KI.USE_YN         = 'Y'
                AND AI.APP_STATUS     = 'CFT'
                AND AI.ACTIVE_YN      = 'Y'
        ) C ON  A.ESTTERM_REF_ID = C.ESTTERM_REF_ID
            AND A.KPI_REF_ID     = C.KPI_REF_ID
        WHERE A.ESTTERM_REF_ID      = @ESTTERM_REF_ID
    ) TA   
) TB
                       
------------------------------------------------------------------       
-- 가중치 배분 프로시저 콜
------------------------------------------------------------------          
EXECUTE usp_BSC_WEIGHT_ALLOCATION @iESTTERM_REF_ID = @ESTTERM_REF_ID, @iYMD = @YMD

SELECT 'Y' as RtnFlag, '계산성공.' as RtnMsg
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, strQuery, "BSC_TERM_CALC", null, paramArray, CommandType.Text).Tables[0];

            if (dt.Rows[0]["RtnFlag"].ToString() == "Y")
                return true;
            else
            {
                this.Transaction_Message = dt.Rows[0]["RtnMsg"].ToString();
                return false;
            }
        }

        /// <summary>
        /// 당월 실적마감
        /// </summary>
        /// <param name="pIestterm_ref_id"></param>
        /// <param name="pIymd"></param>
        /// <param name="pIclose_desc"></param>
        /// <param name="pItxr_user"></param>
        /// <returns></returns>
        public int CloseTermMonth(int pIestterm_ref_id, string pIymd, string pIclose_desc, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CM";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iCLOSE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = pIclose_desc;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = pItxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE.PROC_CLOSE_MONTHLY_RESULT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        /// <summary>
        /// 당월 실적마감 - 가중치 배분
        /// </summary>
        /// <param name="pIestterm_ref_id"></param>
        /// <param name="pIymd"></param>
        /// <param name="pIclose_desc"></param>
        /// <param name="pItxr_user"></param>
        /// <returns></returns>
        public int CloseTermMonthForWeight(int pIestterm_ref_id, string pIymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = pIestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[1].Value         = pIymd;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WEIGHT_ALLOCATION", "usp_BSC_WEIGHT_ALLOCATION"), paramArray, CommandType.StoredProcedure, out col);


            return affectedRow;
        }

        /// <summary>
        /// 당월 실적마감
        /// </summary>
        /// <param name="pIestterm_ref_id"></param>
        /// <param name="pIymd"></param>
        /// <param name="pIclose_desc"></param>
        /// <param name="pItxr_user"></param>
        /// <returns></returns>
        public int CloseTermMonth_Goal(int pIestterm_ref_id, string pIymd, string pIclose_desc, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CM";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iCLOSE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = pIclose_desc;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = pItxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE_GOAL.PROC_CLOSE_MONTHLY_RESULT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 당월실적 마감취소
        /// </summary>
        /// <param name="pIestterm_ref_id"></param>
        /// <param name="pIymd"></param>
        /// <param name="pIclose_desc"></param>
        /// <param name="pItxr_user"></param>
        /// <returns></returns>
        public int CancelTermMonth(int pIestterm_ref_id, string pIymd, string pIclose_desc, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CL";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iCLOSE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = pIclose_desc;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = pItxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char ,1 );
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE.PROC_CANCEL_MONTHLY_RESULT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        public int CancelTermMonth_GOAL(int pIestterm_ref_id, string pIymd, string pIclose_desc, int pItxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CL";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = pIestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = pIymd;
            paramArray[3]               = CreateDataParameter("@iCLOSE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = pIclose_desc;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = pItxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char ,1 );
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE_GOAL.PROC_CANCEL_MONTHLY_RESULT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 지표별 원시점수 구하기
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="iymd">평가년월</param>
        /// <returns></returns>
        public DataSet GetOriginalScorePerKPI(int iestterm_ref_id, string iymd )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "OS";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE.PROC_SELECT_ORIGINAL_SCORE"), "BSC_TERM_CLOSE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 지표별 최종 점수 구하기
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public DataSet GetFinalScoreApplyNormdist(int iestterm_ref_id, string iymd )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "FS";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE.PROC_SELECT_FINAL_SCORE"), "BSC_TERM_CLOSE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public int SetNormdisScoreRollUp(int iestterm_ref_id, string iymd )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "FR";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char ,1 );
            paramArray[4].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_TERM_CLOSE", "PKG_BSC_TERM_CLOSE.PROC_ROLLUP_FINAL_SCORE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

    #endregion
    }
}
