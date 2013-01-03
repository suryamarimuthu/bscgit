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
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;


public partial class PRJ_PRJ0101S1 : PrjPageBase
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
        codeinfo.GetProjectType(ddlPrjType, 0, true, 120);
    }

    public void SetPrjList()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info();

        string iprj_code        = txtPrjCode.Text.Trim();
        string iprj_name        = txtPrjName.Text.Trim();
        int iowner_dept_id      = WebUtility.GetIntByValueDropDownList(ddlOwnerDeptID);
        string iowner_emp_name  = txtOwnerEmpName.Text.Trim();
        string iprj_type        = WebUtility.GetByValueDropDownList(ddlPrjType);
        DateTime iplan_start_date = (DateTime)wdcPlanStartDate.Value;
        DateTime iplan_end_date   = (DateTime)wdcPlanEndDate.Value;
        int iowner_emp_id       = (User.IsInRole(ROLE_ADMIN)) ? 0 : gUserInfo.Emp_Ref_ID;

        string sSDate = iplan_start_date.Year.ToString() + "-" + iplan_start_date.Month.ToString().PadLeft(2, '0') + "-" + iplan_start_date.Day.ToString().PadLeft(2, '0') + " 00:00:00";
        string sEDate = iplan_end_date.Year.ToString()   + "-" + iplan_end_date.Month.ToString().PadLeft(2, '0')   + "-" + iplan_end_date.Day.ToString().PadLeft(2, '0') + " 23:59:59";


        DataSet rDs = objPrj.GetUserAllList(iprj_code
                                    ,  iprj_name
                                    ,  iowner_dept_id
                                    ,  iowner_emp_name
                                    ,  iprj_type
                                    ,  Convert.ToDateTime(sSDate)
                                    ,  Convert.ToDateTime(sEDate)
                                    , iowner_emp_id);

        ugrdPrjList.Clear();
        ugrdPrjList.DataSource = rDs;
        ugrdPrjList.DataBind();

        lblRowCount.Text = rDs.Tables[0].Rows.Count.ToString();
    }

    /// <summary>
    /// 결재아이콘 범례생성
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetDraftLegend(object sender, LayoutEventArgs e)
    { 
        try
        {
            e.Layout.StationaryMargins                  = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault             = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault           = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height          = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor       = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor       = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right    = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign   = VerticalAlign.Middle;

            int iCol  = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg  = iCol;  // Start Colspan Length
            int iFRow = 0;     // Start Colspan Index
            for (int i = 0; i < iCol; i++)
            {
                iFRow += 1;
                if (e.Layout.Bands[0].Columns[i].Hidden)
                {
                    iMrg -= 1;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX     = iMrg;
                    break;
                }
            }

            if (iFRow > 0)
            {
                string sLegend = Biz_Type.app_legend;

                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Caption = sLegend;
                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Style.Width = Unit.Percentage(100);
            }
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        }
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
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("ISDELETE");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("ISDELETE").Value.ToString() == "N") ?
                                    "../images/icon_o.gif" : "../images/icon_x.gif";

        cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = DataTypeUtility.GetValue(e.Row.Cells.FromKey("APP_STATUS").Value);
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
    }

    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName = "PRJ" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName = "PRJ_LIST";

        ugrdPrjList.Columns.FromKey("ISDELETE").Hidden = true;  //이미지컬럼 숨김
        ugrdPrjList.Columns.FromKey("APP_STATUS").Hidden = true;  //이미지컬럼 숨김

        uGridExcelExporter.Export(ugrdPrjList);

        ugrdPrjList.Columns.FromKey("ISDELETE").Hidden = false;  //이미지컬럼
        ugrdPrjList.Columns.FromKey("APP_STATUS").Hidden = false;  //이미지컬럼

    }
    protected void ugrdPrjList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        this.SetDraftLegend(sender, e);

        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
        }

        // 단일 헤더 합침

        //ch = e.Layout.Bands[0].Columns.FromKey("PRJ_CODE").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        //ch = e.Layout.Bands[0].Columns.FromKey("PRJ_NAME").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        //ch = e.Layout.Bands[0].Columns.FromKey("PROCEED_RATE").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        //ch = e.Layout.Bands[0].Columns.FromKey("OWNER_EMP_NAME").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;

        //ch = e.Layout.Bands[0].Columns.FromKey("TASK_OWNER_NAME").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;


        //ch = e.Layout.Bands[0].Columns.FromKey("EFFECTIVENESS").Header;
        //ch.RowLayoutColumnInfo.SpanY = 2;
        //ch.RowLayoutColumnInfo.OriginY = 0;


        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "기본정보";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 5;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "계획기간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "실행기간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "상 태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }

    #endregion
}
