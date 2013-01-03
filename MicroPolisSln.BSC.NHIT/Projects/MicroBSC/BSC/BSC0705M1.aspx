<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0705M1.aspx.cs" Inherits="BSC_BSC0705M1" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템</title>
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
        function ReloadParentForm() {
            opener.__doPostBack();
            window.close();
        }
    </script>

</head>
<body style="margin: 0,0,0,0;">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                        <td>
                            <img src="../images/title/popup_t62.gif" alt="" />
                        </td>
                        <td align="right" valign="top">
                            <img src="../images/title/popup_img.gif" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px; width: 50%; background-color: #FFFFFF">
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
                    <tr style="height: 100%;">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%"
                                style="height: 100%;">
                                <tr>
                                    <td class="cssTblTitle">
                                        작성자
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblWriterName" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        작성일
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblCreateDate" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        질문
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <asp:TextBox ID="txtSubject" runat="server" Height="20" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 100%;">
                                    <td class="cssTblTitle">
                                        답변
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" BasePath="../_common/FCKeditor/"
                                            Height="100%" />
                                        <div id="leftLayer" runat="server" style="border: #F4F4F4 1 solid; display: block;
                                            overflow: auto; width: 100%; height: 100%; padding-bottom: 0px; padding-left: 0px;
                                            padding-right: 0px; padding-top: 0px;">
                                            <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td align="right" class="content" style="height: 40px; width: 70%;">
                            <asp:ImageButton ID="iBtnSave" runat="server" Height="19px" ImageUrl="../images/btn/b_tp07.gif"
                                OnClick="iBtnSave_Click" />
                            <asp:ImageButton ID="iBtnModify" runat="server" Height="19px" ImageUrl="../images/btn/b_002.gif"
                                OnClick="iBtnModify_Click" />
                            <asp:ImageButton ID="iBtnDelete" runat="server" Height="19px" ImageUrl="../images/btn/b_004.gif"
                                OnClick="iBtnDelete_Click" />
                            <img alt="" src="../images/btn/b_003.gif" onclick="ReloadParentForm();" style="cursor: hand;" />
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
    <asp:LinkButton ID="lBtnReload" runat="server"></asp:LinkButton>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
