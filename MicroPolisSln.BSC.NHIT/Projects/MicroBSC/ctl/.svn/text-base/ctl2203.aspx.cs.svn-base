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

public partial class usr_usr2203 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            //WebCommon.FillComDeptTree(TreeView1);
            WebCommon.FillComDeptTree(TreeView1);
        }
    }

    private DataSet GetEmpInfoList(string dept_ref_id) 
    {
        EmpInfos emp = new EmpInfos();
        return emp.GetEmpInfoByDeptID(dept_ref_id);
    }
    
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptId = TreeView1.SelectedNode.Value;
        UltraWebGrid1.DataSource = GetEmpInfoList(deptId);
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        string empId = e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString();
        string empName = e.Row.Cells.FromKey("EMP_NAME").Value.ToString();

        e.Row.Cells.FromKey("SELECT").Value = string.Format(
            "<a href=\"#null\" onclick=\"openwindow('{0}', '{1}');\"><img src='../images/drafts.gif' border='0'></a>", empId, empName);

        if (!dr["SIGN_PATH"].ToString().Trim().Equals(""))
            e.Row.Cells.FromKey("SIGN_PATH").Value = string.Format(
                "<img src='{0}' border='0' width='100%' height='100%'>", "../" + System.Configuration.ConfigurationManager.AppSettings["EmpInfo.UploadImages.Sign"] + "/" + dr["SIGN_PATH"].ToString());
        else
            e.Row.Cells.FromKey("SIGN_PATH").Value = "";

        if (!dr["STAMP_PATH"].ToString().Trim().Equals(""))
            e.Row.Cells.FromKey("STAMP_PATH").Value = string.Format(
                "<img src='{0}' border='0' width='100%' height='100%'>", "../" + System.Configuration.ConfigurationManager.AppSettings["EmpInfo.UploadImages.Stamp"] + "/" + dr["STAMP_PATH"].ToString());
        else
            e.Row.Cells.FromKey("STAMP_PATH").Value = "";
    }
}
