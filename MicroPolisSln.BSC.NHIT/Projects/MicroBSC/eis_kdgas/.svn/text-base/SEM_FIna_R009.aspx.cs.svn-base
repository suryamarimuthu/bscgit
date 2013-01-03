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

public partial class eis_SEM_FIna_R009 : EISPageBase
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
            this.ddlGubun.Items.Clear();

            for (int i = dtNow.Year - 2; i <= dtNow.Year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                sMonth = (i < 10 ? "0" + i.ToString() : i.ToString());
                this.ddlMonth.Items.Add(new ListItem(sMonth, sMonth));
            }

            DataBindDropDownList(ddlGubun, GetDataSetGubun());
            ddlGubun.Items.Insert(0, new ListItem("전체", ""));

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.Month-1 < 10 ? "0" + (dtNow.Month-1).ToString() : (dtNow.Month-1).ToString()));

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
        private DataSet GetDataSetGubun()
        {
            string sQuery = "";

            sQuery += "SELECT DISTINCT SEM_ACCOUNT1_CODE,    \n";
            sQuery += "       SEM_ACCOUNT1_DESC              \n";
            sQuery += "  FROM SEM_Financial_Code_Master      \n";
            sQuery += " WHERE SEM_Financial_Code = 'CB'      \n";   

            return gDbAgent.Fill(sQuery);
        }

        private void DataBindDropDownList(DropDownList ddlReceive, DataSet dsReceive)
        {
            ddlReceive.Items.Clear();

            if (dsReceive.Tables.Count > 0)
            {
                //DB에서 검색된 데이타를 ddlReceive 컨트롤에 바인딩합니다.
                //DropDownList 컨트롤에 사용될 데이타소스입니다.
                ddlReceive.DataSource = dsReceive;
                //DropDownList 컨트롤에 출력될 Text 입니다.
                ddlReceive.DataTextField = "SEM_ACCOUNT1_DESC";
                //DropDownList 컨트롤에 출력될 Value 입니다.
                ddlReceive.DataValueField = "SEM_ACCOUNT1_CODE";
                //DropDownList 컨트롤에 바인딩합니다.
                ddlReceive.DataBind();
            }

            //객체를 해제합니다
            if ((ddlReceive != null) && (dsReceive != null))
            {
                dsReceive.Dispose();
                ddlReceive.Dispose();
                dsReceive = null;
                ddlReceive = null;
            }
        }

        private void GridBinding()
        {
            UltraWebGrid1.DataSource = GetDTGrid();
            UltraWebGrid1.DataBind();
        }

        private void ChartBinding()
        {
            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            #region Chart1 셋팅 START
                // 시리즈 생성
                Series ddcSer_C1_1 = DundasCharts.CreateSeries(Chart1, "ddcSer_C1_1", "Default", "예산", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                Series ddcSer_C1_2 = DundasCharts.CreateSeries(Chart1, "ddcSer_C1_2", "Default", "실적", null, SeriesChartType.Column, 1, Color.FromArgb(0xFF, 0x8A, 0x00), Color.FromArgb(0xD7, 0x41, 0x01), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                Series ddcSer_C1_3 = DundasCharts.CreateSeries(Chart1, "ddcSer_C1_3", "Default", "집행율", null, SeriesChartType.Line, 3, Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(0x00, 0xC4, 0xCB), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

                double Rate = 0;

                Chart1.DataSource = GetDTChart();

                ddcSer_C1_1.ValueMemberX = "capt_date_t";
                ddcSer_C1_1.ValueMembersY= "v_SumPlan";
                ddcSer_C1_2.ValueMembersY= "v_SumActual";
                ddcSer_C1_3.ValueMembersY= "v_Rate";

                string sChartArea = Chart1.Series[ddcSer_C1_3.Name].ChartArea;
                ddcSer_C1_3.YAxisType = AxisType.Secondary;

                Chart1.ChartAreas[sChartArea].AxisY2.Minimum = 0;
                //Chart1.ChartAreas[sChartArea].AxisY2.Maximum = dAxis2MaxRate + 10;
                Chart1.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

                DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
                DundasAnimations.GrowingAnimation(Chart1, ddcSer_C1_1, 0.0, 1.0, true);
                DundasAnimations.GrowingAnimation(Chart1, ddcSer_C1_2, 1.0, 2.0, true);
                DundasAnimations.GrowingAnimation(Chart1, ddcSer_C1_3, 0.5, 1.0, true);
            
                ddcSer_C1_3.MarkerStyle = GetMarkerStyle(2);
                ddcSer_C1_3.MarkerColor = GetChartColor(2);
                ddcSer_C1_3.MarkerBorderColor = GetChartColor(2);

            #endregion Chart1 셋팅 END
        }
     
        private DataTable GetDTChart()
        {
            DataSet ds = gDbAgent.Fill(GetChartQuery());
            DataTable dataTable = new DataTable();

            if (ds.Tables.Count > 0)
            {
                dataTable = ds.Tables[0];
            }

            return dataTable;
        }

        private DataTable GetDTGrid()
        {
            DataTable dataTable = new DataTable();

            string sYYYYMMs, sYYYYMMe;
            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재

            string sGubun       = GetByValueDropDownList(ddlGubun);

            dataTable.Columns.Add("계정1",   typeof(string));
            dataTable.Columns.Add("계정2",   typeof(string));
            dataTable.Columns.Add("계정3",   typeof(string));
            dataTable.Columns.Add("구분",   typeof(string));
            dataTable.Columns.Add("합계",   typeof(double));

            for (int i=0; i<saMonthTerm.Length; i++)
            {
                dataTable.Columns.Add(Convert.ToInt32(saMonthTerm[i].Substring(4, 2)) + "월", typeof(double));
            }

            DataSet dsDefault   = gDbAgent.Fill(GetDefaultQuery());
            DataSet dsGubun     = gDbAgent.Fill(GetGubunQuery());

            DataRow[] drTemp    = null;
            DataRow   drDefault = null;
            if (dsDefault.Tables.Count > 0 && dsGubun.Tables.Count > 0)
            {
                DataTable dtDefault = dsDefault.Tables[0];
                DataTable dtGubun   = dsGubun.Tables[0];
                double SumPlan = 0;  // 해당열 전체합계 저장
                double SumActual = 0;

                double TotalSumPlan = 0;
                double TotalSumActual = 0;
                double TotalPlan=0;
                double TotalActual=0;
                double[] Plan = new double[saMonthTerm.Length];
                double[] Actual = new double[saMonthTerm.Length];
                for (int i = 0; i < dtGubun.Rows.Count; i++)
                {

                    for (int j=0; j<3; j++) // 예산, 실적, 집행율 열추가
                    {
                        drDefault = dataTable.NewRow();
                        drDefault["계정1"] = dtGubun.Rows[i]["SEM_ACCOUNT1_DESC"].ToString();
                        drDefault["계정2"] = dtGubun.Rows[i]["SEM_ACCOUNT2_DESC"].ToString();
                        drDefault["계정3"] = dtGubun.Rows[i]["SEM_ACCOUNT3_DESC"].ToString();
                        SumPlan = 0;
                        SumActual = 0;
                        for (int k=0; k<saMonthTerm.Length; k++)
                        {
                            drTemp = dtDefault.Select(
                                                        "CAPT_DATE_T    = '" + saMonthTerm[k] + "' "
                                                  + "AND SEM_ACCOUNT1_CODE   = '" + dtGubun.Rows[i]["SEM_ACCOUNT1_CODE"].ToString() + "' "
                                                  + "AND SEM_ACCOUNT2_CODE   = '" + dtGubun.Rows[i]["SEM_ACCOUNT2_CODE"].ToString() + "' "
                                                  + "AND SEM_ACCOUNT3_CODE   = '" + dtGubun.Rows[i]["SEM_ACCOUNT3_CODE"].ToString() + "' "
                                                     );
                            
                            if (drTemp.Length > 0)
                            {
                                switch (j)
                                {
                                    case 0: // 예산
                                        drDefault["구분"] = "예산";
                                        drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = Convert.ToDouble(drTemp[0]["v_SumPlan"]);
                                        Plan[k] += Convert.ToDouble(drTemp[0]["v_SumPlan"]);
                                        SumPlan += Convert.ToDouble(drTemp[0]["v_SumPlan"]);
                                        break;
                                    case 1: // 실적
                                        drDefault["구분"] = "실적";
                                        drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = Convert.ToDouble(drTemp[0]["v_SumActual"]);
                                        Actual[k] += Convert.ToDouble(drTemp[0]["v_SumActual"]);
                                        SumActual += Convert.ToDouble(drTemp[0]["v_SumActual"]);
                                        break;
                                    case 2: // 집행율
                                        drDefault["구분"] = "집행율";

                                        if (Convert.ToDouble(drTemp[0]["v_SumPlan"]) > 0)
                                        {
                                            drDefault["합계"] = Math.Round(Convert.ToDouble(drTemp[0]["v_SumActual"]) / Convert.ToDouble(drTemp[0]["v_SumPlan"]) * 100,2);

                                            drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = Math.Round(Convert.ToDouble(drTemp[0]["v_SumActual"]) / Convert.ToDouble(drTemp[0]["v_SumPlan"]) * 100,2);
                                        }
                                        else
                                        {
                                            drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = 0;
                                            drDefault["합계"] = 0;
                                        }

                                        break;


                                }

                                if (j != 2)
                                {
                                    // 집행율일때는 합계를 표시하지 않는다.
                                    if (j == 0)
                                        drDefault["합계"] = SumPlan;
                                    else
                                        drDefault["합계"] = SumActual;
                                }

                                

                            }


                        }
                        

                        dataTable.Rows.Add(drDefault);
                    }


                    
                }

                    drDefault = dataTable.NewRow();
                    drDefault["계정1"] = "합계";
                    drDefault["계정2"] = "";
                    drDefault["계정3"] = "";
                    drDefault["구분"] = "예산";
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (dataTable.Rows[i]["구분"].ToString() == "예산")
                        {
                            TotalSumPlan += Convert.ToDouble(dataTable.Rows[i]["합계"]);
                        }
                    }
                    drDefault["합계"] = TotalSumPlan;
                    for (int k = 0; k < saMonthTerm.Length; k++)
                    {
                        drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = Convert.ToDouble(Plan[k].ToString());

                    }


                    dataTable.Rows.Add(drDefault);
                    drDefault = dataTable.NewRow();
                    drDefault["계정1"] = "합계";
                    drDefault["계정2"] = "";
                    drDefault["계정3"] = "";
                    drDefault["구분"] = "실적";
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (dataTable.Rows[i]["구분"].ToString() == "실적")
                        {
                            TotalSumActual += Convert.ToDouble(dataTable.Rows[i]["합계"]);
                        }
                    }
                    drDefault["합계"] = TotalSumActual;
                    for (int k = 0; k < saMonthTerm.Length; k++)
                    {
                        drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = Convert.ToDouble(Actual[k].ToString());

                    }
                    dataTable.Rows.Add(drDefault);


                    drDefault = dataTable.NewRow();
                    drDefault["계정1"] = "합계";
                    drDefault["계정2"] = "";
                    drDefault["계정3"] = "";
                    drDefault["구분"] = "집행율";
                    if (TotalSumActual > 0 && TotalSumPlan > 0)
                        drDefault["합계"] = Math.Round(TotalSumActual / TotalSumPlan * 100,2);
                    else
                        drDefault["합계"] = 0;
                    for (int k = 0; k < saMonthTerm.Length; k++)
                    {
                        if (Convert.ToDouble(Actual[k].ToString()) > 0 && Convert.ToDouble(Plan[k].ToString()) > 0)
                        {
                            drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = Math.Round(Convert.ToDouble(Actual[k].ToString()) / Convert.ToDouble(Plan[k].ToString()) * 100,2);
                        }
                        else
                        {
                            drDefault[Convert.ToInt32(saMonthTerm[k].Substring(4, 2)) + "월"] = 0;
                        
                        }
                    
                    }


                    
                    dataTable.Rows.Add(drDefault);
                    
            }

           

            return dataTable;
        }

        /// <summary>
        /// GetGubunQuery
        ///     : 검색시 해당 구분을 그리드에 표현하기 위해 추출되는 쿼리스트링
        /// </summary>
        /// <returns></returns>
        private string GetGubunQuery()
        {
            string sGubun = GetByValueDropDownList(ddlGubun);
            string sQuery = "";

            sQuery += "SELECT DISTINCT                       \n";
            sQuery += "       SEM_ACCOUNT1_CODE,             \n";
            sQuery += "       SEM_ACCOUNT1_DESC,             \n";
            sQuery += "       SEM_ACCOUNT2_CODE,             \n";
            sQuery += "       SEM_ACCOUNT2_DESC,             \n";
            sQuery += "       SEM_ACCOUNT3_CODE,             \n";
            sQuery += "       SEM_ACCOUNT3_DESC              \n";
            sQuery += "  FROM SEM_Financial_Code_Master      \n";
            sQuery += " WHERE SEM_Financial_Code = 'CB'      \n";

            if (sGubun != "")
                sQuery += "   AND SEM_ACCOUNT1_CODE = '" + sGubun + "' \n";

            return sQuery;
        }

      


        private string GetChartQuery()
        {
            string sQuery = "";

            sQuery += "SELECT decode(SUBSTR(capt_date_t,5,2), '01','1', '02','2', '03','3',   \n";
            sQuery += "                                       '04','4', '05','5', '06','6',   \n";
            sQuery += "                                       '07','7', '08','8', '09','9',   \n";
            sQuery += "                                        substr(capt_date_t,5,2))||'월'  capt_date_t,                          \n";
            sQuery += "	   v_SumPlan,                               \n";
            sQuery += "	   v_SumActual,                             \n";
            sQuery += "	   round(v_Rate,4)      as v_Rate,          \n";
            sQuery += "	   round(MAX(v_Rate),4) as v_MaxRate,       \n";
            sQuery += "	   capt_date_t          as MM               \n";
            sQuery += "  FROM (                                     \n";
            sQuery += "       SELECT capt_date_t,                   \n";   
            sQuery += "              SUM(v_SumPlan) v_SumPlan,      \n";  
            sQuery += "              SUM(v_SumActual) v_SumActual , \n";
            sQuery += "              DECODE(SUM(v_SumPlan), 0, 0, (SUM(v_SumActual) / SUM(v_SumPlan) * 100)) v_Rate \n";
            sQuery += "         FROM (                              \n";  

            sQuery += GetDefaultQuery();

            sQuery += "              )                              \n";  
            sQuery += "        GROUP BY                             \n";  
            sQuery += "              capt_date_t                    \n";
            sQuery += "       )                                     \n";
            sQuery += " GROUP BY                                    \n";
            sQuery += "       capt_date_t,                          \n";
            sQuery += "	      v_SumPlan,                            \n";
            sQuery += "	      v_SumActual,                          \n";
            sQuery += "	      v_Rate                                \n";
            sQuery += "	ORDER BY MM                                 \n";

            return sQuery;
        }


        private string GetDefaultQuery()
        {
            string[] saMonthTerm;

            string sGubun   = GetByValueDropDownList(ddlGubun);

            string sYYYYMMs = GetByValueDropDownList(ddlYear) + "01";
            string sYYYYMMe = GetByValueDropDownList(ddlYear) + GetByValueDropDownList(ddlMonth);

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            string sQuery = "";

            sQuery += "SELECT                                                                                   \n";
            sQuery += "       b.CAPT_DATE_T    ,                                                                \n";
            sQuery += "       b.SEM_ACCOUNT1_CODE   ,                                                           \n";
            sQuery += "       b.SEM_ACCOUNT2_CODE   ,                                                           \n";
            sQuery += "       b.SEM_ACCOUNT3_CODE   ,                                                           \n";
            sQuery += "       b.SEM_ACCOUNT1_DESC ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT2_DESC ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT3_DESC ,                                                             \n";
            sQuery += "       ROUND(SUM(NVL(a.v_SumPlan, 0))/1000,0) v_SumPlan,                                 \n";
            sQuery += "       ROUND(SUM(NVL(a.v_SumActual, 0))/1000,0) v_SumActual                              \n";
            sQuery += "  FROM (SELECT DISTINCT CA.CAPT_DATE_T,                                 -- 년월                   \n";
            sQuery += "              CDM.SEM_ACCOUNT1_CODE,                           -- 자금수지 코드          \n";
            sQuery += "              CDM.SEM_ACCOUNT1_DESC,                           -- 자금 수지 명           \n";
            sQuery += "              CDM.SEM_ACCOUNT2_CODE,                           -- 자금수지 코드          \n";
            sQuery += "              CDM.SEM_ACCOUNT2_DESC,                           -- 자금 수지 명           \n";
            sQuery += "              CDM.SEM_ACCOUNT3_CODE,                           -- 자금수지 코드          \n";
            sQuery += "              CDM.SEM_ACCOUNT3_DESC,                           -- 자금 수지 명           \n";
            sQuery += "              CA.CAPT_AMT_PLAN AS    v_SumPlan,             -- 예산                   \n";
            sQuery += "              CA.CAPT_AMT_ACTUAL AS  v_SumActual            -- 실적                   \n";
            sQuery += "         FROM SEM_FINANCIAL_CODE_MASTER CDM,                                     \n";
            sQuery += "              SEM_CAPITAL_BALANCE CA                                             \n";
            sQuery += "        WHERE CDM.SEM_FINANCIAL_CODE = 'CB'                                        \n";
            sQuery += "              AND CA.CAPT_DATE_T BETWEEN '" + sYYYYMMs + "' AND '" + sYYYYMMe + "'       \n";
            sQuery += "              AND CA.CAPT_CODE3_T = CDM.SEM_ACCOUNT3_CODE  ) a,                              \n";
            sQuery += "       (SELECT c.v_YYYYMM CAPT_DATE_T,                                                   \n";
            sQuery += "               a.SEM_ACCOUNT1_CODE,                                                      \n";
            sQuery += "               a.SEM_ACCOUNT1_DESC,                                                      \n";
            sQuery += "               a.SEM_ACCOUNT2_CODE,                                                      \n";
            sQuery += "               a.SEM_ACCOUNT2_DESC,                                                      \n";
            sQuery += "               a.SEM_ACCOUNT3_CODE,                                                      \n";
            sQuery += "               a.SEM_ACCOUNT3_DESC                                                       \n";
            sQuery += "         FROM (SELECT DISTINCT                                                           \n";
            sQuery += "                      SEM_ACCOUNT1_CODE,                                                 \n";
            sQuery += "                      SEM_ACCOUNT1_DESC,                                                 \n";
            sQuery += "                      SEM_ACCOUNT2_CODE,                                                 \n";
            sQuery += "                      SEM_ACCOUNT2_DESC,                                                 \n";
            sQuery += "                      SEM_ACCOUNT3_CODE,                                                 \n";
            sQuery += "                      SEM_ACCOUNT3_DESC                                                  \n";
            sQuery += "                FROM SEM_FINANCIAL_CODE_MASTER a                                         \n";
            sQuery += "               WHERE a.SEM_FINANCIAL_CODE = 'CB') a,                                     \n";
            sQuery += "              (                                                                          \n";
            
            for(int i=0; i<saMonthTerm.Length; i++)
            {
                sQuery += "              SELECT '" + saMonthTerm[i] + "' v_YYYYMM FROM DUAL UNION ALL           \n";
            }
            sQuery += "              SELECT '000000' v_YYYYMM FROM DUAL ) c                                     \n";
            sQuery += "       ) b                                                                               \n";
            sQuery += " WHERE a.CAPT_DATE_T         (+) = b.CAPT_DATE_T                                         \n";
            sQuery += "   AND a.SEM_ACCOUNT1_CODE   (+) = b.SEM_ACCOUNT1_CODE                                   \n";
            sQuery += "   AND a.SEM_ACCOUNT2_CODE   (+) = b.SEM_ACCOUNT2_CODE                                   \n";
            sQuery += "   AND a.SEM_ACCOUNT3_CODE   (+) = b.SEM_ACCOUNT3_CODE                                   \n";
            sQuery += "   AND b.CAPT_DATE_T          <> '000000'                                                \n";

            if (sGubun != "")
                sQuery += "   AND b.SEM_ACCOUNT1_CODE  = '" + sGubun + "'                                       \n";

            sQuery += " GROUP BY                                                                                \n";
            sQuery += "       b.CAPT_DATE_T    ,                                                                \n";
            sQuery += "       b.SEM_ACCOUNT1_CODE ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT1_DESC ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT2_CODE ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT2_DESC ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT3_CODE ,                                                             \n";
            sQuery += "       b.SEM_ACCOUNT3_DESC                                                               \n";

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

                e.Layout.Bands[0].Columns.FromKey("합계").CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns.FromKey("합계").Format = "#,##0.##";

                for (int i = 0; i < saMonthTerm.Length; i++)
                {
                    e.Layout.Bands[0].Columns.FromKey(Convert.ToInt32(saMonthTerm[i].Substring(4, 2)) + "월").CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    e.Layout.Bands[0].Columns.FromKey(Convert.ToInt32(saMonthTerm[i].Substring(4, 2)) + "월").Format = "#,##0.##";
                }
            }
            catch{}
           

        }
        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            string sYYYYMMs, sYYYYMMe;
            string[] saMonthTerm = GetMonthTerm(out sYYYYMMs, out sYYYYMMe);   // 현재
            //double[] dSumPlan = null;
            //double[] dSumResult = null;
            //double dSumPlan2=0
            UltraWebGrid1.Bands[0].Columns[0].MergeCells = true;
            UltraWebGrid1.Bands[0].Columns[1].MergeCells = true;
            UltraWebGrid1.Bands[0].Columns[2].MergeCells = true;

            if (
                Convert.ToString(e.Row.Cells.FromKey("구분").Value) == "집행율"
               )
            {
                for (int i = 0; i < saMonthTerm.Length; i++)
                {
                    e.Row.Cells.FromKey(Convert.ToInt32(saMonthTerm[i].Substring(4, 2)) + "월").Value += "%";
                }
                e.Row.Cells.FromKey("합계").Value += "%";
            }

            if (Convert.ToString(e.Row.Cells.FromKey("계정1").Value) == "합계")
            {
                e.Row.Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);

            }

        }
    #endregion
}
