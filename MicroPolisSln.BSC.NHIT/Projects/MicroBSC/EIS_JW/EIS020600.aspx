<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS020600.aspx.cs" Inherits="EIS_EIS020600" %>

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
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr height="20%">
                            <td valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <td height="10px">
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </td>
                                    <tr height="25px">
                                        <td width="480px"><img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>계정별 계획대비실적</b></td>
                                        <td></td>
                                        <td align="right">(단위:백만원)&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <DCWC:Chart ID="Chart1" runat="server" 
                                                ImageUrl="../TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="50px" Height="100px">
                                                <ChartAreas>
                                                    <dcwc:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                                                        <position y="15" height="78" width="88" x="5"></Position>
                                                        <axisy linecolor="64, 64, 64, 64" LabelsAutoFit="False">
	                                                        <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
	                                                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                                                        <majortickmark size="0.6"></MajorTickMark>
                                                        </AxisY>
                                                        <axisx linecolor="64, 64, 64, 64" LabelsAutoFit="False" Interval="1">
	                                                        <labelstyle font="Gulim, 12px"></LabelStyle>
	                                                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                                                        </AxisX>
                                                    </dcwc:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                   <DCWC:Legend Name="Default">
                                                   </DCWC:Legend>
                                               </Legends>
                                            </DCWC:Chart>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td align="center" valign="top">
                                            <ig:UltraWebGrid id="uGrid" runat="server" Width="100%" Height="320px" 
                                                OnInitializeRow="uGrid_InitializeRow" 
                                                oninitializelayout="uGrid_InitializeLayout">
								                <Bands>
									                <ig:UltraGridBand>
										                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									                    </RowTemplateStyle>
									                    <Columns>
										                    <ig:UltraGridColumn BaseColumnName="ALIAS" Key="ALIAS" Width="150px">
											                    <Header Caption="계정명">
											                        <RowLayoutColumnInfo OriginX="0" SpanY="2" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Left"/>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="70px" Format="#,##0">
											                    <Header Caption="목표">
											                        <RowLayoutColumnInfo OriginX="1" OriginY="1" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="70px" Format="#,##0">
											                    <Header Caption="실적">
											                        <RowLayoutColumnInfo OriginX="2" OriginY="1" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="RNF" Key="RNF" Width="70px" Format="#,##0">
											                    <Header Caption="증감">
											                        <RowLayoutColumnInfo OriginX="3" OriginY="1" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="EXE_RATE" Key="EXE_RATE" Width="80px" Format="#,##0">
											                    <Header Caption="집행율(%)">
											                        <RowLayoutColumnInfo OriginX="4" OriginY="1" />
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
                                                        Font-Size="8.25pt" Height="310px" Width="100%">
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
                                    </tr>
                                    <%--<tr height="30px">
                                        <td>&nbsp;&nbsp;&nbsp;전년동기대비 증가율 : <asp:Label ID="lblL" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                        <td>&nbsp;&nbsp;&nbsp;전년동기대비 증가율 : <asp:Label ID="lblR" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>--%>
                                    <tr height="30px">
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>실적분석</b>
                                        </td>
                                        <td></td>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>향후 운영계획</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <iframe id="ifmContent1" runat="server" frameborder="0" width="100%" height="80px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                        </td>
                                        <td></td>
                                        <td>
                                            <iframe id="ifmContent2" runat="server" frameborder="0" width="100%" height="80px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                        </td>
                                    </tr>
                                </table>
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
