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

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;

using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common.Biz;

using System.Transactions;
using System.Text.RegularExpressions;
using System.Drawing;

public partial class PRJ_PRJ1102M4 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
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


    public int IEstterm_Ref_ID
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

    public string IEstterm_Ref_ID_Name
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID_NAME"] == null)
            {
                ViewState["ESTTERM_REF_ID_NAME"] = GetRequest("ESTTERM_REF_ID_NAME", "");
            }

            return (string)ViewState["ESTTERM_REF_ID_NAME"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID_NAME"] = value;
        }
    }

    public int IEst_Dept_Ref_ID
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

    public string IEst_Dept_Ref_ID_Name
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID_NAME"] == null)
            {
                ViewState["EST_DEPT_REF_ID_NAME"] = GetRequest("EST_DEPT_REF_ID_NAME", "");
            }

            return (string)ViewState["EST_DEPT_REF_ID_NAME"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID_NAME"] = value;
        }
    }

    public int IWork_Ref_ID
    {
        get
        {
            if (ViewState["WORK_REF_ID"] == null)
            {
                ViewState["WORK_REF_ID"] = GetRequestByInt("WORK_REF_ID", 0);
            }

            return (int)ViewState["WORK_REF_ID"];
        }
        set
        {
            ViewState["WORK_REF_ID"] = value;
        }
    }

    public string IWork_Name
    {
        get
        {
            if (ViewState["WORK_NAME"] == null)
            {
                ViewState["WORK_NAME"] = GetRequest("WORK_NAME", "");
            }

            return (string)ViewState["WORK_NAME"];
        }
        set
        {
            ViewState["WORK_NAME"] = value;
        }
    }

    public int IExec_Ref_ID
    {
        get
        {
            if (ViewState["EXEC_REF_ID"] == null)
            {
                ViewState["EXEC_REF_ID"] = GetRequestByInt("EXEC_REF_ID", 0);
            }

            return (int)ViewState["EXEC_REF_ID"];
        }
        set
        {
            ViewState["EXEC_REF_ID"] = value;
        }
    }

    public string IExec_Name
    {
        get
        {
            if (ViewState["EXEC_NAME"] == null)
            {
                ViewState["EXEC_NAME"] = GetRequest("EXEC_NAME", "");
            }

            return (string)ViewState["EXEC_NAME"];
        }
        set
        {
            ViewState["EXEC_NAME"] = value;
        }
    }

    public int ITask_Ref_ID
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

    public string ITask_Name
    {
        get
        {
            if (ViewState["TASK_NAME"] == null)
            {
                ViewState["TASK_NAME"] = GetRequest("TASK_NAME", "");
            }

            return (string)ViewState["TASK_NAME"];
        }
        set
        {
            ViewState["TASK_NAME"] = value;
        }
    }

    public int IItem_Ref_ID
    {
        get
        {
            if (ViewState["ITEM_REF_ID"] == null)
            {
                ViewState["ITEM_REF_ID"] = GetRequestByInt("ITEM_REF_ID", 0);
            }

            return (int)ViewState["ITEM_REF_ID"];
        }
        set
        {
            ViewState["ITEM_REF_ID"] = value;
        }
    }

    public string IItem_Name
    {
        get
        {
            if (ViewState["ITEM_NAME"] == null)
            {
                ViewState["ITEM_NAME"] = GetRequest("ITEM_NAME", "");
            }

            return (string)ViewState["ITEM_NAME"];
        }
        set
        {
            ViewState["ITEM_NAME"] = value;
        }
    }
    public string IAdd_File
    {
        get
        {
            if (ViewState["ADD_FILE"] == null)
            {
                ViewState["ADD_FILE"] = GetRequest("ADD_FILE", "");
            }

            return (string)ViewState["ADD_FILE"];
        }
        set
        {
            ViewState["ADD_FILE"] = value;
        }
    }
    public string IItem_Ymd
    {
        get
        {
            if (ViewState["ADD_FILE"] == null)
            {
                ViewState["ADD_FILE"] = GetRequest("ADD_FILE", "");
            }

            return (string)ViewState["ADD_FILE"];
        }
        set
        {
            ViewState["ADD_FILE"] = value;
        }
    }


    private string IItem_Desc = "";
    private string IItem_Issue;
    private decimal IApp_Ref_ID;
    private bool IUse_YN;

    //첨부화일 관련  -start
    public int miFilesProcessed = 0;
    private string CS_MAPPATH = "";
    private string CS_EXCELPATH = "";
    private string[] mArgs = new string[3];

    private enum EN_ARGS_INFO : int
    {
        TBLINFO = 0,
        SAVEINFO = 1,
        ATTACHNO = 2
    }

    private int GetArgsInfo(EN_ARGS_INFO eInfo)
    {
        return (int)eInfo;
    }

    //첨부화일관련  -end

    #endregion

    #region ======================= [ Page Load ] ========================
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        if (!Page.IsPostBack)
        {
            this.SetFormData();
            this.SetButton();
        }
    }
    #endregion

    #region ======================== [ Method ] =========================
    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnNew.Visible = false;
            ddlTask.Visible = true;
            txtTaskRefIdName.Visible = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnNew.Visible = true;
            ddlTask.Visible = false;
            txtTaskRefIdName.Visible = true;

            if (!User.IsInRole(ROLE_ADMIN) && EMP_REF_ID != gUserInfo.Emp_Ref_ID)
            {
                iBtnUpdate.Visible = false;
                iBtnNew.Visible = false;
                iBtnTargetFile_Up.Visible = false;
            }

        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnNew.Visible = false;
            ddlTask.Visible = false;
            txtTaskRefIdName.Visible = true;

        }
    }

    private void SetFormData()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Task objCode = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Task();
        objCode.GetTaskList(ddlTask, 0, false, 200,this.IExec_Ref_ID);
 
        if (this.IType != "A")
        {

            MicroBSC.BSC.Biz.Biz_Bsc_Work_Item objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Item(this.IExec_Ref_ID, this.ITask_Ref_ID, this.IItem_Ref_ID);

            IExec_Ref_ID = objBSC.Iexec_ref_id;

            IExec_Name = objBSC.Iexec_ref_id_name;
            txtExecRefIdName.Text = objBSC.Iexec_ref_id_name;

            ITask_Ref_ID = objBSC.Itask_ref_id;
            //PageUtility.FindByValueDropDownList(ddlTask, objBSC.Itask_ref_id);
            txtTaskRefIdName.Text = objBSC.Itask_ref_id_name;
            ITask_Name = objBSC.Itask_ref_id_name;
            
            IItem_Ref_ID = objBSC.Iitem_ref_id;

            IItem_Ymd = objBSC.Iitem_ymd;
            txtItemYMD.Text = objBSC.Iitem_ymd;

            IItem_Name = objBSC.Iitem_name;
            txtItemName.Text = objBSC.Iitem_name;

            txtItemDesc.Value = objBSC.Iitem_desc;

            txtItemUnit.Text = objBSC.Iitem_unit;
            txtItemTgt.Text = objBSC.Iitem_tgt;
            txtItemRst.Text = objBSC.Iitem_rst;

            this.IAdd_File = objBSC.Iadd_file;
            this.hdfTargetReasonFile.Value = objBSC.Iadd_file;
            this.IUse_YN = (objBSC.Iuse_yn == "Y") ? true : false;
            this.chkUseYN.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
            iBtnTargetFile_Down.Visible = (objBSC.Iadd_file == "") ? false : true;
            if (objBSC.Iadd_file == "")
            {

            }
            else
            {
                SearchAddFile();
            }
            if (!chkUseYN.Checked)
            {
                txtItemDesc.Visible = false;
                spnItemDesc.Visible = true;
            }
            else
            {
                txtItemDesc.Visible = true;
                spnItemDesc.Visible = false;
            }


        }
        else
        {

            MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec(this.IEstterm_Ref_ID, this.IExec_Ref_ID);
            txtExecRefIdName.Text = objBSC.Iexec_name;
            IExec_Name = objBSC.Iexec_name;

            if (this.ddlTask.Items.Count > 0) 
            {
                this.ITask_Ref_ID = PageUtility.GetIntByValueDropDownList(ddlTask);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("세부일정 등록 후 사용하세요", false);
                ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);

            }
            this.chkUseYN.Checked = true;
            iBtnTargetFile_Down.Visible = false;
            lbFileList.Items.Clear();
            //ddlKpiCategoryTop_SelectedIndexChanged(null, null);
        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtItemName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("관리항목명을 입력해 주십시오", false);
                return false;
            }
            else if (this.ITask_Ref_ID == 0)
            {
                ltrScript.Text = JSHelper.GetAlertScript("세부일정을 선해 주십시요", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (this.IItem_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("관리항목을 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (this.IItem_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("관리항목을 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertWorkItem()
    {
        if (!this.CheckFormData()) { return; }
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Item objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Item();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itask_ref_id = this.ITask_Ref_ID;

        objBSC.Iitem_name = txtItemName.Text.Trim();
        objBSC.Iitem_ymd = txtItemYMD.Text.Trim();
        objBSC.Iitem_desc = txtItemDesc.Value;
        objBSC.Iitem_unit = txtItemUnit.Text.Trim();
        objBSC.Iitem_tgt = txtItemTgt.Text.Trim();
        objBSC.Iitem_rst = txtItemRst.Text.Trim();

        objBSC.Iadd_file = this.hdfTargetReasonFile.Value;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.InsertData(objBSC.Iexec_ref_id,
                                      objBSC.Itask_ref_id,
                                      objBSC.Iitem_ref_id,
                                      objBSC.Iitem_ymd,
                                      objBSC.Iitem_name,
                                      objBSC.Iitem_desc,
                                      objBSC.Iitem_unit,
                                      objBSC.Iitem_tgt,
                                      objBSC.Iitem_rst,
                                      objBSC.Iadd_file,
                                      objBSC.Iuse_yn,
                                      objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IExec_Ref_ID = objBSC.Iexec_ref_id;
            this.ITask_Ref_ID = objBSC.Itask_ref_id;
            this.IItem_Ref_ID = objBSC.Iitem_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UpdateWorkItem()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Work_Item objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Item();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itask_ref_id = this.ITask_Ref_ID;
        objBSC.Iitem_ref_id = this.IItem_Ref_ID;

        objBSC.Iitem_name = txtItemName.Text.Trim();
        objBSC.Iitem_ymd = txtItemYMD.Text.Trim();
        objBSC.Iitem_desc = txtItemDesc.Value;
        objBSC.Iitem_unit = txtItemUnit.Text.Trim();
        objBSC.Iitem_tgt = txtItemTgt.Text.Trim();
        objBSC.Iitem_rst = txtItemRst.Text.Trim();

        objBSC.Iadd_file = this.IAdd_File;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UpdateData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
                                       objBSC.Iitem_ref_id,
                                       objBSC.Iitem_ymd,
                                       objBSC.Iitem_name,
                                       objBSC.Iitem_desc,
                                       objBSC.Iitem_unit,
                                       objBSC.Iitem_tgt,
                                       objBSC.Iitem_rst,
                                       objBSC.Iadd_file,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
    }

    private void ReUsedWorkItem()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Item objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Item();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itask_ref_id = this.ITask_Ref_ID;
        objBSC.Iitem_ref_id = this.IItem_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReUsedData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
                                       objBSC.Iitem_ref_id,
                                       objBSC.Itxr_user);

        if (objBSC.Transaction_Result == "Y")
        {
            //            this.TxrWorkPoolQuestion();
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            this.IType = "U";
        }
    }

    private void DeleteWorkItem()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Item objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Item();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itask_ref_id = this.ITask_Ref_ID;
        objBSC.Iitem_ref_id = this.IItem_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.DeleteData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
                                       objBSC.Iitem_ref_id,
                                       objBSC.Itxr_user);

        if (objBSC.Transaction_Result == "Y")
        {
            //            this.TxrWorkPoolQuestion();
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            this.IType = "U";
        }
    }
    #endregion

    #region ======================== [ Server Event ] =========================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertWorkItem();
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteWorkItem();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedWorkItem();
    }


    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateWorkItem();
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    #endregion

    protected void iBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        this.IItem_Name = "";
        this.txtItemName.Text = "";
        this.txtItemDesc.Value = "";
        this.IAdd_File = "";
        this.hdfTargetReasonFile.Value = "";
        this.lbFileList.Items.Clear();

        this.SetFormData();
        this.SetButton();

    }
    private void SearchAddFile()
    {
        // dialogArguments가 있는지 체크한다.
        mArgs = hdfTargetReasonFile.Value.ToString().Split(';');

        if (mArgs.Length >= 1)
        {
            // 엑셀파일 저장인지 확인한다.
            if (mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)] == "EXCEL")
            {
                return;
            }
        }

        if (mArgs.Length < 3)
        {
            return;
        }

        Biz_Base_FileUpload bizCom = new Biz_Base_FileUpload();
        DataSet lDS = bizCom.GetFileUploaded(mArgs[GetArgsInfo(EN_ARGS_INFO.TBLINFO)]);

        DataTable lDT = lDS.Tables[0];

        lbFileList.Items.Clear();

        for (int i = 0; i < lDT.Rows.Count; i++)
        {
            lbFileList.Items.Add(new ListItem(lDT.Rows[i]["v_FileText"].ToString(), lDT.Rows[i]["v_FileValue"].ToString()));
        }
    }

    protected void btnAddFileSearch_Click(object sender, EventArgs e)
    {
        IAdd_File = hdfTargetReasonFile.Value;
        SearchAddFile();
    }

    protected void ddlTask_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ITask_Ref_ID = PageUtility.GetIntByValueDropDownList(ddlTask);
    }
    protected void chkUseYN_CheckedChanged(object sender, EventArgs e)
    {


        if (!chkUseYN.Checked)
        {
            txtItemDesc.Visible = false;
            spnItemDesc.Visible = true;
            iBtnTargetFile_Up.Visible = false;
        }
        else
        {
            txtItemDesc.Visible = true;
            spnItemDesc.Visible = false;
            iBtnTargetFile_Up.Visible = true;
        }

    }
}
