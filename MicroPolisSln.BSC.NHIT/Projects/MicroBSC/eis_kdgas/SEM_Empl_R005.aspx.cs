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

public partial class eis_SEM_Empl_R005 : EISPageBase
{
    private string[,] msaType = {
                                    {"인건비", "4009010000"},
                                    {"복리후생비", "4009030100"}
                                };

    private string[,] msaGubun = {
                                    {"계획" , "V_SUM_PLAN_AMOUNT"},
                                    {"실적" , "V_SUM_ACTUAL_AMOUNT"},
                                    {"집행율", "RATE"}
                                };

    private string[] msaHeader = {
                                    "구분", "구분","금액","비율","금액","비율","차이","집행율","금액","비율","금액","비율","차이","집행율"
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
            
            this.ddlLocation1.Items.Clear();
            this.ddlLocation2.Items.Clear();
            this.ddlLocation3.Items.Clear();

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

            this.SetAreaDropDownList(ddlLocation1);
            ddlLocation1.SelectedIndex = 0;

            ddlLocation2.DataSource = GetLocationInfo("부문");
            ddlLocation2.DataTextField = "v_Name";
            ddlLocation2.DataValueField= "v_Code3";
            ddlLocation2.DataBind();
            ddlLocation2.Items.Insert(0, new ListItem("==부문 선택==", ""));

            ddlLocation3.DataSource = GetLocationInfo("팀");
            ddlLocation3.DataTextField  = "v_Name";
            ddlLocation3.DataValueField = "v_Code3";
            ddlLocation3.DataBind();
            ddlLocation3.Items.Insert(0, new ListItem("==팀 선택==", ""));

            ddlType.Items.Add(new ListItem("전체", ""));
            ddlType.Items.Add(new ListItem("인건비", "4009010000"));
            ddlType.Items.Add(new ListItem("복리후생비", "4009030100"));

            FindByValueDropDownList(ddlYear, dtNow.Year.ToString());
            FindByValueDropDownList(ddlMonth, (dtNow.Month-1 < 10 ? "0" + (dtNow.Month-1).ToString() : (dtNow.Month-1).ToString()));
        }

        private void InitControlEvent()
        {
            this.ddlLocation1.Attributes["onchange"] = "mfChangeLocate(this, 'ddlLocation2', 'ddlLocation3')";
            this.ddlLocation2.Attributes["onchange"] = "mfChangeLocate(this, 'ddlLocation1', 'ddlLocation3')";
            this.ddlLocation3.Attributes["onchange"] = "mfChangeLocate(this, 'ddlLocation1', 'ddlLocation2')";
        }

