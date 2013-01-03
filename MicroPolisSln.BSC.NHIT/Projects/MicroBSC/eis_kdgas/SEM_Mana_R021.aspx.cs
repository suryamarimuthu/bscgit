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

public partial class eis_SEM_Mana_R021 : System.Web.UI.Page
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        this._initForm(Page.IsPostBack);
        this._queryGrid();
    }

    private void _initForm(bool blnGbn)
    {
        /// <summary>
        /// 폼초기화 및 기본값 세팅
        /// 
        if (!blnGbn)
        {
            DateTime objDT = DateTime.Now;
            string strYY;
            string strMM;
            int intLP;
            int iniYY;

            int intYY = objDT.Year;
            int intMM = objDT.Month;

            this.cboYY.Items.Clear();
            this.cboMM.Items.Clear();
            this.cboCom.Items.Clear();

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

                this.cboMM.Items.Add(new ListItem(strMM, strMM));
                if (intMM - 1 == intLP)
                {
                    this.cboMM.SelectedValue = strMM;
                }

            }

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }
            this.cboYY.SelectedIndex = cboYY.Items.Count - 1;

            this.cboCom.Items.Add(new ListItem("전체", ""));
            this.cboCom.Items.Add(new ListItem("울산", "01"));
            this.cboCom.Items.Add(new ListItem("양산", "02"));
            this.cboCom.SelectedIndex = 0;

            this.cboGbn.Items.Add(new ListItem("월계", "MS"));
            this.cboGbn.Items.Add(new ListItem("누계", "TS"));
            cboGbn.SelectedIndex = 0;

            /// </summary>
        }
    }

    private void _queryGrid()
    {
        string strYY = this.cboYY.SelectedValue;
        string strMM = this.cboMM.SelectedValue;
        string strCom = this.cboCom.SelectedValue;
        string strGbn = this.cboGbn.SelectedValue;
        int intPYY = Convert.ToInt32(strYY)-1;
        string strPYY = intPYY.ToString();
        string query = "";

        query = @"SELECT SGBUN_CD, MAX(SGBUN_NM) SGBUN_NM,
               SUM(TA.PLAN_01) PLAN_01, SUM(TA.PLAN_02) PLAN_02, SUM(TA.PLAN_03) PLAN_03, SUM(TA.PLAN_04) PLAN_04,
               SUM(TA.PLAN_05) PLAN_05, SUM(TA.PLAN_06) PLAN_06, SUM(TA.PLAN_07) PLAN_07, SUM(TA.PLAN_08) PLAN_08,
               SUM(TA.PLAN_09) PLAN_09, SUM(TA.PLAN_10) PLAN_10, SUM(TA.PLAN_11) PLAN_11, SUM(TA.PLAN_12) PLAN_12,
               SUM(TA.ACTL_01) ACTL_01, SUM(TA.ACTL_02) ACTL_02, SUM(TA.ACTL_03) ACTL_03, SUM(TA.ACTL_04) ACTL_04,
               SUM(TA.ACTL_05) ACTL_05, SUM(TA.ACTL_06) ACTL_06, SUM(TA.ACTL_07) ACTL_07, SUM(TA.ACTL_08) ACTL_08,
               SUM(TA.ACTL_09) ACTL_09, SUM(TA.ACTL_10) ACTL_10, SUM(TA.ACTL_11) ACTL_11, SUM(TA.ACTL_12) ACTL_12,
			   (SUM(TA.ACTL_01)-SUM(TA.PLAN_01)) DIFF_01,(SUM(TA.ACTL_02)-SUM(TA.PLAN_02)) DIFF_02,(SUM(TA.ACTL_03)-SUM(TA.PLAN_03)) DIFF_03,
               (SUM(TA.ACTL_04)-SUM(TA.PLAN_04)) DIFF_04,(SUM(TA.ACTL_05)-SUM(TA.PLAN_05)) DIFF_05,(SUM(TA.ACTL_06)-SUM(TA.PLAN_06)) DIFF_06,
			   (SUM(TA.ACTL_07)-SUM(TA.PLAN_07)) DIFF_07,(SUM(TA.ACTL_08)-SUM(TA.PLAN_08)) DIFF_08,(SUM(TA.ACTL_09)-SUM(TA.PLAN_09)) DIFF_09,
			   (SUM(TA.ACTL_10)-SUM(TA.PLAN_10)) DIFF_10,(SUM(TA.ACTL_11)-SUM(TA.PLAN_11)) DIFF_11,(SUM(TA.ACTL_12)-SUM(TA.PLAN_12)) DIFF_12,
               NVL(SUM(TA.ACHV_RATE_01),0) ACHV_RATE_01, NVL(SUM(TA.ACHV_RATE_02),0) ACHV_RATE_02, NVL(SUM(TA.ACHV_RATE_03),0) ACHV_RATE_03,
               NVL(SUM(TA.ACHV_RATE_04),0) ACHV_RATE_04, NVL(SUM(TA.ACHV_RATE_05),0) ACHV_RATE_05, NVL(SUM(TA.ACHV_RATE_06),0) ACHV_RATE_06,
               NVL(SUM(TA.ACHV_RATE_07),0) ACHV_RATE_07, NVL(SUM(TA.ACHV_RATE_08),0) ACHV_RATE_08, NVL(SUM(TA.ACHV_RATE_09),0) ACHV_RATE_09,
               NVL(SUM(TA.ACHV_RATE_10),0) ACHV_RATE_10, NVL(SUM(TA.ACHV_RATE_11),0) ACHV_RATE_11, NVL(SUM(TA.ACHV_RATE_12),0) ACHV_RATE_12,
               NVL(SUM(TA.GROW_RATE_01),0) GROW_RATE_01, NVL(SUM(TA.GROW_RATE_02),0) GROW_RATE_02, NVL(SUM(TA.GROW_RATE_03),0) GROW_RATE_03,
               NVL(SUM(TA.GROW_RATE_04),0) GROW_RATE_04, NVL(SUM(TA.GROW_RATE_05),0) GROW_RATE_05, NVL(SUM(TA.GROW_RATE_06),0) GROW_RATE_06,
               NVL(SUM(TA.GROW_RATE_07),0) GROW_RATE_07, NVL(SUM(TA.GROW_RATE_08),0) GROW_RATE_08, NVL(SUM(TA.GROW_RATE_09),0) GROW_RATE_09,
               NVL(SUM(TA.GROW_RATE_10),0) GROW_RATE_10, NVL(SUM(TA.GROW_RATE_11),0) GROW_RATE_11, NVL(SUM(TA.GROW_RATE_12),0) GROW_RATE_12
          FROM (
               SELECT A.SGBUN_CD as SGBUN_CD, MAX(A.SGBUN_NM) as SGBUN_NM, MAX(A.YY) as YY, MAX(A.MM) as MM,
			          DECODE(MAX(A.MM),'01',SUM(A.S_PLAN)/1000000,0) as PLAN_01,
			          DECODE(MAX(A.MM),'02',SUM(A.S_PLAN)/1000000,0) as PLAN_02,
			          DECODE(MAX(A.MM),'03',SUM(A.S_PLAN)/1000000,0) as PLAN_03,
			          DECODE(MAX(A.MM),'04',SUM(A.S_PLAN)/1000000,0) as PLAN_04,
			          DECODE(MAX(A.MM),'05',SUM(A.S_PLAN)/1000000,0) as PLAN_05,
			          DECODE(MAX(A.MM),'06',SUM(A.S_PLAN)/1000000,0) as PLAN_06,
			          DECODE(MAX(A.MM),'07',SUM(A.S_PLAN)/1000000,0) as PLAN_07,
			          DECODE(MAX(A.MM),'08',SUM(A.S_PLAN)/1000000,0) as PLAN_08,
			          DECODE(MAX(A.MM),'09',SUM(A.S_PLAN)/1000000,0) as PLAN_09,
			          DECODE(MAX(A.MM),'10',SUM(A.S_PLAN)/1000000,0) as PLAN_10,
			          DECODE(MAX(A.MM),'11',SUM(A.S_PLAN)/1000000,0) as PLAN_11,
			          DECODE(MAX(A.MM),'12',SUM(A.S_PLAN)/1000000,0) as PLAN_12,
			          DECODE(MAX(A.MM),'01',SUM(A.S_RSLT)/1000000,0) as ACTL_01,
			          DECODE(MAX(A.MM),'02',SUM(A.S_RSLT)/1000000,0) as ACTL_02,
			          DECODE(MAX(A.MM),'03',SUM(A.S_RSLT)/1000000,0) as ACTL_03,
			          DECODE(MAX(A.MM),'04',SUM(A.S_RSLT)/1000000,0) as ACTL_04,
			          DECODE(MAX(A.MM),'05',SUM(A.S_RSLT)/1000000,0) as ACTL_05,
			          DECODE(MAX(A.MM),'06',SUM(A.S_RSLT)/1000000,0) as ACTL_06,
			          DECODE(MAX(A.MM),'07',SUM(A.S_RSLT)/1000000,0) as ACTL_07,
			          DECODE(MAX(A.MM),'08',SUM(A.S_RSLT)/1000000,0) as ACTL_08,
			          DECODE(MAX(A.MM),'09',SUM(A.S_RSLT)/1000000,0) as ACTL_09,
			          DECODE(MAX(A.MM),'10',SUM(A.S_RSLT)/1000000,0) as ACTL_10,
			          DECODE(MAX(A.MM),'11',SUM(A.S_RSLT)/1000000,0) as ACTL_11,
			          DECODE(MAX(A.MM),'12',SUM(A.S_RSLT)/1000000,0) as ACTL_12,
			          DECODE(MAX(A.MM),'01',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_01,
			          DECODE(MAX(A.MM),'02',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_02,
			          DECODE(MAX(A.MM),'03',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_03,
			          DECODE(MAX(A.MM),'04',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_04,
			          DECODE(MAX(A.MM),'05',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_05,
			          DECODE(MAX(A.MM),'06',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_06,
			          DECODE(MAX(A.MM),'07',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_07,
			          DECODE(MAX(A.MM),'08',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_08,
			          DECODE(MAX(A.MM),'09',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_09,
			          DECODE(MAX(A.MM),'10',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_10,
			          DECODE(MAX(A.MM),'11',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_11,
			          DECODE(MAX(A.MM),'12',ROUND(DECODE(NVL(SUM(A.S_PLAN),0),0,0,(SUM(A.S_RSLT)/SUM(A.S_PLAN))*100)),2,0) as ACHV_RATE_12,
			          DECODE(MAX(A.MM),'01',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_01,
			          DECODE(MAX(A.MM),'02',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_02,
			          DECODE(MAX(A.MM),'03',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_03,
			          DECODE(MAX(A.MM),'04',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_04,
			          DECODE(MAX(A.MM),'05',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_05,
			          DECODE(MAX(A.MM),'06',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_06,
			          DECODE(MAX(A.MM),'07',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_07,
			          DECODE(MAX(A.MM),'08',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_08,
			          DECODE(MAX(A.MM),'09',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_09,
			          DECODE(MAX(A.MM),'10',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_10,
			          DECODE(MAX(A.MM),'11',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_11,
			          DECODE(MAX(A.MM),'12',ROUND(DECODE(NVL(SUM(B.S_RSLT),0),0,0,(SUM(A.S_RSLT)/SUM(B.S_RSLT)))),2,0) as GROW_RATE_12
                 FROM (
                      SELECT AA.SGBUN_CD as SGBUN_CD, AA.SGBUN_NM as SGBUN_NM, 
                             AA.YY as YY, AA.MM as MM,
                             AA.COM_CD as COM_CD,   
                             SUM(AA.S_PLAN) as S_PLAN, SUM(AA.S_RSLT) as S_RSLT
                        FROM (SELECT SEM_CODE_MASTER.SEM_CODE2_T as SGBUN_CD,
                                     SEM_CODE_MASTER.SEM_CODE2_NAME as SGBUN_NM,
                                     SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,1,4) as YY,
			                         SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,5,2) as MM,							 
                                     SEM_SALE_MONTHLY.SALE_OFFICE_T as COM_CD,
                                     DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_PLAN),'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_PLAN)) as S_PLAN,
                                     0 as S_RSLT
                                FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                     SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                               WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                                 AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                 AND SEM_SALE_MONTHLY.SALE_DATE_T BETWEEN '" + (strYY) + @"01' AND '" + (strYY) + @"12'
                                 AND SEM_SALE_MONTHLY.SALE_OFFICE_T like  '" + strCom + @"%'
                               GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                                        SEM_CODE_MASTER.SEM_CODE2_NAME,
                                        SEM_SALE_MONTHLY.SALE_DATE_T,
                                        SEM_SALE_MONTHLY.SALE_OFFICE_T 
                               UNION  ALL
                              SELECT SEM_CODE_MASTER.SEM_CODE2_T as SGBUN_CD,
                                     SEM_CODE_MASTER.SEM_CODE2_NAME as SGBUN_NM,
                                     SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,1,4) as YY,
			                         SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,5,2) as MM,							 
                                     SEM_SALE_MONTHLY.SALE_OFFICE_T as COM_CD,
                                     0 as S_PLAN,
                                     DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_ACTUAL),'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_ACTUAL)) as S_RSLT
                                FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                     SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                               WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                                 AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                 AND SEM_SALE_MONTHLY.SALE_DATE_T BETWEEN '" + (strYY) + @"01' AND '" + (strYY+strMM) + @"'
                                 AND SEM_SALE_MONTHLY.SALE_OFFICE_T like  '" + strCom + @"%'
                               GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                                        SEM_CODE_MASTER.SEM_CODE2_NAME,
                                        SEM_SALE_MONTHLY.SALE_DATE_T,
                                        SEM_SALE_MONTHLY.SALE_OFFICE_T) AA
                         GROUP BY  AA.SGBUN_CD, AA.SGBUN_NM, AA.YY, AA.MM, AA.COM_CD) A,
                      (
                       SELECT SEM_CODE_MASTER.SEM_CODE2_T as SGBUN_CD,
                              SEM_CODE_MASTER.SEM_CODE2_NAME as SGBUN_NM,
                             SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,1,4) as YY,
							 SUBSTR(SEM_SALE_MONTHLY.SALE_DATE_T,5,2) as MM,
                              SEM_SALE_MONTHLY.SALE_OFFICE_T as COM_CD,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_PLAN),'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_PLAN)) as S_PLAN,
                              DECODE('" + strGbn + @"','MS',SUM(SEM_SALE_MONTHLY.SALE_AMT_ACTUAL),'TS',SUM(SEM_SALE_MONTHLY.SALE_SUM_AMT_ACTUAL)) as S_RSLT
                         FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                              SEM_SALE_MONTHLY SEM_SALE_MONTHLY
                        WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                          AND SEM_SALE_MONTHLY.SALE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                          AND SEM_SALE_MONTHLY.SALE_DATE_T BETWEEN '" + (strPYY) + @"01' AND '" + (strPYY) + @"12'
                          AND SEM_SALE_MONTHLY.SALE_OFFICE_T like  '" + strCom + @"%'
                        GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                              SEM_CODE_MASTER.SEM_CODE2_NAME,
                              SEM_SALE_MONTHLY.SALE_DATE_T,
                              SEM_SALE_MONTHLY.SALE_OFFICE_T) B
                 WHERE B.SGBUN_CD = A.SGBUN_CD(+)
                   AND B.MM = A.MM(+)
                   AND B.COM_CD = A.COM_CD(+)
				 GROUP BY A.SGBUN_CD, A.YY, A.MM) TA
        GROUP BY TA.SGBUN_CD";

        DataSet dsGrid = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(query, _connection);
        daGrid.Fill(dsGrid);
        this.setGrid(dsGrid);
    }

    private void setGrid(DataSet dsGrid)
    {

        DataTable dtGrid = Tbl_Grid();
        DataRow drGrid;

        double dblAmt_01 = 0.00;
        double dblAmt_02 = 0.00;
        double dblAmt_03 = 0.00;
        double dblAmt_04 = 0.00;
        double dblAmt_05 = 0.00;
        double dblAmt_06 = 0.00;
        double dblAmt_07 = 0.00;
        double dblAmt_08 = 0.00;
        double dblAmt_09 = 0.00;
        double dblAmt_10 = 0.00;
        double dblAmt_11 = 0.00;
        double dblAmt_12 = 0.00;

        int idxY = 0;
        for (int i = 0; i < dsGrid.Tables[0].Rows.Count; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                drGrid = dtGrid.NewRow();
                switch (j)
                {
                    case 1:
                        drGrid["serNo"] = j;
                        idxY = 2;
                        drGrid["sTYPE"] = "계획";
                        break;
                    case 2:
                        drGrid["serNo"] = j;
                        idxY = 14;
                        drGrid["sTYPE"] = "실적";
                        break;
                    case 3:
                        drGrid["serNo"] = j;
                        idxY = 26;
                        drGrid["sTYPE"] = "차이";
                        break;
                    case 4:
                        drGrid["serNo"] = j;
                        idxY = 38;
                        drGrid["sTYPE"] = "달성율(%)";
                        break;
                    case 5:
                        drGrid["serNo"] = j;
                        idxY = 50;
                        drGrid["sTYPE"] = "증가율(%)";
                        break;
                    default:
                        break;
                }

                drGrid["sYY"] = "당년";
                drGrid["SGBUN_CD"] = dsGrid.Tables[0].Rows[i][0];
                drGrid["SGBUN_NM"] = dsGrid.Tables[0].Rows[i][1];
                drGrid["AMT_01"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY].ToString());
                drGrid["AMT_02"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 1].ToString());
                drGrid["AMT_03"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 2].ToString());
                drGrid["AMT_04"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 3].ToString());
                drGrid["AMT_05"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 4].ToString());
                drGrid["AMT_06"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 5].ToString());
                drGrid["AMT_07"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 6].ToString());
                drGrid["AMT_08"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 7].ToString());
                drGrid["AMT_09"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 8].ToString());
                drGrid["AMT_10"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 9].ToString());
                drGrid["AMT_11"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 10].ToString());
                drGrid["AMT_12"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 11].ToString());
                dtGrid.Rows.Add(drGrid);
            }
        }

        DataView dvSubT = dtGrid.DefaultView;
        dvSubT.Sort = "serNo";

        DataTable dtSubT = dvSubT.ToTable();

        string strAftGbn = "";
        string strBfrGbn = "";
        int cntRow = dtSubT.Rows.Count;

        if (dtSubT.Rows.Count > 1)
        {
            for (int k = 0; k < dtSubT.Rows.Count; k++)
            {
                strBfrGbn = (k == 0) ? dtSubT.Rows[k]["serNo"].ToString() : dtSubT.Rows[k - 1]["serNo"].ToString();
                strAftGbn = dtSubT.Rows[k]["serNo"].ToString();

                if ((strBfrGbn != strAftGbn) && (int.Parse(strBfrGbn) < 4))
                {
                    drGrid = dtSubT.NewRow();
                    drGrid["serNo"] = strBfrGbn;
                    //drGrid["sTYPE"] = "소계";
                    drGrid["sYY"] = "당년";
                    drGrid["SGBUN_CD"] = "999999";
                    drGrid["SGBUN_NM"] = "소계";
                    drGrid["AMT_01"] = dblAmt_01;
                    drGrid["AMT_02"] = dblAmt_02;
                    drGrid["AMT_03"] = dblAmt_03;
                    drGrid["AMT_04"] = dblAmt_04;
                    drGrid["AMT_05"] = dblAmt_05;
                    drGrid["AMT_06"] = dblAmt_06;
                    drGrid["AMT_07"] = dblAmt_07;
                    drGrid["AMT_08"] = dblAmt_08;
                    drGrid["AMT_09"] = dblAmt_09;
                    drGrid["AMT_10"] = dblAmt_10;
                    drGrid["AMT_11"] = dblAmt_11;
                    drGrid["AMT_12"] = dblAmt_12;
                    dtSubT.Rows.InsertAt(drGrid, k);
                    k += 1;
                    //dtGrid.Rows.Add(drGrid);

                    dblAmt_01 = 0.00;
                    dblAmt_02 = 0.00;
                    dblAmt_03 = 0.00;
                    dblAmt_04 = 0.00;
                    dblAmt_05 = 0.00;
                    dblAmt_06 = 0.00;
                    dblAmt_07 = 0.00;
                    dblAmt_08 = 0.00;
                    dblAmt_09 = 0.00;
                    dblAmt_10 = 0.00;
                    dblAmt_11 = 0.00;
                    dblAmt_12 = 0.00;

                    dblAmt_01 += double.Parse(dtSubT.Rows[k][5].ToString());
                    dblAmt_02 += double.Parse(dtSubT.Rows[k][6].ToString());
                    dblAmt_03 += double.Parse(dtSubT.Rows[k][7].ToString());
                    dblAmt_04 += double.Parse(dtSubT.Rows[k][8].ToString());
                    dblAmt_05 += double.Parse(dtSubT.Rows[k][9].ToString());
                    dblAmt_06 += double.Parse(dtSubT.Rows[k][10].ToString());
                    dblAmt_07 += double.Parse(dtSubT.Rows[k][11].ToString());
                    dblAmt_08 += double.Parse(dtSubT.Rows[k][12].ToString());
                    dblAmt_09 += double.Parse(dtSubT.Rows[k][13].ToString());
                    dblAmt_10 += double.Parse(dtSubT.Rows[k][14].ToString());
                    dblAmt_11 += double.Parse(dtSubT.Rows[k][15].ToString());
                    dblAmt_12 += double.Parse(dtSubT.Rows[k][16].ToString());

                }
                else
                {
                    dblAmt_01 += double.Parse(dtSubT.Rows[k][5].ToString());
                    dblAmt_02 += double.Parse(dtSubT.Rows[k][6].ToString());
                    dblAmt_03 += double.Parse(dtSubT.Rows[k][7].ToString());
                    dblAmt_04 += double.Parse(dtSubT.Rows[k][8].ToString());
                    dblAmt_05 += double.Parse(dtSubT.Rows[k][9].ToString());
                    dblAmt_06 += double.Parse(dtSubT.Rows[k][10].ToString());
                    dblAmt_07 += double.Parse(dtSubT.Rows[k][11].ToString());
                    dblAmt_08 += double.Parse(dtSubT.Rows[k][12].ToString());
                    dblAmt_09 += double.Parse(dtSubT.Rows[k][13].ToString());
                    dblAmt_10 += double.Parse(dtSubT.Rows[k][14].ToString());
                    dblAmt_11 += double.Parse(dtSubT.Rows[k][15].ToString());
                    dblAmt_12 += double.Parse(dtSubT.Rows[k][16].ToString());
                }
            }

        }

        DataView dvGrid = dtSubT.DefaultView;
        //dvGrid.Sort = "serNo";
        UltraWebGrid1.DataSource = dvGrid;
        UltraWebGrid1.DataBind();
        return;
    }

    private DataTable Tbl_Grid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("serNo", typeof(int));
        dt.Columns.Add("sYY", typeof(string));
        dt.Columns.Add("sTYPE", typeof(string));
        dt.Columns.Add("SGBUN_CD", typeof(string));
        dt.Columns.Add("SGBUN_NM", typeof(string));
        dt.Columns.Add("AMT_01", typeof(double));
        dt.Columns.Add("AMT_02", typeof(double));
        dt.Columns.Add("AMT_03", typeof(double));
        dt.Columns.Add("AMT_04", typeof(double));
        dt.Columns.Add("AMT_05", typeof(double));
        dt.Columns.Add("AMT_06", typeof(double));
        dt.Columns.Add("AMT_07", typeof(double));
        dt.Columns.Add("AMT_08", typeof(double));
        dt.Columns.Add("AMT_09", typeof(double));
        dt.Columns.Add("AMT_10", typeof(double));
        dt.Columns.Add("AMT_11", typeof(double));
        dt.Columns.Add("AMT_12", typeof(double));
        return dt;
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        double dblRate = 0.0;
        if (Convert.ToString(e.Row.Cells[2].Value) == "달성율")
        {
            for (int i = 5; i < UltraWebGrid1.Columns.Count; i++)
            {
                dblRate = Convert.ToDouble(e.Row.Cells[i].Value);
                e.Row.Cells[i].Style.ForeColor = (dblRate > 99) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
            }
        }

        if (Convert.ToString(e.Row.Cells[2].Value) == "증가율")
        {
            for (int i = 5; i < UltraWebGrid1.Columns.Count; i++)
            {
                dblRate = Convert.ToDouble(e.Row.Cells[i].Value);
                e.Row.Cells[i].Style.ForeColor = (dblRate >= 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
            }
        }

    }
}