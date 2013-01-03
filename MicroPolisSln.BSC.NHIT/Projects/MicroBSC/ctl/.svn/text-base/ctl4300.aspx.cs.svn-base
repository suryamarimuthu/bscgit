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
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;

public partial class ctl_ctl4300 : AppPageBase
{
    // 디폴트 측정단계
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setGridData();
        }
        else
        {
        
        }
    }

    #region 페이지 초기화 함수
    private void setGridData()
    {
        Biz_Com_Category_Info objCat = new Biz_Com_Category_Info();
        //CategoryInfos objCat = new CategoryInfos();
        DataSet dsCat = objCat.GetAllList();
        ugrdCategory.Clear();
        ugrdCategory.DataSource = dsCat;
        ugrdCategory.DataBind();

        iBtnAdd.Visible = true;
        iBtnUpdate.Visible = true;
        btnCatSave.Visible = true;
    }

    #endregion

    private void saveCatInfo()
    {
        if (!ValidateCatForm())
        {
            return;
        }

        Biz_Com_Category_Info objCat = new Biz_Com_Category_Info();
        objCat.Itype = "A";
        objCat.Icategory_code = txtCatCode.Text;
        objCat.Icategory_name = txtCatName.Text;
        objCat.Icategory_desc = "";
        objCat.Iuse_yn        = (chkUseYn.Checked)    ? "Y" : "N";
        objCat.Isystem_yn     = (chkSystemYn.Checked) ? "Y" : "N";
        objCat.InsertData(objCat.Icategory_code, objCat.Icategory_name, objCat.Icategory_desc
                         , objCat.Isystem_yn, objCat.Iuse_yn, gUserInfo.Emp_Ref_ID);

        ltlMsg.Text = JSHelper.GetAlertScript(objCat.Transaction_Message, false);
    }

    private bool ValidateCatForm()
    {
        if (txtCatCode.Text.Trim() == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("분류코드를 입력해주십시오");
            return false;
        }
        else if (txtCatName.Text.Trim() == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("분류코드명을 입력해주십시오");
            return false;
        }

        return true;
    }

    private bool ValidateEtcForm()
    {
        if (txtEtcCode.Text.Trim() == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("기타코드를 입력해주십시오");
            return false;
        }
        else if (txtEtcName.Text.Trim() == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("기타코드명을 입력해주십시오");
            return false;
        }
        else if (txtSortOrder.Text.Trim() == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("정렬순서를 입력해주십시오");
            return false;
        }
        else if (txtEtcDesc.Text.Trim() == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("코드설명을 입력해주십시오");
            return false;
        }

        return true;
    }

    private void saveCodeInfo(string strGbn)
    {
        if (!ValidateEtcForm())
        {
            return;
        }

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.Itype           = strGbn;
        objCode.Icode_info_id   = (objCode.Itype == "U") ? int.Parse(hdnCodeInfoID.Value.ToString()) : 0;
        objCode.Icategory_code  = txtSCatCode.Text;
        objCode.Ietc_code       = txtEtcCode.Text;
        objCode.Icode_name      = txtEtcName.Text;
        objCode.Icode_desc      = txtEtcDesc.Text;
        objCode.Isort_order     = (txtSortOrder.Text.Trim()=="") ? 0 : int.Parse(txtSortOrder.Text.ToString());
        objCode.Iuse_yn         = (chkSUseYn.Checked) ? "Y" : "N";
        objCode.Isegment1       = txtSegment1.Text;
        objCode.Isegment2       = txtSegment2.Text;
        objCode.Isegment3       = txtSegment3.Text;
        objCode.Isegment4       = txtSegment4.Text;
        objCode.Isegment5       = txtSegment5.Text;
        objCode.InsertData(objCode.Icode_info_id, objCode.Icategory_code, objCode.Ietc_code, objCode.Icode_name, objCode.Icode_desc,
                           objCode.Isort_order, objCode.Iuse_yn, objCode.Isegment1, objCode.Isegment2, objCode.Isegment3, objCode.Isegment4, objCode.Isegment5, gUserInfo.Emp_Ref_ID);

        ltlMsg.Text = JSHelper.GetAlertScript(objCode.Transaction_Message, false);
        this.refreshCodeGrid(txtSCatCode.Text);
    }

    private void setGridCodeData(string strCatCode)
    {
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        DataSet dsCode = objCode.GetCodeListPerCategory(strCatCode,"");

        ugrdComCode.Clear();
        ugrdComCode.DataSource = dsCode;
        ugrdComCode.DataBind();

        if (ugrdComCode.Rows.Count > 0)
        {
            ugrdComCode.Rows[0].Selected = true;
            objCode = new Biz_Com_Code_Info(int.Parse(dsCode.Tables[0].Rows[0]["CODE_INFO_ID"].ToString()));
            hdnCodeInfoID.Value = objCode.Icode_info_id.ToString();
            txtEtcCode.Text     = objCode.Ietc_code;
            txtEtcName.Text     = objCode.Icode_name;
            txtEtcDesc.Text     = objCode.Icode_desc;
            txtSortOrder.Text   = objCode.Isort_order.ToString();
            chkSUseYn.Checked   = (objCode.Iuse_yn == "Y") ? true : false;
            txtSegment1.Text    = objCode.Isegment1;
            txtSegment2.Text    = objCode.Isegment2;
            txtSegment3.Text    = objCode.Isegment3;
            txtSegment4.Text    = objCode.Isegment4;
            txtSegment5.Text    = objCode.Isegment5;
        }
        else
        {
            hdnCodeInfoID.Value = "0";
            txtEtcCode.Text = "";
            txtEtcName.Text = "";
            txtEtcDesc.Text = "";
            txtSortOrder.Text = "";
            chkSUseYn.Checked = false;
        }

        Biz_Com_Category_Info objCat = new Biz_Com_Category_Info(strCatCode);
        txtCatCode.Text      = objCat.Icategory_code;
        txtCatName.Text      = objCat.Icategory_name;
        chkUseYn.Checked     = (objCat.Iuse_yn    == "Y") ? true : false;
        chkSystemYn.Checked  = (objCat.Isystem_yn == "Y") ? true : false;

        txtSCatCode.Text = objCat.Icategory_code;
        txtSCatName.Text = objCat.Icategory_name;
    }

    private void refreshCodeGrid(string strCatCode)
    {
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        DataSet dsCode = objCode.GetCodeListPerCategory(strCatCode, "");
        ugrdComCode.Clear();
        ugrdComCode.DataSource = dsCode;
        ugrdComCode.DataBind();
    }

    protected void btnCatSave_Click(object sender, ImageClickEventArgs e)
    {
        saveCatInfo();
    }
    protected void ugrdCategory_Click(object sender, ClickEventArgs e)
    {
        ltlMsg.Text = "";
        string strCatCode = e.Row.Cells.FromKey("CATEGORY_CODE").ToString();
        this.setGridCodeData(strCatCode);
    }
    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.saveCodeInfo("A");
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.saveCodeInfo("U");
    }
    protected void ugrdComCode_ActiveRowChange(object sender, RowEventArgs e)
    {
        ltlMsg.Text = "";
        hdnCodeInfoID.Value = e.Row.Cells.FromKey("CODE_INFO_ID").Value.ToString();
        txtEtcCode.Text     = e.Row.Cells.FromKey("ETC_CODE").Value.ToString();
        txtEtcName.Text     = e.Row.Cells.FromKey("CODE_NAME").Value.ToString();
        txtEtcDesc.Text     = (e.Row.Cells.FromKey("CODE_DESC").Value==null) ? "" : e.Row.Cells.FromKey("CODE_DESC").Value.ToString();
        txtSortOrder.Text   = e.Row.Cells.FromKey("SORT_ORDER").Value.ToString();
        chkSUseYn.Checked   = (e.Row.Cells.FromKey("USE_YN").Value.ToString().ToUpper() == "TRUE") ? true : false;
        txtSegment1.Text    = (e.Row.Cells.FromKey("SEGMENT1").Value==null) ? "" : e.Row.Cells.FromKey("SEGMENT1").Value.ToString();
        txtSegment2.Text    = (e.Row.Cells.FromKey("SEGMENT2").Value==null) ? "" : e.Row.Cells.FromKey("SEGMENT2").Value.ToString();
        txtSegment3.Text    = (e.Row.Cells.FromKey("SEGMENT3").Value==null) ? "" : e.Row.Cells.FromKey("SEGMENT3").Value.ToString();
        txtSegment4.Text    = (e.Row.Cells.FromKey("SEGMENT4").Value==null) ? "" : e.Row.Cells.FromKey("SEGMENT4").Value.ToString();
        txtSegment5.Text    = (e.Row.Cells.FromKey("SEGMENT5").Value==null) ? "" : e.Row.Cells.FromKey("SEGMENT5").Value.ToString();
    }
    protected void ugrdComCode_InitializeRow(object sender, RowEventArgs e)
    {
        string chkYn = (e.Row.Cells.FromKey("USE_YN").Value == null) ? "N" : e.Row.Cells.FromKey("USE_YN").Value.ToString();

        e.Row.Cells.FromKey("USE_YN").Value = (chkYn == "Y") ? true : false;
        
    }
}
