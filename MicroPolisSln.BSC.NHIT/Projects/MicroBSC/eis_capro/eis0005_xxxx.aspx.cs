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
using System.Data.SqlClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroBSC.Data;
using MicroCharts;

public partial class est0005 : AppPageBase
{
    DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetDropDownListYear(ddlYear);

            string yearStr = ddlYear.SelectedValue;

            BindingChart(Chart1, yearStr);
        }
    }
    private void SetDropDownListYear(System.Web.UI.WebControls.DropDownList ddlYear) 
    {
        for (int i = System.DateTime.Now.Year; i >= 1999; i--) 
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    //private void SetDropDownListItem(System.Web.UI.WebControls.DropDownList ddlItem)
    //{
    //    string query = @"SELECT DISTINCT ITMU_IDX, ITMU_NAME FROM D_ITEM_UTIL";
    //    dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
    //    DataSet ds = dbAgent.FillDataSet(query, "Data");
    //    ddlItem.DataSource = ds;
    //    ddlItem.DataValueField  = "ITMU_IDX";
    //    ddlItem.DataTextField   = "ITMU_NAME";
    //    ddlItem.DataBind();
    //}
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string yearStr)
    {
        string query_item = @"SELECT PAN_IDX, PAN_ITMNM from D_ITEM_PANMAE WHERE PAN_ITMNM LIKE '%유안%'";
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        chart.DataSource = GetChartDataTable(yearStr).DefaultView;
        //DataGrid1.DataSource = GetChartDataTable(yearStr).DefaultView;
        //DataGrid1.DataBind();

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 450
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series = null;
        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);

        for (int i = 0; i < ds_item.Tables[0].Rows.Count; i++) 
        {
            series = DundasCharts.CreateSeries(chart, "Series" + i.ToString(), "Default", ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString(), null, SeriesChartType.Line, 3, GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            series.ValueMembersY = "C_" + ds_item.Tables[0].Rows[i]["PAN_IDX"].ToString();
            DundasAnimations.GrowingAnimation(chart, series, 2 * i, 2 * (i + 1), false);
            series.MarkerStyle = GetMarkerStyle(i);
            series.MarkerColor = GetChartColor(i);
            series.MarkerBorderColor = GetChartColor(i);

            //if (ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString().IndexOf("공업용유안25Kg(Pk)") < 0)
            //    series.YAxisType = AxisType.Secondary;

            if(i == 0)
                series.ValueMemberX = "MONTH";
        }

        chart.Legends.Add(new Legend("test"));
        Chart1.Legends["test"].Alignment = StringAlignment.Center;
        Chart1.Legends["test"].Docking = LegendDocking.Top;
        Chart1.Legends["test"].ShadowOffset = 0;
        Chart1.Legends["test"].LegendStyle = LegendStyle.Row;
        Chart1.Legends["test"].Font = new Font(Chart1.Legends["Default"].Font.FontFamily, 9);

        Font font1 = new Font("Gulim", 9, FontStyle.Regular);
        Legend legend = DundasCharts.CreateLegend(Chart1, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
        DundasCharts.SetChartArea(Chart1.ChartAreas["Default"], false);
    }
    private DataTable GetChartDataTable(string yearStr)
    {
        string query        = GetQuery(yearStr);
        string query_item = @"SELECT PAN_IDX, PAN_ITMNM from D_ITEM_PANMAE WHERE PAN_ITMNM LIKE '%유안%'";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds      = dbAgent.FillDataSet(query, "Data");
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("MONTH", typeof(string));

        for (int i = 0; i < ds_item.Tables[0].Rows.Count; i++)
        {
            dataTable.Columns.Add("C_" + ds_item.Tables[0].Rows[i]["PAN_IDX"].ToString(), typeof(double));
        }

        for (int i = 1; i <= 12; i++) 
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = i.ToString();

            for (int j = 0; j < ds_item.Tables[0].Rows.Count; j++)
            {
                dr["C_" + ds_item.Tables[0].Rows[j]["PAN_IDX"].ToString()] = 0;
            }

            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            for (int j = 0; j < ds_item.Tables[0].Rows.Count; j++)
            {
                drCol = ds.Tables[0].Select("yyyy_mm = '" + yearStr + i.ToString().PadLeft(2, '0') + "' AND PAN_IDX = '" + ds_item.Tables[0].Rows[j]["PAN_IDX"].ToString() + "'");
                if (drCol.Length > 0)
                    dataTable.Rows[i - 1]["C_" + ds_item.Tables[0].Rows[j]["PAN_IDX"].ToString()] = Convert.ToDouble(drCol[0]["PAN_QTY"].ToString());
            }
        }

        return dataTable;
    }
    private string GetQuery(string yearStr)
    {
        string query = @"SELECT C.yyyy_mm, PAN_IDX, PAN_ITMNM, SUM(PAN_QTY) AS PAN_QTY FROM CA_FT_PANMAE A,
		                    D_ITEM_PANMAE  B,
		                    D_TIME_ILJA C
	                        WHERE A.ITEM_IDX = B.PAN_IDX
			                        AND A.TIME_IDX = C.TM_IDX
							AND B.PAN_ITMNM LIKE '%유안%'
                                    AND SUBSTRING(CONVERT(varchar,C.yyyy_mm), 1, 4) = '" + yearStr + @"' 
                        GROUP BY C.yyyy_mm, PAN_IDX, PAN_ITMNM
	                        ORDER BY C.yyyy_mm";

        return query;
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string yearStr = ddlYear.SelectedValue;

        BindingChart(Chart1, yearStr);
    }
}
