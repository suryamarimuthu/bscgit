<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CTL301020.aspx.cs" Inherits="CTL_CTL301020" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
        function SearchMenuID() {
            gfOpenWindow("./CTL_MENU.aspx?CTRL_VALUE_NAME=" + "txtUpMenuID"
                                + "&CTRL_TEXT_NAME=" + "txtUpMenuName"
                                + "&CHECKBOX_YN=" + "N"
                                + "&CTRL_VALUE_VALUE=" + "hdfUpMenuID"
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_ctl_menuId");
            return false;
        }
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td style="height: 40px;" valign="top">
                            <img alt="" src="../images/title/popup_t91.gif" />
                        </td>
                        <td align="right" valign="top">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr style="width: 100%;">
                        <td>
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%"
                                style="height: 100%;">
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴ID</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuRefID" runat="server" Width="99%" BackColor="#E0E0E0" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>상위메뉴ID</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width: 40%;">
                                                    <asp:TextBox ID="txtUpMenuID" runat="server" Width="100%" BackColor="#E0E0E0" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td style="width: 65px; text-align: center;">
                                                    <asp:Image ID="ibtnUpMenuID" runat="server" BorderWidth="0px" ImageAlign="Top" ImageUrl="../images/btn/b_094.gif"
                                                        onclick="SearchMenuID();" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUpMenuName" runat="server" BackColor="#E0E0E0" ReadOnly="True"
                                                        Width="100%" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴명(*)</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuName" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴디렉토리(*)</b>
                                    </td>
                                    <td class="cssTblContentSingle" style="height: 19px">
                                        <asp:TextBox ID="txtMenuDir" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴페이지명(*)</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuPageName" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴파라메터</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuParam" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴전체경로(*)</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuFullPath" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 100%;">
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴설명</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuDesc" runat="server" TextMode="MultiLine" Height="100%" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴순서</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuPriority" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴인증타입</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:DropDownList ID="ddlMenuAuthType" runat="server" Width="99%" CssClass="box01">
                                            <asp:ListItem Selected="True" Value="A">인증</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴타입</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:DropDownList ID="ddlMenuType" runat="server" Width="99%" CssClass="box01">
                                            <asp:ListItem Value="T">탑메뉴</asp:ListItem>
                                            <asp:ListItem Value="M">폴더메뉴</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="S">서브메뉴</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴명이미지경로</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuNameImagePath" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴명이미지경로2</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuNameImagePathU" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>메뉴아이콘경로</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtMenuPrevIconPath" runat="server" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        <b>왼쪽메뉴보여주기여부</b>
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:DropDownList ID="ddlShowLeftMenu" runat="server" Width="100px" CssClass="box01">
                                            <asp:ListItem Selected="True" Value="Y">보임</asp:ListItem>
                                            <asp:ListItem Value="N">숨김</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" Height="19px"
                                runat="server" OnClick="iBtnInsert_Click" />&nbsp;
                            <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" Height="19px"
                                runat="server" OnClick="iBtnUpdate_Click" />&nbsp;
                            <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_004.gif" Height="19px"
                                runat="server" OnClick="iBtnDelete_Click" />&nbsp;
                            <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" Height="19px"
                                runat="server" OnClick="iBtnClose_Click" />&nbsp;
                            <asp:HiddenField ID="hdfMenuRefID" runat="server" />
                            <asp:HiddenField ID="hdfUpMenuID" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
