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

public partial class eis_SEM_Mana_R004 : EISPageBase
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
            this.cboCom.Items.Add(new ListItem("울산", "21"));
            this.cboCom.Items.Add(new ListItem("양산", "51"));
            this.cboCom.SelectedIndex = 0;

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYY = cboYY.SelectedValue;
        string strMM = cboMM.SelectedValue;
        string strYMD = strYY+strMM;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R004.PROC_Mana_R004_01", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = cboCom.SelectedValue;
        arrOpmGrph[2] = new OracleParameter("i_GUBN", OracleType.VarChar, 2);
        arrOpmGrph[2].Value = cboGbn.SelectedValue;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R004", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        UltraWebGrid1.DataSource = dsGrph;
        UltraWebGrid1.DataBind();

    }

    private void _setGraph(DataSet iDsSet)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        //================================================================== LINE GRAPH
        Series[] oasrType = new Series[iDsSet.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in iDsSet.Tables[0].Rows)
        {
            if (intLP < 2)
            {
                oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                        row["YY"].ToString(), null, SeriesChartType.Column, 0,
                                                        GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            }
            else
            {
                oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                        row["YY"].ToString(), null, SeriesChartType.Line, 3,
                                                        GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            }
            for (int colIndex = 1; colIndex < iDsSet.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = iDsSet.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
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
        Chart1.DataSource = iDsSet.Tables[0].DefaultView;
        Chart1.DataBind();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Header.Caption = "구  분";
                e.Layout.Bands[0].Columns[i].Width = 80;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
}