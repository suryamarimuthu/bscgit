using System;
using System.Web;
using System.Data;
using System.Text;
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
    public class Dac_Bsc_Communication_List : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private int      _ilist_ref_id     ;
        private string   _icategory_code   ;
        private int      _iparent_list_id  ;
        private int      _iestterm_ref_id  ;
        private string   _iymd             ;
        private int      _ikpi_ref_id      ;
        private string   _ititle           ;
        private string   _idetails         ;
        private int      _iread_count      ;
        private string   _iattach_no       ;
        private int      _iowner_emp_id    ;
        private string   _iowner_emp_name  ;
        private string   _iarr_receiver_id ;
        private string   _iis_send_mail    ;
        private string   _iis_open_list    ;
        private Int32    _itxr_user;
        private int 	 _create_user;
        private DateTime _create_date;
        private int 	 _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)

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

        public string Icategory_code
        {
            get
            {
                return _icategory_code;
            }
            set
            {
                _icategory_code = value;
            }
        }

        public int Iparent_list_id
        {
            get 
            {
	            return _iparent_list_id;
            }
            set
            {
	            _iparent_list_id = value;
            }
        }
     
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
         
        public string Ititle
        {
            get 
            {
	            return _ititle;
            }
            set
            {
	            _ititle = ( value==null ? "" : value );
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

        public int Iread_count
        {
            get 
            {
	            return _iread_count;
            }
            set
            {
	            _iread_count = value;
            }
        }
         
        public string Iattach_no
        {
            get 
            {
	            return _iattach_no;
            }
            set
            {
	            _iattach_no = ( value==null ? "" : value );
            }
        }

        public int Iowner_emp_id
        {
            get
            {
                return _iowner_emp_id;
            }
            set
            {
                _iowner_emp_id = value;
            }
        }

        public string Iowner_emp_name
        {
            get
            {
                return _iowner_emp_name;
            }
            set
            { 
                _iowner_emp_name = ( value==null ? "" : value );
            }
        }

        public string Iarr_receiver_id
        {
            get
            {
                return _iarr_receiver_id;
            }
            set
            {
                _iarr_receiver_id = (value == null ? "" : value);
            }
        }

        public string Iis_send_mail
        {
            get
            {
                return _iis_send_mail;
            }
            set
            {
                _iis_send_mail = (value == null ? "" : value);
            }
        }

        public string Iis_open_list
        {
            get
            {
                return _iis_open_list;
            }
            set
            {
                _iis_open_list = (value == null ? "" : value);
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
        public Dac_Bsc_Communication_List() { }
        public Dac_Bsc_Communication_List(int ilist_ref_id) 
        {
            DataSet ds = this.GetOneList(ilist_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _ilist_ref_id            = (dr["LIST_REF_ID"]     == DBNull.Value ? 0  : Convert.ToInt32(dr["LIST_REF_ID"]));
                _icategory_code          = (dr["CATEGORY_CODE"]   == DBNull.Value ? "" : Convert.ToString(dr["CATEGORY_CODE"]));
                _iparent_list_id         = (dr["PARENT_LIST_ID"]  == DBNull.Value ? 0  : Convert.ToInt32(dr["PARENT_LIST_ID"]));
                _iestterm_ref_id         = (dr["ESTTERM_REF_ID"]  == DBNull.Value ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]));
                _iymd                    = (dr["YMD"]             == DBNull.Value ? "" : Convert.ToString(dr["YMD"]));
                _ikpi_ref_id             = (dr["KPI_REF_ID"]      == DBNull.Value ? 0  : Convert.ToInt32(dr["KPI_REF_ID"]));
                _ititle                  = (dr["TITLE"]           == DBNull.Value ? "" : Convert.ToString(dr["TITLE"]));
                _idetails                = (dr["DETAILS"]         == DBNull.Value ? "" : Convert.ToString(dr["DETAILS"]));
                _iread_count             = (dr["READ_COUNT"]      == DBNull.Value ? 0  : Convert.ToInt32(dr["READ_COUNT"]));
                _iattach_no              = (dr["ATTACH_NO"]       == DBNull.Value ? "" : Convert.ToString(dr["ATTACH_NO"]));
                _iowner_emp_id           = (dr["OWNER_EMP_ID"]    == DBNull.Value ? 0  : Convert.ToInt32(dr["OWNER_EMP_ID"]));
                _iowner_emp_name         = (dr["OWNER_NAME"]      == DBNull.Value ? "" : Convert.ToString(dr["OWNER_NAME"]));
                _iarr_receiver_id        = (dr["ARR_RECEIVER_ID"] == DBNull.Value ? "" : Convert.ToString(dr["ARR_RECEIVER_ID"]));
                _iis_send_mail           = (dr["IS_SEND_MAIL"]    == DBNull.Value ? "" : Convert.ToString(dr["IS_SEND_MAIL"]));
                _iis_open_list           = (dr["IS_OPEN_LIST"]    == DBNull.Value ? "" : Convert.ToString(dr["IS_OPEN_LIST"]));
                _create_user             = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion
    
        #region ====================== [ Method ] ======================
        internal protected int InsertData_Dac(string icategory_code, int iparent_list_id, int iestterm_ref_id, string iymd
                                            , int ikpi_ref_id, string ititle, string idetails, int iread_count, string iattach_no
                                            , string iarr_receiver_id, string iis_send_mail, string iis_open_list, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(17);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[1].Value 	    = icategory_code;
	        paramArray[2] 		        = CreateDataParameter("@iPARENT_LIST_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iparent_list_id;
	        paramArray[3] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = iestterm_ref_id;
	        paramArray[4] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iymd;
	        paramArray[5] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[5].Value 	    = ikpi_ref_id ;
	        paramArray[6] 		        = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
	        paramArray[6].Value 	    = ititle;
	        paramArray[7] 		        = CreateDataParameter("@iDETAILS", SqlDbType.Text);
	        paramArray[7].Value 	    = idetails;
	        paramArray[8] 		        = CreateDataParameter("@iREAD_COUNT", SqlDbType.Int);
	        paramArray[8].Value 	    = iread_count;
	        paramArray[9] 		        = CreateDataParameter("@iATTACH_NO", SqlDbType.VarChar);
	        paramArray[9].Value 	    = iattach_no;
	        paramArray[10] 		        = CreateDataParameter("@iARR_RECEIVER_ID", SqlDbType.VarChar);
	        paramArray[10].Value 	    = iarr_receiver_id;
	        paramArray[11] 		        = CreateDataParameter("@iIS_SEND_MAIL", SqlDbType.VarChar);
	        paramArray[11].Value 	    = iis_send_mail;
	        paramArray[12] 		        = CreateDataParameter("@iIS_OPEN_LIST", SqlDbType.VarChar);
	        paramArray[12].Value 	    = iis_open_list;
	        paramArray[13] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[13].Value 	    = itxr_user;
	        paramArray[14] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[14].Direction 	= ParameterDirection.Output ;
	        paramArray[15] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[15].Direction 	= ParameterDirection.Output ;
            paramArray[16]              = CreateDataParameter("@oLIST_REF_ID", SqlDbType.Int);
            paramArray[16].Direction    = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Ilist_ref_id           = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oLIST_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int ilist_ref_id, string icategory_code, int iparent_list_id, int iestterm_ref_id, string iymd
                                            , int ikpi_ref_id, string ititle, string idetails, int iread_count, string iattach_no
                                            , string iarr_receiver_id, string iis_send_mail, string iis_open_list, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(17);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iCATEGORY_CODE", SqlDbType.VarChar);
	        paramArray[2].Value 	    = icategory_code;
	        paramArray[3] 		        = CreateDataParameter("@iPARENT_LIST_ID", SqlDbType.Int);
	        paramArray[3].Value 	    = iparent_list_id;
	        paramArray[4] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = iestterm_ref_id;
	        paramArray[5] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[5].Value 	    = iymd;
	        paramArray[6] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[6].Value 	    = ikpi_ref_id ;
	        paramArray[7] 		        = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
	        paramArray[7].Value 	    = ititle;
	        paramArray[8] 		        = CreateDataParameter("@iDETAILS", SqlDbType.Text);
	        paramArray[8].Value 	    = idetails;
	        paramArray[9] 		        = CreateDataParameter("@iREAD_COUNT", SqlDbType.Int);
	        paramArray[9].Value 	    = iread_count;
	        paramArray[10] 		        = CreateDataParameter("@iATTACH_NO", SqlDbType.VarChar);
	        paramArray[10].Value 	    = iattach_no;
	        paramArray[11] 		        = CreateDataParameter("@iARR_RECEIVER_ID", SqlDbType.VarChar);
	        paramArray[11].Value 	    = iarr_receiver_id;
	        paramArray[12] 		        = CreateDataParameter("@iIS_SEND_MAIL", SqlDbType.VarChar);
	        paramArray[12].Value 	    = iis_send_mail;
	        paramArray[13] 		        = CreateDataParameter("@iIS_OPEN_LIST", SqlDbType.VarChar);
	        paramArray[13].Value 	    = iis_open_list;
	        paramArray[14] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[14].Value 	    = itxr_user;
	        paramArray[15] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[15].Direction 	= ParameterDirection.Output ;
	        paramArray[16] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[16].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int ilist_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int AddClickCount_Dac(int ilist_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "AC";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_ADD_CLICK"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iowner_emp_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iOWNER_EMP_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iowner_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_SELECT_ALL"), "BSC_COMMUNICATION_LIST", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int ilist_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iLIST_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = ilist_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_SELECT_ONE"), "BSC_COMMUNICATION_LIST", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 사용자별 게시물 가져오기
        /// </summary>
        /// <param name="iowner_emp_id">사용자 아이디</param>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="iymd">평가년월</param>
        /// <param name="ikpi_ref_id">지표아이디</param>
        /// <param name="inCludeMyDeptList">관련조직데이터 조회 여부</param>
        /// <returns></returns>
        public DataSet GetAllListPerKpiUser(int iowner_emp_id, int iestterm_ref_id, string iymd, int ikpi_ref_id, bool inCludeMyDeptList)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "MF";
	        paramArray[1] 		        = CreateDataParameter("@iOWNER_EMP_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iowner_emp_id;
	        paramArray[2] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iestterm_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
	        paramArray[4].Value 	    = ikpi_ref_id ;
	        paramArray[5] 		        = CreateDataParameter("@iDEPT_YN", SqlDbType.VarChar);
	        paramArray[5].Value 	    = (inCludeMyDeptList) ? "Y" : "N";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_LIST", "PKG_BSC_COMMUNICATION_LIST.PROC_SELECT_MUST_FEEDBACK"), "BSC_COMMUNICATION_LIST", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

    }
}
