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

public partial class BSC_BSC0301S1 : AppPageBase
{
    #region 변수선언
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }
    #endregion

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
        
    }

    private void InitControlValue()
    {
        WebCommon.SetUseYnDropDownList(ddlUseYn, true);
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiType,"", true, 100);
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
        DataSet ds = objBSC.GetAllList(txtKPIName.Text.Trim(), 
                                       PageUtility.GetByValueDropDownList(ddlKpiType),
                                       PageUtility.GetByValueDropDownList(ddlUseYn));

        ugrdKPIPool.Clear();
        ugrdKPIPool.DataSource = ds.Tables[0].DefaultView;
        ugrdKPIPool.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
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
    }
    #endregion
}
