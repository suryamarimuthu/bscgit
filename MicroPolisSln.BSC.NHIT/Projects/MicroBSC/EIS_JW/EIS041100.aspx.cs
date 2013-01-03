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

public partial class EIS_EIS041100 : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;
    private string BU;

    //private DataSet DS_DATA;
    private DataTable DT_DATA;

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

            ifmContent1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 101));
            ifmContent1_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 201));

            ifmContent2.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 102));
            ifmContent2_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 202));

            ifmContent3.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 103));
            ifmContent3_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 203));

            ifmContent4.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 104));
            ifmContent4_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 204));

            ifmContent5.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 105));
            ifmContent5_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 205));

            ifmContent6.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 106));
            ifmContent6_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 206));

            ifmContent7.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 107));
            ifmContent7_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 207));

            ifmContent8.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 108));
            ifmContent8_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 208));

            ifmContent9.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 109));
            ifmContent9_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 209));

            ifmContent10.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 110));
            ifmContent10_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 210));

            ifmContent11.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 111));
            ifmContent11_1.Attributes.Add("src", string.Format("EIS_COMMENT.aspx?ESTTERM_REF_ID={0}&YMD={1}&M_ID={2}&S_ID={3}&AREA_ID={4}", ESTTERM_REF_ID, YMD, M_ID, S_ID, 211));
        }

        ltrScript.Text = "";
    }

    private void SetData(int estterm_ref_id, string ymd) 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DT_DATA             = objEIS.GetData_M_4_S_11(estterm_ref_id, ymd).Tables[0];
    }

    private void DataBinding() 
    {
        DataTable dtIndex = new DataTable();
        DataRow dr = null;
        dtIndex.Columns.Add("IDX", typeof(int));
        dtIndex.Columns.Add("BU", typeof(string));

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 1;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 2;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 3;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 4;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 5;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 6;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 7;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 8;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 9;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 10;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);

        dr          = dtIndex.NewRow();
        dr["IDX"]   = 11;
        dr["BU"]    = "CJ";
        dtIndex.Rows.Add(dr);


        HtmlTable tbl = Page.FindControl("tbl") as HtmlTable;

        foreach(Control con in tbl.Controls) 
        {
            if(con is HtmlTableRow) 
            {
                int idx = DataTypeUtility.GetToInt32(con.ID.Replace("tr", ""));

                Infragistics.WebUI.UltraWebGrid.UltraWebGrid grid = Page.FindControl(string.Format("Grid{0}", idx)) as Infragistics.WebUI.UltraWebGrid.UltraWebGrid;

                if(grid != null) 
                {
                    DataTable dt = DataTypeUtility.FilterSortDataTable(DT_DATA, string.Format("SORT_ORDER1 = {0}", idx), "SORT_ORDER2");

                    dt.Columns.Add("ITM_NAME", typeof(string));

                    foreach(DataRow dr_I in dt.Rows) 
                    {
                        if(DataTypeUtility.GetToInt32(dr_I["SORT_ORDER2"]) == 1) 
                        {
                            dr_I["ITM_NAME"] = "생산수율";
                        }
                        else if(DataTypeUtility.GetToInt32(dr_I["SORT_ORDER2"]) == 2) 
                        {
                            dr_I["ITM_NAME"] = "공정불량율";
                        }
                    }

                    grid.DataSource = dt;
                    grid.DataBind();


                    if(dt.Rows.Count == 0)
                        con.Visible = false;
                }
            }
            else 
            {
                con.Visible = false;
            }


        }
    }

    protected Color GetChartColor(int i)
    {
        int iCheck = i % 10;

        return Color.FromArgb(CHART_COLOR_INT[iCheck, 0], CHART_COLOR_INT[iCheck, 1], CHART_COLOR_INT[iCheck, 2]);
    }
}
