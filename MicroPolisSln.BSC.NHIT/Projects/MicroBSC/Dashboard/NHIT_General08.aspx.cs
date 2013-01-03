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
using Dundas.Charting.WebControl;

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

public partial class Dashboard_NHIT_General08 : AppPageBase
{
    protected Color CHART_COLOR1 = Color.FromArgb(0x33, 0x66, 0xff);
    protected Color CHART_COLOR2 = Color.FromArgb(0x99, 0xcc, 0x00);
    protected Color CHART_COLOR3 = Color.FromArgb(0xff, 0xcc, 0x00);
    protected Color CHART_COLOR4 = Color.FromArgb(0xff, 0x99, 0x00);

    protected Color CHART_COL_BLUE1 = Color.FromArgb(0, 148, 225);
    protected Color CHART_COL_BLUE2 = Color.FromArgb(114, 200, 251);

    protected Color CHART_COL_ORANGE1 = Color.FromArgb(255, 167, 41);
    protected Color CHART_COL_ORANGE2 = Color.FromArgb(255, 214, 158);

    protected Color CHART_COL_GREEN1 = Color.FromArgb(152, 199, 11);
    protected Color CHART_COL_GREEN2 = Color.FromArgb(227, 244, 175);

    protected Color CHART_BORDER_BLUE = Color.FromArgb(87, 123, 201);
    protected Color CHART_BORDER_GRAY = Color.FromArgb(194, 194, 194);

    protected Color CHART_COLUMN_RED = Color.FromArgb(200, 255, 0, 0);

    protected Color CHART_COLUMN_BLUE = Color.FromArgb(0, 148, 225);
    protected Color CHART_COLUMN_GR = Color.FromArgb(150, 116, 255, 15);
    protected Color CHART_COLUMN_YELLOW = Color.FromArgb(200, 255, 255, 0);

    protected Color CHART_COLUMN_GREEN = Color.FromArgb(152, 199, 11);
    protected Color CHART_COLUMN_ORANGE = Color.FromArgb(255, 173, 65);
    protected Color CHART_COLUMN_BORDER = Color.FromArgb(102, 102, 102);

    protected Color CHART_LINE_BLUE = Color.FromArgb(58, 127, 205);
    protected Color CHART_LINE_ORANGE = Color.FromArgb(242, 129, 46);

    private int ChartWidth = 318;
    private int ChartHeight = 230;




    const int SRC_CNT = 4;
    string[] ARR_SRCNAME;
    Color[] ARR_SRCCOLOR;
    Color BORDER_COLOR;
    int BORDER_WIDTH;
    Color SHADOW_COLOR;
    int SHADOW_OFFSET;
    int MAKER_SIZE;
    Color MAKER_BORDER_COLOR;
    Dundas.Charting.WebControl.SeriesChartType[] CHART_TYPE;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        ARR_SRCNAME = new string[SRC_CNT] { "매출목표", "매출실적", "손익목표", "손익실적" };//데이터 종류
        ARR_SRCCOLOR = new Color[SRC_CNT] { CHART_COLOR1, CHART_COLOR2, CHART_COLOR3, CHART_COLOR4 };//데이터 색상 종류
        BORDER_COLOR = Color.FromArgb(180, 26, 59, 105);
        BORDER_WIDTH = 1;
        SHADOW_COLOR = Color.FromArgb(64, 0, 0, 0);
        SHADOW_OFFSET = 1;
        MAKER_SIZE = 9;
        MAKER_BORDER_COLOR = Color.FromArgb(64, 0, 0, 0);
        CHART_TYPE = new Dundas.Charting.WebControl.SeriesChartType[SRC_CNT] { Dundas.Charting.WebControl.SeriesChartType.Column
                                                                                , Dundas.Charting.WebControl.SeriesChartType.Column
                                                                                , Dundas.Charting.WebControl.SeriesChartType.Line
                                                                                , Dundas.Charting.WebControl.SeriesChartType.Line};//차트 타입




        //데이터 입력될 베이스 제작
        DataTable dt = new DataTable();//데이터집합
        string[] arr_srcTerm = { "1/4분기", "2/4분기", "3/4분기", "4/4분기" };//기간




