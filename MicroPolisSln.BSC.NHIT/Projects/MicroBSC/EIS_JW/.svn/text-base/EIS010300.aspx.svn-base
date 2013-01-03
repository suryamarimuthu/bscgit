<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS010300.aspx.cs" Inherits="EIS_EIS010300" %>

<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

        <script type="text/javascript">

        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr height="10px">
                <td></td>
            </tr>
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr height="20%">
                            <td valign="top">
                                <table width="900px" cellpadding="0" cellspacing="0">
                                    
                                    <tr height="25px">
                                        <%--<td colspan="2"><img align="absMiddle" src="../images/icon/left_icon01.gif"/><b>사업부별 매출현황</b></td>--%>
                                        <td width="480px"><img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>사업부별 Global매출현황(법인제외)</b></td>
                                        <td></td>
                                        <td align="right">(단위:백만원)&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    </tr>
                                    <%--<tr>
                                        <td><img align="absMiddle" src="../images/arrow/arrow.gif"/><b>DD사업부</b></td>
                                        <td><img align="absMiddle" src="../images/arrow/arrow.gif"/><b>DO사업부</b></td>
                                    </tr>--%>
                                    <tr>
                                        <td valign="top">
                                            <DCWC:Chart ID="Chart1" runat="server" 
                                                ImageUrl="../TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="50px" Height="100px">
                                                <ChartAreas>
                                                    <dcwc:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                                                        <position y="15" height="78" width="88" x="5"></Position>
                                                        <axisy linecolor="64, 64, 64, 64" LabelsAutoFit="False">
	                                                        <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
	                                                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                                                        <majortickmark size="0.6"></MajorTickMark>
                                                        </AxisY>
                                                        <axisx linecolor="64, 64, 64, 64" LabelsAutoFit="False" Interval="1">
	                                                        <labelstyle font="Gulim, 12px"></LabelStyle>
	                                                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                                                        </AxisX>
                                                    </dcwc:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                   <DCWC:Legend Name="Default">
                                                   </DCWC:Legend>
                                               </Legends>
                                            </DCWC:Chart>
                                        </td>
                                        <td></td>
                                        <td  valign="top">
                                            <DCWC:Chart ID="Chart2" runat="server" 
                                                ImageUrl="../TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="50px" Height="100px">
                                                <ChartAreas>
                                                    <dcwc:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                                                        <position y="15" height="78" width="88" x="5"></Position>
                                                        <axisy linecolor="64, 64, 64, 64" LabelsAutoFit="False">
	                                                        <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
	                                                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                                                        <majortickmark size="0.6"></MajorTickMark>
                                                        </AxisY>
                                                        <axisx linecolor="64, 64, 64, 64" LabelsAutoFit="False" Interval="1">
	                                                        <labelstyle font="Gulim, 12px"></LabelStyle>
	                                                        <majorgrid linecolor="64, 64, 64, 64"></MajorGrid>
	                                                        </AxisX>
                                                    </dcwc:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                   <DCWC:Legend Name="Default">
                                                   </DCWC:Legend>
                                               </Legends>
                                            </DCWC:Chart>
                                        </td>
                                    </tr>
                                    <tr height="30px">
                                        <td>&nbsp;&nbsp;&nbsp;합계 : <asp:Label ID="lblL" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label> 백만원</td>
                                        <td></td>
                                        <td>&nbsp;&nbsp;&nbsp;합계 : <asp:Label ID="lblR" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label> 백만원</td>
                                    </tr>
                                    <tr height="20px">
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>DD사업부분</b>
                                            <iframe id="ifmContent1" runat="server" frameborder="0" width="100%" height="80px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>DO사업부문</b>
                                            <iframe id="ifmContent2" runat="server" frameborder="0" width="100%" height="80px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
        <asp:literal id="ltrScript" runat="server"></asp:literal>     
        <!--- MAIN END --->
    </form>
</body>
</html>
