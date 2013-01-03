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
using System.Drawing.Drawing2D;
using System.IO;

using Infragistics.WebUI.UltraWebGrid;
using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.BSC.Biz;

public partial class _common_Draft_DOC0201S1 : AppPageBase
{
    #region 변수선언
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
                ViewState["YMD"] = GetRequest("YMD", "");
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

    public string IisEstMonth
    {
        get
        {
            if (ViewState["IS_EST_MONTH"] == null)
            {
                ViewState["IS_EST_MONTH"] = GetRequest("IS_EST_MONTH", "N");
            }
            return (string)ViewState["IS_EST_MONTH"];
        }
        set
        {
            ViewState["IS_EST_MONTH"] = value;
        }
    }

    public int IGroupRefID
    {
        get
        {
            if (ViewState["GROUP_REF_ID"] == null)
            {
                ViewState["GROUP_REF_ID"] = GetRequestByInt("GROUP_REF_ID", 0);
            }

            return (int)ViewState["GROUP_REF_ID"];
        }
        set
        {
            ViewState["GROUP_REF_ID"] = value;
        }
    }

    public int IEstLevel
    {
        get
        {
            if (ViewState["EST_LEVEL"] == null)
            {
                ViewState["EST_LEVEL"] = GetRequestByInt("EST_LEVEL", 0);
            }

            return (int)ViewState["EST_LEVEL"];
        }
        set
        {
            ViewState["EST_LEVEL"] = value;
        }
    }

