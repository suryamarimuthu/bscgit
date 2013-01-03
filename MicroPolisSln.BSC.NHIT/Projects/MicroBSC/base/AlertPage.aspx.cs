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

public partial class base_AlertPage : System.Web.UI.Page
{
    public String imgSrc = "~/images/stgmap/log_isi01.jpg";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack) 
        //{
        //    int eid = (Request["eid"] != null && !Request["eid"].Equals("")) ? int.Parse(Request["eid"].ToString()) : 1000;
        //    StrategyMapInfos stgMap = new StrategyMapInfos(eid);
        //    imgSrc = "../stgmap/" + stgMap.Image_Path;
        //}
        //Response.Redirect("/eis/SEM_Mana_R000_02.aspx");
        //Response.Redirect("/usr/usr1005.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/base/logout.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/eis_kdgas/SEM_Mana_R000_02.aspx");
    }
}
