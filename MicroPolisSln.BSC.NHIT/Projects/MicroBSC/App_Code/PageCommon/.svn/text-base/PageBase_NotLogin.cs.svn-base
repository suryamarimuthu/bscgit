using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase_NotLogin : AppPageBase
{
    private string _userId;

    protected string USERID
    {
        get
        {
            return _userId;
        }
    }

    override protected void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Context.User.Identity.IsAuthenticated)
        {
            //if (!Page..IsStartupScriptRegistered("SiteTitle"))
            //    Page.RegisterStartupScript("SiteTitle", JSHelper.JSSetTitle("¢Æ  ¢Æ¢Æ¢Æ - " + user.UserName));

            //if (!Page.IsClientScriptBlockRegistered("DreamWeaver"))
            //    Page.RegisterClientScriptBlock("DreamWeaver", string.Format("<script language='javascript' src='{0}'></script>", LemonCommon.GetRemoveSlash(Request.ApplicationPath + "/_JScript/JSCommon.js")));

            _userId = User.Identity.Name;
        }
        else
        {
            //if (!Page.IsStartupScriptRegistered("SiteTitle"))
            //    Page.RegisterStartupScript("SiteTitle", JSHelper.JSSetTitle("¢Æ  ¢Æ¢Æ¢Æ"));

            _userId = "Anonymous";
        }

        Response.AddHeader("P3P", "CP='CAO PSA CONi OTR OUR DEM ONL'");
    }   
}
