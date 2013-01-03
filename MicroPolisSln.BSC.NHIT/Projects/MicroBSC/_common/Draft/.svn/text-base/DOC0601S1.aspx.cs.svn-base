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
using System.Drawing.Drawing2D;
using System.IO;

using Infragistics.WebUI.UltraWebGrid;
using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class _common_Draft_DOC0601S1 : AppPageBase
{
    protected string IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = "0";
            return (string)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.IESTTERM_REF_ID = GetRequest("ESTTERM_REF_ID", "0");
            DoBinding();
        }
    }

    private void DoBinding()
    {
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetKpiListForBatchDraft(GetRequestByInt("ESTTERM_REF_ID")
                                            , ""
                                            , ""
                                            , "Y"
                                            , GetRequestByInt("EMP_REF_ID")
                                            , GetRequest("KPI_REF_ID"));

        ugrdKPI.Clear();
        ugrdKPI.DataSource = ds.Tables[0];
        ugrdKPI.DataBind();
    }

    protected void ugrdKPI_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //e.Row.Cells.FromKey("KPI_NAME").Value = string.Format("<a href='#' onClick='javascript:OpenDraftPrint({1}, {2});' style='cursor: pointer;'>{0}</a>", e.Row.Cells.FromKey("KPI_NAME"), e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString(), e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString());

        e.Row.Cells.FromKey("KPI_NAME").Value = string.Format("<a href='#' target='_blank' onClick='javascript:return OpenDraftPrint({1}, {2});' style='cursor: pointer;'>{0}</a>", e.Row.Cells.FromKey("KPI_NAME"), e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString(), e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString());

        //var app_ref_id = "0";
        //    var biz_type = "<%= Biz_Type.biz_type_kpi_doc %>";
        //    var url = "/BSC/BSC0901P1.aspx?DRAFT_STATUS=" + '<%= Biz_Type.app_draft_select %>' + "&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id + "&BIZ_TYPE=" + biz_type + "&APP_REF_ID=" + app_ref_id;

        //    gfOpenWindow(url, 900, 650, 'BSC0901P1');

        e.Row.Cells.FromKey("KPI_NAME").Style.Font.Bold = true;
        e.Row.Cells.FromKey("KPI_NAME").Style.Font.Underline = true;
    }

    protected void ugrdKPI_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
}
