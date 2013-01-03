<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R002.aspx.cs" Inherits="eis_SEM_Mana_R002" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title> ▒ KD JUMP - 성과관리 네트웍 </title>
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
                        <td class="box_td01" style="width:100;">
                            <ig:WebDateChooser ID="sDate" runat="server" AllowNull="False">
                                <CalendarLayout AllowNull="False">
                                </CalendarLayout>
                            </ig:WebDateChooser>
                        </td>
                        <td class="box_td01" style="width:6;"><strong>∼</strong></td>
                        <td class="box_td01" style="width:100;">
                            <ig:WebDateChooser ID="eDate" runat="server" AllowNull="False">
                                <CalendarLayout AllowNull="False">
                                </CalendarLayout>
                            </ig:WebDateChooser>
                        </td>
                        <td align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">사업장</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="cboTCom" runat="server" Visible="true" AutoPostBack="false">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
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
                                            <td><img alt="" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>시간/일별 공급량 추이</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단 위 : ㎥</strong></font></td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td width="100%" align="center">
                                          <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" >
                                            <ChartAreas>
                                                <DCWC:ChartArea BackColor="White" BackGradientEndColor="White" BorderColor="196, 196, 196"
                                                    Name="Default" ShadowColor="Transparent">
                                                    <AxisX LabelsAutoFit="False" LineColor="196, 196, 196" Interval="1">
                                                        <LabelStyle Font="Tahoma, 10px" />
                                                        <MajorGrid LineColor="196, 196, 196" />
                                                    </AxisX>
                                                     <Area3DStyle Enable3D="false" WallWidth="3" YAngle="20" />
                                                     <Position Height="83.15719" Width="94" X="3" Y="13.84281" />
                                                    <AxisY LineColor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px" />
                                                        <MajorGrid LineColor="196, 196, 196" />
                                                    </AxisY>
                                                    <AxisY2 Enabled="False" LabelsAutoFit="False">
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
	                <tr>
		                <td align="center">
		                  <table cellpadding="0"  cellspacing="0">
		                    <tr>
    	                       <td>
                                    &nbsp;
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