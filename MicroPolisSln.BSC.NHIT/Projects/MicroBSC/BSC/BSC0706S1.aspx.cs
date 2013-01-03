using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.BSC.Biz;
using MicroBSC.Integration.BSC.Biz;


public partial class BSC_BSC0706S1 : AppPageBase
{
    #region Property
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
    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 웹 취약성 검사 때문에 처리
        if (ICCB1.Equals("-0"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("악성 요청을 거부합니다.", false);
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        if (!Page.IsPostBack)
        {
            if (User.IsInRole(ROLE_ADMIN))
            {
                iBtnWriteNotice.Visible = true;
            }
            else
            {
                iBtnWriteNotice.Visible = false;
            }

            SetNoticeGrid();
        }
    }

    /// <summary>
    /// 공지사항 조회
    /// </summary>
    private void SetNoticeGrid()
    {
        Biz_Bsc_Kpi_Notice objBSC = new Biz_Bsc_Kpi_Notice();
        this.ugrdNotice.Clear();
        this.ugrdNotice.DataSource = objBSC.SelectNoticeAll(txtSearchText.Text);
        this.ugrdNotice.DataBind();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetNoticeGrid();
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        SetNoticeGrid();
    }
    protected void ugrdNotice_InitializeRow(object sender, RowEventArgs e)
    {

    }
}
