<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501M2.aspx.cs"
    Inherits="BSC_BSC0501M2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript" language="javascript">  
<!--

        var isChanged = false;
        var isWorking = 0;
        function MouseOverHandler(gridName, id, objectType) {
            if (objectType == 0) { // Are we over a cell
                var cell = igtbl_getElementById(id);
                var row = igtbl_getRowById(id);
                var band = igtbl_getBandById(id);
                var active = igtbl_getActiveRow(id);
                cell.style.cursor = 'hand';
            }
        }

        function ugrdResult_CellChangeHandler(gridName, cellId) {
            var oRow = igtbl_getRowById(cellId);
            var mBox;
            document.getElementById('lblYMD').innerHTML = oRow.getCellFromKey("YMD").getValue();
            for (i = 1; i < 13; i++) {
                tName = "0" + i.toString();
                if (tName.length == 3)
                    tName = tName.substr(1, 2);
                document.getElementById('cms' + tName).style.zIndex = "0";
                document.getElementById('cts' + tName).style.zIndex = "0";
                document.getElementById('mms' + tName).style.zIndex = "0";
                document.getElementById('mts' + tName).style.zIndex = "0";

            }
            tName = oRow.getCellFromKey("YMD").getValue().substr(5, 2);
            document.getElementById('cms' + tName).style.zIndex = "1";
            document.getElementById('cts' + tName).style.zIndex = "1";
            document.getElementById('mms' + tName).style.zIndex = "1";
            document.getElementById('mts' + tName).style.zIndex = "1";
        }

        function isChanging() {
            isChanged = true;
        }

        function ugrdResult_AfterCellUpdateHandler(gridName, cellId) {

            if (isWorking == 0) {
                isChanging();
                isWorking = 1;
                var oSum = 0;
                var oGrid = ougrdResult;
                var oRows = oGrid.Rows;
                if ("<%=this.IResultTsCalcType %>" == "SUM") {
                    for (i = 0; i < oRows.length; i++) {
                        var oRow = oRows.getRow(i);
                        if (oRow.getCellFromKey("CHECK_YN").getValue() == "Y" && oRow.getCellFromKey("OPEN_YN").getValue() == "Y") {
                            oSum += oRow.getCellFromKey("RESULT_MS").getValue();
                            oRow.getCellFromKey("RESULT_TS").setValue(oSum);
                        }
                    }
                }
                else if ("<%=this.IResultTsCalcType %>" == "AVG") {
                    k = 1;
                    for (i = 0; i < oRows.length; i++) {
                        var oRow = oRows.getRow(i);
                        if (oRow.getCellFromKey("CHECK_YN").getValue() == "Y" && oRow.getCellFromKey("OPEN_YN").getValue() == "Y") {
                            oSum += oRow.getCellFromKey("RESULT_MS").getValue();
                            oRow.getCellFromKey("RESULT_TS").setValue(oSum / k);
                            k++;
                        }
                    }
                }
                var oRow = igtbl_getRowById(cellId);
                oRow.getCellFromKey("CHECKSTATUS").setValue("Y");
                isWorking = 0;
            }
        }

        function getTsSumMsg() {
            if (!isChanged) {
                alert("변경된 데이터가 없습니다.");
                return false;
            }
            if ("<%=this.IResultTsCalcType %>" == "SUM" || "<%=this.IResultTsCalcType %>" == "AVG") {
                var msg = "수정 월은 해당월의 재 마감처리가 되어야 점수에 반영됩니다.\n변경된 실적을 저장하시겠습니까?";
                return confirm(msg);
            }
            else {
                var msg = "누적실적 계산방식이 단순합계나 단순평균이 아니므로 누적실적이 수기로 입력되어야 합니다.\n수정 월은 해당월의 재 마감처리가 되어야 점수에 반영됩니다.\n입력된 실적을 저장하시겠습니까?";
                return confirm(msg);
            }
        }
        
