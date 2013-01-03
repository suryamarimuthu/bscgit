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
using System.Collections.Generic;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Biz.BSC.Biz;

public partial class EST_EST_DEPT1 : EstPageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           TreeViewCommom.BindDept(TreeView1, TreeNodeSelectAction.Select);
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string script = string.Format("<script>opener.fnDeptSelect({0},'{1}',window)</script>;", TreeView1.SelectedNode.Value, TreeView1.SelectedNode.Text);
        Response.Write(script);
    }

}
