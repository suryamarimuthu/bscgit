<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R023.aspx.cs" Inherits="eis_SEM_Mana_R023" %>

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
            <td valign="top" style="height:1" align="left">
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
                <table border="0" cellspacing="0" cellpadding="0" width="100%" >
	                <tr>
	                    <td style="padding-left:5px;">
	                        <table border="0" width="100%">
	                            <tr>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="" src="../images/title_ic01.gif" align="left" /><font color="408BEF"><strong>CNG 년도별 매출량 추이</strong></font></td>
                                        </tr>
                                    </table>
	                                </td>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>메탄 년도별 매출량 추이</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단위 : 천 ㎥</strong></font></td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td align="center">
                                      <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" >
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
	                                <td>
                                      <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" >
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
                            </table>
                        </td>
	                </tr>
	                <tr>
		                <td>
		                  <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
		                    <tr>
    	                       <td colspan="2">
                                  <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="135px"
                                        Width="100%" oninitializelayout="UltraWebGrid1_InitializeLayout" OnInitializeRow="UltraWebGrid1_InitializeRow" >
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
                                            HeaderClickActionDefault="NotSet" Name="UltraWebGrid1" RowHeightDefault="20px"
                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header">
                                            <GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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