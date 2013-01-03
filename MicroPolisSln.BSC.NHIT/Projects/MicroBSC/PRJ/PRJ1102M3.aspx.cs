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

public partial class PRJ_PRJ1102M3 : AppPageBase
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


    private string IExec_Desc = "";
    private string IExec_Issue;
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
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnNew.Visible = true;
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

        }
    }

    private void SetFormData()
    {

        if (this.IType != "A")
        {
            txtCostRate.Text = "0";
            MicroBSC.BSC.Biz.Biz_Bsc_Work_Task objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Task(this.IExec_Ref_ID, this.ITask_Ref_ID);

            IExec_Ref_ID = objBSC.Iexec_ref_id;
            txtExecRefIdName.Text = objBSC.Iexec_ref_id_name;

            ITask_Ref_ID = objBSC.Itask_ref_id;
            txtTaskName.Text = objBSC.Itask_name;

            txtTaskDesc.Value = objBSC.Itask_desc;
            spnTaskDesc.InnerHtml = objBSC.Itask_desc;

            txtTaskWeight.Text = Convert.ToString(objBSC.Itask_weight);

            calTgtStrDate.Value = (Convert.ToString(objBSC.Itgt_str_date) == "1900-01-01 오전 12:00:00") ? "" : Convert.ToString(objBSC.Itgt_str_date);
            calTgtEndDate.Value = (Convert.ToString(objBSC.Itgt_end_date) == "1900-01-01 오전 12:00:00") ? "" : Convert.ToString(objBSC.Itgt_end_date);
            txtTgtCost.Text = Convert.ToString(objBSC.Itgt_cost);

            calRstStrDate.Value = (Convert.ToString(objBSC.Irst_str_date) == "1900-01-01 오전 12:00:00") ? "" : Convert.ToString(objBSC.Irst_str_date);
            calRstEndDate.Value = (Convert.ToString(objBSC.Irst_end_date) == "1900-01-01 오전 12:00:00") ? "" : Convert.ToString(objBSC.Irst_end_date);
            txtRstCost.Text = Convert.ToString(objBSC.Irst_cost);
            
            if (objBSC.Itgt_cost != 0 && objBSC.Irst_cost != 0 )
            {
                txtCostRate.Text =  string.Format("{0:F2}", (Convert.ToDouble(objBSC.Irst_cost) / Convert.ToDouble(objBSC.Itgt_cost) * 100));
            }
            else
            {
                txtCostRate.Text = "0";
            }
            txtDoRate.Text = Convert.ToString(objBSC.Ido_rate);
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
                txtTaskDesc.Visible = false;
                spnTaskDesc.Visible = true;
                iBtnTargetFile_Up.Visible = false;
            }
            else
            {
                txtTaskDesc.Visible = true;
                spnTaskDesc.Visible = false;
                iBtnTargetFile_Up.Visible = true;
            }


        }
        else
        {
            //ltrScript.Text = JSHelper.GetAlertScript("this.IEstterm_Ref_ID=" + Convert.ToString(this.IEstterm_Ref_ID) + "  this.IEst_Dept_Ref_ID=" + Convert.ToString(this.IEst_Dept_Ref_ID) + "  this.IWork_Ref_ID=" + Convert.ToString(this.IWork_Ref_ID) + "  this.IExec_Ref_ID=" + Convert.ToString(this.IExec_Ref_ID), false);

            MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec(this.IEstterm_Ref_ID, this.IEst_Dept_Ref_ID, this.IWork_Ref_ID,this.IExec_Ref_ID );
            txtExecRefIdName.Text = objBSC.Iexec_name;
            txtTaskWeight.Value = "0";
            calTgtStrDate.Value = System.DateTime.Now;
            calTgtEndDate.Value = System.DateTime.Now;
            calRstStrDate.Value = "";
            calRstEndDate.Value = "";
            txtCostRate.Text = "0";
            txtDoRate.Value = "0";
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
            if (txtTaskName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("세부일정명을 입력해 주십시오", false);
                return false;
            }
            else
            {
                if (txtTaskWeight.Text.Trim() == "")
                {
                    ltrScript.Text = JSHelper.GetAlertScript("가중치를 입력해 주십시오", false);
                    return false;
                }
                else
                {
                    decimal  number1 = 0;
                    bool result = Decimal.TryParse( txtTaskWeight.Text  , out number1);
                    if (result == false)
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("가중치는 숫자만 가능합니다.", false);
                        return false;
                    }
                    else
                    {
                        if (calTgtStrDate.Value == null)
                        {
                            ltrScript.Text = JSHelper.GetAlertScript("목표 시작일자를 입력해 주십시오", false);
                            return false;
                        }
                        else
                        {
                            if (calTgtEndDate.Value == null)
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("목표 마감일자를 입력해 주십시오", false);
                                return false;
                            }
                            else
                            {
                                if (txtTaskWeight.Text == "")
                                {
                                    ltrScript.Text = JSHelper.GetAlertScript("세부일정 가중치 입력해 주십시오", false);
                                    return false;
                                }
                                else
                                {
                                    if (Convert.ToInt32(txtDoRate.Text) >= 100)
                                    {
                                        txtDoRate.Text = "100";
                                        return true;                                  
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(txtDoRate.Text) <= 0)
                                        {
                                            txtDoRate.Text = "0";
                                            return true;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (this.IType == "U")
        {
            if (this.ITask_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("세부일정을 선택해 주십시오", false);
                return false;
            }
            else
            {
                if (txtTaskName.Text.Trim() == "")
                {
                    ltrScript.Text = JSHelper.GetAlertScript("세부일정명을 입력해 주십시오", false);
                    return false;
                }
                else
                {
                    if (txtTaskWeight.Text.Trim() == "")
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("가중치를 입력해 주십시오", false);
                        return false;
                    }
                    else
                    {
                        decimal  number1 = 0;
                        bool result = Decimal.TryParse( txtTaskWeight.Text  , out number1);
                        if (result == false)
                        {
                            ltrScript.Text = JSHelper.GetAlertScript("가중치는 숫자만 가능합니다.", false);
                            return false;
                        }
                        else
                        {
                            if (calTgtStrDate.Value == null)
                            {
                                ltrScript.Text = JSHelper.GetAlertScript("목표 시작일자를 입력해 주십시오", false);
                                return false;
                            }
                            else
                            {
                                if (calTgtEndDate.Value == null)
                                {
                                    ltrScript.Text = JSHelper.GetAlertScript("목표 마감일자를 입력해 주십시오", false);
                                    return false;
                                }
                                else
                                {
                                    if (txtTaskWeight.Text == "")
                                    {
                                        ltrScript.Text = JSHelper.GetAlertScript("세부일정 가중치 입력해 주십시오", false);
                                        return false;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(txtDoRate.Text) >= 100)
                                        {
                                            txtDoRate.Text = "100";
                                            return true;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(txtDoRate.Text) <= 0)
                                            {
                                                txtDoRate.Text = "0";
                                                return true;
                                            }
                                            else
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (this.IType == "D")
        {
            if (this.ITask_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("세부일정을 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertWorkTask()
    {
        if (!this.CheckFormData()) { return; }
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Task objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Task();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;

        objBSC.Itask_name = txtTaskName.Text.Trim();
        objBSC.Itask_desc = txtTaskDesc.Value;
        objBSC.Itask_weight = Convert.ToDecimal( GetStringDigit(this.txtTaskWeight.Text, "###0.0"));

        DateTime mydt1 = new DateTime(1900, 1, 1, 0, 0, 0);
        objBSC.Itgt_str_date = (calTgtStrDate.Value == null || calTgtStrDate.Value == "") ? mydt1 : Convert.ToDateTime(calTgtStrDate.Value);
        objBSC.Itgt_end_date = (calTgtEndDate.Value == null || calTgtEndDate.Value == "") ? mydt1 : Convert.ToDateTime(calTgtEndDate.Value);
        objBSC.Itgt_cost = Convert.ToInt32(GetStringDigit(this.txtTgtCost.Text, "###0"));

        objBSC.Irst_str_date = (calRstStrDate.Value == null || calRstStrDate.Value == "") ? mydt1 : Convert.ToDateTime(calRstStrDate.Value);
        objBSC.Irst_end_date = (calRstEndDate.Value == null || calRstEndDate.Value == "") ? mydt1 : Convert.ToDateTime(calRstEndDate.Value);
        objBSC.Irst_cost = Convert.ToInt32(GetStringDigit(this.txtRstCost.Text, "###0"));
        
        objBSC.Ido_rate = Convert.ToDecimal(GetStringDigit(this.txtDoRate.Text,"###0.0"));
        
        objBSC.Iadd_file = this.hdfTargetReasonFile.Value;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

         int intRtn = objBSC.InsertData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
                                       objBSC.Itask_name,
                                       objBSC.Itask_desc,
                                       objBSC.Itask_weight,
                                       objBSC.Itgt_str_date,
                                       objBSC.Itgt_end_date,
                                       objBSC.Itgt_cost,
                                       objBSC.Irst_str_date,
                                       objBSC.Irst_end_date,
                                       objBSC.Irst_cost,
                                       objBSC.Ido_rate,
                                       objBSC.Iadd_file,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IExec_Ref_ID = objBSC.Iexec_ref_id;
            this.ITask_Ref_ID = objBSC.Itask_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UpdateWorkTask()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Work_Task objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Task();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;

        objBSC.Itask_ref_id = this.ITask_Ref_ID;

        objBSC.Itask_name = txtTaskName.Text.Trim();
        objBSC.Itask_desc = txtTaskDesc.Value;
        objBSC.Itask_weight = Convert.ToDecimal(GetStringDigit(this.txtTaskWeight.Text, "###0.0"));

        DateTime mydt1 = new DateTime(1900, 1, 1, 0, 0, 0);
        objBSC.Itgt_str_date = (calTgtStrDate.Value == null || calTgtStrDate.Value == "") ? mydt1 : Convert.ToDateTime(calTgtStrDate.Value);
        objBSC.Itgt_end_date = (calTgtEndDate.Value == null || calTgtEndDate.Value == "") ? mydt1 : Convert.ToDateTime(calTgtEndDate.Value);
        objBSC.Itgt_cost = Convert.ToInt32(GetStringDigit(this.txtTgtCost.Text, "###0"));

        objBSC.Irst_str_date = (calRstStrDate.Value == null || calRstStrDate.Value == "") ? mydt1 : Convert.ToDateTime(calRstStrDate.Value);
        objBSC.Irst_end_date = (calRstEndDate.Value == null || calRstEndDate.Value == "") ? mydt1 : Convert.ToDateTime(calRstEndDate.Value);
        objBSC.Irst_cost = Convert.ToInt32(GetStringDigit(this.txtRstCost.Text, "###0"));

        objBSC.Ido_rate = Convert.ToDecimal(GetStringDigit(this.txtDoRate.Text, "###0.0"));

        objBSC.Iadd_file = this.IAdd_File;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UpdateData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
                                       objBSC.Itask_name,
                                       objBSC.Itask_desc,
                                       objBSC.Itask_weight,
                                       objBSC.Itgt_str_date,
                                       objBSC.Itgt_end_date,
                                       objBSC.Itgt_cost,
                                       objBSC.Irst_str_date,
                                       objBSC.Irst_end_date,
                                       objBSC.Irst_cost,
                                       objBSC.Ido_rate,
                                       objBSC.Iadd_file,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        this.SetFormData();
        this.SetButton();

    }

    private void ReUsedWorkTask()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Task objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Task();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itask_ref_id = this.ITask_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReUsedData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
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

    private void DeleteWorkTask()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Task objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Task();
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itask_ref_id = this.ITask_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.DeleteData(objBSC.Iexec_ref_id,
                                       objBSC.Itask_ref_id,
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
        this.InsertWorkTask();
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteWorkTask();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedWorkTask();
    }


    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateWorkTask();
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
        this.IExec_Name = "";
        this.txtTaskName.Text = "";
        this.txtTaskDesc.Value = "";
        this.lbFileList.Items.Clear();
        this.IAdd_File = "";
        this.hdfTargetReasonFile.Value = "";

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

    protected void calTgtEndDate_ValueChanged(object sender, Infragistics.WebUI.WebSchedule.WebDateChooser.WebDateChooserEventArgs e)
    {
        if (calTgtStrDate.Value == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("목표시작일을 확인하세요", false);
            calTgtEndDate.Value = calTgtStrDate.Value;
            calTgtStrDate.Focus();
        }
        if (Convert.ToDateTime(calTgtStrDate.Value) > Convert.ToDateTime(calTgtEndDate.Value))
        {
            ltrScript.Text = JSHelper.GetAlertScript("목표마감일을 확인하세요", false);
            calTgtEndDate.Value = calTgtStrDate.Value;
            
            calTgtEndDate.Focus();
        }
    }

    protected void calRstEndDate_ValueChanged(object sender, Infragistics.WebUI.WebSchedule.WebDateChooser.WebDateChooserEventArgs e)
    {
        if (calRstStrDate.Value == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("실적시작일을 확인하세요", false);
            calRstEndDate.Value = calRstStrDate.Value;

            calRstStrDate.Focus();
            return;
        }
        if (Convert.ToDateTime(calRstStrDate.Value) > Convert.ToDateTime(calRstEndDate.Value))
        {
            ltrScript.Text = JSHelper.GetAlertScript("실적마감일을 확인하세요", false);
            calRstEndDate.Value = calRstStrDate.Value;

            calRstEndDate.Focus();
            return;
        }

    }
    protected void chkUseYN_CheckedChanged(object sender, EventArgs e)
    {


        if (!chkUseYN.Checked)
        {
            txtTaskDesc.Visible = false;
            spnTaskDesc.Visible = true;
            iBtnTargetFile_Up.Visible = false;
        }
        else
        {
            txtTaskDesc.Visible = true;
            spnTaskDesc.Visible = false;
            iBtnTargetFile_Up.Visible = true;
        }

    }
}
