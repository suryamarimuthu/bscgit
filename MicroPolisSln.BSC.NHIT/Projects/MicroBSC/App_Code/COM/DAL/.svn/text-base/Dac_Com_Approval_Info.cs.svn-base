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
using System.Collections;
using System.Collections.Specialized;

using MicroBSC.Data;
using MicroBSC.Biz.Common.Biz;

public struct Biz_Type
{
    public const string app_category_cod = "CM003"; // CATEGORY CODE
    public const string biz_type_kpi_doc = "KDA";   // 지표정의서
    public const string biz_type_kpi_docbatch = "KDB";   // 지표정의서 일괄결재
    public const string biz_type_kpi_rst = "KRA";   // 실적
    public const string biz_type_kpi_rstbatch = "KRB";   // 지표실적 일괄결재
    public const string biz_type_prj_doc = "PMA";   // 사업관리
    public const string biz_type_target_agreement = "TAA"; //목표합의(MBO)
    
    public const string biz_type_target_result = "TRA"; //MBO실적
    public const string biz_type_target_resultbatch = "TRB"; //MBO실적 일괄결재

    public const string biz_type_kpi_doc_name = "조직KPI 결재";//"지표정의서 결재";
    public const string biz_type_kpi_docbatch_name = "조직KPI 일괄결재";//"지표정의서 일괄결재";
    public const string biz_type_kpi_rst_name = "조직KPI 실적 결재";//"실적 결재";
    public const string biz_type_kpi_rstbatch_name = "조직KPI 실적 일괄결재";//"지표실적 일괄결재";
    public const string biz_type_prj_doc_name = "사업관리 결재";
    public const string biz_type_prm_doc_name = "사업관리 실적 보고";
    public const string biz_type_target_agreement_name = "목표합의서 결재";
    public const string biz_type_target_result_name = "개인KPI 실적 결재";//"MBO실적 결재";
    public const string biz_type_target_resultbatch_name = "개인KPI 실적 일괄결재";//"MBO실적 일괄결재";

    public const string qry_selt_kpi_doc = @"SELECT KP.KPI_NAME
                                               FROM BSC_KPI_INFO KI
                                                    INNER JOIN BSC_KPI_POOL KP
                                                       ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
                                                      AND KI.ESTTERM_REF_ID  = {0}
                                                      AND KI.KPI_REF_ID      = {1}";
    public const string qry_selt_kpi_rst = @"SELECT KP.KPI_NAME
                                               FROM BSC_KPI_RESULT KR
                                                    INNER JOIN BSC_KPI_INFO KI
                                                       ON KR.ESTTERM_REF_ID = KI.ESTTERM_REF_ID
                                                      AND KR.KPI_REF_ID     = KI.KPI_REF_ID
                                                    INNER JOIN BSC_KPI_POOL KP
                                                       ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
                                              WHERE KR.ESTTERM_REF_ID  = {0}
                                                AND KR.KPI_REF_ID      = {1}
                                                AND KR.YMD             = '{2}'";

    public const string qry_selt_prj_doc = "SELECT PRJ_NAME FROM PRJ_INFO WHERE PRJ_REF_ID = {0}";

    public const string qry_selt_target_result = @"SELECT KP.KPI_NAME
                                               FROM BSC_KPI_RESULT KR
                                                    INNER JOIN BSC_KPI_INFO KI
                                                       ON KR.ESTTERM_REF_ID = KI.ESTTERM_REF_ID
                                                      AND KR.KPI_REF_ID     = KI.KPI_REF_ID
                                                    INNER JOIN BSC_KPI_POOL KP
                                                       ON KI.KPI_POOL_REF_ID = KP.KPI_POOL_REF_ID
                                              WHERE KR.ESTTERM_REF_ID  = {0}
                                                AND KR.KPI_REF_ID      = {1}
                                                AND KR.YMD             = '{2}'";

    public const string qry_udat_kpi_doc         = "UPDATE BSC_KPI_INFO   SET APP_REF_ID={0} WHERE ESTTERM_REF_ID={1} AND KPI_REF_ID={2}";
    public const string qry_udat_kpi_rst         = "UPDATE BSC_KPI_RESULT SET APP_REF_ID={0} WHERE ESTTERM_REF_ID={1} AND KPI_REF_ID={2} AND YMD='{3}'";
    public const string qry_udat_prj_doc         = "UPDATE PRJ_INFO       SET APP_REF_ID={0} WHERE PRJ_REF_ID = {1}";
    //public const string qry_udat_target_agreement = @"
//DELETE FROM BSC_MBO_KPI_TARGET_AGREEMENT WHERE ESTTERM_REF_ID={1} AND EMP_REF_ID={2}
//INSERT INTO BSC_MBO_KPI_TARGET_AGREEMENT (ESTTERM_REF_ID, EMP_REF_ID, APP_REF_ID, CREATE_DATE, CREATE_USER) VALUES ({1}, {2}, {0}, GETDATE(), {2})";
    public const string qry_udat_target_result = "UPDATE BSC_KPI_RESULT SET APP_REF_ID={0} WHERE ESTTERM_REF_ID={1} AND KPI_REF_ID={2} AND YMD='{3}'";

    public const string path_kpi_doc             = "/_common/Draft/DOC0101S1.aspx";  // 정의서
    public const string path_kpi_docbatch        = "/_common/Draft/DOC0601S1.aspx";  // 정의서일괄결재
    public const string path_rst_doc             = "/_common/Draft/DOC0201S1.aspx";  // 실적
    public const string path_rst_docbatch        = "/_common/Draft/DOC0701S1.aspx";  // 실적일괄결재
    public const string path_prj_doc             = "/_common/Draft/DOC0301S1.aspx";  // 사업관리
    public const string path_target_agreement    = "/_common/Draft/DOC0401S1.aspx";  // MBO목표합의
    public const string path_target_result       = "/_common/Draft/DOC0501S1.aspx";  // MBO실적
    public const string path_target_resultbatch = "/_common/Draft/DOC0701S1.aspx";  // MBO실적일괄결재

    public const string app_status_nodraft       = "NFT";  // 기타코드:Y - 미상신
    public const string app_status_draft         = "DFT";  // 기타코드:Y - 기안
    public const string app_status_return        = "RFT";  // 기타코드:Y - 반려
    public const string app_status_recall        = "AFT";  // 기타코드:Y - 회수
    public const string app_status_ondraft       = "OFT";  // 기타코드:Y - 결재중
    public const string app_status_onmodify      = "MFT";  // 기타코드:Y - 수정기안중
    public const string app_status_complete      = "CFT";  // 기타코드:Y - 결재완료    

    public const string app_status_img_none      = "../images/draft/sta_non.gif";  // 기타코드:Y - 미상신
    public const string app_status_img_draft     = "../images/draft/sta_dft.gif";  // 기타코드:Y - 기안
    public const string app_status_img_return    = "../images/draft/sta_rft.gif";  // 기타코드:Y - 반려
    public const string app_status_img_recall    = "../images/draft/sta_aft.gif";  // 기타코드:Y - 회수
    public const string app_status_img_ondraft   = "../images/draft/sta_oft.gif";  // 기타코드:Y - 결재중
    public const string app_status_img_onmodify  = "../images/draft/sta_mft.gif";  // 기타코드:Y - 수정기안중
    public const string app_status_img_complete  = "../images/draft/sta_cft.gif";  // 기타코드:Y - 결재완료    

