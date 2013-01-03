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

public partial class ctl_ctl2106 : AppPageBase
{
    string DEPT_ID;

    int intEstTermID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();
        intEstTermID = GetRequestByInt("ESTTERM_REF_ID", 0);

        DEPT_ID = WebUtility.GetRequest("DEPT_ID", "");

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
        hdfObjKey.Value = GetRequest("OBJ_KEY", "");
        hdfObjVal.Value = GetRequest("OBJ_VAL", "");
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        //WebCommon.FillEstTree(TreeView1, intEstTermID, gUserInfo.Emp_Ref_ID);
        WebCommon.FillComDeptTree(TreeView1);

        if (DEPT_ID.Trim().Length > 0)
        {
            TreeView1.Enabled = false;
            SelectTreeNodeByValue(TreeView1.Nodes[0].ChildNodes, DEPT_ID);
            doBind_Emp(DEPT_ID);
        }
    }
    //리커시브 함수 
    private int SelectTreeNodeByValue(TreeNodeCollection childNode, string value)
    {
        int nodeCnt = childNode.Count;
        int flag;

        if (nodeCnt > 0)
        {
            for (int i = 0; i < childNode.Count; i++)
            {
                flag = SelectTreeNodeByValue(childNode[i].ChildNodes, value);
                
                if (flag==0)
                {
                    if (DataTypeUtility.GetString(childNode[i].Value).Equals(value))
                    {
                        childNode[i].Selected = true;
                        return -1;
                    }
                }
                else if (flag == -1)
                {
                    return -1;
                }
            }
        }

        return nodeCnt;
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
        doBind_Emp(deptId);
    }
    protected void doBind_Emp(string dept_ref_id)
    {
        UltraWebGrid1.DataSource = GetEmpInfoList(dept_ref_id);
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells.FromKey("SELECT").Value = "<img src='../images/drafts.gif' border='0'>";
    }

    #endregion
}
