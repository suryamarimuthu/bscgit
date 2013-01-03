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
using MicroBSC.Common;
using Infragistics.WebUI.UltraWebGrid;

public partial class ctl_ctl2200 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout);

        if (!Page.IsPostBack)
        {
            WebCommon.SetBizInfoDropDownList(ddlBizInfoList,false);
            //ApprovalDatabind(ddlBizInfoList, "", 0);
        }
        SetAllTimeBottom();
    }
    #region 페이지 초기화 함수

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ibtnDelete.Attributes.Add("onclick", "return confirm('선택하신 항목을 삭제할까요?');");
    }

    private void SetAllTimeBottom()
    {
        Literal1.Text = "";
    }

    #endregion
    
    #region 내부함수
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        string empid = dr["REP_EMP_ID"].ToString();
        string bizCode = dr["BIZ_TYPE_CODE"].ToString();
        e.Row.Cells.FromKey("MODIFY").Value
            = string.Format("<a href=\"#\" onclick=\"openwindow_updateUser('Modify', '{0}', '{1}');\"><img src='../images/drafts.gif' border='0'></a>", empid, bizCode);
    }
    #endregion
    
    #region 서버 이벤트 처리 함수
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //수정 박면 int.Parse(ddlPosition.SelectedValue),
        ApprovalDatabind(ddlBizInfoList.SelectedValue, txtEmpName.Text, (txtDeptID.Text.Equals("")) ? 0 : int.Parse(txtDeptID.Text));
    }

    private void ApprovalDatabind(string biz_type_code, string empName, int deptId)
    {
        //파라메터에 존재 했던 내용 int positionId (수정 박면)
        ApprovalLines app = new ApprovalLines();
        UltraWebGrid1.DataSource = app.ApprovalLineEmpList(biz_type_code, empName, deptId);
        UltraWebGrid1.DataBind();
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ApprovalLines app = new ApprovalLines();
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isRemoved = false;
        for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("selchk");

            if (chk.Checked)
            {
                isRemoved = app.RemoveApprovalLine(row.Cells.FromKey("BIZ_TYPE_CODE").Value.ToString(), (int)row.Cells.FromKey("REP_EMP_ID").Value);
            }
        }

        if (!isRemoved)
            Literal1.Text = JSHelper.GetAlertScript("삭제할 결제선을 선택해 주세요.", false);
        else
        {
            Literal1.Text = JSHelper.GetAlertScript("결제선이 삭제 되었습니다.", false);
            ApprovalDatabind(ddlBizInfoList.SelectedValue, txtEmpName.Text, (txtDeptID.Text.Equals("")) ? 0 : int.Parse(txtDeptID.Text));
        }
    }
    #endregion
}
