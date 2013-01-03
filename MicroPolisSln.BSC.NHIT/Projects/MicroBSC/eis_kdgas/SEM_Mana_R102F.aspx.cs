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
using System.Drawing;
using System.Text;

public partial class eis_SEM_Mana_R102F : System.Web.UI.Page
{
    int type = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        type = (Request["type"] != null && !Request["type"].Equals("")) ? int.Parse(Request["type"].ToString()) : 2;
        Response.ContentType = "application/vnd.ms-powerpoint";
        Response.ContentEncoding = System.Text.UTF7Encoding.UTF7;
        Response.WriteFile("금융기관별예금현황_R102.ppt");
    }
}