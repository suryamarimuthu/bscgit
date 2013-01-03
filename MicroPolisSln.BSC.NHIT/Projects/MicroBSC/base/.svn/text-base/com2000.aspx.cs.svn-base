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
using System.Data.SqlClient;
using System.Text;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Biz.Common.Biz;


public partial class base_com2000 : AppPageBase
{
    int emp_ref_id = 0;

    string EN_USE_YN;
    string ENCRYPTION_ONEWAY_MODE;
    string ENCRYPTION_KEY;

    protected string IPASS_VAL_YN
    {
        get
        {
            if (ViewState["PASS_VAL_YN"] == null)
                ViewState["PASS_VAL_YN"] = "N";
            return (string)ViewState["PASS_VAL_YN"];
        }
        set
        {
            ViewState["PASS_VAL_YN"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        EN_USE_YN = WebUtility.GetConfig("ENCRYPTION_USE_YN", "N").ToUpper();
        ENCRYPTION_ONEWAY_MODE = WebUtility.GetConfig("ENCRYPTION_ONEWAY_MODE").ToUpper();
        ENCRYPTION_KEY = WebUtility.GetConfig("ENCRYPTION_KEY").ToUpper();

        SetAllTimeTop();

        if (!IsPostBack)
        {
            this.IPASS_VAL_YN = WebUtility.GetConfig("PASSWORD_VALIDATION_YN", "N");
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }
    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        emp_ref_id = ((SiteIdentity)Context.User.Identity).Emp_Ref_ID;
        EmpInfos empInfo = new EmpInfos(emp_ref_id);

        lblDeptName.Text = empInfo.Dept_Name;
        lblLoginID.Text = empInfo.LoginID;
        lblEmpName.Text = empInfo.Emp_Name;
    }

    private void InitControlValue()
    {
    }
    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {
        txtPassword.Text = "";
        txtCfmPassword.Text = "";


        emp_ref_id = ((SiteIdentity)Context.User.Identity).Emp_Ref_ID;
        EmpInfos empInfo = new EmpInfos(emp_ref_id);
        if (EN_USE_YN.Equals("Y"))
        {
            this.txtEmail.Text = DataTypeUtility.Decrypt(empInfo.Emp_Email, ENCRYPTION_KEY);
            this.txtCellPhone.Text = DataTypeUtility.Decrypt(empInfo.Cell_Phone, ENCRYPTION_KEY);
        }
        else
        {
            this.txtEmail.Text = empInfo.Emp_Email;
            this.txtCellPhone.Text = empInfo.Cell_Phone;
        }
    }
    private void SetPostBack()
    {
    }

    private void SetAllTimeBottom()
    {
        ltrScript.Text = "";
    }
    #endregion

    #region 내부 함수
    /// <summary>
    /// IsMandatory
    ///     : 필수값 체크
    /// </summary>
    /// <returns></returns>
    private bool IsMandatory(out string sErr, bool abEdit)
    {
        bool bRet = true;
        sErr = "";

        if (GetValue(txtPassword.Text) == "")
        {
            sErr = "alert('비밀번호를 알 수 없습니다!');";
            bRet = false;
        }
        else if (GetValue(txtCfmPassword) == "")
        {
            sErr = "alert('비밀번호 확인정보를 알 수 없습니다!');";
            bRet = false;
        }
        else if (GetValue(txtPassword.Text) != GetValue(txtCfmPassword.Text))
        {
            sErr = "alert('비밀번호 확인 정보가 동일하지 않습니다!');";
            bRet = false;
        }
        
        return bRet;
    }
    private void ModifyPassword(int empId)
    {
        string sErr = "";

        if (!IsMandatory(out sErr, true))
        {
            PageUtility.ExecuteScript(string.Format("{0}", sErr));
            return;
        }

        


        string pw = "";

        if(EN_USE_YN.Equals("Y"))
        {
            //pw = GetEncriptString(txtPassword.Text.ToString());
            pw = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.ToString(), ENCRYPTION_ONEWAY_MODE);
        }
        else 
        {
            pw = txtPassword.Text.ToString();
        }

        EmpInfos emp    = new EmpInfos();
        bool isOK       = emp.InitEmpPasswd(empId, pw);

        if (isOK)
            ltrScript.Text = JSHelper.GetAlertScript("비밀번호를 재설정 하였습니다.", true);
        else
            ltrScript.Text = JSHelper.GetAlertScript("비밀번호를 재설정 하는데 실패하였습니다.", false);
    }

    private string GetEncriptString(string iStr)
    {
        byte[] plainText  = new byte[16];
        byte[] cipherText = new byte[16];

        plainText         = Encoding.Unicode.GetBytes(iStr.PadRight(8, ' '));
        Encryption objEcy = new Encryption(Encryption.KeySize.Bits128, new byte[16]);
        objEcy.Cipher(plainText, cipherText);
        return (Encoding.Unicode.GetString(cipherText));
    }

    #endregion

    #region 서버 이벤트 처리 함수


    protected void ibtnSave_Click(object sender, EventArgs e)
    {
        if (this.txtPassword.Text.Length > 0)
            ModifyPassword(emp_ref_id);

        ModifyEmpInfo();
    }
    protected void ModifyEmpInfo()
    {
        string cell_phone = this.txtCellPhone.Text;
        string emp_email = this.txtEmail.Text;

        MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Info bizEmpInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Info();
        bool result = bizEmpInfo.Modify_Emp_Info(gUserInfo.Emp_Ref_ID, emp_email, cell_phone, gUserInfo.Emp_Ref_ID);

        if (result)
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("변경된 정보를 저장하였습니다.");
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("정보를 저장하는 도중 오류가 발생했습니다.");
        }
    }


    protected void ibtnTEST_Click(object sender, EventArgs e)
    {
        
    }
    #endregion
}
