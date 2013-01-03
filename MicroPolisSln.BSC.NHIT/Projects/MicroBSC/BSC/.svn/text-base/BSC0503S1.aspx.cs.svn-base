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

public partial class BSC_BSC0503S1 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, int.Parse(PageUtility.GetByValueDropDownList(ddlEstTermInfo)));

            this.SetPaReportGrid();
        }
    }

    private void SetPaReportGrid()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
        DataSet rDs = objBSC.GetResultPaReportList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                 , PageUtility.GetByValueDropDownList(ddlMonthInfo));

        ugrdPaReport.Clear();
        ugrdPaReport.DataSource = rDs;
        ugrdPaReport.DataBind();

        if(rDs.Tables[0].Rows.Count > 0)  
        {
            float cnt   = rDs.Tables[0].Select("PA_YN = 'Y'").Length;
            float total = rDs.Tables[0].Rows.Count;
            float rate = cnt/total * 100.0f;

            lblRowCount.Text = string.Format("{0} / {1} ({2} %)", cnt, total, rate.ToString("N2"));
        }
    }

    #region 서버이벤트
    protected void ugrdPaReport_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        if (e.Row.Cells.FromKey("CONFIRM_YN") != null)
        {
            e.Row.Cells.FromKey("CONFIRM_YN").Text = (e.Row.Cells.FromKey("CONFIRM_YN").Value.ToString() == "Y") ?
                                                     "<div class='stext'><img src='../images/icon_o.gif'></div>" :
                                                     "<div class='stext'><img src='../images/icon_x.gif'></div>";
        }
        else
        {
            e.Row.Cells.FromKey("CONFIRM_YN").Text = "<div class='stext'><img src='../images/icon_x.gif'></div>";
        }

        if (e.Row.Cells.FromKey("PA_YN") != null)
        {
            e.Row.Cells.FromKey("PA_YN").Text = (e.Row.Cells.FromKey("PA_YN").Value.ToString() == "Y") ?
                                                     "<div class='stext'><img src='../images/icon_o.gif'></div>" :
                                                     "<div class='stext'><img src='../images/icon_x.gif'></div>";
        }
        else
        {
            e.Row.Cells.FromKey("PA_YN").Text = "<div class='stext'><img src='../images/icon_x.gif'></div>";
        }
    }
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, int.Parse(PageUtility.GetByValueDropDownList(ddlEstTermInfo)));
        this.SetPaReportGrid();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetPaReportGrid();
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }
    #endregion
}
