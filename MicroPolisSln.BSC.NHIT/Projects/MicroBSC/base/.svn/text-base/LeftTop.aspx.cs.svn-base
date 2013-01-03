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

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;

public partial class base_LeftTop : AppPageBase
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

    public void SetCheckInOutBuuton(params Control[] control)
    {
        _control = control;
    }

    public string err = "err";
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
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
        DataSet dsAuthMenu = biz.GetAuthMenu(gUserInfo.Emp_Ref_ID.ToString());
        bool bAuthPage = biz.IsAuthPage(gUserInfo.Emp_Ref_ID.ToString(), sUrl);
        bool bNotUseMenu = biz.IsNotUseMenu(gUserInfo.Emp_Ref_ID.ToString(), sUrl);

        //// 권한이 없을때 처리...
        if (!bAuthPage && err != "err")
        {
            HttpContext.Current.Response.Redirect("/_common/ErrorPages/ErrorInfo.aspx?ERRMSG=권한이 없습니다!");
            return;
        }

        // 메뉴구성페이지가 아닐때 처리...
        if (bNotUseMenu)
        {
            return;
        }
    }

    private void InitControlValue()
    {
        string sUrl = HttpContext.Current.Request.Url.AbsolutePath;

        // ERRORINFO.ASPX는 쿼리스트링이 고정되지 않은 페이지 이므로 예외처리한다. (해당페이지 권한시 FULL_PATH로 처리되므로 무한루프일수 있다.)
        //if (sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "ERRORINFO.ASPX")
        //    sUrl = HttpContext.Current.Request.Url.PathAndQuery;

        lblEmpName.Text = gUserInfo.Emp_Name;

        #region KPI실적 마감월, 마감율 셋팅
        MicroBSC.Estimation.Dac.TermInfos objTermYY = new MicroBSC.Estimation.Dac.TermInfos();
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();

        int intEstTerm    = objTermYY.GetOpenEstTermID();
        string sFinishMon = objTerm.GetReleasedMonth();
        lblFinishMonth.Text = sFinishMon.Substring(0,4)+"/"+sFinishMon.Substring(4,2);

        //실적마감율 세팅
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();
        lblFinishRate.Text = biz.GetFinishRate(intEstTerm,sFinishMon).ToString();

        #endregion
    }

    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {
        ////결재이미지 visible여부
        //SitePrincipal sp = new SitePrincipal(gUserInfo.Emp_Ref_ID);
        //RoleBases rb = new RoleBases();
        //if (sp.IsInRole(rb.ROLE_ADMIN) || sp.IsInRole(rb.ROLE_TEAM_MANAGER) || sp.IsInRole(rb.ROLE_CHAMPION) || sp.IsInRole(rb.ROLE_CEO) || sp.IsInRole(rb.ROLE_OFFICER))
        //{

        //    ImageButton1.Src = "~/images/btn/top_bu_k01_b.gif";
        //    ImageButton1.Visible = true;
        //    if (isResult())
        //        ImageButton1.Src = "~/images/btn/top_bu_k01_b.gif";
        //    else
        //        ImageButton1.Src = "~/images/btn/top_bu_k01.gif";

        //}
        //else
        //{
        //    ImageButton1.Visible = false;
        //}
        //if (sp.IsInRole(rb.ROLE_ADMIN) || sp.IsInRole(rb.ROLE_CHAMPION) || sp.IsInRole(rb.ROLE_CEO) || sp.IsInRole(rb.ROLE_TEAM_MANAGER) || sp.IsInRole(rb.ROLE_OFFICER))
        //{
        //    ImageButton2.Visible = true;
        //    if (isResultPA())
        //        ImageButton2.Src = "~/images/btn/top_bu_k02_b.gif";
        //    else
        //        ImageButton2.Src = "~/images/btn/top_bu_k02.gif";
        //}
        //else
        //{
        //    ImageButton2.Visible = false;
        //}
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {
        //if (IsCheckInOutVisible)
        //{
        //    for (int i = 0; i < this.Controls.Count; i++)
        //    {
        //        if (this.Controls[i] is _common_lib_CheckInOutControl)
        //        {
        //            _common_lib_CheckInOutControl checkOutIn = (_common_lib_CheckInOutControl)this.Controls[i];
        //            checkOutIn.IsEnabled = true;

        //            if (checkOutIn.IsEnabled)
        //                checkOutIn.ButtonArr = _control;

        //            break;
        //        }
        //    }
        //}
    }
    #endregion

    #region 결제아이콘표시

    private bool isResult()
    {
        // 결재할 문서가 있는지?
        //Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result();
        //iBtnConfirm.Src = (objBSC.GetIsNewDraftPerUser(intEstTerm, sFinishMon, this.ILogInUserId)) ? "~/images/btn/top_bu_k01_b.gif" : "~/images/btn/top_bu_k01.gif";
        Biz_Com_Approval_Prc objBSC = new Biz_Com_Approval_Prc();
        DataSet rDs = objBSC.GetToDraftList(this.ILogInUserId, "");
        if (rDs.Tables.Count > 0)
        {
            if (rDs.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

        //매니저권한있는지 여부 true 권한있음.
        //Page.User.IsInRole(ROLE_TEAM_MANAGER); 

        //tmcode 를 가져옵니다.
//        StrategyMapInfos stgMapInfo = new StrategyMapInfos();
//        int tmcode = stgMapInfo.GetTMCODE();

//        //해당유저의 부서코드를 가져옵니다.
//        int dept_id = 0;
//        string query = @"
//                SELECT 
//                    CASE A.DEPT_LEVEL WHEN 4 THEN
//                        (SELECT EST_DEPT_REF_ID 
//                                FROM EST_DEPT_INFO 
//                                WHERE EST_DEPT_REF_ID = A.UP_EST_DEPT_ID)
//                        ELSE
//                           A.EST_DEPT_REF_ID
//                    END AS EST_DEPT_REF_ID
//                    , UP_EST_DEPT_ID
//                FROM 
//                      EST_DEPT_INFO A
//                    , REL_DEPT_EMP B 
//                WHERE A.DEPT_REF_ID= B.DEPT_REF_ID 
//                AND B.EMP_REF_ID=" + gUserInfo.Emp_Ref_ID.ToString() + @"
//                ORDER BY A.ESTTERM_REF_ID DESC";

//        DataSet ds = gDbAgent.FillDataSet(query, "data0");
//        try
//        {
//            dept_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
//        }
//        catch
//        {
//            dept_id = 0;
//        }

//        RoleBases rb    = new RoleBases();
//        string sQuery   = "";

//        if (User.IsInRole(rb.ROLE_ADMIN))//admin 권한일경우 전부서의 결재를 여부를 가져옴
//        {

//            sQuery = @"
//                    SELECT A.RESULT 
//                    FROM   KPI_RESULT A
//	                       ,KPI_INFO B
//                    WHERE A.KPI_REF_ID=B.KPI_REF_ID
//                    AND A.CHECKSTATUS>0
//                    AND A.CONFIRMSTATUS=0
//--                    AND A.TMCODE<=" + tmcode.ToString() + @"";
//        }
//        else
//        {
//            sQuery = @"
//                    SELECT A.RESULT 
//                    FROM   KPI_RESULT A
//	                       ,KPI_INFO B
//                    WHERE A.KPI_REF_ID=B.KPI_REF_ID
//--                    AND EST_DEPT_ID=" + dept_id.ToString() + @"
//                    AND B.CONFIRM_EMP_ID=" + gUserInfo.Emp_Ref_ID + @"
//                    AND A.CHECKSTATUS>0
//                    AND A.CONFIRMSTATUS=0
//--                    AND A.TMCODE<=" + tmcode.ToString() + @"
//                    ";
//        }
//        ds = gDbAgent.FillDataSet(sQuery, "data0");
//        if (ds.Tables[0].Rows.Count > 0)//결재할것들이 있는지 여부
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

    }

    private bool isResultPA()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Communication_User objUser = new MicroBSC.BSC.Biz.Biz_Bsc_Communication_User();
        return (objUser.GetIsNewListPerUser(this.ILogInUserId));

        //매니저권한있는지 여부 true 권한있음.
        //Page.User.IsInRole(ROLE_TEAM_MANAGER); 

        //tmcode 를 가져옵니다.
//        StrategyMapInfos stgMapInfo = new StrategyMapInfos();
//        int tmcode = stgMapInfo.GetTMCODE();

//        //해당유저의 부서코드를 가져옵니다.
//        int dept_id = 0;
//        string query = @"
//                SELECT 
//                    CASE A.DEPT_LEVEL WHEN 4 THEN 
//                            (SELECT EST_DEPT_REF_ID 
//                                FROM EST_DEPT_INFO 
//                                WHERE EST_DEPT_REF_ID = A.UP_EST_DEPT_ID)
//                        ELSE
//                            A.EST_DEPT_REF_ID
//                    END AS EST_DEPT_REF_ID
//                    , UP_EST_DEPT_ID
//                FROM 
//                      EST_DEPT_INFO A
//                    , REL_DEPT_EMP B 
//                WHERE A.DEPT_REF_ID= B.DEPT_REF_ID 
//                AND B.EMP_REF_ID=" + gUserInfo.Emp_Ref_ID.ToString() + @"
//                ORDER BY A.ESTTERM_REF_ID DESC";

//        DataSet ds = gDbAgent.FillDataSet(query, "data0");
//        try
//        {
//            dept_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
//        }
//        catch
//        {
//            dept_id = 0;
//        }

//        RoleBases rb = new RoleBases();

//        if (   User.IsInRole(rb.ROLE_ADMIN) 
//            || User.IsInRole(rb.ROLE_CEO))//admin 권한일경우 전부서의 결재를 여부를 가져옴
//        {

//            query = @"
//                    SELECT KPI_REF_ID 
//                    FROM   PA_REPORT_NOTICE
//                    WHERE COMMENT_CHECK='완료'
//                    AND FEEDBACK_CHECK='미확인'";
//        }
//        else
//        {
//            query = @"
//                    SELECT B.KPI_REF_ID 
//                    FROM   KPI_INFO A
//	                       ,PA_REPORT_NOTICE B
//                    WHERE A.KPI_REF_ID=B.KPI_REF_ID
//                    AND (A.CHAMPION_EMP_ID=" + gUserInfo.Emp_Ref_ID.ToString() + @"
//                    OR A.CONFIRM_EMP_ID=" + gUserInfo.Emp_Ref_ID + @")
//                    AND B.COMMENT_CHECK='미확인'";

//        }
//        ds = gDbAgent.FillDataSet(query, "data0");
//        if (ds.Tables[0].Rows.Count > 0)//결재할것들이 있는지 여부
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

    }
    #endregion
}
