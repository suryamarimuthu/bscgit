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
using MicroBSC.Data;
using System.Text;

public partial class eis_eis0002 : AppPageBase
{
    DBAgent dbAgent = null;

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

            for (int i = 1999; i <= (dtNow.Year + 1); i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                sMonth = (i < 10 ? "0" + i.ToString() : i.ToString());
                this.ddlMonth.Items.Add(new ListItem(sMonth, sMonth));
            }

            this.ddlGong.Items.Add(new ListItem("전체", ""));
            this.ddlGong.Items.Add(new ListItem("1공장", "1"));
            this.ddlGong.Items.Add(new ListItem("2공장", "2"));
            this.ddlGong.Items.Add(new ListItem("3공장", "3"));

            this.ddlItem.DataSource = GetDTItems();
            this.ddlItem.DataTextField = "ITMJ_NAME";
            this.ddlItem.DataValueField = "ITMJ_CD";
            this.ddlItem.DataBind();

            // 이승주 추가
            //System.DateTime date = System.DateTime.Now.AddMonths(-1).AddDays(-15);
            DateTime date = System.DateTime.Now;  // 생산현황에서는 현재월로 조건 셋팅
            PageUtility.FindByValueDropDownList(ddlYear, date.Year.ToString());
            PageUtility.FindByValueDropDownList(ddlMonth, date.Month.ToString().PadLeft(2, '0'));
        }

        private void InitControlEvent()
        {

        }

        private void SetPageData()
        {
            BindingPieChart(ddlYear.SelectedValue + ddlMonth.SelectedValue);
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
        /// <summary>
        /// GetDTItems
        ///     : 조회조건용 제품 추출
        /// </summary>
        /// <returns></returns>
        private DataTable GetDTItems()
        {
            string sQuery = "";

            sQuery += "SELECT ''       ITMJ_CD,     \n";
            sQuery += "       '전체'   ITMJ_NAME    \n";
            sQuery += "UNION ALL                    \n";
            sQuery += "SELECT DISTINCT              \n";
            sQuery += "       ITMJ_CD,              \n";
            sQuery += "       ITMJ_NAME             \n";
            sQuery += "  FROM D_ITEM_JAEGO          \n";

            DataTable dtRet = new DataTable();
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsItems = gDbAgentEIS.Fill(sQuery);

            if (dsItems.Tables.Count > 0)
                dtRet = dsItems.Tables[0];

            return dtRet;
        }

        private DataTable GetDTItems(string asItem)
        {
            string sQuery = "";

            sQuery += "SELECT DISTINCT              \n";
            sQuery += "       ITMJ_CD,              \n";
            sQuery += "       ITMJ_NAME             \n";
            sQuery += "  FROM D_ITEM_JAEGO          \n";
            sQuery += " WHERE 1=1                   \n";

            if (asItem != "")
                sQuery += "   AND ITMJ_CD   = '" + asItem + "'  \n";

            DataTable dtRet = new DataTable();
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsItems = gDbAgentEIS.Fill(sQuery);

            if (dsItems.Tables.Count > 0)
                dtRet = dsItems.Tables[0];

            return dtRet;
        }
    private string GetLastDay()
    {
        string sYear = PageUtility.GetByValueDropDownList(ddlYear);
        string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
        string sQuery = @"SELECT 	DISTINCT TOP 1	
	                                B.DayNumberOfMonth
                            FROM 	CA_FT_JAEGO A,
	                                D_TIME_ILJA B,
	                                D_ITEM_JAEGO C
                            WHERE   B.TM_IDX=A.TIME_IDX
                            AND     B.yyyy_mm=" + sYear + sMonth + @"
                            AND     B.DayNumberOfMonth between 1 and 31
                            AND     C.ITMJ_IDX=A.ITEM_IDX
                        ORDER BY    B.DayNumberOfMonth DESC ";
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
        DataTable dtTable = dbAgent.FillDataSet(sQuery, "Data").Tables[0];
        if (dtTable.Rows.Count > 0)
        {
            return dtTable.Rows[0][0].ToString();
        }
        else
        {
            return "1";
        }
    
    }
        // 이승주 추가 (재고 파이 차트)
        private DataTable GetChartDataTable(string yearStr)
        {
            string query = GetPieQuery(yearStr);
            dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            return dbAgent.FillDataSet(query, "Data").Tables[0];
        }
        private string GetPieQuery(string dateStr)
        {
            DateTime date = System.DateTime.Now;
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            string sGong = PageUtility.GetByValueDropDownList(ddlGong);


            string sLastDay = GetLastDay();
            
            string sQuery = "";
            sQuery += "SELECT v_YMD,v_Day,ITMJ_CD,ITMJ_NAME,v_JgoQty                                                    \n";
            sQuery += "FROM     (                                                                                       \n";
            sQuery += "SELECT a.v_Year + a.v_Month + a.v_Day v_YMD,                                                     \n";
            sQuery += "       a.v_Day,                                                                                  \n";
            sQuery += "       a.ITMJ_CD,                                                                                \n";
            sQuery += "       a.ITMJ_NAME,                                                                              \n";
            sQuery += "       a.v_JgoQty                                                                                \n";
            sQuery += "  FROM (                                                                                         \n";
            sQuery += "       SELECT CONVERT(VARCHAR, a.Year) v_Year,                                                   \n";
            sQuery += "              CASE WHEN a.Month < 10 THEN '0' + CONVERT(VARCHAR, a.Month)                        \n";
            sQuery += "                                     ELSE CONVERT(VARCHAR, a.Month)                              \n";
            sQuery += "              END v_Month,                                                                       \n";
            sQuery += "              CASE WHEN a.DayNumberOfMonth < 10 THEN '0' + CONVERT(VARCHAR, a.DayNumberOfMonth)  \n";
            sQuery += "                                                ELSE CONVERT(VARCHAR, a.DayNumberOfMonth)        \n";
            sQuery += "              END v_Day,                                                                         \n";
            sQuery += "              b.ITMJ_CD,                                                                         \n";
            sQuery += "              b.ITMJ_NAME,                                                                       \n";
            sQuery += "              SUM(c.JGO_QTY) v_JgoQty                                                            \n";
            sQuery += "         FROM D_TIME_ILJA a,                                                                     \n";
            sQuery += "              D_ITEM_JAEGO b,                                                                    \n";
            sQuery += "              CA_FT_JAEGO  c                                                                     \n";
            sQuery += "        WHERE c.TIME_IDX = a.TM_IDX                                                              \n";
            sQuery += "          AND c.ITEM_IDX = b.ITMJ_IDX                                                             \n";
            sQuery += "          AND a.Year = " + sYear + "  -- 년                                                      \n";
            sQuery += "          AND a.Month= " + Convert.ToInt32(sMonth) + "     -- 월                                 \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일                                       \n";
            
            if (sGong != "")
                sQuery += "          AND c.GONG_IDX = " + sGong + " -- 공장                                                              \n";

            sQuery += "        GROUP by                                                                                 \n";
            sQuery += "              a.Year,                                                                            \n";
            sQuery += "              a.Month,                                                                           \n";
            sQuery += "              a.DayNumberOfMonth,                                                                \n";
            sQuery += "              b.ITMJ_CD,                                                                         \n";
            sQuery += "              b.ITMJ_NAME                                                                        \n";
            sQuery += "       ) a                                                                                       \n";
            sQuery += "       ) G                                                                                       \n";
            sQuery += "       WHERE v_Day=(" + sLastDay + ")                                              \n"; 
            sQuery += "       ORDER BY v_Day DESC                                                                       \n";


            return sQuery;

        }

        private void BindingPieChart(string yearStr)
        {
            DataRow drNew = null;
            DataTable dataTable = new DataTable();
            DataTable dtTable = GetDTChart("전체");
            DataRow[] draDefault = null;
            DataTable dtItems = GetDTItems("");
            draDefault = dtTable.Select(
                                        "YMD='" + GetLastDay() + "'"
                                        );

            if (draDefault.Length == 0)
            {
                dataTable.Columns.Add("Gubun", typeof(string));
                dataTable.Columns.Add("카프로락탐", typeof(double));
                dataTable.Columns.Add("박편락탐", typeof(double));
                dataTable.Columns.Add("유안벌크", typeof(double));
                dataTable.Columns.Add("싸이크로헥산", typeof(double));
                dataTable.Columns.Add("아논", typeof(double));

                drNew = dataTable.NewRow();
                drNew["Gubun"] = ddlGong.SelectedItem.Text;
                drNew["카프로락탐"] = 0;
                drNew["박편락탐"] = 0;
                drNew["유안벌크"] = 0;
                drNew["싸이크로헥산"] = 0;
                drNew["아논"] = 0;
                dataTable.Rows.Add(drNew);
                Chart5.DataSource = dataTable;

                DundasCharts.DundasChartBase(Chart5, ChartImageType.Flash, 800, 235
                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                    , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                    , -1
                    , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

                Series srSeries1 = DundasCharts.CreateSeries(Chart5, "", "Default", "카프로락탐", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries1.ValueMembersY = "카프로락탐";
                DundasAnimations.GrowingAnimation(Chart5, srSeries1, 0, 0 + 1, true);
                srSeries1.ShowLabelAsValue = true;
                srSeries1.ToolTip = "#VALY{N0}";
                srSeries1.LabelFormat = "N0";

                Series srSeries2 = DundasCharts.CreateSeries(Chart5, "", "Default", "박편락탐", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries2.ValueMembersY = "박편락탐";
                DundasAnimations.GrowingAnimation(Chart5, srSeries2, 1, 1 + 1, true);
                srSeries2.ShowLabelAsValue = true;
                srSeries2.ToolTip = "#VALY{N0}";
                srSeries2.LabelFormat = "N0";

                Series srSeries3 = DundasCharts.CreateSeries(Chart5, "", "Default", "유안벌크", null, SeriesChartType.Column, 1, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries3.ValueMembersY = "유안벌크";
                DundasAnimations.GrowingAnimation(Chart5, srSeries3, 2, 2 + 1, true);
                srSeries3.ShowLabelAsValue = true;
                srSeries3.ToolTip = "#VALY{N0}";
                srSeries3.LabelFormat = "N0";

                Series srSeries4 = DundasCharts.CreateSeries(Chart5, "", "Default", "싸이크로헥산", null, SeriesChartType.Column, 1, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries4.ValueMembersY = "싸이크로헥산";
                DundasAnimations.GrowingAnimation(Chart5, srSeries4, 3, 3 + 1, true);
                srSeries4.ShowLabelAsValue = true;
                srSeries4.ToolTip = "#VALY{N0}";
                srSeries4.LabelFormat = "N0";

                Series srSeries5 = DundasCharts.CreateSeries(Chart5, "", "Default", "아논", null, SeriesChartType.Column, 1, GetChartColor(4), GetChartColor(4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries5.ValueMembersY = "아논";
                DundasAnimations.GrowingAnimation(Chart5, srSeries5, 4, 4 + 1, true);
                srSeries5.ShowLabelAsValue = true;
                srSeries5.ToolTip = "#VALY{N0}";
                srSeries5.LabelFormat = "N0";

                srSeries3.ValueMemberX = "Gubun";
                srSeries3.YAxisType = AxisType.Secondary;
                Chart5.Legends[0].Position.Auto = true;

                string sChartArea = Chart5.Series[srSeries1.Name].ChartArea;
                Chart5.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
                Chart5.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

                Font font1 = new Font("Gulim", 9, FontStyle.Regular);
                Legend legend = DundasCharts.CreateLegend(Chart5, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);

                SetVisibleZeroPoint(Chart5, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));
                return;
            }

            if (dtTable.Columns.Count != 2)
            {
            
                dataTable.Columns.Add("Gubun", typeof(string));
                for (int i = 1; i < dtTable.Columns.Count; i++)
                {
                    dataTable.Columns.Add(dtTable.Columns[i].ColumnName, typeof(double));
                }
                drNew = dataTable.NewRow();
                drNew["Gubun"] = ddlGong.SelectedItem.Text;


                for (int i = 1; i < dtTable.Columns.Count; i++)
                {
                    drNew[i] = Math.Round(Convert.ToDouble(draDefault[0][i]), 0);
                }

                dataTable.Rows.Add(drNew);


                Chart5.DataSource = dataTable;

                DundasCharts.DundasChartBase(Chart5, ChartImageType.Flash, 800, 235
                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                    , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                    , -1
                    , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

            
                Series srSeries1 = DundasCharts.CreateSeries(Chart5, "", "Default", "카프로락탐", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries1.ValueMembersY = "카프로락탐";
                DundasAnimations.GrowingAnimation(Chart5, srSeries1, 0, 0 + 1, true);
                srSeries1.ShowLabelAsValue = true;
                srSeries1.ToolTip = "#VALY{N0}";
                srSeries1.LabelFormat = "N0";

                Series srSeries2 = DundasCharts.CreateSeries(Chart5, "", "Default", "박편락탐", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries2.ValueMembersY = "박편락탐";
                DundasAnimations.GrowingAnimation(Chart5, srSeries2, 1, 1 + 1, true);
                srSeries2.ShowLabelAsValue = true;
                srSeries2.ToolTip = "#VALY{N0}";
                srSeries2.LabelFormat = "N0";

                Series srSeries3 = DundasCharts.CreateSeries(Chart5, "", "Default", "유안벌크", null, SeriesChartType.Column, 1, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries3.ValueMembersY = "유안벌크";
                DundasAnimations.GrowingAnimation(Chart5, srSeries3, 2, 2 + 1, true);
                srSeries3.ShowLabelAsValue = true;
                srSeries3.ToolTip = "#VALY{N0}";
                srSeries3.LabelFormat = "N0";

                Series srSeries4 = DundasCharts.CreateSeries(Chart5, "", "Default", "싸이크로헥산", null, SeriesChartType.Column, 1, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries4.ValueMembersY = "싸이크로헥산";
                DundasAnimations.GrowingAnimation(Chart5, srSeries4, 3, 3 + 1, true);
                srSeries4.ShowLabelAsValue = true;
                srSeries4.ToolTip = "#VALY{N0}";
                srSeries4.LabelFormat = "N0";

                Series srSeries5 = DundasCharts.CreateSeries(Chart5, "", "Default", "아논", null, SeriesChartType.Column, 1, GetChartColor(4), GetChartColor(4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries5.ValueMembersY = "아논";
                DundasAnimations.GrowingAnimation(Chart5, srSeries5, 4, 4 + 1, true);
                srSeries5.ShowLabelAsValue = true;
                srSeries5.ToolTip = "#VALY{N0}";
                srSeries5.LabelFormat = "N0";

                srSeries3.ValueMemberX = "Gubun";
                srSeries3.YAxisType = AxisType.Secondary;
                Chart5.Legends[0].Position.Auto = true;

                string sChartArea = Chart5.Series[srSeries1.Name].ChartArea;
                Chart5.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
                Chart5.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

                Font font1 = new Font("Gulim", 9, FontStyle.Regular);
                Legend legend = DundasCharts.CreateLegend(Chart5, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
            }
            else
            {
                dataTable.Columns.Add("Gubun", typeof(string));
                for (int i = 1; i < dtTable.Columns.Count; i++)
                {
                    dataTable.Columns.Add(dtTable.Columns[i].ColumnName, typeof(double));
                }
                drNew = dataTable.NewRow();
                drNew["Gubun"] = ddlGong.SelectedItem.Text;


                for (int i = 1; i < dtTable.Columns.Count; i++)
                {
                    drNew[i] = Math.Round(Convert.ToDouble(draDefault[0][i]), 0);
                }

                dataTable.Rows.Add(drNew);


                Chart5.DataSource = dataTable;

                DundasCharts.DundasChartBase(Chart5, ChartImageType.Flash, 800, 235
                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                    , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                    , -1
                    , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

                Series srSeries5 = DundasCharts.CreateSeries(Chart5, "", "Default", dtTable.Columns[1].ColumnName, null, SeriesChartType.Column, 1, GetChartColor(GetChartInfo(dtTable.Columns[1].ColumnName)), GetChartColor(GetChartInfo(dtTable.Columns[1].ColumnName)), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
                srSeries5.ValueMembersY = dtTable.Columns[1].ColumnName;
                DundasAnimations.GrowingAnimation(Chart5, srSeries5, 2, 2 + 1, true);
                srSeries5.ShowLabelAsValue = true;
                srSeries5.ToolTip = "#VALY{N0}";
                srSeries5.LabelFormat = "N0";

                srSeries5.ValueMemberX = "Gubun";
                if (dtTable.Columns[1].ColumnName == "유안벌크")
                {
                    srSeries5.YAxisType = AxisType.Secondary;
                }
                Chart5.Legends[0].Position.Auto = true;

                string sChartArea = Chart5.Series[srSeries5.Name].ChartArea;
                Chart5.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
                Chart5.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";

                Font font1 = new Font("Gulim", 9, FontStyle.Regular);
                Legend legend = DundasCharts.CreateLegend(Chart5, "Default", Color.Transparent, Color.Empty, Color.Empty, font1, true, -1, -1, -1, -1);
           
            }

            SetVisibleZeroPoint(Chart5, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));
        }

    #endregion

        #region 일별 재고량

        private void ChartBinding()
        {
            DateTime date = System.DateTime.Now;
            string sItem = PageUtility.GetByValueDropDownList(ddlItem);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            DataTable dtItems = GetDTItems(sItem);    // 선택된 아이템
            DataTable dt = GetDTChart("일일");
            Chart1.DataSource = dt;

            #region 챠트 초기화
            DundasCharts.DundasChartBase(Chart1, ChartImageType.Flash, 800, 400
                , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                , Color.FromArgb(0xFF, 0xFF, 0xFE)
                , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
                , -1
                , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);
            #endregion

            // Title 생성
            FontStyle fontStyle = FontStyle.Bold;
            Chart1.Titles[0].Position.Auto = false;
            Chart1.ChartAreas["Default"].Axes[0].Title = ddlGong.SelectedItem.Text;
            Chart1.ChartAreas["Default"].Axes[0].TitleFont = new Font("Trebuchet MS", 12, fontStyle);

           

            //시리즈 생성
            //Series srArray0 = DundasCharts.CreateSeries(Chart1, "", "Default", "카프로락탐", null, SeriesChartType.Line, 3, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            ////srArray0.ValueMembersY = dtItems.Rows[0]["ITMJ_CD"] + "_QTY";
            //DatabaseBindingXY(srArray0, "YMD", dtItems.Rows[0]["ITMJ_CD"] + "_QTY", dt);
            //DundasAnimations.GrowingAnimation(Chart1, srArray0, 0, 0 + 1, true);
            //srArray0.MarkerStyle = GetMarkerStyle(0);
            //srArray0.ToolTip = "#VALY{N0}";

            //Series srArray1 = DundasCharts.CreateSeries(Chart1, "", "Default", "박편락탐", null, SeriesChartType.Line, 3, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            ////srArray1.ValueMembersY = dtItems.Rows[1]["ITMJ_CD"] + "_QTY";
            //DatabaseBindingXY(srArray1, "YMD", dtItems.Rows[1]["ITMJ_CD"] + "_QTY", dt);
            //DundasAnimations.GrowingAnimation(Chart1, srArray1, 1, 1 + 1, true);
            //srArray1.MarkerStyle = GetMarkerStyle(1);
            //srArray1.ToolTip = "#VALY{N0}";

            //Series srArray3 = DundasCharts.CreateSeries(Chart1, "", "Default", "싸이크로헥산", null, SeriesChartType.Line, 3, GetChartColor(3), GetChartColor(3), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            ////srArray3.ValueMembersY = dtItems.Rows[3]["ITMJ_CD"] + "_QTY";
            //DatabaseBindingXY(srArray3, "YMD", dtItems.Rows[3]["ITMJ_CD"] + "_QTY", dt);
            //DundasAnimations.GrowingAnimation(Chart1, srArray3, 3, 3 + 1, true);
            //srArray3.MarkerStyle = GetMarkerStyle(3);
            //srArray3.ToolTip = "#VALY{N0}";

            //Series srArray4 = DundasCharts.CreateSeries(Chart1, "", "Default", "아논", null, SeriesChartType.Line, 3, GetChartColor(4), GetChartColor(4), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            ////srArray4.ValueMembersY = dtItems.Rows[4]["ITMJ_CD"] + "_QTY";
            //DatabaseBindingXY(srArray4, "YMD", dtItems.Rows[4]["ITMJ_CD"] + "_QTY", dt);
            //DundasAnimations.GrowingAnimation(Chart1, srArray4, 4, 4 + 1, true);
            //srArray4.MarkerStyle = GetMarkerStyle(4);
            //srArray4.ToolTip = "#VALY{N0}";

            //Series srArray2 = DundasCharts.CreateSeries(Chart1, "", "Default", "유안벌크", null, SeriesChartType.Line, 3, GetChartColor(2), GetChartColor(2), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
            ////srArray2.ValueMembersY = dtItems.Rows[2]["ITMJ_CD"] + "_QTY";
            //DatabaseBindingXY(srArray2, "YMD", dtItems.Rows[2]["ITMJ_CD"] + "_QTY", dt);
            //DundasAnimations.GrowingAnimation(Chart1, srArray2, 2, 2 + 1, true);
            //srArray2.MarkerStyle = GetMarkerStyle(2);
            //srArray2.ToolTip = "#VALY{N0}";

            //SetVisibleZeroPoint(Chart1, int.Parse(sMonth));
            //srArray2.YAxisType = AxisType.Secondary;

            //string sChartArea = Chart1.Series[srArray0.Name].ChartArea;
            //Chart1.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";

            Series[] srArray = new Series[dtItems.Rows.Count];
            for (int i = 0; i < dtItems.Rows.Count; i++)
            {
                srArray[i] = DundasCharts.CreateSeries(Chart1, "", "Default", dtItems.Rows[i]["ITMJ_NAME"].ToString(), null, SeriesChartType.Line, 3, GetChartColor(GetChartInfo(dtItems.Rows[i]["ITMJ_NAME"].ToString())), GetChartColor(GetChartInfo(dtItems.Rows[i]["ITMJ_NAME"].ToString())), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

                DatabaseBindingXY(srArray[i], "YMD", dtItems.Rows[i]["ITMJ_NAME"].ToString(), dt);
                DundasAnimations.GrowingAnimation(Chart1, srArray[i], i, i + 1, true);
                srArray[i].MarkerStyle = GetMarkerStyle(GetChartInfo(dtItems.Rows[i]["ITMJ_NAME"].ToString()));


                if (dtItems.Rows[i]["ITMJ_NAME"].ToString() == "유안벌크")
                {

                    srArray[i].YAxisType = AxisType.Secondary;
                }

                //SetVisibleZeroPoint(Chart1, int.Parse(sMonth));
                srArray[i].ToolTip = "#VALY{N0}";

                string sChartArea = Chart1.Series[srArray[i].Name].ChartArea;
                Chart1.ChartAreas[sChartArea].AxisY.LabelStyle.Format = "N0";
                Chart1.ChartAreas[sChartArea].AxisY2.LabelStyle.Format = "N0";
            }

            SetVisibleZeroPoint(Chart1, Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlYear)));
           
        }

        // 챠트용 데이타테이블 반환

        private DataTable GetDTChart(string sGubun)
        {
            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            string sItem = PageUtility.GetByValueDropDownList(ddlItem);

            string[] saDayTerm = TypeUtility.GetDateDiff(sYear + sMonth, sYear + sMonth, true);    // 1달동안의 날짜
            DataTable dtItems = GetDTItems(sItem);    // 선택된 아이템

            double dTotal = 0;
            double dTmp = 0;

            DataTable dataTable = new DataTable();
            DataRow drNew = null;
            MicroBSC.Data.DBAgent gDbAgentEIS = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);
            DataSet dsTable = gDbAgentEIS.Fill(GetDefaultQuery(sGubun));
          
            DataTable dtTable = dsTable.Tables[0];
            DataRow[] draDefault = null;

            if (dtTable.Rows.Count > 0)
            {

                dataTable.Columns.Add("YMD", typeof(string));

                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    dataTable.Columns.Add(dtItems.Rows[i]["ITMJ_NAME"].ToString(), typeof(double));
                }

                for (int i = 0; i < saDayTerm.Length; i++)
                {
                    drNew = dataTable.NewRow();
                    drNew["YMD"] = saDayTerm[i].Substring(6, 2);

                    for (int j = 0; j < dtItems.Rows.Count; j++)
                    {
                        
                            draDefault = dtTable.Select(
                                                        "v_YMD = '" + saDayTerm[i] + "' "
                                                  + "AND ITMJ_CD = '" + dtItems.Rows[j]["ITMJ_CD"] + "' "
                                                       );
                       
                        dTmp = 0;

                        for (int k = 0; k < draDefault.Length; k++)
                        {
                            dTmp += Convert.ToDouble(draDefault[k]["v_JgoQty"]);
                        }

                        if (dtItems.Rows[j]["ITMJ_CD"].ToString() == "11")
                        {
                            drNew[dtItems.Rows[j]["ITMJ_NAME"].ToString()] = dTmp / 2;
                        }
                        else
                        {
                            drNew[dtItems.Rows[j]["ITMJ_NAME"].ToString()] = dTmp;
                        }
                    }

                    dataTable.Rows.Add(drNew);
                }
            }
            else
            {
                dataTable.Columns.Add("YMD", typeof(string));

                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    dataTable.Columns.Add(dtItems.Rows[i]["ITMJ_NAME"].ToString(), typeof(double));
                }

                for (int i = 0; i < saDayTerm.Length; i++)
                {
                    drNew = dataTable.NewRow();
                    drNew["YMD"] = saDayTerm[i].Substring(6, 2);

                    for (int j = 0; j < dtItems.Rows.Count; j++)
                    {
                        drNew[dtItems.Rows[j]["ITMJ_NAME"].ToString()] = dTmp;
                    }

                    dataTable.Rows.Add(drNew);
                }
            
            }
            return dataTable;
        }

        //private string GetChartQuery()
        //{
        //    string sQuery = "";

        //    sQuery += GetDefaultQuery();

        //    return sQuery;
        //}

        private string GetDefaultQuery(string sGubun)
        {

            string sYear = PageUtility.GetByValueDropDownList(ddlYear);
            string sMonth = PageUtility.GetByValueDropDownList(ddlMonth);
            string sGong = PageUtility.GetByValueDropDownList(ddlGong);
            string sItem = PageUtility.GetByValueDropDownList(ddlItem);

            string sQuery = "";

            sQuery += "SELECT a.v_Year + a.v_Month + a.v_Day v_YMD,                                         \n";
            sQuery += "       a.v_Day,                                                                      \n";
            sQuery += "       a.ITMJ_CD,                                                                                \n";
            sQuery += "       a.ITMJ_NAME,                                                                              \n";
            sQuery += "       a.v_JgoQty                                                                                \n";
            sQuery += "  FROM (                                                                                         \n";
            sQuery += "       SELECT CONVERT(VARCHAR, a.Year) v_Year,                                                   \n";
            sQuery += "              CASE WHEN a.Month < 10 THEN '0' + CONVERT(VARCHAR, a.Month)                        \n";
            sQuery += "                                     ELSE CONVERT(VARCHAR, a.Month)                              \n";
            sQuery += "              END v_Month,                                                                       \n";
            sQuery += "              CASE WHEN a.DayNumberOfMonth < 10 THEN '0' + CONVERT(VARCHAR, a.DayNumberOfMonth)  \n";
            sQuery += "                                                ELSE CONVERT(VARCHAR, a.DayNumberOfMonth)        \n";
            sQuery += "              END v_Day,                                                                         \n";
            sQuery += "              b.ITMJ_CD,                                                                         \n";
            sQuery += "              b.ITMJ_NAME,                                                                       \n";
            sQuery += "              SUM(c.JGO_QTY) v_JgoQty                                                            \n";
            sQuery += "         FROM D_TIME_ILJA a,                                                                     \n";
            sQuery += "              D_ITEM_JAEGO b,                                                                              \n";
            sQuery += "              CA_FT_JAEGO  c                                                                     \n";
            sQuery += "        WHERE c.TIME_IDX = a.TM_IDX                                                              \n";
            sQuery += "          AND c.ITEM_IDX = b.ITMJ_IDX                                                             \n";
            sQuery += "          AND a.Year = " + sYear + "  -- 년                                                      \n";
            sQuery += "          AND a.Month= " + Convert.ToInt32(sMonth) + "     -- 월                                 \n";
            sQuery += "          AND a.DayNumberOfMonth between 1 and 31    -- 일                                       \n";
            if (sGubun == "일일")
            {
                if (sItem != "")
                    sQuery += "          AND b.ITMJ_CD = " + sItem + " -- item                                                             \n";
                if (sGong != "")
                    sQuery += "          AND c.GONG_IDX = " + sGong + " -- 공장                                                              \n";
            }
            else
            {
                if (sGong != "")
                    sQuery += "          AND c.GONG_IDX = " + sGong + " -- 공장                                                              \n";
            }
            sQuery += "        GROUP by                                                                                 \n";
            sQuery += "              a.Year,                                                                            \n";
            sQuery += "              a.Month,                                                                           \n";
            sQuery += "              a.DayNumberOfMonth,                                                                \n";
            sQuery += "              b.ITMJ_CD,                                                                         \n";
            sQuery += "              b.ITMJ_NAME                                                                        \n";
            sQuery += "       ) a                                                                                       \n";

            return sQuery;
        }


        private int GetChartInfo(string sGubun)
        {
            if (sGubun == "카프로락탐")
                return 0;
            else if (sGubun == "박편락탐")
                return 1;
            else if (sGubun == "유안벌크")
                return 2;
            else if (sGubun == "싸이크로헥산")
                return 3;
            else
                return 4;
        }


        #endregion




        #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindingPieChart(ddlYear.SelectedValue + ddlMonth.SelectedValue);
            ChartBinding();
        }

    #endregion
}
