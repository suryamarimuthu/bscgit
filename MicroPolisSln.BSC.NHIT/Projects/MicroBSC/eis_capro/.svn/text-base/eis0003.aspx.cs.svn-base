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

public partial class est0003 : AppPageBase
{
    DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetDropDownListYear(ddlYear);

            string yearStr = ddlYear.SelectedValue;
            BindingChart_1(Chart1, yearStr);
            BindingChart_2(Chart2, yearStr);
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
    private void BindingChart_1(Dundas.Charting.WebControl.Chart chart, string yearStr)
    {
        string query_item = @"SELECT PAN_ITMNM from D_ITEM_PANMAE WHERE PAN_ITMNM LIKE '%¶ôÅ½%' GROUP BY PAN_ITMNM";
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        //chart.DataSource = GetChartDataTable_1(yearStr).DefaultView;
        //DataGrid1.DataSource = GetChartDataTable(yearStr).DefaultView;
        //DataGrid1.DataBind();

        DataTable dt = GetChartDataTable_1(yearStr);

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 182
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
            //series.ValueMembersY = "C_" + ds_item.Tables[0].Rows[i]["PAN_IDX"].ToString();
            DatabaseBindingXY(series, "MONTH", "C_" + ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString(), dt);
            DundasAnimations.GrowingAnimation(chart, series, i, (i + 1), false);
            if (ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString() == "¿ëÀ¶¶ôÅ½")
            {
                series.YAxisType = AxisType.Secondary;
                
            }
            series.MarkerStyle = GetMarkerStyle(i);
            series.MarkerColor = GetChartColor(i);
            series.MarkerBorderColor = GetChartColor(i);
            series.ToolTip = "#VALY{N0}";

            //if (ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString().IndexOf("°ø¾÷¿ëÀ¯¾È25Kg(Pk)") < 0)
            //    series.YAxisType = AxisType.Secondary;

            string sChartArea = chart.Series[series.Name].ChartArea;
            chart.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
            chart.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

            //SetZeroPoint(chart, int.Parse(ddlYear.SelectedValue));
        }

