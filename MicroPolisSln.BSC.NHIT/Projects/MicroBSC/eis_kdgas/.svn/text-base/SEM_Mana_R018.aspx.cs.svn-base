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

public partial class eis_SEM_Mana_R018 : EISPageBase
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
            this.cboMM.Items.Clear();
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
                if (intMM - 1 == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedIndex = cboYY.Items.Count - 1;

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));

            cboGbn.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strCom = this.cboCom.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        int intPYY = Convert.ToInt32(strYY)-1;
        string strPYY = intPYY.ToString();
        string query = "";

        query = @"SELECT A.SGBUN_CD as SGBUN_CD, MAX(A.SGBUN_NM) as SGBUN_NM, SUBSTR(MAX(A.SYYMM),1,4) || '/' || SUBSTR(MAX(A.SYYMM),5,2) as SYYMM,
                      MAX(A.COM_CD) as COM_CD, SUM(A.S_PLAN) as S_PLAN, SUM(A.S_RSLT) as S_RSLT,
                      (SUM(A.S_RSLT)-SUM(A.S_PLAN)) as S_DIFF,
                      ROUND(DECODE(SUM(A.S_PLAN),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100),1) as ACHV_RATE,
                      NVL(SUM(B.S_RSLT),0) as L_RSLT,
                      (SUM(A.S_RSLT)-SUM(B.S_RSLT)) as S_ADD,
                      ROUND(DECODE(SUM(B.S_RSLT),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT))*100),1) as GROW_RATE
                 FROM (
                      SELECT SEM_CODE_MASTER.SEM_CODE2_T as SGBUN_CD,
                             SEM_CODE_MASTER.SEM_CODE2_NAME as SGBUN_NM,
                             SEM_SALE_MONTHLY.SALE_DATE_T as SYYMM,
                             MAX(SEM_SALE_MONTHLY.SALE_OFFICE_T) as COM_CD,
                             DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_PLAN)/1000,'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_PLAN)/1000) as S_PLAN,
                             DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_ACTUAL)/1000,'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_ACTUAL)/1000) as S_RSLT
                        FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                             SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                       WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                         AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                         AND SEM_SALE_MONTHLY.SALE_DATE_T = '" + (strYY + strMM) + @"'
                         AND SEM_SALE_MONTHLY.SALE_OFFICE_T like  '" + strCom + @"%'
                       GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                             SEM_CODE_MASTER.SEM_CODE2_NAME,
                             SEM_SALE_MONTHLY.SALE_DATE_T) A,
                      (
                       SELECT SEM_CODE_MASTER.SEM_CODE2_T as SGBUN_CD,
                              SEM_CODE_MASTER.SEM_CODE2_NAME as SGBUN_NM,
                              SEM_SALE_MONTHLY.SALE_DATE_T as SYYMM,
                              MAX(SEM_SALE_MONTHLY.SALE_OFFICE_T) as COM_CD,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_PLAN)/1000,'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_PLAN)/1000) as S_PLAN,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_ACTUAL)/1000,'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_ACTUAL)/1000) as S_RSLT
                         FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                              SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                        WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                          AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                          AND SEM_SALE_MONTHLY.SALE_DATE_T = '" + (strPYY+strMM)+ @"'
                          AND SEM_SALE_MONTHLY.SALE_OFFICE_T like '" + strCom + @"%'
                        GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                              SEM_CODE_MASTER.SEM_CODE2_NAME,
                              SEM_SALE_MONTHLY.SALE_DATE_T) B
                 WHERE A.SGBUN_CD = B.SGBUN_CD(+)
                 GROUP BY A.SGBUN_CD";

     string strSQL;
     strSQL = @"  SELECT DECODE(B.MM , '01','1', '02','2', '03','3', '04','4',
		                       '05','5', '06','6', '07','7', '08','8', '09', '9',
								 B.MM) as V_MM, 
                        (NVL(SUM(A.AMT_PLAN),0)/1000) AMT_PLAN, 
                        (NVL(SUM(A.AMT_ACTL),0)/1000) AMT_ACTL,
                        NVL(ROUND(DECODE(SUM(A.AMT_ACTL),0,0,((SUM(A.AMT_ACTL)/SUM(A.AMT_PLAN))*100)),1),0) as ACHV_RATE
                  FROM (SELECT SUBSTR(SM.SALE_DATE_T,5,2) MM,
                               DECODE('" + strGbn + @"','MS',SUM(SM.SALE_AMT_PLAN),'TS',SUM(SM.SALE_SUM_AMT_PLAN)) as AMT_PLAN,
                               0 as AMT_ACTL
                          FROM SEM_SALE_MONTHLY SM
                         WHERE SM.SALE_DATE_T BETWEEN '" + strYY + @"01' AND '" + strYY + @"12'
                           AND SALE_OFFICE_T Like '" + strCom + @"%'
                         GROUP BY SM.SALE_DATE_T
                         UNION ALL
                        SELECT SUBSTR(SM.SALE_DATE_T,5,2) MM,
                               0 as AMT_PLAN,
                               DECODE('" + strGbn + @"','MS',SUM(SM.SALE_AMT_ACTUAL),'TS',SUM(SM.SALE_SUM_AMT_ACTUAL)) as AMT_ACTL
                          FROM SEM_SALE_MONTHLY SM
                         WHERE SM.SALE_DATE_T BETWEEN '" + strYY + @"01' AND '" + (strYY+strMM) + @"'
                           AND SALE_OFFICE_T Like '" + strCom + @"%'
                         GROUP BY SM.SALE_DATE_T ) A, PVT_TBL B 
                  WHERE B.MM = A.MM(+) 
                  GROUP BY B.MM
                  ORDER BY B.MM";

        DataSet dsGrid = new DataSet();
        DataSet dsGrph = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(query, _connection);
        OracleDataAdapter daGrph = new OracleDataAdapter(strSQL, _connection);
        daGrid.Fill(dsGrid);
        daGrph.Fill(dsGrph);

        this._setGraph(dsGrid, dsGrph);
        this.setGridData(dsGrid);
    }

    private void setGridData(DataSet iDsSet)
    {
        double dblPlan = 0.00;
        double dblActl = 0.00;
        double dblRslt = 0.00;


        int intRow = iDsSet.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            dblPlan += double.Parse(iDsSet.Tables[0].Rows[i]["S_PLAN"].ToString());
            dblActl += double.Parse(iDsSet.Tables[0].Rows[i]["S_RSLT"].ToString());
            dblRslt += double.Parse(iDsSet.Tables[0].Rows[i]["L_RSLT"].ToString());
        }

        DataRow drTmp = iDsSet.Tables[0].NewRow();
        drTmp["SGBUN_NM"] = "합       계";
        drTmp["S_PLAN"] = dblPlan;
        drTmp["S_RSLT"] = dblActl;
        drTmp["L_RSLT"] = dblRslt;
        drTmp["S_DIFF"] = dblActl-dblPlan;
        drTmp["ACHV_RATE"] = (dblPlan==0) ? 0.00 : Math.Round((dblActl / dblPlan) * 100,1);
        drTmp["S_ADD"] = dblActl - dblRslt;
        drTmp["GROW_RATE"] = (dblRslt==0) ? 0.00 : Math.Round((dblActl / dblRslt) * 100,1);
        iDsSet.Tables[0].Rows.InsertAt(drTmp,0);

        UltraWebGrid1.DataSource = iDsSet;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsGrid, DataSet dsGrph)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 300, 290
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1),2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 500, 290
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "매출비중", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        series1.FontColor = Color.White;
        Series series5 = DundasCharts.CreateSeries(Chart2, "Series5", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series6 = DundasCharts.CreateSeries(Chart2, "Series6", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series7 = DundasCharts.CreateSeries(Chart2, "Series7", "Default", "달성율",null, SeriesChartType.Line, 1, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //Series series8 = DundasCharts.CreateSeries(Chart2, "Series8", "Default", "실적율", null, SeriesChartType.Point, 1, Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(0xE4, 0xE4, 0xE4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

      //------------------------------------------------------Chart1
        double dblTRAmt = 0.00;
        DataTableReader drSum = dsGrid.CreateDataReader();
        if (drSum.HasRows)
        {
            while (drSum.Read())
            {
                dblTRAmt += Convert.ToDouble(drSum["S_RSLT"].ToString());
            }
        }

        DataTable dtTmp = Tbl_Change_Rate();
        DataRow drTmp = null;
        DataRowCollection drcTmp = dsGrid.Tables[0].Rows;
        DataRow[] drPie = dsGrid.Tables[0].Select("", "S_RSLT DESC");

        double dblRAmt = 0.00;
        double dblRSum = 0.00;
        double dblRate = 0.00;
        for (int i = 0; i < drPie.Length; i++)
        {
            dblRAmt = Convert.ToDouble(drPie[i]["S_RSLT"].ToString());
            if (dblTRAmt == 0)
            {
                dblRate = 0;
            }
            else
            {
                dblRate = (dblRAmt / dblTRAmt) * 100;
            }

            if (i < 3)
            {
                drTmp = dtTmp.NewRow();
                drTmp["SGubun"] = drPie[i]["SGBUN_NM"].ToString() +"(" + Convert.ToDouble(dblRate.ToString()).ToString("#,##0.#") + "%)";
                drTmp["Sale_Rate"] = dblRate;
                dtTmp.Rows.Add(drTmp);
            }
            else
            {
                dblRSum += dblRate;
            }
        }
        drTmp = dtTmp.NewRow();
        drTmp["SGubun"] = "기타" + "(" + Convert.ToDouble(dblRSum.ToString()).ToString("#,##0.#") + "%)";
        drTmp["Sale_Rate"] = dblRSum;
        dtTmp.Rows.Add(drTmp);

        Chart1.DataSource = dtTmp.DefaultView;
        //Chart1.Series[series1.Name]["PieLabelStyle"] = "Outside";
        series1.ValueMembersY = "Sale_Rate";
        series1.ValueMemberX = "SGubun";
        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, false);

        //------------------------------------------------------Chart2
        Chart2.DataSource = dsGrph.Tables[0].DefaultView;
        series5.ValueMembersY = "AMT_PLAN";
        series6.ValueMembersY = "AMT_ACTL";
        series7.ValueMembersY = "ACHV_RATE";
        series5.ValueMemberX  = "V_MM";

        //Chart1.Series["My series"].ToolTip = "X value \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";
        //Chart2.Series[series5.Name].ToolTip = "MONTH \t= #VALX{d}\nY PLAN \t= #VALY{C}\nRadius \t= #VALY2{P}";
        //Chart2.Series[series6.Name].ToolTip = "MONTH \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";
        //Chart2.Series[series7.Name].ToolTip = "MONTH \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";

        string strChartArea = Chart2.Series[series7.Name].ChartArea;
        series7.YAxisType = AxisType.Secondary;


        double mxRate = 0;
        double bfRate = 0;
        double afRate = 0;
        int intLP = 0;
        for (intLP = 0; intLP<dsGrph.Tables[0].Rows.Count;intLP++)
        {
            bfRate = afRate;
            afRate = Convert.ToDouble(dsGrph.Tables[0].Rows[intLP]["ACHV_RATE"].ToString());
            if (bfRate > afRate && bfRate > mxRate)
            {
                mxRate = bfRate;
            }
            else if (afRate > bfRate && afRate > mxRate)
            {
                mxRate = afRate;
            }
            intLP = intLP + 1;
        }


        Chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart2.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";


        DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart2, series5, 0.0, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart2, series6, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart2, series7, 1.0, 2.0, true);
        //DundasAnimations.GrowingAnimation(Chart2, series8, 4.0, 6.0, true);

    }
    private DataTable Tbl_Change_Rate() 
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SGubun", typeof(string));
        dt.Columns.Add("Sale_Rate", typeof(double));
        return dt;
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        int[] arrCol = new int[2] { 5, 7 };
        double[] arrRate = new double[2];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            if (arrRate[intCol] > 99)
            {
                e.Row.Cells[arrCol[intCol]].Style.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                e.Row.Cells[arrCol[intCol]].Style.ForeColor = System.Drawing.Color.Red;
            }
        }

        //============================= 증가율처리
        double dblARate = (Convert.ToDouble(e.Row.Cells[7].Value) == 0) ? 0 : (Convert.ToDouble(e.Row.Cells[7].Value) - 100);
        e.Row.Cells[7].Value = dblARate;
        e.Row.Cells[7].Style.ForeColor = (dblARate >= 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();
        e.Layout.Bands[0].Reset();

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;

            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "구분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년동기";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[1].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[2].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[3].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanY = 2;

    }
}