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
    public class Dac_Bsc_Map_Kpi : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;
        private int 	 _iest_dept_ref_id;
        private string   _iest_dept_name;
        private int 	 _imap_version_id;
        private int 	 _istg_ref_id;
        private string   _istg_name;
        private int 	 _ikpi_ref_id;
        private string   _ikpi_name;
        private double   _iweight;
        private int 	 _isort_order;
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
         
        public int Iest_dept_ref_id
        {
	        get 
	        {
		        return _iest_dept_ref_id;
	        }
	        set
	        {
		        _iest_dept_ref_id = value;
	        }
        }

        public string Iest_dept_name
        {
            get
            {
                return _iest_dept_name;
            }
            set
            {
                _iest_dept_name = value;
            }
        }
         
        public int Imap_version_id
        {
	        get 
	        {
		        return _imap_version_id;
	        }
	        set
	        {
		        _imap_version_id = value;
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

        public string Istg_name
        {
            get
            {
                return _istg_name;
            }
            set
            {
                _istg_name = value;  
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

        public string Ikpi_name
        {
            get
            {
                return _ikpi_name;
            }
            set
            {
                _ikpi_name = value;
            }
        }

        public double Iweight
        {
            get
            {
                return _iweight;
            }
            set
            {
                _iweight = value;
            }
        }
         
        public int Isort_order
        {
	        get 
	        {
		        return _isort_order;
	        }
	        set
	        {
		        _isort_order = value;
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
        public Dac_Bsc_Map_Kpi() { }
        public Dac_Bsc_Map_Kpi(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id,  iest_dept_ref_id,  imap_version_id, istg_ref_id, ikpi_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id     = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iest_dept_ref_id    = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_name      = (dr["EST_DEPT_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_NAME"]);
                _imap_version_id     = (dr["MAP_VERSION_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["MAP_VERSION_ID"]);
                _istg_ref_id         = (dr["STG_REF_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
                _istg_name           = (dr["STG_NAME"]        == DBNull.Value) ? "" : Convert.ToString(dr["STG_NAME"]);
                _ikpi_ref_id         = (dr["KPI_REF_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _ikpi_name           = (dr["KPI_NAME"]        == DBNull.Value) ? "" : Convert.ToString(dr["KPI_NAME"]);
                _iweight             = (dr["WEIGHT"]          == DBNull.Value) ? 0 : Convert.ToDouble(dr["WEIGHT"]);
                _isort_order         = (dr["SORT_ORDER"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _create_user         = (dr["CREATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date         = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user         = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date         = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
            paramArray[6]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[6].Value         = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = isort_order;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }



        internal protected int UpdateData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
            paramArray[6]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[6].Value         = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = isort_order;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
            paramArray[5]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = ikpi_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteKpiPerStgData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "DA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn
                                            , IDbTransaction trx
                                            , int iestterm_ref_id
                                            , int iest_dept_ref_id
                                            , int imap_version_id
                                            , int istg_ref_id
                                            , int ikpi_ref_id
                                            , double iweight
                                            , int isort_order
                                            , string imap_kpi_type
                                            , int itxr_user)
        {
            string strQuery = @"
IF EXISTS (SELECT * FROM BSC_MAP_KPI
                            WHERE ESTTERM_REF_ID  = @iESTTERM_REF_ID
                              AND EST_DEPT_REF_ID = @iEST_DEPT_REF_ID
                              AND MAP_VERSION_ID  = @iMAP_VERSION_ID
                              AND STG_REF_ID      = @iSTG_REF_ID
                              AND KPI_REF_ID      = @iKPI_REF_ID)
BEGIN
     UPDATE BSC_MAP_KPI
        SET WEIGHT          = @iWEIGHT
           ,SORT_ORDER      = @iSORT_ORDER 
           ,MAP_KPI_TYPE    = @iMAP_KPI_TYPE
           ,UPDATE_DATE     = GETDATE()
           ,UPDATE_USER     = @iTXR_USER
     WHERE ESTTERM_REF_ID   = @iESTTERM_REF_ID
       AND EST_DEPT_REF_ID  = @iEST_DEPT_REF_ID
       AND MAP_VERSION_ID   = @iMAP_VERSION_ID
       AND STG_REF_ID       = @iSTG_REF_ID
       AND KPI_REF_ID       = @iKPI_REF_ID
END
ELSE
BEGIN
    SELECT @iSORT_ORDER = ISNULL(MAX(SORT_ORDER),0)+1
      FROM BSC_MAP_KPI
     WHERE ESTTERM_REF_ID   = @iESTTERM_REF_ID
       AND EST_DEPT_REF_ID  = @iEST_DEPT_REF_ID
       AND MAP_VERSION_ID   = @iMAP_VERSION_ID
       AND STG_REF_ID       = @iSTG_REF_ID
       --AND KPI_REF_ID       = @iKPI_REF_ID

    INSERT INTO BSC_MAP_KPI
    (
      ESTTERM_REF_ID 
     ,EST_DEPT_REF_ID
     ,MAP_VERSION_ID
     ,STG_REF_ID 
     ,KPI_REF_ID
     ,WEIGHT
     ,SORT_ORDER 
     ,CREATE_DATE   
     ,CREATE_USER   
     ,UPDATE_DATE   
     ,UPDATE_USER   
    )
    VALUES
    (
      @iESTTERM_REF_ID 
     ,@iEST_DEPT_REF_ID
     ,@iMAP_VERSION_ID
     ,@iSTG_REF_ID 
     ,@iKPI_REF_ID
     ,@iWEIGHT
     ,@iSORT_ORDER 
     ,GETDATE()   
     ,@iTXR_USER   
     ,GETDATE()
     ,@iTXR_USER   
    )
END

IF (@@ERROR <> 0 OR @@ROWCOUNT < 1)
  BEGIN
       SET @oRTN_MSG = '처리시 오류가 발생되었습니다. 다시 시도해주십시오.'
       SET @oRTN_COMPLETE_YN = 'N'
       RETURN
  END
ELSE
  BEGIN
       SET @oRTN_MSG         = '정상적으로 처리되었습니다.'
       SET @oRTN_COMPLETE_YN = 'Y'
  END
";
	        IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@iMAP_KPI_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = imap_kpi_type;
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
            paramArray[6]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[6].Value         = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = isort_order;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);
            
            //this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            //this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_DB(IDbConnection conn
                                            , IDbTransaction trx
                                            , int iestterm_ref_id
                                            , int iest_dept_ref_id
                                            , int imap_version_id
                                            , int istg_ref_id
                                            , int ikpi_ref_id
                                            , double iweight
                                            , int isort_order
                                            , string imap_kpi_type
                                            , int itxr_user)
        {
            string strQuery = @"
    INSERT INTO BSC_MAP_KPI
    (
      ESTTERM_REF_ID 
     ,EST_DEPT_REF_ID
     ,MAP_VERSION_ID
     ,STG_REF_ID 
     ,KPI_REF_ID
     ,WEIGHT
     ,SORT_ORDER 
     ,CREATE_DATE   
     ,CREATE_USER   
     ,UPDATE_DATE   
     ,UPDATE_USER   
    )
    VALUES
    (
      @iESTTERM_REF_ID 
     ,@iEST_DEPT_REF_ID
     ,@iMAP_VERSION_ID
     ,@iSTG_REF_ID 
     ,@iKPI_REF_ID
     ,@iWEIGHT
     ,@iSORT_ORDER 
     ,GETDATE()   
     ,@iTXR_USER   
     ,GETDATE()
     ,@iTXR_USER   
    )
";
	        IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
            paramArray[6]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[6].Value         = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = isort_order;
         
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);
            
            //this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            //this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }



        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, double iweight, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id;
            paramArray[6]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[6].Value         = iweight;
	        paramArray[7] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	    = isort_order;
	        paramArray[8] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[8].Value 	    = itxr_user;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteKpiPerStgData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int itxr_user)
        {	        
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "DA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id, int itxr_user)
        {	        
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = istg_ref_id;
            paramArray[5]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = ikpi_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;
            paramArray[4]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = istg_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_ALL"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value         = istg_ref_id;
            paramArray[5]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = ikpi_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_ONE"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetOneList_DB(int iestterm_ref_id
                                   , int iest_dept_ref_id
                                   , int imap_version_id
                                   , int istg_ref_id
                                   , int ikpi_ref_id)
        {
            string query = @"

SELECT ESTTERM_REF_ID
      ,EST_DEPT_REF_ID
      ,MAP_VERSION_ID
      ,STG_REF_ID
      ,KPI_REF_ID
      ,WEIGHT
      ,SORT_ORDER
      ,MAP_KPI_TYPE
      ,CREATE_DATE
      ,CREATE_USER
      ,UPDATE_DATE
      ,UPDATE_USER
 FROM BSC_MAP_KPI
WHERE (ESTTERM_REF_ID   = @iESTTERM_REF_ID          OR   @iESTTERM_REF_ID    =  0)
  AND (EST_DEPT_REF_ID  = @iEST_DEPT_REF_ID         OR   @iEST_DEPT_REF_ID    =  0)
  AND (MAP_VERSION_ID   = @iMAP_VERSION_ID          OR   @iMAP_VERSION_ID    =  0)
  AND (STG_REF_ID       = @iSTG_REF_ID              OR   @iSTG_REF_ID    =  0)
  AND (KPI_REF_ID       = @iKPI_REF_ID              OR   @iKPI_REF_ID    =  0)

";


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = ikpi_ref_id;
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[4].Value         = istg_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "BSC_MAP_KPI", null,  paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiListPerStg(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id)
        {
            string strQuery = @"
SELECT MK.ESTTERM_REF_ID                                   
                      ,MK.EST_DEPT_REF_ID                                  
                      ,ED.DEPT_NAME AS EST_DEPT_NAME                       
                      ,MK.MAP_VERSION_ID                                   
                      ,MK.STG_REF_ID                                       
                      ,SI.STG_NAME                                         
                      ,MK.KPI_REF_ID                                       
                      ,KP.KPI_NAME                                         
                      ,KI.KPI_CODE                                         
                      ,MK.WEIGHT                                           
                      ,ISNULL(VEE.EMP_NAME,'') as CHAMPION_EMP_NAME        
                      ,VEE.COM_DEPT_NAME       as OP_DEPT_NAME             
                      ,MK.SORT_ORDER   
                      ,ISNULL(MK.MAP_KPI_TYPE, '') AS MAP_KPI_TYPE
                      ,MK.CREATE_DATE                                      
                      ,MK.CREATE_USER                                      
                      ,MK.UPDATE_DATE                                      
                      ,MK.UPDATE_USER                                      
                  FROM BSC_MAP_KPI MK                                      
                       LEFT JOIN EST_DEPT_INFO ED                          
                         ON MK.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID        
                        AND MK.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID         
                       LEFT JOIN BSC_STG_INFO SI                           
                         ON MK.STG_REF_ID     = SI.STG_REF_ID                  
                        AND MK.ESTTERM_REF_ID = SI.ESTTERM_REF_ID         
                       LEFT JOIN BSC_KPI_INFO KI                           
                         ON MK.ESTTERM_REF_ID = KI.ESTTERM_REF_ID          
                        AND MK.KPI_REF_ID     = KI.KPI_REF_ID              
                       LEFT JOIN BSC_KPI_POOL KP                           
                         ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID        
                       LEFT JOIN viw_EMP_COMDEPT VEE                       
                              ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID       
                 WHERE MK.ESTTERM_REF_ID  = @iESTTERM_REF_ID               
                   AND MK.EST_DEPT_REF_ID = @iEST_DEPT_REF_ID              
                   AND MK.MAP_VERSION_ID  = @iMAP_VERSION_ID               
                   AND MK.STG_REF_ID      = @iSTG_REF_ID      
                   AND KI.USE_YN = 'Y'             
                 ORDER BY MK.SORT_ORDER
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iest_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value         = imap_version_id;
	        paramArray[3] 		        = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
	        paramArray[3].Value         = istg_ref_id;


            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_STG_KPI"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_MAP_KPI", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllKpiExceptDept(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int ikpi_ref_id, string ikpi_name, 
                                           string ichampion_name, string idept_name)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]       		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 		= "S2";
            paramArray[1]       		= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 		= iestterm_ref_id;
            paramArray[2]       		= CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 		= iest_dept_ref_id;
            paramArray[3]       		= CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value 		= imap_version_id;
            paramArray[4]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = ikpi_ref_id;
            paramArray[5]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ikpi_name;
            paramArray[6]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ichampion_name;
            paramArray[7]               = CreateDataParameter("@iDEPT_NAME", SqlDbType.VarChar);
            paramArray[7].Value         = idept_name;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_KPI_MAP_LIST"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetWeightPerKpi(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S3";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.Int);
            paramArray[3].Value         = iymd;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_KPI_WEIGHT"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetWeightPerStg(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S4";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_STG_WEIGHT"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetWeightPerView(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S5";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_VIEW_WEIGHT"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetWeightPerDept(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "DK";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_DEPT_WEIGHT"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListPerEstDept(int iestterm_ref_id, int iest_dept_ref_id, string iymd, string iresult_input_type
                                          , string ikpi_code, string ikpi_name, string ichampion_name, string ikpi_group_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S6";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = iresult_input_type;
            paramArray[5]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[5].Value         = ikpi_code;
            paramArray[6]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[6].Value         = ikpi_name;
            paramArray[7]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[7].Value         = ichampion_name;
            paramArray[8]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value         = ikpi_group_ref_id;

            


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_ESTDEPT_STATUS"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetKpiListPerEstDept2(int iestterm_ref_id, int iest_dept_ref_id, string iymd, string iresult_input_type
                                          , string ikpi_code, string ikpi_name, string ichampion_name, string ikpi_group_ref_id, string ikpi_use_yn)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S6";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value = iymd;
            paramArray[4] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = iresult_input_type;
            paramArray[5] = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[5].Value = ikpi_code;
            paramArray[6] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[6].Value = ikpi_name;
            paramArray[7] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[7].Value = ichampion_name;
            paramArray[8] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value = ikpi_group_ref_id;
            paramArray[9] = CreateDataParameter("@iKPI_USE_YN", SqlDbType.VarChar);
            paramArray[9].Value = ikpi_use_yn;



            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_ESTDEPT_STATUS2"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetKpiStatusPerStrategy(int iestterm_ref_id, int iest_dept_ref_id, string iymd, int istg_ref_id, string isum_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S7";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = istg_ref_id;
            paramArray[5]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[5].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_STGKPI_STATUS"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetBadKpiListPreviousMonth(int iestterm_ref_id, int iest_dept_ref_id, string iymd, string isum_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S8";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_PREV_STATUS"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiAnalysisPerEstDept(int iestterm_ref_id, int iest_dept_ref_id, string iymd, int ithreshold_ref_id, string isum_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S9";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = ithreshold_ref_id;
            paramArray[5]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[5].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_KPI_ANALY"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiForMoonchart(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SM";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_MOONCHART"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetKpiStgResultAnalysis(int iestterm_ref_id, int iest_dept_ref_id, string iymd,  string isum_type,  int istg_ref_id )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "KS";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value = iymd;
            paramArray[4] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = isum_type;
            paramArray[5] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[5].Value = istg_ref_id;
          

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_KPI", "PKG_BSC_MAP_KPI.PROC_SELECT_KPI_ANALY_STG"), "BSC_MAP_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

    }
}