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

using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz;

public partial class base_LeftContents : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (PageUtility.IsContainSystemAdminUser(EMP_REF_ID))
            {
                Page.Response.Redirect("/usr/usr2007.aspx");
            }
            else
            {
                if (PageUtility.IsContainSMGUser(EMP_REF_ID))
                {
                    Page.Response.Redirect("/usr/usr2008.aspx");
                }
                else
                {
                    Page.Response.Redirect("/usr/usr1005.aspx");
                }
            }
        }
    }
}
