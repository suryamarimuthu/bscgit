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

public partial class eis_SEM_Empl_R006 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            ddlMonth.SelectedIndex = DateTime.Now.Month - 1;
            DataBindingObjects();
            rBtnGbn.Items.Add(new ListItem("월계", "1"));
            rBtnGbn.Items.Add(new ListItem("누계", "2"));
            rBtnGbn.SelectedIndex = 0;
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        /*
        double dblRate = 0.0;
        if (e.Row.Cells[0].Value.ToString() == "집행율(%)")
        {
            for (int i = 1; i < UltraWebGrid1.Bands[0].Columns.Count; i++)
            {
                dblRate = Convert.ToDouble(e.Row.Cells[i].Value);
                e.Row.Cells[i].Style.ForeColor = (dblRate > 99) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
            }
        }
        */
    }
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string yearStr, string monthStr, string type) 
    {
        string typeStr = "";
        chart.DataSource = GetChartDataTable(yearStr, monthStr, type).DefaultView;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(chart, "Series3", "Default", "집행율", null, SeriesChartType.Line, 3, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        if (type.Equals("1"))
            typeStr = "";
        else
            typeStr = "SUM_";

        series1.ValueMemberX = "MONTH";
        series1.ValueMembersY = "EMP_" + typeStr + "PLAN";
        series2.ValueMembersY = "EMP_" + typeStr + "ACTUAL";
        series3.ValueMembersY = "EMP_" + typeStr + "ACHIVE";

        series3.YAxisType = AxisType.Secondary;

        //series3.ValueMembersY = "T_" + Convert.ToString(int.Parse(yearStr) - 1);
        //series4.ValueMembersY = "T_40000";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 2.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 1.0, 3.0, true);
        DundasAnimations.GrowingAnimation(chart, series3, 0.5, 1.0, true);
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

        chart.ChartAreas["Default"].AxisY2.LabelStyle.Format = "P0";

    }
    private void GridBinding(string yearStr, string monthStr, string type)
    {
        UltraWebGrid1.DataSource = GetGridDataTable(yearStr, monthStr, type);
        UltraWebGrid1.DataBind();
    }
    private DataTable GetGridDataTable(string yearStr, string monthStr, string type)
    {
        string typeStr = "";

        if (type.Equals("1"))
            typeStr = "";
        else
            typeStr = "SUM_";

        string query = GetQuery(yearStr, type);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        
        dataTable.Columns.Add("GUBUN", typeof(string));

        for (int i = 1; i <= 12; i++) 
        {
            dataTable.Columns.Add("T_" + i.ToString(), typeof(double));
        }

        dr = dataTable.NewRow();
        dr["GUBUN"] = "계획";
        dataTable.Rows.Add(dr);
        dr = dataTable.NewRow();
        dr["GUBUN"] = "실적";
        dataTable.Rows.Add(dr);
        dr = dataTable.NewRow();
        dr["GUBUN"] = "집행율(%)";
        dataTable.Rows.Add(dr);

        for (int j = 0; j <= 2; j++) 
        {
            for (int i = 1; i <= 12; i++)
            {
                dataTable.Rows[j]["T_" + i.ToString()] = 0;
            }
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds.Tables[0].Select("MONTH = '" + i.ToString().PadLeft(2, '0') + "'");
            if (drCol.Length > 0)
                dataTable.Rows[0]["T_" + i.ToString()] = Convert.ToDouble(drCol[0]["EMP_" + typeStr + "PLAN"].ToString());
        }

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds.Tables[0].Select("MONTH = '" + i.ToString().PadLeft(2, '0') + "'");

            if (i <= int.Parse(monthStr)) 
            {
                if (drCol.Length > 0)
                    dataTable.Rows[1]["T_" + i.ToString()] = Convert.ToDouble(drCol[0]["EMP_" + typeStr + "ACTUAL"].ToString());
            }
        }

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds.Tables[0].Select("MONTH = '" + i.ToString().PadLeft(2, '0') + "'");

            if (i <= int.Parse(monthStr))
            {
                if (drCol.Length > 0)
                    dataTable.Rows[2]["T_" + i.ToString()] = Convert.ToDouble(drCol[0]["EMP_" + typeStr + "ACHIVE"].ToString());
            }
        }

        return dataTable;
    }
    private DataTable GetChartDataTable(string yearStr, string monthStr, string type) 
    {
        string query = GetQuery(yearStr, type);
//        string query_type = @"SELECT DISTINCT SEM_CODE3_T, SEM_CODE3_NAME FROM SEM_CODE_MASTER WHERE SEM_CODE1_T = '14' AND SEM_CODE3_T < '10006'";

        dbAgent             = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds          = dbAgent.FillDataSet(query, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("MONTH", typeof(string));
        dataTable.Columns.Add("EMP_DATE_T", typeof(string));
        dataTable.Columns.Add("EMP_PLAN", typeof(double));
        dataTable.Columns.Add("EMP_ACTUAL", typeof(double));
        dataTable.Columns.Add("EMP_ACHIVE", typeof(double));
        dataTable.Columns.Add("EMP_SUM_PLAN", typeof(double));
        dataTable.Columns.Add("EMP_SUM_ACTUAL", typeof(double));
        dataTable.Columns.Add("EMP_SUM_ACHIVE", typeof(double));

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = ds.Tables[0].Rows[i]["MONTH"].ToString();
            dr["EMP_DATE_T"] = ds.Tables[0].Rows[i]["EMP_DATE_T"].ToString();
            dr["EMP_PLAN"] = double.Parse(ds.Tables[0].Rows[i]["EMP_PLAN"].ToString());
            dr["EMP_SUM_PLAN"] = double.Parse(ds.Tables[0].Rows[i]["EMP_SUM_PLAN"].ToString());

            int rowMonth = int.Parse(ds.Tables[0].Rows[i]["MONTH"].ToString());
            int month = int.Parse(monthStr);

            if (rowMonth <= month)
            {
                dr["EMP_ACTUAL"] = double.Parse(ds.Tables[0].Rows[i]["EMP_ACTUAL"].ToString());
                dr["EMP_ACHIVE"] = double.Parse(ds.Tables[0].Rows[i]["EMP_ACHIVE"].ToString());
                dr["EMP_SUM_ACTUAL"] = Math.Round(double.Parse(ds.Tables[0].Rows[i]["EMP_SUM_ACTUAL"].ToString()),1);
                dr["EMP_SUM_ACHIVE"] = Math.Round(double.Parse(ds.Tables[0].Rows[i]["EMP_SUM_ACHIVE"].ToString()),1);
            }
            else 
            {
                dr["EMP_ACTUAL"] = 0;
                dr["EMP_ACHIVE"] = 0;
                dr["EMP_SUM_ACTUAL"] = 0;
                dr["EMP_SUM_ACHIVE"] = 0;
            }

            dataTable.Rows.Add(dr);
        }

        return dataTable;
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        string yearStr  = ddlYear.SelectedValue;
        string monthStr = ddlMonth.SelectedValue;
        string type     = rBtnGbn.SelectedValue;
        
        BindingChart(Chart1, yearStr, monthStr, type);
        GridBinding(yearStr, monthStr, type);
    }
    private string GetQuery(string yearStr, string type)
    {
        string query = @"
                SELECT SUBSTR(BUDG.EMP_DATE_T, 5, 2) MONTH,
                       BUDG.EMP_DATE_T,
                       SUM(BUDG.EMP_PLAN)/1000       EMP_PLAN,
                       SUM(BUDG.EMP_ACTUAL)/1000     EMP_ACTUAL,
                       ROUND(DECODE(SUM(BUDG.EMP_PLAN),0,0,ROUND((SUM(BUDG.EMP_ACTUAL)/ SUM(BUDG.EMP_PLAN))*100, 2))) AS EMP_ACHIVE, 
                       SUM(BUDG.EMP_SUM_PLAN)/1000   EMP_SUM_PLAN,
                       SUM(BUDG.EMP_SUM_ACTUAL)/1000 EMP_SUM_ACTUAL,
                       ROUND(DECODE(SUM(BUDG.EMP_SUM_PLAN),0,0,ROUND((SUM(BUDG.EMP_SUM_ACTUAL)/ SUM(BUDG.EMP_SUM_PLAN))*100, 2))) AS EMP_SUM_ACHIVE 
                  FROM SEM_EDUCATION_BUDGET BUDG
                 WHERE BUDG.EMP_DATE_T like '" + yearStr + @"%'
                 GROUP BY BUDG.EMP_DATE_T ORDER BY MONTH";
        
        return query;
    }
}
