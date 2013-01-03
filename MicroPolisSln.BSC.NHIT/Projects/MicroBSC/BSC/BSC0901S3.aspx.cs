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

public partial class BSC_BSC0901S3 : AppPageBase
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
        objCode.GetApprovalStatus(ddlApprovalStatus, "", true, 100);

        for (int i = 0; i < ddlApprovalStatus.Items.Count; i++)
        {
            if ((ddlApprovalStatus.Items[i].Value == "")    ||
                (ddlApprovalStatus.Items[i].Value == "CFT") ||
                (ddlApprovalStatus.Items[i].Value == "RFT"))
            {
                continue;
            }
            else
            {
                ddlApprovalStatus.Items.Remove(ddlApprovalStatus.Items[i]);
                i = i - 1;
            }
        }

        wdcSDate.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-01 00:00:00");
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

        DateTime dtSDate = (DateTime)wdcSDate.Value;
        DateTime dtEDate = (DateTime)wdcEDate.Value;

        string sSDate = dtSDate.Year.ToString() + "-" + dtSDate.Month.ToString().PadLeft(2, '0') + "-" + dtSDate.Day.ToString().PadLeft(2, '0') + " 00:00:00";
        string sEDate = dtEDate.Year.ToString() + "-" + dtEDate.Month.ToString().PadLeft(2, '0') + "-" + dtEDate.Day.ToString().PadLeft(2, '0') + " 23:59:59";

        DataSet rDs = objApp.GetCompletedList
                     ( gUserInfo.Emp_Ref_ID
                     , PageUtility.GetByValueDropDownList(ddlApprovalStatus)
                     , PageUtility.GetByValueDropDownList(ddlBizType)
                     , txtTitle.Text
                     , Convert.ToDateTime(sSDate)
                     , Convert.ToDateTime(sEDate));

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

    #endregion

    #region 서버 이벤트 처리 함수
    protected void ugrdAppList_InitializeRow(object sender, RowEventArgs e)
    {
        //string strAppId = e.Row.Cells.FromKey("APP_REF_ID").Value.ToString();
        //string strVerNo = e.Row.Cells.FromKey("VERSION_NO").Value.ToString();
        //string strAppCd = e.Row.Cells.FromKey("APP_CODE").Value.ToString();
        //string strURL = String.Format("<span onclick='OpenAppWin({0},{1})'>{2}</span>", strAppId, strVerNo, strAppCd);
        //e.Row.Cells.FromKey("APP_CODE").Text = strURL;
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

    #endregion
}
