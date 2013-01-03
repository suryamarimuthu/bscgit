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



public partial class eis_SEM_Mana_R032 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this.makeQuery();
    }

    private void _initForm(bool blnGbn)
    {
        /// <summary>
        /// 폼초기화 및 기본값 세팅
        /// 
        if (!blnGbn)
        {
            DateTime objDT = DateTime.Now;
            string strYY;
            string strMM;
            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.cboYY.Items.Clear();
            this.cboCom.Items.Clear();

            for (intLP = 1; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    strMM = "0" + intLP.ToString();
                }
                else
                {
                    strMM = intLP.ToString();
                }

                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM-1 == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            cboYY.SelectedValue = intYY.ToString();

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;
            /// </summary>
        }
    }

    private void makeQuery()
    {
        DataSet dsComb = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        string strHd = "";
        string strDt = "";
        string sqlComb = "";
        int cntRow = 0;

        cboCom.Items.Clear();
        sqlComb = @"SELECT SEM_CODE2_T as COM_CD, SEM_CODE2_NAME as COM_NM FROM SEM_CODE_MASTER WHERE SEM_CODE_MASTER.SEM_CODE1_T = '08'";

        OracleDataAdapter daComb = new OracleDataAdapter(sqlComb, _connection);
        daComb.Fill(dsComb);

        string strQtr = "\"";
        cntRow = dsComb.Tables[0].Rows.Count;
        for (int i = 0; i < cntRow; i++)
        {
            if (i < cntRow - 1)
            {
                strHd += "SUM(B.AREA" + i.ToString() + ") as " + strQtr + dsComb.Tables[0].Rows[i]["COM_NM"] + strQtr + ",";
                strDt += "DECODE(A.COM_CD,'" + dsComb.Tables[0].Rows[i]["COM_CD"].ToString() + "', A.AMT_ACTL,0) AREA"+i.ToString()+",";
            }
            else 
            {
                strHd += "SUM(B.AREA" + i.ToString() + ") as " + strQtr + dsComb.Tables[0].Rows[i]["COM_NM"] + strQtr + " ";
                strDt += "DECODE(A.COM_CD,'" + dsComb.Tables[0].Rows[i]["COM_CD"].ToString() + "', A.AMT_ACTL,0) AREA" + i.ToString() + " ";
            }
            
            cboCom.Items.Add(new ListItem(dsComb.Tables[0].Rows[i]["COM_NM"].ToString(), dsComb.Tables[0].Rows[i]["COM_CD"].ToString()));
        }

        this._queryGrid(_connection, strHd, strDt);
    }

    private void _queryGrid(OracleConnection pCon, string strHd, string strDt)
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strCom = this.cboCom.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        int intSYm = int.Parse(strYY)-4;

        string sqlGrid = "";

       sqlGrid = @"
                  SELECT B.YY, " + strHd + @"
                    FROM (SELECT A.YY, A.COM_NM, " + strDt + @"
                            FROM ( SELECT Substr(SEM_COMPETITOR_SALE.COMP_DATE_T,1,4) YY,
                                          SEM_COMPETITOR_SALE.COMP_GUBN_CODE_T COM_CD,
                                          SEM_CODE_MASTER.SEM_CODE2_NAME COM_NM,
                                          DECODE('" + strGbn + @"','MS',Sum(SEM_COMPETITOR_SALE.COMP_ACTUAL),'TS',Sum(SEM_COMPETITOR_SALE.COMP_SUM_ACTUAL)) AMT_ACTL
                                     FROM SEM_COMPETITOR_SALE SEM_COMPETITOR_SALE,
                                          SEM_CODE_MASTER SEM_CODE_MASTER
                                    WHERE substr(SEM_COMPETITOR_SALE.COMP_DATE_T,1,4) between '" + intSYm.ToString() + @"' and '" + strYY + @"'
                                      AND substr(SEM_COMPETITOR_SALE.COMP_DATE_T,5,2) = '" + strMM + @"'
                                      AND SEM_CODE_MASTER.SEM_CODE1_T = '08'
                                      AND SEM_COMPETITOR_SALE.COMP_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                    GROUP BY Substr(SEM_COMPETITOR_SALE.COMP_DATE_T,1,4),
                                          SEM_COMPETITOR_SALE.COMP_GUBN_CODE_T,
                                          SEM_CODE_MASTER.SEM_CODE2_NAME) A
                            ) B
                     GROUP BY B.YY
                     ORDER BY B.YY DESC";

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(sqlGrid, pCon);
        daGrid.Fill(dsGrid);


        this._setGraph(dsGrid);
        UltraWebGrid1.DataSource = dsGrid;
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
                                                    row["YY"].ToString(), null, SeriesChartType.Column, 1,
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

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView;
        Chart1.DataBind();
    }

    private DataTable Tbl_Grph()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("YY", typeof(string));
        for (int i = 1; i < cboCom.Items.Count; i++)
        {
            dt.Columns.Add(cboCom.Items[i].Text, typeof(double));
        }
        return dt;
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        try
        {
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
            ch = e.Layout.Bands[0].Columns[0].Header;

            e.Layout.Bands[0].Columns.FromKey("YY").Header.Caption = "년도";
            e.Layout.Bands[0].Columns.FromKey("YY").Width = 40;

            for (int i = 0; i < cboCom.Items.Count; i++)
            {
                //e.Layout.Bands[0].Columns.FromKey("AREA" + i.ToString()).Header.Caption = cboCom.Items[i].Text;
                e.Layout.Bands[0].Columns.FromKey(cboCom.Items[i].Text).CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns.FromKey(cboCom.Items[i].Text).Format = "#,##0";
                e.Layout.Bands[0].Columns.FromKey(cboCom.Items[i].Text).Width = 70;
            }
        }
        catch
        {
        }
    }
}