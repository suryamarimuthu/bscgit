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

public partial class PRJ_PRJ1102M1 : AppPageBase
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

    public string IEstterm_Ref_Id_Name
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

    public string IEst_Dept_Ref_Id_Name
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

    public int IWork_Pool_Ref_ID
    {
        get
        {
            if (ViewState["WORK_POOL_REF_ID"] == null)
            {
                ViewState["WORK_POOL_REF_ID"] = GetRequestByInt("WORK_POOL_REF_ID", 0);
            }

            return (int)ViewState["WORK_POOL_REF_ID"];
        }
        set
        {
            ViewState["WORK_POOL_REF_ID"] = value;
        }
    }

    public int IWork_Emp_ID
    {
        get
        {
            if (ViewState["WORK_EMP_ID"] == null)
            {
                ViewState["WORK_EMP_ID"] = GetRequestByInt("WORK_EMP_ID", 0);
            }

            return (int)ViewState["WORK_EMP_ID"];
        }
        set
        {
            ViewState["WORK_EMP_ID"] = value;
        }
    }

    public string IWork_Emp_ID_Name
    {
        get
        {
            if (ViewState["WORK_EMP_ID_NAME"] == null)
            {
                ViewState["WORK_EMP_ID_NAME"] = GetRequest("WORK_EMP_ID_NAME", "");
            }

            return (string)ViewState["WORK_EMP_ID_NAME"];
        }
        set
        {
            ViewState["WORK_EMP_ID_NAME"] = value;
        }
    }

    public int IWork_Emp_Dept_ID
    {
        get
        {
            if (ViewState["WORK_EMP_DEPT_ID"] == null)
            {
                ViewState["WORK_EMP_DEPT_ID"] = GetRequestByInt("WORK_EMP_DEPT_ID", 0);
            }

            return (int)ViewState["WORK_EMP_DEPT_ID"];
        }
        set
        {
            ViewState["WORK_EMP_DEPT_ID"] = value;
        }
    }

    public string IWork_Emp_Dept_ID_Name
    {
        get
        {
            if (ViewState["WORK_EMP_DEPT_ID_NAME"] == null)
            {
                ViewState["WORK_EMP_DEPT_ID_NAME"] = GetRequest("WORK_EMP_DEPT_ID_NAME", "");
            }

            return (string)ViewState["WORK_EMP_DEPT_ID_NAME"];
        }
        set
        {
            ViewState["WORK_EMP_DEPT_ID_NAME"] = value;
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
    private string IWork_Desc = "";
    private string IWork_Issue;
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
        if (!Page.IsPostBack)
        {
            this.SetFormData();
            this.SetButton();
        }
        ltrScript.Text = "";
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
            iBtnUndo.Visible = false;
            imgopenWorkPool.Visible = true;
            imgWorkCodeSearch.Visible = true;

            //pnlWorkPool.Enabled = true;
            pnlWorkCode.Enabled = true;


        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            
           
            iBtnUpdate.Visible = true;
            iBtnNew.Visible = true;
            imgopenWorkPool.Visible = false;
            imgWorkCodeSearch.Visible = false;

            //pnlWorkPool.Enabled = false;
            pnlWorkCode.Enabled = false;

            if (!User.IsInRole(ROLE_ADMIN) && EMP_REF_ID.ToString() != hdfWorkEmpId.Value)
            {
                iBtnUpdate.Visible = false;
                iBtnNew.Visible = false;
                iBtnTargetFile_Up.Visible = false;
            }

            if (!this.chkUseYN.Checked)
            {
                pnlWorkDesc.Enabled = false;
                spnWorkDesc.Visible = true;
                txtWorkDesc.Visible = false;
                imgDeptEmp.Visible = false;
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
            imgopenWorkPool.Visible = false;
            imgWorkCodeSearch.Visible = false;

            //pnlWorkPool.Enabled = false;
            pnlWorkCode.Enabled = false;
        }




    }

    private void SetFormData()
    {
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetProjectPriority(ddlWorkPriority, 0, false, 100);
        objCode.GetProjectType(ddlWorkType, 0, false, 100);

        if (this.IType != "A")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info(this.IEstterm_Ref_ID, this.IEst_Dept_Ref_ID, this.IWork_Ref_ID);

            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;

            this.IEstterm_Ref_Id_Name = objBSC.Iestterm_ref_id_name;
            txtEstTermRefId.Text = objBSC.Iestterm_ref_id_name;

            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;

            this.IEst_Dept_Ref_Id_Name = objBSC.Iest_dept_ref_id_name;
            txtEstDeptRefId.Text = objBSC.Iest_dept_ref_id_name;

            this.IWork_Ref_ID = objBSC.Iwork_ref_id;
           
            this.IWork_Pool_Ref_ID = objBSC.Iwork_pool_ref_id;
            hdfWorkPoolRefId.Value = Convert.ToString(objBSC.Iwork_pool_ref_id);

            txtWorkCode.Text = objBSC.Iwork_code;
            txtWorkName.Text = objBSC.Iwork_name;
            
            txtWorkDesc.Value = objBSC.Iwork_desc;
            spnWorkDesc.InnerHtml = objBSC.Iwork_desc;

            this.IWork_Emp_Dept_ID = objBSC.Iwork_emp_id_dept_id;
            hdfWorkEmpDeptId.Value  = Convert.ToString(objBSC.Iwork_emp_id_dept_id);

            this.IWork_Emp_Dept_ID_Name = objBSC.Iwork_emp_id_dept_id_name;
            hdfWorkEmpDeptIdName.Value  = objBSC.Iwork_emp_id_dept_id_name;

            this.IWork_Emp_ID = objBSC.Iwork_emp_id;
            hdfWorkEmpId.Value  = Convert.ToString(objBSC.Iwork_emp_id);

            this.IWork_Emp_ID_Name = objBSC.Iwork_emp_id_name;
            txtWorkEmpIdName.Text = objBSC.Iwork_emp_id_name;

            PageUtility.FindByValueDropDownList(ddlWorkType, objBSC.Iwork_type);
            PageUtility.FindByValueDropDownList(ddlWorkPriority, objBSC.Iwork_priority);
            txtWorkIssue.Text = objBSC.Iwork_issue;
            this.IAdd_File = objBSC.Iadd_file;
            this.hdfTargetReasonFile.Value = objBSC.Iadd_file;
            this.IApp_Ref_ID = objBSC.Iapp_ref_id;
            this.IUse_YN = (objBSC.Iuse_yn == "Y") ? true : false;
            this.chkUseYN.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
            if (objBSC.Iuse_yn == "Y")
            {
                //2012.01.02 박효동 : 허성덕과장요청으로 사용안함에 대하여 각종 컨트롤 잠금
                ddlWorkPriority.Enabled = ddlWorkType.Enabled = true;
                txtWorkIssue.ReadOnly = false;
            }
            else
            {
                //2012.01.02 박효동 : 허성덕과장요청으로 사용안함에 대하여 각종 컨트롤 잠금
                ddlWorkPriority.Enabled = ddlWorkType.Enabled = false;
                txtWorkIssue.ReadOnly = true;
            }
            this.chkCompleteYN.Checked = (objBSC.Icomplete_yn == "Y") ? true : false;
            
           
            if (objBSC.Iadd_file == "")
            {

            }
            else
            {
                SearchAddFile();
            }


        }
        else
        {
            MicroBSC.Estimation.Dac.TermInfos objTERM = new MicroBSC.Estimation.Dac.TermInfos(this.IEstterm_Ref_ID);
            txtEstTermRefId.Text = Convert.ToString(objTERM.Estterm_name);
            MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo objDEPT = new MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo(this.IEst_Dept_Ref_ID);
            txtEstDeptRefId.Text = Convert.ToString(objDEPT.Idept_name);
            //ddlKpiCategoryTop_SelectedIndexChanged(null, null);
            this.chkUseYN.Checked = true;
            iBtnTargetFile_Down.Visible = false ;
            lbFileList.Items.Clear();

        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtWorkCode.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("중점과제 코드를 입력해 주십시오", false);
                return false;
            }
            else
            {
                if (txtWorkName.Text.Trim() == "")
                {
                    ltrScript.Text = JSHelper.GetAlertScript("중점과제명을 입력해 주십시오", false);
                    return false;
                }
                else
                {
                    if (hdfchkWorkCode.Value == "")
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("중점코드를 중복체크 하세요", false);
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
            if (this.IWork_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("중점과제를 선택해 주십시오", false);
                return false;
            }
            else if (txtWorkName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("중점과제명을 입력해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (this.IWork_Ref_ID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("중점과제를 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertWorkInfo()
    {
        if (!this.CheckFormData()) { return; }
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        //objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Iwork_pool_ref_id = Convert.ToInt32(this.hdfWorkPoolRefId.Value);// this.IWork_Pool_Ref_ID;
        objBSC.Iwork_code = txtWorkCode.Text.Trim();
        objBSC.Iwork_name = txtWorkName.Text.Trim();
        objBSC.Iwork_desc = txtWorkDesc.Value;
        objBSC.Iwork_emp_id = Convert.ToInt32((this.hdfWorkEmpId.Value == "") ? "0" : this.hdfWorkEmpId.Value);
        objBSC.Iwork_priority = PageUtility.GetByValueDropDownList(ddlWorkPriority, "");
        objBSC.Iwork_type = PageUtility.GetByValueDropDownList(ddlWorkType, "");
        objBSC.Iwork_issue = txtWorkIssue.Text;

        objBSC.Iadd_file = this.hdfTargetReasonFile.Value ;
        objBSC.Iapp_ref_id = this.IApp_Ref_ID;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Icomplete_yn = (this.chkCompleteYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.InsertData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iwork_pool_ref_id,
                                       objBSC.Iwork_code,
                                       objBSC.Iwork_name,
                                       objBSC.Iwork_desc,
                                       objBSC.Iwork_emp_id,
                                       objBSC.Iwork_priority,
                                       objBSC.Iwork_type,
                                       objBSC.Iwork_issue,
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
            
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UpdateWorkInfo()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Iwork_pool_ref_id = Convert.ToInt32(this.IWork_Pool_Ref_ID);// this.IWork_Pool_Ref_ID;
        objBSC.Iwork_code = txtWorkCode.Text.Trim();
        objBSC.Iwork_name = txtWorkName.Text.Trim();
        objBSC.Iwork_desc = txtWorkDesc.Value;
        objBSC.Iwork_emp_id = Convert.ToInt32((this.hdfWorkEmpId.Value == "") ? "0" : this.hdfWorkEmpId.Value);
        objBSC.Iwork_priority = PageUtility.GetByValueDropDownList(ddlWorkPriority, "");
        objBSC.Iwork_type = PageUtility.GetByValueDropDownList(ddlWorkType, "");
        objBSC.Iwork_issue = txtWorkIssue.Text;
        objBSC.Iadd_file = this.IAdd_File;
        objBSC.Iapp_ref_id = this.IApp_Ref_ID;
        objBSC.Iuse_yn = (this.chkUseYN.Checked) ? "Y" : "N";
        objBSC.Icomplete_yn = (this.chkCompleteYN.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UpdateData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Iwork_pool_ref_id,
                                       objBSC.Iwork_code,
                                       objBSC.Iwork_name,
                                       objBSC.Iwork_desc,
                                       objBSC.Iwork_emp_id,
                                       objBSC.Iwork_priority,
                                       objBSC.Iwork_type,
                                       objBSC.Iwork_issue,
                                       objBSC.Iadd_file,
                                       objBSC.Iapp_ref_id,
                                       objBSC.Iuse_yn,
                                       objBSC.Icomplete_yn,
                                       objBSC.Itxr_user);

        //중점과제 사용여부를 "N"으로 변경하면 관련 실행과제의 사용여부도 "N"으로 변경. "Y"로 변경시 개별 수정
        if (!this.chkUseYN.Checked)
        {
            this.UnUsedWorkExec();
        }

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        if (objBSC.Transaction_Result == "Y")
        {
            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;
            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;
            this.IWork_Ref_ID = objBSC.Iwork_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }

    }

    private void ReUsedWorkInfo()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReUsedData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;
            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;
            this.IWork_Ref_ID = objBSC.Iwork_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UnUsedWorkExec()
    {
        this.IType = "UU";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Exec();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UnUsedData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Itxr_user);
    }


    private void ReCompleteWorkInfo()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RC";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReCompleteData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IEstterm_Ref_ID = objBSC.Iestterm_ref_id;
            this.IEst_Dept_Ref_ID = objBSC.Iest_dept_ref_id;
            this.IWork_Ref_ID = objBSC.Iwork_ref_id;

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void DeleteWorkInfo()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info();
        objBSC.Iestterm_ref_id = this.IEstterm_Ref_ID;
        objBSC.Iest_dept_ref_id = this.IEst_Dept_Ref_ID;
        objBSC.Iwork_ref_id = this.IWork_Ref_ID;
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.DeleteData(objBSC.Iestterm_ref_id,
                                       objBSC.Iest_dept_ref_id,
                                       objBSC.Iwork_ref_id,
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
        this.InsertWorkInfo();
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteWorkInfo();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedWorkInfo();
    }


    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateWorkInfo();

    
        // 평가항목관련 주석처리했음.
        //this.TxrKpiPoolQuestion();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
     
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    #endregion

    protected void imgWorkCodeSearch_Click(object sender, ImageClickEventArgs e)
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Work_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Info();
        DataSet ds = objBSC.GetWorkCode(this.IEstterm_Ref_ID, this.txtWorkCode.Text);

        if (ds.Tables[0].Rows.Count > 0 )
        {
            ltrScript.Text = JSHelper.GetAlertScript("코드가 중복되었습니다. 다른 코드를 사용하세요", false);
            hdfchkWorkCode.Value = "";

            txtWorkCode.Text = "";
            txtWorkCode.Focus(); 
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("중복확인 완료. 입력 가능합니다.", false);
            hdfchkWorkCode.Value = "*";
        }
    }


    protected void iBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        this.IWork_Pool_Ref_ID = 0;
        this.hdfWorkPoolRefId .Value = "";
        this.IWork_Name = "";
        this.txtWorkName.Text = "";
        this.txtWorkCode.Text = "";
        this.hdfchkWorkCode.Value = "";
        this.txtWorkDesc.Value = "";
        this.hdfWorkEmpDeptId.Value = "";
        this.hdfWorkEmpDeptIdName.Value = "";
        this.hdfWorkEmpId.Value = "";
        this.txtWorkEmpIdName.Text = "";
        this.txtWorkIssue.Text = "";
        this.lbFileList.Items.Clear();
        this.IAdd_File  = "";
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
    protected void iBtnUndo_Click(object sender, ImageClickEventArgs e)
    {
        this.ReCompleteWorkInfo();
    }
    protected void chkUseYN_CheckedChanged(object sender, EventArgs e)
    {



        if (!chkUseYN.Checked)
        {
            ltrScript.Text = JSHelper.GetAlertScript("[사용안함]으로 변경 시 관련 실행과제도 [사용안함]으로 상태 변경됩니다.", false);
            pnlWorkDesc.Enabled = false;
            txtWorkDesc.Visible = false;
            spnWorkDesc.Visible = true;
            imgDeptEmp.Visible = false;
            iBtnTargetFile_Up.Visible = false;
            this.chkCompleteYN.Enabled = false;

            //2012.01.02 박효동 : 허성덕과장요청으로 사용안함에 대하여 각종 컨트롤 잠금
            ddlWorkPriority.Enabled = ddlWorkType.Enabled = false;
            txtWorkIssue.ReadOnly = true;
        }
        else
        {
            //2012.01.02 박효동 : 허성덕과장요청으로 사용안함에 대하여 각종 컨트롤 잠금
            ddlWorkPriority.Enabled = ddlWorkType.Enabled = true;
            txtWorkIssue.ReadOnly = false;

            ltrScript.Text = JSHelper.GetAlertScript("관련 실행과제의 상태를 확인하세요", false);
            pnlWorkDesc.Enabled = true;
            txtWorkDesc.Visible = true;
            spnWorkDesc.Visible = false;
            imgDeptEmp.Visible = true;
            iBtnTargetFile_Up.Visible = true;
            this.chkCompleteYN.Enabled = true;
            if (!User.IsInRole(ROLE_ADMIN) && EMP_REF_ID.ToString() != hdfWorkEmpId.Value)
            {
                iBtnUpdate.Visible = false;
                iBtnNew.Visible = false;
                iBtnTargetFile_Up.Visible = false;

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
            // 수정버튼이 튀어나와서 처리 2011.01.03 박효동
            if (this.IType == "A")
                iBtnUpdate.Visible = false;
        }
      
    }
}
