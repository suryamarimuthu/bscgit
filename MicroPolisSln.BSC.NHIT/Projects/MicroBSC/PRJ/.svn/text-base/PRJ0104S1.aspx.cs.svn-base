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
using MicroBSC.PRJ.Biz;

public partial class PRJ_PRJ0104S1 : PrjPageBase
{

    private string CTRL_VALUE_NAME;
    private string CTRL_TEXT_NAME;
    private int PRJ_REF_ID;
    private string PRJ_AFER_TASK_YN;
    private string SELECT_NODE_VALUE;

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", "");
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CTRL_VALUE_NAME     = WebUtility.GetRequest("CTRL_VALUE_NAME");
        CTRL_TEXT_NAME      = WebUtility.GetRequest("CTRL_TEXT_NAME");
        PRJ_REF_ID          = WebUtility.GetRequestByInt("PRJ_REF_ID");
        PRJ_AFER_TASK_YN    = WebUtility.GetRequest("AFTER_TASK_YN");
        SELECT_NODE_VALUE   = WebUtility.GetRequest("SELECT_NODE");

        if (PRJ_AFER_TASK_YN == "N")
            this.ibtnNoSelect.Visible = false;
        else
            this.ibtnNoSelect.Visible = true;
     

        if (!Page.IsPostBack)
        {
            BindSchedule(TreeView1, false, TreeNodeSelectAction.Select, "");
        }

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
		
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (SELECT_NODE_VALUE == TreeView1.SelectedNode.Value)
        {
            ltrScript.Text = JSHelper.GetAlertScript("동일한 작업을 선택하실수없습니다.");
            return;
        }


        Response.Write("<script type='text/javascript'>\r\n");

        if (!TreeView1.SelectedNode.Value.Equals(""))
        {
            if (!CTRL_VALUE_NAME.Equals(""))
                Response.Write("opener.document.getElementById('" + CTRL_VALUE_NAME + "').value='" + TreeView1.SelectedNode.Value + "';\r\n");

            if (!CTRL_TEXT_NAME.Equals(""))
                Response.Write("opener.document.getElementById('" + CTRL_TEXT_NAME + "').value='" + TreeView1.SelectedNode.Text + "';\r\n");

            if(ICCB2 == "")
                Response.Write("self.close();\r\n");
        }
        else
        {
                Response.Write("alert('작업명을 선택하세요.');");
        }

        Response.Write("</script>\r\n");

        if(ICCB2 != "")
            ltrScript.Text = string.Format("<script language=javascript>parent.window.opener.__doPostBack('{0}',''); parent.window.close(); </script>", this.ICCB2);
    }

    private TreeNode CreateNode(DataRow row
                                 , string imageurl
                                 , bool expanded
                                 , TreeNodeSelectAction treeNodeSel
                                 , bool showChk
                                 )
    {
        TreeNode node = new TreeNode();

        node.Value = row["TASK_REF_ID"].ToString();
        node.Text = row["TASK_NAME"].ToString();

        node.ImageUrl = imageurl;
        node.SelectAction = treeNodeSel;
        node.Expanded = expanded;
        node.ShowCheckBox = showChk;
        return node;
    }

    public void BindSchedule(TreeView treeView
                                    , bool isCheckBox
                                    , TreeNodeSelectAction treeNodeSelectAction
                                    , string checkedValues)
    {
        string valueStr = "TASK_REF_ID";
        string up_valueStr = "UP_TASK_REF_ID";
        string textStr = "TASK_NAME";
        string iconStr = "TASK_TYPE";
        string imageUrlDir = "../images/treeview/";
        bool isExtended = true;
        DataTable dataTable = null;

       

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        DataSet ds = objSchedule.GetAllList(PRJ_REF_ID, 0);

        ds.Relations.Add("NodeRelation"
                        , ds.Tables[0].Columns[valueStr]
                        , ds.Tables[0].Columns[up_valueStr]
                        , false);

        treeView.Nodes.Clear();


        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (DataTypeUtility.GetToInt32(dbRow[up_valueStr]) == 0)
            {
                TreeNode rootNode = CreateNode(dbRow
                                        , imageUrlDir + "root.gif"
                                        , isExtended
                                        , treeNodeSelectAction
                                        , isCheckBox);

                if (isCheckBox && (checkedValues != null || checkedValues == ""))
                {
                    TreeNodeCheck(rootNode, dataTable);
                }

                treeView.Nodes.Add(rootNode);
                PopulateScheduleTree(dbRow, rootNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, isExtended, isCheckBox, dataTable);
            }
        }
    }

    private void TreeNodeCheck(TreeNode treeNode, DataTable dataTable)
    {
        DataRow[] drCol = dataTable.Select("OK_YN = 'N'");

        foreach (DataRow dr in drCol)
        {
            if (treeNode.Value.Equals(dr["VALUE"].ToString()))
            {
                treeNode.Checked = true;
                dr["OK_YN"] = "Y";
            }
        }
    }


    private void PopulateScheduleTree(DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , string iconStr
                                        , TreeNodeSelectAction treeNodeSelectAction
                                        , bool expanded
                                        , bool isCheckBox
                                        , DataTable callbackDataTable
                                       )
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            TreeNode childNode = CreateNode(childRow
                                            , imageUrlDir + "tasks.gif"
                                            , expanded
                                            , treeNodeSelectAction
                                            , isCheckBox);

            if (isCheckBox && callbackDataTable != null)
            {
                TreeNodeCheck(childNode, callbackDataTable);
            }

            node.ChildNodes.Add(childNode);

            PopulateScheduleTree(childRow, childNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, expanded, isCheckBox, callbackDataTable);
        }
    }

    protected void ibtnNoSelect_Click(object sender, ImageClickEventArgs e)
    {

        Response.Write("<script type='text/javascript'>\r\n");

        if (!CTRL_VALUE_NAME.Equals(""))
            Response.Write("opener.document.getElementById('" + CTRL_VALUE_NAME + "').value='" + "" + "';\r\n");

        if (!CTRL_TEXT_NAME.Equals(""))
            Response.Write("opener.document.getElementById('" + CTRL_TEXT_NAME + "').value='" + "" + "';\r\n");

        if (ICCB2 == "")
            Response.Write("self.close();\r\n");

        Response.Write("</script>\r\n");


        if(ICCB2 != "")
            ltrScript.Text = string.Format("<script language=javascript>parent.window.opener.__doPostBack('{0}',''); parent.window.close(); </script>", this.ICCB2);

    }
}
