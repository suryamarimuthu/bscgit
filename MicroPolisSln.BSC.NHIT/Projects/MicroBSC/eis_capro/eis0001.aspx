<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0001.aspx.cs" Inherits="est0001" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
<link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
<!--- MAIN START --->
<!--
<table width="358" height="24" border="0" cellpadding="0" cellspacing="0" background="../images/title/title_bg1.gif">
                 <tr>
                     <td  class="title_m01">��ƿ��Ƽ</td>
                  </tr>
                </table>

                <table>
                <tr><td height=3></td></tr>
                </table>
-->                
                <table cellpadding="0" cellspacing="0" width="98%">
                 <tr>
                    <td >
                        <table cellSpacing=0 cellpadding="0" borderColorDark=#ffffff width=100% height="100%" borderColorLight=#A2A2A2 border=0>
                            <tr>
                                <td width="15%" align="center">
                                    <img src="../images/title/se_ti10.gif" align=absmiddle>
                                </td>
                                <td width="20%">
                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01"></asp:DropDownList>&nbsp;
                                </td>
                                <td width="15%">
                                    <img src="../images/title/opt_s07.gif" align=absmiddle>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlItem" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01"></asp:DropDownList>&nbsp;
                                </td>
                                <td>
                                    <img src="../images/title/opt_s08.gif" align="absmiddle"/>&nbsp;
                                    <asp:DropDownList ID="ddlGongJang" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01"></asp:DropDownList>&nbsp;
                                </td>
                                
                                <td align=right>
                                    <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;            
                                </td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                </table>

<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    	<tr>
    	<td valign=Top>
    	<table border=0 width=100%>
    	    <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <img src="../images/icon/title_ic02.gif" /><span class="subTitle">��ƿ��Ƽ ��뷮 �� �����</span>
                            </td>
                            <td align="right">
                                <font style="color:#666666;font-style:normal;">
                                &nbsp;<b>���� ��: </b>��뷮  &nbsp;&nbsp; <b>������ ��: </b>�����</font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
    	    <tr>
    	        <td>
    	           <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" Height="220px" OnDataBound="Chart1_DataBound" OnPreRender="Chart1_PreRender" >
                    <Titles>
						<dcwc:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 13pt, style=Bold" ShadowOffset="3" Text="" Alignment="BottomCenter" Color="26, 59, 105">
						</dcwc:Title>
					</Titles>
                    <ChartAreas>
                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196" BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                <AxisY linecolor="196, 196, 196" LabelsAutoFit="False">
		                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196"></MajorGrid>
	                            </AxisY>
	                            <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False">
		                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
		                            <MajorGrid linecolor="196, 196, 196" Enabled="false"></MajorGrid>
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
            </tr>
        </table>
        <table border=0 width=100%>
    	    <tr>
    	        <td>
    	        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="130px"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                       <Columns>
                                            <ig:UltraGridColumn BaseColumnName="ITMU_NAME" Key="ITMU_NAME" Width="120px" HeaderText="��ƿ��Ƽ">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="��ƿ��Ƽ">
                                                    
                                                </Header>
                                                <CellStyle HorizontalAlign=Center></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ITMU_TYPE" Key="ITMU_TYPE" Width="80px" HeaderText="�׸�">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="�׸�">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign=Center></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_1" BaseColumnName="C_1" Width="80px" Format="#,##0.##" HeaderText="1��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="1��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_2" BaseColumnName="C_2" Width="80px" Format="#,##0.##" HeaderText="2��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="2��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="3"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_3" BaseColumnName="C_3" Width="80px" Format="#,##0.##" HeaderText="3��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="3��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="4"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_4" BaseColumnName="C_4" Width="80px" Format="#,##0.##" HeaderText="4��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="4��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="5"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_5" BaseColumnName="C_5" Width="80px" Format="#,##0.##" HeaderText="5��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="5��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="6"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_6" BaseColumnName="C_6" Width="80px" Format="#,##0.##" HeaderText="6��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="6��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="7"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_7" BaseColumnName="C_7" Width="80px" Format="#,##0.##" HeaderText="7��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="7��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="8"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_8" BaseColumnName="C_8" Width="80px" Format="#,##0.##" HeaderText="8��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="8��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="9"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_9" BaseColumnName="C_9" Width="80px" Format="#,##0.##" HeaderText="9��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="9��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="10"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_10" BaseColumnName="C_10" Width="80px" Format="#,##0.##" HeaderText="10��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="10��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="11"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_11" BaseColumnName="C_11" Width="80px" Format="#,##0.##" HeaderText="11��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="11��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="12"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="C_12" BaseColumnName="C_12" Width="80px" Format="#,##0.##" HeaderText="12��">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="12��">
                                                    
                                                    <RowLayoutColumnInfo OriginX="13"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn Key="SUM" BaseColumnName="SUM" Width="80px" Format="#,##0.##" HeaderText="�Ⱓ�հ�">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="�Ⱓ�հ�">
                                                    
                                                    <RowLayoutColumnInfo OriginX="14"/>
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="14" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                BorderCollapseDefault="Separate" allowsortingdefault="NotSet"
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
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
                                                <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Center" font-bold="True" BorderColor="#C7C7C7"
                                                     ForeColor="White">
                                                    <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="130px"
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
        </table>
            </td>
    	</tr>
    </table>
        
        
		
<!--- MAIN END --->
<%Response.WriteFile("../_common/html/MenuBottom.htm");%>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
