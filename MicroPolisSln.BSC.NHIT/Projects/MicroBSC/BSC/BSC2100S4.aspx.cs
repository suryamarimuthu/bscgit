using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroBSC.Integration.BSC.Biz;
using System.Data;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC2100S4 : AppPageBase
{
    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            KpiPool_GridBind();
        }
    }

    private void KpiPool_GridBind()
    {
        DataTable dt = new Biz_Bsc_Kpi_Pool().AllInsertKpiList(ddlEstTermRefID.SelectedValue, txtKpiName.Text);
        ugrdKpiList.DataSource = dt;
        ugrdKpiList.DataBind();
       
    }

    protected void ibnSearch_Click(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        hdkpipool.Value = "0";
        hdkpistg.Value = "0";
        hdkpiview.Value = "0";
        ugrdKpiDept.Clear();
        KpiPool_GridBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int result = 0;
        for (int i = 0; i < ugrdKpiDept.Rows.Count; i++)
        {
            UltraGridRow row = ugrdKpiDept.Rows[i];
            TemplatedColumn Col_Check = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[row.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                result += new Biz_Bsc_Kpi_Pool().KpiCreateDeptRemove(DataTypeUtility.GetToInt32((row.Cells.FromKey("KPI_REF_ID").Value)));
            }
        }

        if (result > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제 되었습니다.");
            ugrdKpiDept.Clear();
            KpiPool_GridBind();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제 실패.");
            return;
        }
    }

    protected void lbnDeptReload_Click(object sender, EventArgs e)
    {
        DeptList(int.Parse(hdkpipool.Value), int.Parse(hdkpistg.Value), int.Parse(hdkpiview.Value));
    }

    protected void ugrdKpiList_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        ltrScript.Text = "";
        int stg_ref_id = (e.SelectedRows[0].Cells.FromKey("STG_REF_ID") != null) ? int.Parse(e.SelectedRows[0].Cells.FromKey("STG_REF_ID").Value.ToString()) : 0;
        int view_ref_id = (e.SelectedRows[0].Cells.FromKey("VIEW_REF_ID") != null) ? int.Parse(e.SelectedRows[0].Cells.FromKey("VIEW_REF_ID").Value.ToString()) : 0;
        int kpi_pool_ref_id = (e.SelectedRows[0].Cells.FromKey("KPI_POOL_REF_ID") != null) ? int.Parse(e.SelectedRows[0].Cells.FromKey("KPI_POOL_REF_ID").Value.ToString()) : 0;
        DeptList(kpi_pool_ref_id, stg_ref_id, view_ref_id);
    }

    private void DeptList(int kpi_pool_ref_id, int stg_view_ref_id, int view_ref_id)
    {
        DataTable dt = new Biz_Bsc_Kpi_Pool().KpiCreateDeptList(kpi_pool_ref_id);
        hdkpipool.Value = kpi_pool_ref_id.ToString();
        hdkpistg.Value = stg_view_ref_id.ToString();
        hdkpiview.Value = view_ref_id.ToString();
        ugrdKpiDept.DataSource = dt;
        ugrdKpiDept.DataBind();
    }
}
