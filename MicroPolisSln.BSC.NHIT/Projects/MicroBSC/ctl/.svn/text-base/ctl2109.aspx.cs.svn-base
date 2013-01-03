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
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class ctl_ctl2109 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }

    #region 페이지 초기화 함수

    private void SetAllTimeTop()
    {

    }

    private void InitControlValue()
    {
        strDeptKey.Value = GetRequest("DEPT_KEY", "");
        strDeptVal.Value = GetRequest("DEPT_VAL", "");
        strEmpKey.Value = GetRequest("EMP_KEY", "");
        strEmpVal.Value = GetRequest("EMP_VAL", "");
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        WebCommon.FillComDeptTree(TreeView1);
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    #endregion

    #region 내부함수

    private DataSet GetEmpInfoList(string dept_ref_id)
    {
        EmpInfos emp = new EmpInfos();
        return emp.GetEmpInfoByDeptID(dept_ref_id);
    }


    #endregion

    #region 서버 이벤트 처리 함수

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptId = TreeView1.SelectedNode.Value;
        UltraWebGrid1.DataSource = GetEmpInfoList(deptId);
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        string deptId = e.Row.Cells.FromKey("DEPT_REF_ID").Value.ToString();
        string deptName = e.Row.Cells.FromKey("DEPT_NAME").Value.ToString();
        string empId = e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString();
        string empName = e.Row.Cells.FromKey("EMP_NAME").Value.ToString();

        e.Row.Cells.FromKey("SELECT").Value = string.Format(
                            "<a href=\"#\" onclick=\"SetValue('{0}', '{1}', '{2}', '{3}');\"><img src='../images/drafts.gif' border='0'></a>", deptId, deptName, empId, empName);
     
    }

    #endregion
}
