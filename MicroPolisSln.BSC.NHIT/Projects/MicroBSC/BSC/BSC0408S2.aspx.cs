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

using System.Data.OracleClient;


using Infragistics.WebUI.UltraWebGrid;
using Dundas.Gauges.WebControl;
//using Dundas.Charting.WebControl;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC0408S2 : AppPageBase
{

    Biz_EstDeptOrgScoreInfos estDeptOrgScore_e = null;
    Biz_EstDeptOrgScoreInfos estDeptOrgScore_g = null;
    Biz_EstDeptOrgScoreInfos estDeptOrgScore_w = null;
    Biz_EstDeptOrgScoreInfos estDeptOrgScore_a = null;
    Biz_EstDeptOrgScoreInfos estDeptOrgScore_u = null;
    public double dTotalPoint = 0;


    #region --> Property

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
    #endregion

    #region --> Page_Load()
    protected void Page_Load(object sender, EventArgs e)
    {
        //좌측메뉴설정
        base.SetMenuControl(true, true, true);

        if (!IsPostBack)
            this.NotPostBackSetting();
        else
            this.PostBackSetting();        
    }
    #endregion

    #region --> Event
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

    protected void dstKpiStatus_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }
    

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.Search();
    }
    protected void ugrdResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        string strTrend = e.Row.Cells.FromKey("TREND").Value.ToString();

        e.Row.Cells.FromKey("ACHIEVE_RATE").Value = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("ACHIEVE_RATE").Value) * 100 / 100.00;
        switch (strTrend)
        {
            case "UP":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_e_up.gif'>"; ;
                break;
            case "DOWN":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_b_down.gif'>"; ;
                break;
            case "FLAT":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_m.gif'>"; ;
                break;
            default:
                break;
        }

        e.Row.Cells.FromKey("SIGNAL_IMAGE").Value = "<div align=center><img src='../images/" + e.Row.Cells.FromKey("SIGNAL_IMAGE").Value.ToString() + "'></div>";

        if (drw["SORT_TYPE"].ToString() == "H")
        {
            e.Row.Cells.FromKey("RANK").Style.BackColor = System.Drawing.Color.FromName("#CEE2F4");
        }
        else if (drw["SORT_TYPE"].ToString() == "L")
        {
            e.Row.Cells.FromKey("RANK").Style.BackColor = System.Drawing.Color.FromName("#FFE0E0");
        }
    }

    protected void ugrdResultStatus_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.GroupByBox.Hidden = true;
        e.Layout.GroupByColumnsHiddenDefault = GroupByColumnsHidden.Yes;
    }
  
    #endregion

    #region --> Function
   
    private void Search()
    {
        this.SetParameter();

        this.SetGauge();

        this.SetResultGrid();

        this.SetKpiStatusGraph();

        this.SetKpiStatusGraph2();

        this.SetResulSetKpiStatusGraph3();

    }

    private void NotPostBackSetting()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        WebCommon.SetSumTypeDropDownList(ddlSumType, false);

        if (IEstTermRefID > 0)
        {
            PageUtility.FindByValueDropDownList(ddlEstTermInfo, IEstTermRefID);
        }

        if (IYmd.Trim().Length > 0)
        {
            PageUtility.FindByValueDropDownList(ddlMonthInfo, IYmd);
        }

        if (ISumType.Trim().Length > 0)
        {
            PageUtility.FindByValueDropDownList(ddlSumType, ISumType);
        }


        //lblToatal.Style.Add(HtmlTextWriterStyle.FontFamily, "휴먼엑스포");
        lblToatal.Style.Add(HtmlTextWriterStyle.VerticalAlign, "middle");
        lblToatal.Style.Add(HtmlTextWriterStyle.FontSize, "35pt");
        lblToatal.Style.Add(HtmlTextWriterStyle.Color, "navy");

        this.Search();
    }

    private void PostBackSetting()
    {
        chtKPI1.Visible = false;
        chtKPI2.Visible = false;
        chtKPI3.Visible = false;
        chtKPI4.Visible = false;
        chtKPI5.Visible = false;
        chtKPI6.Visible = false;
    }
   
    private void SetParameter()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.ISumType = PageUtility.GetByValueDropDownList(ddlSumType);

        DeptInfos objDept = new DeptInfos();
        this.IEstDeptID = objDept.GetRootEstDeptID(this.IEstTermRefID);

    }

    private void SetGauge()
    {
        //================================================================== 전체
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();


        DataSet dsTot = objBSC.GetEstDeptTotalScore
                                                (this.IEstTermRefID
                                                , this.IYmd
                                                , this.ISumType
                                                , this.IEstDeptID);
        double dblMax = 0.00;

        if (dsTot.Tables[0].Rows.Count > 0)
        {

            dblMax = Math.Round(double.Parse(dsTot.Tables[0].Rows[0][3].ToString()), 0);
            this.gauTotal2.NumericIndicators["Default"].Value = (dsTot.Tables[0].Rows.Count > 0) ? double.Parse(dsTot.Tables[0].Rows[0]["POINT"].ToString()) : 0;
            this.gauTotal2.NumericIndicators["Default"].Href = "./BSC0404S1.ASPX";
            this.gauTotal2.NumericIndicators["Default"].BorderWidth = 0;
            this.gauTotal2.Labels["Default"].Href = "./BSC0404S1.ASPX";

            lblToatal.Text = Convert.ToString(Math.Round(this.gauTotal2.NumericIndicators["Default"].Value,2));

            this.SetStateIndicator(this.gauTotal2.StateIndicators);

            foreach (Dundas.Gauges.WebControl.StateIndicator stateIndicator in this.gauTotal2.StateIndicators)
            {
                stateIndicator.Value = (dsTot.Tables[0].Rows.Count > 0) ? double.Parse(dsTot.Tables[0].Rows[0]["POINT"].ToString()) : 0;
                stateIndicator.Location.Y = 0;
                stateIndicator.Location.X = 30;
                stateIndicator.Size.Height = 9;
                stateIndicator.Size.Width = 7;
            }

        }


        //================================================================== 관점별 달성율

        DataSet dsViw = objBSC.GetEstDeptKpiViewTypeList
                                                 (this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID);

        Dundas.Gauges.WebControl.GaugeContainer objGauge = null;

        if (dsViw.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < dsViw.Tables[0].Rows.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        objGauge = gauKPI1;
                        break;
                    case 1:
                        objGauge = gauKPI2;
                        break;
                    case 2:
                        objGauge = gauKPI3;
                        break;
                    case 3:
                        objGauge = gauKPI4;
                        break;


                    default:
                        return;
                }


                dblMax = Math.Round(double.Parse(dsViw.Tables[0].Rows[i]["ACHV_RATE"].ToString()), 0);
                objGauge.CircularGauges["Default"].Scales[0].Minimum = 0;
                objGauge.CircularGauges["Default"].Scales[0].Maximum = (dblMax >= 100) ? dblMax : 100;
                objGauge.CircularGauges["Default"].Scales[0].StartAngle = 89;
                objGauge.CircularGauges["Default"].Scales[0].SweepAngle = 95;
                //objGauge.CircularGauges["Default"].Scales[0].Width = 10;
                //objGauge.CircularGauges["Default"].Scales[0].ShadowOffset = 0;
                objGauge.CircularGauges["Default"].Scales[0].Radius = 57;
                //objGauge.CircularGauges["Default"].Scales[0].FillColor = System.Drawing.Color.White;

                // Jpeg based streaming
                objGauge.ImageType = Dundas.Gauges.WebControl.ImageType.Jpeg;
                objGauge.RenderAsControl = Dundas.Gauges.WebControl.AutoBool.False;



             

                objGauge.CircularGauges["Default"].Pointers["Default"].Value = (dsViw.Tables[0].Rows.Count > 0) ? double.Parse(dsViw.Tables[0].Rows[i]["ACHV_RATE"].ToString()) : 0;

                objGauge.Labels[0].Text = dsViw.Tables[0].Rows[i]["VIEW_NAME"].ToString();
                objGauge.Labels[0].Href = "./BSC0404S1.ASPX";
                objGauge.Labels[0].BorderWidth = 0;

                this.SetStateIndicator(objGauge.StateIndicators);

                foreach (Dundas.Gauges.WebControl.StateIndicator stateIndicator in this.gauTotal2.StateIndicators)
                {
                    stateIndicator.Value = (dsViw.Tables[0].Rows.Count > 0) ? double.Parse(dsViw.Tables[0].Rows[i]["ACHV_RATE"].ToString()) : 0;
                }

            }

        }

    }

    private void SetResultGrid()
    {

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();




        DataSet ds = objBSC.GetKpiListForResultAnalysis(this.IEstTermRefID
                                                                       , this.IYmd
                                                                       , ""
                                                                       , ""
                                                                       , ""
                                                                       , ""
                                                                       , this.IDeptID
                                                                       , 1 // 우수
                                                                       , this.ISumType
                                                                       , ""
                                                                       , "");

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Add("RANK", typeof(int));
            ds.Tables[0].Columns.Add("SORT_TYPE", typeof(string));

            DataTable dataTable = null;

            // 순위정렬 성격에 따라 처리 내용
            dataTable = PageUtility.FilterSortData(ds.Tables[0], "", "ACHIEVE_RATE_DIFF DESC");
            SetRowNum(dataTable, "H");

            // DataRow 삭제
            DeleteExtraRowsByRowNum(dataTable, 10);

            ugrdResultStatus.Clear();
            ugrdResultStatus.DataSource = dataTable;
            ugrdResultStatus.DataBind();
        }

    }

    private void SetKpiStatusGraph()
    {
        this.SetParameter();

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);

        int cntRow = 0;
        int cntCol = 0;
       

        int intEsttermRefID = 0;
        int intKpiRefID = 0;
        string strTrendType = "";
        string strKpiName = "";
        string strTypeName = "";

        cntRow = rDs.Tables[0].Rows.Count;
        cntCol = rDs.Tables[0].Columns.Count;
        Chart objChart = null;

        for (int i = 0; i < cntRow; i++)
        {
            intEsttermRefID = Convert.ToInt32(rDs.Tables[0].Rows[i]["ESTTERM_REF_ID"].ToString());
            intKpiRefID = Convert.ToInt32(rDs.Tables[0].Rows[i]["KPI_REF_ID"].ToString());
            strTrendType = Convert.ToString(rDs.Tables[0].Rows[i]["SELECT_TYPE"].ToString());
            strKpiName = Convert.ToString(rDs.Tables[0].Rows[i]["KPI_NAME"].ToString());
            strTypeName = Convert.ToString(rDs.Tables[0].Rows[i]["SELECT_TYPE_NAME"].ToString());

            DataSet dsGraph = objBSC.GetDashBoardForKpiAnalysis(intEsttermRefID, intKpiRefID, "00000000", this.IYmd, this.ISumType);
            //DataSet dsGraph = objBSC.GetDashBoardForKpiAnalysis(intEsttermRefID, intKpiRefID, this.IYmd, "99999999", this.ISumType);

            

            switch (i)
            {
                case 0:
                    objChart = chtKPI1;
                    objChart.Visible = true;
                    break;
                case 1:
                    objChart = chtKPI2;
                    objChart.Visible = true;
                    break;
                case 2:
                    objChart = chtKPI3;
                    objChart.Visible = true;
                    break;
                case 3:
                    objChart = chtKPI4;
                    objChart.Visible = true;
                    break;
                case 4:
                    objChart = chtKPI5;
                    objChart.Visible = true;
                    break;
                case 5:
                    objChart = chtKPI6;
                    objChart.Visible = true;
                    break;

                default:
                    return;
            }
                
            MSCharts.DundasChartBase(objChart, ChartImageType.Jpeg, 300, 100
                , BorderSkinStyle.Emboss, Color.FromArgb(26, 59, 105), 2
                , Color.FromArgb(211, 223, 240)
                , Color.FromArgb(255, 255, 255), Color.FromArgb(37, 58, 118), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

            Series serKpi = MSCharts.CreateSeries
                             (objChart, strTypeName, objChart.ChartAreas[0].Name,
                              strTypeName, null, WebCommon.GetMSChartType(rDs.Tables[0].Rows[i]["GRAPH_TYPE"].ToString()), 2,
                              GetSignalColor(i), GetChartColor(i),
                              Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            objChart.ChartAreas[objChart.Series[serKpi.Name].ChartArea].AxisX.Interval = 4;


            objChart.ChartAreas[objChart.Series[serKpi.Name].ChartArea].Area3DStyle.Enable3D = false;
            objChart.ChartAreas[objChart.Series[serKpi.Name].ChartArea].AxisY2.Enabled = AxisEnabled.False;
            objChart.ChartAreas[objChart.Series[serKpi.Name].ChartArea].AxisY.LabelStyle.Format = "#,##0";

            //string strHerf = HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().LastIndexOf('/')) + "/BSC0304S2.aspx?ESTTERM_REF_ID=" + intEsttermRefID.ToString() + "&KPI_REF_ID=" + intKpiRefID.ToString() + "&YMD=" + this.IYmd;
            string strHerf = HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().LastIndexOf('/')) + "/BSC0304S2.aspx?ITYPE=POP&ESTTERM_REF_ID=" + intEsttermRefID.ToString() + "&KPI_REF_ID=" + intKpiRefID.ToString() + "&YMD=" + this.IYmd;
            string strURL = "javascript:gfOpenWindow('"+strHerf+"',840,600,'no','no');";
           



            objChart.DataSource = dsGraph;
            serKpi.YValueMembers = "RESULT_VALUE";
            serKpi.XValueMember = "YMD";
            objChart.DataBind();
            objChart.Legends[0].Enabled = false;

            objChart.Titles[0].Text = strKpiName;
            objChart.Titles[0].Url = strURL;
            
            

            dsGraph = null;
            serKpi = null;
            objChart = null;
        }
    }

    private void SetKpiStatusGraph2()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();

        DataSet dsGraph = new DataSet();
        List<string> listYMDs = new List<string>();
        Chart objChart = this.chtPart;

        //dsGraph = TempData3();

        //관점별 1년치데이타
        foreach (string str in GetBeforeMonth(listYMDs))
        {
            dsGraph.Merge(objBSC.GetEstDeptKpiViewTypeList
                                                 (this.IEstTermRefID
                                                 , str
                                                 , this.ISumType
                                                 , this.IEstDeptID));

        }

        dsGraph.AcceptChanges();
        dsGraph = this.ModifyData(dsGraph);

        if (dsGraph.Tables[0].Rows.Count > 0)
        {


            MSCharts.DundasChartBase(objChart, ChartImageType.Jpeg, 680, 130
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

            objChart.DataSource = dsGraph;
            objChart.Series.Clear();

            MicroBSC.BSC.Biz.Biz_Bsc_View_Info objViewInfo = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
            DataSet rDs = objViewInfo.GetAllList();

            if (rDs.Tables != null && rDs.Tables[0].Rows.Count == 4)
            {
                Series series4 = MSCharts.CreateSeries(objChart, "sp1", "AreaView", rDs.Tables[0].Rows[0]["VIEW_NAME"].ToString(), null, SeriesChartType.Area, 1, Color.FromArgb(240, 224, 64, 10), Color.FromArgb(180, 26, 59, 105), Color.Transparent, 1, 9, Color.FromArgb(64, 64, 64));
                Series series1 = MSCharts.CreateSeries(objChart, "sp2", "AreaView", rDs.Tables[0].Rows[1]["VIEW_NAME"].ToString(), null, SeriesChartType.Area, 1, Color.FromArgb(240, 192, 192, 192), Color.FromArgb(180, 26, 59, 105), Color.Transparent, 1, 9, Color.FromArgb(64, 64, 64));
                Series series3 = MSCharts.CreateSeries(objChart, "sp3", "AreaView", rDs.Tables[0].Rows[2]["VIEW_NAME"].ToString(), null, SeriesChartType.Area, 1, Color.FromArgb(240, 65, 140, 240), Color.FromArgb(180, 26, 59, 105), Color.Transparent, 1, 9, Color.FromArgb(64, 64, 64));

                Series series2 = MSCharts.CreateSeries(objChart, "sp4", "AreaView", rDs.Tables[0].Rows[3]["VIEW_NAME"].ToString(), null, SeriesChartType.Area, 1, Color.FromArgb(240, 252, 180, 65), Color.FromArgb(180, 26, 59, 105), Color.Transparent, 1, 9, Color.FromArgb(64, 64, 64));

                series1.YValueMembers = "ACHV_RATE1";
                series2.YValueMembers = "ACHV_RATE2";
                series3.YValueMembers = "ACHV_RATE3";
                series4.YValueMembers = "ACHV_RATE4";
                series1.XValueMember = "YMD";

                foreach (Series series in objChart.Series)
                {
                    //objChart.ChartAreas[objChart.Series[series.Name].ChartArea].AxisX.Margin = false;
                    objChart.ChartAreas[objChart.Series[series.Name].ChartArea].AxisY2.Enabled = AxisEnabled.False;
                    objChart.ChartAreas[objChart.Series[series.Name].ChartArea].AxisY.Interval = 30;
                    series.Url = HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().LastIndexOf('/')) + "/BSC0404S1.ASPX";
                }

                objChart.DataBind();

            }
        }

    }

    private void SetResulSetKpiStatusGraph3()
    {

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();

        DataSet ds = objBSC.GetKpiListForResultAnalysis(this.IEstTermRefID
                                                                       , this.IYmd
                                                                       , ""
                                                                       , ""
                                                                       , ""
                                                                       , ""
                                                                       , 0
                                                                       , 0
                                                                       , this.ISumType
                                                                       ,""
                                                                       ,"");

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            DataTable dataTable = ds.Tables[0];



            DataRow[] rank1 = dataTable.Select("ACHIEVE_RATE > '120.00'");
            DataRow[] rank2 = dataTable.Select("ACHIEVE_RATE > '100.00' AND ACHIEVE_RATE <= '120.00' ");
            DataRow[] rank3 = dataTable.Select("ACHIEVE_RATE > '80'  AND ACHIEVE_RATE <= '100' ");
            DataRow[] rank4 = dataTable.Select("ACHIEVE_RATE > '60'  AND ACHIEVE_RATE <= '80' ");
            DataRow[] rank5 = dataTable.Select("ACHIEVE_RATE > '40'  AND ACHIEVE_RATE < '60' ");
            DataRow[] rank6 = dataTable.Select("ACHIEVE_RATE >= '0.00'  AND ACHIEVE_RATE < '40' ");



            double[] yValues1 = new double[] { rank1.Length, rank2.Length, rank3.Length, rank4.Length, rank5.Length, rank6.Length };

            double[] yValues2 = new double[] { 10, 10, 10, 10, 10, 10 };

            string[] xValues1 = new string[] { "120%초과,200.00-120.01", "100~ 120%이하,120.00-100.01", "80~100%이하,100.00-80.01", "60~80%이하,80.00-60.01", "40~60%이하,60.00-40.01", "40%미만,40.00-0.00" };

            Color[] bColor = new Color[] { Color.FromArgb(220, 224, 64, 10), Color.FromArgb(220, 225, 140, 240), Color.FromArgb(220, 252, 180, 65), Color.FromArgb(220, 224, 64, 10), Color.FromArgb(220, 224, 64, 10), Color.FromArgb(220, 192, 192, 192) };

            //double[] maxValue = new double[] { 200, 120, 100, 80, 60, 40 };
            //double[] minValue = new double[] { 121, 101, 81, 61, 41, 0 };

            Array.Sort(yValues1, xValues1);
            Array.Reverse(xValues1);
            Array.Reverse(yValues1);


            chtFunnel.Series["Default"].Points.Clear();


            for (int i = 0; i < yValues1.Length; i++)
            {
                chtFunnel.Series["Default"].Points.AddXY(xValues1[i], yValues2[i]);
                chtFunnel.Series["Default"].Points[i].Label = xValues1[i].ToString().Split(',').GetValue(0).ToString() + "\n" + yValues1[i].ToString();

                // chtFunnel.Series["Default"].Points[i].Color = bColor[i];

                string strUrl = HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().LastIndexOf('/')) + "/BSC0304S1.aspx?PAGE_TYPE=D&MAX_VALUE=" + xValues1[i].ToString().Split(',').GetValue(1).ToString().Split('-').GetValue(0).ToString() + "&MIN_VALUE=" + xValues1[i].ToString().Split(',').GetValue(1).ToString().Split('-').GetValue(1).ToString();

                chtFunnel.Series["Default"].Points[i].Url = strUrl;
                chtFunnel.Series["Default"].Points[i].LabelUrl = strUrl;

            }

            chtFunnel.Series["Default"]["FunnelLabelStyle"]                 = "Outside";
            chtFunnel.ChartAreas["Default"].Area3DStyle.Enable3D            = true;
            chtFunnel.Series["Default"]["FunnelStyle"]                      = "YIsHeight";
            chtFunnel.Series["Default"]["FunnelOutsideLabelPlacement"]      = "Left";
            chtFunnel.Series["Default"]["FunnelPointGap"]                   = "2";
            chtFunnel.Series["Default"]["Funnel3DDrawingStyle"]             = "CircularBase";
            chtFunnel.Series["Default"]["Funnel3DRotationAngle"]            = "10";
            //chtFunnel.Titles[0].Text = "달성율 분포";
        }
    }

    private void DeleteExtraRowsByRowNum(DataTable dataTable, int deleteRowNum)
    {
        if (dataTable.Rows.Count < deleteRowNum)
            return;

        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            if (i >= deleteRowNum)
                dataTable.Rows[i].Delete();
        }

        dataTable.AcceptChanges();
    }

    private void SetRowNum(DataTable dataTable, string sort_type)
    {
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            dataTable.Rows[i]["RANK"] = i + 1;
            dataTable.Rows[i]["SORT_TYPE"] = sort_type;
        }

        dataTable.AcceptChanges();
    }


    private void SetStateIndicator(Dundas.Gauges.WebControl.StateIndicatorCollection stateIndicators)
    {
        foreach (Dundas.Gauges.WebControl.StateIndicator stateIndicator in stateIndicators)
        {
            // Set style of the state indicator
            stateIndicator.Style = Dundas.Gauges.WebControl.StateIndicatorStyle.RectangularLed;

            stateIndicator.Size.Height = 9;
            stateIndicator.Size.Width = 9;
            stateIndicator.Location.X = 20;
            stateIndicator.Location.Y = 0;
            stateIndicator.BorderWidth = 0;



            // Add state object to the state indicator 
            Dundas.Gauges.WebControl.State state = new Dundas.Gauges.WebControl.State();
            state.Name = "Limit";
            stateIndicator.States.Add(state);

            // Set value range of the state when it is activated
            state.StartValue = 0;
            state.EndValue = 50;

            // Set fill attributes
            state.FillColor = Color.Red;
            state.FillGradientEndColor = Color.Red;
            state.FillGradientType = Dundas.Gauges.WebControl.GradientType.Center;
            state.Image = "~/images/icon_a.gif";

            // Set border attributes
            //state.BorderColor = Color.Gray;
            state.BorderWidth = 0;


            // Add state object to the state indicator 
            Dundas.Gauges.WebControl.State state2 = new Dundas.Gauges.WebControl.State();
            state2.Name = "Limit2";
            stateIndicator.States.Add(state2);

            // Set value range of the state when it is activated
            state2.StartValue = 60;
            state2.EndValue = 100;

            // Set fill attributes
            state2.FillColor = Color.FromArgb(30, 180, 252);
            state2.FillGradientEndColor = Color.FromArgb(9, 113, 204);
            state2.FillGradientType = Dundas.Gauges.WebControl.GradientType.DiagonalLeft;
            state2.Image = "~/images/icon_e.gif";
            state2.BorderWidth = 0;
        }

    }

    private List<string> GetBeforeMonth(List<string> list)
    {
        //현재월에서 1년전의 YMD를 구한다.
        DateTime startYM = (DateTime.ParseExact(this.IYmd, "yyyyMM", null)).AddYears(-1);

        list.Clear();

        for (int i = 1; i <= 12; i++)
        {
            list.Add(startYM.AddMonths(i).ToString("yyyyMM"));
        }

        return list;

    }

    private DataSet ModifyData(DataSet ds)
    {
        DataSet tmpds = new DataSet();

        DataRow[] row1001 = ds.Tables[0].Select("VIEW_REF_ID = 1001");
        DataRow[] row1002 = ds.Tables[0].Select("VIEW_REF_ID = 1002");
        DataRow[] row1003 = ds.Tables[0].Select("VIEW_REF_ID = 1003");
        DataRow[] row1004 = ds.Tables[0].Select("VIEW_REF_ID = 1004");

        tmpds.Tables.Add(new DataTable("SELECT_VIEW_WEIGHT"));
        tmpds.Tables[0].Columns.Add("YMD", typeof(string));
        tmpds.Tables[0].Columns.Add("ACHV_RATE1", typeof(int));
        tmpds.Tables[0].Columns.Add("ACHV_RATE2", typeof(int));
        tmpds.Tables[0].Columns.Add("ACHV_RATE3", typeof(int));
        tmpds.Tables[0].Columns.Add("ACHV_RATE4", typeof(int));


        //for (int i = 0; i < row1001.Length; i++)
        //{
        //    tmpds.Tables[0].Rows.Add(new object[] { row1001[i]["YMD"]
        //                                              , row1001[i]["ACHV_RATE"]
        //                                              , row1002[i]["ACHV_RATE"]
        //                                              , row1003[i]["ACHV_RATE"]
        //                                              , row1004[i]["ACHV_RATE"]
        //                                 });
        //}

        for (int i = 0; i < row1001.Length; i++)
        {
            tmpds.Tables[0].Rows.Add(new object[] { row1001[i]["YMD"]
                                                      , row1001[i]["ACHV_RATE"]
                                                      , 0
                                                      , 0
                                                      , 0
                                         });
        }

        for (int i = 0; i < row1002.Length; i++)
        {
            tmpds.Tables[0].Rows[i]["ACHV_RATE2"] = row1002[i]["ACHV_RATE"];
        }

        for (int i = 0; i < row1003.Length; i++)
        {
            tmpds.Tables[0].Rows[i]["ACHV_RATE3"] = row1003[i]["ACHV_RATE"];
        }

        for (int i = 0; i < row1004.Length; i++)
        {
            tmpds.Tables[0].Rows[i]["ACHV_RATE4"] = row1004[i]["ACHV_RATE"];
        }

        tmpds.AcceptChanges();


        //if (row1001.Length == row1002.Length
        //    && row1002.Length == row1003.Length
        //    && row1003.Length == row1004.Length
        //    && row1004.Length == row1001.Length)
        //{
        //}
        return tmpds;
    }


    public string GetTotalNumer()
    {
        string strImg = "";
        estDeptOrgScore_e = new Biz_EstDeptOrgScoreInfos("E");
        estDeptOrgScore_g = new Biz_EstDeptOrgScoreInfos("G");
        estDeptOrgScore_w = new Biz_EstDeptOrgScoreInfos("W");
        estDeptOrgScore_a = new Biz_EstDeptOrgScoreInfos("A");
        estDeptOrgScore_u = new Biz_EstDeptOrgScoreInfos("U");

        if ((estDeptOrgScore_u.Min_Value <= dTotalPoint) && (estDeptOrgScore_u.Max_Value > dTotalPoint))
        {
            strImg = "<img alt='Unmeasured' src='../images/icon_u.gif' style='vertical-align:middle;' border='0' />";
        }
        else if ((estDeptOrgScore_a.Min_Value <= dTotalPoint) && (estDeptOrgScore_a.Max_Value > dTotalPoint))
        {
            strImg = "<img alt='Alert' src='../images/icon_a.gif' style='vertical-align:middle;' border='0' />";
        }
        else if ((estDeptOrgScore_w.Min_Value <= dTotalPoint) && (estDeptOrgScore_w.Max_Value > dTotalPoint))
        {
            strImg = "<img alt='Watching' src='../images/icon_w.gif' style='vertical-align:middle;' border='0'  />";
        }
        else if ((estDeptOrgScore_g.Min_Value <= dTotalPoint) && (estDeptOrgScore_g.Max_Value > dTotalPoint))
        {
            strImg = "<img alt='Good' src='../images/icon_g.gif' style='vertical-align:middle;'  border='0' />";
        }
        else if ((estDeptOrgScore_e.Min_Value <= dTotalPoint) && (estDeptOrgScore_e.Max_Value >= dTotalPoint))
        {
            strImg = "<img alt='Excellent' src='../images/icon_e.gif' style='vertical-align:middle;'  border='0' />";
        }

        return strImg;
    }

    public string GetNumber(double point)
    {
        string strCount = "";

        for (int i = 0; i < point.ToString().Length; i++)
        {
            if (point.ToString()[i] == '.')
                strCount += "<img src='../images/num/no_dot.gif'/>";
            else
                strCount += "<img src='../images/num/no_0" + point.ToString()[i].ToString() + ".gif'/>";
        }
        //return "<img src='../images/num/blue_num01.gif'/><img src='../images/num/blue_num02.gif'/><img src='../images/num/blue_num00.gif'/><img src='../images/proc_i08.gif'/><img src='../images/num/blue_num09.gif'/>";

        return strCount;
    }

    /*
    private DataSet TempData2()
    {
        DataSet ds = new DataSet();

        ds.Tables.Add(new DataTable("SELECT_VIEW_WEIGHT"));

       
        ds.Tables[0].Columns.Add("YMD", typeof(string));
        ds.Tables[0].Columns.Add("ACHV_RATE1", typeof(int));
        ds.Tables[0].Columns.Add("ACHV_RATE2", typeof(int));
        ds.Tables[0].Columns.Add("ACHV_RATE3", typeof(int));
        ds.Tables[0].Columns.Add("ACHV_RATE4", typeof(int));


        ds.Tables[0].Rows.Add(new object[] { "200701", 30, 50, 35, 20 });
        ds.Tables[0].Rows.Add(new object[] { "200702", 55, 72, 44, 28 });
        ds.Tables[0].Rows.Add(new object[] { "200703", 43, 55, 82, 66 });
        ds.Tables[0].Rows.Add(new object[] { "200704", 12, 70, 99, 27 });
        ds.Tables[0].Rows.Add(new object[] { "200705", 22, 37, 52, 83 });
        ds.Tables[0].Rows.Add(new object[] { "200706", 90, 77, 82, 42 });
        ds.Tables[0].Rows.Add(new object[] { "200707", 20, 33, 26, 55 });
        ds.Tables[0].Rows.Add(new object[] { "200708", 55, 47, 63, 83 });
        ds.Tables[0].Rows.Add(new object[] { "200709", 44, 29, 36, 74 });
        ds.Tables[0].Rows.Add(new object[] { "200710", 89, 63, 50, 38 });
        ds.Tables[0].Rows.Add(new object[] { "200711", 99, 28, 82, 76 });
        ds.Tables[0].Rows.Add(new object[] { "200712", 31, 27, 43, 33 });

      
        return ds;
    }


    private DataSet TempData3()
    {
        DataSet ds = new DataSet();

        ds.Tables.Add(new DataTable("SELECT_VIEW_WEIGHT"));


        ds.Tables[0].Columns.Add("YMD", typeof(string));
        ds.Tables[0].Columns.Add("VIEW_REF_ID", typeof(int));
        ds.Tables[0].Columns.Add("VIEW_NAME", typeof(string));
        ds.Tables[0].Columns.Add("ACHV_RATE", typeof(int));


        ds.Tables[0].Rows.Add(new object[] { "200701", 1001, "Activity", 35 });
        ds.Tables[0].Rows.Add(new object[] { "200702", 1001, "Activity", 55 });
        ds.Tables[0].Rows.Add(new object[] { "200703", 1001, "Activity", 43 });
        ds.Tables[0].Rows.Add(new object[] { "200704", 1001, "Activity", 70 });
        ds.Tables[0].Rows.Add(new object[] { "200705", 1001, "Activity", 83 });
        ds.Tables[0].Rows.Add(new object[] { "200706", 1001, "Activity", 90 });
        ds.Tables[0].Rows.Add(new object[] { "200707", 1001, "Activity", 20 });
        ds.Tables[0].Rows.Add(new object[] { "200708", 1001, "Activity", 55 });
        ds.Tables[0].Rows.Add(new object[] { "200709", 1001, "Activity", 44 });
        ds.Tables[0].Rows.Add(new object[] { "200710", 1001, "Activity", 89 });
        ds.Tables[0].Rows.Add(new object[] { "200711", 1001, "Activity", 99 });
        ds.Tables[0].Rows.Add(new object[] { "200712", 1001, "Activity", 33 });

        ds.Tables[0].Rows.Add(new object[] { "200701", 1002, "고객만족", 15 });
        ds.Tables[0].Rows.Add(new object[] { "200702", 1002, "고객만족", 25 });
        ds.Tables[0].Rows.Add(new object[] { "200703", 1002, "고객만족", 63 });
        ds.Tables[0].Rows.Add(new object[] { "200704", 1002, "고객만족", 90 });
        ds.Tables[0].Rows.Add(new object[] { "200705", 1002, "고객만족", 23 });
        ds.Tables[0].Rows.Add(new object[] { "200706", 1002, "고객만족", 60 });
        ds.Tables[0].Rows.Add(new object[] { "200707", 1002, "고객만족", 50 });
        ds.Tables[0].Rows.Add(new object[] { "200708", 1002, "고객만족", 25 });
        ds.Tables[0].Rows.Add(new object[] { "200709", 1002, "고객만족", 64 });
        ds.Tables[0].Rows.Add(new object[] { "200710", 1002, "고객만족", 49 });
        ds.Tables[0].Rows.Add(new object[] { "200711", 1002, "고객만족", 49 });
        ds.Tables[0].Rows.Add(new object[] { "200712", 1002, "고객만족", 13 });

        ds.Tables[0].Rows.Add(new object[] { "200701", 1003, "사업성과", 15 });
        ds.Tables[0].Rows.Add(new object[] { "200702", 1003, "사업성과", 35 });
        ds.Tables[0].Rows.Add(new object[] { "200703", 1003, "사업성과", 53 });
        ds.Tables[0].Rows.Add(new object[] { "200704", 1003, "사업성과", 76 });
        ds.Tables[0].Rows.Add(new object[] { "200705", 1003, "사업성과", 88 });
        ds.Tables[0].Rows.Add(new object[] { "200706", 1003, "사업성과", 80 });
        ds.Tables[0].Rows.Add(new object[] { "200707", 1003, "사업성과", 25 });
        ds.Tables[0].Rows.Add(new object[] { "200708", 1003, "사업성과", 45 });
        ds.Tables[0].Rows.Add(new object[] { "200709", 1003, "사업성과", 47 });
        ds.Tables[0].Rows.Add(new object[] { "200710", 1003, "사업성과", 82 });
        ds.Tables[0].Rows.Add(new object[] { "200711", 1003, "사업성과", 79 });
        ds.Tables[0].Rows.Add(new object[] { "200712", 1003, "사업성과", 23 });

        ds.Tables[0].Rows.Add(new object[] { "200701", 1004, "성장동력", 15 });
        ds.Tables[0].Rows.Add(new object[] { "200702", 1004, "성장동력", 15 });
        ds.Tables[0].Rows.Add(new object[] { "200703", 1004, "성장동력", 13 });
        ds.Tables[0].Rows.Add(new object[] { "200704", 1004, "성장동력", 10 });
        ds.Tables[0].Rows.Add(new object[] { "200705", 1004, "성장동력", 13 });
        ds.Tables[0].Rows.Add(new object[] { "200706", 1004, "성장동력", 10 });
        ds.Tables[0].Rows.Add(new object[] { "200707", 1004, "성장동력", 20 });
        ds.Tables[0].Rows.Add(new object[] { "200708", 1004, "성장동력", 15 });
        ds.Tables[0].Rows.Add(new object[] { "200709", 1004, "성장동력", 14 });
        ds.Tables[0].Rows.Add(new object[] { "200710", 1004, "성장동력", 29 });
        ds.Tables[0].Rows.Add(new object[] { "200711", 1004, "성장동력", 29 });
        ds.Tables[0].Rows.Add(new object[] { "200712", 1004, "성장동력", 3 });

        return ds;
    }
    */
    
    #endregion




    
}
