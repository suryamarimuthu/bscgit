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

using System.Collections.Generic;
using System.Text;

using MicroBSC.Common;
using MicroBSC.BSC.Biz;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class PRJ_PRJ1104S2 : PrjPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";
    }

    private void DoInitControl()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTerm);
        WebCommon.SetEstDeptDropDownList(ddlEstDept, PageUtility.GetIntByValueDropDownList(ddlEstTerm), false);

        ddlWorkType.Items.Insert(0, new ListItem("전체", ""));
        ddlWorkType.Items.Insert(1, new ListItem("중점과제", "C"));
        ddlWorkType.Items.Insert(2, new ListItem("실행과제", "E"));

        ddlCompleteYN.Items.Insert(0, new ListItem("전체", ""));
        ddlCompleteYN.Items.Insert(1, new ListItem("완료", "Y"));
        ddlCompleteYN.Items.Insert(2, new ListItem("미완료", "N"));
    }

    private void DoBinding()
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DataSet dsMap = bizMap.GetWorkMapList(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                            , txtWorkCode.Text.Trim()
                                            , txtWorkName.Text.Trim()
                                            , txtEmpName.Text.Trim()
                                            , PageUtility.GetIntByValueDropDownList(ddlEstDept)
                                            , PageUtility.GetByValueDropDownList(ddlWorkType)
                                            , PageUtility.GetByValueDropDownList(ddlCompleteYN)
                                            , (txtEmpID.Text.Trim() == "" ? 0 : DataTypeUtility.GetToInt32(txtEmpID.Text.Trim())));

        lblRowCount.Text = (dsMap.Tables[0].Rows.Count > 0 ? dsMap.Tables[0].Rows.Count.ToString() : "0");

        ugrdWorkList.Clear();
        ugrdWorkList.DataSource = dsMap;
        ugrdWorkList.DataBind();
    }

    private void PrintFormGrid()
    {
        ugrdEEP.ExcelStartRow = 4;
        ugrdEEP.ExportMode    = ExportMode.InBrowser;
        ugrdEEP.DownloadName  = "WorkList";
        ugrdEEP.WorksheetName = "평가부서별 과제현황";
        ugrdEEP.Export(ugrdWorkList);
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    protected void ibtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFormGrid();
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTerm.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가조직 : " + ddlEstDept.SelectedItem.Text;

        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetEstDeptDropDownList(ddlEstDept, PageUtility.GetIntByValueDropDownList(ddlEstTerm), false);
    }

    protected void ugrdWorkList_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        if (drv["WORK_TYPE"].ToString() == "C")
            e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openWorkForm({0}, {1}, {2})' />"
                , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
                , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
                , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
        else
            e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openExecForm({0}, {1}, {2}, {3})' />"
                , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
                , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
                , e.Row.Cells.FromKey("WORK_REF_ID_ORG").Value.ToString()
                , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
    }
}
