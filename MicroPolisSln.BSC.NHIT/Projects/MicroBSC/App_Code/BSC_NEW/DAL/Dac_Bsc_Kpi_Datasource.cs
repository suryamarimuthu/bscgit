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

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Datasource : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int      _iestterm_ref_id;
        private int      _ikpi_ref_id;
        private int      _idatasource_id;
        private string   _ilevel1;
        private string   _ilevel2;
        private string   _ilevel3;
        private string   _iresult_source;
        private string   _itarget_source;
        private string   _iresult_create_time;
        private int      _iunit_type_ref_id;
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

        public int Idatasource_id
        {
            get
            {
                return _idatasource_id;
            }
            set
            {
                _idatasource_id = value;
            }
        }

        public string Ilevel1
        {
            get
            {
                return _ilevel1;
            }
            set
            {
                _ilevel1 = (value == null ? "" : value);
            }
        }

        public string Ilevel2
        {
            get
            {
                return _ilevel2;
            }
            set
            {
                _ilevel2 = (value == null ? "" : value);
            }
        }

        public string Ilevel3
        {
            get
            {
                return _ilevel3;
            }
            set
            {
                _ilevel3 = (value == null ? "" : value);
            }
        }

        public string Iresult_source
        {
            get
            {
                return _iresult_source;
            }
            set
            {
                _iresult_source = (value == null ? "" : value);
            }
        }

        public string Itarget_source
        {
            get
            {
                return _itarget_source;
            }
            set
            {
                _itarget_source = (value == null ? "" : value);
            }
        }

        public string Iresult_create_time
        {
            get
            {
                return _iresult_create_time;
            }
            set
            {
                _iresult_create_time = (value == null ? "" : value);
            }
        }

        public int Iunit_type_ref_id
        {
            get
            {
                return _iunit_type_ref_id;
            }
            set
            {
                _iunit_type_ref_id = value;
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
        public Dac_Bsc_Kpi_Datasource() {}

        public Dac_Bsc_Kpi_Datasource(int iestterm_ref_id, int ikpi_ref_id, int idatasource_id)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, idatasource_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id         = (dr["KPI_REF_ID"]         == DBNull.Value) ? 0  : Convert.ToInt32(dr["KPI_REF_ID"]);
                _idatasource_id      = (dr["DATASOURCE_ID"]      == DBNull.Value) ? 0  : Convert.ToInt32(dr["DATASOURCE_ID"]);
                _ilevel1             = (dr["LEVEL1"]             == DBNull.Value) ? "" : Convert.ToString(dr["LEVEL1"]);
                _ilevel2             = (dr["LEVEL2"]             == DBNull.Value) ? "" : Convert.ToString(dr["LEVEL2"]);
                _ilevel3             = (dr["LEVEL3"]             == DBNull.Value) ? "" : Convert.ToString(dr["LEVEL3"]);
                _iresult_source      = (dr["RESULT_SOURCE"]      == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_SOURCE"]);
                _itarget_source      = (dr["TARGET_SOURCE"]      == DBNull.Value) ? "" : Convert.ToString(dr["TARGET_SOURCE"]);
                _iresult_create_time = (dr["RESULT_CREATE_TIME"] == DBNull.Value) ? "" : Convert.ToString(dr["RESULT_CREATE_TIME"]);
                _iunit_type_ref_id   = (dr["UNIT_TYPE_REF_ID"]   == DBNull.Value) ? 0  : Convert.ToInt32(dr["UNIT_TYPE_REF_ID"]);
                _create_user         = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date         = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user         = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date         = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
 
        #endregion


        internal protected int InsertData_Dac(int iestterm_ref_id, int ikpi_ref_id, string ilevel1, string ilevel2, 
                                    string ilevel3, string iresult_source, string itarget_source, string iresult_create_time, 
                                    int iunit_type_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iLEVEL1", SqlDbType.VarChar);
            paramArray[3].Value         = ilevel1;
            paramArray[4]               = CreateDataParameter("@iLEVEL2", SqlDbType.VarChar);
            paramArray[4].Value         = ilevel2;
            paramArray[5]               = CreateDataParameter("@iLEVEL3", SqlDbType.VarChar);
            paramArray[5].Value         = ilevel3;
            paramArray[6]               = CreateDataParameter("@iRESULT_SOURCE", SqlDbType.VarChar);
            paramArray[6].Value         = iresult_source;
            paramArray[7]               = CreateDataParameter("@iTARGET_SOURCE", SqlDbType.VarChar);
            paramArray[7].Value         = itarget_source;
            paramArray[8]               = CreateDataParameter("@iRESULT_CREATE_TIME", SqlDbType.VarChar);
            paramArray[8].Value         = iresult_create_time;
            paramArray[9]               = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[9].Value         = iunit_type_ref_id;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[11].Direction    = ParameterDirection.Output;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[12].Direction    = ParameterDirection.Output;
            paramArray[13]              = CreateDataParameter("@oRTN_DATASOURCE_ID", SqlDbType.Int);
            paramArray[13].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Idatasource_id         = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_DATASOURCE_ID").ToString()); 

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, string ilevel1, string ilevel2,
                                    string ilevel3, string iresult_source, string itarget_source, string iresult_create_time,
                                    int iunit_type_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iDATASOURCE_ID", SqlDbType.Int);
            paramArray[3].Value         = idatasource_id;
            paramArray[4]               = CreateDataParameter("@iLEVEL1", SqlDbType.VarChar);
            paramArray[4].Value         = ilevel1;
            paramArray[5]               = CreateDataParameter("@iLEVEL2", SqlDbType.VarChar);
            paramArray[5].Value         = ilevel2;
            paramArray[6]               = CreateDataParameter("@iLEVEL3", SqlDbType.VarChar);
            paramArray[6].Value         = ilevel3;
            paramArray[7]               = CreateDataParameter("@iRESULT_SOURCE", SqlDbType.VarChar);
            paramArray[7].Value         = iresult_source;
            paramArray[8]               = CreateDataParameter("@iTARGET_SOURCE", SqlDbType.VarChar);
            paramArray[8].Value         = itarget_source;
            paramArray[9]               = CreateDataParameter("@iRESULT_CREATE_TIME", SqlDbType.VarChar);
            paramArray[9].Value         = iresult_create_time;
            paramArray[10]              = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[10].Value        = iunit_type_ref_id;
            paramArray[11]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value        = itxr_user;
            paramArray[12]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[12].Direction    = ParameterDirection.Output;
            paramArray[13]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[13].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iDATASOURCE_ID", SqlDbType.Int);
            paramArray[3].Value         = idatasource_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx, 
                                    int iestterm_ref_id, int ikpi_ref_id, string ilevel1, string ilevel2, 
                                    string ilevel3, string iresult_source, string itarget_source, string iresult_create_time, 
                                    int iunit_type_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iLEVEL1", SqlDbType.VarChar);
            paramArray[3].Value         = ilevel1;
            paramArray[4]               = CreateDataParameter("@iLEVEL2", SqlDbType.VarChar);
            paramArray[4].Value         = ilevel2;
            paramArray[5]               = CreateDataParameter("@iLEVEL3", SqlDbType.VarChar);
            paramArray[5].Value         = ilevel3;
            paramArray[6]               = CreateDataParameter("@iRESULT_SOURCE", SqlDbType.VarChar);
            paramArray[6].Value         = iresult_source;
            paramArray[7]               = CreateDataParameter("@iTARGET_SOURCE", SqlDbType.VarChar);
            paramArray[7].Value         = itarget_source;
            paramArray[8]               = CreateDataParameter("@iRESULT_CREATE_TIME", SqlDbType.VarChar);
            paramArray[8].Value         = iresult_create_time;
            paramArray[9]               = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[9].Value         = iunit_type_ref_id;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[11].Direction    = ParameterDirection.Output;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[12].Direction    = ParameterDirection.Output;
            paramArray[13]              = CreateDataParameter("@oRTN_DATASOURCE_ID", SqlDbType.Int);
            paramArray[13].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Idatasource_id = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_DATASOURCE_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, 
                                    int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, string ilevel1, string ilevel2,
                                    string ilevel3, string iresult_source, string itarget_source, string iresult_create_time,
                                    int iunit_type_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iDATASOURCE_ID", SqlDbType.Int);
            paramArray[3].Value         = idatasource_id;
            paramArray[4]               = CreateDataParameter("@iLEVEL1", SqlDbType.VarChar);
            paramArray[4].Value         = ilevel1;
            paramArray[5]               = CreateDataParameter("@iLEVEL2", SqlDbType.VarChar);
            paramArray[5].Value         = ilevel2;
            paramArray[6]               = CreateDataParameter("@iLEVEL3", SqlDbType.VarChar);
            paramArray[6].Value         = ilevel3;
            paramArray[7]               = CreateDataParameter("@iRESULT_SOURCE", SqlDbType.VarChar);
            paramArray[7].Value         = iresult_source;
            paramArray[8]               = CreateDataParameter("@iTARGET_SOURCE", SqlDbType.VarChar);
            paramArray[8].Value         = itarget_source;
            paramArray[9]               = CreateDataParameter("@iRESULT_CREATE_TIME", SqlDbType.VarChar);
            paramArray[9].Value         = iresult_create_time;
            paramArray[10]              = CreateDataParameter("@iUNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[10].Value        = iunit_type_ref_id;
            paramArray[11]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value        = itxr_user;
            paramArray[12]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[12].Direction    = ParameterDirection.Output;
            paramArray[13]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[13].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iDATASOURCE_ID", SqlDbType.Int);
            paramArray[3].Value         = idatasource_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_SELECT_ALL"), "Add_Datasource", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, int idatasource_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iDATASOURCE_ID", SqlDbType.Int);
            paramArray[3].Value         = idatasource_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DATASOURCE", "PKG_BSC_KPI_DATASOURCE.PROC_SELECT_ONE"), "Add_Datasource", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
    }
}
