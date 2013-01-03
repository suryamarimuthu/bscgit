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

public partial class eis_eis0004_Daily : AppPageBase
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
            this.ddlGong.Items.Clear();

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

            System.DateTime date = System.DateTime.Now.AddMonths(-1).AddDays(-15);
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
        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {

        }
    #endregion

    #region 내부함수
        private void GridBinding()
        {
            UltraWebGrid1.DataSource = GetDTGrid();
            UltraWebGrid1.DataBind();
        }

        private void ChartBinding()
        {
            string sGongName = PageUtility.GetByTextDropDownList(ddlGong);

            Chart1.DataSource = GetDTChart();

            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 250
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            //series1.ToolTip = "#VALY{N}";
            //series2.ToolTip = "#VALY{N}";
            // 시리즈 생성
            Series srProd = DundasCharts.CreateSeries(Chart1, "", "Default", "생산량", null, SeriesChartType.Line, 3, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srProd.ValueMembersY = "ProdQty";
            DundasAnimations.GrowingAnimation(Chart1, srProd, 0, 0 + 1, true);
            srProd.MarkerStyle = GetMarkerStyle(0);
            srProd.ToolTip = "#VALY{N0}";

            Series srRate = DundasCharts.CreateSeries(Chart1, "", "Default", "계획대비일간실적", null, SeriesChartType.Line, 3, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srRate.ValueMembersY = "Rate";
            DundasAnimations.GrowingAnimation(Chart1, srRate, 1, 1 + 1, true);
            srRate.MarkerStyle = GetMarkerStyle(1);
            srRate.ToolTip = "#VALY{P0}";

            Series srBuha = DundasCharts.CreateSeries(Chart1, "", "Default", "부하율", null, SeriesChartType.Line, 3, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            srBuha.ValueMembersY = "Buha";
            DundasAnimations.GrowingAnimation(Chart1, srBuha, 2, 2 + 1, true);
            srBuha.MarkerStyle = GetMarkerStyle(2);
            srBuha.ToolTip = "#VALY{P0}";

            srProd.ValueMemberX = "YMD";

            string sChartArea = Chart1.Series[srProd.Name].ChartArea;
            Chart1.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";

            sChartArea = Chart1.Series[srRate.Name].ChartArea;

            srRate.YAxisType = AxisType.Secondary;
            srBuha.YAxisType = AxisType.Secondary;

            Chart1.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);

            string[] saDayTerm = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true);    // 1달동안의 날짜

            double dTmp = 0;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetDefaultQuery());
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("구분",   typeof(string));

            for (int i = 0; i < saDayTerm.Length; i++)
            {
                dataTable.Columns.Add(saDayTerm[i].Substring(6, 2), typeof(double));
            }

            // 생산량 (ProdQty)
            drNew = dataTable.NewRow();
            drNew["구분"] = "생산량";

            for (int i = 0; i < saDayTerm.Length; i++)
            {
                draDefault = dtTable.Select(
                                            "v_YMD = '" + saDayTerm[i] + "' "
                                           );

                dTmp = 0;

                for (int k = 0; k < draDefault.Length; k++)
                {
                    dTmp += Convert.ToDouble(draDefault[k]["v_ProdQty"]);
                }

                drNew[saDayTerm[i].Substring(6, 2)] = Math.Round(dTmp, 0);
            }

            dataTable.Rows.Add(drNew);

            // 계획대비일간실적 (Rate)
            drNew = dataTable.NewRow();
            drNew["구분"] = "계획대비일간실적";

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
            }

            dataTable.Rows.Add(drNew);

            // 부하율 (Buha)
            drNew = dataTable.NewRow();
            drNew["구분"] = "부하율";

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
            }

            dataTable.Rows.Add(drNew);

            return dataTable;
        }

        // 챠트용 데이타테이블 반환
        private DataTable GetDTChart()
        {
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);

            string[] saDayTerm = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true);    // 1달동안의 날짜

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
            sQuery += "              sum(b.BUHA)     v_Buha,                                                            \n";
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
            ChartBinding();
            GridBinding();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP1);
            
            //e.Layout.Bands[0].Columns[0].MergeCells = true;
            //e.Layout.Bands[0].Columns[0].CellStyle.VerticalAlign = VerticalAlign.Top;
            //e.Layout.Bands[0].Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            //e.Layout.Bands[0].Columns[1].MergeCells = true;

            for (int i = 1; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";

            }
        }
        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
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
