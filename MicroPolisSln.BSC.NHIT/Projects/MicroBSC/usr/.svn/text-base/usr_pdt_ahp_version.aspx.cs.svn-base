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

using SJ.Web.UI;

using MicroBSC.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;

public partial class usr_pdt_ahp_version : AppPageBase
{
    private int ESTTERM_REF_ID;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        if (!Page.IsPostBack) 
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            StgVersionDropDownBinding();
            StatusInfo();
        }

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        iBtnRemove.Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");
    }

    private void StgVersionDropDownBinding() 
    {
        ddlStgVersion.ClearSelection();
        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions();
        DataSet ds                          = pdtAhpVersion.GetPdtAhpVersions(ESTTERM_REF_ID); 
        ddlStgVersion.DataSource            = ds;
        ddlStgVersion.DataValueField        = "VER_ID";
        ddlStgVersion.DataTextField         = "VER_NAME";
        ddlStgVersion.DataBind();

        ddlStgVersion.Items.Insert(ds.Tables[0].Rows.Count, new ListItem("<<< 새로 추가", "0"));

        if (ds.Tables[0].Rows.Count > 0)
            hdfStatus.Value = "M";
        else
            hdfStatus.Value = "N";
    }

    private void SetStgVersion() 
    {
        int ver_id                          = int.Parse(ddlStgVersion.SelectedValue);

        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions(ver_id, ESTTERM_REF_ID);
        txtStgName.Text                     = pdtAhpVersion.Ver_Name;
        txtStgDesc.Text                     = pdtAhpVersion.Ver_Desc;

        iBtnSave.ImageUrl                   = "~/images/btn/b_002.gif";
        iBtnRemove.Visible                  = true;
    }

    private void SetBlankStgVersion()
    {
        txtStgName.Text                     = "";
        txtStgDesc.Text                     = "";

        iBtnSave.ImageUrl                   = "~/images/btn/b_tp07.gif";
        iBtnRemove.Visible                  = false;

        TreeView2.Nodes.Clear();
    }

    private void StatusInfo() 
    {
        if (hdfStatus.Value == "N")
        {
            SetBlankStgVersion();
        }
        else if (hdfStatus.Value == "M")
        {
            SetStgVersion();

            LeftTreeBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            RightTreeBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        }
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions();

        if (hdfStatus.Value == "N")
        {
            pdtAhpVersion.AddPdtAhpVersion(ESTTERM_REF_ID, txtStgName.Text, txtStgDesc.Text, EMP_REF_ID);
        }
        else if (hdfStatus.Value == "M")
        {
            int ver_id = int.Parse(ddlStgVersion.SelectedValue);

            pdtAhpVersion.ModifyPdtAhpVersion(ver_id, ESTTERM_REF_ID, txtStgName.Text, txtStgDesc.Text, EMP_REF_ID);
        }

        StgVersionDropDownBinding();
        StatusInfo();
    }
    protected void iBtnRemove_Click(object sender, ImageClickEventArgs e)
    {
        int ver_id = int.Parse(ddlStgVersion.SelectedValue);

        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions();
        pdtAhpVersion.RemovePdtAhpVersion(ver_id, ESTTERM_REF_ID);

        StgVersionDropDownBinding();
        StatusInfo();
    }
    protected void ddlStgVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ver_id = int.Parse(ddlStgVersion.SelectedValue);

        if(ver_id == 0)
            hdfStatus.Value = "N";
        else
            hdfStatus.Value = "M";

        StatusInfo();
    }

    protected void TreeView1_NodeMoved(object sender, SJ.Web.UI.TreeViewNodeMovedEventArgs e)
    {
        if (e.Node.ParentNode == null)
        {
            //lblFeedback.Text = "Moved '" + e.Node.Text + "' into a root position.";
        }
        else if (e.Node.Text == "Droppable into Tasks Only" && e.Node.ParentNode.Text != "Tasks")
        {
            //lblFeedback.Text = "Can't move into '" + e.Node.ParentNode.Text + "'";
            //e.Node.ParentNode.Nodes.Remove(e.Node);
            //e.OldParent.Nodes.Add(e.Node);
        }
        else
        {
            //lblFeedback.Text = "Moved '" + e.Node.Text + "' into '" + e.Node.ParentNode.Text + "'";
        }
    }

    private void LeftTreeBinding(int estterm_ref_id)
    {
        TreeView1.Nodes.Clear();

        Biz_Bsc_Stg_Info stgInfo    = new Biz_Bsc_Stg_Info();
        DataSet ds                  = stgInfo.GetAllList(estterm_ref_id, "", "", "Y");

        if (ds.Tables[0].Rows.Count == 0)
            return;

        TreeViewNode newNode = null;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
        {
            newNode = CreateNode(ds.Tables[0].Rows[i]["STG_REF_ID"].ToString()
                                , ds.Tables[0].Rows[i]["STG_NAME"].ToString()
                                , "../images/tree/folder.gif"
                                , true);

            TreeView1.Nodes.Add(newNode);
        }
    }

    private void RightTreeBinding(int estterm_ref_id)
    {
        TreeView2.Nodes.Clear();

        Biz_PDTAndAHPStgInfos stgInfo   = new Biz_PDTAndAHPStgInfos();
        DataSet ds                      = stgInfo.GetPDTAndAHPStgInfo(PageUtility.GetIntByValueDropDownList(ddlStgVersion)
                                                , PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                , 0);

        TreeViewNode newNode = null;

        newNode             = CreateNode("0"
                                        , "<b>" + PageUtility.GetByTextDropDownList(ddlEstTermInfo) + " (" + PageUtility.GetByTextDropDownList(ddlStgVersion) + ")</b>"
                                        , "../images/tree/folder.gif"
                                        , true);

        TreeView2.Nodes.Add(newNode);

        if (ds.Tables[0].Rows.Count == 0)
            return;

        ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["STG_REF_ID"], ds.Tables[0].Columns["UP_STG_ID"], false);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (Convert.ToInt32(dbRow["UP_STG_ID"]) == 0)
            {
                newNode = CreateNode(dbRow["STG_REF_ID"].ToString()
                                    , dbRow["STG_NAME"].ToString()
                                    , "../images/tree/folder.gif"
                                    , true);
                TreeView2.Nodes[0].Nodes.Add(newNode);
                PopulateSubTree(dbRow, newNode);
            }
        }
    }

    private void PopulateSubTree(DataRow dbRow, SJ.Web.UI.TreeViewNode node)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            SJ.Web.UI.TreeViewNode childNode = CreateNode(childRow["STG_REF_ID"].ToString()
                                                        , childRow["STG_NAME"].ToString()
                                                        , "../images/tree/folder.gif"
                                                        , true);

            node.Nodes.Add(childNode);
            PopulateSubTree(childRow, childNode);
        }
    }

    private TreeViewNode CreateNode(string value, string text, string imageurl, bool expanded)
    {
        TreeViewNode node   = new TreeViewNode();
        node.Selectable     = true;
        node.Text           = text;
        node.Value          = value;
        node.ImageUrl       = imageurl;
        node.Expanded       = expanded;
        return node;
    }
    protected void iBtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        LeftTreeBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }
    protected void iBtnSetRel_Click(object sender, ImageClickEventArgs e)
    {
        Biz_PDTAndAHPStgInfos stgInfo = new Biz_PDTAndAHPStgInfos();

        DataTable treeData = new DataTable();
        treeData.Columns.Add("STG_REF_ID", typeof(int));
        treeData.Columns.Add("UP_STG_ID", typeof(int));
        treeData.Columns.Add("STG_MAP_YN", typeof(string));
        treeData.Columns.Add("F_YN", typeof(string));
        treeData.Columns.Add("C_YN", typeof(string));
        treeData.Columns.Add("P_YN", typeof(string));
        treeData.Columns.Add("L_YN", typeof(string));

        SaveDataTableTreeNode(ref treeData);

        bool isOK = stgInfo.AddPDTAndAHPStgInfo(PageUtility.GetIntByValueDropDownList(ddlStgVersion)
                                    , PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                    , treeData
                                    , EMP_REF_ID);
        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되었습니다.", false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.", false);
        }

        //GridView1.DataSource = treeData;
        //GridView1.DataBind();
    }

    public void SaveDataTableTreeNode(ref DataTable treeData)
    {
        DataRow dr = null;

        foreach (SJ.Web.UI.TreeViewNode treeNode in TreeView2.Nodes)
        {
            if (int.Parse(treeNode.Value) != 0) 
            {
                dr                  = treeData.NewRow();
                dr["STG_REF_ID"]    = int.Parse(treeNode.Value);
                dr["UP_STG_ID"]     = int.Parse(treeNode.ParentNode.Value);
                dr["STG_MAP_YN"]    = "N";
                dr["F_YN"]          = "N";
                dr["C_YN"]          = "N";
                dr["P_YN"]          = "N";
                dr["L_YN"]          = "N";

                treeData.Rows.Add(dr);
            }

            SaveSelfDataTableTreeNode(treeNode.Nodes, ref treeData);
        }
    }

    private void SaveSelfDataTableTreeNode(SJ.Web.UI.TreeViewNodeCollection nodeCol, ref DataTable treeData)
    {
        DataRow dr = null;

        foreach (SJ.Web.UI.TreeViewNode treeNode in nodeCol)
        {
            dr = treeData.NewRow();
            dr["STG_REF_ID"]    = int.Parse(treeNode.Value);
            dr["UP_STG_ID"]     = int.Parse(treeNode.ParentNode.Value);
            dr["STG_MAP_YN"]    = "N";
            dr["F_YN"]          = "N";
            dr["C_YN"]          = "N";
            dr["P_YN"]          = "N";
            dr["L_YN"]          = "N";
            treeData.Rows.Add(dr);

            SaveSelfDataTableTreeNode(treeNode.Nodes, ref treeData);
        }
    }
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ver_id = int.Parse(ddlStgVersion.SelectedValue);

        if(ver_id == 0)
            hdfStatus.Value = "N";
        else
            hdfStatus.Value = "M";

        StatusInfo();
    }
}
