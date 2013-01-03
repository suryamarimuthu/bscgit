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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;


public partial class BSC_BSC0802M1 : AppPageBase
{

    public int IValidationUserID
    {
        get
        {
            if (ViewState["VALIDATION_USER_ID"] == null)
            {
                ViewState["VALIDATION_USER_ID"] = GetRequestByInt("VALIDATION_USER_ID", 0);
            }

            return (int)ViewState["VALIDATION_USER_ID"];
        }
        set
        {
            ViewState["VALIDATION_USER_ID"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetAllTimeTop();
        if (!IsPostBack)
        {
            this.InitControlValue();
        }
        else
        { 
        
        }
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }

    private void InitControlValue()
    {
        iBtnCopyKpiList.Style.Add("vertical-align", "middle");
        WebCommon.SetEstTermDropDownList(ddlEstTerm);
        WebCommon.SetValuationGroupDropDownList(ddlEstGroup, false);
        this.SetSelectedGroupList();

        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiGroup,0, true, 100);
        ddlKpiGroup.SelectedIndex = (ddlKpiGroup.Items.Count > 0) ? 0 : -1;
        objCode.GetKpiEstimateType(ddlBASIS_USE_YN,0, true, 100);
        PageUtility.FindByValueDropDownList(ddlBASIS_USE_YN, "EQL");

        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        WebCommon.SetKpiQltEstLevelDropDownList(ddlEstLevel, PageUtility.GetIntByValueDropDownList(ddlEstTerm), false);

        this.SetTermList();
    }
    #endregion

    #region 내부함수
    private void SetSelectedGroupList()
    { 
        Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        objBSC.Iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
        objBSC.Igroup_ref_id   = PageUtility.GetIntByValueDropDownList(ddlEstGroup);

        DataSet rDs = objBSC.GetEstEmpListPerLevel(
                             objBSC.Iestterm_ref_id
                           , objBSC.Igroup_ref_id
                           , PageUtility.GetIntByValueDropDownList(ddlEstLevel));

        ugrdVaidationUserGrid.Clear();
        ugrdVaidationUserGrid.DataSource = rDs;
        ugrdVaidationUserGrid.DataBind();
        //lblUserName.Text = "";
        //this.IValidationUserID = 0;

        Biz_Bsc_Kpi_Qlt_Est_Term objTrm = new Biz_Bsc_Kpi_Qlt_Est_Term();
        DataSet tDs = objTrm.GetAllList
            (objBSC.Iestterm_ref_id
            , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
            , PageUtility.GetIntByValueDropDownList(ddlEstLevel));

        ugrdTerm.Clear();
        ugrdTerm.DataSource = tDs;
        ugrdTerm.DataBind();
    }

    private void SetTargetKpiList()
    {
        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        DataSet rDs = objBSC.GetKpiListPerValidationTarget
                                             ( PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                             , ""
                                             , txtKPICode.Text
                                             , txtKPIName.Text
                                             , "Y"
                                             , txtChamName.Text
                                             , PageUtility.GetIntByValueDropDownList(ddlEstDept)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstLevel)
                                             , this.IValidationUserID
                                             , PageUtility.GetByValueDropDownList(ddlKpiGroup)
                                             , PageUtility.GetByValueDropDownList(ddlBASIS_USE_YN)
                                             );

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = rDs;
        ugrdKpiList.DataBind();

        lblCntKpiTarget.Text = rDs.Tables[0].Rows.Count.ToString();
    }

