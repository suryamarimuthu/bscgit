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

public partial class eis_SEM_Mana_R052 : EISPageBase
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

            /// </summary>
        }
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrphLine = new OracleCommand("PKG_SEM_Mana_R052.PROC_Mana_R052_01", _connection);
        OracleCommand objCmdGrphPie = new OracleCommand("PKG_SEM_Mana_R052.PROC_Mana_R052_02", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R052.PROC_Mana_R052_03", _connection);

        _connection.Open();

        objCmdGrphPie.CommandType = CommandType.StoredProcedure;
        objCmdGrphLine.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpmPie = new OracleParameter[3];
        arrOpmPie[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmPie[0].Value = (strYY + strMM);
        arrOpmPie[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmPie[1].Value = cboCom.SelectedValue;
        arrOpmPie[2] = new OracleParameter("O_Mana_R052", OracleType.Cursor);
        arrOpmPie[2].Direction = ParameterDirection.Output;

        OracleParameter[] arrOpmLine = new OracleParameter[3];
        arrOpmLine[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmLine[0].Value = (strYY + strMM);
        arrOpmLine[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmLine[1].Value = cboCom.SelectedValue;
        arrOpmLine[2] = new OracleParameter("O_Mana_R052", OracleType.Cursor);
        arrOpmLine[2].Direction = ParameterDirection.Output;

        OracleParameter[] arrOpmGrid = new OracleParameter[3];
        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("O_Mana_R052", OracleType.Cursor);
        arrOpmGrid[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmPie.Length; i++)
        {
            objCmdGrphPie.Parameters.Add(arrOpmPie[i]);
        }

        for (int i = 0; i < arrOpmLine.Length; i++)
        {
            objCmdGrphLine.Parameters.Add(arrOpmLine[i]);
        }

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrphPie = new DataSet();
        DataSet dsGrphLine = new DataSet();
        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrphPie = new OracleDataAdapter(objCmdGrphPie);
        OracleDataAdapter daGrphLine = new OracleDataAdapter(objCmdGrphLine);
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);

        try
        {
            daGrphPie.Fill(dsGrphPie);
            daGrphLine.Fill(dsGrphLine);
            daGrid.Fill(dsGrid);

            this._setGraph(dsGrphPie, dsGrphLine);

            UltraWebGrid1.DataSource = dsGrid;
            UltraWebGrid1.DataBind();

        }
        catch (Exception e)
        {
            return;
        }

        _connection.Close();
        _connection = null;

        objCmdGrid = null;
        objCmdGrphPie = null;
        objCmdGrphLine = null;
    }

    private void _setGraph(DataSet dsPie, DataSet dsLine)
    {
        // Line GRAPH
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 550, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series[] oasrType = new Series[dsLine.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsLine.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart2, "Series" + intLP.ToString(), Chart2.ChartAreas[0].Name,
                                                    row["GBN_NM"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsLine.Tables[0].Columns.Count; colIndex++)
            {
                string columnName = dsLine.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart2.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart2, oasrType[i], 0.5, 1.0, true);
            else
                DundasAnimations.GrowingAnimation(Chart2, oasrType[i], i + 0.1, 1.0, true);

            oasrType[i].MarkerStyle = GetMarkerStyle(i);
            oasrType[i].MarkerColor = GetChartColor(i);
            oasrType[i].MarkerBorderColor = GetChartColor(i);
        }

        Chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart2.DataSource = dsLine.Tables[0].DefaultView;
        Chart2.DataBind();

        // PIE GRAPH
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 250, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series serPie = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "고객상태별점유율", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Chart1.Series[serPie.Name].ValueMemberX = "GBN_NM";
        Chart1.Series[serPie.Name].ValueMembersY = "FNL_QNT";
        serPie.FontColor = Color.White;
        Chart1.DataSource = dsPie;
        Chart1.DataBind();


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
        ch.Caption = "구분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "잠재고객";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 6;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "가망고객";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 6;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "기회고객";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 13;
        ch.RowLayoutColumnInfo.SpanX = 6;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계약고객";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 19;
        ch.RowLayoutColumnInfo.SpanX = 6;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        string[] strHdr = new string[25] { "월", "기초", "증가", "감소", "CLOSE", "기말", "점유율", "기초", "증가", "감소", "CLOSE", "기말", "점유율", "기초", "증가", "감소", "CLOSE", "기말", "점유율", "기초", "증가", "감소", "CLOSE", "기말", "점유율" };
        int intIdx = 0;
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {

            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = strHdr[i];
                e.Layout.Bands[0].Columns[i].Width = 45;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = strHdr[i];
                e.Layout.Bands[0].Columns[i].Width = (i % 6 == 0) ? 55 : 45;
                e.Layout.Bands[0].Columns[i].Format = (i % 6 == 0) ? "#,##0.0" : "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
}