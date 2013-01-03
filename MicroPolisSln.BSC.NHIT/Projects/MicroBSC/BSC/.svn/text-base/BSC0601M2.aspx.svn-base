<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0601M2.aspx.cs" Inherits="BSC_BSC0601M2"  MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
<!--- MAIN START --->	
  <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; text-align:left; border-collapse:collapse;">
    <tr style="height:25px;">
      <td style="width:30%;">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                <td>Data Source</td>
            </tr>
        </table>
        
      </td>
      <td>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                <td>Data Source 상세</td>
            </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td style="vertical-align:top;">
        <ig:UltraWebGrid ID="ugrdSourceData" runat="server" Width="100%" Height="100%"  OnClick="ugrdSourceData_Click" OnInitializeRow="ugrdSourceData_InitializeRow">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <Columns>
                        <ig:UltraGridColumn BaseColumnName="SOURCE_ID" Key="SOURCE_ID" Width="60px">
                            <Header Caption="ID">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SOURCE_NAME" Key="SOURCE_NAME" Width="180px">
                            <Header Caption="NAME">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                    </RowTemplateStyle>
                </ig:UltraGridBand>
            </Bands>
             <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="ugrdSourceData" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                    OptimizeCSSClassNamesOutput="False">
                    <%--
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="25px">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                        BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                    <GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                    </GroupByBox>
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                 <ClientSideEvents />
                </DisplayLayout>
        </ig:UltraWebGrid>
      </td>
      <td style="vertical-align:top;">
        <table class="tableBorder" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
          <tr style="height:22px;">
            <td class="cssTblTitle" style="width:30%;">Source Name</td>
            <td class="cssTblContent" style="width:70%;">
                <asp:TextBox ID="txtSOURCE_NAME" runat="server" Width="100%"></asp:TextBox>
            </td>
          </tr>
          <tr style="height:22px;">
            <td class="cssTblTitle">Database Type</td>
            <td class="cssTblContent">
                <asp:DropDownList ID="ddlSOURCE_TYPE" runat="server" Width="45%" AutoPostBack="True" OnSelectedIndexChanged="ddlSOURCE_TYPE_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddlPROVIDER" runat="server" Width="45%"></asp:DropDownList>
            </td>
          </tr>
          <tr style="height:22px;">
            <td class="cssTblTitle">Data Source</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtDATA_SOURCE" runat="server" Width="100%" Height="100%" TextMode="SingleLine"></asp:TextBox>
            </td>
          </tr>
          <tr style="height:22px;">
            <td class="cssTblTitle">Initial Catalog</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtINITIAL_CATALOG" runat="server" Width="100%" Height="100%" TextMode="SingleLine"></asp:TextBox>
            </td>
          </tr>
          <tr style="height:22px;">
            <td class="cssTblTitle">User Id</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtUSER_ID" runat="server" Width="100%" Height="100%" TextMode="SingleLine"></asp:TextBox>
            </td>
          </tr>
          <tr style="height:22px;">
            <td class="cssTblTitle">Password</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtPASSWORD" runat="server" Width="100%" Height="100%" TextMode="Password"></asp:TextBox>
            </td>
          </tr>
          <tr style="height:50px;">
            <td class="cssTblTitle">Extended Properties</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtEXTENDED_PROPERTIES" runat="server" Width="100%" Height="100%" TextMode="multiLine"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="cssTblTitle">Descriptions</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtDESCRIPTIONS" runat="server" Width="100%" Height="100%" TextMode="multiLine"></asp:TextBox>
            </td>
          </tr>
          <tr style="height:150px;">
            <td class="cssTblTitle">Connection Test</td>
            <td class="cssTblContent">
                <asp:TextBox ID="txtConnectionResult" runat="server" Width="100%" Height="100%" TextMode="multiLine" ReadOnly="true" BackColor="whitesmoke"></asp:TextBox>
            </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td style="height:30px; text-align:right;" align="right" colspan="2">
        <asp:ImageButton ImageUrl="~/images/btn/b_156.gif" ID="iBtnNew" runat="server" OnClick="iBtnNew_Click" />
        <asp:ImageButton ImageUrl="~/images/btn/b_214.gif" ID="iBtnConnect" runat="server" OnClick="iBtnConnect_Click" />
        <asp:ImageButton ImageUrl="~/images/btn/b_001.gif" ID="iBtnInsert" runat="server" OnClick="iBtnInsert_Click" />
        <asp:ImageButton ImageUrl="~/images/btn/b_002.gif" ID="iBtnUpdate" runat="server" OnClick="iBtnUpdate_Click" />
        <asp:ImageButton ImageUrl="~/images/btn/b_004.gif" ID="iBtnDelete" runat="server" OnClick="iBtnDelete_Click" />   
        <asp:ImageButton ImageUrl="~/images/btn/b_138.gif" ID="iBtnReUse" runat="server" OnClick="iBtnReUse_Click" />              
      </td>
    </tr>
  </table>
  <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
<!--- MAIN END --->
</asp:Content>
