<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl3100.aspx.cs" Inherits="ctl_ctl3100" MasterPageFile="~/_common/lib/MicroBSC.master" enableEventValidation="false" %>

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

    function Valid() 
    {
        var ddlRole ="<%= PageUtility.GetByValueDropDownList(ddlRoles) %>";
        
        if(ddlRole == '') 
        {
            alert('등록할 권한이 없습니다.');
            return false;
        }
        
        return true;
    }        

    function OpenInsertWindow()
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow('CTL301020.aspx?iType=A&ROLE_REF_ID=0&CCB1='+ICCB1, 650, 460);
    }     
    
    function OpenMenuInfoWindow(type,menu_ref_id)
    {
        var ICCB1 = "<%= this.ICCB1 %>";
        gfOpenWindow("CTL301020.aspx?iType=" + type + "&MENU_REF_ID=" + menu_ref_id + "&CCB1=" + ICCB1, 650, 460);
    }    
    
</script>        

 <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" width="100%" height="100%">
        <tr>
            <td style="height:20px; width:540px;" ><img src="../images/title/ta_t24.gif" alt="" /></td>
            <td><img alt="" src="../images/title/ta_t25.gif" style="vertical-align:middle" /></td>
        </tr>
        <tr>
            <td valign="top" style="width: 540px">
            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
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
                        <ig:UltraGridColumn BaseColumnName="MENU_UPDATE" HeaderText="수정" Key="MENU_UPDATE"
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
                        <ig:UltraGridColumn BaseColumnName="MENU_REF_ID" HeaderText="Key" Hidden="True"
                            Key="MENU_REF_ID" Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="Key">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="UP_MENU_ID" HeaderText="부모" Hidden="True"
                            Key="UP_MENU_ID" Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="부모">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_NAME" HeaderText="메뉴명" Key="MENU_NAME"
                            Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="메뉴명">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_PAGE_NAME" HeaderText="파일명" Key="MENU_PAGE_NAME"
                            Width="80px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="파일명">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_FULL_PATH" HeaderText="전체경로" Key="MENU_FULL_PATH"
                            Width="165px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="전체경로">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_TYPE_NAME" HeaderText="메뉴타입" Hidden="True"
                            Key="MENU_TYPE_NAME" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="메뉴타입">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="MENU_DESC" HeaderText="설명" Hidden="True" Key="MENU_DESC"
                            Width="120px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="설명">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EDIDX" Hidden="True" Key="EDIDX">
                            <Header>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="10" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="10" />
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
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                    </Pager>
                    <AddNewBox Hidden="False">
                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                    </AddNewBox>
                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                    </SelectedRowStyleDefault>
                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                <ActivationObject BorderColor="" BorderWidth="">
                </ActivationObject>
                </DisplayLayout>
            </ig:UltraWebGrid>   
             </td>
            <td valign="top">
            <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Height="100%" Width="100%">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                    </RowTemplateStyle>
                    <Columns>
                        <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No">
                            <CellTemplate>
                                <asp:CheckBox ID="cBox" runat="server" />
                            </CellTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center"  />
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_NAME" Key="ROLE_NAME" Width="200">
                            <Header Caption="권한">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"/>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_DESC" Key="ROLE_DESC" Width="150" Hidden="true">
                            <Header Caption="권한 설명">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"/>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ROLE_REF_ID" Key="ROLE_REF_ID" Hidden="True">
                            <Header>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
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
                            ReadOnly="LevelTwo"
                            CellClickActionDefault="NotSet" 
                            TableLayout="Fixed" 
                            StationaryMargins="Header" 
                            AutoGenerateColumns="False">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="white">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                        Width="100%">
                    </FrameStyle>
                    <Pager>
                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                    </Pager>
                    <AddNewBox Hidden="False">
                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                        </Style>
                    </AddNewBox>
                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                    </SelectedRowStyleDefault>
                </DisplayLayout>
        </ig:UltraWebGrid>
            </td>
        </tr>
        <tr >
            <td align="right" style="height:40px; width: 540px;">
                <asp:hiddenfield id="hdfMenu_Ref_ID" runat="server"></asp:hiddenfield>
                <img alt="" src="../images/btn/b_005.gif" style="cursor:hand;" onclick="OpenInsertWindow();" />
                    &nbsp;<asp:ImageButton ID="iBtnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnDelete_Click" />&nbsp;
            </td>
            <td align=right >
                <table width="100%" id="tblRole" runat="server" visible="false" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" align="left">
                            <asp:dropdownlist id="ddlRoles" runat="server" class="box01"></asp:dropdownlist><asp:ImageButton id="iBtnAdd" runat="server" ImageUrl="../images/btn/b_005.gif" onclick="iBtnAdd_Click" ></asp:ImageButton>&nbsp;<asp:imagebutton id="iBtnRemove" onclick="iBtnRemove_Click" runat="server" ImageUrl="../images/btn/b_004.gif"></asp:imagebutton></td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
    <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click" Visible="false"></asp:linkbutton>
<asp:literal id="lblScript" runat="server"></asp:literal>&nbsp;

<!--- MAIN END --->

</asp:Content>