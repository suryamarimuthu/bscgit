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

using System.Transactions;
using System.Text.RegularExpressions;
using System.Drawing;

public partial class PRJ_PRJ1101M1 : AppPageBase
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

    public int IWorkPoolRefID
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

    UltraWebGrid TugrdQuestionItem;
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
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetProjectPriority(ddlPriority, 0, false, 200);
        objCode.GetProjectType(ddlWorkType, 0, false, 200);

        if (this.IType != "A")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool(this.IWorkPoolRefID);
            this.IWorkPoolRefID = objBSC.Iwork_pool_ref_id;
            this.txtWorkPoolRefID.Text = Convert.ToString(this.IWorkPoolRefID);
            txtWorkName.Text = objBSC.Iwork_name;
            txtWorkDesc.Value = objBSC.Iwork_desc;
            chkUseYn.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
            PageUtility.FindByValueDropDownList(ddlWorkType, objBSC.Iwork_type);
            PageUtility.FindByValueDropDownList(ddlPriority, objBSC.Iwork_priority);
        }
        else
        {
            this.IWorkPoolRefID = 0;
            txtWorkPoolRefID.Text = "";
            txtWorkName.Text = "";
            txtWorkDesc.Value  = "";
            chkUseYn.Checked = true;
        }

    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtWorkName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("중점과제명을 입력해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (this.IWorkPoolRefID < 1)
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
            if (this.IWorkPoolRefID < 1)
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

    private void InsertWorkPool()
    {
        if (!this.CheckFormData()) { return; }
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool();
        objBSC.Iwork_name = txtWorkName.Text.Trim();
        objBSC.Iwork_desc = txtWorkDesc.Value;
        objBSC.Iwork_type = PageUtility.GetByValueDropDownList(ddlWorkType, "");
        objBSC.Iwork_priority = PageUtility.GetByValueDropDownList(ddlPriority, "");
        objBSC.Iuse_yn = (chkUseYn.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.InsertData(objBSC.Iwork_name,
                                       objBSC.Iwork_desc,
                                       objBSC.Iwork_priority,
                                       objBSC.Iwork_type,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IWorkPoolRefID = objBSC.Iwork_pool_ref_id;
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UpdateWorkPool()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool();
        objBSC.Iwork_name = txtWorkName.Text.Trim();
        objBSC.Iwork_desc = txtWorkDesc.Value;
        objBSC.Iwork_type = PageUtility.GetByValueDropDownList(ddlWorkType, "");
        objBSC.Iwork_priority = PageUtility.GetByValueDropDownList(ddlPriority, "");
        objBSC.Iuse_yn = (chkUseYn.Checked) ? "Y" : "N";
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UpdateData(this.IWorkPoolRefID,
                                       objBSC.Iwork_name,
                                       objBSC.Iwork_desc,
                                       objBSC.Iwork_priority,
                                       objBSC.Iwork_type,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
    }

    private void ReUsedWorkPool()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool();
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReUsedData(this.IWorkPoolRefID,
                                       objBSC.Itxr_user);

        if (objBSC.Transaction_Result == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            this.IType = "U";
        }
    }

    private void DeleteWorkPool()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool();
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.DeleteData(this.IWorkPoolRefID,
                                       objBSC.Itxr_user);

        if (objBSC.Transaction_Result == "Y")
        {
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
        this.InsertWorkPool();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteWorkPool();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedWorkPool();
    }


    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateWorkPool();
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    #endregion

    protected void iBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        this.SetFormData();
        this.SetButton();
    }
}
