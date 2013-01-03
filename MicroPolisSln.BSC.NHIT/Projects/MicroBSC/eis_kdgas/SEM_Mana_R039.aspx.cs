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
using MicroBSC.Data.Oracle;
using System.Text;


public partial class eis_SEM_Mana_R039 : EISPageBase
{
    private enum EN_YEARMON : int
    {
        YEARMON0    = 0,
        YEARMON1    = 1,
        YEARMON2    = 2
    }

    private int GetYMPos(EN_YEARMON enCol)
    {
        return (int)enCol;
    }

    private DBAgent dbAgent = null;

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
            this.ddlLocation.Items.Clear();
            this.ddlGubun.Items.Clear();

            for (int i = dtNow.Year - 2; i <= dtNow.Year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            this.SetAreaDropDownList(ddlLocation);

            ddlGubun.Items.Add(new ListItem("당월", "당월"));
            ddlGubun.Items.Add(new ListItem("누계", "누계"));

            FindByValueDropDownList(ddlYear, (dtNow.Year).ToString());
            FindByTextDropDownList(ddlLocation, "전체");
        }

        private void InitControlEvent()
        {

        }

        private void SetPageData()
        {
            GridBinding();
            ChartBinding();
        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {

        }
    #endregion

    #region 내부함수
        private void ChartBinding()
        {
            string sYear0, sYear1, sYear2;  // 3년에 대한 년도 (0=현재, 1=현재-1, 2=현재-2)
            ArrayList al3YearMon = GetALYearMon(out sYear0, out sYear1, out sYear2);

            // 전체 구분 추출쿼리
            string sQueryGubun = "";
            sQueryGubun += "SELECT a.SEM_CODE2_T            ,               -- 매출구분 코드(용도)  \n";
            sQueryGubun += "       a.SEM_CODE2_NAME                         -- 매출구분 명          \n";
            sQueryGubun += "  FROM SEM_CODE_MASTER      a,                  -- 코드 Master Table    \n";
            sQueryGubun += "       SEM_DEMAND_DEVELOP   b                   -- 월 수요개발 현황     \n";
            sQueryGubun += " WHERE a.SEM_CODE1_T = '06'                                             \n";
            sQueryGubun += "   AND b.DEVE_GUBN_CODE_T = a.SEM_CODE3_T                               \n";
            sQueryGubun += "   AND (b.DEVE_DATE_T BETWEEN  '" + sYear2 + "01' AND '" + sYear0 + "12')           \n";
            sQueryGubun += " GROUP BY                                                               \n";
            sQueryGubun += "       a.SEM_CODE2_T,                                                   \n";
            sQueryGubun += "       a.SEM_CODE2_NAME                                                 \n";

            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
            DataTable dtGubun = dbAgent.FillDataSet(sQueryGubun, "Data").Tables[0];

            DataTable dataTable = GetDTChart();

            #region 챠트 초기화
                DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                    , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                    , -1
                    , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

                
            #endregion

            #region 챠트1 셋팅 START
                SetLineChart(dataTable);
            #endregion 챠트1 셋팅 END

        }

        private void SetLineChart(DataTable adtTable)
        {
            string sGubun = GetByValueDropDownList(ddlGubun);
            
            string[] saTmpTerm; // 각 년도별 저장된 년월 문자열배열 추출시 사용되는 임시변수
            
            string sYear0, sYear1, sYear2;  // 3년에 대한 년도 (0=현재, 1=현재-1, 2=현재-2)
            ArrayList al3YearMon = GetALYearMon(out sYear0, out sYear1, out sYear2);

            DataRow[] draTmp    = null; // 데이타테이블 조건추출
            DataRow drTmp       = null; // 임시저장 데이타로우
            double dTmp         = 0;    // 임시저장 double 변수
            double dTmp2        = 0;

            // Line챠트용 테이블 구조 생성
            DataTable dtLineChart = new DataTable();

            // X축 데이타 처리
            dtLineChart.Columns.Add("MONTH",    typeof(string));

            // 시리즈
            dtLineChart.Columns.Add("MONTH_" + sYear2 + "_T",   typeof(double));
            dtLineChart.Columns.Add("MONTH_" + sYear1 + "_T",   typeof(double));
            dtLineChart.Columns.Add("MONTH_" + sYear0 + "_T",   typeof(double));

            for (int i=1; i<=12; i++)
            {
                drTmp = dtLineChart.NewRow();
                drTmp["MONTH"] = i.ToString() + "월";

                    draTmp = adtTable.Select(
                                            "deve_date_t = '" + sYear2 + (i < 10 ? "0" + i.ToString() : i.ToString()) + "' "
                                            );

                    // 해당년월 매출합계 저장
                    dTmp = 0;
                    for (int j=0; j<draTmp.Length; j++)
                    {
                        if (sGubun == "당월")
                        {
                            dTmp += Convert.ToDouble(draTmp[j]["v_Actual"]);
                        }
                        else
                        {
                            dTmp += Convert.ToDouble(draTmp[j]["v_SumActual"]);
                        }
                    }

                    drTmp["MONTH_" + sYear2 + "_T"] = dTmp;

                    draTmp = adtTable.Select(
                                            "deve_date_t = '" + sYear1 + (i < 10 ? "0" + i.ToString() : i.ToString()) + "' "
                                            );

                    // 해당년월 매출합계 저장
                    dTmp = 0;
                    for (int j = 0; j < draTmp.Length; j++)
                    {
                        if (sGubun == "당월")
                        {
                            dTmp += Convert.ToDouble(draTmp[j]["v_Actual"]);
                        }
                        else
                        {
                            dTmp += Convert.ToDouble(draTmp[j]["v_SumActual"]);
                        }
                    }

                    drTmp["MONTH_" + sYear1 + "_T"] = dTmp;

                    draTmp = adtTable.Select(
                                                "deve_date_t = '" + sYear0 + (i < 10 ? "0" + i.ToString() : i.ToString()) + "' "
                                                );

                    // 해당년월 매출합계 저장
                    dTmp = 0;
                    for (int j = 0; j < draTmp.Length; j++)
                    {
                        if (sGubun == "당월")
                        {
                            dTmp += Convert.ToDouble(draTmp[j]["v_Actual"]);
                        }
                        else
                        {
                            dTmp += Convert.ToDouble(draTmp[j]["v_SumActual"]);
                        }
                    }

                    drTmp["MONTH_" + sYear0 + "_T"] = dTmp;
                
                dtLineChart.Rows.Add(drTmp);
            }

            Series ddcSerLine2 = DundasCharts.CreateSeries(Chart1, "Series2", "Default",
                                                            sYear2, null, SeriesChartType.Line, 3,
                                                            GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSerLine1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default",
                                                            sYear1, null, SeriesChartType.Line, 3,
                                                            GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSerLine0 = DundasCharts.CreateSeries(Chart1, "Series0", "Default",
                                                            sYear0, null, SeriesChartType.Line, 3,
                                                            GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            
            Chart1.DataSource = dtLineChart;
            ddcSerLine2.ValueMemberX = "MONTH";

            DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
            ddcSerLine2.ValueMembersY = "MONTH_" + sYear2 + "_T";
            ddcSerLine1.ValueMembersY = "MONTH_" + sYear1 + "_T";
            ddcSerLine0.ValueMembersY = "MONTH_" + sYear0 + "_T";

            DundasAnimations.GrowingAnimation(Chart1, ddcSerLine2, 0.0, 0.5, false);
            DundasAnimations.GrowingAnimation(Chart1, ddcSerLine1, 0.5, 1.0, true);
            DundasAnimations.GrowingAnimation(Chart1, ddcSerLine0, 1.0, 1.0, true);

            ddcSerLine2.MarkerStyle = GetMarkerStyle(0);
            ddcSerLine2.MarkerColor = GetChartColor(0);
            ddcSerLine2.MarkerBorderColor = GetChartColor(0);

            ddcSerLine1.MarkerStyle = GetMarkerStyle(1);
            ddcSerLine1.MarkerColor = GetChartColor(1);
            ddcSerLine1.MarkerBorderColor = GetChartColor(1);

            ddcSerLine0.MarkerStyle = GetMarkerStyle(2);
            ddcSerLine0.MarkerColor = GetChartColor(2);
            ddcSerLine0.MarkerBorderColor = GetChartColor(2);

            //lblChart_Pie0.Text = sYear0 + "년";
            //lblChart_Pie1.Text = sYear1 + "년";
            //lblChart_Pie2.Text = sYear2 + "년";
        }

        private void GridBinding()
        {
            UltraWebGrid1.DataSource = GetDTGrid();
            UltraWebGrid1.DataBind();
        }

        /// <summary>
        /// GetALYearMon
        ///     : 3년동안의 년월을 담은 문자열배열을 가진 ArrayList 리턴
        /// </summary>
        /// <param name="sYMs">시작년월 리턴</param>
        /// <param name="sYMe">종료년월 리턴</param>
        /// <returns></returns>
        private ArrayList GetALYearMon(out string sYear0, out string sYear1, out string sYear2)
        {
            ArrayList alRet = new ArrayList();

            string  sYear = GetByValueDropDownList(ddlYear);
            
            int     iYear = Convert.ToInt32(sYear);

            sYear0 = sYear;
            sYear1 = Convert.ToString(iYear - 1);
            sYear2 = Convert.ToString(iYear - 2);

            string[] saMonthTerm0 = GetMonthDiff(sYear0 + "01", sYear0 + "12", "M");
            string[] saMonthTerm1 = GetMonthDiff(sYear1 + "01", sYear1 + "12", "M");
            string[] saMonthTerm2 = GetMonthDiff(sYear2 + "01", sYear2 + "12", "M");

            alRet.Add(saMonthTerm0);
            alRet.Add(saMonthTerm1);
            alRet.Add(saMonthTerm2);

            return alRet;
        }

        /// <summary>
        /// GetDTChart
        ///     : 챠트용 데이타테이블 반환
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTChart()
        {
            string sQuery = GetChartQuery();   // 챠트 셋팅용 쿼리
            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);

            DataSet ds = dbAgent.FillDataSet(sQuery, "Data");

            return ds.Tables[0];
        }

        /// <summary>
        /// GetDTGrid
        ///     : 그리드용 데이타테이블 반환
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTGrid()
        {
            int i, j, k, l, iSubTot;
            string[] saTmpTerm; // 각 년도별 저장된 년월 문자열배열 추출시 사용되는 임시변수
            
            string sGubun = GetByValueDropDownList(ddlGubun);   // 당월, 누계 정보

            string sYear0, sYear1, sYear2;  // 3년에 대한 년도 (0=현재, 1=현재-1, 2=현재-2)
            ArrayList al3YearMon = GetALYearMon(out sYear0, out sYear1, out sYear2);
            DataTable dtGubun = GetDTGubun();   // 전체구분

            string sQuery = GetGridQuery();
            DataSet ds = gDbAgent.Fill(sQuery);
            DataTable dtDefault;
            DataRow[] draSelect;

            double dTotTmp = 0, dTmp = 0; 
            double dSum = 0;
            double[] dSubTotal = new double[13];

            DataTable dtRet = new DataTable();
            DataRow drNew;

            dtRet.Columns.Add("년도", typeof(string));
            dtRet.Columns.Add("구분", typeof(string));
            dtRet.Columns.Add("합계", typeof(double));

            for (i=1; i<=12; i++)
            {
                dtRet.Columns.Add((i<10 ? "0" + i.ToString() : i.ToString()) + "월",    typeof(double));
            }

            if (ds.Tables.Count > 0)
            {
                dtDefault = ds.Tables[0];

                for (i = 0; i < al3YearMon.Count; i++)
                {
                    saTmpTerm = (string[])al3YearMon[i];

                    // SubTotal저장변수 초기화
                    for (iSubTot = 0; iSubTot < dSubTotal.Length; iSubTot++)
                    {
                        dSubTotal[iSubTot] = 0;
                    }

                    for (j = 0; j < dtGubun.Rows.Count; j++)
                    {
                        drNew = dtRet.NewRow();

                        drNew["년도"] = saTmpTerm[saTmpTerm.GetLowerBound(0)].Substring(0, 4);
                        drNew["구분"] = dtGubun.Rows[j]["SEM_CODE2_NAME"].ToString();
                        
                        dTotTmp = 0;
                        for (k = 0; k < saTmpTerm.Length; k++)
                        {
                            draSelect = dtDefault.Select(
                                                        "DEVE_DATE_T = '" + saTmpTerm[k] + "' "
                                                  + "AND SEM_CODE2_T = '" + dtGubun.Rows[j]["SEM_CODE2_T"].ToString() + "' "
                                                       );

                            dTmp = 0;
                            dSum = 0;
                            for (l = 0; l < draSelect.Length; l++)
                            {
                                if (sGubun == "당월")
                                {
                                    dTmp += Convert.ToDouble(draSelect[l]["v_Actual"]);
                                    dSum += Convert.ToDouble(draSelect[l]["v_Actual"]);
                                }
                                else if (sGubun == "누계")
                                {
                                    dTmp += Convert.ToDouble(draSelect[l]["v_SumActual"]);
                                    dSum += Convert.ToDouble(draSelect[l]["v_Actual"]);
                                }
                            }
                             dTotTmp += dSum;

                            drNew[saTmpTerm[k].Substring(4, 2) + "월"] = dTmp;
                            dSubTotal[k+1] += dTmp;
                        }

                        drNew["합계"] = dTotTmp;
                        dSubTotal[0] += dTotTmp;

                        dtRet.Rows.Add(drNew);
                    }

                    drNew = dtRet.NewRow();
                    drNew["년도"] = saTmpTerm[saTmpTerm.GetLowerBound(0)].Substring(0, 4);
                    drNew["구분"] = "계";
                    drNew["합계"] = dSubTotal[0];

                    // SubTotal저장변수 초기화
                    for (iSubTot = 1; iSubTot < dSubTotal.Length; iSubTot++)
                    {
                        drNew[(iSubTot < 10 ? "0" + iSubTot.ToString() : iSubTot.ToString()) + "월"] = dSubTotal[iSubTot];
                    }

                    dtRet.Rows.Add(drNew);
                }
            }

            return dtRet;
        }

        /// <summary>
        /// GetChartQuery
        ///     : 기본 쿼리문장을 가지고 챠트 표현에 맞도록 재구성
        /// </summary>
        /// <returns></returns>
        private string GetChartQuery()
        {
            string sYear0, sYear1, sYear2;  // 3년에 대한 년도 (0=현재, 1=현재-1, 2=현재-2)
            ArrayList al3YearMon = GetALYearMon(out sYear0, out sYear1, out sYear2);

            string sQuery = "";

            sQuery += "SELECT                                   \n";
            sQuery += "       SEM_CODE2_T      ,                \n";
            sQuery += "       SEM_CODE2_NAME   ,                \n";
            sQuery += "       DEVE_DATE_T      ,                \n";
            sQuery += "       SUM(v_Plan     ) v_Plan       ,   \n";
            sQuery += "       SUM(v_Actual   ) v_Actual     ,   \n";
            sQuery += "       SUM(v_SumPlan  ) v_SumPlan    ,   \n";
            sQuery += "       SUM(v_SumActual) v_SumActual      \n";
            sQuery += "  FROM (                                 \n";

            sQuery += GetDefaultQuery();

            sQuery += "       )                                 \n";
            sQuery += " WHERE 1=1                               \n";
            sQuery += " GROUP BY                                \n";
            sQuery += "       SEM_CODE2_T      ,                \n";
            sQuery += "       SEM_CODE2_NAME   ,                \n";
            sQuery += "       DEVE_DATE_T                       \n";

            return sQuery;
        }

        private string GetGridQuery()
        {
            string sQuery = "";

            sQuery += "SELECT                                   \n";
            sQuery += "       SEM_CODE2_T      ,                \n";
            sQuery += "       SEM_CODE2_NAME   ,                \n";
            sQuery += "       DEVE_DATE_T      ,                \n";
            sQuery += "       SUM(v_Plan     ) v_Plan       ,   \n";
            sQuery += "       SUM(v_Actual   ) v_Actual     ,   \n";
            sQuery += "       SUM(v_SumPlan  ) v_SumPlan    ,   \n";
            sQuery += "       SUM(v_SumActual) v_SumActual      \n";
            sQuery += "  FROM (                                 \n";

            sQuery += GetDefaultQuery();

            sQuery += "       )                                 \n";
            sQuery += " WHERE 1=1                               \n";
            sQuery += " GROUP BY                                \n";
            sQuery += "       SEM_CODE2_T      ,                \n";
            sQuery += "       SEM_CODE2_NAME   ,                \n";
            sQuery += "       DEVE_DATE_T                       \n";

            return sQuery;
        }

        private string GetDefaultQuery()
        {
            int i, j;
            string[] saTmpTerm; // 각 년도별 저장된 년월 문자열배열 추출시 사용되는 임시변수

            string sGubun = GetByValueDropDownList(ddlGubun);
            string sLocation = GetByValueDropDownList(ddlLocation);

            string sYear0, sYear1, sYear2;  // 3년에 대한 년도 (0=현재, 1=현재-1, 2=현재-2)
            ArrayList al3YearMon = GetALYearMon(out sYear0, out sYear1, out sYear2);

            string sRet = "";

            sRet += "SELECT SEM_CODE2_T      ,             \n";
            sRet += "       SEM_CODE2_NAME   ,             \n";
            sRet += "       DEVE_DATE_T      ,             \n";
            sRet += "       v_Plan           ,             \n";
            sRet += "       v_Actual         ,             \n";
            sRet += "       v_SumPlan        ,             \n";
            sRet += "       v_SumActual                    \n";
            sRet += "  FROM (                              \n";
            sRet += "       SELECT                         \n";
            sRet += "              b.SEM_CODE2_T    ,      \n";
            sRet += "              b.SEM_CODE2_NAME ,      \n";
            sRet += "              b.DEVE_DATE_T    ,      \n";
            sRet += "              --b.DEVE_OFFICE_T  ,    \n";
            sRet += "              SUM(NVL(a.v_Plan, 0))    v_Plan  ,                                              \n";
            sRet += "              SUM(NVL(a.v_Actual, 0))  v_Actual,                                              \n";
            sRet += "              SUM(NVL(A.v_SumPlan    , 0)) v_SumPlan       ,                                  \n";
            sRet += "              SUM(NVL(A.v_SumActual  , 0)) v_SumActual                                        \n";
            sRet += "         FROM (                                                                               \n";
            sRet += "              SELECT a.SEM_CODE2_T            ,               -- 매출구분 코드(용도)          \n";
            sRet += "                     a.SEM_CODE2_NAME         ,               -- 매출구분 명                  \n";
            sRet += "                     b.DEVE_DATE_T            ,               -- 년월(yyyymm)                 \n";
            sRet += "                     b.DEVE_OFFICE_T          ,               -- 사업장 코드                  \n";
            sRet += "                     SUM(b.DEVE_PLAN)       v_Plan      ,     -- 월 수요개발계획              \n";
            sRet += "                     SUM(b.DEVE_ACTUAL)     v_Actual    ,     -- 월 수요개발 건수             \n";
            sRet += "                     SUM(b.DEVE_SUM_PLAN)   v_SumPlan   ,     -- 월 누계 수요개발 계획        \n";
            sRet += "                     SUM(b.DEVE_SUM_ACTUAL) v_SumActual       -- 월 누계 수요개발 건수        \n";
            sRet += "                FROM SEM_CODE_MASTER a,                       -- 코드 Master Table            \n";
            sRet += "                     SEM_DEMAND_DEVELOP b                     -- 월 수요개발 현황             \n";
            sRet += "               WHERE a.SEM_CODE1_T = '06'                                                     \n";
            sRet += "                 AND b.DEVE_GUBN_CODE_T = a.SEM_CODE3_T                                       \n";
            sRet += "                 AND a.SEM_CODE3_T <> '120'                                                   \n";

            if (al3YearMon.Count > GetYMPos(EN_YEARMON.YEARMON0))
            {
                saTmpTerm = (string[])al3YearMon[GetYMPos(EN_YEARMON.YEARMON0)];
                sRet += "                 AND b.DEVE_DATE_T BETWEEN  '" + saTmpTerm[saTmpTerm.GetLowerBound(0)] + "' AND '" + saTmpTerm[saTmpTerm.GetUpperBound(0)] + "'                       \n";
            }

            sRet += "               GROUP BY                                                                       \n";
            sRet += "                     a.SEM_CODE2_T,                                                           \n";
            sRet += "                     a.SEM_CODE2_NAME,                                                        \n";
            sRet += "                     b.DEVE_DATE_T,                                                           \n";
            sRet += "                     b.DEVE_OFFICE_T                                                          \n";
            sRet += "              UNION ALL                                                                       \n";
            sRet += "              SELECT a.SEM_CODE2_T            ,               -- 매출구분 코드(용도)          \n";
            sRet += "                     a.SEM_CODE2_NAME         ,               -- 매출구분 명                  \n";
            sRet += "                     b.DEVE_DATE_T            ,               -- 년월(yyyymm)                 \n";
            sRet += "                     b.DEVE_OFFICE_T          ,               -- 사업장 코드                  \n";
            sRet += "                     SUM(b.DEVE_PLAN)       v_Plan      ,     -- 월 수요개발계획              \n";
            sRet += "                     SUM(b.DEVE_ACTUAL)     v_Actual    ,     -- 월 수요개발 건수             \n";
            sRet += "                     SUM(b.DEVE_SUM_PLAN)   v_SumPlan   ,     -- 월 누계 수요개발 계획        \n";
            sRet += "                     SUM(b.DEVE_SUM_ACTUAL) v_SumActual       -- 월 누계 수요개발 건수        \n";
            sRet += "                FROM SEM_CODE_MASTER a,                       -- 코드 Master Table            \n";
            sRet += "                     SEM_DEMAND_DEVELOP b                     -- 월 수요개발 현황             \n";
            sRet += "               WHERE a.SEM_CODE1_T = '06'                                                     \n";
            sRet += "                 AND b.DEVE_GUBN_CODE_T = a.SEM_CODE3_T                                       \n";
            sRet += "                 AND a.SEM_CODE3_T <> '120'                                                   \n";

            if (al3YearMon.Count > GetYMPos(EN_YEARMON.YEARMON1))
            {
                saTmpTerm = (string[])al3YearMon[GetYMPos(EN_YEARMON.YEARMON1)];
                sRet += "                 AND b.DEVE_DATE_T BETWEEN  '" + saTmpTerm[saTmpTerm.GetLowerBound(0)] + "' AND '" + saTmpTerm[saTmpTerm.GetUpperBound(0)] + "'                       \n";
            }

            sRet += "               GROUP BY                                                                       \n";
            sRet += "                     a.SEM_CODE2_T,                                                           \n";
            sRet += "                     a.SEM_CODE2_NAME,                                                        \n";
            sRet += "                     b.DEVE_DATE_T,                                                           \n";
            sRet += "                     b.DEVE_OFFICE_T                                                          \n";
            sRet += "              UNION ALL                                                                       \n";
            sRet += "              SELECT a.SEM_CODE2_T            ,               -- 매출구분 코드(용도)          \n";
            sRet += "                     a.SEM_CODE2_NAME         ,               -- 매출구분 명                  \n";
            sRet += "                     b.DEVE_DATE_T            ,               -- 년월(yyyymm)                 \n";
            sRet += "                     b.DEVE_OFFICE_T          ,               -- 사업장 코드                  \n";
            sRet += "                     SUM(b.DEVE_PLAN)       v_Plan      ,     -- 월 수요개발계획              \n";
            sRet += "                     SUM(b.DEVE_ACTUAL)     v_Actual    ,     -- 월 수요개발 건수             \n";
            sRet += "                     SUM(b.DEVE_SUM_PLAN)   v_SumPlan   ,     -- 월 누계 수요개발 계획        \n";
            sRet += "                     SUM(b.DEVE_SUM_ACTUAL) v_SumActual       -- 월 누계 수요개발 건수        \n";
            sRet += "                FROM SEM_CODE_MASTER a,                       -- 코드 Master Table            \n";
            sRet += "                     SEM_DEMAND_DEVELOP b                     -- 월 수요개발 현황             \n";
            sRet += "               WHERE a.SEM_CODE1_T = '06'                                                     \n";
            sRet += "                 AND b.DEVE_GUBN_CODE_T = a.SEM_CODE3_T                                       \n";
            sRet += "                 AND a.SEM_CODE3_T <> '120'                                                   \n";

            if (al3YearMon.Count > GetYMPos(EN_YEARMON.YEARMON2))
            {
                saTmpTerm = (string[])al3YearMon[GetYMPos(EN_YEARMON.YEARMON2)];
                sRet += "                 AND b.DEVE_DATE_T BETWEEN  '" + saTmpTerm[saTmpTerm.GetLowerBound(0)] + "' AND '" + saTmpTerm[saTmpTerm.GetUpperBound(0)] + "'                       \n";
            }

            sRet += "               GROUP BY                                                                       \n";
            sRet += "                     a.SEM_CODE2_T,                                                           \n";
            sRet += "                     a.SEM_CODE2_NAME,                                                        \n";
            sRet += "                     b.DEVE_DATE_T,                                                           \n";
            sRet += "                     b.DEVE_OFFICE_T                                                          \n";
            sRet += "              ) a,                                                                            \n";
            sRet += "              (                                                                               \n";
            sRet += "              SELECT                                                                          \n";
            sRet += "                     A.SEM_CODE2_T,                                                           \n";
            sRet += "                     a.SEM_CODE2_NAME,                                                        \n";
            sRet += "                     b.v_DYYYYMM DEVE_DATE_T,                                                 \n";
            sRet += "                     a.DEVE_OFFICE_T                                                          \n";
            sRet += "                FROM (                                                                        \n";
            sRet += "                     SELECT a.SEM_CODE2_T            ,               -- 매출구분 코드(용도)   \n";
            sRet += "                            a.SEM_CODE2_NAME         ,               -- 매출구분 명           \n";
            sRet += "                            b.DEVE_OFFICE_T                                                   \n";
            sRet += "                       FROM SEM_CODE_MASTER      a,                  -- 코드 Master Table     \n";
            sRet += "                            SEM_DEMAND_DEVELOP   b                   -- 월 수요개발 현황      \n";
            sRet += "                      WHERE a.SEM_CODE1_T = '06'                                              \n";
            sRet += "                        AND b.DEVE_GUBN_CODE_T = a.SEM_CODE3_T                                \n";
            sRet += "                        AND a.SEM_CODE3_T <> '120'                                            \n";
            sRet += "                        AND (b.DEVE_DATE_T BETWEEN  '" + sYear2 + "01' AND '" + sYear0 + "12')        \n";
            sRet += "                      GROUP BY                                                                \n";
            sRet += "                            a.SEM_CODE2_T,                                                    \n";
            sRet += "                            a.SEM_CODE2_NAME,                                                 \n";
            sRet += "                            b.DEVE_OFFICE_T                                                   \n";
            sRet += "                     ) a,                                                                     \n";
            sRet += "                     (                                                                        \n";

            for (i=0; i<al3YearMon.Count; i++)
            {
                saTmpTerm = (string[])al3YearMon[i];

                for (j=0; j<saTmpTerm.Length; j++)
                {
                    sRet += "                     SELECT '" + saTmpTerm[j] + "' v_DYYYYMM FROM dual UNION    \n";
                }
            }

            sRet += "                     SELECT '000000' v_DYYYYMM FROM dual           \n";

            sRet += "                     ) b                                          \n";
            sRet += "              ) b                                                 \n";
            sRet += "        WHERE a.SEM_CODE2_T    (+) = b.SEM_CODE2_T                \n";
            sRet += "          AND a.SEM_CODE2_NAME (+) = b.SEM_CODE2_NAME             \n";
            sRet += "          AND a.DEVE_DATE_T    (+) = b.DEVE_DATE_T                \n";
            sRet += "          AND a.DEVE_OFFICE_T  (+) = b.DEVE_OFFICE_T              \n";
            sRet += "          AND b.DEVE_DATE_T    <> '000000'                        \n";

            if (sLocation != "--")
                sRet += "          AND b.DEVE_OFFICE_T      = '" + sLocation + "'                         \n";

            //if (sGubun == "당월")
            //    sRet += "          AND (b.deve_date_t = '" + sYYYYMMe + "' OR b.deve_date_t = '" + sYYYYMMeP + "')                 \n";

            sRet += "        GROUP BY                                                  \n";
            sRet += "              b.SEM_CODE2_T    ,                                  \n";
            sRet += "              b.SEM_CODE2_NAME ,                                  \n";
            sRet += "              b.DEVE_DATE_T                                       \n";
            sRet += "       )                                                          \n";


            return sRet;
        }
        
        /// <summary>
        /// GetDTGubun
        ///     : 코드마스터에 등록된 전체 구분 추출
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTGubun()
        {
            string sQuery = "";

            sQuery += "SELECT a.SEM_CODE2_T            ,   -- 매출구분 코드(용도)   \n";
            sQuery += "       a.SEM_CODE2_NAME             -- 매출구분 명           \n";
            sQuery += "  FROM SEM_CODE_MASTER      a       -- 코드 Master Table     \n";
            sQuery += " WHERE a.SEM_CODE1_T = '06'                                  \n";
            sQuery += " GROUP BY                                                    \n";
            sQuery += "       a.SEM_CODE2_T,                                        \n";
            sQuery += "       a.SEM_CODE2_NAME                                      \n";

            DataSet ds = gDbAgent.Fill(sQuery);
            DataTable dtRet = new DataTable();
            DataRow drNew;

            dtRet.Columns.Add("SEM_CODE2_T",    typeof(string));
            dtRet.Columns.Add("SEM_CODE2_NAME", typeof(string));

            if (ds.Tables.Count > 0)
            {
                for (int i=0; i<ds.Tables[0].Rows.Count; i++)
                {
                    drNew = dtRet.NewRow();

                    drNew["SEM_CODE2_T"] = ds.Tables[0].Rows[i]["SEM_CODE2_T"].ToString();
                    drNew["SEM_CODE2_NAME"] = ds.Tables[0].Rows[i]["SEM_CODE2_NAME"].ToString();

                    dtRet.Rows.Add(drNew);
                }
            }

            return dtRet;
        }
    #endregion

    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            GridBinding();
            ChartBinding();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].Columns[0].MergeCells = true;

            e.Layout.Bands[0].Columns[0].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP1);
            e.Layout.Bands[0].Columns[1].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP2);

            for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.##";

            }
        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            #region 서브토탈 및 총합계열에 대한 색깔변경
                if (e.Row.Cells[1].Value.ToString().IndexOf("계") >= 0)
                {

                    e.Row.Cells[1].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME1);
                    for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
                    {
                        e.Row.Cells[i].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
                    }
                }
            #endregion
        }
    #endregion
    
}
