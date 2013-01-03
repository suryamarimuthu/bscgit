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
using System.Collections.Specialized;

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.RolesBasedAthentication;
using System.Net;

using System.Web.Security;

public partial class base_Login : AppPageBase
{
    protected string POPUP = "";

    public string _LOGIN_ID
    {
        get
        {
            if (ViewState["LOGINID"] == null)
            {
                ViewState["LOGINID"] = GetRequest("LOGINID", "");
            }

            return (string)ViewState["LOGINID"];
        }
        set
        {
            ViewState["LOGINID"] = value;
        }
    }

    public string _PASSWORD
    {
        get
        {
            if (ViewState["PASSWORD"] == null)
            {
                ViewState["PASSWORD"] = GetRequest("PASSWORD", "");
            }

            return (string)ViewState["PASSWORD"];
        }
        set
        {
            ViewState["PASSWORD"] = value;
        }
    }

    public string _SSO_SITE
    {
        get
        {
            if (ViewState["SSO_SITE"] == null)
            {
                ViewState["SSO_SITE"] = GetRequest("SSO_SITE", "");
            }

            return (string)ViewState["SSO_SITE"];
        }
        set
        {
            ViewState["SSO_SITE"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack) 
        {
            

            loginDiv.Style.Add(HtmlTextWriterStyle.BackgroundImage, PageUtility.GetAppConfig("LoginPage.ImageUrl"));

            // 싱글사인온 처리
            if (ConfigurationManager.AppSettings["SSO"].ToString().Equals("Y"))
            {
                this.SingleSignOne();
            } // 회사별 로그인페이지가 다른경우
            else if (ConfigurationManager.AppSettings["SSO"].ToString().Equals("E"))
            {
                this.EachFromLoginPage();
            }

            CheckSaveUserID();

            if (txtLoginID.Text.Equals(""))
                txtLoginID.Focus();
            else
                txtPasswd.Focus();

            if (ConfigurationManager.AppSettings["Popup.Used"].ToString().ToLower().Equals("true")) 
            {
                POPUP = "<script language='JavaScript' src='../_common/js/PopUpCookie.js'></script>";
            }
        }

        txtLoginID.Attributes["onkeypress"] = "if (event.keyCode==13) {" +
            Page.GetPostBackEventReference(loginbtn) + ";return false;}";
        txtPasswd.Attributes["onkeypress"] = "if (event.keyCode==13) {" +
            Page.GetPostBackEventReference(loginbtn) + ";return false;}";
    }

    /// <summary>
    /// Single Sign On 
    /// </summary>
    protected void SingleSignOne()
    {
        if (this.IsValidSSOServer())
        {
            
            SitePrincipal newUser = null;

            if (PageUtility.GetAppConfig("SSO.Request.OnlyID").ToUpper() == "Y")
            {
                newUser = SitePrincipal.ValidateLogin(this._LOGIN_ID);
            }
            else
            {
                newUser = SitePrincipal.ValidateLogin(this._LOGIN_ID, this._PASSWORD);
            }

            if (newUser != null)
            {
                FormsAuthentication.RedirectFromLoginPage(this._LOGIN_ID, false);
                Response.Redirect("Main.aspx");
            }
        }

        if (PageUtility.GetAppConfig("SSO").ToUpper() == "E")
        {
            string sURL = ConfigurationManager.AppSettings["SSO.MainPage"].ToString();
            Response.Redirect(sURL);
        }
    }

    protected void EachFromLoginPage()
    {
        

        SitePrincipal newUser = null;
        newUser = SitePrincipal.ValidateLogin(this._LOGIN_ID, this._PASSWORD);
        if (newUser != null)
        {
            FormsAuthentication.RedirectFromLoginPage(this._LOGIN_ID, false);
            Response.Redirect("Main.aspx");
        }
        else
        {
            string sURL = ConfigurationManager.AppSettings["SSO.MainPage"].ToString();
            Response.Redirect(sURL);
        }
    }

    public bool IsValidSSOServer()
    {
        string sChkID = PageUtility.GetAppConfig("SSO.Request.OnlyID").ToUpper();
        if (PageUtility.GetAppConfig("SSO").ToUpper() == "N")
        {
            return false;
        }

        if (sChkID == "")
        {
            return false;
        }
        else if (sChkID == "Y" && this._LOGIN_ID == "")
        {
            return false;
        }
        else if (sChkID == "N" && (this._LOGIN_ID == "" || this._PASSWORD == ""))
        {
            return false;
        }
        else
        {
            return true;
        }

        #region 쓸데 없는 주석
        //int i, j;
        //NameValueCollection colReq;

        //if (ConfigurationManager.AppSettings["SSO.Request.Type"].ToString() == "F")
        //{
        //    colReq = Request.Form;
        //}
        //else
        //{
        //    colReq = Request.QueryString;
        //}

        //string strFullPath = "";

        //// 요청된 Querystring Collection에 로그인아이디 키가 있는지
        //String[] arrKey = colReq.AllKeys;

        //bool HaveLoginParam   = false;
        //for (i = 0; i < arrKey.Length; i++)
        //{
        //    String[] arrVal = colReq.GetValues(arrKey[i]);
        //    if (arrKey[i].ToUpper() == "LOGINID")
        //    { 
        //        for (j = 0; j < arrVal.Length; j++)
        //        {
        //            this._LOGIN_ID = arrVal[j];
        //            HaveLoginParam = true;
        //        }                
        //    }

        //    if (arrKey[i].ToUpper() == "PASSWORD")
        //    {
        //        for (j = 0; j < arrVal.Length; j++)
        //        {
        //            this._PASSWORD = arrVal[j];
        //        }
        //    }
        //}

        //if (!HaveLoginParam)
        //{
        //    return false;
        //}

        // Serer Page Check 는 당분간 사용안함
        //if (PageUtility.GetAppConfig("SSO.Request.Server.Check").ToUpper() == "Y")
        //{
        //    // 요청된 서버의 URL 정보 비교
        //    string strVPath = Request.ApplicationPath;
        //    string strSHost = Request.Url.Host;
        //    string strSPort = Request.Url.Port.ToString();
        //    string strProto = Request.Url.Scheme;

        //    if (strVPath == "/")
        //    {
        //        strVPath = "";
        //    }

        //    if (strSPort.Length > 0)
        //    {
        //        strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath;
        //    }
        //    else
        //    {
        //        strFullPath = strProto + "://" + strSHost + strVPath;
        //    }

        //    if (PageUtility.GetAppConfig("SSO.Request.Server").ToUpper() == strFullPath.ToUpper())
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //else
        //{
        //    return true;
        //}
        #endregion
    }

    protected void loginbtn_Click(object sender, ImageClickEventArgs e)
    {
        string bscAuth          = ConfigurationManager.AppSettings["BSC.Authentication"].ToString();
        string domainName       = ConfigurationManager.AppSettings["Domain.Name"].ToString();
        SitePrincipal newUser   = null;

        string en_use_yn = WebUtility.GetConfig("ENCRYPTION_USE_YN").ToUpper();
        string encryption_oneway_mode = WebUtility.GetConfig("ENCRYPTION_ONEWAY_MODE").ToUpper();

        string encPasswd;
        if (en_use_yn.Equals("Y"))
            encPasswd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPasswd.Text, encryption_oneway_mode);
        else
            encPasswd = txtPasswd.Text;

        if (bscAuth.Equals("Forms")) // 폼 인증
        {
            newUser = SitePrincipal.ValidateLogin(txtLoginID.Text, encPasswd);
        }
        else if (bscAuth.Equals("Windows")) // 윈도우 인증 & 폼인증
        {
            if (WindowAuthentication.ValidateLogin(txtLoginID.Text, encPasswd, domainName, Context))
            {
                newUser = new SitePrincipal(txtLoginID.Text);
            }
        }
        
        if (newUser == null)
        {
            MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Info bizEmpInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Info();
            string emp_ref_id = bizEmpInfo.Get_Emp_Ref_Id(txtLoginID.Text);

            if (emp_ref_id.Length == 0)
            { 
                //ID가 없음
                this.ltrScript.Text = JSHelper.GetAlertScript("ID가 존재하지 않습니다.");
                txtLoginID.Focus();
            }
            else
            { 
                //비번이 틀림
                this.ltrScript.Text = JSHelper.GetAlertScript("비밀번호가 틀렸습니다.");
                txtPasswd.Focus();
            }
        }
        else
        {
            Context.User = newUser;

            SaveUserID(txtLoginID.Text, true);			// 쿠키 저장 여부
            //login.SetUserLogs(txtUserID.Text, Request.ServerVariables["REMOTE_ADDR"].ToString(), Request.ServerVariables["HTTP_USER_AGENT"].ToString(), Session.SessionID);



            SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;
            


            //MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common log = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();
            //log.InsertConnectLog(Session.SessionID, gUserInfo.Emp_Ref_ID, gUserInfo.LoginID, gUserInfo.Emp_Name, Request.UserHostAddress, "BSC");



            MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common objCtlCommon = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();
            objCtlCommon.AddConnectLog(Session.SessionID, gUserInfo.Emp_Ref_ID, gUserInfo.LoginID, gUserInfo.Emp_Name, Request.UserHostAddress, "BSC");



            FormsAuthentication.RedirectFromLoginPage(txtLoginID.Text, false);
            Response.Redirect("Main.aspx");

            //if (Request["ReturnUrl"] != null)
            //{
            //    //Response.Cookies["GSBNPortalWeb"].Expires = DateTime.Today.AddDays(-1);
            //    //Response.Cookies["GSBNPortalWeb"].Value = null;

            //    FormsAuthentication.RedirectFromLoginPage(txtLoginID.Text, false);
            //    Response.Redirect("../index.aspx?" + "ReturnUrl=" + Request["ReturnUrl"]);
            //}
            //else
            //{
            //    FormsAuthentication.RedirectFromLoginPage(txtLoginID.Text, false);
            //}
        }
    }

