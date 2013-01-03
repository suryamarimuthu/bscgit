<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0101M1.aspx.cs" Inherits="BSC_BSC0101M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>성과관리 시스템::관점등록</title>
<meta http-equiv="Content-Type" content="text/html; " />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    var Page = {
        fnImgCheck: function() {
            if (!Page.fnExtensioncheck()) {
                alert('이미지 파일만 업로드 됩니다.'); return false;
            }
        },
        fnExtensioncheck: function() {
            var file = document.getElementById("<%=fudViewImage.ClientID %>").value;
            var lastIndex = -1;
            lastIndex = file.lastIndexOf('.');
            var extension = "";

            if (lastIndex != -1) {
                extension = file.substring(lastIndex + 1, file.length);
            }

            if (extension.toLowerCase() == "jpg") {
                return true;
            }
            else if (extension.toLowerCase() == "bmp") {
                return true;
            }
            else if (extension.toLowerCase() == "png") {
                return true;
            }
            else if (extension.toLowerCase() == "tif") {
                return true;
            }
            else if (extension.toLowerCase() == "gif") {
                return true;
            }
            else {
                return false;
            }
        }
    }
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">

    <form id="form1" runat="server">
    <div>
      <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
        <tr> 
            <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t1.gif" /></td>
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
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
            		
		                        <!--tr>
			                        <td class="cssTblTitle" align=right><B>상위 전략</B></td>
			                        <td class="cssTblContent">
			                        </td>
		                        </tr-->
		                        <tr>
			                        <td class="cssTblTitle">관점명</td>
			                        <td class="cssTblContent">
                                        <asp:TextBox ID="txtVIEW_NAME" runat="server" Width="100%" MaxLength="40"></asp:TextBox>
			                        </td>
                                    <td class="cssTblContent" rowspan="3"  style="width:20%;" align="center">
                                        <asp:Image ID="imgPreview" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1" ImageAlign="AbsMiddle"/>
                                    </td>
		                        </tr>
		                         <tr>
			                        <td class="cssTblTitle">관점설명</td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtVIEW_DESC" runat="server" TextMode="MultiLine" Height="110" Width="100%"></asp:TextBox>
                                    </td>
		                        </tr>
		                        <tr>
			                        <td class="cssTblTitle">관점순서</td>
			                        <td class="cssTblContent" >
                                        <ig:webnumericedit id="txtVIEW_SEQ" runat="server" Width="80" MinDecimalPlaces="None" 
                                               NullText="0" Font-Names="Verdana" Font-Size="10pt" NegativeForeColor="Magenta" 
                                               ToolTip="관점순서" MinValue="0" MaxValue="100" 
                                               ValueText="0" Nullable="False" SpinWrap="true">
                                        </ig:webnumericedit>
			                        </td>
		                        </tr>
		                        <tr>
			                        <td class="cssTblTitle">이미지 경로</td>
			                        <td class="cssTblContent"  colspan="2">
                                        <asp:FileUpload ID="fudViewImage" Width="100%" runat="server" />
                                    </td>
		                        </tr>
            		           
		                        <tr>
			                        <td class="cssTblTitle">비고</td>
                                    <td class="cssTblContent" colspan="2">
                                        <asp:TextBox ID="txtVIEW_ETC" runat="server" TextMode="MultiLine" Height="80" Width="100%"></asp:TextBox>
                                    </td>
		                        </tr>
		                    </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPopBtnLine">
                              <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" Height="19px" runat="server" OnClick="iBtnInsert_Click" OnClientClick="return Page.fnImgCheck();" />
                              <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" Height="19px" runat="server" OnClick="iBtnUpdate_Click" OnClientClick="return Page.fnImgCheck();" />
                              <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_208.gif" Height="19px" runat="server" OnClick="iBtnDelete_Click" />
                              <asp:ImageButton ID="iBtnReUsed" ImageUrl="../images/btn/b_138.gif" Height="19px" runat="server" OnClick="iBtnReUsed_Click" />
                              <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" Height="19px" runat="server" OnClick="iBtnClose_Click" />
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

