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

public partial class eis_SEM_Mana_R024 : System.Web.UI.Page
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

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboCom.SelectedIndex = 0;
            
            this.cboYY.SelectedValue = intYY.ToString();

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;
            /// </summary>
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
        string sqlGrph1 = "";
        string sqlGrph2 = "";

        sqlGrph1 = @"
                      SELECT decode(PT.MM,'01','1','02','2', '03','3', '04','4', '05','5',
                                          '06','6','07','7', '08','8', '09','9', PT.MM)  as MM,
                             NVL(UA.A_PLAN,0)/1000 as A_PLAN, 
                             NVL(UA.A_ACTL,0)/1000 as A_ACTL, NVL(UA.A_RATE,0) as A_RATE
                        FROM (	 
	                          SELECT A.MM as MM, 
	                                 NVL(SUM(A.QNT_PLAN),0) as A_PLAN, 
			                         NVL(SUM(A.QNT_ACTL),0) as A_ACTL, 
			                         ROUND(DECODE(NVL(SUM(A.QNT_PLAN),0),0,0,(SUM(A.QNT_ACTL) / SUM(A.QNT_PLAN))*100),4) as A_RATE
	                            FROM (SELECT SUBSTR(SEM_CNG_SALE.CNG_DATE_T,5,2) as MM,
	                                         DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_PLAN),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_PLAN)) as QNT_PLAN,
					                         0 as QNT_ACTL
	                                    FROM SEM_CNG_SALE SEM_CNG_SALE
	                                   WHERE SEM_CNG_SALE.CNG_DATE_T BETWEEN '" + strYY + @"01' AND '" + (strYY) + @"12'
	                                     AND SEM_CNG_SALE.CNG_OFFICE_T LIKE '" + strCom + @"%'
				                         AND SEM_CNG_SALE.CNG_GUBN_CODE_T = 'C'
	       	                           GROUP BY SEM_CNG_SALE.CNG_GUBN_CODE_T,
		                                     SEM_CNG_SALE.CNG_DATE_T
			                           UNION ALL 
			                          SELECT SUBSTR(SEM_CNG_SALE.CNG_DATE_T,5,2) as MM,
			                                 0 as QNT_PLAN,
			                                 DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_ACTUAL),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_ACTUAL)) as QNT_ACTL
	                                    FROM SEM_CNG_SALE SEM_CNG_SALE
	                                   WHERE SEM_CNG_SALE.CNG_DATE_T BETWEEN '" + strYY + @"01' AND '" + (strYY + strMM) + @"'
	                                     AND SEM_CNG_SALE.CNG_OFFICE_T LIKE '" + strCom + @"%'
				                         AND SEM_CNG_SALE.CNG_GUBN_CODE_T = 'C'
	       	                           GROUP BY SEM_CNG_SALE.CNG_GUBN_CODE_T,
		                                     SEM_CNG_SALE.CNG_DATE_T) A
	                           GROUP BY A.MM
	                          ) UA , PVT_TBL PT
                        WHERE UA.MM(+) = PT.MM 
                        ORDER BY PT.MM ";                       

        sqlGrph2 = @"
                      SELECT decode(PT.MM,'01','1','02','2', '03','3', '04','4', '05','5',
                                          '06','6','07','7', '08','8', '09','9', PT.MM)  as MM, 
                             NVL(UA.A_PLAN,0)/1000 as A_PLAN, NVL(UA.A_ACTL,0)/1000 as A_ACTL, NVL(UA.A_RATE,0) as A_RATE
                        FROM (	 
	                          SELECT A.MM as MM, 
	                                 NVL(SUM(A.QNT_PLAN),0) as A_PLAN, 
			                         NVL(SUM(A.QNT_ACTL),0) as A_ACTL, 
			                         ROUND(DECODE(NVL(SUM(A.QNT_PLAN),0),0,0,(SUM(A.QNT_ACTL) / SUM(A.QNT_PLAN))*100),4) as A_RATE
	                            FROM (SELECT SUBSTR(SEM_CNG_SALE.CNG_DATE_T,5,2) as MM,
	                                         DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_PLAN),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_PLAN)) as QNT_PLAN,
					                         0 as QNT_ACTL
	                                    FROM SEM_CNG_SALE SEM_CNG_SALE
	                                   WHERE SEM_CNG_SALE.CNG_DATE_T BETWEEN '" + strYY + @"01' AND '" + (strYY) + @"12'
	                                     AND SEM_CNG_SALE.CNG_OFFICE_T LIKE '" + strCom + @"%'
				                         AND SEM_CNG_SALE.CNG_GUBN_CODE_T = 'M'
	       	                           GROUP BY SEM_CNG_SALE.CNG_GUBN_CODE_T,
		                                     SEM_CNG_SALE.CNG_DATE_T
			                           UNION ALL 
			                          SELECT SUBSTR(SEM_CNG_SALE.CNG_DATE_T,5,2) as MM,
			                                 0 as QNT_PLAN,
			                                 DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_ACTUAL),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_ACTUAL)) as QNT_ACTL
	                                    FROM SEM_CNG_SALE SEM_CNG_SALE
	                                   WHERE SEM_CNG_SALE.CNG_DATE_T BETWEEN '" + strYY + @"01' AND '" + (strYY + strMM) + @"'
	                                     AND SEM_CNG_SALE.CNG_OFFICE_T LIKE '" + strCom + @"%'
				                         AND SEM_CNG_SALE.CNG_GUBN_CODE_T = 'M'
	       	                           GROUP BY SEM_CNG_SALE.CNG_GUBN_CODE_T,
		                                     SEM_CNG_SALE.CNG_DATE_T) A
	                           GROUP BY A.MM
	                          ) UA , PVT_TBL PT
                        WHERE UA.MM(+) = PT.MM
                        ORDER BY PT.MM";
       
       
     string sqlGrid;
     string strQtn = "\"";
     sqlGrid = @"   
              SELECT DECODE(A.CNG_GUBN_CODE_T,'C','CNG','M','메탄','') as " + strQtn + @"구분" + strQtn + @",
                     A.AMT_PLAN as " + strQtn + @"계획" + strQtn + @",
                     A.AMT_ACTL as " + strQtn + @"실적" + strQtn + @",
                     NVL(B.AMT_ACTL,0) as " + strQtn + @"전년동기실적" + strQtn + @",
                     (A.AMT_ACTL-A.AMT_PLAN) as " + strQtn + @"차이" + strQtn + @",
                     ROUND(A.AMT_RATE,4) as " + strQtn + @"달성율(%)" + strQtn + @",
                     (A.AMT_ACTL-B.AMT_ACTL) as " + strQtn + @"차 이" + strQtn + @",
                     ROUND(DECODE(NVL(B.AMT_ACTL,0),0,0,(A.AMT_ACTL/B.AMT_ACTL)*100),4) as " + strQtn + @"증가율(%)" + strQtn + @"
                FROM (SELECT SEM_CNG_SALE.CNG_GUBN_CODE_T,                
                             DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_QNT_PLAN),'TS',SUM(SEM_CNG_SALE.CNG_SUM_QNT_PLAN)) as QNT_PLAN,
                             DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_QNT_ACTUAL),'TS',SUM(SEM_CNG_SALE.CNG_SUM_QNT_ACTUAL)) as QTN_ACTL,
                             DECODE('" + strGbn + @"','MS',DECODE(SUM(SEM_CNG_SALE.CNG_QNT_PLAN),0,0,SUM(SEM_CNG_SALE.CNG_QNT_ACTUAL)/SUM(SEM_CNG_SALE.CNG_QNT_PLAN)*100),
                                         'TS',DECODE(SUM(SEM_CNG_SALE.CNG_SUM_QNT_PLAN),0,0,SUM(SEM_CNG_SALE.CNG_SUM_QNT_ACTUAL)/SUM(SEM_CNG_SALE.CNG_SUM_QNT_PLAN)*100)) as QTN_RATE,
                             DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_PLAN),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_PLAN))/1000 as AMT_PLAN,
                             DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_ACTUAL),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_ACTUAL))/1000 as AMT_ACTL,
                             DECODE('" + strGbn + @"','MS',DECODE(SUM(SEM_CNG_SALE.CNG_AMT_PLAN),0,0,SUM(SEM_CNG_SALE.CNG_AMT_ACTUAL)/SUM(SEM_CNG_SALE.CNG_AMT_PLAN)*100),
                                         'TS',DECODE(SUM(SEM_CNG_SALE.CNG_SUM_AMT_PLAN),0,0,SUM(SEM_CNG_SALE.CNG_SUM_AMT_ACTUAL)/SUM(SEM_CNG_SALE.CNG_SUM_AMT_PLAN)*100)) as AMT_RATE
                        FROM SEM_CNG_SALE SEM_CNG_SALE
                       WHERE SEM_CNG_SALE.CNG_DATE_T = '" + (strYY + cboMM.SelectedValue.ToString()) + @"'
                         AND SEM_CNG_SALE.CNG_OFFICE_T LIKE '" + strCom + @"%'
                       GROUP BY SEM_CNG_SALE.CNG_GUBN_CODE_T) A,
                     (SELECT SEM_CNG_SALE.CNG_GUBN_CODE_T,                
                             DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_QNT_ACTUAL),'TS',SUM(SEM_CNG_SALE.CNG_SUM_QNT_ACTUAL)) as QTN_ACTL,
                             DECODE('" + strGbn + @"','MS',SUM(SEM_CNG_SALE.CNG_AMT_ACTUAL),'TS',SUM(SEM_CNG_SALE.CNG_SUM_AMT_ACTUAL))/1000 as AMT_ACTL
                        FROM SEM_CNG_SALE SEM_CNG_SALE
                       WHERE SEM_CNG_SALE.CNG_DATE_T = '" + (strPYY + cboMM.SelectedValue.ToString()) + @"'
                         AND SEM_CNG_SALE.CNG_OFFICE_T LIKE '" + strCom + @"%'
                       GROUP BY SEM_CNG_SALE.CNG_GUBN_CODE_T) B
              WHERE A.CNG_GUBN_CODE_T = B.CNG_GUBN_CODE_T(+)";

        DataSet dsGrid = new DataSet();
        DataSet dsGrph1 = new DataSet();
        DataSet dsGrph2 = new DataSet();

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(sqlGrid, _connection);
        OracleDataAdapter daGrph1 = new OracleDataAdapter(sqlGrph1, _connection);
        OracleDataAdapter daGrph2 = new OracleDataAdapter(sqlGrph2, _connection);

        daGrid.Fill(dsGrid);
        daGrph1.Fill(dsGrph1);
        daGrph2.Fill(dsGrph2);

        this._setGraph(dsGrph1, dsGrph2);
        
        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsGrph1, DataSet dsGrph2)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 400, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1),2
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

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "달성율", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Series series4 = DundasCharts.CreateSeries(Chart2, "Series4", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series5 = DundasCharts.CreateSeries(Chart2, "Series5", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series6 = DundasCharts.CreateSeries(Chart2, "Series6", "Default", "달성율", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Chart1.DataSource = dsGrph1;
        Chart1.Series[series1.Name].ValueMembersY = "A_PLAN";
        Chart1.Series[series2.Name].ValueMembersY = "A_ACTL";
        Chart1.Series[series3.Name].ValueMembersY = "A_RATE";
        Chart1.Series[series1.Name].ValueMemberX = "MM";

        string strChartArea = Chart1.Series[series3.Name].ChartArea;
        series3.YAxisType = AxisType.Secondary;
        //Chart1.ChartAreas[series3.Name].AxisY.LabelStyle.Format = "P0";

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series2, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series3, 1.0, 2.0, true);

        //------------------------------------------------------Chart - METAN
        Chart2.DataSource = dsGrph2;
        Chart2.Series[series4.Name].ValueMembersY = "A_PLAN";
        Chart2.Series[series5.Name].ValueMembersY = "A_ACTL";
        Chart2.Series[series6.Name].ValueMembersY = "A_RATE";
        Chart2.Series[series4.Name].ValueMemberX = "MM";

        strChartArea = Chart2.Series[series6.Name].ChartArea;
        series6.YAxisType = AxisType.Secondary;
        //Chart2.ChartAreas[series3.Name].AxisY.LabelStyle.Format = "P0";
        Chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";

        DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart2, series4, 0.0, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart2, series5, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart2, series6, 1.0, 2.0, true);
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
        ch.Caption = "전년동기실적";
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
        
        try
        {
            int intWid = 0;
            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 120;
                }
                else if (i == 5 || i == 7)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                    e.Layout.Bands[0].Columns[i].Width = 90;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].Width = 100;
                }
            }
        }
        catch
        {
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int[] arrCol = new int[2] { 5, 7 };
        double[] arrRate = new double[2];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 99) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }

        //============================= 증가율처리
        double dblARate = (Convert.ToDouble(e.Row.Cells[7].Value) == 0) ? 0 : (Convert.ToDouble(e.Row.Cells[7].Value) - 100);
        e.Row.Cells[7].Value = dblARate;
        e.Row.Cells[7].Style.ForeColor = (dblARate >= 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
    }
}