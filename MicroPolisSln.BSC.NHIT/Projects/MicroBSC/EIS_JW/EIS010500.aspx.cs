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

public partial class EIS_EIS010500 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;

    private DataSet DS_DATA;

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

            ifmContent1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 1));
            ifmContent2.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 2));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DS_DATA             = objEIS.GetData_M_1_S_5(estterm_ref_id, ymd);


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
        BindChart(Chart1
                , DS_DATA.Tables[0]
                , ""
                , lblL1
                , lblL2
                , lblL3);

        BindChart(Chart2
                , DS_DATA.Tables[1]
                , ""
                , lblR1
                , lblR2
                , lblR3);
    }

    private void BindChart(Chart chart
                        , DataTable dt
                        , string titleName
                        , System.Web.UI.WebControls.Label lbl1
                        , System.Web.UI.WebControls.Label lbl2
                        , System.Web.UI.WebControls.Label lbl3)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 480
                                    , 220
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

        Series series1 = null;

        for(int k = 0; k < dt.Rows.Count; k++) 
        {
            if(DataTypeUtility.GetToInt32(dt.Rows[k]["KPI_REF_ID"]) < 0)
                continue;

            series1 = DundasCharts.CreateSeries(chart
                                            , "Series" + k.ToString()
                                            , "Default"
                                            , dt.Rows[k]["ALIAS"].ToString()
                                            , null
                                            , SeriesChartType.StackedColumn
                                            , 1
                                            , GetChartColor(k)
                                            , Color.FromArgb(0x4A, 0x58, 0x7E)
                                            , Color.FromArgb(64, 0, 0, 0)
                                            , 1
                                            , 9
                                            , Color.FromArgb(64, 64, 64));

            series1.Label   = "#VALY{N0}";

            series1.ToolTip                                         = "#VALY{N0}";

            //series1.ShowLabelAsValue = true;
            //series1.ShowInLegend = true;

            chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

            DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);

            series1.Font = new Font("굴림", 7, FontStyle.Regular);

            DataTable dtData = DataTypeUtility.FilterSortDataTable(dt, "KPI_REF_ID > 0");

            if(k == 0) 
            {
                series1.Points.AddXY("계획", dt.Rows[k]["TARGET_TS"]);
                series1.Points.AddXY("실적", dt.Rows[k]["RESULT_TS"]);
            }
            else 
            {
                series1.Points.AddY(dt.Rows[k]["TARGET_TS"]);
                series1.Points.AddY(dt.Rows[k]["RESULT_TS"]);
            }

            //series1.ToolTip = "#VALY{#,##0,00}";
            //series2.ToolTip = "#VALY{#,##0}";
        }

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

        legend.AutoFitText = false;
        legend.Position = new ElementPosition(80, 7, 50, 20);
        legend.Font = new Font("굴림", 7, FontStyle.Regular);

        DataRow[] drCol = dt.Select(string.Format("KPI_REF_ID < 0"));

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);

        if(drCol.Length > 0) 
        {
            lbl1.Text = DataTypeUtility.GetToDouble(drCol[0]["RNF_RATE"]).ToString("#,##0.00") + "%";
        }
        else 
        {
            lbl1.Text = "0" + "%";
        }

        drCol = dt.Select(string.Format("KPI_REF_ID < 0"));

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);

        if(drCol.Length > 0) 
        {
            lbl2.Text = DataTypeUtility.GetToDouble(drCol[0]["TARGET_TS"]).ToString("#,##0") + "";
            lbl3.Text = DataTypeUtility.GetToDouble(drCol[0]["RESULT_TS"]).ToString("#,##0") + "";
        }
        else 
        {
            lbl2.Text = "0" + "";
            lbl3.Text = "0" + "";
        }
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
