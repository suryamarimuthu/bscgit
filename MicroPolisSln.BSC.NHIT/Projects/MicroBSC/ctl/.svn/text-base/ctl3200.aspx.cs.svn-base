using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Data;
using System.Text.RegularExpressions;

public partial class ctl3200 : AppPageBase
{
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebCommon.FillComDeptTree(TreeView2);
            iBtnCheck.Attributes.Add("onclick", "return selectChkBox(" + TreeView2.ClientID.Replace('$', '_') + ")");
        }

        ltrScript.Text = "";
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if(e.SelectedRows.Count > 0) 
        {
            iBtnAdd.Visible     = true;
            hdfEmpRefID.Value   = e.SelectedRows[0].Cells.FromKey("EMP_REF_ID").Value.ToString();

            WebCommon.FillEstOrgAuthorityTree(TreeView1, Convert.ToInt32(e.SelectedRows[0].Cells.FromKey("EMP_REF_ID").Value));
        }
    }

    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (hdfEmpRefID.Value.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("사원을 선택하세요.", false);
            return;
        }

        Biz_EmpComDeptDetails empComDeptDetail = new Biz_EmpComDeptDetails();
        TreeNodeCollection treeNodeCol  = TreeView1.CheckedNodes;
        int  intRnt = 0;
        bool blnRtn = empComDeptDetail.RemoveEmpComDeptDetail(int.Parse(hdfEmpRefID.Value));


        foreach (TreeNode node in treeNodeCol)
        {
            blnRtn = empComDeptDetail.AddEmpComDeptDetail(int.Parse(hdfEmpRefID.Value), int.Parse(node.Value), EMP_REF_ID);
            if (blnRtn)
            {
                intRnt += 1;
            }
        }

        ltrScript.Text = JSHelper.GetAlertScript(String.Format("총[{0}]건중 [{1}]건이 처리 되었습니다.", treeNodeCol.Count.ToString(), intRnt.ToString()), false);

        //IDbConnection conn = DbAgentHelper.CreateDbConnection();
        //conn.Open();
        //IDbTransaction trx = conn.BeginTransaction();

        //TreeNodeCollection treeNodeCol  = TreeView1.CheckedNodes;

        //try
        //{
        //    empComDeptDetail.RemoveEmpComDeptDetail(conn, trx, int.Parse(hdfEmpRefID.Value));

        //    foreach (TreeNode node in treeNodeCol)
        //    {
        //        if (!empComDeptDetail.AddEmpComDeptDetail(conn, trx, int.Parse(hdfEmpRefID.Value), int.Parse(node.Value), EMP_REF_ID))
        //        {
        //            trx.Rollback();
        //            break;
        //        }
        //    }

        //    trx.Commit();
        //}
        //catch (SqlException)
        //{
        //    trx.Rollback();
        //    conn.Close();
        //    return;
        //}
        //finally
        //{
        //    conn.Close();
        //}

        //ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되었습니다.", false);
    }

    protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
    {
        EmpInfos emp                = new EmpInfos();
        DataTable dt                = emp.GetEmpInfoByDeptID(TreeView2.SelectedValue).Tables[0];
        UltraWebGrid1.DataSource    = dt;
        UltraWebGrid1.DataBind();

        TreeView1.Nodes.Clear();
    }
}
