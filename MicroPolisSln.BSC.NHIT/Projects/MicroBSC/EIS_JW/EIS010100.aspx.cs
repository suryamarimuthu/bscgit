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
using Infragistics.WebUI.UltraWebGrid;

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.EIS.Dac;

using MicroBSC.Estimation.Biz;

public partial class EIS_EIS010100 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;

    private DataTable DT_DATA;

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        YMD             = WebUtility.GetRequest("YMD");
        M_ID            = WebUtility.GetRequestByInt("M_ID");
        S_ID            = WebUtility.GetRequestByInt("S_ID");

        if (!Page.IsPostBack)
        {
            SetData(ESTTERM_REF_ID, YMD);
            DataBinding();

            ifmContent.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 1));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
//        DataSet ds          = objEIS.GetData_M_0_S_1(estterm_ref_id, ymd);

        DataSet ds = objEIS.GetData_M_0_S_All(estterm_ref_id, ymd);

        DT_DATA = ds.Tables[0];

        DT_DATA             = DataTypeUtility.FilterSortDataTable(DT_DATA, "", "SORT_ORDER");
    }

    private void DataBinding() 
    {
        DataTable dt_ms1 = new DataTable();
        dt_ms1.Columns.Add("NAME", typeof(string));
        dt_ms1.Columns.Add("VAL", typeof(double));
        dt_ms1.Columns.Add("SORT_ORDER", typeof(int));

        DataTable dt_ts1 = new DataTable();
        dt_ts1.Columns.Add("NAME", typeof(string));
        dt_ts1.Columns.Add("VAL", typeof(double));
        dt_ts1.Columns.Add("SORT_ORDER", typeof(int));

        DataTable dt_ms2 = dt_ms1.Clone();
        DataTable dt_ts2 = dt_ts1.Clone();

		//전사-Global매출액 1367->3639로 변경(2010.07.15)  
        DataTable dt1 = DataTypeUtility.FilterSortDataTable(DT_DATA, string.Format("KPI_REF_ID = {0}", 3639));
        DataTable dt2 = DataTypeUtility.FilterSortDataTable(DT_DATA, string.Format("KPI_REF_ID = {0}", -3));
       
		if(dt1.Rows.Count > 0) 
        {
            DataRow dr = null;

            dr                  = dt_ms1.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = dt1.Rows[0]["TARGET_MS"];
            dr["SORT_ORDER"]    = 1;

            dt_ms1.Rows.Add(dr);

            dr                  = dt_ms1.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = dt1.Rows[0]["RESULT_MS"];
            dr["SORT_ORDER"]    = 2;

            dt_ms1.Rows.Add(dr);


            dr                  = dt_ts1.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = dt1.Rows[0]["TARGET_TS"];
            dr["SORT_ORDER"]    = 1;

            dt_ts1.Rows.Add(dr);

            dr                  = dt_ts1.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = dt1.Rows[0]["RESULT_TS"];
            dr["SORT_ORDER"]    = 2;

            dt_ts1.Rows.Add(dr);

            dr                  = dt_ts1.NewRow();
            dr["NAME"]          = "전년동기";
            dr["VAL"]           = dt1.Rows[0]["BF_RESULT_TS"];
            dr["SORT_ORDER"]    = 3;

            dt_ts1.Rows.Add(dr);
        }
        else
        {
            DataRow dr = null;

            dr                  = dt_ms1.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 1;

            dt_ms1.Rows.Add(dr);

            dr                  = dt_ms1.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 2;

            dt_ms1.Rows.Add(dr);


            dr                  = dt_ts1.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 1;

            dt_ts1.Rows.Add(dr);

            dr                  = dt_ts1.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 2;

            dt_ts1.Rows.Add(dr);

            dr                  = dt_ts1.NewRow();
            dr["NAME"]          = "전년동기";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 3;

            dt_ts1.Rows.Add(dr);
        }

        if(dt2.Rows.Count > 0) 
        {
            DataRow dr = null;

            dr                  = dt_ms2.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = dt2.Rows[0]["TARGET_MS"];
            dr["SORT_ORDER"]    = 1;

            dt_ms2.Rows.Add(dr);

            dr                  = dt_ms2.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = dt2.Rows[0]["RESULT_MS"];
            dr["SORT_ORDER"]    = 2;

            dt_ms2.Rows.Add(dr);


            dr                  = dt_ts2.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = dt2.Rows[0]["TARGET_TS"];
            dr["SORT_ORDER"]    = 1;

            dt_ts2.Rows.Add(dr);

            dr                  = dt_ts2.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = dt2.Rows[0]["RESULT_TS"];
            dr["SORT_ORDER"]    = 2;

            dt_ts2.Rows.Add(dr);

            dr                  = dt_ts2.NewRow();
            dr["NAME"]          = "전년동기";
            dr["VAL"]           = dt2.Rows[0]["BF_RESULT_TS"];
            dr["SORT_ORDER"]    = 3;

            dt_ts2.Rows.Add(dr);
        }
        else
        {
            DataRow dr = null;

            dr                  = dt_ms1.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 1;

            dt_ms1.Rows.Add(dr);

            dr                  = dt_ms1.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 2;

            dt_ms1.Rows.Add(dr);


            dr                  = dt_ts2.NewRow();
            dr["NAME"]          = "목표";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 1;

            dt_ts2.Rows.Add(dr);

            dr                  = dt_ts2.NewRow();
            dr["NAME"]          = "실적";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 2;

            dt_ts2.Rows.Add(dr);

            dr                  = dt_ts2.NewRow();
            dr["NAME"]          = "전년동기";
            dr["VAL"]           = 0;
            dr["SORT_ORDER"]    = 3;

            dt_ts2.Rows.Add(dr);
        }

        BindChart_ms( Chart1
                    , dt_ms1
                    , DataTypeUtility.FilterSortDataTable(dt_ms1, "SORT_ORDER = 1", "", "DT_1")
                    , DataTypeUtility.FilterSortDataTable(dt_ms1, "SORT_ORDER = 2", "", "DT_2")
                    , "당월");

        BindChart_ms( Chart3
                    , dt_ms2
                    , DataTypeUtility.FilterSortDataTable(dt_ms2, "SORT_ORDER = 1", "", "DT_1")
                    , DataTypeUtility.FilterSortDataTable(dt_ms2, "SORT_ORDER = 2", "", "DT_2")
                    , "당월");

        BindChart_ts( Chart2
                    , dt_ts1
                    , DataTypeUtility.FilterSortDataTable(dt_ts1, "SORT_ORDER = 1", "", "DT_1")
                    , DataTypeUtility.FilterSortDataTable(dt_ts1, "SORT_ORDER = 2", "", "DT_2")
                    , DataTypeUtility.FilterSortDataTable(dt_ts1, "SORT_ORDER = 3", "", "DT_3")
                    , "누계");

		//영업이익 누계 값으로 산출[10.07.20]
        BindChart_ts( Chart4
                    , dt_ts2
                    , DataTypeUtility.FilterSortDataTable(dt_ts2, "SORT_ORDER = 1", "", "DT_1")
                    , DataTypeUtility.FilterSortDataTable(dt_ts2, "SORT_ORDER = 2", "", "DT_2")
                    , DataTypeUtility.FilterSortDataTable(dt_ts2, "SORT_ORDER = 3", "", "DT_3")
                    , "누계");

        //uGrid.DataSource = DT_DATA;
        //uGrid.DataBind();

        UltraWebGrid1.DataSource = DT_DATA;
        UltraWebGrid1.DataBind();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        ///e.Layout.Bands[0].HeaderLayout.Reset();

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누계";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 6;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "증감액";
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "달성율";
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        
    }

    protected void uGrid_InitializeRow(object sender, RowEventArgs e)
    {

    }

    protected void uGrid_InitializeLayout(object sender, LayoutEventArgs e)
    {
        ///e.Layout.Bands[0].HeaderLayout.Reset();

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "당월";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누계";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 5;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    private void BindChart_ms(Chart chart
                            , DataTable dt
                            , DataTable dt1
                            , DataTable dt2
                            , string titleName)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 240
                                    , 160
                                    , BorderSkinStyle.Emboss
                                    , Color.FromArgb(181, 64, 1)
                                    , 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , "목표"
                                                , null
                                                , SeriesChartType.RangeColumn
                                                , 1
                                                , GetChartColor(0)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        Series series2 = DundasCharts.CreateSeries(chart
                                                , "Series2"
                                                , "Default"
                                                , "실적"
                                                , null
                                                , SeriesChartType.RangeColumn
                                                , 1
                                                , GetChartColor(1)
                                                , Color.FromArgb(0xD7, 0x41, 0x01)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        //series1.Label   = "#VALY{N0}";
        //series2.Label   = "#VALY{N0}";

        series1.ToolTip                                         = "#VALY{N0}";
        series2.ToolTip                                         = "#VALY{N0}";

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);
        DundasAnimations.GrowingAnimation(chart, series2, 0.5, 1.5, true);

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            series1.Points.AddXY(" ", dt1.Rows[i]["VAL"]);
        }

        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            series2.Points.AddXY(" ", dt2.Rows[i]["VAL"]);
        }


        //series1.ValueMemberX    = "NAME";
        //series1.ValueMembersY   = "VAL";

        //series2.ValueMemberX    = "NAME";
        //series2.ValueMembersY   = "VAL";

        //chart.DataSource = dt1;

        
        //chart.DataBind();

        //series1.ToolTip = "#VALY{#,##0,00}";
        //series2.ToolTip = "#VALY{#,##0}";

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points[i].AxisLabel = xValues[i].ToString();
        //}

        //series2.MarkerStyle         = MarkerStyle.Circle;
        //series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        Font font   = new Font("Gulim", 11, FontStyle.Regular);
        Font font1  = new Font("Gulim", 10, FontStyle.Regular);

        Dundas.Charting.WebControl.Title title = DundasCharts.CreateTitle(chart
                                                                        , "Title1"
                                                                        , titleName
                                                                        , font
                                                                        , Color.FromArgb(26, 59, 105)
                                                                        , Color.Empty
                                                                        , Color.Empty
                                                                        , ContentAlignment.TopCenter
                                                                        , null
                                                                        , Color.FromArgb(32, 0, 0, 0)
                                                                        , 3
                                                                        , false
                                                                        , 5
                                                                        , 7
                                                                        , 91
                                                                        , 6);

        Legend legend = DundasCharts.CreateLegend(chart
                                                , "Default"
                                                , Color.Transparent
                                                , Color.Empty
                                                , Color.Empty);

        legend.AutoFitText = false;
        legend.Position = new ElementPosition(70, 2, 50, 20);
        legend.Font = new Font("굴림", 7, FontStyle.Regular);

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    private void BindChart_ts(Chart chart
                            , DataTable dt
                            , DataTable dt1
                            , DataTable dt2
                            , DataTable dt3
                            , string titleName)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 240
                                    , 160
                                    , BorderSkinStyle.Emboss
                                    , Color.FromArgb(181, 64, 1)
                                    , 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , "목표"
                                                , null
                                                , SeriesChartType.RangeColumn
                                                , 1
                                                , GetChartColor(0)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        Series series2 = DundasCharts.CreateSeries(chart
                                                , "Series2"
                                                , "Default"
                                                , "실적"
                                                , null
                                                , SeriesChartType.RangeColumn
                                                , 1
                                                , GetChartColor(1)
                                                , Color.FromArgb(0xD7, 0x41, 0x01)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        Series series3 = DundasCharts.CreateSeries(chart
                                                , "Series3"
                                                , "Default"
                                                , "전년동기"
                                                , null
                                                , SeriesChartType.RangeColumn
                                                , 1
                                                , GetChartColor(2)
                                                , Color.FromArgb(107, 148, 49)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        //series1.Label   = "#VALY{N0}";
        //series2.Label   = "#VALY{N0}";
        //series3.Label   = "#VALY{N0}";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        series3.ToolTip = "#VALY{N0}";

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);
        DundasAnimations.GrowingAnimation(chart, series2, 0.5, 1.5, true);
        DundasAnimations.GrowingAnimation(chart, series3, 0.5, 1.5, true);

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            series1.Points.AddXY(" ", dt1.Rows[i]["VAL"]);
        }

        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            series2.Points.AddXY(" ", dt2.Rows[i]["VAL"]);
        }

        for (int i = 0; i < dt3.Rows.Count; i++)
        {
            series3.Points.AddXY(" ", dt3.Rows[i]["VAL"]);
        }


        //series1.ValueMemberX    = "NAME";
        //series1.ValueMembersY   = "VAL";

        //series2.ValueMemberX    = "NAME";
        //series2.ValueMembersY   = "VAL";

        //chart.DataSource = dt1;

        
        //chart.DataBind();

        //series1.ToolTip = "#VALY{#,##0,00}";
        //series2.ToolTip = "#VALY{#,##0}";

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points[i].AxisLabel = xValues[i].ToString();
        //}

        //series2.MarkerStyle         = MarkerStyle.Circle;
        //series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        Font font   = new Font("Gulim", 11, FontStyle.Regular);
        Font font1  = new Font("Gulim", 10, FontStyle.Regular);

        Dundas.Charting.WebControl.Title title = DundasCharts.CreateTitle(chart
                                                                        , "Title1"
                                                                        , titleName
                                                                        , font
                                                                        , Color.FromArgb(26, 59, 105)
                                                                        , Color.Empty
                                                                        , Color.Empty
                                                                        , ContentAlignment.TopCenter
                                                                        , null
                                                                        , Color.FromArgb(32, 0, 0, 0)
                                                                        , 3
                                                                        , false
                                                                        , 5
                                                                        , 7
                                                                        , 91
                                                                        , 6);

        Legend legend = DundasCharts.CreateLegend(chart
                                                , "Default"
                                                , Color.Transparent
                                                , Color.Empty
                                                , Color.Empty);

        //legend.AutoFitText = true;
        //legend.Position = new ElementPosition(60, 7, 50, 24);

        legend.AutoFitText = false;
        legend.Position = new ElementPosition(70, 2, 50, 25);
        legend.Font = new Font("굴림", 7, FontStyle.Regular);

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
