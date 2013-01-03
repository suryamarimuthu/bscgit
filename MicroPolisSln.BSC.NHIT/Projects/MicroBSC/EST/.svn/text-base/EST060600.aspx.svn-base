<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060600.aspx.cs" Inherits="EST_EST060600" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<script type="text/javascript">

	</script>
	<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <table cellpadding="0" cellspacing="1" style="width: 98%; height: 95%">
        <tr>
            <td valign="top" height="25">
                <table cellpadding="0" cellspacing="0" class="tableOutBorder" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table class="tableBorder" cellpadding="0" cellspacing="1" width="100%">
                                            <tr>
                                                <td class="tableTitle" width="120px">기준대상</td> 
                                                <td class="tdBorder" colspan="3"> 
                                                    <asp:dropdownlist id="ddlEstTermRefID_From" runat="server" class="box01"></asp:dropdownlist>
                                                    <asp:dropdownlist id="ddlEstTermSubID_From" runat="server" class="box01"></asp:dropdownlist>
                                                </td> 
                                                <td class="tableTitle" width="120px">피참조대상</td> 
                                                <td class="tdBorder" colspan="3"> 
                                                    <asp:dropdownlist id="ddlEstTermRefID_To" runat="server" class="box01"></asp:dropdownlist>
                                                    <asp:dropdownlist id="ddlEstTermSubID_To" runat="server" class="box01"></asp:dropdownlist>
                                                </td> 
                                            </tr>
                                        </table>
                                     </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr height="25" valign="bottom" width="50%">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01"></asp:dropdownlist>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:expression(eval(document.body.clientHeight) - 260); ">
            <td  valign="top" align="center">
                <table cellpadding="0" cellspacing="0" height="100%" width="98%" class="tableBorder">
                    <tr>
                        <td class="tdBorder" valign="top">
                            <br />
                            &nbsp;<asp:checkbox runat="server" ID="ckbType_1" Text="부서별 등급산출 방법 및 가중치" Checked="True"></asp:checkbox><br />
                            &nbsp;<asp:checkbox runat="server" ID="ckbType_2" Text="상대그룹 설정" Checked="True"></asp:checkbox><br />
                            &nbsp;<asp:checkbox runat="server" ID="ckbType_3" Text="평가자/ 피평가자 매핑 정보" Checked="True"></asp:checkbox><br />
                            &nbsp;<asp:checkbox runat="server" ID="ckbType_4" Text="질의/ 피평가자 매핑 정보" Checked="True"></asp:checkbox><br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td colspan="3" height="40">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_192.gif" OnClick="ibnSave_Click"></asp:ImageButton>
                            &nbsp;
                        </td>
                    </tr>
                </table></td>
        </tr>
    </table>

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>