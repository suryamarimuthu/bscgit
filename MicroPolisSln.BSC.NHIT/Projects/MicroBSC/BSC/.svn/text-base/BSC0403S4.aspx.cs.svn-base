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

using Dundas.Charting.WebControl;
using MicroCharts;
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

public partial class BSC_BSC0403S4 : AppPageBase
{
    #region 변수선언
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("ITYPE", "");
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

    public string IGubun
    {
        get
        {
            if (ViewState["GUBUN"] == null)
            {
                ViewState["GUBUN"] = GetRequest("GUBUN", "L");
            }

            return (string)ViewState["GUBUN"];
        }
        set
        {
            ViewState["GUBUN"] = value;
        }
    }

    public bool IExtKpiYN
    {
        get
        {
            if (ViewState["EXT_KPI_YN"] == null)
            {
                ViewState["EXT_KPI_YN"] = (GetRequest("EXT_KPI_YN", "Y") == "Y") ? true : false;
            }

            return (bool)ViewState["EXT_KPI_YN"];
        }
        set
        {
            ViewState["EXT_KPI_YN"] = value;
        }
    }

    public int intRowNum = 0;
    public int cntView   = 0;
    public string oldViewID = "";
    public string newViewID = "";
    Workbook workBook = null; // smjjang

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        { 
            
        }

