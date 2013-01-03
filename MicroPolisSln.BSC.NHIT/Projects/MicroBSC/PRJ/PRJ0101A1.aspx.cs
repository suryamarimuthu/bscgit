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
using System.Collections.Generic;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.BSC.Biz;
using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;
using System.Drawing;
using MicroBSC.Data;


public partial class PRJ_PRJ0101A1 : PrjPageBase
{
    #region ==========================[변수선언]================
    public int IPrjRefID
    {
        get
        {
            if (ViewState["PRJ_REF_ID"] == null)
            {
                ViewState["PRJ_REF_ID"] = GetRequestByInt("PRJ_REF_ID", 0);
            }

            return (int)ViewState["PRJ_REF_ID"];
        }
        set
        {
            ViewState["PRJ_REF_ID"] = value;
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

    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.IBtnShareAddRow.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lBtnAddRow.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

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
        
    /// <summary>
    /// 결재상태
    /// </summary>
    public string IApp_Status
    {
        get
        {
            if (ViewState["APP_STATUS"] == null)
            {
                ViewState["APP_STATUS"] = GetRequest("APP_STATUS");
            }
            return (string)ViewState["APP_STATUS"];
        }
        set
        {
            ViewState["APP_STATUS"] = value;
        }
    }

    /// <summary>
    /// 결재 상태명
    /// </summary>
    public string IApp_Status_Name
    {
        get
        {
            if (ViewState["APP_STATUS_NAME"] == null)
            {
                ViewState["APP_STATUS_NAME"] = GetRequest("APP_STATUS_NAME");
            }
            return (string)ViewState["APP_STATUS_NAME"];
        }
        set
        {
            ViewState["APP_STATUS_NAME"] = value;
        }
    }
    /// <summary>
    /// 결재 Id
    /// </summary>
    public decimal IApp_Ref_Id
    {
        get
        {
            if (ViewState["APP_REF_ID"] == null)
            {
                ViewState["APP_REF_ID"] = (decimal)GetRequestByInt("APP_REF_ID", 0);
            }

            return (decimal)ViewState["APP_REF_ID"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }

    /// <summary>
    /// 상신자
    /// </summary>
    public int IDraftEmpID
    {
        get
        {
            return (int)ViewState["DRAFT_EMP_ID"];
        }
        set
        {
            ViewState["DRAFT_EMP_ID"] = value;
        }
    }

    public string IAPP_CCB
    {
        get
        {
            if (ViewState["APP_CCB"] == null)
            {
                ViewState["APP_CCB"] = linkBtnDraft.ClientID.Replace('_', '$');
            }

            return (string)ViewState["APP_CCB"];
        }
        set
        {
            ViewState["APP_CCB"] = value;
        }
    }


    #endregion

    #region ================================= [ 결재처리 ]===================================
    /// <summary>
    /// 결재상태조회
    /// </summary>
    private void SetDraftInfo()
    {
        Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info(this.IApp_Ref_Id);
        this.IApp_Status = objApp.IApp_Status;
        this.IApp_Status_Name = objApp.IApp_Status_Name;
    }

    /// <summary>
    /// 수정결재요청
    /// </summary>
    private void RequestModifyDraft()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();
        bool blnRtn = objApp.RequestModifyDraft(this.IApp_Ref_Id, gUserInfo.Emp_Ref_ID);
        if (blnRtn)
        {
            this.SetDraftInfo();
            this.SetButton();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objApp.Transaction_Message, false);
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetFormInit();
            this.SetFormData();
        }
        else
        {

        }

        this.SetDraftInfo();
        SetButton();

        ltrScript.Text = "";

        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    private void SetButton()
    {
        // 프로젝트 책임자가 아닐경우
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        bool bIsOwner = objPrj.IsOwnerEmpIDYN(gUserInfo.Emp_Ref_ID, this.IPrjRefID);

        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;

        }
        else if (this.IType == "U")
        {
            //iBtnInsert.Visible = false;
            //iBtnUpdate.Visible = (this.IType == "D") ? false : true;
            //iBtnDelete.Visible = (this.IType == "D") ? false : true;
            //iBtnReUsed.Visible = (this.IType == "D") ? true : false;

            iBtnComplete_Y.Visible = false;
            iBtnComplete_N.Visible = false;

            switch (this.IApp_Status)
            {
                case "": // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnReUsed.Visible    = false;  
                    break;
                case Biz_Type.app_status_nodraft: // 결재상태 없음
                    iBtnDraft.Visible = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible = false;
                    iBtnReDraft.Visible = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible = false;

                    iBtnInsert.Visible = false;
                    iBtnUpdate.Visible = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnReUsed.Visible = false;
                    break;
                case Biz_Type.app_status_draft: // 상신
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = false;
                    iBtnDelete.Visible    = false;
                    iBtnReUsed.Visible    = false;
                    break;
                case Biz_Type.app_status_ondraft: // 결재중
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = false;
                    iBtnDelete.Visible    = false;
                    iBtnReUsed.Visible    = false;
                    break;
                case Biz_Type.app_status_return: // 반려
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnReUsed.Visible    = false;

                    break;
                case Biz_Type.app_status_recall: // 결재회수
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = (bIsOwner) ? true : false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = (bIsOwner) ? true : false;
                    iBtnDelete.Visible    = (bIsOwner) ? true : false;
                    iBtnReUsed.Visible    = false;
                    break;
                case Biz_Type.app_status_onmodify: // 수정결재
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible    = false;
                    iBtnReUsed.Visible    = false;

                    break;
                case Biz_Type.app_status_complete: // 결재완료
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = (bIsOwner) ? true : false;
                    iBtnReWrite.Visible   = false;

                    iBtnInsert.Visible    = false;
                    iBtnUpdate.Visible    = false;
                    iBtnDelete.Visible    = false;
                    iBtnReUsed.Visible    = false;

                    if (objPrj.IComplete_YN == "Y")
                    {
                        iBtnComplete_Y.Visible = false;
                        iBtnComplete_N.Visible = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    }
                    else
                    {
                        iBtnComplete_Y.Visible = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                        iBtnComplete_N.Visible = false;
                    }

                    break;
                default:
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    break;
            }


        }
        else if (this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = (this.IType == "D") ? false : true;
            iBtnDelete.Visible = (this.IType == "D") ? false : true;
            iBtnReUsed.Visible = (this.IType == "D") ? true : false;

            iBtnDraft.Visible = false;
            iBtnReDraft.Visible = false;
            iBtnMoDraft.Visible = false;
            iBtnReqModify.Visible = false;


        }
        else if (this.IType == "S")
        {
            iBtnInsert.Visible     = false;
            iBtnUpdate.Visible     = false;
            iBtnDelete.Visible     = false;
            iBtnReUsed.Visible     = false;

            iBtnDraft.Visible      = false;
            iBtnReDraft.Visible    = false;
            iBtnMoDraft.Visible    = false;
            iBtnReqModify.Visible  = false;

            iBtnComplete_Y.Visible = false;
            iBtnComplete_N.Visible = false;
        }
        else
        {
            iBtnInsert.Visible    = false;
            iBtnUpdate.Visible    = false;
            iBtnDelete.Visible    = false;
            iBtnReUsed.Visible    = false;

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;

        }

        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
        }
    }
    

    private void SetFormInit()
    {
        wdcPlanStartDate.Value = base.GetStartDayofCurrent();
        wdcPlanEndDate.Value = base.GetEndDayofCurrent();

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetProjectPriority(ddlPRIORITY, 0, false, 250);

        objCode.GetProjectType(ddlPrjType, 0, false, 250);

        WebCommon.SetComDeptDropDownList(ddlOwnerDeptID, true);
        //TextBoxCommon.SetOnlyInteger(txtTotalBudget);

        iBtnDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_first + "');";
        iBtnReDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_redraft + "');";
        iBtnReWrite.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_rewrite + "');";
        iBtnMoDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_modify + "');";
    }

    private void SetFormData()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        Biz_Prj_Resource prjResource = new Biz_Prj_Resource();
        Biz_Prj_Share objPrjShare = new Biz_Prj_Share();
        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        DataSet actualDs = objSchedule.GetActualDate(this.IPrjRefID);

        this.IApp_Ref_Id           = objPrj.IApp_Ref_Id;
        txtPRJ_CODE.Text           = objPrj.IPrj_Code;
        txtPRJ_NAME.Text           = objPrj.IPrj_Name;
        txtDEFINITION.Text         = objPrj.IDefinition;
        txtEFFECTIVENESS.Text      = objPrj.IEffectiveness;
        txtRANGE.Text              = objPrj.IRange;
        txtOWNER_EMP_ID.Text       = objPrj.IOwner_Emp_Name;
        hdfOWNER_EMP_ID.Value      = objPrj.IOwner_Emp_Id.ToString();
        this.IDraftEmpID           = objPrj.IOwner_Emp_Id;
        txtREF_STG.Text            = objPrj.IRef_Stg;
        txtREQUEST_DEPT.Text       = objPrj.IRequest_Dept;
        txtTotalBudget.Text        = objPrj.ITotal_Budget.ToString("###,##0");
        txtINTERESTED_PARTIES.Text = objPrj.IInterested_Parties;

        WebUtility.FindByValueDropDownList(ddlOwnerDeptID, objPrj.IOwner_Dept_Id);
        WebUtility.FindByValueDropDownList(ddlPRIORITY, objPrj.IPriority);
        WebUtility.FindByValueDropDownList(ddlPrjType, objPrj.IPrj_Type);

        wdcPlanStartDate.Value = objPrj.IPlan_Start_Date;
        wdcPlanEndDate.Value   = objPrj.IPlan_End_Date;

        wdcActualStartDate.Value = actualDs.Tables[0].Rows[0]["ACTUAL_START_DATE"];
        wdcActualEndDate.Value   = actualDs.Tables[0].Rows[0]["ACTUAL_END_DATE"];

        DataSet dsPSH = objPrjShare.GetAllList(this.IPrjRefID, 0);
        if (dsPSH.Tables.Count > 0)
        {
            dsPSH.Tables[0].DefaultView.Sort = "CREATE_DATE ASC";
            ugrdProjectShareList.Clear();
            ugrdProjectShareList.DataSource = dsPSH.Tables[0].DefaultView;
            ugrdProjectShareList.DataBind();
        }
        else
        {
            ugrdProjectShareList.Clear();
        }

        ugrdResourceList.Clear();
        ugrdResourceList.DataSource = prjResource.GetAllList(this.IPrjRefID, 0);
        ugrdResourceList.DataBind();
    }

