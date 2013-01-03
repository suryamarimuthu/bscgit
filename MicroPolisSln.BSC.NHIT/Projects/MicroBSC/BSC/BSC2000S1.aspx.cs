using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using MicroCharts;
using MicroBSC.Estimation.Dac;
using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Integration.COM.Biz;

using Infragistics.WebUI.UltraWebGrid;
//using Dundas.Gauges.WebControl;
//using Dundas.Charting.WebControl;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC2000S1 : AppPageBase
{

    public double dTotalPoint = 0;

    #region --> Property

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

    public int IEstDeptID
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

    public int IDeptID
    {
        get
        {
            if (ViewState["COM_DEPT_REF_ID"] == null)
            {
                ViewState["COM_DEPT_REF_ID"] = GetRequestByInt("COM_DEPT_REF_ID", 0);
            }

            return (int)ViewState["COM_DEPT_REF_ID"];
        }
        set
        {
            ViewState["COM_DEPT_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string ISumType
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "");
            }

            return (string)ViewState["SUM_TYPE"];
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }

    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = GetRequest("IS_ADMIN", "N");
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    public int VIEWROLE;//임원, 팀장, 사원 구분

    #endregion

    #region --> Page_Load()

    protected void Page_Load(object sender, EventArgs e)
    {
        //좌측메뉴설정
        base.SetMenuControl(true, true, true);

        if (!IsPostBack) 
        {
            chartMM.Visible = false;
            chartDal.Visible = false;

            NotPostBackSetting();

            this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            this.IYmd = PageUtility.GetByValueDropDownList(ddlMonthInfo);

            
            this.IisAdmin = (User.IsInRole(ROLE_ADMIN) ? "Y" : "N");

            if (this.IisAdmin == "Y")
            {

                //WebCommon.SetComDeptDropDownList(ddlDeptList, true, gUserInfo.Emp_Ref_ID);
                //PageUtility.FindByValueDropDownList(ddlDeptList, this.IDEPT_ID);
                this.IDeptID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
                WebCommon.SetComDeptDropDownList(ddlDeptList, false, gUserInfo.Emp_Ref_ID);
                PageUtility.FindByValueDropDownList(ddlDeptList, IDeptID);
      
            }
            else
            {
                BindDeptList();

            }
            this.IDeptID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
            DoBinding(IEstTermRefID, IDeptID);  

          
        }
        else
        {
        }


        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.IDeptID = PageUtility.GetIntByValueDropDownList(ddlDeptList);


        this.UltraWebGrid1.Columns.FromKey("CHAMPION_NAME").Header.Caption = this.GetText("LBL_00001", "챔피언");
    }

    protected void BindDeptList()
    {
        Biz_Com_Dept_Info bizComDeptInfo = new Biz_Com_Dept_Info();
        DataTable dt = bizComDeptInfo.Get_Dept_UpDept_List();


        VIEWROLE = 0;
        for (int i = 0; i < EMP_ROLES.Count; i++)
        {
            int emp_role = DataTypeUtility.GetToInt32(EMP_ROLES[i]);

            if (emp_role == 2)
            {
                //임원권한
                VIEWROLE = 2;
                dt = DataTypeUtility.FilterSortDataTable(dt, string.Format("UP_DEPT_ID='{0}'", gUserInfo.Dept_Ref_ID));
                break;
            }
            else if (emp_role == 4)
            {
                //팀장권한
                VIEWROLE = 4;
                dt = DataTypeUtility.FilterSortDataTable(dt, string.Format("DEPT_ID='{0}'", gUserInfo.Dept_Ref_ID));
                break;
            }
            else if (emp_role == 5)
            {
                //사원권한
                VIEWROLE = 5;
                dt = DataTypeUtility.FilterSortDataTable(dt, string.Format("DEPT_ID='{0}'", gUserInfo.Dept_Ref_ID));
                break;
            }
        }


        DataTable dt_result = new DataTable();
        dt_result.Columns.Add("DEPT_REF_ID");
        dt_result.Columns.Add("DEPT_NAME");


        if (dt.Rows.Count > 0)
        {
            if (VIEWROLE == 2 || VIEWROLE == 4)
            {
                DataRow dr = dt_result.NewRow();

                dr["DEPT_REF_ID"] = DataTypeUtility.GetString(dt.Rows[0]["UP_DEPT_ID"]);
                dr["DEPT_NAME"] = DataTypeUtility.GetString(dt.Rows[0]["UP_DEPT_NAME"]);

                dt_result.Rows.Add(dr);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt_result.NewRow();

                dr["DEPT_REF_ID"] = DataTypeUtility.GetString(dt.Rows[0]["DEPT_ID"]);
                dr["DEPT_NAME"] = DataTypeUtility.GetString(dt.Rows[0]["DEPT_NAME"]);

                dt_result.Rows.Add(dr);
            }
        }

        ddlDeptList.DataTextField = "DEPT_NAME";
        ddlDeptList.DataValueField = "DEPT_REF_ID";
        ddlDeptList.DataSource = dt_result;
        ddlDeptList.DataBind();
    }


    private void NotPostBackSetting()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        //WebCommon.SetSumTypeDropDownList(ddlSumType, false);

        //DeptInfos objDept = new DeptInfos();

        //if (Request["EST_DEPT_REF_ID"] == null)
        //{
        //    objDept = new DeptInfos();
        //    this.IEstDeptID = objDept.GetRootEstDeptID(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        //}
        //else
        //{
        //    this.IEstDeptID = WebUtility.GetRequestByInt("EST_DEPT_REF_ID");
        //}



        //this.Search(this.IEstDeptID);


        UltraWebGrid1.Columns.FromKey("CHAMPION_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
    }

    #endregion

    #region --> Event

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

    protected void dstKpiStatus_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //this.Search(DataTypeUtility.GetToInt32(txtDeptID.Text));
        DoBinding(IEstTermRefID, IDeptID);

        //AppPageUtility apu = new AppPageUtility(this.Page);
        //apu.SendMail("test mail 농협", "아다다다", "goodgury@naver.com", "goodgury@micropolis.co.kr");


        //System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

        //mail.BodyFormat = System.Web.Mail.MailFormat.Html;
        //mail.BodyEncoding = System.Text.Encoding.Default;

        //System.Web.Mail.SmtpMail.SmtpServer = GetAppConfig("Mail.SMTP");


        //try
        //{

        //    System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();

        //    smtpClient.Host = "121.157.111.9";
        //    smtpClient.Port = 25;
        //    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //    smtpClient.Send("goodgury@naver.com", "goodgury@micropolis.co.kr", "test mail 농협", "아다다다");

        //}
        //catch(Exception ex)
        //{
        //    string a = ex.Message;
        //}

    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        //PopupControlExtender1.Commit(trvEstDept.SelectedNode.Text);
        //PopupControlExtender2.Commit(trvEstDept.SelectedNode.Value);
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = null;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = "목표";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.RowLayoutColumnInfo.SpanY = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = "달성율(%)";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string col_goal = "GOAL_MS";
        string col_target = "TARGET_MS";
        string col_result = "RESULT_MS";
        string col_goal_dal = "GOAL_DAL_MS";
        string col_target_dal = "TARGET_DAL_MS";

        if (rdoMethod.SelectedIndex.Equals(1))
        {
            col_goal = "GOAL_TS";
            col_target = "TARGET_TS";
            col_result = "RESULT_TS";
            col_goal_dal = "GOAL_DAL_TS";
            col_target_dal = "TARGET_DAL_TS";
        }

        double goal_p = 0;
        double target_p = 0;

        double result = 0;

        double goal_dal = 0;
        double target_dal = 0;

        DataRowView drw = (DataRowView)e.Data;

        int kpi_ref_id = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("KPI_REF_ID").Value);

        // 목표
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target_Goal bizBscKpiTargetGoal = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target_Goal();

        DataTable dtBscKpiTargetGoal = bizBscKpiTargetGoal.GetBscKpiTargetGoalTong_DB(IEstTermRefID
                                                                            , kpi_ref_id
                                                                            , IYmd);

        if (dtBscKpiTargetGoal.Rows.Count > 0)
        {
            goal_p = DataTypeUtility.GetToDouble(DataTypeUtility.GetValue(dtBscKpiTargetGoal.Rows[0][col_goal]).Replace("-", "0"));
            goal_dal = DataTypeUtility.GetToDouble(DataTypeUtility.GetValue(dtBscKpiTargetGoal.Rows[0][col_goal_dal]).Replace("-", "0"));
        }

        // 실적
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result();

        DataTable dtBscKpiResult = bizBscKpiResult.GetBscKpiTargetGoalTong_DB(IEstTermRefID
                                                                            , kpi_ref_id
                                                                            , IYmd);
        if (dtBscKpiResult.Rows.Count > 0)
        {
            result = DataTypeUtility.GetToDouble(DataTypeUtility.GetValue(dtBscKpiResult.Rows[0][col_result]).Replace("-","0"));
        }


        // 달성율
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target bizBscKpiTarget = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target();

        DataTable dtBscKpiTarget = bizBscKpiTarget.GetBscKpiTargetGoalTong_DB(IEstTermRefID
                                                                            , kpi_ref_id
                                                                            , IYmd);
        if (dtBscKpiTarget.Rows.Count > 0)
        {
            target_p = DataTypeUtility.GetToDouble(DataTypeUtility.GetValue(dtBscKpiTarget.Rows[0][col_target]).Replace("-", "0"));
            target_dal = DataTypeUtility.GetToDouble(DataTypeUtility.GetValue(dtBscKpiTarget.Rows[0][col_target_dal]).Replace("-", "0"));
        }

        e.Row.Cells.FromKey("GOAL_P").Value = goal_p;
        e.Row.Cells.FromKey("TARGET_P").Value = target_p;
        e.Row.Cells.FromKey("RESULT").Value = result;
        e.Row.Cells.FromKey("GOAL_DAL").Value = goal_dal;
        e.Row.Cells.FromKey("TARGET_DAL").Value = target_dal;
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        
        if (e.SelectedRows.Count > 0)
        {
            int kpi_ref_id = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("KPI_REF_ID").Value);
            string kpi_name = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("KPI_NAME").Value);

            DoCharting( kpi_ref_id, kpi_name);
        }
    }
    #endregion

    #region --> Function

    private void DoBinding(int estTermRefID, int deptID)
    {
        UltraWebGrid1.Clear();
        

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info bizBscKpiInfo = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info();

        DataTable dtBscKpiInfo = bizBscKpiInfo.Get_GoalTongDashboard(estTermRefID, deptID);

        if (dtBscKpiInfo.Rows.Count > 0)
        {
            this.ChartView.Visible = true;
            UltraWebGrid1.DataSource = dtBscKpiInfo;
            UltraWebGrid1.DataBind();

            UltraWebGrid1.Rows[0].Activated = true;
            int kpi_ref_id = DataTypeUtility.GetToInt32(dtBscKpiInfo.Rows[0]["KPI_REF_ID"]);
            string kpi_name = DataTypeUtility.GetValue(dtBscKpiInfo.Rows[0]["KPI_NAME"]);

            DoCharting(kpi_ref_id, kpi_name);
        }
        else
        {
            this.ChartView.Visible = false;
            //chartMM.Visible = false;
            //chartDal.Visible = false;
        }
    }


    private void DoCharting(int kpi_ref_id, string kpi_name)
    {
        chartMM.Visible = true;
        chartDal.Visible = true;

        int chartWidth = 500;
        int chartHeight = 250;


        lblKpiName1.Text = kpi_name;
        lblKpiName2.Text = kpi_name;

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target bizBscKpiTarget = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target();
        DataTable dtBscKpiTarget = bizBscKpiTarget.GetBscKpiTargetGoalTongMM_DB(IEstTermRefID
                                                                              , kpi_ref_id
                                                                              , "");
       
        // 목표 실적 그래프
        MSCharts.DundasChartBase(chartMM
                               , ChartImageType.Jpeg
                               , chartWidth
                               , chartHeight
                                , BorderSkinStyle.Emboss
                                , Color.FromArgb(181, 64, 1)
                                , 2
                                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                , Color.FromArgb(0x20, 0x80, 0xD0)
                                , ChartDashStyle.Solid
                                , -1
                                , ChartHatchStyle.None
                                , MsGradientType.TopBottom
                                , MsAntiAliasing.None);

        chartMM.DataSource = dtBscKpiTarget;

        Series series1 = MSCharts.CreateSeries(chartMM, "serTarget", "Default", "Target", null, SeriesChartType.Column, 1, GetChartColor(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = MSCharts.CreateSeries(chartMM, "serGoal", "Default", "Goal", null, SeriesChartType.Column, 1, GetChartColor(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series3 = MSCharts.CreateSeries(chartMM, "serActl", "Default",  "실적", null, SeriesChartType.Line, 1, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //series3.YAxisType = AxisType.Secondary;

        //series1.ValueMembersY = "TARGET_MS";
        //series2.ValueMembersY = "RESULT_MS";
        //series3.ValueMembersY = "GR_RATE_MS";
        //series1.ValueMemberX = "MM";


        string series2_col = "GOAL_MS";
        string series1_col = "TARGET_MS";
        string series3_col = "RESULT_MS";

        if (rdoMethod.SelectedIndex.Equals(1))
        {
            series2_col = "GOAL_TS";
            series1_col = "TARGET_TS";
            series3_col = "RESULT_TS";
        }


        series1.YValueMembers = series1_col;
        series2.YValueMembers = series2_col;
        series3.YValueMembers = series3_col;
        series1.XValueMember = "MM";

        series1.ToolTip = "#VALY{N0}";
        series2.ToolTip = "#VALY{N0}";
        series3.ToolTip = "#VALY{N0}";

        string sChartArea = chartMM.Series[series2.Name].ChartArea;
        chartMM.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        //chartMM.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

        //DundasAnimations.DundasChartBase(chartMM, AnimationTheme.None, -1, -1, false, 1);
        //DundasAnimations.GrowingAnimation(chartMM, series1, 1.0, 1.0, true);
        //DundasAnimations.GrowingAnimation(chartMM, series2, 2.0, 2.0, true);
        //DundasAnimations.GrowingAnimation(chartMM, series3, 2.0, 1.0, true);

        chartMM.DataBind();


        // 달성율 그래프
        MSCharts.DundasChartBase(chartDal
                               , ChartImageType.Jpeg
                               , chartWidth
                               , chartHeight
                                , BorderSkinStyle.Emboss
                                , Color.FromArgb(181, 64, 1)
                                , 2
                                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                , Color.FromArgb(0x20, 0x80, 0xD0)
                                , ChartDashStyle.Solid
                                , -1
                                , ChartHatchStyle.None
                                , MsGradientType.TopBottom
                                , MsAntiAliasing.None);

        chartDal.DataSource = dtBscKpiTarget;

         Series series1D = MSCharts.CreateSeries(chartDal, "serTarget", "Default", "Target", null, SeriesChartType.Column, 1, GetChartColor(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
       Series series2D = MSCharts.CreateSeries(chartDal, "serGoal", "Default", "Goal", null, SeriesChartType.Column, 1, GetChartColor(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        //series3.YAxisType = AxisType.Secondary;

        //series1.ValueMembersY = "TARGET_MS";
        //series2.ValueMembersY = "RESULT_MS";
        //series3.ValueMembersY = "GR_RATE_MS";
        //series1.ValueMemberX = "MM";


        string series2D_col = "GOAL_DAL_MS";
        string series1D_col = "TARGET_DAL_MS";

        if (rdoMethod.SelectedIndex.Equals(1))
        {
            series2D_col = "GOAL_DAL_TS";
            series1D_col = "TARGET_DAL_TS";
        }


        series1D.YValueMembers = series1D_col;
        series2D.YValueMembers = series2D_col;
        series1D.XValueMember = "MM";

        series1D.ToolTip = "#VALY{N0}";
        series2D.ToolTip = "#VALY{N0}";

        string sChartAreaD = chartDal.Series[series2D.Name].ChartArea;
        chartDal.ChartAreas[sChartAreaD].AxisY.LabelStyle.Format = "N0";
        //chartDal.ChartAreas[sChartAreaD].AxisY2.LabelStyle.Format = "N0";

        //DundasAnimations.DundasChartBase(chartDal, AnimationTheme.None, -1, -1, false, 1);
        //DundasAnimations.GrowingAnimation(chartDal, series1, 1.0, 1.0, true);
        //DundasAnimations.GrowingAnimation(chartDal, series2, 2.0, 2.0, true);
        //DundasAnimations.GrowingAnimation(chartDal, series3, 2.0, 1.0, true);

        chartDal.DataBind();

    }


    #endregion
    protected void ddlDeptList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IDeptID = DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlDeptList));

    }
}