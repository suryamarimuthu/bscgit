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

public partial class eis_SEM_Mana_R069 : EISPageBase
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
                if (intMM - 1 == int.Parse(strMM))
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
            /// </summary>

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboCom.SelectedIndex = 0;

            this.setDBCombo();

        }
    }

    private void setDBCombo()
    {
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R069.PROC_Mana_R069_03", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[1];

        arrOpm[0] = new OracleParameter("O_Mana_R069", OracleType.Cursor);
        arrOpm[0].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsCombo = new DataSet();
        OracleDataAdapter daCombo = new OracleDataAdapter(objCmd);

        daCombo.Fill(dsCombo);
        _connection.Close();
        objCmd = null;

        cboDEPT.Items.Clear();
        cboTEAM.Items.Clear();
        cboEXPS.Items.Clear();

        string strGbn = "";
        string strCd = "";
        string strNm = "";
        int intRow = dsCombo.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            strGbn = dsCombo.Tables[0].Rows[i]["GUBUN"].ToString();
            strCd = dsCombo.Tables[0].Rows[i]["ORG_CD"].ToString();
            strNm = dsCombo.Tables[0].Rows[i]["ORG_NM"].ToString();
            switch (strGbn)
            { 
                case "DEPT":
                    cboDEPT.Items.Add(new ListItem(strNm, strCd));
                    break;
                case "TEAM":
                    cboTEAM.Items.Add(new ListItem(strNm, strCd));
                    break;
                case "EXPS":
                    cboEXPS.Items.Add(new ListItem(strNm, strCd));
                    break;
                default:
                    break;
            }
        }
        cboDEPT.SelectedIndex = 0;
        cboTEAM.SelectedIndex = 0;
        cboEXPS.SelectedIndex = 0;
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        string sqlGrid = "";

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R069.PROC_Mana_R069_01", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R069.PROC_Mana_R069_02", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[6];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY+strMM);
        arrOpm[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpm[1].Value = cboCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_DEPT_CD", OracleType.VarChar, 12);
        arrOpm[2].Value = cboDEPT.SelectedValue;
        arrOpm[3] = new OracleParameter("i_TEAM_CD", OracleType.VarChar, 12);
        arrOpm[3].Value = cboTEAM.SelectedValue;
        arrOpm[4] = new OracleParameter("i_EXPS_CD", OracleType.VarChar, 12);
        arrOpm[4].Value = cboEXPS.SelectedValue;
        arrOpm[5] = new OracleParameter("O_Mana_R069", OracleType.Cursor);
        arrOpm[5].Direction = ParameterDirection.Output;

        OracleParameter[] arrOpmGrid = new OracleParameter[6];
        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("i_DEPT_CD", OracleType.VarChar, 12);
        arrOpmGrid[2].Value = cboDEPT.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("i_TEAM_CD", OracleType.VarChar, 12);
        arrOpmGrid[3].Value = cboTEAM.SelectedValue;
        arrOpmGrid[4] = new OracleParameter("i_EXPS_CD", OracleType.VarChar, 12);
        arrOpmGrid[4].Value = cboEXPS.SelectedValue;
        arrOpmGrid[5] = new OracleParameter("O_Mana_R069", OracleType.Cursor);
        arrOpmGrid[5].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpm[i]);
        }

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrph = new DataSet();
        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);

        daGrph.Fill(dsGrph);
        daGrid.Fill(dsGrid);

        this._setGraph(dsGrph);
        this._setGrid(dsGrid);

        _connection.Close();
        _connection = null;

        objCmdGrid = null;
        objCmdGrph = null;

    }

    private void _setGrid(DataSet dsGrid)
    {
        DataTable dtActual = dsGrid.Tables[0].Clone();
        DataRow drTmp = null;

        double dblCM_BUDGET = 0.00;
        double dblCM_ACTUAL = 0.00;
        double dblCM_RATE = 0.00;
        double dblTM_BUDGET = 0.00;
        double dblTM_ACTUAL = 0.00;
        double dblTM_RATE = 0.00;
        double dblPM_BUDGET = 0.00;
        double dblPM_ACTUAL = 0.00;
        double dblPM_RATE = 0.00;

        int intRow = dsGrid.Tables[0].Rows.Count;
        int intCol = dsGrid.Tables[0].Columns.Count;
        int i = 0;
        for (i = 0; i < intRow; i++)
        {
            drTmp = dtActual.NewRow();
            for (int j = 0; j < intCol; j++)
            {
                drTmp[j] = dsGrid.Tables[0].Rows[i][j];
            }
            dtActual.Rows.Add(drTmp);

            if (i < intRow -1 )
            {
                if (dsGrid.Tables[0].Rows[i][0].Equals(dsGrid.Tables[0].Rows[i +1][0]))
                {
                    dblCM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["CM_BUDGET"]);
                    dblCM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["CM_ACTUAL"]);
                    dblTM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["TM_BUDGET"]);
                    dblTM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["TM_ACTUAL"]);
                    dblPM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["PM_BUDGET"]);
                    dblPM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["PM_ACTUAL"]);
                }
                else
                {
                    dblCM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["CM_BUDGET"]);
                    dblCM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["CM_ACTUAL"]);
                    dblTM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["TM_BUDGET"]);
                    dblTM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["TM_ACTUAL"]);
                    dblPM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["PM_BUDGET"]);
                    dblPM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i]["PM_ACTUAL"]);   	
                	
                	
                    drTmp = dtActual.NewRow();
                    drTmp["ACCT_CD2"] = dsGrid.Tables[0].Rows[i]["ACCT_CD2"];
                    drTmp["ACCT_CD3"] = dsGrid.Tables[0].Rows[i]["ACCT_CD3"];
                    drTmp["ACCT_NM2"] = dsGrid.Tables[0].Rows[i]["ACCT_NM2"];
                    drTmp["ACCT_NM3"] = "소   계";
                    drTmp["CM_BUDGET"] = dblCM_BUDGET;
                    drTmp["CM_ACTUAL"] = dblCM_ACTUAL;
                    drTmp["CM_BARATE"] = (dblCM_BUDGET == 0) ? 0 : Math.Round(dblCM_ACTUAL / dblCM_BUDGET * 100, 1);
                    drTmp["TM_BUDGET"] = dblTM_BUDGET;
                    drTmp["TM_ACTUAL"] = dblTM_ACTUAL;
                    drTmp["TM_BARATE"] = (dblTM_BUDGET == 0) ? 0 : Math.Round(dblTM_ACTUAL / dblTM_BUDGET * 100, 1);
                    drTmp["PM_BUDGET"] = dblPM_BUDGET;
                    drTmp["PM_ACTUAL"] = dblPM_ACTUAL;
                    drTmp["PM_BARATE"] = (dblPM_BUDGET == 0) ? 0 : Math.Round(dblPM_ACTUAL / dblPM_BUDGET * 100, 1);
                    dtActual.Rows.Add(drTmp);

                    dblCM_BUDGET = 0.00;
                    dblCM_ACTUAL = 0.00;
                    dblTM_BUDGET = 0.00;
                    dblTM_ACTUAL = 0.00;
                    dblPM_BUDGET = 0.00;
                    dblPM_ACTUAL = 0.00;
                }
            }
        }

        if ((i > 0) && (i == (intRow)))
        {
            dblCM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i - 1]["CM_BUDGET"]);
            dblCM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i - 1]["CM_ACTUAL"]);
            dblTM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i - 1]["TM_BUDGET"]);
            dblTM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i - 1]["TM_ACTUAL"]);
            dblPM_BUDGET += Convert.ToDouble(dsGrid.Tables[0].Rows[i - 1]["PM_BUDGET"]);
            dblPM_ACTUAL += Convert.ToDouble(dsGrid.Tables[0].Rows[i - 1]["PM_ACTUAL"]);

            drTmp = dtActual.NewRow();
            drTmp["ACCT_CD2"] = dsGrid.Tables[0].Rows[i - 1]["ACCT_CD2"];
            drTmp["ACCT_CD3"] = dsGrid.Tables[0].Rows[i - 1]["ACCT_CD3"];
            drTmp["ACCT_NM2"] = dsGrid.Tables[0].Rows[i - 1]["ACCT_NM2"];
            drTmp["ACCT_NM3"] = "소   계";
            drTmp["CM_BUDGET"] = dblCM_BUDGET;
            drTmp["CM_ACTUAL"] = dblCM_ACTUAL;
            drTmp["CM_BARATE"] = (dblCM_BUDGET == 0) ? 0 : Math.Round(dblCM_ACTUAL / dblCM_BUDGET * 100, 1);
            drTmp["TM_BUDGET"] = dblTM_BUDGET;
            drTmp["TM_ACTUAL"] = dblTM_ACTUAL;
            drTmp["TM_BARATE"] = (dblTM_BUDGET == 0) ? 0 : Math.Round(dblTM_ACTUAL / dblTM_BUDGET * 100, 1);
            drTmp["PM_BUDGET"] = dblPM_BUDGET;
            drTmp["PM_ACTUAL"] = dblPM_ACTUAL;
            drTmp["PM_BARATE"] = (dblPM_BUDGET == 0) ? 0 : Math.Round(dblPM_ACTUAL / dblPM_BUDGET * 100, 1);
            dtActual.Rows.Add(drTmp);
        }

        UltraWebGrid1.DataSource = dtActual;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsGrid)
    {

        // 년도별 매출량 그래프
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 280
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "예산", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "집행율(%)", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Chart1.DataSource = dsGrid;
        series1.ValueMemberX = "MM";
        series1.ValueMembersY = "예산";
        series2.ValueMembersY = "실적";
        series3.ValueMembersY = "집행율";
        Chart1.DataBind();

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.ChartAreas[Chart1.Series[series3.Name].ChartArea].AxisY2.LabelStyle.Format = "P0";
        series3.YAxisType = AxisType.Secondary;

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.5, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series2, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series3, 1.0, 2.0, true);
       
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();
        e.Layout.Bands[0].Reset();
        //e.Layout.FrameStyle.Height = 160;

        e.Layout.Bands[0].Columns[0].Hidden = true;
        e.Layout.Bands[0].Columns[1].Hidden = true;

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader[] arrCh = new Infragistics.WebUI.UltraWebGrid.ColumnHeader[3];

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;

            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "구     분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "당 월 실 적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누 계 실 적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전 년 동 기";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        string[] arrColNm = new string[13] { "코드1", "코드2", "상위계정", "하위계정", "계획", "실적", "집행율(%)", "계획", "실적", "집행율(%)", "실적", "증감", "증가율(%)" };
        e.Layout.Bands[0].Columns[2].MergeCells = true;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].Header.Caption = arrColNm[i];
            if (i < 2)
            {
                e.Layout.Bands[0].Columns[i].Hidden = true;
            }
            else if (i == 2)
            {
                e.Layout.Bands[0].Columns[i].Width = 80;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else if (i == 3)
            {
                e.Layout.Bands[0].Columns[i].Width = 135;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = (i % 3 == 0) ? 60 : 80;
                e.Layout.Bands[0].Columns[i].Format = (i % 3 == 0) ? "#,##0.0" : "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }

    }
    protected void UltraWebGrid1_InitializeRow1(object sender, RowEventArgs e)
    {
        int[] arrCol = new int[3] { 6,9,12 };
        double[] arrRate = new double[3];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 99.999) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }

        //============================= 증가율처리
        double dblARate = (Convert.ToDouble(e.Row.Cells[12].Value) == 0) ? 0 : (Convert.ToDouble(e.Row.Cells[12].Value) - 100);
        e.Row.Cells[12].Value = dblARate;
        e.Row.Cells[12].Style.ForeColor = (dblARate >= 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
    }
}