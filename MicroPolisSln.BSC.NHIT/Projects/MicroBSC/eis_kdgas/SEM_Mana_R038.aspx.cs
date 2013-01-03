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

public partial class eis_SEM_Mana_R038 : EISPageBase
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
        string strYMD = (cboYY.SelectedValue + cboMM.SelectedValue);

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R038.PROC_Mana_R038_02", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R038.PROC_Mana_R038_01", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = cboCom.SelectedValue;
        arrOpmGrph[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmGrph[2].Value = cboGbn.SelectedValue;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R038", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrid = new OracleParameter[4];

        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYMD);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmGrid[2].Value = cboGbn.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("O_Mana_R038", OracleType.Cursor);
        arrOpmGrid[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);
        this.setGridData(dsGrid);
    }

    private void setGridData(DataSet iDsSet)
    {
        DataTable dtGrid = iDsSet.Tables[0];
        int intCol = dtGrid.Columns.Count;
        int intRow = dtGrid.Rows.Count;

        double dblCPLAN = 0.00;
        double dblCACTL = 0.00;
        double dblPACTL = 0.00;

        DataRow drGrid = dtGrid.NewRow();
        for (int i = 0; i < intRow; i++)
        {
            if ((dtGrid.Rows[i][1].ToString()) != "개별난방" && (dtGrid.Rows[i][1].ToString()) != "냉방용")
            {
                dblCPLAN += Convert.ToDouble(dtGrid.Rows[i][2].ToString());
                dblCACTL += Convert.ToDouble(dtGrid.Rows[i][3].ToString());
                dblPACTL += Convert.ToDouble(dtGrid.Rows[i][4].ToString());
            }
        }
        if (intRow > 0)
        {
            drGrid[0] = "합 계";
            drGrid[1] = "";
            drGrid[2] = dblCPLAN;
            drGrid[3] = dblCACTL;
            drGrid[4] = dblPACTL;
            drGrid[5] = (dblCACTL - dblCPLAN);
            drGrid[6] = (dblCPLAN == 0) ? 0 : ((dblCACTL / dblCPLAN) * 100);
            drGrid[7] = (dblCACTL - dblPACTL);
            drGrid[8] = (dblPACTL == 0) ? 0 : ((dblCACTL / dblPACTL) * 100);
            dtGrid.Rows.Add(drGrid);
        }

        UltraWebGrid1.DataSource = iDsSet;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet iDsSet)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "달성율", null, SeriesChartType.Line, 1, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        //------------------------------------------------------Chart2
        Chart1.DataSource = iDsSet.Tables[0].DefaultView;
        series1.ValueMembersY = "S_PLAN";
        series2.ValueMembersY = "S_ACTL";
        series3.ValueMembersY = "S_RATE";
        series1.ValueMemberX = "MM";


        string strChartArea = Chart1.Series[series3.Name].ChartArea;
        series3.YAxisType = AxisType.Secondary;


        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series2, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series3, 1.0, 2.0, true);
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
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년동기";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[2].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[3].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[4].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanY = 2;


        e.Layout.Bands[0].Columns[0].MergeCells = true;
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 86;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else if (i == 1)
            {
                e.Layout.Bands[0].Columns[i].Width = 190;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else
            {
                if (e.Layout.Bands[0].Columns[i].Header.Caption == "차 이")
                {
                    e.Layout.Bands[0].Columns[i].Header.Caption = "차이";
                }

                if (e.Layout.Bands[0].Columns[i].Header.Caption == "달성율" || 
                    e.Layout.Bands[0].Columns[i].Header.Caption == "증가율" ||
                    e.Layout.Bands[0].Columns[i].Header.Caption == "차이")
                {
                    e.Layout.Bands[0].Columns[i].Width = 60;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Width = 90;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }
    }
   
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int[] arrCol = new int[2] { 6, 8 };
        double[] arrRate = new double[2];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 100) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }

        //============================= 증가율처리
        double dblARate = (Convert.ToDouble(e.Row.Cells[8].Value) == 0) ? 0 : (Convert.ToDouble(e.Row.Cells[8].Value) - 100);
        e.Row.Cells[8].Value = dblARate;
        e.Row.Cells[8].Style.ForeColor = (dblARate >= 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
    }
}