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
using MicroBSC.Estimation.Dac;
using MicroBSC.Common;

public partial class ctl_ctl2302 : AppPageBase
{
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            WebCommon.FillEstTree(TreeView1, int.Parse(Request["estterm_ref_id"]));
            WebCommon.FillEstTree(TreeView2, int.Parse(Request["estterm_ref_id"]));
        }

        Literal1.Text = "";
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept          = new DeptInfos();
        string deptid           = this.TreeView1.SelectedNode.Value;
        string deptname         = this.TreeView1.SelectedNode.Text;
        ltrHiddenDeptID.Text    = deptid;

        ltrTreePath_Move.Text   = WebCommon.GetEstParentTreeText(TreeView1);
        ltrHiddenLevel.Text     = dept.GetDeptpathSelectLevel(int.Parse(deptid),int.Parse(Request["estterm_ref_id"]));
    }
    protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept          = new DeptInfos();
        string deptid           = this.TreeView2.SelectedNode.Value;
        string deptname         = this.TreeView2.SelectedNode.Text;
        int level               = 0;

        txtDeptMove.Text        = WebCommon.GetEstParentTreeText(TreeView2);
        txtMoveLevel.Text       = dept.GetDeptpathSelectLevel(int.Parse(deptid),int.Parse(Request["estterm_ref_id"]));
        txtMoveDeptID.Text      = deptid;
    }
    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtMoveDeptID.Text.Equals(""))
        {
            Literal1.Text = JSHelper.GetAlertScript("이동하실 부서경로를 선택 하세요.", false);
            return;
        }

        DeptInfos dept = new DeptInfos();
        dept.MoveDeptPath(int.Parse(Request["estterm_ref_id"]),int.Parse(ltrHiddenDeptID.Text), int.Parse(txtMoveDeptID.Text), int.Parse(txtMoveLevel.Text) + 1);
        //Response.Redirect("ctl2302.aspx?estterm_ref_id=" + Request["estterm_ref_id"]);
        //Literal1.Text = JSHelper.GetAlertOpenerReflashSelfRedirectScript("정상적으로 부서명이 이동되었습니다.", "ctl2302.aspx?estterm_ref_id=" + Request["estterm_ref_id"]);
        Literal1.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 부서명이 이동되었습니다.", this.ICCB1, true);
    }
}
