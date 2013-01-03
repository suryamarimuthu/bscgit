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

public partial class usr_excel_pivot_full_screen_dongkuk : AppPageBase
{
    private int ESTTERM_REF_ID  = 0;
    private int TMCODE          = 0;
    private int EST_DEPT_REF_ID = 0;

    public string MONTH         = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        TMCODE          = GetRequestByInt("TMCODE");
        EST_DEPT_REF_ID = GetRequestByInt("EST_DEPT_REF_ID");
        MONTH           = TMCODE.ToString();

        if (!Page.IsPostBack) 
        {
                
        }
    }
}
