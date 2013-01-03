<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_General08.aspx.cs" EnableEventValidation="false"
    Inherits="Dashboard_NHIT_General08" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
    <style>
        .title
        {
            font-weight: bold;
            font-size: 15;
        }
        .unit
        {
            text-align: right;
        }
        .cssTblTitle
        {
            text-align: center;
            width: auto;
            font-size: 13px;
        }
        .cssTblContent
        {
            text-align: right;
            padding-right: 10px;
            width: auto;
            font-size: 13px;
        }
    </style>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="title">
                □ 매출 및 손익 현황
            </td>
        </tr>
        <tr>
            <td class="unit">
                (단위: 백만원)
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
                    <tr>
                        <td rowspan="2" class="cssTblTitle" style="width: 16%;">
                            구분
                        </td>
                        <td colspan="2" class="cssTblTitle">
                            2012년 목표
                        </td>
                        <td colspan="2" class="cssTblTitle">
                            계획대비
                        </td>
                        <td colspan="2" class="cssTblTitle">
                            전년대비
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle" style="width: 14%;">
                            연간
                        </td>
                        <td class="cssTblTitle" style="width: 14%;">
                            8월 목표(A)
                        </td>
                        <td class="cssTblTitle" style="width: 14%;">
                            8월 실적(A)
                        </td>
                        <td class="cssTblTitle" style="width: 14%;">
                            달성률(B/A)
                        </td>
                        <td class="cssTblTitle" style="width: 14%;">
                            실적(C)
                        </td>
                        <td class="cssTblTitle" style="width: 14%;">
                            성장률(B/C-1)
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            매출액
                        </td>
                        <td class="cssTblContent">
                            142,025
                        </td>
                        <td class="cssTblContent">
                            94,064
                        </td>
                        <td class="cssTblContent">
                            100,348
                        </td>
                        <td class="cssTblContent">
                            107%
                        </td>
                        <td class="cssTblContent">
                            58,332
                        </td>
                        <td class="cssTblContent">
                            72%
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            매출원가
                        </td>
                        <td class="cssTblContent">
                            129,195
                        </td>
                        <td class="cssTblContent">
                            85,909
                        </td>
                        <td class="cssTblContent">
                            90,601
                        </td>
                        <td class="cssTblContent">
                            105%
                        </td>
                        <td class="cssTblContent">
                            52,307
                        </td>
                        <td class="cssTblContent">
                            73%
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            매출총이익
                        </td>
                        <td class="cssTblContent">
                            12,830
                        </td>
                        <td class="cssTblContent">
                            8,154
                        </td>
                        <td class="cssTblContent">
                            9,746
                        </td>
                        <td class="cssTblContent">
                            116%
                        </td>
                        <td class="cssTblContent">
                            6,025
                        </td>
                        <td class="cssTblContent">
                            62%
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            판매관리비
                        </td>
                        <td class="cssTblContent">
                            5,152
                        </td>
                        <td class="cssTblContent">
                            3,531
                        </td>
                        <td class="cssTblContent">
                            3,272
                        </td>
                        <td class="cssTblContent">
                            93%
                        </td>
                        <td class="cssTblContent">
                            2,506
                        </td>
                        <td class="cssTblContent">
                            31%
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            영업이익
                        </td>
                        <td class="cssTblContent">
                            7,678
                        </td>
                        <td class="cssTblContent">
                            4,623
                        </td>
                        <td class="cssTblContent">
                            6,474
                        </td>
                        <td class="cssTblContent">
                            140%
                        </td>
                        <td class="cssTblContent">
                            3,519
                        </td>
                        <td class="cssTblContent">
                            84%
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            당기순이익
                        </td>
                        <td class="cssTblContent">
                            6,056
                        </td>
                        <td class="cssTblContent">
                            3,672
                        </td>
                        <td class="cssTblContent">
                            5,227
                        </td>
                        <td class="cssTblContent">
                            142%
                        </td>
                        <td class="cssTblContent">
                            2,860
                        </td>
                        <td class="cssTblContent">
                            83%
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="title">
                □ 분기별 현황
            </td>
        </tr>
        <tr>
            <td class="unit">
                (단위: 백만원)
            </td>
        </tr>
        <tr>
            <td>
                <DCWC:Chart ID="chart" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                    Palette="Dundas" Height="300px" Width="800px">
                    <ChartAreas>
                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196" BackGradientEndColor="White"
                            BackColor="White" ShadowColor="Transparent">
                            <AxisX LineColor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                            </AxisX>
                            <AxisY LineColor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                            </AxisY>
                            <AxisY2 LineColor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                            </AxisY2>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false" />
                        </DCWC:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Right"
                            LegendStyle="Column" Name="Default" ShadowOffset="0">
                        </DCWC:Legend>
                    </Legends>
                </DCWC:Chart>
            </td>
        </tr>
        <tr>
            <td>
                * 3/4분기 목표는 8월 목표, 실적은 8월까지의 누적 실적임
            </td>
        </tr>
    </table>
</asp:Content>
