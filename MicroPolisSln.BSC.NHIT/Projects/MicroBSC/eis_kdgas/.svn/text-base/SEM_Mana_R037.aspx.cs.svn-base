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

public partial class eis_SEM_Mana_R037 : EISPageBase
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
        //private enum EN_GRIDCOL : int
        //{

        //    SELECT          = 0,
        //    DCP_CODE        = 1,
        //    SER_NO          = 2,
        //    NOTICE_YN       = 3,
        //    VW_DC_STATUS    = 4,
        //    VW_DC_DOCCODE   = 5,
        //    NTDEPT_NAME     = 6,
        //    NTEMP_NAME      = 7,
        //    VW_NT_STATUS    = 8,
        //    VW_NT_DOCCODE   = 9,
        //    REPORT_TIME     = 10,
        //    REPORT_SUBJECT  = 11,
        //    REPORT_PLACE    = 12,
        //    NTDEPT_CODE     = 13,
        //    NTEMP_ID        = 14,
        //    DC_STATUS       = 15,
        //    NT_STATUS       = 16,
        //    DC_DOCCODE      = 17,
        //    NT_DOCCODE      = 18
        //}

        //private int GetGridCol(EN_GRIDCOL enCol)
        //{
        //    return (int)enCol;
        //}

        private void SetAllTimeTop()
        {

        }

        private void InitControlValue()
        {
            this.ddlGubun.Items.Clear();
            this.ddlYearS.Items.Clear();
            this.ddlYearE.Items.Clear();
            this.ddlMonthS.Items.Clear();
            this.ddlMonthE.Items.Clear();
            
            this.ddlGubun.Items.Add(new ListItem("가격", "1"));
            this.ddlGubun.Items.Add(new ListItem("지수", "2"));

            this.ddlOffice.Items.Add(new ListItem("울산", "01"));
            this.ddlOffice.Items.Add(new ListItem("양산", "02"));
            
            DateTime dtS = System.DateTime.Now.AddMonths(-11);
            DateTime dtE = System.DateTime.Now;
            string sMonth= "";

            for (int i=dtS.Year; i<= dtE.Year; i++)
            {
                this.ddlYearS.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.ddlYearE.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i=1; i<=12; i++)
            {
                sMonth = (i<10 ? "0" + i.ToString() : i.ToString());

                this.ddlMonthS.Items.Add(new ListItem(sMonth, sMonth));
                this.ddlMonthE.Items.Add(new ListItem(sMonth, sMonth));
            }

            FindByValueDropDownList(ddlYearS, dtS.Year.ToString());
            FindByValueDropDownList(ddlYearE, dtE.Year.ToString());
            FindByValueDropDownList(ddlMonthS, (dtS.Month < 10 ? "0"+dtS.Month.ToString() :dtS.Month.ToString()));
            FindByValueDropDownList(ddlMonthE, (dtE.Month < 10 ? "0"+dtE.Month.ToString() :dtE.Month.ToString()));
            FindByValueDropDownList(ddlGubun, "2");
            FindByValueDropDownList(ddlOffice, "01");
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
            string sGubun   = GetByValueDropDownList(ddlGubun);
            string sYYYYMMs = GetByValueDropDownList(ddlYearS) + GetByValueDropDownList(ddlMonthS);
            string sYYYYMMe = GetByValueDropDownList(ddlYearE) + GetByValueDropDownList(ddlMonthE);
            string[] saTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");
            string sOffice  = GetByValueDropDownList(ddlOffice);

            if (!(saTerm.Length >= 1 && saTerm.Length <= 12))
            {
                AlertMessage("[12개월] 이내에서만 조회 가능합니다!");
                return;
            }

            string sTypeQuery = ""; // 시리즈용 쿼리
            Series[] oasrType;      // 시리즈 저장배열

            sTypeQuery += "SELECT DISTINCT                                    \n";
            sTypeQuery += "       a.sem_code2_name,                           \n";
            sTypeQuery += "       a.sem_code2_t                               \n";
            sTypeQuery += "  FROM SEM_CODE_MASTER      a,                     \n";
            sTypeQuery += "       SEM_MOVEMENT_PRICE   b                      \n";
            sTypeQuery += " WHERE a.sem_code1_t = '09'                        \n";
            sTypeQuery += "   AND b.LNG_DATE_T BETWEEN '" + sYYYYMMs + "'     \n";
            sTypeQuery += "                        AND '" + sYYYYMMe + "'     \n";
            sTypeQuery += "   AND b.LNG_OFFICE_T    =  '" + sOffice  + "'     \n";
            sTypeQuery += "   AND b.LNG_GUBN_NAME_T = a.SEM_CODE2_T           \n";
            sTypeQuery += "   AND a.sem_code2_t IN ('51002','51003','51004')  \n";
            sTypeQuery += " ORDER BY                                          \n";
            sTypeQuery += "       a.sem_code2_t                               \n";



            DataSet dsType  = dbAgent.FillDataSet(sTypeQuery, "Data");

            Chart1.DataSource = GetChartDataTable(sYYYYMMs, sYYYYMMe, sGubun, sOffice).DefaultView;

            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

            // 시리즈 동적 생성
            oasrType = new Series[dsType.Tables[0].Rows.Count];
            DataRow dr;

            if (oasrType.Length > 0)
            {
                for (int i = 0; i < oasrType.Length; i++)
                {
                    dr = dsType.Tables[0].Rows[i];
                    oasrType[i] = DundasCharts.CreateSeries(Chart1, "Series" + i.ToString(), "Default",
                                                            dr["sem_code2_name"].ToString(), null, SeriesChartType.Line, 3,
                                                            GetChartColor(i), GetChartColor(i), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                }

                oasrType[0].ValueMemberX = "sem_yyyymm";
                DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);

                for (int i=0; i<oasrType.Length; i++)
                {
                    dr = dsType.Tables[0].Rows[i];
                    oasrType[i].ValueMembersY = "sem_" + dr["sem_code2_name"].ToString() + "_t";

                    if (i== 0)
                        DundasAnimations.GrowingAnimation(Chart1, oasrType[i], 0.5, 1.0, false);
                    else
                        DundasAnimations.GrowingAnimation(Chart1, oasrType[i], i + 0.1, 1.0, true);

                    oasrType[i].MarkerStyle = GetMarkerStyle(i);
                    oasrType[i].MarkerColor = GetChartColor(i);
                    oasrType[i].MarkerBorderColor = GetChartColor(i);
                    
                    oasrType[i].ToolTip = "#VALY{0.##}";
                }
                
            }

        }

        /// <summary>
        /// GetChartDataTable
        ///     : Chart용 데이타테이블 리턴
        /// </summary>
        /// <param name="asYYYYMMs"></param>
        /// <param name="asYYYYMMe"></param>
        /// <param name="sGubun"></param>
        /// <returns></returns>
        private DataTable GetChartDataTable(string asYYYYMMs, string asYYYYMMe, string asGubun, string asOffice)
        {
            string[] saTerm     = GetMonthDiff(asYYYYMMs, asYYYYMMe, "M");
            string sQuery       = GetGridQuery(asYYYYMMs, asYYYYMMe, asGubun, asOffice, false); // 기본쿼리
            string sTypeQuery   = ""; // 시리즈용 쿼리

            sTypeQuery += "SELECT DISTINCT                                 \n";
            sTypeQuery += "       a.sem_code2_name,                        \n";
            sTypeQuery += "       a.sem_code2_t                            \n";
            sTypeQuery += "  FROM SEM_CODE_MASTER      a,                  \n";
            sTypeQuery += "       SEM_MOVEMENT_PRICE   b                   \n";
            sTypeQuery += " WHERE a.sem_code1_t = '09'                     \n";
            sTypeQuery += "   AND b.LNG_DATE_T BETWEEN '" + asYYYYMMs + "' \n";
            sTypeQuery += "                        AND '" + asYYYYMMe + "' \n";
            sTypeQuery += "   AND b.LNG_OFFICE_T    = '" + asOffice + "'   \n";
            sTypeQuery += "   AND b.LNG_GUBN_NAME_T = a.SEM_CODE2_T        \n";
            sTypeQuery += " ORDER BY                                       \n";
            sTypeQuery += "       a.sem_code2_t                            \n";

            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
            DataSet ds      = dbAgent.FillDataSet(sQuery, "Data");
            DataSet dsType  = dbAgent.FillDataSet(sTypeQuery, "Data");

            DataTable dataTable = new DataTable();
            DataRow dr      = null;
            DataRow drType  = null;
            DataRow[] drDef = null;

            
            // 년도 lng b-c(30%) b-c(50%) 납사 lpg 경유 보일러등유
            dataTable.Columns.Add("sem_yyyymm", typeof(string));

            // 시리즈컬럼
            for (int i=0; i<dsType.Tables[0].Rows.Count; i++)
            {
                dataTable.Columns.Add("sem_" + dsType.Tables[0].Rows[i]["sem_code2_name"].ToString() + "_t", typeof(float));
            }

            // X축(년도) 기준 데이타 완성
            for (int i=0; i<saTerm.Length; i++)
            {
                dr = dataTable.NewRow();
                dr["sem_yyyymm"] = saTerm[i].Substring(2, 2) + "/" + saTerm[i].Substring(4,2);

                for (int j=0; j<dsType.Tables[0].Rows.Count; j++)
                {
                    drType = dsType.Tables[0].Rows[j];
                    drDef = ds.Tables[0].Select(
                                                "sem_code2_t='"     + drType["sem_code2_t"].ToString()      + "'"
                                          + "AND sem_code2_name='"  + drType["sem_code2_name"].ToString()   + "'"
                                               );

                    if (drDef.Length > 0)
                    {
                        dr["sem_" + drType["sem_code2_name"].ToString() + "_t"] = Convert.ToSingle(drDef[0]["v_" + saTerm[i]]);
                    }
                }

                dataTable.Rows.Add(dr);
            }



            return dataTable;
        }

        private void GridBinding()
        {
            string sYYYYMMs = GetByValueDropDownList(ddlYearS) + GetByValueDropDownList(ddlMonthS);
            string sYYYYMMe = GetByValueDropDownList(ddlYearE) + GetByValueDropDownList(ddlMonthE);
            string[] saTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");
            string sOffice  = GetByValueDropDownList(ddlOffice);
            

            if (!(saTerm.Length >= 1 && saTerm.Length <=12))
            {
                AlertMessage("[12개월] 이내에서만 조회 가능합니다!");
                return;
            }

            string sQuery = GetGridQuery(sYYYYMMs, sYYYYMMe, sOffice);

            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
            DataSet ds = dbAgent.FillDataSet(sQuery, "Data");

            UltraWebGrid1.Bands[0].ResetColumns();
            UltraWebGrid1.DataSource = ds;
            UltraWebGrid1.DataBind();
        }

        private string GetGridQuery(string asYYYYMMs, string asYYYYMMe, string asGubun, string asOffice, bool abIsGrid)
        {
            int i;
            string[] saMonthTerm = GetMonthDiff(asYYYYMMs, asYYYYMMe, "M");
            string sRet = "";

            if (saMonthTerm.Length <= 0)
                return "";

            sRet += "SELECT                     \n";
            sRet += "       sem_code2_t,        \n";
            sRet += "       sem_code2_name,     \n";
            sRet += "       v_Gubun,            \n";

            for (i = 0; i < saMonthTerm.Length; i++)
            {
                sRet += "       SUM(v_" + saMonthTerm[i] + ") v_" + saMonthTerm[i] + ", \n";
            }

            sRet += "       v_Order                                                             \n";
            sRet += "  FROM (                                                                   \n";
            sRet += "       SELECT a.sem_code2_t,                                               \n";
            sRet += "              a.sem_code2_name,                                            \n";
            sRet += "              DECODE(a.sem_code2_name, 'LNG', 'LNG', b.v_Gubun) v_Gubun,   \n";

            for (i = 0; i < saMonthTerm.Length; i++)
            {
                sRet += "              DECODE(b.v_Order, 1, a.v_" + saMonthTerm[i] + ", DECODE(a.sem_code2_name, 'LNG', DECODE(v_Order, 1, a.v_" + saMonthTerm[i] + ", 0), DECODE(a.v_L_" + saMonthTerm[i] + ", 0, 0, ROUND(a.v_" + saMonthTerm[i] + " / a.v_L_" + saMonthTerm[i] + ", 2)))) v_" + saMonthTerm[i] + ",  \n";
            }

            sRet += "              DECODE(a.sem_code2_name, 'LNG', 1, b.v_Order) v_Order    \n";
            sRet += "         FROM (                                                        \n";
            sRet += "              SELECT a.sem_code2_t,                                    \n";
            sRet += "                     a.sem_code2_name,                                 \n";

            for (i = 0; i < saMonthTerm.Length - 1; i++)
            {
                sRet += "                     SUM(DECODE(a.lng_date_t, '" + saMonthTerm[i] + "', a.lng_price, 0)) v_" + saMonthTerm[i] + ", \n";
                sRet += "                     SUM(DECODE(b.lng_date_t, '" + saMonthTerm[i] + "', b.lng_price, 0)) v_L_" + saMonthTerm[i] + ",   \n";
            }
            sRet += "                     SUM(DECODE(a.lng_date_t, '" + saMonthTerm[i] + "', a.lng_price, 0)) v_" + saMonthTerm[i] + ", \n";
            sRet += "                     SUM(DECODE(b.lng_date_t, '" + saMonthTerm[i] + "', b.lng_price, 0)) v_L_" + saMonthTerm[i] + "   \n";

            sRet += "                FROM (                                                 \n";
            sRet += "                     SELECT b.v_DYYYYMM      lng_date_t,               \n";
            sRet += "                            b.v_code2_t      sem_code2_t,              \n";
            sRet += "                            b.v_code2_name   sem_code2_name,           \n";
            sRet += "                            NVL(a.lng_price  , v_lng_Price) lng_price  \n";
            sRet += "                       FROM (                                          \n";
            sRet += "                            SELECT b.lng_date_t,                       \n";
            sRet += "                                   a.sem_code2_name,                   \n";
            sRet += "                                   a.sem_code2_t,                      \n";
            sRet += "                                   b.lng_price                         \n";
            sRet += "                              FROM SEM_CODE_MASTER      a,             \n";
            sRet += "                                   SEM_MOVEMENT_PRICE   b              \n";
            sRet += "                             WHERE a.sem_code1_t = '09'                \n";
            sRet += "                               AND b.LNG_DATE_T BETWEEN '" + asYYYYMMs + "'    \n";
            sRet += "                                                    AND '" + asYYYYMMe + "'    \n";
            sRet += "                               AND b.LNG_GUBN_NAME_T = a.SEM_CODE2_T       \n";
            sRet += "                               AND b.LNG_OFFICE_T    = '" + asOffice + "'  \n";
            sRet += "                            ) a,                                           \n";
            sRet += "                            (                                              \n";
            sRet += "                            SELECT a.v_code2_name,                         \n";
            sRet += "                                   a.v_code2_t,                            \n";
            sRet += "                                   b.v_DYYYYMM,                            \n";
            sRet += "                                   0 v_lng_Price                           \n";
            sRet += "                              FROM (                                       \n";
            sRet += "                                    SELECT DISTINCT                        \n";
            sRet += "                                           a.sem_code2_name v_code2_name,  \n";
            sRet += "                                           a.sem_code2_t    v_code2_t      \n";
            sRet += "                                      FROM SEM_CODE_MASTER      a          \n";
            sRet += "                                     WHERE a.sem_code1_t = '09'            \n";
            sRet += "                                   ) a,                                    \n";
            sRet += "                                   (                                       \n";

            for (i = 0; i < saMonthTerm.Length - 1; i++)
            {
                sRet += "                                   SELECT '" + saMonthTerm[i] + "' v_DYYYYMM FROM dual UNION   \n";
            }
            sRet += "                                   SELECT '" + saMonthTerm[i] + "' v_DYYYYMM FROM dual \n";

            sRet += "                                   ) b                                     \n";
            sRet += "                            ) b                                            \n";
            sRet += "                      WHERE a.sem_code2_t   (+) = b.v_code2_t              \n";
            sRet += "                        AND a.sem_code2_name(+) = b.v_code2_name           \n";
            sRet += "                        AND a.lng_date_t	   (+) = b.v_DYYYYMM            \n";
            sRet += "                     ) a,                                                  \n";
            sRet += "       			  (                                                     \n";
            sRet += "                     SELECT b.v_DYYYYMM      lng_date_t,                   \n";
            sRet += "                            b.v_code2_t      sem_code2_t,                  \n";
            sRet += "                            b.v_code2_name   sem_code2_name,               \n";
            sRet += "                            NVL(a.lng_price  , v_lng_Price) lng_price      \n";
            sRet += "                       FROM (                                              \n";
            sRet += "                            SELECT b.lng_date_t,                           \n";
            sRet += "                                   a.sem_code2_name,                       \n";
            sRet += "                                   a.sem_code2_t,                          \n";
            sRet += "                                   b.lng_price                             \n";
            sRet += "                              FROM SEM_CODE_MASTER      a,                 \n";
            sRet += "                                   SEM_MOVEMENT_PRICE   b                  \n";
            sRet += "                             WHERE a.sem_code1_t = '09'                    \n";
            sRet += "                               AND b.LNG_DATE_T BETWEEN '" + asYYYYMMs + "'    \n";
            sRet += "                                                    AND '" + asYYYYMMe + "'    \n";
            sRet += "                               AND b.LNG_GUBN_NAME_T = a.SEM_CODE2_T           \n";
            sRet += "                               AND b.LNG_OFFICE_T    = '" + asOffice + "'      \n";
            sRet += "                            ) a,                                               \n";
            sRet += "                            (                                                  \n";
            sRet += "                            SELECT a.v_code2_name,                             \n";
            sRet += "                                   a.v_code2_t,                                \n";
            sRet += "                                   b.v_DYYYYMM,                                \n";
            sRet += "                                   0 v_lng_Price                               \n";
            sRet += "                              FROM (                                           \n";
            sRet += "                                    SELECT DISTINCT                            \n";
            sRet += "                                           a.sem_code2_name v_code2_name,      \n";
            sRet += "                                           a.sem_code2_t    v_code2_t          \n";
            sRet += "                                      FROM SEM_CODE_MASTER      a              \n";
            sRet += "                                     WHERE a.sem_code1_t = '09'                \n";
            sRet += "                                       AND a.sem_code2_t = '51001'             \n";
            sRet += "                                   ) a,                                        \n";
            sRet += "                                   (                                           \n";

            for (i = 0; i < saMonthTerm.Length - 1; i++)
            {
                sRet += "                                   SELECT '" + saMonthTerm[i] + "' v_DYYYYMM FROM dual UNION   \n";
            }
            sRet += "                                   SELECT '" + saMonthTerm[i] + "' v_DYYYYMM FROM dual     \n";

            sRet += "                                   ) b                             \n";
            sRet += "                            ) b                                    \n";
            sRet += "                      WHERE a.sem_code2_t   (+) = b.v_code2_t      \n";
            sRet += "                        AND a.sem_code2_name(+) = b.v_code2_name   \n";
            sRet += "                        AND a.lng_date_t	   (+) = b.v_DYYYYMM    \n";
            sRet += "                     ) b                                           \n";
            sRet += "       		WHERE a.lng_date_t = b.lng_date_t                   \n";
            sRet += "               GROUP BY                                            \n";
            sRet += "                     a.sem_code2_t,                                \n";
            sRet += "                     a.sem_code2_name                              \n";
            sRet += "              ) a,                                                 \n";
            sRet += "              (                                                    \n";
            sRet += "              SELECT '가격' v_Gubun, 1 v_Order FROM dual UNION     \n";
            sRet += "              SELECT '지수' v_Gubun, 2 v_Order FROM dual           \n";
            sRet += "              ) b                                                  \n";
            sRet += "        WHERE 1=1                                                  \n";

            if (asGubun != "")
                sRet += "          AND v_Order = " + asGubun + "              \n";

            sRet += "       )                                                           \n";
            sRet += " GROUP BY                                                          \n";
            sRet += "       sem_code2_t,                                                \n";
            sRet += "       sem_code2_name,                                             \n";
            sRet += "       v_Gubun,                                                    \n";
            sRet += "       v_Order                                                     \n";
            sRet += " ORDER BY                                                          \n";
            sRet += "       sem_code2_t,                                                \n";
            sRet += "       sem_code2_name,                                             \n";
            sRet += "       v_Gubun,                                                    \n";
            sRet += "       v_Order                                                     \n";

            
            
            
            
            
            
            
            return sRet;
        }

        private string GetGridQuery(string asYYYYMMs, string asYYYYMMe, string asOffice)
        {
            return GetGridQuery(asYYYYMMs, asYYYYMMe, "", asOffice, true);
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
            string sYYYYMMs = GetByValueDropDownList(ddlYearS) + GetByValueDropDownList(ddlMonthS);
            string sYYYYMMe = GetByValueDropDownList(ddlYearE) + GetByValueDropDownList(ddlMonthE);
            string[] saTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            try
            {
                Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
                ch = e.Layout.Bands[0].Columns[0].Header;


                for (int i = 0; i < saTerm.Length; i++)
                {
                    e.Layout.Bands[0].Columns.FromKey("SEM_CODE2_NAME").MergeCells = true;
                    e.Layout.Bands[0].Columns.FromKey("V_" + saTerm[i]).CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns.FromKey("V_" + saTerm[i]).Format = "#,##0.0";
                    e.Layout.Bands[0].Columns[i+3].Width = 72;
                }
            }
            catch
            {
            }
            //e.Layout.Bands[0].RowStyle.BackColor = GetChartColor(0);
            
        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            string sCaption = "";
            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Row.Band.Columns)
            {
                //c.Header.RowLayoutColumnInfo.OriginY = 1;

                //iIndex++;
                sCaption = c.Header.Caption.ToUpper();

                //this.uwgTotal.Columns.FromKey("est_fail_icon").Hidden = true;

                if (sCaption == "SEM_CODE2_T")          c.Hidden = true;
                else if (sCaption == "SEM_CODE2_NAME")  c.Header.Caption = "구 분";
                else if (sCaption == "V_GUBUN")         c.Header.Caption = "구 분";
                else if (sCaption == "V_ORDER" || sCaption == "ORDER")         c.Hidden = true;
                else if (sCaption.Substring(0,2) == "V_")   c.Header.Caption = sCaption.Substring(4, 2) + "/" + sCaption.Substring(6, 2);

                
            }
            if (e.Row.Cells[2].Text == "지수")
            {
                for (int i = 2; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style.ForeColor = Color.Blue;
                    e.Row.Cells[i].Style.Font.Bold = true;
                }
            }
            
        }
    #endregion


    }
