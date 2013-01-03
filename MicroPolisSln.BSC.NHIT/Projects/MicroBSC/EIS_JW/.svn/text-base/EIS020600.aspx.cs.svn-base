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

public partial class EIS_EIS020600 : EstPageBase
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
            ifmContent2.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 2));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DS_DATA             = objEIS.GetData_M_2_S_6(estterm_ref_id, ymd);


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
            dt = DS_DATA.Tables[0];
        else if(BU.Equals("DO"))
            dt = DS_DATA.Tables[1];
        else if(BU.Equals("CJ"))
            dt = DS_DATA.Tables[2];
        else
            return;

        DataTable dtChart   = DataTypeUtility.FilterSortDataTable(dt, "CHART_USE = 'Y'");
        DataTable dtGrid    = DataTypeUtility.FilterSortDataTable(dt, "GRID_USE = 'Y'");

        uGrid.DataSource = dtGrid;
        uGrid.DataBind();

        BindChart(Chart1
                , dtChart
                , "계획대비 실적");
    }

    protected void uGrid_InitializeRow(object sender, RowEventArgs e)
    {

    }
    
    protected void uGrid_InitializeLayout(object sender, LayoutEventArgs e)
    {
        ///e.Layout.Bands[0].HeaderLayout.Reset();

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누계";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    private void BindChart(Chart chart
                        , DataTable dt
                        , string titleName)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 480
                                    , 310
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

        Series series1 =  DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , "사업계획"
                                                , null
                                                , SeriesChartType.Column
                                                , 1
                                                , GetChartColor(0)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        Series series2 =  DundasCharts.CreateSeries(chart
                                                , "Series2"
                                                , "Default"
                                                , "사업실적"
                                                , null
                                                , SeriesChartType.Column
                                                , 1
                                                , GetChartColor(1)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        //series1.Label   = "#VALY{N0}";

        series1.ToolTip                                         = "#VALY{N0}";
        series2.ToolTip                                         = "#VALY{N0}";

        //series1.ShowLabelAsValue = true;
        //series1.ShowInLegend = true;

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);
        DundasAnimations.GrowingAnimation(chart, series2, 0.5, 1.5, true);

        series1.Font = new Font("굴림", 7, FontStyle.Regular);
        series2.Font = new Font("굴림", 7, FontStyle.Regular);

        for(int i = 0; i < dt.Rows.Count; i++) 
        {
            series1.Points.AddXY(dt.Rows[i]["ALIAS"].ToString(), dt.Rows[i]["TARGET_TS"]);
        }

        for(int i = 0; i < dt.Rows.Count; i++) 
        {
            series2.Points.AddY(dt.Rows[i]["RESULT_TS"]);
        }

        //DataTable dtData = DataTypeUtility.FilterSortDataTable(dt, "KPI_REF_ID > 0");

        //if(k == 0) 
        //{
        //    series1.Points.AddXY("계획", dt.Rows[k]["TARGET_TS"]);
        //    series1.Points.AddXY("실적", dt.Rows[k]["RESULT_TS"]);
        //}
        //else 
        //{
        //    series1.Points.AddY(dt.Rows[k]["TARGET_TS"]);
        //    series1.Points.AddY(dt.Rows[k]["RESULT_TS"]);
        //}

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

        //DataRow[] drCol = dt.Select(string.Format("KPI_REF_ID < 0"));

        //DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);

        //if(drCol.Length > 0) 
        //{
        //    lbl.Text = DataTypeUtility.GetToDouble(drCol[0]["RNF_RATE"]).ToString("#,##0.00") + "%";
        //}
        //else 
        //{
        //    lbl.Text = "0" + "%";
        //}
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
