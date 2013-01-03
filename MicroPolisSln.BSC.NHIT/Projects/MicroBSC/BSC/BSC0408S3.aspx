<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0408S3.aspx.cs" Inherits="BSC_BSC0408S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
   <table cellspacing="0" cellpadding="0" border="0" style="width:100%; height:100%;" >
       <tr>
            <td> 
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%; width:980; background-color:Transparent;">
                   <tr>
                        <td> 
                            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="cssTblTitleSingle">평가기간</td>
                                    <td class="cssTblContentSingle">
                                        <table  cellspacing="0" cellpadding="0"  border="0">
                                            <tr>
                                                <td style="width:1px;">
                                                    <asp:DropDownList ID="ddlEstTermInfo" class="box01" runat="server"></asp:DropDownList>
                                                </td>
                                                <td style="width:1px;">
                                                    <asp:UpdatePanel ID="udpMonth" runat="server" UpdateMode="Conditional" RenderMode="Block">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlMonthInfo" class="box01" runat="server" ></asp:DropDownList>
                                                        </ContentTemplate>
                                                        <Triggers >
                                                            <asp:AsyncPostBackTrigger ControlID="ddlEstTermInfo" />
                                                        </Triggers>
                                                   </asp:UpdatePanel>
                                                </td>
                                                <td style="width:1px;">
                                                    <asp:DropDownList ID="ddlSumType" class="box01" runat="server" ></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                   </tr>
                   <tr>
                        <td >
                            <table  cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="전사현황"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="cssPopBtnLine">
                                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" ImageUrl="../images/btn/b_033.gif" />
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                   </tr>
                   <tr>
                        <td style="height:10%; vertical-align:top; width:980px;">
                            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%; background-color:Transparent;">
                                <col style="width:230px;"/>
                                <col style="width:520px;"/>
                                <col style="width:230px;"/>
                                <tr>
                                    <td align="center">
                                          <asp:Chart ID="chtEntGrade" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(50,3)" Width="100px" Height="100px" ></asp:Chart>
                                    </td>
                                    <td align="center">
                                          <asp:Chart ID="chtEntGradeTrend" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(50,3)" Width="100px" Height="100px" ></asp:Chart>
                                    </td>
                                    <td align="center">
                                          <asp:Chart ID="chtEntGradeView" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(50,3)" Width="100px" Height="100px" ></asp:Chart>
                                    </td>
                                </tr>
                            </table>
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <table  cellpadding="0" cellspacing="0" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label runat="server" ID="lblYmd" Text="-" Font-Bold="true"></asp:Label></td>
                                </tr>
                            </table>
                            
                        </td>
                   </tr>
                   <tr>
                        <td style="height:100%; vertical-align:top; width:980px;">
                            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
                                <tr>
                                    <td align="center" colspan="2" style="padding-top:15px;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
                                            <col align="center" style="width:25%; vertical-align:top;" />
                                            <col align="center" style="width:25%; vertical-align:top;" />
                                            <col align="center" style="width:25%; vertical-align:top;" />
                                            <col align="center" style="width:25%; vertical-align:top;" />
                                            <tr>
                                                <td style="height:20px;"><asp:Label ID="lblKpiName1" runat="server" Text="-" Font-Bold="true"></asp:Label></td>
                                                <td ><asp:Label ID="lblKpiName2" runat="server" Text="-" Font-Bold="true"></asp:Label></td>
                                                <td ><asp:Label ID="lblKpiName3" runat="server" Text="-" Font-Bold="true"></asp:Label></td>
                                                <td ><asp:Label ID="lblKpiName4" runat="server" Text="-" Font-Bold="true"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <DGWC:GaugeContainer id="GaugeKPI1" runat="server" backcolor="White" Height="130px" Width="240px" AutoLayout="true"></DGWC:GaugeContainer>
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer id="GaugeKPI2" runat="server" backcolor="White" Height="130px" Width="240px" AutoLayout="true"></DGWC:GaugeContainer>
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer id="GaugeKPI3" runat="server" backcolor="White" Height="130px" Width="240px" AutoLayout="true"></DGWC:GaugeContainer>
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer id="GaugeKPI4" runat="server" backcolor="White" Height="130px" Width="240px" AutoLayout="true"></DGWC:GaugeContainer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height:30px;" class="tableBorder">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <col align="center" style="width:20%; padding-right:5px;" />
                                                        <col align="left"  style="width:60%;" />
                                                        <col align="left"  style="width:20%; padding-left:3px;" />
                                                        <tr>
                                                            <td class="cssTblTitle">목표</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtTarget1" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td><asp:Label runat="server" ID="lblTargetUNm1" Text=""></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssTblTitle">실적</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtResult1" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td><asp:Label runat="server" ID="lblResultUNm1" Text=""></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="tableBorder">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <col align="center" style="width:20%; padding-right:5px;" />
                                                        <col align="left"  style="width:60%;" />
                                                        <col align="left"  style="width:20%; padding-left:3px;" />
                                                        <tr>
                                                            <td class="cssTblTitle">목표</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtTarget2" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td><asp:Label runat="server" ID="lblTargetUNm2" Text=""></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssTblTitle">실적</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtResult2" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td><asp:Label runat="server" ID="lblResultUNm2" Text=""></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="tableBorder">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <col align="center" style="width:20%; padding-right:5px;" />
                                                        <col align="left"  style="width:60%;" />
                                                        <col align="left"  style="width:20%; padding-left:3px;" />
                                                        <tr>
                                                            <td class="cssTblTitle">목표</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtTarget3" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td><asp:Label runat="server" ID="lblTargetUNm3" Text=""></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssTblTitle">실적</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtResult3" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td><asp:Label runat="server" ID="lblResultUNm3" Text=""></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="tableBorder">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <col align="center" style="width:20%; padding-right:5px;" />
                                                        <col align="left"  style="width:60%;" />
                                                        <col align="left"  style="width:20%; padding-left:3px;" />
                                                        <tr>
                                                            <td class="cssTblTitle">목표</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtTarget4" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td style="border-right: 1px solid LightBlue;"><asp:Label runat="server" ID="lblTargetUNm4" Text=""></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssTblTitle">실적</td>
                                                            <td><ig:WebNumericEdit runat="server" ID="txtResult4" Nullable="true" Width="100%"></ig:WebNumericEdit></td>
                                                            <td style="border-right: 1px solid LightBlue; border-bottom: 1px solid LightBlue;"><asp:Label runat="server" ID="lblResultUNm4" Text=""></asp:Label></td>
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
   </table>
   <asp:Label ID="lblEntScore" runat="server" Text="0" Visible="false"></asp:Label>
   <asp:Chart ID="chtEntViewSta" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(50,3)" Width="100px" Height="100px" Visible="false" ></asp:Chart>

</asp:Content>