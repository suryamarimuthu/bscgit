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

public partial class EST_EST030100 : EstPageBase
{
    private Biz_QuestionObjects questionObjects = new Biz_QuestionObjects();
    private Biz_QuestionEstMaps questionEstMaps = new Biz_QuestionEstMaps();

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
            ibnCopyQObj.Attributes.Add("onclick", "return confirm('선택하신 질의그룹을 복사하시겠습니까?');");

            txtQObjName.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
            txtQObjTitle.Attributes["onkeypress"] = "if (event.keyCode == 13 && chkOK()) {" +
                Page.ClientScript.GetPostBackEventReference(ibnSearch, "") + ";return false;}";
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);

        ltrScript.Text  = "";
    }

    protected void btnNew_Click(object sender, System.EventArgs e)
    {
        string q_obj_id         = ""; 
        string q_obj_name       = txtQObjName.Text;
        string q_obj_title      = txtQObjTitle.Text;
        string q_obj_preface    = PageUtility.GetHtmlEncodeChar(txtQObjPreface.Text.Trim().Replace("\r\n", "<br>"));

        string[] est_ids        = null;

        if(hdfEstID.Value.Equals("")) 
        {
            est_ids = hdfSearchEstID.Value.Split(',');
        }
        else 
        {
            est_ids = hdfEstID.Value.Split(',');
        }
        
        bool bResult            = false;
        
        if (rblMode.SelectedValue.Equals("0"))  //신규
        {
            bResult = questionObjects.AddQuestionObject(  q_obj_name
                                                        , q_obj_title
                                                        , q_obj_preface
                                                        , est_ids
                                                        , DateTime.Now
                                                        , EMP_REF_ID);

            if (bResult)
            {
                BindGrid(hdfSearchEstID.Value);
                ClearValueControls();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("등록되지 않았습니다.", false);
            }
        }
        else // 수정
        {
            q_obj_id = hdfQObjID.Value;

            bResult =  questionObjects.ModifyQuestionObject(q_obj_id
                                                            , q_obj_name
                                                            , q_obj_title
                                                            , q_obj_preface
                                                            , est_ids
                                                            , DateTime.Now
                                                            , EMP_REF_ID);

            if (bResult)
            {
                BindGrid(hdfSearchEstID.Value);
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
        string q_obj_id     = hdfQObjID.Value;
        string est_id       = hdfEstID.Value;

        bool bResult        = false;

        bResult             = questionObjects.RemoveQuestionObject(q_obj_id);

        if (bResult)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제되었습니다.");
            BindGrid(hdfSearchEstID.Value);
            ClearValueControls();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제되지 않았습니다.");
        }
    }

    protected void ibnCopyQObj_Click(object sender, ImageClickEventArgs e)
    {
        Biz_QuestionObjects questionObj = new Biz_QuestionObjects();
        DataTable dataTable             = questionObj.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue( UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "Q_OBJ_ID" }
                                                            , dataTable);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("복사하려는 질의가 없습니다.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["EST_ID"]   = hdfSearchEstID.Value;
            dataRow["DATE"]     = DateTime.Now;
            dataRow["USER"]     = EMP_REF_ID;
        }

        bool isOK = questionObj.CopyQuestionObject(dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 질의 그룹이 복사되었습니다.");

            BindGrid(hdfSearchEstID.Value);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 복사되지 않았습니다.");
        }
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr      = (DataRowView)e.Data;

        DataSet ds          = questionEstMaps.GetQuestionEstMap("", dr["Q_OBJ_ID"].ToString());
        string returnEstID  = "";
        string est_names    = "";
        Biz_EstInfos estInfo = null;

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            estInfo     = new Biz_EstInfos(COMP_ID, row["EST_ID"].ToString());

            returnEstID += row["EST_ID"].ToString() + ",";
            est_names   += estInfo.Est_Name + ",";
        }

        returnEstID     = returnEstID.Substring(0, returnEstID.LastIndexOf(","));
        est_names       = est_names.Substring(0, est_names.LastIndexOf(","));

        e.Row.Cells.FromKey("Q_OBJ_NAME").Value  = string.Format("<a href=\"#null\" onclick=\"GetQuestionObjects('{0}','{1}','{2}','{3}','{4}','{5}');\">{3}</a>"
                                                                                            , returnEstID
                                                                                            , est_names
                                                                                            , dr["Q_OBJ_ID"]
                                                                                            , dr["Q_OBJ_NAME"]
                                                                                            , dr["Q_OBJ_TITLE"]
                                                                                            , dr["Q_OBJ_PREFACE"]
                                                                                            );
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearValueControls();
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {

    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid(hdfSearchEstID.Value);
    }

    private void BindGrid(string est_id)
    {
        UltraWebGrid1.DataSource = questionObjects.GetQuestionObjects(est_id);
        UltraWebGrid1.DataBind();

        Biz_EstInfos estInfo                = new Biz_EstInfos(COMP_ID, est_id);
        Biz_QuestionPageStyles qPageStyle   = new Biz_QuestionPageStyles(estInfo.Q_Style_ID);

        hdfQStylePageName.Value = qPageStyle.Question_Style_Page_Name;
    }

    private void ClearValueControls()
    {
        rblMode.SelectedValue   = "0";

        //txtSearchEstName.Text   = "";
        //hdfSearchEstID.Value    = "";
        txtQObjID.Text          = "";
        txtQObjName.Text        = "";
        txtQObjTitle.Text       = "";
        txtQObjPreface.Text     = "";
        txtEstName.Text         = "";
        hdfEstID.Value          = "";
        hdfQObjID.Value         = "";
    }

    
}
