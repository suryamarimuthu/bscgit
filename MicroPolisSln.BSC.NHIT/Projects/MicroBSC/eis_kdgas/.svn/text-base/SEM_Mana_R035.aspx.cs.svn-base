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

public partial class eis_SEM_Mana_R035 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this.setGridGrph();
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
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.cboYY.Items.Clear();
            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedIndex = cboYY.Items.Count - 1;

        }
    }

    private void setGridGrph()
    {
        string strYY = this.cboYY.SelectedValue;
        int intYY = Convert.ToInt16(strYY);

        string strSQL = "";
        string strQN = "\"";
        string str05 = strQN + Convert.ToString(intYY - 4) + "년" + strQN;
        string str04 = strQN + Convert.ToString(intYY - 3) + "년" + strQN;
        string str03 = strQN + Convert.ToString(intYY - 2) + "년" + strQN;
        string str02 = strQN + Convert.ToString(intYY - 1) + "년" + strQN;
        string str01 = strQN + Convert.ToString(intYY - 0) + "년" + strQN;

        strSQL = @"
               SELECT '1' as SORT_ORDER,
                      '사용처별' as " + strQN + @"구분" + strQN + @",
                      B.SEM_NM as " + strQN +@"타입"+ strQN +@",
                      SUM(B.Y01) as " + str05 + @", 
                      SUM(B.Y02) as " + str04 + @",
                      SUM(B.Y03) as " + str03 + @",
                      SUM(B.Y04) as " + str02 + @",
                      SUM(B.Y05) as " + str01 + @"
                 FROM ( 
                       SELECT A.SEM_CD, A.SEM_NM,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 4) + @"',A.SEM_QNT,0) as Y01,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 3) + @"',A.SEM_QNT,0) as Y02,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 2) + @"',A.SEM_QNT,0) as Y03,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 1) + @"',A.SEM_QNT,0) as Y04,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 0) + @"',A.SEM_QNT,0) as Y05
                         FROM (  
                               SELECT SEM_FUEL_MARKET.FUEL_CODE_T as SEM_CD,
                                      SEM_CODE_MASTER.SEM_CODE3_NAME as SEM_NM,
                                      SEM_FUEL_MARKET.FUEL_DATE_T as YY,
                                      SUM(SEM_FUEL_MARKET.FUEL_QUANTITY) as SEM_QNT
                                 FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                      SEM_FUEL_MARKET SEM_FUEL_MARKET
                                WHERE SEM_CODE_MASTER.SEM_CODE1_T = '37'
                                  AND SEM_FUEL_MARKET.FUEL_DATE_T BETWEEN '" + Convert.ToString(intYY - 4) + @"' AND '" + strYY + @"'
                                  AND SEM_FUEL_MARKET.FUEL_GUBN_T ='1'
                                  AND SEM_FUEL_MARKET.FUEL_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                GROUP BY SEM_FUEL_MARKET.FUEL_DATE_T,
                                         SEM_FUEL_MARKET.FUEL_CODE_T,
                                         SEM_CODE_MASTER.SEM_CODE3_NAME
                               ) A
                       ) B
                GROUP BY B.SEM_CD, B.SEM_NM
                UNION ALL
               SELECT '2' as SORT_ORDER,
                      '에너지별' as " + strQN + @"구분" + strQN + @",
                      B.SEM_NM as " + strQN +@"타입"+ strQN +@",
                      SUM(B.Y01) as " + str05 + @", 
                      SUM(B.Y02) as " + str04 + @",
                      SUM(B.Y03) as " + str03 + @",
                      SUM(B.Y04) as " + str02 + @",
                      SUM(B.Y05) as " + str01 + @"
                 FROM ( 
                       SELECT A.SEM_CD, A.SEM_NM,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 4) + @"',A.SEM_QNT,0) as Y01,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 3) + @"',A.SEM_QNT,0) as Y02,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 2) + @"',A.SEM_QNT,0) as Y03,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 1) + @"',A.SEM_QNT,0) as Y04,
                              DECODE(A.YY,'" + Convert.ToString(int.Parse(strYY) - 0) + @"',A.SEM_QNT,0) as Y05
                         FROM (
                               SELECT SEM_FUEL_MARKET.FUEL_CODE_T as SEM_CD,            
                                      SEM_CODE_MASTER.SEM_CODE3_NAME as SEM_NM,
                                      SEM_FUEL_MARKET.FUEL_DATE_T as YY,
                                      SUM(SEM_FUEL_MARKET.FUEL_QUANTITY) as SEM_QNT
                                 FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                      SEM_FUEL_MARKET SEM_FUEL_MARKET
                                WHERE SEM_CODE_MASTER.SEM_CODE1_T = '37'
                                  AND SEM_FUEL_MARKET.FUEL_DATE_T BETWEEN '" + Convert.ToString(intYY - 4) + @"' AND '" + strYY + @"'
                                  AND SEM_FUEL_MARKET.FUEL_GUBN_T ='2'
                                  AND SEM_FUEL_MARKET.FUEL_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                GROUP BY SEM_FUEL_MARKET.FUEL_CODE_T,           
                                         SEM_CODE_MASTER.SEM_CODE3_NAME , 
                                         SEM_FUEL_MARKET.FUEL_DATE_T
                                ORDER BY SEM_FUEL_MARKET.FUEL_CODE_T 
                              ) A
                       ) B
                GROUP BY B.SEM_NM
         
                ";

        DataSet dsGrid = new DataSet();
        DataSet dsGrph = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(strSQL, _connection);
        daGrid.Fill(dsGrid);
        daGrid.Fill(dsGrph);

        UltraWebGrid1.Bands[0].ResetColumns();
        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();

        this.setGraph(dsGrph);
    }

    private DataSet setGraphTable(DataSet dsGrph, string istrGbn)
    {
        DataTable dtGrph = dsGrph.Tables[0].Clone();
        DataRow drGrph = null;
        int intCol = dsGrph.Tables[0].Columns.Count;
        int intRow = dsGrph.Tables[0].Rows.Count;

        for (int i = 0; i < intRow; i++)
        {
            if (dsGrph.Tables[0].Rows[i][0].ToString() == istrGbn)
            {
                drGrph = dtGrph.NewRow();
                for (int j = 0; j < intCol; j++)
                {
                    {
                        drGrph[j] = dsGrph.Tables[0].Rows[i][j];
                    }
                }
                dtGrph.Rows.Add(drGrph);
            }
        }

        DataSet rtnDS = new DataSet();
        rtnDS.Tables.Add(dtGrph);
        return rtnDS;
    }

    private void setGraph(DataSet idsGrph)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 400, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 400, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);


        //============================================================== Graph 1
        DataSet dsGrph1 = setGraphTable(idsGrph, "2");
        int intCol = dsGrph1.Tables[0].Columns.Count - 3;
        int intRow = dsGrph1.Tables[0].Rows.Count;

        Series[] oasrType = new Series[intCol];
        double dblYVal = 0.00;
        string strColNm = "";
        string strRowNm = "";

        for (int i = 0; i < intCol; i++)
        {
            strColNm = dsGrph1.Tables[0].Columns[i+3].ColumnName;
            oasrType[i] = DundasCharts.CreateSeries(Chart1, "Series" + i.ToString(), Chart1.ChartAreas[0].Name,
                                                    strColNm, null, SeriesChartType.Column, 0,
                                                    GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int j = 0; j < intRow; j++)
            {
                strRowNm = dsGrph1.Tables[0].Rows[j][2].ToString();
                dblYVal = Convert.ToDouble(dsGrph1.Tables[0].Rows[j][i+3].ToString());
                Chart1.Series[oasrType[i].Name].Points.AddXY(strRowNm, dblYVal);
            }
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i, i + 1, true);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 1, i + 2, false);
        }

        //============================================================== Graph 2
        DataSet dsGrph2 = setGraphTable(idsGrph, "1");
        intCol = dsGrph2.Tables[0].Columns.Count - 3;
        intRow = dsGrph2.Tables[0].Rows.Count;

        Series[] oasrType2 = new Series[intCol];
        dblYVal = 0.00;
        strColNm = "";
        strRowNm = "";


        for (int i = 0; i < intRow; i++)
        {
            strRowNm = dsGrph2.Tables[0].Rows[i][2].ToString();
            oasrType2[i] = DundasCharts.CreateSeries(Chart2, "Series" + i.ToString(), Chart2.ChartAreas[0].Name,
                                                    strRowNm, null, SeriesChartType.StackedColumn, 0,
                                                    GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int j = 0; j < intCol; j++)
            {
                strColNm = dsGrph2.Tables[0].Columns[j+3].ColumnName;
                dblYVal = Convert.ToDouble(dsGrph2.Tables[0].Rows[i][j+3].ToString());
                Chart2.Series[oasrType2[i].Name].Points.AddXY(strColNm, dblYVal);
            }
        }

        DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType2.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart2, oasrType2[i], i, i + 1, true);
            else
                DundasAnimations.GrowingAnimation(Chart2, oasrType2[i], i + 1, i + 2, false);
        }


    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Hidden = true;
            }
            else if (i == 1 || i == 2)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                e.Layout.Bands[0].Columns[i].Width = (i == 1) ? 90 : 120;
                e.Layout.Bands[0].Columns[i].MergeCells = true;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].Width = 115;
            }
        }
    }
}
