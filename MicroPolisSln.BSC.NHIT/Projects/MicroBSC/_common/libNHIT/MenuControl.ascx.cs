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
using MicroBSC.Estimation.Biz;

using Infragistics.WebUI.UltraWebNavigator;

public partial class _common_libNHIT_MenuControl : AppUserControlBase
{
    private Control[] _control = null;

    private int _menuRefID;
    private int _noticeBoardID;
    private string _startDate;
    private string _endDate;

    public string _todayDate = DataTypeUtility.GetToDateTimeText(DateTime.Now);

    public string NOTICE_START_DATE
    {
        get { return _startDate; }
        set { _startDate = value; }
    }

    public string NOTICE_END_DATE
    {
        get { return _endDate; }
        set { _endDate = value; }
    }

    public int NOTICE_BOARD_ID
    {
        get
        {
            return _noticeBoardID;
        }
        set
        {
            _noticeBoardID = value;
        }
    }

    public int CURRENT_PAGE_MENU_ID
    {
        get
        {
            return _menuRefID;
        }
        set
        {
            _menuRefID = value;
        }
    }

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

    public int ILogInUserId
    {
        get
        {
            if (ViewState["EMP_REF_ID"] == null)
            {
                SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;
                ViewState["EMP_REF_ID"] = gUserInfo.Emp_Ref_ID.ToString();
            }

            return Convert.ToInt32(ViewState["EMP_REF_ID"].ToString());
        }
        set
        {
            ViewState["EMP_REF_ID"] = value;
        }
    }

