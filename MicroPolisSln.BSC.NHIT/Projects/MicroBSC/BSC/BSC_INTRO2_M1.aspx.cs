using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using MicroCharts;
using MicroBSC.Estimation.Dac;
using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Integration.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;
//using Dundas.Gauges.WebControl;
//using Dundas.Charting.WebControl;

using System.Web.UI.DataVisualization.Charting;


public partial class BSC_INTRO2_M1 : AppPageBase
{

    protected Color CHART_BORDER_BLUE = Color.FromArgb(87, 123, 201);
    protected Color CHART_BORDER_GRAY = Color.FromArgb(194, 194, 194);

    protected Color CHART_COLUMN_GREEN = Color.FromArgb(129, 211, 89);
    protected Color CHART_COLUMN_ORANGE = Color.FromArgb(255, 173, 65);
    protected Color CHART_COLUMN_BORDER = Color.FromArgb(102, 102, 102);

    protected Color CHART_LINE_BLUE = Color.FromArgb(58, 127, 205);
    protected Color CHART_LINE_ORANGE = Color.FromArgb(242, 129, 46);
    //protected Color CHART_COLUMN_BORDER = Color.FromArgb(102, 102, 102);


    public double dTotalPoint = 0;
    private int ChartWidth = 600;     // 1280
    private int ChartHeight = 400;


    #region --> Property

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

    public int IEstDeptID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public int IDeptID
    {
        get
        {
            if (ViewState["COM_DEPT_REF_ID"] == null)
            {
                ViewState["COM_DEPT_REF_ID"] = GetRequestByInt("COM_DEPT_REF_ID", 0);
            }

            return (int)ViewState["COM_DEPT_REF_ID"];
        }
        set
        {
            ViewState["COM_DEPT_REF_ID"] = value;
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

    public string ISumType
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "");
            }

