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
using System.Collections.Generic;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.BSC.Biz;
using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;
using System.Drawing;

public partial class PRJ_PRJ0101A3 : PrjPageBase
{
    private decimal _totalBudget;

    #region ==========================[변수선언]================

    public int IPrjRefID
    {
        get
        {
            if (ViewState["PRJ_REF_ID"] == null)
            {
                ViewState["PRJ_REF_ID"] = GetRequestByInt("PRJ_REF_ID", 0);
            }

            return (int)ViewState["PRJ_REF_ID"];
        }
        set
        {
            ViewState["PRJ_REF_ID"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public decimal ITotalBudget
    {
        get { return _totalBudget; }
        set { _totalBudget = value; }
    }

    /// <summary>
    /// 결재상태
    /// </summary>
    public string IApp_Status
    {
        get
        {
            if (ViewState["APP_STATUS"] == null)
            {
                ViewState["APP_STATUS"] = GetRequest("APP_STATUS");
            }
            return (string)ViewState["APP_STATUS"];
        }
        set
        {
            ViewState["APP_STATUS"] = value;
        }
    }

    /// <summary>
    /// 결재 상태명
    /// </summary>
    public string IApp_Status_Name
    {
        get
        {
            if (ViewState["APP_STATUS_NAME"] == null)
            {
                ViewState["APP_STATUS_NAME"] = GetRequest("APP_STATUS_NAME");
            }
            return (string)ViewState["APP_STATUS_NAME"];
        }
        set
        {
            ViewState["APP_STATUS_NAME"] = value;
        }
    }
    /// <summary>
    /// 결재 Id
    /// </summary>
    public decimal IApp_Ref_Id
    {
        get
        {
            if (ViewState["APP_REF_ID"] == null)
            {
                ViewState["APP_REF_ID"] = (decimal)GetRequestByInt("APP_REF_ID", 0);
            }

            return (decimal)ViewState["APP_REF_ID"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }

    /// <summary>
    /// 상신자
    /// </summary>
    public int IDraftEmpID
    {
        get
        {
            return (int)ViewState["DRAFT_EMP_ID"];
        }
        set
        {
            ViewState["DRAFT_EMP_ID"] = value;
        }
    }

    public string IAPP_CCB
    {
        get
        {
            if (ViewState["APP_CCB"] == null)
            {
                ViewState["APP_CCB"] = linkBtnDraft.ClientID.Replace('_', '$');
            }

            return (string)ViewState["APP_CCB"];
        }
        set
        {
            ViewState["APP_CCB"] = value;
        }
    }
    #endregion

    #region ================================= [ 결재처리 ]===================================
    /// <summary>
    /// 결재상태조회
    /// </summary>
    private void SetDraftInfo()
    {
        Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info(this.IApp_Ref_Id);
        this.IApp_Status = objApp.IApp_Status;
        this.IApp_Status_Name = objApp.IApp_Status_Name;
    }

    /// <summary>
    /// 수정결재요청
    /// </summary>
    private void RequestModifyDraft()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();
        bool blnRtn = objApp.RequestModifyDraft(this.IApp_Ref_Id, gUserInfo.Emp_Ref_ID);
        if (blnRtn)
        {
            this.SetDraftInfo();
            this.SetButton();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objApp.Transaction_Message, false);
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetFormInit();
            this.SetFormData();
        }
        else
        {

        }

        this.SetDraftInfo();
        SetButton();

        ltrScript.Text = "";

        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");
    }

    private void SetButton()
    {
        // 프로젝트 책임자가 아닐경우
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        bool bIsOwner = objPrj.IsOwnerEmpIDYN(gUserInfo.Emp_Ref_ID, this.IPrjRefID);

        if (this.IType == "A")
        {
            iBtnUpdate.Visible    = false;

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;

        }
        else if (this.IType == "U")
        {
            //iBtnUpdate.Visible = (this.IType == "D") ? false : true;

            switch (this.IApp_Status)
            {
                case "": // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;
                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_nodraft: // 결재상태 없음
                    iBtnDraft.Visible     = (bIsOwner) ? true : false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;
                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_draft: // 상신
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnUpdate.Visible    = false;
                    break;
                case Biz_Type.app_status_ondraft: // 결재중
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnUpdate.Visible    = false;
                    break;
                case Biz_Type.app_status_return: // 반려
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = (bIsOwner) ? true : false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_recall: // 회수
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = (bIsOwner) ? true : false;

                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_onmodify: // 수정결재
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = true;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    iBtnReWrite.Visible   = false;

                    iBtnUpdate.Visible    = (bIsOwner || (User.IsInRole(ROLE_ADMIN))) ? true : false;
                    break;
                case Biz_Type.app_status_complete: // 결재완료
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = (bIsOwner) ? true : false;
                    iBtnReWrite.Visible   = false;

                    iBtnUpdate.Visible    = false;
                    break;
                default:
                    iBtnDraft.Visible     = false;
                    iBtnMoDraft.Visible   = false;
                    iBtnReDraft.Visible   = false;
                    iBtnReqModify.Visible = false;
                    break;
            }


        }
        else if (this.IType == "D")
        {
            iBtnUpdate.Visible = (this.IType == "D") ? false : true;

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;


        }
        else if(this.IType == "S")
        {
            iBtnUpdate.Visible    = false;

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;

        }
        else
        {
            iBtnUpdate.Visible    = false;

            iBtnDraft.Visible     = false;
            iBtnReDraft.Visible   = false;
            iBtnMoDraft.Visible   = false;
            iBtnReqModify.Visible = false;

        }
    }

    public void SetFormInit()
    {
        iBtnDraft.OnClientClick   = "return OpenDraft('" + Biz_Type.app_draft_first + "');";
        iBtnReDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_redraft + "');";
        iBtnMoDraft.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_modify + "');";
        iBtnReWrite.OnClientClick = "return OpenDraft('" + Biz_Type.app_draft_rewrite + "');";
    }

    public void SetFormData()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        Biz_Prj_Resource prjResource = new Biz_Prj_Resource();
        Biz_Prj_Budget objBud = new Biz_Prj_Budget();

        this.IApp_Ref_Id = objPrj.IApp_Ref_Id;
        txtPRJ_CODE.Text = objPrj.IPrj_Code;
        txtPRJ_NAME.Text = objPrj.IPrj_Name;
        this.IDraftEmpID = objPrj.IOwner_Emp_Id;


        if (this.IPrjRefID == 0)
            return;

    
        lblPrjPeriod.Text = DataTypeUtility.GetToDateTime(objPrj.IPlan_Start_Date).ToShortDateString() + " ~ " + DataTypeUtility.GetToDateTime(objPrj.IPlan_End_Date).ToShortDateString();

        this.ITotalBudget = objPrj.ITotal_Budget;
        lblTotalBudgetAmount.Text = this.ITotalBudget.ToString("###,##0");


        ugrdBudgetList.Clear();

        DataSet ds = objBud.SelectMonthRateList(this.IPrjRefID);
        DataTable dt = objBud.GetDataTableSchema();
        DateTime dtStart = DataTypeUtility.GetToDateTime(objPrj.IPlan_Start_Date);
        DateTime dtEnd = DataTypeUtility.GetToDateTime(objPrj.IPlan_End_Date);


        for (DateTime date = dtStart; date <= dtEnd; )
        {

            DataRow dataRow = null;

            dataRow = GetBudGetYM(ds.Tables[0], date.ToString("yyyyMM"));

            if (dataRow == null)
            {
                dataRow = dt.NewRow();

                dataRow["ITYPE"] = "A";
                dataRow["PRJ_REF_ID"] = this.IPrjRefID;
                dataRow["BUDGET_YM"] = date.ToString("yyyyMM");
                dataRow["BUDGET_YM_NAME"] = date.ToString("yyyy년 MM월");
                dataRow["MONTHLY_AMOUNT"] = 0;
                dataRow["AMOUNT"] = 0;
                dataRow["RATE"] = DBNull.Value;

                dt.Rows.Add(dataRow);
            }
            else
            {
                dt.ImportRow(dataRow);
            }

            date = date.AddMonths(1);
        }

        ugrdBudgetList.DataSource = dt;
        ugrdBudgetList.DataBind();


    }

    private DataRow GetBudGetYM(DataTable dt, string budgetYM)
    {
        DataRow dataRow = null;

        foreach (DataRow row in dt.Rows)
        {
            if (row["BUDGET_YM"].ToString() == budgetYM)
            {
                dataRow = row;
                break;
            }
        }

        return dataRow;
    }

    private decimal GetPlanSumBudGet()
    {
        decimal sumAmount = 0;

        foreach (UltraGridRow row in ugrdBudgetList.Rows)
        {
            sumAmount += DataTypeUtility.GetToDecimal(row.Cells.FromKey("MONTHLY_AMOUNT").Value);
        }

        return sumAmount;
    }

    protected void ugrdBudgetList_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        ugrdBudgetList.DisplayLayout.ColFootersVisibleDefault = Infragistics.WebUI.UltraWebGrid.ShowMarginInfo.Yes;
        ugrdBudgetList.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;


        UltraGridColumn budget_ymColumn = e.Layout.Bands[0].Columns.FromKey("BUDGET_YM_NAME");
        budget_ymColumn.Footer.Caption = "합 계";
        budget_ymColumn.FooterStyleResolved.HorizontalAlign = HorizontalAlign.Right;

        UltraGridColumn monthlyAmountColumn = e.Layout.Bands[0].Columns.FromKey("MONTHLY_AMOUNT");
        //monthlyAmountColumn.Width = Unit.Percentage(20);
        monthlyAmountColumn.Format = "###,###,###,##0";
        monthlyAmountColumn.CellStyle.HorizontalAlign = HorizontalAlign.Right;
        monthlyAmountColumn.FooterTotal = SummaryInfo.Sum;
        monthlyAmountColumn.Footer.Style.HorizontalAlign = HorizontalAlign.Right;
        monthlyAmountColumn.FooterStyle.Padding.Left = new Unit(6);

        UltraGridColumn amountColumn = e.Layout.Bands[0].Columns.FromKey("AMOUNT");
        //amountColumn.Width = Unit.Percentage(20);
        amountColumn.Format = "###,###,###,##0";
        amountColumn.CellStyle.HorizontalAlign = HorizontalAlign.Right;
        amountColumn.FooterTotal = SummaryInfo.Sum;
        amountColumn.Footer.Style.HorizontalAlign = HorizontalAlign.Right;
        amountColumn.FooterStyle.Padding.Left = new Unit(6);

        UltraGridColumn rateColumn = e.Layout.Bands[0].Columns.FromKey("RATE");
        //rateColumn.Width = Unit.Percentage(20);
        rateColumn.Format = "##0.00";
        rateColumn.CellStyle.HorizontalAlign = HorizontalAlign.Right;
        rateColumn.FooterTotal = SummaryInfo.Avg;
        rateColumn.Footer.Style.HorizontalAlign = HorizontalAlign.Right;
        rateColumn.FooterStyle.Padding.Left = new Unit(6);

        ugrdBudgetList.DisplayLayout.FooterStyleDefault.BackColor = Color.FromName("#94BAC9");
    }
    protected void ugrdBudgetList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        Biz_Prj_Execution objExecution = new Biz_Prj_Execution();

        DataSet ds = objExecution.GetTotalSum(this.IPrjRefID, drw["BUDGET_YM"].ToString(), DataTypeUtility.GetToDecimal(drw["MONTHLY_AMOUNT"]));

        if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        {
            e.Row.Cells.FromKey("AMOUNT").Value = ds.Tables[0].Rows[0]["AMOUNT"];
            e.Row.Cells.FromKey("RATE").Value   = ds.Tables[0].Rows[0]["RATE"];
        }


    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        this.ITotalBudget = objPrj.ITotal_Budget;

        // 비용금액 체크 
        if (GetPlanSumBudGet() > this.ITotalBudget)
        {
            ltrScript.Text = JSHelper.GetAlertScript("계획예산금액이 총예산금액보다 큽니다. 다시 예산을 책정해주세요.");
            return;
        }

        this.UpdateViewData();
    }
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        //ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
        ltrScript.Text = string.Format("<script language=javascript>parent.window.opener.__doPostBack('{0}',''); parent.window.close(); </script>", this.ICCB1);
    }

    //----------------------------- 결재처리 이벤트

    protected void linkBtnDraft_Click(object sender, EventArgs e)
    {
        //this.SetKPIMaster();
        this.SetDraftInfo();
        this.SetButton();
    }

    protected void iBtnDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnReDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnMoDraft_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }
    

    private void UpdateViewData()
    {

        #region 비용관리 저장

        Biz_Prj_Budget objBudget = new Biz_Prj_Budget();

        int intRtn = objBudget.DeleteData(this.IPrjRefID
                           , ""
                           , gUserInfo.Emp_Ref_ID);


        foreach (UltraGridRow row in ugrdBudgetList.Rows)
        {
            objBudget.IPrj_Ref_Id = this.IPrjRefID;
            objBudget.IBudget_Ym = DataTypeUtility.GetValue(row.Cells.FromKey("BUDGET_YM").Value);
            objBudget.IMonthly_Amount = DataTypeUtility.GetToDecimal(row.Cells.FromKey("MONTHLY_AMOUNT").Value);


            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objBudget.InsertData(objBudget.IPrj_Ref_Id
                      , objBudget.IBudget_Ym
                      , objBudget.IMonthly_Amount
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objBudget.UpdateData(objBudget.IPrj_Ref_Id
                                   , objBudget.IBudget_Ym
                                   , objBudget.IMonthly_Amount
                                   , gUserInfo.Emp_Ref_ID);
            }
        }

        #endregion

        if (intRtn > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("비용관리정보가  저장되었습니다.");
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

}
