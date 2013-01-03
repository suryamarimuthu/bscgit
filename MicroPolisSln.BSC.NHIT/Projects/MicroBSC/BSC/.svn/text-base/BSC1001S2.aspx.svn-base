<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC1001S2.aspx.cs" Inherits="BSC_BSC1001S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
   
    <script id="Infragistics" type="text/javascript">
        function confirmCheck(btype) {
            if (btype == 'i') {
                var ugrd = igtbl_getGridById('<%= ugrdDeptKpi.ClientID %>');
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
                        if (chkYN.checked) {
                            return confirm('선택한 조직KPI를 MBO로 복사하시겠습니까?');
                        }
                    }
                }
                alert('복사할 KPI를 선택하세요.');
                return false;
            }
            else if (btype == 'i2') {
                var ugrd = igtbl_getGridById('<%= ugrdTeamMbo.ClientID %>');
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
                        if (chkYN.checked) {
                            return confirm('선택한 팀원MBO를 나의 MBO로 복사하시겠습니까?');
                        }
                    }
                }
                alert('복사할 MBO를 선택하세요.');
                return false;
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
        
        function ugrdDeptKpi_DblClickHandler(gridName, cellId)
        {
            var cell            = igtbl_getElementById(cellId);
            var row             = igtbl_getRowById(cellId);
            var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB1           = "<%= this.ICCB1 %>";
            
            var url             = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID+'&CCB1='+ICCB1;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
        }

        function doLinking_Dept(estterm_ref_id, kpiID, ICCB1) {


            var url = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');
        }

        function ugrdTeamMbo_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB3 = "<%= this.ICCB3 %>";

            var url = 'BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB3;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
        }

        function doLinking_Team(estterm_ref_id, kpiID, ICCB3) {


            var url = 'BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB3;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
        }

        function ugrdMBO_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB2 = "<%= this.ICCB2 %>";

            var url = 'BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB2;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
        }

        function doLinking_MBO(estterm_ref_id, kpiID, ICCB2) {


            var url = 'BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB2;
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
        }
        
        function openInstWindow()
        {
            var estterm_ref_id = document.getElementById("<% =this.ddlEstTerm.ClientID.Replace('_','$') %>").value;
            var ICCB2           = "<%= this.ICCB2 %>";
            
            var url             = "BSC0302M2.aspx?iType=A&IS_TEAM_KPI=N&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=0&CCB1="+ICCB2;
            
            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
            return false;
        }

        var param1 = false;
//        function selectChkBox(chkChild)
//        {
//            var _elements   = document.forms[0].elements;

