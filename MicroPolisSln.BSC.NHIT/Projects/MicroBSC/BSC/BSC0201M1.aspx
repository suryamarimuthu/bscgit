<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0201M1.aspx.cs" Inherits="BSC_BSC0201M1" %>

<html>
<head id="Head1" runat="server">
<title>성과관리 시스템::전략수정</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF; overflow:scroll " onload="document.focus();">

    <form id="form1" runat="server">
        <div>
            <table width="100%" style="height:100%" border="0" cellspacing="0" cellpadding="0">
                <tr> 
                    <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t45.gif" /></td>
                                <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
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
                <tr class="cssPopContent">
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                            <tr>
                                <td>
                                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                                        <tr>
                                            <td class="cssTblTitle" style="width:20%;">
                                                전략코드
                                             </td>
                                            <td class="cssTblContent"  style="width:80%;">
                                              <asp:TextBox ID="txtSTG_CODE" runat="server" ReadOnly="true" BackColor="whitesmoke" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">전략명</td>
                                            <td class="cssTblContent">
                                                <asp:TextBox ID="txtSTG_NAME" runat="server" Width="100%" MaxLength="40"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">전략설정사유</td>
                                            <td class="cssTblContent">
                                                <asp:TextBox ID="txtSTG_SET_DESC" runat="server" TextMode="MultiLine" Height="103" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">상위관점</td>
                                            <td class="cssTblContent">
                                                <asp:dropdownlist ID="ddlStgViewInfo" runat="server" width="100%" CssClass="box01"></ASP:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle">비고</td>
                                            <td class="cssTblContent">
                                                <asp:TextBox ID="txtSTG_ETC" runat="server" TextMode="MultiLine" Height="80" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssPopBtnLine">
                                    <asp:ImageButton ID="iBtnInsert" runat="server" Height="19px" ImageUrl="../images/btn/b_001.gif" OnClick="iBtnInsert_Click" />
                                    <asp:ImageButton ID="iBtnUpdate" runat="server" Height="19px" ImageUrl="../images/btn/b_002.gif" OnClick="iBtnUpdate_Click" />
                                    <asp:ImageButton ID="iBtnDelete" runat="server" Height="19px" ImageUrl="../images/btn/b_208.gif" OnClick="iBtnDelete_Click" />
                                    <asp:ImageButton ID="iBtnReUsed" runat="server" Height="19px" ImageUrl="../images/btn/b_138.gif" OnClick="iBtnReUsed_Click" />
                                    <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif" OnClick="iBtnClose_Click" />
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
                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                        <asp:HiddenField ID="hdfImagePath" runat="server" Value="" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
