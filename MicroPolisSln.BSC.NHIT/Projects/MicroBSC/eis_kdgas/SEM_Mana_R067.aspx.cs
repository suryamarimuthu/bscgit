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

public partial class eis_SEM_Mana_R067 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            SetAreaDropDownList(ddlArea);
            SetTypeDropDownList(ddlType);
            DataBindingObjects();
        }
    }
    public void SetTypeDropDownList(System.Web.UI.WebControls.DropDownList ddList)
    {
        string query = @"
                        SELECT BS_CODE.SEM_ACCOUNT4_CODE,
                               BS_CODE.SEM_ACCOUNT4_DESC
                          FROM SEM_FINANCIAL_CODE_MASTER BS_CODE
                         WHERE BS_CODE.SEM_FINANCIAL_CODE = 'BS'
                           AND BS_CODE.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        ddList.DataSource = ds;
        ddList.DataTextField = "SEM_ACCOUNT4_DESC";
        ddList.DataValueField = "SEM_ACCOUNT4_CODE";
        ddList.DataBind();

        //ddList.Items.Insert(0, new ListItem("전체", "*"));
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        
    }
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string yearStr, string monthStr, string areaStr, string type) 
    {
        chart.DataSource = GetChartDataTable(yearStr, monthStr, areaStr, type).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", "예산", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(chart, "Series3", "Default", "집행률", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "MONTH_NAME";
        series1.ValueMembersY = "BUDGET";
        series2.ValueMembersY = "ACTUAL";
        series3.ValueMembersY = "RATE";
        //series4.ValueMembersY = "T_40000";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(chart, series3, 1.0, 2.0, true);
        //DundasAnimations.GrowingAnimation(chart, series4, 6.0, 8.0, true);

        //series1.MarkerStyle = MarkerStyle.Circle;
        //series2.MarkerStyle = MarkerStyle.Diamond;
        //series3.MarkerStyle = MarkerStyle.Triangle;
        //series4.MarkerStyle = MarkerStyle.Square;
        //series1.MarkerColor = Color.FromArgb(0x7A, 0x9D, 0xFE);
        //series2.MarkerColor = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series3.MarkerColor = Color.FromArgb(0x20, 0xE4, 0xEB);
        //series4.MarkerColor = Color.FromArgb(0xE4, 0xE4, 0xE4);
        //series1.MarkerBorderColor = Color.FromArgb(0x4A, 0x58, 0x7E);
        //series2.MarkerBorderColor = Color.FromArgb(0xD7, 0x41, 0x01);
        //series3.MarkerBorderColor = Color.FromArgb(0x00, 0xC4, 0xCB);
        //series4.MarkerBorderColor = Color.FromArgb(0xE4, 0xE4, 0xE4);
    }
    //private void GridBinding(string yearStr, string monthStr, string type)
    //{
    //    UltraWebGrid1.DataSource = GetGridDataTable(yearStr, monthStr, type);
    //    UltraWebGrid1.DataBind();
    //}
    //private DataTable GetGridDataTable(string yearStr, string monthStr, string type)
    //{
    //    string query = GetQuery(yearStr, monthStr, type);

    //    dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
    //    DataSet ds = dbAgent.FillDataSet(query, "Data");
        
    //    return ds.Tables[0];
    //}
    private DataTable GetChartDataTable(string yearStr, string monthStr, string areaStr, string type) 
    {
        string query = GetQuery(yearStr, monthStr, areaStr, type);

        dbAgent             = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds          = dbAgent.FillDataSet(query, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        dataTable.Columns.Add("MONTH", typeof(string));
        dataTable.Columns.Add("MONTH_NAME", typeof(string));
        dataTable.Columns.Add("BUDGET", typeof(double));
        dataTable.Columns.Add("ACTUAL", typeof(double));
        dataTable.Columns.Add("RATE", typeof(double));

        for (int i = 1; i <= 12; i++)
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = i.ToString();
            dr["MONTH_NAME"] = i.ToString() + "월";
            dr["BUDGET"] = 0;
            dr["ACTUAL"] = 0;
            dr["RATE"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds.Tables[0].Select("C_MONTH = '" + i.ToString().PadLeft(2, '0') + "'");
            if (drCol.Length > 0)
            {
                dataTable.Rows[i]["BUDGET"] = double.Parse(drCol[0]["BUDGET"].ToString());
                dataTable.Rows[i]["ACTUAL"] = double.Parse(drCol[0]["ACTUAL"].ToString());
                dataTable.Rows[i]["RATE"] = double.Parse(drCol[0]["RATE"].ToString());
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
        string areaStr      = ddlArea.SelectedValue;
        string type         = ddlType.SelectedValue;
        
        BindingChart(Chart1, yearStr, monthStr, areaStr, type);
        //GridBinding(yearStr, monthStr, type);
    }
    private string GetQuery(string yearStr, string monthStr, string areaStr, string type)
    {
        string query = @"
                    SELECT  A.C_DADT, A.C_MONTH, A.C_DESC,
                            SUM(A.BUDGET) BUDGET, SUM(A.ACTUAL) ACTUAL,
                            ROUND(DECODE(SUM(A.BUDGET),0,0,ROUND((SUM(A.ACTUAL)/ SUM(A.BUDGET))*100, 2)),2) RATE
                      FROM (SELECT  BS.BS_DATE_T C_DADT, 
                                   SUBSTR(BS.BS_DATE_T, 5,2) C_MONTH,
                                   FIN.SEM_ACCOUNT4_DESC C_DESC,                                            -- 투자구분 명
                                   round(NVL(SUM(BS.BS_SUM_BUDGET_AMOUNT),0)/1000,0) BUDGET,                -- 예산 
                                   0 ACTUAL
                              FROM SEM_BALANCE_SHEET BS ,
                                   SEM_FINANCIAL_CODE_MASTER FIN
                             WHERE BS.BS_DATE_T BETWEEN '" + yearStr + @"01' and '" + yearStr + monthStr + @"'
                               AND FIN.SEM_FINANCIAL_CODE = 'BS'
                               AND FIN.SEM_ACCOUNT3_CODE in ('1303000000', '1305000000')
                               AND BS.BS_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE
                               AND BS.BS_ACCOUNT4_CODE_T = '" + type + @"'                            -- 입력 조건(투자구분) 
                             GROUP BY BS.BS_DATE_T,
                                   FIN.SEM_ACCOUNT4_DESC
                             UNION ALL
                           SELECT  CE.CAPEX_DATE_T C_DADT, 
                                   SUBSTR(CE.CAPEX_DATE_T, 5,2) C_MONTH,
                                   FIN.SEM_ACCOUNT4_DESC C_DESC,                                            -- 투자구분 명
                                   0 BUDGET,                  -- 예산 
                                   round(NVL(SUM(CE.CAPEX_ACTUAL_AMT),0)/1000,0) ACTUAL
                              FROM SEM_CAPEX_EXECUTE CE ,
                                   SEM_FINANCIAL_CODE_MASTER FIN
                             WHERE CE.CAPEX_DATE_T BETWEEN '" + yearStr + @"01' and '" + yearStr + monthStr + @"'
                               AND FIN.SEM_FINANCIAL_CODE = 'BS'
                               AND FIN.SEM_ACCOUNT3_CODE in ('1303000000', '1305000000')
                               AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE
                               AND CE.CAPEX_ACCOUNT4_CODE_T = '" + type + @"'                            -- 입력 조건(투자구분) 
                             GROUP BY CE.CAPEX_DATE_T,
                                   FIN.SEM_ACCOUNT4_DESC ) A
                      GROUP BY A.C_DADT, A.C_MONTH, A.C_DESC                      
                      
                      ";

        return query;
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
}
