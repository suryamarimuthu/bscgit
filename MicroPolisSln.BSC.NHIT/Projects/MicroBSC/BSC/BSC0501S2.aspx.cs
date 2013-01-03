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

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC0501S2 : AppPageBase
{
    #region 변수선언
    // Control for Call Back
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    private int    _iestterm_ref_id      = 0;
    private string _iresult_input_method = "";
    private string _ikpi_code            = "";
    private string _ikpi_name            = "";
    private string _iemp_name            = "";
    private int    _iest_dept_id         = 0;
    private int    _ilogin_id            = 0;
    private string _iymd                 = "";
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
        //WebCommon.SetMonthDropDownList(ddlEstTermMonth);
        //StrategyMapInfos stgMapInfo = new StrategyMapInfos();
        //_iymd = stgMapInfo.GetTMCODE();
        //ddlEstTermMonth.Items.FindByValue(_iymd.ToString()).Selected = true;

        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        
        
        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);

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
        _iestterm_ref_id      = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iresult_input_method = (ddlResultMethod.Items.Count > 0) ? ddlResultMethod.SelectedValue : "";
        _ikpi_code            = txtKPICode.Text.Trim();
        _ikpi_name            = txtKPIName.Text.Trim();
        _iemp_name            = txtChamName.Text.Trim();
        _iest_dept_id         = (ddlEstDept.Items.Count > 0 && ddlEstDept.SelectedValue != "") ? int.Parse(ddlEstDept.SelectedValue.ToString()) : 0;
        _ilogin_id            = gUserInfo.Emp_Ref_ID;
        _iymd                 = PageUtility.GetByValueDropDownList(ddlEstTermMonth,"");

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetKpiListForApproval(_iestterm_ref_id
                                                 , _iresult_input_method
                                                 , _ikpi_code
                                                 , _ikpi_name
                                                 , _iemp_name
                                                 , _iest_dept_id
                                                 , _iymd
                                                 , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                                                 , _ilogin_id
                                                    );

        ugrdKpiResultList.DataSource = ds;
        ugrdKpiResultList.DataBind();

    }
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

        if (drw["CONFIRMSTATUS"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CONFIRMSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CONFIRMSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        //KPIResult kpiResult = new KPIResult();

        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        bool isChkStat = false;

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
