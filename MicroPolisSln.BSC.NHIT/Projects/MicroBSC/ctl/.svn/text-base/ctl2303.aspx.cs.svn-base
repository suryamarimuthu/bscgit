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

public partial class ctl_ctl2103 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            WebCommon.FillEstTree(TreeView1, int.Parse(Request["esttermid"]));
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            ddlEstTermInfo.Items.FindByValue(Request["esttermid"]).Selected = true;
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DeptInfos dept = new DeptInfos();
        string deptid = this.TreeView1.SelectedNode.Value;
        string deptname = this.TreeView1.SelectedNode.Text;

        string script = "<script type='text/javascript'>\r\n"
                + "opener.document.getElementById('" + Request["id"] + "').value='" + deptid + "';\r\n"
                + "opener.document.getElementById('" + Request["name"] + "').value='" + deptname + "';\r\n"
                + "self.close();\r\n"
                + "</script>\r\n";

        Literal1.Text = script;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        TreeView1.Nodes.Clear();
        WebCommon.FillEstTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        TreeView1.ExpandAll();
    }
}
