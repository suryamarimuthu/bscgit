using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;


using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;

public partial class BSC_BSC0501M3 : AppPageBase
{
    #region 변수선언

    public string firstIYMD
    {
        get
        {
            if (ViewState["firstIYMD"] == null)
            {
                ViewState["firstIYMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["firstIYMD"];
        }
        set
        {
            ViewState["firstIYMD"] = value;
        }
    }
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "U");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public string iPopUpType
    {
        get
        {
            if (ViewState["POPUP_TYPE"] == null)
            {
                ViewState["POPUP_TYPE"] = GetRequest("POPUP_TYPE", "R");
            }

            return (string)ViewState["POPUP_TYPE"];
        }
        set
        {
            ViewState["POPUP_TYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
                hdnEstTermID.Value          = GetRequest("ESTTERM_REF_ID", "");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
                hdnKpiId.Value          = GetRequest("KPI_REF_ID", "");
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public int IGroupRefID
    {
        get
        {
            if (ViewState["GROUP_REF_ID"] == null)
            {
                ViewState["GROUP_REF_ID"] = GetRequestByInt("GROUP_REF_ID", 0);
                hdnKpiId.Value            = GetRequest("GROUP_REF_ID", "");
            }

            return (int)ViewState["GROUP_REF_ID"];
        }
        set
        {
            ViewState["GROUP_REF_ID"] = value;
        }
    }

    public int IEstLevel
    {
        get
        {
            if (ViewState["EST_LEVEL"] == null)
            {
                ViewState["EST_LEVEL"] = GetRequestByInt("EST_LEVEL", 0);
                hdnKpiId.Value         = GetRequest("EST_LEVEL", "");
            }

            return (int)ViewState["EST_LEVEL"];
        }
        set
        {
            ViewState["EST_LEVEL"] = value;
        }
    }

    public int IEstEmpID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = GetRequestByInt("EST_EMP_ID", 0);
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID", 0);
            }

            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"]    = GetRequest("YMD", "");
                hdnYMD.Value        = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string IYMD_NEXT
    {
        get
        {
            if (ViewState["YMD_NEXT"] == null)
            {
                ViewState["YMD_NEXT"] = GetRequest("YMD_NEXT", "-");
            }

            return (string)ViewState["YMD_NEXT"];
        }
        set
        {
            ViewState["YMD_NEXT"] = value;
        }
    }

    public string IChampionEmpYN
    {
        get
        {
            if (ViewState["CHAMPION_EMP_YN"] == null)
            {
                ViewState["CHAMPION_EMP_YN"] = GetRequest("CHAMPION_EMP_YN", "N");
            }

            return (string)ViewState["CHAMPION_EMP_YN"];
        }
        set
        {
            ViewState["CHAMPION_EMP_YN"] = value;
        }
    }

    public string IApprovalEmpYN
    {
        get
        {
            if (ViewState["APPROVAL_EMP_YN"] == null)
            {
                ViewState["APPROVAL_EMP_YN"] = GetRequest("APPROVAL_EMP_YN", "N");
            }

            return (string)ViewState["APPROVAL_EMP_YN"];
        }
        set
        {
            ViewState["APPROVAL_EMP_YN"] = value;
        }
    }

    public string ICheckStatus
    {
        get
        {
            if (ViewState["CHECKSTATUS"] == null)
            {
                ViewState["CHECKSTATUS"] = GetRequest("CHECKSTATUS", "N");
            }

            return (string)ViewState["CHECKSTATUS"];
        }
        set
        {
            ViewState["CHECKSTATUS"] = value;
        }
    }

    public string IConfirmStatus
    {
        get
        {
            if (ViewState["CONFIRMSTATUS"] == null)
            {
                ViewState["CONFIRMSTATUS"] = GetRequest("CONFIRMSTATUS", "N");
            }

            return (string)ViewState["CONFIRMSTATUS"];
        }
        set
        {
            ViewState["CONFIRMSTATUS"] = value;
        }
    }

    public string IYearlyClose_YN
    {
        get
        {
            if (ViewState["YEARLY_CLOSE_YN"] == null)
            {
                ViewState["YEARLY_CLOSE_YN"] = GetRequest("YEARLY_CLOSE_YN");
            }
            return (string)ViewState["YEARLY_CLOSE_YN"];
        }
        set
        {
            ViewState["YEARLY_CLOSE_YN"] = value;
        }
    }

    public string IMontylyClose_YN
    {
        get
        {
            if (ViewState["MONTHLY_CLOSE_YN"] == null)
            {
                ViewState["MONTHLY_CLOSE_YN"] = GetRequest("MONTHLY_CLOSE_YN","Y");
            }
            return (string)ViewState["MONTHLY_CLOSE_YN"];
        }
        set
        {
            ViewState["MONTHLY_CLOSE_YN"] = value;
        }
    }
    public string IRelease_YN
    {
        get
        {
            if (ViewState["RELEASE_YN"] == null)
            {
                ViewState["RELEASE_YN"] = GetRequest("RELEASE_YN", "N");
            }
            return (string)ViewState["RELEASE_YN"];
        }
        set
        {
            ViewState["RELEASE_YN"] = value;
        }
    }

    public string IisPassCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_CLOSE_DAY"] = GetRequest("IS_PASS_CLOSE_DAY");
            }
            return (string)ViewState["IS_PASS_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_CLOSE_DAY"] = value;
        }
    }

