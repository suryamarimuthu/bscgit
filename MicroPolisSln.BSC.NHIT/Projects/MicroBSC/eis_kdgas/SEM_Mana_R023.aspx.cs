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

public partial class eis_SEM_Mana_R023 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid();
        this._queryChart();
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
                if (intMM-1 == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY+3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboYY.SelectedValue = intYY.ToString();

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;
            /// </summary>
        }
    }

    private void _queryGrid()
    {
        string strCom = this.cboCom.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        string strYMD = (this.cboYY.SelectedValue + this.cboMM.SelectedValue);

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R023.PROC_Mana_R023_02", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = strYMD;
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmGrph[1].Value = strCom;
        arrOpmGrph[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 12);
        arrOpmGrph[2].Value = strGbn;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R023", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);

        //this._setGraph(dsGrph);
        UltraWebGrid1.DataSource = dsGrph;
        UltraWebGrid1.DataBind();
    }
    private void _queryChart()
    {
        string strCom = this.cboCom.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        string strYMD = (this.cboYY.SelectedValue + this.cboMM.SelectedValue);

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R023.PROC_Mana_R023_01", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = strYMD;
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmGrph[1].Value = strCom;
        arrOpmGrph[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 12);
        arrOpmGrph[2].Value = strGbn;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R023", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);

        this._setGraph(dsGrph);
        //UltraWebGrid1.DataSource = dsGrph;
        //UltraWebGrid1.DataBind();
    }
    private void _setGraph(DataSet dsGrid)
    {
        string strCYY = cboYY.SelectedValue;
        string strPYY = (int.Parse(strCYY) - 1).ToString();
        string strFYY = (int.Parse(strCYY) - 2).ToString();
        string strCMM = cboMM.SelectedValue;
        //strCYY = strCYY + "년";

        // 년도별 매출량 그래프
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 400, 280
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
        // 년도별 매출량 그래프
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 400, 280
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        //===============================================================================================
        DataRow[] drLine1 = dsGrid.Tables[0].Select("GBN_CD='CNG'", "YY");
        DataRow[] drLine2 = dsGrid.Tables[0].Select("GBN_CD='메탄'", "YY");
        //=============================================================================================== GRAPH 1
        Series[] oasrType = new Series[drLine1.Length];
        for (int i = 0; i < drLine1.Length; i++)
        {
            oasrType[i] = DundasCharts.CreateSeries(Chart1, "Series" + i.ToString(), Chart1.ChartAreas[0].Name,
                                                    drLine1[i]["YY"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 2; colIndex < drLine1[i].Table.Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = drLine1[i].Table.Columns[colIndex].ColumnName.ToString();
                double YVal = double.Parse(drLine1[i][colIndex].ToString());
                Chart1.Series[oasrType[i].Name].Points.AddXY(columnName, YVal);
            }
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView;
        Chart1.DataBind();

        //================================================================================================ GRAPH 2
        Series[] oasrType2 = new Series[drLine2.Length];
        for (int i = 0; i < drLine2.Length; i++)
        {
            oasrType2[i] = DundasCharts.CreateSeries(Chart2, "Series" + i.ToString(), Chart2.ChartAreas[0].Name,
                                                    drLine2[i]["YY"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 2; colIndex < drLine2[i].Table.Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = drLine2[i].Table.Columns[colIndex].ColumnName.ToString();
                double YVal = double.Parse(drLine2[i][colIndex].ToString());
                Chart2.Series[oasrType2[i].Name].Points.AddXY(columnName, YVal);
            }
        }

        DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType2.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart2, oasrType2[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart2, oasrType2[i], i + 0.1, 1.0, true);
        }

        Chart2.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        Chart2.DataSource = dsGrid.Tables[0].DefaultView;
        Chart2.DataBind();


    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        try
        {
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
            ch = e.Layout.Bands[0].Columns[0].Header;

            int intWid = 0;
            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].Header.Caption = "구분";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 50;
                    e.Layout.Bands[0].Columns[i].MergeCells = true;
                }
                else if (i == 1)
                {
                    e.Layout.Bands[0].Columns[i].Header.Caption = "년도";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    e.Layout.Bands[0].Columns[i].Width = 60;
                }
                else if ( i == 14)
                {
                    e.Layout.Bands[0].Columns[i].Hidden = true;	
                }
        
                else
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].Width = 60;
                }
            }
        }
        catch
        {
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //e.Row.Cells.FromKey("GBN_CD").Value = (e.Row.Cells.FromKey("GBN_CD").Value == "C") ? "CNG" : "메탄";
    }
}