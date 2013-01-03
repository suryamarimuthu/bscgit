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
/// Dac_Bsc_Interface_Code의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Dashboard Dac 클래스
/// Class 내용		@ Dac_Bsc_Kpi_Dashboard Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.09.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// </summary>

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Dashboard : DbAgentBase
    {

        #region ------------------------ [ Field ] ------------------------
        private int _iestterm_ref_id;
        private int _ikpi_ref_id;
        private string _iselect_type;
        private string _igraph_type;
        private int _isort_order;
        private string _iuse_yn;
        private Int32 _itxr_user;
        private Int32 _create_user;
        private DateTime _create_date;
        private Int32 _update_user;
        private DateTime _update_date;
        private String _txr_message; // 처리결과메시지
        private String _txr_result;  // 처리결과여부(Y,N)
        #endregion

        #region ------------------------ [ Property ] ------------------------
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

        public string Iselect_type
        {
            get
            {
                return _iselect_type;
            }
            set
            {
                _iselect_type = value;
            }
        }
        public string Igraph_type
        {
            get { return _igraph_type; }
            set { _igraph_type = value; }
        }

        public int Isort_order
        {
            get { return _isort_order; }
            set { _isort_order = value; }
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
        public Dac_Bsc_Kpi_Dashboard() { }
        public Dac_Bsc_Kpi_Dashboard(int iestterm_ref_id, int Ikpi_ref_id)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, Ikpi_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id    = (dr["ESTTERM_REF_ID"] == DBNull.Value)               ? 0 :  Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id           = (dr["KPI_REF_ID"] == DBNull.Value)                   ? 0 :  Convert.ToInt32(dr["KPI_REF_ID"]);
                _iselect_type         = (dr["SELECT_TYPE"] == DBNull.Value) ? "" : Convert.ToString(dr["SELECT_TYPE"]);
                _igraph_type         = (dr["GRAPH_TYPE"] == DBNull.Value) ? "" : Convert.ToString(dr["GRAPH_TYPE"]);
                _isort_order = (dr["SORT_ORDER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _create_user                   = (dr["CREATE_USER"] == DBNull.Value)                  ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date                   = (dr["CREATE_DATE"] == DBNull.Value)                  ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user                   = (dr["UPDATE_USER"] == DBNull.Value)                  ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date                   = (dr["UPDATE_DATE"] == DBNull.Value)                  ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        /// <summary>
        /// 대쉬보드 지표분석 대상 KPI 추가
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <returns></returns>
        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string iselect_type, string igraph_type, int isort_order, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3] = CreateDataParameter("@iSELECT_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = iselect_type;
            paramArray[4] = CreateDataParameter("@iGRAPH_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = igraph_type;
            paramArray[5] = CreateDataParameter("@iSORT_ORDER", SqlDbType.VarChar);
            paramArray[5].Value = isort_order;
            paramArray[6] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value = itxr_user;
            paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[7].Direction = ParameterDirection.Output;
            paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[8].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, string iselect_type, string igraph_type, int isort_order, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3] = CreateDataParameter("@iSELECT_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = iselect_type;
            paramArray[4] = CreateDataParameter("@iGRAPH_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = igraph_type;
            paramArray[5] = CreateDataParameter("@iSORT_ORDER", SqlDbType.VarChar);
            paramArray[5].Value = isort_order;
            paramArray[6] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value = itxr_user;
            paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[7].Direction = ParameterDirection.Output;
            paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[8].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }



        /// <summary>
        /// 대쉬보드 지표분석 대상 KPI 전체조회
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <returns></returns>
        public DataSet GetAllList(int iestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_SELECT_ALL"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 대쉬보드 지표분석 대상 KPI 상세조회
        /// </summary>
        /// <param name="ikpi_pool_ref_id"></param>
        /// <returns></returns>
        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_SELECT_ONE"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 대쉬보드 관점별 점수
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <returns></returns>
        public DataSet GetDashBoardForViewScore(int iestterm_ref_id, int iest_dept_ref_id, string iymd, string isum_type )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "PV";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_SELECT_SCORE_PER_VIEW"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 대쉬보드 등급별 점수
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <returns></returns>
        public DataSet GetDashBoardForGradeScore(int iestterm_ref_id, int iest_dept_ref_id, string iymd, string isum_type )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SG";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_SELECT_SCORE_PER_GRADE"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 대쉬보드 지표군별 점수
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <returns></returns>
        public DataSet GetDashBoardForKpiGroupScore(int iestterm_ref_id, string iymd, string isum_type )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KG";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_SELECT_SCORE_KPI_GROUP"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 대쉬보드 지표별분석
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <returns></returns>
        public DataSet GetDashBoardForKpiAnalysis(int iestterm_ref_id, int ikpi_ref_id, string iymd_fr, string iymd_to, string isum_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD_FR", SqlDbType.VarChar);
            paramArray[3].Value         = iymd_fr;
            paramArray[4]               = CreateDataParameter("@iYMD_TO", SqlDbType.VarChar);
            paramArray[4].Value         = iymd_to;
            paramArray[5]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[5].Value         = isum_type;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.PROC_SELECT_KPI_ALALYSIS"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        /// <summary>
        ///  DashBoard에 등록된 지표리스트
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataSet GetDashBoardKpiList(int iestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "DK";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.RPOC_SELECT_DASHBOARD_KPI"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 지표의 년간 누계현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <returns></returns>
        public DataSet GetDashBoardKpiYearlyStatusList(int iestterm_ref_id, int ikpi_ref_id, string isymd, int iyear)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "YA";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ikpi_ref_id;
            paramArray[3]       = CreateDataParameter("@iSYMD", SqlDbType.VarChar);
            paramArray[3].Value = isymd;
            paramArray[4]       = CreateDataParameter("@iYEAR", SqlDbType.Int);
            paramArray[4].Value = iyear;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_DASHBOARD", "PKG_BSC_KPI_DASHBOARD.RPOC_SELECT_YEARLY_KPI_ANAYL"), "BSC_KPI_DASHBOARD", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
    }
}