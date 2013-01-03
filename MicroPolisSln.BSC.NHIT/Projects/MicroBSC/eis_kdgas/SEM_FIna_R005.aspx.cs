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

public partial class SEM_FIna_R005 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            this._initForm();
            this.setData();
        }
    }

    private void _initForm()
    {
        /// <summary>
        /// 폼초기화 및 기본값 세팅

            DateTime objDT = DateTime.Now;
            string strYY;
            string strMM;

            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.cboYY.Items.Clear();
            this.cboMM.Items.Clear();

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

            this.setAcctCD();
    }

    public void setAcctCD()
    {
        string query = @"
            SELECT DISTINCT                                      
                   FIN.SEM_ACCOUNT1_CODE,                        -- 손익계정 코드
                   FIN.SEM_ACCOUNT1_DESC                         -- 손익계정 명(Account1 Level)
              FROM SEM_FINANCIAL_CODE_MASTER FIN
             WHERE FIN.SEM_FINANCIAL_CODE = 'PL'
             ORDER BY FIN.SEM_ACCOUNT1_CODE";

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        this.cboActCd.DataSource       = ds;
        this.cboActCd.DataTextField = "SEM_ACCOUNT1_DESC";
        this.cboActCd.DataValueField = "SEM_ACCOUNT1_CODE";
        this.cboActCd.DataBind();
    }

    private void setData()
    {
        string strYM = cboYY.SelectedValue + cboMM.SelectedValue;
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Fina_R005.PROC_Fina_R005_01", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[4];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = strYM;
        arrOpm[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 10);
        arrOpm[1].Value = cboCom.SelectedValue;
        arrOpm[2] = new OracleParameter("i_ACCTCD", OracleType.VarChar, 20);
        arrOpm[2].Value = cboActCd.SelectedValue;
        arrOpm[3] = new OracleParameter("O_Fina_R005", OracleType.Cursor);
        arrOpm[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpm.Length; i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);
        this.getGridTable(dsGrid);
    }

    private void getGridTable(DataSet dsGrid)
    {
        DataTable dtGrid = Tbl_Grid();
        DataRow drGrid = null;
        DataRow drGrph = null;
        DataSet dsGrph = new DataSet();
        DataTable dtGrph = Tbl_Grid();

        int idxY = 0;
        int intCol = dsGrid.Tables[0].Columns.Count;
        int intRow = dsGrid.Tables[0].Rows.Count;

        for (int i = 0; i < intRow; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                drGrid = dtGrid.NewRow();
                switch (j)
                {
                    case 1:
                        drGrph = dtGrph.NewRow();
                        drGrid["serNo"] = j;
                        drGrph["serNo"] = j;
                        idxY = 0;
                        drGrid["구분"] = "이익원단위";
                        drGrid["내역"] = "계획";
                        drGrph["구분"] = "이익원단위";
                        drGrph["내역"] = "계획";
                        break;
                    case 2:
                        drGrph = dtGrph.NewRow();
                        drGrid["serNo"] = j;
                        drGrph["serNo"] = j;
                        idxY = 12;
                        drGrid["구분"] = "이익원단위";
                        drGrid["내역"] = "실적";
                        drGrph["구분"] = "이익원단위";
                        drGrph["내역"] = "실적";
                        break;
                    case 3:
                        drGrph = dtGrph.NewRow();
                        drGrid["serNo"] = j;
                        drGrph["serNo"] = j;
                        idxY = 24;
                        drGrid["구분"] = "이익원단위";
                        drGrid["내역"] = "달성율";
                        drGrph["구분"] = "이익원단위";
                        drGrph["내역"] = "달성율";
                        break;
                    case 4:
                        drGrid["serNo"] = j;
                        idxY = 36;
                        drGrid["구분"] = "매출량";
                        drGrid["내역"] = "계획";
                        break;
                    case 5:
                        drGrid["serNo"] = j;
                        idxY = 48;
                        drGrid["구분"] = "매출량";
                        drGrid["내역"] = "실적";
                        break;
                    case 6:
                        drGrid["serNo"] = j;
                        idxY = 60;
                        drGrid["구분"] = "매출량";
                        drGrid["내역"] = "달성율";
                        break;
                    case 7:
                        drGrid["serNo"] = j;
                        idxY = 72;
                        drGrid["구분"] = cboActCd.SelectedItem.Text;
                        drGrid["내역"] = "계획";
                        break;
                    case 8:
                        drGrid["serNo"] = j;
                        idxY = 84;
                        drGrid["구분"] = cboActCd.SelectedItem.Text;
                        drGrid["내역"] = "실적";
                        break;
                    case 9:
                        drGrid["serNo"] = j;
                        idxY = 96;
                        drGrid["구분"] = cboActCd.SelectedItem.Text;
                        drGrid["내역"] = "달성율";
                        break;
                    default:
                        break;
                }

                drGrid["1월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 0].ToString());
                drGrid["2월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 1].ToString());
                drGrid["3월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 2].ToString());
                drGrid["4월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 3].ToString());
                drGrid["5월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 4].ToString());
                drGrid["6월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 5].ToString());
                drGrid["7월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 6].ToString());
                drGrid["8월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 7].ToString());
                drGrid["9월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 8].ToString());
                drGrid["10월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 9].ToString());
                drGrid["11월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 10].ToString());
                drGrid["12월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 11].ToString());
                dtGrid.Rows.Add(drGrid);

                if (j < 4)
                {
                    drGrph["1월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 0].ToString());
                    drGrph["2월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 1].ToString());
                    drGrph["3월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 2].ToString());
                    drGrph["4월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 3].ToString());
                    drGrph["5월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 4].ToString());
                    drGrph["6월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 5].ToString());
                    drGrph["7월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 6].ToString());
                    drGrph["8월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 7].ToString());
                    drGrph["9월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 8].ToString());
                    drGrph["10월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 9].ToString());
                    drGrph["11월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 10].ToString());
                    drGrph["12월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 11].ToString());
                    dtGrph.Rows.Add(drGrph);
                }
            }
        }
        DataView dvGrid = dtGrid.DefaultView;
        dvGrid.Sort = "serNo";
        UltraWebGrid1.DataSource = dvGrid;
        UltraWebGrid1.DataBind();

        dsGrph.Tables.Add(dtGrph);
        this.setGrph(dsGrph);
        return;
    }

    private void setGrph(DataSet dsGrid)
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
            if (row["내역"].ToString() == "달성율")
            {
                oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                        row["내역"].ToString(), null, SeriesChartType.Line, 3,
                                                        GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                string strChartArea = Chart1.Series[oasrType[intLP].Name].ChartArea;
                oasrType[intLP].YAxisType = AxisType.Secondary;
                Chart1.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";
            }
            else
            {
                oasrType[intLP] = DundasCharts.CreateSeries(Chart1, "Series" + intLP.ToString(), Chart1.ChartAreas[0].Name,
                                                        row["내역"].ToString(), null, SeriesChartType.Column, 0,
                                                        GetChartColor(intLP), GetChartColor(intLP), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            }

            for (int colIndex = 3; colIndex < dsGrid.Tables[0].Columns.Count; colIndex++)
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
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
            else
                DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);
        }

        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        Chart1.DataSource = dsGrid.Tables[0].DefaultView;
        Chart1.DataBind();
    }

    private DataTable Tbl_Grid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("serNo", typeof(int));
        dt.Columns.Add("구분", typeof(string));
        dt.Columns.Add("내역", typeof(string));
        dt.Columns.Add("1월", typeof(double));
        dt.Columns.Add("2월", typeof(double));
        dt.Columns.Add("3월", typeof(double));
        dt.Columns.Add("4월", typeof(double));
        dt.Columns.Add("5월", typeof(double));
        dt.Columns.Add("6월", typeof(double));
        dt.Columns.Add("7월", typeof(double));
        dt.Columns.Add("8월", typeof(double));
        dt.Columns.Add("9월", typeof(double));
        dt.Columns.Add("10월", typeof(double));
        dt.Columns.Add("11월", typeof(double));
        dt.Columns.Add("12월", typeof(double));
        return dt;
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setData();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Hidden = true;
            }
            else if (i == 1)
            {
                e.Layout.Bands[0].Columns[i].Width = 80;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                e.Layout.Bands[0].Columns[i].MergeCells = true;
            }
            else if (i == 2)
            {
                e.Layout.Bands[0].Columns[i].Width = 80;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 90;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.0";
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow1(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        double dblRate = 0.0;
        if (e.Row.Cells[2].Value.ToString() == "달성율")
        {
            for (int i = 3; i < UltraWebGrid1.Bands[0].Columns.Count; i++)
            {
                dblRate = Convert.ToDouble(e.Row.Cells[i].Value);
                e.Row.Cells[i].Style.ForeColor = (dblRate >= 100) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
            }
        }
    }
}
