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

public partial class ctl_ctl2104 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            WebCommon.FillComDeptTree(TreeView1);
            //WebCommon.FillComDeptTree(TreeView1);
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept = new DeptInfos();
        string deptid = this.TreeView1.SelectedNode.Value;
        string deptname = this.TreeView1.SelectedNode.Text;
        int level = 0;

        string script = "<script type='text/javascript'>\r\n"
                + "opener.document.getElementById('txtDeptMove').value='" + dept.GetDeptpath(int.Parse(deptid), ref level) + "';\r\n"
                + "opener.document.getElementById('txtMoveLevel').value='" + level.ToString() + "';\r\n"
                + "opener.document.getElementById('txtMoveDeptID').value='" + deptid + "';\r\n"
                + "self.close();\r\n"
                + "</script>\r\n";

        Literal1.Text = script;
    }
}
