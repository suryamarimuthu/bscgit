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
using MicroBSC.Estimation.Dac;
using MicroBSC.Estimation.Biz;

/// <summary>
/// 평가에서만 사용
/// </summary>
public class EstPageBase : AppPageBase
{
    private DataTable _dtDeptEstPosDetail   = null;
    private DataTable _dtScope              = null;

    public WriteMode PageWriteMode 
    {
        get 
        {
            if(ViewState["WRITE_MODE"] == null)
                return WriteMode.None;

            return (WriteMode)ViewState["WRITE_MODE"];
        }
        set 
        {
            ViewState["WRITE_MODE"] = value;
        }
    }

    protected string EstStyleID
    {
        get 
        {
            if(ViewState["EST_STYLE_ID"] == null)
                return "";

            return (string)ViewState["EST_STYLE_ID"];
        }
        set 
        {
            ViewState["EST_STYLE_ID"] = value;
        }
    }

    protected string EST_JOB_ID
    {
        get 
        {
            if(ViewState["EST_JOB_ID"] == null)
                return "";

            return (string)ViewState["EST_JOB_ID"];
        }
        set 
        {
            ViewState["EST_JOB_ID"] = value;
        }
    }

    protected string EST_JOB_IDS
    {
        get 
        {
            if(ViewState["EST_JOB_IDS"] == null)
                return "";

            return (string)ViewState["EST_JOB_IDS"];
        }
        set 
        {
            ViewState["EST_JOB_IDS"] = value;
        }
    }

    protected bool SEARCH_ALL
    {
        get 
        {
            if(ViewState["SEARCH_ALL"] == null)
                return false;

            return (bool)ViewState["SEARCH_ALL"];
        }
        set 
        {
            ViewState["SEARCH_ALL"] = value;
        }
    }

    protected OwnerType OwnerTypeMode
    {
        get 
        {
            if(ViewState["OWNER_TYPE_MODE"] == null)
                return OwnerType.All;

            return (OwnerType)ViewState["OWNER_TYPE_MODE"];
        }
        set 
        {
            ViewState["OWNER_TYPE_MODE"] = value;
        }
    }

    protected string ScaleTypeMode
    {
        get 
        {
            if(ViewState["SCALE_TYPE_MODE"] == null)
                return "";

            return (string)ViewState["SCALE_TYPE_MODE"];
        }
        set 
        {
            ViewState["SCALE_TYPE_MODE"] = value;
        }
    }

    protected string WeightTypeMode
    {
        get 
        {
            if(ViewState["WEIGHT_TYPE_MODE"] == null)
                return "";

            return (string)ViewState["WEIGHT_TYPE_MODE"];
        }
        set 
        {
            ViewState["WEIGHT_TYPE_MODE"] = value;
        }
    }

    protected YesNo BiasYN
    {
        get 
        {
            if(ViewState["BIAS_YN"] == null)
                return YesNo.No;

            return (YesNo)ViewState["BIAS_YN"];
        }
        set 
        {
            ViewState["BIAS_YN"] = value;
        }
    }

    protected YesNo GradeConfirmYN
    {
        get 
        {
            if(ViewState["GRADE_CONFIRM_YN"] == null)
                return YesNo.No;

            return (YesNo)ViewState["GRADE_CONFIRM_YN"];
        }
        set 
        {
            ViewState["GRADE_CONFIRM_YN"] = value;
        }
    }

    protected int COMP_ID
    {
        get 
        {
            if(Session["COMP_ID"] == null)
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
            if(Session["ESTTERM_REF_ID"] == null)
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
            if(Session["ESTTERM_SUB_ID"] == null)
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
            if(Session["ESTTERM_STEP_ID"] == null)
                return 0;

            return (int)Session["ESTTERM_STEP_ID"];
        }
        set 
        {
            Session["ESTTERM_STEP_ID"] = value;
        }
    }
    
    protected string COL_CHECK_VISIBLE_YN
    {
        get
        {
            if (ViewState["COL_CHECK_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_CHECK_VISIBLE_YN"];
        }
        set
        {
            ViewState["COL_CHECK_VISIBLE_YN"] = value;
        }
    }

    protected string COL_WEIGHT_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_WEIGHT_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_WEIGHT_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_WEIGHT_VISIBLE_YN"] = value;
        }
    }

    protected string COL_POINT_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_POINT_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_POINT_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_POINT_VISIBLE_YN"] = value;
        }
    }

    protected string COL_BIAS_POINT_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_BIAS_POINT_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_BIAS_POINT_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_BIAS_POINT_VISIBLE_YN"] = value;
        }
    }

    protected string COL_GRADE_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_GRADE_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_GRADE_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_GRADE_VISIBLE_YN"] = value;
        }
    }

    protected string COL_GRADE_TO_POINT_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_GRADE_TO_POINT_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_GRADE_TO_POINT_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_GRADE_TO_POINT_VISIBLE_YN"] = value;
        }
    }

    protected string COL_ESTTERM_SUB_AGG_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_ESTTERM_SUB_AGG_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_ESTTERM_SUB_AGG_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_ESTTERM_SUB_AGG_VISIBLE_YN"] = value;
        }
    }

    protected string COL_ESTTERM_STEP_AGG_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_ESTTERM_STEP_AGG_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_ESTTERM_STEP_AGG_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_ESTTERM_STEP_AGG_VISIBLE_YN"] = value;
        }
    }

    protected string COL_CTRL_POINT_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_CTRL_POINT_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_CTRL_POINT_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_CTRL_POINT_VISIBLE_YN"] = value;
        }
    }

    protected string COL_CTRL_GRADE_VISIBLE_YN
    {
        get 
        {
            if(ViewState["COL_CTRL_GRADE_VISIBLE_YN"] == null)
                return "N";

            return (string)ViewState["COL_CTRL_GRADE_VISIBLE_YN"];
        }
        set 
        {
            ViewState["COL_CTRL_GRADE_VISIBLE_YN"] = value;
        }
    }

    protected string COL_DEPT_TO_EMP_DATA
    {
        get 
        {
            if(ViewState["COL_DEPT_TO_EMP_DATA"] == null)
                return "N";

            return (string)ViewState["COL_DEPT_TO_EMP_DATA"];
        }
        set 
        {
            ViewState["COL_DEPT_TO_EMP_DATA"] = value;
        }
    }

    protected string COL_GET_OUTER_DATA
    {
        get 
        {
            if(ViewState["COL_GET_OUTER_DATA"] == null)
                return "N";

            return (string)ViewState["COL_GET_OUTER_DATA"];
        }
        set 
        {
            ViewState["COL_GET_OUTER_DATA"] = value;
        }
    }

    protected string COL_LINK_EST_DATA
    {
        get 
        {
            if(ViewState["COL_LINK_EST_DATA"] == null)
                return "N";

            return (string)ViewState["COL_LINK_EST_DATA"];
        }
        set 
        {
            ViewState["COL_LINK_EST_DATA"] = value;
        }
    }

    protected DataTable DT_DEPT_EST_POS_DETAIL
    {
        get 
        {
            return _dtDeptEstPosDetail;
        }
        set 
        {
            _dtDeptEstPosDetail = value;
        }
    }

    protected DataTable DT_SCOPE
    {
        get 
        {
            return _dtScope;
        }
        set 
        {
            _dtScope = value;
        }
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
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }
}
