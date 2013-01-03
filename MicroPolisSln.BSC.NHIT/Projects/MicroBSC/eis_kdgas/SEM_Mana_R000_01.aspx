<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R000_01.aspx.cs" Inherits="eis_SEM_Mana_R000_01" %>

<!--%@ Register Assembly="DundasWebGauge" Namespace="Dundas.Gauges.WebControl" TagPrefix="DGWC" %-->

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
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">조회일자</font></strong></td>
                        <td class="box_td01">
                            <ig:WebDateChooser ID="sDate" runat="server" AllowNull="False">
                                <CalendarLayout AllowNull="False">
                                </CalendarLayout>
                            </ig:WebDateChooser>
                        </td>
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">조회구분</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="cboGbn" runat="server" Visible="true" AutoPostBack="false">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                  <tr>
                    <td style="height:3px;">
                    </td>
                  </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="800px"  >
	                <tr>
	                    <td style="padding-left:0px;" align="right">
	                        <table border="0" width="800px" cellpadding="0" cellspacing style="background:rgb(247,243,247);">
	                            <tr>
	                                <td style="width: 50%">
	                                     <table border="0" cellpadding="0" cellspacing="0" class="box_tt01">
	                                       <tr>
	                                           <td colspan="3" align="center"><b />공급량</td>
	                                       </tr>
    	                                    <tr>
    	                                       <td colspan="3">
                                                   <dgwc:gaugecontainer id="GaugeContainer1" runat="server" backcolor="#F7F3F7" Height="150px" Width="400px">
                                                     <CircularGauges>
                                                         <DGWC:CircularGauge Name="Default">
                                                             <Scales>
                                                                 <DGWC:CircularScale FillColor="Black" Name="Default" Radius="40" ShadowOffset="0"
                                                                     StartAngle="90" SweepAngle="180" Width="2">
                                                                     <LabelStyle Placement="Outside" />
                                                                     <MajorTickMark BorderColor="Black" BorderWidth="0" FillColor="Black" Length="8" Placement="Outside"
                                                                         Shape="None" Width="2" />
                                                                     <MinorTickMark BorderColor="Black" BorderWidth="0" EnableGradient="False" FillColor="Black"
                                                                         Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                                 </DGWC:CircularScale>
                                                             </Scales>
                                                             <Size Height="100" Width="100" />
                                                             <PivotPoint X="50" Y="65" />
                                                             <Pointers>
                                                                 <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                                     CapFillGradientType="None" CapReflection="True" CapWidth="24" Name="Default"
                                                                     NeedleStyle="NeedleStyle4" Placement="Outside" Width="13" />
                                                             </Pointers>
                                                             <BackFrame BackColor="WhiteSmoke" BackGradientEndColor="LightBlue" BackGradientType="TopBottom"
                                                                 BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1"
                                                                 Shape="AutoShape" Style="edged" />
                                                             <Location X="0" Y="0" />
                                                         </DGWC:CircularGauge>
                                                        </CircularGauges>
                                                        <Values>
                                                            <DGWC:InputValue Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame Shape="Rectangular" Style="None"></BackFrame>
                                                       <Labels>
                                                           <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                               Text="" TextAlignment="MiddleCenter">
                                                               <Size Height="11" Width="30" />
                                                               <Location X="36" Y="46" />
                                                           </DGWC:GaugeLabel>
                                                       </Labels>
                                                   </dgwc:gaugecontainer>
                                                </td>
                                             </tr>
                                             <tr>
                                                  <td align="center">계&nbsp;&nbsp;획</td>
                                                  <td align="center">실&nbsp;&nbsp;적</td>
                                                  <td align="center">전&nbsp;&nbsp;년</td>
                                                  
                                             </tr>
                                             <tr>
                                                  <td align="center"><asp:TextBox runat="server" ID="txtBrd1_1" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                                  <td align="center"><asp:TextBox runat="server" ID="txtBrd1_2" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                                  <td align="center"><asp:TextBox runat="server" ID="txtBrd1_3" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                  <td align="center" colspan="2"><b />달&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                                  <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd1_4" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                  <td align="center" colspan="2"><b />성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;장&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                                  <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd1_5" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                             </tr>
                                          </table>
	                                </td>
	                                <td width="100%" align="left">
                                        <table border="0" cellpadding="0" cellspacing="0" class="box_tt01">
	                                       <tr>
	                                           <td colspan="3" align="center"><b />수요개발</td>
	                                       </tr>
    	                                    <tr>
    	                                       <td colspan="3">
                                                 <dgwc:gaugecontainer id="GaugeContainer2" runat="server" backcolor="#F7F3F7" Height="150px" Width="400px">
                                                     <CircularGauges>
                                                         <DGWC:CircularGauge Name="Default">
                                                             <Scales>
                                                                 <DGWC:CircularScale FillColor="Black" Name="Default" Radius="40" ShadowOffset="0"
                                                                     StartAngle="90" SweepAngle="180" Width="2">
                                                                     <LabelStyle Placement="Outside" />
                                                                     <MajorTickMark BorderColor="Black" BorderWidth="0" FillColor="Black" Length="8" Placement="Outside"
                                                                         Shape="None" Width="2" />
                                                                     <MinorTickMark BorderColor="Black" BorderWidth="0" EnableGradient="False" FillColor="Black"
                                                                         Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                                 </DGWC:CircularScale>
                                                             </Scales>
                                                             <Size Height="100" Width="100" />
                                                             <PivotPoint X="50" Y="65" />
                                                             <Pointers>
                                                                 <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                                     CapFillGradientType="None" CapReflection="True" CapWidth="24" Name="Default"
                                                                     NeedleStyle="NeedleStyle4" Placement="Outside" Width="13" />
                                                             </Pointers>
                                                             <BackFrame BackColor="WhiteSmoke" BackGradientEndColor="215, 255, 235, 205" BackGradientType="TopBottom"
                                                                 BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1"
                                                                 Shape="AutoShape" Style="edged" />
                                                             <Location X="0" Y="0" />
                                                         </DGWC:CircularGauge>
                                                        </CircularGauges>
                                                        <Values>
                                                            <DGWC:InputValue Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame Shape="Rectangular" Style="None"></BackFrame>
                                                       <Labels>
                                                           <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                               Text="" TextAlignment="MiddleCenter">
                                                               <Size Height="13" Width="35" />
                                                               <Location X="36" Y="46" />
                                                           </DGWC:GaugeLabel>
                                                       </Labels>
                                                   </dgwc:gaugecontainer>
                                                </td>
                                             </tr>
                                             <tr>
                                                  <td align="center">계&nbsp;&nbsp;획</td>
                                                  <td align="center">실&nbsp;&nbsp;적</td>
                                                  <td align="center">전&nbsp;&nbsp;년</td>
                                                  
                                             </tr>
                                             <tr>
                                                  <td align="center"><asp:TextBox runat="server" ID="txtBrd2_1" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                                  <td align="center"><asp:TextBox runat="server" ID="txtBrd2_2" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                                  <td align="center"><asp:TextBox runat="server" ID="txtBrd2_3" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                  <td align="center" colspan="2"><b />달&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                                  <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd2_4" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                                  <td align="center" colspan="2"><b />성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;장&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                                  <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd2_5" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                             </tr>
                                          </table>
	                                </td>
                                </tr>
                            </table>                    
                        </td>
	                </tr>
	                <!--tr><td style="height:5px;"></td></tr-->
	                <tr>
		                <td align="center">
		                  <table cellpadding="0"  cellspacing="0" width="800px" style="background:rgb(247,243,247);">
		                    <tr>
    	                       <td style="height: 150px">
    	                          <table border="0" cellpadding="0" cellspacing="0" class="box_tt01">
                                   <tr>
                                       <td colspan="3" align="center"><b />매출량</td>
                                   </tr>
    	                            <tr>
    	                               <td colspan="3">
                                           <dgwc:gaugecontainer id="GaugeContainer3" runat="server" backcolor="#F7F3F7" Height="150px" Width="400px">
                                             <CircularGauges>
                                                 <DGWC:CircularGauge Name="Default">
                                                     <Scales>
                                                         <DGWC:CircularScale FillColor="Black" Name="Default" Radius="40" ShadowOffset="0"
                                                             StartAngle="90" SweepAngle="180" Width="2">
                                                             <LabelStyle Placement="Outside" />
                                                             <MajorTickMark BorderColor="Black" BorderWidth="0" FillColor="Black" Length="8" Placement="Outside"
                                                                 Shape="None" Width="2" />
                                                             <MinorTickMark BorderColor="Black" BorderWidth="0" EnableGradient="False" FillColor="Black"
                                                                 Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                         </DGWC:CircularScale>
                                                     </Scales>
                                                     <Size Height="100" Width="100" />
                                                     <PivotPoint X="50" Y="65" />
                                                     <Pointers>
                                                         <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                             CapFillGradientType="None" CapReflection="True" CapWidth="24" Name="Default"
                                                             NeedleStyle="NeedleStyle4" Placement="Outside" Width="13" />
                                                     </Pointers>
                                                     <BackFrame BackColor="WhiteSmoke" BackGradientEndColor="71, 0, 0, 255" BackGradientType="TopBottom"
                                                         BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1"
                                                         Shape="AutoShape" Style="edged" />
                                                     <Location X="0" Y="0" />
                                                 </DGWC:CircularGauge>
                                                </CircularGauges>
                                                <Values>
                                                    <DGWC:InputValue Name="Default">
                                                    </DGWC:InputValue>
                                                </Values>
                                                <BackFrame Shape="Rectangular" Style="None"></BackFrame>
                                               <Labels>
                                                   <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                       Text="" TextAlignment="MiddleCenter">
                                                       <Size Height="11" Width="30" />
                                                       <Location X="36" Y="46" />
                                                   </DGWC:GaugeLabel>
                                               </Labels>
                                           </dgwc:gaugecontainer>
                                        </td>
                                     </tr>
                                     <tr>
                                          <td align="center">계&nbsp;&nbsp;획</td>
                                          <td align="center">실&nbsp;&nbsp;적</td>
                                          <td align="center">전&nbsp;&nbsp;년</td>
                                          
                                     </tr>
                                     <tr>
                                          <td align="center"><asp:TextBox runat="server" ID="txtBrd3_1" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                          <td align="center"><asp:TextBox runat="server" ID="txtBrd3_2" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                          <td align="center"><asp:TextBox runat="server" ID="txtBrd3_3" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                     </tr>
                                     <tr>
                                          <td align="center" colspan="2"><b />달&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                          <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd3_4" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                     </tr>
                                     <tr>
                                          <td align="center" colspan="2"><b />성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;장&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                          <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd3_5" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                     </tr>
                                  </table>
                               </td>
    	                       <td style="height: 150px">
    	                          <table border="0" cellpadding="0" cellspacing="0" class="box_tt01">
                                   <tr>
                                       <td colspan="3" align="center"><b />손익</td>
                                   </tr>
    	                            <tr>
    	                               <td colspan="3">
                                           <dgwc:gaugecontainer id="GaugeContainer4" runat="server" backcolor="#F7F3F7" Height="150px" Width="400px">
                                             <CircularGauges>
                                                 <DGWC:CircularGauge Name="Default">
                                                     <Scales>
                                                         <DGWC:CircularScale FillColor="Black" Name="Default" Radius="40" ShadowOffset="0"
                                                             StartAngle="90" SweepAngle="180" Width="2">
                                                             <LabelStyle Placement="Outside" />
                                                             <MajorTickMark BorderColor="Black" BorderWidth="0" FillColor="Black" Length="8" Placement="Outside"
                                                                 Shape="None" Width="2" />
                                                             <MinorTickMark BorderColor="Black" BorderWidth="0" EnableGradient="False" FillColor="Black"
                                                                 Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                         </DGWC:CircularScale>
                                                     </Scales>
                                                     <Size Height="100" Width="100" />
                                                     <PivotPoint X="50" Y="65" />
                                                     <Pointers>
                                                         <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                             CapFillGradientType="None" CapReflection="True" CapWidth="24" Name="Default"
                                                             NeedleStyle="NeedleStyle4" Placement="Outside" Width="13" />
                                                     </Pointers>
                                                     <BackFrame BackColor="WhiteSmoke" BackGradientEndColor="215, 255, 222, 173" BackGradientType="TopBottom"
                                                         BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1"
                                                         Shape="AutoShape" Style="edged" />
                                                     <Location X="0" Y="0" />
                                                 </DGWC:CircularGauge>
                                                </CircularGauges>
                                                <Values>
                                                    <DGWC:InputValue Name="Default">
                                                    </DGWC:InputValue>
                                                </Values>
                                                <BackFrame Shape="Rectangular" Style="None"></BackFrame>
                                               <Labels>
                                                   <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                       Text="" TextAlignment="MiddleCenter">
                                                       <Size Height="11" Width="30" />
                                                       <Location X="36" Y="46" />
                                                   </DGWC:GaugeLabel>
                                               </Labels>
                                           </dgwc:gaugecontainer>
                                        </td>
                                     </tr>
                                     <tr>
                                          <td align="center">계&nbsp;&nbsp;획</td>
                                          <td align="center">실&nbsp;&nbsp;적</td>
                                          <td align="center">전&nbsp;&nbsp;년</td>
                                          
                                     </tr>
                                     <tr>
                                          <td align="center"><asp:TextBox runat="server" ID="txtBrd4_1" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                          <td align="center"><asp:TextBox runat="server" ID="txtBrd4_2" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                          <td align="center"><asp:TextBox runat="server" ID="txtBrd4_3" Text="0" Width="100%" CssClass ="eis_MainBox"></asp:TextBox></td>
                                     </tr>
                                     <tr>
                                          <td align="center" colspan="2"><b />달&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                          <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd4_4" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                     </tr>
                                     <tr>
                                          <td align="center" colspan="2"><b />성&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;장&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;율</td>
                                          <td align="center"><b /><asp:TextBox runat="server" ID="txtBrd4_5" Text="0" Width="100%"  CssClass ="eis_MainBox"></asp:TextBox></td>
                                     </tr>
                                  </table>
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