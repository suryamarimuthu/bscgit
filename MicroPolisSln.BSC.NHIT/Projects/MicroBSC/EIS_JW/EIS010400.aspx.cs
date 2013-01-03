﻿using System;
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

public partial class EIS_EIS010400 : EstPageBase
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
            ifmContent3.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 3));
            ifmContent4.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 4));
            ifmContent5.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 5));
            ifmContent6.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 6));
            ifmContent7.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 7));
            ifmContent8.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 8));
            ifmContent9.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 9));
            ifmContent10.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 10));
            ifmContent11.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 11));
            ifmContent12.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 12));
            ifmContent13.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 13));
            ifmContent14.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 14));
            ifmContent15.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 15));
            ifmContent16.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 16));
            ifmContent17.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 17));
            ifmContent18.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 18));
            ifmContent19.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 19));
            ifmContent20.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 20));
            ifmContent21.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 21));
            ifmContent22.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 22));
            ifmContent23.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 23));
            ifmContent24.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 24));
            ifmContent25.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 25));
            ifmContent26.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 26));
            ifmContent27.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 27));
            ifmContent28.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 28));
            ifmContent29.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 29));
            ifmContent30.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 30));
            ifmContent31.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 31));
            ifmContent32.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 32));
            ifmContent33.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 33));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS    = new Dac_EISDatas();
        DS_DATA             = objEIS.GetData_M_1_S_4(estterm_ref_id, ymd);
    }

    private void DataBinding() 
    {
        DataTable dtIndex = new DataTable();
        DataRow dr = null;
        dtIndex.Columns.Add("IDX", typeof(int));
        dtIndex.Columns.Add("BU", typeof(string));

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 1;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 2;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 3;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 4;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 5;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 6;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 7;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 8;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 9;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 10;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 11;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 12;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 13;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 14;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 15;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 16;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 17;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 18;
        dr["BU"]    = "DD";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 19;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 20;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 21;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 22;
        dr["BU"]    = "DO";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 23;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 24;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 25;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 26;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 27;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 28;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 29;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 30;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 31;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 32;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 33;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);


        HtmlTable tbl = Page.FindControl("tbl") as HtmlTable;

        foreach(Control con in tbl.Controls) 
        {
            if(con is HtmlTableRow) 
            {
                int idx = DataTypeUtility.GetToInt32(con.ID.Replace("tr", ""));

                string filter = "";

                if(BU.Equals(""))
                    filter = @"BU <> 'CJ' AND IDX = {1}";
                else
                    filter = @"BU = '{0}' AND IDX = {1}";

                DataRow[] drCol = dtIndex.Select(string.Format(   filter
                                                                , BU
                                                                , idx));

                if(drCol.Length > 0) 
                {
                    con.Visible = true;

                    if(DS_DATA.Tables[idx - 1].Rows.Count > 0) 
                    {
                        BindChart(Page.FindControl(string.Format("Chart{0}", idx)) as Dundas.Charting.WebControl.Chart
                                , DS_DATA.Tables[idx - 1]
                                , "");
                    }
                    else
                    {
                        con.Visible = false;
                    }
                }
                else
                {
                    con.Visible = false;
                }
            }
            else 
            {
                con.Visible = false;
            }


        }

        //BindChart(Chart1
        //        , DT_DATA_01
        //        , "DD사업부_PTC");

        //BindChart(Chart2
        //        , DT_DATA_02
        //        , "DD사업부_VM");

        //BindChart(Chart3
        //        , DT_DATA_03
        //        , "DO사업부");
    }

    private void BindChart(Chart chart
                        , DataTable dt
                        , string titleName)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 480
                                    , 150
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
                                                , "매출액"
                                                , null
                                                , SeriesChartType.Column
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
                                                , "영업이익"
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

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";

        //series1.ShowLabelAsValue = true;
        //series1.ShowInLegend = true;

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);
        DundasAnimations.GrowingAnimation(chart, series2, 0.5, 1.5, true);

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points[i].AxisLabel = dt.Rows[i]["ALIAS"].ToString();
        //}

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points.AddY(dt.Rows[i]["RESULT_TS"]);
        //}

        series1.Font = new Font("굴림", 7, FontStyle.Regular);
        series2.Font = new Font("굴림", 7, FontStyle.Regular);

        if(dt.Rows.Count > 0) 
        {
            series1.Points.AddXY("당월", dt.Rows[0]["RESULT_MS"]);
            series1.Points.AddXY("누계", dt.Rows[0]["RESULT_TS"]);
            series1.Points.AddXY("전년동기실적", dt.Rows[0]["BF_RESULT_TS"]);

            series2.Points.AddY(dt.Rows[1]["RESULT_MS"]);
            series2.Points.AddY(dt.Rows[1]["RESULT_TS"]);
            series2.Points.AddY(dt.Rows[1]["BF_RESULT_TS"]);
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

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
