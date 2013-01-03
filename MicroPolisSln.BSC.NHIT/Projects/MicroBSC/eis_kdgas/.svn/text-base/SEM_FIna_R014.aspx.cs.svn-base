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

public partial class SEM_FIna_R014 : EISPageBase
{
    private DBAgent dbAgent = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            SetDateDropDownList(ddlYear, ddlMonth);
            SetAreaDropDownList(ddlArea);
            DataBindingObjects();
        }
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        if (dr["LAND_REGISTER_DATE"].ToString().Length == 8)
            e.Row.Cells.FromKey("LAND_REGISTER_DATE").Value = dr["LAND_REGISTER_DATE"].ToString().Substring(0, 4) + "." + dr["LAND_REGISTER_DATE"].ToString().Substring(4, 2) + "." + dr["LAND_REGISTER_DATE"].ToString().Substring(6, 2);
        if (dr["LAND_REGISTER_DATE"].ToString().Length == 8)
            e.Row.Cells.FromKey("LAND_GET_DATE").Value = dr["LAND_GET_DATE"].ToString().Substring(0, 4) + "." + dr["LAND_GET_DATE"].ToString().Substring(4, 2) + "." + dr["LAND_GET_DATE"].ToString().Substring(6, 2);
        if (dr["LAND_REGISTER_DATE"].ToString().Length == 8)
            e.Row.Cells.FromKey("LAND_REGISTER_DATE").Value = dr["LAND_REGISTER_DATE"].ToString().Substring(0, 4) + "." + dr["LAND_REGISTER_DATE"].ToString().Substring(4, 2) + "." + dr["LAND_REGISTER_DATE"].ToString().Substring(6, 2);

        if (dr["LAND_DATE_T"].ToString().Length == 6)
            e.Row.Cells.FromKey("LAND_DATE_T").Value = dr["LAND_DATE_T"].ToString().Substring(0, 4) + "." + dr["LAND_DATE_T"].ToString().Substring(4, 2);

        if (dr["LAND_OFFICE_T"].ToString().Equals("01")) 
        {
            e.Row.Cells.FromKey("LAND_OFFICE_T").Value = "울산";
        }
        else if (dr["LAND_OFFICE_T"].ToString().Equals("02"))
        {
            e.Row.Cells.FromKey("LAND_OFFICE_T").Value = "양산";
        }

//        e.Row.Cells.FromKey("LAND_TOTAL_AREA").Value    = double.Parse(dr["LAND_TOTAL_AREA"].ToString()).ToString("N0");
//        e.Row.Cells.FromKey("LAND_PRICE").Value         = double.Parse(dr["LAND_PRICE"].ToString()).ToString("N0");
//        e.Row.Cells.FromKey("LAND_BOOK_AMOUNT").Value   = double.Parse(dr["LAND_BOOK_AMOUNT"].ToString()).ToString("N0");
    }
    private void GridBinding(string yearStr, string monthStr, string areaStr)
    {
        string query = GetGridQuery(yearStr, monthStr, areaStr);
        dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataBindingObjects();
    }
    private void DataBindingObjects() 
    {
        string yearStr  = ddlYear.SelectedValue;
        string monthStr = ddlMonth.SelectedValue;
        string areaStr  = ddlArea.SelectedValue;

        GridBinding(yearStr, monthStr, areaStr);
    }
    private string GetGridQuery(string yearStr, string monthStr, string areaStr)
    {
        string query = @"
            SELECT LA.LAND_DATE_T,                       -- 년월
                 LA.LAND_OFFICE_T,                       -- 사업장
                 LA.LAND_ASSETS_ID_T,                    -- 자산번호
                 LA.LAND_ASSETS_NAME,                    -- 소재지
                 LA.LAND_SEAT,                           -- 지번
                 LA.LAND_USE,                            -- 용도
                 LA.LAND_TOTAL_AREA,                     -- 총면적
                 LA.LAND_OWNER_AREA,
                 LA.LAND_GRADE,
                 LA.LAND_PRICE,                          -- 공시지가
                 LA.LAND_REGISTER_DATE,                  -- 등기일자
                 LA.LAND_GET_DATE,                       -- 취득일자
                 LA.LAND_BOOK_AMOUNT,                    -- 장부가액
                 LA.LAND_CHANGE_REASON                   -- 변동사유
                      FROM SEM_LAND_RETAIN LA
                   WHERE LA.LAND_DATE_T = '" + yearStr + monthStr + @"' AND (LA.LAND_OFFICE_T ='" + areaStr + @"' OR '--' = '" + areaStr + @"')";

        System.IO.StreamWriter writer = new System.IO.StreamWriter("c://aaa.txt");
        writer.Write(query);
        writer.Close();

        return query;
    }
}
