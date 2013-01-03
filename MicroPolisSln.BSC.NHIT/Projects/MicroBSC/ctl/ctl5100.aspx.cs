using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ctl_ctl5100 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DoSaving();
    }

    private void DoSaving()
    {
        MicroBSC.Biz.Common.CodeInfos bizCodes = new MicroBSC.Biz.Common.CodeInfos();
        object[,] objSave = new object[24, 3];

        objSave[0, 0] = "GS_OSF_ALLSIGNAL";
        objSave[0, 1] = "조직상황판의 시그널을 당월, 누적 모두 보여줄 것인지";
        objSave[0, 2] = rbOSF_ALLSIGNAL.SelectedItem.Value;
        objSave[1, 0] = "GS_OSF_BACKGROUNDIMAGE";
        objSave[1, 1] = "조직상황판 백그라운드이미지";
        objSave[1, 2] = ddlOSF_BACKGROUNDIMAGE.SelectedItem.Value;
        objSave[2, 0] = "GS_OSF_IMAGESET";
        objSave[2, 1] = "조직상황판 시그널 이미지셋";
        objSave[2, 2] = ddlOSF_IMAGESET.SelectedItem.Value;

        objSave[3, 0] = "GS_IMG_MENULOGO";
        objSave[3, 1] = "상단 메뉴로고";
        objSave[3, 2] = txtIMG_MENULOGO.Text.Trim();
        objSave[4, 0] = "GS_IMG_COPYLOGO";
        objSave[4, 1] = "하단 카피로고";
        objSave[4, 2] = txtIMG_COPYLOGO.Text.Trim();
        objSave[5, 0] = "GS_IMG_LOGINLOGO";
        objSave[5, 1] = "로그인페이지 로고";
        objSave[5, 2] = txtIMG_LOGINLOGO.Text.Trim();

        objSave[6, 0] = "GS_DBT_OLAPSERVER";
        objSave[6, 1] = "OLAP SEVER 설정";
        objSave[6, 2] = txtDBT_OLAPSERVER.Text.Trim();

        objSave[7, 0] = "GS_SSO_USEYN";
        objSave[7, 1] = "Single Sign On 사용여부 (Yes:사용/ No:미사용/ Each:회사별로그인페이지)";
        objSave[7, 2] = rbSSO_USEYN.SelectedItem.Value;
        objSave[8, 0] = "GS_SSO_DEFAULTPAGEURL";
        objSave[8, 1] = "Default Page URL";
        objSave[8, 2] = txtSSO_DEFAULTPAGEURL.Text.Trim();
        objSave[9, 0] = "GS_SSO_SERVERCHECKYN";
        objSave[9, 1] = "Single Sign On Server 체크 여부 (Y:체크/ N:미체크)";
        objSave[9, 2] = rbSSO_SERVERCHECKYN.SelectedItem.Value;
        objSave[10, 0] = "GS_SSO_IDPWDCONFIRMYN";
        objSave[10, 1] = "Yes:아이디만 인증/ No:아이디, 패스워드 모두인증";
        objSave[10, 2] = rbSSO_IDPWDCONFIRMYN.SelectedItem.Value;

        objSave[11, 0] = "GS_FLS_S";
        objSave[11, 1] = "File Size - S:5M";
        objSave[11, 2] = txtFLS_S.Text.Trim();
        objSave[12, 0] = "GS_FLS_M";
        objSave[12, 1] = "File Size - M:10M";
        objSave[12, 2] = txtFLS_M.Text.Trim();
        objSave[13, 0] = "GS_FLS_L";
        objSave[13, 1] = "File Size - L:20M";
        objSave[13, 2] = txtFLS_L.Text.Trim();

        objSave[14, 0] = "GS_IFC_EMP";
        objSave[14, 1] = "인사정보(기간계 연동)";
        objSave[14, 2] = txtIFC_EMP.Text.Trim();
        objSave[15, 0] = "GS_IFC_DEPT";
        objSave[15, 1] = "부서정보(기간계 연동)";
        objSave[15, 2] = txtIFC_DEPT.Text.Trim();

        objSave[16, 0] = "GS_PWD_ENCRYPTYN";
        objSave[16, 1] = "패스워드 암호화 사용여부";
        objSave[16, 2] = rbPWD_ENCRYPTYN.SelectedItem.Value;
        objSave[17, 0] = "GS_PWD_VALIDATEYN";
        objSave[17, 1] = "비밀번호 유효성검사여부";
        objSave[17, 2] = rbPWD_VALIDATEYN.SelectedItem.Value;

        objSave[18, 0] = "GS_APP_EXTERNALYN";
        objSave[18, 1] = "결재처리의 외부위임";
        objSave[18, 2] = rbAPP_EXTERNALYN.SelectedItem.Value;
        objSave[19, 0] = "GS_APP_SELFYN";
        objSave[19, 1] = "자가결재 사용안함여부 Y=사용안함 N=사용함";
        objSave[19, 2] = rbAPP_SELFYN.SelectedItem.Value;
        objSave[20, 0] = "GS_APP_HISTORYYN";
        objSave[20, 1] = "결재선변경이력관리 사용여부";
        objSave[20, 2] = rbAPP_HISTORYYN.SelectedItem.Value;

        objSave[21, 0] = "GS_ETC_DEFAULTPAGE";
        objSave[21, 1] = "로그인 초기화면(1:종합DASH BOARD, 2:종합평정결과분석, 3:조직상황판, 4:전략체계도, 5:시스템경고화면(경동))";
        objSave[21, 2] = rbETC_DEFAULTPAGE.SelectedItem.Value;
        objSave[22, 0] = "GS_ETC_FCKEDITORPATH";
        objSave[22, 1] = "FCKEDITORPATH";
        objSave[22, 2] = txtETC_FCKEDITORPATH.Text.Trim();
        objSave[23, 0] = "GS_ETC_WORKMAPYN";
        objSave[23, 1] = "과제맵으로 가기 사용 유무";
        objSave[23, 2] = rbETC_WORKMAPYN.SelectedItem.Value;

        if (bizCodes.SaveGeneralSetup(objSave))
            ltrScript.Text = JSHelper.GetAlertScript("설정하였습니다.");
        else
            ltrScript.Text = JSHelper.GetAlertScript("설정이 실패하였습니다!");
    }

    private void DoBinding()
    {
        MicroBSC.Biz.Common.CodeInfos bizCodes = new MicroBSC.Biz.Common.CodeInfos();
        DataTable dtSetup = bizCodes.GetGeneralSetup();

        foreach (DataRow drSetup in dtSetup.Rows)
        {
            switch (drSetup["GENERALKEY"].ToString())
            {
                #region 조직상황판
                //조직상황판ORIGANIZATION SIGNAL FRAME
                case "GS_OSF_ALLSIGNAL": //당월/누적 시그널 모두 보기
                    PageUtility.FindByValueRadioButtonList(rbOSF_ALLSIGNAL, drSetup["VALUE"].ToString());
                    break;
                case "GS_OSF_BACKGROUNDIMAGE": //배경이미지
                    PageUtility.FindByValueDropDownList(ddlOSF_BACKGROUNDIMAGE, drSetup["VALUE"].ToString());
                    break;
                case "GS_OSF_IMAGESET": //시그널이미지 세트
                    PageUtility.FindByValueDropDownList(ddlOSF_IMAGESET, drSetup["VALUE"].ToString());
                    break;
                #endregion
                #region 이미지설정
                //이미지설정
                case "GS_IMG_MENULOGO": //상단 메뉴 LOGO
                    txtIMG_MENULOGO.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_IMG_COPYLOGO": //하단 카피 LOGO
                    txtIMG_COPYLOGO.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_IMG_LOGINLOGO": //로그인페이지 LOGO
                    txtIMG_LOGINLOGO.Text = drSetup["VALUE"].ToString();
                    break;
                #endregion
                #region DB 유형
                //DB 유형
                case "GS_DBT_OLAPSERVER": //OLAP Server
                    txtDBT_OLAPSERVER.Text = drSetup["VALUE"].ToString();
                    break;
                //case "GS_DBT_PROVIDERTYPE": //DB Provider Type
                //    PageUtility.FindByValueRadioButtonList(rbDBT_PROVIDERTYPE, drSetup["VALUE"].ToString());
                //    break;
                #endregion
                #region DB SSO
                //DB SSO
                case "GS_SSO_USEYN": //Single Sign On 사용여부
                    PageUtility.FindByValueRadioButtonList(rbSSO_USEYN, drSetup["VALUE"].ToString());
                    break;
                case "GS_SSO_DEFAULTPAGEURL": //Default Page URL
                    txtSSO_DEFAULTPAGEURL.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_SSO_SERVERCHECKYN": //Single Sign On Server 체크여부
                    PageUtility.FindByValueRadioButtonList(rbSSO_SERVERCHECKYN, drSetup["VALUE"].ToString());
                    break;
                case "GS_SSO_IDPWDCONFIRMYN": //ID/PWD 인증여부
                    PageUtility.FindByValueRadioButtonList(rbSSO_IDPWDCONFIRMYN, drSetup["VALUE"].ToString());
                    break;
                #endregion
                #region 첨부파일
                //첨부파일
                case "GS_FLS_S": //File Size [S:5M]
                    txtFLS_S.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_FLS_M": //File Size [S:5M]
                    txtFLS_M.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_FLS_L": //File Size [S:5M]
                    txtFLS_L.Text = drSetup["VALUE"].ToString();
                    break;
                #endregion
                #region 부서정보 연동
                //부서정보 연동
                case "GS_IFC_EMP": //인사정보 Table [기간계 연동]
                    txtIFC_EMP.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_IFC_DEPT": //부서정보 Table [기간계 연동]
                    txtIFC_DEPT.Text = drSetup["VALUE"].ToString();
                    break;
                #endregion
                #region 패스워드
                //패스워드
                case "GS_PWD_ENCRYPTYN": //패스워드 암호화 사용여부
                    PageUtility.FindByValueRadioButtonList(rbPWD_ENCRYPTYN, drSetup["VALUE"].ToString());
                    break;
                case "GS_PWD_VALIDATEYN": //패스워드 유효성 검사여부
                    PageUtility.FindByValueRadioButtonList(rbPWD_VALIDATEYN, drSetup["VALUE"].ToString());
                    break;
                #endregion
                #region 결재
                //결재
                case "GS_APP_EXTERNALYN": //결재처리 외부위임
                    PageUtility.FindByValueRadioButtonList(rbAPP_EXTERNALYN, drSetup["VALUE"].ToString());
                    break;
                case "GS_APP_SELFYN": //자가결재 사용여부
                    PageUtility.FindByValueRadioButtonList(rbAPP_SELFYN, drSetup["VALUE"].ToString());
                    break;
                case "GS_APP_HISTORYYN": //결재선변경 이력관리 사용여부
                    PageUtility.FindByValueRadioButtonList(rbAPP_HISTORYYN, drSetup["VALUE"].ToString());
                    break;
                #endregion
                #region 기타
                //기타
                case "GS_ETC_DEFAULTPAGE": //로그인 초기화면
                    PageUtility.FindByValueRadioButtonList(rbETC_DEFAULTPAGE, drSetup["VALUE"].ToString());
                    break;
                case "GS_ETC_FCKEDITORPATH": //FCKEditor User Files Path
                    txtETC_FCKEDITORPATH.Text = drSetup["VALUE"].ToString();
                    break;
                case "GS_ETC_WORKMAPYN": //과제맵 바로가기 사용여부
                    PageUtility.FindByValueRadioButtonList(rbETC_WORKMAPYN, drSetup["VALUE"].ToString());
                    break;
                #endregion
            }
        }
        
    }

    private void DoInitControl()
    {
        //조직상황판
        RadioButtonListCommom.BindYN(rbOSF_ALLSIGNAL);
        rbOSF_ALLSIGNAL.Items[rbOSF_ALLSIGNAL.SelectedIndex].Selected = false;
        for (int i = 1; i < 20; i++)
            ddlOSF_BACKGROUNDIMAGE.Items.Insert(i - 1, new ListItem(i.ToString(), "../images/org/bg_org_" + i.ToString() + ".jpg"));
        ddlOSF_BACKGROUNDIMAGE.SelectedIndex = ddlOSF_BACKGROUNDIMAGE.Items.Count - 1;
        for (int i = 1; i < 4; i++)
            ddlOSF_IMAGESET.Items.Insert(i - 1, new ListItem(i.ToString(), "../images/org/signal_set" + i.ToString() + (i == 2 ? "/icon_ania.gif" : "/icon_a.gif")));

        //이미지설정
        //txtIMG_MENULOGO.Text = "../images/logo/logo.gif";
        //txtIMG_COPYLOGO.Text = "../images/logo/copy.gif";
        //txtIMG_LOGINLOGO.Text = "../images/login/login.gif";

        //DB 유형
        //txtDBT_OLAPSERVER.Text = "192.168.1.1";
        //rbDBT_PROVIDERTYPE.Items.Insert(0, new ListItem("MSSQL", "MSSQL"));
        //rbDBT_PROVIDERTYPE.Items.Insert(1, new ListItem("ORACLE", "ORACLE"));
        //rbDBT_PROVIDERTYPE.Items.Insert(2, new ListItem("OLEDB", "OLEDB"));
        //rbDBT_PROVIDERTYPE.SelectedIndex = 0;

        //SSO
        rbSSO_USEYN.Items.Insert(0, new ListItem("예", "Y"));
        rbSSO_USEYN.Items.Insert(1, new ListItem("아니오", "N"));
        rbSSO_USEYN.Items.Insert(2, new ListItem("회사별", "E"));
        //rbSSO_USEYN.SelectedIndex = 1;
        //txtSSO_DEFAULTPAGEURL.Text = "~/base/login.aspx";
        rbSSO_SERVERCHECKYN.Items.Insert(0, new ListItem("체크", "Y"));
        rbSSO_SERVERCHECKYN.Items.Insert(1, new ListItem("미체크", "N"));
        //rbSSO_SERVERCHECKYN.SelectedIndex = 1;
        rbSSO_IDPWDCONFIRMYN.Items.Insert(0, new ListItem("ID만 인증", "Y"));
        rbSSO_IDPWDCONFIRMYN.Items.Insert(1, new ListItem("ID,PWD 모두 인증", "Y"));
        //rbSSO_IDPWDCONFIRMYN.SelectedIndex = 1;

        //첨부파일
        TextBoxCommon.SetOnlyInteger(txtFLS_S);
        TextBoxCommon.SetOnlyInteger(txtFLS_M);
        TextBoxCommon.SetOnlyInteger(txtFLS_L);
        //txtFLS_S.Text = "5120";
        //txtFLS_M.Text = "10240";
        //txtFLS_L.Text = "20480";

        //패스워드
        rbPWD_ENCRYPTYN.Items.Insert(0, new ListItem("예", "Y"));
        rbPWD_ENCRYPTYN.Items.Insert(1, new ListItem("아니오", "N"));
        //rbPWD_ENCRYPTYN.SelectedIndex = 1;
        rbPWD_VALIDATEYN.Items.Insert(0, new ListItem("예", "Y"));
        rbPWD_VALIDATEYN.Items.Insert(1, new ListItem("아니오", "N"));
        //rbPWD_VALIDATEYN.SelectedIndex = 1;

        //결재
        rbAPP_EXTERNALYN.Items.Insert(0, new ListItem("사용함", "Y"));
        rbAPP_EXTERNALYN.Items.Insert(1, new ListItem("사용안함", "N"));
        //rbAPP_EXTERNALYN.SelectedIndex = 1;
        rbAPP_SELFYN.Items.Insert(0, new ListItem("사용함", "N"));
        rbAPP_SELFYN.Items.Insert(1, new ListItem("사용안함", "Y"));
        //rbAPP_SELFYN.SelectedIndex = 1;
        rbAPP_HISTORYYN.Items.Insert(0, new ListItem("사용함", "Y"));
        rbAPP_HISTORYYN.Items.Insert(1, new ListItem("사용안함", "N"));
        //rbAPP_HISTORYYN.SelectedIndex = 1;

        //기타
        //1:종합DASH BOARD, 2:종합평정결과분석, 3:조직상황판, 4:전략체계도, 5:시스템경고화면(경동)
        rbETC_DEFAULTPAGE.Items.Insert(0, new ListItem("종합DASHBOARD", "1"));
        rbETC_DEFAULTPAGE.Items.Insert(1, new ListItem("종합평정결과분석", "2"));
        rbETC_DEFAULTPAGE.Items.Insert(2, new ListItem("조직상황판", "3"));
        rbETC_DEFAULTPAGE.Items.Insert(3, new ListItem("전략체계도", "4"));
        rbETC_DEFAULTPAGE.Items.Insert(4, new ListItem("시스템경고화면(경동)", "5"));
        //rbETC_DEFAULTPAGE.SelectedIndex = 3;
        //txtETC_FCKEDITORPATH.Text = "/Wherever/Directory/";
        rbETC_WORKMAPYN.Items.Insert(0, new ListItem("예", "Y"));
        rbETC_WORKMAPYN.Items.Insert(1, new ListItem("아니오", "N"));
        //rbETC_WORKMAPYN.SelectedIndex = 1;
    }
}
