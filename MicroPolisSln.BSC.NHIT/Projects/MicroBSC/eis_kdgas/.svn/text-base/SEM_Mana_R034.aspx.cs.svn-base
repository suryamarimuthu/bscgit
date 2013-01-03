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

public partial class eis_SEM_Mana_R034 : EISPageBase
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
            int intLP;
            int iniYY;

            int intYY = objDT.Year;

            this.cboYY.Items.Clear();

            for (iniYY = 2000; iniYY <= intYY; iniYY++)
            {
                strYY = iniYY.ToString();
                this.cboYY.Items.Add(new ListItem(strYY, strYY));
            }

            cboYY.SelectedValue = intYY.ToString();
            /// </summary>
        }

        lblYear.Text = cboYY.SelectedItem.Text + "年 ";
        lblNextYear.Text = Convert.ToString(int.Parse(cboYY.SelectedItem.Text) + 1) + "年 ";

    }

    private void _queryGrid()
    {
        string strCYY = this.cboYY.SelectedValue;

        string strQtn = "\"";
        string sqlGrid = "";
        sqlGrid = @"
                 SELECT CM.SEM_CODE2_NAME                         as " + strQtn + @"지역             " + strQtn + @",
                        CE.COMP_COOKING_HEATING                   as " + strQtn + @"취사용           " + strQtn + @",
                        CE.COMP_HOUSE_HEATING                     as " + strQtn + @"주택난방         " + strQtn + @",
                        CE.COMP_CENTRAL_HEATING                   as " + strQtn + @"중앙난방         " + strQtn + @",
                        CE.COMP_WORK_HEATING                      as " + strQtn + @"업무난방         " + strQtn + @",
                        CE.COMP_BUSINESS_HEATING_1                as " + strQtn + @"영업용1          " + strQtn + @",
                        CE.COMP_BUSINESS_HEATING_2                as " + strQtn + @"영업용2          " + strQtn + @",
                        CE.COMP_AIR_CONDITION                     as " + strQtn + @"냉방용(5~9월)    " + strQtn + @",
                        CE.COMP_INDUSTRY_HEATING_1                as " + strQtn + @"산업용1          " + strQtn + @",
                        CE.COMP_INDUSTRY_HEATING_2                as " + strQtn + @"산업용2          " + strQtn + @",
                        CE.COMP_STEAM_HEATING_1                   as " + strQtn + @"열병합12~3월     " + strQtn + @",
                        CE.COMP_STEAM_HEATING_2                   as " + strQtn + @"열병합5~8월      " + strQtn + @",
                        CE.COMP_STEAM_HEATING_3                   as " + strQtn + @"열병합4,9~11월   " + strQtn + @",
                        CE.COMP_AREA_HEATING_1                    as " + strQtn + @"지역난방12~3월   " + strQtn + @",
                        CE.COMP_AREA_HEATING_2                    as " + strQtn + @"지역난방5~8월    " + strQtn + @",
                        CE.COMP_AREA_HEATING_3                    as " + strQtn + @"지역난방4,9~11월 " + strQtn + @",
                        CE.COMP_TRANSPORT                         as " + strQtn + @"수송용           " + strQtn + @",
                        CE.COMP_BASE_CHARGE_1                     as " + strQtn + @"기본요금_개별    " + strQtn + @",
                        CE.COMP_BASE_CHARGE_2                     as " + strQtn + @"기본요금_지역    " + strQtn + @",
                        CE.COMP_INVESTMENT                        as " + strQtn + @"투자재원         " + strQtn + @",
                        CE.COMP_AVG_COST                          as " + strQtn + @"평균단가         " + strQtn + @",
                        CE.COMP_INVESTMENT + CE.COMP_AVG_COST     as " + strQtn + @"공급비용         " + strQtn + @"
                   FROM SEM_COMPETITOR_EXPENSE CE,
                        SEM_CODE_MASTER CM
                  WHERE CE.COMP_DATE_T = '"+strCYY+@"'
                    AND CM.SEM_CODE1_T = '32'
                    AND CE.COMP_GUBN_CODE_T = CM.SEM_CODE2_T
                 ";

        DataSet dsGrid = new DataSet();
        OracleConnection _connection = new OracleConnection();
        _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        OracleDataAdapter daGrid = new OracleDataAdapter(sqlGrid, _connection);
        daGrid.Fill(dsGrid);

        UltraWebGrid1.DataSource = dsGrid;
        UltraWebGrid1.DataBind();
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();
        e.Layout.Bands[0].Reset();

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;

            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "구분";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "주택.난방용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "일반용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "냉방용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "산업용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "열병합용(상:공동, 하:특정건물)";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "지역난방";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 13;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "수송용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 16;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "기본요금";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 17;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "투자재원";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 19;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평균단가";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 20;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "공급비용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 21;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(22);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[7].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[16].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 16;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[19].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 19;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[20].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 20;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[21].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 21;
        ch.RowLayoutColumnInfo.SpanY = 2;

        int intCol = UltraWebGrid1.Bands[0].Columns.Count;
        for (int i = 1; i < intCol; i++)
        {
            e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.Bands[0].Columns[i].Width = 80;
            e.Layout.Bands[0].Columns[i].Format = "#,##0.#0";
        }
    }
}
