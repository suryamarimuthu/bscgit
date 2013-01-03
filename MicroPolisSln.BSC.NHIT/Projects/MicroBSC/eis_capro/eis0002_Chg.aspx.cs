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

public partial class eis_eis0002_Chg : AppPageBase
{
    DBAgent dbAgent = null;

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

            // 이승주 추가
            System.DateTime date = System.DateTime.Now.AddMonths(-1).AddDays(-15);
            PageUtility.FindByValueDropDownList(ddlYear, date.Year.ToString());
            PageUtility.FindByValueDropDownList(ddlMonth, date.Month.ToString().PadLeft(2, '0'));
        }

        private void InitControlEvent()
        {

        }

        private void SetPageData()
        {
            BindingPieChart(ddlYear.SelectedValue + ddlMonth.SelectedValue);
        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {

        }
    #endregion

    #region 내부함수
        /// <summary>
        /// GetDTItems
        ///     : 조회조건용 제품 추출
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTItems()
        {
            string sQuery = "";

            sQuery += "SELECT ''       ITMJ_CD,     \n";
            sQuery += "       '전체'   ITMJ_NAME    \n";
            sQuery += "UNION ALL                    \n";
            sQuery += "SELECT DISTINCT              \n";
            sQuery += "       ITMJ_CD,              \n";
            sQuery += "       ITMJ_NAME             \n";
            sQuery += "  FROM D_ITEM_JAEGO          \n";

            DataTable dtRet = new DataTable();
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsItems = gDbAgentEIS.Fill(sQuery);

            if (dsItems.Tables.Count > 0)
                dtRet = dsItems.Tables[0];

            return dtRet;
        }

        private DataTable GetDTItems(string asItem)
        {
            string sQuery = "";

            sQuery += "SELECT DISTINCT              \n";
            sQuery += "       ITMJ_CD,              \n";
            sQuery += "       ITMJ_NAME             \n";
            sQuery += "  FROM D_ITEM_JAEGO          \n";
            sQuery += " WHERE 1=1                   \n";

            if (asItem != "")
                sQuery += "   AND ITMJ_CD   = '" + asItem + "'  \n";

            DataTable dtRet = new DataTable();
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsItems = gDbAgentEIS.Fill(sQuery);

            if (dsItems.Tables.Count > 0)
                dtRet = dsItems.Tables[0];

            return dtRet;
        }

        // 이승주 추가 (재고 파이 차트)
        private DataTable GetChartDataTable(string yearStr, string gongJangType)
        {
            string query = GetPieQuery(yearStr, gongJangType);
            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            return dbAgent.FillDataSet(query, "Data").Tables[0];
        }
        private string GetPieQuery(string dateStr, string gongJangType)
        {
            string query = @"
                                SELECT yyyy_mm, ITMJ_NAME, SUM(JGO_QTY) JGO_QTY FROM CA_FT_JAEGO A,
		                                D_GONGJANG B,
		                                D_ITEM_JAEGO C,
		                                D_TIME_ILJA D
                                WHERE A.GONG_IDX = B.GO_IDX
		                                AND A.ITEM_IDX = C.ITMJ_IDX
		                                AND A.TIME_IDX = D.TM_IDX
		                                AND (GONG_IDX = " + gongJangType + @" OR 0 = " + gongJangType + @")
		                                AND yyyy_mm = " + dateStr + @"
                                GROUP BY yyyy_mm, ITMJ_NAME
                                ORDER BY yyyy_mm";
            return query;
        }
        private void BindingPieChart(string yearStr)
        {
            Chart2.DataSource = GetChartDataTable(yearStr, "1").DefaultView;
            Chart3.DataSource = GetChartDataTable(yearStr, "2").DefaultView;
            Chart4.DataSource = GetChartDataTable(yearStr, "3").DefaultView;
            Chart5.DataSource = GetChartDataTable(yearStr, "0").DefaultView;

            DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 263, 190
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            DundasCharts.DundasChartBase(Chart3, ChartImageType.Flash, 263, 190
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            DundasCharts.DundasChartBase(Chart4, ChartImageType.Flash, 263, 190
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            DundasCharts.DundasChartBase(Chart5, ChartImageType.Flash, 800, 190
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

            Series series1 = DundasCharts.CreateSeries(Chart2, "Series10", "Default", "제1공장", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0),  Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series series2 = DundasCharts.CreateSeries(Chart3, "Series11", "Default", "제2공장", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1),  Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series series3 = DundasCharts.CreateSeries(Chart4, "Series12", "Default", "제3공장", null, SeriesChartType.Column, 1, GetChartColor(2), GetChartColor(2),  Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series series4 = DundasCharts.CreateSeries(Chart5, "Series13", "Default", "전체", null, SeriesChartType.Column, 1, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            series1.ShowLabelAsValue = true;
            series2.ShowLabelAsValue = true;
            series3.ShowLabelAsValue = true;
            series4.ShowLabelAsValue = true;

            series1.ValueMemberX = "ITMJ_NAME";
            series1.ValueMembersY = "JGO_QTY";
            series2.ValueMemberX = "ITMJ_NAME";
            series2.ValueMembersY = "JGO_QTY";
            series3.ValueMemberX = "ITMJ_NAME";
            series3.ValueMembersY = "JGO_QTY";
            series4.ValueMemberX = "ITMJ_NAME";
            series4.ValueMembersY = "JGO_QTY";

            DundasAnimations.DundasChartBase(Chart2, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.DundasChartBase(Chart3, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.DundasChartBase(Chart4, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.DundasChartBase(Chart5, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(Chart2, series1, 0.0, 3.0, false);
            DundasAnimations.GrowingAnimation(Chart3, series2, 3.0, 4.0, true);
            DundasAnimations.GrowingAnimation(Chart4, series3, 4.0, 6.0, true);
            DundasAnimations.GrowingAnimation(Chart5, series4, 6.0, 8.0, true);

            //Chart2.Series["Default"]["PieLabelStyle"] = "Outside";
            series1["PieLabelStyle"] = "Outside";
            series2["PieLabelStyle"] = "Outside";
            series3["PieLabelStyle"] = "Outside";
            series4["PieLabelStyle"] = "Outside";
            Chart2.Legends[0].Position.Auto = false;
            Chart2.Legends[0].Position.Height = 0;
            Chart2.Legends[0].Position.Width = 0;
            Chart3.Legends[0].Position.Auto = false;
            Chart3.Legends[0].Position.Height = 0;
            Chart3.Legends[0].Position.Width = 0;
            Chart4.Legends[0].Position.Auto = false;
            Chart4.Legends[0].Position.Height = 0;
            Chart4.Legends[0].Position.Width = 0;
            Chart5.Legends[0].Position.Auto = false;
            Chart5.Legends[0].Position.Height = 0;
            Chart5.Legends[0].Position.Width = 0;
        }

    #endregion


    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindingPieChart(ddlYear.SelectedValue + ddlMonth.SelectedValue);
        }

    #endregion
}
