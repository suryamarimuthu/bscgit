<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2103.aspx.cs" Inherits="ctl_ctl2100_3" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: 부서 관리 ::</title>
    <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
        <tr>
            <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="40" valign="top">
                            <img src="../images/title/popup_t28.gif">
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
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr style="height: 100%;">
                        <td>
                            <div style="border-right: 1px solid; border-top: 1px solid; overflow: auto; border-left: 1px solid;
                                width: 100%; border-bottom: 1px solid; height: 100%">
                                &nbsp;<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                    OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltrHiddenLevel" runat="server" Visible="False"></asp:Literal>
                            <asp:Literal ID="ltrHiddenDeptID" runat="server" Visible="False"></asp:Literal>
                            <table border="0" width="100%" class="tableBorder">
                                <tr id="pnlNew" runat="server">
                                    <td class="cssTblTitle">
                                        생성 부서 위치
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Literal ID="ltrTreePath_New" runat="server"></asp:Literal>
                                    </td>
                                    <td class="cssTblTitle">
                                        생생 부서명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtDeptNew" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="pnlRename" runat="server">
                                    <td class="cssTblTitle">
                                        현재 부서 위치의 부서명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Literal ID="ltrTreePath_Rename" runat="server"></asp:Literal>
                                    </td>
                                    <td class="cssTblTitle">
                                        변경 부서명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtDeptRename" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="pnlMove" runat="server">
                                    <td class="cssTblTitle">
                                        현재 부서 위치
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Literal ID="ltrTreePath_Move" runat="server"></asp:Literal>
                                    </td>
                                    <td class="cssTblTitle">
                                        이동 부서 위치<asp:TextBox ID="txtMoveDeptID" runat="server" Width="0" BorderWidth="0px"></asp:TextBox>
                                        <asp:TextBox ID="txtMoveLevel" runat="server" BorderWidth="0px" Width="0"></asp:TextBox>
                                    </td>
                                    <td class="cssTblContent">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtDeptMove" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td style="width: 85px;">
                                                    <a href="#null" onclick="gfOpenWindow('ctl2104.aspx', 600, 450)">[이동부서위치]</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="pnlRemove" runat="server">
                                    <td class="cssTblTitle">
                                        삭제할 부서 위치
                                    </td>
                                    <td class="cssTblContent" style="border-right: none;">
                                        <asp:Literal ID="ltrTreePath_Remove" runat="server"></asp:Literal>
                                    </td>
                                    <td class="cssTblContent" style="width: 15%; border-left: none; border-right: none;">
                                        &nbsp;
                                    </td>
                                    <td class="cssTblContent">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnSave" runat="server" OnClick="iBtnSave_Click" ImageUrl="../images/btn/b_tp07.gif" />&nbsp;
                            <a href="#" onclick="self.close();">
                                <img src="../images/btn/b_016.gif" border="0" /></a>
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
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
