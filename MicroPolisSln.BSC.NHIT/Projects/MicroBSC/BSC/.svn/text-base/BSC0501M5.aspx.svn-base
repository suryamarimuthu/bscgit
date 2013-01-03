<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501M5.aspx.cs"
    Inherits="BSC_BSC0501M5" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템::결재일괄승인</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script id="Infragistics" type="text/javascript">
        function ugrdKpiList_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var appID = row.getCellFromKey("APP_REF_ID").getValue();
            var verNO = row.getCellFromKey("VERSION_NO").getValue();
            var linST = row.getCellFromKey("LINE_STEP").getValue();
            var biz_type = row.getCellFromKey("BIZ_TYPE").getValue();
            var draftStatus = "<%= Biz_Type.app_draft_approval %>";
            var app_ccb = "<%= this.ICCB1 %>";

            var draft_emp_id = parseInt("<%= this.IDraftEmpID %>", 0);

            if (draft_emp_id == "NaN" || draft_emp_id < 1) {
                alert("기안자 정보를 알수 없습니다.");
                return false;
            }

            var strURL = "BSC0901M1.aspx?DRAFT_STATUS=" + draftStatus + "&APP_REF_ID=" + appID + "&VERSION_NO=" + verNO + "&LINE_STEP=" + linST + "&APP_CCB=" + app_ccb + "&DRAFT_EMP_ID=" + draft_emp_id + "&BIZ_TYPE=" + biz_type;

            gfOpenWindow(strURL, 900, 650, 'no', 'no', "BSC0901M1");

        }

        function onDraft() {

            return confirm('일괄승인하시겠습니까?');
        }
    </script>

    <script src="../_common/js/iezn_embed_patch.js" type="text/javascript"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                        <td>
                            <img alt="" src="../images/title/popup_t11.gif" />
                        </td>
                        <td align="right" valign="top">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                        <asp:HiddenField ID="hdnEstTermID" runat="server" />
                        <asp:HiddenField ID="hdnKpiId" runat="server" />
                        <asp:HiddenField ID="hdnYMD" runat="server" />
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
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td>
                            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-top: 5px;">
                                        <img src="../images/icon/subtitle.gif" alt="" />&nbsp;일괄승인 대상목록
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <ig:UltraWebGrid ID="ugrdDraft" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDraft_InitializeRow"
                                OnInitializeLayout="ugrdDraft_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_NAME" Key="BIZ_TYPE_NAME" Width="70px">
                                                <Header Caption="업무구분">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText="" Format=""
                                                HeaderText="KPI 코드" Key="KPI_CODE" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="KPI 코드">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" HeaderText="운영조직" Key="OP_DEPT_NAME"
                                                Width="150px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="운영조직">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="KPI 명" Key="KPI_NAME" Width="240px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="담당자" Key="CHAMPION_EMP_NAME"
                                                Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="담당자">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME"
                                                Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="지표유형">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="단위">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID="" FooterText=""
                                                Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="실적방식">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="RESULT_MS" HeaderText="당월실적" Key="RESULT_MS"
                                                Format="##,###,##0.####" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="당월실적">
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="RESULT_TS" HeaderText="누적실적" Key="RESULT_TS"
                                                Format="##,###,##0.####" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="누적실적">
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="SIGNAL_MS" HeaderText="당" Key="SIGNAL_MS" Width="30px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="시그널">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="SIGNAL_TS" HeaderText="누" Key="SIGNAL_TS" Width="30px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="시그널">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" Hidden="true" Key="YMD">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BIZ_TYPE" Hidden="true" Key="BIZ_TYPE">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="APP_REF_ID" Hidden="true" Key="APP_REF_ID">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="VERSION_NO" Hidden="true" Key="VERSION_NO">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LINE_STEP" Hidden="true" Key="LINE_STEP">
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
                                    AllowDeleteDefault="No" AllowSortingDefault="No" BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" Name="ugrdDraft" RowHeightDefault="20px" HeaderStyleDefault-Height="22px"
                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat"
                                    CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                                    AutoGenerateColumns="False">
                                    <GroupByBox>
                                        <BoxStyle BackColor="whitesmoke" BorderColor="Window">
                                        </BoxStyle>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left"
                                        BorderColor="#E5E5E5" ForeColor="White">
                                        <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                            </BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                            </BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <ClientSideEvents DblClickHandler="ugrdKpiList_DblClickHandler" />
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                            <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
                            <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lBtnReload2" runat="server" OnClick="lBtnReload2_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <th class="tableTitle" id="th1" runat="server" style="width: 80px; text-align: center;
                                        font-weight: bold;">
                                        결재의견
                                    </th>
                                    <td style="padding-right: 5px;">
                                        <asp:TextBox ID="txtAppOpinion" runat="server" Text="" TextMode="MultiLine" Width="100%"
                                            Height="80px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-right: 5px; padding-top: 3px;">
                                        <asp:ImageButton ID="ibtnDraft" runat="server" ImageUrl="../images/btn/b_022.gif"
                                            ImageAlign="AbsMiddle" OnClientClick="return onDraft();" OnClick="ibtnDraft_Click">
                                        </asp:ImageButton>
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
    </form>
</body>
</html>
