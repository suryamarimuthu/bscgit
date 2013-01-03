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

public partial class PRJ_PRJ1104S1 : PrjPageBase
{
    protected int IESTTERM_REF_ID
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
    protected int IEST_DEPT_REF_ID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }
    protected string ITERM_MONTH
    {
        get
        {
            if (ViewState["TERM_MONTH"] == null)
                ViewState["TERM_MONTH"] = "";
            return (string)ViewState["TERM_MONTH"];
        }
        set
        {
            ViewState["TERM_MONTH"] = value;
        }
    }

    protected int IMAP_VERSION_ID
    {
        get
        {
            if (ViewState["MAP_VERSION_ID"] == null)
                ViewState["MAP_VERSION_ID"] = 1;
            return (int)ViewState["MAP_VERSION_ID"];
        }
        set
        {
            ViewState["MAP_VERSION_ID"] = value;
        }
    }
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
        if (!IsPostBack)
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        WebCommon.FillEstTree(trvEstDept, this.IESTTERM_REF_ID, gUserInfo.Emp_Ref_ID);
        trvEstDept.ExpandAll();

        if (trvEstDept.Nodes.Count > 0)
        {
            trvEstDept.Nodes[0].Select();
            this.IEST_DEPT_REF_ID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
            DoBinding();
        }
        else
        {
            ltEstDeptName.Text = lblChampName.Text = lblSTGMapName.Text = "";
            ugrdStgList.Clear();
            this.IEST_DEPT_REF_ID = 0;
        }
    }

    private void DoBinding()
    {        
        ltEstDeptName.Text = lblSTGMapName.Text = lblChampName.Text = "";
        
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DataSet dsMap = bizMap.GetWorkMapTotalListHeader_DB(this.IESTTERM_REF_ID, this.IEST_DEPT_REF_ID);

        IMAP_VERSION_ID = 1;
        if (dsMap.Tables[0].Rows.Count > 0)
        {
            ltEstDeptName.Text  = dsMap.Tables[0].Rows[0]["EST_DEPT_NAME"].ToString();
            lblSTGMapName.Text  = dsMap.Tables[0].Rows[0]["DEPT_VISION"].ToString();
            lblChampName.Text   = dsMap.Tables[0].Rows[0]["BSCCHAMPION_NAME"].ToString();
            IMAP_VERSION_ID = DataTypeUtility.GetToInt32(dsMap.Tables[0].Rows[0]["MAP_VERSION_ID"]);
        }

        Biz_Bsc_Term_Detail bizTerm = new Biz_Bsc_Term_Detail();
        DataSet dsTerm = bizTerm.GetAllList(IESTTERM_REF_ID);
        if (dsTerm.Tables[0].Rows.Count > 0)
            ITERM_MONTH = dsTerm.Tables[0].Compute("MAX(YMD)", "RELEASE_YN = 'Y'").ToString();
        if (ITERM_MONTH == "")
        {
            Biz_Bsc_Map_Info bizMap2 = new Biz_Bsc_Map_Info();
            DataSet dsMap2 = bizMap2.GetMapTermList(IESTTERM_REF_ID, IEST_DEPT_REF_ID, IMAP_VERSION_ID);
            if (dsMap2.Tables[0].Rows.Count > 0)
                ITERM_MONTH = dsMap2.Tables[0].Compute("MAX(YMD)", "APPLY_YN = 'Y'").ToString();
        }

        DataSet dsList = bizMap.GetWorkMapTotalList_DB();

        ugrdStgList.Clear();
        ugrdStgList.DataSource = dsList.Tables[0];
        ugrdStgList.DataBind();
    }

    private void PrintFormGrid()
    {
        ugrdEEP.ExcelStartRow = 6;
        ugrdEEP.ExportMode    = ExportMode.InBrowser;
        ugrdEEP.DownloadName  = "WorkList";
        ugrdEEP.WorksheetName = "과제현황";
        ugrdEEP.Export(ugrdStgList);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        trvEstDept.Nodes.Clear();
        WebCommon.FillEstTree(trvEstDept, Convert.ToInt32(ddlEstTermInfo.SelectedValue));
        trvEstDept.ExpandAll();
    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.IEST_DEPT_REF_ID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
        DoBinding();
    }

    protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFormGrid();
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가조직 : " + ltEstDeptName.Text;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "조직비젼 : " + lblSTGMapName.Text;
        e.CurrentWorksheet.Rows[3].Cells[0].Value = "BSC Champion : " + lblChampName.Text;

        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoInitControl();
    }

    protected void ugrdStgList_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        e.Row.Cells.FromKey("WORK_COUNT").Value = drv["WORK_COMPLETE_COUNT"].ToString() + " / " + drv["WORK_COUNT"].ToString();
        e.Row.Cells.FromKey("EXEC_COUNT").Value = drv["EXEC_COMPLETE_COUNT"].ToString() + " / " + drv["EXEC_COUNT"].ToString();
        if (DataTypeUtility.GetToInt32(drv["WORK_COUNT"]) > 0)
        {
            e.Row.Cells.FromKey("WORK_COUNT").Style.ForeColor = System.Drawing.Color.SkyBlue;
            e.Row.Cells.FromKey("WORK_COUNT").Style.Font.Bold = true;
        }
        if (DataTypeUtility.GetToInt32(drv["EXEC_COUNT"]) > 0)
        {
            e.Row.Cells.FromKey("EXEC_COUNT").Style.ForeColor = System.Drawing.Color.SkyBlue;
            e.Row.Cells.FromKey("EXEC_COUNT").Style.Font.Bold = true;
        }
    }
}
