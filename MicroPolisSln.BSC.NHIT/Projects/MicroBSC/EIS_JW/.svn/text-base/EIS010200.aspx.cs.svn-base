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
using Infragistics.WebUI.UltraWebGrid;

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.EIS.Dac;

using MicroBSC.Estimation.Biz;

public partial class EIS_EIS010200 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;

    private DataTable DT_DATA;

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        YMD             = WebUtility.GetRequest("YMD");
        M_ID            = WebUtility.GetRequestByInt("M_ID");
        S_ID            = WebUtility.GetRequestByInt("S_ID");

        if (!Page.IsPostBack)
        {
            SetData(ESTTERM_REF_ID, YMD);
            DataBinding();

            ifmContent.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 1));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        //DT_DATA             = objEIS.GetData_M_1_S_2(estterm_ref_id, ymd);

        DataSet ds = objEIS.GetData_M_0_S_Factory(estterm_ref_id, ymd);

        DT_DATA = ds.Tables[0];

        DT_DATA = DataTypeUtility.FilterSortDataTable(DT_DATA, "", "SORT_ORDER");
    }

    private void DataBinding() 
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add("M_NAME", typeof(string));
        dt.Columns.Add("S_NAME", typeof(string));

        dt.Columns.Add("BF_SALES", typeof(double));              // 전년동기실적 - 매출액
        dt.Columns.Add("BF_PROFIT", typeof(double));             // 전년동기실적 - 매출액
        dt.Columns.Add("MS_SALES", typeof(double));              // 계획 - 매출액
        dt.Columns.Add("MS_PROFIT", typeof(double));             // 계획 - 영업이익
        dt.Columns.Add("TS_SALES", typeof(double));              // 실적 - 매출액
        dt.Columns.Add("TS_PROFIT", typeof(double));             // 실적 - 영업이익
        dt.Columns.Add("ACHIEVE_SALES", typeof(double));         // 사업계획대비 - 매출액
        dt.Columns.Add("ACHIEVE_PROFIT", typeof(double));        // 사업계획대비 - 영업이익
        dt.Columns.Add("BF_ACHIEVE_SALES", typeof(double));      // 전년동기대비 - 매출액
        dt.Columns.Add("BF_ACHIEVE_PROFIT", typeof(double));     // 전년동기대비 - 영업이익
        dt.Columns.Add("RS_SALES", typeof(double));   
        dt.Columns.Add("RS_PROFIT", typeof(double));
        dt.Columns.Add("RATIO_SALES", typeof(double));
        dt.Columns.Add("RATIO_PROFIT", typeof(double));
        dt.Columns.Add("SORT_ORDER", typeof(int));



        //dr = dt.NewRow();
        






        // 여기서 부터 수정



        //DataRow[] rows = null;
        //int[] intSale   = { 3642, 3644, -1, 3646, 3648, 3650, 3652 };
        //int[] intProfit = { 3643, 3645, -2, 3647, 3649, 3651, 3653 };


        //for (int i = 0; i < intSale.Length; i++)
        //{
        //    rows = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3642));	

        //    if(rows.Length > 0)
        //    {
        //        dr = dt.NewRow();
        //        dr["SORT_ORDER"] = i+1;
        //        dr["M_NAME"] = "본사";
        //        dr["S_NAME"] = "DD 사업부";

        //        dr["BF_SALES"]         = rows[0]["BF_RESULT"];
        //        dr["MS_SALES"]         = rows[0]["TARGET_TS"];
        //        dr["TS_SALES"]         = rows[0]["RESULT_TS"];
        //        dr["ACHIEVE_SALES"]    = rows[0]["ACHIEVE_RATE"];
        //        dr["BF_ACHIEVE_SALES"] = rows[0]["BF_ACHIEVE_RATE"];
        //        dr["RS_SALES"]         = rows[0]["RESULT_RNF"];

        //        dt.Rows.Add(dr);
        //    }

            
        //}

        //for (int i = 0; i < intProfit.Length; i++)
        //{
        //    rows = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3642));

        //    if (rows.Length > 0)
        //    {
        //        dr = dt.NewRow();
        //        dr["SORT_ORDER"] = i+1;
        //        dr["M_NAME"] = "본사";
        //        dr["S_NAME"] = "DD 사업부";

        //        dr["BF_PROFIT"]         = rows[0]["BF_RESULT"];
        //        dr["MS_PROFIT"]         = rows[0]["TARGET_TS"];
        //        dr["TS_PROFIT"]         = rows[0]["RESULT_TS"];
        //        dr["ACHIEVE_PROFIT"]    = rows[0]["ACHIEVE_RATE"];
        //        dr["BF_ACHIEVE_PROFIT"] = rows[0]["BF_ACHIEVE_RATE"];
        //        dr["RS_PROFIT"]         = rows[0]["RESULT_RNF"];

        //        dt.Rows.Add(dr);
        //    }
        //}

        

        // 여기가 수정끝






        #region 본사

        
        dr = dt.NewRow();
        dr["SORT_ORDER"] = 1;
        dr["M_NAME"] = "본사";
        dr["S_NAME"] = "DD 사업부";
        

        DataRow[] drCol = null;

		//-- 1371 -> 3642 로 변경(2010.07.15) 
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3642));	

		if (drCol.Length > 0)
		{

			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		//-- 1372 -> 3643 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3643));	

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);

		dr = dt.NewRow();
		dr["SORT_ORDER"] = 2;
		dr["M_NAME"] = "본사";
		dr["S_NAME"] = "DO 사업부";

		//-- 1400 -> 3644 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3644));

		if (drCol.Length > 0)
		{
			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		//-- 1401 -> 3645 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3645));

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);

		dr = dt.NewRow();
		dr["SORT_ORDER"] = 3;
		dr["M_NAME"] = "본사";
		dr["S_NAME"] = "DD/DO 합계";

		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", -1));

		if (drCol.Length > 0)
		{
			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", -2));

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);

		#endregion

		#region 해외법인
		dr = dt.NewRow();
		dr["SORT_ORDER"] = 4;
		dr["M_NAME"] = "해외법인";
		dr["S_NAME"] = "천진";

		//-- 1475 -> 3646 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3646));

		if (drCol.Length > 0)
		{
			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		//-- 1476 -> 3647 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3647));

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);

		dr = dt.NewRow();
		dr["SORT_ORDER"] = 5;
		dr["M_NAME"] = "해외법인";
		dr["S_NAME"] = "혜주";

		//-- 1477 -> 3648 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3648));

		if (drCol.Length > 0)
		{
			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		//-- 1478 -> 3649 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3649));

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);

		dr = dt.NewRow();
		dr["SORT_ORDER"] = 6;
		dr["M_NAME"] = "해외법인";
		dr["S_NAME"] = "말레이";

		//-- 1479 -> 3650 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3650));

		if (drCol.Length > 0)
		{
			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		//-- 1480 -> 3651 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3651));

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);

		#endregion

		#region 기타 [기존 해외법인 - 베트남을 기타로 변경함]
		dr = dt.NewRow();
		dr["SORT_ORDER"] = 7;
		dr["M_NAME"] = "기타";
		dr["S_NAME"] = "기타";

		//-- 1525 -> 3652 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3652));

		if (drCol.Length > 0)
		{
			dr["MS_SALES"] = drCol[0]["TARGET_TS"];
			dr["TS_SALES"] = drCol[0]["RESULT_TS"];
			dr["RS_SALES"] = drCol[0]["RESULT_RNF"];
            dr["BF_SALES"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_SALES"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_SALES"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_SALES"] = drCol[0]["RATIO"];
		}

		//-- 1526 -> 3653 로 변경(2010.07.15)
		drCol = DT_DATA.Select(string.Format("KPI_REF_ID = {0}", 3653));

		if (drCol.Length > 0)
		{
			dr["MS_PROFIT"] = drCol[0]["TARGET_TS"];
			dr["TS_PROFIT"] = drCol[0]["RESULT_TS"];
			dr["RS_PROFIT"] = drCol[0]["RESULT_RNF"];
            dr["BF_PROFIT"] = drCol[0]["BF_RESULT"];
            dr["ACHIEVE_PROFIT"] = drCol[0]["ACHIEVE_RATE"];
            dr["BF_ACHIEVE_PROFIT"] = drCol[0]["BF_ACHIEVE_RATE"];
			//dr["RATIO_PROFIT"] = drCol[0]["RATIO"];
		}

		dt.Rows.Add(dr);
        
		#endregion
        
        
        
        
        dt = DataTypeUtility.FilterSortDataTable(dt, "MS_SALES IS NOT NULL", "SORT_ORDER");

        //uGrid.DataSource = dt;
        //uGrid.DataBind();

        UltraWebGrid1.DataSource = dt;
        UltraWebGrid1.DataBind();


        BindPieChart( Chart1
					, DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 1 OR SORT_ORDER = 2 OR SORT_ORDER = 4 OR SORT_ORDER = 5 OR SORT_ORDER = 6 OR SORT_ORDER = 7")
                    , "매출액"
                    , "TS_SALES"
                    , "RATIO_SALES");

        BindPieChart( Chart2
					, DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 1 OR SORT_ORDER = 2 OR SORT_ORDER = 4 OR SORT_ORDER = 5 OR SORT_ORDER = 6 OR SORT_ORDER = 7")
                    , "영업이익"
                    , "TS_PROFIT"
                    , "RATIO_PROFIT");

        DataSet ds = new DataSet();

        if(dt.Select("SORT_ORDER = 1").Length > 0)
            ds.Tables.Add(DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 1", "", "DD사업부"));

        if(dt.Select("SORT_ORDER = 2").Length > 0)
            ds.Tables.Add(DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 2", "", "DO사업부"));

        if(dt.Select("SORT_ORDER = 4").Length > 0)
            ds.Tables.Add(DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 4", "", "천진법인"));

        if(dt.Select("SORT_ORDER = 5").Length > 0)
            ds.Tables.Add(DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 5", "", "혜주법인"));

        if(dt.Select("SORT_ORDER = 6").Length > 0)
            ds.Tables.Add(DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 6", "", "말레이법인"));

        if(dt.Select("SORT_ORDER = 7").Length > 0)
            ds.Tables.Add(DataTypeUtility.FilterSortDataTable(dt, "SORT_ORDER = 7", "", "기타법인"));
        
        BindColumnChart(Chart3, ds, "매출액", " ", "RS_SALES");
        BindColumnChart(Chart4, ds, "영업이익", " ", "RS_PROFIT");



        //series.Points.AddXY("매출액", dt.Rows[0]["MS_SALES"]);
                //series.Points.AddXY("영업이익", dt.Rows[0]["MS_PROFIT"]);
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        string sumTitle = (e.Row.Cells.FromKey("S_NAME").Value == null) ? "" : e.Row.Cells.FromKey("S_NAME").Value.ToString();
        if (sumTitle.Equals("DD/DO 합계"))
        {
            string bf_profit = (e.Row.Cells.FromKey("BF_PROFIT").Value.ToString().Equals("0")) ? "-" : e.Row.Cells.FromKey("BF_PROFIT").Value.ToString();
            string ms_profit = (e.Row.Cells.FromKey("ACHIEVE_SALES").Value.ToString().Equals("0")) ? "-" : e.Row.Cells.FromKey("ACHIEVE_SALES").Value.ToString();
            string ts_profit = (e.Row.Cells.FromKey("BF_ACHIEVE_SALES").Value.ToString().Equals("0")) ? "-" : e.Row.Cells.FromKey("BF_ACHIEVE_SALES").Value.ToString();
            string achieve_profit = (e.Row.Cells.FromKey("ACHIEVE_PROFIT").Value.ToString().Equals("0")) ? "-" : e.Row.Cells.FromKey("ACHIEVE_PROFIT").Value.ToString();
            string bf_achieve_profit = (e.Row.Cells.FromKey("BF_ACHIEVE_PROFIT").Value.ToString().Equals("0")) ? "-" : e.Row.Cells.FromKey("BF_ACHIEVE_PROFIT").Value.ToString();


            //e.Row.Cells.FromKey("BF_PROFIT").Value = bf_profit;
            e.Row.Cells.FromKey("ACHIEVE_SALES").Value = ms_profit;
            e.Row.Cells.FromKey("BF_ACHIEVE_SALES").Value = ts_profit;
            e.Row.Cells.FromKey("ACHIEVE_PROFIT").Value = achieve_profit;
            e.Row.Cells.FromKey("BF_ACHIEVE_PROFIT").Value = bf_achieve_profit;



        }

    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int year = 2010;
        ///e.Layout.Bands[0].HeaderLayout.Reset();

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년동기실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Caption = "'"+year.ToString()+"년 상반기";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 4;
        //ch.RowLayoutColumnInfo.SpanX = 8;        
        //ch.Style.Height = Unit.Pixel(20);
        //e.Layout.Bands[0].HeaderLayout.Add(ch);
        //e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "달성율";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "사업계획대비";
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년동기대비";
        ch.RowLayoutColumnInfo.OriginY = 1;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    protected void uGrid_InitializeRow(object sender, RowEventArgs e)
    {

    }
    
    protected void uGrid_InitializeLayout(object sender, LayoutEventArgs e)
    {
        ///e.Layout.Bands[0].HeaderLayout.Reset();

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "목표";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "전년동기대비 증감";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    private void BindPieChart(Chart chart
                            , DataTable dt
                            , string titleName
                            , string yValueColumn
                            , string ratioColumn)
    {
        dt.Columns.Add("TEXT", typeof(string));

        foreach(DataRow dr in dt.Rows) 
        {
            dr["TEXT"] = string.Format("{0}"
                                    , dr["S_NAME"]
                                    , DataTypeUtility.GetToDouble(dr[ratioColumn]).ToString("#,##0.00"));
        }

        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 240
                                    , 180
                                    , BorderSkinStyle.Emboss
                                    , Color.FromArgb(181, 64, 1)
                                    , 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);

        Series series1 = DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , null
                                                , null
                                                , SeriesChartType.Doughnut
                                                , 1
                                                , GetChartColor(0)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        //series1.Label   = "#VALY{N0}";

        series1.ToolTip                                         = "#VALY{N0}";

        //series1.ShowLabelAsValue = true;
        //series1.ShowInLegend = true;

        chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

        DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points[i].AxisLabel = dt.Rows[i]["ALIAS"].ToString();
        //}

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    series1.Points.AddY(dt.Rows[i]["RESULT_TS"]);
        //}

        series1.Font = new Font("굴림", 7, FontStyle.Regular);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            series1.Points.AddXY(dt.Rows[i]["TEXT"].ToString(), dt.Rows[i][yValueColumn]);
        }

        if(series1.Type == SeriesChartType.Pie || series1.Type == SeriesChartType.Doughnut) 
        {
            for(int p = 0; p < series1.Points.Count; p++) 
            {
                DataPoint point = series1.Points[p];

                point.Color = GetChartColor(p);
            }
        }

        //series1.ToolTip = "#VALY{#,##0,00}";
        //series2.ToolTip = "#VALY{#,##0}";

        //series2.MarkerStyle         = MarkerStyle.Circle;
        //series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        Font font   = new Font("Gulim", 11, FontStyle.Regular);

        Dundas.Charting.WebControl.Title title = DundasCharts.CreateTitle(chart
                                                                        , "Title1"
                                                                        , titleName
                                                                        , font
                                                                        , Color.FromArgb(26, 59, 105)
                                                                        , Color.Empty
                                                                        , Color.Empty
                                                                        , ContentAlignment.TopCenter
                                                                        , null
                                                                        , Color.FromArgb(32, 0, 0, 0)
                                                                        , 3
                                                                        , false
                                                                        , 5
                                                                        , 7
                                                                        , 91
                                                                        , 6);

        Legend legend = DundasCharts.CreateLegend(chart
                                                , "Default"
                                                , Color.Transparent
                                                , Color.Empty
                                                , Color.Empty);

        //legend.AutoFitText = false;
        //legend.Position = new ElementPosition(65, 7, 50, 40);

        legend.Enabled = false;

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], true);

        series1.Font = new Font("굴림", 7, FontStyle.Regular);
        series1["PieLabelStyle"] = "Outside";
        
        legend.Font = new Font("굴림", 7, FontStyle.Regular);
        legend.LegendStyle = LegendStyle.Table;
        legend.AutoFitText = false;
        legend.Docking = LegendDocking.Bottom;
        //legend.Alignment = StringAlignment.Near;
        //legend.Position = new ElementPosition(60, 7, 50, 24);
        //legend.Enabled = false;
        //legend.DockInsideChartArea = true;
        chart.ChartAreas["Default"].AlignOrientation = AreaAlignOrientation.All;

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    private void BindColumnChart( Chart chart
                                , DataSet ds
                                , string titleName
                                , string name
                                , string value)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 240
                                    , 180
                                    , BorderSkinStyle.Emboss
                                    , Color.FromArgb(181, 64, 1)
                                    , 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);

        Series series = null;

        for(int k = 0; k < ds.Tables.Count; k++) 
        {
            DataTable dt = ds.Tables[k];

            series = DundasCharts.CreateSeries(chart
                                            , "Series" + k.ToString()
                                            , "Default"
                                            , dt.TableName.Replace("사업부", "").Replace("법인", "")
                                            , dt.TableName.Replace("사업부", "").Replace("법인", "")
                                            , SeriesChartType.Column
                                            , 1
                                            , GetChartColor(k)
                                            , Color.FromArgb(0x4A, 0x58, 0x7E)
                                            , Color.FromArgb(64, 0, 0, 0)
                                            , 1
                                            , 9
                                            , Color.FromArgb(64, 64, 64));

            //series1.Label   = "#VALY{N0}";

            series.ToolTip                                         = "#VALY{N0}";

            chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

            DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(chart, series, 0.5, 1.5, true);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    series1.Points[i].AxisLabel = dt.Rows[i]["ALIAS"].ToString();
            //}

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    series1.Points.AddY(dt.Rows[i]["RESULT_TS"]);
            //}

            series.Font = new Font("굴림", 7, FontStyle.Regular);

            if(k == 0) 
            {
                //series.Points.AddXY("매출액", dt.Rows[0]["MS_SALES"]);
                //series.Points.AddXY("영업이익", dt.Rows[0]["MS_PROFIT"]);

                series.Points.AddXY(name, dt.Rows[0][value]);
            }
            else 
            {
                //series.Points.AddY(dt.Rows[0]["MS_SALES"]);
                //series.Points.AddY(dt.Rows[0]["MS_PROFIT"]);

                series.Points.AddY(dt.Rows[0][value]);
            }
        }


        //series1.ToolTip = "#VALY{#,##0,00}";
        //series2.ToolTip = "#VALY{#,##0}";

        //series2.MarkerStyle         = MarkerStyle.Circle;
        //series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        //series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        Font font   = new Font("Gulim", 11, FontStyle.Regular);

        Dundas.Charting.WebControl.Title title = DundasCharts.CreateTitle(chart
                                                                        , "Title1"
                                                                        , titleName
                                                                        , font
                                                                        , Color.FromArgb(26, 59, 105)
                                                                        , Color.Empty
                                                                        , Color.Empty
                                                                        , ContentAlignment.TopCenter
                                                                        , null
                                                                        , Color.FromArgb(32, 0, 0, 0)
                                                                        , 3
                                                                        , false
                                                                        , 5
                                                                        , 7
                                                                        , 91
                                                                        , 6);

        Legend legend = DundasCharts.CreateLegend(chart
                                                , "Default"
                                                , Color.Transparent
                                                , Color.Empty
                                                , Color.Empty);

        legend.AutoFitText = false;
        legend.Position = new ElementPosition(73, 7, 50, 40);
        legend.Font = new Font("굴림", 7, FontStyle.Regular);

        //legend.LegendStyle = LegendStyle.Table;
        //legend.AutoFitText = true;
        //legend.Docking = LegendDocking.Bottom;


        //legend.LegendStyle = LegendStyle.Table;
        //legend.AutoFitText = false;
        ////legend.Position = new ElementPosition(20, 100, 200, 40);
        //legend.Font = new Font("굴림", 7, FontStyle.Regular);
        //legend.Docking = LegendDocking.Bottom;

        DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
