using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;
using MicroBSC.BSC.Dac;

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
    public class Dac_Bsc_Communication_User : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int      _ilist_ref_id ;
        private int      _ito_emp_id   ;
        private string   _iread_yn     ;
        private Int32    _itxr_user    ;
        private int 	 _create_user  ;
        private DateTime _create_date  ;
        private int 	 _update_user  ;
        private DateTime _update_date  ;
        private String   _txr_message  ; // 처리결과메시지
        private String   _txr_result   ;  // 처리결과여부(Y,N)

        #endregion
    
        #region ============================== [Properties] ==============================
        public int Ilist_ref_id
        {
            get 
            {
	            return _ilist_ref_id;
            }
            set
            {
	            _ilist_ref_id = value;
            }
        }

        public int Ito_emp_id
        {
            get 
            {
	            return _ito_emp_id;
            }
            set
            {
	            _ito_emp_id = value;
            }
        }

        public string Iread_yn
        {
            get
            {
                return _iread_yn;
            }
            set
            {
                _iread_yn = value;
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
    
        #region ====================== [ Constructor ] ======================
        public Dac_Bsc_Communication_User() { }
        public Dac_Bsc_Communication_User(int ilist_ref_id, int ito_emp_id) 
        {
            DataSet ds = this.GetOneList(ilist_ref_id, ito_emp_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _ilist_ref_id = (dr["LIST_REF_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LIST_REF_ID"]));
                _ito_emp_id   = (dr["TO_EMP_ID"]   == DBNull.Value ? 0 : Convert.ToInt32(dr["TO_EMP_ID"]));
                _iread_yn     = (dr["READ_YN"]     == DBNull.Value ? "" : Convert.ToString(dr["READ_YN"]));
                _create_user  = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date  = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user  = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date  = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
            else
            { 
                _ilist_ref_id = ilist_ref_id;
                _ito_emp_id   = ito_emp_id;
                _iread_yn     = "X";
            }
        }
        #endregion

        #region ====================== [ Method ] ======================
        internal protected int InsertData_Dac(int ilist_ref_id, int ito_emp_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTO_EMP_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ito_emp_id;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value 	    = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int ilist_ref_id, int ito_emp_id, string iread_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTO_EMP_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ito_emp_id;
	        paramArray[3] 		        = CreateDataParameter("@iREAD_YN", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iread_yn;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int ilist_ref_id, int ito_emp_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTO_EMP_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ito_emp_id;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value 	    = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteDataAll_Dac(int ilist_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "DA";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_DELETE_ALL"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int ilist_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_SELECT_ALL"), "BSC_COMMUNICATION_USER", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int ilist_ref_id, int ito_emp_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTO_EMP_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = ito_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_SELECT_ONE"), "BSC_COMMUNICATION_USER", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public bool GetIsNewListPerUser(int iemp_ref_id)
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RL";
	        paramArray[1] 		        = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_USER", "PKG_BSC_COMMUNICATION_USER.PROC_SELECT_READ_LIST"), "BSC_COMMUNICATION_USER", null, paramArray, CommandType.StoredProcedure);
            
            int intRtn = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            if (intRtn > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}