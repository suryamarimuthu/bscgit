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

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz.Common;

public partial class BSC_BSC0704S1 : AppPageBase
{
    public int INoticeRefID
    {
        get
        {
            if (ViewState["NOTICE_REF_ID"] == null)
            {
                ViewState["NOTICE_REF_ID"] = GetRequestByInt("NOTICE_REF_ID",0);
            }

            return Convert.ToInt32(ViewState["NOTICE_REF_ID"].ToString());
        }
        set
        {
            ViewState["NOTICE_REF_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.SetInitForm();
        }
        else
        { 
        
        }
    }

    private void SetInitForm()
    {
        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice();
        bool blnRtn = objBSC.GetCurrentNotice();

        if (blnRtn)
        {
            this.INoticeRefID = objBSC.Inotice_ref_id;
            lblTitle.Text     = objBSC.Ititle;
            ltrContent.Text   = objBSC.Idetails;
        }
        else
        {
            lblTitle.Text   = "공지사항 없음";
            ltrContent.Text = "";
        }
    }

    protected void chkToDay_CheckedChanged(object sender, EventArgs e)
    {
        string strCookieKey = "NOTICE_" + this.INoticeRefID.ToString();
        if (Request.Cookies[strCookieKey] != null)
        {
            //쿠키값이 존재하면 삭제하고 다음날로 다시 설정
            Response.Cookies[strCookieKey].Expires = DateTime.Now.AddDays(-1);
            Response.SetCookie(new HttpCookie(strCookieKey,this.INoticeRefID.ToString()));
            Response.Cookies[strCookieKey].Expires = DateTime.Now.AddDays(1);
        }
        else
        { 
            Response.SetCookie(new HttpCookie(strCookieKey,this.INoticeRefID.ToString()));
            Response.Cookies[strCookieKey].Expires = DateTime.Now.AddDays(1);
        }

        ltrScript.Text = JSHelper.GetCloseScript();
    }
}
