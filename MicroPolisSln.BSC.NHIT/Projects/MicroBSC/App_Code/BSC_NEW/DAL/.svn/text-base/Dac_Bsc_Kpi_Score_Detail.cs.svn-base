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
/// Dac_Bsc_Kpi_Result의 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Score_Detail Dac 클래스
/// Class 내용		@ Bsc_Kpi_Score_Detail Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.11.21
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Score_Detail : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int      _iestterm_ref_id;
        private int      _ikpi_ref_id;
        private string   _iymd;
        private string   _inrmdst_use_ms ;
        private string   _ipoints_ori_ms   ;
        private string   _ipoints_avg_ms   ;
        private string   _ipoints_std_ms   ;
        private string   _ipoints_ada_ms   ;
        private string   _ipoints_ads_ms   ;
        private string   _ipoints_nor_ms   ;
        private string   _ipoints_fnl_ms   ;
        private string   _inrmdst_use_ts   ;
        private string   _ipoints_ori_ts   ;
        private string   _ipoints_avg_ts   ;
        private string   _ipoints_std_ts   ;
        private string   _ipoints_ada_ts   ;
        private string   _ipoints_ads_ts   ;
        private string   _ipoints_nor_ts   ;
        private string   _ipoints_fnl_ts   ;
        private int      _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)

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
        public string Iymd
        {
            get
            {
                return _iymd;
            }
            set
            {
                _iymd = (value == null ? "" : value);
            }
        }
        public string Inrmdst_use_ms
        {
            get
            {
                return _inrmdst_use_ms;
            }
            set
            {
                _inrmdst_use_ms = (value == null ? "" : value);
            }
        }

        public string Ipoints_ori_ms
        {
            get
            {
                return _ipoints_ori_ms;
            }
            set
            {
                _ipoints_ori_ms = (value == null ? "" : value);
            }
        }
        public string Ipoints_avg_ms
        {
            get
            {
                return _ipoints_avg_ms;
            }
            set
            {
                _ipoints_avg_ms = (value == null ? "" : value);
            }
        }
        public string Ipoints_std_ms
        {
            get
            {
                return _ipoints_std_ms;
            }
            set
            {
                _ipoints_std_ms = (value == null ? "" : value);
            }
        }
        public string Ipoints_ada_ms
        {
            get
            {
                return _ipoints_ada_ms;
            }
            set
            {
                _ipoints_ada_ms = (value == null ? "" : value);
            }
        }
        public string Ipoints_ads_ms
        {
            get
            {
                return _ipoints_ads_ms;
            }
            set
            {
                _ipoints_ads_ms = (value == null ? "" : value);
            }
        }
        public string Ipoints_nor_ms
        {
            get
            {
                return _ipoints_nor_ms;
            }
            set
            {
                _ipoints_nor_ms = (value == null ? "" : value);
            }
        }
        public string Ipoints_fnl_ms
        {
            get
            {
                return _ipoints_fnl_ms;
            }
            set
            {
                _ipoints_fnl_ms = (value == null ? "" : value);
            }
        }
        public string Inrmdst_use_ts
        {
            get
            {
                return _inrmdst_use_ts;
            }
            set
            {
                _inrmdst_use_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_ori_ts
        {
            get
            {
                return _ipoints_ori_ts;
            }
            set
            {
                _ipoints_ori_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_avg_ts
        {
            get
            {
                return _ipoints_avg_ts;
            }
            set
            {
                _ipoints_avg_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_std_ts
        {
            get
            {
                return _ipoints_std_ts;
            }
            set
            {
                _ipoints_std_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_ada_ts
        {
            get
            {
                return _ipoints_ada_ts;
            }
            set
            {
                _ipoints_ada_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_ads_ts
        {
            get
            {
                return _ipoints_ads_ts;
            }
            set
            {
                _ipoints_ads_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_nor_ts
        {
            get
            {
                return _ipoints_nor_ts;
            }
            set
            {
                _ipoints_nor_ts = (value == null ? "" : value);
            }
        }
        public string Ipoints_fnl_ts
        {
            get
            {
                return _ipoints_fnl_ts;
            }
            set
            {
                _ipoints_fnl_ts = (value == null ? "" : value);
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
    
        #region ============================== [Constructor] ==============================
        public Dac_Bsc_Kpi_Score_Detail() { }

        public Dac_Bsc_Kpi_Score_Detail(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, iymd);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id   = (dr["ESTTERM_REF_ID"]   == DBNull.Value) ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id       = (dr["KPI_REF_ID"]       == DBNull.Value) ? 0  : Convert.ToInt32(dr["KPI_REF_ID"]);
                _iymd              = (dr["YMD"]              == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _inrmdst_use_ms    = (dr["NRMDST_USE_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["NRMDST_USE_MS"]);
                _ipoints_ori_ms    = (dr["POINTS_ORI_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_ORI_MS"]);
                _ipoints_avg_ms    = (dr["POINTS_AVG_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_AVG_MS"]);
                _ipoints_std_ms    = (dr["POINTS_STD_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_STD_MS"]);
                _ipoints_ada_ms    = (dr["POINTS_ADA_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_ADA_MS"]);
                _ipoints_ads_ms    = (dr["POINTS_ADS_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_ADS_MS"]);
                _ipoints_nor_ms    = (dr["POINTS_NOR_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_NOR_MS"]);
                _ipoints_fnl_ms    = (dr["POINTS_FNL_MS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_FNL_MS"]);
                _inrmdst_use_ts    = (dr["NRMDST_USE_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["NRMDST_USE_TS"]);
                _ipoints_ori_ts    = (dr["POINTS_ORI_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_ORI_TS"]);
                _ipoints_avg_ts    = (dr["POINTS_AVG_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_AVG_TS"]);
                _ipoints_std_ts    = (dr["POINTS_STD_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_STD_TS"]);
                _ipoints_ada_ts    = (dr["POINTS_ADA_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_ADA_TS"]);
                _ipoints_ads_ts    = (dr["POINTS_ADS_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_ADS_TS"]);
                _ipoints_nor_ts    = (dr["POINTS_NOR_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_NOR_TS"]);
                _ipoints_fnl_ts    = (dr["POINTS_FNL_TS"]    == DBNull.Value) ? "" : Convert.ToString(dr["POINTS_FNL_TS"]);
                _create_user       = (dr["CREATE_USER"]      == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date       = (dr["CREATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user       = (dr["UPDATE_USER"]      == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date       = (dr["UPDATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion
    
        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                              (int iestterm_ref_id, int ikpi_ref_id, string iymd, 
                               string inrmdst_use_ms, string ipoints_ori_ms, string ipoints_avg_ms, string ipoints_std_ms, string ipoints_ada_ms, string ipoints_ads_ms, string ipoints_nor_ms, string ipoints_fnl_ms, 
                               string inrmdst_use_ts, string ipoints_ori_ts, string ipoints_avg_ts, string ipoints_std_ts, string ipoints_ada_ts, string ipoints_ads_ts, string ipoints_nor_ts, string ipoints_fnl_ts, 
                               int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iNRMDST_USE_MS", SqlDbType.Char,1);
            paramArray[4].Value         = inrmdst_use_ms;
            paramArray[5]               = CreateDataParameter("@iPOINTS_ORI_MS", SqlDbType.VarChar);
            paramArray[5].Value         = ipoints_ori_ms;
            paramArray[6]               = CreateDataParameter("@iPOINTS_AVG_MS", SqlDbType.VarChar);
            paramArray[6].Value         = ipoints_avg_ms;
            paramArray[7]               = CreateDataParameter("@iPOINTS_STD_MS", SqlDbType.VarChar);
            paramArray[7].Value         = ipoints_std_ms;
            paramArray[8]               = CreateDataParameter("@iPOINTS_ADA_MS", SqlDbType.VarChar);
            paramArray[8].Value         = ipoints_ada_ms;
            paramArray[9]               = CreateDataParameter("@iPOINTS_ADS_MS", SqlDbType.VarChar);
            paramArray[9].Value         = ipoints_ads_ms;
            paramArray[10]              = CreateDataParameter("@iPOINTS_NOR_MS", SqlDbType.VarChar);
            paramArray[10].Value        = ipoints_nor_ms;
            paramArray[11]              = CreateDataParameter("@iPOINTS_FNL_MS", SqlDbType.VarChar);
            paramArray[11].Value        = ipoints_fnl_ms;
            paramArray[12]               = CreateDataParameter("@iNRMDST_USE_TS", SqlDbType.Char,1);
            paramArray[12].Value         = inrmdst_use_ts;
            paramArray[13]              = CreateDataParameter("@iPOINTS_ORI_TS", SqlDbType.VarChar);
            paramArray[13].Value        = ipoints_ori_ts;
            paramArray[14]              = CreateDataParameter("@iPOINTS_AVG_TS", SqlDbType.VarChar);
            paramArray[14].Value        = ipoints_avg_ts;
            paramArray[15]              = CreateDataParameter("@iPOINTS_STD_TS", SqlDbType.VarChar);
            paramArray[15].Value        = ipoints_std_ts;
            paramArray[16]              = CreateDataParameter("@iPOINTS_ADA_TS", SqlDbType.VarChar);
            paramArray[16].Value        = ipoints_ada_ts;
            paramArray[17]              = CreateDataParameter("@iPOINTS_ADS_TS", SqlDbType.VarChar);
            paramArray[17].Value        = ipoints_ads_ts;
            paramArray[18]              = CreateDataParameter("@iPOINTS_NOR_TS", SqlDbType.VarChar);
            paramArray[18].Value        = ipoints_nor_ts;
            paramArray[19]              = CreateDataParameter("@iPOINTS_FNL_TS", SqlDbType.VarChar);
            paramArray[19].Value        = ipoints_fnl_ts;
            paramArray[20]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[20].Value        = itxr_user;
            paramArray[21]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[21].Direction    = ParameterDirection.Output;
            paramArray[22]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[22].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL", "PKG_BSC_KPI_SCORE_DETAIL.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                              (int iestterm_ref_id, int ikpi_ref_id, string iymd, 
                               string inrmdst_use_ms, string ipoints_ori_ms, string ipoints_avg_ms, string ipoints_std_ms, string ipoints_ada_ms, string ipoints_ads_ms, string ipoints_nor_ms, string ipoints_fnl_ms, 
                               string inrmdst_use_ts, string ipoints_ori_ts, string ipoints_avg_ts, string ipoints_std_ts, string ipoints_ada_ts, string ipoints_ads_ts, string ipoints_nor_ts, string ipoints_fnl_ts, 
                               int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iNRMDST_USE_MS", SqlDbType.Char,1);
            paramArray[4].Value         = inrmdst_use_ms;
            paramArray[5]               = CreateDataParameter("@iPOINTS_ORI_MS", SqlDbType.VarChar);
            paramArray[5].Value         = ipoints_ori_ms;
            paramArray[6]               = CreateDataParameter("@iPOINTS_AVG_MS", SqlDbType.VarChar);
            paramArray[6].Value         = ipoints_avg_ms;
            paramArray[7]               = CreateDataParameter("@iPOINTS_STD_MS", SqlDbType.VarChar);
            paramArray[7].Value         = ipoints_std_ms;
            paramArray[8]               = CreateDataParameter("@iPOINTS_ADA_MS", SqlDbType.VarChar);
            paramArray[8].Value         = ipoints_ada_ms;
            paramArray[9]               = CreateDataParameter("@iPOINTS_ADS_MS", SqlDbType.VarChar);
            paramArray[9].Value         = ipoints_ads_ms;
            paramArray[10]              = CreateDataParameter("@iPOINTS_NOR_MS", SqlDbType.VarChar);
            paramArray[10].Value        = ipoints_nor_ms;
            paramArray[11]              = CreateDataParameter("@iPOINTS_FNL_MS", SqlDbType.VarChar);
            paramArray[11].Value        = ipoints_fnl_ms;
            paramArray[12]              = CreateDataParameter("@iNRMDST_USE_TS", SqlDbType.Char,1);
            paramArray[12].Value        = inrmdst_use_ts;
            paramArray[13]              = CreateDataParameter("@iPOINTS_ORI_TS", SqlDbType.VarChar);
            paramArray[13].Value        = ipoints_ori_ts;
            paramArray[14]              = CreateDataParameter("@iPOINTS_AVG_TS", SqlDbType.VarChar);
            paramArray[14].Value        = ipoints_avg_ts;
            paramArray[15]              = CreateDataParameter("@iPOINTS_STD_TS", SqlDbType.VarChar);
            paramArray[15].Value        = ipoints_std_ts;
            paramArray[16]              = CreateDataParameter("@iPOINTS_ADA_TS", SqlDbType.VarChar);
            paramArray[16].Value        = ipoints_ada_ts;
            paramArray[17]              = CreateDataParameter("@iPOINTS_ADS_TS", SqlDbType.VarChar);
            paramArray[17].Value        = ipoints_ads_ts;
            paramArray[18]              = CreateDataParameter("@iPOINTS_NOR_TS", SqlDbType.VarChar);
            paramArray[18].Value        = ipoints_nor_ts;
            paramArray[19]              = CreateDataParameter("@iPOINTS_FNL_TS", SqlDbType.VarChar);
            paramArray[19].Value        = ipoints_fnl_ts;
            paramArray[20]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[20].Value        = itxr_user;
            paramArray[21]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[21].Direction    = ParameterDirection.Output;
            paramArray[22]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[22].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL", "PKG_BSC_KPI_SCORE_DETAIL.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL","PKG_BSC_KPI_SCORE_DETAIL.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteDataAll_Dac(int iestterm_ref_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "DA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL","PKG_BSC_KPI_SCORE_DETAIL.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateExternalScore_Dac
                              (int iestterm_ref_id, int ikpi_ref_id, string iymd, 
                               string inrmdst_use_ts, string ipoints_ori_ts, string ipoints_avg_ts, string ipoints_std_ts, string ipoints_ada_ts, string ipoints_ads_ts, string ipoints_nor_ts, string ipoints_fnl_ts, 
                               int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(15);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "UX";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iNRMDST_USE_TS", SqlDbType.Char,1);
            paramArray[4].Value         = inrmdst_use_ts;
            paramArray[5]               = CreateDataParameter("@iPOINTS_ORI_TS", SqlDbType.VarChar);
            paramArray[5].Value         = ipoints_ori_ts;
            paramArray[6]               = CreateDataParameter("@iPOINTS_AVG_TS", SqlDbType.VarChar);
            paramArray[6].Value         = ipoints_avg_ts;
            paramArray[7]               = CreateDataParameter("@iPOINTS_STD_TS", SqlDbType.VarChar);
            paramArray[7].Value         = ipoints_std_ts;
            paramArray[8]               = CreateDataParameter("@iPOINTS_ADA_TS", SqlDbType.VarChar);
            paramArray[8].Value         = ipoints_ada_ts;
            paramArray[9]               = CreateDataParameter("@iPOINTS_ADS_TS", SqlDbType.VarChar);
            paramArray[9].Value         = ipoints_ads_ts;
            paramArray[10]              = CreateDataParameter("@iPOINTS_NOR_TS", SqlDbType.VarChar);
            paramArray[10].Value        = ipoints_nor_ts;
            paramArray[11]              = CreateDataParameter("@iPOINTS_FNL_TS", SqlDbType.VarChar);
            paramArray[11].Value        = ipoints_fnl_ts;
            paramArray[12]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value        = itxr_user;
            paramArray[13]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[13].Direction    = ParameterDirection.Output;
            paramArray[14]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[14].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL", "PKG_BSC_KPI_SCORE_DETAIL.PROC_UPDATE_EXT_SCORE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 외부지표 원시점수 반영
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public int UpdateExternalOriScore(int iestterm_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "UO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char ,1 );
            paramArray[4].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL", "PKG_BSC_KPI_SCORE_DETAIL.PROC_UPDATE_EXT_ORI_SCORE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 지표별 외부점수 구하기
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="iymd">평가년월</param>
        /// <returns></returns>
        public DataSet GetExternalScorePerKPI(int iestterm_ref_id, string iymd )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "XS";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL", "PKG_BSC_KPI_SCORE_DETAIL.PROC_SELECT_FOR_EXT_SCORE"), "BSC_TERM_CLOSE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetAllList(int iestterm_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL","PKG_BSC_KPI_SCORE_DETAIL.PROC_SELECT_ALL"), "BSC_KPI_SCORE_DETAIL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_SCORE_DETAIL","PKG_BSC_KPI_SCORE_DETAIL.PROC_SELECT_ONE"), "BSC_KPI_SCORE_DETAIL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }

}