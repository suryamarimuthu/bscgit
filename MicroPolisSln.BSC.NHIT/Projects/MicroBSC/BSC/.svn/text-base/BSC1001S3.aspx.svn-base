<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001S3.aspx.cs" Inherits="BSC_BSC1001S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <style type="text/css">
         .weightcss
         {
             text-align: right;
             vertical-align: middle;
         }
    </style>   
    <script id="Infragistics" type="text/javascript">

        function isMoDraftMsg() {
            if (confirm("수정상신이 진행되는 동안은 실적입력 및 점수산출이 진행되지 않습니다. 수정상신을 진행하시겠습니까?")) {
                return true;
            }
            else {
                return false;
            }
        }

        /*=========================================================================
        호출 파라미터 결재상신, 재상신 처리
        estterm_ref_id : 결재원문파라미터
        kpi_ref_id     : 결재원문파라미터
        app_ref_id     : 결재문서가 최초버젼일 아닐경우
        biz_type       : KDA:지표정의서 결재, KRA:지표실적결재, PMA:사업관리
        app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
        //========================================================================*/
        function OpenDraft(draftStatus) {
            var sumVal = document.getElementById('<%= txtWeightSum.ClientID %>').value;
            var sumWeight = (sumVal == "" ? 0 : parseFloat(sumVal.toString()));
            if (sumWeight < 100 || sumWeight > 100) {
                alert('가중치의 합이 100이 아니면 결재상신할 수 없습니다.');
                return false;
            }

            if (draftStatus == 'redraft')
                draftStatus = '<%= Biz_Type.app_draft_redraft %>';
            else if (draftStatus == 'rewrite')
                draftStatus = '<%= Biz_Type.app_draft_rewrite %>';
            else if (draftStatus == 'modify')
                draftStatus = '<%= Biz_Type.app_draft_modify %>';

            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            if (ugrd.Rows.length > 0) {
                var estterm_ref_id = ugrd.Rows.getRow(0).getCellFromKey("ESTTERM_REF_ID").getValue();
                var app_ref_id = "<%= IAPP_REF_ID %>";
                var app_ccb = "<%= ICCB1 %>";
                var biz_type = "<%= Biz_Type.biz_type_target_agreement %>";
                var draft_emp_id = parseInt("<%= gUserInfo.Emp_Ref_ID %>", 10);
                var emp_ref_id = draft_emp_id;

                if (draft_emp_id == "NaN" || draft_emp_id < 1) {
                    alert("기안자 정보를 알수 없습니다.");
                    return false;
                }

                var url = "BSC0901M2.aspx?DRAFT_STATUS=" + draftStatus + "&ESTTERM_REF_ID=" + estterm_ref_id + "&BIZ_TYPE=" + biz_type + "&APP_CCB=" + app_ccb + "&APP_REF_ID=" + app_ref_id + "&DRAFT_EMP_ID=" + draft_emp_id + "&EMP_REF_ID=" + emp_ref_id;
                var isExt = '<%= IEXTERNAL_APPROVAL %>';
                if (isExt == "Y") {
                    //                var url = "ApprovalGateway.aspx?DRAFT_STATUS=" + draftStatus
                    //                    + "&POPUP_TYPE=A"+"&ESTTERM_REF_ID=" + estterm_ref_id 
                    //                    + "&YMD=" + "" 
                    //                    + "&BIZ_TYPE=" + biz_type 
                    //                    + "&APP_CCB=" + app_ccb 
                    //                    + "&APP_REF_ID=" + app_ref_id
                    //                    + "&DRAFT_EMP_ID=" + draft_emp_id;
                    return false;
                }

                gfOpenWindow(url, 900, 680, 'BSC0901M2'); // 728
            }
            return false;
        }

        function OpenDraftPrint(draftStatus) {
            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            var estterm_ref_id = ugrd.Rows.getRow(0).getCellFromKey("ESTTERM_REF_ID").getValue();
            var app_ref_id = "<%= this.IAPP_REF_ID %>";
            var app_ccb = "<%= this.ICCB1 %>";
            var biz_type = "<%= Biz_Type.biz_type_target_agreement %>";
            var emp_ref_id = parseInt("<%= gUserInfo.Emp_Ref_ID %>", 10);
            var url = "BSC0901P1.aspx?DRAFT_STATUS=" + draftStatus + "&ESTTERM_REF_ID=" + estterm_ref_id + "&EMP_REF_ID=" + emp_ref_id + "&BIZ_TYPE=" + biz_type + "&APP_CCB=" + app_ccb + "&APP_REF_ID=" + app_ref_id;

            gfOpenWindow(url, 900, 650, 'BSC0901P1');

            return false;
        }

        function ugrdMBO_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB1 = "<%= this.ICCB1 %>";
            var isTeamKpi = row.getCellFromKey("IS_TEAM_KPI").getValue();
            if (isTeamKpi == "Y") {
                var url = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;
                gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
            }
            else {
                var url = 'BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;
                gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
            }
        }

        function checkDraft() {
            var ddl = document.getElementById('<%= ddlComDept.ClientID %>');
            if (ddl.options[ddl.selectedIndex].value != '<%= this.IDEPT_ID %>') {
                alert('담당부서만 결재할 수 있습니다.');
                return false;
            }

            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            if (ugrd.Rows.length > 0) {
                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);
                    if (tRow.getCellFromKey("APPROVAL_STATUS").getValue() != "Y") {
                        //alert('모든 MBO가 확정되어야만 결재상신할 수 있습니다.');
                        alert('확정되지 않은 KPI가 있습니다.');
                        return false;
                    }
                }
            }
            else {
                alert('상신할 MBO가 없습니다.');
                return false;
            }
            var draftstatus = '<%= Biz_Type.app_draft_first %>';
            return OpenDraft(draftstatus);
        }
    </script>

    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
        <tr style="height: 100%;">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                                <tr style="height:21px;">
                                    <td colspan="4">
                                        <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                                            <%--<colgroup>
                                                <col width="12%" />
                                                <col width="20%" />
                                                <col width="12%" />
                                                <col width="24%" />
                                                <col width="12%" />
                                                <col width="20%" />
                                            </colgroup>--%>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    평가기간
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:dropdownlist id="ddlEstTerm" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                                </td>
                                                <td class="cssTblTitle">
                                                    KPI 코드
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox id="txtKpiCode" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    KPI 명
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox id="txtKpiName" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                                <td class="cssTblTitle">
                                                    담당자명
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox id="txtChampionName" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    운영조직
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:dropdownlist id="ddlComDept" AutoPostBack="true" OnSelectedIndexChanged="ddlComDept_SelectedIndexChanged" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                                </td>
                                                <td class="cssTblTitle">
                                                    지표유형
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:dropdownlist id="ddlKpiGroup" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    지표구분
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:dropdownlist id="ddlMboType" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                                </td>
                                                <td class="cssTblTitle">
                                                    직무분류
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlKpiCategoryTop" Width="32%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryTop_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" /><asp:DropDownList ID="ddlKpiCategoryMid" Width="32%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryMid_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" /><asp:DropDownList ID="ddlKpiCategoryLow" Width="33%" runat="server" CssClass="box01" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td align="left" colspan="3">
                                        <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:ImageButton id="ibtnSearch" onclick="ibtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" valign="top" style="padding: 0; width: 100%;">
                                        <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow" OnInitializeLayout="ugrdMBO_InitializeLayout" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="50px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="KPI<BR />CODE" Fixed="true">
                                                                <RowLayoutColumnInfo />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="운영조직" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="250px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="KPI 명" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="50px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="담당자" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="70px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="지표유형" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CLASS_NAME" Key="CLASS_NAME" Width="70px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="지표구분" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CATEGORY_NAME" Key="CATEGORY_NAME" Width="70px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="직무분류" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="UNIT_NAME" Width="40px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="단위" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="50px" Format="###,###,###.####">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="가중치" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS_YN" Key="APPROVAL_STATUS_YN" Width="60px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="확정여부" Fixed="true">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH01" HeaderText="1월" Key="MONTH01" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH02" HeaderText="2월" Key="MONTH02" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH03" HeaderText="3월" Key="MONTH03" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH04" HeaderText="4월" Key="MONTH04" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH05" HeaderText="5월" Key="MONTH05" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH06" HeaderText="6월" Key="MONTH06" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH07" HeaderText="7월" Key="MONTH07" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH08" HeaderText="8월" Key="MONTH08" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH09" HeaderText="9월" Key="MONTH09" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH10" HeaderText="10월" Key="MONTH10" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH11" HeaderText="11월" Key="MONTH11" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="MONTH12" HeaderText="12월" Key="MONTH12" DataType="System.Double" Type="Custom" Width="60px" AllowUpdate="No" Format="###,###,##0.####">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="CHAMPION_EMP_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="IS_TEAM_KPI" Key="IS_TEAM_KPI" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout  CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowColumnMovingDefault="None" 
                                                            AllowDeleteDefault="No"
                                                            AllowSortingDefault="Yes" 
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="SortMulti" 
                                                            Name="ugrdMBO" 
                                                            RowHeightDefault="20px" 
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Extended" 
                                                            Version="4.00" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            AutoGenerateColumns="False"
                                                            UseFixedHeaders="true"
                                                            OptimizeCSSClassNamesOutput="False">
                                                <%--
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                    Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </PagerStyle>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </BoxStyle>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>--%>
                                                <GroupByBox>
                                                    <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <ClientSideEvents DblClickHandler="ugrdMBO_DblClickHandler" />
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right" valign="top" id="tdChampionContent" runat="server">
                <table cellpadding="0" cellspacing="0" border="0" class="" style="width: 100%; height: 100%;">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="* 모든 KPI가 확정되어야 결재상신 가능합니다." ForeColor="Red"></asp:Label>
                        </td>
                        <td align="right" style="width: 200px;">
                            <asp:ImageButton ID="iBtnDraft" AlternateText="결재상신" ImageUrl="../images/draft/draft.gif" runat="server" ImageAlign="AbsMiddle" OnClientClick="return checkDraft();" />
                            <asp:ImageButton ID="iBtnReDraft" AlternateText="재상신" ImageUrl="../images/draft/redraft.gif" runat="server" OnClientClick="return OpenDraft('redraft');" />
                            <asp:ImageButton ID="iBtnReWrite" AlternateText="재작성" ImageUrl="../images/draft/rewrite.gif" runat="server" OnClientClick="return OpenDraft('rewrite');" />
                            <asp:ImageButton ID="iBtnMoDraft" AlternateText="수정상신" ImageUrl="../images/draft/modraft.gif" runat="server" OnClientClick="return OpenDraft('modify');" />
                            <asp:ImageButton ID="iBtnReqModify" AlternateText="수정요청" ImageUrl="../images/draft/morequest.gif" runat="server" OnClientClick="return isMoDraftMsg();" OnClick="iBtnReqModify_Click" />            
                            <asp:ImageButton ID="ImgBtnPrint" AlternateText="인쇄" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  />
                            [<img id="imgApprovalStatus" runat="server" alt="결재상태" src="" />]
                        </td>
                        <td align="right" style="width:85px;">
                            <asp:Label ID="lblWeightSum" runat="server" Text="가중치 합계:"></asp:Label>
                        </td>
                        <td style="width: 100px;">
                            <asp:TextBox id="txtWeightSum" runat="server" CssClass="weightcss" width="100%" ReadOnly="true"></asp:TextBox>
                        </td>
                        
                    </tr>
                </table>
                <asp:LinkButton id="lbtReload" runat="server" OnClick="lbtReload_Click"></asp:LinkButton>
	            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
