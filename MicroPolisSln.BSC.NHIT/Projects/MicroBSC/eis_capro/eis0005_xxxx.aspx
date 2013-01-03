<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0005_xxxx.aspx.cs" Inherits="est0005" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
<link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
<!--- MAIN START --->
<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    	<tr>
    		<td height=50>
                <table cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" class="tableBorder" width="100%">
                                <tr>
                                    <td class="tableTitle" style="width: 100px">
                                        판매현황</td>
                                    <td class="tdBorder">
                                        <table cellSpacing=0 borderColorDark=#ffffff cellPadding=1 width=100% borderColorLight=#A2A2A2 border=1>
                                            <tr>
                                                <td width="10%" class="tableTitle"  align="right">
                                                    년월&nbsp;</td>
                                                <td width="20%" align="center">
                                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                    </td>
                                                <td align="right" style="height: 23px">
                                                    <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
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
    	<td style="padding-left:5px;" height="300" valign=Top>
    	<table border=0 width=100%>
    	    <tr>
    	        <td align="center" class="tableTitle">
                    년간 락탐 판매 추이</td>
    	        <td align="center" class="tableTitle">
    	            </td>
    	    </tr>
    	    <tr>
    	        <td>
    	            <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
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
