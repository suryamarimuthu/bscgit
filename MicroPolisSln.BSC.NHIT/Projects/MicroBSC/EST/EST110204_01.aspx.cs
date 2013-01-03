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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Integration.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;

using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

public partial class EST_EST110204_01 : EstPageBase
{
    #region 전역변수
    protected string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lnkReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }
    private bool ICONFIRM_EST
    {
        get
        {
            if (ViewState["CONFIRM_EST"] == null)
                ViewState["CONFIRM_EST"] = false;
            return (bool)ViewState["CONFIRM_EST"];
        }
        set
        {
            ViewState["CONFIRM_EST"] = value;
        }
    }
    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }
    protected int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 0;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }
    protected string IEST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
                ViewState["EST_ID"] = "3A";
            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }
    protected int IESTTERM_SUB_ID
    {
        get
        {
            if (ViewState["ESTTERM_SUB_ID"] == null)
                ViewState["ESTTERM_SUB_ID"] = 0;
            return (int)ViewState["ESTTERM_SUB_ID"];
        }
        set
        {
            ViewState["ESTTERM_SUB_ID"] = value;
        }
    }
    protected int IESTTERM_STEP_ID
    {
        get
        {
            if (ViewState["ESTTERM_STEP_ID"] == null)
                ViewState["ESTTERM_STEP_ID"] = 0;
            return (int)ViewState["ESTTERM_STEP_ID"];
        }
        set
        {
            ViewState["ESTTERM_STEP_ID"] = value;
        }
    }

    //1: 평가자, 2: 피평가자
    protected int IUSER_TYPE
    {
        get
        {
            if (ViewState["USER_TYPE"] == null)
                ViewState["USER_TYPE"] = 1;
            return (int)ViewState["USER_TYPE"];
        }
        set
        {
            ViewState["USER_TYPE"] = value;
        }
    }
    protected int IEST_EMP_ID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
                ViewState["EST_EMP_ID"] = -1;
            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }
    protected int ITGT_EMP_ID
    {
        get
        {
            if (ViewState["TGT_EMP_ID"] == null)
                ViewState["TGT_EMP_ID"] = -1;
            return (int)ViewState["TGT_EMP_ID"];
        }
        set
        {
            ViewState["TGT_EMP_ID"] = value;
        }
    }
    protected int IEST_DEPT_ID
    {
        get
        {
            if (ViewState["EST_DEPT_ID"] == null)
                ViewState["EST_DEPT_ID"] = -1;
            return (int)ViewState["EST_DEPT_ID"];
        }
        set
        {
            ViewState["EST_DEPT_ID"] = value;
        }
    }
    protected int ITGT_DEPT_ID
    {
        get
        {
            if (ViewState["TGT_DEPT_ID"] == null)
                ViewState["TGT_DEPT_ID"] = GetRequestByInt("TGT_DEPT_ID", -1);
            return (int)ViewState["TGT_DEPT_ID"];
        }
        set
        {
            ViewState["TGT_DEPT_ID"] = value;
        }
    }

    protected bool IRESULT_APP_OK
    {
        get
        {
            if (ViewState["RESULT_APP_OK"] == null)
                ViewState["RESULT_APP_OK"] = false;
            return (bool)ViewState["RESULT_APP_OK"];
        }
        set
        {
            ViewState["RESULT_APP_OK"] = value;
        }
    }
    protected string IRESULT_APP_GET
    {
        get
        {
            return (IRESULT_APP_OK == true ? "1" : "2");
        }
    }
    protected string IREPORT_STATUS
    {
        get
        {
            if (ViewState["REPORT_STATUS"] == null)
                ViewState["REPORT_STATUS"] = 'N';
            return (string)ViewState["REPORT_STATUS"];
        }
        set
        {
            ViewState["REPORT_STATUS"] = value;
        }
    }
    protected bool IEST_TERM_STATUS
    {
        get
        {
            if (ViewState["EST_TERM_STATUS"] == null)
                ViewState["EST_TERM_STATUS"] = false;
            return (bool)ViewState["EST_TERM_STATUS"];
        }
        set
        {
            ViewState["EST_TERM_STATUS"] = value;
        }
    }
    protected string IEST_STATUS
    {
        get
        {
            if (ViewState["EST_STATUS"] == null)
                ViewState["EST_STATUS"] = "";
            return (string)ViewState["EST_STATUS"];
        }
        set
        {
            ViewState["EST_STATUS"] = value;
        }
    }

    protected bool ITOTAL_EST_STATUS_TRUE
    {
        get
        {
            if (ViewState["TOTAL_EST_STATUS_TRUE"] == null)
                ViewState["TOTAL_EST_STATUS_TRUE"] = false;
            return (bool)ViewState["TOTAL_EST_STATUS_TRUE"];
        }
        set
        {
            ViewState["TOTAL_EST_STATUS_TRUE"] = value;
        }
    }
    protected int IEST_FEEDBACK_SEQ
    {
        get
        {
            if (ViewState["EST_FEEDBACK_SEQ"] == null)
                ViewState["EST_FEEDBACK_SEQ"] = 0;
            return (int)ViewState["EST_FEEDBACK_SEQ"];
        }
        set
        {
            ViewState["EST_FEEDBACK_SEQ"] = value;
        }
    }
    protected string IEST_FEEDBACK_TYPE
    {
        get
        {
            if (ViewState["EST_FEEDBACK_TYPE"] == null)
                ViewState["EST_FEEDBACK_TYPE"] = "";
            return (string)ViewState["EST_FEEDBACK_TYPE"];
        }
        set
        {
            ViewState["EST_FEEDBACK_TYPE"] = value;
        }
    }
    private string IEST_QTT_MBO_YN
    {
        get
        {
            if (ViewState["EST_QTT_MBO_YN"] == null)
                ViewState["EST_QTT_MBO_YN"] = "N";
            return (string)ViewState["EST_QTT_MBO_YN"];
        }
        set
        {
            ViewState["EST_QTT_MBO_YN"] = value;
        }
    }
    private string IMBO_SCORE_ESTIMATE_YN
    {
        get
        {
            if (ViewState["MBO_SCORE_ESTIMATE_YN"] == null)
                ViewState["MBO_SCORE_ESTIMATE_YN"] = "N";
            return (string)ViewState["MBO_SCORE_ESTIMATE_YN"];
        }
        set
        {
            ViewState["MBO_SCORE_ESTIMATE_YN"] = value;
        }
    }
    protected string IEST_STEP_PREV
    {
        get
        {
            if (ViewState["EST_STEP_PREV"] == null)
                ViewState["EST_STEP_PREV"] = "";
            return (string)ViewState["EST_STEP_PREV"];
        }
        set
        {
            ViewState["EST_STEP_PREV"] = value;
        }
    }
    protected string IEST_STEP_NEXT
    {
        get
        {
            if (ViewState["EST_STEP_NEXT"] == null)
                ViewState["EST_STEP_NEXT"] = "";
            return (string)ViewState["EST_STEP_NEXT"];
        }
        set
        {
            ViewState["EST_STEP_NEXT"] = value;
        }
    }
    private string ICOMMENTLIST
    {
        get
        {
            if (ViewState["COMMENTLIST"] == null)
                ViewState["COMMENTLIST"] = "";
            return (string)ViewState["COMMENTLIST"];
        }
        set
        {
            ViewState["COMMENTLIST"] = value;
        }
    }
    private string IESTEMPLIST
    {
        get
        {
            if (ViewState["ESTEMPLIST"] == null)
                ViewState["ESTEMPLIST"] = "";
            return (string)ViewState["ESTEMPLIST"];
        }
        set
        {
            ViewState["ESTEMPLIST"] = value;
        }
    }
    protected string IEST_STEP_LAST
    {
        get
        {
            if (ViewState["EST_STEP_LAST"] == null)
                ViewState["EST_STEP_LAST"] = "";
            return (string)ViewState["EST_STEP_LAST"];
        }
        set
        {
            ViewState["EST_STEP_LAST"] = value;
        }
    }
    protected int ILAST_STEP_ID
    {
        get
        {
            if (ViewState["LAST_STEP_ID"] == null)
                ViewState["LAST_STEP_ID"] = 0;
            return (int)ViewState["LAST_STEP_ID"];
        }
        set
        {
            ViewState["LAST_STEP_ID"] = value;
        }
    }
    private DataTable ISTATUS_TABLE
    {
        get
        {
            return (DataTable)ViewState["STATUS_TABLE"];
        }
        set
        {
            ViewState["STATUS_TABLE"] = value;
        }
    }

    private DataTable DT_EQT_EQL_RATIO
    {
        get
        {
            return (DataTable)ViewState["DT_EQT_EQL_RATIO"];
        }
        set
        {
            ViewState["DT_EQT_EQL_RATIO"] = value;
        }
    } 
    #endregion

    private DataTable dtPreStepGrade = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdMBO.DisplayLayout.Bands[0].Columns.FromKey("KPI_CODE").Header.Caption = this.GetText("LBL_00017", "CODE");

        if (!IsPostBack)
        {
            DoInitControl();
            DoBindingStatus();
            DoBinding();
            return;
        }
        else
        {
            MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info bizCom = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
            DataSet dsCom = bizCom.GetCodeListPerCategory("BS015", "Y");
            ddlGrade_hdf.DataSource = dsCom;
            ddlGrade_hdf.DataValueField = "ETC_CODE";
            ddlGrade_hdf.DataTextField = "CODE_NAME";
            ddlGrade_hdf.DataBind();
            ddlGrade_hdf.Items.Insert(0, "::선택::");

            ddlGradePoint_hdf.DataSource = dsCom;
            ddlGradePoint_hdf.DataValueField = "ETC_CODE";
            ddlGradePoint_hdf.DataTextField = "SEGMENT1";
            ddlGradePoint_hdf.DataBind();
            ddlGradePoint_hdf.Items.Insert(0, "::선택::");

            DoBindingStatus();
        }

        ltrScript.Text = "";
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ICOMP_ID = PageUtility.GetIntByValueDropDownList(ddlCompID);
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
        DoReSetControl();
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        IESTTERM_SUB_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        DoReSetControl();
    }

    private string estterm_step_name = "X차 평가";

    private void DoInitControl()
    {
        //범례표시
        //HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, this.IEST_ID);
        Biz_Com_Code_Info bizCom = new Biz_Com_Code_Info();
        this.ISTATUS_TABLE = bizCom.GetCodeListPerCategory("BS016", "Y").Tables[0];

        iBtnTargetFile_Up.Visible = false;
        txtReport.ToolbarStartExpanded = txtOpinion.ToolbarStartExpanded = txtFeedBack.ToolbarStartExpanded = false;

        DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
        ICOMP_ID = GetRequestByInt("COMP_ID", PageUtility.GetIntByValueDropDownList(ddlCompID));
        PageUtility.FindByValueDropDownList(ddlCompID, ICOMP_ID);

        DropDownListCommom.BindEstTerm(ddlEstTerm);
        IESTTERM_REF_ID = GetRequestByInt("ESTTERM_REF_ID", PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        PageUtility.FindByValueDropDownList(ddlEstTerm, IESTTERM_REF_ID);

        DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , ICOMP_ID
                                                    , "N");
        IESTTERM_SUB_ID = GetRequestByInt("ESTTERM_SUB_ID", PageUtility.GetIntByValueDropDownList(ddlEstTermSubID));
        PageUtility.FindByValueDropDownList(ddlEstTermSubID, IESTTERM_SUB_ID);

        IESTTERM_STEP_ID = GetRequestByInt("ESTTERM_STEP_ID");
        IUSER_TYPE = GetRequestByInt("USERTYPE", 1);
        IEST_ID = GetRequest("EST_ID", "3A");

        if (IUSER_TYPE == 1) //평가자
        {
            IEST_EMP_ID = EMP_REF_ID;
            IEST_DEPT_ID = GetRequestByInt("EST_DEPT_ID");
            if (IEST_DEPT_ID == 0)
            {
                Biz_EmpInfos bizEmp = new Biz_EmpInfos();
                DataSet ds = bizEmp.GetEmpByEmpID(IEST_EMP_ID);
                if (ds.Tables[0].Rows.Count > 0)
                    IEST_DEPT_ID = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["DEPT_REF_ID"]);
            }
            ITGT_EMP_ID = GetRequestByInt("TGT_EMP_ID");
            
        }
        else if (IUSER_TYPE == 2)//피평가자
        {
            IEST_EMP_ID = GetRequestByInt("EST_EMP_ID");
            IEST_DEPT_ID = GetRequestByInt("EST_DEPT_ID");
            ITGT_EMP_ID = EMP_REF_ID;
            
        }
        else //관리자, 성과평가관리자
        {
            IEST_EMP_ID = GetRequestByInt("EST_EMP_ID");
            IEST_DEPT_ID = GetRequestByInt("EST_DEPT_ID");
            ITGT_EMP_ID = GetRequestByInt("TGT_EMP_ID");
            
        }


        if (ITGT_EMP_ID > 0)
        {
            Biz_EmpInfos bizEmp = new Biz_EmpInfos();
            DataSet ds = bizEmp.GetEmpInfo(ITGT_EMP_ID);
            if (ds.Tables[0].Rows.Count > 0)
                txtEMPNAME.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
            Biz_DeptInfos bizDept = new Biz_DeptInfos();
            ds = bizDept.GetDeptInfo(ITGT_DEPT_ID);
            if (ds.Tables[0].Rows.Count > 0)
                txtDEPTNAME.Text = ds.Tables[0].Rows[0]["DEPT_NAME"].ToString();
            hdfEmpRefId.Value = ITGT_EMP_ID.ToString();
            hdfDeptRefId.Value = ITGT_DEPT_ID.ToString();
        }
        if (IUSER_TYPE == 1)
            ddlEstTerm.Enabled = ddlEstTermSubID.Enabled = true;
        else
        {
            ibtnEmpSearch.Visible = false;
            //txtDEPTNAME.Visible = txtEMPNAME.Visible = false;
            ibtnSearch.Visible = false;
        }

        //MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info bizCom = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        DataSet dsCom = bizCom.GetCodeListPerCategory("BS015", "Y");
        ddlGrade_hdf.DataSource = dsCom;
        ddlGrade_hdf.DataValueField = "ETC_CODE";
        ddlGrade_hdf.DataTextField = "CODE_NAME";
        ddlGrade_hdf.DataBind();
        ddlGrade_hdf.Items.Insert(0, "::선택::");

        ddlGradePoint_hdf.DataSource = dsCom;
        ddlGradePoint_hdf.DataValueField = "ETC_CODE";
        ddlGradePoint_hdf.DataTextField = "SEGMENT1";
        ddlGradePoint_hdf.DataBind();
        ddlGradePoint_hdf.Items.Insert(0, "::선택::");

        //계량평가 평가가능여부
        Biz_EstInfos bizInfos = new Biz_EstInfos(ICOMP_ID, IEST_ID);
        this.IEST_QTT_MBO_YN = (bizInfos.Est_Qtt_Mbo_YN.Trim() == "" ? "N" : bizInfos.Est_Qtt_Mbo_YN.Trim());
        this.IMBO_SCORE_ESTIMATE_YN = (bizInfos.Mbo_Score_Estimate_YN.Trim() == "" ? "N" : bizInfos.Mbo_Score_Estimate_YN.Trim());
    }

    protected void ibtnSearch_Click(object sender, EventArgs e)
    {
       
        DoBinding();
    }

    protected void ibtnPrint_Click(object sender, EventArgs e)
    {
        ugrdEEP.ExcelStartRow = 4;
        ugrdEEP.ExportMode = ExportMode.InBrowser;
        //string dnName = Server.HtmlEncode("MBO평가결과");
        //ugrdEEP.DownloadName = HttpUtility.UrlDecode(dnName);
        ugrdEEP.WorksheetName = "MBO평가결과";
        ugrdMBO.Columns.FromKey("TARGET").Hidden = true;
        ugrdMBO.Columns.FromKey("RESULT").Hidden = true;
        ugrdEEP.Export(ugrdMBO);
        ugrdMBO.Columns.FromKey("TARGET").Hidden = false;
        ugrdMBO.Columns.FromKey("RESULT").Hidden = false;
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간";
        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Rows[0].Cells[1].Value = ddlEstTerm.SelectedItem.Text;
        e.CurrentWorksheet.Rows[0].Cells[2].Value = "평가주기";
        e.CurrentWorksheet.Rows[0].Cells[2].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Rows[0].Cells[3].Value = ddlEstTermSubID.SelectedItem.Text;
        e.CurrentWorksheet.Rows[0].Cells[4].Value = "피평가자";
        e.CurrentWorksheet.Rows[0].Cells[4].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Rows[0].Cells[5].Value = txtDEPTNAME.Text;
        e.CurrentWorksheet.Rows[0].Cells[6].Value = txtEMPNAME.Text;

        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.White;
        e.CurrentWorksheet.Rows[0].Cells[2].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[0].Cells[2].CellFormat.Font.Color = System.Drawing.Color.White;
        e.CurrentWorksheet.Rows[0].Cells[4].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[0].Cells[4].CellFormat.Font.Color = System.Drawing.Color.White;

        for (int i = 0; i < 10; i++)
        {
            e.CurrentWorksheet.MergedCellsRegions.Add(2, i, 3, i);
            e.CurrentWorksheet.Rows[2].Cells[i].Value = ugrdMBO.Columns[i].Header.Caption.Replace("<br />", "") ;
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.Font.Name = "Malgun Gothic";
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.Font.Height = 165;
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.Font.Color = System.Drawing.Color.White;
        }

        //e.CurrentWorksheet.MergedCellsRegions.Add(2, 10, 2, 14);
        //e.CurrentWorksheet.Rows[2].Cells[10].Value = "평가등급";
        //e.CurrentWorksheet.Rows[2].Cells[10].CellFormat.Font.Color = System.Drawing.Color.White;
        //e.CurrentWorksheet.Rows[2].Cells[10].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");

        e.CurrentWorksheet.MergedCellsRegions.Add(2,15, 3, 15);
        e.CurrentWorksheet.Rows[2].Cells[15].Value = ugrdMBO.Columns[15].Header.Caption.Replace("<br />", "");
        e.CurrentWorksheet.Rows[2].Cells[15].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[2].Cells[15].CellFormat.Font.Name = "Malgun Gothic";
        e.CurrentWorksheet.Rows[2].Cells[15].CellFormat.Font.Height = 165;
        e.CurrentWorksheet.Rows[2].Cells[15].CellFormat.Font.Color = System.Drawing.Color.White;

        //int cntPreStep = (ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index - 16) / 3;
        //for (int i = 0; i < cntPreStep; i++)
        //{
        //    e.CurrentWorksheet.MergedCellsRegions.Add(2, 16 + (i * 3), 2, 18 + (i * 3));
        //    e.CurrentWorksheet.Rows[2].Cells[16 + (i * 3)].Value = (i + 1).ToString() + "차 평가";
        //    e.CurrentWorksheet.Rows[2].Cells[16 + (i * 3)].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        //    e.CurrentWorksheet.Rows[2].Cells[16 + (i * 3)].CellFormat.Font.Color = System.Drawing.Color.White;
        //    e.CurrentWorksheet.Rows[2].Cells[16 + (i * 3)].CellFormat.Font.Name = "Malgun Gothic";
        //}

        e.CurrentWorksheet.MergedCellsRegions.Add(2, ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index, 2, ugrdMBO.Columns.FromKey("EST_REASON").Index);
        e.CurrentWorksheet.Rows[2].Cells[ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index].Value = (this.IESTTERM_STEP_ID - 1).ToString() + "차 평가";
        e.CurrentWorksheet.Rows[2].Cells[ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[2].Cells[ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index].CellFormat.Font.Color = System.Drawing.Color.White;
        e.CurrentWorksheet.Rows[2].Cells[ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index].CellFormat.Font.Name = "Malgun Gothic";

        for (int i = 0; i < ugrdMBO.Columns.Count; i++)
        {
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.Alignment = HorizontalCellAlignment.Center;
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.LeftBorderColor = Color.White;
            e.CurrentWorksheet.Columns[i].Width = DataTypeUtility.GetToInt32(ugrdMBO.Columns[i].Width.Value) * 10;
        }

    }

    protected void ugrdEEP_CellExporting(object sender, CellExportingEventArgs e)
    {
        int iRdex = e.CurrentRowIndex;
        int iCdex = e.CurrentColumnIndex;

        if (iRdex > 3)
        {
            if (iCdex == ugrdMBO.Columns.FromKey("APP_STATUS").Index)
            {
                try
                {
                    e.Value = ugrdMBO.Rows[e.CurrentRowIndex - 4].Cells.FromKey("APP_STATUS_NAME").Value;
                }
                catch { }
            }
            if (iCdex == ugrdMBO.Columns.FromKey("EST_REASON").Index)
            {
                try
                {
                    
                    e.Value = ugrdMBO.Rows[e.CurrentRowIndex - 4].Cells.FromKey("GRADE_REASON").Value.ToString().Replace("<br />", "\n");
                }
                catch { }
            }

            if (ugrdMBO.Columns.FromKey("GRADE").Hidden)
            {
                if (iCdex == ugrdMBO.Columns.FromKey("GRADE_POP_POINT").Index)
                {
                    try
                    {
                        e.Value = e.Value.ToString() + "등급";
                        e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].CellFormat.Alignment = HorizontalCellAlignment.Center;
                    }
                    catch { }
                }
            }
            else
            {
                if (iCdex == ugrdMBO.Columns.FromKey("GRADE").Index)
                {
                    try
                    {
                        e.Value = e.Value.ToString() + "등급";
                        e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].CellFormat.Alignment = HorizontalCellAlignment.Center;
                    }
                    catch { }
                }
            }
        }
    }

    protected void ugrdEEP_CellExported(object sender, CellExportedEventArgs e)
    {
        //int iRdex = e.CurrentRowIndex;
        //int iCdex = e.CurrentColumnIndex;

        //if (iCdex == ugrdMBO.Columns.FromKey("APP_STATUS").Index)
        //{
        //    try
        //    {
        //        e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value = ugrdMBO.Rows[iRdex].Cells.FromKey("APP_STATUS_NAME").Text;
        //    }
        //    catch { }
        //}
            
        
        //string strEname = string.Empty;
        //int colReason = ugrdMBO.Columns.FromKey("EST_REASON").Index;
        //if (colReason == iCdex)
        //{
        //    try
        //    {
        //        e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value = ugrdMBO.Rows[iRdex].Cells.FromKey("GRADE_REASON").Value;
        //    }
        //    catch { }
        //}
        //if (iRdex > 4)
        //{
        //    if (iCdex > 6)
        //    {
        //        strEname = ugrdMBO.Rows[iRdex - 5].Cells.FromKey("THRESHOLD_ENAME").Text;
        //        string[] strEnameA = strEname.Split('*');
        //        string strEname1 = strEnameA.GetValue(iCdex - 7).ToString().Split('^').GetValue(0).ToString();
        //        string strEname2 = strEnameA.GetValue(iCdex - 7).ToString().Split('^').GetValue(1).ToString();
        //        string str = e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value.ToString();
        //        char[] sep = { '<', '>' };
        //        Array a = str.Split(sep);
        //        e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value
        //            = a.GetValue(0).ToString().Replace("&nbsp;", "  [") + (strEname1.Length > 4 ? strEname1.Substring(0, 4) : strEname1) + "] \n"
        //            + a.GetValue(4).ToString().Replace("&nbsp;", "  [") + (strEname2.Length > 4 ? strEname2.Substring(0, 4) : strEname2) + "] ";
        //        e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].CellFormat.WrapText = ExcelDefaultableBoolean.True;
        //    }
        //}
    }

    protected void ugrdEEP_EndExport(object sender, EndExportEventArgs e)
    {
        //e.CurrentWorksheet.Columns[0].Width = 3000;
        //e.CurrentWorksheet.Columns[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
        //e.CurrentWorksheet.Columns[1].Width = 6000;
        //e.CurrentWorksheet.Columns[2].Width = 2500;
        //e.CurrentWorksheet.Columns[2].CellFormat.Alignment = HorizontalCellAlignment.Center;
        //e.CurrentWorksheet.Columns[3].Width = 3000;
        //e.CurrentWorksheet.Columns[3].CellFormat.Alignment = HorizontalCellAlignment.Center;
        //e.CurrentWorksheet.Columns[4].Width = 2500;
        //e.CurrentWorksheet.Columns[4].CellFormat.Alignment = HorizontalCellAlignment.Center;
        //e.CurrentWorksheet.Columns[5].Width = 2500;
        //e.CurrentWorksheet.Columns[5].CellFormat.Alignment = HorizontalCellAlignment.Center;
        //for (int i = 7; i < 19; i++)
        //    e.CurrentWorksheet.Columns[i].Width = 6000;

        for (int i = 0; i < ugrdMBO.Columns.Count - 2; i++)
        {
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.Alignment = HorizontalCellAlignment.Center;
            e.CurrentWorksheet.Rows[3].Cells[i].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
            e.CurrentWorksheet.Rows[2].Cells[i].CellFormat.LeftBorderColor = Color.White;
            //e.CurrentWorksheet.Columns[i].Width = DataTypeUtility.GetToInt32(ugrdMBO.Columns[i].Width.Value) * 50;
        }
        e.CurrentWorksheet.Columns[0].Width = 2500;
        e.CurrentWorksheet.Columns[1].Width = 5000;
        e.CurrentWorksheet.Columns[2].Width = 3000;
        e.CurrentWorksheet.Columns[3].Width = 2100;
        e.CurrentWorksheet.Columns[4].Width = 2100;
        e.CurrentWorksheet.Columns[5].Width = 2100;
        e.CurrentWorksheet.Columns[6].Width = 2100;
        e.CurrentWorksheet.Columns[7].Width = 2100;
        e.CurrentWorksheet.Columns[8].Width = 2100;
        e.CurrentWorksheet.Columns[9].Width = 2100;
        e.CurrentWorksheet.Columns[10].Width = 2100;
        e.CurrentWorksheet.Columns[11].Width = 2100;
        e.CurrentWorksheet.Columns[12].Width = 2100;
        e.CurrentWorksheet.Columns[13].Width = 2100;
        e.CurrentWorksheet.Columns[14].Width = 2100;
        e.CurrentWorksheet.Columns[15].Width = 3500;
        e.CurrentWorksheet.Rows[3].Height = e.CurrentWorksheet.Rows[2].Height;

        //int cntPreStep = (ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index - 16) / 3;
        for (int i = 16; i < ugrdMBO.Columns.Count - 2; i++)
        {
            e.CurrentWorksheet.Columns[i].Width = 2100;
        }

        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[0].Value = "평가점수";
        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[0].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[0].CellFormat.Font.Color = System.Drawing.Color.White;
        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[0].CellFormat.BottomBorderColor = Color.White;
        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[1].Value = lblTotalPoint.InnerText;
        e.CurrentWorksheet.Rows[6 + ugrdMBO.Rows.Count].Cells[1].CellFormat.Alignment = HorizontalCellAlignment.Right;

        e.CurrentWorksheet.MergedCellsRegions.Add(7 + ugrdMBO.Rows.Count, 0, 7 + ugrdMBO.Rows.Count, 0);
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Height = 1000;
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].CellFormat.BottomBorderColor = Color.White;
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[1].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
        e.CurrentWorksheet.MergedCellsRegions.Add(7 + ugrdMBO.Rows.Count, 1, 7 + ugrdMBO.Rows.Count, 5);
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].Value = "종합\n실적보고";
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].CellFormat.WrapText = ExcelDefaultableBoolean.True;
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].CellFormat.Font.Color = System.Drawing.Color.White;
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[0].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[1].Value = txtReport.Value.ToString().Replace("<p>", "").Replace("</p>", "\n");
        e.CurrentWorksheet.Rows[7 + ugrdMBO.Rows.Count].Cells[1].CellFormat.WrapText = ExcelDefaultableBoolean.True;

        //차수별 평가의견
        if (this.ICOMMENTLIST.Length > 0)
        {
            int j = 1;
            foreach (string strComment in this.ICOMMENTLIST.Split(';'))
            {
                e.CurrentWorksheet.MergedCellsRegions.Add(8 + j - 1 + ugrdMBO.Rows.Count, 0, 8 + j - 1 + ugrdMBO.Rows.Count, 0);
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Height = 1000;
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].CellFormat.BottomBorderColor = Color.White;
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[1].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
                e.CurrentWorksheet.MergedCellsRegions.Add(8 + j - 1 + ugrdMBO.Rows.Count, 1, 8 + j - 1 + ugrdMBO.Rows.Count, 5);
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].Value = j.ToString() + "차 종합평가\n의견";
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].CellFormat.WrapText = ExcelDefaultableBoolean.True;
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].CellFormat.Font.Color = System.Drawing.Color.White;
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[0].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[1].Value = strComment.ToString().Replace("<p>", "").Replace("</p>", "\n");
                e.CurrentWorksheet.Rows[8 + j - 1 + ugrdMBO.Rows.Count].Cells[1].CellFormat.WrapText = ExcelDefaultableBoolean.True;
                j++;
            }
        }


        int stepcount = this.IESTTERM_STEP_ID - 1;        
        e.CurrentWorksheet.MergedCellsRegions.Add(8 + stepcount + ugrdMBO.Rows.Count, 0, 8 + stepcount + ugrdMBO.Rows.Count, 0);
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Height = 1000;
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].CellFormat.BottomBorderColor = Color.White;
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[1].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
        e.CurrentWorksheet.MergedCellsRegions.Add(8 + stepcount + ugrdMBO.Rows.Count, 1, 8 + stepcount + ugrdMBO.Rows.Count, 5);
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].Value = "피평가자\n의견";
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].CellFormat.WrapText = ExcelDefaultableBoolean.True;
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].CellFormat.Font.Color = System.Drawing.Color.White;
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[0].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[1].Value = txtFeedBack.Value.ToString().Replace("<p>", "").Replace("</p>", "\n");
        e.CurrentWorksheet.Rows[8 + stepcount + ugrdMBO.Rows.Count].Cells[1].CellFormat.WrapText = ExcelDefaultableBoolean.True;
    }

    private void DoBinding()
    {
        dtPreStepGrade.Clear();
        DoReSetControl();

        //if (hdfEmpRefId.Value == null || hdfEmpRefId.Value == "")
        //{
        //    if (!IsPostBack)
        //        return;
        //    ltrScript.Text = JSHelper.GetAlertScript("사원을 선택하세요.");
        //    return;
        //}

        //ITGT_DEPT_ID = DataTypeUtility.GetToInt32(hdfDeptRefId.Value);
        //ITGT_EMP_ID = DataTypeUtility.GetToInt32(hdfEmpRefId.Value);

        Biz_EmpInfos bizEmp = new Biz_EmpInfos();
        DataSet dsEmp = bizEmp.GetEmpInfo(ITGT_EMP_ID);
        if (dsEmp.Tables[0].Rows.Count > 0)
            txtEMPNAME.Text = dsEmp.Tables[0].Rows[0]["EMP_NAME"].ToString();
        Biz_DeptInfos bizDept = new Biz_DeptInfos();
        dsEmp = bizDept.GetDeptInfo(ITGT_DEPT_ID);
        if (dsEmp.Tables[0].Rows.Count > 0)
            txtDEPTNAME.Text = dsEmp.Tables[0].Rows[0]["DEPT_NAME"].ToString();
        hdfEmpRefId.Value = ITGT_EMP_ID.ToString();
        hdfDeptRefId.Value = ITGT_DEPT_ID.ToString();

        //Biz_Datas biz = new Biz_Datas();


        //DataSet ds = biz.Get3GAKpiDataList(ICOMP_ID
        //                                , IEST_ID
        //                                , IESTTERM_REF_ID
        //                                , IESTTERM_SUB_ID
        //                                , IEST_DEPT_ID
        //                                , IEST_EMP_ID
        //                                , ITGT_DEPT_ID
        //                                , ITGT_EMP_ID);

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

        DataTable dtEstEmpEstTargetMap = bizEstEmpEstTargetMap.Get3A_List(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , IEST_DEPT_ID
                                                                        , IEST_EMP_ID
                                                                        , ITGT_DEPT_ID).Tables[0];

        if (dtEstEmpEstTargetMap.Rows.Count > 0)
        {
            //이전차수 정보 테이블

            IESTTERM_STEP_ID = DataTypeUtility.GetToInt32(dtEstEmpEstTargetMap.Rows[0]["ESTTERM_STEP_ID"]);
            estterm_step_name = dtEstEmpEstTargetMap.Rows[0]["ESTTERM_STEP_NAME"].ToString() + " 평가";

            dtPreStepGrade = bizEstEmpEstTargetMap.Get3APre_Table7(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , IESTTERM_STEP_ID
                                                                        , IEST_DEPT_ID
                                                                        , IEST_EMP_ID
                                                                        , ITGT_DEPT_ID).Tables[0];

            DataTable dtComments =  bizEstEmpEstTargetMap.Get3APre_Table8(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , IESTTERM_STEP_ID
                                                                        , ITGT_DEPT_ID).Tables[0];

            foreach (DataRow dr in dtComments.Rows)
                this.ICOMMENTLIST += dr["COMMENT"].ToString().Replace(";", "") + ";";
            if (this.ICOMMENTLIST.Length > 0)
                this.ICOMMENTLIST = this.ICOMMENTLIST.Substring(0, this.ICOMMENTLIST.Length - 1);


            DataTable dtEST  = bizEstEmpEstTargetMap.Get3APre_Table9(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , ITGT_DEPT_ID).Tables[0];


            foreach (DataRow dr in dtEST.Rows)
                this.IESTEMPLIST += dr["EST_EMP_ID"].ToString() + ";";
            if (this.IESTEMPLIST.Length > 0)
                this.IESTEMPLIST = this.IESTEMPLIST.Substring(0, this.IESTEMPLIST.Length - 1);



            DataTable dtNotNowWithEstView = bizEstEmpEstTargetMap.Get3APre_Table6(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , ITGT_DEPT_ID).Tables[0];

            if (IUSER_TYPE == 1) //평가자로 볼 때
            {
                DataRow[] dr = dtNotNowWithEstView.Select("ESTTERM_STEP_ID = " + (IESTTERM_STEP_ID - 1));
                if (dr.Length > 0)
                    IEST_STEP_PREV = dr[0]["STATUS"].ToString();
                dr = dtNotNowWithEstView.Select("ESTTERM_STEP_ID = " + (IESTTERM_STEP_ID + 1));
                if (dr.Length > 0)
                    IEST_STEP_NEXT = dr[0]["STATUS"].ToString();

                dr = dtNotNowWithEstView.Select("ESTTERM_STEP_ID <> " + IESTTERM_STEP_ID); //2차 평가이상이 환경설정되면 다음을 FOR문으로 늘려야 함
                if (dr.Length > 0)
                {
                    tdStep.Visible = tdStepDesc.Visible = true;
                    lblStep.Text = dr[0]["ESTTERM_STEP_NAME"].ToString() + "평가 상태";
                    lblStepDesc.Text = dr[0]["STATUS_NAME"].ToString();
                    switch (dr[0]["STATUS"].ToString())
                    {
                        case "N":
                            lblStepDesc.ForeColor = Color.Red;
                            break;
                        case "O":
                            lblStepDesc.ForeColor = Color.Blue;
                            break;
                        case "C":
                            lblStepDesc.ForeColor = Color.Black;
                            break;
                    }
                }
            }
            else
            {
                DataRow[] dr = dtNotNowWithEstView.Select("ESTTERM_STEP_ID <> " + IESTTERM_STEP_ID); //2차 평가이상이 환경설정되면 다음을 FOR문으로 늘려야 함
                if (dr.Length > 0)
                {
                    tdStep.Visible = tdStepDesc.Visible = true;
                    lblStep.Text = dr[0]["ESTTERM_STEP_NAME"].ToString() + "평가 상태";
                    lblStepDesc.Text = dr[0]["STATUS_NAME"].ToString();
                    switch (dr[0]["STATUS"].ToString())
                    {
                        case "N":
                            lblStepDesc.ForeColor = Color.Red;
                            break;
                        case "O":
                            lblStepDesc.ForeColor = Color.Blue;
                            break;
                        case "C":
                            lblStepDesc.ForeColor = Color.Black;
                            break;
                    }
                }
            }

            DataRow[] drw = dtNotNowWithEstView.Select("", "ESTTERM_STEP_ID ASC");


            this.IEST_STEP_LAST = "2";
            this.ILAST_STEP_ID = 2;

            if (drw.Length > 0)
            {
                this.IEST_STEP_LAST = drw[drw.Length - 1]["STATUS"].ToString();

                this.ILAST_STEP_ID = DataTypeUtility.GetToInt32(drw[drw.Length - 1]["ESTTERM_STEP_ID"]);
            }

        }


        DataTable dtCommandNStatus = bizEstEmpEstTargetMap.Get3APre_Table4(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , IESTTERM_STEP_ID
                                                                        , IEST_DEPT_ID
                                                                        , IEST_EMP_ID
                                                                        , ITGT_DEPT_ID).Tables[0];



        if (dtCommandNStatus.Rows.Count > 0)
        {
            IEST_STATUS = dtCommandNStatus.Rows[0]["STATUS"].ToString();
            txtOpinion.Value = dtCommandNStatus.Rows[0]["COMMENT"].ToString();
        }


        DataTable dtEstStatus = bizEstEmpEstTargetMap.Get3APre_Table1(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , ITGT_DEPT_ID).Tables[0];

        if (dtEstStatus.Rows.Count > 0)
        {
            IREPORT_STATUS = dtEstStatus.Rows[0]["STATUS"].ToString();
            iBtnTargetFile_Down.Visible = (dtEstStatus.Rows[0]["REPORT_FILE"].ToString() == "") ? false : true;
            txtReport.Value = dtEstStatus.Rows[0]["REPORT"].ToString();
            hdfTargetReasonFile.Value = dtEstStatus.Rows[0]["REPORT_FILE"].ToString();
            ITOTAL_EST_STATUS_TRUE = (dtEstStatus.Rows[0]["EST_STATUS"].ToString() == "X" ? false : true);
        }


        DataTable dtFeedBack = bizEstEmpEstTargetMap.Get3APre_Table5(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , ITGT_DEPT_ID).Tables[0];


        if (dtFeedBack.Rows.Count > 0)
        {
            if (dtFeedBack.Rows[0]["CONFIRM_TYPE"].ToString() != "RJT")
            {
                txtFeedBack.Value = dtFeedBack.Rows[0]["COMMENT"].ToString();
                IEST_FEEDBACK_SEQ = DataTypeUtility.GetToInt32(dtFeedBack.Rows[0]["SEQ"]); //IPT: 저장, AGR: 확정, RJT: 거절
            }
            IEST_FEEDBACK_TYPE = dtFeedBack.Rows[0]["CONFIRM_TYPE"].ToString();

            if (IEST_FEEDBACK_TYPE == "RJT" && IEST_STATUS != "C")
            {
                trReject.Visible = true;
                lblReject.Text = dtFeedBack.Rows[0]["COMMENT"].ToString();
            }
        }


        //이전평가차수 평가정보 처리
        if (dtEstEmpEstTargetMap.Rows.Count > 0)
        {
            DataView dtView = new DataView(dtPreStepGrade);
            DataTable dtDist = dtView.ToTable(true, "ESTTERM_STEP_ID", "ESTTERM_STEP_NAME");
            if (dtDist.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDist.Rows)
                {
                    dtEstEmpEstTargetMap.Columns.Add("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString(), typeof(double));
                    dtEstEmpEstTargetMap.Columns.Add("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString(), typeof(double));
                    dtEstEmpEstTargetMap.Columns.Add("GRADE_" + dr["ESTTERM_STEP_ID"].ToString(), typeof(string));
                }
                foreach (DataRow dr in dtEstEmpEstTargetMap.Rows)
                {
                    foreach (DataRow drValue in dtDist.Rows)
                    {
                        DataRow drPre = dtPreStepGrade.Select("KPI_REF_ID = " + dr["KPI_REF_ID"].ToString())[0];
                        dr["SCORE_WEIGHT_" + drValue["ESTTERM_STEP_ID"].ToString()] = drPre["SCORE_WEIGHT"];
                        dr["SCORE_ORI_" + drValue["ESTTERM_STEP_ID"].ToString()] = drPre["SCORE_ORI"];
                        dr["GRADE_" + drValue["ESTTERM_STEP_ID"].ToString()] = drPre["GRADE_NAME"];
                    }
                }
                dtEstEmpEstTargetMap.AcceptChanges();

            }
            
        }

        ugrdMBO.Clear();
        ugrdMBO.DataSource = dtEstEmpEstTargetMap;
        ugrdMBO.DataBind();

        lblRowCount.Text = ugrdMBO.Rows.Count.ToString("#,##0");

        if (dtEstEmpEstTargetMap.Rows.Count == 0)
        {
            lblTotalPoint.InnerText = "0";
            IREPORT_STATUS = "N";
            return;
        }

        object objTotalPoint = dtEstEmpEstTargetMap.Compute("SUM(SCORE_WEIGHT)", "");
        lblTotalPoint.InnerText = DataTypeUtility.GetToDouble(objTotalPoint).ToString();


        DataTable dtClosing = bizEstEmpEstTargetMap.Get3APre_Table2(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID).Tables[0];


        if (dtClosing.Rows.Count > 0)    
        {
            if (dtClosing.Rows[0]["STATUS_YN"].ToString() == "Y")
                ICONFIRM_EST = true;

            string ndate = DateTime.Now.ToString("yyyyMMdd");
            string sdate = DataTypeUtility.GetToDateTime(dtClosing.Rows[0]["START_DATE"]).ToString("yyyyMMdd");
            string edate = DataTypeUtility.GetToDateTime(dtClosing.Rows[0]["END_DATE"]).ToString("yyyyMMdd");
            if (string.Compare(ndate, sdate) >= 0 && string.Compare(ndate, edate) <= 0)
                IEST_TERM_STATUS = true;
        }

        DataTable dtApproval = bizEstEmpEstTargetMap.Get3APre_Table3(ICOMP_ID
                                                                        , IEST_ID
                                                                        , IESTTERM_REF_ID
                                                                        , IESTTERM_SUB_ID
                                                                        , IEST_DEPT_ID
                                                                        , IEST_EMP_ID
                                                                        , ITGT_DEPT_ID).Tables[0];


        if (dtApproval.Rows.Count == 0)
            IRESULT_APP_OK = true;

        if (!IEST_TERM_STATUS) // 평가기간이아니면
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가기간이 아닙니다.");
            return;
        }

        tdMap.Visible = true;

        if (!IRESULT_APP_OK) //모든 결재가 완료가 되지 않았으면
        {
            ltrScript.Text = JSHelper.GetAlertScript("실적이 모두 완료되지 않았습니다.");
            return;
        }

        img1.Src = "../images/status/P.gif";

        DoStatus();

        if (this.IUSER_TYPE == 0) //관리자, 성과평가관리자
        {
            ibtnCancelEst.Visible = ibtnCancelFeedBack.Visible = ibtnCancelReport.Visible 
                = ibtnConfirmEst.Visible = ibtnConfirmFeedBack.Visible = ibtnConfirmReport.Visible = ibtnEst.Visible 
                = ibtnFeedBack.Visible = ibtnOpinion.Visible = ibtnReport.Visible = ibtnSave.Visible 
                = ibtnSaveEst.Visible = ibtnSaveFeedBack.Visible = ibtnSaveReport.Visible = iBtnTargetFile_Up.Visible = false;
        }

    }

    private void DoReSetControl()
    {
        ugrdMBO.Clear();
        this.ICOMMENTLIST = "";
        this.IESTEMPLIST = "";
        iBtnTargetFile_Down.Visible = iBtnTargetFile_Up.Visible = false;
        hdfTargetReasonFile.Value = txtReport.Value = txtOpinion.Value = txtFeedBack.Value = "";
        IREPORT_STATUS = IEST_STATUS = "N";
        ITOTAL_EST_STATUS_TRUE = false;
        IEST_FEEDBACK_SEQ = 0;
        IEST_STEP_PREV = IEST_STEP_NEXT = IEST_STEP_LAST = IEST_FEEDBACK_TYPE = "";
        IEST_TERM_STATUS = IRESULT_APP_OK = false;
        IESTTERM_STEP_ID = 0;

        ibtnReport.Style["display"] = "none";

        tdMap.Visible = false;
        img1.Src = img2.Src = img3.Src = img4.Src = "../images/status/N.gif";
        ibtnConfirm.ImageUrl = "../images/btn/b_003.gif"; //닫기로 초기화 b_305



        ibtnSave.Style["display"]
            = spnReport.Style["display"] = spnOpinion.Style["display"] = spnFeedBack.Style["display"]
            = ibtnViewReport.Style["display"] = ibtnViewOpinion.Style["display"] = ibtnViewFeedBack.Style["display"]
            = tdReport.Style["display"] = tdEst.Style["display"] = tdFeedBack.Style["display"]
            = ibtnEst.Style["display"] = ibtnOpinion.Style["display"] = ibtnFeedBack.Style["display"] = "none";
        txtReport.Visible = txtOpinion.Visible = txtFeedBack.Visible = false;

        ibtnSaveReport.Visible = ibtnConfirmReport.Visible = ibtnCancelReport.Visible
            = ibtnSaveEst.Visible = ibtnConfirmEst.Visible = ibtnCancelEst.Visible
            = ibtnSaveFeedBack.Visible = ibtnConfirmFeedBack.Visible = ibtnCancelFeedBack .Visible = false;
        //ibtnCloseReport.Visible = ibtnCloseOpinion.Visible = ibtnCloseFeedBack.Visible = false;
        ibtnCloseReport.Style["display"] = ibtnCloseOpinion.Style["display"] = ibtnCloseFeedBack.Style["display"] = "none";
    }

    private void DoStatus()
    {
        // 피평가자가 평가중이지 않은 차수를 들고 왔을때 표현되는 확인
        // 피평가자가 평가중인 차수 들고 왔을 때 표현되는 확인
        lblEstOpinion.Text = estterm_step_name.Substring(0, 2) + " 종합<br />평가의견";
        //평가상태에 따라
        if (IEST_STATUS == "C" || IEST_STATUS == "P" || IEST_STATUS == "E") //평가확정, 피드백저장, 피드백확정
        {
            if (IEST_STATUS == "E") //피드백확정
            {
                img1.Src = img2.Src = img3.Src = img4.Src = "../images/status/E.gif";
                spnReport.InnerHtml = txtReport.Value;
                spnOpinion.InnerHtml = txtOpinion.Value;
                spnFeedBack.InnerHtml = txtFeedBack.Value;
                spnReport.Style["display"] = spnOpinion.Style["display"] = spnFeedBack.Style["display"] 
                    = ibtnViewReport.Style["display"] = ibtnViewOpinion.Style["display"] = ibtnViewFeedBack.Style["display"] = "block";
                ibtnCloseFeedBack.Visible = true;
                ibtnCloseReport.Visible = ibtnCloseOpinion.Visible = ibtnCloseFeedBack.Visible = true;
                DoActiveGrade(false);
            }
            else if (IEST_STATUS == "P") //피드백중
            {
                img1.Src = img2.Src = img3.Src = "../images/status/E.gif";
                img4.Src = "../images/status/P.gif";
                ibtnViewReport.Style["display"] = ibtnViewOpinion.Style["display"] = "block";
                spnReport.InnerHtml = txtReport.Value;
                spnOpinion.InnerHtml = txtOpinion.Value;
                spnReport.Style["display"] = spnOpinion.Style["display"] = "block";
                if (IUSER_TYPE == 2)
                {
                    ibtnConfirmFeedBack.Visible = ibtnSaveFeedBack.Visible = ibtnCancelFeedBack.Visible = true;
                    txtFeedBack.Visible = true;
                    ibtnFeedBack.Style["display"] = "block";
                    ibtnCloseReport.Visible = ibtnCloseOpinion.Visible = true;
                }
                else
                {
                    spnFeedBack.InnerHtml = txtFeedBack.Value;
                    spnFeedBack.Style["display"] = "block";
                    ibtnCloseReport.Visible = ibtnCloseOpinion.Visible = true;
                    ibtnViewFeedBack.Style["display"] = "block";
                    ibtnCloseFeedBack.Visible = true;
                }
                DoActiveGrade(false);
            }
            else if (IEST_STATUS == "C") //평가확정
            {
                img1.Src = img2.Src = img3.Src = "../images/status/E.gif";
                if (this.IEST_STEP_LAST == "C")
                    img4.Src = "../images/status/P.gif";
                else
                    img4.Src = "../images/status/N.gif";
                spnReport.InnerHtml = txtReport.Value;
                spnOpinion.InnerHtml = txtOpinion.Value;
                spnReport.Style["display"] = spnOpinion.Style["display"] = ibtnViewReport.Style["display"] = "block";
                lblEstOpinion.Text  = estterm_step_name.Substring(0, 2) + " 종합<br />평가의견";
                if (IUSER_TYPE == 1)
                {
                    ibtnCancelEst.Visible = ibtnCloseOpinion.Visible = true;
                    tdEst.Style["display"] = "none";
                    ibtnViewOpinion.Style["display"] = "block";
                    if (IEST_STEP_NEXT != "")
                        if (IEST_STEP_NEXT == "O") //다음차수가 평가중이면(O) 확정취소안된다. 미평가 또는 평가완료는 취소할수있다.
                            ibtnCancelEst.Visible = false;
                }
                else
                {
                    ibtnFeedBack.Style["display"] = "block";
                    ibtnViewOpinion.Style["display"] = "block";
                    ibtnSaveFeedBack.Visible = true;
                    txtFeedBack.Visible = true;
                    ibtnCloseReport.Visible = ibtnCloseOpinion.Visible = true;
                    if (IEST_STEP_LAST != "C") //최종평가차수가 평가완료가 되지 않았으면
                    {
                        ibtnFeedBack.Style["display"] = "none";
                        img4.Src = "../images/status/N.gif";
                    }
                }
                DoActiveGrade(false);
            }
        }
        else if (IEST_STATUS == "O") //평가중
        {
            img1.Src = "../images/status/E.gif";
            img2.Src = img3.Src = "../images/status/P.gif";
            spnReport.InnerHtml = txtReport.Value;
            spnReport.Style["display"] = "block";
            ibtnViewReport.Style["display"] = "block";
            lblEstOpinion.Text = estterm_step_name.Substring(0, 2) + " 종합<br />평가의견";
            ibtnCloseReport.Visible = true;
            if (IUSER_TYPE == 2)
            {
                ibtnCloseOpinion.Visible = true;
                spnOpinion.InnerHtml = txtOpinion.Value;
                spnOpinion.Style["display"] = "block";
                txtOpinion.Visible = false;
                ibtnViewOpinion.Style["display"] = "block";
                DoActiveGrade(false);
            }
            else
            {
                ibtnSaveEst.Visible = ibtnConfirmEst.Visible = true;
                txtOpinion.Visible = true;
                ibtnOpinion.Style["display"] = "block";
                DoActiveGrade(true);
            }
        }
        else //미평가 IEST_STATUS='N'
        {
            switch (IREPORT_STATUS)
            {
                case "C": //종합실적보고 확정
                    if (ITOTAL_EST_STATUS_TRUE) //다른 차수가 평가가 시작되었다면 실적보고 수정 못하도록
                    {
                        img1.Src = "../images/status/E.gif";
                        img2.Src = "../images/status/P.gif";
                        img3.Src = "../images/status/N.gif";
                        spnReport.InnerHtml = txtReport.Value;
                        spnReport.Style["display"] = "block";
                        txtReport.Visible = false;
                        ibtnViewReport.Style["display"] = "block";
                        lblEstOpinion.Text = estterm_step_name.Substring(0, 2) + " 종합<br />평가의견";
                        ibtnCloseReport.Visible = true;
                        if (IUSER_TYPE == 2)
                            DoActiveGrade(false);
                        else
                        {
                            ibtnSaveEst.Style["display"] = ibtnConfirmEst.Style["display"] = "block";
                            txtOpinion.Visible = true;
                            ibtnEst.Style["display"] = "block";
                            if (IEST_STEP_PREV != "C" && IESTTERM_STEP_ID > 2) //이전평가차수가 평가완료상태가 아니고 현재평가가 1차평가 이상이면
                            {
                                ibtnEst.Style["display"] = "none";
                                img2.Src = "../images/status/N.gif";
                            }
                            DoActiveGrade(false);
                        }
                    }
                    else
                    {
                        img1.Src = "../images/status/E.gif";
                        img2.Src = "../images/status/P.gif";
                        if (IUSER_TYPE == 2)
                        {
                            ibtnViewReport.Style["display"] = "block";
                            ibtnCancelReport.Visible = true;
                            spnReport.InnerHtml = txtReport.Value;
                            spnReport.Style["display"] = "block";
                            txtReport.Visible = false;
                        }
                        else
                        {
                            ibtnViewReport.Style["display"] = "block";
                            spnReport.InnerHtml = txtReport.Value;
                            spnReport.Style["display"] = ibtnEst.Style["display"] = "block";
                            if (IEST_STEP_PREV != "C" && IESTTERM_STEP_ID > 2) //이전평가차수가 평가완료상태가 아니고 현재평가가 1차평가 이상이면
                            {
                                ibtnEst.Style["display"] = "none";
                                img2.Src = "../images/status/N.gif";
                            }
                            txtReport.Visible = false;
                            ibtnCloseReport.Visible = true;
                        }
                        DoActiveGrade(false);
                    }
                    break;
                case "O": //입력상태
                    img1.Src = "../images/status/P.gif";
                    if (IUSER_TYPE == 2)
                    {
                        ibtnReport.Style["display"] = "block";
                        ibtnSaveReport.Visible = ibtnConfirmReport.Visible = true;
                        iBtnTargetFile_Up.Visible = txtReport.Visible = true;
                    }
                    else
                    {
                        ibtnCloseReport.Visible = true;
                        spnReport.InnerHtml = txtReport.Value;
                        spnReport.Style["display"] = "block";
                        txtReport.Visible = false;
                        ibtnViewReport.Style["display"] = "block";
                    }
                    DoActiveGrade(false);
                    break;
                case "N":// 종합실적보고가 초기
                    img1.Src = "../images/status/P.gif";
                    if (IUSER_TYPE == 2)
                    {
                        ibtnReport.Style["display"] = "block";
                        ibtnSaveReport.Visible = true;
                        iBtnTargetFile_Up.Visible = txtReport.Visible = true;
                    }
                    DoActiveGrade(false);
                    break;
            }
        }

        if (ICONFIRM_EST)    // 평가가 확정되었다면
        {
            ibtnSave.Style["display"]
                = ibtnSaveReport.Style["display"] = ibtnConfirmReport.Style["display"] = ibtnCancelReport.Style["display"]
                = ibtnSaveEst.Style["display"] = ibtnConfirmEst.Style["display"] = ibtnCancelEst.Style["display"]
                = ibtnSaveFeedBack.Style["display"] = ibtnCancelFeedBack.Style["display"] = ibtnConfirmFeedBack.Style["display"] = "none";
            DoActiveGrade(false);
            ltrScript.Text = JSHelper.GetAlertScript("전체 평가가 확정된 상태입니다.");
        }
    }

    private void DoActiveGrade(bool status)
    {
        string imgPop = "<img src='../images/icon/subtitle.gif' alt='' onclick='doCheckingPoint(\"{0}\",\"{1}\",\"{2}\",\"{3}\")' />";

        if (IUSER_TYPE == 0)
        {
            status = false;
        }
        bool isCompleteGrade = true;
        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            UltraGridRow uRow = ugrdMBO.Rows[i];
            TemplatedColumn colGrade = (TemplatedColumn)ugrdMBO.Rows[i].Band.Columns.FromKey("GRADE");
            DropDownList ddlCGrade = (DropDownList)((CellItem)colGrade.CellItems[ugrdMBO.Rows[i].BandIndex]).FindControl("ddlGrade");
            ddlCGrade.Enabled = false;

            string kpi_pool_ref_id = DataTypeUtility.GetValue(uRow.Cells.FromKey("KPI_POOL_REF_ID").Value);
            string kpi_ref_id = DataTypeUtility.GetValue(uRow.Cells.FromKey("KPI_REF_ID").Value);
            string score_ori_list = DataTypeUtility.GetValue(uRow.Cells.FromKey("SCORE_ORI_LIST").Value);

            if (status)
            {
                if (uRow.Cells.FromKey("KPI_GROUP_REF_ID").Value.ToString().Trim() == "QLT")
                {
                    ddlCGrade.Enabled = true;
                    
                }
                else if (this.IEST_QTT_MBO_YN == "Y")
                {
                    ddlCGrade.Enabled = true;
                    
                }
                if (ddlCGrade.Enabled && this.IMBO_SCORE_ESTIMATE_YN == "Y")
                {
                    ugrdMBO.Rows[i].Cells.FromKey("SCORE_ORI").AllowEditing = AllowEditing.Yes;
                }


                uRow.Cells.FromKey("GRADE_POP").Value = string.Format(imgPop, kpi_pool_ref_id, kpi_ref_id, uRow.Index, score_ori_list);
            }

            if (ddlCGrade.SelectedIndex == 0)
                isCompleteGrade = false;

            colGrade = (TemplatedColumn)ugrdMBO.Rows[i].Band.Columns.FromKey("EST_REASON");
            System.Web.UI.WebControls.Image CButton = (System.Web.UI.WebControls.Image)((CellItem)colGrade.CellItems[ugrdMBO.Rows[i].BandIndex]).FindControl("btnReason");
            if (ddlCGrade.SelectedIndex == 1 || ddlCGrade.SelectedIndex == ddlCGrade.Items.Count - 1)
                CButton.Style["display"] = "block";


            if (status) // 평가중일때만 보이게..
            {
                if (DataTypeUtility.GetValue(uRow.Cells.FromKey("BASIS_USE_YN").Value) == "EQL")
                {
                    uRow.Cells.FromKey("GRADE_POP").Value = string.Format(imgPop, kpi_pool_ref_id, kpi_ref_id, uRow.Index, score_ori_list);
                    CButton.Style["display"] = "block";
                }
                else
                {
                    uRow.Cells.FromKey("GRADE_POP").Value = "";
                    CButton.Style["display"] = "none";
                }
            }
        }
        if (!status)
            txtGRADE_REASON.ReadOnly = true;
        else
            txtGRADE_REASON.ReadOnly = false;

        if (isCompleteGrade && IEST_STATUS != "N")
            img2.Src = "../images/status/E.gif";
        else
        {
            img3.Src = "../images/status/N.gif";
            ibtnOpinion.Style["display"] = "none";
            if (IEST_STATUS == "O")
                ibtnSave.Style["display"] = "block";
            ibtnViewOpinion.Style["display"] = "none";
        }


    }

    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {
        DataView dtView = new DataView(dtPreStepGrade);
        if (dtPreStepGrade.Rows.Count > 0)
        {
            DataTable dtDist = dtView.ToTable(true, "ESTTERM_STEP_ID", "ESTTERM_STEP_NAME");

            if (dtDist.Rows.Count > 0)
            {
                int currPointColumn = ugrdMBO.Columns.FromKey("SCORE_WEIGHT").Index;
                foreach (DataRow dr in dtDist.Rows)
                {
                    ugrdMBO.Columns.Insert(currPointColumn, "GRADE_" + dr["ESTTERM_STEP_ID"].ToString());
                    ugrdMBO.Columns.FromKey("GRADE_" + dr["ESTTERM_STEP_ID"].ToString()).BaseColumnName = "GRADE_" + dr["ESTTERM_STEP_ID"].ToString();
                    ugrdMBO.Columns.FromKey("GRADE_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Caption = "등급";
                    //ugrdMBO.Columns.FromKey("GRADE_" + dr["ESTTERM_STEP_ID"].ToString()).CellStyle.Width = Unit.Pixel(60);
                    //ugrdMBO.Columns.FromKey("GRADE_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Style.Width = Unit.Pixel(60);
                    ugrdMBO.Columns.FromKey("GRADE_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Style.HorizontalAlign = HorizontalAlign.Center;
                    ugrdMBO.Columns.FromKey("GRADE_" + dr["ESTTERM_STEP_ID"].ToString()).CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    ugrdMBO.Columns[currPointColumn].Width = Unit.Pixel(60);

                    ugrdMBO.Columns.Insert(currPointColumn, "SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString());
                    ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).BaseColumnName = "SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString();
                    ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Caption = "평.점수";
                    //ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).CellStyle.Width = Unit.Pixel(50);
                    //ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Style.Width = Unit.Pixel(50);
                    ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Style.HorizontalAlign = HorizontalAlign.Center;
                    ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    ugrdMBO.Columns.FromKey("SCORE_ORI_" + dr["ESTTERM_STEP_ID"].ToString()).Format = "###,###,##0.####";
                    ugrdMBO.Columns[currPointColumn].Width = Unit.Pixel(50);

                    ugrdMBO.Columns.Insert(currPointColumn, "SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString());
                    ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).BaseColumnName = "SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString();
                    ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Caption = "가.점수";
                    //ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).CellStyle.Width = Unit.Pixel(50);
                    //ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Style.Width = Unit.Pixel(50);
                    ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).Header.Style.HorizontalAlign = HorizontalAlign.Center;
                    ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).Format = "###,###,##0.####";
                    ugrdMBO.Columns[currPointColumn].Width = Unit.Pixel(50);

                    //ugrdMBO.Columns.FromKey("SCORE_WEIGHT_" + dr["ESTTERM_STEP_ID"].ToString()).Header.RowLayoutColumnInfo.SpanX = 3;
                }
            }
        }

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        for (int i = 0; i < 10; i++)
        {
            ch = e.Layout.Bands[0].Columns[i].Header;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = i;
            ch.RowLayoutColumnInfo.SpanY = 2;
            ch.Fixed = true;
        }

        for (int i = 15; i < 16; i++)
        {
            ch = e.Layout.Bands[0].Columns[i].Header;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = i;
            ch.RowLayoutColumnInfo.SpanY = 2;
        }

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "평가등급";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 10;
        //ch.RowLayoutColumnInfo.SpanX = 5;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        int j = 0;

        if (dtPreStepGrade.Rows.Count > 0)
        {
            DataTable dtDist = dtView.ToTable(true, "ESTTERM_STEP_ID", "ESTTERM_STEP_NAME");
            for (int i = dtDist.Rows.Count - 1; i >= 0; i--)
            {
                ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
                ch.Caption = dtDist.Rows[i]["ESTTERM_STEP_NAME"] + " 평가";
                ch.Style.ForeColor = Color.LightGray;
                ch.RowLayoutColumnInfo.OriginY = 0;
                ch.RowLayoutColumnInfo.OriginX = 16 + (j * 3);
                ch.RowLayoutColumnInfo.SpanX = 3;
                ch.Style.Height = Unit.Pixel(20);
                e.Layout.Bands[0].HeaderLayout.Add(ch);
                e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                j++;
            }
        }

        if (dtPreStepGrade.Rows.Count > 0)
        {
            DataTable dtDist = dtView.ToTable(true, "ESTTERM_STEP_ID", "ESTTERM_STEP_NAME");
            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "* " + estterm_step_name;
            ch.Style.Font.Bold = true;
            ch.Style.Font.Underline = true;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 16 + (dtDist.Rows.Count * 3);
            ch.RowLayoutColumnInfo.SpanX = 5;
            ch.Style.Height = Unit.Pixel(20);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "상세정보조회";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 21 + (dtDist.Rows.Count * 3);
            ch.RowLayoutColumnInfo.SpanX = 2;
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        else
        {
            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "* " + estterm_step_name;
            ch.Style.Font.Bold = true;
            ch.Style.Font.Underline = true;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 16;
            ch.RowLayoutColumnInfo.SpanX = 5;
            ch.Style.Height = Unit.Pixel(20);
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "상세정보조회";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 21;
            ch.RowLayoutColumnInfo.SpanX = 2;
            e.Layout.Bands[0].HeaderLayout.Add(ch);
            e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }
    }
    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
        TemplatedColumn colGrade = (TemplatedColumn)e.Row.Band.Columns.FromKey("GRADE");
        DropDownList ddlCGrade = (DropDownList)((CellItem)colGrade.CellItems[e.Row.BandIndex]).FindControl("ddlGrade");


        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);



        ddlCGrade.DataSource = ddlGrade_hdf.DataSource;
        ddlCGrade.DataTextField = ddlGrade_hdf.DataTextField;
        ddlCGrade.DataValueField = ddlGrade_hdf.DataValueField;
        ddlCGrade.DataBind();

        ddlCGrade.Items.Insert(0, "::선택::");

        e.Row.Cells.FromKey("GRADE_REASON").Value = drw["GRADE_REASON"].ToString().Replace("\r\n", "<br />");

        if (drw["KPI_GROUP_REF_ID"].ToString().Trim() == "QLT") 
            PageUtility.FindByValueDropDownList(ddlCGrade, drw["GRADE"]);
        else
        {
            // 계량지표 초기값 설정
            if (drw["GRADE"].ToString().Trim() == "")
            {
                double initPoint = (DataTypeUtility.GetToDouble(drw["TARGET_TS"]) == 0 ? 0 : DataTypeUtility.GetToDouble(drw["RESULT_TS"]) / DataTypeUtility.GetToDouble(drw["TARGET_TS"]) * 100);
                int sValue = ddlCGrade.Items.Count - 1;
                for (int i = 1; i < ddlCGrade.Items.Count - 1; i++)
                {
                    if (initPoint >= DataTypeUtility.GetToDouble(ddlGradePoint_hdf.Items[i].Text.Trim()))
                    {
                        sValue = i;
                        break;
                    }
                }
                ddlCGrade.SelectedIndex = sValue;
                e.Row.Cells.FromKey("SCORE_WEIGHT").Value = DataTypeUtility.GetToDouble(ddlGradePoint_hdf.Items[sValue].Text.Trim()) * DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("WEIGHT").Value) / 100;
                e.Row.Cells.FromKey("SCORE_ORI").Value = DataTypeUtility.GetToDouble(ddlGradePoint_hdf.Items[sValue].Text.Trim());

                if (sValue == 1 || sValue == ddlCGrade.Items.Count - 1)
                    e.Row.Cells.FromKey("GRADE_REASON").Value = "계량평가 자동계산";
            }
            else
                PageUtility.FindByValueDropDownList(ddlCGrade, drw["GRADE"]);
        }

        //최초 등급비활성화
        ddlCGrade.Enabled = false;




        e.Row.Cells.FromKey("GRADE_BINDED").Value = ddlCGrade.SelectedIndex;
        e.Row.Cells.FromKey("SCORE_BINDED").Value = e.Row.Cells.FromKey("SCORE_ORI").Value;
        e.Row.Cells.FromKey("GRADE_ORG").Value = ddlGrade_hdf.Items.IndexOf(ddlGrade_hdf.Items.FindByValue(e.Row.Cells.FromKey("GRADE_ORG").Value.ToString()));

        colGrade = (TemplatedColumn)e.Row.Band.Columns.FromKey("EST_REASON");
        System.Web.UI.WebControls.Image CButton = (System.Web.UI.WebControls.Image)((CellItem)colGrade.CellItems[e.Row.BandIndex]).FindControl("btnReason");
        //CButton.Style["display"] = "none";


        if (DataTypeUtility.GetValue(e.Row.Cells.FromKey("BASIS_USE_YN").Value).Equals("EQL"))
        {
            CButton.Style["display"] = "block";
            //e.Row.Cells.FromKey("GRADE_POP").Value = string.Format(imgPop, kpi_pool_ref_id, kpi_ref_id, e.Row.Index, score_ori_list);
        }
        else
        {
            CButton.Style["display"] = "none";
            //e.Row.Cells.FromKey("GRADE_POP").Value = "";
        }

        e.Row.Cells.FromKey("APP_STATUS").Text = string.Format("<div class='stext'><img src='{0}' alt='{1}' /></div>", Biz_Com_Approval_Info.GetAppImageUrl(drw["APP_STATUS"].ToString()), Biz_Com_Approval_Info.GetAppImageText(drw["APP_STATUS"].ToString()));
        e.Row.Cells.FromKey("APP_STATUS_NAME").Value = Biz_Com_Approval_Info.GetAppImageText(drw["APP_STATUS"].ToString());






        if (DT_EQT_EQL_RATIO == null)
        {
            Biz_Bsc_Kpi_Eqt_Eql bizBscKpiEqtEql = new Biz_Bsc_Kpi_Eqt_Eql();
            DT_EQT_EQL_RATIO = bizBscKpiEqtEql.Get_Kpi_Eqt_Eql_Ratio(ESTTERM_REF_ID
                                                                    , Biz_Bsc_Kpi_Eqt_Eql.EST_TYPE.TOTAL
                                                                    , 0
                                                                    , 0
                                                                    , ""
                                                                    , ""
                                                                    , "");
        }

        DataTable ratioInfo = DataTypeUtility.FilterSortDataTable(DT_EQT_EQL_RATIO, string.Format("KPI_REF_ID='{0}'", kpi_ref_id));

        //DT : 정량
        //MT : 정성
        e.Row.Cells.FromKey("SCORE_DT").Value = e.Row.Cells.FromKey("SCORE_ORI").Value;
        if (e.Row.Cells.FromKey("SCORE_MT").Value == null)
            e.Row.Cells.FromKey("SCORE_MT").Value = "";

        if (ratioInfo.Rows.Count > 0)
        {
            e.Row.Cells.FromKey("RATIO_DT").Value = DataTypeUtility.GetString(ratioInfo.Rows[0]["EQT"]);
            e.Row.Cells.FromKey("RATIO_MT").Value = DataTypeUtility.GetString(ratioInfo.Rows[0]["EQL"]);
        }
    }

    protected void ibtnSaveReport_Click(object sender, ImageClickEventArgs e)
    {
        int emp_id = EMP_REF_ID;

        if (IUSER_TYPE.Equals(2))
            emp_id = -1;
        
        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboReport(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , ITGT_DEPT_ID
                                , emp_id
                                , txtReport.Value
                                , hdfTargetReasonFile.Value
                                , "O"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
            DoBinding();
            tdReport.Style.Add("display", "block");
            ibtnReport.ImageUrl = "../images/btn/b_003.gif";
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas biz = new Biz_Datas();
        object[,] objGrade = new object[ugrdMBO.Rows.Count, 6];
        double[] ScoreMT = new double[ugrdMBO.Rows.Count];
        string[] ymd = new string[ugrdMBO.Rows.Count];


        TemplatedColumn colGrade;
        DropDownList ddlCGrade;
        int saveCnt = 0;
        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            string grade = string.Empty;

            //if (ugrdMBO.Rows[i].Band.Columns.FromKey("GRADE").Hidden)
            //{
            //   grade = DataTypeUtility.GetValue(ugrdMBO.Rows[i].Cells.FromKey("GRADE_POP_POINT").Text);
            //}
            //else
            //{
                colGrade = (TemplatedColumn)ugrdMBO.Rows[i].Band.Columns.FromKey("GRADE");
                ddlCGrade = (DropDownList)((CellItem)colGrade.CellItems[ugrdMBO.Rows[i].BandIndex]).FindControl("ddlGrade");

                grade = (ddlCGrade.SelectedIndex == 0 ? "0" : ddlCGrade.SelectedValue);
            //}

            if (ugrdMBO.Rows[i].Cells.FromKey("SCORE_WEIGHT").Value != null)
            {
                objGrade[i, 0] = ugrdMBO.Rows[i].Cells.FromKey("KPI_REF_ID").Value;
                objGrade[i, 1] = grade;
                objGrade[i, 2] = DataTypeUtility.GetToDouble(ugrdMBO.Rows[i].Cells.FromKey("FINAL_SCORE").Value);
                objGrade[i, 3] = ugrdMBO.Rows[i].Cells.FromKey("SCORE_WEIGHT").Value;
                objGrade[i, 4] = ugrdMBO.Rows[i].Cells.FromKey("GRADE_REASON").Value;
                objGrade[i, 5] = DataTypeUtility.GetValue(ugrdMBO.Rows[i].Cells.FromKey("SCORE_ORI_LIST").Value);


                string str_scoreMT = DataTypeUtility.GetString(ugrdMBO.Rows[i].Cells.FromKey("SCORE_MT").Value);
                if (str_scoreMT.Trim().Length == 0)
                    ScoreMT[i] = -1.0;
                else
                    ScoreMT[i] = DataTypeUtility.GetToDouble(str_scoreMT);
                ymd[i] = DataTypeUtility.GetString(ugrdMBO.Rows[i].Cells.FromKey("YMD").Value);

                saveCnt++;
            }
        }

        object[,] objSaveGrade = new object[saveCnt, 6];
        double[] SaveScoreMT = new double[saveCnt];
        string[] SaveYMD = new string[saveCnt];

        saveCnt = 0;
        //for (int i = 0; i < objGrade.GetLength(0); i++)
        //{
        //    if (objGrade[i, 0] != null)
        //    {
        //        objSaveGrade[saveCnt, 0] = objGrade[i, 0];
        //        objSaveGrade[saveCnt, 1] = (objGrade[i, 1] == null ? DBNull.Value : objGrade[i, 1]);
        //        objSaveGrade[saveCnt, 2] = (objGrade[i, 1] == null ? DBNull.Value : objGrade[i, 2]);
        //        objSaveGrade[saveCnt, 3] = (objGrade[i, 1] == null ? DBNull.Value : objGrade[i, 3]);
        //        objSaveGrade[saveCnt, 4] = (objGrade[i, 1] == null || objGrade[i, 4] == null ? DBNull.Value : objGrade[i, 4]);
        //        saveCnt++;
        //    }
        //}

        for (int i = 0; i < objGrade.GetLength(0); i++)
        {
            if (objGrade[i, 0] != null)
            {
                objSaveGrade[saveCnt, 0] = objGrade[i, 0];
                objSaveGrade[saveCnt, 1] = (objGrade[i, 1]);
                objSaveGrade[saveCnt, 2] = (objGrade[i, 2]);
                objSaveGrade[saveCnt, 3] = (objGrade[i, 3]);
                objSaveGrade[saveCnt, 4] = (objGrade[i, 4]);
                objSaveGrade[saveCnt, 5] = (objGrade[i, 5]);

                SaveScoreMT[saveCnt] = ScoreMT[i];
                SaveYMD[saveCnt] = ymd[i];

                saveCnt++;
            }
        }

        if (biz.UpdateMboDTGrade(true
                                , ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , IESTTERM_STEP_ID
                                , IEST_DEPT_ID
                                , EMP_REF_ID
                                , ITGT_DEPT_ID
                                , ITGT_EMP_ID
                                , objSaveGrade
                                , SaveScoreMT
                                , SaveYMD
                                , gUserInfo.Emp_Ref_ID))
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
            DoBinding();
            ibtnOpinion.ImageUrl = "../images/btn/b_001.gif";
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }

    protected void ibtnConfirmReport_Click(object sender, ImageClickEventArgs e)
    {
        int emp_id = EMP_REF_ID;

        if (IUSER_TYPE.Equals(2))
            emp_id = -1;

        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboReport(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , ITGT_DEPT_ID
                                , emp_id
                                , txtReport.Value
                                , hdfTargetReasonFile.Value
                                , "C"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정하였습니다.");
            DoBinding();
            tdReport.Style.Add("display", "block");
            ibtnReport.ImageUrl = "../images/btn/b_003.gif";
            ibtnViewReport.Style["display"] = "none";
            ibtnCloseReport.Style["display"] = "block";

            //메일발송
            SendMail(2, 1);
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정 실패!");
    }

    private void SendMail(int mailType, int toStepId)
    {
        if (PageUtility.GetAppConfig("Mail.UseMBOMailYN") != "true")
        {
            return;
        }

        string sC_EMP_MAIL = "";
        string sN_EMP_MAIL = "";
        string sFile = "";
        EmpInfos objEmp;
        EmpInfos objEmp2;

        if (mailType == 2)
        {
            sFile = "mailtemp_평가.htm";
            objEmp = new EmpInfos(this.ITGT_EMP_ID);
            sC_EMP_MAIL = objEmp.Emp_Email;
            objEmp2 = new EmpInfos(DataTypeUtility.GetToInt32(this.IESTEMPLIST.Split(';').GetValue(toStepId - 1)));
            sN_EMP_MAIL = objEmp2.Emp_Email;

        }
        else
        {
            sFile = "mailtemp_피드백.htm";
            objEmp = new EmpInfos(DataTypeUtility.GetToInt32(this.IESTEMPLIST.Split(';').GetValue(toStepId - 2)));
            sC_EMP_MAIL = objEmp.Emp_Email;
            objEmp2 = new EmpInfos(this.ITGT_EMP_ID);
            sN_EMP_MAIL = objEmp2.Emp_Email;

        }
        if (!PageUtility.CheckMailAddress(sC_EMP_MAIL) || !PageUtility.CheckMailAddress(sN_EMP_MAIL))
        {
            return;
        }

        DataTable dtMailParam = new DataTable("PARAM");
        dtMailParam.Columns.Add("KEY", typeof(string));
        dtMailParam.Columns.Add("VAL", typeof(string));

        string strVPath = Request.ApplicationPath;
        string strSHost = Request.Url.Host;
        string strSPort = Request.Url.Port.ToString();
        string strProto = Request.Url.Scheme;
        strVPath = (strVPath == "/") ? "" : strVPath;

        string strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath;

        DataRow dr = null;
        dr = dtMailParam.NewRow();
        dr["KEY"] = "[::MAIL_DOMAIN::]";
        dr["VAL"] = strFullPath;
        dtMailParam.Rows.Add(dr);

        if (mailType == 2)
        {
            dr = dtMailParam.NewRow();
            dr["KEY"] = "[::EMP_NAME::]";
            dr["VAL"] = objEmp.Emp_Name;
            dtMailParam.Rows.Add(dr);

            dr = dtMailParam.NewRow();
            dr["KEY"] = "[::KPI_INFO::]";
            dr["VAL"] = "MBO평가";
            dtMailParam.Rows.Add(dr);
        }
        else if (mailType == 3)
        {
            dr = dtMailParam.NewRow();
            dr["KEY"] = "[::APP_GUBUN::]";
            dr["VAL"] = "MBO";
            dtMailParam.Rows.Add(dr);
        }

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[::TO_DAY::]";
        dr["VAL"] = DateTime.Now.ToString();
        dtMailParam.Rows.Add(dr);

        string sMailTitle;
        if (mailType == 2)
        {
            sMailTitle = "[성과관리 - " + "MBO평가 요청 건 알림메일]";
        }
        else
        {
            sMailTitle = "[성과관리 - " + "MBO평가 피드백요청 건 알림메일]";
        }

        bool rtnMail = PageUtility.SendMail(dtMailParam, sC_EMP_MAIL, sN_EMP_MAIL, sMailTitle, sFile);
    }

    protected void ibtnEst_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas biz = new Biz_Datas();
        //IREPORT_STATUS = biz.GetMboReportStatus(ICOMP_ID
        //                                        , IEST_ID
        //                                        , IESTTERM_REF_ID
        //                                        , IESTTERM_SUB_ID
        //                                        , ITGT_DEPT_ID
        //                                        , ITGT_EMP_ID);
        //if (IREPORT_STATUS != "C")
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("실적보고입력이 확정되지 않았습니다.");
        //    return;
        //}

        if (biz.UpdateMboEstMTStatus(ICOMP_ID
                                    , IEST_ID
                                    , IESTTERM_REF_ID
                                    , IESTTERM_SUB_ID
                                    , IESTTERM_STEP_ID
                                    , IEST_DEPT_ID
                                    , EMP_REF_ID
                                    , ITGT_DEPT_ID
                                    , ITGT_EMP_ID
                                    , "O"))//O:평가중, C:평가완료, P:피드백중, E:피드백완료
        {
            DoBinding();
            //ibtnSaveEst.Visible = ibtnConfirmEst.Visible = true;
            //ibtnSaveEst.Style["display"] = ibtnConfirmEst.Style["display"] = "block";
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가를 시작할 수 없는 정보입니다.");
            return;
        }
    }

    protected void ibtnCancelReport_Click(object sender, ImageClickEventArgs e)
    {
        int emp_id = EMP_REF_ID;

        if (IUSER_TYPE.Equals(2))
            emp_id = -1;

        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboReport(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , ITGT_DEPT_ID
                                , emp_id
                                , txtReport.Value
                                , hdfTargetReasonFile.Value
                                , "O"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정취소하였습니다.");
            DoBinding();
            tdReport.Style.Add("display", "block");
            ibtnReport.ImageUrl = "../images/btn/b_003.gif";
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정취소 실패!");
    }
    protected void ibtnSaveEst_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboMTGrade(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , IESTTERM_STEP_ID
                                , IEST_DEPT_ID
                                , EMP_REF_ID
                                , ITGT_DEPT_ID
                                , ITGT_EMP_ID
                                , txtOpinion.Value))
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
            DoBinding();
            tdEst.Style["display"] = "block";
            ibtnOpinion.ImageUrl = "../images/btn/b_003.gif";
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }
    protected void ibtnConfirmEst_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboEst(ICOMP_ID
                            , IEST_ID
                            , IESTTERM_REF_ID
                            , IESTTERM_SUB_ID
                            , IESTTERM_STEP_ID
                            , IEST_DEPT_ID
                            , EMP_REF_ID
                            , ITGT_DEPT_ID
                            , ITGT_EMP_ID
                            , txtOpinion.Value
                            , "C"))
        {
            if (this.IESTTERM_STEP_ID == this.ILAST_STEP_ID) //피평가자의견 요청
                SendMail(3, this.ILAST_STEP_ID);
            else // 다음차수 평가요청
                SendMail(2, this.IESTTERM_STEP_ID);
            ltrScript.Text = JSHelper.GetAlertScript("확정하였습니다.");
            DoBinding();
            tdEst.Style["display"] = "block";
            //ibtnOpinion.ImageUrl = "../images/btn/b_003.gif";
            ibtnViewOpinion.Style["display"] = "none";
            ibtnCloseOpinion.Style["display"] = "block";
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정 실패!");
    }
    protected void ibtnCancelEst_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas biz = new Biz_Datas();
        //if (IESTTERM_STEP_ID == 2) // 현재평가차수를 확정취소할땐 현재평가차수 이후의 평가차수들의 평가상태를 미평가상태로 돌린다.
        if (biz.UpdateMboEstCancel(ICOMP_ID
                        , IEST_ID
                        , IESTTERM_REF_ID
                        , IESTTERM_SUB_ID
                        , IESTTERM_STEP_ID
                        , IEST_DEPT_ID
                        , EMP_REF_ID
                        , ITGT_DEPT_ID
                        , ITGT_EMP_ID
                        , txtOpinion.Value
                        , "N"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정취소하였습니다.");
            DoBinding();
            //tdEst.Style.Add("display", "block");
            //ibtnOpinion.ImageUrl = "../images/btn/b_003.gif";
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정취소 실패!");
        }
        //else 
        //    if (biz.UpdateMboEst(ICOMP_ID
        //                    , IEST_ID
        //                    , IESTTERM_REF_ID
        //                    , IESTTERM_SUB_ID
        //                    , IESTTERM_STEP_ID
        //                    , IEST_DEPT_ID
        //                    , EMP_REF_ID
        //                    , ITGT_DEPT_ID
        //                    , ITGT_EMP_ID
        //                    , txtOpinion.Value
        //                    , "O"))
        //    {
        //        ltrScript.Text = JSHelper.GetAlertScript("확정취소하였습니다.");
        //        DoBinding();
        //        //tdEst.Style.Add("display", "block");
        //        //ibtnOpinion.ImageUrl = "../images/btn/b_003.gif";
        //    }
        //    else
        //        ltrScript.Text = JSHelper.GetAlertScript("확정취소 실패!");
    }
    protected void ibtnSaveFeedBack_Click(object sender, ImageClickEventArgs e)
    {
        int emp_id = EMP_REF_ID;

        if (IUSER_TYPE.Equals(2))
            emp_id = -1;

        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboFeedBack_3A(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , IESTTERM_STEP_ID
                                , IEST_DEPT_ID
                                , IEST_EMP_ID
                                , ITGT_DEPT_ID
                                , emp_id
                                , IEST_FEEDBACK_SEQ
                                , txtFeedBack.Value
                                , "P"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
            DoBinding();
            tdFeedBack.Style["display"] = "block";
            ibtnFeedBack.ImageUrl = "../images/btn/b_003.gif";
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }
    protected void ibtnConfirmFeedBack_Click(object sender, ImageClickEventArgs e)
    {
        int emp_id = EMP_REF_ID;

        if (IUSER_TYPE.Equals(2))
            emp_id = -1;

        Biz_Datas biz = new Biz_Datas();
        if (biz.UpdateMboFeedBack_3A(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , IESTTERM_STEP_ID
                                , IEST_DEPT_ID
                                , IEST_EMP_ID
                                , ITGT_DEPT_ID
                                , emp_id
                                , 0
                                , txtFeedBack.Value
                                , "E"
                                , "AGR"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정하였습니다.");
            DoBinding();
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정 실패!");
    }

    protected void ibtnCancelFeedBack_Click(object sender, ImageClickEventArgs e)
    {
        int emp_id = EMP_REF_ID;

        if (IUSER_TYPE.Equals(2))
            emp_id = -1;

        Biz_Datas biz = new Biz_Datas();
        // 이의신청시 모든 차수의 평가상태를 미평가상태로 돌린다.
        if (biz.UpdateMboEstReject_3A(ICOMP_ID
                                , IEST_ID
                                , IESTTERM_REF_ID
                                , IESTTERM_SUB_ID
                                , IESTTERM_STEP_ID
                                , IEST_DEPT_ID
                                , IEST_EMP_ID
                                , ITGT_DEPT_ID
                                , emp_id
                                , txtFeedBack.Value.Replace("<p>", "").Replace("</p>", "</br>")
                                , "N"
                                , "RJT"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("이의신청하였습니다.");
            DoBinding();
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("이의신청 실패!");
    }

    protected void lnkReload_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    private void DoBindingStatus()
    {
        DataTable dtStatus = this.ISTATUS_TABLE;
        if (dtStatus.Rows.Count == 0)
        {
            string strName = string.Empty;
            string strDesc = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        strName = "미작성";
                        strDesc = "../images/icon/color/red.gif";
                        break;
                    case 1:
                        strName = "진행중";
                        strDesc = "../images/icon/color/green.gif";
                        break;
                    case 2:
                        strName = "완료";
                        strDesc = "../images/icon/color/blue.gif";
                        break;
                }

                DataRow dr = dtStatus.NewRow();
                dr["CODE_NAME"] = strName;
                dr["CODE_DESC"] = strDesc;
                dtStatus.Rows.Add(dr);
            }
        }
        tblViewStatus.CellPadding = 0;
        tblViewStatus.CellSpacing = 0;
        tblViewStatus.BorderWidth = 0;
        TableRow tblRow = new TableRow();
        TableCell tblCell = null;
        tblViewStatus.Rows.Add(tblRow);
        foreach (DataRow dataRow in dtStatus.Rows)
        {
            tblCell = new TableCell();
            tblCell.Style.Add("padding-right", "5px");
            tblCell.Text = string.Format("<img src='{0}' alt='{1}' /> {2} ", dataRow["CODE_DESC"], dataRow["CODE_NAME"], dataRow["CODE_NAME"]);
            tblRow.Cells.Add(tblCell);
        }
    }
}
