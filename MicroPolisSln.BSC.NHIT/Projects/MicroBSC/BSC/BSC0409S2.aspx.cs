using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.WebUI.UltraWebGrid;
using System.Data;
using MicroBSC.RolesBasedAthentication;

using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

public partial class BSC_BSC0409S2 : AppPageBase
{
    protected int EstTermRefId
    {
        get
        {
            return (int)ViewState["iestterm_ref_id"];
        }
        set
        {
            ViewState["iestterm_ref_id"] = value;
        }
    }

    private DataTable dtTH
    {
        get
        {
            return (DataTable)ViewState["dtTH"];
        }
        set
        {
            ViewState["dtTH"] = value;
        }
    }

    private string ITOP_URL
    {
        get
        {
            return (string)ViewState["TOP_URL"];
        }
        set
        {
            ViewState["TOP_URL"] = value;
        }
    }

    protected void ddlestterm_selectedindexchanged(object sender, EventArgs e)
    {
        this.EstTermRefId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            this.EstTermRefId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            this.SetResultListGrid();

            this.ITOP_URL = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
        }

        ltrScript.Text = "";
    }

    protected void iBtnSearch_Click(object sender, EventArgs e)
    {
        this.SetResultListGrid();
    }

    protected void ibtnPrint_Click(object sender, EventArgs e)
    {
        ugrdEEP.ExcelStartRow = 5;
        ugrdEEP.ExportMode = ExportMode.InBrowser;
        ugrdEEP.DownloadName = "Dept Score Rank";
        ugrdEEP.WorksheetName = "조직별 Score 순위";
        ugrdEEP.Export(ugridKpiTargetList);
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가조직 : " + txtDeptName.Text;

        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    protected void ugrdEEP_CellExported(object sender, CellExportedEventArgs e)
    {
        int iRdex = e.CurrentRowIndex;
        int iCdex = e.CurrentColumnIndex;
        string strEname = string.Empty;
        
        if (iRdex > 4)
        {
            if (iCdex > 6)
            {
                strEname = ugridKpiTargetList.Rows[iRdex - 5].Cells.FromKey("THRESHOLD_ENAME").Text;
                string[] strEnameA = strEname.Split('*');
                string strEname1 = strEnameA.GetValue(iCdex - 7).ToString().Split('^').GetValue(0).ToString();
                string strEname2 = strEnameA.GetValue(iCdex - 7).ToString().Split('^').GetValue(1).ToString();
                string str = e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value.ToString();
                char[] sep = { '<', '>' };
                Array a = str.Split(sep);
                e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value 
                    = a.GetValue(0).ToString().Replace("&nbsp;", "  [") + (strEname1.Length > 4 ? strEname1.Substring(0, 4) : strEname1) + "] \n"
                    + a.GetValue(4).ToString().Replace("&nbsp;", "  [") + (strEname2.Length > 4 ? strEname2.Substring(0, 4) : strEname2) + "] ";
                e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].CellFormat.WrapText = ExcelDefaultableBoolean.True;
            }
        }
    }

    protected void ugrdEEP_EndExport(object sender, EndExportEventArgs e)
    {
        e.CurrentWorksheet.Columns[0].Width = 3000;
        e.CurrentWorksheet.Columns[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Columns[1].Width = 6000;
        e.CurrentWorksheet.Columns[2].Width = 2500;
        e.CurrentWorksheet.Columns[2].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Columns[3].Width = 3000;
        e.CurrentWorksheet.Columns[3].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Columns[4].Width = 2500;
        e.CurrentWorksheet.Columns[4].CellFormat.Alignment = HorizontalCellAlignment.Center;
        e.CurrentWorksheet.Columns[5].Width = 2500;
        e.CurrentWorksheet.Columns[5].CellFormat.Alignment = HorizontalCellAlignment.Center;
        for (int i = 7; i < 19; i++)
            e.CurrentWorksheet.Columns[i].Width = 6000;
    }

    protected void ugridKpiTargetList_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        //string appUrl = Server.MapPath
        for (int i = 1; i < 13; i++)
        {
            e.Row.Cells.FromKey("M" + i.ToString("00")).Value = DataTypeUtility.GetToDouble(drv["M" + i.ToString("00") + "_MS"]).ToString("###,##0.00")
                + String.Format("&nbsp;<img src='{1}/images/{0}' alt='' />", dtTH.Select(string.Format("THRESHOLD_REF_ID = {0}", (drv["M" + i.ToString("00") + "_CHECKSTATUS"].ToString() == "Y" ? DataTypeUtility.GetToInt32(drv["M" + i.ToString("00") + "_SIGNAL_MS"]) : dtTH.Rows.Count - 1)))[0]["IMAGE_FILE_NAME"].ToString(), this.ITOP_URL)
                + "<br/>" 
                + DataTypeUtility.GetToDouble(drv["M" + i.ToString("00") + "_TS"]).ToString("###,##0.00")
                + String.Format("&nbsp;<img src='{1}/images/{0}' alt='' />", dtTH.Select(string.Format("THRESHOLD_REF_ID = {0}", (drv["M" + i.ToString("00") + "_CHECKSTATUS"].ToString() == "Y" ? DataTypeUtility.GetToInt32(drv["M" + i.ToString("00") + "_SIGNAL_TS"]) : dtTH.Rows.Count - 1)))[0]["IMAGE_FILE_NAME"].ToString(), this.ITOP_URL);
            if (drv["M" + i.ToString("00") + "_CHECK_YN"].ToString() == "N")
                e.Row.Cells.FromKey("M" + i.ToString("00")).Style.ForeColor = System.Drawing.Color.LightGray;
            e.Row.Cells.FromKey("THRESHOLD_ENAME").Value
                += dtTH.Select(string.Format("THRESHOLD_REF_ID = {0}", (drv["M" + i.ToString("00") + "_CHECKSTATUS"].ToString() == "Y" ? DataTypeUtility.GetToInt32(drv["M" + i.ToString("00") + "_SIGNAL_MS"]) : dtTH.Rows.Count - 1)))[0]["THRESHOLD_ENAME"].ToString() + "^"
                + dtTH.Select(string.Format("THRESHOLD_REF_ID = {0}", (drv["M" + i.ToString("00") + "_CHECKSTATUS"].ToString() == "Y" ? DataTypeUtility.GetToInt32(drv["M" + i.ToString("00") + "_SIGNAL_TS"]) : dtTH.Rows.Count - 1)))[0]["THRESHOLD_ENAME"].ToString() + "*";
        }
        e.Row.Cells.FromKey("THRESHOLD_ENAME").Value = e.Row.Cells.FromKey("THRESHOLD_ENAME").Value.ToString().Substring(0, e.Row.Cells.FromKey("THRESHOLD_ENAME").Value.ToString().Length - 1);
    }

    public void SetResultListGrid()
    {
        DataSet ds;

        //MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
        //if (((SitePrincipal)this.User).Roles.Contains("1") == true || ((SitePrincipal)this.User).Roles.Contains("8") == true)
        //    ds = objBSC.SelectKpiResultYear(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), (txtDeptCode.Value == string.Empty ? 0 : int.Parse(txtDeptCode.Value)), 0);
        //else
        //    ds = objBSC.SelectKpiResultYear(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), (txtDeptCode.Value == string.Empty ? 0 : int.Parse(txtDeptCode.Value)), this.gUserInfo.Emp_Ref_ID);


        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result();

        int emp_id = this.gUserInfo.Emp_Ref_ID;

        if (this.EMP_ROLES.Contains("1") || this.EMP_ROLES.Contains("8"))
        {
            emp_id = 0;
        }

        ds = bizBscKpiResult.SelectKpiResultYear(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                              , (txtDeptCode.Value == string.Empty ? 0 : int.Parse(txtDeptCode.Value))
                                              , emp_id);

        this.ugridKpiTargetList.Clear();
        this.ugridKpiTargetList.DataSource = ds.Tables[0];
        this.ugridKpiTargetList.DataBind();

        lblRowCount.Text = (ugridKpiTargetList.Rows.Count).ToString();

        //MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();

        DataTable dtBscThresholdCode = bizBscKpiResult.SelectKpiResultYear_BscThresholdCode().Tables[0];

        dtTH = dtBscThresholdCode;

        
    }
}
