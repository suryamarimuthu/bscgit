<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Fina_R007.aspx.cs" Inherits="eis_SEM_Fina_R007" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
    <head id="Head1" runat="server">
        <title>일자별 공정별 처리건수</title>
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
      <table border="0" cellspacing="1" cellpadding="2" width="800px" style="height:100%" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" style="height:200" align="left">
                <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
                    <tr>
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">년월</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" EnableTheming="False" Visible="false">
                            </asp:DropDownList>
                        </td>
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">구분</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="ddlGubun" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td class="box_td01" align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
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
                                            <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>재무비율</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단 위 : %</strong></font>&nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td width=100% style="padding-left:5px;">
	                                    <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle font="Tahoma, 10px" Format="#,##0"></LabelStyle>
                                                        <MajorGrid linecolor="196, 196, 196"></MajorGrid>
                                                    </AxisY>
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid linecolor="196, 196, 196"></MajorGrid>
                                                        </AxisX>
                                                     <AxisY2 LabelsAutoFit="False">
                                                        <LabelStyle font="Tahoma, 10px" Format="#,##0"></LabelStyle>
                                                     </AxisY2>
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
                            </table>
                    
                        </td>
	                </tr>
	                <tr>
		                <td>
		                    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    		    	            <tr>
    		    		            <td>
                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="135px"
                                            Width="100%" oninitializelayout="UltraWebGrid1_InitializeLayout" >
                                            <Bands>
                                                <ig:UltraGridBand addbuttoncaption="Column0Column1Column2" key="Column0Column1Column2">
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <COLUMNS>
                                                    </COLUMNS>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
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
                                                <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#C7C7C7"
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
                                                <RowAlternateStyleDefault BackColor="#E7E7E7">
                                                </RowAlternateStyleDefault>
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