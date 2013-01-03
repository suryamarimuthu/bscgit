<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0008.aspx.cs" Inherits="eis_eis0008" %>


<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
        <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
        <%Response.WriteFile("../_common/html/CommonTop.htm");%>
            <form id="form1" runat="server">
            <div>
        <MenuControl:MenuControl ID="MenuControl1" runat="server" />
        <!--- MAIN START --->
                <table border="0" cellspacing="0" cellpadding="0" width="100%"  >
	                <tr>
		                <td height=50 style="padding-left:5px;">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1" class="tableBorder" width="100%">
                                            <tr>
                                                <td class="tableTitle" style="width: 100px">
                                                    공장별 현황
                                                </td>
                                                <td class="tdBorder">
                                                    <table cellSpacing=0 cellpadding="0" borderColorDark=#ffffff width=100% height="100%" borderColorLight=#A2A2A2 border=0>
                                                        <tr>
                                                            <td width="10%" class="tableTitle"  align="center">
                                                                년월
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                            
                                                            <td align="right" style="height: 23px">
                                                                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" onclick="iBtnSearch_Click" />&nbsp;
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
	                <tr>
	                    <td style="padding-left:5px;">
	                        <table border=0 width=100% height="100%">
	                            <tr>
	                                <td align="center" class="tableTitle">
	                                    공장별 락탐 계획량, 생산량, 전년동기 차액(생산량), 부하량, 계획과 생산차이 누계(한해)
	                                </td>
	                            </tr>
	                            <tr>
	                                <td width=100%>
	                                    <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
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
	                
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
            </form>
        <%Response.WriteFile("../_common/html/CommonBottom.htm");%>
