<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0403S3.aspx.cs" Inherits="BSC_BSC0403S3" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html; " />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" oncontextmenu="return false"
    onselectstart="return false;" ondragstart="return false;">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="40" valign="top">
                                        <img src="../images/title/popup_t22.gif">
                                    </td>
                                    <td align="right" valign="top">
                                        <img src="../images/title/popup_img.gif">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="50%" height="4" bgcolor="#FFFFFF">
                                    </td>
                                    <td width="50%" bgcolor="#FFFFFF">
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
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height:100%;">
                    <tr style="height:100%;">
                        <td>
                            <div style="border: #F4F4F4 3px solid; overflow: auto; width: 100%; height: 100%">
                                &nbsp;<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                    OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
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
                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                        <td style="width:50%; background-color:#FFFFFF"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
