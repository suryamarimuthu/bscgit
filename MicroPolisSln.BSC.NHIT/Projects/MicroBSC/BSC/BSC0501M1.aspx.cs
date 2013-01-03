using System;
using System.Data;
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
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;

public partial class BSC_BSC0501M1 : AppPageBase
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


    /* 2011-03-02 수정 : 외부결재 세팅이 있는 경우 */
    private bool externApprovlaProcess = false;

    public bool ExternalApproval
    {
        get
        {
            return externApprovlaProcess;
        }
    }
    /* 2011-03-02 완료 *****************************/

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
    /// 자식지표가 있는지 없는지 여부
    /// </summary>
    public string IHaveChildKpiYn
    {
        get
        {
            if (ViewState["HAVE_CHILD_KPI_YN"] == null)
            {
                ViewState["HAVE_CHILD_KPI_YN"] = GetRequest("HAVE_CHILD_KPI_YN", "N");
            }

            return (string)ViewState["HAVE_CHILD_KPI_YN"];
        }
        set
        {
            ViewState["HAVE_CHILD_KPI_YN"] = value;
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
    #endregion

    UltraWebGrid TugrdResult;
    UltraWebGrid TugrdEstLevel;
    UltraWebGrid TugrdQuestionList;
    UltraWebGrid TugrdChildKpiResult;
    UltraWebGrid TugrdExpectGrid;

    Label       TlblMM_MS;
    //Label       TlblMM_TS;

    CheckBox    TChkApplyItfsResult;
    TextBox     TtxtCAUSE_TEXT_MS;
    TextBox     TtxtCAUSE_TEXT_TS;
    TextBox     TtxtMEASURE_TEXT_MS;
    TextBox     TtxtMEASURE_TEXT_TS;
    TextBox     TtxtNotApplyReason;
    TextBox     TtxtEstOpinion;
    TextBox     TtxtINITIATIVE_PLAN;
    TextBox     TtxtINITIATIVE_DO;

    TextBox     TtxtEXPECT_REASON_MS;
    TextBox     TtxtEXPECT_REASON_TS;
    TextBox     TtxtRESULT_DIFF_CAUSE;

    ImageButton TiBtnPastTotal;
    ImageButton TiBtnInsert;
    ImageButton TiBtnConfirm;
    ImageButton TiBtnCancel;
    ImageButton TiBtnClose;
    ImageButton TiBtnSaveOpnion;
    ImageButton TiBtnInterfaceDataAdd;
    ImageButton TiBtnConfirmOpinion;
    ImageButton TiBtnCancelOpinion;

    ImageButton TiBtnDraft    ;
    ImageButton TiBtnReDraft  ;
    ImageButton TiBtnMoDraft  ;
    ImageButton TiBtnReqModify;
    ImageButton TiBtnReWrite;
    ImageButton TiBtnReviewFile;


    Literal     TltrEstBasis;
    Literal     TltrAppLegend;

    WebNumericEdit TtxtMSResult;
    WebNumericEdit TtxtMsCalcResult;
    WebNumericEdit TtxtTSResult;
    WebNumericEdit TtxtTsCalcResult;
    WebNumericEdit TtxtExtResult_MS;
    WebNumericEdit TtxtExtResult_TS;

    HiddenField ThdfReviewFile;

    #endregion

    #region 페이지 로딩 및 폼 초기화

    protected void Page_Load(object sender, EventArgs e)
    {
        TlblMM_MS             = this.ugrdKpiResultTab.FindControl("lblMM_MS")           as Label;
        //TlblMM_TS             = this.ugrdKpiResultTab.FindControl("lblMM_TS")           as Label;

        TChkApplyItfsResult   = this.ugrdKpiResultTab.FindControl("ChkApplyItfsResult") as CheckBox;

        TtxtCAUSE_TEXT_MS     = this.ugrdKpiResultTab.FindControl("txtCAUSE_TEXT_MS")   as TextBox;
        TtxtCAUSE_TEXT_TS     = this.ugrdKpiResultTab.FindControl("txtCAUSE_TEXT_TS")   as TextBox;
        TtxtMEASURE_TEXT_MS   = this.ugrdKpiResultTab.FindControl("txtMEASURE_TEXT_MS") as TextBox;
        TtxtMEASURE_TEXT_TS   = this.ugrdKpiResultTab.FindControl("txtMEASURE_TEXT_TS") as TextBox;
        TtxtNotApplyReason    = this.ugrdKpiResultTab.FindControl("txtNotApplyReason")  as TextBox;
        TtxtEstOpinion        = this.ugrdKpiResultTab.FindControl("txtEstOpinion")      as TextBox;

        TtxtINITIATIVE_PLAN   = this.ugrdKpiResultTab.FindControl("txtINITIATIVE_PLAN")  as TextBox;
        TtxtINITIATIVE_DO     = this.ugrdKpiResultTab.FindControl("txtINITIATIVE_DO")    as TextBox;
        TtxtEXPECT_REASON_MS  = this.ugrdKpiResultTab.FindControl("txtEXPECT_REASON_MS") as TextBox;
        TtxtEXPECT_REASON_TS  = this.ugrdKpiResultTab.FindControl("txtEXPECT_REASON_TS") as TextBox;
        TtxtRESULT_DIFF_CAUSE = this.ugrdKpiResultTab.FindControl("txtRESULT_DIFF_CAUSE") as TextBox;

        TiBtnPastTotal        = this.ugrdKpiResultTab.FindControl("iBtnPastTotal")      as ImageButton;
        TiBtnInsert           = this.ugrdKpiResultTab.FindControl("iBtnInsert")         as ImageButton;
        TiBtnConfirm          = this.ugrdKpiResultTab.FindControl("iBtnConfirm")        as ImageButton;
        TiBtnCancel           = this.ugrdKpiResultTab.FindControl("iBtnCancel")         as ImageButton;
        TiBtnClose            = this.ugrdKpiResultTab.FindControl("iBtnClose")          as ImageButton;
        TiBtnSaveOpnion       = this.ugrdKpiResultTab.FindControl("iBtnSaveOpnion")     as ImageButton;
        TiBtnInterfaceDataAdd = this.ugrdKpiResultTab.FindControl("iBtnInterfaceDataAdd") as ImageButton;
        TiBtnConfirmOpinion   = this.ugrdKpiResultTab.FindControl("iBtnConfirmOpinion")   as ImageButton;
        TiBtnCancelOpinion    = this.ugrdKpiResultTab.FindControl("iBtnCancelOpinion")    as ImageButton;

        TiBtnDraft            = this.ugrdKpiResultTab.FindControl("iBtnDraft")         as ImageButton;
        TiBtnReDraft          = this.ugrdKpiResultTab.FindControl("iBtnReDraft")       as ImageButton;
        TiBtnMoDraft          = this.ugrdKpiResultTab.FindControl("iBtnMoDraft")       as ImageButton;
        TiBtnReqModify        = this.ugrdKpiResultTab.FindControl("iBtnReqModify")     as ImageButton;
        TiBtnReWrite          = this.ugrdKpiResultTab.FindControl("iBtnReWrite")       as ImageButton;
        TiBtnReviewFile       = this.ugrdKpiResultTab.FindControl("iBtnReviewFile")    as ImageButton;
        

        TltrEstBasis          = this.ugrdKpiResultTab.FindControl("ltrEstBasis")        as Literal;
        TltrAppLegend         = this.ugrdKpiResultTab.FindControl("ltrAppLegend")       as Literal;

        TtxtMSResult          = this.ugrdKpiResultTab.FindControl("txtMSResult")        as WebNumericEdit;
        TtxtMsCalcResult      = this.ugrdKpiResultTab.FindControl("txtMsCalcResult")    as WebNumericEdit;
        TtxtTSResult          = this.ugrdKpiResultTab.FindControl("txtTSResult")        as WebNumericEdit;
        TtxtTsCalcResult      = this.ugrdKpiResultTab.FindControl("txtTsCalcResult")    as WebNumericEdit;
        TtxtExtResult_MS      = this.ugrdKpiResultTab.FindControl("txtExtResult_MS")    as WebNumericEdit;
        TtxtExtResult_TS      = this.ugrdKpiResultTab.FindControl("txtExtResult_TS")    as WebNumericEdit;


        TugrdResult           = this.ugrdKpiResultTab.FindControl("ugrdResult")         as UltraWebGrid;
        TugrdEstLevel         = this.ugrdKpiResultTab.FindControl("ugrdEstLevel")       as UltraWebGrid;
        TugrdQuestionList     = this.ugrdKpiResultTab.FindControl("ugrdQuestionList")   as UltraWebGrid;
        TugrdChildKpiResult   = this.ugrdKpiResultTab.FindControl("ugrdChildKpiResult") as UltraWebGrid;
        TugrdExpectGrid       = this.ugrdKpiResultTab.FindControl("ugrdExpectGrid")     as UltraWebGrid;

        ThdfReviewFile        = this.ugrdKpiResultTab.FindControl("hdfReviewFile")      as HiddenField;

        /* 2011-03-02 수정 : ApplicationSetting으로 부터 외부 결재정보를 취득하고 없으면 기존의 
         *                  결재를 사용한다.
         */
        String approvalGateway = System.Configuration.ConfigurationManager.AppSettings.Get("APPROVALGATEWAY");

        if (approvalGateway == null || "".Equals(approvalGateway))
        {
            externApprovlaProcess = false;
        }
        else
        {
            externApprovlaProcess = true;
        }
        /* 2011-03-02 완료 *************************************************************************/

        if (!IsPostBack)
        {
            InitControlValue();
            firstIYMD = GetRequest("YMD", "");
        }
        else
        {
            
        }

        ltrScript.Text = "";

        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    private void InitControlValue()
    {
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetKpiQualityEstimateGrade(ddlScoreGrade, 0, false, 10);
        ugrdKpiResultTab.SelectedTabIndex = 0;
        this.SetKpiInfoData();
        this.SetResultData();
        this.SetResultGrid();        
        this.SetDraftInfo();
        this.SetButton();
        this.SetEstQuestionListGrid();
        this.SetInitiativeList();
        this.SetExceptGrid();
        this.GetInterfaceData();

        if (this.IHaveChildKpiYn == "Y")
        {
            ugrdKpiResultTab.Tabs.FromKey("4").Visible = true;
            this.SetChildKpiGrid();
        }
        else
        {
            ugrdKpiResultTab.Tabs.FromKey("4").Visible = false;
        }

        ugrdKpiResultTab.Tabs.FromKey("2").Visible = (this.IHaveInitive_YN == "N") ? true : false;

        iBtnInterfaceDataAdd.Attributes.Add("onmousedown", "openInterfaceDataAdd()");
        this.IisAdmin = (User.IsInRole(ROLE_ADMIN) ? "Y" : "N");

        TiBtnReviewFile.OnClientClick = "return mfUpload_Review('" + hdfReviewFile.ClientID+ "')";
        TltrAppLegend.Text = Biz_Type.app_legend;
    }
    #endregion

    #region 내부함수
    //===================================: KPI기본정보 조회
    private void SetKpiInfoData()
    {
        int LogInUser = gUserInfo.Emp_Ref_ID;

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        this.IDraftEmpID                = objBSC.Ichampion_emp_id;
        lblRESULT_ACHIEVEMENT_TYPE.Text = objBSC.Iresult_achievement_type_name;
        if (objBSC.Iresult_achievement_type == "BTY")
        {
            ugrdResult.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_MS").Header.Caption = 
                ugrdResult.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_TS").Header.Caption = 
                ugrdExpectGrid.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_MS").Header.Caption = 
                ugrdExpectGrid.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_TS").Header.Caption = "한계초과율";
        }
        else
        {
            ugrdResult.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_MS").Header.Caption = 
                ugrdResult.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_TS").Header.Caption = 
                ugrdExpectGrid.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_MS").Header.Caption =
                ugrdExpectGrid.DisplayLayout.Bands[0].Columns.FromKey("AC_RATE_TS").Header.Caption = "달성율";
        }
        lblRESULT_INPUT_TYPE.Text       = objBSC.Iresult_input_type_name;
        lblRESULT_TS_CALC_TYPE.Text     = objBSC.Iresult_ts_calc_type_name;
        lblKPICode.Text                 = objBSC.Ikpi_code;
        lblKPIName.Text                 = objBSC.Ikpi_name;
        lblUnitName.Text                = objBSC.Iunit_name;
        this.IResultTsCalcType          = objBSC.Iresult_ts_calc_type;
        this.TtxtTSResult.ReadOnly      = (objBSC.Iresult_ts_calc_type == "SUM" || objBSC.Iresult_ts_calc_type == "AVG") ? true : false;
        this.TtxtTSResult.BackColor     = (objBSC.Iresult_ts_calc_type == "SUM" || objBSC.Iresult_ts_calc_type == "AVG") ? Color.WhiteSmoke : Color.White;
        this.TtxtMSResult.ReadOnly      = (objBSC.Iresult_ts_calc_type == "OTS") ? true : false;
        this.TtxtMSResult.BackColor     = (objBSC.Iresult_ts_calc_type == "OTS") ? Color.WhiteSmoke : Color.White;
        this.IKpiPoolRefID              = objBSC.Ikpi_pool_ref_id;
        this.IResultInputType           = objBSC.Iresult_input_type;

        DataSet rDs = objBSC.GetKpiStatus(this.IEstTermRefID, this.IKpiRefID, LogInUser);
        if (rDs.Tables[0].Rows.Count > 0)
        {
            this.IChampionEmpYN     = rDs.Tables[0].Rows[0]["CHAMPION_EMP_YN"].ToString();
            this.IApprovalEmpYN     = rDs.Tables[0].Rows[0]["APPROVAL_EMP_YN"].ToString();
            this.IYearlyClose_YN    = rDs.Tables[0].Rows[0]["YEARLY_CLOSE_YN"].ToString();
            this.IisPassPreCloseDay = rDs.Tables[0].Rows[0]["IS_PASS_PRE_CLOSE_DAY"].ToString();
            this.IisPassCloseDay    = rDs.Tables[0].Rows[0]["IS_PASS_CLOSE_DAY"].ToString();
            this.IisPassQLTCloseDay = rDs.Tables[0].Rows[0]["IS_PASS_QLT_CLOSE_DAY"].ToString();
            this.IHaveChildKpiYn    = rDs.Tables[0].Rows[0]["HAVE_CHILD_KPI_YN"].ToString();
            this.IHaveInitive_YN    = rDs.Tables[0].Rows[0]["HAVE_INITIATIVE_YN"].ToString();
        }

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail(this.IEstTermRefID, this.IYMD);
        this.IMontylyClose_YN       = objTerm.Iclose_yn;

        Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        TltrEstBasis.Text     = objPool.Ivaluation_basis;
        this.IKpiGroupRefID   = objPool.Ikpi_type;
        this.IKpiExternalType = objPool.Ikpi_external_type;

        Biz_Bsc_Kpi_Term objChk = new Biz_Bsc_Kpi_Term(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        this.IisEstMonth        = objChk.Icheck_yn;
    }

    //===================================: 상태별/권한별 버튼설정
    private void SetButton()
    {

        // 어드민에게만 실적일괄변경 권한부여(조건: 현재평가월 이하만 수정)
        TiBtnPastTotal.Visible = false;
        if (User.IsInRole(ROLE_ADMIN))
        {
            TiBtnPastTotal.Visible = true;
        }


        if (this.iPopUpType == "E")
        {
            ugrdKpiResultTab.Tabs.FromKey("3").Visible = true;
            TiBtnInsert.Visible           = false;
            TiBtnConfirm.Visible          = false;
            TiBtnCancel.Visible           = false;
            TiBtnInterfaceDataAdd.Visible = false;
            TiBtnSaveOpnion.Visible       = false;

            TiBtnDraft.Visible      = false;
            TiBtnMoDraft.Visible    = false;
            TiBtnReDraft.Visible    = false;
            TiBtnReqModify.Visible  = false;
            TiBtnReWrite.Visible    = false;
        }
        else
        { 
            ugrdKpiResultTab.Tabs.FromKey("3").Visible = false;
            TiBtnSaveOpnion.Visible = false;
            if (this.IChampionEmpYN == "Y" && this.IisEstMonth == "Y")  // 챔피언이고 측정월이면
            {
                if (this.ICheckStatus=="N")
                {
                    TiBtnInsert.Visible           = false;
                    TiBtnConfirm.Visible          = false;
                    TiBtnCancel.Visible           = false;
                    TiBtnInterfaceDataAdd.Visible = true;
                }
                else
                { 
                    TiBtnInsert.Visible           = false;
                    TiBtnConfirm.Visible          = false;
                    TiBtnCancel.Visible           = false;
                    TiBtnInterfaceDataAdd.Visible = true;
                }
            }
            else
            {
                    TiBtnInsert.Visible           = false;
                    TiBtnConfirm.Visible          = false;
                    TiBtnCancel.Visible           = false;
                    TiBtnInterfaceDataAdd.Visible = false;
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
                        TiBtnInsert.Visible           = true;
                        TiBtnInterfaceDataAdd.Visible = true;
                        TiBtnDraft.Visible            = (this.IisChildAppYn == "Y") ? true : false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_nodraft: // 미상신
                        TiBtnInsert.Visible           = true;
                        TiBtnInterfaceDataAdd.Visible = true;
                        TiBtnDraft.Visible            = (this.IisChildAppYn == "Y") ? true : false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_draft: // 상신
                        TiBtnInsert.Visible           = false;
                        TiBtnInterfaceDataAdd.Visible = false;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_ondraft: // 결재중
                        TiBtnInsert.Visible           = false;
                        TiBtnInterfaceDataAdd.Visible = false;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_return: // 반려
                        TiBtnInsert.Visible           = true;
                        TiBtnInterfaceDataAdd.Visible = true;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = (this.IisChildAppYn == "Y") ? true : false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_recall: // 결재회수
                        TiBtnInsert.Visible           = true;
                        TiBtnInterfaceDataAdd.Visible = true;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = (this.IisChildAppYn == "Y") ? true : false;
                        break;
                    case Biz_Type.app_status_onmodify: // 수정결재
                        TiBtnInsert.Visible           = true;
                        TiBtnInterfaceDataAdd.Visible = true;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = (this.IisChildAppYn == "Y") ? true : false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                    case Biz_Type.app_status_complete: // 결재완료
                        TiBtnInsert.Visible           = false;
                        TiBtnInterfaceDataAdd.Visible = false;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = true;
                        TiBtnReWrite.Visible          = false;
                        break;
                    default:
                        TiBtnInsert.Visible           = false;
                        TiBtnInterfaceDataAdd.Visible = false;
                        TiBtnDraft.Visible            = false;
                        TiBtnMoDraft.Visible          = false;
                        TiBtnReDraft.Visible          = false;
                        TiBtnReqModify.Visible        = false;
                        TiBtnReWrite.Visible          = false;
                        break;
                 }
            }
            else
            {
                TiBtnInsert.Visible           = false;
                TiBtnInterfaceDataAdd.Visible = false;
                TiBtnDraft.Visible            = false;
                TiBtnMoDraft.Visible          = false;
                TiBtnReDraft.Visible          = false;
                TiBtnReqModify.Visible        = false;
                TiBtnReWrite.Visible          = false;
            }

            // 챔피언이고 저장을 하지 않았으면
            if (this.IChampionEmpYN == "Y" && this.ICheckStatus == "N") 
            {
                TiBtnInsert.Visible = true;
            }

            // 어드민 권한처리
            if ((this.IApp_Status == "" ||
                 this.IApp_Status == Biz_Type.app_status_nodraft ||
                 this.IApp_Status == Biz_Type.app_status_return ||
                 this.IApp_Status == Biz_Type.app_status_recall ||
                 this.IApp_Status == Biz_Type.app_status_onmodify) && (User.IsInRole(ROLE_ADMIN)))
            {
                TiBtnInsert.Visible = true;
            }

        }

        if (IResultInputType.Equals("SYS"))
            TiBtnInterfaceDataAdd.Visible = true;
    }

    /// <summary>
    /// 기본 입출력 제한사항 체크
    /// </summary>
    /// <returns></returns>
    private bool ValidateForm()
    {
        if (this.IType == "A" || this.IType == "U")
        {
            //if (TtxtCAUSE_TEXT_MS.Text.Length < 1)
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("당월 원인분석 내용을 입력해 주십시오.", false);
            //    return false;
            //}
            //else if (TtxtCAUSE_TEXT_TS.Text.Length < 1)
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("누적 원인분석 내용을 입력해 주십시오.", false);
            //    return false;
            //}
            //else if (TtxtMEASURE_TEXT_MS.Text.Length < 1)
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("당월 대책검토 내용을 입력해 주십시오.", false);
            //    return false;
            //}
            //else if (TtxtMEASURE_TEXT_TS.Text.Length < 1)
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("누적 대책검토 내용을 입력해 주십시오.", false);
            //    return false;
            //}
            //else 
                
            //if (TtxtINITIATIVE_DO.Text.Length < 1)
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("Initiative실적 내용을 입력해 주십시오.", false);
            //    return false;
            //}

            if (this.IResultInputType == "SYS" && !TChkApplyItfsResult.Checked)
            {
                if (TtxtNotApplyReason.Text.Trim().Length < 1)
                {
                    ltrScript.Text = JSHelper.GetAlertScript("산식 미적용 사유를 입력해주십시오.", false);
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// KPI실적정보 조회
    /// </summary>
    private void SetResultData()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        TlblMM_MS.Text              = objBSC.Iymd;
        //TlblMM_TS.Text            = objBSC.Iymd;
        TtxtMSResult.Text           = objBSC.Iresult_ms.ToString();
        TtxtTSResult.Text           = objBSC.Iresult_ts.ToString();
        TtxtMsCalcResult.Text       = objBSC.Ical_result_ms.ToString();
        TtxtTsCalcResult.Text       = objBSC.Ical_result_ts.ToString();
        TtxtCAUSE_TEXT_MS.Text      = objBSC.Icause_text_ms;
        TtxtCAUSE_TEXT_TS.Text      = objBSC.Icause_text_ts;
        TtxtMEASURE_TEXT_MS.Text    = objBSC.Imeasure_text_ms;
        TtxtMEASURE_TEXT_TS.Text    = objBSC.Imeasure_text_ts;
        TChkApplyItfsResult.Checked = (objBSC.Ical_apply_yn == "Y") ? true : false;
        TtxtNotApplyReason.Text     = objBSC.Ical_apply_reason;
        hdfCauseDocNo.Value         = objBSC.Icause_file_id;
        hdfMeasureDocNo.Value       = objBSC.Imeasure_file_id;

        imgHdfCauseDocNo.Visible   = (hdfCauseDocNo.Value == "") ? false : true;
        imgHdfMeasureDocNo.Visible = (hdfMeasureDocNo.Value == "") ? false : true;

        this.ICheckStatus        = objBSC.Icheckstatus;
        this.IConfirmStatus      = (objBSC.Iapp_status==Biz_Type.app_status_complete) ? "Y" : "N";
        this.IApp_Ref_Id         = objBSC.Iapp_ref_id;
        this.IisChildAppYn       = (objBSC.GetKpiChildAppStatus(this.IEstTermRefID, this.IKpiRefID, this.IYMD)) ? "Y" : "N";
    }

    /// <summary>
    /// KPI실적정보 입력/수정
    /// </summary>
    /// <returns></returns>
    private bool TxrResultForm()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        objBSC.Iresult_ms        = double.Parse(TtxtMSResult.Text.ToString());
        objBSC.Iresult_ts        = double.Parse(TtxtTSResult.Text.ToString());
        objBSC.Ical_result_ms    = double.Parse(TtxtMsCalcResult.Text.ToString());
        objBSC.Ical_result_ts    = double.Parse(TtxtTsCalcResult.Text.ToString());
        objBSC.Icause_text_ms    = TtxtCAUSE_TEXT_MS.Text;
        objBSC.Icause_text_ts    = TtxtCAUSE_TEXT_TS.Text;
        objBSC.Icause_file_id    = hdfCauseDocNo.Value;
        objBSC.Imeasure_text_ms  = TtxtMEASURE_TEXT_MS.Text;
        objBSC.Imeasure_text_ts  = TtxtMEASURE_TEXT_TS.Text;
        objBSC.Imeasure_file_id  = hdfMeasureDocNo.Value;
        objBSC.Ical_apply_yn     = (TChkApplyItfsResult.Checked) ? "Y" : "N";
        objBSC.Ical_apply_reason = TtxtNotApplyReason.Text;
        objBSC.Iremark           = "";
        objBSC.Isequence         = 0;
        objBSC.Itxr_user         = gUserInfo.Emp_Ref_ID;

        int intRnt = 0;
        if (this.IType == "A" || this.IType == "U") //입력/수정
        {
            intRnt = objBSC.InsertData
                             ( this.IEstTermRefID
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
                             , objBSC.Itxr_user);
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

            if (objBSC.Transaction_Result == "Y")
            {
                Biz_Bsc_Kpi_Initiative objIni = new Biz_Bsc_Kpi_Initiative();
                intRnt = objIni.InsertInitiativeDo
                                        ( this.IEstTermRefID
                                        , this.IKpiRefID
                                        , this.IYMD
                                        , TtxtINITIATIVE_DO.Text
                                        , hdfInitiativeDocNo.Value
                                        , objBSC.Itxr_user );
                ltrScript.Text = JSHelper.GetAlertScript(objIni.Transaction_Message, false);

                // 익월 평가기간이 있으면
                if (this.IYMD_NEXT != "-")
                {
                    Biz_Bsc_Kpi_Result_Expect objExp = new Biz_Bsc_Kpi_Result_Expect();
                    intRnt = objExp.UpdateData
                             (
                                  this.IEstTermRefID
                                , this.IKpiRefID
                                , this.IYMD_NEXT
                                , (TtxtExtResult_MS.Text == "") ? 0 : decimal.Parse(TtxtExtResult_MS.Text)
                                , (TtxtExtResult_TS.Text == "") ? 0 : decimal.Parse(TtxtExtResult_TS.Text)
                                , TtxtEXPECT_REASON_MS.Text
                                , TtxtEXPECT_REASON_TS.Text
                                , hdfEXPECT_REASON_FILE_ID.Value
                                , TtxtRESULT_DIFF_CAUSE.Text
                                , hdfRESULT_DIFF_FILE_ID.Value
                                , objBSC.Itxr_user
                             );
                }
            }

            return (objBSC.Transaction_Result == "Y") ? true : false;
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
    /// 정성지표 평가정보 입력
    /// </summary>
    private bool TxrQualityEstInfo()
    {
        if (this.IYearlyClose_YN == "Y" || this.IMontylyClose_YN == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("이미 마감된 데이터 입니다. 처리할 수 없습니다.", false);
            return false;
        }

        if (this.IisPassCloseDay == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("이미 마감된 데이터 입니다. 처리할 수 없습니다.", false);
            return false;
        }

        if (this.IConfirmStatus == "N" || this.ICheckStatus == "N")
        {
            ltrScript.Text = JSHelper.GetAlertScript("실적입력이 완료되지 않았습니다. 처리할 수 없습니다.", false);
            return false;
        }

        if (this.IisPassQLTCloseDay == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("정성지표 평가기간이 마감되었습니다.", false);
            return false;
        }

        int intRow = TugrdQuestionList.Rows.Count;
        if ((this.IKpiGroupRefID == "COM" || this.IKpiGroupRefID == "QLT") && (intRow < 1))
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가항목이 등록되지 않았습니다. 처리할 수 없습니다.", false);
            return false;
        }

        int intTxrUser          = gUserInfo.Emp_Ref_ID;
        int intRtn              = 0;

        Biz_Bsc_Kpi_Qlt_Score_Det objBSC = new Biz_Bsc_Kpi_Qlt_Score_Det();
        for (int i = 0; i < intRow; i++)
        {
            objBSC.Iestterm_ref_id  = Convert.ToInt32(TugrdQuestionList.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            objBSC.Igroup_ref_id    = Convert.ToInt32(TugrdQuestionList.Rows[i].Cells.FromKey("GROUP_REF_ID").Value.ToString());
            objBSC.Ikpi_ref_id      = Convert.ToInt32(TugrdQuestionList.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            objBSC.Iymd             = Convert.ToString(TugrdQuestionList.Rows[i].Cells.FromKey("YMD").Value);
            objBSC.Iest_level       = Convert.ToInt32(TugrdQuestionList.Rows[i].Cells.FromKey("EST_LEVEL").Value.ToString());
            objBSC.Iquestion_ref_id = Convert.ToInt32(TugrdQuestionList.Rows[i].Cells.FromKey("QUESTION_REF_ID").Value.ToString());

            if (this.IKpiGroupRefID == "QLT")
            {
                TemplatedColumn tColDDLScore = (TemplatedColumn)TugrdQuestionList.Columns.FromKey("DDLSCORE");
                DropDownList ddlScore        = (DropDownList)((CellItem)tColDDLScore.CellItems[TugrdQuestionList.Rows[i].BandIndex]).FindControl("ddlScore");

                objBSC.Iscore_grade = ddlScore.SelectedItem.Value;
                objBSC.Iscore       = 0;

                intRtn = objBSC.EstQuestionItemGrade(
                                                objBSC.Iestterm_ref_id
                                              , objBSC.Igroup_ref_id
                                              , objBSC.Ikpi_ref_id
                                              , this.IEstEmpID
                                              , objBSC.Iymd
                                              , objBSC.Iest_level
                                              , objBSC.Iquestion_ref_id
                                              , objBSC.Iscore_grade  
                                              , intTxrUser
                                              );
            }
            else if (this.IKpiGroupRefID == "COM")
            {
                TemplatedColumn tColTXTScore = (TemplatedColumn)TugrdQuestionList.Columns.FromKey("TXTSCORE");
                WebNumericEdit txtScore      = (WebNumericEdit)((CellItem)tColTXTScore.CellItems[TugrdQuestionList.Rows[i].BandIndex]).FindControl("txtScore");
                
                objBSC.Iscore_grade  = "";
                objBSC.Iscore        = Convert.ToDouble(txtScore.Text.ToString());

                intRtn = objBSC.EstQuestionItem(
                                                objBSC.Iestterm_ref_id
                                              , objBSC.Igroup_ref_id
                                              , objBSC.Ikpi_ref_id
                                              , this.IEstEmpID
                                              , objBSC.Iymd
                                              , objBSC.Iest_level
                                              , objBSC.Iquestion_ref_id
                                              , objBSC.Iscore  
                                              , intTxrUser
                                              );
            }
            else
            {
                objBSC.Iscore_grade  = "";
                objBSC.Iscore        = 0;

                intRtn = objBSC.EstQuestionItem(
                                                objBSC.Iestterm_ref_id
                                              , objBSC.Igroup_ref_id
                                              , objBSC.Ikpi_ref_id
                                              , this.IEstEmpID
                                              , objBSC.Iymd
                                              , objBSC.Iest_level
                                              , objBSC.Iquestion_ref_id
                                              , objBSC.Iscore  
                                              , intTxrUser
                                              );
            }

            if (objBSC.Transaction_Result == "N")
            {
                ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
                break;
                return false;
            }

        }

        Biz_Bsc_Kpi_Qlt_Score_Had objGRP = new Biz_Bsc_Kpi_Qlt_Score_Had();
        intRtn = objGRP.InsertData(this.IEstTermRefID
                                 , this.IYMD
                                 , this.IGroupRefID
                                 , this.IKpiRefID
                                 , this.IEstLevel
                                 , this.IEstEmpID
                                 , 0
                                 , "DFT"
                                 , TtxtEstOpinion.Text
                                 , ThdfReviewFile.Value
                                 , intTxrUser);

        if (objGRP.Transaction_Result == "N")
        {
            return false;
        }

        ltrScript.Text = JSHelper.GetAlertScript(objGRP.Transaction_Message, false);
        return true;
    }

    /// <summary>
    /// 평가의견 확정, 취소
    /// </summary>
    /// <param name="strGubun"></param>
    /// <returns></returns>
    private int ConfirmCancelOpinion(string strGubun)
    {
        if (this.IYearlyClose_YN == "Y" || this.IMontylyClose_YN == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("이미 마감된 데이터 입니다. 처리할 수 없습니다.", false);
            return 0;
        }

        if (this.IisPassCloseDay == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("이미 마감된 데이터 입니다. 처리할 수 없습니다.", false);
            return 0;
        }

        if (this.IConfirmStatus == "N" || this.ICheckStatus == "N")
        {
            ltrScript.Text = JSHelper.GetAlertScript("실적입력이 완료되지 않았습니다. 처리할 수 없습니다.", false);
            return 0;
        }

        if (this.IisPassQLTCloseDay == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("정성지표 평가기간이 마감되었습니다.", false);
            return 0;
        }

        int intRow = TugrdQuestionList.Rows.Count;
        if ((this.IKpiGroupRefID == "COM" || this.IKpiGroupRefID == "QLT") && (intRow < 1))
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가항목이 등록되지 않았습니다. 처리할 수 없습니다.", false);
            return 0;
        }

        int intRtn = 0;
        Biz_Bsc_Kpi_Qlt_Score_Had objGRP = new Biz_Bsc_Kpi_Qlt_Score_Had();

        if (strGubun == "EC") // 확정
        {
            intRtn = objGRP.ConfirmOpinion
                            (this.IEstTermRefID
                           , this.IYMD
                           , this.IGroupRefID
                           , this.IKpiRefID
                           , this.IEstLevel
                           , this.IEstEmpID
                           , gUserInfo.Emp_Ref_ID);
            if (objGRP.Transaction_Result == "Y")
            {
                TiBtnSaveOpnion.Visible     = false;
                TiBtnConfirmOpinion.Visible = false;
                TiBtnCancelOpinion.Visible  = true;
                this.IEstStatus             = "Y";
            }
            else
            { 
                TiBtnSaveOpnion.Visible     = false;
                TiBtnConfirmOpinion.Visible = true;
                TiBtnCancelOpinion.Visible  = false;
                this.IEstStatus             = "N";
            }
        }
        else if (strGubun == "EL")  // 확정취소
        { 
            intRtn = objGRP.CancelOpinion
                            (this.IEstTermRefID
                           , this.IYMD
                           , this.IGroupRefID
                           , this.IKpiRefID
                           , this.IEstLevel
                           , this.IEstEmpID
                           , gUserInfo.Emp_Ref_ID
                           );
            if (objGRP.Transaction_Result == "Y")
            {
                TiBtnSaveOpnion.Visible     = false;
                TiBtnConfirmOpinion.Visible = true;
                TiBtnCancelOpinion.Visible  = false;
                this.IEstStatus             = "N";
            }
            else
            { 
                TiBtnSaveOpnion.Visible     = false;
                TiBtnConfirmOpinion.Visible = false;
                TiBtnCancelOpinion.Visible  = true;
                this.IEstStatus             = "N";
            }
        }

        ltrScript.Text = JSHelper.GetAlertScript(objGRP.Transaction_Message, false);

        return intRtn;
    }

    /// <summary>
    /// 계획/실적 그리드 조회
    /// </summary>
    private void SetResultGrid()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        DataSet ds = objBSC.GetResultListPerMonth(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        TugrdResult.Clear();
        TugrdResult.DataSource = ds;
        TugrdResult.DataBind();
    }

    /// <summary>
    /// 정성지표 평가조회
    /// </summary>
    private void SetEstQuestionListGrid()
    { 
        Biz_Bsc_Kpi_Qlt_Score_Det objBSC = new Biz_Bsc_Kpi_Qlt_Score_Det();
        DataSet rDs = objBSC.GetQuestionListPerEstEmp(this.IEstTermRefID, this.IGroupRefID, this.IEstLevel, this.IKpiRefID, this.IYMD, gUserInfo.Emp_Ref_ID);
                             
        TugrdQuestionList.Clear();
        TugrdQuestionList.DataSource = rDs;
        TugrdQuestionList.DataBind();

        Biz_Bsc_Kpi_Qlt_Score_Had objHad = new Biz_Bsc_Kpi_Qlt_Score_Had
                                                              ( this.IEstTermRefID
                                                              , this.IYMD
                                                              , this.IGroupRefID
                                                              , this.IKpiRefID
                                                              , this.IEstLevel
                                                              , gUserInfo.Emp_Ref_ID);
        TtxtEstOpinion.Text  = objHad.Iopinion;
        ThdfReviewFile.Value = objHad.Ireview_file_id;
        if (objHad.Istatus == "CET")
        { 
            TiBtnSaveOpnion.Visible     = false;
            TiBtnConfirmOpinion.Visible = false;
            TiBtnCancelOpinion.Visible  = true;
            this.IEstStatus             = "Y";
        }
        else
        {
            TiBtnSaveOpnion.Visible     = false;
            TiBtnConfirmOpinion.Visible = true;
            TiBtnCancelOpinion.Visible  = false;
            TiBtnReviewFile.Visible     = true;
            this.IEstStatus             = "N";
        }
    }

    /// <summary>
    /// Initiative 조회
    /// </summary>
    private void SetInitiativeList()
    {
        Biz_Bsc_Kpi_Initiative objBSC = new Biz_Bsc_Kpi_Initiative(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        TtxtINITIATIVE_DO.Text      = objBSC.Iinitiative_do;
        TtxtINITIATIVE_PLAN.Text    = objBSC.Iinitiative_plan;
        hdfInitiativeDocNo.Value    = objBSC.Ido_file;
        imgHdfInitiativeDocNo.Visible = (hdfInitiativeDocNo.Value == "") ? false : true;
        TtxtINITIATIVE_PLAN.ReadOnly = true;
    }

    /// <summary>
    /// 하위지표 실적조회
    /// </summary>
    private void SetChildKpiGrid()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        DataSet rDs = objBSC.GetChildKpiResultList(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        TugrdChildKpiResult.Clear();
        TugrdChildKpiResult.DataSource = rDs;
        TugrdChildKpiResult.DataBind();
    }

    /// <summary>
    /// 예측실적 그리드 조회
    /// </summary>
    private void SetExceptGrid()
    {
        this.IYMD_NEXT  = "-";

        Biz_Bsc_Kpi_Term objTrm = new Biz_Bsc_Kpi_Term();
        this.IYMD_NEXT = objTrm.GetNavigateMonth(this.IEstTermRefID, this.IKpiRefID, this.IYMD, gNavigator.NEXT);

        Biz_Bsc_Kpi_Result_Expect objNextExp = new Biz_Bsc_Kpi_Result_Expect(this.IEstTermRefID, this.IKpiRefID, this.IYMD_NEXT);
        TtxtExtResult_MS.Text           = objNextExp.IResult_Ms.ToString();
        TtxtExtResult_TS.Text           = objNextExp.IResult_Ts.ToString();
        TtxtEXPECT_REASON_MS.Text       = objNextExp.IExpect_Reason_Ms;
        TtxtEXPECT_REASON_TS.Text       = objNextExp.IExpect_Reason_Ts;
        hdfEXPECT_REASON_FILE_ID.Value  = objNextExp.IExpect_Reason_File_Id;
        TtxtRESULT_DIFF_CAUSE.Text      = objNextExp.IResult_Diff_Cause;
        hdfRESULT_DIFF_FILE_ID.Value    = objNextExp.IResult_Diff_File_Id;

        imgHdfRESULT_DIFF_FILE_ID.Visible   = (hdfRESULT_DIFF_FILE_ID.Value == "") ? false : true;
        imgHdfEXPECT_REASON_FILE_ID.Visible = (hdfEXPECT_REASON_FILE_ID.Value == "") ? false : true;

        lblNextYmd_Ms.Text = this.IYMD_NEXT;
        lblNextYmd_Ts.Text = this.IYMD_NEXT;

        DataSet rDs = objNextExp.GetResultExpect(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        TugrdExpectGrid.Clear();
        TugrdExpectGrid.DataSource = rDs;
        TugrdExpectGrid.DataBind();
    }

    #region ================================= [ 인터페이스 실적조회 ]===================================

    public void GetInterfaceData()
    {
        if (this.IResultInputType == "SYS" && 
           (this.IApp_Status == Biz_Type.app_status_draft   ||  // 기안
            this.IApp_Status == Biz_Type.app_status_nodraft ||  // 미작성
            this.IApp_Status == Biz_Type.app_status_recall  ||  // 회수
            this.IApp_Status == Biz_Type.app_status_return  ||  // 반려
            this.IApp_Status == Biz_Type.app_status_onmodify))  // 수정결재
        {
            Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query(this.IKpiRefID, "");
            Biz_Bsc_Term_Detail objTrm = new Biz_Bsc_Term_Detail();
            string sYMD = objTrm.GetStartEstMonth(this.IEstTermRefID);

            string sRtnMsg = "";
            bool bIsOkMs = false;
            bool bIsOkTs = false;
            decimal dRtnVal = 0;

            dRtnVal = objQry.GetInterfaceResultMs(this.IKpiRefID, this.IYMD, out sRtnMsg, out bIsOkMs);
            TtxtMsCalcResult.Text = (bIsOkMs) ? dRtnVal.ToString() : "0";

            dRtnVal = objQry.GetInterfaceResultTs(this.IKpiRefID, sYMD, this.IYMD, out sRtnMsg, out bIsOkTs);
            TtxtTsCalcResult.Text = (bIsOkTs) ? dRtnVal.ToString() : "0";

            if (bIsOkMs && bIsOkTs)
            {
                TChkApplyItfsResult.Checked = true;
                this.SetResultInputStatus();
            }
        }

        if (this.IResultInputType == "MAN")
        {
            TChkApplyItfsResult.Checked = false;
            TChkApplyItfsResult.Enabled = false;

            TtxtNotApplyReason.Enabled    = false;
            TiBtnInterfaceDataAdd.Visible = false;
        }
    }

    public void SetResultInputStatus()
    {
        if (TChkApplyItfsResult.Checked)
        {
            TtxtMSResult.ReadOnly = true;
            TtxtTSResult.ReadOnly = true;

            TtxtMSResult.BackColor = Color.WhiteSmoke;
            TtxtTSResult.BackColor = Color.WhiteSmoke;

            TtxtMSResult.Text = TtxtMsCalcResult.Text;
            TtxtTSResult.Text = TtxtTsCalcResult.Text;
        }
        else
        { 
            TtxtMSResult.ReadOnly  = false;
            TtxtTSResult.ReadOnly  = false;

            TtxtMSResult.BackColor = Color.White;
            TtxtTSResult.BackColor = Color.White;
        }
    }

    #endregion

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
        //ugrdResult.Width = 520;
        //ugrdResult.Height = 286;
        //ugrdResult.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;

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
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 누    적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "결재";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "측정";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "Signal";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 11;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[9].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[10].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
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

        e.Row.Cells.FromKey("SIGNAL_MS").Text     = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_MS").Value.ToString() + "' />";
        e.Row.Cells.FromKey("SIGNAL_TS").Text     = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_TS").Value.ToString() + "' />";

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
        if (!this.ValidateForm())
        {
            return;
        }

        this.IType = "U";
        if (this.TxrResultForm())
        {
            this.SetResultData();
            this.SetResultGrid();
            this.SetInitiativeList();
            this.SetExceptGrid();
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

    protected void iBtnSaveOpnion_Click(object sender, ImageClickEventArgs e)
    {
        bool blnRtn = this.TxrQualityEstInfo();
    }

    protected void iBtnConfirmOpinion_Click(object sender, ImageClickEventArgs e)
    {
        if (this.TxrQualityEstInfo())
        {
            int intRtn = this.ConfirmCancelOpinion("EC");
        }
    }

    protected void iBtnCancelOpinion_Click(object sender, ImageClickEventArgs e)
    {
        int intRtn = this.ConfirmCancelOpinion("EL");
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (GetRequest("closeRefresh", "") == "F")
            ltrScript.Text = JSHelper.GetCloseScript();
        else
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    protected void ugrdQuestionList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (this.IKpiGroupRefID == "QLT") // 비계량
        {
            e.Layout.Bands[0].Columns.FromKey("TXTSCORE").Hidden = true;
            e.Layout.Bands[0].Columns.FromKey("DDLSCORE").Hidden = false;
        }
        else if (this.IKpiGroupRefID == "COM") // 공통
        {
            e.Layout.Bands[0].Columns.FromKey("TXTSCORE").Hidden = false;
            e.Layout.Bands[0].Columns.FromKey("DDLSCORE").Hidden = true;
        }
        else
        { 
            e.Layout.Bands[0].Columns.FromKey("TXTSCORE").Hidden = true;
            e.Layout.Bands[0].Columns.FromKey("DDLSCORE").Hidden = true;
        }
    }

    protected void ugrdQuestionList_InitializeRow(object sender, RowEventArgs e)
    {
        if (this.IKpiGroupRefID == "QLT")
        {
            string selVal = e.Row.Cells.FromKey("DDLSCORE").Value.ToString();
            TemplatedColumn tColDDLScore = (TemplatedColumn)e.Row.Cells.FromKey("DDLSCORE").Column;
            DropDownList ddlScore = (DropDownList)((CellItem)tColDDLScore.CellItems[e.Row.BandIndex]).FindControl("ddlScore");

            for (int i = 0; i < ddlScoreGrade.Items.Count; i++)
            {
                ddlScore.Items.Add(new ListItem(ddlScoreGrade.Items[i].Text, ddlScoreGrade.Items[i].Value));
                
            }

            PageUtility.FindByValueDropDownList(ddlScore, selVal);
        }
        else
        { 
            TemplatedColumn tColTXTScore = (TemplatedColumn)e.Row.Cells.FromKey("TXTSCORE").Column;
            WebNumericEdit txtScore = (WebNumericEdit)((CellItem)tColTXTScore.CellItems[e.Row.BandIndex]).FindControl("txtScore");
            txtScore.Text = e.Row.Cells.FromKey("TXTSCORE").Value.ToString();
        }
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
        /*
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
        */


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 당 월 실 적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 12;
        //ch.Style.Height = Unit.Pixel(20);
        ch.Fixed = false;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 누 적 실 적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 21;
        ch.RowLayoutColumnInfo.SpanX = 12;
        //ch.Style.Height = Unit.Pixel(20);
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
                
                //e.Layout.Bands[0].Columns[i].Header.Style.BackColor = ColorTranslator.FromHtml("#94BAC9");
                //e.Layout.Bands[0].Columns[i].Header.Style.ForeColor = Color.White;
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

    protected void ugrdExpectGrid_InitializeLayout(object sender, LayoutEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "구분";
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

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;
    }
    
    protected void ugrdExpectGrid_InitializeRow(object sender, RowEventArgs e)
    {
        string sGubun = e.Row.Cells.FromKey("GUBUN").Value.ToString();
        switch (sGubun)
        { 
            case "EXPT":
                e.Row.Cells.FromKey("GUBUN").Value = "예측실적";
                break;
            case "CURR":
                e.Row.Cells.FromKey("GUBUN").Value = "당월실적";
                break;
            case "DIFF":
                e.Row.Cells.FromKey("GUBUN").Value = "차    이";
                break;
            default:
                e.Row.Cells.FromKey("GUBUN").Value = "-";
                break;
        }

        e.Row.Cells.FromKey("TARGET_MS").Value  = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells.FromKey("TARGET_MS").Value),"#,###,###,###,###,###,###,##0.00");
        e.Row.Cells.FromKey("RESULT_MS").Value  = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells.FromKey("RESULT_MS").Value),"#,###,###,###,###,###,###,##0.00");
        e.Row.Cells.FromKey("AC_RATE_MS").Value = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells.FromKey("AC_RATE_MS").Value),"#,###,###,###,###,###,###,##0.00");
        e.Row.Cells.FromKey("TARGET_TS").Value  = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells.FromKey("TARGET_TS").Value),"#,###,###,###,###,###,###,##0.00");
        e.Row.Cells.FromKey("RESULT_TS").Value  = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells.FromKey("RESULT_TS").Value),"#,###,###,###,###,###,###,##0.00");
        e.Row.Cells.FromKey("AC_RATE_TS").Value = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells.FromKey("AC_RATE_TS").Value), "#,###,###,###,###,###,###,##0.00");
    }

    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }

    protected void ChkApplyItfsResult_CheckedChanged(object sender, EventArgs e)
    {
        this.SetResultInputStatus();
    }
    #endregion

}
