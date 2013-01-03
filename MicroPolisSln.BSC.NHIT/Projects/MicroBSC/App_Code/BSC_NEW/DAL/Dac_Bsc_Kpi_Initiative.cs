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
/// Dac_Bsc_Map_Kpi 에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Map_Kpi Dac 클래스
/// Class 내용		@ Bsc_Map_Kpi Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.06.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Initiative : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int      _iestterm_ref_id ;
        private int      _ikpi_ref_id     ;
        private string   _iymd            ;
        private string   _iinitiative_plan;
        private string   _iinitiative_do  ;
        private string   _iinitiative_desc;
        private string   _ido_file;
        private int  	 _itxr_user;
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
                _iymd = value;
            }
        }
         
        public string Iinitiative_plan
        {
	        get 
	        {
		        return _iinitiative_plan;
	        }
	        set
	        {
		        _iinitiative_plan = value;
	        }
        }
         
        public string Iinitiative_do
        {
	        get 
	        {
		        return _iinitiative_do;
	        }
	        set
	        {
		        _iinitiative_do = value;
	        }
        }

        public string Iinitiative_desc
        {
            get
            {
                return _iinitiative_desc;
            }
            set
            {
                _iinitiative_desc = value;  
            }
        }

        public string Ido_file
        {
            get 
            {
                return _ido_file;
            }
            set
            {
                _ido_file = value;
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
        public Dac_Bsc_Kpi_Initiative() { }
        public Dac_Bsc_Kpi_Initiative(int iestterm_ref_id, int ikpi_ref_id, string iymd) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_ref_id, iymd);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id     = (dr["ESTTERM_REF_ID"]   == DBNull.Value) ? 0 :  Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id         = (dr["KPI_REF_ID"]       == DBNull.Value) ? 0 :  Convert.ToInt32(dr["KPI_REF_ID"]);
                _iymd                = (dr["YMD"]              == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _iinitiative_plan    = (dr["INITIATIVE_PLAN"]  == DBNull.Value) ? "" :  Convert.ToString(dr["INITIATIVE_PLAN"]);
                _iinitiative_do      = (dr["INITIATIVE_DO"]    == DBNull.Value) ? "" :  Convert.ToString(dr["INITIATIVE_DO"]);
                _iinitiative_desc    = (dr["INITIATIVE_DESC"]  == DBNull.Value) ? "" : Convert.ToString(dr["INITIATIVE_DESC"]);
                _ido_file            = (dr["DO_FILE"]          == DBNull.Value) ? "" : Convert.ToString(dr["DO_FILE"]);
                _create_user         = (dr["CREATE_USER"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date         = (dr["CREATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user         = (dr["UPDATE_USER"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date         = (dr["UPDATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_plan, string iinitiative_do, string iinitiative_desc, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iINITIATIVE_PLAN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iinitiative_plan;
	        paramArray[5] 		        = CreateDataParameter("@iINITIATIVE_DO", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iinitiative_do;
            paramArray[6]               = CreateDataParameter("@iINITIATIVE_DESC", SqlDbType.VarChar);
            paramArray[6].Value         = iinitiative_desc;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_plan, string iinitiative_do, string iinitiative_desc, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iINITIATIVE_PLAN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iinitiative_plan;
	        paramArray[5] 		        = CreateDataParameter("@iINITIATIVE_DO", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iinitiative_do;
            paramArray[6]               = CreateDataParameter("@iINITIATIVE_DESC", SqlDbType.VarChar);
            paramArray[6].Value         = iinitiative_desc;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        /// <summary>
        /// 이니셔티브 실적 등록 및 파일첨부
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iinitiative_do"></param>
        /// <param name="ido_file"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int InsertInitiativeDo_Dac(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_do, string ido_file, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "AO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iINITIATIVE_DO", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iinitiative_do;
	        paramArray[5] 		        = CreateDataParameter("@iDO_FILE", SqlDbType.VarChar,25);
	        paramArray[5].Value 	    = ido_file;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_INSERT_DO"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }


        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_SELECT_ALL"), "BSC_KPI_INITIATIVE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_SELECT_ONE"), "BSC_KPI_INITIATIVE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiInitaitive(int iestterm_ref_id, int ikpi_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "KI";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_SELECT_KPI_INITIATIVE"), "BSC_KPI_INITIATIVE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiInitaitivePerMonth(int iestterm_ref_id, int ikpi_ref_id, string iymd)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "MI";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ikpi_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_INITIATIVE", "PKG_BSC_KPI_INITIATIVE.PROC_SELECT_MONTHLY_INITIATIVE"), "BSC_KPI_INITIATIVE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

        #region ========================== 멀티 DB 작업 ============================

        public int InsertData_DB(IDbConnection idc
                                                , IDbTransaction idt
                                                , object estterm_ref_id
                                                , object kpi_ref_id
                                                , object ymd
                                                , object initiative_plan
                                                , object initiative_do
                                                , object initiative_desc
                                                , object create_user)
        {
            string query = @"
          
INSERT INTO BSC_KPI_INITIATIVE
(ESTTERM_REF_ID,    KPI_REF_ID,     YMD,            INITIATIVE_PLAN,    INITIATIVE_DO,  INITIATIVE_DESC,    CREATE_USER,    CREATE_DATE)
VALUES
(@ESTTERM_REF_ID,   @KPI_REF_ID,    @YMD,           @INITIATIVE_PLAN,   @INITIATIVE_DO, @INITIATIVE_DESC,   @CREATE_USER,   GETDATE())
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@INITIATIVE_PLAN", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@INITIATIVE_DO", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@INITIATIVE_DESC", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;
            paramArray[3].Value = initiative_plan;
            paramArray[4].Value = initiative_do;
            paramArray[5].Value = initiative_desc;
            paramArray[6].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int UpdateData_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object ymd
                                , object initiative_plan
                                , object initiative_do
                                , object initiative_desc
                                , object create_user)
        {
            string query = @"
          
UPDATE BSC_KPI_INITIATIVE
    SET INITIATIVE_PLAN     = @INITIATIVE_PLAN               
        , INITIATIVE_DO     = @INITIATIVE_DO                 
        , INITIATIVE_DESC   = @INITIATIVE_DESC               
        , UPDATE_USER       = @CREATE_USER
        , UPDATE_DATE       = GETDATE()                   
WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID                
    AND KPI_REF_ID    = @KPI_REF_ID                    
    AND YMD           = @YMD

";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@INITIATIVE_PLAN", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@INITIATIVE_DO", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@INITIATIVE_DESC", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;
            paramArray[2].Value = ymd;
            paramArray[3].Value = initiative_plan;
            paramArray[4].Value = initiative_do;
            paramArray[5].Value = initiative_desc;
            paramArray[6].Value = create_user;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        internal protected int DeleteData_DB(IDbConnection idc
                                            , IDbTransaction idt
                                            , object estterm_ref_id
                                            , object kpi_ref_id)
        {
            string query = @"
DELETE FROM BSC_KPI_INITIATIVE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		        = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[0].Value 	    = estterm_ref_id;
	        paramArray[1] 		        = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = kpi_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);


            return affectedRow;
        }

        #endregion

    }

}