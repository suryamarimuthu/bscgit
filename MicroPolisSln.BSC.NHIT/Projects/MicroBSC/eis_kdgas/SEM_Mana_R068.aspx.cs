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

public partial class eis_SEM_Mana_R068 : EISPageBase
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
            DateTime objDT = DateTime.Now;
            string strYY;
            string strMM;
            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.cboFYY.Items.Clear();
            this.cboTYY.Items.Clear();

            for (intLP = 1; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    strMM = "0" + intLP.ToString();
                }
                else
                {
                    strMM = intLP.ToString();
                }

                this.cboFMM.Items.Add(new ListItem(strMM, strMM));
                this.cboTMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM - 1 == int.Parse(strMM))
                {
                    this.cboFMM.SelectedValue = "01";
                    this.cboTMM.SelectedValue = strMM;
                }

            }

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboFYY.Items.Add(new ListItem(strYY, strYY));
                this.cboTYY.Items.Add(new ListItem(strYY, strYY));
            }
            cboFYY.SelectedValue = intYY.ToString();
            cboTYY.SelectedValue = intYY.ToString();
            /// </summary>

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboCom.SelectedIndex = 0;


        }

        private void InitControlEvent()
        {

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
            DataTable dataTable = new DataTable();
            DataRow     drTable = null;
            DataTable   dtDefault = null;
            DataSet     dsDefault = gDbAgent.Fill(GetDefaultQuery());

            double dbl_v01 = 0.00;
            double dbl_v02 = 0.00;
            double dbl_v03 = 0.00;
            double dbl_v04 = 0.00;
            double dbl_v05 = 0.00;
            double dbl_v06 = 0.00;
            double dbl_v07 = 0.00;
            double dbl_v08 = 0.00;


            if (dsDefault.Tables.Count > 0)
            {
                dtDefault = dsDefault.Tables[0];

                dataTable.Columns.Add("종류",   typeof(string));
                dataTable.Columns.Add("구분",   typeof(string));
                dataTable.Columns.Add("계획",   typeof(double));
                dataTable.Columns.Add("실적",   typeof(double));
                dataTable.Columns.Add("집행율(%)", typeof(double));
                //dataTable.Columns.Add("점유율", typeof(double));
                dataTable.Columns.Add("년간계획",   typeof(double));
                dataTable.Columns.Add("년간집행율", typeof(double));
                dataTable.Columns.Add("전년실적",   typeof(double));
                dataTable.Columns.Add("전년증감",   typeof(double));
                dataTable.Columns.Add("증가율(%)", typeof(double));

                for (int i=0; i<dtDefault.Rows.Count; i++)
                {
                    drTable = dataTable.NewRow();

                    drTable["종류"]       = dtDefault.Rows[i]["SEM_ACCOUNT3_DESC"].ToString();
                    drTable["구분"]       = dtDefault.Rows[i]["SEM_ACCOUNT4_DESC"].ToString();
                    drTable["계획"]       = Convert.ToDouble( dtDefault.Rows[i]["V_PLAN"]);
                    drTable["실적"]       = Convert.ToDouble( dtDefault.Rows[i]["V_ACTUAL"]);
                    drTable["집행율(%)"]     = Convert.ToDouble(dtDefault.Rows[i]["V_RATE"]);
                    //drTable["점유율"]   = Convert.ToDouble(dtDefault.Rows[i]["V_TOTALSHARE"]);
                    drTable["년간계획"]   = Convert.ToDouble(dtDefault.Rows[i]["V_YEARPLAN"]);
                    drTable["년간집행율"] = Convert.ToDouble(dtDefault.Rows[i]["V_YEARRATE"]);
                    drTable["전년실적"]   = Convert.ToDouble(dtDefault.Rows[i]["V_PREYEARACTUAL"]);
                    drTable["전년증감"]   = Convert.ToDouble(dtDefault.Rows[i]["V_UPDOWN"]);
                    drTable["증가율(%)"] = Convert.ToDouble(dtDefault.Rows[i]["V_UPDOWNRATE"]);

                    if (dtDefault.Rows[i]["SEM_ACCOUNT4_DESC"].ToString() == "소계")
                    {
                        dbl_v01 += Convert.ToDouble(dtDefault.Rows[i]["V_PLAN"]);
                        dbl_v02 += Convert.ToDouble(dtDefault.Rows[i]["V_ACTUAL"]);
                        dbl_v03 += Convert.ToDouble(dtDefault.Rows[i]["V_RATE"]);
                        dbl_v04 += Convert.ToDouble(dtDefault.Rows[i]["V_YEARPLAN"]);
                        dbl_v05 += Convert.ToDouble(dtDefault.Rows[i]["V_YEARRATE"]);
                        dbl_v06 += Convert.ToDouble(dtDefault.Rows[i]["V_PREYEARACTUAL"]);
                        dbl_v07 += Convert.ToDouble(dtDefault.Rows[i]["V_UPDOWN"]);
                        dbl_v08 += Convert.ToDouble(dtDefault.Rows[i]["V_UPDOWNRATE"]);
                    }

                    dataTable.Rows.Add(drTable);
                }

                drTable = dataTable.NewRow();
                drTable["종류"]       = "";
                drTable["구분"]       = "합계";
                drTable["계획"]       = dbl_v01;
                drTable["실적"]       = dbl_v02;
                drTable["집행율(%)"]     = (dbl_v01 == 0) ? 0 : Math.Round((dbl_v02/dbl_v01)*100,2);
                drTable["년간계획"]   = dbl_v04;
                drTable["년간집행율"] = (dbl_v04 == 0) ? 0 : Math.Round((dbl_v02 / dbl_v04)*100, 2);
                drTable["전년실적"]   = dbl_v06;
                drTable["전년증감"]   = (dbl_v02 - dbl_v06);
                drTable["증가율(%)"] = (dbl_v02 == 0) ? 0 : Math.Round(((dbl_v02 - dbl_v06) / dbl_v02) * 100,2);
                dataTable.Rows.Add(drTable);

            }

            return dataTable;
        }

        private string GetDefaultQuery()
        {
            int i;

            //string sLocation = GetByValueDropDownList(ddlLocation);

           string strFYY = this.cboFYY.SelectedValue;
           string strFMM = this.cboFMM.SelectedValue;
           string strTYY = this.cboTYY.SelectedValue;
           string strTMM = this.cboTMM.SelectedValue;
           string strCom = this.cboCom.SelectedValue;
           int intPYY = Convert.ToInt32(strFYY) - 1;
           string strPYY = intPYY.ToString();  
           string strAMM = "12";   
                                                                                    
            string sQuery = "";                                                     
                                                                        
            sQuery += "SELECT                                                                                                  \n";                                                                                                                                                                                                                  
            sQuery += "       SEM_ACCOUNT3_CODE,                                                                               \n";                                                                                                                                                                                                                  
            sQuery += "       SEM_ACCOUNT3_DESC,                                                                               \n";                                                                                                                                                                                                                  
            sQuery += "       CAPEX_ACCOUNT4_CODE_T,                                                                           \n";                                                                                                                                                                                                                  
            sQuery += "       SEM_ACCOUNT4_DESC,                                                                               \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(V_PLAN) V_PLAN,                                                                          \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(ROUND(V_ACTUAL,0)) V_ACTUAL,                                                                      \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(V_RATE) V_RATE,                                                                          \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(DECODE(V_TOTALSHARE, 0, 0, V_ACTUAL / V_TOTALSHARE * 100)) V_TOTALSHARE,                 \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(V_YEARPLAN) V_YEARPLAN,                                                                  \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(DECODE(V_YEARPLAN, 0, 0, V_ACTUAL / V_YEARPLAN * 100)) V_YEARRATE,                       \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(ROUND(V_PREYEARACTUAL,0)) V_PREYEARACTUAL,                                                        \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(ROUND((V_ACTUAL - V_PREYEARACTUAL),0)) V_UPDOWN,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "       TO_CHAR(DECODE(V_PREYEARACTUAL, 0, 0,(V_ACTUAL / V_PREYEARACTUAL) - 1)*100) V_UPDOWNRATE             \n";                                                                                                                                                                                                                  
            sQuery += "  FROM (SELECT SEM_ACCOUNT3_CODE,                                                                       \n";                                                                                                                                                                                                                  
            sQuery += "               SEM_ACCOUNT3_DESC,                                                                       \n";                                                                                                                                                                                                                  
            sQuery += "               CAPEX_ACCOUNT4_CODE_T,                                                                   \n";                                                                                                                                                                                                                  
            sQuery += "               SEM_ACCOUNT4_DESC,                                                                       \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_PLAN         )/1000 V_PLAN      ,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_ACTUAL       )/1000 V_ACTUAL    ,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_RATE         ) V_RATE           ,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_TOTALSHARE   ) V_TOTALSHARE     ,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_YEARPLAN     )/1000 V_YEARPLAN  ,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_YEARRATE     ) V_YEARRATE       ,                                                  \n";                                                                                                                                                                                                                  
            sQuery += "               SUM(V_PREYEARACTUAL)/1000 V_PREYEARACTUAL                                                \n";                                                                                                                                                                                                                  
            sQuery += "         FROM ( SELECT FIN.SEM_ACCOUNT3_CODE,                                                           \n";                                                                                                                                                                                                                  
            sQuery += "                       FIN.SEM_ACCOUNT3_DESC,                                                           \n";                                                                                                                                                                                                                  
            sQuery += "                       CE.CAPEX_ACCOUNT4_CODE_T,                                                        \n";                                                                                                                                                                                                                  
            sQuery += "                       FIN.SEM_ACCOUNT4_DESC,                                                           \n";                                                                                                                                                                                                                  
            sQuery += "                       SUM(CE.CAPEX_PLAN_AMT) v_Plan,                                                   \n";                                                                                                                                                                                                                  
            sQuery += "                       SUM(CE.CAPEX_ACTUAL_AMT) v_Actual,                                               \n";                                                                                                                                                                                                                  
            sQuery += "                       0 v_TOTALSHARE,                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                       DECODE(SUM(CE.CAPEX_PLAN_AMT), 0, 0,                                             \n";
            sQuery += "                              SUM(CE.CAPEX_ACTUAL_AMT) / SUM(CE.CAPEX_PLAN_AMT) * 100) v_Rate,          \n";                                                                                                                                                                                  
            sQuery += "                       0 v_YearPlan,                                                                    \n";                                                                                                                                                                                                                
            sQuery += "                       0 v_YearRate,                                                                    \n";                                                                                                                                                                                                                
            sQuery += "                       0 v_PreYearActual                                                                \n";                                                                                                                                                                                                                
            sQuery += "                  FROM SEM_CAPEX_EXECUTE CE,                                                    \n";                                                                                                                                                                                                                
            sQuery += "                       SEM_FINANCIAL_CODE_MASTER FIN                                            \n";                                                                                                                                                                                                                
            sQuery += "                 WHERE CE.CAPEX_DATE_T BETWEEN  '" + (strFYY + strFMM) + "' AND '" + (strTYY + strTMM) + "' \n";                                                                                                                                                   
            sQuery += "                   AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                    \n";                                                                                                                                                                                                                
            sQuery += "                   AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                             \n";                                                                                                                                                                                                                
            sQuery += "                   AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                 \n";  
            sQuery += "                   AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                    \n";                                                                                                                                                                                                             
            sQuery += "                 GROUP BY FIN.SEM_ACCOUNT3_CODE,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                          FIN.SEM_ACCOUNT3_DESC,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                          CE.CAPEX_ACCOUNT4_CODE_T,                                                     \n";                                                                                                                                                                                                                
            sQuery += "                          FIN.SEM_ACCOUNT4_DESC                                                         \n";   
            sQuery += "                UNION ALL                                                                               \n";
            sQuery += "               SELECT FIN.SEM_ACCOUNT3_CODE,                                                            \n";                                                                                                                                                                                                                  
            sQuery += "                       FIN.SEM_ACCOUNT3_DESC,                                                           \n";                                                                                                                                                                                                                  
            sQuery += "                       '9999999999' as ACCOUNT4_CODE_T,                                                 \n";                                                                                                                                                                                                                  
            sQuery += "                       '소계' as ACCOUNT4_DESC,                                                       \n";                                                                                                                                                                                                                  
            sQuery += "                       SUM(CE.CAPEX_PLAN_AMT) v_Plan,                                                   \n";                                                                                                                                                                                                                  
            sQuery += "                       SUM(CE.CAPEX_ACTUAL_AMT) v_Actual,                                               \n";                                                                                                                                                                                                                  
            sQuery += "                       0 v_TOTALSHARE,                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                       DECODE(SUM(CE.CAPEX_PLAN_AMT), 0, 0,                                             \n";
            sQuery += "                              SUM(CE.CAPEX_ACTUAL_AMT) / SUM(CE.CAPEX_PLAN_AMT) * 100) v_Rate,          \n";                                                                                                                                                                                  
            sQuery += "                       0 v_YearPlan,                                                                    \n";                                                                                                                                                                                                                
            sQuery += "                       0 v_YearRate,                                                                    \n";                                                                                                                                                                                                                
            sQuery += "                       0 v_PreYearActual                                                                \n";                                                                                                                                                                                                                
            sQuery += "                  FROM SEM_CAPEX_EXECUTE CE,                                                    \n";                                                                                                                                                                                                                
            sQuery += "                       SEM_FINANCIAL_CODE_MASTER FIN                                            \n";                                                                                                                                                                                                                
            sQuery += "                 WHERE CE.CAPEX_DATE_T BETWEEN  '" + (strFYY + strFMM) + "' AND '" + (strTYY + strTMM) + "' \n";                                                                                                                                                   
            sQuery += "                   AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                    \n";                                                                                                                                                                                                                
            sQuery += "                   AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                             \n";                                                                                                                                                                                                                
            sQuery += "                   AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                 \n";  
            sQuery += "                   AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                    \n";                                                                                                                                                                                                             
            sQuery += "                 GROUP BY FIN.SEM_ACCOUNT3_CODE,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                          FIN.SEM_ACCOUNT3_DESC                                                         \n";                                                                                                                                                                                                                
            sQuery += "              UNION ALL                                                                                 \n";                                                                                                                                                                                                                
            sQuery += "              SELECT b.sem_account3_code,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     b.sem_account3_desc,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     b.capex_account4_code_t,                                                           \n";                                                                                                                                                                                                                
            sQuery += "                     b.sem_account4_desc,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Plan,                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Actual,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     NVL(a.v_Actual, 0) v_TOTALSHARE,                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Rate,                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearPlan,                                                                      \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearRate,                                                                      \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_PreYearActual                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                FROM (SELECT FIN.SEM_ACCOUNT3_CODE,                                                     \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_DESC,                                                     \n";                                                                                                                                                                                                                
            sQuery += "                             CE.CAPEX_ACCOUNT4_CODE_T,                                                  \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT4_DESC,                                                     \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_Plan,                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                             SUM(CE.CAPEX_ACTUAL_AMT) v_Actual,                                         \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_Rate,                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_YearPlan,                                                              \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_YearRate,                                                              \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_PreYearActual                                                          \n";                                                                                                                                                                                                                
            sQuery += "                        FROM SEM_CAPEX_EXECUTE CE,                                              \n";                                                                                                                                                                                                                
            sQuery += "                             SEM_FINANCIAL_CODE_MASTER FIN                                      \n";                                                                                                                                                                                                                
            sQuery += "                       WHERE CE.CAPEX_DATE_T BETWEEN '" + (strFYY + strFMM) + "' AND '" + (strTYY + strTMM) + "' \n";                                                                                                                                              
            sQuery += "                         AND FIN.SEM_FINANCIAL_CODE = 'BS'                                               \n";                                                                                                                                                                                                                
            sQuery += "                         AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                        \n";                                                                                                                                                                                                                
            sQuery += "                         AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                            \n";  
            sQuery += "                         AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                               \n";                                                                                                                                                                                                                
            sQuery += "                       GROUP BY                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_CODE,                                                      \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_DESC,                                                      \n";                                                                                                                                                                                                                
            sQuery += "                             CE.CAPEX_ACCOUNT4_CODE_T,                                                   \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT4_DESC                                                       \n";
            sQuery += "                       UNION ALL                                                                         \n";
            sQuery += "                      SELECT FIN.SEM_ACCOUNT3_CODE,                                                     \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_DESC,                                                     \n";                                                                                                                                                                                                                
            sQuery += "                             '9999999999' as ACCOUNT4_CODE_T,                                           \n";                                                                                                                                                                                                                  
            sQuery += "                             '소계' as ACCOUNT4_DESC,                                                 \n";                                                                                                                                                                                                             
            sQuery += "                             0 v_Plan,                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                             SUM(CE.CAPEX_ACTUAL_AMT) v_Actual,                                         \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_Rate,                                                                  \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_YearPlan,                                                              \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_YearRate,                                                              \n";                                                                                                                                                                                                                
            sQuery += "                             0 v_PreYearActual                                                          \n";                                                                                                                                                                                                                
            sQuery += "                        FROM SEM_CAPEX_EXECUTE CE,                                              \n";                                                                                                                                                                                                                
            sQuery += "                             SEM_FINANCIAL_CODE_MASTER FIN                                      \n";                                                                                                                                                                                                                
            sQuery += "                       WHERE CE.CAPEX_DATE_T BETWEEN '" + (strFYY + strFMM) + "' AND '" + (strTYY + strTMM) + "' \n";                                                                                                                                              
            sQuery += "                         AND FIN.SEM_FINANCIAL_CODE = 'BS'                                               \n";                                                                                                                                                                                                                
            sQuery += "                         AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                        \n";                                                                                                                                                                                                                
            sQuery += "                         AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                            \n";  
            sQuery += "                         AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                               \n";                                                                                                                                                                                                                
            sQuery += "                       GROUP BY                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_CODE,                                                      \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_DESC) a,                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     (SELECT FIN.SEM_ACCOUNT3_CODE,                                                      \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT3_DESC,                                                      \n";                                                                                                                                                                                                                
            sQuery += "                             CE.CAPEX_ACCOUNT4_CODE_T,                                                   \n";                                                                                                                                                                                                                
            sQuery += "                             FIN.SEM_ACCOUNT4_DESC                                                       \n";                                                                                                                                                                                                                
            sQuery += "                        FROM SEM_CAPEX_EXECUTE CE,                                               \n";                                                                                                                                                                                                                
            sQuery += "                             SEM_FINANCIAL_CODE_MASTER FIN                                       \n";                                                                                                                                                                                                                
            sQuery += "                       WHERE CE.CAPEX_DATE_T BETWEEN '" + (strFYY + strFMM) + "' AND '" + (strTYY + strTMM) + "' \n";                                                                                                                                              
            sQuery += "                         AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                \n";                                                                                                                                                                                                                
            sQuery += "                         AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                         \n";                                                                                                                                                                                                                
            sQuery += "                         AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                             \n";  
            sQuery += "                         AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                \n";                                                                                                                                                                                                                
            sQuery += "                       GROUP BY FIN.SEM_ACCOUNT3_CODE,                                                    \n";                                                                                                                                                                                                                
            sQuery += "                                FIN.SEM_ACCOUNT3_DESC,                                                    \n";                                                                                                                                                                                                                
            sQuery += "                                CE.CAPEX_ACCOUNT4_CODE_T,                                                 \n";                                                                                                                                                                                                                
            sQuery += "                                FIN.SEM_ACCOUNT4_DESC) b                                                  \n";                                                                                                                                                                                                                
            sQuery += "               WHERE a.sem_account3_code(+) = b.sem_account3_code                                         \n";                                                                                                                                                                                                                
            sQuery += "                 AND a.sem_account3_desc(+) = b.sem_account3_desc                                         \n";                                                                                                                                                                                                                
            sQuery += "               UNION ALL                                                                                  \n";                                                                                                                                                                                                                
            sQuery += "              SELECT FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     CE.CAPEX_ACCOUNT4_CODE_T,                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT4_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     0  v_Plan,                                                                           \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Actual,                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_TOTALSHARE,                                                                      \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Rate, --집행율                                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     SUM(CE.CAPEX_PLAN_AMT) v_YearPlan,                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearRate,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_PreYearActual                                                                    \n";                                                                                                                                                                                                                
            sQuery += "                FROM SEM_CAPEX_EXECUTE CE,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     SEM_FINANCIAL_CODE_MASTER FIN                                                \n";                                                                                                                                                                                                                 
            sQuery += "               WHERE CE.CAPEX_DATE_T BETWEEN '" + (strFYY + "01") + "' AND '" + (strTYY + "12") + "'      \n";                                                                                                                                            
            sQuery += "                 AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                        \n";                                                                                                                                                                                                                
            sQuery += "                 AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                                 \n";                                                                                                                                                                                                                
            sQuery += "                 AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                     \n"; 
            sQuery += "                 AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                        \n";                                                                                                                                                                                                                 
            sQuery += "               GROUP BY                                                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     CE.CAPEX_ACCOUNT4_CODE_T,                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT4_DESC                                                                \n";                                                                                                                                                                                                                
            sQuery += "              UNION ALL                                                                                   \n";   
            sQuery += "              SELECT FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     '9999999999' as ACCOUNT4_CODE_T,                                                     \n";                                                                                                                                                                                                                  
            sQuery += "                     '소계' as ACCOUNT4_DESC,                                                           \n";                                                                                                                                                                                                                 
            sQuery += "                     0  v_Plan,                                                                           \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Actual,                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_TOTALSHARE,                                                                      \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Rate, --집행율                                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     SUM(CE.CAPEX_PLAN_AMT) v_YearPlan,                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearRate,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_PreYearActual                                                                    \n";                                                                                                                                                                                                                
            sQuery += "                FROM SEM_CAPEX_EXECUTE CE,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     SEM_FINANCIAL_CODE_MASTER FIN                                                \n";                                                                                                                                                                                                                 
            sQuery += "               WHERE CE.CAPEX_DATE_T BETWEEN '" + (strFYY + "01") + "' AND '" + (strTYY + "12") + "'      \n";                                                                                                                                            
            sQuery += "                 AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                        \n";                                                                                                                                                                                                                
            sQuery += "                 AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                                 \n";                                                                                                                                                                                                                
            sQuery += "                 AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                     \n"; 
            sQuery += "                 AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                        \n";                                                                                                                                                                                                                 
            sQuery += "               GROUP BY                                                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC                                                               \n";                                                                                                                                                                                                                
            sQuery += "              UNION ALL                                                                                   \n";                                                                                                                                                                                                             
            sQuery += "              SELECT FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     CE.CAPEX_ACCOUNT4_CODE_T,                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT4_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Plan,                                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Actual,                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_TOTALSHARE,                                                                      \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Rate,                                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearPlan,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearRate,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     SUM(CE.CAPEX_ACTUAL_AMT) v_PreYearActual                                             \n";                                                                                                                                                                                                                
            sQuery += "                FROM SEM_CAPEX_EXECUTE CE,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     SEM_FINANCIAL_CODE_MASTER FIN                                                \n";                                                                                                                                                                                                                
            sQuery += "               WHERE CE.CAPEX_DATE_T BETWEEN '" + (strPYY + strFMM) + "' AND '" + (strPYY + strTMM) + "'  \n";                                                         
            sQuery += "                 AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                        \n";                                                                                                                                                                                                                
            sQuery += "                 AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                                 \n";                                                                                                                                                                                                                
            sQuery += "                 AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                     \n"; 
            sQuery += "                 AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                        \n";                                                                                                                                                                                                                 
            sQuery += "               GROUP BY                                                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     CE.CAPEX_ACCOUNT4_CODE_T,                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT4_DESC                                                                \n";
            sQuery += "              UNION ALL                                                                                   \n";                                                                                                                                                                                                             
            sQuery += "              SELECT FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     '9999999999' as ACCOUNT4_CODE_T,                                                     \n";                                                                                                                                                                                                                  
            sQuery += "                     '소계' as ACCOUNT4_DESC,                                                           \n";                                                                                                                                                                                                              
            sQuery += "                     0 v_Plan,                                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Actual,                                                                          \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_TOTALSHARE,                                                                      \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_Rate,                                                                            \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearPlan,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     0 v_YearRate,                                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     SUM(CE.CAPEX_ACTUAL_AMT) v_PreYearActual                                             \n";                                                                                                                                                                                                                
            sQuery += "                FROM SEM_CAPEX_EXECUTE CE,                                                        \n";                                                                                                                                                                                                                
            sQuery += "                     SEM_FINANCIAL_CODE_MASTER FIN                                                \n";                                                                                                                                                                                                                
            sQuery += "               WHERE CE.CAPEX_DATE_T BETWEEN '" + (strPYY + strFMM) + "' AND '" + (strPYY + strTMM) + "'  \n";                                                         
            sQuery += "                 AND FIN.SEM_FINANCIAL_CODE = 'BS'                                                        \n";                                                                                                                                                                                                                
            sQuery += "                 AND FIN.SEM_ACCOUNT3_CODE IN ('1303000000','1305000000')                                 \n";                                                                                                                                                                                                                
            sQuery += "                 AND CE.CAPEX_ACCOUNT4_CODE_T = FIN.SEM_ACCOUNT4_CODE                                     \n"; 
            sQuery += "                 AND CE.CAPEX_OFFICE_T    like '"+ strCom +"'||'%'                                        \n";                                                                                                                                                                                                                 
            sQuery += "               GROUP BY                                                                                   \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_CODE,                                                               \n";                                                                                                                                                                                                                
            sQuery += "                     FIN.SEM_ACCOUNT3_DESC )                                                              \n";                                                                                                                                                                                                                
            sQuery += "  GROUP BY SEM_ACCOUNT3_CODE,                                                                             \n";                                                                                                                                                                                                                
            sQuery += "           SEM_ACCOUNT3_DESC,                                                                             \n";                                                                                                                                                                                                                
            sQuery += "           CAPEX_ACCOUNT4_CODE_T,                                                                         \n";                                                                                                                                                                                                                
            sQuery += "           SEM_ACCOUNT4_DESC)                                                                             \n";                                                                                                                                                                                                                

            return sQuery;
        }


    #endregion

        #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            GridBinding();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {


            e.Layout.Bands[0].HeaderLayout.Reset();

            //int iYear = Convert.ToInt32(GetByValueDropDownList(ddlYear));
            //string sMonth = GetByValueDropDownList(ddlMonth);

            //string[] saMonthCurr = GetMonthTerm(iYear, sMonth);  // 조회기간
            string sYear = this.cboFYY.SelectedValue;
            string sFMonth = this.cboFMM.SelectedValue;
            string sTMonth = this.cboTMM.SelectedValue;


            int iIndex = 0;
            Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
            {
                c.Header.RowLayoutColumnInfo.OriginY = 1;

                iIndex++;
            }

            

            ch = e.Layout.Bands[0].Columns[0].Header;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanY = 2;

            ch = e.Layout.Bands[0].Columns[1].Header;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 1;
            ch.RowLayoutColumnInfo.SpanY = 2;


            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            
            ch.Caption = string.Format("{0}년({1}월~{2}월)", sYear, sFMonth, sTMonth);
                                                        
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 2;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "년간";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 5;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "전년동기간 대비";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 7;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.Height = Unit.Pixel(22);
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            e.Layout.Bands[0].Columns[0].MergeCells = true;

            for (int i=2; i<UltraWebGrid1.Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Layout.Bands[0].Columns[i].Format = "#,##0.##";
                
            }

            //e.Layout.Bands[0].Columns[5].Hidden = true;

        }
        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {
            for (int i=2; i<UltraWebGrid1.Columns.Count; i++)
            {
                e.Row.Cells[i].Value = Math.Round(Convert.ToDouble(e.Row.Cells[i].Value), 2);
            }
        }
    #endregion
}
