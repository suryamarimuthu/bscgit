<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R019.aspx.cs" Inherits="eis_SEM_Mana_R019" %>

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
                <table>
                    <tr>
                        <td width="8"></td>
                    </tr>
                </table>
                <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
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
                                            <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>년도별매출량</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단 위 : 천원, %</strong></font>&nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td width="100%" align="center">
                                          <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
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
    	                       <td>
                                  <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" >
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
                                  <DCWC:Chart ID="Chart3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" >
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
                                  <DCWC:Chart ID="Chart4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" >
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