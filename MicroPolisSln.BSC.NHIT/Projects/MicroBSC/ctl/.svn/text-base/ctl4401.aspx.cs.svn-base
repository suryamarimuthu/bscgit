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

using MicroBSC.Common;
using MicroBSC.Biz.Common;

using MicroBSC.Biz.BSC.Biz;

public partial class ctl_ctl4401 : AppPageBase
{
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

    private string  _mode;
    private int     _unit_id;
    private string  _unitgroup;
    private string  _unit;
    private string  _formatstring;
    private int     _decimalpoint;
    private string  _roundingtype;
    private string  _use;
    private int     _user;

    protected void Page_Load(object sender, EventArgs e)
    {
        _mode       = Request.QueryString["MODE"];
        _unit_id    = GetRequestByInt("UNIT_ID");
        
        if (!Page.IsPostBack)
        {
            SetUnitTypeDroupDownList();

            if (_mode.Equals("MODIFY"))
            {
                SetUnitTypeInfo(_unit_id);
                
                rBtnEdit.Checked        = true;
                ddlUnitGroup.Visible    = true;
                iBtnSave.Visible        = false;
                rBtnNew.Enabled         = false;
                
            }
            else if(_mode.Equals("NEW"))
            {
                rBtnNew.Checked         = true;
                txtUnitGroup.Visible    = true;
                txtUnitGroup.Focus();
                iBtnModify.Visible      = false;
            }
        }

        if (chkUse.Checked)
            chkUse.Text = "사용";
        else
            chkUse.Text = "사용안함";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        txtDecimalPoint.Style.Add("ime-mode", "disabled");
        txtDecimalPoint.Style.Add("text-align", "right");
        txtDecimalPoint.Attributes.Add("onkeydown", "return gfChkInputNum(-1, 2)");
        iBtnSave.Attributes.Add("onClick", "return inputCheck()");
    }

    private void SetUnitTypeInfo(int unit_type_ref_id)
    {
        UnitTypeInfos unitInfo  = new UnitTypeInfos(unit_type_ref_id);
        
        ddlUnitGroup.Text       = unitInfo.Unit_Type;
        ddlUnitGroup.Enabled    = false;
        txtUnit.Text            = unitInfo.Unit;
        txtFormatString.Text    = unitInfo.Format_String;
        txtDecimalPoint.Text    = unitInfo.Decimal_Point.ToString();
        txtRoundingType.Text    = unitInfo.Rounding_Type;
        if (unitInfo.Use_Yn.Equals("Y"))
        {
            chkUse.Checked      = true;
        }
    }

    private void SetUnitTypeDroupDownList()
    {
        UnitTypeInfos unitInfo  = new UnitTypeInfos();
        DataSet ds              = unitInfo.GetUnitTypeGroup();

        ddlUnitGroup.DataSource     = ds;
        ddlUnitGroup.DataTextField  = "UNIT_TYPE";
        ddlUnitGroup.DataBind();
    }

    protected void rBtnInput_CheckedChanged(object sender, EventArgs e)
    {
        txtUnitGroup.Visible = true;
        txtUnitGroup.Focus();
        ddlUnitGroup.Visible = false;
    }

    protected void rBtnEdit_CheckedChanged(object sender, EventArgs e)
    {
        txtUnitGroup.Visible = false;
        ddlUnitGroup.Visible = true;
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        UnitTypeInfos unitInfo = new UnitTypeInfos();
        GetData();
        bool isOK = false;

        try
        {
            isOK = unitInfo.AddNewUnitTypeInfo(_unitgroup, _unit, _formatstring, _decimalpoint, _roundingtype, _use, _user);
        }
        catch(Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장 중 오류가 발생했습니다", false);
            return;
        }

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("저장 완료되었습니다",this.ICCB1, true);
        }
    }

    protected void iBtnModify_Click(object sender, ImageClickEventArgs e)
    {
        UnitTypeInfos unitInfo = new UnitTypeInfos();
        GetData();
        bool isOK = false;

        try
        {
            isOK = unitInfo.ModifyUnitTypeInfo(_unitgroup, _unit, _formatstring, _decimalpoint, _roundingtype, _use, _user, _unit_id);
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript("수정 중 오류가 발생했습니다.", false);
            return;
        }

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("수정 완료되었습니다", this.ICCB1 , true);
        }
    }

    private void GetData()
    {
        if (_mode.Equals("NEW"))
        {
            if (rBtnNew.Checked)
                _unitgroup = txtUnitGroup.Text;
            else
                _unitgroup = ddlUnitGroup.SelectedItem.ToString();
        }

        if (_mode.Equals("MODIFY"))
        {
            if (rBtnEdit.Checked)
                _unitgroup = ddlUnitGroup.SelectedItem.ToString();
            else
                _unitgroup = txtUnitGroup.Text;
        }


        _unit           = txtUnit.Text;
        _formatstring   = txtFormatString.Text;
        _decimalpoint   = Convert.ToInt32(txtDecimalPoint.Text);
        _roundingtype   = txtRoundingType.Text;

        if (chkUse.Checked)
            _use = "Y";
        else
            _use = "N";

        _user = EMP_REF_ID;
    }
}