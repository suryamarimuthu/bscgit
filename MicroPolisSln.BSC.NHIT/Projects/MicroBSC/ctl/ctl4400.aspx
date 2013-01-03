<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4400.aspx.cs" Inherits="ctl_ctl4400" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script  type="text/javascript">
function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    { 
       var cell             = igtbl_getElementById(id);
       var row              = igtbl_getRowById(id);
       var band             = igtbl_getBandById(id);
       var active           = igtbl_getActiveRow(id);
       cell.style.cursor    = 'hand';
    }
}
 
</script>        

<!--- MAIN START --->
<table width="100%" style="height: 100%;">
    <tr>
        <td valign="top" style="height: 100%; width: 350px;">
            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                        </RowTemplateStyle>
                        <Columns>
                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                <CellTemplate>
                                    <asp:CheckBox ID="cBox" runat="server" />
                                </CellTemplate>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn BaseColumnName="UNIT_TYPE" HeaderText="Unit그룹명" Key="UNIT_TYPE"
                                Width="170px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="Unit그룹명">
                                    
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                    <%--<GroupByBox>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                </DisplayLayout>
            </ig:UltraWebGrid>    
        </td>
        <td valign="top">
            <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                        </RowTemplateStyle>
                        <Columns>
                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                <CellTemplate>
                                    <asp:CheckBox ID="cBox" runat="server" />
                                </CellTemplate>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn HeaderText="수정" Key="MODIFY" Width="30px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="수정">
                                    
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="UNIT" HeaderText="UNIT" Key="UNIT" Width="50px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="단위">
                                    
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="FORMAT_STRING" HeaderText="FORMAT" Key="FORMAT_STRING"
                                Width="80px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="형식">
                                    
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="DECIMAL_POINT" HeaderText="DECIMAL" Key="DECIMAL_POINT"
                                Width="60px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="기본값">
                                    
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <CellStyle HorizontalAlign="Right" />
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ROUNDING_TYPE" HeaderText="ROUNDING" Key="ROUNDING_TYPE"
                                Width="100px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="반올림 자릿수">
                                    
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:TemplatedColumn BaseColumnName="USE_YN" HeaderText="USE" Key="USE_YN" Width="80px">
                                <CellTemplate>
                                    <asp:CheckBox ID="useBox" runat="server" />
                                </CellTemplate>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <Header Caption="사용여부">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <HeaderStyle HorizontalAlign="Center" />
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn BaseColumnName="UNIT_TYPE_REF_ID" Hidden="True" Key="UNIT_TYPE_REF_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                    <%--<GroupByBox>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                </DisplayLayout>
            </ig:UltraWebGrid>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 350px;">
            <asp:panel id="pnlUnitType" runat="server" Width="100%">
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="cssTblTitle">그룹명</td>
                        <td class="cssTblContent" style="border-right-style:none;">
                            <asp:TextBox id="txtUnitGroup" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td class="cssTblContent" align="right" style=" border-left-style:none; text-align:right; vertical-align:middle;">
                            <asp:ImageButton id="iBtnUnitTypeModify" onclick="iBtnUnitTypeModify_Click" runat="server" ImageUrl="../images/btn/b_002.gif" 
                            />&nbsp;<asp:imagebutton id="iBtnUnitTypeRemove" onclick="iBtnUnitTypeRemove_Click" runat="server" ImageUrl="../images/btn/b_004.gif" />&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:panel>
        </td>
        <td align="right">
            <asp:panel id="pnlUnit" runat="server" Visible="False" Width="200px" Height="25px">
                <table style="height: 30px;" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td>
                            <asp:Literal id="ltrEmpAdd" runat="server"></asp:Literal>&nbsp;<asp:imagebutton id="iBtnUnitRemove" onclick="iBtnUnitRemove_Click" runat="server" ImageUrl="../images/btn/b_004.gif"></asp:imagebutton>&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:panel>
        </td>
    </tr>
</table>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:hiddenfield id="hdfUnitGroup" runat="server"></asp:hiddenfield>
<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>

</asp:Content>