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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

// 제    목 : 부서 선택 페이지
// 내    용 : 쿼리스트링의 옵션값에 의해서 싱글/멀티 선택이 가능함
//            해당 부서는 평가부서가 아닌 인사부서            
public partial class EST_EST_EMP : EstPageBase
{
    public string CTRL_DEPT_VALUE_NAME;
    public string CTRL_DEPT_TEXT_NAME;
    public string CTRL_EMP_VALUE_NAME;
    public string CTRL_EMP_TEXT_NAME;
    public int SELECT_DEPT_REF_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID      = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        CTRL_DEPT_VALUE_NAME= WebUtility.GetRequest("CTRL_DEPT_VALUE_NAME");
        CTRL_DEPT_TEXT_NAME = WebUtility.GetRequest("CTRL_DEPT_TEXT_NAME");
        CTRL_EMP_VALUE_NAME = WebUtility.GetRequest("CTRL_EMP_VALUE_NAME");
        CTRL_EMP_TEXT_NAME  = WebUtility.GetRequest("CTRL_EMP_TEXT_NAME");
        SELECT_DEPT_REF_ID  = WebUtility.GetRequestByInt("SELECT_DEPT_REF_ID");

        if (!Page.IsPostBack)
        {
            TreeViewCommom.BindDept(TreeView1);

            if(SELECT_DEPT_REF_ID != 0) 
            {
                TreeViewCommom.SelectTreeNode(TreeView1, SELECT_DEPT_REF_ID);
                BindEmpInfoList(DataTypeUtility.GetToInt32(TreeView1.SelectedValue));
            }
        }

        ltrScript.Text = "";
    }

    private void BindEmpInfoList(int dept_ref_id)
    {
        Biz_EmpInfos empInfo = new Biz_EmpInfos();

        DataSet ds                  = empInfo.GetEmpByEstDeptID(dept_ref_id);
        UltraWebGrid1.DataSource    = ds;
        UltraWebGrid1.DataBind();

        lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        BindEmpInfoList(DataTypeUtility.GetToInt32(TreeView1.SelectedValue));
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;

        string deptId   = e.Row.Cells.FromKey("DEPT_REF_ID").Value.ToString();
        string deptName = e.Row.Cells.FromKey("DEPT_NAME").Value.ToString();
        string empId    = e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString();
        string empName  = e.Row.Cells.FromKey("EMP_NAME").Value.ToString();

        e.Row.Cells.FromKey("SELECT").Value = string.Format(
                            "<a href=\"#\" onclick=\"SetValue('{0}', '{1}', '{2}', '{3}');\"><img src='../images/drafts.gif' border='0'></a>", deptId, deptName, empId, empName);

        

    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }
}
