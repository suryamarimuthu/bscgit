<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501M4.aspx.cs"
    Inherits="BSC_BSC0501M4" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템::실적 결재일괄요청</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script id="Infragistics" type="text/javascript">
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
        function ugrdKpiList_DblClickHandler(gridName, cellId) {
            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var strMM = row.getCellFromKey("YMD").getValue();
            var intEST = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB1 = "<%= this.ICCB1 %>";

            var isteamkpi = '<%= IIS_TEAM_KPI %>';
            if (isteamkpi == 'Y') {
                var url = 'BSC0501M1.aspx?KPI_REF_ID=' + kpiID + '&YMD=' + strMM + '&ESTTERM_REF_ID=' + intEST + '&CCB1=' + ICCB1;
                /* 2011-08-17 수정 : KPI의 ID가 다른 경우 새로운 창이 열리도록 수정
                gfOpenWindow(url
                ,870
                ,690
                ,'no'
                ,'no'
                ,'Win5'); */
                gfOpenWindow(url
                    , 870
                    , 640
                    , 'no'
                    , 'no'
                    , 'BSC0501M1' + kpiID);
            }
            else {
                var row = igtbl_getRowById(cellId);
                var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
                var strMM = row.getCellFromKey("YMD").getValue();
                var intEST = row.getCellFromKey("ESTTERM_REF_ID").getValue();
                var ICCB1 = "<%= this.ICCB1 %>";

                var url = 'BSC0501M3.aspx?KPI_REF_ID=' + kpiID + '&YMD=' + strMM + '&ESTTERM_REF_ID=' + intEST + '&CCB1=' + ICCB1;

                gfOpenWindow(url
                    , 870
                    , 690
                    , 'no'
                    , 'no'
                    , 'BSC0501M3');
            }
        }

        function onDraft() {

            var kpi_ref_id = "";
            var ugrd = igtbl_getGridById('ugrdDraft');
            for (var i = 0; i < ugrd.Rows.length; i++) {
                var tRow = ugrd.Rows.getRow(i);
                var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                if (chkYN.checked) {
                    kpi_ref_id += tRow.getCellFromKey("KPI_REF_ID").getValue() + ",";
                }
            }
            if (kpi_ref_id == "") {
                alert('일괄결재할 KPI를 선택하세요!');
                return false;
            }

            var e = document.getElementById('ddlDraftTerm');
            var estterm_ref_id = e.options[e.selectedIndex].value;
            var e2 = document.getElementById('ddlEstTermMonth');
            var ymd = e2.options[e2.selectedIndex].value;

            var biz_type;
            var isteamkpi = '<%= IIS_TEAM_KPI %>';
            if (isteamkpi == 'Y') {
                biz_type = "<%= Biz_Type.biz_type_kpi_rstbatch %>";
            }
            else {
                biz_type = "<%= Biz_Type.biz_type_target_resultbatch %>";
            }

            kpi_ref_id = kpi_ref_id.substring(0, kpi_ref_id.length - 1);
            var app_ccb = "<%= this.ICCB2 %>";
            var url = "BSC0901M3.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id + "&APP_CCB=" + app_ccb + "&BIZ_TYPE=" + biz_type + "&YMD=" + ymd;
            gfOpenWindow(url, 900, 680, 'BSC0901M3'); // 728

            return false;
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
                                    <td class="cssTblTitle">
                                        평가기간
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlDraftTerm" runat="server" class="box01" Width="60%" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlEstTermMonth" runat="server" class="box01" Width="35%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblTitle">
                                        지표유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlDraftKpiType" CssClass="box01" runat="server" Width="99%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        실적방식
                                    </td>
                                    <td class="cssTblContent" style="border-right: none;">
                                        <asp:DropDownList ID="ddlDraftResultType" CssClass="box01" runat="server" Width="99%"
                                            Visible="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblContent" style="width: 15%; border-left: none; border-right: none;">
                                        &nbsp;
                                    </td>
                                    <td class="cssTblContent">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="ibtnSearch" OnClick="ibtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif"
                                ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebGrid ID="ugrdDraft" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDraft_InitializeRow"
                                OnInitializeLayout="ugrdDraft_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed">
                                                <HeaderTemplate>
                                                    <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor: hand; vertical-align: middle;"
                                                        onclick="selectChkBox('ugrdDraft')" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText="" Format=""
                                                HeaderText="KPI 코드" Key="KPI_CODE" Width="75px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="KPI 코드">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText="" Format=""
                                                HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI 담당자" Key="CHAMPION_EMP_NAME"
                                                Width="170px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI담당자">
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
                                                Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="실적방식">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn HeaderText="평가대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="70px">
                                                <Header Caption="평가대상">
                                                </Header>
                                                <HeaderStyle Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn HeaderText="실적입력" Key="CHECKSTATUS" BaseColumnName="CHECKSTATUS"
                                                Width="70px">
                                                <Header Caption="실적입력">
                                                </Header>
                                                <HeaderStyle Wrap="true" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID=""
                                                Width="60px" FooterText="" HeaderText="APP_STATUS">
                                                <Header Caption="결재상태">
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <CellTemplate>
                                                    <asp:Image runat="server" ID="imgApp" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                                    </asp:Image>
                                                </CellTemplate>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="YMD" Hidden="true" Key="YMD">
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
                                    <%--<GroupByBox>
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
                                    </SelectedRowStyleDefault>--%>
                                    <ClientSideEvents DblClickHandler="ugrdKpiList_DblClickHandler" />
                                    
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                            <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
                            <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lBtnReload2" runat="server" OnClick="lBtnReload2_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="ibtnDraft" runat="server" ImageUrl="../images/btn/b_021.gif"
                                ImageAlign="AbsMiddle" OnClientClick="return onDraft();"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                        <td style="width:50%; background-color:#FFFFFF"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