        private void SetPageData()
        {
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

        // 그리드용 데이타테이블 반환
        private DataTable GetDTGrid()
        {
            DataSet dsDefault = gDbAgent.Fill(GetDefaultQuery());
            DataTable dtDefault = null;
            DataRow[] draDefault = null;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;

            double dTotActual1 = 0;     // 당월 Actual총합
            double dTotPlan1 = 0;       // 당월 Plan총합
            double dTotVari1 = 0;       // 당월 Vari총합
            double dSumTotActual1 = 0;  // 누계 Actual총합
            double dSumTotPlan1 = 0;    // 누계 Plan총합
            double dSumTotVari1 = 0;    // 누계 Vari총합

            double dTotActual2 = 0;     // 당월 Actual총합
            double dTotPlan2 = 0;       // 당월 Plan총합
            double dTotVari2 = 0;       // 당월 Vari총합
            double dSumTotActual2 = 0;  // 누계 Actual총합
            double dSumTotPlan2 = 0;    // 누계 Plan총합
            double dSumTotVari2 = 0;    // 누계 Vari총합

            if (dsDefault.Tables.Count > 0)
            {
                dtDefault = dsDefault.Tables[0];
                DataTableReader dtrTable = dtDefault.CreateDataReader();

                // 각 항목의 비율을 구하기 위한 합계 계산
                if (dtrTable.HasRows)
                {
                    while (dtrTable.Read())
                    {
                        if (dtrTable["V_ORDER"].ToString() == "1")
                        {
                            // 인건비
                            dTotActual1 += Convert.ToDouble(dtrTable["v_Actual"]);
                            dTotPlan1 += Convert.ToDouble(dtrTable["v_Plan"]);
                            dTotVari1 += Convert.ToDouble(dtrTable["v_Vari"]);

                            dSumTotActual1 += Convert.ToDouble(dtrTable["v_Sum_Actual"]);
                            dSumTotPlan1 += Convert.ToDouble(dtrTable["v_Sum_Plan"]);
                            dSumTotVari1 += Convert.ToDouble(dtrTable["v_Sum_Vari"]);
                        }
                        else
                        {
                            // 복리후생비
                            dTotActual2 += Convert.ToDouble(dtrTable["v_Actual"]);
                            dTotPlan2   += Convert.ToDouble(dtrTable["v_Plan"]);
                            dTotVari2   += Convert.ToDouble(dtrTable["v_Vari"]);

                            dSumTotActual2  += Convert.ToDouble(dtrTable["v_Sum_Actual"]);
                            dSumTotPlan2    += Convert.ToDouble(dtrTable["v_Sum_Plan"]);
                            dSumTotVari2    += Convert.ToDouble(dtrTable["v_Sum_Vari"]);
                        }
                    }
                }

                dataTable.Columns.Add("구분1",              typeof(string));
                dataTable.Columns.Add("구분2",              typeof(string));
                dataTable.Columns.Add("PLAN_AMOUNT",        typeof(double));
                dataTable.Columns.Add("PLAN_RATE",          typeof(double));
                dataTable.Columns.Add("ACTUAL_AMOUNT",      typeof(double));
                dataTable.Columns.Add("ACTUAL_RATE",        typeof(double));
                dataTable.Columns.Add("VARI_AMOUNT",        typeof(double));
                dataTable.Columns.Add("VARI_RATE",          typeof(double));
                dataTable.Columns.Add("SUM_PLAN_AMOUNT",    typeof(double));
                dataTable.Columns.Add("SUM_PLAN_RATE",      typeof(double));
                dataTable.Columns.Add("SUM_ACTUAL_AMOUNT",  typeof(double));
                dataTable.Columns.Add("SUM_ACTUAL_RATE",    typeof(double));
                dataTable.Columns.Add("SUM_VARI_AMOUNT",    typeof(double));
                dataTable.Columns.Add("SUM_VARI_RATE",      typeof(double));

                for (int i=0; i<=msaType.GetUpperBound(0); i++)
                {
                    if (msaType[i, 0] == "인건비")
                    {
                        double d_PR_TotActual1 = 0;     // 당월 인건비 코드별 Actual총합
                        double d_PR_TotPlan1 = 0;       // 당월 인건비 코드별 Plan총합
                        double d_PR_TotVari1 = 0;       // 당월 인건비 코드별 Vari총합
                        double d_PR_SumTotActual1 = 0;  // 누계 인건비 코드별 Actual총합
                        double d_PR_SumTotPlan1 = 0;    // 누계 인건비 코드별 Plan총합
                        double d_PR_SumTotVari1 = 0;    // 누계 인건비 코드별 Vari총합

                        string[,] saPayrollCode = GetPayrollCode(); // 인건비 구분코드

                        for (int j = 0; j <= saPayrollCode.GetUpperBound(0); j++)
                        {
                            d_PR_TotActual1 = 0;
                            d_PR_TotPlan1 = 0;
                            d_PR_TotVari1 = 0;
                            d_PR_SumTotActual1 = 0;
                            d_PR_SumTotPlan1 = 0;
                            d_PR_SumTotVari1 = 0;  

                            draDefault = dtDefault.Select(
                                                           "v_code2 = '" + msaType[i, 1] + "' "
                                                     + "AND V_CODE3 = '" + saPayrollCode[j, 0] + "' "
                                                         );

                            // 각 구분코드별 합계추출
                            for (int k=0; k <= draDefault.GetUpperBound(0); k++)
                            {
                                d_PR_TotActual1 += Convert.ToDouble(draDefault[k]["v_Actual"]);
                                d_PR_TotPlan1 += Convert.ToDouble(draDefault[k]["v_Plan"]);
                                d_PR_TotVari1 += Convert.ToDouble(draDefault[k]["v_Vari"]);

                                d_PR_SumTotActual1 += Convert.ToDouble(draDefault[k]["v_Sum_Actual"]);
                                d_PR_SumTotPlan1 += Convert.ToDouble(draDefault[k]["v_Sum_Plan"]);
                                d_PR_SumTotVari1 += Convert.ToDouble(draDefault[k]["v_Sum_Vari"]);

                            }

                            // 테이블에 계산된 Row추가
                            // 합계열.
                            drNew = dataTable.NewRow();

                            drNew["구분1"]          = "인건비";
                            drNew["구분2"]          = saPayrollCode[j, 1];
                            drNew["ACTUAL_AMOUNT"]  = d_PR_TotActual1;
                            drNew["ACTUAL_RATE"]    = (dTotActual1 == 0 ? 0 : d_PR_TotActual1 / dTotActual1 * 100);
                            drNew["PLAN_AMOUNT"]    = d_PR_TotPlan1;
                            drNew["PLAN_RATE"]      = (dTotPlan1 == 0 ? 0 : d_PR_TotPlan1 / dTotPlan1 * 100);
                            drNew["VARI_AMOUNT"]    = d_PR_TotVari1;
                            drNew["VARI_RATE"]      = (d_PR_TotPlan1 == 0 ? 0 : d_PR_TotActual1 / d_PR_TotPlan1 * 100);
                            drNew["SUM_ACTUAL_AMOUNT"]  = d_PR_SumTotActual1;
                            drNew["SUM_ACTUAL_RATE"]    = (dSumTotActual1 == 0 ? 0 : d_PR_SumTotActual1 / dSumTotActual1 * 100);
                            drNew["SUM_PLAN_AMOUNT"]    = d_PR_SumTotPlan1;
                            drNew["SUM_PLAN_RATE"]      = (dSumTotPlan1 == 0 ? 0 : d_PR_SumTotPlan1 / dSumTotPlan1 * 100);
                            drNew["SUM_VARI_AMOUNT"]    = d_PR_SumTotVari1;
                            drNew["SUM_VARI_RATE"]      = (d_PR_SumTotPlan1 == 0 ? 0 : d_PR_SumTotActual1 / d_PR_SumTotPlan1 * 100);

                            dataTable.Rows.Add(drNew);

                            for (int k=0; k <= draDefault.GetUpperBound(0); k++)
                            {
                                drNew = dataTable.NewRow();

                                drNew["구분1"]          = "인건비";
                                drNew["구분2"]          = draDefault[k]["V_NAME4"];
                                drNew["ACTUAL_AMOUNT"]  = Convert.ToDouble(draDefault[k]["V_ACTUAL"]);
                                drNew["ACTUAL_RATE"]    = (dTotActual1 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_ACTUAL"]) / dTotActual1 * 100);
                                drNew["PLAN_AMOUNT"]    = Convert.ToDouble(draDefault[k]["V_PLAN"]);
                                drNew["PLAN_RATE"]      = (dTotPlan1 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_PLAN"]) / dTotPlan1 * 100);
                                drNew["VARI_AMOUNT"]    = Convert.ToDouble(draDefault[k]["V_VARI"]);
                                drNew["VARI_RATE"]      = (Convert.ToDouble(draDefault[k]["V_PLAN"]) == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_ACTUAL"]) / Convert.ToDouble(draDefault[k]["V_PLAN"]) * 100);
                                drNew["SUM_ACTUAL_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_SUM_ACTUAL"]);
                                drNew["SUM_ACTUAL_RATE"] = (dSumTotActual1 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_SUM_ACTUAL"]) / dSumTotActual1 * 100);
                                drNew["SUM_PLAN_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]);
                                drNew["SUM_PLAN_RATE"] = (dSumTotPlan1 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]) / dSumTotPlan1 * 100);
                                drNew["SUM_VARI_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_SUM_VARI"]);
                                drNew["SUM_VARI_RATE"] = (Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]) == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_SUM_ACTUAL"]) / Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]) * 100);

                                dataTable.Rows.Add(drNew);
                            }
                        }

                        // 총합계열.
                        drNew = dataTable.NewRow();

                        drNew["구분1"] = "인건비";
                        drNew["구분2"] = "인건비 총계";
                        drNew["ACTUAL_AMOUNT"]      = dTotActual1;
                        drNew["ACTUAL_RATE"]        = (dTotActual1 == 0 ? 0 : (dTotActual1 / dTotActual1 * 100));
                        drNew["PLAN_AMOUNT"]        = dTotPlan1;
                        drNew["PLAN_RATE"]          = (dTotPlan1 == 0 ? 0 : (dTotPlan1 / dTotPlan1 * 100));
                        drNew["VARI_AMOUNT"]        = dTotVari1;
                        drNew["VARI_RATE"]          = (dTotPlan1 == 0 ? 0 : (dTotActual1 / dTotPlan1 * 100));
                        drNew["SUM_ACTUAL_AMOUNT"]  = dSumTotActual1;
                        drNew["SUM_ACTUAL_RATE"]    = (dSumTotVari1 == 0 ? 0 : (dSumTotVari1 / dSumTotVari1 * 100));
                        drNew["SUM_PLAN_AMOUNT"]    = dSumTotPlan1;
                        drNew["SUM_PLAN_RATE"]      = (dSumTotPlan1 == 0 ? 0 : (dSumTotPlan1 / dSumTotPlan1 * 100));
                        drNew["SUM_VARI_AMOUNT"]    = dSumTotVari1;
                        drNew["SUM_VARI_RATE"]      = (dSumTotPlan1 == 0 ? 0 : (dSumTotActual1 / dSumTotPlan1 * 100));

                        dataTable.Rows.Add(drNew);
                    }
                    else
                    {
                        draDefault = dtDefault.Select(
                                                       "v_code3 = '" + msaType[i, 1] + "' "
                                                     );

                        for (int k=0; k <= draDefault.GetUpperBound(0); k++)
                        {
                            drNew = dataTable.NewRow();

                            drNew["구분1"]  = "복리후생비";
                            drNew["구분2"]  = draDefault[k]["V_NAME4"];
                            drNew["ACTUAL_AMOUNT"]  = Convert.ToDouble(draDefault[k]["V_ACTUAL"]);
                            drNew["ACTUAL_RATE"] = (dTotActual2 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_ACTUAL"]) / dTotActual2 * 100);
                            drNew["PLAN_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_PLAN"]);
                            drNew["PLAN_RATE"] = (dTotPlan2 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_PLAN"]) / dTotPlan2 * 100);
                            drNew["VARI_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_VARI"]);
                            drNew["VARI_RATE"] = (Convert.ToDouble(draDefault[k]["V_PLAN"]) == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_ACTUAL"]) / Convert.ToDouble(draDefault[k]["V_PLAN"]) * 100);
                            drNew["SUM_ACTUAL_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_SUM_ACTUAL"]);
                            drNew["SUM_ACTUAL_RATE"] = (dSumTotActual2 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_SUM_ACTUAL"]) / dSumTotActual2 * 100);
                            drNew["SUM_PLAN_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]);
                            drNew["SUM_PLAN_RATE"] = (dSumTotPlan2 == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]) / dSumTotPlan2 * 100);
                            drNew["SUM_VARI_AMOUNT"] = Convert.ToDouble(draDefault[k]["V_SUM_VARI"]);
                            drNew["SUM_VARI_RATE"] = (Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]) == 0 ? 0 : Convert.ToDouble(draDefault[k]["V_SUM_ACTUAL"]) / Convert.ToDouble(draDefault[k]["V_SUM_PLAN"]) * 100);

                            dataTable.Rows.Add(drNew);
                        }

                        // 총합계열.
                        drNew = dataTable.NewRow();

                        drNew["구분1"] = "복리후생비";
                        drNew["구분2"] = "복리후생비 총계";
                        drNew["ACTUAL_AMOUNT"]      = dTotActual2;
                        drNew["ACTUAL_RATE"]        = (dTotActual2 == 0 ? 0 : (dTotActual2 / dTotActual2 * 100));
                        drNew["PLAN_AMOUNT"]        = dTotPlan2;
                        drNew["PLAN_RATE"]          = (dTotPlan2 == 0 ? 0 : (dTotPlan2 / dTotPlan2 * 100));
                        drNew["VARI_AMOUNT"]        = dTotVari2;
                        drNew["VARI_RATE"]          = (dTotPlan2 == 0 ? 0 : (dTotActual2 / dTotPlan2 * 100));
                        drNew["SUM_ACTUAL_AMOUNT"]  = dSumTotActual2;
                        drNew["SUM_ACTUAL_RATE"]    = (dSumTotActual2 == 0 ? 0 : (dSumTotActual2 / dSumTotActual2 * 100));
                        drNew["SUM_PLAN_AMOUNT"]    = dSumTotPlan2;
                        drNew["SUM_PLAN_RATE"]      = (dSumTotPlan2 == 0 ? 0 : (dSumTotPlan2 / dSumTotPlan2 * 100));
                        drNew["SUM_VARI_AMOUNT"]    = dSumTotVari2;
                        drNew["SUM_VARI_RATE"]      = (dSumTotPlan2 == 0 ? 0 : (dSumTotActual2 / dSumTotPlan2 * 100));

                        dataTable.Rows.Add(drNew);
                    }
                }
            }