//-->  
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();"
    id="iBtnQtnList">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnEstTermID" runat="server" />
    <asp:HiddenField ID="hdnKpiId" runat="server" />
    <asp:HiddenField ID="hdnYMD" runat="server" />
    <asp:HiddenField ID="isChangedYN" runat="server" Value="NNNNNNNNNNNN" />
    <ig:WebNumericEdit ID="igtxtNum" runat="server" Nullable="false" NullText="0" MinDecimalPlaces="Three"
        DataMode="Double">
    </ig:WebNumericEdit>
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="height: 40px;" valign="top">
                                <img alt="" src="../images/title/popup_t12.gif" width="230" height="40" id="IMG1" />
                            </td>
                            <td align="right" valign="top">
                                <img alt="" src="../images/title/popup_img.gif" />
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
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="2" class="tableBorder" width="100%">
                                    <tr>
                                        <td class="tableTitle" align="center" style="height: 19px; width: 80px;">
                                            KPI 코드
                                        </td>
                                        <td class="tableContent" style="height: 19px; width: 80px;">
                                            <asp:Label ID="lblKPICode" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td class="tableTitle" align="center" style="height: 19px; width: 80px;">
                                            KPI 명
                                        </td>
                                        <td class="tableContent" style="height: 19px">
                                            <asp:Label ID="lblKPIName" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td class="tableTitle" align="center" style="height: 19px; width: 80px;">
                                            단위
                                        </td>
                                        <td class="tableContent" style="height: 19px;">
                                            &nbsp;<asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tableTitle" align="center" style="height: 19px; width: 80px;">
                                            측정유형
                                        </td>
                                        <td class="tableContent" style="height: 19px; width: 80px;">
                                            <asp:Label ID="lblRESULT_INPUT_TYPE" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" class="tableTitle" style="width: 80px; height: 19px; width: 80px;">
                                            누적실적유형
                                        </td>
                                        <td class="tableContent" style="height: 19px">
                                            <asp:Label ID="lblRESULT_TS_CALC_TYPE" runat="server"></asp:Label>
                                            <span style="color: #03C3FF;">(단순합산, 단순평균의 누계실적은 자동계산)</span>
                                        </td>
                                        <td class="tableTitle" align="center" style="height: 19px; width: 80px;">
                                            KPI 유형
                                        </td>
                                        <td class="tableContent" style="height: 19px;">
                                            <asp:Label ID="lblRESULT_ACHIEVEMENT_TYPE" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdfCauseDocNo" Value="" runat="server" />
                                            <asp:HiddenField ID="hdfMeasureDocNo" Value="" runat="server" />
                                            <asp:HiddenField ID="hdfInitiativeDocNo" Value="" runat="server" />
                                            <asp:HiddenField ID="hdfRESULT_DIFF_FILE_ID" runat="server" Value="" />
                                            <asp:HiddenField ID="hdfEXPECT_REASON_FILE_ID" runat="server" Value="" />
                                            <asp:DropDownList ID="ddlScoreGrade" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span style="font-weight: bold;"><font color="red">&nbsp;* 측정유형 [시스템]은 과거 실적변경이 불가합니다.</font></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px;">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-left: 3px;
                                    padding-right: 3px;">
                                    <tr>
                                        <td>
                                            <img alt="" src="../images/icon/subtitle.gif" />&nbsp;<span style="font-weight: bold;">실적</span>
                                        </td>
                                        <td style="width: 570px;" align="left">
                                            <img alt="" src="../images/icon/subtitle.gif" />&nbsp;<asp:Label Style="font-weight: bold;"
                                                ID="lblYMD" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <ig:UltraWebGrid ID="ugrdResult" runat="server" Height="100%" OnInitializeRow="ugrdResult_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="측정년월" Key="YMD" Width="90px">
                                                                <HeaderStyle HorizontalAlign="Center" Height="17px" />
                                                                <Header Caption="측정년월">
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="#94BAC9" ForeColor="Black">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="RESULT_MS" FooterText="" HeaderText="당월실적" EditorControlID="igtxtNum"
                                                                AllowUpdate="Yes" Type="Custom" Key="RESULT_MS" Width="95px" Format="#,###,###,###,###,###,##0.####"
                                                                DataType="System.Double">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right" Cursor="Hand">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="RESULT_TS" FooterText="" HeaderText="누적실적" EditorControlID="igtxtNum"
                                                                AllowUpdate="Yes" Type="Custom" Key="RESULT_TS" Width="95px" Format="#,###,###,###,###,###,##0.####"
                                                                DataType="System.Double">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right" Cursor="Hand">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CAUSE_TEXT_MS" FooterText="" HeaderText="원인분석(당월)"
                                                                Key="CAUSE_TEXT_MS" DataType="System.String" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CAUSE_TEXT_TS" FooterText="" HeaderText="원인분석(누적)"
                                                                Key="CAUSE_TEXT_TS" DataType="System.String" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="MEASURE_TEXT_MS" FooterText="" HeaderText="대책검토(당월)"
                                                                Key="MEASURE_TEXT_MS" DataType="System.String" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="MEASURE_TEXT_TS" FooterText="" HeaderText="대책검토(당월)"
                                                                Key="MEASURE_TEXT_TS" DataType="System.String" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CHECKSTATUS" Key="CHECKSTATUS" Hidden="true">
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="평가기간"
                                                                Key="ESTTERM_REF_ID" Hidden="True" DataType="System.Int">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="KPI_REF_ID" FooterText="" HeaderText="KPI코드"
                                                                Key="KPI_REF_ID" Hidden="True" DataType="System.Int">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="OPEN_YN" FooterText="" HeaderText="평가년월" Key="OPEN_YN"
                                                                Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="CHECK_YN" FooterText="" HeaderText="측정주기" Key="CHECK_YN"
                                                                Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:TemplatedColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="No" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                    CellClickActionDefault="Edit" CellPaddingDefault="0" HeaderClickActionDefault="Select"
                                                    Name="ugrdResult" RowHeightDefault="26px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                    StationaryMargins="HeaderAndFooter" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy">
                                                    <GroupByBox Hidden="True">
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                        </BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                                        Cursor="hand">
                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="0px" />
                                                    </RowStyleDefault>
                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                    </SelectedRowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                        ForeColor="White" HorizontalAlign="Left">
                                                        <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                    </HeaderStyleDefault>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="0px"
                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="340px">
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
                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                    </ActivationObject>
                                                    <ClientSideEvents CellChangeHandler="ugrdResult_CellChangeHandler" MouseOutHandler="MouseOverHandler"
                                                        AfterCellUpdateHandler="ugrdResult_AfterCellUpdateHandler" />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                        <td valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="tableTitle" align="center" style="height: 26px; width: 590px;">
                                                        원인분석(당월)
                                                    </td>
                                                    <td class="tableTitle" align="center" style="height: 26px; width: 590px;">
                                                        원인분석(누적)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="background-color: #ffffff; height: 143px;" valign="top">
                                                        <div id="cms01" style="position: absolute; z-index: 12;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_01" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms02" style="position: absolute; z-index: 11;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_02" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms03" style="position: absolute; z-index: 10;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_03" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms04" style="position: absolute; z-index: 9;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_04" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms05" style="position: absolute; z-index: 8;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_05" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms06" style="position: absolute; z-index: 7;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_06" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms07" style="position: absolute; z-index: 6;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_07" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms08" style="position: absolute; z-index: 5;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_08" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms09" style="position: absolute; z-index: 4;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_09" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms10" style="position: absolute; z-index: 3;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_10" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms11" style="position: absolute; z-index: 2;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_11" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cms12" style="position: absolute; z-index: 1;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_MS_12" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="background-color: #ffffff; height: 143px;" valign="top">
                                                        <div id="cts01" style="position: absolute; z-index: 12;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_01" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts02" style="position: absolute; z-index: 11;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_02" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts03" style="position: absolute; z-index: 10;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_03" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts04" style="position: absolute; z-index: 9;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_04" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts05" style="position: absolute; z-index: 8;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_05" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts06" style="position: absolute; z-index: 7;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_06" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts07" style="position: absolute; z-index: 6;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_07" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts08" style="position: absolute; z-index: 5;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_08" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts09" style="position: absolute; z-index: 4;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_09" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts10" style="position: absolute; z-index: 3;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_10" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts11" style="position: absolute; z-index: 2;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_11" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="cts12" style="position: absolute; z-index: 1;">
                                                            <asp:TextBox ID="txtCAUSE_TEXT_TS_12" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tableTitle" align="center" style="height: 26px;">
                                                        대책검토(당월)
                                                    </td>
                                                    <td class="tableTitle" align="center" style="height: 26px;">
                                                        대책검토(누적)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="background-color: #ffffff; height: 143px;" valign="top">
                                                        <div id="mms01" style="position: absolute; z-index: 12;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_01" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms02" style="position: absolute; z-index: 11;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_02" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms03" style="position: absolute; z-index: 10;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_03" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms04" style="position: absolute; z-index: 9;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_04" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms05" style="position: absolute; z-index: 8;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_05" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms06" style="position: absolute; z-index: 7;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_06" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms07" style="position: absolute; z-index: 6;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_07" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms08" style="position: absolute; z-index: 5;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_08" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms09" style="position: absolute; z-index: 4;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_09" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms10" style="position: absolute; z-index: 3;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_10" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms11" style="position: absolute; z-index: 2;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_11" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mms12" style="position: absolute; z-index: 1;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_MS_12" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="background-color: #ffffff; height: 143px;" valign="top">
                                                        <div id="mts01" style="position: absolute; z-index: 12;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_01" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts02" style="position: absolute; z-index: 11;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_02" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts03" style="position: absolute; z-index: 10;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_03" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts04" style="position: absolute; z-index: 9;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_04" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts05" style="position: absolute; z-index: 8;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_05" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts06" style="position: absolute; z-index: 7;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_06" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts07" style="position: absolute; z-index: 6;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_07" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts08" style="position: absolute; z-index: 5;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_08" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts09" style="position: absolute; z-index: 4;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_09" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts10" style="position: absolute; z-index: 3;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_10" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts11" style="position: absolute; z-index: 2;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_11" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                        <div id="mts12" style="position: absolute; z-index: 1;">
                                                            <asp:TextBox ID="txtMEASURE_TEXT_TS_12" runat="server" Width="290px" Height="143px"
                                                                Rows="100" TextMode="MultiLine" MaxLength="1000" onchange="isChanging()"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 35px; padding-top: 10px;" colspan="2">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td style="height: 30px; vertical-align: top;" align="right">
                                                        <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_tp07.gif" runat="server"
                                                            OnClick="iBtnInsert_Click" OnClientClick="return getTsSumMsg();" />
                                                        <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" />
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
        <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </div>
    </form>
</body>
</html>
