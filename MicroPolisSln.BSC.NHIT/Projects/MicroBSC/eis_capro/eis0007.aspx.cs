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

public partial class est0007 : AppPageBase
{
    DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetDropDownListArea(ddlArea);

            string areaStr = ddlArea.SelectedValue;
            BindingChart(Chart1, areaStr);
            GridBinding();
        }
    }
    //private void SetDropDownListYear(System.Web.UI.WebControls.DropDownList ddlYear) 
    //{
    //    for (int i = System.DateTime.Now.Year; i >= 1999; i--) 
    //    {
    //        ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
    //    }
    //}
    private void SetDropDownListArea(System.Web.UI.WebControls.DropDownList ddlItem)
    {
        ddlArea.Items.Insert(0, new ListItem("전체", ""));
        ddlArea.Items.Insert(1, new ListItem("본사", "본사"));
        ddlArea.Items.Insert(2, new ListItem("울산", "울산"));
    }
    private void BindingChart(Dundas.Charting.WebControl.Chart chart, string areaStr)
    {
        string query_jikgub = GetJikGubQuery();

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds_jikgub = dbAgent.FillDataSet(query_jikgub, "Data");

        //chart.DataSource = GetChartDataTable(areaStr).DefaultView;

        DataTable dt = GetChartDataTable(areaStr);

        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 390
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series = null;
        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);

        for (int i = 0; i < ds_jikgub.Tables[0].Rows.Count; i++) 
        {
            series = DundasCharts.CreateSeries(chart, "Series" + i.ToString(), "Default", ds_jikgub.Tables[0].Rows[i]["JIKGUB_NM"].ToString(), null, SeriesChartType.StackedColumn, 1, GetChartColor(i), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            //series.ValueMembersY = "C_" + ds_jikgub.Tables[0].Rows[i]["JIKGUB_NM"].ToString();
            DatabaseBindingXY(series, "TEAM_NM", "C_" + ds_jikgub.Tables[0].Rows[i]["JIKGUB_NM"].ToString(), dt);
            series["DrawingStyle"] = "Cylinder";
            DundasAnimations.FadingAnimation(chart, series, 0.5 * i, 0.5 * (i + 1), false, false);
            series.ShowLabelAsValue = true;
            series.ToolTip = "#VALY{N0}";

            SetVisibleZeroLabelText(chart); 
        }
    }
    private DataTable GetChartDataTable(string areaStr)
    {
        string query            = GetQuery(areaStr);
        string query_jikgub     = GetJikGubQuery();
        string query_buseo      = GetTeamQuery(areaStr);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds          = dbAgent.FillDataSet(query, "Data");
        DataSet ds_jikgub   = dbAgent.FillDataSet(query_jikgub, "Data");
        DataSet ds_buseo    = dbAgent.FillDataSet(query_buseo, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr = null;

        dataTable.Columns.Add("TEAM_NM", typeof(string));

        for (int i = 0; i < ds_jikgub.Tables[0].Rows.Count; i++)
        {
            dataTable.Columns.Add("C_" + ds_jikgub.Tables[0].Rows[i]["JIKGUB_NM"].ToString(), typeof(double));
        }

        for (int i = 0; i < ds_buseo.Tables[0].Rows.Count; i++) 
        {
            dr = dataTable.NewRow();
            dr["TEAM_NM"] = ds_buseo.Tables[0].Rows[i]["TEAM_NM"].ToString();

            for (int j = 0; j < ds_jikgub.Tables[0].Rows.Count; j++)
            {
                dr["C_" + ds_jikgub.Tables[0].Rows[j]["JIKGUB_NM"].ToString()] = 0;
            }

            dataTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 0; i < ds_buseo.Tables[0].Rows.Count; i++) 
        {
            for (int j = 0; j < ds_jikgub.Tables[0].Rows.Count; j++)
            {
                drCol = ds.Tables[0].Select("TEAM_NM = '" + ds_buseo.Tables[0].Rows[i]["TEAM_NM"].ToString() + "' AND JIKGUB = '" + ds_jikgub.Tables[0].Rows[j]["JIKGUB_NM"].ToString() + "'");
                if (drCol.Length > 0)
                    dataTable.Rows[i]["C_" + ds_jikgub.Tables[0].Rows[j]["JIKGUB_NM"].ToString()] = Convert.ToDouble(drCol[0]["INWONSU"].ToString());
            }
        }

        return dataTable;
    }
    private string GetQuery(string areaStr)
    {

        string query = @"SELECT 
                                B.TEAM_NM, 
                                A.JIKGUB, 
                                SUM(A.INWONSU) AS INWONSU 
                           FROM CA_FT_INSA2 A,
			                    D_JOGIC2 B
	                      WHERE A.JOGIC_IDX = B.IN_IDX
                            AND (B.TEAM_NM LIKE '" + areaStr + @"%' OR '' = '" + areaStr + @"')
                         GROUP BY 
                               B.TEAM_NM, 
                               A.JIKGUB
                         ORDER BY 
                               B.TEAM_NM";

        return query;
    }
    private string GetTeamQuery(string areaStr) 
    {
        //string query = @"SELECT DISTINCT BUSEO FROM D_JOGIC WHERE (BUSEO LIKE '" + areaStr + "%' OR '' = '" + areaStr + "')";
        string query = @"SELECT TEAM_NM FROM D_JOGIC2 WHERE (TEAM_NM LIKE '" + areaStr + "%' OR '' = '" + areaStr + "')";
        return query;
    }
    private string GetJikGubQuery() 
    {
        string query = @"SELECT JIKGUB_NM FROM D_JIKGUB";
        return query;
    }

    // 그리드용 데이타테이블 반환
    private DataTable GetDTGrid()
    {
        DataTable dataTable = new DataTable();
        string query_jikgub = GetJikGubQuery();
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet ds_jikgub = dbAgent.FillDataSet(query_jikgub, "Data");
        DataTable dt_jikgub = ds_jikgub.Tables[0];
        DataTable dtTable = GetChartDataTable("");
        DataRow drNew = null;
        DataRow[] draDefault = null;

        dataTable.Columns.Add("구분", typeof(string));
        for (int i = 0; i < dt_jikgub.Rows.Count; i++)
        {
            dataTable.Columns.Add(dt_jikgub.Rows[i]["JIKGUB_NM"].ToString(), typeof(int));
        }
        dataTable.Columns.Add("총원", typeof(int));

        int iTmp = 0;
        int iSum = 0;
        drNew = dataTable.NewRow();
        drNew["구분"] = "전사";
        for (int i = 0; i < dt_jikgub.Rows.Count; i++)
        {
            draDefault = dtTable.Select();

            iTmp = 0;
            for (int k = 0; k < draDefault.Length; k++)
            {
                iTmp += Convert.ToInt32(draDefault[k][i + 1]);
            }
            drNew[i + 1] = iTmp;
            iSum += iTmp;
        }
        drNew["총원"] = iSum;
        dataTable.Rows.Add(drNew);


        int iTmp1 = 0;
        int iSum1 = 0;
        drNew = dataTable.NewRow();
        drNew["구분"] = "본사";
        for (int i = 0; i < dt_jikgub.Rows.Count; i++)
        {
            draDefault = dtTable.Select(
                                      "TEAM_NM LIKE '본사%'"
                                    );
            iTmp1 = 0;
            for (int k = 0; k < draDefault.Length; k++)
            {
                iTmp1 += Convert.ToInt32(draDefault[k][i + 1]);
            }
            drNew[i + 1] = iTmp1;
            iSum1 += iTmp1;
        }
        drNew["총원"] = iSum1;
        dataTable.Rows.Add(drNew);


        int iTmp2 = 0;
        int iSum2 = 0;
        drNew = dataTable.NewRow();
        drNew["구분"] = "울산";
        for (int i = 0; i < dt_jikgub.Rows.Count; i++)
        {
            draDefault = dtTable.Select(
                                      "TEAM_NM LIKE '울산%'"
                                    );
            iTmp2 = 0;
            for (int k = 0; k < draDefault.Length; k++)
            {
                iTmp2 += Convert.ToInt32(draDefault[k][i + 1]);
            }
            drNew[i + 1] = iTmp2;
            iSum2 += iTmp2;
        }
        drNew["총원"] = iSum2;
        dataTable.Rows.Add(drNew);

        return dataTable;
    }

    private void GridBinding()
    {
        UltraWebGrid1.DataSource = GetDTGrid();
        UltraWebGrid1.DataBind();
    }


    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string areaStr = ddlArea.SelectedValue;

        BindingChart(Chart1, areaStr);
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].Columns[0].Width = 75;
        for (int i = 1; i < UltraWebGrid1.Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.Bands[0].Columns[i].Width = 79;
        
        }
       


    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        for (int i = 1; i < UltraWebGrid1.Columns.Count; i++)
        {
            e.Row.Cells[i].Value += "&nbsp;&nbsp;";
        }
    }
}
