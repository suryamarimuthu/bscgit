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
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC1003S3 : AppPageBase
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

    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
                ViewState["YMD"] = "0";
            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    int iTRow = 0;
    int iCRow = 0;

    #region 초기 세팅 메소드
    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdKpiResultList.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");
        if (!Page.IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";

        rowKpiType.Visible = false;
    }

    private void DoInitControl()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IESTTERM_REF_ID);
        this.IYMD = PageUtility.GetByValueDropDownList(ddlEstTermMonth);


        WebCommon.SetComDeptDropDownList(ddlEstDept, true, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlEstDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);

        WebCommon.SetKpiCategoryTopActiveDropDownList(ddlKpiCategoryTop, true, "Y");
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    #endregion

    #region 내부함수
    public void DoBinding()
    {
        bool isAdmin = false;
        bool isTeamManager = false;
        if (User.IsInRole(ROLE_ADMIN))
            isAdmin = true;
        if (User.IsInRole(ROLE_TEAM_MANAGER))
            isTeamManager = true;

        lblRowCount.Text = "0 / 0";
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet dsResult = objBSC.GetMboListForResultInput(this.IESTTERM_REF_ID
                                                            , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
                                                            , txtKPICode.Text.Trim()
                                                            , txtKPIName.Text.Trim()
                                                            , txtChamName.Text.Trim()
                                                            , PageUtility.GetIntByValueDropDownList(ddlEstDept)
                                                            , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                                            , gUserInfo.Emp_Ref_ID
                                                            , isAdmin
                                                            , isTeamManager
                                                            , BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        ugrdKpiResultList.DataSource = dsResult;
        ugrdKpiResultList.DataBind();

    }

    /// <summary>
    /// 결재아이콘 범례생성
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetDraftLegend(object sender, LayoutEventArgs e)
    { 
        try
        {
            e.Layout.StationaryMargins                  = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault             = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault           = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height          = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor       = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor       = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right    = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign   = VerticalAlign.Middle;

            int iCol  = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg  = iCol;  // Start Colspan Length
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
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX     = iMrg;
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

    #endregion

    #region 서버이벤트
    protected void ugrdKpiResultList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        this.SetDraftLegend(sender, e);
    }

    protected void ugrdKpiResultList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
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
        string strImg =   DataTypeUtility.GetValue(e.Row.Cells.FromKey("APP_STATUS").Value);
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);

        iTRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            iCRow += 1;
        }

        lblRowCount.Text = iCRow.ToString() + " / " + iTRow.ToString();

        

        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string url = "<a href='#' onclick='doPopping_Result(\"{0}\",\"{1}\",\"{2}\",\"{3}\")'>{4}</a>";
        string link = string.Format(url, kpi_ref_id, IYMD, IESTTERM_REF_ID, ICCB1, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = link;
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

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IESTTERM_REF_ID);
        DoBinding();
    }
    #endregion
}
