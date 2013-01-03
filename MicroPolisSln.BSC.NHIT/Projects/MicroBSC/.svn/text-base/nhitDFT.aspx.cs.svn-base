using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _nhitDefault : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        writeLog(string.Format("{0} : PAGE LOAD START", Request.PhysicalPath));


        

        //string aa = GetText("LBL_00001", "챔피언");

        string use_SSO_YN = WebUtility.GetConfig("SSO", "");
        string SSO_Login_Url = ConfigurationManager.AppSettings["SSO.MainPage"].ToString();
        string default_Login_Url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");





        if (use_SSO_YN.Equals("Y"))
        {
            Response.Redirect(SSO_Login_Url);
        }
        else
        {
            Response.Redirect(default_Login_Url);
        }


        writeLog(string.Format("{0} : PAGE LOAD END", Request.PhysicalPath));
    }

    //private void DoLoading_Diction()
    //{
    //    Application["LBL"] = null;

    //    try
    //    {
    //        MicroBSC.Integration.COM.Biz.Biz_Com_Lbl_Diction bizComLblDiction = new MicroBSC.Integration.COM.Biz.Biz_Com_Lbl_Diction();

    //        DataTable dtLbl = bizComLblDiction.GetLBL("");

    //        Application["LBL"] = dtLbl;
    //    }
    //    catch
    //    {

    //    }
    //    finally
    //    {

    //    }
    //}
}
