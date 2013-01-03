using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
//using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

using System.Web.UI.DataVisualization.Charting;

using MicroCharts;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class Dashboard_NHIT_Main_Table_Chart : AppPageBase
    //public partial class Dashboard_NHIT_Main : Page
{
    public string CR_YEAR       = "0000";
    public string CR_MONTH      = "00";
    public int ikpiType         = 0;
    public String skpiType      = "";
    public String kpiType       = "";
    public String champname     = "";
    public String check_purpose = "";
    public String calc_form     = "";
    public String grammer       = "";
    public String issue         = "";
    public String is3D          = "";
    public string TG_GUBUN      = "T";
    decimal sumplanVal          = 0;
    decimal sumactVal           = 0;
    decimal old_chkVal          = 0;
    decimal old_chksumVal       = 0;
    int cnt                     = 0;

    int intRowNum = 0;
    Workbook workBook = null; // smjjang

    public string unit = "-";

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "000000");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }
    public enum GRP_ONE_ID
    {
        A // 전사
      , B // 고객사
        , C // 사업유형
        , D // 본부
    }

    public enum GRP_TWO_ID : int
    {
        GTO_10 = 10 // 전사
      ,
        GTO_20 = 20// 중앙회
      ,
        GTO_30 = 30// 계열사
      , GTO_40 = 40// 대외
        , GTO_50 = 50// SI
        , GTO_60 = 60// SM
        , GTO_70 = 70// 상품
        , GTO_80 = 80// 사업지원
        , GTO_90 = 90// 금융사업
        , GTO_100 = 100// 경제사업
        , GTO_110 = 110// 카드사업
        , GTO_120 = 120// 보험부문
        , GTO_130 = 130// 전략사업
    }

    public enum GRP_THREE_ID
    {
        ME // 매출
      ,
        YG // 영업이익
        ,
        DN // 당기순이익
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitializing();

            CR_YEAR = ddlYear.Items[ddlYear.Items.Count - 1].Value;
            CR_MONTH = ddlMonth.Items[ddlMonth.Items.Count - 1].Value;

            iBtnSearch_Click(null, null);
            base.SetMenuControl(true, false, true);
        }
        else
        {

        }

        CR_YEAR = ddlYear.SelectedValue;
        CR_MONTH = ddlMonth.SelectedValue;
    }

    #region 페이지 초기화 함수

    private void DoInitializing()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtYear = bizNHIT.GetYear_DB();

        if (dtYear.Rows.Count > 0)
        {
            ddlYear.DataSource = dtYear;
            ddlYear.DataTextField = "CR_YEAR_NAME";
            ddlYear.DataValueField = "CR_YEAR";
            ddlYear.DataBind();
        }
        else
        {
            ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
        }

        DataTable dtMonth = bizNHIT.GetMonth_DB();

        if (dtMonth.Rows.Count > 0)
        {
            ddlMonth.DataSource = dtMonth;
            ddlMonth.DataTextField = "CR_MONTH_NAME";
            ddlMonth.DataValueField = "CR_MONTH";
            ddlMonth.DataBind();
        }
        else
        {
            ddlMonth.Items.Add(new ListItem(DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString()));
        }
    }

    private void DoBinding_JeonSa()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetJeonSa(GRP_ONE_ID.A.ToString()
                                           , (int)GRP_TWO_ID.GTO_10
                                           , CR_YEAR
                                           , CR_MONTH
                                           , TG_GUBUN);

        UltraWebGrid1.DataSource = dtNHIT;
        UltraWebGrid1.DataBind();

        //dtNHIT = bizNHIT.GetJeonSa(GRP_ONE_ID.A.ToString()
        //                           , (int)GRP_TWO_ID.GTO_10
        //                           , GRP_THREE_ID.ME.ToString()
        //                           , CR_YEAR
        //                           , CR_MONTH);

        DoDrawingJunsaChart1(dtNHIT, chart1);

        dtNHIT = bizNHIT.GetJeonSa(GRP_ONE_ID.A.ToString()
                                   , (int)GRP_TWO_ID.GTO_10
                                   , GRP_THREE_ID.DN.ToString()
                                   , CR_YEAR
                                   , "");

        DoDrawingJunsaChart2(dtNHIT, chartMM);
    }

    private void DoBinding_InPower()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetInPower(CR_YEAR);

        UltraWebGrid2.DataSource = dtNHIT;
        UltraWebGrid2.DataBind();
        DoDrawingInPower(dtNHIT, chart2);
    }

    private void DoBinding_ETC()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT_B = bizNHIT.GetEtc(GRP_ONE_ID.B.ToString()
                                           , CR_YEAR
                                           , CR_MONTH
                                           , TG_GUBUN);

        UltraWebGrid3.DataSource = dtNHIT_B;
        UltraWebGrid3.DataBind();
        DoDrawingEtcChart(dtNHIT_B, chart3,4);


        DataTable dtNHIT_C = bizNHIT.GetEtc(GRP_ONE_ID.C.ToString()
                                           , CR_YEAR
                                           , CR_MONTH
                                           , TG_GUBUN);

        UltraWebGrid4.DataSource = dtNHIT_C;
        UltraWebGrid4.DataBind();
        DoDrawingEtcChart(dtNHIT_C, chart4,17);


        DataTable dtNHIT_D = bizNHIT.GetEtc(GRP_ONE_ID.D.ToString()
                                           , CR_YEAR
                                           , CR_MONTH
                                           , TG_GUBUN);

        UltraWebGrid5.DataSource = dtNHIT_D;
        UltraWebGrid5.DataBind();
        DoDrawingEtcChart(dtNHIT_D, chart5,13);
    }


    #endregion

    private void DoDrawingJunsaChart1(DataTable dtChart, Chart chart)
    {

        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , 340
                               , 250
                               , BorderSkinStyle.Emboss
                               , Color.FromArgb(181, 64, 1)
                               , 2
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "목표", null, SeriesChartType.Column, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series3 = MSCharts.CreateSeries(chart, "serPlan", "Default", "목표", null, SeriesChartType.Column, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series5 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series6 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Line, 1, GetChartColor2(2), GetChartColor2(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.YValueMembers = "TARGET_TS";
        series2.YValueMembers = "RESULT_TS";
        series1.XValueMember = "GRP_THREE_NAME";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";

        string sChartArea = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

        chart.DataBind();
    }


    private void DoDrawingJunsaChart2(DataTable dtChart, Chart chart)
    {

        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , 450
                               , 250
                               , BorderSkinStyle.Emboss
                               , Color.FromArgb(181, 64, 1)
                               , 2
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "목표", null, SeriesChartType.Line, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Line, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        // Enable data points labels
        series1.IsValueShownAsLabel = true;
        series2.IsValueShownAsLabel = true;

        series1.BorderWidth = 3;
        series1.BorderColor = GetChartColor2(0);

        // Enable data points markers
        series2.MarkerStyle = MarkerStyle.Circle;
        series2.MarkerSize = 2;
        series2.MarkerColor = Color.Magenta;

        series2.BorderWidth = 3;
        series2.BorderColor = GetChartColor2(1);

        //Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Line, 1, GetChartColor2(2), GetChartColor2(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.YValueMembers = "TARGET_TS";
        series2.YValueMembers = "RESULT_TS";
        series1.XValueMember = "CR_MONTH_NAME";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";

        string sChartArea = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

        // Disable X axis margin
        chart.ChartAreas[sChartArea].AxisX.IsMarginVisible = false;

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
            chart.ChartAreas[sChartArea].Area3DStyle.Enable3D = false;
        else
            chart.ChartAreas[sChartArea].Area3DStyle.Enable3D = true;

        chart.DataBind();
    }

    private void DoDrawingInPower(DataTable dtChart, Chart chart)
    {

        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , 450
                               , 250
                               , BorderSkinStyle.Emboss
                               , Color.FromArgb(181, 64, 1)
                               , 2
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "목표 가득율", null, SeriesChartType.Line, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "가득율", null, SeriesChartType.Area, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        // Enable data points labels
        series1.IsValueShownAsLabel = true;
        series2.IsValueShownAsLabel = true;

        series1.BorderWidth = 3;
        series1.BorderColor = GetChartColor2(0);

        // Set SplineArea chart type
        series2.ChartType = SeriesChartType.SplineArea;

        // Set spline line tension 
        series2["LineTension"] = "0.1";

        // Enable data points markers
        series2.MarkerStyle = MarkerStyle.Circle;
        series2.MarkerSize = 5;
        series2.MarkerColor = Color.Magenta;

        series2.BorderWidth = 3;
        series2.BorderColor = GetChartColor2(1);

        //Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Line, 1, GetChartColor2(2), GetChartColor2(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.YValueMembers = "TARGET_FULL_RATE";
        series2.YValueMembers = "RESULT_FULL_RATE";
        series1.XValueMember = "CR_MONTH_NAME";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";

        string sChartArea = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "P0";
        chart.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

        // Disable X axis margin
        chart.ChartAreas[sChartArea].AxisX.IsMarginVisible = false;

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
            chart.ChartAreas[sChartArea].Area3DStyle.Enable3D = false;
        else
            chart.ChartAreas[sChartArea].Area3DStyle.Enable3D = true;

        chart.DataBind();
    }

    private void DoDrawingEtcChart(DataTable dtChart, Chart chart, int colorCode)
    {
       
        // 당월그래프
        MSCharts.DundasChartBase(chart, ChartImageType.Jpeg, 410, 250
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart, "ME1", "Default", "매출(목표)", null, SeriesChartType.Column, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chart, "ME2", "Default", "매출(실적)", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Series series3 = MSCharts.CreateSeries(chart, "YG1", "Default", "영업(목표)", null, SeriesChartType.Column, 1, GetChartColor2(4), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series4 = MSCharts.CreateSeries(chart, "YG2", "Default", "영업(실적)", null, SeriesChartType.Column, 1, GetChartColor2(13), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Line, 1, GetChartColor2(colorCode), GetChartColor2(colorCode), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        if (series2.ChartType == SeriesChartType.Line)
        {
            series2.IsValueShownAsLabel = true;
            series2.MarkerStyle = MarkerStyle.Circle;
            series2.MarkerSize = 5;
            series2.MarkerColor = Color.Magenta;

            series2.BorderWidth = 3;
        }

        series1.YValueMembers = "ME_TARGET_TS";
        series2.YValueMembers = "ME_RESULT_TS";
        series3.YValueMembers = "YG_TARGET_TS";
        series4.YValueMembers = "YG_RESULT_TS";
        series1.XValueMember = "GRP_TWO_NAME";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        series3.ToolTip = "#VALY{N0}";
        series4.ToolTip = "#VALY{N0}";

        string sChartArea = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";

        string sChartArea2 = chart.Series[series3.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
        {
            chart.ChartAreas[sChartArea].Area3DStyle.Enable3D = false;
        }
        else
        {
            chart.ChartAreas[sChartArea].Area3DStyle.Enable3D = true;
        }

        chart.DataBind();
    }

    private void SetResutlGraph(DataSet iDs)
    {
        DataSet dsGrph = iDs.Copy();
        dsGrph.Tables[0].Columns.Add("GR_RATE_MS", typeof(double));
        dsGrph.Tables[0].Columns.Add("GR_RATE_TS", typeof(double));

        for (int i = 0; i < dsGrph.Tables[0].Rows.Count; i++)
        {
            if (dsGrph.Tables[0].Rows[i]["AC_RATE_MS"].ToString() == "-")
            {
                dsGrph.Tables[0].Rows[i]["AC_RATE_MS"] = "0";
            }
            dsGrph.Tables[0].Rows[i]["GR_RATE_MS"] = Convert.ToDouble(dsGrph.Tables[0].Rows[i]["AC_RATE_MS"].ToString());

            if (dsGrph.Tables[0].Rows[i]["AC_RATE_TS"].ToString() == "-")
            { 
                dsGrph.Tables[0].Rows[i]["AC_RATE_TS"] = "0";
            }
            dsGrph.Tables[0].Rows[i]["GR_RATE_TS"] = Convert.ToDouble(dsGrph.Tables[0].Rows[i]["AC_RATE_TS"].ToString());
        }

        // 당월그래프
        MSCharts.DundasChartBase(chartMM, ChartImageType.Jpeg, 385, 230
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

        chartMM.DataSource = dsGrph;

        Series series1 = MSCharts.CreateSeries(chartMM, "serPlan", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chartMM, "serActl", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = MSCharts.CreateSeries(chartMM, "serRate", "Default", (kpiType == "BTY" ? "한계초과율" : "달성율"), null, SeriesChartType.Line, 1, GetChartColor2(2), GetChartColor2(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        series3.YAxisType = AxisType.Secondary;

        series1.YValueMembers = "TARGET_MS";
        series2.YValueMembers = "RESULT_MS";
        series3.YValueMembers = "GR_RATE_MS";
        series1.XValueMember = "MM";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        series3.ToolTip = "#VALY{P0}";

        string sChartArea = chartMM.Series[series2.Name].ChartArea;
        chartMM.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        chartMM.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

        //DundasAnimations.DundasChartBase(chartMM, AnimationTheme.None, -1, -1, false, 1);
        //DundasAnimations.GrowingAnimation(chartMM, series1, 1.0, 1.0, true);
        //DundasAnimations.GrowingAnimation(chartMM, series2, 2.0, 2.0, true);
        //DundasAnimations.GrowingAnimation(chartMM, series3, 2.0, 1.0, true);

        chartMM.DataBind();

    }

    protected Color GetChartColor2(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(CHART_COLOR[iCheck, 0], CHART_COLOR[iCheck, 1], CHART_COLOR[iCheck, 2]);
    }

    protected int[,] CHART_COLOR = new int[,]
                                   {
                                        {0x0c, 0x4c, 0xd4},
                                        {0xff, 0xa1, 0x0d},
                                        {0xad, 0x00, 0x00},
                                        {0xff, 0x72, 0x00},
                                        {0x75, 0xd8, 0x00},
                                        {0xA8, 0xD2, 0xFD},
                                        {0xFB, 0xEE, 0xA6},
                                        {0xFC, 0xD1, 0xA6},
                                        {0xD1, 0xFC, 0xD1},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };


    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding_JeonSa();
        DoBinding_InPower();
        DoBinding_ETC();

    }

    protected void ugrdKpiResultStatus_InitializeLayout(object sender, LayoutEventArgs e)
    {
        ////Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ////ch.Caption = "월별 조회";
        ////ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ////ch.RowLayoutColumnInfo.OriginY = 0;
        ////ch.RowLayoutColumnInfo.OriginX = 1;
        ////ch.RowLayoutColumnInfo.SpanX = 6;
        ////e.Layout.Bands[0].HeaderLayout.Add(ch);

        ////ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ////ch.Caption = "누적 조회";
        ////ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ////ch.RowLayoutColumnInfo.OriginY = 0;
        ////ch.RowLayoutColumnInfo.OriginX = 8;
        ////ch.RowLayoutColumnInfo.SpanX = 6;
        ////e.Layout.Bands[0].HeaderLayout.Add(ch);

        ////// 단일 헤더 합침
        ////ch = e.Layout.Bands[0].Columns.FromKey("MM").Header;
        ////ch.RowLayoutColumnInfo.SpanY = 2;
        ////ch.RowLayoutColumnInfo.OriginY = 0;

        //int iIndex = 0;
        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        //foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        //{
        //    c.Header.RowLayoutColumnInfo.OriginY = 1;
        //    c.Header.RowLayoutColumnInfo.OriginX = iIndex;
        //    iIndex++;
        //}

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "월";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanX = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "[ 당 월 ]";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 1;
        //ch.RowLayoutColumnInfo.SpanX = 6;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 7;
        //ch.RowLayoutColumnInfo.SpanX   = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //ch.Style.BackColor = Color.White;
        //ch.Style.BorderColor = Color.White;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "[ 누 적 ]";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 8;
        //ch.RowLayoutColumnInfo.SpanX = 7;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        

        //// 단일 헤더 합침
        //ch = e.Layout.Bands[0].Columns.FromKey("MM").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        //e.Layout.Bands[0].Columns.FromKey("SPLITER").Header.Style.BackColor = Color.White;

        //// 단일 헤더 합침
        ////ch = e.Layout.Bands[0].Columns.FromKey("SPLITER").Header;
        ////ch.RowLayoutColumnInfo.SpanY = 2;
        ////ch.RowLayoutColumnInfo.OriginY = 0;
    }
    
    protected void ugrdKpiResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        
    }

    protected void ugrdCommunication_InitializeRow(object sender, RowEventArgs e)
    { 
        //int intSpace     = (e.Row.Cells.FromKey("TREE_LEVEL").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("TREE_LEVEL").Value.ToString()) : 0;
        //string strReIcon = "<img alt='' src='../images/icon/board_re.gif' style=\"vertical-align:middle;\" />";
        //string strTitle  = (e.Row.Cells.FromKey("TITLE").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("TITLE").Value) : "";
        //string strReadYN = (e.Row.Cells.FromKey("READ_YN").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("READ_YN").Value) : "X";
        //string strEmpty  = "";

        //if (intSpace > 1)
        //{
        //    e.Row.Cells.FromKey("TITLE").Text = strEmpty.PadRight((intSpace-1)*2, ' ') + strReIcon + strTitle;
        //}

        //string strOkIcon = "<img alt='미확인' src='../images/icon/gr_po01_b.gif' style=\"vertical-align:middle;\" />";
        //if (strReadYN == "N")
        //{
        //    e.Row.Cells.FromKey("NUM_TEXT").Text = strOkIcon;
        //}
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        //this.SetResultGrid();
        //this.SetInitiativeInfo();
        //this.SetCommunicationGrid();
    }

    protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        //this.ExcelDownLoad();
    }

    #region ================================= [ 엑셀다운로드  ] ============================
    /// <summary>
    /// 엑셀 다운로드
    /// </summary>
    private void ExcelDownLoad()
    {
        //string strCurDate = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');

        //ugrdEEP.ExportMode = ExportMode.Download;
        //ugrdEEP.DownloadName = "KpiWorkDetail" + strCurDate + ".xls";

        //this.AddWorkSheet(); // Sheet추가
    }

    /// <summary>
    /// Tab페이지별 엑셀Sheet 추가
    /// </summary>
    private void AddWorkSheet()
    {
        workBook = new Workbook();

        //Sheet추가 
        workBook.Worksheets.Add("KPI 실적상세");

        #region ==> KPI 실적상세
        workBook.ActiveWorksheet = workBook.Worksheets[0];
        //ugrdEEP.ExcelStartRow = 7;
        //ugrdKpiResultStatus.Columns[3].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[5].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[12].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[14].Hidden = true;  //이미지컬럼 숨김

        //ugrdKpiResultStatus.Columns[4].Hidden =false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[6].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[13].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[15].Hidden = false;  //이미지컬럼 숨김


        //ugrdEEP.Export(ugrdKpiResultStatus, workBook.ActiveWorksheet);

        //ugrdKpiResultStatus.Columns[3].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[5].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[12].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[14].Hidden = false;  //이미지컬럼 숨김

        //ugrdKpiResultStatus.Columns[4].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[6].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[13].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[15].Hidden = true;  //이미지컬럼 숨김
        #endregion
    }

    /// <summary>
    /// Sheet별 공통데이타
    /// </summary>
    private void CommonDataPrint()
    {
        //foreach (Worksheet ws in workBook.Worksheets)
        //{
        //    ws.Rows[0].Cells[0].Value = "KPI 코드 : " + lblKpiCode.Text.Trim();
        //    ws.Rows[1].Cells[0].Value = "KPI 명:  " + lblKpiName.Text.Trim();
        //    ws.Rows[2].Cells[0].Value = "단위 : " + lblUnitName.Text.Trim();
        //    ws.Rows[3].Cells[0].Value = "누적형태: " + lblPNUType.Text.Trim();
        //    ws.Rows[4].Cells[0].Value = "계획월: " + ddlMonthInfo.SelectedItem.Text.Trim();


        //    ws.Rows[21].Cells[0].Value = "Initiative 추진계획";
        //    ws.Rows[22].Cells[1].Value = txtINITIATIVE_PLAN.Text.Trim();

        //    ws.Rows[24].Cells[0].Value = "Initiative 추진내용";
        //    ws.Rows[25].Cells[1].Value = txtINITIATIVE_DO.Text.Trim();


        //    ws.Rows[27].Cells[0].Value = "원인및 대책";
        //    ws.Rows[28].Cells[0].Value = "원인분석 당월: ";
        //    ws.Rows[28].Cells[1].Value = txtReason_Month.Text.Trim();
        //    ws.Rows[29].Cells[0].Value = "원인분석 누적: ";
        //    ws.Rows[29].Cells[1].Value = txtReason_Sum.Text.Trim();

        //    ws.Rows[30].Cells[0].Value = "대책검토 당월: ";
        //    ws.Rows[30].Cells[1].Value = txtReason_Month.Text.Trim();
        //    ws.Rows[31].Cells[0].Value = "대책검토 누적: ";
        //    ws.Rows[31].Cells[1].Value = txtReason_Sum.Text.Trim();

        //    this.SetCoulumStlye(ws, 0, 0);
        //    this.SetCoulumStlye(ws, 0, 5);
        //    this.SetCoulumStlye(ws, 1, 0);
        //    this.SetCoulumStlye(ws, 1, 5);
        //    this.SetCoulumStlye(ws, 2, 0);
        //    this.SetCoulumStlye(ws, 2, 5);
        //    this.SetCoulumStlye(ws, 3, 0);
        //    this.SetCoulumStlye(ws, 3, 5);
        //    this.SetCoulumStlye(ws, 4, 0);
        //    this.SetCoulumStlye(ws, 4, 5);


        //    this.SetCoulumStlye(ws, 21, 0);
        //    this.SetCoulumStlye(ws, 21, 5);
        //    this.SetCoulumStlye(ws, 22, 0);
        //    this.SetCoulumStlye(ws, 22, 5);
        //    this.SetCoulumStlye(ws, 24, 0);
        //    this.SetCoulumStlye(ws, 24, 5);
        //    this.SetCoulumStlye(ws, 25, 0);
        //    this.SetCoulumStlye(ws, 25, 5);
        //    this.SetCoulumStlye(ws, 27, 0);
        //    this.SetCoulumStlye(ws, 27, 5);

        //    this.SetCoulumStlye(ws, 28, 0);
        //    this.SetCoulumStlye(ws, 28, 5);
        //    this.SetCoulumStlye(ws, 29, 0);
        //    this.SetCoulumStlye(ws, 29, 5);
        //    this.SetCoulumStlye(ws, 30, 0);
        //    this.SetCoulumStlye(ws, 30, 5);
        //    this.SetCoulumStlye(ws, 31, 0);
        //    this.SetCoulumStlye(ws, 31, 5);

        //}
    }

    /// <summary>
    /// 엑셀Cell별 스타일설정
    /// </summary>
    /// <param name="ws">workSheet</param>
    /// <param name="row">rowIndex</param>
    /// <param name="cell">cellIndex</param>
    private void SetCoulumStlye(Worksheet ws, int row, int cell)
    {
        ws.Rows[row].Cells[cell].CellFormat.Font.Height = 250;
        ws.Rows[row].Height = 400;
        ws.Columns[cell].Width = 18 * 256;
        ws.Rows[row].Expanded = true;
    }

    protected void ugrdEEP_BeginExport(object sender, Infragistics.WebUI.UltraWebGrid.ExcelExport.BeginExportEventArgs e)
    {
        this.CommonDataPrint();
    }

    protected void ugrdEEP_CellExporting(object sender, Infragistics.WebUI.UltraWebGrid.ExcelExport.CellExportingEventArgs e)
    {
        this.SetCoulumStlye(e.CurrentWorksheet, e.CurrentRowIndex, e.CurrentColumnIndex);
    }

    protected void ugrdPrjList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        //DataRowView dr = (DataRowView)e.Data;

        //Biz_Prj_Resource objResource = new Biz_Prj_Resource();
        ////Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        //DataSet ds = objResource.GetAllList(DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]), 0);
        ////object oRate = objSchedule.GetTotalRate(DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]), 0);
        ////double dTotalRate = 0;

        //string EMP_NAMES = "";

        //foreach (DataRow row in ds.Tables[0].Rows)
        //{
        //    EMP_NAMES += row["EMP_NAME"].ToString() + Environment.NewLine;
        //}

        //e.Row.Cells.FromKey("TASK_OWNER_NAME").Value = EMP_NAMES;

        ////dTotalRate = DataTypeUtility.GetToDouble(oRate);
        ////e.Row.Cells.FromKey("PROCEED_RATE").Value = dTotalRate.ToString("###.#0") + " %";

    }

    protected void ugrdPrjList_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void grvResultExpt_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell oTableCell = new TableHeaderCell();

            oTableCell.ColumnSpan = 1;
            oTableCell.RowSpan = 2;
            oTableCell.Text = "구분";
            oTableCell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#94bac9");
            oTableCell.Style.Add(HtmlTextWriterStyle.Color, "white");
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "[ 당  월 ]";
            oTableCell.ColumnSpan = 3;
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "[ 누  적 ]";
            oTableCell.ColumnSpan = 3;
            oGridViewRow.Cells.Add(oTableCell);

            oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

            e.Row.Cells[0].Visible = false;

            e.Row.Cells[0].Width = Unit.Pixel(120);
            e.Row.Cells[1].Width = Unit.Pixel(120);
            e.Row.Cells[2].Width = Unit.Pixel(120);
            e.Row.Cells[3].Width = Unit.Pixel(90);
            e.Row.Cells[4].Width = Unit.Pixel(120);
            e.Row.Cells[5].Width = Unit.Pixel(120);
            e.Row.Cells[6].Width = Unit.Pixel(90);
        }
    }
    
    protected void grvResultExpt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string sGubun = e.Row.Cells[0].Text;
        switch (sGubun)
        {
            case "EXPT":
                e.Row.Cells[0].Text = "예측실적";
                break;
            case "CURR":
                e.Row.Cells[0].Text = "당월실적";
                break;
            case "DIFF":
                e.Row.Cells[0].Text = "차    이";
                break;
            default:
                e.Row.Cells[0].Text = "-";
                break;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[6].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        }

        e.Row.Cells[1].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[1].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[2].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[2].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[3].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[3].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[4].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[4].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[5].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[5].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[6].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[6].Text), "#,###,###,###,###,###,###,##0.00");
    }

    #endregion
}
