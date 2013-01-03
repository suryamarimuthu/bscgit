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
using System.Text;

using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;

public partial class _common_lib_MenuControl_Dept : AppUserControlBase
{
    private Control[] _control = null;

    public bool IsCheckInOutVisible
    {
        get
        {
            return (ViewState["IS_CHECK_IN_OUT_VISIBLE"] == null) ? false : (bool)ViewState["IS_CHECK_IN_OUT_VISIBLE"];
        }
        set
        {
            ViewState["IS_CHECK_IN_OUT_VISIBLE"] = value;
        }
    }

    public void SetCheckInOutBuuton(params Control[] control) 
    {
        _control = control;
    }

    public string err="err";
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
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        int iTmp = 0;
        string sUrl = HttpContext.Current.Request.Url.AbsolutePath;

        // ERRORINFO.ASPX는 쿼리스트링이 고정되지 않은 페이지 이므로 예외처리한다. (해당페이지 권한시 FULL_PATH로 처리되므로 무한루프일수 있다.)
        if (
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "ERRORINFO.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1002.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1003.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR2001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1009.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1014.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST1100.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST3600.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST4000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST4100.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "APP2000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR10001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR3001.ASPX" 
           )
            sUrl = HttpContext.Current.Request.Url.PathAndQuery;

        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        DataSet dsAuthTop = biz.GetAuthTopMenu(gUserInfo.Emp_Ref_ID.ToString());
        DataSet dsAuthSub = biz.GetAuthSubMenu(gUserInfo.Emp_Ref_ID.ToString());
        DataSet dsAuthMenu = biz.GetAuthMenu(gUserInfo.Emp_Ref_ID.ToString());

        bool bAuthPage = biz.IsAuthPage(gUserInfo.Emp_Ref_ID.ToString(), sUrl);
        bool bNotUseMenu = biz.IsNotUseMenu(gUserInfo.Emp_Ref_ID.ToString(), sUrl);

        //// 권한이 없을때 처리...
        if (!bAuthPage && err != "err")
        {
            //Server.Transfer("/_common/ErrorPages/ErrorInfo.aspx?ERRMSG=권한이 없습니다!");
            HttpContext.Current.Response.Redirect("/_common/ErrorPages/ErrorInfo.aspx?ERRMSG=권한이 없습니다!");
            return;
        }

        // 메뉴구성페이지가 아닐때 처리...
        if (bNotUseMenu)
        {
            return;
        }

        int iTopMenuID = GetTopMenuRefID(sUrl);
        DataTable dtSubMenu = GetSubMenu(iTopMenuID.ToString());

        #region TopMenu 설정
        string sTopLiteral = "";
        iTmp = 0;

        sTopLiteral += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">    \n";
        sTopLiteral += "    <tr>    \n";

        foreach (DataRow drRow in dsAuthTop.Tables[0].Rows)
        {
            sTopLiteral += "<td><img src=\"../images/blank.gif\" width=\"6\"></td>          ";
            sTopLiteral += "<td style=\"cursor:hand\" onclick=\"location.href='{0}';mfLeftTopTitle('{5}')\"               ";
            sTopLiteral += "                                    onmouseout=\"MM_swapImgRestore()\"              ";
            sTopLiteral += "                                    onmouseover=\"MM_swapImage('img{1}', '', '{2}')\"   ";
            sTopLiteral += "            ><img src=\"{3}\" name=\"img{4}\" border=0></td>                        ";

            sTopLiteral = string.Format(
                                        sTopLiteral
                                       , GetValue(drRow["MENU_FULL_PATH"])
                                       , GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."))
                                       , (iTopMenuID == Convert.ToInt32(drRow["MENU_REF_ID"]) ? GetValue(drRow["MENU_NAME_IMAGE_PATH"]) : GetValue(drRow["MENU_NAME_IMAGE_PATH_U"]))
                                       , (iTopMenuID == Convert.ToInt32(drRow["MENU_REF_ID"]) ? GetValue(drRow["MENU_NAME_IMAGE_PATH_U"]) : GetValue(drRow["MENU_NAME_IMAGE_PATH"]))
                                       , GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."))
                                       , GetValue(drRow["MENU_PREV_ICON_PATH"])
                                       );

            iTmp++;
        }

        sTopLiteral += "    </tr>   \n";
        sTopLiteral += "</table>    \n";

        litTopMenu.Text = sTopLiteral;
        #endregion


        #region 부서점수트리 설정
        //TreeNode trnTop = new TreeNode("Top", "TOP");
        //trvDeptScore.Nodes.Add(trnTop);
        //trnTop.ChildNodes.Add(new TreeNode("Child", "CHILD"));

        WebCommon.FillEstTree(trvDeptScore, 1000);

