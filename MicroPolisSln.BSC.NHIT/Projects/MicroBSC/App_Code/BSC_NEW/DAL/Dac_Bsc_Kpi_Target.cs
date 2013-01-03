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
/// Dac_Bsc_Kpi_Target에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Target Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Target : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private string 	 _itype;
        private int 	 _iestterm_ref_id;
        private int 	 _ikpi_ref_id;
        private int 	 _ikpi_target_version_id;
        private string 	 _iymd;
        private double 	 _itarget_ms;
        private double 	 _itarget_ts;
        private int 	 _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
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
         
        public int Ikpi_target_version_id
        {
	        get 
	        {
		        return _ikpi_target_version_id;
	        }
	        set
	        {
		        _ikpi_target_version_id = value;
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
         
        public double Itarget_ms
        {
	        get 
	        {
		        return _itarget_ms;
	        }
	        set
	        {
		        _itarget_ms = value;
	        }
        }
         
        public double Itarget_ts
        {
	        get 
	        {
		        return _itarget_ts;
	        }
	        set
	        {
		        _itarget_ts = value;
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
        public Dac_Bsc_Kpi_Target() {}

        public Dac_Bsc_Kpi_Target(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
		        dr = ds.Tables[0].Rows[0];
		        _iestterm_ref_id        = (dr["ESTTERM_REF_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _ikpi_ref_id            = (dr["KPI_REF_ID"]             == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
		        _ikpi_target_version_id = (dr["KPI_TARGET_VERSION_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_TARGET_VERSION_ID"]);
		        _iymd                   = (dr["YMD"]                    == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
		        _itarget_ms             = (dr["TARGET_MS"]              == DBNull.Value) ? 0 : Convert.ToDouble(dr["TARGET_MS"]);
		        _itarget_ts             = (dr["TARGET_TS"]              == DBNull.Value) ? 0 : Convert.ToDouble(dr["TARGET_TS"]);
                _create_user            = (dr["CREATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date            = (dr["CREATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user            = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date            = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
	        }
         }
        #endregion
        
        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd, 
                                              double itarget_ms,   double itarget_ts, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd,
                                              double itarget_ms, double itarget_ts, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;
            paramArray[6]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[7].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx, 
                                              int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd, 
                                              double itarget_ms,   double itarget_ts, int itxr_user)
        {
            
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, 
                                              int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd,
                                              double itarget_ms, double itarget_ts, int itxr_user)
        {
            
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;
            paramArray[6]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[6].Direction     = ParameterDirection.Output;
            paramArray[7]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[7].Direction     = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            //paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            //paramArray[3].Value         = ikpi_target_version_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ALL"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ONE"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetNewTargetList(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S1";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_MOD_PLAN"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 하위지표 목표현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <returns></returns>
        public DataSet GetChildKpiTargetStatus(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CK";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_CHILD_KPI"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        
        #endregion


    }
}
