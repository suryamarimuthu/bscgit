using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.RolesBasedAthentication;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.PRJ.Biz;

/// <summary>
/// Summary description for PrjPageBase
/// </summary>
public class PrjPageBase : AppPageBase
{
    private int _isPositionWeightPriorityUsed;
    protected int POSITION_WEIGHT_PRIORITYUSED { get { return _isPositionWeightPriorityUsed; } }

    protected int COMP_ID
    {
        get
        {
            if (Session["COMP_ID"] == null)
                return 0;

            return (int)Session["COMP_ID"];
        }
        set
        {
            Session["COMP_ID"] = value;
        }
    }

    protected int ESTTERM_REF_ID
    {
        get
        {
            if (Session["ESTTERM_REF_ID"] == null)
                return 0;

            return (int)Session["ESTTERM_REF_ID"];
        }
        set
        {
            Session["ESTTERM_REF_ID"] = value;
        }
    }

    protected int ESTTERM_SUB_ID
    {
        get
        {
            if (Session["ESTTERM_SUB_ID"] == null)
                return 0;

            return (int)Session["ESTTERM_SUB_ID"];
        }
        set
        {
            Session["ESTTERM_SUB_ID"] = value;
        }
    }

    protected int ESTTERM_STEP_ID
    {
        get
        {
            if (Session["ESTTERM_STEP_ID"] == null)
                return 0;

            return (int)Session["ESTTERM_STEP_ID"];
        }
        set
        {
            Session["ESTTERM_STEP_ID"] = value;
        }
    }

    public PrjPageBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    override protected void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Context.User.Identity.IsAuthenticated)
        {
            PageTraces pageTrace = new PageTraces();
            pageTrace.LogPageTrace(
                int.Parse(User.Identity.Name)
                , Request.ServerVariables["REMOTE_ADDR"].ToString()
                , Request.UserAgent
                , Request.Url.AbsolutePath.ToString());

            //_isPositionWeightPriorityUsed = (System.Configuration.ConfigurationManager.AppSettings["EST.POSITION.WEIGHT.PRIORITY"].ToUpper().Equals("TRUE")) ? 1 : 0;

            //string isUserIPUsed = ConfigurationManager.AppSettings["Login.IsUserIPUsed"].ToString().ToUpper();

            //if (isUserIPUsed.Equals("TRUE"))
            //{
            //    MicroBSC.Estimation.Dac.Common common = new MicroBSC.Estimation.Dac.Common();

            //    bool isOK = common.IsEstAccessValid(EMP_REF_ID, Request.ServerVariables["REMOTE_ADDR"].ToString());

            //    if (!isOK)
            //    {
            //        string script = JSHelper.GetAlertRedirectScript("접근권한이 없습니다.", "../_common/ErrorPages/ErrorInfo.aspx?ERRTITLE=성과평가 접근권한 없음&ERRMSG=성과평가 접근권한이 없습니다.<br>관리자에게 문의하세요");
            //        Response.Write(script);
            //    }
            //}
        }
    }
}

public enum PrjPeriodDate
{
    PLAN_START,
    PLAN_END,
    EXEC_START,
    EXEC_END
}
