using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC0501M4 : AppPageBase
{
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lBtnReload2.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    protected string IIS_TEAM_KPI
    {
        get
        {
            if (ViewState["IS_TEAM_KPI"] == null)
            {
                ViewState["IS_TEAM_KPI"] = GetRequest("IS_TEAM_KPI");
            }

            return (string)ViewState["IS_TEAM_KPI"];
        }
        set
        {
            ViewState["IS_TEAM_KPI"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdDraft.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        this.IIS_TEAM_KPI = GetRequest("IS_TEAM_KPI");
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";

        this.ibtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlDraftTerm);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        DoBinding();
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void lBtnReload2_Click(object sender, EventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    private void DoBinding()
    {
        if (ddlDraftTerm.Items.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("등록된 평가기간이 없습니다.");
            return;
        }
        
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();

        DataSet ds = objBSC.GetKpiResultListForBatchDraft(DataTypeUtility.GetToInt32(PageUtility.GetIntByValueDropDownList(ddlDraftTerm))
                                                    , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
                                                    , ddlDraftResultType.SelectedValue
                                                    , PageUtility.GetByValueDropDownList(ddlDraftKpiType)
                                                    , GetRequest("IS_TEAM_KPI")
                                                    , gUserInfo.Emp_Ref_ID
                                                    , "");

        ugrdDraft.Clear();
        ugrdDraft.DataSource = ds;
        ugrdDraft.DataBind();

    }

    private void DoInitControl()
    {
        WebCommon.SetEstTermDropDownList(ddlDraftTerm);

        int intEstTermId = (ddlDraftTerm.Items.Count > 0) ? int.Parse(ddlDraftTerm.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlDraftResultType, "", true, 120);
        objCode.GetKpiType(ddlDraftKpiType, "", true, 120);
    }

    protected void ugrdDraft_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //this.SetDraftLegend(sender, e);
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    protected void ugrdDraft_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        
        DataRowView drw = (DataRowView)e.Data;

        if (drw["CHECK_YN"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        if (drw["CHECKSTATUS"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = DataTypeUtility.GetValue(e.Row.Cells.FromKey("APP_STATUS").Value);
        objImg.ImageUrl = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
    }
}
