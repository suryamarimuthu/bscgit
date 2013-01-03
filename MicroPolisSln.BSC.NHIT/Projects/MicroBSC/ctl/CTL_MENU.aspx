﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CTL_MENU.aspx.cs" Inherits="CTL_CTL_MENU" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
   
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td height="40">
                <!-- 타이틀시작 -->
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="40" valign="top">
                                        <img src="../images/title/popup_t91.gif">
                                    </td>
                                    <td align="right" valign="top">
                                        <img src="../images/title/popup_img.gif">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="50%" height="4" bgcolor="FFFFFF">
                                    </td>
                                    <td width="50%" bgcolor="FFFFFF">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!-- 타이틀끝 -->
            </td>
        </tr>
        <tr class="cssPopContent">
            <td valign="top" class="box_td03">
                <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0"
                    class="box_ta01">
                    <tr>
                        <td>
                            <div style="border: #F4F4F4 1px solid; overflow: auto; width: 100%; height: 100%">
                                &nbsp;<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                    OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Dotum" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="ibnSelect" runat="server" ImageUrl="../images/btn/b_094.gif"
                                OnClick="ibnSelect_Click" />
                            <a href="javascript:window.close();">
                                <img src="../images/btn/b_003.gif" border="0" /></a>
                        </td>
                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
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

    <script>        gfWinFocus();</script>

    <!--- MAIN END --->
    </form>
</body>
</html>