        SetVisibleZeroPoint(chart, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));

        Font font1 = new Font("Gulim", 9, FontStyle.Regular);
        Legend legend = DundasCharts.CreateLegend(chart, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }
    private DataTable GetChartDataTable_1(string yearStr)
    {
        string query        = GetQuery_1(yearStr);
        string query_item = @"SELECT PAN_ITMNM from D_ITEM_PANMAE WHERE PAN_ITMNM LIKE '%¶ôÅ½%' GROUP BY PAN_ITMNM";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds      = dbAgent.FillDataSet(query, "Data");
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("MONTH", typeof(string));

        for (int i = 0; i < ds_item.Tables[0].Rows.Count; i++)
        {
            dataTable.Columns.Add("C_" + ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString(), typeof(double));
        }

        for (int i = 1; i <= 12; i++) 
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = i.ToString();

            for (int j = 0; j < ds_item.Tables[0].Rows.Count; j++)
            {
                dr["C_" + ds_item.Tables[0].Rows[j]["PAN_ITMNM"].ToString()] = 0;
            }

            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            for (int j = 0; j < ds_item.Tables[0].Rows.Count; j++)
            {
                drCol = ds.Tables[0].Select("yyyy_mm = '" + yearStr + i.ToString().PadLeft(2, '0') + "' AND PAN_ITMNM = '" + ds_item.Tables[0].Rows[j]["PAN_ITMNM"].ToString() + "'");
                if (drCol.Length > 0)
                    dataTable.Rows[i - 1]["C_" + ds_item.Tables[0].Rows[j]["PAN_ITMNM"].ToString()] = Convert.ToDouble(drCol[0]["PAN_QTY"].ToString());
            }
        }

        return dataTable;
    }
    private string GetQuery_1(string yearStr)
    {
        string query = @"SELECT C.yyyy_mm, PAN_ITMNM, CONVERT(int,SUM(PAN_QTY)) AS PAN_QTY FROM CA_FT_PANMAE A,
		                    D_ITEM_PANMAE  B,
		                    D_TIME_ILJA C
	                        WHERE A.ITEM_IDX = B.PAN_IDX
			                        AND A.TIME_IDX = C.TM_IDX
							AND B.PAN_ITMNM LIKE '%¶ôÅ½%'
                                    AND SUBSTRING(CONVERT(varchar,C.yyyy_mm), 1, 4) = '" + yearStr + @"' 
                        GROUP BY C.yyyy_mm, PAN_ITMNM
	                        ORDER BY C.yyyy_mm, PAN_ITMNM";

        return query;
    }
    private void BindingChart_2(Dundas.Charting.WebControl.Chart chart, string yearStr)
    {
        string query_item = @"SELECT REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PAN_ITMNM, ' ', ''), '25Kg', ''), '(Plt)', ''), 'Bulk', ''), '20Kg', ''), '50Kg', ''), '1Ton', '') PAN_ITMNM FROM D_ITEM_PANMAE WHERE PAN_ITMNM LIKE '%À¯¾È%' GROUP BY REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PAN_ITMNM, ' ', ''), '25Kg', ''), '(Plt)', ''), 'Bulk', ''), '20Kg', ''), '50Kg', ''), '1Ton', '')";
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        //chart.DataSource = GetChartDataTable_2(yearStr).DefaultView;
        //DataGrid1.DataSource = GetChartDataTable(yearStr).DefaultView;
        //DataGrid1.DataBind();
        DataTable dt = GetChartDataTable_2(yearStr);

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 183
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
            //series.ValueMembersY = "C_" + ds_item.Tables[0].Rows[i]["PAN_IDX"].ToString();
            DatabaseBindingXY(series, "MONTH", "C_" + ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString(), dt);
            DundasAnimations.GrowingAnimation(chart, series, i, (i + 1), false);

            if (ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString() == "¼öÃâ¿ëÀ¯¾È")
            {
                series.YAxisType = AxisType.Secondary;
            }
            series.MarkerStyle = GetMarkerStyle(i);
            series.MarkerColor = GetChartColor(i);
            series.MarkerBorderColor = GetChartColor(i);
            series.ToolTip = "#VALY{N0}";

            string sChartArea = chart.Series[series.Name].ChartArea;
            chart.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
            chart.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";
            //SetZeroPoint(chart, int.Parse(ddlYear.SelectedValue));
        }

        SetVisibleZeroPoint(chart, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));

        Font font1 = new Font("Gulim", 9, FontStyle.Regular);
        Legend legend = DundasCharts.CreateLegend(chart, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }
    private DataTable GetChartDataTable_2(string yearStr)
    {
        string query = GetQuery_2(yearStr);
        string query_item = @"SELECT REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PAN_ITMNM, ' ', ''), '25Kg', ''), '(Plt)', ''), 'Bulk', ''), '20Kg', ''), '50Kg', ''), '1Ton', '') PAN_ITMNM FROM D_ITEM_PANMAE WHERE PAN_ITMNM LIKE '%À¯¾È%' GROUP BY REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PAN_ITMNM, ' ', ''), '25Kg', ''), '(Plt)', ''), 'Bulk', ''), '20Kg', ''), '50Kg', ''), '1Ton', '')";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("MONTH", typeof(string));

        for (int i = 0; i < ds_item.Tables[0].Rows.Count; i++)
        {
            dataTable.Columns.Add("C_" + ds_item.Tables[0].Rows[i]["PAN_ITMNM"].ToString(), typeof(double));
        }

        for (int i = 1; i <= 12; i++)
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = i.ToString();

            for (int j = 0; j < ds_item.Tables[0].Rows.Count; j++)
            {
                dr["C_" + ds_item.Tables[0].Rows[j]["PAN_ITMNM"].ToString()] = 0;
            }

            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            for (int j = 0; j < ds_item.Tables[0].Rows.Count; j++)
            {
                drCol = ds.Tables[0].Select("yyyy_mm = '" + yearStr + i.ToString().PadLeft(2, '0') + "' AND PAN_ITMNM = '" + ds_item.Tables[0].Rows[j]["PAN_ITMNM"].ToString() + "'");
                if (drCol.Length > 0)
                    dataTable.Rows[i - 1]["C_" + ds_item.Tables[0].Rows[j]["PAN_ITMNM"].ToString()] = Convert.ToDouble(drCol[0]["PAN_QTY"].ToString());
            }
        }

        return dataTable;
    }
    private string GetQuery_2(string yearStr)
    {
        string query = @"SELECT C.yyyy_mm, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PAN_ITMNM, ' ', ''), '25Kg', ''), '(Plt)', ''), 'Bulk', ''), '20Kg', ''), '50Kg', ''), '1Ton', '') PAN_ITMNM, CONVERT(int,SUM(PAN_QTY)) AS PAN_QTY FROM CA_FT_PANMAE A,
		                    D_ITEM_PANMAE  B,
		                    D_TIME_ILJA C
	                        WHERE A.ITEM_IDX = B.PAN_IDX
			                        AND A.TIME_IDX = C.TM_IDX
							AND B.PAN_ITMNM LIKE '%À¯¾È%'
                                    AND SUBSTRING(CONVERT(varchar,C.yyyy_mm), 1, 4) = '" + yearStr + @"' 
                        GROUP BY C.yyyy_mm, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PAN_ITMNM, ' ', ''), '25Kg', ''), '(Plt)', ''), 'Bulk', ''), '20Kg', ''), '50Kg', ''), '1Ton', '')
	                        ORDER BY C.yyyy_mm";

        return query;
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string yearStr = ddlYear.SelectedValue;

        BindingChart_1(Chart1, yearStr);
        BindingChart_2(Chart2, yearStr);
    }


    protected void SetZeroPoint(Chart chart, int iYear)
    {
        DateTime date = System.DateTime.Now;
        for (int i = 0; i < chart.Series.Count; i++)
        {
            for (int j = date.Month; j < chart.Series[i].Points.Count; j++)
            {
                //series2.Points[i].ShowLabelAsValue = true;

                if (chart.Series[i].Points[j].GetValueY(0) == 0 && date.Year == iYear)
                {
                    chart.Series[i].Points[j].Color = Color.Transparent;
                    chart.Series[i].Points[j].BorderColor = Color.Transparent;
                    chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
                    //chart.Series[i].Points[j].BorderWidth = 1;
                }
            }
        }
    }

}
