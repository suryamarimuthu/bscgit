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
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC0901S2 : AppPageBase
{
    #region 변수선언
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

    public int IVersion_No
    {
        get
        {
            if (ViewState["VERSION_NO"] == null)
            {
                ViewState["VERSION_NO"] = GetRequestByInt("VERSION_NO", 0);
            }

            return (int)ViewState["VERSION_NO"];
        }
        set
        {
            ViewState["VERSION_NO"] = value;
        }
    }
    #endregion
    #region 페이지 초기화 함수
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();

        ltrScript.Text = "";
    }


    private void SetAllTimeTop()
    {
        
    }

    private void InitControlValue()
    {
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetApprovalBizType(ddlBizType, "", true, 100);
        //objCode.GetApprovalStatus(ddlApprovalStatus, "", true, 100);

        wdcSDate.Value = base.GetDefaultYMD(DateType.StartDate);
        wdcEDate.Value = base.GetDefaultYMD(DateType.EndDate);
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        this.SetApprovalList();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }

    #endregion

    #region 내부 함수

    public void SetApprovalList()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();

        string sSDate = base.GetYMDFromDateTime((DateTime)wdcSDate.Value, "-") + " 00:00:00";
        string sEDate = base.GetYMDFromDateTime((DateTime)wdcEDate.Value, "-") + " 23:59:59";

        DateTime dtSDate = Convert.ToDateTime(sSDate);
        DateTime dtEDate = Convert.ToDateTime(sEDate);

        DataSet rDs = objApp.GetMyDraftList(gUserInfo.Emp_Ref_ID, PageUtility.GetByValueDropDownList(ddlBizType), 0, dtSDate, dtEDate);

        ugrdAppList.Clear();
        ugrdAppPrc.Clear();

        if (rDs.Tables.Count > 0)
        {
            ugrdAppList.DataSource = rDs.Tables[0].DefaultView;
            ugrdAppList.DataBind();
            lblCountRow.Text = "Total Rows : " + rDs.Tables[0].Rows.Count.ToString();
        }
        else
        {
            lblCountRow.Text = "Total Rows : 0";
        }
    }

    public void SetAppDetailList()
    {
        Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
        DataSet rDs = objPrc.GetAllList(this.IApp_Ref_Id, this.IVersion_No);

        ugrdAppPrc.Clear();
        ugrdAppPrc.DataSource = rDs;
        ugrdAppPrc.DataBind();
    }

    public void SetRecallDraft()
    {
        DataTable dtDraft = new DataTable("RECALL_LIST");
        dtDraft.Columns.Add("APP_REF_ID", typeof(int));
        dtDraft.Columns.Add("VERSION_NO", typeof(int));

        DataRow drDraft = null;
        int iRow        = ugrdAppList.Rows.Count;
        int iCol        = ugrdAppList.Columns.Count;
        TemplatedColumn cCol = (TemplatedColumn)ugrdAppList.Columns.FromKey("selchk");
        CheckBox chkSel = null;

        for (int i = 0; i < iRow; i++)
        {
            chkSel = (CheckBox)((CellItem)cCol.CellItems[ugrdAppList.Rows[i].BandIndex]).FindControl("cBox");
            if (chkSel.Checked)
            {
                drDraft = dtDraft.NewRow();
                drDraft["APP_REF_ID"] = int.Parse(ugrdAppList.Rows[i].Cells.FromKey("APP_REF_ID").Value.ToString());
                drDraft["VERSION_NO"] = int.Parse(ugrdAppList.Rows[i].Cells.FromKey("VERSION_NO").Value.ToString());
                dtDraft.Rows.Add(drDraft);
            }
        }

        if (dtDraft.Rows.Count > 0)
        {
            Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
            int iRtnRow = objPrc.RecallDraft(null, null, dtDraft, gUserInfo.Emp_Ref_ID);
            ltrScript.Text = JSHelper.GetAlertScript(objPrc.Transaction_Message, false);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 문서가 없습니다.", false);
        }
    }

    #endregion

    #region 서버 이벤트 처리 함수
    protected void ugrdAppList_InitializeRow(object sender, RowEventArgs e)
    {
        //string strAppId = e.Row.Cells.FromKey("APP_REF_ID").Value.ToString();
        //string strVerNo = e.Row.Cells.FromKey("VERSION_NO").Value.ToString();
        //string strAppCd = e.Row.Cells.FromKey("APP_CODE").Value.ToString();
        //string strURL = String.Format("<span onclick='OpenAppWin({0},{1})'>{2}</span>", strAppId, strVerNo, strAppCd);
        //e.Row.Cells.FromKey("APP_CODE").Text = strURL;

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        CheckBox chkSel = (CheckBox)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("cBox");

        string strAppStatusCd = e.Row.Cells.FromKey("APP_CODE").Value.ToString();
        if (strAppStatusCd == Biz_Type.app_status_draft)
        {
            chkSel.Enabled = false;
        }
        else
        {
            chkSel.Enabled = true;
        }
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetApprovalList();
    }
    protected void linkBtnDraft_Click(object sender, EventArgs e)
    {
        this.SetApprovalList();
    }

    protected void ugrdAppList_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.IApp_Ref_Id = decimal.Parse(e.Row.Cells.FromKey("APP_REF_ID").Value.ToString());
        this.IVersion_No = int.Parse(e.Row.Cells.FromKey("VERSION_NO").Value.ToString());
        this.SetAppDetailList();
    }

    protected void iBtnAppCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.SetRecallDraft();
        this.SetApprovalList();
        ugrdAppPrc.Clear();
    }
    #endregion
}
