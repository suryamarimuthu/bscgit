using System;
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

public partial class Dashboard_NHIT_Project_TablePop : AppPageBase
    //public partial class Dashboard_NHIT_Main : Page
{
    public string CR_YEAR       = "0000";
    public string CR_MONTH      = "00";
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

    public string ICR_YEAR
    {
        get
        {
            if (ViewState["CR_YEAR"] == null)
            {
                ViewState["CR_YEAR"] = GetRequest("CR_YEAR", "-1");
            }

            return (string)ViewState["CR_YEAR"];
        }
        set
        {
            ViewState["CR_YEAR"] = value;
        }
    }

    public string ICR_MONTH
    {
        get
        {
            if (ViewState["CR_MONTH"] == null)
            {
                ViewState["CR_MONTH"] = GetRequest("CR_MONTH", "-1");
            }

            return (string)ViewState["CR_MONTH"];
        }
        set
        {
            ViewState["CR_MONTH"] = value;
        }
    }

    public string GRP_ONE_C_CODE
    {
        get
        {
            if (ViewState["GRP_ONE_C_CODE"] == null)
            {
                ViewState["GRP_ONE_C_CODE"] = GetRequest("GRP_ONE_C_CODE", "");
            }

            return (string)ViewState["GRP_ONE_C_CODE"];
        }
        set
        {
            ViewState["GRP_ONE_C_CODE"] = value;
        }
    }

    public string GRP_ONE_B_CODE
    {
        get
        {
            if (ViewState["GRP_ONE_B_CODE"] == null)
            {
                ViewState["GRP_ONE_B_CODE"] = GetRequest("GRP_ONE_B_CODE", "");
            }

            return (string)ViewState["GRP_ONE_B_CODE"];
        }
        set
        {
            ViewState["GRP_ONE_B_CODE"] = value;
        }
    }

    public string GRP_ONE_D_CODE
    {
        get
        {
            if (ViewState["GRP_ONE_D_CODE"] == null)
            {
                ViewState["GRP_ONE_D_CODE"] = GetRequest("GRP_ONE_D_CODE", "");
            }

            return (string)ViewState["GRP_ONE_D_CODE"];
        }
        set
        {
            ViewState["GRP_ONE_D_CODE"] = value;
        }
    }


    public enum GRP_ONE_ID
    {
        A // 전사
      , B // 고객사
        , C // 사업유형
        , D // 본부
    }

    public enum GRP_TWO_ID : int
    {
        GTO_10 = 10 // 전사
      ,
        GTO_20 = 20// 중앙회
      ,
        GTO_30 = 30// 계열사
      , GTO_40 = 40// 대외
        , GTO_50 = 50// SI
        , GTO_60 = 60// SM
        , GTO_70 = 70// 상품
        , GTO_80 = 80// 사업지원
        , GTO_90 = 90// 금융사업
        , GTO_100 = 100// 경제사업
        , GTO_110 = 110// 카드사업
        , GTO_120 = 120// 보험부문
        , GTO_130 = 130// 전략사업
    }

    public enum GRP_THREE_ID
    {
        ME // 매출
      ,
        YG // 영업이익
        ,
        DN // 당기순이익
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DoInitializing();

         
            ddlYear.SelectedValue = ICR_YEAR;
            ddlMonth.SelectedValue = ICR_MONTH;

            CR_YEAR = ddlYear.SelectedValue;
            //CR_MONTH = ddlMonth.SelectedValue;

            iBtnSearch_Click(null, null);
        }
        else
        { 
           
        }

        CR_YEAR = ddlYear.SelectedValue;
        //CR_MONTH = ddlMonth.SelectedValue;
    }

    #region 페이지 초기화 함수

    private void DoInitializing()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtYear = bizNHIT.GetYear_DB();

        if (dtYear.Rows.Count > 0)
        {
            ddlYear.DataSource = dtYear;
            ddlYear.DataTextField = "CR_YEAR_NAME";
            ddlYear.DataValueField = "CR_YEAR";
            ddlYear.DataBind();
        }
        else
        {
            ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
        }

        DataTable dtMonth = bizNHIT.GetMonth_DB();

        if (dtMonth.Rows.Count > 0)
        {
            ddlMonth.DataSource = dtMonth;
            ddlMonth.DataTextField = "CR_MONTH_NAME";
            ddlMonth.DataValueField = "CR_MONTH";
            ddlMonth.DataBind();
        }
        else
        {
            ddlMonth.Items.Add(new ListItem(DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString()));
        }
    }

    

    private void DoBinding_Project()
    {
        UltraWebGrid1.Clear();

        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetProjectDetail(CR_YEAR, GRP_ONE_B_CODE, GRP_ONE_C_CODE, GRP_ONE_D_CODE);

        UltraWebGrid1.DataSource = dtNHIT;
        UltraWebGrid1.DataBind();

        string title = "{0} 프로젝트 현황";
        string gubun = string.Empty;

        if (GRP_ONE_B_CODE.Length > 0)
        {
            gubun = "고객사 별";
        }

        if (GRP_ONE_C_CODE.Length > 0)
        {
            gubun = "사업유형 별";
        }

        if (GRP_ONE_D_CODE.Length > 0)
        {
            gubun = "본부 별";
        }

        if (dtNHIT.Rows.Count > 0)
        {
            lblTitle.Text = string.Format(title, gubun);
            lblProjectTotal.Text = string.Format("(Total : {0})", dtNHIT.Rows.Count);
        }
    }

    private void DoBinding_Emp(string cr_year, string cr_month, string project_name)
    {
       
    }


    #endregion

    #region
    private void SetInitiativeInfo()
    { 
        //MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        //txtINITIATIVE_DO.Text       = objBSC.Iinitiative_do;
        //txtINITIATIVE_PLAN.Text     = objBSC.Iinitiative_plan;
        //hdfInitiativeDocNo.Value    = objBSC.Ido_file;
        //iBtnInitiativeFile.Visible  = (objBSC.Ido_file == "") ? false : true;

        //txtINITIATIVE_PLAN.ReadOnly = true;
        //txtINITIATIVE_DO.ReadOnly = true;
    }

    private void SetResultGrid()
    {
        //this.IYMD = "201203";

        //Biz_Bsc_Kpi_Result objBSC   = new Biz_Bsc_Kpi_Result(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        //DataSet rDs                 = objBSC.GetResultAnalysisList(this.IEstTermRefID, this.IKpiRefID, this.IYMD, this.IGoalTong_YN);

        //txtPlan_Month.Text          = objBSC.Imeasure_text_ms;
        //txtPlan_Sum.Text            = objBSC.Imeasure_text_ts;
        //txtReason_Month.Text        = objBSC.Icause_text_ms;
        //txtReason_Sum.Text          = objBSC.Icause_text_ts;

        //if (objBSC.Icause_file_id == "")
        //{
        //    iBtnCauseFileID.Visible = false;
        //}
        //else
        //{
        //    iBtnCauseFileID.Visible = true;
        //    hdfCauseDocNo.Value     = objBSC.Icause_file_id;
        //}



        //if (objBSC.Imeasure_file_id == "")
        //{
        //    iBtnMeasureFileID.Visible = false;
        //}
        //else
        //{
        //    iBtnMeasureFileID.Visible = false;
        //    hdfMeasureDocNo.Value = objBSC.Imeasure_file_id;
        //}

        //try
        //{
        //    this.SetResutlGraph(rDs);
        //}
        //catch (Exception e)
        //{
        //    string msg = e.Message;
        //}
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
        //Biz_Bsc_Communication_List objBSC = new Biz_Bsc_Communication_List();
        //this.ugrdCommunication.Clear();
        //this.ugrdCommunication.DataSource = objBSC.GetAllListPerKpiUser(gUserInfo.Emp_Ref_ID, this.IEstTermRefID, this.IYMD, this.IKpiRefID, false);
        //this.ugrdCommunication.DataBind();
    }

    /// <summary>
    /// 관련프로젝트
    /// </summary>
    private void SetProjectList()
    {
        //MicroBSC.PRJ.Biz.Biz_Bsc_Kpi_Prj objBSC = new MicroBSC.PRJ.Biz.Biz_Bsc_Kpi_Prj();
        //DataSet rDs = objBSC.GetKpiCodePrjectList(this.IEstTermRefID, this.IKpiRefID);

        //ugrdPrjList.Clear();
        //ugrdPrjList.DataSource = rDs;
        //ugrdPrjList.DataBind();
    }

    /// <summary>
    /// 지표기본정보 (사업이 있는지 여부)
    /// </summary>
    private void SetKPIBaseInfo()
    {
        ////-------------------- KPI Status Setting
        //Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        //DataSet rDs = objBSC.GetKpiStatus(this.IEstTermRefID, this.IKpiRefID, gUserInfo.Emp_Ref_ID);

        //Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(objBSC.Ikpi_pool_ref_id);
        //if (objPool.Ibasis_use_yn == "EQL")
        //{
        //    iBtnEstOpinion.Visible = true;
        //}
        //else
        //{
        //    iBtnEstOpinion.Visible = false;
        //}

        //if (rDs.Tables[0].Rows.Count > 0)
        //{
        //    this.IHaveInitive_YN = rDs.Tables[0].Rows[0]["HAVE_INITIATIVE_YN"].ToString();

        //    if (this.IHaveInitive_YN == "Y")
        //    {
        //        pnlinitiative.Visible = false;
        //        pnlPrj.Visible        = true;
        //        this.SetProjectList();
        //    }
        //    else
        //    { 
        //        pnlinitiative.Visible = true;
        //        pnlPrj.Visible        = false;
        //        this.SetInitiativeInfo();
        //        ugrdPrjList.Clear();
        //    }
        //}
    }

    /// <summary>
    /// 예측실적 그리드 조회
    /// </summary>
    private void SetExceptGrid()
    {
        //this.IYMD_NEXT  = "-";

        //Biz_Bsc_Kpi_Term objTrm = new Biz_Bsc_Kpi_Term();
        //this.IYMD_NEXT = objTrm.GetNavigateMonth(this.IEstTermRefID, this.IKpiRefID, this.IYMD, gNavigator.NEXT);

        //Biz_Bsc_Kpi_Result_Expect objNextExp = new Biz_Bsc_Kpi_Result_Expect(this.IEstTermRefID, this.IKpiRefID, this.IYMD_NEXT);
        //lblExtResult_MS.Text           = objNextExp.IResult_Ms.ToString();
        //lblExtResult_TS.Text           = objNextExp.IResult_Ts.ToString();
        //lblEXPECT_REASON_MS.Text       = objNextExp.IExpect_Reason_Ms;
        //lblEXPECT_REASON_TS.Text       = objNextExp.IExpect_Reason_Ts;
        //lbltxtRESULT_DIFF_CAUSE.Text   = objNextExp.IResult_Diff_Cause;
        //hdfExpectReasonFileId.Value    = objNextExp.IExpect_Reason_File_Id;        
        //hdfResultDiffFileId.Value      = objNextExp.IResult_Diff_File_Id;

        //iBtnEXPECT_REASON_FILE_ID.Visible = (objNextExp.IExpect_Reason_File_Id == "") ? false : true;
        //iBtnRESULT_DIFF_FILE_ID.Visible   = (objNextExp.IResult_Diff_File_Id == "")   ? false : true;

        //lblNextYmd_Ms.Text = this.IYMD_NEXT;
        //lblNextYmd_Ts.Text = this.IYMD_NEXT;

        //DataSet rDs = objNextExp.GetResultExpect(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        //grvResultExpt.DataSource = rDs.Tables[0].DefaultView;
        //grvResultExpt.DataBind();
    }

    #endregion

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding_Project();

    }
    protected void ugrdInPower_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {

        if (e.SelectedRows.Count > 0)
        {
            string cr_year = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("CR_YEAR").Value);
            string cr_month = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("CR_MONTH").Value);
            string project_name = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("PROJECT_NAME").Value);

            DoBinding_Emp(cr_year, cr_month, project_name);
        }

    }

    protected void ugrdInPower_InitializeLayout(object sender, LayoutEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "당월 누적";
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 3;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
    }

    protected void ugrdETC_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraWebGrid grid = (UltraWebGrid)sender;

        grid.Columns[5].Hidden = true;
        grid.Columns[6].Hidden = true;
        grid.Columns[7].Hidden = true;
        grid.Columns[8].Hidden = true;

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "매출(당월)";
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "당기순이익";
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 4;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ////// 단일 헤더 합침
        ////ch = e.Layout.Bands[0].Columns.FromKey("MM").Header;
        ////ch.RowLayoutColumnInfo.SpanY = 2;
        ////ch.RowLayoutColumnInfo.OriginY = 0;

        //int iIndex = 0;
        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        //foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        //{
        //    c.Header.RowLayoutColumnInfo.OriginY = 1;
        //    c.Header.RowLayoutColumnInfo.OriginX = iIndex;
        //    iIndex++;
        //}

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "월";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanX = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "[ 당 월 ]";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 1;
        //ch.RowLayoutColumnInfo.SpanX = 6;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 7;
        //ch.RowLayoutColumnInfo.SpanX   = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //ch.Style.BackColor = Color.White;
        //ch.Style.BorderColor = Color.White;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "[ 누 적 ]";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 8;
        //ch.RowLayoutColumnInfo.SpanX = 7;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        

        //// 단일 헤더 합침
        //ch = e.Layout.Bands[0].Columns.FromKey("MM").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        //e.Layout.Bands[0].Columns.FromKey("SPLITER").Header.Style.BackColor = Color.White;

        //// 단일 헤더 합침
        ////ch = e.Layout.Bands[0].Columns.FromKey("SPLITER").Header;
        ////ch.RowLayoutColumnInfo.SpanY = 2;
        ////ch.RowLayoutColumnInfo.OriginY = 0;
    }
    
    protected void ugrdKpiResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        
    }

    protected void ugrdCommunication_InitializeRow(object sender, RowEventArgs e)
    { 
        //int intSpace     = (e.Row.Cells.FromKey("TREE_LEVEL").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("TREE_LEVEL").Value.ToString()) : 0;
        //string strReIcon = "<img alt='' src='../images/icon/board_re.gif' style=\"vertical-align:middle;\" />";
        //string strTitle  = (e.Row.Cells.FromKey("TITLE").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("TITLE").Value) : "";
        //string strReadYN = (e.Row.Cells.FromKey("READ_YN").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("READ_YN").Value) : "X";
        //string strEmpty  = "";

        //if (intSpace > 1)
        //{
        //    e.Row.Cells.FromKey("TITLE").Text = strEmpty.PadRight((intSpace-1)*2, ' ') + strReIcon + strTitle;
        //}

        //string strOkIcon = "<img alt='미확인' src='../images/icon/gr_po01_b.gif' style=\"vertical-align:middle;\" />";
        //if (strReadYN == "N")
        //{
        //    e.Row.Cells.FromKey("NUM_TEXT").Text = strOkIcon;
        //}
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        //this.SetResultGrid();
        //this.SetInitiativeInfo();
        //this.SetCommunicationGrid();
    }

    protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        //this.ExcelDownLoad();
    }

    #region ================================= [ 엑셀다운로드  ] ============================
    /// <summary>
    /// 엑셀 다운로드
    /// </summary>
    private void ExcelDownLoad()
    {
        //string strCurDate = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');

        //ugrdEEP.ExportMode = ExportMode.Download;
        //ugrdEEP.DownloadName = "KpiWorkDetail" + strCurDate + ".xls";

        //this.AddWorkSheet(); // Sheet추가
    }

    /// <summary>
    /// Tab페이지별 엑셀Sheet 추가
    /// </summary>
    private void AddWorkSheet()
    {
        workBook = new Workbook();

        //Sheet추가 
        workBook.Worksheets.Add("KPI 실적상세");

        #region ==> KPI 실적상세
        workBook.ActiveWorksheet = workBook.Worksheets[0];
        //ugrdEEP.ExcelStartRow = 7;
        //ugrdKpiResultStatus.Columns[3].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[5].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[12].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[14].Hidden = true;  //이미지컬럼 숨김

        //ugrdKpiResultStatus.Columns[4].Hidden =false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[6].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[13].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[15].Hidden = false;  //이미지컬럼 숨김


        //ugrdEEP.Export(ugrdKpiResultStatus, workBook.ActiveWorksheet);

        //ugrdKpiResultStatus.Columns[3].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[5].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[12].Hidden = false;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[14].Hidden = false;  //이미지컬럼 숨김

        //ugrdKpiResultStatus.Columns[4].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[6].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[13].Hidden = true;  //이미지컬럼 숨김
        //ugrdKpiResultStatus.Columns[15].Hidden = true;  //이미지컬럼 숨김
        #endregion
    }

    /// <summary>
    /// Sheet별 공통데이타
    /// </summary>
    private void CommonDataPrint()
    {
        //foreach (Worksheet ws in workBook.Worksheets)
        //{
        //    ws.Rows[0].Cells[0].Value = "KPI 코드 : " + lblKpiCode.Text.Trim();
        //    ws.Rows[1].Cells[0].Value = "KPI 명:  " + lblKpiName.Text.Trim();
        //    ws.Rows[2].Cells[0].Value = "단위 : " + lblUnitName.Text.Trim();
        //    ws.Rows[3].Cells[0].Value = "누적형태: " + lblPNUType.Text.Trim();
        //    ws.Rows[4].Cells[0].Value = "계획월: " + ddlMonthInfo.SelectedItem.Text.Trim();


        //    ws.Rows[21].Cells[0].Value = "Initiative 추진계획";
        //    ws.Rows[22].Cells[1].Value = txtINITIATIVE_PLAN.Text.Trim();

        //    ws.Rows[24].Cells[0].Value = "Initiative 추진내용";
        //    ws.Rows[25].Cells[1].Value = txtINITIATIVE_DO.Text.Trim();


        //    ws.Rows[27].Cells[0].Value = "원인및 대책";
        //    ws.Rows[28].Cells[0].Value = "원인분석 당월: ";
        //    ws.Rows[28].Cells[1].Value = txtReason_Month.Text.Trim();
        //    ws.Rows[29].Cells[0].Value = "원인분석 누적: ";
        //    ws.Rows[29].Cells[1].Value = txtReason_Sum.Text.Trim();

        //    ws.Rows[30].Cells[0].Value = "대책검토 당월: ";
        //    ws.Rows[30].Cells[1].Value = txtReason_Month.Text.Trim();
        //    ws.Rows[31].Cells[0].Value = "대책검토 누적: ";
        //    ws.Rows[31].Cells[1].Value = txtReason_Sum.Text.Trim();

        //    this.SetCoulumStlye(ws, 0, 0);
        //    this.SetCoulumStlye(ws, 0, 5);
        //    this.SetCoulumStlye(ws, 1, 0);
        //    this.SetCoulumStlye(ws, 1, 5);
        //    this.SetCoulumStlye(ws, 2, 0);
        //    this.SetCoulumStlye(ws, 2, 5);
        //    this.SetCoulumStlye(ws, 3, 0);
        //    this.SetCoulumStlye(ws, 3, 5);
        //    this.SetCoulumStlye(ws, 4, 0);
        //    this.SetCoulumStlye(ws, 4, 5);


        //    this.SetCoulumStlye(ws, 21, 0);
        //    this.SetCoulumStlye(ws, 21, 5);
        //    this.SetCoulumStlye(ws, 22, 0);
        //    this.SetCoulumStlye(ws, 22, 5);
        //    this.SetCoulumStlye(ws, 24, 0);
        //    this.SetCoulumStlye(ws, 24, 5);
        //    this.SetCoulumStlye(ws, 25, 0);
        //    this.SetCoulumStlye(ws, 25, 5);
        //    this.SetCoulumStlye(ws, 27, 0);
        //    this.SetCoulumStlye(ws, 27, 5);

        //    this.SetCoulumStlye(ws, 28, 0);
        //    this.SetCoulumStlye(ws, 28, 5);
        //    this.SetCoulumStlye(ws, 29, 0);
        //    this.SetCoulumStlye(ws, 29, 5);
        //    this.SetCoulumStlye(ws, 30, 0);
        //    this.SetCoulumStlye(ws, 30, 5);
        //    this.SetCoulumStlye(ws, 31, 0);
        //    this.SetCoulumStlye(ws, 31, 5);

        //}
    }

    /// <summary>
    /// 엑셀Cell별 스타일설정
    /// </summary>
    /// <param name="ws">workSheet</param>
    /// <param name="row">rowIndex</param>
    /// <param name="cell">cellIndex</param>
    private void SetCoulumStlye(Worksheet ws, int row, int cell)
    {
        ws.Rows[row].Cells[cell].CellFormat.Font.Height = 250;
        ws.Rows[row].Height = 400;
        ws.Columns[cell].Width = 18 * 256;
        ws.Rows[row].Expanded = true;
    }

    protected void ugrdEEP_BeginExport(object sender, Infragistics.WebUI.UltraWebGrid.ExcelExport.BeginExportEventArgs e)
    {
        this.CommonDataPrint();
    }

    protected void ugrdEEP_CellExporting(object sender, Infragistics.WebUI.UltraWebGrid.ExcelExport.CellExportingEventArgs e)
    {
        this.SetCoulumStlye(e.CurrentWorksheet, e.CurrentRowIndex, e.CurrentColumnIndex);
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        e.Row.Cells.FromKey("NO").Value = e.Row.Index + 1;

        //System.Drawing.Color color = System.Drawing.Color.YellowGreen;

        //if (GRP_ONE_B_CODE.Length > 0)
        //{
        //    e.Row.Cells.FromKey("GRP_ONE_B_NAME").Style.BackColor = color;
        //}

        //if (GRP_ONE_C_CODE.Length > 0)
        //{
        //    e.Row.Cells.FromKey("GRP_ONE_C_NAME").Style.BackColor = color;
        //}

        //if (GRP_ONE_D_CODE.Length > 0)
        //{
        //    e.Row.Cells.FromKey("GRP_ONE_D_NAME").Style.BackColor = color;
        //}

        if (GRP_ONE_B_CODE.Length > 0)
        {
            e.Row.Cells.FromKey("GRP_ONE_B_NAME").Style.Font.Bold = true;
        }

        if (GRP_ONE_C_CODE.Length > 0)
        {
            e.Row.Cells.FromKey("GRP_ONE_C_NAME").Style.Font.Bold = true;
        }

        if (GRP_ONE_D_CODE.Length > 0)
        {
            e.Row.Cells.FromKey("GRP_ONE_D_NAME").Style.Font.Bold = true;
        }
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

        e.Row.Cells[1].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[1].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[2].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[2].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[3].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[3].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[4].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[4].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[5].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[5].Text), "#,###,###,###,###,###,###,##0.00");
        e.Row.Cells[6].Text = GetStringDigit(DataTypeUtility.GetString(e.Row.Cells[6].Text), "#,###,###,###,###,###,###,##0.00");
    }

    #endregion
}
