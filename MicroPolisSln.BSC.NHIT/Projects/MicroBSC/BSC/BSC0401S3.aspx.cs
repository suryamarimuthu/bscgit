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
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;

public partial class BSC_BSC0401S3 : AppPageBase
{
    public String baselink = "usr1001.aspx";

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DoInitializing();

            
            this.GridBinding();
        }
    }

    private void DoInitializing()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);

        ugrdMapList.Columns.FromKey("BSCCHAMPION_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
    }

    public void GridBinding()
    {
        int estterm_ref_id = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue.ToString()) : 0;
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info();
        DataSet ds = objBSC.GetMapListByDeptTree(estterm_ref_id, PageUtility.GetByValueDropDownList(ddlEstTermMonth));

        ugrdMapList.DataSource = ds;
        ugrdMapList.DataBind();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridBinding();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string strSpace = "";
        int intLevel = int.Parse(e.Row.Cells.FromKey("DEPT_LEVEL").Value.ToString());
        for (int i = 0; i < intLevel; i++)
        {
            strSpace += "&nbsp;";
        }

        if (intLevel < 4)
        {
            e.Row.Cells.FromKey("DEPT_NAME").Text = "<b>" + strSpace + e.Row.Cells.FromKey("DEPT_NAME").Text + "<b>";
        }
        else
        {
            e.Row.Cells.FromKey("DEPT_NAME").Text = "&nbsp;&nbsp;" + strSpace + e.Row.Cells.FromKey("DEPT_NAME").Text;
        }

        decimal dWeight = DataTypeUtility.GetToDecimal(e.Row.Cells.FromKey("TOT_WEIGHT").Value);
        if (dWeight == 100)
        {
            e.Row.Cells.FromKey("TOT_WEIGHT").Style.ForeColor = System.Drawing.Color.Blue;
        }
        else
        {
            e.Row.Cells.FromKey("TOT_WEIGHT").Style.ForeColor = System.Drawing.Color.Red;
        }

    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.GridBinding();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.GridBinding();
    }
}
