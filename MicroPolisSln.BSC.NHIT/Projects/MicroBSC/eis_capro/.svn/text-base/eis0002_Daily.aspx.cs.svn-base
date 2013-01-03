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

public partial class eis_eis0002_Daily : AppPageBase
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
            this.ddlGong.Items.Clear();
            this.ddlItem.Items.Clear();

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

            this.ddlItem.DataSource = GetDTItems();
            this.ddlItem.DataTextField = "ITMJ_NAME";
            this.ddlItem.DataValueField = "ITMJ_CD";
            this.ddlItem.DataBind();

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
            string sItem = PageUtility.GetByValueDropDownList(ddlItem);
            DataTable dtItems = GetDTItems(sItem);    // 선택된 아이템

            Chart1.DataSource = GetDTChart();

            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 400
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            // 시리즈 생성
            Series[] srArray = new Series[dtItems.Rows.Count];

            for (int i = 0; i < dtItems.Rows.Count; i++)
            {
                srArray[i] = DundasCharts.CreateSeries(Chart1, "", "Default", dtItems.Rows[i]["ITMJ_NAME"].ToString(), null, SeriesChartType.Line, 3, GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srArray[i].ValueMembersY = dtItems.Rows[i]["ITMJ_CD"] + "_QTY";
                DundasAnimations.GrowingAnimation(Chart1, srArray[i], i, i + 1, true);
                srArray[i].MarkerStyle = GetMarkerStyle(i);
                srArray[i].ToolTip = "#VALY{N0}";
            }

            srArray[0].ValueMemberX = "YMD";

            string sChartArea = Chart1.Series[srArray[0].Name].ChartArea;
            Chart1.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
        }

        // 챠트용 데이타테이블 반환

        private DataTable GetDTChart()
        {
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            string sItem = PageUtility.GetByValueDropDownList(ddlItem);

            string[] saDayTerm = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true);    // 1달동안의 날짜
            DataTable dtItems = GetDTItems(sItem);    // 선택된 아이템

            double dTotal = 0;
            double dTmp = 0;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetDefaultQuery());
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("YMD", typeof(string));

            for (int i = 0; i < dtItems.Rows.Count; i++)
            {
                dataTable.Columns.Add(dtItems.Rows[i]["ITMJ_CD"] + "_QTY", typeof(double));
            }

            for (int i = 0; i < saDayTerm.Length; i++)
            {
                drNew = dataTable.NewRow();
                drNew["YMD"] = saDayTerm[i].Substring(6, 2);

                for (int j = 0; j < dtItems.Rows.Count; j++)
                {
                    draDefault = dtTable.Select(
                                                "v_YMD = '" + saDayTerm[i] + "' "
                                          + "AND ITMJ_CD = '" + dtItems.Rows[j]["ITMJ_CD"] + "' "
                                               );

                    dTmp = 0;

                    for (int k = 0; k < draDefault.Length; k++)
                    {
                        dTmp += Convert.ToDouble(draDefault[k]["v_JgoQty"]);
                    }

                    drNew[dtItems.Rows[j]["ITMJ_CD"] + "_QTY"] = dTmp;
                }

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

        private string GetDefaultQuery()
        {

            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            string sGong = PageUtility.GetByValueDropDownList(ddlGong);
            string sItem = PageUtility.GetByValueDropDownList(ddlItem);

            string sQuery = "";

            sQuery += "SELECT a.v_Year + a.v_Month + a.v_Day v_YMD,                                         \n";
            sQuery += "       a.v_Day,                                                                      \n";
            sQuery += "       a.ITMJ_CD,                                                                                \n";
            sQuery += "       a.ITMJ_NAME,                                                                              \n";
            sQuery += "       a.v_JgoQty                                                                                \n";
            sQuery += "  FROM (                                                                                         \n";
            sQuery += "       SELECT CONVERT(VARCHAR, a.Year) v_Year,                                                   \n";
            sQuery += "              CASE WHEN a.Month < 10 THEN '0' + CONVERT(VARCHAR, a.Month)                        \n";
            sQuery += "                                     ELSE CONVERT(VARCHAR, a.Month)                              \n";
            sQuery += "              END v_Month,                                                                       \n";
            sQuery += "              CASE WHEN a.DayNumberOfMonth < 10 THEN '0' + CONVERT(VARCHAR, a.DayNumberOfMonth)  \n";
            sQuery += "                                                ELSE CONVERT(VARCHAR, a.DayNumberOfMonth)        \n";
            sQuery += "              END v_Day,                                                                         \n";
            sQuery += "              b.ITMJ_CD,                                                                         \n";
            sQuery += "              b.ITMJ_NAME,                                                                       \n";
            sQuery += "              SUM(c.JGO_QTY) v_JgoQty                                                            \n";
            sQuery += "         FROM D_TIME_ILJA a,                                                                     \n";
            sQuery += "              (                                                                                  \n";
            sQuery += "               SELECT distinct                                                                   \n";
            sQuery += "                      ITMJ_CD,                                                                   \n";
            sQuery += "                      ITMJ_NAME                                                                  \n";
            sQuery += "                 FROM D_ITEM_JAEGO                                                               \n";
            sQuery += "              )  b,                                                                              \n";
            sQuery += "              CA_FT_JAEGO  c                                                                     \n";
            sQuery += "        WHERE c.TIME_IDX = a.TM_IDX                                                              \n";
            sQuery += "          AND c.ITEM_IDX = b.ITMJ_CD                                                             \n";
            sQuery += "          AND a.Year = " + sYear + "  -- 년                                                      \n";
            sQuery += "          AND a.Month= " + Convert.ToInt32(sMonth) + "     -- 월                                 \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일                                       \n";

            if (sItem != "")
                sQuery += "          AND b.ITMJ_CD = " + sItem + " -- item                                                             \n";

            if (sGong != "")
                sQuery += "          AND c.GONG_IDX = " + sGong + " -- 공장                                                              \n";

            sQuery += "        GROUP by                                                                                 \n";
            sQuery += "              a.Year,                                                                            \n";
            sQuery += "              a.Month,                                                                           \n";
            sQuery += "              a.DayNumberOfMonth,                                                                \n";
            sQuery += "              b.ITMJ_CD,                                                                         \n";
            sQuery += "              b.ITMJ_NAME                                                                        \n";
            sQuery += "       ) a                                                                                       \n";

            return sQuery;
        }

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
        }

    #endregion
}
