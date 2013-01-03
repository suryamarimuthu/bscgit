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

public partial class eis_SEM_FIna_R012 : EISPageBase
{
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
            this.ddlLocation.Items.Clear();
            this.ddlType.Items.Clear();

            for (int i = dtNow.Year - 2; i <= dtNow.Year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                sMonth = (i < 10 ? "0" + i.ToString() : i.ToString());
                this.ddlMonth.Items.Add(new ListItem(sMonth, sMonth));
            }

            this.SetAreaDropDownList(ddlLocation);

            ddlType.Items.Add(new ListItem("당월", "당월"));
            ddlType.Items.Add(new ListItem("누계", "누계"));

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.Month-1 < 10 ? "0" + (dtNow.Month-1).ToString() : (dtNow.Month-1).ToString()));
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
        private void GridBinding()
        {
            UltraWebGrid1.DataSource = GetDTGrid();
            UltraWebGrid1.DataBind();
        }

        private void ChartBinding()
        {
            Chart1.DataSource = GetDTChart();
            
            #region 챠트 초기화
                DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                    , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                    , -1
                    , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            // 시리즈 생성
            Series ddcSer_Col_1 = DundasCharts.CreateSeries(Chart1, "ddcSer_Col_1", "Default", "매출계획", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Col_2 = DundasCharts.CreateSeries(Chart1, "ddcSer_Col_2", "Default", "매출실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Line_1 = DundasCharts.CreateSeries(Chart1, "ddcSer_Line_1", "Default", "매출총이익률", null, SeriesChartType.Line, 3, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Line_2 = DundasCharts.CreateSeries(Chart1, "ddcSer_Line_2", "Default", "영업이익률", null, SeriesChartType.Line, 3, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Line_3 = DundasCharts.CreateSeries(Chart1, "ddcSer_Line_3", "Default", "OI/GI Ratio", null, SeriesChartType.Line, 3, GetChartColor(4), GetChartColor(4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            ddcSer_Col_1.ValueMembersY = "v_Plan";
            ddcSer_Col_2.ValueMembersY = "v_SALE";
            ddcSer_Line_1.ValueMembersY = "V_TotSaleRate";
            ddcSer_Line_2.ValueMembersY = "v_BizProfitRate";
            ddcSer_Line_3.ValueMembersY = "v_OGRatio";
            ddcSer_Col_1.ValueMemberX = "V_MONTH";

            string sChartArea = Chart1.Series[ddcSer_Line_1.Name].ChartArea;
            
            ddcSer_Line_1.YAxisType = AxisType.Secondary;
            ddcSer_Line_2.YAxisType = AxisType.Secondary;
            ddcSer_Line_3.YAxisType = AxisType.Secondary;

            Chart1.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

            DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Line_1, 0.0, 1.0, true);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Line_2, 0.5, 1.0, true);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Line_3, 1.0, 1.0, true);

            ddcSer_Line_1.MarkerStyle = GetMarkerStyle(2);
            ddcSer_Line_1.MarkerColor = GetChartColor(2);
            ddcSer_Line_1.MarkerBorderColor = GetChartColor(2);

            ddcSer_Line_2.MarkerStyle = GetMarkerStyle(3);
            ddcSer_Line_2.MarkerColor = GetChartColor(3);
            ddcSer_Line_2.MarkerBorderColor = GetChartColor(3);

            ddcSer_Line_3.MarkerStyle = GetMarkerStyle(4);
            ddcSer_Line_3.MarkerColor = GetChartColor(4);
            ddcSer_Line_3.MarkerBorderColor = GetChartColor(4);
        }

        // 챠트용 데이타테이블 반환

        private DataTable GetDTChart()
        {
            DataTable dataTable = new DataTable();
            DataSet dsTable = gDbAgent.Fill(GetDefaultQuery());

            if (dsTable.Tables.Count > 0)
                dataTable = dsTable.Tables[0];

            return dataTable;
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            DataTable dataTable = new DataTable();

            DataSet dsDefault = gDbAgent.Fill(GetDefaultQuery());
            DataTable dtDefault = null;
            DataRow drTable = null;


            if (dsDefault.Tables.Count > 0)
            {
                dtDefault = dsDefault.Tables[0];

                dataTable.Columns.Add("월", typeof(string));
                dataTable.Columns.Add("매출액", typeof(double));
                dataTable.Columns.Add("매출총이익", typeof(double));
                dataTable.Columns.Add("영업이익", typeof(double));
                dataTable.Columns.Add("매출총이익률", typeof(double));
                dataTable.Columns.Add("영업이익률", typeof(double));
                dataTable.Columns.Add("OI/GI Ratio", typeof(double));

                for (int i = 0; i < dtDefault.Rows.Count; i++)
                {
                    drTable = dataTable.NewRow();

                    drTable["월"] = dtDefault.Rows[i]["v_Month"].ToString();
                    drTable["매출액"] = Convert.ToDouble(dtDefault.Rows[i]["v_Sale"]);
                    drTable["매출총이익"] = Convert.ToDouble(dtDefault.Rows[i]["v_TotSaleProfit"]);
                    drTable["영업이익"] = Convert.ToDouble(dtDefault.Rows[i]["v_BizProfit"]);
                    drTable["매출총이익률"] = Convert.ToDouble(dtDefault.Rows[i]["v_TotSaleRate"]);
                    drTable["영업이익률"] = Convert.ToDouble(dtDefault.Rows[i]["v_BizProfitRate"]);
                    drTable["OI/GI Ratio"] = Convert.ToDouble(dtDefault.Rows[i]["v_OGRatio"]);

                    dataTable.Rows.Add(drTable);
                }
            }

            return dataTable;
        }

        private string GetDefaultQuery()
        {
            string sLocation = GetByValueDropDownList(ddlLocation);

            string sYear = GetByValueDropDownList(ddlYear);
            string sType = GetByValueDropDownList(ddlType);

            string[] saMonthTerm = GetMonthTerm(sYear);

            string sQuery = "";

            sQuery += "SELECT ta.v_Month, ta.v_Plan, ta.v_Sale, ta.v_TotSaleProfit, ta.v_BizProfit, ta.v_TotSaleRate, ta.v_BizProfitRate, ta.v_OGRatio FROM ( ";
            sQuery += "SELECT TO_CHAR(TO_NUMBER(SUBSTR(b.V_YEARMON, 5, 2))) || '월' v_Month, -- 년월,                          \n";
            sQuery += "       NVL(round(SUM(a.PLAN)/1000,0), 0) v_Plan,                                     --매출계획                          \n";
            sQuery += "       NVL(round(SUM(a.AMT1)/1000,0), 0) v_Sale, -- 매출액                                                               \n";
            sQuery += "       NVL(round(SUM(a.AMT2)/1000,0), 0) v_TotSaleProfit, -- 매출총이익                                                  \n";
            sQuery += "       NVL(round(SUM(a.AMT3)/1000,0), 0) v_BizProfit,     --  영업이익                                                   \n";
            sQuery += "       NVL(DECODE(SUM(a.AMT1), 0, 0, ROUND(SUM(a.AMT2) / SUM(a.AMT1) * 100,2)), 0) v_TotSaleRate,         -- 매출총이익률               \n";
            sQuery += "       NVL(DECODE(SUM(a.AMT1), 0, 0, ROUND(SUM(a.AMT3) / SUM(a.AMT1) * 100,2)), 0) v_BizProfitRate,       -- 영업이익률                 \n";
            sQuery += "       NVL(DECODE(SUM(a.AMT2), 0, 0, ROUND(SUM(a.AMT3) / SUM(a.AMT2) * 100,2)), 0) v_OGRatio,             -- OI/GI Ratio                \n";
            sQuery += "       V_YEARMON                                     v_YM                                                 -- YM                         \n";
            sQuery += " FROM (                                                                                          \n";
            sQuery += "      SELECT PL.PL_DATE_T DADT,                                                                  \n";
            sQuery += "             PL_CODE.SEM_ACCOUNT1_CODE A_CODE,                                                   \n";

            if (sType == "당월")
            {
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4003000000', PL.PL_BUDGET_AMOUNT, 0)) PLAN,  \n";
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4003000000', PL.PL_ACTUAL_AMOUNT, 0)) AMT1,  \n";
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4007000000', PL.PL_ACTUAL_AMOUNT, 0)) AMT2,  \n";
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4011000000', PL.PL_ACTUAL_AMOUNT, 0)) AMT3   \n";
            }
            else
            {
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4003000000', PL.PL_SUM_BUDGET_AMOUNT, 0)) PLAN,  \n";
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4003000000', PL.PL_SUM_ACTUAL_AMOUNT, 0)) AMT1,  \n";
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4007000000', PL.PL_SUM_ACTUAL_AMOUNT, 0)) AMT2,  \n";
                sQuery += "             SUM(DECODE(PL_CODE.SEM_ACCOUNT1_CODE, '4011000000', PL.PL_SUM_ACTUAL_AMOUNT, 0)) AMT3   \n";
            }

            sQuery += "        FROM                                                                                     \n";
            sQuery += "             SEM_PROFIT_LOSS PL, ( SELECT DISTINCT                                        \n";
            sQuery += "                                                  SEM_ACCOUNT1_CODE SEM_ACCOUNT1_CODE,           \n";
            sQuery += "                                                  SEM_ACCOUNT2_CODE SEM_ACCOUNT2_CODE,           \n";
            sQuery += "                                                  SEM_ACCOUNT3_CODE SEM_ACCOUNT3_CODE,           \n";
            sQuery += "                                                  SEM_ACCOUNT1_DESC SEM_ACCOUNT1_DESC            \n";
            sQuery += "                                             FROM SEM_FINANCIAL_CODE_MASTER                      \n";
            sQuery += "                                            WHERE SEM_FINANCIAL_CODE = 'PL' ) PL_CODE            \n";
            sQuery += "       WHERE PL.PL_DATE_T LIKE '" + sYear + "%'                                                   \n";

            if (sLocation != "--")
                sQuery += "         AND PL.PL_OFFICE_T = '" + sLocation + "'    \n";

            sQuery += "         AND PL.PL_ACCOUNT3_CODE_T = PL_CODE.SEM_ACCOUNT3_CODE                                   \n";
            sQuery += "         AND PL_CODE.SEM_ACCOUNT1_CODE IN ('4003000000','4007000000','4011000000')               \n";
            sQuery += "       GROUP BY                                                                                  \n";
            sQuery += "             PL.PL_DATE_T,                                                                       \n";
            sQuery += "             PL_CODE.SEM_ACCOUNT1_CODE,                                                          \n";
            sQuery += "             PL_CODE.SEM_ACCOUNT1_DESC                                                           \n";
            sQuery += "      ) a,                                                                                          \n";
            sQuery += "      (  \n";

            for (int i = 0; i < saMonthTerm.Length; i++)
            {
                sQuery += "       SELECT '" + saMonthTerm[i] + "' v_YearMon FROM DUAL UNION ALL  \n";
            }
            sQuery += "       SELECT '000000' v_YearMon FROM DUAL   \n";
            sQuery += "      ) b    \n";
            sQuery += " WHERE A.DADT(+) = B.V_YEARMON   \n";
            sQuery += "   AND b.v_YearMon   <> '000000' \n";
            sQuery += " GROUP BY                                                                                        \n";

            sQuery += "       V_YEARMON                                                                                 \n";
            sQuery += " ) ta ORDER BY v_YM                                                                              \n";

            return sQuery;
        }

        private string[] GetMonthTerm(string asYear)
        {
            string[] saMonthTerm;

            string sYYYYMMs = asYear + "01";
            string sYYYYMMe = asYear + "12";

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

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
            GridBinding();
            ChartBinding();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;

            for (int i = 1; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.##";
                e.Layout.Bands[0].Columns[i].Width = (i < 1) ? 50 : 112;
            }

        }
        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {

        }
    #endregion
}
