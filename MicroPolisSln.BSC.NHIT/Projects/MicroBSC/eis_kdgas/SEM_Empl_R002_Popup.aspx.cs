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

public partial class eis_SEM_Empl_R002_Popup : EISPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            BuildTree();
        }
    }
    private void BuildTree()
    {
      string query = @"    SELECT DISTINCT 
                                  SEM_ORG_LEVEL, SEM_ORG_PATH,
                                  CM.SEM_CODE3_T,
                                  CM.SEM_CODE3_NAME,
                                  DECODE(CM.SEM_CODE2_T,CM.SEM_CODE3_T, NULL, CM.SEM_CODE2_T) SEM_CODE2_T
                             FROM SEM_CODE_MASTER CM,
                                  SEM_ORG_TABLE OT
                            WHERE CM.SEM_CODE1_T = '28'
                              AND CM.SEM_CODE3_T = OT.SEM_ORG_CODE2
                         ORDER BY SEM_ORG_LEVEL, SEM_ORG_PATH, SEM_CODE3_T, SEM_CODE2_T";

        DataSet ds = GetDataSet(query);

        ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["SEM_CODE3_T"], ds.Tables[0].Columns["SEM_CODE2_T"]);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (dbRow.IsNull("SEM_CODE2_T"))
            {
                SJ.Web.UI.TreeViewNode newNode = CreateNode(dbRow["SEM_CODE3_NAME"].ToString(), dbRow["SEM_CODE3_T"].ToString(), true);
                TreeView1.Nodes.Add(newNode);
                PopulateSubTree(dbRow, newNode);
            }
        }
    }
    private void PopulateSubTree(DataRow dbRow, SJ.Web.UI.TreeViewNode node)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            SJ.Web.UI.TreeViewNode childNode = CreateNode(childRow["SEM_CODE3_NAME"].ToString(), childRow["SEM_CODE3_T"].ToString(), false);
            node.Nodes.Add(childNode);
            PopulateSubTree(childRow, childNode);
        }
    }
    private SJ.Web.UI.TreeViewNode CreateNode(string text, string value, bool expanded)
    {
        SJ.Web.UI.TreeViewNode node = new SJ.Web.UI.TreeViewNode();
        node.Text = text;
        node.Value = value;
        node.ToolTip = text;
        //node.ImageUrl = imageurl;
        node.Expanded = expanded;
        return node;
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        DataTable dt = GetTeamInfo(dr["EMP_TEAM"].ToString());

        if (dt.Rows.Count > 0) 
        {
            e.Row.Cells.FromKey("edit").Value = string.Format(
                    "<a href=\"#null\" onclick=\"SetOpenerCtrl('{0}','{1}','{2}','{3}');\"><img src='../images/drafts.gif' border='0'></a>"
                    , dr["EMP_SABUN_T"].ToString(), dt.Rows[0]["SEM_CODE2_NAME"].ToString(), dt.Rows[0]["SEM_CODE3_NAME"].ToString(), dr["EMP_NAME"].ToString());
        }
    }
    protected void TreeView1_NodeSelected(object sender, SJ.Web.UI.TreeViewNodeEventArgs e)
    {
        DataGridBinding(e.Node.Value);
    }
    private void DataGridBinding(string emp_team) 
    {
        string query = @"SELECT * FROM SEM_EMPLOYEE_INFO WHERE EMP_TEAM = '" + emp_team + "'";
        DataSet ds = GetDataSet(query);
        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
    private DataTable GetTeamInfo(string emp_team)
    {
        string query = @"SELECT * FROM SEM_CODE_MASTER WHERE SEM_CODE1_T = '28' AND SEM_CODE3_T = '" + emp_team + "'";
        DataSet ds = GetDataSet(query);
        return ds.Tables[0];
    }
}
