﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001S4.aspx.cs" Inherits="BSC_BSC1001S4"
    MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">
        //////////////////////////
        //윈도우 열릴때 실행
        function initPage() {
            calcWeight();
        }

        /*
        alert(e.keyCode); //크롬, 익스
        alert(e.which);//크롬, 파이어폭스
        alert(e.charCode); //크롬
        alert(document.all); //익스
        */

        if (window.addEventListener) {
            window.addEventListener("load", initPage, false); // W3C DOM 지원 브라우저 
        }
        else if (window.attachEvent) {
            window.attachEvent("onload", initPage); // W3C DOM 지원 브라우저 외(ex:MSDOM 지원 브라우저 IE) 
        }
        else {
            window.onload = initPage;
        }
        //윈도우 열릴때 실행
        //////////////////////////


        function confirmCheck(btype) {
            if (btype == 'i') {

            }
            else if (btype == 'i2') {

            }
            else if (btype == 'd') {
                var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
                if (ugrd.Rows.length > 0) {
                    for (var i = 0; i < ugrd.Rows.length; i++) {
                        var tRow = ugrd.Rows.getRow(i);
                        var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                        if (chkYN.checked) {
                            if ('<%= this.IDEPT_ID %>' != tRow.getCellFromKey("COM_DEPT_REF_ID").getValue()) {
                                alert(i.toString() + " 번째 선택한 항목은 담당부서가 아닙니다.");
                                return false;
                            }
                        }
                    }
                    for (var i = 0; i < ugrd.Rows.length; i++) {
                        var tRow = ugrd.Rows.getRow(i);
                        var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                        if (chkYN.checked)
                            return confirm('선택한 MBO를 삭제시겠습니까?');
                    }
                }
                alert('삭제할 MBO를 선택하세요.');
                return false;
            }

            else if (btype == 'd2') {
                var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
                if (ugrd.Rows.length > 0) {
                    for (var i = 0; i < ugrd.Rows.length; i++) {
                        var tRow = ugrd.Rows.getRow(i);
                        var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                        if (chkYN.checked) {
                            if ('<%= this.IDEPT_ID %>' != tRow.getCellFromKey("COM_DEPT_REF_ID").getValue()) {
                                alert(i.toString() + " 번째 선택한 항목은 담당부서가 아닙니다.");
                                return false;
                            }
                        }
                    }
                    for (var i = 0; i < ugrd.Rows.length; i++) {
                        var tRow = ugrd.Rows.getRow(i);
                        var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                        if (chkYN.checked)
                            return confirm('선택한 MBO를 삭제시겠습니까?');
                    }
                }
                alert('삭제할 MBO를 선택하세요.');
                return false;
            }
        }

        function ugrdMBO_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB2 = "<%= this.ICCB2 %>";

            var url = 'BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB2;
            gfOpenWindow(url, 900, 670, 'yes', 'no', 'BSC0302M2');
        }

        function doLinking_MBO(estterm_ref_id, kpiID, ICCB2) {
            var target = '<%=ConfigurationSettings.AppSettings["GOALTONG_YN"] %>';
            var url = target == "Y" ? "BSC0302M6.aspx" : "BSC0302M2.aspx";
            url += '?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB2;
            gfOpenWindow(url, 900, 670, 'yes', 'no', 'BSC0302M2');
        }

        function openInstWindow() {
            var rdoTeamKpi = document.getElementById("<%=rdoTeamKpi.ClientID %>").checked;
            var rdoTemplateKpi = document.getElementById("<%=rdoTemplateKpi.ClientID %>").checked;
            var rdoKpiPool = document.getElementById("<%=rdoKpiPool.ClientID %>").checked;

            if (rdoTeamKpi) {
                doPopingup_Dept()
            }
            else if (rdoTemplateKpi) {
                doPopingup_Templete();
            }
            else if (rdoKpiPool) {
                var estterm_ref_id = document.getElementById("<% =this.ddlEstTerm.ClientID.Replace('_','$') %>").value;
                var ICCB2 = "<%= this.ICCB2 %>";

                //var url = "BSC0302M2.aspx?iType=A&IS_TEAM_KPI=N&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=0&CCB1=" + ICCB2;
                var url = "BSC1001M3.aspx?iType=A&IS_TEAM_KPI=N&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=0&CCB1=" + ICCB2;

                gfOpenWindow(url, 600, 645, 'yes', 'no', 'BSC1001M3');
            }

            return false;
        }

        function doPopingup_Dept() {
            var estterm_ref_id = document.getElementById("<% =this.ddlEstTerm.ClientID.Replace('_','$') %>").value;
            var ICCB2 = "<%= this.ICCB2 %>";

            var url = "BSC1001M1.aspx?ESTTERM_REF_ID=" + estterm_ref_id + '&CCB1=' + ICCB2;

            gfOpenWindow(url, 600, 600, 'yes', 'no', 'doPopingup_Dept');
            return false;
        }

        function doPopingup_Templete() {
            var estterm_ref_id = document.getElementById("<% =this.ddlEstTerm.ClientID.Replace('_','$') %>").value;
            var ICCB2 = "<%= this.ICCB2 %>";

            var url = "BSC1001M2.aspx?ESTTERM_REF_ID=" + estterm_ref_id + '&CCB1=' + ICCB2;

            gfOpenWindow(url, 800, 600, 'yes', 'no', 'doPopingup_Templete');
            return false;
        }


        function doDeleting() {
            if (doChecking('ugrdMBO')) {

                return confirm("삭제 하시겠습니까?");
            }

            return false;

        }


        function validateWeight() {
            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            var sumWeight = 0;

            if (ugrd.Rows.length > 0) {
                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);
                    var weight = tRow.getCellFromKey("WEIGHT").getValue() * 1;

                    if (tRow.getCellFromKey("USE_YN").getValue() == "N")
                        continue;

                    if (weight == null)
                        weight = 0;

                    if (weight == 0) {
                        alert("가중치를 모두 입력하세요.");
                        return false;
                    }

                    sumWeight += weight;
                }
            }

            if (sumWeight == 100)
                return true;
            else
                alert("가중치의 합은 '100'이어야 합니다.");

            return false;
        }


        function isMoDraftMsg() {
            if (confirm("수정상신이 진행되는 동안은 실적입력 및 점수산출이 진행되지 않습니다. 수정상신을 진행하시겠습니까?")) {
                return true;
            }
            else {
                return false;
            }
        }


        function checkDraft() {
            var ddl = document.getElementById('<%= ddlComDeptRight.ClientID %>');
            if (ddl.options[ddl.selectedIndex].value != '<%= this.IDEPT_ID %>') {
                alert('담당부서만 결재할 수 있습니다.');
                return false;
            }

            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            if (ugrd.Rows.length > 0) {
                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);

                    if (tRow.getCellFromKey("USE_YN").getValue() == "Y") {
                        if (tRow.getCellFromKey("APPROVAL_STATUS").getValue() != "Y") {
                            alert('확정되지 않은 KPI가 있습니다.');
                            return false;
                        }
                    }
                }
            }
            else {
                alert('상신할 MBO가 없습니다.');
                return false;
            }

            if (!validateWeight()) {
                return false;
            }


            var draftstatus = '<%= Biz_Type.app_draft_first %>';
            return OpenDraft(draftstatus);
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


        function calcWeight() {
            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            var sumWeight = 0;

            if (ugrd.Rows.length > 0) {
                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);
                    var weight = tRow.getCellFromKey("WEIGHT").getValue() * 1;

                    if (tRow.getCellFromKey("USE_YN").getValue() == "N")
                        continue;

                    if (weight == null)
                        weight = 0;

                    sumWeight += weight;
                }
            }
            if (document.getElementById("iSumWeight"))
                document.getElementById("iSumWeight").value = sumWeight;
        }
    </script>

    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%;">
                    <%--<colgroup>
                        <col width="15%" />
                        <col width="35%" />
                        <col width="15%" />
                        <col width="35%" />
                    </colgroup>--%>
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlEstTerm" class="box01" runat="server" Width="100%" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            운영조직
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlComDeptRight" class="box01" runat="server" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <!--<td class="cssTblTitle">
                            <%=this.GetText("LBL_00009", "KPI CODE") %>
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtKpiCodeRight" runat="server" Width="100%"></asp:TextBox>
                        </td>-->
                        <td class="cssTblTitle">
                            <%=this.GetText("LBL_00001", "챔피언") %>
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtChampionNameRight" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td class="cssTblTitle">
                            KPI 명
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtKpiNameRight" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        
                        <td class="cssTblTitle">
                            지표유형
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlKpiGroup" class="box01" runat="server" Width="100%">
                            </asp:DropDownList>
                            <td colspan="2"></td>
                        </td>
                    </tr>
                    <tr id="rowKpiType" runat="server">
                        <td class="cssTblTitle">
                            직무분류
                        </td>
                        <td class="cssTblContent" colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlKpiCategoryTop" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryTop_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                    /><asp:DropDownList ID="ddlKpiCategoryMid" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryMid_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                    /><asp:DropDownList ID="ddlKpiCategoryLow" Width="33%" runat="server" CssClass="box01" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cssPopBtnLine">
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t01.gif" alt="" />
                                        <asp:Label ID="lblRowCnt" runat="server" Text="0"></asp:Label>
                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                    </td>
                                    <td>
                                        (결재상태 :
                                    </td>
                                    <td>
                                        <img id="imgApprovalStatus" runat="server" alt="결재상태" src="" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="strApprovalStatus" Text="미상신" />)
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="ibtnSearchRight" OnClick="ibtnSearchRight_Click" runat="server"
                                ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 100%;">
            <td>
                <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" Style="cursor: pointer" runat="server" onclick="selectChkBox(this,'ugrdMBO');" />
                                        <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox(this,'ugrdMBO');"  />--%>
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                                    </CellTemplate>
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="230px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="50px" AllowUpdate="Yes"
                                    DataType="System.Double">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="가중치">
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IMG_USE_YN" Key="IMG_USE_YN" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="사용여부">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" Width="40px"
                                    Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="확정">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IMG_APPROVAL_STATUS" Key="IMG_APPROVAL_STATUS"
                                    Width="40px" Hidden="false">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="확정">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CODE_NAME" Key="CODE_NAME" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="지표구분">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="OP_DEPT_NAME" Width="120px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI담당자">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="40px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="코드">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="UNIT_NAME" Width="40px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="70px"
                                    Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CLASS_NAME" Key="CLASS_NAME" Width="70px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표구분">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CATEGORY_NAME" Key="CATEGORY_NAME" Width="140px"
                                    Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직무분류">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                
                                
                                
                                <ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Width="40px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="사용">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="MONTH01" HeaderText="1월" Key="MONTH01" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH02" HeaderText="2월" Key="MONTH02" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH03" HeaderText="3월" Key="MONTH03" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH04" HeaderText="4월" Key="MONTH04" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH05" HeaderText="5월" Key="MONTH05" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH06" HeaderText="6월" Key="MONTH06" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH07" HeaderText="7월" Key="MONTH07" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH08" HeaderText="8월" Key="MONTH08" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH09" HeaderText="9월" Key="MONTH09" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH10" HeaderText="10월" Key="MONTH10" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH11" HeaderText="11월" Key="MONTH11" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MONTH12" HeaderText="12월" Key="MONTH12" DataType="System.Double"
                                    Type="Custom" Width="40px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IS_TEAM_KPI" Key="IS_TEAM_KPI" Width="40px" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32"
                                    Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32"
                                    Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CLASS_REF_ID" Key="KPI_CLASS_REF_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="CHAMPION_EMP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Hidden="true">
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="0" AllowColSizingDefault="Free" AllowColumnMovingDefault="None"
                        AllowDeleteDefault="No" AllowSortingDefault="No" BorderCollapseDefault="Separate"
                        StationaryMargins="Header" HeaderClickActionDefault="NotSet" Name="ugrdMBO" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="None" Version="4.00" ViewType="Flat"
                        CellClickActionDefault="CellSelect" TableLayout="Fixed" AutoGenerateColumns="False">
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
                        <ClientSideEvents AfterCellUpdateHandler="calcWeight" />
                        <%--<ClientSideEvents DblClickHandler="ugrdMBO_DblClickHandler" />--%>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td>
                            <table id="btnArea" runat="server">
                                <tr>
                                    <td style="cursor: pointer;">
                                        <asp:RadioButton runat="server" ID="rdoTemplateKpi" Checked="true" GroupName="KpiType" Text="템플릿" />
                                        <asp:RadioButton runat="server" ID="rdoTeamKpi" GroupName="KpiType"
                                            Text="조직" />
                                        <asp:RadioButton runat="server" ID="rdoKpiPool" GroupName="KpiType" Text="풀" />
                                    </td>
                                    <td align="left" style="padding-right: 20px;">
                                        <asp:ImageButton runat="server" ID="ibtnAdd" ImageUrl="../images/btn/b_005.gif" OnClientClick="return openInstWindow();" />
                                        <asp:ImageButton runat="server" ID="iBtnDelete" ImageUrl="~/images/btn/b_004.gif"
                                            OnClick="iBtnDelete_Click" OnClientClick="return doDeleting();" />
                                    </td>
                                    <td>
                                        (가중치 합 :
                                    </td>
                                    <td>
                                        <input id="iSumWeight" value="0" style="width: 30px; text-align: right;" readonly="readonly" />
                                    </td>
                                    <td>
                                        )
                                    </td>
                                    <td>
                                        <asp:ImageButton runat="server" ID="iBtnSetWeight" ImageUrl="../images/btn/b_308.gif"
                                            OnClick="iBtnSetWeight_Click" OnClientClick="return validateWeight();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../images/btn/btn_kpi.gif"
                                OnClientClick="return doPopingup_Dept();" />
                            <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/images/btn/btn_Tkpi.gif"
                                OnClientClick="return doPopingup_Templete();" />
                            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                            <asp:LinkButton ID="lbtReload" runat="server" OnClick="lbtReload_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lbtReloadRight" runat="server" OnClick="lbtReloadRight_Click"></asp:LinkButton>
                        </td>
                        <td align="right">
                            <td style="text-align: right;">
                                <asp:ImageButton ID="iBtnDraft" AlternateText="결재상신" ImageUrl="../images/draft/draft.gif"
                                    runat="server" ImageAlign="AbsMiddle" OnClientClick="return checkDraft();" />
                                <asp:ImageButton ID="iBtnReDraft" AlternateText="재상신" ImageUrl="../images/draft/redraft.gif"
                                    runat="server" OnClientClick="return OpenDraft('redraft');" />
                                <asp:ImageButton ID="iBtnReWrite" AlternateText="재작성" ImageUrl="../images/draft/rewrite.gif"
                                    runat="server" OnClientClick="return OpenDraft('rewrite');" />
                                <asp:ImageButton ID="iBtnMoDraft" AlternateText="수정상신" ImageUrl="../images/btn/b_309.gif"
                                    runat="server" OnClientClick="return OpenDraft('modify');" />
                                <asp:ImageButton ID="iBtnReqModify" AlternateText="수정요청" ImageUrl="../images/btn/b_311.gif"
                                    runat="server" OnClientClick="return isMoDraftMsg();" OnClick="iBtnReqModify_Click" />
                            </td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
