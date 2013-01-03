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

using Dundas.Charting.WebControl;
using MicroCharts;
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Integration.COM.Biz;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC1005S1 : AppPageBase
{
    public int ESTTERM_REF_ID;
    public string YMD;
    public int DEPT_REF_ID;

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

    string SUM_TYPE;


    public int VIEWROLE;//임원, 팀장, 사원 구분



    public DataTable DT_SCORE;
    public double SCORE;


    protected Color CHART_BORDER_BLUE = Color.FromArgb(87, 123, 201);


    protected void Page_Load(object sender, EventArgs e)
    {
        




        ltrScript.Text = "";



        if (!IsPostBack)
        {
            if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
            {
                rdoGoalTong.Visible = true;
            }


            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

            MicroBSC.Integration.BSC.Biz.Biz_My_Kpi bizMyKpi = new MicroBSC.Integration.BSC.Biz.Biz_My_Kpi();
            YMD = bizMyKpi.SelectCurrentYYYYMM();

            PageUtility.FindByValueDropDownList(ddlMonthInfo, YMD);


            this.IisAdmin = (User.IsInRole(ROLE_ADMIN) ? "Y" : "N");

            if (this.IisAdmin == "Y")
            {
                
                //WebCommon.SetComDeptDropDownList(ddlDeptList, true, gUserInfo.Emp_Ref_ID);
                //PageUtility.FindByValueDropDownList(ddlDeptList, this.IDEPT_ID);
                this.DEPT_REF_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
                WebCommon.SetComDeptDropDownList(ddlDeptList, false, gUserInfo.Emp_Ref_ID);
                PageUtility.FindByValueDropDownList(ddlDeptList, DEPT_REF_ID);
            }
            else
            { 
                BindDeptList();

            }

            this.DEPT_REF_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
        
        }
        

        ESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        YMD = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        DEPT_REF_ID = PageUtility.GetIntByValueDropDownList(ddlDeptList);

        SUM_TYPE = "TS";


        BindChart();
        BindScore();
        BindGrade();
        BindGrid();
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




    protected void BindChart()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score_Goal bizKpiScoreGoal = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score_Goal();
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score bizKpiScore = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score();

        if (rdoGoalTong.SelectedValue.Equals("GOAL"))
        {
            DT_SCORE = bizKpiScoreGoal.Get_Kpi_Monthly_Score(ESTTERM_REF_ID, DEPT_REF_ID, SUM_TYPE);
        }
        else
        {
            DT_SCORE = bizKpiScore.Get_Kpi_Monthly_Score(ESTTERM_REF_ID, DEPT_REF_ID, SUM_TYPE);
        }

        DrawChart(DT_SCORE);   
    }
    private void DrawChart(DataTable dt)
    {
        DataTable dtGrph = dt.Copy();
        dtGrph.Columns.Add("YMD_NAME");

        for (int i = 0; i < dtGrph.Rows.Count; i++)
        {
            string ymd = DataTypeUtility.GetString(dtGrph.Rows[i]["YMD"]);

            string year = ymd.Substring(0, 4);
            string month = ymd.Replace(year, "");

            dtGrph.Rows[i]["YMD_NAME"] = DataTypeUtility.GetToInt32(month).ToString() + "월";
        }

        DundasCharts.DundasChartBase(chart_score
                                          , Dundas.Charting.WebControl.ChartImageType.Flash
                                          , DataTypeUtility.GetToInt32(Math.Ceiling(chart_score.Width.Value))
                                          , DataTypeUtility.GetToInt32(Math.Ceiling(chart_score.Height.Value))
                                          , Dundas.Charting.WebControl.BorderSkinStyle.None
                                          , Color.FromArgb(181, 64, 1)
                                          , 0
                                          , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                          , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                          , Color.FromArgb(0x20, 0x80, 0xD0)
                                          , Dundas.Charting.WebControl.ChartDashStyle.Solid
                                          , -1
                                          , Dundas.Charting.WebControl.ChartHatchStyle.None
                                          , GradientType.TopBottom
                                          , AntiAliasing.None);


        chart_score.DataSource = dtGrph;

        string y_value_col_name = "SCORE";
        Dundas.Charting.WebControl.Series series1 = DundasCharts.CreateSeries(chart_score, y_value_col_name, "Default", "점수", null, Dundas.Charting.WebControl.SeriesChartType.Line, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));


        series1.MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.Circle;

        series1.ValueMemberX = "YMD_NAME";
        series1.ValueMembersY = y_value_col_name;

        series1.ToolTip = "#VALY{N0}";
        series1.Label = "#VALY{N0}";

        DundasAnimations.DundasChartBase(chart_score, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart_score, series1, 0.5, 2.0, true);

        chart_score.DataBind();
    }

    protected Color GetChartColor2(int i)
    {
        int iCheck = i % 20;

        return Color.FromArgb(CHART_COLOR[iCheck, 0], CHART_COLOR[iCheck, 1], CHART_COLOR[iCheck, 2]);
    }

    protected int[,] CHART_COLOR = new int[,]
                                   {
                                       {0x33, 0x66, 0xff},
                                       {0x99, 0xcc, 0x00},
                                       {0xff, 0xcc, 0x00},
                                       {0xff, 0x99, 0x00},
                                        {0x0c, 0x4c, 0xd4},
                                        {0xff, 0xa1, 0x0d},
                                        {0xad, 0x00, 0x00},
                                        {0xff, 0x72, 0x00},
                                        {0x75, 0xd8, 0x00},
                                        {0xA8, 0xD2, 0xFD},
                                        {0xFB, 0xEE, 0xA6},
                                        {0xFC, 0xD1, 0xA6},
                                        {0xD1, 0xFC, 0xD1},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };


    protected void BindScore()
    {
        if (DT_SCORE != null && DT_SCORE.Rows.Count > 0)
        {
            DataTable dt_current_score = DataTypeUtility.FilterSortDataTable(DT_SCORE, string.Format("YMD='{0}'", YMD));

            if (dt_current_score.Rows.Count > 0)
            {
                string score_col_name = "SCORE";
                SCORE = DataTypeUtility.GetToDouble(dt_current_score.Rows[0][score_col_name]);

                lblScore.Text = Math.Round(SCORE, 1).ToString();
            }
            else
            {
                lblScore.Text = "-";
            }
        }
    }





    protected void BindGrade()
    {
        string grade = "";
        string colorCode = "";

        if (SCORE >= 100)
        {
            grade = "S";
            colorCode = "#6fe1e0";
        }
        else if (SCORE >= 90 && SCORE < 100)
        {
            grade = "A";
            colorCode = "#6fe1e0";
        }
        else if (SCORE >= 80 && SCORE < 90)
        {
            grade = "B";
            colorCode = "#a8f620";
        }
        else if (SCORE >= 70 && SCORE < 80)
        {
            grade = "C";
            colorCode = "#f6c739";
        }
        else if (SCORE < 70)
        {
            grade = "D";
            colorCode = "#fb7716";
        }

        lblGrade.Text = grade;
        lblGrade.ForeColor = Color.FromName(colorCode);
    }






    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
    protected void BindGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card bizScoreCard = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score_Goal bizKpiScoreGoal = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score_Goal();
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score bizKpiScore = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Score();
        
        
        DataTable dt_kpiScore = new DataTable();
        DataTable dt_kpiScore_monthly_TS = new DataTable();

        if (rdoGoalTong.SelectedValue.Equals("GOAL"))
        {
            dt_kpiScore = bizScoreCard.GetEstDeptKpiScoreList(ESTTERM_REF_ID, YMD, "TS", DEPT_REF_ID, false).Tables[0];
            dt_kpiScore_monthly_TS = bizKpiScoreGoal.Get_Kpi_Monthly_Total_Sum(ESTTERM_REF_ID, DEPT_REF_ID);
        }
        else
        {
            dt_kpiScore = bizScoreCard.GetEstDeptKpiScoreList_Goal(ESTTERM_REF_ID, YMD, "TS", DEPT_REF_ID, false).Tables[0];
            dt_kpiScore_monthly_TS = bizKpiScore.Get_Kpi_Monthly_Total_Sum(ESTTERM_REF_ID, DEPT_REF_ID);
        }



        //월별 컬럼 생성
        string year = YMD.Substring(0, 4);
        for (int j = 1; j <= 12; j++)
        {
            string month = j.ToString().PadLeft(2, '0');
            dt_kpiScore.Columns.Add(year + month);
        }


        
        //월별 컬럼에 값 추가
        for (int i = 0; i < dt_kpiScore.Rows.Count; i++)
        {
            string kpi_ref_id = DataTypeUtility.GetString(dt_kpiScore.Rows[i]["KPI_REF_ID"]);

            for (int j = 1; j <= 12; j++)
            {
                string month = j.ToString().PadLeft(2, '0');

                string filter = string.Format("KPI_REF_ID='{0}' AND YMD='{1}'", kpi_ref_id, year + month);
                DataTable dt_tmp_monthly_score = DataTypeUtility.FilterSortDataTable(dt_kpiScore_monthly_TS, filter);

                if (dt_tmp_monthly_score.Rows.Count > 0)
                {
                    dt_kpiScore.Rows[i][year + month] = DataTypeUtility.GetString(dt_tmp_monthly_score.Rows[0]["SCORE_TS"]);
                }
            }
        }



        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = dt_kpiScore;
        UltraWebGrid1.DataBind();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        string year = YMD.Substring(0, 4);
        if (!e.Layout.Bands[0].Columns.Exists(YMD))
        {
            int last_col_idx = e.Layout.Bands[0].Columns.FromKey("SIGNAL_NAME").Index;

            while (e.Layout.Bands[0].Columns.Count > last_col_idx + 1)
            {
                e.Layout.Bands[0].Columns.RemoveAt(last_col_idx + 1);
            }

            //그리드에 월별 컬럼 추가
            for (int i = 1; i <= 12; i++)
            {
                string month = i.ToString().PadLeft(2, '0');

                UltraGridColumn uc = new UltraGridColumn();
                uc.BaseColumnName = year + month;
                uc.Key = year + month;
                uc.Header.Caption = i.ToString() + "월";
                uc.Header.Style.HorizontalAlign = HorizontalAlign.Center;
                uc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                uc.Width = Unit.Pixel(50);

                e.Layout.Bands[0].Columns.Add(uc);
            }
        }



        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginY = 1;
        }


        ColumnHeader ch = new ColumnHeader();
        ch.Caption = "실적현황(해당월 누적)";
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ch.RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns.FromKey("TARGET").Index;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.SpanX = 4;

        e.Layout.Bands[0].HeaderLayout.Add(ch);


        ch = new ColumnHeader();
        ch.Caption = "월별 성과 현황(누적 점수)";
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        ch.RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns.FromKey(year + "01").Index;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.SpanX = 12;

        e.Layout.Bands[0].HeaderLayout.Add(ch);




        e.Layout.Bands[0].HeaderLayout[0].RowLayoutColumnInfo.OriginY = 0;
        e.Layout.Bands[0].HeaderLayout[0].RowLayoutColumnInfo.SpanY = 2;

        e.Layout.Bands[0].HeaderLayout[1].RowLayoutColumnInfo.OriginY = 0;
        e.Layout.Bands[0].HeaderLayout[1].RowLayoutColumnInfo.SpanY = 2;
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        double target = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("TARGET").Value);
        double result = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("RESULT").Value);

        double progress;
        if (result == 0 || target == 0)
        {
            progress = 0;

            if (result + target == 0)
            {
                e.Row.Cells.FromKey("SIGNAL_NAME").Value = "-";
            }
        }
        else
        {
            progress = result / target * 100;
        }

        e.Row.Cells.FromKey("PROGRESS").Value = Math.Round(progress, 1);
    }
    protected void ddlDeptList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DEPT_REF_ID = DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlDeptList));
    }
}
