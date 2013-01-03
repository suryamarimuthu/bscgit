<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0003.aspx.cs" Inherits="est0003" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
<link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
<!--- MAIN START --->
    <!--
    <table width="358" height="24" border="0" cellpadding="0" cellspacing="0" background="../images/title/title_bg1.gif">
         <tr>
             <td  class="title_m01">판매현황</td>
          </tr>
    </table>
    
    <table>
    <tr><td height=3></td></tr>
    </table>
    -->
    <table cellpadding="0" cellspacing="0" width="98%">
     <tr>
        <td>
            <table cellSpacing=0 width=100% border=0>
                    <tr>
                        <td width="15%">
                            <img src="../images/title/se_ti10.gif" align=absmiddle>
                        </td>
                        <td width="60%">
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    	<tr>
    	    <td valign=Top>
    	        <table border=0 width=100%>
    	            <tr>
    	                <td>
                            <table>
                                <tr>
    	                            <td class="subTitle">
                                        <img src="../images/icon/title_ic02.gif" align="absbottom" />년간 락탐 판매 추이
                                    </td>
                                    <td align="right"><font style="color:#666666;font-style:normal;">
                                        &nbsp;<b>왼쪽 축: </b>박편락탐, 수출용박편락탐 &nbsp;&nbsp; <b>오른쪽 축: </b>용융락탐</font>
                                    </td>
                                </tr>
                            </table>
                        </td>
    	            </tr>
    	            
    	            <tr>
    	                <td>
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
		                                <AxisX2 Interval="1" LabelsAutoFit="False" LineColor="196, 196, 196">
                                            <LabelStyle Font="Tahoma, 10px" />
                                            <MajorGrid LineColor="196, 196, 196" />
                                        </AxisX2>
                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5"  />
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
                <table border="0" width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
    	                            <td class="subTitle">
                                        <img src="../images/icon/title_ic02.gif" align="absbottom" />년간 유안 판매 추이
                                    </td>
                                    <td align="right"><font style="color:#666666;font-style:normal;">
                                        &nbsp;<b>왼쪽 축: </b>공업용유안, 농업용유안, 원료용유안, 이재유안 &nbsp;&nbsp; <b>오른쪽 축: </b>수출용유안</font>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                Palette="Dundas" Width="800px">
                                <ChartAreas>
                                    <DCWC:ChartArea BackColor="White" BackGradientEndColor="White" BorderColor="196, 196, 196"
                                        Name="Default" ShadowColor="Transparent">
                                        <AxisY LineColor="196, 196, 196" LabelsAutoFit="False">
                                            <LabelStyle Font="Tahoma, 10px" />
                                            <MajorGrid LineColor="196, 196, 196" />
                                        </AxisY>
                                        <AXISY2 linecolor="196, 196, 196" LabelsAutoFit="False">
                                            <labelstyle font="Tahoma, 10px"></LabelStyle>
                                            <majorgrid linecolor="196, 196, 196"></MajorGrid>
                                        </AxisY2>
                                        <AxisX Interval="1" LabelsAutoFit="False" LineColor="196, 196, 196">
                                            <LabelStyle Font="Tahoma, 10px" />
                                            <MajorGrid LineColor="196, 196, 196" />
                                        </AxisX>
                                        <AxisX2 Interval="1" LabelsAutoFit="False" LineColor="196, 196, 196">
                                            <LabelStyle Font="Tahoma, 10px" />
                                            <MajorGrid LineColor="196, 196, 196" />
                                        </AxisX2>
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
            <td width="10px"></td>
    	</tr>
    </table>
        
        
		
<!--- MAIN END --->
<%Response.WriteFile("../_common/html/MenuBottom.htm");%>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
