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

public partial class eis_eis0006 : AppPageBase
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

            this.ddlYear.Items.Clear();
            this.ddlBond.Items.Clear();


            for (int i = 1999; i <= (dtNow.Year + 1); i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            SetDropdownListVendor();
            SetDropdownListBond();

            PageUtility.FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
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
            DataTable dtBond    = GetDTBond(false);
            DataTable dtChart   = GetDTChart();
            //Chart1.DataSource = GetDTChart();

            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 240
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            //// 시리즈 생성
            // 시리즈 생성
            Series[] srArray = new Series[dtBond.Rows.Count];

            for (int i = 0; i < dtBond.Rows.Count; i++)
            {
                srArray[i] = DundasCharts.CreateSeries(Chart1, "", "Default", dtBond.Rows[i]["v_Name"].ToString(), null, SeriesChartType.StackedColumn, 3, GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                //srArray[i].ValueMembersY = dtBond.Rows[i]["v_Code"].ToString();
                DatabaseBindingXY(srArray[i], "YYYYMM", dtBond.Rows[i]["v_Code"].ToString(), dtChart);
                DundasAnimations.GrowingAnimation(Chart1, srArray[i], i, i + 1, true);
                srArray[i].MarkerStyle = GetMarkerStyle(i);
                srArray[i].ToolTip = "#VALY{N0}";
                //srArray[i].ShowLabelAsValue = true;
                //SetZeroPoint(Chart1, int.Parse(PageUtility.GetByValueDropDownList(ddlYear)));
            }

            SetVisibleZeroPoint(Chart1, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));
            //srArray[0].ValueMemberX = "YYYYMM";

            string sChartArea = Chart1.Series[srArray[0].Name].ChartArea;
            Chart1.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";

            Font font1 = new Font("Gulim", 9, FontStyle.Regular);
            Legend legend = DundasCharts.CreateLegend(Chart1, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            string sYear        = PageUtility.GetByValueDropDownList(ddlYear);
            string[] saMonthTerm= GetMonthTerm(sYear);  // 년초부터 년말까지 년월배열
            DataTable dtBond    = GetDTBond();
            DataTable dtVendor  = GetDTVendor(PageUtility.GetByValueDropDownList(ddlVendor));

            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsDefault = gDbAgentEIS.Fill(GetGridQuery());
            DataTable dtDefault = null;
            DataRow[] draDefault = null;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            dataTable.Columns.Add("업체",   typeof(string));
            dataTable.Columns.Add("월",     typeof(string));
            dataTable.Columns.Add("계정",   typeof(string));

            dataTable.Columns.Add("이월금액",   typeof(double));
            dataTable.Columns.Add("판매액",     typeof(double));
            dataTable.Columns.Add("수금액",     typeof(double));
            dataTable.Columns.Add("수금잔액",   typeof(double));

            if (dsDefault.Tables.Count > 0)
            {
                dtDefault = dsDefault.Tables[0];

                for (int i=0; i <= saMonthTerm.GetUpperBound(0); i++)   // 년월
                {
                    for (int j=0; j < dtVendor.Rows.Count; j++)         // 업체
                    {
                        for (int k=0; k < dtBond.Rows.Count; k++)       // 계정
                        {
                            drNew = dataTable.NewRow();

                            drNew["업체"]   = dtVendor.Rows[j]["v_Name"].ToString();
                            drNew["월"]     = Convert.ToInt32(saMonthTerm[i].Substring(4, 2)).ToString() + "월";
                            drNew["계정"]   = dtBond.Rows[k]["v_Name"].ToString();

                            draDefault = dtDefault.Select(
                                                            "yyyy_mm    = '" + saMonthTerm[i] + "' "
                                                      + "AND VNDR_IDX   = " + dtVendor.Rows[j]["v_Code"].ToString() + " "
                                                      + "AND AC_IDX     = " + dtBond.Rows[k]["v_Code"].ToString() + " "
                                                         );
                            
                            if (draDefault.Length > 0)
                            {
                                drNew["이월금액"]   = Convert.ToDouble(draDefault[0]["IWOL_AMT"]);
                                drNew["판매액"]     = Convert.ToDouble(draDefault[0]["MAE_AMT"]);
                                drNew["수금액"]     = Convert.ToDouble(draDefault[0]["SUG_AMT"]);
                                drNew["수금잔액"]   = Convert.ToDouble(draDefault[0]["JAN_AMT"]);
                            }
                            else
                            {
                                drNew["이월금액"] = 0;
                                drNew["판매액"] = 0;
                                drNew["수금액"] = 0;
                                drNew["수금잔액"] = 0;

                            }

                            dataTable.Rows.Add(drNew);
                        }
                    }
                }
            }

            
            return dataTable;
        }

        // 챠트용 데이타테이블 반환
        private DataTable GetDTChart()
        {
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string[] saMonthTerm= GetMonthTerm(sYear);  // 년초부터 년말까지 년월배열

            double dTmp1 = 0;
            
            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            DataTable dtBond    = GetDTBond(false); // 전체계정 추출
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetDefaultQuery());
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            dataTable.Columns.Add("YYYYMM",     typeof(string));

            for (int i=0; i < dtBond.Rows.Count; i++)
            {
                dataTable.Columns.Add(dtBond.Rows[i]["v_Code"].ToString(), typeof(double));
            }

            for (int i=0; i < saMonthTerm.Length; i++)
            {
                drNew = dataTable.NewRow();
                drNew["YYYYMM"] = Convert.ToInt32(saMonthTerm[i].Substring(4, 2)).ToString() + "월";

                for (int j=0; j < dtBond.Rows.Count; j++)
                {
                    draDefault = dtTable.Select(
                                                "yyyy_mm = '" + saMonthTerm[i] + "' "
                                          + "AND AC_IDX = " + dtBond.Rows[j]["v_Code"].ToString() + " "
                                               );

                    dTmp1 = 0;
                    for (int k=0; k < draDefault.Length; k++)
                    {
                        dTmp1 += Convert.ToDouble(draDefault[k]["JAN_AMT"]);
                    }

                    drNew[dtBond.Rows[j]["v_Code"].ToString()] = dTmp1;
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

        private string GetGridQuery()
        {
            string sVendor = PageUtility.GetByValueDropDownList(ddlVendor);
            string sBond = PageUtility.GetByValueDropDownList(ddlBond);

            string sQuery = "";

            sQuery += "SELECT a.yyyy_mm,                \n";
            sQuery += "       a.VNDR_IDX,               \n";
            sQuery += "       a.VNDR_NAME,              \n";
            sQuery += "       a.AC_IDX,                 \n";
            sQuery += "       a.AC_ACNT_NM,             \n";
            sQuery += "       a.IWOL_AMT,       \n";
            sQuery += "       a.MAE_AMT,        \n";
            sQuery += "       a.SUG_AMT,        \n";
            sQuery += "       a.JAN_AMT         \n";
            sQuery += "  FROM (                 \n";

            sQuery += GetDefaultQuery();
            
            sQuery += "       ) a               \n";
            sQuery += " WHERE 1=1               \n";

            if (sBond != "")
                sQuery += "   AND AC_IDX = " + sBond + "              \n";

            if (sVendor != "")
                sQuery += "   AND VNDR_IDX = " + sVendor + "              \n";

            return sQuery;
        }

        private string GetDefaultQuery()
        {

            string sYear    = PageUtility.GetByValueDropDownList(ddlYear);
            
            string sQuery = "";

            sQuery += "SELECT D.yyyy_mm,                \n";
            sQuery += "       B.VNDR_IDX,               \n";
            sQuery += "       B.VNDR_NAME,              \n";
            sQuery += "       C.AC_IDX,                 \n";
            sQuery += "       C.AC_ACNT_NM,             \n";
            sQuery += "       SUM(IWOL_AMT) IWOL_AMT,   \n";
            sQuery += "       SUM(MAE_AMT) MAE_AMT,     \n";
            sQuery += "       SUM(SUG_AMT) SUG_AMT,     \n";
            sQuery += "       SUM(JAN_AMT) JAN_AMT      \n";
            sQuery += "  FROM CA_FT_SUGUM A,            \n";
            sQuery += "       (SELECT DISTINCT VNDR_IDX, VNDR_NAME FROM D_VENDER ) B,   \n";
            sQuery += "       (SELECT DISTINCT AC_IDX, AC_ACNT_NM FROM D_ACOUNT) C,     \n";
            sQuery += "       D_TIME_ILJA D             \n";
            sQuery += " WHERE A.VNDR_IDX = B.VNDR_IDX   \n";
            sQuery += "   AND A.ACNT_IDX = C.AC_IDX     \n";
            sQuery += "   AND A.DATE_IDX = D.TM_IDX     \n";
            sQuery += "   AND D.Year = " + sYear + "    \n";

            //if (sBond != "")
            //    sQuery += "   AND C.AC_IDX = " + sBond + "              \n";

            //if (sVendor != "")
            //    sQuery += "   AND B.VNDR_IDX = " + sVendor + "              \n";

            sQuery += " GROUP BY                        \n";
            sQuery += "       D.yyyy_mm,                \n";
            sQuery += "       B.VNDR_IDX,               \n";
            sQuery += "       VNDR_NAME,                \n";
            sQuery += "       AC_IDX,                   \n";
            sQuery += "       AC_ACNT_NM                \n";

            return sQuery;
        }

        /// <summary>
        /// SetDropdownListBond
        ///     : 채권 검색조건 셋팅
        /// </summary>
        private void SetDropdownListBond()
        {
            DataTable dtBond = GetDTBond(true);

            ddlBond.DataSource = dtBond;
            ddlBond.DataTextField = "v_Name";
            ddlBond.DataValueField= "v_Code";
            ddlBond.DataBind();
        }

        /// <summary>
        /// SetDropdownListVendor
        ///     : 업체 검색조건 셋팅
        /// </summary>
        private void SetDropdownListVendor()
        {
            DataTable dtVendor = GetDTVendor();

            ddlVendor.DataSource = dtVendor;
            ddlVendor.DataTextField = "v_Name";
            ddlVendor.DataValueField= "v_Code";
            ddlVendor.DataBind();
        }

        /// <summary>
        /// GetDTBond
        ///     : 채권종류 테이블리턴
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTBond(bool bAddAll)
        {
            string sQuery = "";

            if (bAddAll)
            {
                sQuery += "SELECT '' v_Code,        \n";
                sQuery += "       '전체' v_Name     \n";
                sQuery += "UNION ALL                \n";
            }
            
            sQuery += "SELECT DISTINCT              \n";
            sQuery += "       CONVERT(VARCHAR,AC_IDX)        v_Code, \n";
            sQuery += "       AC_ACNT_NM    v_Name  \n";
            sQuery += "  FROM D_ACOUNT              \n";
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsBond = gDbAgentEIS.Fill(sQuery);

            return dsBond.Tables[0];
        }

        private DataTable GetDTBond(string asCode)
        {
            string sQuery = "";

            sQuery += "SELECT DISTINCT              \n";
            sQuery += "       CONVERT(VARCHAR,AC_IDX)        v_Code, \n";
            sQuery += "       AC_ACNT_NM    v_Name  \n";
            sQuery += "  FROM D_ACOUNT              \n";
            sQuery += " WHERE 1=1                   \n";
            
            if (asCode != "")
                sQuery += "   AND AC_IDX = " + asCode + "   \n";
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsBond = gDbAgentEIS.Fill(sQuery);

            return dsBond.Tables[0];
        }

        private DataTable GetDTBond()
        {
            string sBond = PageUtility.GetByValueDropDownList(ddlBond);

            return GetDTBond(sBond);
        }

        /// <summary>
        /// GetDTVender
        ///     : 업체별 테이블 리턴
        /// </summary>
        /// <param name="asVndCode"></param>
        /// <returns></returns>
        private DataTable GetDTVendor(string asVndCode)
        {
            string sQuery = "";

            sQuery += "SELECT DISTINCT          \n";
            sQuery += "       CONVERT(VARCHAR, VNDR_IDX)  v_Code, \n";
            sQuery += "       VNDR_NAME v_Name  \n";
            sQuery += "  FROM D_VENDER      \n";
            sQuery += " WHERE 1=1           \n";

            if (asVndCode != "")
                sQuery += "   AND VNDR_IDX = '" + asVndCode + "' \n";
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsVendor = gDbAgentEIS.Fill(sQuery);;
            return dsVendor.Tables[0];
        }

        /// <summary>
        /// GetDTVendor
        ///     : 모든 업체 리턴
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTVendor()
        {
            return GetDTVendor("");
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
            e.Layout.Bands[0].Columns[1].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP2);

            e.Layout.Bands[0].Columns[0].MergeCells = true;
            e.Layout.Bands[0].Columns[0].CellStyle.VerticalAlign = VerticalAlign.Top;
            e.Layout.Bands[0].Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].Columns[1].MergeCells = true;

            for (int i = 3; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.00";

            }
        }
        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {

        }


    protected void SetZeroPoint(Chart chart, int iYear)
    {
        DateTime date = System.DateTime.Now;
        for (int i = 0; i < chart.Series.Count; i++)
        {
            for (int j = date.Month; j < chart.Series[i].Points.Count; j++)
            {
                //series2.Points[i].ShowLabelAsValue = true;

                if (chart.Series[i].Points[j].GetValueY(0) == 0 && date.Year == iYear)
                {
                    chart.Series[i].Points[j].Color = Color.Transparent;
                    chart.Series[i].Points[j].BorderColor = Color.Transparent;
                    chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
                    //chart.Series[i].Points[j].BorderWidth = 1;
                }
            }
        }
    }
    #endregion



    
}