            return (string)ViewState["SUM_TYPE"];
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }

    public string IBonID
    {
        get
        {
            if (ViewState["BONBU_ID"] == null)
            {
                ViewState["BONBU_ID"] = GetRequest("BONBU_ID", "");
            }

            return (string)ViewState["BONBU_ID"];
        }
        set
        {
            ViewState["BONBU_ID"] = value;
        }
    }

    public string IBonNAME
    {
        get
        {
            if (ViewState["BONBU_NAME"] == null)
            {
                ViewState["BONBU_NAME"] = GetRequest("BONBU_NAME", "");
            }

            return (string)ViewState["BONBU_NAME"];
        }
        set
        {
            ViewState["BONBU_NAME"] = value;
        }
    }


    public string ITeamID
    {
        get
        {
            if (ViewState["TEAM_ID"] == null)
            {
                ViewState["TEAM_ID"] = GetRequest("TEAM_ID", "");
            }

            return (string)ViewState["TEAM_ID"];
        }
        set
        {
            ViewState["TEAM_ID"] = value;
        }
    }

    public string ITeamNAME
    {
        get
        {
            if (ViewState["TEAM_NAME"] == null)
            {
                ViewState["TEAM_NAME"] = GetRequest("TEAM_NAME", "");
            }

            return (string)ViewState["TEAM_NAME"];
        }
        set
        {
            ViewState["TEAM_NAME"] = value;
        }
    }

    public string KPI_URL
    {
        get
        {
            if (ViewState["KPI_URL"] == null)
            {
                ViewState["KPI_URL"] = "";
            }

            return (string)ViewState["KPI_URL"];
        }
        set
        {
            ViewState["KPI_URL"] = value;
        }
    }

    #endregion

    #region --> Page_Load()

    protected void Page_Load(object sender, EventArgs e)
    {
        //좌측메뉴설정

        MicroBSC.Integration.BSC.Biz.Biz_My_Kpi bizMyKpi = new MicroBSC.Integration.BSC.Biz.Biz_My_Kpi();

        if (!IsPostBack)
        {

            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));


            IEstTermRefID = WebUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            //IYmd = WebUtility.GetIntByValueDropDownList(ddlMonthInfo);

            IYmd = bizMyKpi.SelectCurrentYYYYMM();
            ddlMonthInfo.SelectedValue = IYmd;

            DoBinding_Chart();

            SetGrid1();
            SetGrid2();
            SetGrid3();
            SetGrid4();


        }

        IEstTermRefID = WebUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        IYmd = IYmd = WebUtility.GetByValueDropDownList(ddlMonthInfo);
    }


    #endregion

    #region --> Event


    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void UltraWebGrid2_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void UltraWebGrid3_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void UltraWebGrid4_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void UltraWebGrid5_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string ESTTERM_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        string YMD = DataTypeUtility.GetValue(e.Row.Cells.FromKey("YMD").Value);
        string EST_DEPT_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value);
        string DEPT_NAME = DataTypeUtility.GetValue(e.Row.Cells.FromKey("DEPT_NAME").Value);
        string UP_EST_DEPT_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("UP_EST_DEPT_ID").Value);
        string UP_DEPT_NAME = DataTypeUtility.GetValue(e.Row.Cells.FromKey("UP_DEPT_NAME").Value);

        string url = "<a href=\"javascript:setOpenerLocation('../BSC/BSC0404S1.ASPX?{1}{2}{3}');\"  style=\"color:Navy;\">{0}</a>";
        string link = string.Format(url, DEPT_NAME, "&ESTTERM_REF_ID=" + ESTTERM_REF_ID, "&YMD=" + YMD, "&EST_DEPT_REF_ID=" + EST_DEPT_REF_ID);
        e.Row.Cells.FromKey("DEPT_NAME").Text = link;

        string url1 = "<a href=\"javascript:setOpenerLocation('../BSC/BSC0404S1.ASPX?{1}{2}{3}');\"  style=\"color:Navy;\">{0}</a>";
        string link1 = string.Format(url1, UP_DEPT_NAME, "&ESTTERM_REF_ID=" + ESTTERM_REF_ID, "&YMD=" + YMD, "&EST_DEPT_REF_ID=" + UP_EST_DEPT_ID);
        e.Row.Cells.FromKey("UP_DEPT_NAME").Text = link1;
    }
    protected void UltraWebGrid2_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        string ESTTERM_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        string YMD = DataTypeUtility.GetValue(e.Row.Cells.FromKey("YMD").Value);
        string EST_DEPT_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value);
        string DEPT_NAME = DataTypeUtility.GetValue(e.Row.Cells.FromKey("DEPT_NAME").Value);

        string url = "<a href=\"javascript:setOpenerLocation('../BSC/BSC0404S1.ASPX?{1}{2}{3}');\"  style=\"color:Navy;\">{0}</a>";
        string link = string.Format(url, DEPT_NAME, "&ESTTERM_REF_ID=" + ESTTERM_REF_ID, "&YMD=" + YMD, "&EST_DEPT_REF_ID=" + EST_DEPT_REF_ID);
        e.Row.Cells.FromKey("DEPT_NAME").Text = link;
    }
    protected void UltraWebGrid3_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        string ESTTERM_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        string YMD = DataTypeUtility.GetValue(e.Row.Cells.FromKey("YMD").Value);
        string EST_DEPT_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value);
        string DEPT_NAME = DataTypeUtility.GetValue(e.Row.Cells.FromKey("DEPT_NAME").Value);

        string url = "<a href=\"javascript:setOpenerLocation('../BSC/BSC0404S1.ASPX?{1}{2}{3}');\"  style=\"color:Navy;\">{0}</a>";
        string link = string.Format(url, DEPT_NAME, "&ESTTERM_REF_ID=" + ESTTERM_REF_ID, "&YMD=" + YMD, "&EST_DEPT_REF_ID=" + EST_DEPT_REF_ID);
        e.Row.Cells.FromKey("DEPT_NAME").Text = link;
    }
    protected void UltraWebGrid4_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }
    protected void UltraWebGrid5_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string EMP_NAME = DataTypeUtility.GetValue(e.Row.Cells.FromKey("EMP_NAME").Value);
        string EMP_REF_ID = DataTypeUtility.GetValue(e.Row.Cells.FromKey("EMP_REF_ID").Value);

        string url = "<a href=\"javascript:setOpenerLocation('../BSC/BSC1004S1.ASPX?{1}');\"  style=\"color:Navy;\">{0}</a>";
        string link = string.Format(url, EMP_NAME, "&EMP_REF_ID=" + EMP_REF_ID);
        e.Row.Cells.FromKey("EMP_NAME").Text = link;

    }
    protected void UltraWebGrid4_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {

        if (e.SelectedRows.Count > 0)
        {
            string ESTTERM_REF_ID = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("ESTTERM_REF_ID").Value);
            string YMD = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("YMD").Value);
            string EST_DEPT_REF_ID = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("EST_DEPT_REF_ID").Value);
            string bonbu_name = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("DEPT_NAME").Value).ToString();
            SetGrid5(DataTypeUtility.GetToInt32(ESTTERM_REF_ID), YMD, EST_DEPT_REF_ID,bonbu_name);
        }

        //DoBinding_Chart();
    }



    #endregion

    #region --> Function

    private void SetGrid1()
    {
        UltraWebGrid1.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizObj = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();

        DataTable dtObj = bizObj.GetOrgRank(IEstTermRefID, IYmd, 0);

        if (dtObj.Rows.Count > 0)
        {

            UltraWebGrid1.DataSource = dtObj;
            UltraWebGrid1.DataBind();

        }
    }


    private void SetGrid2()
    {
        UltraWebGrid2.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizObj = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();

        DataTable dtObj = bizObj.GetOrgRank(IEstTermRefID, IYmd, 5);

        if (dtObj.Rows.Count > 0)
        {

            UltraWebGrid2.DataSource = dtObj;
            UltraWebGrid2.DataBind();

        }
    }

    private void SetGrid3()
    {
        UltraWebGrid3.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizObj = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();

        DataTable dtObj = bizObj.GetOrgRankDesc(IEstTermRefID, IYmd, 5);

        if (dtObj.Rows.Count > 0)
        {

            UltraWebGrid3.DataSource = dtObj;
            UltraWebGrid3.DataBind();

        }
    }

    private void SetGrid4()
    {
        UltraWebGrid4.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizObj = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();

        DataTable dtObj = bizObj.GetOrgRankBonbu(IEstTermRefID, IYmd, "4", "TS");

        if (dtObj.Rows.Count > 0)
        {

            UltraWebGrid4.DataSource = dtObj;
            UltraWebGrid4.DataBind();

            UltraWebGrid4.Rows[0].Activate();
            UltraWebGrid4.Rows[0].Selected = true;

            string ESTTERM_REF_ID = DataTypeUtility.GetValue(UltraWebGrid4.Rows[0].Cells.FromKey("ESTTERM_REF_ID").Value);
            string YMD = DataTypeUtility.GetValue(UltraWebGrid4.Rows[0].Cells.FromKey("YMD").Value);
            string EST_DEPT_REF_ID = DataTypeUtility.GetValue(UltraWebGrid4.Rows[0].Cells.FromKey("EST_DEPT_REF_ID").Value);
            string bonbu_name = DataTypeUtility.GetValue(UltraWebGrid4.Rows[0].Cells.FromKey("DEPT_NAME").Value).ToString();
            SetGrid5(DataTypeUtility.GetToInt32(ESTTERM_REF_ID), YMD, EST_DEPT_REF_ID, bonbu_name);



        }
    }

    private void SetGrid5(int estterm_ref_id, string ymd, string bonbu_id, string bonbu_name)
    {
        UltraWebGrid5.Clear();

        lblBonbuName.Text = bonbu_name;
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizObj = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();

        DataTable dtObj = bizObj.GetOrgRankPri(estterm_ref_id, ymd, bonbu_id);

        if (dtObj.Rows.Count > 0)
        {

            UltraWebGrid5.DataSource = dtObj;
            UltraWebGrid5.DataBind();

        }
    }

    private void DoDrawingChart1(DataTable dtChart, Chart chart)
    {


        int chartWidth = 300;
        int chartHeight = 270;

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

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "등급", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_GREEN
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1
                                             , 9
                                             , Color.FromArgb(64, 64, 64));


        //Enable data points labels
        //series1.IsValueShownAsLabel = true;
        //series2.IsValueShownAsLabel = true;

        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerSize = 2;
        //series1.MarkerColor = Color.Magenta;

        series1.BorderWidth = 1;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;

        series1.YValueMembers = "GRADE_COUNT";
        //series2.YValueMembers = "GRADE_COUNT";
        series1.XValueMember = "TS_GRADE";


        

        series1.ToolTip = "#VALY{N0}";
        //series2.ToolTip = "#VALY{N0}";

        string sChartArea2 = chart.Series[series1.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;
        


        DoSettingChartStyles(chart, "#,##0");



        //// Show as 3D
        //if (rdoChartType.SelectedIndex == 0)
        //{
        chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        //}
        //else
        //{
        //    chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;
        //}

        // chart.DataBind();

    }

    private void DoDrawingChart2(DataTable dtChart, Chart chart)
    {


        int chartWidth = 300;
        int chartHeight = 270;

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

        Series series1 = MSCharts.CreateSeries(chart, "serPlan", "Default", "등급", null, SeriesChartType.Column, 1
                                             , CHART_COLUMN_ORANGE
                                             , Color.FromArgb(180, 26, 59, 105)
                                             , Color.FromArgb(64, 0, 0, 0)
                                             , 1
                                             , 9
                                             , Color.FromArgb(64, 64, 64));

        //Series series2 = MSCharts.CreateSeries(chart, "serActl", "Default", "실적", null, SeriesChartType.Column, 1
        //                                     , CHART_COLUMN_ORANGE
        //                                     , Color.FromArgb(180, 26, 59, 105)
        //                                     , Color.FromArgb(64, 0, 0, 0)
        //                                     , 1, 9, Color.FromArgb(64, 64, 64));


        //Enable data points labels
        //series1.IsValueShownAsLabel = true;
        //series2.IsValueShownAsLabel = true;

        //series1.MarkerStyle = MarkerStyle.Circle;
        //series1.MarkerSize = 2;
        //series1.MarkerColor = Color.Magenta;

        series1.BorderWidth = 1;
        series1.BorderColor = CHART_COLUMN_BORDER;
        series1.ShadowOffset = 0;

        //series1.Label = "#VALY{N0}";


        // Enable data points markers
        //series2.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerSize = 2;
        //series2.MarkerColor = Color.Magenta;

        //series2.BorderWidth = 1;
        //series2.BorderColor = CHART_COLUMN_BORDER;
        //series2.ShadowOffset = 0;
        //series2.Label = "#VALY{N0}";


        series1.YValueMembers = "GRADE_COUNT";
        //series2.YValueMembers = "GRADE_COUNT";
        series1.XValueMember = "TS_GRADE";


        series1.ToolTip = "#VALY{N0}";
        //series2.ToolTip = "#VALY{N0}";

        string sChartArea2 = chart.Series[series1.Name].ChartArea;
        chart.ChartAreas[sChartArea2].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.LabelStyle.Format = "N0";
        chart.ChartAreas[sChartArea2].AxisY2.Enabled = AxisEnabled.False;



        DoSettingChartStyles(chart, "#,##0");



        //// Show as 3D
        //if (rdoChartType.SelectedIndex == 0)
        //{
        chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = false;
        //}
        //else
        //{
        //    chart.ChartAreas[sChartArea2].Area3DStyle.Enable3D = true;
        //}

        // chart.DataBind();
    }

    private void DoBinding_Chart()
    {
        DataTable dtTemp = new DataTable();

        dtTemp.Columns.Add("TS_GRADE");
        dtTemp.Columns.Add("GRADE_COUNT", typeof(double));

        DataRow row = dtTemp.NewRow();
        row["TS_GRADE"] = "D";
        row["GRADE_COUNT"] = 0;
        dtTemp.Rows.Add(row);

        row = dtTemp.NewRow();
        row["TS_GRADE"] = "C";
        row["GRADE_COUNT"] = 0;
        dtTemp.Rows.Add(row);


        row = dtTemp.NewRow();
        row["TS_GRADE"] = "B";
        row["GRADE_COUNT"] = 0;
        dtTemp.Rows.Add(row);

        row = dtTemp.NewRow();
        row["TS_GRADE"] = "A";
        row["GRADE_COUNT"] = 0;
        dtTemp.Rows.Add(row);

        row = dtTemp.NewRow();
        row["TS_GRADE"] = "S";
        row["GRADE_COUNT"] = 0;
        dtTemp.Rows.Add(row);

        DataTable dtOrg = dtTemp.Copy();
        DataTable dtPri = dtTemp.Copy();

        Biz_Bsc_Intro_Score bizNHIT = new Biz_Bsc_Intro_Score();
        DataTable dtNHIT = bizNHIT.GetOrgRankBunpo(IEstTermRefID, IYmd, "7", "TS");

        if (dtNHIT.Rows.Count > 0)
        {
            for (int i = 0; i < dtOrg.Rows.Count; i++)
            {
                string ts_grade = DataTypeUtility.GetValue(dtOrg.Rows[i]["TS_GRADE"]);

                DataRow[] rows = dtNHIT.Select(string.Format(" TS_GRADE = '{0}' ", ts_grade));

                if (rows.Length > 0)
                {
                    dtOrg.Rows[i]["GRADE_COUNT"] = rows[0]["GRADE_COUNT"];
                }
            }        
            DoDrawingChart1(dtOrg, chart1);

        }









        dtNHIT = bizNHIT.GetPriRankBunpo(IEstTermRefID, IYmd);

        if (dtNHIT.Rows.Count > 0)
        {
            for (int i = 0; i < dtPri.Rows.Count; i++)
            {
                string ts_grade = DataTypeUtility.GetValue(dtPri.Rows[i]["TS_GRADE"]);

                DataRow[] rows = dtNHIT.Select(string.Format(" TS_GRADE = '{0}' ", ts_grade));

                if (rows.Length > 0)
                {
                    dtPri.Rows[i]["GRADE_COUNT"] = rows[0]["GRADE_COUNT"];
                }
            }        
            DoDrawingChart2(dtPri, chart2);

        }

    }

    private void DoSettingChartStyles(Chart chart, string format)
    {
        chart.Legends[0].BorderWidth = 0;
        chart.Legends[0].ShadowOffset = 0;
        Font font = new Font(new FontFamily("Dotum"), 8);
        chart.Legends[0].Font = font;
        chart.Legends[0].ForeColor = Color.FromArgb(127, 127, 127);
        chart.Legends.Clear();


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
        lblStyle.Font = new Font("Tahoma", 7.5f, FontStyle.Regular);

        chart.ChartAreas[sChartArea2].AxisX.LabelStyle = lblStyle;
        chart.ChartAreas[sChartArea2].AxisX.LineColor = Color.FromArgb(127, 127, 127);

        chart.ChartAreas[sChartArea2].AxisY.TitleFont = new Font("Tahoma", 7.5f, FontStyle.Regular);
        chart.ChartAreas[sChartArea2].AxisY.TitleForeColor = Color.FromArgb(127, 127, 127);

        chart.ChartAreas[sChartArea2].AxisY2.TitleFont = new Font("Tahoma", 7.5f, FontStyle.Regular);
        chart.ChartAreas[sChartArea2].AxisY2.TitleForeColor = Color.FromArgb(127, 127, 127);

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


    #endregion

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBinding_Chart();

        SetGrid1();
        SetGrid2();
        SetGrid3();
        SetGrid4();
    }

    protected void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBinding_Chart();

        SetGrid1();
        SetGrid2();
        SetGrid3();
        SetGrid4();
    }
    
}
