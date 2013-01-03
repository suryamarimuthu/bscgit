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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0803S2 : AppPageBase
{
    public int IEsttermRefID
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

    public int IEstLevel
    {
        get
        {
            if (ViewState["EST_LEVEL"] == null)
            {
                ViewState["EST_LEVEL"] = GetRequestByInt("EST_LEVEL", 0);
            }

            return (int)ViewState["EST_LEVEL"];
        }
        set
        {
            ViewState["EST_LEVEL"] = value;
        }
    }

    public int IGroupRefID
    {
        get
        {
            if (ViewState["GROUP_REF_ID"] == null)
            {
                ViewState["GROUP_REF_ID"] = GetRequestByInt("GROUP_REF_ID", 0);
            }

            return (int)ViewState["GROUP_REF_ID"];
        }
        set
        {
            ViewState["GROUP_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetAllTimeTop();
        if (!IsPostBack)
        {
            this.InitControlValue();
        }
        else
        { 
        
        }
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTerm);
        WebCommon.SetValuationGroupDropDownList(ddlEstGroup, true);

        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiGroup,0, true, 100);
        ddlKpiGroup.Width = Unit.Percentage(100);

        objCode.GetKpiEstimateType(ddlBASIS_USE_YN,0, true, 100);
        ddlBASIS_USE_YN.Width = Unit.Percentage(100);

        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        WebCommon.SetKpiQltEstLevelDropDownList(ddlEstLevel, PageUtility.GetIntByValueDropDownList(ddlEstTerm), true);

        this.SetKpiOpinionList();
    }
    #endregion

    #region 내부함수
    private void SetKpiOpinionList()
    { 
        //Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        //DataSet rDs = objBSC.GetOpinionListPerKpi(this.IEsttermRefID, this.IGroupRefID, this.IEstLevel, this.IKpiRefID);

        Biz_Bsc_Kpi_Qlt_Score_Had objBSC = new Biz_Bsc_Kpi_Qlt_Score_Had();
        DataSet rDs = objBSC.GetKpiEstCompleteList
                             ( PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                             , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
                             , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
                             , (ddlEstDept.SelectedValue=="") ? 0 : PageUtility.GetIntByValueDropDownList(ddlEstDept)
                             );

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = rDs;
        ugrdKpiList.DataBind();
    }

    private void SetOpinionListPerKpi()
    { 
        Biz_Bsc_Kpi_Qlt_Score_Had objBSC = new Biz_Bsc_Kpi_Qlt_Score_Had();
        DataSet rDs = objBSC.GetAllList
                                       ( this.IEsttermRefID
                                        , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
                                        , this.IGroupRefID
                                        , this.IKpiRefID
                                        , 0);

        ugrdOpinionList.Clear();
        ugrdOpinionList.DataSource = rDs;
        ugrdOpinionList.DataBind();
    }

    #endregion

    #region 서버 이벤트 처리 함수
    protected void ddlEstGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.SetSelectedGroupList();
    }

    protected void ugrdVaidationUserGrid_ActiveRowChange(object sender, RowEventArgs e)
    {
        //this.IValidationUserID = (e.Row.Cells.FromKey("EMP_REF_ID").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString()) : 0;
        //this.SetKpiListPerValidationUser();
        
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpiOpinionList();
    }

    protected void ugrdKpiList_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.IEsttermRefID = (e.Row.Cells.FromKey("ESTTERM_REF_ID").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()) : 0;
        this.IEstLevel     = (e.Row.Cells.FromKey("EST_LEVEL").Value != null)      ? Convert.ToInt32(e.Row.Cells.FromKey("EST_LEVEL").Value.ToString()) : 0; 
        this.IGroupRefID   = (e.Row.Cells.FromKey("GROUP_REF_ID").Value != null)   ? Convert.ToInt32(e.Row.Cells.FromKey("GROUP_REF_ID").Value.ToString()) : 0;
        this.IKpiRefID     = (e.Row.Cells.FromKey("KPI_REF_ID").Value != null)     ? Convert.ToInt32(e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString()) : 0;
        this.SetOpinionListPerKpi();
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        this.SetKpiOpinionList();
        this.ugrdOpinionList.Clear();
    }
    #endregion
    protected void ddlEstGroup_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlBASIS_USE_YN_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
