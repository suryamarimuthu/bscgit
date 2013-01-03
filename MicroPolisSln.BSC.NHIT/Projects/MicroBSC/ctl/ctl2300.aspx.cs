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
using MicroBSC.Biz.Common;
using MicroBSC.Common;

public partial class ctl_ctl2300 : AppPageBase
{
    protected string ESTTERM_REF_ID;

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

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TreeView1.Nodes.Clear();
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetEstDeptGroupDropDownList(ddlDeptGroup, ":: 선택 ::", "0", true);

            TreeView1.Nodes.Clear();
            WebCommon.FillEstMappingTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            //WebCommon.FillEstTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            TreeView1.ExpandAll();

            if (ddlEstTermInfo.Items.Count > 0)
            {
                WebCommon.FillComDeptTree(TreeView2);
            }

            WebCommon.SetEstTermDropDownList(ddlEstTermInfo2);
            DoSetPossibleCopay();
        }

        ESTTERM_REF_ID  = PageUtility.GetByValueDropDownList(ddlEstTermInfo);
        Literal1.Text   = "";

        // //체크인-체크아웃 활성화
        //MenuControl1.IsCheckInOutVisible = true;
        //MenuControl1.SetCheckInOutBuuton(tbSetup
        //                                        , btnIn
        //                                        , btnOut
        //                                        );
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        MicroBSC.Estimation.Dac.DeptInfos dept  = new MicroBSC.Estimation.Dac.DeptInfos();
        string deptid                           = TreeView1.SelectedNode.Value;
        string deptname                         = TreeView1.SelectedNode.Text;
        ltrEstDeptID.Text                       = deptid;
        int est_dept_group_id                   = 0;

        if(tdEstDeptGroup.Visible == false)
            tdEstDeptGroup.Visible              = true;

        ltrEstDeptPath.Text = WebCommon.GetEstParentTreeText(TreeView1);

        ListItem listItem = ddlDeptGroup.Items.FindByValue(est_dept_group_id.ToString());

        ddlDeptGroup.ClearSelection();

        if (listItem != null)
            listItem.Selected = true;
        else
            ddlDeptGroup.Items.FindByValue(Convert.ToString(0)).Selected = true;
    }
    protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeNode trnCur     = TreeView2.SelectedNode;

        ltrDeptID.Text      = trnCur.Value.ToString();
        ltrDeptPath.Text    = WebCommon.GetParentTreeText(TreeView2);
    }
    
    protected void btnOut_Click(object sender, ImageClickEventArgs e)
    {
        if (ltrEstDeptPath.Text.Equals(String.Empty))
        {
            Literal1.Text = JSHelper.GetAlertScript("평가 부서를 선택해 주세요.", false);
            return;
        }

        MicroBSC.Estimation.Dac.DeptInfos dept = new MicroBSC.Estimation.Dac.DeptInfos();

        dept.MappingEstDept_Dept_ID(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo),int.Parse(ltrEstDeptID.Text), 0, 0);
        TreeView1.Nodes.Clear();
        WebCommon.FillEstMappingTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        TreeView1.ExpandAll();
    }
    protected void btnIn_Click(object sender, ImageClickEventArgs e)
    {
        if (ltrEstDeptPath.Text.Equals(String.Empty))
        {
            Literal1.Text = JSHelper.GetAlertScript("평가 부서를 선택해 주세요.", false);
            return;
        }

        if (ltrDeptPath.Text.Equals(String.Empty))
        {
            Literal1.Text = JSHelper.GetAlertScript("인사 부서를 선택해 주세요.", false);
            return;
        }

        if (ddlDeptGroup.SelectedValue.Equals("0"))
        {
            Literal1.Text = JSHelper.GetAlertScript("부분을 선택해주세요.", false);
            return;
        }

        MicroBSC.Estimation.Dac.DeptInfos dept = new MicroBSC.Estimation.Dac.DeptInfos();
        dept.MappingEstDept_Dept_ID(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo),int.Parse(ltrEstDeptID.Text), int.Parse(ltrDeptID.Text), int.Parse(ddlDeptGroup.SelectedValue));
        TreeView1.Nodes.Clear();
        WebCommon.FillEstMappingTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        TreeView1.ExpandAll();
    }
    protected void ibtnCopy_Click(object sender, ImageClickEventArgs e)
    {
        DoCopyStg();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        TreeView1.Nodes.Clear();
        WebCommon.FillEstMappingTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        TreeView1.ExpandAll();

        if (btnIn.Visible           == false)
            btnIn.Visible           = true;
        if (btnOut.Visible          == false)
            btnOut.Visible          = true;
        if (tdEstDeptButton.Visible == false)
            tdEstDeptButton.Visible = true;
        //if (tdEstDeptGroup.Visible  = false)
        //    tdEstDeptGroup.Visible  = true;
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        WebCommon.FillEstMappingTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        TreeView1.ExpandAll();

        if (btnIn.Visible == false)
            btnIn.Visible = true;
        if (btnOut.Visible == false)
            btnOut.Visible = true;
        if (tdEstDeptButton.Visible == false)
            tdEstDeptButton.Visible = true;
    }

    protected void ddlEstTermInfo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoSetPossibleCopay();
    }

    private void DoSetPossibleCopay()
    {
        this.IPOSSIBLE_COPY = true;
        MicroBSC.Estimation.Dac.Dac_EstDeptInfos dept = new MicroBSC.Estimation.Dac.Dac_EstDeptInfos();
        DataTable dt = dept.Select(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), 0).Tables[0];
        if (dt.Rows.Count > 1)
            this.IPOSSIBLE_COPY = false;
        else
            if (dt.Rows.Count == 1)
                if (DataTypeUtility.GetToInt32(dt.Rows[0]["UP_EST_DEPT_ID"]) != 0)
                    this.IPOSSIBLE_COPY = false;
    }

    private void DoCopyStg()
    {
        MicroBSC.Estimation.Biz.Biz_EstDeptInfos dept = new MicroBSC.Estimation.Biz.Biz_EstDeptInfos();
        if (dept.CopyEstDept(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), gUserInfo.Emp_Ref_ID))
            PageUtility.AlertMessage("복사하였습니다.");
        else
            PageUtility.AlertMessage("복사 실패!" + dept.errMSG.Replace("'", ""));
        DoSetPossibleCopay();
    }
    //protected void lBtnReload_Click(object sender, EventArgs e)
    //{
    //    WebCommon.FillEstMappingTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    //}
}
