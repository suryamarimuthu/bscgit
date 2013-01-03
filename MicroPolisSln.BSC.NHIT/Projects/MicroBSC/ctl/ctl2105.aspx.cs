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

public partial class ctl_ctl2105 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            WebCommon.FillComDeptTree(TreeView1);
            WebCommon.FillComDeptTree(TreeView2);
        }

        Literal1.Text = "";
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept = new DeptInfos();
        string deptid = this.TreeView1.SelectedNode.Value;
        string deptname = this.TreeView1.SelectedNode.Text;
        ltrHiddenDeptID.Text = deptid;
        int level = 0;

        //ltrTreePath_Move.Text = dept.GetDeptpath(int.Parse(deptid), ref level);
        ltrTreePath_Move.Text = WebCommon.GetParentTreeText(TreeView1);
        ltrHiddenLevel.Text = level.ToString();
    }
    protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept = new DeptInfos();
        string deptid = this.TreeView2.SelectedNode.Value;
        string deptname = this.TreeView2.SelectedNode.Text;
        int level = 0;

        //txtDeptMove.Text = dept.GetDeptpath(int.Parse(deptid), ref level);
        txtDeptMove.Text  = WebCommon.GetParentTreeText(TreeView2);
        txtMoveLevel.Text = level.ToString();
        txtMoveDeptID.Text = deptid;
    }
    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtMoveDeptID.Text.Equals(""))
        {
            Literal1.Text = JSHelper.GetAlertScript("이동하실 부서경로를 선택 하세요.", false);
            return;
        }

        DeptInfos dept = new DeptInfos();
        dept.MoveDeptPath(int.Parse(ltrHiddenDeptID.Text), int.Parse(txtMoveDeptID.Text), int.Parse(txtMoveLevel.Text) + 1);
        Response.Redirect("ctl2105.aspx?mode=Move");
    }
}
