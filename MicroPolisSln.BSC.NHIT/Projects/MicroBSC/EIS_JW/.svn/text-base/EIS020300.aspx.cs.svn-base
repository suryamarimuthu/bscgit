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

public partial class EIS_EIS020300 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;
    private string BU;

    private DataSet DS_DATA;

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        YMD             = WebUtility.GetRequest("YMD");
        M_ID            = WebUtility.GetRequestByInt("M_ID");
        S_ID            = WebUtility.GetRequestByInt("S_ID");
        BU              = WebUtility.GetRequest("BU");

        if (!Page.IsPostBack)
        {
            SetData(ESTTERM_REF_ID, YMD);
            DataBinding();

            ifmContent1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 1));
            ifmContent2.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 2));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DS_DATA             = objEIS.GetData_M_2_S_3(estterm_ref_id, ymd);


        //foreach(DataRow dr in DT_DATA_01.Rows) 
        //{
        //    dr["RESULT_TS"] = 2;
        //}

        //foreach(DataRow dr in DT_DATA_02.Rows) 
        //{
        //    dr["RESULT_TS"] = 2;
        //}
    }

    private void DataBinding() 
    {
        DataTable dt = null;

        if(BU.Equals("DD"))
            dt = DS_DATA.Tables[0];
        else if(BU.Equals("DO"))
            dt = DS_DATA.Tables[1];
        else if(BU.Equals("CJ"))
            dt = DS_DATA.Tables[2];
        else
            return;

        //------------------ 그리드 바인딩 --------------------------

        dt.Columns.Add("I_NAME", typeof(string));
        dt.Columns.Add("S_NAME", typeof(string));

        DataTable dtItem = new DataTable();
        DataRow drItem = null;
        dtItem.Columns.Add("I_ID", typeof(string));
        dtItem.Columns.Add("I_NAME", typeof(string));

        DataTable dtStock = new DataTable();
        DataRow drStock = null;
        dtStock.Columns.Add("S_ID", typeof(string));
        dtStock.Columns.Add("S_NAME", typeof(string));

        drStock = dtStock.NewRow();
        drStock["S_ID"] = "S_01";
        drStock["S_NAME"] = "제품";
        dtStock.Rows.Add(drStock);

        drStock = dtStock.NewRow();
        drStock["S_ID"] = "S_02";
        drStock["S_NAME"] = "부품";
        dtStock.Rows.Add(drStock);

        drStock = dtStock.NewRow();
        drStock["S_ID"] = "S_03";
        drStock["S_NAME"] = "원자재";
        dtStock.Rows.Add(drStock);

        drStock = dtStock.NewRow();
        drStock["S_ID"] = "S_04";
        drStock["S_NAME"] = "재공품";
        dtStock.Rows.Add(drStock);

        drStock = dtStock.NewRow();
        drStock["S_ID"] = "S_05";
        drStock["S_NAME"] = "총재고";
        dtStock.Rows.Add(drStock);

        if(BU.Equals("DD")) 
        {
            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_01";
            drItem["I_NAME"] = "PTC";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_02";
            drItem["I_NAME"] = "VM";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_03";
            drItem["I_NAME"] = "EV";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_04";
            drItem["I_NAME"] = "AFA";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_05";
            drItem["I_NAME"] = "ALC";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_06";
            drItem["I_NAME"] = "기타";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_07";
            drItem["I_NAME"] = "추가여분1";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_08";
            drItem["I_NAME"] = "추가여분2";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_09";
            drItem["I_NAME"] = "추가여분3";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_10";
            drItem["I_NAME"] = "추가여분4";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_11";
            drItem["I_NAME"] = "합계";
            dtItem.Rows.Add(drItem);


            foreach(DataRow dr in dtStock.Rows) 
            {
                dtItem.Columns.Add(dr["S_ID"].ToString(), typeof(double));
            }

            foreach(DataRow drI in dtItem.Rows) 
            {
                foreach(DataRow drS in dtStock.Rows) 
                {
                    DataRow[] drCol = dt.Select(string.Format("ITEM_CODE = '{0}' AND STOCK_CODE = '{1}'", drI["I_ID"], drS["S_ID"]));

                    if(drCol.Length > 0) 
                    {
                        drCol[0]["I_NAME"] = drI["I_NAME"].ToString();
                        drCol[0]["S_NAME"] = drS["S_NAME"].ToString();
                        drI[drS["S_ID"].ToString()] = drCol[0]["RESULT_TS"];
                    }
                }
            }
        }
        else if(BU.Equals("DO")) 
        {
            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_01";
            drItem["I_NAME"] = "PCM";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_02";
            drItem["I_NAME"] = "TS";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_03";
            drItem["I_NAME"] = "Roller";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_04";
            drItem["I_NAME"] = "Sleeve";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_05";
            drItem["I_NAME"] = "CTR";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_06";
            drItem["I_NAME"] = "FCCL";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_07";
            drItem["I_NAME"] = "Film";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_08";
            drItem["I_NAME"] = "기타";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_09";
            drItem["I_NAME"] = "추가여부1";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_10";
            drItem["I_NAME"] = "추가여부2";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_11";
            drItem["I_NAME"] = "추가여부3";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_12";
            drItem["I_NAME"] = "추가여부4";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_13";
            drItem["I_NAME"] = "합계";
            dtItem.Rows.Add(drItem);

            foreach(DataRow dr in dtStock.Rows) 
            {
                dtItem.Columns.Add(dr["S_ID"].ToString(), typeof(double));
            }

            foreach(DataRow drI in dtItem.Rows) 
            {
                foreach(DataRow drS in dtStock.Rows) 
                {
                    DataRow[] drCol = dt.Select(string.Format("ITEM_CODE = '{0}' AND STOCK_CODE = '{1}'", drI["I_ID"], drS["S_ID"]));

                    if(drCol.Length > 0) 
                    {
                        drCol[0]["I_NAME"] = drI["I_NAME"].ToString();
                        drCol[0]["S_NAME"] = drS["S_NAME"].ToString();
                        drI[drS["S_ID"].ToString()] = drCol[0]["RESULT_TS"];
                    }
                }
            }
        }
        else if(BU.Equals("CJ")) 
        {
            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_01";
            drItem["I_NAME"] = "PTC";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_02";
            drItem["I_NAME"] = "VM";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_03";
            drItem["I_NAME"] = "EV";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_04";
            drItem["I_NAME"] = "AFA";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_05";
            drItem["I_NAME"] = "PCM";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_06";
            drItem["I_NAME"] = "ROLLER";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_07";
            drItem["I_NAME"] = "기타";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_08";
            drItem["I_NAME"] = "추가여부1";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_09";
            drItem["I_NAME"] = "추가여부2";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_10";
            drItem["I_NAME"] = "추가여부3";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_11";
            drItem["I_NAME"] = "추가여부4";
            dtItem.Rows.Add(drItem);

            drItem = dtItem.NewRow();
            drItem["I_ID"] = "I_12";
            drItem["I_NAME"] = "합계";
            dtItem.Rows.Add(drItem);

            foreach(DataRow dr in dtStock.Rows) 
            {
                dtItem.Columns.Add(dr["S_ID"].ToString(), typeof(double));
            }

            foreach(DataRow drI in dtItem.Rows) 
            {
                foreach(DataRow drS in dtStock.Rows) 
                {
                    DataRow[] drCol = dt.Select(string.Format("ITEM_CODE = '{0}' AND STOCK_CODE = '{1}'", drI["I_ID"], drS["S_ID"]));

                    if(drCol.Length > 0) 
                    {
                        drCol[0]["I_NAME"] = drI["I_NAME"].ToString();
                        drCol[0]["S_NAME"] = drS["S_NAME"].ToString();
                        drI[drS["S_ID"].ToString()] = drCol[0]["RESULT_TS"];
                    }
                }
            }
        }

        dtItem = DataTypeUtility.FilterSortDataTable(dtItem, "S_01 IS NOT NULL", "I_ID");

        uGrid.DataSource = dtItem;
        uGrid.DataBind();
        
        //-----------------------------------------------------------

        BindChart(Chart1
                , dtItem
                , DataTypeUtility.FilterSortDataTable(dtStock, "S_ID <> 'S_05'")
                , dt
                , "");
    }

    private void BindChart(Chart chart
                        , DataTable dtItem
                        , DataTable dtStock
                        , DataTable dtData
                        , string titleName)
    {
        DundasCharts.DundasChartBase(chart
                                    , ChartImageType.Flash
                                    , 480
                                    , 310
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

        Series series1 = null;

        for(int k = 0; k < dtStock.Rows.Count; k++) 
        {
            DataRow drS = dtStock.Rows[k];

            series1 =  DundasCharts.CreateSeries( chart
                                                , "Series" + k.ToString()
                                                , "Default"
                                                , drS["S_NAME"].ToString()
                                                , null
                                                , SeriesChartType.StackedColumn
                                                , 1
                                                , GetChartColor(k)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

            //series1.Label   = "#VALY{N0}";

            series1.ToolTip = "#VALY{N0}";

            //series1.ShowLabelAsValue = true;
            //series1.ShowInLegend = true;

            chart.ChartAreas["Default"].AxisY.LabelStyle.Format = "N0";

            DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(chart, series1, 0.5, 1.5, true);
            
            series1.Font = new Font("굴림", 7, FontStyle.Regular);

            //for(int i = 0; i < dt.Rows.Count; i++) 
            //{
            //    series1.Points.AddXY(dt.Rows[i]["ALIAS"].ToString(), dt.Rows[i]["TARGET_TS"]);
            //}

            //for(int i = 0; i < dt.Rows.Count; i++) 
            //{
            //    series2.Points.AddY(dt.Rows[i]["RESULT_TS"]);
            //}

            DataTable dtData_1 = DataTypeUtility.FilterSortDataTable(dtData, string.Format("KPI_REF_ID > 0 AND STOCK_CODE = '{0}'", drS["S_ID"]));
            
            foreach(DataRow dr in dtData_1.Rows) 
            {
                if(k == 0) 
                {
                    series1.Points.AddXY(dr["I_NAME"].ToString(), dr["RESULT_TS"]);
                }
                else 
                {
                    series1.Points.AddY(dr["RESULT_TS"]);
                }
            }

            //else 
            //{
            //    series1.Points.AddY(dtData.Rows[k]["RESULT_TS"]);
            //    //series1.Points.AddY(dtData.Rows[k]["RESULT_TS"]);
            //}
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
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
