﻿using System;
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
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC0302S1 : AppPageBase
{
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    int emp_ref_id = 0;
    int iestterm_ref_id = 0;
    int ikpi_ref_id = 0;
    int iTRow = 0;
    int iCRow = 0;
    public double totalsum = 0;
    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdKpiList.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            this.setKpiData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();

        ltrScript.Text = "";
    }


    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        emp_ref_id = EMP_REF_ID;
    }

    private void InitControlValue()
    {

        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        PageUtility.FindByValueDropDownList(ddlEstDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultInput, "", true, 0);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 0);

        //if (User.IsInRole(ROLE_ADMIN))
        //{
        //    iBtnConfirm.Visible = true;
        //    iBtnCancel.Visible  = true;
        //}
        //else
        //{
        //    iBtnConfirm.Visible = false;
        //    iBtnCancel.Visible  = false;
        //}

        lblCopyText.Style.Add("vertical-align", "middle");
        ddlEsttermCopy.Style.Add("vertical-align", "middle");

        TermInfos objTerm = new TermInfos();
        TermInfos objTermOpen = new TermInfos(objTerm.GetOpenEstTermID());

        if (objTermOpen.Estterm_ref_id > 0)
        {
            ddlEsttermCopy.Items.Add(new ListItem(objTermOpen.Estterm_name, objTermOpen.Estterm_ref_id.ToString()));
        }
        else
        {
            lblCopyText.Visible = false;
            ddlEsttermCopy.Visible = false;
            iBtnKpiCopy.Visible = false;
        }
    }

    private void InitControlEvent()
    {

    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    #endregion

    #region 초기 세팅 메소드

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setKpiData();
    }

    #endregion

    #region 내부 함수

    public void setKpiData()
    {
        if (ddlEstTermInfo.Items.Count < 1)
        {
            PageUtility.AlertMessage("등록된 평가기간이 없습니다.");
            return;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();

        objBSC.Iestterm_ref_id = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        objBSC.Iresult_input_type = ddlResultInput.SelectedValue;
        objBSC.Ikpi_code = txtKPICode.Text.Trim();
        objBSC.Ikpi_name = txtKPIName.Text.Trim();
        objBSC.Ichampion_emp_name = txtChamName.Text.Trim();
        int iest_dept_id = (ddlEstDept.SelectedValue.Trim() == "") ? -1 : int.Parse(ddlEstDept.SelectedValue);
        objBSC.Iuse_yn = "";
        objBSC.Itxr_user = int.Parse(gUserInfo.Emp_Ref_ID.ToString());

        DataSet ds = objBSC.GetKpiListPerUser
                                (objBSC.Iestterm_ref_id
                               , objBSC.Iresult_input_type
                               , objBSC.Ikpi_code
                               , objBSC.Ikpi_name
                               , objBSC.Iuse_yn
                               , objBSC.Ichampion_emp_name
                               , iest_dept_id
                               , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                               , "Y"
                               , objBSC.Itxr_user);

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = ds;
        ugrdKpiList.DataBind();

        //lblCountRow.Text = "Total Rows : " + ds.Tables[0].Rows.Count.ToString();
    }

    public void SetKpiConfirmCancel(DataTable iTs, string strGubun)
    {
        int i = 0;
        int intAffectedRow = 0;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        if (strGubun == "CONFIRM")
        {
            intAffectedRow = objBSC.SetKpiConirm(iTs);
        }
        else
        {
            intAffectedRow = objBSC.SetKpiCancel(iTs);
        }

        //string strMsg = "총 " + iTs.Rows.Count.ToString() + "건중 " + intAffectedRow.ToString() + "건이 처리되었습니다.";
        string strMsg = string.Format("총 {0}건중 {1}건이 처리되었습니다.", iTs.Rows.Count, intAffectedRow);
        ltrScript.Text = JSHelper.GetAlertScript(strMsg, false);
    }

    public void GetCountConfirmCancel(string strGubun)
    {
        int itxr_user = EMP_REF_ID;
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;


        DataTable dt = new DataTable("tblKpiConfirmList");
        dt.Columns.Add("ESTTERM_REF_ID", typeof(int));
        dt.Columns.Add("KPI_REF_ID", typeof(int));
        dt.Columns.Add("TXR_USER", typeof(int));
        DataRow dr;

        for (int i = 0; i < ugrdKpiList.Rows.Count; i++)
        {
            row = ugrdKpiList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    dr = dt.NewRow();
                    dr["ESTTERM_REF_ID"] = int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    dr["KPI_REF_ID"] = int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                    dr["TXR_USER"] = itxr_user;
                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    PageUtility.AlertMessage(ex.Message);
                    return;
                }
            }
        }

        if (dt.Rows.Count < 1)
        {
            PageUtility.AlertMessage("확정 항목을 선택하세요.");
        }
        else
        {
            this.SetKpiConfirmCancel(dt, strGubun);
            this.setKpiData();
        }
    }

    public void CopyKpiToAnotherEstterm()
    {
        int itxr_user = EMP_REF_ID;
        int estterm_ref_id_to = PageUtility.GetIntByValueDropDownList(ddlEsttermCopy);
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        DataTable dt = new DataTable("tblKpiCopyList");
        dt.Columns.Add("ESTTERM_REF_ID_FR", typeof(int));
        dt.Columns.Add("KPI_REF_ID", typeof(int));
        dt.Columns.Add("ESTTERM_REF_ID_TO", typeof(int));
        dt.Columns.Add("TXR_USER", typeof(int));
        DataRow dr;

        for (int i = 0; i < ugrdKpiList.Rows.Count; i++)
        {
            row = ugrdKpiList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    dr = dt.NewRow();
                    dr["ESTTERM_REF_ID_FR"] = int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    dr["KPI_REF_ID"] = int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                    dr["ESTTERM_REF_ID_TO"] = estterm_ref_id_to;
                    dr["TXR_USER"] = itxr_user;

                    if (dr["ESTTERM_REF_ID_FR"].ToString() == dr["ESTTERM_REF_ID_TO"].ToString())
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("같은 평가기간 내에서는 복사할 수 없습니다.", false);
                        return;
                    }

                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    PageUtility.AlertMessage(ex.Message);
                    return;
                }
            }
        }

        if (dt.Rows.Count < 1)
        {
            PageUtility.AlertMessage("확정 항목을 선택하세요.");
        }
        else
        {
            Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
            int intRtn = objBSC.CopyKpiToAnotherTerm(dt);
            string strMsg = "총 [" + dt.Rows.Count.ToString() + "]건중 [" + intRtn.ToString() + "]건이 처리되었습니다.";

            ltrScript.Text = JSHelper.GetAlertScript(strMsg, false);
        }
    }


    /// <summary>
    /// 결재아이콘 범례생성
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetDraftLegend(object sender, LayoutEventArgs e)
    {
        try
        {
            e.Layout.StationaryMargins = StationaryMargins.HeaderAndFooter;
            //e.Layout.CellClickActionDefault = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign = VerticalAlign.Middle;
            //e.Layout.ReadOnly = ReadOnly.LevelTwo;
            
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
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        }
    }

    #endregion

    #region 서버 이벤트 처리 함수
    protected void ugrdKpiList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        this.SetDraftLegend(sender, e);
    }

    protected void ugrdKpiList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);

        iTRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            iCRow += 1;
        }

        lblRowCount.Text = iCRow.ToString() + " / " + iTRow.ToString();

        string estterm_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string url = "<a href='#null' onclick='doPoppingUp_KPI(\"{0}\",\"{1}\",\"{2}\")' style=\"color:Navy;\">{3}</a>";
        string temp = string.Format(url, estterm_ref_id, kpi_ref_id, ICCB1, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = temp;

        string useyn = DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN").Value);
        if (useyn == "Y")
        {
            if (e.Row.Cells.FromKey("WEIGHT").Value != null)
            {
                string weight = DataTypeUtility.GetValue(e.Row.Cells.FromKey("WEIGHT").Value.ToString());
                totalsum += weight == "" ? 0 : DataTypeUtility.GetToDouble(weight);
            }
        }
        else
        {
            e.Row.Cells.FromKey("WEIGHT").Value = "0";
            e.Row.Cells.FromKey("WEIGHT").AllowEditing = AllowEditing.No;
        }
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.setKpiData();
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        this.GetCountConfirmCancel("CONFIRM");
    }

    protected void iBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.GetCountConfirmCancel("CANCEL");
    }

    protected void iBtnKpiCopy_Click(object sender, ImageClickEventArgs e)
    {
        this.CopyKpiToAnotherEstterm();
    }

    protected void btnSumAdd_Click(object sender, EventArgs e)
    {
        int row = 0;
        int cnt = ugrdKpiList.Rows.Count;
        double sum = 0;
        if (cnt > 0)
        {
            for (int i = 0; i < cnt; i++)
            {
                sum += DataTypeUtility.GetToDouble(ugrdKpiList.Rows[i].Cells.FromKey("WEIGHT").Value);
            }

            if (sum > 100)
            {
                Response.Write("<script>alert('합계는 100이하여야 합니다.');</script>");
            }
            else
            {
                for (int i = 0; i < cnt; i++)
                {
                    double weight = DataTypeUtility.GetToDouble(ugrdKpiList.Rows[i].Cells.FromKey("WEIGHT").Value);
                    int STG_REF_ID = int.Parse(ugrdKpiList.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString());
                    int EST_DEPT_REF_ID = int.Parse(ugrdKpiList.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                    int ESTTERM_REF_ID = int.Parse(ugrdKpiList.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    int KPI_REF_ID = int.Parse(ugrdKpiList.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());

                    row += new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info().KpiWeightUpdate(weight, ESTTERM_REF_ID, EST_DEPT_REF_ID
                        , 1, STG_REF_ID, KPI_REF_ID);
                }
                setKpiData();
            }
           
        }

        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (hdfChampionEmpId.Value != "")
        {
            int row_effect = 0;
            for (int i = 0; i < ugrdKpiList.Rows.Count; i++)
            {
                UltraGridRow row = ugrdKpiList.Rows[i];
                TemplatedColumn col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                CheckBox chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

                if (chk.Checked)
                {
                    int estterm_ref_id = int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    int kpi_ref_id = int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                    row_effect += new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info().KpiInfoChampionChange(kpi_ref_id, int.Parse(hdfChampionEmpId.Value), estterm_ref_id);
                }
            }

            if (row_effect > 0)
            {
                ltrScript.Text = JSHelper.GetAlertScript("수정되었습니다.");
                setKpiData();
            }
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("사원을 선택해 주세요.");
            return;
        }
    }
    #endregion
}
