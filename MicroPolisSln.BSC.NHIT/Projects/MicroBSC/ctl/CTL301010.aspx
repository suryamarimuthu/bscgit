<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CTL301010.aspx.cs" Inherits="CTL_CTL301010" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td style="height: 40px;" valign="top">
                            <img alt="" src="../images/title/popup_t90.gif" />
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
                    <tr>
                        <td>
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="cssTblTitleSingle" align="center" width="100">
                                        권한명
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtRoleName" runat="server" Width="100%"></asp:TextBox>
                                        <asp:HiddenField ID="hdfRoleRefID" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle" align="center" width="100">
                                        권한설명
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtRoleDesc" runat="server" TextMode="MultiLine" Height="100%" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitleSingle" align="center" width="100">
                                        순서
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtSortOrder" runat="server" Width="100%"></asp:TextBox>
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
