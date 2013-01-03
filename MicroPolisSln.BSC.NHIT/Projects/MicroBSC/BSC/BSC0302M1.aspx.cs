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

using System.Collections.Generic;
using System.Text;

using MicroCharts;
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.BSC.Biz;


//using Dundas.Charting.WebControl;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC0302M1 : AppPageBase
{
    #region ==========================[변수선언]================
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
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
                hdfEstTermRefID.Value       = GetRequest("ESTTERM_REF_ID");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
            hdfEstTermRefID.Value       = value.ToString();
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
                hdfKpiRefID.Value       = GetRequest("KPI_REF_ID");
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
            hdfKpiRefID.Value       = value.ToString();
        }
    }

    public string IisTeamKpi
    {
        get
        {
            if (ViewState["IS_TEAM_KPI"] == null)
            {
                ViewState["IS_TEAM_KPI"] = GetRequest("IS_TEAM_KPI", "Y");
            }

            return (string)ViewState["IS_TEAM_KPI"];
        }
        set
        {
            ViewState["IS_TEAM_KPI"] = value;
        }
    }

    public string ISaveRecord_YN
    {
        get
        {
            if (ViewState["INSERT_YN"] == null)
            {
                ViewState["INSERT_YN"] = GetRequestByInt("INSERT_YN", 0);
            }

            return (string)ViewState["INSERT_YN"];
        }
        set
        {
            ViewState["INSERT_YN"] = value;
        }
    }

    public string IConfirm_YN
    {
        get
        {
            if (ViewState["APPROVAL_STATUS"] == null)
            {
                ViewState["APPROVAL_STATUS"] = GetRequest("APPROVAL_STATUS");
            }
            return (string)ViewState["APPROVAL_STATUS"];
        }
        set
        {
            ViewState["APPROVAL_STATUS"] = value;
        }
    }

    public string IChampion_User_YN
    {
        get
        {
            if (ViewState["CHAMPION_EMP_YN"] == null)
            {
                ViewState["CHAMPION_EMP_YN"] = GetRequest("CHAMPION_EMP_YN");
            }
            return (string)ViewState["CHAMPION_EMP_YN"];
        }
        set
        {
            ViewState["CHAMPION_EMP_YN"] = value;
        }
    }

    public string IApporval_User_YN
    {
        get
        {
            if (ViewState["APPROVAL_EMP_YN"] == null)
            {
                ViewState["APPROVAL_EMP_YN"] = GetRequest("APPROVAL_EMP_YN");
            }
            return (string)ViewState["APPROVAL_EMP_YN"];
        }
        set
        {
            ViewState["APPROVAL_EMP_YN"] = value;
        }
    }

    //public string ITargetVersion_Inital_YN
    //{
    //    get
    //    {
    //        if (ViewState["INITIAL_VERSION_YN"] == null)
    //        {
    //            ViewState["INITIAL_VERSION_YN"] = GetRequest("INITIAL_VERSION_YN");
    //            hdfinitial_version_yn.Value     = GetRequest("INITIAL_VERSION_YN");
    //        }
    //        return (string)ViewState["INITIAL_VERSION_YN"]);
    //    }
    //    set
    //    {
    //        ViewState["INITIAL_VERSION_YN"] = value;
    //        hdfbinitial_version_yn.Value = value;
    //    }
    //}

    //public int ITargetVersionRefID
    //{
    //    get
    //    {
    //        if (ViewState["KPI_TARGET_VERSION_ID"] == null)
    //        {
    //            ViewState["KPI_TARGET_VERSION_ID"] = GetRequest("KPI_TARGET_VERSION_ID");
    //            hdfbkpi_target_version_id.Value = GetRequest("KPI_TARGET_VERSION_ID");
    //        }
    //        return (int)ViewState["KPI_TARGET_VERSION_ID"]);
    //    }
    //    set
    //    {
    //        ViewState["KPI_TARGET_VERSION_ID"] = value;
    //        hdfbkpi_target_version_id.Value = value.ToString();
    //    }
    //}

    public string IHaveChildKPI_YN
    {
        get
        {
            if (ViewState["HAVE_CHILD_KPI_YN"] == null)
            {
                ViewState["HAVE_CHILD_KPI_YN"] = GetRequest("HAVE_CHILD_KPI_YN");
            }
            return (string)ViewState["HAVE_CHILD_KPI_YN"];
        }
        set
        {
            ViewState["HAVE_CHILD_KPI_YN"] = value;
        }
    }

    public string IHaveInitive_YN
    {
        get
        {
            if (ViewState["HAVE_INITIATIVE_YN"] == null)
            {
                ViewState["HAVE_INITIATIVE_YN"] = GetRequest("HAVE_INITIATIVE_YN","N");
            }
            return (string)ViewState["HAVE_INITIATIVE_YN"];
        }
        set
        {
            ViewState["HAVE_INITIATIVE_YN"] = value;
        }
    }

    public int IMonthly_Close_Day
    {
        get
        {
            if (ViewState["MONTHLY_CLOSE_DAY"] == null)
            {
                ViewState["MONTHLY_CLOSE_DAY"] = GetRequest("MONTHLY_CLOSE_DAY");
            }
            return (int)ViewState["MONTHLY_CLOSE_DAY"];
        }
        set
        {
            ViewState["MONTHLY_CLOSE_DAY"] = value;
        }
    }

    public string IScoreValuationType
    {
        get
        {
            if (ViewState["SCORE_VALUATION_TYPE"] == null)
            {
                ViewState["SCORE_VALUATION_TYPE"] = GetRequest("SCORE_VALUATION_TYPE");
            }
            return (string)ViewState["SCORE_VALUATION_TYPE"];
        }
        set
        {
            ViewState["SCORE_VALUATION_TYPE"] = value;
        }
    }

    public string IEsttermUseYN
    {
        get
        {
            if (ViewState["ESTTERM_USER_YN"] == null)
            {
                ViewState["ESTTERM_USER_YN"] = GetRequest("ESTTERM_USER_YN");
            }
            return (string)ViewState["ESTTERM_USER_YN"];
        }
        set
        {
            ViewState["ESTTERM_USER_YN"] = value;
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

    public string IMonthlyCloseType
    {
        get
        {
            if (ViewState["CLOSE_RATE_COMPLETE_YN"] == null)
            {
                ViewState["CLOSE_RATE_COMPLETE_YN"] = GetRequest("CLOSE_RATE_COMPLETE_YN");
            }
            return (string)ViewState["CLOSE_RATE_COMPLETE_YN"];
        }
        set
        {
            ViewState["CLOSE_RATE_COMPLETE_YN"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID");
            }
            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
            hdfKpiPoolRefID.Value        = value.ToString();
        }
    }

    public string IKpiGroup
    {
        get
        {
            if (ViewState["KPI_GROUP"] == null)
            {
                ViewState["KPI_GROUP"] = GetRequest("KPI_GROUP");
            }
            return (string)ViewState["KPI_GROUP"];
        }
        set
        {
            ViewState["KPI_GROUP"] = value;
        }
    }

    public string IBasis_Use_Yn
    {
        get
        {
            if (ViewState["BASIS_USE_YN"] == null)
            {
                ViewState["BASIS_USE_YN"] = GetRequest("BASIS_USE_YN");
            }
            return (string)ViewState["BASIS_USE_YN"];
        }
        set
        {
            ViewState["BASIS_USE_YN"] = value;
        }
    }

    public int IEstLevel
    {
        get
        {
            if (ViewState["EST_LEVEL"] == null)
            {
                ViewState["EST_LEVEL"] = GetRequestByInt("EST_LEVEL",0);
            }
            return (int)ViewState["EST_LEVEL"];
        }
        set
        {
            ViewState["EST_LEVEL"] = value;
        }
    }

    public string IKpi_Use_Yn
    {
        get
        {
            if (ViewState["KPI_USE_YN"] == null)
            {
                ViewState["KPI_USE_YN"] = GetRequest("KPI_USE_YN","N");
            }
            return (string)ViewState["KPI_USE_YN"];
        }
        set
        {
            ViewState["KPI_USE_YN"] = value;
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

    TextBox txtBCalcFormMs;
    TextBox txtBCalcFormTs;
    HiddenField hdfBChampionEmpId;
    TextBox txtBChampionEmpName;
    HiddenField hdfBMeasurementEmpId;
    TextBox txtBMeasurementEmpName;
    //HiddenField hdfBApprovalEmpId;
    //TextBox txtBApprovalEmpName;
    TextBox txtBGetheringMethod;
    TextBox txtBRelatedIssue;
    TextBox txtBMeasurementPurpose;
    TextBox txtBWordDefinition;
    TextBox txtBTargetReason;

    FileUpload fileBDefinition;

    HyperLink linkBDefinition;

    ImageButton iBtnBTargetFile_Up;
    ImageButton iBtnBTargetFile_Down;
                                          
    DropDownList ddlBResultTermType;
    DropDownList ddlBResultInputType;
    DropDownList ddlBResultAchievementType;
    DropDownList ddlBResultTsCalcType;
    DropDownList ddlBMeasurementGradeType;
    DropDownList ddlBResultMeasurementStep;
    DropDownList ddlBUnit;

    UltraWebGrid ugrdBDetail;
    UltraWebGrid ugrdBTerm;
    UltraWebGrid ugrdBPlan;
    UltraWebGrid ugrdBSignal;
    UltraWebGrid ugrdBQuestionTerm;
    UltraWebGrid ugrdBEstLevel;
    UltraWebGrid ugrdBInitiative;
    UltraWebGrid ugrdBPrjList;
  

    Chart chartBScore;
    Chart chartBTarget;

    UltraWebTab ugrdBGraphTab; 
    
    Workbook workBook = null; // smjjang
    Panel pnlBPrj=null;

    int startYY = 0;

    #endregion

    #region 폼초기화

    protected void Page_Load(object sender, EventArgs e)
    {
        txtBCalcFormMs            = this.ugrdKpiStatusTab.FindControl("txtCalcFormMs")            as TextBox;
        txtBCalcFormTs            = this.ugrdKpiStatusTab.FindControl("txtCalcFormTs")            as TextBox;
        hdfBChampionEmpId         = this.ugrdKpiStatusTab.FindControl("hdfChampionEmpId")         as HiddenField;
        txtBChampionEmpName       = this.ugrdKpiStatusTab.FindControl("txtChampionEmpName")       as TextBox;
        hdfBMeasurementEmpId      = this.ugrdKpiStatusTab.FindControl("hdfMeasurementEmpId")      as HiddenField;
        txtBMeasurementEmpName    = this.ugrdKpiStatusTab.FindControl("txtMeasurementEmpName")    as TextBox;
        //hdfBApprovalEmpId         = this.ugrdKpiStatusTab.FindControl("hdfApprovalEmpId")         as HiddenField;
        //txtBApprovalEmpName       = this.ugrdKpiStatusTab.FindControl("txtApprovalEmpName")       as TextBox;
        txtBGetheringMethod       = this.ugrdKpiStatusTab.FindControl("txtDataGetheringMethod")   as TextBox;
        txtBRelatedIssue          = this.ugrdKpiStatusTab.FindControl("txtRelatedIssue")          as TextBox;
        txtBMeasurementEmpName    = this.ugrdKpiStatusTab.FindControl("txtMeasurementEmpName")    as TextBox;
        txtBMeasurementPurpose    = this.ugrdKpiStatusTab.FindControl("txtMeasurementPurpose")    as TextBox;
        txtBWordDefinition        = this.ugrdKpiStatusTab.FindControl("txtWordDefinition")        as TextBox;
        txtBTargetReason          = this.ugrdKpiStatusTab.FindControl("txtTargetReason")          as TextBox;

        ddlBResultTermType        = this.ugrdKpiStatusTab.FindControl("ddlResultTermType")        as DropDownList;
        ddlBResultInputType       = this.ugrdKpiStatusTab.FindControl("ddlResultInputType")       as DropDownList;
        ddlBResultAchievementType = this.ugrdKpiStatusTab.FindControl("ddlResultAchievementType") as DropDownList;
        ddlBResultTsCalcType      = this.ugrdKpiStatusTab.FindControl("ddlResultTsCalcType")      as DropDownList;
        ddlBMeasurementGradeType  = this.ugrdKpiStatusTab.FindControl("ddlMeasurementGradeType")  as DropDownList;
        ddlBResultMeasurementStep = this.ugrdKpiStatusTab.FindControl("ddlResultMeasurementStep") as DropDownList;
        ddlBUnit                  = this.ugrdKpiStatusTab.FindControl("ddlUnit")                  as DropDownList;
        
        ugrdBDetail               = this.ugrdKpiStatusTab.FindControl("ugrdDetail")               as UltraWebGrid;
        ugrdBTerm                 = this.ugrdKpiStatusTab.FindControl("ugrdTerm")                 as UltraWebGrid;
        ugrdBPlan                 = this.ugrdKpiStatusTab.FindControl("ugrdPlan")                 as UltraWebGrid;
        ugrdBSignal               = this.ugrdKpiStatusTab.FindControl("ugrdSignal")               as UltraWebGrid;
        ugrdBQuestionTerm         = this.ugrdKpiStatusTab.FindControl("ugrdQuestionTerm")         as UltraWebGrid;
        ugrdBEstLevel             = this.ugrdKpiStatusTab.FindControl("ugrdEstLevel")             as UltraWebGrid;
        ugrdBInitiative           = this.ugrdKpiStatusTab.FindControl("ugrdInitiative")           as UltraWebGrid;
        ugrdBPrjList              = this.ugrdKpiStatusTab.FindControl("ugrdPrjList")              as UltraWebGrid;

        ugrdBGraphTab             = this.ugrdKpiStatusTab.FindControl("ugrdGraphTab")             as UltraWebTab;
        pnlBPrj                   = this.ugrdKpiStatusTab.FindControl("pnlPrj")                   as Panel;

        chartBScore               = this.ugrdBGraphTab.FindControl("chartScore")                  as Chart;
        chartBTarget              = this.ugrdBGraphTab.FindControl("chartTarget")                 as Chart;

        fileBDefinition           = this.ugrdBGraphTab.FindControl("fileDefinition")              as FileUpload; 

        linkBDefinition           = this.ugrdBGraphTab.FindControl("linkDefinition")              as HyperLink;

        iBtnBTargetFile_Up        = this.ugrdKpiStatusTab.FindControl("iBtnTargetFile_Up")        as ImageButton;
        iBtnBTargetFile_Down      = this.ugrdKpiStatusTab.FindControl("iBtnTargetFile_Down")      as ImageButton;
        
        ltrScript.Text = "";

        this.InitializeGrid(ugrdPlan);

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
            this.NotPostBackSetting();
        }
        else
        {
            this.PostBackSetting();
        }

        iBtnAddChildKpi.Visible = PageUtility.GetByValueDropDownList(ddlBResultInputType).Equals("KPI");

        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    private void NotPostBackSetting()
    {
        this.InitForm();
        this.SetKPIBaseInfo();
        this.SetKPIMaster();
        this.SetDraftInfo();
        this.SetKpiDataSourceGrid();
        this.SetKpiNewTargetGrid();
        this.SetKpiTargetGrid();
        this.SetKpiSignalGrid();
        this.SetTermToTarget(false, false);
        this.GetKpiQltTermList();
        this.SetEstLevelList();
        this.SetKpiTermGrid();
        this.SetButton();
        defaultTab3();
    }

    private void PostBackSetting()
    { 
        
    }

    //------------------------------------------------------ 폼초기화

    private void InitForm()
    {
        Biz_EtcCodeInfos objCode = new Biz_EtcCodeInfos();
        objCode.getResultMethod(ddlBResultInputType, "", false, 100);
        objCode.getTermType(ddlBResultTermType, "", false, 100);
        objCode.getPNUType(ddlBResultAchievementType, "", false, 100);
        objCode.getColTargetType(ddlBResultTsCalcType, "", false, 80);
        objCode.getCheckStep(ddlBResultMeasurementStep, "", false, 100);
        objCode.getCheckType(ddlBMeasurementGradeType, "", false, 80);
        WebCommon.SetUnitTypeDropDownList(ddlBUnit, false);
       // this.ugrdKpiStatusTab.SelectedTabIndex = 3;
        //this.ugrdKpiStatusTab.SelectedTab = 2;
        //defaultTab3();
        //txtBChampionEmpName.ReadOnly = true;
        
    }

    private void defaultTab3()
    {
       
        iBtnGoalTong.Visible = false;

        if (this.IHaveChildKPI_YN == "Y")
        {
            this.SetTermToTarget(false, false);
        }
        else
        {
            this.SetTermToTarget(false, true);
        }

        if (this.IType == "U" && (this.IChampion_User_YN == "Y" || User.IsInRole(ROLE_ADMIN)))
        {
            this.iBtnAddTarget.Visible = true;
            this.iBtnAddChildKpi.Visible = true;
        }

        if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y") && this.IChampion_User_YN == "Y")
            iBtnGoalTong.Visible = true;

        this.drawGrade();
        this.drawPoint();

        iBtnAddChildKpi.Visible = PageUtility.GetByValueDropDownList(ddlBResultInputType).Equals("KPI");
        this.ugrdKpiStatusTab.SelectedTab = 2;
    }

    private void InitializeGrid(UltraWebGrid grid)
    {
        grid.DisplayLayout.Bands[0].HeaderLayout.Reset();

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in grid.DisplayLayout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "월";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "당초계획";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "수정계획";  //_itarget_mod_name;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = grid.DisplayLayout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        for (int i = 0; i < grid.DisplayLayout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                grid.DisplayLayout.Bands[0].Columns[i].Width = 50;
                grid.DisplayLayout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else if (i > 0 && i < 5)
            {
                grid.DisplayLayout.Bands[0].Columns[i].DataType = "System.Double";
                grid.DisplayLayout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,##0.####";
                grid.DisplayLayout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                //e.Layout.Bands[0].Columns[i].Hidden = true;
            }
        }
    }

    private void SetKPIBaseInfo()
    {
        //-------------------- KPI Status Setting
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiStatus(this.IEstTermRefID, this.IKpiRefID, gUserInfo.Emp_Ref_ID);

        if (rDs.Tables[0].Rows.Count > 0)
        {
            this.IConfirm_YN                    = rDs.Tables[0].Rows[0]["CONFIRM_YN"].ToString();
            this.IChampion_User_YN              = rDs.Tables[0].Rows[0]["CHAMPION_EMP_YN"].ToString();
            this.IApporval_User_YN              = rDs.Tables[0].Rows[0]["APPROVAL_EMP_YN"].ToString();
            this.hdfinitial_version_yn.Value    = rDs.Tables[0].Rows[0]["INITIAL_VERSION_YN"].ToString();
            this.hdfkpi_target_version_id.Value = rDs.Tables[0].Rows[0]["KPI_TARGET_VERSION_ID"].ToString();
            this.ISaveRecord_YN                 = rDs.Tables[0].Rows[0]["INSERT_YN"].ToString();
            this.IHaveChildKPI_YN               = rDs.Tables[0].Rows[0]["HAVE_CHILD_KPI_YN"].ToString();
            this.IHaveInitive_YN                = rDs.Tables[0].Rows[0]["HAVE_INITIATIVE_YN"].ToString();
            this.IMonthly_Close_Day             = int.Parse(rDs.Tables[0].Rows[0]["MONTHLY_CLOSE_DAY"].ToString());
            this.IScoreValuationType            = rDs.Tables[0].Rows[0]["SCORE_VALUATION_TYPE"].ToString();
            this.IEsttermUseYN                  = rDs.Tables[0].Rows[0]["ESTTERM_USE_YN"].ToString();
            this.IYearlyClose_YN                = rDs.Tables[0].Rows[0]["YEARLY_CLOSE_YN"].ToString();
            this.IMonthlyCloseType              = rDs.Tables[0].Rows[0]["MONTHLY_CLOSE_TYPE"].ToString();

            if (this.IHaveInitive_YN == "Y")
            {
                ugrdBInitiative.Visible = false;
                pnlBPrj.Visible         = true;
                ugrdBInitiative.Clear();
                this.SetProjectList();
            }
            else
            { 
                ugrdBInitiative.Visible = true;
                pnlBPrj.Visible         = false;
                ugrdBPrjList.Clear();
                this.SetInitiativeList();
            }
        }
    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnKpiPoolList.Visible = true;
            iBtnInsert.Visible          = true;
            iBtnUpdate.Visible          = false;
            iBtnDelete.Visible          = false;
            iBtnUsed.Visible            = false;
            iBtnTargetFile_Up.Visible   = true;
            iBtnTargetFile_Down.Visible = false;
            iBtnAddChildKpi.Visible     = false;
            iBtnDraft.Visible           = false;
            iBtnReDraft.Visible         = false;
            iBtnMoDraft.Visible         = false;
            iBtnReqModify.Visible       = false;
            iBtnAddTarget.Visible       = false;
            
            txtKpiCode.ReadOnly         = true;
            txtKpiCode.BackColor        = Color.WhiteSmoke;
            txtKpiCode.Attributes.Add("onkeydown", "CheckKeyVal(this);");
            txtKpiCode.Attributes.Add("onblur", "isExistsKpi(this);");

        }
        else if (this.IType == "U")
        {
            iBtnKpiPoolList.Visible = false;

            iBtnInsert.Visible          = false;
            iBtnUsed.Visible            = false;
            iBtnAddChildKpi.Visible     = false;
            iBtnTargetFile_Up.Visible   = true;
            iBtnTargetFile_Down.Visible = false;
            txtKpiCode.ReadOnly         = true;
            txtKpiCode.BackColor        = Color.WhiteSmoke;
            txtKpiCode.Attributes.Remove("onkeydown");
            txtKpiCode.Attributes.Remove("onblur");
            

            switch (this.IApp_Status)
            {
                case "": // 결재상태 없음
                    iBtnUpdate.Visible      = true;
                    iBtnDelete.Visible      = true;
                    iBtnUsed.Visible        = (this.IKpi_Use_Yn=="N") ? true : false;
                    iBtnAddChildKpi.Visible = (!IsPostBack) ? false :true;
                    iBtnAddTarget.Visible   = (!IsPostBack) ? false :true;;
                    iBtnDraft.Visible       = true;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_nodraft: // 결재상태 없음
                    iBtnUpdate.Visible      = true;
                    iBtnDelete.Visible      = true;
                    iBtnUsed.Visible        = (this.IKpi_Use_Yn == "N") ? true : false;
                    iBtnAddChildKpi.Visible = (!IsPostBack) ? false : true; ;
                    iBtnAddTarget.Visible   = (!IsPostBack) ? false :true;;
                    iBtnDraft.Visible       = true;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_draft: // 상신
                    iBtnUpdate.Visible      = false;
                    iBtnDelete.Visible      = false;
                    iBtnUsed.Visible        = false;
                    iBtnAddChildKpi.Visible = false;
                    iBtnAddTarget.Visible   = false;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_ondraft: // 결재중
                    iBtnUpdate.Visible      = false;
                    iBtnDelete.Visible      = false;
                    iBtnUsed.Visible        = false;
                    iBtnAddChildKpi.Visible = false;
                    iBtnAddTarget.Visible   = false;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_return: // 반려
                    iBtnUpdate.Visible      = true;
                    iBtnDelete.Visible      = true;
                    iBtnUsed.Visible        = (this.IKpi_Use_Yn=="N") ? true : false;
                    iBtnAddChildKpi.Visible = (!IsPostBack) ? false : true; ;
                    iBtnAddTarget.Visible   = (!IsPostBack) ? false :true;;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = true;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_recall: // 결재회수
                    iBtnUpdate.Visible      = true;
                    iBtnDelete.Visible      = true;
                    iBtnUsed.Visible        = (this.IKpi_Use_Yn=="N") ? true : false;
                    iBtnAddChildKpi.Visible = true;
                    iBtnAddTarget.Visible   = true;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = true;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_onmodify: // 수정결재
                    iBtnUpdate.Visible      = true;
                    iBtnDelete.Visible      = true;
                    iBtnUsed.Visible        = (this.IKpi_Use_Yn=="N") ? true : false;
                    iBtnAddChildKpi.Visible = true;
                    iBtnAddTarget.Visible   = true;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = true;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    break;
                case Biz_Type.app_status_complete: // 결재완료
                    iBtnUpdate.Visible      = false;
                    iBtnDelete.Visible      = false;
                    iBtnUsed.Visible        = false;
                    iBtnAddChildKpi.Visible = false;
                    iBtnAddTarget.Visible   = false;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReWrite.Visible     = false;
                    iBtnReqModify.Visible   = true;
                    break;
                default:
                    iBtnUpdate.Visible      = false;
                    iBtnDelete.Visible      = false;
                    iBtnUsed.Visible        = false;
                    iBtnAddChildKpi.Visible = false;
                    iBtnAddTarget.Visible   = false;
                    iBtnDraft.Visible       = false;
                    iBtnMoDraft.Visible     = false;
                    iBtnReDraft.Visible     = false;
                    iBtnReqModify.Visible   = false;
                    iBtnReWrite.Visible     = false;
                    break;
            }

            if (this.IChampion_User_YN == "N")
            {
                iBtnInsert.Visible      = false;
                iBtnUpdate.Visible      = false;
                iBtnDelete.Visible      = false;
                iBtnUsed.Visible        = false;
                iBtnAddChildKpi.Visible = false;
                iBtnAddTarget.Visible   = false;
                iBtnDraft.Visible       = false;
                iBtnReDraft.Visible     = false;
                iBtnMoDraft.Visible     = false;
                iBtnReqModify.Visible   = false;
                iBtnReWrite.Visible     = false;
                iBtnBTargetFile_Up.Visible = false;
            }
        }
        else if (this.IType == "D")
        {
            iBtnKpiPoolList.Visible = false;

            iBtnInsert.Visible          = false;
            iBtnUpdate.Visible          = false;
            iBtnDelete.Visible          = false;
            iBtnUsed.Visible            = true;
            iBtnAddChildKpi.Visible     = false;
            iBtnTargetFile_Up.Visible   = false;
            iBtnTargetFile_Down.Visible = false;
            iBtnDraft.Visible           = false;
            iBtnReDraft.Visible         = false;
            iBtnMoDraft.Visible         = false;
            iBtnReqModify.Visible       = false;
            iBtnReWrite.Visible         = false;

            txtKpiCode.ReadOnly         = true;
            txtKpiCode.BackColor        = Color.WhiteSmoke;
            txtKpiCode.Attributes.Remove("onkeydown");
            txtKpiCode.Attributes.Remove("onblur");

            if (this.IChampion_User_YN == "N")
            {
                iBtnInsert.Visible      = false;
                iBtnUpdate.Visible      = false;
                iBtnDelete.Visible      = false;
                iBtnUsed.Visible        = false;
                iBtnAddChildKpi.Visible = false;
                iBtnAddTarget.Visible   = false;
            }
        }
        else
        {
            iBtnInsert.Visible          = false;
            iBtnUpdate.Visible          = false;
            iBtnDelete.Visible          = false;
            iBtnUsed.Visible            = false;
            iBtnAddChildKpi.Visible     = false;
            iBtnAddTarget.Visible       = false;
            iBtnTargetFile_Up.Visible   = false;
            iBtnTargetFile_Down.Visible = true;
            iBtnDraft.Visible           = false;
            iBtnReDraft.Visible         = false;
            txtKpiCode.ReadOnly         = true;
            iBtnDraft.Visible           = false;
            iBtnMoDraft.Visible         = false;
            iBtnReWrite.Visible         = false;
            iBtnReqModify.Visible       = false;
            txtKpiCode.BackColor        = Color.WhiteSmoke;
        }

        // 평가기간이 종료되었거나 결재완료 되었으면 처리불가
        if (this.IYearlyClose_YN == "Y")
        { 
            iBtnInsert.Visible          = false;
            iBtnUpdate.Visible          = false;
            iBtnDelete.Visible          = false;
            iBtnUsed.Visible            = false;
            iBtnAddChildKpi.Visible     = false;
            iBtnAddTarget.Visible       = false;
            iBtnTargetFile_Up.Visible   = false;
            iBtnTargetFile_Down.Visible = false;
            iBtnDraft.Visible           = false;
            iBtnReDraft.Visible         = false;
            iBtnReWrite.Visible         = false;
            iBtnReqModify.Visible       = false;
            return;
        }

        // 어드민인경우 작성중인문서(미작성, 반려) 인경우 해당 문서를 수정가능함
        if (User.IsInRole(ROLE_ADMIN) && (this.IApp_Status=="" || 
                                          this.IApp_Status == Biz_Type.app_status_return ||
                                          this.IApp_Status == Biz_Type.app_status_nodraft || 
                                          this.IApp_Status == Biz_Type.app_status_onmodify ||
                                          this.IApp_Status == Biz_Type.app_status_recall)
           )
        { 
            iBtnInsert.Visible          = (this.IType=="A") ? true : false;
            iBtnUpdate.Visible          = (this.IType=="U" || this.IType=="D") ? true : false;
            iBtnDelete.Visible          = false;
            iBtnUsed.Visible            = false;
            iBtnAddChildKpi.Visible     = false;
            iBtnAddTarget.Visible       = (this.IType=="A") ? false : false;
            iBtnTargetFile_Up.Visible   = true;
            iBtnTargetFile_Down.Visible = false;
            //iBtnDraft.Visible           = (this.IChampion_User_YN=="Y" && this.IApp_Status=="" && this.IApp_Status == Biz_Type.app_status_nodraft) ? true : false;
            //iBtnReWrite.Visible         = (this.IChampion_User_YN=="Y" && this.IApp_Status == Biz_Type.app_status_return) ? true : false;
            //iBtnReqModify.Visible       = false;
        }

        iBtnAddChildKpi.Visible = PageUtility.GetByValueDropDownList(ddlBResultInputType).Equals("KPI");

        iBtnBTargetFile_Down.Visible    =  (hdfTargetReasonFile.Value == "") ? false : true;


        // 골타겟 관련 입력 버튼 (농협에서 추가)
        //iBtnGoalTong.Visible = iBtnAddTarget.Visible;

        //if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
        //    iBtnGoalTong.Visible = true;
    }

    #endregion

    #region KPI 마스터 등록/수정, 지표복사
    public bool ValidateForm()
    {
        if (this.IYearlyClose_YN == "1")
        {
            ltrScript.Text = JSHelper.GetAlertScript("해당평가기간은 년마감처리 되었습니다. 수정할수 없습니다.", false);
            return false;
        }
        else if (hdfBChampionEmpId.Value.Trim() == "" || hdfBChampionEmpId.Value.Trim() == "0")
        {
            ltrScript.Text = JSHelper.GetAlertScript("챔피언을 지정해주십시오.", false);
            return false;
        }
        else if (hdfkpi_target_version_id.Value.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("목표버젼이 존재하지 않습니다.", false);
            return false;
        }
        else if ((this.IType=="U" || this.IType=="D") && txtKpiCode.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("KPI 코드를 입력해주십시오", false);
            return false;
        }
        else if (this.IisTeamKpi == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("지표관리 주체를 알수 없습니다.", false);
            return false;
        }

        //2012.01.27 박효동 : 자화전자요청으로 누적이 누적데이터확인메시지처리, 계획 > 0 && SUM, AVG && 주기 && 누적 = 0
        if (ddlBResultTsCalcType.SelectedItem.Value == "SUM" || ddlBResultTsCalcType.SelectedItem.Value == "AVG")
        {
            bool calcTypeSum = (ddlBResultTsCalcType.SelectedItem.Value == "SUM" ? true : false);
            string mscolumn = string.Empty;
            string tscolumn = string.Empty;
            double tssum = 0;
            int checkcnt = 0;

            if (hdfinitial_version_yn.Value == "Y")
            {
                mscolumn = "MS_PLAN";
                tscolumn = "TS_PLAN";
            }
            else
            {
                mscolumn = "MM_PLAN";
                tscolumn = "TM_PLAN";
            }

            for (int i = 0; i < ugrdBTerm.Rows.Count; i++)
            {
                if (ugrdBPlan.Rows.Count > i)
                {
                    TemplatedColumn colCHECK = (TemplatedColumn)ugrdBTerm.Columns.FromKey("CHECK_YN");
                    CheckBox chkCHECK = (CheckBox)((CellItem)colCHECK.CellItems[ugrdBTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");
                    if (chkCHECK.Checked)
                    {
                        checkcnt++;
                        tssum += DataTypeUtility.GetToDouble(ugrdBPlan.Rows[i].Cells.FromKey(mscolumn).Value);
                        if (calcTypeSum)
                        {
                            if (Math.Round(DataTypeUtility.GetToDouble(ugrdBPlan.Rows[i].Cells.FromKey(tscolumn).Value), 4) != Math.Round(DataTypeUtility.GetToDouble(tssum), 4))
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("누적계획 데이터가 올바르지 않습니다." 
                                    + ugrdBPlan.Rows[i].Cells.FromKey("YMD_DESC").Value.ToString()
                                    + "\\n" + DataTypeUtility.GetToDouble(ugrdBPlan.Rows[i].Cells.FromKey(tscolumn).Value).ToString()
                                    + "\\n" + tssum.ToString()
                                    , false);
                                return false;
                            }
                        }
                        else
                        {
                            if (Math.Round(DataTypeUtility.GetToDouble(ugrdBPlan.Rows[i].Cells.FromKey(tscolumn).Value), 4) != Math.Round(DataTypeUtility.GetToDouble(tssum / checkcnt), 4))
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("누적계획 데이터가 올바르지 않습니다." 
                                    + ugrdBPlan.Rows[i].Cells.FromKey("YMD_DESC").Value.ToString(), false);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (calcTypeSum)
                        {
                            if (Math.Round(DataTypeUtility.GetToDouble(ugrdBPlan.Rows[i].Cells.FromKey(tscolumn).Value), 4) != Math.Round(DataTypeUtility.GetToDouble(tssum), 4))
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("누적계획 데이터가 올바르지 않습니다." + ugrdBPlan.Rows[i].Cells.FromKey("YMD_DESC").Value.ToString(), false);
                                return false;
                            }
                        }
                        else
                        {
                            if (Math.Round(DataTypeUtility.GetToDouble(ugrdBPlan.Rows[i].Cells.FromKey(tscolumn).Value), 4) != (checkcnt == 0 ? 0 : Math.Round(DataTypeUtility.GetToDouble(tssum / checkcnt), 4)))
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("누적계획 데이터가 올바르지 않습니다." + ugrdBPlan.Rows[i].Cells.FromKey("YMD_DESC").Value.ToString(), false);
                                return false;
                            }
                        }
                    }
                }
            }
        }

        return true;
    }

    public bool TxrKpiMaster()
    {
        if (!this.ValidateForm())
        {
            return false;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        objBSC.Iestterm_ref_id            = this.IEstTermRefID;
        objBSC.Ikpi_ref_id                = this.IKpiRefID;
        objBSC.Ikpi_code                  = txtKpiCode.Text;
        objBSC.Ikpi_pool_ref_id           = this.IKpiPoolRefID;
        objBSC.Ikpi_target_version_id     = hdfkpi_target_version_id.Value;
        objBSC.Ikpi_target_setting_reason = txtBTargetReason.Text;
        objBSC.Ikpi_target_reason_file    = hdfTargetReasonFile.Value;
        objBSC.Ichampion_emp_id           = int.Parse(hdfChampionEmpId.Value);
        objBSC.Imeasurement_purpose       = txtBMeasurementPurpose.Text;
        objBSC.Icalc_form_ms              = txtBCalcFormMs.Text;
        objBSC.Icalc_form_ts              = txtBCalcFormTs.Text;
        objBSC.Iword_definition           = txtBWordDefinition.Text;
        objBSC.Irelated_issue             = txtBRelatedIssue.Text;
        objBSC.Iadd_file                  = "";//(fileBDefinition.HasFile) ? fileBDefinition.FileName : linkBDefinition.Text;
        
        objBSC.Imeasurement_emp_id        = (hdfBMeasurementEmpId.Value=="") ? 0 : int.Parse(hdfBMeasurementEmpId.Value);
        //objBSC.Iapproval_emp_id           = (hdfBApprovalEmpId.Value == "") ? 0 : int.Parse(hdfBApprovalEmpId.Value);
        objBSC.Idata_gethering_method     = txtBGetheringMethod.Text;


        objBSC.Iresult_input_type         = PageUtility.GetByValueDropDownList(ddlBResultInputType);
        objBSC.Iresult_term_type          = PageUtility.GetByValueDropDownList(ddlBResultTermType);
        objBSC.Iresult_achievement_type   = PageUtility.GetByValueDropDownList(ddlBResultAchievementType);
        objBSC.Iresult_ts_calc_type       = PageUtility.GetByValueDropDownList(ddlBResultTsCalcType);
        objBSC.Iresult_measurement_step   = PageUtility.GetByValueDropDownList(ddlBResultMeasurementStep);
        objBSC.Imeasurement_grade_type    = PageUtility.GetByValueDropDownList(ddlBMeasurementGradeType);
        objBSC.Iunit_type_ref_id          = PageUtility.GetIntByValueDropDownList(ddlBUnit);
        objBSC.Iapproval_status           = "N";
        objBSC.Igraph_type                = "";
        objBSC.Iapp_ref_id                = this.IApp_Ref_Id;
        objBSC.Iexcel_dnuse               = "N";
        objBSC.Iis_team_kpi               = this.IisTeamKpi;
        objBSC.Iuse_yn                    = "N";
        
        DataSet rtnDS = this.TxrKpiAllData();

        string strRtnMsg = "";
        bool blnRtn = objBSC.TxrKPIMaster
                     (this.IType
                     , objBSC.Iestterm_ref_id
                     , objBSC.Ikpi_ref_id
                     , objBSC.Ikpi_code
                     , objBSC.Ikpi_pool_ref_id
                     , objBSC.Iword_definition
                     , objBSC.Imeasurement_purpose
                     , objBSC.Icalc_form_ms
                     , objBSC.Icalc_form_ts
                     , objBSC.Irelated_issue
                     , objBSC.Iadd_file
                     , objBSC.Ichampion_emp_id
                     , objBSC.Imeasurement_emp_id
                     , objBSC.Iapproval_emp_id
                     , objBSC.Idata_gethering_method
                     , objBSC.Iresult_term_type
                     , objBSC.Iresult_input_type
                     , objBSC.Iresult_achievement_type
                     , objBSC.Iresult_ts_calc_type
                     , objBSC.Iresult_measurement_step
                     , objBSC.Imeasurement_grade_type
                     , objBSC.Iunit_type_ref_id
                     , objBSC.Ikpi_target_version_id
                     , objBSC.Ikpi_target_setting_reason
                     , objBSC.Ikpi_target_reason_file
                     , objBSC.Iapproval_status
                     , objBSC.Igraph_type
                     , objBSC.Iapp_ref_id
                     , objBSC.Iexcel_dnuse
                     , objBSC.Iis_team_kpi
                     , objBSC.Iuse_yn
                     , gUserInfo.Emp_Ref_ID
                     , rtnDS
                     , out strRtnMsg);

        ltrScript.Text = JSHelper.GetAlertScript(strRtnMsg.Replace("'", "").Replace("\r\n", "\\n"), false);

        if (blnRtn)
        {
            if (this.IType == "A")
            {
                this.IKpiRefID       = objBSC.Ikpi_ref_id;
                this.txtKpiCode.Text = objBSC.Ikpi_ref_id.ToString();
                this.IType           = "U";
            }

            this.SetKPIBaseInfo();

            this.IDraftEmpID = int.Parse(hdfBChampionEmpId.Value);
            this.txtChampionEmpName.Text = txtBChampionEmpName.Text;

            this.SetButton();
            this.SetKpiDataSourceGrid();
        }

        return blnRtn;
    }   

    public DataSet TxrKpiAllData()
    { 
        int intRow = 0;
        int intCol = 0;
        DataSet rDS = new DataSet("DS_KPI_MASTER");

        ////////////////////////////////////////////////////
        // KPI DATA SOURCE 
        ////////////////////////////////////////////////////
        intRow = ugrdBDetail.Rows.Count;
        intCol = ugrdBDetail.Columns.Count;
        DataTable rDT1 = new DataTable("BSC_KPI_DATASOURCE");
        rDT1.Columns.Add("ITYPE",              typeof(string));
        rDT1.Columns.Add("ESTTERM_REF_ID",     typeof(int));
        rDT1.Columns.Add("KPI_REF_ID",         typeof(int));
        rDT1.Columns.Add("DATASOURCE_ID",      typeof(int));
        rDT1.Columns.Add("LEVEL1",             typeof(string));
        rDT1.Columns.Add("LEVEL2",             typeof(string));
        rDT1.Columns.Add("LEVEL3",             typeof(string));
        rDT1.Columns.Add("RESULT_SOURCE",      typeof(string));
        rDT1.Columns.Add("TARGET_SOURCE",      typeof(string));
        rDT1.Columns.Add("RESULT_CREATE_TIME", typeof(string));
        rDT1.Columns.Add("UNIT_TYPE_REF_ID",   typeof(int));

        DataRow rDR1;
        DropDownList ddlTempUnit;
        TemplatedColumn unit_col = (TemplatedColumn)ugrdBDetail.Columns.FromKey("UNIT_TYPE_REF_ID");
        
        for (int i = 0; i < intRow; i++)
        { 
            rDR1 = rDT1.NewRow();

            rDR1["ITYPE"]              = (ugrdBDetail.Rows[i].Cells.FromKey("ITYPE").Value == null) ? "X" : ugrdBDetail.Rows[i].Cells.FromKey("ITYPE").Value.ToString();
            rDR1["ESTTERM_REF_ID"]     = (ugrdBDetail.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdBDetail.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR1["KPI_REF_ID"]         = (ugrdBDetail.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)     ? this.IKpiRefID     : int.Parse(ugrdBDetail.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR1["DATASOURCE_ID"]      = (ugrdBDetail.Rows[i].Cells.FromKey("DATASOURCE_ID").Value == null)  ? 0                  : int.Parse(ugrdBDetail.Rows[i].Cells.FromKey("DATASOURCE_ID").Value.ToString()); 
            rDR1["LEVEL1"]             = ugrdBDetail.Rows[i].Cells.FromKey("LEVEL1").Value;
            rDR1["LEVEL2"]             = ugrdBDetail.Rows[i].Cells.FromKey("LEVEL2").Value;
            rDR1["LEVEL3"]             = ugrdBDetail.Rows[i].Cells.FromKey("LEVEL3").Value;
            rDR1["RESULT_SOURCE"]      = ugrdBDetail.Rows[i].Cells.FromKey("RESULT_SOURCE").Value;
            rDR1["TARGET_SOURCE"]      = ugrdBDetail.Rows[i].Cells.FromKey("TARGET_SOURCE").Value;
            rDR1["RESULT_CREATE_TIME"] = ugrdBDetail.Rows[i].Cells.FromKey("RESULT_CREATE_TIME").Value;

            ddlTempUnit = (DropDownList)((CellItem)unit_col.CellItems[ugrdBDetail.Rows[i].BandIndex]).FindControl("ddlDataUnit");

            rDR1["UNIT_TYPE_REF_ID"]   = PageUtility.GetIntByValueDropDownList(ddlTempUnit);

            rDT1.Rows.Add(rDR1);
        }

        ////////////////////////////////////////////////////
        // KPI TERM 
        ////////////////////////////////////////////////////
        intRow = ugrdBTerm.Rows.Count;
        intCol = ugrdBTerm.Columns.Count;
        DataTable rDT2 = new DataTable("BSC_KPI_TERM");

        rDT2.Columns.Add("ITYPE",           typeof(string));
        rDT2.Columns.Add("ESTTERM_REF_ID",  typeof(int));
        rDT2.Columns.Add("KPI_REF_ID",      typeof(int));
        rDT2.Columns.Add("YMD",             typeof(string));
        rDT2.Columns.Add("CHECK_YN",        typeof(string));
        rDT2.Columns.Add("REPORT_YN",       typeof(string));



        DataRow rDR2;
        CheckBox chkCHECK;
        CheckBox chkREPORT;
        TemplatedColumn colCHECK  = (TemplatedColumn)ugrdBTerm.Columns.FromKey("CHECK_YN");
        TemplatedColumn colREPORT = (TemplatedColumn)ugrdBTerm.Columns.FromKey("REPORT_YN");
        for (int i = 0; i < intRow; i++)
        { 
            rDR2 = rDT2.NewRow();

            chkCHECK  = (CheckBox)((CellItem)colCHECK.CellItems[ugrdBTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");
            chkREPORT = (CheckBox)((CellItem)colREPORT.CellItems[ugrdBTerm.Rows[i].BandIndex]).FindControl("chkReportTerm");

            rDR2["ITYPE"]              = (ugrdBTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? "A" : "U";
            rDR2["ESTTERM_REF_ID"]     = (ugrdBTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdBTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR2["KPI_REF_ID"]         = (ugrdBTerm.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)     ? this.IKpiRefID     : int.Parse(ugrdBTerm.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR2["YMD"]                = (ugrdBTerm.Rows[i].Cells.FromKey("YMD").Value == null)            ? ""  : ugrdBTerm.Rows[i].Cells.FromKey("YMD").Value; 
            rDR2["CHECK_YN"]           = chkCHECK.Checked  ? "Y" : "N";
            rDR2["REPORT_YN"]          = chkREPORT.Checked ? "Y" : "N";

            rDT2.Rows.Add(rDR2);
        }

        ////////////////////////////////////////////////////
        // KPI TARGET 
        ////////////////////////////////////////////////////
        intRow = ugrdBPlan.Rows.Count;
        intCol = ugrdBPlan.Columns.Count;
        DataTable rDT3 = new DataTable("BSC_KPI_TARGET");

        string strMS = "";
        string strTS = "";
        int intTargetVersion = (hdfkpi_target_version_id.Value == "") ? 0 : int.Parse(hdfkpi_target_version_id.Value);
        if (hdfinitial_version_yn.Value == "Y")
        {
            strMS = "MS_PLAN";
            strTS = "TS_PLAN";
        }
        else
        {
            strMS = "MM_PLAN";
            strTS = "TM_PLAN";
        }

        rDT3.Columns.Add("ITYPE",                 typeof(string));
        rDT3.Columns.Add("ESTTERM_REF_ID",        typeof(int));
        rDT3.Columns.Add("KPI_REF_ID",            typeof(int));
        rDT3.Columns.Add("KPI_TARGET_VERSION_ID", typeof(int));
        rDT3.Columns.Add("YMD",                   typeof(string));
        rDT3.Columns.Add("TARGET_MS",             typeof(double));
        rDT3.Columns.Add("TARGET_TS",             typeof(double));

        DataRow rDR3;
        for (int i = 0; i < intRow; i++)
        { 
            rDR3 = rDT3.NewRow();

            rDR3["ITYPE"]                 = this.IType; //(ugrdBPlan.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? "A" : "U";
            rDR3["ESTTERM_REF_ID"]        = (ugrdBPlan.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdBPlan.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR3["KPI_REF_ID"]            = (ugrdBPlan.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)     ? this.IKpiRefID     : int.Parse(ugrdBPlan.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR3["KPI_TARGET_VERSION_ID"] = intTargetVersion; //(ugrdBPlan.Rows[i].Cells.FromKey("KPI_TARGET_VERSION_ID").Value == null) ? intTargetVersion : ugrdBPlan.Rows[i].Cells.FromKey("KPI_TARGET_VERSION_ID").Value;
            rDR3["YMD"]                   = (ugrdBPlan.Rows[i].Cells.FromKey("YMD").Value == null)            ? "" : ugrdBPlan.Rows[i].Cells.FromKey("YMD").Value; 
            rDR3["TARGET_MS"]             = (ugrdBPlan.Rows[i].Cells.FromKey(strMS).Value == null)            ? 0  : double.Parse(ugrdBPlan.Rows[i].Cells.FromKey(strMS).Value.ToString());
            rDR3["TARGET_TS"]             = (ugrdBPlan.Rows[i].Cells.FromKey(strTS).Value == null)            ? 0  : double.Parse(ugrdBPlan.Rows[i].Cells.FromKey(strTS).Value.ToString());

            rDT3.Rows.Add(rDR3);
        }

        ////////////////////////////////////////////////////
        // KPI THRESHOLD 
        ////////////////////////////////////////////////////
        intRow = ugrdBSignal.Rows.Count;
        intCol = ugrdBSignal.Columns.Count;
        DataTable rDT4 = new DataTable("BSC_KPI_THRESHOLD_INFO");

        rDT4.Columns.Add("ITYPE",             typeof(string));
        rDT4.Columns.Add("ESTTERM_REF_ID",    typeof(int));
        rDT4.Columns.Add("KPI_REF_ID",        typeof(int));
        rDT4.Columns.Add("THRESHOLD_REF_ID",  typeof(int));
        rDT4.Columns.Add("THRESHOLD_LEVEL",   typeof(string));
        rDT4.Columns.Add("SET_MIN_VALUE",     typeof(double));
        rDT4.Columns.Add("SET_MAX_VALUE",     typeof(double));
        rDT4.Columns.Add("ACHIEVE_RATE",      typeof(double));

        DataRow rDR4;
        for (int i = 0; i < intRow; i++)
        { 
            rDR4 = rDT4.NewRow();

            rDR4["ITYPE"]                 = (ugrdBSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)   ? "A" : "U";
            rDR4["ESTTERM_REF_ID"]        = (ugrdBSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)   ? this.IEstTermRefID : int.Parse(ugrdBSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR4["KPI_REF_ID"]            = (ugrdBSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)       ? this.IKpiRefID     : int.Parse(ugrdBSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR4["THRESHOLD_REF_ID"]      = (ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value == null) ? 0                  : int.Parse(ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value.ToString());
            rDR4["THRESHOLD_LEVEL"]       = (ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value == null)  ? "" : ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value; 
            rDR4["SET_MIN_VALUE"]         = (ugrdBSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value == null)    ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value.ToString());
            rDR4["SET_MAX_VALUE"]         = (ugrdBSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value == null)    ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value.ToString());
            rDR4["ACHIEVE_RATE"]          = (ugrdBSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value == null)     ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value.ToString());

            rDT4.Rows.Add(rDR4);
        }

        ////////////////////////////////////////////////////
        // KPI INITIATIVE 
        ////////////////////////////////////////////////////
        intRow = ugrdBInitiative.Rows.Count;
        intCol = ugrdBInitiative.Columns.Count;
        DataTable rDT5 = new DataTable("BSC_KPI_INITIATIVE");

        rDT5.Columns.Add("ITYPE",             typeof(string));
        rDT5.Columns.Add("ESTTERM_REF_ID",    typeof(int));
        rDT5.Columns.Add("KPI_REF_ID",        typeof(int));
        rDT5.Columns.Add("YMD",               typeof(string));
        rDT5.Columns.Add("INITIATIVE_PLAN",   typeof(string));
        rDT5.Columns.Add("INITIATIVE_DO",     typeof(string));
        rDT5.Columns.Add("INITIATIVE_DESC",   typeof(string));

        TemplatedColumn tmcPL = null;
        TemplatedColumn tmcDO = null;
        TemplatedColumn tmcDE = null;

        TextBox txtPL = null;
        TextBox txtDO = null;
        TextBox txtDE = null;

        DataRow rDR5;
        for (int i = 0; i < intRow; i++)
        { 
            rDR5 = rDT5.NewRow();

            tmcPL = (TemplatedColumn)ugrdBInitiative.Rows[i].Band.Columns.FromKey("INITIATIVE_PLAN");
            tmcDO = (TemplatedColumn)ugrdBInitiative.Rows[i].Band.Columns.FromKey("INITIATIVE_DO");
            tmcDE = (TemplatedColumn)ugrdBInitiative.Rows[i].Band.Columns.FromKey("INITIATIVE_DESC");

            txtPL = (TextBox)((CellItem)tmcPL.CellItems[ugrdBInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_PLAN");
            txtDO = (TextBox)((CellItem)tmcDO.CellItems[ugrdBInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DO");
            txtDE = (TextBox)((CellItem)tmcDE.CellItems[ugrdBInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DESC");

            rDR5["ITYPE"]             = "A";
            rDR5["ESTTERM_REF_ID"]    = (ugrdBInitiative.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)   ? this.IEstTermRefID : int.Parse(ugrdBInitiative.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR5["KPI_REF_ID"]        = (ugrdBInitiative.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)       ? this.IKpiRefID     : int.Parse(ugrdBInitiative.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR5["YMD"]               = (ugrdBInitiative.Rows[i].Cells.FromKey("YMD").Value == null)              ? "000000"           : ugrdBInitiative.Rows[i].Cells.FromKey("YMD").Value.ToString();
            rDR5["INITIATIVE_PLAN"]   = txtPL.Text; //(ugrdBInitiative.Rows[i].Cells.FromKey("INITIATIVE_PLAN").Value == null)  ? ""                 : ugrdBInitiative.Rows[i].Cells.FromKey("INITIATIVE_PLAN").Value; 
            rDR5["INITIATIVE_DO"]     = txtDO.Text; //(ugrdBInitiative.Rows[i].Cells.FromKey("INITIATIVE_DO").Value == null)    ? ""                 : ugrdBInitiative.Rows[i].Cells.FromKey("INITIATIVE_DO").Value.ToString();
            rDR5["INITIATIVE_DESC"]   = txtDE.Text; //(ugrdBInitiative.Rows[i].Cells.FromKey("INITIATIVE_DESC").Value == null)  ? ""                 : ugrdBInitiative.Rows[i].Cells.FromKey("INITIATIVE_DESC").Value.ToString();

            rDT5.Rows.Add(rDR5);
        }

        ////////////////////////////////////////////////////
        // KPI QLT TERM WEIGHT 
        ////////////////////////////////////////////////////
        intRow = ugrdBQuestionTerm.Rows.Count;
        intCol = ugrdBQuestionTerm.Columns.Count;
        DataTable rDT6 = new DataTable("BSC_KPI_QLT_TERM_WEIGHT");

        rDT6.Columns.Add("ITYPE",             typeof(string));
        rDT6.Columns.Add("ESTTERM_REF_ID",    typeof(int));
        rDT6.Columns.Add("KPI_REF_ID",        typeof(int));
        rDT6.Columns.Add("YMD",               typeof(string));
        rDT6.Columns.Add("EST_LEVEL",         typeof(int));
        rDT6.Columns.Add("WEIGHT",            typeof(double));

        DataRow rDR6;
        for (int i = 0; i < intRow; i++)
        { 
            rDR6 = rDT6.NewRow();

            rDR6["ITYPE"]          = "A";
            rDR6["ESTTERM_REF_ID"] = (ugrdBQuestionTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : Convert.ToInt32(ugrdBQuestionTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR6["KPI_REF_ID"]     = (ugrdBQuestionTerm.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)     ? this.IKpiRefID     : Convert.ToInt32(ugrdBQuestionTerm.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR6["YMD"]            = (ugrdBQuestionTerm.Rows[i].Cells.FromKey("YMD").Value == null)            ? "000000"           : ugrdBQuestionTerm.Rows[i].Cells.FromKey("YMD").Value.ToString();
            rDR6["EST_LEVEL"]      = (ugrdBQuestionTerm.Rows[i].Cells.FromKey("EST_LEVEL").Value == null)      ? 0                  : Convert.ToInt32(ugrdBQuestionTerm.Rows[i].Cells.FromKey("EST_LEVEL").Value); 
            rDR6["WEIGHT"]         = (ugrdBQuestionTerm.Rows[i].Cells.FromKey("WEIGHT").Value == null)         ? 0                  : Convert.ToDouble(ugrdBQuestionTerm.Rows[i].Cells.FromKey("WEIGHT").Value.ToString());

            rDT6.Rows.Add(rDR6);
        }


        rDS.Tables.Add(rDT1);
        rDS.Tables.Add(rDT2);
        rDS.Tables.Add(rDT3);
        rDS.Tables.Add(rDT4);
        rDS.Tables.Add(rDT5);
        rDS.Tables.Add(rDT6);

        return rDS;

    }

    /// <summary>
    /// 지표코드가 존재하는지 존재한다면 어느 평가기간에 있는지
    /// </summary>
    public void GetExistsKpiCode()
    { 
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiCodeForInsert(this.IEstTermRefID, this.txtKpiCode.Text.Trim().ToUpper());

        if (rDs.Tables[0].Rows.Count > 0)
        {
            string estterm_id   = rDs.Tables[0].Rows[0]["ESTTERM_REF_ID"].ToString();
            string estterm_name = rDs.Tables[0].Rows[0]["ESTTERM_NAME"].ToString();
            string kpi_name     = rDs.Tables[0].Rows[0]["KPI_NAME"].ToString();
            string is_same_term = rDs.Tables[0].Rows[0]["IS_SAME_ESTTERM"].ToString();

            if (is_same_term == "Y")
            {
                ltrScript.Text = @"<script language=javascript>
                                      alert('동일한 코드가 동일 평가기간에 존재합니다.');
                                      document.forms[0]." + txtKpiCode.ClientID.Replace('$', '_') + @".focus();
                                      document.forms[0]." + txtKpiCode.ClientID.Replace('$', '_') + @".value='';
                                  </script>";
            }
            else
            { 
                ltrScript.Text = @"<script language=javascript>
                                  if (confirm('입력한 코드의 지표가 "+estterm_name+@"에 존재합니다. 지표를 복사 하시겠습니까?'))
                                  {
                                      __doPostBack('iBtnKpiCopy', '');
                                  }
                                  else
                                  {
                                      document.forms[0]." + txtKpiCode.ClientID.Replace('$', '_') + @".focus();
                                      document.forms[0]." + txtKpiCode.ClientID.Replace('$', '_') + @".value='';
                                  }
                               </script>";
            }
        }
        else
        {
                ltrScript.Text = @"<script language=javascript>
                                      document.forms[0]." + txtKpiCode.ClientID.Replace('$', '_') + @".blur();
                                  </script>";
        }
    }

    /// <summary>
    /// 지표기본정보 복사
    /// </summary>
    public void SetCopyKpiInfo()
    { 
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiCodeForInsert(this.IEstTermRefID, this.txtKpiCode.Text.Trim().ToUpper());

        if (rDs.Tables[0].Rows.Count > 0)
        {
            string estterm_id   = rDs.Tables[0].Rows[0]["ESTTERM_REF_ID"].ToString();
            string estterm_name = rDs.Tables[0].Rows[0]["ESTTERM_NAME"].ToString();
            int    kpi_ref_id   = Convert.ToInt32(rDs.Tables[0].Rows[0]["KPI_REF_ID"].ToString());
            string kpi_name     = rDs.Tables[0].Rows[0]["KPI_NAME"].ToString();
            string is_same_term = rDs.Tables[0].Rows[0]["IS_SAME_ESTTERM"].ToString();

            // 지표코드가 다른 평가기간에 존재하면
            if (is_same_term == "N")
            { 
                DataTable dt = new DataTable("tblKpiCopyList");
                dt.Columns.Add("ESTTERM_REF_ID_FR" , typeof(int));
                dt.Columns.Add("KPI_REF_ID"        , typeof(int));
                dt.Columns.Add("ESTTERM_REF_ID_TO" , typeof(int));
                dt.Columns.Add("TXR_USER"          , typeof(int));
                DataRow dr = dt.NewRow();

                dr["ESTTERM_REF_ID_FR"] = Convert.ToInt32(estterm_id);
                dr["KPI_REF_ID"]        = kpi_ref_id;
                dr["ESTTERM_REF_ID_TO"] = this.IEstTermRefID;
                dr["TXR_USER"]          = gUserInfo.Emp_Ref_ID;

                dt.Rows.Add(dr);

                int intRtn    = objBSC.CopyKpiToAnotherTerm(dt);
                if (intRtn == 1)
                {
                    this.IType     = "U";
                    this.IKpiRefID = kpi_ref_id;
                    this.NotPostBackSetting();
                    ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.", false);
                }
                else
                {
                    ltrScript.Text = JSHelper.GetAlertScript("처리시 오류가 발생되었습니다.", false);
                }
            }
        }
    }
    #endregion

    #region ================================= [ 실적누계계산 관련 메소드 ]======================
    // isAddTargetYN : 목표가 추가되어 그리드다시세팅여부
    // isCalcYN      : 산식에 의해 셀계산할것인지 여부
    private void SetTermToTarget(bool isAddTargetYN, bool isCalcYN)
    {
        if (ugrdBPlan.Rows.Count < 1)
        {
            return;
        }

        int intCol          = ugrdBTerm.Columns.Count;
        int intRow          = ugrdBTerm.Rows.Count;
        int intChkRow       = 0;
        string strMS_PLAN   = "";
        string strTS_PLAN   = "";
        string strCheck     = "";
        double dblTot       = 0.00;
        string _icheck_term = "";
        string strCloseYn   = "";


        if (!isAddTargetYN)
        {
            //this.SetKPIBaseInfo();
        }

        ugrdBPlan.Columns.FromKey("YMD_DESC").AllowUpdate = AllowUpdate.No;
        ugrdBPlan.Columns.FromKey("YMD_DESC").CellStyle.BackColor = Color.WhiteSmoke;
        if (this.hdfinitial_version_yn.Value == "Y")
        {
            strMS_PLAN   = "MS_PLAN";
            strTS_PLAN   = "TS_PLAN";
            strCheck     = "ORI_CHECK_YN";
            ugrdBPlan.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdBPlan.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdBPlan.Columns.FromKey("MM_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdBPlan.Columns.FromKey("TM_PLAN").AllowUpdate = AllowUpdate.No;

            ugrdBPlan.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.White;
            ugrdBPlan.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.White;
            ugrdBPlan.Columns.FromKey("MM_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdBPlan.Columns.FromKey("TM_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
        }
        else
        {
            strMS_PLAN   = "MM_PLAN";
            strTS_PLAN   = "TM_PLAN";
            strCheck     = "MOD_CHECK_YN";
            ugrdBPlan.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdBPlan.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdBPlan.Columns.FromKey("MM_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdBPlan.Columns.FromKey("TM_PLAN").AllowUpdate = AllowUpdate.Yes;

            ugrdBPlan.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdBPlan.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdBPlan.Columns.FromKey("MM_PLAN").CellStyle.BackColor = Color.White;
            ugrdBPlan.Columns.FromKey("TM_PLAN").CellStyle.BackColor = Color.White;
        }

        CheckBox chkCheck;
        TemplatedColumn Col_Check;
        for (int i = 0; i < intRow; i++)
        {
            _icheck_term = "";

            Col_Check    = (TemplatedColumn)ugrdBTerm.Columns.FromKey("CHECK_YN");
            chkCheck     = (CheckBox)((CellItem)Col_Check.CellItems[ugrdBTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");
            _icheck_term = (chkCheck.Checked) ? "Y" : "N";
            strCloseYn   = ugrdBTerm.Rows[i].Cells.FromKey("CLOSE_YN").Value.ToString();

            if (_icheck_term == "Y")
            {
                dblTot += double.Parse(ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value.ToString());
                intChkRow += 1;
            }


            if (ugrdBPlan.Rows[i] != null)
            {
                ugrdBPlan.Rows[i].Cells.FromKey(strCheck).Value = _icheck_term;

                if (strCloseYn == "Y")
                {
                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing    = AllowEditing.No;
                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing    = AllowEditing.No;
                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = Color.WhiteSmoke;
                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    if (_icheck_term == "N")
                    {
                        ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing    = AllowEditing.No;
                        ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing    = AllowEditing.No;
                        ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = Color.WhiteSmoke;
                        ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = Color.WhiteSmoke;
                        ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value           = 0;
                        ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value           = 0;

                        switch (PageUtility.GetByValueDropDownList(ddlBResultTsCalcType))
                        {
                            case "SUM": // 단순합계
                                ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = Math.Round(dblTot, 5);
                                break;
                            case "AVG": // 단순평균
                                ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (this.hdfinitial_version_yn.Value == "Y")
                        {
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing    = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing    = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.White;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.White;

                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").AllowEditing    = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").AllowEditing    = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").Style.BackColor = Color.WhiteSmoke;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").Style.BackColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing    = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing    = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.WhiteSmoke;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.WhiteSmoke;

                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").AllowEditing    = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").AllowEditing    = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").Style.BackColor = Color.White;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").Style.BackColor = Color.White;
                        }

                        if (isCalcYN)
                        {
                            switch (PageUtility.GetByValueDropDownList(ddlBResultTsCalcType))
                            {
                                case "SUM": // 단순합계
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value           = Math.Round(dblTot, 5);
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing    = AllowEditing.No;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "AVG": // 단순평균
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value           = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing    = AllowEditing.No;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "OTS": // 누적만측정
                                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing    = AllowEditing.No;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing    = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value           = 0;
                                    break;
                                default:
                                    //ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value          = 0;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing    = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region ================================= [ Data Select ]===================================
    /// <summary>
    /// 지표기본정보 세팅
    /// </summary>
    private void SetKPIMaster()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        txtBCalcFormMs.Text                     = objBSC.Icalc_form_ms;               
        txtBCalcFormTs.Text                     = objBSC.Icalc_form_ts;
        this.IDraftEmpID                        = objBSC.Ichampion_emp_id;
        hdfBChampionEmpId.Value                 = objBSC.Ichampion_emp_id.ToString();
        txtBChampionEmpName.Text                = objBSC.Ichampion_emp_name;          
        //hdfBApprovalEmpId.Value                 = objBSC.Iapproval_emp_id.ToString(); 
        //txtBApprovalEmpName.Text                = objBSC.Iapproval_emp_name;
        hdfBMeasurementEmpId.Value              = objBSC.Imeasurement_emp_id.ToString();
        txtBMeasurementEmpName.Text             = objBSC.Imeasurement_emp_name;                
        txtBGetheringMethod.Text                = objBSC.Idata_gethering_method;      
        txtBRelatedIssue.Text                   = objBSC.Irelated_issue;              
        txtKpiCode.Text                         = objBSC.Ikpi_code;                   
        txtBMeasurementPurpose.Text             = objBSC.Imeasurement_purpose;        
        txtBWordDefinition.Text                 = objBSC.Iword_definition;
        ddlBResultInputType.SelectedValue       = objBSC.Iresult_input_type;
        ddlBResultAchievementType.SelectedValue = objBSC.Iresult_achievement_type;
        ddlBResultTsCalcType.SelectedValue      = objBSC.Iresult_ts_calc_type;
        ddlBMeasurementGradeType.SelectedValue  = objBSC.Imeasurement_grade_type;
        ddlBResultMeasurementStep.SelectedValue = objBSC.Iresult_measurement_step;
        ddlBUnit.SelectedValue                  = objBSC.Iunit_type_ref_id.ToString();
        ddlBResultTermType.SelectedValue        = objBSC.Iresult_term_type;
        txtBTargetReason.Text                   = objBSC.Ikpi_target_setting_reason;
        hdfTargetReasonFile.Value               = objBSC.Ikpi_target_reason_file;
        this.IApp_Ref_Id                        = objBSC.Iapp_ref_id;
        this.IKpi_Use_Yn                        = objBSC.Iuse_yn;

        this.IKpiPoolRefID                      = objBSC.Ikpi_pool_ref_id;
        if (objBSC.Iuse_yn == "N")
        {
            this.IType = "D";
        }

        iBtnBTargetFile_Down.Visible = (objBSC.Ikpi_target_reason_file == "") ? false : true;
        this.SetKpiPoolInfo();
    }

    /// <summary>
    /// 지표풀정보 세팅
    /// </summary>
    private void SetKpiPoolInfo()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objPool = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        lblKpiType.Text = objPool.Ikpi_external_type_name + "/" + objPool.Ikpi_type_name;
        this.IKpiGroup       = objPool.Ikpi_type;
        this.IBasis_Use_Yn   = objPool.Ibasis_use_yn;
        this.txtKpiName.Text = objPool.Ikpi_name;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objL = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low(objPool.Icategory_top_ref_id, objPool.Icategory_mid_ref_id, objPool.Icategory_low_ref_id);
        this.lblKpiCatName.Text = objL.Icategory_top_name + " / " + objL.Icategory_mid_name + " / " +objL.Icategory_low_name;

        // 공공기관용
        //this.ugrdKpiStatusTab.Tabs.FromKey("5").Visible = (this.IBasis_Use_Yn == "EQL") ? true : false;    // 정성지표인경우 
    }

    /// <summary>
    /// 데이터원천정보 그리드세팅
    /// </summary>
    private void SetKpiDataSourceGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Datasource objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Datasource();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID);
        ugrdBDetail.Clear();
        ugrdBDetail.DataSource = rDs;
        ugrdBDetail.DataBind();
    }

    /// <summary>
    /// 목표 조회
    /// </summary>
    private void SetKpiTargetGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Target objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Target();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID, 1);
        ugrdBPlan.Clear();
        ugrdBPlan.DataSource = rDs;
        ugrdBPlan.DataBind();
    }

    /// <summary>
    /// 목표버젼 조회
    /// </summary>
    private void SetKpiNewTargetGrid()
    {
        int intTargetVersion = (hdfkpi_target_version_id.Value == "") ? 1 : int.Parse(hdfkpi_target_version_id.Value);

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Target objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Target();
        DataSet rDs = (intTargetVersion > 1) ? 
                      objBSC.GetNewTargetList(this.IEstTermRefID, this.IKpiRefID, intTargetVersion) :
                      objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID, intTargetVersion);
        ugrdBPlan.Clear();
        ugrdBPlan.DataSource = rDs;
        ugrdBPlan.DataBind();
    }

    /// <summary>
    /// 등급구간 조회
    /// </summary>
    private void SetKpiSignalGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Threshold_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Threshold_Info();
        //DataSet dsSignal = objBSC.GetSignalListPerKpi(this.IEstTermRefID, this.IKpiRefID, ddlBResultMeasurementStep.SelectedValue);
        DataSet dsSignal = objBSC.GetSignalListPerKpiWithBiz(this.IEstTermRefID, this.IKpiRefID, ddlBResultMeasurementStep.SelectedValue);

        ugrdSignal.Clear();
        ugrdSignal.Rows.Clear();
        ugrdSignal.DataSource = dsSignal;
        ugrdSignal.DataBind();
        //this.drawPoint();

        startYY = 0;
        DataSet dsTRStatus = objBSC.GetTargetResultPerYear(this.IEstTermRefID, this.IKpiRefID, out startYY);
        ugrdTRStatus.Clear();
        ugrdTRStatus.DataSource = dsTRStatus;
        ugrdTRStatus.DataBind();
    }

    /// <summary>
    /// 측정주기 조회
    /// </summary>
    private void SetKpiTermGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID);
        ugrdBTerm.DataSource = rDs;
        ugrdBTerm.DataBind();
    }

    /// <summary>
    /// 비계량지표
    /// </summary>
    private void GetKpiQltTermList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Term_Weight objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Term_Weight();
        DataSet rDs = objBSC.GetKpiQualityTermWeight(this.IEstTermRefID, this.IKpiRefID, 0);

        ugrdBQuestionTerm.Clear();
        ugrdBQuestionTerm.DataSource = rDs;
        ugrdBQuestionTerm.DataBind();

        this.SetKpiQltTermListRow();
    }

    /// <summary>
    /// 월별 비계량지표가중치 조회
    /// </summary>
    private void SetKpiQltTermListRow()
    { 
        int intRow     = ugrdBQuestionTerm.Rows.Count;
        int intTermRow = ugrdBTerm.Rows.Count;

        string strQTermYmd = "";
        string strETermYmd = "";
        string strECheckYN = "";
        string strCloseYn  = "";
        CheckBox chkCheck;
        TemplatedColumn Col_Check;

        for (int i = 0; i < intRow; i++)
        {
            ugrdBQuestionTerm.Rows[i].Hidden = true;
            strETermYmd = ugrdBQuestionTerm.Rows[i].Cells.FromKey("YMD").Value.ToString();
            for (int j = 0; j < intTermRow; j++)
            {
                strQTermYmd   = (ugrdBTerm.Rows[j].Cells.FromKey("YMD").Value != null) ? ugrdBTerm.Rows[j].Cells.FromKey("YMD").Value.ToString() : "000000";
                Col_Check     = (TemplatedColumn)ugrdBTerm.Columns.FromKey("CHECK_YN");
                chkCheck      = (CheckBox)((CellItem)Col_Check.CellItems[ugrdBTerm.Rows[j].BandIndex]).FindControl("chkCheckTerm");
                strECheckYN   = (chkCheck.Checked) ? "Y" : "N";
                strCloseYn    = (ugrdBTerm.Rows[j].Cells.FromKey("CLOSE_YN").Value !=null)  ? ugrdBTerm.Rows[j].Cells.FromKey("CLOSE_YN").Value.ToString() : "N";

                if (strCloseYn == "Y")
                {
                    strECheckYN = "N";
                }

                if ((strETermYmd == strQTermYmd) && (strECheckYN == "Y"))
                {
                    ugrdBQuestionTerm.Rows[i].Hidden = false;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 평가차수 조회
    /// </summary>
    private void SetEstLevelList()
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Info();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);
        
        ugrdBEstLevel.Clear();
        ugrdBEstLevel.DataSource = rDs;
        ugrdBEstLevel.DataBind();
    }

    /// <summary>
    /// 이니셔티브 리스트
    /// </summary>
    private void SetInitiativeList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative();
        DataSet rDs = objBSC.GetKpiInitaitive(this.IEstTermRefID, this.IKpiRefID);
        
        ugrdBInitiative.Clear();
        ugrdBInitiative.DataSource = rDs;
        ugrdBInitiative.DataBind();
    }

    /// <summary>
    /// 관련프로젝트
    /// </summary>
    private void SetProjectList()
    {
        MicroBSC.PRJ.Biz.Biz_Bsc_Kpi_Prj objBSC = new MicroBSC.PRJ.Biz.Biz_Bsc_Kpi_Prj();
        DataSet rDs = objBSC.GetKpiCodePrjectList(this.IEstTermRefID, this.IKpiRefID);

        ugrdBPrjList.Clear();
        ugrdBPrjList.DataSource = rDs;
        ugrdBPrjList.DataBind();
    }

    /// <summary>
    /// 이니셔티브 월별 입력
    /// </summary>
    private void SetInitiativeRow()
    { 
        int intRow     = ugrdBInitiative.Rows.Count;
        int intTermRow = ugrdBTerm.Rows.Count;

        string strQTermYmd = "";
        string strETermYmd = "";
        string strECheckYN = "";
        string strCloseYn  = "";
        CheckBox chkCheck;
        TemplatedColumn Col_Check;

        TemplatedColumn tmcPL ; 
        TemplatedColumn tmcDO;
        TemplatedColumn tmcDE; 

        TextBox txtPL;
        TextBox txtDO; 
        TextBox txtDE ;


        for (int i = 0; i < intRow; i++)
        {
            ugrdBInitiative.Rows[i].Hidden = true;
            strETermYmd = ugrdBInitiative.Rows[i].Cells.FromKey("YMD").Value.ToString();
            for (int j = 0; j < intTermRow; j++)
            {
                strQTermYmd   = (ugrdBTerm.Rows[j].Cells.FromKey("YMD").Value != null) ? ugrdBTerm.Rows[j].Cells.FromKey("YMD").Value.ToString() : "000000";
                Col_Check     = (TemplatedColumn)ugrdBTerm.Columns.FromKey("CHECK_YN");
                chkCheck      = (CheckBox)((CellItem)Col_Check.CellItems[ugrdBTerm.Rows[j].BandIndex]).FindControl("chkCheckTerm");
                strECheckYN   = (chkCheck.Checked) ? "Y" : "N";
                strCloseYn    = (ugrdBTerm.Rows[j].Cells.FromKey("CLOSE_YN").Value !=null)  ? ugrdBTerm.Rows[j].Cells.FromKey("CLOSE_YN").Value.ToString() : "N";

                tmcPL = (TemplatedColumn)ugrdBInitiative.Columns.FromKey("INITIATIVE_PLAN");
                tmcDO = (TemplatedColumn)ugrdBInitiative.Columns.FromKey("INITIATIVE_DO");
                tmcDE = (TemplatedColumn)ugrdBInitiative.Columns.FromKey("INITIATIVE_DESC");

                txtPL = (TextBox)((CellItem)tmcPL.CellItems[ugrdBInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_PLAN");
                txtDO = (TextBox)((CellItem)tmcDO.CellItems[ugrdBInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DO");
                txtDE = (TextBox)((CellItem)tmcDE.CellItems[ugrdBInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DESC");

                //if (strCloseYn == "Y")
                //{
                //    strECheckYN = "N";
                //}

                if ((strETermYmd == strQTermYmd) && (strECheckYN == "Y"))
                {
                    ugrdBInitiative.Rows[i].Hidden = false;
                    txtPL.Enabled = true;
                    txtDO.Enabled = true;
                    txtDE.Enabled = true;

                    break;
                }
            }
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
        this.IApp_Status = objApp.IApp_Status;
        this.IApp_Status_Name = objApp.IApp_Status_Name;

        iBtnDraft.OnClientClick     = "return OpenDraft('" + Biz_Type.app_draft_first +"');";
        iBtnReDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_redraft + "');";
        iBtnReWrite.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_rewrite + "');";
        iBtnMoDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_modify + "');";
        iBtnReqModify.OnClientClick = "return isMoDraftMsg();";
        ImgBtnPrint.OnClientClick   = "return OpenDraftPrint('"+ Biz_Type.app_draft_select +"')";
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
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objApp.Transaction_Message, false);
        }
    }

    #endregion

    #region ================================= [ 그래프 그리기 ]=================================
    private void drawPoint()
    {
        DataSet idsSet = new DataSet();
        ////////////////////////////////////////////////////
        // KPI THRESHOLD 
        ////////////////////////////////////////////////////
        int intRow = ugrdBSignal.Rows.Count;
        int intCol = ugrdBSignal.Columns.Count;
        DataTable rDT4 = new DataTable("BSC_KPI_THRESHOLD_INFO");

        rDT4.Columns.Add("ITYPE",             typeof(string));
        rDT4.Columns.Add("ESTTERM_REF_ID",    typeof(int));
        rDT4.Columns.Add("KPI_REF_ID",        typeof(int));
        rDT4.Columns.Add("THRESHOLD_REF_ID",  typeof(int));
        rDT4.Columns.Add("THRESHOLD_LEVEL",   typeof(string));
        rDT4.Columns.Add("SET_MIN_VALUE",     typeof(double));
        rDT4.Columns.Add("SET_MAX_VALUE",     typeof(double));
        rDT4.Columns.Add("ACHIEVE_RATE",      typeof(double));
        rDT4.Columns.Add("POINT",             typeof(double));

        DataRow rDR4;
        for (int i = 0; i < intRow; i++)
        { 
            rDR4 = rDT4.NewRow();

            rDR4["ITYPE"]                 = (ugrdBSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)   ? "A" : "U";
            rDR4["ESTTERM_REF_ID"]        = (ugrdBSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)   ? this.IEstTermRefID : int.Parse(ugrdBSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR4["KPI_REF_ID"]            = (ugrdBSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)       ? this.IKpiRefID     : int.Parse(ugrdBSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR4["THRESHOLD_REF_ID"]      = (ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value == null) ? 0                  : int.Parse(ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value.ToString());
            rDR4["THRESHOLD_LEVEL"]       = (ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value == null)  ? "" : ugrdBSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value; 
            rDR4["SET_MIN_VALUE"]         = (ugrdBSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value == null)    ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value.ToString());
            rDR4["SET_MAX_VALUE"]         = (ugrdBSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value == null)    ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value.ToString());
            rDR4["ACHIEVE_RATE"]          = (ugrdBSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value == null)     ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value.ToString());
            rDR4["POINT"]                 = (ugrdBSignal.Rows[i].Cells.FromKey("POINT").Value == null)            ? 0  : double.Parse(ugrdBSignal.Rows[i].Cells.FromKey("POINT").Value.ToString());

            rDT4.Rows.Add(rDR4);
        }

        idsSet.Tables.Add(rDT4);

        MSCharts.DundasChartBase(chartBScore, ChartImageType.Jpeg, 400, 280
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

        string strRate  = "";
        double dblPoint = 0;
        int cntRow      = idsSet.Tables[0].Rows.Count;

        Series series1 = MSCharts.CreateSeries(chartBScore, "Series1", "Default", "평가 Graph", null, ((this.IScoreValuationType == "SLP") ? SeriesChartType.Line : SeriesChartType.StepLine), 2, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        chartBScore.ChartAreas["Default"].AxisX.Title = "달성율";
        chartBScore.ChartAreas["Default"].AxisY.Title = "획득점수";

        if (ddlBResultAchievementType.SelectedValue == "ATY") // 증가형
        {
            for (int i = 0; i < cntRow; i++)
            {
                strRate  = double.Parse(idsSet.Tables[0].Rows[cntRow - (i + 1)]["ACHIEVE_RATE"].ToString()).ToString("#,##0");
                dblPoint = double.Parse(idsSet.Tables[0].Rows[cntRow - (i + 1)]["POINT"].ToString());
                chartBScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
            }
        }
        else if (ddlBResultAchievementType.SelectedValue == "BTY") // 감소형
        {
            if (this.IScoreValuationType == "SLP")
            {
                for (int i = 0; i < cntRow; i++)
                {
                    strRate  = double.Parse(idsSet.Tables[0].Rows[i]["ACHIEVE_RATE"].ToString()).ToString("#,##0");
                    dblPoint = double.Parse(idsSet.Tables[0].Rows[i]["POINT"].ToString());
                    chartBScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
                }
            }
            else
            {
                strRate  = double.Parse(idsSet.Tables[0].Rows[0]["ACHIEVE_RATE"].ToString()) + "이하";
                dblPoint = double.Parse(idsSet.Tables[0].Rows[0]["POINT"].ToString());
                chartBScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);

                int j = 0;
                for (int i = 0; i < cntRow; i++)
                {
                    j = (i == cntRow - 1) ? i : i + 1;
                    strRate  = double.Parse(idsSet.Tables[0].Rows[i]["ACHIEVE_RATE"].ToString()).ToString("#,##0");
                    dblPoint = double.Parse(idsSet.Tables[0].Rows[j]["POINT"].ToString());
                    chartBScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
                }
            }

            chartBScore.ChartAreas["Default"].AxisX.Title = "한계초과율";
        }
        else if (ddlBResultAchievementType.SelectedValue == "CTY") // Zero 형
        {
            for (int i = 0; i < cntRow; i++)
            {
                strRate = double.Parse(idsSet.Tables[0].Rows[i]["SET_MIN_VALUE"].ToString()).ToString("#,##0");
                dblPoint = double.Parse(idsSet.Tables[0].Rows[i]["POINT"].ToString());
                chartBScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
            }
        }
    }

    private void drawGrade()
    {
        MSCharts.DundasChartBase(chartBTarget, ChartImageType.Jpeg, 400, 205
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

        startYY = 0;
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Threshold_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Threshold_Info();
        DataSet dsLine = objBSC.GetTargetPerGrade(this.IEstTermRefID, this.IKpiRefID, out startYY);
        int cntRow     = dsLine.Tables[0].Rows.Count;
        int cntCol     = dsLine.Tables[0].Columns.Count;

        if (startYY < 1)
        {
            return;
        }

        try
        {
            //================================================================== LINE GRAPH
            int idxCol = 0;
            for (int i = cntCol - 1; i > 0; i--)
            {
                dsLine.Tables[0].Columns[i].ColumnName = dsLine.Tables[0].Columns[i].ColumnName.Substring(0, 2) == "YY"
                                                       ? Convert.ToString(startYY) + "년"
                                                       : dsLine.Tables[0].Columns[i].ColumnName;

                startYY = startYY - 1;
            }

            Series[] oasrType = new Series[cntRow];
            int intLP = 0;


            for (int i = 0; i < cntRow; i++)
            {
                oasrType[intLP] = MSCharts.CreateSeries
                                 (chartBTarget, "Series" + intLP.ToString(), chartBTarget.ChartAreas[0].Name,
                                  dsLine.Tables[0].Rows[i]["THRESHOLD_ENAME"].ToString(), null, (i == 0) ? SeriesChartType.Column : SeriesChartType.Line, (i == 0) ? 0 : 3,
                                  (intLP == 0) ? Color.Blue : GetSignalColor(intLP - 1), GetChartColor(intLP),
                                  Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

                for (int j = 2; j < cntCol; j++)
                {
                    oasrType[intLP].Points.AddXY(dsLine.Tables[0].Columns[j].ColumnName
                                                , double.Parse(dsLine.Tables[0].Rows[i][j].ToString()));
                }

                intLP += 1;
            }

            if (intLP > 0)
            {
                //oasrType[intLP - 1].ValueMemberX = "THRESHOLD_ENAME";
                oasrType[intLP - 1].XValueMember = "THRESHOLD_ENAME";
            }

            chartBTarget.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
            chartBTarget.ChartAreas[0].AxisY2.LabelStyle.Format = "P0";

        }
        catch(Exception ex)
        {
            string rtnMsg = ex.Message;
        }
    }

    #endregion

    #region ================================= [ 엑셀다운로드  ] ============================
    /// <summary>
    /// 엑셀 다운로드
    /// </summary>
    private void ExcelDownLoad()
    {
        string strCurDate = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');
       
        ugrdEEP.ExportMode = ExportMode.Download;
        ugrdEEP.DownloadName = "KPI_DefineDoc" + strCurDate + ".xls";

        this.AddWorkSheet(); // Sheet추가
    }

    /// <summary>
    /// Tab페이지별 엑셀Sheet 추가
    /// </summary>
    private void AddWorkSheet()
    {
        workBook = new Workbook();

        //Sheet추가 
        workBook.Worksheets.Add("Part I KPI 정의");
        workBook.Worksheets.Add("Part II KPI 측정");
        workBook.Worksheets.Add("Part III KPI 계획 및 평가");
        workBook.Worksheets.Add("Part IV Initiative 관리");
        workBook.Worksheets.Add("Part V 정성평가기준 관리");

        #region ==> Part I KPI 정의
        workBook.ActiveWorksheet = workBook.Worksheets[0];
        // Part I KPI 정의
        ugrdEEP.ExcelStartRow = 7;
        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "챔 피 언 : " + txtCalcFormTs.Text.Trim();
        workBook.ActiveWorksheet.Rows[4].Cells[0].Value = "지표 및 용어 정의 : " + txtMeasurementPurpose.Text.Trim();
        workBook.ActiveWorksheet.Rows[5].Cells[0].Value = "당 월 산 식 : " + txtCalcFormMs.Text.Trim();
        workBook.ActiveWorksheet.Rows[6].Cells[0].Value = "누 계 산 식 : " + txtCalcFormTs.Text.Trim();

        this.SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 4, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 5, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 6, 0);
        #endregion

        #region ==> Part II KPI 측정
        workBook.ActiveWorksheet = workBook.Worksheets[1];
        // Part II KPI 측정
        ugrdEEP.ExcelStartRow = 7;

        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "측정조직 담당자: " + txtMeasurementEmpName.Text.Trim();
        //workBook.ActiveWorksheet.Rows[3].Cells[5].Value = "결 재 자 : " + txtApprovalEmpName.Text.Trim();
        workBook.ActiveWorksheet.Rows[4].Cells[0].Value = "측정 유형: " + ddlResultInputType.SelectedItem.Text.Trim();
        workBook.ActiveWorksheet.Rows[4].Cells[5].Value = "측정 주기: " + ddlResultTermType.SelectedItem.Text.Trim();

        workBook.ActiveWorksheet.Rows[5].Cells[0].Value = "데이타 집계방법 : " + txtDataGetheringMethod.Text.Trim();

        this.SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 3, 5);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 4, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 4, 5);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 5, 0);

        ugrdEEP.Export(ugrdDetail, workBook.ActiveWorksheet);

        ugrdEEP.ExcelStartRow = (ugrdDetail.Rows.Count + 9);
        ugrdEEP.Export(ugrdTerm, workBook.ActiveWorksheet);
        #endregion

        #region ==> Part III KPI 계획 및 평가
        workBook.ActiveWorksheet = workBook.Worksheets[2];
        // Part III KPI 계획 및 평가
        ugrdEEP.ExcelStartRow = 8;

        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "KPI 유형: " + ddlResultAchievementType.SelectedItem.Text.Trim();
        workBook.ActiveWorksheet.Rows[3].Cells[5].Value = "누적실적유형: " + ddlResultTsCalcType.SelectedItem.Text.Trim();
        workBook.ActiveWorksheet.Rows[4].Cells[0].Value = "구간산정방법: " + ddlMeasurementGradeType.SelectedItem.Text.Trim();
        workBook.ActiveWorksheet.Rows[4].Cells[5].Value = "단위 : " + ddlUnit.SelectedItem.Text.Trim();
        workBook.ActiveWorksheet.Rows[5].Cells[0].Value = this.GetText("LBL_00003", "평가단계") +" : " + ddlResultMeasurementStep.SelectedItem.Text.Trim();

        workBook.ActiveWorksheet.Rows[5].Cells[5].Value = "목표 및 등급구간 설정근거 : " + txtTargetReason.Text.Trim();

        this.SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 3, 5);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 4, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 4, 5);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 5, 0);
        this.SetCoulumStlye(workBook.ActiveWorksheet, 5, 5);

        ugrdEEP.Export(ugrdPlan, workBook.ActiveWorksheet);
        ugrdEEP.ExcelStartRow = (ugrdPlan.Rows.Count + 11);

        ugrdBSignal.Columns[1].Hidden = true;  //이미지컬럼 숨김
        ugrdEEP.Export(ugrdSignal, workBook.ActiveWorksheet);
        ugrdBSignal.Columns[1].Hidden = false;

        #endregion

        #region ==> Part IV Initiative 관리
        workBook.ActiveWorksheet = workBook.Worksheets[3];
        // Part IV Initiative 관리
        ugrdEEP.ExcelStartRow = 7;

        ugrdEEP.Export(ugrdBInitiative, workBook.ActiveWorksheet);
        #endregion

        #region ==> Part V 정성평가기준 관리
        workBook.ActiveWorksheet = workBook.Worksheets[4];
        // Part V 정성평가기준 관리
        ugrdEEP.ExcelStartRow = 7;

        ugrdEEP.Export(ugrdEstLevel, workBook.ActiveWorksheet);

        ugrdEEP.ExcelStartRow = (ugrdEstLevel.Rows.Count + 9);
        ugrdEEP.Export(ugrdQuestionTerm, workBook.ActiveWorksheet);
        #endregion
    }

    /// <summary>
    /// Sheet별 공통데이타
    /// </summary>
    private void CommonDataPrint()
    {
        foreach (Worksheet ws in workBook.Worksheets)
        {
            ws.Rows[0].Cells[0].Value = "KPI 코드 : " + txtKpiCode.Text.Trim();
            ws.Rows[0].Cells[5].Value = "KPI 명 : " + txtKpiName.Text.Trim();
            ws.Rows[1].Cells[0].Value = "KPI 유형 : " + txtKpiName.Text.Trim();
            ws.Rows[1].Cells[5].Value = "지표 분류 : " + lblKpiCatName.Text.Trim();

            this.SetCoulumStlye(ws, 0, 0);
            this.SetCoulumStlye(ws, 0, 5);
            this.SetCoulumStlye(ws, 1, 0);
            this.SetCoulumStlye(ws, 1, 5);
        }
    }

    /// <summary>
    /// 엑셀Cell별 스타일설정
    /// </summary>
    /// <param name="ws">workSheet</param>
    /// <param name="row">rowIndex</param>
    /// <param name="cell">cellIndex</param>
    private void SetCoulumStlye(Worksheet ws, int row, int cell)
    {
        ws.Rows[row].Cells[cell].CellFormat.Font.Height = 250;
        ws.Rows[row].Height = 400;
        ws.Columns[cell].Width = 18 * 256;
        ws.Rows[row].Expanded = true;
    }
    

    #endregion
    
    #region ================================= [ 서버이벤트 ]================================
        
    protected void ugrdEEP_CellExporting(object sender, CellExportingEventArgs e)
    {
            this.SetCoulumStlye(e.CurrentWorksheet, e.CurrentRowIndex, e.CurrentColumnIndex);

            if (e.CurrentWorksheet.Index == 2) // "Part III KPI 계획 및 평가"
            {

                //merge Header row
                int mergeHeader = 6;

                e.CurrentWorksheet.Rows[mergeHeader].Cells[1].Value = "당초계획";
                e.CurrentWorksheet.Rows[mergeHeader].Cells[1].CellFormat.Alignment = HorizontalCellAlignment.Center;
                
                
                //WorksheetMergedCellsRegion wsrc =
                //     (WorksheetMergedCellsRegion)e.CurrentWorksheet.MergedCellsRegions.Add(2, 3, 4, 6);

                e.CurrentWorksheet.Rows[mergeHeader].Cells[3].Value = "수정계획";
                e.CurrentWorksheet.Rows[mergeHeader].Cells[3].CellFormat.Alignment = HorizontalCellAlignment.Center;

                //merge Header row
                mergeHeader = ugrdPlan.Rows.Count + 9;
                e.CurrentWorksheet.Rows[mergeHeader].Cells[0].Value = "표시상태";
                e.CurrentWorksheet.Rows[mergeHeader].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
                e.CurrentWorksheet.Rows[mergeHeader].Cells[1].Value = "등급구간";
                e.CurrentWorksheet.Rows[mergeHeader].Cells[1].CellFormat.Alignment = HorizontalCellAlignment.Center;
                e.CurrentWorksheet.Rows[mergeHeader].Cells[3].Value = "평가Table";
                e.CurrentWorksheet.Rows[mergeHeader].Cells[3].CellFormat.Alignment = HorizontalCellAlignment.Center;
               
            }
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        this.CommonDataPrint();
    }
    
    protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.ExcelDownLoad();
    }
    
    protected void ImgBtnAddRow_Click(object sender, ImageClickEventArgs e)
    {
        int cntRow = 0;
        ugrdBDetail.Rows.Add();
        cntRow = ugrdBDetail.Rows.Count - 1;

        DropDownList ddlTempUnit;
        TemplatedColumn unit_col = (TemplatedColumn)ugrdBDetail.Columns.FromKey("UNIT_TYPE_REF_ID");
        ddlTempUnit = (DropDownList)((CellItem)unit_col.CellItems[ugrdBDetail.Rows[cntRow].BandIndex]).FindControl("ddlDataUnit");

        for (int i = 0; i < ddlBUnit.Items.Count; i++)
        {
            ddlTempUnit.Items.Add(new ListItem(ddlBUnit.Items[i].Text, ddlBUnit.Items[i].Value));
        }

        ugrdBDetail.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
    }

    protected void ImgBtnDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdBDetail.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdBDetail.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < cntRow; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdBDetail.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow  = ugrdBDetail.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdBDetail.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    chkCheck.BackColor = Color.Red;
                    ugrdBDetail.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                }
                else if (striType == "A")
                {
                    ugrdBDetail.Rows.Remove(ugrdRow);
                }
            }
        }
    }
    
    protected void ugrdDetail_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }

    protected void ugrdDetail_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells.FromKey("ITYPE").Value = "U";

        DropDownList ddlTempUnit;
        TemplatedColumn unit_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("UNIT_TYPE_REF_ID");

        ddlTempUnit = (DropDownList)((CellItem)unit_col.CellItems[e.Row.BandIndex]).FindControl("ddlDataUnit");
        for (int i = 0; i < ddlBUnit.Items.Count; i++)
        {
            ddlTempUnit.Items.Add(new ListItem(ddlBUnit.Items[i].Text, ddlBUnit.Items[i].Value));
        }

        PageUtility.FindByValueDropDownList(ddlTempUnit, e.Row.Cells.FromKey("UNIT_TYPE_REF_ID").Value.ToString());
    }

    protected void ugrdTerm_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }
    
    protected void ugrdTerm_InitializeRow(object sender, RowEventArgs e)
    {
        CheckBox chkCheck;
        CheckBox chkReport;

        TemplatedColumn Col_Check  = (TemplatedColumn)e.Row.Band.Columns.FromKey("CHECK_YN");
        TemplatedColumn Col_Report = (TemplatedColumn)e.Row.Band.Columns.FromKey("REPORT_YN");


        chkCheck  = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("chkCheckTerm");
        chkReport = (CheckBox)((CellItem)Col_Report.CellItems[e.Row.BandIndex]).FindControl("chkReportTerm");

        chkCheck.Checked  = (e.Row.Cells.FromKey("CHECK_YN").Value.ToString()  == "Y") ? true : false;
        chkReport.Checked = (e.Row.Cells.FromKey("REPORT_YN").Value.ToString() == "Y") ? true : false;

        chkCheck.Enabled  = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;
        chkReport.Enabled = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;

        chkCheck.Attributes.Add("onclick", string.Format("checkInitPlan(this, '{0}', '{1}')", ugrdTerm.ClientID, ugrdPlan.ClientID));
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        iBtnGoalTong.Visible = false;

        if (e.Tab.Key == "3")
        {
            if (this.IHaveChildKPI_YN == "Y")
            {
                this.SetTermToTarget(false, false);
            }
            else
            {
                this.SetTermToTarget(false, true);
            }
            
            if (this.IType == "U" && (this.IChampion_User_YN=="Y" || User.IsInRole(ROLE_ADMIN)))
            {
                this.iBtnAddTarget.Visible   = true;
                this.iBtnAddChildKpi.Visible = true;
            }

            if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y") && this.IChampion_User_YN == "Y")
                iBtnGoalTong.Visible = true;

            this.drawGrade();
            this.drawPoint();
            
        }
        else if (e.Tab.Key == "4")
        {
            this.SetInitiativeRow();
            this.iBtnAddTarget.Visible   = false;
            this.iBtnAddChildKpi.Visible = false;
        }
        else if (e.Tab.Key == "5")
        {
            this.SetKpiQltTermListRow();
            this.iBtnAddTarget.Visible   = false;
            this.iBtnAddChildKpi.Visible = false;
        }
        else
        {
            this.iBtnAddTarget.Visible   = false;
            this.iBtnAddChildKpi.Visible = false;
        }

        iBtnAddChildKpi.Visible = PageUtility.GetByValueDropDownList(ddlBResultInputType).Equals("KPI");
    }

    protected void ugrdGraphTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "1")
        {
            this.drawGrade();
            
            
        }
        else if (e.Tab.Key == "2")
        {
            this.drawPoint();
        }
    }

    protected void ugrdPlan_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //e.Layout.Bands[0].HeaderLayout.Reset();

        //int iIndex = 0;
        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        //foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        //{
        //    c.Header.RowLayoutColumnInfo.OriginY = 1;
        //    c.Header.RowLayoutColumnInfo.OriginX = iIndex;
        //    iIndex++;
        //}

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "월";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanX = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "당초계획" ;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 1;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "수정계획";  //_itarget_mod_name;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 3;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        //ch = e.Layout.Bands[0].Columns[0].Header;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanY = 2;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 50;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else if (i > 0 && i < 5)
            {
                e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.#####";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Hidden = true;
            }
        }
    }

    protected void ugrdPlan_InitializeRow(object sender, RowEventArgs e)
    {
        
    }

    protected void ugrdSignal_InitializeLayout(object sender, LayoutEventArgs e)
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
        ch.Caption = "표시상태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "등급구간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평가 Table";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            switch (i)
            {
                case 0:
                    e.Layout.Bands[0].Columns[i].Width = 80;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 1:
                    e.Layout.Bands[0].Columns[i].Width = 35;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 2:
                    e.Layout.Bands[0].Columns[i].Width = 78;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    break;
                case 3:
                    e.Layout.Bands[0].Columns[i].Width = 80;
                    e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                    e.Layout.Bands[0].Columns[i].Format = "##,##0.00";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                case 4:
                    e.Layout.Bands[0].Columns[i].Header.Caption = (ddlResultAchievementType.SelectedValue == "BTY") ? "한계초과율" : "달성율";
                    e.Layout.Bands[0].Columns[i].Width = 63;
                    e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.##";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                case 5:
                    e.Layout.Bands[0].Columns[i].Width = 62;
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.##";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                default:
                    //e.Layout.Bands[0].Columns[i].Hidden = true;
                    break;
            }
        }
    }

    protected void ugrdSignal_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells[0].AllowEditing = AllowEditing.No;
        e.Row.Cells[1].AllowEditing = AllowEditing.No;
        e.Row.Cells[2].AllowEditing = AllowEditing.No;
        e.Row.Cells[4].AllowEditing = AllowEditing.No;
        e.Row.Cells[5].AllowEditing = AllowEditing.No;

        e.Row.Cells[0].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[1].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[2].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[4].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[5].Style.BackColor = System.Drawing.Color.WhiteSmoke;

        e.Row.Cells[1].Value = "<img src='../images/" + e.Row.Cells[1].Value.ToString() + "'>";
        e.Row.Cells[1].Style.HorizontalAlign = HorizontalAlign.Center;
    }

    protected void ugrdQuestionTerm_InitializeRow(object sender, RowEventArgs e)
    {

        //CheckBox chkUseYn;
        //TemplatedColumn Col_Check  = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

        //chkUseYn  = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");
        //chkUseYn.Checked  = (e.Row.Cells.FromKey("CHECK_YN").Value.ToString()  == "Y") ? true : false;

        //chkUseYn.Enabled = false;

        //string strCheckYn = (e.Row.Cells.FromKey("CHECK_YN").Value == null) ? "N" : e.Row.Cells.FromKey("CHECK_YN").Value.ToString();
        //string strCloseYn = (e.Row.Cells.FromKey("CLOSE_YN").Value == null) ? "N" : e.Row.Cells.FromKey("CLOSE_YN").Value.ToString();

        //if ((strCheckYn == "Y") && (strCloseYn == "N"))
        //{
        //    //e.Row.Cells.FromKey("EST_LEVEL_NAME").AllowEditing    = AllowEditing.No;
        //    //e.Row.Cells.FromKey("YMD").AllowEditing               = AllowEditing.No;
        //    //e.Row.Cells.FromKey("WEIGHT").AllowEditing            = AllowEditing.No;

        //    //e.Row.Cells.FromKey("EST_LEVEL_NAME").Style.BackColor = System.Drawing.Color.WhiteSmoke;
        //    //e.Row.Cells.FromKey("YMD").Style.BackColor            = System.Drawing.Color.WhiteSmoke;
        //    //e.Row.Cells.FromKey("WEIGHT").Style.BackColor         = System.Drawing.Color.WhiteSmoke;

        //    e.Row.Hidden = false;
        //}
        //else
        //{ 
        //    //e.Row.Cells.FromKey("EST_LEVEL_NAME").AllowEditing    = AllowEditing.No;
        //    //e.Row.Cells.FromKey("YMD").AllowEditing               = AllowEditing.No;
        //    //e.Row.Cells.FromKey("WEIGHT").AllowEditing            = AllowEditing.Yes;

        //    //e.Row.Cells.FromKey("EST_LEVEL_NAME").Style.BackColor = System.Drawing.Color.WhiteSmoke;
        //    //e.Row.Cells.FromKey("YMD").Style.BackColor            = System.Drawing.Color.WhiteSmoke;
        //    //e.Row.Cells.FromKey("WEIGHT").Style.BackColor         = System.Drawing.Color.White;
        //    e.Row.Hidden = true;
        //}
    }

    protected void ddlResultMeasurementStep_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetKpiSignalGrid();
    }

    protected void ddlResultTsCalcType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetTermToTarget(false, true);
    }

    protected void linkBtnRegTarget_Click(object sender, EventArgs e)
    {
        this.SetKpiNewTargetGrid();
        this.SetTermToTarget(false, true);
        this.drawGrade();
        this.drawPoint();
    }

    /// <summary>
    /// 지표풀 선택시 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void linkBtnSelKpiPool_Click(object sender, EventArgs e)
    {
        this.IKpiPoolRefID = (this.hdfKpiPoolRefID.Value == "") ? 0 : Convert.ToInt32(hdfKpiPoolRefID.Value.ToString());
        this.SetKpiPoolInfo();
        this.drawGrade();
        this.drawPoint();
    }

    protected void linkBtnDraft_Click(object sender, EventArgs e)
    {
        this.SetKPIMaster();
        this.SetDraftInfo();
        this.SetButton();
        this.drawGrade();
        this.drawPoint();
    }

    //---------------------- 마스터 입력/수정/삭제
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        bool blnRtn = this.TxrKpiMaster();
    }
    
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        bool blnRtn = this.TxrKpiMaster();
        if (blnRtn)
        { 
            this.drawPoint();
            this.drawGrade();
        }
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string striType = this.IType;
        this.IType      = "D";
        bool blnRtn     = this.TxrKpiMaster();
        if (blnRtn)
        {
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        }
        else
        {
            this.IType = striType;
        }
    }

    protected void ugrdEstLevel_InitializeGroupByRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol1    = (TemplatedColumn)e.Row.Band.Columns.FromKey("NORMDIST_USE_YN");
        TemplatedColumn cCol2    = (TemplatedColumn)e.Row.Band.Columns.FromKey("MULTI_EST_USE_YN");

        CheckBox chkNormdist     = (CheckBox)((CellItem)cCol1.CellItems[e.Row.BandIndex]).FindControl("chkUse");
        CheckBox chkMultiEst     = (CheckBox)((CellItem)cCol2.CellItems[e.Row.BandIndex]).FindControl("chkUse");

        chkNormdist.Checked = (e.Row.Cells.FromKey("NORMDIST_USE_YN").Value.ToString()=="Y") ? true : false;
        chkMultiEst.Checked = (e.Row.Cells.FromKey("MULTI_EST_USE_YN").Value.ToString()=="Y") ? true : false;
    }

    protected void ugrdInitiative_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn tmcPL = (TemplatedColumn)e.Row.Band.Columns.FromKey("INITIATIVE_PLAN");
        TemplatedColumn tmcDO = (TemplatedColumn)e.Row.Band.Columns.FromKey("INITIATIVE_DO");
        TemplatedColumn tmcDE = (TemplatedColumn)e.Row.Band.Columns.FromKey("INITIATIVE_DESC");

        TextBox txtPL = (TextBox)((CellItem)tmcPL.CellItems[e.Row.BandIndex]).FindControl("txtINITIATIVE_PLAN");
        TextBox txtDO = (TextBox)((CellItem)tmcDO.CellItems[e.Row.BandIndex]).FindControl("txtINITIATIVE_DO");
        TextBox txtDE = (TextBox)((CellItem)tmcDE.CellItems[e.Row.BandIndex]).FindControl("txtINITIATIVE_DESC");

        txtPL.Text = (e.Row.Cells.FromKey("INITIATIVE_PLAN").Value != null) ? e.Row.Cells.FromKey("INITIATIVE_PLAN").Value.ToString() : "";
        txtDO.Text = (e.Row.Cells.FromKey("INITIATIVE_DO").Value != null)   ? e.Row.Cells.FromKey("INITIATIVE_DO").Value.ToString() : "";
        txtDE.Text = (e.Row.Cells.FromKey("INITIATIVE_DESC").Value != null) ? e.Row.Cells.FromKey("INITIATIVE_DESC").Value.ToString() : "";

        txtPL.Style.Add("overflow", "auto");
        txtDO.Style.Add("overflow", "auto");
        txtDE.Style.Add("overflow", "auto");

        string strCheckYN = (e.Row.Cells.FromKey("CHECK_YN").Value != null) ? e.Row.Cells.FromKey("CHECK_YN").Value.ToString() : "N";
        if (strCheckYN == "Y")
        {
            txtPL.Enabled = true;
            txtDO.Enabled = true;
            txtDE.Enabled = true;
        }
        else
        { 
            txtPL.Enabled = false;
            txtDO.Enabled = false;
            txtDE.Enabled = false;
        }

    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (GetRequest("closeRefresh", "") == "F")
            ltrScript.Text = JSHelper.GetCloseScript();
        else if (this.ICCB1.Trim().Length > 0)
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        else
            ltrScript.Text = JSHelper.GetAlertOpenerReflashScript(null, true);
    }

    protected void ugrdEEP_CellExported(object sender, CellExportedEventArgs e)
    {

    }

    protected void iBtnKpiCopy_Click(object sender, EventArgs e)
    {
        this.SetCopyKpiInfo();
    }

    protected void iBtnExistsKpi_Click(object sender, EventArgs e)
    {
        this.GetExistsKpiCode();
    }

    protected void iBtnUsed_Click(object sender, ImageClickEventArgs e)
    {
        string striType = this.IType;
        this.IType = "RU";
        bool blnRtn = this.TxrKpiMaster();
        if (blnRtn)
        {
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        }
        else
        {
            this.IType = striType;
        }
    }

    protected void ugrdTRStatus_InitializeLayout(object sender, LayoutEventArgs e)
    {
        for (int i=0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i > 0)
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = Convert.ToString(this.startYY + i - 5) + "년";
                e.Layout.Bands[0].Columns[i].Width = Unit.Pixel(73);
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = "구분";
                e.Layout.Bands[0].Columns[i].Width = Unit.Pixel(30);
            }
        }
    }
    protected void ugrdTRStatus_InitializeRow(object sender, RowEventArgs e)
    {

    }
    
    //----------------------------- 결재처리 이벤트
    protected void iBtnDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnReDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnMoDraft_Click(object sender, ImageClickEventArgs e)
    {
              
    }

    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }

    protected void ugrdPrjList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        DataRowView dr = (DataRowView)e.Data;

        MicroBSC.PRJ.Biz.Biz_Prj_Resource objResource = new MicroBSC.PRJ.Biz.Biz_Prj_Resource();
        //Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        DataSet ds = objResource.GetAllList(DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]), 0);
        //object oRate = objSchedule.GetTotalRate(DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]), 0);
        //double dTotalRate = 0;

        string EMP_NAMES = "";

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            EMP_NAMES += row["EMP_NAME"].ToString() + Environment.NewLine;
        }

        e.Row.Cells.FromKey("TASK_OWNER_NAME").Value = EMP_NAMES;

        //dTotalRate = DataTypeUtility.GetToDouble(oRate);
        //e.Row.Cells.FromKey("PROCEED_RATE").Value = dTotalRate.ToString("###.#0") + " %";

    }

    protected void ugrdPrjList_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    #endregion
   
}
