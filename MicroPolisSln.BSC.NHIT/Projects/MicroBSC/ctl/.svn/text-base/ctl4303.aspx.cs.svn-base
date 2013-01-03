using System;
using System.Data;
using System.Web.UI;

public partial class ctl_ctl4303 : AppPageBase
{

    protected int IESTTERM_REF_ID
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

    protected bool IPOSSIBLE_COPY
    {
        get
        {
            if (ViewState["POSSIBLE_COPY"] == null)
                ViewState["POSSIBLE_COPY"] = false;
            return (bool)ViewState["POSSIBLE_COPY"];
        }
        set
        {
            ViewState["POSSIBLE_COPY"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";
    }

    private void DoInitControl()
    {
        txtGROUP_CODE.Attributes.Add("readonly", "readonly");
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo2);
        DoSetPossibleCopay();
    }
    private void DoBinding()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        DataTable dt = objBSC.GetIssueGroup(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), 0);

        ugrdGroupList.Clear();
        ugrdGroupList.DataSource = dt;
        ugrdGroupList.DataBind();
    }

    private void DoSetPossibleCopay()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        DataTable dt = objBSC.GetIssueGroup(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), 0);
        this.IPOSSIBLE_COPY = (dt.Rows.Count > 0 ? false : true);
    }

    private void DoCopyStg()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        if (objBSC.CopyGroup(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), gUserInfo.Emp_Ref_ID))
            PageUtility.AlertMessage("복사하였습니다.");
        else
            PageUtility.AlertMessage("복사 실패!");
        DoSetPossibleCopay();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        DoBinding();
    }

    protected void ddlEstTermInfo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoSetPossibleCopay();
    }
    
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        if (objBSC.SaveIssueGroup(this.IESTTERM_REF_ID, (txtGROUP_CODE.Text.Trim() == "" ? 0 : DataTypeUtility.GetToInt32(txtGROUP_CODE.Text.Trim())), txtGROUP_NAME.Text.Trim(), gUserInfo.Emp_Ref_ID))
        {
            DoBinding();
            txtGROUP_CODE.Text = txtGROUP_NAME.Text = "";
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }

    protected void ibtnCopy_Click(object sender, ImageClickEventArgs e)
    {
        DoCopyStg();
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        if (objBSC.DeleteIssueGroup(this.IESTTERM_REF_ID, DataTypeUtility.GetToInt32(txtGROUP_CODE.Text.Trim())))
        {
            DoBinding();
            txtGROUP_CODE.Text = txtGROUP_NAME.Text = "";
            ltrScript.Text = JSHelper.GetAlertScript("삭제하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("삭제 실패!");
    }
}
