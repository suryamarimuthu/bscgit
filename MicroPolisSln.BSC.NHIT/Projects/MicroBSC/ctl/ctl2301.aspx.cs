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
using MicroBSC.RolesBasedAthentication;

public partial class ctl_ctl2301 : AppPageBase
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

            string mode = WebUtility.GetRequest("mode");

            if (mode.Equals("New"))
            {
                pnlNew.Visible      = true;
                pnlRename.Visible   = false;
                pnlMove.Visible     = false;
                pnlRemove.Visible   = false;
                iBtnSave.ImageUrl   = "~/images/btn/b_156.gif";
            }
            else if (mode.Equals("Rename"))
            {
                pnlNew.Visible      = false;
                pnlRename.Visible   = true;
                pnlMove.Visible     = false;
                pnlRemove.Visible   = false;
                iBtnSave.ImageUrl   = "~/images/btn/b_002.gif";
            }
            else if (mode.Equals("Move"))
            {
                pnlNew.Visible      = false;
                pnlRename.Visible   = false;
                pnlMove.Visible     = true;
                pnlRemove.Visible   = false;
                iBtnSave.ImageUrl   = "~/images/btn/b_002.gif";
            }
            else if (mode.Equals("Remove"))
            {
                pnlNew.Visible      = false;
                pnlRename.Visible   = false;
                pnlMove.Visible     = false;
                pnlRemove.Visible   = true;
                iBtnSave.ImageUrl   = "~/images/btn/b_006.gif";
            }
        }

        Literal1.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        string mode = WebUtility.GetRequest("mode");

        if (mode.Equals("New"))
        {
            Header.Title = ":: 평가 부서 생성 ::";
        }
        else if (mode.Equals("Rename"))
        {
            Header.Title = ":: 평가 부서명 바꾸기 ::";
        }
        else if (mode.Equals("Move"))
        {
            Header.Title = ":: 평가 부서 이동 ::";
        }
        else if (mode.Equals("Remove"))
        {
            Header.Title = ":: 평가 부서 삭제 ::";
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept              = new DeptInfos();
        string deptid               = this.TreeView1.SelectedNode.Value;
        string deptname             = this.TreeView1.SelectedNode.Text;
        ltrHiddenDeptID.Text        = deptid;
        int est_dept_group_id       = 0;
        string level                = "";
        string treepath             = "";
        
        treepath    = WebCommon.GetEstParentTreeText(TreeView1);
        level = dept.GetDeptpathSelectLevel(int.Parse(deptid), WebUtility.GetRequestByInt("estterm_ref_id"));

        txtSortOrder.Text = this.TreeView1.SelectedNode.ToolTip;

        string mode = WebUtility.GetRequest("mode");

        if (mode.Equals("New"))
        {            
            ltrTreePath_New.Text    = treepath;
            ltrHiddenLevel.Text     = level;
        }
        else if (mode.Equals("Rename"))
        {
            int edIndex = (deptname.IndexOf("<") < 0) ? deptname.Length:deptname.IndexOf("<");
            ltrTreePath_Rename.Text = treepath.Replace(deptname, "").Replace("//", "/");
            ltrHiddenLevel.Text     = level;
            txtDeptRename.Text      = deptname.Substring(0,edIndex);
        }
        else if (mode.Equals("Move"))
        {
            ltrTreePath_Move.Text   = treepath; 
            ltrHiddenLevel.Text     = level;
        }
        else if (mode.Equals("Remove"))
        {
            ltrTreePath_Remove.Text = treepath; 
            ltrHiddenLevel.Text     = level;
        }
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DeptInfos dept              = new DeptInfos();
        string mode = WebUtility.GetRequest("mode");

        if (ltrHiddenDeptID.Text.Equals("")) 
        {
            Literal1.Text           = JSHelper.GetAlertScript("부서를 선택해 주세요.", false);
            return;
        }

        if (mode.Equals("New"))
        {
            if (txtDeptNew.Text.Equals("")) 
            {
                Literal1.Text       = JSHelper.GetAlertScript("등록하실 부서명을 입력하세요.", false);
                return;
            }
            
            dept.AddDeptinfo(int.Parse(ltrHiddenDeptID.Text), int.Parse(ltrHiddenLevel.Text) + 1, txtDeptNew.Text, int.Parse(Request["estterm_ref_id"]));
            //Response.Write(dept.IERRMSG.Replace("'", ""));
            WebCommon.FillEstTree(TreeView1, WebUtility.GetRequestByInt("estterm_ref_id"));
            TreeView1.ExpandAll();
            Literal1.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        }
        else if (mode.Equals("Rename"))
        {
            if (txtDeptRename.Text.Equals(""))
            {
                Literal1.Text = JSHelper.GetAlertScript("바꾸실 부서명을 입력하세요.", false);
                return;
            }

            /* 2011-06-13 수정 : 명칭변경시에 sortOrder도 수정하도록 변경 */
            //dept.RenameDeptName(int.Parse(Request["estterm_ref_id"]), int.Parse(ltrHiddenDeptID.Text), txtDeptRename.Text);
            int sortOrder = Convert.ToInt32(txtSortOrder.Text);
            dept.RenameDeptName(WebUtility.GetRequestByInt("estterm_ref_id"), int.Parse(ltrHiddenDeptID.Text), txtDeptRename.Text, sortOrder);
            /* 2011-06-13 수정 완료 ****************************************/
            WebCommon.FillEstTree(TreeView1, int.Parse(Request["estterm_ref_id"]));
            TreeView1.ExpandAll();
            Literal1.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        }
        else if (mode.Equals("Move"))
        {
            if (txtMoveDeptID.Text.Equals(""))
            {
                Literal1.Text = JSHelper.GetAlertScript("이동하실 부서경로를 선택 하세요.", false);
                return;
            }

            dept.MoveDeptPath(WebUtility.GetRequestByInt("estterm_ref_id"), int.Parse(ltrHiddenDeptID.Text), int.Parse(txtMoveDeptID.Text), int.Parse(txtMoveLevel.Text) + 1);
            //WebCommon.FillEstTree(TreeView1, int.Parse(Request["estterm_ref_id"]));
            Literal1.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        }
        else if (mode.Equals("Remove"))
        {
            if (ltrTreePath_Remove.Text.Equals(""))
            {
                Literal1.Text = JSHelper.GetAlertScript("삭제하실 부서를 선택 하세요.", false);
                return;
            }

            bool isOK = dept.RemoveDeptInfo(WebUtility.GetRequestByInt("estterm_ref_id"), int.Parse(ltrHiddenDeptID.Text));
            WebCommon.FillEstTree(TreeView1, WebUtility.GetRequestByInt("estterm_ref_id"));
            TreeView1.ExpandAll();
            Literal1.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
            //if (!isOK)
            //{
            //    Literal1.Text = JSHelper.GetAlertScript("사용 중인 평가 부서입니다.", false);
            //}
            //else 
            //{
            //    Literal1.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 부서명이 삭제되었습니다.", "lBtnReload", true);
            //}
        }
    }
}
