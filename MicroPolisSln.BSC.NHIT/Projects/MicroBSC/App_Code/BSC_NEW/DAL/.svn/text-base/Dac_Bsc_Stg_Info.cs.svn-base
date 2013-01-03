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
/// Dac_Bsc_Stg_Info의 요약 설명입니다.
/// </summary>

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Stg_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================

        private int      _iestterm_ref_id;
        private int      _istg_ref_id;
        private int      _iup_stg_id;
        private string   _istg_code;
        private string   _istg_name;
        private string   _istg_set_desc;
        private string   _istg_etc;
        private string   _iuse_yn;
        private int      _create_user;
        private DateTime _create_date;
        private int      _update_user;
        private DateTime _update_date;
        private string   _txr_message; // 처리결과메시지
        private string   _txr_result; // 처리결과여부(Y,N)
        private int _view_ref_id;
        #endregion

        #region ============================== [Properties] ==============================
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

        public int Istg_ref_id
        {
            get
            {
                return _istg_ref_id;
            }
            set
            {
                _istg_ref_id = value;
            }
        }

        public int Iup_stg_id
        {
            get
            {
                return _iup_stg_id;
            }
            set
            {
                _iup_stg_id = value;
            }
        }

        public string Istg_code
        {
            get
            {
                return _istg_code;
            }
            set
            {
                _istg_code = (value == null ? "" : value);
            }
        }

        public string Istg_name
        {
            get
            {
                return _istg_name;
            }
            set
            {
                _istg_name = (value == null ? "" : value);
            }
        }

        public string Istg_set_desc
        {
            get
            {
                return _istg_set_desc;
            }
            set
            {
                _istg_set_desc = (value == null ? "" : value);
            }
        }

        public string Istg_etc
        {
            get
            {
                return _istg_etc;
            }
            set
            {
                _istg_etc = (value == null ? "" : value);
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

        public int View_ref_id
        {
            get
            {
                return _view_ref_id;
            }
            set
            {
                _view_ref_id = value;
            }
        }

        #endregion

        #region ============================== [Constructor] ==============================

        public Dac_Bsc_Stg_Info() 
        {
        
        }

        public Dac_Bsc_Stg_Info(int iestterm_ref_id, int istg_ref_id)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, istg_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _istg_ref_id     = (dr["STG_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
                _iup_stg_id      = (dr["UP_STG_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["UP_STG_ID"]);
                _istg_code       = (dr["STG_CODE"]       == DBNull.Value) ? "" : Convert.ToString(dr["STG_CODE"]);
                _istg_name       = (dr["STG_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["STG_NAME"]);
                _istg_set_desc   = (dr["STG_SET_DESC"]   == DBNull.Value) ? "" : Convert.ToString(dr["STG_SET_DESC"]);
                _istg_etc        = (dr["STG_ETC"]        == DBNull.Value) ? "" : Convert.ToString(dr["STG_ETC"]);
                _iuse_yn         = (dr["USE_YN"]         == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user     = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date     = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user     = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date     = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _view_ref_id = (dr["VIEW_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["VIEW_REF_ID"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id
                                            , int iup_stg_id
                                            , string istg_code
                                            , string istg_name
                                            , string istg_set_desc
                                            , string istg_etc
                                            , string iuse_yn
                                            , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]       		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);																																																																						
            paramArray[0].Value 		= "A";																																																																						
            paramArray[1]       		= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);																																																																						
            paramArray[1].Value 		= iestterm_ref_id;																																																																						
            paramArray[2]       		= CreateDataParameter("@iUP_STG_ID", SqlDbType.Int);																																																																						
            paramArray[2].Value 		= iup_stg_id;																																																																						
            paramArray[3]       		= CreateDataParameter("@iSTG_CODE", SqlDbType.VarChar,20);																																																																						
            paramArray[3].Value 		= istg_code;																																																																						
            paramArray[4]       		= CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar,200);																																																																						
            paramArray[4].Value 		= istg_name;																																																																						
            paramArray[5]       		= CreateDataParameter("@iSTG_SET_DESC", SqlDbType.VarChar,2000);																																																																						
            paramArray[5].Value 		= istg_set_desc;																																																																						
            paramArray[6]       		= CreateDataParameter("@iSTG_ETC", SqlDbType.VarChar,2000);																																																																						
            paramArray[6].Value 		= istg_etc;																																																																						
            paramArray[7]       		= CreateDataParameter("@iUSE_YN", SqlDbType.VarChar,1);																																																																						
            paramArray[7].Value 		= iuse_yn;																																																																																																										
            paramArray[8]       		= CreateDataParameter("@iTXR_USER", SqlDbType.Int);																																																																																																										
            paramArray[8].Value 		= itxr_user;																																																																																																										
            paramArray[9]       		= CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);		
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_STG_REF_ID", SqlDbType.Int);
            paramArray[11].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();
            this.Istg_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_STG_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int InsertData_Dac(
                                             int iup_stg_id
                                            , string istg_code
                                            , string istg_name
                                            , string istg_set_desc
                                            , string istg_etc
                                            , string iuse_yn
                                            , int itxr_user
                                            , int view_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iUP_STG_ID", SqlDbType.Int);
            paramArray[1].Value = iup_stg_id;
            paramArray[2] = CreateDataParameter("@iSTG_CODE", SqlDbType.VarChar, 20);
            paramArray[2].Value = istg_code;
            paramArray[3] = CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar, 200);
            paramArray[3].Value = istg_name;
            paramArray[4] = CreateDataParameter("@iSTG_SET_DESC", SqlDbType.VarChar, 2000);
            paramArray[4].Value = istg_set_desc;
            paramArray[5] = CreateDataParameter("@iSTG_ETC", SqlDbType.VarChar, 2000);
            paramArray[5].Value = istg_etc;
            paramArray[6] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Value = iuse_yn;
            paramArray[7] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value = itxr_user;
            paramArray[8] = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[8].Value = view_ref_id;
            paramArray[9] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[9].Direction = ParameterDirection.Output;
            paramArray[10] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[10].Direction = ParameterDirection.Output;
            paramArray[11] = CreateDataParameter("@oRTN_STG_REF_ID", SqlDbType.Int);
            paramArray[11].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_INSERT1"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Istg_ref_id = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_STG_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id
                                                , int istg_ref_id
                                                , int iup_stg_id
                                                , string istg_code
                                                , string istg_name
                                                , string istg_set_desc
                                                , string istg_etc
                                                , string iuse_yn
                                                , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]       		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 		= "U";
            paramArray[1]       		= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 		= iestterm_ref_id;
            paramArray[2]       		= CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[2].Value 		= istg_ref_id;
            paramArray[3]       		= CreateDataParameter("@iUP_STG_ID", SqlDbType.Int);
            paramArray[3].Value 		= iup_stg_id;
            paramArray[4]       		= CreateDataParameter("@iSTG_CODE", SqlDbType.VarChar,20);
            paramArray[4].Value 		= istg_code;
            paramArray[5]       		= CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar,200);
            paramArray[5].Value 		= istg_name;
            paramArray[6]       		= CreateDataParameter("@iSTG_SET_DESC", SqlDbType.VarChar,2000);
            paramArray[6].Value 		= istg_set_desc;
            paramArray[7]       		= CreateDataParameter("@iSTG_ETC", SqlDbType.VarChar,2000);
            paramArray[7].Value 		= istg_etc;
            paramArray[8]       		= CreateDataParameter("@iUSE_YN", SqlDbType.VarChar,1);
            paramArray[8].Value 		= iuse_yn;
            paramArray[9]       		= CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value 		= itxr_user;
            paramArray[10]      		= CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);						
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[11].Direction    = ParameterDirection.Output;
            
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(
                                                int istg_ref_id
                                               , int iup_stg_id
                                               , string istg_code
                                               , string istg_name
                                               , string istg_set_desc
                                               , string istg_etc
                                               , string iuse_yn
                                               , int itxr_user, int VIEW_REF_ID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1] = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[1].Value = VIEW_REF_ID;
            paramArray[2] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[2].Value = istg_ref_id;
            paramArray[3] = CreateDataParameter("@iUP_STG_ID", SqlDbType.Int);
            paramArray[3].Value = iup_stg_id;
            paramArray[4] = CreateDataParameter("@iSTG_CODE", SqlDbType.VarChar, 20);
            paramArray[4].Value = istg_code;
            paramArray[5] = CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar, 200);
            paramArray[5].Value = istg_name;
            paramArray[6] = CreateDataParameter("@iSTG_SET_DESC", SqlDbType.VarChar, 2000);
            paramArray[6].Value = istg_set_desc;
            paramArray[7] = CreateDataParameter("@iSTG_ETC", SqlDbType.VarChar, 2000);
            paramArray[7].Value = istg_etc;
            paramArray[8] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar, 1);
            paramArray[8].Value = iuse_yn;
            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;
            paramArray[10] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[10].Direction = ParameterDirection.Output;
            paramArray[11] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[11].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_UPDATE1"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int istg_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = istg_ref_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(int iestterm_ref_id, int istg_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[2].Value = istg_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, string istg_code, string istg_name, string iuse_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 		= "SA";
            paramArray[1]       		= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 		= iestterm_ref_id;
            paramArray[2]       		= CreateDataParameter("@iSTG_CODE", SqlDbType.VarChar, 20);
            paramArray[2].Value 		= istg_code;
            paramArray[3]       		= CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar,200);
            paramArray[3].Value 		= istg_name;
            paramArray[4]       		= CreateDataParameter("@iUSE_YN", SqlDbType.VarChar,1);
            paramArray[4].Value 		= iuse_yn;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_SELECT_ALL"), "BSC_STG_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 상위관점 where 조건
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="istg_code"></param>
        /// <param name="istg_name"></param>
        /// <param name="iuse_yn"></param>
        /// <returns></returns>
        public DataSet GetAllList(string istg_code, string istg_name, string iuse_yn, string view_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1] = CreateDataParameter("@iSTG_CODE", SqlDbType.VarChar, 20);
            paramArray[1].Value = istg_code;
            paramArray[2] = CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar, 200);
            paramArray[2].Value = istg_name;
            paramArray[3] = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar, 1);
            paramArray[3].Value = iuse_yn;
            paramArray[4] = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[4].Value = view_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_SELECT_ALL1"), "BSC_STG_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public bool CopyStg(IDbConnection conn, IDbTransaction trx, object org_estterm_ref_id, object new_estterm_ref_id, object itxr_user)
        {
            this.Transaction_Message = "";

            string strQuery = @"
IF NOT EXISTS (SELECT * FROM BSC_STG_INFO WHERE ESTTERM_REF_ID = @NEW_ESTTERM_REF_ID)
BEGIN
    INSERT INTO BSC_STG_INFO
        (ESTTERM_REF_ID,        STG_REF_ID,     UP_STG_ID,      STG_CODE,       STG_NAME
        ,STG_SET_DESC,          STG_ETC,        USE_YN,         CREATE_DATE,    CREATE_USER)
    SELECT
        @NEW_ESTTERM_REF_ID,    STG_REF_ID,     UP_STG_ID,      CONVERT(VARCHAR, @NEW_ESTTERM_REF_ID) + '_' + CONVERT(VARCHAR, STG_REF_ID),       STG_NAME
        ,STG_SET_DESC,          STG_ETC,        USE_YN,         GETDATE(),      @CREATE_USER
    FROM    BSC_STG_INFO
    WHERE   ESTTERM_REF_ID  = @ORG_ESTTERM_REF_ID
END
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ORG_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = org_estterm_ref_id;
            paramArray[1] = CreateDataParameter("@NEW_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = new_estterm_ref_id;
            paramArray[2] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) > 0)
                return true;
            return false;
        }

        public DataSet GetOneList(int iestterm_ref_id, int istg_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar,2);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = istg_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_STG_INFO", "PKG_BSC_STG_INFO.PROC_SELECT_ONE"), "BSC_STG_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion
    }
}