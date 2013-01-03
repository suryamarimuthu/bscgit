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

public partial class BSC_BSC0403S3 : EstPageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           WebCommon.FillEstTree(TreeView1, WebUtility.GetRequestByInt("estterm_ref_id"));
        }
    }


    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        MicroBSC.Biz.Common.Biz.Biz_DeptTypeInfo biz = new MicroBSC.Biz.Common.Biz.Biz_DeptTypeInfo();
        DataSet ds = biz.GetDeptTypeSortList(int.Parse(Request["estterm_ref_id"]), int.Parse(TreeView1.SelectedNode.Value));

        int rowcount = ds.Tables[0].Rows.Count;
        if (rowcount == 0)
        {
            PageUtility.ExecuteScript("alert('비교 대상이 될수 없는 최하위 조직입니다\\n상위 조식을 선택하세요');");
        }
        else
        {
            Response.Write("<script type='text/javascript'>\r\n");
            Response.Write("opener.document.getElementById('hdfDeptID').value='" + TreeView1.SelectedNode.Value + "';\r\n");
            Response.Write("opener.document.getElementById('txtDeptName').value='" + TreeView1.SelectedNode.Text + "';\r\n");
            Response.Write("opener.__doPostBack('lBtnReload','');\r\n");
            //Response.Write("alert('" + TreeView1.SelectedNode.Value + "');\r\n");
            Response.Write("self.close();\r\n");
            Response.Write("</script>\r\n");
        }
    }
}
