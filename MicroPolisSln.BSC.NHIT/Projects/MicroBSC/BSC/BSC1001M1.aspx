<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001M1.aspx.cs" Inherits="BSC_BSC1001M1" %>

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
            if (doChecking('ugrdDeptKpi')) {

                return confirm("저장 하시겠습니까?");
            }

            return false;

        }


        function doLinking_Dept(estterm_ref_id, kpiID, ICCB1) {


            var url = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
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
                            <asp:Label ID="lblPopUpTitle" runat="server" Text="조직 KPI" CssClass="cssPopTitleTxt"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="width: 140px; height: 40px; background-image: url(../images/title/popup_img.gif);
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
                    <tr style="height: 100%;">
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%;" border="0">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%;
                                            height: 100%;">
                                            <tr>
                                                <td class="cssTblTitle">
                                                    운영조직
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:DropDownList ID="ddlComDeptLeft" class="box01" Width="100%" runat="server" />
                                                </td>
                                                <td class="cssTblTitle">
                                                    담당자명
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox ID="txtChampionNameLeft" runat="server" Width="100%" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    KPI 코드
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox ID="txtKpiCodeLeft" runat="server" Width="100%" />
                                                </td>
                                                <td class="cssTblTitle">
                                                    KPI명
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox ID="txtKpiNameLeft" runat="server" Width="100%" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssPopBtnLine">
                                        <asp:ImageButton ID="ibtnSearchLeft" OnClick="ibtnSearchLeft_Click" runat="server"
                                            ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr style="height: 100%;">
                                    <td>
                                        <ig:UltraWebGrid ID="ugrdDeptKpi" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDeptKpi_InitializeRow"
                                            OnInitializeLayout="ugrdDeptKpi_InitializeLayout">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:TemplatedColumn Key="selchk" Width="5%">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cBox_header" Style="cursor: pointer" runat="server" onclick="selectChkBox(this,'ugrdDeptKpi');" />
                                                                <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox(this,'ugrdDeptKpi');" />--%>
                                                            </HeaderTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="10%">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="코드">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="40%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="KPI 명">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="OP_DEPT_NAME" Width="20%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="운영조직">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="17%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="담당자">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APP_STATUS" Key="APP_STATUS_NAME" Width="8%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="결재">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32"
                                                            Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32"
                                                            Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" DataType="System.Int32"
                                                            Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
                                                AllowDeleteDefault="No" AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet" Name="ugrdDeptKpi" RowHeightDefault="20px"
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
                                    <td style="margin-left: 5px; padding-right: 5px;" align="right">
                                        <table cellpadding="0" cellspacing="0" style="height: 100%; width: 100%;" border="0">
                                            <tr>
                                                <td style="margin-left: 5px; vertical-align: middle;" align="right">
                                                </td>
                                                <td style="margin-left: 5px; vertical-align: middle;" align="right">
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
    <asp:DropDownList ID="ddlUnit_Hdf" runat="server" Visible="false">
    </asp:DropDownList>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
