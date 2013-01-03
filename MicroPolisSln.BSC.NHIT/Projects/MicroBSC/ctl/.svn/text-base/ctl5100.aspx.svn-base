<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl5100.aspx.cs" Inherits="ctl_ctl5100" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content id="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
    function osbackgroundimagechange() {
        var selectedItem = document.getElementById('<%= ddlOSF_BACKGROUNDIMAGE.ClientID %>');
        document.getElementById('imgBackground').src = selectedItem.options[selectedItem.selectedIndex].value;
    }
    function osimagesetchange() {
        var selectedItem = document.getElementById('<%= ddlOSF_IMAGESET.ClientID %>');
        document.getElementById('imgImageSet').src = selectedItem.options[selectedItem.selectedIndex].value;
    }
    function checkSave() {
        return confirm('설정하시겠습니까?');
    }
</script>

<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="2" width="100%" style="height: 100%;">
    <tr valign="top">
        <td>
            <div style="height: 100%; overflow: auto;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 1000px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;조직상황판
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        당월/누적 시그널 모두 보기
                                    </td>
                                    <td class="tableContent" colspan="2">
                                        <asp:RadioButtonList ID="rbOSF_ALLSIGNAL" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" valign="top" style="padding-top: 5px;">
                                        배경이미지
                                    </td>
                                    <td class="tableContent" style="width: 200px; padding-top: 5px;" valign="top">
                                        <asp:DropDownList ID="ddlOSF_BACKGROUNDIMAGE" runat="server" CssClass="box01" Width="100%" onchange="osbackgroundimagechange()"></asp:DropDownList>
                                    </td>
                                    <td class="tableContent" style="padding-top: 5px; padding-bottom: 5px;" align="center">
                                        <img id="imgBackground" src="../images/org/bg_org_19.jpg" width="50px" height="50px" alt="조직상황판 배경이미지" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" valign="top">
                                        시그널이미지 세트
                                    </td>
                                    <td class="tableContent">
                                        <asp:DropDownList ID="ddlOSF_IMAGESET" runat="server" CssClass="box01" Width="100%" onchange="osimagesetchange()"></asp:DropDownList>
                                    </td>
                                    <td class="tableContent" align="center">
                                        <img id="imgImageSet" src="../images/org/signal_set1/icon_a.gif" width="11px" height="11px" alt="시그널 이미지세트" />
                                    </td>
                                </tr>
                                <!--<add key="DTree.SignalLevel" value="4"/>
                                <tr visible="false">
                                    <td class="tableTitle" valign="top">
                                        시그널 단계
                                    </td>
                                    <td class="tableContent" colspan="2">
                                        <asp:DropDownList ID="ddlOSStep" runat="server" CssClass="box01" Width="200px"></asp:DropDownList>
                                    </td>
                                </tr>
                                -->
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;이미지 설정
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        상단 메뉴 LOGO
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtIMG_MENULOGO" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        하단 카피 LOGO
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtIMG_COPYLOGO" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        로그인페이지 LOGO
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtIMG_LOGINLOGO" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;DB 유형
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        OLAP Server
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtDBT_OLAPSERVER" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!--
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        DB Provider Type
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbDBT_PROVIDERTYPE" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                -->
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;SSO
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        Single Sign On 사용여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbSSO_USEYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        Default Page URL
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtSSO_DEFAULTPAGEURL" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        Single Sign On Server 체크여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbSSO_SERVERCHECKYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        ID/PWD 인증여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbSSO_IDPWDCONFIRMYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;첨부파일
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        File Size [S:5M]
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtFLS_S" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        File Size [M:10M]
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtFLS_M" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        File Size [L:10M]
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtFLS_L" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;부서정보 연동
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        인사정보 Table [기간계 연동]
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtIFC_EMP" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        부서정보 Table [기간계 연동]
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtIFC_DEPT" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;패스워드
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        패스워드 암호화 사용여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbPWD_ENCRYPTYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        패스워드 유효성 검사여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbPWD_VALIDATEYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;결재
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        결재처리 외부위임
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbAPP_EXTERNALYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        자가결재 사용여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbAPP_SELFYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        결재선변경 이력관리 사용여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbAPP_HISTORYYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="padding-top: 10px;">
                            <img alt="" src="../images/icon/subtitle.gif" style="vertical-align:middle;" />&nbsp;기타
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        로그인 초기화면
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbETC_DEFAULTPAGE" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        FCKEditor User Files Path
                                    </td>
                                    <td class="tableContent">
                                        <asp:TextBox ID="txtETC_FCKEDITORPATH" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableTitle" style="width: 200px;">
                                        과제맵 바로가기 사용여부
                                    </td>
                                    <td class="tableContent">
                                        <asp:RadioButtonList ID="rbETC_WORKMAPYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr valign="bottom">
        <td style="height: 20px;">
            <table border="0" cellpadding="0" cellspacing="2" width="100%" style="height: 20px;">
                <tr>
                    <td align="right" valign="bottom">
                        <asp:ImageButton ID="ibtnSave" runat="server" OnClientClick="return checkSave();" OnClick="ibtnSave_Click" ImageUrl="../images/btn/b_007.gif" />
                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<!--- MAIN END --->

</asp:Content>