    public int IEstEmpID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = GetRequestByInt("EST_EMP_ID", 0);
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID", 0);
            }

            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
        }
    }

    public string IChampionEmpYN
    {
        get
        {
            if (ViewState["CHAMPION_EMP_YN"] == null)
            {
                ViewState["CHAMPION_EMP_YN"] = GetRequest("CHAMPION_EMP_YN", "N");
            }

            return (string)ViewState["CHAMPION_EMP_YN"];
        }
        set
        {
            ViewState["CHAMPION_EMP_YN"] = value;
        }
    }

    public string IApprovalEmpYN
    {
        get
        {
            if (ViewState["APPROVAL_EMP_YN"] == null)
            {
                ViewState["APPROVAL_EMP_YN"] = GetRequest("APPROVAL_EMP_YN", "N");
            }

            return (string)ViewState["APPROVAL_EMP_YN"];
        }
        set
        {
            ViewState["APPROVAL_EMP_YN"] = value;
        }
    }

    public string ICheckStatus
    {
        get
        {
            if (ViewState["CHECKSTATUS"] == null)
            {
                ViewState["CHECKSTATUS"] = GetRequest("CHECKSTATUS", "N");
            }

            return (string)ViewState["CHECKSTATUS"];
        }
        set
        {
            ViewState["CHECKSTATUS"] = value;
        }
    }

    public string IConfirmStatus
    {
        get
        {
            if (ViewState["CONFIRMSTATUS"] == null)
            {
                ViewState["CONFIRMSTATUS"] = GetRequest("CONFIRMSTATUS", "N");
            }

            return (string)ViewState["CONFIRMSTATUS"];
        }
        set
        {
            ViewState["CONFIRMSTATUS"] = value;
        }
    }

    public string IYearlyClose_YN
    {
        get
        {
            if (ViewState["YEARLY_CLOSE_YN"] == null)
            {
                ViewState["YEARLY_CLOSE_YN"] = GetRequest("YEARLY_CLOSE_YN");
            }
            return (string)ViewState["YEARLY_CLOSE_YN"];
        }
        set
        {
            ViewState["YEARLY_CLOSE_YN"] = value;
        }
    }

    public string IMontylyClose_YN
    {
        get
        {
            if (ViewState["MONTHLY_CLOSE_YN"] == null)
            {
                ViewState["MONTHLY_CLOSE_YN"] = GetRequest("MONTHLY_CLOSE_YN", "Y");
            }
            return (string)ViewState["MONTHLY_CLOSE_YN"];
        }
        set
        {
            ViewState["MONTHLY_CLOSE_YN"] = value;
        }
    }

    public string IisPassCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_CLOSE_DAY"] = GetRequest("IS_PASS_CLOSE_DAY");
            }
            return (string)ViewState["IS_PASS_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_CLOSE_DAY"] = value;
        }
    }

    public string IKpiGroupRefID
    {
        get
        {
            if (ViewState["KPI_GROUP_REF_ID"] == null)
            {
                ViewState["KPI_GROUP_REF_ID"] = GetRequest("KPI_GROUP_REF_ID");
            }

            return (string)ViewState["KPI_GROUP_REF_ID"];
        }
        set
        {
            ViewState["KPI_GROUP_REF_ID"] = value;
        }
    }

    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = GetRequest("IS_ADMIN", "N");
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetKpiInfoData();
            this.SetResultGrid();
            this.SetResultData();
            this.SetExceptGrid();
        }
    }

    #region Event
    //===================================: KPI기본정보 조회
    private void SetInitForm()
    {
        lblMM_MS.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        lblMM_TS.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        lblMSResult.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        lblTSResult.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        lblTsCalcResult.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        lblMsCalcResult.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        lblINITIATIVE_MM.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
    }
    
    private void SetKpiInfoData()
    {
        //int LogInUser = gUserInfo.Emp_Ref_ID;

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        lblRESULT_ACHIEVEMENT_TYPE.Text = objBSC.Iresult_achievement_type_name;
        lblRESULT_INPUT_TYPE.Text       = objBSC.Iresult_input_type_name;
        lblRESULT_TS_CALC_TYPE.Text     = objBSC.Iresult_ts_calc_type_name;
        lblKPICode.Text                 = objBSC.Ikpi_code;
        lblKPIName.Text                 = objBSC.Ikpi_name;
        lblUnitName.Text                = objBSC.Iunit_name;
        //this.TtxtTSResult.ReadOnly      = (objBSC.Iresult_ts_calc_type == "SUM" || objBSC.Iresult_ts_calc_type == "AVG") ? true : false;
        //this.TtxtTSResult.BackColor     = (objBSC.Iresult_ts_calc_type == "SUM" || objBSC.Iresult_ts_calc_type == "AVG") ? Color.WhiteSmoke : Color.White;
        //this.IKpiPoolRefID              = objBSC.Ikpi_pool_ref_id;

        //DataSet rDs = objBSC.GetKpiStatus(this.IEstTermRefID, this.IKpiRefID, LogInUser);
        //if (rDs.Tables[0].Rows.Count > 0)
        //{
        //    this.IChampionEmpYN   = rDs.Tables[0].Rows[0]["CHAMPION_EMP_YN"].ToString();
        //    this.IApprovalEmpYN   = rDs.Tables[0].Rows[0]["APPROVAL_EMP_YN"].ToString();
        //    this.IYearlyClose_YN  = rDs.Tables[0].Rows[0]["YEARLY_CLOSE_YN"].ToString();
        //    this.IisPassCloseDay  = rDs.Tables[0].Rows[0]["IS_PASS_CLOSE_DAY"].ToString();
        //}

        //Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail(this.IEstTermRefID, this.IYMD);
        //this.IMontylyClose_YN       = objTerm.Iclose_yn;

        //Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        //TltrEstBasis.Text   = objPool.Ivaluation_basis;
        //this.IKpiGroupRefID = objPool.Ikpi_type;
    }

    private void SetResultData()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        lblMM_MS.Text              = objBSC.Iymd;
        lblMM_TS.Text              = objBSC.Iymd;
        lblMSResult.Text           = objBSC.Iresult_ms.ToString();
        lblTSResult.Text           = objBSC.Iresult_ts.ToString();
        lblMsCalcResult.Text       = objBSC.Ical_result_ms.ToString();
        lblTsCalcResult.Text       = objBSC.Ical_result_ts.ToString();
        lblCAUSE_TEXT_MS.Text      = PageUtility.GetHtmlEncodeChar(objBSC.Icause_text_ms);
        lblCAUSE_TEXT_TS.Text      = PageUtility.GetHtmlEncodeChar(objBSC.Icause_text_ts);
        lblMEASURE_TEXT_MS.Text    = PageUtility.GetHtmlEncodeChar(objBSC.Imeasure_text_ms);
        lblMEASURE_TEXT_TS.Text    = PageUtility.GetHtmlEncodeChar(objBSC.Imeasure_text_ts);
        ChkApplyItfsResult.Checked = (objBSC.Ical_apply_yn == "Y") ? true : false;
        lblNotApplyReason.Text     = PageUtility.GetHtmlEncodeChar(objBSC.Ical_apply_reason);
        hdfCauseDocNo.Value        = objBSC.Icause_file_id;
        hdfMeasureDocNo.Value      = objBSC.Imeasure_file_id;
        imgCauseDocNo.Visible      = (objBSC.Icause_file_id=="") ? false : true;
        imgMeasureDocNo.Visible    = (objBSC.Imeasure_file_id=="") ? false : true;

        //this.ICheckStatus           = objBSC.Icheckstatus;
        //this.IConfirmStatus         = objBSC.Iconfirmstatus;
        //this.IApp_Ref_Id            = objBSC.Iapp_ref_id;

        Biz_Bsc_Kpi_Initiative objIni = new Biz_Bsc_Kpi_Initiative(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        lblINITIATIVE_MM.Text     = PageUtility.GetHtmlEncodeChar(objIni.Iymd);
        lblINITIATIVE_DO.Text     = PageUtility.GetHtmlEncodeChar(objIni.Iinitiative_do);
        lblINITIATIVE_PLAN.Text   = PageUtility.GetHtmlEncodeChar(objIni.Iinitiative_plan);
        hdfInitiativeDocNo.Value  = objIni.Ido_file;
        imgInitiativeFile.Visible = (objIni.Ido_file == "") ? false : true;
    }

    //===================================: 계획/실적 그리드 조회
    private void SetResultGrid()
    {
        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        DataSet ds = objBSC.GetResultListPerMonth(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        
        grvResult.DataSource = ds.Tables[0].DefaultView;
        grvResult.DataBind();
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
        lblExtResult_MS.Text           = objNextExp.IResult_Ms.ToString();
        lblExtResult_TS.Text           = objNextExp.IResult_Ts.ToString();
        lblEXPECT_REASON_MS.Text       = PageUtility.GetHtmlEncodeChar(objNextExp.IExpect_Reason_Ms);
        lblEXPECT_REASON_TS.Text       = PageUtility.GetHtmlEncodeChar(objNextExp.IExpect_Reason_Ts);
        lbltxtRESULT_DIFF_CAUSE.Text   = PageUtility.GetHtmlEncodeChar(objNextExp.IResult_Diff_Cause);
        hdfEXPECT_REASON_FILE_ID.Value = objNextExp.IExpect_Reason_File_Id;
        hdfRESULT_DIFF_FILE_ID.Value   = objNextExp.IResult_Diff_File_Id;

        imgEXPECT_REASON_FILE_ID.Visible = (objNextExp.IExpect_Reason_File_Id == "") ? false : true;
        imgRESULT_DIFF_FILE_ID.Visible   = (objNextExp.IResult_Diff_File_Id == "") ? false : true;

        lblNextYmd_Ms.Text = this.IYMD_NEXT;
        lblNextYmd_Ts.Text = this.IYMD_NEXT;

        DataSet rDs = objNextExp.GetResultExpect(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        grvResultExpt.DataSource = rDs.Tables[0].DefaultView;
        grvResultExpt.DataBind();
    }
    #endregion

    #region Event
    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[6].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[7].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[8].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[9].Style.Add(HtmlTextWriterStyle.TextAlign, "center");
            e.Row.Cells[10].Style.Add(HtmlTextWriterStyle.TextAlign, "center");

            string sSignal_MS = DataBinder.Eval(e.Row.DataItem, "SIGNAL_MS").ToString();
            string sSignal_TS = DataBinder.Eval(e.Row.DataItem, "SIGNAL_TS").ToString();

            System.Web.UI.WebControls.Image imgSignal_MS = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgSignal_MS");
            System.Web.UI.WebControls.Image imgSignal_TS = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgSignal_TS");

            imgSignal_MS.ImageUrl = "~/images/" + sSignal_MS;
            imgSignal_TS.ImageUrl = "~/images/" + sSignal_TS;
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        { 
            
        }
    }
    
    protected void grvResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell oTableCell = new TableHeaderCell();

            oTableCell.ColumnSpan = 1;
            oTableCell.RowSpan    = 2;
            oTableCell.Text = "목표&lt;BR /&gt;시기";
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "[ 당  월 ]";
            oTableCell.ColumnSpan = 4;  
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "[ 누  적 ]";
            oTableCell.ColumnSpan = 4;
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.ColumnSpan = 1;
            oTableCell.ColumnSpan = 2;
            oTableCell.Text = "신호";
            oGridViewRow.Cells.Add(oTableCell);

            oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

            e.Row.Cells[0].Visible = false;

            e.Row.Cells[0].Width  = Unit.Pixel(80);
            e.Row.Cells[1].Width  = Unit.Pixel(100);
            e.Row.Cells[2].Width  = Unit.Pixel(100);
            e.Row.Cells[3].Width  = Unit.Pixel(100);
            e.Row.Cells[4].Width  = Unit.Pixel(80);
            e.Row.Cells[5].Width  = Unit.Pixel(100);
            e.Row.Cells[6].Width  = Unit.Pixel(100);
            e.Row.Cells[7].Width  = Unit.Pixel(100);
            e.Row.Cells[8].Width  = Unit.Pixel(80);
            e.Row.Cells[9].Width  = Unit.Pixel(20);
            e.Row.Cells[10].Width = Unit.Pixel(20);
        }
    }

    protected void grvResultExpt_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell oTableCell = new TableHeaderCell();

            oTableCell.ColumnSpan = 1;
            oTableCell.RowSpan    = 2;
            oTableCell.Text = "구분";
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
            e.Row.Cells[1].Width = Unit.Pixel(130);
            e.Row.Cells[2].Width = Unit.Pixel(130);
            e.Row.Cells[3].Width = Unit.Pixel(101);
            e.Row.Cells[4].Width = Unit.Pixel(130);
            e.Row.Cells[5].Width = Unit.Pixel(130);
            e.Row.Cells[6].Width = Unit.Pixel(102);
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
