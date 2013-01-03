﻿using System;
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
/// Dac_Bsc_Map_Stg 에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Map_Stg Dac 클래스
/// Class 내용		@ Bsc_Map_Stg Dac 처리 
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
    public class Dac_Bsc_Map_Stg : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;
        private int 	 _iest_dept_ref_id;
        private string   _iest_dept_name;
        private int 	 _imap_version_id;
        private int 	 _istg_ref_id;
        private string   _istg_name;
        private int 	 _iview_ref_id;
        private string   _iview_name;
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

        public string Iview_name
        {
            get
            {
                return _iview_name;
            }
            set
            {
                _iview_name = value;
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
        public Dac_Bsc_Map_Stg() { }
        public Dac_Bsc_Map_Stg(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id,  iest_dept_ref_id,  imap_version_id, istg_ref_id);
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
                _iview_ref_id        = (dr["VIEW_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["VIEW_REF_ID"]);
                _iview_name          = (dr["VIEW_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["VIEW_NAME"]);
                _isort_order         = (dr["SORT_ORDER"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _create_user         = (dr["CREATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date         = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user         = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date         = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
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
	        paramArray[5] 		        = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iview_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[6].Value 	    = isort_order;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
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
	        paramArray[5] 		        = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iview_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[6].Value 	    = isort_order;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
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
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
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
	        paramArray[5] 		        = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iview_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[6].Value 	    = isort_order;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
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
	        paramArray[5] 		        = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = iview_ref_id;
	        paramArray[6] 		        = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[6].Value 	    = isort_order;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
	        paramArray[9] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[9].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int itxr_user)
        {
	       
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
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
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_SELECT_ALL"), "BSC_MAP_STG", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_SELECT_ONE"), "BSC_MAP_STG", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetStrategyPerView(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int iview_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S1";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;
            paramArray[4]               = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iview_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_SELECT_VIEW_STG"), "BSC_MAP_STG", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllStrategyExceptDept(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, string istg_name)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S2";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;
            paramArray[4]               = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = istg_ref_id;
            paramArray[5]               = CreateDataParameter("@iSTG_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = istg_name;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_SELECT_TARGET_STG"), "BSC_MAP_STG", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptHaveStrategy(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S3";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_STG", "PKG_BSC_MAP_STG.PROC_SELECT_ESTDEPT_HAVE_STG"), "BSC_MAP_STG", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion

    }
}