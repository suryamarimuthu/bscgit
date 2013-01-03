<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2301.aspx.cs" Inherits="ctl_ctl2301" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: 부서 생성 ::</title>
    <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
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
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div style="border-right: 1px solid; border-top: 1px solid; overflow: auto; border-left: 1px solid;
                                                        width: 100%; border-bottom: 1px solid; height: 100%">
                                                        &nbsp;<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                                            OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Width="100%">
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
                     <tr>
                        <td>
                            <asp:Literal ID="ltrHiddenLevel" runat="server" Visible="false"></asp:Literal>
                            <asp:Literal ID="ltrHiddenDeptID" runat="server" Visible="false"></asp:Literal>
                            <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                <tr id="pnlNew" runat="server">
                                    <td class="cssTblTitle">
                                        상위부서경로
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Literal ID="ltrTreePath_New" runat="server"></asp:Literal>
                                    </td>
                                    <td class="cssTblTitle">
                                        추가 부서명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtDeptNew" runat="server"></asp:TextBox>
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
                                        <asp:TextBox ID="txtDeptRename" runat="server" Width="132px"></asp:TextBox>
                                        <ig:WebNumericEdit runat="server" ID="txtSortOrder" Width="50px" AutoPostBack="false"
                                            MinValue="0" Nullable="false" NullText="0" />
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
                                        <asp:TextBox ID="txtDeptMove" runat="server" Width="258px" ReadOnly="True"></asp:TextBox>
                                        <a href="#null" onclick="gfOpenWindow('ctl2104.aspx', 600, 470);">[이동부서위치]</a>
                                    </td>
                                </tr>
                                <tr id="pnlRemove" runat="server">
                                    <td class="cssTblTitle">
                                        삭제할 부서 위치&nbsp;
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Literal ID="ltrTreePath_Remove" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnSave" runat="server" OnClick="iBtnSave_Click" />&nbsp;
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
