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
using System.Data.OracleClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroCharts;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Data.Oracle;
using System.Text;

public partial class eis_SEM_Mana_R071 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            //SetDateDropDownList(ddlYear, ddlMonth);
            SetTypeDropDownList(ddlType);
            DataBindingObjects();
        }
    }
    public void SetTypeDropDownList(System.Web.UI.WebControls.DropDownList ddList)
    {
        string query = @"SELECT DISTINCT  OTH_COMPANY_NAME FROM SEM_GROUP_COMPANY ORDER BY OTH_COMPANY_NAME  ";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        ddList.DataSource = ds;
        ddList.DataTextField  = "OTH_COMPANY_NAME";
        ddList.DataValueField = "OTH_COMPANY_NAME";
        ddList.DataBind();

    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        string type     = ddlType.SelectedValue;
        GridBinding(type);
    }
    private void GridBinding(string type)
    {
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(GetQuery(type), "Data");

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
    private string GetQuery(string type)
    {
        string query = @" SELECT NVL(OTH_SERIAL,' ')       SERI,
                                 NVL(OTH_Company_Name,' ') COMP,
                                 NVL(OTH_Gubn,' ')         GUBN,
                                 NVL(OTH_PART,' ')         PART,
                                 NVL(OTH_NAME,' ')         NAME,
                                 NVL(OTH_OTEL_NO,' ')      OTEL,     
                                 NVL(OTH_HTEL_NO,' ')      HTEL,   
                                 NVL(OTH_FAX_NO,' ')       FAX, 
                                 NVL(OTH_HOME_NO,' ')      HOME,   
                                 NVL(OTH_EMAIL,' ')        EMIL,    
                                 NVL(OTH_ADDR,' ')         ADDR
                            FROM SEM_GROUP_COMPANY
                           WHERE OTH_COMPANY_NAME = '" + type + @"'
                           ORDER BY OTH_SERIAL, OTH_COMPANY_NAME   ";
        
        return query;
    }
}
