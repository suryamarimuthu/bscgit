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

public partial class eis_SEM_Mana_R029 : System.Web.UI.Page
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
            string[] arrMM = {"01","03","05","07","09","11"};
            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            if (intMM % 2 == 0)
            {
                intMM = intMM - 1;
            }

            this.cboYY.Items.Clear();
            this.cboMM.Items.Clear();
            this.cboCom.Items.Clear();

            for (intLP = 0; intLP < arrMM.Length; intLP++)
            {
                strMM = arrMM[intLP].ToString();
                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM == int.Parse(strMM))
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY+3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }

            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));

            this.cboYY.SelectedValue = intYY.ToString();
            /// </summary>
        }
    }

    private void _queryGrid()
    {
        string strCYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strYM = strCYY + strMM;
        string strCom = this.cboCom.SelectedValue;
        int intPYY = Convert.ToInt32(strCYY) - 1;
        int intFYY = Convert.ToInt32(strCYY) - 2;
        string strPYY = intPYY.ToString();
        string strFYY = intFYY.ToString();
        string strSQL1;
        string strSQL2;
        string strSQL3;

        strSQL1 = @"
          SELECT A.SEM_CD2 CODE, A.SEM_CDNM2 CODENM, A.MM,SUM(A.COST) COST, SUM(A.EXPENSE) EXPENSE, SUM(A.PRICE) PRICE
            FROM (
                  SELECT SUBSTR(SEM_LNG_PRICE.LNG_DATE_T,1,4) YY,
                         SUBSTR(SEM_LNG_PRICE.LNG_DATE_T,5,2) MM,
                  	     DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','910',SEM_CODE_MASTER.SEM_CODE2_T) SEM_CD2,
                  	     DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','평균',SEM_CODE_MASTER.SEM_CODE2_NAME) SEM_CDNM2,
                         SEM_LNG_PRICE.LNG_GUBN_CODE_T GUBUN_CD,
                         SEM_LNG_PRICE.LNG_COST COST,
                         SEM_LNG_PRICE.LNG_EXPENSE EXPENSE,
                         SEM_LNG_PRICE.LNG_PRICE PRICE,
                         DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T, '910', '평균',SEM_CODE_MASTER.SEM_CODE3_NAME) SEM_CDNM3
                    FROM SEM_LNG_PRICE SEM_LNG_PRICE,
                         SEM_CODE_MASTER SEM_CODE_MASTER
                   WHERE SEM_LNG_PRICE.LNG_DATE_T BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE('" + strYM + @"','YYYYMM'),-12),'YYYYMM') AND TO_CHAR(ADD_MONTHS(TO_DATE('" + strYM + @"','YYYYMM'),-1),'YYYYMM')
                     AND SEM_CODE_MASTER.SEM_CODE1_T = '06'
                     AND SEM_LNG_PRICE.LNG_OFFICE_T = '" +strCom+@"'
                     AND SEM_LNG_PRICE.LNG_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                   ORDER BY SEM_LNG_PRICE.LNG_GUBN_CODE_T) A
           GROUP BY A.SEM_CD2,A.SEM_CDNM2, A.YY, A.MM
           ORDER BY A.MM";

        strSQL2 = @"
          SELECT A.YY, A.MM, ROUND(AVG(A.COST),2) COST, ROUND(AVG(A.EXPENSE),2) EXPENSE, ROUND(AVG(A.PRICE),2) PRICE
            FROM (
                  SELECT SUBSTR(SEM_LNG_PRICE.LNG_DATE_T,1,4) YY,
                         SUBSTR(SEM_LNG_PRICE.LNG_DATE_T,5,2) MM,
                  	     DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','910',SEM_CODE_MASTER.SEM_CODE2_T) SEM_CD2,
                  	     DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','평균',SEM_CODE_MASTER.SEM_CODE2_NAME) SEM_CDNM2,
                         SEM_LNG_PRICE.LNG_GUBN_CODE_T GUBUN_CD,
                         SEM_LNG_PRICE.LNG_COST COST,
                         SEM_LNG_PRICE.LNG_EXPENSE EXPENSE,
                         SEM_LNG_PRICE.LNG_PRICE PRICE,
                         DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T, '910', '평균',SEM_CODE_MASTER.SEM_CODE3_NAME) SEM_CDNM3
                    FROM SEM_LNG_PRICE SEM_LNG_PRICE,
                         SEM_CODE_MASTER SEM_CODE_MASTER
                   WHERE SEM_LNG_PRICE.LNG_DATE_T BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE('" + strYM + @"','YYYYMM'),-36),'YYYYMM') AND TO_CHAR(ADD_MONTHS(TO_DATE('" + strYM + @"','YYYYMM'),-1),'YYYYMM')
                     AND SEM_CODE_MASTER.SEM_CODE1_T = '06'
                     AND SEM_LNG_PRICE.LNG_OFFICE_T = '" + strCom + @"'
                     AND SEM_LNG_PRICE.LNG_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                   ORDER BY SEM_LNG_PRICE.LNG_GUBN_CODE_T) A
           GROUP BY A.YY, A.MM";

        strSQL3 = @"
          SELECT B.SEM_CDNM2 T_NAME, B.SEM_CDNM3 M_NAME,
                 NVL(B.COST,0) as CP_COST, 
                 NVL(A.COST,0) as CC_COST, 
                 NVL((A.COST-B.COST),0) as C_DIFF, 
                 NVL(ROUND(DECODE(NVL(B.COST,0),0,0,(A.COST/B.COST)*100),2),0) as C_RATE, 
          	     NVL(A.EXPENSE,0) as C_EXPS, 
                 NVL(B.PRICE,0) as PP_PRICE, 
                 NVL(A.PRICE,0) as CP_PRICE, 
                 NVL((A.PRICE-B.PRICE),0) as P_DIFF,
          	     NVL(ROUND(DECODE(NVL(B.PRICE,0),0,0,(A.PRICE/B.PRICE)*100),2),0) as P_RATE
            FROM (SELECT DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','910',SEM_CODE_MASTER.SEM_CODE2_T) SEM_CD2,
                         DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','평균',SEM_CODE_MASTER.SEM_CODE2_NAME) SEM_CDNM2,
                         SEM_LNG_PRICE.LNG_GUBN_CODE_T SEM_CD3,
                         DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T, '910', '평균',SEM_CODE_MASTER.SEM_CODE3_NAME) SEM_CDNM3,  
                         SEM_LNG_PRICE.LNG_COST COST,
          			     SEM_LNG_PRICE.LNG_EXPENSE EXPENSE,
                         SEM_LNG_PRICE.LNG_PRICE PRICE
                    FROM SEM_LNG_PRICE SEM_LNG_PRICE,
                         SEM_CODE_MASTER SEM_CODE_MASTER
                   WHERE SEM_LNG_PRICE.LNG_DATE_T = '" + strYM + @"'
                     AND SEM_CODE_MASTER.SEM_CODE1_T = '06'
                     AND SEM_LNG_PRICE.LNG_OFFICE_T = '" + strCom + @"'
                     AND SEM_LNG_PRICE.LNG_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T) A,
                 (SELECT DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','910',SEM_CODE_MASTER.SEM_CODE2_T) SEM_CD2,
                  	     DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T,'910','평균',SEM_CODE_MASTER.SEM_CODE2_NAME) SEM_CDNM2,
                         SEM_LNG_PRICE.LNG_GUBN_CODE_T SEM_CD3,
                         DECODE(SEM_LNG_PRICE.LNG_GUBN_CODE_T, '910', '평균',SEM_CODE_MASTER.SEM_CODE3_NAME) SEM_CDNM3,  
                         SEM_LNG_PRICE.LNG_COST COST,
                         SEM_LNG_PRICE.LNG_PRICE PRICE
                    FROM SEM_LNG_PRICE SEM_LNG_PRICE,
                         SEM_CODE_MASTER SEM_CODE_MASTER
                   WHERE SEM_LNG_PRICE.LNG_DATE_T = (SELECT MAX(SEM_LNG_PRICE.LNG_DATE_T) FROM SEM_LNG_PRICE WHERE SEM_LNG_PRICE.LNG_DATE_T < '" + strYM + @"')
                     AND SEM_CODE_MASTER.SEM_CODE1_T = '06'
                     AND SEM_LNG_PRICE.LNG_OFFICE_T = '" + strCom + @"'
                     AND SEM_LNG_PRICE.LNG_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T) B
            WHERE A.SEM_CD2(+) = B.SEM_CD2
              AND A.SEM_CD3(+) = B.SEM_CD3";

        //DataSet dsGrph1 = new DataSet();
        //DataSet dsGrph2 = new DataSet();
        DataSet dsGrph3 = new DataSet();

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        //OracleDataAdapter daGrph1 = new OracleDataAdapter(strSQL1, _connection);
        //OracleDataAdapter daGrph2 = new OracleDataAdapter(strSQL2, _connection);
        OracleDataAdapter daGrph3 = new OracleDataAdapter(strSQL3, _connection);

        //daGrph1.Fill(dsGrph1);
        //daGrph2.Fill(dsGrph2);
        daGrph3.Fill(dsGrph3);

        UltraWebGrid1.DataSource = dsGrph3;
        UltraWebGrid1.DataBind();

        //this._setGraph(dsGrph1, dsGrph2);


    }

    private void _setGraph(DataSet dsGrph1, DataSet dsGrph2)
    {
        string strCYY = cboYY.SelectedValue;
        string strPYY = (int.Parse(strCYY) - 1).ToString();
        string strFYY = (int.Parse(strCYY) - 2).ToString();
        string strCMM = cboMM.SelectedValue;
        //strCYY = strCYY + "년";

        // 용도별요금 추이 분석
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 400, 250
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
        // 년도별 평균 단가 추이
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 400, 250
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        string tpCode = "";
        string tpCdNm = "";
        string bfCode = "";
        string afCode = "";
        bool blnSW = false;

        tpCdNm = "";
        for (int i = 0; i < dsGrph1.Tables[0].Rows.Count; i++)
        {
            blnSW = false;
            tpCdNm = dsGrph1.Tables[0].Rows[i]["CODENM"].ToString();

            for (int j = 0; j < Chart1.Series.Count; j++)
            {
                if (tpCdNm == Chart1.Series[j].Name.ToString())
                {
                    blnSW = true;
                    break;
                }
            }


            // 범례가 5개 이상일경우 범례를 하나 추가한다
            if (!blnSW)
            {
                Series arrSeries = Chart1.Series.Add(tpCdNm);
                //-------------------------------------------------- Legend 추가
                if (Chart1.Series.Count == 5)
                {
                    Chart1.Legends.Add(new Legend("LGD2"));
                    Chart1.Legends["LGD2"].Alignment = StringAlignment.Center;
                    Chart1.Legends["LGD2"].Docking = LegendDocking.Top;
                    Chart1.Legends["LGD2"].ShadowOffset = 0;
                    Chart1.Legends["LGD2"].LegendStyle = LegendStyle.Row;
                    Chart1.Legends["LGD2"].Font = new Font(Chart1.Legends["Default"].Font.FontFamily, 9);
                }
                
                if (Chart1.Series.Count > 4)
                {
                    Chart1.Series[tpCdNm].Legend = "LGD2";
                }
                //--------------------------------------------------
                Chart1.Series[tpCdNm].LegendText = tpCdNm;
                Chart1.Series[tpCdNm].Type = SeriesChartType.Line;
                Chart1.Series[tpCdNm].BorderWidth = 3;
                Chart1.Series[tpCdNm].MarkerStyle = MarkerStyle.Circle;
                arrSeries = null;
            }
        }

        for (int i = 0; i < dsGrph1.Tables[0].Rows.Count; i++)
        {
            Chart1.Series[dsGrph1.Tables[0].Rows[i]["CODENM"].ToString()].Points.AddXY(dsGrph1.Tables[0].Rows[i]["MM"], dsGrph1.Tables[0].Rows[i]["PRICE"]);
        }

        tpCdNm = "";
        for (int i = 0; i < dsGrph2.Tables[0].Rows.Count; i++)
        {
            blnSW = false;
            tpCode = dsGrph2.Tables[0].Rows[i]["YY"].ToString();

            for (int j = 0; j < Chart2.Series.Count; j++)
            {
                if (tpCode == Chart2.Series[j].Name.ToString())
                {
                    blnSW = true;
                    break;
                }
            }

            if (!blnSW)
            {
                Series arrSeries = Chart2.Series.Add(tpCode);
                Chart2.Series[tpCode].LegendText = tpCode;
                Chart2.Series[tpCode].Type = SeriesChartType.Line;
                Chart2.Series[tpCode].BorderWidth = 3;
                Chart2.Series[tpCode].MarkerStyle = MarkerStyle.Circle;
                arrSeries = null;
            }
        }

        for (int i = 0; i < dsGrph2.Tables[0].Rows.Count; i++)
        {
            Chart2.Series[dsGrph2.Tables[0].Rows[i]["YY"].ToString()].Points.AddXY(dsGrph2.Tables[0].Rows[i]["MM"], dsGrph2.Tables[0].Rows[i]["COST"]);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        Chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);

        //DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, false);
        //DundasAnimations.GrowingAnimation(Chart1, series2, 3.0, 4.0, true);
        //DundasAnimations.GrowingAnimation(Chart1, series3, 4.0, 6.0, true);
    }

    private DataTable Tbl_Grid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("serNo", typeof(int));
        dt.Columns.Add("sYY", typeof(string));
        dt.Columns.Add("SGBUN_CD", typeof(string));
        dt.Columns.Add("SGBUN_NM", typeof(string));
        dt.Columns.Add("AMT_01", typeof(double));
        dt.Columns.Add("AMT_02", typeof(double));
        dt.Columns.Add("AMT_03", typeof(double));
        dt.Columns.Add("AMT_04", typeof(double));
        dt.Columns.Add("AMT_05", typeof(double));
        dt.Columns.Add("AMT_06", typeof(double));
        dt.Columns.Add("AMT_07", typeof(double));
        dt.Columns.Add("AMT_08", typeof(double));
        dt.Columns.Add("AMT_09", typeof(double));
        dt.Columns.Add("AMT_10", typeof(double));
        dt.Columns.Add("AMT_11", typeof(double));
        dt.Columns.Add("AMT_12", typeof(double));
        return dt;
    }

    protected void UltraWebGrid1_InitializeLayout1(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();
        e.Layout.Bands[0].Reset();

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader[] arrCh = new Infragistics.WebUI.UltraWebGrid.ColumnHeader[3];

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "구      분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "원 료 가 격";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "소비자가격";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;
        
        ch = e.Layout.Bands[0].Columns[6].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanY = 2;
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        int[] arrCol = new int[2] { 5, 10 };
        double[] arrRate = new double[2];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            if (arrRate[intCol] >= 0)
            {
                e.Row.Cells[arrCol[intCol]].Style.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                e.Row.Cells[arrCol[intCol]].Style.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}