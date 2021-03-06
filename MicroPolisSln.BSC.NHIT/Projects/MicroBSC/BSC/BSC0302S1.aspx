﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0302S1.aspx.cs" Inherits="BSC_BSC0302S1"
    MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">

        function draftBatch() {
            var estterm_ref_id = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
            var ICCB1 = "<%= this.ICCB1 %>";

            var url = "BSC0302M3.aspx?CCB1=" + ICCB1;

            gfOpenWindow(url, 810, 645, 'yes', 'no', 'BSC0302M3');
            return false;
        }

        function ugrdKpiList_DblClickHandler(gridName, cellId) {
            var cell = igtbl_getElementById(cellId);
            var row = igtbl_getRowById(cellId);
            var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
            var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
            var ICCB1 = "<%= this.ICCB1 %>";

            var url = 'BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;
            //gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1');

            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1_' + kpiID);
        }

        function doPoppingUp_KPI(estterm_ref_id, kpiID, ICCB1) {
            var target = '<%=ConfigurationSettings.AppSettings["GOALTONG_YN"] %>';
            var url = target == "Y" ? "BSC0302M5.aspx" : "BSC0302M1.aspx";
            url += '?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + '&CCB1=' + ICCB1;

            gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1_' + kpiID);
        }

        function openInstWindow() {
            var estterm_ref_id = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
            var ICCB1 = "<%= this.ICCB1 %>";

            var url = "BSC0302M1.aspx?iType=A&IS_TEAM_KPI=Y&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=0&CCB1=" + ICCB1;

            gfOpenWindow(url, 800, 645, 'yes', 'no', 'BSC0302M1');
            return false;
        }

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

        function btnTempleteMatch_Click() {
            var temp = document.getElementById("rdot").checked;
            var kpi = document.getElementById("rdop").checked;
            var est = document.getElementById("<%=ddlEstTermInfo.ClientID %>").value;
            var url = "BSC0302M4.aspx";
            if (temp) {
                url = "BSC0302M4.aspx?type=T&est=" + est;
            }
            else if (kpi) {
                url = "BSC0302M4.aspx?type=K&est=" + est;
            }
            else {
                alert('추가하실 항목을 선택해 주세요.');
                return false;
            }
            gfOpenWindow(url, 700, 550, 'yes', 'no', 'BSC0302M2');
            return false;
        }

        function calcWeight() {
            var ugrd = igtbl_getGridById('<%= ugrdKpiList.ClientID %>');
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

            document.getElementById("spSum").value = sumWeight;

        }

        function totalSumValidate() {
            var ugrd = igtbl_getGridById('<%= ugrdKpiList.ClientID %>');
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

            if (sumWeight > 100) {
                alert('합계는 100이하여야 합니다.'); return false;
            }
        }

        function openDeptEmp() {

            var estterm_ref_id = "<%= ddlEstTermInfo.SelectedValue %>";
            var strKeyObj = "<%=hdfChampionEmpId.ClientID %>";
            var strValObj = "<%=txtChampionEmpName.ClientID %>";
            var url = "../ctl/ctl2106.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&OBJ_KEY=" + strKeyObj + "&OBJ_VAL=" + strValObj;

            gfOpenWindow(url, 750, 400, 'yes', 'no', 'bsc2100s1');
        }
        function Validation() {
            var emp = document.getElementById("<%=hdfChampionEmpId.ClientID %>").value;
            if (emp == "") { alert("사원을 선택하세요."); return false; }
        }
    </script>

    <!--- MAIN START --->
    <asp:Literal ID="LitTest" runat="server"></asp:Literal>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
        <tr valign="top">
            <td colspan="2" style="height: 40px;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td>
                            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="cssTblTitle">
                                        평가기간
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlEstTermInfo" CssClass="box01" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblTitle">
                                        운영조직
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlEstDept" CssClass="box01" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        지표유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlKpiGroupRefID" CssClass="box01" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblTitle">
                                        실적방식
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlResultInput" CssClass="box01" runat="server" Width="100%"
                                            Visible="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <!--<td class="cssTblTitle"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                  <td class="cssTblContent"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>-->
                                    <td class="cssTblTitle">
                                        KPI 명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtKPIName" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="cssTblTitle">
                                        <%=this.GetText("LBL_00001", "KPI 담당자")%>
                                    </td>
                                    <td class="cssTblContent" style="border-right: none;">
                                        <asp:TextBox ID="txtChamName" CssClass="box01" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 25px;">
            <td align="left">
                <img style="vertical-align: middle;" src="../Images/etc/lis_t01.gif" alt="" />
                <asp:Label ID="lblRowCount" runat="server" Text="0"></asp:Label>
                <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
            </td>
            <td align="right">
                <a href="BSC0401S1.ASPX">
                    <img src="../Images/btn/b_086.gif" alt="전략체계도 보기" align="absmiddle" /></a>
                <asp:ImageButton ID="iBtnSearch" OnClick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif"
                    ImageAlign="AbsMiddle"></asp:ImageButton>&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <%--<ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow" OnInitializeLayout="ugrdKpiList_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed">
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                               
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32"
                                    HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32"
                                    HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" FooterText=""
                                    HeaderText="KPI 코드" Key="KPI_CODE" Width="75px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="KPI 코드">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" FooterText=""
                                    HeaderText="운영조직" Key="OP_DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" FooterText=""
                                    HeaderText="평가조직" Key="EST_DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="평가조직">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" FooterText=""
                                    HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI 담당자" Key="CHAMPION_EMP_NAME" Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 담당자">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME"
                                    HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적방식">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" Width="60px" HeaderText="사용여부">
                                  <Header Caption="사용여부">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                  <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Footer>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Width="60px" HeaderText="APP_STATUS">
                                  <Header Caption="결재상태">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                  <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                  </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="dept_ref_id" DataType="System.Int32"
                                    HeaderText="관리부서ID" Hidden="True" Key="dept_ref_id">
                                    <Header Caption="관리부서ID">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="daily_phone" HeaderText="연락처" Hidden="True"
                                    Key="daily_phone">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="연락처">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="emp_email" HeaderText="E-Mail" Hidden="True"
                                    Key="emp_email" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="E-Mail">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                    Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="측정단계">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_EST_DEPT_ID" DataType="System.Int16" HeaderText="상위부서"
                                    Hidden="True" Key="UP_EST_DEPT_ID" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="상위부서">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                     <DisplayLayout CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="None" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdKpiList" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    ReadOnly="LevelTwo"
                                    OptimizeCSSClassNamesOutput="False">
                       
                        <GroupByBox>
                            <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
   
                    </DisplayLayout>
                </ig:UltraWebGrid>--%>
                <ig:ultrawebgrid id="ugrdKpiList" runat="server" width="100%" height="100%" oninitializerow="ugrdKpiList_InitializeRow"
                    oninitializelayout="ugrdKpiList_InitializeLayout">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px" >
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                               
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" HeaderText="STG_REF_ID" Hidden="True" Key="STG_REF_ID">
                                </ig:UltraGridColumn>
                               
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="KPI 명" Key="KPI_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" Width="60px" DataType="System.Double" AllowUpdate="Yes">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="가중치">
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" Width="60px" HeaderText="사용여부">
                                  <Header Caption="사용여부">
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Width="60px" HeaderText="APP_STATUS">
                                  <Header Caption="결재상태">
                                  </Header>
                                  <HeaderStyle Wrap="True" />
                                  <CellStyle HorizontalAlign="Center"></CellStyle>
                                  <CellTemplate>
                                    <asp:image runat="server" id="imgApp" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                  </CellTemplate>
                                </ig:TemplatedColumn>
                                 <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                 <ig:UltraGridColumn BaseColumnName="view_name" HeaderText="관점" Key="view_name" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="관점">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="stg_name" HeaderText="전략" Key="stg_name" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="전략">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME" Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI담당자">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" HeaderText="평가조직" Key="EST_DEPT_NAME" Width="130px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="평가조직">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="운영조직" Key="DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="dept_ref_id" HeaderText="관리부서ID" Hidden="True" Key="dept_ref_id">
                                    <Header Caption="관리부서ID">
                                    </Header>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="daily_phone" HeaderText="연락처" Hidden="True" Key="daily_phone">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="연락처">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="emp_email" HeaderText="E-Mail" Hidden="True" Key="emp_email" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="E-Mail">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                    Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="측정단계">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_EST_DEPT_ID" HeaderText="상위부서" Hidden="True" Key="UP_EST_DEPT_ID" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="상위부서">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" HeaderText="EST_DEPT_REF_ID" Hidden="True"
                                    Key="EST_DEPT_REF_ID" Width="150px">
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  Name="ugrdKpiList" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    AutoGenerateColumns="False">
                        <GroupByBox>
                            <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                        <ClientSideEvents AfterCellUpdateHandler="calcWeight" />
                    </DisplayLayout>
                </ig:ultrawebgrid>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 25px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <div style="display: none;">
                                <asp:Label runat="server" ID="lblCopyText" Text="평가중인 평가대상기간:"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlEsttermCopy" CssClass="box01">
                                </asp:DropDownList>
                                <asp:ImageButton runat="server" ID="iBtnKpiCopy" ImageUrl="../images/btn/b_054.gif"
                                    ImageAlign="AbsMiddle" OnClick="iBtnKpiCopy_Click" />
                            </div>
                            <input type="radio" name="rdoAddType" id="rdot" value="T" />
                            <label for="rdot">
                                전략템플릿</label>
                            <input type="radio" name="rdoAddType" id="rdop" value="P" />
                            <label for="rdop">
                                KPI풀</label>
                            <img src="../images/btn/b_005.gif" onclick="btnTempleteMatch_Click();" align="absmiddle"
                                style="cursor: pointer;" />
                            &nbsp;&nbsp; (가중치 합:
                            <input type="text" style="width: 30px; text-align: right;" readonly="readonly" id="spSum"
                                value="<%=totalsum %>">)
                            <asp:ImageButton runat="server" ID="btnSumAdd" OnClick="btnSumAdd_Click" ImageAlign="AbsMiddle"
                                ImageUrl="../images/btn/b_308.gif" OnClientClick="return totalSumValidate();" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtChampionEmpName" runat="server" BorderWidth="0" ReadOnly="true" Width="150px"></asp:TextBox>
                           <img alt="" id="ibtnChampion" runat="server" src="../images/btn/b_008.gif" style="vertical-align:inherit; cursor:hand;" onclick="openDeptEmp();" />
                           <asp:HiddenField ID="hdfChampionEmpId" runat="server" />
                           <asp:Button runat="server" ID="btnSave" Text="담당자변경" OnClick="btnSave_Click" />
                        </td>
                        <td align="right">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="iBtnConfirm" runat="server" ImageUrl="../images/btn/b_045.gif"
                                            ImageAlign="AbsMiddle" OnClick="iBtnConfirm_Click" Visible="false"></asp:ImageButton>
                                        <asp:ImageButton ID="iBtnCancel" runat="server" ImageUrl="../images/btn/b_019.gif"
                                            ImageAlign="AbsMiddle" OnClick="iBtnCancel_Click" Visible="false"></asp:ImageButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <asp:ImageButton runat="server" ID="ibtnDraftBatch" ImageUrl="../images/btn/btn_draft_batch.gif"
                    ImageAlign="AbsMiddle" OnClientClick="return draftBatch();" />
                <div style="display: none;">
                    <asp:ImageButton runat="server" ID="iBtnInsert" ImageUrl="../images/btn/b_005.gif"
                        ImageAlign="AbsMiddle" OnClientClick="return openInstWindow();" /></div>
            </td>
        </tr>
    </table>
    <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>
