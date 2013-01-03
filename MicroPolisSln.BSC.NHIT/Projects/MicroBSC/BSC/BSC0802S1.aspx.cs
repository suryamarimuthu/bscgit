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
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

using MicroCharts;
using System.Drawing;
using Dundas.Charting.WebControl;

using MicroBSC.BSC.Biz;

public partial class BSC_BSC0802S1 : AppPageBase
{
    public static double dblAvg = 0;
    public static double dblStd = 0;

    UltraWebGrid TugrdBias;
    Chart TchartBias;
    DropDownList TddlEstGroup;

    bool blnSw    = false;
    bool blnCL    = false;
    string NewKey = "";
    string OldKey = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        TugrdBias    = this.ugrdKpiStatusTab.FindControl("ugrdBias")    as UltraWebGrid;
        TchartBias   = this.ugrdKpiStatusTab.FindControl("chartBias")   as Chart;
        TddlEstGroup = this.ugrdKpiStatusTab.FindControl("ddlEstGroup") as DropDownList;

        if (!IsPostBack)
        {
            this.SetEstGroup();
            this.SetInitForm();
            this.SetEstStatusGrid();
            //this.SetPointsForGraph();
        }
        else
        { 
        
        }
    }

    private void SetInitForm()
    { 
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, int.Parse(PageUtility.GetByValueDropDownList(ddlEstTermInfo)));
        this.ugrdKpiStatusTab.SelectedTab = 0;
    }

    private void SetEstStatusGrid()
    {
        Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        DataSet rDs = objBSC.GetEstStatusPerEmp(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                               , PageUtility.GetByValueDropDownList(ddlMonthInfo));
        ugrdEstStatus.Clear();
        ugrdEstStatus.DataSource = rDs;
        ugrdEstStatus.DataBind();        
    }

    private void SetEstGroup()
    {
        Biz_Bsc_Validation_Group objBSC = new Biz_Bsc_Validation_Group();
        DataSet rDs = objBSC.GetAllList();

        TddlEstGroup.Items.Clear();
        TddlEstGroup.DataSource     = rDs;
        TddlEstGroup.DataTextField  = "GROUP_NAME";
        TddlEstGroup.DataValueField = "GROUP_REF_ID";
        TddlEstGroup.DataBind();
    }

    private void SetPointsForGraph()
    {
        Biz_Bsc_Kpi_Qlt_Score_Had objBSC = new Biz_Bsc_Kpi_Qlt_Score_Had();
        DataSet rDs = objBSC.GetKpiEstAdjustList
                           ( PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                           , PageUtility.GetByValueDropDownList(ddlMonthInfo)
                           , 1
                           , PageUtility.GetIntByValueDropDownList(TddlEstGroup));

        TugrdBias.Clear();
        TugrdBias.DataSource = rDs;
        TugrdBias.DataBind();

        if (rDs.Tables[0].Rows.Count > 0)
        {
            dblAvg = Convert.ToDouble(rDs.Tables[0].Rows[0]["ALL_AVG"].ToString());
            dblStd = Convert.ToDouble(rDs.Tables[0].Rows[0]["ALL_STD"].ToString());
        }
        
        DataSet rDsGraph = objBSC.GetEstEmpBiasGraphList
                                 ( PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                 , PageUtility.GetByValueDropDownList(ddlMonthInfo)
                                 , 1
                                 , PageUtility.GetIntByValueDropDownList(TddlEstGroup));

        DundasCharts.DundasChartBase(TchartBias, ChartImageType.Flash, 800, 305
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        //TchartBias.ChartAreas["Default"].AxisY.Minimum = 40;

        Series serOriRng = DundasCharts.CreateSeries(TchartBias, "serOriRng", "Default", "원시점수구간",          null, SeriesChartType.RangeColumn, 0, GetChartColor(0), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series serAvgRng = DundasCharts.CreateSeries(TchartBias, "serAvgRng", "Default", "평균점수구간",          null, SeriesChartType.RangeColumn, 0, GetChartColor(1), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series serStdRng = DundasCharts.CreateSeries(TchartBias, "serStdRng", "Default", "평균.표준편차점수구간", null, SeriesChartType.RangeColumn, 0, GetChartColor(2), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series serEmpAvg = DundasCharts.CreateSeries(TchartBias, "serEmpAvg", "Default", "평가자별평균점수",      null, SeriesChartType.Line,        3, GetChartColor(3), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 0, 7, Color.FromArgb(64, 64, 64));
        Series serAllAvg = DundasCharts.CreateSeries(TchartBias, "serAllAvg", "Default", "전체평균점수",          null, SeriesChartType.Point,       1, GetChartColor(4), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 0, 7, Color.FromArgb(64, 64, 64));

        string strEstEmp = "";
        double dblEmpAvg = 0;
        double dblAllAvg = 0;
        double dblOriMin = 0;
        double dblOriMax = 0;
        double dblAvgMin = 0;
        double dblAvgMax = 0;
        double dblStdMin = 0;
        double dblStdMax = 0;

        int cntRow = rDsGraph.Tables[0].Rows.Count;
        for (int i = 0; i < cntRow; i++)
        {
            strEstEmp = rDsGraph.Tables[0].Rows[i]["EMP_NAME"].ToString();
            dblEmpAvg = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["ORI_AVG_SCORE"].ToString());
            dblAllAvg = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["ALL_AVG_SCORE"].ToString());
            dblOriMin = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["ORI_MIN_SCORE"].ToString());
            dblOriMax = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["ORI_MAX_SCORE"].ToString());
            dblAvgMin = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["AVG_MIN_SCORE"].ToString());
            dblAvgMax = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["AVG_MAX_SCORE"].ToString());
            dblStdMin = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["STD_MIN_SCORE"].ToString());
            dblStdMax = Convert.ToDouble(rDsGraph.Tables[0].Rows[i]["STD_MAX_SCORE"].ToString());

            object[] objOri = new object[] { dblOriMax, dblOriMin };
            object[] objAvg = new object[] { dblAvgMax, dblAvgMin };
            object[] objStd = new object[] { dblStdMax, dblStdMin };

            serEmpAvg.Points.AddXY(strEstEmp, dblEmpAvg);
            serAllAvg.Points.AddXY(strEstEmp, dblAllAvg);
            serOriRng.Points.AddXY(strEstEmp, objOri);
            serAvgRng.Points.AddXY(strEstEmp, objAvg);
            serStdRng.Points.AddXY(strEstEmp, objStd);
        }

        serEmpAvg.MarkerStyle = MarkerStyle.Diamond;
        serAllAvg.MarkerStyle = MarkerStyle.Triangle;

        serEmpAvg.ToolTip = "#VALY{N0}";
        serAllAvg.ToolTip = "#VALY{N0}";
        serOriRng.ToolTip = "#VALY{N0}";
        serAvgRng.ToolTip = "#VALY{N0}";
        serStdRng.ToolTip = "#VALY{N0}";
    }

    public void GetExcelFile()
    {
        
        ugrdEEP.ExcelStartRow = 5;
        ugrdEEP.ExportMode = ExportMode.Download;
        ugrdEEP.DownloadName = "AvgStdAdjustment";
        ugrdEEP.WorksheetName = "평균편차조정현황";
        ugrdEEP.Export(ugrdBias);
        return;
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평 가  기 간 : " + (ddlEstTermInfo.SelectedItem.Text + " / " + ddlMonthInfo.SelectedItem.Text);
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "전 체  평 균 : " + dblAvg.ToString();
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "전체표준편차 : " + dblStd.ToString();

        //e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
        //e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Height = 400;

        // Add a caption with some more information
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (ugrdKpiStatusTab.SelectedTab == 0)
        {
            this.SetEstStatusGrid();
        }
        else
        {
            this.SetPointsForGraph();
        }
    }
    protected void ugrdEstStatus_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        
    }
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, int.Parse(PageUtility.GetByValueDropDownList(ddlEstTermInfo)));
        this.SetEstStatusGrid();
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "2")
        {
            this.SetPointsForGraph();
            this.iBtnPrint.Visible = true;
        }
        else
        {
            this.iBtnPrint.Visible = false;
        }
    }
    protected void ugrdBias_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평가단";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX   = 1;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평가자";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX   = 1;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "지표명";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX   = 1;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "원시점수";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX   = 3;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평균조정점수";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX   = 3;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평균.편차조정점수";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX   = 3;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "조정여부";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 12;
        ch.RowLayoutColumnInfo.SpanX = 1;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[1].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[2].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[12].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 12;
        ch.RowLayoutColumnInfo.SpanY = 2;

        e.Layout.Bands[0].Columns.FromKey("EMP_NAME").CellStyle.BackColor  = Color.WhiteSmoke;
        e.Layout.Bands[0].Columns.FromKey("KPI_NAME").CellStyle.BackColor  = Color.WhiteSmoke;
        e.Layout.Bands[0].Columns.FromKey("ORI_SCORE").CellStyle.BackColor = Color.FromName("#DCE1E5");
        e.Layout.Bands[0].Columns.FromKey("AVG_SCORE").CellStyle.BackColor = Color.FromName("#DCE1E5");
        e.Layout.Bands[0].Columns.FromKey("STD_SCORE").CellStyle.BackColor = Color.FromName("#DCE1E5");
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.GetExcelFile();
    }

    protected void ugrdBias_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        NewKey = e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString();
        if (OldKey == NewKey)
        {
            blnSw = true;
        }
        else
        {
            blnSw = false;
            blnCL = (blnCL) ? false : true;
        }

        OldKey = NewKey;

        e.Row.Style.BackColor = (blnCL) ? Color.Wheat : Color.WhiteSmoke;
    }
    protected void ddlEstGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPointsForGraph();
    }
}