        #endregion

    }

    private void InitControlValue()
    {
        string sUrl = HttpContext.Current.Request.Url.AbsolutePath;

        // ERRORINFO.ASPX는 쿼리스트링이 고정되지 않은 페이지 이므로 예외처리한다. (해당페이지 권한시 FULL_PATH로 처리되므로 무한루프일수 있다.)
        //if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "ERRORINFO.ASPX")
        //    sUrl = HttpContext.Current.Request.Url.PathAndQuery;


        lblEmpName.Text = gUserInfo.Emp_Name;

        #region KPI실적 마감월 셋팅
        string sFinishMon = "";

        //StrategyMapInfos stgMapInfo = new StrategyMapInfos();
        //sFinishMon = stgMapInfo.GetTMCODE().ToString();

        //lblFinishMonth.Text = sFinishMon;

        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        sFinishMon          = objTerm.GetReleasedMonth();

        lblFinishMonth.Text = sFinishMon.Substring(0, 4) + "/" + sFinishMon.Substring(4, 2);

        #endregion

        #region KPI실적 마감율 셋팅
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        lblFinishRate.Text = biz.GetFinishRate(1000,sFinishMon).ToString();
        #endregion
    }

    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {
        //결재이미지 visible여부
        RoleBases rb = new RoleBases();

        if (   Context.User.IsInRole(rb.ROLE_ADMIN)
            || Context.User.IsInRole(rb.ROLE_TEAM_MANAGER)
            || Context.User.IsInRole(rb.ROLE_CHAMPION)
            || Context.User.IsInRole(rb.ROLE_CEO)
            || Context.User.IsInRole(rb.ROLE_OFFICER))
        {

            ImageButton1.Src = "~/images/btn/top_bu_k01_b.gif";
            ImageButton1.Visible = true;
            if (isResult())
                ImageButton1.Src = "~/images/btn/top_bu_k01_b.gif";
            else
                ImageButton1.Src = "~/images/btn/top_bu_k01.gif";

        }
        else
        {
            ImageButton1.Visible = false;
        }
        if (   Context.User.IsInRole(rb.ROLE_ADMIN)
            || Context.User.IsInRole(rb.ROLE_CHAMPION)
            || Context.User.IsInRole(rb.ROLE_CEO)
            || Context.User.IsInRole(rb.ROLE_TEAM_MANAGER)
            || Context.User.IsInRole(rb.ROLE_OFFICER))
        {
            //WebCommon.SetCommunicationImageStatus(ImageButton2
            //                                        , "~/images/btn/top_bu_k02_b.gif"
            //                                        , "~/images/btn/top_bu_k02.gif"
            //                                        , gUserInfo.Emp_Ref_ID);


            //ImageButton2.Visible = true;
            //if (isResultPA())
            //    ImageButton2.Src = "~/images/btn/top_bu_k02_b.gif";
            //else
            //    ImageButton2.Src = "~/images/btn/top_bu_k02.gif";
        }
        else
        {
            ImageButton2.Visible = false;
        }
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {
        if (IsCheckInOutVisible)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is _common_lib_CheckInOutControl)
                {
                    _common_lib_CheckInOutControl checkOutIn = (_common_lib_CheckInOutControl)this.Controls[i];
                    checkOutIn.IsEnabled = true;

                    if (checkOutIn.IsEnabled)
                        checkOutIn.ButtonArr = _control;

                    break;
                }
            }
        }
    }
    #endregion

    #region 결제아이콘표시

    private bool isResult()
    {
        Approval_Infos approval = new Approval_Infos();

        RoleBases rb = new RoleBases();

        //admin 권한일경우 전부서의 결재를 여부를 가져옴
        if (Context.User.IsInRole(rb.ROLE_ADMIN))
        {
            return approval.IsApproved();
        }

        return approval.IsApproved(gUserInfo.Emp_Ref_ID);
    }
    
    #endregion


    #region 내부함수
    public void CallApprovalInfo()
    {
        //ApprovalListControl1.APP_SetAppProcInfo();
    }
    /// <summary>
    /// GetTopMenuRefID
    ///     : 현재페이지를 기초로 TOP_MENU_REF_ID를 리턴한다.
    ///     : 재귀호출로 처리
    /// </summary>
    /// <param name="asUrl"></param>
    /// <returns></returns>
    private int GetTopMenuRefID(string asUrl)
    {
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();

        int iTopMenuID = 0;
        DataSet dsAuthMenu = biz.GetAuthMenu(gUserInfo.Emp_Ref_ID.ToString());

        DataRow[] draRow;

        draRow = dsAuthMenu.Tables[0].Select(
                                            "MENU_FULL_PATH = '" + asUrl.ToUpper() + "' "
                                            );

        foreach (DataRow dbRow in draRow)
        {
            SearchTopMenuID(dsAuthMenu, dbRow, out iTopMenuID);
        }

        return iTopMenuID;
    }

    private void SearchTopMenuID(DataSet dsAuthMenu, DataRow dbRow, out int oiTopMenuID)
    {
        oiTopMenuID = 0;

        if (dbRow["MENU_TYPE"].ToString() != "T")
        {
            DataRow[] draRow;

            draRow = dsAuthMenu.Tables[0].Select(
                                                "MENU_REF_ID = " + dbRow["UP_MENU_ID"].ToString()
                                                );

            foreach (DataRow drRow in draRow)
            {
                SearchTopMenuID(dsAuthMenu, drRow, out oiTopMenuID);
            }
        }
        else
        {
            oiTopMenuID = Convert.ToInt32(dbRow["MENU_REF_ID"]);
        }
    }

    /// <summary>
    /// GetSubMenu
    ///     : TOP MENU ID를 기초로 해당 서브메뉴를 추출한다.
    /// </summary>
    /// <param name="asTopMenuID"></param>
    /// <returns></returns>
    private DataTable GetSubMenu(string asTopMenuID)
    {
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();

        DataTable dtRet = new DataTable();

        dtRet.Columns.Add("MENU_REF_ID", typeof(int));
        dtRet.Columns.Add("UP_MENU_ID", typeof(int));
        dtRet.Columns.Add("MENU_NAME", typeof(string));
        dtRet.Columns.Add("MENU_DIR", typeof(string));
        dtRet.Columns.Add("MENU_PAGE_NAME", typeof(string));
        dtRet.Columns.Add("MENU_PARAM", typeof(string));
        dtRet.Columns.Add("MENU_FULL_PATH", typeof(string));
        dtRet.Columns.Add("MENU_DESC", typeof(string));
        dtRet.Columns.Add("MENU_PRIORITY", typeof(int));
        dtRet.Columns.Add("MENU_TYPE", typeof(string));
        dtRet.Columns.Add("MENU_NAME_IMAGE_PATH", typeof(string));
        dtRet.Columns.Add("MENU_PREV_ICON_PATH", typeof(string));
        dtRet.Columns.Add("LEVEL", typeof(int));

        DataSet dsAuthMenu = biz.GetAuthMenu(gUserInfo.Emp_Ref_ID.ToString());

        SearchSubMenu(dsAuthMenu, asTopMenuID, 1, ref dtRet);

        return dtRet;
    }

    private void SearchSubMenu(DataSet dsAuthMenu, string asMenuID, int aiLevel, ref DataTable dtRet)
    {
        if (dsAuthMenu.Tables.Count > 0)
        {
            DataRow drNew;
            DataRow[] draAuthMenu;
            DataTable dtAuthMenu = dsAuthMenu.Tables[0];

            draAuthMenu = dtAuthMenu.Select(
                                            "UP_MENU_ID = " + asMenuID
                                           , "MENU_PRIORITY"
                                           );

            foreach (DataRow drRow in draAuthMenu)
            {
                drNew = dtRet.NewRow();

                drNew["MENU_REF_ID"] = Convert.ToInt32(drRow["MENU_REF_ID"]);

                if (!drRow.IsNull("UP_MENU_ID"))
                {
                    drNew["UP_MENU_ID"] = Convert.ToInt32(drRow["UP_MENU_ID"]);
                }

                drNew["MENU_NAME"] = drRow["MENU_NAME"].ToString();
                drNew["MENU_DIR"] = drRow["MENU_DIR"].ToString();
                drNew["MENU_PAGE_NAME"] = drRow["MENU_PAGE_NAME"].ToString();
                drNew["MENU_PARAM"] = drRow["MENU_PARAM"].ToString();
                drNew["MENU_FULL_PATH"] = drRow["MENU_FULL_PATH"].ToString();
                drNew["MENU_DESC"] = drRow["MENU_DESC"].ToString();
                drNew["MENU_PRIORITY"] = Convert.ToInt32(drRow["MENU_PRIORITY"]);
                drNew["MENU_TYPE"] = drRow["MENU_TYPE"].ToString();

                drNew["MENU_NAME_IMAGE_PATH"] = drRow["MENU_NAME_IMAGE_PATH"].ToString();
                drNew["MENU_PREV_ICON_PATH"] = drRow["MENU_PREV_ICON_PATH"].ToString();
                drNew["LEVEL"] = aiLevel;

                dtRet.Rows.Add(drNew);

                if (drRow["MENU_TYPE"].ToString() == "M")
                {
                    SearchSubMenu(dsAuthMenu, drRow["MENU_REF_ID"].ToString(), (aiLevel + 1), ref dtRet);
                }
            }
        }
    }
    #endregion

    
}