    public string IisHaveNoticeYN
    {
        get
        {
            if (ViewState["HAVE_NOTICE_YN"] == null)
            {
                ViewState["HAVE_NOTICE_YN"] = "N";
            }

            return Convert.ToString(ViewState["HAVE_NOTICE_YN"].ToString());
        }
        set
        {
            ViewState["HAVE_NOTICE_YN"] = value;
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

        this.SetNoticeBoard();
        SetAllTimeBottom();
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        string sUrl = HttpContext.Current.Request.Url.AbsolutePath;

        // ERRORINFO.ASPX는 쿼리스트링이 고정되지 않은 페이지 이므로 예외처리한다. (해당페이지 권한시 FULL_PATH로 처리되므로 무한루프일수 있다.)
        if (
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "ERRORINFO.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1002.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1003.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1005.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR2001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR3001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR2001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR_DEPT_ORG.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR_DEPT_ORG_EMBED.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1009.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1014.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR10001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST1100.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST3600.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST4000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST4100.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "APP2000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0406S1.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0304S2.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0403S4.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0404S1.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110104.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110104_01.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110204.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110204_01.ASPX"
           )
        {
            sUrl = HttpContext.Current.Request.Url.PathAndQuery;
        }

        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        DataSet dsAuthTop       = biz.GetAuthTopMenu(gUserInfo.Emp_Ref_ID.ToString());
        DataSet dsAuthSub       = biz.GetAuthSubMenu(gUserInfo.Emp_Ref_ID.ToString());
        DataSet dsAuthMenu      = biz.GetAuthMenu(gUserInfo.Emp_Ref_ID.ToString());

        bool bAuthPage          = biz.IsAuthPage(gUserInfo.Emp_Ref_ID.ToString(), sUrl);
        bool bNotUseMenu        = biz.IsNotUseMenu(gUserInfo.Emp_Ref_ID.ToString(), sUrl);

        //// 권한이 없을때 처리...
        if (!bAuthPage && err != "err")
        {
            //Server.Transfer("/_common/ErrorPages/ErrorInfo.aspx?ERRMSG=권한이 없습니다!");
            HttpContext.Current.Response.Redirect("/_common/ErrorPages/ErrorInfo.aspx?ERRMSG=권한이 없습니다!");
            return;
        }

        // 메뉴구성페이지가 아닐때 처리...
        //if (bNotUseMenu)
        //{
        //    return;
        //}

        int iTopMenuID      = GetTopMenuRefID( sUrl );
/*
        DataTable dtSubMenu = GetSubMenu(iTopMenuID.ToString());
*/
        #region TopMenu 설정
        string sTopLiteral = "";
        int iTmp = 0;

        sTopLiteral += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">    \n";
        sTopLiteral += "    <tr>    \n";

        foreach (DataRow drRow in dsAuthTop.Tables[0].Rows)
        {
            if (GetValue(drRow["MENU_NAME_IMAGE_PATH"]).ToUpper().IndexOf("MENU_04") > -1)
            {
                //경영실적의 경우 탑메뉴에서 분리
                this.lnkChartPage.Visible = true;
                this.lnkChartPage.Attributes.Add("onclick", string.Format("location.href='{0}'", GetValue(drRow["MENU_FULL_PATH"])));
            }
            else
            {
                if (iTmp > 0)
                    sTopLiteral += "<td><img src=\"../images/NHIT/Menu_col.gif\" width=\"2\"></td>          ";//대메뉴 사이 공백

                sTopLiteral += "<td style=\"vertical-align:bottom;\"";
                //sTopLiteral += "<td style=\"cursor:hand\"               ";
                //sTopLiteral += "                                    onmouseout=\"MM_swapImgRestore()\"              ";
                //sTopLiteral += "                                    onmouseover=\"MM_swapImage('img{1}', '', '{2}')\"   ";//;mfLeftTopTitle('{5}')
                sTopLiteral += "            ><a href='#null' onfocus='this.blur();' onclick=\"location.href='{0}'\"><img src=\"{3}\" name=\"img{4}\" border='0'></a></td>                        ";

                sTopLiteral = string.Format(
                                            sTopLiteral
                                           , GetValue(drRow["MENU_FULL_PATH"])
                                           , GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."))
                                           , (iTopMenuID == Convert.ToInt32(drRow["MENU_REF_ID"]) ? GetValue(drRow["MENU_NAME_IMAGE_PATH"]) : GetValue(drRow["MENU_NAME_IMAGE_PATH_U"]))
                                           , (iTopMenuID == Convert.ToInt32(drRow["MENU_REF_ID"]) ? GetValue(drRow["MENU_NAME_IMAGE_PATH_U"]) : GetValue(drRow["MENU_NAME_IMAGE_PATH"]))
                                           , GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."))
                                           , GetValue(drRow["MENU_PREV_ICON_PATH"])
                                           );

                if (iTopMenuID == Convert.ToInt32(drRow["MENU_REF_ID"]))
                {
                    leftTopTitle.ImageUrl = GetValue(drRow["MENU_PREV_ICON_PATH"]);
                }

                iTmp++;
            }
        }

        sTopLiteral += "    </tr>   \n";
        sTopLiteral += "</table>    \n";

        ltrTopMenu.Text = sTopLiteral;
        #endregion

        #region SubMenuStyle 설정 - 08.03.20 류승태 -- 주석처리 메뉴추가관련
/*
        string sSubLiteral = "";
        int iPrevLevel = 1; // 이전레벨
        int iTmpLevel = 0;

        string sMenuID = "";    // 토글메뉴시 사용

        foreach (DataRow drRow in dtSubMenu.Rows)
        {
            iTmpLevel = Convert.ToInt32(drRow["LEVEL"]);

            if (iPrevLevel != iTmpLevel)
            {
                if (iPrevLevel < iTmpLevel)
                {
                    // 세부항목 여는 행위
                    if (iTmpLevel >= 3)
                        //sSubLiteral += "        <tr><td height=\"19\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'\" class=\"stext\">▶ " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                        sSubLiteral += "        <tr><td height=\"19\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" class=\"stext\">▶ " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                    else if (iTmpLevel >= 2)
                    {
                        sSubLiteral += "<span id=\"" + sMenuID + "\">                                                               \n";
                        sSubLiteral += "    <table width=\"137\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">      \n";
                        sSubLiteral += "        <tr><td width=\"128\" height=3></td></tr>                               \n";

                        //sSubLiteral += "        <tr><td height=\"19\"><a href=\"javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'\" class=\"stext\">>> " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                        sSubLiteral += "        <tr><td height=\"19\"><a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" class=\"stext\">>> " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                    }
                    else
                    {
                        if (GetValue(drRow["MENU_TYPE"]) == "M")
                        {
                            // 메뉴그룹이라면 토글시 사용할 ID를 정한다.
                            //sMenuID = "spn" + GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."));
                            sMenuID = "spn" + GetValue(drRow["MENU_REF_ID"]);

                            sSubLiteral += "<script type=\"text/javascript\">saMenu[saMenu.length] = '" + sMenuID + "';</script>";
                        }

                        sSubLiteral += "<table width=\"169\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" runat=\"server\">   \n";
                        sSubLiteral += "    <tr><td height=\"1\" bgcolor=\"#FFFFFF\"></td></tr>                                                 \n";
                        sSubLiteral += "    <tr>                                                                                                \n";
                        sSubLiteral += "        <td height=\"21\" bgcolor=\"EEEEEE\" class=\"left_menu3\"><img                                  \n";
                        sSubLiteral += "            src=\"../images/icon/left_icon01.gif\" height=\"10\" align=\"absmiddle\"                    \n";
                        sSubLiteral += "            style=\"cursor:hand\"                                                                       \n";
                        sSubLiteral += "            ><a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" ";

                        if (GetValue(drRow["MENU_TYPE"]) == "M")
                        {
                            // 메뉴그룹이라면 토클함수를 콜한다.
                            sSubLiteral += "onclick=\"return mfToggleMenu('" + sMenuID + "')\" ";
                        }

                        sSubLiteral += "> " + GetValue(drRow["MENU_NAME"]) + "</a> \n";
                        sSubLiteral += "        </td>                                                                                           \n";
                        sSubLiteral += "    </tr>                                                                                               \n";
                        sSubLiteral += "    <tr bgcolor=\"F0F0F0\"><td height=\"1\" bgcolor=\"D6D6D6\"></td></tr>                               \n";
                        sSubLiteral += "</table>                                                                                                \n";
                    }
                }
                else
                {
                    // 레벨이 달라지는 경우이므로 레벨이 2인경우는 닫고 다시연다.
                    if (iTmpLevel >= 3)
                        ;
                    else if (iTmpLevel >= 2)
                    {
                        sSubLiteral += "        <tr><td height=5></td></tr>                                             \n";
                        sSubLiteral += "    </table>                                                                    \n";
                        sSubLiteral += "</span>                                                                         \n";

                        //////sMenuID = "spn" + GetValue(drRow["MENU_REF_ID"]);

                        sSubLiteral += "<span id=\"" + sMenuID + "\">                                                               \n";
                        sSubLiteral += "    <table width=\"137\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">      \n";
                        sSubLiteral += "        <tr><td width=\"128\" height=3></td></tr>                               \n";

                    }

                    // 세부항목 닫는 행위
                    if (iTmpLevel >= 3)
                        //sSubLiteral += "        <tr><td height=\"19\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'\" class=\"stext\">▶ " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                        sSubLiteral += "        <tr><td height=\"19\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" class=\"stext\">▶ " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                    else if (iTmpLevel >= 2)
                    {
                        //sSubLiteral += "        <tr><td height=\"19\"><a href=\"javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'\" class=\"stext\">>> " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                        sSubLiteral += "        <tr><td height=\"19\"><a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" class=\"stext\">>> " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                    }
                    else
                    {
                        sSubLiteral += "        <tr><td height=5></td></tr>                                             \n";
                        sSubLiteral += "    </table>                                                                    \n";
                        sSubLiteral += "</span>                                                                         \n";

                        if (GetValue(drRow["MENU_TYPE"]) == "M")
                        {
                            // 메뉴그룹이라면 토글시 사용할 ID를 정한다.
                            //sMenuID = "spn" + GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."));
                            sMenuID = "spn" + GetValue(drRow["MENU_REF_ID"]);

                            sSubLiteral += "<script type=\"text/javascript\">saMenu[saMenu.length] = '" + sMenuID + "';</script>";
                        }

                        sSubLiteral += "<table width=\"169\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" runat=\"server\">   \n";
                        sSubLiteral += "    <tr><td height=\"1\" bgcolor=\"#FFFFFF\"></td></tr>                                                 \n";
                        sSubLiteral += "    <tr>                                                                                                \n";
                        sSubLiteral += "        <td height=\"21\" bgcolor=\"EEEEEE\" class=\"left_menu3\"><img                                  \n";
                        sSubLiteral += "            src=\"../images/icon/left_icon01.gif\" height=\"10\" align=\"absmiddle\"                    \n";
                        sSubLiteral += "            style=\"cursor:hand\"                                                                       \n";
                        sSubLiteral += "            ><a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" ";

                        if (GetValue(drRow["MENU_TYPE"]) == "M")
                        {
                            // 메뉴그룹이라면 토클함수를 콜한다.
                            sSubLiteral += "onclick=\"return mfToggleMenu('" + sMenuID + "')\" ";
                        }

                        sSubLiteral += "> " + GetValue(drRow["MENU_NAME"]) + "</a> \n";

                        sSubLiteral += "        </td>                                                                                           \n";
                        sSubLiteral += "    </tr>                                                                                               \n";
                        sSubLiteral += "    <tr bgcolor=\"F0F0F0\"><td height=\"1\" bgcolor=\"D6D6D6\"></td></tr>                               \n";
                        sSubLiteral += "</table>                                                                                                \n";
                    }
                }

                iPrevLevel = iTmpLevel;
            }
            else
            {
                if (iTmpLevel >= 3)
                    //sSubLiteral += "        <tr><td height=\"19\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'\" class=\"stext\">▶ " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                    sSubLiteral += "        <tr><td height=\"19\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" class=\"stext\">▶ " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                else if (iTmpLevel >= 2)
                    //sSubLiteral += "        <tr><td height=\"19\"><a href=\"javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'\" class=\"stext\">>> " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                    sSubLiteral += "        <tr><td height=\"19\"><a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" class=\"stext\">>> " + GetValue(drRow["MENU_NAME"]) + "</a></td></tr>    \n";
                else
                {
                    if (GetValue(drRow["MENU_TYPE"]) == "M")
                    {
                        // 메뉴그룹이라면 토글시 사용할 ID를 정한다.
                        //sMenuID = "spn" + GetValue(drRow["MENU_PAGE_NAME"]).Substring(0, GetValue(drRow["MENU_PAGE_NAME"]).LastIndexOf("."));
                        sMenuID = "spn" + GetValue(drRow["MENU_REF_ID"]);

                        sSubLiteral += "<script type=\"text/javascript\">saMenu[saMenu.length] = '" + sMenuID + "';</script>";
                    }

                    sSubLiteral += "<table width=\"169\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" runat=\"server\">   \n";
                    sSubLiteral += "    <tr><td height=\"1\" bgcolor=\"#FFFFFF\"></td></tr>                                                 \n";
                    sSubLiteral += "    <tr>                                                                                                \n";
                    sSubLiteral += "        <td height=\"21\" bgcolor=\"EEEEEE\" class=\"left_menu3\"><img                                  \n";
                    sSubLiteral += "            src=\"../images/icon/left_icon01.gif\" height=\"10\" align=\"absmiddle\"                    \n";
                    sSubLiteral += "            style=\"cursor:hand\"                                                                       \n";
                    sSubLiteral += "            ><a href=\"" + (GetValue(drRow["MENU_FULL_PATH"]) == "" ? "#" : "javascript:location.href='" + GetValue(drRow["MENU_FULL_PATH"]) + "'") + "\" ";

                    if (GetValue(drRow["MENU_TYPE"]) == "M")
                    {
                        // 메뉴그룹이라면 토클함수를 콜한다.
                        sSubLiteral += "onclick=\"return mfToggleMenu('" + sMenuID + "')\" ";
                    }

                    sSubLiteral += "> " + GetValue(drRow["MENU_NAME"]) + "</a> \n";

                    sSubLiteral += "        </td>                                                                                           \n";
                    sSubLiteral += "    </tr>                                                                                               \n";
                    sSubLiteral += "    <tr bgcolor=\"F0F0F0\"><td height=\"1\" bgcolor=\"D6D6D6\"></td></tr>                               \n";
                    sSubLiteral += "</table>                                                                                                \n";

                }
            }

            //if (GetValue(drRow["MENU_DIR"]) + GetValue(drRow["MENU_PAGE_NAME"]) == sUrl.ToUpper())
            if (GetValue(drRow["MENU_FULL_PATH"]) == sUrl.ToUpper())
            {
                // 현재페이지가 속해있는 메뉴그룹 셋팅 (계속 펼쳐져 있도록 한다.)
                sSubLiteral += "<script type=\"text/javascript\">sMenu = '" + sMenuID + "';</script>";
            }
        }

        // iPrevLevel이 2보다 크거나 같으면 닫아준다.
        if (iPrevLevel >= 2)
        {
            sSubLiteral += "        <tr><td height=5></td></tr>                                             \n";
            sSubLiteral += "    </table>                                                                    \n";
            sSubLiteral += "</span>                                                                         \n";
        }

        // 최초 시작시 메뉴를 전부 닫고 현재페이지가 속한 메뉴만 오픈한다.
        sSubLiteral += "<script type=\"text/javascript\">mfStartMenu();</script>";

        litSubMenu.Text = sSubLiteral;
*/
        #endregion
	}

    private void InitControlValue()
    {
        string pathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        string sUrl         = HttpContext.Current.Request.Url.AbsolutePath;
        
        // ERRORINFO.ASPX는 쿼리스트링이 고정되지 않은 페이지 이므로 예외처리한다. (해당페이지 권한시 FULL_PATH로 처리되므로 무한루프일수 있다.)
        //if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "ERRORINFO.ASPX")
        //    sUrl = HttpContext.Current.Request.Url.PathAndQuery;

        if (HttpContext.Current.Request.Url.Query != "")
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.ToUpper() == "/EST/EST110204.ASPX")
            {
                pathAndQuery = HttpContext.Current.Request.Url.AbsolutePath;
            }
        }

