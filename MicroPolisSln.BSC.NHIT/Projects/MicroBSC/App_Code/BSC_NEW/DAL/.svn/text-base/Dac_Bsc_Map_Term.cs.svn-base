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
/// Dac_Bsc_Map_Term 에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Map_Term Dac 클래스
/// Class 내용		@ Bsc_Map_Term Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.06.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Map_Term : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int 	 _iestterm_ref_id;
        private int 	 _iest_dept_ref_id;
        private string   _iest_dept_name;
        private int 	 _imap_version_id;
        private string 	 _iymd;
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

        private string Iest_dept_name
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
        public Dac_Bsc_Map_Term() { }
        public Dac_Bsc_Map_Term(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, iest_dept_ref_id, iymd);
            DataRow dr;

            if (ds.Tables.Count < 1)
            {
                return;
            }
         
            if(ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id  = (dr["ESTTERM_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iest_dept_ref_id = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_name   = (dr["EST_DEPT_NAME"]   == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_NAME"]);
                _imap_version_id  = (dr["MAP_VERSION_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["MAP_VERSION_ID"]);
                _iymd             = (dr["YMD"]             == DBNull.Value) ? "" : Convert.ToString(dr["YMD"]);
                _create_user      = (dr["CREATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date      = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user      = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date      = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac( int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		    	= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 		= "A";
	        paramArray[1] 		    	= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 		= iestterm_ref_id;
	        paramArray[2] 		    	= CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 		= iest_dept_ref_id;
	        paramArray[3] 		    	= CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 		= imap_version_id;
	        paramArray[4] 		    	= CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 		= iymd;
	        paramArray[5] 		    	= CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 		= itxr_user;			
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac( int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		    	= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 		= "U";
	        paramArray[1] 		    	= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 		= iestterm_ref_id;
	        paramArray[2] 		    	= CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 		= iest_dept_ref_id;
	        paramArray[3] 		    	= CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 		= imap_version_id;
	        paramArray[4] 		    	= CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 		= iymd;
	        paramArray[5] 		    	= CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 		= itxr_user;
	        paramArray[6] 		    	= CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);					
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac( int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 	    	    = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iymd;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteAllData_Dac( int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "DA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int InsertData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iymd;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }        

        internal protected int UpdateData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iymd;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
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
	        paramArray[4] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iymd;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();


            return affectedRow;
        }

        internal protected int DeleteAllData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "DA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iest_dept_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iMAP_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = imap_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
         
            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_SELECT_ALL"), "BSC_MAP_TERM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value 		= "SO";
            paramArray[1]       		= CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value 		= iestterm_ref_id;
            paramArray[2]       		= CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value 		= iest_dept_ref_id;
            paramArray[3]       		= CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value 		= iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_TERM", "PKG_BSC_MAP_TERM.PROC_SELECT_ONE"), "BSC_MAP_TERM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion
    }
}