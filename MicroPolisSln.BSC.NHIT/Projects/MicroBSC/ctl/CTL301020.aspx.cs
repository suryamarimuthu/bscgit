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
using MicroBSC.Estimation.Biz;
using MicroBSC.RolesBasedAthentication;
using System.IO;

using MicroBSC.Common;

public partial class CTL_CTL301020 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
    private int _imenu_ref_id;
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
    #endregion
    #region ======================= [ Page Load ] ========================
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ExecuteAtTop();
        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        { 
        
        }
    }

    #endregion
    #region ======================== [ Method ] =========================
    private void ExecuteAtTop() 
    {
        _imenu_ref_id = GetRequestByInt("MENU_REF_ID", 0);
        hdfMenuRefID.Value = _imenu_ref_id.ToString();
        ltrScript.Text = "";
    }
    
    private void NotPostBackSetting()
    {
        TextBoxCommon.SetOnlyInteger(txtMenuRefID);
        TextBoxCommon.SetOnlyInteger(txtUpMenuID);
        TextBoxCommon.SetOnlyInteger(txtMenuPriority);
        

        this.SetButton();
        this.SetFormData();
    }

    private void PostBackSetting()
    { 
    
    }

    private void ExecuteAtBottom() 
    {
    
    }

    private void InitForm()
    { 
        
    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnDelete.Visible = (this.IType == "D") ? false : true;
        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
        }
    }

    /// <summary>
    ///  메뉴ID 구하기
    /// </summary>
    /// <returns></returns>
    private int GetMaxMenuRefID()
    {
        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

        return objMenuInfo.GetMaxMenuRefID();
    }

    private void SetFormData()
    {
        if (this.IType != "A")
        {
            Biz_MenuInfo objMenuInfo = new Biz_MenuInfo(_imenu_ref_id);

            txtMenuRefID.Text    = objMenuInfo.Menu_ref_id.ToString();
            txtUpMenuID.Text     = objMenuInfo.Up_menu_id.ToString();
            hdfUpMenuID.Value    = objMenuInfo.Up_menu_id.ToString();
            txtUpMenuName.Text   = objMenuInfo.Up_Menu_name;

            txtMenuName.Text        = objMenuInfo.Menu_name;
            txtMenuDir.Text         = objMenuInfo.Menu_dir;
            txtMenuPageName.Text    = objMenuInfo.Menu_page_name;
            txtMenuParam.Text       = objMenuInfo.Menu_param;
            txtMenuFullPath.Text    = objMenuInfo.Menu_full_path;
            txtMenuDesc.Text        = objMenuInfo.Menu_desc;
            txtMenuPriority.Text    = objMenuInfo.Menu_priority.ToString();
            WebUtility.FindByValueDropDownList(ddlMenuAuthType, objMenuInfo.Menu_auth_type);
            WebUtility.FindByValueDropDownList(ddlMenuType, objMenuInfo.Menu_type);
            txtMenuNameImagePath.Text   = objMenuInfo.Menu_name_image_path;
            txtMenuNameImagePathU.Text  = objMenuInfo.Menu_name_image_path_u;
            txtMenuPrevIconPath.Text    = objMenuInfo.Menu_prev_icon_path;
            WebUtility.FindByValueDropDownList(ddlShowLeftMenu, objMenuInfo.Show_left_menu);
        }
        else
        {
            txtMenuRefID.Text = GetMaxMenuRefID().ToString();
        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtMenuName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴명을 입력해 주십시오", false);
                return false;
            }
            else if (txtMenuDir.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴디렉토리를 입력해 주십시오", false);
            }
            else if (txtMenuPageName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴페이지명을 입력해 주십시오", false);
            }
            else if (txtMenuFullPath.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴전체경로를 입력해 주십시오", false);
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (hdfMenuRefID.Value.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴ID를 선택해 주십시오", false);
                return false;
            }
            else if (txtMenuName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴명을 입력해 주십시오", false);
                return false;
            }
            else if (txtMenuDir.Text.Trim() == "" && PageUtility.GetByValueDropDownList(ddlMenuType).Equals("S"))
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴디렉토리를 입력해 주십시오", false);
            }
            else if (txtMenuPageName.Text.Trim() == "" && PageUtility.GetByValueDropDownList(ddlMenuType).Equals("S"))
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴페이지명을 입력해 주십시오", false);
            }
            else if (txtMenuFullPath.Text.Trim() == "" && PageUtility.GetByValueDropDownList(ddlMenuType).Equals("S"))
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴전체경로를 입력해 주십시오", false);
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (hdfMenuRefID.Value.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("메뉴ID를 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertViewData()
    {
        if (!this.CheckFormData()) { return; }


        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();


        objMenuInfo.Menu_ref_id             = DataTypeUtility.GetToInt32(this.txtMenuRefID.Text.Trim());
        objMenuInfo.Up_menu_id              = DataTypeUtility.GetToInt32(this.hdfUpMenuID.Value);
        objMenuInfo.Menu_name               = txtMenuName.Text.Trim();
        objMenuInfo.Menu_dir                = txtMenuDir.Text.Trim();
        objMenuInfo.Menu_page_name          = txtMenuPageName.Text.Trim();
        objMenuInfo.Menu_param              = txtMenuParam.Text.Trim();
        objMenuInfo.Menu_full_path          = txtMenuFullPath.Text.Trim();
        objMenuInfo.Menu_desc               = txtMenuDesc.Text.Trim();
        objMenuInfo.Menu_priority           = DataTypeUtility.GetToInt32(txtMenuPriority.Text.Trim());
        objMenuInfo.Menu_auth_type          = WebUtility.GetByValueDropDownList(ddlMenuAuthType);
        objMenuInfo.Menu_type               = WebUtility.GetByValueDropDownList(ddlMenuType);
        objMenuInfo.Menu_name_image_path    = txtMenuNameImagePath.Text.Trim();
        objMenuInfo.Menu_name_image_path_u  = txtMenuNameImagePathU.Text.Trim();
        objMenuInfo.Menu_prev_icon_path     = txtMenuPrevIconPath.Text.Trim();
        objMenuInfo.Show_left_menu          = WebUtility.GetByValueDropDownList(ddlShowLeftMenu);

        bool result = objMenuInfo.AddMenuinfo(objMenuInfo.Menu_ref_id
                                                  , objMenuInfo.Up_menu_id
                                                  , objMenuInfo.Menu_name
                                                  , objMenuInfo.Menu_dir
                                                  , objMenuInfo.Menu_page_name
                                                  , objMenuInfo.Menu_param
                                                  , objMenuInfo.Menu_full_path
                                                  , objMenuInfo.Menu_desc
                                                  , objMenuInfo.Menu_priority
                                                  , objMenuInfo.Menu_auth_type
                                                  , objMenuInfo.Menu_type
                                                  , objMenuInfo.Menu_name_image_path
                                                  , objMenuInfo.Menu_name_image_path_u
                                                  , objMenuInfo.Menu_prev_icon_path
                                                  , DateTime.Now
                                                  , objMenuInfo.Show_left_menu);


        if (result)
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("메뉴등록이 성공되었습니다.", this.ICCB1, true);
        }
        else
        {
            hdfMenuRefID.Value = "";

            ltrScript.Text = JSHelper.GetAlertScript("메뉴등록이 실패했습니다.", false);
        }
    }

    private void UpdateViewData()
    {
        if (!this.CheckFormData()) { return; }

        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo(_imenu_ref_id);

        objMenuInfo.Menu_ref_id             = _imenu_ref_id;
        objMenuInfo.Up_menu_id              = DataTypeUtility.GetToInt32(this.hdfUpMenuID.Value);
        objMenuInfo.Menu_name               = txtMenuName.Text.Trim();
        objMenuInfo.Menu_dir                = txtMenuDir.Text.Trim();
        objMenuInfo.Menu_page_name          = txtMenuPageName.Text.Trim();
        objMenuInfo.Menu_param              = txtMenuParam.Text.Trim();
        objMenuInfo.Menu_full_path          = txtMenuFullPath.Text.Trim();
        objMenuInfo.Menu_desc               = txtMenuDesc.Text.Trim();
        objMenuInfo.Menu_priority           = DataTypeUtility.GetToInt32(txtMenuPriority.Text.Trim());
        objMenuInfo.Menu_auth_type          = WebUtility.GetByValueDropDownList(ddlMenuAuthType);
        objMenuInfo.Menu_type               = WebUtility.GetByValueDropDownList(ddlMenuType);
        objMenuInfo.Menu_name_image_path    = txtMenuNameImagePath.Text.Trim();
        objMenuInfo.Menu_name_image_path_u  = txtMenuNameImagePathU.Text.Trim();
        objMenuInfo.Menu_prev_icon_path     = txtMenuPrevIconPath.Text.Trim();
        objMenuInfo.Show_left_menu          = WebUtility.GetByValueDropDownList(ddlShowLeftMenu);


        bool result = objMenuInfo.ModifyMenuInfo(objMenuInfo.Menu_ref_id
                                                ,objMenuInfo.Up_menu_id
                                                ,objMenuInfo.Menu_name
                                                ,objMenuInfo.Menu_dir
                                                ,objMenuInfo.Menu_page_name
                                                ,objMenuInfo.Menu_param
                                                ,objMenuInfo.Menu_full_path
                                                ,objMenuInfo.Menu_desc
                                                ,objMenuInfo.Menu_priority
                                                ,objMenuInfo.Menu_auth_type
                                                ,objMenuInfo.Menu_type
                                                ,objMenuInfo.Menu_name_image_path
                                                ,objMenuInfo.Menu_name_image_path_u
                                                ,objMenuInfo.Menu_prev_icon_path
                                                ,DateTime.Now
                                                ,objMenuInfo.Show_left_menu);

        if (result)
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("메뉴수정 성공되었습니다.", this.ICCB1, true);
        }
        else
        {
            hdfMenuRefID.Value = "";

            ltrScript.Text = JSHelper.GetAlertScript("메뉴수정이 실패했습니다.", false);
        }
    }

    private void DeleteViewData()
    {
        if (!this.CheckFormData()) { return; }

        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

        bool result = objMenuInfo.RemoveMenuinfo(_imenu_ref_id);

        if (result)
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("메뉴삭제가 성공되었습니다.", this.ICCB1, true);
        }
        else
        {
            hdfMenuRefID.Value = "";

            ltrScript.Text = JSHelper.GetAlertScript("메뉴삭제가 실패했습니다.", false);
        }
    }
   
    #endregion
    #region =========================[ Server Event ] ===================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertViewData();
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateViewData();
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteViewData();
    }
   
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
    #endregion
    
}
