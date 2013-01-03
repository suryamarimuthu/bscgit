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
using System.Drawing;
using System.Collections.Specialized;

using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0902M1 : AppPageBase
{
    #region ==========================[변수선언]================
    public string IBIZ_TYPE
    {
        get
        {
            if (ViewState["BIZ_TYPE"] == null)
            {
                ViewState["BIZ_TYPE"] = GetRequest("BIZ_TYPE", "");
            }

            return (string)ViewState["BIZ_TYPE"];
        }
        set
        {
            ViewState["BIZ_TYPE"] = value;
        }
    }
    private string IDEPT_VALUE
    {
        get
        {
            if (ViewState["DEPT_VALUE"] == null)
                ViewState["DEPT_VALUE"] = "";
            return (string)ViewState["DEPT_VALUE"];
        }
        set
        {
            ViewState["DEPT_VALUE"] = value;
        }
    }
    #endregion

    #region ==========================[초 기 화]================
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            WebCommon.FillComDeptTree(trvDept);
            trvDept.Attributes.Add("onclick", "visibleLoading();");

            Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
            DataSet rDs = objCode.GetApprovalBizType(0);

            ddlWorkType.DataValueField = "ETC_CODE";
            ddlWorkType.DataTextField = "CODE_NAME";
            ddlWorkType.DataSource = rDs;
            ddlWorkType.DataBind();

            ddlWorkType.Items.Insert(0, new ListItem(":: 선택 ::", ""));

            this.Page.Form.Style.Add("height", "100%");

            //ibtnAdd1.Enabled = ibtnAdd2.Enabled = ibtnAdd3.Enabled = ibtnDel1.Enabled = ibtnDel2.Enabled = ibtnDel3.Enabled = false;            
        }
        DoHiddenLoading();
    }
    #endregion

    #region ==========================[내부함수]================
    /// <summary>
    /// 결재 업무유형 지정
    /// </summary>
    public void DoInitControl()
    {
        ugrdFixEmp.Clear();
        ugrdSignerEmp.Clear();
        ugrdDraftEmp.Clear();
        ugrdEmpList.Clear();

        //if (this.IBIZ_TYPE.Equals(""))
        //    ibtnAdd1.Enabled = ibtnAdd2.Enabled = ibtnAdd3.Enabled = ibtnDel1.Enabled = ibtnDel2.Enabled = ibtnDel3.Enabled = false;
        //else
        //    ibtnAdd1.Enabled = ibtnAdd2.Enabled = ibtnAdd3.Enabled = ibtnDel1.Enabled = ibtnDel2.Enabled = ibtnDel3.Enabled = true;
    }


    #endregion

    #region ==========================[이 벤 트]================
    /// <summary>
    /// 트리변경시 사용자검색
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void trvDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeNode trnDept = trvDept.SelectedNode;
        this.IDEPT_VALUE = "";
        if (trnDept != null)
        {
            string strDeptNm = trnDept.Text;
            string strDeptID = trnDept.Value;
            this.IDEPT_VALUE = strDeptID;
            DoBindingEmp();
        }
    }

    private void DoBindingEmp()
    {
        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        DataTable dtAppEmp = bizComApp.GetEmpList(this.IBIZ_TYPE, this.IDEPT_VALUE);

        ugrdEmpList.Clear();
        ugrdEmpList.DataSource = dtAppEmp;
        ugrdEmpList.DataBind();
    }

    protected void ddlWorkType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IBIZ_TYPE = ddlWorkType.SelectedItem.Value;
        DoInitControl();
        DoBinding();
        ugrdEmpList.Clear();
        TreeNode trn = trvDept.SelectedNode;
        if (trn != null)
            trvDept.FindNode(trvDept.SelectedNode.ValuePath).Selected = false;
    }

    private void DoBinding()
    {
        Biz_Com_Approval_Info bizApp = new Biz_Com_Approval_Info();
        DataTable dtApp = bizApp.GetBaseAppList(this.IBIZ_TYPE);
        ugrdFixEmp.DataSource = dtApp;
        ugrdFixEmp.DataBind();
    }
    protected void ibtnUp1_Click(object sender, ImageClickEventArgs e)
    {
        DoBaseSortChange(true);
    }
    protected void ibtnUp2_Click(object sender, ImageClickEventArgs e)
    {
        DoLineSortChange(true);
    }
    protected void ibtnDown1_Click(object sender, ImageClickEventArgs e)
    {
        DoBaseSortChange(false);
    }

    private void DoLineSortChange(bool isUp)
    {
        int app_emp_ref_id = DataTypeUtility.GetToInt32(ugrdSignerEmp.DisplayLayout.SelectedRows[0].Cells.FromKey("EMP_REF_ID"));
        object[] objDraftEmp = new object[ugrdDraftEmp.Rows.Count];
        objDraftEmp = GetInsertDraftEmpList(ugrdDraftEmp.Rows.Count);

        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        if (bizComApp.ChangeLineSort(this.IBIZ_TYPE, isUp, objDraftEmp, app_emp_ref_id, gUserInfo.Emp_Ref_ID))
        {
            int sort_order = (isUp ? DataTypeUtility.GetToInt32(ugrdSignerEmp.DisplayLayout.SelectedRows[0].Cells.FromKey("SORT_ORDER")) - 1 : DataTypeUtility.GetToInt32(ugrdSignerEmp.DisplayLayout.SelectedRows[0].Cells.FromKey("SORT_ORDER")) + 1);
            if (isUp)
                ugrdSignerEmp.Rows[ugrdSignerEmp.DisplayLayout.SelectedRows[0].Index - 1].Cells.FromKey("SORT_ORDER").Value = sort_order + 1;
            else
                ugrdSignerEmp.Rows[ugrdSignerEmp.DisplayLayout.SelectedRows[0].Index + 1].Cells.FromKey("SORT_ORDER").Value = sort_order - 1;

            ugrdSignerEmp.DisplayLayout.SelectedRows[0].Cells.FromKey("SORT_ORDER").Value = sort_order;
            ugrdSignerEmp.Bands[0].SortedColumns.Clear();
            ugrdSignerEmp.Columns.FromKey("SORT_ORDER").SortIndicator = SortIndicator.Ascending;
            ugrdSignerEmp.Bands[0].SortedColumns.Add(ugrdSignerEmp.Columns.FromKey("SORT_ORDER"), true);
            DoFocusLine(ugrdSignerEmp, app_emp_ref_id);
        }
        else
            MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
    }

    private void DoHiddenLoading()
    {
        string guidKey = Guid.NewGuid().ToString();
        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), guidKey, "hideLoading();", true);
    }

    private void DoBaseSortChange(bool isUp)
    {
        int emp_ref_id = DataTypeUtility.GetToInt32(ugrdFixEmp.DisplayLayout.SelectedRows[0].Cells.FromKey("EMP_REF_ID"));
        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        if (bizComApp.ChangeBaseSort(this.IBIZ_TYPE, isUp, emp_ref_id, gUserInfo.Emp_Ref_ID))
        {
            DoBinding();
            DoFocusLine(ugrdFixEmp, emp_ref_id);
        }
        else
            MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
    }

    private void DoFocusLine(UltraWebGrid ugrd, int emp_ref_id)
    {
        foreach (UltraGridRow gr in ugrd.Rows)
        {
            if (DataTypeUtility.GetToInt32(gr.Cells.FromKey("EMP_REF_ID")) == emp_ref_id)
            {
                gr.Selected = true;
                gr.Activate();
                return;
            }
        }
    }

    protected void ibtnDown2_Click(object sender, ImageClickEventArgs e)
    {
        DoLineSortChange(false);
    }

    protected void ibtnAdd1_Click(object sender, ImageClickEventArgs e)
    {
        DoInsertEmp(ugrdEmpList, ugrdFixEmp);
        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        int objCount = GetEmpCount(ugrdEmpList);
        object[,] objAppEmp = new object[objCount, 2];
        objAppEmp = GetInsertEmpList(ugrdFixEmp, objCount);

        if (bizComApp.InsertFixEmp(this.IBIZ_TYPE, objAppEmp, gUserInfo.Emp_Ref_ID))
            MsgOnUP(UpdatePanel1, "추가하였습니다.");
        else
        {
            DoDeleteEmp(ugrdFixEmp, objCount);
            MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
        }
    }
    protected void ibtnAdd2_Click(object sender, ImageClickEventArgs e)
    {
        DoInsertEmp(ugrdEmpList, ugrdSignerEmp);
        if (ugrdDraftEmp.Rows.Count > 0)
        {
            Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
            int objCount = GetEmpCount(ugrdEmpList);
            object[,] objAppEmp = new object[objCount, 2];
            objAppEmp = GetInsertEmpList(ugrdSignerEmp, objCount);

            object[] objDraftEmp = new object[ugrdDraftEmp.Rows.Count];
            objDraftEmp = GetInsertDraftEmpList(ugrdDraftEmp.Rows.Count);
            if (bizComApp.InsertAppEmp(this.IBIZ_TYPE, objDraftEmp, objAppEmp, gUserInfo.Emp_Ref_ID))
                MsgOnUP(UpdatePanel1, "추가하였습니다.");
            else
            {
                DoDeleteEmp(ugrdSignerEmp, objCount);
                MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
                return;
            }
        }
        DoBindingEmp();
    }
    protected void ibtnAdd3_Click(object sender, ImageClickEventArgs e)
    {
        DoInsertEmp(ugrdEmpList, ugrdDraftEmp);
        if (ugrdSignerEmp.Rows.Count > 0)
        {
            Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
            int objCount = GetEmpCount(ugrdEmpList);
            object[,] objAppEmp = new object[ugrdSignerEmp.Rows.Count, 2];
            objAppEmp = GetInsertEmpList(ugrdSignerEmp, 0);

            object[] objDraftEmp = new object[objCount];
            objDraftEmp = GetInsertDraftEmpList(objCount);
            if (bizComApp.InsertAppEmp(this.IBIZ_TYPE, objDraftEmp, objAppEmp, gUserInfo.Emp_Ref_ID))
                MsgOnUP(UpdatePanel1, "추가하였습니다.");
            else
            {
                DoDeleteEmp(ugrdDraftEmp, objCount);
                MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
                return;
            }
        }
        DoBindingEmp();
    }

    protected void ibtnInit_Click(object sender, ImageClickEventArgs e)
    {
        ugrdDraftEmp.Clear();
        ugrdSignerEmp.Clear();
    }

    private void DoDeleteEmp(UltraWebGrid ugrdDel, int delCount)
    {
        //for (int i = ugrdDel.Rows.Count - 1; i < delCount; i++)
        //{
        //    ugrdDel.Rows[ugrdDel.Rows.Count - 1].Delete();
        //}
        int j = ugrdDel.Rows.Count;
        for (int i = ugrdDel.Rows.Count - 1; i > j - delCount - 1; i--)
        {
            ugrdDel.Rows[i].Delete();
        }
    }

    private void DoInsertEmp(UltraWebGrid ugrdOrg, UltraWebGrid ugrdDes)
    {
        TemplatedColumn col_Check;
        foreach (UltraGridRow gr in ugrdOrg.Rows)
        {
            col_Check = (TemplatedColumn)gr.Cells.FromKey("selchk").Column;
            if (((CheckBox)((CellItem)col_Check.CellItems[gr.BandIndex]).FindControl("cBox")).Checked)
            {
                UltraGridRow insertGR = new UltraGridRow();
                ugrdDes.Rows.Insert(ugrdDes.Rows.Count, insertGR);
                insertGR.Cells.FromKey("COM_DEPT_NAME").Value = gr.Cells.FromKey("DEPT_NAME").Value;
                insertGR.Cells.FromKey("EMP_NAME").Value = gr.Cells.FromKey("EMP_NAME").Value;
                insertGR.Cells.FromKey("POSITION_CLASS_NAME").Value = gr.Cells.FromKey("POSITION_CLASS_NAME").Value;
                insertGR.Cells.FromKey("EMP_REF_ID").Value = gr.Cells.FromKey("EMP_REF_ID").Value;
                if (ugrdDes.Columns.Exists("SORT_ORDER"))
                    insertGR.Cells.FromKey("SORT_ORDER").Value = GetSortOrder(ugrdDes);
            }
        }
    }

    private void DoDeleteEmp(UltraWebGrid ugrd)
    {
        TemplatedColumn col_Check;
        //foreach (UltraGridRow gr in ugrd.Rows)
        //{
        //    col_Check = (TemplatedColumn)gr.Cells.FromKey("selchk").Column;
        //    if (((CheckBox)((CellItem)col_Check.CellItems[gr.BandIndex]).FindControl("cBox")).Checked)
        //    {
        //        gr.Delete();
        //    }
        //}
        for (int i = ugrd.Rows.Count - 1; i >= 0; i--)
        {
            UltraGridRow gr = ugrd.Rows[i];
            col_Check = (TemplatedColumn)gr.Cells.FromKey("selchk").Column;
            if (((CheckBox)((CellItem)col_Check.CellItems[gr.BandIndex]).FindControl("cBox")).Checked)
            {
                gr.Delete();
            }
        }
    }

    private void SetSortOrder(UltraWebGrid ugrd)
    {
        for (int i = 0; i < ugrd.Rows.Count; i++)
        {
            if (DataTypeUtility.GetToInt32(ugrd.Rows[i].Cells.FromKey("SORT_ORDER").Value) != i + 1)
                ugrd.Rows[i].Cells.FromKey("SORT_ORDER").Value = i + 1;
        }
    }

    private object[,] GetInsertEmpList(UltraWebGrid ugrd, int addedCount)
    {
        object[,] objEmp = new object[(addedCount == 0 ? ugrd.Rows.Count : addedCount), 2];
        for (int i = (addedCount == 0 ? 0 : ugrd.Rows.Count - addedCount); i < ugrd.Rows.Count; i++)
        {
            objEmp[(addedCount == 0 ? i : i - (ugrd.Rows.Count - addedCount)), 0] = DataTypeUtility.GetToInt32(ugrd.Rows[i].Cells.FromKey("EMP_REF_ID").Value);
            objEmp[(addedCount == 0 ? i : i - (ugrd.Rows.Count - addedCount)), 1] = DataTypeUtility.GetToInt32(ugrd.Rows[i].Cells.FromKey("SORT_ORDER").Value);
        }
        return objEmp;
    }

    private object[] GetDeleteEmpList(UltraWebGrid ugrd, int deleteCount)
    {
        object[] objEmp = new object[(deleteCount == 0 ? ugrd.Rows.Count : deleteCount)];
        int i = 0;
        if (deleteCount == 0)
        {
            foreach (UltraGridRow gr in ugrd.Rows)
            {
                objEmp[i] = gr.Cells.FromKey("EMP_REF_ID").Value;
                i++;
            }
        }
        else
        {
            TemplatedColumn col_Check;
            foreach (UltraGridRow gr in ugrd.Rows)
            {
                col_Check = (TemplatedColumn)gr.Cells.FromKey("selchk").Column;
                if (((CheckBox)((CellItem)col_Check.CellItems[gr.BandIndex]).FindControl("cBox")).Checked)
                {
                    objEmp[i] = gr.Cells.FromKey("EMP_REF_ID").Value;
                    i++;
                }
            }
        }
        return objEmp;
    }

    private int GetEmpCount(UltraWebGrid gr)
    {
        int rtnValue = 0;
        TemplatedColumn col_Check;
        foreach (UltraGridRow insertGR in gr.Rows)
        {
            col_Check = (TemplatedColumn)insertGR.Cells.FromKey("selchk").Column;
            if (((CheckBox)((CellItem)col_Check.CellItems[insertGR.BandIndex]).FindControl("cBox")).Checked)
            {
                rtnValue++;
            }
        }
        return rtnValue;
    }

    private object[] GetInsertDraftEmpList(int addedCount)
    {
        object[] objEmp = new object[(addedCount == 0 ? ugrdDraftEmp.Rows.Count : addedCount)];
        for (int i = ugrdDraftEmp.Rows.Count - addedCount; i < ugrdDraftEmp.Rows.Count; i++)
        {
            objEmp[i - (ugrdDraftEmp.Rows.Count - addedCount)] = DataTypeUtility.GetToInt32(ugrdDraftEmp.Rows[i].Cells.FromKey("EMP_REF_ID").Value);
        }
        return objEmp;
    }

    private int GetSortOrder(UltraWebGrid gr)
    {
        int rtnValue = 0;
        for (int i = 0; i < gr.Rows.Count - 1; i++)
        {
            if (DataTypeUtility.GetToInt32(gr.Rows[i].Cells.FromKey("SORT_ORDER").Value) > rtnValue)
                rtnValue = DataTypeUtility.GetToInt32(gr.Rows[i].Cells.FromKey("SORT_ORDER").Value);
        }
        return rtnValue + 1;
    }

    protected void ibtnDel1_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        int objCount = GetEmpCount(ugrdFixEmp);
        object[] objAppEmp = new object[objCount];
        objAppEmp = GetDeleteEmpList(ugrdFixEmp, objCount);

        if (bizComApp.DeleteFixEmp(this.IBIZ_TYPE, objAppEmp))
            MsgOnUP(UpdatePanel1, "삭제하였습니다.");
        else
        {
            MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
            return;
        }
        DoBinding();
    }
    protected void ibtnDel2_Click(object sender, ImageClickEventArgs e)
    {
        if (ugrdDraftEmp.Rows.Count > 0)
        {
            Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
            int objAppCount = GetEmpCount(ugrdSignerEmp);
            int objDraftCount = ugrdDraftEmp.Rows.Count;
            object[] objAppEmp = new object[objAppCount];
            object[] objDraftEmp = new object[objDraftCount];
            objAppEmp = GetDeleteEmpList(ugrdSignerEmp, objAppCount);
            objDraftEmp = GetDeleteEmpList(ugrdDraftEmp, 0);

            if (bizComApp.DeleteAllEmp(this.IBIZ_TYPE, objDraftEmp, objAppEmp))
            {
                if (ugrdSignerEmp.Rows.Count == objAppCount)
                {
                    ugrdSignerEmp.Clear();
                    ugrdDraftEmp.Clear();
                    DoBindingEmp();
                }
                else
                {
                    DoDeleteEmp(ugrdSignerEmp);
                }
                MsgOnUP(UpdatePanel1, "삭제하였습니다.");
            }
            else
            {
                MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message.Replace("'", ""));
                return;
            }
        }
        else
        {
            DoDeleteEmp(ugrdSignerEmp);
        }
        SetSortOrder(ugrdSignerEmp);
    }
    protected void ibtnDel3_Click(object sender, ImageClickEventArgs e)
    {
        if (ugrdSignerEmp.Rows.Count > 0)
        {
            Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
            int objAppCount = ugrdSignerEmp.Rows.Count;
            int objDraftCount = GetEmpCount(ugrdDraftEmp);
            object[] objAppEmp = new object[objAppCount];
            object[] objDraftEmp = new object[objDraftCount];
            objAppEmp = GetDeleteEmpList(ugrdSignerEmp, 0);
            objDraftEmp = GetDeleteEmpList(ugrdDraftEmp, objDraftCount);

            if (bizComApp.DeleteAllEmp(this.IBIZ_TYPE, objDraftEmp, objAppEmp))
            {
                if (ugrdDraftEmp.Rows.Count == objDraftCount)
                {
                    ugrdSignerEmp.Clear();
                    ugrdDraftEmp.Clear();
                }
                else
                {
                    DoDeleteEmp(ugrdDraftEmp);
                }
                DoBindingEmp();
                MsgOnUP(UpdatePanel1, "삭제하였습니다.");
            }
            else
            {
                MsgOnUP(UpdatePanel1, "실패하였습니다!\\n" + bizComApp.Transaction_Message);
            }
        }
        else
        {
            DoDeleteEmp(ugrdDraftEmp);
        }
    }

    protected void iBtnSet_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ugrdEmpList_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        if (drv["EXIST_YN"].ToString() == "Y")
        {
            e.Row.Cells.FromKey("EMP_NAME").Style.ForeColor = Color.LightBlue;
            e.Row.Cells.FromKey("EMP_NAME").Style.Font.Bold = true;
            e.Row.Cells.FromKey("EMP_NAME").Style.Cursor = Infragistics.WebUI.Shared.Cursors.Hand;
        }
    }

    protected void ugrdEmpList_ActiveRowChange(object sender, RowEventArgs e)
    {
        if (ugrdEmpList.DisplayLayout.ActiveCell == null)
            return;
        if (ugrdEmpList.DisplayLayout.ActiveCell.Key != "EMP_NAME")
            return;
        if (trvDept.SelectedNode == null)
            return;
        if (this.IDEPT_VALUE != trvDept.SelectedNode.Value)
            return;
        if (e.Row.Cells.FromKey("EXIST_YN").Value.ToString() != "Y")
            return;
        DoBindingDraftAppEmp(DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("EMP_REF_ID").Value));
    }

    protected void ugrdEmpList_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (ugrdEmpList.DisplayLayout.ActiveCell == null)
            return;
        //if (ugrdEmpList.DisplayLayout.ActiveCell.Key == "selchk")
        //    MsgOnUP(UpdatePanel1, "ㅇㅇㅇ");
        if (trvDept.SelectedNode == null)
        {
            return;
        }
        if (this.IDEPT_VALUE != trvDept.SelectedNode.Value)
        {
            return;
        }
        if (e.SelectedRows[0].Cells.FromKey("EXIST_YN").Value.ToString() != "Y")
        {
            return;
        }
        DoBindingDraftAppEmp(DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("EMP_REF_ID").Value));
    }

    private void DoBindingDraftAppEmp(int emp_ref_id)
    {
        ugrdDraftEmp.Clear();
        ugrdSignerEmp.Clear();
        foreach (UltraGridRow gr in ugrdEmpList.Rows)
        {
            if (gr.Cells.FromKey("EMP_REF_ID").Value.ToString() == emp_ref_id.ToString())
            {
                UltraGridRow insertGR = new UltraGridRow();
                ugrdDraftEmp.Rows.Insert(ugrdDraftEmp.Rows.Count, insertGR);
                insertGR.Cells.FromKey("COM_DEPT_NAME").Value = gr.Cells.FromKey("DEPT_NAME").Value;
                insertGR.Cells.FromKey("EMP_NAME").Value = gr.Cells.FromKey("EMP_NAME").Value;
                insertGR.Cells.FromKey("POSITION_CLASS_NAME").Value = gr.Cells.FromKey("POSITION_CLASS_NAME").Value;
                insertGR.Cells.FromKey("EMP_REF_ID").Value = gr.Cells.FromKey("EMP_REF_ID").Value;

                Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
                DataTable dtApp = bizComApp.GetApprovalEmpByOne(this.IBIZ_TYPE, emp_ref_id);
                ugrdSignerEmp.DataSource = dtApp;
                ugrdSignerEmp.DataBind();
                break;
            }
        }
    }
    #endregion

}
