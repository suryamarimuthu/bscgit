using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class TermInfos : DbAgentBase
    {
        #region ------------------------ 필드 ------------------------

        private int _estterm_ref_id;
        private string _estterm_name;
        private DateTime _est_compdate;
        private DateTime _est_startdate;
        private int _monthly_close_day;
        private int _pre_close_day;
        private int _kpi_qlt_close_day;
        private int _yearly_close_yn;
        private string _score_valuation_type;
        private string _est_desc;
        private int _est_status;
        private int _close_rate_complete_yn;
        private string _external_score_use_yn;
        private string _external_score_type;
        private DateTime _create_date;
        private int _create_user;
        private DateTime _update_date;
        private int _update_user;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Estterm_ref_id
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                _estterm_ref_id = value;
            }
        }

        public string Estterm_name
        {
            get
            {
                return _estterm_name;
            }
            set
            {
                _estterm_name = (value == null ? "" : value);
            }
        }

        public DateTime Est_compdate
        {
            get
            {
                return _est_compdate;
            }
            set
            {
                _est_compdate = value;
            }
        }

        public DateTime Est_startdate
        {
            get
            {
                return _est_startdate;
            }
            set
            {
                _est_startdate = value;
            }
        }

        public int Monthly_close_day
        {
            get
            {
                return _monthly_close_day;
            }
            set
            {
                _monthly_close_day = value;
            }
        }

        public int Pre_close_day
        {
            get
            {
                return _pre_close_day;
            }
            set
            {
                _pre_close_day = value;
            }
        }

        public int Kpi_Qlt_Close_Day
        {
            get
            {
                return _kpi_qlt_close_day;
            }
            set
            {
                _kpi_qlt_close_day = value;
            }
        }

        public int Yearly_close_yn
        {
            get
            {                
                return _yearly_close_yn;
            }
            set
            {
                _yearly_close_yn = value;
            }
        }

        public string Score_valuation_type
        {
            get
            {
                return _score_valuation_type;
            }
            set
            {
                _score_valuation_type = (value == null ? "" : value);
            }
        }

        public string Est_desc
        {
            get
            {
                return _est_desc;
            }
            set
            {
                _est_desc = (value == null ? "" : value);
            }
        }

        public int Est_status
        {
            get
            {
                return _est_status;
            }
            set
            {
                _est_status = value;
            }
        }

        public int Close_rate_complete_yn
        {
            get
            {
                return _close_rate_complete_yn;
            }
            set
            {
                _close_rate_complete_yn = value;
            }
        }

        public string External_score_use_yn
        {
            get
            {
                return _external_score_use_yn;
            }
            set
            {
                _external_score_use_yn = (value == null ? "N" : value);
            }
        }

        public string External_score_type
        {
            get
            {
                return _external_score_type;
            }
            set
            {
                _external_score_type = (value == null ? "K" : value);
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

        #endregion

        public TermInfos()
        {

        }

        public TermInfos(int estterm_ref_id)
        {
            DataSet ds = GetOneList(estterm_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                      = ds.Tables[0].Rows[0];
                _estterm_ref_id         = Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_name           = (string)dr["ESTTERM_NAME"];
                _est_compdate           = (dr["EST_COMPDATE"]           == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["EST_COMPDATE"];
                _est_startdate          = (dr["EST_STARTDATE"]          == DBNull.Value) ? Convert.ToDateTime("2001-01-01") : (DateTime)dr["EST_STARTDATE"];
                _monthly_close_day      = (dr["MONTHLY_CLOSE_DAY"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["MONTHLY_CLOSE_DAY"]);
                _pre_close_day          = (dr["PRE_CLOSE_DAY"]          == DBNull.Value) ? 0 : Convert.ToInt32(dr["PRE_CLOSE_DAY"]);
                _kpi_qlt_close_day      = (dr["KPI_QLT_CLOSE_DAY"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_QLT_CLOSE_DAY"]);
                _yearly_close_yn        = (dr["YEARLY_CLOSE_YN"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["YEARLY_CLOSE_YN"]);
                _score_valuation_type   = (dr["SCORE_VALUATION_TYPE"]   == DBNull.Value) ? "" : (string)dr["SCORE_VALUATION_TYPE"];
                _est_desc               = (dr["EST_DESC"]               == DBNull.Value) ? "" : (string)dr["EST_DESC"];
                _est_status             = (dr["EST_STATUS"]             == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_STATUS"]);
                _close_rate_complete_yn = (dr["CLOSE_RATE_COMPLETE_YN"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CLOSE_RATE_COMPLETE_YN"]);
                _external_score_use_yn  = (dr["EXTERNAL_SCORE_USE_YN"]  == DBNull.Value) ? "N" : (string)dr["EXTERNAL_SCORE_USE_YN"];
                _external_score_type    = (dr["EXTERNAL_SCORE_TYPE"]    == DBNull.Value) ? "K" : (string)dr["EXTERNAL_SCORE_TYPE"];
                _create_date            = (dr["CREATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
                _create_user            = (dr["CREATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _update_date            = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user            = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public DataSet GetAllTermInfo()
        {
            string query = @"SELECT	ESTTERM_REF_ID
                                    , ESTTERM_NAME
                                    , EST_STARTDATE
                                    , EST_COMPDATE
                                    , MONTHLY_CLOSE_DAY
                                    , PRE_CLOSE_DAY
                                    , KPI_QLT_CLOSE_DAY
                                    , YEARLY_CLOSE_YN
                                    , SCORE_VALUATION_TYPE
                                    , EST_DESC
                                    , EST_STATUS
                                    , CLOSE_RATE_COMPLETE_YN
                                    , CREATE_DATE
                                    , CREATE_USER
                                    , UPDATE_DATE
                                    , UPDATE_USER
                                FROM	EST_TERM_INFO
	                                WHERE EST_STATUS = 1
                                        ORDER BY EST_STARTDATE DESC";

            DataSet ds = DbAgentObj.FillDataSet(query, "TERMINFOGETALL", null, null, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 평가기간 등록
        /// </summary>
        /// <param name="iestterm_name">기간명</param>
        /// <param name="iest_startdate">시작일자</param>
        /// <param name="iest_compdate">종료일자</param>
        /// <param name="imonthly_close_day">월마감일</param>
        /// <param name="ipre_close_day">예비마감일</param>
        /// <param name="iyearly_close_yn">년평가종료여부</param>
        /// <param name="iscore_valuation_type">점수평가방식</param>
        /// <param name="iest_desc">평가기타사항</param>
        /// <param name="iest_status">평가상태</param>
        /// <param name="iclose_rate_complete_yn">월평가평가 완료마감가능여부</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public string InsertData(string iestterm_name
                                                , DateTime iest_startdate
                                                , DateTime iest_compdate
                                                , int imonthly_close_day
                                                , int ipre_close_day
                                                , int ikpi_qlt_close_day
                                                , bool iyearly_close_yn
                                                , string iscore_valuation_type
                                                , string iest_desc
                                                , bool iest_status
                                                , bool iclose_rate_complete_yn
                                                , string iexternal_score_use_yn
                                                , string iexternal_score_type
                                                , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);
         
	        paramArray[0] 		 = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value  = "A";
	        paramArray[1] 		 = CreateDataParameter("@iESTTERM_NAME", SqlDbType.VarChar);
	        paramArray[1].Value  = iestterm_name;
	        paramArray[2] 		 = CreateDataParameter("@iEST_STARTDATE", SqlDbType.DateTime);
	        paramArray[2].Value  = iest_startdate;
	        paramArray[3] 		 = CreateDataParameter("@iEST_COMPDATE", SqlDbType.DateTime);
	        paramArray[3].Value  = iest_compdate;
	        paramArray[4] 		 = CreateDataParameter("@iMONTHLY_CLOSE_DAY", SqlDbType.Int);
	        paramArray[4].Value  = imonthly_close_day;
	        paramArray[5] 		 = CreateDataParameter("@iPRE_CLOSE_DAY", SqlDbType.Int);
	        paramArray[5].Value  = ipre_close_day;
	        paramArray[6] 		 = CreateDataParameter("@iKPI_QLT_CLOSE_DAY", SqlDbType.Int);
	        paramArray[6].Value  = ikpi_qlt_close_day;
	        paramArray[7] 		 = CreateDataParameter("@iYEARLY_CLOSE_YN", SqlDbType.Int);
	        paramArray[7].Value  = (iyearly_close_yn) ? 1 : 0;
	        paramArray[8] 		 = CreateDataParameter("@iSCORE_VALUATION_TYPE", SqlDbType.VarChar);
	        paramArray[8].Value  = iscore_valuation_type;
	        paramArray[9] 		 = CreateDataParameter("@iEST_DESC", SqlDbType.VarChar);
	        paramArray[9].Value  = iest_desc;
	        paramArray[10] 		 = CreateDataParameter("@iEST_STATUS", SqlDbType.Int);
            paramArray[10].Value = (iest_status) ? 1 : 0;
            paramArray[11]       = CreateDataParameter("@iCLOSE_RATE_COMPLETE_YN", SqlDbType.Int);
	        paramArray[11].Value = (iclose_rate_complete_yn) ? 1 : 0 ;
            paramArray[12] 	     = CreateDataParameter("@iEXTERNAL_SCORE_USE_YN", SqlDbType.Char);
            paramArray[12].Value = iexternal_score_use_yn;
            paramArray[13] 		 = CreateDataParameter("@iEXTERNAL_SCORE_TYPE", SqlDbType.Char);
            paramArray[13].Value = iexternal_score_type;
	        paramArray[14] 		= CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[14].Value= itxr_user;
	        paramArray[15] 		= CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
	        paramArray[15].Direction 	= ParameterDirection.Output ;
	        paramArray[16] 		= CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
	        paramArray[16].Direction 	= ParameterDirection.Output ;
 
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            string Transaction_Result   = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            string Transaction_Message  = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();

            string rtnResult            =  Transaction_Result +"\t" + Transaction_Message;

            return rtnResult;
        }

        /// <summary>
        /// 평가기간 수정
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간 ID</param>
        /// <param name="iestterm_name">기간명</param>
        /// <param name="iest_startdate">시작일자</param>
        /// <param name="iest_compdate">종료일자</param>
        /// <param name="imonthly_close_day">월마감일</param>
        /// <param name="ipre_close_day">예비마감일</param>
        /// <param name="iyearly_close_yn">년평가종료여부</param>
        /// <param name="iscore_valuation_type">점수평가방식</param>
        /// <param name="iest_desc">평가기타사항</param>
        /// <param name="iest_status">평가상태</param>
        /// <param name="iclose_rate_complete_yn">월평가평가 완료마감가능여부</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public string UpdateData(int iestterm_ref_id
                               , string iestterm_name
                               , DateTime iest_startdate 
                               , DateTime iest_compdate
                               , int imonthly_close_day
                               , int ipre_close_day
                               , int ikpi_qlt_close_day
                               , string iscore_valuation_type
                               , string iest_desc
                               , bool iest_status
                               , bool iclose_rate_complete_yn
                               , string iexternal_score_use_yn
                               , string iexternal_score_type
                               , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iESTTERM_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = iestterm_name;
            paramArray[3]               = CreateDataParameter("@iEST_STARTDATE", SqlDbType.DateTime);
            paramArray[3].Value         = iest_startdate;
            paramArray[4]               = CreateDataParameter("@iEST_COMPDATE", SqlDbType.DateTime);
            paramArray[4].Value         = iest_compdate;
            paramArray[5]               = CreateDataParameter("@iMONTHLY_CLOSE_DAY", SqlDbType.Int);
            paramArray[5].Value         = imonthly_close_day;
            paramArray[6]               = CreateDataParameter("@iPRE_CLOSE_DAY", SqlDbType.Int);
            paramArray[6].Value         = ipre_close_day;
	        paramArray[7] 	            = CreateDataParameter("@iKPI_QLT_CLOSE_DAY", SqlDbType.Int);
	        paramArray[7].Value         = ikpi_qlt_close_day;
            paramArray[8]               = CreateDataParameter("@iSCORE_VALUATION_TYPE", SqlDbType.VarChar);
            paramArray[8].Value         = iscore_valuation_type;
            paramArray[9]               = CreateDataParameter("@iEST_DESC", SqlDbType.VarChar);
            paramArray[9].Value         = iest_desc;
            paramArray[10]              = CreateDataParameter("@iEST_STATUS", SqlDbType.Int);
            paramArray[10].Value        = (iest_status) ? 1 : 0;
            paramArray[11]              = CreateDataParameter("@iCLOSE_RATE_COMPLETE_YN", SqlDbType.Int);
            paramArray[11].Value        = (iclose_rate_complete_yn) ? 1 : 0;
            paramArray[12] 	            = CreateDataParameter("@iEXTERNAL_SCORE_USE_YN", SqlDbType.Char);
            paramArray[12].Value        = iexternal_score_use_yn;
            paramArray[13] 		        = CreateDataParameter("@iEXTERNAL_SCORE_TYPE", SqlDbType.Char);
            paramArray[13].Value        = iexternal_score_type;
            paramArray[14]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[14].Value        = itxr_user;
            paramArray[15]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[16].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            string Transaction_Result   = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            string Transaction_Message  = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();

            string rtnResult            =  Transaction_Result +"\t" + Transaction_Message;

            return rtnResult;
        }

        /// <summary>
        /// 평가기간 삭제
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간 아이디</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public string DeleteData(int iestterm_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]           = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value     = "D";
            paramArray[1]           = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = iestterm_ref_id;
            paramArray[2]           = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value     = itxr_user;
            paramArray[3]           = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4]           = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_EST_TERM_INFO","PKG_EST_TERM_INFO.PROC_DLELTE"), paramArray, CommandType.StoredProcedure, out col);

            string Transaction_Result   = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            string Transaction_Message  = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();

            string rtnResult            =  Transaction_Result +"\t" + Transaction_Message;

            return rtnResult;
        }

        /// <summary>
        /// 평가기간 종료처리
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간아이디</param>
        /// <param name="itxr_user">처리자</param>
        /// <returns>처리건수</returns>
        public string CloseYearlyTerm(int iestterm_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]           = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value     = "CT";
            paramArray[1]           = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = iestterm_ref_id;
            paramArray[2]           = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value     = itxr_user;
            paramArray[3]           = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4]           = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_CLOSE_TERM"), paramArray, CommandType.StoredProcedure, out col);

            string Transaction_Result   = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            string Transaction_Message  = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();

            string rtnResult            =  Transaction_Result +"\t" + Transaction_Message;

            return rtnResult;
        }

        /// <summary>
        /// 평가기간 마감취소
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public string OpenYearlyTerm(int iestterm_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]           = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value     = "OT";
            paramArray[1]           = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = iestterm_ref_id;
            paramArray[2]           = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value     = itxr_user;
            paramArray[3]           = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4]           = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_OPEN_TERM"), paramArray, CommandType.StoredProcedure, out col);

            string Transaction_Result   = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            string Transaction_Message  = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();

            string rtnResult            =  Transaction_Result +"\t" + Transaction_Message;

            return rtnResult;
        }

        /// <summary>
        /// 전 평가기간 조회
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_SELECT_ALL"), "EST_TERM_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가기간 상세조회
        /// </summary>
        /// <param name="estterm_ref_id">평가기간 아이디</param>
        /// <returns></returns>
        public DataSet GetOneList(int estterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_SELECT_ONE"), "EST_TERM_INFO", null, paramArray, CommandType.StoredProcedure);

            return ds;
        }

        /// <summary>
        /// 사용자의 평가부서 아이디
        /// </summary>
        /// <param name="estterm_ref_id"></param>
        /// <returns></returns>
        public int GetEstDeptIdPerUser(int estterm_ref_id, int iemp_ref_id)
        {
            int intEstDept = 0;
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ED";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_SELECT_ESTDEPT_EMP"), "EST_TERM_INFO", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                intEstDept = Convert.ToInt32(ds.Tables[0].Rows[0]["EST_DEPT_REF_ID"].ToString());
            }
            else
            {
                intEstDept = 0;
            }

            return intEstDept;
        }

        /// <summary>
        /// 평가중인 평가기간 조회
        /// </summary>
        /// <returns></returns>
        public int GetOpenEstTermID()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "OE";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_EST_TERM_INFO", "PKG_EST_TERM_INFO.PROC_SELECT_OPEN_ESTTERM"), "EST_TERM_INFO", null, paramArray, CommandType.StoredProcedure);

            int intRtn = 0;

            if(ds.Tables.Count > 0) 
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    intRtn = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }

            return intRtn;
        }
    }
}
