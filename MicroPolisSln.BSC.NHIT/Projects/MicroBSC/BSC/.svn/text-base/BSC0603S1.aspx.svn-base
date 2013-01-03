<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0603S1.aspx.cs" Inherits="BSC_BSC0603S1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

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
                            &nbsp;
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
                        <td>
                            <ig:UltraWebTab runat="server" ID="ugrdKpiResultTab" Height="100%" ThreeDEffect="False"
                                Width="100%" AutoPostBack="false">
                                <Tabs>
                                    <ig:Tab Text="지표기본정보" Key="1">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
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
                                                        당월산식
                                                    </td>
                                                    <td class="cssTblContent" colspan="3">
                                                        <asp:TextBox ID="txtCalcFormMs" runat="server" Width="99%" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        누계산식
                                                    </td>
                                                    <td class="cssTblContent" colspan="3">
                                                        <asp:TextBox ID="txtCalcFormTs" runat="server" Height="40px" TextMode="MultiLine"
                                                            Width="99%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                    <ig:TabSeparator>
                                        <Style Width="1px">
                                            </Style>
                                    </ig:TabSeparator>
                                    <ig:Tab Text="산식정보" Key="2">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" width="100%" cellpadding="0" cellspacing="0" style="height: 100%"
                                                class="tableBorder">
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        DICODE
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtDiCode" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td class="cssTblTitle">
                                                        DICODE명
                                                    </td>
                                                    <td class="cssTblContent">
                                                        <asp:TextBox ID="txtDiName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        당월산식
                                                    </td>
                                                    <td class="cssTblContent" colspan="3">
                                                        <asp:TextBox ID="txtFieldMs" runat="server" Width="99%" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">
                                                        누계산식
                                                    </td>
                                                    <td class="cssTblContent" colspan="3">
                                                        <asp:TextBox ID="txtFieldTs" runat="server" Height="40px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                </Tabs>
                                <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff">
                                </DefaultTabStyle>
                                <SelectedTabStyle CssClass="cssTabStyleOn">
                                </SelectedTabStyle>
                                <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb2.gif"
                                    SelectedImage="../images/tab/ig_tab_blueb1.gif" />
                            </ig:UltraWebTab>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
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
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle">
                                        당월실적
                                    </td>
                                    <td class="cssTblContent">
                                        <ig:WebNumericEdit ID="txtResult_Ms" runat="server" Width="97%" Nullable="False"
                                            ValueText="0.0000" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적"
                                            NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                            NullText="0" MinDecimalPlaces="Four">
                                        </ig:WebNumericEdit>
                                    </td>
                                    <td class="cssTblTitle">
                                        누적실적
                                    </td>
                                    <td class="cssTblContent">
                                        <ig:WebNumericEdit ID="txtResult_Ts" runat="server" Width="97%" Nullable="False"
                                            ValueText="0" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="누계실적"
                                            NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                            NullText="0" MinDecimalPlaces="Four">
                                        </ig:WebNumericEdit>
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
                                    StationaryMargins="Header" UseFixedHeaders="false" NoDataMessage=" " NullTextDefault=" ">
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
                                        <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                            BorderStyle="Solid" BackColor="#FAFCF1" Height="100%">
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
                                        </RowStyleDefault>--%>
                                    <ClientSideEvents DblClickHandler="AfterSelectChangeHandler" />
                                    <Images>
                                        <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                        <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                        <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                        <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                                    </Images>
                                    <RowStyleDefault CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                    </RowAlternateStyleDefault>
                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                    </HeaderStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                    </FrameStyle>
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
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnExcelExport" ImageUrl="../images/btn/b_i011.gif" runat="server"
                                OnClick="iBtnExcelExport_Click" />
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
    <!--- MAIN END --->
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </form>
</body>
</html>
