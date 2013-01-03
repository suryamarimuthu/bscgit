<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr1005.aspx.cs" Inherits="usr_usr1006" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="width: 1000px; border: 0; padding: 0; margin-top: -10px;"></td>
    </tr>
    <tr>
        <td style="width: 100%; border: 0; padding: 0;">
            <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="cssTblTitle">
                        평가기간
                    </td>
                    <td class="cssTblContent" style="border-right:none;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEstTermInfo" Width="100%" runat="server" CssClass="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                   <asp:UpdatePanel ID="udpMonth" runat="server" UpdateMode="Conditional" RenderMode="Block">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlMonthInfo"   Width="100%" runat="server" CssClass="box01"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers >
                                            <asp:AsyncPostBackTrigger ControlID="ddlEstTermInfo" />
                                        </Triggers>
                                   </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:CheckBox     ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" />        
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                    <td class="cssTblContent">&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:25px;">
        <td align="right">
        <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;" Visible="false">
                <asp:ListItem Text="목표(Target)" Value="TARGET" Selected="True"></asp:ListItem>
                <asp:ListItem Text="의지목표(Goal)" Value="GOAL"></asp:ListItem>
            </asp:RadioButtonList>&nbsp;&nbsp;
            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
        </td>
    </tr>
</table>
<iframe id="ifmDeptOrg" runat="server" frameborder="0" style="overflow: auto; width: 100%; height: 89%; padding: 2px;" scrolling="auto">
</iframe>
</asp:Content>