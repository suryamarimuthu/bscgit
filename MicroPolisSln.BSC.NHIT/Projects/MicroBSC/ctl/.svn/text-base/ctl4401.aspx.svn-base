<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4401.aspx.cs" Inherits="ctl_ctl4401" %>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript">
    function inputCheck() {
        var f = document.form1;
        if (f.rBtnNew.checked == true) {
            if (f.txtUnitGroup.value == "") {
                alert("Unit그룹명을 입력하세요");
                f.txtUnitGroup.focus();
                return false;
            }
        }

        if (f.txtUnit.value == "") {
            alert("Unit명을 입력하세요");
            f.txtUnit.focus();
            return false;
        }

        if (f.txtDecimalPoint.value == "") {
            alert("DecimalPoint를 입력하세요");
            f.txtDecimalPoint.focus();
            return false;
        }


        //                if(!f.chkUse.checked)
        //                {
        //                    alert(f.txtUnit.value+"을(를) 사용하지 않습니다");
        //                }
        //                else
        //                {
        //                    alert(f.txtUnit.value+"을(를) 사용합니다");
        //                }

        return true;
    }
</script>

<form id="form1" runat="server">
<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                    <td valign="top" style="height: 40px">
                        <img src="../images/title/popup_t51.gif">
                    </td>
                    <td align="right" valign="top" style="height: 40px">
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
                        <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder"
                            style="height: 30px">
                            <tr>
                                <td class="cssTblTitleSingle">
                                    Unit 그룹명
                                </td>
                                <td class="cssTblContentSingle">
                                    <asp:radiobutton id="rBtnNew" runat="server" autopostback="True" groupname="UnitType"
                                        oncheckedchanged="rBtnInput_CheckedChanged" text="신규"></asp:radiobutton>
                                    <asp:radiobutton id="rBtnEdit" runat="server" autopostback="True" groupname="UnitType"
                                        oncheckedchanged="rBtnEdit_CheckedChanged" text="수정"></asp:radiobutton>
                                    <asp:dropdownlist id="ddlUnitGroup" runat="server" visible="False" cssclass="box01"></asp:dropdownlist>
                                    <asp:textbox id="txtUnitGroup" runat="server" visible="False"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitleSingle">
                                    UNIT
                                </td>
                                <td class="cssTblContentSingle">
                                    <asp:textbox id="txtUnit" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitleSingle">
                                    FORMAT
                                </td>
                                <td class="cssTblContentSingle">
                                    <asp:textbox id="txtFormatString" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitleSingle">
                                    DECIMAL
                                </td>
                                <td class="cssTblContentSingle">
                                    <asp:textbox id="txtDecimalPoint" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitleSingle">
                                    ROUNDING
                                </td>
                                <td class="cssTblContentSingle">
                                    <asp:textbox id="txtRoundingType" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssTblTitleSingle">
                                    USE
                                </td>
                                <td class="cssTblContentSingle">
                                    <asp:checkbox id="chkUse" runat="server" autopostback="True"></asp:checkbox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="cssPopBtnLine">
                    <td>
                        <asp:literal id="ltrScript" runat="server"></asp:literal>
                        <asp:imagebutton id="iBtnModify" runat="server" imageurl="~/images/btn/b_002.gif"
                            onclick="iBtnModify_Click"></asp:imagebutton>
                        <asp:imagebutton id="iBtnSave" runat="server" height="19px" imageurl="~/images/btn/b_tp07.gif"
                            onclick="iBtnSave_Click" />
                        &nbsp;<a href="#null" onclick="self.close()"><img src="../images/btn/b_003.gif" id="hBtnClose" /></a>
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

<script>    gfWinFocus();</script>

<!--- MAIN END --->
</form>
