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
using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0801M1 : AppPageBase
{
    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetAllTimeTop();
        if (!IsPostBack)
        {
            this.InitControlValue();
        }
        else
        { 
        
        }
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }

    private void InitControlValue()
    {
        WebCommon.FillComDeptTree(trvComDept);
        WebCommon.SetEstTermDropDownList(ddlEstTerm);
        this.SetEstGroupGrid();
    }
    #endregion

    #region 내부함수
    private void TxrEstGroup()
    {
        if (txtGroupName.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("그룹명을 입력해 주십시오.",false);
            return;
        }
        //else if (hdfGroupRefID.Value.Trim() == "")
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("그룹을 선택해 주십시오.",false);
        //    return;
        //}

        Biz_Bsc_Validation_Group objBSC = new Biz_Bsc_Validation_Group();
        objBSC.Igroup_ref_id = (hdfGroupRefID.Value.ToString() == "") ? -1 : Convert.ToInt32(hdfGroupRefID.Value.ToString());
        objBSC.Igroup_name   = txtGroupName.Text;
        objBSC.Iuse_yn       = chkUseYn.Checked ? "Y" : "N";
        objBSC.Itxr_user     = gUserInfo.Emp_Ref_ID;

        int intRow = objBSC.UpdateData(objBSC.Igroup_ref_id
                                     , objBSC.Igroup_name
                                     , ""
                                     , objBSC.Iuse_yn
                                     , objBSC.Itxr_user);
        ltrScript.Text = objBSC.Transaction_Message;
        this.SetEstGroupGrid();
    }

    private void SetEstGroupGrid()
    {
        Biz_Bsc_Validation_Group objBSC = new Biz_Bsc_Validation_Group();
        DataSet rDs = objBSC.GetAllList();

        ugrdValuationGrid.Clear();
        ugrdValuationGrid.DataSource = rDs;
        ugrdValuationGrid.DataBind();
    }

    private void SetSelectedGroupList()
    { 
        Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        objBSC.Iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
        objBSC.Igroup_ref_id   = (hdfGroupRefID.Value == "") ? 0 : Convert.ToInt32(hdfGroupRefID.Value.ToString());

        DataSet rDs = objBSC.GetAllList(objBSC.Iestterm_ref_id, objBSC.Igroup_ref_id);

        ugrdSelectedGrid.Clear();
        ugrdSelectedGrid.DataSource = rDs;
        ugrdSelectedGrid.DataBind();
    }

    protected int AddUserToGroup()
    {
        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        bool isOK           = false;
        string isSuccessed  = "0";
        int intTxrUser      = gUserInfo.Emp_Ref_ID;
        int intRtn          = 0;
        int intRow          = ugrdTargetGrid.Rows.Count;

        Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        for (int i = 0; i < intRow; i++)
        {
            row = ugrdTargetGrid.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;

                objBSC.Iemp_ref_id          = Convert.ToInt32(row.Cells.FromKey("EMP_REF_ID").Value.ToString());
                objBSC.Iestterm_ref_id      = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
                objBSC.Igroup_ref_id        = (hdfGroupRefID.Value=="") ? 0 : Convert.ToInt32(hdfGroupRefID.Value.ToString());
                objBSC.Iuse_yn              = "Y";
                objBSC.Itxr_user            = intTxrUser;
                objBSC.Idescriptions        = "";

                intRtn += objBSC.InsertData(objBSC.Iestterm_ref_id
                                          , objBSC.Igroup_ref_id
                                          , objBSC.Iemp_ref_id
                                          , objBSC.Idescriptions
                                          , objBSC.Iuse_yn
                                          , objBSC.Itxr_user);
            }
        }

        return intRtn;
    }

    protected int RemoveUserFromGroup()
    {
        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        bool isOK           = false;
        string isSuccessed  = "0";
        int intTxrUser      = gUserInfo.Emp_Ref_ID;
        int intRtn          = 0;
        int intRow          = ugrdSelectedGrid.Rows.Count;

        Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        for (int i = 0; i < intRow; i++)
        {
            row = ugrdSelectedGrid.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;

                objBSC.Iestterm_ref_id      = Convert.ToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                objBSC.Igroup_ref_id        = Convert.ToInt32(row.Cells.FromKey("GROUP_REF_ID").Value.ToString());
                objBSC.Iemp_ref_id          = Convert.ToInt32(row.Cells.FromKey("EMP_REF_ID").Value.ToString());
                objBSC.Itxr_user            = intTxrUser;

                intRtn += objBSC.DeleteData(objBSC.Iestterm_ref_id
                                          , objBSC.Igroup_ref_id
                                          , objBSC.Iemp_ref_id
                                          , objBSC.Itxr_user);
            }
        }

        return intRtn;
    }

    #endregion

    #region 서버 이벤트 처리 함수

    protected void trvComDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptId               = trvComDept.SelectedNode.Value;

        EmpInfos emp                = new EmpInfos();
        DataSet rDs                 = emp.GetEmpInfoByDeptID(deptId);

        ugrdTargetGrid.DataSource   = rDs;
        ugrdTargetGrid.DataBind();

        //lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
    }

    protected void iBtnRemoveEmp_Click(object sender, ImageClickEventArgs e)
    {
        this.RemoveUserFromGroup();
        this.SetSelectedGroupList();
    }
    protected void iBtnAddEmp_Click(object sender, ImageClickEventArgs e)
    {
        if ((hdfGroupRefID.Value == "") || (txtGroupName.Text == ""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("그룹을 선택해주십시오.", false);
            return;
        }

        int cntAffRow = this.AddUserToGroup();
        this.SetSelectedGroupList();
    }
    protected void iBtnAddGroup_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrEstGroup();
    }

    protected void iBtnClrGroup_Click(object sender, ImageClickEventArgs e)
    {
        this.hdfGroupRefID.Value  = "";
        this.txtGroupName.Text    = "";
        this.lblEstGroupName.Text = "";
        chkUseYn.Checked          = false;
    }
    protected void ugrdValuationGrid_ActiveRowChange(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        this.hdfGroupRefID.Value  = (e.Row.Cells.FromKey("GROUP_REF_ID").Value == null) ? "" : (e.Row.Cells.FromKey("GROUP_REF_ID").Value.ToString());
        this.txtGroupName.Text    = (e.Row.Cells.FromKey("GROUP_NAME").Value == null) ? "" : (e.Row.Cells.FromKey("GROUP_NAME").Value.ToString());
        string strCheck           = (e.Row.Cells.FromKey("USE_YN").Value == null) ? "N" : (e.Row.Cells.FromKey("USE_YN").Value.ToString());
        chkUseYn.Checked          = (strCheck == "Y") ? true : false;
        this.lblEstGroupName.Text = this.txtGroupName.Text;
        this.SetSelectedGroupList();
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetSelectedGroupList();
    }
    #endregion
}
    