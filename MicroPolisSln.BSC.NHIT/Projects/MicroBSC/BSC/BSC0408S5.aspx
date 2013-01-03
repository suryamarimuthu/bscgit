<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0408S5.aspx.cs" Inherits="BSC_BSC0408S5" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



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
    
    location.href = 'BSC0304S2.aspx?ESTTERM_REF_ID='    + estterm_ref_id 
                                + '&KPI_REF_ID='        + kpi_ref_id 
                                + '&YMD='               + ymd;
}// -->
</script>
    
        
      

       <!--- MAIN START --->
<table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%;">
    <tr>
        <td >
            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="cssTblTitleSingle">평가기간</td>
                    <td class="cssTblContentSingle">
                        <asp:DropDownList ID="ddlEstTermInfo" class="box01" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="ddlMonthInfo" class="box01" runat="server" ></asp:DropDownList>
                        <asp:DropDownList ID="ddlSumType" class="box01" runat="server" ></asp:DropDownList>&nbsp;
                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="cssPopBtnLine">
            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                            OnClick="iBtnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <table cellspacing="0" cellpadding="0"  border="0" style="height:100%;">
                <tr>
                    <td align="left" valign="top">
                        <!--    시작//-->
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tr valign="top">
                                <td colspan="2" valign="top" align="left">
                                    <!--  게이지  시작//-->
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%" >
                                        <tr align="left">             
                                            <td valign="top"  style="width: 100%;" align="left">                    
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr align="right">
                                                        <td style="width:170px; height: 100%; padding-top: 5px;" align="center" valign="middle">
                                                            <DGWC:GaugeContainer ID="gauTotal2" runat="server" BackColor="White" Height="160px" Width="160px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)" Visible="False">
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
                                                                    BorderColor="White" FrameColor="Transparent" FrameGradientEndColor="Transparent" Shape="Rectangular" FrameGradientType="None" />
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
                                                            <asp:HyperLink NavigateUrl="./BSC0404S1.ASPX" ID="lblEntTitle" runat="server" Text="전사 달성도" Font-Bold="true" Width="98%"></asp:HyperLink><br /><br />
                                                            <asp:HyperLink NavigateUrl="./BSC0404S1.ASPX" ID="lblToatal" runat="server" Font-Names="휴먼엑스포" Text="00.00" Font-Size="XX-Large" Height="80%"></asp:HyperLink>
                                                            <!--
                                                            <DGWC:GaugeContainer id="gauTotal" runat="server" backcolor="White" Height="120px" Width="150px" ImageUrl="~/tempimages/GaugePic_#SEQ(300,3)"  >
                                                                <CircularGauges>
                                                                    <DGWC:CircularGauge Name="Default">
                                                                        <Ranges>
                                                                            <DGWC:CircularRange BorderStyle="Solid" DistanceFromScale="40" FillColor="255, 210, 0"
                                                                                FillGradientEndColor="Yellow" InRangeLabelColor="White" Name="Default" StartWidth="18" />
                                                                        </Ranges>
                                                                        <Scales>
                                                                            <DGWC:CircularScale BorderColor="Firebrick" FillColor="Red" Name="Default" Radius="50"
                                                                             ShadowOffset="3" StartAngle="90" SweepAngle="180">
                                                                             <LabelStyle Font="Microsoft Sans Serif, 15.75pt, style=Bold" RotateLabels="False"
                                                                                 TextColor="White" />
                                                                             <MajorTickMark BorderColor="LightGray" BorderWidth="2" DistanceFromScale="-2" FillColor="White"
                                                                                 Length="9" Width="3" />
                                                                             <MinorTickMark BorderColor="Silver" FillColor="Gainsboro" Length="7" Shape="Trapezoid"
                                                                                 Width="2" />
                                                                            </DGWC:CircularScale>
                                                                        </Scales>
                                                                        <Size Height="100" Width="100" />
                                                                        <PivotPoint X="50" Y="82" />
                                                                        <Pointers>
                                                                            <DGWC:CircularPointer BorderWidth="0" CapFillColor="White" CapFillGradientEndColor="DarkGray"
                                                                            CapFillGradientType="LeftRight" CapReflection="True" CapWidth="20" DampeningSweepTime="0"
                                                                            DistanceFromScale="-13" FillColor="Red" FillGradientEndColor="Maroon" Name="Default"
                                                                            Placement="Outside" ShadowOffset="1" ValueSource="Default" Width="14" />
                                                                        </Pointers>
                                                                        <BackFrame BackColor="74, 115, 173" BackGradientEndColor="102, 204, 255" BackGradientType="DiagonalRight"
                                                                            BorderColor="Transparent" FrameColor="Transparent" FrameGradientEndColor="Transparent"
                                                                            FrameGradientType="None" FrameWidth="0" Shape="AutoShape" Style="edged" />
                                                                        <Location X="0" Y="0" />
                                                                    </DGWC:CircularGauge>
                                                                </CircularGauges>
                                                                <Labels>
                                                                    <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                        Text="전사점수" TextAlignment="MiddleCenter">
                                                                        <Size Height="17" Width="44" />
                                                                        <Location X="27" Y="5" />
                                                                    </DGWC:GaugeLabel>
                                                                </Labels>
                                                                <Values>
                                                                    <DGWC:InputValue Name="Default">
                                                                    </DGWC:InputValue>
                                                                </Values>
                                                                <BackFrame BorderColor="Transparent" FrameWidth="0" Shape="Rectangular"
                                                                    Style="none" FrameGradientType="None" BackColor="Transparent" BackGradientEndColor="Transparent" BackGradientType="None" FrameColor="Transparent" FrameGradientEndColor="Transparent" />
                                                            </DGWC:GaugeContainer>
                                                            //-->                 
                                                        </td>
                                                        <td  align="right" style="width:120px;padding-top: 5px;">
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
                                                                            FrameGradientType="None" FrameWidth="2" Shape="AutoShape" />
                                                                        <Location X="0" Y="0" />
                                                                    </DGWC:CircularGauge>
                                                                </CircularGauges>
                                                                <Values>
                                                                    <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                                    </DGWC:InputValue>
                                                                </Values>
                                                                <BackFrame Shape="Rectangular" BackColor="White"  BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                                <Labels>
                                                                    <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                        ResizeMode="None" Text="">
                                                                        <Size Height="17" Width="50" />
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
                                                        <td  align="right" style="width:120px;padding-top: 5px;">
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
                                                                            FrameGradientType="None" FrameWidth="2" Shape="AutoShape" />
                                                                        <Location X="0" Y="0" />
                                                                    </DGWC:CircularGauge>
                                                                </CircularGauges>
                                                                <Values>
                                                                    <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                                    </DGWC:InputValue>
                                                                </Values>
                                                                <BackFrame Shape="Rectangular" BackColor="White"  BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                                <Labels>
                                                                    <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                        ResizeMode="None" Text="">
                                                                        <Size Height="17" Width="50" />
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
                                                        <td  align="right" style="width:120px;padding-top: 5px;">
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
                                                                            FrameGradientType="None" FrameWidth="2" Shape="AutoShape" />
                                                                        <Location X="0" Y="0" />
                                                                    </DGWC:CircularGauge>
                                                                </CircularGauges>
                                                                <Values>
                                                                    <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                                    </DGWC:InputValue>
                                                                </Values>
                                                                <BackFrame Shape="Rectangular" BackColor="White"  BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                                <Labels>
                                                                    <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                        ResizeMode="None" Text="">
                                                                        <Size Height="17" Width="50" />
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
                                                        <td  align="left" style="width:120px;padding-top: 5px;">
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
                                                                            FrameGradientType="None" FrameWidth="2" Shape="AutoShape" />
                                                                        <Location X="0" Y="0" />
                                                                    </DGWC:CircularGauge>
                                                                </CircularGauges>
                                                                <Values>
                                                                    <DGWC:InputValue HistoryDepth="10" Name="Default">
                                                                    </DGWC:InputValue>
                                                                </Values>
                                                                <BackFrame Shape="Rectangular" BackColor="White"  BackGradientType="None" FrameColor="White" FrameGradientEndColor="White" FrameGradientType="None" FrameWidth="0"  />
                                                                <Labels>
                                                                    <DGWC:GaugeLabel BackColor="" BackGradientEndColor="" Name="Label1" Parent="CircularGauges.Default"
                                                                        ResizeMode="None" Text="">
                                                                        <Size Height="17" Width="60" />
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
                                    </table>
                                    <!--  게이지  끝//-->
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="top" align="center">
                                    <DCWC:Chart ID="chtPart" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="200px"  Width="760px" >
                                        <ChartAreas>
                                            <DCWC:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            
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
                                <td valign="top" style="width: 100%; height:100%; text-align:center;">


                <table cellspacing="0" cellpadding="0" width="680px"  border="0" style="height:100%; ">

                    <tr>
                        <td>
                        <img alt="" src="../images/icon/left_icon01.gif" style="vertical-align:middle;" />
                                                                                전사 스코어카드
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 100%; width: 100%; " align="center">
            <!-- 우측 컨텐츠 영역 -->
            <div style="clear:both; width:680px; height:180px;  " >
                 <ig:UltraWebGrid ID="ugrdResultScore" runat="server" Width="100%" Height="100%" 
                     OnInitializeRow="ugrdResultScore_InitializeRow" >
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
                        <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" HeaderText="평가부서"
                            Key="EST_DEPT_NAME" Hidden="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="평가부서">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="VIEW_NAME" HeaderText="VIEW_NAME"
                            Key="VIEW_NAME" MergeCells="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="관점명">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                            Format="" HeaderText="KPI 코드" Key="KPI_CODE" Hidden="True"  Width="60px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI 코드">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="140px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI 명">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                            Width="85px" Hidden="True" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI담당자">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" HeaderText="실적 방식"
                            Key="RESULT_INPUT_TYPE_NAME" Width="60px" Hidden="True" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="실적 방식">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="단위">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                       <ig:UltraGridColumn BaseColumnName="THRESHOLD_IMG" HeaderText="신호" Key="THRESHOLD_IMG"
                            Width="35px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="신호">
                                <RowLayoutColumnInfo OriginX="11" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="11" />
                            </Footer>
                        </ig:UltraGridColumn>
                       
                        <ig:UltraGridColumn BaseColumnName="TREND" HeaderText="추세" Key="TREND" Width="35px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="추세">
                                <RowLayoutColumnInfo OriginX="12" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="12" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="TARGET" DataType="System.Decimal" Format="###,###,##0.####"
                            HeaderText="계획" Key="TARGET" Width="80px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="계획">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="RESULT" DataType="System.Decimal" Format="###,###,##0.####"
                            HeaderText="실적" Key="RESULT" Width="80px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="실적">
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="PACT" DataType="System.Double" HeaderText="차이"
                            Hidden="True" Key="PACT" Width="60px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="차이">
                                <RowLayoutColumnInfo OriginX="10" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="10" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn HeaderText="측정대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="60px" Hidden="True" >
                            <Header Caption="측정대상">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <HeaderStyle Wrap="true" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                         <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                            <Header Caption="ESTTERM_REF_ID">
                                <RowLayoutColumnInfo OriginX="18" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="18" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                            <Header Caption="KPI_REF_ID">
                                <RowLayoutColumnInfo OriginX="19" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="19" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True" >
                            <Header Caption="YMD">
                                <RowLayoutColumnInfo OriginX="20" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="20" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                    </RowTemplateStyle>
                </ig:UltraGridBand>
            </Bands>
            <DisplayLayout  AllowColSizingDefault="Free" 
                            AllowColumnMovingDefault="OnServer" 
                            AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes" 
                            BorderCollapseDefault="Separate" 
                            AutoGenerateColumns="False" 
                            HeaderClickActionDefault="SortMulti" 
                            Name="ugrdResultScore" 
                            RowHeightDefault="20px"
                            RowSelectorsDefault="No" 
                            SelectTypeRowDefault="Extended" 
                            Version="4.00" 
                            CellClickActionDefault="RowSelect" 
                            TableLayout="Fixed" 
                            StationaryMargins="Header"
                            ReadOnly="LevelTwo"
                            OptimizeCSSClassNamesOutput="False">
                   
                    <GroupByBox>
                        <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                    </GroupByBox>
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>                            
                
                </DisplayLayout>
        </ig:UltraWebGrid>
                       
                       </div> </td>
                    </tr>
                </table>
                                    <!--  그리드  끝//-->
                                </td>
                                <td  align="left" valign="top">
                                    
                                    <!--  차트  끝//-->
                                </td>
                            </tr>            
                        </table>
                        <!--    끝//-->             
                    </td>
                    <td style=" width:450px;height:100%;" align="left" valign="top">
                        <!--  당월/누계 구분 차트  시작//-->
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%;">
                            <tr>
                                <td style="height:15px; font-size: 11px; padding-top: 5px; padding-left: 5px;">
                                    <img alt="" src="../images/icon/left_icon01.gif" style="vertical-align:middle;" /> 주요지표현황
                                </td>
                            </tr>
                            <tr>
                                <td  style=" width:100%; height: 100%;" align="left" valign="top">
                                    <div style=" width:450px; height: 100%; overflow:auto;" >
                                        <div style=" width:100%; height: 96px;">
                                            <DCWC:Chart ID="chtKPI1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="10px"  Width="10px" >
                                                <ChartAreas>
                                                    <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisY>
                                                    
                                                    </DCWC:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    </DCWC:Legend>
                                                </Legends>
                                            </DCWC:Chart>

                                        </div>
           
                                        <div  style=" width:100%; height: 96px;" >                 
                                            <DCWC:Chart ID="chtKPI2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="10px"  Width="10px" >
                                                <ChartAreas>
                                                    <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisY>
                                                    
                                                    </DCWC:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    </DCWC:Legend>
                                                </Legends>
                                            </DCWC:Chart>

                                        </div>
                                
                                        <div  style=" width:100%; height: 100px;" >
                                            <DCWC:Chart ID="chtKPI3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="10px"  Width="10px" >
                                                <ChartAreas>
                                                    <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisY>
                                                    
                                                    </DCWC:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    </DCWC:Legend>
                                                </Legends>
                                            </DCWC:Chart>

                                        </div>
                         
                                        <div  style=" width:100%; height: 100px;">
                                             <DCWC:Chart ID="chtKPI4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="10px"  Width="10px" >
                                                <ChartAreas>
                                                    <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisY>
                                                    
                                                    </DCWC:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    </DCWC:Legend>
                                                </Legends>
                                            </DCWC:Chart>
                                        </div>
                          
                                        <div style=" width:100%; " align="left" >
                                              <DCWC:Chart ID="chtKPI5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="10px"  Width="10px" >
                                                <ChartAreas>
                                                    <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisY>
                                                    
                                                    </DCWC:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    </DCWC:Legend>
                                                </Legends>
                                            </DCWC:Chart>
                                            
                                        </div >
                           
                                        <div  style=" width:100%;" align="left">
                                            <DCWC:Chart ID="chtKPI6" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="10px"  Width="10px" >
                                                <ChartAreas>
                                                    <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                                    BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                                    <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                                    <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                    </AxisY>
                                                    
                                                    </DCWC:ChartArea>
                                                </ChartAreas>
                                                <Legends>
                                                    <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                    </DCWC:Legend>
                                                </Legends>
                                            </DCWC:Chart>
                                        </div>
                                    </div>
                                </td>
                            </tr>             
                        </table>             
                        <!--  당월/누계 구분 차트  끝//-->
                    </td>             
                </tr>
            </table> 
        </td>
    </tr>
</table>
       <asp:linkbutton id="lBtnReload" runat="server" onclick="lBtnReload_Click"></asp:linkbutton>
       <asp:Literal ID="ltrScript" runat="server" />
       <!--- MAIN END --->
 </asp:Content>
