﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;


using MicroCharts;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class BSC_BSC0304P2 : AppPageBase
{
    public String kpiCode       = "";
    public String kpiname       = "";
    public int ikpiType         = 0;
    public String skpiType      = "";
    public String kpiType       = "";
    public String champname     = "";
    public String check_purpose = "";
    public String calc_form     = "";
    public String grammer       = "";
    public String issue         = "";
    public String is3D          = "";

    decimal sumplanVal          = 0;
    decimal sumactVal           = 0;
    decimal old_chkVal          = 0;
    decimal old_chksumVal       = 0;
    int cnt                     = 0;

    int intRowNum = 0;
    Workbook workBook = null; // smjjang

    public string unit = "-";

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

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

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "000000");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string IYMD_NEXT
    {
        get
        {
            if (ViewState["YMD_NEXT"] == null)
            {
                ViewState["YMD_NEXT"] = GetRequest("YMD_NEXT", "-");
            }

            return (string)ViewState["YMD_NEXT"];
        }
        set
        {
            ViewState["YMD_NEXT"] = value;
        }
    }

    public string IHaveInitive_YN
    {
        get
        {
            if (ViewState["HAVE_INITIATIVE_YN"] == null)
            {
                ViewState["HAVE_INITIATIVE_YN"] = GetRequest("HAVE_INITIATIVE_YN", "N");
            }
            return (string)ViewState["HAVE_INITIATIVE_YN"];
        }
        set
        {
            ViewState["HAVE_INITIATIVE_YN"] = value;
        }
    }

    public string IBasisUse_YN
    {
        get
        {
            if (ViewState["BASIS_USE_YN"] == null)
            {
                ViewState["BASIS_USE_YN"] = GetRequest("BASIS_USE_YN", "");
            }
            return (string)ViewState["BASIS_USE_YN"];
        }
        set
        {
            ViewState["BASIS_USE_YN"] = value;
        }
    }

    public string IGoalTong_YN
    {
        get
        {
            if (ViewState["GOALTONG_YN"] == null)
            {
                ViewState["GOALTONG_YN"] = GetRequest("GOALTONG_YN", "N");
            }
            return (string)ViewState["GOALTONG_YN"];
        }
        set
        {
            ViewState["GOALTONG_YN"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetTopMenu();
            InitControlValue();
        }
        else
        { 
           
        }

        
    }

    #region 페이지 초기화 함수

    private void SetTopMenu()
    {
        if (this.IType != "POP")
        {
            this.iBtnSearch.Visible = true;
        }
        else
        { 
            this.iBtnSearch.Visible = false;
            base.SetMenuControl(false, false, false);
        }
    }

    private void InitControlValue()
    {
        iBtnInitiativeFile.Attributes.Add("onclick","return mfUpload('"+hdfInitiativeDocNo.ClientID.Replace('_','$')+"');");
        iBtnCauseFileID.Attributes.Add("onclick","return mfUpload('"+hdfCauseDocNo.ClientID.Replace('_','$')+"');");
        iBtnMeasureFileID.Attributes.Add("onclick","return mfUpload('"+hdfMeasureDocNo.ClientID.Replace('_','$')+"');");

        txtINITIATIVE_DO.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        txtINITIATIVE_PLAN.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        txtReason_Month.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        txtReason_Sum.Style.Add(HtmlTextWriterStyle.TextAlign, "left");

        ugrdPrjList.Visible = false;

        Biz_Bsc_Kpi_Info objKpi = new Biz_Bsc_Kpi_Info(IEstTermRefID, IKpiRefID);

        lblKpiCode.Text         = objKpi.Ikpi_code;
        lblKpiName.Text         = objKpi.Ikpi_name;
        kpiType                 = objKpi.Iresult_achievement_type;
        lblPNUType.Text         = objKpi.Iresult_achievement_type_name;
        lblUnitName.Text        = objKpi.Iunit_name;

        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, this.IEstTermRefID);
        PageUtility.FindByValueDropDownList(ddlMonthInfo, IYMD);

        lblMonthInfo.Text = PageUtility.GetByTextDropDownList(ddlMonthInfo);

        this.SetKPIBaseInfo();
        this.SetResultGrid();
        this.SetCommunicationGrid();
        this.SetExceptGrid();
    }

    #endregion

    #region
    private void SetInitiativeInfo()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        txtINITIATIVE_DO.Text       = PageUtility.GetHtmlEncodeChar(objBSC.Iinitiative_do);
        txtINITIATIVE_PLAN.Text     = PageUtility.GetHtmlEncodeChar(objBSC.Iinitiative_plan);
        hdfInitiativeDocNo.Value    = objBSC.Ido_file;
        iBtnInitiativeFile.Visible  = (objBSC.Ido_file == "") ? false : true;
    }

    private void SetResultGrid()
    {
        this.IYMD = PageUtility.GetByValueDropDownList(ddlMonthInfo);

        Biz_Bsc_Kpi_Result objBSC   = new Biz_Bsc_Kpi_Result(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        DataSet rDs                 = objBSC.GetResultAnalysisList(this.IEstTermRefID, this.IKpiRefID, this.IYMD, this.IGoalTong_YN);

        txtPlan_Month.Text          = PageUtility.GetHtmlEncodeChar(objBSC.Imeasure_text_ms);
        txtPlan_Sum.Text            = PageUtility.GetHtmlEncodeChar(objBSC.Imeasure_text_ts);
        txtReason_Month.Text        = PageUtility.GetHtmlEncodeChar(objBSC.Icause_text_ms);
        txtReason_Sum.Text          = PageUtility.GetHtmlEncodeChar(objBSC.Icause_text_ts);

        if (objBSC.Icause_file_id == "")
        {
            iBtnCauseFileID.Visible = false;
        }
        else
        {
            iBtnCauseFileID.Visible = true;
            hdfCauseDocNo.Value     = objBSC.Icause_file_id;
        }



        if (objBSC.Imeasure_file_id == "")
        {
            iBtnMeasureFileID.Visible = false;
        }
        else
        {
            iBtnMeasureFileID.Visible = false;
            hdfMeasureDocNo.Value = objBSC.Imeasure_file_id;
        }

        ugrdKpiResultStatus.Clear();
        ugrdKpiResultStatus.DataSource = rDs;
        ugrdKpiResultStatus.DataBind();

        try
        {
            this.SetResutlGraph(rDs);
        }
        catch (Exception e)
        {
            string msg = e.Message;
        }
    }

    private void SetResutlGraph(DataSet iDs)
    {
        DataSet dsGrph = iDs.Copy();
        dsGrph.Tables[0].Columns.Add("GR_RATE_MS", typeof(double));
        dsGrph.Tables[0].Columns.Add("GR_RATE_TS", typeof(double));

        for (int i = 0; i < dsGrph.Tables[0].Rows.Count; i++)
        {
            if (dsGrph.Tables[0].Rows[i]["AC_RATE_MS"].ToString() == "-")
            {
                dsGrph.Tables[0].Rows[i]["AC_RATE_MS"] = "0";
            }
            dsGrph.Tables[0].Rows[i]["GR_RATE_MS"] = Convert.ToDouble(dsGrph.Tables[0].Rows[i]["AC_RATE_MS"].ToString());

            if (dsGrph.Tables[0].Rows[i]["AC_RATE_TS"].ToString() == "-")
            { 
                dsGrph.Tables[0].Rows[i]["AC_RATE_TS"] = "0";
            }
            dsGrph.Tables[0].Rows[i]["GR_RATE_TS"] = Convert.ToDouble(dsGrph.Tables[0].Rows[i]["AC_RATE_TS"].ToString());
        }

        // 당월그래프
        DundasCharts.DundasChartBase(chartMM, ChartImageType.Flash, 385, 230
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        chartMM.DataSource = dsGrph;

        Series series1 = DundasCharts.CreateSeries(chartMM, "serPlan", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(chartMM, "serActl", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = DundasCharts.CreateSeries(chartMM, "serRate", "Default", "달성률", null, SeriesChartType.Line, 1, GetChartColor2(2), GetChartColor2(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        series3.YAxisType = AxisType.Secondary;

        series1.ValueMembersY = "TARGET_MS";
        series2.ValueMembersY = "RESULT_MS";
        series3.ValueMembersY = "GR_RATE_MS";
        series1.ValueMemberX = "MM";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        series3.ToolTip = "#VALY{P0}";

        string sChartArea = chartMM.Series[series2.Name].ChartArea;
        chartMM.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        chartMM.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

        DundasAnimations.DundasChartBase(chartMM, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chartMM, series1, 1.0, 1.0, true);
        DundasAnimations.GrowingAnimation(chartMM, series2, 2.0, 2.0, true);
        DundasAnimations.GrowingAnimation(chartMM, series3, 2.0, 1.0, true);

        chartMM.DataBind();

        // 누계그래프
        DundasCharts.DundasChartBase(chartTM, ChartImageType.Flash, 385, 230
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        chartTM.DataSource = dsGrph;

        Series series4 = DundasCharts.CreateSeries(chartTM, "serPlan", "Default", "누적계획", null, SeriesChartType.Column, 1, GetChartColor2(3), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series5 = DundasCharts.CreateSeries(chartTM, "serActl", "Default", "누적실적", null, SeriesChartType.Column, 1, GetChartColor2(4), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series6 = DundasCharts.CreateSeries(chartTM, "serRate", "Default", "달성율", null, SeriesChartType.Line, 1, GetChartColor2(2), GetChartColor2(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        series6.YAxisType = AxisType.Secondary;

        series4.ValueMembersY = "TARGET_TS";
        series5.ValueMembersY = "RESULT_TS";
        series6.ValueMembersY = "GR_RATE_TS";
        series4.ValueMemberX = "MM";

        series4.ToolTip = "#VALY{N0}";
        series5.ToolTip = "#VALY{N0}";
        series6.ToolTip = "#VALY{P0}";

        sChartArea = chartTM.Series[series4.Name].ChartArea;
        chartTM.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        chartTM.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

        DundasAnimations.DundasChartBase(chartTM, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chartTM, series4, 1.0, 1.0, true);
        DundasAnimations.GrowingAnimation(chartTM, series5, 2.0, 2.0, true);
        DundasAnimations.GrowingAnimation(chartTM, series6, 2.0, 1.0, true);

        chartTM.DataBind();
    }

    protected Color GetChartColor2(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(CHART_COLOR[iCheck, 0], CHART_COLOR[iCheck, 1], CHART_COLOR[iCheck, 2]);
    }

    protected int[,] CHART_COLOR = new int[,]
                                   {
                                        {0x0c, 0x4c, 0xd4},
                                        {0xff, 0xa1, 0x0d},
                                        {0xad, 0x00, 0x00},
                                        {0xff, 0x72, 0x00},
                                        {0x75, 0xd8, 0x00},
                                        {0xA8, 0xD2, 0xFD},
                                        {0xFB, 0xEE, 0xA6},
                                        {0xFC, 0xD1, 0xA6},
                                        {0xD1, 0xFC, 0xD1},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };

    private void UpdateCheckValue(string step, string ccheck, string fcheck)
    {

    }

    private void SetCommunicationGrid()
    {
        Biz_Bsc_Communication_List objBSC = new Biz_Bsc_Communication_List();
        this.ugrdCommunication.Clear();
        this.ugrdCommunication.DataSource = objBSC.GetAllListPerKpiUser(gUserInfo.Emp_Ref_ID, this.IEstTermRefID, this.IYMD, this.IKpiRefID, false);
        this.ugrdCommunication.DataBind();
    }

    private void SendMail(int step)
    {
        string strFrom = System.Configuration.ConfigurationSettings.AppSettings["Mail.From"].ToString();
        string strServer = System.Configuration.ConfigurationSettings.AppSettings["Mail.SMTP"].ToString();
        string strUrl = System.Configuration.ConfigurationSettings.AppSettings["Mail.Url"].ToString();

        Biz_Bsc_Kpi_Info kpiInfo = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);

        EmpInfos empinfo = new EmpInfos(kpiInfo.Ichampion_emp_id);
        string strSubject = GetFileText("../_common/SendMailTemplate/BSC_PC_NOTE_subject.txt");

        string strBody = GetFileText("../_common/SendMailTemplate/BSC_PC_NOTE_Content.txt");
        string kpi_info = @"등록일시     : " + DateTime.Now.ToString() + @"<br>
                            KPI ID       : " + kpiInfo.Ikpi_code + @"<br>
                            측정월       : " + this.IYMD + @"<br>
                            KPI Name     : " + kpiInfo.Ikpi_name + @"<br>
                            KPI Champion : " + empinfo.Emp_Name + @"<br>";
        strBody = strBody.Replace("[KPI_INFO]", kpi_info);
        string ceocomment = "";
        //if (step == 1)
        //    ceocomment = "DUE DATE : " + "" + "<br>" + txtComment1.Text.Replace("\r\n", "<br>");
        //else if (step == 2)
        //    ceocomment = "DUE DATE : " + "" + "<br>" + txtComment2.Text.Replace("\r\n", "<br>");
        strBody = strBody.Replace("[CEO_COMMENT]", ceocomment);
        strBody = strBody.Replace("[MAIL.URL]", strUrl);
        strBody = strBody.Replace("[TODAY]", DateTime.Today.ToString());
        //        strServer = "mail.micropolis.co.kr";
        if (ceocomment.Trim().Length > 0) SendMail(strFrom, empinfo.Emp_Email, strSubject, strBody, "", strServer);
    }

    /// <summary>
    /// 관련프로젝트
    /// </summary>
    private void SetProjectList()
    {
        MicroBSC.PRJ.Biz.Biz_Bsc_Kpi_Prj objBSC = new MicroBSC.PRJ.Biz.Biz_Bsc_Kpi_Prj();
        DataSet rDs = objBSC.GetKpiCodePrjectList(this.IEstTermRefID, this.IKpiRefID);

        ugrdPrjList.Clear();
        ugrdPrjList.DataSource = rDs;
        ugrdPrjList.DataBind();
    }

    /// <summary>
    /// 지표기본정보 (사업이 있는지 여부)
    /// </summary>
    private void SetKPIBaseInfo()
    {
        //-------------------- KPI Status Setting
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        DataSet rDs = objBSC.GetKpiStatus(this.IEstTermRefID, this.IKpiRefID, gUserInfo.Emp_Ref_ID);

        //Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(objBSC.Ikpi_pool_ref_id);
        //if (objPool.Ibasis_use_yn == "EQL")
        //{
        //    iBtnEstOpinion.Visible = true;
        //    Biz_Bsc_Kpi_Qlt_Score_Had objOpn = new Biz_Bsc_Kpi_Qlt_Score_Had();
        //    DataSet oDs = objOpn.GetAllList( this.IEstTermRefID
        //                                   , this.IYMD
        //                                   , 0
        //                                   , this.IKpiRefID  //PageUtility.GetIntByValueDropDownList(ddlEstLevel)
        //                                   , 0);
        //    ugrdEstOpinion.Clear();
        //    ugrdEstOpinion.DataSource = oDs.Tables[0].DefaultView;
        //    ugrdEstOpinion.DataBind();
        //}
        //else
        //{
        //    iBtnEstOpinion.Visible = false;
        //}

        if (rDs.Tables[0].Rows.Count > 0)
        {
            this.IHaveInitive_YN = rDs.Tables[0].Rows[0]["HAVE_INITIATIVE_YN"].ToString();

            if (this.IHaveInitive_YN == "Y")
            {
                this.SetProjectList();
            }
            else
            { 
                this.SetInitiativeInfo();
                ugrdPrjList.Clear();
            }
        }
    }

    /// <summary>
    /// 예측실적 그리드 조회
    /// </summary>
    private void SetExceptGrid()
    {
        this.IYMD_NEXT  = "-";

        Biz_Bsc_Kpi_Term objTrm = new Biz_Bsc_Kpi_Term();
        this.IYMD_NEXT = objTrm.GetNavigateMonth(this.IEstTermRefID, this.IKpiRefID, this.IYMD, gNavigator.NEXT);

        Biz_Bsc_Kpi_Result_Expect objNextExp = new Biz_Bsc_Kpi_Result_Expect(this.IEstTermRefID, this.IKpiRefID, this.IYMD_NEXT);
        lblExtResult_MS.Text           = PageUtility.GetHtmlEncodeChar(objNextExp.IResult_Ms.ToString());
        lblExtResult_TS.Text           = PageUtility.GetHtmlEncodeChar(objNextExp.IResult_Ts.ToString());
        lblEXPECT_REASON_MS.Text       = PageUtility.GetHtmlEncodeChar(objNextExp.IExpect_Reason_Ms);
        lblEXPECT_REASON_TS.Text       = PageUtility.GetHtmlEncodeChar(objNextExp.IExpect_Reason_Ts);
        lbltxtRESULT_DIFF_CAUSE.Text   = PageUtility.GetHtmlEncodeChar(objNextExp.IResult_Diff_Cause);

        lblNextYmd_Ms.Text = this.IYMD_NEXT;
        lblNextYmd_Ts.Text = this.IYMD_NEXT;

        DataSet rDs = objNextExp.GetResultExpect(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        grvResultExpt.DataSource = rDs.Tables[0].DefaultView;
        grvResultExpt.DataBind();
    }

    #endregion

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetResultGrid();
        this.SetExceptGrid();
    }

    protected void ugrdKpiResultStatus_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "월별 조회";
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 1;
        //ch.RowLayoutColumnInfo.SpanX = 6;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "누적 조회";
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 8;
        //ch.RowLayoutColumnInfo.SpanX = 6;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

        //// 단일 헤더 합침
        //ch = e.Layout.Bands[0].Columns.FromKey("MM").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "월";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 당 월 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 6;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX   = 1;
        ch.Style.Height = Unit.Pixel(20);
        ch.Style.BackColor = Color.White;
        ch.Style.BorderColor = Color.White;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "[ 누 적 ]";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 7;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        

        // 단일 헤더 합침
        ch = e.Layout.Bands[0].Columns.FromKey("MM").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        e.Layout.Bands[0].Columns.FromKey("SPLITER").Header.Style.BackColor = Color.White;

        // 단일 헤더 합침
        //ch = e.Layout.Bands[0].Columns.FromKey("SPLITER").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;
    }
    
    protected void ugrdKpiResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        int iYmd = (drw["YMD"] != null) ? int.Parse(drw["YMD"].ToString()) : 0;

        if (iYmd > int.Parse(this.IYMD))
        {
            e.Row.Cells.FromKey("TREND_MS").Value = "<div align=center><img src='../images/arrow/arrow_m.gif'></div>";
            e.Row.Cells.FromKey("TREND_TS").Value = "<div align=center><img src='../images/arrow/arrow_m.gif'></div>";
            e.Row.Cells.FromKey("IMAGE_FILE_NAME_MS").Value = String.Format("<div align=center><img src='../images/{0}'></div>", e.Row.Cells.FromKey("IMAGE_FILE_NAME_MS").Value.ToString());
            e.Row.Cells.FromKey("IMAGE_FILE_NAME_TS").Value = String.Format("<div align=center><img src='../images/{0}'></div>", e.Row.Cells.FromKey("IMAGE_FILE_NAME_TS").Value.ToString());
            return;
        }

        e.Row.Cells.FromKey("IMAGE_FILE_NAME_MS").Value = String.Format("<div align=center><img src='../images/{0}'></div>", e.Row.Cells.FromKey("IMAGE_FILE_NAME_MS").Value.ToString());
        e.Row.Cells.FromKey("IMAGE_FILE_NAME_TS").Value = String.Format("<div align=center><img src='../images/{0}'></div>", e.Row.Cells.FromKey("IMAGE_FILE_NAME_TS").Value.ToString());

        string strTrend = e.Row.Cells.FromKey("TREND_MS").Value.ToString();
        switch (strTrend)
        {
            case "UP":
                e.Row.Cells.FromKey("TREND_MS").Value = "<div align=center><img src='../images/arrow/arrow_e_up.gif'></div>";
                break;
            case "DOWN":
                e.Row.Cells.FromKey("TREND_MS").Value = "<div align=center><img src='../images/arrow/arrow_b_down.gif'></div>";
                break;
            case "FLAT":
                e.Row.Cells.FromKey("TREND_MS").Value = "<div align=center><img src='../images/arrow/arrow_m.gif'></div>";
                break;
            default:
                break;
        }

        strTrend = e.Row.Cells.FromKey("TREND_TS").Value.ToString();
        switch (strTrend)
        {
            case "UP":
                e.Row.Cells.FromKey("TREND_TS").Value = "<div align=center><img src='../images/arrow/arrow_e_up.gif'></div>"; 
                break;
            case "DOWN":
                e.Row.Cells.FromKey("TREND_TS").Value = "<div align=center><img src='../images/arrow/arrow_b_down.gif'></div>";
                break;
            case "FLAT":
                e.Row.Cells.FromKey("TREND_TS").Value = "<div align=center><img src='../images/arrow/arrow_m.gif'></div>";
                break;
            default:
                break;
        }

        if (drw["POINTS_MS"].ToString().Equals("-"))
        {
            e.Row.Cells.FromKey("POINTS_MS").Value = drw["POINTS_MS"].ToString();
        }
        else
        {
            e.Row.Cells.FromKey("POINTS_MS").Value = Convert.ToDouble(drw["POINTS_MS"].ToString());
        }

        if (drw["POINTS_TS"].ToString().Equals("-"))
        {
            e.Row.Cells.FromKey("POINTS_TS").Value = drw["POINTS_TS"].ToString();
        }
        else
        {
            e.Row.Cells.FromKey("POINTS_TS").Value = Convert.ToDouble(drw["POINTS_TS"].ToString());
        }

        e.Row.Cells.FromKey("AC_RATE_MS").Value = (drw["AC_RATE_MS"].ToString().Equals("-")) ? "-" : Convert.ToDouble(drw["AC_RATE_MS"].ToString()).ToString("#,###.00");
        e.Row.Cells.FromKey("AC_RATE_TS").Value = (drw["AC_RATE_TS"].ToString().Equals("-")) ? "-" : Convert.ToDouble(drw["AC_RATE_TS"].ToString()).ToString("#,###.00");
    }

    protected void ugrdCommunication_InitializeRow(object sender, RowEventArgs e)
    { 
        int intSpace     = (e.Row.Cells.FromKey("TREE_LEVEL").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("TREE_LEVEL").Value.ToString()) : 0;
        string strReIcon = "<img alt='' src='../images/icon/board_re.gif' style=\"vertical-align:middle;\" />";
        string strTitle  = (e.Row.Cells.FromKey("TITLE").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("TITLE").Value) : "";
        string strReadYN = (e.Row.Cells.FromKey("READ_YN").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("READ_YN").Value) : "X";
        string strEmpty  = "";

        if (intSpace > 1)
        {
            e.Row.Cells.FromKey("TITLE").Text = strEmpty.PadRight((intSpace-1)*2, ' ') + strReIcon + strTitle;
        }

        string strOkIcon = "<img alt='미확인' src='../images/icon/gr_po01_b.gif' style=\"vertical-align:middle;\" />";
        if (strReadYN == "N")
        {
            e.Row.Cells.FromKey("NUM_TEXT").Text = strOkIcon;
        }
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetResultGrid();
        this.SetInitiativeInfo();
        this.SetCommunicationGrid();
    }

    protected void ugrdEstOpinion_InitializeRow(object sender, RowEventArgs e)
    {
        string sFileId = (e.Row.Cells.FromKey("REVIEW_FILE_ID").Value == null) ? "" : e.Row.Cells.FromKey("REVIEW_FILE_ID").Value.ToString();
        TemplatedColumn colEst = (TemplatedColumn)e.Row.Cells.FromKey("EST_LEVEL_NAME").Column;

        System.Web.UI.WebControls.Label lblLevel      = (System.Web.UI.WebControls.Label)((CellItem)colEst.CellItems[e.Row.BandIndex]).FindControl("lblEST_LEVEL_NAME");
        System.Web.UI.WebControls.ImageButton btnFile = (System.Web.UI.WebControls.ImageButton)((CellItem)colEst.CellItems[e.Row.BandIndex]).FindControl("iBtnReviewFile");
        System.Web.UI.WebControls.HiddenField hdfFile = (System.Web.UI.WebControls.HiddenField)((CellItem)colEst.CellItems[e.Row.BandIndex]).FindControl("iHdfReviewFile");

        lblLevel.Text = (e.Row.Cells.FromKey("EST_LEVEL_NAME").Value == null) ? "" : e.Row.Cells.FromKey("EST_LEVEL_NAME").Value.ToString();

        if (sFileId.Length > 0)
        {
            hdfFile.Value = sFileId;
            btnFile.Visible = true;
            btnFile.OnClientClick = "return mfUpload('" + hdfFile.ClientID.Replace("$", "_") + "')";
        }
        else
        {
            hdfFile.Value = "";
            btnFile.Visible = false;
        }
    }
    protected void ugrdPrjList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }

    protected void ugrdPrjList_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void grvResultExpt_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell oTableCell = new TableHeaderCell();

            oTableCell.ColumnSpan = 1;
            oTableCell.RowSpan = 2;
            oTableCell.Text = "구분";
            oTableCell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#94bac9");
            oTableCell.Style.Add(HtmlTextWriterStyle.Color, "white");
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "[ 당  월 ]";
            oTableCell.ColumnSpan = 3;
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "[ 누  적 ]";
            oTableCell.ColumnSpan = 3;
            oGridViewRow.Cells.Add(oTableCell);

            oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

            e.Row.Cells[0].Visible = false;

            e.Row.Cells[0].Width = Unit.Pixel(120);
            e.Row.Cells[1].Width = Unit.Pixel(120);
            e.Row.Cells[2].Width = Unit.Pixel(120);
            e.Row.Cells[3].Width = Unit.Pixel(90);
            e.Row.Cells[4].Width = Unit.Pixel(120);
            e.Row.Cells[5].Width = Unit.Pixel(120);
            e.Row.Cells[6].Width = Unit.Pixel(90);
        }
    }
    
    protected void grvResultExpt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string sGubun = e.Row.Cells[0].Text;
        switch (sGubun)
        {
            case "EXPT":
                e.Row.Cells[0].Text = "예측실적";
                break;
            case "CURR":
                e.Row.Cells[0].Text = "당월실적";
                break;
            case "DIFF":
                e.Row.Cells[0].Text = "차    이";
                break;
            default:
                e.Row.Cells[0].Text = "-";
                break;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[6].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        }
    }
}
