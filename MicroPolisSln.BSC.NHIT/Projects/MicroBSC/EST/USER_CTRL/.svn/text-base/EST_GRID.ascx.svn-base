<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EST_GRID.ascx.cs" Inherits="EST_USER_CTRL_EST_GRID" %>
<asp:Literal ID="ltrJScript" runat="server"></asp:Literal>
<table width="97%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td height="20">
            <asp:Image ID="imgTitle" runat="server" ImageAlign="AbsMiddle" /> <asp:Label ID="lblTitle" runat="server" Font-Bold="true"></asp:Label>
        </td>
    </tr>
</table>
<ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100px" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
    <Bands>
        <ig:UltraGridBand>
            <Columns>
                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No">
                    <CellTemplate>
                        <asp:CheckBox ID="cBox" runat="server" />
                    </CellTemplate>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                    </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Center"  />
                </ig:TemplatedColumn>
            </Columns>
            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
            <RowTemplateStyle BorderColor="White" BackColor="White">
                <BorderDetails WidthRight="0px" WidthLeft="0px" WidthTop="0px" WidthBottom="0px"></BorderDetails>
            </RowTemplateStyle>
        </ig:UltraGridBand>
    </Bands>
    <DisplayLayout  CellPaddingDefault="2" 
                    AllowColSizingDefault="Free" 
                    AllowDeleteDefault="Yes"
                    AllowSortingDefault="NotSet" 
                    BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="NotSet" 
                    Name="ctl00xUltraWebGrid1" 
                    RowHeightDefault="22px"
                    RowSelectorsDefault="No" 
                    SelectTypeRowDefault="Extended" 
                    Version="4.00" 
                    ScrollbarView="Both"
                    CellClickActionDefault="RowSelect" 
                    TableLayout="Fixed" 
                    StationaryMargins="Header" 
                    AutoGenerateColumns="False">
       <%-- <GroupByBox>
            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
        </GroupByBox>
        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
        </GroupByRowStyleDefault>
        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
            <BorderDetails ColorTop="White" WidthTop="1px" />
        </FooterStyleDefault>
        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
            <Padding Left="3px" />
        </RowStyleDefault>
        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
        </HeaderStyleDefault>
        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
        </EditCellStyleDefault>
        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100px"
            Width="100%">
        </FrameStyle>
        <Pager>
            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
            </PagerStyle>
        </Pager>
        <AddNewBox Hidden="False">
            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
            </BoxStyle>
        </AddNewBox>
        <SelectedRowStyleDefault BackColor="#E2ECF4">
        </SelectedRowStyleDefault>--%>
        <RowStyleDefault  CssClass="GridRowStyle" />
        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
        <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="DblClickHandler"/>
        <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
    </DisplayLayout>
</ig:UltraWebGrid> 