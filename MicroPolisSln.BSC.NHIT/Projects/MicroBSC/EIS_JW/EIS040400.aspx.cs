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

public partial class EIS_EIS040400 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;
    private string BU;

    private DataSet DS_DATA;

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        YMD             = WebUtility.GetRequest("YMD");
        M_ID            = WebUtility.GetRequestByInt("M_ID");
        S_ID            = WebUtility.GetRequestByInt("S_ID");
        BU              = WebUtility.GetRequest("BU");

        if (!Page.IsPostBack)
        {
            SetData(ESTTERM_REF_ID, YMD);
            DataBinding();

            ifmContent1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 1));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DS_DATA             = objEIS.GetData_M_2_S_4(estterm_ref_id, ymd);

        //foreach(DataRow dr in DT_DATA_01.Rows) 
        //{
        //    dr["RESULT_TS"] = 2;
        //}

        //foreach(DataRow dr in DT_DATA_02.Rows) 
        //{
        //    dr["RESULT_TS"] = 2;
        //}
    }

    private void DataBinding() 
    {
        DataTable dt = null;

        if(BU.Equals("DD"))
        {
            dt = DS_DATA.Tables[0];
        }
        else if(BU.Equals("DO"))
        {
            dt = DS_DATA.Tables[1];
        }
        else if(BU.Equals("CJ")) 
        {
            dt = DS_DATA.Tables[2];

            dt = DataTypeUtility.FilterSortDataTable(dt, "", "SORT_ORDER, SORT_ORDER2 DESC");
        }
        else
            return;

        uGrid.DataSource = dt;
        uGrid.DataBind();

        dt.Columns.Add("TEXT", typeof(string));

        foreach(DataRow dr in dt.Rows) 
        {
            dr["TEXT"] = string.Format("{0}({2}%)"
                                    , dr["ALIAS"]
                                    , DataTypeUtility.GetToDouble(dr["RESULT_TS"]).ToString("#,##0.00")
                                    , DataTypeUtility.GetToDouble(dr["RESULT_RATIO"]).ToString("#,##0.00"));
        }

        BindChart(Chart1
                , DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER2 = 2", "SORT_ORDER")
                , "Item별 점유비 - 총매출"
                , lbl1);

        BindChart(Chart2
                , DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER2 = 1", "SORT_ORDER")
                , "Item별 점유비 - 내수매출"
                , lbl2);
    }

    protected void uGrid_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        if(drw["SORT_ORDER2"].ToString().Equals("1"))
            e.Row.Cells.FromKey("GB").Value = "내수매출";
        else if(drw["SORT_ORDER2"].ToString().Equals("2"))
            e.Row.Cells.FromKey("GB").Value = "총매출";
    }
    
    protected void uGrid_InitializeLayout(object sender, LayoutEventArgs e)
    {
        ///e.Layout.Bands[0].HeaderLayout.Reset();

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "당월";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누계";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    private void BindChart(Chart chart
                        , DataTable dt
                        , string titleName
                        , System.Web.UI.WebControls.Label lbl)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 330
                                    , 300
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
                                                , null
                                                , null
                                                , SeriesChartType.Doughnut
                                                , 1
                                                , GetChartColor(0)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        

        //series1.Label   = "#VALY{N0}";

        series1.ToolTip                                         = "#VALY{N0}";

        //series1.ShowLabelAsValue = true;
        //series1.ShowInLegend = true;

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points[i].AxisLabel = dt.Rows[i]["ALIAS"].ToString();
        //}

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points.AddY(dt.Rows[i]["RESULT_TS"]);
        //}

        DataTable dtData = DataTypeUtility.FilterSortDataTable(dt, "KPI_REF_ID > 0");

        for (int i = 0; i < dtData.Rows.Count; i++)
        {
            series1.Points.AddXY(dt.Rows[i]["TEXT"].ToString(), dt.Rows[i]["RESULT_TS"]);
        }

        if(series1.Type == SeriesChartType.Pie || series1.Type == SeriesChartType.Doughnut) 
        {
            for(int p = 0; p < series1.Points.Count; p++) 
            {
                DataPoint point = series1.Points[p];

                point.Color = GetChartColor(p);
            }
        }

        //series1.ToolTip = "#VALY{#,##0,00}";
        //series2.ToolTip = "#VALY{#,##0}";

        //series2.MarkerStyle         = MarkerStyle.Circle;
        //series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        Font font   = new Font("Gulim", 11, FontStyle.Regular);

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

        series1.Font = new Font("굴림", 8, FontStyle.Regular);
        series1["PieLabelStyle"] = "Outside";
        
        legend.LegendStyle = LegendStyle.Table;
        legend.AutoFitText = false;
        legend.Docking = LegendDocking.Bottom;
        //legend.Alignment = StringAlignment.Near;
        //legend.Position = new ElementPosition(60, 7, 50, 24);
        //legend.Enabled = false;
        //legend.DockInsideChartArea = true;
        //chart.ChartAreas["Default"].AlignOrientation = AreaAlignOrientation.Horizontal;

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], true);

        DataRow[] drCol = dt.Select(string.Format("KPI_REF_ID < 0"));

        if(drCol.Length > 0) 
        {
            lbl.Text = DataTypeUtility.GetToDouble(drCol[0]["RESULT_TS"]).ToString("#,##0");
        }
        else 
        {
            lbl.Text = "0";
        }
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
