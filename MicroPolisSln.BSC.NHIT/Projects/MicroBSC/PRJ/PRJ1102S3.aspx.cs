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

using System.Collections.Generic;
using System.Text;

using MicroBSC.Common;
using MicroBSC.BSC.Biz;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
public partial class PRJ_PRJ1102S3 : AppPageBase
{

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public string IEstTermRefIDName
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID_NAME"] == null)
            {
                ViewState["ESTTERM_REF_ID_NAME"] = GetRequest("ESTTERM_REF_ID_NAME", "");
            }

            return (string)ViewState["ESTTERM_REF_ID_NAME"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID_NAME"] = value;
        }
    }

    //평가부서
    public int IEstDeptRefID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public string IEstDeptRefIDName
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID_NAME"] == null)
            {
                ViewState["EST_DEPT_REF_ID_NAME"] = GetRequest("EST_DEPT_REF_ID_NAME", "");
            }

            return (string)ViewState["EST_DEPT_REF_ID_NAME"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID_NAME"] = value;
        }
    }

    public int IWorkRefID
    {
        get
        {
            if (ViewState["WORK_REF_ID"] == null)
            {
                ViewState["WORK_REF_ID"] = GetRequestByInt("WORK_REF_ID", 0);
            }

            return (int)ViewState["WORK_REF_ID"];
        }
        set
        {
            ViewState["WORK_REF_ID"] = value;
        }
    }

    public string IWorkRefIDName
    {
        get
        {
            if (ViewState["WORK_REF_ID_NAME"] == null)
            {
                ViewState["WORK_REF_ID_NAME"] = GetRequest("WORK_REF_ID_NAME", "");
            }

            return (string)ViewState["WORK_REF_ID_NAME"];
        }
        set
        {
            ViewState["WORK_REF_ID_NAME"] = value;
        }
    }


    public int IExecRefID
    {
        get
        {
            if (ViewState["EXEC_REF_ID"] == null)
            {
                ViewState["EXEC_REF_ID"] = GetRequestByInt("EXEC_REF_ID", 0);
            }

            return (int)ViewState["EXEC_REF_ID"];
        }
        set
        {
            ViewState["EXEC_REF_ID"] = value;
        }
    }

    public string IExecRefIDName
    {
        get
        {
            if (ViewState["EXEC_REF_ID_NAME"] == null)
            {
                ViewState["EXEC_REF_ID_NAME"] = GetRequest("EXEC_REF_ID_NAME", "");
            }

            return (string)ViewState["EXEC_REF_ID_NAME"];
        }
        set
        {
            ViewState["EXEC_REF_ID_NAME"] = value;
        }
    }


    public int IViewRefID
    {
        get
        {
            if (ViewState["VIEW_REF_ID"] == null)
            {
                ViewState["VIEW_REF_ID"] = GetRequestByInt("VIEW_REF_ID", 0);
            }

            return (int)ViewState["VIEW_REF_ID"];
        }
        set
        {
            ViewState["VIEW_REF_ID"] = value;
        }
    }

    public string IViewRefIDName
    {
        get
        {
            if (ViewState["VIEW_REF_ID_NAME"] == null)
            {
                ViewState["VIEW_REF_ID_NAME"] = GetRequest("VIEW_REF_ID_NAME", "");
            }

            return (string)ViewState["VIEW_REF_ID_NAME"];
        }
        set
        {
            ViewState["VIEW_REF_ID_NAME"] = value;
        }
    }

    public int IStgRefID
    {
        get
        {
            if (ViewState["STG_REF_ID"] == null)
            {
                ViewState["STG_REF_ID"] = GetRequestByInt("STG_REF_ID", 0);
            }

            return (int)ViewState["STG_REF_ID"];
        }
        set
        {
            ViewState["STG_REF_ID"] = value;
        }
    }

    public string IStgRefIDName
    {
        get
        {
            if (ViewState["STG_REF_ID_NAME"] == null)
            {
                ViewState["STG_REF_ID_NAME"] = GetRequest("STG_REF_ID_NAME", "");
            }

            return (string)ViewState["STG_REF_ID_NAME"];
        }
        set
        {
            ViewState["STG_REF_ID_NAME"] = value;
        }
    }

    //평가기간
    public string strYMD;

    protected void Page_Load(object sender, EventArgs e)
    {

        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();

    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }


    private void InitControlValue()
    {

    }

    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {

        MicroBSC.Estimation.Dac.TermInfos objTERM = new MicroBSC.Estimation.Dac.TermInfos(this.IEstTermRefID);
        this.IEstTermRefIDName = Convert.ToString(objTERM.Estterm_name);

        Biz_Bsc_Work_Info objWorkInfo = new Biz_Bsc_Work_Info(this.IEstTermRefID, this.IEstDeptRefID, this.IWorkRefID);
        this.IWorkRefIDName = Convert.ToString(objWorkInfo.Iwork_name);

        Biz_Bsc_Work_Exec objWorkExec = new Biz_Bsc_Work_Exec(this.IEstTermRefID, this.IEstDeptRefID, this.IWorkRefID,this.IExecRefID );
        this.IExecRefIDName = Convert.ToString(objWorkExec.Iexec_name);

        this.txtEstTermRefId.Text = this.IEstTermRefIDName;
        this.txtWorkName.Text = this.IWorkRefIDName;
        this.txtExecName.Text = this.IExecRefIDName;

        SetFormData();

    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }

    #endregion

 
    #region 내부함수
    private void SetFormData()
    {

        SetViewStg();
    }

    //중점과제(WorkInfo)조회
    private void SetViewStg()
    {
        Biz_Bsc_Work_Exec objWorkExec = new Biz_Bsc_Work_Exec();
        DataSet rDs = objWorkExec.GetViewStg(this.IEstTermRefID, this.IEstDeptRefID, this.IWorkRefID, this.IExecRefID );

        ugrdViewStg.Clear();
        ugrdViewStg.DataSource = rDs;
        ugrdViewStg.DataBind();

    }

    private void GetParentStg()
    {

    }

    #endregion

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
}
