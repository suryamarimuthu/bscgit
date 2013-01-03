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

public partial class CTL_CTL301010 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
    private int _irole_ref_id;
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
        _irole_ref_id = GetRequestByInt("ROLE_REF_ID", 0);
        hdfRoleRefID.Value = _irole_ref_id.ToString();
        ltrScript.Text = "";
    }
    
    private void NotPostBackSetting()
    {
        TextBoxCommon.SetOnlyInteger(txtSortOrder);

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

    private void SetFormData()
    {
        if (this.IType != "A")
        {
            Biz_RoleInfos objRoleInfo = new Biz_RoleInfos(_irole_ref_id);

            txtRoleName.Text        = objRoleInfo.Role_Name;
            txtRoleDesc.Text        = objRoleInfo.Role_Desc;
            txtSortOrder.Text       = objRoleInfo.Sort_Order.ToString();
        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtRoleName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("권한명을 입력해 주십시오", false);
                return false;
            }
            else if (txtSortOrder.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("정렬순서를 입력해 주십시오", false);
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (hdfRoleRefID.Value.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("권한을 선택해 주십시오", false);
                return false;
            }
            else if (txtRoleName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("권한명을 입력해 주십시오", false);
                return false;
            }
            else if (txtSortOrder.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("정렬순서를 입력해 주십시오", false);
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (hdfRoleRefID.Value.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("권한을 선택해 주십시오", false);
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


        Biz_RoleInfos objRoleInfo = new Biz_RoleInfos();

        objRoleInfo.Role_Ref_ID = 0;
        objRoleInfo.Role_Name   = this.txtRoleName.Text.Trim();
        objRoleInfo.Role_Desc   = this.txtRoleDesc.Text.Trim();
        objRoleInfo.Sys_Type    = "";
        objRoleInfo.Sort_Order  = DataTypeUtility.GetToInt32(this.txtSortOrder.Text.Trim());
        objRoleInfo.Delete_Enabled_YN = "Y";

        bool result = objRoleInfo.AddRoleInfo( objRoleInfo.Role_Name
                                            , objRoleInfo.Role_Desc
                                            , objRoleInfo.Sys_Type
                                            , objRoleInfo.Sort_Order
                                            , objRoleInfo.Delete_Enabled_YN);

        if (result)
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("권한등록이 성공되었습니다.", this.ICCB1, true);
        }
        else
        {
            hdfRoleRefID.Value = "";

            ltrScript.Text = JSHelper.GetAlertScript("권한등록이 실패했습니다.", false);
        }
    }

    private void UpdateViewData()
    {
        if (!this.CheckFormData()) { return; }


        Biz_RoleInfos objRoleInfo = new Biz_RoleInfos(_irole_ref_id);

     
        objRoleInfo.Role_Name = this.txtRoleName.Text.Trim();
        objRoleInfo.Role_Desc = this.txtRoleDesc.Text.Trim();
        objRoleInfo.Sys_Type = "";
        objRoleInfo.Sort_Order = DataTypeUtility.GetToInt32(this.txtSortOrder.Text.Trim());
        objRoleInfo.Delete_Enabled_YN = "Y";



        bool result = objRoleInfo.ModifyRoleInfo(objRoleInfo.Role_Ref_ID
                                           , objRoleInfo.Role_Name
                                           , objRoleInfo.Role_Desc
                                           , objRoleInfo.Sys_Type
                                           , objRoleInfo.Sort_Order
                                           , objRoleInfo.Delete_Enabled_YN);

        if (result)
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("권한수정 성공되었습니다.", this.ICCB1, true);
        }
        else
        {
            hdfRoleRefID.Value = "";

            ltrScript.Text = JSHelper.GetAlertScript("권한수정이 실패했습니다.", false);
        }
    }

    private void DeleteViewData()
    {
        if (!this.CheckFormData()) { return; }

        //this.IType = "D";

        Biz_RoleInfos objRoleInfo = new Biz_RoleInfos();

        bool result = objRoleInfo.RemoveRoleInfo(_irole_ref_id);

        if (result)
        {
            this.IType = "U";
            this.SetFormData();
            this.SetButton();

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("권한삭제가 성공되었습니다.", this.ICCB1, true);
        }
        else
        {
            hdfRoleRefID.Value = "";

            ltrScript.Text = JSHelper.GetAlertScript("권한삭제가 실패했습니다.", false);
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
