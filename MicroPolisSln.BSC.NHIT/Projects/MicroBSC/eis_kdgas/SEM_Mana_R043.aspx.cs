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

public partial class eis_SEM_Mana_R043 : EISPageBase
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

            this.setCombo();
        }
    }

    private void setCombo()
    {
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
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R042.PROC_Mana_R042_04", _connection);

        _connection.Open();

        objCmdGrid.CommandType = CommandType.StoredProcedure;

        OracleParameter[] arrOpmGrid = new OracleParameter[3];
        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYY + strMM);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 8);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("O_Mana_R042", OracleType.Cursor);
        arrOpmGrid[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);

        try
        {
            daGrid.Fill(dsGrid);

            this._setGraph(dsGrid);

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
    }

    private void _setGraph(DataSet dsLine)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series[] oasrType = new Series[dsLine.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsLine.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["년도"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsLine.Tables[0].Columns.Count; colIndex++)
            {
                string columnName = dsLine.Tables[0].Columns[colIndex].ColumnName;
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

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsLine.Tables[0].DefaultView;
        Chart1.DataBind();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        try
        {
            e.Layout.Bands[0].HeaderLayout.Reset();
            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {

                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].Width = 40;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Width = 63;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }
        catch
        {
        }
    }
}