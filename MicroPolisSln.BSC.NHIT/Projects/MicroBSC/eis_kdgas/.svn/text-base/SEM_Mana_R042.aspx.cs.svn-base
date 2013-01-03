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

public partial class eis_SEM_Mana_R042 : EISPageBase
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

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            this.cboGbn.SelectedValue = "MS";

            //this.setCombo();

            /// </summary>
        }
    }

    private void setCombo() 
    {
        return;
        /*
        DataSet dsComb = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        string strHd = "";
        string strDt = "";
        string sqlComb = "";
        int cntRow = 0;

        cboCom.Items.Clear();
        sqlComb = @"SELECT '' as CEN_CD, '==전체==' as CEN_NM FROM DUAL
                     UNION ALL							
                    SELECT CM.SEM_CODE2_T, CM.SEM_CODE2_NAME FROM SEM_CODE_MASTER CM WHERE CM.SEM_CODE1_T = '11'";

        OracleDataAdapter daComb = new OracleDataAdapter(sqlComb, _connection);
        daComb.Fill(dsComb);

        this.cboCom.DataSource = dsComb;
        this.cboCom.DataValueField = "CEN_CD";
        this.cboCom.DataTextField = "CEN_NM";
        this.cboCom.DataBind();
        this.cboCom.SelectedIndex = 0;
        _connection.Close();
        _connection = null;
        */
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrphLine = new OracleCommand("PKG_SEM_Mana_R042.PROC_Mana_R042_01", _connection);
        OracleCommand objCmdGrphPie = new OracleCommand("PKG_SEM_Mana_R042.PROC_Mana_R042_02", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R042.PROC_Mana_R042_03", _connection);

        _connection.Open();

        objCmdGrphPie.CommandType = CommandType.StoredProcedure;
        objCmdGrphLine.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpmPie = new OracleParameter[4];
        arrOpmPie[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmPie[0].Value = (strYY + strMM);
        arrOpmPie[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmPie[1].Value = "";
        arrOpmPie[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmPie[2].Value = cboGbn.SelectedValue;
        arrOpmPie[3] = new OracleParameter("O_Mana_R042", OracleType.Cursor);
        arrOpmPie[3].Direction = ParameterDirection.Output;

        OracleParameter[] arrOpmLine = new OracleParameter[4];
        arrOpmLine[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmLine[0].Value = (strYY + strMM);
        arrOpmLine[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmLine[1].Value = "";
        arrOpmLine[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmLine[2].Value = cboGbn.SelectedValue;
        arrOpmLine[3] = new OracleParameter("O_Mana_R042", OracleType.Cursor);
        arrOpmLine[3].Direction = ParameterDirection.Output;


        OracleParameter[] arrOpmGrid = new OracleParameter[4];
        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmGrid[1].Value = "";
        arrOpmGrid[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmGrid[2].Value = cboGbn.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("O_Mana_R042", OracleType.Cursor);
        arrOpmGrid[3].Direction = ParameterDirection.Output;

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
            Response.Write(e.Message);
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
                                                    row["VOC_NM"].ToString(), null, SeriesChartType.StackedColumn, 1,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 2; colIndex < dsLine.Tables[0].Columns.Count; colIndex++)
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
                DundasAnimations.GrowingAnimation(Chart2, oasrType[i], i, i + 2, true);
            else
                DundasAnimations.GrowingAnimation(Chart2, oasrType[i], i + 1, i + 3, true);

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

        Series serPie = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "유형별증가건수", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Chart1.Series[serPie.Name].ValueMemberX = "VOC_NM";
        Chart1.Series[serPie.Name].ValueMembersY = "VOC_RATE";
        serPie.FontColor = Color.White;
        Chart1.DataSource = dsPie;
        Chart1.DataBind();


    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = "구분";
                e.Layout.Bands[0].Columns[i].Width = 93;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 58;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
}