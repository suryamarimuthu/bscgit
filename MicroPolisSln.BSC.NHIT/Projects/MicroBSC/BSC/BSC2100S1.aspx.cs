using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroBSC.Integration.BSC.Biz;
using System.Data;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC3001S : AppPageBase
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
            GridBind();
        }
    }

    private void GridBind()
    {
        DataTable dt = new Biz_Bsc_Kpi_Pool().AllInsertKpiList(ddlEstTermRefID.SelectedValue, txtKpiName.Text);
        ugrdKpiList.DataSource = dt;
        ugrdKpiList.DataBind();
    }

    protected void ugrdKpiList_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells.FromKey("TARGET_WRITE").Text = "목표입력";
        e.Row.Cells.FromKey("TARGET_WRITE").TargetURL = "BSC2100S2.aspx?kpipool=" + e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value;
        e.Row.Cells.FromKey("RESULT_WRITE").Text = "실적입력";
        e.Row.Cells.FromKey("RESULT_WRITE").TargetURL = "BSC2100S3.aspx?kpipool=" + e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value;
    }

    protected void ibnSearch_Click(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        GridBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int result = 0;
        string type = rdoTarget.SelectedValue;
        int emp_no = DataTypeUtility.GetToInt32(hdfChampionEmpId.Value);
        for (int i = 0; i < ugrdKpiList.Rows.Count; i++)
        {
            UltraGridRow row = ugrdKpiList.Rows[i];
            TemplatedColumn Col_Check = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[row.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                if(type == "0")
                {
                    result = new Biz_Bsc_Kpi_Pool().AllTargetInsert(emp_no,
                        DataTypeUtility.GetToInt32((row.Cells.FromKey("KPI_POOL_REF_ID").Value))
                        );
                }
                else
                {
                    result = new Biz_Bsc_Kpi_Pool().AllResultInsert(emp_no,
                        DataTypeUtility.GetToInt32((row.Cells.FromKey("KPI_POOL_REF_ID").Value))
                        );
                }
            }
        }
        if (result > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
            GridBind();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패.");
            return;
        }
    }
}
