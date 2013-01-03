using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.BSC.Biz;
using MicroBSC.Integration.BSC.Biz;

public partial class BSC_BSC0705S1 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetFaqGrid();
    }

    private void SetFaqGrid()
    {
        Biz_Bsc_Faq objBSC = new Biz_Bsc_Faq();
        this.ugrdNotice.Clear();
        this.ugrdNotice.DataSource = objBSC.SelectBscFaqAll(txtSearchText.Text);
        this.ugrdNotice.DataBind();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetFaqGrid();
    }

    protected void ugrdNotice_InitializeRow(object sender, RowEventArgs e)
    {

    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        SetFaqGrid();
    }
}
