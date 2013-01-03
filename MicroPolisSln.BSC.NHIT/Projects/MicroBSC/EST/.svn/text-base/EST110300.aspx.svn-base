<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110300.aspx.cs" Inherits="EST_EST110300" %>

<%@ Register Src="USER_CTRL/EST_SUM_GRID.ascx" TagName="EST_SUM_GRID" TagPrefix="uc1" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">

	

</script>

<form id="form1" runat="server">
	<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle" style="width:15%;">
                            평가기간
                        </td>
                        <td  class="cssTblContent" style="width:85%;">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" Visible="False"></asp:dropdownlist>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:100%">
            <td  valign="top">
                <table cellpadding="0" cellspacing="0" height="100%" width="100%">
                    <tr>
                        <td style="height: 100%" valign="top">
                            <div id="leftLayer" style="border:#F4F4F4 0 solid; DISPLAY:block; overflow: auto; width: 100%;  height:100%; padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px; ">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" BorderWidth="0px" CellPadding="1" CellSpacing="1" ShowHeader="False">
                                    <Columns>
                                        <asp:TemplateField></asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
        <%--<tr>
            <td colspan="3" height="40">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
							<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>							
							<asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>&nbsp;
                        </td>
                    </tr>
                </table></td>
        </tr>--%>
    </table>

    <asp:HiddenField ID="hdfEstTermSubID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>