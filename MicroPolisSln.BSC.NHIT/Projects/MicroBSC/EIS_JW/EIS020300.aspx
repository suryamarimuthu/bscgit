<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS020300.aspx.cs" Inherits="EIS_EIS020300" %>

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
                                        <td widht="480px"><img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>Item별 재고현황</b></td>
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
                                        <td widht="20px">
                                        &nbsp;&nbsp;
                                        </td>
                                        <td align="center" valign="top">
                                            <ig:UltraWebGrid id="uGrid" runat="server" Width="100%" Height="320px" >
								                <Bands>
									                <ig:UltraGridBand>
										                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									                    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									                    </RowTemplateStyle>
									                    <Columns>
										                    <ig:UltraGridColumn BaseColumnName="I_NAME" Key="I_NAME" Width="100px">
											                    <Header Caption="Item명">
											                        <RowLayoutColumnInfo OriginX="0"/>
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Left"/>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="S_01" Key="S_01" Width="70px" Format="#,##0">
											                    <Header Caption="제품">
											                        <RowLayoutColumnInfo OriginX="1" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="S_02" Key="S_02" Width="70px" Format="#,##0">
											                    <Header Caption="부품">
											                        <RowLayoutColumnInfo OriginX="2" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="S_03" Key="S_03" Width="70px" Format="#,##0">
											                    <Header Caption="원자재">
											                        <RowLayoutColumnInfo OriginX="3" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="S_04" Key="S_04" Width="70px" Format="#,##0">
											                    <Header Caption="재공품">
											                        <RowLayoutColumnInfo OriginX="4" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
                                                                </Footer>
										                    </ig:UltraGridColumn>
										                    <ig:UltraGridColumn BaseColumnName="S_05" Key="S_05" Width="70px" Format="#,##0">
											                    <Header Caption="총재고">
											                        <RowLayoutColumnInfo OriginX="5" />
										                        </Header>
											                    <HeaderStyle HorizontalAlign="Center" />
											                    <CellStyle HorizontalAlign="Right"/>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
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
                                    <tr height="25px">
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>재고자산 현황</b>
                                        </td>
                                        <td widht="10px">
                                        </td>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>재고감축 방안</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <iframe id="ifmContent1" runat="server" frameborder="0" width="100%" height="80px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                        </td>
                                        <td widht="10px">
                                        </td>
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
