using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Data;

public partial class ctl2500 : AppPageBase
{
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo2);
            DoSetPossibleCopay();
            TextBoxCommon.SetOnlyInteger(txtMAX_VALUE);
            TextBoxCommon.SetOnlyInteger(txtMIN_VALUE);

            DoBinding();
        }
        ltrScript.Text = "";
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string[] strCode = new string[]{"SCORE_CODE"};
        DataTable dtTemp = new DataTable();
        dtTemp.Columns.Add("SCORE_CODE", typeof(string));
        dtTemp = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1, "cBox", "selchk", strCode, dtTemp);
        if (dtTemp.Rows.Count > 0)
        {
            Biz_EstDeptOrgScoreInfos bizEDOS = new Biz_EstDeptOrgScoreInfos();
            if (bizEDOS.DeleteEDOS(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), dtTemp))
            {
                DoBinding();
                ltrScript.Text = JSHelper.GetAlertScript("삭제하였습니다.");
            }
            else
                ltrScript.Text = JSHelper.GetAlertScript("삭제실패!");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("선택하세요!");
    }

    protected void ibtnCopy_Click(object sender, ImageClickEventArgs e)
    {
        DoCopyStg();
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EstDeptOrgScoreInfos bizEDOS = new Biz_EstDeptOrgScoreInfos();
        if (bizEDOS.InsertEDOS(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), txtSCORE_CODE.Text.Trim(), txtSCORE_NAME.Text.Trim(), DataTypeUtility.GetToDouble(txtMIN_VALUE.Text), DataTypeUtility.GetToDouble(txtMAX_VALUE.Text), gUserInfo.Emp_Ref_ID))
        {
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장실패!");
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void ddlEstTermInfo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoSetPossibleCopay();
    }

    private void DoBinding()
    {
        Biz_EstDeptOrgScoreInfos bizEDOS = new Biz_EstDeptOrgScoreInfos();
        DataTable dt = bizEDOS.GetEstDeptOrgScoreInfos(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)).Tables[0];
        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = dt;
        UltraWebGrid1.DataBind();
    }

    private void DoSetPossibleCopay()
    {
        this.IPOSSIBLE_COPY = true;
        Biz_EstDeptOrgScoreInfos bizEDOS = new Biz_EstDeptOrgScoreInfos();
        DataTable dt = bizEDOS.GetEstDeptOrgScoreInfos(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2)).Tables[0];
        this.IPOSSIBLE_COPY = (dt.Rows.Count > 0 ? false : true);
    }
    private void DoCopyStg()
    {
        Biz_EstDeptOrgScoreInfos bizEDOS = new Biz_EstDeptOrgScoreInfos();
        if (bizEDOS.CopyEDOS(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), gUserInfo.Emp_Ref_ID))
            PageUtility.AlertMessage("복사하였습니다.");
        else
            PageUtility.AlertMessage("복사 실패!");
        DoSetPossibleCopay();
    }

}
