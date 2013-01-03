using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;


namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Qlt_Info에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Kpi_Qlt_Info Dac 클래스
    /// Class 내용		@ Bsc_Kpi_Qlt_Info Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Validation_Group : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _igroup_ref_id       ;
        private string   _igroup_name         ;
        private string   _idescriptions       ;
        private string   _iuse_yn             ;
        private Int32    _itxr_user           ;
        private Int32    _create_user         ;
        private DateTime _create_date         ;
        private Int32    _update_user         ;
        private DateTime _update_date         ;
        private String   _txr_message         ; // 처리결과메시지
        private String   _txr_result          ; // 처리결과여부(Y,N)
        #endregion

        #region ------------------------ [ Property ] ------------------------

        public int Igroup_ref_id
        {
            get
            {
                return _igroup_ref_id;
            }
            set
            {
                _igroup_ref_id = value;
            }
        }

        public string Igroup_name
        {
            get
            {
                return _igroup_name;
            }
            set
            {
                _igroup_name = value;
            }
        }

        public string Idescriptions
        {
            get
            {
                return _idescriptions;
            }
            set
            {
                _idescriptions = value;
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
                _iuse_yn = value;
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

        #region ------------------------ [ Constructor ] ------------------------
        public Dac_Bsc_Validation_Group() { }
        public Dac_Bsc_Validation_Group(int igroup_ref_id) 
        {
            DataSet ds = this.GetOneList(igroup_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

                _igroup_ref_id        = (dr["GROUP_REF_ID"]    == DBNull.Value) ? 0   : Convert.ToInt32 (dr["GROUP_REF_ID"]);
                _igroup_name          = (dr["GROUP_NAME"]      == DBNull.Value) ? ""  : Convert.ToString (dr["GROUP_NAME"]);
                _idescriptions        = (dr["DESCRIPTIONS"]    == DBNull.Value) ? ""  : Convert.ToString (dr["DESCRIPTIONS"]);
                _iuse_yn              = (dr["USE_YN"]          == DBNull.Value) ? ""   : Convert.ToString (dr["USE_YN"]);
                _create_user          = (dr["CREATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date          = (dr["CREATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user          = (dr["UPDATE_USER"]     == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date          = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion


        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(string igroup_name, string idescriptions, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iGROUP_NAME", SqlDbType.VarChar);
	        paramArray[1].Value 	    = igroup_name;
	        paramArray[2] 		        = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.VarChar);
	        paramArray[2].Value 	    = idescriptions;
	        paramArray[3] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[3].Value 	    = iuse_yn;
	        paramArray[4] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[4].Value 	    = itxr_user;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[5].Direction 	= ParameterDirection.Output ;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
            paramArray[7]               = CreateDataParameter("@oGROUP_REF_ID", SqlDbType.Int);
            paramArray[7].Direction     = ParameterDirection.Output;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP", "PKG_BSC_VALIDATION_GROUP.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Igroup_ref_id          = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oGROUP_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int igroup_ref_id, string igroup_name, string idescriptions, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = igroup_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iGROUP_NAME", SqlDbType.VarChar);
	        paramArray[2].Value 	    = igroup_name;
	        paramArray[3] 		        = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.VarChar);
	        paramArray[3].Value 	    = idescriptions;
	        paramArray[4] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = iuse_yn;
	        paramArray[5] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[5].Value 	    = itxr_user;
	        paramArray[6] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[6].Direction 	= ParameterDirection.Output ;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP", "PKG_BSC_VALIDATION_GROUP.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int igroup_ref_id, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = igroup_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[2].Value 	    = itxr_user;
	        paramArray[3] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[3].Direction 	= ParameterDirection.Output ;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP", "PKG_BSC_VALIDATION_GROUP.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP", "PKG_BSC_VALIDATION_GROUP.PROC_SELECT_ALL"), "BSC_VALIDATION_GROUP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int igroup_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iGROUP_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = igroup_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_VALIDATION_GROUP", "PKG_BSC_VALIDATION_GROUP.PROC_SELECT_ONE"), "BSC_VALIDATION_GROUP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
}
