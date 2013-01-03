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

public partial class eis_SEM_Mana_R057 : EISPageBase
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

            sDate.Value = objDT;
            this.cboComCd.Items.Add(new ListItem("전체", ""));
            this.cboComCd.Items.Add(new ListItem("울산", "01"));
            this.cboComCd.Items.Add(new ListItem("양산", "02"));
            this.cboComCd.SelectedIndex = 0;
            /// </summary>
        }
    }

    private void _queryGrid(bool blnPostYn)
    {
        string strYY = "";
        string strMM = "";
        string strDD = "";
        string strYMD = "";
        string[] arrDay = new string[15];
        int intDay = 0;
        int intMon = 0;
        string strMon = "";
        int intIdx = 0;

        DateTime dtSYMD = Convert.ToDateTime(sDate.Value.ToString());

        for (int i = 0; i < arrDay.Length; i++)
        {
            intIdx = (arrDay.Length - 1) - i;
            intDay = dtSYMD.AddDays(i * -1).Day;
            intMon = dtSYMD.AddDays(i * -1).Month;
            strMon = (intMon < 10) ? ("0" + intMon.ToString()) : intMon.ToString();
            arrDay[intIdx] = (intDay < 10) ? (strMon + "-0" + intDay.ToString()) : (strMon + "-" + intDay.ToString());
        }

        strYY = dtSYMD.Year.ToString();
        strMM = (dtSYMD.Month > 9) ? dtSYMD.Month.ToString() : ("0" + dtSYMD.Month.ToString());
        strDD = (dtSYMD.Day > 9) ? dtSYMD.Day.ToString() : ("0" + dtSYMD.Day.ToString());
        strYMD = strYY + strMM + strDD;
        
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Mana_R057.PROC_Mana_R057_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[3];
        arrOpm[0] = new OracleParameter("i_YYMMDD", OracleType.VarChar, 8);
        arrOpm[0].Value = strYMD;
        arrOpm[1] = new OracleParameter("i_OFFICE", OracleType.VarChar, 12);
        arrOpm[1].Value = cboComCd.SelectedValue.ToString();
        arrOpm[2] = new OracleParameter("O_Mana_R057", OracleType.Cursor);
        arrOpm[2].Direction = ParameterDirection.Output;

        for (int i = 0; i<arrOpm.Length;i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        drawGraph(dsGrid, arrDay);
        setGrid(dsGrid, arrDay);
    }

    private void drawGraph(DataSet dsGrid, string[] arrDay)
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
            // For each Row add a new series
            oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                    row["SNM"].ToString(), null, SeriesChartType.Line, 3,
                                                    GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            for (int colIndex = 1; colIndex < dsGrid.Tables[0].Columns.Count; colIndex++)
            {
                // For each column (column 1 and onward) add the value as a point
                string columnName = dsGrid.Tables[0].Columns[colIndex].ColumnName;
                double YVal = double.Parse(row[columnName].ToString());
                Chart1.Series[oasrType[intLP].Name].Points.AddXY(arrDay[colIndex-1], YVal);
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
        Chart1.DataSource = dsGrid;
        Chart1.DataBind();

    }

    private void setGrid(DataSet dsGrid, string[] arrDay)
    {
        DataTable dtDay = new DataTable();
        dtDay.Columns.Add("구분",typeof(string));
        for (int i = 0; i < arrDay.Length; i++)
        {
            dtDay.Columns.Add(arrDay[i], typeof(double));
        }

        int intCol = dsGrid.Tables[0].Columns.Count;
        int intRow = dsGrid.Tables[0].Rows.Count;
        double[] arrSum = new double[arrDay.Length];
        DataRow drDay;

        for (int i = 0; i < intRow; i++)
        {
            drDay = dtDay.NewRow();
            for (int j = 0; j < intCol; j++)
            {
                if (j > 0)
                {
                    arrSum[j - 1] += Convert.ToDouble(dsGrid.Tables[0].Rows[i][j]); 
                }
                drDay[j] = dsGrid.Tables[0].Rows[i][j];
            }
            dtDay.Rows.Add(drDay);
        }

        drDay = dtDay.NewRow();
        for (int i = 0; i < arrSum.Length+1; i++)
        {
            if (i == 0)
            { 
                drDay[i] = "합계"; 
            }
            else
            {
                drDay[i] = Convert.ToDouble(arrSum[i-1]); 
            }

        }
        dtDay.Rows.Add(drDay);

        UltraWebGrid1.DataSource = dtDay.DefaultView;
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 48;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
        
    }
    
}