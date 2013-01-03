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

public partial class est0000 : AppPageBase
{
    DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetDropDownListYear(ddlYear);
            SetDropDownListMonth(ddlMonth);

            System.DateTime date = System.DateTime.Now.AddMonths(-1).AddDays(-15);
            ddlYear.Items.FindByValue(date.Year.ToString()).Selected = true;
            ddlMonth.Items.FindByValue(date.Month.ToString().PadLeft(2, '0')).Selected = true;

            ObjectBinding();
        }
    }
    private void SetDropDownListYear(System.Web.UI.WebControls.DropDownList ddlYear) 
    {
        for (int i = System.DateTime.Now.Year; i >= 1999; i--) 
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void SetDropDownListMonth(System.Web.UI.WebControls.DropDownList ddlMonth)
    {
        for (int i = 1; i <= 12; i++)
        {
            ddlMonth.Items.Add(new ListItem(i.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0')));
        }
    }
    private DataTable GetChartDataTable_1(string yearStr)
    {
        string query = GetColumnQuery_1(yearStr);
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        return dbAgent.FillDataSet(query, "Data").Tables[0];
    }
    private DataTable GetChartDataTable_2(string yearStr)
    {
        string query = GetColumnQuery_2(yearStr);
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        return dbAgent.FillDataSet(query, "Data").Tables[0];
    }
    private DataTable GetChartDataTable_3(string yearStr, string gongJangType)
    {
        string query = GetPieQuery_1(yearStr, gongJangType);
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        return dbAgent.FillDataSet(query, "Data").Tables[0];
    }
    private DataTable GetChartDataTable_4(string yearStr)
    {
        string query = GetPieQuery_2(yearStr);
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        return dbAgent.FillDataSet(query, "Data").Tables[0];
    }
    private string GetColumnQuery_1(string dateStr)
    {
        string query = @"SELECT D.GONGJANG, SUM(PLAN_QTY) PLAN_QTY, CONVERT(int,SUM(PROD_QTY)) PROD_QTY, CONVERT(int,SUM(BUHA)) BUHA  FROM CA_FT_SANGSAN A,
				            D_ITEM_SANGSAN B,
				            D_TIME_ILJA C,
				            D_GONGJANG D
                        WHERE A.ITEM_IDX = B.SAN_IDX
		                        AND A.TIME_IDX = C.TM_IDX
		                        AND C.yyyy_mm = " + dateStr + @"
		                        AND A.GONG_IDX = D.GO_IDX
                        GROUP BY D.GONGJANG";
        return query;
    }
    private string GetColumnQuery_2(string dateStr)
    {
        string query = @"SELECT PAN_ITMNM, CONVERT(int,SUM(PAN_QTY)) AS PAN_QTY FROM CA_FT_PANMAE A,
		                    D_ITEM_PANMAE  B,
		                    D_TIME_ILJA C
	                        WHERE A.ITEM_IDX = B.PAN_IDX
			                        AND A.TIME_IDX = C.TM_IDX
							AND B.PAN_ITMNM LIKE '%락탐%'
                                    AND C.yyyy_mm = " + dateStr + @"
                        GROUP BY C.yyyy_mm, PAN_IDX, PAN_ITMNM
	                        ORDER BY C.yyyy_mm";
        return query;
    }
    private string GetPieQuery_1(string dateStr, string gongJangType)
    {
        string query = @"
                            SELECT yyyy_mm, ITMJ_NAME + '\n(' + dbo.fn_FormatComma(SUM(JGO_QTY)) + ')' ITMJ_NAME, CONVERT(int,SUM(JGO_QTY)) JGO_QTY FROM CA_FT_JAEGO A,
		                            D_GONGJANG B,
		                            D_ITEM_JAEGO C,
		                            D_TIME_ILJA D
                            WHERE A.GONG_IDX = B.GO_IDX
		                            AND A.ITEM_IDX = C.ITMJ_IDX
		                            AND A.TIME_IDX = D.TM_IDX
		                            AND (GONG_IDX = " + gongJangType + @" OR 0 = " + gongJangType + @")
		                            AND yyyy_mm = " + dateStr + @"
                            GROUP BY yyyy_mm, ITMJ_NAME
                            ORDER BY yyyy_mm";
        return query;
    }
    private string GetPieQuery_2(string dateStr)
    {
        string query = @"SELECT B.AC_ACNT_NM + '\n(' + REPLACE(CONVERT(varchar,CONVERT(money, SUM(JAN_AMT) ),1), '.00', '') + ')' AC_ACNT_NM, SUM(JAN_AMT) JAN_AMT FROM CA_FT_SUGUM A,
			                D_ACOUNT B,
			                D_TIME_ILJA C
                        WHERE A.ACNT_IDX = B.AC_IDX
		                        AND A.DATE_IDX = C.TM_IDX
		                        AND yyyy_mm = " + dateStr + @"
                        GROUP BY B.AC_ACNT_NM";
        return query;
    }
    private void BindingColumChart_1(Dundas.Charting.WebControl.Chart chart, string dateStr)
    {
        chart.DataSource = GetChartDataTable_1(dateStr).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 400, 180
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", "계획량", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "생산량", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(chart, "Series3", "Default", "부하율", null, SeriesChartType.Column, 1, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "GONGJANG";
        series1.ValueMembersY = "PLAN_QTY";
        series2.ValueMembersY = "PROD_QTY";
        series3.ValueMembersY = "BUHA";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        series3.ToolTip = "#VALY{N0}";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 3.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 3.0, 4.0, true);
        DundasAnimations.GrowingAnimation(chart, series3, 4.0, 6.0, true);

        

        //series1.ShowLabelAsValue = true;
        //series2.ShowLabelAsValue = true;
        //series3.ShowLabelAsValue = true;
    }
    private void BindingColumChart_2(Dundas.Charting.WebControl.Chart chart, string dateStr)
    {
        chart.DataSource = GetChartDataTable_2(dateStr).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 400, 180
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series4", "Default", "판매실적", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "생산량", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series3 = DundasCharts.CreateSeries(chart, "Series3", "Default", "부하율", null, SeriesChartType.Column, 1, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "PAN_ITMNM";
        series1.ValueMembersY = "PAN_QTY";
        series1.ToolTip = "#VALY{N0}";
        //series2.ValueMembersY = "PROD_QTY";
        //series3.ValueMembersY = "BUHA";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 3.0, false);
        //DundasAnimations.GrowingAnimation(chart, series2, 3.0, 4.0, true);
        //DundasAnimations.GrowingAnimation(chart, series3, 4.0, 6.0, true);
        series1.ShowLabelAsValue = true;
        series1.LabelFormat = "N0";
    }
    private void BindingPieChart_3(string yearStr)
    {
        Chart3.DataSource = GetChartDataTable_3(yearStr, "0").DefaultView;

        DundasCharts.DundasChartBase(Chart3, ChartImageType.Flash, 400, 180
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart3, "Series11", "Default", "전공장", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "ITMJ_NAME";
        series1.ValueMembersY = "JGO_QTY";
        series1.ToolTip = "#VALY{N0}";

        DundasAnimations.DundasChartBase(Chart3, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart3, series1, 0.0, 3.0, false);
        
        series1["PieLabelStyle"] = "Outside";
        
        Chart3.Legends[0].Position.Auto = false;
        Chart3.Legends[0].Position.Height = 0;
        Chart3.Legends[0].Position.Width = 0;
        //series1.ShowLabelAsValue = true;
    }
    private void BindingPieChart_4(string yearStr)
    {
        Chart4.DataSource = GetChartDataTable_4(yearStr).DefaultView;

        DundasCharts.DundasChartBase(Chart4, ChartImageType.Flash, 400, 180
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart4, "Series10", "Default", "채권현황", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "AC_ACNT_NM";
        series1.ValueMembersY = "JAN_AMT";
        series1.ToolTip = "#VALY{N0}";

        DundasAnimations.DundasChartBase(Chart4, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart4, series1, 0.0, 3.0, false);

        series1["PieLabelStyle"] = "Outside";

        Chart4.Legends[0].Position.Auto = false;
        Chart4.Legends[0].Position.Height = 0;
        Chart4.Legends[0].Position.Width = 0;
        //series1.ShowInLegend = true;
    }
    private void ObjectBinding() 
    {
        string yearStr = ddlYear.SelectedValue;
        string monthStr = ddlMonth.SelectedValue;
        BindingColumChart_1(Chart1, yearStr + monthStr);
        BindingColumChart_2(Chart2, yearStr + monthStr);
        BindingPieChart_3(yearStr + monthStr);
        BindingPieChart_4(yearStr + monthStr);
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ObjectBinding();
    }
}
