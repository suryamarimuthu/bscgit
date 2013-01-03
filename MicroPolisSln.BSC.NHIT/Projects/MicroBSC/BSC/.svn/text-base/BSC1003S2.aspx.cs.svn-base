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

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC1003S2 : AppPageBase
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

        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, true, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlEstDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultMethod, "", true, 120);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);
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
        _ikpi_code    = txtKPICode.Text.Trim();
        _ikpi_name    = txtKPIName.Text.Trim();
        _iemp_name    = txtChamName.Text.Trim();
        _iest_dept_id = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        _ilogin_id    = gUserInfo.Emp_Ref_ID;
        _iymd         = PageUtility.GetByValueDropDownList(ddlEstTermMonth, ""); // (ddlEstTermMonth.Items.Count > 0) ? ddlEstTermMonth.SelectedValue : "";

        MicroBSC.BSC.Biz.Biz_Bsc_Mbo_Kpi_Weight objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Mbo_Kpi_Weight();
        DataSet ds = objBSC.GetKpiAnalysis
            ( _iestterm_ref_id
            , _ilogin_id
            , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
            , "MS"
            , _iresult_input_method
            , _ikpi_code
            , _ikpi_name
            , "Y"
            , _iemp_name
            , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
            );


        ugrdKpiResultList.DataSource = ds;
        ugrdKpiResultList.DataBind();

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

    #region 서버이벤트
    protected void ugrdKpiResultList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //this.SetDraftLegend(sender, e);
    }

    protected void ugrdKpiResultList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        string strTrend = e.Row.Cells.FromKey("TREND").Value.ToString();

        switch (strTrend)
        {
            case "UP":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_e_up.gif'>"; ;
                break;
            case "DOWN":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_b_down.gif'>"; ;
                break;
            case "FLAT":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_m.gif'>"; ;
                break;
            default:
                break;
        }

        e.Row.Cells.FromKey("THRESHOLD_IMG").Value = "<div align=center><img src='../images/" + e.Row.Cells.FromKey("THRESHOLD_IMG").Value.ToString() + "'></div>";

        double dTemp = 0;
        string sARate = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ACHV_RATE").Value);
        e.Row.Cells.FromKey("ACHV_RATE").Value = (double.TryParse(sARate,out dTemp)) ? Convert.ToDouble(sARate.Replace('-','0')).ToString("#,###,###,##0.00") : sARate;

        //_iTRow += 1;

        //lblCountRow.Text = "Total Rows : " + _iTRow.ToString();
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        //KPIResult kpiResult = new KPIResult();

        bool isOK = false;

        _iymd = ddlEstTermMonth.SelectedValue.ToString();

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
        if (!isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정 항목을 선택하세요.", false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.", false);

        }
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

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.SetResultListGrid();
    }
    #endregion
}
