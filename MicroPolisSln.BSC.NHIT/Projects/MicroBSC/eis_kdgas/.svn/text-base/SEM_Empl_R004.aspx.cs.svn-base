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

public partial class eis_SEM_Empl_R004 : EISPageBase
{
    private string[,] msaType = {
                                    {"인건비", "4009010000"},
                                    {"복리후생비", "4009030100"}
                                };
    
    private string[,] msaGubun= {
                                    {"계획" , "V_SUM_PLAN_AMOUNT"},
                                    {"실적" , "V_SUM_ACTUAL_AMOUNT"},
                                    {"차이",  "V_DIFF_AMOUNT"},
                                    {"집행율", "RATE"}
                                };

    

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
            this.ddlGubn.Items.Clear();

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

            ddlType.Items.Add(new ListItem("전체", ""));
            ddlType.Items.Add(new ListItem("인건비", "4009010000"));
            ddlType.Items.Add(new ListItem("복리후생비", "4009030100"));
            
            ddlGubn.Items.Add(new ListItem("당월","MS"));
            ddlGubn.Items.Add(new ListItem("누계","TS"));
            

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.Month-1 < 10 ? "0" + (dtNow.Month-1).ToString() : (dtNow.Month-1).ToString()));
            FindByTextDropDownList(ddlLocation, "울산");

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
            Series ddcSer_Col_1 = DundasCharts.CreateSeries(Chart1, "ddcSer_Col_1", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Col_2 = DundasCharts.CreateSeries(Chart1, "ddcSer_Col_2", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Line_1 = DundasCharts.CreateSeries(Chart1, "ddcSer_Line_1", "Default", "집행율", null, SeriesChartType.Line, 3, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            Series ddcSer_Line_2 = DundasCharts.CreateSeries(Chart1, "ddcSer_Line_2", "Default", "차이량", null, SeriesChartType.Column, 3, GetChartColor(6), GetChartColor(6), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

            ddcSer_Col_1.ValueMembersY = "PLAN";
            ddcSer_Col_2.ValueMembersY = "ACTUAL";
            ddcSer_Line_1.ValueMembersY = "RATE";
            ddcSer_Line_2.ValueMembersY = "DIFF";
            ddcSer_Col_1.ValueMemberX = "YYYYMM";

            string sChartArea = Chart1.Series[ddcSer_Line_1.Name].ChartArea;

            ddcSer_Line_1.YAxisType = AxisType.Secondary;
            
            Chart1.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "P0";

            DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Col_1, 0.0, 1.0, true);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Col_2, 1.0, 2.0, true);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Line_1, 0.5, 1.0, true);
            DundasAnimations.GrowingAnimation(Chart1, ddcSer_Line_2, 1.0, 1.0, true);
            //ddcSer_Line_1.MarkerStyle = GetMarkerStyle(0);
            //ddcSer_Line_1.MarkerColor = GetChartColor(2);
            //ddcSer_Line_1.MarkerBorderColor = GetChartColor(2);

        }

        // 챠트용 데이타테이블 반환

        private DataTable GetDTChart()
        {
            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            DataSet dsTable = gDbAgent.Fill(GetChartQuery());
            DataTable dtTable = null;

            dataTable.Columns.Add("YYYYMM", typeof(string));
            dataTable.Columns.Add("PLAN",   typeof(double));
            dataTable.Columns.Add("ACTUAL", typeof(double));
            dataTable.Columns.Add("RATE",   typeof(double));
            dataTable.Columns.Add("DIFF", typeof(double));

            if (dsTable.Tables.Count > 0)
            {
                dtTable = dsTable.Tables[0];

                for (int i=0; i<dtTable.Rows.Count; i++)
                {
                    drNew = dataTable.NewRow();

                    drNew["YYYYMM"] = Convert.ToInt32(dtTable.Rows[i]["V_DATE_T"].ToString().Substring(4, 2)).ToString() + "월";
                    drNew["PLAN"]   = Convert.ToDouble(dtTable.Rows[i]["V_SUM_PLAN_AMOUNT"]);
                    drNew["ACTUAL"] = Convert.ToDouble(dtTable.Rows[i]["V_SUM_ACTUAL_AMOUNT"]);
                    drNew["RATE"]   = (Convert.ToDouble(dtTable.Rows[i]["V_SUM_PLAN_AMOUNT"]) <= 0 ? 0 : Convert.ToDouble(dtTable.Rows[i]["V_SUM_ACTUAL_AMOUNT"]) / Convert.ToDouble(dtTable.Rows[i]["V_SUM_PLAN_AMOUNT"]) * 100);
                    drNew["DIFF"] = (Convert.ToDouble(dtTable.Rows[i]["V_SUM_ACTUAL_AMOUNT"]) <= 0 ? 0 : Convert.ToDouble(dtTable.Rows[i]["V_SUM_ACTUAL_AMOUNT"]) - Convert.ToDouble(dtTable.Rows[i]["V_SUM_PLAN_AMOUNT"]));
                    dataTable.Rows.Add(drNew);
                }
            }
            

            return dataTable;
        }

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            string sLocation= GetByValueDropDownList(ddlLocation);
            string sType    = GetByValueDropDownList(ddlType);
            string sYear    = GetByValueDropDownList(ddlYear);
            
            string[] saMonthTermPlan    = GetMonthTerm(sYear);          // 계획은 모든월

            DataSet dsDefault = gDbAgent.Fill(GetDefaultQuery());
            DataTable dtDefault = null;
            DataRow[] draDefault= null;

            DataTable dataTable = new DataTable();
            DataRow     drNew   = null;

            double      dTotal  = 0;

            dataTable.Columns.Add("TYPE"   , typeof(string));
            dataTable.Columns.Add("구성"   , typeof(string));
            //dataTable.Columns.Add("합계"   , typeof(double));

            for (int i=1; i<=12; i++)
            {
                dataTable.Columns.Add(i.ToString() + "월",  typeof(double));
            }

            if (dsDefault.Tables.Count > 0)
            {
                dtDefault = dsDefault.Tables[0];

                string[,] saType = GetSelectType(sType);

                for (int i=0; i<=saType.GetUpperBound(0); i++)   // 인건비, 복리후생
                {
                    for (int j=0; j<=msaGubun.GetUpperBound(0); j++) // 계획, 실적, 집행율
                    {
                        drNew = dataTable.NewRow();
                        dTotal= 0;

                        for (int k=0; k<saMonthTermPlan.Length; k++)// 검색년에 대한 년월
                        {
                            draDefault = dtDefault.Select(
                                                            "V_DATE_T   = '" + saMonthTermPlan[k] + "' "
                                                      + "AND V_ACCOUNT_CODE = '" + saType[i, 1] + "' "
                                                         ); 

                            if (draDefault.Length > 0)
                            {
                                for (int l=0; l<draDefault.Length; l++)
                                {
                                    if (msaGubun[j, 1] == "RATE")   // 집행율 계산 (실적/계획 * 100)
                                    {
                                        drNew[(k+1).ToString() + "월"] = (Convert.ToDouble(draDefault[l]["V_SUM_PLAN_AMOUNT"]) == 0 ? 0 : Convert.ToDouble(draDefault[l]["V_SUM_ACTUAL_AMOUNT"]) / Convert.ToDouble(draDefault[l]["V_SUM_PLAN_AMOUNT"]) * 100);
                                    }
                                    else    // 아니면 해당필드명이 저장되어 있으므로 해당 필드명으로 처리한다.
                                    {
                                        drNew[(k+1).ToString() + "월"] = Convert.ToDouble(draDefault[l][msaGubun[j, 1]]);
                                        dTotal += Convert.ToDouble(draDefault[l][msaGubun[j, 1]]);
                                    }
                                }
                            }
                        }

                        drNew["TYPE"] = saType[i, 0];
                        drNew["구성"] = msaGubun[j, 0];
                        //drNew["합계"] = dTotal;

                        dataTable.Rows.Add(drNew);
                    }
                }
            }

            return dataTable;
        }

        private string GetChartQuery()
        {
            string sQuery = "";

            sQuery += "SELECT v_date_t,                                     \n";
            sQuery += "       SUM(V_SUM_PLAN_AMOUNT) V_SUM_PLAN_AMOUNT,     \n";
            sQuery += "       SUM(V_SUM_ACTUAL_AMOUNT) V_SUM_ACTUAL_AMOUNT  \n";
            sQuery += "  FROM (                                             \n";

            sQuery += GetDefaultQuery();

            sQuery += "       )                                             \n";
            sQuery += " GROUP BY                                            \n";
            sQuery += "       v_date_t                                      \n";

            return sQuery;
        }

        private string GetDefaultQuery()
        {
            string sLocation = GetByValueDropDownList(ddlLocation);

            string sYear = GetByValueDropDownList(ddlYear);
            string sMonth= GetByValueDropDownList(ddlMonth);
            string sType = GetByValueDropDownList(ddlType);
            string sGubn = GetByValueDropDownList(ddlGubn);

            string[] saMonthTermPlan    = GetMonthTerm(sYear);          // 계획은 모든월
            string[] saMonthTermActual  = GetMonthTerm(sYear, sMonth);  // 실적은 선택월까지

            string sQuery = "";

            sQuery += "SELECT --+ORDERED                                                                                   \n";
            sQuery += "       B.V_DATE_T,                                                                                  \n";
            sQuery += "       B.V_ACCOUNT_CODE,                                                                            \n";
            sQuery += "       B.V_ACCOUNT_DESC,                                                                            \n";
            sQuery += "       ROUND(NVL(SUM(A.V_SUM_PLAN_AMOUNT), 0) / 1000000,0) V_SUM_PLAN_AMOUNT,                                \n";
            sQuery += "       ROUND(NVL(SUM(A.V_SUM_ACTUAL_AMOUNT), 0) / 1000000,0) V_SUM_ACTUAL_AMOUNT,                            \n";
            sQuery += "       ROUND(DECODE(SUM(A.V_SUM_ACTUAL_AMOUNT), 0, 0, (SUM(A.V_SUM_ACTUAL_AMOUNT) - SUM(A.V_SUM_PLAN_AMOUNT))/1000000),0) V_DIFF_AMOUNT                \n";
            sQuery += "  FROM (                                                                                            \n";
            sQuery += "        SELECT SM_DATE_T,                                -- 년월                                    \n";
            sQuery += "               SM_OFFICE_T,                              -- 사업장 01(울산),  02(양산)              \n";
            sQuery += "               V_ACCOUNT_CODE,        -- 계정코드                                                   \n";
            sQuery += "               V_ACCOUNT_DESC,        -- 계정명                                                     \n";
            sQuery += "               SUM(V_SUM_PLAN_AMOUNT) V_SUM_PLAN_AMOUNT,                                            \n";
            sQuery += "               SUM(V_SUM_ACTUAL_AMOUNT) V_SUM_ACTUAL_AMOUNT                                         \n";
            sQuery += "          FROM (                                                                                    \n";
            sQuery += "               SELECT SM.SM_DATE_T,                                -- 년월                          \n";
            sQuery += "                      SM.SM_OFFICE_T,                              -- 사업장 01(울산),  02(양산)    \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_CODE V_ACCOUNT_CODE,        -- 계정코드                      \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC V_ACCOUNT_DESC,        -- 계정명                        \n";
            sQuery += "                      DECODE('"+sGubn+"', 'MS', SUM(SM.SM_BUDGET_AMOUNT), SUM(SM.SM_SUM_BUDGET_AMOUNT)) V_SUM_PLAN_AMOUNT,  -- 계획                          \n";
            sQuery += "                      0 V_SUM_ACTUAL_AMOUNT -- 실적                                                 \n";
            sQuery += "                 FROM SEM_SALLING_EXPENSE SM,                                               \n";
            sQuery += "                      SEM_FINANCIAL_CODE_MASTER FIN                                         \n";
            sQuery += "                WHERE SM.SM_DATE_T BETWEEN '" + saMonthTermPlan[saMonthTermPlan.GetLowerBound(0)] + "' AND '" + saMonthTermPlan[saMonthTermPlan.GetUpperBound(0)] + "'                                    \n";
            sQuery += "                  AND SM.SM_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE                               \n";
            sQuery += "                  AND SM.SM_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                 \n";
            sQuery += "                  AND FIN.SEM_ACCOUNT2_CODE = '4009010000'                                          \n";
            sQuery += "                GROUP BY                                                                            \n";
            sQuery += "                      SM.SM_DATE_T,                                                                 \n";
            sQuery += "                      SM.SM_OFFICE_T,                                                               \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_CODE,                                                        \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC                                                         \n";
            sQuery += "               UNION ALL                                                                            \n";
            sQuery += "               SELECT SM.SM_DATE_T,                                -- 년월                          \n";
            sQuery += "                      SM.SM_OFFICE_T,                              -- 사업장 01(울산),  02(양산)    \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_CODE V_ACCOUNT_CODE,        -- 계정코드                      \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC V_ACCOUNT_DESC,        -- 계정명                        \n";
            sQuery += "                      0 V_SUM_PLAN_AMOUNT,  -- 계획                                                 \n";
            sQuery += "                      DECODE('"+sGubn+"','MS',SUM(SM.SM_ACTUAL_AMOUNT), SUM(SM.SM_SUM_ACTUAL_AMOUNT)) V_SUM_ACTUAL_AMOUNT -- 실적                          \n";
            sQuery += "                 FROM SEM_SALLING_EXPENSE SM,                                               \n";
            sQuery += "                      SEM_FINANCIAL_CODE_MASTER FIN                                         \n";
            sQuery += "                WHERE SM.SM_DATE_T BETWEEN '" + saMonthTermActual[saMonthTermActual.GetLowerBound(0)] + "' AND '" + saMonthTermActual[saMonthTermActual.GetUpperBound(0)] + "'                                    \n";
            sQuery += "                  AND SM.SM_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE                               \n";
            sQuery += "                  AND SM.SM_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                 \n";
            sQuery += "                  AND FIN.SEM_ACCOUNT2_CODE = '4009010000'                                          \n";
            sQuery += "                GROUP BY                                                                            \n";
            sQuery += "                      SM.SM_DATE_T,                                                                 \n";
            sQuery += "                      SM.SM_OFFICE_T,                                                               \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_CODE,                                                        \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC                                                         \n";
            sQuery += "               )                                                                                    \n";
            sQuery += "         GROUP BY                                                                                   \n";
            sQuery += "               SM_DATE_T,                                -- 년월                                    \n";
            sQuery += "               SM_OFFICE_T,                              -- 사업장 01(울산),  02(양산)              \n";
            sQuery += "               V_ACCOUNT_CODE,        -- 계정코드                                                   \n";
            sQuery += "               V_ACCOUNT_DESC         -- 계정명                                                     \n";
            sQuery += "        UNION ALL                                                                                   \n";
            sQuery += "        SELECT                                                                                      \n";
            sQuery += "               SM_DATE_T,                                                                           \n";
            sQuery += "               SM_OFFICE_T,                                                                         \n";
            sQuery += "               V_ACCOUNT_CODE,                                                                      \n";
            sQuery += "               V_ACCOUNT_DESC,                                                                      \n";
            sQuery += "               SUM(V_SUM_PLAN_AMOUNT) V_SUM_PLAN_AMOUNT,                                            \n";
            sQuery += "               SUM(V_SUM_ACTUAL_AMOUNT) V_SUM_ACTUAL_AMOUNT                                         \n";
            sQuery += "          FROM                                                                                      \n";
            sQuery += "               (                                                                                    \n";
            sQuery += "                SELECT SM.SM_DATE_T,                                                                \n";
            sQuery += "                       SM.SM_OFFICE_T,                                                              \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_CODE V_ACCOUNT_CODE,                                        \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_DESC V_ACCOUNT_DESC,                                        \n";
            sQuery += "                       DECODE('"+sGubn+"','MS', SUM(SM.SM_BUDGET_AMOUNT), SUM(SM.SM_SUM_BUDGET_AMOUNT)) V_SUM_PLAN_AMOUNT,                                  \n";
            sQuery += "                       0 V_SUM_ACTUAL_AMOUNT                                                        \n";
            sQuery += "                  FROM SEM_SALLING_EXPENSE SM,                                              \n";
            sQuery += "                       SEM_FINANCIAL_CODE_MASTER FIN                                        \n";
            sQuery += "                 WHERE SM.SM_DATE_T BETWEEN '" + saMonthTermPlan[saMonthTermPlan.GetLowerBound(0)] + "' AND '" + saMonthTermPlan[saMonthTermPlan.GetUpperBound(0)] + "'                                   \n";
            sQuery += "                   AND SM.SM_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE                              \n";
            sQuery += "                   AND SM.SM_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                \n";
            sQuery += "                   AND FIN.SEM_ACCOUNT3_CODE = '4009030100'                                         \n";
            sQuery += "                 GROUP BY                                                                           \n";
            sQuery += "                       SM.SM_DATE_T,                                                                \n";
            sQuery += "                       SM.SM_OFFICE_T,                                                              \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_CODE,                                                       \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_DESC                                                        \n";
            sQuery += "                UNION ALL                                                                           \n";
            sQuery += "                SELECT SM.SM_DATE_T,                                                                \n";
            sQuery += "                       SM.SM_OFFICE_T,                                                              \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_CODE V_ACCOUNT_CODE,                                        \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_DESC V_ACCOUNT_DESC,                                        \n";
            sQuery += "                       0 V_SUM_PLAN_AMOUNT,                                                         \n";
            sQuery += "                       DECODE('"+sGubn+"', 'MS',SUM(SM.SM_ACTUAL_AMOUNT),SUM(SM.SM_SUM_ACTUAL_AMOUNT)) V_SUM_ACTUAL_AMOUNT                                 \n";
            sQuery += "                  FROM SEM_SALLING_EXPENSE SM,                                              \n";
            sQuery += "                       SEM_FINANCIAL_CODE_MASTER FIN                                        \n";
            sQuery += "                 WHERE SM.SM_DATE_T BETWEEN '" + saMonthTermActual[saMonthTermActual.GetLowerBound(0)] + "' AND '" + saMonthTermActual[saMonthTermActual.GetUpperBound(0)] + "'                                   \n";
            sQuery += "                   AND SM.SM_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE                              \n";
            sQuery += "                   AND SM.SM_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                \n";
            sQuery += "                   AND FIN.SEM_ACCOUNT3_CODE = '4009030100'                                         \n";
            sQuery += "                 GROUP BY                                                                           \n";
            sQuery += "                       SM.SM_DATE_T,                                                                \n";
            sQuery += "                       SM.SM_OFFICE_T,                                                              \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_CODE,                                                       \n";
            sQuery += "                       FIN.SEM_ACCOUNT3_DESC                                                        \n";
            sQuery += "               )                                                                                    \n";
            sQuery += "         GROUP BY                                                                                   \n";
            sQuery += "               SM_DATE_T,                                                                           \n";
            sQuery += "               SM_OFFICE_T,                                                                         \n";
            sQuery += "               V_ACCOUNT_CODE,                                                                      \n";
            sQuery += "               V_ACCOUNT_DESC                                                                       \n";
            sQuery += "       ) A,                                                                                         \n";
            sQuery += "       (                                                                                            \n";
            sQuery += "       SELECT A.V_ACCOUNT_CODE,                                                                     \n";
            sQuery += "              A.V_ACCOUNT_DESC,                                                                     \n";
            sQuery += "              B.V_OFFICE_T,                                                                         \n";
            sQuery += "              C.V_DATE_T                                                                            \n";
            sQuery += "         FROM                                                                                       \n";
            sQuery += "              (                                                                                     \n";
            sQuery += "              SELECT '4009010000' v_ACCOUNT_CODE, '인건비' V_ACCOUNT_DESC FROM dual UNION ALL       \n";
            sQuery += "              SELECT '4009030100' V_ACCOUNT_CODE, '복리후생비' V_ACCOUNT_DESC FROM DUAL             \n";
            sQuery += "              ) A,                                                                                  \n";
            sQuery += "              (                                                                                     \n";
            sQuery += "              SELECT '01' V_OFFICE_T FROM DUAL UNION ALL                                            \n";
            sQuery += "              SELECT '02' V_OFFICE_T FROM DUAL                                                      \n";
            sQuery += "              ) B,                                                                                  \n";
            sQuery += "              (                                                                                     \n";
            
            int i = 0;
            for (i=0; i<saMonthTermPlan.Length-1; i++)
            {
                sQuery += "              SELECT '" + saMonthTermPlan[i] + "' V_DATE_T FROM DUAL UNION ALL                                          \n";
            }
            sQuery += "              SELECT '" + saMonthTermPlan[i] + "' V_DATE_T FROM DUAL                                          \n";
            
            
            sQuery += "              ) C                                                                                   \n";
            sQuery += "       ) B                                                                                          \n";
            sQuery += " WHERE 1=1                                                                                          \n";
            sQuery += "   AND A.SM_DATE_T      (+) = B.V_DATE_T                                                            \n";
            sQuery += "   AND A.V_ACCOUNT_CODE (+) = B.V_ACCOUNT_CODE                                                      \n";
            sQuery += "   AND A.SM_OFFICE_T    (+) = B.V_OFFICE_T                                                          \n";
            
            if (sLocation != "--")
                sQuery += "   AND B.V_OFFICE_T = '" + sLocation + "'                                                                          \n";
            
            if (sType != "")
                sQuery += "   AND B.V_ACCOUNT_CODE = '" + sType + "'                                                                          \n";
            
            
            sQuery += " GROUP BY                                                                                           \n";
            sQuery += "       B.V_DATE_T,                                                                                  \n";
            sQuery += "       B.V_ACCOUNT_CODE,                                                                            \n";
            sQuery += "       B.V_ACCOUNT_DESC                                                                             \n";

            return sQuery;
        }
        
        private string[] GetMonthTerm(string asYear, string asMonth)
        {
            string[] saMonthTerm;

            string sYYYYMMs = asYear + "01";
            string sYYYYMMe = asYear + asMonth;

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

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

            saMonthTerm = GetMonthDiff(sYYYYMMs, sYYYYMMe, "M");

            return saMonthTerm;
        }

        private string[] GetMonthTerm(int aiYear)
        {
            return GetMonthTerm(aiYear.ToString());
        }

        private string[,] GetSelectType(string asType)
        {
            string sType = "";

            for (int i = 0; i <= msaType.GetUpperBound(0); i++)
            {
                if (asType == "")
                {
                    sType += msaType[i, 0] + ";" + msaType[i, 1] + ";";
                }
                else
                {
                    if (asType == msaType[i, 1])
                    {
                        sType += msaType[i, 0] + ";" + msaType[i, 1] + ";";
                        break;
                    }
                }
            }

            return GetSplit(sType, 2);
        }

        private string[,] GetSelectType()
        {
            return GetSelectType("");
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

            for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.#";

            }

        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            UltraWebGrid1.Bands[0].Columns[0].Header.Caption = "계정구분";
            if (
                Convert.ToString(e.Row.Cells.FromKey("구성").Value) == "집행율"
               )
            {
                for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
                {
                    UltraWebGrid1.Columns[i].Width = 60;
                    e.Row.Cells[i].Value = Math.Round(Convert.ToDouble(e.Row.Cells[i].Value), 1).ToString() + "%";
                }
            }
        }
    #endregion
}
