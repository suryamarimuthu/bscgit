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
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;

using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.BSC.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common.Biz;

using System.Transactions;
using System.Text.RegularExpressions;


using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class PRJ_PRJ1102M5 : AppPageBase
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

    public string ICCB4
    {
        get
        {
            if (ViewState["CCB4"] == null)
            {
                ViewState["CCB4"] = GetRequest("CCB4", this.iBtnWorkTaskRefresh.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB4"];
        }
        set
        {
            ViewState["CCB4"] = value;
        }
    }

    public string ICCB5
    {
        get
        {
            if (ViewState["CCB5"] == null)
            {
                ViewState["CCB5"] = GetRequest("CCB5", this.iBtnWorkItemRefresh.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB5"];
        }
        set
        {
            ViewState["CCB5"] = value;
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

    public string IExec_Code
    {
        get
        {
            if (ViewState["EXEC_CODE"] == null)
            {
                ViewState["EXEC_CODE"] = GetRequest("EXEC_CODE", "");
            }

            return (string)ViewState["EXEC_CODE"];
        }
        set
        {
            ViewState["EXEC_CODE"] = value;
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

    public int IExec_Emp_ID
    {
        get
        {
            if (ViewState["EXEC_EMP_ID"] == null)
            {
                ViewState["EXEC_EMP_ID"] = GetRequestByInt("EXEC_EMP_ID", 0);
            }

            return (int)ViewState["EXEC_EMP_ID"];
        }
        set
        {
            ViewState["EXEC_EMP_ID"] = value;
        }
    }

    public string IExec_Emp_Id_Name
    {
        get
        {
            if (ViewState["EXEC_EMP_ID_NAME"] == null)
            {
                ViewState["EXEC_EMP_ID_NAME"] = GetRequest("EXEC_EMP_ID_NAME", "");
            }

            return (string)ViewState["EXEC_EMP_ID_NAME"];
        }
        set
        {
            ViewState["EXEC_EMP_ID_NAME"] = value;
        }
    }

    public int IExec_Emp_Dept_ID
    {
        get
        {
            if (ViewState["EXEC_EMP_DEPT_ID"] == null)
            {
                ViewState["EXEC_EMP_DEPT_ID"] = GetRequestByInt("EXEC_EMP_DEPT_ID", 0);
            }

            return (int)ViewState["EXEC_EMP_DEPT_ID"];
        }
        set
        {
            ViewState["EXEC_EMP_DEPT_ID"] = value;
        }
    }

    public string IExec_Emp_Dept_Id_Name
    {
        get
        {
            if (ViewState["EXEC_EMP_DEPT_ID_NAME"] == null)
            {
                ViewState["EXEC_EMP_DEPT_ID_NAME"] = GetRequest("EXEC_EMP_DEPT_ID_NAME", "");
            }

            return (string)ViewState["EXEC_EMP_DEPT_ID_NAME"];
        }
        set
        {
            ViewState["EXEC_EMP_DEPT_ID_NAME"] = value;
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

    public string IUse_YN
    {
        get
        {
            if (ViewState["USE_YN"] == null)
            {
                ViewState["USE_YN"] = GetRequest("USE_YN", "");
            }

            return (string)ViewState["USE_YN"];
        }
        set
        {
            ViewState["USE_YN"] = value;
        }
    }
    public string IComplete_YN
    {
        get
        {
            if (ViewState["COMPLETE_YN"] == null)
            {
                ViewState["COMPLETE_YN"] = GetRequest("COMPLETE_YN", "");
            }

            return (string)ViewState["COMPLETE_YN"];
        }
        set
        {
            ViewState["COMPLETE_YN"] = value;
        }
    }

    private string IExec_Desc = "";
    private string IExec_Issue;
    private decimal IApp_Ref_ID;


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
            imgExecCodeSearch.Visible = true;
            pnlExecCode.Enabled = true;
            pnlWorkTaskList.Visible = false;
            pnlWorkItemList.Visible = false;
            pnlWorkTaskNotice.Visible = true;
            pnlWorkItemNotice.Visible = true;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnNew.Visible = true;
            imgExecCodeSearch.Visible = false;
            pnlExecCode.Enabled = false;
            pnlWorkTaskList.Visible = true;
            pnlWorkItemList.Visible = true;
            pnlWorkTaskNotice.Visible = false;
            pnlWorkItemNotice.Visible = false;

            if (!User.IsInRole(ROLE_ADMIN) && EMP_REF_ID.ToString() != hdfExecEmpId.Value)
            {
                iBtnUpdate.Visible = false;
                iBtnNew.Visible = false;
                Img1.Visible = false;
                iBtnWorkTaskInsert.Visible = false;
                iBtnWorkItemInsert.Visible = false;
                iBtnTargetFile_Up.Visible = false;
            }

            if (!this.chkUseYN.Checked)
            {
                Img1.Visible = false;
                pnlWorkTaskList.Enabled = false;

                pnlWorkItemList.Enabled = false;
                iBtnTargetFile_Up.Visible = false;
                this.chkCompleteYN.Enabled = false;
            }

            if (this.chkCompleteYN.Checked)
            {
                this.chkCompleteYN.Enabled = false;
                this.iBtnUpdate.Visible = false;
                this.iBtnUndo.Visible = true;
            }
            else
            {
                this.chkCompleteYN.Enabled = true;
                this.iBtnUpdate.Visible = true;
                this.iBtnUndo.Visible = false;
            }
          
        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnNew.Visible = false;
            imgExecCodeSearch.Visible = false;
            pnlExecCode.Enabled = false;
            pnlWorkTaskList.Visible = false;
            pnlWorkItemList.Visible = false;
            pnlWorkTaskNotice.Visible = false;
            pnlWorkItemNotice.Visible = false;

        }

    }

    private void SetFormData()
    {

        if (this.IType != "A")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec(this.IEstterm_Ref_ID, this.IEst_Dept_Ref_ID, this.IWork_Ref_ID, this.IExec_Ref_ID );

            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;

            this.IEstterm_Ref_ID_Name = objBSC.Iestterm_ref_id_name;
            txtEstTermRefIdName.Text  = objBSC.Iestterm_ref_id_name;

            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;

            this.IEst_Dept_Ref_ID_Name = objBSC.Iest_dept_ref_id_name;
            txtEstDeptRefIdName.Text = objBSC.Iest_dept_ref_id_name;

            this.IWork_Ref_ID = objBSC.Iwork_ref_id;
         

            txtWorkRefIdName.Text = objBSC.Iwork_ref_id_name;
            this.IWork_Name = objBSC.Iwork_ref_id_name;
            txtWorkCode.Text = objBSC.Iwork_code;

            IExec_Ref_ID = objBSC.Iexec_ref_id;
            hdfExecRefID.Value = Convert.ToString( objBSC.Iexec_ref_id);

            this.IExec_Code = objBSC.Iexec_code;
            txtExecCode.Text = objBSC.Iexec_code;

            txtExecName.Text = objBSC.Iexec_name;
            txtExecDesc.Text = objBSC.Iexec_desc;

            this.IExec_Emp_Dept_ID = objBSC.Iexec_emp_id_dept_id;
            hdfExecEmpDeptId.Value = Convert.ToString(objBSC.Iexec_emp_id_dept_id);

            this.IExec_Emp_Dept_Id_Name = objBSC.Iexec_emp_id_dept_id_name;
            txtExecEmpDeptIdName.Text = objBSC.Iexec_emp_id_dept_id_name;

            this.IExec_Emp_ID = objBSC.Iexec_emp_id;
            hdfExecEmpId.Value = Convert.ToString(objBSC.Iexec_emp_id);

            this.IExec_Emp_Id_Name = objBSC.Iexec_emp_id_name;
            txtExecEmpIdName.Text = objBSC.Iexec_emp_id_name;

            txtExecIssue.Text = objBSC.Iexec_issue;
            this.IAdd_File = objBSC.Iadd_file;
            this.hdfTargetReasonFile.Value = objBSC.Iadd_file;

            this.IApp_Ref_ID = objBSC.Iapp_ref_id;
            this.IUse_YN = objBSC.Iuse_yn;
            this.chkUseYN.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
            this.IComplete_YN = objBSC.Icomplete_yn;
            this.chkCompleteYN.Checked = (objBSC.Icomplete_yn == "Y") ? true : false;
            iBtnTargetFile_Down.Visible = (objBSC.Iadd_file == "") ? false : true;
            if (objBSC.Iadd_file == "")
            {

            }
            else
            {
                SearchAddFile();
            }
            setWorkTaskList(this.IExec_Ref_ID );
            setWorkItemList(this.IExec_Ref_ID );

            if (this.chkCompleteYN.Checked == true)
            {
                this.ugrdWorkTaskList.DisplayLayout.ReadOnly = ReadOnly.LevelZero;
                this.ugrdWorkItemList.DisplayLayout.ReadOnly = ReadOnly.LevelZero;
            }
            else
            {
                this.ugrdWorkTaskList.DisplayLayout.ReadOnly = ReadOnly.NotSet ;
                this.ugrdWorkItemList.DisplayLayout.ReadOnly = ReadOnly.NotSet;

            }
        }
        else
        {
            MicroBSC.Estimation.Dac.TermInfos objTERM = new MicroBSC.Estimation.Dac.TermInfos(this.IEstterm_Ref_ID);
            txtEstTermRefIdName.Text = Convert.ToString(objTERM.Estterm_name);
            MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo objDEPT = new MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo(this.IEst_Dept_Ref_ID);
            txtEstDeptRefIdName.Text = Convert.ToString(objDEPT.Idept_name);
            MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info(this.IEstterm_Ref_ID,this.IEst_Dept_Ref_ID,this.IWork_Ref_ID );
            txtWorkCode.Text = objBSC.Iwork_code ;
           
            txtWorkRefIdName.Text = objBSC.Iwork_name;
            txtWorkEmp.Text = objBSC.Iwork_emp_id_name;
            this.chkUseYN.Checked = true;
            this.chkCompleteYN.Checked = false;
            iBtnTargetFile_Down.Visible = false;
            lbFileList.Items.Clear();

            setWorkTaskList(0);
            setWorkItemList(0);
            

            //ddlKpiCategoryTop_SelectedIndexChanged(null, null);
        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtExecCode.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("실행과제 코드를 입력해 주십시오", false);
                return false;
            }
            else
            {
                if (txtExecName.Text.Trim() == "")
                {
                    ltrScript.Text = JSHelper.GetAlertScript("실행과제명을 입력해 주십시오", false);
                    return false;
                }
                else
                {
                    if (hdfchkExecCode.Value == "")
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("실행과제코드를 중복확인 하세요", false);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        else if (this.IType == "U")
        {
            if (this.IExec_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("실행과제를 선택해 주십시오", false);
                return false;
            }
            else if (txtExecName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("실행과제명을 입력해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (this.IExec_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("실행과제를 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertWorkExec()
    {
        if (!this.CheckFormData()) { return; }
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;

        objBSC.Iexec_code = txtExecCode.Text.Trim();
        objBSC.Iexec_name = txtExecName.Text.Trim();
        objBSC.Iexec_desc = txtExecDesc.Text.Trim();
        objBSC.Iexec_emp_id = Convert.ToInt32((this.hdfExecEmpId.Value == "") ? "0" : this.hdfExecEmpId.Value);
        objBSC.Iexec_issue = txtExecIssue.Text;
        objBSC.Iadd_file = this.hdfTargetReasonFile.Value;
        objBSC.Iapp_ref_id = this.IApp_Ref_ID;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Icomplete_yn = (this.chkCompleteYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.InsertData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iexec_ref_id,
                                       objBSC.Iexec_code,
                                       objBSC.Iexec_name,
                                       objBSC.Iexec_desc,
                                       objBSC.Iexec_emp_id,
                                       objBSC.Iexec_issue,
                                       objBSC.Iadd_file,
                                       objBSC.Iapp_ref_id,
                                       objBSC.Iuse_yn,
                                       objBSC.Icomplete_yn ,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;
            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;
            this.IWork_Ref_ID = objBSC.Iwork_ref_id;
            this.IExec_Ref_ID = objBSC.Iexec_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UpdateWorkExec()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Iexec_ref_id = Convert.ToInt32(this.IExec_Ref_ID);
        objBSC.Iexec_code = txtExecCode.Text.Trim();
        objBSC.Iexec_name = txtExecName.Text.Trim();
        objBSC.Iexec_desc = txtExecDesc.Text.Trim();
        objBSC.Iexec_emp_id = Convert.ToInt32((this.hdfExecEmpId.Value == "") ? "0" : this.hdfExecEmpId.Value);
        objBSC.Iexec_issue = txtExecIssue.Text;
        objBSC.Iadd_file = this.IAdd_File;
        objBSC.Iapp_ref_id = this.IApp_Ref_ID;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Icomplete_yn = (this.chkCompleteYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UpdateData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iexec_ref_id,
                                       objBSC.Iexec_code,
                                       objBSC.Iexec_name,
                                       objBSC.Iexec_desc,
                                       objBSC.Iexec_emp_id,
                                       objBSC.Iexec_issue,
                                       objBSC.Iadd_file,
                                       objBSC.Iapp_ref_id,
                                       objBSC.Iuse_yn,
                                       objBSC.Icomplete_yn,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;
            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;
            this.IWork_Ref_ID = objBSC.Iwork_ref_id;
            this.IExec_Ref_ID = objBSC.Iexec_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void ReUsedWorkExec()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReUsedData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iexec_ref_id,
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
            this.SetFormData();
            this.SetButton();

        }
    }


    private void ReCompleteWorkExec()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RC";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReCompleteData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iexec_ref_id,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;
            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;
            this.IWork_Ref_ID = objBSC.Iwork_ref_id;
            this.IExec_Ref_ID = objBSC.Iexec_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void DeleteWorkExec()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Iexec_ref_id = this.IExec_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.DeleteData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iexec_ref_id,
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
    
    private void setWorkTaskList(int iExecRefID)
    {
        Biz_Bsc_Work_Task objWorkTask = new Biz_Bsc_Work_Task();
        DataSet rDs = objWorkTask.GetAllList(iExecRefID);

        ugrdWorkTaskList.Clear();
        ugrdWorkTaskList.DataSource = rDs;
        ugrdWorkTaskList.DataBind();
        getToWeight();
    }
    
    private void setWorkItemList(int iExecRefID)
    {
        Biz_Bsc_Work_Item objWorkItem = new Biz_Bsc_Work_Item();
        DataSet rDs = objWorkItem.GetAllList(iExecRefID);

        ugrdWorkItemList.Clear();
        ugrdWorkItemList.DataSource = rDs;
        ugrdWorkItemList.DataBind();
    }

    private void getToWeight()
    {
        int intRow = ugrdWorkTaskList.Rows.Count;
        double var1 = 0;
        if (intRow > 0)
        {
            for (int i = 0; i < intRow; i++)
            {
                var1 += double.Parse(ugrdWorkTaskList.Rows[i].Cells.FromKey("TASK_WEIGHT").Value.ToString());
            }
            lblToWeight.Text = string.Format("{0:F2}", var1);
        }
    }
    #endregion

    #region ======================== [ Server Event ] =========================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertWorkExec();
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteWorkExec();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedWorkExec();
    }


    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateWorkExec();
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    #endregion

    protected void imgExecCodeSearch_Click(object sender, ImageClickEventArgs e)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec(this.IEstterm_Ref_ID, this.txtExecCode.Text);

        if (objBSC.Iexec_code == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("중복확인 완료. 사용가능합니다.", false);
            hdfchkExecCode.Value = "*";
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("코드가 중복되었습니다. 다른 코드를 사용하세요", false);
            hdfchkExecCode.Value = "";

            txtExecCode.Text = "";
            txtExecCode.Focus();
        }
    }


    protected void iBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        this.IWork_Name = "";
        this.txtExecName.Text = "";
        this.txtExecCode.Text = "";
        this.hdfchkExecCode.Value = "";
        this.txtExecDesc.Text = "";
        this.hdfExecEmpDeptId.Value = "";
        this.txtExecEmpDeptIdName.Text = "";
        this.hdfExecEmpId.Value = "";
        this.txtExecEmpIdName.Text = "";
        this.txtExecIssue.Text = "";
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

    protected void ugrdWorkTaskList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        if (e.Row.Cells.FromKey("TGT_STR_DATE").Value.ToString().Substring(0, 10).Equals("1900-01-01"))
        {
            e.Row.Cells.FromKey("TGT_STR_DATE").Value = null;
        }
        if (e.Row.Cells.FromKey("TGT_END_DATE").Value.ToString().Substring(0, 10).Equals("1900-01-01"))
        {
            e.Row.Cells.FromKey("TGT_END_DATE").Value = null;
        }
        if (e.Row.Cells.FromKey("RST_STR_DATE").Value.ToString().Substring(0, 10).Equals("1900-01-01"))
        {
            e.Row.Cells.FromKey("RST_STR_DATE").Value = null;
        }
        if (e.Row.Cells.FromKey("RST_END_DATE").Value.ToString().Substring(0, 10).Equals("1900-01-01"))
        {
            e.Row.Cells.FromKey("RST_END_DATE").Value = null;
        }

        int intRow = ugrdWorkTaskList.Rows.Count;
        if (intRow > 0)
        {
            for (int i = 0; i < intRow; i++)
            {
                double var1 = double.Parse(ugrdWorkTaskList.Rows[i].Cells.FromKey("TGT_COST").Value.ToString());
                double var2 = double.Parse(ugrdWorkTaskList.Rows[i].Cells.FromKey("RST_COST").Value.ToString());

                if (var1 != 0 && var2 != 0)
                {
                    ugrdWorkTaskList.Rows[i].Cells.FromKey("PROG_RATE").Value = var2 / var1 * 100;
                }
                else
                {
                    ugrdWorkTaskList.Rows[i].Cells.FromKey("PROG_RATE").Value = 0;
                }
            }
        }
    }

    protected void ugrdWorkItemList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

    }

    protected void iBtnWorkTaskRefresh_Click(object sender, ImageClickEventArgs e)
    {
        setWorkTaskList(this.IExec_Ref_ID);
        
    }
    protected void iBtnWorkItemRefresh_Click(object sender, ImageClickEventArgs e)
    {
        setWorkItemList(this.IExec_Ref_ID);

    }
    protected void ugrdWorkTaskList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "사용여부";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "세부일정명칭";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "가중치(%)";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "집행율(%)";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "관리항목수";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[1].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[2].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;


        ch = e.Layout.Bands[0].Columns[9].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[10].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanY = 2;

    }
    protected void iBtnUndo_Click(object sender, ImageClickEventArgs e)
    {
        this.ReCompleteWorkExec();
    }
    protected void chkUseYN_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.chkUseYN.Checked)
        {
            Img1.Visible = false;
            pnlWorkTaskList.Enabled = false;
            pnlWorkItemList.Enabled = false;
            iBtnTargetFile_Up.Visible = false;
            this.chkCompleteYN.Enabled = false;
        }
        else
        {
            Img1.Visible = true;
            pnlWorkTaskList.Enabled = true;
            pnlWorkItemList.Enabled = true;
            iBtnTargetFile_Up.Visible = true;
            this.chkCompleteYN.Enabled = true;
            if (!User.IsInRole(ROLE_ADMIN) && EMP_REF_ID.ToString() != hdfExecEmpId.Value)
            {
                iBtnUpdate.Visible = false;
                iBtnNew.Visible = false;
                Img1.Visible = false;
                iBtnWorkTaskInsert.Visible = false;
                iBtnWorkItemInsert.Visible = false;
                iBtnTargetFile_Up.Visible = false;
            }
            if (this.chkCompleteYN.Checked)
            {
                this.chkCompleteYN.Enabled = false;
                this.iBtnUpdate.Visible = false;
                this.iBtnUndo.Visible = true;
                this.ugrdWorkTaskList.DisplayLayout.ReadOnly = ReadOnly.NotSet;
                this.ugrdWorkItemList.DisplayLayout.ReadOnly = ReadOnly.NotSet;
            }
            else
            {
                this.chkCompleteYN.Enabled = true;
                this.iBtnUpdate.Visible = true;
                this.iBtnUndo.Visible = false;
                this.ugrdWorkTaskList.DisplayLayout.ReadOnly = ReadOnly.LevelZero;
                this.ugrdWorkItemList.DisplayLayout.ReadOnly = ReadOnly.LevelZero;

            }
        }

        
    }
}
