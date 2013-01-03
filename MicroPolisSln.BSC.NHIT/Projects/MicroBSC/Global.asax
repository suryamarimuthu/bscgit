<%@ Application Language="C#" %>
<%@ Import Namespace="MicroBSC.Common" %>
<%@ Import Namespace="MicroBSC.RolesBasedAthentication" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        FileInfo fileInfo = null;
        string dir;
        string imageExtensions = "*.PNG;*.JPEG;*.JPG;*.SWF;*.GIF";
        
        
        
        dir = System.Web.HttpContext.Current.Server.MapPath("~/Tempimages");
        if (Directory.Exists(dir))
        {
            string[] files = Directory.GetFiles(dir);

            for (int i = 0; i < files.Length; i++)
            {
                fileInfo = new FileInfo(files[i]);
                string extension = fileInfo.Extension.ToUpper();

                //if (extension.Equals(".swf") || extension.Equals(".png"))
                if (imageExtensions.IndexOf(extension) > -1)
                {
                    File.Delete(files[i]);
                }
            }
        }

        
        
        
        dir = System.Web.HttpContext.Current.Server.MapPath("~/BSC/TempFiles");
        if (Directory.Exists(dir))
        {
            string[] files = Directory.GetFiles(dir);

            for (int i = 0; i < files.Length; i++)
            {
                fileInfo = new FileInfo(files[i]);
                string extension = fileInfo.Extension.ToUpper();

                //if (extension.Equals(".png"))
                if (imageExtensions.IndexOf(extension) > -1)
                {
                    File.Delete(files[i]);
                }
            }
        }


        
        
        dir = System.Web.HttpContext.Current.Server.MapPath("~");
        if (Directory.Exists(dir))
        {
            string[] files = Directory.GetFiles(dir);

            for (int i = 0; i < files.Length; i++)
            {
                fileInfo = new FileInfo(files[i]);

                string filename = fileInfo.Name.ToUpper();
                string extension = fileInfo.Extension.ToUpper();

                //if (extension.Equals(".png"))
                if (imageExtensions.IndexOf(extension) > -1)
                {
                    if (filename.IndexOf("CHART") > -1)
                    {
                        File.Delete(files[i]);
                    }
                }
            }
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //ErrorLogs.WriteFileError(Server.GetLastError().ToString()
        //                        , Request.ServerVariables["REMOTE_ADDR"].ToString()
        //                        , AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["ErrorLog.LogFileName"]);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common log = new MicroBSC.Integration.CTL.Dac.Dac_Ctl_Common();
            SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;
            log.InsertConnectLog(Session.SessionID, gUserInfo.Emp_Ref_ID, gUserInfo.LoginID, gUserInfo.Emp_Name, Request.UserHostAddress, "BSC");
        }
        
    }

    void Session_End(object sender, EventArgs e) 
    {
        if (Context != null)
        {
            SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;
            MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common Biz = new MicroBSC.Integration.CTL.Biz.Biz_Ctl_Common();
            Biz.ModifyConnectLog(Session.SessionID, gUserInfo.LoginID);
        }
    }

    void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication)sender;

        if (app.Request.IsAuthenticated
            && app.User.Identity is FormsIdentity
            && Context.User.Identity.IsAuthenticated)
        {
            if (!(Context.User is SitePrincipal))
            {
                SitePrincipal newUser = new SitePrincipal(Context.User.Identity.Name);
                Context.User = newUser;
            }
        }
    }
</script>
