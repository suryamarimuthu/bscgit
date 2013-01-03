using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class nhit_sso : Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        writeLog(string.Format("{0} : PAGE LOAD START", Request.PhysicalPath));
        
        
        //MicroBSC.RolesBasedAthentication.SitePrincipal newUser = null;

        ////int login_status = LOGIN_STATUS;
        ////string user_id = USER_ID;

        //int login_status = 3;
        //string user_id = "5555";

        //if (login_status > 0 && !user_id.Equals(""))
        //{
        //    LOGIN_STATUS = -4;
        //    USER_ID = string.Empty;


        //    MicroBSC.Biz.Common.EmpInfos emp = new MicroBSC.Biz.Common.EmpInfos();
        //    int emp_ref_id = emp.ValidateLogin(user_id);

        //    if (emp_ref_id.Equals(0))
        //    {
        //        FormsAuthentication.SignOut();
        //        Response.Redirect("~/base/login.aspx");
        //        return;
        //    }

        //    newUser = new MicroBSC.RolesBasedAthentication.SitePrincipal(user_id);

        //    Context.User = newUser;

        //    MicroBSC.RolesBasedAthentication.SiteIdentity gUserInfo = (MicroBSC.RolesBasedAthentication.SiteIdentity)Context.User.Identity;

        //    MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common objCtlCommon = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();
        //    objCtlCommon.AddConnectLog(Session.SessionID, gUserInfo.Emp_Ref_ID, gUserInfo.LoginID, gUserInfo.Emp_Name, Request.UserHostAddress, "BSC");

        //    FormsAuthentication.RedirectFromLoginPage(user_id, false);
        //    Response.Redirect("~/base/Main.aspx");
        //}
        //else
        //{
        //    FormsAuthentication.SignOut();
        //    Response.Redirect("~/base/login.aspx");
        //}


        writeLog(string.Format("{0} : PAGE LOAD END", Request.PhysicalPath));
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        //페이지 열릴대마다 로그 기록
        writeLog(string.Format("{0} : lBtnReload_Click START", Request.PhysicalPath));
       
        int status = DataTypeUtility.GetToInt32(hdfStatus.Value);
        string customer = hdfCustomer.Value;
        DoAction(status, customer);


        //페이지 열릴대마다 로그 기록
        writeLog(string.Format("{0} : lBtnReload_Click END", Request.PhysicalPath));

    }

    private void DoAction(int LOGIN_STATUS, string USER_ID)
    {
        //페이지 열릴대마다 로그 기록
        writeLog(string.Format("{0} : DoAction() START", Request.PhysicalPath));
       
        MicroBSC.RolesBasedAthentication.SitePrincipal newUser = null;

        int login_status = LOGIN_STATUS;
        string user_id = USER_ID;

        string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");

        if (WebUtility.GetConfig("SSL", "N").Equals("Y"))
        {
            if (WebUtility.GetConfig("SSLLIVE", "N").Equals("Y"))
            {
                login_page_url = WebUtility.GetConfig("SSL.LoginPageLive", "~/base/Login.aspx");

            }
            else
            {
                login_page_url = WebUtility.GetConfig("SSL.LoginPage", "~/base/Login.aspx");

            }

        }
        //int login_status = 3;
        //string user_id = "admin";

        if (login_status > 0 && !user_id.Equals("-1"))
        {
            LOGIN_STATUS = -4;
            USER_ID = string.Empty;


            MicroBSC.Biz.Common.EmpInfos emp = new MicroBSC.Biz.Common.EmpInfos();
            int emp_ref_id = emp.ValidateLogin(user_id);

            if (emp_ref_id.Equals(0))
            {
                FormsAuthentication.SignOut();
                Response.Redirect(login_page_url);
                return;
            }

            newUser = new MicroBSC.RolesBasedAthentication.SitePrincipal(user_id);

            Context.User = newUser;

            MicroBSC.RolesBasedAthentication.SiteIdentity gUserInfo = (MicroBSC.RolesBasedAthentication.SiteIdentity)Context.User.Identity;


            if (WebUtility.GetConfig("LOG_SIGNON", "N").Equals("Y"))
            {
                MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common objCtlCommon = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();
                objCtlCommon.AddConnectLog(Session.SessionID, gUserInfo.Emp_Ref_ID, gUserInfo.LoginID, gUserInfo.Emp_Name, Request.UserHostAddress, "BSC");
            }

            //페이지 열릴대마다 로그 기록
            writeLog(string.Format("{0} : DoAction() END", Request.PhysicalPath));

            FormsAuthentication.RedirectFromLoginPage(user_id, false);
            Response.Redirect("~/base/Main.aspx");
        }
        else
        {
            //페이지 열릴대마다 로그 기록
            writeLog(string.Format("{0} : DoAction() END", Request.PhysicalPath));
            FormsAuthentication.SignOut();
            Response.Redirect(login_page_url);
        }
    }



    protected void writeLog(string msg)
    {
        //페이지 열릴대마다 로그 기록
        if (WebUtility.GetConfig("USE_PAGE_OPEN_LOG", "N").Equals("Y"))
        {
            string base_dir = System.Web.HttpContext.Current.Server.MapPath("~");

            string fileName = WebUtility.GetConfig("PAGE_OPEN_LOG_FILE", "~\\log.txt");
            string name = fileName.Substring(0, fileName.LastIndexOf("."));
            if (name.IndexOf("~") > -1)
                name = name.Replace("~\\", base_dir);
            string ext = fileName.Substring(fileName.LastIndexOf("."));
            string logFile = name + System.DateTime.Now.ToString("_yyyy-MM-dd") + ext;

            string proxyAddr = DataTypeUtility.GetString(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            string remoteAddr = DataTypeUtility.GetString(Request.ServerVariables["REMOTE_ADDR"]);

            string userAddr = string.Format("PROXY:{0}, USER:{1}", proxyAddr, remoteAddr);

            System.Text.StringBuilder logMsg = new System.Text.StringBuilder();
            logMsg.Append(msg);

            try
            {
                MicroBSC.Common.ErrorLogs.WriteFileError(logMsg.ToString(), userAddr, logFile);
            }
            catch (Exception ex)
            { }
        }
    }
}
