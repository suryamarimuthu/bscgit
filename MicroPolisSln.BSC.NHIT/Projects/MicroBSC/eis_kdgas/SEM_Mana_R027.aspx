<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R027.aspx.cs" Inherits="eis_SEM_Mana_R027" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
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
    <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
            <tr>
                <td align="center" bgcolor="A6C5D1">
                    <strong><font color="#FFFFFF">년/월</font></strong>
                </td>
                <td class="box_td01">
                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                </td>
            <td bgcolor="A6C5D1" align="center" ><strong><font color="#FFFFFF">사업장</font></strong></td>
            <td class="box_td01" width: 183px;">
                <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>&nbsp;</td>
            <td bgcolor="A6C5D1" align="center" ><strong><font color="#FFFFFF">구분</font></strong></td>
            <td class="box_td01" width: 183px;">
                <asp:DropDownList ID="ddlGubn" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>&nbsp;</td>
            <td align="right" class="box_td01">
                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="800px" height="95%" >
    	<tr>
    	<td height="300">
    	<table border=0 width=100%>
    	    <tr>
    	        <td>
    	           <table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                        <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>월별 차이량 현황</strong></font></td>
                     </tr>
                   </table>
                </td>
    	        <td>
    	        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>년도별 차이비율 현황</strong></font></td>
                        <td align="right"><font color="408BEF"><strong>단위 : 천 ㎥,%</strong></font></td>
                    </tr>
                </table>
                </td>
    	    </tr>
    	    <tr>
    	        <td>
    	            <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" >
                    <ChartAreas>
                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                         
                         BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                        <AxisY linecolor="196, 196, 196" LabelsAutoFit="False">
		                            <LabelStyle font="Tahoma, 10px" Format="#,##0"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                            </AxisY>
	                    <AxisY2 LabelsAutoFit="false">
	                            <LabelStyle font="Tahoma, 10px" Format="#,##0.0"></LabelStyle>
	                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                    </AxisY2>

	                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
		                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                        </DCWC:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                        </DCWC:Legend>
                    </Legends>
                    </DCWC:Chart>        
    	        </td>
    	        <td>
    	        <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" >
                    <ChartAreas>
                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                         
                         BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                        <AxisY linecolor="196, 196, 196" LabelsAutoFit="false">
	                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
	                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                    </AxisY>
	                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
		                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false" />
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
    		<td>
    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="95%" >
    		    	<tr>
    		    		<td width=50% valign="top" align=center><ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="135px"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                       <Columns>
                                            <ig:UltraGridColumn BaseColumnName="MONTH" Key="MONTH" Width="90px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="월">
                                                    
                                                </Header>
                                                <CellStyle HorizontalAlign=Center></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_TOTL_QNT_C" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="매출량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_SALE_QNT_C" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="원가량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_ADJUST_QNT_C" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="차이량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="RATE_ADJUST_C" Width="70px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="차이비율">
                                                    
                                                    <RowLayoutColumnInfo OriginX="3"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_TOTL_QNT_B" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="매출량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_SALE_QNT_B" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="원가량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="4"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_ADJUST_QNT_B" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="차이량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="5"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="RATE_ADJUST_B" Width="70px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="차이비율">
                                                    
                                                    <RowLayoutColumnInfo OriginX="6"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_TOTL_QNT_A" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="원가량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_SALE_QNT_A" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="매출량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="7"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="DIFF_ADJUST_QNT_A" Width="80px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="차이량">
                                                    
                                                    <RowLayoutColumnInfo OriginX="8"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="" Key="RATE_ADJUST_A" Width="70px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="차이비율">
                                                    
                                                    <RowLayoutColumnInfo OriginX="9"  OriginY="1"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                    <GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                    <RowAlternateStyleDefault BackColor="#E7E7E7">
                                    </RowAlternateStyleDefault>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                            &nbsp;</td>
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

