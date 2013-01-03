<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Main_Table.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Main_Table" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">


    <!--- MAIN START --->
<asp:Panel ID="pnlAll" runat="server" Width="100%" Height="100%" HorizontalAlign="Left" BorderWidth="0">
  <table cellpadding="0" cellspacing="0" border="0" width="100%;" style="height:100%;">
    <tr>
      <td align="left" style="vertical-align:top;">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
          <tr>
            <td>
                <table cellspacing="0" border="0" width="100%"> 
                    <tr>
                        <td class="cssPopBtnLine">
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle"/>
                        </td>
                    </tr>
                </table>
            </td>
          </tr>
          <tr>
            <td style="height:100%;">
                <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                    <tr>
                        <td style="width:39%;height:100%;">
                            <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="전사 매출/손익"/></td>
                                                <td align="right"><asp:Label ID="Label3" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:31%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_THREE_NAME" Key="GRP_THREE_NAME" Width="90px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TARGET_YEAR" Key="TARGET_YEAR" Width="80px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DAL_RATE" Key="DAL_RATE" Width="80px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" 
                                                           AllowColumnMovingDefault="OnServer" 
                                                           AllowDeleteDefault="Yes"
                                                           AllowSortingDefault="Yes" 
                                                           BorderCollapseDefault="Separate"
                                                           HeaderClickActionDefault="SortMulti" 
                                                           Name="UltraWebGrid1" 
                                                           RowHeightDefault="20px"
                                                           RowSelectorsDefault="No" 
                                                           SelectTypeRowDefault="Extended" 
                                                           Version="4.00" 
                                                           CellClickActionDefault="RowSelect" 
                                                           TableLayout="Fixed" 
                                                           StationaryMargins="Header" 
                                                           OptimizeCSSClassNamesOutput="False"
                                                           ReadOnly = "LevelTwo"
                                                           ColFootersVisibleDefault="Yes"
                                                           AutoGenerateColumns="False">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:5px;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="인력정산"/></td>
                                                <td align="right"><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="(단위:%)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:69%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" Height="100%" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="CR_MONTH_NAME" Key="CR_MONTH_NAME" Width="60px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TARGET_FULL_RATE" Key="TARGET_FULL_RATE" Width="80px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="가득 목표율">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_FULL_RATE" Key="RESULT_FULL_RATE" Width="80px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="가득율">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_DONG_RATE" Key="RESULT_DONG_RATE" Width="80px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="가동율">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_BDONG_RATE" Key="RESULT_BDONG_RATE" Width="80px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="비가동">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" 
                                                           AllowColumnMovingDefault="OnServer" 
                                                           AllowDeleteDefault="Yes"
                                                           AllowSortingDefault="Yes" 
                                                           BorderCollapseDefault="Separate"
                                                           HeaderClickActionDefault="SortMulti" 
                                                           Name="UltraWebGrid2" 
                                                           RowHeightDefault="20px"
                                                           RowSelectorsDefault="No" 
                                                           SelectTypeRowDefault="Extended" 
                                                           Version="4.00" 
                                                           CellClickActionDefault="RowSelect" 
                                                           TableLayout="Fixed" 
                                                           StationaryMargins="Header" 
                                                           OptimizeCSSClassNamesOutput="False"
                                                           ReadOnly = "LevelTwo"
                                                           ColFootersVisibleDefault="Yes"
                                                           AutoGenerateColumns="False">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:1%;">
                        </td>
                        <td style="width:60%;">
                            <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label4" runat="server" Font-Bold="true" Text="고객별 매출현황"/></td>
                                                <td align="right"><asp:Label ID="Label5" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:30%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid3" runat="server" Width="100%" Height="100%" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="85px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_YEAR" Key="ME_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_TS" Key="ME_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_RESULT_TS" Key="ME_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_DAL_RATE" Key="ME_DAL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>                                                       
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_TS" Key="YG_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_RESULT_TS" Key="YG_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_DAL_RATE" Key="YG_DAL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" 
                                                           AllowColumnMovingDefault="OnServer" 
                                                           AllowDeleteDefault="Yes"
                                                           AllowSortingDefault="Yes" 
                                                           BorderCollapseDefault="Separate"
                                                           HeaderClickActionDefault="SortMulti" 
                                                           Name="UltraWebGrid3" 
                                                           RowHeightDefault="20px"
                                                           RowSelectorsDefault="No" 
                                                           SelectTypeRowDefault="Extended" 
                                                           Version="4.00" 
                                                           CellClickActionDefault="RowSelect" 
                                                           TableLayout="Fixed" 
                                                           StationaryMargins="Header" 
                                                           OptimizeCSSClassNamesOutput="False"
                                                           ReadOnly = "LevelTwo"
                                                           ColFootersVisibleDefault="Yes"
                                                           AutoGenerateColumns="False">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:5px;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label6" runat="server" Font-Bold="true" Text="사업유형별 매출현황"/></td>
                                                <td align="right"><asp:Label ID="Label7" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:30%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid4" runat="server" Width="100%" Height="100%" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="85px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_YEAR" Key="ME_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_TS" Key="ME_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_RESULT_TS" Key="ME_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_DAL_RATE" Key="ME_DAL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>                                                       
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_TS" Key="YG_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_RESULT_TS" Key="YG_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_DAL_RATE" Key="YG_DAL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" 
                                                           AllowColumnMovingDefault="OnServer" 
                                                           AllowDeleteDefault="Yes"
                                                           AllowSortingDefault="Yes" 
                                                           BorderCollapseDefault="Separate"
                                                           HeaderClickActionDefault="SortMulti" 
                                                           Name="UltraWebGrid4" 
                                                           RowHeightDefault="20px"
                                                           RowSelectorsDefault="No" 
                                                           SelectTypeRowDefault="Extended" 
                                                           Version="4.00" 
                                                           CellClickActionDefault="RowSelect" 
                                                           TableLayout="Fixed" 
                                                           StationaryMargins="Header" 
                                                           OptimizeCSSClassNamesOutput="False"
                                                           ReadOnly = "LevelTwo"
                                                           ColFootersVisibleDefault="Yes"
                                                           AutoGenerateColumns="False">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label8" runat="server" Font-Bold="true" Text="본부별 매출현황"/></td>
                                                <td align="right"><asp:Label ID="Label9" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:40%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid5" runat="server" Width="100%" Height="100%" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="85px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_YEAR" Key="ME_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_TS" Key="ME_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_RESULT_TS" Key="ME_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_DAL_RATE" Key="ME_DAL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>                                                       
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_TS" Key="YG_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_RESULT_TS" Key="YG_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_DAL_RATE" Key="YG_DAL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" 
                                                           AllowColumnMovingDefault="OnServer" 
                                                           AllowDeleteDefault="Yes"
                                                           AllowSortingDefault="Yes" 
                                                           BorderCollapseDefault="Separate"
                                                           HeaderClickActionDefault="SortMulti" 
                                                           Name="UltraWebGrid5" 
                                                           RowHeightDefault="20px"
                                                           RowSelectorsDefault="No" 
                                                           SelectTypeRowDefault="Extended" 
                                                           Version="4.00" 
                                                           CellClickActionDefault="RowSelect" 
                                                           TableLayout="Fixed" 
                                                           StationaryMargins="Header" 
                                                           OptimizeCSSClassNamesOutput="False"
                                                           ReadOnly = "LevelTwo"
                                                           ColFootersVisibleDefault="Yes"
                                                           AutoGenerateColumns="False">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                 
            </td>
          </tr>
          <tr>
            <td align="left">
              <div style=" overflow:auto; width:100%; height:100%;">
                 <table border="0" cellspacing="0" cellpadding="0" style="width:100%; height:100%">
                  <tr>
                    <td style="vertical-align:top;">
                      <div runat="server" id="block0" style="display: block; margin-left: 1px; height:230px;"> 
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                                <td style="height:5px;" colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width:385px">
                                    <DCWC:Chart ID="chartMM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                        <ChartAreas>
                                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="True"/>
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY2>
                                            </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                                            </DCWC:Legend>
                                        </Legends>
                                    </DCWC:Chart>
                                </td>
                                <td align="left">
                                    
                                </td>
                            </tr>
                        </table>
                      </div>
                    </td>
                  </tr>
                 
                 </table>
              </div>
            </td>
          </tr>
          <tr>
            <td style="height:20px;" align="left">
                <%--<table style="height:100%; width:772px;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <img alt="실적정보 그래프 숨기기"  src="../images/btn/b_tp01_1.gif" style="CURSOR: hand;"  onclick="clickshow(0)" id="img0" name="img0"  />
                            <img alt="실적정보 상세 숨기기"  src="../images/btn/b_tp02_1.gif" style="CURSOR: hand;" onclick="clickshow(1)"  id="img1" name="img1"   /> 
                            <img alt="원인분석 및 대책검토 숨기기"  src="../images/btn/b_tp03_1.gif" style="CURSOR: hand;" onclick="clickshow(2)"  id="img2" name="img2" /> 
                            <img alt="Communication 숨기기"  src="../images/btn/b_tp04_1.gif" style="CURSOR: hand;" onclick="clickshow(3)"  id="img3" name="img3" /> 
                        </td>
                        <td align="right">
                            <img alt="" src="../images/btn/b_049.gif" onclick="OpenShowRelationKpi();" style="cursor:hand; visibility:hidden;" /> 
                            <asp:ImageButton ID="iBtnGoBack" runat="server" ImageUrl="../images/btn/b_140.gif" OnClientClick="return GoBack();" />
                            <asp:ImageButton ID="iBtnOrgMap" OnClientClick="GoUrl('home'); return false;" ImageUrl="../images/btn/b_137.gif" runat="server" />
                            <img alt="" src="../images/btn/b_048.gif" onclick="OpenShowKpiDetail();" style="cursor:hand;" />
                            <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClientClick="return OpenPrintPage();" OnClick="ImgBtnPrint_Click" />
                            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
                            <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport" OnCellExporting="ugrdEEP_CellExporting">
                            </ig:UltraWebGridExcelExporter>
                            <asp:HiddenField ID="hdfResultDiffFileId" runat="server" Value="" />
                            <asp:HiddenField ID="hdfExpectReasonFileId" runat="server" Value="" />
                        </td>
                    </tr>
                </table>--%>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Panel>
<!--- MAIN END --->
</asp:Content>