    private void CheckSaveUserID()
    {
        HttpCookieCollection cookies = Request.Cookies;

        if (cookies["SaveBSCUserID"] != null)
        {
            txtLoginID.Text = cookies["SaveBSCUserID"].Values["UserID"];
//            cBoxSaveUserID.Checked = true;
        }
    }

    // 아이디 저장 체크 박스가 true 이면 txtBox 의 값을 쿠키에 저장하여 1달간 저장한다.
    // 아이디 저장 체크 박스가 false 이면 만약 쿠키 key가 존재하면 쿠키를 삭제한다.
    private void SaveUserID(string userId, bool isUserIDSaved)
    {
        HttpCookieCollection cookies = Request.Cookies;
        HttpCookie cookie;

        if (isUserIDSaved)
        {
            if (cookies["SaveBSCUserID"] != null)
                cookie = cookies["SaveBSCUserID"];
            else
                cookie = new HttpCookie("SaveBSCUserID");

            cookie.Values["UserID"] = userId;
            cookie.Expires = System.DateTime.Now.AddDays(30);
            Response.AppendCookie(cookie);
        }
        else
        {
            if (cookies["SaveBSCUserID"] != null)
            {
                cookie = cookies["SaveBSCUserID"];
                cookie.Expires = System.DateTime.Now;
                Response.AppendCookie(cookie);
            }
        }
    }
}