    private void SetTermList()
    {
        Biz_Bsc_Term_Detail objTrm = new Biz_Bsc_Term_Detail();
        DataSet rDs = objTrm.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTerm));

        ugrdTerm.Clear();
        ugrdTerm.DataSource = rDs;
        ugrdTerm.DataBind();
    }

    /// <summary>
    /// 지표미적용리스트
    /// </summary>
    private void SetTargetKpiListNotAllocate()
    {
        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        DataSet rDs = objBSC.GetKpiListNotAllocate
                                             ( PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                             , ""
                                             , txtKPICode.Text
                                             , txtKPIName.Text
                                             , "Y"
                                             , txtChamName.Text
                                             , PageUtility.GetIntByValueDropDownList(ddlEstDept)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstLevel)
                                             , this.IValidationUserID
                                             , PageUtility.GetByValueDropDownList(ddlKpiGroup)
                                             , PageUtility.GetByValueDropDownList(ddlBASIS_USE_YN)
                                             );

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = rDs;
        ugrdKpiList.DataBind();
    }

    private void SetKpiListPerValidationUser()
    { 
        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        DataSet rDs = objBSC.GetKpiListPerValidationUser
                                             ( PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                             , ""
                                             , ""
                                             , ""
                                             , "Y"
                                             , ""
                                             , 0 //PageUtility.GetIntByValueDropDownList(ddlEstDept)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstLevel)
                                             , this.IValidationUserID);

        ugrdSelectValidationList.Clear();
        ugrdSelectValidationList.DataSource = rDs;
        ugrdSelectValidationList.DataBind();
    }

    private int AddKpiPerValidationUser()
    { 
        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        int intTxrUser      = gUserInfo.Emp_Ref_ID;
        int intRtn          = 0;
        int intRow          = ugrdKpiList.Rows.Count;

        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();

        for (int i = 0; i < intRow; i++)
        {
            row = ugrdKpiList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;

                objBSC.Iemp_ref_id          = this.IValidationUserID;
                objBSC.Iestterm_ref_id      = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
                objBSC.Igroup_ref_id        = PageUtility.GetIntByValueDropDownList(ddlEstGroup);
                objBSC.Iest_level           = PageUtility.GetIntByValueDropDownList(ddlEstLevel);
                objBSC.Ikpi_ref_id          = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                objBSC.Itxr_user            = intTxrUser;
                objBSC.Iopinion             = "";

                intRtn += objBSC.InsertData(objBSC.Iestterm_ref_id
                                          , objBSC.Igroup_ref_id
                                          , objBSC.Iest_level
                                          , objBSC.Iemp_ref_id
                                          , objBSC.Ikpi_ref_id
                                          , objBSC.Iopinion
                                          , objBSC.Itxr_user);
            }
        }

        return intRtn;
    }

    private int RemoveKpiPerValidationUser()
    { 
        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        int intTxrUser      = gUserInfo.Emp_Ref_ID;
        int intRtn          = 0;
        int intRow          = ugrdSelectValidationList.Rows.Count;

        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        for (int i = 0; i < intRow; i++)
        {
            row = ugrdSelectValidationList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;

                objBSC.Iestterm_ref_id      = Convert.ToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                objBSC.Igroup_ref_id        = Convert.ToInt32(row.Cells.FromKey("GROUP_REF_ID").Value.ToString());
                objBSC.Iest_level           = Convert.ToInt32(row.Cells.FromKey("EST_LEVEL").Value.ToString());
                objBSC.Iemp_ref_id          = Convert.ToInt32(row.Cells.FromKey("EMP_REF_ID").Value.ToString());
                objBSC.Ikpi_ref_id          = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                objBSC.Itxr_user            = intTxrUser;

                intRtn += objBSC.DeleteData(objBSC.Iestterm_ref_id
                                          , objBSC.Igroup_ref_id
                                          , objBSC.Iest_level
                                          , objBSC.Iemp_ref_id
                                          , objBSC.Ikpi_ref_id
                                          , objBSC.Itxr_user);
            }
        }

        return intRtn;
    }

    private int SetKpiQltTerm()
    { 
        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;

        int intTxrUser      = EMP_REF_ID;
        int intRtn          = 0;
        int intRow          = ugrdTerm.Rows.Count;

        string sBias = "N";
        string sEst  = "N";

        Biz_Bsc_Kpi_Qlt_Est_Term objBSC = new Biz_Bsc_Kpi_Qlt_Est_Term();
        DataTable rDt = objBSC.GetSchema();
        DataRow rDr   = null;

        for (int i = 0; i < intRow; i++)
        {
            row = ugrdTerm.Rows[i];

            col = (TemplatedColumn)row.Band.Columns.FromKey("EST_YN");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("chkEst");
            sEst = (chk.Checked) ? "Y" : "N";

            col   = (TemplatedColumn)row.Band.Columns.FromKey("BIAS_YN");
            chk   = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("chkBias");
            sBias = (chk.Checked) ? "Y" : "N";
            
            rDr = rDt.NewRow();
            rDr["ESTTERM_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value);
            rDr["GROUP_REF_ID"]   = DataTypeUtility.GetToInt32(row.Cells.FromKey("GROUP_REF_ID").Value);
            rDr["EST_LEVEL"]      = DataTypeUtility.GetToInt32(row.Cells.FromKey("EST_LEVEL").Value);
            rDr["YMD"]            = DataTypeUtility.GetString(row.Cells.FromKey("YMD").Value);
            rDr["EST_YN"]         = sEst;
            rDr["BIAS_YN"]        = sBias;
            rDr["TXR_USER"]       = intTxrUser;
            rDt.Rows.Add(rDr);
        }

        intRtn = objBSC.TrxListData(rDt);

        return intRtn;
    }

    private int CopyKpiList()
    {
        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        objBSC.Iestterm_ref_id      = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
        objBSC.Igroup_ref_id        = PageUtility.GetIntByValueDropDownList(ddlEstGroup);
        objBSC.Iest_level           = PageUtility.GetIntByValueDropDownList(ddlEstLevel);
        objBSC.Itxr_user            = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.CopyValuationKpiList(objBSC.Iestterm_ref_id, objBSC.Igroup_ref_id, objBSC.Iest_level, this.IValidationUserID, objBSC.Itxr_user);
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        return intRtn;
    }

    #endregion

    #region 서버 이벤트 처리 함수
    protected void ddlEstGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetSelectedGroupList();

        this.ugrdKpiList.Clear();
        this.ugrdSelectValidationList.Clear();
        this.IValidationUserID = 0;
        this.lblUserName.Text  = "";
    }

    protected void ugrdVaidationUserGrid_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.IValidationUserID = (e.Row.Cells.FromKey("EMP_REF_ID").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString()) : 0;
        lblUserName.Text = (e.Row.Cells.FromKey("EMP_NAME").Value == null) ? "" : e.Row.Cells.FromKey("EMP_NAME").Value.ToString();
        this.SetKpiListPerValidationUser();
        this.ugrdKpiList.Clear();
        this.lblCntKpiTarget.Text = "0";
        //this.SetTargetKpiList();
    }

    protected void iBtnRemoveEmp_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IValidationUserID < 1 || this.lblUserName.Text.Trim().Length < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가자를 선택해주십시오", false);
            return;
        }

        int intRtn = this.RemoveKpiPerValidationUser();
        this.SetKpiListPerValidationUser();
        this.SetTargetKpiList();
        this.SetSelectedGroupList();
    }
    protected void iBtnAddEmp_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IValidationUserID < 1 || this.lblUserName.Text.Trim().Length < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가자를 선택해주십시오", false);
            return;
        }
        int intRtn = this.AddKpiPerValidationUser();
        this.SetKpiListPerValidationUser();
        this.SetTargetKpiList();
        this.SetSelectedGroupList();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetTargetKpiList();
        this.SetSelectedGroupList();
        this.SetKpiListPerValidationUser();
    }

    protected void iBtnSearchNotAlloc_Click(object sender, ImageClickEventArgs e)
    {
        this.SetTargetKpiListNotAllocate();
        this.ugrdSelectValidationList.Clear();
    }

    protected void iBtnCopyKpiList_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IValidationUserID < 1 || this.lblUserName.Text.Trim().Length < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가자를 선택해주십시오", false);
            return;
        }

        this.CopyKpiList();
        this.SetSelectedGroupList();
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetSelectedGroupList();
        this.ugrdSelectValidationList.Clear();
        this.ugrdKpiList.Clear();
    }

    protected void ugrdTerm_InitializeRow(object sender, RowEventArgs e)
    {
        string sEstYn  = DataTypeUtility.GetString(e.Row.Cells.FromKey("EST_YN").Value);
        string sBiasYn = DataTypeUtility.GetString(e.Row.Cells.FromKey("BIAS_YN").Value);

        CheckBox            chk;
        TemplatedColumn     col;
        col = (TemplatedColumn)e.Row.Band.Columns.FromKey("EST_YN");
        chk = (CheckBox)((CellItem)col.CellItems[e.Row.BandIndex]).FindControl("chkEst");

        chk.Checked = (sEstYn == "Y") ? true : false;

        col = (TemplatedColumn)e.Row.Band.Columns.FromKey("BIAS_YN");
        chk = (CheckBox)((CellItem)col.CellItems[e.Row.BandIndex]).FindControl("chkBias");

        chk.Checked = (sBiasYn == "Y") ? true : false;
    }

    protected void iBtnSaveEstTerm_Click(object sender, ImageClickEventArgs e)
    {
        int iRtn = this.SetKpiQltTerm();
        if (iRtn > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.", false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리시 오류가 발생되었습니다.", false);
        }
    }

    #endregion
}
