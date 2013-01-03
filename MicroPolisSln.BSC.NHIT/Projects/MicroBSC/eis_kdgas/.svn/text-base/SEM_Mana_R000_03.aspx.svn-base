<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R000_03.aspx.cs" Inherits="eis_SEM_Mana_R000_03" %>

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
            <DIV>
                <MenuControl:MenuControl ID="MenuControl1" runat="server" />
                <!--- MAIN START --->
                <!--- TITLE --->
                <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
                    <tr> 
                        <td align="center" bgcolor="A6C5D1" width="12%"><strong><font color="#FFFFFF">조회일자</font></strong></td>
                        <td class="box_td01"  width="28%">
                            <ig:WebDateChooser ID="sDate" runat="server" AllowNull="False">
                                <CalendarLayout AllowNull="False">
                                </CalendarLayout>
                            </ig:WebDateChooser>
                        </td>
                        <td align="center" bgcolor="A6C5D1" width="12%"><strong><font color="#FFFFFF">조회구분</font></strong></td>
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
	                        <table border="0" width="800px" cellpadding="0" cellspacing="0">
	                            <tr>
	                                <td style="width: 50%">
	                                     <table border="0" cellpadding="0" cellspacing="0" >
	                                       <tr>
	                                           <td colspan="3" align="center">
                                          <table width="395" border="0" cellpadding="0" cellspacing="0">
                                              <tr> 
                                                <td align="center"><b /> <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr> 
                                                      <td style="height: 17px"><img align="left" alt="" src="../images/title_ic01.gif" /><font color="#408bef"><strong>공급량</strong></font></td>
                                                    </tr>
                                                  </table></td>
                                              </tr>
                                              <tr> 
                                                <td style="height: 69px">
                                                <DGWC:GaugeContainer id="GaugeContainer1" runat="server" backcolor="White" Height="130px" Width="420px" AutoLayout="False" OnClick="GaugeContainer1_Click">
                                                     <CircularGauges>
                                                         <DGWC:CircularGauge Name="Default">
                                                             <Scales>
                                                                 <DGWC:CircularScale BorderColor="Gray" FillColor="135, 255, 255, 255" Name="Default"
                                                                     Radius="56" ShadowOffset="2" StartAngle="90" SweepAngle="180" Width="11">
                                                                     <LabelStyle Font="Microsoft Sans Serif, 15.75pt, style=Bold" Placement="Outside"
                                                                         TextColor="White" />
                                                                     <MajorTickMark BorderColor="White" BorderWidth="0" DistanceFromScale="1" FillColor="White"
                                                                         Length="8" Placement="Outside" Shape="None" Width="3" />
                                                                     <MinorTickMark BorderColor="White" BorderWidth="0" EnableGradient="False" FillColor="White"
                                                                         Length="5" Placement="Outside" Shape="Wedge" Width="2" />
                                                                 </DGWC:CircularScale>
                                                             </Scales>
                                                             <Size Height="100" Width="100" />
                                                             <PivotPoint X="50" Y="82" />
                                                             <Pointers>
                                                                 <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                                     CapFillGradientType="None" CapReflection="True" CapWidth="21" DistanceFromScale="1"
                                                                     FillColor="Snow" FillGradientEndColor="White" Name="Default" NeedleStyle="NeedleStyle11"
                                                                     Placement="Outside" Width="14" />
                                                             </Pointers>
                                                             <BackFrame BackColor="DeepSkyBlue" BackGradientEndColor="Blue" BackGradientType="TopBottom"
                                                                 BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1"
                                                                 Shape="AutoShape" Style="edged" />
                                                             <Location X="0" Y="0" />
                                                         </DGWC:CircularGauge>
                                                     </CircularGauges>
                                                    <Labels>
                                                        <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                            Text="" TextAlignment="MiddleCenter">
                                                            <Size Height="11" Width="30" />
                                                            <Location X="36" Y="46" />
                                                        </DGWC:GaugeLabel>
                                                    </Labels>
                                                    <Values>
                                                        <DGWC:InputValue Name="Default">
                                                        </DGWC:InputValue>
                                                    </Values>
                                                    <BackFrame BorderColor="212, 208, 200" BorderWidth="1" FrameWidth="1" Shape="Rectangular"
                                                        Style="none" />
                                                </DGWC:GaugeContainer>
                                                </td>
                                              </tr>
                                              <tr>
                                                  <td align="center">
                                                      <table width="370" border="0" cellpadding="0" cellspacing="3">
                                                          <tr>
                                                              <td width="50%" align="center">
                                                                  <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                      <tr>
                                                                          <td width="30%" height="18" align="center" bgcolor="#EAEAEA">
                                                                              계 &nbsp;획</td>
                                                                          <td bgcolor="#EFEFEF">
                                                                              <asp:TextBox ID="txtBrd1_1" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                      </tr>
                                                                      <tr>
                                                                          <td height="18" align="center" bgcolor="#EAEAEA">
                                                                              실 &nbsp;적</td>
                                                                          <td bgcolor="#EFEFEF">
                                                                              <asp:TextBox ID="txtBrd1_2" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                      </tr>
                                                                      <tr>
                                                                          <td height="19" align="center" bgcolor="#EAEAEA">
                                                                              전 &nbsp;년</td>
                                                                          <td bgcolor="#EFEFEF">
                                                                              <asp:TextBox ID="txtBrd1_3" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                      </tr>
                                                                  </table>
                                                              </td>
                                                              <td align="center">
                                                                  <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                      <tr>
                                                                          <td width="30%" height="28" align="center" bgcolor="#EAEAEA">
                                                                              달성율</td>
                                                                          <td bgcolor="#EFEFEF">
                                                                              <asp:TextBox ID="txtBrd1_4" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                      </tr>
                                                                      <tr>
                                                                          <td height="28" align="center" bgcolor="#EAEAEA">
                                                                              성장율</td>
                                                                          <td bgcolor="#EFEFEF">
                                                                              <asp:TextBox ID="txtBrd1_5" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                      </tr>
                                                                  </table>
                                                              </td>
                                                          </tr>
                                                      </table>
                                                  </td>
                                              </tr>
                                          </table>
                                               </td>
                                               <td width="100%" align="right">
                                                   <table width="395" border="0" cellpadding="0" cellspacing="0">
                                                       <tr>
                                                           <td align="center">
                                                               <b />
                                                               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                   <tr>
                                                                       <td style="height: 17px">
                                                                           <img align="left" alt="" src="../images/title_ic01.gif" /><font color="#408bef"><strong>수요개발</strong></font></td>
                                                                   </tr>
                                                               </table>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="height: 69px">
                                                               <DGWC:GaugeContainer id="GaugeContainer2" runat="server" backcolor="White" Height="130px" Width="420px" AutoLayout="False">
                                                                   <CircularGauges>
                                                                       <DGWC:CircularGauge Name="Default">
                                                                           <Scales>
                                                                               <DGWC:CircularScale BorderColor="Gray" FillColor="135, 255, 255, 255" Name="Default"
                                                                                   Radius="56" ShadowOffset="2" StartAngle="90" SweepAngle="180" Width="11">
                                                                                   <LabelStyle Font="Microsoft Sans Serif, 15.75pt, style=Bold" Placement="Outside"
                                                                                       TextColor="White" />
                                                                                   <MajorTickMark BorderColor="White" BorderWidth="0" FillColor="White" Length="8" Placement="Outside"
                                                                                       Shape="None" Width="2" />
                                                                                   <MinorTickMark BorderColor="White" BorderWidth="0" EnableGradient="False" FillColor="White"
                                                                                       Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                                               </DGWC:CircularScale>
                                                                           </Scales>
                                                                           <Size Height="100" Width="100" />
                                                                           <PivotPoint X="50" Y="82" />
                                                                           <Pointers>
                                                                               <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                                                   CapFillGradientType="None" CapReflection="True" CapWidth="21" DistanceFromScale="1"
                                                                                   FillColor="Red" FillGradientEndColor="Maroon" Name="Default" Placement="Outside"
                                                                                   Width="14" />
                                                                           </Pointers>
                                                                           <BackFrame BackColor="MediumSeaGreen" BackGradientEndColor="DarkGreen" BackGradientType="TopBottom"
                                                                               BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1"
                                                                               Shape="AutoShape" Style="edged" />
                                                                           <Location X="0" Y="0" />
                                                                       </DGWC:CircularGauge>
                                                                   </CircularGauges>
                                                                   <Labels>
                                                                       <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                           Text="" TextAlignment="MiddleCenter">
                                                                           <Size Height="11" Width="30" />
                                                                           <Location X="36" Y="46" />
                                                                       </DGWC:GaugeLabel>
                                                                   </Labels>
                                                                   <Values>
                                                                       <DGWC:InputValue Name="Default">
                                                                       </DGWC:InputValue>
                                                                   </Values>
                                                                   <BackFrame BorderColor="212, 208, 200" BorderWidth="1" FrameWidth="1" Shape="Rectangular" Style="none" />
                                                               </DGWC:GaugeContainer>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td align="center">
                                                               <table width="370" border="0" cellpadding="0" cellspacing="3">
                                                                   <tr>
                                                                       <td width="50%" align="center">
                                                                           <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                               <tr>
                                                                                   <td width="30%" height="18" align="center" bgcolor="#EAEAEA">
                                                                                       계 &nbsp;획</td>
                                                                                   <td bgcolor="#EFEFEF">
                                                                                       <asp:TextBox ID="txtBrd2_1" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td height="18" align="center" bgcolor="#EAEAEA">
                                                                                       실 &nbsp;적</td>
                                                                                   <td bgcolor="#EFEFEF">
                                                                                       <asp:TextBox ID="txtBrd2_2" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td height="19" align="center" bgcolor="#EAEAEA">
                                                                                       전 &nbsp;년</td>
                                                                                   <td bgcolor="#EFEFEF">
                                                                                       <asp:TextBox ID="txtBrd2_3" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                               </tr>
                                                                           </table>
                                                                       </td>
                                                                       <td align="center">
                                                                           <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                               <tr>
                                                                                   <td width="30%" height="28" align="center" bgcolor="#EAEAEA">
                                                                                       달성율</td>
                                                                                   <td bgcolor="#EFEFEF">
                                                                                       <asp:TextBox ID="txtBrd2_4" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td height="28" align="center" bgcolor="#EAEAEA">
                                                                                       성장율</td>
                                                                                   <td bgcolor="#EFEFEF">
                                                                                       <asp:TextBox ID="txtBrd2_5" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                               </tr>
                                                                           </table>
                                                                       </td>
                                                                   </tr>
                                                               </table>
                                                           </td>
                                                       </tr>
                                                   </table>
                                               </td>
                                           </tr>
                                         </table>
                                        <table border="0" cellpadding="0" cellspacing="0" >
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <table width="395" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center">
                                                                <b />
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td style="height: 17px">
                                                                            <img align="left" alt="" src="../images/title_ic01.gif" /><font color="#408bef"><strong>매출량</strong></font></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 69px">
                                                                <DGWC:GaugeContainer id="GaugeContainer3" runat="server" backcolor="White" Height="130px" Width="420px" AutoLayout="False">
                                                                    <CircularGauges>
                                                                        <DGWC:CircularGauge Name="Default">
                                                                            <Scales>
                                                                                <DGWC:CircularScale BorderColor="Gray" FillColor="135, 255, 255, 255" Name="Default"
                                                                                    Radius="56" ShadowOffset="2" StartAngle="90" SweepAngle="180" Width="11">
                                                                                    <LabelStyle Font="Microsoft Sans Serif, 15.75pt, style=Bold" Placement="Outside"
                                                                                        TextColor="White" />
                                                                                    <MajorTickMark BorderColor="White" BorderWidth="0" FillColor="White" Length="8" Placement="Outside"
                                                                                        Shape="None" Width="2" />
                                                                                    <MinorTickMark BorderColor="White" BorderWidth="0" EnableGradient="False" FillColor="White"
                                                                                        Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                                                </DGWC:CircularScale>
                                                                            </Scales>
                                                                            <Size Height="100" Width="100" />
                                                                            <PivotPoint X="50" Y="82" />
                                                                            <Pointers>
                                                                                <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise"
                                                                                    CapFillGradientType="None" CapReflection="True" CapWidth="21" DistanceFromScale="1"
                                                                                    FillGradientEndColor="GhostWhite" Name="Default" Placement="Outside" Width="14" />
                                                                            </Pointers>
                                                                            <BackFrame BackColor="OrangeRed" BackGradientEndColor="50, 0, 0" BackGradientType="TopBottom"
                                                                                BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1" Shape="AutoShape" Style="edged" />
                                                                            <Location X="0" Y="0" />
                                                                        </DGWC:CircularGauge>
                                                                    </CircularGauges>
                                                                    <Labels>
                                                                        <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default" Text="" TextAlignment="MiddleCenter">
                                                                            <Size Height="11" Width="30" />
                                                                            <Location X="36" Y="46" />
                                                                        </DGWC:GaugeLabel>
                                                                    </Labels>
                                                                    <Values>
                                                                        <DGWC:InputValue Name="Default">
                                                                        </DGWC:InputValue>
                                                                    </Values>
                                                                    <BackFrame BorderColor="212, 208, 200" BorderWidth="1" FrameWidth="1" Shape="Rectangular" Style="none" />
                                                                </DGWC:GaugeContainer>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <table width="370" border="0" cellpadding="0" cellspacing="3">
                                                                    <tr>
                                                                        <td width="50%" align="center">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                                <tr>
                                                                                    <td width="30%" height="18" align="center" bgcolor="#EAEAEA">
                                                                                        계 &nbsp;획</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd3_1" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="18" align="center" bgcolor="#EAEAEA">
                                                                                        실 &nbsp;적</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd3_2" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="19" align="center" bgcolor="#EAEAEA">
                                                                                        전 &nbsp;년</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd3_3" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td align="center">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                                <tr>
                                                                                    <td width="30%" height="28" align="center" bgcolor="#EAEAEA">
                                                                                        달성율</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd3_4" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="28" align="center" bgcolor="#EAEAEA">
                                                                                        성장율</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd3_5" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="100%" align="right">
                                                    <table width="395" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center">
                                                                <b />
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td style="height: 17px">
                                                                            <img align="left" alt="" src="../images/title_ic01.gif" /><font color="#408bef"><strong>손 익</strong></font></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="color: #4b4b4b">
                                                            <td style="height: 69px">
                                                                <DGWC:GaugeContainer id="GaugeContainer4" runat="server" backcolor="White" Height="130px" Width="420px" AutoLayout="False">
                                                                    <CircularGauges>
                                                                        <DGWC:CircularGauge Name="Default">
                                                                            <Scales>
                                                                                <DGWC:CircularScale BorderColor="Gray" FillColor="135, 255, 255, 255" Name="Default" Radius="56" ShadowOffset="2" StartAngle="90" SweepAngle="180" Width="11">
                                                                                    <LabelStyle Font="Microsoft Sans Serif, 15.75pt, style=Bold" Placement="Outside" TextColor="White" />
                                                                                    <MajorTickMark BorderColor="White" BorderWidth="0" FillColor="White" Length="8" Placement="Outside" Shape="None" Width="2" />
                                                                                    <MinorTickMark BorderColor="White" BorderWidth="0" EnableGradient="False" FillColor="White" Length="5" Placement="Outside" Shape="Wedge" Width="1" />
                                                                                </DGWC:CircularScale>
                                                                            </Scales>
                                                                            <Size Height="100" Width="100" />
                                                                            <PivotPoint X="50" Y="82" />
                                                                            <Pointers>
                                                                                <DGWC:CircularPointer BorderWidth="0" CapFillColor="Silver" CapFillGradientEndColor="MediumTurquoise" CapFillGradientType="None" CapReflection="True" CapWidth="21" DistanceFromScale="1" FillColor="Red" FillGradientEndColor="Maroon" Name="Default" Placement="Outside" Width="14" />
                                                                            </Pointers>
                                                                            <BackFrame BackColor="DeepSkyBlue" BackGradientEndColor="DarkBlue" BackGradientType="TopBottom" BorderColor="DarkGray" BorderWidth="1" FrameGradientType="None" FrameWidth="1" Shape="AutoShape" Style="edged" />
                                                                            <Location X="0" Y="0" />
                                                                        </DGWC:CircularGauge>
                                                                    </CircularGauges>
                                                                    <Labels>
                                                                        <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default" Text="" TextAlignment="MiddleCenter">
                                                                            <Size Height="11" Width="30" />
                                                                            <Location X="36" Y="46" />
                                                                        </DGWC:GaugeLabel>
                                                                    </Labels>
                                                                    <Values>
                                                                        <DGWC:InputValue Name="Default"></DGWC:InputValue>
                                                                    </Values>
                                                                    <BackFrame BorderColor="212, 208, 200" BorderWidth="1" FrameWidth="1" Shape="Rectangular" Style="none" />
                                                                </DGWC:GaugeContainer>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <table width="370" border="0" cellpadding="0" cellspacing="3">
                                                                    <tr>
                                                                        <td width="50%" align="center">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                                <tr>
                                                                                    <td width="30%" height="18" align="center" bgcolor="#EAEAEA">
                                                                                        계 &nbsp;획</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd4_1" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="18" align="center" bgcolor="#EAEAEA">
                                                                                        실 &nbsp;적</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd4_2" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="19" align="center" bgcolor="#EAEAEA">
                                                                                        전 &nbsp;년</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd4_3" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td align="center">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                                                <tr>
                                                                                    <td width="30%" height="28" align="center" bgcolor="#EAEAEA">
                                                                                        달성율</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd4_4" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="28" align="center" bgcolor="#EAEAEA">
                                                                                        성장율</td>
                                                                                    <td bgcolor="#EFEFEF">
                                                                                        <asp:TextBox ID="txtBrd4_5" runat="server" CssClass="eis_MainBox" Text="0" Width="100%"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
	                                </td>
                                </tr>
                            </table>                    
                        </td>
	                </tr>
	                <!--tr><td style="height:5px;"></td></tr-->
	                <tr>
		                <td align="center" style="height: 17px">
		                </td>
	                </tr>
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </DIV>
            </DIV>
        </form>
    </body>
</html>