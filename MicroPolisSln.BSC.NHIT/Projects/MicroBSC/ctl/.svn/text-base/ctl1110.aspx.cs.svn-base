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

using MicroBSC.Estimation.Dac;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;

public partial class ctl_ctl1110 : AppPageBase
{
    #region ===================================== [Load]    =============================
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
    #endregion
    
    #region ===================================== [Load]    =============================

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.InitForm();
            this.GetTermInfos();
        }
        
        Literal1.Text = "";

        //// 체크인-체크아웃 활성화 
        //MenuControl2.IsCheckInOutVisible = true;
        //MenuControl2.SetCheckInOutBuuton(
        //                                 iBtnClear,iBtnAdd,iBtnModifyTermInfo,iBtnDel,iBtnClose
        //                               , iBtnDeleteTermDetail
        //                               , tdSub
        //                                );
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            ltrAddTermInfo.Text = "<a href='#null' onclick=\"gfOpenWindow('ctl1111.aspx?mode=New', 600, 200);\"><img src=\"../images/btn/b_035.gif\" border=0 /></a>";
            iBtnRemoveEstTermInfo.Attributes.Add("onclick", "return confirm('평가기간을 삭제하시겠습니까? 만약 삭제 후 복원을 원하신다면 시스템관리자에게 문의하세요.');");
        }
    }

    #endregion

    private void InitForm()
    {
        for (int i = 1; i < 32; i++)
        {
            ddlMONTHLY_CLOSE_DAY.Items.Add(new ListItem(i.ToString() + "일", i.ToString()));
            ddlPRE_CLOSE_DAY.Items.Add(new ListItem(i.ToString() + "일", i.ToString()));
            ddlKPI_QLT_CLOSE_DAY.Items.Add(new ListItem(i.ToString() + "일", i.ToString()));
        }

        MicroBSC.Biz.Common.Biz.Biz_EtcCodeInfos objCode = new MicroBSC.Biz.Common.Biz.Biz_EtcCodeInfos();
        objCode.GetScoreValuationType(ddlSCORE_VALUATION_TYPE, 0, false, 90);
        WebCommon.SetMonthlyCloseRateTypeDropDownList(ddlCLOSE_RATE_COMPLETE_YN, false);

        ddlEXTERNAL_SCORE_TYPE.Items.Clear();
        WebCommon.SetExternalEstTypeDropDownList(ddlEXTERNAL_SCORE_TYPE, false);


        ddlMONTHLY_CLOSE_DAY.Width      = Unit.Pixel(90);
        ddlPRE_CLOSE_DAY.Width          = Unit.Pixel(90);
        ddlCLOSE_RATE_COMPLETE_YN.Width = Unit.Pixel(90);
        ddlKPI_QLT_CLOSE_DAY.Width      = Unit.Pixel(90);

        iBtnModifyTermInfo.Visible      = false;
        iBtnDel.Visible                 = false;
        iBtnClose.Visible               = false;
    }

    private void GetTermInfos()
    {
        TermInfos termInfo              = new TermInfos();
        DataTable dt                    = termInfo.GetAllList().Tables[0];

        dt = DataTypeUtility.FilterSortDataTable(dt, "", "EST_STARTDATE");

        UltraWebGrid1.DataSource        = dt;
        UltraWebGrid1.DataBind();
    }

    private void GetTermDetails(int estterm_ref_id)
    {;
        //// 0 : All, 1 : 업적 정성 평가, 2 : 역량 평가 4 : 업적 정량 펑가, 5 : ,6 : ,7 : 
        //TermDetails termDetail          = new TermDetails();
        //UltraWebGrid2.DataSource        = termDetail.GetTermDetail(estterm_ref_id, 0, 0);
        //UltraWebGrid2.DataBind();
    }

    private void SetEstTermInfo(int estterm_ref_id)
    {
        TermInfos termInfo              = new TermInfos(estterm_ref_id);
        txtEstTermName.Text             = termInfo.Estterm_name;
        ltrEstTermRefId.Text            = termInfo.Estterm_ref_id.ToString();
        txtEST_DESC.Text                = termInfo.Est_desc;

        wdcFrom.Value                   = termInfo.Est_startdate.ToString("yyyy-MM-dd");
        wdcTo.Value                     = termInfo.Est_compdate.ToString("yyyy-MM-dd");

        PageUtility.FindByValueDropDownList(ddlMONTHLY_CLOSE_DAY, termInfo.Monthly_close_day.ToString());
        PageUtility.FindByValueDropDownList(ddlPRE_CLOSE_DAY, termInfo.Pre_close_day.ToString());
        PageUtility.FindByValueDropDownList(ddlKPI_QLT_CLOSE_DAY, termInfo.Kpi_Qlt_Close_Day.ToString());
        PageUtility.FindByValueDropDownList(ddlSCORE_VALUATION_TYPE, termInfo.Score_valuation_type);
        PageUtility.FindByValueDropDownList(ddlCLOSE_RATE_COMPLETE_YN, (termInfo.Close_rate_complete_yn == 1) ? "1" : "0");
        PageUtility.FindByValueDropDownList(ddlEXTERNAL_SCORE_TYPE, termInfo.External_score_type);

        chkEXTERNAL_SCORE_USE_YN.Checked = (termInfo.External_score_use_yn == "Y") ? true : false;

        // 마감여부
        if (termInfo.Yearly_close_yn == 1)
        {
            iBtnClose.Visible           = false;
            iBtnModifyTermInfo.Visible  = false;
            iBtnOpen.Visible            = true;
        }
        else
        {
            iBtnModifyTermInfo.Visible  = true;
            iBtnClose.Visible           = true;
            iBtnOpen.Visible            = false;
        }

        // 사용여부
        if (termInfo.Est_status == 1)
        {
            iBtnDel.Visible             = true;
        }
        else
        {
            iBtnDel.Visible             = false;
        }

        iBtnAdd.Visible                 = false;
    }

    /// <summary>
    /// 평가기간 입력/수정/삭제/마감처리
    /// </summary>
    /// <param name="strType"></param>
    private void TxrEstTermInfo(string strType)
    {

        if (strType == "A")
        {
            if (txtEstTermName.Text.Trim() == "")
            {
                Literal1.Text = JSHelper.GetAlertScript("평가기간명을 입력해 주십시오", false);
                return;
            }
        }
        else if (strType == "U")
        {
            if (txtEstTermName.Text.Trim() == "" || this.IEstTermRefID < 1)
            {
                Literal1.Text = JSHelper.GetAlertScript("평가기간 정보가 올바르지 않습니다.", false);
                return;
            }
        }
        else
        {
            if (this.IEstTermRefID < 1)
            {
                Literal1.Text = JSHelper.GetAlertScript("평가기간명이 선택되지 않았습니다.", false);
                return;
            }
        }

        int _estterm_ref_id          = this.IEstTermRefID;
        string _estterm_name         = txtEstTermName.Text.Trim();
        DateTime _est_compdate       = Convert.ToDateTime(wdcTo.Value);
        DateTime _est_startdate      = Convert.ToDateTime(wdcFrom.Value);
        int _monthly_close_day       = PageUtility.GetIntByValueDropDownList(ddlMONTHLY_CLOSE_DAY);
        int _pre_close_day           = PageUtility.GetIntByValueDropDownList(ddlPRE_CLOSE_DAY);
        int _kpi_qlt_close_day       = PageUtility.GetIntByValueDropDownList(ddlKPI_QLT_CLOSE_DAY);
        bool _yearly_close_yn        = true;
        string _score_valuation_type = ddlSCORE_VALUATION_TYPE.SelectedValue;
        string _est_desc             = txtEST_DESC.Text;
        bool _est_status             = true;
        bool _close_rate_complete_yn = (ddlCLOSE_RATE_COMPLETE_YN.SelectedValue.ToString() == "1") ? true : false;
        string _external_score_use_yn = (chkEXTERNAL_SCORE_USE_YN.Checked) ? "Y" : "N";
        string _external_score_type   = PageUtility.GetByValueDropDownList(ddlEXTERNAL_SCORE_TYPE);
        
        string rtnResult            = "";
        string[] _rtnResult         = new string[2];

        TermInfos objTerm = new TermInfos();

        //-------------------------------------------------------------------입력
        if (strType == "A")
        {
            rtnResult = objTerm.InsertData(_estterm_name, _est_startdate, _est_compdate, _monthly_close_day, _pre_close_day, _kpi_qlt_close_day, _yearly_close_yn,
                                     _score_valuation_type, _est_desc, _est_status, _close_rate_complete_yn, _external_score_use_yn,_external_score_type, gUserInfo.Emp_Ref_ID);
            _rtnResult = rtnResult.Split('\t');
            if (_rtnResult[0] == "Y") { this.GetTermInfos(); }
        }
        //-------------------------------------------------------------------수정
        else if (strType == "U")
        {
            rtnResult = objTerm.UpdateData(_estterm_ref_id, _estterm_name, _est_startdate, _est_compdate, _monthly_close_day, _pre_close_day, _kpi_qlt_close_day,
                                     _score_valuation_type, _est_desc, _est_status, _close_rate_complete_yn, _external_score_use_yn,_external_score_type, gUserInfo.Emp_Ref_ID);
            _rtnResult = rtnResult.Split('\t');
            if (_rtnResult[0] == "Y") { this.SetEstTermInfo(_estterm_ref_id); }
        }
        //-------------------------------------------------------------------삭제
        else if (strType == "D")
        {
            rtnResult = objTerm.DeleteData(_estterm_ref_id, gUserInfo.Emp_Ref_ID);
            _rtnResult = rtnResult.Split('\t');
            if (_rtnResult[0] == "Y") { this.GetTermInfos(); }
        }
        //-------------------------------------------------------------------연간평가마감
        else if (strType == "CT")
        {
            rtnResult = objTerm.CloseYearlyTerm(_estterm_ref_id, gUserInfo.Emp_Ref_ID);
            _rtnResult = rtnResult.Split('\t');
            if (_rtnResult[0] == "Y") { this.GetTermInfos(); }
        }
        //-------------------------------------------------------------------연간평가마감취소
        else if (strType == "OT")
        {
            rtnResult = objTerm.OpenYearlyTerm(_estterm_ref_id, gUserInfo.Emp_Ref_ID);
            _rtnResult = rtnResult.Split('\t');
            if (_rtnResult[0] == "Y") { this.GetTermInfos(); }
        }
        else
        {
            return;
        }

        Literal1.Text = JSHelper.GetAlertScript(_rtnResult[1], false);
    }

    private void SetBscTermDetail()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);

        ugrdClose.Clear();
        ugrdClose.DataSource = rDs;
        ugrdClose.DataBind();
    }

    private string GetEstSubType(int est_sub_type)
    {
        if (est_sub_type == 0)
            return "All";
        else if (est_sub_type == 1)
            return "업적 정성 평가";
        else if (est_sub_type == 2)
            return "역량 평가";
        else if (est_sub_type == 3)
            return "다면 평가";
        else if (est_sub_type == 4)
            return "업적 정량 평가";
        else if (est_sub_type == 5)
            return "업적 평가 확정";
        else if (est_sub_type == 6)
            return "역량 평가 Bias 조정";
        else if (est_sub_type == 7)
            return "역량 평가 확정";

        return "";
    }

    protected void iBtnRemoveEstTermInfo_Click(object sender, ImageClickEventArgs e)
    {
        TermInfos termInfo = new TermInfos();
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        int estterm_ref_id = 0;

        for (int i = 0; i < UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    estterm_ref_id  = int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    string msg      = termInfo.DeleteData(estterm_ref_id, EMP_REF_ID);
                }
                catch (Exception ex)
                {
                    Literal1.Text   = JSHelper.GetAlertScript("삭제 중 오류가 발생하였습니다.. \\n" + ex.Message, false);
                    return;
                }
            }
        }

        if (!isOK)
            Literal1.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        else
            GetTermInfos();
    }

    

    protected void UltraWebGrid1_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        this.IEstTermRefID = (e.SelectedRows[0].Cells.FromKey("ESTTERM_REF_ID")!=null) ? int.Parse(e.SelectedRows[0].Cells.FromKey("ESTTERM_REF_ID").Value.ToString()) : 0;
        this.SetEstTermInfo(this.IEstTermRefID);
        this.GetTermDetails(this.IEstTermRefID);
        this.SetBscTermDetail();

        //tdSub.Visible = true;
    }

    
    
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        GetTermInfos();
    }
    
    protected void lBtnSubReload_Click(object sender, EventArgs e)
    {
        GetTermDetails(this.IEstTermRefID);
    }
    
    protected void iBtnClear_Click(object sender, ImageClickEventArgs e)
    {
        DateTime strFrDate          = DateTime.Now.AddMonths(DateTime.Now.Month * -1 + 1);
        strFrDate                   = strFrDate.AddDays(DateTime.Now.Day * -1 + 1);
        DateTime strToDate          = strFrDate.AddDays(-1);
        strToDate                   = strToDate.AddYears(1);

        txtEstTermName.Text         = "";
        txtEST_DESC.Text            = "";
        wdcFrom.Value               = strFrDate;
        wdcTo.Value                 = strToDate;

        iBtnAdd.Visible             = true;
        iBtnModifyTermInfo.Visible  = false;
        iBtnDel.Visible             = false;
        iBtnClose.Visible           = false;
        iBtnOpen.Visible            = false;
        //UltraWebGrid2.Clear();
    }

    protected void iBtnModifyTermInfo_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrEstTermInfo("U");
    }
    
    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrEstTermInfo("A");
    }
    
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrEstTermInfo("CT");

        iBtnAdd.Visible             = false;
        iBtnModifyTermInfo.Visible  = false;
        iBtnDel.Visible             = false;
        iBtnClose.Visible           = false;
        iBtnOpen.Visible            = true;
    }

    protected void iBtnOpen_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrEstTermInfo("OT");

        iBtnAdd.Visible             = false;
        iBtnModifyTermInfo.Visible  = true;
        iBtnDel.Visible             = true;
        iBtnClose.Visible           = true;
        iBtnOpen.Visible            = false;
    }
    
    protected void iBtnDel_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrEstTermInfo("D");
    }
    
    protected void ugrdClose_InitializeRow(object sender, RowEventArgs e)
    {
        CheckBox chkClose;
        CheckBox chkRelease;

        TemplatedColumn Col_Close   = (TemplatedColumn)e.Row.Band.Columns.FromKey("CLOSE_YN");
        TemplatedColumn Col_Release = (TemplatedColumn)e.Row.Band.Columns.FromKey("RELEASE_YN");


        chkClose                    = (CheckBox)((CellItem)Col_Close.CellItems[e.Row.BandIndex]).FindControl("chkCLOSE_YN");
        chkRelease                  = (CheckBox)((CellItem)Col_Release.CellItems[e.Row.BandIndex]).FindControl("chkRELEASE_YN");

        chkClose.Checked            = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString()   == "Y") ? true : false;
        chkRelease.Checked          = (e.Row.Cells.FromKey("RELEASE_YN").Value.ToString() == "Y") ? true : false;

        chkClose.Enabled            = false; //(e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;
        chkRelease.Enabled          = false; //(e.Row.Cells.FromKey("RELEASE_YN").Value.ToString() == "N") ? true : false;

        if (e.Row.Cells.FromKey("CLOSING_RATE") != null)
        { 
            if (e.Row.Cells.FromKey("CLOSING_RATE").Value.ToString() == "-")
            {
                e.Row.Cells.FromKey("CLOSING_RATE").Style.ForeColor = Color.Gray;
            }
            else
            {
                e.Row.Cells.FromKey("CLOSING_RATE").Style.ForeColor = (double.Parse(e.Row.Cells.FromKey("CLOSING_RATE").Value.ToString()) < 100) ? Color.Red : Color.Blue;
                e.Row.Cells.FromKey("CLOSING_RATE").Value           = e.Row.Cells.FromKey("CLOSING_RATE").Value.ToString() + "%";
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        int iEstTermID = e.Row.Cells.FromKey("ESTTERM_REF_ID").Value == null ? 0 : int.Parse(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());

        if (this.IEstTermRefID == iEstTermID)
        {
            e.Row.Selected = true;
        }
    }
}
