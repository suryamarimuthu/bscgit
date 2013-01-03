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
using System.Text;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Biz.BSC.Biz;

public partial class ctl_ctl2100_1 : AppPageBase
{
    const string DEFAULT_PASS = "1111"; // 기본 패스워드

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

    public string mode
    {
        get
        {
            if (ViewState["mode"] == null)
            {
                ViewState["mode"] = GetRequest("mode", "");
            }

            return (string)ViewState["mode"];
        }
        set
        {
            ViewState["mode"] = value;
        }
    }

    public string empId
    {
        get
        {
            if (ViewState["empId"] == null)
            {
                ViewState["empId"] = GetRequest("empId", "");
            }

            return (string)ViewState["empId"];
        }
        set
        {
            ViewState["empId"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
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
            ltrScript.Text = "";
        }

        private void InitControlValue()
        {
        }

        private void InitControlEvent()
        {
            fileSign.Attributes.Add("onchange", "uploadImg_Change( this.value );");
            fileStamp.Attributes.Add("onchange", "uploadImg_Change( this.value );");
            iBtnSave.Attributes.Add("onclick", "return confirm('현재의 사원정보를 저장하시겠습니까?')");
        }

        private void SetPageData()
        {
           
            if (mode.ToUpper() == "NEW")
            {
                InitEmp();
            }
            else if (mode.ToUpper() == "MODIFY")
            {
//                ViewEmp(int.Parse(Request["empId"]));
                ViewEmp(Convert.ToInt32(empId));
            }

            Callback1.Content.Controls.Add(ltrScript);
        }

        private void SetPostBack()
        {

        }

        private void SetAllTimeBottom()
        {
            
        }
    #endregion

    #region 내부함수
        private void ViewEmp(int empId)
        {

            iBtnSave.ImageUrl = "../images/btn/b_002.gif";

            EmpInfos emp = new EmpInfos(empId);


            string en_use_yn = WebUtility.GetConfig("ENCRYPTION_USE_YN").ToUpper();
            string encryption_key = WebUtility.GetConfig("ENCRYPTION_KEY").ToUpper();


            string emp_email;
            string emp_cellphone;

            


            //WebCommon.SetPositionDutyDropDownList(ddlPositionDuty, false);
            //WebCommon.SetPositionClassDropDownList(ddlPositionClass, false);
            //WebCommon.SetPositionGrpDropDownList(ddlPositionGrp, false);
            //WebCommon.SetPositionRankDropDownList(ddlPositionRank, false);

            //ddlPositionClass.Items.FindByValue(emp.Position_class_code).Selected = true;
            //ddlPositionDuty.Items.FindByValue(emp.Position_duty_code).Selected = true;
            //PageUtility.FindByValueDropDownList(ddlPositionGrp, emp.Position_grp_code);
            //ddlPositionRank.Items.FindByValue(emp.Position_rank_code).Selected = true;

            DropDownListCommom.BindPositionClass(ddlPositionClass);
            DropDownListCommom.BindPositionDuty(ddlPositionDuty);
            DropDownListCommom.BindPositionGroup(ddlPositionGrp);
            DropDownListCommom.BindPositionRank(ddlPositionRank);
            DropDownListCommom.BindPositionKind(ddlPositionKind);

            WebUtility.FindByValueDropDownList(ddlPositionClass, emp.Position_class_code);
            WebUtility.FindByValueDropDownList(ddlPositionClass, emp.Position_class_code);
            WebUtility.FindByValueDropDownList(ddlPositionDuty, emp.Position_duty_code);
            WebUtility.FindByValueDropDownList(ddlPositionGrp, emp.Position_grp_code);
            WebUtility.FindByValueDropDownList(ddlPositionRank, emp.Position_rank_code);
            WebUtility.FindByValueDropDownList(ddlPositionKind, emp.Position_Kind_Code);



            if (en_use_yn.Equals("Y"))
            {
                emp_email = DataTypeUtility.Decrypt(emp.Emp_Email, encryption_key);
                emp_cellphone = DataTypeUtility.Decrypt(emp.Cell_Phone, encryption_key);
            }
            else
            {
                emp_email = emp.Emp_Email;
                emp_cellphone = emp.Cell_Phone;
            }




            hfPrevDeptID.Value  = emp.Dept_Ref_ID.ToString();
            txtDeptID.Text      = emp.Dept_Ref_ID.ToString();
            txtLoginID.Text     = emp.LoginID;
            txtLoginIP.Text     = emp.LoginIP;
            txtName.Text        = emp.Emp_Name;
            txtDaily.Text       = emp.Daily_Phone;

            txtEmail.Text       = emp_email;
            txtCell.Text        = emp_cellphone;



            txtZipcode1.Text = ((emp.ZipCode == null) || emp.ZipCode.Trim().Equals("")) ? "": emp.ZipCode.Substring(0, 3);
            txtZipcode2.Text = ((emp.ZipCode == null) || emp.ZipCode.Trim().Equals("")) ? "": emp.ZipCode.Substring(3, 3);


            //txtZipcode1.Text = (emp.ZipCode.Trim().Equals("")) ? emp.ZipCode.Substring(0, 3) : "";
            //txtZipcode2.Text = (!emp.ZipCode.Trim().Equals("")) ? emp.ZipCode.Substring(2, 3) : "";
            txtAddr1.Text       = emp.Addr_1;
            txtAddr2.Text       = emp.Addr_2;
            txtDeptName.Text    = emp.Dept_Name;

            if (emp.Position_duty_code == null)
            {
                WebUtility.FindByValueDropDownList(ddlPositionClass, "99");
                WebUtility.FindByValueDropDownList(ddlPositionDuty, "99");
                WebUtility.FindByValueDropDownList(ddlPositionGrp, "99");
                WebUtility.FindByValueDropDownList(ddlPositionRank, "99");
            }
            else
            {
                //ddlPositionDuty.Items.FindByValue(emp.Position_duty_code).Selected = true;
                //ddlPositionRank.Items.FindByValue(emp.Position_duty_code).Selected = true;
                //ddlPositionClass.Items.FindByValue(emp.Position_duty_code).Selected = true;
            }
        }

        /// <summary>
        /// IsMandatory
        ///     : 필수값 체크
        /// </summary>
        /// <returns></returns>
        private bool IsMandatory(out string sErr, bool abEdit)
        {
            bool bRet = true;
            sErr = "";

            if (abEdit)
            {
                //if (TypeUtility.GetNumString(GetRequest("empid")) == "")
                if (TypeUtility.GetNumString(empId) == "")
                {
                    sErr = "alert('수정정보를 정확히 알 수 없습니다.\n\n다시 시도해 주십시요.');";
                    bRet = false;
                }
            }

            if (GetValue(txtDeptID.Text) == "")
            {
                sErr = "alert('[부서]를 알 수 없습니다.');";
                bRet = false;
            }
            else if (GetValue(txtDeptName.Text) == "")
            {
                sErr = "alert('[부서]를 알 수 없습니다.');";
                bRet = false;
            }
            else if (GetValue(txtLoginID.Text) == "")
            {
                sErr = "alert('[사용자아이디]를 알 수 없습니다.');"
                     + "try {eval(document.forms[0]." + txtLoginID.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + txtLoginID.ClientID + ".select());} catch(e){}";

                bRet = false;
            }
            else if (GetValue(txtName.Text) == "")
            {
                sErr = "alert('[사용자명]을 알 수 없습니다.');"
                     + "try {eval(document.forms[0]." + txtName.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + txtName.ClientID + ".select());} catch(e){}";
                                    
                bRet = false;
            }
            else if (PageUtility.GetByValueDropDownList(ddlPositionDuty) == "0")
            {
                sErr = "alert('[직책]을 선택하십시요.');"
                     + "try {eval(document.forms[0]." + ddlPositionDuty.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + ddlPositionDuty.ClientID + ".select());} catch(e){}";
                                    
                bRet = false;
            }
            else if (PageUtility.GetByValueDropDownList(ddlPositionRank) == "0")
            {
                sErr = "alert('[직위]를 선택하십시요.');"
                     + "try {eval(document.forms[0]." + ddlPositionRank.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + ddlPositionRank.ClientID + ".select());} catch(e){}";

                bRet = false;
            }
            else if (PageUtility.GetByValueDropDownList(ddlPositionGrp) == "0")
            {
                sErr = "alert('[직군]를 선택하십시요.');"
                     + "try {eval(document.forms[0]." + ddlPositionGrp.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + ddlPositionGrp.ClientID + ".select());} catch(e){}";

                bRet = false;
            }
            else if (PageUtility.GetByValueDropDownList(ddlPositionClass) == "0")
            {
                sErr = "alert('[직급]을 선택하십시요.');"
                     + "try {eval(document.forms[0]." + ddlPositionClass.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + ddlPositionClass.ClientID + ".select());} catch(e){}";

                bRet = false;
            }
            else if (PageUtility.GetByValueDropDownList(ddlPositionKind) == "0")
            {
                sErr = "alert('[직종]을 선택하십시요.');"
                     + "try {eval(document.forms[0]." + ddlPositionKind.ClientID + ".select());} catch(e){}"
                     + "try {eval(document.forms[0]." + ddlPositionKind.ClientID + ".select());} catch(e){}";

                bRet = false;
            }

            // 추가일 경우에는 아이디의 중복확인을 처리한다.
            if (mode.ToUpper() == "NEW")
            {
                EmpInfos emp = new EmpInfos();

                if (!emp.CheckLoginID(GetValue(txtLoginID.Text)))
                {
                    sErr = "alert('입력하신 [사용자아이디]는 이미 존재합니다.');"
                         + "try {eval(document.forms[0]." + txtLoginID.ClientID + ".select());} catch(e){}"
                         + "try {eval(document.forms[0]." + txtLoginID.ClientID + ".select());} catch(e){}";

                    bRet = false;
                }
            }

            return bRet;
        }

        private void InitEmp()
        {
            string sDeptID = TypeUtility.GetNumString(GetRequest("deptid"));

            if (sDeptID == "")
            {
                PageUtility.ExecuteScript("alert('부서정보를 알 수 없습니다.\n\n다시 시도해 주십시요.');gfCloseWindow();");
                return;
            }

            DeptInfos oDept = new DeptInfos(Convert.ToInt32(sDeptID));

            DropDownListCommom.BindPositionDuty(ddlPositionDuty, true);
            DropDownListCommom.BindPositionClass(ddlPositionClass, true);
            DropDownListCommom.BindPositionGroup(ddlPositionGrp, true);
            DropDownListCommom.BindPositionRank(ddlPositionRank, true);
            DropDownListCommom.BindPositionKind(ddlPositionKind, true);

            txtDeptID.Text      = oDept.Dept_Ref_ID.ToString();
            txtDeptName.Text    = oDept.Dept_Name;

            ltrCheckLoginID.Text = "[중복확인]";
            iBtnSave.ImageUrl = "../images/btn/b_156.gif";

            // 패스워드 초기화하는 부분 감춤
            iBtnInitPasswd.Visible = false;
        }

        private void ModifyEmp(int empId)
        {
            Biz_ctl_ctl2101 biz = new Biz_ctl_ctl2101();

            string en_use_yn = WebUtility.GetConfig("ENCRYPTION_USE_YN").ToUpper();
            string encryption_key = WebUtility.GetConfig("ENCRYPTION_KEY").ToUpper();


            string emp_email;
            string emp_cellphone;

            if (en_use_yn.Equals("Y"))
            {
                emp_email = DataTypeUtility.Encrypt(GetValue(txtEmail.Text), encryption_key);
                emp_cellphone = DataTypeUtility.Encrypt(GetValue(txtCell.Text), encryption_key);
            }
            else
            {
                emp_email = GetValue(txtEmail.Text);
                emp_cellphone = GetValue(txtCell.Text);
            }



            int iRet = biz.EditEmpInfo(
                                        Convert.ToInt32(GetValue(hfPrevDeptID.Value))
                                      , Convert.ToInt32(GetRequest("txtDeptID"))
                                      , Convert.ToInt32(empId)
                                      , GetValue(txtLoginID.Text)
                                      , GetValue(txtLoginIP.Text)
                                      , GetValue(txtName.Text)
                                      , PageUtility.GetByValueDropDownList(ddlPositionClass)
                                      , PageUtility.GetByValueDropDownList(ddlPositionGrp)
                                      , PageUtility.GetByValueDropDownList(ddlPositionRank)
                                      , PageUtility.GetByValueDropDownList(ddlPositionDuty)
                                      , "-1"
                                      , PageUtility.GetByValueDropDownList(ddlPositionKind)
                                      , emp_email
                                      , GetValue(txtDaily.Text)
                                      , emp_cellphone
                                      , GetValue(txtFax.Text)
                                      , 0
                                      , GetValue(Utils.GetZipCode(txtZipcode1.Text, txtZipcode2.Text))
                                      , GetValue(txtAddr1.Text)
                                      , GetValue(txtAddr2.Text)
                                      , Utils.UploadFile(fileSign.Value, "EmpInfo.UploadImages.Sign")
                                      , Utils.UploadFile(fileStamp.Value, "EmpInfo.UploadImages.Stamp")
                                      , 0
                                      , 0
                                      , 0
                                      , gUserInfo.Emp_Ref_ID
                                      );
        }

        private void NewEmp()
        {
            string en_use_yn = WebUtility.GetConfig("ENCRYPTION_USE_YN").ToUpper();
            string encryption_oneway_mode = WebUtility.GetConfig("ENCRYPTION_ONEWAY_MODE").ToUpper();

            string encryption_key = WebUtility.GetConfig("ENCRYPTION_KEY").ToUpper();


            string pw = "";
            string emp_email;
            string emp_cellphone;

            if(en_use_yn.Equals("Y"))
            {
                //pw = GetEncriptString(DEFAULT_PASS);
                pw = FormsAuthentication.HashPasswordForStoringInConfigFile(DEFAULT_PASS, encryption_oneway_mode);
                emp_email = DataTypeUtility.Encrypt(GetValue(txtEmail.Text), encryption_key);
                emp_cellphone = DataTypeUtility.Encrypt(GetValue(txtCell.Text), encryption_key);
            }
            else 
            {
                pw = DEFAULT_PASS;
                emp_email = GetValue(txtEmail.Text);
                emp_cellphone = GetValue(txtCell.Text);
            }

            Biz_ctl_ctl2101 biz = new Biz_ctl_ctl2101();

            int iRet = biz.AddEmpInfo(
                                        Convert.ToInt32(GetRequest("txtDeptID"))
                                      , GetValue(txtLoginID.Text)
                                      , GetValue(txtLoginIP.Text)
                                      , pw
                                      , GetValue(txtName.Text)
                                      , PageUtility.GetByValueDropDownList(ddlPositionClass)
                                      , PageUtility.GetByValueDropDownList(ddlPositionGrp)
                                      , PageUtility.GetByValueDropDownList(ddlPositionRank)
                                      , PageUtility.GetByValueDropDownList(ddlPositionDuty)
                                      , "-1"
                                      , PageUtility.GetByValueDropDownList(ddlPositionKind)
                                      , emp_email
                                      , GetValue(txtDaily.Text)
                                      , emp_cellphone
                                      , GetValue(txtFax.Text)
                                      , 0
                                      , GetValue(Utils.GetZipCode(txtZipcode1.Text, txtZipcode2.Text))
                                      , GetValue(txtAddr1.Text)
                                      , GetValue(txtAddr2.Text)
                                      , Utils.UploadFile(fileSign.Value, "EmpInfo.UploadImages.Sign")
                                      , Utils.UploadFile(fileStamp.Value, "EmpInfo.UploadImages.Stamp")
                                      , 0
                                      , gUserInfo.Emp_Ref_ID
                                      , 0
                                      , 0
                                      );

        }
    #endregion

    #region 서버 이벤트 처리 함수

        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
          
            string sErr = "";
            if (!IsMandatory(out sErr, false))
            {
                PageUtility.ExecuteScript(string.Format("{0}", sErr));
                return;
            }

            //bool returnVal = Utils.FileExtensionValidator(fileSign.PostedFile);
            if (mode.ToUpper() == "NEW")
            {
                if (Utils.FileExtensionValidator(fileSign.PostedFile) && Utils.FileExtensionValidator(fileStamp.PostedFile))
                {
                    NewEmp();
                }
                else
                {
                    ltrScript.Text = JSHelper.GetAlertScript("유효하지 않은 파일입니다.");
                }
            }
            else if (mode.ToUpper() == "MODIFY")
            {
                if (Utils.FileExtensionValidator(fileSign.PostedFile) && Utils.FileExtensionValidator(fileStamp.PostedFile))
                {
                    ModifyEmp(Convert.ToInt32(empId));
                }
                else
                {
                    ltrScript.Text = JSHelper.GetAlertScript("유효하지 않은 파일입니다.");
                }
            }

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 저장되었습니다.", this.ICCB1, true);
        }
        protected void Callback1_Callback(object sender, SJ.Web.UI.CallBackEventArgs e)
        {
            EmpInfos emp = new EmpInfos();

            if (e.Parameter == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("아이디를 입력하십시요.", false);
                ltrScript.RenderControl(e.Output);
                return;
            }

            if (emp.CheckLoginID(e.Parameter))
                ltrScript.Text = JSHelper.GetAlertScript("사용 가능한 아이디 입니다.", false);
            else
                ltrScript.Text = JSHelper.GetAlertScript("존재하는 아이디 입니다.", false);

            ltrScript.RenderControl(e.Output);
        }
        protected void iBtnInitPasswd_Click(object sender, ImageClickEventArgs e)
        {
            EmpInfos emp = new EmpInfos();

            string en_use_yn = WebUtility.GetConfig("ENCRYPTION_USE_YN").ToUpper();
            string encryption_oneway_mode = WebUtility.GetConfig("ENCRYPTION_ONEWAY_MODE").ToUpper();


            //bool isOK = emp.InitEmpPasswd(int.Parse(Request["empId"]), GetEncriptString(DEFAULT_PASS)); // 패스워드 암호화
            
            
            string encDEFAULT_PASS;
            if (en_use_yn.Equals("Y"))
                encDEFAULT_PASS = FormsAuthentication.HashPasswordForStoringInConfigFile(DEFAULT_PASS, encryption_oneway_mode);
            else
                encDEFAULT_PASS = DEFAULT_PASS;


            bool isOK = emp.InitEmpPasswd(Convert.ToInt32(empId), encDEFAULT_PASS);

            if (isOK)
                Literal1.Text = JSHelper.GetAlertScript("패스워드를 초기화 하였습니다.", false);
            else
                Literal1.Text = JSHelper.GetAlertScript("패스워드를 초기화 하는데 실패하였습니다.", false);
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

    
}