    public const string app_status_desc_none     = "미상신";
    public const string app_status_desc_draft    = "기안";
    public const string app_status_desc_return   = "반려";
    public const string app_status_desc_recall   = "회수";
    public const string app_status_desc_ondraft  = "결재중";
    public const string app_status_desc_onmodify = "수정기안중";
    public const string app_status_desc_complete = "결재완료";

    public const string app_draft_first          = "FD";    // 기타코드:Y - 최초기안
    public const string app_draft_redraft        = "RD";    // 기타코드:Y - 재기안    (반려     -> 재기안)
    public const string app_draft_rewrite        = "WD";    // 기타코드:Y - 재작성    (회수     -> 재작성)
    public const string app_draft_modify         = "MD";    // 기타코드:Y - 수정기안  (수정상신 -> 수정기안)
    public const string app_draft_approval       = "AP";    // 기타코드:N - 승인
    public const string app_draft_select         = "SS";    // 기타코드:N - 결재문서 조회

    public const string app_legend = "<img alt='' src='" + app_status_img_none + "' />" + app_status_desc_none + "&nbsp;&nbsp;&nbsp;<img alt='' src='" + app_status_img_draft + "' />" + app_status_desc_draft + "&nbsp;&nbsp;&nbsp;<img alt='' src='" + app_status_img_return + "' />" + app_status_desc_return + "&nbsp;&nbsp;&nbsp;<img alt='' src='" + app_status_img_recall + "' />" + app_status_desc_recall + "&nbsp;&nbsp;&nbsp;<img alt='' src='" + app_status_img_ondraft + "' />" + app_status_desc_ondraft + "&nbsp;&nbsp;&nbsp;<img alt='' src='" + app_status_img_onmodify + "' />" + app_status_desc_onmodify + "&nbsp;&nbsp;&nbsp;<img alt='' src='" + app_status_img_complete + "' />" + app_status_desc_complete + "&nbsp;&nbsp;&nbsp;"; // 결재상태 범례

}

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_Com_Approval_Info
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Com_Approval_Info
    /// Class Func     : COM_APPROVAL_INFO Table Data Access
    /// CREATE DATE    : 2008-05-16 오후 7:35:50
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    /// 

    public class Dac_Com_Approval_Info : DbAgentBase
    {
        #region ============================== [결재원문정보변수선언] ================
        // 현재 결재는 지표정의서, 실적, 사업관리 등이며 추후 추가되는 부분에 대해서는 
        // 이부분에 추가해야함



        /// <summary>
        /// 결재문서의 원래문서제목을 가져온다
        /// </summary>
        /// <param name="iBizTypeCode">업무유형코드</param>
        /// <param name="pParam">파라미터인자</param>
        /// <param name="pTitle">문서제목</param>
        /// <returns></returns>
        public bool GetOriDocTitle(string iBizTypeCode, NameValueCollection pParam, out string pTitle)
        {
            Biz_Com_Code_Info objCod = new Biz_Com_Code_Info(Biz_Type.app_category_cod, iBizTypeCode);
            
            string strTable = objCod.Isegment1;
            string strKey1  = objCod.Isegment2;
            string strKey2  = objCod.Isegment3;
            string strKey3  = objCod.Isegment4;
            string strKey4  = objCod.Isegment5;

            string strVal1 = "";
            string strVal2 = "";
            string strVal3 = "";
            string strVal4 = "";

            string strQry  = "";
            pTitle = "";

            if (iBizTypeCode == Biz_Type.biz_type_kpi_doc)      // 지표 정의서 문서제목
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);

                strQry = string.Format(Biz_Type.qry_selt_kpi_doc, strVal1, strVal2);
            }
            else if (iBizTypeCode == Biz_Type.biz_type_kpi_rst) // 지표 실적 문서제목
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);
                strVal3 = pParam.Get(strKey3);

                strQry = string.Format(Biz_Type.qry_selt_kpi_rst, strVal1, strVal2, strVal3);
            }
            else if (iBizTypeCode == Biz_Type.biz_type_prj_doc) // 사업관리 문서제목
            {
                strVal1 = pParam.Get(strKey1);

                strQry = string.Format(Biz_Type.qry_selt_prj_doc, strVal1);   
            }
            else if (iBizTypeCode == Biz_Type.biz_type_target_agreement) // 목표합의서
            {
                
                strQry = GetQueryStringByDb("SELECT '목표합의서'", "SELECT '목표합의서' FROM DUAL");
            }
            else if (iBizTypeCode == Biz_Type.biz_type_kpi_docbatch) // 지표정의서일괄결재
            {
                strQry = GetQueryStringByDb("SELECT '지표정의서 일괄결재'", "SELECT '지표정의서 일괄결재' FROM DUAL");
            }
            else if (iBizTypeCode == Biz_Type.biz_type_kpi_rstbatch) // 실적 일괄결재
            {
                strVal3 = pParam.Get("YMD").Substring(0, 4) + "/" + pParam.Get("YMD").Substring(4, 2);
                //strQry = GetQueryStringByDb("SELECT '" + strVal3 + " 지표실적 일괄결재'", "SELECT '" + strVal3 + " 지표실적 일괄결재' FROM DUAL");
                strQry = GetQueryStringByDb("SELECT '" + strVal3 + " 조직KPI 실적 일괄결재'", "SELECT '" + strVal3 + " 조직KPI 실적 일괄결재' FROM DUAL");
            }
            else if (iBizTypeCode == Biz_Type.biz_type_target_resultbatch) // MBO실적 일괄결재
            {
                strVal3 = pParam.Get("YMD").Substring(0, 4) + "/" + pParam.Get("YMD").Substring(4, 2);
                strQry = GetQueryStringByDb("SELECT '" + strVal3 + " MBO실적 일괄결재'", "SELECT '" + strVal3 + " MBO실적 일괄결재' FROM DUAL");
            }
            else if (iBizTypeCode == Biz_Type.biz_type_target_result) // MBO 실적 문서제목
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);
                strVal3 = pParam.Get(strKey3);

                strQry = string.Format(Biz_Type.qry_selt_kpi_rst, strVal1, strVal2, strVal3);
            }

            if (strQry != "")
            {
                DataSet ds = DbAgentObj.FillDataSet(strQry, "ORI_DOC_INFO", null, null, CommandType.Text);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        pTitle = ds.Tables[0].Rows[0][0].ToString();
                        return true;
                    }
                    else
                    {
                        pTitle = "";
                        return false;
                    }
                }
                else
                {
                    pTitle = "";
                    return false;
                }
            }

            return false;
        }

        public bool UpdateOriDocAppKey_Dac(IDbConnection con, IDbTransaction trx, string iBizTypeCode, NameValueCollection pParam, decimal pAppRefId)
        {
            Biz_Com_Code_Info objCod = new Biz_Com_Code_Info(Biz_Type.app_category_cod, iBizTypeCode);

            string strTable = objCod.Isegment1;
            string strKey1 = objCod.Isegment2;
            string strKey2 = objCod.Isegment3;
            string strKey3 = objCod.Isegment4;
            string strKey4 = objCod.Isegment5;

            string strVal1 = "";
            string strVal2 = "";
            string strVal3 = "";
            string strVal4 = "";

            string strQry = "";

            if (iBizTypeCode == Biz_Type.biz_type_kpi_doc)      // 지표 정의서 문서제목
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);

                strQry = string.Format(Biz_Type.qry_udat_kpi_doc, pAppRefId.ToString(), strVal1, strVal2);
            }
            else if (iBizTypeCode == Biz_Type.biz_type_kpi_rst) // 지표 실적 문서제목
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);
                strVal3 = pParam.Get(strKey3);

                strQry = string.Format(Biz_Type.qry_udat_kpi_rst, pAppRefId.ToString(), strVal1, strVal2, strVal3);
            }
            else if (iBizTypeCode == Biz_Type.biz_type_prj_doc) // 사업관리 문서제목
            {
                strVal1 = pParam.Get(strKey1);

                strQry = string.Format(Biz_Type.qry_udat_prj_doc, pAppRefId.ToString(), strVal1);
            }
            else if (iBizTypeCode == Biz_Type.biz_type_target_agreement) // MBO 목표합의
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);

                //strQry = string.Format(Biz_Type.qry_udat_target_agreement, pAppRefId.ToString(), strVal1, strVal2);
                //strQry = string.Format(strQry, strVal1, strVal2);

                strQry = "DELETE FROM BSC_MBO_KPI_TARGET_AGREEMENT WHERE ESTTERM_REF_ID={0} AND EMP_REF_ID={1}";
                strQry = string.Format(strQry, strVal1, strVal2);

                int iRtn = DbAgentObj.ExecuteNonQuery(con, trx, strQry, null, CommandType.Text);

                strQry = "INSERT INTO BSC_MBO_KPI_TARGET_AGREEMENT (ESTTERM_REF_ID, EMP_REF_ID, APP_REF_ID, CREATE_DATE, CREATE_USER) VALUES ({1}, {2}, {0}, GETDATE(), {2})";
                strQry = string.Format(strQry, pAppRefId.ToString(), strVal1, strVal2);

                iRtn = DbAgentObj.ExecuteNonQuery(con, trx, strQry, null, CommandType.Text);
                if (iRtn > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (iBizTypeCode == Biz_Type.biz_type_target_result) // MBO 실적 문서제목
            {
                strVal1 = pParam.Get(strKey1);
                strVal2 = pParam.Get(strKey2);
                strVal3 = pParam.Get(strKey3);

                strQry = string.Format(Biz_Type.qry_udat_kpi_rst, pAppRefId.ToString(), strVal1, strVal2, strVal3);
            }

            if (strQry != "")
            {
                int iRtn = DbAgentObj.ExecuteNonQuery(con, trx, strQry, null, CommandType.Text);
                if (iRtn > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        #endregion

        #region ============================== [Fields] ==============================
        private decimal        _iapp_ref_id;
        private Int32          _iversion_no;
        private String         _iapp_code;
        private String         _iactive_yn;
        private String         _iori_doc;
        private String         _ititle;
        private String         _ibiz_type;
        private String         _iapp_status;
        private String         _iapp_status_name;
        private String         _idraft_status;
        private String         _idraft_status_name;
        private String         _ifile_ref_id;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private Int32 	       _itxr_user;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public decimal IApp_Ref_Id
        {
            get { return _iapp_ref_id; }
            set { _iapp_ref_id = value; }
        }
        public int IVersion_No
        {
            get { return _iversion_no; }
            set { _iversion_no = value; }
        }
        public string IApp_Code
        {
            get { return _iapp_code; }
            set { _iapp_code = value; }
        }
        public string IActive_Yn
        {
            get { return _iactive_yn; }
            set { _iactive_yn = value; }
        }
        public string IOri_Doc
        {
            get { return _iori_doc; }
            set { _iori_doc = value; }
        }
        public string ITitle
        {
            get { return _ititle; }
            set { _ititle = value; }
        }
        public string IBiz_Type
        {
            get { return _ibiz_type; }
            set { _ibiz_type = value; }
        }
        public string IApp_Status
        {
            get { return _iapp_status; }
            set { _iapp_status = value; }
        }
        public string IApp_Status_Name
        {
            get { return _iapp_status_name; }
            set { _iapp_status_name = value; }
        }
        public string IDraft_Status
        {
            get { return _idraft_status; }
            set { _idraft_status = value; }
        }
        public string IDraft_Status_Name
        {
            get { return _idraft_status_name; }
            set { _idraft_status_name = value; }
        }
        public string IFile_Ref_Id
        {
            get { return _ifile_ref_id; }
            set { _ifile_ref_id = value; }
        }
        public int ICreate_User
        {
            get { return _icreate_user; }
            set { _icreate_user = value; }
        }
        public System.DateTime ICreate_Date
        {
            get { return _icreate_date; }
            set { _icreate_date = value; }
        }
        public int IUpdate_User
        {
            get { return _iupdate_user; }
            set { _iupdate_user = value; }
        }
        public System.DateTime IUpdate_Date
        {
            get { return _iupdate_date; }
            set { _iupdate_date = value; }
        }
        public int Itxr_user
        {
            get{ return _itxr_user; }
            set{ _itxr_user = value; }
        }
        public String Transaction_Message
        {
            get { return _txr_message; }
            set { _txr_message = value; }
        }
        public String Transaction_Result
        {
            get { return _txr_result; }
            set { _txr_result = value; }
        }
        #endregion
		
		#region ============================== [Constructor] ==============================
		public Dac_Com_Approval_Info() { }
        public Dac_Com_Approval_Info(decimal iapp_ref_id)
        {
            DataSet ds = this.GetOneList( iapp_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iapp_ref_id                 = (dr["APP_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToDecimal(dr["APP_REF_ID"]);
                _iversion_no                 = (dr["VERSION_NO"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                _iapp_code                   = (dr["APP_CODE"]    == DBNull.Value) ? "" : Convert.ToString(dr["APP_CODE"]);
                _iactive_yn                  = (dr["ACTIVE_YN"]   == DBNull.Value) ? "" : Convert.ToString(dr["ACTIVE_YN"]);
                _iori_doc                    = (dr["ORI_DOC"]     == DBNull.Value) ? "" : Convert.ToString(dr["ORI_DOC"]);
                _ititle                      = (dr["TITLE"]       == DBNull.Value) ? "" : Convert.ToString(dr["TITLE"]);
                _ibiz_type                   = (dr["BIZ_TYPE"]    == DBNull.Value) ? "" : Convert.ToString(dr["BIZ_TYPE"]);
                _iapp_status                 = (dr["APP_STATUS"] == DBNull.Value) ? Biz_Type.app_status_nodraft : Convert.ToString(dr["APP_STATUS"]);
                _iapp_status_name            = (dr["APP_STATUS_NAME"]  == DBNull.Value) ? "" : Convert.ToString(dr["APP_STATUS_NAME"]);
                _idraft_status               = (dr["DRAFT_STATUS"] == DBNull.Value) ? "" : Convert.ToString(dr["DRAFT_STATUS"]);
                _idraft_status_name          = (dr["DRAFT_STATUS_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["DRAFT_STATUS_NAME"]);
                _ifile_ref_id                = (dr["FILE_REF_ID"] == DBNull.Value) ? "" : Convert.ToString(dr["FILE_REF_ID"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
            else
            {
                _iapp_ref_id      = 0;
                _iversion_no      = 0;
                _iapp_code        = "";
                _iactive_yn       = "N";
                _iori_doc         = "";
                _ititle           = "";
                _ibiz_type        = "";
                _iapp_status      = Biz_Type.app_status_nodraft;
                _iapp_status_name = Biz_Type.app_status_desc_none;  
                _idraft_status    = "";
                _idraft_status_name = "";
            }
		}

        public Dac_Com_Approval_Info(decimal iapp_ref_id, int iversion_no)
        {
            DataSet ds = this.GetOneList( iapp_ref_id, iversion_no);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iapp_ref_id                 = (dr["APP_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToDecimal(dr["APP_REF_ID"]);
                _iversion_no                 = (dr["VERSION_NO"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                _iapp_code                   = (dr["APP_CODE"]    == DBNull.Value) ? "" : Convert.ToString(dr["APP_CODE"]);
                _iactive_yn                  = (dr["ACTIVE_YN"]   == DBNull.Value) ? "" : Convert.ToString(dr["ACTIVE_YN"]);
                _iori_doc                    = (dr["ORI_DOC"]     == DBNull.Value) ? "" : Convert.ToString(dr["ORI_DOC"]);
                _ititle                      = (dr["TITLE"]       == DBNull.Value) ? "" : Convert.ToString(dr["TITLE"]);
                _ibiz_type                   = (dr["BIZ_TYPE"]    == DBNull.Value) ? "" : Convert.ToString(dr["BIZ_TYPE"]);
                _iapp_status                 = (dr["APP_STATUS"] == DBNull.Value) ? Biz_Type.app_status_nodraft : Convert.ToString(dr["APP_STATUS"]);
                _iapp_status_name            = (dr["APP_STATUS_NAME"]  == DBNull.Value) ? "" : Convert.ToString(dr["APP_STATUS_NAME"]);
                _idraft_status               = (dr["DRAFT_STATUS"] == DBNull.Value) ? "" : Convert.ToString(dr["DRAFT_STATUS"]);
                _idraft_status_name          = (dr["DRAFT_STATUS_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["DRAFT_STATUS_NAME"]);
                _ifile_ref_id                = (dr["FILE_REF_ID"] == DBNull.Value) ? "" : Convert.ToString(dr["FILE_REF_ID"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
            else
            {
                _iapp_ref_id      = 0;
                _iversion_no      = 0;
                _iapp_code        = "";
                _iactive_yn       = "N";
                _iori_doc         = "";
                _ititle           = "";
                _ibiz_type        = "";
                _iapp_status      = Biz_Type.app_status_nodraft;
                _iapp_status_name = Biz_Type.app_status_desc_none;  
                _idraft_status    = "";
                _idraft_status_name = "";
            }
		}
		#endregion
		
		#region ============================== [Method] ==============================
        /// <summary>
        /// 최초기안
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="idraft_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction txr, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = 0;
            paramArray[2]               = CreateDataParameter("@iORI_DOC", SqlDbType.Text);
            paramArray[2].Value         = "";
            paramArray[3]               = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[3].Value         = ititle;
            paramArray[4]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = ibiz_type;
            paramArray[5]               = CreateDataParameter("@iAPP_STATUS", SqlDbType.VarChar);
            paramArray[5].Value         = iapp_status;
            paramArray[6]               = CreateDataParameter("@iDRAFT_STATUS", SqlDbType.VarChar);
            paramArray[6].Value         = idraft_status;
            paramArray[7]               = CreateDataParameter("@iFILE_REF_ID", SqlDbType.VarChar);
            paramArray[7].Value         = ifile_ref_id;
            paramArray[8]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value         = itxr_user;
            paramArray[9]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_APP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Direction    = ParameterDirection.Output;
			paramArray[12]              = CreateDataParameter("@oRTN_VERSION_NO", SqlDbType.Int);
            paramArray[12].Direction    = ParameterDirection.Output;

			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IApp_Ref_Id            = (this.Transaction_Result == "N") ? 0 : decimal.Parse(GetOutputParameterValueBySP(col,"@oRTN_APP_REF_ID").ToString());
            this.IVersion_No            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_VERSION_NO").ToString());

            if (this.Transaction_Result == "Y")
            {
                this.UpdateAppDoc(con, txr, this.IApp_Ref_Id, this.IVersion_No, iori_doc);
            }

            return affectedRow;
        }

        /// <summary>
        /// 재기안 : 반려시 호출
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="idraft_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int ReDraft_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RD";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
            paramArray[2]               = CreateDataParameter("@iORI_DOC", SqlDbType.Text);
            paramArray[2].Value         = "";
            paramArray[3]               = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[3].Value         = ititle;
            paramArray[4]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = ibiz_type;
            paramArray[5]               = CreateDataParameter("@iAPP_STATUS", SqlDbType.VarChar);
            paramArray[5].Value         = iapp_status;
            paramArray[6]               = CreateDataParameter("@iDRAFT_STATUS", SqlDbType.VarChar);
            paramArray[6].Value         = idraft_status;
            paramArray[7]               = CreateDataParameter("@iFILE_REF_ID", SqlDbType.VarChar);
            paramArray[7].Value         = ifile_ref_id;
            paramArray[8]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value         = itxr_user;
            paramArray[9]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_APP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Direction    = ParameterDirection.Output;
			paramArray[12]              = CreateDataParameter("@oRTN_VERSION_NO", SqlDbType.Int);
            paramArray[12].Direction    = ParameterDirection.Output;

			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_RE_DRAFT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IApp_Ref_Id            = (this.Transaction_Result == "N") ? 0 : decimal.Parse(GetOutputParameterValueBySP(col,"@oRTN_APP_REF_ID").ToString());
            this.IVersion_No            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_VERSION_NO").ToString());

            if (this.Transaction_Result == "Y")
            {
                this.UpdateAppDoc(con, txr, this.IApp_Ref_Id, this.IVersion_No, iori_doc);
            }

            return affectedRow;
        }
		
        /// <summary>
        /// 수정기안 처리 : 수정결재요청시
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="idraft_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int MoDraft_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "MD";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
            paramArray[2]               = CreateDataParameter("@iORI_DOC", SqlDbType.Text);
            paramArray[2].Value         = "";
            paramArray[3]               = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[3].Value         = ititle;
            paramArray[4]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = ibiz_type;
            paramArray[5]               = CreateDataParameter("@iAPP_STATUS", SqlDbType.VarChar);
            paramArray[5].Value         = iapp_status;
            paramArray[6]               = CreateDataParameter("@iDRAFT_STATUS", SqlDbType.VarChar);
            paramArray[6].Value         = idraft_status;
            paramArray[7]               = CreateDataParameter("@iFILE_REF_ID", SqlDbType.VarChar);
            paramArray[7].Value         = ifile_ref_id;
            paramArray[8]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value         = itxr_user;
            paramArray[9]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_APP_REF_ID", SqlDbType.Decimal);
            paramArray[11].Direction    = ParameterDirection.Output;
			paramArray[12]              = CreateDataParameter("@oRTN_VERSION_NO", SqlDbType.Int);
            paramArray[12].Direction    = ParameterDirection.Output;

			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_MD_DRAFT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.IApp_Ref_Id            = (this.Transaction_Result == "N") ? 0 : decimal.Parse(GetOutputParameterValueBySP(col,"@oRTN_APP_REF_ID").ToString());
            this.IVersion_No            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_VERSION_NO").ToString());

            if (this.Transaction_Result == "Y")
            {
                this.UpdateAppDoc(con, txr, this.IApp_Ref_Id, this.IVersion_No, iori_doc);
            }

            return affectedRow;
        }

        /// <summary>
        /// 재작성 : 회수시 처리
        /// </summary>
        /// <param name="con"></param>
        /// <param name="txr"></param>
        /// <param name="iapp_ref_id"></param>
        /// <param name="iori_doc"></param>
        /// <param name="ititle"></param>
        /// <param name="ibiz_type"></param>
        /// <param name="iapp_status"></param>
        /// <param name="idraft_status"></param>
        /// <param name="ifile_ref_id"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        internal protected int ReWrite_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, string iori_doc, string ititle, string ibiz_type, string iapp_status, string idraft_status, string ifile_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "WD";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
			paramArray[2]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Decimal);
            paramArray[2].Value         = iversion_no;
            paramArray[3]               = CreateDataParameter("@iORI_DOC", SqlDbType.Text);
            paramArray[3].Value         = "";
            paramArray[4]               = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[4].Value         = ititle;
            paramArray[5]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[5].Value         = ibiz_type;
            paramArray[6]               = CreateDataParameter("@iAPP_STATUS", SqlDbType.VarChar);
            paramArray[6].Value         = iapp_status;
            paramArray[7]               = CreateDataParameter("@iDRAFT_STATUS", SqlDbType.VarChar);
            paramArray[7].Value         = idraft_status;
            paramArray[8]               = CreateDataParameter("@iFILE_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value         = ifile_ref_id;
            paramArray[9]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value         = itxr_user;
            paramArray[10]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[11].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_WD_DRAFT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            if (this.Transaction_Result == "Y")
            {
                this.UpdateAppDoc(con, txr, iapp_ref_id, iversion_no, iori_doc);
            }

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, string iapp_code, string iori_doc, string ititle, string ibiz_type, string ifile_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value         = iversion_no;
            paramArray[3]               = CreateDataParameter("@iAPP_CODE", SqlDbType.VarChar);
            paramArray[3].Value         = iapp_code;
            paramArray[4]               = CreateDataParameter("@iORI_DOC", SqlDbType.Text);
            paramArray[4].Value         = "";
            paramArray[5]               = CreateDataParameter("@iTITLE", SqlDbType.VarChar);
            paramArray[5].Value         = ititle;
            paramArray[6]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[6].Value         = ibiz_type;
            paramArray[7]               = CreateDataParameter("@iFILE_REF_ID", SqlDbType.VarChar);
            paramArray[7].Value         = ifile_ref_id;
            paramArray[8]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value         = itxr_user;
            paramArray[9]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            if (this.Transaction_Result == "Y")
            {
                this.UpdateAppDoc(con, txr, this.IApp_Ref_Id, this.IVersion_No, iori_doc);
            }

            return affectedRow;
        }

        private void UpdateAppDoc(IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, string iori_doc)
        { 
            string strSQL = "UPDATE COM_APPROVAL_INFO SET ORI_DOC = @iORI_DOC WHERE APP_REF_ID = @iAPP_REF_ID AND VERSION_NO = @iVERSION_NO";
			
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[0].Value         = iapp_ref_id;
            paramArray[1]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[1].Value         = iversion_no;
            paramArray[2]               = CreateDataParameter("@iORI_DOC", SqlDbType.Text);
            paramArray[2].Value         = iori_doc;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, strSQL, paramArray, CommandType.Text);
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction txr, decimal iapp_ref_id, int iversion_no, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
            paramArray[2]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value         = iversion_no;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, txr, GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(decimal iapp_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_SELECT_ONE"), "COM_APPROVAL_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(decimal iapp_ref_id, int iversion_no)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SV";
			paramArray[1]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iapp_ref_id;
			paramArray[2]               = CreateDataParameter("@iVERSION_NO", SqlDbType.Int);
            paramArray[2].Value         = iversion_no;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_SELECT_PER_VERSION"), "COM_APPROVAL_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public bool InsertFixEmp(IDbConnection conn, IDbTransaction trx, object biz_type, object[,] objAppEmp, object reg_user)
        {
            string strQuery = @"
INSERT INTO COM_APPROVAL_LINE_BASE
        (BIZ_TYPE, EMP_REF_ID, SORT_ORDER, CREATE_USER, CREATE_DATE)
    VALUES
        (@BIZ_TYPE, @EMP_REF_ID, @SORT_ORDER, @REG_USER, GETDATE())
";

            IDbDataParameter[] paramArray;

            for(int i = 0; i < objAppEmp.GetLength(0); i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(4);
                paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
                paramArray[0].Value = biz_type;
                paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[1].Value = objAppEmp[i, 0];
                paramArray[2] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
                paramArray[2].Value = objAppEmp[i, 1];
                paramArray[3] = CreateDataParameter("@REG_USER", SqlDbType.Int);
                paramArray[3].Value = reg_user;

                if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                {
                    this.Transaction_Message = "적용된 데이터가 없습니다.";
                    return false;
                }
            }

            return true;
        }

        public bool DeleteFixEmp(IDbConnection conn, IDbTransaction trx, object biz_type, object[] objAppEmp)
        {
            string strQuery = @"
DELETE FROM COM_APPROVAL_LINE_BASE
WHERE   BIZ_TYPE    = @BIZ_TYPE
    AND EMP_REF_ID  = @EMP_REF_ID
";

            IDbDataParameter[] paramArray;

            for (int i = 0; i < objAppEmp.Length; i++)
            {
                paramArray = null;
                paramArray = CreateDataParameters(2);
                paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
                paramArray[0].Value = biz_type;
                paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[1].Value = objAppEmp[i];

                if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                {
                    this.Transaction_Message = "적용된 데이터가 없습니다.";
                    return false;
                }
            }

            return true;
        }

        public bool ChangeLineSort(IDbConnection conn, IDbTransaction trx, object biz_type, bool sort_up, object[] objDraftEmp, object app_emp_ref_id, object reg_user)
        {
            string strAdd1 = string.Empty;
            string strAdd2 = string.Empty;
            if (sort_up)
            {
                strAdd1 = "+ 1";
                strAdd2 = "- 1";
            }
            else
            {
                strAdd1 = "- 1";
                strAdd2 = "+ 1";
            }

            string strQuery = @"
DECLARE @LINE_STEP INT
SELECT @LINE_STEP = LINE_STEP
FROM    COM_APPROVAL_LINE
WHERE   LINE_TYPE       = @LINE_TYPE
    AND EMP_REF_ID      = @EMP_REF_ID
    AND APP_EMP_REF_ID  = @APP_EMP_REF_ID

UPDATE COM_APPROVAL_LINE
    SET
        LINE_STEP   = LINE_STEP {0}, UPDATE_USER = @REG_USER, UPDATE_DATE = GETDATE()
WHERE   LINE_TYPE   = @LINE_TYPE
    AND EMP_REF_ID  = @EMP_REF_ID
    AND LINE_STEP   = @LINE_STEP {1}

UPDATE COM_APPROVAL_LINE
    SET
        LINE_STEP  = LINE_STEP {1}, UPDATE_USER = @REG_USER, UPDATE_DATE = GETDATE()
WHERE   LINE_TYPE       = @LINE_TYPE
    AND EMP_REF_ID      = @EMP_REF_ID
    AND APP_EMP_REF_ID  = @APP_EMP_REF_ID
";

            strQuery = string.Format(strQuery, strAdd1, strAdd2);

            IDbDataParameter[] paramArray;
            foreach(object objEmp in objDraftEmp)
            {
                paramArray = null;
                paramArray = CreateDataParameters(4);
                paramArray[0] = CreateDataParameter("@LINE_TYPE", SqlDbType.VarChar);
                paramArray[0].Value = biz_type;
                paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[1].Value = objEmp;
                paramArray[2] = CreateDataParameter("@APP_EMP_REF_ID", SqlDbType.Int);
                paramArray[2].Value = app_emp_ref_id;
                paramArray[3] = CreateDataParameter("@REG_USER", SqlDbType.Int);
                paramArray[3].Value = reg_user;

                if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                {
                    this.Transaction_Message = "적용된 데이터가 없습니다.";
                    return false;
                }
            }
            return true;
        }

        public bool ChangeBaseSort(IDbConnection conn, IDbTransaction trx, object biz_type, bool sort_up, object emp_ref_id, object reg_user)
        {
            string strAdd1 = string.Empty;
            string strAdd2 = string.Empty;
            if (sort_up)
            {
                strAdd1 = "+ 1";
                strAdd2 = "- 1";
            }
            else
            {
                strAdd1 = "- 1";
                strAdd2 = "+ 1";
            }

            string strQuery = @"
DECLARE @SORT_ORDER INT
SELECT @SORT_ORDER = SORT_ORDER
FROM    COM_APPROVAL_LINE_BASE
WHERE   BIZ_TYPE       = @LINE_TYPE
    AND EMP_REF_ID      = @EMP_REF_ID

UPDATE COM_APPROVAL_LINE_BASE
    SET
        SORT_ORDER  = SORT_ORDER {0}, UPDATE_USER = @REG_USER, UPDATE_DATE = GETDATE()
WHERE   BIZ_TYPE   = @LINE_TYPE
    AND SORT_ORDER  = @SORT_ORDER {1}

UPDATE COM_APPROVAL_LINE_BASE
    SET
        SORT_ORDER  = SORT_ORDER {1}, UPDATE_USER = @REG_USER, UPDATE_DATE = GETDATE()
WHERE   BIZ_TYPE   = @LINE_TYPE
    AND EMP_REF_ID  = @EMP_REF_ID
";

            strQuery = string.Format(strQuery, strAdd1, strAdd2);
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@LINE_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;
            paramArray[2] = CreateDataParameter("@REG_USER", SqlDbType.Int);
            paramArray[2].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
            {
                this.Transaction_Message = "적용된 데이터가 없습니다.";
                return false;
            }
            return true;
        }

        public bool InsertAppEmp(IDbConnection conn, IDbTransaction trx, object biz_type, object[] objDraftEmp, object[,] objAppEmp, object reg_user)
        {
            string strQuery = @"
INSERT INTO COM_APPROVAL_LINE
        (LINE_TYPE, EMP_REF_ID, APP_EMP_REF_ID, LINE_STEP, CREATE_USER, CREATE_DATE)
    VALUES
        (@LINE_TYPE, @DRAFT_EMP_REF_ID, @APP_EMP_REF_ID, @LINE_STEP, @REG_USER, GETDATE())
";

            IDbDataParameter[] paramArray;

            foreach (object draftEmp in objDraftEmp)
            {
                for (int i = 0; i < objAppEmp.GetLength(0); i++)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(5);
                    paramArray[0] = CreateDataParameter("@LINE_TYPE", SqlDbType.VarChar);
                    paramArray[0].Value = biz_type;
                    paramArray[1] = CreateDataParameter("@DRAFT_EMP_REF_ID", SqlDbType.Int);
                    paramArray[1].Value = draftEmp;
                    paramArray[2] = CreateDataParameter("@APP_EMP_REF_ID", SqlDbType.Int);
                    paramArray[2].Value = objAppEmp[i, 0];
                    paramArray[3] = CreateDataParameter("@LINE_STEP", SqlDbType.Int);
                    paramArray[3].Value = objAppEmp[i, 1];
                    paramArray[4] = CreateDataParameter("@REG_USER", SqlDbType.Int);
                    paramArray[4].Value = reg_user;

                    if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                    {
                        this.Transaction_Message = "적용된 데이터가 없습니다.";
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetLineUpdateHistory(IDbConnection conn, IDbTransaction trx, object app_ref_id, object version_no, object update_reason)
        {
            string strQuery = @"
UPDATE COM_APPROVAL_INFO
    SET UPDATE_REASON   = @UPDATE_REASON
WHERE   APP_REF_ID  = @APP_REF_ID
    AND VERSION_NO  = @VERSION_NO
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.Decimal);
            paramArray[0].Value = app_ref_id;
            paramArray[1] = CreateDataParameter("@VERSION_NO", SqlDbType.Int);
            paramArray[1].Value = version_no;
            paramArray[2] = CreateDataParameter("@UPDATE_REASON", SqlDbType.VarChar);
            paramArray[2].Value = update_reason;

            int rtnCount = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);
        }

        public bool DeleteAllEmp(IDbConnection conn, IDbTransaction trx, object biz_type, object[] objDraftEmp, object[] objAppEmp)
        {
            string strQuery = @"
DECLARE @LINE_STEP INT
SELECT @LINE_STEP = LINE_STEP
FROM    COM_APPROVAL_LINE
WHERE   LINE_TYPE       = @LINE_TYPE
    AND EMP_REF_ID      = @DRAFT_EMP_REF_ID
    AND APP_EMP_REF_ID  = @APP_EMP_REF_ID

UPDATE COM_APPROVAL_LINE
    SET
        LINE_STEP   = LINE_STEP - 1
WHERE   LINE_TYPE   = @LINE_TYPE
    AND EMP_REF_ID  = @DRAFT_EMP_REF_ID
    AND LINE_STEP   > @LINE_STEP

DELETE FROM COM_APPROVAL_LINE
WHERE   LINE_TYPE       = @LINE_TYPE
    AND EMP_REF_ID      = @DRAFT_EMP_REF_ID
    AND APP_EMP_REF_ID  = @APP_EMP_REF_ID
";

            IDbDataParameter[] paramArray;

            foreach (object draftEmp in objDraftEmp)
            {
                foreach (object appEmp in objAppEmp)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(3);
                    paramArray[0] = CreateDataParameter("@LINE_TYPE", SqlDbType.VarChar);
                    paramArray[0].Value = biz_type;
                    paramArray[1] = CreateDataParameter("@DRAFT_EMP_REF_ID", SqlDbType.Int);
                    paramArray[1].Value = draftEmp;
                    paramArray[2] = CreateDataParameter("@APP_EMP_REF_ID", SqlDbType.Int);
                    paramArray[2].Value = appEmp;

                    if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                    {
                        this.Transaction_Message = "적용된 데이터가 없습니다.";
                        return false;
                    }
                }
            }
            return true;
        }

        public DataTable GetLineUpdateReason(object app_ref_id, object version_no)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.Decimal);
            paramArray[0].Value = app_ref_id;
            paramArray[1] = CreateDataParameter("@VERSION_NO", SqlDbType.Int);
            paramArray[1].Value = version_no;

            string strQuery = @"
SELECT   APP_REF_ID, VERSION_NO, APP_CODE, ACTIVE_YN, ORI_DOC, TITLE, BIZ_TYPE, APP_STATUS, DRAFT_STATUS, FILE_REF_ID, UPDATE_REASON
FROM        COM_APPROVAL_INFO
WHERE   (APP_REF_ID   = @APP_REF_ID   OR APP_REF_ID     = 0)
    AND (VERSION_NO   = @VERSION_NO   OR VERSION_NO   = 0)
ORDER BY APP_REF_ID, VERSION_NO
";

            DataTable dt = DbAgentObj.FillDataSet(strQuery, "AppInfoList", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetApprovalEmpByOne(object biz_type, object draft_emp_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@LINE_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = draft_emp_ref_id;

            string strQuery = @"
SELECT   A.APP_EMP_REF_ID AS EMP_REF_ID, C.EMP_NAME, D.DEPT_NAME COM_DEPT_NAME, E.POS_CLS_NAME AS POSITION_CLASS_NAME, A.LINE_STEP AS SORT_ORDER
FROM        COM_APPROVAL_LINE   A
INNER JOIN  REL_DEPT_EMP    B   ON  B.EMP_REF_ID    = A.APP_EMP_REF_ID  AND B.REL_STATUS = 1
INNER JOIN  COM_EMP_INFO    C   ON  C.EMP_REF_ID    = B.EMP_REF_ID
INNER JOIN  COM_DEPT_INFO   D   ON  D.DEPT_REF_ID   = B.DEPT_REF_ID AND D.DEPT_FLAG = 1
LEFT OUTER JOIN EST_POSITION_CLS    E   ON  E.POS_CLS_ID    = C.POSITION_CLASS_CODE
WHERE   A.LINE_TYPE     = @LINE_TYPE
    AND A.EMP_REF_ID    = @EMP_REF_ID    
ORDER BY A.LINE_STEP
";

            DataTable dt = DbAgentObj.FillDataSet(strQuery, "AppEmpList", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetEmpList(object biz_type, object dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = dept_ref_id;
            paramArray[1] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value = biz_type;

            string strQuery = @"
SELECT   B.POSITION_DUTY_CODE, B.POSITION_CLASS_CODE, B.POSITION_RANK_CODE, A.EMP_REF_ID, B.EMP_NAME, C.DEPT_NAME, D.POS_CLS_NAME AS POSITION_CLASS_NAME
        ,CASE WHEN ISNULL(COUNT(E.EMP_REF_ID), 0) = 0 THEN 'N' ELSE 'Y' END AS EXIST_YN
FROM        REL_DEPT_EMP    A
INNER JOIN  COM_EMP_INFO    B   ON  B.EMP_REF_ID    = A.EMP_REF_ID
INNER JOIN  COM_DEPT_INFO   C   ON  C.DEPT_REF_ID   = A.DEPT_REF_ID AND C.DEPT_FLAG = 1
LEFT OUTER JOIN EST_POSITION_CLS    D   ON  D.POS_CLS_ID    = B.POSITION_CLASS_CODE
LEFT OUTER JOIN COM_APPROVAL_LINE   E   ON  E.LINE_TYPE  = @BIZ_TYPE AND E.EMP_REF_ID    = A.EMP_REF_ID
WHERE   A.DEPT_REF_ID   = @DEPT_REF_ID
    AND A.REL_STATUS = 1
GROUP BY B.POSITION_DUTY_CODE, B.POSITION_CLASS_CODE, B.POSITION_RANK_CODE, A.EMP_REF_ID, B.EMP_NAME, C.DEPT_NAME, D.POS_CLS_NAME
ORDER BY B.POSITION_DUTY_CODE, B.POSITION_CLASS_CODE, B.POSITION_RANK_CODE, B.EMP_NAME
";

            DataTable dt = DbAgentObj.FillDataSet(strQuery, "AppEmpList", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetBaseAppList(object biz_type)
        {
            string strQuery = @"
SELECT   A.BIZ_TYPE, A.EMP_REF_ID, A.SORT_ORDER
        ,C.DEPT_NAME AS COM_DEPT_NAME
        ,D.EMP_NAME
        ,E.POS_CLS_NAME AS POSITION_CLASS_NAME
FROM    COM_APPROVAL_LINE_BASE  A
INNER JOIN REL_DEPT_EMP    B   ON  B.EMP_REF_ID    = A.EMP_REF_ID  AND REL_STATUS  = 1
LEFT OUTER JOIN COM_DEPT_INFO   C   ON  C.DEPT_REF_ID   = B.DEPT_REF_ID
LEFT OUTER JOIN COM_EMP_INFO    D   ON  D.EMP_REF_ID    = B.EMP_REF_ID
LEFT OUTER JOIN EST_POSITION_CLS    E   ON  E.POS_CLS_ID    = D.POSITION_CLASS_CODE
WHERE   A.BIZ_TYPE  = @BIZ_TYPE
ORDER BY A.SORT_ORDER
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;

            return DbAgentObj.FillDataSet(strQuery, "COM_APPROVAL_BASELINE", null, paramArray, CommandType.Text).Tables[0];

        }

        public DataTable GetFullAppLine(object biz_type, object emp_ref_id)
        {
            string strQuery = @"
DECLARE @PLUSCOUNT INT, @LASTSTEP INT
SELECT @PLUSCOUNT = ISNULL(MAX(SORT_ORDER), 0)
FROM COM_APPROVAL_LINE_BASE
WHERE BIZ_TYPE   = @BIZ_TYPE

SELECT  @LASTSTEP = ISNULL(MAX(LINE_STEP), 0)
FROM    COM_APPROVAL_LINE
WHERE   LINE_TYPE   = @BIZ_TYPE
    AND EMP_REF_ID  = @EMP_REF_ID

SELECT   CE.COM_DEPT_REF_ID
        ,CE.EMP_REF_ID
        ,CE.COM_DEPT_NAME as DEPT_NAME
        ,CE.EMP_NAME
        ,ISNULL(EP.POS_RNK_NAME,' ') as POSITION_RANK_NAME
        ,TA.LINE_TYPE
        ,TA.SORT_ORDER
        ,TA.DEFAULT_YN
FROM viw_EMP_COMDEPT CE
INNER JOIN  (
                SELECT  APP_EMP_REF_ID AS EMP_REF_ID, LINE_STEP + @PLUSCOUNT AS SORT_ORDER, CASE WHEN LINE_STEP = @LASTSTEP THEN 'A' ELSE 'R' END AS LINE_TYPE, 'N' AS DEFAULT_YN
                FROM    COM_APPROVAL_LINE
                WHERE   LINE_TYPE   = @BIZ_TYPE
                    AND EMP_REF_ID  = @EMP_REF_ID
                UNION ALL
                SELECT  EMP_REF_ID, SORT_ORDER, 'R' as LINE_TYPE, 'Y' AS DEFAULT_YN
                FROM    COM_APPROVAL_LINE_BASE
                WHERE   BIZ_TYPE    = @BIZ_TYPE
                    AND EMP_REF_ID NOT IN (@EMP_REF_ID)
                UNION ALL
                SELECT  @EMP_REF_ID, -1 as SORT_ORDER, 'D' as LINE_TYPE, 'Y' AS DEFAULT_YN
            ) TA    ON CE.EMP_REF_ID = TA.EMP_REF_ID
INNER JOIN COM_EMP_INFO EI  ON CE.EMP_REF_ID = EI.EMP_REF_ID
LEFT JOIN EST_POSITION_RNK EP   ON EI.POSITION_RANK_CODE = EP.POS_RNK_ID
ORDER BY TA.SORT_ORDER DESC
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "COM_APPROVAL_FULLLINE", null, paramArray, CommandType.Text).Tables[0];

        }


        public DataTable GetPlusCountOfFullAppLine(object biz_type)
        {
            string strQuery = @"
SELECT ISNULL(MAX(SORT_ORDER), 0) AS PLUS_COUNT
FROM COM_APPROVAL_LINE_BASE
WHERE BIZ_TYPE   = @BIZ_TYPE

";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;

            return DbAgentObj.FillDataSet(strQuery, "COM_APPROVAL_FULLLINE", null, paramArray, CommandType.Text).Tables[0];

        }


        public DataTable GetLastStepOfFullAppLine(object biz_type, object emp_ref_id)
        {
            string strQuery = @"

SELECT ISNULL(MAX(LINE_STEP), 0) AS LAST_STEP
FROM    COM_APPROVAL_LINE
WHERE   LINE_TYPE   = @BIZ_TYPE
    AND EMP_REF_ID  = @EMP_REF_ID

";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "COM_APPROVAL_FULLLINE", null, paramArray, CommandType.Text).Tables[0];

        }


        public DataTable GetFullAppLine(object plus_count
                                      , object last_step
                                      , object biz_type
                                      , object emp_ref_id)
        {
            string sqlQuery = @"

SELECT   CE.COM_DEPT_REF_ID
        ,CE.EMP_REF_ID
        ,CE.COM_DEPT_NAME as DEPT_NAME
        ,CE.EMP_NAME
        ,ISNULL(EP.POS_RNK_NAME,' ') as POSITION_RANK_NAME
        ,TA.LINE_TYPE
        ,TA.SORT_ORDER
        ,TA.DEFAULT_YN
FROM viw_EMP_COMDEPT CE
INNER JOIN  (
                SELECT  APP_EMP_REF_ID AS EMP_REF_ID, LINE_STEP + @PLUSCOUNT AS SORT_ORDER, CASE WHEN LINE_STEP = @LASTSTEP THEN 'A' ELSE 'R' END AS LINE_TYPE, 'N' AS DEFAULT_YN
                FROM    COM_APPROVAL_LINE
                WHERE   LINE_TYPE   = @BIZ_TYPE
                    AND EMP_REF_ID  = @EMP_REF_ID
                UNION ALL
                SELECT  EMP_REF_ID, SORT_ORDER, 'R' as LINE_TYPE, 'Y' AS DEFAULT_YN
                FROM    COM_APPROVAL_LINE_BASE
                WHERE   BIZ_TYPE    = @BIZ_TYPE
                    AND EMP_REF_ID NOT IN (@EMP_REF_ID)
                UNION ALL
                SELECT  @EMP_REF_ID, -1 as SORT_ORDER, 'D' as LINE_TYPE, 'Y' AS DEFAULT_YN
            ) TA    ON CE.EMP_REF_ID = TA.EMP_REF_ID
INNER JOIN COM_EMP_INFO EI  ON CE.EMP_REF_ID = EI.EMP_REF_ID
LEFT JOIN EST_POSITION_RNK EP   ON EI.POSITION_RANK_CODE = EP.POS_RNK_ID
ORDER BY TA.SORT_ORDER DESC
";

            string orclQuery = @"
SELECT   CE.COM_DEPT_REF_ID
        ,CE.EMP_REF_ID
        ,CE.COM_DEPT_NAME as DEPT_NAME
        ,CE.EMP_NAME
        ,ISNULL(EP.POS_RNK_NAME,' ') as POSITION_RANK_NAME
        ,TA.LINE_TYPE
        ,TA.SORT_ORDER
        ,TA.DEFAULT_YN
FROM viw_EMP_COMDEPT CE
INNER JOIN  (


SELECT  APP_EMP_REF_ID AS EMP_REF_ID
      , LINE_STEP +@PLUSCOUNT AS SORT_ORDER
      , CASE WHEN LINE_STEP = @LASTSTEP THEN 'A' ELSE 'R' END AS LINE_TYPE
      , 'N' AS DEFAULT_YN
  FROM COM_APPROVAL_LINE
 WHERE LINE_TYPE   = @BIZ_TYPE
   AND EMP_REF_ID  = @EMP_REF_ID
                
                UNION ALL
                
SELECT  EMP_REF_ID
      , SORT_ORDER
      , 'R' as LINE_TYPE
      , 'Y' AS DEFAULT_YN
FROM   COM_APPROVAL_LINE_BASE
WHERE   BIZ_TYPE    = @BIZ_TYPE
  AND EMP_REF_ID NOT IN (@EMP_REF_ID)
    
                UNION ALL
                
SELECT  @EMP_REF_ID, -1 as SORT_ORDER, 'D' as LINE_TYPE, 'Y' AS DEFAULT_YN FROM DUAL

) TA    ON CE.EMP_REF_ID = TA.EMP_REF_ID
INNER JOIN COM_EMP_INFO EI  ON CE.EMP_REF_ID = EI.EMP_REF_ID
LEFT JOIN EST_POSITION_RNK EP   ON EI.POSITION_RANK_CODE = EP.POS_RNK_ID
ORDER BY TA.SORT_ORDER DESC

";

            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@BIZ_TYPE", SqlDbType.VarChar);
            paramArray[0].Value = biz_type;
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value = emp_ref_id;
            paramArray[2] = CreateDataParameter("@PLUSCOUNT", SqlDbType.Int);
            paramArray[2].Value = plus_count;
            paramArray[3] = CreateDataParameter("@LASTSTEP", SqlDbType.Int);
            paramArray[3].Value = last_step;

            return DbAgentObj.FillDataSet(GetQueryStringByDb(sqlQuery, orclQuery), "COM_APPROVAL_FULLLINE", null, paramArray, CommandType.Text).Tables[0];

        }


        public DataSet GetAllList(string ibiz_type, string iapp_status)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
            paramArray[1]               = CreateDataParameter("@iBIZ_TYPE", SqlDbType.VarChar);
            paramArray[1].Value         = ibiz_type;
            paramArray[2]               = CreateDataParameter("@iAPP_STATUS", SqlDbType.VarChar);
            paramArray[2].Value         = iapp_status;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_APPROVAL_INFO", "PKG_COM_APPROVAL_INFO.PROC_SELECT_ALL"), "COM_APPROVAL_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

		#endregion
	}
}