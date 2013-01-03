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


public partial class BSC_BSC0302M1M1 : AppPageBase
{
    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
                hdfEstTermRefID.Value = GetRequest("ESTTERM_REF_ID");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
            hdfEstTermRefID.Value = value.ToString();
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

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
                hdfKpiRefID.Value = GetRequest("KPI_REF_ID");
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
            hdfKpiRefID.Value = value.ToString();
        }
    }

    public string IHaveChildKPI_YN
    {
        get
        {
            if (ViewState["HAVE_CHILD_KPI_YN"] == null)
            {
                ViewState["HAVE_CHILD_KPI_YN"] = GetRequest("HAVE_CHILD_KPI_YN");
            }
            return (string)ViewState["HAVE_CHILD_KPI_YN"];
        }
        set
        {
            ViewState["HAVE_CHILD_KPI_YN"] = value;
        }
    }

    public DataTable DT_TERM
    {
        get
        {
            if (ViewState["DT_TERM"] == null)
            {
                ViewState["DT_TERM"] = null;
            }
            return (DataTable)ViewState["DT_TERM"];
        }
        set
        {
            ViewState["DT_TERM"] = value;
        }
    }

    public DataTable DT_TARGET
    {
        get
        {
            if (ViewState["DT_TARGET"] == null)
            {
                ViewState["DT_TARGET"] = null;
            }
            return (DataTable)ViewState["DT_TARGET"];
        }
        set
        {
            ViewState["DT_TARGET"] = value;
        }
    }
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            DoInitializing();

            DoBinding_Term();

            DoLoading_KpiMaster();
            DoLoading_KpiPoolInfo();
            
            DoLoading_KPIBaseInfo();
            //DoLoadingKpiTermGrid();

            DoBinding_KpiTarget();

            if (this.IHaveChildKPI_YN == "Y")
            {
                this.SetTermToTarget(false, false);

            }
            else
            {
                this.SetTermToTarget(false, true);

            }

            DoBinding_KpiGoal();

            if (this.IHaveChildKPI_YN == "Y")
            {
                this.SetTermToGoal(false, false);
                
            }
            else
            {
                this.SetTermToGoal(false, true);
                
            }
        }
        else
        {
        }

        this.InitializeGrid(ugrdPlan);
    }

    private void InitializeGrid(UltraWebGrid grid)
    {
        grid.DisplayLayout.Bands[0].HeaderLayout.Reset();

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in grid.DisplayLayout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "월";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanX = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        //grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = this.GetText("LBL_00012", "Target");
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = this.GetText("LBL_00011", "Goal");  //_itarget_mod_name;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = grid.DisplayLayout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = grid.DisplayLayout.Bands[0].Columns[7].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = grid.DisplayLayout.Bands[0].Columns[8].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanY = 2;

        for (int i = 0; i < grid.DisplayLayout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                grid.DisplayLayout.Bands[0].Columns[i].Width = 80;
                grid.DisplayLayout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            }
            else if (i > 0 && i < 5)
            {
                grid.DisplayLayout.Bands[0].Columns[i].DataType = "System.Double";
                grid.DisplayLayout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,##0.####";
                grid.DisplayLayout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                //grid.DisplayLayout.Bands[0].Columns[i].Width = 100;
                //grid.DisplayLayout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
        }
    }

    private void DoSaving()
    {
        ////////////////////////////////////////////////////
        // KPI TARGET 
        ////////////////////////////////////////////////////
        int intRow = ugrdPlan.Rows.Count;
        int intCol = ugrdPlan.Columns.Count;
        DataTable rDT3 = new DataTable("BSC_KPI_TARGET");

        string strMS = "";
        string strTS = "";
        int intTargetVersion = (hdfkpi_target_version_id.Value == "") ? 0 : int.Parse(hdfkpi_target_version_id.Value);
        //if (hdfinitial_version_yn.Value == "Y")
        {
            strMS = "MS_PLAN";
            strTS = "TS_PLAN";
        }
        //else
        //{
        //    strMS = "MM_PLAN";
        //    strTS = "TM_PLAN";
        //}

        rDT3.Columns.Add("ITYPE",                 typeof(string));
        rDT3.Columns.Add("ESTTERM_REF_ID",        typeof(int));
        rDT3.Columns.Add("KPI_REF_ID",            typeof(int));
        rDT3.Columns.Add("KPI_TARGET_VERSION_ID", typeof(int));
        rDT3.Columns.Add("YMD",                   typeof(string));
        rDT3.Columns.Add("TARGET_MS",             typeof(double));
        rDT3.Columns.Add("TARGET_TS",             typeof(double));

        DataRow rDR3;
        for (int i = 0; i < intRow; i++)
        { 
            rDR3 = rDT3.NewRow();

            //rDR3["ITYPE"]                 = this.IType; //(ugrdPlan.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? "A" : "U";
            rDR3["ITYPE"] = "A";
            rDR3["ESTTERM_REF_ID"]        = (ugrdPlan.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdPlan.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            rDR3["KPI_REF_ID"]            = (ugrdPlan.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)     ? this.IKpiRefID     : int.Parse(ugrdPlan.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            rDR3["KPI_TARGET_VERSION_ID"] = intTargetVersion; //(ugrdPlan.Rows[i].Cells.FromKey("KPI_TARGET_VERSION_ID").Value == null) ? intTargetVersion : ugrdPlan.Rows[i].Cells.FromKey("KPI_TARGET_VERSION_ID").Value;
            rDR3["YMD"]                   = (ugrdPlan.Rows[i].Cells.FromKey("YMD").Value == null)            ? "" : ugrdPlan.Rows[i].Cells.FromKey("YMD").Value; 
            rDR3["TARGET_MS"]             = (ugrdPlan.Rows[i].Cells.FromKey(strMS).Value == null)            ? 0  : double.Parse(ugrdPlan.Rows[i].Cells.FromKey(strMS).Value.ToString());
            rDR3["TARGET_TS"]             = (ugrdPlan.Rows[i].Cells.FromKey(strTS).Value == null)            ? 0  : double.Parse(ugrdPlan.Rows[i].Cells.FromKey(strTS).Value.ToString());

            rDT3.Rows.Add(rDR3);
        }

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target_Goal bizBscKpiTargetGoal = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target_Goal();

        string msg = bizBscKpiTargetGoal.AddBscKpiTargetGoal_DB(rDT3
                                                              , IEstTermRefID
                                                              , IKpiRefID
                                                              , intTargetVersion
                                                              , this.gUserInfo.Emp_Ref_ID);

        if (msg.Equals(string.Empty))
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.", false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리시 오류가 발생되었습니다.", false);
        }
    }


    private void DoInitializing()
    {
        Biz_EtcCodeInfos objCode = new Biz_EtcCodeInfos();
        //objCode.getResultMethod(ddlResultInputType, "", false, 100);
        //objCode.getTermType(ddlResultTermType, "", false, 100);
        objCode.getPNUType(ddlResultAchievementType, "", false,0);
        objCode.getColTargetType(ddlResultTsCalcType, "", false, 0);
        objCode.getCheckStep(ddlResultMeasurementStep, "", false, 0);
        objCode.getCheckType(ddlMeasurementGradeType, "", false, 0);
        WebCommon.SetUnitTypeDropDownList(ddlUnit, false);

        txtKpiCode.Enabled = false;
        ddlResultAchievementType.Enabled = false;
        ddlResultTsCalcType.Enabled = false;
        ddlResultMeasurementStep.Enabled = false;
        ddlMeasurementGradeType.Enabled = false;
        ddlUnit.Enabled = false;
    }

    /// <summary>
    /// 측정주기 조회
    /// </summary>
    private void DoLoadingKpiTermGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID);
        ugrdTerm.DataSource = rDs;
        ugrdTerm.DataBind();
    }

    private void DoLoading_KPIBaseInfo()
    {
        //-------------------- KPI Status Setting
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiStatus(this.IEstTermRefID, this.IKpiRefID, gUserInfo.Emp_Ref_ID);

        if (rDs.Tables[0].Rows.Count > 0)
        {

            //this.IConfirm_YN                    = rDs.Tables[0].Rows[0]["CONFIRM_YN"].ToString();
            //this.IChampion_User_YN              = rDs.Tables[0].Rows[0]["CHAMPION_EMP_YN"].ToString();
            //this.IApporval_User_YN              = rDs.Tables[0].Rows[0]["APPROVAL_EMP_YN"].ToString();
            this.hdfinitial_version_yn.Value    = rDs.Tables[0].Rows[0]["INITIAL_VERSION_YN"].ToString();
            this.hdfkpi_target_version_id.Value = rDs.Tables[0].Rows[0]["KPI_TARGET_VERSION_ID"].ToString();
            //this.ISaveRecord_YN                 = rDs.Tables[0].Rows[0]["INSERT_YN"].ToString();
            this.IHaveChildKPI_YN = rDs.Tables[0].Rows[0]["HAVE_CHILD_KPI_YN"].ToString();
            //this.IHaveInitive_YN                = rDs.Tables[0].Rows[0]["HAVE_INITIATIVE_YN"].ToString();
            //this.IMonthly_Close_Day             = int.Parse(rDs.Tables[0].Rows[0]["MONTHLY_CLOSE_DAY"].ToString());
            //this.IScoreValuationType            = rDs.Tables[0].Rows[0]["SCORE_VALUATION_TYPE"].ToString();
            //this.IEsttermUseYN                  = rDs.Tables[0].Rows[0]["ESTTERM_USE_YN"].ToString();
            //this.IYearlyClose_YN                = rDs.Tables[0].Rows[0]["YEARLY_CLOSE_YN"].ToString();
            //this.IMonthlyCloseType              = rDs.Tables[0].Rows[0]["MONTHLY_CLOSE_TYPE"].ToString();

            //if (this.IHaveInitive_YN == "Y")
            //{
            //    ugrdBInitiative.Visible = false;
            //    pnlBPrj.Visible         = true;
            //    ugrdBInitiative.Clear();
            //    this.SetProjectList();
            //}
            //else
            //{ 
            //    ugrdBInitiative.Visible = true;
            //    pnlBPrj.Visible         = false;
            //    ugrdBPrjList.Clear();
            //    this.SetInitiativeList();
            //}
        }
    }

    private void DoLoading_KpiMaster()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        //txtBCalcFormMs.Text                     = objBSC.Icalc_form_ms;               
        //txtBCalcFormTs.Text                     = objBSC.Icalc_form_ts;
        //this.IDraftEmpID                        = objBSC.Ichampion_emp_id;
        //hdfBChampionEmpId.Value                 = objBSC.Ichampion_emp_id.ToString();
        //txtBChampionEmpName.Text                = objBSC.Ichampion_emp_name;          
        ////hdfBApprovalEmpId.Value                 = objBSC.Iapproval_emp_id.ToString(); 
        ////txtBApprovalEmpName.Text                = objBSC.Iapproval_emp_name;
        //hdfBMeasurementEmpId.Value              = objBSC.Imeasurement_emp_id.ToString();
        //txtBMeasurementEmpName.Text             = objBSC.Imeasurement_emp_name;                
        //txtBGetheringMethod.Text                = objBSC.Idata_gethering_method;      
        //txtBRelatedIssue.Text                   = objBSC.Irelated_issue;              
        txtKpiCode.Text                         = objBSC.Ikpi_code;                   
        //txtBMeasurementPurpose.Text             = objBSC.Imeasurement_purpose;        
        //txtBWordDefinition.Text                 = objBSC.Iword_definition;
        //ddlResultInputType.SelectedValue       = objBSC.Iresult_input_type;
        ddlResultAchievementType.SelectedValue = objBSC.Iresult_achievement_type;
        ddlResultTsCalcType.SelectedValue      = objBSC.Iresult_ts_calc_type;
        ddlMeasurementGradeType.SelectedValue  = objBSC.Imeasurement_grade_type;
        ddlResultMeasurementStep.SelectedValue = objBSC.Iresult_measurement_step;
        ddlUnit.SelectedValue                  = objBSC.Iunit_type_ref_id.ToString();
        //ddlResultTermType.SelectedValue        = objBSC.Iresult_term_type;
        //txtBTargetReason.Text                   = objBSC.Ikpi_target_setting_reason;
        //hdfTargetReasonFile.Value               = objBSC.Ikpi_target_reason_file;
        //this.IApp_Ref_Id                        = objBSC.Iapp_ref_id;
        //this.IKpi_Use_Yn                        = objBSC.Iuse_yn;

        //this.IKpiPoolRefID                      = objBSC.Ikpi_pool_ref_id;
        //if (objBSC.Iuse_yn == "N")
        //{
        //    this.IType = "D";
        //}

    }

    /// <summary>
    /// 지표풀정보 세팅
    /// </summary>
    private void DoLoading_KpiPoolInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objPool = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        lblKpiType.Text = objPool.Ikpi_external_type_name + "/" + objPool.Ikpi_type_name;
        //this.IKpiGroup = objPool.Ikpi_type;
        //this.IBasis_Use_Yn = objPool.Ibasis_use_yn;
        //txtKpiCode.Text = objPool.Ikpi_pool_ref_id.ToString();          
        this.txtKpiName.Text = objPool.Ikpi_name;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objL = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low(objPool.Icategory_top_ref_id, objPool.Icategory_mid_ref_id, objPool.Icategory_low_ref_id);
        this.lblKpiCatName.Text = objL.Icategory_top_name + " / " + objL.Icategory_mid_name + " / " + objL.Icategory_low_name;

    }

    /// <summary>
    /// 목표 조회
    /// </summary>
    private void DoBinding_KpiGoal()
    {
        
        

        

        ugrdPlan.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target_Goal bizBscKpiTargetGoal = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target_Goal();

        DataTable dtBscKpiTargetGoal = bizBscKpiTargetGoal.GetBscKpiTargetGoal_DB(this.IEstTermRefID, this.IKpiRefID, 1);

        DataTable dtTemp = dtBscKpiTargetGoal;
        if (dtBscKpiTargetGoal.Rows.Count == 0)
        {
            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Term_Detail bizBscTermDetail = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Term_Detail();
            DataTable dtBscTermDetail = bizBscTermDetail.GetBscTermDetail_DB(this.IEstTermRefID, this.IKpiRefID);

            dtTemp = dtBscTermDetail;

        }

        
        ugrdPlan.DataSource = dtTemp;
        ugrdPlan.DataBind();
    }

    private void DoBinding_Term()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term biz = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Term();
        DT_TERM = biz.GetAllList(this.IEstTermRefID, this.IKpiRefID).Tables[0];
        ugrdTerm.DataSource = DT_TERM;
        ugrdTerm.DataBind();

    }

    private void DoBinding_KpiTarget()
    {
        ugrdBPlan.Clear();

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Target objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Target();
        DT_TARGET = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID, 1).Tables[0];
        ugrdBPlan.DataSource = DT_TARGET;
        ugrdBPlan.DataBind();
    }

    #region ================================= [ 실적누계계산 관련 메소드 ]======================
    // isAddTargetYN : 목표가 추가되어 그리드다시세팅여부
    // isCalcYN      : 산식에 의해 셀계산할것인지 여부
    private void SetTermToGoal(bool isAddTargetYN, bool isCalcYN)
    {
        if (ugrdPlan.Rows.Count < 1)
        {
            return;
        }

        int intCol = ugrdTerm.Columns.Count;
        int intRow = ugrdTerm.Rows.Count;
        int intChkRow = 0;
        string strMS_PLAN = "";
        string strTS_PLAN = "";
        string strCheck = "";
        double dblTot = 0.00;
        string _icheck_term = "";
        string strCloseYn = "";


        if (!isAddTargetYN)
        {
            //this.SetKPIBaseInfo();
        }

        ugrdPlan.Columns.FromKey("YMD_DESC").AllowUpdate = AllowUpdate.No;
        ugrdPlan.Columns.FromKey("YMD_DESC").CellStyle.BackColor = Color.WhiteSmoke;
        if (this.hdfinitial_version_yn.Value == "Y")
        {
            strMS_PLAN = "MS_PLAN";
            strTS_PLAN = "TS_PLAN";
            strCheck = "ORI_CHECK_YN";
            ugrdPlan.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdPlan.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdPlan.Columns.FromKey("MM_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdPlan.Columns.FromKey("TM_PLAN").AllowUpdate = AllowUpdate.No;

            ugrdPlan.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.White;
            ugrdPlan.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.White;
            ugrdPlan.Columns.FromKey("MM_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdPlan.Columns.FromKey("TM_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
        }
        else
        {
            strMS_PLAN = "MM_PLAN";
            strTS_PLAN = "TM_PLAN";
            strCheck = "MOD_CHECK_YN";
            ugrdPlan.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdPlan.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdPlan.Columns.FromKey("MM_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdPlan.Columns.FromKey("TM_PLAN").AllowUpdate = AllowUpdate.Yes;

            ugrdPlan.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdPlan.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdPlan.Columns.FromKey("MM_PLAN").CellStyle.BackColor = Color.White;
            ugrdPlan.Columns.FromKey("TM_PLAN").CellStyle.BackColor = Color.White;
        }

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
                dblTot += double.Parse(ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value.ToString());
                intChkRow += 1;
            }


            if (ugrdPlan.Rows[i] != null)
            {
                ugrdPlan.Rows[i].Cells.FromKey(strCheck).Value = _icheck_term;


                if (strCloseYn == "Y")
                {
                    ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing = AllowEditing.No;
                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                    ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = Color.WhiteSmoke;
                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    if (_icheck_term == "N")
                    {
                        ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing = AllowEditing.No;
                        ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                        ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = Color.WhiteSmoke;
                        ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = Color.WhiteSmoke;
                        ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value = 0;
                        ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = 0;

                        switch (PageUtility.GetByValueDropDownList(ddlResultTsCalcType))
                        {
                            case "SUM": // 단순합계
                                ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = Math.Round(dblTot, 5);
                                break;
                            case "AVG": // 단순평균
                                ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (this.hdfinitial_version_yn.Value == "Y")
                        {
                            ugrdPlan.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdPlan.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdPlan.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.White;
                            ugrdPlan.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.White;

                            ugrdPlan.Rows[i].Cells.FromKey("MM_PLAN").AllowEditing = AllowEditing.No;
                            ugrdPlan.Rows[i].Cells.FromKey("TM_PLAN").AllowEditing = AllowEditing.No;
                            ugrdPlan.Rows[i].Cells.FromKey("MM_PLAN").Style.BackColor = Color.WhiteSmoke;
                            ugrdPlan.Rows[i].Cells.FromKey("TM_PLAN").Style.BackColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            ugrdPlan.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.No;
                            ugrdPlan.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                            ugrdPlan.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.WhiteSmoke;
                            ugrdPlan.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.WhiteSmoke;

                            ugrdPlan.Rows[i].Cells.FromKey("MM_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdPlan.Rows[i].Cells.FromKey("TM_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdPlan.Rows[i].Cells.FromKey("MM_PLAN").Style.BackColor = Color.White;
                            ugrdPlan.Rows[i].Cells.FromKey("TM_PLAN").Style.BackColor = Color.White;
                        }

                        

                        if (isCalcYN)
                        {
                            switch (PageUtility.GetByValueDropDownList(ddlResultTsCalcType))
                            {
                                case "SUM": // 단순합계
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = Math.Round(dblTot, 5);
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "AVG": // 단순평균
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "OTS": // 누적만측정
                                    ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing = AllowEditing.No;
                                    ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    ugrdPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value = 0;
                                    break;
                                default:
                                    //ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value          = 0;
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    break;
                            }
                        }
                    }
                }


                ugrdPlan.Rows[i].Cells.FromKey("CHECK_YN").AllowEditing = AllowEditing.No;
                ugrdPlan.Rows[i].Cells.FromKey("CHECK_YN").Style.BackColor = Color.WhiteSmoke;

                ugrdPlan.Rows[i].Cells.FromKey("REPORT_YN").AllowEditing = AllowEditing.No;
                ugrdPlan.Rows[i].Cells.FromKey("REPORT_YN").Style.BackColor = Color.WhiteSmoke;

                ugrdPlan.Rows[i].Cells.FromKey("CLOSE_YN").AllowEditing = AllowEditing.No;
                ugrdPlan.Rows[i].Cells.FromKey("CLOSE_YN").Style.BackColor = Color.WhiteSmoke;

                ugrdPlan.Rows[i].Cells.FromKey("MS_TARGET").AllowEditing = AllowEditing.No;
                ugrdPlan.Rows[i].Cells.FromKey("MS_TARGET").Style.BackColor = Color.WhiteSmoke;

                ugrdPlan.Rows[i].Cells.FromKey("TS_TARGET").AllowEditing = AllowEditing.No;
                ugrdPlan.Rows[i].Cells.FromKey("TS_TARGET").Style.BackColor = Color.WhiteSmoke;
            }
        }

    }
    #endregion

    protected void ugrdPlan_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //e.Layout.Bands[0].HeaderLayout.Reset();

        //int iIndex = 0;
        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        //foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        //{
        //    c.Header.RowLayoutColumnInfo.OriginY = 1;
        //    c.Header.RowLayoutColumnInfo.OriginX = iIndex;
        //    iIndex++;
        //}

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "월";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanX = 1;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "당초계획" ;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 1;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "수정계획";  //_itarget_mod_name;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 3;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        //ch = e.Layout.Bands[0].Columns[0].Header;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 0;
        //ch.RowLayoutColumnInfo.SpanY = 2;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                //e.Layout.Bands[0].Columns[i].Width = 50;
                //e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else if (i > 0 && i < 5)
            {
                e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.#####";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                //e.Layout.Bands[0].Columns[i].Hidden = true;
            }
        }
    }

    protected void ugrdPlan_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells.FromKey("CHECK_YN").Value = DT_TERM.Rows[e.Row.Index]["CHECK_YN"];
        e.Row.Cells.FromKey("REPORT_YN").Value = DT_TERM.Rows[e.Row.Index]["REPORT_YN"];
        e.Row.Cells.FromKey("CLOSE_YN").Value = DT_TERM.Rows[e.Row.Index]["CLOSE_YN"];

        e.Row.Cells.FromKey("MS_TARGET").Value = ugrdBPlan.Rows[e.Row.Index].Cells.FromKey("MS_PLAN").Value;
        e.Row.Cells.FromKey("TS_TARGET").Value = ugrdBPlan.Rows[e.Row.Index].Cells.FromKey("TS_PLAN").Value;
    }


    protected void ugrdTerm_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void ugrdTerm_InitializeRow(object sender, RowEventArgs e)
    {
        CheckBox chkCheck;
        CheckBox chkReport;

        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("CHECK_YN");
        TemplatedColumn Col_Report = (TemplatedColumn)e.Row.Band.Columns.FromKey("REPORT_YN");


        chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("chkCheckTerm");
        chkReport = (CheckBox)((CellItem)Col_Report.CellItems[e.Row.BandIndex]).FindControl("chkReportTerm");

        chkCheck.Checked = (e.Row.Cells.FromKey("CHECK_YN").Value.ToString() == "Y") ? true : false;
        chkReport.Checked = (e.Row.Cells.FromKey("REPORT_YN").Value.ToString() == "Y") ? true : false;

        chkCheck.Enabled = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;
        chkReport.Enabled = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;

        chkCheck.Attributes.Add("onclick", string.Format("checkInitPlan(this, '{0}', '{1}')", ugrdTerm.ClientID, ugrdPlan.ClientID));
    }

    //---------------------- 마스터 입력/수정/삭제
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DoSaving();
    }


    private void SetTermToTarget(bool isAddTargetYN, bool isCalcYN)
    {
        if (ugrdBPlan.Rows.Count < 1)
        {
            return;
        }

        int intCol = ugrdTerm.Columns.Count;
        int intRow = ugrdTerm.Rows.Count;
        int intChkRow = 0;
        string strMS_PLAN = "";
        string strTS_PLAN = "";
        string strCheck = "";
        double dblTot = 0.00;
        string _icheck_term = "";
        string strCloseYn = "";


        if (!isAddTargetYN)
        {
            //this.SetKPIBaseInfo();
        }

        ugrdBPlan.Columns.FromKey("YMD_DESC").AllowUpdate = AllowUpdate.No;
        ugrdBPlan.Columns.FromKey("YMD_DESC").CellStyle.BackColor = Color.WhiteSmoke;
        if (this.hdfinitial_version_yn.Value == "Y")
        {
            strMS_PLAN = "MS_PLAN";
            strTS_PLAN = "TS_PLAN";
            strCheck = "ORI_CHECK_YN";
            ugrdBPlan.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdBPlan.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdBPlan.Columns.FromKey("MM_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdBPlan.Columns.FromKey("TM_PLAN").AllowUpdate = AllowUpdate.No;

            ugrdBPlan.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.White;
            ugrdBPlan.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.White;
            ugrdBPlan.Columns.FromKey("MM_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdBPlan.Columns.FromKey("TM_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
        }
        else
        {
            strMS_PLAN = "MM_PLAN";
            strTS_PLAN = "TM_PLAN";
            strCheck = "MOD_CHECK_YN";
            ugrdBPlan.Columns.FromKey("MS_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdBPlan.Columns.FromKey("TS_PLAN").AllowUpdate = AllowUpdate.No;
            ugrdBPlan.Columns.FromKey("MM_PLAN").AllowUpdate = AllowUpdate.Yes;
            ugrdBPlan.Columns.FromKey("TM_PLAN").AllowUpdate = AllowUpdate.Yes;

            ugrdBPlan.Columns.FromKey("MS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdBPlan.Columns.FromKey("TS_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            ugrdBPlan.Columns.FromKey("MM_PLAN").CellStyle.BackColor = Color.White;
            ugrdBPlan.Columns.FromKey("TM_PLAN").CellStyle.BackColor = Color.White;
        }

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
                dblTot += double.Parse(ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value.ToString());
                intChkRow += 1;
            }


            if (ugrdBPlan.Rows[i] != null)
            {
                ugrdBPlan.Rows[i].Cells.FromKey(strCheck).Value = _icheck_term;

                if (strCloseYn == "Y")
                {
                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing = AllowEditing.No;
                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = Color.WhiteSmoke;
                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    if (_icheck_term == "N")
                    {
                        ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing = AllowEditing.No;
                        ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                        ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = Color.WhiteSmoke;
                        ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = Color.WhiteSmoke;
                        ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value = 0;
                        ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = 0;

                        switch (PageUtility.GetByValueDropDownList(ddlResultTsCalcType))
                        {
                            case "SUM": // 단순합계
                                ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = Math.Round(dblTot, 5);
                                break;
                            case "AVG": // 단순평균
                                ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (this.hdfinitial_version_yn.Value == "Y")
                        {
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.White;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.White;

                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").AllowEditing = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").AllowEditing = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").Style.BackColor = Color.WhiteSmoke;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").Style.BackColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").AllowEditing = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").AllowEditing = AllowEditing.No;
                            ugrdBPlan.Rows[i].Cells.FromKey("MS_PLAN").Style.BackColor = Color.WhiteSmoke;
                            ugrdBPlan.Rows[i].Cells.FromKey("TS_PLAN").Style.BackColor = Color.WhiteSmoke;

                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").AllowEditing = AllowEditing.Yes;
                            ugrdBPlan.Rows[i].Cells.FromKey("MM_PLAN").Style.BackColor = Color.White;
                            ugrdBPlan.Rows[i].Cells.FromKey("TM_PLAN").Style.BackColor = Color.White;
                        }

                        if (isCalcYN)
                        {
                            switch (PageUtility.GetByValueDropDownList(ddlResultTsCalcType))
                            {
                                case "SUM": // 단순합계
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = Math.Round(dblTot, 5);
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "AVG": // 단순평균
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value = (intChkRow == 0) ? dblTot : Math.Round((dblTot / intChkRow), 5);
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = AllowEditing.No;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                case "OTS": // 누적만측정
                                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).AllowEditing = AllowEditing.No;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Style.BackColor = System.Drawing.Color.WhiteSmoke;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strMS_PLAN).Value = 0;
                                    break;
                                default:
                                    //ugrdPlan.Rows[i].Cells.FromKey(strTS_PLAN).Value          = 0;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).AllowEditing = (_icheck_term == "N") ? AllowEditing.No : AllowEditing.Yes;
                                    ugrdBPlan.Rows[i].Cells.FromKey(strTS_PLAN).Style.BackColor = (_icheck_term == "N") ? System.Drawing.Color.WhiteSmoke : System.Drawing.Color.White;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
    
}

