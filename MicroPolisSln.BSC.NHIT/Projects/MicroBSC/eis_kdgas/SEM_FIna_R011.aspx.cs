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

public partial class eis_SEM_FIna_R011 : EISPageBase
{
    private DBAgent dbAgent = null;
    public int iMonth = DateTime.Now.Month - 2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            ddlGbn.Items.Add(new ListItem("월계","MS"));
            ddlGbn.Items.Add(new ListItem("누계","TS"));
            ddlGbn.SelectedIndex = 1;
            if (iMonth < 0)
                ddlMonth.SelectedIndex = 11;
            else
                ddlMonth.SelectedIndex = iMonth;
            DataBindingObjects();
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        
    }
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string yearStr, string monthStr) 
    {
        //DataGrid1.DataSource = GetChartDataTable(yearStr, monthStr);
        //DataGrid1.DataBind();

        chart.DataSource = GetChartDataTable(yearStr, monthStr).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", "당년 실적", null, SeriesChartType.Line, 3, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "전년 실적", null, SeriesChartType.Line, 3, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "Month";
        series1.ValueMembersY = "T_1";
        series2.ValueMembersY = "T_2";
        //series3.ValueMembersY = "T_" + Convert.ToString(int.Parse(yearStr) - 1);
        //series4.ValueMembersY = "T_40000";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 1.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 0.5, 1.0, true);
        //DundasAnimations.GrowingAnimation(chart, series3, 4.0, 6.0, true);
        //DundasAnimations.GrowingAnimation(chart, series4, 6.0, 8.0, true);

        series1.MarkerStyle = MarkerStyle.Circle;
        series2.MarkerStyle = MarkerStyle.Diamond;
        //series3.MarkerStyle = MarkerStyle.Triangle;
        //series4.MarkerStyle = MarkerStyle.Square;
        series1.MarkerColor = Color.FromArgb(0x7A, 0x9D, 0xFE);
        series2.MarkerColor = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series3.MarkerColor = Color.FromArgb(0x20, 0xE4, 0xEB);
        //series4.MarkerColor = Color.FromArgb(0xE4, 0xE4, 0xE4);
        series1.MarkerBorderColor = Color.FromArgb(0x4A, 0x58, 0x7E);
        series2.MarkerBorderColor = Color.FromArgb(0xD7, 0x41, 0x01);
        //series3.MarkerBorderColor = Color.FromArgb(0x00, 0xC4, 0xCB);
        //series4.MarkerBorderColor = Color.FromArgb(0xE4, 0xE4, 0xE4);

    }
    private void GridBinding(string yearStr, string type)
    {
        UltraWebGrid1.DataSource = GetTwoDataTable(yearStr, type);
        UltraWebGrid1.DataBind();
    }
    //private DataTable GetGridDataTable(string yearStr, string monthStr)
    //{
    //    string query = GetQuery(yearStr, monthStr);

    //    dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
    //    DataSet ds = dbAgent.FillDataSet(query, "Data");

    //    return ds.Tables[0];
    //}
    private DataTable GetChartDataTable(string yearStr, string monthStr) 
    {
        DataTable dt = GetTwoDataTable(yearStr, monthStr);

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        dataTable.Columns.Add("MONTH", typeof(string));
        dataTable.Columns.Add("T_1", typeof(double));
        dataTable.Columns.Add("T_2", typeof(double));

        for (int i = 1; i <= 12; i++)
        {
            dr = dataTable.NewRow();
            dr["MONTH"]     = i.ToString() + "월";
            dr["T_1"] = 0;
            dr["T_2"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            for (int j = int.Parse(yearStr) - 3; j < int.Parse(yearStr); j++)
            {
                drCol = dt.Select("DADT_1 = '" + i.ToString().PadLeft(2, '0') + "'");
                //drCol = ds.Tables[0].Select("DADT_1 = '" + i.ToString().PadLeft(2,'0') + "'");
                if (drCol.Length > 0) 
                {
                    dataTable.Rows[i - 1]["T_1"] = Convert.ToDouble(drCol[0]["PL_SUM_1"].ToString());
                    dataTable.Rows[i - 1]["T_2"] = Convert.ToDouble(drCol[0]["PL_SUM_2"].ToString());
                }
            }
        }

        return dataTable;
    }
    private DataTable GetTwoDataTable(string yearStr, string monthStr) 
    {
        string query_one = GetOneQuery(yearStr, monthStr);
        string query_two = GetTwoQuery(yearStr, monthStr);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds_one = dbAgent.FillDataSet(query_one, "Data");
        DataSet ds_two = dbAgent.FillDataSet(query_two, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        dataTable.Columns.Add("DADT_1", typeof(string));
        dataTable.Columns.Add("BS_1", typeof(double));
        dataTable.Columns.Add("PL_1", typeof(double));
        dataTable.Columns.Add("PL_SUM_1", typeof(double));
        dataTable.Columns.Add("DADT_2", typeof(string));
        dataTable.Columns.Add("BS_2", typeof(double));
        dataTable.Columns.Add("PL_2", typeof(double));
        dataTable.Columns.Add("PL_SUM_2", typeof(double));

        for (int i = 1; i <= 12; i++)
        {
            dr = dataTable.NewRow();
            dr["DADT_1"] = i.ToString().PadLeft(2, '0');
            dr["BS_1"] = 0;
            dr["PL_1"] = 0;
            dr["PL_SUM_1"] = 0;
            dr["DADT_2"] = i.ToString().PadLeft(2, '0');
            dr["BS_2"] = 0;
            dr["PL_2"] = 0;
            dr["PL_SUM_2"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds_one.Tables[0].Select("DADT_1 = '" + i.ToString().PadLeft(2, '0') + "'");
            if (drCol.Length > 0)
            {
                dataTable.Rows[i - 1]["BS_1"] = Convert.ToDouble(drCol[0]["BS_1"].ToString());
                dataTable.Rows[i - 1]["PL_1"] = Convert.ToDouble(drCol[0]["PL_1"].ToString());
                dataTable.Rows[i - 1]["PL_SUM_1"] = Convert.ToDouble(drCol[0]["PL_SUM_1"].ToString());
            }
        }

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds_two.Tables[0].Select("DADT_2 = '" + i.ToString().PadLeft(2, '0') + "'");
            if (drCol.Length > 0)
            {
                dataTable.Rows[i - 1]["BS_2"] = Convert.ToDouble(drCol[0]["BS_2"].ToString());
                dataTable.Rows[i - 1]["PL_2"] = Convert.ToDouble(drCol[0]["PL_2"].ToString());
                dataTable.Rows[i - 1]["PL_SUM_2"] = Convert.ToDouble(drCol[0]["PL_SUM_2"].ToString());
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
        string yearStr      = ddlYear.SelectedValue;
        string monthStr     = ddlMonth.SelectedValue;
        
        BindingChart(Chart1, yearStr, monthStr);
        GridBinding(yearStr, monthStr);
    }
    private string GetOneQuery(string yearStr, string monthStr) 
    {
        string pYearStr = Convert.ToString(int.Parse(yearStr) - 1);

        string query = @"
                SELECT      SUBSTR(DADT,5,2) DADT_1,
                            ROUND(SUM(PL_AMT)/1000,0) AS PL_1,
                            ROUND(SUM(BS_AMT)/1000,0) AS BS_1,
                            ROUND(DECODE(SUM(BS_AMT),0,0,ROUND((SUM(PL_AMT)/ SUM(BS_AMT))*100, 2)),1) AS PL_SUM_1
                      FROM (SELECT BS.BS_DATE_T DADT,
                                   SUM(BS.BS_SUM_ACTUAL_AMOUNT) BS_AMT,
                                   0 PL_AMT
                              FROM SEM_BALANCE_SHEET BS,
                                   SEM_FINANCIAL_CODE_MASTER BS_CODE
                             WHERE BS.BS_DATE_T BETWEEN '" + yearStr + @"01' AND '" + yearStr + monthStr + @"'
                               AND BS_CODE.SEM_ACCOUNT1_CODE = '3000000000'
                               AND BS.BS_FINANCIAL_CODE_T = BS_CODE.SEM_FINANCIAL_CODE
                               AND BS.BS_ACCOUNT4_CODE_T = BS_CODE.SEM_ACCOUNT4_CODE
                             GROUP BY BS.BS_DATE_T
                             UNION ALL   
                            SELECT PL.PL_DATE_T DADT,
                                   0 BS_AMT,
                                   DECODE('"+ ddlGbn.SelectedValue +@"','MS',SUM(PL.PL_ACTUAL_AMOUNT),'TS',SUM(PL.PL_SUM_ACTUAL_AMOUNT)) PL_AMT
                              FROM SEM_PROFIT_LOSS PL
                             WHERE PL.PL_DATE_T BETWEEN '" + yearStr + @"01' AND '" + yearStr + monthStr + @"'
                               AND PL.PL_ACCOUNT3_CODE_T = '4001000000'
                             GROUP BY PL.PL_DATE_T)
                     GROUP BY DADT";
        return query;
    }
    private string GetTwoQuery(string yearStr, string monthStr)
    {
        string pYearStr = Convert.ToString(int.Parse(yearStr) - 1);

        string query = @"
                SELECT SUBSTR(DADT,5,2) DADT_2,
                       ROUND(SUM(BS_AMT)/1000,0) AS BS_2,
                       ROUND(SUM(PL_AMT)/1000,0) AS PL_2,
                       ROUND(DECODE(SUM(BS_AMT),0,0,ROUND((SUM(PL_AMT)/ SUM(BS_AMT))*100, 2)),1) AS PL_SUM_2
                  FROM (SELECT BS.BS_DATE_T DADT,
                               SUM(BS.BS_SUM_ACTUAL_AMOUNT) BS_AMT,
                               0 PL_AMT
                          FROM SEM_BALANCE_SHEET BS,
                               SEM_FINANCIAL_CODE_MASTER BS_CODE
                         WHERE BS.BS_DATE_T BETWEEN '" + pYearStr + @"01' AND '" + pYearStr + @"12'
                           AND BS_CODE.SEM_ACCOUNT1_CODE = '3000000000'
                           AND BS.BS_FINANCIAL_CODE_T = BS_CODE.SEM_FINANCIAL_CODE
                           AND BS.BS_ACCOUNT4_CODE_T = BS_CODE.SEM_ACCOUNT4_CODE
                         GROUP BY BS.BS_DATE_T
                         UNION ALL   
                        SELECT PL.PL_DATE_T DADT,
                               0 BS_AMT,
                               DECODE('" + ddlGbn.SelectedValue + @"','MS',SUM(PL.PL_ACTUAL_AMOUNT),'TS',SUM(PL.PL_SUM_ACTUAL_AMOUNT)) PL_AMT
                          FROM SEM_PROFIT_LOSS PL
                         WHERE PL.PL_DATE_T BETWEEN '" + pYearStr + @"01' AND '" + pYearStr + @"12'
                           AND PL.PL_ACCOUNT3_CODE_T = '4001000000'
                         GROUP BY PL.PL_DATE_T)
                   GROUP BY DADT";
        return query;
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);

        ch.Caption = "당기";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전기";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = e.Layout.Bands[0].Columns.FromKey("DADT_1").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;
    }
}
