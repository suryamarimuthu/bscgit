<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctlPassExcel_Upload.aspx.cs"
    Inherits="ctl_ctlPassExcel_Upload" %>

<%Response.WriteFile("../_common/html/PopupTop.htm");%>

<script type="text/javascript" language="javascript">
    function mfCheckFile() {
        var oFile = gfGetFindObj("hFile");

        if (oFile) {
            if (oFile.value == "") {
                alert("일괄수정할 파일을 선택하십시요!");
            }
            else if (oFile.value.substr(oFile.value.lastIndexOf(".") + 1).toUpperCase() != "XLS") {
                alert("업로드는 엑셀파일만 가능합니다!");
            }
            else {
                return true;
            }
        }

        return false;
    }
</script>

<form id="form1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                    <td height="40" valign="top">
                        <img src="../images/title/popup_t26.gif">
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
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td style="width: 15px;">
                                    <img src="../images/title/ma_t14.gif" alt="" />
                                </td>
                                <td>
                                    <asp:label id="lblTitle1" runat="server" style="font-weight: bold" text="사용자에 대한 비밀번호를 일괄수정 합니다." />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                            <tr>
                                <td class="cssTblTitleSingle">
                                    적용 엑셀 파일
                                </td>
                                <td class="cssTblContentSingle">
                                    <input id="hFile" type="file" runat="server" style="width: 100%" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="cssPopBtnLine">
                    <td>
                        <asp:imagebutton id="iBtnExcelUpload" imageurl="~/images/btn/b_040.gif"
                            runat="server" align="absmiddle" onclick="iBtnExcelUpload_Click"></asp:imagebutton>
                        <a href="javascript:window.close();">
                            <img src="../images/btn/b_003.gif" border="0" align="absmiddle"></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>