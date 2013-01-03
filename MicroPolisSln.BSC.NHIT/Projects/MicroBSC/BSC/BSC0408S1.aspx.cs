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

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
//using Dundas.Charting.WebControl;
using MicroCharts;
using System.Drawing;
using MicroBSC.Common;
using MicroBSC.Estimation.Dac;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC0408S1 : AppPageBase
{

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

        // 웹 취약성 검사 때문에 처리
        if ( IYmd.Equals("-0")
            || ISumType.Equals("-0"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("악성 요청을 거부합니다.", false);
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            WebCommon.SetSumTypeDropDownList(ddlSumType, false);

            WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            chkApplyExtScore.Visible = false;

            wdtSYM.Value = DateTime.Now.AddYears(-1); //PageUtility.GetByTextDropDownList(ddlMonthInfo).Substring(1, 4) + "-01";
            wdtEYM.Value = DateTime.Now;

            this.SetParameter();
            this.SetGraph();
        }

        if (PageUtility.GetByValueRadioButtonList(rdoGubun) == "AY")
        {
            pnlAY.Visible = true;
            pnlAM.Visible = false;
        }
        else
        {
            pnlAY.Visible = false;
            pnlAM.Visible = true;
        }
        

        if (PageUtility.GetByValueRadioButtonList(rdoGubun) == "AY")
        {
            this.SetYearlyResultGraph();
        }
        else
        {
            this.SetKpiStatusGraph();
        }
    }
    #endregion

    #region --> Event
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        
    }


    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

    protected void dstKpiStatus_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }
    protected void iBtnSe_Click(object sender, EventArgs e)
    {
        //this.SetParameter();
        //this.SetGraph();
        //if (PageUtility.GetByValueRadioButtonList(rdoGubun) == "AY")
        //{
        //    this.SetYearlyResultGraph();
        //}
        //else
        //{
        //    this.SetKpiStatusGraph();
        //}

        this.SetParameter();
        this.SetGraph();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        //this.SetParameter();
        //this.SetGraph();

        //if (PageUtility.GetByValueRadioButtonList(rdoGubun) == "AY")
        //{
        //    this.SetYearlyResultGraph();
        //}
        //else
        //{
        //    this.SetKpiStatusGraph();
        //}        
    }

    protected void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.SetParameter();
        //this.SetGraph();

        //if (PageUtility.GetByValueRadioButtonList(rdoGubun) == "AY")
        //{
        //    this.SetYearlyResultGraph();
        //}
        //else
        //{
        //    this.SetKpiStatusGraph();
        //}        
    }
    #endregion

    #region --> Function
    private void SetParameter()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.ISumType = "TS";

        DeptInfos objEst = new DeptInfos();
        this.IEstDeptID = objEst.GetRootEstDeptID(this.IEstTermRefID);

        //iBtnOp.Style.Add("background-image", "url(../images/bg/bg_topmenu.gif)");
        //iBtnOp.Style.Add("vertical-align", "top");
        //iBtnOp.Style.Add("cursor", "hand");
        //iBtnOp.Style.Add("border", "0px");
        //iBtnOp.Height = Unit.Pixel(25);

        //iBtnSe.Style.Add("background-image", "url(../images/bg/bg_topmenu.gif)");
        //iBtnSe.Style.Add("vertical-align", "top");
        //iBtnSe.Style.Add("cursor", "hand");
        //iBtnSe.Style.Add("border", "0px");
        //iBtnSe.Height = Unit.Pixel(25);
    }

    private void SetKpiStatusGraph()
    {
        int charWidth = 270;
        int charHeight = 170;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);

        int cntRow = 0;
        int cntCol = 0;
        int intLP = 0;

        int intEsttermRefID = 0;
        int intKpiRefID     = 0;
        string strTrendType = "";
        string strKpiName   = "";
        string strTypeName  = "TARGET";
        string strGraphType = "LINE";
        int intSortOrder = 0;

        DateTime dsYmd = (DateTime)wdtSYM.Value;
        DateTime deYmd = (DateTime)wdtEYM.Value;

        string sYmd = dsYmd.Year.ToString() + dsYmd.Month.ToString().PadLeft(2,'0');
        string eYmd = deYmd.Year.ToString() + deYmd.Month.ToString().PadLeft(2,'0');
        string sSum = PageUtility.GetByValueDropDownList(ddlSumType);

        cntRow = rDs.Tables[0].Rows.Count;
        cntCol = rDs.Tables[0].Columns.Count;
        Chart objChart = null;

        for (int i = 0; i < cntRow; i++)
        {
            intEsttermRefID = Convert.ToInt32(rDs.Tables[0].Rows[i]["ESTTERM_REF_ID"].ToString());
            intKpiRefID     = Convert.ToInt32(rDs.Tables[0].Rows[i]["KPI_REF_ID"].ToString());
            strTrendType    = Convert.ToString(rDs.Tables[0].Rows[i]["SELECT_TYPE"].ToString());
            strKpiName      = Convert.ToString(rDs.Tables[0].Rows[i]["KPI_NAME"].ToString());
            strTypeName     = Convert.ToString(rDs.Tables[0].Rows[i]["SELECT_TYPE_NAME"].ToString());
            strGraphType    = Convert.ToString(rDs.Tables[0].Rows[i]["GRAPH_TYPE"].ToString());
            intSortOrder    = Convert.ToInt32(rDs.Tables[0].Rows[i]["SORT_ORDER"].ToString());

            DataSet dsGraph = objBSC.GetDashBoardForKpiAnalysis(intEsttermRefID, intKpiRefID, sYmd, eYmd, "TS");

            switch (i)
            {
                case 0:
                    objChart = chtKPI1;
                    break;
                case 1:
                    objChart = chtKPI2;
                    break;
                case 2:
                    objChart = chtKPI3;
                    break;
                case 3:
                    objChart = chtKPI4;
                    break;
                case 4:
                    objChart = chtKPI5;
                    break;
                case 5:
                    objChart = chtKPI6;
                    break;
                case 6:
                    objChart = chtKPI7;
                    break;
                case 7:
                    objChart = chtKPI8;
                    break;
                default:
                    return;
            }



            MSCharts.DundasChartBase(objChart, ChartImageType.Jpeg, charWidth, charHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

            Series serT = MSCharts.CreateSeries
                            ( objChart
                            , "T"
                            , objChart.ChartAreas[0].Name
                            , "계획"
                            , "계획"
                            , SeriesChartType.Spline
                            , 3
                            , Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            Series serR = MSCharts.CreateSeries
                            (objChart
                            , "R"
                            , objChart.ChartAreas[0].Name
                            , "실적"
                            , "실적"
                            , SeriesChartType.Spline
                            , 3
                            , Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            Series serA = MSCharts.CreateSeries
                            (objChart
                            , "A"
                            , objChart.ChartAreas[0].Name
                            , "달성율"
                            , "달성율"
                            , SeriesChartType.Spline
                            , 1
                            , Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            int iInterval = (int)(dsGraph.Tables[0].Rows.Count/4);

            objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].AxisX.Interval = iInterval;

            objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].Area3DStyle.Enable3D    = false;
            objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].AxisY2.Enabled          = AxisEnabled.True;
            objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].AxisY.LabelStyle.Format = "#,##0";

            //serA.MarkerStyle = MarkerStyle.Circle;
            //serA.MarkerSize  = 2;
            serA.YAxisType = AxisType.Secondary;
            serT.ToolTip   = "Target \t= #VALY{d}";
            serR.ToolTip   = "Result \t= #VALY{d}";
            serA.ToolTip   = "Rate \t= #VALY{P}";

            objChart.DataSource  = dsGraph;
            serT.YValueMembers   = "TARGET_" + sSum;
            serR.YValueMembers   = "RESULT_" + sSum;
            serA.YValueMembers   = "ACHV_RATE_" + sSum;
            serT.XValueMember    = "YMD";
            objChart.DataBind();
            objChart.Legends[0].Enabled = false;


            objChart.Titles[0].Text = strKpiName;

            dsGraph  = null;
            serT     = null;
            serR     = null;
            serA     = null;
            objChart = null;
        }

        if (cntRow > 1 && cntRow < 3)
        {
            tr01.Visible = true;
            //tr02.Visible = false;
            tr03.Visible = false;
            //tr04.Visible = false;
            return;
        }
        else if (cntRow > 2 && cntRow < 5)
        {
            tr01.Visible = true;
            //tr02.Visible = true;
            tr03.Visible = false;
            //tr04.Visible = false;
            return;
        }
        else if (cntRow > 4 && cntRow < 7)
        {
            tr01.Visible = true;
            //tr02.Visible = true;
            tr03.Visible = true;
            //tr04.Visible = false;
            return;
        }
        else
        {
            tr01.Visible = true;
            //tr02.Visible = true;
            tr03.Visible = true;
            //tr04.Visible = true;
            return;
        }
    }

    private void SetYearlyResultGraph()
    {
        int charWidth = 270;
        int charHeight = 170;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);

        int cntRow = 0;
        int cntCol = 0;
        int cntLop = 0;

        cntRow = rDs.Tables[0].Rows.Count;
        cntCol = rDs.Tables[0].Columns.Count;
        Chart objChart = null;

        for (int i = 0; i < cntRow; i++)
        {
            switch (i)
            {
                case 0:
                    objChart = chtKPI1;
                    break;
                case 1:
                    objChart = chtKPI2;
                    break;
                case 2:
                    objChart = chtKPI3;
                    break;
                case 3:
                    objChart = chtKPI4;
                    break;
                case 4:
                    objChart = chtKPI5;
                    break;
                case 5:
                    objChart = chtKPI6;
                    break;
                case 6:
                    objChart = chtKPI7;
                    break;
                case 7:
                    objChart = chtKPI8;
                    break;
                default:
                    return;
            }

            int ikpi_ref_id = int.Parse(rDs.Tables[0].Rows[i]["KPI_REF_ID"].ToString());
            string sKpiName = rDs.Tables[0].Rows[i]["KPI_NAME"].ToString();

            DataSet dsGraph = objBSC.GetDashBoardKpiYearlyStatusList(this.IEstTermRefID, ikpi_ref_id, this.IYmd, int.Parse(txtYearTerm.Text));

            MSCharts.DundasChartBase(objChart, ChartImageType.Jpeg, charWidth, charHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

            Series serT = MSCharts.CreateSeries
                            ( objChart
                            , "T"
                            , objChart.ChartAreas[0].Name
                            , "계획"
                            , "계획"
                            , SeriesChartType.Column
                            , 1
                            , Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            Series serR = MSCharts.CreateSeries
                            (objChart
                            , "R"
                            , objChart.ChartAreas[0].Name
                            , "실적"
                            , "실적"
                            , SeriesChartType.Column
                            , 1
                            , Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            Series serA = MSCharts.CreateSeries
                            (objChart
                            , "A"
                            , objChart.ChartAreas[0].Name
                            , "달성율"
                            , "달성율"
                            , SeriesChartType.Bubble
                            , 0
                            , Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


            //objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].AxisX.Interval = 1;

            objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].Area3DStyle.Enable3D    = false;
            objChart.ChartAreas[objChart.Series[serR.Name].ChartArea].AxisY2.Enabled          = AxisEnabled.True;
            objChart.ChartAreas[objChart.Series[serT.Name].ChartArea].AxisY.LabelStyle.Format = "#,##0";
            serA.YAxisType   = AxisType.Secondary;
            //serT.ToolTip = "Target \t= #VALY{d}";
            //serR.ToolTip = "Result \t= #VALY{d}";
            //serA.ToolTip = "Rate \t= #VALY{P}";

            serT.ToolTip = "#VALY{d}";
            serR.ToolTip = "#VALY{d}";
            serA.ToolTip = "#VALY{P}";

            objChart.DataSource  = dsGraph;
            serT.YValueMembers = "TARGET_TS";
            serR.YValueMembers = "RESULT_TS";
            serA.YValueMembers = "ACHV_RATE_TS";
            serT.XValueMember  = "YMD";
            objChart.DataBind();
            objChart.Legends[0].Enabled = false;

            objChart.Titles[0].Text = sKpiName;

            dsGraph  = null;
            serT     = null;
            serR     = null;
            serA     = null;
            objChart = null;
        }

        if (cntRow > 1 && cntRow < 3)
        {
            tr01.Visible = true;
            //tr02.Visible = false;
            tr03.Visible = false;
            //tr04.Visible = false;
            return;
        }
        else if (cntRow > 2 && cntRow < 5)
        {
            tr01.Visible = true;
            //tr02.Visible = true;
            tr03.Visible = false;
            //tr04.Visible = false;
            return;
        }
        else if (cntRow > 4 && cntRow < 7)
        {
            tr01.Visible = true;
            //tr02.Visible = true;
            tr03.Visible = true;
            //tr04.Visible = false;
            return;
        }
        else
        {
            tr01.Visible = true;
            //tr02.Visible = true;
            tr03.Visible = true;
            //tr04.Visible = true;
            return;
        }
    }

    private void SetGraph()
    {
        int charWidth = 300;
        int charHeight = 170;

        int cntRow = 0;
        int cntCol = 0;
        int intLP = 0;
        string strSerNm = "";

        //================================================================== 관점별 달성율
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet dsViw = objBSC.GetEstDeptKpiViewTypeList
                                                 (this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID);

        if (dsViw.Tables[0].Rows.Count > 0)
        {
            Chart chartMS = chartView;
            MSCharts.DundasChartBase(chartMS, ChartImageType.Jpeg, charWidth, charHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);
            Series serARate = MSCharts.CreateSeries(chartMS, "serA", "AreaView", "달성율", null, SeriesChartType.Bar, 0, GetChartColor(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            chartMS.Legends[0].Enabled = false;
            serARate.ToolTip = "#VALY{P}";

            chartMS.ChartAreas["AreaView"].Area3DStyle.Enable3D = false;

            chartMS.DataSource     = dsViw;
            serARate.YValueMembers = "ACHV_RATE";
            serARate.XValueMember  = "VIEW_NAME";
            chartMS.DataBind();
        }

        //================================================================== 등급구간별별 점수현황
        DataSet dsGrd = objBSC.GetKpiGradeStatusForMap
                                                 (this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID);

        if (dsGrd.Tables[0].Rows.Count > 0)
        {
            Chart chartGD = chartGrade;
            MSCharts.DundasChartBase(chartGD, ChartImageType.Jpeg, charWidth, charHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

            Series serCRate = MSCharts.CreateSeries(chartGD, "serA", "AreaGrade", "달성율", null, SeriesChartType.Pie, 0, GetChartColor(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            chartGD.Legends[0].Enabled = false;
            serCRate.ToolTip = "#VALY{P}";

            chartGD.ChartAreas["AreaGrade"].Area3DStyle.Enable3D = true;
            serCRate["PieLabelStyle"] = "Outside";

            chartGD.DataSource     = dsGrd;
            serCRate.YValueMembers = "C_RATE";
            serCRate.XValueMember  = "THRESHOLD_KNAME";
            chartGD.DataBind();
        }

        //================================================================== 지표군별 점수현황
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBOR = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();
        DataSet dsGroup = objBOR.GetDashBoardForKpiGroupScore(this.IEstTermRefID, this.IYmd, this.ISumType);

        if (dsGroup.Tables[0].Rows.Count > 0)
        {
            MSCharts.DundasChartBase(chartGroup, ChartImageType.Jpeg, charWidth, charHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.Graphics);
            Series serGroup = MSCharts.CreateSeries(chartGroup, "serA", "AreaGroup", "점수", null, SeriesChartType.Bar, 0, GetChartColor(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            chartGroup.Legends[0].Enabled = false;
            serGroup.ToolTip = "#VALY{P}";

            chartGroup.ChartAreas["AreaGroup"].Area3DStyle.Enable3D = false;

            chartGroup.DataSource  = dsGroup;
            serGroup.YValueMembers = "POINTS";
            serGroup.XValueMember  = "KPI_GROUP_NAME";
            chartGroup.DataBind();
        }
    }
    #endregion

}
