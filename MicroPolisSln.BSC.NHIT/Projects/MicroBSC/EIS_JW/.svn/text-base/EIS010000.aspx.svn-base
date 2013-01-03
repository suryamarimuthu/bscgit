<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS010000.aspx.cs" Inherits="EIS_JW_EST010100" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td class="tableoutBorder">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="center" class="tableTitle" style="width:80px">
                        평가기간
                    </td>
                    <td class="tableContent">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="conditional" RenderMode="inline">
							<ContentTemplate>
                                <asp:DropDownList ID="ddlEstRefID" Width="120px" runat="server" CssClass="box01"
                                    onselectedindexchanged="ddlEstRefID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </ContentTemplate>
						</asp:UpdatePanel>
                    </td>
                    <td align="center" class="tableTitle" style="width:60px">
                        년월
                    </td>
                    <td class="tableContent">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="conditional" RenderMode="inline">
							<ContentTemplate>
                                <asp:DropDownList ID="ddlYMD"   Width="80px" runat="server" CssClass="box01"></asp:DropDownList>
                            </ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="ddlEstRefID" EventName="SelectedIndexChanged" />
							</Triggers>
						</asp:UpdatePanel>
                    </td>
                    <td align="center" class="tableTitle" style="width:70px">
                        사업장
                    </td>
                    <td class="tableContent">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" RenderMode="inline">
							<ContentTemplate>
								<asp:DropDownList ID="ddlMain"   Width="100px" runat="server" CssClass="box01" 
                                    onselectedindexchanged="ddlMain_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
							</ContentTemplate>
						</asp:UpdatePanel>
                    </td>
                    <td align="center" class="tableTitle" style="width:60px">
                        구분
                    </td>
                    <td class="tableContent">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional" RenderMode="inline">
							<ContentTemplate>
								<asp:DropDownList ID="ddlSub" Width="150px" runat="server" CssClass="box01"></asp:DropDownList>
							</ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="ddlMain" EventName="SelectedIndexChanged" />
							</Triggers>
						</asp:UpdatePanel>
                    </td>
                    <td class="tableContent" align="right" style="width:100px;">
                        <asp:ImageButton ID="ibnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<iframe id="ifmContent" runat="server" frameborder="0" style="overflow: auto; width: 100%; height: 94%" scrolling="auto"></iframe>
<!--- MAIN END --->
</asp:Content>