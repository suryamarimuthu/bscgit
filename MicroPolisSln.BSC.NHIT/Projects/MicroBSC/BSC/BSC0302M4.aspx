<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0302M4.aspx.cs" Inherits="BSC_BSC0302M4" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC::성과관리 시스템::KPI 템플릿상속</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
        var param1 = false;
        function selectChkBox(chkChild) {
            var _elements = document.forms[0].elements;

            for (var i = 0; i < _elements.length; i++) {
                if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                    if (param1) {
                        _elements[i].checked = false;
                    }
                    else {
                        _elements[i].checked = true;
                    }
                }
            }

            param1 = (param1 == true) ? false : true;
        }
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                        <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" Text="조직KPI 풀" CssClass="cssPopTitleTxt"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="width: 220px; height: 40px; background-image: url(../images/title/popup_img.gif);
                            vertical-align: middle;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
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
        <tr class="cssPopContent">
            <td valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 500px;">
                    <tr>
                        <td>
                            <ig:UltraWebGrid ID="ugrdStgList" runat="server" Width="100%" Height="100%" Style="top: 1px">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="25px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                                                </CellTemplate>
                                                <HeaderTemplate>
                                                    <input type="checkbox" id="ck1" onclick="selectChkBox('ugrdStgList');" />
                                                </HeaderTemplate>
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="VIEW_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="VIEW_NAME" Key="VIEW_NAME" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="관점">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STG_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="전략" Key="STG_NAME" Width="210px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="전략">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="KPI" Key="KPI_NAME" Width="300px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" Width="250px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI_POOL_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="VIEW_REF_ID" Key="VIEW_REF_ID" Width="250px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="VIEW_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STG_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="STG_REF_ID" Key="STG_REF_ID" Width="250px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="STG_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                    AllowSortingDefault="No" BorderCollapseDefault="Separate" AutoGenerateColumns="False"
                                    HeaderClickActionDefault="NotSet" Name="ugrdStgList" RowHeightDefault="20px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Single" Version="4.00" CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed" StationaryMargins="HeaderAndFooter" OptimizeCSSClassNamesOutput="False"
                                    ReadOnly="LevelTwo" ScrollBar="Auto" ViewType="Flat">
                                    <GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
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
                                    <ClientSideEvents DblClickHandler="DblClickHandler" />
                                    <Images>
                                        <CurrentRowImage Url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage Url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPopBtnLine">
                            <asp:ImageButton ID="iBtnInsert" runat="server" Height="19px" ImageUrl="../images/btn/b_001.gif"
                                OnClick="iBtnInsert_Click" />
                            <asp:ImageButton ID="iBtnClose" runat="server" Height="19px" ImageUrl="../images/btn/b_003.gif"
                                OnClick="iBtnClose_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
