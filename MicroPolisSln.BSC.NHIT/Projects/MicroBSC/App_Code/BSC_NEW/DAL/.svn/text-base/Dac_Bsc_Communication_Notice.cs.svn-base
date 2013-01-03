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
    /// Class 명		@ Dac_Bsc_Communication_Notice Dac 클래스
    /// Class 내용		@ Bsc Communication Notice Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2008.01.01
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------

    public class Dac_Bsc_Communication_Notice : DbAgentBase
    {
        #region ============================== [Fields] ==============================
         
        private Int32    _inotice_ref_id   ;
        private Int32    _iestterm_ref_id  ;
        private string   _iymd             ;
        private string   _ititle           ;
        private string   _idetails         ;
        private Int32    _iread_count      ;
        private string   _iattach_no       ;
        private DateTime _inotice_from     ;
        private DateTime _inotice_to       ;
        private string   _ishow_pop_up     ;
        private Int32    _itxr_user    ;
        private int 	 _create_user  ;
        private DateTime _create_date  ;
        private int 	 _update_user  ;
        private DateTime _update_date  ;
        private String   _txr_message  ; // 처리결과메시지
        private String   _txr_result   ;  // 처리결과여부(Y,N)

        #endregion

        #region ============================== [Properties] ==============================
        public int Inotice_ref_id
        {
            get 
            {
	            return _inotice_ref_id;
            }
            set
            {
	            _inotice_ref_id = value;
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
                return _iymd ;
            }
            set
            {
                _iymd  = value;
            }
        }

        public string Ititle 
        {
            get
            {
                return _ititle ;
            }
            set
            {
                _ititle  = value;
            }
        }

        public string Idetails 
        {
            get
            {
                return _idetails ;
            }
            set
            {
                _idetails  = value;
            }
        }

        public int Iread_count 
        {
            get
            {
                return _iread_count ;
            }
            set
            {
                _iread_count  = value;
            }
        }

        public string Iattach_no 
        {
            get
            {
                return _iattach_no ;
            }
            set
            {
                _iattach_no  = value;
            }
        }

        public DateTime Inotice_from
        {
            get 
            {
	            return _inotice_from;
            }
            set
            {
	            _inotice_from = value;
            }
        }

        public DateTime Inotice_to
        {
            get 
            {
	            return _inotice_to;
            }
            set
            {
	            _inotice_to = value;
            }
        }

        public string Ishow_pop_up 
        {
            get
            {
                return _ishow_pop_up ;
            }
            set
            {
                _ishow_pop_up  = value;
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
        public Dac_Bsc_Communication_Notice() { }
        public Dac_Bsc_Communication_Notice(int inotice_ref_id) 
        {
            DataSet ds = this.GetOneList(inotice_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _inotice_ref_id  = (dr["NOTICE_REF_ID"]  == DBNull.Value ? 0 : Convert.ToInt32(dr["NOTICE_REF_ID"]));
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]));
                _iymd            = (dr["YMD"]            == DBNull.Value ? "" : Convert.ToString(dr["YMD"]));
                _ititle          = (dr["TITLE"]          == DBNull.Value ? "" : Convert.ToString(dr["TITLE"]));
                _idetails        = (dr["DETAILS"]        == DBNull.Value ? "" : Convert.ToString(dr["DETAILS"]));
                _iread_count     = (dr["READ_COUNT"]     == DBNull.Value ? 0  : Convert.ToInt32(dr["READ_COUNT"]));
                _iattach_no      = (dr["ATTACH_NO"]      == DBNull.Value ? "" : Convert.ToString(dr["ATTACH_NO"]));
                _inotice_from    = (dr["NOTICE_FROM"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["NOTICE_FROM"]);
                _inotice_to      = (dr["NOTICE_TO"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["NOTICE_TO"]);
                _ishow_pop_up    = (dr["SHOW_POP_UP"]    == DBNull.Value ? "" : Convert.ToString(dr["SHOW_POP_UP"]));                
                _create_user     = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date     = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user     = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date     = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ====================== [ Method ] ======================
        internal protected int InsertData_Dac(int iestterm_ref_id, string iymd
                                            , string ititle, string idetails, int iread_count, string iattach_no
                                            , DateTime inotice_from, DateTime inotice_to, string ishow_pop_up, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(14);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[2].Value 	    = iymd;
	        paramArray[3] 		        = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
	        paramArray[3].Value 	    = ititle;
	        paramArray[4] 		        = CreateDataParameter("@iDETAILS", SqlDbType.Text);
	        paramArray[4].Value 	    = idetails;
	        paramArray[5] 		        = CreateDataParameter("@iREAD_COUNT", SqlDbType.Int);
	        paramArray[5].Value 	    = iread_count;
	        paramArray[6] 		        = CreateDataParameter("@iATTACH_NO", SqlDbType.VarChar);
	        paramArray[6].Value 	    = iattach_no;
	        paramArray[7] 		        = CreateDataParameter("@iNOTICE_FROM", SqlDbType.DateTime);
	        paramArray[7].Value 	    = inotice_from;
	        paramArray[8] 		        = CreateDataParameter("@iNOTICE_TO", SqlDbType.DateTime);
	        paramArray[8].Value 	    = inotice_to ;
	        paramArray[9] 		        = CreateDataParameter("@iSHOW_POP_UP", SqlDbType.VarChar,1);
	        paramArray[9].Value 	    = ishow_pop_up;
	        paramArray[10] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[10].Value 	    = itxr_user;
	        paramArray[11] 		        = CreateDataParameter("@oNOTICE_REF_ID", SqlDbType.Int);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
	        paramArray[13] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[13].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Inotice_ref_id         = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oNOTICE_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int inotice_ref_id, int iestterm_ref_id, string iymd
                                            , string ititle, string idetails, int iread_count, string iattach_no
                                            , DateTime inotice_from, DateTime inotice_to, string ishow_pop_up, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(14);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iNOTICE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = inotice_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value 	    = iestterm_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iYMD", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iymd;
	        paramArray[4] 		        = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
	        paramArray[4].Value 	    = ititle;
	        paramArray[5] 		        = CreateDataParameter("@iDETAILS", SqlDbType.Text);
	        paramArray[5].Value 	    = idetails;
	        paramArray[6] 		        = CreateDataParameter("@iREAD_COUNT", SqlDbType.Int);
	        paramArray[6].Value 	    = iread_count;
	        paramArray[7] 		        = CreateDataParameter("@iATTACH_NO", SqlDbType.VarChar);
	        paramArray[7].Value 	    = iattach_no;
	        paramArray[8] 		        = CreateDataParameter("@iNOTICE_FROM", SqlDbType.DateTime);
	        paramArray[8].Value 	    = inotice_from;
	        paramArray[9] 		        = CreateDataParameter("@iNOTICE_TO", SqlDbType.DateTime);
	        paramArray[9].Value 	    = inotice_to ;
	        paramArray[10] 		        = CreateDataParameter("@iSHOW_POP_UP", SqlDbType.VarChar,1);
	        paramArray[10].Value 	    = ishow_pop_up;
	        paramArray[11] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[11].Value 	    = itxr_user;
	        paramArray[12] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
	        paramArray[13] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[13].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int inotice_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "D";
	        paramArray[1] 		        = CreateDataParameter("@iNOTICE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = inotice_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int AddClickCount_Dac(int inotice_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "AC";
	        paramArray[1] 		        = CreateDataParameter("@iNOTICE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = inotice_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_ADD_CLICK"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_SELECT_ALL"), "BSC_COMMUNICATION_NOTICE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(string title)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1] = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[1].Value = title;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_SELECT_ALL_QUERY"), "BSC_COMMUNICATION_NOTICE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int inotice_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iNOTICE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = inotice_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_SELECT_ONE"), "BSC_COMMUNICATION_NOTICE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public bool GetCurrentNotice()
        { 
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "NL";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_SELECT_NOTICE_LIST"), "BSC_COMMUNICATION_NOTICE", null, paramArray, CommandType.StoredProcedure);

            DataRow dr = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _inotice_ref_id  = (dr["NOTICE_REF_ID"]  == DBNull.Value ? 0 : Convert.ToInt32(dr["NOTICE_REF_ID"]));
                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]));
                _iymd            = (dr["YMD"]            == DBNull.Value ? "" : Convert.ToString(dr["YMD"]));
                _ititle          = (dr["TITLE"]          == DBNull.Value ? "" : Convert.ToString(dr["TITLE"]));
                _idetails        = (dr["DETAILS"]        == DBNull.Value ? "" : Convert.ToString(dr["DETAILS"]));
                _iread_count     = (dr["READ_COUNT"]     == DBNull.Value ? 0  : Convert.ToInt32(dr["READ_COUNT"]));
                _iattach_no      = (dr["ATTACH_NO"]      == DBNull.Value ? "" : Convert.ToString(dr["ATTACH_NO"]));
                _inotice_from    = (dr["NOTICE_FROM"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["NOTICE_FROM"]);
                _inotice_to      = (dr["NOTICE_TO"]      == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["NOTICE_TO"]);
                _ishow_pop_up    = (dr["SHOW_POP_UP"]    == DBNull.Value ? "" : Convert.ToString(dr["SHOW_POP_UP"]));                
                _create_user     = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date     = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user     = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date     = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            return false;
        }

        public bool IsExistsNotice ()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "NL";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_COMMUNICATION_NOTICE", "PKG_BSC_COMMUNICATION_NOTICE.PROC_SELECT_NOTICE_LIST"), "BSC_COMMUNICATION_NOTICE", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            return false;
        }

        #endregion
    }
}
