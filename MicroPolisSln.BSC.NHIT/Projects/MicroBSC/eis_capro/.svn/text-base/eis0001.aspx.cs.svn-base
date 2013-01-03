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
using System.Data.SqlClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroBSC.Data;
using MicroCharts;

public partial class est0001 : AppPageBase
{
    DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetDropDownListYear(ddlYear);
            SetDropDownListItem(ddlItem);
            SetDropDownListGongJang(ddlGongJang);

            string sGongjang    = ddlGongJang.SelectedValue;
            string yearStr      = ddlYear.SelectedValue;
            string util         = ddlItem.SelectedValue;

            BindingChart(Chart1, yearStr, util, sGongjang);
            UltraWebGrid1.DataSource = GetGridDataTable(yearStr, util, sGongjang);
            UltraWebGrid1.DataBind();
        }
    }

    private void SetDropDownListGongJang(System.Web.UI.WebControls.DropDownList ddlGongJang)
    {
        string query = @"SELECT DISTINCT GO_IDX, GONGJANG FROM D_GONGJANG";
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        ddlGongJang.DataSource = ds;
        ddlGongJang.DataValueField = "GO_IDX";
        ddlGongJang.DataTextField = "GONGJANG";
        ddlGongJang.DataBind();

        ddlGongJang.Items.Insert(0, new ListItem("전체", "0"));
    
    
        
    }

    private void SetDropDownListYear(System.Web.UI.WebControls.DropDownList ddlYear) 
    {
        for (int i = System.DateTime.Now.Year; i >= 1999; i--) 
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void SetDropDownListItem(System.Web.UI.WebControls.DropDownList ddlItem)
    {
        string query = @"SELECT DISTINCT ITMU_IDX, ITMU_NAME FROM D_ITEM_UTIL";
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        ddlItem.DataSource = ds;
        ddlItem.DataValueField = "ITMU_IDX";
        ddlItem.DataTextField = "ITMU_NAME";
        ddlItem.DataBind();

        ddlItem.Items.Insert(0, new ListItem("전체", "0"));

    }
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string yearStr, string util, string sGongjang)
    {
        //chart.DataSource = GetChartDataTable(yearStr, util).DefaultView;
        // Code -> 1:  전기 : 2, 고압증기 : 3, 중압증기

        DataTable dt = GetChartDataTable(yearStr, util, sGongjang);

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 255
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series2 = DundasCharts.CreateSeries(chart, "Series2", "Default", "사용요금", null, SeriesChartType.Column, 3, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series1 = DundasCharts.CreateSeries(chart, "Series1", "Default", "사용량", null, SeriesChartType.Line, 3, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series3 = DundasCharts.CreateSeries(chart, "Series3", "Default", "중압증기", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0xD7, 0x41, 0x01),Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series4 = DundasCharts.CreateSeries(chart, "Series4", "Default", "협력업체", null, SeriesChartType.Line, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        //series1.ValueMemberX = "MONTH";
        //series1.ValueMembersY = "USEQTY";
        //series2.ValueMembersY = "AMT2";
        DatabaseBindingXY(series2, "MONTH", "AMT3", dt);
        DatabaseBindingXY(series1, "MONTH", "USEQTY", dt);

        series2.YAxisType = AxisType.Secondary;

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        //series2.ToolTip = "X value \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";
 
        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series2, 0.0, 3.0, false);
        DundasAnimations.GrowingAnimation(chart, series1, 3.0, 4.0, true);

        
        chart.Titles[0].Position.Auto = false;
        FontStyle fontStyle = FontStyle.Bold;
        chart.ChartAreas["Default"].Axes[0].Title = ddlGongJang.SelectedItem.Text;
        chart.ChartAreas["Default"].Axes[0].TitleFont = new Font("Trebuchet MS", 12, fontStyle);


        //Chart1.ChartAreas["Default"].Axes[int.Parse( Position.SelectedItem.Value )].TitleFont = new Font(Font1.SelectedItem.Text, float.Parse(TitleSize.SelectedItem.Text), fontStyle);



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
        //series1.ShowLabelAsValue = true;
        //series2.ShowLabelAsValue = true;
        //series3.ShowLabelAsValue = true;

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";
        chart.ChartAreas["Default"].AxisY2.LabelStyle.Format = "N0";

        SetVisibleZeroPoint(chart, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));
        //BindingToolTip(chart);
    }

    protected void SetZeroPoint(Chart chart, int iYear)
    {
        DateTime date = System.DateTime.Now;
        for (int i = 0; i < chart.Series.Count; i++)
        {
            for (int j = 0; j < chart.Series[i].Points.Count; j++)
            {
                //series2.Points[i].ShowLabelAsValue = true;

                if (chart.Series[i].Points[j].GetValueY(0) == 0 && date.Year == iYear)
                {
                    chart.Series[i].Points[j].Color = Color.Transparent;
                    chart.Series[i].Points[j].BorderColor = Color.Transparent;
                    chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
                    //chart.Series[i].Points[j].BorderWidth = 1;
                }
            }
        }
    }

    private DataTable GetChartDataTable(string yearStr, string util, string sGongjang)
    {
        string query = GetChartQuery(yearStr, util, sGongjang);
        //string query_item = @"SELECT DISTINCT ITMU_IDX, ITMU_NAME FROM D_ITEM_UTIL";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        //DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("MONTH", typeof(string));
        dataTable.Columns.Add("USEQTY", typeof(double));
        dataTable.Columns.Add("AMT3", typeof(double));

        for (int j = 1; j <= 12; j++)
        {
            dr = dataTable.NewRow();
            dr["MONTH"] = j.ToString();
            dr["USEQTY"] = 0;
            dr["AMT3"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 1; i <= 12; i++)
        {
            drCol = ds.Tables[0].Select("yyyy_mm = '" + yearStr + i.ToString().PadLeft(2, '0') + "'");
            if (drCol.Length > 0)
            {
                dataTable.Rows[i - 1]["USEQTY"] = Convert.ToDouble(drCol[0]["USEQTY"].ToString());
                dataTable.Rows[i - 1]["AMT3"] = Convert.ToDouble(drCol[0]["AMT3"].ToString());
            }
        }

        return dataTable;
    }
    private DataTable GetGridDataTable(string yearStr, string util, string sGongjang)
    {
        string query = GetGridQuery(yearStr, util, sGongjang);
        string query_item = @"SELECT DISTINCT ITMU_IDX, ITMU_NAME FROM D_ITEM_UTIL WHERE (ITMU_IDX = " + util + " OR 0 = " + util + ")"; ;

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        DataSet ds_item = dbAgent.FillDataSet(query_item, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("ITMU_NAME", typeof(string));
        dataTable.Columns.Add("ITMU_TYPE", typeof(string));


        for (int i = 1; i <= 12; i++)
        {
            dataTable.Columns.Add("C_" + i.ToString(), typeof(double));
        }
        dataTable.Columns.Add("년간합계", typeof(double));

        for (int i = 0; i < ds_item.Tables[0].Rows.Count; i++)
        {
            for (int j = 0; j < 2; j++) 
            {
                dr = dataTable.NewRow();
                dr["ITMU_NAME"] = ds_item.Tables[0].Rows[i]["ITMU_NAME"].ToString();
                dr["ITMU_TYPE"] = GetType(j);

                for (int k = 1; k <= 12; k++)
                {
                    dr["C_" + k.ToString()] = 0;
                }

                dataTable.Rows.Add(dr);
            }
        }

        DataRow[] drCol = null;

        for (int i = 0; i < ds_item.Tables[0].Rows.Count; i++)
        {
            for (int j = 1; j <= 12; j++)
            {
                drCol = ds.Tables[0].Select("yyyy_mm = '" + yearStr + j.ToString().PadLeft(2, '0') + "' AND ITMU_IDX = '" + ds_item.Tables[0].Rows[i]["ITMU_IDX"].ToString() + "'");
                if (drCol.Length > 0) 
                {
                    dataTable.Rows[i + (i * 1)]["C_" + j.ToString()]        = Convert.ToDouble(drCol[0]["USEQTY"].ToString());
                    dataTable.Rows[i + (i * 1) + 1]["C_" + j.ToString()]    = Convert.ToDouble(drCol[0]["AMT3"].ToString());
                }

            }
        }

      
        return dataTable;
    }
    private string GetType(int i) 
    {
        if (i.ToString() == "0") 
            return "사용량";
        else if (i.ToString() == "1")
            return "사용요금";

        return "";
    }
    private string GetChartQuery(string yearStr, string util, string sGongjang)
    {
        
        string query = @"   SELECT  D.yyyy_mm, 
	                                SUM(USEQTY) USEQTY, 
                                    CONVERT(bigint,SUM(AMT3)) AMT3 
                              FROM  CA_FT_UTIL A, 
                                    D_ITEM_UTIL C,
                                    D_TIME_ILJA D
	                          WHERE A.ITEM_IDX = C.ITMU_IDX
	                                AND (A.ITEM_IDX = " + util + @" OR 0 = " + util + @")
	                                AND A.ILJA_IDX = D.TM_IDX
	                                AND SUBSTRING(CONVERT(varchar, yyyy_mm), 1, 4) = '" + yearStr + @"'
	                                AND  (A.GONGJANG_IDX=" + sGongjang + @" OR 0 = " + sGongjang + @")
		                      GROUP BY D.yyyy_mm";
        return query;
    }
    private string GetGridQuery(string yearStr, string util, string sGongjang)
    {
        
        string query = @"SELECT D.yyyy_mm, 
                                C.ITMU_IDX, 
                                ITMU_NAME, 
                                CONVERT(bigint,SUM(USEQTY)) USEQTY, 
                                CONVERT(bigint,SUM(AMT3)) AMT3 
                           FROM CA_FT_UTIL A, 
                                D_ITEM_UTIL C,
                                D_TIME_ILJA D
	                      WHERE (A.GONGJANG_IDX=" + sGongjang + @" OR 0 = " + sGongjang + @")
	                            AND A.ITEM_IDX = C.ITMU_IDX
                                AND (A.ITEM_IDX = " + util + @" OR 0 = " + util + @")
	                            AND A.ILJA_IDX = D.TM_IDX
	                            AND SUBSTRING(CONVERT(varchar, yyyy_mm), 1, 4) = '" + yearStr + @"'
                       GROUP BY yyyy_mm, C.ITMU_IDX, ITMU_NAME";

        return query;
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string yearStr = ddlYear.SelectedValue;
        string util = ddlItem.SelectedValue;
        string sGongJang = ddlGongJang.SelectedValue;
        BindingChart(Chart1, yearStr, util, sGongJang);

        UltraWebGrid1.DataSource = GetGridDataTable(yearStr, util, sGongJang);
        UltraWebGrid1.DataBind();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView  dr = (DataRowView)e.Data;
        double dSum = 0;
        for (int i = 2; i < 14; i++)
        {
            dSum += Convert.ToDouble(e.Row.Cells[i].Value.ToString());
        }
        e.Row.Cells[14].Value = dSum;


        if (e.Row.Cells[1].Value.ToString().Equals("사용량"))
        {
            if (e.Row.Cells[0].Value.ToString().Equals("전기"))
            {
                e.Row.Cells[1].Value += "  (kWH)";
            }
            else
            {
                e.Row.Cells[1].Value += "  (TON)";
            }
        }
        
        
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].Columns[0].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP1);
        e.Layout.Bands[0].Columns[1].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP2);

        e.Layout.Bands[0].Columns[0].MergeCells = true;
        e.Layout.Bands[0].Columns[14].Format = "#,##0.##";
       
    }
    

    protected void Chart1_DataBound(object sender, EventArgs e)
    {

    }

    protected void Chart1_PreRender(object sender, EventArgs e)
    {

    }
}
