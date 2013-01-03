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

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

using MicroBSC.Estimation.Biz;

public partial class EST_EST030400 : EstPageBase
{
    private string EST_ID;
    private Biz_QuestionDefines _questionDefine = new Biz_QuestionDefines();

    protected void Page_Init(object sender, System.EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);

            ibnSearch.Attributes.Add("onclick", "return Search();");
            btnNew.Attributes.Add("onclick", "return chkOK();");
            rblMode.Attributes.Add("onclick", "chkRBtn();");
            btnDelete.Attributes.Add("onclick", "return chkDelete();");
        }

        EST_ID = hdfSearchEstID.Value;

        ltrScript.Text = "";
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }

    protected void btnNew_Click(object sender, System.EventArgs e)
    {
        string q_dfn_name    = WebUtility.GetHtmlEncodeChar(txtDfnName.Text.Trim().Replace("\r\n", "<br>")); 
        string q_dfn_define  = WebUtility.GetHtmlEncodeChar(txtDfnDefine.Text.Trim().Replace("\r\n", "<br>"));
        string q_dfn_notice  = WebUtility.GetHtmlEncodeChar(txtDfnNotice.Text.Trim().Replace("\r\n", "<br>"));
        string q_dfn_desc    = WebUtility.GetHtmlEncodeChar(txtDfnDesc.Text.Trim().Replace("\r\n", "<br>"));
        string num           = txtNum.Text;
        string est_id        = hdfSearchEstID.Value;

        bool bResult = false;

        if (rblMode.SelectedValue.Equals("0"))  //신규
        {
            bResult = _questionDefine.AddQuestionDefine(  num
                                                        , q_dfn_name
                                                        , q_dfn_define
                                                        , q_dfn_notice
                                                        , q_dfn_desc
                                                        , est_id
                                                        , DateTime.Now
                                                        , EMP_REF_ID);

            if (bResult)
            {
                BindGrid();
                ClearValueControls();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("등록되지 않았습니다.", false);
            }
        }
        else // 수정
        {
            string q_dfn_id = hdfDfnID.Value;

            bResult = _questionDefine.ModifyQuestionDefine(q_dfn_id
                                                        , num
                                                        , q_dfn_name
                                                        , q_dfn_define
                                                        , q_dfn_notice
                                                        , q_dfn_desc
                                                        , est_id
                                                        , DateTime.Now
                                                        , EMP_REF_ID);
            if (bResult)
            {
                BindGrid();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("수정되지 않았습니다.", false);
            }
        }
    }

    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        string q_dfn_id = hdfDfnID.Value;

        bool bResult = _questionDefine.RemoveQuestionDefine(q_dfn_id);

        if (bResult)
        {
            BindGrid();
            ClearValueControls();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제되지 않았습니다.", false);
            return;
        }
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        e.Row.Cells.FromKey("Q_DFN_NAME").Value = string.Format("<a href=\"#null\" onclick=\"GetSurveyGroups('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');\">{2}</a>"
                                                                                            , dr["EST_ID"]
                                                                                            , dr["Q_DFN_ID"]
                                                                                            , dr["Q_DFN_NAME"]
                                                                                            , dr["Q_DFN_DEFINE"]
                                                                                            , dr["Q_DFN_NOTICE"]
                                                                                            , dr["Q_DFN_DESC"]
                                                                                            , dr["NUM"]
                                                                                            , dr["EST_NAME"]);
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {

    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearValueControls();
    }

    private void BindGrid()
    {
        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = _questionDefine.GetQuestionDefine(EST_ID);

        UltraWebGrid1.DataBind();
    }

    private void ClearValueControls()
    {
        //txtSearchEstName.Text  = "";
        //hdfSearchEstID.Value   = "";
	    txtDfnID.Text          = "";
	    hdfDfnID.Value         = "";
        txtDfnName.Text        = "";
	    txtDfnDefine.Text      = "";
	    txtDfnNotice.Text      = "";
	    txtDfnDesc.Text        = "";
		txtNum.Text            = "";
    }
}
