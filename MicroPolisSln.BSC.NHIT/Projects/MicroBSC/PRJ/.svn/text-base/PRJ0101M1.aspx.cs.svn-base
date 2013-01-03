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

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;
using System.Drawing;

public partial class PRJ_PRJ0101M1 : PrjPageBase
{
    #region ==========================[변수선언]================
    public int IPrjRefID
    {
        get
        {
            if (ViewState["PRJ_REF_ID"] == null)
            {
                ViewState["PRJ_REF_ID"] = GetRequestByInt("PRJ_REF_ID", 0);
            }

            return (int)ViewState["PRJ_REF_ID"];
        }
        set
        {
            ViewState["PRJ_REF_ID"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public int ITaskRefID
    {
        get
        {
            if (ViewState["TASK_REF_ID"] == null)
            {
                ViewState["TASK_REF_ID"] = GetRequestByInt("TASK_REF_ID", 0);
            }

            return (int)ViewState["TASK_REF_ID"];
        }
        set
        {
            ViewState["TASK_REF_ID"] = value;
        }
    }

    public int ISelectTabIndex
    {
           get
            {
                if (ViewState["ISELECTTABINDEX"] == null)
                {
                    ViewState["ISELECTTABINDEX"] = WebUtility.GetRequestByInt("ISelectTabIndex",0);
                }
                return (int)ViewState["ISELECTTABINDEX"];
            }
            set
            {
                ViewState["ISELECTTABINDEX"] = value;
            }
    }

   
    private string _taskCode;
    private string _taskName;
    private int _upTaskRefID;
    private string _upTaskName;
    private string _taskType;
    private DateTime _schPlanStartDate;
    private DateTime _schPlanEndDate;
    private DateTime _schActualStartDate;
    private DateTime _schActualEndDate;
    private decimal _proceedRate;
    

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetFormInit();
            SetFormData();
        }
        else
        {

        }

        SetTabPage();

        SetAllTimeBottom();

        ltrScript.Text = "";
    }

    #region 내부 함수

    public void SetAllTimeBottom()
    {
       
    }

    public void SetTabPage()
    {
        if (IType == "A")
        {
            ((Infragistics.WebUI.UltraWebTab.Tab)(ugrdKpiStatusTab.Tabs.FromKey("2"))).Enabled = false;
            ((Infragistics.WebUI.UltraWebTab.Tab)(ugrdKpiStatusTab.Tabs.FromKey("3"))).Enabled = false;
            ((Infragistics.WebUI.UltraWebTab.Tab)(ugrdKpiStatusTab.Tabs.FromKey("4"))).Enabled = false;
        }
        else
        {
 
        }
    }

    public void SetFormInit()
    {
        ifmContent1.Attributes.Add("src", "PRJ0101A1.aspx" + GetTabParam());
        ifmContent2.Attributes.Add("src", "PRJ0101A2.aspx" + GetTabParam());
        ifmContent3.Attributes.Add("src", "PRJ0101A3.aspx" + GetTabParam());
        ifmContent4.Attributes.Add("src", "PRJ0101A4.aspx" + GetTabParam());
    }
    public void SetFormData()
    {

    }

    private string GetTabParam()
    {
        string strParam = string.Format("?PRJ_REF_ID={0}&ITYPE={1}&CCB1={2}"
                                            , this.IPrjRefID.ToString()
                                            , this.IType
                                            , this.ICCB1);
        return strParam;
    }
    #endregion

    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        this.SetFormInit();
    }
}
