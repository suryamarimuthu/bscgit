﻿using System;
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

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC0501S1 : AppPageBase
{
    #region 변수선언
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


    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
                ViewState["YMD"] = "0";
            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    int iTRow = 0;
    int iCRow = 0;

    private int _iestterm_ref_id = 0;
    private string _iresult_input_method = "";
    private string _ikpi_code = "";
    private string _ikpi_name = "";
    private string _iemp_name = "";
    private int _iest_dept_id = 0;
    private int _ilogin_id = 0;
    private string _iymd = "";
    #endregion

    #region 초기 세팅 메소드
    protected void Page_Load(object sender, EventArgs e)
    {
        // 웹 취약성 검사 때문에 처리
        if (ICCB1.Equals("-0")
            || IYMD.Equals("-0"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("악성 요청을 거부합니다.", false);
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        ugrdKpiResultList.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        if (!Page.IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        {
            this.PostBackSetting();
        }

    }

    private void NotPostBackSetting()
    {
        this.InitControlValue();
        this.SetResultListGrid();
    }

    private void PostBackSetting()
    {

    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        //WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        //WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, true, gUserInfo.Emp_Ref_ID);
        WebCommon.SetComDeptDropDownList(ddlEstDept, true, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlEstDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultMethod, "", true, 120);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);

        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYMD = PageUtility.GetByValueDropDownList(ddlEstTermMonth);
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetResultListGrid();
    }

    #endregion

    #region 내부함수
    public void SetResultListGrid()
    {
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iresult_input_method = (ddlResultMethod.Items.Count > 0) ? ddlResultMethod.SelectedValue : "";
        _ikpi_code = txtKPICode.Text.Trim();
        _ikpi_name = txtKPIName.Text.Trim();
        _iemp_name = txtChamName.Text.Trim();
        //_iest_dept_id         = (ddlEstDept.Items.Count > 0 && ddlEstDept.SelectedValue != "") ? int.Parse(ddlEstDept.SelectedValue.ToString()) : 0;
        _iest_dept_id = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        _ilogin_id = gUserInfo.Emp_Ref_ID;
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, ""); // (ddlEstTermMonth.Items.Count > 0) ? ddlEstTermMonth.SelectedValue : "";

        //2011.08.18 허성덕과장 요청으로 관리자권한자에게는 모든 MBO 실적보이도록
        int isAdmin = 0;
        if (User.IsInRole(ROLE_ADMIN))
            isAdmin = 1;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetKpiListForResultInput(_iestterm_ref_id
                                                   , _iresult_input_method
                                                   , _ikpi_code
                                                   , _ikpi_name
                                                   , _iemp_name
                                                   , _iest_dept_id
                                                   , _iymd
                                                   , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                                                   , "Y"
                                                   , _ilogin_id
                                                   , isAdmin
                                                    );

        ugrdKpiResultList.DataSource = ds;
        ugrdKpiResultList.DataBind();

        //this.SetDraftImage(ugrdKpiResultList);
    }

    //public void SetDraftImage(UltraWebGrid iUgrd)
    //{
    //    int iRow = iUgrd.Rows.Count;
    //    int iCol = iUgrd.Columns.Count;
    //    int iIdx = 0;

    //    for (int i = 0; i < iCol; i++)
    //    {
    //        if (!iUgrd.Columns[i].Hidden)
    //        {
    //            iIdx += 1;
    //            break;
    //        }
    //    }

    //    if (iRow > 0)
    //    {
    //        iUgrd.Rows.Add();
    //        iUgrd.Rows[iRow].Cells[iIdx-1]. = 2;
    //    }
    //}
    #endregion

    #region 서버이벤트
    protected void ugrdKpiResultList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        if (drw["CHECK_YN"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        if (drw["CHECKSTATUS"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = DataTypeUtility.GetValue(e.Row.Cells.FromKey("APP_STATUS").Value);
        objImg.ImageUrl = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);

        iTRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            iCRow += 1;
        }

        lblRowCount.Text = iCRow.ToString() + "/" + iTRow.ToString();



        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string url = "<a href='#' onclick='doPoppingUp_ResultList(\"{0}\",\"{1}\",\"{2}\",\"{3}\")'>{4}</a>";
        string link = string.Format(url, kpi_ref_id, IYMD, IESTTERM_REF_ID, ICCB1, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = link;
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        //KPIResult kpiResult = new KPIResult();

        //CheckBox chk;
        //UltraGridRow row;
        //TemplatedColumn col;
        //bool isOK = false;
        //bool isChkStat = false;

        //_iymd = ddlEstTermMonth.SelectedValue.ToString();

        /*
        for (int i = 0; i < ugrdKpiResultList.Rows.Count; i++)
        {
            row = ugrdKpiResultList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                if (Convert.ToDouble(row.Cells.FromKey("CHECKSTATUS").Value.ToString()) == 0)
                {
                    isChkStat = true;
                }
                else
                {
                    try
                    {
                        isOK = kpiResult.ConfirmStatus(int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                                    , TMCODE
                                                    , "E");
                    }
                    catch (Exception ex)
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.." + ex.Message, false);
                        return;
                    }
                }
            }
        }

        if (isChkStat)
        {
            ltrScript.Text = JSHelper.GetAlertScript("일부 선택 항목이 입력및 수집된 항목이 아니어서 처리되지 않았습니다.", false);
        }
        */
        //if (!isOK)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("확정 항목을 선택하세요.", false);
        //}
        //else
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.", false);

        //}
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetResultListGrid();
    }

    protected void iBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        /*
        KPIResult kpiResult = new KPIResult();

        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        TMCODE = int.Parse(ddlEstTermMonth.SelectedValue.ToString());
        for (int i = 0; i < ugrdKpiResultList.Rows.Count; i++)
        {
            row = ugrdKpiResultList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    isOK = kpiResult.ConfirmStatus(int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                                , TMCODE
                                                , "C");
                }
                catch (Exception ex)
                {
                    ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.." + ex.Message, false);
                    return;
                }
            }
        }

        if (!isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정취소 항목을 선택하세요.", false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.", false);

            GridBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                    , txtKPICode.Text
                    , PageUtility.GetIntByValueDropDownList(ddlResultMethod)
                    , PageUtility.GetIntByValueDropDownList(ddlEstDept)
                    , txtChamName.Text);
        }
       */

    }

    public void SetDraftLegend(object sender, LayoutEventArgs e)
    {
        try
        {
            e.Layout.StationaryMargins = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault = CellClickAction.RowSelect;
            e.Layout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Left;
            e.Layout.FooterStyleDefault.VerticalAlign = VerticalAlign.Middle;

            int iCol = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg = iCol;  // Start Colspan Length
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
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX = iMrg;
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

    protected void ugrdKpiResultList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        this.SetDraftLegend(sender, e);
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.SetResultListGrid();
    }

    #endregion
}
