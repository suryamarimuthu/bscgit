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

public partial class eis_SEM_Mana_R059 : EISPageBase
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
            this.cboTCom.SelectedIndex = 1;

            this.cboGbnSum.Items.Add(new ListItem("월계", "MS"));
            this.cboGbnSum.Items.Add(new ListItem("누계", "TS"));
            this.cboGbnSum.SelectedIndex = 0;

            this.setDBCombo();
            this._queryGrid();
        }
    }

    private void setDBCombo()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R059.PROC_Mana_R059_03", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[1];

        arrOpm[0] = new OracleParameter("O_Mana_R059", OracleType.Cursor);
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

        cboType.Items.Clear();

        string strCd = "";
        string strNm = "";
        int intRow = dsCombo.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            strCd = dsCombo.Tables[0].Rows[i]["SEM_CD"].ToString();
            strNm = dsCombo.Tables[0].Rows[i]["SEM_NM"].ToString();
            cboType.Items.Add(new ListItem(strNm, strCd));
        }
        cboType.SelectedIndex = 0;
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R059.PROC_Mana_R059_02", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R059.PROC_Mana_R059_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpm = new OracleParameter[5];

        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 4);
        arrOpm[0].Value = (strYY + strMM);
        arrOpm[1] = new OracleParameter("i_OFFICE", OracleType.VarChar, 2);
        arrOpm[1].Value = cboTCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_PIPE", OracleType.VarChar, 10);
        arrOpm[2].Value = cboType.SelectedValue;
        arrOpm[3] = new OracleParameter("i_GUBN", OracleType.VarChar, 2);
        arrOpm[3].Value = cboGbnSum.SelectedValue;
        arrOpm[4] = new OracleParameter("O_Mana_R059", OracleType.Cursor);
        arrOpm[4].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmd);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrid = new OracleParameter[5];
        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 4);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_OFFICE", OracleType.VarChar, 2);
        arrOpmGrid[1].Value = cboTCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("i_PIPE", OracleType.VarChar, 10);
        arrOpmGrid[2].Value = cboType.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("i_GUBN", OracleType.VarChar, 2);
        arrOpmGrid[3].Value = cboGbnSum.SelectedValue;
        arrOpmGrid[4] = new OracleParameter("O_Mana_R059", OracleType.Cursor);
        arrOpmGrid[4].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);

        
        //DataView dvTmp = dsGrid.Tables[0];
        //DataTable dtGrid = getGridTBL(dsGrid.Tables[0]);

        UltraWebGrid1.DataSource = getGridTBL(dsGrid.Tables[0]).DefaultView;
        UltraWebGrid1.DataBind();
    }

    private DataTable getGridTBL(DataTable dtGrid)
    {
        int intCol = dtGrid.Columns.Count;
        int intRow = dtGrid.Rows.Count;

        double[] arrSum = new double[12];

        for (int i = 0; i < intRow; i++)
        {
            for (int j = 1; j < intCol; j++)
            {
                arrSum[i] += Convert.ToDouble(dtGrid.Rows[i][j].ToString());
            }
        }

        dtGrid.Columns.Add("합  계", typeof(double));
        intCol = dtGrid.Columns.Count;
        for (int i = 0; i < intRow ; i++)
        {
            dtGrid.Rows[i][intCol-1] = arrSum[i];
        }

        return dtGrid;
    }

    private void _setGraph(DataSet dsGrid)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series[] oasrType = new Series[dsGrid.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsGrid.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["YY"].ToString(), null, SeriesChartType.Column, 1,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsGrid.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = dsGrid.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i, i + 2, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 1, i + 3, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView;
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
                c.Header.RowLayoutColumnInfo.OriginY = 0;
                iIndex++;
            }

            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 100;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].Width = 54;
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

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.ResetRows();
        this._queryGrid();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        
    }


}
