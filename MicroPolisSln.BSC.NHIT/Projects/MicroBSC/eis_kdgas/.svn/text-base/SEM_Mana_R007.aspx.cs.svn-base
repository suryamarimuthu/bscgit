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

public partial class eis_SEM_Mana_R007 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid();

        lblNow.Text = DateTime.Now.ToString() + " 현재";
    }

    private void _initForm(bool blnGbn)
    {
        /// <summary>
        /// 폼초기화 및 기본값 세팅
        /// 
        if (!blnGbn)
        {
            return;
        }
    }

    private void _queryGrid()
    {
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R007.PROC_Mana_R007_01", _connection);
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R007.PROC_Mana_R007_02", _connection);
        
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;
        objCmdGrph.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[1];
        arrOpm[0] = new OracleParameter("O_Mana_R007", OracleType.Cursor);
        arrOpm[0].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrph = new OracleParameter[1];
        arrOpmGrph[0] = new OracleParameter("O_Mana_R007", OracleType.Cursor);
        arrOpmGrph[0].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);

        drawGraph(dsGrph);
    }

    private void drawGraph(DataSet dsGrph)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "1차", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "2차", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Chart1.DataSource = dsGrph.Tables[0].DefaultView;
        series1.ValueMembersY = "1차";
        series2.ValueMembersY = "2차";
        series1.ValueMemberX  = "SEC_NM";
        Chart1.DataBind();

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0.#0";

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series2, 2.0, 3.0, true);


    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
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
        ch.Caption = "지역";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "1 차 압 력";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "2 차 압 력";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 140;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 105;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }

    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        double dblMax1 = 0.00;
        double dblMin1 = 0.00;
        double dblVal1 = 0.00;
        double dblMax2 = 0.00;
        double dblMin2 = 0.00;
        double dblVal2 = 0.00;

        for (int intCol = 0; intCol < e.Row.Band.Columns.Count; intCol++)
        {
            dblMin1 = Convert.ToDouble(e.Row.Cells[1].Value);
            dblMax1 = Convert.ToDouble(e.Row.Cells[2].Value);
            dblVal1 = Convert.ToDouble(e.Row.Cells[3].Value);
            dblMin2 = Convert.ToDouble(e.Row.Cells[4].Value);
            dblMax2 = Convert.ToDouble(e.Row.Cells[5].Value);
            dblVal2 = Convert.ToDouble(e.Row.Cells[6].Value);

            e.Row.Cells[3].Style.ForeColor = (dblVal1 >= dblMin1 && dblVal1 <= dblMax1) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
            e.Row.Cells[6].Style.ForeColor = (dblVal2 >= dblMin2 && dblVal2 <= dblMax2) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }
    }
}