    protected void ugrdResourceList_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

    }
    protected void ugrdResourceList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }

    protected void ImgBtnShareDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdProjectShareList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdProjectShareList.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < ugrdProjectShareList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdProjectShareList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdProjectShareList.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdProjectShareList.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    ugrdProjectShareList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    ugrdProjectShareList.Rows[i].Hidden = true;
                    chkCheck.Checked = false;
                }
                else if (striType == "A")
                {
                    ugrdProjectShareList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    ugrdProjectShareList.Rows[i].Hidden = true;
                }
            }
        }
    }
    protected void IBtnShareAddRow_Click(object sender, EventArgs e)
    {
        bool isCheck = false;

        //중복체크
        foreach (UltraGridRow row in ugrdProjectShareList.Rows)
        {
            if (row.Cells.FromKey("EMP_REF_ID").Value.ToString() == hdfValue1.Value.ToString())
            {
                row.Cells.FromKey("ITYPE").Value = "U";
                row.Hidden = false;
                isCheck = true;
                break;
            }
        }

        if (isCheck)
            return;

        int cntRow = 0;
        ugrdProjectShareList.Rows.Add();
        cntRow = ugrdProjectShareList.Rows.Count == 0 ? 0 : (ugrdProjectShareList.Rows.Count - 1);

        ugrdProjectShareList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        ugrdProjectShareList.Rows[cntRow].Cells.FromKey("EMP_REF_ID").Value = hdfValue1.Value;
        ugrdProjectShareList.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = hdfValue2.Value;
        ugrdProjectShareList.Rows[cntRow].Cells.FromKey("DEPT_CODE").Value = hdfValue3.Value;
        ugrdProjectShareList.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value = hdfValue4.Value;
    }

    protected void ImgBtnDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdResourceList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdResourceList.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < ugrdResourceList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdResourceList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdResourceList.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdResourceList.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    ugrdResourceList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    ugrdResourceList.Rows[i].Hidden = true;
                    chkCheck.Checked = false;
                }
                else if (striType == "A")
                {
                   // ugrdResourceList.Rows.Remove(ugrdRow);
                    ugrdResourceList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    ugrdResourceList.Rows[i].Hidden = true;
                }
            }
        }
    }
    protected void lBtnAddRow_Click(object sender, EventArgs e)
    {
        bool isCheck = false;

        //중복체크
        foreach (UltraGridRow row in ugrdResourceList.Rows)
        {
            if (row.Cells.FromKey("EMP_REF_ID").Value.ToString() == hdfValue1.Value.ToString())
            {
                row.Cells.FromKey("ITYPE").Value = "U";
                row.Hidden = false;
                isCheck = true;
                break;
            }
        }

        if (isCheck)
            return;

        int cntRow = 0;
        ugrdResourceList.Rows.Add();
        cntRow = ugrdResourceList.Rows.Count == 0 ? 0 : (ugrdResourceList.Rows.Count - 1);

        ugrdResourceList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        ugrdResourceList.Rows[cntRow].Cells.FromKey("EMP_REF_ID").Value = hdfValue1.Value;
        ugrdResourceList.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = hdfValue2.Value;
        ugrdResourceList.Rows[cntRow].Cells.FromKey("DAILY_PHONE").Value = hdfValue3.Value;
        ugrdResourceList.Rows[cntRow].Cells.FromKey("CELL_PHONE").Value = hdfValue4.Value;
        ugrdResourceList.Rows[cntRow].Cells.FromKey("EMP_EMAIL").Value = hdfValue5.Value;
    }


    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertViewData();
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateViewData();
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteViewData();
    }
    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedViewData();
    }
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = string.Format("<script language=javascript>parent.window.opener.__doPostBack('{0}',''); parent.window.close(); </script>", this.ICCB1);
    }

    //----------------------------- 결재처리 이벤트

    protected void linkBtnDraft_Click(object sender, EventArgs e)
    {
        //this.SetKPIMaster();
        this.SetDraftInfo();
        this.SetButton();
    }
    protected void iBtnDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnReDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnMoDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }

    protected void iBtnComplete_N_Click(object sender, ImageClickEventArgs e)
    {
        UpdateComplete("N");
    }
    protected void iBtnComplete_Y_Click(object sender, ImageClickEventArgs e)
    {
        UpdateComplete("Y");
    }

    private void UpdateComplete(string icompleteYN)
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info();
       
        objPrj.IPrj_Ref_Id = this.IPrjRefID;
        objPrj.IComplete_YN = icompleteYN;
       

        int intRtn = objPrj.UpdateComplete(objPrj.IPrj_Ref_Id
                                        , objPrj.IComplete_YN
                                         , gUserInfo.Emp_Ref_ID
                                       );

        if (intRtn > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("사업정보 마감정보가 변경되었습니다.");
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void InsertViewData()
    {
        if (this.CheckFormData())
        {
            ltrScript.Text = JSHelper.GetAlertScript("사업아이디 또는 사업명이 동일한 값이 존재합니다.");
            return;
        }

     
        #region 기본정보 저장

        Biz_Prj_Info objPrj = new Biz_Prj_Info();
        Biz_Prj_Resource objResource = new Biz_Prj_Resource();
        Biz_Prj_Share objPrjShare = new Biz_Prj_Share();


        objPrj.IPrj_Code = txtPRJ_CODE.Text.Trim();
        objPrj.IPrj_Name = txtPRJ_NAME.Text.Trim();
        objPrj.IDefinition = txtDEFINITION.Text.Trim();
        objPrj.IRef_Stg = txtREF_STG.Text.Trim();
        objPrj.IEffectiveness = txtEFFECTIVENESS.Text.Trim();
        objPrj.IRange = txtRANGE.Text.Trim();
        objPrj.IOwner_Dept_Id = WebUtility.GetIntByValueDropDownList(ddlOwnerDeptID);
        objPrj.IOwner_Emp_Id = DataTypeUtility.GetToInt32(hdfOWNER_EMP_ID.Value);
        objPrj.IRequest_Dept = txtREQUEST_DEPT.Text.Trim();
        objPrj.IPriority = WebUtility.GetByValueDropDownList(ddlPRIORITY);
        objPrj.ITotal_Budget = DataTypeUtility.GetToDecimal(txtTotalBudget.Text);
        objPrj.IPrj_Type = WebUtility.GetByValueDropDownList(ddlPrjType);
        objPrj.IInterested_Parties = txtINTERESTED_PARTIES.Text.Trim();
        objPrj.IPlan_Start_Date = wdcPlanStartDate.Value;
        objPrj.IPlan_End_Date = wdcPlanEndDate.Value;
        objPrj.IActual_Start_Date = wdcActualStartDate.Value;
        objPrj.IActual_End_Date = wdcActualEndDate.Value;

        int intRtn = objPrj.InsertData(objPrj.IPrj_Code
                                        , objPrj.IPrj_Name
                                        , 0
                                        , objPrj.IDefinition
                                        , objPrj.IRef_Stg
                                        , objPrj.IEffectiveness
                                        , objPrj.IRange
                                        , objPrj.IOwner_Dept_Id
                                        , objPrj.IOwner_Emp_Id
                                        , objPrj.IRequest_Dept
                                        , objPrj.IPriority
                                        , objPrj.ITotal_Budget
                                        , objPrj.IPrj_Type
                                        , objPrj.IInterested_Parties
                                        , objPrj.IPlan_Start_Date
                                        , objPrj.IPlan_End_Date
                                        , objPrj.IActual_Start_Date
                                        , objPrj.IActual_End_Date
                                        , gUserInfo.Emp_Ref_ID
                                       );


        this.IPrjRefID = objPrj.IPrj_Ref_Id;

        //사업정보공유정보저장

        foreach (UltraGridRow row in ugrdProjectShareList.Rows)
        {
            objPrjShare.IPrj_Ref_Id = this.IPrjRefID;
            objPrjShare.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objPrjShare.InsertData(objPrjShare.IPrj_Ref_Id
                      , objPrjShare.IEmp_Ref_Id
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objPrjShare.DeleteData(objPrjShare.IPrj_Ref_Id
                    , objPrjShare.IEmp_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }


        //사업수행구성원저장

        foreach (UltraGridRow row in ugrdResourceList.Rows)
        {
            objResource.IPrj_Ref_Id = this.IPrjRefID;
            objResource.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);
            objResource.IRole_Type = DataTypeUtility.GetValue(row.Cells.FromKey("ROLE_TYPE").Value);
            objResource.INote = DataTypeUtility.GetValue(row.Cells.FromKey("NOTE").Value);
            objResource.IIsdelete = DataTypeUtility.GetValue(row.Cells.FromKey("ISDELETE").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objResource.InsertData(objResource.IPrj_Ref_Id
                      , objResource.IEmp_Ref_Id
                      , objResource.IRole_Type
                      , objResource.INote
                      , objResource.IIsdelete
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objResource.UpdateData(objResource.IPrj_Ref_Id
                                   , objResource.IEmp_Ref_Id
                                   , objResource.IRole_Type
                                   , objResource.INote
                                   , objResource.IIsdelete
                                   , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objResource.DeleteData(objResource.IPrj_Ref_Id
                    , objResource.IEmp_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }

        #endregion

        #region 일정관리
        //Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        //objSchedule.IPrj_Ref_Id = this.IPrjRefID;
        //objSchedule.IUp_Task_Ref_Id = 0;

        //intRtn += objSchedule.InsertData(objSchedule.IPrj_Ref_Id
        //                        , 0
        //                        , this.txtPRJ_NAME.Text.Trim()
        //                        , "PAS"
        //                        , 0
        //                        , objSchedule.IUp_Task_Ref_Id
        //                        , "1.0"
        //                        , this.wdcPlanStartDate.Value
        //                        , this.wdcPlanEndDate.Value
        //                        , null
        //                        , null
        //                        , 0
        //                        , ""
        //                        , "N"
        //                        , "N"
        //                        , 0
        //                        , -1
        //                        , ""
        //                        , gUserInfo.Emp_Ref_ID);



        MicroBSC.Integration.PRJ.Biz.Biz_Prj_Schedule bizPrjSchedule = new MicroBSC.Integration.PRJ.Biz.Biz_Prj_Schedule();

        intRtn += bizPrjSchedule.AddData(this.IPrjRefID
                                    , 0
                                    , this.txtPRJ_NAME.Text.Trim()
                                    , "PAS"
                                    , 0
                                    , "1.0"
                                    , 0
                                    , this.wdcPlanStartDate.Value
                                    , this.wdcPlanEndDate.Value
                                    , null
                                    , null
                                    , 0
                                    , ""
                                    , "N"
                                    , "N"
                                    , 0
                                    , -1
                                    , ""
                                    , gUserInfo.Emp_Ref_ID);

        #endregion

        if (intRtn > 0)
        {
            string url = "./PRJ0101M1.aspx?iType=U&PRJ_REF_ID=" + this.IPrjRefID + "&CCB1=" + ICCB1;
            ltrScript.Text = string.Format("<script language=javascript>parent.location.replace('" + url + "'); </script>");
        }
    }

    private void UpdateViewData()
    {
        #region 기본정보 저장

        Biz_Prj_Info objPrj = new Biz_Prj_Info();
        Biz_Prj_Resource objResource = new Biz_Prj_Resource();
        Biz_Prj_Share objPrjShare = new Biz_Prj_Share();

        objPrj.IPrj_Ref_Id = this.IPrjRefID;
        objPrj.IPrj_Code = txtPRJ_CODE.Text.Trim();
        objPrj.IPrj_Name = txtPRJ_NAME.Text.Trim();
        objPrj.IDefinition = txtDEFINITION.Text.Trim();
        objPrj.IRef_Stg = txtREF_STG.Text.Trim();
        objPrj.IEffectiveness = txtEFFECTIVENESS.Text.Trim();
        objPrj.IRange = txtRANGE.Text.Trim();
        objPrj.IOwner_Dept_Id = WebUtility.GetIntByValueDropDownList(ddlOwnerDeptID);
        objPrj.IOwner_Emp_Id = DataTypeUtility.GetToInt32(hdfOWNER_EMP_ID.Value);
        objPrj.IRequest_Dept = txtREQUEST_DEPT.Text.Trim();
        objPrj.IPriority = WebUtility.GetByValueDropDownList(ddlPRIORITY);
        objPrj.ITotal_Budget = DataTypeUtility.GetToDecimal(txtTotalBudget.Text);
        objPrj.IPrj_Type = WebUtility.GetByValueDropDownList(ddlPrjType);
        objPrj.IInterested_Parties = txtINTERESTED_PARTIES.Text.Trim();
        objPrj.IPlan_Start_Date = wdcPlanStartDate.Value;
        objPrj.IPlan_End_Date = wdcPlanEndDate.Value;
        objPrj.IActual_Start_Date = wdcActualStartDate.Value;
        objPrj.IActual_End_Date = wdcActualEndDate.Value;

        int intRtn = objPrj.UpdateData(objPrj.IPrj_Ref_Id
                                        , objPrj.IPrj_Code
                                        , objPrj.IPrj_Name
                                        , 0
                                        , objPrj.IDefinition
                                        , objPrj.IRef_Stg
                                        , objPrj.IEffectiveness
                                        , objPrj.IRange
                                        , objPrj.IOwner_Dept_Id
                                        , objPrj.IOwner_Emp_Id
                                        , objPrj.IRequest_Dept
                                        , objPrj.IPriority
                                        , objPrj.ITotal_Budget
                                        , objPrj.IPrj_Type
                                        , objPrj.IInterested_Parties
                                        , objPrj.IPlan_Start_Date
                                        , objPrj.IPlan_End_Date
                                        , objPrj.IActual_Start_Date
                                        , objPrj.IActual_End_Date
                                        , gUserInfo.Emp_Ref_ID
                                       );

        //사업정보공유정보저장

        foreach (UltraGridRow row in ugrdProjectShareList.Rows)
        {
            objPrjShare.IPrj_Ref_Id = this.IPrjRefID;
            objPrjShare.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objPrjShare.InsertData(objPrjShare.IPrj_Ref_Id
                      , objPrjShare.IEmp_Ref_Id
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objPrjShare.DeleteData(objPrjShare.IPrj_Ref_Id
                    , objPrjShare.IEmp_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }

        //사업수행구성원저장

        foreach (UltraGridRow row in ugrdResourceList.Rows)
        {
            objResource.IPrj_Ref_Id = this.IPrjRefID;
            objResource.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);
            objResource.IRole_Type = DataTypeUtility.GetValue(row.Cells.FromKey("ROLE_TYPE").Value);
            objResource.INote = DataTypeUtility.GetValue(row.Cells.FromKey("NOTE").Value);
            objResource.IIsdelete = DataTypeUtility.GetValue(row.Cells.FromKey("ISDELETE").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objResource.InsertData(objResource.IPrj_Ref_Id
                      , objResource.IEmp_Ref_Id
                      , objResource.IRole_Type
                      , objResource.INote
                      , objResource.IIsdelete
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objResource.UpdateData(objResource.IPrj_Ref_Id
                                   , objResource.IEmp_Ref_Id
                                   , objResource.IRole_Type
                                   , objResource.INote
                                   , objResource.IIsdelete
                                   , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objResource.DeleteData(objResource.IPrj_Ref_Id
                    , objResource.IEmp_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }

        #endregion

        if (intRtn > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("사업정보가 저장되었습니다.");
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void DeleteViewData()
    {
        #region 기본정보 삭제
        Biz_Prj_Info objPrj = new Biz_Prj_Info();

        objPrj.IPrj_Ref_Id = this.IPrjRefID;

        int intRtn = objPrj.DeleteData(objPrj.IPrj_Ref_Id
                                        , gUserInfo.Emp_Ref_ID
                                       );

        ltrScript.Text = JSHelper.GetAlertScript(objPrj.Transaction_Message, false);

        if (objPrj.Transaction_Result == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertScript("사업정보가 삭제되었습니다.");
            this.IType = "D";
            this.SetFormData();
            this.SetButton();
        }
        else
        {
        }
        #endregion
    }

    private void ReUsedViewData()
    {
    
        Biz_Prj_Info objPrj = new Biz_Prj_Info();

        objPrj.IPrj_Ref_Id = this.IPrjRefID;

        int intRtn = objPrj.ReUsedData(objPrj.IPrj_Ref_Id
                                        , gUserInfo.Emp_Ref_ID
                                       );

        ltrScript.Text = JSHelper.GetAlertScript(objPrj.Transaction_Message, false);

        if (objPrj.Transaction_Result == "Y")
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
        else
        {
        }
    }

    private bool CheckFormData()
    {
        bool isCheck = false;

        Biz_Prj_Info objPrj = new Biz_Prj_Info();
        objPrj.IPrj_Code = txtPRJ_CODE.Text.Trim();
        objPrj.IPrj_Name = txtPRJ_NAME.Text.Trim();

        isCheck = objPrj.IsExist(objPrj.IPrj_Code, objPrj.IPrj_Name);

        return isCheck;

    }

   
}
