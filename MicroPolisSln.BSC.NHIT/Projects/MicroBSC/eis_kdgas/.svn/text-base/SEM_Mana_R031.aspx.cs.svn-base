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

public partial class eis_SEM_Mana_R031 : EISPageBase
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
                if (intMM == intLP)
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

            cboGbn.Items.Add(new ListItem("월계", "MS"));
            cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;
            /// </summary>
        }
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        string sqlGrid = "";

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R031.PROC_Mana_R031_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[3];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY+strMM);
        arrOpm[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 8);
        arrOpm[1].Value = cboGbn.SelectedValue;
        arrOpm[2] = new OracleParameter("O_Mana_R031", OracleType.Cursor);
        arrOpm[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();

        this._setGraph(dsGrid);
        //makePvtTable(dsGrid);

    }

    private void _setGraph(DataSet dsGrid)
    {
        if (dsGrid.Tables[0].Rows.Count == 0)
            return;

        // 년도별 매출량 그래프
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "당월실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "전년동월", null, SeriesChartType.Column, 1, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series4 = DundasCharts.CreateSeries(Chart1, "Series4", "Default", "달성율", null, SeriesChartType.Line, 3, Color.FromArgb(0x38, 0xd9, 0x38), Color.FromArgb(0x38, 0xd9, 0x38), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Chart1.DataSource = dsGrid;
        series1.ValueMemberX = "동종사명";
        series1.ValueMembersY = "계획";
        series2.ValueMembersY = "실적";
        series3.ValueMembersY = "실 적";
        series4.ValueMembersY = "달성율";
        Chart1.DataBind();

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        Chart1.ChartAreas[Chart1.Series[series4.Name].ChartArea].AxisY2.LabelStyle.Format = "P0";
        series4.YAxisType = AxisType.Secondary;

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series2, 1.0, 1.5, true);
        DundasAnimations.GrowingAnimation(Chart1, series3, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series4, 1.5, 2.5, true);
        
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "GUBUN";
        ch.Caption = "구     분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "CY_ACTL";
        ch.Caption = "당기실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "PYYMM";
        ch.Caption = "전년동기실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "CY_PLAN";
        ch.Caption = "계획대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "CY_PYYMM";
        ch.Caption = "전년동기대비";
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


        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 140;
            }
            else if (i == 5 || i == 7)
            {
                e.Layout.Bands[0].Columns[i].Width = 69;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 100;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }

            if (e.Layout.Bands[0].Columns[i].Header.Caption == "실 적")
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = "실적";
            }

            if (e.Layout.Bands[0].Columns[i].Header.Caption == "증 감")
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = "증감";
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        int[] arrCol = new int[2] { 5,7 };
        double[] arrRate = new double[2];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 99.999) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }
    }
}