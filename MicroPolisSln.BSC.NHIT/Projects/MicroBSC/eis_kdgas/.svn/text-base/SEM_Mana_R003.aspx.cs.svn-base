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

public partial class eis_SEM_Mana_R003 : EISPageBase
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
            DateTime objDT = DateTime.Now.AddDays(-1);
            sDate.Value = objDT;

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "21"));
            this.cboCom.Items.Add(new ListItem("양산", "51"));
            this.cboCom.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYY = "";
        string strMM = "";
        string strDD = "";
        string strYMD = "";
        DateTime dtYMD = Convert.ToDateTime(sDate.Value.ToString());

        strYY = dtYMD.Year.ToString();
        strMM = (dtYMD.Month > 9) ? dtYMD.Month.ToString() : ("0" + dtYMD.Month.ToString());
        strDD = (dtYMD.Day > 9)   ? dtYMD.Day.ToString()   : ("0" + dtYMD.Day.ToString());

        strYMD = strYY + strMM + strDD;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R003.PROC_Mana_R003_01", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R003.PROC_Mana_R003_02", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[3];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = cboCom.SelectedValue;
        arrOpmGrph[2] = new OracleParameter("O_Mana_R003", OracleType.Cursor);
        arrOpmGrph[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrid = new OracleParameter[3];

        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYMD);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("O_Mana_R003", OracleType.Cursor);
        arrOpmGrid[2].Direction = ParameterDirection.Output;

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
        /*
        double dblCYActl = 0.00;
        double dblPYActl = 0.00;
        double dblDiff = 0.00;
        double dblRate = 0.00;


        int intRow = iDsSet.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            dblCYActl += double.Parse(iDsSet.Tables[0].Rows[i]["월실적"].ToString());
            dblPYActl += double.Parse(iDsSet.Tables[0].Rows[i]["전년동기실적"].ToString());
        }

        DataRow drTmp = iDsSet.Tables[0].NewRow();
        drTmp["지역명"] = "합       계";
        drTmp["월실적"] = dblCYActl;
        drTmp["전년동기실적"] = dblPYActl;
        drTmp["전년대비증감"] = (dblCYActl - dblPYActl);
        drTmp["증감율"] = (dblPYActl == 0) ? 0.00 : Math.Round((dblCYActl / dblPYActl) * 100, 2);
        iDsSet.Tables[0].Rows.InsertAt(drTmp, 0);

         */

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
        series1.ValueMembersY = "PLAN_QNT";
        series2.ValueMembersY = "ACTL_QNT";
        series3.ValueMembersY = "ACHV_RATE";
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
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            }
            else
            {
                if (e.Layout.Bands[0].Columns[i].Header.Caption == "비율(%)" || e.Layout.Bands[0].Columns[i].Header.Caption == "비 율(%)")
                {
                    e.Layout.Bands[0].Columns[i].Header.Caption = "비율(%)";
                    e.Layout.Bands[0].Columns[i].Width = 75;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                else if (e.Layout.Bands[0].Columns[i].Header.Caption == "증감" || e.Layout.Bands[0].Columns[i].Header.Caption == "증 감")
                {
                    e.Layout.Bands[0].Columns[i].Header.Caption = "차이";
                    e.Layout.Bands[0].Columns[i].Width = 115;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Width = 115;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int[] arrCol = new int[2] { 5,7 };
        double[] arrRate = new double[2];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 100) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }

        //============================= 증가율처리
        double dblARate = (Convert.ToDouble(e.Row.Cells[7].Value) == 0) ? 0 : (Convert.ToDouble(e.Row.Cells[7].Value) - 100);
        e.Row.Cells[7].Value = dblARate;
        e.Row.Cells[7].Style.ForeColor = (dblARate >= 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
    }
}