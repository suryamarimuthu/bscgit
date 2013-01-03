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

using MicroCharts;
using System.Drawing;
using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.BSC.Biz;


public partial class BSC_BSC0301M3 : AppPageBase
{
    protected string MODE
    {
        get
        {
            if (ViewState["MODE"] == null)
                ViewState["MODE"] = "";
            return (string)ViewState["MODE"];
        }
        set
        {
            ViewState["MODE"] = value;
        }
    }

    #region ==========================[변수선언]================
    
    public string IKpi_Use_Yn
    {
        get
        {
            if (ViewState["KPI_USE_YN"] == null)
            {
                ViewState["KPI_USE_YN"] = GetRequest("KPI_USE_YN","N");
            }
            return (string)ViewState["KPI_USE_YN"];
        }
        set
        {
            ViewState["KPI_USE_YN"] = value;
        }
    }

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdKPIPoolVer.Bands[0].Columns.FromKey("KPI_POOL_VER_ID").Header.Caption = this.GetText("LBL_00014","버전");
        ugrdKPIPoolVer.Bands[0].Columns.FromKey("KPI_POOL_VER_NAME").Header.Caption = this.GetText("LBL_00015","버전명");
        ugrdKPIPoolVer.Bands[0].Columns.FromKey("KPI_POOL_VER_NOTE").Header.Caption = this.GetText("LBL_00016", "설명");
            

        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        {
            this.PostBackSetting();
        }

        ltrScript.Text = "";

        
    }

    private void NotPostBackSetting()
    {
        DoBinding();
    }

    private void PostBackSetting()
    { 
        
    }


    private void InitForm()
    {
        
    }

    protected void ugrdKPIPoolVer_InitializeRow(object sender, RowEventArgs e)
    {
        string kpi_pool_ver_id = e.Row.Cells.FromKey("KPI_POOL_VER_ID").Value.ToString();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver_Map bizBscKpiPoolVerMap = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver_Map();
        DataTable dtBscKpiPoolVerMap = bizBscKpiPoolVerMap.GetBscKpiPoolVerMap_DB(kpi_pool_ver_id);

        if (dtBscKpiPoolVerMap.Rows.Count > 0)
        {
            e.Row.Cells.FromKey("MAP_YN").Value = "Y";
            e.Row.Cells.FromKey("MAP_YN").Style.ForeColor = System.Drawing.Color.Blue;
        }
        else
        {
            e.Row.Cells.FromKey("MAP_YN").Value = "N";
            e.Row.Cells.FromKey("MAP_YN").Style.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void iBtnSaveVer_Click(object sender, ImageClickEventArgs e)
    {
        if (BizUtility.KPI_POOL_LIST.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 KPI 풀이 없습니다.", false);
        }
        else
        {
            string[] kpi_pool_ref_id_list = BizUtility.KPI_POOL_LIST.Split(',');

            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver_Map bizBscKpiPoolVerMap = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver_Map();

            string msg = bizBscKpiPoolVerMap.AddData_DB(txtKpiPoolVerID.Text
                                                      , kpi_pool_ref_id_list
                                                      , DateTime.Now
                                                      , this.gUserInfo.Emp_Ref_ID);

            if (msg.Equals(""))
            {
                DoBinding();
                BizUtility.KPI_POOL_LIST = string.Empty;
                ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript(msg);
            }
        }
    }

    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        txtKpiPoolVerID.Text = string.Empty;
        txtKpiPoolVerName.Text = string.Empty;
        txtKpiPoolVerNote.Text = string.Empty;

        MODE = "A";
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (MODE.Equals("A"))
            DoSaving();
        else
            DoUpdating();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        DoDeleting();
    }

    private void DoSaving()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver bizBscKpiPoolVer = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver();

        string msg = bizBscKpiPoolVer.AddData_DB(txtKpiPoolVerName.Text
                                               , txtKpiPoolVerNote.Text
                                               , DateTime.Now
                                               , this.gUserInfo.Emp_Ref_ID);

        if (msg.Equals(""))
        {
            DoBinding();

            //ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);
            ltrScript.Text = JSHelper.GetSclipt("alert('정상 처리 되었습니다.');opener.location.href=opener.document.location;");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(msg);
        }
    }

    private void DoUpdating()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver bizBscKpiPoolVer = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver();

        string msg = bizBscKpiPoolVer.ModifyData_DB(txtKpiPoolVerID.Text
                                                   , txtKpiPoolVerName.Text
                                                   , txtKpiPoolVerNote.Text
                                                   , DateTime.Now
                                                   , this.gUserInfo.Emp_Ref_ID);

        if (msg.Equals(""))
        {
            DoBinding();
            ltrScript.Text = JSHelper.GetSclipt("alert('정상 처리 되었습니다.');opener.location.href=opener.document.location;");

        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(msg);
        }
    }

    private void DoDeleting()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver bizBscKpiPoolVer = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver();

        string msg = bizBscKpiPoolVer.RemoveData_DB(txtKpiPoolVerID.Text);

        if (msg.Equals(""))
        {
            DoBinding();
            ltrScript.Text = JSHelper.GetSclipt("alert('정상 처리 되었습니다.');opener.location.href=opener.document.location;");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(msg);
        }
    }

    private void DoBinding()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver bizBscKpiPoolVer = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver();

        DataTable dtBscKpiPoolVer = bizBscKpiPoolVer.GetBscKpiPoolVer_DB();

        ugrdKPIPoolVer.DataSource = dtBscKpiPoolVer;
        ugrdKPIPoolVer.DataBind();

        txtKpiPoolVerID.Text = string.Empty;
        txtKpiPoolVerName.Text = string.Empty;
        txtKpiPoolVerNote.Text = string.Empty;

        MODE = "A";
    }

    protected void ugrdKPIPoolVer_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0)
        {
            txtKpiPoolVerID.Text = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("KPI_POOL_VER_ID").Value);

            MODE = "U";
        }
    }
}
