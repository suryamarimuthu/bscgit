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

public partial class eis_SEM_Mana_R055 : EISPageBase
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
            this.cboGbnPQ.Items.Clear();

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

            this.cboGbnPQ.Items.Add(new ListItem("금액", "PR"));
            this.cboGbnPQ.Items.Add(new ListItem("수량", "QN"));
            this.cboGbnPQ.SelectedIndex = 1;

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            this.cboGbn.SelectedIndex = 0;

            this.setDBCombo();
        }
    }

    private void setDBCombo()
    {
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R055.PROC_Mana_R055_03", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[1];

        arrOpm[0] = new OracleParameter("O_Mana_R055", OracleType.Cursor);
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

    }

    private void _queryGrid()
    {
        string strYY = cboYY.SelectedValue;
        string strMM = cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R055.PROC_Mana_R055_01", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R055.PROC_Mana_R055_02", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[5];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYY+strMM);
        arrOpmGrph[1] = new OracleParameter("i_GBN_BOILER", OracleType.VarChar, 10);
        arrOpmGrph[1].Value = "";
        arrOpmGrph[2] = new OracleParameter("i_GBN_MONTH", OracleType.VarChar, 5);
        arrOpmGrph[2].Value = cboGbn.SelectedValue;
        arrOpmGrph[3] = new OracleParameter("i_GBN_AMTQNT", OracleType.VarChar, 5);
        arrOpmGrph[3].Value = cboGbnPQ.SelectedValue;
        arrOpmGrph[4] = new OracleParameter("O_Mana_R055", OracleType.Cursor);
        arrOpmGrph[4].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrid = new OracleParameter[5];

        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_GBN_BOILER", OracleType.VarChar, 10);
        arrOpmGrid[1].Value = "";
        arrOpmGrid[2] = new OracleParameter("i_GBN_MONTH", OracleType.VarChar, 5);
        arrOpmGrid[2].Value = cboGbn.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("i_GBN_AMTQNT", OracleType.VarChar, 5);
        arrOpmGrid[3].Value = cboGbnPQ.SelectedValue;
        arrOpmGrid[4] = new OracleParameter("O_Mana_R055", OracleType.Cursor);
        arrOpmGrid[4].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();

        lblUnit.Text = (cboGbnPQ.SelectedValue == "PR") ? "천" : "㎥";
        lblTitle.Text = cboGbnPQ.SelectedItem.Text;

    }

    private void _setGraph(DataSet dsGrph)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 290
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1),2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "달성율", null, SeriesChartType.Line, 1, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        dsGrph.Tables[0].DefaultView.Sort = "MM";

        Chart1.DataSource = dsGrph.Tables[0].DefaultView;
        series1.ValueMembersY = "A_PLAN";
        series2.ValueMembersY = "A_ACTL";
        series3.ValueMembersY = "A_RATE";
        series1.ValueMemberX  = "MM";

        string strChartArea = Chart1.Series[series3.Name].ChartArea;
        series3.YAxisType = AxisType.Secondary;

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";
        Chart1.DataBind();

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

        try
        {
            //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
            ch = e.Layout.Bands[0].Columns[0].Header;

            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 130;
                }
                else if(i==5 || i==7)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                    e.Layout.Bands[0].Columns[i].Width = 80;
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