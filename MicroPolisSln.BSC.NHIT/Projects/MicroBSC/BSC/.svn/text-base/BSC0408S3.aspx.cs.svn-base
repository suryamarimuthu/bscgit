using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using MicroCharts;
using MicroBSC.Estimation.Dac;
using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;


using Infragistics.WebUI.UltraWebGrid;
using Dundas.Gauges.WebControl;
//using Dundas.Charting.WebControl;
using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC0408S3 : AppPageBase
{
    #region ================= [변수선언] ====================
    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IEstDeptID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public int IDeptID
    {
        get
        {
            if (ViewState["COM_DEPT_REF_ID"] == null)
            {
                ViewState["COM_DEPT_REF_ID"] = GetRequestByInt("COM_DEPT_REF_ID", 0);
            }

            return (int)ViewState["COM_DEPT_REF_ID"];
        }
        set
        {
            ViewState["COM_DEPT_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public int IThresholdRefID
    {
        get
        {
            if (ViewState["THRESHOLD_REF_ID"] == null)
            {
                ViewState["THRESHOLD_REF_ID"] = GetRequestByInt("THRESHOLD_REF_ID", 0);
            }

            return (int)ViewState["THRESHOLD_REF_ID"];
        }
        set
        {
            ViewState["THRESHOLD_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string ISumType
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "");
            }

            return (string)ViewState["SUM_TYPE"];
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }

    public int iRow = 0;
    public int iCol = 0;

    private int chartHeight = 250;

    public const int iPageSize = 4;

    public enum COL_KEY
    { 
        KEY_FIELD
       ,VAL_FIELD
    }

    public enum GAUGE_COLOR_TYPE
    { 
        TYPE1
       ,TYPE2
       ,TYPE3
    }

    // 흐린색, 진한색
    public Color[,] arrColor = new Color[,] 
    { 
        {ColorTranslator.FromHtml("#F7F6FB"), ColorTranslator.FromHtml("#D9E7DA")},
        {ColorTranslator.FromHtml("#FCF7F3"), ColorTranslator.FromHtml("#EFE0D9")},
        {ColorTranslator.FromHtml("#F5F4F9"), ColorTranslator.FromHtml("#D6D5E5")} 
    };

    #endregion

    #region =================== [페이지초기화] ===================
    protected void Page_Load(object sender, EventArgs e)
    {
        //좌측메뉴설정
        base.SetMenuControl(true, true, true);

        this.ExecuteOnLoad();
        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        {
            
        }
    }

    public void ExecuteOnLoad()
    {
        iBtnSearch.Click += new ImageClickEventHandler(iBtnSearch_Click);
        ddlEstTermInfo.AutoPostBack = true;
        ddlEstTermInfo.SelectedIndexChanged += new EventHandler(ddlEstTermInfo_SelectedIndexChanged);

        txtResult1.Value = 0;
        txtResult2.Value = 0;
        txtResult3.Value = 0;
        txtResult4.Value = 0;
        txtTarget1.Value = 0;
        txtTarget2.Value = 0;
        txtTarget3.Value = 0;
        txtTarget4.Value = 0;
        lblTargetUNm1.Text = "-";
        lblTargetUNm2.Text = "-";
        lblTargetUNm3.Text = "-";
        lblTargetUNm4.Text = "-";
        lblResultUNm1.Text = "-";
        lblResultUNm2.Text = "-";
        lblResultUNm3.Text = "-";
        lblResultUNm4.Text = "-";

        lblKpiName1.Text = "-";
        lblKpiName2.Text = "-";
        lblKpiName3.Text = "-";
        lblKpiName4.Text = "-";
    }

    private void NotPostBackSetting()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        WebCommon.SetSumTypeDropDownList(ddlSumType, false);

        lblEntScore.Style.Add(HtmlTextWriterStyle.FontFamily    , "MS Gothic");
        lblEntScore.Style.Add(HtmlTextWriterStyle.FontWeight    , "bold");
        lblEntScore.Style.Add(HtmlTextWriterStyle.VerticalAlign , "middle");
        lblEntScore.Style.Add(HtmlTextWriterStyle.FontSize      , "50pt");
        lblEntScore.Style.Add(HtmlTextWriterStyle.Color         , "navy");

        this.SetAllGraph();
    }

    private void SetParameter()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.ISumType      = PageUtility.GetByValueDropDownList(ddlSumType);

        DeptInfos objDept  = new DeptInfos();
        this.IEstDeptID = objDept.GetRootEstDeptID(this.IEstTermRefID);

    }
    #endregion

    #region ==================== [ 내부함수 ] =====================

    public void SetAllGraph()
    {
        this.SetParameter();
        //this.SetEntStatus(chtEntViewSta);
        this.SetEntGradeRate(chtEntGrade);
        this.SetEntGradeRateTrend(chtEntGradeTrend);
        this.SetEntGradeView(chtEntGradeView);
        this.SetKpiStatus();
    }


    #region [ 전사점수 및 관점별 달성율]
    public void SetEntStatus(Chart iChart)
    {
        //전사점수
        Biz_Bsc_Score_Card objBSC = new Biz_Bsc_Score_Card();
        DataSet dsScore = objBSC.GetEstDeptTotalScore(this.IEstTermRefID, this.IYmd, this.ISumType, this.IEstDeptID);

        if (dsScore.Tables.Count > 0)
        {
            if (dsScore.Tables[0].Rows.Count > 0)
            {
                lblEntScore.Text = Math.Round(decimal.Parse(dsScore.Tables[0].Rows[0]["POINT"].ToString()),0).ToString();
            }
        }
        else
        {
            lblEntScore.Text = "0";
        }

        // 관점별 달성도
        DataSet dsViw = objBSC.GetEstDeptKpiViewTypeList(this.IEstTermRefID, this.IYmd, this.ISumType, this.IEstDeptID);

        MSCharts.GetDefaultChart(iChart, ChartImageType.Jpeg, 300, 178, true, false, true);
        //iChart.Titles.Add("전사 관점별 달성도", Docking.Top);

        iRow = dsViw.Tables[0].Rows.Count;
        
        if (iRow > 0)
        {
            Series serARate = MSCharts.CreateSeries(iChart, "1", iChart.ChartAreas[0].Name, "달성율", null, SeriesChartType.Bar, 0, GetChartColor(0), Color.FromArgb(chartHeight, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            dsViw.Tables[0].DefaultView.Sort = "VIEW_REF_ID desc";
            iChart.DataSource                = dsViw.Tables[0].DefaultView;
            serARate.YValueMembers           = "ACHV_RATE";
            serARate.XValueMember            = "VIEW_NAME";
            iChart.DataBind();

            for (int i = 0; i < serARate.Points.Count; i++ )
            {
                serARate.Points[i].Color = GetChartColor(i);
            }

            serARate.ToolTip = "#VALY{P}";
        }
    }

    #endregion

    #region [전사지표 등급구성비]

    // 전사 현재월 등급구성비
    public void SetEntGradeRate(Chart iChart)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet dsGrd = objBSC.GetKpiEntGradeStatus
                                                 ( this.IYmd
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID);

        MSCharts.GetDefaultChart(iChart, ChartImageType.Jpeg, 230, chartHeight, true, false, true);
        ChartArea FstChtArea     = iChart.ChartAreas[0];
        FstChtArea.Position.Auto = true;
        
        string sTitle = PageUtility.GetByTextDropDownList(ddlMonthInfo) +" 현재 지표등급 구성비";
        MSCharts.CreateTitle(iChart, sTitle);

        
        if (dsGrd.Tables[0].Rows.Count > 0)
        {

            Series serCRate = MSCharts.CreateSeries(iChart, "serA", iChart.ChartAreas[0].Name, "달성율", null, SeriesChartType.Pie, 0, GetChartColor(0), Color.FromArgb(chartHeight, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            iChart.DataSource      = dsGrd;

            iRow = dsGrd.Tables[0].Rows.Count;
            for (int i = 0; i < iRow; i++)
            {
                string sValue = dsGrd.Tables[0].Rows[i]["COMP_RATE"].ToString();
                string sColor = dsGrd.Tables[0].Rows[i]["THRESHOLD_COLOR"].ToString();
                serCRate.Points.Add(double.Parse(sValue));
                serCRate.Points[i].Color = ColorTranslator.FromHtml(sColor);
                if (sValue.IndexOf('.') > 0)
                {
                    serCRate.Points[i].Label = sValue.Substring(0, sValue.IndexOf('.')) + "%";
                }
                else
                {
                    serCRate.Points[i].Label = sValue + "%";
                }
            }

            //serCRate.ToolTip = "X value \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";
            serCRate.ToolTip = "#VALY{P}";
        }
    }

    // 전사 등급추이
    public void SetEntGradeRateTrend(Chart iChart)
    {
        DateTime startYM = (DateTime.ParseExact(this.IYmd, "yyyyMM", null)).AddYears(-1);
        Biz_Bsc_Score_Card objBSC = new Biz_Bsc_Score_Card();
        DataSet dsGrd = objBSC.GetKpiEntGradeStatus
                                                 ( base.GetYMDFromDateTime(startYM,"").Substring(0,6)
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID);

        MSCharts.GetDefaultChart(iChart, ChartImageType.Jpeg, 520, chartHeight, true, true, true);
        ChartArea FstChtArea = iChart.ChartAreas[0];

        iChart.Legends[0].Alignment   = StringAlignment.Near;
        iChart.Legends[0].LegendStyle = LegendStyle.Column;
        iChart.Legends[0].Docking     =  Docking.Left;
        //iChart.Legends[0].DockInsideChartArea = false;

        string sTitle = "지표 등급추이분석";
        MSCharts.CreateTitle(iChart, sTitle);

        //FstChtArea.AxisY.Title = "구성비";

        DataTable dtGrade = this.GetGradeSchema();

        if (dsGrd.Tables.Count > 0)
        { 
            iRow = dsGrd.Tables[0].Rows.Count;
            for (int i = 0; i < iRow; i++)
            {
                string sKey  = dsGrd.Tables[0].Rows[i]["THRESHOLD_REF_ID"].ToString();
                string sVal  = dsGrd.Tables[0].Rows[i]["THRESHOLD_KNAME"].ToString();
                string sYmd  = dsGrd.Tables[0].Rows[i]["YMD"].ToString();
                decimal dVal = decimal.Parse(dsGrd.Tables[0].Rows[i]["COMP_RATE"].ToString());

                for (int k = 0; k < dtGrade.Rows.Count; k++)
                {
                    if (sYmd.Equals(dtGrade.Rows[k][COL_KEY.KEY_FIELD.ToString()].ToString()) && dtGrade.Columns.Contains(sKey))
                    {
                        dtGrade.Rows[k][sKey] = dVal;
                    }
                }
            }

            FstChtArea.AxisY.LabelStyle.Format = "P0";

            iCol = dtGrade.Columns.Count;
            //DundasAnimations.DundasChartBase(iChart, AnimationTheme.GrowingTogether, -1, -1, false, 1);
            iChart.DataSource = dtGrade;
            for (int m = 1; m < iCol; m++)
            {
                Series serAchv = MSCharts.CreateSeries(iChart, m.ToString(), iChart.ChartAreas[0].Name, dtGrade.Columns[m].Namespace, null,
                                                           SeriesChartType.StackedColumn100, 0, ColorTranslator.FromHtml(dtGrade.Columns[m].Caption), 
                                                           Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                serAchv.ToolTip = "#VALY{P}";

                //DundasAnimations.GrowingAnimation(iChart, serAchv, m, m, true);
                serAchv.YValueMembers        = dtGrade.Columns[m].ColumnName;

                if (m == 1)
                {
                    serAchv.XValueMember = dtGrade.Columns[COL_KEY.KEY_FIELD.ToString()].ColumnName;
                }
            }

            iChart.DataBind();
        }
    }
    // 전사 관점별 경고지표 구성비
    public void SetEntGradeView(Chart iChart)
    {
        MSCharts.GetDefaultChart(iChart, ChartImageType.Jpeg, 230, chartHeight, true, false, true);
        ChartArea FstChtArea     = iChart.ChartAreas[0];
        FstChtArea.Position.Auto = true;

        string sTitle = PageUtility.GetByTextDropDownList(ddlMonthInfo) + " 현재 위험지표 구성비";
        MSCharts.CreateTitle(iChart, sTitle);

        if (this.IThresholdRefID < 1)
        {
            return;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet dsGrd = objBSC.GetKpiEntGradeAlert
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IThresholdRefID);

        if (dsGrd.Tables[0].Rows.Count > 0)
        {

            Series serCRate = MSCharts.CreateSeries(iChart, "serA", iChart.ChartAreas[0].Name, "달성율", null, SeriesChartType.Pie, 0, GetChartColor(0), Color.FromArgb(chartHeight, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            iChart.DataSource      = dsGrd;

            iRow = dsGrd.Tables[0].Rows.Count;
            for (int i = 0; i < iRow; i++)
            {
                string sValue = dsGrd.Tables[0].Rows[i]["COMP_RATE"].ToString();
                string sText  = dsGrd.Tables[0].Rows[i]["VIEW_NAME"].ToString();
                serCRate.Points.Add(double.Parse(sValue));
                serCRate.Points[i].Color = GetChartColor(i);
                serCRate.Points[i].Label = sText;
            }

            //serCRate.ToolTip = "X value \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";
            serCRate.ToolTip = "#VALY{P}";
        }
    }
    /// <summary>
    /// 시그널추이 스키마
    /// YMD | E | G | W | A
    /// </summary>
    /// <returns></returns>
    public DataTable GetGradeSchema()
    {
        DataTable dtGrade = new DataTable("GRADE");
        Biz_Bsc_Threshold_Code objTC = new Biz_Bsc_Threshold_Code();
        DataSet dsGrade = objTC.GetThresholdCodeList("");
        DataRow drGrade = null;

        DateTime startYM = (DateTime.ParseExact(this.IYmd, "yyyyMM", null)).AddYears(-1);

        dtGrade.Columns.Add(COL_KEY.KEY_FIELD.ToString(), typeof(string));

        iRow = dsGrade.Tables[0].Rows.Count;
        for (int i = iRow-1; i > -1; i--)
        {
            bool IsDefault = (dsGrade.Tables[0].Rows[i]["DEFAULT_IMG_YN"].ToString().ToUpper() == "N") ? false : true;
            if (!IsDefault)
            {
                DataColumn dc = dtGrade.Columns.Add(dsGrade.Tables[0].Rows[i]["THRESHOLD_REF_ID"].ToString(), typeof(decimal));
                dc.Caption    = dsGrade.Tables[0].Rows[i]["THRESHOLD_COLOR"].ToString();
                dc.Namespace  = dsGrade.Tables[0].Rows[i]["THRESHOLD_KNAME"].ToString();
            }

            if (dsGrade.Tables[0].Rows[i]["ALERT_IMG_YN"].ToString().ToUpper() == "Y")
            {
                this.IThresholdRefID = int.Parse(dsGrade.Tables[0].Rows[i]["THRESHOLD_REF_ID"].ToString());
            }
        }

        for (int i = 1; i <= 12; i++)
        {
            drGrade = dtGrade.NewRow();
            drGrade[COL_KEY.KEY_FIELD.ToString()] = startYM.AddMonths(i).ToString("yyyyMM");
            dtGrade.Rows.Add(drGrade);
        }

        return dtGrade;
    }

    /// <summary>
    /// 주요지표 스키마 추가 및 데이터 바인딩
    /// YMD | E | G | W | A | 매출액 | 공급량 | ...
    /// </summary>
    /// <returns></returns>
    //public DataTable GetGradeSchema(DataTable iDt)
    //{
    //    DateTime startYM = (DateTime.ParseExact(this.IYmd, "yyyyMM", null)).AddYears(-1);
    //    DataTable dtGrade = iDt;
    //    Biz_Bsc_Kpi_Dashboard objTC = new Biz_Bsc_Kpi_Dashboard();
    //    DataSet dsGrade = objTC.GetDashBoardKpiList(this.IEstTermRefID);
    //    DataRow drGrade = null;

    //    iRow = dsGrade.Tables[0].Rows.Count;
    //    for (int i = 0; i < iRow; i++)
    //    {
    //            DataColumn dc = dtGrade.Columns.Add(dsGrade.Tables[0].Rows[i]["KPI_REF_ID"].ToString(), typeof(decimal));
    //            dc.Caption    = dsGrade.Tables[0].Rows[i]["NAME_KNAME"].ToString();
    //    }

    //    DataSet actDs = new DataSet();

    //    string sKpiNm   = "";
    //    string sUnitNm  = "";
    //    decimal dTarget = 0;
    //    decimal dResult = 0;
    //    double dAVRate  = 0;
    //    string sColT = (this.ISumType == "MS") ? "TARGET_MS" : "TARGET_TS";
    //    string sColR = (this.ISumType == "MS") ? "RESULT_MS" : "RESULT_TS";
    //    string sColA = (this.ISumType == "MS") ? "ACHV_RATE_MS" : "ACHV_RATE_TS";

    //    if (dsGrade.Tables.Count > 0)
    //    {
    //        iRow = dsGrade.Tables[0].Rows.Count;
    //        for (int i = 0; i < iRow; i++)
    //        {
    //            this.IKpiRefID = int.Parse(dsGrade.Tables[0].Rows[i]["KPI_REF_ID"].ToString());
    //            actDs = objTC.GetDashBoardForKpiAnalysis( this.IEstTermRefID, this.IKpiRefID
    //                                                    , base.GetYMDFromDateTime(startYM, "").Substring(0, 6)
    //                                                    , this.IYmd, this.ISumType);

    //            if (actDs.Tables.Count > 0)
    //            {
    //                if (actDs.Tables[0].Rows.Count > 0)
    //                {
    //                    string sYmd = "";
    //                    for (int k = 0; k < dtGrade.Rows.Count; k++)
    //                    {
    //                        if (sYmd.Equals(dtGrade.Rows[k][COL_KEY.KEY_FIELD.ToString()].ToString()) && dtGrade.Columns.Contains(sKey))
    //                        {
    //                            dtGrade.Rows[k][sKey] = dVal;
    //                        }
    //                    }



    //                    dTarget = decimal.Parse(actDs.Tables[0].Rows[0][sColT].ToString());
    //                    dResult = decimal.Parse(actDs.Tables[0].Rows[0][sColR].ToString());
    //                    dAVRate = double.Parse(actDs.Tables[0].Rows[0][sColA].ToString());
    //                }
    //            }
    //        }
    //    }

    //    return dtGrade;
    //}


    #endregion

    #region [지표현황 - 게이지 설정]
    public void SetGuageLayout(GaugeContainer iGauge, GAUGE_COLOR_TYPE iColorType)
    {  
        iGauge.Height = Unit.Pixel(130);
        iGauge.Width  = Unit.Pixel(240);
        iGauge.AutoLayout = false;

        iGauge.BackFrame.BorderColor  = Color.FromArgb(212, 208, 200);
        iGauge.BackFrame.BorderWidth  = 0;
        iGauge.BackFrame.FrameWidth   = 0f;
        iGauge.BackFrame.FrameStyle   = BackFrameStyle.None;
        iGauge.BackFrame.FrameShape   = BackFrameShape.AutoShape;
        iGauge.BackFrame.ShadowOffset = 0f;
        iGauge.BackFrame.BorderStyle  = GaugeDashStyle.NotSet;

        iGauge.CircularGauges.Clear();
        iGauge.CircularGauges.Add("Default");
        CircularGauge cclg = iGauge.CircularGauges[0];
        cclg.Size.Width    = 100f;
        cclg.Size.Height   = 96f;
        cclg.PivotPoint.X  = 50f;
        cclg.PivotPoint.Y  = 87f;
        cclg.BackFrame.BackColor            = arrColor[(int)iColorType, 0];
        cclg.BackFrame.BackGradientEndColor = arrColor[(int)iColorType, 1];
        cclg.BackFrame.BackGradientType = Dundas.Gauges.WebControl.GradientType.TopBottom;
        cclg.BackFrame.BorderColor      = Color.DarkGray;
        cclg.BackFrame.BorderWidth      = 2;
        cclg.BackFrame.FrameGradientType = Dundas.Gauges.WebControl.GradientType.None;
        cclg.BackFrame.FrameStyle        = BackFrameStyle.Edged;
        cclg.BackFrame.FrameShape        = BackFrameShape.AutoShape;
        cclg.BackFrame.FrameWidth        = 0f;
        cclg.Location.X = 0f;
        cclg.Location.Y = 0f;

        cclg.Ranges.Clear();
        //cclg.Ranges.Add("Alert");
        //CircularRange cclr = cclg.Ranges[0];
        //cclr.StartValue = 0;
        //cclr.EndValue   = 50;
        //cclr.StartWidth = 200f;
        //cclr.EndWidth   = 200f;

        iGauge.Labels.Clear();
        iGauge.Labels.Add("Default");
        GaugeLabel gglt = iGauge.Labels[0];
        gglt.BackColor = Color.Transparent;
        gglt.BackGradientType = Dundas.Gauges.WebControl.GradientType.None;
        //gglt.Parent = cclg.Name;
        gglt.Text   = "단위";
        gglt.TextAlignment = ContentAlignment.MiddleCenter;
        gglt.Size.Height = 11f;
        gglt.Size.Width  = 30f;
        gglt.Location.X  = 36f;
        gglt.Location.Y  = 46f;


        cclg.Scales.Clear();
        cclg.Scales.Add("Default");
        CircularScale ccls = cclg.Scales[0];
        ccls.BorderColor  = Color.Gray;
        ccls.FillColor    = Color.Black;
        ccls.Radius       = 58f;
        ccls.ShadowOffset = 0f;
        ccls.StartAngle   = 90f;
        ccls.SweepAngle   = 180f;
        ccls.Width        = 1f;

        ccls.LabelStyle.DistanceFromScale = 5f;
        ccls.LabelStyle.Placement = Placement.Outside;
        ccls.LabelStyle.TextColor = Color.Black;

        ccls.MajorTickMark.BorderColor       = Color.Black;
        ccls.MajorTickMark.BorderWidth       = 1;
        ccls.MajorTickMark.DistanceFromScale = 1f;
        ccls.MajorTickMark.FillColor         = Color.Black;
        ccls.MajorTickMark.Length            = 10f;
        ccls.MajorTickMark.Placement         = Placement.Outside;
        ccls.MajorTickMark.Shape             = Dundas.Gauges.WebControl.MarkerStyle.Wedge;
        ccls.MajorTickMark.Width             = 2f;

        ccls.MinorTickMark.BorderColor       = ccls.MajorTickMark.BorderColor;
        ccls.MinorTickMark.BorderWidth       = 1;
        ccls.MinorTickMark.DistanceFromScale = 1f;
        ccls.MinorTickMark.FillColor         = ccls.MajorTickMark.FillColor;
        ccls.MinorTickMark.Length            = 7f;
        ccls.MinorTickMark.Placement         = Placement.Outside;
        ccls.MinorTickMark.Shape             = Dundas.Gauges.WebControl.MarkerStyle.Wedge;
        ccls.MinorTickMark.Width             = 2f;
        ccls.MinorTickMark.EnableGradient    = false;

        cclg.Pointers.Clear();
        CircularPointer cclp = cclg.Pointers[0];
        cclp.BorderWidth          = 0;
        cclp.CapFillColor         = Color.Silver;
        cclp.FillGradientEndColor = Color.MediumTurquoise;
        cclp.CapReflection        = true;
        cclp.CapWidth             = 20f;
        cclp.DistanceFromScale    = 1f;
        cclp.FillColor            = Color.Red;
        cclp.FillGradientEndColor = Color.Pink;
        cclp.FillGradientType     = Dundas.Gauges.WebControl.GradientType.LeftRight;
        cclp.NeedleStyle          = NeedleStyle.NeedleStyle4;
        cclp.Placement            = Placement.Outside;
        cclp.Width                = 13f;

        cclp.SnappingEnabled = true;
        cclp.SnappingInterval = 1;


        cclp.Value = 50;
        ccls.Maximum = 100;
        ccls.Minimum = 0;
    }

    public void SetGuageLayout2(GaugeContainer iGauge, GAUGE_COLOR_TYPE iColorType, double iRate)
    {
        Font fntDefault = new Font("", 12f, FontStyle.Regular, GraphicsUnit.Pixel);

        // Gauge 기본설정
        iGauge.Height = Unit.Pixel(130);
        iGauge.Width  = Unit.Pixel(200);
        iGauge.AutoLayout = true;

        iGauge.BackFrame.BorderColor  = Color.FromArgb(212, 208, 200);
        iGauge.BackFrame.BorderWidth  = 0;
        iGauge.BackFrame.FrameWidth   = 0f;
        iGauge.BackFrame.FrameStyle   = BackFrameStyle.None;
        iGauge.BackFrame.FrameShape   = BackFrameShape.AutoShape;
        iGauge.BackFrame.ShadowOffset = 0f;
        iGauge.BackFrame.BorderStyle  = GaugeDashStyle.NotSet;

        //iGauge.MapAreas.Clear();
        //iGauge.StateIndicators.Clear();
        
        // 원형게이지 설정
        iGauge.CircularGauges.Clear();
        iGauge.CircularGauges.Add("Default");
        CircularGauge cclg = iGauge.CircularGauges[0];
        cclg.Size.Width    = 100f;
        cclg.Size.Height   = 96f;
        cclg.PivotPoint.X  = 50f;
        cclg.PivotPoint.Y  = 87f;

        cclg.BackFrame.BackGradientType = Dundas.Gauges.WebControl.GradientType.None;
        cclg.BackFrame.BorderColor      = Color.Transparent;
        cclg.BackFrame.BorderWidth      = 0;
        cclg.BackFrame.FrameGradientType = Dundas.Gauges.WebControl.GradientType.None;
        cclg.BackFrame.FrameStyle        = BackFrameStyle.None;
        cclg.BackFrame.FrameShape        = BackFrameShape.AutoShape;
        cclg.BackFrame.FrameWidth        = 0f;
        cclg.Location.X = 0f;
        cclg.Location.Y = 0f;
        
        cclg.Knobs.Clear();
        cclg.Ranges.Clear();

        // 게이지 제목 설정
        iGauge.Labels.Clear();
        iGauge.Labels.Add("Default");
        

        GaugeLabel gglt = iGauge.Labels[0];
        gglt.BackColor = Color.Transparent;
        gglt.BackGradientType = Dundas.Gauges.WebControl.GradientType.None;
        //gglt.Parent = cclg.Name;
        gglt.Text   = "달성율(%)";
        gglt.TextAlignment = ContentAlignment.MiddleCenter;
        gglt.Size.Height = 11f;
        gglt.Size.Width  = 30f;
        gglt.Location.X  = 36f;
        gglt.Location.Y  = 46f;
        gglt.Font        = fntDefault;

        // 게이지 눈금 설정
        cclg.Scales.Clear();
        cclg.Scales.Add("Default");
        CircularScale ccls = cclg.Scales[0];
        ccls.BorderColor  = Color.Gray;
        ccls.FillColor = ColorTranslator.FromHtml("#5A78AF"); // #ADC9DC
        ccls.Radius       = 73f;
        ccls.ShadowOffset = 0f;
        ccls.StartAngle   = 80f;
        ccls.SweepAngle   = 200f;
        ccls.Width        = 25f;
        ccls.FillGradientType = Dundas.Gauges.WebControl.GradientType.None;
        ccls.FillHatchStyle   = GaugeHatchStyle.None;

        ccls.LabelStyle.DistanceFromScale = 5f;
        ccls.LabelStyle.Placement         = Placement.Inside;
        ccls.LabelStyle.TextColor         = Color.Black;
        ccls.LabelStyle.Font              = fntDefault;

        ccls.MajorTickMark.BorderColor       = ColorTranslator.FromHtml("#E0E8F3");
        ccls.MajorTickMark.BorderWidth       = 0;
        ccls.MajorTickMark.DistanceFromScale = 1f;
        ccls.MajorTickMark.FillColor         = ColorTranslator.FromHtml("#E0E8F3");
        ccls.MajorTickMark.Length            = ccls.Width;
        ccls.MajorTickMark.Placement         = Placement.Cross;
        ccls.MajorTickMark.Shape             = Dundas.Gauges.WebControl.MarkerStyle.None;
        ccls.MajorTickMark.Width             = 5f;
        ccls.MajorTickMark.EnableGradient    = false;

        ccls.MinorTickMark.Visible           = false;
        ccls.MinorTickMark.BorderColor       = ccls.MajorTickMark.BorderColor;
        ccls.MinorTickMark.BorderWidth       = 1;
        ccls.MinorTickMark.DistanceFromScale = 1f;
        ccls.MinorTickMark.FillColor         = ccls.MajorTickMark.FillColor;
        ccls.MinorTickMark.Length            = 7f;
        ccls.MinorTickMark.Placement         = Placement.Outside;
        ccls.MinorTickMark.Shape             = Dundas.Gauges.WebControl.MarkerStyle.Wedge;
        ccls.MinorTickMark.Width             = 2f;
        ccls.MinorTickMark.EnableGradient    = false;

        // 게이지 바늘 설정
        cclg.Pointers.Clear();
        cclg.Pointers.Add("Default");
        CircularPointer cclp = cclg.Pointers[0];
        cclp.BorderWidth          = 0;
        cclp.FillGradientEndColor = Color.MediumTurquoise;
        cclp.DistanceFromScale    = 1f;
        cclp.FillColor            = Color.Red;
        cclp.FillGradientEndColor = Color.Pink;
        cclp.FillGradientType     = Dundas.Gauges.WebControl.GradientType.LeftRight;
        cclp.NeedleStyle          = NeedleStyle.NeedleStyle4;
        cclp.Placement            = Placement.Cross;
        cclp.Width                = 2f;
        cclp.ShadowOffset         = 3f;
        cclp.CapFillColor         = ColorTranslator.FromHtml("#DFE8ED");
        cclp.CapFillGradientEndColor = ColorTranslator.FromHtml("#508EBF");
        cclp.CapFillGradientType  = Dundas.Gauges.WebControl.GradientType.DiagonalLeft;
        cclp.CapReflection        = true;
        cclp.CapWidth             = 50f;

        double dMax = iRate;
        if (100 < iRate)
        {
            dMax = (iRate - (iRate % 20)) + 20;
            //dMax = Math.Round(iRate,0);
        }
        else
        {
            dMax = 100;
        }

        cclp.Value    = iRate;
        ccls.Maximum  = dMax;
        ccls.Minimum  = 0;
        ccls.Interval = Math.Round(dMax / 10);

        gglt.Text = Math.Round(iRate,0).ToString() + "%";
    }
    #endregion

    #region [지표현황 - 조회]
    public void SetKpiStatus()
    {
        lblYmd.Text = "주요지표현황 ( " + PageUtility.GetByTextDropDownList(ddlMonthInfo) + " 월 현재 )";

        Biz_Bsc_Kpi_Dashboard objKpi = new Biz_Bsc_Kpi_Dashboard();
        DataSet rDs = objKpi.GetDashBoardKpiList(this.IEstTermRefID);
        DataSet actDs = new DataSet();

        string sKpiNm   = "";
        string sUnitNm  = "";
        decimal dTarget = 0;
        decimal dResult = 0;
        double dAVRate  = 0;
        string sColT = (this.ISumType == "MS") ? "TARGET_MS" : "TARGET_TS";
        string sColR = (this.ISumType == "MS") ? "RESULT_MS" : "RESULT_TS";
        string sColA = (this.ISumType == "MS") ? "ACHV_RATE_MS" : "ACHV_RATE_TS";

        if (rDs.Tables.Count > 0)
        {
            iRow = rDs.Tables[0].Rows.Count;
            for (int i = 0; i < iPageSize; i++)
            {
                if (i < iRow)
                {
                    this.IKpiRefID = int.Parse(rDs.Tables[0].Rows[i]["KPI_REF_ID"].ToString());
                    sKpiNm  = rDs.Tables[0].Rows[i]["KPI_NAME"].ToString();
                    sUnitNm = rDs.Tables[0].Rows[i]["UNIT_NAME"].ToString();
                    actDs = objKpi.GetDashBoardForKpiAnalysis(this.IEstTermRefID, this.IKpiRefID, this.IYmd, this.IYmd, this.ISumType);

                    if (actDs.Tables.Count > 0)
                    {
                        if (actDs.Tables[0].Rows.Count > 0)
                        {
                            dTarget = decimal.Parse(actDs.Tables[0].Rows[0][sColT].ToString());
                            dResult = decimal.Parse(actDs.Tables[0].Rows[0][sColR].ToString());
                            dAVRate = double.Parse(actDs.Tables[0].Rows[0][sColA].ToString());
                        }
                    }
                }
                else
                {
                    sKpiNm  = "-";
                    sUnitNm = "-";
                    dTarget = 0;
                    dResult = 0;
                    dAVRate = 0;
                }

                switch (i)
                { 
                    case 0:
                        lblKpiName1.Text = sKpiNm;
                        txtTarget1.Value = dTarget;
                        txtResult1.Value = dResult;
                        lblTargetUNm1.Text = sUnitNm;
                        lblResultUNm1.Text = sUnitNm;
                        this.SetGuageLayout2(GaugeKPI1, GAUGE_COLOR_TYPE.TYPE1, dAVRate);
                        break;
                    case 1:
                        lblKpiName2.Text = sKpiNm;
                        txtTarget2.Value = dTarget;
                        txtResult2.Value = dResult;
                        lblTargetUNm2.Text = sUnitNm;
                        lblResultUNm2.Text = sUnitNm;
                        this.SetGuageLayout2(GaugeKPI2, GAUGE_COLOR_TYPE.TYPE2, dAVRate);
                        break;
                    case 2:
                        lblKpiName3.Text = sKpiNm;
                        txtTarget3.Value = dTarget;
                        txtResult3.Value = dResult;
                        lblTargetUNm3.Text = sUnitNm;
                        lblResultUNm3.Text = sUnitNm;
                        this.SetGuageLayout2(GaugeKPI3, GAUGE_COLOR_TYPE.TYPE3, dAVRate);
                        break;
                    case 3:
                        lblKpiName4.Text = sKpiNm;
                        txtTarget4.Value = dTarget;
                        txtResult4.Value = dResult;
                        lblTargetUNm4.Text = sUnitNm;
                        lblResultUNm4.Text = sUnitNm;
                        this.SetGuageLayout2(GaugeKPI4, GAUGE_COLOR_TYPE.TYPE2, dAVRate);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    #endregion

    #endregion

    #region =============== [ 이벤트 ] ================
    void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetAllGraph();
    }

    void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }

    #endregion
}
