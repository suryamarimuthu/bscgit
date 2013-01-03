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
using MicroBSC.RolesBasedAthentication;

public partial class ctl_ctl2100_3 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            //WebCommon.FillComDeptTree(TreeView1);
            WebCommon.FillComDeptTree(TreeView1);

            if (WebUtility.GetRequest("mode").Equals("New"))
            {
                pnlNew.Visible = true;
                pnlRename.Visible = false;
                pnlMove.Visible = false;
                pnlRemove.Visible = false;
                iBtnSave.ImageUrl = "~/images/btn/b_156.gif";
            }
            else if (WebUtility.GetRequest("mode").Equals("Rename"))
            {
                pnlNew.Visible = false;
                pnlRename.Visible = true;
                pnlMove.Visible = false;
                pnlRemove.Visible = false;
                iBtnSave.ImageUrl = "~/images/btn/b_002.gif";
            }
            else if (WebUtility.GetRequest("mode").Equals("Move"))
            {
                pnlNew.Visible = false;
                pnlRename.Visible = false;
                pnlMove.Visible = true;
                pnlRemove.Visible = false;
                iBtnSave.ImageUrl = "~/images/btn/b_002.gif";
            }
            else if (WebUtility.GetRequest("mode").Equals("Remove"))
            {
                pnlNew.Visible = false;
                pnlRename.Visible = false;
                pnlMove.Visible = false;
                pnlRemove.Visible = true;
                iBtnSave.ImageUrl = "~/images/btn/b_006.gif";
            }
        }

        Literal1.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        string mode = WebUtility.GetRequest("mode");

        if (mode.Equals("New"))
        {
            Header.Title = ":: 부서 생성 ::";
        }
        else if (mode.Equals("Rename"))
        {
            Header.Title = ":: 부서명 바꾸기 ::";
        }
        else if (mode.Equals("Move"))
        {
            Header.Title = ":: 부서 이동 ::";
        }
        else if (mode.Equals("Remove"))
        {
            Header.Title = ":: 부서 삭제 ::";
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept = new DeptInfos();
        string deptid = this.TreeView1.SelectedNode.Value;
        string deptname = this.TreeView1.SelectedNode.Text;
        ltrHiddenDeptID.Text = deptid;
        int level = 0;

        if (Request["mode"].Equals("New"))
        {
            ltrTreePath_New.Text = dept.GetDeptpath(int.Parse(deptid), ref level);
            ltrHiddenLevel.Text = level.ToString();
        }
        else if (Request["mode"].Equals("Rename"))
        {
            ltrTreePath_Rename.Text = dept.GetDeptpath(int.Parse(deptid), ref level).Replace(deptname, "").Replace("//", "/");
            ltrHiddenLevel.Text = level.ToString();
            txtDeptRename.Text = deptname;
        }
        else if (Request["mode"].Equals("Move"))
        {
            ltrTreePath_Move.Text = dept.GetDeptpath(int.Parse(deptid), ref level);
            ltrHiddenLevel.Text = level.ToString();
        }
        else if (Request["mode"].Equals("Remove"))
        {
            //ltrTreePath_Remove.Text = dept.GetDeptpath(int.Parse(deptid), ref level);
            ltrTreePath_Remove.Text = WebCommon.GetParentTreeText(TreeView1);
            ltrHiddenLevel.Text = level.ToString();
        }
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DeptInfos dept = new DeptInfos();

        if (ltrHiddenDeptID.Text.Equals("")) 
        {
            Literal1.Text = JSHelper.GetAlertScript("부서를 선택해 주세요.", false);
            return;
        }

        if (Request["mode"].Equals("New"))
        {
            if (txtDeptNew.Text.Equals("")) 
            {
                Literal1.Text = JSHelper.GetAlertScript("등록하실 부서명을 입력하세요.", false);
                return;
            }

            dept.AddDeptInfo(int.Parse(ltrHiddenDeptID.Text)
                , int.Parse(ltrHiddenLevel.Text) + 1
                , txtDeptNew.Text
                , DateTime.Now
                , ((SiteIdentity)User.Identity).Emp_Ref_ID);
            Response.Redirect("ctl2103.aspx?mode=New");
        }
        else if (Request["mode"].Equals("Rename"))
        {
            if (txtDeptRename.Text.Equals(""))
            {
                Literal1.Text = JSHelper.GetAlertScript("바꾸실 부서명을 입력하세요.", false);
                return;
            }

            dept.RenameDeptName(int.Parse(ltrHiddenDeptID.Text), txtDeptRename.Text);
            Response.Redirect("ctl2103.aspx?mode=Rename");
        }
        else if (Request["mode"].Equals("Move"))
        {
            if (txtMoveDeptID.Text.Equals(""))
            {
                Literal1.Text = JSHelper.GetAlertScript("이동하실 부서경로를 선택 하세요.", false);
                return;
            }

            dept.MoveDeptPath(int.Parse(ltrHiddenDeptID.Text), int.Parse(txtMoveDeptID.Text), int.Parse(txtMoveLevel.Text) + 1);
            Response.Redirect("ctl2103.aspx?mode=Move");
        }
        else if (Request["mode"].Equals("Remove"))
        {
            if (ltrTreePath_Remove.Text.Equals(""))
            {
                Literal1.Text = JSHelper.GetAlertScript("삭제하실 부서를 선택 하세요.", false);
                return;
            }

            bool isOK = dept.RemoveDeptinfo(int.Parse(ltrHiddenDeptID.Text));

            if (!isOK) 
            {
                Literal1.Text = JSHelper.GetAlertScript("소속되어 있는 부서나 사원이 있습니다. 확인 후 삭제 해주세요.", false);
            }
            else
                Response.Redirect("ctl2103.aspx?mode=Remove");
        }
    }
}
