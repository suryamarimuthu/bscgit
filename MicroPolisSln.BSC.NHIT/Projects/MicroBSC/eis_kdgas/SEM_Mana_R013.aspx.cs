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

public partial class eis_SEM_Mana_R013 : EISPageBase
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
            this.cboCom.SelectedIndex = 0;

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
        int intFYY = Convert.ToInt32(strYY) - 2;
        int intPYY = Convert.ToInt32(strYY) - 1;

        string strFYY = intFYY.ToString();
        string strPYY = intPYY.ToString();
        string strCYY = strYY;

        string sqlLine = "";
        string strQtn = "\"";
        sqlLine = @"SELECT B.YY,
	                   SUM(B.M01) as " + strQtn + @"1월" + strQtn + @", SUM(B.M02) as " + strQtn + @"2월" + strQtn + @", 
                           SUM(B.M03) as " + strQtn + @"3월" + strQtn + @", SUM(B.M04) as " + strQtn + @"4월" + strQtn + @",
			   SUM(B.M05) as " + strQtn + @"5월" + strQtn + @", SUM(B.M06) as " + strQtn + @"6월" + strQtn + @", 
                           SUM(B.M07) as " + strQtn + @"7월" + strQtn + @", SUM(B.M08) as " + strQtn + @"8월" + strQtn + @",
			   SUM(B.M09) as " + strQtn + @"9월" + strQtn + @", SUM(B.M10) as " + strQtn + @"10월" + strQtn + @", 
                           SUM(B.M11) as " + strQtn + @"11월" + strQtn + @", SUM(B.M12) as " + strQtn + @"12월" + strQtn + @"  
	            FROM ( SELECT A.YY,
			          DECODE(A.MM,'01', A.S_RSLT, 0) as M01, DECODE(A.MM,'02', A.S_RSLT, 0) as M02, 
			          DECODE(A.MM,'03', A.S_RSLT, 0) as M03, DECODE(A.MM,'04', A.S_RSLT, 0) as M04, 
			          DECODE(A.MM,'05', A.S_RSLT, 0) as M05, DECODE(A.MM,'06', A.S_RSLT, 0) as M06,
				  DECODE(A.MM,'07', A.S_RSLT, 0) as M07, DECODE(A.MM,'08', A.S_RSLT, 0) as M08, 
				  DECODE(A.MM,'09', A.S_RSLT, 0) as M09, DECODE(A.MM,'10', A.S_RSLT, 0) as M10, 
				  DECODE(A.MM,'11', A.S_RSLT, 0) as M11, DECODE(A.MM,'12', A.S_RSLT, 0) as M12  
			    FROM (SELECT SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,1,4) as YY,
					 SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,5,2) as MM,
                                         round(NVL(DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_QNT_ACTUAL),'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_QNT_ACTUAL)),0)/1000,0) as S_RSLT
                                    FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                         SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                                   WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                                     AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                     AND SEM_SALE_MONTHLY.SALE_DATE_T BETWEEN '" + strFYY + @"01' AND '" + (strCYY+strCYY) + @"'
                                     AND SEM_SALE_MONTHLY.SALE_OFFICE_T like  '" + strCom + @"%'
                                   GROUP BY SEM_SALE_MONTHLY.SALE_DATE_T) A
				        ) B
		        GROUP BY B.YY";

     string sqlPie;
     sqlPie = @"SELECT SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,1,4) as YY,
		       MAX(SEM_CODE_MASTER.SEM_CODE2_NAME) as SGBUN_NM,
                       NVL(DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_QNT_ACTUAL),'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_QNT_ACTUAL)),0)/1000 as S_RSLT
                  FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                       SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                 WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                   AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                   AND SEM_SALE_MONTHLY.SALE_DATE_T BETWEEN '" + (strFYY) + @"01' AND '" + (strCYY+strMM) + @"'
                   AND SEM_SALE_MONTHLY.SALE_OFFICE_T like  '" + strCom + @"%'
                 GROUP BY SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,1,4),
			  SEM_CODE_MASTER.SEM_CODE2_T";


        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;

        DataSet dsLine = new DataSet();
        DataSet dsPie = new DataSet();
        OracleDataAdapter daLine = new OracleDataAdapter(sqlLine, _connection);
        OracleDataAdapter daPie = new OracleDataAdapter(sqlPie, _connection);
        daLine.Fill(dsLine);
        daPie.Fill(dsPie);

        this._setGraph(dsLine, dsPie);
    }

    private void _setGraph(DataSet dsLine, DataSet dsPie)
    {
        string strCYY = cboYY.SelectedValue;
        string strFYY = (int.Parse(strCYY) - 2).ToString();
        string strPYY = (int.Parse(strCYY) - 1).ToString();
        string strCMM = cboMM.SelectedValue;
        //strCYY = strCYY + "년";

        // 년도별 매출량 그래프
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 250
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        // 전년매출비중 파이그래프
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 265, 200
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        // 당년매출비중 파이그래프
        DundasCharts.DundasChartBase(Chart3, ChartImageType.Flash, 265, 200
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        // 익년매출비중 파이그래프
        DundasCharts.DundasChartBase(Chart4, ChartImageType.Flash, 265, 200
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        //================================================================== LINE GRAPH
        Series[] oasrType = new Series[dsLine.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsLine.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["YY"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsLine.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = dsLine.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            
            oasrType[i].MarkerStyle = GetMarkerStyle(i);
            oasrType[i].MarkerColor = GetChartColor(i);
            oasrType[i].MarkerBorderColor = GetMarkerBorderColor(i);
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsLine.Tables[0].DefaultView;
        Chart1.DataBind();


        //=================================================================== PIE GRAPH
        Series series2 = DundasCharts.CreateSeries(Chart2, "Series2", "Default", "매출비중", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart3, "Series3", "Default", "매출비중", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series4 = DundasCharts.CreateSeries(Chart4, "Series4", "Default", "매출비중", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        series2.FontColor = Color.White;
        series3.FontColor = Color.White;
        series4.FontColor = Color.White;
       

        double dblPTAmt = 0.00;
        double dblCTAmt = 0.00;
        double dblNTAmt = 0.00;

        double dblPRate = 0.00;
        double dblCRate = 0.00;
        double dblNRate = 0.00;
        double dblEtcRate = 0.00;

        DataRow[] drPPie = dsPie.Tables[0].Select("YY='" + strFYY + "'", "S_RSLT DESC");
        DataRow[] drCPie = dsPie.Tables[0].Select("YY='" + strPYY + "'", "S_RSLT DESC");
        DataRow[] drNPie = dsPie.Tables[0].Select("YY='" + strCYY + "'", "S_RSLT DESC");

        for (int i = 0; i < drPPie.Length; i++)
        {
            dblPTAmt += double.Parse(drPPie[i]["S_RSLT"].ToString());
        }
        for (int i = 0; i < drCPie.Length; i++)
        {
            dblCTAmt += double.Parse(drCPie[i]["S_RSLT"].ToString());
        }
        for (int i = 0; i < drNPie.Length; i++)
        {
            dblNTAmt += double.Parse(drNPie[i]["S_RSLT"].ToString());
        }

        dblEtcRate = 0.00;
        int intLoop = 0;
        string strLabel = "";
        for (intLoop = 0; intLoop < drPPie.Length; intLoop++)
        {
            dblPRate = (dblPTAmt == 0) ? 0 : (double.Parse(drPPie[intLoop]["S_RSLT"].ToString()) / dblPTAmt) * 100;
            if (intLoop < 3)
            {
                strLabel = drPPie[intLoop]["SGBUN_NM"].ToString() +"(" + Math.Round(dblPRate,1).ToString() +"%)";
                Chart2.Series[series2.Name].Points.AddXY(strLabel, dblPRate);
            }
            else
            {
                dblEtcRate += dblPRate;
            }
        }
        if (drPPie.Length > 3)
        {
            Chart2.Series[series2.Name].Points.AddXY("기타", dblEtcRate);
        }

        dblEtcRate = 0.00;
        for (intLoop = 0; intLoop < drCPie.Length; intLoop++)
        {
            dblCRate = (dblCTAmt == 0) ? 0 : (double.Parse(drCPie[intLoop]["S_RSLT"].ToString()) / dblCTAmt) * 100;
            if (intLoop < 3)
            {
                strLabel = drCPie[intLoop]["SGBUN_NM"].ToString() + "(" + Math.Round(dblCRate, 1).ToString() + "%)";
                Chart3.Series[series3.Name].Points.AddXY(strLabel, dblCRate);
            }
            else
            {
                dblEtcRate += dblCRate;
            }
        }
        if (drCPie.Length > 3)
        {
            Chart3.Series[series3.Name].Points.AddXY("기타", dblEtcRate);
        }

        dblEtcRate = 0.00;
        for (intLoop = 0; intLoop < drNPie.Length; intLoop++)
        {
            dblNRate = (dblNTAmt==0) ? 0 :(double.Parse(drNPie[intLoop]["S_RSLT"].ToString()) / dblNTAmt) * 100;
            if (intLoop < 3)
            {
                strLabel = drNPie[intLoop]["SGBUN_NM"].ToString() + "(" + Math.Round(dblNRate, 1).ToString() + "%)";
                Chart4.Series[series4.Name].Points.AddXY(strLabel, dblNRate);
            }
            else
            {
                dblEtcRate += dblNRate;
            }
        }
        if (drNPie.Length > 3)
        {
            Chart4.Series[series4.Name].Points.AddXY("기타", dblEtcRate);
        }

        Chart2.Titles.Add(strFYY);
        Chart3.Titles.Add(strPYY);
        Chart4.Titles.Add(strCYY);
        Chart2.Titles[0].Text = (strFYY + "년");
        Chart3.Titles[0].Text = (strPYY + "년");
        Chart4.Titles[0].Text = (strCYY + "년");
    }

    private DataTable Tbl_Change_Rate()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SGubun", typeof(string));
        dt.Columns.Add("Sale_Rate", typeof(double));
        return dt;
    }

}