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

public partial class EST_EST030300 : EstPageBase
{
    private Biz_QuestionObjects _questionObjects    = new Biz_QuestionObjects();
    private Biz_QuestionItems _questionItems        = new Biz_QuestionItems();

    protected void Page_Init(object sender, System.EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindDefaultValue(ddlQObjID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlQSbjID, "----------", "");
            TextBoxCommon.SetOnlyInteger(txtNum);
            TextBoxCommon.SetOnlyPercent(txtPoint);

            ibnSearch.Attributes.Add("onclick", "return Search();");
            ibnSearchQObjID.Attributes.Add("onclick", "return SearchQObjID();");
            btnNew.Attributes.Add("onclick", "return chkOK();");
            rblMode.Attributes.Add("onclick", "chkRBtn();");
            btnDelete.Attributes.Add("onclick", "return chkDelete();");
            ddlQObjID.Attributes.Add("onchange", "GetDataSet('GetDataSet.aspx','ddlQSbjID','Q_SBJ_NAME','Q_SBJ_ID', 'Survey', 'B', this.value );");
            txtQItmName.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
            txtNum.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
            txtPoint.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);

        ltrScript.Text  = "";
    }

    protected void btnNew_Click(object sender, System.EventArgs e)
    {
        string q_itm_id         = txtQItmID.Text;
        string q_itm_name       = txtQItmName.Text;
        string q_sbj_id         = B.Value;
        int num                 = DataTypeUtility.GetToInt32(txtNum.Text);
        double dPoint           = DataTypeUtility.GetToDouble(txtPoint.Text);
        //string comment          = PageUtility.GetHtmlEncodeChar(txtComment.Text.Trim().Replace("\r\n", "<br>"));
        string comment = txtComment.Text.Trim();
        string subject_item_yn  = rblSubjectItemYN.SelectedValue;

        bool bResult = false;

        if (rblMode.SelectedValue.Equals("0"))  //신규
        {
            bResult = _questionItems.AddQuestionItem( q_sbj_id
                                                    , num
                                                    , q_itm_name
                                                    , dPoint
                                                    , comment
                                                    , subject_item_yn
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
            bResult = _questionItems.ModifyQuestionItem(  q_itm_id
                                                        , q_sbj_id
                                                        , num
                                                        , q_itm_name
                                                        , dPoint
                                                        , comment
                                                        , subject_item_yn
                                                        , DateTime.Now
                                                        , EMP_REF_ID);
            if (bResult)
            {
                BindGrid();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("수정되지 않았습니다.", false);
                return;
            }
        }
    }
    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        string q_itm_id = txtQItmID.Text;
        bool bResult    = _questionItems.RemoveQuestionItem(q_itm_id);

        if (bResult)
        {
            BindGrid();
            ClearValueControls();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제되지 않았습니다.");
        }
    }
   
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        
        e.Row.Cells.FromKey("Q_SBJ_NAME").Value = string.Format("<a href=\"#null\" onclick=\"GetQuestionSubjects('{0}','{1}');\">{2}</a>"
                                                                                        , dr["Q_SBJ_ID"]
                                                                                        , dr["Q_OBJ_ID"]
                                                                                        , dr["Q_SBJ_NAME"]);

        e.Row.Cells.FromKey("Q_ITEM_NAME").Value = string.Format("<a href=\"#null\" onclick=\"GetQuestionItems('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');\">{3}</a>"
                                                                                        , dr["Q_ITM_ID"]
                                                                                        , dr["Q_SBJ_ID"]
                                                                                        , dr["NUM"]
                                                                                        , dr["Q_ITEM_NAME"]
                                                                                        , dr["POINT"]
                                                                                        , dr["COMMENT"]
                                                                                        , dr["SUBJECT_ITEM_YN"]
                                                                                        , dr["Q_OBJ_ID"]);
    }

    protected void ibnSearchQObjID_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
        ClearValueControls();
    }

    protected void ddlEstID_SelectedIndexChanged(object sender, EventArgs e)
    {
        UltraWebGrid1.Clear();
        ClearValueControls();

        DropDownListCommom.BindQuestionObject(ddlQObjID, hdfSearchEstID.Value, true);
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownListCommom.BindQuestionObject(ddlQObjID, hdfSearchEstID.Value, true);

        UltraWebGrid1.Clear();
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
        UltraWebGrid1.DataSource = _questionItems.GetQuestionItem("", "", PageUtility.GetByValueDropDownList(ddlQObjID));
        UltraWebGrid1.DataBind();

        if (!Page.ClientScript.IsStartupScriptRegistered(Page.GetType(), "Search"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Search", string.Format("<script>GetDataSet('GetDataSet.aspx','ddlQSbjID','Q_SBJ_NAME','Q_SBJ_ID', 'Survey', 'B', '{0}');"
                                                                        + "document.forms[0].ddlQSbjID.value={1}; </script>"
                                                                        , PageUtility.GetByValueDropDownList(ddlQObjID), 0));
        }
    }

    private void ClearValueControls()
    {
        WebUtility.FindByValueRadioButtonList(rblMode, "0");

        //txtSearchEstName.Text   = "";
        //hdfSearchEstID.Value    = "";
        txtQItmID.Text          = "";
        txtQItmName.Text        = "";
        txtNum.Text             = "";
        txtPoint.Text           = "";
        txtComment.Text         = "";
        hdfQSbjID.Value         = "";
        hdfQDfnID.Value         = "";
        WebUtility.FindByValueRadioButtonList(rblSubjectItemYN, "0");
    }
}
