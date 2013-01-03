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

using System.Data;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

public partial class BSC_BSC0301S2 : AppPageBase
{
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

    public string IObjKey
    {
        get
        {
            if (ViewState["OBJ_KEY"] == null)
            {
                ViewState["OBJ_KEY"] = GetRequest("OBJ_KEY", "");
            }

            return (string)ViewState["OBJ_KEY"];
        }
        set
        {
            ViewState["OBJ_KEY"] = value;
        }
    }

    public string IObjVal
    {
        get
        {
            if (ViewState["OBJ_VAL"] == null)
            {
                ViewState["OBJ_VAL"] = GetRequest("OBJ_VAL", "");
            }

            return (string)ViewState["OBJ_VAL"];
        }
        set
        {
            ViewState["OBJ_VAL"] = value;
        }
    }

    #region 페이지 초기화 함수
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

        ltrScript.Text = "";
    }

    private void SetAllTimeTop()
    {
        //SetPageLayout(phdLayout);
    }

    private void InitControlValue()
    {
        WebCommon.SetUseYnDropDownList(ddlUseYn, true);
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiType,"", true, 100);

        WebCommon.SetUseYnDropDownList(ddlBASIS_USE_YN,false);
        WebCommon.SetKpiCategoryTopActiveDropDownList(ddlKpiCategoryTop, true, "Y");
        //WebCommon.SetKpiCategoryMidDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop));
        //WebCommon.SetKpiCategoryLowDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid));
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        this.SetKpiPoolGrid();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    
    #endregion

    #region 내부 함수

    public void SetKpiPoolGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        DataSet ds = objBSC.GetDetailAllList(txtKPIName.Text.Trim()
                                           , PageUtility.GetByValueDropDownList(ddlKpiType)
                                           , PageUtility.GetByValueDropDownList(ddlUseYn)
                                           , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                           , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                           , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                           , ""
                                     );

        ugrdKPIPool.Clear();
        ugrdKPIPool.DataSource = ds.Tables[0].DefaultView;
        ugrdKPIPool.DataBind();
    }
        
    #endregion

    #region 서버 이벤트 처리 함수

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    protected void ugrdKPIPool_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";


        string strUrl = "";
        if (e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value != null)
        {
            strUrl = String.Format("<a href={0}javascript:SetPoolinfo('{1}','{2}');{0}><u>{2}</u></a>"
                                   , "\""
                                   , e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("KPI_NAME").Value.ToString());

            e.Row.Cells.FromKey("KPI_NAME").Text = strUrl;
        }
    }

    protected void txtKPIName_TextChanged(object sender, EventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    protected void ddlKpiCategoryTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }
    protected void ddlKpiCategoryMid_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }
    #endregion

}
