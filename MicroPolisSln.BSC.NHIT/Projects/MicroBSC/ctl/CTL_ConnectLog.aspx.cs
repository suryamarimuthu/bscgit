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

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Estimation.Dac;
using MicroBSC.BSC.Biz;

public partial class CTL_ConnectLog : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetResultGrid();
        }
    }

    #region 내부함수
    private void SetResultGrid()
    {
        string sDeptID = string.Empty;
        string sUserNM = string.Empty;
        string sSDT = string.Empty;
        string sEDT = string.Empty;

        sDeptID = txtDeptID.Text + "%";
        sUserNM = txtUserNM.Text + "%";
        if (wdcSDate.Value != null)
        {
            sSDT = wdcSDate.Text.ToString().Replace("-", "");
            sEDT = Convert.ToDateTime(wdcEDate.Text).AddDays(1).ToShortDateString().Replace("-", "");
        }
        else
        {
            sSDT = "20000101";
            sEDT = "99990101";
            //sSDT = DateTime.Now.ToShortDateString().Replace("-", "");
            //sEDT = DateTime.Now.AddDays(1).ToShortDateString().Replace("-", "");
        }


        MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common Biz = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();

        int iTotalRows = Biz.GetConnectLogCount(sDeptID, sUserNM, sSDT, sEDT);
        int iLastPage = (int)Math.Ceiling((Double)iTotalRows / ugrdResultStatus.DisplayLayout.Pager.PageSize);
        int iFirstRow = (ugrdResultStatus.DisplayLayout.Pager.CurrentPageIndex - 1) * ugrdResultStatus.DisplayLayout.Pager.PageSize;
        int iLastRow = ugrdResultStatus.DisplayLayout.Pager.CurrentPageIndex * ugrdResultStatus.DisplayLayout.Pager.PageSize;


        ViewState.Add("CurrentPageIndex", ugrdResultStatus.DisplayLayout.Pager.CurrentPageIndex);
        ViewState.Add("PageCount", iLastPage);


        DataTable dt = Biz.GetConnectLog(sDeptID, sUserNM, sSDT, sEDT, iFirstRow + 1, iLastRow);
        ugrdResultStatus.Clear();
        ugrdResultStatus.DataSource = dt;
        ugrdResultStatus.DataBind();

        //DataRow[] row = dt.Select(" SEQ < 3 AND  ");

        //DataTypeUtility.FilterSortDataTable(dt,"");

        //DataTypeUtility.GetBoolean ("");




        lblRowCount.Text = iTotalRows.ToString();
    }
    #endregion

    #region 서버이벤트
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ugrdResultStatus.DisplayLayout.Pager.CurrentPageIndex = 1;
        SetResultGrid();
    }

    protected void ugrdResultStatus_InitializeRow(object sender, RowEventArgs e)
    {

    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {

    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ugrdResultStatus_PreRender(object sender, System.EventArgs e)
    {
        ugrdResultStatus.DisplayLayout.Pager.CurrentPageIndex = (int)ViewState["CurrentPageIndex"];
        ugrdResultStatus.DisplayLayout.Pager.PageCount = (int)ViewState["PageCount"];
    }
    protected void ugrdResultStatus_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        ugrdResultStatus.DisplayLayout.AllowSortingDefault = AllowSorting.Yes;
        ugrdResultStatus.DisplayLayout.HeaderClickActionDefault = HeaderClickAction.SortMulti;
        ugrdResultStatus.DisplayLayout.Pager.AllowCustomPaging = true;
        ugrdResultStatus.DisplayLayout.Pager.AllowPaging = true;
        ugrdResultStatus.DisplayLayout.Pager.StyleMode = PagerStyleMode.Numeric;
    }
    protected void ugrdResultStatus_PageIndexChanged(object sender, Infragistics.WebUI.UltraWebGrid.PageEventArgs e)
    {
        ugrdResultStatus.DisplayLayout.Pager.CurrentPageIndex = e.NewPageIndex;
        SetResultGrid();
    }

    #endregion


}
