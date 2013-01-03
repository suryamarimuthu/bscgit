<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R018.aspx.cs" Inherits="eis_SEM_Mana_R018" %>

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
      <table border="0" cellspacing="1" cellpadding="2" width="800px" style="height:100%" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" style="height:200" align="left">
                <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF"  class="box_tt01">
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
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">구 분</font></strong></td>
                        <td class="box_td01">
                             <asp:DropDownList ID="cboGbn" runat="server" AppendDataBoundItems="True" EnableTheming="False">
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
                                            <td><img alt="매출비중" src="../images/title_ic01.gif" align="left" /><font color="408BEF"><strong>매출비중</strong></font></td>
                                        </tr>
                                    </table>
	                                </td>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="계획대비실적" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>월 계획대비실적</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단 위 : 천원,% </strong></font>&nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td align="center">
                                      <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" >
                                        <ChartAreas>
                                           <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                             BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False">
		                                       <LabelStyle font="Tahoma, 10px" Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto"></LabelStyle>
		                                       <MajorGrid linecolor="196, 196, 196" Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto"></MajorGrid>
                                                <MajorTickMark Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
	                                        </AxisY>
	                                        <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                                    <LabelStyle font="Tahoma, 10px" Interval="1" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto"></LabelStyle>
		                                       <MajorGrid linecolor="196, 196, 196" Interval="1" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto"></MajorGrid>
                                                <MajorTickMark Interval="1" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
		                                       </AxisX>
                                            <Area3DStyle Enable3D="True" XAngle="50" YAngle="20" WallWidth="5" />
                                               <AxisX2 LabelsAutoFit="False">
                                                   <LabelStyle Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                                   <MajorTickMark Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                                   <MajorGrid Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                               </AxisX2>
                                               <AxisY2 LabelsAutoFit="False">
                                                   <LabelStyle Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                                   <MajorTickMark Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                                   <MajorGrid Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                               </AxisY2>
                                           </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                LegendStyle="Row" Name="Default" ShadowOffset="1" Enabled="False">
                                            </DCWC:Legend>
                                        </Legends>
                                      </DCWC:Chart>
	                                </td>
	                                <td>
                                          <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" >
                                            <ChartAreas>
                                                <DCWC:ChartArea BackColor="White" BackGradientEndColor="White" BorderColor="196, 196, 196"
                                                    Name="Default" ShadowColor="Transparent">
                                                    <AxisX LabelsAutoFit="False" LineColor="196, 196, 196" Interval="1">
                                                        <LabelStyle Font="Tahoma, 10px" />
                                                        <MajorGrid LineColor="196, 196, 196" />
                                                    </AxisX>
                                                     <Area3DStyle Enable3D="True" WallWidth="3" YAngle="20" />
                                                     <Position Height="83.15719" Width="94" X="3" Y="13.84281" />
                                                    <AxisY LineColor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px" />
                                                        <MajorGrid LineColor="196, 196, 196" />
                                                    </AxisY>
                                                    <AxisY2 Enabled="True" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px" />
                                                    </AxisY2>
                                                </DCWC:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    <Position Height="8" Width="60" X="20" Y="3" />
                                                </DCWC:Legend>
                                            </Legends>
                                          </DCWC:Chart>
	                                </td>
                                </tr>
                            </table>
                            </td>
                                </tr>
                            </table>
                        </td>
	                </tr>
	                <tr>
		            <td align="center">
		                <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    		    	        <tr>
    		    		        <td>
    		                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="SGBUN_NM" EditorControlID="" FooterText="" Format=""
                                                    HeaderText="구분" Key="SGBUN_NM" Width="180px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="구분">
                                                        
                                                    </Header>
                                                    <CellStyle Font-Bold="true" HorizontalAlign="Center"></CellStyle>
                                                    <Footer Caption=""></Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="S_PLAN" EditorControlID="" FooterText="" Format="###,##0"
                                                    HeaderText="계획" Key="S_PLAN" NullText="0" Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="계획">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="S_RSLT" EditorControlID="" FooterText="" Format="###,##0"
                                                    HeaderText="실적" Key="S_RSLT" NullText="0" Width="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="실적">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="L_RSLT" EditorControlID="" FooterText="" Format="###,##0"
                                                    HeaderText="전년동기" Key="L_RSLT" NullText="0" Width="120px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="전년동기실적">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="S_DIFF" EditorControlID="" FooterText="" Format="###,##0"
                                                    HeaderText="차이" Key="S_DIFF" NullText="0" Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="차이">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ACHV_RATE" EditorControlID="" FooterText=""
                                                    Format="#,##0.0" HeaderText="달성율(%)" Key="ACHV_RATE" NullText="0" Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="달성율(%)">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="S_ADD" EditorControlID="" FooterText="" Format="###,##0"
                                                    HeaderText="차이" Key="S_DIFF" NullText="0" Width="80px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="차이">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="GROW_RATE" EditorControlID="" FooterText=""
                                                    Format="#,##0.0" HeaderText="증가율(%)" Key="GROW_RATE" NullText="0" Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="증가율(%)">
                                                        
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Right">
                                                      <Padding Right="3" />
                                                    </CellStyle>
                                                    <Footer Caption="">
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                            AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" RowHeightDefault="20px"
                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                            <GroupByBox>
                                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                            </GroupByBox>
                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                            </GroupByRowStyleDefault>
                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                            </FooterStyleDefault>
                                            <RowAlternateStyleDefault BackColor="#F9F9F7">
                                                <BorderDetails  ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                                            </RowAlternateStyleDefault>
                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                <Padding Left="3px" />
                                            </RowStyleDefault>
                                            <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                                                 ForeColor="white">
                                                <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                            <RowAlternateStyleDefault BackColor="#E7E7E7">
                                            </RowAlternateStyleDefault>
                                    </DisplayLayout>
                                                        
                                </ig:UltraWebGrid>
    	                       
		                </td>
	                </tr>
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
        </form>
    </body>
</html>