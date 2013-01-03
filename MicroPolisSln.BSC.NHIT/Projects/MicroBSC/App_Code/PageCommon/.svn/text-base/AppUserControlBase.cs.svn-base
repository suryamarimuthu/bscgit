using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Text;

using Dundas.Charting.WebControl;
using MicroBSC.Data;
using MicroBSC.RolesBasedAthentication;

/// <summary>
/// AppUserControlBase의 요약 설명입니다.
/// </summary>
public class AppUserControlBase : System.Web.UI.UserControl
{
    private AppPageUtility _libPageUtil;
    private AppTypeUtility _libTypeUtil;

    protected SiteIdentity gUserInfo
    {
        get
        {
            if (Context.User.Identity.IsAuthenticated)
                return (SiteIdentity)Context.User.Identity;

            return null;
        }
    }

    /// <summary>
    /// 서비스명	: PageUtility 프로퍼티.
    /// 서비스내용	: PageUtility 객체를 가져옵니다.
    /// </summary>
    protected AppPageUtility PageUtility
    {
        get
        {
            return _libPageUtil;
        }
    }

    /// <summary>
    /// 서비스명	: TypeUtility 프로퍼티.
    /// 서비스내용	: TypeUtility 객체를 가져옵니다.
    /// </summary>
    protected AppTypeUtility TypeUtility
    {
        get
        {
            return _libTypeUtil;
        }
    }

    private string _userId;
    protected DBAgent gDbAgent = null;
    protected DBAgent gDbAgentEIS = null;

    //랜덤필드
    private Random _clsRandom;

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

        _libPageUtil = new AppPageUtility(Page);
        _libTypeUtil = new AppTypeUtility();

        gDbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        gDbAgentEIS = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);

        _clsRandom = new Random(unchecked((int)DateTime.Now.Ticks));

        if (Context.User.Identity.IsAuthenticated)
        {
            _userId = Context.User.Identity.Name;
        }
        else
        {
            _userId = "Anonymous";
        }

        Response.AddHeader("P3P", "CP='CAO PSA CONi OTR OUR DEM ONL'");

        //Response.Write("<META http-equiv=\"Page-Enter\" content=\"blendTrans(Duration=0.3)\">");
        //Response.Write("<META http-equiv=\"Page-Exit\" content=\"blendTrans(Duration=0.3)\">");

        //string sScript = "window.attachEvent('onbeforeunload', gfAttachBeforeUnload_DT);\n"
        //               + "document.body.attachEvent('onfocusout', gfAttachFocusOut_DT);\n"
        //               + "window.attachEvent('onload', gfAttachLoad_DT);\n"
        //               + "document.writeln(\"<iframe id='ifrWAIT' frameborder='0' scrolling='no' class='WaitingBar'></iframe>\");\n"
        //               + "document.writeln(\"<div id='flpWAIT' class='WaitingBarDiv'></div>\");\n";

        //_libPageUtil.ExecuteScript(sScript);

    }
    
    protected string GetValue(object aObj)
    {
        if (aObj == null)
            return "";

        return aObj.ToString().Replace("&nbsp;", "");
    }

    public string GetRootPagePath(string filePath)
    {
        string fpath = "";

        fpath = Convert.ToString(System.Web.HttpContext.Current.Request.ApplicationPath + filePath).Replace("//", "");

        //if (Page.Request.IsLocal)
        //    fpath = Convert.ToString(System.Web.HttpContext.Current.Request.ApplicationPath + filePath).Replace("//", "");
        //else
        //    fpath = filePath;

        return fpath;
    }


    protected void SetCopyrightLayout(HtmlControl htmlCtl)
    {     
        string page_layout = System.Configuration.ConfigurationManager.AppSettings["Page.Layout"].ToString();

        if (page_layout.Equals("DEFAULT"))
            htmlCtl.Attributes.Add("style", "display:block;");
        else if (page_layout.Equals("TOP"))
            htmlCtl.Attributes.Add("style", "display:block;");
        else if (page_layout.Equals("GROUP"))
            htmlCtl.Attributes.Add("style", "display:none;");
    }
}
