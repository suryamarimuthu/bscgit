<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110100M1.aspx.cs" Inherits="EST_EST110100M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

<%--<script type="text/javascript" src="../_common/js/common.js"></script>--%>
<script type="text/javascript">
    function CloseWindow() {
        self.close();
    }

    function validateGrade() {
        var grade_id = document.getElementById("hdf_grade_id").value;

        if (grade_id == '') {
            alert("평가등급 조회 후 저장하세요.");
            return false;
        }

        return true;
    }
</script>
</head>


<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">
<form id="form1" runat="server">
    
         <table width="100%" style="height:100%" border="0" cellspacing="0" cellpadding="0">
            <tr> 
                <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <%--<td style="width:170px; height:40px; background-image:url(../images/title/popup_title.gif); vertical-align:middle; padding-left:70px;">
                              <asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Italic="false" Font-Bold="true" ForeColor="white" Text="개인종합평가 결과" />
                            </td>--%>
                            <td style="width:170px; height:40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                                <asp:Label ID="lblPopUpTitle" runat="server" CssClass="cssPopTitleTxt" Text="개인종합평가 결과"></asp:Label>
                            </td>
                            <td align="right" valign="top">
                                <img alt="" src="../images/title/popup_img.gif" />
                            </td>
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
            
            <tr class="cssPopBtnLine">
                <td align="right">
                    <table cellpadding="0" cellspacing="0" border="0" style="height:100%;">
                        <tr>
                            <td style="padding-right:5px; font-weight:bold;">
                                평가기간
                            </td>
                            <td style="padding-right:5px;">
                                <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01" ></asp:DropDownList>
						            <asp:DropDownList id="ddlEstTermSubID" runat="server" class="box01"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:label id="lblCompTitle" runat="server"></asp:label>
                                <asp:dropdownlist id="ddlCompID" runat="server" class="box01"  Visible="false"></asp:dropdownlist>
                                <asp:ImageButton ID="ibnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" OnClick="ibnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
           
            
            <tr>
                <td>
                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width:100%">
                        <tr>
                            <td class="cssTblTitleSingle">
                                평가등급
                            </td>
                            <td class="cssTblContent">
                                <asp:Label ID="lblGrade_id" runat="server"></asp:Label>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
            
            <tr style="height:5px;">
                <td></td>
            </tr>
            
            
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                        <tr>
                            <td style="width:15px;">
                                <img src="../images/title/ma_t14.gif" alt="" />
                            </td>
                            <td>
                                <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="이의내용" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
            
            <tr style="height:50%;">
                <td>
                    <asp:TextBox ID="txt_RefusalComment" runat="server" TextMode="MultiLine" Width="100%" Height="99%"></asp:TextBox>
                </td>
            </tr>
            
            
            
            <tr class="cssPopBtnLine">
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                        <tr>
                            <td style="width:15px;">
                                <img src="../images/title/ma_t14.gif" alt="" />
                            </td>
                            <td>
                                <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="답변" />
                            </td>
                            <td align="right">
                                <asp:ImageButton id="ibnSaveComment" runat="server" ImageUrl="../images/btn/b_tp07.gif" onclick="ibnSaveComment_Click" OnClientClick="return validateGrade()" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
            
            <tr style="height:50%;">
                <td>
                    <asp:TextBox ID="txt_RefusalReply" runat="server" TextMode="MultiLine" Width="100%" Height="100%"></asp:TextBox>
                </td>
            </tr>
            
            
            <tr class="cssPopBtnLine">
                <td align="right">
                    <asp:ImageButton id="ibnSaveReply" runat="server" ImageUrl="../images/btn/b_tp07.gif" onclick="ibnSaveReply_Click" OnClientClick="return validateGrade()" />
                    <asp:ImageButton ID="ibnClose" runat="server" ImageUrl="../images/btn/b_003.gif" OnClientClick="CloseWindow()" />
                    <asp:literal id="ltrScript" runat="server"></asp:literal>
                    <asp:HiddenField ID="hdf_grade_id" runat="server" Value="" />
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
            </table></td></tr>
        </table>
    
</form>
</body>
</html>