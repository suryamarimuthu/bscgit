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

public partial class Dashboard_NHIT_Main_Table_1280 : AppPageBase
{
    protected Color CHART_BORDER_BLUE = Color.FromArgb(87, 123, 201);
    protected Color CHART_BORDER_GRAY = Color.FromArgb(194, 194, 194);

    protected Color CHART_COLUMN_RED = Color.FromArgb(200, 255, 0, 0);

    protected Color CHART_COLUMN_BLUE = Color.FromArgb(200, 0, 128, 255);
    protected Color CHART_COLUMN_GR = Color.FromArgb(150, 116, 255, 15);
    protected Color CHART_COLUMN_YELLOW = Color.FromArgb(200, 255, 255, 0); 
   
    protected Color CHART_COLUMN_GREEN = Color.FromArgb(129, 211, 89);
    protected Color CHART_COLUMN_ORANGE = Color.FromArgb(255, 173, 65);
    protected Color CHART_COLUMN_BORDER = Color.FromArgb(102, 102, 102);

    protected Color CHART_LINE_BLUE = Color.FromArgb(58, 127, 205);
    protected Color CHART_LINE_ORANGE = Color.FromArgb(242, 129, 46);
    //protected Color CHART_COLUMN_BORDER = Color.FromArgb(102, 102, 102);


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
    public string TG_GUBUN = "T";
    decimal sumplanVal          = 0;
    decimal sumactVal           = 0;
    decimal old_chkVal          = 0;
    decimal old_chksumVal       = 0;
    int cnt                     = 0;

    int intRowNum = 0;
    Workbook workBook = null; // smjjang

    public string unit = "-";

    //private int ChartWidth = 410;     // 1280
    //private int ChartHeight = 240;

    private int ChartWidth = 340;     // 1280
    private int ChartHeight = 264;