//            for (var i = 0; i < _elements.length; i++)
//            {
//                if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
//                {
//                    if (param1)
//                    {
//                        _elements[i].checked = false;
//                    }
//                    else {
//                        if (_elements[i].disabled == false)
//                            _elements[i].checked = true;
//                    }
//                }
//            }
//            
//            param1 = (param1==true) ? false : true;
//        }
    </script>

    <!--- MAIN START --->
    <table cellpadding="5" cellspacing="0" border="0" style="width: 100%; height: 100%;">
        <colgroup>
            <col width="60%" />
            <col width="1%" />
            <col width="39%" />
        </colgroup>
        <tr style="height: 95%;">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="height: 100%;">
                    <tr>
                        <td style="width: 50%; height: 25px; border: 0; padding: 0;" align="left">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="My 관리지표(MBO)" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 50%;" align="right">
                            <asp:ImageButton id="ibtnSearchRight" onclick="ibtnSearchRight_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 80px;">
                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height: 100%;">
                                <colgroup>
                                    <col width="15%" />
                                    <col width="35%" />
                                    <col width="15%" />
                                    <col width="35%" />
                                </colgroup>
                                <tr>
                                    <td class="cssTblTitle">
                                        평가기간
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:dropdownlist id="ddlEstTerm" class="box01" runat="server" width="100%" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" AutoPostBack="true"></asp:dropdownlist>
                                    </td>
                                    <td class="cssTblTitle">
                                        <%=this.GetText("LBL_00009", "KPI CODE") %>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox id="txtKpiCodeRight" runat="server" width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        KPI명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox id="txtKpiNameRight" runat="server" width="100%"></asp:TextBox>
                                    </td>
                                    <td class="cssTblTitle">
                                        담당자명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox id="txtChampionNameRight" runat="server" width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="cssTblTitle">
                                        지표유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:dropdownlist id="ddlKpiGroup" class="box01" runat="server" width="99%"></asp:dropdownlist>
                                    </td>
                                    <td class="cssTblTitle">
                                        운영조직
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:dropdownlist id="ddlComDeptRight" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        직무분류
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlKpiCategoryTop" Width="32%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryTop_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                                /><asp:DropDownList ID="ddlKpiCategoryMid" Width="32%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryMid_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                                /><asp:DropDownList ID="ddlKpiCategoryLow" Width="33%" runat="server" CssClass="box01" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow" >
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'ugrdMBO');" />
                                                    <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox(this,'ugrdMBO');"  />--%>
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <CellTemplate>
                                                    <asp:checkbox id="cBox" runat="server" />
                                                </CellTemplate>
                                                <CellStyle VerticalAlign="Middle"></CellStyle>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="코드">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="OP_DEPT_NAME" Width="130px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="운영조직">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="150px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="KPI 명">
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="담당자">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="지표유형">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CLASS_NAME" Key="CLASS_NAME" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="지표구분">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CATEGORY_NAME" Key="CATEGORY_NAME" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="직무분류">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="UNIT_NAME" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="단위">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="사용">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" Key="APPROVAL_STATUS" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                <Header Caption="확정">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="KPI_CLASS_REF_ID" Key="KPI_CLASS_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="CHAMPION_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" 
                                                AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="None" 
                                                AllowDeleteDefault="No"
                                                AllowSortingDefault="No"
                                                BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="NotSet"
                                                Name="ugrdMBO" 
                                                RowHeightDefault="20px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="None"
                                                Version="4.00" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="No"
                                                OptimizeCSSClassNamesOutput ="False"
                                                
                                                AutoGenerateColumns="False">
                                    <%--<GroupByBox>
                                        <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                    </GroupByBox>
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
                                    </SelectedRowStyleDefault>
                                    <ClientSideEvents DblClickHandler="ugrdMBO_DblClickHandler" />--%>
                                    <GroupByBox>
                                        <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                                    </GroupByBox>
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle"  ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                    <ClientSideEvents DblClickHandler="ugrdMBO_DblClickHandler" />
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="middle" align="center" style="padding-top: 100px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                    <tr>
                        <td>
                            <asp:ImageButton id="ibtnDelete" OnClientClick="return confirmCheck('d');" OnClick="ibtnDelete_Click" runat="server" ImageUrl="../images/arrow/arrow_right.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                            <br />
                            <asp:ImageButton id="ibtnInsert" OnClientClick="return confirmCheck('i');" OnClick="ibtnInsert_Click" runat="server" ImageUrl="../images/arrow/arrow_left.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton id="ibtnDelete2" OnClientClick="return confirmCheck('d2');" OnClick="ibtnDelete2_Click" runat="server" ImageUrl="../images/arrow/arrow_right.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                            <br />
                            <asp:ImageButton id="ibtnInsert2" OnClientClick="return confirmCheck('i2');" OnClick="ibtnInsert2_Click" runat="server" ImageUrl="../images/arrow/arrow_left.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width:100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" style="height: 100%; width:100%;">
                                <tr>
                                    <td style="width: 50%; height: 25px;" align="left" valign="middle">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="Label1" runat="server" style="font-weight:bold" text="대상 조직KPI" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="right">
                                        <asp:ImageButton id="ibtnSearchLeft" onclick="ibtnSearchLeft_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 40px;">
                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height: 100%;">
                                            <tr>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    운영조직
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:dropdownlist id="ddlComDeptLeft" class="box01" Width="100%" runat="server" />
                                                </td>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    KPI 코드
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:TextBox id="txtKpiCodeLeft" runat="server" Width="100%" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    KPI명
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:TextBox id="txtKpiNameLeft" runat="server"  Width="100%" />
                                                </td>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    담당자명
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:TextBox id="txtChampionNameLeft" runat="server" Width="100%" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top">
                                        <ig:UltraWebGrid ID="ugrdDeptKpi" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDeptKpi_InitializeRow" OnInitializeLayout="ugrdDeptKpi_InitializeLayout" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:TemplatedColumn Key="selchk" Width="25px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'ugrdDeptKpi');" />
                                                                <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox(this,'ugrdDeptKpi');" />--%>
                                                            </HeaderTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellTemplate>
                                                                <asp:checkbox id="cBox" runat="server" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="60px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="코드">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="33%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="KPI 명">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="OP_DEPT_NAME" Width="30%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="운영조직">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="15%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="담당자">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowColumnMovingDefault="None" 
                                                            AllowDeleteDefault="No"
                                                            AllowSortingDefault="Yes" 
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="NotSet" 
                                                            Name="ugrdDeptKpi" 
                                                            RowHeightDefault="20px" 
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Extended" 
                                                            Version="4.00" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            OptimizeCSSClassNamesOutput="False"
                                                            
                                                            AutoGenerateColumns="False">
                                                <%--<GroupByBox>
                                                    <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
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
                                                </SelectedRowStyleDefault>
                                                <ClientSideEvents DblClickHandler="ugrdDeptKpi_DblClickHandler" />--%>
                                                <GroupByBox>
                                                    <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                                                </GroupByBox>
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <ClientSideEvents DblClickHandler="ugrdDeptKpi_DblClickHandler" />
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;">
                            <table cellpadding="0" cellspacing="0" border="0" style="height: 100%; width:100%;">
                                <tr>
                                    <td style="width: 50%; height: 25px;" align="left" valign="middle">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:15px;">
                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                </td>
                                                <td>
                                                    <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="대상조직 팀원MBO" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%;" align="right">
                                        <asp:ImageButton id="ibtnSearchLeft2" onclick="ibtnSearchLeft2_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 40px;">
                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height: 100%;">
                                            <tr>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    운영조직
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:dropdownlist id="ddlComDeptLeft2" class="box01" runat="server" width="100%"></asp:dropdownlist>
                                                </td>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    MBO CODE
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:TextBox id="txtKpiCodeLeft2" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    MBO 명
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:TextBox id="txtKpiNameLeft2" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                                <td class="cssTblTitle" style="width:75px;">
                                                    담당자명
                                                </td>
                                                <td class="cssTblContent" style="width:105px;">
                                                    <asp:TextBox id="txtChampionNameLeft2" runat="server" width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top">
                                        <ig:UltraWebGrid ID="ugrdTeamMbo" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdTeamMbo_InitializeRow" OnInitializeLayout="ugrdTeamMbo_InitializeLayout" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:TemplatedColumn Key="selchk" Width="25px">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'ugrdTeamMbo');" />
                                                                <%--<img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;"  onclick="selectChkBox(this,'ugrdTeamMbo');" />--%>
                                                            </HeaderTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <CellTemplate>
                                                                <asp:checkbox id="cBox" runat="server" />
                                                            </CellTemplate>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="60px">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                            <Header Caption="코드">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="33%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="MBO 명">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="OP_DEPT_NAME" Width="30%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="운영조직">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" Key="CHAMPION_EMP_NAME" Width="15%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="담당자">
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Hidden="true"></ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                    </Columns>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowColumnMovingDefault="None" 
                                                            AllowDeleteDefault="No"
                                                            AllowSortingDefault="Yes" 
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="NotSet" 
                                                            Name="ugrdTeamMbo" 
                                                            RowHeightDefault="20px" 
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Extended" 
                                                            Version="4.00" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            OptimizeCSSClassNamesOutput="False"
                                                            
                                                            AutoGenerateColumns="False">
                                                <%--<GroupByBox>
                                                    <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
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
                                                </SelectedRowStyleDefault>
                                                <ClientSideEvents DblClickHandler="ugrdTeamMbo_DblClickHandler" />--%>
                                                <GroupByBox>
                                                    <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                                                </GroupByBox>
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <ClientSideEvents DblClickHandler="ugrdTeamMbo_DblClickHandler" />
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
        <tr style="height: 20px;">
            <td valign="middle">
                <div style="vertical-align: middle;">
                    <asp:ImageButton runat="server" ID="ibtnAdd" ImageUrl="../images/btn/b_035.gif" ImageAlign="AbsMiddle" OnClientClick="return openInstWindow();" />
                            <asp:LinkButton id="lbtReloadLeft" runat="server" OnClick="lbtReloadLeft_Click"></asp:LinkButton>
                            <asp:LinkButton id="lbtReloadRight" runat="server" OnClick="lbtReloadRight_Click"></asp:LinkButton>
                            <asp:LinkButton id="lbtReloadLeft2" runat="server" OnClick="lbtReloadLeft2_Click"></asp:LinkButton>
	                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
	                        
	                        <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                        
                    <asp:ImageButton ID="ibtnFirst" runat="server" OnClick="ibtnFirst_Click" Width="10" ImageUrl="../images/paging/01-1.gif" />&nbsp;
                    <asp:ImageButton ID="ibtnPre" runat="server" OnClick="ibtnPre_Click" Width="10" ImageUrl="../images/paging/01-2.gif" />&nbsp;
                    <asp:Button ID="ibtn1" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn2" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn3" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn4" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn5" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn6" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn7" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn8" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn9" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:Button ID="ibtn10" runat="server" BackColor="White" Font-Bold="true" OnClick="ibtnPaging_Click" />
                    <asp:ImageButton ID="ibtnNext" runat="server" OnClick="ibtnNext_Click" Width="10" ImageUrl="../images/paging/01-3.gif" />&nbsp;
                    <asp:ImageButton ID="ibtnLast" runat="server" OnClick="ibtnLast_Click" Width="10" ImageUrl="../images/paging/01-4.gif" />&nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
