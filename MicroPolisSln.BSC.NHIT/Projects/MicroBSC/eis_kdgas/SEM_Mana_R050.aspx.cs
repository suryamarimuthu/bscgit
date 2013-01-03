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

public partial class eis_SEM_Mana_R050 : EISPageBase
{
    private DBAgent dbAgent = null;

    public DataTable CODE_TABLE
    {
        get
        {
            if (ViewState["CODE_TABLE"] == null)
            {
                ViewState["CODE_TABLE"] = this.GetCodeTable();
            }
            return (DataTable)ViewState["CODE_TABLE"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            this.GridBinding();
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }

    private void BindingChart(Dundas.Charting.WebControl.Chart chart, DataTable dtData)
    {
        DundasCharts.DundasChartBase(chart, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        DataTable dt = this.CODE_TABLE;
        int iRow = dt.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            Series ser = DundasCharts.CreateSeries(chart, "ser"+i.ToString(), "Default", dt.Rows[i][1].ToString(), null, SeriesChartType.Line, 3
                                                  ,GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64)
                                                  );
            ser.MarkerStyle   = GetMarkerStyle(i);
            ser.MarkerColor   = GetMarkerColor(i);
            ser.MarkerBorderColor = GetMarkerBorderColor(i);
            ser.ValueMembersY = dt.Rows[i][0].ToString();

            if (i == 0)
            {
                ser.ValueMemberX = "YY";
            }
        }

        chart.DataSource = dtData;
        chart.DataBind();
    }

    public void SetGridHeader()
    {
        int iRow = UltraWebGrid1.Columns.Count;
        for (int i = iRow; i > 0; i--)
        {
            UltraWebGrid1.Columns.RemoveAt(iRow);
        }
        UltraWebGrid1.ResetColumns();


        DataTable dtCol = this.CODE_TABLE;
        iRow = dtCol.Rows.Count;

        UltraGridColumn cn = null;
        cn = new UltraGridColumn("YY", "년도", ColumnType.NotSet, "");
        cn.BaseColumnName = "YY";
        cn.Width = Unit.Pixel(120);
        cn.CellStyle.HorizontalAlign = HorizontalAlign.Center;
        UltraWebGrid1.Columns.Add(cn);

        for (int i = 0; i < iRow; i++)
        {
            cn = new UltraGridColumn(dtCol.Rows[i][0].ToString(), dtCol.Rows[i][1].ToString(), ColumnType.NotSet, 0);
            cn.BaseColumnName = dtCol.Rows[i][0].ToString();
            cn.Width = Unit.Pixel(165);
            cn.DataType = "System.Double";
            cn.Format = "#,###,###,###,###,###,###,###,###,##0.00";
            cn.CellStyle.HorizontalAlign = HorizontalAlign.Right;
            UltraWebGrid1.Columns.Add(cn);
        }
    }

    private void GridBinding()
    {
        this.SetGridHeader();
        DataTable rDt = GetDataTable();

        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = rDt.DefaultView;
        UltraWebGrid1.DataBind();

        this.BindingChart(Chart1, rDt);
    }
    private DataTable GetDataTable(string yearStr) 
    {
        string query1 = GetChartQuery(yearStr);
        int startYear = int.Parse(yearStr) - 4;

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds1 = dbAgent.FillDataSet(query1, "Data");

        DataTable gridTable = new DataTable();
        DataRow dr = null;
        gridTable.Columns.Add("T_DATE", typeof(string));
        gridTable.Columns.Add("T_10000", typeof(double));
        gridTable.Columns.Add("T_20000", typeof(double));
        gridTable.Columns.Add("T_30000", typeof(double));
        gridTable.Columns.Add("T_40000", typeof(double));

        for (int i = startYear; i < startYear + 5; i++)
        {
            dr = gridTable.NewRow();
            dr["T_DATE"] = i.ToString();
            dr["T_10000"] = 0;
            dr["T_20000"] = 0;
            dr["T_30000"] = 0;
            dr["T_40000"] = 0;
            gridTable.Rows.Add(dr);
        }

        DataRow[] drCol = null;

        for (int i = 0; i < gridTable.Rows.Count; i++)
        {
            for (int j = 10000; j < 50000; j += 10000)
            {
                drCol = ds1.Tables[0].Select("T_DATE = '" + gridTable.Rows[i]["T_DATE"].ToString()
                    + "' AND T_GUBN = '" + j.ToString() + "'");
                if (drCol.Length > 0)
                    gridTable.Rows[i]["T_" + j.ToString()] = Convert.ToDouble(drCol[0]["DATA"].ToString());
            }
        }

        return gridTable;
    }

    private DataTable GetDataTable()
    {
        string sYY       = ddlYear.SelectedValue;
        DataTable dtCode = this.CODE_TABLE;
        DataTable dtCol  = new DataTable("COLUMN");
        dtCol.Columns.Add("YY");

        int iRow = dtCode.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            dtCol.Columns.Add(dtCode.Rows[i][0].ToString(), typeof(double));
        }

        DataRow rCd = null;

        DataSet dsRaw = gDbAgent.Fill(this.GetChartQuery(sYY));
        iRow = dsRaw.Tables[0].Rows.Count;
        string sCode = "";
        string sYY_OLD = "";
        string sYY_NEW = "";
        rCd = dtCol.NewRow();
        for (int i = 0; i < iRow; i++)
        {
            
            sCode     = dsRaw.Tables[0].Rows[i]["T_GUBN"].ToString();

            if (i == (iRow - 1))
            {
                sYY_OLD = dsRaw.Tables[0].Rows[i]["T_DATE"].ToString();
                sYY_NEW = sYY_OLD;
            }
            else
            {
                sYY_OLD = dsRaw.Tables[0].Rows[i]["T_DATE"].ToString();
                sYY_NEW = dsRaw.Tables[0].Rows[i + 1]["T_DATE"].ToString();
            }

            if (i==0 || (sYY_OLD != sYY_NEW))
            {
                
            }

            rCd["YY"]  = dsRaw.Tables[0].Rows[i]["T_DATE"].ToString();
            rCd[sCode] = dsRaw.Tables[0].Rows[i]["DATA"].ToString();

            if (sYY_OLD != sYY_NEW)
            {
                dtCol.Rows.Add(rCd);
                rCd = dtCol.NewRow();
            }
        }

        if (iRow > 0)
        {
            dtCol.Rows.Add(rCd);
        }

        return dtCol;
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.GridBinding();
    }

