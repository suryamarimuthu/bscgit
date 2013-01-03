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

public partial class ctl_ctl2102 : AppPageBase
{
    string DEPT_ID_field;
    string DEPT_NAME_field;

    protected void Page_Load(object sender, EventArgs e)
    {
        DEPT_ID_field = WebUtility.GetRequest("DEPT_ID", "");
        DEPT_NAME_field = WebUtility.GetRequest("DEPT_NAME", "");

        if (!Page.IsPostBack) 
        {
            WebCommon.FillComDeptTree(TreeView1);
            //WebCommon.FillComDeptTree(TreeView1);
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptid   = TreeView1.SelectedNode.Value;
        string deptname = TreeView1.SelectedNode.Text;

        string script;
        //if (DEPT_ID_field.Trim().Length == 0 || DEPT_NAME_field.Trim().Length == 0)
        //{
        //    script = "<script type='text/javascript'>\r\n"
        //            + "opener.document.getElementById('txtDeptID').value='" + deptid + "';\r\n"
        //            + "opener.document.getElementById('txtDeptName').value='" + deptname + "';\r\n"
        //            + "self.close();\r\n"
        //            + "</script>\r\n";
        //}
        //else
        //{
        //    script = "<script type='text/javascript'>\r\n"
        //            + "opener.document.getElementById('" + DEPT_ID_field + "').value='" + deptid + "';\r\n"
        //            + "opener.document.getElementById('" + DEPT_NAME_field + "').value='" + deptname + "';\r\n"
        //            + "self.close();\r\n"
        //            + "</script>\r\n";
        //}

        //심민섭 수정
        script = string.Format("<script type='text/javascript'>window.opener.PopUpCllFunction('{0}','{1}');window.close();</script>", deptid, deptname);

        Literal1.Text = script;
    }
}
