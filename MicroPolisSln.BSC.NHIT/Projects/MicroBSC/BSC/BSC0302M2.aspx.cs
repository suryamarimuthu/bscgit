﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebTab;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

//using Dundas.Charting.WebControl;
using System.Web.UI.DataVisualization.Charting;

using MicroBSC.Biz.Common.Biz;
using MicroCharts;

public partial class BSC_BSC0302M2 : AppPageBase
{
    #region ==========================[변수선언]================
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    private string IKpiGroupType
    {
        get
        {
            if (ViewState["KPI_GROUP_TYPE"] == null)
                ViewState["KPI_GROUP_TYPE"] = "";
            return (string)ViewState["KPI_GROUP_TYPE"];
        }
        set
        {
            ViewState["KPI_GROUP_TYPE"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

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

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public string IChampion_User_YN
    {
        get
        {
            if (ViewState["CHAMPION_EMP_YN"] == null)
            {
                ViewState["CHAMPION_EMP_YN"] = GetRequest("CHAMPION_EMP_YN");
            }
            return (string)ViewState["CHAMPION_EMP_YN"];
        }
        set
        {
            ViewState["CHAMPION_EMP_YN"] = value;
        }
    }

    public string IHaveInitive_YN
    {
        get
        {
            if (ViewState["HAVE_INITIATIVE_YN"] == null)
            {
                ViewState["HAVE_INITIATIVE_YN"] = GetRequest("HAVE_INITIATIVE_YN", "N");
            }
            return (string)ViewState["HAVE_INITIATIVE_YN"];
        }
        set
        {
            ViewState["HAVE_INITIATIVE_YN"] = value;
        }
    }

    public string IScoreValuationType
    {
        get
        {
            if (ViewState["SCORE_VALUATION_TYPE"] == null)
            {
                ViewState["SCORE_VALUATION_TYPE"] = GetRequest("SCORE_VALUATION_TYPE");
            }
            return (string)ViewState["SCORE_VALUATION_TYPE"];
        }
        set
        {
            ViewState["SCORE_VALUATION_TYPE"] = value;
        }
    }

    public string IYearlyClose_YN
    {
        get
        {
            if (ViewState["YEARLY_CLOSE_YN"] == null)
            {
                ViewState["YEARLY_CLOSE_YN"] = GetRequest("YEARLY_CLOSE_YN");
            }
            return (string)ViewState["YEARLY_CLOSE_YN"];
        }
        set
        {
            ViewState["YEARLY_CLOSE_YN"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID");
            }
            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
            hdfKpiPoolRefID.Value = value.ToString();
        }
    }

    private string IApproval_Status
    {
        get
        {
            if (ViewState["APPROVAL_STATUS"] == null)
                ViewState["APPROVAL_STATUS"] = "N";
            return (string)ViewState["APPROVAL_STATUS"];
        }
        set
        {
            ViewState["APPROVAL_STATUS"] = value;
        }
    }

    Workbook workBook = null; // smjjang

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBaseBinding();
            DoBinding();
            DoBindingSignal();
            DoBindingTerm();
            DoSetTarget(false, false);
            SetButton();
        }
        ltrScript.Text = "";
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        iBtnGoalTong.Visible = false;
        
        if (e.Tab.Key == "2")
            SetInitiativeRow();
        else if (e.Tab.Key == "1")
        {
            if (this.IType == "U")
                drawPoint();

            if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
                iBtnGoalTong.Visible = true;
        }
        
    }

    protected void ugrdEEP_CellExporting(object sender, CellExportingEventArgs e)
    {
        this.SetCoulumStlye(e.CurrentWorksheet, e.CurrentRowIndex, e.CurrentColumnIndex);

        if (e.CurrentWorksheet.Index == 2) // "Part III KPI 계획 및 평가"
        {
            int mergeHeader = 6;

            e.CurrentWorksheet.Rows[mergeHeader].Cells[1].Value = "당초계획";
            e.CurrentWorksheet.Rows[mergeHeader].Cells[1].CellFormat.Alignment = HorizontalCellAlignment.Center;

            e.CurrentWorksheet.Rows[mergeHeader].Cells[3].Value = "수정계획";
            e.CurrentWorksheet.Rows[mergeHeader].Cells[3].CellFormat.Alignment = HorizontalCellAlignment.Center;

            mergeHeader = ugrdTerm.Rows.Count + 9;
            e.CurrentWorksheet.Rows[mergeHeader].Cells[0].Value = "상태표시";
            e.CurrentWorksheet.Rows[mergeHeader].Cells[0].CellFormat.Alignment = HorizontalCellAlignment.Center;
            e.CurrentWorksheet.Rows[mergeHeader].Cells[1].Value = "등급구간";
            e.CurrentWorksheet.Rows[mergeHeader].Cells[1].CellFormat.Alignment = HorizontalCellAlignment.Center;
            e.CurrentWorksheet.Rows[mergeHeader].Cells[3].Value = "평가Table";
            e.CurrentWorksheet.Rows[mergeHeader].Cells[3].CellFormat.Alignment = HorizontalCellAlignment.Center;
        }
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        CommonDataPrint();
    }
    
    protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        ExcelDownLoad();
    }

    protected void linkBtnRegTarget_Click(object sender, EventArgs e)
    {
        DoBindingTerm();
        DoSetTarget(false, false);
        this.drawPoint();
    }

    protected void ugrdSignal_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "표시상태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "등급구간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평가 Table";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = ugrdSignal.Bands[0].Columns.FromKey("SET_MIN_VALUE").Header;
        ch.Caption = "계획";
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.SpanX = 2;

