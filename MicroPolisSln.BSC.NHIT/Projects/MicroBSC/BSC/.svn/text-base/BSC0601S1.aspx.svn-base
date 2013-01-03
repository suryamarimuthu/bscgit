<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0601S1.aspx.cs" Inherits="BSC_BSC0601S1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin-bottom: 0px; margin-left: 0px; margin-right: 0px; margin-top: 0px;">
    <form id="form1" runat="server">
    <div>
        <!--- MAIN START --->
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
            <tr>
                <td valign="top" style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                                class="cssPopTitleArea">
                                <asp:Label ID="lblPopUpTitle" runat="server" Text="컬럼미리보기" CssClass="cssPopTitleTxt"></asp:Label>
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
                                <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%" class="tableBorder">
                                    <tr>
                                        <td class="cssTblTitle">
                                            CODE
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:Label ID="lblDICODE" runat="server" Width="100%"></asp:Label>
                                        </td>
                                        <td class="cssTblTitle">
                                            NAME
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:Label ID="lblDINAME" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle">
                                            사용여부
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:Label runat="server" ID="lblUseYN" Width="100%"></asp:Label>
                                        </td>
                                        <td class="cssTblTitle">
                                            정의
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:Panel ID="pnlDefinition" runat="server" Width="99%" Height="99%" ScrollBars="Auto">
                                                <asp:Label runat="server" ID="lblDEFINITION" Width="100%" Height="100%"></asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="cssPopTblBottomSpace">
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 100%;">
                            <td>
                                <ig:UltraWebGrid ID="ugrdPreview" runat="server" Visible="false" Width="100%" Height="100%"
                                    OnInitializeLayout="ugrdPreview_InitializeLayout">
                                    <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                                        BorderCollapseDefault="Separate" AllowColSizingDefault="Free" Name="ugrdPreview"
                                        TableLayout="Fixed" CellClickActionDefault="CellSelect" StationaryMargins="Header"
                                        UseFixedHeaders="false" OptimizeCSSClassNamesOutput="False">
                                        <%--<AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver"
                                            View="Compact">
                                            <style borderwidth="1px" borderstyle="Solid" backcolor="LightGray">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" />
                                            </style>
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
                                            <style borderwidth="1px" bordercolor="White" borderstyle="Outset" backcolor="DarkGray">
                                                </style>
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
                                        <Images>
                                            <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                            <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                            <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                            <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                                        </Images>
                                        <ClientSideEvents DblClickHandler="AfterSelectChangeHandler" />
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
                                <asp:ImageButton ID="iBtnClose" ImageUrl="~/images/btn/b_003.gif" runat="server"
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
    </div>
    </form>
</body>
</html>
