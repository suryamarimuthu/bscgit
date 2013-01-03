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
/// Dac_Bsc_Kpi_Datasource에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Info Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.04.25
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Term : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int 	 _iestterm_ref_id;
        private int 	 _ikpi_ref_id;
        private string 	 _iymd;
        private string 	 _icheck_yn;
        private string 	 _ireport_yn;
        private string 	 _iestimate_yn;
        private int 	 _itxr_user;
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
		        _iymd = ( value==null ? "" : value );
	        }
        }
         
        public string Icheck_yn
        {
	        get 
	        {
		        return _icheck_yn;
	        }
	        set
	        {
		        _icheck_yn = ( value==null ? "" : value );
	        }
        }
         
        public string Ireport_yn
        {
	        get 
	        {
		        return _ireport_yn;
	        }
	        set
	        {
		        _ireport_yn = ( value==null ? "" : value );
	        }
        }
         
        public string Iestimate_yn
        {
	        get 
	        {
		        return _iestimate_yn;
	        }
	        set
	        {
		        _iestimate_yn = ( value==null ? "" : value );
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
        public Dac_Bsc_Kpi_Term() { }

        public Dac_Bsc_Kpi_Term(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, iymd);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id     = (dr["KPI_REF_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _iymd            = (dr["YMD"]             == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _icheck_yn       = (dr["CHECK_YN"]        == DBNull.Value) ? "" : Convert.ToString(dr["CHECK_YN"]);
                _ireport_yn      = (dr["REPORT_YN"]       == DBNull.Value) ? "" : Convert.ToString(dr["REPORT_YN"]);
                _iestimate_yn    = (dr["ESTIMATE_YN"]     == DBNull.Value) ? "" : Convert.ToString(dr["ESTIMATE_YN"]);
                _create_user     = (dr["CREATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date     = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user     = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date     = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iCHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = icheck_yn;
            paramArray[5]               = CreateDataParameter("@iREPORT_YN", SqlDbType.Char);
            paramArray[5].Value         = ireport_yn;
            paramArray[6]               = CreateDataParameter("@iESTIMATE_YN", SqlDbType.Char);
            paramArray[6].Value         = iestimate_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iCHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = icheck_yn;
            paramArray[5]               = CreateDataParameter("@iREPORT_YN", SqlDbType.Char);
            paramArray[5].Value         = ireport_yn;
            paramArray[6]               = CreateDataParameter("@iESTIMATE_YN", SqlDbType.Char);
            paramArray[6].Value         = iestimate_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteData_Dac(int    iestterm_ref_id, int ikpi_ref_id,     string iymd, int itxr_user)
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
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx,
                                              int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iCHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = icheck_yn;
            paramArray[5]               = CreateDataParameter("@iREPORT_YN", SqlDbType.Char);
            paramArray[5].Value         = ireport_yn;
            paramArray[6]               = CreateDataParameter("@iESTIMATE_YN", SqlDbType.Char);
            paramArray[6].Value         = iestimate_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx,
                                              int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
           
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iCHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = icheck_yn;
            paramArray[5]               = CreateDataParameter("@iREPORT_YN", SqlDbType.Char);
            paramArray[5].Value         = ireport_yn;
            paramArray[6]               = CreateDataParameter("@iESTIMATE_YN", SqlDbType.Char);
            paramArray[6].Value         = iestimate_yn;
            paramArray[7]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value         = itxr_user;
            paramArray[8]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction     = ParameterDirection.Output;
            paramArray[9]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
          
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
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
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
                       
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected DataSet GetMBOList(object estterm_ref_id, object kpi_ref_id)
        {
            string strQuery = @"
SELECT    ISNULL(B.ESTTERM_REF_ID, @ESTTERM_REF_ID) AS ESTTERM_REF_ID
        , ISNULL(B.KPI_REF_ID, @KPI_REF_ID) AS KPI_REF_ID
        , A.YMD
        , SUBSTRING(A.YMD, 1, 4) + '/' + SUBSTRING(A.YMD, 5, 2) AS YMD_DESC
        , ISNULL(B.CHECK_YN, 'N') AS CHECK_YN
        , D.TARGET_MS AS MS_PLAN
        , D.TARGET_TS AS TS_PLAN
        , A.CLOSE_YN
FROM    BSC_TERM_DETAIL                 A
LEFT OUTER JOIN BSC_KPI_TERM            B ON B.ESTTERM_REF_ID   = A.ESTTERM_REF_ID  AND B.KPI_REF_ID    = @KPI_REF_ID   AND B.YMD   = A.YMD
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  C ON C.ESTTERM_REF_ID   = B.ESTTERM_REF_ID  AND C.KPI_REF_ID    = B.KPI_REF_ID  AND C.USE_YN = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          D ON D.ESTTERM_REF_ID   = C.ESTTERM_REF_ID  AND D.KPI_REF_ID    = C.KPI_REF_ID  AND D.YMD   = B.YMD AND D.KPI_TARGET_VERSION_ID = C.KPI_TARGET_VERSION_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
ORDER BY A.YMD        
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_TERM_AND_TARGET", null, paramArray, CommandType.Text);
            return ds;
        }

        internal protected DataSet GetAllList_Dac(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_SELECT_ALL"), "BSC_KPI_TERM", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_SELECT_ONE"), "BSC_KPI_TERM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public string GetNavigateMonth(int iestterm_ref_id, int ikpi_ref_id, string iymd, gNavigator iNavigator)
        {
            string sNavigator = "";
            switch (iNavigator)
            { 
                case gNavigator.FIRST:
                    sNavigator = "F";
                    break;
                case gNavigator.LAST:
                    sNavigator = "L";
                    break;
                case gNavigator.NEXT:
                    sNavigator = "N";
                    break;
                case gNavigator.PREVIOUS:
                    sNavigator = "P";
                    break;
                default:
                    sNavigator = "C";
                    break;
            }

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "GM";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iNAVIGATOR", SqlDbType.VarChar);
            paramArray[4].Value         = sNavigator;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_SELECT_EST_MONTH"), "BSC_KPI_TERM", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables.Count < 1)
            {
                return "-";
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return (ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    return "-";
                }
            }

            //return Convert.ToString(DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_BSC_KPI_TERM", "PKG_BSC_KPI_TERM.PROC_SELECT_EST_MONTH"), paramArray, CommandType.StoredProcedure));
        }
        #endregion



        #region ========================== 멀티 DB 작업 ============================
        
        


        public int InsertData_DB(IDbConnection conn
                                            , IDbTransaction trx
                                            , object iestterm_ref_id
                                            , object ikpi_ref_id
                                            , object iymd
                                            , object icheck_yn
                                            , object ireport_yn
                                            , object iestimate_yn
                                            , object itxr_user)
        {
            string query = @"
INSERT INTO BSC_KPI_TERM
( ESTTERM_REF_ID
, KPI_REF_ID
, YMD
, CHECK_YN
, REPORT_YN
, ESTIMATE_YN
, CREATE_DATE
, CREATE_USER)
VALUES
( @ESTTERM_REF_ID
, @KPI_REF_ID
, @YMD
, @CHECK_YN
, @REPORT_YN
, @ESTIMATE_YN
, GETDATE()
, @TXR_USER)
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@CHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = icheck_yn;
            paramArray[5]               = CreateDataParameter("@REPORT_YN", SqlDbType.Char);
            paramArray[5].Value         = ireport_yn;
            paramArray[6]               = CreateDataParameter("@ESTIMATE_YN", SqlDbType.Char);
            paramArray[6].Value         = iestimate_yn;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public int UpdateData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object iymd
                                , object icheck_yn
                                , object itxr_user)
        {
            string query = @"

UPDATE BSC_KPI_TERM
    SET  YMD            = @YMD        
        ,CHECK_YN       = @CHECK_YN   
		,UPDATE_DATE    = GETDATE()
		,UPDATE_USER    = @TXR_USER
WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
    AND KPI_REF_ID     = @KPI_REF_ID    
    AND YMD            = @YMD
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@CHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = icheck_yn;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            

            return affectedRow;
        }

        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object estterm_ref_id
                                , object kpi_ref_id)
        {
            string query = @"

DELETE FROM BSC_KPI_TERM
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }
        #endregion
    }
}
