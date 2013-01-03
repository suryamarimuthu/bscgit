<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001M3.aspx.cs" Inherits="BSC_BSC1001M3" %>

<!--DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script id="Infragistics" type="text/javascript">
        function OpenPreviewWindow() {

            var strURL = 'BSC0601S1.aspx?iType=P&DICODE=' + Dicode + '&CCB1=' + ICCB1;

            gfOpenWindow(strURL, 800, 600, 'BSC0601S1');

            return false;
        }

        function doSaving() {
            if (doChecking('UltraWebGrid1')) {

                return confirm("저장 하시겠습니까?");
            }

            return false;

        }

        function doLinking_Pool(kpiID) {

            var ICCB1 = "<%= this.ICCB1 %>";

            //var strURL = 'BSC0301M1.aspx?iType=X&KPI_POOL_REF_ID=' + kpiID;
            //gfOpenWindow(strURL, 720, 670, "doLinking_Pool");

        }

        function OpenInsertWindow() {
            var kpiID = '';
            var strURL = 'BSC0301M1.aspx?iType=A&KPI_POOL_REF_ID=' + kpiID;
            gfOpenWindow(strURL, 720, 670, 'BSC0301M1');
        }
    </script>

</head>
<body style="margin-bottom: 0px; margin-left: 0px; margin-right: 0px; margin-top: 0px;">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%;" border="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                        <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" Text="개인KPI 풀" CssClass="cssPopTitleTxt"></asp:Label>
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
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="cssTblTitleSingle">
                                        KPI 명
                                    </td>
                                    <td class="cssTblContentSingle">
                                        <asp:TextBox ID="txtKpiName" runat="server" Width="99%" BorderWidth="0"></asp:TextBox>
                                        <asp:HiddenField ID="hdfTargetReasonFile" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfKpiPoolRefID" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfinitial_version_yn" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfkpi_target_version_id" runat="server" Value="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" ImageUrl="../images/btn/b_033.gif"
                                OnClick="iBtnSearch_Click" />
                            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                                OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" Style="cursor: pointer" runat="server" onclick="selectChkBox(this,'UltraWebGrid1');" />
                                                    <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox(this,'ugrdDeptKpi');" />--%>
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" Width="100px" Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI_POOL_REF_ID">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="250px">
                                                <Header Caption="KPI 명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle Cursor="Default">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_EXTERNAL_TYPE_NAME" Key="KPI_EXTERNAL_TYPE_NAME"
                                                Width="100px" Hidden="true">
                                                <Header Caption="KPI 구분">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="100px"
                                                Hidden="true">
                                                <Header Caption="KPI 유형">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="TOP_CATEGORY_NAME" Key="TOP_CATEGORY_NAME" Width="100px"
                                                Hidden="true">
                                                <Header Caption="대분류">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="MID_CATEGORY_NAME" Key="MID_CATEGORY_NAME" Width="100px"
                                                Hidden="true">
                                                <Header Caption="중분류">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_CATEGORY_NAME" Key="LOW_CATEGORY_NAME" Width="100px"
                                                Hidden="true">
                                                <Header Caption="소분류">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px"
                                                FooterText="" HeaderText="사용여부" Hidden="true">
                                                <Header Caption="사용여부">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <CellTemplate>
                                                    <asp:Image runat="server" ID="imgUseYn" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                                    </asp:Image>
                                                </CellTemplate>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_DESC" HeaderText="KPI 설명" Key="KPI_DESC"
                                                Width="400px">
                                                <Header Caption="KPI 설명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle Cursor="Default">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" DataType="System.Int32"
                                                Hidden="true">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32"
                                                Hidden="true">
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
                                    AllowDeleteDefault="No" AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" Name="UltraWebGrid2" RowHeightDefault="20px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed" StationaryMargins="Header" OptimizeCSSClassNamesOutput="False"
                                    ReadOnly="LevelTwo" AutoGenerateColumns="False">
                                    <GroupByBox>
                                        <BoxStyle CssClass="GridGroupBoxStyle">
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
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                    </FrameStyle>
                                    <%--<ClientSideEvents DblClickHandler="ugrdDeptKpi_DblClickHandler" />--%>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img alt="" src="../images/btn/b_005.gif" style="cursor: hand;" onclick="OpenInsertWindow();" />
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="iBtnSave" ImageUrl="~/images/btn/b_tp07.gif" runat="server"
                                            OnClick="iBtnSave_Click" OnClientClick="return doSaving();" AlternateText="저장" />
                                        <%--<asp:ImageButton ID="iBtnClose" ImageUrl="~/images/btn/b_003.gif" runat="server" OnClick="iBtnClose_Click" AlternateText="닫기" />--%>
                                        <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/btn/b_003.gif" runat="server"
                                            OnClientClick="window.close();" AlternateText="닫기" />
                                    </td>
                                </tr>
                            </table>
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
    </form>
</body>
</html>
