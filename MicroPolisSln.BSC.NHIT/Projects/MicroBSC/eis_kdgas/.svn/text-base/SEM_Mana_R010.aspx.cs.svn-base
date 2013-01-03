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

public partial class eis_SEM_Mana_R010 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
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

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            cboYY.SelectedValue = intYY.ToString();

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

            this.cboTCom.Items.Add(new ListItem("전체", ""));
            this.cboTCom.Items.Add(new ListItem("울산", "01"));
            this.cboTCom.Items.Add(new ListItem("양산", "02"));
            this.cboTCom.SelectedIndex = 0;

            this.cboGbnNew.Items.Add(new ListItem("전체", ""));
            this.cboGbnNew.Items.Add(new ListItem("주요", "M"));
            this.cboGbnNew.Items.Add(new ListItem("신규", "N"));
            this.cboGbnNew.SelectedIndex = 0;

            this.cboGbnSum.Items.Add(new ListItem("월계", "MS"));
            this.cboGbnSum.Items.Add(new ListItem("누계", "TS"));
            this.cboGbnSum.SelectedIndex = 0;

            this.setDBCombo();
            this._queryGrid();
        }
    }
    private void setDBName()
    {
    	cboName.Text = "==업체명==";
    	//UltraWebGrid1.ResetRows();
        //this._queryGrid();
    }
    private void setDBCombo()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R010.PROC_Mana_R010_02", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[4];

        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY);
        arrOpm[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpm[1].Value = cboTCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_GUBN", OracleType.VarChar, 12);
        arrOpm[2].Value = cboGbnNew.SelectedValue;
        arrOpm[3] = new OracleParameter("O_Mana_R010", OracleType.Cursor);
        arrOpm[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsCombo = new DataSet();
        OracleDataAdapter daCombo = new OracleDataAdapter(objCmd);

        daCombo.Fill(dsCombo);
        _connection.Close();
        objCmd = null;

        cboMCom.Items.Clear();
        cboName.Text = "";
        
        string strCd = "";
        string strNm = "";
        int intRow = dsCombo.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            strCd = dsCombo.Tables[0].Rows[i]["COM_CD"].ToString();
            strNm = dsCombo.Tables[0].Rows[i]["COM_NM"].ToString();
            cboMCom.Items.Add(new ListItem(strNm, strCd));
        }
        cboMCom.SelectedIndex = 0;
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R010.PROC_Mana_R010_01", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R010.PROC_Mana_R010_03", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpm = new OracleParameter[7];

        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = (strYY + strMM);
        arrOpm[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpm[1].Value = cboTCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_MCOMCD", OracleType.VarChar, 12);
        arrOpm[2].Value = cboMCom.SelectedValue;
        arrOpm[3] = new OracleParameter("i_GBN_NEWYN", OracleType.VarChar, 12);
        arrOpm[3].Value = cboGbnNew.SelectedValue;
        arrOpm[4] = new OracleParameter("i_GBN_SUMYN", OracleType.VarChar, 12);
        arrOpm[4].Value = cboGbnSum.SelectedValue;
        arrOpm[5] = new OracleParameter("i_MCOMNM", OracleType.VarChar, 20);
        arrOpm[5].Value = cboName.Text; 
        arrOpm[6] = new OracleParameter("O_Mana_R010", OracleType.Cursor);
        arrOpm[6].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmd);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrid = new OracleParameter[7];
        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = cboTCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("i_MCOMCD", OracleType.VarChar, 12);
        arrOpmGrid[2].Value = cboMCom.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("i_GBN_NEWYN", OracleType.VarChar, 12);
        arrOpmGrid[3].Value = cboGbnNew.SelectedValue;
        arrOpmGrid[4] = new OracleParameter("i_GBN_SUMYN", OracleType.VarChar, 12);
        arrOpmGrid[4].Value = cboGbnSum.SelectedValue;
        arrOpmGrid[5] = new OracleParameter("i_MCOMNM", OracleType.VarChar, 20);
        arrOpmGrid[5].Value = cboName.Text; 
        arrOpmGrid[6] = new OracleParameter("O_Mana_R010", OracleType.Cursor);
        arrOpmGrid[6].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);

        
        //DataView dvTmp = dsGrid.Tables[0];
        //DataTable dtGrid = getGridTBL(dsGrid.Tables[0]);

        UltraWebGrid1.Bands[0].ResetColumns();
        UltraWebGrid1.DataSource = getGridTBL(dsGrid.Tables[0]).DefaultView;
        UltraWebGrid1.DataBind();
    }

    private DataTable getGridTBL(DataTable dtGrid)
    {
        int intCol = dtGrid.Columns.Count;
        int intRow = dtGrid.Rows.Count;

        double dblCPLAN = 0.00;
        double dblCACTL = 0.00;
        double dblCRATE = 0.00;

        double dblPPLAN = 0.00;
        double dblPACTL = 0.00;
        double dblPRATE = 0.00;

        DataRow drGrid = dtGrid.NewRow();
        for (int i = 0; i < intRow ; i++)
        { 
            dblCPLAN += Convert.ToDouble(dtGrid.Rows[i][3].ToString());
            dblCACTL += Convert.ToDouble(dtGrid.Rows[i][4].ToString());
            dblPPLAN += Convert.ToDouble(dtGrid.Rows[i][6].ToString());
            dblPACTL += Convert.ToDouble(dtGrid.Rows[i][7].ToString());
        }
        if (intRow > 0)
        {
            drGrid[0] = "";
            drGrid[1] = "";
            drGrid[2] = "합 계";
            drGrid[3] = dblCPLAN;
            drGrid[4] = dblCACTL;
            drGrid[5] = (dblCPLAN == 0) ? 0 : ((dblCACTL / dblCPLAN) * 100);
            drGrid[6] = dblPPLAN;
            drGrid[7] = dblPACTL;
            drGrid[8] = (dblPPLAN == 0) ? 0 : ((dblPACTL / dblPPLAN) * 100);

            dtGrid.Rows.Add(drGrid);
        }

        return dtGrid;
    }

    private void _setGraph(DataSet dsGrph)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);


        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "달성율(%)", null, SeriesChartType.Line, 1, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        Chart1.DataSource = dsGrph.Tables[0].DefaultView;
        series1.ValueMembersY = "QTN_PLAN";
        series2.ValueMembersY = "QTN_ACTL";
        series3.ValueMembersY = "QTN_RATE";
        series1.ValueMemberX = "MM";

        string strChartArea = Chart1.Series[series3.Name].ChartArea;
        series3.YAxisType = AxisType.Secondary;

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 1.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series2, 1.0, 2.0, true);
        DundasAnimations.GrowingAnimation(Chart1, series3, 1.0, 2.0, true);

        Chart1.DataBind();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        try
        {
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
            ch = e.Layout.Bands[0].Columns[0].Header;

            int iIndex = 0;
            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
            {
                c.Header.RowLayoutColumnInfo.OriginY = 1;

                iIndex++;
            }

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "구  분";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "당  월";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 3;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "누  계";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 6;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    e.Layout.Bands[0].Columns[i].Width = 40;
                }
                else if (i == 1)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    e.Layout.Bands[0].Columns[i].Width = 50;
                }
                else if (i == 2)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 156;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = ((i + 1) % 3 == 0) ? "#,##0.0" : "#,##0";
                    e.Layout.Bands[0].Columns[i].Width = ((i + 1) % 3 == 0) ? 70 : 100;
                }
            }
        }
        catch
        {
        }
    }

    protected void cboTCom_SelectedIndexChanged(object sender, EventArgs e)
    {
        UltraWebGrid1.ResetRows();
        this.setDBCombo();
    }
    protected void cboMCom_SelectedIndexChanged(object sender, EventArgs e)
    {
        //UltraWebGrid1.ResetRows();
        this._queryGrid();
        this.setDBName();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.ResetRows();
        this._queryGrid();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        int[] arrCol = new int[2] { 5, 8 };
        double[] arrRate = new double[2];
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


}
