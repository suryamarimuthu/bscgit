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
using System.Data.OracleClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroCharts;

public partial class eis_eis0000 : System.Web.UI.Page
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        string query = "SELECT splyy as tmcode , sum(splddqty) as target , sum(sumddqty) as result FROM uz5plan WHERE saupjang=21 group by splyy";

        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 400, 250, BorderSkinStyle.None, Color.FromArgb(181, 64, 1), 5
            , Color.FromArgb(0xE0, 0xF0, 0xFF), Color.FromArgb(0xF0, 0xC0, 0xFF), Color.FromArgb(210, 210, 210), ChartDashStyle.Solid, 2
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 400, 250, BorderSkinStyle.None, Color.FromArgb(181, 64, 1), 5
            , Color.FromArgb(0xE0, 0xF0, 0xFF), Color.FromArgb(0xF0, 0xC0, 0xFF), Color.FromArgb(210, 210, 210), ChartDashStyle.Solid, 2
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        string ctTitle = "Line Chart";
        SeriesChartType DataCT;
        switch (type)
        {
            case 1:
                DataCT = SeriesChartType.Bar;
                ctTitle = "Bar Chart";
                break;
            case 2:
                DataCT = SeriesChartType.Line;
                ctTitle = "Line Chart";
                break;
            case 3:
                DataCT = SeriesChartType.CandleStick;
                ctTitle = "CandleStick Chart";
                break;
            case 4:
                DataCT = SeriesChartType.StackedBar;
                ctTitle = "StackedBar Chart";
                break;
            case 5:
                DataCT = SeriesChartType.Spline;
                ctTitle = "Spline Chart";
                break;
            case 6:
                DataCT = SeriesChartType.SplineArea;
                ctTitle = "SplineArea Chart";
                break;
            case 7:
                DataCT = SeriesChartType.Range;
                ctTitle = "Range Chart";
                break;
            case 8:
                DataCT = SeriesChartType.RangeColumn;
                ctTitle = "RangeColumn Chart";
                break;
            case 9:
                DataCT = SeriesChartType.Point;
                ctTitle = "Point Chart";
                break;
            case 10:
                DataCT = SeriesChartType.Gantt;
                ctTitle = "Gantt Chart";
                break;
            case 11:
                DataCT = SeriesChartType.StepLine;
                ctTitle = "StepLine Chart";
                break;
            default:
                DataCT = SeriesChartType.Radar;
                ctTitle = "Radar Chart";
                break;
        }
        
        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, DataCT, 2, Color.FromArgb(220, 65, 140, 240), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, DataCT, 2, Color.FromArgb(220, 252, 180, 65), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Series series3 = DundasCharts.CreateSeries(Chart2, "Series1", "Default", "계획", null, DataCT, 2, Color.FromArgb(220, 65, 140, 240), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series4 = DundasCharts.CreateSeries(Chart2, "Series2", "Default", "실적", null, DataCT, 2, Color.FromArgb(220, 252, 180, 65), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        
        ArrayList yValues1;
        ArrayList yValues2;
        ArrayList xValues;

        DundasCharts.SetDataFieldsX1(query, "tmcode", out xValues, "target", out yValues1, "result", out yValues2);

        series1.Points.DataBindXY(xValues, yValues1);
        series2.Points.DataBindXY(xValues, yValues2);

        //DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, true, 1);

        //DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, false);
        //DundasAnimations.GrowingAnimation(Chart1, series2, 3.0, 4.0, true);

        DataPoint point = series1.Points.FindMaxValue();
        point.Color = Color.Fuchsia;

        for (int i = 0; i < series2.Points.Count; i++)
        {
            //series2.Points[i].ShowLabelAsValue = true;

            if (yValues2[i].ToString() == "0")
            {
                series2.Points[i].Color = Color.Transparent;
            }
        }

        DundasAnimations.FadingAnimation(Chart1, point, Color.BlueViolet, Color.FromArgb(64, 64, 64), Color.Empty, Color.Empty, Color.Empty, 7.0, 1.0, true, true, -1);

        DundasAnimations.FadingAnimation(Chart2, point, Color.BlueViolet, Color.FromArgb(64, 64, 64), Color.Empty, Color.Empty, Color.Empty, 7.0, 1.0, true, true, -1);
        // Set radar chart style Line, Area, Marker
        series1["RadarDrawingStyle"] = "Line";
        series2["RadarDrawingStyle"] = "Line";

        // Set circular area drawing style //Circle, Polygon
        series1["AreaDrawingStyle"] = "Polygon";
        series2["AreaDrawingStyle"] = "Polygon";

        // Set labels style //Horizontal, Circular, Radial
        series1["CircularLabelsStyle"] = "Horizontal";
        series2["CircularLabelsStyle"] = "Horizontal";

        Font font = new Font("Tahoma", 14, FontStyle.Regular);
        Font font1 = new Font("Gulim", 9, FontStyle.Regular);
        /*
        Dundas.Charting.WebControl.Title title = DundasCharts.CreateTitle(Chart1, "Title1", ctTitle, font, Color.FromArgb(26, 59, 105), Color.Empty, Color.Empty
            , ContentAlignment.TopCenter, null, Color.FromArgb(32, 0, 0, 0), 3, false, 5, 5, 91, 6);

        Dundas.Charting.WebControl.Title title2 = DundasCharts.CreateTitle(Chart2, "Title1", ctTitle, font, Color.FromArgb(26, 59, 105), Color.Empty, Color.Empty
            , ContentAlignment.TopCenter, null, Color.FromArgb(32, 0, 0, 0), 3, false, 5, 5, 91, 6);
        */
        //Legend legend = DundasCharts.CreateLegend(Chart1, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, 75, 75, 20, 15);

        DundasCharts.SetChartArea(Chart1.ChartAreas["Default"], true);
        DundasCharts.SetChartArea(Chart2.ChartAreas["Default"], true);

        query = " SELECT a.saupjang, a.splyy, a.splmm, a.spldd, a.splddqty, a.splmmqty,";
        query += " a.splyyqty, a.sumddqty, a.summmqty, a.sumyyqty, a.modempno, a.modymdt";
        query += " FROM uz5plan a";
        query += " where a.splyy = 2006 order by saupjang, splyy, splmm";
        DataSet ds = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter ad = new OracleDataAdapter(query, _connection);
        ad.Fill(ds);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
}