    public string IisPassPreCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_PRE_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_PRE_CLOSE_DAY"] = GetRequest("IS_PASS_PRE_CLOSE_DAY");
            }
            return (string)ViewState["IS_PASS_PRE_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_PRE_CLOSE_DAY"] = value;
        }
    }

    public string IisPassQLTCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_QLT_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_QLT_CLOSE_DAY"] = GetRequest("IS_PASS_QLT_CLOSE_DAY","N");
            }
            return (string)ViewState["IS_PASS_QLT_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_QLT_CLOSE_DAY"] = value;
        }
    }

    public string IisEstMonth
    {
        get
        {
            if (ViewState["IS_EST_MONTH"] == null)
            {
                ViewState["IS_EST_MONTH"] = GetRequest("IS_EST_MONTH","N");
            }
            return (string)ViewState["IS_EST_MONTH"];
        }
        set
        {
            ViewState["IS_EST_MONTH"] = value;
        }
    }

    public string IKpiGroupRefID
    {
        get
        {
            if (ViewState["KPI_GROUP_REF_ID"] == null)
            {
                ViewState["KPI_GROUP_REF_ID"] = GetRequest("KPI_GROUP_REF_ID");
            }

            return (string)ViewState["KPI_GROUP_REF_ID"];
        }
        set
        {
            ViewState["KPI_GROUP_REF_ID"] = value;
        }
    }

    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = GetRequest("IS_ADMIN", "N");
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    public string IResultInputType
    {
        get
        {
            if (ViewState["RESULT_INPUT_TYPE"] == null)
            {
                ViewState["RESULT_INPUT_TYPE"] = GetRequest("RESULT_INPUT_TYPE", "MAN");
            }

            return (string)ViewState["RESULT_INPUT_TYPE"];
        }
        set
        {
            ViewState["RESULT_INPUT_TYPE"] = value;
        }
    }

    public string IResultTsCalcType
    {
        get
        {
            if (ViewState["RESULT_TS_CALC_TYPE"] == null)
            {
                ViewState["RESULT_TS_CALC_TYPE"] = GetRequest("RESULT_TS_CALC_TYPE", "");
            }

            return (string)ViewState["RESULT_TS_CALC_TYPE"];
        }
        set
        {
            ViewState["RESULT_TS_CALC_TYPE"] = value;
        }
    }

    public string IEstStatus
    {
        get
        {
            if (ViewState["ESTSTATUS"] == null)
            {
                ViewState["ESTSTATUS"] = GetRequest("ESTSTATUS", "N");
            }

            return (string)ViewState["ESTSTATUS"];
        }
        set
        {
            ViewState["ESTSTATUS"] = value;
        }
    }

    public string IKpiExternalType
    {
        get
        {
            if (ViewState["KPI_EXTERNAL_TYPE"] == null)
            {
                ViewState["KPI_EXTERNAL_TYPE"] = GetRequest("KPI_EXTERNAL_TYPE", "");
            }

            return (string)ViewState["KPI_EXTERNAL_TYPE"];
        }
        set
        {
            ViewState["KPI_EXTERNAL_TYPE"] = value;
        }
    }

    /// <summary>
    /// 하위지표의 실적 결재완료 여부
    /// </summary>
    public string IisChildAppYn
    {
        get
        {
            if (ViewState["IS_CHILD_KPI_APP_YN"] == null)
            {
                ViewState["IS_CHILD_KPI_APP_YN"] = GetRequest("IS_CHILD_KPI_APP_YN", "N");
            }

            return (string)ViewState["IS_CHILD_KPI_APP_YN"];
        }
        set
        {
            ViewState["IS_CHILD_KPI_APP_YN"] = value;
        }
    }

    /// <summary>
    /// 관련프로젝트가 매핑되어있는지 여부
    /// </summary>
    public string IHaveInitive_YN
    {
        get
        {
            if (ViewState["HAVE_INITIATIVE_YN"] == null)
            {
                ViewState["HAVE_INITIATIVE_YN"] = GetRequest("HAVE_INITIATIVE_YN", "N");
            }
            return (string)ViewState["HAVE_INITIATIVE_YN"];
        }
        set
        {
            ViewState["HAVE_INITIATIVE_YN"] = value;
        }
    }

    protected bool IAPPROVAL_GATEWAY
    {
        get
        {
            if (ViewState["APPROVAL_GATEWAY"] == null)
                ViewState["APPROVAL_GATEWAY"] = false;
            return (bool)ViewState["APPROVAL_GATEWAY"];
        }
        set
        {
            ViewState["APPROVAL_GATEWAY"] = value;
        }
    }

    #region  =========== 결재관련 변수
    /// <summary>
    /// 결재상태
    /// </summary>
    public string IApp_Status
    {
        get
        {
            if (ViewState["APP_STATUS"] == null)
            {
                ViewState["APP_STATUS"] = GetRequest("APP_STATUS");
            }
            return (string)ViewState["APP_STATUS"];
        }
        set
        {
            ViewState["APP_STATUS"] = value;
        }
    }

    /// <summary>
    /// 결재 상태명
    /// </summary>
    public string IApp_Status_Name
    {
        get
        {
            if (ViewState["APP_STATUS_NAME"] == null)
            {
                ViewState["APP_STATUS_NAME"] = GetRequest("APP_STATUS_NAME");
            }
            return (string)ViewState["APP_STATUS_NAME"];
        }
        set
        {
            ViewState["APP_STATUS_NAME"] = value;
        }
    }
    /// <summary>
    /// 결재 Id
    /// </summary>
    public decimal IApp_Ref_Id
    {
        get
        {
            if (ViewState["APP_REF_ID"] == null)
            {
                ViewState["APP_REF_ID"] = (decimal)GetRequestByInt("APP_REF_ID", 0);
            }

            return (decimal)ViewState["APP_REF_ID"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }

    /// <summary>
    /// 상신자
    /// </summary>
    public int IDraftEmpID
    {
        get
        {
            if (ViewState["DRAFT_EMP_ID"] == null)
                return -1;

            return (int)ViewState["DRAFT_EMP_ID"];
        }
        set
        {
            ViewState["DRAFT_EMP_ID"] = value;
        }
    }

    public string IAPP_CCB
    {
        get
        {
            if (ViewState["APP_CCB"] == null)
            {
                ViewState["APP_CCB"] = linkBtnDraft.ClientID.Replace('_', '$');
            }

            return (string)ViewState["APP_CCB"];
        }
        set
        {
            ViewState["APP_CCB"] = value;
        }
    }

    public string IConfirm_Status
    {
        get
        {
            if (ViewState["CONFIRMSTATUS"] == null)
            {
                ViewState["CONFIRMSTATUS"] = GetRequest("CONFIRMSTATUS", "N");
            }

            return (string)ViewState["CONFIRMSTATUS"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }
    #endregion

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.iBtnInsert.Attributes.Add("onmouseover", "doCompute();");

        if (!IsPostBack)
        {
            DoInitControl();
            firstIYMD = GetRequest("YMD", "");
            DoBinding();
        }
        ltrScript.Text = "";

        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    #region 내부함수
    private void DoBinding()
    {

        //KPI기본정보조회(SetKpiInfoData)
        Biz_Bsc_Kpi_Info objKPI = new Biz_Bsc_Kpi_Info();

        DataSet dsKPI = objKPI.GetKpiForMboResult(this.IEstTermRefID, this.IKpiRefID, gUserInfo.Emp_Ref_ID, IYMD);
        if (dsKPI.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dsKPI.Tables[0].Rows[0];
            this.IDraftEmpID                = DataTypeUtility.GetToInt32(dr["CHAMPION_EMP_ID"]);
            lblRESULT_ACHIEVEMENT_TYPE.Text = dr["RESULT_ACHIEVEMENT_TYPE_NAME"].ToString();
            lblRESULT_TS_CALC_TYPE.Text     = dr["RESULT_TS_CALC_TYPE_NAME"].ToString();
            lblCATEGORY_NAME.Text           = dr["CATEGORY_NAME"].ToString();
            lblKPICode.Text                 = dr["KPI_CODE"].ToString();
            lblKPIName.Text                 = dr["KPI_NAME"].ToString();
            lblUnitName.Text                = dr["UNIT_NAME"].ToString();
            IResultTsCalcType               = dr["RESULT_TS_CALC_TYPE"].ToString();
            txtTSResult.ReadOnly            = (dr["RESULT_TS_CALC_TYPE"].ToString() == "SUM" || dr["RESULT_TS_CALC_TYPE"].ToString() == "AVG" ? true : false);
            txtTSResult.BackColor           = (dr["RESULT_TS_CALC_TYPE"].ToString() == "SUM" || dr["RESULT_TS_CALC_TYPE"].ToString() == "AVG" ? Color.WhiteSmoke : Color.White);
            txtMSResult.ReadOnly            = (dr["RESULT_TS_CALC_TYPE"].ToString() == "OTS" ? true : false);
            txtMSResult.BackColor           = (dr["RESULT_TS_CALC_TYPE"].ToString() == "OTS" ? Color.WhiteSmoke : Color.White);
            this.IKpiPoolRefID              = DataTypeUtility.GetToInt32(dr["KPI_POOL_REF_ID"]);
            this.IResultInputType           = dr["RESULT_INPUT_TYPE"].ToString();


            this.IConfirm_Status           = dr["CONFIRMSTATUS"].ToString();

        }

        

        if (dsKPI.Tables[1].Rows.Count > 0)
        {
            
            DataRow dr = dsKPI.Tables[1].Rows[0];
            this.IChampionEmpYN     = dr["CHAMPION_EMP_YN"].ToString();
            this.IYearlyClose_YN    = dr["YEARLY_CLOSE_YN"].ToString();
            this.IisPassPreCloseDay = dr["IS_PASS_PRE_CLOSE_DAY"].ToString();
            this.IisPassCloseDay    = dr["IS_PASS_CLOSE_DAY"].ToString();
            this.IisPassQLTCloseDay = dr["IS_PASS_QLT_CLOSE_DAY"].ToString();
            this.IHaveInitive_YN    = dr["HAVE_INITIATIVE_YN"].ToString();

        }

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail(this.IEstTermRefID, this.IYMD);
        this.IMontylyClose_YN = objTerm.Iclose_yn;
        this.IRelease_YN = objTerm.Irelease_yn;

        Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        this.IKpiGroupRefID = objPool.Ikpi_type;
        this.IKpiExternalType = objPool.Ikpi_external_type;

        Biz_Bsc_Kpi_Term objChk = new Biz_Bsc_Kpi_Term(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        this.IisEstMonth = objChk.Icheck_yn;

        //실적조회
        SetResultData();

        //계획실적 그리드 
        SetResultGrid();

        SetDraftInfo();
        SetButton();
        SetInitiativeList();

        ugrdKpiResultTab.Tabs.FromKey("2").Visible = (this.IHaveInitive_YN == "N") ? true : false;
    }

    //계획실적 그리드 
    private void SetResultGrid()
    {
        Biz_Bsc_Kpi_Result objResult = new Biz_Bsc_Kpi_Result();
        DataSet ds = objResult.GetResultListPerMonth(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        ugrdResult.Clear();
        ugrdResult.DataSource = ds;
        ugrdResult.DataBind();
    }

    //실적조회(SetResultData)
    private void SetResultData()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        lblMM_MS.Text = objBSC.Iymd;
        txtMSResult.Text = objBSC.Iresult_ms.ToString();
        txtTSResult.Text = objBSC.Iresult_ts.ToString();
        txtCAUSE_TEXT_MS.Text = objBSC.Icause_text_ms;
        txtCAUSE_TEXT_TS.Text = objBSC.Icause_text_ts;
        txtMEASURE_TEXT_MS.Text = objBSC.Imeasure_text_ms;
        txtMEASURE_TEXT_TS.Text = objBSC.Imeasure_text_ts;
        hdfCauseDocNo.Value = objBSC.Icause_file_id;
        hdfMeasureDocNo.Value = objBSC.Imeasure_file_id;

        imgHdfCauseDocNo.Visible = (hdfCauseDocNo.Value == "") ? false : true;
        imgHdfMeasureDocNo.Visible = (hdfMeasureDocNo.Value == "") ? false : true;

        this.ICheckStatus = objBSC.Icheckstatus;
        this.IConfirmStatus = (objBSC.Iapp_status == Biz_Type.app_status_complete) ? "Y" : "N";
        this.IApp_Ref_Id = objBSC.Iapp_ref_id;
        this.IisChildAppYn = (objBSC.GetKpiChildAppStatus(this.IEstTermRefID, this.IKpiRefID, this.IYMD)) ? "Y" : "N";
    }

    private void DoInitControl()
    {
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetKpiQualityEstimateGrade(ddlScoreGrade, 0, false, 10);
        ugrdKpiResultTab.SelectedTabIndex = 0;

        this.IisAdmin = (User.IsInRole(ROLE_ADMIN) ? "Y" : "N");

        // 외부 결재정보를 취득하고 없으면 기존의 결재를 사용한다.
        string approvalGateway = System.Configuration.ConfigurationManager.AppSettings.Get("APPROVALGATEWAY");
        if (approvalGateway == null || "".Equals(approvalGateway))
            IAPPROVAL_GATEWAY = false;
        else
            IAPPROVAL_GATEWAY = true;
    }

    //===================================: 상태별/권한별 버튼설정
    private void SetButton()
    {

        // 어드민에게만 실적일괄변경 권한부여(조건: 현재평가월 이하만 수정)
        iBtnPastTotal.Visible = false;
        //if (User.IsInRole(ROLE_ADMIN))
        //{
        //    iBtnPastTotal.Visible = true;
        //}

        if (this.iPopUpType == "E")
        {
            iBtnInsert.Visible           = false;
            iBtnConfirm.Visible          = false;
            iBtnCancel.Visible           = false;

            iBtnDraft.Visible      = false;
            iBtnMoDraft.Visible    = false;
            iBtnReDraft.Visible    = false;
            iBtnReqModify.Visible  = false;
            iBtnReWrite.Visible    = false;
        }
        else
        { 
            if (this.IChampionEmpYN == "Y" && this.IisEstMonth == "Y")  // 챔피언이고 측정월이면
            {
                if (this.ICheckStatus=="N")
                {
                    iBtnInsert.Visible           = false;
                    iBtnConfirm.Visible          = false;
                    iBtnCancel.Visible           = false;
                }
                else
                { 
                    iBtnInsert.Visible           = false;
                    iBtnConfirm.Visible          = false;
                    iBtnCancel.Visible           = false;
                }
            }
            else
            {
                    iBtnInsert.Visible           = false;
                    iBtnConfirm.Visible          = false;
                    iBtnCancel.Visible           = false;
            }

            if (this.IChampionEmpYN   == "Y" &&    //챔피언이고
                this.ICheckStatus     == "Y" &&    //저장을 했으며
                this.IMontylyClose_YN == "N" &&    //월마감이 안되었고
                this.IYearlyClose_YN  == "N" &&    //년마감이 안되었고
                this.IisPassCloseDay  == "N" &&    //월마감일이 안지났으면
                this.IisPassPreCloseDay == "N" &&  //월예비마감일이 안지났으면
                this.IisEstMonth      == "Y")      //측정주기이면
            {
                switch (this.IApp_Status)
                {
                    case "": // 결재상태 없음
                        iBtnInsert.Visible  = true;
                        iBtnDraft.Visible   = (this.IisChildAppYn == "Y") ? true : false;
                        iBtnMoDraft.Visible = iBtnReDraft.Visible   = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
                        break;
                    case Biz_Type.app_status_nodraft: // 미상신
                        iBtnInsert.Visible  = true;
                        iBtnDraft.Visible   = (this.IisChildAppYn == "Y") ? true : false;
                        iBtnMoDraft.Visible = iBtnReDraft.Visible   = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
                        break;
                    case Biz_Type.app_status_draft: // 상신
                        iBtnInsert.Visible  = iBtnDraft.Visible     = iBtnMoDraft.Visible   = iBtnReDraft.Visible = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
                        break;
                    case Biz_Type.app_status_ondraft: // 결재중
                        iBtnInsert.Visible  = iBtnDraft.Visible     = iBtnMoDraft.Visible   = iBtnReDraft.Visible = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
                        break;
                    case Biz_Type.app_status_return: // 반려
                        iBtnInsert.Visible      = true;
                        iBtnDraft.Visible       = iBtnMoDraft.Visible          = false;
                        iBtnReDraft.Visible     = (this.IisChildAppYn == "Y") ? true : false;
                        iBtnReqModify.Visible   = iBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_recall: // 결재회수
                        iBtnInsert.Visible      = true;
                        iBtnDraft.Visible       = iBtnMoDraft.Visible   = iBtnReDraft.Visible   = iBtnReqModify.Visible = false;
                        iBtnReWrite.Visible     = (this.IisChildAppYn == "Y") ? true : false;
                        break;
                    case Biz_Type.app_status_onmodify: // 수정결재
                        iBtnInsert.Visible      = true;
                        iBtnDraft.Visible       = false;
                        iBtnMoDraft.Visible     = (this.IisChildAppYn == "Y") ? true : false;
                        iBtnReDraft.Visible     = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
                        break;
                    case Biz_Type.app_status_complete: // 결재완료
                        iBtnInsert.Visible      = iBtnDraft.Visible = iBtnMoDraft.Visible   = iBtnReDraft.Visible   = false;
                        iBtnReqModify.Visible   = true;
                        iBtnReWrite.Visible     = false;
                        break;
                    default:
                        iBtnInsert.Visible      = iBtnDraft.Visible = iBtnMoDraft.Visible   = iBtnReDraft.Visible   = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
                        break;
                 }
            }
            else
            {
                iBtnInsert.Visible  = iBtnDraft.Visible = iBtnMoDraft.Visible   = iBtnReDraft.Visible   = iBtnReqModify.Visible = iBtnReWrite.Visible   = false;
            }

            // 챔피언이고 저장을 하지 않았으면
            if (this.IChampionEmpYN == "Y" && this.ICheckStatus == "N") 
            {
                iBtnInsert.Visible = true;
            }

            // 어드민 권한처리
            if ((this.IApp_Status == "" ||
                 this.IApp_Status == Biz_Type.app_status_nodraft ||
                 this.IApp_Status == Biz_Type.app_status_return ||
                 this.IApp_Status == Biz_Type.app_status_recall ||
                 this.IApp_Status == Biz_Type.app_status_onmodify) && (User.IsInRole(ROLE_ADMIN)))
            {
                iBtnInsert.Visible = true;
            }

        }
    }

    /// <summary>
    /// KPI실적정보 입력/수정
    /// </summary>
    /// <returns></returns>
    private bool TxrResultForm()
    {
        double TSResult = DataTypeUtility.GetToDouble(txtTSResult.Text);

        if (this.IResultTsCalcType == "SUM" 
            || this.IResultTsCalcType == "AVG")
        {
            TSResult = DataTypeUtility.GetToDouble(hdfTSResult.Value);
        }

        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        objBSC.Iresult_ms        = DataTypeUtility.GetToDouble(txtMSResult.Text);
        //objBSC.Iresult_ts        = DataTypeUtility.GetToDouble(txtTSResult.Text);
        objBSC.Iresult_ts        = TSResult;
        //objBSC.Iresult_ts        = DataTypeUtility.GetToDouble(hdfResultTS.Value);
        objBSC.Icause_text_ms    = txtCAUSE_TEXT_MS.Text;
        objBSC.Icause_text_ts    = txtCAUSE_TEXT_TS.Text;
        objBSC.Icause_file_id    = hdfCauseDocNo.Value;
        objBSC.Imeasure_text_ms  = txtMEASURE_TEXT_MS.Text;
        objBSC.Imeasure_text_ts  = txtMEASURE_TEXT_TS.Text;
        objBSC.Imeasure_file_id  = hdfMeasureDocNo.Value;
        objBSC.Iremark           = "";
        objBSC.Isequence         = 0;
        objBSC.Itxr_user         = gUserInfo.Emp_Ref_ID;

        int intRnt = 0;
        if (this.IType == "A" || this.IType == "U") //입력/수정
        {
            //DataTable dtKpiResult = new DataTable();

            //dtKpiResult.Columns.Add("ESTTERM_REF_ID");
            //dtKpiResult.Columns.Add("KPI_REF_ID");
            //dtKpiResult.Columns.Add("YMD");
            //dtKpiResult.Columns.Add("RESULT_MS");
            //dtKpiResult.Columns.Add("RESULT_TS");
            //dtKpiResult.Columns.Add("SEQUENCE");
            //dtKpiResult.Columns.Add("CAL_RESULT_MS");
            //dtKpiResult.Columns.Add("CAL_RESULT_TS");
            //dtKpiResult.Columns.Add("CAL_APPLY_YN");
            //dtKpiResult.Columns.Add("CAL_APPLY_REASON");
            //dtKpiResult.Columns.Add("CAUSE_TEXT_MS");
            //dtKpiResult.Columns.Add("CAUSE_TEXT_TS");
            //dtKpiResult.Columns.Add("CAUSE_FILE_ID");
            //dtKpiResult.Columns.Add("MEASURE_TEXT_MS");
            //dtKpiResult.Columns.Add("MEASURE_TEXT_TS");
            //dtKpiResult.Columns.Add("MEASURE_FILE_ID");
            //dtKpiResult.Columns.Add("REMARK");
            //dtKpiResult.Columns.Add("CREATE_USER");
            //dtKpiResult.Columns.Add("INITIATIVE_DO");
            //dtKpiResult.Columns.Add("INITIATIVE_DOCNO");

            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result();

            DataTable dtBscKpiResult = bizBscKpiResult.SelectKpiResult_DB(this.IEstTermRefID
                                                         , this.IKpiRefID
                                                         , this.IYMD).Tables[0];

            if (dtBscKpiResult.Rows.Count > 0)
            {
                this.IType = "U";
            }
            else
            {
                this.IType = "A";
            }

            string msg = string.Empty;

            if (this.IType == "A")
            {
                msg = bizBscKpiResult.AddKpiResult_DB(this.IEstTermRefID
                                                         , this.IKpiRefID
                                                         , this.IYMD
                                                         , objBSC.Iresult_ms
                                                         , objBSC.Iresult_ts
                                                         , objBSC.Isequence
                                                         , objBSC.Ical_result_ms
                                                         , objBSC.Ical_result_ts
                                                         , objBSC.Ical_apply_yn
                                                         , objBSC.Ical_apply_reason
                                                         , objBSC.Icause_text_ms
                                                         , objBSC.Icause_text_ts
                                                         , objBSC.Icause_file_id
                                                         , objBSC.Imeasure_text_ms
                                                         , objBSC.Imeasure_text_ts
                                                         , objBSC.Imeasure_file_id
                                                         , objBSC.Iremark
                                                         , txtINITIATIVE_DO.Text
                                                         , hdfInitiativeDocNo.Value
                                                         , DateTime.Now.Date
                                                         , objBSC.Itxr_user);
            }
            else
            {
                msg = bizBscKpiResult.ModifyKpiResult_DB(this.IEstTermRefID
                                                         , this.IKpiRefID
                                                         , this.IYMD
                                                         , objBSC.Iresult_ms
                                                         , objBSC.Iresult_ts
                                                         , objBSC.Isequence
                                                         , objBSC.Ical_result_ms
                                                         , objBSC.Ical_result_ts
                                                         , objBSC.Ical_apply_yn
                                                         , objBSC.Ical_apply_reason
                                                         , objBSC.Icause_text_ms
                                                         , objBSC.Icause_text_ts
                                                         , objBSC.Icause_file_id
                                                         , objBSC.Imeasure_text_ms
                                                         , objBSC.Imeasure_text_ts
                                                         , objBSC.Imeasure_file_id
                                                         , objBSC.Iremark
                                                         , txtINITIATIVE_DO.Text
                                                         , hdfInitiativeDocNo.Value
                                                         , DateTime.Now.Date
                                                         , objBSC.Itxr_user);
            }

            return msg.Equals(string.Empty) ? true : false;
            //intRnt = objBSC.InsertData
            //                 (this.IEstTermRefID
            //                 , this.IKpiRefID
            //                 , this.IYMD
            //                 , objBSC.Iresult_ms
            //                 , objBSC.Iresult_ts
            //                 , objBSC.Isequence
            //                 , objBSC.Ical_result_ms
            //                 , objBSC.Ical_result_ts
            //                 , objBSC.Ical_apply_yn
            //                 , objBSC.Ical_apply_reason
            //                 , objBSC.Icause_text_ms
            //                 , objBSC.Icause_text_ts
            //                 , objBSC.Icause_file_id
            //                 , objBSC.Imeasure_text_ms
            //                 , objBSC.Imeasure_text_ts
            //                 , objBSC.Imeasure_file_id
            //                 , objBSC.Iremark
            //                 , objBSC.Itxr_user);
            //ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

            //if (objBSC.Transaction_Result == "Y")
            //{
            //    Biz_Bsc_Kpi_Initiative objIni = new Biz_Bsc_Kpi_Initiative();
            //    intRnt = objIni.InsertInitiativeDo
            //                            (this.IEstTermRefID
            //                            , this.IKpiRefID
            //                            , this.IYMD
            //                            , txtINITIATIVE_DO.Text
            //                            , hdfInitiativeDocNo.Value
            //                            , objBSC.Itxr_user);
            //    ltrScript.Text = JSHelper.GetAlertScript(objIni.Transaction_Message, false);
            //}

            //return (objBSC.Transaction_Result == "Y") ? true : false;
        }
        else if (this.IType == "D") //삭제
        {
            objBSC.DeleteData( this.IEstTermRefID
                             , this.IKpiRefID
                             , this.IYMD
                             , gUserInfo.Emp_Ref_ID);
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            return (objBSC.Transaction_Result == "Y") ? true : false;
        }
        else if (this.IType == "RF") //실적확정
        {
            objBSC.Result_Confirm(this.IEstTermRefID
                                , this.IKpiRefID
                                , this.IYMD
                                , gUserInfo.Emp_Ref_ID);
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            return (objBSC.Transaction_Result == "Y") ? true : false;
        }
        else if (this.IType == "RC") //실적취소
        {
            objBSC.Result_Cancel( this.IEstTermRefID
                                , this.IKpiRefID
                                , this.IYMD
                                , gUserInfo.Emp_Ref_ID);
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            return (objBSC.Transaction_Result == "Y") ? true : false;
        }

        return false;
    }

    /// <summary>
    /// Initiative 조회
    /// </summary>
    private void SetInitiativeList()
    {
        Biz_Bsc_Kpi_Initiative objBSC = new Biz_Bsc_Kpi_Initiative(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        txtINITIATIVE_DO.Text      = objBSC.Iinitiative_do;
        txtINITIATIVE_PLAN.Text    = objBSC.Iinitiative_plan;
        hdfInitiativeDocNo.Value    = objBSC.Ido_file;
        imgHdfInitiativeDocNo.Visible = (hdfInitiativeDocNo.Value == "") ? false : true;
        txtINITIATIVE_PLAN.ReadOnly = true;
    }

    #region ================================= [ 결재처리 ]===================================
    /// <summary>
    /// 결재상태조회
    /// </summary>
    private void SetDraftInfo()
    {
        Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info(this.IApp_Ref_Id);
        this.IApp_Status      = objApp.IApp_Status;
        this.IApp_Status_Name = objApp.IApp_Status_Name;

        iBtnPastTotal.OnClientClick = "return openBatchSave();";
        iBtnDraft.OnClientClick     = "return OpenDraft('" + Biz_Type.app_draft_first +"');";
        iBtnReDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_redraft + "');";
        iBtnReWrite.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_rewrite + "');";
        iBtnMoDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_modify + "');";
        iBtnReqModify.OnClientClick = "return isMoDraftMsg();";
        iBtnPrint.OnClientClick     = "return OpenDraftPrint('" + Biz_Type.app_draft_select + "')";
    }

    /// <summary>
    /// 수정결재요청
    /// </summary>
    private void RequestModifyDraft()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();
        bool blnRtn = objApp.RequestModifyDraft(this.IApp_Ref_Id, gUserInfo.Emp_Ref_ID);
        if (blnRtn)
        {
            this.SetDraftInfo();
            this.SetButton();

            // 이승주 (2010-06-03)
            // 수정요청 뒤에 파일업로드가 불가능하여 활성화시키기 위해서 추가
            Response.Redirect(Request.Url.ToString());
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objApp.Transaction_Message, false);
        }
    }
    #endregion

    #endregion

    #region 이벤트처리함수
    protected void ugrdResult_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //ugrdResult.Height = 286;

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "년월";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[  당    월 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 누    적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "결재";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "Signal";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[7].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[8].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanY = 2;
    }

    protected void ugrdResult_InitializeRow(object sender, RowEventArgs e)
    {
        if (e.Row.Cells.FromKey("YMD").Value.ToString() == this.IYMD)
        {
            e.Row.Selected = true;
        }

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg        = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
        
        e.Row.Cells.FromKey("CHECKSTATUS").Text   = (e.Row.Cells.FromKey("CHECKSTATUS").Value.ToString().Equals("Y"))   ? "<img src='../images/icon_o.gif' />" : "<img src='../images/icon_x.gif' />";

        if(e.Row.Cells.FromKey("SIGNAL_MS").Value != null)
        e.Row.Cells.FromKey("SIGNAL_MS").Text = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_MS").Value.ToString() + "' />";

        if (e.Row.Cells.FromKey("SIGNAL_TS").Value != null)
        e.Row.Cells.FromKey("SIGNAL_TS").Text = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_TS").Value.ToString() + "' />";

        //e.Row.Cells.FromKey("SIGNAL_MS").Text     = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_MS").Value.ToString() + "' />";
        //e.Row.Cells.FromKey("SIGNAL_TS").Text     = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_TS").Value.ToString() + "' />";

        double dblRateMs = double.Parse(e.Row.Cells.FromKey("AC_RATE_MS").Value.ToString().Replace('-', '0'));
        double dblRateTs = double.Parse(e.Row.Cells.FromKey("AC_RATE_TS").Value.ToString().Replace('-', '0'));

        e.Row.Cells.FromKey("AC_RATE_MS").Value = dblRateMs.ToString("#,##0.00");
        e.Row.Cells.FromKey("AC_RATE_TS").Value = dblRateTs.ToString("#,##0.00");
    }

    protected void ugrdResult_DblClick(object sender, ClickEventArgs e)
    {
        this.IYMD = (e.Row.Cells.FromKey("YMD").Value == null) ? this.IYMD : e.Row.Cells.FromKey("YMD").Value.ToString();
        //this.SetResultGrid();
        this.SetResultData();
        this.SetButton();
    }

    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "U";
        if (this.TxrResultForm())
        {
            this.SetResultData();
            this.SetResultGrid();
            this.SetInitiativeList();
            this.SetButton();
        }
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "RF";
        if (!this.TxrResultForm())
        {
            this.IType = "U";
        }
        else
        {
            this.SetResultData();
            this.SetResultGrid();
            this.SetButton();
        }
    }

    protected void iBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "RC";
        if (!this.TxrResultForm())
        {
            this.IType = "U";
        }
        else
        {
            this.SetResultData();
            this.SetResultGrid();
            this.SetButton();
        }
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (GetRequest("closeRefresh", "") == "F")
            ltrScript.Text = JSHelper.GetCloseScript();
        else
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    protected void linkBtnDraft_Click(object sender, EventArgs e)
    {
        this.SetResultData();
        this.SetDraftInfo();
        this.SetButton();
    }

    protected void lnkRefresh_Click(object sender, EventArgs e)
    {
        string tmpYMD = this.IYMD;
        this.IYMD = firstIYMD;
        this.SetResultData();
        this.SetResultGrid();
        this.SetButton();
        this.IYMD = tmpYMD;
    }

    protected void ugrdChildKpiResult_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "KPI 코드";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "KPI명";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "L";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "가중치";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "운영조직";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "챔피언";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "단위";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = true;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적방식";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = true;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "결재상태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = true;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 당 월 실 적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 12;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = false;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 누 적 실 적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 21;
        ch.RowLayoutColumnInfo.SpanX = 12;
        ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = false;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i < 9)
            {
                ch = e.Layout.Bands[0].Columns[i].Header;
                ch.RowLayoutColumnInfo.OriginY = 0;
                ch.RowLayoutColumnInfo.OriginX = i;
                ch.RowLayoutColumnInfo.SpanY   = 2;
                e.Layout.Bands[0].Columns[i].Header.Style.BackColor = ColorTranslator.FromHtml("#94BAC9");
                e.Layout.Bands[0].Columns[i].Header.Style.ForeColor = Color.White;
                e.Layout.Bands[0].Columns[i].Header.Fixed = true;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Header.Fixed = false;
            }
        }
    }

    protected void ugrdChildKpiResult_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg        = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
    }

    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }
    #endregion

}
