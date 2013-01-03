using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;


using MicroCharts;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class Dashboard_NHIT_Main_Popup1 : AppPageBase
//public partial class Dashboard_NHIT_Main : Page
{
    public string CR_YEAR = "0000";
    public string CR_MONTH = "00";
    public int ikpiType = 0;
    public String skpiType = "";
    public String kpiType = "";
    public String champname = "";
    public String check_purpose = "";
    public String calc_form = "";
    public String grammer = "";
    public String issue = "";
    public String is3D = "";
    public string TG_GUBUN = "T";
    decimal sumplanVal = 0;
    decimal sumactVal = 0;
    decimal old_chkVal = 0;
    decimal old_chksumVal = 0;
    int cnt = 0;

    int intRowNum = 0;
    Workbook workBook = null; // smjjang

    public string unit = "-";

    public string ICR_YEAR
    {
        get
        {
            if (ViewState["CR_YEAR"] == null)
            {
                ViewState["CR_YEAR"] = GetRequest("CR_YEAR", "-1");
            }

            return (string)ViewState["CR_YEAR"];
        }
        set
        {
            ViewState["CR_YEAR"] = value;
        }
    }

    public string ICR_MONTH
    {
        get
        {
            if (ViewState["CR_MONTH"] == null)
            {
                ViewState["CR_MONTH"] = GetRequest("CR_MONTH", "-1");
            }

            return (string)ViewState["CR_MONTH"];
        }
        set
        {
            ViewState["CR_MONTH"] = value;
        }
    }


    public enum GRP_ONE_ID
    {
        A // 전사
      ,
        B // 고객사
        ,
        C // 사업유형
            , D // 본부
    }

    public enum GRP_TWO_ID : int
    {
        GTO_10 = 10 // 전사
      ,
        GTO_20 = 20// 중앙회
      ,
        GTO_30 = 30// 계열사
      ,
        GTO_40 = 40// 대외
        ,
        GTO_50 = 50// SI
            ,
        GTO_60 = 60// SM
            ,
        GTO_70 = 70// 상품
            ,
        GTO_80 = 80// 사업지원
            ,
        GTO_90 = 90// 금융사업
            ,
        GTO_100 = 100// 경제사업
            ,
        GTO_110 = 110// 카드사업
            ,
        GTO_120 = 120// 보험부문
            , GTO_130 = 130// 전략사업
    }

    public enum GRP_THREE_ID
    {
        ME // 매출
      ,
        YG // 영업이익
        ,
        DN // 당기순이익
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitializing();

            ddlYear.SelectedValue = ICR_YEAR;

            CR_YEAR = ddlYear.SelectedValue;

            iBtnSearch_Click(null, null);
        }
        else
        {

        }

        CR_YEAR = ddlYear.SelectedValue;
    }

    #region 페이지 초기화 함수

    private void DoInitializing()
    {
        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtYear = bizNHIT.GetYear_DB();

        if (dtYear.Rows.Count > 0)
        {
            ddlYear.DataSource = dtYear;
            ddlYear.DataTextField = "CR_YEAR_NAME";
            ddlYear.DataValueField = "CR_YEAR";
            ddlYear.DataBind();
        }
        else
        {
            ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
        }

    }

    private void DoBinding_JeonSa()
    {
        UltraWebGrid1.Clear();

        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetJeonSaPOPUP(GRP_ONE_ID.A.ToString()
                                           , (int)GRP_TWO_ID.GTO_10
                                           , CR_YEAR
                                           , TG_GUBUN         );

    #region 차트용 datatable 생성
        DataTable dtChart = new DataTable();
        dtChart.Columns.Add("CR_YEAR");
        dtChart.Columns.Add("CR_MONTH");
        dtChart.Columns.Add("ME_RATE", typeof(double));
        dtChart.Columns.Add("YG_RATE", typeof(double));
        dtChart.Columns.Add("DN_RATE", typeof(double));

        for (int i = 0; i < 12; i++)
        {
            DataRow dr = dtChart.NewRow();

            dr["CR_YEAR"] = CR_YEAR;
            dr["CR_MONTH"] = DataTypeUtility.GetString(i + 1).PadLeft(2,'0');
            dr["ME_RATE"] = 0;
            dr["YG_RATE"] = 0;
            dr["DN_RATE"] = 0;

            dtChart.Rows.Add(dr);

        }

        string cr_year = "";
        string cr_month = "";
        string grp_three_code = "";
        int iRow = 0;

        for (int i = 0; i < dtNHIT.Rows.Count ; i++)
        {
            cr_year = DataTypeUtility.GetString(dtNHIT.Rows[i]["CR_YEAR"]);
            cr_month = DataTypeUtility.GetString(dtNHIT.Rows[i]["CR_MONTH"]);
            grp_three_code =  DataTypeUtility.GetString(dtNHIT.Rows[i]["GRP_THREE_CODE"]);

            iRow = DataTypeUtility.GetToInt32(cr_month) - 1;

            if (grp_three_code == "ME")
            {
                dtChart.Rows[iRow]["ME_RATE"] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["DAL_RATE_100"]);
            }
            else if (grp_three_code == "YG")
            {
                dtChart.Rows[iRow]["YG_RATE"] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["DAL_RATE_100"]);
            }
            else if (grp_three_code == "DN")
            {
                dtChart.Rows[iRow]["DN_RATE"] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["DAL_RATE_100"]);
            }

        }

        DrawChart(dtChart);

    #endregion


        #region 그리드용 datatable 생성
        DataTable dtGrid = new DataTable();
        dtGrid.Columns.Add("ACC");
        dtGrid.Columns.Add("GUBUN");
        dtGrid.Columns.Add("M01", typeof(double));
        dtGrid.Columns.Add("M02", typeof(double));
        dtGrid.Columns.Add("M03", typeof(double));
        dtGrid.Columns.Add("M04", typeof(double));
        dtGrid.Columns.Add("M05", typeof(double));
        dtGrid.Columns.Add("M06", typeof(double));
        dtGrid.Columns.Add("M07", typeof(double));
        dtGrid.Columns.Add("M08", typeof(double));
        dtGrid.Columns.Add("M09", typeof(double));
        dtGrid.Columns.Add("M10", typeof(double));
        dtGrid.Columns.Add("M11", typeof(double));
        dtGrid.Columns.Add("M12", typeof(double));

        for (int i = 0; i < 9; i++)
        {
            DataRow dr = dtGrid.NewRow();

            switch (i)
            {
                case 0:
               
                    dr["ACC"] = "매출";
                    break;
                case 3:
             
                    dr["ACC"] = "영업이익";
                    break;
                case 6:
              
                    dr["ACC"] = "당기순이익";
                    break;
            }

            switch (i)
            {
                case 0:
                case 3:
                case 6:
                    dr["GUBUN"] = "목표";
                    break;
                case 1:
                case 4:
                case 7:
                    dr["GUBUN"] = "실적";
                    break;
                case 2:
                case 5:
                case 8:
                    dr["GUBUN"] = "달성률";
                    break;
            }
            dr["M01"] = 0;
            dr["M02"] = 0;
            dr["M03"] = 0;
            dr["M04"] = 0;
            dr["M05"] = 0;
            dr["M06"] = 0;
            dr["M07"] = 0;
            dr["M08"] = 0;
            dr["M09"] = 0;
            dr["M10"] = 0;
            dr["M11"] = 0;
            dr["M12"] = 0;

            dtGrid.Rows.Add(dr);

        }

        cr_year = "";
        cr_month = "";
        grp_three_code = "";

        int iCol = 0;
        for (int i = 0; i < dtNHIT.Rows.Count; i++)
        {
            cr_year = DataTypeUtility.GetString(dtNHIT.Rows[i]["CR_YEAR"]);
            cr_month = DataTypeUtility.GetString(dtNHIT.Rows[i]["CR_MONTH"]);
            grp_three_code = DataTypeUtility.GetString(dtNHIT.Rows[i]["GRP_THREE_CODE"]);

            iCol = DataTypeUtility.GetToInt32(cr_month) + 1;

            if (grp_three_code == "ME")
            {

                dtGrid.Rows[0][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["TARGET_TS"]);
                dtGrid.Rows[1][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["RESULT_TS"]);
                dtGrid.Rows[2][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["DAL_RATE_100"]);
            }
            else if (grp_three_code == "YG")
            {
                dtGrid.Rows[3][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["TARGET_TS"]);
                dtGrid.Rows[4][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["RESULT_TS"]);
                dtGrid.Rows[5][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["DAL_RATE_100"]);
            }
            else if (grp_three_code == "DN")
            {
                dtGrid.Rows[6][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["TARGET_TS"]);
                dtGrid.Rows[7][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["RESULT_TS"]);
                dtGrid.Rows[8][iCol] = DataTypeUtility.GetToDouble(dtNHIT.Rows[i]["DAL_RATE_100"]);
            }

        }

     

        UltraWebGrid1.DataSource = dtGrid;
        UltraWebGrid1.DataBind();

       
        #endregion
     
    }

    private void DrawChart(DataTable dt)
    {
        DataTable dtGrph = dt.Copy();
        dtGrph.Columns.Add("YMD_NAME");

        for (int i = 0; i < dtGrph.Rows.Count; i++)
        {
            string cr_month = DataTypeUtility.GetString(dtGrph.Rows[i]["CR_MONTH"]);


            dtGrph.Rows[i]["YMD_NAME"] = DataTypeUtility.GetToInt32(cr_month).ToString() + "월";
        }

        DundasCharts.DundasChartBase(this.chart1 
                                          , Dundas.Charting.WebControl.ChartImageType.Flash
                                          , 1100
                                          , 300
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


        chart1.DataSource = dtGrph;

        string y_value_col_name = "";
        Dundas.Charting.WebControl.Series series1 = DundasCharts.CreateSeries(chart1, "ME_RATE", "Default", "매출액", null, Dundas.Charting.WebControl.SeriesChartType.Column, 1, GetChartColor2(0), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Dundas.Charting.WebControl.Series series2 = DundasCharts.CreateSeries(chart1, "YG_RATE", "Default", "영업이익", null, Dundas.Charting.WebControl.SeriesChartType.Column, 1, GetChartColor2(3), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Dundas.Charting.WebControl.Series series3 = DundasCharts.CreateSeries(chart1, "DN_RATE", "Default", "당기순이익", null, Dundas.Charting.WebControl.SeriesChartType.Column, 1, GetChartColor2(1), Color.FromArgb(180, 26, 59, 105), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.ValueMemberX = "YMD_NAME";
        series1.ValueMembersY = "ME_RATE";
        series2.ValueMembersY = "YG_RATE";
        series3.ValueMembersY = "DN_RATE";

        series1.MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.Circle;
        series1.MarkerSize = 5;
        series1.MarkerColor = GetChartColor2(0);
        series1.MarkerBorderColor = GetChartColor2(0);
        series2.MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.Circle;
        series2.MarkerSize = 5;
        series2.MarkerColor = GetChartColor2(3);
        series2.MarkerBorderColor = GetChartColor2(3);
        series3.MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.Circle;
        series3.MarkerSize = 5;
        series3.MarkerColor = GetChartColor2(1);
        series3.MarkerBorderColor = GetChartColor2(1);

        series1.ToolTip = "#VALY{P}";
        series2.ToolTip = "#VALY{P}";
        series3.ToolTip = "#VALY{P}";
        //        series1.Label = "#VALY{N0}";

        DundasAnimations.DundasChartBase(chart1, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart1, series1, 0.5, 3.0, true);
        DundasAnimations.GrowingAnimation(chart1, series2, 0.5, 3.0, true);
        DundasAnimations.GrowingAnimation(chart1, series3, 0.5, 3.0, true);

        chart1.DataBind();
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



    #endregion

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding_JeonSa();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {

    }

}
