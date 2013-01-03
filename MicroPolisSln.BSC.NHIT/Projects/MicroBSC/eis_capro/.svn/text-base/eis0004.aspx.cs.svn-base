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
using System.Data.OracleClient;
using System.Drawing;
using Dundas.Charting.WebControl;
using MicroCharts;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Data;
using System.Text;

public partial class eis_eis0004 : AppPageBase
{
    
    private enum EN_CHART : int
    {
        CH_TOT  = 0,
        CH_1    = 1,
        CH_2    = 2,
        CH_3    = 3
    }

    private int GetChartInfo(EN_CHART enCol)
    {
        return (int)enCol;
    }

    #region 각 공장별 코드... (공장코드를 상수값으로 정의)
        private string[] masGongJang    = {
                                            "전체",
                                            "1",
                                            "2",
                                            "3"
                                          };
    #endregion
    

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }

    #region 페이지 초기화 함수
        private void SetAllTimeTop()
        {

        }

        private void InitControlValue()
        {
            DateTime dtNow = System.DateTime.Now;
            string sMonth = "";

            this.ddlYear.Items.Clear();
            this.ddlMonth.Items.Clear();

            for (int i = 1999; i <= (dtNow.Year + 1); i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                sMonth = (i < 10 ? "0" + i.ToString() : i.ToString());
                this.ddlMonth.Items.Add(new ListItem(sMonth, sMonth));
            }
            this.ddlGong.Items.Add(new ListItem("전체", ""));
            this.ddlGong.Items.Add(new ListItem("1공장", "1"));
            this.ddlGong.Items.Add(new ListItem("2공장", "2"));
            this.ddlGong.Items.Add(new ListItem("3공장", "3"));
            //System.DateTime date = System.DateTime.Now.AddMonths(-1).AddDays(-15);
            DateTime date = System.DateTime.Now;  // 생산현황에서는 현재월로 조건 셋팅
            PageUtility.FindByValueDropDownList(ddlYear, date.Year.ToString());
            PageUtility.FindByValueDropDownList(ddlMonth, date.Month.ToString().PadLeft(2, '0'));
        }

        private void InitControlEvent()
        {

        }

        private void SetPageData()
        {
            ChartBinding();
            GridBinding();
            ChartBinding2();
            ChartBinding3();
        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {

        }
    #endregion

    #region 내부함수


        private void ChartBinding2()
        {
            Chart[] oaChart = {
                                ChartTot,
                                Chart1,
                                Chart2,
                                Chart3
                              };

            Chart2.DataSource = GetDTChart2();

            #region 챠트 초기화
                for (int i=0; i<oaChart.Length; i++)
                {
                    if (i == GetChartInfo(EN_CHART.CH_TOT))
                    {
                        DundasCharts.DundasChartBase(oaChart[i], ChartImageType.Flash, 800, 185
                            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                            , Color.FromArgb(0xFF, 0xFF, 0xFE)
                            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                            , -1
                            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
                    }
                    else
                    {
                        DundasCharts.DundasChartBase(oaChart[i], ChartImageType.Flash, 263, 185
                            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                            , Color.FromArgb(0xFF, 0xFF, 0xFE)
                            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                            , -1
                            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
                    }

                    oaChart[i].DataSource = GetDTChart2(masGongJang[i]);

                    // 시리즈 생성
                    Series srProd = DundasCharts.CreateSeries(oaChart[i], "", "Default", "1. 월간 생산량", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                    srProd.ValueMembersY = "Prod";
                    srProd.LabelFormat = "N0";
                    DundasAnimations.GrowingAnimation(oaChart[i], srProd, 0, 0 + 1, true);
                    srProd.ToolTip = "#VALY{N0}";

                    Series srPlan = DundasCharts.CreateSeries(oaChart[i], "", "Default", "2. 월간 계획량", null, SeriesChartType.Column, 1, GetChartColor(4), GetChartColor(4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                    srPlan.ValueMembersY = "Plan";
                    srPlan.LabelFormat = "N0";
                    srPlan.ToolTip = "#VALY{N0}";
                    DundasAnimations.GrowingAnimation(oaChart[i], srPlan, 1, 1 + 1, true);


                    Series srPrevYear = DundasCharts.CreateSeries(oaChart[i], "", "Default", "3. 전년대비월간실적", null, SeriesChartType.Column, 1, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                    srPrevYear.ValueMembersY = "PrevYear";
                    srPrevYear.LabelFormat = "N0";
                    DundasAnimations.GrowingAnimation(oaChart[i], srPrevYear, 2, 2 + 1, true);
                    srPrevYear.ToolTip = "#VALY{N0}";

                    Series srSum = DundasCharts.CreateSeries(oaChart[i], "", "Default", "4. 계획대비월간실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                    srSum.ValueMembersY = "Sum";
                    srSum.LabelFormat = "N0";
                    DundasAnimations.GrowingAnimation(oaChart[i], srSum, 4, 4 + 1, true);
                    srSum.ToolTip = "#VALY{N0}";

                    string sChartArea = "";

                    // 전체에는 부하율이 필요없다.
                    if (i != GetChartInfo(EN_CHART.CH_TOT))
                    {
                        Series srBuha = DundasCharts.CreateSeries(oaChart[i], "", "Default", "부하율", null, SeriesChartType.Column, 3, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                        srBuha.ValueMembersY = "Rate";
                        DundasAnimations.GrowingAnimation(oaChart[i], srBuha, 3, 3 + 1, true);
                        //srBuha.MarkerStyle = GetMarkerStyle(3);
                        
                        srBuha.ShowLabelAsValue = true;
                        srBuha.YAxisType = AxisType.Secondary;
                        srBuha.LabelFormat = "P0";
                        srBuha.ToolTip = "#VALY{N0}";

                        sChartArea = oaChart[i].Series[srBuha.Name].ChartArea;
                        oaChart[i].ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";
                    }
                    

                    srPlan.ShowLabelAsValue = true;
                    srProd.ShowLabelAsValue = true;
                    srPrevYear.ShowLabelAsValue = true;
                    srSum.ShowLabelAsValue = true;
                    
                    srPlan.ValueMemberX = "GongJang";

                    sChartArea = oaChart[i].Series[srPlan.Name].ChartArea;
                    oaChart[i].ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
                    
                    // 전체가 아니면 시리즈설명 없엔다.
                    if (i != GetChartInfo(EN_CHART.CH_TOT))
                    {
                        oaChart[i].Legends[0].Position.Auto     = false;
                        oaChart[i].Legends[0].Position.Width    = 0;
                        oaChart[i].Legends[0].Position.Height   = 0;
                    }
                    else
                    {
                        Font font1 = new Font("Gulim", 9, FontStyle.Regular);
                        Legend legend = DundasCharts.CreateLegend(oaChart[i], "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
                    }

                    
                }
            #endregion
        }

        // 챠트용 데이타테이블 반환

        private DataTable GetDTChart2()
        {
            return GetDTChart2(masGongJang[GetChartInfo(EN_CHART.CH_TOT)]);
        }

        private DataTable GetDTChart2(string asGongJang)
        {
            DataTable dtGong = GetDTGongJang(); // X축이 되는 공장정보 테이블

            DateTime dtNow = System.DateTime.Now;

            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);

            int iDays = 0;  // 부하율을 계산하기 위한 해당월의 날짜일수 (부하율의 계산시 총생산량 / 일수)

            // 검색년월이 현재년월보다 크면 일수는 0
            // 검색년월이 현재년월보다 같으면 일수는 현재일까지
            // 검색년월이 현재년월 이전이면 검색월의 모든일자
            if (
                Convert.ToInt32(TypeUtility.GetDate(Convert.ToInt32(sYear), Convert.ToInt32(sMonth), 1)) < 
                Convert.ToInt32(TypeUtility.GetDate(dtNow.Year, dtNow.Month, 1))
               )
            {
                //iDays = TypeUtility.GetMonthDiff(sYear + sMonth, sYear + sMonth, "M").Length;
                iDays = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true).Length;
            }
            else if (
                    Convert.ToInt32(TypeUtility.GetDate(Convert.ToInt32(sYear), Convert.ToInt32(sMonth), 1)) ==
                    Convert.ToInt32(TypeUtility.GetDate(dtNow.Year, dtNow.Month, 1))
                    )
            {
                iDays = dtNow.Day;
            }

            float dTmp1 = 0;
            float dTmp2 = 0;
            float dTmp3 = 0;
            float dTmp4 = 0;
            float dTmp5 = 0;



            DataTable dataTable = new DataTable();
            DataRow drNew = null;
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetChartQuery2(asGongJang));
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("GongJang", typeof(string));
            dataTable.Columns.Add("Plan", typeof(float));
            dataTable.Columns.Add("Prod", typeof(float));
            dataTable.Columns.Add("PrevYear", typeof(float));
            dataTable.Columns.Add("Sum", typeof(float));
            dataTable.Columns.Add("Rate", typeof(float));

            drNew = dataTable.NewRow();
            
            if (asGongJang != masGongJang[GetChartInfo(EN_CHART.CH_TOT)])
            {
                drNew["GongJang"] = asGongJang + "공장";
                draDefault = dtTable.Select(
                                            "v_GongCD = '" + asGongJang + "' "
                                           );
            }
            else
            {
                drNew["GongJang"] = asGongJang;
                draDefault = dtTable.Select();
            }

            dTmp1 = 0;
            dTmp2 = 0;
            dTmp3 = 0;
            dTmp4 = 0;
            dTmp5 = 0;

            int iIndex = 0; // 전체조회일 경우 부하율 평균값을 구하기위함.
            for (int j = 0; j < draDefault.Length; j++)
            {
                dTmp1 += Convert.ToSingle(draDefault[j]["v_PlanQty"]);
                dTmp2 += Convert.ToSingle(draDefault[j]["v_ProdQty"]);
                dTmp3 += Convert.ToSingle(draDefault[j]["v_Buha"]);
                dTmp4 += Convert.ToSingle(draDefault[j]["v_PrevYearSub"]);
                dTmp5 += Convert.ToSingle(draDefault[j]["v_PlanProdSubSum"]);

                iIndex++;
            }

            drNew["Plan"] = Math.Round(dTmp1, 3);
            drNew["Prod"] = Math.Round(dTmp2, 3);

            if (asGongJang != masGongJang[GetChartInfo(EN_CHART.CH_TOT)])
            {
                if (asGongJang == masGongJang[GetChartInfo(EN_CHART.CH_3)])
                {
                    // 3공장은 3.64로 한번 더 나눈다.
                    //drNew["Rate"] = Math.Round(dTmp3 / 3.64, 2);
                    drNew["Rate"] = (iDays == 0 ? 0 : Math.Round(dTmp2 / iDays / 3.64, 0));
                }
                else
                {
                    //drNew["Rate"] = Math.Round(dTmp3, 2);
                    drNew["Rate"] = (iDays == 0 ? 0 : Math.Round(dTmp2 / iDays, 0));
                }
                
            }
            else
            {
                //drNew["Rate"] = Math.Round(dTmp3 / iIndex, 2);
                drNew["Rate"] = (iDays == 0 ? 0 : Math.Round(dTmp2 / iDays, 0));
            }

            drNew["PrevYear"]   = Math.Round(dTmp4, 0);
            drNew["Sum"] = Math.Round(dTmp2, 3) - Math.Round(dTmp1, 3);

            dataTable.Rows.Add(drNew);

            return dataTable;
        }

        private string GetChartQuery2(string asGongCD)
        {
            string sQuery = "";

            sQuery += "SELECT v_GongCD,                                     \n";
            sQuery += "       v_GongName,                                   \n";
            sQuery += "       SUM(v_PlanQty        )    v_PlanQty       ,   \n";
            sQuery += "       SUM(v_ProdQty        )    v_ProdQty       ,   \n";
            sQuery += "       SUM(v_Buha           )    v_Buha          ,   \n";
            sQuery += "       SUM(v_PrevYearSub    )    v_PrevYearSub   ,   \n";
            sQuery += "       SUM(v_PlanProdSubSum )    v_PlanProdSubSum    \n";
            sQuery += "  FROM (                                             \n";

            sQuery += GetChartQuery2();

            sQuery += "       ) A           \n";
            sQuery += " WHERE 1=1           \n";

            if (asGongCD != masGongJang[GetChartInfo(EN_CHART.CH_TOT)])
                sQuery += "   AND v_GongCD = '" + asGongCD + "' \n";

            sQuery += " GROUP BY            \n";
            sQuery += "       v_GongCD,     \n";
            sQuery += "       v_GongName    \n";

            return sQuery;
        }

        private string GetChartQuery2()
        {
            string sQuery = "";

            sQuery += GetDefaultQuery2();

            return sQuery;
        }

        private string GetDefaultQuery2()
        {

            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);

            int iYear = Convert.ToInt32(sYear);

            string sQuery = "";

            sQuery += "SELECT v_GongCD,                                                         \n";
            sQuery += "       v_GongName,                                                       \n";
            sQuery += "       SUM(v_PlanQty       ) v_PlanQty           ,                       \n";
            sQuery += "       SUM(v_ProdQty       ) v_ProdQty           ,                       \n";
            sQuery += "       SUM(v_Buha          ) v_Buha              ,                       \n";
            sQuery += "       SUM(v_PrevYearSub   ) v_PrevYearSub       ,                       \n";
            sQuery += "       SUM(v_PlanProdSubSum) v_PlanProdSubSum                            \n";
            sQuery += "  FROM (                                                                 \n";
            sQuery += "       select c.GO_IDX        v_GongCD,                                  \n";
            sQuery += "              c.GONGJANG      v_GongName,                                \n";
            sQuery += "              SUM(b.PLAN_QTY) v_PlanQty,                                 \n";
            sQuery += "              sum(b.PROD_QTY) v_ProdQty,                                 \n";
            sQuery += "              sum(b.BUHA) / count(b.BUHA)     v_Buha,                    \n";
            sQuery += "              0               v_PrevYearSub,                             \n";
            sQuery += "              0               v_PlanProdSubSum                           \n";
            sQuery += "         from D_TIME_ILJA a,                                             \n";
            sQuery += "              CA_FT_SANGSAN  b,                                          \n";
            sQuery += "              D_GONGJANG     c                                           \n";
            sQuery += "        where b.TIME_IDX = a.TM_IDX                                      \n";
            sQuery += "          AND b.GONG_IDX = c.GO_IDX                                      \n";
            sQuery += "          AND a.Year = " + iYear.ToString() + "  -- 년                                       \n";
            sQuery += "          AND a.Month= " + sMonth + "     -- 월                                       \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일               \n";
            sQuery += "          AND b.ITEM_IDX IN                                              \n";
            sQuery += "                         (       \n";
            sQuery += "                         SELECT SAN_IDX          \n";
            sQuery += "                           FROM D_ITEM_SANGSAN   \n";
            sQuery += "                          WHERE SAN_ITMNM LIKE '%락탐%'  \n";
            sQuery += "                         )       \n";
            sQuery += "        group by                                                         \n";
            sQuery += "              c.GO_IDX  ,                                                \n";
            sQuery += "              c.GONGJANG                                                 \n";
            sQuery += "       UNION ALL                                                         \n";
            sQuery += "       select c.GO_IDX          v_GongCD,                                \n";
            sQuery += "              c.GONGJANG        v_GongName,                              \n";
            sQuery += "              0                 v_PlanQty,                               \n";
            sQuery += "              0                 v_ProdQty,                               \n";
            sQuery += "              0                 v_Buha,                                  \n";
            sQuery += "              (                                                          \n";
            sQuery += "              SUM(CASE WHEN a.Year = 2006 THEN b.PROD_QTY ELSE 0 END) -  \n";
            sQuery += "              SUM(CASE WHEN a.Year = 2005 THEN b.PROD_QTY ELSE 0 END)    \n";
            sQuery += "              )                 v_PrevYearSub ,                          \n";
            sQuery += "              0                 v_PlanProdSubSum                         \n";
            sQuery += "         from D_TIME_ILJA a,                                             \n";
            sQuery += "              CA_FT_SANGSAN  b,                                          \n";
            sQuery += "              D_GONGJANG     c                                           \n";
            sQuery += "        where b.TIME_IDX = a.TM_IDX                                      \n";
            sQuery += "          AND b.GONG_IDX = c.GO_IDX                                      \n";
            sQuery += "          AND a.Year IN (" + (iYear - 1).ToString() + ", " + iYear.ToString() + ")  -- 년                              \n";
            sQuery += "          AND a.Month= " + sMonth + "     -- 월                                       \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일               \n";
            sQuery += "          AND b.ITEM_IDX IN                                              \n";
            sQuery += "                         (       \n";
            sQuery += "                         SELECT SAN_IDX          \n";
            sQuery += "                           FROM D_ITEM_SANGSAN   \n";
            sQuery += "                          WHERE SAN_ITMNM LIKE '%락탐%'  \n";
            sQuery += "                         )       \n";
            sQuery += "        group by                                                         \n";
            sQuery += "              c.GO_IDX  ,                                                \n";
            sQuery += "              c.GONGJANG                                                 \n";
            sQuery += "       UNION ALL                                                         \n";
            sQuery += "       select c.GO_IDX          v_GongCD,                                \n";
            sQuery += "              c.GONGJANG        v_GongName,                              \n";
            sQuery += "              0                 v_PlanQty,                               \n";
            sQuery += "              0                 v_ProdQty,                               \n";
            sQuery += "              0                 v_Buha,                                  \n";
            sQuery += "              0                 v_PrevYearSub,                           \n";
            sQuery += "              SUM(b.PLAN_QTY - b.PROD_QTY) v_PlanProdSubSum              \n";
            sQuery += "         from D_TIME_ILJA a,                                             \n";
            sQuery += "              CA_FT_SANGSAN  b,                                          \n";
            sQuery += "              D_GONGJANG     c                                           \n";
            sQuery += "        where b.TIME_IDX = a.TM_IDX                                      \n";
            sQuery += "          AND b.GONG_IDX = c.GO_IDX                                      \n";
            sQuery += "          AND a.Year = " + iYear.ToString() + "  -- 년                                       \n";
            sQuery += "          AND a.Month BETWEEN 1 AND 12     -- 월                         \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일               \n";
            sQuery += "          AND b.ITEM_IDX IN                                              \n";
            sQuery += "                         (       \n";
            sQuery += "                         SELECT SAN_IDX          \n";
            sQuery += "                           FROM D_ITEM_SANGSAN   \n";
            sQuery += "                          WHERE SAN_ITMNM LIKE '%락탐%'  \n";
            sQuery += "                         )       \n";
            sQuery += "        group by                                                         \n";
            sQuery += "              c.GO_IDX  ,                                                \n";
            sQuery += "              c.GONGJANG                                                 \n";
            sQuery += "       ) A                                                               \n";
            sQuery += " GROUP BY                                                                \n";
            sQuery += "       v_GongCD,                                                         \n";
            sQuery += "       v_GongName                                                        \n";

            return sQuery;
        }

        private DataTable GetDTGongJang()
        {
            string sQuery = "";

            sQuery += "select GO_IDX    v_Code, \n";
            sQuery += "       GONGJANG  v_Name  \n";
            sQuery += "  from D_GONGJANG        \n";
            sQuery += "UNION ALL                \n";
            sQuery += "SELECT '' v_Code,        \n";
            sQuery += "       '" + masGongJang[GetChartInfo(EN_CHART.CH_TOT)] + "' v_Name     \n";
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsGong = gDbAgentEIS.Fill(sQuery);

            return dsGong.Tables[0];
        }

        private string[] GetMonthTerm(string asYear, string asMonth)
        {
            string[] saMonthTerm;

            string sYYYYMMs = asYear + "01";
            string sYYYYMMe = asYear + asMonth;

            saMonthTerm = TypeUtility.GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            return saMonthTerm;
        }

        private string[] GetMonthTerm(int aiYear, string asMonth)
        {
            return GetMonthTerm(aiYear.ToString(), asMonth);
        }

        private string[] GetMonthTerm(string asYear)
        {
            string[] saMonthTerm;

            string sYYYYMMs = asYear + "01";
            string sYYYYMMe = asYear + "12";

            saMonthTerm = TypeUtility.GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            return saMonthTerm;
        }

        private string[] GetMonthTerm(int aiYear)
        {
            return GetMonthTerm(aiYear.ToString());
        }


    #endregion


        #region 일별생산실적

        private void GridBinding()
        {
            UltraWebGrid1.DataSource = GetDTGrid();
            UltraWebGrid1.DataBind();
        }

        private void ChartBinding()
        {
            string sGongName = PageUtility.GetByTextDropDownList(ddlGong);
            DataTable dt = GetDTChart();
            Chart_Daily.DataSource = dt;

            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart_Daily, ChartImageType.Flash, 800, 250
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion



            //series1.ToolTip = "#VALY{N}";
            //series2.ToolTip = "#VALY{N}";
            // 시리즈 생성
            Series srProd = DundasCharts.CreateSeries(Chart_Daily, "", "Default", "일간 생산량", null, SeriesChartType.Line, 3, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            //srProd.ValueMembersY = "ProdQty";
            DatabaseBindingXY(srProd, "YMD", "ProdQty", dt);
            DundasAnimations.GrowingAnimation(Chart_Daily, srProd, 0, 0 + 1, true);
            srProd.MarkerStyle = GetMarkerStyle(0);
            srProd.ToolTip = "#VALY{N0}";


            Series srBuha = DundasCharts.CreateSeries(Chart_Daily, "", "Default", "부하율", null, SeriesChartType.Line, 3, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            //srBuha.ValueMembersY = "Buha";
            DatabaseBindingXY(srBuha, "YMD", "Buha", dt);
            DundasAnimations.GrowingAnimation(Chart_Daily, srBuha, 1, 1 + 1, true);
            srBuha.MarkerStyle = GetMarkerStyle(2);
            srBuha.ToolTip = "#VALY{P0}";
            


            Series srRate = DundasCharts.CreateSeries(Chart_Daily, "", "Default", "계획대비일간실적", null, SeriesChartType.Line, 3, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            //srRate.ValueMembersY = "Rate";
            DatabaseBindingXY(srRate, "YMD", "Rate", dt);
            DundasAnimations.GrowingAnimation(Chart_Daily, srRate, 2, 2 + 1, true);
            srRate.MarkerStyle = GetMarkerStyle(1);
            srRate.ToolTip = "#VALY{P0}";


            // Title 생성
            FontStyle fontStyle = FontStyle.Bold;
            Chart_Daily.Titles[0].Position.Auto = false;
            Chart_Daily.ChartAreas["Default"].Axes[0].Title = ddlGong.SelectedItem.Text;
            Chart_Daily.ChartAreas["Default"].Axes[0].TitleFont = new Font("Trebuchet MS", 12, fontStyle);




            //srProd.ValueMemberX = "YMD";

            SetVisibleZeroPoint(Chart_Daily);

            string sChartArea = Chart_Daily.Series[srProd.Name].ChartArea;
            Chart_Daily.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";

            sChartArea = Chart_Daily.Series[srRate.Name].ChartArea;

            srRate.YAxisType = AxisType.Secondary;
            srBuha.YAxisType = AxisType.Secondary;

            Chart_Daily.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

            
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);

            string[] saDayTerm = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true);    // 1달동안의 날짜

            float fTmp = 0;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetDefaultQuery());
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("구분", typeof(string));

            for (int i = 0; i < saDayTerm.Length; i++)
            {
                dataTable.Columns.Add(saDayTerm[i].Substring(6, 2), typeof(float));
            }
            dataTable.Columns.Add("월간합계", typeof(float));

            // 생산량 (ProdQty)
            drNew = dataTable.NewRow();
            drNew["구분"] = "생산량";
            float fSum_Prod = 0;
            for (int i = 0; i < saDayTerm.Length; i++)
            {
                draDefault = dtTable.Select(
                                            "v_YMD = '" + saDayTerm[i] + "' "
                                           );

                fTmp = 0;

                for (int k = 0; k < draDefault.Length; k++)
                {
                    fTmp += Convert.ToSingle(draDefault[k]["v_ProdQty"]);
                }

                drNew[saDayTerm[i].Substring(6, 2)] = fTmp;
                fSum_Prod += fTmp;
                    //double.Parse(drNew[saDayTerm[i].Substring(6, 2)].ToString());
            }
            drNew["월간합계"] = fSum_Prod;
            dataTable.Rows.Add(drNew);

            // 계획대비일간실적 (Rate)
            drNew = dataTable.NewRow();
            drNew["구분"] = "계획대비일간실적";
            double dAvg_daily = 0;
            double dLength = 0;
            double dTmp = 0;
            for (int i = 0; i < saDayTerm.Length; i++)
            {
                
                draDefault = dtTable.Select(
                                            "v_YMD = '" + saDayTerm[i] + "' "
                                           );

                dTmp = 0;
                
                for (int k = 0; k < draDefault.Length; k++)
                {
                    dTmp += Convert.ToDouble(draDefault[k]["v_Rate"]);
                }

                drNew[saDayTerm[i].Substring(6, 2)] = Math.Round(dTmp, 0);
                dAvg_daily += double.Parse(drNew[saDayTerm[i].Substring(6, 2)].ToString());
                if (double.Parse(drNew[saDayTerm[i].Substring(6, 2)].ToString()) != 0)
                    dLength++;
               
            }


            drNew["월간합계"] = Math.Round((dAvg_daily / dLength),0);
            dataTable.Rows.Add(drNew);

            // 부하율 (Buha)
            drNew = dataTable.NewRow();
            drNew["구분"] = "부하율";
            double dAvg_buha = 0;
            double dLength_buha = 0;
            for (int i = 0; i < saDayTerm.Length; i++)
            {
                
                draDefault = dtTable.Select(
                                            "v_YMD = '" + saDayTerm[i] + "' "
                                           );

                dTmp = 0;

                for (int k = 0; k < draDefault.Length; k++)
                {
                    dTmp += Convert.ToDouble(draDefault[k]["v_Buha"]);
                }

                drNew[saDayTerm[i].Substring(6, 2)] = Math.Round(dTmp, 0);
                dAvg_buha += double.Parse(drNew[saDayTerm[i].Substring(6, 2)].ToString());
                if (double.Parse(drNew[saDayTerm[i].Substring(6, 2)].ToString()) != 0)
                    dLength_buha++;
            }
            drNew["월간합계"] = Math.Round((dAvg_buha / dLength_buha), 0);
            dataTable.Rows.Add(drNew);

            return dataTable;
        }

        // 챠트용 데이타테이블 반환
        private DataTable GetDTChart()
        {
            DateTime Day = DateTime.Now;
            
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);

            string[] saDayTerm = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true);    // 1달동안의 날짜
            int iDay = 0;
            if (Day.Year == int.Parse(sYear) && Day.Month == int.Parse(sMonth))
            {
                iDay = Day.Day;
            }
            else
            {
                iDay = saDayTerm.Length;
            }
            double dTmp1 = 0;
            double dTmp2 = 0;
            double dTmp3 = 0;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetDefaultQuery());
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("YMD", typeof(string));
            dataTable.Columns.Add("ProdQty", typeof(double));
            dataTable.Columns.Add("Rate", typeof(double));
            dataTable.Columns.Add("Buha", typeof(double));

            for (int i = 0; i < saDayTerm.Length; i++)
            {
                drNew = dataTable.NewRow();
                
                drNew["YMD"] = saDayTerm[i].Substring(6, 2);
               
                draDefault = dtTable.Select(
                                            "v_YMD = '" + saDayTerm[i] + "' "
                                           );

                dTmp1 = 0;
                dTmp2 = 0;
                dTmp3 = 0;

                for (int k = 0; k < draDefault.Length; k++)
                {
                    dTmp1 += Convert.ToDouble(draDefault[k]["v_ProdQty"]);
                    dTmp2 += Convert.ToDouble(draDefault[k]["v_Buha"]);
                    dTmp3 += Convert.ToDouble(draDefault[k]["v_Rate"]);
                }

                drNew["ProdQty"] = Math.Round(dTmp1, 0);
                drNew["Buha"] = Math.Round(dTmp2, 0);
                drNew["Rate"] = Math.Round(dTmp3, 0);

                dataTable.Rows.Add(drNew);
            }


            return dataTable;
        }

        private string GetChartQuery()
        {
            string sQuery = "";

            sQuery += GetDefaultQuery();

            return sQuery;
        }

        private string GetGridQuery()
        {
            string sQuery = "";

            sQuery += GetDefaultQuery();

            return sQuery;
        }

        private string GetDefaultQuery()
        {

            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            string sGong = PageUtility.GetByValueDropDownList(ddlGong);
            string sIF = "";
            if (ddlGong.SelectedItem.Text == "전체")
            {
                sIF = "sum(b.PROD_QTY)/564*100 ";
            }
            else
            {
                sIF = "sum(b.BUHA)";
            }

            string sQuery = "";

            sQuery += "SELECT A.v_Year + A.v_Month + A.v_Day v_YMD,                                                     \n";
            sQuery += "       A.v_ProdQty,                                                                              \n";
            sQuery += "       A.v_Buha,                                                                                 \n";
            sQuery += "       A.v_Rate                                                                                  \n";
            sQuery += "  FROM (                                                                                         \n";
            sQuery += "       select CONVERT(VARCHAR, a.Year) v_Year,                                                   \n";
            sQuery += "              CASE WHEN a.Month < 10 THEN '0' + CONVERT(VARCHAR, a.Month)                        \n";
            sQuery += "                                    ELSE CONVERT(VARCHAR, a.Month)                               \n";
            sQuery += "              END v_Month,                                                                       \n";
            sQuery += "              CASE WHEN a.DayNumberOfMonth < 10 THEN '0' + CONVERT(VARCHAR, a.DayNumberOfMonth)  \n";
            sQuery += "                                               ELSE CONVERT(VARCHAR, a.DayNumberOfMonth)         \n";
            sQuery += "              END v_Day,                                                                         \n";
            sQuery += "              sum(b.PROD_QTY) v_ProdQty,                                                         \n";
            sQuery += "              " + sIF + "    v_Buha,                                                             \n";
            sQuery += "              case when sum(b.PLAN_QTY)=0 then 0                                                 \n";
            sQuery += "                                          else sum(b.PROD_QTY) / sum(b.PLAN_QTY) * 100 end v_Rate    \n";
            sQuery += "         from D_TIME_ILJA a,                                                                     \n";
            sQuery += "              CA_FT_SANGSAN  b,                                                                  \n";
            sQuery += "              D_GONGJANG     c                                                                   \n";
            sQuery += "        where b.TIME_IDX = a.TM_IDX                                                              \n";
            sQuery += "          AND b.GONG_IDX = c.GO_IDX                                                              \n";
            sQuery += "          AND a.Year = " + sYear + "  -- 년                                                      \n";
            sQuery += "          AND a.Month= " + Convert.ToInt32(sMonth) + "     -- 월                                 \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일                                       \n";

            if (sGong != "")
                sQuery += "          AND c.GO_IDX   = " + sGong + "                                 \n";

            sQuery += "          AND b.ITEM_IDX IN                                                                \n";
            sQuery += "                         (       \n";
            sQuery += "                         SELECT SAN_IDX          \n";
            sQuery += "                           FROM D_ITEM_SANGSAN   \n";
            sQuery += "                          WHERE SAN_ITMNM LIKE '%락탐%'  \n";
            sQuery += "                         )       \n";
            sQuery += "        group by                                                                                 \n";
            sQuery += "              a.Year,                                                                            \n";
            sQuery += "              a.Month,                                                                           \n";
            sQuery += "              a.DayNumberOfMonth                                                                 \n";
            sQuery += "       ) A                                                                                       \n";

            return sQuery;
        }


    private DataTable GetDTLast()
    {
        string sYear = PageUtility.GetByValueDropDownList(ddlYear);
        string sQuery = "";
        sQuery += "	SELECT MM,SUM(월간실적) 월간실적,SUM(월간계획) 월간계획,SUM(전년월간실적) 전년월간실적      	    \n";
        sQuery += "	FROM (                                                                                              \n";
        sQuery += "	SELECT  DISTINCT SUBSTRING(CONVERT(VARCHAR(6),yyyy_mm),5,2) MM,월간실적,월간계획,전년월간실적       \n";
        sQuery += "	FROM (                                                                                              \n";
        sQuery += "	SELECT 	A.yyyy_mm                                                                                   \n";
        sQuery += "		,SUM(B.PROD_QTY) 월간실적                                                                       \n";
        sQuery += "		,SUM(B.PLAN_QTY) 월간계획                                                                       \n";
        sQuery += "		,0                 전년월간실적                                                                 \n";
        sQuery += "	FROM      D_TIME_ILJA A                                                                             \n";
        sQuery += "		,CA_FT_SANGSAN B                                                                                \n";
        sQuery += "		,D_ITEM_SANGSAN C                                                                               \n";
        sQuery += "	WHERE 	A.TM_IDX=B.TIME_IDX                                                                         \n";
        sQuery += "		AND C.SAN_IDX=B.ITEM_IDX                                                                        \n";
        sQuery += "		AND C.SAN_ITMNM='카프로락탐'                                                                    \n";
        sQuery += "		AND A.Year=" + sYear + "                                                                        \n";
        sQuery += "	GROUP BY 	A.yyyy_mm                                                                               \n";
        sQuery += "	UNION ALL                                                                                           \n";
        sQuery += "	SELECT 	A.yyyy_mm                                                                                   \n";
        sQuery += "		,0	월간실적                                                                                    \n";
        sQuery += "		,0	월간계획                                                                                    \n";
        sQuery += "		,SUM(B.PROD_QTY) 전년월간실적                                                                   \n";
        sQuery += "	FROM      D_TIME_ILJA A                                                                             \n";
        sQuery += "		,CA_FT_SANGSAN B                                                                                \n";
        sQuery += "		,D_ITEM_SANGSAN C                                                                               \n";
        sQuery += "	WHERE A.TM_IDX=B.TIME_IDX                                                                           \n";
        sQuery += "		AND C.SAN_IDX=B.ITEM_IDX                                                                        \n";
        sQuery += "		AND C.SAN_ITMNM='카프로락탐'                                                                    \n";
        sQuery += "		AND A.Year=" + sYear + "   -1                                                                   \n";
        sQuery += "	GROUP BY A.yyyy_mm	                                                                                \n";
        sQuery += "	 )  A                                                                                               \n";
        sQuery += "	) B                                                                                                 \n";
        sQuery += "	GROUP BY MM                                                                                         \n";
        sQuery += "	HAVING SUM(월간실적) > 0                                                                            \n";
        MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataSet dsTable = gDbAgentEIS.Fill(sQuery);
        DataTable dtTable = dsTable.Tables[0];
        return dtTable;
    
    }


    private void ChartBinding3()
    {
        string sYear = PageUtility.GetByValueDropDownList(ddlYear) + "년";
        string sPreYear = Convert.ToString(int.Parse(PageUtility.GetByValueDropDownList(ddlYear)) - 1) + "년";

        DataTable dataTable = GetDTLast();
        
        float fTotal=0;

        dataTable.Columns.Add("년간실적", typeof(float));
        dataTable.Columns.Add("년간계획", typeof(float));
        dataTable.Columns.Add("전년연간실적", typeof(float));
        
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            
            for (int j = 4; j < dataTable.Columns.Count; j++)
            {
                if (i == 0)
                {
                    dataTable.Rows[i][j] = Convert.ToSingle(dataTable.Rows[i][j - 3]);
                }
                else
                {
                    fTotal = 0;
                    for (int k = 0; k < i+1; k++)
                    {
                        fTotal += Convert.ToSingle(dataTable.Rows[k][j - 3]);

                    }
                    dataTable.Rows[i][j] = fTotal;
                }
            }
            
        }

        



        ChartSum.DataSource = dataTable;

        #region 챠트 초기화
        DundasCharts.DundasChartBase(ChartSum, ChartImageType.Flash, 800, 250
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
        #endregion

        // 시리즈 생성
        Series srSeries1 = DundasCharts.CreateSeries(ChartSum, "", "Default", sYear+" 월간실적", null, SeriesChartType.Column, 2, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        srSeries1.ValueMembersY = "월간실적";
        DundasAnimations.GrowingAnimation(ChartSum, srSeries1, 0, 0 + 1, true);
        //srSeries1.MarkerStyle = GetMarkerStyle(0);
        srSeries1.ToolTip = "#VALY{N0}";


        Series srSeries2 = DundasCharts.CreateSeries(ChartSum, "", "Default", sYear + " 월간계획", null, SeriesChartType.Column, 2, GetChartColor(9), GetChartColor(9), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        srSeries2.ValueMembersY = "월간계획";
        DundasAnimations.GrowingAnimation(ChartSum, srSeries2, 1, 1 + 1, true);
        //srSeries2.MarkerStyle = GetMarkerStyle(1);
        srSeries2.ToolTip = "#VALY{N0}";
       


        Series srSeries3 = DundasCharts.CreateSeries(ChartSum, "", "Default", sPreYear + " 월간실적", null, SeriesChartType.Column, 2, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        srSeries3.ValueMembersY = "전년월간실적";
        DundasAnimations.GrowingAnimation(ChartSum, srSeries3, 2, 2 + 1, true);
        //srSeries3.MarkerStyle = GetMarkerStyle(2);
        srSeries3.ToolTip = "#VALY{N0}";


        Series srSeries4 = DundasCharts.CreateSeries(ChartSum, "", "Default", sYear + " 년간실적", null, SeriesChartType.Line, 3, GetChartColor(6), GetChartColor(6), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        srSeries4.ValueMembersY = "년간실적";
        DundasAnimations.GrowingAnimation(ChartSum, srSeries4, 3, 3 + 1, true);
        srSeries4.MarkerStyle = GetMarkerStyle(0);
        srSeries4.ToolTip = "#VALY{N0}";


        Series srSeries5 = DundasCharts.CreateSeries(ChartSum, "", "Default", sYear + " 년간계획", null, SeriesChartType.Line, 3, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        srSeries5.ValueMembersY = "년간계획";
        DundasAnimations.GrowingAnimation(ChartSum, srSeries5, 4, 4 + 1, true);
        srSeries5.MarkerStyle = GetMarkerStyle(1);
        srSeries5.ToolTip = "#VALY{N0}";



        Series srSeries6 = DundasCharts.CreateSeries(ChartSum, "", "Default", sPreYear + " 년간실적", null, SeriesChartType.Line, 3, GetChartColor(11), GetChartColor(11), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        srSeries6.ValueMembersY = "전년연간실적";
        DundasAnimations.GrowingAnimation(ChartSum, srSeries6, 5, 5 + 1, true);
        srSeries6.MarkerStyle = GetMarkerStyle(2);
        srSeries6.ToolTip = "#VALY{N0}";
        //// Title 생성
        //FontStyle fontStyle = FontStyle.Bold;
        //ChartSum.Titles[0].Position.Auto = false;
        //ChartSum.ChartAreas["Default"].Axes[0].Title = ddlGong.SelectedItem.Text;
        //ChartSum.ChartAreas["Default"].Axes[0].TitleFont = new Font("Trebuchet MS", 12, fontStyle);




        srSeries2.ValueMemberX = "MM";
        srSeries4.YAxisType = AxisType.Secondary;
        srSeries5.YAxisType = AxisType.Secondary;
        srSeries6.YAxisType = AxisType.Secondary;
        string sChartArea = ChartSum.Series[srSeries2.Name].ChartArea;
        ChartSum.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        ChartSum.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

        Font font1 = new Font("Gulim", 9, FontStyle.Regular);
        Legend legend = DundasCharts.CreateLegend(ChartSum, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
        DundasCharts.SetChartArea(ChartSum.ChartAreas["Default"], false);
        //DundasCharts.SetChartArea(ChartSum.ChartAreas["Default"],Color.Transparent,Color.Tomato,Color.Violet,ChartDashStyle.Solid,3,true);
        sChartArea = ChartSum.Series[srSeries2.Name].ChartArea;

        


    }








        #endregion


        #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            ChartBinding2();
            ChartBinding();
            GridBinding();
            ChartBinding3();
        }

    
        protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP1);

            //e.Layout.Bands[0].Columns[0].MergeCells = true;
            //e.Layout.Bands[0].Columns[0].CellStyle.VerticalAlign = VerticalAlign.Top;
            //e.Layout.Bands[0].Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            //e.Layout.Bands[0].Columns[1].MergeCells = true;

            for (int i = 1; i < UltraWebGrid1.Columns.Count-1; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,###";
                e.Layout.Bands[0].Columns[i].Width = 35;
            }
            e.Layout.Bands[0].Columns[UltraWebGrid1.Columns.Count - 1].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.Bands[0].Columns[UltraWebGrid1.Columns.Count - 1].Width = 65;
            e.Layout.Bands[0].Columns[UltraWebGrid1.Columns.Count - 1].Format = "#,###.##0";
        }
        protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
        {
            #region 해당 열에 %기호 붙이기
            if (e.Row.Cells[0].Value.ToString().IndexOf("생산량") >= 0)
            {
            }
            else
            {
                for (int i = 1; i < UltraWebGrid1.Columns.Count; i++)
                {
                    e.Row.Cells[i].Value += "%";
                }
            }
            #endregion
        }

    


    #endregion



    
}
