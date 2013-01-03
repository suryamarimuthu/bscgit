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
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using Infragistics.WebUI.UltraWebGrid;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Common;

public partial class BSC_BSC0201M1 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IStgRefID
    {
        get
        {
            if (ViewState["STG_REF_ID"] == null)
            {
                ViewState["STG_REF_ID"] = GetRequestByInt("STG_REF_ID", 0);
            }

            return (int)ViewState["STG_REF_ID"];
        }
        set
        {
            ViewState["STG_REF_ID"] = value;
        }
    }

    #endregion
    #region ======================= [ Page Load ] ========================
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ExecuteAtTop();
        if (!Page.IsPostBack)
        {
            ViewInfo_ddlBind();
            this.NotPostBackSetting();
        }
        else
        { 
        
        }
        this.ExecuteAtBottom();
    }
    #endregion
    #region ======================== [ Method ] =========================
    private void ExecuteAtTop()
    {
        ltrScript.Text = "";
    }

    private void NotPostBackSetting()
    {
        this.SetButton();
        this.SetFormData();
    }

    private void PostBackSetting()
    {

    }

    private void ExecuteAtBottom()
    {

    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = (this.IType == "D") ? false : true;
            iBtnDelete.Visible = (this.IType == "D") ? false : true;
            iBtnReUsed.Visible = (this.IType == "D") ? true : false;
        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;
        }
    }

    private void SetFormData()
    {
        if (this.IType != "A")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info(this.IEstTermRefID, this.IStgRefID);
            this.IEstTermRefID = objBSC.Iestterm_ref_id;
            this.IStgRefID     = objBSC.Istg_ref_id;
            txtSTG_CODE.Text   = objBSC.Istg_code;
            txtSTG_ETC.Text    = objBSC.Istg_etc;
            txtSTG_NAME.Text   = objBSC.Istg_name;
            txtSTG_SET_DESC.Text = objBSC.Istg_set_desc;
            ddlStgViewInfo.SelectedValue = objBSC.View_ref_id.ToString();
        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtSTG_NAME.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("전략명을 입력해 주십시오", false);
                return false;
            }
            else if (this.IEstTermRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("평가기간을 알수 없습니다.", false);
                return false;
            }
            else if (PageUtility.GetByValueDropDownList(ddlStgViewInfo) == "0")
            {
                ltrScript.Text = JSHelper.GetAlertScript("상위전략을 선택해 주십시오.", false);
                return false;
            }
            //else if (txtSTG_CODE.Text.Trim() == "")
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("전략코드를 입력해 주십시오", false);
            //}
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (this.IStgRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("전략을 선택해 주십시오", false);
                return false;
            }
            else if (this.IEstTermRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("평가기간을 알수 없습니다.", false);
                return false;
            }
            else if (txtSTG_NAME.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("전략명을 입력해 주십시오", false);
                return false;
            }
            //else if (txtSTG_CODE.Text.Trim() == "")
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("전략코드를 입력해 주십시오", false);
            //}
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (this.IStgRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("전략을 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertStgData()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
        objBSC.Iestterm_ref_id = this.IEstTermRefID;
        objBSC.Istg_code       = txtSTG_CODE.Text.Trim().ToUpper();
        objBSC.Istg_name       = txtSTG_NAME.Text.Trim();
        objBSC.Istg_set_desc   = txtSTG_SET_DESC.Text;
        objBSC.Istg_etc        = txtSTG_ETC.Text;
        objBSC.Iup_stg_id      = 0;
        objBSC.Iuse_yn         = "Y";
        objBSC.Create_user     = gUserInfo.Emp_Ref_ID;

        //int intRtn = objBSC.InsertData(objBSC.Iestterm_ref_id,
        //                               objBSC.Iup_stg_id,
        //                               objBSC.Istg_code,
        //                               objBSC.Istg_name,
        //                               objBSC.Istg_set_desc,
        //                               objBSC.Istg_etc,
        //                               objBSC.Iuse_yn,
        //                               gUserInfo.Emp_Ref_ID);

        int intRtn = objBSC.InsertData(
                                       objBSC.Iup_stg_id,
                                       objBSC.Istg_code,
                                       objBSC.Istg_name,
                                       objBSC.Istg_set_desc,
                                       objBSC.Istg_etc,
                                       objBSC.Iuse_yn,
                                       gUserInfo.Emp_Ref_ID
                                       , int.Parse(PageUtility.GetByValueDropDownList(ddlStgViewInfo)));
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IStgRefID = objBSC.Istg_ref_id;
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }

    private void UpdateStgData()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();

        objBSC.Istg_ref_id     = this.IStgRefID;
        objBSC.Iestterm_ref_id = this.IEstTermRefID;
        objBSC.Istg_code       = txtSTG_CODE.Text.Trim();
        objBSC.Istg_etc        = txtSTG_ETC.Text;
        objBSC.Istg_name       = txtSTG_NAME.Text.Trim();
        objBSC.Istg_set_desc   = txtSTG_SET_DESC.Text;
        objBSC.Create_user     = gUserInfo.Emp_Ref_ID;
        objBSC.Iup_stg_id      = 0;
        objBSC.Iuse_yn         = "Y";
        objBSC.View_ref_id = int.Parse(PageUtility.GetByValueDropDownList(ddlStgViewInfo));

        int intRtn = objBSC.UpdateData(objBSC.Istg_ref_id
                                      ,objBSC.Iup_stg_id
                                      ,objBSC.Istg_code
                                      ,objBSC.Istg_name
                                      ,objBSC.Istg_set_desc
                                      ,objBSC.Istg_etc
                                      ,objBSC.Iuse_yn
                                      , gUserInfo.Emp_Ref_ID, objBSC.View_ref_id);
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
    }

    private void DeleteStgData()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();

        int intRtn = objBSC.DeleteData(this.IEstTermRefID
                                      ,this.IStgRefID
                                      ,gUserInfo.Emp_Ref_ID);


        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
    }

    private void ReUsedStgData()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();

        int intRtn = objBSC.ReUsedData(this.IEstTermRefID
                                      , this.IStgRefID
                                      , gUserInfo.Emp_Ref_ID);


        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
    }

    #region 전략관리 관점 드롭다운 바인딩
    private void ViewInfo_ddlBind()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        DataSet rDs = objBSC.GetAllList();
        ddlStgViewInfo.Items.Add(new ListItem(":: 전체 ::", "0"));
        if (rDs.Tables.Count > 0)
        {
            for (int i = 0; i < rDs.Tables[0].Rows.Count; i++)
            {
                ddlStgViewInfo.Items.Add(new ListItem(rDs.Tables[0].Rows[i]["VIEW_NAME"].ToString(), rDs.Tables[0].Rows[i]["VIEW_REF_ID"].ToString()));
            }

            //ddlStgViewInfo.DataSource = rDs.Tables[0];
            //ddlStgViewInfo.DataTextField = "VIEW_NAME";
            //ddlStgViewInfo.DataValueField = "VIEW_REF_ID";
            //ddlStgViewInfo.DataBind();
        }
    }
    #endregion
    #endregion
    
    #region ======================== [ Server Event ] =========================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertStgData();
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateStgData();
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteStgData();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedStgData();
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
    #endregion
    
}