        lblEmpName.Text = gUserInfo.Emp_Name;
        tblTopMenu.Style.Add(HtmlTextWriterStyle.BackgroundImage, ConfigurationManager.AppSettings["TopMenuLogo.ImageUrl"].ToString());


        MicroBSC.Estimation.Dac.TermInfos objTermYY = new MicroBSC.Estimation.Dac.TermInfos();
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();

        int intEstTerm = objTermYY.GetOpenEstTermID();
        string sFinishMon = objTerm.GetReleasedMonth();
        

        #region KPI실적 마감월 셋팅
        lblFinishMonth.Text = sFinishMon.Substring(0, 4) + "/" + sFinishMon.Substring(4, 2);
        #endregion

        #region KPI실적 마감율 셋팅
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        lblFinishRate.Text = biz.GetFinishRate(intEstTerm, sFinishMon).ToString();
        #endregion

        #region 커뮤니케이션 리스트가 있는지?
        MicroBSC.BSC.Biz.Biz_Bsc_Communication_User objUser = new MicroBSC.BSC.Biz.Biz_Bsc_Communication_User();
        iBtnCommunication.Src = (objUser.GetIsNewListPerUser(this.ILogInUserId)) ? "~/images/NHIT/btn_top_02.gif" : "~/images/NHIT/btn_top_02.gif";//있음:없음

