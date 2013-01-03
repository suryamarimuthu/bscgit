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
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class ctl_ctl2108 : AppPageBase
{
    int intEstTermID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();
        intEstTermID = GetRequestByInt("ESTTERM_REF_ID", 0);


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

    }

    private void InitControlValue()
    {
        WorkPoolKey.Value = GetRequest("WORK_POOL_KEY", "");
        WorkPoolVal.Value = GetRequest("WORK_POOL_VAL", "");

        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetProjectPriority(ddlWorkPriority, 0, true, 100);
        objCode.GetProjectType(ddlWorkType, 0, true, 100);

        ddlUseYN.Items.Insert(0, new ListItem("::전체::", ""));
        ddlUseYN.Items.Insert(1, new ListItem("사용함", "Y"));
        ddlUseYN.Items.Insert(1, new ListItem("사용안함", "N"));
        ddlUseYN.SelectedIndex = 0;

    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        UltraWebGrid1.DataSource = GetEmpInfoList();
        UltraWebGrid1.DataBind();

    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    #endregion

    #region 내부함수

    private DataSet GetEmpInfoList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool workpool = new MicroBSC.BSC.Biz.Biz_Bsc_Work_Pool();
        return workpool.GetAllList(txtWorkName.Text.Trim(), ddlWorkType.SelectedValue, ddlWorkPriority.SelectedValue, ddlUseYN.SelectedValue);
    }


    #endregion

    #region 서버 이벤트 처리 함수

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetPageData();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";


        DataRowView dr = (DataRowView)e.Data;

        string poolid = e.Row.Cells.FromKey("WORK_POOL_REF_ID").Value.ToString();
        string poolname = e.Row.Cells.FromKey("WORK_NAME").Value.ToString();


        e.Row.Cells.FromKey("SELECT").Value = string.Format(
                            "<a href=\"#\" onclick=\"SetValue('{0}', '{1}');\"><img src='../images/drafts.gif' border='0'></a>", poolid, poolname);
     

    }

    #endregion
}
