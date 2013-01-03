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

public partial class eis_SEM_Mana_R005 : EISPageBase
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
            sDate.Value = objDT;

            this.cboCom.Items.Add(new ListItem("전체", "99"));
            this.cboCom.Items.Add(new ListItem("울산", "21"));
            this.cboCom.Items.Add(new ListItem("양산", "51"));
            this.cboCom.SelectedIndex = 0;

            sDate.Value = Convert.ToDateTime(sDate.Value).AddDays(-1);
        }
    }

    private void _queryGrid()
    {
        string strYY = "";
        string strMM = "";
        string strDD = "";
        string strYMD = "";
        DateTime dtYMD = Convert.ToDateTime(sDate.Value.ToString());

        strYY = dtYMD.Year.ToString();
        strMM = (dtYMD.Month > 9) ? dtYMD.Month.ToString() : ("0" + dtYMD.Month.ToString());
        strDD = (dtYMD.Day > 9) ? dtYMD.Day.ToString() : ("0" + dtYMD.Day.ToString());

        strYMD = strYY + strMM + strDD;

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R005.PROC_Mana_R005_01", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R005.PROC_Mana_R005_02", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[3];

        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = cboCom.SelectedValue;
        arrOpmGrph[2] = new OracleParameter("O_Mana_R005", OracleType.Cursor);
        arrOpmGrph[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);

        /* -- 해당일까지 그래프 디스플레이
        int intCDD = int.Parse(strDD);
        int intCol = dsGrph.Tables[0].Columns.Count;
        for (int i = 1; i < intCol; i++)
        {
            if (i > int.Parse(strDD))
            {
                dsGrph.Tables[0].Columns.RemoveAt(intCDD+1);
            }
        }
        */

        this._setGraph(dsGrph);

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrid = new OracleParameter[3];

        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYMD);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("O_Mana_R005", OracleType.Cursor);
        arrOpmGrid[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);
        this.setGridData(dsGrid);
    }

    private void setGridData(DataSet iDsSet)
    {
        double dblCYActl = 0.00;
        double dblPYActl = 0.00;
        double dblDiff = 0.00;
        double dblRate = 0.00;


        int intRow = iDsSet.Tables[0].Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            dblCYActl += double.Parse(iDsSet.Tables[0].Rows[i]["월실적"].ToString());
            dblPYActl += double.Parse(iDsSet.Tables[0].Rows[i]["전년동기실적"].ToString());
        }

        DataRow drTmp = iDsSet.Tables[0].NewRow();
        drTmp["지구명"]       = "합       계";
        drTmp["월실적"]       = dblCYActl;
        drTmp["전년동기실적"] = dblPYActl;
        drTmp["차이"]         = (dblCYActl - dblPYActl);
        drTmp["증가율(%)"]    = (dblPYActl == 0) ? 0.00 : Math.Round((dblCYActl / dblPYActl) * 100, 2);
        iDsSet.Tables[0].Rows.InsertAt(drTmp, 0);

        UltraWebGrid1.DataSource = iDsSet;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsLine)
    {
        string strCYY = "2006";
        string strFYY = (int.Parse(strCYY) - 2).ToString();
        string strPYY = (int.Parse(strCYY) - 1).ToString();
        string strCMM = "06";
        //strCYY = strCYY + "년";

        // 년도별 매출량 그래프
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 270
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        //================================================================== LINE GRAPH
        Series[] oasrType = new Series[dsLine.Tables[0].Rows.Count];
        int intLP = 0;
        foreach (DataRow row in dsLine.Tables[0].Rows)
        {
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["AREA_NM"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsLine.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = dsLine.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(columnName, YVal);
            }
            intLP += 1;
        }

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        for (int i = 0; i < oasrType.Length; i++)
        {
            //oasrType[i].MarkerStyle = GetMarkerStyle(i);
            //oasrType[i].MarkerColor = GetChartColor(i);
            //oasrType[i].MarkerBorderColor = GetMarkerBorderColor(i);
            if (i == 0)
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
        Chart1.DataSource = dsLine.Tables[0].DefaultView;
        Chart1.DataBind();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 200;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            }
            else if (i == e.Layout.Bands[0].Columns.Count - 1)
            {
                e.Layout.Bands[0].Columns[i].Width = 130;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 150;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int[] arrCol = new int[1] { 4};
        double[] arrRate = new double[1];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 100) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }
    }
}