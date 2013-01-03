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

public partial class eis_SEM_Mana_R041 : EISPageBase
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
        int intPYY = Convert.ToInt32(strYY) - 1;
        string strPYY = intPYY.ToString();
        string query = "";

        query = @"
           SELECT SEM_NM,
                  SUM(PN01) as PN01, SUM(PN02) as PN02, SUM(PN03) as PN03,
                  SUM(PN04) as PN04, SUM(PN05) as PN05, SUM(PN06) as PN06,
                  SUM(PN07) as PN07, SUM(PN08) as PN08, SUM(PN09) as PN09,
                  SUM(PN10) as PN10, SUM(PN11) as PN11, SUM(PN12) as PN12,
                  SUM(CA01) as CA01, SUM(CA02) as CA02, SUM(CA03) as CA03,
                  SUM(CA04) as CA04, SUM(CA05) as CA05, SUM(CA06) as CA06,
                  SUM(CA07) as CA07, SUM(CA08) as CA08, SUM(CA09) as CA09,
                  SUM(CA10) as CA10, SUM(CA11) as CA11, SUM(CA12) as CA12,
                  SUM(DF01) as DF01, SUM(DF02) as DF02, SUM(DF03) as DF03,
                  SUM(DF04) as DF04, SUM(DF05) as DF05, SUM(DF06) as DF06,
                  SUM(DF07) as DF07, SUM(DF08) as DF08, SUM(DF09) as DF09,
                  SUM(DF10) as DF10, SUM(DF11) as DF11, SUM(DF12) as DF12,
                  SUM(AR01) as AR01, SUM(AR02) as AR02, SUM(AR03) as AR03,
                  SUM(AR04) as AR04, SUM(AR05) as AR05, SUM(AR06) as AR06,
                  SUM(AR07) as AR07, SUM(AR08) as AR08, SUM(AR09) as AR09,
                  SUM(AR10) as AR10, SUM(AR11) as AR11, SUM(AR12) as AR12,
                  SUM(DR01) as DR01, SUM(DR02) as DR02, SUM(DR03) as DR03,
                  SUM(DR04) as DR04, SUM(DR05) as DR05, SUM(DR06) as DR06,
                  SUM(DR07) as DR07, SUM(DR08) as DR08, SUM(DR09) as DR09,
                  SUM(DR10) as DR10, SUM(DR11) as DR11, SUM(DR12) as DR12
             FROM (SELECT A.SEM_CD, A.SEM_NM,
                          DECODE(A.MM,'01',A.PN,0) as PN01, DECODE(A.MM,'02',A.PN,0) as PN02, DECODE(A.MM,'03',A.PN,0) as PN03,
                          DECODE(A.MM,'04',A.PN,0) as PN04, DECODE(A.MM,'05',A.PN,0) as PN05, DECODE(A.MM,'06',A.PN,0) as PN06,
                          DECODE(A.MM,'07',A.PN,0) as PN07, DECODE(A.MM,'08',A.PN,0) as PN08, DECODE(A.MM,'09',A.PN,0) as PN09,
                          DECODE(A.MM,'10',A.PN,0) as PN10, DECODE(A.MM,'11',A.PN,0) as PN11, DECODE(A.MM,'12',A.PN,0) as PN12,
                          DECODE(A.MM,'01',A.CA,0) as CA01, DECODE(A.MM,'02',A.CA,0) as CA02, DECODE(A.MM,'03',A.CA,0) as CA03,
                          DECODE(A.MM,'04',A.CA,0) as CA04, DECODE(A.MM,'05',A.CA,0) as CA05, DECODE(A.MM,'06',A.CA,0) as CA06,
                          DECODE(A.MM,'07',A.CA,0) as CA07, DECODE(A.MM,'08',A.CA,0) as CA08, DECODE(A.MM,'09',A.CA,0) as CA09,
                          DECODE(A.MM,'10',A.CA,0) as CA10, DECODE(A.MM,'11',A.CA,0) as CA11, DECODE(A.MM,'12',A.CA,0) as CA12,
                          DECODE(A.MM,'01',A.DF,0) as DF01, DECODE(A.MM,'02',A.DF,0) as DF02, DECODE(A.MM,'03',A.DF,0) as DF03,
                          DECODE(A.MM,'04',A.DF,0) as DF04, DECODE(A.MM,'05',A.DF,0) as DF05, DECODE(A.MM,'06',A.DF,0) as DF06,
                          DECODE(A.MM,'07',A.DF,0) as DF07, DECODE(A.MM,'08',A.DF,0) as DF08, DECODE(A.MM,'09',A.DF,0) as DF09,
                          DECODE(A.MM,'10',A.DF,0) as DF10, DECODE(A.MM,'11',A.DF,0) as DF11, DECODE(A.MM,'12',A.DF,0) as DF12,
                          DECODE(A.MM,'01',A.AR,0) as AR01, DECODE(A.MM,'02',A.AR,0) as AR02, DECODE(A.MM,'03',A.AR,0) as AR03,
                          DECODE(A.MM,'04',A.AR,0) as AR04, DECODE(A.MM,'05',A.AR,0) as AR05, DECODE(A.MM,'06',A.AR,0) as AR06,
                          DECODE(A.MM,'07',A.AR,0) as AR07, DECODE(A.MM,'08',A.AR,0) as AR08, DECODE(A.MM,'09',A.AR,0) as AR09,
                          DECODE(A.MM,'10',A.AR,0) as AR10, DECODE(A.MM,'11',A.AR,0) as AR11, DECODE(A.MM,'12',A.AR,0) as AR12,
                          DECODE(A.MM,'01',A.DR,0) as DR01, DECODE(A.MM,'02',A.DR,0) as DR02, DECODE(A.MM,'03',A.DR,0) as DR03,
                          DECODE(A.MM,'04',A.DR,0) as DR04, DECODE(A.MM,'05',A.DR,0) as DR05, DECODE(A.MM,'06',A.DR,0) as DR06,
                          DECODE(A.MM,'07',A.DR,0) as DR07, DECODE(A.MM,'08',A.DR,0) as DR08, DECODE(A.MM,'09',A.DR,0) as DR09,
                          DECODE(A.MM,'10',A.DR,0) as DR10, DECODE(A.MM,'11',A.DR,0) as DR11, DECODE(A.MM,'12',A.DR,0) as DR12
                     FROM (SELECT CT.MM,CT.SEM_CD, CT.SEM_NM,
                                  NVL(SUM(CT.C_PN),0) as PN, 
                                  NVL(SUM(CT.C_AL),0) as CA,
                                  NVL((SUM(CT.C_AL) - SUM(CT.C_PN)),0) as DF,
                                  NVL(ROUND(DECODE(SUM(CT.C_PN),0,0, ((SUM(CT.C_AL)/SUM(CT.C_PN))*100)),2),0) as AR,
                                  NVL(ROUND(DECODE(SUM(PT.P_AL),0,0, ((SUM(CT.C_AL)/SUM(PT.P_AL))*100)),2),0) as DR
                             FROM (SELECT SUBSTR(SEM_DEMAND_DEVELOP.DEVE_DATE_T,5,2) as MM,
                                          SEM_CODE_MASTER.SEM_CODE2_T as SEM_CD,
                                          SEM_CODE_MASTER.SEM_CODE2_NAME as SEM_NM,
                                          DECODE('" + cboGbn.SelectedValue + @"','MS',SUM(SEM_DEMAND_DEVELOP.DEVE_PLAN),'TS',SUM(SEM_DEMAND_DEVELOP.DEVE_SUM_PLAN)) as C_PN,
                                          DECODE('" + cboGbn.SelectedValue + @"','MS',SUM(SEM_DEMAND_DEVELOP.DEVE_ACTUAL),'TS',SUM(SEM_DEMAND_DEVELOP.DEVE_SUM_ACTUAL)) as C_AL
                                     FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                          SEM_DEMAND_DEVELOP SEM_DEMAND_DEVELOP
                                    WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                                      AND SEM_DEMAND_DEVELOP.DEVE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                      AND SEM_DEMAND_DEVELOP.DEVE_DATE_T BETWEEN ('" + cboYY.SelectedValue + @"'||'01') AND ('" + (cboYY.SelectedValue+cboMM.SelectedValue) + @"')
                                      AND SEM_DEMAND_DEVELOP.DEVE_OFFICE_T like ('" + strCom +@"'||'%')
                                      AND SEM_CODE_MASTER.SEM_CODE3_T <> '120'
                                    GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                                          SEM_CODE_MASTER.SEM_CODE2_NAME,
                                          SEM_DEMAND_DEVELOP.DEVE_DATE_T) CT,
                                  (SELECT SUBSTR(SEM_DEMAND_DEVELOP.DEVE_DATE_T,5,2) as MM,
                                          SEM_CODE_MASTER.SEM_CODE2_T as SEM_CD,
                                          SEM_CODE_MASTER.SEM_CODE2_NAME as SEM_NM,
                                          DECODE('MS','MS',SUM(SEM_DEMAND_DEVELOP.DEVE_ACTUAL),'TS',SUM(SEM_DEMAND_DEVELOP.DEVE_SUM_ACTUAL)) as P_AL
                                     FROM SEM_CODE_MASTER SEM_CODE_MASTER,
                                          SEM_DEMAND_DEVELOP SEM_DEMAND_DEVELOP
                                    WHERE SEM_CODE_MASTER.SEM_CODE1_T = '06'
                                      AND SEM_CODE_MASTER.SEM_CODE3_T <> '120'
                                      AND SEM_DEMAND_DEVELOP.DEVE_OFFICE_T like ('" + strCom +@"'||'%')
                                      AND SEM_DEMAND_DEVELOP.DEVE_GUBN_CODE_T = SEM_CODE_MASTER.SEM_CODE3_T
                                      AND SEM_DEMAND_DEVELOP.DEVE_DATE_T BETWEEN ('" + intPYY.ToString() + @"'||'01') AND ('" + (intPYY.ToString()+cboMM.SelectedValue) + @"')
                                    GROUP BY SEM_CODE_MASTER.SEM_CODE2_T,
                                          SEM_CODE_MASTER.SEM_CODE2_NAME,
                                          SEM_DEMAND_DEVELOP.DEVE_DATE_T) PT
                            WHERE CT.MM = PT.MM(+)
                              AND CT.SEM_CD = PT.SEM_CD(+)
                            GROUP BY CT.MM, CT.SEM_CD,CT.SEM_NM
                           ) A
                      ) B
                GROUP BY B.SEM_CD, B.SEM_NM";

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
                        idxY = 0;
                        drGrid["구분"] = "계획";
                        break;
                    case 2:
                        drGrid["serNo"] = j;
                        idxY = 12;
                        drGrid["구분"] = "실적";
                        break;
                    case 3:
                        drGrid["serNo"] = j;
                        idxY = 24;
                        drGrid["구분"] = "차이";
                        break;
                    case 4:
                        drGrid["serNo"] = j;
                        idxY = 36;
                        drGrid["구분"] = "달성율(%)";
                        break;
                    case 5:
                        drGrid["serNo"] = j;
                        idxY = 48;
                        drGrid["구분"] = "증가율(%)";
                        break;
                    default:
                        break;
                }
                drGrid["용도"] = dsGrid.Tables[0].Rows[i][0].ToString();
                drGrid["01월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 1].ToString());
                drGrid["02월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 2].ToString());
                drGrid["03월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 3].ToString());
                drGrid["04월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 4].ToString());
                drGrid["05월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 5].ToString());
                drGrid["06월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 6].ToString());
                drGrid["07월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 7].ToString());
                drGrid["08월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 8].ToString());
                drGrid["09월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 9].ToString());
                drGrid["10월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 10].ToString());
                drGrid["11월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 11].ToString());
                drGrid["12월"] = double.Parse(dsGrid.Tables[0].Rows[i][idxY + 12].ToString());
                dtGrid.Rows.Add(drGrid);
            }
        }
        DataView dvSubT = dtGrid.DefaultView;
        dvSubT.Sort = "serNo";

        DataTable dtSubT = dvSubT.ToTable();

        string strAftGbn = "";
        string strBfrGbn = "";
        string strGbn = "";
        int cntRow = dtSubT.Rows.Count;


        if (dtSubT.Rows.Count > 1)
        {
            for (int k = 0; k < dtSubT.Rows.Count; k++)
            {
                strBfrGbn = (k == 0) ? dtSubT.Rows[k]["serNo"].ToString() : dtSubT.Rows[k - 1]["serNo"].ToString();
                strAftGbn = dtSubT.Rows[k]["serNo"].ToString();
                strGbn = (k == 0) ? dtSubT.Rows[k]["구분"].ToString() : dtSubT.Rows[k - 1]["구분"].ToString();

                if ((strBfrGbn != strAftGbn) && (int.Parse(strBfrGbn) < 4))
                {
                    drGrid = dtSubT.NewRow();
                    drGrid["serNo"] = strBfrGbn;
                    //drGrid["sTYPE"] = "소계";
                    //drGrid["sYY"] = "당년";
                    drGrid["구분"] = strGbn;
                    drGrid["용도"] = "소계";
                    drGrid["01월"] = dblAmt_01;
                    drGrid["02월"] = dblAmt_02;
                    drGrid["03월"] = dblAmt_03;
                    drGrid["04월"] = dblAmt_04;
                    drGrid["05월"] = dblAmt_05;
                    drGrid["06월"] = dblAmt_06;
                    drGrid["07월"] = dblAmt_07;
                    drGrid["08월"] = dblAmt_08;
                    drGrid["09월"] = dblAmt_09;
                    drGrid["10월"] = dblAmt_10;
                    drGrid["11월"] = dblAmt_11;
                    drGrid["12월"] = dblAmt_12;
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

                    dblAmt_01 += double.Parse(dtSubT.Rows[k][3].ToString());
                    dblAmt_02 += double.Parse(dtSubT.Rows[k][4].ToString());
                    dblAmt_03 += double.Parse(dtSubT.Rows[k][5].ToString());
                    dblAmt_04 += double.Parse(dtSubT.Rows[k][6].ToString());
                    dblAmt_05 += double.Parse(dtSubT.Rows[k][7].ToString());
                    dblAmt_06 += double.Parse(dtSubT.Rows[k][8].ToString());
                    dblAmt_07 += double.Parse(dtSubT.Rows[k][9].ToString());
                    dblAmt_08 += double.Parse(dtSubT.Rows[k][10].ToString());
                    dblAmt_09 += double.Parse(dtSubT.Rows[k][11].ToString());
                    dblAmt_10 += double.Parse(dtSubT.Rows[k][12].ToString());
                    dblAmt_11 += double.Parse(dtSubT.Rows[k][13].ToString());
                    dblAmt_12 += double.Parse(dtSubT.Rows[k][14].ToString());

                }
                else
                {
                    dblAmt_01 += double.Parse(dtSubT.Rows[k][3].ToString());
                    dblAmt_02 += double.Parse(dtSubT.Rows[k][4].ToString());
                    dblAmt_03 += double.Parse(dtSubT.Rows[k][5].ToString());
                    dblAmt_04 += double.Parse(dtSubT.Rows[k][6].ToString());
                    dblAmt_05 += double.Parse(dtSubT.Rows[k][7].ToString());
                    dblAmt_06 += double.Parse(dtSubT.Rows[k][8].ToString());
                    dblAmt_07 += double.Parse(dtSubT.Rows[k][9].ToString());
                    dblAmt_08 += double.Parse(dtSubT.Rows[k][10].ToString());
                    dblAmt_09 += double.Parse(dtSubT.Rows[k][11].ToString());
                    dblAmt_10 += double.Parse(dtSubT.Rows[k][12].ToString());
                    dblAmt_11 += double.Parse(dtSubT.Rows[k][13].ToString());
                    dblAmt_12 += double.Parse(dtSubT.Rows[k][14].ToString());
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
        dt.Columns.Add("구분", typeof(string));
        dt.Columns.Add("용도", typeof(string));
        dt.Columns.Add("01월", typeof(double));
        dt.Columns.Add("02월", typeof(double));
        dt.Columns.Add("03월", typeof(double));
        dt.Columns.Add("04월", typeof(double));
        dt.Columns.Add("05월", typeof(double));
        dt.Columns.Add("06월", typeof(double));
        dt.Columns.Add("07월", typeof(double));
        dt.Columns.Add("08월", typeof(double));
        dt.Columns.Add("09월", typeof(double));
        dt.Columns.Add("10월", typeof(double));
        dt.Columns.Add("11월", typeof(double));
        dt.Columns.Add("12월", typeof(double));
        return dt;
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        _queryGrid();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i == 0)
            {
                e.Layout.Bands[0].Columns[i].Hidden = true;
            }
            else if (i == 1)
            {
                e.Layout.Bands[0].Columns[i].Width = 60;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                e.Layout.Bands[0].Columns[i].MergeCells = true;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = 70;
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
    protected void UltraWebGrid1_InitializeRow1(object sender, RowEventArgs e)
    {
        double dblRate = 0.0;
        if (Convert.ToString(e.Row.Cells[1].Value) == "달성율(%)")
        {
            for (int i = 3; i < UltraWebGrid1.Columns.Count; i++)
            {
                dblRate = Convert.ToDouble(e.Row.Cells[i].Value);
                e.Row.Cells[i].Style.ForeColor = (dblRate > 99) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
            }
        }

        if (Convert.ToString(e.Row.Cells[1].Value) == "증가율(%)")
        {
            for (int i = 3; i < UltraWebGrid1.Columns.Count; i++)
            {
                dblRate = Convert.ToDouble(e.Row.Cells[i].Value);
                e.Row.Cells[i].Value = (dblRate==0) ? 0 : (dblRate-100);
                if (dblRate-100 > 0)
                {
                    e.Row.Cells[i].Style.ForeColor = System.Drawing.Color.Blue;
                }
                else if ((Math.Round(dblRate,0)-100) < 0)
                {
                    e.Row.Cells[i].Style.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[i].Style.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
    }
}
