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

using System.Diagnostics;

using MicroBSC.RolesBasedAthentication;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Common;
using MicroBSC.BSC.Biz;
using MicroBSC.Estimation.Biz;

using Infragistics.WebUI.UltraWebNavigator;

public partial class _common_lib_MicroBSC : System.Web.UI.MasterPage
{
    #region 변수선언 및 초기화
    private string IASSEMBLY_VERSION
    {
        get
        {
            if (ViewState["ASSEMBLY_VERSION"] == null)
            {
                ViewState["ASSEMBLY_VERSION"] = "";
            }

            return (string)ViewState["ASSEMBLY_VERSION"];
        }
        set
        {
            ViewState["ASSEMBLY_VERSION"] = value;
        }
    }
    public int ILogInUserId
    {
        get
        {
            if (ViewState["EMP_REF_ID"] == null)
            {
                SiteIdentity gUserInfo = (SiteIdentity) Context.User.Identity;
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


	// 탑메뉴관련추가 - 08.03.19 류승태
	// AppUserControlBase.cs에서 Copy
	private SiteIdentity gUserInfo = null;

    protected void Page_Load(object sender, EventArgs e)
    {

		if ( Context.User.Identity.IsAuthenticated )
		{
			gUserInfo = (SiteIdentity)Context.User.Identity;
		}

        iBtnShowMenu.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        iBtnShowMenu.Style.Add(HtmlTextWriterStyle.Top, "75px");
        iBtnShowMenu.Style.Add(HtmlTextWriterStyle.Left, "0px");

        if (!IsPostBack)
        {
            this.SetGlobalStatus();
            #region FileVersion
            if (this.IASSEMBLY_VERSION == "")
            {
                string sVersionFormat = "[ {0} ]";
                try
                {
                    FileVersionInfo FVI = FileVersionInfo.GetVersionInfo(Server.MapPath("../bin/MicroBSC_deploy.dll"));
                    this.IASSEMBLY_VERSION = String.Format(sVersionFormat, FVI.FileVersion);
                }
                catch
                {
                }
            }
            lblSysVer.Text = this.IASSEMBLY_VERSION;
            #endregion
        }
        else
        {
            if (hdfMenuStatus.Value == "O")
            {
                tdMenuLeft.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                tdMenuLeft.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        this.SetNoticeBoard();
        this.SetUserName();
        this.SetMenu();

		// 탑메뉴관련추가 - 타이틀설정 - 08.03.19 류승태
		// MenuControl_Tree.ascx.cs 에서 Copy
		InitControlValue();
	}
    #endregion

//    #region Method
    /// <summary>
    /// 현재페이지 전체경로 반환
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public string GetRootPagePath(string filePath)
    {
        string fpath = "";

        fpath = Convert.ToString(System.Web.HttpContext.Current.Request.ApplicationPath + filePath).Replace("//", "");

        return fpath;
    }

    /// <summary>
    /// 사용자정보 세팅
    /// </summary>
    private void SetUserName()
    { 
        SiteIdentity gUserInfo = (SiteIdentity) Context.User.Identity;
        lblEmpName.Text = gUserInfo.Emp_Name;


        //DataTable dtEst_Data = bizEstData.GetEstData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, "", TGT_DEPT_ID, TGT_EMP_ID);
    }

    /// <summary>
    /// 실적마감율 세팅, 결재할 문서, 커뮤니케이션 문서 존재하는지여부
    /// 공지사항 존재여부
    /// </summary>
    private void SetGlobalStatus()
    {
        MicroBSC.Estimation.Dac.TermInfos objTermYY = new MicroBSC.Estimation.Dac.TermInfos();
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();

        int intEstTerm    = objTermYY.GetOpenEstTermID();
        string sFinishMon = objTerm.GetReleasedMonth();
        lblFinishMonth.Text = sFinishMon.Substring(0,4)+"/"+sFinishMon.Substring(4,2);

        //실적마감율 세팅
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        lblFinishRate.Text = biz.GetFinishRate(intEstTerm,sFinishMon).ToString();

        // 커뮤니케이션 리스트가 있는지?
        Biz_Bsc_Communication_User objUser = new Biz_Bsc_Communication_User();
        iBtnCommunication.Src = (objUser.GetIsNewListPerUser(this.ILogInUserId)) ? "~/images/btn/top_bu_k02_b.gif" : "~/images/btn/top_bu_k02.gif";

        // 결재할 문서가 있는지?
        //Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        //iBtnConfirm.Src = (objBSC.GetIsNewDraftPerUser(intEstTerm, sFinishMon, this.ILogInUserId)) ? "~/images/btn/top_bu_k01_b.gif" : "~/images/btn/top_bu_k01.gif";
        Biz_Com_Approval_Prc objBSC = new Biz_Com_Approval_Prc();
        DataSet rDs = objBSC.GetToDraftList(this.ILogInUserId,"");
        if (rDs.Tables.Count > 0)
        {
            iBtnConfirm.Src = (rDs.Tables[0].Rows.Count > 0) ? "~/images/btn/top_bu_k01_b.gif" : "~/images/btn/top_bu_k01.gif";
        }
        else
        {
            iBtnConfirm.Src = "~/images/btn/top_bu_k01.gif";
        }


        // 공지사항이 있는지 또는 읽었는지
        Biz_Bsc_Communication_Notice objNot = new Biz_Bsc_Communication_Notice();
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

        // 회사 이미지로고 세팅
        tblTopMenu.Style.Add(HtmlTextWriterStyle.BackgroundImage, ConfigurationManager.AppSettings["TopMenuLogo.ImageUrl"].ToString());
        imgBottomCopy.ImageUrl = ConfigurationManager.AppSettings["BottomPageCopy.ImageUrl"].ToString();
    }

    private void SetNoticeBoard()
    {
        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

        string strMenuFullPath = HttpContext.Current.Request.Url.AbsolutePath + HttpContext.Current.Request.Url.Query;
        CURRENT_PAGE_MENU_ID = objMenuInfo.GetMenuIDByMenuFullPath(strMenuFullPath);

        if (CURRENT_PAGE_MENU_ID != 0)
            CheckNoticePopupMenu(CURRENT_PAGE_MENU_ID);
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


    /// <summary>
    /// 공백처리
    /// </summary>
    /// <param name="aObj"></param>
    /// <returns></returns>
    protected string GetValue(object aObj)
    {
        if (aObj == null)
            return "";

        return aObj.ToString().Replace( "&nbsp;", "" );
	}

	#region 구 SetMenu() 08.03.19 - 류승태
/*
	/// <summary>
    /// 메뉴세팅
    /// </summary>
    private void SetMenu()
    { 
        string sUrl = HttpContext.Current.Request.Url.AbsolutePath;
               sUrl = sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper();
        string sWhere      = "";
        string sShowLeftMenu = "Y";

        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        DataSet dsAuthMenu      = biz.GetTreeMenuPerUser(this.ILogInUserId.ToString());

        string strTopMenuFileName = "";
        string strCurMenuPageName = "";
        string strCurMenuFileName = "";
        string strAllMenuPathName = "";
        string strUseLeftMenuPage = "Y";

        biz.GetMenuPageInfo(sUrl
                          , out strCurMenuPageName
                          , out strCurMenuFileName
                          , out strAllMenuPathName
                          , out strTopMenuFileName
                          , out strUseLeftMenuPage);

        sWhere = "MENU_TYPE = 'T'";
        DataRow[] arrTopRow     = dsAuthMenu.Tables[0].Select(sWhere,"MENU_PRIORITY ASC");
        DataRow[] arrMidRow     = null;
        DataRow[] arrLowRow     = null;

        string sTopLiteral = "";
        string sMidLiteral = "";
        string sLowLiteral = "";

        string strMenuTxt  = "";
        string strMenuVal  = "";
        string strMenuUrl  = "";

        int cntTopRow      = arrTopRow.Length;
        int cntMidRow      = 0;
        int cntLowRow      = 0;

        trvMenu.Nodes.Clear();
        trvMenu.NodeIndent = 10;
        //trvMenu.CollapseImageUrl = "~/images/arrow/arrow_col_01.jpg";
        //trvMenu.ExpandImageUrl   = "~/images/arrow/arrow_exp_01.jpg";

        for (int i = 0; i < cntTopRow; i++)
        {
            sTopLiteral += "<img src=\"{3}\" alt=\"\" name=\"img{4}\" style=\"vertical-align:bottom; cursor:hand;\" onclick=\"location.href='{0}';\" onmouseover=\"MM_swapImage('img{1}', '', '{2}')\" onmouseout=\"MM_swapImgRestore()\" />";
            sTopLiteral += "&nbsp;";
            sTopLiteral = string.Format
                              (
                                 sTopLiteral
                               , GetValue(arrTopRow[i]["MENU_FULL_PATH"])
                               , GetValue(arrTopRow[i]["MENU_PAGE_NAME"]).Substring(0, GetValue(arrTopRow[i]["MENU_PAGE_NAME"]).LastIndexOf("."))
                               , (strTopMenuFileName.ToUpper() == arrTopRow[i]["MENU_PAGE_NAME"].ToString()) ? GetValue(arrTopRow[i]["MENU_NAME_IMAGE_PATH"])   : GetValue(arrTopRow[i]["MENU_NAME_IMAGE_PATH_U"])
                               , (strTopMenuFileName.ToUpper() == arrTopRow[i]["MENU_PAGE_NAME"].ToString()) ? GetValue(arrTopRow[i]["MENU_NAME_IMAGE_PATH_U"]) : GetValue(arrTopRow[i]["MENU_NAME_IMAGE_PATH"])
                               , GetValue(arrTopRow[i]["MENU_PAGE_NAME"]).Substring(0, GetValue(arrTopRow[i]["MENU_PAGE_NAME"]).LastIndexOf("."))
                                       
                              );
            if ((strTopMenuFileName.ToUpper() == arrTopRow[i]["MENU_PAGE_NAME"].ToString()))
            {
                leftTopTitle.ImageUrl = arrTopRow[i]["MENU_PREV_ICON_PATH"].ToString();
            }

            sWhere    = "UP_MENU_ID=" + arrTopRow[i]["MENU_REF_ID"].ToString();
            arrMidRow = dsAuthMenu.Tables[0].Select(sWhere, "MENU_PRIORITY ASC");
            cntMidRow = arrMidRow.Length;

            for (int j = 0; j < cntMidRow; j++)
            {

                if (strTopMenuFileName.ToUpper().Trim() != arrTopRow[i]["MENU_PAGE_NAME"].ToString().Trim())
                {
                    break;
                }

                //if (arrMidRow[j]["MENU_FULL_PATH"].ToString().Trim() == "")
                //{
                //    strMenuTxt = "<font onclick='return false;'>&nbsp;" + arrMidRow[j]["MENU_NAME"].ToString() + "</font>";
                //}
                //else
                //{ 
                //    strMenuTxt = "&nbsp;"+arrMidRow[j]["MENU_NAME"].ToString();
                //}

                strMenuTxt = "&nbsp;"+arrMidRow[j]["MENU_NAME"].ToString();
                strMenuVal = arrMidRow[j]["MENU_REF_ID"].ToString();

                TreeNode trnMenu = new TreeNode(strMenuTxt, strMenuVal);
                trvMenu.Nodes.Add(trnMenu);
                trnMenu.NavigateUrl = arrMidRow[j]["MENU_FULL_PATH"].ToString().Trim();
                trnMenu.SelectAction = TreeNodeSelectAction.Expand;

                sWhere    = "UP_MENU_ID=" + arrMidRow[j]["MENU_REF_ID"].ToString();
                arrLowRow = dsAuthMenu.Tables[0].Select(sWhere, "MENU_PRIORITY ASC");
                cntLowRow = arrLowRow.Length;

                trnMenu.Collapse();
                for (int k = 0; k < cntLowRow; k++)
                { 
                    if (arrLowRow[k]["MENU_FULL_PATH"].ToString().Trim() == "")
                    {
                        strMenuTxt = "<font onclick='return false;'>&nbsp;" + arrLowRow[k]["MENU_NAME"].ToString() + "</font>";
                    }
                    else
                    { 
                        strMenuTxt = "&nbsp;"+arrLowRow[k]["MENU_NAME"].ToString();
                    }

                    strMenuVal = arrLowRow[k]["MENU_REF_ID"].ToString();

                    TreeNode trnSub = new TreeNode(strMenuTxt, strMenuVal);
                    trnMenu.ChildNodes.Add(trnSub);
                    trnSub.ImageUrl    = "~/images/arrow/arrow_not_sel.gif";
                    trnSub.NavigateUrl = arrLowRow[k]["MENU_FULL_PATH"].ToString();
                    

                    if (strCurMenuFileName == arrLowRow[k]["MENU_PAGE_NAME"].ToString().Trim().ToUpper())
                    {
                        trnSub.Parent.Expand();
                        trnSub.Select();
                        trnSub.Text     = "<font color=\"red\">"+strMenuTxt+"</font>";
                        trnSub.ImageUrl = "~/images/arrow/arrow_sel.gif";
                    }
                }
            }
		}

		ltrTopMenu.Text = sTopLiteral;
        lblTitle.Text = strAllMenuPathName;

        if (strUseLeftMenuPage == "N")
        {
            this.tdMenu_Left.Visible     = false;
            this.tdMenu_Contents.Width   = "100%";
            this.tdMenu_Contents.ColSpan = 2;
        }
    }
*/

	/// <summary>
	/// 08.03.19 - 류승태
	/// 탑메뉴만 있음
	/// </summary>
	private void SetMenu()
	{
		string sUrl = HttpContext.Current.Request.Url.PathAndQuery;

        Biz_lib_MenuControl biz	= new Biz_lib_MenuControl();

        DataSet dsAuthTop			= biz.GetAuthTopMenu( gUserInfo.Emp_Ref_ID.ToString() );

        int iTopMenuID				= GetTopMenuRefID( sUrl );
		DataSet dsSubMenu			= GetSubMenuDs( iTopMenuID.ToString() );

		#region TopMenu 설정
        string sTopLiteral = "";
        int iTmp = 0;
        
        sTopLiteral += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">    \n";
        sTopLiteral += "    <tr>    \n";

        foreach (DataRow drRow in dsAuthTop.Tables[0].Rows)
        {
            sTopLiteral += "<td><img src=\"../images/blank.gif\" width=\"3\"></td>          ";
            sTopLiteral += "<td";
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

        sTopLiteral += "    </tr>   \n";
        sTopLiteral += "</table>    \n";

        ltrTopMenu.Text = sTopLiteral;
        #endregion
	}

    private string GetAppConfig(string asSetting)
    {
        //string connstr = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
        //string saveFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + System.Configuration.ConfigurationManager.AppSettings[asSetting];

        //System.Configuration.AppSettingsReader appSetting = new AppSettingsReader();
        //return (string)appSetting.GetValue(asSetting, Type.GetType("string"));

        string lsRet = "";

        try
        {
            lsRet = ConfigurationManager.AppSettings[asSetting].ToString();
        }
        catch (Exception ex)
        {
            lsRet = "";
        }

        return lsRet;
    }

	private void InitControlValue()
	{
		string sUrl = HttpContext.Current.Request.Url.AbsolutePath;
		Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
		lblTitle.Text = biz.GetMenuTitle( sUrl );

		if ( lblTitle.Text.Trim().Equals( string.Empty ) == true )
		{
			imgTitle.Visible = false;
		}

        //string rightClickYN = GetAppConfig("RIGHT_CLICK_YN");

        //if (rightClickYN.Equals("Y"))
        //    mstBody.Attributes.Add("oncontextmenu", "true");
        //else
        //    mstBody.Attributes.Add("oncontextmenu", "false");
	}

	#endregion
 
    private int GetTopMenuRefID(string asUrl)
    {
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();

        int iTopMenuID = 0;
        DataSet dsAuthMenu = biz.GetAuthMenuInclude_N(gUserInfo.Emp_Ref_ID.ToString());

        DataRow[] draRow;

        draRow = dsAuthMenu.Tables[0].Select(
                                                "(MENU_FULL_PATH = '" + asUrl.ToUpper() + "') OR ( MENU_DIR + MENU_PAGE_NAME = '"+ asUrl.ToUpper() + "' AND MENU_TYPE = 'N')"
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

	#region GetSubMenu() 주석 -- 08.03.20 류승태
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
*/
	#endregion

	private DataSet GetSubMenuDs( string asTopMenuID )
	{
		Biz_lib_MenuControl biz = new Biz_lib_MenuControl();

		DataSet dsReturn = new DataSet();
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

		DataSet dsAuthMenu = biz.GetAuthMenu( gUserInfo.Emp_Ref_ID.ToString() );

		SearchSubMenu( dsAuthMenu, asTopMenuID, 1, ref dtRet );

		dsReturn.Tables.Add( dtRet );

		return dsReturn;
	}    

    public void SetTitle(string title)
    {
        lblTitle.Text = title;
    }

    public string GetTitle()
    {
        return lblTitle.Text;
    }

	#region Event
	protected void leftTopTitle_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnShowMenu_Click(object sender, EventArgs e)
    {

    }
    #endregion
}