    private string GetChartQuery(string yearStr)
    {
        string query = @"
                     SELECT SEM_CODE_MASTER.SEM_CODE2_NAME T_NAME,         
                            SEM_CUSTOMER_CST.CST_DATE_T T_DATE,
                            ('T_'||SEM_CUSTOMER_CST.CST_GUBN_T) AS T_GUBN,
                            ROUND(SUM(SEM_CUSTOMER_CST.CST_GRADE),1) DATA
                       FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                            SEM_CUSTOMER_CST SEM_CUSTOMER_CST
                      WHERE SEM_CODE_MASTER.SEM_CODE1_T = '14'
                        AND SEM_CUSTOMER_CST.CST_GUBN_T = SEM_CODE_MASTER.SEM_CODE2_T
                        AND SEM_CUSTOMER_CST.CST_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                        AND SEM_CUSTOMER_CST.CST_DATE_T BETWEEN '" + Convert.ToString(int.Parse(yearStr) - 4) + @"' AND '" + Convert.ToString(int.Parse(yearStr)) + @"'
                      GROUP BY SEM_CODE_MASTER.SEM_CODE2_NAME,
                            SEM_CUSTOMER_CST.CST_DATE_T,
                            SEM_CUSTOMER_CST.CST_GUBN_T
                      ORDER BY T_DATE, T_GUBN";
        return query;
    }

    private DataTable GetCodeTable()
    {
        string query = @"
                          SELECT ('T_'||SEM_CODE2_T) AS CODE_ID, sem_code2_name AS CODE_NM 
                            FROM sem_code_master 
                           WHERE SEM_CODE1_T = '14'
                        ";

        DataSet rDs = gDbAgent.Fill(query);
        return rDs.Tables[0];
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
}
