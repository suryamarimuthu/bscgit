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

public partial class PRJ_PRJ0101A2 : PrjPageBase
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


    public string ICCB4
    {
        get
        {
            if (ViewState["CCB4"] == null)
            {
                ViewState["CCB4"] = GetRequest("CCB4", this.lBtnTaskShareAddRow.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB4"];
        }
        set
        {
            ViewState["CCB4"] = value;
        }
    }

    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.lBtnTaskOwnerAddRow.ClientID.Replace('_', '$'));
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

    private string   _taskCode;
    private string   _taskName;
    private int      _upTaskRefID;
    private string   _upTaskName;
    private string   _taskType;
    private decimal  _taskWeight;
    private DateTime _schPlanStartDate;
    private DateTime _schPlanEndDate;
    private DateTime _schActualStartDate;
    private DateTime _schActualEndDate;
    private decimal  _proceedRate;
    private string   _attFile;
    private int      _selectNodeValue = 0;
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
            iBtnAddBrother.Visible = false;
            iBtnAddChild.Visible   = false;
            iBtnUpdate.Visible     = false;
            iBtnDelete.Visible     = false;

            iBtnDraft.Visible      = false;
            iBtnReDraft.Visible    = false;
            iBtnMoDraft.Visible    = false;
            iBtnReqModify.Visible  = false;

        }
        else if (this.IType == "U")
        {
            //iBtnAddBrother.Visible = true;
            //iBtnAddChild.Visible = true;
            //iBtnUpdate.Visible = true;
            //iBtnDelete.Visible = true;

            switch (this.IApp_Status)
            {
                case "": // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = true;
                    iBtnAddChild.Visible   = true;
                    iBtnUpdate.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_nodraft: // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = true;
                    iBtnAddChild.Visible   = true;
                    iBtnUpdate.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_draft: // 상신
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = false;
                    iBtnAddChild.Visible   = false;
                    iBtnUpdate.Visible     = false;
                    iBtnDelete.Visible     = false;

                    break;
                case Biz_Type.app_status_ondraft: // 결재중
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = false;
                    iBtnAddChild.Visible   = false;
                    iBtnUpdate.Visible     = false;
                    iBtnDelete.Visible     = false;
                    break;
                case Biz_Type.app_status_return: // 반려
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = true;
                    iBtnAddChild.Visible   = true;
                    iBtnUpdate.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;

                    break;
                case Biz_Type.app_status_recall: // 회수
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = (bIsOwner) ? true : false;;

                    iBtnAddBrother.Visible = true;
                    iBtnAddChild.Visible   = true;
                    iBtnUpdate.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;

                    break;
                case Biz_Type.app_status_onmodify: // 수정결재
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = true;
                    iBtnAddChild.Visible   = true;
                    iBtnUpdate.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    iBtnDelete.Visible     = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;

                    break;
                case Biz_Type.app_status_complete: // 결재완료
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = true;
                    iBtnReWrite.Visible   = false;

                    iBtnAddBrother.Visible = false;
                    iBtnAddChild.Visible   = false;
                    iBtnUpdate.Visible     = false;
                    iBtnDelete.Visible     = false;

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
            iBtnAddBrother.Visible = true;
            iBtnAddChild.Visible   = true;
            iBtnUpdate.Visible     = true;
            iBtnDelete.Visible     = true;

            iBtnDraft.Visible      = false;
            iBtnReDraft.Visible    = false;
            iBtnMoDraft.Visible    = false;
            iBtnReqModify.Visible  = false;
        }
        else if (this.IType == "S")
        {
            iBtnAddBrother.Visible = false;
            iBtnAddChild.Visible   = false;
            iBtnUpdate.Visible     = false;
            iBtnDelete.Visible     = false;

            iBtnDraft.Visible      = false;
            iBtnReDraft.Visible    = false;
            iBtnMoDraft.Visible    = false;
            iBtnReqModify.Visible  = false;

        }
        else
        {
            iBtnAddBrother.Visible = false;
            iBtnAddChild.Visible   = false;
            iBtnUpdate.Visible     = false;
            iBtnDelete.Visible     = false;

            iBtnDraft.Visible      = false;
            iBtnReDraft.Visible    = false;
            iBtnMoDraft.Visible    = false;
            iBtnReqModify.Visible  = false;

        }
    }

    public void SetFormInit()
    {

        //wdcPlanStartDate.Value = base.GetStartDayofCurrent();
        //wdcPlanEndDate.Value = base.GetEndDayofCurrent();

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetTaskType(ddlTaskType, 0, false, 120);

        TextBoxCommon.SetOnlyInteger(txtProceedRate);

        ListItem itemA = new ListItem("파일선택", "");
        ddlFileUpload.Items.Insert(0, itemA);

        iBtnDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_first + "');";
        iBtnReDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_redraft + "');";
        iBtnMoDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_modify + "');";
        iBtnReWrite.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_rewrite + "');";

        txtTaskCode.Attributes.Add("onkeypress", "return processKeyPress();");
        txtTaskName.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchPlanStartDate.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchPlanEndDate.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchActualStartDate.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchActualEndDate.Attributes.Add("onkeypress", "return processKeyPress();");

        txtProceedRate.Attributes.Add("onkeypress", "return processKeyPress();");
        txtProceedRate.Attributes.Add("onBlur", "return CheckValue();");
        
    }

    public void SetFormData()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);

        this.IApp_Ref_Id = objPrj.IApp_Ref_Id;

        txtPRJ_CODE.Text = objPrj.IPrj_Code;
        txtPRJ_NAME.Text = objPrj.IPrj_Name;
        this.IDraftEmpID = objPrj.IOwner_Emp_Id;

        SetTaskTree();
    }

    /// <summary>
    /// 일정트리조회
    /// </summary>
    public void SetTaskTree()
    {
        this.BindSchedule(this.TtrvTask, false, TreeNodeSelectAction.Select, "");
    }

    private void SetUploadFileInfo(string asAttachNo, DropDownList ddlFileUpload)
    {
        DataSet lDS = new DataSet();

        ddlFileUpload.Items.Clear();

        Biz_Base_FileUpload bizUpload = new Biz_Base_FileUpload();
        lDS = bizUpload.GetFileUploaded(asAttachNo);

        for (int i = 0; i < lDS.Tables[0].Rows.Count; i++)
        {
            ddlFileUpload.Items.Add(new ListItem(lDS.Tables[0].Rows[i]["v_FileText"].ToString(), lDS.Tables[0].Rows[i]["v_FileValue"].ToString()));
        }

        ddlFileUpload.Items.Insert(0, new ListItem("파일선택", ""));

        if (ddlFileUpload.Items.Count > 1)
        {
            ddlFileUpload.Items[1].Selected = true;
        }
    }

    private TreeNode CreateNode(DataRow row
                                   , string imageurl
                                   , bool expanded
                                   , TreeNodeSelectAction treeNodeSel
                                   , bool showChk
                                   , int nodeDepth
                                   )
    {
        // ChildRow Sorting
        //row.Table.DefaultView.Sort = "TASK_CODE DESC";


        TreeNode node = new TreeNode();
        node.Value = row["TASK_REF_ID"].ToString();

        int nodeWidth = 0;

        switch (DataTypeUtility.GetToInt32(row["NODE_DEPTH"]))
        {
            case 0:
                nodeWidth = 343;
                break;
            case 1:
                nodeWidth = 320;
                break;
            case 2:
                nodeWidth = 300;
                break;
            case 3:
                nodeWidth = 280;
                break;
            case 4:
                nodeWidth = 260;
                break;
            case 5:
                nodeWidth = 240;
                break;
            case 6:
                nodeWidth = 220;
                break;
            case 7:
                nodeWidth = 200;
                break;
        }

        string strcolor = "#FFFFFF";

        if (hdfSelectNode.Value == node.Value)
        {
            strcolor = "#c9cee1";
        }

        string strText = "";
        string strPlanStartDate = "";
        string strPlanEndDate = "";
        string strProceedRate = "";

        if (DataTypeUtility.GetToInt32(row["UP_TASK_REF_ID"]) == 0)
        {
            Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
            object oRate = objSchedule.GetTotalRate(DataTypeUtility.GetToInt32(row["PRJ_REF_ID"]), 0);
            double dTotalRate = 0;

            strPlanStartDate = DataTypeUtility.GetToDateTimeText(GetPrjDate(PrjPeriodDate.PLAN_START));
            strPlanEndDate = DataTypeUtility.GetToDateTimeText(GetPrjDate(PrjPeriodDate.PLAN_END));

            dTotalRate = DataTypeUtility.GetToDouble(oRate);
            strProceedRate = dTotalRate.ToString("##0.#0") + " %";
        }
        else
        {
            strPlanStartDate = DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]);
            strPlanEndDate   = DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]);
            strProceedRate   = DataTypeUtility.GetToDouble(row["PROCEED_RATE"]).ToString("##0.#0") + " %";
        }

        strText += "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='height:20px;'>";
        strText += "<tr bgcolor=" + strcolor + " style=\"cursor:hand\" onMouseOver=\"this.style.backgroundColor='#c9cee1';return true;\" onMouseOut=\"this.style.backgroundColor='';return true;\" onclick=\"javascript:selectNode('" + node.Value + "');\">";
        strText += "<td  width='" + nodeWidth.ToString() + "px' align='left'>" + row["TASK_NAME"].ToString() + "</td>";
        strText += "<td  width='70px' align='right'>" + strPlanStartDate + "</td>";
        strText += "<td  width='90px' align='right'>" + strPlanEndDate + "</td>";
        strText += "<td  width='70px' align='right'>" + strProceedRate + "</td>";
        strText += "</tr>";
        strText += "</table>";

        node.NavigateUrl = "";
        node.Text = strText;
        node.ImageUrl = imageurl;
        node.SelectAction = treeNodeSel;
        node.Expanded = expanded;
        node.ShowCheckBox = showChk;

        return node;
    }

    public void BindSchedule(TreeView treeView
                                    , bool isCheckBox
                                    , TreeNodeSelectAction treeNodeSelectAction
                                    , string checkedValues)
    {
        string valueStr    = "TASK_REF_ID";
        string up_valueStr = "UP_TASK_REF_ID";

        //string valueStr     = "SF_TASK_CODE";
        //string up_valueStr  = "PT_TASK_CODE";
        string textStr      = "TASK_NAME";
        string iconStr      = "TASK_TYPE";
        string imageUrlDir  = "../images/treeview/";
        bool isExtended     = true;
        DataTable dataTable = null;

        // 부모 페이지에서 값이 수정되었을 경우를 위해서 체크박스에 대한 값을 처리하기 
        // 위해서 추가 되는 부분
        if (isCheckBox && (checkedValues != null || checkedValues == ""))
        {
            dataTable = new DataTable();
            DataRow dr = null;
            dataTable.Columns.Add("VALUE", typeof(string));
            dataTable.Columns.Add("OK_YN", typeof(string));

            string[] values = checkedValues.Split(',');

            foreach (string val in values)
            {
                dr = dataTable.NewRow();
                dr["VALUE"] = val;
                dr["OK_YN"] = "N";
                dataTable.Rows.Add(dr);
            }
        }

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        DataSet ds = objSchedule.GetAllList(this.IPrjRefID, 0);

        ds.Relations.Add("NodeRelation"
                        , ds.Tables[0].Columns[valueStr]
                        , ds.Tables[0].Columns[up_valueStr]
                        , false);

        treeView.Nodes.Clear();


        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (DataTypeUtility.GetString(dbRow[up_valueStr]) == "0")
            {
                TreeNode rootNode = CreateNode(dbRow
                                        , imageUrlDir + "root.gif"
                                        , isExtended
                                        , treeNodeSelectAction
                                        , isCheckBox
                                        , 0);


                treeView.Nodes.Add(rootNode);
                PopulateScheduleTree(dbRow, rootNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, isExtended, isCheckBox, dataTable);
            }
        }
    }

    private void PopulateScheduleTree(DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , string iconStr
                                        , TreeNodeSelectAction treeNodeSelectAction
                                        , bool expanded
                                        , bool isCheckBox
                                        , DataTable callbackDataTable
                                       )
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            TreeNode childNode = CreateNode(childRow
                                            , imageUrlDir + "tasks.gif"
                                            , expanded
                                            , treeNodeSelectAction
                                            , isCheckBox
                                            , node.Depth);


            node.ChildNodes.Add(childNode);

            PopulateScheduleTree(childRow, childNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, expanded, isCheckBox, callbackDataTable);
        }
    }

    private DataRow GetBudGetYM(DataTable dt, string budgetYM)
    {
        DataRow dataRow = null;

        foreach (DataRow row in dt.Rows)
        {
            if (row["BUDGET_YM"].ToString() == budgetYM)
            {
                dataRow = row;
                break;
            }
        }

        return dataRow;
    }

    private void SetParameter()
    {
        _taskCode         = txtTaskCode.Text.Trim();
        _taskName         = DataTypeUtility.GetValue(txtTaskName.Text.Trim());
        _upTaskRefID      = DataTypeUtility.GetToInt32(hdfUpTaskRefID.Value);
        _upTaskName       = DataTypeUtility.GetValue(txtUPTaskName.Text.Trim());
        _taskType         = WebUtility.GetByValueDropDownList(ddlTaskType);
        _taskWeight       = DataTypeUtility.GetToDecimal(txtWeight.Text);
        _schPlanStartDate = DataTypeUtility.GetToDateTime(wdcSchPlanStartDate.Value);
        _schPlanEndDate   = DataTypeUtility.GetToDateTime(wdcSchPlanEndDate.Value);
        _schActualStartDate = DataTypeUtility.GetToDateTime(wdcSchActualStartDate.Value);
        _schActualEndDate   = DataTypeUtility.GetToDateTime(wdcSchActualEndDate.Value);
        _proceedRate        = DataTypeUtility.GetToDecimal(txtProceedRate.Text.Trim());
        //_attFile                = DataTypeUtility.GetValue(txtAttFile.Text.Trim());

    }

    private void AddDeptNode(string strGubun)
    {
        if (this.ITaskRefID == 0 || txtTaskCode.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("작업을 선택해주십시오.", false);
            return;
        }

        if (strGubun == "BROTHER" && (hdfUpTaskRefID.Value.Trim() == "" || txtUPTaskName.Text.Trim() == ""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("프로젝트레벨이므로 동위레벨등록을 할수 없습니다.", false);
            return;
        }

        this.SetParameter();
        if (strGubun == "CHILD")
        {
            _upTaskRefID = this.ITaskRefID;
        }

        this.ITaskRefID = -1;

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        objSchedule.IPrj_Ref_Id        = this.IPrjRefID;
        objSchedule.ITask_Ref_Id       = this.ITaskRefID;
        objSchedule.ITask_Code         = _taskCode;
        objSchedule.ITask_Name         = _taskName;
        objSchedule.IUp_Task_Ref_Id    = _upTaskRefID;
        objSchedule.ITask_Type         = _taskType;
        objSchedule.ITask_Weight       = _taskWeight;
        objSchedule.IPlan_Start_Date   = wdcSchPlanStartDate.Value;
        objSchedule.IPlan_End_Date     = wdcSchPlanEndDate.Value;
        objSchedule.IActual_Start_Date = wdcSchActualStartDate.Value;
        objSchedule.IActual_End_Date   = wdcSchActualEndDate.Value;
        objSchedule.IProceed_Rate      = _proceedRate;
        objSchedule.IAtt_File          = _attFile;
        objSchedule.IComplete_Yn       = "N";
        objSchedule.IIsdelete          = "N";
        objSchedule.IAfter_Task_Ref_Id = -1;
        objSchedule.IDesction          = "";

        if (strGubun == "CHILD")
        {
            objSchedule.INode_Depth = DataTypeUtility.GetToInt32(hdfNodeDepth.Value) + 1;
        }
        else
        {
            objSchedule.INode_Depth = DataTypeUtility.GetToInt32(hdfNodeDepth.Value);
        }

       int intRtn = objSchedule.InsertData(objSchedule.IPrj_Ref_Id
                                , objSchedule.ITask_Ref_Id
                                , objSchedule.ITask_Name
                                , objSchedule.ITask_Type
                                , objSchedule.ITask_Weight
                                , objSchedule.IUp_Task_Ref_Id
                                , objSchedule.ITask_Code
                                , objSchedule.IPlan_Start_Date
                                , objSchedule.IPlan_End_Date
                                , objSchedule.IActual_Start_Date
                                , objSchedule.IActual_End_Date
                                , objSchedule.IProceed_Rate
                                , ""
                                , objSchedule.IComplete_Yn
                                , objSchedule.IIsdelete
                                , objSchedule.INode_Depth
                                , objSchedule.IAfter_Task_Ref_Id
                                , objSchedule.IDesction
                                , gUserInfo.Emp_Ref_ID);
        

        if (objSchedule.Transaction_Result == "Y")
        {
            this.ITaskRefID = objSchedule.ITask_Ref_Id;
        }

        TreeNode cTrn = new TreeNode(_taskName);
        if (strGubun == "CHILD")
        {
            TtrvTask.SelectedNode.ChildNodes.Add(cTrn);
        }
        else
        {
            TtrvTask.SelectedNode.Parent.ChildNodes.Add(cTrn);
        }

        cTrn.Value = objSchedule.ITask_Ref_Id.ToString();

        this.hdfSelectNode.Value = objSchedule.ITask_Ref_Id.ToString();

        this.BindSchedule(this.TtrvTask, false, TreeNodeSelectAction.Select, "");
        
        SelectNodeBind(DataTypeUtility.GetToInt32(hdfSelectNode.Value));
       
    }

    public void FindKeyNode(int iSelectNodeValue)
    {
        TreeNode FindNode = null;

        foreach (TreeNode tn in TtrvTask.Nodes)
        {
            if (tn.Value == iSelectNodeValue.ToString())
            {
                FindNode = tn;
                break;
            }
            else if (tn.ChildNodes.Count > 0)
            {
                FindNode = GetChildNode(tn, iSelectNodeValue, FindNode);
            }
            else 
            {
                if (tn.Value == iSelectNodeValue.ToString())
                    FindNode = tn;
            }
        }

        if (FindNode != null)
        {
            this.BindSchedule(this.TtrvTask, false, TreeNodeSelectAction.Select, "");
            FindNode.Selected = true;
        }
    }
    
    public TreeNode GetChildNode(TreeNode tn, int iSelectNodeValue, TreeNode findNode)
    {
        foreach (TreeNode childtn in tn.ChildNodes)
        {
            if (childtn.Value == iSelectNodeValue.ToString())
            {
                findNode = childtn;
                break;
            }
            else
            {
                if (childtn.ChildNodes.Count > 0)
                {
                    findNode = GetChildNode(childtn, iSelectNodeValue, findNode);
                }
                else
                {
                    if (childtn.Value == iSelectNodeValue.ToString())
                        findNode = childtn;
                }
            }
        }
        return findNode;
    } 

    private void SelectNodeBind(int iSelectNodeValue)
    {
        this.FindKeyNode(iSelectNodeValue);

        this.ITaskRefID = iSelectNodeValue;
        this.hdfTaskRefID.Value = this.ITaskRefID.ToString();
        Biz_Prj_Schedule objSchedule      = new Biz_Prj_Schedule(this.IPrjRefID, this.ITaskRefID);
        Biz_Prj_Schedule objUpSchedule    = new Biz_Prj_Schedule(this.IPrjRefID, objSchedule.IUp_Task_Ref_Id);
        Biz_Prj_Schedule objAfterSchedule = new Biz_Prj_Schedule(this.IPrjRefID, objSchedule.IAfter_Task_Ref_Id);
        Biz_Prj_Task_Owner objTaskOwner   = new Biz_Prj_Task_Owner();
        Biz_Prj_Task_Share objTaskShare   = new Biz_Prj_Task_Share();

        DataSet actualDs = objSchedule.GetActualDate(this.IPrjRefID);


        if (objSchedule.IUp_Task_Ref_Id == 0)
        {
            object oRate = objSchedule.GetTotalRate(this.IPrjRefID, 0);
            double dTotalRate = 0;
            dTotalRate = DataTypeUtility.GetToDouble(oRate);
            txtProceedRate.Text = dTotalRate.ToString("##0.#0");

            wdcSchActualStartDate.Value = actualDs.Tables[0].Rows[0]["ACTUAL_START_DATE"];
            wdcSchActualEndDate.Value = actualDs.Tables[0].Rows[0]["ACTUAL_END_DATE"];
        }
        else
        {
            txtProceedRate.Text = objSchedule.IProceed_Rate.ToString("##0.#0");
            wdcSchActualStartDate.Value = objSchedule.IActual_Start_Date;
            wdcSchActualEndDate.Value = objSchedule.IActual_End_Date;
        }

        txtTaskCode.Text = objSchedule.ITask_Code;
        txtTaskName.Text = objSchedule.ITask_Name;
        hdfUpTaskRefID.Value = objSchedule.IUp_Task_Ref_Id.ToString();
        txtUPTaskName.Text = objUpSchedule.ITask_Name;
        WebUtility.FindByValueDropDownList(ddlTaskType, objSchedule.ITask_Type);
        txtWeight.Text = objSchedule.ITask_Weight.ToString();
        wdcSchPlanStartDate.Value = objSchedule.IPlan_Start_Date;
        wdcSchPlanEndDate.Value = objSchedule.IPlan_End_Date;
       

        //txtProceedRate.Text = objSchedule.IProceed_Rate.ToString("###.#0");
        hdfAttachNo.Value = objSchedule.IAtt_File;
        hdfNodeDepth.Value = objSchedule.INode_Depth.ToString();
        hdfAfterTaskRefID.Value = objSchedule.IAfter_Task_Ref_Id.ToString();
        txtAfterTaskRefName.Text = objAfterSchedule.ITask_Name;
        hdfDesction.Value = objSchedule.IDesction;

        SetUploadFileInfo(hdfAttachNo.Value, ddlFileUpload);

        ugrdTaskOwnerList.Clear();
        ugrdTaskShareList.Clear();

        ugrdTaskOwnerList.DataSource = objTaskOwner.GetAllList(this.IPrjRefID, 0, this.ITaskRefID);
        ugrdTaskOwnerList.DataBind();

        ugrdTaskShareList.DataSource = objTaskShare.GetAllList(this.IPrjRefID, this.ITaskRefID, 0);
        ugrdTaskShareList.DataBind();

        if (this.hdfUpTaskRefID.Value == "0") //프로젝트노드일경우
            SetFristNode(true);
        else
            SetFristNode(false);
    }

    private object GetPrjDate(PrjPeriodDate date)
    {
        object retrunObj = null;
        Biz_Prj_Info objInfo = new Biz_Prj_Info(this.IPrjRefID);

        switch (date)
        {
            case PrjPeriodDate.PLAN_START :
                retrunObj = objInfo.IPlan_Start_Date;
                break;
            case PrjPeriodDate.PLAN_END :
                retrunObj = objInfo.IPlan_End_Date;
                break;
            case PrjPeriodDate.EXEC_START :
                retrunObj = objInfo.IActual_Start_Date;
                break;
            case PrjPeriodDate.EXEC_END :
                retrunObj = objInfo.IActual_End_Date;
                break;
        }
        return retrunObj;
    }

    private void SetFristNode(bool isFrist)
    {
        txtUPTaskName.ReadOnly          = isFrist;
        wdcSchPlanStartDate.ReadOnly    = isFrist;
        wdcSchPlanEndDate.ReadOnly      = isFrist;
        wdcSchActualStartDate.ReadOnly  = isFrist;
        wdcSchActualEndDate.ReadOnly    = isFrist;
        txtProceedRate.ReadOnly         = isFrist;
        txtAfterTaskRefName.ReadOnly    = isFrist;

        Color col = Color.Transparent;

        if (isFrist)
        {
            col = Color.LightGray;

            //프로젝트전체의 설정

            wdcSchPlanStartDate.Value = GetPrjDate(PrjPeriodDate.PLAN_START);
            wdcSchPlanEndDate.Value = GetPrjDate(PrjPeriodDate.PLAN_END);
            //wdcSchActualStartDate.Value = objInfo.IActual_Start_Date;
            //wdcSchActualEndDate.Value = objInfo.IActual_End_Date;
            //txtProceedRate.Text = objInfo.IProceed_Rate.ToString("###.#0");


        }

        wdcSchPlanStartDate.BackColor = col;
        wdcSchPlanEndDate.BackColor = col;
        wdcSchActualStartDate.BackColor = col;
        wdcSchActualEndDate.BackColor = col;
        txtProceedRate.BackColor = col;

        
    }

    protected void ibtnTaskOwnerDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdTaskOwnerList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdTaskOwnerList.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < ugrdTaskOwnerList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdTaskOwnerList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdTaskOwnerList.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdTaskOwnerList.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    ugrdTaskOwnerList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    ugrdTaskOwnerList.Rows[i].Hidden = true;
                    chkCheck.Checked = false;
                }
                else if (striType == "A")
                {
                    ugrdTaskOwnerList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    ugrdTaskOwnerList.Rows[i].Hidden = true;
                    //ugrdTaskOwnerList.Rows.Remove(ugrdRow);
                }
            }
        }
    }
    protected void ibtnTaskShareDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdTaskShareList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdTaskShareList.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < ugrdTaskShareList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdTaskShareList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdTaskShareList.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    ugrdTaskShareList.Rows[i].Hidden = true;
                }
                else if (striType == "A")
                {
                    ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    ugrdTaskShareList.Rows[i].Hidden = true;
                    //ugrdTaskShareList.Rows.Remove(ugrdRow);
                }
            }
        }
    }
    protected void iBtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlFileUpload.SelectedValue.Trim() == "")
        {
            PageUtility.AlertMessage("첨부된 파일을 선택하세요.");
            return;
        }

        string sText = ddlFileUpload.SelectedItem.Text;
        string sValue = ddlFileUpload.SelectedItem.Value;

        PageUtility.FileDownLoad(sText.Substring(0, sText.LastIndexOf(" (")), sValue);
    }
    protected void lBtnTaskShareAddRow_Click(object sender, EventArgs e)
    {
        bool isCheck = false;

        //중복체크
        foreach (UltraGridRow row in ugrdTaskShareList.Rows)
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
        ugrdTaskShareList.Rows.Add();
        cntRow = ugrdTaskShareList.Rows.Count == 0 ? 0 : (ugrdTaskShareList.Rows.Count - 1);

        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("EMP_REF_ID").Value = hdfValue1.Value;
        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = hdfValue2.Value;
        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("DEPT_CODE").Value = hdfValue3.Value;
        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value = hdfValue4.Value;
        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("PRJ_REF_ID").Value = this.IPrjRefID;
        ugrdTaskShareList.Rows[cntRow].Cells.FromKey("TASK_REF_ID").Value = this.ITaskRefID;
    }
    protected void lBtnTaskOwnerAddRow_Click(object sender, EventArgs e)
    {
        bool isCheck = false;

        //중복체크
        foreach (UltraGridRow row in ugrdTaskOwnerList.Rows)
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
        ugrdTaskOwnerList.Rows.Add();
        cntRow = ugrdTaskOwnerList.Rows.Count == 0 ? 0 : (ugrdTaskOwnerList.Rows.Count - 1);

        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("EMP_REF_ID").Value = hdfValue1.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = hdfValue2.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("DEPT_CODE").Value = hdfValue3.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value = hdfValue4.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("PRJ_REF_ID").Value = this.IPrjRefID;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("TASK_REF_ID").Value = this.ITaskRefID;
    }

    protected void lBtnAddRow_Click(object sender, EventArgs e)
    {

    }
    protected void TtrvTask_SelectedNodeChanged(object sender, EventArgs e)
    {
        hdfSelectNode.Value = ((TreeView)(sender)).SelectedValue;
        SelectNodeBind(DataTypeUtility.GetToInt32(hdfSelectNode.Value));
    }
    protected void iBtnAddBrother_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = "";
        this.FindKeyNode(DataTypeUtility.GetToInt32(hdfSelectNode.Value));
        this.AddDeptNode("BROTHER");

        //InitScheduleTabPage();
    }
    protected void iBtnAddChild_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = "";

        this.FindKeyNode(DataTypeUtility.GetToInt32(hdfSelectNode.Value));

        this.AddDeptNode("CHILD");

        //InitScheduleTabPage();
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateViewData();
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteViewData();
    }
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        //ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
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
    

    private void UpdateViewData()
    {


        #region 일정관리 저장
        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        Biz_Prj_Task_Owner objTaskOwner = new Biz_Prj_Task_Owner();
        Biz_Prj_Task_Share objTaskShare = new Biz_Prj_Task_Share();

        objSchedule.IPrj_Ref_Id        = this.IPrjRefID;
        objSchedule.ITask_Ref_Id       = this.ITaskRefID;
        objSchedule.ITask_Code         = txtTaskCode.Text.Trim();
        objSchedule.ITask_Name         = txtTaskName.Text.Trim();
        objSchedule.IUp_Task_Ref_Id    = DataTypeUtility.GetToInt32(hdfUpTaskRefID.Value);
        objSchedule.ITask_Type         = WebUtility.GetByValueDropDownList(ddlTaskType);
        objSchedule.ITask_Weight       = DataTypeUtility.GetToDecimal(txtWeight.Text);
        objSchedule.IPlan_Start_Date   = wdcSchPlanStartDate.Value;
        objSchedule.IPlan_End_Date     = wdcSchPlanEndDate.Value;
        objSchedule.IActual_Start_Date = wdcSchActualStartDate.Value;
        objSchedule.IActual_End_Date   = wdcSchActualEndDate.Value;
        objSchedule.IProceed_Rate      = DataTypeUtility.GetToDecimal(txtProceedRate.Text.Trim());
        objSchedule.IAtt_File          = hdfAttachNo.Value;
        objSchedule.IComplete_Yn       = "N";
        objSchedule.IIsdelete          = "N";
        objSchedule.INode_Depth        = DataTypeUtility.GetToInt32(hdfNodeDepth.Value);
        objSchedule.IAfter_Task_Ref_Id = hdfAfterTaskRefID.Value == ""? -1 : DataTypeUtility.GetToInt32(hdfAfterTaskRefID.Value);
        objSchedule.IDesction          = hdfDesction.Value;

        string[,] saAttachInfo = TypeUtility.GetSplit(hdfAttachNo.Value);

        string strAttach = hdfAttachNo.Value;
        if (saAttachInfo.Length / 2 >= 1)
        {
            if (Convert.ToInt32(saAttachInfo[1, 0]) > 0)
            {
                strAttach = saAttachInfo[0, 0];
            }
        }

        int intRtn = objSchedule.UpdateData(objSchedule.IPrj_Ref_Id
                                , objSchedule.ITask_Ref_Id
                                , objSchedule.ITask_Name
                                , objSchedule.ITask_Type
                                , objSchedule.ITask_Weight
                                , objSchedule.IUp_Task_Ref_Id
                                , objSchedule.ITask_Code
                                , objSchedule.IPlan_Start_Date
                                , objSchedule.IPlan_End_Date
                                , objSchedule.IActual_Start_Date
                                , objSchedule.IActual_End_Date
                                , objSchedule.IProceed_Rate
                                , strAttach
                                , objSchedule.IComplete_Yn
                                , objSchedule.IIsdelete
                                , objSchedule.INode_Depth
                                , objSchedule.IAfter_Task_Ref_Id
                                , objSchedule.IDesction
                                , gUserInfo.Emp_Ref_ID);
      

        //작업수행담당자 저장

        foreach (UltraGridRow row in ugrdTaskOwnerList.Rows)
        {
            objTaskOwner.IPrj_Ref_Id = this.IPrjRefID;
            objTaskOwner.ITask_Ref_Id = this.ITaskRefID;
            objTaskOwner.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objTaskOwner.InsertData(objTaskOwner.IPrj_Ref_Id
                      , objTaskOwner.IEmp_Ref_Id
                      , objTaskOwner.ITask_Ref_Id
                      , "N"
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objTaskOwner.UpdateData(objTaskOwner.IPrj_Ref_Id
                                   , objTaskOwner.IEmp_Ref_Id
                                   , objTaskOwner.ITask_Ref_Id
                                   , "N"
                                   , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objTaskOwner.DeleteData(objTaskOwner.IPrj_Ref_Id
                    , objTaskOwner.IEmp_Ref_Id
                    , objTaskOwner.ITask_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }

        //일정공유자 저장

        foreach (UltraGridRow row in ugrdTaskShareList.Rows)
        {
            objTaskShare.IPrj_Ref_Id = this.IPrjRefID;
            objTaskShare.ITask_Ref_Id = this.ITaskRefID;
            objTaskShare.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objTaskShare.InsertData(objTaskShare.IPrj_Ref_Id
                      , objTaskShare.ITask_Ref_Id
                      , objTaskShare.IEmp_Ref_Id
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objTaskShare.UpdateData(objTaskShare.IPrj_Ref_Id
                                   , objTaskShare.ITask_Ref_Id
                                   , objTaskShare.IEmp_Ref_Id
                                   , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objTaskShare.DeleteData(objTaskShare.IPrj_Ref_Id
                    , objTaskShare.ITask_Ref_Id
                    , objTaskShare.IEmp_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }

        ugrdTaskOwnerList.Clear();
        ugrdTaskShareList.Clear();

        ugrdTaskOwnerList.DataSource = objTaskOwner.GetAllList(this.IPrjRefID, 0, this.ITaskRefID);
        ugrdTaskOwnerList.DataBind();

        ugrdTaskShareList.DataSource = objTaskShare.GetAllList(this.IPrjRefID, this.ITaskRefID, 0);
        ugrdTaskShareList.DataBind();


        #endregion

        if (intRtn > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("일정정보가  저장되었습니다.");
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            TrvSelectNode_Click(null, null);
        }
    }
    private void DeleteViewData()
    {
        #region 일정관리 삭제

        if (hdfUpTaskRefID.Value == "0")
        {
            PageUtility.AlertMessage("최상위 일정은 삭제하실 수 없습니다.");
            return;
        }

        int intRtn = 0;

        this.SubFactory(this.ITaskRefID, ref intRtn);

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        intRtn += objSchedule.DeleteData(this.IPrjRefID, this.ITaskRefID, gUserInfo.Emp_Ref_ID);

        if (intRtn > 0)
        {
            this.IType = "U";
            this.SetFormData();
            InitScheduleTabPage();
        }

        #endregion
    }

    private void SubFactory(int sub_task_id, ref int intRtn)
    {
        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        DataSet ds = objSchedule.GetChildList(this.IPrjRefID, sub_task_id);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.SubFactory(DataTypeUtility.GetToInt32(row["TASK_REF_ID"]), ref intRtn);
            }
        }
        else
        {
            intRtn += objSchedule.DeleteData(this.IPrjRefID, sub_task_id, gUserInfo.Emp_Ref_ID);
        }
    }

    private void InitScheduleTabPage()
    {
        this.ITaskRefID = 0;
        this.hdfTaskRefID.Value = "0";
        txtTaskCode.Text = "";
        txtTaskName.Text = "";
        hdfUpTaskRefID.Value = "";
        txtUPTaskName.Text = "";
        WebUtility.FindByValueDropDownList(ddlTaskType, "");
        txtWeight.Text = "0";
        wdcSchPlanStartDate.Value = null;
        wdcSchPlanEndDate.Value = null;
        wdcSchActualStartDate.Value = null;
        wdcSchActualEndDate.Value = null;
        txtProceedRate.Text = "";
        hdfAttachNo.Value = "";

    }
  
    protected void TrvSelectNode_Click(object sender, EventArgs e)
    {
        SelectNodeBind(DataTypeUtility.GetToInt32(hdfSelectNode.Value));
    }
}
