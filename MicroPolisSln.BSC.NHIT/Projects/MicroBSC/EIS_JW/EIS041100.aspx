<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS041100.aspx.cs" Inherits="EIS_EIS041100" %>

<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

        <script type="text/javascript">

        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
            <tr height="10px">
                <td></td>
            </tr>
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0" runat="server" id="tbl">
                        
                        <tr height="100px" valign="top" runat="server" id="tr1">
                            <td width="480px">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>PTC</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid1" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td width="20px"></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent1_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr2">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>VM</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid2" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent2" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent2_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr3">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>EV</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid3" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent3" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent3_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr4">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>AFA</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid4" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent4" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent4_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr5">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>PCM</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid5" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent5" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent5_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr6">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>ROLLER</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid6" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent6" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent6_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr7">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>기타</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid7" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent7" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent7_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr8">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>추가여분1</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid8" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent8" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent8_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr9">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>추가여분2</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid9" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent9" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent9_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr10">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>추가여분3</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid10" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent10" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent10_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                        <tr height="100px" valign="top" runat="server" id="tr11">
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>추가여분4</b>
                                        </td>
                                        <td align="right">
                                            (단위:%,PPM)&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <ig:UltraWebGrid id="Grid11" runat="server" Width="480px" Height="210px">
					                <Bands>
						                <ig:UltraGridBand>
							                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
						                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
							                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
						                    </RowTemplateStyle>
						                    <Columns>
							                    <ig:UltraGridColumn BaseColumnName="ITM_NAME" Key="ITM_NAME" Width="120px">
								                    <Header Caption="항목">
								                        <RowLayoutColumnInfo OriginX="0" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Left"/>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="80px" Format="#,##0">
								                    <Header Caption="계획">
								                        <RowLayoutColumnInfo OriginX="1" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="실적">
								                        <RowLayoutColumnInfo OriginX="2" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Key="ACHIEVE_RATE" Width="80px" Format="#,##0">
								                    <Header Caption="달성율">
								                        <RowLayoutColumnInfo OriginX="3" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                    <ig:UltraGridColumn BaseColumnName="BF_RESULT_TS" Key="BF_RESULT_TS" Width="80px" Format="#,##0">
								                    <Header Caption="전년동기대비">
								                        <RowLayoutColumnInfo OriginX="4" />
							                        </Header>
								                    <HeaderStyle HorizontalAlign="Center" />
								                    <CellStyle HorizontalAlign="Right"/>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                    </Footer>
							                    </ig:UltraGridColumn>
							                </Columns>
						                </ig:UltraGridBand>
					                </Bands>
					                <DisplayLayout  CellPaddingDefault="2" 
					                                AllowColSizingDefault="Free" 
					                                AllowColumnMovingDefault="OnServer" 
					                                AllowDeleteDefault="Yes" 
					                                AllowSortingDefault="No" 
					                                BorderCollapseDefault="Separate" 
					                                HeaderClickActionDefault="SortMulti" 
					                                Name="UltraWebGrid1" 
					                                RowHeightDefault="20px" 
					                                RowSelectorsDefault="No" 
					                                SelectTypeRowDefault="Extended" 
					                                Version="4.00" 
					                                ViewType="Flat" 
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
					                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
						                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
					                </HeaderStyleDefault>
					                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
					                <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" 
                                            BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" 
                                            Font-Size="8.25pt" Height="210px" Width="480px">
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
					                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
					                <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
					                </DisplayLayout>
				                </ig:UltraWebGrid>
                            </td>
                            <td></td>
                            <td>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b><br />
                                <iframe id="ifmContent11" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>만회대책</b><br />
                                <iframe id="ifmContent11_1" runat="server" style="margin-top:5px" frameborder="0" width="100%" height="90px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
        </table> 
        <asp:literal id="ltrScript" runat="server"></asp:literal>     
        <!--- MAIN END --->
    </form>
</body>
</html>
