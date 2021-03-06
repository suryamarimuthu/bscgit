<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Empl_R006.aspx.cs" Inherits="eis_SEM_Empl_R006" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
<head id="Head1" runat="server">
<title> ▒ KD JUMP - 성과관리 네트워크 ▒ </title>
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
            <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">년월</font></strong></td>
            <td class="box_td01">
                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                </td>
            <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">구분</font></strong></td>
            <td class="box_td01">
                 <asp:DropDownList ID="rBtnGbn" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                 </asp:DropDownList>
            </td>
            <td class="box_td01" align="right">
                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="800px" height="95%" >
    	<tr>
    	<td align="left" height="300">
    	<table border=0 width=100%>
    	    <tr>
    	        <td>
    	            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>교육예산 대비 실적</strong></font></td>
                            <td align="right"><font color="408BEF"><strong>단위 : 천원</strong></font></td>
                        </tr>
                    </table>
                </td>
    	    </tr>
    	    <tr>
    	        <td >
    	            <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
                    <ChartAreas>
                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                         
                         BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                          <AxisY linecolor="196, 196, 196" LabelsAutoFit="False">
		                    <LabelStyle font="Tahoma, 10px" Format="#,##0"></LabelStyle>
		                    <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                      </AxisY>
	                      <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False">
		                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                    <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                      </AxisY2>
	                      <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                      <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                      <MajorGrid linecolor="196, 196, 196"></MajorGrid>
		                  </AxisX>
                          <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="True" />
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
    		    		<td width=50% valign="top" align=center>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="135px"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="GUBUN" EditorControlID="" FooterText="" Format=""
                                                Key="GUBUN" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="구분">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign=Center></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_1" Key="T_1" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="1월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_2" Key="T_2" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="2월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_3" Key="T_3" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="3월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_4" Key="T_4" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="4월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_5" Key="T_5" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="5월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_6" Key="T_6" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="6월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_7" Key="T_7" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="7월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_8" Key="T_8" Width="70px" Format="#,##0.##">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="8월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_9" Key="T_9" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="9월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_10" Key="T_10" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="10월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_11" Key="T_11" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="11월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="T_12" Key="T_12" Width="70px" Format="#,##0">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="12월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
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
                            </ig:UltraWebGrid>&nbsp;</td>
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
