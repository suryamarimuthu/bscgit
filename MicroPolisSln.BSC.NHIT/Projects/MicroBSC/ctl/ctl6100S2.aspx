<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CTL6100S2.aspx.cs" Inherits="CTL_CTL6100S2" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>


<form id="form" runat="server">
<div>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <table cellpadding="0" cellspacing="0" border="0" height="100%" Width="100%">
        <tr>
            <td>
                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" height="100%" Width="100%">
                    <tr>
                        <td class="cssTblTitle">
                            사용자 쿼리
                        </td>
                        
                        <td class="cssTblContent" style="width:85%;">
                            <asp:textbox id="userQuery" runat="server" bordercolor="Silver" borderwidth="1px" width="100%" textmode="MultiLine" height="60px"></asp:textbox>
                        </td>
                    </tr>
                    <tr id="exMsgRow">
                        <td class="cssTblTitle">
                            메시지
                        </td>
                        <td class="cssTblContent">
                        <asp:Label id="exMsg" runat="server" text=""></asp:Label>&nbsp;
                            <%--<asp:textbox id="exMsg" runat="server" bordercolor="Silver" borderwidth="1px" width="100%" textmode="MultiLine" height="60px"></asp:textbox>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr style="height:25px;"> 
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                            <asp:ImageButton id="ibtnRun" onclick="ibtnRun_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" visible="true"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        
        <tr style="height:100%;">
            <td>
                <ig:UltraWebGrid id="UltraWebGrid" runat="server" Width="100%" Height="100%">
                    <DisplayLayout  CellPaddingDefault="2"
                                    ReadOnly="LevelTwo"
                                    AllowColSizingDefault="Free"
                                    AllowSortingDefault="Yes"
                                    HeaderClickActionDefault="SortMulti"
                                    RowSelectorsDefault="No"
                                    TableLayout="Fixed"
                                    StationaryMargins="Header"
                                    NoDataMessage=" "
                                    NullTextDefault=" "
                                    OptimizeCSSClassNamesOutput="False">
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        
        <tr style="height:25px;">
            <td align="right">
                <asp:imagebutton id="ibtnDownExcel" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif" onclick="ibtnDownExcel_Click" Visible="false"></asp:imagebutton>                        
            </td>
        </tr>
    </table>
    
    <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server"></ig:UltraWebGridExcelExporter>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    
    
    <MenuControl:MenuControl_Bottom id="MenuControl_Bottom1" runat="server" />
</div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>