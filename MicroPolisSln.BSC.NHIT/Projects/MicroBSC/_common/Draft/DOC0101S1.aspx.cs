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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

using Infragistics.WebUI.UltraWebGrid;
using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.BSC.Biz;

public partial class _common_Draft_DOC0101S1 : AppPageBase
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

    public string IisTeamKpi
    {
        get
        {
            if (ViewState["IS_TEAM_KPI"] == null)
            {
                ViewState["IS_TEAM_KPI"] = GetRequest("IS_TEAM_KPI", "Y");
            }

            return (string)ViewState["IS_TEAM_KPI"];
        }
        set
        {
            ViewState["IS_TEAM_KPI"] = value;
        }
    }

    public string ISaveRecord_YN
    {
        get
        {
            if (ViewState["INSERT_YN"] == null)
            {
                ViewState["INSERT_YN"] = GetRequestByInt("INSERT_YN", 0);
            }

            return (string)ViewState["INSERT_YN"];
        }
        set
        {
            ViewState["INSERT_YN"] = value;
        }
    }

    public string IConfirm_YN
    {
        get
        {
            if (ViewState["APPROVAL_STATUS"] == null)
            {
                ViewState["APPROVAL_STATUS"] = GetRequest("APPROVAL_STATUS");
            }
            return (string)ViewState["APPROVAL_STATUS"];
        }
        set
        {
            ViewState["APPROVAL_STATUS"] = value;
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

    public string IApporval_User_YN
    {
        get
        {
            if (ViewState["APPROVAL_EMP_YN"] == null)
            {
                ViewState["APPROVAL_EMP_YN"] = GetRequest("APPROVAL_EMP_YN");
            }
            return (string)ViewState["APPROVAL_EMP_YN"];
        }
        set
        {
            ViewState["APPROVAL_EMP_YN"] = value;
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
        }
    }

    public string IMeasurementStep
    {
        get
        {
            if (ViewState["MEASUREMENTSTEP"] == null)
            {
                ViewState["MEASUREMENTSTEP"] = GetRequest("MEASUREMENTSTEP");
            }
            return (string)ViewState["MEASUREMENTSTEP"];
        }
        set
        {
            ViewState["MEASUREMENTSTEP"] = value;
        }
    }

    public int startYY = 0;
    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitControl();
            this.SetKPIMaster();
            this.SetKpiDataSourceGrid();
            this.SetKpiTargetGrid();
            this.SetKpiSignalGrid();
            this.SetInitiativeList();
        }
    }

    #region ================================= [ Data Select ]===================================
    private void SetInitControl()
    {
        
    }
    
    private void SetKPIMaster()
    {
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        lblCalcFormMs.Text            = objBSC.Icalc_form_ms;
        lblCalcFormTs.Text            = objBSC.Icalc_form_ts;
        lblChampionEmpName.Text       = objBSC.Ichampion_emp_name;
        lblMeasurementEmpName.Text    = objBSC.Imeasurement_emp_name;
        lblDataGetheringMethod.Text   = objBSC.Idata_gethering_method;
        lblKpiCode.Text               = objBSC.Ikpi_code;
        lblWordDefinition.Text        = PageUtility.GetHtmlEncodeChar(objBSC.Iword_definition);
        lblResultInputType.Text       = objBSC.Iresult_input_type_name;
        lblResultAchievementType.Text = objBSC.Iresult_achievement_type_name;
        lblResultTsCalcType.Text      = objBSC.Iresult_ts_calc_type_name;
        lblMeasurementGradeType.Text  = objBSC.Imeasurement_grade_type_name;
        lblUnit.Text                  = objBSC.Iunit_name;
        lblResultMeasurementStep.Text = objBSC.Iresult_measurement_step_name;
        this.IMeasurementStep         = objBSC.Iresult_measurement_step;
        lblTargetReason.Text          = PageUtility.GetHtmlEncodeChar(objBSC.Ikpi_target_setting_reason);

        //txtBWordDefinition.Text                 = objBSC.Iword_definition;
        //ddlBResultInputType.SelectedValue       = objBSC.Iresult_input_type;
        //ddlBResultAchievementType.SelectedValue = objBSC.Iresult_achievement_type;
        //ddlBResultTsCalcType.SelectedValue = objBSC.Iresult_ts_calc_type;
        //ddlBMeasurementGradeType.SelectedValue = objBSC.Imeasurement_grade_type;
        //ddlBResultMeasurementStep.SelectedValue = objBSC.Iresult_measurement_step;
        //ddlBUnit.SelectedValue = objBSC.Iunit_type_ref_id.ToString();
        //ddlBResultTermType.SelectedValue = objBSC.Iresult_term_type;
        //txtBTargetReason.Text = objBSC.Ikpi_target_setting_reason;
        hdfTargetReasonFile.Value = objBSC.Ikpi_target_reason_file;



        this.IKpiPoolRefID = objBSC.Ikpi_pool_ref_id;
        if (objBSC.Iuse_yn == "N")
        {
            this.IType = "D";
        }

        this.SetKpiPoolInfo();
    }

    private void SetKpiPoolInfo()
    {
        Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        lblKpiType.Text = objPool.Ikpi_external_type_name + "/" + objPool.Ikpi_type_name;
        //this.IKpiGroup = objPool.Ikpi_type;
        //this.IBasis_Use_Yn = objPool.Ibasis_use_yn;
        this.lblKpiName.Text = objPool.Ikpi_name;

        //Biz_Bsc_Kpi_Category_Low objL = new Biz_Bsc_Kpi_Category_Low(objPool.Icategory_top_ref_id, objPool.Icategory_mid_ref_id, objPool.Icategory_low_ref_id);
        //this.lblKpiCatName.Text = objL.Icategory_top_name + " / " + objL.Icategory_mid_name + " / " + objL.Icategory_low_name;

        //this.ugrdKpiStatusTab.Tabs.FromKey("5").Visible = (this.IBasis_Use_Yn == "EQL") ? true : false;    // 정성지표인경우 
    }

    private void SetKpiDataSourceGrid()
    {
        Biz_Bsc_Kpi_Datasource objBSC = new Biz_Bsc_Kpi_Datasource();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID);

        grvDataSource.DataSource = rDs.Tables[0].DefaultView;
        grvDataSource.DataBind();
        //ugrdBDetail.Clear();
        //ugrdBDetail.DataSource = rDs;
        //ugrdBDetail.DataBind();
    }

    private void SetKpiTargetGrid()
    {
        Biz_Bsc_Kpi_Target objBSC = new Biz_Bsc_Kpi_Target();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID, 1);

        grvTarget.DataSource = rDs.Tables[0].DefaultView;
        grvTarget.DataBind();

        grvTarget.Columns[6].Visible = false;
        grvTarget.Columns[7].Visible = false;
    }

    private void SetKpiNewTargetGrid()
    {
        //Biz_Bsc_Kpi_Target objBSC = new Biz_Bsc_Kpi_Target();
        //DataSet rDs = objBSC.GetNewTargetList(this.IEstTermRefID, this.IKpiRefID, intTargetVersion);
        //ugrdBPlan.Clear();
        //ugrdBPlan.DataSource = rDs;
        //ugrdBPlan.DataBind();
    }

    private void SetKpiSignalGrid()
    {
        Biz_Bsc_Kpi_Threshold_Info objBSC = new Biz_Bsc_Kpi_Threshold_Info();
        //DataSet dsSignal = objBSC.GetSignalListPerKpi(this.IEstTermRefID, this.IKpiRefID, this.IMeasurementStep);
        DataSet dsSignal = objBSC.GetSignalListPerKpiWithBiz(this.IEstTermRefID, this.IKpiRefID, this.IMeasurementStep);

        grvSignal.DataSource = dsSignal.Tables[0].DefaultView;
        grvSignal.DataBind();

        //ugrdSignal.Clear();
        //ugrdSignal.Rows.Clear();
        //ugrdSignal.DataSource = dsSignal;
        //ugrdSignal.DataBind();
        this.drawGrade();

        startYY = 0;
        DataSet dsTRStatus = objBSC.GetTargetResultPerYear(this.IEstTermRefID, this.IKpiRefID, out startYY);
        //ugrdTRStatus.Clear();
        //ugrdTRStatus.DataSource = dsTRStatus;
        //ugrdTRStatus.DataBind();
    }

    #region ================================= [ 그래프 그리기 ]=================================
    private void drawGrade()
    {
        DundasCharts.DundasChartBase(chartScore, ChartImageType.Png, 350, 170
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        startYY = 0;
        Biz_Bsc_Kpi_Threshold_Info objBSC = new Biz_Bsc_Kpi_Threshold_Info();
        DataSet dsLine = objBSC.GetTargetPerGrade(this.IEstTermRefID, this.IKpiRefID, out startYY);
        int cntRow = dsLine.Tables[0].Rows.Count;
        int cntCol = dsLine.Tables[0].Columns.Count;

        if (startYY < 1)
        {
            return;
        }

        try
        {
            //================================================================== LINE GRAPH
            for (int i = cntCol - 1; i > 0; i--)
            {
                dsLine.Tables[0].Columns[i].ColumnName = dsLine.Tables[0].Columns[i].ColumnName.Substring(0, 2) == "YY"
                                                       ? Convert.ToString(startYY) + "년"
                                                       : dsLine.Tables[0].Columns[i].ColumnName;

                startYY = startYY - 1;
            }

            Series[] oasrType = new Series[cntRow];
            int intLP = 0;


            for (int i = 0; i < cntRow; i++)
            {
                oasrType[intLP] = DundasCharts.CreateSeries
                                 (chartScore, "Series" + intLP.ToString(), chartScore.ChartAreas[0].Name,
                                  dsLine.Tables[0].Rows[i]["THRESHOLD_ENAME"].ToString(), null, (i == 0) ? SeriesChartType.Column : SeriesChartType.Line, (i == 0) ? 0 : 3,
                                  (intLP == 0) ? Color.Blue : GetSignalColor(intLP - 1), GetChartColor(intLP),
                                  Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

                for (int j = 2; j < cntCol; j++)
                {
                    oasrType[intLP].Points.AddXY(dsLine.Tables[0].Columns[j].ColumnName
                                                , double.Parse(dsLine.Tables[0].Rows[i][j].ToString()));
                }

                intLP += 1;
            }

            if (intLP > 0)
            {
                oasrType[intLP - 1].ValueMemberX = "THRESHOLD_ENAME";
            }

            string strVirDir = Request.CurrentExecutionFilePath;
                   strVirDir = strVirDir.Substring(0, strVirDir.LastIndexOf('/'));
            string strCurDir = Server.MapPath(".");
            string strImgDir = "/ChartImages/";
            string strFileNm = System.Guid.NewGuid().ToString()+".Png";
            string strFullNm = (strCurDir + strImgDir + strFileNm);

            if (!Directory.Exists(strCurDir + strImgDir))
            { 
                Directory.CreateDirectory(strCurDir + strImgDir);
            }

            if (!File.Exists(strFullNm))
            {
                File.Delete(strFullNm);
            }

            chartScore.Save(strFullNm, ChartImageFormat.Png);

            imgChart.ImageUrl = strVirDir + strImgDir + strFileNm;
        }
        catch (Exception ex)
        {
            string rtnMsg = ex.Message;
        }
    }

    #endregion

    private void SetKpiTermGrid()
    {
        Biz_Bsc_Kpi_Term objBSC = new Biz_Bsc_Kpi_Term();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IKpiRefID);
        //ugrdBTerm.DataSource = rDs;
        //ugrdBTerm.DataBind();
    }

    private void GetKpiQltTermList()
    {
        Biz_Bsc_Kpi_Qlt_Term_Weight objBSC = new Biz_Bsc_Kpi_Qlt_Term_Weight();
        DataSet rDs = objBSC.GetKpiQualityTermWeight(this.IEstTermRefID, this.IKpiRefID, 0);

        //ugrdBQuestionTerm.Clear();
        //ugrdBQuestionTerm.DataSource = rDs;
        //ugrdBQuestionTerm.DataBind();

        //this.SetKpiQltTermListRow();
    }

    private void SetEstLevelList()
    {

        Biz_Bsc_Kpi_Qlt_Info objBSC = new Biz_Bsc_Kpi_Qlt_Info();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);

        //ugrdBEstLevel.Clear();
        //ugrdBEstLevel.DataSource = rDs;
        //ugrdBEstLevel.DataBind();
    }

    /// <summary>
    /// 이니셔티브 리스트
    /// </summary>
    private void SetInitiativeList()
    {
        Biz_Bsc_Kpi_Initiative objBSC = new Biz_Bsc_Kpi_Initiative();
        DataSet rDs = objBSC.GetKpiInitaitive(this.IEstTermRefID, this.IKpiRefID);

        grvInitiative.DataSource = rDs;
        grvInitiative.DataBind();
    }

    #endregion

    #region Event
    protected void grvTarget_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "right");

            if (e.Row.Cells[6].Text == "N")
            {
                e.Row.Cells[1].BackColor = Color.WhiteSmoke;
                e.Row.Cells[2].BackColor = Color.WhiteSmoke;
            }
            else
            {
                e.Row.Cells[1].BackColor = Color.White;
                e.Row.Cells[2].BackColor = Color.White;
            }

            if (e.Row.Cells[7].Text == "N")
            {
                e.Row.Cells[3].BackColor = Color.WhiteSmoke;
                e.Row.Cells[4].BackColor = Color.WhiteSmoke;
            }
            else
            {
                e.Row.Cells[3].BackColor = Color.White;
                e.Row.Cells[4].BackColor = Color.White;
            }
        }
    }
    
    protected void grvTarget_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell oTableCell = new TableHeaderCell();

            oTableCell.ColumnSpan = 1;
            oTableCell.RowSpan    = 2;
            oTableCell.Text = "목표&lt;BR /&gt;시기";
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "당초목표";
            oTableCell.ColumnSpan = 2;  
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "수정목표";
            oTableCell.ColumnSpan = 2;
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.ColumnSpan = 1;
            oTableCell.RowSpan    = 2;
            oTableCell.Text = "마감&lt;BR /&gt;여부";
            oGridViewRow.Cells.Add(oTableCell);

            oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

            e.Row.Cells[0].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[5].Width   = Unit.Pixel(80);
        }
    }

    protected void grvSignal_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView oGridView = (GridView)sender;
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell oTableCell = new TableHeaderCell();

            oTableCell.ColumnSpan = 2;
            oTableCell.Text = "표시상태";
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "등급구간";
            oTableCell.ColumnSpan = 2;  
            oGridViewRow.Cells.Add(oTableCell);

            oTableCell = new TableHeaderCell();
            oTableCell.Text = "평가 Table";
            oTableCell.ColumnSpan = 2;
            oGridViewRow.Cells.Add(oTableCell);

            oGridViewRow.Cells.Add(oTableCell);

            oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
        }
    }

    protected void grvSignal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.TextAlign, "right");

            //((ImageButton)e.Row.Cells[1].FindControl("imgSignal")).ImageUrl = "../images/"+e.Row.Cells[6].Text;
        }
    }

    protected void grvInitiative_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text.Equals("N"))
            {
                e.Row.Visible = false;
            }
            else
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
                e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
                e.Row.Cells[1].Text = PageUtility.GetHtmlEncodeChar(e.Row.Cells[1].Text);
            }
        }
        else
        {
            e.Row.Cells[2].Visible = false;
        }
    }
    #endregion
}
