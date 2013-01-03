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

using MicroBSC.RolesBasedAthentication;

public partial class base_LogOut : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;
            MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common Biz = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();
            Biz.ModifyConnectLog(Session.SessionID, gUserInfo.LoginID);
        }

        FormsAuthentication.SignOut();

        string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");

        Response.Redirect(login_page_url);
    }
}
