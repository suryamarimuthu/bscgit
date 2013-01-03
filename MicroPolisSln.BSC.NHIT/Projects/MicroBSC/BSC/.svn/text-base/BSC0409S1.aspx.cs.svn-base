using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class BSC_BSC0409S1 : AppPageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //좌측메뉴설정
        base.SetMenuControl(true, false, true);
        if (!Page.IsPostBack)
        {
            DoInitControl();
            if (ddlDiCode.Items.Count > 1)
            {
                ddlDiCode.SelectedIndex = 1;
                DoBinding();
            }
        }
        ltrScript.Text = "";
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    private void DoBinding()
    {
        try
        {
            ugrdResult.Clear();
            Dundas.Charting.WebControl.Chart objChart = this.chat1;

            Dundas.Charting.WebControl.SeriesChartType scType;
            scType = FindChartType();

            //objChart.ChartAreas.Clear();

            MicroBSC.Estimation.Biz.Biz_TermInfos objTerms = new MicroBSC.Estimation.Biz.Biz_TermInfos(PageUtility.GetIntByValueDropDownList(ddlEstTerm));
            string sYMD = objTerms.Est_StartDate.Year.ToString() + PageUtility.GetByValueDropDownList(ddlMonth);
            string ymd1 = string.Empty;
            string ymd3 = string.Empty;
            if (sYMD.Substring(4, 2) == "01")
            {
                ymd1 = (DataTypeUtility.GetToInt32(sYMD.Substring(0, 4)) - 1).ToString() + "12";
                ymd3 = sYMD.Substring(0, 4) + (DataTypeUtility.GetToInt32(sYMD.Substring(4, 2)) + 1).ToString("00");
            }
            else if (sYMD.Substring(4, 2) == "12")
            {
                ymd1 = sYMD.Substring(0, 4) + (DataTypeUtility.GetToInt32(sYMD.Substring(4, 2)) - 1).ToString("00");
                ymd3 = (DataTypeUtility.GetToInt32(sYMD.Substring(0, 4)) + 1).ToString() + "01";
            }
            else
            {
                ymd1 = sYMD.Substring(0, 4) + (DataTypeUtility.GetToInt32(sYMD.Substring(4, 2)) - 1).ToString("00");
                ymd3 = sYMD.Substring(0, 4) + (DataTypeUtility.GetToInt32(sYMD.Substring(4, 2)) + 1).ToString("00");
            }
            MicroBSC.BSC.Biz.Biz_Bsc_Interface_Column objUnit = new MicroBSC.BSC.Biz.Biz_Bsc_Interface_Column();
            lblUnit.Text = "";
            DataTable dtUnit = objUnit.GetOneList(PageUtility.GetByValueDropDownList(ddlDiCode), "DVALUES1", 0).Tables[0];

            if (dtUnit.Rows.Count > 0)
            {
                MicroBSC.Biz.Common.UnitTypeInfos objUnitInfo = new MicroBSC.Biz.Common.UnitTypeInfos(DataTypeUtility.GetToInt32(dtUnit.Rows[0]["UNIT_REF_ID"]));
                lblUnit.Text = "단위 : " + objUnitInfo.Unit;
            }

            MicroBSC.BSC.Biz.Biz_Bsc_Interface_Data objInterface = new MicroBSC.BSC.Biz.Biz_Bsc_Interface_Data();
            DataTable dtResult = objInterface.GetInterfaceDataForDayResult(PageUtility.GetByValueDropDownList(ddlDiCode), sYMD, PageUtility.GetByValueDropDownList(ddlSumType));

            ugrdResult.DataSource = dtResult;
            ugrdResult.DataBind();

            dtResult = objInterface.GetInterfaceDataForDayResultGraph(PageUtility.GetByValueDropDownList(ddlDiCode), sYMD, PageUtility.GetByValueDropDownList(ddlSumType));

            MicroCharts.DundasCharts.DundasChartBase(objChart, Dundas.Charting.WebControl.ChartImageType.Flash, 980, 420
                , Dundas.Charting.WebControl.BorderSkinStyle.Emboss, System.Drawing.Color.FromArgb(181, 64, 1), 2
                , System.Drawing.Color.FromArgb(0xFF, 0xFF, 0xFE)
                , System.Drawing.Color.FromArgb(0xFF, 0xFF, 0xFE)
                , System.Drawing.Color.FromArgb(0x20, 0x80, 0xD0)
                , Dundas.Charting.WebControl.ChartDashStyle.Solid
                , -1
                , Dundas.Charting.WebControl.ChartHatchStyle.None
                , Dundas.Charting.WebControl.GradientType.TopBottom
                , Dundas.Charting.WebControl.AntiAliasing.None);

            objChart.DataSource = dtResult;
            objChart.Series.Clear();

            Dundas.Charting.WebControl.Series series1
                = MicroCharts.DundasCharts.CreateSeries(objChart
                , "sp1"
                , "Default"
                , (PageUtility.GetByValueDropDownList(ddlSumType) == "1" ? ymd1.Substring(0, 4) + "년 " + ymd1.Substring(4, 2) + "월" : "3개월 합계")
                , null
                , scType
                , 3
                , System.Drawing.Color.FromArgb(240, 87, 112, 218)
                , System.Drawing.Color.FromArgb(180, 26, 59, 105)
                , System.Drawing.Color.Transparent
                , 1
                , 9
                , System.Drawing.Color.FromArgb(64, 64, 64));
            Dundas.Charting.WebControl.Series series2 = MicroCharts.DundasCharts.CreateSeries(objChart, "sp2", "Default", sYMD.Substring(0, 4) + "년 " + sYMD.Substring(4, 2) + "월", null, scType, 3, System.Drawing.Color.FromArgb(240, 248, 134, 6), System.Drawing.Color.FromArgb(180, 26, 59, 105), System.Drawing.Color.Transparent, 1, 9, System.Drawing.Color.FromArgb(64, 64, 64));
            Dundas.Charting.WebControl.Series series3 = MicroCharts.DundasCharts.CreateSeries(objChart, "sp3", "Default", ymd3.Substring(0, 4) + "년 " + ymd3.Substring(4, 2) + "월", null, scType, 3, System.Drawing.Color.FromArgb(240, 10, 190, 207), System.Drawing.Color.FromArgb(180, 26, 59, 105), System.Drawing.Color.Transparent, 1, 9, System.Drawing.Color.FromArgb(64, 64, 64));

            series1.ValueMembersY = "RESULT1";

            int rowArea = 0;
            int rowArea2 = 0;
            int rowArea3 = 0;
            int rowArea1 = Convert.ToInt32(dtResult.Compute("MAX(RESULT1)", ""));
            rowArea = rowArea1;

            series2.ValueMembersY = "RESULT2";
            series3.ValueMembersY = "RESULT3";
            rowArea3 = Convert.ToInt32(dtResult.Compute("MAX(RESULT3)", ""));
            rowArea2 = Convert.ToInt32(dtResult.Compute("MAX(RESULT2)", ""));

            if (rowArea < rowArea2)
                rowArea = rowArea2;
            if (rowArea < rowArea3)
                rowArea = rowArea3;

            series1.ValueMemberX = "RESULTDAY";

            string rowAreaCalc = rowArea.ToString();
            string rowAreazero = string.Empty;
            for (int i = 0; i < rowArea.ToString().Length - 1; i++)
            {
                rowAreazero += "0";
            }
            rowAreaCalc = rowAreaCalc.Substring(0, 1) + rowAreazero;
            rowArea = Convert.ToInt32(rowAreaCalc) / 10;

            foreach (Dundas.Charting.WebControl.Series series in objChart.Series)
            {
                objChart.ChartAreas[objChart.Series[series.Name].ChartArea].AxisX.Margin = false;
                objChart.ChartAreas[objChart.Series[series.Name].ChartArea].AxisY2.Enabled = Dundas.Charting.WebControl.AxisEnabled.False;
                objChart.ChartAreas[objChart.Series[series.Name].ChartArea].AxisY.Interval = rowArea;
                //series.Href = HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().LastIndexOf('/')) + "/BSC0404S1.ASPX";
            }

            objChart.DataBind();
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        }
    }

    private void DoInitControl()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTerm);

        for (int i = 1; i < 13; i++)
            ddlMonth.Items.Insert(ddlMonth.Items.Count, new ListItem(i.ToString() + "월", i.ToString("00")));

        ddlSumType.Items.Insert(0, new ListItem("개별", "1"));
        ddlSumType.Items.Insert(1, new ListItem("누적", "2"));

        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        if (objTerm.GetReleasedMonth().Substring(4, 2) != "00")
            PageUtility.FindByValueDropDownList(ddlMonth, objTerm.GetReleasedMonth().Substring(4, 2));

        MicroBSC.BSC.Biz.Biz_Bsc_Interface_Dicode objInterface = new MicroBSC.BSC.Biz.Biz_Bsc_Interface_Dicode();
        DataTable dtDiCode = objInterface.GetDiCodeUseYNDailyKpiYN("Y", "Y");

        ddlDiCode.DataTextField = "NAME";
        ddlDiCode.DataValueField = "DICODE";
        ddlDiCode.DataSource = dtDiCode;
        ddlDiCode.DataBind();

        ddlDiCode.Items.Insert(0, new ListItem("::선택::", ""));

        //ddlChart.Items.Add(new ListItem("ThreeLineBreak", "ThreeLineBreak"));
        //ddlChart.Items.Add(new ListItem("Stock", "Stock"));
        ddlChart.Items.Add(new ListItem("StepLine", "StepLine"));
        //ddlChart.Items.Add(new ListItem("StackedColumn100", "StackedColumn100"));
        //ddlChart.Items.Add(new ListItem("StackedColumn", "StackedColumn"));
        //ddlChart.Items.Add(new ListItem("StackedBar100", "StackedBar100"));
        //ddlChart.Items.Add(new ListItem("StackedBar", "StackedBar"));
        //ddlChart.Items.Add(new ListItem("StackedArea100", "StackedArea100"));
        //ddlChart.Items.Add(new ListItem("StackedArea", "StackedArea"));
        //ddlChart.Items.Add(new ListItem("SplineRange", "SplineRange"));
        //ddlChart.Items.Add(new ListItem("SplineArea", "SplineArea"));
        ddlChart.Items.Add(new ListItem("Spline", "Spline"));
        //ddlChart.Items.Add(new ListItem("Renko", "Renko"));
        ddlChart.Items.Add(new ListItem("RangeColumn", "RangeColumn"));
        //ddlChart.Items.Add(new ListItem("Range", "Range"));
        ddlChart.Items.Add(new ListItem("Radar", "Radar"));
        //ddlChart.Items.Add(new ListItem("Pyramid", "Pyramid"));
        //ddlChart.Items.Add(new ListItem("Polar", "Polar"));
        //ddlChart.Items.Add(new ListItem("PointAndFigure", "PointAndFigure"));
        ddlChart.Items.Add(new ListItem("Point", "Point"));
        //ddlChart.Items.Add(new ListItem("Pie", "Pie"));
        ddlChart.Items.Add(new ListItem("Line", "Line"));
        //ddlChart.Items.Add(new ListItem("Kagi", "Kagi"));
        //ddlChart.Items.Add(new ListItem("Gantt", "Gantt"));
        //ddlChart.Items.Add(new ListItem("Funnel", "Funnel"));
        ddlChart.Items.Add(new ListItem("FastLine", "FastLine"));
        //ddlChart.Items.Add(new ListItem("ErrorBar", "ErrorBar"));
        //ddlChart.Items.Add(new ListItem("Doughnut", "Doughnut"));
        ddlChart.Items.Add(new ListItem("Column", "Column"));
        //ddlChart.Items.Add(new ListItem("CandleStick", "CandleStick"));
        ddlChart.Items.Add(new ListItem("Bubble", "Bubble"));
        //ddlChart.Items.Add(new ListItem("BoxPlot", "BoxPlot"));
        //ddlChart.Items.Add(new ListItem("Bar", "Bar"));
        //ddlChart.Items.Add(new ListItem("Area", "Area"));                                

        PageUtility.FindByValueDropDownList(ddlChart, "FastLine");
    }

    private Dundas.Charting.WebControl.SeriesChartType FindChartType()
    {
        Dundas.Charting.WebControl.SeriesChartType sct;
        switch (PageUtility.GetByValueDropDownList(ddlChart))
        {
            case "ThreeLineBreak":
                sct = Dundas.Charting.WebControl.SeriesChartType.ThreeLineBreak;
                break;
            case "Stock":
                sct = Dundas.Charting.WebControl.SeriesChartType.Stock;
                break;
            case "StepLine":
                sct = Dundas.Charting.WebControl.SeriesChartType.StepLine;
                break;
            case "StackedColumn100":
                sct = Dundas.Charting.WebControl.SeriesChartType.StackedColumn100;
                break;
            case "StackedColumn":
                sct = Dundas.Charting.WebControl.SeriesChartType.StackedColumn;
                break;
            case "StackedBar100":
                sct = Dundas.Charting.WebControl.SeriesChartType.StackedBar100;
                break;
            case "StackedBar":
                sct = Dundas.Charting.WebControl.SeriesChartType.StackedBar;
                break;
            case "StackedArea100":
                sct = Dundas.Charting.WebControl.SeriesChartType.StackedArea100;
                break;
            case "StackedArea":
                sct = Dundas.Charting.WebControl.SeriesChartType.StackedArea;
                break;
            case "SplineRange":
                sct = Dundas.Charting.WebControl.SeriesChartType.SplineRange;
                break;
            case "SplineArea":
                sct = Dundas.Charting.WebControl.SeriesChartType.SplineArea;
                break;
            case "Spline":
                sct = Dundas.Charting.WebControl.SeriesChartType.Spline;
                break;
            case "Renko":
                sct = Dundas.Charting.WebControl.SeriesChartType.Renko;
                break;
            case "RangeColumn":
                sct = Dundas.Charting.WebControl.SeriesChartType.RangeColumn;
                break;
            case "Range":
                sct = Dundas.Charting.WebControl.SeriesChartType.Range;
                break;
            case "Radar":
                sct = Dundas.Charting.WebControl.SeriesChartType.Radar;
                break;
            case "Pyramid":
                sct = Dundas.Charting.WebControl.SeriesChartType.Pyramid;
                break;
            case "Polar":
                sct = Dundas.Charting.WebControl.SeriesChartType.Polar;
                break;
            case "PointAndFigure":
                sct = Dundas.Charting.WebControl.SeriesChartType.PointAndFigure;
                break;
            case "Point":
                sct = Dundas.Charting.WebControl.SeriesChartType.Point;
                break;
            case "Pie":
                sct = Dundas.Charting.WebControl.SeriesChartType.Pie;
                break;
            case "Line":
                sct = Dundas.Charting.WebControl.SeriesChartType.Line;
                break;
            case "Kagi":
                sct = Dundas.Charting.WebControl.SeriesChartType.Kagi;
                break;
            case "Gantt":
                sct = Dundas.Charting.WebControl.SeriesChartType.Gantt;
                break;
            case "Funnel":
                sct = Dundas.Charting.WebControl.SeriesChartType.Funnel;
                break;
            case "FastLine":
                sct = Dundas.Charting.WebControl.SeriesChartType.FastLine;
                break;
            case "ErrorBar":
                sct = Dundas.Charting.WebControl.SeriesChartType.ErrorBar;
                break;
            case "Doughnut":
                sct = Dundas.Charting.WebControl.SeriesChartType.Doughnut;
                break;
            case "Column":
                sct = Dundas.Charting.WebControl.SeriesChartType.Column;
                break;
            case "CandleStick":
                sct = Dundas.Charting.WebControl.SeriesChartType.CandleStick;
                break;
            case "Bubble":
                sct = Dundas.Charting.WebControl.SeriesChartType.Bubble;
                break;
            case "BoxPlot":
                sct = Dundas.Charting.WebControl.SeriesChartType.BoxPlot;
                break;
            case "Bar":
                sct = Dundas.Charting.WebControl.SeriesChartType.Bar;
                break;
            case "Area":
                sct = Dundas.Charting.WebControl.SeriesChartType.Area;
                break;
            default:
                sct = Dundas.Charting.WebControl.SeriesChartType.FastLine;
                break;
        }
        return sct;
    }
}
