<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0604S1.aspx.cs" Inherits="BSC_BSC0604S1" %>

<!--DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
        function KpiDrillDown() {
            var wo = window.open('../usr/usr_excel_pivot_full_screen.aspx', 'WinPop', 'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=yes,resizable=0,top=0,left=0,width=screen.width, height=screen.height');
            wo.resizeTo(screen.width, screen.height);
        }
    </script>

</head>
<body style="margin-bottom: 0px; margin-left: 0px; margin-right: 0px; margin-top: 0px;">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
        <tr>
            <td valign="top" style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" Text="Interface Data" CssClass="cssPopTitleTxt"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td style="height: 25px;">
                            <table border="0" width="100%" cellpadding="0" cellspacing="0" style="height: 100%"
                                class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle">
                                        지표코드
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKpiCode" runat="server" Width="100%"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        지표명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKpiName" runat="server" Width="100%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        실적방식
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblResultInputType" runat="server" Width="100%"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        단위
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblUnitName" runat="server" Width="100%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 180px;">
                            <table border="0" width="100%" cellpadding="0" cellspacing="1" style="height: 100%"
                                class="tableBorder">
                                <tr>
                                    <td style="width: 50%; height: 20px; margin-left: 10px;">
                                        <img src="../images/icon/title_ic01.gif" alt="" style="vertical-align: middle;" />당월
                                    </td>
                                    <td style="width: 50%; height: 20px; margin-left: 10px;">
                                        <img src="../images/icon/title_ic02.gif" alt="" style="vertical-align: middle;" />누적
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%; text-align: center;">
                                        <DCWC:Chart ID="chartMs" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                            Palette="Dundas" Width="200px" Height="160px">
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196" BackGradientEndColor="White"
                                                    BackColor="White" ShadowColor="Transparent">
                                                    <AxisX LineColor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                        <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                                                    <AxisY LineColor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                                                    </AxisY>
                                                    <AxisY2 LineColor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                                                    </AxisY2>
                                                </DCWC:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                    LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                </DCWC:Legend>
                                            </Legends>
                                        </DCWC:Chart>
                                    </td>
                                    <td style="width: 50%; text-align: center;">
                                        <DCWC:Chart ID="chartTs" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                            Palette="Dundas" Width="200px" Height="160px">
                                            <ChartAreas>
                                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196" BackGradientEndColor="White"
                                                    BackColor="White" ShadowColor="Transparent">
                                                    <AxisX LineColor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                                        <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                                                    </AxisX>
                                                    <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" />
                                                    <AxisY LineColor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                                                    </AxisY>
                                                    <AxisY2 LineColor="196, 196, 196" LabelsAutoFit="False">
                                                        <LabelStyle Font="Tahoma, 10px"></LabelStyle>
                                                        <MajorGrid LineColor="196, 196, 196"></MajorGrid>
                                                    </AxisY2>
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
                    <tr class="cssPopTblBottomSpace">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <table border="0" width="100%" cellpadding="0" cellspacing="0" style="height: 100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                            <tr>
                                                <td style="width: 15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTitle1" runat="server" Style="font-weight: bold" Text="Interface Data" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="height: 100%;">
                                    <td>
                                        <ig:UltraWebGrid ID="ugrdInterface" runat="server" Visible="true" Width="100%" Height="100%"
                                            OnInitializeLayout="ugrdInterface_InitializeLayout">
                                            <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                                                BorderCollapseDefault="Separate" AllowColSizingDefault="Free" Name="ugrdInterface"
                                                TableLayout="Fixed" CellClickActionDefault="CellSelect" AutoGenerateColumns="false"
                                                StationaryMargins="Header" UseFixedHeaders="false">
                                                <%--<AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver"
                                                    View="Compact">
                                                    <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                                        </BorderDetails>
                                                    </BoxStyle>
                                                    <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset"
                                                        BackColor="Gray">
                                                    </ButtonStyle>
                                                </AddNewBox>
                                                <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                                    BorderStyle="Solid" HorizontalAlign="Center" ForeColor="White" BackColor="#94BAC9">
                                                    <Padding Left="0px" Right="0px"></Padding>
                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                                    </BorderDetails>
                                                </HeaderStyleDefault>
                                                <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset"
                                                    BackColor="DarkGray">
                                                </GroupByRowStyleDefault>
                                                <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White">
                                                </RowSelectorStyleDefault>
                                                <FrameStyle Width="99%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                                    BorderStyle="Solid" BackColor="#FAFCF1" Height="97%">
                                                </FrameStyle>
                                                <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                                    </BorderDetails>
                                                </FooterStyleDefault>
                                                <ActivationObject BorderColor="170, 184, 131" BorderWidth="">
                                                </ActivationObject>
                                                <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                                                    <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                                                    </BoxStyle>
                                                    <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset"
                                                        BackColor="Gray">
                                                    </BandLabelStyle>
                                                </GroupByBox>
                                                <RowExpAreaStyleDefault BackColor="WhiteSmoke">
                                                </RowExpAreaStyleDefault>
                                                <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif"
                                                    BorderStyle="None" HorizontalAlign="Left">
                                                </EditCellStyleDefault>
                                                <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98">
                                                </SelectedRowStyleDefault>
                                                <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset"
                                                    ForeColor="White" BackColor="#CF5F5B">
                                                </SelectedGroupByRowStyleDefault>
                                                <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif"
                                                    BorderColor="#AAB883" BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333"
                                                    BackColor="White">
                                                    <Padding Left="3px" Right="3px"></Padding>
                                                    <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                                                </RowStyleDefault>
                                                <ClientSideEvents />--%>
                                                <Images>
                                                    <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                                    <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                                    <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                                    <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                                                </Images>
                                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                            </DisplayLayout>
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                </ig:UltraGridBand>
                                            </Bands>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnDrillDown" ImageUrl="../images/btn/b_126.gif" runat="server"
                                OnClientClick="KpiDrillDown(); return false;" />
                            <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server"
                                OnClientClick="self.close(); return false;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </form>
</body>
</html>
