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
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class usr_usr2202 : AppPageBase
{
    string biz_type_code;
    int EmpID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!Page.IsPostBack)
        {
            //WebCommon.FillComDeptTree(TreeView1);
            WebCommon.FillComDeptTree(TreeView1);
            
            SetBizTypeName();

            if (WebUtility.GetRequest("mode").Equals("New"))
            {
                ltrEmpButton.Text = "<a href='#null' onclick=\"gfOpenWindow('ctl2203.aspx', 700, 400);\"><img src=\"../images/btn/b_008.gif\" align=\"middle\" border=\"0\"/></a>";
            }
            else 
            {
                DataLoad();
            }
        }
        SetAllTimeBottom();
        
    }


    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        biz_type_code = (Request["biz_type_code"] != null && Request["biz_type_code"].Length > 0) ? Request["biz_type_code"] : "";
        EmpID = (Request["EmpID"] != null && Request["EmpID"].Length > 0) ? int.Parse(Request["EmpID"]) : 0;

        if (biz_type_code != null && biz_type_code.Length > 0 && EmpID > 0)
        { }
        else
        {
            Literal1.Text = JSHelper.GetAlertScript("잘못 된 경로로 접근하셨습니다.", true);
        }

        EmpInfos emp = new EmpInfos(EmpID);
        txtEmpID.Text = EmpID.ToString();
        txtEmpName.Text = emp.Emp_Name;

    }

    protected void Page_PreRender(object sender, EventArgs e) 
    {
        if (!Page.IsPostBack) 
        {
            ibtnDelete.Attributes.Add("onclick", "return confirm('선택하신 항목을 삭제할까요?');");
        }
    }

    private DataSet GetEmpInfoList(string dept_ref_id)
    {
        EmpInfos emp = new EmpInfos();
        return emp.GetEmpInfoByDeptID(dept_ref_id);
    }

    private void SetBizTypeName() 
    {
        BizInfos biz = new BizInfos(biz_type_code);
        lblBizTypeName.Text = biz.Biz_Type_Name;
    }

    private void SetAllTimeBottom()
    {
        Literal1.Text = "";
    }
    #endregion

    #region 내부함수
    private void DataLoad()
    {
        ApprovalLines app = new ApprovalLines();
        UltraWebGrid2.DataSource = app.GetApprovalLine(biz_type_code, EmpID);
        UltraWebGrid2.DataBind();

    }
    #endregion

    #region 서버 이벤트 처리 함수
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptId = TreeView1.SelectedNode.Value;
        UltraWebGrid1.DataSource = GetEmpInfoList(deptId);
        UltraWebGrid1.DataBind();
    }
    protected void ibtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        bool isDupId = false;
        int grid1_rowcnt = UltraWebGrid1.Rows.Count;
        int grid2_rowcnt = UltraWebGrid2.Rows.Count;

        CheckBox chk;
        Infragistics.WebUI.UltraWebGrid.UltraGridRow row;
        Infragistics.WebUI.UltraWebGrid.TemplatedColumn col;

        for (int i = 0; i < grid1_rowcnt; i++)
        {
            row = this.UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk1");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("selchk1");

            if (chk.Checked)
            {
                for (int j = 0; j < grid2_rowcnt; j++)
                {
                    if (UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("APP_EMP_ID").Value.Equals(row.Cells.FromKey("EMP_REF_ID").Value))
                    {
                        isDupId = true;
                        break;
                    }
                }

                // 동일한 사용자가 선택되지 않았다면 결재선 지정에 추가함
                if (!isDupId)
                {
                    // 결재선 그리드 레코드 갯수 하나 추가
                    grid2_rowcnt++;

                    // 결재선 지정 그리드에 추가
                    UltraWebGrid2.Rows.Add();

                    // 사용자이름
                    UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("APP_STEP").Value = grid2_rowcnt;
                    UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("EMP_NAME").Value = row.Cells.FromKey("EMP_NAME").Value;
                    UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("DEPT_NAME").Value = row.Cells.FromKey("DEPT_NAME").Value;
                    UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("POSITION_NAME").Value = row.Cells.FromKey("POSITION_NAME").Value;
                    UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("APP_EMP_ID").Value = row.Cells.FromKey("EMP_REF_ID").Value;
                    UltraWebGrid2.Rows[grid2_rowcnt - 1].Cells.FromKey("BIZ_TYPE_CODE").Value = Request["BIZ_TYPE_CODE"];

                    // 선택항목 사용자 제거
                    UltraWebGrid1.Rows.Remove(row);
                    // 레코드 갯수 하나 삭제
                    grid1_rowcnt--;
                    // 일련번호 갯수 하나 삭제
                    i--;
                }
            }
        }
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int chkcnt = 0;
        int grid2_rowcnt = this.UltraWebGrid2.Rows.Count;

        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        for (int i = 0; i < grid2_rowcnt; i++)
        {
            row = this.UltraWebGrid2.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk2");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("selchk2");

            if (chk.Checked)
            {
                chkcnt++;
                // 선택항목 사용자 제거
                this.UltraWebGrid2.Rows.Remove(row);
                // 레코드 갯수 하나 삭제
                grid2_rowcnt--;
                // 일련번호 갯수 하나 삭제
                i--;
            }
        }

        grid2_rowcnt = this.UltraWebGrid2.Rows.Count;
        for (int i = 0; i < grid2_rowcnt; i++)
        {
            row = this.UltraWebGrid2.Rows[i];
            row.Cells[1].Value = i + 1;

        }

        if (chkcnt <= 0)
            Literal1.Text = JSHelper.GetAlertOpenerReflashScript("삭제할 항목을 선택해 주세요.", false);
    }

    protected void ibtnRemove_Click(object sender, ImageClickEventArgs e)
    {
        bool isRemoved = false;
        ApprovalLines app = new ApprovalLines();
        isRemoved = app.RemoveApprovalLine(biz_type_code, EmpID);

        if (!isRemoved)
            Literal1.Text = JSHelper.GetAlertScript("삭제할 결제선이 없습니다.", false);
        else
        {
            Literal1.Text = JSHelper.GetAlertOpenerControlCallBackScript("결제선이 삭제 되었습니다.", "ibtnSearch", false);
        }
        DataLoad();
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        bool isSuccessed = false;
        int grid2_rowcnt = this.UltraWebGrid2.Rows.Count;
        UltraGridRow row;

        ApprovalLines app = null;

        if (txtEmpID.Text != null && txtEmpID.Text.Length > 0)
        {

            //if (Request["mode"].Equals("New"))
            //{
                for (int i = 0; i < grid2_rowcnt; i++)
                {
                    app = new ApprovalLines();
                    row = this.UltraWebGrid2.Rows[i];
                    isSuccessed = app.AddApprovaLline(
                        (int)row.Cells.FromKey("APP_STEP").Value
                        , (string)row.Cells.FromKey("BIZ_TYPE_CODE").Value
                        , int.Parse(txtEmpID.Text)
                        , (int)row.Cells.FromKey("APP_EMP_ID").Value);
                }

                if (isSuccessed)
                    Literal1.Text = JSHelper.GetAlertOpenerControlCallBackScript("결재선 지정이 완료되었습니다.", "ibtnSearch", true);
                else
                    Literal1.Text = JSHelper.GetAlertOpenerReflashScript("결재선 지정 시 오류가 발생하였습니다.", false);
            // 이하 부분 2006-06-21 박면 수정 작업 했음

            //}
            /*else if (Request["mode"].Equals("Modify"))
            {
                app = new ApprovalLines();
                bool isRemoved = app.RemoveApprovalLine(Request["biz_type_code"], int.Parse(Request["EmpID"]));

                if (isRemoved)
                {
                    for (int i = 0; i < grid2_rowcnt; i++)
                    {
                        app = new ApprovalLines();
                        row = this.UltraWebGrid2.Rows[i];
                        isSuccessed = app.AddApprovaLline(
                            (int)row.Cells.FromKey("APP_STEP").Value
                            , (string)row.Cells.FromKey("BIZ_TYPE_CODE").Value
                            , int.Parse(txtEmpID.Text)
                            , (int)row.Cells.FromKey("APP_EMP_ID").Value);
                    }

                    if (isSuccessed)
                        Literal1.Text = JSHelper.GetAlertOpenerReflashScript("수정이 완료되었습니다.", true);
                    else
                        Literal1.Text = JSHelper.GetAlertOpenerReflashScript("수정 중 실패 하였습니다.", false);

                    return;
                }
                else
                {
                    Literal1.Text = JSHelper.GetAlertOpenerReflashScript("수정 중 실패 하였습니다.", false);
                }
            }*/
        }
        else 
        {
            Literal1.Text = JSHelper.GetAlertOpenerReflashScript("결재 승인자를 선택하여야 합니다.", false);
        }
    }
    #endregion

}
