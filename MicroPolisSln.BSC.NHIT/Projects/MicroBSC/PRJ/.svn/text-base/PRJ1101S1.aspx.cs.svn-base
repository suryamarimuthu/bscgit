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

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

public partial class PRJ_PRJ1101S1 : AppPageBase
{
    /// <summary>
    /// 중점과제 POOL 등록
    /// </summary>
    #region 변수선언
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
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
        objCode.GetProjectType(ddlWorkType, "", true, 100);
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        this.SetWorkPoolGrid();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }

    #endregion

    #region 내부 함수

    public void SetWorkPoolGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool();
        DataSet ds = objBSC.GetAllList(txtWorkName.Text.Trim(),
                                       PageUtility.GetByValueDropDownList(ddlWorkType),
                                       PageUtility.GetByValueDropDownList(ddlUseYn));

        ugrdWorkPool.Clear();
        ugrdWorkPool.DataSource = ds.Tables[0].DefaultView;
        ugrdWorkPool.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }

    #endregion

    #region 서버 이벤트 처리 함수

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetWorkPoolGrid();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetWorkPoolGrid();
    }

    #endregion
    protected void ugrdWorkPool_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

    }
}
