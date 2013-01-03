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

public partial class eis_SEM_Mana_R016 : EISPageBase
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid(Page.IsPostBack);
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
            this.cboTerm.Items.Clear();
            this.cboType.Items.Clear();

            for (intLP = 0; intLP < 13; intLP++)
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
                if (intMM - 1 == int.Parse(strMM))
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY + 3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedValue = intYY.ToString();

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboCom.SelectedIndex = 0;

            this.cboTerm.Items.Add(new ListItem("매출기간", "1"));
            this.cboTerm.Items.Add(new ListItem("공급기간", "2"));
            this.cboTerm.SelectedIndex = 0;

            this.setUseCode();
        }
    }

    private void setUseCode()
    {
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R016.PROC_Mana_R016_02", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Combo Query
        OracleParameter[] arrOpm = new OracleParameter[1];

        arrOpm[0] = new OracleParameter("O_Mana_R016", OracleType.Cursor);
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

        cboType.DataSource = dsCombo;
        cboType.DataTextField = "SEM_NM";
        cboType.DataValueField = "SEM_CD";
        cboType.DataBind();
        cboType.SelectedIndex = 0;
    }

    private void _queryGrid(bool blnPostYn)
    {
        string strCYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strYM = strCYY + strMM;


        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R016.PROC_Mana_R016_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[5];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 6);
        arrOpm[0].Value = strYM;
        arrOpm[1] = new OracleParameter("i_OFFICE", OracleType.VarChar, 10);
        arrOpm[1].Value = cboCom.SelectedValue ;
        arrOpm[2] = new OracleParameter("i_GUBN", OracleType.VarChar, 1);
        arrOpm[2].Value = cboTerm.SelectedValue;
        arrOpm[3] = new OracleParameter("i_CODE", OracleType.VarChar, 10);
        arrOpm[3].Value = cboType.SelectedValue;
        arrOpm[4] = new OracleParameter("O_Mana_R016", OracleType.Cursor);
        arrOpm[4].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        drawGraph(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }

    private void drawGraph(DataSet dsGrid)
    {
        string strCYY = cboYY.SelectedValue;
        string strPYY = Convert.ToString(int.Parse(cboYY.SelectedValue.ToString()) - 1);
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
            // For each Row add a new series
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["년도"].ToString(), null, SeriesChartType.Line, 3,
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
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, true);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);

            oasrType[i].MarkerStyle = GetMarkerStyle(i);
            oasrType[i].MarkerColor = GetChartColor(i);
            oasrType[i].MarkerBorderColor = GetChartColor(i);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###.#0";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView.Sort = "년도 DESC";
        Chart1.DataBind();

    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 40;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 63;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.#0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }


        }

    }

}