using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MicroBSC.Integration.COM.Biz;
using Infragistics.WebUI.UltraWebGrid;
using System.Drawing;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC2100S3 : AppPageBase
{
    public int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    #region public void Grid_Bind()
    public void Grid_Bind()
    {
        int kpiempid = hdfChampionEmpId0.Value != "" ? int.Parse(hdfChampionEmpId0.Value) : 0;
        int goalempid = hdfChampionEmpId0.Value != "" ? int.Parse(hdfChampionEmpId0.Value) : gUserInfo.Emp_Ref_ID;
        int estterm_id = DataTypeUtility.GetToInt32(ddlEstTermInfo.SelectedValue);
        string ymd = ddlEstTermMonth.SelectedValue;
        string kpiname = txtKPIName.Text;
        ugrdKpiResultList.DataSource = new Biz_Com_Emp_Info().Select_Result(estterm_id, ymd, goalempid, kpiempid, kpiname);
        ugrdKpiResultList.DataBind();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IESTTERM_REF_ID);
            Grid_Bind();
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IESTTERM_REF_ID);
    }

    protected void ugrdKpiResultList_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        SetDraftLegend(sender, e);
    }

    protected void ugrdKpiResultList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = DataTypeUtility.GetValue(e.Row.Cells.FromKey("APP_STATUS").Value);
        objImg.ImageUrl = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
    }

    protected void ibnSearch_Click(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        Grid_Bind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int isAllConvertThis = txtThis.Text == "" ? 0 : DataTypeUtility.GetToInt32(txtThis.Text);
        int isAllConvertFill = txtThis.Text == "" ? 0 : DataTypeUtility.GetToInt32(txtFill.Text);
        int rowEffect = 0;
        for (int i = 0; i < ugrdKpiResultList.Rows.Count; i++)
        {
            UltraGridRow row = ugrdKpiResultList.Rows[i];
            TemplatedColumn Col_Check = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            System.Web.UI.WebControls.CheckBox chkCheck = (System.Web.UI.WebControls.CheckBox)((CellItem)Col_Check.CellItems[row.BandIndex]).FindControl("cBox");

            if (chkCheck.Checked)
            {
                double target_ms = txtThis.Text != "" && DataTypeUtility.GetToDouble(txtThis.Text) != 0 ?
                    DataTypeUtility.GetToDouble(txtThis.Text) : DataTypeUtility.GetToDouble((row.Cells.FromKey("RESULT_MS").Value));
                double target_ts = txtFill.Text != "" && DataTypeUtility.GetToDouble(txtFill.Text) != 0 ?
                    DataTypeUtility.GetToDouble(txtFill.Text) : DataTypeUtility.GetToDouble((row.Cells.FromKey("RESULT_TS").Value));

                int kpi_pool_ref_id = DataTypeUtility.GetToInt32((row.Cells.FromKey("KPI_REF_ID").Value));
                int esstid = DataTypeUtility.GetToInt32(ddlEstTermInfo.SelectedValue);
                string ymd = ddlEstTermMonth.SelectedValue;

                rowEffect += new Biz_Com_Emp_Info().Update_Result(esstid, kpi_pool_ref_id, ymd, target_ms, target_ts);
            }
        }
        if (rowEffect > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
            txtFill.Text = "";
            txtThis.Text = "";
            Grid_Bind();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패.");
            return;
        }
    }

    protected void btnIFMove_Click(object sender, EventArgs e)
    {
        int rowEffect = 0;
        for (int i = 0; i < ugrdKpiResultList.Rows.Count; i++)
        {
            UltraGridRow row = ugrdKpiResultList.Rows[i];
            TemplatedColumn Col_Check = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            System.Web.UI.WebControls.CheckBox chkCheck = (System.Web.UI.WebControls.CheckBox)((CellItem)Col_Check.CellItems[row.BandIndex]).FindControl("cBox");

            if (chkCheck.Checked)
            {
                double target_ms = DataTypeUtility.GetToDouble((row.Cells.FromKey("CAL_RESULT_MS").Value));
                double target_ts = DataTypeUtility.GetToDouble((row.Cells.FromKey("CAL_RESULT_TS").Value));

                int kpi_pool_ref_id = DataTypeUtility.GetToInt32((row.Cells.FromKey("KPI_REF_ID").Value));
                int esstid = DataTypeUtility.GetToInt32(ddlEstTermInfo.SelectedValue);
                string ymd = ddlEstTermMonth.SelectedValue;

                rowEffect += new Biz_Com_Emp_Info().Update_Result(esstid, kpi_pool_ref_id, ymd, target_ms, target_ts);
            }
        }

        if (rowEffect > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
            txtFill.Text = "";
            txtThis.Text = "";
            Grid_Bind();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패.");
            return;
        }
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        Grid_Bind();
    }

    protected void lBtnReload2_Click(object sender, EventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(lBtnReload.ClientID.Replace('_', '$'), true);
    }


    /// <summary>
    /// 결재아이콘 범례생성
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    #region public void SetDraftLegend(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    public void SetDraftLegend(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        try
        {
            e.Layout.StationaryMargins = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign = VerticalAlign.Middle;

            int iCol = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg = iCol;  // Start Colspan Length
            int iFRow = 0;     // Start Colspan Index
            for (int i = 0; i < iCol; i++)
            {
                iFRow += 1;
                if (e.Layout.Bands[0].Columns[i].Hidden)
                {
                    iMrg -= 1;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX = iMrg;
                    break;
                }
            }

            if (iFRow > 0)
            {
                string sLegend = Biz_Type.app_legend;

                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Caption = sLegend;
                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Style.Width = Unit.Percentage(100);
            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion
}