        // 결재할 문서가 있는지?
        //Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        //iBtnConfirm.Src = (objBSC.GetIsNewDraftPerUser(intEstTerm, sFinishMon, this.ILogInUserId)) ? "~/images/btn/top_bu_k01_b.gif" : "~/images/btn/top_bu_k01.gif";
        Biz_Com_Approval_Prc objBSC = new Biz_Com_Approval_Prc();
        DataSet rDs = objBSC.GetToDraftList(this.ILogInUserId, "");
        if (rDs.Tables.Count > 0)
        {
            iBtnConfirm.Src = (rDs.Tables[0].Rows.Count > 0) ? "~/images/NHIT/btn_top_01.gif" : "~/images/NHIT/btn_top_01.gif";//있음:없음
        }
        else
        {
            iBtnConfirm.Src = "~/images/NHIT/btn_top_01.gif";
        }


        // 공지사항이 있는지 또는 읽었는지
        MicroBSC.BSC.Biz.Biz_Bsc_Communication_Notice objNot = new MicroBSC.BSC.Biz.Biz_Bsc_Communication_Notice();
        this.IisHaveNoticeYN = (objNot.GetCurrentNotice() ? "Y" : "N");

        string strCookieKey = "NOTICE_" + objNot.Inotice_ref_id.ToString();
        if (Request.Cookies[strCookieKey] != null)
        {
            DateTime dtCookieDate = Convert.ToDateTime(Server.HtmlEncode(Request.Cookies[strCookieKey].Expires.ToShortTimeString()));
            if (dtCookieDate < DateTime.Now)
            {
                this.IisHaveNoticeYN = "N";
            }
        }

