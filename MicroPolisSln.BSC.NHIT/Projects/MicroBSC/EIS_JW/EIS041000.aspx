<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS041000.aspx.cs" Inherits="EIS_EIS041000" %>

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
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr height="20%">
                            <td valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr height="10px">
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr height="25px">
                                        <td><img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>장기채권액 현황</b></td>
                                        <td>&nbsp;</td>
                                        <td><img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>거래처별 금액 및 발생시기</b></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top" width="50%">
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
                                        <td>&nbsp;&nbsp;</td>
                                        <td align="center">
                                            <iframe id="ifmContent1" runat="server" frameborder="0" width="100%" height="160px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                                        </td>
                                    </tr>
                                    <%--<tr height="30px">
                                        <td>&nbsp;&nbsp;&nbsp;전년동기대비 증가율 : <asp:Label ID="lblL" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                        <td>&nbsp;&nbsp;&nbsp;전년동기대비 증가율 : <asp:Label ID="lblR" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>--%>
                                    <tr height="25px">
                                        <td colspan="3">
                                            <img align="absMiddle" src="../images/arrow/arrow.gif"/> <b>미수금 관련 현 진행상황 및 향후 회수방안</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <iframe id="ifmContent2" runat="server" frameborder="0" width="100%" height="230px" marginwidth="0" marginheight="0" scrolling="no"></iframe>
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
