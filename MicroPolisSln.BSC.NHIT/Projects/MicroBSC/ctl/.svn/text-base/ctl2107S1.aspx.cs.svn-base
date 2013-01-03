using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Biz;
using MicroBSC.Common;



using MicroBSC.Integration.COM.Biz;
using MicroBSC.RolesBasedAthentication;


public partial class ctl_ctl2107s1 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        initGrid();
        

        if (this.radioDept.Checked)
            searchDept();
        else if (this.radioUser.Checked)
            searchUser();
    }



    protected void searchDept()
    { 
        doBindDept();
    }



    protected void searchUser()
    {
        doBindUser();
    }    




    protected void ibtnSync_Click(object sender, EventArgs e)
    {
        bool Result = syncDept();

        if (Result && radioUser.Checked)
            Result = syncUSer();

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("성공했습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("실패했습니다.");
        }


        initGrid();


        if (this.radioDept.Checked)
            searchDept();
        else if (this.radioUser.Checked)
            searchUser();
    }




    protected bool syncDept()
    {
        Biz_Com_IF bizComIF = new Biz_Com_IF();
        SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;


        bool Result = bizComIF.Sync_Dept_IF(gUserInfo.LoginID);

        return Result;
    }




    

    protected bool syncUSer()
    {
        Biz_Com_IF bizComIF = new Biz_Com_IF();
        SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;

        bool Result = bizComIF.Sync_Emp_IF(gUserInfo.LoginID);

        return Result;
    }




    protected void doBindDept()
    {
        Biz_Com_IF bizComIF = new Biz_Com_IF();


        DataTable DT = new DataTable();
        string option = this.searchOption.SelectedValue;


        Biz_Com_IF.GUBUN gubun;


        if (option.Equals("MATCH"))
            gubun = Biz_Com_IF.GUBUN.MATCH;
        else if (option.Equals("NOTMATCH"))
            gubun = Biz_Com_IF.GUBUN.NOTMATCH;
        else
            gubun = Biz_Com_IF.GUBUN.TOTAL;


        DT = bizComIF.Get_Diff_Dept_IF(gubun);


        this.lblRowCount.Text = DT.Rows.Count.ToString();

        this.ugrdDept.Visible = true;
        this.ugrdDept.DataSource = DT;
        this.ugrdDept.DataBind();
    }


    protected void doBindUser()
    {
        Biz_Com_IF bizComIF = new Biz_Com_IF();


        DataTable DT = new DataTable();
        string option = this.searchOption.SelectedValue;


        Biz_Com_IF.GUBUN gubun;

        if (option.Equals("MATCH"))
            gubun = Biz_Com_IF.GUBUN.MATCH;
        else if (option.Equals("NOTMATCH"))
            gubun = Biz_Com_IF.GUBUN.NOTMATCH;
        else
            gubun = Biz_Com_IF.GUBUN.TOTAL;



        int iTotalRows = bizComIF.Get_Diff_Emp_IF_Count(gubun);
        int iLastPage = (int)Math.Ceiling((Double)iTotalRows / ugrdUser.DisplayLayout.Pager.PageSize);
        int iFirstRow = (ugrdUser.DisplayLayout.Pager.CurrentPageIndex - 1) * ugrdUser.DisplayLayout.Pager.PageSize;
        int iLastRow = ugrdUser.DisplayLayout.Pager.CurrentPageIndex * ugrdUser.DisplayLayout.Pager.PageSize;


        ViewState.Add("CurrentPageIndex", ugrdUser.DisplayLayout.Pager.CurrentPageIndex);
        ViewState.Add("PageCount", iLastPage);


        this.lblRowCount.Text = iTotalRows.ToString();


        DT = bizComIF.Get_Diff_Emp_IF(gubun, iFirstRow + 1, iLastRow);

        this.ugrdUser.Visible = true;
        this.ugrdUser.DataSource = DT;
        this.ugrdUser.DataBind();
    }


    protected void initGrid()
    {
        this.ugrdDept.Clear();
        this.ugrdDept.Visible = false;
        this.ugrdUser.Clear();
        this.ugrdUser.Visible = false;
    }


    protected void ugrdDept_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "성과관리부서";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "기간시스템부서";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;        
        
        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[9].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanY = 2;
    }



    protected void ugrdUser_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "성과관리부서";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "기간시스템부서";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 5;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[9].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanY = 2;

        /*
        ugrdUser.DisplayLayout.Pager.AllowCustomPaging = true;
        ugrdUser.DisplayLayout.Pager.AllowPaging = true;
        ugrdUser.DisplayLayout.Pager.StyleMode = PagerStyleMode.Numeric;
         */
    }


    protected void ugrdUser_PreRender(object sender, System.EventArgs e)
    {
        ugrdUser.DisplayLayout.Pager.CurrentPageIndex = (int)ViewState["CurrentPageIndex"];
        ugrdUser.DisplayLayout.Pager.PageCount = (int)ViewState["PageCount"];
    }
    protected void ugrdUser_PageIndexChanged(object sender, Infragistics.WebUI.UltraWebGrid.PageEventArgs e)
    {
        ugrdUser.DisplayLayout.Pager.CurrentPageIndex = e.NewPageIndex;
        searchUser();
    }



    protected void ugrdDept_InitializeRow(object sender, RowEventArgs e)
    {
        System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
        string RedImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/red.gif");
        string BlueImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/blue.gif");



        string SRC_DEPT_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("SRC_DEPT_CODE").Value);
        string SRC_UP_DEPT_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("SRC_UP_DEPT_CODE").Value);

        string TARGET_DEPT_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("TARGET_DEPT_CODE").Value);
        string TARGET_UP_DEPT_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("TARGET_UP_DEPT_CODE").Value);

        if (!SRC_UP_DEPT_CODE.Equals(TARGET_UP_DEPT_CODE))
            strbuilder.AppendLine("상위부서 다름");

        if (!SRC_DEPT_CODE.Equals(TARGET_DEPT_CODE))
        {
            if (strbuilder.Length > 0)
                strbuilder.AppendLine(", ");
            strbuilder.AppendLine("부서 다름");
        }


        if (strbuilder.Length > 0)
        {
            e.Row.Cells.FromKey("STATUS").Value = strbuilder.ToString();
            e.Row.Cells.FromKey("STATUS_IMG").Value = RedImgUrl;
        }
        else
            e.Row.Cells.FromKey("STATUS_IMG").Value = BlueImgUrl;
    }
    //protected void CompareDeptInfo(DataRow DR)
    //{
    //    System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
    //    string RedImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/red.gif");
    //    string BlueImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/blue.gif");



    //    string SRC_DEPT_CODE = DR["SRC_DEPT_CODE"].ToString();
    //    string SRC_UP_DEPT_CODE = DR["SRC_UP_DEPT_CODE"].ToString();

    //    string TARGET_DEPT_CODE = DR["TARGET_DEPT_CODE"].ToString();
    //    string TARGET_UP_DEPT_CODE = DR["TARGET_UP_DEPT_CODE"].ToString();

    //    if (!SRC_UP_DEPT_CODE.Equals(TARGET_UP_DEPT_CODE))
    //        strbuilder.AppendLine("상위부서 다름");

    //    if (!SRC_DEPT_CODE.Equals(TARGET_DEPT_CODE))
    //    {
    //        if (strbuilder.Length > 0)
    //            strbuilder.AppendLine(", ");
    //        strbuilder.AppendLine("부서 다름");
    //    }


    //    if (strbuilder.Length > 0)
    //    {
    //        DR["STATUS"] = strbuilder.ToString();
    //        DR["STATUS_IMG"] = RedImgUrl;
    //    }
    //    else
    //        DR["STATUS_IMG"] = BlueImgUrl;
    //}



    protected void ugrdUser_InitializeRow(object sender, RowEventArgs e)
    {
        System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
        string RedImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/red.gif");
        string BlueImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/blue.gif");




        string SRC_DEPT_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("SRC_DEPT_CODE").Value);
        string SRC_EMP_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("SRC_EMP_CODE").Value);

        string TARGET_DEPT_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("TARGET_DEPT_CODE").Value);
        string TARGET_EMP_CODE = DataTypeUtility.GetString(e.Row.Cells.FromKey("TARGET_EMP_CODE").Value);

        if (!SRC_EMP_CODE.Equals(TARGET_EMP_CODE))
            strbuilder.AppendLine("사원 다름");

        if (!SRC_DEPT_CODE.Equals(TARGET_DEPT_CODE))
        {
            if (strbuilder.Length > 0)
                strbuilder.AppendLine(", ");
            strbuilder.AppendLine("부서 다름");
        }


        if (strbuilder.Length > 0)
        {
            e.Row.Cells.FromKey("STATUS").Value = strbuilder.ToString();
            e.Row.Cells.FromKey("STATUS_IMG").Value = RedImgUrl;
        }
        else
            e.Row.Cells.FromKey("STATUS_IMG").Value = BlueImgUrl;
    }
    //protected void CompareEmpInfo(DataRow DR)
    //{
    //    System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
    //    string RedImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/red.gif");
    //    string BlueImgUrl = string.Format("<img src='{0}'>", "../images/icon/color/blue.gif");




    //    string SRC_DEPT_CODE = DR["SRC_DEPT_CODE"].ToString();
    //    string SRC_EMP_CODE = DR["SRC_EMP_CODE"].ToString();

    //    string TARGET_DEPT_CODE = DR["TARGET_DEPT_CODE"].ToString();
    //    string TARGET_EMP_CODE = DR["TARGET_EMP_CODE"].ToString();

    //    if (!SRC_EMP_CODE.Equals(TARGET_EMP_CODE))
    //        strbuilder.AppendLine("사원 다름");

    //    if (!SRC_DEPT_CODE.Equals(TARGET_DEPT_CODE))
    //    {
    //        if (strbuilder.Length > 0)
    //            strbuilder.AppendLine(", ");
    //        strbuilder.AppendLine("부서 다름");
    //    }


    //    if (strbuilder.Length > 0)
    //    {
    //        DR["STATUS"] = strbuilder.ToString();
    //        DR["STATUS_IMG"] = RedImgUrl;
    //    }
    //    else
    //        DR["STATUS_IMG"] = BlueImgUrl;
    //}
}
