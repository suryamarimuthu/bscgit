using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_EstDept_LoadMap의 요약 설명입니다.
    /// </summary>
    /// 
    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_EstDept_LoadMap Dac 클래스
    /// Class 내용		@ Kpi_Pool Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_EstDept_LoadMap : DbAgentBase
    {
    #region ============================== [Fields] ==============================
     
        private int 	 _iestterm_ref_id;
        private int 	 _iest_dept_ref_id;
        private string 	 _iymd;
        private string 	 _imonthly_plan;
        private string 	 _idetails;
        private string 	 _ietc_contents;
        private Int32    _itxr_user;
        private int 	 _create_user;
        private DateTime _create_date;
        private int 	 _update_user;
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
         
        public string Imonthly_plan
        {
	        get 
	        {
		        return _imonthly_plan;
	        }
	        set
	        {
		        _imonthly_plan = ( value==null ? "" : value );
	        }
        }
         
        public string Idetails
        {
	        get 
	        {
		        return _idetails;
	        }
	        set
	        {
		        _idetails = ( value==null ? "" : value );
	        }
        }
         
        public string Ietc_contents
        {
	        get 
	        {
		        return _ietc_contents;
	        }
	        set
	        {
		        _ietc_contents = ( value==null ? "" : value );
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
     
        public Dac_Bsc_EstDept_LoadMap() { }
        public Dac_Bsc_EstDept_LoadMap(int estterm_ref_id, int est_dept_ref_id, string ymd) 
        {
            DataSet ds = this.GetOneList(estterm_ref_id, est_dept_ref_id, ymd);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr = ds.Tables[0].Rows[0];
		        _iestterm_ref_id    = (dr["ESTTERM_REF_ID"]   == DBNull.Value) ? 0 : (int) dr["ESTTERM_REF_ID"];
		        _iest_dept_ref_id   = (dr["EST_DEPT_REF_ID"]  == DBNull.Value) ? 0 : (int) dr["EST_DEPT_REF_ID"];
		        _iymd               = (dr["YMD"]              == DBNull.Value) ? "" : (string) dr["YMD"];
		        _imonthly_plan      = (dr["MONTHLY_PLAN"]     == DBNull.Value) ? "" : (string) dr["MONTHLY_PLAN"];
		        _idetails           = (dr["DETAILS"]          == DBNull.Value) ? "" : (string) dr["DETAILS"];
		        _ietc_contents      = (dr["ETC_CONTENTS"]     == DBNull.Value) ? "" : (string) dr["ETC_CONTENTS"];
		        _create_user        = (dr["CREATE_USER"]      == DBNull.Value) ? 0 : (int) dr["CREATE_USER"];
		        _create_date        = (dr["CREATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]      == DBNull.Value) ? 0 : (int) dr["UPDATE_USER"];
		        _update_date        = (dr["UPDATE_DATE"]      == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
	        }
        }

        internal protected int InsertData_Dac(int estterm_ref_id, int est_dept_ref_id, string ymd, string monthly_plan, string details, string etc_contents, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);
         
            paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 	    = "A";
            paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 	    = estterm_ref_id;
            paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 	    = est_dept_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar,8);
            paramArray[3].Value 	    = ymd;
            paramArray[4] 		        = CreateDataParameter("@iMONTHLY_PLAN", SqlDbType.VarChar,2500);
            paramArray[4].Value 	    = monthly_plan;
            paramArray[5] 		        = CreateDataParameter("@iDETAILS", SqlDbType.VarChar,2500);
            paramArray[5].Value 	    = details;
            paramArray[6] 		        = CreateDataParameter("@iETC_CONTENTS", SqlDbType.VarChar,2000);
            paramArray[6].Value 	    = etc_contents;
            paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value 	    = itxr_user;
            paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction 	= ParameterDirection.Output ;
            paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_ESTDEPT_LOADMAP", "PKG_BSC_ESTDEPT_LOADMAP.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }    

        internal protected int UpdateData_Dac(int estterm_ref_id, int est_dept_ref_id, string ymd, string monthly_plan, string details, string etc_contents, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);
         
            paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 	    = "U";
            paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 	    = estterm_ref_id;
            paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 	    = est_dept_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar,8);
            paramArray[3].Value 	    = ymd;
            paramArray[4] 		        = CreateDataParameter("@iMONTHLY_PLAN", SqlDbType.VarChar,2500);
            paramArray[4].Value 	    = monthly_plan;
            paramArray[5] 		        = CreateDataParameter("@iDETAILS", SqlDbType.VarChar,2500);
            paramArray[5].Value 	    = details;
            paramArray[6] 		        = CreateDataParameter("@iETC_CONTENTS", SqlDbType.VarChar,2000);
            paramArray[6].Value 	    = etc_contents;
            paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value 	    = itxr_user;
            paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[8].Direction 	= ParameterDirection.Output ;
            paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_ESTDEPT_LOADMAP", "PKG_BSC_ESTDEPT_LOADMAP.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }    

        internal protected int DeleteData_Dac(int estterm_ref_id, int est_dept_ref_id, string ymd, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
         
            paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 	    = "D";
            paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 	    = estterm_ref_id;
            paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 	    = est_dept_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar,8);
            paramArray[3].Value 	    = ymd;
            paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value 	    = itxr_user;
            paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction 	= ParameterDirection.Output ;
            paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_ESTDEPT_LOADMAP", "PKG_BSC_ESTDEPT_LOADMAP.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }   

        public DataSet GetAllList(int estterm_ref_id, int est_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 	    = estterm_ref_id;
            paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 	    = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_ESTDEPT_LOADMAP", "PKG_BSC_ESTDEPT_LOADMAP.PROC_SELECT_ALL"), "BSC_ESTDEPT_LOADMAP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int estterm_ref_id, int est_dept_ref_id, string ymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 	    = estterm_ref_id;
            paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 	    = est_dept_ref_id;
            paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar,8);
            paramArray[3].Value 	    = ymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_ESTDEPT_LOADMAP", "PKG_BSC_ESTDEPT_LOADMAP.PROC_SELECT_ONE"), "BSC_ESTDEPT_LOADMAP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetLoadMapPerEstDept(int estterm_ref_id, int est_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "EA";
            paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 	    = estterm_ref_id;
            paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 	    = est_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_ESTDEPT_LOADMAP", "PKG_BSC_ESTDEPT_LOADMAP.PROC_SELECT_ESTDEPT_LOADMAP"), "BSC_ESTDEPT_LOADMAP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

    }
}