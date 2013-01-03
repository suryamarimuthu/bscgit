<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R029.aspx.cs" Inherits="eis_SEM_Mana_R029" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <!--META http-equiv="Page-Enter" content="blendTrans(Duration=0.3)">
        <META http-equiv="Page-Exit" content="blendTrans(Duration=0.3)"-->
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    </head>
    
    <body style="margin:0 0 0 0 ; background-color:#FFFFFF">
        <form id="form1" runat="server">
            <div>
                <MenuControl:MenuControl ID="MenuControl1" runat="server" />
                <!--- MAIN START --->
                <!--- TITLE --->
                <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF"  class="box_tt01">
                    <tr> 
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">년/월</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="cboYY" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cboMM" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">사업장</font></strong></td>
                        <td class="box_td01">
                             <asp:DropDownList ID="cboCom" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                             </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="800px" >
	                <tr>
	                    <td style="padding-left:5px;">
	                        <table border="0" width="100%">
	                            <tr>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
	                                </td>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="right"><font color="408BEF"><strong>단위 : 원, %</strong></font></td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td align="center">
                                          <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" Visible="False" >
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                 BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                <AxisY linecolor="196, 196, 196" Interlaced="True" InterlacedColor="215, 215, 215" LabelsAutoFit="False">
                                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
                                                            <MinorGrid linecolor="196, 196, 196" LineWidth="2"></MinorGrid>
                                                        </AxisY>
                                                        <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
                                                        </AxisX>
                                                    <Area3DStyle XAngle="50" YAngle="20" WallWidth="5" />
                                                </DCWC:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="White" Docking="Top"
                                                    LegendStyle="Row" Name="Default"  Font="Microsoft Sans Serif, 8.25pt" AutoFitText="False">
                                                </DCWC:Legend>
                                            </Legends>
                                          </DCWC:Chart>
	                                </td>
	                                <td>
                                          <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" Visible="False" >
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                 BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                <AxisY linecolor="196, 196, 196" Interlaced="True" InterlacedColor="215, 215, 215" LabelsAutoFit="False">
                                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
                                                            <MinorGrid linecolor="196, 196, 196" LineWidth="2"></MinorGrid>
                                                        </AxisY>
                                                        <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
                                                        </AxisX>
                                                    <Area3DStyle XAngle="50" YAngle="20" WallWidth="5" />
                                                </DCWC:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                </DCWC:Legend>
                                            </Legends>
                                          </DCWC:Chart>
	                                </td>
                                </tr>
                            </table>
                        </td>
	                </tr>
	                <tr>
		                <td align="center">
		                  <table cellpadding="0"  cellspacing="0">
		                    <tr>
    	                       <td colspan="2">
                                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="141px" Width="100%" OnInitializeLayout="UltraWebGrid1_InitializeLayout1" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                                <Columns>
                                                    <ig:UltraGridColumn BaseColumnName="T_NAME" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="구분" Key="T_NAME" Width="80px" Hidden="false" MergeCells="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="구       분">
                                                            
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <CellStyle Font-Bold="True" HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:TemplatedColumn BaseColumnName="M_NAME" EditorControlID="" FooterText="" MergeCells="True"
                                                           Format="" HeaderText="하위코드명" Key="M_NAME" Width="80px">
                                                        <Header Caption="하위코드명">
                                                          
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="CP_COST" EditorControlID="CP_COST" FooterText="" Format="#,##0.#0"
                                                        HeaderText="변동전" Key="CP_COST" NullText="0" Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="변동전">
                                                            
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="CC_COST" EditorControlID="" FooterText="" Format="#,##0.#0"
                                                        HeaderText="변동후" Key="CC_COST" NullText="0" Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="변동후">
                                                            
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="C_DIFF" EditorControlID="" FooterText="" Format="#,##0.#0"
                                                        HeaderText="증감" Key="C_DIFF" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="증감">
                                                            
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="C_RATE" EditorControlID="" FooterText="" Format="#,##0.0"
                                                        HeaderText="증감율" Key="C_RATE" NullText="0" Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="증감율">
                                                            
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="C_EXPS" EditorControlID="" FooterText="" Format="#,##0.#0"
                                                        HeaderText="공급비용" Key="C_EXPS" NullText="0" Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="PP_PRICE" EditorControlID="" FooterText="" Format="#,##0.#0"
                                                        HeaderText="변동전" Key="PP_PRICE" NullText="0" Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="변동전">
                                                            
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="CP_PRICE" EditorControlID="CP_PRICE" FooterText="" Format="#,##0.#0"
                                                        HeaderText="변동전" Key="CP_PRICE" NullText="0" Width="80px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="변동전">
                                                            
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="P_DIFF" EditorControlID="" FooterText="" Format="#,##0.#0"
                                                        HeaderText="증감" Key="P_DIFF" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="증감">
                                                            
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="P_RATE" EditorControlID="" FooterText="" Format="#,##0.0"
                                                        HeaderText="증감율" Key="P_RATE" NullText="0" Width="50px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="증감율">
                                                            
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="NotSet" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet" Name="UltraWebGrid1" RowHeightDefault="22px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                <GroupByBox>
                                                    <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                                                     ForeColor="White">
                                                    <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="450px"
                                                    Width="800px">
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
                                                <RowAlternateStyleDefault BackColor="#FFFFFF"></RowAlternateStyleDefault>
                                        </DisplayLayout>
                                    </ig:UltraWebGrid>
    	                       </td>
		                    </tr>
		                  </table>
		                </td>
	                </tr>
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
        </form>
    </body>
</html>