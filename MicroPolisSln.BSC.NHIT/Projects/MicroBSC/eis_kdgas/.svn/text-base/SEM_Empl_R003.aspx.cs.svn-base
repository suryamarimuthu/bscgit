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

public partial class eis_SEM_Empl_R003 : EISPageBase
{
    private DBAgent dbAgent = null;
    public int iMonth = DateTime.Now.Month - 2;
    #region ============================================================================================폼 초기화
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            if (iMonth < 0)
                ddlMonth.SelectedIndex = 11;
            else
                ddlMonth.SelectedIndex = iMonth;
            
            SetType1DropDownList();
            setGridGrph();
        }
    }
    protected void Page_PreRender(object sender, EventArgs e) 
    {
        ddlLocation1.Attributes["onchange"] = "mfChangeLocate(this, 'ddlLocation2', 'ddlLocation3')";
        ddlLocation2.Attributes["onchange"] = "mfChangeLocate(this, 'ddlLocation1', 'ddlLocation3')";
    }


    public void SetType1DropDownList()
    {
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet dsBumun = dbAgent.FillDataSet(GetBumunQuery(),"data");

        ddlLocation1.Items.Insert(0, new ListItem("==전체==", ""));
        ddlLocation1.Items.Insert(1, new ListItem("울산", "01"));
        ddlLocation1.Items.Insert(2, new ListItem("양산", "02"));

        ddlLocation2.DataSource = dsBumun;
        ddlLocation2.DataTextField = "ORG_NM";
        ddlLocation2.DataValueField = "ORG_CD";
        ddlLocation2.DataBind();
        ddlLocation2.Items.Insert(0, new ListItem("==부문 선택==", ""));
        dbAgent = null;
    }
    #endregion

    #region ============================================================================================그리드 조회
    private void setGridGrph() 
    {
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        string strSQL = "SELECT DISTINCT EMP_CODE_T, EMP_CODE_NAME FROM SEM_ORGANIZATION_PERSON WHERE EMP_GUBN_T = '" + ddlStyle.SelectedValue + "'  ORDER BY EMP_CODE_T";
        DataSet dsCode = dbAgent.FillDataSet(strSQL, "tblCD");

        string strQN = "\"";
        string strHD = "";
        string strDT = "";
        string strCD = "";
        string strNM = "";
        int intRow = dsCode.Tables[0].Rows.Count;
        int intCol = dsCode.Tables[0].Columns.Count;

        for (int i = 0; i < intRow; i++)
        {
            strCD = dsCode.Tables[0].Rows[i][0].ToString();
            strNM = dsCode.Tables[0].Rows[i][1].ToString();

            if (i == (intRow - 1))
            {
                strHD += "SUM(B.COL_" + i.ToString() + ") as " + strQN + strNM + strQN;
                strDT += "DECODE(A.GBN_CD,'" + strCD + "',A.EMP_CNT,0) as COL_" + i.ToString();
            }
            else
            {
                strHD += "SUM(B.COL_" + i.ToString() + ") as " + strQN + strNM + strQN + ",";
                strDT += "DECODE(A.GBN_CD,'" + strCD + "',A.EMP_CNT,0) as COL_" + i.ToString() + ",";
            }
        }

        strSQL = setGridQuery(strHD, strDT);
        DataSet dsGrid = dbAgent.FillDataSet(strSQL, "tblGrid");
        getSumRowCol(dsGrid);
        
        dbAgent = null;
    }

    private string setGridQuery(string istrHD, string istrDT)
    {
        string strQN = "\"";
        string strSQL = "";
        string strYMD = ddlYear.SelectedValue + ddlMonth.SelectedValue;
        string strCom = ddlLocation1.SelectedValue;
        string strDep = ddlLocation2.SelectedValue;
        string strTyp = ddlStyle.SelectedValue;
        if (ddlLocation2.SelectedValue != "")
        {
            strSQL = @"
                       SELECT NVL(B.COM_NM,0) as "  + strQN + @"부문" + strQN + @", 
		                      NVL(B.DEPT_NM,0) as " + strQN + @"팀"   + strQN + @",
                              " + istrHD + @"
			            FROM (SELECT A.COM_NM, A.DEPT_NM," + istrDT + @"
			                    FROM (SELECT OT.SEM_ORG_CODE1_NAME as COM_NM,
		                                     OT.SEM_ORG_CODE2 as DEPT_CD,
                                             OT.SEM_ORG_CODE2_NAME as DEPT_NM,
                                             OP.EMP_CODE_T as GBN_CD,
                                             OP.EMP_CODE_NAME as GBN_NM,
                                             SUM(OP.EMP_PERSON) as EMP_CNT
                                        FROM SEM_ORGANIZATION_PERSON OP, 
                                             SEM_ORG_TABLE OT
                                       WHERE OP.EMP_GUBN_T = '" + strTyp + @"'
                                         AND OP.EMP_TEAM_T = OT.SEM_ORG_CODE2
                                         AND OP.EMP_DATE_T = '"+ strYMD +@"'
					                     AND OT.SEM_ORG_CODE1 = '" + strDep + @"'
					                     AND OT.SEM_ORG_LEVEL = '2'
                                         AND OT.SEM_DATE_T = (CASE WHEN '"+ strYMD +@"' < '200704' THEN '200604' ELSE '200704' END)
                                       GROUP BY OP.EMP_GROUP_T,
                                             OP.EMP_CODE_T,
                                             OP.EMP_CODE_NAME,
                                             OT.SEM_ORG_CODE1,
                                             OT.SEM_ORG_CODE1_NAME,
                                             OT.SEM_ORG_CODE2,
                                             OT.SEM_ORG_CODE2_NAME
						              ) A
					            ) B
			            GROUP BY B.COM_NM, B.DEPT_NM
                        ORDER BY B.COM_NM DESC";
        }
        else
        {
            strSQL = @"
                       SELECT NVL(B.COM_NM,0) as "  + strQN + @"사업장" + strQN + @", 
		                      NVL(B.DEPT_NM,0) as " + strQN + @"부문"   + strQN + @",
                              " + istrHD + @"
			             FROM (SELECT A.COM_NM, A.DEPT_NM," + istrDT + @"
				                 FROM (SELECT DECODE(OT.SEM_ORG_OFFICE,'01','울산','02','양산') as COM_NM,
					                          OT.SEM_ORG_CODE1 as DEPT_CD,
					                          OT.SEM_ORG_CODE1_NAME as DEPT_NM,
                                              OP.EMP_CODE_T as GBN_CD,
                                              OP.EMP_CODE_NAME as GBN_NM,
                                              SUM(OP.EMP_PERSON) as EMP_CNT
                                         FROM SEM_ORGANIZATION_PERSON OP, 
                                              SEM_ORG_TABLE OT
                                        WHERE OP.EMP_GUBN_T = '" + strTyp + @"'
                                          AND OP.EMP_TEAM_T = OT.SEM_ORG_CODE3
                                          AND OT.SEM_ORG_OFFICE LIKE ( '" + strCom + @"' ||'%')
                                          AND OP.EMP_DATE_T = '" + strYMD + @"'
                                          AND OT.SEM_DATE_T = (CASE WHEN '"+ strYMD +@"' < '200704' THEN '200604' ELSE '200704' END)
                                        GROUP BY OT.SEM_ORG_OFFICE,
                                              OP.EMP_CODE_T,
                                              OP.EMP_CODE_NAME,
				                              OT.SEM_ORG_CODE1,
					                          OT.SEM_ORG_CODE1_NAME 
						              ) A
					            ) B
			            GROUP BY B.COM_NM, B.DEPT_NM 
                        ORDER BY B.COM_NM DESC";
        }
        return strSQL;
    }

    private string GetBumunQuery() 
    {
        string strYMD = ddlYear.SelectedValue + ddlMonth.SelectedValue;
      {
        return @" SELECT SEM_ORG_CODE2 as ORG_CD,
                         SEM_ORG_CODE2_NAME as ORG_NM
                    FROM SEM_ORG_TABLE
                   WHERE SEM_ORG_LEVEL = '1'
                     AND SEM_ORG_PATH <> '99999'
                     AND SEM_DATE_T = '200704'
                   ORDER BY SEM_ORG_PATH";
      }
    }
    #endregion

    #region ============================================================================================합계구하기
    private void getSumRowCol(DataSet idsSet)
    {
        int intCol = idsSet.Tables[0].Columns.Count;
        int intRow = idsSet.Tables[0].Rows.Count;
        double[] arrCol = new double[intCol - 2];
        double[] arrRow = new double[intRow];

        ///////////////////////////////////////////////////////  Column Sum
        idsSet.Tables[0].Columns.Add("합계", typeof(int));

        for (int i = 0; i < intRow; i++)
        {
            for (int j = 2; j < intCol; j++)
            { 
                arrRow[i] += Convert.ToInt32(idsSet.Tables[0].Rows[i][j]);
            }
            idsSet.Tables[0].Rows[i]["합계"] = arrRow[i];
        }

        ///////////////////////////////////////////////////////  Row Sum
        intCol = idsSet.Tables[0].Columns.Count;
        intRow = idsSet.Tables[0].Rows.Count;

        DataRow drSum = idsSet.Tables[0].NewRow();
        drSum[0] = "합계";
        int intColSum = 0;
        for (int i = 2; i < intCol ; i++)
        {
            intColSum = 0;
            for (int j = 0; j < intRow; j++)
            {
                intColSum += Convert.ToInt32(idsSet.Tables[0].Rows[j][i]);
            }
            drSum[i] = intColSum;
        }
        idsSet.Tables[0].Rows.Add(drSum);

        UltraWebGrid1.Bands[0].ResetColumns();
        UltraWebGrid1.DataSource = idsSet.Tables[0].DefaultView;
        UltraWebGrid1.DataBind();


        drawGraph(idsSet);
    }
    #endregion

    #region ============================================================================================그래프그리기
    private void drawGraph(DataSet idsSet)
    {
        DataTable dtGrph = new DataTable();
        dtGrph.Columns.Add("COL_CNAME", typeof(string));
        dtGrph.Columns.Add("COL_RNAME", typeof(string));
        dtGrph.Columns.Add("COL_COUNT", typeof(int));
        dtGrph.Columns.Add("COL_RATE", typeof(double));
        DataRow drGrph = null;

        int intCol = idsSet.Tables[0].Columns.Count;
        int intRow = idsSet.Tables[0].Rows.Count;
        string strGbn = "";

        double intSum = 0.0;
        double intCnt = 0.0;

        intSum = double.Parse(idsSet.Tables[0].Rows[intRow - 1][intCol - 1].ToString());
        if (intSum != 0)
        {
            for (int i = 0; i < intRow; i++)
            {

                strGbn = idsSet.Tables[0].Rows[i][0].ToString();
                if (strGbn.Equals("합계"))
                {
                    for (int j = 2; j < intCol - 1; j++)
                    {
                        drGrph = dtGrph.NewRow();
                        intCnt = double.Parse(idsSet.Tables[0].Rows[i][j].ToString());
                        drGrph["COL_CNAME"] = idsSet.Tables[0].Columns[j].ColumnName.ToString();
                        drGrph["COL_RNAME"] = idsSet.Tables[0].Columns[j].ColumnName.ToString() + "(" + Math.Round(((intCnt / intSum) * 100), 1) + "%)";
                        drGrph["COL_COUNT"] = intCnt;
                        drGrph["COL_RATE"] = Math.Round(((intCnt / intSum) * 100), 2);
                        dtGrph.Rows.Add(drGrph);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < intRow; i++)
            {

                strGbn = idsSet.Tables[0].Rows[i][0].ToString();
                if (strGbn.Equals("합계"))
                {
                    for (int j = 2; j < intCol - 1; j++)
                    {
                        drGrph = dtGrph.NewRow();
                        intCnt = double.Parse(idsSet.Tables[0].Rows[i][j].ToString());
                        drGrph["COL_CNAME"] = idsSet.Tables[0].Columns[j].ColumnName.ToString();
                        drGrph["COL_RNAME"] = idsSet.Tables[0].Columns[j].ColumnName.ToString() + "(0%)";
                        drGrph["COL_COUNT"] = intCnt;
                        drGrph["COL_RATE"] = 0;
                        dtGrph.Rows.Add(drGrph);
                    }
                }
            }
        }
        setGrph(dtGrph);
    }

    private void setGrph(DataTable idtSet)
    {
        DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 300, 290
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
        DundasCharts.DundasChartBase(Chart2, ChartImageType.Flash, 500, 290
            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
            , Color.FromArgb(0xFF, 0xFF, 0xFE)
            , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
            , -1
            , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", "매출비중", null, SeriesChartType.Pie, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series series2 = DundasCharts.CreateSeries(Chart2, "Series2", "Default", "계획", null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        series1.FontColor = Color.White;
        Chart1.DataSource = idtSet.DefaultView;
        Chart1.Series[series1.Name].ValueMemberX = "COL_RNAME";
        Chart1.Series[series1.Name].ValueMembersY = "COL_RATE";
        Chart1.DataBind();

        Chart2.DataSource = idtSet.DefaultView;
        Chart2.Series[series2.Name].ValueMemberX = "COL_CNAME";
        Chart2.Series[series2.Name].ValueMembersY = "COL_COUNT";
        Chart2.DataBind();
    
    }
    #endregion

    #region ============================================================================================이벤트
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        setGridGrph();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int intWidCol = e.Layout.Bands[0].Columns.Count - 3;
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            if (i < 2)
            {
                e.Layout.Bands[0].Columns[i].Width = 100;
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            }
            else
            {
                e.Layout.Bands[0].Columns[i].Width = (intWidCol==0) ? 520 : Convert.ToInt32((520/intWidCol));
                e.Layout.Bands[0].Columns[i].Format = "#,##0";
                e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
        e.Layout.Bands[0].Columns[0].MergeCells = true;
    }
    #endregion
}
