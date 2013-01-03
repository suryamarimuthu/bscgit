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
using MicroBSC.BSC.Biz;

public partial class BSC_BSC0703S1 : AppPageBase
{
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

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 웹 취약성 검사 때문에 처리
        if (ICCB1.Equals("-0") ||
            IYMD.Equals("-0"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("악성 요청을 거부합니다.", false);
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        if (!IsPostBack)
        {
            this.SetFormInit();
            this.SetParameter();
            this.SetCommunicationGrid();
        }
        else
        { 
        
        }


        this.ugrdKpiStatusTab.Tabs.FromKey("1").Text = string.Format("나의 {0}/{1}", this.GetText("LBL_00007", "Comment"), this.GetText("LBL_00008", "Feedback"));
        this.ugrdKpiStatusTab.Tabs.FromKey("2").Text = string.Format("관련조직의 {0}/{1}", this.GetText("LBL_00007", "Comment"), this.GetText("LBL_00008", "Feedback"));
    }

    private void SetFormInit()
    { 
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, int.Parse(PageUtility.GetByValueDropDownList(ddlEstTermInfo)));

        if (User.IsInRole(ROLE_ADMIN))
        {
            iBtnWriteNotice.Visible = true;
        }
        else
        {
            iBtnWriteNotice.Visible = false;
        }

        ugrdKpiStatusTab.SelectedTabIndex = 0;
    }

    private void SetParameter()
    { 
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYMD          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.IKpiRefID     = 0;        
    }

    /// <summary>
    /// 내게남겨진/내가 남긴 글조회
    /// </summary>
    private void SetCommunicationGrid()
    {
        Biz_Bsc_Communication_List objBSC = new Biz_Bsc_Communication_List();
        this.ugrdCommunication.Clear();
        this.ugrdCommunication.DataSource = objBSC.GetAllListPerKpiUser(gUserInfo.Emp_Ref_ID, this.IEstTermRefID, this.IYMD, this.IKpiRefID, false);
        this.ugrdCommunication.DataBind();
    }

    /// <summary>
    /// 관련조직 글조회
    /// </summary>
    private void SetCommunicationOrgGrid()
    {
        Biz_Bsc_Communication_List objBSC = new Biz_Bsc_Communication_List();
        this.ugrdCommunicationOrg.Clear();
        this.ugrdCommunicationOrg.DataSource = objBSC.GetAllListPerKpiUser(gUserInfo.Emp_Ref_ID, this.IEstTermRefID, this.IYMD, this.IKpiRefID, true);
        this.ugrdCommunicationOrg.DataBind();
    }

    /// <summary>
    /// 공지사항 조회
    /// </summary>
    private void SetNoticeGrid()
    {
        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice();
        this.ugrdNotice.Clear();
        this.ugrdNotice.DataSource = objBSC.GetAllList();
        this.ugrdNotice.DataBind();
    }

    private void SetAllData()
    { 
        this.SetParameter();
        switch (ugrdKpiStatusTab.SelectedTab)
        { 
            case 0:
                this.SetCommunicationGrid();
                break;
            case 1:
                this.SetCommunicationOrgGrid();
                break;
            case 2:
                this.SetNoticeGrid();
                break;
            default:
                break;
        }
    }

    protected void ugrdCommunication_InitializeRow(object sender, RowEventArgs e)
    { 
        int intSpace     = (e.Row.Cells.FromKey("TREE_LEVEL").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("TREE_LEVEL").Value.ToString()) : 0;
        string strReIcon = "<img alt='' src='../images/icon/board_re.gif' style=\"vertical-align:middle;\" />";
        string strTitle  = (e.Row.Cells.FromKey("TITLE").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("TITLE").Value) : "";
        string strReadYN = (e.Row.Cells.FromKey("READ_YN").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("READ_YN").Value) : "X";
        string strEmpty  = "";
        string strKpiID  = (e.Row.Cells.FromKey("KPI_REF_ID").Value != null) ? Convert.ToString(e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString()) : "0";

        //e.Row.Cells.FromKey("KPI_NAME").TargetURL = "../BSC/BSC0304S2.aspx?iType=S&ESTTERM_REF_ID="+this.IEstTermRefID.ToString()+"&KPI_REF_ID="+strKpiID+"&YMD="+this.IYMD;
        string strURL = "javascript:gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}',840,600,'no','no');";
        e.Row.Cells.FromKey("KPI_NAME").TargetURL = string.Format(strURL, this.IEstTermRefID, strKpiID, this.IYMD);
        if (intSpace > 1)
        {
            e.Row.Cells.FromKey("TITLE").Text = strEmpty.PadRight((intSpace-1)*2, ' ') + strReIcon + strTitle;
        }

        string strOkIcon = "<img alt='미확인' src='../images/icon/gr_po01_b.gif' style=\"vertical-align:middle;\" />";
        if (strReadYN == "N")
        {
            e.Row.Cells.FromKey("NUM_TEXT").Text = strOkIcon;
        }
    }

    protected void ugrdNotice_InitializeRow(object sender, RowEventArgs e)
    { 

    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetAllData();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetAllData();
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        this.SetParameter();
        switch (e.Tab.Key)
        { 
            case "1":
                this.SetCommunicationGrid();
                break;
            case "2":
                this.SetCommunicationOrgGrid();
                break;
            case "3":
                this.SetNoticeGrid();
                break;
            default:
                break;
        }
    }
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, int.Parse(PageUtility.GetByValueDropDownList(ddlEstTermInfo)));
        this.SetAllData();
    }
}
