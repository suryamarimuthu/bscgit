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

public partial class EIS_EIS041000 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;
    private string BU;

    private DataTable DT_DATA;

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
            ifmContent2.Attributes.Add("src", string.Format("EIS_COMMENT_HTML.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 2));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DT_DATA             = objEIS.GetData_M_4_S_10(estterm_ref_id, ymd);


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
        DataTable dt = DT_DATA;

        BindChart(Chart1
                , dt
                , string.Format(" ", YMD.Substring(2, 2)));
    }

    private void BindChart(Chart chart
                        , DataTable dt
                        , string titleName)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 480
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

        Series series1 =  DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , "당월미수금(누계)"
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
                                                , "당월수금금액"
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
            series1.Points.AddXY(" ", dt.Rows[i]["TARGET_MS"]);
        }

        for(int i = 0; i < dt.Rows.Count; i++) 
        {
            series2.Points.AddY(dt.Rows[i]["RESULT_MS"]);
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

        Font font   = new Font("Gulim", 10, FontStyle.Regular);

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
