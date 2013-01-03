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


public partial class PRJ_PRJ0101A4 : PrjPageBase
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

    public int ITaskRefID
    {
        get
        {
            if (ViewState["TASK_REF_ID"] == null)
            {
                ViewState["TASK_REF_ID"] = GetRequestByInt("TASK_REF_ID", 0);
            }

            return (int)ViewState["TASK_REF_ID"];
        }
        set
        {
            ViewState["TASK_REF_ID"] = value;
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
            this.SetDraftInfo();

            this.setKpiPrjData();
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

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;

            btnOut.Visible        = false;
            btnIn.Visible         = false;

        }
        else if (this.IType == "U")
        {
            switch (this.IApp_Status)
            {
                case "": // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    btnOut.Visible        = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    btnIn.Visible         = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_nodraft: // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    btnOut.Visible        = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    btnIn.Visible         = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_draft: // 상신
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    btnOut.Visible        = false;
                    btnIn.Visible         = false;

                    break;
                case Biz_Type.app_status_ondraft: // 결재중
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    btnOut.Visible        = false;
                    btnIn.Visible         = false;

                    break;
                case Biz_Type.app_status_return: // 반려
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    btnOut.Visible        = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    btnIn.Visible         = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_recall: // 회수
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = (bIsOwner) ? true : false;

                    btnOut.Visible        = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    btnIn.Visible         = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_onmodify: // 수정결재
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    btnOut.Visible        = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    btnIn.Visible         = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    
                    break;
                case Biz_Type.app_status_complete: // 결재완료
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = (bIsOwner) ? true : false;

                    btnOut.Visible        = false;
                    btnIn.Visible         = false;

                    break;
                default:
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;
                    break;
            }


        }
        else if (this.IType == "D")
        {

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;
            iBtnReWrite.Visible   = false;


        }
        else if(this.IType == "S")
        {
            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;
            iBtnReWrite.Visible   = false;

            btnOut.Visible        = false;
            btnIn.Visible         = false;

        }
        else
        {
            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;
            iBtnReWrite.Visible   = false;

            btnOut.Visible        = false;
            btnIn.Visible         = false;

        }
    }

    public void SetFormInit()
    {

        hdfPrjRefID.Value = this.IPrjRefID.ToString();

        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetComDeptDropDownList(ddlEstDept, false);

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultInput, "", true, 120);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);

        iBtnDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_first + "');";
        iBtnReDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_redraft + "');";
        iBtnMoDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_modify + "');";
        iBtnReWrite.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_rewrite + "');";

    }

    public void SetFormData()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        this.IApp_Ref_Id = objPrj.IApp_Ref_Id;
        txtPRJ_CODE.Text = objPrj.IPrj_Code;
        txtPRJ_NAME.Text = objPrj.IPrj_Name;
        this.IDraftEmpID = objPrj.IOwner_Emp_Id;
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        //ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        ltrScript.Text = string.Format("<script language=javascript>parent.window.opener.__doPostBack('{0}',''); parent.window.close(); </script>", this.ICCB1);
    }

    protected void btnOut_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdKpiPrjList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdKpiPrjList.Bands[0].Columns.FromKey("selchk");
        
        Biz_Bsc_Kpi_Prj objKpiPrj = new Biz_Bsc_Kpi_Prj();
        int iRtn = 0;

        for (int i = 0; i < ugrdKpiPrjList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdKpiPrjList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdKpiPrjList.Rows[i];
            if (chkCheck.Checked)
            {
                objKpiPrj.IEstterm_Ref_Id = DataTypeUtility.GetToInt32(ugrdRow.Cells.FromKey("ESTTERM_REF_ID"));
                objKpiPrj.IKpi_Ref_Id = DataTypeUtility.GetToInt32(ugrdRow.Cells.FromKey("KPI_REF_ID"));
                objKpiPrj.IPrj_Ref_Id = DataTypeUtility.GetToInt32(ugrdRow.Cells.FromKey("PRJ_REF_ID"));

                iRtn += objKpiPrj.DeleteData(objKpiPrj.IEstterm_Ref_Id, objKpiPrj.IKpi_Ref_Id, objKpiPrj.IPrj_Ref_Id);
            }
        }


        this.setKpiPrjData();
        this.setKpiData();

    }
    protected void btnIn_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdKpiList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdKpiList.Bands[0].Columns.FromKey("selchk");
        Biz_Bsc_Kpi_Prj objKpiPrj = new Biz_Bsc_Kpi_Prj();
        int iRtn = 0;

        for (int i = 0; i < ugrdKpiList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdKpiList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdKpiList.Rows[i];
            if (chkCheck.Checked)
            {
                objKpiPrj.IEstterm_Ref_Id = DataTypeUtility.GetToInt32(ugrdRow.Cells.FromKey("ESTTERM_REF_ID"));
                objKpiPrj.IKpi_Ref_Id = DataTypeUtility.GetToInt32(ugrdRow.Cells.FromKey("KPI_REF_ID"));
                objKpiPrj.IPrj_Ref_Id = this.IPrjRefID;

                if(!objKpiPrj.IsExist(objKpiPrj.IEstterm_Ref_Id, objKpiPrj.IKpi_Ref_Id, objKpiPrj.IPrj_Ref_Id))
                    iRtn += objKpiPrj.InsertData(objKpiPrj.IEstterm_Ref_Id, objKpiPrj.IKpi_Ref_Id, objKpiPrj.IPrj_Ref_Id, gUserInfo.Emp_Ref_ID);
            }
        }

        this.setKpiPrjData();
        this.setKpiData();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setKpiPrjData();
        this.setKpiData();
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
    

    public void setKpiData()
    {
        if (ddlEstTermInfo.Items.Count < 1)
        {
            PageUtility.AlertMessage("등록된 평가기간이 없습니다.");
            return;
        }

        Biz_Bsc_Kpi_Prj objBSC = new Biz_Bsc_Kpi_Prj();

        int iEstterm_ref_id = WebUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        string iResult_input_type = WebUtility.GetByValueDropDownList(ddlResultInput);
        string iKpiGroup_ref_id = WebUtility.GetByValueDropDownList(ddlKpiGroupRefID);
        string iKpi_code = txtKPICode.Text.Trim();
        string iKpi_name = txtKPIName.Text.Trim();
        string iChampion_emp_name = txtChamName.Text.Trim();
        int iDept_ref_id = (ddlEstDept.SelectedValue.Trim() == "") ? -1 : int.Parse(ddlEstDept.SelectedValue);

        DataSet ds = objBSC.GetKpiList
                                (iEstterm_ref_id
                               , this.IPrjRefID
                               , iResult_input_type
                               , iKpi_code
                               , iKpi_name
                               , iChampion_emp_name
                               , iDept_ref_id
                               , iKpiGroup_ref_id
                               , gUserInfo.Emp_Ref_ID);

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = ds;
        ugrdKpiList.DataBind();

        //lblCountRow.Text = "Total Rows : " + ds.Tables[0].Rows.Count.ToString();
    }

    private void setKpiPrjData()
    {
        Biz_Bsc_Kpi_Prj objKpiPrj = new Biz_Bsc_Kpi_Prj();

        objKpiPrj.IEstterm_Ref_Id = WebUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        objKpiPrj.IKpi_Ref_Id = 0;
        objKpiPrj.IPrj_Ref_Id = DataTypeUtility.GetToInt32(hdfPrjRefID.Value);

        DataSet ds = objKpiPrj.GetAllList(objKpiPrj.IEstterm_Ref_Id, objKpiPrj.IKpi_Ref_Id, objKpiPrj.IPrj_Ref_Id);

        ugrdKpiPrjList.Clear();
        ugrdKpiPrjList.DataSource = ds;
        ugrdKpiPrjList.DataBind();
       
    }
}
