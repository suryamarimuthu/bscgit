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

// 제    목 : 평가 선택 페이지
// 내    용 : 쿼리스트링의 옵션값에 의해서 싱글/멀티 선택이 가능함            
public partial class EST_EST_EST : EstPageBase
{
    private string CHECHBOX_YN;
    private string CTRL_VALUE_NAME;
    private string CTRL_TEXT_NAME;
    private string CTRL_VALUE_VALUE;
    private string POSTBACK_YN;
    private string POSTBACK_CTRL_NAME;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID             = WebUtility.GetRequestByInt("COMP_ID");
        CTRL_VALUE_NAME     = WebUtility.GetRequest("CTRL_VALUE_NAME");
        CTRL_TEXT_NAME      = WebUtility.GetRequest("CTRL_TEXT_NAME");
        CHECHBOX_YN         = WebUtility.GetRequest("CHECKBOX_YN");
        CTRL_VALUE_VALUE    = WebUtility.GetRequest("CTRL_VALUE_VALUE");
        POSTBACK_YN         = WebUtility.GetRequest("POSTBACK_YN");
        POSTBACK_CTRL_NAME  = WebUtility.GetRequest("POSTBACK_CTRL_NAME");

        if (!Page.IsPostBack)
        {
            if(!CHECHBOX_YN.Equals("Y")) 
            {
                ibnSelect.Visible = false;
                TreeViewCommom.BindEst(TreeView1, false, TreeNodeSelectAction.Select, null, COMP_ID);
            }
            else 
            {
                TreeViewCommom.BindEst(TreeView1, ibnSelect.Visible, TreeNodeSelectAction.None, CTRL_VALUE_VALUE, COMP_ID);
            }
        }

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
		
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        Response.Write("<script type='text/javascript'>\r\n");

        if (!TreeView1.SelectedNode.Value.Equals(""))
        {
            if (!CTRL_VALUE_NAME.Equals(""))
                Response.Write("opener.document.getElementById('" + CTRL_VALUE_NAME + "').value='" + TreeView1.SelectedNode.Value + "';\r\n");

            if (!CTRL_TEXT_NAME.Equals(""))
            {
                Response.Write("opener.document.getElementById('" + CTRL_TEXT_NAME + "').value='" + TreeView1.SelectedNode.Text + "';\r\n");
                Response.Write("opener.document.getElementById('" + CTRL_TEXT_NAME + "').focus();\r\n");
            }

            Response.Write("self.close();\r\n");
        }
        else
        {
            Response.Write("alert('트리의 선택된 값이 빈값입니다.');");
        }

        Response.Write("</script>\r\n");
    }

    protected void ibnSelect_Click(object sender, ImageClickEventArgs e)
    {
        if(TreeView1.CheckedNodes.Count > 0)
        {
            string values   = "";
            string texts    = "";
            bool isFirst    = true;

            for(int i = 0; i < TreeView1.CheckedNodes.Count; i++) 
            {
                if(isFirst) 
                {
                    values  += TreeView1.CheckedNodes[i].Value;
                    texts   += TreeView1.CheckedNodes[i].Text;
                    isFirst = false;
                }
                else 
                {
                    values  += string.Format(",{0}", TreeView1.CheckedNodes[i].Value); 
                    texts   += string.Format(",{0}", TreeView1.CheckedNodes[i].Text); 
                }
            }

            Response.Write("<script type='text/javascript'>\r\n");

            if (!CTRL_VALUE_NAME.Equals(""))
                Response.Write("opener.document.getElementById('" + CTRL_VALUE_NAME + "').value='" + values + "';\r\n");

            if (!CTRL_TEXT_NAME.Equals(""))
            {
                Response.Write("opener.document.getElementById('" + CTRL_TEXT_NAME + "').value='" + texts + "';\r\n");
                Response.Write("opener.document.getElementById('" + CTRL_TEXT_NAME + "').focus();\r\n");
            }

            if(!POSTBACK_YN.Equals("Y"))
                Response.Write("self.close();\r\n");

            Response.Write("</script>\r\n");

            if(POSTBACK_YN.Equals("Y"))
            {
                ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(POSTBACK_CTRL_NAME, true);
                return;
            }
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("체크박스를 선택하세요.");
        }
    }
}
