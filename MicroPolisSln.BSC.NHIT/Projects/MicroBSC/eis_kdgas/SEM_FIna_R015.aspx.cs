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

public partial class SEM_FIna_R015 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            DateTime objDT = DateTime.Now;
            string strYY;
            string strMM;

            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.ddlTYear.Items.Clear();
            this.ddlTMonth.Items.Clear();

            for (intLP = 0; intLP < 13; intLP++)
            {
                if (intLP < 10)
                {
                    strMM = "0"+intLP.ToString();
                }
                else
                {
                    strMM = intLP.ToString();
                }

                this.ddlTMonth.Items.Add(new ListItem(strMM, strMM));
                if (intMM-1 == int.Parse(strMM))
                {
                    this.ddlTMonth.SelectedValue = strMM;
                }
            }

            for (iniYY = 2000; iniYY <= intYY+3; iniYY++)
            {
                strYY = iniYY.ToString();
                this.ddlTYear.Items.Add(new ListItem(strYY, strYY));
            }
            this.ddlTYear.SelectedValue = intYY.ToString();
        	
            SetDateDropDownList(ddlYear, ddlMonth);  

            SetAreaDropDownList(ddlArea);
            DataBindingObjects();
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        e.Row.Style.BackColor = Color.White;
        if(dr["SORT"].ToString().Equals("0"))
        {
            e.Row.Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_DATA1);
            e.Row.Cells.FromKey("T_2_NAME").Style.BackColor = GetGridColor(gEN_GRID_COLOR.SUBTOTAL_NAME1);
        }
    }
    private void GridBinding(string yearStr, string monthStr, string yearTStr, string monthTStr, string areaStr)
    {
        DataView dv = GetContentTable(yearStr, monthStr, yearTStr, monthTStr, areaStr).DefaultView;
        dv.Sort = "OBJECT_TYPE, SORT";

        UltraWebGrid1.DataSource = dv;
        UltraWebGrid1.DataBind();

        //DataGrid1.DataSource = dv;
        //DataGrid1.DataBind();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        string yearStr  = ddlYear.SelectedValue;
        string monthStr = ddlMonth.SelectedValue;
        string yearTStr = ddlTYear.SelectedValue;
        string monthTStr = ddlTMonth.SelectedValue;
        string areaStr  = ddlArea.SelectedValue;

        GridBinding(yearStr, monthStr, yearTStr, monthTStr, areaStr);
    }
    private DataTable GetHeaderTable(string yearStr, string monthStr, string yearTStr, string monthTStr, string areaStr) 
    {
        string query_p = GetGridHeaderQuery(Convert.ToString(int.Parse(yearStr) - 1), monthStr, Convert.ToString(int.Parse(yearTStr)-1), monthTStr, areaStr);
        string query_c = GetGridHeaderQuery(yearStr, monthStr, yearTStr, monthTStr, areaStr);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds_p = dbAgent.FillDataSet(query_p, "Data");
        DataSet ds_c = dbAgent.FillDataSet(query_c, "Data");

        DataTable dataTable = new DataTable();
        DataRow dr      = null;
        DataRowCollection drCol_p    = null;
        DataRowCollection drCol_c    = null;
        dataTable.Columns.Add("C_ACTUAL", typeof(double));
        dataTable.Columns.Add("C_PLAN", typeof(double));
        dataTable.Columns.Add("P_PAST_ACTUAL", typeof(double));
        dataTable.Columns.Add("P_PAST_COUNT", typeof(double));
        dataTable.Columns.Add("P_PAST_RATE", typeof(double));
        dataTable.Columns.Add("P_PLAN_COUNT", typeof(double));
        dataTable.Columns.Add("P_PLAN_RATE", typeof(double));

        drCol_c = ds_c.Tables[0].Rows;
        drCol_p = ds_p.Tables[0].Rows;

        dr = dataTable.NewRow();
        dr["C_ACTUAL"]      = 0;
        dr["C_PLAN"]        = 0;
        dr["P_PAST_ACTUAL"] = 0;
        dr["P_PAST_COUNT"]  = 0;
        dr["P_PAST_RATE"]   = 0;
        dr["P_PLAN_COUNT"]  = 0;
        dr["P_PLAN_RATE"]   = 0;
        dataTable.Rows.Add(dr);

        if (drCol_c.Count > 0)
        {
            dataTable.Rows[0]["C_ACTUAL"] = Convert.ToDouble(drCol_c[0]["ACTUAL"].ToString());
            dataTable.Rows[0]["C_PLAN"] = Convert.ToDouble(drCol_c[0]["PLAN"].ToString());
            dataTable.Rows[0]["P_PLAN_COUNT"] = Convert.ToDouble(drCol_c[0]["ACTUAL"].ToString()) - Convert.ToDouble(drCol_c[0]["PLAN"].ToString());
            dataTable.Rows[0]["P_PLAN_RATE"] = Math.Round(Convert.ToDouble(drCol_c[0]["ACTUAL"].ToString()) / Convert.ToDouble(drCol_c[0]["PLAN"].ToString()) * 100.00);
        }

        if (drCol_p.Count > 0 && drCol_c.Count > 0)
        {
            dataTable.Rows[0]["P_PAST_ACTUAL"] = Convert.ToDouble(drCol_p[0]["ACTUAL"].ToString());
            dataTable.Rows[0]["P_PAST_COUNT"] = Convert.ToDouble(drCol_c[0]["ACTUAL"].ToString()) - Convert.ToDouble(drCol_p[0]["ACTUAL"].ToString());
            dataTable.Rows[0]["P_PAST_RATE"] = Math.Round(Convert.ToDouble(drCol_c[0]["ACTUAL"].ToString()) / Convert.ToDouble(drCol_p[0]["ACTUAL"].ToString()) * 100.00);
        }

        return dataTable;
    }
    private DataTable GetContentTable(string yearStr, string monthStr, string yearTStr, string monthTStr, string areaStr)
    {
        string query_p          = GetGridContentQuery(Convert.ToString(int.Parse(yearStr) - 1), monthStr, Convert.ToString(int.Parse(yearTStr)-1), monthTStr,areaStr);
        string query_c          = GetGridContentQuery(yearStr, monthStr, yearTStr, monthTStr, areaStr);
        string query_p_profit   = GetGridTotalProfitQuery(Convert.ToString(int.Parse(yearStr) - 1), monthStr, Convert.ToString(int.Parse(yearTStr)-1), monthTStr,areaStr);
        string query_c_profit   = GetGridTotalProfitQuery(yearStr, monthStr, yearTStr, monthTStr,areaStr);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds_p        = dbAgent.FillDataSet(query_p, "Data");
        DataSet ds_c        = dbAgent.FillDataSet(query_c, "Data");
        DataSet ds_p_profit = dbAgent.FillDataSet(query_p_profit, "Data");
        DataSet ds_c_profit = dbAgent.FillDataSet(query_c_profit, "Data");
        DataTable dt_header = GetHeaderTable(yearStr, monthStr, yearTStr, monthTStr,areaStr);
        //DataSet ds_type = dbAgent.FillDataSet(query_type, "Data");

        double p_profit_plan    = 0;
        double p_profit_actual  = 0;
        double c_profit_plan    = 0;
        double c_profit_actual  = 0;

        if (ds_p_profit.Tables[0].Rows.Count > 0) 
        {
            p_profit_plan       = double.Parse(ds_p_profit.Tables[0].Rows[0]["PL_BUDGET_AMOUNT"].ToString());
            p_profit_actual     = double.Parse(ds_p_profit.Tables[0].Rows[0]["PL_ACTUAL_AMOUNT"].ToString());
        }
        if (ds_c_profit.Tables[0].Rows.Count > 0)
        {
            c_profit_plan       = double.Parse(ds_c_profit.Tables[0].Rows[0]["PL_BUDGET_AMOUNT"].ToString());
            c_profit_actual     = double.Parse(ds_c_profit.Tables[0].Rows[0]["PL_ACTUAL_AMOUNT"].ToString());
        }

        DataTable totalTable = new DataTable();
        DataTable dataTable = new DataTable();
        DataRow dr = null;
        DataRowCollection drCol_p = null;
        DataRowCollection drCol_c = null;
        dataTable.Columns.Add("T_1_CODE", typeof(string));
        dataTable.Columns.Add("T_2_CODE", typeof(string));
        dataTable.Columns.Add("T_1_NAME", typeof(string));
        dataTable.Columns.Add("T_2_NAME", typeof(string));
        dataTable.Columns.Add("ACTUAL_PRICE", typeof(double));
        dataTable.Columns.Add("ACTUAL_CONSIST", typeof(double));
        dataTable.Columns.Add("ACTUAL_UNIT", typeof(double));
        dataTable.Columns.Add("PLAN_PRICE", typeof(double));
        dataTable.Columns.Add("PLAN_CONSIST", typeof(double));
        dataTable.Columns.Add("PLAN_UNIT", typeof(double));
        dataTable.Columns.Add("P_ACTUAL_PRICE", typeof(double));
        dataTable.Columns.Add("P_ACTUAL_CONSIST", typeof(double));
        dataTable.Columns.Add("P_ACTUAL_UNIT", typeof(double));
        dataTable.Columns.Add("P_RATE_COUNT", typeof(double));
        dataTable.Columns.Add("P_RATE_PERCENT", typeof(double));
        dataTable.Columns.Add("PLAN_RATE_COUNT", typeof(double));
        dataTable.Columns.Add("PLAN_RATE_PERCENT", typeof(double));
        dataTable.Columns.Add("OBJECT_TYPE", typeof(int));
        dataTable.Columns.Add("SORT", typeof(int));
                
        drCol_c = ds_c.Tables[0].Rows;
        drCol_p = ds_p.Tables[0].Rows;

        for (int i = 0; i < ds_c.Tables[0].Rows.Count; i++) 
        {
            dr = dataTable.NewRow();
            dr["T_1_CODE"] = ds_c.Tables[0].Rows[i]["SEM_ACCOUNT1_CODE"].ToString();
            dr["T_2_CODE"] = ds_c.Tables[0].Rows[i]["SEM_ACCOUNT2_CODE"].ToString();
            dr["T_1_NAME"] = ds_c.Tables[0].Rows[i]["SEM_ACCOUNT1_DESC"].ToString();
            dr["T_2_NAME"] = ds_c.Tables[0].Rows[i]["SEM_ACCOUNT2_DESC"].ToString();
            dr["ACTUAL_PRICE"] = 0;
            dr["ACTUAL_CONSIST"] = 0;
            dr["ACTUAL_UNIT"] = 0;
            dr["PLAN_PRICE"] = 0;
            dr["PLAN_CONSIST"] = 0;
            dr["PLAN_UNIT"] = 0;
            dr["P_ACTUAL_PRICE"] = 0;
            dr["P_ACTUAL_CONSIST"] = 0;
            dr["P_ACTUAL_UNIT"] = 0;
            dr["P_RATE_COUNT"] = 0;
            dr["P_RATE_PERCENT"] = 0;
            dr["PLAN_RATE_COUNT"] = 0;
            dr["PLAN_RATE_PERCENT"] = 0;
            dr["OBJECT_TYPE"] = 0;
            dr["SORT"] = 0;
            dataTable.Rows.Add(dr);
        }

        DataRow[] drArr_c = null;
        DataRow[] drArr_p = null;

        for (int i = 0; i < ds_c.Tables[0].Rows.Count; i++)
        {
            drArr_c = ds_c.Tables[0].Select("SEM_ACCOUNT2_CODE = '" + ds_c.Tables[0].Rows[i]["SEM_ACCOUNT2_CODE"].ToString() + "'");
            drArr_p = ds_p.Tables[0].Select("SEM_ACCOUNT2_CODE = '" + ds_c.Tables[0].Rows[i]["SEM_ACCOUNT2_CODE"].ToString() + "'");

            if (drArr_c.Length > 0)
            {
                dataTable.Rows[i]["ACTUAL_PRICE"]       = double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString());
                dataTable.Rows[i]["ACTUAL_CONSIST"]     = (c_profit_actual == 0) ? 0 : double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString()) / c_profit_actual * 100.00;
                dataTable.Rows[i]["ACTUAL_UNIT"]        = (double.Parse(dt_header.Rows[0]["C_ACTUAL"].ToString()) == 0) ? 0 : double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString()) / double.Parse(dt_header.Rows[0]["C_ACTUAL"].ToString());
                dataTable.Rows[i]["PLAN_PRICE"]         = double.Parse(drArr_c[0]["PL_BUDGET_AMOUNT"].ToString());
                dataTable.Rows[i]["PLAN_CONSIST"]       = (c_profit_plan == 0) ? 0 : double.Parse(drArr_c[0]["PL_BUDGET_AMOUNT"].ToString()) / c_profit_plan * 100.00;
                dataTable.Rows[i]["PLAN_UNIT"]          = (double.Parse(dt_header.Rows[0]["C_PLAN"].ToString()) == 0) ? 0 : double.Parse(drArr_c[0]["PL_BUDGET_AMOUNT"].ToString()) / double.Parse(dt_header.Rows[0]["C_PLAN"].ToString()) ;
                dataTable.Rows[i]["PLAN_RATE_COUNT"]    = double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString()) - double.Parse(drArr_c[0]["PL_BUDGET_AMOUNT"].ToString());
                dataTable.Rows[i]["PLAN_RATE_PERCENT"]  = (double.Parse(drArr_c[0]["PL_BUDGET_AMOUNT"].ToString()) == 0) ? 0 : double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString()) / double.Parse(drArr_c[0]["PL_BUDGET_AMOUNT"].ToString()) * 100.00;

                if (drArr_c[0]["SEM_ACCOUNT1_CODE"].ToString().Equals("4003000000") || drArr_c[0]["SEM_ACCOUNT1_CODE"].ToString().Equals("4005000000")) 
                {
                    dataTable.Rows[i]["ACTUAL_CONSIST"] = 0;
                    dataTable.Rows[i]["PLAN_CONSIST"] = 0;   
                }
            }

            if (drArr_p.Length > 0)
            {
                dataTable.Rows[i]["P_ACTUAL_PRICE"]     = double.Parse(drArr_p[0]["PL_ACTUAL_AMOUNT"].ToString());
                dataTable.Rows[i]["P_ACTUAL_CONSIST"]   = (p_profit_actual == 0) ? 0 : double.Parse(drArr_p[0]["PL_ACTUAL_AMOUNT"].ToString()) / p_profit_actual * 100.00;
                dataTable.Rows[i]["P_ACTUAL_UNIT"]      = (double.Parse(dt_header.Rows[0]["P_PAST_ACTUAL"].ToString()) == 0) ? 0 : double.Parse(drArr_p[0]["PL_ACTUAL_AMOUNT"].ToString()) / double.Parse(dt_header.Rows[0]["P_PAST_ACTUAL"].ToString()) ;
                dataTable.Rows[i]["P_RATE_COUNT"]       = double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString()) - double.Parse(drArr_p[0]["PL_ACTUAL_AMOUNT"].ToString());
                dataTable.Rows[i]["P_RATE_PERCENT"]     = (double.Parse(drArr_p[0]["PL_ACTUAL_AMOUNT"].ToString()) == 0) ? 0 : double.Parse(drArr_c[0]["PL_ACTUAL_AMOUNT"].ToString()) / double.Parse(drArr_p[0]["PL_ACTUAL_AMOUNT"].ToString()) * 100.00;

                if (drArr_p[0]["SEM_ACCOUNT1_CODE"].ToString().Equals("4003000000") || drArr_p[0]["SEM_ACCOUNT1_CODE"].ToString().Equals("4005000000"))
                {
                    dataTable.Rows[i]["P_ACTUAL_CONSIST"] = 0;
                }
            }
        }

        totalTable.Merge(dataTable);
        totalTable.Rows.Clear();

        string tempCode = "";
        string tempName = "";
        int gidx = 1;
        int idx = 1;

        double actual_price     = 0;
        double actual_consist   = 0;
        double actual_unit      = 0;
        double plan_price       = 0;
        double plan_consist     = 0;
        double plan_unit        = 0;
        double p_actual_price   = 0;
        double p_actual_consist = 0;
        double p_actual_unit    = 0;
        double p_rate_count     = 0;
        double p_rate_percent   = 0;
        double plan_rate_count  = 0;
        double plan_rate_percent = 0;

        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            if (tempCode != dataTable.Rows[i]["T_1_CODE"].ToString() && tempCode != "")
            {                

                dr = totalTable.NewRow();
                dr["T_1_CODE"] = tempCode;
                dr["T_2_CODE"] = tempCode;
                dr["T_1_NAME"] = tempName;
                dr["T_2_NAME"] = tempName;
                dr["ACTUAL_PRICE"]      = actual_price;
                dr["ACTUAL_CONSIST"]    = actual_consist;
                dr["ACTUAL_UNIT"]       = actual_unit;
                dr["PLAN_PRICE"]        = plan_price;
                dr["PLAN_CONSIST"]      = plan_consist;
                dr["PLAN_UNIT"]         = plan_unit;
                dr["P_ACTUAL_PRICE"]    = p_actual_price;
                dr["P_ACTUAL_CONSIST"]  = p_actual_consist;
                dr["P_ACTUAL_UNIT"]     = p_actual_unit;
                dr["P_RATE_COUNT"]      = p_rate_count;
                dr["P_RATE_PERCENT"]    = p_rate_percent;
                dr["PLAN_RATE_COUNT"]   = plan_rate_count;
                dr["PLAN_RATE_PERCENT"] = plan_rate_percent;
            
                dr["OBJECT_TYPE"] = gidx;
                dr["SORT"] = 0;
                totalTable.Rows.Add(dr);
 
                //tempCode = "";
                //tempName = "";
                idx = 1;
                gidx++;
                actual_price        = 0;
                actual_consist      = 0;
                actual_unit         = 0;
                plan_price          = 0;
                plan_consist        = 0;
                plan_unit           = 0;
                p_actual_price      = 0;
                p_actual_consist    = 0;
                p_actual_unit       = 0;
                p_rate_count        = 0;
                p_rate_percent      = 0;
                plan_rate_count     = 0;
                plan_rate_percent   = 0;
            }

            if ( dataTable.Rows[i]["T_1_CODE"].ToString() == "4003000000" || 
                 dataTable.Rows[i]["T_1_CODE"].ToString() == "4005000000" ||
                 dataTable.Rows[i]["T_1_CODE"].ToString() == "4009000000" ||
                 dataTable.Rows[i]["T_1_CODE"].ToString() == "4013000000" ||
                 dataTable.Rows[i]["T_1_CODE"].ToString() == "4015000000"   )
            {
                dr = totalTable.NewRow();
                dr["T_1_CODE"] = dataTable.Rows[i]["T_1_CODE"].ToString();
                dr["T_2_CODE"] = dataTable.Rows[i]["T_2_CODE"].ToString();
                dr["T_1_NAME"] = dataTable.Rows[i]["T_1_NAME"].ToString();
                dr["T_2_NAME"] = dataTable.Rows[i]["T_2_NAME"].ToString();
                dr["ACTUAL_PRICE"]      = dataTable.Rows[i]["ACTUAL_PRICE"];
                dr["ACTUAL_CONSIST"]    = dataTable.Rows[i]["ACTUAL_CONSIST"];
                dr["ACTUAL_UNIT"]       = dataTable.Rows[i]["ACTUAL_UNIT"];
                dr["PLAN_PRICE"]        = dataTable.Rows[i]["PLAN_PRICE"];
                dr["PLAN_CONSIST"]      = dataTable.Rows[i]["PLAN_CONSIST"];
                dr["PLAN_UNIT"]         = dataTable.Rows[i]["PLAN_UNIT"];
                dr["P_ACTUAL_PRICE"]    = dataTable.Rows[i]["P_ACTUAL_PRICE"];
                dr["P_ACTUAL_CONSIST"]  = dataTable.Rows[i]["P_ACTUAL_CONSIST"];
                dr["P_ACTUAL_UNIT"]     = dataTable.Rows[i]["P_ACTUAL_UNIT"];
                dr["P_RATE_COUNT"]      = dataTable.Rows[i]["P_RATE_COUNT"];
                dr["P_RATE_PERCENT"]    = dataTable.Rows[i]["P_RATE_PERCENT"];
                dr["PLAN_RATE_COUNT"]   = dataTable.Rows[i]["PLAN_RATE_COUNT"];
                dr["PLAN_RATE_PERCENT"] = dataTable.Rows[i]["PLAN_RATE_PERCENT"];
                dr["OBJECT_TYPE"] = gidx;
                dr["SORT"] = idx.ToString();
                totalTable.Rows.Add(dr);
            }
            actual_price        += double.Parse(dataTable.Rows[i]["ACTUAL_PRICE"].ToString());
            actual_consist      += double.Parse(dataTable.Rows[i]["ACTUAL_CONSIST"].ToString());
            actual_unit         += double.Parse(dataTable.Rows[i]["ACTUAL_UNIT"].ToString());
            plan_price          += double.Parse(dataTable.Rows[i]["PLAN_PRICE"].ToString());
            plan_consist        += double.Parse(dataTable.Rows[i]["PLAN_CONSIST"].ToString());
            plan_unit           += double.Parse(dataTable.Rows[i]["PLAN_UNIT"].ToString());
            p_actual_price      += double.Parse(dataTable.Rows[i]["P_ACTUAL_PRICE"].ToString());
            p_actual_consist    += double.Parse(dataTable.Rows[i]["P_ACTUAL_CONSIST"].ToString());
            p_actual_unit       += double.Parse(dataTable.Rows[i]["P_ACTUAL_UNIT"].ToString());
            p_rate_count        += double.Parse(dataTable.Rows[i]["P_RATE_COUNT"].ToString());
            p_rate_percent      += double.Parse(dataTable.Rows[i]["P_RATE_PERCENT"].ToString());
            plan_rate_count     += double.Parse(dataTable.Rows[i]["PLAN_RATE_COUNT"].ToString());
            plan_rate_percent   += double.Parse(dataTable.Rows[i]["PLAN_RATE_PERCENT"].ToString());
            idx++;
            tempCode = dataTable.Rows[i]["T_1_CODE"].ToString();
            tempName = dataTable.Rows[i]["T_1_NAME"].ToString();

            // 마지막 라인을 추가하기 위해서
            if (i == dataTable.Rows.Count - 1) 
            {
                dr = totalTable.NewRow();
                dr["T_1_CODE"] = tempCode;
                dr["T_2_CODE"] = tempCode;
                dr["T_1_NAME"] = tempName;
                dr["T_2_NAME"] = tempName;
                dr["ACTUAL_PRICE"]      = actual_price;
                dr["ACTUAL_CONSIST"]    = actual_consist;
                dr["ACTUAL_UNIT"]       = actual_unit;
                dr["PLAN_PRICE"]        = plan_price;
                dr["PLAN_CONSIST"]      = plan_consist;
                dr["PLAN_UNIT"]         = plan_unit;
                dr["P_ACTUAL_PRICE"]    = p_actual_price;
                dr["P_ACTUAL_CONSIST"]  = p_actual_consist;
                dr["P_ACTUAL_UNIT"]     = p_actual_unit;
                dr["P_RATE_COUNT"]      = p_rate_count;
                dr["P_RATE_PERCENT"]    = p_rate_percent;
                dr["PLAN_RATE_COUNT"]   = plan_rate_count;
                dr["PLAN_RATE_PERCENT"] = plan_rate_percent;
                dr["OBJECT_TYPE"]       = gidx;
                dr["SORT"]              = 0;
                totalTable.Rows.Add(dr);
            }
        }

        return totalTable;
    }
    private string GetGridHeaderQuery(string yearStr, string monthStr, string yearTStr, string monthTStr, string areaStr)
    {
        string query = @"  SELECT ROUND(SUM(SM.SALE_QNT_PLAN)/1000000,1) PLAN, 
                                  ROUND(SUM(SM.SALE_QNT_ACTUAL)/1000000,1) ACTUAL 
                             FROM SEM_SALE_MONTHLY SM
                            WHERE SM.SALE_DATE_T BETWEEN '" + yearStr + monthStr + @"' AND '" + yearTStr + monthTStr + @"' 
                              AND (SM.SALE_OFFICE_T = '" + areaStr + @"' 
                               OR '--' = '" + areaStr + @"')";

        return query;
    }
    private string GetGridContentQuery(string yearStr, string monthStr, string yearTStr, string monthTStr,string areaStr)
    {
        string query = @"SELECT  DECODE(FIN.SEM_ACCOUNT1_CODE, '4001000000' ,'9999999999', FIN.SEM_ACCOUNT1_CODE) SEM_ACCOUNT1_CODE,
                            FIN.SEM_ACCOUNT2_CODE,
                            FIN.SEM_ACCOUNT1_DESC,
                            FIN.SEM_ACCOUNT2_DESC,
                            ROUND(SUM(PL.PL_BUDGET_AMOUNT)/1000000, 0) PL_BUDGET_AMOUNT,
                            ROUND(SUM(PL.PL_ACTUAL_AMOUNT)/1000000, 0) PL_ACTUAL_AMOUNT
                          FROM SEM_PROFIT_LOSS PL, (SELECT distinct 
                                                                   SEM_FINANCIAL_CODE,
                                                                   SEM_ACCOUNT1_CODE,
                                                                   SEM_ACCOUNT2_CODE,
                                                                   SEM_ACCOUNT3_CODE,
                                                                   SEM_ACCOUNT1_DESC,
                                                                   SEM_ACCOUNT2_DESC
                                                              FROM SEM_FINANCIAL_CODE_MASTER
                                                             WHERE SEM_FINANCIAL_CODE = 'PL') FIN
                       WHERE PL.PL_DATE_T BETWEEN '" + yearStr + monthStr + @"' AND '" + yearTStr + monthTStr + @"'
                            AND (PL.PL_OFFICE_T = '" + areaStr + @"' OR '--' = '" + areaStr + @"')
                            AND PL.PL_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE 
                            AND PL.PL_ACCOUNT3_CODE_T = FIN.SEM_ACCOUNT3_CODE
                            AND (PL.PL_BUDGET_AMOUNT <> 0 OR  PL.PL_ACTUAL_AMOUNT <> 0)
                       GROUP BY DECODE(FIN.SEM_ACCOUNT1_CODE, '4001000000' ,'9999999999', FIN.SEM_ACCOUNT1_CODE),
                                FIN.SEM_ACCOUNT2_CODE,
                                FIN.SEM_ACCOUNT1_DESC,
                                FIN.SEM_ACCOUNT2_DESC
                       ORDER BY 1,2";
        return query;
    }
    private string GetGridTotalProfitQuery(string yearStr, string monthStr, string yearTStr, string monthTStr, string areaStr)
    {
        string query = @"SELECT  DECODE(FIN.SEM_ACCOUNT1_CODE, '4001000000' ,'9999999999', FIN.SEM_ACCOUNT1_CODE) SEM_ACCOUNT1_CODE,
                            FIN.SEM_ACCOUNT2_CODE,
                            FIN.SEM_ACCOUNT1_DESC,
                            FIN.SEM_ACCOUNT2_DESC,
                            ROUND(NVL(SUM(PL.PL_BUDGET_AMOUNT),0)/1000000, 0) PL_BUDGET_AMOUNT,
                            ROUND(NVL(SUM(PL.PL_ACTUAL_AMOUNT),0)/1000000, 0) PL_ACTUAL_AMOUNT
                          FROM SEM_PROFIT_LOSS PL,(SELECT distinct 
                                                                   SEM_FINANCIAL_CODE,
                                                                   SEM_ACCOUNT1_CODE,
                                                                   SEM_ACCOUNT2_CODE,
                                                                   SEM_ACCOUNT3_CODE,
                                                                   SEM_ACCOUNT1_DESC,
                                                                   SEM_ACCOUNT2_DESC
                                                              FROM SEM_FINANCIAL_CODE_MASTER
                                                             WHERE SEM_FINANCIAL_CODE = 'PL') FIN
                       WHERE PL.PL_DATE_T BETWEEN '" + yearStr + monthStr + @"' AND '" + yearTStr + monthTStr + @"'
                            AND (PL.PL_OFFICE_T = '" + areaStr + @"' OR '--' = '" + areaStr + @"')
                            AND PL.PL_FINANCIAL_CODE_T = FIN.SEM_FINANCIAL_CODE 
                            AND PL.PL_ACCOUNT3_CODE_T = FIN.SEM_ACCOUNT3_CODE
                            AND (PL.PL_BUDGET_AMOUNT <> 0 OR  PL.PL_ACTUAL_AMOUNT <> 0)
                            AND SEM_ACCOUNT2_CODE = '4007000000'
                       GROUP BY DECODE(FIN.SEM_ACCOUNT1_CODE, '4001000000' ,'9999999999', FIN.SEM_ACCOUNT1_CODE),
                                FIN.SEM_ACCOUNT2_CODE,
                                FIN.SEM_ACCOUNT1_DESC,
                                FIN.SEM_ACCOUNT2_DESC
                       ORDER BY 1,2";
        return query;
    }




    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();

        string yearStr = ddlYear.SelectedValue;
        string monthStr = ddlMonth.SelectedValue;
        string yearTStr = ddlTYear.SelectedValue;  
        string monthTStr = ddlTMonth.SelectedValue;
        string areaStr = ddlArea.SelectedValue;

        DataTable dt = GetHeaderTable(yearStr, monthStr, yearTStr, monthTStr, areaStr);

        int iIndex = 0;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }


        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = null;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = "매출량";
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        //ch.RowLayoutColumnInfo.SpanY = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["C_ACTUAL"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["C_PLAN"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["P_PAST_ACTUAL"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["P_PAST_COUNT"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["P_PAST_RATE"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 11;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["P_PLAN_COUNT"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 12;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = double.Parse(dt.Rows[0]["P_PLAN_RATE"].ToString()).ToString("#,##0.#");
        ch.RowLayoutColumnInfo.OriginY = 2;
        ch.RowLayoutColumnInfo.OriginX = 13;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = ddlYear.SelectedValue + "년" + ddlMonth.SelectedValue + "월~" +ddlTMonth.SelectedValue +"월 실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = ddlYear.SelectedValue + "년 " + ddlMonth.SelectedValue + "월~" +ddlTMonth.SelectedValue +"월 계획";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = "전년동기간 실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = "전년대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Reset();
        ch.Caption = "계획대비";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 12;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.HorizontalAlign = HorizontalAlign.Center;
        e.Layout.Bands[0].HeaderLayout.Add(ch);

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch = e.Layout.Bands[0].Columns.FromKey("T_2_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;
    }
}
