﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0006.aspx.cs" Inherits="eis_eis0006" %>


<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
        <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
        <%Response.WriteFile("../_common/html/CommonTop.htm");%>
            <form id="form1" runat="server">
            <div>
        <MenuControl:MenuControl ID="MenuControl1" runat="server" />
        <!--- MAIN START --->
                
                <table cellpadding="0" cellspacing="0" width="98%">
                 <tr>
                    <td>
                        <table cellSpacing=0 width=100% border=0>
                                <tr>
                                    <td width="10%">
                                        <img src="../images/title/se_ti10.gif" align=absmiddle>
                                    </td>
                                    <td width="60%">
                                        <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                                        </asp:DropDownList>
                                    </td>
                                    <td align=right>
                                        <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" onclick="iBtnSearch_Click" />&nbsp;
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
                <table border="0" cellspacing="0" cellpadding="0" width="100%"  >
	                <tr>
	                    <td>
	                        <table border=0 width=100% height="100%">
	                            <tr>
                                    <td class="subTitle">
                                        <img src="../images/icon/title_ic02.gif" align="absbottom" />채권현황
                                    </td>
                                </tr>
	                            <tr>
	                                <td>
	                                    <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" height="220px" >
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <axisy linecolor="196, 196, 196" LabelsAutoFit="False">
                                                        <labelstyle font="Tahoma, 10px"></LabelStyle>
                                                        <majorgrid linecolor="196, 196, 196"></MajorGrid>
                                                    </AxisY>
                                                    <AXISY2 linecolor="196, 196, 196" LabelsAutoFit="False">
                                                        <labelstyle font="Tahoma, 10px"></LabelStyle>
                                                        <majorgrid linecolor="196, 196, 196"></MajorGrid>
                                                    </AxisY2>
                                                    <axisx linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                        <labelstyle font="Tahoma, 10px"></LabelStyle>
                                                        <majorgrid linecolor="196, 196, 196"></MajorGrid>
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
                    
                        </td>
	                </tr>
	                
	                <tr><td height="5px"></td></tr>
	                
	                <tr>
		                <td>
		                    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
		                        <tr>
		                            <td>
		                            <table cellpadding="0" cellspacing="0" width="100%">
                                         <tr>
                                            <td class="tableoutBorder">
                                                <table cellSpacing=0 width=100% border=0 class="tableBorder">
                                                    <tr>
                                                        <td width="15%" class="tableTitle"  align="center">
                                                            업체
                                                        </td>
                                                        <td width="35%" class="tableContent">
                                                            <asp:DropDownList ID="ddlVendor" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="15%" class="tableTitle"  align="center">
                                                            채권
                                                        </td>
                                                        <td  class="tableContent">
                                                            <asp:DropDownList ID="ddlBond" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        <table>
                                           <tr><td height=3></td></tr>
                                        </table>
		                            </td>
		                        </tr>
		    	                <tr>
		    		                <td width=100% height="115" valign="top" align=center>
                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%"
                                            Width="100%" oninitializelayout="UltraWebGrid1_InitializeLayout" oninitializerow="UltraWebGrid1_InitializeRow">
                                            <Bands>
                                                <ig:UltraGridBand addbuttoncaption="Column0Column1Column2" key="Column0Column1Column2">
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                BorderCollapseDefault="Separate" allowsortingdefault="NotSet"
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header">
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
                                                <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Center" font-bold="true" BorderColor="#C7C7C7"
                                                     ForeColor="White">
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
                                                
                                                
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
		    	                </tr>
		                    </table>
		                </td>
		                <td width="10px"></td>
	                </tr>
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
            </form>
        <%Response.WriteFile("../_common/html/CommonBottom.htm");%>
