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

public partial class usr_usr_excel_pivot_full_screen : AppPageBase
{
    protected string SERVER = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        SERVER = System.Configuration.ConfigurationManager.AppSettings["OLAP_SERVER"].ToString();

        if (!Page.IsPostBack) 
        {
                
        }
    }
}
