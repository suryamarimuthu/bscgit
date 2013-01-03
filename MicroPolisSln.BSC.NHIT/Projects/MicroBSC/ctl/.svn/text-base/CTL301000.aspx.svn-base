<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CTL301000.aspx.cs" Inherits="CTL_CTL101000" MasterPageFile="~/_common/lib/MicroBSC.master"  enableEventValidation="false"%>

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

    function OpenInsertWindow()
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow('CTL301010.aspx?iType=A&ROLE_REF_ID=0&CCB1='+ICCB1, 650, 250);
    }     
    
    function OpenRoleInfoWindow(type,role_ref_id)
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow("CTL301010.aspx?iType=" + type + "&ROLE_REF_ID=" + role_ref_id + "&CCB1=" + ICCB1, 650, 250);
    }    
</script>        

 <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" width="100%" height="100%">
        <tr>
            <td style="width:280px;" >
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="권한 리스트" />
                        </td>
                    </tr>
                </table>
                <%--<img src="../images/title/ta_t25.gif" alt="" />--%>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="Label3" runat="server" style="font-weight:bold" text="메뉴 리스트" />
                        </td>
                    </tr>
                </table>
                <%--<img alt="" src="../images/title/ta_t24.gif" style="vertical-align:middle" />--%>
            </td>
        </tr>
        <tr style="height:100%;">
            <td valign="top" style="width: 279px">
            <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Height="100%" Width="100%" style="left: -140px; top: 64px" OnSelectedRowsChange="UltraWebGrid2_SelectedRowsChange" OnInitializeRow="UltraWebGrid2_InitializeRow">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                    </RowTemplateStyle>
                    <Columns>
                        <ig:TemplatedColumn AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No" Key="selchk"
                            Width="30px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                            </HeaderTemplate>
                            <CellTemplate>
                                <asp:CheckBox ID="cBox" runat="server" />
                            </CellTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_UPDATE" HeaderText="수정" Key="ROLE_UPDATE"
                            Width="40px">
                            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                            </CellStyle>
                            <Header Caption="수정">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_NAME" HeaderText="권한" Key="ROLE_NAME"
                            Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="권한">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_DESC" HeaderText="권한 설명" Hidden="True"
                            Key="ROLE_DESC" Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="권한 설명">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_REF_ID" Hidden="True" Key="ROLE_REF_ID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DELETE_ENABLED_YN" Hidden="True" Key="DELETE_ENABLED_YN">
                            <Header>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                </ig:UltraGridBand>
            </Bands>
            <DisplayLayout CellPaddingDefault="2" 
                            AllowColSizingDefault="Free" 
                            BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="NotSet" 
                            Name="UltraWebGrid2" 
                            RowHeightDefault="20px"
                            RowSelectorsDefault="No" 
                            SelectTypeRowDefault="Extended" 
                            Version="4.00" 
                            TableLayout="Fixed" 
                            StationaryMargins="Header" 
                            AutoGenerateColumns="False" CellClickActionDefault="RowSelect">
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
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
                    </SelectedRowStyleDefault>
                    <ActivationObject BorderColor="" BorderWidth="">
                    </ActivationObject>--%>
                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                </DisplayLayout>
        </ig:UltraWebGrid>
                <asp:HiddenField ID="hdfRoleRefID" runat="server" />
            </td>
            <td valign="top">
            <DIV style="BORDER-RIGHT: #f4f4f4 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #f4f4f4 1px solid; DISPLAY: block; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; OVERFLOW: auto; BORDER-LEFT: #f4f4f4 1px solid; WIDTH: 100%; PADDING-TOP: 2px; BORDER-BOTTOM: #f4f4f4 1px solid; HEIGHT: 100%" id="Div1">
            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                    </RowTemplateStyle>
                    <Columns>
                        <ig:TemplatedColumn AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No" Key="selchk"
                            Width="30px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                            </HeaderTemplate>
                            <CellTemplate>
                                <asp:CheckBox ID="cBox" runat="server" />
                            </CellTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_REF_ID" HeaderText="Key" Hidden="True"
                            Key="MENU_REF_ID" Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="Key">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="UP_MENU_ID" HeaderText="부모" Hidden="True"
                            Key="UP_MENU_ID" Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="부모">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_NAME" HeaderText="메뉴명" Key="MENU_NAME"
                            Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="메뉴명">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_PAGE_NAME" HeaderText="파일명" Key="MENU_PAGE_NAME"
                            Width="120px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="파일명">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_FULL_PATH" HeaderText="전체경로" Key="MENU_FULL_PATH"
                            Width="160px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="전체경로">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_TYPE_NAME" HeaderText="메뉴타입" Hidden="True"
                            Key="MENU_TYPE_NAME" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="메뉴타입">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_DESC" HeaderText="설명" Hidden="True" Key="MENU_DESC"
                            Width="120px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="설명">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EDIDX" Hidden="True" Key="EDIDX">
                            <Header>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                </ig:UltraGridBand>
            </Bands>
            <DisplayLayout CellPaddingDefault="2" 
                            AllowColSizingDefault="Free" 
                            AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" 
                            BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="NotSet" 
                            Name="UltraWebGrid1" 
                            RowHeightDefault="20px"
                            RowSelectorsDefault="No" 
                            SelectTypeRowDefault="Extended" 
                            Version="4.00" 
                            CellClickActionDefault="RowSelect" 
                            TableLayout="Fixed" 
                            StationaryMargins="Header" 
                            AutoGenerateColumns="False">
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
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
                    </SelectedRowStyleDefault>
                    <ActivationObject BorderColor="" BorderWidth="">
                    </ActivationObject>--%>
                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                </DisplayLayout>
            </ig:UltraWebGrid>
            <SJ:SmartScroller ID="SmartScroller1" runat="server" MaintainScrollX="true" MaintainScrollY="true" TargetObject="Div1">
                <input name="SmartScroller1_ScrollY" type="hidden" value="0"><input name="SmartScroller1_ScrollX" type="hidden" value="0">
            </SJ:SmartScroller>
            </DIV>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" />&nbsp;
                <asp:ImageButton ID="iBtnRemove" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnRemove_Click" />
            </td>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="매핑된 메뉴 : "></asp:Label>
                <asp:Label ID="lblMapCnt" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text=" 개"></asp:Label>&nbsp; &nbsp;
                <asp:ImageButton ID="iBtnSave" runat="server" align="absmiddle" ImageUrl="../images/btn/b_007.gif" OnClick="iBtnSave_Click" />
            </td>
        </tr>
        
    </table>

                                           
<asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click" Visible="false"></asp:linkbutton>
<asp:literal id="lblScript" runat="server"></asp:literal>&nbsp;

<!--- MAIN END --->

</asp:Content>