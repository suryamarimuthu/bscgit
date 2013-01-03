<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis0002.aspx.cs" Inherits="eis_eis0002" %>


<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
        <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
        <%Response.WriteFile("../_common/html/CommonTop.htm");%>
            <form id="form1" runat="server">
            <div>
        <MenuControl:MenuControl ID="MenuControl1" runat="server" />
        <!--- MAIN START --->
        <script type="text/javascript">
        
            function himgDaily_Click()
            {
                gfOpenDialog("eis0002_Daily_Main.aspx", "", 820, 500);
            }
        </script>
        
        <table cellpadding="0" cellspacing="0" width="98%">
             <tr>
                <td>
                    <table cellSpacing=0 width=100% border=0>
                            <tr>
                            <td width="15%" align="center">
                               <img src="../images/title/se_ti10.gif" align=absmiddle>
                            </td>
                            <td width="40%">
                                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                                </asp:DropDownList>
                            </td>
                            <td width="10%"  align="center">
                                <img src="../images/title/opt_s08.gif" align="absmiddle"/>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGong" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                                </asp:DropDownList>
                            </td>
                            
                            <td width="10%"  align="center">
                                <img src="../images/title/opt_s09.gif" align="absmiddle"/>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlItem" runat="server" AppendDataBoundItems="True" EnableTheming="False" class="box01">
                                </asp:DropDownList>&nbsp;&nbsp;
                            </td>
                            <td align=right>
                                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" onclick="iBtnSearch_Click" />
                                <%--&nbsp;
                                <img src="../images/btn/b_047.gif" id="himgDaily" style="cursor:hand" onclick="himgDaily_Click();" />--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                <table border="0" cellspacing="0" cellpadding="0" width="100%"  >
	                <tr>
	                    <td>
	                        <table border=0 width=100% height="100%">
	                            <tr>
	                                <td>
	                                    <table>
	                                        <tr>
	                                            <td class="subTitle">
                                                    <img src="../images/icon/title_ic02.gif" align="absbottom" />주요 제품별 일간 재고현황
                                                </td>
                                                <td align="right"><font style="color:#666666;font-style:normal;">
                                                    &nbsp;<b>왼쪽 축: </b>카프로락탐, 박편락탐, 싸이크로헥산, 아논 &nbsp;&nbsp; <b>오른쪽 축: </b>유안벌크</font>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
	                            </tr>
	                            <tr>
	                                <td width=100%>
	                                    <DCWC:Chart ID="Chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="800px" >
                                            <Titles>
						                        <dcwc:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 13pt, style=Bold" ShadowOffset="3" Alignment="BottomCenter" Color="26, 59, 105" Name="Title1">
						                        </dcwc:Title>
					                        </Titles>
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
	                            
	                            <tr>
	                                <td height="20px">
	                                </td>
	                            </tr>
	                            <tr>
	                                <td>
	                                    <table>
	                                        <tr>
	                                            <td class="subTitle">
                                                    <img src="../images/icon/title_ic02.gif" align="absbottom" />주요 제품별 재고현황
                                                </td>
                                                <td align="right"><font style="color:#666666;font-style:normal;">
                                                    &nbsp;<b>왼쪽 축: </b>카프로락탐, 박편락탐, 싸이크로헥산, 아논 &nbsp;&nbsp; <b>오른쪽 축: </b>유안벌크</font>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
	                            </tr>
	                            <tr>
	                                <td width=100%>
	                                    <DCWC:Chart ID="Chart5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                            
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
                                                        <labelstyle font="Tahoma, 14px"></LabelStyle>
                                                        <majorgrid linecolor="196, 196, 196"></MajorGrid>
                                                        </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5"/>
                                                </DCWC:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                </DCWC:Legend>
                                            </Legends>
                                        </DCWC:Chart>
	                                <td>
	                            </tr>
	                            <tr>
	                                <td>
	                                    <table>
	                                        <%--<tr>
	                                            <td class="subTitle"><img src="../images/icon/title_ic02.gif" align="absbottom" />1공장</td>
                                                <td class="subTitle"><img src="../images/icon/title_ic02.gif" align="absbottom" />2공장</td>
                                                <td class="subTitle"><img src="../images/icon/title_ic02.gif" align="absbottom" />3공장</td>
	                                        </tr>--%>
                                            <tr>
                                                <td>
                                                    <DCWC:Chart ID="Chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" Enabled="False" Visible="False" >
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
                                                <td>
                                                    <DCWC:Chart ID="Chart3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" Enabled="False" Visible="False" >
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
                                                                <Area3DStyle XAngle="15" YAngle="10" WallWidth="5"/>
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
                                                    <DCWC:Chart ID="Chart4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" Enabled="False" Visible="False" >
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
                                                                <Area3DStyle XAngle="15" YAngle="10" WallWidth="5"/>
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
                        <td width="10px"></td>
	                </tr>
                </table>
                <!--- MAIN END --->
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
            </form>
        <%Response.WriteFile("../_common/html/CommonBottom.htm");%>