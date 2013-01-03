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
/// Dac_Bsc_View_Info의 요약 설명입니다.
/// </summary>

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_View_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================

        private string _itype;
        private int _iview_ref_id;
        private int _iview_seq;
        private string _iview_name;
        private string _iview_desc;
        private string _iview_etc;
        private string _iview_image_name;
        private string _iuse_yn;
        private Int32 _create_user;
        private DateTime _create_date;
        private Int32 _update_user;
        private DateTime _update_date;
        private String _txr_message; // 처리결과메시지
        private String _txr_result; // 처리결과여부(Y,N)
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

        public int Iview_ref_id
        {
            get
            {
                return _iview_ref_id;
            }
            set
            {
                _iview_ref_id = value;
            }
        }

        public int Iview_seq
        {
            get
            {
                return _iview_seq;
            }
            set
            {
                _iview_seq = value;
            }
        }

        public string Iview_name
        {
            get
            {
                return _iview_name;
            }
            set
            {
                _iview_name = (value == null ? "" : value);
            }
        }

        public string Iview_desc
        {
            get
            {
                return _iview_desc;
            }
            set
            {
                _iview_desc = (value == null ? "" : value);
            }
        }

        public string Iview_etc
        {
            get
            {
                return _iview_etc;
            }
            set
            {
                _iview_etc = (value == null ? "" : value);
            }
        }

        public string Iview_image_name
        {
            get
            {
                return _iview_image_name;
            }
            set
            {
                _iview_image_name = (value == null ? "" : value);
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
        public Dac_Bsc_View_Info() { }
        public Dac_Bsc_View_Info(int iview_ref_id)
        {
            DataSet ds = this.GetOneList(iview_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _iview_ref_id     = (dr["VIEW_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["VIEW_REF_ID"]);
                _iview_seq        = (dr["VIEW_SEQ"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["VIEW_SEQ"]);
                _iview_name       = (dr["VIEW_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["VIEW_NAME"]);
                _iview_desc       = (dr["VIEW_DESC"]       == DBNull.Value) ? "" : Convert.ToString(dr["VIEW_DESC"]);
                _iview_etc        = (dr["VIEW_ETC"]        == DBNull.Value) ? "" : Convert.ToString(dr["VIEW_ETC"]);
                _iview_image_name = (dr["VIEW_IMAGE_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["VIEW_IMAGE_NAME"]);
                _iuse_yn          = (dr["USE_YN"]      == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user      = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date      = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user      = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date      = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iview_seq, string iview_name, string iview_desc, string iview_etc,
                                              string iview_image_name, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iVIEW_SEQ", SqlDbType.Int);
            paramArray[1].Value         = iview_seq;
            paramArray[2]               = CreateDataParameter("@iVIEW_NAME", SqlDbType.VarChar,200);
            paramArray[2].Value         = iview_name;
            paramArray[3]               = CreateDataParameter("@iVIEW_DESC", SqlDbType.VarChar,2000);
            paramArray[3].Value         = iview_desc;
            paramArray[4]               = CreateDataParameter("@iVIEW_ETC", SqlDbType.VarChar,2000);
            paramArray[4].Value         = iview_etc;
            paramArray[5]               = CreateDataParameter("@iVIEW_IMAGE_NAME", SqlDbType.VarChar,200);
            paramArray[5].Value         = iview_image_name;
            paramArray[6]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value         = itxr_user;
            paramArray[7]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[7].Direction     = ParameterDirection.Output;
            paramArray[8]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_VIEW_REF_ID", SqlDbType.Int);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VIEW_INFO", "PKG_BSC_VIEW_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();
            this.Iview_ref_id           = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_VIEW_REF_ID").ToString());
           
            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iview_ref_id, int iview_seq, string iview_name, string iview_desc, string iview_etc,
                              string iview_image_name, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar,2);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iview_ref_id;
            paramArray[2]               = CreateDataParameter("@iVIEW_SEQ", SqlDbType.Int);
            paramArray[2].Value         = iview_seq;
            paramArray[3]               = CreateDataParameter("@iVIEW_NAME", SqlDbType.VarChar,200);
            paramArray[3].Value         = iview_name;
            paramArray[4]               = CreateDataParameter("@iVIEW_DESC", SqlDbType.VarChar,2000);
            paramArray[4].Value         = iview_desc;
            paramArray[5]               = CreateDataParameter("@iVIEW_ETC", SqlDbType.VarChar,2000);
            paramArray[5].Value         = iview_etc;
            paramArray[6]               = CreateDataParameter("@iVIEW_IMAGE_NAME", SqlDbType.VarChar,200);
            paramArray[6].Value         = iview_image_name;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VIEW_INFO", "PKG_BSC_VIEW_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
          
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(Int32 iview_ref_id, String iuse_yn, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar,2);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iview_ref_id;
            paramArray[2]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[2].Value         = iuse_yn;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VIEW_INFO", "PKG_BSC_VIEW_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
           
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(Int32 iview_ref_id, String iuse_yn, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iview_ref_id;
            paramArray[2] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[2].Value = iuse_yn;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VIEW_INFO", "PKG_BSC_VIEW_INFO.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VIEW_INFO", "PKG_BSC_VIEW_INFO.PROC_SELECT_ALL"), "BSC_VIEW_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(Int32 iview_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iview_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VIEW_INFO", "PKG_BSC_VIEW_INFO.PROC_SELECT_ONE"), "BSC_VIEW_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public int GetMaxViewRefID()
        {
            string query = @"SELECT VIEW_REF_ID
                               FROM BSC_VIEW_INFO
                              WHERE VIEW_SEQ = (SELECT MAX(VIEW_SEQ) 
                                                  FROM BSC_VIEW_INFO)";

            //IDbDataParameter[] paramArray = CreateDataParameters(1);

            //paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            //paramArray[0].Value = estterm_ref_id;

            object obj = DbAgentObj.ExecuteScalar(query, null, CommandType.Text);

            if (obj == DBNull.Value)
                return 0;

            return Convert.ToInt32(obj);
        }

        #endregion
    }
}