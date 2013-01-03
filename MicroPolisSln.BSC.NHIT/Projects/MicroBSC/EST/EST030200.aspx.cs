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

public partial class EST_EST030200 : EstPageBase
{
    private Biz_QuestionObjects questionObjects     = new Biz_QuestionObjects();
    private Biz_QuestionSubjects questionSubjects   = new Biz_QuestionSubjects();
    private Biz_QuestionDefines questionDefines     = new Biz_QuestionDefines();

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
            DropDownListCommom.BindDefaultValue(ddlQDfnID, "----------", ""); 
            TextBoxCommon.SetOnlyInteger(txtNum);
            TextBoxCommon.SetOnlyPercent(txtWeight);

            ibnSearch.Attributes.Add("onclick", "return Search();");
            ibnSearchQObjID.Attributes.Add("onclick", "return SearchQObjID();");
            btnNew.Attributes.Add("onclick", "return chkOK();");
            rblMode.Attributes.Add("onclick", "chkRBtn();");
            btnDelete.Attributes.Add("onclick", "return chkDelete();");

            txtQSbjName.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
            txtNum.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
            txtWeight.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
        }

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

        ltrScript.Text = "";
    }

    protected void btnNew_Click(object sender, System.EventArgs e)
    {
        string q_sbj_name   = txtQSbjName.Text;
        string q_dfn_id     = WebUtility.GetByValueDropDownList(ddlQDfnID);
        int num             = DataTypeUtility.GetToInt32(txtNum.Text);
        double weight       = DataTypeUtility.GetToDouble(txtWeight.Text);
        string q_sbj_define = PageUtility.GetHtmlEncodeChar(txtQSbjDefine.Text.Trim().Replace("\r\n", "<br>"));
        string q_sbj_desc   = PageUtility.GetHtmlEncodeChar(txtQSbjDesc.Text.Trim().Replace("\r\n", "<br>"));

        bool bResult        = false;

        if (rblMode.SelectedValue.Equals("0"))  //신규
        {
            bResult = questionSubjects.AddQuestionSubject(WebUtility.GetByValueDropDownList(ddlQObjID)
                                                        , q_dfn_id
                                                        , num
                                                        , q_sbj_name
                                                        , weight
                                                        , q_sbj_define
                                                        , q_sbj_desc
                                                        , DateTime.Now
                                                        , EMP_REF_ID);

            if (bResult)
            {
                BindGrid(WebUtility.GetByValueDropDownList(ddlQObjID));
                ClearValueControls();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("등록되지 않았습니다.", false);
                return;
            }

        }
        else // 수정
        {
            bResult = questionSubjects.ModifyQuestionSubject(hdfQSbjID.Value
                                                           , hdfQObjID.Value
                                                           , q_dfn_id
                                                           , num
                                                           , q_sbj_name
                                                           , weight
                                                           , q_sbj_define
                                                           , q_sbj_desc
                                                           , DateTime.Now
                                                           , EMP_REF_ID);
            if (bResult)
            {
                BindGrid(WebUtility.GetByValueDropDownList(ddlQObjID));
                ClearValueControls();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("수정되지 않았습니다.", false);
            }
        }
    }

    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        string q_sbj_id = hdfQSbjID.Value;
        string q_obj_id = hdfQObjID.Value;

        bool bResult    = questionSubjects.RemoveQuestionSubject(q_sbj_id);

        if (bResult)
        {
            BindGrid(WebUtility.GetByValueDropDownList(ddlQObjID));
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

        e.Row.Cells.FromKey("Q_OBJ_NAME").Value = string.Format("<a href=\"#null\" onclick=\"GetQuestionObjects('{0}');\">{1}</a>"
                                                                                        , dr["Q_OBJ_ID"].ToString()
                                                                                        , dr["Q_OBJ_NAME"].ToString());

        e.Row.Cells.FromKey("Q_SBJ_NAME").Value = string.Format("<a href=\"#null\" onclick=\"GetQuestionSubjects('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');\">{4}</a>"
                                                                                        , dr["Q_SBJ_ID"].ToString()
                                                                                        , dr["Q_OBJ_ID"].ToString()
                                                                                        , dr["Q_DFN_ID"].ToString()
                                                                                        , dr["NUM"].ToString()
                                                                                        , dr["Q_SBJ_NAME"].ToString()
                                                                                        , dr["WEIGHT"].ToString()
                                                                                        , dr["Q_SBJ_DEFINE"].ToString()
                                                                                        , dr["Q_SBJ_DESC"].ToString());
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownListCommom.BindQuestionObject(ddlQObjID, hdfSearchEstID.Value, true);
        DropDownListCommom.BindQuestionDefine(ddlQDfnID, hdfSearchEstID.Value, true);
        UltraWebGrid1.Clear();
        ClearValueControls();
    }

    protected void ibnSearchQObjID_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid(WebUtility.GetByValueDropDownList(ddlQObjID));
        ClearValueControls();
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {
        
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearValueControls();
    }

    private void BindGrid(string q_obj_id)
    {
        UltraWebGrid1.DataSource = questionSubjects.GetQuestionSubject("", q_obj_id,"");
        UltraWebGrid1.DataBind();
    }

    private void ClearValueControls()
    {
        rblMode.SelectedValue   = "0";

        //txtSearchEstName.Text   = "";
        //hdfSearchEstID.Value    = "";
        txtQSbjID.Text          = "";
        txtQSbjName.Text        = "";
        txtNum.Text             = "";
        txtWeight.Text          = "";
        txtQSbjDefine.Text      = "";
        txtQSbjDesc.Text        = "";
        hdfQObjID.Value         = "";
        hdfQSbjID.Value         = "";
    }
}
