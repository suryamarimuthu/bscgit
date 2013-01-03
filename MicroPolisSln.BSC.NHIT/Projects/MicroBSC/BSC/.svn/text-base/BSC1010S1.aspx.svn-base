<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1010S1.aspx.cs" Inherits="BSC_BSC1010S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--

function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
       var cell         = igtbl_getElementById(id);
       cell.style.cursor = 'hand';
    }
}

function UltraWebGrid1_DblClickHandler(gridName, id)
{
	var cell            = igtbl_getElementById(id);
    var row             = igtbl_getRowById(id);
    var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
    var kpi_ref_id      = row.getCellFromKey("KPI_REF_ID").getValue();
    var ymd             = row.getCellFromKey("YMD").getValue();
    
//    location.href = 'BSC0304S2.aspx?ESTTERM_REF_ID='    + estterm_ref_id 
//                                + '&KPI_REF_ID='        + kpi_ref_id
//                                + '&YMD=' + ymd;
    
    gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID=' + estterm_ref_id + '&KPI_REF_ID=' + kpi_ref_id + '&YMD=' + ymd, 840, 600, 'no', 'no');
                                
}// -->
</script>
    
    
    <table cellpadding="0" cellspacing="0" width="1000px" height="100%" border="0">
        <tr>
            <td style="height:25px">
                <!-- 검색 조건 --->
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%;">
                    <tr>
                        <td style=" width:80px; height: 12px;" align="left" valign="bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/title/se_ti03.gif" />
                        </td>
                        <td valign="middle" style="height: 12px">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlEstTermInfo" class="box01" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMonthInfo" class="box01" runat="server" ></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSumType" class="box01" runat="server" ></asp:DropDownList>&nbsp;
                                    </td>
                                    <td onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'">
                                        <asp:TextBox ID="txtDropDown" runat="server" Width="178px" onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='default'" onclick="this.style.cursor='hand'" /><asp:TextBox ID="txtDeptID" runat="server" Width="0px" BorderColor="White" BorderWidth="0px" BorderStyle="None" CssClass="NotBoader" Height="0px" style="visibility:hidden;" />
                                        <asp:Panel ID="Panel1" runat="server" CssClass="popupControl">
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                            <ContentTemplate>
                                                <div style="BORDER-RIGHT: #f4f4f4 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: #f4f4f4 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; OVERFLOW:auto; BORDER-LEFT: #f4f4f4 1px solid; WIDTH: 200px; PADDING-TOP: 2px; BORDER-BOTTOM: #f4f4f4 1px solid; HEIGHT: 250px;background-color:White" id="leftLayer">
                                                    <asp:TreeView ID="trvEstDept" runat="server" 
                                                        OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged" 
                                                        NodeIndent="5">
                                                        <SelectedNodeStyle BackColor="Silver"></SelectedNodeStyle>
                                                    </asp:TreeView>
                                                </div>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>

                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server"
                                            TargetControlID="txtDropDown"
                                            PopupControlID="Panel1"
                                            Position="Bottom" />

                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender2" runat="server"
                                            TargetControlID="txtDeptID"
                                            PopupControlID="Panel1"
                                            Position="Bottom" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!-- 검색 조건 --->
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" width="100%" height="100%">
                    <tr height="20px">
                        <td width="60%" valign="top" style="color:#24425E;font-size:12px;font-family:굴림;font-weight:bold">
                            <img src="../images/icon/subtitle.gif" /> 종합 성과결과
                        </td>
                        <td style="color:#24425E;font-size:12px;font-family:굴림;font-weight:bold">
                            <img src="../images/icon/subtitle.gif" /> 주요 지표현황
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td >
                                                    <DGWC:GaugeContainer ID="gauTotal2" runat="server" BackColor="White" Height="120px" Width="160px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)" Visible="False">
                                                        <NumericIndicators>
                                                            <DGWC:NumericIndicator BackColor="White" BackGradientType="None" BorderColor="White"
                                                                BorderWidth="0" DecimalColor="Black" Decimals="2" DigitColor="Black" Digits="5"
                                                                LedDimColor="" Name="Default" Parent="" SeparatorColor="Transparent" ShowDecimalPoint="True"
                                                                ShowLeadingZeros="False" Value="367.12">
                                                                <Size Height="54" Width="91" />
                                                                <Location X="-7" Y="12" />
                                                            </DGWC:NumericIndicator>
                                                        </NumericIndicators>
                                                        <Values>
                                                            <DGWC:InputValue Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame BackColor="Transparent" BackGradientEndColor="Transparent" BackGradientType="None"
                                                            BorderColor="White" FrameColor="Transparent" FrameGradientEndColor="Transparent" Shape="Rectangular" FrameStyle="Simple" FrameGradientType="None" />
                                                            <StateIndicators>
	                                                        <dgwc:StateIndicator Name="StateIndicator1" ValueSource="Default" Parent="">
                                                                <Location X="26" Y="47" />
                                                                <Size Height="6" Width="12" />
	                                                        </dgwc:StateIndicator>
                                                        </StateIndicators>

                                                        <Labels>
                                                            <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Font="Microsoft Sans Serif, 9pt"
                                                                Name="Default" Parent="" ResizeMode="None" Text="전 사" TextAlignment="TopCenter">
                                                                <Size Height="30" Width="50" />
                                                                <Location X="27" Y="0" />
                                                            </DGWC:GaugeLabel>
                                                        </Labels>
                                                    </DGWC:GaugeContainer>
                                                    
                                                    <table cellpadding="0" cellspacing="0" width="177px" height="125px">
                                                        <tr>
                                                            <td background="../images/dashboard/boxbg_01.gif"> 

                                                                <table width="177" cellspacing="0" cellpadding="0"    >
                                                                    <tr>
                                                                        <td width="35" height="32">&nbsp;</td>
                                                                        <td align="center" valign="bottom" style="font-family:돋움;font-size:12px;font-weight:bold;color:#0615B0">
                                                                            <asp:HyperLink NavigateUrl="./BSC0404S1.ASPX" ID="lblEntTitle" runat="server" Text="전사 달성도" Width="98%"></asp:HyperLink>
                                                                        </td>
                                                                        <td width="35">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td height="2" bgcolor="#EE1C25"><img src="../images/dashboard/space_dot.gif" width="1" height="2" /></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="60">&nbsp;</td>
                                                                        <td align="center" style="font-family:돋움;font-size:45px;font-weight:bold;color:#6E7A7A">
                                                                            <asp:HyperLink NavigateUrl="./BSC0404S1.ASPX" ID="lblToatal" runat="server"></asp:HyperLink>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td align="center"  style="font-family:돋움;font-size:12px;font-weight:bold;color:#ED1B26">
                                                                            <label  id="lblRank"  runat="server"  ></label>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer ID="gauKPI1" runat="server" BackColor="White" Height="120px" Width="120px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)">
                                                        <CircularGauges>
                                                            <DGWC:CircularGauge Name="Default">
                                                                <Scales>
                                                                    <DGWC:CircularScale BorderColor="DarkRed" FillColor="Red" Name="Default" Radius="55"
                                                                        ShadowOffset="2" StartAngle="90" SweepAngle="90">
                                                                        <LabelStyle DistanceFromScale="3" Font="Microsoft Sans Serif, 14.25pt" RotateLabels="False"
                                                                        TextColor="White" />
                                                                        <MajorTickMark BorderColor="SteelBlue" BorderWidth="0" EnableGradient="False" FillColor="Blue"
                                                                        Length="2" Shape="Rectangle" Visible="False" Width="0" />
                                                                        <MinorTickMark BorderColor="Transparent" FillColor="Gold" Length="11" Shape="Trapezoid" />
                                                                    </DGWC:CircularScale>
                                                                </Scales>
                                                                <Size Height="100" Width="100" />
                                                                <PivotPoint X="80" Y="80" />
                                                                <Pointers>
                                                                <DGWC:CircularPointer BorderWidth="0" CapFillColor="White" CapFillGradientType="LeftRight"
                                                                    CapReflection="True" CapWidth="25" DampeningSweepTime="0" DistanceFromScale="10"
                                                                    FillColor="Red" FillGradientEndColor="DarkSalmon" FillGradientType="DiagonalLeft"
                                                                    Name="Default" ShadowOffset="3" SnappingEnabled="True" Width="18" />
                                                                </Pointers>
                                                                    <BackFrame BackColor="74, 115, 173" BackGradientEndColor="102, 204, 255" BackGradientType="DiagonalRight"
                                                                    BorderColor="Transparent" FrameColor="Transparent" FrameGradientEndColor="Transparent"
                                                                    FrameGradientType="None" FrameWidth="2" Shape="AutoShape" FrameStyle="Edged" />
                                                                <Location X="0" Y="0" />
                                                            </DGWC:CircularGauge>
                                                        </CircularGauges>
                                                        <Values>
                                                            <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame Shape="Rectangular" FrameStyle="None" BackColor="White" BackGradientEndColor="White" BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                        <Labels>
                                                            <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                            ResizeMode="None" Text="">
                                                            <Size Height="17" Width="100" />
                                                            <Location X="32" Y="0" />
                                                        </DGWC:GaugeLabel>
                                                        </Labels>
                                                        <StateIndicators>
                                                            <dgwc:StateIndicator Name="StateIndicator1" ValueSource="Default" Parent="CircularGauges.Default">
                                                                <Location X="26" Y="47" />
                                                                <Size Height="6" Width="12" />
                                                            </dgwc:StateIndicator>
                                                        </StateIndicators>
                                                    </DGWC:GaugeContainer>
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer ID="gauKPI2" runat="server" BackColor="White" Height="120px" Width="120px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)">
                                                        <CircularGauges>
                                                            <DGWC:CircularGauge Name="Default">
                                                                <Scales>
                                                                    <DGWC:CircularScale BorderColor="DarkRed" FillColor="Red" Name="Default" Radius="55"
                                                                        ShadowOffset="2" StartAngle="90" SweepAngle="90">
                                                                            <LabelStyle DistanceFromScale="3" Font="Microsoft Sans Serif, 14.25pt" RotateLabels="False"
                                                                            TextColor="White" />
                                                                            <MajorTickMark BorderColor="SteelBlue" BorderWidth="0" EnableGradient="False" FillColor="Blue"
                                                                            Length="2" Shape="Rectangle" Visible="False" Width="0" />
                                                                        <MinorTickMark BorderColor="Transparent" FillColor="Gold" Length="11" Shape="Trapezoid" />
                                                                    </DGWC:CircularScale>
                                                                    </Scales>
                                                                    <Size Height="100" Width="100" />
                                                                    <PivotPoint X="80" Y="80" />
                                                                    <Pointers>
                                                                        <DGWC:CircularPointer BorderWidth="0" CapFillColor="White" CapFillGradientType="LeftRight"
                                                                        CapReflection="True" CapWidth="25" DampeningSweepTime="0" DistanceFromScale="10"
                                                                        FillColor="Red" FillGradientEndColor="DarkSalmon" FillGradientType="DiagonalLeft"
                                                                        Name="Default" ShadowOffset="3" SnappingEnabled="True" Width="18" />
                                                                    </Pointers>
                                                                    <BackFrame BackColor="74, 115, 173" BackGradientEndColor="102, 204, 255" BackGradientType="DiagonalRight"
                                                                    BorderColor="Transparent" FrameColor="Transparent" FrameGradientEndColor="Transparent"
                                                                    FrameGradientType="None" FrameWidth="2" Shape="AutoShape" FrameStyle="Edged" />
                                                                <Location X="0" Y="0" />
                                                            </DGWC:CircularGauge>
                                                        </CircularGauges>
                                                        <Values>
                                                            <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame Shape="Rectangular" FrameStyle="None" BackColor="White" BackGradientEndColor="White" BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                        <Labels>
                                                            <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                ResizeMode="None" Text="">
                                                                <Size Height="17" Width="100" />
                                                                <Location X="32" Y="0" />
                                                            </DGWC:GaugeLabel>
                                                        </Labels>
                                                        <StateIndicators>
                                                            <dgwc:StateIndicator Name="StateIndicator1" ValueSource="Default" Parent="CircularGauges.Default">
                                                                <Location X="26" Y="47" />
                                                                <Size Height="6" Width="12" />
                                                            </dgwc:StateIndicator>
                                                        </StateIndicators>
                                                    </DGWC:GaugeContainer>
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer ID="gauKPI3" runat="server" BackColor="White" Height="120px" Width="120px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)">
                                                        <CircularGauges>
                                                            <DGWC:CircularGauge Name="Default">
                                                                <Scales>
                                                                    <DGWC:CircularScale BorderColor="DarkRed" FillColor="Red" Name="Default" Radius="55"
                                                                        ShadowOffset="2" StartAngle="90" SweepAngle="90">
                                                                        <LabelStyle DistanceFromScale="3" Font="Microsoft Sans Serif, 14.25pt" RotateLabels="False"
                                                                        TextColor="White" />
                                                                        <MajorTickMark BorderColor="SteelBlue" BorderWidth="0" EnableGradient="False" FillColor="Blue"
                                                                        Length="2" Shape="Rectangle" Visible="False" Width="0" />
                                                                        <MinorTickMark BorderColor="Transparent" FillColor="Gold" Length="11" Shape="Trapezoid" />
                                                                    </DGWC:CircularScale>
                                                                </Scales>
                                                                <Size Height="100" Width="100" />
                                                                <PivotPoint X="80" Y="80" />
                                                                <Pointers>
                                                                    <DGWC:CircularPointer BorderWidth="0" CapFillColor="White" CapFillGradientType="LeftRight"
                                                                    CapReflection="True" CapWidth="25" DampeningSweepTime="0" DistanceFromScale="10"
                                                                    FillColor="Red" FillGradientEndColor="DarkSalmon" FillGradientType="DiagonalLeft"
                                                                    Name="Default" ShadowOffset="3" SnappingEnabled="True" Width="18" />
                                                                </Pointers>
                                                                <BackFrame BackColor="74, 115, 173" BackGradientEndColor="102, 204, 255" BackGradientType="DiagonalRight"
                                                                BorderColor="Transparent" FrameColor="Transparent" FrameGradientEndColor="Transparent"
                                                                FrameGradientType="None" FrameWidth="2" Shape="AutoShape" FrameStyle="Edged" />
                                                            <Location X="0" Y="0" />
                                                        </DGWC:CircularGauge>
                                                        </CircularGauges>
                                                        <Values>
                                                            <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame Shape="Rectangular" FrameStyle="None" BackColor="White" BackGradientEndColor="White" BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                        <Labels>
                                                            <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                            ResizeMode="None" Text="">
                                                                <Size Height="17" Width="100" />
                                                                <Location X="32" Y="0" />
                                                            </DGWC:GaugeLabel>
                                                        </Labels>
                                                        <StateIndicators>
                                                            <dgwc:StateIndicator Name="StateIndicator1" ValueSource="Default" Parent="CircularGauges.Default">
                                                                <Location X="26" Y="47" />
                                                                <Size Height="6" Width="12" />
                                                            </dgwc:StateIndicator>
                                                        </StateIndicators>
                                                    </DGWC:GaugeContainer>
                                                </td>
                                                <td>
                                                    <DGWC:GaugeContainer ID="gauKPI4" runat="server" BackColor="White" Height="120px" Width="120px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)">
                                                        <CircularGauges>
                                                            <DGWC:CircularGauge Name="Default">
                                                            <Scales>
                                                                <DGWC:CircularScale BorderColor="DarkRed" FillColor="Red" Name="Default" Radius="55"
                                                                    ShadowOffset="2" StartAngle="90" SweepAngle="90">
                                                                    <LabelStyle DistanceFromScale="3" Font="Microsoft Sans Serif, 14.25pt" RotateLabels="False"
                                                                    TextColor="White" />
                                                                    <MajorTickMark BorderColor="SteelBlue" BorderWidth="0" EnableGradient="False" FillColor="Blue"
                                                                    Length="2" Shape="Rectangle" Visible="False" Width="0" />
                                                                    <MinorTickMark BorderColor="Transparent" FillColor="Gold" Length="11" Shape="Trapezoid" />
                                                                </DGWC:CircularScale>
                                                            </Scales>
                                                            <Size Height="100" Width="100" />
                                                            <PivotPoint X="80" Y="80" />
                                                            <Pointers>
                                                                <DGWC:CircularPointer BorderWidth="0" CapFillColor="White" CapFillGradientType="LeftRight"
                                                                CapReflection="True" CapWidth="25" DampeningSweepTime="0" DistanceFromScale="10"
                                                                FillColor="Red" FillGradientEndColor="DarkSalmon" FillGradientType="DiagonalLeft"
                                                                Name="Default" ShadowOffset="3" SnappingEnabled="True" Width="18" />
                                                            </Pointers>
                                                            <BackFrame BackColor="74, 115, 173" BackGradientEndColor="102, 204, 255" BackGradientType="DiagonalRight"
                                                                BorderColor="Transparent" FrameColor="Transparent" FrameGradientEndColor="Transparent"
                                                                FrameGradientType="None" FrameWidth="2" Shape="AutoShape" FrameStyle="Edged" />
                                                            <Location X="0" Y="0" />
                                                        </DGWC:CircularGauge>
                                                        </CircularGauges>
                                                        <Values>
                                                            <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                            </DGWC:InputValue>
                                                        </Values>
                                                        <BackFrame Shape="Rectangular" FrameStyle="None" BackColor="White" BackGradientEndColor="White" BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                        <Labels>
                                                            <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                ResizeMode="None" Text="">
                                                                <Size Height="18" Width="100" />
                                                                <Location X="32" Y="0" />
                                                            </DGWC:GaugeLabel>
                                                        </Labels>
                                                        <StateIndicators>
                                                            <dgwc:StateIndicator Name="StateIndicator1" ValueSource="Default" Parent="CircularGauges.Default">
                                                                <Location X="26" Y="47" />
                                                                <Size Height="6" Width="12" />
                                                            </dgwc:StateIndicator>
                                                        </StateIndicators>
                                                    </DGWC:GaugeContainer>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <DCWC:Chart ID="chtPart" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="720px" Height="130px" >
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisX>
                                                <Area3DStyle XAngle="10" YAngle="10" WallWidth="2"/>
                                                <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisY>
                                                <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisX2>
                                                <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisY2>
                                            </DCWC:ChartArea>
                                            </ChartAreas>
                                            <Titles >
                                                <DCWC:Title Alignment="TopCenter" Font="Tahoma, 11px" Name="Title1">
                                                </DCWC:Title>
                                            </Titles>
                                            <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Bottom"
                                                LegendStyle="Row" Name="Default" ShadowOffset="2"  Font="Dotum, 10px" AutoFitText="False" >
                                            </DCWC:Legend>
                                            </Legends>
                                            <Series>
                                                <DCWC:Series ChartType="Area" Name="Series1" XValueType="Double" YValueType="Double">
                                                </DCWC:Series>
                                            </Series>
                                        </DCWC:Chart>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr height="20px">
                                                <td width="70%" style="color:#24425E;font-size:12px;font-family:굴림;font-weight:bold">
                                                    <img src="../images/icon/subtitle.gif" /> 상위 Top10 지표
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="color:#24425E;font-size:12px;font-family:굴림;font-weight:bold">
                                                    <img src="../images/icon/subtitle.gif" /> 달성율분포
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <ig:UltraWebGrid ID="ugrdResultStatus" runat="server" Width="100%" Height="195px" OnInitializeRow="ugrdResultStatus_InitializeRow" OnInitializeLayout="ugrdResultStatus_InitializeLayout" >
                                                          <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                                                                            Hidden="True" Width="40px">
                                                                            <Header Caption="선택">
                                                                            </Header>
                                                                            <Footer Caption="">
                                                                            </Footer>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RANK" FooterText="" HeaderText="순위" Hidden="True"
                                                                            Key="RANK" Width="30px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="순위">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="KPI 코드" Hidden="True" Key="KPI_CODE" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 코드">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" HeaderText="운영부서" Hidden="True"
                                                                            Key="OP_DEPT_NAME">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="운영부서">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Justify">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="운영조직" Hidden="True" Key="DEPT_NAME">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="운영조직">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Header>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Hidden="True"
                                                                            Key="CHAMPION_EMP_NAME" Width="50px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI담당자">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="120px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 명">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Footer>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" HeaderText="실적 방식"
                                                                            Hidden="True" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적 방식">
                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME"
                                                                            Width="50px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="단위">
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET" DataType="System.Decimal" Format="###,###,##0.####"
                                                                            HeaderText="계획" Key="TARGET" Width="80px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="계획">
                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT" DataType="System.Decimal" Format="###,###,##0.####"
                                                                            HeaderText="실적" Key="RESULT" Width="80px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적">
                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" DataType="System.Decimal" Format="#,##0.00"
                                                                            HeaderText="달성율" Key="ACHIEVE_RATE" Width="50px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="달성율">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="PACT" DataType="System.Double" HeaderText="차이"
                                                                            Hidden="True" Key="PACT" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="차이">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL_IMAGE" HeaderText="신호" Key="SIGNAL_IMAGE" Width="35px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="신호">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TREND" HeaderText="추세" Key="TREND" Width="35px" Hidden="true">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="추세">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHECK_STEP" HeaderText="측정단계" Hidden="True"
                                                                            IsBound="True" Key="CHECK_STEP" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="측정단계">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Footer>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="PN_UTYPE" Hidden="True" Key="PN_UTYPE">
                                                                            <Header>
                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                            </Header>
                                                                            <Footer>
                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True">
                                                                        </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free" 
                                                                            AllowColumnMovingDefault="OnServer" 
                                                                            AllowDeleteDefault="Yes"
                                                                            AllowSortingDefault="No" 
                                                                            BorderCollapseDefault="Separate" 
                                                                            AutoGenerateColumns="False" 
                                                                            HeaderClickActionDefault="SortMulti" 
                                                                            Name="ugrdResultStatus" 
                                                                            RowHeightDefault="15px"
                                                                            RowSelectorsDefault="No" 
                                                                            SelectTypeRowDefault="Extended" 
                                                                            Version="4.00" 
                                                                            ViewType="OutlookGroupBy" 
                                                                            CellClickActionDefault="RowSelect" 
                                                                            TableLayout="Fixed" 
                                                                            StationaryMargins="Header">
                                                                    <GroupByBox>
                                                                        <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                                                                    </GroupByBox>
                                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                    </GroupByRowStyleDefault>
                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                    </FooterStyleDefault>
                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Font-Names="Dotum" Font-Size="11px">
                                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window"  />
                                                                        <Padding Left="3px" />
                                                                    </RowStyleDefault>
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                        <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                        BorderWidth="3px" Font-Names="Dotum" Font-Size="11px" Height="195px"
                                                                        Width="100%">
                                                                    </FrameStyle>
                                                                    <Pager>
                                                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                        </PagerStyle>
                                                                    </Pager>
                                                                    <AddNewBox Hidden="False">
                                                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                        </BoxStyle>
                                                                    </AddNewBox>
                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                    </SelectedRowStyleDefault>
                                                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="UltraWebGrid1_DblClickHandler" />
                                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                                </ActivationObject>
                                                                </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    <DCWC:Chart ID="chtFunnel" runat="server" BackColor="#D3DFF0" BackGradientEndColor="White"
                                                        BorderLineColor="26, 59, 105" BorderLineStyle="Solid" BorderLineWidth="2" Height="200px"
                                                        Palette="Dundas" Width="230px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                        <BorderSkin FrameBackColor="CornflowerBlue" FrameBackGradientEndColor="CornflowerBlue"
                                                        PageColor="AliceBlue" SkinStyle="Emboss" />
                                                        <Series>
                                                            <DCWC:Series BorderColor="26, 59, 105" ChartType="Funnel" CustomAttributes="FunnelLabelStyle=Outside, FunnelOutsideLabelPlacement=Right"
                                                            Name="Default" ShadowOffset="2" XValueType="Double" YValueType="Double" Font="Dotum, 9px" ShowLabelAsValue="True">
                                                            </DCWC:Series>
                                                        </Series>
                                                        <UI>
                                                            <Toolbar BorderColor="26, 59, 105">
                                                                <BorderSkin PageColor="Transparent" SkinStyle="Emboss" />
                                                            </Toolbar>
                                                        </UI>
                                                        <ChartAreas>
                                                            <DCWC:ChartArea BackColor="Transparent" BorderColor="Transparent" BorderStyle="Solid" Name="Default">
                                                                <AxisX>
                                                                    <MinorGrid LineColor="Silver" />
                                                                    <MajorGrid LineColor="Silver" />
                                                                </AxisX>
                                                                <Area3DStyle Enable3D="True" XAngle="0" YAngle="0" />
                                                                <AxisY>
                                                                    <MinorGrid LineColor="Silver" />
                                                                    <MajorGrid LineColor="Silver" />
                                                                </AxisY>
                                                                <AxisX2>
                                                                    <MinorGrid LineColor="Silver" />
                                                                    <MajorGrid LineColor="Silver" />
                                                                </AxisX2>
                                                                <AxisY2>
                                                                    <MinorGrid LineColor="Silver" />
                                                                    <MajorGrid LineColor="Silver" />
                                                                </AxisY2>
                                                            </DCWC:ChartArea>
                                                        </ChartAreas>
                                                        <Titles>
                                                            <DCWC:Title Name="Title1">
                                                            </DCWC:Title>
                                                        </Titles>
                                                        <Legends>
                                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Bottom"
                                                            Enabled="False" LegendStyle="Table" Name="Default" ShadowOffset="2">
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
                        <td valign="top">
                        
                            <ig:UltraWebTab ID="UltraWebTab1" runat="server" Height="100%" Width="100%" BorderStyle="None">
	                            <DefaultTabStyle BackColor="White" Height="20px">
	                            </DefaultTabStyle>
	                            <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
	                            <Tabs>
		                            <ig:Tab Key="CustomerInsert" Text="Line Graph">
			                            <Style Width="140px" Height="25px" Font-Bold="True" />
			                            <ContentTemplate>
			                            
			                            
			                                <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                    
                                                        <DCWC:Chart ID="chtKPI1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="170px" Height="100px" >
                                                             <ChartAreas>
                                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX><Area3DStyle XAngle="10" YAngle="10" WallWidth="2" Enable3D="True"/>
                                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                                        <LabelStyle Font="Tahoma, 10px" />
                                                                        <MajorGrid LineColor="196, 196, 196" />
                                                                    </AxisY>
                                                                    <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle Font="Tahoma, 10px" />
                                                                        <MajorGrid LineColor="196, 196, 196" />
                                                                    </AxisX2>
                                                                    <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                                        <LabelStyle Font="Tahoma, 10px" />
                                                                        <MajorGrid LineColor="196, 196, 196" />
                                                                    </AxisY2>
                                                                </DCWC:ChartArea>
                                                             </ChartAreas>
                                                             <Titles >
                                                                 <DCWC:Title Alignment="TopCenter" Font="Dotum, 8.25pt" Name="Title1">
                                                                 </DCWC:Title>
                                                             </Titles>
                                                             <Legends>
                                                                 <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default"
                                                                     ShadowOffset="2">
                                                                 </DCWC:Legend>
                                                             </Legends>
                                                             <BorderSkin FrameBackColor="Transparent" />
                                                             <Series>
                                                                 <DCWC:Series Name="Default" XValueType="Double" YValueType="Double">
                                                                 </DCWC:Series>
                                                             </Series>
                                                        </DCWC:Chart>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <DCWC:Chart ID="chtKPI2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="170px" Height="100px" >
                                                            <ChartAreas>
                                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                                BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX>
                                                                    <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX2>
                                                                    <Area3DStyle XAngle="10" YAngle="10" WallWidth="2" Enable3D="True"/>
                                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY>
                                                                    <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY2>
                                                                </DCWC:ChartArea>
                                                            </ChartAreas>
                                                            <Legends>
                                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                                            </DCWC:Legend>
                                                            </Legends>
                                                            <Titles >
                                                                <DCWC:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></DCWC:Title>
                                                            </Titles>
                                                        </DCWC:Chart>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <DCWC:Chart ID="chtKPI3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="180px" Height="100px" >
                                                            <ChartAreas>
                                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                                BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX>
                                                                    <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX2>
                                                                    <Area3DStyle XAngle="10" YAngle="10" WallWidth="2" Enable3D="True"/>
                                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY>
                                                                    <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY2>
                                                                </DCWC:ChartArea>
                                                            </ChartAreas>
                                                            <Legends>
                                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                                                </DCWC:Legend>
                                                            </Legends>
                                                            <Titles >
                                                                <DCWC:Title Alignment="TopCenter" Font="Dotum, 11px" Name="Title1"></DCWC:Title>
                                                            </Titles>
                                                        </DCWC:Chart>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <DCWC:Chart ID="chtKPI4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="180px" Height="100px" >
                                                            <ChartAreas>
                                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX>
                                                                    <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX2>
                                                                    <Area3DStyle XAngle="10" YAngle="10" WallWidth="2" Enable3D="True"/>
                                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY>
                                                                    <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY2>
                                                                </DCWC:ChartArea>
                                                            </ChartAreas>
                                                            <Legends>
                                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                                                </DCWC:Legend>
                                                            </Legends>
                                                            <Titles >
                                                                <DCWC:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></DCWC:Title>
                                                            </Titles>
                                                        </DCWC:Chart>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <DCWC:Chart ID="chtKPI5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="180px" Height="5px" >
                                                            <ChartAreas>
                                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX>
                                                                    <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX2>
                                                                    <Area3DStyle XAngle="10" YAngle="10" WallWidth="2" Enable3D="True"/>
                                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY>
                                                                    <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY2>
                                                                </DCWC:ChartArea>
                                                            </ChartAreas>
                                                            <Legends>
                                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                                                </DCWC:Legend>
                                                            </Legends>
                                                            <Titles >
                                                                <DCWC:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></DCWC:Title>
                                                            </Titles>
                                                        </DCWC:Chart>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <DCWC:Chart ID="chtKPI6" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="180px" Height="5px" >
                                                            <ChartAreas>
                                                                <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX>
                                                                    <AxisX2 linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisX2>
                                                                    <Area3DStyle XAngle="10" YAngle="10" WallWidth="2" Enable3D="True"/>
                                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY>
                                                                    <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                                    </AxisY2>
                                                                </DCWC:ChartArea>
                                                            </ChartAreas>
                                                            <Legends>
                                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                                                </DCWC:Legend>
                                                            </Legends>
                                                            <Titles >
                                                                <DCWC:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></DCWC:Title>
                                                            </Titles>
                                                        </DCWC:Chart>
                                                    </td>
                                                </tr>
                                            </table>
                							
			                            </ContentTemplate>
		                            </ig:Tab>
		                            <ig:Tab Key="CustomerSearch" Text="Radar Graph">
			                            <Style Width="140px" Height="25px" Font-Bold="True" />
			                            <ContentTemplate>
			                            
			                                
                                            <DCWC:Chart ID="chartRadar" runat="server" BackColor="#D3DFF0" BackGradientEndColor="White"
                                                BackGradientType="TopBottom" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                BorderLineWidth="2" Height="450px" ImageType="Png" ImageUrl="~\TempImages\ChartPic_#SEQ(300,3)"
                                                Palette="Dundas" Width="280px">
                                                <titles>
                                                    <dcwc:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"  Color="26, 59, 105"></dcwc:title>
                                                </titles>
                                                <legends>
                                                    <dcwc:legend  Alignment="Center" Docking="Top"  Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></dcwc:legend>
                                                </legends> 
                                                <BorderSkin SkinStyle="Emboss" />
                                                <chartareas>
                                                    <dcwc:chartarea Name="Chart Area 1" BorderColor="64, 64, 64, 64" BorderStyle="Solid" BackGradientEndColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientType="TopBottom">
                                                        <area3dstyle yangle="10" perspective="10" xangle="15" rightangleaxes="False" wallwidth="0" clustered="True"></area3dstyle>
                                                        <axisy linecolor="64, 64, 64, 64" labelsautofit="False" arrows="Triangle">
                                                            <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"  format="{#,0}" ></labelstyle>
                                                            <majorgrid linecolor="64, 64, 64, 64"></majorgrid>
                                                        </axisy>  
                                                        <axisx linecolor="64, 64, 64, 64" labelsautofit="False" arrows="Triangle">
                                                            <labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IntervalOffsetType="Auto" IntervalType="Auto" OffsetLabels="true"></labelstyle>
                                                            <majorgrid linecolor="64, 64, 64, 64"></majorgrid> 
                                                        </axisx>
                                                    </dcwc:chartarea>
                                                </chartareas>
                                            </DCWC:Chart>
			                                
			                                
                							
			                            </ContentTemplate>
		                            </ig:Tab>
                					
	                            </Tabs>
                            </ig:UltraWebTab>
                        
                        
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:linkbutton id="lBtnReload" runat="server" onclick="lBtnReload_Click"></asp:linkbutton>
    <asp:Literal ID="ltrScript" runat="server" />

</asp:Content>
