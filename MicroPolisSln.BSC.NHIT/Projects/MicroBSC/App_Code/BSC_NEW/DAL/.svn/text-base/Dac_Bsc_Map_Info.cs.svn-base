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
/// Dac_Bsc_Map_Info에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Map_Info Dac 클래스
/// Class 내용		@ Bsc_Map_Info Dac 처리 
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
    public class Dac_Bsc_Map_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int 	 _iestterm_ref_id;
        private string   _iestterm_name;
        private int  	 _iest_dept_ref_id;
        private string   _iest_dept_name;
        private int  	 _imap_version_id;
        private string   _imap_version_name;
        private string   _idept_vision;
        private string 	 _imap_desc;
        private int 	 _ibscchampion_emp_id;
        private string   _ibscchampion_name;
        private string 	 _iuse_yn;
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

        public string Iest_term_name
        {
            get
            {
                return _iestterm_name;
            }
            set
            {
                _iestterm_name = (value == null ? "" : value);
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
                _iest_dept_name = (value == null ? "" : value);
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

        public string Imap_version_name
        {
            get
            {
                return _imap_version_name;
            }
            set
            {
                _imap_version_name = value;
            }
        }
         
        public string Idept_vision
        {
	        get 
	        {
		        return _idept_vision;
	        }
	        set
	        {
		        _idept_vision = ( value==null ? "" : value );
	        }
        }
         
        public string Imap_desc
        {
	        get 
	        {
		        return _imap_desc;
	        }
	        set
	        {
		        _imap_desc = ( value==null ? "" : value );
	        }
        }
         
        public int Ibscchampion_emp_id
        {
	        get 
	        {
		        return _ibscchampion_emp_id;
	        }
	        set
	        {
		        _ibscchampion_emp_id = value;
	        }
        }

        public string Ibscchampion_name
        {
            get
            {
                return _ibscchampion_name;
            }
            set
            {
                _ibscchampion_name = (value == null ? "" : value);
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
		        _iuse_yn = ( value==null ? "" : value );
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
        public Dac_Bsc_Map_Info() { }
        public Dac_Bsc_Map_Info(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id) 
        {

            DataSet ds = this.GetOneList(iestterm_ref_id, iest_dept_ref_id, imap_version_id);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr = ds.Tables[0].Rows[0];
		        _iestterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _iestterm_name       = (dr["ESTTERM_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_NAME"]);
                _iest_dept_ref_id    = (dr["EST_DEPT_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_name      = (dr["EST_DEPT_NAME"]      == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_NAME"]);
		        _imap_version_id     = (dr["MAP_VERSION_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["MAP_VERSION_ID"]);
                _imap_version_name   = (dr["MAP_VERSION_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["MAP_VERSION_NAME"]);
		        _idept_vision        = (dr["DEPT_VISION"]        == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_VISION"]);
		        _imap_desc           = (dr["MAP_DESC"]           == DBNull.Value) ? "" : Convert.ToString(dr["MAP_DESC"]);
		        _ibscchampion_emp_id = (dr["BSCCHAMPION_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["BSCCHAMPION_EMP_ID"]);
                _ibscchampion_name   = (dr["BSCCHAMPION_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["BSCCHAMPION_NAME"]);
		        _iuse_yn             = (dr["USE_YN"]             == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user         = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date         = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user         = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date         = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
	        }
        }

        public Dac_Bsc_Map_Info(int iestterm_ref_id, int iest_dept_ref_id, string iymd) 
        {

            DataSet ds = this.GetDeptMapPerMonth(iestterm_ref_id, iest_dept_ref_id, iymd);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr = ds.Tables[0].Rows[0];
		        _iestterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _iestterm_name       = (dr["ESTTERM_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_NAME"]);
                _iest_dept_ref_id    = (dr["EST_DEPT_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_name      = (dr["EST_DEPT_NAME"]      == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_NAME"]);
		        _imap_version_id     = (dr["MAP_VERSION_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["MAP_VERSION_ID"]);
                _imap_version_name   = (dr["MAP_VERSION_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["MAP_VERSION_NAME"]);
		        _idept_vision        = (dr["DEPT_VISION"]        == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_VISION"]);
		        _imap_desc           = (dr["MAP_DESC"]           == DBNull.Value) ? "" : Convert.ToString(dr["MAP_DESC"]);
		        _ibscchampion_emp_id = (dr["BSCCHAMPION_EMP_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["BSCCHAMPION_EMP_ID"]);
                _ibscchampion_name   = (dr["BSCCHAMPION_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["BSCCHAMPION_NAME"]);
		        _iuse_yn             = (dr["USE_YN"]             == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user         = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date         = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user         = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date         = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
	        }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iMAP_VERSION_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	    = imap_version_name;
	        paramArray[5] 		        = CreateDataParameter("@iDEPT_VISION", SqlDbType.VarChar);
	        paramArray[5].Value 	    = idept_vision;
	        paramArray[6] 		        = CreateDataParameter("@iMAP_DESC", SqlDbType.VarChar);
	        paramArray[6].Value 	    = imap_desc;
	        paramArray[7] 		        = CreateDataParameter("@iBSCCHAMPION_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = ibscchampion_emp_id;
	        paramArray[8] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[8].Value 	    = iuse_yn;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
            paramArray[12]              = CreateDataParameter("@oMAP_VERSION_ID", SqlDbType.Int);
            paramArray[12].Direction    = ParameterDirection.Output;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            if (this.Transaction_Result == "Y")
            {
                this.Imap_version_id    = int.Parse(GetOutputParameterValueBySP(col, "@oMAP_VERSION_ID").ToString());
            }
            else
            {
                this.Imap_version_id = 0;
            }

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
            paramArray[4]               = CreateDataParameter("@iMAP_VERSION_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = imap_version_name;
	        paramArray[5] 		        = CreateDataParameter("@iDEPT_VISION", SqlDbType.VarChar);
	        paramArray[5].Value 	    = idept_vision;
	        paramArray[6] 		        = CreateDataParameter("@iMAP_DESC", SqlDbType.VarChar);
	        paramArray[6].Value 	    = imap_desc;
	        paramArray[7] 		        = CreateDataParameter("@iBSCCHAMPION_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = ibscchampion_emp_id;
	        paramArray[8] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[8].Value 	    = iuse_yn;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iuse_yn, int itxr_user)
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
	        paramArray[4] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[4].Value 	    = iuse_yn;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iMAP_VERSION_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	    = imap_version_name;
	        paramArray[5] 		        = CreateDataParameter("@iDEPT_VISION", SqlDbType.VarChar);
	        paramArray[5].Value 	    = idept_vision;
	        paramArray[6] 		        = CreateDataParameter("@iMAP_DESC", SqlDbType.VarChar);
	        paramArray[6].Value 	    = imap_desc;
	        paramArray[7] 		        = CreateDataParameter("@iBSCCHAMPION_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = ibscchampion_emp_id;
	        paramArray[8] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[8].Value 	    = iuse_yn;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
            paramArray[12]              = CreateDataParameter("@oMAP_VERSION_ID", SqlDbType.Int);
            paramArray[12].Direction    = ParameterDirection.Output;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            if (this.Transaction_Result == "Y")
            {
                this.Imap_version_id    = int.Parse(GetOutputParameterValueBySP(col, "@oMAP_VERSION_ID").ToString());
            }
            else
            {
                this.Imap_version_id = 0;
            }

            return affectedRow;
        }

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string imap_version_name, string idept_vision, string imap_desc, int ibscchampion_emp_id, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
            paramArray[4]               = CreateDataParameter("@iMAP_VERSION_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = imap_version_name;
	        paramArray[5] 		        = CreateDataParameter("@iDEPT_VISION", SqlDbType.VarChar);
	        paramArray[5].Value 	    = idept_vision;
	        paramArray[6] 		        = CreateDataParameter("@iMAP_DESC", SqlDbType.VarChar);
	        paramArray[6].Value 	    = imap_desc;
	        paramArray[7] 		        = CreateDataParameter("@iBSCCHAMPION_EMP_ID", SqlDbType.Int);
	        paramArray[7].Value 	    = ibscchampion_emp_id;
	        paramArray[8] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[8].Value 	    = iuse_yn;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	    = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iuse_yn, int itxr_user)
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
	        paramArray[4] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[4].Value 	    = iuse_yn;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_MAP_INFO", GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_ALL"), null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
	        paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value         = imap_version_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_ONE"), "BSC_MAP_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMapTermList(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S1";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = imap_version_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_MAP_TERM"), "BSC_MAP_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMapVersionList(int iestterm_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S2";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_MAP_VERSION"), "BSC_MAP_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetDeptMapHistory(int iestterm_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S3";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_MAP_DEPT_VER"), "BSC_MAP_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetDeptMapPerMonth(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_MAP_MONTH"), "BSC_MAP_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMapListByDeptTree(int iestterm_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S5";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_INFO", "PKG_BSC_MAP_INFO.PROC_SELECT_MAP_MONTH_TREE"), "BSC_MAP_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
}