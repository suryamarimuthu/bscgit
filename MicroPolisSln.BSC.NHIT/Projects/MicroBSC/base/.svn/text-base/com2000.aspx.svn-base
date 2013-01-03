<%@ Page Language="C#" AutoEventWireup="true" CodeFile="com2000.aspx.cs" Inherits="base_com2000" %>


<html>
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html; " />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    function ValidatePass() {
        if ('<%= this.IPASS_VAL_YN %>' == 'Y') {
            var passText = document.getElementById('txtPassword').value;
            
            if (passText.length > 0) {
                //1 특수문자, 숫자, 문자 3중 2이상으로 결합
                var chk1 = /[a-z]/i;
                var chk2 = /\d/;
                var chk3 = /[~!@\#$%^&*\()\=+_']/gi;
                if (!chk1.test(passText)) {
                    alert('[알파벳+숫자] [알파벳+특수문자] [알파벳+숫자+특수문자]로 조합할 수 있습니다.');
                    return false;
                }
                if (!chk2.test(passText) && !chk3.test(passText)) {
                    alert('알파벳+숫자 혹은 알파벳+특수문자 혹은 알파벳+숫자+특수문자로 조합할 수 있습니다.');
                    return false;
                }
                //2 특수문자나 숫자로 시작할 수 없음
                if (!passText.substr(0, 1).match('^[a-zA-Z]')) {
                    alert('숫자나 특수문자가 먼저 올 수 없습니다.');
                    return false;
                }
                //3 7~12자리수
                if (passText.length < 7 || passText.length > 12) {
                    alert('7자리 이상 12자리 이하로 설정할 수 있습니다.');
                    return false;
                }
                //5 아이디와 동일여부
                if (passText.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '') == document.getElementById('lblLoginID').innerText.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '')) {
                    alert('비밀번호는 아이디와 동일할 수 없습니다.');
                    return false;
                }
                //6 특수문자 &, =, ? 사용불가
                if (passText.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '').match('=')
            || passText.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '').match('&')
            || passText.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '').match(eval(/\?/gi))) {
                    alert('특수문자 [&, =, ?]는 사용할 수 없습니다.');
                    return false;
                }
                //7 한문자로 연속된 암호 불가
                for (var i = 0; i < passText.length - 1; i++) {
                    if (passText.substr(i, 1) == passText.substr(i + 1, 1)) {
                        alert('연속된 문자는 사용할 수 없습니다.');
                        return false;
                    }
                }
            }
        }

        return confirm('변경된 정보를 저장하시겠습니까?');
    }
    function ViewValInfo(mode) {
        if (mode == "rule") {
            document.getElementById('rule').style.display = "block";
            document.getElementById("main").style.display = "none";
        }
        else {
            document.getElementById("main").style.display = "block";
            document.getElementById('rule').style.display = "none";
        }
    }
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">
    <form id="form1" enctype="multipart/form-data" runat="server">
    <%--<asp:ImageButton ID="ImageButton1" runat="server" OnClick="ibtnTEST_Click" Height="19px" ImageUrl="~/images/btn/b_tp07.gif"   Visible="false"/>--%>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
            <tr id="main" style="display:block;">
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t26.gif"></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                                                    <td style="width:50%; background-color:#FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                          </tr>
                          <tr class="cssPopContent">
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                                <tr>
                                                    <td style="width:15px;">
                                                        <img src="../images/title/ma_t14.gif" alt="" />
                                                    </td>
                                                    <td>
                                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="사용자 정보" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align:top;">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        부서명
                                                    </td>
                                                    <td class="cssTblContentSingle">
                                                        <ASP:LABEL id="lblDeptName" runat="server"></ASP:LABEL>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        사용자 아이디
                                                    </td>
                                                    <td class="cssTblContentSingle">
                                                        <ASP:LABEL id="lblLoginID" runat="server"></ASP:LABEL>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        성명</td>
                                                    <td class="cssTblContentSingle">
                                                        <ASP:LABEL id="lblEmpName" runat="server"></ASP:LABEL>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" height="26">※ 비밀번호를 변경 하실 수 있습니다.
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder" >
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        비밀번호
                                                    </td>
                                                    <td class="cssTblContentSingle">
                                                        <ASP:TEXTBOX id="txtPassword" runat="server" TextMode="Password" Width="100%"></ASP:TEXTBOX>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        비밀번호 확인
                                                    </td>
                                                    <td class="cssTblContentSingle">
                                                        <ASP:TEXTBOX id="txtCfmPassword" runat="server" TextMode="Password" Width="100%"></ASP:TEXTBOX>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        휴대전화 번호
                                                    </td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtCellPhone" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitleSingle">
                                                        이메일
                                                    </td>
                                                    <td class="cssTblContentSingle">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr class="cssPopBtnLine">
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="width: 50%;">
                                                        <a href="#" onclick="javascript:ViewValInfo('rule');"><asp:Label ID="lblValidateView" runat="server" Text="비밀번호 규칙" Font-Underline="true" ForeColor="LightBlue"></asp:Label></a>
                                                    </td>
                                                    <td align="right" style="width: 50%;">
                                                        <asp:ImageButton ID="iBtnSave" runat="server" OnClientClick="return ValidatePass();" OnClick="ibtnSave_Click" Height="19px" ImageUrl="~/images/btn/b_tp07.gif" />
                                                        <a href='#null' onclick="return window.close()"><img src="../images/btn/b_003.gif" border="0" id="imgClose" alt="" /></a>
                                                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                          </tr>
                          <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr> 
                                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                                        <td style="width:50%; background-color:#FFFFFF"></td>
                                    </tr>
                                </table>
                            </td>
                          </tr>
                    </table>
                </td>
            </tr>
          
            <tr id="rule" style="display:none;">
                <td>
                    <table border="0" cellpadding="0" cellspacing="2" width="100%" style="height: 100%;">
                        <tr>
                            <td style="width: 100%; height: 100%; padding: 10px;" valign="top">
                                <br />
                                <img src="../images/icon/subtitle.gif" alt="">&nbsp;<b>비밀번호 규칙</b><br /><br />
                                &nbsp;◎ 알파벳+숫자 혹은 알파벳+특수문자<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;혹은 알파벳+숫자+특수문자 조합.<br />
                                &nbsp;◎ 숫자나 특수문자가 먼저 올 수 없음.<br />
                                &nbsp;◎ 7자리 이상 12자리 이하.<br />
                                &nbsp;◎ 알파벳은 대소문자 모두 가능.<br />
                                &nbsp;◎ ID와 동일할 수 없음.<br />
                                &nbsp;◎ 특수문자 중 '&', '=', '?' 사용불가.<br />
                                &nbsp;◎ 한 문자로 연속된 암호 불가.<br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <img src="../images/btn/b_003.gif" border="0" id="img1" alt="" onclick="javascript:ViewValInfo('main');" style="cursor: pointer;" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>