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

public partial class eis_SEM_Mana_R001 : EISPageBase
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
            this.cboTCom.Items.Add(new ListItem("전체", "99"));
            this.cboTCom.Items.Add(new ListItem("울산", "21"));
            this.cboTCom.Items.Add(new ListItem("양산", "51"));
            this.cboTCom.SelectedIndex = 0;

            this.ddlGbn.Items.Add(new ListItem("시간대별공급량", "HS"));
            this.ddlGbn.Items.Add(new ListItem("일자별공급량", "DS"));
            this.ddlGbn.SelectedIndex = 0;

            this.ddlMT.Items.Add(new ListItem("시계", "HS"));
            this.ddlMT.Items.Add(new ListItem("누계", "TS"));
            this.ddlMT.SelectedIndex = 1;

            this._queryGrid();
        }
    }

    private void _queryGrid()
    {
        string strYY = "";
        string strMM = "";
        string strDD = "";
        string strYMD = "";
        string strPKG = "";
        DateTime dtYMD = Convert.ToDateTime(sDate.Value.ToString());

        strYY = dtYMD.Year.ToString();
        strMM = (dtYMD.Month > 9) ? dtYMD.Month.ToString() : ("0" + dtYMD.Month.ToString());
        strDD = (dtYMD.Day > 9) ? dtYMD.Day.ToString() : ("0" + dtYMD.Day.ToString());

        strYMD = strYY+strMM+strDD;

        //strPKG = (ddlMT.SelectedValue == "HS") ? "PKG_SEM_Mana_R001.PROC_Mana_R001_04" : "PKG_SEM_Mana_R001.PROC_Mana_R001_05";
        if ((ddlGbn.SelectedValue == "HS") && (ddlMT.SelectedValue == "HS")) // 시간대별, 시계
        {
            strPKG = "PKG_SEM_Mana_R001.PROC_Mana_R001_02";
        }
        else if ((ddlGbn.SelectedValue == "HS") && (ddlMT.SelectedValue == "TS")) // 시간대별, 누계
        {
            strPKG = "PKG_SEM_Mana_R001.PROC_Mana_R001_04";
        }
        else if (ddlGbn.SelectedValue == "DS")
        {
            strPKG = "PKG_SEM_Mana_R001.PROC_Mana_R001_05";
        }

        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleCommand objCmdGrph = new OracleCommand("PKG_SEM_Mana_R001.PROC_Mana_R001_01", _connection);
        OracleCommand objCmdGrid = new OracleCommand(strPKG, _connection);

        _connection.Open();

        objCmdGrph.CommandType = CommandType.StoredProcedure;
        objCmdGrid.CommandType = CommandType.StoredProcedure;

        //================================================================== Graph Query
        OracleParameter[] arrOpmGrph = new OracleParameter[4];
        
        arrOpmGrph[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrph[0].Value = (strYMD);
        arrOpmGrph[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpmGrph[1].Value = ((cboTCom.SelectedValue == "99") && (ddlGbn.SelectedValue == "DS")) ? "" : cboTCom.SelectedValue;
        arrOpmGrph[2] = new OracleParameter("i_SGUBUN", OracleType.VarChar, 2);
        arrOpmGrph[2].Value = ddlGbn.SelectedValue;
        arrOpmGrph[3] = new OracleParameter("O_Mana_R001", OracleType.Cursor);
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
        OracleParameter[] arrOpmGrid = new OracleParameter[3];

        arrOpmGrid[0] = new OracleParameter("i_YYMM", OracleType.VarChar, 8);
        arrOpmGrid[0].Value = (strYMD);
        arrOpmGrid[1] = new OracleParameter("i_TCOMCD", OracleType.VarChar, 12);
        arrOpmGrid[1].Value = ((cboTCom.SelectedValue == "99") && (ddlGbn.SelectedValue == "DS")) ? "" : cboTCom.SelectedValue;
        arrOpmGrid[2] = new OracleParameter("O_Mana_R001", OracleType.Cursor);
        arrOpmGrid[2].Direction = ParameterDirection.Output;

        for (int i = 0; i < arrOpmGrid.Length; i++)
        {
            objCmdGrid.Parameters.Add(arrOpmGrid[i]);
        }

        DataSet dsGrid = new DataSet();
        OracleDataAdapter daGrid = new OracleDataAdapter(objCmdGrid);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.Bands[0].ResetColumns();
        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }

    private void _setGraph(DataSet dsGrph)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 280
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        if (ddlGbn.SelectedValue == "HS") // 시간대별 누적공급량현황
        {
            DataTable dtSply = dsGrph.Tables[0].Clone();
            DataRow drSply;

            string strMM = "";
            double dblCQtn = 0.00;
            double dblPQtn = 0.00;
            for (int i = 0; i < dsGrph.Tables[0].Rows.Count; i++)
            {
                drSply = dtSply.NewRow();
                strMM = dsGrph.Tables[0].Rows[i][0].ToString();
                if (ddlMT.SelectedValue == "TS")
                {
                    dblCQtn += Convert.ToDouble(dsGrph.Tables[0].Rows[i]["CD_QTN"].ToString());
                    dblPQtn += Convert.ToDouble(dsGrph.Tables[0].Rows[i]["PD_QTN"].ToString());
                }
                else
                {
                    dblCQtn = Convert.ToDouble(dsGrph.Tables[0].Rows[i]["CD_QTN"].ToString());
                    dblPQtn = Convert.ToDouble(dsGrph.Tables[0].Rows[i]["PD_QTN"].ToString());
                }
                drSply[0] = strMM;
                drSply[1] = dblCQtn;
                drSply[2] = dblPQtn;
                dtSply.Rows.Add(drSply);
            }

            Chart1.DataSource = dtSply.DefaultView;
            Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "금일", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "전일", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            
            series1.ValueMembersY = "CD_QTN";
            series2.ValueMembersY = "PD_QTN";
            series1.ValueMemberX = "HH";

            Chart1.ChartAreas[Chart1.Series[series1.Name].ChartArea].AxisX.Interval = 2;
            Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";
            Chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;

            DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, true);
            DundasAnimations.GrowingAnimation(Chart1, series2, 3.0, 4.0, true);

            Chart1.DataBind();

        }
        else                              // 일자별 공급량
        {
            Chart1.DataSource = dsGrph.Tables[0].DefaultView;
            Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series series2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series series3 = DundasCharts.CreateSeries(Chart1, "Series3", "Default", "달성율", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


            series1.ValueMembersY = "QTN_PLAN";
            series2.ValueMembersY = "QTN_ACTL";
            series3.ValueMembersY = "QTN_RATE";
            series1.ValueMemberX = "GUBUN";

            string strChartArea = Chart1.Series[series3.Name].ChartArea;
            series3.YAxisType = AxisType.Secondary;

            Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            Chart1.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";
            Chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True ;
            Chart1.ChartAreas[Chart1.Series[series1.Name].ChartArea].AxisX.Interval = 1;

            DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, true);
            DundasAnimations.GrowingAnimation(Chart1, series2, 3.0, 4.0, true);
            DundasAnimations.GrowingAnimation(Chart1, series3, 4.0, 6.0, true);

            Chart1.DataBind();
        }
                           
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        int intWid = 0;
        int intCntCol = e.Layout.Bands[0].Columns.Count;

        e.Layout.Bands[0].HeaderLayout.Reset();
        if (ddlGbn.SelectedValue == "HS")
        {
            for (int i = 0; i < intCntCol; i++)
            {
                if (i == 0)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    e.Layout.Bands[0].Columns[i].Width = 64;
                }
                else if (i == 1)
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    e.Layout.Bands[0].Columns[i].Width = 43;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns[i].Format = "#,##0";
                    //e.Layout.Bands[0].Columns[i].Width = (i < 7) ? 30 : (30 + intWid++);
                    e.Layout.Bands[0].Columns[i].Width =  44;
                }
            }
        }
        else
        {
            int iIndex = 0;
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
            {
                c.Header.RowLayoutColumnInfo.OriginY = 1;
                iIndex++;
            }

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "금 일(차이:계획-실적)";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanX = 4;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "전 일(차이:금일-전일)";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 4;
            ch.RowLayoutColumnInfo.SpanX = 4;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "전년동일(차이:금일-전년동일)";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 8;
            ch.RowLayoutColumnInfo.SpanX = 4;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "전전년동일(차이:금일-전전년동일)";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 12;
            ch.RowLayoutColumnInfo.SpanX = 4;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            intWid = 800;
            for (int i = 0; i < intCntCol; i++)
            {
                switch (i % 4)
                { 
                    case 0:
                        e.Layout.Bands[0].Columns[i].Header.Caption = "계획";
                        break;
                    case 1:
                        e.Layout.Bands[0].Columns[i].Header.Caption = "실적";
                        break;
                    case 2:
                        e.Layout.Bands[0].Columns[i].Header.Caption = "달성율";
                        break;
                    case 3:
                        e.Layout.Bands[0].Columns[i].Header.Caption = "차이";
                        break;
                    default:
                        break;
                }
                
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].Width = (intCntCol==0) ? 0 : Convert.ToInt32((intWid / intCntCol));
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        if (ddlGbn.SelectedValue == "DS")
      {
        int[] arrCol = new int[4] { 2,6,10,14 };
        double[] arrRate = new double[4];
        double dblTmpVal = 0.00;

        for (int intCol = 0; intCol < arrCol.Length; intCol++)
        {
            arrRate[intCol] = Convert.ToDouble(e.Row.Cells[arrCol[intCol]].Value);
            e.Row.Cells[arrCol[intCol]].Style.ForeColor = (arrRate[intCol] > 100) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
        }
      }
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this._queryGrid();
    }

}
