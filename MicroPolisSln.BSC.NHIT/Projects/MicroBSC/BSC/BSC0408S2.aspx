﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0408S2.aspx.cs" Inherits="BSC_BSC0408S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

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

    gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID=' + estterm_ref_id + '&KPI_REF_ID=' + kpi_ref_id + '&YMD=' + ymd, 840, 600, 'no', 'no');
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
                                    <asp:Chart ID="chtPart" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="720px" Height="130px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196"  IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisX>
                                                <Area3DStyle  WallWidth="2"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisY>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisX2>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter" Font="Tahoma, 11px" Name="Title1">
                                            </asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Bottom"
                                                LegendStyle="Row" Name="Default" ShadowOffset="2"  Font="Dotum, 10px"  IsTextAutoFit="False" >
                                            </asp:Legend>
                                        </Legends>
                                        <Series>
                                            <asp:Series ChartType="Area" Name="Series1" XValueType="Double" YValueType="Double">
                                            </asp:Series>
                                        </Series>
                                    </asp:Chart>
                                </td>             
                            </tr>             
                            <tr>
                                <td valign="top" style="width: 440px;height:100%;">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%;">
                                        <tr valign="top">
                                            <td style="height:15px; width: 405px; font-size: 11px; padding-left: 5px;" valign="top" colspan="2">
                                                <img alt="" src="../images/icon/left_icon01.gif" style="vertical-align:middle;" />
                                                상위Top10 지표
                                            </td>
                                        </tr>               
                                        <!--  그리드  시작//-->
                                        <tr>
                                            <td style="width: 430px;height:100%; padding-left: 5px;" valign="top">
                                                <ig:UltraWebGrid  ID="ugrdResultStatus" runat="server" Width="99%" Height="100%" OnInitializeRow="ugrdResultStatus_InitializeRow" OnInitializeLayout="ugrdResultStatus_InitializeLayout" >
                                                    <Bands>
                                                        <ig:UltraGridBand>
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
                                                                    <CellStyle HorizontalAlign="Right"></CellStyle>
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
                                                                <ig:UltraGridColumn BaseColumnName="SIGNAL_IMAGE" HeaderText="신호" Key="SIGNAL_IMAGE"
                                                                    Width="35px">
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
                                                                <ig:UltraGridColumn BaseColumnName="TREND" HeaderText="추세" Hidden="True" Key="TREND"
                                                                    Width="35px">
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
                                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                                                    Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                    <Header Caption="ESTTERM_REF_ID">
                                                                        <RowLayoutColumnInfo OriginX="17" />
                                                                    </Header>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="17" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" EditorControlID="" FooterText=""
                                                                    Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                    <Header Caption="KPI_REF_ID">
                                                                        <RowLayoutColumnInfo OriginX="18" />
                                                                    </Header>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="18" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText="" Format=""
                                                                    HeaderText="YMD" Hidden="True" Key="YMD">
                                                                    <Header Caption="YMD">
                                                                        <RowLayoutColumnInfo OriginX="19" />
                                                                    </Header>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="19" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                            </Columns>
                                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                                            </RowTemplateStyle>
                                                        </ig:UltraGridBand>
                                                    </Bands>
                                                    <DisplayLayout AllowColSizingDefault="Free" 
                                                                    AllowDeleteDefault="Yes"
                                                                    AllowColumnMovingDefault="None"
                                                                    AllowSortingDefault="No" 
                                                                    BorderCollapseDefault="Separate" 
                                                                    AutoGenerateColumns="False" 
                                                                    HeaderClickActionDefault="SortMulti" 
                                                                    Name="ugrdResultStatus" 
                                                                    RowHeightDefault="18px"
                                                                    RowSelectorsDefault="No" 
                                                                    SelectTypeRowDefault="Extended" 
                                                                    Version="4.00" 
                                                                    ViewType="OutlookGroupBy" 
                                                                    CellClickActionDefault="RowSelect" 
                                                                    TableLayout="Fixed" 
                                                                    StationaryMargins="Header">
                                                        <%--<GroupByBox>
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
                                                        <FrameStyle BackColor="Window" BorderColor="White" BorderStyle="Solid"
                                                            BorderWidth="3px" Font-Names="Dotum" Font-Size="11px" Height="210px"
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
                                                        </ActivationObject>--%>
                                                        <GroupByBox>
                                                            <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                                                        </GroupByBox>
                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                        <ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />
                                                    </DisplayLayout>
                                                </ig:UltraWebGrid>
                                            </td>
                                        </tr>
                                    </table>
                                    <!--  그리드  끝//-->
                                </td>
                                <td  align="left" valign="top">
                                    <!--  차트  시작//-->
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr valign="top">
                                            <td style="height:15px; font-size: 11px; padding-left: 10px;" valign="top">
                                                <img alt="" src="../images/icon/left_icon01.gif" style="vertical-align:middle;" /> 달성율분포
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td valign="top" align="center">
                                                <asp:Chart ID="chtFunnel" runat="server" BackColor="#D3DFF0" 
                                                    BorderLineColor="26, 59, 105" BorderLineStyle="Solid" BorderLineWidth="2" Height="210px"
                                                    Palette="None" Width="230px" ImageUrl="~/tempimages/ChartPic_#SEQ(300,3)">
                                                    <BorderSkin   SkinStyle="Emboss" />
                                                    <Series>
                                                        <asp:Series BorderColor="26, 59, 105" ChartType="Funnel" 
                                                            Name="Default" ShadowOffset="2" XValueType="Double" YValueType="Double" Font="Dotum, 9px" LabelPostBackValue="True">
                                                        </asp:Series>
                                                    </Series>
                                                   
                                                    <ChartAreas>
                                                        <asp:ChartArea BackColor="Transparent" BorderColor="Transparent" BorderDashStyle="Solid"
                                                            Name="Default">
                                                            <AxisX>
                                                                <MinorGrid LineColor="Silver" />
                                                                <MajorGrid LineColor="Silver" />
                                                            </AxisX>
                                                            <Area3DStyle Enable3D="True"  />
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
                                                        </asp:ChartArea>
                                                    </ChartAreas>
                                                    <Titles>
                                                        <asp:Title Name="Title1">
                                                        </asp:Title>
                                                    </Titles>
                                                    <Legends>
                                                        <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Bottom"
                                                            Enabled="False" LegendStyle="Table" Name="Default" ShadowOffset="2">
                                                        </asp:Legend>
                                                    </Legends>
                                                </asp:Chart>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <!--  차트  끝//-->
                                </td>
                            </tr>            
                        </table>
                        <!--    끝//-->             
                    </td>
                    <td style=" width:300px;height:100%;" align="left" valign="top">
                        <!--  당월/누계 구분 차트  시작//-->
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height:100%;">
                            <tr>
                                <td style="height:15px; font-size: 11px; padding-top: 5px; padding-left: 5px;">
                                    <img alt="" src="../images/icon/left_icon01.gif" style="vertical-align:middle;" /> 주요지표현황
                                </td>
                            </tr>
                            <tr>
                                <td  style=" width:100%; height: 96px;" align="left" valign="top">
                                    <asp:Chart ID="chtKPI1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="170px" Height="100px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisY>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisX2>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle Font="Tahoma, 10px" />
                                                    <MajorGrid LineColor="196, 196, 196" />
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter" Font="Dotum, 8.25pt" Name="Title1">
                                            </asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default"
                                                ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                        
                                        <Series>
                                            <asp:Series Name="Default" XValueType="Double" YValueType="Double">
                                            </asp:Series>
                                        </Series>
                                    </asp:Chart>
                                </td>
                            </tr>
                            <tr>
                                <td  style=" width:100%; height: 96px;" align="left" valign="top">                 
                                    <asp:Chart ID="chtKPI2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="170px" Height="100px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX2>
                                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td >
                            </tr>
                            <tr>
                                <td  style=" width:100%; height: 100px;" align="left" valign="top">
                                    <asp:Chart ID="chtKPI3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="180px" Height="100px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX2>
                                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter" Font="Dotum, 11px" Name="Title1"></asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td>
                            </tr>
                            <tr>
                                <td  style=" width:100%; height: 100px;" align="left" valign="top">
                                    <asp:Chart ID="chtKPI4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="180px" Height="100px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX2>
                                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></asp:Title>
                                        </Titles>                                        
                                    </asp:Chart>
                                </td>
                            </tr>
                            <tr>
                                <td  style=" width:100%; " align="left" valign="top">
                                    <asp:Chart ID="chtKPI5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="180px" Height="5px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX2>
                                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </td >
                            </tr>
                            <tr>
                                <td  style=" width:100%;" align="left" valign="top">
                                    <asp:Chart ID="chtKPI6" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="180px" Height="5px" >
                                        <ChartAreas>
                                            <asp:ChartArea Name="AreaView" BorderColor="196, 196, 196"
                                                 BackColor="White" ShadowColor="Transparent">
                                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX>
                                                <AxisX2 linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisX2>
                                                <Area3DStyle  WallWidth="2" Enable3D="True"/>
                                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY>
                                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                                </AxisY2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Name="Default" ShadowOffset="2">
                                            </asp:Legend>
                                        </Legends>
                                        <Titles >
                                            <asp:Title Alignment="TopCenter"  Font="Dotum, 11px" Name="Title1"></asp:Title>
                                        </Titles>
                                    </asp:Chart>
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