    //public int ChartWidth = 330;    // 1024
    //public int ChartHeight = 220;

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }


    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }


    public string IYear
    {
        get
        {
            if (ViewState["YEAR"] == null)
            {
                ViewState["YEAR"] = GetRequest("YEAR", "");
            }

            return (string)ViewState["YEAR"];
        }
        set
        {
            ViewState["YEAR"] = value;
        }
    }

    public string IMonth
    {
        get
        {
            if (ViewState["MONTH"] == null)
            {
                ViewState["MONTH"] = GetRequest("MONTH", "");
            }

            return (string)ViewState["MONTH"];
        }
        set
        {
            ViewState["MONTH"] = value;
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


    private string searchColor(int score)
    {
        string rtvalue = null;

        if (score >= 100)
        {
            rtvalue = "fcols";
        }
        else if (score >= 90 && score < 100)
        {
            rtvalue = "fcola";

        }
        else if (score >= 80 && score < 90)
        {
            rtvalue = "fcolb";

        }
        else if (score >= 70 && score < 80)
        {
            rtvalue = "fcolc";

        }
        else if (score < 70)
        {
            rtvalue = "fcold";

        }

        return rtvalue;
    }

    private void DoCompute()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetJeonSa("A"
                                           , 10
                                           , ""
                                           , "",TG_GUBUN);

        //object objMaxYear =  dtNHIT.Compute("MAX(CR_YEAR)", "");
        //object objMaxMonth = dtNHIT.Compute("MAX(CR_MONTH)", string.Format(" CR_YEAR = '{0}' ", objMaxYear));

        object objMaxYear = CR_YEAR;
        object objMaxMonth = CR_MONTH;

        DataRow[] rows = dtNHIT.Select(string.Format(" CR_YEAR = '{0}' AND CR_MONTH = '{1}' ", objMaxYear, objMaxMonth), " SORT_ORDER ");

        if (rows.Length > 0)
        {
            lblYearMonth.Text = string.Format("{0}년 {1}월", objMaxYear, objMaxMonth);

            double rate1p = 0;
            double rate2p = 0;
            double rate3p = 0;


            lblMeDon.Text = String.Format("{0:##,##0}", DataTypeUtility.GetToInt32(rows[0][10]));
            lblMePer.Text = String.Format("{0:##,##0.00}", DataTypeUtility.GetToDouble(rows[0][11]) * 100) + "%";

            lblYoungDon.Text = String.Format("{0:##,##0}", DataTypeUtility.GetToInt32(rows[1][10]));
            lblYoungPer.Text = String.Format("{0:##,##0.00}", DataTypeUtility.GetToDouble(rows[1][11]) * 100) + "%";

            lblDangDon.Text = String.Format("{0:##,##0}", DataTypeUtility.GetToInt32(rows[2][10]));
            lblDangPer.Text = String.Format("{0:##,##0.00}", DataTypeUtility.GetToDouble(rows[2][11]) * 100) + "%";

            rate1p = DataTypeUtility.GetToDouble(rows[0][11]) * 100 * 0.5;
            rate2p = DataTypeUtility.GetToDouble(rows[1][11]) * 100 * 0.5;
            rate3p = DataTypeUtility.GetToDouble(rows[2][11]) * 100 * 0.5;

            //if (rate < rate1p)
            //{
            //    rate = rate1p;
            //}

            //if (rate < rate2p)
            //{
            //    rate = rate2p;
            //}

            //if (rate < rate3p)
            //{
            //    rate = rate3p;
            //}

            //if (rate > 100)
            //{
            //    rate1p = (rate1p == 0) ? rate1p : (rate1p / rate * 100);
            //    rate2p = (rate2p == 0) ? rate2p : (rate2p / rate * 100);
            //    rate3p = (rate3p == 0) ? rate3p : (rate3p / rate * 100);
            //}

            if (rate1p < 0)
            {
                rate1p = 0;
            }
            if (rate1p > 100)
            {
                rate1p = 100;
            }

            if (rate2p < 0)
            {
                rate2p = 0;
            }
            if (rate2p > 100)
            {
                rate2p = 100;
            }

            if (rate3p < 0)
            {
                rate3p = 0;
            }
            if (rate3p > 100)
            {
                rate3p = 100;
            }

            string wid1 = @"width:{0}%";
            string widthvalue1 = string.Format(wid1, rate1p);
            divMe.Attributes.Add("style", widthvalue1);

            string wid2 = @"width:{0}%";
            string widthvalue2 = string.Format(wid2, rate2p);
            divYoung.Attributes.Add("style", widthvalue2);

            string wid3 = @"width:{0}%";
            string widthvalue3 = string.Format(wid3, rate3p);
            divDang.Attributes.Add("style", widthvalue3);

            double avg = (rate1p + rate2p + rate2p / 3);
            string grade = "U";
            string colorCode = "#b8b8b8";

            if (avg >= 100)
            {
                grade = "S";
                colorCode = "#6fe1e0";
            }
            else if (avg >= 90 && avg < 100)
            {
                grade = "A";
                colorCode = "#6fe1e0";
            }
            else if (avg >= 80 && avg < 90)
            {
                grade = "B";
                colorCode = "#a8f620";
            }
            else if (avg >= 70 && avg < 80)
            {
                grade = "C";
                colorCode = "#f6c739";
            }
            else if (avg < 70)
            {
                grade = "D";
                colorCode = "#fb7716";
            }
            //else if(avg <= 50)
            //{
            //    grade = "U";
            //    colorCode = "#b8b8b8";
            //}


            lblG.Text = grade;
            lblG.ForeColor = Color.FromName(colorCode);

            //            .fcols{color: #8fc9fa;}
            //.fcola{color: #6fe1e0;}
            //.fcolb{color: #a8f620;}
            //.fcolc{color: #f6c739;}
            //.fcold{color: #fb7716;}
            //.fcolu{color: #b8b8b8;}
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            DoInitializing();

            TG_GUBUN = "T";

            CR_YEAR = ddlYear.Items[ddlYear.Items.Count - 1].Value;
            CR_MONTH = ddlMonth.Items[ddlMonth.Items.Count - 1].Value;

            ddlYear.SelectedValue = CR_YEAR;
            ddlMonth.SelectedValue = CR_MONTH;

            iBtnSearch_Click(null, null);
            base.SetMenuControl(true, false, true);

            DoCompute();
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
        DropDownListCommom.BindEstTerm(ddlEstTermRefID);
        IEstTermRefID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

        MicroBSC.Integration.BSC.Biz.Biz_My_Kpi bizMyKpi = new MicroBSC.Integration.BSC.Biz.Biz_My_Kpi();
        IYmd = bizMyKpi.SelectCurrentYYYYMM();

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

        ddlResolution.Items.Add(new ListItem("1024", "330*245"));
        ddlResolution.Items.Add(new ListItem("1280", "415*250"));
    }

    private void DoBinding_JeonSa()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetJeonSa(GRP_ONE_ID.A.ToString()
                                           , (int)GRP_TWO_ID.GTO_10
                                           , CR_YEAR
                                           , CR_MONTH,TG_GUBUN);


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
                                   , "",TG_GUBUN);

        DoDrawingJunsaChart2(dtNHIT, chartMM);
    }

    private void DoBinding_InPower()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetInPower(CR_YEAR);

        DoDrawingInPower(dtNHIT, chart2);
    }

    private void DoBinding_ETC()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT_B = bizNHIT.GetEtc(GRP_ONE_ID.B.ToString()
                                           , CR_YEAR
                                           , CR_MONTH, TG_GUBUN);

        DoDrawing3(dtNHIT_B, chart3);
        //DoDrawingEtcChart(dtNHIT_B, chart3,4);



        DataTable dtNHIT_C = bizNHIT.GetEtc(GRP_ONE_ID.C.ToString()
                                           , CR_YEAR
                                           , CR_MONTH, TG_GUBUN);

        DoDrawing3(dtNHIT_C, chart4);
        //DoDrawingEtcChart(dtNHIT_C, chart4,17);


        DataTable dtNHIT_D = bizNHIT.GetEtc(GRP_ONE_ID.D.ToString()
                                           , CR_YEAR
                                           , CR_MONTH, TG_GUBUN);


        DoDrawing3(dtNHIT_D, chart5);
        //DoDrawingEtcChart(dtNHIT_D, chart5,13);
    }


    #endregion

    private void DoSettingChartStyles(Chart chart, string format)
    {
        chart.Legends[0].BorderWidth = 0;
        chart.Legends[0].ShadowOffset = 0;
        Font font = new Font(new FontFamily("Dotum"), 8);
        chart.Legends[0].Font = font;
        chart.Legends[0].ForeColor = Color.FromArgb(127, 127, 127);


        string sChartArea2 = chart.Series[0].ChartArea;

        LabelStyle lblStyle = new LabelStyle();
        lblStyle.ForeColor = Color.FromArgb(127, 127, 127);
        lblStyle.Font = new Font("Tahoma", 7.5f, FontStyle.Regular);
        lblStyle.Format = format;

        //if (isSecondary)
        //{
        //    chart.ChartAreas[sChartArea2].AxisY2.LabelStyle = lblStyle;
        //    chart.ChartAreas[sChartArea2].AxisY2.LineColor = Color.FromArgb(127, 127, 127);
        //}

        chart.ChartAreas[sChartArea2].AxisY.LabelStyle = lblStyle;
        chart.ChartAreas[sChartArea2].AxisY.LineColor = Color.FromArgb(127, 127, 127);
        

        //chart.ChartAreas[sChartArea2].AxisY2.LabelStyle = lblStyle;

        lblStyle = new LabelStyle();
        lblStyle.ForeColor = Color.FromArgb(127, 127, 127);
        lblStyle.Font = new Font("Tahoma", 7.3f, FontStyle.Regular);

        chart.ChartAreas[sChartArea2].AxisX.LabelStyle = lblStyle;
        chart.ChartAreas[sChartArea2].AxisX.LineColor = Color.FromArgb(127, 127, 127);

        chart.ChartAreas[sChartArea2].AxisY.TitleFont = new Font("Tahoma", 7.5f, FontStyle.Regular);
        chart.ChartAreas[sChartArea2].AxisY.TitleForeColor = Color.FromArgb(127, 127, 127);

        chart.ChartAreas[sChartArea2].AxisY2.TitleFont = new Font("Tahoma", 7.5f, FontStyle.Regular);
        chart.ChartAreas[sChartArea2].AxisY2.TitleForeColor = Color.FromArgb(127, 127, 127);
        
    }

    private void DoDrawingJunsaChart1(DataTable dtChart, Chart chart)
    {

        int chartWidth = 310;
        int chartHeight = 258;

        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , chartWidth
                               , chartHeight
                               , BorderSkinStyle.Emboss
                               , CHART_BORDER_BLUE
                               , 1
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "목표", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_GREEN

                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1
                                             , 9
                                             , Color.FromArgb(64, 64, 64));

        Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_ORANGE
                                       
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1, 9, Color.FromArgb(64, 64, 64));



         //Enable data points labels
        //series1.IsValueShownAsLabel = true;
        //series2.IsValueShownAsLabel = true;

        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerSize = 2;
        //series1.MarkerColor = Color.Magenta;

        series1.Color = CHART_COLUMN_GREEN;
        //series1.Color = GetChartColor2(0);
        series1.BorderWidth = 0;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;
        series1.Label = "#VALY{N0}";


        // Enable data points markers
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerSize = 2;
        //series2.MarkerColor = Color.Magenta;

        series2.Color = CHART_COLUMN_ORANGE;
        //series2.Color = GetChartColor2(7);
        series2.BorderColor = CHART_COLUMN_BORDER;
        //series2.Color = CHART_COLUMN_GR;
        //series2.BorderColor = CHART_COLUMN_GR;
        series2.BorderWidth = 0;
        series2.ShadowOffset = 0;
        series2.Label = "#VALY{N0}";


        series1.YValueMembers = "TARGET_TS";
        series2.YValueMembers = "RESULT_TS";
        series1.XValueMember = "GRP_THREE_NAME";
        

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";

        string sChartArea2 = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        
        
        DoSettingChartStyles(chart,"#,##0");

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        }
        else
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;
        }

        chart.DataBind();
    }


    private void DoDrawingJunsaChart2(DataTable dtChart, Chart chart)
    {
        int chartWidth = 510;
        int chartHeight = 258;

        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , chartWidth
                               , chartHeight
                               , BorderSkinStyle.Emboss
                               , CHART_BORDER_BLUE
                               , 1
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "목표", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_GREEN, Color.FromArgb(180, 26, 59, 105),
                                             Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_ORANGE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        // Enable data points labels
        //series1.IsValueShownAsLabel = true;
        //series2.IsValueShownAsLabel = true;

        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerSize = 2;
        //series1.MarkerColor = Color.Magenta;

        series1.Color = CHART_COLUMN_GREEN;
        series1.BorderWidth = 0;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;
        //series1.BorderColor = GetChartColor2(0);
        series1.Label = "#VALY{N0}";


        // Enable data points markers
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerSize = 2;
        //series2.MarkerColor = Color.Magenta;

        series2.Color = CHART_COLUMN_ORANGE;
        series2.BorderWidth = 0;
        series2.BorderColor = CHART_COLUMN_BORDER;
        series2.ShadowOffset = 0;
        //series2.BorderColor = GetChartColor2(1);
        series2.Label = "#VALY{N0}";

        series1.YValueMembers = "TARGET_TS";
        series2.YValueMembers = "RESULT_TS";
        series1.XValueMember = "CR_MONTH_NAME";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";

        string sChartArea2 = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisX.IsMarginVisible = true;
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        DoSettingChartStyles(chart,"#,##0");

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        else
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;

        chart.DataBind();
    }

    private void DoDrawingInPower(DataTable dtChart, Chart chart)
    {

        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , ChartWidth
                               , ChartHeight
                               , BorderSkinStyle.Emboss
                               , CHART_BORDER_GRAY
                               , 1
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        string target = "-";

        if(dtChart.Rows.Count > 0)
            target = DataTypeUtility.GetValue(dtChart.Rows[0]["TARGET_FULL_RATE"]);

        
        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", string.Format("목표 가득율 ({0}%)", target), null, SeriesChartType.Line, 1
                                             , CHART_LINE_BLUE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "가득율", null, SeriesChartType.Line, 1
                                            , CHART_LINE_ORANGE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 8, Color.FromArgb(64, 64, 64));//Font="Trebuchet MS, 4pt, style=Bold">
        
        

        // Enable data points labels
        //series1.IsValueShownAsLabel = true;
        //series2.IsValueShownAsLabel = true;

        series1.BorderWidth = 2;
        series1.ShadowOffset = 0;
        //series1.BorderColor = GetChartColor2(0);
        series1.Label = "#VALY{P0}";

        // Set spline line tension 
        //series2["LineTension"] = "0.1";

        // Enable data points markers
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerSize = 5;
        //series2.MarkerColor = Color.Magenta;

        series2.BorderWidth = 2;
        series2.ShadowOffset = 0;
        series2.Label = "#VALY{P0}";
        //series2.BorderColor = GetChartColor2(1);

        series1.YValueMembers = "TARGET_FULL_RATE_001";
        series2.YValueMembers = "RESULT_FULL_RATE_001";
        series1.XValueMember = "CR_MONTH_NAME";


        series1.ToolTip = "#VALY{P0}";
        series2.ToolTip = "#VALY{P0}";


        string sChartArea2 = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "P0";
        chart.ChartAreas[sChartArea2].AxisY.IsStartedFromZero = false;
        chart.ChartAreas[sChartArea2].AxisX.IsMarginVisible = true;
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        DoSettingChartStyles(chart,"#%");

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        else
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;

        chart.DataBind();
    }

    private void DoDrawingEtcChart(DataTable dtChart, Chart chart, int colorCode)
    {
        string url = string.Empty;

        string xValue = DataTypeUtility.GetValue(dtChart.Rows[0]["GRP_TWO_NAME"]);


        // 당월그래프
        MSCharts.DundasChartBase(chart
                                , ChartImageType.Jpeg
                                , ChartWidth
                                , ChartHeight
                                , BorderSkinStyle.Emboss
                                , CHART_BORDER_GRAY
                                , 1
                                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                , Color.FromArgb(255,255,255)
                                , Color.FromArgb(0x20, 0x80, 0xD0)
                                , ChartDashStyle.Solid
                                , -1
                                , ChartHatchStyle.None
                                , MsGradientType.TopBottom
                                , MsAntiAliasing.None);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart
                                             , "ME1"
                                             , "Default"
                                             , "매출(목표)"
                                             , null
                                             , SeriesChartType.Column
                                             , 1
                                             , CHART_COLUMN_GREEN
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1
                                             , 9
                                             , Color.FromArgb(64, 64, 64));

        Series series2 = MSCharts.CreateSeries(chart, 
                                              "ME2", 
                                              "Default", 
                                              "매출(실적)", 
                                              null, 
                                              SeriesChartType.Column, 
                                              1
                                             , CHART_COLUMN_ORANGE, 
                                             Color.FromArgb(180, 26, 59, 105), 
                                             Color.FromArgb(64, 0, 0, 0), 1, 9,
                                             Color.FromArgb(64, 64, 64));

        //Series series3 = MSCharts.CreateSeries(chart, "YG1", "Default", "영업(목표)", null, SeriesChartType.Line, 1, GetChartColor2(4), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = MSCharts.CreateSeries(chart, "YG2", "Default", "영업(실적)", null
        //                                       , SeriesChartType.Line
        //                                       , 2
        //                                       , CHART_LINE_BLUE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));



        Series series4 = MSCharts.CreateSeries(chart, "serPlan", "Default", "영업이익", null
                                             , SeriesChartType.Line
                                             , 1
                                             , CHART_LINE_BLUE
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1, 9, Color.FromArgb(64, 64, 64));


        //series1.IsValueShownAsLabel = true;
        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerColor = Color.Magenta;
        //series1.MarkerSize = 3;
        //series1.BorderWidth = 1;


        series1.Label = "#VALY{N0}";
        series1.Color = CHART_COLUMN_GREEN;
        series1.BorderWidth = 0;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;

        
        //series2.IsValueShownAsLabel = true;
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerColor = Color.Magenta;
        //series2.MarkerSize = 3;
        series2.Label = "#VALY{N0}";
        series2.Color = CHART_COLUMN_ORANGE;
        series2.BorderWidth = 0;
        series2.BorderColor = CHART_COLUMN_BORDER;
        series2.ShadowOffset = 0;

        //series3.IsValueShownAsLabel = true;
        //series3.MarkerStyle = MarkerStyle.Circle;
        //series3.MarkerColor = Color.Magenta;
        //series3.MarkerSize = 3;
        //series3.Label = "#VALY{N0}";

        //series4.YAxisType = AxisType.Secondary;
        series4.ShadowOffset = 0;
        series4.Color = CHART_COLUMN_RED;
        series4.BorderColor = CHART_COLUMN_RED;

        
        //series4.IsValueShownAsLabel = true;
        //series4.MarkerStyle = MarkerStyle.Circle;
        //series4.MarkerColor = Color.Magenta;
        //series4.MarkerSize = 3;
        series4.Label = "#VALY{N0}";


        series1.YValueMembers = "ME_TARGET_TS";
        series2.YValueMembers = "ME_RESULT_TS";
        //series3.YValueMembers = "YG_TARGET_TS";
        series4.YValueMembers = "YG_RESULT_TS";
        series1.XValueMember = "GRP_TWO_NAME";

        

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        //series3.ToolTip = "#VALY{N0}";
        series4.ToolTip = "#VALY{N0}";

        string sChartArea2 = chart.Series[series2.Name].ChartArea;
        //chart.ChartAreas[sChartArea2].AxisX.IsMarginVisible = true;
        //chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

      ///  chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
      ///  chart.ChartAreas[sChartArea2].AxisY.Title = "매출";
       

       // chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
       // chart.ChartAreas[sChartArea2].AxisY2.Title = "영업";

      ///  LabelStyle lblStyle = new LabelStyle();
      ///  lblStyle.ForeColor = Color.FromArgb(127, 127, 127);
      ///  lblStyle.Font = new Font("Tahoma", 7.5f, FontStyle.Regular);
      ///  lblStyle.Format = "#,##0";

       // chart.ChartAreas[sChartArea2].AxisY2.LabelStyle = lblStyle;
       // chart.ChartAreas[sChartArea2].AxisY2.LineColor = Color.FromArgb(127, 127, 127);
        
        DoSettingChartStyles(chart,"#,##0");

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        }
        else
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;
        }

        chart.DataBind();
    }


    private void DoDrawing3(DataTable dtChart, Chart chart)
    {


        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , ChartWidth
                               , ChartHeight
                               , BorderSkinStyle.Emboss
                               , CHART_BORDER_GRAY
                               , 1
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart
                                             , "ME1"
                                             , "Default"
                                             , "매출(목표)"
                                             , null
                                             , SeriesChartType.Column
                                             , 1
                                             , CHART_COLUMN_GREEN
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1
                                             , 9
                                             , Color.FromArgb(64, 64, 64));

        Series series2 = MSCharts.CreateSeries(chart, "ME2", "Default", "매출(실적)", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_ORANGE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


        Series series4 = MSCharts.CreateSeries(chart, "serPlan", "Default", "영업이익", null
                                             , SeriesChartType.Line
                                             , 1
                                             , CHART_LINE_BLUE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


        //series1.IsValueShownAsLabel = true;
        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerColor = Color.Magenta;
        //series1.MarkerSize = 3;
        series1.Label = "#VALY{N0}";
        series1.Color = CHART_COLUMN_GREEN;
        series1.BorderWidth = 0;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;
        //series2.IsValueShownAsLabel = true;
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerColor = Color.Magenta;
        //series2.MarkerSize = 3;
        series2.Label = "#VALY{N0}";
        series2.Color = CHART_COLUMN_ORANGE;
        series2.BorderWidth = 0;
        series2.BorderColor = CHART_COLUMN_BORDER;
        series2.ShadowOffset = 0;
        //series3.IsValueShownAsLabel = true;
        //series3.MarkerStyle = MarkerStyle.Circle;
        //series3.MarkerColor = Color.Magenta;
        //series3.MarkerSize = 3;
        //series3.Label = "#VALY{N0}";

        //series4.YAxisType = AxisType.Secondary;
        series4.ShadowOffset = 0;
        series4.Color = CHART_COLUMN_RED;
        series4.BorderColor = CHART_COLUMN_RED;

        //series4.IsValueShownAsLabel = true;
        //series4.MarkerStyle = MarkerStyle.Circle;
        //series4.MarkerColor = Color.Magenta;
        //series4.MarkerSize = 3;
        series4.Label = "#VALY{N0}";


        series1.YValueMembers = "ME_TARGET_TS";
        series2.YValueMembers = "ME_RESULT_TS";
        //series3.YValueMembers = "YG_TARGET_TS";
        series4.YValueMembers = "YG_RESULT_TS";
        series1.XValueMember = "GRP_TWO_NAME";



        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        //series3.ToolTip = "#VALY{N0}";
        series4.ToolTip = "#VALY{N0}";

        ////string sChartArea2 = chart.Series[series2.Name].ChartArea;
        //chart.ChartAreas[sChartArea2].AxisX.IsMarginVisible = true;
        //chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        ////chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        ////chart.ChartAreas[sChartArea2].AxisY.Title = "매출";

        ////chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        ////chart.ChartAreas[sChartArea2].AxisY2.Title = "영업";

        ////LabelStyle lblStyle = new LabelStyle();
        ////lblStyle.ForeColor = Color.FromArgb(127, 127, 127);
        ////lblStyle.Font = new Font("Tahoma", 7.5f, FontStyle.Regular);
        ////lblStyle.Format = "#,##0";

        ////chart.ChartAreas[sChartArea2].AxisY2.LabelStyle = lblStyle;
        ////chart.ChartAreas[sChartArea2].AxisY2.LineColor = Color.FromArgb(127, 127, 127);


        string sChartArea2 = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        DoSettingChartStyles(chart, "#,##0");

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        }
        else
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;
        }

        chart.DataBind();
    }

    private void DoDrawing2(DataTable dtChart, Chart chart)
    {


        // 당월그래프
        MSCharts.DundasChartBase(chart
                               , ChartImageType.Jpeg
                               , ChartWidth
                               , ChartHeight
                               , BorderSkinStyle.Emboss
                               , CHART_BORDER_GRAY
                               , 1
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0xFF, 0xFF, 0xFE)
                               , Color.FromArgb(0x20, 0x80, 0xD0)
                               , ChartDashStyle.Solid
                               , -1
                               , ChartHatchStyle.None
                               , MsGradientType.Center
                               , MsAntiAliasing.Graphics);

        chart.DataSource = dtChart;

        Series series1 = MSCharts.CreateSeries(chart
                                             , "ME1"
                                             , "Default"
                                             , "매출(목표)"
                                             , null
                                             , SeriesChartType.Column
                                             , 1
                                             , CHART_COLUMN_GREEN
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1
                                             , 9
                                             , Color.FromArgb(64, 64, 64));

        Series series2 = MSCharts.CreateSeries(chart, "ME2", "Default", "매출(실적)", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_ORANGE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


        Series series4 = MSCharts.CreateSeries(chart, "serPlan", "Default", "당기순이익", null
                                             , SeriesChartType.Line
                                             , 1
                                             , CHART_LINE_BLUE, Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


        //series1.IsValueShownAsLabel = true;
        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerColor = Color.Magenta;
        //series1.MarkerSize = 3;
        series1.Label = "#VALY{N0}";
        series1.Color = CHART_COLUMN_GREEN;
        series1.BorderWidth = 0;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;
        //series2.IsValueShownAsLabel = true;
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerColor = Color.Magenta;
        //series2.MarkerSize = 3;
        series2.Label = "#VALY{N0}";
        series2.Color = CHART_COLUMN_ORANGE;
        series2.BorderWidth = 0;
        series2.BorderColor = CHART_COLUMN_BORDER;
        series2.ShadowOffset = 0;
        //series3.IsValueShownAsLabel = true;
        //series3.MarkerStyle = MarkerStyle.Circle;
        //series3.MarkerColor = Color.Magenta;
        //series3.MarkerSize = 3;
        //series3.Label = "#VALY{N0}";

        //series4.YAxisType = AxisType.Secondary;
        series4.ShadowOffset = 0;
        series4.Color = CHART_COLUMN_RED;
        series4.BorderColor = CHART_COLUMN_RED;

        //series4.IsValueShownAsLabel = true;
        //series4.MarkerStyle = MarkerStyle.Circle;
        //series4.MarkerColor = Color.Magenta;
        //series4.MarkerSize = 3;
        series4.Label = "#VALY{N0}";


        series1.YValueMembers = "ME_TARGET_TS";
        series2.YValueMembers = "ME_RESULT_TS";
        //series3.YValueMembers = "YG_TARGET_TS";
        //series4.YValueMembers = "YG_RESULT_TS";
        series4.YValueMembers = "DN_RESULT_TS";
        series1.XValueMember = "GRP_TWO_NAME";



        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        //series3.ToolTip = "#VALY{N0}";
        series4.ToolTip = "#VALY{N0}";

        ////string sChartArea2 = chart.Series[series2.Name].ChartArea;
        //chart.ChartAreas[sChartArea2].AxisX.IsMarginVisible = true;
        //chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        ////chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        ////chart.ChartAreas[sChartArea2].AxisY.Title = "매출";

        ////chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        ////chart.ChartAreas[sChartArea2].AxisY2.Title = "영업";

        ////LabelStyle lblStyle = new LabelStyle();
        ////lblStyle.ForeColor = Color.FromArgb(127, 127, 127);
        ////lblStyle.Font = new Font("Tahoma", 7.5f, FontStyle.Regular);
        ////lblStyle.Format = "#,##0";

        ////chart.ChartAreas[sChartArea2].AxisY2.LabelStyle = lblStyle;
        ////chart.ChartAreas[sChartArea2].AxisY2.LineColor = Color.FromArgb(127, 127, 127);


        string sChartArea2 = chart.Series[series2.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;

        DoSettingChartStyles(chart, "#,##0");

        // Show as 3D
        if (rdoChartType.SelectedIndex == 0)
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        }
        else
        {
            chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;
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
            , BorderSkinStyle.Emboss, CHART_BORDER_BLUE, 2
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


        //ChartWidth = DataTypeUtility.GetToInt32(hdfChartWidth.Value);
        //ChartHeight = DataTypeUtility.GetToInt32(hdfChartHeight.Value);

        //if (ddlResolution.SelectedIndex == 0)
        //{
        //    ChartWidth = 330;    // 1024 768
        //    ChartHeight = 245;
        //}
        //else
        //{
        //    ChartWidth = 415;     // 1280 800
        //    ChartHeight = 250;
        //}

        //if (!txtWidth.Text.Equals(""))
        //{
        //    ChartWidth = DataTypeUtility.GetToInt32(txtWidth.Text);
        //    ChartHeight = DataTypeUtility.GetToInt32(txtHeight.Text);
        //}

        DoBinding_JeonSa();
        DoBinding_InPower();
        DoBinding_ETC();

        DoCompute();

    }

    
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        //this.SetResultGrid();
        //this.SetInitiativeInfo();
        //this.SetCommunicationGrid();
    }

}
