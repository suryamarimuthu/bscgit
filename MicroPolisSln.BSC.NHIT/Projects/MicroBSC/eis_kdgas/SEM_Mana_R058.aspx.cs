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

public partial class eis_SEM_Mana_R058 : EISPageBase
{
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
            this.ddlMonth.Items.Clear();
            this.ddlLocation.Items.Clear();

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

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.Month < 10 ? "0" + dtNow.Month.ToString() : dtNow.Month.ToString()));
            FindByTextDropDownList(ddlLocation, "--");

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
            string sYYYYMMs, sYYYYMMe;
            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재

            Series[] oasrType;      // 시리즈 저장배열

            // 구분 추출 쿼리
            string sQueryGubun = "";

            sQueryGubun += "SELECT stock_work_code_t,           \n";
            sQueryGubun += "       stock_work_name              \n";
            //sQueryGubun += "       ,stock_office_t              \n";
            sQueryGubun += "  FROM SEM_STOCK_MONTHLY            \n";
            sQueryGubun += " WHERE stock_date_t BETWEEN '" + sYYYYMMs + "'\n";
            sQueryGubun += "                        AND '" + sYYYYMMe + "'\n";
            sQueryGubun += " GROUP BY                           \n";
            sQueryGubun += "       stock_work_code_t,           \n";
            sQueryGubun += "       stock_work_name              \n";
            //sQueryGubun += "       ,stock_office_t              \n";

            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);

            DataRow drGubun = null;
            DataSet dsGubun = dbAgent.FillDataSet(sQueryGubun, "Data");

            Chart1.DataSource = GetDTChart();

            #region 챠트 초기화
                DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                    , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                    , -1
                    , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            // 시리즈 동적 생성
            oasrType = new Series[dsGubun.Tables[0].Rows.Count];

            if (oasrType.Length > 0)
            {
                for (int i = 0; i < oasrType.Length; i++)
                {
                    drGubun = dsGubun.Tables[0].Rows[i];
                    oasrType[i] = DundasCharts.CreateSeries(Chart1, "Series" + i.ToString(), "Default",
                                                            drGubun["stock_work_name"].ToString(), null, SeriesChartType.Line, 3,
                                                            GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                }

                oasrType[0].ValueMemberX = "YEARMON";
                DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);

                for (int i = 0; i < oasrType.Length; i++)
                {
                    drGubun = dsGubun.Tables[0].Rows[i];
                    oasrType[i].ValueMembersY = "WORK_CODE_T_" + drGubun["stock_work_code_t"].ToString();

                    if (i == 0)
                        DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
                    else
                        DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);

                    oasrType[i].MarkerStyle = GetMarkerStyle(i);
                    oasrType[i].MarkerColor = GetChartColor(i);
                    oasrType[i].MarkerBorderColor = GetChartColor(i);
                }

            }
        }

        // 챠트용 데이타테이블 반환
        private DataTable GetDTChart()
        {
            DataTable dataTable = new DataTable();

            string sYYYYMMs, sYYYYMMe;

            string sLocation = GetByValueDropDownList(ddlLocation);

            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재

            // 구분 추출 쿼리
            string sQueryGubun = "";

            sQueryGubun += "SELECT stock_work_code_t,           \n";
            sQueryGubun += "       stock_work_name              \n";
            //sQueryGubun += "       ,stock_office_t              \n";
            sQueryGubun += "  FROM SEM_STOCK_MONTHLY            \n";
            sQueryGubun += " WHERE stock_date_t BETWEEN '" + sYYYYMMs + "'\n";
            sQueryGubun += "                        AND '" + sYYYYMMe + "'\n";
            sQueryGubun += " GROUP BY                           \n";
            sQueryGubun += "       stock_work_code_t,           \n";
            sQueryGubun += "       stock_work_name              \n";
            //sQueryGubun += "       ,stock_office_t              \n";

            string sQuery = GetDefaultQuery();   // 기본 쿼리
            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);

            DataRow drTable = null;
            DataRow[] dr = null;
            DataRow drGubun = null;
            DataSet ds = dbAgent.FillDataSet(sQuery, "Data");
            DataSet dsGubun = dbAgent.FillDataSet(sQueryGubun, "Data");

            // 기본테이블에 데이타가 없으면 나간다.
            if (ds.Tables[0].Rows.Count <= 0)
            {
                AlertMessage("데이타가 없습니다!");
                return dataTable;
            }

            dataTable.Columns.Add("YEARMON",   typeof(string));

            for (int i=0; i<dsGubun.Tables[0].Rows.Count; i++)
            {
                drGubun = dsGubun.Tables[0].Rows[i];
                dataTable.Columns.Add("WORK_CODE_T_" + drGubun["stock_work_code_t"],    typeof(int));
            }

            for (int i=0; i<saMonthTerm.Length; i++)
            {
                drTable = dataTable.NewRow();

                drTable["YEARMON"] = Convert.ToString(Convert.ToInt32(saMonthTerm[i].Substring(4, 2))) + "월";

                for (int j = 0; j < dsGubun.Tables[0].Rows.Count; j++)
                {
                    drGubun = dsGubun.Tables[0].Rows[j];
                    dr = ds.Tables[0].Select(
                                            "stock_work_code_t = '" + drGubun["stock_work_code_t"] + "' "
                                      + "AND stock_date_t = '" + saMonthTerm[i] + "' "
                                            );
                    if (dr.Length > 0)
                        drTable["WORK_CODE_T_" + drGubun["stock_work_code_t"]] = Convert.ToInt32(dr[0]["stock_qnt"]);
                }
                
                dataTable.Rows.Add(drTable);
            }

            return dataTable;
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            DataTable dataTable = new DataTable();

            string sYYYYMMs, sYYYYMMe;

            string sLocation = GetByValueDropDownList(ddlLocation);

            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재

            // 구분 추출 쿼리
            string sQueryGubun = "";

            sQueryGubun += "SELECT stock_work_code_t,           \n";
            sQueryGubun += "       stock_work_name              \n";
            //sQueryGubun += "       ,stock_office_t              \n";
            sQueryGubun += "  FROM SEM_STOCK_MONTHLY            \n";
            sQueryGubun += " WHERE stock_date_t BETWEEN '" + sYYYYMMs + "'\n";
            sQueryGubun += "                        AND '" + sYYYYMMe + "'\n";
            sQueryGubun += " GROUP BY                           \n";
            sQueryGubun += "       stock_work_code_t,           \n";
            sQueryGubun += "       stock_work_name              \n";
            //sQueryGubun += "       ,stock_office_t              \n";

            string sQuery = GetDefaultQuery();   // 그리드 셋팅용 쿼리
            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);

            DataRow drTable = null;
            DataRow[] dr = null;
            DataRow drGubun = null;
            DataSet ds = dbAgent.FillDataSet(sQuery, "Data");
            DataSet dsGubun = dbAgent.FillDataSet(sQueryGubun, "Data");

            // 기본테이블에 데이타가 없으면 나간다.
            if (ds.Tables[0].Rows.Count <= 0)
            {
                AlertMessage("데이타가 없습니다!");
                return dataTable;
            }

            dataTable.Columns.Add("구분",   typeof(string));
            
            for (int i=0; i<saMonthTerm.Length; i++)
            {
                dataTable.Columns.Add(saMonthTerm[i].Substring(4, 2) + "월",    typeof(int));
            }

            for (int i=0; i < dsGubun.Tables[0].Rows.Count; i++)
            {
                drGubun = dsGubun.Tables[0].Rows[i];

                drTable = dataTable.NewRow();
                drTable["구분"] = drGubun["stock_work_name"].ToString();

                for (int j=0; j < saMonthTerm.Length; j++)
                {
                    dr = ds.Tables[0].Select(
                                            "stock_work_code_t='" + drGubun["stock_work_code_t"].ToString() + "' "
                                      + "AND (stock_date_t = '" + saMonthTerm[j] + "') "
                                            );

                    if (dr.Length > 0)
                        drTable[saMonthTerm[j].Substring(4, 2) + "월"] = Convert.ToInt32(dr[0]["stock_qnt"]);
                }

                dataTable.Rows.Add(drTable);

            }

            return dataTable;
        }

        private string GetDefaultQuery()
        {
            int i;

            string sLocation = GetByValueDropDownList(ddlLocation);
            
            string sYYYYMMs, sYYYYMMe;
            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재

            string sQuery = "";

            sQuery += "SELECT b.stock_work_code_t       ,                           \n";
            sQuery += "       b.stock_work_name         ,                           \n";
            //sQuery += "       b.stock_office_t          ,                           \n";
            sQuery += "       b.v_YM stock_date_t       ,                           \n";
            sQuery += "       SUM(NVL(a.stock_qnt, 0)) stock_qnt                         \n";
            sQuery += "  FROM (                                                     \n";
            sQuery += "        SELECT stock_work_code_t,                            \n";
            sQuery += "               stock_work_name,                              \n";
            sQuery += "               stock_date_t,                                 \n";
            sQuery += "               stock_office_t,                               \n";
            sQuery += "               SUM(stock_qnt) stock_qnt                      \n";
            sQuery += "          FROM SEM_STOCK_MONTHLY                             \n";
            sQuery += "         WHERE stock_date_t BETWEEN '" + sYYYYMMs + "'       \n";
            sQuery += "                                AND '" + sYYYYMMe + "'       \n";
            sQuery += "         GROUP BY                                            \n";
            sQuery += "               stock_work_code_t,                            \n";
            sQuery += "               stock_work_name,                              \n";
            sQuery += "               stock_date_t,                                 \n";
            sQuery += "               stock_office_t                                \n";
            sQuery += "       ) a,                                                  \n";
            sQuery += "       (                                                     \n";
            sQuery += "        SELECT                                               \n";
            sQuery += "               a.stock_work_code_t,                          \n";
            sQuery += "               a.stock_work_name,                            \n";
            sQuery += "               a.stock_office_t,                             \n";
            sQuery += "               b.v_YM                                        \n";
            sQuery += "          FROM (                                             \n";
            sQuery += "                SELECT stock_work_code_t,                    \n";
            sQuery += "                       stock_work_name,                      \n";
            sQuery += "                       stock_office_t                        \n";
            sQuery += "                  FROM SEM_STOCK_MONTHLY                     \n";
            sQuery += "                 WHERE stock_date_t BETWEEN '" + sYYYYMMs + "'         \n";
            sQuery += "                                        AND '" + sYYYYMMe + "'         \n";
            sQuery += "                 GROUP BY                                    \n";
            sQuery += "                       stock_work_code_t,                    \n";
            sQuery += "                       stock_work_name,                      \n";
            sQuery += "                       stock_office_t                        \n";
            sQuery += "               ) a,                                          \n";
            sQuery += "               (                                             \n";

            for (i=0; i<saMonthTerm.Length; i++)
            {
                sQuery += "                SELECT '" + saMonthTerm[i] + "' v_YM FROM dual UNION ALL     \n";
            }

            sQuery += "                SELECT '000000' v_YM FROM dual               \n";
            sQuery += "               ) b                                           \n";
            sQuery += "       ) b                                                   \n";
            sQuery += " WHERE b.stock_work_code_t  = a.stock_work_code_t(+)         \n";
            sQuery += "   AND b.stock_work_name    = a.stock_work_name(+)           \n";
            sQuery += "   AND b.stock_office_t     = a.stock_office_t(+)            \n";
            sQuery += "   AND b.v_YM               = a.stock_date_t(+)              \n";
            sQuery += "   AND b.v_YM               <> '000000'                      \n";

            if (sLocation != "--")
                sQuery += "   AND b.stock_office_t = '" + sLocation +  "'";

            sQuery += " GROUP BY    \n";
            sQuery += "       b.stock_work_code_t       ,                           \n";
            sQuery += "       b.stock_work_name         ,                           \n";
            //sQuery += "       b.stock_office_t          ,                           \n";
            sQuery += "       b.v_YM                                                \n";

            return sQuery;
        }

        /// <summary>
        /// GetMonthTerm
        ///     : 검색기간의 년월을 문자배열 추출
        /// </summary>
        /// <param name="abCurr"></param>
        /// <returns></returns>
        private string[] GetMonthTerm(out string asYYYYMMs, out string asYYYYMMe)
        {
            string[] saMonthTerm;

            string sYYYYMMs = GetByValueDropDownList(ddlYear) + "01";
            string sYYYYMMe = GetByValueDropDownList(ddlYear) + GetByValueDropDownList(ddlMonth);

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");
            asYYYYMMs = sYYYYMMs;
            asYYYYMMe = sYYYYMMe;

            return saMonthTerm;
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
            string sYYYYMMs, sYYYYMMe;
            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재

            try
            {
                for (int i = 0; i < saMonthTerm.Length; i++)
                {
                    e.Layout.Bands[0].Columns.FromKey(saMonthTerm[i].Substring(4, 2) + "월").CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns.FromKey(saMonthTerm[i].Substring(4, 2) + "월").Format = "#,##0";
                }
            }
            catch {}
            
        }
        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            
        }
    #endregion
}
