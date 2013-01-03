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

public partial class eis_SEM_Mana_R051 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            SetTypeDropDownList(ddlType);
            setGridData();
        }
    }

    public void SetTypeDropDownList(System.Web.UI.WebControls.DropDownList ddList)
    {
        string query = @"SELECT DISTINCT SEM_CODE2_T, SEM_CODE2_NAME
                           FROM SEM_CODE_MASTER
                          WHERE SEM_CODE1_T = '14'";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        ddList.Items.Clear();
        ddList.DataSource = ds;
        ddList.DataTextField = "SEM_CODE2_NAME";
        ddList.DataValueField = "SEM_CODE2_T";
        ddList.DataBind();
    }

    private string GetTypeQuery(string type)
    {
        string query = @" SELECT SEM_CODE3_T, 
                                 SEM_CODE3_NAME 
                            FROM SEM_CODE_MASTER
                           WHERE SEM_CODE1_T = '14' 
                             AND SEM_CODE2_T = '" + type + @"' ";
        return query;
    }

    private void setGridData()
    {
        string sqlCD = GetTypeQuery(ddlType.SelectedValue);
        string sYear = Convert.ToString(int.Parse(this.ddlYear.SelectedValue) - 2);
        string eYear = ddlYear.SelectedValue.ToString();

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(sqlCD, "Data");

        string sqlHD = "";
        string sqlDT = "";
        string strQN = "\"";
        int intRow = 0;
        string strCD = "";
        string strNM = "";

        intRow = ds.Tables[0].Rows.Count;
        sqlHD = "";
        sqlDT = "";
        

        for (int i = 0; i < intRow; i++)
        {
            strCD = ds.Tables[0].Rows[i][0].ToString();
            strNM = ds.Tables[0].Rows[i][1].ToString();
            sqlHD += (i == (intRow - 1)) ? "SUM(COL_" + i.ToString() + ") as " + strQN + strNM + strQN :
                                          "SUM(COL_" + i.ToString() + ") as " + strQN + strNM + strQN + ",";

            sqlDT += (i == (intRow - 1)) ? "DECODE(A.SEM_CODE3_T,'" + strCD + "',A.CST_GRADE,0) as COL_" + i.ToString() :
                                          "DECODE(A.SEM_CODE3_T,'" + strCD + "',A.CST_GRADE,0) as COL_" + i.ToString() + ",";
        }

        string grdSQL = 
               @"
                    SELECT B.YY as " + strQN + @"년도"+ strQN +@", 
                           "+ sqlHD +@"
                      FROM (       
		                    SELECT A.CST_DATE_T as YY,
                                   "+ sqlDT +@"
	                          FROM (         
				                    SELECT SEM_CUSTOMER_CST.CST_DATE_T,                                 
                                           SEM_CODE_MASTER.SEM_CODE2_T,                        
                                           SEM_CODE_MASTER.SEM_CODE3_T,                        
                                           SEM_CODE_MASTER.SEM_CODE2_NAME,                     
                                           SEM_CODE_MASTER.SEM_CODE3_NAME,                     
                                           SEM_CUSTOMER_CST.CST_GRADE                          
                                      FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                           SEM_CUSTOMER_CST SEM_CUSTOMER_CST
                                     WHERE SEM_CODE_MASTER.SEM_CODE1_T = '14'
                                       AND SEM_CUSTOMER_CST.CST_DATE_T BETWEEN '"+ sYear +@"' AND '"+ eYear +@"'
                                       AND SEM_CUSTOMER_CST.CST_GUBN_T = '"+ ddlType.SelectedValue +@"'
                                       AND SEM_CUSTOMER_CST.CST_GUBN_T = SEM_CODE_MASTER.SEM_CODE2_T
                                       AND SEM_CUSTOMER_CST.CST_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
				                    ) A
		                      ) B
                     GROUP BY B.YY
               ";

        DataSet dsGrid = dbAgent.FillDataSet(grdSQL, "tblGrid");
        _setGraph(dsGrid);
        _setGrid(dsGrid);
    }

    private void _setGrid(DataSet dsGrid)
    {
        dsGrid.Tables[0].Columns.Add("합계", typeof(string));
        int intCol = dsGrid.Tables[0].Columns.Count;
        int intRow = dsGrid.Tables[0].Rows.Count;
        double tmpPoint = 0.00;

        for (int i = 0; i < intRow; i++)
        {
            tmpPoint = 0.00;
            for (int j = 1; j < intCol-1; j++)
            {
                tmpPoint += Convert.ToDouble(dsGrid.Tables[0].Rows[i][j].ToString());
            }
            dsGrid.Tables[0].Rows[i][intCol-1] = tmpPoint;
        }

        UltraWebGrid1.Bands[0].ResetColumns();
        DataView dvGrid = dsGrid.Tables[0].DefaultView;
        dvGrid.Sort = "년도 DESC";
        UltraWebGrid1.DataSource = dvGrid;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsGrid)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series[] oasrType = new Series[dsGrid.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsGrid.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["년도"].ToString(), null, SeriesChartType.Column, 1,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsGrid.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = dsGrid.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i, i + 2, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 1, i + 3, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView;
        Chart1.DataBind();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        setGridData();
    }


    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int intWidth = 0;
        int intColCnt = e.Layout.Bands[0].Columns.Count;
        for (int i = 0; i < intColCnt; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 80;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            }
            else
            {
                intWidth = (intColCnt == 0) ? 0 : Convert.ToInt32((700 / (intColCnt-1)));
                e.Layout.Bands[0].Columns[i].Width = intWidth;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
}
