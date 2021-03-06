﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2105.aspx.cs" Inherits="ctl_ctl2105" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>부서이동 선택</title>
    <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
        <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
            <tr>
                <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" valign="top">
                                <img src="../images/title/popup_t29.gif">
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
                        <tr style="height:100%;">
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height:100%;" align="center">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td style="width: 15px;">
                                                        <img src="../images/title/ma_t14.gif" alt="" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTitle1" runat="server" Style="font-weight: bold" Text="현재 부서경로 선택" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td style="width: 15px;">
                                                        <img src="../images/title/ma_t14.gif" alt="" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Style="font-weight: bold" Text="이동 부서경로 선택" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="height:100%;">
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
                                        <td>
                                            <div style="border-right: 1px solid; border-top: 1px solid; overflow: auto; border-left: 1px solid;
                                                width: 100%; border-bottom: 1px solid; height: 100%">
                                                &nbsp;<asp:TreeView ID="TreeView2" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                                    OnSelectedNodeChanged="TreeView2_SelectedNodeChanged">
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
                                </table>
                            </td>
                        </tr>
                        <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrHiddenLevel" runat="server" Visible="False"></asp:Literal>
                                <asp:Literal ID="ltrHiddenDeptID" runat="server" Visible="False"></asp:Literal>
                                <table border="0" width="100%" class="tableBorder">
                                    <tr>
                                        <td class="cssTblTitle">
                                            현재 부서 위치
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:Literal ID="ltrTreePath_Move" runat="server"></asp:Literal>
                                        </td>
                                        <td class="cssTblTitle">
                                            이동 부서 위치<asp:TextBox ID="txtMoveDeptID" runat="server" BorderWidth="0px" Width="0"></asp:TextBox>
                                            <asp:TextBox ID="txtMoveLevel" runat="server" BorderWidth="0px" Width="0"></asp:TextBox>
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:TextBox ID="txtDeptMove" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td>
                                <asp:ImageButton ID="iBtnSave" runat="server" ImageUrl="~/images/btn/b_002.gif" OnClick="iBtnSave_Click" />
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
