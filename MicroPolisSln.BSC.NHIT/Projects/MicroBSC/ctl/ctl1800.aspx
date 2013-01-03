<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl1800.aspx.cs" Inherits="ctl_ctl1800" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
    <tr>
      <td valign="top" align="left" style="width:100%; height:90%;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" CssClass="tableBorder"><Columns>
            <asp:BoundField DataField="SYS_CATEGORY_NAME" HeaderText="카테고리">
            <ItemStyle Width="250px" HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Width="250px" HorizontalAlign="Center" CssClass="tableTitle"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="내      용">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle HorizontalAlign="Center" CssClass="tableTitle"></HeaderStyle>
            <ItemTemplate>
                <asp:GridView id="gView_Sub" runat="server" OnRowDataBound="gView_Sub_RowDataBound" Width="100%" AutoGenerateColumns="False" CssClass="tableBorder">
                    <Columns>
                        <asp:BoundField DataField="SYS_NAME" HeaderText="설정명">
                        <ItemStyle Width="40%" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle Width="40%" HorizontalAlign="Center" CssClass="tableTitle"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="SYS_DESC" HeaderText="설정 설명">
                        <ItemStyle Width="40%" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle Width="40%" HorizontalAlign="Center" CssClass="tableTitle"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="설정값">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center" CssClass="tableTitle"></HeaderStyle>
                            <ItemTemplate>
                                <asp:RadioButtonList id="rBtnColSys_Sub" runat="server" RepeatDirection="Horizontal" DataTextField="SYS_CTRL_VALUE" DataValueField="SYS_CTRL_KEY"></asp:RadioButtonList> 
                                <asp:DropDownList runat="server" id="ddlColSys_Sub" DataTextField="SYS_CTRL_VALUE" DataValueField="SYS_CTRL_KEY"></asp:DropDownList>
                                <asp:Literal id="ltrSysKey_Sub" runat="server" ></asp:Literal> 
                                <asp:Literal id="ltrSysCtrlType_Sub" runat="server" ></asp:Literal> 
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView> 
            
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>

            <HeaderStyle Font-Bold="False"></HeaderStyle>
            </asp:GridView>
      </td>
    </tr>
    <tr>
      <td style="height:10%;">
         <table width=100%>
             <tr>
                 <td align="right">
                        <br />
                        <asp:imagebutton runat="server" ID="btnSave" OnClick="btnSave_Click" ImageUrl="../images/btn/b_007.gif"></asp:imagebutton>
                        &nbsp; &nbsp;
                 </td>
             </tr>
         </table>        
         <asp:literal id="ltrScript" runat="server"></asp:literal>
      </td>
    </tr>
</table>

        <!--- MAIN END --->
</asp:Content>