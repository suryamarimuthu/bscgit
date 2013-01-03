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

public partial class BSC_BSC0201S1 : AppPageBase
{
    // Control for Call Back
    protected bool IPOSSIBLE_COPY
    {
        get
        {
            if (ViewState["POSSIBLE_COPY"] == null)
                ViewState["POSSIBLE_COPY"] = false;
            return (bool)ViewState["POSSIBLE_COPY"];
        }
        set 
        {
            ViewState["POSSIBLE_COPY"] = value;
        }
    }

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


    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

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
        
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetUseYnDropDownList(ddlUseYn, true);
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo2);

        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        DoSetPossibleCopay();


    }

    private void InitControlEvent()
    {
    }

    private void DoSetPossibleCopay()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
        DataTable dt = objBSC.GetAllList(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), "", "", "").Tables[0];
        this.IPOSSIBLE_COPY = (dt.Rows.Count > 0 ? false : true);
    }

    private void SetPageData()
    {
        SetStgGrid();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {
        if (ddlEstTermInfo.Items.Count == 0)
        {
            divAdd.Visible = false;
        }
    }
    #endregion

    #region 내부함수

    private void DoCopyStg()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
        if (objBSC.CopyStg(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), gUserInfo.Emp_Ref_ID))
            PageUtility.AlertMessage("복사하였습니다.");
        else
            PageUtility.AlertMessage("복사 실패!");
        DoSetPossibleCopay();
    }

    protected void SetStgGrid()
    {
        if (TypeUtility.GetNumString(PageUtility.GetByValueDropDownList(ddlEstTermInfo)) == "")
        {
            PageUtility.AlertMessage("평가기간을 알 수 없습니다!");
            return;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
        objBSC.Iestterm_ref_id = Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlEstTermInfo));
        objBSC.Istg_code       = txtKPICode.Text;
        objBSC.Istg_name       = txtKPIName.Text;
        objBSC.Iuse_yn         = PageUtility.GetByValueDropDownList(ddlUseYn);

        DataSet rDs = objBSC.GetAllList(objBSC.Iestterm_ref_id, objBSC.Istg_code, objBSC.Istg_name, objBSC.Iuse_yn);

        ugrdStgList.Clear();

        if (rDs.Tables.Count > 0)
        {
            ugrdStgList.DataSource = rDs;
            ugrdStgList.DataBind();
        }
    }
    #endregion

    #region 서버 이벤트 처리 함수
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetStgGrid();
    }

    protected void ibtnCopy_Click(object sender, ImageClickEventArgs e)
    {
        DoCopyStg();
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        SetStgGrid();
    }

    protected void ugrdStgList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";


        string use_yn = (DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN").Value) == "Y") ? "U" : "D";
        string stg_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("STG_REF_ID").Value);
        string stg_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("STG_NAME").Value);

        string url = "<a href='#' onclick='doPoppingUp_StgList(\"{0}\",\"{1}\",\"{2}\",\"{3}\")'>{4}</a>";
        string link = string.Format(url, use_yn, IESTTERM_REF_ID, stg_ref_id, ICCB1, stg_name);

        e.Row.Cells.FromKey("STG_NAME").Value = link;
    }

    protected void ddlEstTermInfo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoSetPossibleCopay();
    }
    #endregion

}
