using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class nhit_sso_login : Page
{
    public int LOGIN_STATUS
    {
        get
        {
            if (ViewState["LOGIN_STATUS"] == null)
            {
                ViewState["LOGIN_STATUS"] = Request["LOGIN_STATUS"];
                //ViewState["LOGIN_STATUS"] = -4;
            }

            return DataTypeUtility.GetToInt32(ViewState["LOGIN_STATUS"]);
        }
        set
        {
            ViewState["LOGIN_STATUS"] = value;
        }
    }

    public string USER_ID
    {
        get
        {
            if (ViewState["USER_ID"] == null)
            {
                ViewState["USER_ID"] = Request["USER_ID"];
                //ViewState["USER_ID"] = "-1";
            }

            return (string)ViewState["USER_ID"];
        }
        set
        {
            ViewState["USER_ID"] = value;
        }
    }

    public string SSO_YN
    {
        get
        {
            if (ViewState["SSO_YN"] == null)
            {
                ViewState["SSO_YN"] = "";
            }

            return (string)ViewState["SSO_YN"];
        }
        set
        {
            ViewState["SSO_YN"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        MicroBSC.RolesBasedAthentication.SitePrincipal newUser = null;

        int login_status = LOGIN_STATUS;
        string user_id = USER_ID;

        string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");

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

            MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common objCtlCommon = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();
            objCtlCommon.AddConnectLog(Session.SessionID, gUserInfo.Emp_Ref_ID, gUserInfo.LoginID, gUserInfo.Emp_Name, Request.UserHostAddress, "BSC");

            FormsAuthentication.RedirectFromLoginPage(user_id, false);
            Response.Redirect("~/base/Main.aspx");
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect(login_page_url);
        }
    }

    protected void btnRedirection_Click(object sender, EventArgs e)
    {
        
    }
}
