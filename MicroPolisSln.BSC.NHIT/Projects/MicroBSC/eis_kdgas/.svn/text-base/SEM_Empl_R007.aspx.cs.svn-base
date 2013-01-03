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

public partial class eis_SEM_Empl_R007 : EISPageBase
{
    private DBAgent dbAgent = null;
    protected string MONTH = "";

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
 
            this.ddlYear.Items.Clear();
            this.ddlMonth.Items.Clear();


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

                this.ddlMonth.Items.Add(new ListItem(strMM, strMM));
                if (intMM -1  == intLP)
                {
                    this.ddlMonth.SelectedValue = strMM;
                }
            }

           
            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.ddlYear.Items.Add(new ListItem(strYY, strYY));
            }
            this.ddlYear.SelectedIndex = ddlYear.Items.Count - 1;


            ddlTerm.Items.Add(new ListItem("당월", "MS"));
            ddlTerm.Items.Add(new ListItem("누계", "TS"));
            ddlTerm.SelectedIndex = 0;
            DataBindingObjects();
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        MONTH = ddlMonth.SelectedValue;
    }

    private void GridBinding(string yearStr, string monthStr, string type)
    {
        DataTable dtGrid = GetGridDataTable(yearStr, monthStr, type);
        UltraWebGrid1.Bands[0].ResetColumns();
        UltraWebGrid1.DataSource = dtGrid;
        UltraWebGrid1.DataBind();
        
        if (dtGrid.Rows.Count > 0)
        {
            this.setGraph(dtGrid);
        }
    }
    private DataTable GetGridDataTable(string yearStr, string monthStr, string type)
    {
        string query = GetQuery(yearStr, monthStr, type);

        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        
        return ds.Tables[0];
    }

    
    private void DataBindingObjects() 
    {
        string yearStr      = ddlYear.SelectedValue;
        string monthStr     = ddlMonth.SelectedValue;
        string type         = rBtnType.SelectedValue;

        GridBinding(yearStr, monthStr, type);
        
    }

    private void setGraph(DataTable dtGrph)
    {
             DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 300
                 , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                 , Color.FromArgb(0xFF, 0xFF, 0xFE)
                 , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                 , -1
                 , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
             
             string strLgdText = rBtnType.SelectedItem.Text + "평균학점" + " (" + ddlTerm.SelectedItem.Text +")";
             
             Series series1 = DundasCharts.CreateSeries(Chart1, "Series1", "Default", strLgdText, null, SeriesChartType.Column, 1, Color.FromArgb(0x5A, 0x7D, 0xDE), Color.FromArgb(0x4A, 0x58, 0x7E), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
             
             Chart1.DataSource = dtGrph.DefaultView;
             series1.ValueMembersY = (ddlTerm.SelectedValue.Equals("MS")) ? "평균학점" : "평균 학점";
             series1.ValueMemberX = (rBtnType.SelectedValue.Equals("1")) ? "부문명" : "팀명";
             Chart1.DataBind();
             
             DundasAnimations.DundasChartBase(Chart1, AnimationTheme.None, -1, -1, false, 1);
             DundasAnimations.GrowingAnimation(Chart1, series1, 0.0, 3.0, false);
    }

    private string GetQuery(string yearStr, string monthStr, string type)
    {
        string query = "";
        string strQN = "\"";

        if(type.Equals("2"))
        {
            query = @" SELECT NVL(A.NAME1,0)   as " + strQN + @"부문명" + strQN + @",                                      
                              NVL(A.NAME2,0)   as " + strQN + @"팀명" + strQN + @",                                        
                              NVL(A.POINT,0)   as " + strQN + @"총학점" + strQN + @",                                      
                              NVL(A.ECNT,0)    as " + strQN + @"인원수" + strQN + @",                                       
                              NVL(A.VPOINT,0)  as " + strQN + @"평균학점" + strQN + @",
                              NVL(A.TPOINT,0)  as " + strQN + @"점 수" + strQN + @",      
                              NVL(A.TCNT,0)    as " + strQN + @"인원 수" + strQN + @",  
                              NVL(A.VTPOINT,0) as " + strQN + @"평균 학점" + strQN + @",  
                              SEM_ORG_PATH      
                        FROM  SEM_ORG_TABLE,
                             (SELECT B.CODE1  as NAME1,  
                                     B.CODE2  as NAME2,
                                     SUM(B.MPOINT) as POINT,
                                     SUM(B.ECNT)   as ECNT,
                                     DECODE(SUM(B.ECNT),0,0, ROUND(SUM(B.MPOINT)/SUM(B.ECNT),2)) as VPOINT,
                                     SUM(B.TPOINT) as TPOINT,
                                     SUM(B.ECNT)   as TCNT,
                                     DECODE(SUM(B.ECNT),0,0, ROUND(SUM(B.TPOINT)/SUM(B.ECNT),2)) as VTPOINT
                               FROM (SELECT ORG.SEM_ORG_CODE1_NAME   as CODE1,
                                            ORG.SEM_ORG_CODE2_NAME   as CODE2,
                                            SUM(POINT.EMP_POINT)     as MPOINT,
                                            0                        as ECNT,
                                            SUM(POINT.EMP_SUM_POINT) as TPOINT 
                                       FROM SEM_AVG_POINT POINT,
                                            SEM_ORG_TABLE ORG
                                      WHERE POINT.EMP_DATE_T = '" + yearStr + monthStr + @"'
                                        AND ORG.SEM_DATE_T = (CASE WHEN '" + yearStr + monthStr + @"' < '200704' THEN '200604' ELSE '200704' END)
                                        AND POINT.EMP_OFFICE_T = ORG.SEM_ORG_OFFICE
                                        AND POINT.EMP_TEAM_T   = ORG.SEM_ORG_CODE3
                                      GROUP BY ORG.SEM_ORG_CODE1_NAME,
                                               ORG.SEM_ORG_CODE2_NAME   
                                      UNION ALL
                                     SELECT ORG.SEM_ORG_CODE1_NAME   as CODE1,
                                            ORG.SEM_ORG_CODE2_NAME   as CODE2,
                                            0                        as MPOINT,
                                            DECODE(ORG.SEM_ORG_CODE2_NAME ,'HR팀',SUM(OP.EMP_PERSON) -1,SUM(OP.EMP_PERSON))  as ECNT,
                                            0                        as TPOINT 
                                       FROM SEM_ORG_TABLE ORG,
                                            SEM_ORGANIZATION_PERSON OP
                                      WHERE OP.EMP_DATE_T(+) = '" + yearStr + monthStr + @"'
                                        AND ORG.SEM_DATE_T = (CASE WHEN '" + yearStr + monthStr + @"' < '200704' THEN '200604' ELSE '200704' END)
                                        AND OP.EMP_GUBN_T(+)   = '2'
										AND OP.EMP_CODE_T BETWEEN '1' AND '7'
                                        AND OP.EMP_TEAM_T(+)   = ORG.SEM_ORG_CODE3
                                      GROUP BY ORG.SEM_ORG_CODE1_NAME,
                                               ORG.SEM_ORG_CODE2_NAME ) B
                               GROUP BY B.CODE1, B.CODE2) A
                         WHERE SEM_ORG_LEVEL =  '2'
                           AND SEM_ORG_CODE1_NAME = A.NAME1
                           AND SEM_ORG_CODE2_NAME = A.NAME2
                           AND SEM_DATE_T = (CASE WHEN '" + yearStr + monthStr + @"' < '200704' THEN '200604' ELSE '200704' END)
                           AND sem_org_path<>99999      
                         ORDER BY SEM_ORG_PATH  ";
        }
        else if (type.Equals("1"))
        {
            query = @" SELECT  
                              NVL(A.NAME,0)     as " + strQN + @"부문명" + strQN + @",  
                              NVL(A.POINT,0)    as " + strQN + @"점수" + strQN + @",
                              NVL(A.ECNT,0)     as " + strQN + @"인원수" + strQN + @",
                              NVL(A.VPOINT,0)   as " + strQN + @"평균학점" + strQN + @",
                              NVL(A.TPOINT,0)   as " + strQN + @"점 수" + strQN + @",
                              NVL(A.TCNT,0)     as " + strQN + @"인원 수" + strQN + @",
                              NVL(A.VTPOINT ,0) as " + strQN + @"평균 학점" + strQN + @",
                              SEM_ORG_PATH   
                        FROM  SEM_ORG_TABLE,
                              (SELECT OT.SEM_ORG_CODE1_NAME  as NAME,
                                      SUM(nvl(AP.EMP_POINT,0))  as POINT,
                                      SUM(nvl(OP.EMP_PERSON,0)) as ECNT,
                                      ROUND(DECODE(SUM(OP.EMP_PERSON),0,0,ROUND(( SUM(AP.EMP_POINT)/ SUM(OP.EMP_PERSON) ), 2)),2) as VPOINT,
                                      SUM(AP.EMP_SUM_POINT) as TPOINT,
                                      SUM(OP.EMP_PERSON)    as TCNT,
                                      ROUND(DECODE(SUM(OP.EMP_PERSON),0,0,ROUND((SUM(AP.EMP_SUM_POINT)/ SUM(OP.EMP_PERSON)), 2)),2) as VTPOINT
                                 FROM SEM_AVG_POINT AP,
                                      SEM_ORG_TABLE OT,(SELECT EMP_TEAM_T , SUM(EMP_PERSON) EMP_PERSON
                                                                     FROM SEM_ORGANIZATION_PERSON OP
                                                                    WHERE EMP_DATE_T = '" + yearStr + monthStr + @"'
                                                                      AND EMP_GUBN_T   = '2'
																	  AND EMP_CODE_T BETWEEN '1' AND '7'
                                                                    GROUP BY EMP_TEAM_T) OP
                                WHERE AP.EMP_DATE_T(+) = '" + yearStr + monthStr + @"'
                                  AND AP.EMP_TEAM_T(+) = OT.SEM_ORG_CODE3 
                                  AND OP.EMP_TEAM_T(+) = OT.SEM_ORG_CODE3
                                  AND OT.SEM_DATE_T = (CASE WHEN '" + yearStr + monthStr + @"' < '200704' THEN '200604' ELSE '200704' END)
                                GROUP BY OT.SEM_ORG_CODE1_NAME) A
                          WHERE SEM_ORG_LEVEL = '1'
                            AND SEM_ORG_CODE1_NAME = A.NAME
                            AND SEM_DATE_T = (CASE WHEN '" + yearStr + monthStr + @"' < '200704' THEN '200604' ELSE '200704' END)
                            AND sem_org_path<>99999
                           ORDER BY SEM_ORG_PATH  ";
                  
        }
                
        return query;
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        
        string strSum = e.Row.Cells[1].Value.ToString().Trim();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;
        e.Layout.Bands[0].HeaderLayout.Reset();
        //e.Layout.Bands[0].Reset();

        e.Layout.Bands[0].Columns[0].MergeCells = true;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }

        if (rBtnType.SelectedValue.Equals("2"))
        {
            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "조직";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanX = 2;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "당월";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 2;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "누계";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 5;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i < 2)
                {
                    e.Layout.Bands[0].Columns[i].Width = 120;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                }
                else if (i > 0 && i < 8)
                {
                    e.Layout.Bands[0].Columns[i].Width = 90;
                    e.Layout.Bands[0].Columns[i].Format = (i == 3 || i == 6) ? "#,##0" : "#,##0.#";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                else
                {
                   e.Layout.Bands[0].Columns[i].Hidden = true;
                }
            }
        }
        else
        {
            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "조직";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanX = 1;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "당월";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 1;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = "누계";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 4;
            ch.RowLayoutColumnInfo.SpanX = 3;
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].HeaderLayout.Add(ch);

            ch = e.Layout.Bands[0].Columns[0].Header;
            ch.Caption = "부문명";
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = 0;
            ch.RowLayoutColumnInfo.SpanY = 2;

            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                if (i < 1)
                {
                    e.Layout.Bands[0].Columns[i].Width = 240;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                }
                else if (i > 0 && i < 7)     
                {
                    e.Layout.Bands[0].Columns[i].Width = 90;
                    e.Layout.Bands[0].Columns[i].Format = (i == 2 || i == 5) ? "#,##0" : "#,##0.#";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                }  
                else
                {
                   e.Layout.Bands[0].Columns[i].Hidden = true;
                }
            }
        }
    }
}
