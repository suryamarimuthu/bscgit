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
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Data.Oracle;
using System.Text;

public partial class eis_SEM_Mana_R027 : EISPageBase
{
    private DBAgent dbAgent = null;
    protected string MONTH = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //  SetDateDropDownList(ddlYear, ddlMonth);
            DateTime objDT = DateTime.Now;
            string yearStr;
            string monthStr;
            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.ddlYear.Items.Clear();
            this.ddlMonth.Items.Clear();

            for (intLP = 1; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    monthStr = "0" + intLP.ToString();
                }
                else
                {
                    monthStr = intLP.ToString();
                }

                this.ddlMonth.Items.Add(new ListItem(monthStr, monthStr));
                if (intMM - 1 == intLP)
                {
                    this.ddlMonth.SelectedValue = monthStr;
                }

            }

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                yearStr = iniYY.ToString();
                this.ddlYear.Items.Add(new ListItem(yearStr, yearStr));
            }
            this.ddlYear.SelectedIndex = ddlYear.Items.Count - 1;

            SetAreaDropDownList(ddlArea);
            DataBindingObjects();

            this.ddlGubn.Items.Add(new ListItem("월계", "MS"));
            this.ddlGubn.Items.Add(new ListItem("누계", "TS"));
            ddlGubn.SelectedIndex = 0;

            //DateTime dtNow = System.DateTime.Now.AddMonths(-1);
            //FindByValueDropDownList(ddlMonth, (dtNow.Month < 10 ? "0" + dtNow.Month.ToString() : dtNow.Month.ToString()));
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        e.Row.Cells.FromKey("DIFF_TOTL_QNT" + "_A").Value = double.Parse(dr["DIFF_TOTL_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 2)].ToString());
        e.Row.Cells.FromKey("DIFF_SALE_QNT" + "_A").Value = double.Parse(dr["DIFF_SALE_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 2)].ToString());
        e.Row.Cells.FromKey("DIFF_ADJUST_QNT" + "_A").Value = double.Parse(dr["DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 2)].ToString());
        e.Row.Cells.FromKey("RATE_ADJUST" + "_A").Value = double.Parse(dr["RATE_ADJUST" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 2)].ToString());
        e.Row.Cells.FromKey("DIFF_TOTL_QNT" + "_B").Value = double.Parse(dr["DIFF_TOTL_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 1)].ToString());
        e.Row.Cells.FromKey("DIFF_SALE_QNT" + "_B").Value = double.Parse(dr["DIFF_SALE_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 1)].ToString());
        e.Row.Cells.FromKey("DIFF_ADJUST_QNT" + "_B").Value = double.Parse(dr["DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 1)].ToString());
        e.Row.Cells.FromKey("RATE_ADJUST" + "_B").Value = double.Parse(dr["RATE_ADJUST" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 1)].ToString());
        e.Row.Cells.FromKey("DIFF_TOTL_QNT" + "_C").Value = double.Parse(dr["DIFF_TOTL_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 0)].ToString());
        e.Row.Cells.FromKey("DIFF_SALE_QNT" + "_C").Value = double.Parse(dr["DIFF_SALE_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 0)].ToString());
        e.Row.Cells.FromKey("DIFF_ADJUST_QNT" + "_C").Value = double.Parse(dr["DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 0)].ToString());
        e.Row.Cells.FromKey("RATE_ADJUST" + "_C").Value = double.Parse(dr["RATE_ADJUST" + Convert.ToString(int.Parse(ddlYear.SelectedValue) - 0)].ToString());

    }
    private void BindingChartOneYear(Dundas.Charting.WebControl.Chart chart, string yearStr, string monthStr, string type, string gubn)
    {
        chart.DataSource = GetChartDataTableOneYear(yearStr, monthStr, type, gubn).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 400, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", "차이량", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "차이비율", null, SeriesChartType.Line, 3, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "MONTH";
        series1.ValueMembersY = "DIFF_ADJUST_QNT";
        series2.ValueMembersY = "RATE_ADJUST";

        series2.YAxisType = AxisType.Secondary;

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 5.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 1.0, 2.0, true);

        series2.MarkerStyle = MarkerStyle.Diamond;

        series2.MarkerColor = Color.FromArgb(0xFF, 0xAA, 0x20);

        series2.MarkerBorderColor = Color.FromArgb(0xD7, 0x41, 0x01);
    }
    private void BindingChartThreeYear(Dundas.Charting.WebControl.Chart chart, string yearStr, string monthStr, string type, string gubn)
    {
        chart.DataSource = GetChartDataTableThreeYear(yearStr, monthStr, type, gubn).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 400, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series4", "Default", Convert.ToString(int.Parse(yearStr) - 0) + "년", null, SeriesChartType.Line, 3, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series5", "Default", Convert.ToString(int.Parse(yearStr) - 1) + "년", null, SeriesChartType.Line, 3, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(chart, "Series6", "Default", Convert.ToString(int.Parse(yearStr) - 2) + "년", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "MONTH";
        series1.ValueMembersY = "RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 0);
        series2.ValueMembersY = "RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 1);
        series3.ValueMembersY = "RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 2);


        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 1.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 1.0, 1.5, true);
        DundasAnimations.GrowingAnimation(chart, series3, 1.0, 2.0, true);

        series1.MarkerStyle = MarkerStyle.Circle;
        series2.MarkerStyle = MarkerStyle.Diamond;
        series3.MarkerStyle = MarkerStyle.Triangle;

        series1.MarkerColor = Color.FromArgb(0x7A, 0x9D, 0xFE);
        series2.MarkerColor = Color.FromArgb(0xFF, 0xAA, 0x20);
        series3.MarkerColor = Color.FromArgb(0x20, 0xE4, 0xEB);

        series1.MarkerBorderColor = Color.FromArgb(0x4A, 0x58, 0x7E);
        series2.MarkerBorderColor = Color.FromArgb(0xD7, 0x41, 0x01);
        series3.MarkerBorderColor = Color.FromArgb(0x00, 0xC4, 0xCB);

    }
    private void GridBinding(string yearStr, string monthStr, string type, string gubn)
    {
        UltraWebGrid1.DataSource = GetChartDataTableThreeYear(yearStr, monthStr, type, gubn);
        UltraWebGrid1.DataBind();
    }
    private DataTable GetChartDataTableOneYear(string yearStr, string monthStr, string type, string gubn)
    {
        string query = GetQueryOneYear(yearStr, monthStr, type, gubn);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        dataTable.Columns.Add("MONTH", typeof(string));
        dataTable.Columns.Add("DIFF_ADJUST_QNT", typeof(double));
        dataTable.Columns.Add("RATE_ADJUST", typeof(double));

        for (int i = 1; i <= 12; i++)
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = i.ToString();
            dr["DIFF_ADJUST_QNT"] = 0;
            dr["RATE_ADJUST"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds.Tables[0].Select("C_MONTH = '" + i.ToString().PadLeft(2, '0') + "'");
            if (drCol.Length > 0)
            {
                dataTable.Rows[i - 1]["DIFF_ADJUST_QNT"] = Convert.ToDouble(drCol[0]["DIFF_ADJUST_QNT"].ToString());
                dataTable.Rows[i - 1]["RATE_ADJUST"] = Convert.ToDouble(drCol[0]["RATE_ADJUST"].ToString());
            }
        }

        return dataTable;
    }
    private DataTable GetChartDataTableThreeYear(string yearStr, string monthStr, string type, string gubn)
    {
        string query = GetQueryThreeYear(yearStr, monthStr, type, gubn);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        dataTable.Columns.Add("MONTH", typeof(string));
        dataTable.Columns.Add("DIFF_TOTL_QNT" + Convert.ToString(int.Parse(yearStr) - 0), typeof(string));
        dataTable.Columns.Add("DIFF_SALE_QNT" + Convert.ToString(int.Parse(yearStr) - 0), typeof(string));
        dataTable.Columns.Add("DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(yearStr) - 0), typeof(string));
        dataTable.Columns.Add("RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 0), typeof(double));
        dataTable.Columns.Add("DIFF_TOTL_QNT" + Convert.ToString(int.Parse(yearStr) - 1), typeof(string));
        dataTable.Columns.Add("DIFF_SALE_QNT" + Convert.ToString(int.Parse(yearStr) - 1), typeof(string));
        dataTable.Columns.Add("DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(yearStr) - 1), typeof(string));
        dataTable.Columns.Add("RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 1), typeof(double));
        dataTable.Columns.Add("DIFF_TOTL_QNT" + Convert.ToString(int.Parse(yearStr) - 2), typeof(string));
        dataTable.Columns.Add("DIFF_SALE_QNT" + Convert.ToString(int.Parse(yearStr) - 2), typeof(string));
        dataTable.Columns.Add("DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(yearStr) - 2), typeof(string));
        dataTable.Columns.Add("RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 2), typeof(double));

        for (int i = 1; i <= 12; i++)
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = i.ToString();
            dr["DIFF_TOTL_QNT" + Convert.ToString(int.Parse(yearStr) - 0)] = 0;
            dr["DIFF_SALE_QNT" + Convert.ToString(int.Parse(yearStr) - 0)] = 0;
            dr["DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(yearStr) - 0)] = 0;
            dr["RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 0)] = 0;
            dr["DIFF_TOTL_QNT" + Convert.ToString(int.Parse(yearStr) - 1)] = 0;
            dr["DIFF_SALE_QNT" + Convert.ToString(int.Parse(yearStr) - 1)] = 0;
            dr["DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(yearStr) - 1)] = 0;
            dr["RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 1)] = 0;
            dr["DIFF_TOTL_QNT" + Convert.ToString(int.Parse(yearStr) - 2)] = 0;
            dr["DIFF_SALE_QNT" + Convert.ToString(int.Parse(yearStr) - 2)] = 0;
            dr["DIFF_ADJUST_QNT" + Convert.ToString(int.Parse(yearStr) - 2)] = 0;
            dr["RATE_ADJUST" + Convert.ToString(int.Parse(yearStr) - 2)] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            for (int j = int.Parse(yearStr); j >= int.Parse(yearStr) - 2; j--)
            {
                drCol = ds.Tables[0].Select("C_MONTH = '" + i.ToString().PadLeft(2, '0') + "' AND C_YEAR = '" + j.ToString() + "'");
                if (drCol.Length > 0)
                {
                    dataTable.Rows[i - 1]["DIFF_TOTL_QNT" + Convert.ToString(j)] = Convert.ToDouble(drCol[0]["DIFF_TOTL_QNT"].ToString());
                    dataTable.Rows[i - 1]["DIFF_SALE_QNT" + Convert.ToString(j)] = Convert.ToDouble(drCol[0]["DIFF_SALE_QNT"].ToString());
                    dataTable.Rows[i - 1]["DIFF_ADJUST_QNT" + Convert.ToString(j)] = Convert.ToDouble(drCol[0]["DIFF_ADJUST_QNT"].ToString());
                    dataTable.Rows[i - 1]["RATE_ADJUST" + Convert.ToString(j)] = Convert.ToDouble(drCol[0]["RATE_ADJUST"].ToString());
                }
            }
        }

        return dataTable;
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects()
    {
        string yearStr = ddlYear.SelectedValue;
        string monthStr = ddlMonth.SelectedValue;
        string type = ddlArea.SelectedValue;
        string gubn = ddlGubn.SelectedValue;

        BindingChartOneYear(Chart1, yearStr, monthStr, type, gubn);
        BindingChartThreeYear(Chart2, yearStr, monthStr, type, gubn);
        GridBinding(yearStr, monthStr, type, gubn);
    }
    private string GetQueryOneYear(string yearStr, string monthStr, string type, string gubn)
    {
        string query = @"
            SELECT SD.DIFF_DATE_T,
                   SUBSTR(SD.DIFF_DATE_T,1,4) C_YEAR,
                   SUBSTR(SD.DIFF_DATE_T,5,2) C_MONTH,
                   ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_SALE_QNT)/1000, SUM(SD.DIFF_SALE_QNT)/1000), 2) DIFF_SALE_QNT,                       -- 매출량
                   ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_ADJUST_QNT)/1000, SUM(SD.DIFF_ADJUST_QNT)/1000),2) * -1 DIFF_ADJUST_QNT,                   -- 조정량
                   ROUND(decode('" + gubn + @"','TS', DECODE(SUM(SD.DIFF_SUM_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_SUM_ADJUST_QNT)/ SUM(SD.DIFF_SUM_SALE_QNT))*100, 2))  ,
                                                      DECODE(SUM(SD.DIFF_SALE_QNT),0,0, ROUND((SUM(SD.DIFF_ADJUST_QNT)/SUM(SD.DIFF_SALE_QNT))*100,2))), 1)  * -1 RATE_ADJUST
	      FROM SEM_SALE_DIFFERENCE SD
	     WHERE SD.DIFF_DATE_T BETWEEN '" + yearStr + @"01' AND '" + yearStr + monthStr + @"'
	       AND (SD.DIFF_OFFICE_T = '" + type + @"' OR '--' = '" + type + @"')
	     GROUP BY SD.DIFF_DATE_T";

        return query;
    }
    private string GetQueryThreeYear(string yearStr, string monthStr, string type, string gubn)
    {
        string query = @"
                           SELECT SD.DIFF_DATE_T,                                -- 년월
                                  SUBSTR(SD.DIFF_DATE_T,1,4) C_YEAR,
                                  SUBSTR(SD.DIFF_DATE_T,5,2) C_MONTH,
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_TOTAL_QNT)/1000, SUM(SD.DIFF_TOTAL_QNT)/1000),0) DIFF_TOTL_QNT,                           -- 총판매량
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_SALE_QNT)/1000,  SUM(SD.DIFF_SALE_QNT)/1000), 0) DIFF_SALE_QNT,                           -- 매출량
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_ADJUST_QNT)/1000,SUM(SD.DIFF_ADJUST_QNT)/1000),0) * -1 DIFF_ADJUST_QNT,                      -- 조정량
                                  ROUND(decode('" + gubn + @"','TS',DECODE(SUM(SD.DIFF_SUM_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_SUM_ADJUST_QNT)/ SUM(SD.DIFF_SUM_SALE_QNT))*100, 2)),
                                                                    DECODE(SUM(SD.DIFF_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_ADJUST_QNT)/ SUM(SD.DIFF_SALE_QNT))*100, 2))), 1)  * -1 RATE_ADJUST
	                     FROM SEM_SALE_DIFFERENCE SD
		            WHERE SD.DIFF_DATE_T BETWEEN '" + Convert.ToString(int.Parse(yearStr) - 2) + @"01' AND '" + Convert.ToString(int.Parse(yearStr) - 2) + @"12'
		              AND (SD.DIFF_OFFICE_T = '" + type + @"' OR '--' = '" + type + @"')
		            GROUP BY SD.DIFF_DATE_T
                            UNION 		
                           SELECT SD.DIFF_DATE_T,                                -- 년월
                                  SUBSTR(SD.DIFF_DATE_T,1,4) C_YEAR,
                                  SUBSTR(SD.DIFF_DATE_T,5,2) C_MONTH,
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_TOTAL_QNT)/1000, SUM(SD.DIFF_TOTAL_QNT)/1000),0) DIFF_TOTL_QNT,                           -- 총판매량
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_SALE_QNT)/1000,  SUM(SD.DIFF_SALE_QNT)/1000), 0) DIFF_SALE_QNT,                           -- 매출량
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_ADJUST_QNT)/1000,SUM(SD.DIFF_ADJUST_QNT)/1000),0) * -1 DIFF_ADJUST_QNT,                      -- 조정량
                                  ROUND(decode('" + gubn + @"','TS',DECODE(SUM(SD.DIFF_SUM_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_SUM_ADJUST_QNT)/ SUM(SD.DIFF_SUM_SALE_QNT))*100, 2)),
                                                                    DECODE(SUM(SD.DIFF_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_ADJUST_QNT)/ SUM(SD.DIFF_SALE_QNT))*100, 2))), 1)  * -1 RATE_ADJUST
	                     FROM SEM_SALE_DIFFERENCE SD
		            WHERE SD.DIFF_DATE_T BETWEEN '" + Convert.ToString(int.Parse(yearStr) - 1) + @"01' AND '" + Convert.ToString(int.Parse(yearStr) - 1) + @"12'
		              AND (SD.DIFF_OFFICE_T = '" + type + @"' OR '--' = '" + type + @"')
		            GROUP BY SD.DIFF_DATE_T
                            UNION		
                           SELECT SD.DIFF_DATE_T,                                -- 년월
                                  SUBSTR(SD.DIFF_DATE_T,1,4) C_YEAR,
                                  SUBSTR(SD.DIFF_DATE_T,5,2) C_MONTH,
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_TOTAL_QNT)/1000, SUM(SD.DIFF_TOTAL_QNT)/1000),0) DIFF_TOTL_QNT,                           -- 총판매량
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_SALE_QNT)/1000,  SUM(SD.DIFF_SALE_QNT)/1000), 0) DIFF_SALE_QNT,                           -- 매출량
                                  ROUND(decode('" + gubn + @"','TS',SUM(SD.DIFF_SUM_ADJUST_QNT)/1000,SUM(SD.DIFF_ADJUST_QNT)/1000),0) * -1 DIFF_ADJUST_QNT,                      -- 조정량
                                  ROUND(decode('" + gubn + @"','TS',DECODE(SUM(SD.DIFF_SUM_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_SUM_ADJUST_QNT)/ SUM(SD.DIFF_SUM_SALE_QNT))*100, 2)),
                                                                    DECODE(SUM(SD.DIFF_SALE_QNT),0,0,ROUND((SUM(SD.DIFF_ADJUST_QNT)/ SUM(SD.DIFF_SALE_QNT))*100, 2))), 1)  * -1 RATE_ADJUST
	                     FROM SEM_SALE_DIFFERENCE SD
		            WHERE SD.DIFF_DATE_T BETWEEN '" + yearStr + @"01' AND '" + yearStr + monthStr + @"'
		              AND (SD.DIFF_OFFICE_T = '" + type + @"' OR '--' = '" + type + @"')
		            GROUP BY SD.DIFF_DATE_T
                           ";

        return query;
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();

        int iIndex = 0;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = null;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = Convert.ToString(int.Parse(ddlYear.SelectedValue) - 0) + "년";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = Convert.ToString(int.Parse(ddlYear.SelectedValue) - 1) + "년";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = Convert.ToString(int.Parse(ddlYear.SelectedValue) - 2) + "년";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch = e.Layout.Bands[0].Columns.FromKey("MONTH").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;
    }
}
