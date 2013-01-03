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

public partial class _common_Draft_DOC0401S1 : AppPageBase
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoBinding();
        }
    }

    private void DoBinding()
    {
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetMBOForWeight(GetRequestByInt("ESTTERM_REF_ID")
                                            , ""
                                            , ""
                                            , ""
                                            , 0
                                            , ""
                                            , ""
                                            , 0
                                            , 0
                                            , 0
                                            , GetRequestByInt("DRAFT_EMP_ID")
                                            , false);

        ugrdMBO.Clear();
        ugrdMBO.DataSource = ds.Tables[0];
        ugrdMBO.DataBind();
    }

    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        if (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y")
            e.Row.Cells.FromKey("APPROVAL_STATUS_YN").Value = "O";
        else
            e.Row.Cells.FromKey("APPROVAL_STATUS_YN").Value = "X";
    }

    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
}
