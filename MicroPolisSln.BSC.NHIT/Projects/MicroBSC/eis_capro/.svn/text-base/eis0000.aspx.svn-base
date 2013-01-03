<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0000.aspx.cs" Inherits="est0000" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
<link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
<!--- MAIN START --->
<table cellpadding="0" cellspacing="0" width="98%">
    <tr>
        <td class="tableoutBorder">
            <table cellSpacing=0 width=100% border=0>
                <tr>
                    <td width="15%" class="tableTitle"  align="center">
                        년월&nbsp;</td>
                    <td width="60%"  class="tableContent">
                        <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                        </asp:DropDownList>&nbsp;<asp:dropdownlist id="ddlMonth" runat="server"></asp:dropdownlist></td>
                    <td align="right"  class="tableContent">
                        <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table>
<tr><td height=5></td></tr>
</table>
<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    <tr>
    	<td height="300" valign=Top>
    	    <table border=0 width=100%>
    	        <tr>
    	            <td  class="subTitle">
    	            <table width="385" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td>
                                <img src="../images/icon/title_ic02.gif" align="absbottom" />공장별 생산계획대비 실적
                            </td>
                            <td align="right">
                                <a href='eis0004.aspx'><img src="../images/btn/bs_01.gif" align="absbottom" border=0 /></a>
                            </td>
                        </tr>
                    </table>
                    </td>
    	            <td class="subTitle">
    	            <table width="385" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td>
                                <img src="../images/icon/title_ic02.gif" align="absbottom" />락탐 판매실적
                            </td>
                            <td align="right">
                                <a href='eis0003.aspx'><img src="../images/btn/bs_01.gif" align="absbottom" border=0/></a>
                            </td>
                        </tr>
                    </table>
                    </td>
    	        </tr>
    	        <tr>
    	            <td>
    	                <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" Height="220px" >
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                             
                             BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <axisy linecolor="196, 196, 196">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
	                                </AxisY>
	                                <axisx linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
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
    	            <td>
    	                <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px"  Height="220px">
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                             
                             BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <axisy linecolor="196, 196, 196">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
	                                </AxisY>
	                                <axisx linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
		                                </AxisX>
                                <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="True"/>
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
    	            <td class="subTitle">
    	            <table width="385" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td>
                                <img src="../images/icon/title_ic01.gif" align="absbottom" />재고 현황 (전공장)
                            </td>
                            <td align="right">
                                <a href='eis0002.aspx'><img src="../images/btn/bs_01.gif" align="absbottom" /></a>
                            </td>
                        </tr>
                    </table>
                    </td>
    	            <td class="subTitle">
    	            <table width="385" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td>
                                <img src="../images/icon/title_ic01.gif" align="absbottom" />채권 현황
                            </td>
                            <td align="right">
                                <a href='eis0006.aspx'><img src="../images/btn/bs_01.gif" align="absbottom" /></a>
                            </td>
                        </tr>
                    </table>
                    </td>
    	        </tr>
    	        <tr>
    	            <td>
    	                <DCWC:Chart ID="Chart3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px" Height="220px" >
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                             
                             BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <axisy linecolor="196, 196, 196">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
	                                </AxisY>
	                                <axisx linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
		                                </AxisX>
                                <Area3DStyle YAngle="20" WallWidth="20" Enable3D="True" />
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
    	                <DCWC:Chart ID="Chart4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="400px"  Height="220px">
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                             
                             BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <axisy linecolor="196, 196, 196">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
	                                </AxisY>
	                                <axisx linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
		                                <labelstyle font="Tahoma, 10px"></LabelStyle>
		                                <majorgrid linecolor="196, 196, 196"></MajorGrid>
		                                </AxisX>
                                <Area3DStyle YAngle="20" WallWidth="20" Enable3D="True"/>
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
