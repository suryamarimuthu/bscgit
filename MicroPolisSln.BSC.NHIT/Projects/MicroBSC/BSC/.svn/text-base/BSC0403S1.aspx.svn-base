<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0403S1.aspx.cs" Inherits="BSC_BSC0403S1"
    MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

    <script id="Infragistics" type="text/javascript">

        function MouseOverHandler(gridName, id, objectType) {
            if (objectType == 0) {
                var cell = igtbl_getElementById(id);
                var row = igtbl_getRowById(id);
                var band = igtbl_getBandById(id);
                var active = igtbl_getActiveRow(id);
                cell.style.cursor = 'hand';
            }
        }

        function AfterSelectChangeHandler(gridName, id) {
            var row = igtbl_getRowById(id);
            var est_dept_id = row.getCellFromKey("EST_DEPT_REF_ID").getValue();

            MBSCMain.location.href = "usr5002.aspx?edeptid=" + est_dept_id
                                        + "&tmcode=" + form1.ddlMonthInfo.options[form1.ddlMonthInfo.selectedIndex].value
                                        + "&sumtype=" + form1.ddlSumType.options[form1.ddlSumType.selectedIndex].value
                                        + "&esttermrefid=" + form1.ddlEstTermInfo.options[form1.ddlEstTermInfo.selectedIndex].value;
        }
    
    </script>

    <script language="jscript" type="text/javascript">

        function showMemo() {
            document.all.imgShow.style.display = "none";
            document.all.imgHide.style.display = "block";
            document.all.leftLayer.style.display = "block";
            document.all.tdleftLayer.style.width = "25%";
        }

        function hiddenMemo() {
            document.all.imgShow.style.display = "block";
            document.all.imgHide.style.display = "none";
            document.all.leftLayer.style.display = "none";
            document.all.tdleftLayer.style.width = "0%";
        }

        function OpenEstDept() {
            var EsttermRefID = "<%= PageUtility.GetIntByValueDropDownList(ddlEstTermInfo).ToString() %>"
            var intEstDeptID = "<%= this.ICCB1 %>"
            var strEstDeptNM = "<%= this.ICCB2 %>"
            var strLinkBtnNm = "<%= this.ICCB3 %>";

            var strURL = "../BSC/BSC0406S2.aspx?ESTTERM_REF_ID=" + EsttermRefID + "&CCB1=" + intEstDeptID + "&CCB2=" + strEstDeptNM + "&CCB3=" + strLinkBtnNm;

            gfOpenWindow(strURL, 350, 500, 0, 0, 'BSC0406S2');
        }


        function itemCntDropDownList() {
            var ddlControl = document.getElementById("<%=this.ddlComTypeInfo.ClientID %>");
            var dept_type_flag = document.getElementById("<%=this.hdfDept_Type_Flag.ClientID %>");

            if (dept_type_flag.value == "") {
                alert("조직 유형을 불러오는 중입니다.");
                return false;
            }

            if (dept_type_flag.value == "0") {
                alert("하위 조직이 있는 조직을 선택 후 조회하세요.");
                return false;
            }

            return true;
        }
    </script>

    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 87%;">
        <tr>
            <td style="width: 100%;">
                <asp:Panel ID="plnWhere" runat="server" Width="100%">
                    <table class="tableBorder" cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td class="cssTblTitle">
                                측정주기
                            </td>
                            <td class="cssTblContent">
                                <asp:DropDownList Width="100%" ID="ddlEstTermInfo" CssClass="box01" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td class="cssTblTitle">
                                조직
                            </td>
                            <td class="cssTblContent">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="width: 100%;">
                                            <asp:TextBox ID="txtDeptName" runat="server" Width="100%" />
                                        </td>
                                        <td>
                                            <img alt="" src='../images/btn/b_094.gif' style="cursor: hand; vertical-align: bottom;"
                                                onclick="OpenEstDept();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">
                                조회구분
                            </td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlSumType" CssClass="box01" Enabled="true" Width="100%" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="cssTblTitle">
                                측정월
                            </td>
                            <td class="cssTblContent" align="left">
                                <asp:DropDownList ID="ddlMonthInfo" CssClass="box01" Width="100%" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="cssTblTitle">
                                조직유형
                            </td>
                            <td class="cssTblContent">
                                <asp:DropDownList ID="ddlComTypeInfo" CssClass="box01" Width="60px" Enabled="true"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:CheckBox ID="chkApplyExtScore" Text="외부평가점수반영" runat="server" />
                                <asp:CheckBox ID="chkInSubDept" runat="server" Text="하위조직포함" Visible="False" />
                                <asp:HiddenField ID="hdfDept_Type_Flag" runat="server" Value="" />
                            </td>
                            <td class="cssTblTitle">
                                조회수준
                            </td>
                            <td class="cssTblContent" align="left">
                                <asp:DropDownList ID="ddlMapLevel" CssClass="box01" Width="100%" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="cssPopBtnLine">
                            <asp:HiddenField ID="hdfDeptID" runat="server" Value="0"></asp:HiddenField>
                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" ImageUrl="../images/btn/b_033.gif"
                                OnClick="iBtnSearch_Click" OnClientClick="return itemCntDropDownList()" />
                            <asp:ImageButton ID="iBtnPrint" runat="server" align="absmiddle" ImageUrl="../images/btn/b_080.gif"
                                Visible="false" OnClick="iBtnPrint_Click" />
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                    <tr>
                        <td valign="top" style="width: 25%; height: 100%;" id="tdplnScoreGrid" runat="server">
                            <asp:Panel ID="plnScoreGrid" runat="server" Width="100%" Height="97%">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                                    <tr>
                                        <td style="width: 100%; height: 100%;">
                                            <div id="leftLayer" style="width: 100%; height: 100%;">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                    <tr>
                                                        <td style="width: 100%; height: 100%;">
                                                            <ig:UltraWebGrid ID="ugrdScore" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdScore_InitializeRow"
                                                                OnClick="ugrdScore_Click">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <Columns>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                                <Header Caption="ESTTERM_REF_ID">
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText="" Format=""
                                                                                HeaderText="YMD" Key="YMD" Hidden="true">
                                                                                <Header Caption="YMD">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="SUM_TYPE" EditorControlID="" FooterText="" Format=""
                                                                                HeaderText="SUM_TYPE" Hidden="True" Key="SUM_TYPE">
                                                                                <Header Caption="SUM_TYPE">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="ACCESS_YN" EditorControlID="" FooterText="" Format=""
                                                                                HeaderText="ACCESS_YN" Hidden="True" Key="ACCESS_YN">
                                                                                <Header Caption="ACCESS_YN">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" EditorControlID="" FooterText=""
                                                                                Format="" HeaderText="부서ID" Hidden="True" Key="EST_DEPT_REF_ID">
                                                                                <Header Caption="부서ID">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="DEPT_TYPE" EditorControlID="" FooterText="" Format=""
                                                                                HeaderText="DEPT_TYPE" Hidden="True" Key="DEPT_TYPE">
                                                                                <Header Caption="DEPT_TYPE">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="RANK_ID" DataType="System.Int16" HeaderText="순위"
                                                                                Hidden="false" Key="RANK_ID" Width="30px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="순위">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText="" Format=""
                                                                                HeaderText="부서명" Key="DEPT_NAME" Width="100px" Hidden="false">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="부서명">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="SCORE" DataType="System.Double" EditorControlID=""
                                                                                FooterText="" Format="###,###,###.00" HeaderText="점수" Key="SCORE" Width="40px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="점수">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Right">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="DEPT_GRADE" DataType="System.String" EditorControlID=""
                                                                                FooterText="" HeaderText="등급" Key="DEPT_GRADE" Width="40px" Hidden="false">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="등급">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="RANK_PERCENT" DataType="System.Double" EditorControlID=""
                                                                                FooterText="" Format="###,###,###.00" HeaderText="점수" Key="RANK_PERCENT" Width="40px"
                                                                                Hidden="true">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="%">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Right">
                                                                                </CellStyle>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                        </Columns>
                                                                    </ig:UltraGridBand>
                                                                </Bands>
                                                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                    AutoGenerateColumns="False" BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect"
                                                                    HeaderClickActionDefault="NotSet" OptimizeCSSClassNamesOutput="False" Name="ugrdScore"
                                                                    HeaderStyleDefault-Height="26px" RowHeightDefault="20px" RowSelectorsDefault="No"
                                                                    SelectTypeRowDefault="Extended" StationaryMargins="Header" TableLayout="Fixed"
                                                                    Version="4.00">
                                                                    <GroupByBox>
                                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                                        </BoxStyle>
                                                                    </GroupByBox>
                                                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                    </HeaderStyleDefault>
                                                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                    <RowStyleDefault CssClass="GridRowStyle" />
                                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                    </SelectedRowStyleDefault>
                                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                    </RowAlternateStyleDefault>
                                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                                                    </FrameStyle>
                                                                </DisplayLayout>
                                                            </ig:UltraWebGrid>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td align="right">
                                                            <asp:ImageButton ID="iBtnPrintRank" runat="server" ImageUrl="../images/btn/b_080.gif"
                                                                Visible="false" OnClick="iBtnPrintRank_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td style="width: 4px;">
                                            &nbsp; <a href="javascript:hiddenMemo();" style="display: none;">
                                                <img src="../images/btn/btn_Hide.gif" id="imgHide" /></a><br />
                                            <a href="javascript:showMemo();">
                                                <img src="../images/btn/btn_Show.gif" id="imgShow" style="display: none" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td valign="top" style="width: 100%">
                            <div id="RL" style="width: 100%; height: 100%;">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 97%;">
                                    <tr>
                                        <td valign="top" style="width: 100%;">
                                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                                <tr>
                                                    <td class="cssTblTitle" width="80">
                                                        부서명
                                                    </td>
                                                    <td class="tdBorder" colspan="3">
                                                        <asp:Label ID="lblDeptName" runat="server" Width="98%"></asp:Label>
                                                    </td>
                                                    <td class="subcssTblTitle" width="150" rowspan="4" align="right">
                                                        <asp:GridView ID="grvSignal" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowHeader="false" CellPadding="0" CellSpacing="0" BorderWidth="0">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="신호" ItemStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="imgSignal" ImageUrl='<%# "../images/"+Eval("IMAGE_FILE_NAME") %>'
                                                                            runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="THRESHOLD_ENAME" DataField="THRESHOLD_ENAME" ItemStyle-Font-Names="wizz" />
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDash" runat="server" Text=":"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="THRESHOLD_KNAME" DataField="THRESHOLD_KNAME" HtmlEncode="False"
                                                                    ItemStyle-Font-Names="wizz" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle" width="80">
                                                        조직비전
                                                    </td>
                                                    <td class="tdBorder" colspan="3">
                                                        <asp:Label ID="lblDeptVision" runat="server" Width="98%"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle" width="80">
                                                        <%=GetText("LBL_00001", "챔피언") %>
                                                    </td>
                                                    <td class="tdBorder" style="width: 100px;">
                                                        <asp:Label ID="lblBSCChampion" runat="server" Width="95%"></asp:Label>
                                                    </td>
                                                    <td class="cssTblTitle" width="80">
                                                        순위
                                                    </td>
                                                    <td class="tdBorder" style="width: 100px;">
                                                        <asp:Label ID="lblRank" runat="server" Font-Bold="True" ForeColor="Navy" Text=" "></asp:Label>/
                                                        <asp:Label ID="lblRankAll" runat="server" Font-Bold="True" ForeColor="Navy" Text=" "></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle" width="80">
                                                        BSC점수
                                                    </td>
                                                    <td class="tdBorder">
                                                        <asp:Label ID="lblTotalScore" runat="server" Width="90%" Font-Bold="True" ForeColor="Navy"
                                                            Text="0"></asp:Label>
                                                    </td>
                                                    <td class="cssTblTitle" width="80">
                                                        등급
                                                    </td>
                                                    <td class="tdBorder">
                                                        <asp:Label ID="lblGrade" runat="server" Width="90%" Font-Bold="True" ForeColor="Navy"
                                                            Text=" "></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 100%;">
                                            <ig:UltraWebGrid ID="ugrdScoreCard" runat="server" OnInitializeRow="ugrdScoreCard_InitializeRow"
                                                OnInitializeLayout="ugrdScoreCard_InitializeLayout" Width="100%" Height="90%">
                                                <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                                                    OptimizeCSSClassNamesOutput="False" ReadOnly="LevelTwo" ViewType="Hierarchical"
                                                    SelectTypeCellDefault="Extended" BorderCollapseDefault="NotSet" AllowColSizingDefault="Free"
                                                    Name="ugrdScoreCard" TableLayout="Fixed" RowSelectorsDefault="No" NoDataMessage=" "
                                                    SelectTypeColDefault="Extended" CellClickActionDefault="RowSelect">
                                                    <GroupByBox>
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                        </BoxStyle>
                                                    </GroupByBox>
                                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                    </HeaderStyleDefault>
                                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                    <RowStyleDefault CssClass="GridRowStyle" />
                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                    </SelectedRowStyleDefault>
                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                    </RowAlternateStyleDefault>
                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                                    </FrameStyle>
                                                </DisplayLayout>
                                                <Bands>
                                                    <ig:UltraGridBand AddButtonCaption="Column0Column1Column2" Key="Column0Column1Column2">
                                                    </ig:UltraGridBand>
                                                </Bands>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <ig:UltraWebGrid ID="ugrdScoreRankPrint" runat="server" Width="100%" Height="92%"
                    Visible="false" OnInitializeRow="ugrdScoreRankPrint_InitializeRow">
                    <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                        ViewType="Hierarchical" SelectTypeCellDefault="Extended" BorderCollapseDefault="NotSet"
                        AllowColSizingDefault="Free" Name="ugrdScoreRankPrint" TableLayout="Fixed" SelectTypeColDefault="Extended"
                        CellClickActionDefault="RowSelect" AutoGenerateColumns="False">
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                            </BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                        </HeaderStyleDefault>
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                        </SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                        </RowAlternateStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                        </FrameStyle>
                    </DisplayLayout>
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <Header Caption="ESTTERM_REF_ID">
                                    </Header>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText="" Format=""
                                    HeaderText="YMD" Key="YMD" Hidden="true">
                                    <Header Caption="YMD">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SUM_TYPE" EditorControlID="" FooterText="" Format=""
                                    HeaderText="SUM_TYPE" Hidden="True" Key="SUM_TYPE">
                                    <Header Caption="SUM_TYPE">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ACCESS_YN" EditorControlID="" FooterText="" Format=""
                                    HeaderText="ACCESS_YN" Hidden="True" Key="ACCESS_YN">
                                    <Header Caption="ACCESS_YN">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="부서ID" Hidden="True" Key="EST_DEPT_REF_ID">
                                    <Header Caption="부서ID">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_TYPE" EditorControlID="" FooterText="" Format=""
                                    HeaderText="DEPT_TYPE" Hidden="True" Key="DEPT_TYPE">
                                    <Header Caption="DEPT_TYPE">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RANK_ID" DataType="System.Int16" HeaderText="순위"
                                    Hidden="false" Key="RANK_ID" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="순위">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText="" Format=""
                                    HeaderText="부서명" Key="DEPT_NAME" Width="350px" Hidden="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="부서명">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SCORE" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="###,###,###.00" HeaderText="점수" Key="SCORE" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="점수">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_GRADE" DataType="System.String" EditorControlID=""
                                    FooterText="" HeaderText="등급" Key="DEPT_GRADE" Width="80px" Hidden="false">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="등급">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RANK_PERCENT" DataType="System.Double" EditorControlID=""
                                    FooterText="" Format="###,###,###.00" HeaderText="점수" Key="RANK_PERCENT" Width="40px"
                                    Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="%">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                </ig:UltraWebGrid>
                <ig:UltraWebGrid ID="ugrdScoreCardPrint" runat="server" Width="100%" Height="92%"
                    OnInitializeRow="ugrdScoreCardPrint_InitializeRow" OnInitializeLayout="ugrdScoreCardPrint_InitializeLayout"
                    Visible="False">
                    <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                        ViewType="Hierarchical" SelectTypeCellDefault="Extended" BorderCollapseDefault="NotSet"
                        AllowColSizingDefault="Free" Name="ugrdScoreCardPrint" TableLayout="Fixed" SelectTypeColDefault="Extended"
                        CellClickActionDefault="RowSelect" AutoGenerateColumns="False">
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                            </BoxStyle>
                        </GroupByBox>
                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                        </HeaderStyleDefault>
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                        </SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                        </RowAlternateStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                        </FrameStyle>
                    </DisplayLayout>
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="VIEW_NAME" Key="VIEW_NAME" Width="100px" MergeCells="True"
                                    HeaderText="관점명">
                                    <Header Caption="관점명">
                                    </Header>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_NAME" Key="STG_NAME" Width="150px" MergeCells="True"
                                    HeaderText="전략명">
                                    <Header Caption="전략명">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="250px" HeaderText="지표명">
                                    <Header Caption="지표명">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT" Key="UNIT" Width="50px" HeaderText="단위">
                                    <Header Caption="단위">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET" Key="TARGET" Width="90px" DataType="System.Double"
                                    Format="#,##0.00" HeaderText="목표">
                                    <Header Caption="목표">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT" Key="RESULT" Width="90px" DataType="System.Double"
                                    Format="#,##0.00" HeaderText="실적">
                                    <Header Caption="실적">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SIGNAL_NAME" Key="SIGNAL_NAME" Width="100px"
                                    HeaderText="시그널">
                                    <Header Caption="시그널">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="60px" Format="#,##0.00"
                                    HeaderText="원시가중치">
                                    <Header Caption="원시가중치">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CURRENT_WEIGHT" Key="CURRENT_WEIGHT" Width="60px"
                                    Format="#,##0.00" HeaderText="변환가중치">
                                    <Header Caption="변환가중치">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ORI_POINT" Key="ORI_POINT" Width="60px" Format="#,##0.00"
                                    HeaderText="획득점수">
                                    <Header Caption="획득점수">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT" Key="POINT" Width="60px" Format="#,##0.00"
                                    HeaderText="변환점수">
                                    <Header Caption="변환점수">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="AC_POINT" Key="AC_POINT" Width="60px" Format="#,##0.00"
                                    HeaderText="최종점수">
                                    <Header Caption="최종점수">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                </ig:UltraWebGrid>
                <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport"
                    OnInitializeRow="ugrdEEP_InitializeRow">
                </ig:UltraWebGridExcelExporter>
                <ig:UltraWebGridExcelExporter ID="ugrdEEP_Rank" runat="server" OnBeginExport="ugrdEEP_Rank_BeginExport">
                </ig:UltraWebGridExcelExporter>
                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                <asp:LinkButton ID="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
    <!--- MAIN END --->
</asp:Content>
