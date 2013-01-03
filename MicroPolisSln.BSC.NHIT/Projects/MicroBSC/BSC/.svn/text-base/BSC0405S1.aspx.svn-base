<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0405S1.aspx.cs" Inherits="BSC_BSC0405S1" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html; " />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript" language="javascript">  
    <!--
        function mfClose() {
            gfCloseWindow();
        }

    //-->  
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <div>
        <!--- MAIN START --->
        <table width="100%" style="height: 100%;" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <!-- Title -->
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="40" valign="top">
                                            <img src="../images/title/tp_i007.gif">
                                        </td>
                                        <td align="right" valign="top">
                                            <img src="../images/title/popup_img.gif">
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" height="4" bgcolor="#FFFFFF">
                                        </td>
                                        <td width="50%" bgcolor="#FFFFFF">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!-- Title -->
                </td>
            </tr>
            <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                        <tr style="height: 100%;">
                            <td>
                                <table style="width: 100%; height: 100%;" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="tableContent" style="padding-left: 0;">
                                            <ig:UltraWebGrid ID="ugrdBadKPIInfo" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdBadKPIInfo_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="SIGNAL" MergeCells="true" Width="50px" HeaderText="상태"
                                                                Key="SIGNAL">
                                                                <CellStyle HorizontalAlign="Center" />
                                                                <Header Caption="상태">
                                                                    <RowLayoutColumnInfo OriginX="0" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="0" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="VIEW_NAME" Width="80px" HeaderText="관점명" Key="VIEW_NAME">
                                                                <CellStyle HorizontalAlign="Center" />
                                                                <Header Caption="관점명">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="STG_NAME" Width="220px" HeaderText="전략명" Key="STG_NAME">
                                                                <CellStyle HorizontalAlign="left" />
                                                                <Header Caption="전략명">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Width="300px" HeaderText="KPI명" Key="KPI_NAME">
                                                                <CellStyle HorizontalAlign="left" />
                                                                <Header Caption="KPI명">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="IMAGE_FILE_NAME" Hidden="True" Key="IMAGE_FILE_NAME"
                                                                Width="60px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                        </Columns>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer"
                                                    AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat"
                                                    CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                                                    ReadOnly="LevelTwo" OptimizeCSSClassNamesOutput="False" AutoGenerateColumns="False">
                                                    <GroupByBox>
                                                        <BoxStyle BackColor="WhiteSmoke" BorderColor="Window">
                                                        </BoxStyle>
                                                    </GroupByBox>
                                                    <RowStyleDefault CssClass="GridRowStyle" />
                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                    </SelectedRowStyleDefault>
                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                    </RowAlternateStyleDefault>
                                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                    </HeaderStyleDefault>
                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                    </FrameStyle>
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td>
                                <img src="../images/btn/b_003.gif" id="hBtnClose" style="cursor: hand" onclick="mfClose()" />
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
    </div>
    </form>
</body>
</html>
