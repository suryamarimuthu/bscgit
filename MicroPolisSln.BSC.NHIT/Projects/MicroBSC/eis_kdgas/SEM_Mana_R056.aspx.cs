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

public partial class eis_SEM_Mana_R056 : System.Web.UI.Page
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
            this.cboGbn.Items.Clear();
            this.cboPQ.Items.Clear();

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

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;

            this.cboPQ.Items.Add(new ListItem("금액", "PR"));
            this.cboPQ.Items.Add(new ListItem("수량", "QN"));
            cboPQ.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYM = this.cboYY.SelectedValue+this.cboMM.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        string strPQ = this.cboPQ.SelectedValue;
  
        string query = "";

        query = @"
                  SELECT C.MM,
                         SUM(C.PLAN_01) as COL1, SUM(C.ACTL_01) as COL2,
                         SUM(C.PLAN_02) as COL3, SUM(C.ACTL_02) as COL4,
                         SUM(C.PLAN_03) as COL5, SUM(C.ACTL_03) as COL6,
                         (SUM(C.PLAN_01)+SUM(C.PLAN_02)+SUM(C.PLAN_03)) as COL7,
                         (SUM(C.ACTL_01)+SUM(C.ACTL_02)+SUM(C.ACTL_03)) as COL8,
                         ((SUM(C.ACTL_01)+SUM(C.ACTL_02)+SUM(C.ACTL_03)) - (SUM(C.PLAN_01)+SUM(C.PLAN_02)+SUM(C.PLAN_03))) as COL9,
                         ROUND(DECODE((SUM(C.PLAN_01)+SUM(C.PLAN_02)+SUM(C.PLAN_03)),0,0,
                         (SUM(C.ACTL_01)+SUM(C.ACTL_02)+SUM(C.ACTL_03))/(SUM(C.PLAN_01)+SUM(C.PLAN_02)+SUM(C.PLAN_03))*100),4) as COL10
                   FROM (SELECT B.MM,
                         
                                NVL(DECODE('" + strPQ+@"','PR',B.AMT_PLAN,'QN',B.QNT_PLAN,0),0) as PLAN_01,
                                NVL(DECODE('" + strPQ+@"','PR',B.AMT_ACTL,'QN',B.QNT_ACTL,0),0) as ACTL_01,
                                0 as PLAN_02, 0 as ACTL_02, 0 as PLAN_03, 0 as ACTL_03
                          FROM (SELECT SUBSTR(GS.GASM_DATE_T,1,4) as YY,
                                       SUBSTR(GS.GASM_DATE_T,5,2) as MM,
                                       DECODE('"+strGbn+@"','MS',GS.GASM_PLAN_QNT,    'TS',GS.GASM_SUM_PLAN_QNT) as QNT_PLAN,
                                       DECODE('"+strGbn+@"','MS',GS.GASM_ACTUAL_QNT,'TS',GS.GASM_SUM_ACTUAL_QNT) as QNT_ACTL,
                                       nvl(DECODE('"+strGbn+@"','MS',GS.GASM_PLAN_AMT,    'TS',GS.GASM_SUM_PLAN_AMT),0)/1000 as AMT_PLAN,
                                       nvl(DECODE('"+strGbn+@"','MS',GS.GASM_ACTUAL_AMT,'TS',GS.GASM_SUM_ACTUAL_AMT),0)/1000 as AMT_ACTL
                                  FROM SEM_CODE_MASTER CM,
                                       SEM_GASMACHINE_SALE GS
                                 WHERE CM.SEM_CODE1_T = '16'
                                   AND GS.GASM_GAS_CODE_T='10000'
                                   AND GS.GASM_DATE_T BETWEEN (SUBSTR('"+strYM+@"',1,4)||'01') AND '"+strYM+@"' 
                                   AND GS.GASM_GAS_CODE_T = CM.SEM_CODE2_T
                                   AND GS.GASM_SALE_CODE_T='01') B
                         UNION ALL
                        SELECT B.MM,
                               0 as PLAN_01, 0 as ACTL_01, 
                               NVL(DECODE('"+strPQ+@"','PR',B.AMT_PLAN,'QN',B.QNT_PLAN,0),0) as PLAN_02,
                               NVL(DECODE('"+strPQ+@"','PR',B.AMT_ACTL,'QN',B.QNT_ACTL,0),0) as ACTL_02,
                               0 as PLAN_03, 0 as ACTL_03
                         FROM (SELECT SUBSTR(GS.GASM_DATE_T,1,4) as YY,
                                      SUBSTR(GS.GASM_DATE_T,5,2) as MM,
                                      DECODE('"+strGbn+@"','MS',GS.GASM_PLAN_QNT,'TS',GS.GASM_SUM_PLAN_QNT) as QNT_PLAN,
                                      DECODE('"+strGbn+@"','MS',GS.GASM_ACTUAL_QNT,'TS',GS.GASM_SUM_ACTUAL_QNT) as QNT_ACTL,
                                      nvl(DECODE('"+strGbn+@"','MS',GS.GASM_PLAN_AMT,'TS',GS.GASM_SUM_PLAN_AMT),0)/1000 as AMT_PLAN,
                                      nvl(DECODE('"+strGbn+@"','MS',GS.GASM_ACTUAL_AMT,'TS',GS.GASM_SUM_ACTUAL_AMT),0)/1000 as AMT_ACTL
                                 FROM SEM_CODE_MASTER CM,
                                      SEM_GASMACHINE_SALE GS
                                WHERE CM.SEM_CODE1_T = '16'
                                  AND GS.GASM_GAS_CODE_T='10000'
                                  AND GS.GASM_DATE_T BETWEEN (SUBSTR('"+strYM+@"',1,4)||'01') AND '"+strYM+@"' 
                                  AND GS.GASM_GAS_CODE_T = CM.SEM_CODE2_T
                                  AND GS.GASM_SALE_CODE_T='02') B
                        UNION ALL
                       SELECT B.MM,
                              0 as PLAN_01, 0 as ACTL_01, 
                              0 as PLAN_02, 0 as ACTL_02,
                              NVL(DECODE('"+strPQ+@"','PR',B.AMT_PLAN,'QN',B.QNT_PLAN,0),0) as PLAN_03,
                              NVL(DECODE('"+strPQ+@"','PR',B.AMT_ACTL,'QN',B.QNT_ACTL,0),0) as ACTL_03				         
                        FROM (SELECT SUBSTR(GS.GASM_DATE_T,1,4) as YY,
                                     SUBSTR(GS.GASM_DATE_T,5,2) as MM,
                                     DECODE('"+strGbn+@"','MS',GS.GASM_PLAN_QNT,'TS',GS.GASM_SUM_PLAN_QNT) as QNT_PLAN,
                                     DECODE('"+strGbn+@"','MS',GS.GASM_ACTUAL_QNT,'TS',GS.GASM_SUM_ACTUAL_QNT) as QNT_ACTL,
                                     nvl(DECODE('"+strGbn+@"','MS',GS.GASM_PLAN_AMT,'TS',GS.GASM_SUM_PLAN_AMT),0)/1000 as AMT_PLAN,
                                     nvl(DECODE('"+strGbn+@"','MS',GS.GASM_ACTUAL_AMT,'TS',GS.GASM_SUM_ACTUAL_AMT),0)/1000 as AMT_ACTL
                                FROM SEM_CODE_MASTER CM,             
                                     SEM_GASMACHINE_SALE GS
                               WHERE CM.SEM_CODE1_T = '16'          
                                 AND GS.GASM_GAS_CODE_T='10000'
                                 AND GS.GASM_DATE_T BETWEEN (SUBSTR('"+strYM+@"',1,4)||'01') AND '"+strYM+@"' 
                                 AND GS.GASM_GAS_CODE_T = CM.SEM_CODE2_T
                                 AND GS.GASM_SALE_CODE_T IN ('03','04')) B
		 ) C
		 GROUP BY C.MM
         ";

        
        DataSet dsGrid = new DataSet();        
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(query, _connection);        
        daGrid.Fill(dsGrid);
       
        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }

    
    private DataTable Tbl_Change_Rate()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SGubun", typeof(string));
        dt.Columns.Add("Sale_Rate", typeof(double));
        return dt;
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
        ch.Caption = "년월";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "고객지원센터";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "울산특판";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "시공업체/기타";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "합계";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획대비실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        try
        {
            //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
            ch = e.Layout.Bands[0].Columns[0].Header;

            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 50;
                }
                else if (i == 10)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                    e.Layout.Bands[0].Columns[i].Width = 60;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].Width = 75;
                }
            }
        }
        catch
        {
        }
    }
    protected void UltraWebGrid1_InitializeRow1(object sender, RowEventArgs e)
    {
        int[] arrCol = new int[1] { 10 };
        double[] arrRate = new double[1];
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
    }
} 