        for (int i = 0; i < ARR_SRCNAME.Length; i++)
        {
            dt.Columns.Add("TERM_" + i);
            dt.Columns.Add("VALUE_" + i, typeof(System.Double));
        }





        for (int i = 0; i < ARR_SRCNAME.Length; i++)
        {
            ArrayList arr_srcValue = new ArrayList();

            //분류별 데이터 입력
            if (i == 0)
            {
                arr_srcValue.Add(34982);
                arr_srcValue.Add(68990);
                arr_srcValue.Add(94064);
                arr_srcValue.Add(142025);
            }
            else if (i == 1)
            {
                arr_srcValue.Add(47363);
                arr_srcValue.Add(72883);
                arr_srcValue.Add(100348);
            }
            else if (i == 2)
            {
                arr_srcValue.Add(2113);
                arr_srcValue.Add(3308);
                arr_srcValue.Add(3093);
                arr_srcValue.Add(6056);
            }
            else if (i == 3)
            {
                arr_srcValue.Add(3171);
                arr_srcValue.Add(4043);
                arr_srcValue.Add(5227);
            }



            for (int j = 0; j < arr_srcTerm.Length; j++)
            {
                dt.Rows.Add(dt.NewRow());

                dt.Rows[j]["TERM_" + i] = arr_srcTerm[j];
                dt.Rows[j]["VALUE_" + i] = arr_srcValue.Count > j ? arr_srcValue[j] : 0;
            }
        }




        //으헝~ 데이터셋으로 넘기는거 포기 ㅠㅠ
        DrawingChart(dt, this.chart);
    }




    private void DrawingChart(DataTable dt, Dundas.Charting.WebControl.Chart chart)
    {
        DundasCharts.DundasChartBase(chart
                                    , Dundas.Charting.WebControl.ChartImageType.Jpeg
                                    , DataTypeUtility.GetToInt32(chart.Width.Value)
                                    , DataTypeUtility.GetToInt32(chart.Height.Value)
                                    , Dundas.Charting.WebControl.BorderSkinStyle.None
                                    , Color.FromArgb(181, 64, 1)
                                    , 0
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , Dundas.Charting.WebControl.ChartDashStyle.Solid
                                    , -1
                                    , Dundas.Charting.WebControl.ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);


        chart.DataSource = dt;



        Dundas.Charting.WebControl.Series[] arr_series = new Dundas.Charting.WebControl.Series[ARR_SRCNAME.Length];

        for (int i = 0; i < ARR_SRCNAME.Length; i++)
        {
            string seriesName = ARR_SRCNAME[i];

            Dundas.Charting.WebControl.Series series = DundasCharts.CreateSeries(chart
                                                                            , seriesName
                                                                            , "Default"
                                                                            , seriesName
                                                                            , null
                                                                            , CHART_TYPE[i]
                                                                            , BORDER_WIDTH
                                                                            , ARR_SRCCOLOR[i]
                                                                            , BORDER_COLOR
                                                                            , SHADOW_COLOR
                                                                            , SHADOW_OFFSET
                                                                            , MAKER_SIZE
                                                                            , MAKER_BORDER_COLOR);
            series.Color = ARR_SRCCOLOR[i];
            series.BorderWidth = 0;
            series.BorderColor = ARR_SRCCOLOR[i];
            series.ShadowOffset = 0;
            series.ValueMembersY = "VALUE_" + i;
            series.ValueMemberX = "TERM_" + i;
            series.ToolTip = "#VALY{N0}";

            if (i > 1)
            {
                series.YAxisType = Dundas.Charting.WebControl.AxisType.Secondary;
                
                if (i == 3)
                    series.MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.Circle;
                else
                    series.MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.Triangle;

                series.MarkerColor = ARR_SRCCOLOR[i];
                series.MarkerBorderColor = ARR_SRCCOLOR[i];
                series.MarkerSize = 5;
            }


            arr_series[i] = series;
        }


        
        //DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);

        //for (int i = 0; i < ds.Tables.Count; i++)
        //{
        //    DundasAnimations.GrowingAnimation(chart, arr_series[i], 0.5, 3.0, true);
        //}


        chart.DataBind();
    }
}
