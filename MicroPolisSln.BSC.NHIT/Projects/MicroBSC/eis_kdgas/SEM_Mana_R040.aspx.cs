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

public partial class eis_SEM_Mana_R040 : EISPageBase
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
        int intPYY = Convert.ToInt32(strYY) - 1;
        string strPYY = intPYY.ToString();
        string query = "";
        string strQN = "\"";

        query = @"
               SELECT CT.SEM_NM as "+ strQN +@"구분"+ strQN +@",
                      NVL(SUM(CT.C_PN),0) as "+ strQN +@"계획"+ strQN +@", 
                      NVL(SUM(CT.C_AL),0) as "+ strQN +@"실적"+ strQN +@",
					  NVL(SUM(PT.P_AL),0) as "+ strQN +@"전년동기실적"+ strQN +@",
                      NVL((SUM(CT.C_AL) - SUM(CT.C_PN)),0) as "+ strQN +@"차이"+ strQN +@",
                      NVL(ROUND(DECODE(SUM(CT.C_PN),0,0, ((SUM(CT.C_AL)/SUM(CT.C_PN))*100)),2),0) as "+ strQN +@"달성율(%)"+ strQN +@",
					  NVL(SUM(CT.C_AL) - (SUM(PT.P_AL)),0) as "+ strQN +@"차 이"+ strQN +@",
                      NVL(ROUND(DECODE(SUM(PT.P_AL),0,0, ((SUM(CT.C_AL)/SUM(PT.P_AL))*100)),2),0) as " + strQN + @"증가율(%)" + strQN + @"
                 FROM (SELECT SEM_CODE_MASTER.SEM_CODE2_T as SEM_CD,
                              SEM_CODE_MASTER.SEM_CODE2_NAME as SEM_NM,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_DEMAND_DEVELOP.DEVE_PLAN),'TS',SUM(SEM_DEMAND_DEVELOP.DEVE_SUM_PLAN)) as C_PN,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_DEMAND_DEVELOP.DEVE_ACTUAL),'TS',SUM(SEM_DEMAND_DEVELOP.DEVE_SUM_ACTUAL)) as C_AL
                         FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                              SEM_DEMAND_DEVELOP SEM_DEMAND_DEVELOP
                        WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                          AND SEM_DEMAND_DEVELOP.DEVE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                          AND SEM_DEMAND_DEVELOP.DEVE_DATE_T = '" + (strYY + strMM) + @"'
			  AND SEM_DEMAND_DEVELOP.DEVE_OFFICE_T LIKE '" + strCom + @"%'
                          AND SEM_CODE_MASTER.SEM_CODE3_T <> '120'
                        GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                              SEM_CODE_MASTER.SEM_CODE2_NAME) CT,
                      (SELECT SEM_CODE_MASTER.SEM_CODE2_T as SEM_CD,
                              SEM_CODE_MASTER.SEM_CODE2_NAME as SEM_NM,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_DEMAND_DEVELOP.DEVE_ACTUAL),'TS',SUM(SEM_DEMAND_DEVELOP.DEVE_SUM_ACTUAL)) as P_AL
                         FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                              SEM_DEMAND_DEVELOP SEM_DEMAND_DEVELOP
                        WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                          AND SEM_DEMAND_DEVELOP.DEVE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                          AND SEM_DEMAND_DEVELOP.DEVE_DATE_T = '" + (strPYY + strMM) + @"'
			  AND SEM_DEMAND_DEVELOP.DEVE_OFFICE_T LIKE '" + strCom + @"%'
                          AND SEM_CODE_MASTER.SEM_CODE3_T <> '120'
                        GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                              SEM_CODE_MASTER.SEM_CODE2_NAME) PT
                WHERE CT.SEM_CD = PT.SEM_CD(+)
                GROUP BY CT.SEM_CD,CT.SEM_NM ";

        DataSet dsGrid = new DataSet();
        DataSet dsGrph = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(query, _connection);
        daGrid.Fill(dsGrid);
        daGrid.Fill(dsGrph);

        this.setGridData(dsGrid);              
    }

    private void setGridData(DataSet iDsSet)
    {
        double dblPlan = 0.00;
        double dblActl = 0.00;
        double dblRlan = 0.00;
        double dblRslt = 0.00;


        int intRow = iDsSet.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            dblPlan += double.Parse(iDsSet.Tables[0].Rows[i]["계획"].ToString());
            dblActl += double.Parse(iDsSet.Tables[0].Rows[i]["실적"].ToString());
            dblRslt += double.Parse(iDsSet.Tables[0].Rows[i]["전년동기실적"].ToString());
        }

        DataRow drTmp = iDsSet.Tables[0].NewRow();
        drTmp["구분"] = "합       계";
        drTmp["계획"] = dblPlan;
        drTmp["실적"] = dblActl;
        drTmp["전년동기실적"] = dblRslt;
        drTmp["차이"] = dblActl - dblPlan;
        drTmp["달성율(%)"] = (dblPlan == 0) ? 0.00 : Math.Round((dblActl / dblPlan) * 100, 2);
        drTmp["차 이"] = dblActl - dblRslt;
        drTmp["증가율(%)"] = (dblRslt == 0) ? 0.00 : Math.Round((dblActl / dblRslt) * 100, 2);
        iDsSet.Tables[0].Rows.InsertAt(drTmp, 0);

        UltraWebGrid1.DataSource = iDsSet;
        UltraWebGrid1.DataBind();
    }

   
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int[] arrCol = new int[1] { 5 };
        double[] arrRate = new double[1];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            if (arrRate[intCol] > 100)
            {
                e.Row.Cells[arrCol[intCol]].Style.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                e.Row.Cells[arrCol[intCol]].Style.ForeColor = System.Drawing.Color.Red;
            }
        }
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

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i ==0)
            {
                e.Layout.Bands[0].Columns[i].Width = 110;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else if (i == 5 || i == 7)
            {
                e.Layout.Bands[0].Columns[i].Width = 80;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 100;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }

            if (e.Layout.Bands[0].Columns[i].Header.Caption == "차이" || e.Layout.Bands[0].Columns[i].Header.Caption == "차 이")
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = "차이";
            }
        }
    }

    protected void UltraWebGrid1_InitializeRow1(object sender, RowEventArgs e)
    {
        int[] arrCol = new int[2] { 5,7 };
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
}
