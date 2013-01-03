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

public partial class eis_SEM_Mana_R033 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid();
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
            this.makeQuery();

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;
            /// </summary>
        }
    }

    private void makeQuery()
    {
        string strHd = "";
        string strDt = "";
        string strCdNm = "";
        string sqlComb = "";
        int cntRow = 0;


        sqlComb = "SELECT SEM_CODE2_T COM_CD, SEM_CODE2_NAME COM_NM FROM SEM_CODE_MASTER WHERE SEM_CODE_MASTER.SEM_CODE1_T = '08' AND SEM_CODE2_T <> '08001'";

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daComb = new OracleDataAdapter(sqlComb, _connection);
        DataSet dsComb = new DataSet();
        daComb.Fill(dsComb);

        cboCom.Items.Clear();
        cntRow = dsComb.Tables[0].Rows.Count;
        for (int i = 0; i < cntRow; i++)
        {
            cboCom.Items.Add(new ListItem(dsComb.Tables[0].Rows[i]["COM_NM"].ToString(), dsComb.Tables[0].Rows[i]["COM_CD"].ToString()));
        }
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strCom = this.cboCom.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        int intSYm = int.Parse(strYY)-3;

        string strQtn = "\"";
        string sqlGrid = "";
        sqlGrid = @"
                  SELECT B.COM_NM as 구분, B.YY as 년도, SUM(B.TMM) as 합계,
                         SUM(B.M01) as " + strQtn + @"1월" + strQtn + @",   SUM(B.M02) as " + strQtn + @"2월" + strQtn + @",  SUM(B.M03) as " + strQtn + @"3월" + strQtn + @",
                         SUM(B.M04) as " + strQtn + @"4월" + strQtn + @",   SUM(B.M05) as " + strQtn + @"5월" + strQtn + @",  SUM(B.M06) as " + strQtn + @"6월" + strQtn + @",
                         SUM(B.M07) as " + strQtn + @"7월" + strQtn + @",   SUM(B.M08) as " + strQtn + @"8월" + strQtn + @",  SUM(B.M09) as " + strQtn + @"9월" + strQtn + @",
                         SUM(B.M10) as " + strQtn + @"10월" + strQtn + @",  SUM(B.M11) as " + strQtn + @"11월" + strQtn + @", SUM(B.M12) as " + strQtn + @"12월" + strQtn + @"
                    FROM (
                          SELECT A.COM_CD, A.COM_NM, A.YY, A.MM, A.AMT_ACTL as TMM,
						         DECODE(A.MM,'01',A.AMT_ACTL,0) as M01, DECODE(A.MM,'02',A.AMT_ACTL,0) as M02,
								 DECODE(A.MM,'03',A.AMT_ACTL,0) as M03, DECODE(A.MM,'04',A.AMT_ACTL,0) as M04,
								 DECODE(A.MM,'05',A.AMT_ACTL,0) as M05, DECODE(A.MM,'06',A.AMT_ACTL,0) as M06,
								 DECODE(A.MM,'07',A.AMT_ACTL,0) as M07, DECODE(A.MM,'08',A.AMT_ACTL,0) as M08,
								 DECODE(A.MM,'09',A.AMT_ACTL,0) as M09, DECODE(A.MM,'10',A.AMT_ACTL,0) as M10,
								 DECODE(A.MM,'11',A.AMT_ACTL,0) as M11, DECODE(A.MM,'12',A.AMT_ACTL,0) as M12								 
						    FROM (
                                   SELECT Substr(SEM_COMPETITOR_SALE.COMP_DATE_T,1,4) YY,
                                          Substr(SEM_COMPETITOR_SALE.COMP_DATE_T,5,2) MM,								          
                                          MAX(SEM_CODE_MASTER.SEM_CODE2_T) COM_CD,
                                          MAX(SEM_CODE_MASTER.SEM_CODE2_NAME) COM_NM,
                                          DECODE('" + strGbn + @"','MS',Sum(SEM_COMPETITOR_SALE.COMP_ACTUAL),'TS',Sum(SEM_COMPETITOR_SALE.COMP_SUM_ACTUAL)) AMT_ACTL
                                     FROM SEM_COMPETITOR_SALE SEM_COMPETITOR_SALE,
                                          SEM_CODE_MASTER SEM_CODE_MASTER
                                    WHERE SEM_COMPETITOR_SALE.COMP_DATE_T between '" + (intSYm.ToString() + strMM) + @"' and '" + (strYY + strMM) + @"'
                                      AND SEM_CODE_MASTER.SEM_CODE1_T = '08'
                                      AND SEM_CODE_MASTER.SEM_CODE2_T = '08001'
                                      AND SEM_COMPETITOR_SALE.COMP_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                    GROUP BY SEM_COMPETITOR_SALE.COMP_DATE_T
                                    UNION ALL
								   SELECT Substr(SEM_COMPETITOR_SALE.COMP_DATE_T,1,4) YY,
                                          Substr(SEM_COMPETITOR_SALE.COMP_DATE_T,5,2) MM,								          
                                          MAX(SEM_CODE_MASTER.SEM_CODE2_T) COM_CD,
                                          MAX(SEM_CODE_MASTER.SEM_CODE2_NAME) COM_NM,
                                          DECODE('" + strGbn + @"','MS',Sum(SEM_COMPETITOR_SALE.COMP_ACTUAL),'TS',Sum(SEM_COMPETITOR_SALE.COMP_SUM_ACTUAL)) AMT_ACTL
                                     FROM SEM_COMPETITOR_SALE SEM_COMPETITOR_SALE,
                                          SEM_CODE_MASTER SEM_CODE_MASTER
                                    WHERE SEM_COMPETITOR_SALE.COMP_DATE_T between '" + (intSYm.ToString() + strMM) + @"' and '" + (strYY + strMM) + @"'
                                      AND SEM_CODE_MASTER.SEM_CODE1_T = '08'
                                      AND SEM_CODE_MASTER.SEM_CODE2_T LIKE '" + strCom + @"%'
                                      AND SEM_COMPETITOR_SALE.COMP_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE2_T
                                    GROUP BY SEM_COMPETITOR_SALE.COMP_DATE_T) A
                             ) B
                    GROUP BY B.COM_CD, B.COM_NM, B.YY
					ORDER BY B.YY DESC, B.COM_CD";

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(sqlGrid, _connection);
        daGrid.Fill(dsGrid);
        

        this._setGraph(dsGrid);
        DataView dvTmp = dsGrid.Tables[0].DefaultView;
        dvTmp.Sort = "년도 DESC";

        DataTable dtDiff = dvTmp.ToTable();

        double dblD_00 = 0.00;
        double dblD_01 = 0.00;
        double dblD_02 = 0.00;
        double dblD_03 = 0.00;
        double dblD_04 = 0.00;
        double dblD_05 = 0.00;
        double dblD_06 = 0.00;
        double dblD_07 = 0.00;
        double dblD_08 = 0.00;
        double dblD_09 = 0.00;
        double dblD_10 = 0.00;
        double dblD_11 = 0.00;
        double dblD_12 = 0.00;

        DataRow drGrid;

        if (dtDiff.Rows.Count > 1)
        {
            dblD_00 = double.Parse(dtDiff.Rows[0][2].ToString())  - double.Parse(dtDiff.Rows[1][2].ToString());
            dblD_01 = double.Parse(dtDiff.Rows[0][3].ToString())  - double.Parse(dtDiff.Rows[1][3].ToString());
            dblD_02 = double.Parse(dtDiff.Rows[0][4].ToString())  - double.Parse(dtDiff.Rows[1][4].ToString());
            dblD_03 = double.Parse(dtDiff.Rows[0][5].ToString())  - double.Parse(dtDiff.Rows[1][5].ToString());
            dblD_04 = double.Parse(dtDiff.Rows[0][6].ToString())  - double.Parse(dtDiff.Rows[1][6].ToString());
            dblD_05 = double.Parse(dtDiff.Rows[0][7].ToString())  - double.Parse(dtDiff.Rows[1][7].ToString());
            dblD_06 = double.Parse(dtDiff.Rows[0][8].ToString())  - double.Parse(dtDiff.Rows[1][8].ToString());
            dblD_07 = double.Parse(dtDiff.Rows[0][9].ToString())  - double.Parse(dtDiff.Rows[1][9].ToString());
            dblD_08 = double.Parse(dtDiff.Rows[0][10].ToString()) - double.Parse(dtDiff.Rows[1][10].ToString());
            dblD_09 = double.Parse(dtDiff.Rows[0][11].ToString()) - double.Parse(dtDiff.Rows[1][11].ToString());
            dblD_10 = double.Parse(dtDiff.Rows[0][12].ToString()) - double.Parse(dtDiff.Rows[1][12].ToString());
            dblD_11 = double.Parse(dtDiff.Rows[0][13].ToString()) - double.Parse(dtDiff.Rows[1][13].ToString());
            dblD_12 = double.Parse(dtDiff.Rows[0][14].ToString()) - double.Parse(dtDiff.Rows[1][14].ToString());
        }


        drGrid = dtDiff.NewRow();
        drGrid["구분"] = "차이";
        drGrid["년도"] = dtDiff.Rows[0][1].ToString();
        drGrid["합계"] = dblD_00;
        drGrid["1월"] = dblD_01;
        drGrid["2월"] = dblD_02;
        drGrid["3월"] = dblD_03;
        drGrid["4월"] = dblD_04;
        drGrid["5월"] = dblD_05;
        drGrid["6월"] = dblD_06;
        drGrid["7월"] = dblD_07;
        drGrid["8월"] = dblD_08;
        drGrid["9월"] = dblD_09;
        drGrid["10월"] = dblD_10;
        drGrid["11월"] = dblD_11;
        drGrid["12월"] = dblD_12;
        dtDiff.Rows.InsertAt(drGrid, 2);


        UltraWebGrid1.DataSource = dtDiff;
        UltraWebGrid1.DataBind();
    }

    private DataTable Tbl_Grid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("serNo", typeof(int));
        dt.Columns.Add("구분", typeof(string));
        dt.Columns.Add("용도", typeof(string));
        dt.Columns.Add("01월", typeof(double));
        dt.Columns.Add("02월", typeof(double));
        dt.Columns.Add("03월", typeof(double));
        dt.Columns.Add("04월", typeof(double));
        dt.Columns.Add("05월", typeof(double));
        dt.Columns.Add("06월", typeof(double));
        dt.Columns.Add("07월", typeof(double));
        dt.Columns.Add("08월", typeof(double));
        dt.Columns.Add("09월", typeof(double));
        dt.Columns.Add("10월", typeof(double));
        dt.Columns.Add("11월", typeof(double));
        dt.Columns.Add("12월", typeof(double));
        return dt;
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
            // For each Row add a new series
            if (dsGrid.Tables[0].Rows[0]["년도"].Equals(cboYY.SelectedValue.ToString()) && intLP < 2)
            {
                oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name ,
                                                        row["구분"].ToString(), null, SeriesChartType.Column, 1,
                                                        GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                for (int colIndex = 2; colIndex < dsGrid.Tables[0].Columns.Count; colIndex++)
                {
                    // For each column (column 1 and onward) add the value as a point
                    string columnName = dsGrid.Tables[0].Columns[colIndex].ColumnName;
                    double YVal = double.Parse(row[columnName].ToString());
                    Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
                }
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i, i + 2, true);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i+1, i + 3, true);
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

            e.Layout.Bands[0].Columns.FromKey("구분").Header.Caption = "구분";
            e.Layout.Bands[0].Columns.FromKey("구분").Width = 40;
            e.Layout.Bands[0].Columns.FromKey("구분").Header.Style.HorizontalAlign = HorizontalAlign.Left;

            e.Layout.Bands[0].Columns.FromKey("년도").Header.Caption = "년도";
            e.Layout.Bands[0].Columns.FromKey("년도").Width = 30;
            e.Layout.Bands[0].Columns.FromKey("년도").Header.Style.HorizontalAlign = HorizontalAlign.Center;


            e.Layout.Bands[0].Columns.FromKey("합계").CellStyle.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.Bands[0].Columns.FromKey("합계").Format = "#,##0";
            e.Layout.Bands[0].Columns.FromKey("합계").Width = 80;

            for (int i = 1; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                //e.Layout.Bands[0].Columns.FromKey(i.ToString()+"월").Header.Caption = cboCom.Items[i].Text;
                e.Layout.Bands[0].Columns.FromKey(i.ToString() + "월").CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns.FromKey(i.ToString() + "월").Format = "#,##0";
                e.Layout.Bands[0].Columns.FromKey(i.ToString() + "월").Width = 59;
            }
        }
        catch
        {
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        e.Row.Style.BackColor = Color.White;
        if (dr["구분"].ToString().Equals("차이"))
        {
            e.Row.Style.ForeColor = System.Drawing.Color.Blue; //GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
            e.Row.Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
            //e.Row.Cells.FromKey("구분").Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME1);
        }
    }
}