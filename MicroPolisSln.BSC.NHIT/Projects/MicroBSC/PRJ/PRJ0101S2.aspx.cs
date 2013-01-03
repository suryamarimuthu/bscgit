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

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;


public partial class PRJ_PRJ0101S2 : PrjPageBase
{
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //InitializeGrid(ugrdPrjList);

        if (!IsPostBack)
        {
            this.SetFormInit();
            this.SetPrjList();
        }
        else
        {

        }

        ltrScript.Text = "";
    }

    

    #region 내부 함수
    public void SetFormInit()
    {
        wdcPlanStartDate.Value = base.GetStartDayofCurrent();
        wdcPlanEndDate.Value   = base.GetEndDayofCurrent();

        WebCommon.SetComDeptDropDownList(ddlOwnerDeptID, true);

        Biz_Com_Code_Info codeinfo = new Biz_Com_Code_Info();
        codeinfo.GetProjectType(ddlPrjType, "", true, 120);
    }

    public void SetPrjList()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info();

        string iprj_code          = txtPrjCode.Text.Trim();
        string iprj_name          = txtPrjName.Text.Trim();
        int iowner_dept_id        = WebUtility.GetIntByValueDropDownList(ddlOwnerDeptID);
        string iowner_emp_name    = txtOwnerEmpName.Text.Trim();
        string iprj_type          = WebUtility.GetByValueDropDownList(ddlPrjType);
        DateTime iplan_start_date = (DateTime)wdcPlanStartDate.Value;
        DateTime iplan_end_date   = (DateTime)wdcPlanEndDate.Value;
        int iowner_emp_id         = (User.IsInRole(ROLE_ADMIN)) ? 0 : EMP_REF_ID;

        string sSDate = iplan_start_date.Year.ToString() + "-" + iplan_start_date.Month.ToString().PadLeft(2, '0') + "-" + iplan_start_date.Day.ToString().PadLeft(2, '0') + " 00:00:00";
        string sEDate = iplan_end_date.Year.ToString()   + "-" + iplan_end_date.Month.ToString().PadLeft(2, '0')   + "-" + iplan_end_date.Day.ToString().PadLeft(2, '0') + " 23:59:59";

        //int iTxrUser = (User.IsInRole(ROLE_ADMIN)) ? 0 : EMP_REF_ID;

        DataSet rDs = objPrj.GetTotalStateList(iprj_code
                                    , iprj_name
                                    , iowner_dept_id
                                    , iowner_emp_name
                                    , iprj_type
                                    , Convert.ToDateTime(sSDate)
                                    , Convert.ToDateTime(sEDate)
                                    , iowner_emp_id);

        if (rDs.Tables.Count > 0)
        {
            rDs.Tables[0].DefaultView.Sort = "PRJ_CODE ASC";
            ugrdPrjList.Clear();
            ugrdPrjList.DataSource = rDs.Tables[0].DefaultView;
            ugrdPrjList.DataBind();
        }
        else
        {
            ugrdPrjList.Clear();
        }


        lblRowCount.Text = rDs.Tables[0].Rows.Count.ToString();


        //DataSet ds = objPrj.GetExcelDownList(iprj_code
        //                           , iprj_name
        //                           , iowner_dept_id
        //                           , iowner_emp_name
        //                           , iprj_type
        //                           , iplan_start_date
        //                           , iplan_end_date
        //                           , gUserInfo.Emp_Ref_ID);

        //UltraWebGrid1.Clear();
        //UltraWebGrid1.DataSource = ds;
        //UltraWebGrid1.DataBind();
    }


    private void InitializeGrid(UltraWebGrid grid)
    {
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in grid.DisplayLayout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
        }

        // 단일 헤더 합침

        ch = grid.DisplayLayout.Bands[0].Columns.FromKey("PRJ_CODE").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = grid.DisplayLayout.Bands[0].Columns.FromKey("PRJ_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = grid.DisplayLayout.Bands[0].Columns.FromKey("PROCEED_RATE").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = grid.DisplayLayout.Bands[0].Columns.FromKey("OWNER_EMP_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = grid.DisplayLayout.Bands[0].Columns.FromKey("TASK_OWNER_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;


        ch = grid.DisplayLayout.Bands[0].Columns.FromKey("EFFECTIVENESS").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획기간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "비 용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 10;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        grid.DisplayLayout.Bands[0].HeaderLayout.Add(ch);
        grid.DisplayLayout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        
    }


    #endregion

    #region Event

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        SetPrjList();
    }
    
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetPrjList();
    }

    protected void ugrdPrjList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        DataRowView dr = (DataRowView)e.Data;

        Biz_Prj_Resource objResource = new Biz_Prj_Resource();
        //Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();

        DataSet ds = objResource.GetAllList(DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]), 0);
        //object oRate = objSchedule.GetTotalRate(DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]), 0);
        //double dTotalRate = 0;
       
        string EMP_NAMES = "";

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            EMP_NAMES += row["EMP_NAME"].ToString() + Environment.NewLine;
        }

        e.Row.Cells.FromKey("TASK_OWNER_NAME").Value = EMP_NAMES;
        
        //dTotalRate = DataTypeUtility.GetToDouble(oRate);
        //e.Row.Cells.FromKey("PROCEED_RATE").Value = dTotalRate.ToString("###.#0") + " %";
    
    }
    #endregion

    protected void ugrdPrjList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
        }

        // 단일 헤더 합침

        ch = e.Layout.Bands[0].Columns.FromKey("PRJ_CODE").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("PRJ_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("PROCEED_RATE").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("OWNER_EMP_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("TASK_OWNER_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;


        ch = e.Layout.Bands[0].Columns.FromKey("EFFECTIVENESS").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획기간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "비 용";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 8;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName = "PRJ" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName = "PRJ_TotalStatus";

        uGridExcelExporter.Export(this.UltraWebGrid1);
    }
}
