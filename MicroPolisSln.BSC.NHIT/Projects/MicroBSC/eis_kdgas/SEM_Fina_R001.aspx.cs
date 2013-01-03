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

public partial class eis_SEM_Fina_R001 : EISPageBase
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

            for (intLP = 0; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    strMM = "0"+intLP.ToString();
                }
                else
                {
                    strMM = intLP.ToString();
                }

                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM-1 == int.Parse(strMM))
                {
                    this.cboMM.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY+3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedValue = intYY.ToString();

            this.cboGbn.Items.Add(new ListItem("전기말", "A"));
            this.cboGbn.Items.Add(new ListItem("전년동월", "D"));
            //this.Chart1.Visible = false;
            /// </summary>
        }
    }

    private void _queryGrid(bool blnPostYn)
    {
        string strCYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strYM = strCYY + strMM;
        

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmd = new OracleCommand("PKG_SEM_Fina_R001.PROC_Fina_R001_01", _connection);
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Fina_R001.PROC_Fina_R001_02", _connection);
        _connection.Open();

        objCmd.CommandType = CommandType.StoredProcedure;
        objCmdGrph.CommandType = CommandType.StoredProcedure;

        //================================================================== Grid Query
        OracleParameter[] arrOpm = new OracleParameter[3];
        arrOpm[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpm[0].Value = strYM;
        arrOpm[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrOpm[1].Value = cboGbn.SelectedValue;
        arrOpm[2] = new OracleParameter("O_Fina_R001", OracleType.Cursor);
        arrOpm[2].Direction = ParameterDirection.Output;

        for (int i = 0; i<arrOpm.Length;i++)
        {
            objCmd.Parameters.Add(arrOpm[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmd);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();

        //================================================================== Graph Query
        OracleParameter[] arrGrph = new OracleParameter[3];
        arrGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrGrph[0].Value = strYM;
        arrGrph[1] = new OracleParameter("i_GUBUN", OracleType.VarChar, 2);
        arrGrph[1].Value = cboGbn.SelectedValue;
        arrGrph[2] = new OracleParameter("O_Fina_R001", OracleType.Cursor);
        arrGrph[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrGrph.Length; i++)
        {
            objCmdGrph.Parameters.Add(arrGrph[i]);
        }

        DataSet dsGrph = new DataSet();
        OracleDataAdapter daGrph = new OracleDataAdapter(objCmdGrph);
        daGrph.Fill(dsGrph);
        //drawGraph(dsGrph);
    }

    //private void drawGraph(DataSet dsGrph)
    //{
    //    DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 550, 50
    //        , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
    //        , Color.FromArgb(0xFF, 0xFF, 0xFE)
    //        , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
    //        , -1
    //        , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

    //    Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.StackedColumn, 0, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
    //    Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.StackedColumn, 0, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

    //    //------------------------------------------------------Chart2
    //    Chart1.DataSource = dsGrph.Tables[0].DefaultView;
    //    series1.ValueMembersY = "CY_AMT";
    //    series2.ValueMembersY = "PY_AMT";
    //    series1.ValueMemberX = "ACCT_NM";

    //    DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
    //    DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, true);

    //}

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

        e.Layout.Bands[0].HeaderLayout.Reset();
        e.Layout.Bands[0].Reset();
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader[] arrCh = new Infragistics.WebUI.UltraWebGrid.ColumnHeader[3];

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;

            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Key = "GUBUN";
        ch.Caption = "구     분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        int intSpan = 3;
        for (int i = 0; i < arrCh.Length; i++)
        {
            arrCh[i] = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            switch (i)
            {
                case 0:
                    if ( cboGbn.SelectedValue == "A") 
                    {
                        arrCh[i].Caption = Convert.ToString(int.Parse(cboYY.SelectedValue)-1)+"/"+"12";
                    }
                    else
                    {
                        arrCh[i].Caption = Convert.ToString(int.Parse(cboYY.SelectedValue)-1)+"/"+cboMM.SelectedValue;
                    }
                    break;
                case 1:
                    arrCh[i].Caption = cboYY.SelectedValue + "/" + cboMM.SelectedValue;
                    break;
                case 2:
                    arrCh[i].Caption = "전년대비";
                    break;
                default:
                    break;
            }
            arrCh[i].Key = e.Layout.Bands[0].Columns[i].Header.Caption;
            arrCh[i].RowLayoutColumnInfo.OriginY = 0;
            arrCh[i].RowLayoutColumnInfo.OriginX = intSpan;
            arrCh[i].RowLayoutColumnInfo.SpanX = 2;
            arrCh[i].Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(arrCh[i]);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            intSpan = intSpan + 2;
        }

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Width =90;
                e.Layout.Bands[0].Columns[i].MergeCells = true;
            }
            else if (i == 1)
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
                e.Layout.Bands[0].Columns[i].MergeCells = true;
            }
            else if (i == 2)
            {
                e.Layout.Bands[0].Columns[i].Width = 110;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = (i%2==0) ? 50:80;
                e.Layout.Bands[0].Columns[i].Format = (i % 2 == 0) ? "0.#" : "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow1(object sender, RowEventArgs e)
    {
        int[] arrCol = new int[1] { 8  };
        double[] arrRate = new double[1];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 99.999) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }
        if (e.Row.Cells[0].Value.ToString() == "자산총계"  ||
            e.Row.Cells[0].Value.ToString() == "부채와자본총계" )
        {
            e.Row.Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
            
        }
    }
}