        if (User.IsInRole(ROLE_ADMIN))
        {
            ddlEstTermInfo.Enabled = true;
            //ddlMonthInfo.Enabled   = true;
            ddlEstDept.Enabled     = true;
        }
        else
        { 
            ddlEstTermInfo.Enabled = false;
            //ddlMonthInfo.Enabled   = false;
            ddlEstDept.Enabled     = false;
        }
    }

    protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        
        this.SetKpiStatusGrid();
        this.SetEstDeptLoadMap();
        this.SetDeptScoreCard();
        this.ExcelDownLoad();
    }
    #endregion

    #region 내부함수
    private void NotPostBackSetting()
    {
        this.SetInitForm();
        this.SetDeptScoreCard();

        this.SetEstDeptLoadMap();
        this.SetKpiStatusGrid();

        this.SetFormObject(true);
    }

    private void SetFormObject(bool isLoadMap)
    {
        if (isLoadMap)
        {
            plnDeptLoadMap.Visible = true;
            plnScoreCard.Visible   = false;
            iBtnLoadMap.Visible    = false;
            iBtnScoreCard.Visible  = true;
            ddlSumType.Visible     = false;
            ddlEstDept.Visible     = true;            
        }
        else
        { 
            plnDeptLoadMap.Visible = false;
            plnScoreCard.Visible   = true;
            iBtnLoadMap.Visible    = true;
            iBtnScoreCard.Visible  = false;
            ddlSumType.Visible     = true;
            ddlEstDept.Visible     = false;            
        }        
    }

    private void SetInitForm()
    { 
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        ddlEstTermInfo.SelectedValue = this.IEstTermRefID.ToString();

        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        PageUtility.FindByValueDropDownList(ddlMonthInfo, this.IYmd);

        WebCommon.SetSumTypeDropDownList(ddlSumType, false);
        PageUtility.FindByValueDropDownList(ddlSumType, this.ISumType);

        if (this.IEstTermRefID > 0)
        {
            PageUtility.FindByValueDropDownList(ddlEstTermInfo, this.IEstTermRefID.ToString());
        }

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);

        WebCommon.SetEstDeptDropDownList(ddlEstDept, this.IEstTermRefID, false, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlEstDept, this.IEstDeptID);

        WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, this.IEstTermRefID);
        chkApplyExtScore.Checked = this.IExtKpiYN;

        chkApplyExtScore.Enabled = false;
    }

    private void SetParam()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IEstDeptID    = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.IExtKpiYN     = this.chkApplyExtScore.Checked;
        this.ISumType      = PageUtility.GetByValueDropDownList(ddlSumType);
    }

    private void SetMapinfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMapinfo = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID, this.IEstDeptID, this.IYmd);
        lblDeptVision.Text  = objMapinfo.Idept_vision;
        lblChampName.Text   = objMapinfo.Ibscchampion_name;
        lblEstDeptName.Text = objMapinfo.Iest_dept_name;
    }
    private void SetKpiStatusGrid()
    {
        this.SetMapinfo();

        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();

        DataSet dsScore = objBSC.GetEstDeptTotalScore
                                 (
                                  this.IEstTermRefID
                                , this.IYmd
                                , this.ISumType
                                , this.IEstDeptID
                                , chkApplyExtScore.Checked
                                 );

        if (dsScore.Tables[0].Rows.Count > 0)
        {
            string strs = dsScore.Tables[0].Rows[0]["POINT"].ToString();
        }


        DataSet dsKpi = objBSC.GetEstDeptKpiScoreList
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID
                                                 , chkApplyExtScore.Checked);
        ugrdKpiStatus.Clear();
        ugrdKpiStatus.DataSource = dsKpi;
        ugrdKpiStatus.DataBind();
    }

    private void SetEstDeptLoadMap()
    {
        this.SetMapinfo();

        MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap objMap = new MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap();
        DataSet rDs = objMap.GetLoadMapPerEstDept(this.IEstTermRefID, this.IEstDeptID);

        ugrdLoadMapList.Clear();
        ugrdLoadMapList.DataSource = rDs;
        ugrdLoadMapList.DataBind();
    }

    private void SetDeptScoreCard()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        ultraLegend.Clear();
        ultraLegend.DataSource = objBSC.GetEstDeptTotalScoreForMap
                                        ( this.IEstTermRefID
                                        , this.IYmd
                                        , this.ISumType
                                        , this.IEstDeptID
                                        , this.IExtKpiYN
                                        );
        ultraLegend.DataBind();
    }

    protected void ugrdKpiStatus_InitializeRow(object sender, RowEventArgs e)
    {
        string strSignal = e.Row.Cells.FromKey("SIGNAL").Value.ToString();
        e.Row.Cells.FromKey("SIGNAL").Value = "<img class='KPI' border='0' src='../images/"+ strSignal +"'>";

        string strPoints = (e.Row.Cells.FromKey("AC_POINT").Value == null) ? "-" : e.Row.Cells.FromKey("AC_POINT").Value.ToString();
        if (strPoints != "-" && strPoints.IndexOf('.', 0) > -1)
        {
            strPoints = strPoints.Substring(0, strPoints.IndexOf('.', 0) + 2);
        }

        e.Row.Cells.FromKey("AC_POINT").Value = strPoints;
        //e.Row.Style.BackColor = ColorTranslator.FromHtml("#DCE1E5");

        

        newViewID = e.Row.Cells.FromKey("VIEW_NAME").Value.ToString();
        if (newViewID != oldViewID)
        {
            cntView += 1;
            if ((cntView % 2) == 1)
            {
                e.Row.Style.BackColor = ColorTranslator.FromHtml("#EDF0F5");
                oldViewID = newViewID;
            }
            else
            {
                e.Row.Style.BackColor = ColorTranslator.FromHtml("#DCE1E5");
                oldViewID = newViewID;
            }
        }
        else
        { 
            if ((cntView % 2) == 1)
            {
                e.Row.Style.BackColor = ColorTranslator.FromHtml("#EDF0F5");
                oldViewID = newViewID;
            }
            else
            {
                e.Row.Style.BackColor = ColorTranslator.FromHtml("#DCE1E5");
                oldViewID = newViewID;
            }
        }
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.SetKpiStatusGrid();
    }

    protected void btnLoadMap_Click(object sender, EventArgs e)
    {
        this.SetFormObject(true);
    }

    protected void btnScoreCard_Click(object sender, EventArgs e)
    {
        this.SetFormObject(false);
    }

    protected void iBtnGoDeptScore_Click(object sender, EventArgs e)
    {
        this.SetParam();
        string sExt = (this.IExtKpiYN) ? "Y" : "N";
        String strUrl = "~/usr/usr1005.aspx?ESTTERM_REF_ID={0}&YMD={1}&EXT_KPI_YN={2}";
        Response.Redirect(String.Format(strUrl, this.IEstTermRefID.ToString(), this.IYmd, sExt));
        return;
    }

    protected void ultraLegend_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        intRowNum += 1;
        if (intRowNum == 1)
        {
            e.Row.Cells.FromKey("VIEW_NAME").Value           = "조직점수";
            e.Row.Style.Font.Bold                            = true;

            e.Row.Cells.FromKey("VIEW_NAME").Style.ForeColor = System.Drawing.Color.Chocolate;
            e.Row.Cells.FromKey("SCORE").Style.ForeColor     = System.Drawing.Color.Chocolate;
            e.Row.Cells.FromKey("WEIGHT").Style.ForeColor    = System.Drawing.Color.Chocolate;
            
            e.Row.Cells.FromKey("VIEW_NAME").Style.Font.Size = FontUnit.Point(11);
            e.Row.Cells.FromKey("SCORE").Style.Font.Size     = FontUnit.Point(11);
            e.Row.Cells.FromKey("WEIGHT").Style.Font.Size    = FontUnit.Point(11);
            e.Row.Height = Unit.Pixel(20);
            //e.Row.Style.BackColor = Color.Aqua;
        }
        else
        {
            e.Row.Cells.FromKey("VIEW_NAME").Style.ForeColor = System.Drawing.Color.Navy;
            e.Row.Cells.FromKey("SCORE").Style.ForeColor     = System.Drawing.Color.Navy;
            e.Row.Cells.FromKey("WEIGHT").Style.ForeColor    = System.Drawing.Color.Navy;

            e.Row.Style.Font.Bold                            = false;
            e.Row.Cells.FromKey("VIEW_NAME").Value          = "" + e.Row.Cells.FromKey("VIEW_NAME").Value;
        }

        e.Row.Cells.FromKey("DASH").Value                   = "/";
    }

    protected void ugrdLoadMapList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn tmcPL = (TemplatedColumn)e.Row.Band.Columns.FromKey("MONTHLY_PLAN");
        TemplatedColumn tmcDO = (TemplatedColumn)e.Row.Band.Columns.FromKey("DETAILS");
        TemplatedColumn tmcDE = (TemplatedColumn)e.Row.Band.Columns.FromKey("ETC_CONTENTS");

        TextBox txtPL = (TextBox)((CellItem)tmcPL.CellItems[e.Row.BandIndex]).FindControl("txtMONTHLY_PLAN");
        TextBox txtDO = (TextBox)((CellItem)tmcDO.CellItems[e.Row.BandIndex]).FindControl("txtDETAILS");
        TextBox txtDE = (TextBox)((CellItem)tmcDE.CellItems[e.Row.BandIndex]).FindControl("txtETC_CONTENTS");

        txtPL.Text = (e.Row.Cells.FromKey("MONTHLY_PLAN").Value == null)  ? "" : Convert.ToString(e.Row.Cells.FromKey("MONTHLY_PLAN").Value.ToString());
        txtDO.Text = (e.Row.Cells.FromKey("DETAILS").Value == null)       ? "" : Convert.ToString(e.Row.Cells.FromKey("DETAILS").Value.ToString());
        txtDE.Text = (e.Row.Cells.FromKey("ETC_CONTENTS").Value == null)  ? "" : Convert.ToString(e.Row.Cells.FromKey("ETC_CONTENTS").Value.ToString());

        txtPL.Font.Size = FontUnit.Medium;
        txtDO.Font.Size = FontUnit.Medium;
        txtDE.Font.Size = FontUnit.Medium;

        txtPL.Font.Name = "HY울릉도M";
        txtDO.Font.Name = "HY울릉도M";
        txtDE.Font.Name = "HY울릉도M";

        txtPL.Style.Add("overflow", "auto");
        txtDO.Style.Add("overflow", "auto");
        txtDE.Style.Add("overflow", "auto");

        txtPL.Style.Add("padding-left", "10px");
        txtDO.Style.Add("padding-left", "10px");

        txtPL.Style.Add("padding-top", "5px");
        txtDO.Style.Add("padding-top", "5px");

        int intYmd = (e.Row.Cells.FromKey("YMD").Value == null)  ? 0 : Convert.ToInt32(e.Row.Cells.FromKey("YMD").Value.ToString());

        if ((intYmd % 2) == 1)
        {
            e.Row.Style.BackColor = ColorTranslator.FromHtml("#EDF0F5");
            txtPL.Style.Add("background-color", "#EDF0F5");
            txtDO.Style.Add("background-color", "#EDF0F5");
        }
        else
        { 
            e.Row.Style.BackColor = ColorTranslator.FromHtml("#DCE1E5");
            txtPL.Style.Add("background-color", "#DCE1E5");
            txtDO.Style.Add("background-color", "#DCE1E5");
        }

        
        if (intYmd < Convert.ToInt32(this.IYmd)-1)
        {
            e.Row.Hidden = true;
        }
        else if (intYmd == Convert.ToInt32(this.IYmd)+1)
        { 
            //e.Row.Style.BackColor = ColorTranslator.FromHtml("#EDF0F5");
            //txtPL.Style.Add("background-color", "#EDF0F5");
            //txtDO.Style.Add("background-color", "#EDF0F5");
            e.Row.Style.BackColor = ColorTranslator.FromHtml("#9DC1CD");
            //txtPL.ForeColor = Color.Navy;
            //txtDO.ForeColor = Color.Navy;
            e.Row.Activate();
        }

        //string strCheck = e.Row.Cells.FromKey("CLOSE_YN").Value.ToString();
        //if (strCheck == "Y")
        //{
        //    txtPL.ReadOnly = true;
        //    txtDO.ReadOnly = true;
        //    txtDE.ReadOnly = true;

        //    txtPL.BackColor = Color.WhiteSmoke;
        //    txtDO.BackColor = Color.WhiteSmoke;
        //    txtDE.BackColor = Color.WhiteSmoke;
        //}
        //else
        //{ 
        //    txtPL.ReadOnly = (this.IsOpenTerm=="Y") ? false : true;
        //    txtDO.ReadOnly = false;
        //    txtDE.ReadOnly = false;

        //    txtPL.BackColor = (this.IsOpenTerm=="Y") ? Color.White : Color.WhiteSmoke;
        //    txtDO.BackColor = Color.White;
        //    txtDE.BackColor = Color.White;
        //}
    }
    #endregion

    #region ================================= [ 엑셀다운로드  ] ============================
    /// <summary>
    /// 엑셀 다운로드
    /// </summary>
    private void ExcelDownLoad()
    {
        string strCurDate = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');

        ugrdEEP.ExportMode = ExportMode.Download;
        ugrdEEP.DownloadName = "LoadMapDetail" + strCurDate + ".xls";

        this.AddWorkSheet(); // Sheet추가
    }

    /// <summary>
    /// Tab페이지별 엑셀Sheet 추가
    /// </summary>
    private void AddWorkSheet()
    {
        workBook = new Workbook();

        //Sheet추가 
        workBook.Worksheets.Add("상세현황");
        workBook.Worksheets.Add("로드맵");


        #region ==> 상세현황
        workBook.ActiveWorksheet = workBook.Worksheets[0];
        ugrdEEP.ExcelStartRow = 7;
        ugrdKpiStatus.Columns[13].Hidden = true;  //이미지컬럼 숨김
        ugrdEEP.Export(ugrdKpiStatus, workBook.ActiveWorksheet);
        ugrdKpiStatus.Columns[13].Hidden = false;
        #endregion

        #region ==> 로드맵
        workBook.ActiveWorksheet = workBook.Worksheets[1];
        ugrdEEP.ExcelStartRow = 7;
        ugrdEEP.Export(ugrdLoadMapList, workBook.ActiveWorksheet);

        #endregion


         #region ==> DeptScoreCard
        workBook.ActiveWorksheet = workBook.Worksheets[0];
        ugrdEEP.ExcelStartRow = 0;
        ugrdEEP.ExcelStartColumn = "E";
        ugrdEEP.Export(ultraLegend, workBook.ActiveWorksheet);

        workBook.ActiveWorksheet = workBook.Worksheets[1];
        ugrdEEP.ExcelStartRow = 0;
        ugrdEEP.ExcelStartColumn = "E";
        ugrdEEP.Export(ultraLegend, workBook.ActiveWorksheet);

        #endregion



        
    }

    /// <summary>
    /// Sheet별 공통데이타
    /// </summary>
    private void CommonDataPrint()
    {
        foreach (Worksheet ws in workBook.Worksheets)
        {
            ws.Rows[0].Cells[0].Value = "평 가 기 간: " + ddlEstTermInfo.SelectedItem.Text.Trim() + " / " + ddlMonthInfo.SelectedItem.Text.Trim();
            ws.Rows[1].Cells[0].Value = "평 가 조 직:  " + lblEstDeptName.Text.Trim();
            ws.Rows[2].Cells[0].Value = "BSC Champion: " + lblChampName.Text.Trim();
            ws.Rows[3].Cells[0].Value = "조 직 비 전: " + lblDeptVision.Text.Trim();

            this.SetCoulumStlye(ws, 0, 0);
            this.SetCoulumStlye(ws, 0, 5);
            this.SetCoulumStlye(ws, 1, 0);
            this.SetCoulumStlye(ws, 1, 5);
        }
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


    #endregion

    protected void ugrdLoadMapList_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        this.CommonDataPrint();
    }
    protected void ugrdEEP_CellExported(object sender, CellExportedEventArgs e)
    {

    }
    protected void ugrdEEP_CellExporting(object sender, CellExportingEventArgs e)
    {
        this.SetCoulumStlye(e.CurrentWorksheet, e.CurrentRowIndex, e.CurrentColumnIndex);
    }

    protected void ddlSumType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetParam();
        this.SetKpiStatusGrid();
        this.SetDeptScoreCard();
    }
    protected void ddlEstDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetParam();
        this.SetKpiStatusGrid();
        this.SetDeptScoreCard();
        this.SetEstDeptLoadMap();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

    }
    protected void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetParam();
        this.SetKpiStatusGrid();
        this.SetDeptScoreCard();
    }
}
