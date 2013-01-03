<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0406S2.aspx.cs" Inherits="BSC_BSC0406S2" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" oncontextmenu="return false"
    onselectstart="return false;" ondragstart="return false;">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 40px;" valign="top">
                                        <img alt="" src="../images/title/popup_t22.gif" />
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
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr style="height: 100%;">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;
                                vertical-align: top;">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plnTree" runat="server" ScrollBars="auto" Width="100%" Height="100%"
                                            BorderWidth="0">
                                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                                OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Width="100%" Height="100%">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                                    VerticalPadding="0px" />
                                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;" align="right">
                            <a href="#" onclick="self.close();">
                                <img src="../images/btn/b_003.gif" border="0" /></a>
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
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:HiddenField ID="hdfImagePath" runat="server" Value="" />
            </td>
        </tr>
        <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </table>
    </form>
</body>
</html>
