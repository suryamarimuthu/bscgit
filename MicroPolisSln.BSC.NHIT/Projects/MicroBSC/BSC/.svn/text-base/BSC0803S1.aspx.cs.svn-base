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

public partial class BSC_BSC0803S1 : AppPageBase
{

    public int IValidationUserID
    {
        get
        {
            if (ViewState["VALIDATION_USER_ID"] == null)
            {
                ViewState["VALIDATION_USER_ID"] = GetRequestByInt("VALIDATION_USER_ID", 0);
            }

            return (int)ViewState["VALIDATION_USER_ID"];
        }
        set
        {
            ViewState["VALIDATION_USER_ID"] = value;
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
        WebCommon.SetValuationGroupDropDownList(ddlEstGroup, false);
        this.SetSelectedGroupList();

        WebCommon.SetKpiQltEstLevelDropDownList(ddlEstLevel, PageUtility.GetIntByValueDropDownList(ddlEstTerm), false);
    }
    #endregion

    #region 내부함수
    private void SetSelectedGroupList()
    { 
        //Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        //objBSC.Iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
        //objBSC.Igroup_ref_id   = PageUtility.GetIntByValueDropDownList(ddlEstGroup);

        //DataSet rDs = objBSC.GetAllList(objBSC.Iestterm_ref_id, objBSC.Igroup_ref_id);

        Biz_Bsc_Validation_Group_User objBSC = new Biz_Bsc_Validation_Group_User();
        objBSC.Iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
        objBSC.Igroup_ref_id   = PageUtility.GetIntByValueDropDownList(ddlEstGroup);

        DataSet rDs = objBSC.GetEstEmpListPerLevel(
                             objBSC.Iestterm_ref_id
                           , objBSC.Igroup_ref_id
                           , PageUtility.GetIntByValueDropDownList(ddlEstLevel));

        ugrdVaidationUserGrid.Clear();
        ugrdVaidationUserGrid.DataSource = rDs;
        ugrdVaidationUserGrid.DataBind();
    }

    private void SetKpiListPerValidationUser()
    {
        Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi();
        DataSet rDs = objBSC.GetKpiListPerValidationUser
                                             (PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                             , ""
                                             , ""
                                             , ""
                                             , "Y"
                                             , ""
                                             , 0 //PageUtility.GetIntByValueDropDownList(ddlEstDept)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
                                             , PageUtility.GetIntByValueDropDownList(ddlEstLevel)
                                             , this.IValidationUserID);


        ugrdSelectValidationList.Clear();
        ugrdSelectValidationList.DataSource = rDs;
        ugrdSelectValidationList.DataBind();

        //lblUserName.Text = "";
        //this.IValidationUserID = 0;

    }

    private void SetKpiEstOpinion()
    {
        //Biz_Bsc_Validation_Group_Kpi objBSC = new Biz_Bsc_Validation_Group_Kpi
        //                                          (PageUtility.GetIntByValueDropDownList(ddlEstTerm)
        //                                         , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
        //                                         , PageUtility.GetIntByValueDropDownList(ddlEstLevel)
        //                                         , this.IValidationUserID
        //                                         , this.IKpiRefID
        //                                         );
        //txtEstOpinion.Text = objBSC.Iopinion;

        Biz_Bsc_Kpi_Qlt_Score_Had objBSC = new Biz_Bsc_Kpi_Qlt_Score_Had();
        DataSet rDs = objBSC.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                       , ""
                                       , PageUtility.GetIntByValueDropDownList(ddlEstGroup)
                                       , this.IKpiRefID  //PageUtility.GetIntByValueDropDownList(ddlEstLevel)
                                       , this.IValidationUserID);

        ugrdOpinion.Clear();
        ugrdOpinion.DataSource = rDs;
        ugrdOpinion.DataBind();
    }


    #endregion

    #region 서버 이벤트 처리 함수
    protected void ddlEstGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetSelectedGroupList();
    }

    protected void ugrdVaidationUserGrid_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.IValidationUserID = (e.Row.Cells.FromKey("EMP_REF_ID").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString()) : 0;
        this.SetKpiListPerValidationUser();
        ugrdOpinion.Clear();
    }

    protected void ugrdSelectValidationList_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.IKpiRefID = (e.Row.Cells.FromKey("KPI_REF_ID").Value != null) ? Convert.ToInt32(e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString()) : 0;
        this.SetKpiEstOpinion();
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetSelectedGroupList();
        this.ugrdSelectValidationList.Clear();
        //this.txtEstOpinion.Text = "";
    }

    protected void ugrdOpinion_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn tmcOP = (TemplatedColumn)e.Row.Band.Columns.FromKey("OPINION");
        TextBox txtOP = (TextBox)((CellItem)tmcOP.CellItems[e.Row.BandIndex]).FindControl("txtOPINION");
        txtOP.Text = (e.Row.Cells.FromKey("OPINION").Value == null) ? "" : Convert.ToString(e.Row.Cells.FromKey("OPINION").Value.ToString());

    }
    #endregion
}
