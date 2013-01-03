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

public partial class eis_SEM_Mana_R045 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            int cYear = DateTime.Now.Year;
            int cMont = DateTime.Now.Month;
            string strItemYY = "";
            string strNameYY = "";
            ddlYear.Items.Clear();

            for (int i = cYear; i >= 2000; i--)
            {
                strItemYY = i.ToString();
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

                if (i == cYear)
                {
                    this.ddlYear.SelectedValue = i.ToString();
                }
            }

            this.ddlHalf.Items.Add(new ListItem("상반기", "1"));
            this.ddlHalf.Items.Add(new ListItem("하반기", "2"));
            this.ddlHalf.SelectedValue = (cMont < 7) ? "1" : "2";


            DataBindingObjects();
        }
    }
    //private DataTable GetType() 
    //{
    //    string query = @"SELECT SEM_CODE2_T, SEM_CODE2_NAME FROM SEM_CODE_MASTER WHERE SEM_CODE1_T = '11'";
    //    dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
    //    DataSet ds = dbAgent.FillDataSet(query, "Data");
    //    return ds.Tables[0];
    //}
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        int cYear = int.Parse(ddlYear.SelectedValue.Substring(0, 4));
        int pYear = cYear - 1;

        e.Row.Cells.FromKey("T_1").Value = dr["T_" + pYear + "_1"].ToString();
        e.Row.Cells.FromKey("T_2").Value = dr["T_" + pYear + "_2"].ToString();
        e.Row.Cells.FromKey("T_3").Value = dr["T_" + cYear + "_3"].ToString();
        e.Row.Cells.FromKey("T_4").Value = dr["T_" + cYear + "_4"].ToString();

        e.Row.Band.Columns.FromKey("T_1").Header.Caption = pYear.ToString() + "년 상반기";
        e.Row.Band.Columns.FromKey("T_2").Header.Caption = pYear.ToString() + "년 하반기";
        e.Row.Band.Columns.FromKey("T_3").Header.Caption = cYear.ToString() + "년 상반기";
        e.Row.Band.Columns.FromKey("T_4").Header.Caption = cYear.ToString() + "년 하반기";
    }
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string yearStr)
    {
        //DataSet ds = GetDataSet(GetChartQuery(yearStr));
        chart.DataSource = GetDataTable(yearStr).DefaultView;
       
        int cYear = int.Parse(yearStr.Substring(0, 4));
        int pYear = cYear - 1;

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", pYear.ToString() + "상반기", null, SeriesChartType.Line, 3, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", pYear.ToString() + "하반기", null, SeriesChartType.Line, 3, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(chart, "Series3", "Default", cYear.ToString() + "상반기", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", cYear.ToString() + "하반기", null, SeriesChartType.Line, 3, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "SEM_CODE2_NAME";
        series1.ValueMembersY = "T_" + pYear + "_1";
        series2.ValueMembersY = "T_" + pYear + "_2";
        series3.ValueMembersY = "T_" + cYear + "_3";
        series4.ValueMembersY = "T_" + cYear + "_4";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.0, 2.0, false);
        DundasAnimations.GrowingAnimation(chart, series2, 2.0, 3.0, true);
        DundasAnimations.GrowingAnimation(chart, series3, 3.0, 5.0, true);
        DundasAnimations.GrowingAnimation(chart, series4, 5.0, 6.0, true);

        series1.MarkerStyle = MarkerStyle.Circle;
        series2.MarkerStyle = MarkerStyle.Diamond;
        series3.MarkerStyle = MarkerStyle.Triangle;
        series4.MarkerStyle = MarkerStyle.Square;
        series1.MarkerColor = Color.FromArgb(0x7A, 0x9D, 0xFE);
        series2.MarkerColor = Color.FromArgb(0xFF, 0xAA, 0x20);
        series3.MarkerColor = Color.FromArgb(0x20, 0xE4, 0xEB);
        series4.MarkerColor = Color.FromArgb(0xE4, 0xE4, 0xE4);
        series1.MarkerBorderColor = Color.FromArgb(0x4A, 0x58, 0x7E);
        series2.MarkerBorderColor = Color.FromArgb(0xD7, 0x41, 0x01);
        series3.MarkerBorderColor = Color.FromArgb(0x00, 0xC4, 0xCB);
        series4.MarkerBorderColor = Color.FromArgb(0xE4, 0xE4, 0xE4);
    }
    private DataTable GetDataTable(string yearStr)
    {
        string query = GetChartQuery(yearStr);
        int cYear = int.Parse(yearStr.Substring(0, 4));
        int pYear = cYear - 1;

        string query_type = @"SELECT SEM_CODE2_T, SEM_CODE2_NAME FROM SEM_CODE_MASTER WHERE SEM_CODE1_T = '11'";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds      = dbAgent.FillDataSet(query, "Data");
        DataSet ds_type = dbAgent.FillDataSet(query_type, "Data");

        //DataGrid1.DataSource = ds;
        //DataGrid1.DataBind();

        DataTable dataTable = new DataTable();
        DataRow dr = null;
        //gridTable.Columns.Add("SEM_CODE2_T", typeof(string));
        dataTable.Columns.Add("SEM_CODE2_T", typeof(string));
        dataTable.Columns.Add("SEM_CODE2_NAME", typeof(string));
        dataTable.Columns.Add("T_" + pYear + "_1", typeof(double));
        dataTable.Columns.Add("T_" + pYear + "_2", typeof(double));
        dataTable.Columns.Add("T_" + cYear + "_3", typeof(double));
        dataTable.Columns.Add("T_" + cYear + "_4", typeof(double));

        for (int i = 0; i < ds_type.Tables[0].Rows.Count; i++)
        {
            dr = dataTable.NewRow();
            dr["SEM_CODE2_T"]       = ds_type.Tables[0].Rows[i]["SEM_CODE2_T"].ToString();
            dr["SEM_CODE2_NAME"]    = ds_type.Tables[0].Rows[i]["SEM_CODE2_NAME"].ToString();
            dr["T_" + pYear + "_1"] = 0;
            dr["T_" + pYear + "_2"] = 0;
            dr["T_" + cYear + "_3"] = 0;
            dr["T_" + cYear + "_4"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 2; i++)
        {
            for (int j = 0; j < ds_type.Tables[0].Rows.Count; j++)
            {
                drCol = ds.Tables[0].Select("CUST_CENTER_CODE_T = '" + dataTable.Rows[j]["SEM_CODE2_T"].ToString() + "' AND TIME_TYPE = '" + i.ToString() + "'");
                if (drCol.Length > 0)
                    dataTable.Rows[j]["T_" + pYear + "_" + i.ToString()] = Convert.ToDouble(drCol[0]["CUST_GRADE"].ToString());
            }
        }
        for (int i = 3; i <= 4; i++)
        {
            for (int j = 0; j < ds_type.Tables[0].Rows.Count; j++)
            {
                drCol = ds.Tables[0].Select("CUST_CENTER_CODE_T = '" + dataTable.Rows[j]["SEM_CODE2_T"].ToString() + "' AND TIME_TYPE = '" + i.ToString() + "'");
                if (drCol.Length > 0)
                    dataTable.Rows[j]["T_" + cYear + "_" + i.ToString()] = Convert.ToDouble(drCol[0]["CUST_GRADE"].ToString());
            }
        }

        return dataTable;
    }
    private void GridBinding(string yearStr)
    {
        UltraWebGrid1.DataSource = GetDataTable(yearStr);
        UltraWebGrid1.DataBind();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        string yearStr  = ddlYear.SelectedValue + ddlHalf.SelectedValue;
        BindingChart(Chart1, yearStr);
        GridBinding(yearStr);
    }
    private string GetChartQuery(string yearStr)
    {
        int cYear = int.Parse(yearStr.Substring(0, 4));
        int pYear = cYear - 1;

        string hYear = yearStr.Substring(4, 1);

        string query = @"  SELECT '1' TIME_TYPE,
                                    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                    SEM_CODE_MASTER.SEM_CODE2_NAME,
                                    ROUND(AVG(SEM_CUSTOMER_CENTER.CUST_GRADE),2) CUST_GRADE
                                        FROM    SEM_CUSTOMER_CENTER SEM_CUSTOMER_CENTER,
                                                SEM_CODE_MASTER SEM_CODE_MASTER
                                            WHERE SEM_CUSTOMER_CENTER.CUST_DATE_T >= '" + pYear + @"01'AND SEM_CUSTOMER_CENTER.CUST_DATE_T <= '" + pYear + @"06'
                                                AND SEM_CODE_MASTER.SEM_CODE1_T = '11'
                                                AND SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                                    GROUP BY    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                                                SEM_CODE_MASTER.SEM_CODE2_NAME
                            UNION                                    
                            SELECT '2' TIME_TYPE,
                                    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                    SEM_CODE_MASTER.SEM_CODE2_NAME,
                                    ROUND(AVG(SEM_CUSTOMER_CENTER.CUST_GRADE),2) CUST_GRADE
                                        FROM    SEM_CUSTOMER_CENTER SEM_CUSTOMER_CENTER,
                                                SEM_CODE_MASTER SEM_CODE_MASTER
                                            WHERE SEM_CUSTOMER_CENTER.CUST_DATE_T >= '" + pYear + @"07'AND SEM_CUSTOMER_CENTER.CUST_DATE_T <= '" + pYear + @"12'
                                                AND SEM_CODE_MASTER.SEM_CODE1_T = '11'
                                                AND SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                                    GROUP BY    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                                                SEM_CODE_MASTER.SEM_CODE2_NAME
                            UNION                                    
                            SELECT '3' TIME_TYPE,
                                    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                    SEM_CODE_MASTER.SEM_CODE2_NAME,
                                    ROUND(AVG(SEM_CUSTOMER_CENTER.CUST_GRADE),2) CUST_GRADE
                                        FROM    SEM_CUSTOMER_CENTER SEM_CUSTOMER_CENTER,
                                                SEM_CODE_MASTER SEM_CODE_MASTER
                                            WHERE SEM_CUSTOMER_CENTER.CUST_DATE_T >= '" + cYear + @"01'AND SEM_CUSTOMER_CENTER.CUST_DATE_T <= '" + cYear + @"06'
                                                AND SEM_CODE_MASTER.SEM_CODE1_T = '11'
                                                AND SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                                    GROUP BY    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                                                SEM_CODE_MASTER.SEM_CODE2_NAME     
                            UNION                                    
                            SELECT '4' TIME_TYPE,
                                    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                    SEM_CODE_MASTER.SEM_CODE2_NAME,
                                    ROUND(AVG(SEM_CUSTOMER_CENTER.CUST_GRADE),2) CUST_GRADE
                                        FROM    SEM_CUSTOMER_CENTER SEM_CUSTOMER_CENTER,
                                                SEM_CODE_MASTER SEM_CODE_MASTER
                                            WHERE SEM_CUSTOMER_CENTER.CUST_DATE_T >= '" + cYear + @"07'AND SEM_CUSTOMER_CENTER.CUST_DATE_T <= '" + cYear + @"12'
                                                AND SEM_CODE_MASTER.SEM_CODE1_T = '11'
                                                AND SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                                    GROUP BY    SEM_CUSTOMER_CENTER.CUST_CENTER_CODE_T,
                                                                SEM_CODE_MASTER.SEM_CODE2_NAME
        ";

        return query;
    }
}