        #endregion

        #region 타이틀 셋팅
        if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110104.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110104_01.ASPX")
            lblTitle.Text = biz.GetMenuTitle(pathAndQuery);
        else
            lblTitle.Text = biz.GetMenuTitle(sUrl);

        if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() == "PMS0300S1.ASPX")
            lblTitle.Text = biz.GetMenuTitle("/PMS/PMS0300S1.ASPX?EST_TGT_TYPE=EST");

        if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() == "EST110204_01.ASPX")
            lblTitle.Text = biz.GetMenuTitle("/EST/EST110204_01.ASPX");

        if (lblTitle.Text.Trim().Equals(""))
            imgTitle.Visible = false;
        #endregion
    }

    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {

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
                if (this.Controls[i] is _common_libNHIT_CheckInOutControl)
                {
                    _common_libNHIT_CheckInOutControl checkOutIn = (_common_libNHIT_CheckInOutControl)this.Controls[i];
                    checkOutIn.IsEnabled = true;

                    if (checkOutIn.IsEnabled)
                        checkOutIn.ButtonArr = _control;

                    break;
                }
            }
        }
    }

    private void SetNoticeBoard()
    {
        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

        string strMenuFullPath = HttpContext.Current.Request.Url.AbsolutePath + HttpContext.Current.Request.Url.Query;
        CURRENT_PAGE_MENU_ID = objMenuInfo.GetMenuIDByMenuFullPath(strMenuFullPath);
        if (CURRENT_PAGE_MENU_ID != 0)
            CheckNoticePopupMenu(CURRENT_PAGE_MENU_ID);
        else
        {
            string sUrl = HttpContext.Current.Request.Url.AbsolutePath;
            if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() == "EST110104.ASPX" ||
                sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() == "EST110104_01.ASPX")
            {
                CURRENT_PAGE_MENU_ID = objMenuInfo.GetMenuIDByMenuFullPath(sUrl);
                if (CURRENT_PAGE_MENU_ID != 0)
                    CheckNoticePopupMenu(CURRENT_PAGE_MENU_ID);
            }
        }
    }

    private void CheckNoticePopupMenu(int menu_ref_id)
    {
        Biz_Boards objBoard = new Biz_Boards();
        DataSet ds = objBoard.GetBoard("", "NTC", menu_ref_id, "Y");
        if (ds.Tables[0].Rows.Count > 0)
        {
            NOTICE_BOARD_ID     = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["BOARD_ID"]);
            NOTICE_START_DATE   = DataTypeUtility.GetToDateTimeText(ds.Tables[0].Rows[0]["START_DATE"]);
            NOTICE_END_DATE     = DataTypeUtility.GetToDateTimeText(ds.Tables[0].Rows[0]["END_DATE"]);
        }

    }

    #endregion

    #region 결제아이콘표시

    private bool isResult()
    {
        //int dept_id = Approval_Infos.GetDeptID(gUserInfo.Emp_Ref_ID);

        Approval_Infos approval = new Approval_Infos();

        RoleBases rb    = new RoleBases();

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
        DataSet dsAuthMenu = biz.GetAuthMenuInclude_N(gUserInfo.Emp_Ref_ID.ToString());

        DataRow[] draRow;

        draRow = dsAuthMenu.Tables[0].Select(
                                                "(MENU_FULL_PATH = '" + asUrl.ToUpper() + "') OR ( MENU_DIR + MENU_PAGE_NAME = '"+ asUrl.ToUpper() + "' AND MENU_TYPE = 'N')"
                                            );


        //쿼리스트링을 포함한 경로가 메뉴에 없을경우 페이지명으로만 다시 검색
        if (draRow.Length == 0 && Request.Url.Query.Length > 0)
            draRow = dsAuthMenu.Tables[0].Select(
                                                    "( MENU_DIR + MENU_PAGE_NAME = '" + Request.Url.AbsolutePath.Replace(Request.Url.Query, "") + "' )"
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

/*
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

                drNew["MENU_REF_ID"]    = Convert.ToInt32(drRow["MENU_REF_ID"]);

                if (!drRow.IsNull("UP_MENU_ID"))
                {
                    drNew["UP_MENU_ID"] = Convert.ToInt32(drRow["UP_MENU_ID"]);
                }

                drNew["MENU_NAME"]              = drRow["MENU_NAME"].ToString();
                drNew["MENU_DIR"]               = drRow["MENU_DIR"].ToString();
                drNew["MENU_PAGE_NAME"]         = drRow["MENU_PAGE_NAME"].ToString();
                drNew["MENU_PARAM"]             = drRow["MENU_PARAM"].ToString();
                drNew["MENU_FULL_PATH"]         = drRow["MENU_FULL_PATH"].ToString();
                drNew["MENU_DESC"]              = drRow["MENU_DESC"].ToString();
                drNew["MENU_PRIORITY"]          = Convert.ToInt32(drRow["MENU_PRIORITY"]);
                drNew["MENU_TYPE"]              = drRow["MENU_TYPE"].ToString();

                drNew["MENU_NAME_IMAGE_PATH"]   = drRow["MENU_NAME_IMAGE_PATH"].ToString();
                drNew["MENU_PREV_ICON_PATH"]    = drRow["MENU_PREV_ICON_PATH"].ToString();
                drNew["LEVEL"]                  = aiLevel;

                dtRet.Rows.Add(drNew);

                if (drRow["MENU_TYPE"].ToString() == "M")
                {
                    SearchSubMenu(dsAuthMenu, drRow["MENU_REF_ID"].ToString(), (aiLevel + 1), ref dtRet);
                }
            }
        }
    }
*/
    #endregion
}