        ch = new ColumnHeader(true);
        ch.Caption = "계량";
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.OriginY = 2;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new ColumnHeader(true);
        ch.Caption = "비계량";
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.OriginY = 2;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new ColumnHeader(true);
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.OriginY = 2;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new ColumnHeader(true);
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.OriginY = 2;
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = ugrdSignal.Bands[0].Columns.FromKey("SIGNAL").Header;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = ugrdSignal.Bands[0].Columns.FromKey("IMAG_PATH").Header;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = ugrdSignal.Bands[0].Columns.FromKey("THRS_DESC").Header;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = ugrdSignal.Bands[0].Columns.FromKey("ACHIEVE_RATE").Header;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = ugrdSignal.Bands[0].Columns.FromKey("POINT").Header;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            switch (i)
            {
                case 0:
                    //e.Layout.Bands[0].Columns[i].Width = 80;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 1:
                    //e.Layout.Bands[0].Columns[i].Width = 35;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 2:
                    //e.Layout.Bands[0].Columns[i].Width = 78;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    break;
                case 3:
                    //e.Layout.Bands[0].Columns[i].Width = 125;
                    e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.#####";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                case 4:
                    //e.Layout.Bands[0].Columns[i].Width = 125;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 5:
                    e.Layout.Bands[0].Columns[i].Header.Caption = (ddlResultAchievementType.SelectedValue == "BTY") ? "한계초과율" : "달성율";
                    //e.Layout.Bands[0].Columns[i].Width = 63;
                    e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.##";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                case 6:
                    //e.Layout.Bands[0].Columns[i].Width = 62;
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.##";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                default:
                    //e.Layout.Bands[0].Columns[i].Hidden = true;
                    break;
            }
        }
    }

    protected void linkBtnSelKpiPool_Click(object sender, EventArgs e)
    {
        this.IKpiPoolRefID = (this.hdfKpiPoolRefID.Value == "") ? 0 : Convert.ToInt32(hdfKpiPoolRefID.Value.ToString());
        this.drawPoint();
        this.SetKpiPoolInfo();
        
    }

    protected void ugrdTerm_InitializeRow(object sender, RowEventArgs e)
    {
        CheckBox chkCheck;

        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("CHECK_YN");

        chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("chkCheckTerm");
        chkCheck.Checked = (e.Row.Cells.FromKey("CHECK_YN").Value.ToString() == "Y") ? true : false;
        chkCheck.Enabled = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;
    }

    protected void ugrdSignal_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells[0].AllowEditing = AllowEditing.No;
        e.Row.Cells[1].AllowEditing = AllowEditing.No;
        e.Row.Cells[2].AllowEditing = AllowEditing.No;
        e.Row.Cells[3].AllowEditing = AllowEditing.No;
        e.Row.Cells[4].AllowEditing = AllowEditing.No;
        e.Row.Cells[5].AllowEditing = AllowEditing.No;
        e.Row.Cells[6].AllowEditing = AllowEditing.No;

        e.Row.Cells[0].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[1].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[2].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[3].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[4].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[5].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[6].Style.BackColor = System.Drawing.Color.WhiteSmoke;

        e.Row.Cells[1].Value = "<img src='../images/" + e.Row.Cells[1].Value.ToString() + "'>";
        e.Row.Cells[1].Style.HorizontalAlign = HorizontalAlign.Center;
    }

    protected void ugrdQuestionTerm_InitializeRow(object sender, RowEventArgs e)
    {        
    }

    protected void ddlResultMeasurementStep_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBindingSignal();
    }

    //---------------------- 마스터 입력/수정/삭제
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        DoInserting();
    }
    
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        DoUpdating();
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        DoConfirm(true);
    }

    protected void iBtnConfirmCancel_Click(object sender, ImageClickEventArgs e)
    {
        DoConfirm(false);
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        DoUseYN("N");
    }

    protected void ugrdInitiative_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn tmcPL = (TemplatedColumn)e.Row.Band.Columns.FromKey("INITIATIVE_PLAN");
        TemplatedColumn tmcDO = (TemplatedColumn)e.Row.Band.Columns.FromKey("INITIATIVE_DO");
        TemplatedColumn tmcDE = (TemplatedColumn)e.Row.Band.Columns.FromKey("INITIATIVE_DESC");

        TextBox txtPL = (TextBox)((CellItem)tmcPL.CellItems[e.Row.BandIndex]).FindControl("txtINITIATIVE_PLAN");
        TextBox txtDO = (TextBox)((CellItem)tmcDO.CellItems[e.Row.BandIndex]).FindControl("txtINITIATIVE_DO");
        TextBox txtDE = (TextBox)((CellItem)tmcDE.CellItems[e.Row.BandIndex]).FindControl("txtINITIATIVE_DESC");

        txtPL.Text = (e.Row.Cells.FromKey("INITIATIVE_PLAN").Value != null) ? e.Row.Cells.FromKey("INITIATIVE_PLAN").Value.ToString() : "";
        txtDO.Text = (e.Row.Cells.FromKey("INITIATIVE_DO").Value != null) ? e.Row.Cells.FromKey("INITIATIVE_DO").Value.ToString() : "";
        txtDE.Text = (e.Row.Cells.FromKey("INITIATIVE_DESC").Value != null) ? e.Row.Cells.FromKey("INITIATIVE_DESC").Value.ToString() : "";

        txtPL.Style.Add("overflow", "auto");
        txtDO.Style.Add("overflow", "auto");
        txtDE.Style.Add("overflow", "auto");

        string strCheckYN = (e.Row.Cells.FromKey("CHECK_YN").Value != null) ? e.Row.Cells.FromKey("CHECK_YN").Value.ToString() : "N";
        if (strCheckYN == "Y")
        {
            txtPL.Enabled = true;
            txtDO.Enabled = true;
            txtDE.Enabled = true;
        }
        else
        {
            txtPL.Enabled = false;
            txtDO.Enabled = false;
            txtDE.Enabled = false;
        }
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (GetRequest("closeRefresh", "") == "F")
            ltrScript.Text = JSHelper.GetCloseScript();
        else
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    protected void iBtnUsed_Click(object sender, ImageClickEventArgs e)
    {
        DoUseYN("Y");
    }


    private void DoInitControl()
    {         
        Biz_EtcCodeInfos objCode = new Biz_EtcCodeInfos();
        objCode.getPNUType(ddlResultAchievementType, "", false, 200);
        objCode.getCheckType(ddlMeasurementGradeType, "", false, 200);
        objCode.getColTargetType(ddlResultTsCalcType, "", false, 80);
        WebCommon.SetUnitTypeDropDownList(ddlUnit, false);
        objCode.getCheckStep(ddlResultMeasurementStep, "", false, 100);

        ddlResultAchievementType.Width = System.Web.UI.WebControls.Unit.Percentage(100);
        ddlMeasurementGradeType.Width = System.Web.UI.WebControls.Unit.Percentage(100);
        ddlResultTsCalcType.Width = System.Web.UI.WebControls.Unit.Percentage(100);
        ddlUnit.Width = System.Web.UI.WebControls.Unit.Percentage(100);
        ddlResultMeasurementStep.Width = System.Web.UI.WebControls.Unit.Percentage(100);

        if (this.IType == "A" && !User.IsInRole(ROLE_ADMIN))
            ibtnChampion.Visible = false;
    }

    private void DoBaseBinding()
    {
        //-------------------- KPI Status Setting
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiStatus(IEstTermRefID, IKpiRefID, gUserInfo.Emp_Ref_ID);

        if (rDs.Tables[0].Rows.Count > 0)
        {
            IChampion_User_YN = rDs.Tables[0].Rows[0]["CHAMPION_EMP_YN"].ToString();
            hdfinitial_version_yn.Value = rDs.Tables[0].Rows[0]["INITIAL_VERSION_YN"].ToString();
            hdfkpi_target_version_id.Value = rDs.Tables[0].Rows[0]["KPI_TARGET_VERSION_ID"].ToString();
            IHaveInitive_YN = rDs.Tables[0].Rows[0]["HAVE_INITIATIVE_YN"].ToString();
            IScoreValuationType = rDs.Tables[0].Rows[0]["SCORE_VALUATION_TYPE"].ToString();
            IYearlyClose_YN = rDs.Tables[0].Rows[0]["YEARLY_CLOSE_YN"].ToString();

            if (IHaveInitive_YN == "Y")
            {
                ugrdInitiative.Visible = false;
                ugrdInitiative.Clear();
            }
            else
            {
                ugrdInitiative.Visible = true;
                SetInitiativeList();
            }
        }
    }

    /// <summary>
    /// 이니셔티브 리스트
    /// </summary>
    private void SetInitiativeList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Initiative();
        DataSet rDs = objBSC.GetKpiInitaitive(IEstTermRefID, IKpiRefID);

        ugrdInitiative.Clear();
        ugrdInitiative.DataSource = rDs;
        ugrdInitiative.DataBind();
    }

    /// <summary>
    /// 지표기본정보 세팅
    /// </summary>
    private void DoBinding()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        txtCalcFormMs.Text = objBSC.Icalc_form_ms;

        if (objBSC.Ichampion_emp_id.Equals(0))
        {
            hdfChampionEmpId.Value = gUserInfo.Emp_Ref_ID.ToString();
            txtChampionEmpName.Text = gUserInfo.Emp_Name;
        }
        else
        {
            hdfChampionEmpId.Value = objBSC.Ichampion_emp_id.ToString();
            txtChampionEmpName.Text = objBSC.Ichampion_emp_name;
        }

        txtKpiCode.Text = objBSC.Ikpi_code;
        txtWordDefinition.Value = objBSC.Iword_definition;
        spnWordDefinition.InnerHtml = txtWordDefinition.Value;
        ddlResultAchievementType.SelectedValue = objBSC.Iresult_achievement_type;
        ddlResultTsCalcType.SelectedValue = objBSC.Iresult_ts_calc_type;
        ddlMeasurementGradeType.SelectedValue = objBSC.Imeasurement_grade_type;
        ddlResultMeasurementStep.SelectedValue = objBSC.Iresult_measurement_step;
        ddlUnit.SelectedValue = objBSC.Iunit_type_ref_id.ToString();
        txtTargetReason.Text = objBSC.Ikpi_target_setting_reason;
        hdfTargetReasonFile.Value = objBSC.Ikpi_target_reason_file;
        this.IApproval_Status = objBSC.Iapproval_status;

        this.IKpiPoolRefID = objBSC.Ikpi_pool_ref_id;
        if (objBSC.Iuse_yn == "N")
        {
            this.IType = "D";
        }

        iBtnTargetFile_Down.Visible = (objBSC.Ikpi_target_reason_file == "") ? false : true;
        SetKpiPoolInfo();
    }

    /// <summary>
    /// 지표풀정보 세팅
    /// </summary>
    private void SetKpiPoolInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objPool = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        lblKpiType.Text = objPool.Ikpi_external_type_name + "/" + objPool.Ikpi_type_name;
        this.txtKpiName.Text = objPool.Ikpi_name;
        this.IKpiGroupType = objPool.Ikpi_type;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objL = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low(objPool.Icategory_top_ref_id, objPool.Icategory_mid_ref_id, objPool.Icategory_low_ref_id);
        this.lblKpiCatName.Text = objL.Icategory_top_name + " / " + objL.Icategory_mid_name + " / " + objL.Icategory_low_name;

        DoSetKpiGroupType();
    }

    /// <summary>
    /// 등급구간 조회
    /// </summary>
    private void DoBindingSignal()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Threshold_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Threshold_Info();
        DataSet dsSignal = objBSC.GetMBOSignalListPerKpi(this.IEstTermRefID, this.IKpiRefID, ddlResultMeasurementStep.SelectedValue);

        ugrdSignal.Clear();
        ugrdSignal.Rows.Clear();
        ugrdSignal.DataSource = dsSignal;
        ugrdSignal.DataBind();
        this.drawPoint();

        DoSetKpiGroupType();
    }

    private void DoSetKpiGroupType()
    {
        foreach (UltraGridRow gr in ugrdSignal.Rows)
        {
            gr.Cells.FromKey("SET_MIN_VALUE").AllowEditing = gr.Cells.FromKey("SET_TXT_VALUE").AllowEditing = AllowEditing.Yes;
            gr.Cells.FromKey("SET_MIN_VALUE").Style.BackColor = gr.Cells.FromKey("SET_TXT_VALUE").Style.BackColor = Color.White;
            switch (this.IKpiGroupType)
            {
                case "QTT":
                    gr.Cells.FromKey("SET_TXT_VALUE").AllowEditing = AllowEditing.No;
                    gr.Cells.FromKey("SET_TXT_VALUE").Style.BackColor = Color.WhiteSmoke;
                    gr.Cells.FromKey("SET_TXT_VALUE").Value = "";
                    break;
                case "QLT":
                    gr.Cells.FromKey("SET_MIN_VALUE").AllowEditing = AllowEditing.No;
                    gr.Cells.FromKey("SET_MIN_VALUE").Style.BackColor = Color.WhiteSmoke;
                    gr.Cells.FromKey("SET_MIN_VALUE").Value = 0;
                    break;
                default:
                    gr.Cells.FromKey("SET_MIN_VALUE").AllowEditing = gr.Cells.FromKey("SET_TXT_VALUE").AllowEditing = AllowEditing.No;
                    gr.Cells.FromKey("SET_MIN_VALUE").Style.BackColor = gr.Cells.FromKey("SET_TXT_VALUE").Style.BackColor = Color.WhiteSmoke;
                    break;
            }
        }
    }

    #region ================================= [ 그래프 그리기 ]=================================
    private void drawPoint()
    {
        DataSet idsSet = new DataSet();
        ////////////////////////////////////////////////////
        // KPI THRESHOLD 
        ////////////////////////////////////////////////////
        int intRow = ugrdSignal.Rows.Count;
        DataTable rDT4 = new DataTable("BSC_KPI_THRESHOLD_INFO");

        rDT4.Columns.Add("ITYPE", typeof(string));
        rDT4.Columns.Add("ESTTERM_REF_ID", typeof(int));
        rDT4.Columns.Add("KPI_REF_ID", typeof(int));
        rDT4.Columns.Add("THRESHOLD_REF_ID", typeof(int));
        rDT4.Columns.Add("THRESHOLD_LEVEL", typeof(string));
        rDT4.Columns.Add("SET_MIN_VALUE", typeof(double));
        rDT4.Columns.Add("SET_MAX_VALUE", typeof(double));
        rDT4.Columns.Add("ACHIEVE_RATE", typeof(double));
        rDT4.Columns.Add("POINT", typeof(double));

        DataRow rDR4;
        for (int i = 0; i < intRow; i++)
        {
            rDR4 = rDT4.NewRow();

            rDR4["ITYPE"] = (ugrdSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? "A" : "U";
            rDR4["ESTTERM_REF_ID"] = (ugrdSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR4["KPI_REF_ID"] = (ugrdSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null) ? this.IKpiRefID : int.Parse(ugrdSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR4["THRESHOLD_REF_ID"] = (ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value == null) ? 0 : int.Parse(ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value.ToString());
            rDR4["THRESHOLD_LEVEL"] = (ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value == null) ? "" : ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value;
            rDR4["SET_MIN_VALUE"] = (ugrdSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value.ToString());
            rDR4["SET_MAX_VALUE"] = (ugrdSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value.ToString());
            rDR4["ACHIEVE_RATE"] = (ugrdSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value.ToString());
            rDR4["POINT"] = (ugrdSignal.Rows[i].Cells.FromKey("POINT").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("POINT").Value.ToString());

            rDT4.Rows.Add(rDR4);
        }

        idsSet.Tables.Add(rDT4);

        MSCharts.DundasChartBase(chartScore, ChartImageType.Jpeg, 400, 280
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, MsGradientType.TopBottom, MsAntiAliasing.None);

        string strRate = "";
        double dblPoint = 0;
        int cntRow = idsSet.Tables[0].Rows.Count;

        Series series1 = MSCharts.CreateSeries(chartScore, "Series1", "Default", "평가 Graph", null, ((this.IScoreValuationType == "SLP") ? SeriesChartType.Line : SeriesChartType.StepLine), 2, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        chartScore.ChartAreas["Default"].AxisX.Title = "달성율";
        chartScore.ChartAreas["Default"].AxisY.Title = "획득점수";

        if (ddlResultAchievementType.SelectedValue == "ATY") // 증가형
        {
            for (int i = 0; i < cntRow; i++)
            {
                strRate = double.Parse(idsSet.Tables[0].Rows[cntRow - (i + 1)]["ACHIEVE_RATE"].ToString()).ToString("#,##0");
                dblPoint = double.Parse(idsSet.Tables[0].Rows[cntRow - (i + 1)]["POINT"].ToString());
                chartScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
            }
        }
        else if (ddlResultAchievementType.SelectedValue == "BTY") // 감소형
        {
            if (this.IScoreValuationType == "SLP")
            {
                for (int i = 0; i < cntRow; i++)
                {
                    strRate = double.Parse(idsSet.Tables[0].Rows[i]["ACHIEVE_RATE"].ToString()).ToString("#,##0");
                    dblPoint = double.Parse(idsSet.Tables[0].Rows[i]["POINT"].ToString());
                    chartScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
                }
            }
            else
            {
                strRate = double.Parse(idsSet.Tables[0].Rows[0]["ACHIEVE_RATE"].ToString()) + "이하";
                dblPoint = double.Parse(idsSet.Tables[0].Rows[0]["POINT"].ToString());
                chartScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);

                int j = 0;
                for (int i = 0; i < cntRow; i++)
                {
                    j = (i == cntRow - 1) ? i : i + 1;
                    strRate = double.Parse(idsSet.Tables[0].Rows[i]["ACHIEVE_RATE"].ToString()).ToString("#,##0");
                    dblPoint = double.Parse(idsSet.Tables[0].Rows[j]["POINT"].ToString());
                    chartScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
                }
            }

            chartScore.ChartAreas["Default"].AxisX.Title = "한계초과율";
        }
        else if (ddlResultAchievementType.SelectedValue == "CTY") // Zero 형
        {
            for (int i = 0; i < cntRow; i++)
            {
                strRate = double.Parse(idsSet.Tables[0].Rows[i]["SET_MIN_VALUE"].ToString()).ToString("#,##0");
                dblPoint = double.Parse(idsSet.Tables[0].Rows[i]["POINT"].ToString());
                chartScore.Series[series1.Name].Points.AddXY(strRate, dblPoint);
            }
        }
    }
    #endregion

    #region ================================= [ 실적누계계산 관련 메소드 ]======================
    // isAddTargetYN : 목표가 추가되어 그리드다시세팅여부
    // isCalcYN      : 산식에 의해 셀계산할것인지 여부
    public void DoSetTarget(bool isAddTargetYN, bool isCalcYN)
    {
        if (ugrdTerm.Rows.Count < 1)
        {
            return;
        }

        int intRow = ugrdTerm.Rows.Count;
        int intChkRow = 0;
        double dblTot = 0.00;
        string _icheck_term = "";
        string strCloseYn = "";

        ugrdTerm.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.No;
        ugrdTerm.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.No;
        ugrdTerm.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
        ugrdTerm.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;

        CheckBox chkCheck;
        TemplatedColumn Col_Check;
        for (int i = 0; i < intRow; i++)
        {
            _icheck_term = "";

            Col_Check = (TemplatedColumn)ugrdTerm.Columns.FromKey("CHECK_YN");
            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[ugrdTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");
            _icheck_term = (chkCheck.Checked) ? "Y" : "N";
            strCloseYn = ugrdTerm.Rows[i].Cells.FromKey("CLOSE_YN").Value.ToString();

            if (_icheck_term == "Y")
            {
                dblTot += double.Parse((ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Value == null ? "0" : ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Value.ToString()));
                intChkRow += 1;
            }


            if (ugrdTerm.Rows[i] != null)
            {
                if (strCloseYn == "Y")
                {
                    ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.No;
                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                    ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.WhiteSmoke;
                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    if (_icheck_term == "N")
                    {
                        ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.No;
                        ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                        ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.WhiteSmoke;
                        ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.WhiteSmoke;
                        ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Value = 0;
                        ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value = 0;

                        switch (PageUtility.GetByValueDropDownList(ddlResultTsCalcType))
                        {
                            case "SUM": // 단순합계
                                ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value = Math.Round(dblTot, 5);
                                break;
                            case "AVG": // 단순평균
                                ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.Yes;
                        ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.Yes;
                        ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.White;
                        ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.White;

                        if (isCalcYN)
                        {
                            switch (PageUtility.GetByValueDropDownList(ddlResultTsCalcType))
                            {
                                case "SUM": // 단순합계
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value = Math.Round(dblTot, 5);
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "AVG": // 단순평균
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "OTS": // 누적만측정
                                    ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.No;
                                    ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Value = 0;
                                    break;
                                default:
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    break;
                            }
                        }
                        else
                        {
                            ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                            ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                    }
                }
            }
        }
    }
    #endregion

    /// <summary>
    /// 측정주기 조회
    /// </summary>
    private void DoBindingTerm()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term();
        DataSet rDs = objBSC.GetMBOList(this.IEstTermRefID, this.IKpiRefID);
        ugrdTerm.DataSource = rDs;
        ugrdTerm.DataBind();
    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnKpiPoolList.Visible = true;
            iBtnAddTarget.Visible = false;
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnConfirm.Visible = false;
            iBtnConfirmCancel.Visible = false;
            iBtnDelete.Visible = false;
            iBtnUsed.Visible = false;
            ImgBtnPrint.Visible = false;
            iBtnTargetFile_Up.Visible = true;
            iBtnTargetFile_Down.Visible = false;
            
            txtKpiCode.ReadOnly = true;
            txtKpiCode.BackColor = Color.WhiteSmoke;
            txtKpiCode.Attributes.Add("onkeydown", "CheckKeyVal(this);");
            txtKpiCode.Attributes.Add("onblur", "isExistsKpi(this);");

        }
        else if (this.IType == "U")
        {
            iBtnKpiPoolList.Visible = false;

            iBtnInsert.Visible = false;
            iBtnUsed.Visible = false;
            ImgBtnPrint.Visible = true;
            iBtnTargetFile_Up.Visible = true;
            iBtnTargetFile_Down.Visible = false;

            txtKpiCode.ReadOnly = true;
            txtKpiCode.BackColor = Color.WhiteSmoke;
            txtKpiCode.Attributes.Remove("onkeydown");
            txtKpiCode.Attributes.Remove("onblur");

            if (this.IApproval_Status == "Y")
            {
                iBtnAddTarget.Visible = false;
                iBtnUpdate.Visible = false;
                iBtnConfirm.Visible = false;
                iBtnConfirmCancel.Visible = true;
                iBtnDelete.Visible = false;
                iBtnUsed.Visible = false;
            }
            else
            {
                iBtnAddTarget.Visible = true;
                iBtnUpdate.Visible = true;
                iBtnConfirm.Visible = true;
                iBtnConfirmCancel.Visible = false;
                iBtnDelete.Visible = true;
                iBtnUsed.Visible = false;
            }

            if (this.IChampion_User_YN == "N")
            {
                iBtnAddTarget.Visible = false;
                iBtnInsert.Visible = false;
                iBtnUpdate.Visible = false;
                iBtnConfirm.Visible = false;
                iBtnConfirmCancel.Visible = false;
                iBtnDelete.Visible = false;
                iBtnUsed.Visible = false;
                iBtnAddTarget.Visible = false;
                iBtnTargetFile_Up.Visible = false;
            }
        }
        else if (this.IType == "D")
        {
            iBtnKpiPoolList.Visible = false;

            iBtnAddTarget.Visible = false;
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnConfirm.Visible = false;
            iBtnConfirmCancel.Visible = false;
            iBtnDelete.Visible = false;
            iBtnUsed.Visible = true;
            iBtnTargetFile_Up.Visible = false;
            iBtnTargetFile_Down.Visible = false;
            
            txtKpiCode.ReadOnly = true;
            txtKpiCode.BackColor = Color.WhiteSmoke;
            txtKpiCode.Attributes.Remove("onkeydown");
            txtKpiCode.Attributes.Remove("onblur");

            if (this.IChampion_User_YN == "N")
            {
                iBtnUsed.Visible = false;
            }
        }
        else
        {
            iBtnAddTarget.Visible = false;
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnConfirm.Visible = false;
            iBtnConfirmCancel.Visible = false;
            iBtnDelete.Visible = false;
            iBtnUsed.Visible = false;
            iBtnTargetFile_Up.Visible = false;
            iBtnTargetFile_Down.Visible = true;
            txtKpiCode.ReadOnly = true;
            txtKpiCode.BackColor = Color.WhiteSmoke;
        }

        // 평가기간이 종료되었거나 결재완료 되었으면 처리불가
        //if (this.IYearlyClose_YN == "Y")
        //{
        //    iBtnAddTarget.Visible = false;
        //    iBtnInsert.Visible = false;
        //    iBtnUpdate.Visible = false;
        //    iBtnConfirm.Visible = false;
        //    iBtnConfirmCancel.Visible = false;
        //    iBtnDelete.Visible = false;
        //    iBtnUsed.Visible = false;
        //    iBtnTargetFile_Up.Visible = false;
        //    iBtnTargetFile_Down.Visible = false;
        //    return;
        //}

        // 어드민인경우 작성중인문서(미작성, 반려) 인경우 해당 문서를 수정가능함
        if (User.IsInRole(ROLE_ADMIN) && this.IApproval_Status == "N")
        {
            iBtnAddTarget.Visible = (this.IType == "U" ? true : false);
            iBtnInsert.Visible = (this.IType == "A" ? true : false);
            iBtnUpdate.Visible = (this.IType == "A" ? false : true);
            iBtnConfirm.Visible = (this.IType == "U" && this.IApproval_Status == "N" ? true : false);
            iBtnConfirmCancel.Visible = (this.IType == "U" && this.IApproval_Status == "Y" ? true : false);
            iBtnDelete.Visible = (this.IType == "U" ? true : false);
            iBtnUsed.Visible = (this.IType == "D" ? true : false);
            iBtnTargetFile_Up.Visible = true;
            iBtnTargetFile_Down.Visible = false;
        }

        iBtnTargetFile_Down.Visible = (hdfTargetReasonFile.Value == "") ? false : true;

        if (this.IType == "U")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Mbo_Kpi_Weight objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Mbo_Kpi_Weight();
            object[,] objRtn = objBSC.GetMboApprovalStateByKpi(this.IEstTermRefID, this.IKpiRefID);
            if (objRtn != null)
            {
                switch (objRtn[0, 0].ToString())
                {
                    case Biz_Type.app_status_draft: // 상신
                        iBtnConfirmCancel.Visible = false;
                        break;
                    case Biz_Type.app_status_ondraft: // 결재중
                        iBtnConfirmCancel.Visible = false;
                        break;
                    case Biz_Type.app_status_complete: // 결재완료
                        iBtnConfirmCancel.Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }

        if (iBtnConfirmCancel.Visible || (!iBtnInsert.Visible && !iBtnUpdate.Visible))
        {
            txtWordDefinition.Visible = false;
            spnWordDefinition.Visible = true;
        }
        else
        {
            txtWordDefinition.Visible = true;
            spnWordDefinition.Visible = false;
        }


        // 골타겟 관련 입력 버튼 (농협에서 추가)
        iBtnGoalTong.Visible = iBtnAddTarget.Visible;

        //if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
        //    iBtnGoalTong.Visible = true;
        iBtnGoalTong.Visible = PageUtility.GetAppConfig("GOALTONG_YN") == "Y" ? true : false;
    }

    #region KPI 마스터 등록/수정, 지표복사
    public bool ValidateForm()
    {
        if (this.IYearlyClose_YN == "1")
        {
            ltrScript.Text = JSHelper.GetAlertScript("해당평가기간은 년마감처리 되었습니다. 수정할수 없습니다.", false);
            return false;
        }
        else if (hdfChampionEmpId.Value.Trim() == "" || hdfChampionEmpId.Value.Trim() == "0")
        {
            ltrScript.Text = JSHelper.GetAlertScript("챔피언을 지정해주십시오.", false);
            return false;
        }
        else if (hdfkpi_target_version_id.Value.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("목표버젼이 존재하지 않습니다.", false);
            return false;
        }
        else if ((this.IType == "U" || this.IType == "D") && txtKpiCode.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("KPI 코드를 입력해주십시오", false);
            return false;
        }

        return true;
    }

    private void DoConfirm(bool isConfirm)
    {
        if (!ValidateForm())
            ltrScript.Text = JSHelper.GetAlertScript("데이터가 올바르지 않습니다.");
        else
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
            int rtnCnt = objBSC.ConfirmMBO(IEstTermRefID, IKpiRefID, isConfirm);

            if (rtnCnt > 0)
                ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
            else
                ltrScript.Text = JSHelper.GetAlertScript("처리하지 못했습니다.");
        }
    }

    private void DoUseYN(string use_yn)
    {
        if (!ValidateForm())
            ltrScript.Text = JSHelper.GetAlertScript("데이터가 올바르지 않습니다.");
        else
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
            int rtnCnt = objBSC.UseYNMBO(IEstTermRefID, IKpiRefID, use_yn);

            if (rtnCnt > 0)
                ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
            else
                ltrScript.Text = JSHelper.GetAlertScript("처리하지 못했습니다.");
        }
    }

    private void DoSaving()
    {
        if (!this.ValidateForm())
            ltrScript.Text = JSHelper.GetAlertScript("데이터가 올바르지 않습니다.");

        DataSet addDS = GetKpiEtcData();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        int rtnRefID = objBSC.InsertMBO(this.IEstTermRefID
                                    , this.IKpiRefID
                                    , txtKpiCode.Text
                                    , this.IKpiPoolRefID
                                    , txtWordDefinition.Value
                                    , txtCalcFormMs.Text
                                    , int.Parse(hdfChampionEmpId.Value)
                                    , PageUtility.GetByValueDropDownList(ddlResultAchievementType)
                                    , PageUtility.GetByValueDropDownList(ddlResultTsCalcType)
                                    , "MAN"
                                    , PageUtility.GetByValueDropDownList(ddlResultMeasurementStep)
                                    , PageUtility.GetByValueDropDownList(ddlMeasurementGradeType)
                                    , PageUtility.GetIntByValueDropDownList(ddlUnit)
                                    , hdfkpi_target_version_id.Value
                                    , txtTargetReason.Text
                                    , hdfTargetReasonFile.Value
                                    , this.IApproval_Status
                                    , "N"
                                    , "N"
                                    , gUserInfo.Emp_Ref_ID
                                    , addDS);


        if (rtnRefID > 0)
        {
            string PreIType = this.IType;
            if (this.IKpiRefID == 0)
            {
                this.IKpiRefID = rtnRefID;
                this.txtKpiCode.Text = rtnRefID.ToString();
                this.IType = "U";
            }

            DoBaseBinding();
            SetButton();

            if (PreIType == "U")
                drawPoint();

            SetInitiativeRow();
            DoSetTarget(false, false);

            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장이 실패하였습니다.");
    }


    private void DoInserting()
    {
        if (!this.ValidateForm())
            ltrScript.Text = JSHelper.GetAlertScript("데이터가 올바르지 않습니다.");

        DataSet addDS = GetKpiEtcData();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        //int rtnRefID = objBSC.InsertMBO(this.IEstTermRefID
        //                            , this.IKpiRefID
        //                            , txtKpiCode.Text
        //                            , this.IKpiPoolRefID
        //                            , txtWordDefinition.Value
        //                            , txtCalcFormMs.Text
        //                            , int.Parse(hdfChampionEmpId.Value)
        //                            , PageUtility.GetByValueDropDownList(ddlResultAchievementType)
        //                            , PageUtility.GetByValueDropDownList(ddlResultTsCalcType)
        //                            , "MAN"
        //                            , PageUtility.GetByValueDropDownList(ddlResultMeasurementStep)
        //                            , PageUtility.GetByValueDropDownList(ddlMeasurementGradeType)
        //                            , PageUtility.GetIntByValueDropDownList(ddlUnit)
        //                            , hdfkpi_target_version_id.Value
        //                            , txtTargetReason.Text
        //                            , hdfTargetReasonFile.Value
        //                            , this.IApproval_Status
        //                            , "N"
        //                            , "N"
        //                            , gUserInfo.Emp_Ref_ID
        //                            , addDS);

        string returnMsg = string.Empty;

        int rtnRefID = objBSC.AddMBO_NW(this.IEstTermRefID
                                    , this.IKpiRefID
                                    , txtKpiCode.Text
                                    , this.IKpiPoolRefID
                                    , txtWordDefinition.Value
                                    , txtCalcFormMs.Text
                                    , int.Parse(hdfChampionEmpId.Value)
                                    , PageUtility.GetByValueDropDownList(ddlResultAchievementType)
                                    , PageUtility.GetByValueDropDownList(ddlResultTsCalcType)
                                    , "MAN"
                                    , PageUtility.GetByValueDropDownList(ddlResultMeasurementStep)
                                    , PageUtility.GetByValueDropDownList(ddlMeasurementGradeType)
                                    , PageUtility.GetIntByValueDropDownList(ddlUnit)
                                    , hdfkpi_target_version_id.Value
                                    , txtTargetReason.Text
                                    , hdfTargetReasonFile.Value
                                    , this.IApproval_Status
                                    , "N"
                                    , "N"
                                    , gUserInfo.Emp_Ref_ID
                                    , addDS
                                    , ref returnMsg);

        if (rtnRefID > 0)
        {
            string PreIType = this.IType;
            if (this.IKpiRefID == 0)
            {
                this.IKpiRefID = rtnRefID;
                this.txtKpiCode.Text = rtnRefID.ToString();
                this.IType = "U";
            }

            DoBaseBinding();
            SetButton();

            //if (PreIType == "U")
                drawPoint();

            SetInitiativeRow();
            DoSetTarget(false, false);

            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
        {
            //ltrScript.Text = JSHelper.GetAlertScript("저장이 실패하였습니다.");
            ltrScript.Text = JSHelper.GetAlertScript(returnMsg);
            return;
        }
    }

    private void DoUpdating()
    {
        if (!this.ValidateForm())
            ltrScript.Text = JSHelper.GetAlertScript("데이터가 올바르지 않습니다.");

        DataSet addDS = GetKpiEtcData();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        //int rtnRefID = objBSC.InsertMBO(this.IEstTermRefID
        //                            , this.IKpiRefID
        //                            , txtKpiCode.Text
        //                            , this.IKpiPoolRefID
        //                            , txtWordDefinition.Value
        //                            , txtCalcFormMs.Text
        //                            , int.Parse(hdfChampionEmpId.Value)
        //                            , PageUtility.GetByValueDropDownList(ddlResultAchievementType)
        //                            , PageUtility.GetByValueDropDownList(ddlResultTsCalcType)
        //                            , "MAN"
        //                            , PageUtility.GetByValueDropDownList(ddlResultMeasurementStep)
        //                            , PageUtility.GetByValueDropDownList(ddlMeasurementGradeType)
        //                            , PageUtility.GetIntByValueDropDownList(ddlUnit)
        //                            , hdfkpi_target_version_id.Value
        //                            , txtTargetReason.Text
        //                            , hdfTargetReasonFile.Value
        //                            , this.IApproval_Status
        //                            , "N"
        //                            , "N"
        //                            , gUserInfo.Emp_Ref_ID
        //                            , addDS);

        string returnMsg = string.Empty;

        int rtnRefID = objBSC.ModifyMBO_NW(this.IEstTermRefID
                                    , this.IKpiRefID
                                    , txtKpiCode.Text
                                    , this.IKpiPoolRefID
                                    , txtWordDefinition.Value
                                    , txtCalcFormMs.Text
                                    , int.Parse(hdfChampionEmpId.Value)
                                    , PageUtility.GetByValueDropDownList(ddlResultAchievementType)
                                    , PageUtility.GetByValueDropDownList(ddlResultTsCalcType)
                                    , "MAN"
                                    , PageUtility.GetByValueDropDownList(ddlResultMeasurementStep)
                                    , PageUtility.GetByValueDropDownList(ddlMeasurementGradeType)
                                    , PageUtility.GetIntByValueDropDownList(ddlUnit)
                                    , hdfkpi_target_version_id.Value
                                    , txtTargetReason.Text
                                    , hdfTargetReasonFile.Value
                                    , this.IApproval_Status
                                    , "N"
                                    , "N"
                                    , gUserInfo.Emp_Ref_ID
                                    , addDS
                                    , ref returnMsg);

        if (rtnRefID > 0)
        {
            string PreIType = this.IType;
            if (this.IKpiRefID == 0)
            {
                this.IKpiRefID = rtnRefID;
                this.txtKpiCode.Text = rtnRefID.ToString();
                this.IType = "U";
            }

            DoBaseBinding();
            SetButton();

            if (PreIType == "U")
                drawPoint();

            SetInitiativeRow();
            DoSetTarget(false, false);

            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
        {
            //ltrScript.Text = JSHelper.GetAlertScript("저장이 실패하였습니다.");
            ltrScript.Text = JSHelper.GetAlertScript(returnMsg);
        }
    }
    #endregion

    public DataSet GetKpiEtcData()
    {
        int intRow = 0;
        DataSet rDS = new DataSet("DS_KPI_MASTER");

        ////////////////////////////////////////////////////
        // KPI TERM 
        ////////////////////////////////////////////////////
        intRow = ugrdTerm.Rows.Count;
        DataTable rDT1 = new DataTable("BSC_KPI_TERM");

        rDT1.Columns.Add("ESTTERM_REF_ID", typeof(int));
        rDT1.Columns.Add("KPI_REF_ID", typeof(int));
        rDT1.Columns.Add("YMD", typeof(string));
        rDT1.Columns.Add("CHECK_YN", typeof(string));
        rDT1.Columns.Add("MS_PLAN", typeof(double));
        rDT1.Columns.Add("TS_PLAN", typeof(double));

        DataRow rDR1;
        CheckBox chkCHECK;
        TemplatedColumn colCHECK = (TemplatedColumn)ugrdTerm.Columns.FromKey("CHECK_YN");
        for (int i = 0; i < intRow; i++)
        {
            rDR1 = rDT1.NewRow();

            chkCHECK = (CheckBox)((CellItem)colCHECK.CellItems[ugrdTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");

            rDR1["ESTTERM_REF_ID"] = (ugrdTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR1["KPI_REF_ID"] = (ugrdTerm.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null) ? this.IKpiRefID : int.Parse(ugrdTerm.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR1["YMD"] = (ugrdTerm.Rows[i].Cells.FromKey("YMD").Value == null) ? "" : ugrdTerm.Rows[i].Cells.FromKey("YMD").Value;
            rDR1["CHECK_YN"] = chkCHECK.Checked ? "Y" : "N";
            rDR1["MS_PLAN"] = (ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Value == null) ? 0 : double.Parse(ugrdTerm.Rows[i].Cells.FromKey("MS_PLAN").Value.ToString());
            rDR1["TS_PLAN"] = (ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value == null) ? 0 : double.Parse(ugrdTerm.Rows[i].Cells.FromKey("TS_PLAN").Value.ToString());

            rDT1.Rows.Add(rDR1);
        }

        ////////////////////////////////////////////////////
        // KPI THRESHOLD 
        ////////////////////////////////////////////////////
        intRow = ugrdSignal.Rows.Count;
        DataTable rDT2 = new DataTable("BSC_KPI_THRESHOLD_INFO");

        rDT2.Columns.Add("ESTTERM_REF_ID", typeof(int));
        rDT2.Columns.Add("KPI_REF_ID", typeof(int));
        rDT2.Columns.Add("THRESHOLD_REF_ID", typeof(int));
        rDT2.Columns.Add("THRESHOLD_LEVEL", typeof(string));
        rDT2.Columns.Add("SET_MIN_VALUE", typeof(double));
        rDT2.Columns.Add("SET_TXT_VALUE", typeof(string));
        rDT2.Columns.Add("SET_MAX_VALUE", typeof(double));
        rDT2.Columns.Add("ACHIEVE_RATE", typeof(double));

        DataRow rDR2;
        for (int i = 0; i < intRow; i++)
        {
            rDR2 = rDT2.NewRow();

            rDR2["ESTTERM_REF_ID"] = (ugrdSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdSignal.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR2["KPI_REF_ID"] = (ugrdSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null) ? this.IKpiRefID : int.Parse(ugrdSignal.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR2["THRESHOLD_REF_ID"] = (ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value == null) ? 0 : int.Parse(ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_REF_ID").Value.ToString());
            rDR2["THRESHOLD_LEVEL"] = (ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value == null) ? "" : ugrdSignal.Rows[i].Cells.FromKey("THRESHOLD_LEVEL").Value;
            rDR2["SET_MIN_VALUE"] = (ugrdSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value.ToString());
            rDR2["SET_TXT_VALUE"] = (ugrdSignal.Rows[i].Cells.FromKey("SET_TXT_VALUE").Value == null) ? "" : ugrdSignal.Rows[i].Cells.FromKey("SET_TXT_VALUE").Value.ToString();
            rDR2["SET_MAX_VALUE"] = (ugrdSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("SET_MAX_VALUE").Value.ToString());
            rDR2["ACHIEVE_RATE"] = (ugrdSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value.ToString());

            rDT2.Rows.Add(rDR2);
        }

        ////////////////////////////////////////////////////
        // KPI INITIATIVE 
        ////////////////////////////////////////////////////
        intRow = ugrdInitiative.Rows.Count;
        DataTable rDT3 = new DataTable("BSC_KPI_INITIATIVE");

        rDT3.Columns.Add("ESTTERM_REF_ID", typeof(int));
        rDT3.Columns.Add("KPI_REF_ID", typeof(int));
        rDT3.Columns.Add("YMD", typeof(string));
        rDT3.Columns.Add("INITIATIVE_PLAN", typeof(string));
        rDT3.Columns.Add("INITIATIVE_DO", typeof(string));
        rDT3.Columns.Add("INITIATIVE_DESC", typeof(string));

        TemplatedColumn tmcPL = null;
        TemplatedColumn tmcDO = null;
        TemplatedColumn tmcDE = null;

        TextBox txtPL = null;
        TextBox txtDO = null;
        TextBox txtDE = null;

        DataRow rDR3;
        for (int i = 0; i < intRow; i++)
        {
            rDR3 = rDT3.NewRow();

            tmcPL = (TemplatedColumn)ugrdInitiative.Rows[i].Band.Columns.FromKey("INITIATIVE_PLAN");
            tmcDO = (TemplatedColumn)ugrdInitiative.Rows[i].Band.Columns.FromKey("INITIATIVE_DO");
            tmcDE = (TemplatedColumn)ugrdInitiative.Rows[i].Band.Columns.FromKey("INITIATIVE_DESC");

            txtPL = (TextBox)((CellItem)tmcPL.CellItems[ugrdInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_PLAN");
            txtDO = (TextBox)((CellItem)tmcDO.CellItems[ugrdInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DO");
            txtDE = (TextBox)((CellItem)tmcDE.CellItems[ugrdInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DESC");

            rDR3["ESTTERM_REF_ID"] = (ugrdInitiative.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdInitiative.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR3["KPI_REF_ID"] = (ugrdInitiative.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null) ? this.IKpiRefID : int.Parse(ugrdInitiative.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR3["YMD"] = (ugrdInitiative.Rows[i].Cells.FromKey("YMD").Value == null) ? "000000" : ugrdInitiative.Rows[i].Cells.FromKey("YMD").Value.ToString();
            rDR3["INITIATIVE_PLAN"] = txtPL.Text; 
            rDR3["INITIATIVE_DO"] = txtDO.Text; 
            rDR3["INITIATIVE_DESC"] = txtDE.Text; 

            rDT3.Rows.Add(rDR3);
        }

        rDS.Tables.Add(rDT1);
        rDS.Tables.Add(rDT2);
        rDS.Tables.Add(rDT3);

        return rDS;
    }

    private void SetCoulumStlye(Worksheet ws, int row, int cell)
    {
        ws.Rows[row].Cells[cell].CellFormat.Font.Height = 250;
        ws.Rows[row].Height = 400;
        ws.Columns[cell].Width = 18 * 256;
        ws.Rows[row].Expanded = true;
    }

    private void CommonDataPrint()
    {
        foreach (Worksheet ws in workBook.Worksheets)
        {
            ws.Rows[0].Cells[0].Value = "KPI 코드 : " + txtKpiCode.Text.Trim();
            ws.Rows[0].Cells[3].Value = "KPI 명 : " + txtKpiName.Text.Trim();
            ws.Rows[1].Cells[0].Value = "KPI 유형 : " + lblKpiType.Text.Trim();
            ws.Rows[1].Cells[3].Value = "지표 분류 : " + lblKpiCatName.Text.Trim();

            SetCoulumStlye(ws, 0, 0);
            SetCoulumStlye(ws, 0, 3);
            SetCoulumStlye(ws, 1, 0);
            SetCoulumStlye(ws, 1, 3);
        }
    }

    private void ExcelDownLoad()
    {
        string strCurDate = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');

        ugrdEEP.ExportMode = ExportMode.Download;
        ugrdEEP.DownloadName = "KPI_DefineDoc" + strCurDate + ".xls";

        AddWorkSheet(); // Sheet추가
    }

    private void AddWorkSheet()
    {
        workBook = new Workbook();

        //Sheet추가 
        workBook.Worksheets.Add("기본정보");
        workBook.Worksheets.Add("주기 및 목표설정");
        workBook.Worksheets.Add("등급구간설정");
        workBook.Worksheets.Add("Initiative 관리");

        workBook.ActiveWorksheet = workBook.Worksheets[0];
        // KPI 기본정보
        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "KPI 담당자 : " + txtChampionEmpName.Text.Trim();
        workBook.ActiveWorksheet.Rows[3].Cells[3].Value = "KPI 측정 유형 : " + ddlResultAchievementType.SelectedItem.Text;
        workBook.ActiveWorksheet.Rows[4].Cells[0].Value = "누적실적유형 : " + ddlResultTsCalcType.SelectedItem.Text;
        workBook.ActiveWorksheet.Rows[4].Cells[3].Value = "구간산정방법 : " + ddlMeasurementGradeType.SelectedItem.Text;
        workBook.ActiveWorksheet.Rows[5].Cells[0].Value = this.GetText("LBL_00003", "평가단계") + " : " + ddlResultMeasurementStep.SelectedItem.Text;
        workBook.ActiveWorksheet.Rows[5].Cells[3].Value = "단위 : " + ddlUnit.SelectedItem.Text;
        workBook.ActiveWorksheet.Rows[6].Cells[0].Value = "지표 및 용어정의 : " + txtWordDefinition.Value;

        SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        SetCoulumStlye(workBook.ActiveWorksheet, 3, 3);
        SetCoulumStlye(workBook.ActiveWorksheet, 4, 0);
        SetCoulumStlye(workBook.ActiveWorksheet, 4, 3);
        SetCoulumStlye(workBook.ActiveWorksheet, 5, 0);
        SetCoulumStlye(workBook.ActiveWorksheet, 5, 3);
        SetCoulumStlye(workBook.ActiveWorksheet, 6, 0);


        workBook.ActiveWorksheet = workBook.Worksheets[1];
        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "주기 및 목표설정";
        SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        ugrdEEP.ExcelStartRow = 5;
        ugrdEEP.Export(ugrdTerm, workBook.ActiveWorksheet);

        workBook.ActiveWorksheet = workBook.Worksheets[2];
        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "측정산식 : " + txtCalcFormMs.Text;
        workBook.ActiveWorksheet.Rows[4].Cells[0].Value = "목표 및 등급구간 설정근거 : " + txtTargetReason.Text;
        SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        SetCoulumStlye(workBook.ActiveWorksheet, 4, 0);

        workBook.ActiveWorksheet.Rows[5].Cells[0].Value = "등급구간";
        SetCoulumStlye(workBook.ActiveWorksheet, 5, 0);
        
        ugrdEEP.ExcelStartRow = (7);
        ugrdEEP.Export(ugrdSignal, workBook.ActiveWorksheet);

        workBook.ActiveWorksheet.Rows[21].Cells[0].Value = null;
        workBook.ActiveWorksheet.Rows[21].Cells[1].Value = null;
        workBook.ActiveWorksheet.Rows[21].Cells[2].Value = null;
        workBook.ActiveWorksheet.Rows[21].Cells[3].Value = null;
        workBook.ActiveWorksheet.Rows[21].Cells[4].Value = null;
        workBook.ActiveWorksheet.Rows[21].Cells[5].Value = null;
        workBook.ActiveWorksheet.Rows[21].Cells[6].Value = null;

        
        // Initiative 관리
        workBook.ActiveWorksheet = workBook.Worksheets[3];
        workBook.ActiveWorksheet.Rows[3].Cells[0].Value = "KPI Initiative 관리";
        this.SetCoulumStlye(workBook.ActiveWorksheet, 3, 0);
        ugrdEEP.ExcelStartRow = 5;
        ugrdEEP.Export(ugrdInitiative, workBook.ActiveWorksheet);
    }

    private void SetInitiativeRow()
    {
        int intRow = ugrdInitiative.Rows.Count;
        int intTermRow = ugrdTerm.Rows.Count;

        string strQTermYmd = "";
        string strETermYmd = "";
        string strECheckYN = "";
        string strCloseYn = "";
        CheckBox chkCheck;
        TemplatedColumn Col_Check;

        TemplatedColumn tmcPL;
        TemplatedColumn tmcDO;
        TemplatedColumn tmcDE;

        TextBox txtPL;
        TextBox txtDO;
        TextBox txtDE;


        for (int i = 0; i < intRow; i++)
        {
            ugrdInitiative.Rows[i].Hidden = true;
            strETermYmd = ugrdInitiative.Rows[i].Cells.FromKey("YMD").Value.ToString();
            for (int j = 0; j < intTermRow; j++)
            {
                strQTermYmd = (ugrdTerm.Rows[j].Cells.FromKey("YMD").Value != null) ? ugrdTerm.Rows[j].Cells.FromKey("YMD").Value.ToString() : "000000";
                Col_Check = (TemplatedColumn)ugrdTerm.Columns.FromKey("CHECK_YN");
                chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[ugrdTerm.Rows[j].BandIndex]).FindControl("chkCheckTerm");
                strECheckYN = (chkCheck.Checked) ? "Y" : "N";
                strCloseYn = (ugrdTerm.Rows[j].Cells.FromKey("CLOSE_YN").Value != null) ? ugrdTerm.Rows[j].Cells.FromKey("CLOSE_YN").Value.ToString() : "N";

                tmcPL = (TemplatedColumn)ugrdInitiative.Columns.FromKey("INITIATIVE_PLAN");
                tmcDO = (TemplatedColumn)ugrdInitiative.Columns.FromKey("INITIATIVE_DO");
                tmcDE = (TemplatedColumn)ugrdInitiative.Columns.FromKey("INITIATIVE_DESC");

                txtPL = (TextBox)((CellItem)tmcPL.CellItems[ugrdInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_PLAN");
                txtDO = (TextBox)((CellItem)tmcDO.CellItems[ugrdInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DO");
                txtDE = (TextBox)((CellItem)tmcDE.CellItems[ugrdInitiative.Rows[i].BandIndex]).FindControl("txtINITIATIVE_DESC");

                if ((strETermYmd == strQTermYmd) && (strECheckYN == "Y"))
                {
                    ugrdInitiative.Rows[i].Hidden = false;
                    txtPL.Enabled = true;
                    txtDO.Enabled = true;
                    txtDE.Enabled = true;

                    break;
                }
            }
        }
    }
}