            return dataTable;
        }

        private string GetDefaultQuery()
        {
            string sYear = GetByValueDropDownList(ddlYear) + GetByValueDropDownList(ddlMonth);
            string sMonth = GetByValueDropDownList(ddlMonth);

            string sLocate1 = GetByValueDropDownList(ddlLocation1);
            string sLocate2 = GetByValueDropDownList(ddlLocation2);
            string sLocate3 = GetByValueDropDownList(ddlLocation3);

            string sType = GetByTextDropDownList(ddlType);

            string[] saMonthTermActual = GetMonthTerm(sYear, sMonth);  // 실적은 선택월까지

            string sQuery = "";

            sQuery += "SELECT V_ORDER,                          \n";
            sQuery += "       V_CODE2,                          \n";
            sQuery += "       V_NAME2,                          \n";
            sQuery += "       V_CODE3,                          \n";
            sQuery += "       V_NAME3,                          \n";
            sQuery += "       V_CODE4,                          \n";
            sQuery += "       V_NAME4,                          \n";
            sQuery += "       V_PLAN,                           \n";
            sQuery += "       V_ACTUAL,                         \n";
            sQuery += "       V_VARI,                           \n";
            sQuery += "       V_SUM_PLAN,                       \n";
            sQuery += "       V_SUM_ACTUAL,                     \n";
            sQuery += "       V_SUM_VARI                        \n";
            sQuery += "  FROM (                                 \n";
            sQuery += "       SELECT 1 V_ORDER,                 \n";
            sQuery += "              A.V_CODE2,                 \n";
            sQuery += "              A.V_NAME2,                 \n";
            sQuery += "              A.V_CODE3,                 \n";
            sQuery += "              A.V_NAME3,                 \n";
            sQuery += "              A.V_CODE4,                 \n";
            sQuery += "              A.V_NAME4,                 \n";
            sQuery += "              SUM(NVL(B.V_PLAN, 0))                            V_PLAN,                       \n";
            sQuery += "              SUM(NVL(B.V_ACTUAL, 0))                          V_ACTUAL,                     \n";
            sQuery += "              SUM(NVL(B.V_ACTUAL, 0)) - SUM(NVL(B.V_PLAN, 0))  V_VARI,                       \n";
            sQuery += "              SUM(NVL(B.V_SUM_PLAN, 0))                        V_SUM_PLAN,                   \n";
            sQuery += "              SUM(NVL(B.V_SUM_ACTUAL, 0))                      V_SUM_ACTUAL,                 \n";
            sQuery += "              SUM(NVL(B.V_SUM_ACTUAL, 0)) - SUM(NVL(B.V_SUM_PLAN, 0)) V_SUM_VARI             \n";
            sQuery += "         FROM                                                                                \n";
            sQuery += "              (                                                                              \n";
            sQuery += "              -- 인건비ㅣ                                                                    \n";
            sQuery += "              SELECT SEM_ACCOUNT2_CODE V_CODE2,                                              \n";
            sQuery += "                     SEM_ACCOUNT2_DESC V_NAME2,                                              \n";
            sQuery += "                     SEM_ACCOUNT3_CODE V_CODE3,                                              \n";
            sQuery += "                     SEM_ACCOUNT3_DESC V_NAME3,                                              \n";
            sQuery += "                     SEM_ACCOUNT4_CODE V_CODE4,                                              \n";
            sQuery += "                     SEM_ACCOUNT4_DESC V_NAME4                                               \n";
            sQuery += "                FROM SEM_FINANCIAL_CODE_MASTER                                               \n";
            sQuery += "               WHERE SEM_ACCOUNT2_CODE = '4009010000'                                        \n";
            sQuery += "              )   A,                                                                         \n";
            sQuery += "              (                                                                              \n";
            sQuery += "              SELECT  FIN.SEM_ACCOUNT2_CODE    V_CODE2,                       -- 계정2코드   \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC    V_NAME2,                       -- 계정2명     \n";
            sQuery += "                      FIN.SEM_ACCOUNT3_CODE    V_CODE3,                       -- 계정3코드   \n";
            sQuery += "                      FIN.SEM_ACCOUNT3_DESC    V_NAME3,                       -- 계정3명     \n";
            sQuery += "                      FIN.SEM_ACCOUNT4_CODE    V_CODE4,                                      \n";
            sQuery += "                      FIN.SEM_ACCOUNT4_DESC    V_NAME4,                                      \n";
            sQuery += "                      SUM(SM.SM_BUDGET_AMOUNT)        V_PLAN,                 -- 계획        \n";
            sQuery += "                      SUM(SM.SM_ACTUAL_AMOUNT)        V_ACTUAL,               -- 실적        \n";
            sQuery += "                      SUM(SM.SM_SUM_BUDGET_AMOUNT)    V_SUM_PLAN,             -- 누적계획    \n";
            sQuery += "                      SUM(SM.SM_SUM_ACTUAL_AMOUNT)    V_SUM_ACTUAL            -- 누적실적    \n";
            sQuery += "                 FROM SEM_SALLING_EXPENSE SM,                                        \n";
            sQuery += "                      SEM_FINANCIAL_CODE_MASTER FIN,                                 \n";
            sQuery += "                      SEM_ORG_TABLE OT,                                              \n";
            sQuery += "                      SEM_CODE_MASTER CM                                             \n";
            sQuery += "                WHERE SM.SM_DATE_T = '" + sYear +"'                                          \n";
            sQuery += "                  AND SM.SM_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE                        \n";
            sQuery += "                  AND SM.SM_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                          \n";
            sQuery += "                  AND FIN.SEM_ACCOUNT2_CODE = '4009010000'                                   \n";
            sQuery += "                  AND CM.SEM_CODE1_T = '38'                                                  \n";
            sQuery += "                  AND SM.SM_TEAM_T = CM.SEM_CODE2_T                                          \n";
            sQuery += "                  AND CM.SEM_CODE3_T = OT.SEM_ORG_CODE3                                      \n";
            
            if (sLocate1 != "--")
                sQuery += "                  AND OT.SEM_ORG_OFFICE  = '" + sLocate1 + "'                                              \n";
            
            if (sLocate2 != "")
                sQuery += "                  AND OT.SEM_ORG_CODE1   = '" + sLocate2 + "'    \n";

            if (sLocate3 != "")
                sQuery += "                  AND OT.SEM_ORG_CODE2   = '" + sLocate3 + "'    \n";

            sQuery += "                GROUP BY                                                                     \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_CODE,                                                 \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC,                                                 \n";
            sQuery += "                      FIN.SEM_ACCOUNT3_CODE,                                                 \n";
            sQuery += "                      FIN.SEM_ACCOUNT3_DESC,                                                 \n";
            sQuery += "                      FIN.SEM_ACCOUNT4_CODE,                                                 \n";
            sQuery += "                      FIN.SEM_ACCOUNT4_DESC                                                  \n";
            sQuery += "              )   B                                                                          \n";
            sQuery += "        WHERE A.V_CODE2    = B.V_CODE2(+)                                                    \n";
            sQuery += "          AND A.V_CODE3    = B.V_CODE3(+)                                                    \n";
            sQuery += "          AND A.V_CODE4    = B.V_CODE4(+)                                                    \n";
            sQuery += "        GROUP BY                                                                             \n";
            sQuery += "              A.V_CODE2,                                                                     \n";
            sQuery += "              A.V_NAME2,                                                                     \n";
            sQuery += "              A.V_CODE3,                                                                     \n";
            sQuery += "              A.V_NAME3,                                                                     \n";
            sQuery += "              A.V_CODE4,                                                                     \n";
            sQuery += "              A.V_NAME4                                                                      \n";
            sQuery += "       UNION ALL                                                                             \n";
            sQuery += "       SELECT 2 V_ORDER,                                                                     \n";
            sQuery += "              A.V_CODE2,                                                                     \n";
            sQuery += "              A.V_NAME2,                                                                     \n";
            sQuery += "              A.V_CODE3,                                                                     \n";
            sQuery += "              A.V_NAME3,                                                                     \n";
            sQuery += "              A.V_CODE4,                                                                     \n";
            sQuery += "              A.V_NAME4,                                                                     \n";
            sQuery += "              SUM(NVL(B.V_PLAN, 0))                            V_PLAN,                       \n";
            sQuery += "              SUM(NVL(B.V_ACTUAL, 0))                          V_ACTUAL,                     \n";
            sQuery += "              SUM(NVL(B.V_ACTUAL, 0)) - SUM(NVL(B.V_PLAN, 0))  V_VARI,                       \n";
            sQuery += "              SUM(NVL(B.V_SUM_PLAN, 0))                        V_SUM_PLAN,                   \n";
            sQuery += "              SUM(NVL(B.V_SUM_ACTUAL, 0))                      V_SUM_ACTUAL,                 \n";
            sQuery += "              SUM(NVL(B.V_SUM_ACTUAL, 0)) - SUM(NVL(B.V_SUM_PLAN, 0)) V_SUM_VARI             \n";
            sQuery += "         FROM                                                                                \n";
            sQuery += "              (                                                                              \n";
            sQuery += "              -- 복리후생비                                                                  \n";
            sQuery += "              SELECT SEM_ACCOUNT2_CODE V_CODE2,                                              \n";
            sQuery += "                     SEM_ACCOUNT2_DESC V_NAME2,                                              \n";
            sQuery += "                     SEM_ACCOUNT3_CODE V_CODE3,                                              \n";
            sQuery += "                     SEM_ACCOUNT3_DESC V_NAME3,                                              \n";
            sQuery += "                     SEM_ACCOUNT4_CODE V_CODE4,                                              \n";
            sQuery += "                     SEM_ACCOUNT4_DESC V_NAME4                                               \n";
            sQuery += "                FROM SEM_FINANCIAL_CODE_MASTER                                               \n";
            sQuery += "               WHERE SEM_ACCOUNT3_CODE = '4009030100'                                        \n";
            sQuery += "              ) A,                                                                           \n";
            sQuery += "              (                                                                              \n";
            sQuery += "              SELECT  FIN.SEM_ACCOUNT2_CODE            V_CODE2,                -- 계정2코드  \n";
            sQuery += "                      FIN.SEM_ACCOUNT2_DESC            V_NAME2,                -- 계정2명    \n";
            sQuery += "                      FIN.SEM_ACCOUNT3_CODE            V_CODE3,                -- 계정2코드  \n";
            sQuery += "                      FIN.SEM_ACCOUNT3_DESC            V_NAME3,                -- 계정2명    \n";
            sQuery += "                      FIN.SEM_ACCOUNT4_CODE            V_CODE4,                -- 계정3코드  \n";
            sQuery += "                      FIN.SEM_ACCOUNT4_DESC            V_NAME4,                -- 계정3명    \n";
            sQuery += "                      SUM(SM.SM_BUDGET_AMOUNT)         V_PLAN,                 -- 계획       \n";
            sQuery += "                      SUM(SM.SM_ACTUAL_AMOUNT)         V_ACTUAL,               -- 실적       \n";
            sQuery += "                      SUM(SM.SM_SUM_BUDGET_AMOUNT)     V_SUM_PLAN,             -- 누적계획   \n";
            sQuery += "                      SUM(SM.SM_SUM_ACTUAL_AMOUNT)     V_SUM_ACTUAL            -- 누적실적   \n";
            sQuery += "                 FROM SEM_SALLING_EXPENSE SM,                                        \n";
            sQuery += "                      SEM_FINANCIAL_CODE_MASTER FIN,                                 \n";
            sQuery += "                      SEM_ORG_TABLE OT,                                              \n";
            sQuery += "                      SEM_CODE_MASTER CM                                             \n";
            sQuery += "               WHERE SM.SM_DATE_T = '" + sYear +"'                                           \n";
            sQuery += "                 AND SM.SM_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE                         \n";
            sQuery += "                 AND SM.SM_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                           \n";
            sQuery += "                 AND FIN.SEM_ACCOUNT3_CODE = '4009030100'                                    \n";
            sQuery += "                 AND CM.SEM_CODE1_T = '38'                                                   \n";
            sQuery += "                 AND SM.SM_TEAM_T = CM.SEM_CODE2_T                                           \n";
            sQuery += "                 AND CM.SEM_CODE3_T = OT.SEM_ORG_CODE3                                       \n";
            
            if (sLocate1 != "--")
                sQuery += "                  AND OT.SEM_ORG_OFFICE  = '" + sLocate1 + "'                                              \n";

            if (sLocate2 != "")
                sQuery += "                  AND OT.SEM_ORG_CODE3   = '" + sLocate2 + "'    \n";

            if (sLocate3 != "")
                sQuery += "                  AND OT.SEM_ORG_CODE3   = '" + sLocate3 + "'    \n";

            sQuery += "               GROUP BY                                                                      \n";
            sQuery += "                     FIN.SEM_ACCOUNT2_CODE,                                   -- 계정2코드   \n";
            sQuery += "                     FIN.SEM_ACCOUNT2_DESC,                                   -- 계정2명     \n";
            sQuery += "                     FIN.SEM_ACCOUNT3_CODE,                                                  \n";
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                  \n";
            sQuery += "                     FIN.SEM_ACCOUNT4_CODE,                                                  \n";
            sQuery += "                     FIN.SEM_ACCOUNT4_DESC                                                   \n";
            sQuery += "              ) B                                                                            \n";
            sQuery += "        WHERE A.V_CODE2    = B.V_CODE2(+)                                                    \n";
            sQuery += "          AND A.V_CODE3    = B.V_CODE3(+)                                                    \n";
            sQuery += "          AND A.V_CODE4    = B.V_CODE4(+)                                                    \n";
            sQuery += "        GROUP BY                                                                             \n";
            sQuery += "              A.V_CODE2,                                                                     \n";
            sQuery += "              A.V_NAME2,                                                                     \n";
            sQuery += "              A.V_CODE3,                                                                     \n";
            sQuery += "              A.V_NAME3,                                                                     \n";
            sQuery += "              A.V_CODE4,                                                                     \n";
            sQuery += "              A.V_NAME4                                                                      \n";
            sQuery += "       )                                                                                     \n";
            sQuery += " WHERE 1=1       \n";
            
            if (sType == "인건비")
            {
                sQuery += "   AND V_ORDER   = 1 \n";
            }
            else if (sType == "복리후생비")
            {
                sQuery += "   AND V_ORDER   = 2 \n";
            }

            sQuery += " ORDER BY                                                                                    \n";
            sQuery += "       V_ORDER,                                                                              \n";
            sQuery += "       V_CODE2,                                                                              \n";
            sQuery += "       V_NAME2,                                                                              \n";
            sQuery += "       V_CODE3,                                                                              \n";
            sQuery += "       V_NAME3,                                                                              \n";
            sQuery += "       V_CODE4,                                                                              \n";
            sQuery += "       V_NAME4                                                                               \n";
            
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
                    if (asType == msaType[i, 0])
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

        /// <summary>
        /// GetLocationInfo
        ///     : 검색조건중 Location1, Location2 정보 추출(DropDownList에 추가위함.)
        /// </summary>
        /// <returns></returns>
        private DataSet GetLocationInfo(string asLevel)
        {
            string sQuery = "";

            sQuery += "SELECT ORG.SEM_ORG_OFFICE        v_Office,   -- 사업장 코드          \n";
            sQuery += "       ORG.SEM_ORG_LEVEL         v_Level,    -- 부문 Level           \n";
            sQuery += "       ORG.SEM_ORG_CODE3         v_Code3,    -- 부문 또는 팀 코드    \n";
            sQuery += "       ORG.SEM_ORG_CODE3_NAME    v_Name      -- 부문 또는 팀 명      \n";
            sQuery += "  FROM SEM_ORG_TABLE ORG                                     \n";

            if (asLevel == "부문")
                sQuery += " WHERE ORG.SEM_ORG_LEVEL = '1' AND ORG.SEM_DATE_T = '200704' AND SEM_ORG_PATH <> '99999'    \n";
            else if (asLevel == "팀")
                sQuery += " WHERE ORG.SEM_ORG_LEVEL = '2' AND ORG.SEM_DATE_T = '200704' AND SEM_ORG_PATH <> '99999'    \n";

            sQuery += " ORDER BY                                                            \n";
            sQuery += "       ORG.SEM_ORG_LEVEL,                                            \n";
            sQuery += "       ORG.SEM_ORG_PATH                                              \n";

            return gDbAgent.Fill(sQuery);
        }

        /// <summary>
        /// 인건비에 대한 code3 구분
        /// </summary>
        /// <returns></returns>
        private string[,] GetPayrollCode()
        {
            string sQuery = "";

            sQuery += "SELECT DISTINCT                          \n";
            sQuery += "       SEM_ACCOUNT3_CODE V_CODE3,        \n";
            sQuery += "       SEM_ACCOUNT3_DESC V_NAME3         \n";
            sQuery += "  FROM SEM_FINANCIAL_CODE_MASTER         \n";
            sQuery += " WHERE SEM_ACCOUNT2_CODE = '4009010000'  \n";
            sQuery += " ORDER BY                                \n";
            sQuery += "       V_CODE3                           \n";

            string sRet = "";
            DataSet ds = gDbAgent.Fill(sQuery);
            DataTable dt= null;

            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                for (int i=0; i<dt.Rows.Count; i++)
                {
                    sRet += dt.Rows[i]["V_CODE3"].ToString() + ";" + dt.Rows[i]["V_NAME3"].ToString() + ";";
                }
            }

            return GetSplit(sRet, 2);
        }
    #endregion


    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            GridBinding();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {
            int iIndex = 0;
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

            //e.Layout.Bands[0].Columns[0].CellStyle.BackColor = System.Drawing.Color.FromArgb(0x98, 0xc7, 0xd0); //#98c7d0, #b9dce3, #
            //e.Layout.Bands[0].Columns[1].CellStyle.BackColor = System.Drawing.Color.FromArgb(0xb9, 0xdc, 0xe3); //#98c7d0, #b9dce3, #

            e.Layout.Bands[0].Columns[0].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP1);
            e.Layout.Bands[0].Columns[1].CellStyle.BackColor = GetGridColor(gEN_GRID_COLOR.GROUP2);

            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
            {
                c.Header.RowLayoutColumnInfo.OriginY = 2;
                c.Header.Caption = msaHeader[iIndex];
                iIndex++;

            }

            
            ch = e.Layout.Bands[0].Columns[0].Header;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanY = 3;
            ch.RowLayoutColumnInfo.SpanX = 2;
            
            ch.Caption = "구분";

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "당 월";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 2;
            ch.RowLayoutColumnInfo.SpanX = 6;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "계획";
            ch.RowLayoutColumnInfo.OriginY = 1;
            ch.RowLayoutColumnInfo.OriginX = 2;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "실적";
            ch.RowLayoutColumnInfo.OriginY = 1;
            ch.RowLayoutColumnInfo.OriginX = 4;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "계획대비 실적";
            ch.RowLayoutColumnInfo.OriginY = 1;
            ch.RowLayoutColumnInfo.OriginX = 6;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "누 계";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 8;
            ch.RowLayoutColumnInfo.SpanX = 6;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "계획";
            ch.RowLayoutColumnInfo.OriginY = 1;
            ch.RowLayoutColumnInfo.OriginX = 8;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "실적";
            ch.RowLayoutColumnInfo.OriginY = 1;
            ch.RowLayoutColumnInfo.OriginX = 10;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "계획대비 실적";
            ch.RowLayoutColumnInfo.OriginY = 1;
            ch.RowLayoutColumnInfo.OriginX = 12;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);


            e.Layout.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].Columns[0].MergeCells = true;

            for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.##";

            }

        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            #region 서브토탈 및 총합계열에 대한 색깔변경
                string[,] saPayroll = GetPayrollCode();

                for (int i=0; i<=saPayroll.GetUpperBound(0); i++)
                {
                    if (
                        e.Row.Cells[1].Value.ToString() == saPayroll[i, 1]
                       )
                    {
                        e.Row.Cells[1].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME1);
                        for (int j = 2; j < UltraWebGrid1.Columns.Count; j++)
                        {
                            e.Row.Cells[j].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
                        }
                    }
                }

                
                if (e.Row.Cells[1].Value.ToString().IndexOf("총계") >= 0)
                {

                    e.Row.Cells[1].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME2);
                    for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
                    {
                        e.Row.Cells[i].Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA2);
                    }
                }
            #endregion

            #region 비율에 대한 값 %추가
                for (int i = 2; i < UltraWebGrid1.Columns.Count; i++)
                {
                    if (e.Row.Band.Columns[i].Header.Caption.IndexOf("비율") >= 0 ||
                        e.Row.Band.Columns[i].Header.Caption.IndexOf("집행율") >= 0 )
                    {
                        e.Row.Cells[i].Value = Math.Round(Convert.ToDouble(e.Row.Cells[i].Value), 1) + "%";
                    }
                }
            #endregion
        }
    #endregion
    
    
}

