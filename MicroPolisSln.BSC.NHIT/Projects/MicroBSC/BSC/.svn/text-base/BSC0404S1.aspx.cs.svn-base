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

//using Dundas.Charting.WebControl;
using MicroCharts;
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using MicroBSC.Biz.BSC.Dac;
using MicroBSC.Common;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC0404S1 : AppPageBase
{
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

    public int IDeptType
    {
        get
        {
            if (ViewState["DEPT_TYPE_ID"] == null)
            {
                ViewState["DEPT_TYPE_ID"] = GetRequestByInt("DEPT_TYPE_ID", 0);
            }

            return (int)ViewState["DEPT_TYPE_ID"];
        }
        set
        {
            ViewState["DEPT_TYPE_ID"] = value;
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

    public bool IExtKpiYN
    {
        get
        {
            if (ViewState["EXT_KPI_YN"] == null)
            {
                ViewState["EXT_KPI_YN"] = (GetRequest("EXT_KPI_YN", "N") == "Y") ? true : false;
            }

            return (bool)ViewState["EXT_KPI_YN"];
        }
        set
        {
            ViewState["EXT_KPI_YN"] = value;
        }
    }

    public string IPrintType
    {
        get
        {
            if (ViewState["PRINT_TYPE"] == null)
            {
                ViewState["PRINT_TYPE"] = GetRequest("PRINT_TYPE", "MONITOR");
            }

            return (string)ViewState["PRINT_TYPE"];
        }
        set
        {
            ViewState["PRINT_TYPE"] = value;
        }
    }

    #region 페이지 초기화
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";

        // 웹 취약성 검사 때문에 처리
        if (IType.Equals("-0")
            || IYmd.Equals("-0")
            || ISumType.Equals("-0")
            || IPrintType.Equals("-0"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("악성 요청을 거부합니다.", false);
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        if (!IsPostBack)
        {
            this.NotPostBackSetting();
            //IEstDeptID = -1;
            //SetDeptScoreCard();
        }
        else
        { 
            
        }
    }
    #endregion

    #region 내부함수
    private void NotPostBackSetting()
    {
        // 골타겟 관련 입력 버튼 (농협에서 추가)
        if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
        {
            rdoGoalTong.Visible = true;
        }

        iBtnPrint.Style.Add("vertical-align", "middle");
        ugrdKpiStatusTab.SelectedTab = 0;

        WebCommon.SetSumTypeDropDownList(ddlSumType, false);
        WebCommon.SetScoreCardLevelDropDownList(ddlMapLevel, false);

        if (this.IEstTermRefID > 0 && this.IYmd != "")
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            PageUtility.FindByValueDropDownList(ddlEstTermInfo, this.IEstTermRefID);

            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            PageUtility.FindByValueDropDownList(ddlMonthInfo, this.IYmd);

        }
        else
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

            
            IEstTermRefID = DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlEstTermInfo));
            IYmd = PageUtility.GetByValueDropDownList(ddlMonthInfo);

            
            MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp bizRelDeptEmp = new MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp();
            IEstDeptID = DataTypeUtility.GetToInt32(bizRelDeptEmp.Get_Dept_ID_of_Emp_ID(gUserInfo.Emp_Ref_ID.ToString()));            
        }


        WebCommon.FillEstMappingTree_NW(trvEstDept, this.IEstTermRefID, this.IEstDeptID, TreeNodeSelectAction.Select);
        //WebCommon.FillEstTree(trvEstDept
        //                    , PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
        //                    , gUserInfo.Emp_Ref_ID
        //                    , this.IEstDeptID);

        WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        chkApplyExtScore.Checked = this.IExtKpiYN;


        this.SetKpiSignalMaster();

        if (trvEstDept.Nodes.Count > 0 && this.IEstDeptID > 0 && this.IEstTermRefID > 0)
        {
            this.SetParameter();

            if (!this.HaveReadRight())
            {
                ltrScript.Text = JSHelper.GetAlertScript("조회할 권한이 없습니다.", false);
                return;
            }

            this.SetDeptMapInfo();
            this.SetDeptScoreCard();
        }
        else if (trvEstDept.Nodes.Count > 0 && this.IEstDeptID < 1 && this.IEstTermRefID < 1)
        {
            trvEstDept.Nodes[0].Select();
            this.IEstDeptID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
            this.SetParameter();

            if (!this.HaveReadRight())
            {
                return;
            }

            this.SetDeptMapInfo();
            this.SetDeptScoreCard();
        }
        else
        {
            lblDeptName.Text   = "";
            lblTotalScore.Text = "";
            lblDeptVision.Text = "";
            ugrdScoreCard.Clear();
        }
    }

    private void PostBackSetting()
    {

    }

    private void SetParameter()
    { 
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.ISumType      = PageUtility.GetByValueDropDownList(ddlSumType);
        this.IExtKpiYN     = chkApplyExtScore.Checked;
    }

    private void SetDeptMapInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMap = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID
                                                                                       , this.IEstDeptID
                                                                                       , this.IYmd);
        lblDeptName.Text    = objMap.Iest_dept_name;
        lblDeptVision.Text  = objMap.Idept_vision;
        lblBSCChampion.Text = objMap.Ibscchampion_name;
    }

    /// <summary>
    /// 스코어카드 그리드 바인딩
    /// 엑셀출력의 경우 숨겨진 그리드에 바인딩하고 출력한다(this.IPrintType == "XLS" || this.IPrintType == "PDF")
    /// </summary>
    public void SetDeptScoreCard()
    {

        


        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        //DataSet iDs = objBSC.GetEstDeptTotalScore( this.IEstTermRefID
        //                                         , this.IYmd
        //                                         , this.ISumType
        //                                         , this.IEstDeptID);

        DataSet dsViw = new DataSet();
        DataSet dsKpi = new DataSet();
        DataSet dsTot = new DataSet();

        if (rdoGoalTong.SelectedIndex.Equals(0))
        {

            dsViw = objBSC.GetEstDeptKpiViewTypeList
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);

            dsKpi = objBSC.GetEstDeptKpiScoreList
                                                (this.IEstTermRefID
                                                , this.IYmd
                                                , this.ISumType
                                                , this.IEstDeptID
                                                , this.IExtKpiYN);



            dsTot = objBSC.GetEstDeptTotalScore
                                                    (this.IEstTermRefID
                                                    , this.IYmd
                                                    , this.ISumType
                                                    , this.IEstDeptID
                                                    , this.IExtKpiYN);
        }
        else
        {
            dsViw = objBSC.GetEstDeptKpiViewTypeList_Goal
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);

            dsKpi = objBSC.GetEstDeptKpiScoreList_Goal
                                                (this.IEstTermRefID
                                                , this.IYmd
                                                , this.ISumType
                                                , this.IEstDeptID
                                                , this.IExtKpiYN);

            dsTot = objBSC.GetEstDeptTotalScore_Goal
                                                    (this.IEstTermRefID
                                                    , this.IYmd
                                                    , this.ISumType
                                                    , this.IEstDeptID
                                                    , this.IExtKpiYN);

        }




        

        DataSet dsTree = new DataSet();
        if (ddlMapLevel.SelectedValue == "SP")
        {
            DataSet dsStg = new DataSet();
            if (rdoGoalTong.SelectedIndex.Equals(0))
            {
                dsStg = objBSC.GetScorePerStrategy
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);
            }
            else
            {
                dsStg = objBSC.GetScorePerStrategy_Goal
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);
            }


            DataTable dtStg = dsStg.Tables[0].Copy();
            DataTable dtKpi = dsKpi.Tables[0].Copy();

            dsTree = dsViw.Copy();
            dsTree.Tables.Add(dtStg);
            dsTree.Tables.Add(dtKpi);


            dsTree.Relations.Add("SCORE_CARD_STG", dsTree.Tables[0].Columns["VIEW_REF_ID"], dsTree.Tables[1].Columns["VIEW_REF_ID"]);
            dsTree.Relations.Add("SCORE_CARD_KPI", dsTree.Tables[1].Columns["STG_REF_ID"], dsTree.Tables[2].Columns["STG_REF_ID"]);
        }
        else
        {
            DataTable dtKpi = dsKpi.Tables[0].Copy();

            dsTree = dsViw.Copy();
            dsTree.Tables.Add(dtKpi);

            dsTree.Relations.Add("SCORE_CARD_KPI", dsTree.Tables[0].Columns["VIEW_REF_ID"], dsTree.Tables[1].Columns["VIEW_REF_ID"]);
        }

        if (this.IPrintType == "MONITOR")
        {
            ugrdScoreCard.Clear();
            ugrdScoreCard.DataSource = dsTree.Tables[0].DefaultView;
            ugrdScoreCard.DataBind();
        }
        else if (this.IPrintType == "XLS" || this.IPrintType == "PDF")
        { 
            ugrdScoreCardForPrint.Clear();
            ugrdScoreCardForPrint.DataSource = dsTree.Tables[0].DefaultView;
            ugrdScoreCardForPrint.DataBind();
        }

        lblTotalScore.Style.Add("align", "right");
        lblTotalScore.Text = (dsTot.Tables[0].Rows.Count > 0) ? double.Parse(dsTot.Tables[0].Rows[0]["POINT"].ToString()).ToString("#,##0.00") : "0";
    }

    /// <summary>
    /// 관점별 / 등급별 현황 그래프
    /// </summary>
    private void SetGraph()
    {
        int chartWidth = 310;
        int chartHeight = 400;

        double tempWidth = DataTypeUtility.GetToInt32(hdfScreenWidth.Value) * 0.31;
        double tempHeight = DataTypeUtility.GetToInt32(hdfScreenHeight.Value) * 0.33;

        chartWidth = DataTypeUtility.GetToInt32(Math.Round(tempWidth, 0));
        chartHeight = DataTypeUtility.GetToInt32(Math.Round(tempHeight, 0));

        chartView.Visible = false;
        chartGrade.Visible = false;

        this.SetParameter();
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();

        DataSet dsViw = new DataSet();
        DataSet dsGrd = new DataSet();


        if (rdoGoalTong.SelectedIndex.Equals(0))
        {
            dsViw = objBSC.GetEstDeptKpiViewTypeList
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);



            dsGrd = objBSC.GetKpiGradeStatusForMap
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);
        }
        else
        {
            dsViw = objBSC.GetEstDeptKpiViewTypeList_Goal
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);


            dsGrd = objBSC.GetKpiGradeStatusForMap_Goal
                                                     (this.IEstTermRefID
                                                     , this.IYmd
                                                     , this.ISumType
                                                     , this.IEstDeptID
                                                     , this.IExtKpiYN);
        }

        if (dsViw.Tables[0].Rows.Count > 0)
        {
            
            Chart chartMS = this.ugrdKpiStatusTab.FindControl("chartView") as Chart;

            chartMS.Visible = true;

            MSCharts.DundasChartBase(chartMS, ChartImageType.Jpeg, chartWidth, chartHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);
            Series serARate = MSCharts.CreateSeries(chartMS, "serA", "AreaView", "달성율", null, SeriesChartType.Column, 0, GetChartColor(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            chartMS.Legends[0].Enabled = false;
            serARate.ToolTip = "#VALY{P}";

            chartMS.ChartAreas["AreaView"].Area3DStyle.Enable3D = true;

            chartMS.DataSource = dsViw;
            serARate.YValueMembers = "ACHV_RATE";
            serARate.XValueMember = "VIEW_NAME";
            chartMS.DataBind();

        }

      

        if (dsGrd.Tables[0].Rows.Count > 0)
        {
            
            Chart chartGD = this.ugrdKpiStatusTab.FindControl("chartGrade") as Chart;


            DataRow[] rows = dsGrd.Tables[0].Select(" C_RATE <> 0 ");

            if(rows.Length > 0)
                chartGD.Visible = true;

            MSCharts.DundasChartBase(chartGD, ChartImageType.Jpeg, chartWidth, chartHeight
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 1
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

            Series serCRate = MSCharts.CreateSeries(chartGD, "serA", "AreaGrade", "달성율", null, SeriesChartType.Doughnut, 0, GetChartColor(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            chartGD.Legends[0].Enabled = false;
            serCRate.ToolTip = "#VALY{P}";

            chartGD.ChartAreas["AreaGrade"].Area3DStyle.Enable3D = true;

            chartGD.DataSource     = dsGrd;
            serCRate.YValueMembers = "C_RATE";
            serCRate.XValueMember  = "THRESHOLD_ENAME";
            chartGD.DataBind();
        }
    }

    /// <summary>
    /// 전체 폼 조회
    /// </summary>
    private void SelectAllObject()
    {
        this.SetDeptMapInfo();
        this.SetParameter();
        if (this.ugrdKpiStatusTab.SelectedTab == 0)
        {
            this.SetDeptScoreCard();
        }
        else
        {
            this.SetGraph();
        }
    }

    /// <summary>
    /// 엑셀출력
    /// </summary>
    private void PrintFormGrid()
    {
        this.IPrintType = "XLS";
        this.SetDeptScoreCard();
        string strCurDate     = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');
        ugrdEEP.ExcelStartRow = 7;
        ugrdEEP.ExportMode    = ExportMode.Download;
        ugrdEEP.DownloadName  = "ScoreCard"+strCurDate+".xls"; 
        ugrdEEP.WorksheetName = "ScoreCardFor"+lblDeptName.Text;
        ugrdEEP.Export(ugrdScoreCardForPrint);
        this.IPrintType = "MONITOR";
        ugrdScoreCardForPrint.Clear();
    }

    private bool HaveReadRight()
    {
        Dac_EmpComDeptDetails objBSC = new Dac_EmpComDeptDetails();
        return objBSC.IsAccessRightEstDept(this.IEstTermRefID, this.IEstDeptID, gUserInfo.Emp_Ref_ID);
    }

    private void SetKpiSignalMaster()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Threshold_Code objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Threshold_Code();
        DataTable dt = objBSC.GetThresholdCodeList("").Tables[0];

        foreach(DataRow dr in dt.Rows) 
        {
            dr["IMAGE_FILE_NAME"] = string.Format("../images/org/signal_set{0}/{1}", WebUtility.GetConfig("DTree.SignalSet") , dr["IMAGE_FILE_NAME"]);
        }

        grvSignal.DataSource = dt;
        grvSignal.DataBind();
    }

    #endregion
    
    #region 서버이벤트
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetParameter();
        this.SetDeptMapInfo();
        if (this.ugrdKpiStatusTab.SelectedTab == 0)
        {
            this.SetDeptScoreCard();
        }
        else
        {
            this.SetGraph();
        }
    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        int intDept = this.IEstDeptID;
        this.IEstDeptID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);

        if (!this.HaveReadRight())
        {
            ltrScript.Text  = JSHelper.GetAlertScript("조회할 권한이 없습니다.", false);
            this.IEstDeptID = intDept;
            trvEstDept.SelectedNode.SelectAction = TreeNodeSelectAction.None;
            return;
        }

        this.SetParameter();
        this.SetDeptMapInfo();

        if (this.ugrdKpiStatusTab.SelectedTab == 0)
        {
            this.SetDeptScoreCard();
        }
        else
        {
            this.SetGraph();
        }

        trvEstDept.SelectedNode.SelectAction = TreeNodeSelectAction.Select;
    }

    protected void ugrdScoreCard_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        UltraWebGrid ugrdGrid = (this.IPrintType == "MONITOR") ? ugrdScoreCard : ugrdScoreCardForPrint ;

        int idxBand      = (ddlMapLevel.SelectedValue == "VP") ? 1 : 2;
        string widthView = (ddlMapLevel.SelectedValue == "VP") ? "500 px" : "544 px";
        //----------------------------------------------------------------------
        // 관점설정
        //----------------------------------------------------------------------
        ugrdGrid.Bands[0].Columns.FromKey("ESTTERM_REF_ID").Hidden  = true;
        ugrdGrid.Bands[0].Columns.FromKey("YMD").Hidden             = true;
        ugrdGrid.Bands[0].Columns.FromKey("VIEW_REF_ID").Hidden     = true;
        ugrdGrid.Bands[0].Columns.FromKey("EST_DEPT_REF_ID").Hidden = true;
        ugrdGrid.Bands[0].Columns.FromKey("ACHV_RATE").Hidden       = true;

        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("VIEW_NAME").Header.Caption = "관점명";
        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("POINT").Header.Caption     = "관점별 최종점수";
        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("WEIGHT").Header.Caption    = "가중치";

        ugrdGrid.Bands[0].Columns.FromKey("VIEW_NAME").Width = new Unit(widthView);
        ugrdGrid.Bands[0].Columns.FromKey("POINT").Width     = new Unit("150 px");
        ugrdGrid.Bands[0].Columns.FromKey("WEIGHT").Width    = new Unit("100 px");
        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("POINT").Format    = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("WEIGHT").Format   = "#,##0.00";

        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("POINT").CellStyle.HorizontalAlign  = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[0].Columns.FromKey("WEIGHT").CellStyle.HorizontalAlign = HorizontalAlign.Right;

        if (this.IPrintType == "XLS")
        {
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("1");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("2");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("3");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("4");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("5");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("6");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("7");
            ugrdGrid.DisplayLayout.Bands[0].Columns.Add("8");
        }

        //----------------------------------------------------------------------
        // 관점별 전략 설정
        //----------------------------------------------------------------------
        if (ddlMapLevel.SelectedValue == "SP")
        {
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("ESTTERM_REF_ID").Hidden  = true;
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("YMD").Hidden             = true;
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("VIEW_REF_ID").Hidden     = true;
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("VIEW_NAME").Hidden       = true;
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("EST_DEPT_REF_ID").Hidden = true;
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("STG_REF_ID").Hidden      = true;
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("ACHV_RATE").Hidden       = true;
            
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("STG_NAME").Header.Caption = "전략명";
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("POINT").Header.Caption    = "전략별 획득점수";
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("WEIGHT").Header.Caption   = "가중치";

            ugrdGrid.Bands[idxBand-1].Columns.FromKey("STG_NAME").Width = new Unit("500 px");
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("POINT").Width    = new Unit("150 px");
            ugrdGrid.Bands[idxBand-1].Columns.FromKey("WEIGHT").Width   = new Unit("100 px");
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("POINT").Format  = "#,##0.00";
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("WEIGHT").Format = "#,##0.00";
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("POINT").CellStyle.HorizontalAlign  = HorizontalAlign.Right;
            ugrdGrid.DisplayLayout.Bands[idxBand-1].Columns.FromKey("WEIGHT").CellStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        //----------------------------------------------------------------------
        // 전략별 KPI 설정
        //----------------------------------------------------------------------
        ugrdGrid.Bands[idxBand].Columns.FromKey("ESTTERM_REF_ID").Hidden  = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("EST_DEPT_REF_ID").Hidden = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("VIEW_REF_ID").Hidden     = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("VIEW_NAME").Hidden       = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("STG_REF_ID").Hidden      = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("STG_NAME").Hidden        = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("KPI_REF_ID").Hidden      = true;        
        ugrdGrid.Bands[idxBand].Columns.FromKey("YMD").Hidden             = true;
        ugrdGrid.Bands[idxBand].Columns.FromKey("SIGNAL_NAME").Hidden     = true;

        ugrdGrid.Bands[idxBand].Columns.FromKey("SIGNAL").Hidden          = false;
        ugrdGrid.Bands[idxBand].Columns.FromKey("ORI_POINT").Hidden       = false;
        ugrdGrid.Bands[idxBand].Columns.FromKey("POINT").Hidden           = false;
        ugrdGrid.Bands[idxBand].Columns.FromKey("AC_POINT").Hidden        = false;
        ugrdGrid.Bands[idxBand].Columns.FromKey("WEIGHT").Hidden          = false;
        ugrdGrid.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Hidden  = false;

        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("KPI_NAME").Header.Caption       = "KPI명";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("UNIT").Header.Caption           = "단위";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").Header.Caption         = "목표";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").Header.Caption         = "실적";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("SIGNAL").Header.Caption         = "신호";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").Header.Caption      = "획  득";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").Header.Caption          = "변환전";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").Header.Caption       = "변환후";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").Header.Caption         = "변환전";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Header.Caption = "변환후";

        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("KPI_NAME").Header.Style.HorizontalAlign       = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("UNIT").Header.Style.HorizontalAlign           = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("SIGNAL").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").Header.Style.HorizontalAlign      = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").Header.Style.HorizontalAlign          = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").Header.Style.HorizontalAlign       = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").Header.Style.HorizontalAlign         = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Header.Style.HorizontalAlign = HorizontalAlign.Center;

        ugrdGrid.Bands[idxBand].Columns.FromKey("KPI_NAME").Width       = new Unit("221 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("UNIT").Width           = new Unit("40 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("TARGET").Width         = new Unit("85 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("RESULT").Width         = new Unit("85 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("SIGNAL").Width         = new Unit("47 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("ORI_POINT").Width      = new Unit("50 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("POINT").Width          = new Unit("50 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("AC_POINT").Width       = new Unit("50 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("WEIGHT").Width         = new Unit("50 px");
        ugrdGrid.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Width = new Unit("50 px");

        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").Format         = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").Format         = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").Format      = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").Format          = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").Format       = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").Format         = "#,##0.00";
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").Format = "#,##0.00";

        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("UNIT").CellStyle.HorizontalAlign           = HorizontalAlign.Center;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("TARGET").CellStyle.HorizontalAlign         = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("RESULT").CellStyle.HorizontalAlign         = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("ORI_POINT").CellStyle.HorizontalAlign      = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("POINT").CellStyle.HorizontalAlign          = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("AC_POINT").CellStyle.HorizontalAlign       = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("WEIGHT").CellStyle.HorizontalAlign         = HorizontalAlign.Right;
        ugrdGrid.DisplayLayout.Bands[idxBand].Columns.FromKey("CURRENT_WEIGHT").CellStyle.HorizontalAlign = HorizontalAlign.Right;
    }
    
    protected void ugrdScoreCard_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        string strURL;
        //if (this.IType.Equals("POP"))
        //{
        //    strURL = "<a href=\"gfOpenWindow('../BSC/BSC0304S2.aspx?iType=" + this.IType + "&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}',800,600,'no','no');\" style=\"color:Navy;\">{3}</a>";
        //}
        //else
        //{
        //    strURL = "<a href='../BSC/BSC0304S2.aspx?iType="+this.IType+"&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}' style=\"color:Navy;\">{3}</a>";
        //}
        strURL = "<a href=\"javascript:gfOpenWindow('../BSC/BSC0304P1.aspx?iType=POP&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}',790,600,'no','no');\" style=\"color:Navy;\">{3}</a>";
        
        
        
        if (ddlMapLevel.SelectedValue == "SP")
        {
            if (e.Row.Band.Index == 1)
            {
                e.Row.Style.BackColor = System.Drawing.Color.White;
                e.Row.Style.ForeColor = System.Drawing.Color.Black;
                e.Row.Expand(false);
            }
            else if (e.Row.Band.Index == 2)
            {
                if (this.IPrintType == "MONITOR")
                {
                    //e.Row.Cells.FromKey("SIGNAL").Text = "<img alt='' src='../images/" + e.Row.Cells.FromKey("SIGNAL").Value.ToString() + "'";

                    e.Row.Cells.FromKey("SIGNAL").Text = string.Format("<img alt='' src='../images/org/signal_set{0}/{1}'>", WebUtility.GetConfig("DTree.SignalSet"), drw["SIGNAL"]);
                    e.Row.Cells.FromKey("SIGNAL").Style.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Style.BackColor = System.Drawing.Color.White;
                    e.Row.Style.ForeColor = System.Drawing.Color.Black;
                }
                else
                { 
                    e.Row.Cells.FromKey("SIGNAL").Text = e.Row.Cells.FromKey("SIGNAL_NAME").Text;
                }

                if (e.Row.Cells.FromKey("POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("POINT").Value = double.Parse(e.Row.Cells.FromKey("POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }

                if (e.Row.Cells.FromKey("AC_POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("AC_POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("AC_POINT").Value = double.Parse(e.Row.Cells.FromKey("AC_POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }

                if (e.Row.Cells.FromKey("ORI_POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("ORI_POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("ORI_POINT").Value = double.Parse(e.Row.Cells.FromKey("ORI_POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }

                if (this.IPrintType == "MONITOR")
                {
                    e.Row.Cells.FromKey("KPI_NAME").Text = string.Format(strURL
                                                                       , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value
                                                                       , e.Row.Cells.FromKey("KPI_REF_ID").Value
                                                                       , e.Row.Cells.FromKey("YMD").Value
                                                                       , e.Row.Cells.FromKey("KPI_NAME").Value);
                }

                e.Row.Expand(false);
            }
            else
            {
                e.Row.Style.ForeColor = System.Drawing.Color.DarkBlue;
                e.Row.Style.Font.Bold = true;
                e.Row.Height = Unit.Pixel(20);
                e.Row.Style.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Row.Expand(false);
            }
        }
        else
        {
            if (e.Row.Band.Index == 1)
            {
                if (this.IPrintType == "MONITOR")
                {
                    //e.Row.Cells.FromKey("SIGNAL").Text = "<img alt='' src='../images/" + e.Row.Cells.FromKey("SIGNAL").Value.ToString() + "'";

                    e.Row.Cells.FromKey("SIGNAL").Text = string.Format("<img alt='' src='../images/org/signal_set{0}/{1}'>", WebUtility.GetConfig("DTree.SignalSet"), drw["SIGNAL"]);


                    e.Row.Cells.FromKey("SIGNAL").Style.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Style.BackColor = System.Drawing.Color.White;
                    e.Row.Style.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    e.Row.Cells.FromKey("SIGNAL").Text = e.Row.Cells.FromKey("SIGNAL_NAME").Text;
                }

                if (e.Row.Cells.FromKey("POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("POINT").Value = double.Parse(e.Row.Cells.FromKey("POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }

                if (e.Row.Cells.FromKey("AC_POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("AC_POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("AC_POINT").Value = double.Parse(e.Row.Cells.FromKey("AC_POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }

                if (e.Row.Cells.FromKey("ORI_POINT").Value != null)
                {
                    if (e.Row.Cells.FromKey("ORI_POINT").Value.ToString() != "-")
                    {
                        e.Row.Cells.FromKey("ORI_POINT").Value = double.Parse(e.Row.Cells.FromKey("ORI_POINT").Value.ToString()).ToString("#,##0.00");
                    }
                }
                
                if (this.IPrintType == "MONITOR")
                {
                    e.Row.Cells.FromKey("KPI_NAME").Text = string.Format(strURL
                                                                       , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value
                                                                       , e.Row.Cells.FromKey("KPI_REF_ID").Value
                                                                       , e.Row.Cells.FromKey("YMD").Value
                                                                       , e.Row.Cells.FromKey("KPI_NAME").Value);
                }

                e.Row.Expand(false);
            }
            else
            {
                e.Row.Style.ForeColor = System.Drawing.Color.DarkBlue;
                e.Row.Style.Font.Bold = true;
                e.Row.Height = Unit.Pixel(20);
                e.Row.Style.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Row.Expand(false);
            }
        }
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "2")
        {
            this.SetGraph();
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        Dac_EmpComDeptDetails objDept = new Dac_EmpComDeptDetails();
        this.IEstDeptID = objDept.GetTopEstDeptPerEesterm(this.IEstTermRefID, gUserInfo.Emp_Ref_ID);

        WebCommon.FillEstTree(trvEstDept
                            , this.IEstTermRefID
                            , gUserInfo.Emp_Ref_ID
                            , this.IEstDeptID);

        trvEstDept.ExpandAll();

        if (trvEstDept.Nodes.Count > 0 && this.IEstDeptID > 0 && this.IEstTermRefID > 0)
        {
            this.SetParameter();

            if (!this.HaveReadRight())
            {
                ltrScript.Text = JSHelper.GetAlertScript("조회할 권한이 없습니다.", false);
                return;
            }

            this.SetDeptMapInfo();
            this.SetDeptScoreCard();
        }
        else if (trvEstDept.Nodes.Count > 0 && this.IEstDeptID < 1 && this.IEstTermRefID < 1)
        {
            trvEstDept.Nodes[0].Select();
            this.IEstDeptID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
            this.SetParameter();

            if (!this.HaveReadRight())
            {
                return;
            }

            this.SetDeptMapInfo();
            this.SetDeptScoreCard();
        }
        else
        {
            lblDeptName.Text = "";
            lblTotalScore.Text = "";
            lblDeptVision.Text = "";
            ugrdScoreCard.Clear();
        }
    }
    
    protected void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectAllObject();
    }
    
    protected void ddlSumType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectAllObject();
    }
    
    protected void ddlMapLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectAllObject();
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFormGrid();
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text ;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가년월 : " + ddlMonthInfo.SelectedItem.Text ;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "평가조직 : " + lblDeptName.Text;
        e.CurrentWorksheet.Rows[3].Cells[0].Value = "평가점수 : " + lblTotalScore.Text;
        e.CurrentWorksheet.Rows[4].Cells[0].Value = "조직비젼 : " + lblDeptVision.Text;
        e.CurrentWorksheet.Rows[5].Cells[0].Value = "BSC Champion : " + lblBSCChampion.Text;
        
        for (int i = 0; i < 6; i++)
        {
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Navy;
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Height = 250;
            e.CurrentWorksheet.Rows[i].Height = 400;
        }
    }

    protected void ugrdEEP_InitializeRow(object sender, ExcelExportInitializeRowEventArgs e)
    {
        // Add extra styling to particular rows in the document
        //if ((string)e.Row.Cells.FromKey("Country").Value == "UK")
        //{
        //    // highlight rows where the customer is from the UK
        //    e.Row.Style.BackColor = System.Drawing.Color.Pink;
        //}
    }

    protected void chkApplyExtScore_CheckedChanged(object sender, EventArgs e)
    {
        this.SelectAllObject();
    }

    #endregion

    protected void rdoGoalTong_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectAllObject();
    }
}
