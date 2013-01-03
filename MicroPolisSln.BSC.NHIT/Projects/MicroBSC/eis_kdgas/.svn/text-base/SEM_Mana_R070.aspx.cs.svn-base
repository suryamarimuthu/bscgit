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

public partial class eis_SEM_Mana_R070 : EISPageBase
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
            string strDD;
            int intLP;
            int iniYY;
            int iniDD;

            int intYY = objDT.Year;
            int intMM = objDT.Month;
            int intDD = objDT.Day;

            this.cboYY.Items.Clear();
            this.cboMM.Items.Clear();
            this.cboDD.Items.Clear();
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
                if (intMM  == intLP)
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

            for (iniDD = 1; iniDD <= 31; iniDD++)
            {
            	if ( iniDD < 10 )
            	{
                     strDD = "0" + iniDD.ToString();
                }
                else
                {
                    strDD = iniDD.ToString();
                }	
                this.cboDD.Items.Add(new ListItem(strDD, strDD));
                if ( intDD -1 == iniDD)
                {
                    this.cboDD.SelectedValue = strDD;
                }
            }



            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            cboCom.SelectedIndex = 0;

            this.cboGbn.Items.Add(new ListItem("일계", "D"));          
            this.cboGbn.Items.Add(new ListItem("월계", "M"));
            this.cboGbn.Items.Add(new ListItem("누계", "Y"));

            cboGbn.SelectedIndex = 0;
        }
    }

    private void _queryGrid()
    {
        string strYMD = (cboYY.SelectedValue + cboMM.SelectedValue + cboDD.SelectedValue);

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R070.PROC_Mana_R070_02", _connection);
        OracleCommand objCmdGrid = new OracleCommand("PKG_SEM_Mana_R070.PROC_Mana_R070_01", _connection);
        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];

        arrOpmGrph[0] = new OracleParameter("i_YYMMDD", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = cboCom.SelectedValue;
        arrOpmGrph[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmGrph[2].Value = cboGbn.SelectedValue;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R070", OracleType.Cursor);
        arrOpmGrph[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrOpmGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        this._setGraph(dsGrph);

        //================================================================== Grid Query
        OracleParameter[] arrOpmGrid = new OracleParameter[4];

        arrOpmGrid[0] = new OracleParameter("i_YYMMDD", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYMD);
        arrOpmGrid[1] = new OracleParameter("i_COMCD", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = cboCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpmGrid[2].Value = cboGbn.SelectedValue;
        arrOpmGrid[3] = new OracleParameter("O_Mana_R070", OracleType.Cursor);
        arrOpmGrid[3].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);
        //this.setGridData(dsGrid);
        UltraWebGrid1.DataSource = dsGrid;
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

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "건수", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        //------------------------------------------------------Chart2
        Chart1.DataSource = iDsSet.Tables[0].DefaultView;
        series1.ValueMembersY = "DCNT";

        series1.ValueMemberX = "CUST";


        string strChartArea = Chart1.Series[series1.Name].ChartArea;
        series1.YAxisType = AxisType.Secondary;


        Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";

        DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, true);
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

            e.Layout.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].Columns[0].MergeCells = true;

            for (int i = 1; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.#";

            }

    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int[] arrCol = new int[7] { 1,2,3,4,5,6,7 };
        double[] arrRate = new double[7];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] >= 0) ? System.Drawing.Color.Black : System.Drawing.Color.Red;
        }
    }
}