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
//using MicroBSC.Data;
using System.Text;

public partial class eis_eis0004_Chg : AppPageBase
{
    string mTestIdx = "10";

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

            System.DateTime date = System.DateTime.Now.AddMonths(-1).AddDays(-15);
            PageUtility.FindByValueDropDownList(ddlYear, date.Year.ToString());
            PageUtility.FindByValueDropDownList(ddlMonth, date.Month.ToString().PadLeft(2, '0'));
        }

        private void InitControlEvent()
        {

        }

        private void SetPageData()
        {
            ChartBinding2();
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

            Chart2.DataSource = GetDTChart2();

            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 800, 430
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            // 시리즈 생성
            Series srPlan = DundasCharts.CreateSeries(Chart2, "", "Default", "계획량", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srPlan.ValueMembersY = "Plan";
            DundasAnimations.GrowingAnimation(Chart2, srPlan, 0, 0 + 1, true);

            Series srProd = DundasCharts.CreateSeries(Chart2, "", "Default", "생산량", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srProd.ValueMembersY = "Prod";
            DundasAnimations.GrowingAnimation(Chart2, srProd, 1, 1 + 1, true);

            Series srPrevYear = DundasCharts.CreateSeries(Chart2, "", "Default", "전년동기차액", null, SeriesChartType.Column, 1, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srPrevYear.ValueMembersY = "PrevYear";
            DundasAnimations.GrowingAnimation(Chart2, srPrevYear, 2, 2 + 1, true);

            Series srSum = DundasCharts.CreateSeries(Chart2, "", "Default", "계획/생산차이 누계", null, SeriesChartType.Column, 1, GetChartColor(4), GetChartColor(4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srSum.ValueMembersY = "Sum";
            DundasAnimations.GrowingAnimation(Chart2, srSum, 4, 4 + 1, true);

            Series srBuha = DundasCharts.CreateSeries(Chart2, "", "Default", "부하율", null, SeriesChartType.Line, 3, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srBuha.ValueMembersY = "Rate";
            DundasAnimations.GrowingAnimation(Chart2, srBuha, 3, 3 + 1, true);
            srBuha.MarkerStyle = GetMarkerStyle(3);

            srPlan.ShowLabelAsValue = true;
            srProd.ShowLabelAsValue = true;
            srPrevYear.ShowLabelAsValue = true;
            srSum.ShowLabelAsValue = true;

            srPlan.ValueMemberX = "GongJang";

            string sChartArea = Chart2.Series[srPlan.Name].ChartArea;
            Chart2.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";

            srBuha.YAxisType = AxisType.Secondary;

            sChartArea = Chart2.Series[srBuha.Name].ChartArea;
            Chart2.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";
        }

        // 챠트용 데이타테이블 반환

        private DataTable GetDTChart2()
        {
            DataTable dtGong = GetDTGongJang(); // X축이 되는 공장정보 테이블

            double dTmp1 = 0;
            double dTmp2 = 0;
            double dTmp3 = 0;
            double dTmp4 = 0;
            double dTmp5 = 0;


            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetChartQuery2());
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("GongJang", typeof(string));
            dataTable.Columns.Add("Plan", typeof(double));
            dataTable.Columns.Add("Prod", typeof(double));
            dataTable.Columns.Add("PrevYear", typeof(double));
            dataTable.Columns.Add("Sum", typeof(double));
            dataTable.Columns.Add("Rate", typeof(double));

            for (int i = 0; i < dtGong.Rows.Count; i++)
            {
                drNew = dataTable.NewRow();

                drNew["GongJang"] = dtGong.Rows[i]["v_Name"];

                if (dtGong.Rows[i]["v_Name"].ToString() != "전체")
                {
                    draDefault = dtTable.Select(
                                                "v_GongCD = '" + dtGong.Rows[i]["v_Code"].ToString() + "' "
                                               );
                }
                else
                {
                    draDefault = dtTable.Select();
                }

                dTmp1 = 0;
                dTmp2 = 0;
                dTmp3 = 0;
                dTmp4 = 0;
                dTmp5 = 0;

                for (int j = 0; j < draDefault.Length; j++)
                {
                    dTmp1 += Convert.ToDouble(draDefault[j]["v_PlanQty"]);
                    dTmp2 += Convert.ToDouble(draDefault[j]["v_ProdQty"]);
                    dTmp3 += Convert.ToDouble(draDefault[j]["v_Buha"]);
                    dTmp4 += Convert.ToDouble(draDefault[j]["v_PrevYearSub"]);
                    dTmp5 += Convert.ToDouble(draDefault[j]["v_PlanProdSubSum"]);
                }

                drNew["Plan"] = dTmp1;
                drNew["Prod"] = dTmp2;
                drNew["Rate"] = dTmp3;
                drNew["PrevYear"] = dTmp4;
                drNew["Sum"] = dTmp5;

                dataTable.Rows.Add(drNew);
            }

            return dataTable;
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
            sQuery += "              sum(b.BUHA)     v_Buha,                                    \n";
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
            sQuery += "       '전체' v_Name     \n";

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


    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            ChartBinding2();
        }

    #endregion
    
}
