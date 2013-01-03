using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC1001S3 : AppPageBase
{
    protected string IAPP_STATUS
    {
        get
        {
            if (ViewState["APP_STATUS"] == null)
                ViewState["APP_STATUS"] = "";
            return (string)ViewState["APP_STATUS"];
        }
        set
        {
            ViewState["APP_STATUS"] = value;
        }
    }

    protected string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lbtReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected string IAPP_REF_ID
    {
        get
        {
            if (ViewState["APP_REF_ID"] == null)
                ViewState["APP_REF_ID"] = "0";
            return (string)ViewState["APP_REF_ID"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }

    protected string IEXTERNAL_APPROVAL
    {
        get
        {
            if (ViewState["EXTERNAL_APPROVAL"] == null)
            {
                string strExt = System.Configuration.ConfigurationManager.AppSettings.Get("APPROVALGATEWAY");
                if (strExt == null || strExt.Equals(""))
                    ViewState["EXTERNAL_APPROVAL"] = "N";
                else
                    ViewState["EXTERNAL_APPROVAL"] = strExt;
            }
            return (string)ViewState["EXTERNAL_APPROVAL"];
        }
    }

    protected int IDEPT_ID
    {
        get
        {
            if (ViewState["DEPT_ID"] == null)
                ViewState["DEPT_ID"] = 0;
            return (int)ViewState["DEPT_ID"];
        }
        set
        {
            ViewState["DEPT_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }

        ltrScript.Text = "";

        this.Label1.Text = string.Format("* 모든 KPI가 확정되어야 {0} 가능합니다.", this.GetText("LBL_00006", "결재상신"));
        this.iBtnDraft.AlternateText = this.GetText("LBL_00006", "결재상신");
        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    protected void lbtReload_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void ddlKpiCategoryTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }
    protected void ddlKpiCategoryMid_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }

    protected void ddlComDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBinding();
    }

    private void DoInitControl()
    {
        this.IDEPT_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
        WebCommon.SetEstTermDropDownList(ddlEstTerm);

        WebCommon.SetComDeptDropDownList(ddlComDept, true, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlComDept, this.IDEPT_ID);

        Biz_Com_Code_Info objCom = new Biz_Com_Code_Info();
        objCom.GetKpiType(ddlKpiGroup, "", true, 120);

        DataSet dsCode = objCom.GetCodeListPerCategory("BS0014", "Y");
        ddlMboType.DataValueField = "ETC_CODE";
        ddlMboType.DataTextField = "CODE_NAME";
        ddlMboType.DataSource = dsCode;
        ddlMboType.DataBind();

        ddlMboType.Items.Insert(0, new ListItem(":: 전체 ::", ""));

        WebCommon.SetKpiCategoryTopActiveDropDownList(ddlKpiCategoryTop, true, "Y");
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");

        if (User.IsInRole(ROLE_ADMIN))
        {
            txtKpiCode.ReadOnly = txtKpiName.ReadOnly = txtChampionName.ReadOnly = false;
            ddlComDept.Enabled = ddlKpiGroup.Enabled = ddlMboType.Enabled = ddlKpiCategoryTop.Enabled = ddlKpiCategoryMid.Enabled = ddlKpiCategoryLow.Enabled = true;
            //iBtnDraft.Visible = ImgBtnPrint.Visible = false;
        }
        else
        {
            txtKpiCode.ReadOnly = txtKpiName.ReadOnly = txtChampionName.ReadOnly = true;
            ddlComDept.Enabled = ddlKpiGroup.Enabled = ddlMboType.Enabled = ddlKpiCategoryTop.Enabled = ddlKpiCategoryMid.Enabled = ddlKpiCategoryLow.Enabled = false;
            txtChampionName.Text = gUserInfo.Emp_Name;
            iBtnDraft.Visible = ImgBtnPrint.Visible = true;
        }
        ImgBtnPrint.OnClientClick = "return OpenDraftPrint('" + Biz_Type.app_draft_select + "')";
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    /// <summary>
    /// 수정결재요청
    /// </summary>
    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }
    private void RequestModifyDraft()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();
        bool blnRtn = objApp.RequestModifyDraft(DataTypeUtility.GetToInt32(this.IAPP_REF_ID), EMP_REF_ID);
        if (blnRtn)
        {
            DoBinding();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objApp.Transaction_Message, false);
        }
    }

    private void DoBinding()
    {
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetMBOForWeight(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                            , txtKpiCode.Text.Trim()
                                            , txtKpiName.Text.Trim()
                                            , txtChampionName.Text.Trim()
                                            , (ddlComDept.SelectedItem.Value == "" ? 0 : PageUtility.GetIntByValueDropDownList(ddlComDept))
                                            , PageUtility.GetByValueDropDownList(ddlKpiGroup)
                                            , PageUtility.GetByValueDropDownList(ddlMboType)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                            , gUserInfo.Emp_Ref_ID
                                            , User.IsInRole(ROLE_ADMIN));

        
        ugrdMBO.Clear();
        ugrdMBO.DataSource = ds.Tables[0];
        ugrdMBO.DataBind();

        lblRowCount.Text = ugrdMBO.Rows.Count.ToString();

        if (ds.Tables[0].Rows.Count == 0)
            iBtnDraft.Visible = ImgBtnPrint.Visible = iBtnMoDraft.Visible = iBtnReDraft.Visible = iBtnReWrite.Visible = iBtnReqModify.Visible = false;

        object objSum = ds.Tables[0].Compute("SUM(WEIGHT)", "");
        if (objSum == null || this.IDEPT_ID.ToString() != ddlComDept.SelectedValue)
            txtWeightSum.Text = "0";
        else
            txtWeightSum.Text = DataTypeUtility.GetToDouble(objSum).ToString();

        //if (User.IsInRole(ROLE_ADMIN))
        //    return;

        DataTable dtWeightApproval = objBSC.GetMBOForWeight_Approval(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                            , gUserInfo.Emp_Ref_ID).Tables[0];
        if (dtWeightApproval.Rows.Count == 0)
        {
            this.IAPP_STATUS = "";
            this.IAPP_REF_ID = "0";
        }
        else
        {
            this.IAPP_STATUS = dtWeightApproval.Rows[0]["APP_STATUS"].ToString();
            this.IAPP_REF_ID = dtWeightApproval.Rows[0]["APP_REF_ID"].ToString();
        }
        string strImg = (this.IAPP_STATUS == "") ? "" : this.IAPP_STATUS;
        imgApprovalStatus.Src = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        imgApprovalStatus.Alt = Biz_Com_Approval_Info.GetAppImageText(strImg);

        if (ds.Tables[0].Rows.Count == 0)
            return;
        switch (this.IAPP_STATUS)
        {
            case "": // 결재상태 없음
                iBtnDraft.Visible = true;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                break;
            case Biz_Type.app_status_nodraft: // 결재상태 없음
                iBtnDraft.Visible = true;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                break;
            case Biz_Type.app_status_draft: // 상신
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_dft.gif";
                break;
            case Biz_Type.app_status_ondraft: // 결재중
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_oft.gif";
                break;
            case Biz_Type.app_status_return: // 반려
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = true;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_rft.gif";
                break;
            case Biz_Type.app_status_recall: // 결재회수
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = true;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_aft.gif";
                break;
            case Biz_Type.app_status_onmodify: // 수정결재
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = true;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_mft.gif";
                break;
            case Biz_Type.app_status_complete: // 결재완료
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = true;
                imgApprovalStatus.Src = "../images/draft/sta_cft.gif";
                break;
            default:
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReqModify.Visible = false;
                iBtnReWrite.Visible = false;
                break;
        }
    }

    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {
        this.SetDraftLegend(sender, e);
    }

    public void SetDraftLegend(object sender, LayoutEventArgs e)
    {
        try
        {
            e.Layout.StationaryMargins                  = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault             = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault           = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height          = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor       = System.Drawing.Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor       = System.Drawing.Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right    = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign   = VerticalAlign.Middle;

            int iCol = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg = iCol;  // Start Colspan Length
            int iFRow = 0;     // Start Colspan Index
            for (int i = 0; i < iCol; i++)
            {
                iFRow += 1;
                if (e.Layout.Bands[0].Columns[i].Hidden)
                {
                    iMrg -= 1;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX = iMrg;
                    break;
                }
            }

            if (iFRow > 0)
            {
                string sLegend = Biz_Type.app_legend;

                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Caption = sLegend;
                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Style.Width = Unit.Percentage(100);
            }
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        }
    }
    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        if (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y")
            e.Row.Cells.FromKey("APPROVAL_STATUS_YN").Value = "O";
        else
            e.Row.Cells.FromKey("APPROVAL_STATUS_YN").Value = "X";
    }
}
