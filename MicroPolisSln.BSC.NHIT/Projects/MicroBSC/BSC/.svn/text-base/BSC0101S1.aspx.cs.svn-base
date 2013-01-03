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

using MicroBSC.Data;

public partial class BSC_BSC0101S1 : AppPageBase
{
    // Control for Call Back
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

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
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
        //SetPageLayout(phdLayout);
        //this.ICFCB = this.lBtnReload.ClientID;
    }

    private void SetPageData()
    {
        this.SetGridViewInfo();
    }

    private void SetPostBack()
    {
        
    }

    private void SetAllTimeBottom()
    {

    }
    #endregion

    #region 내부함수
    protected void SetGridViewInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        DataSet rDs = objBSC.GetAllList();

        ugrdView.Clear();
        if (rDs.Tables.Count > 0)
        {
            ugrdView.DataSource = rDs;
            ugrdView.DataBind();
        }
    }
    #endregion

    #region 서버 이벤트 처리 함수
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetGridViewInfo();
    }
    protected void ugrdView_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol    = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg            = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl         = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                                    "../images/icon_o.gif" : "../images/icon_x.gif";


        string use_yn = (DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN")) == "Y") ? "U" : "D";

        string view_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("VIEW_REF_ID").Value);
        string view_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("VIEW_NAME").Value);

        string url = "<a href='#' onclick='doPoppingUp_View(\"{0}\",\"{1}\",\"{2}\")'>{3}</a>";
        string link = string.Format(url, use_yn, view_ref_id, ICCB1, view_name);

        e.Row.Cells.FromKey("VIEW_NAME").Value = link;
    }
    #endregion
}
