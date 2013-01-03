<%@ Page Title="" Language="C#" MasterPageFile="~/_common/lib/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC0581M1.aspx.cs" Inherits="BSC_BSC0581M1" %>

<asp:Content ID="cttContents" ContentPlaceHolderID="Contents" Runat="Server">
    <script type="text/javascript">
        function OpenEstDept() {
            var EsttermRefID = "<%= this.EstTermRefId.ToString() %>"
            var intEstDeptID = "<%= this.txtDeptCode.ClientID %>"
            var strEstDeptNM = "<%= this.txtDeptName.ClientID %>"

            var strURL = "../BSC/BSC0406S2.aspx?ESTTERM_REF_ID=" + EsttermRefID + "&CCB1=" + intEstDeptID + "&CCB2=" + strEstDeptNM;

            gfOpenWindow(strURL, 350, 500, 0, 0, 'BSC0581M1');
        }

        function ApplyIFResult(gridId) {
            var grid, gridRow;
            var calMsVal = 0;
            var calTsVal = 0;
            var resultCount = 0;
            grid = igtbl_getGridById(gridId);

            for (var idx = 0; idx < grid.Rows.length; idx++) {
                gridRow = grid.Rows.getRow(idx);

                //alert(gridRow.getCellFromKey("resultInputType").getValue());
                
                if (gridRow.getCellFromKey("resultInputType").getValue() == "SYS") {
                    calMsVal = gridRow.getCellFromKey("calResultMs").getValue();
                    calTsVal = gridRow.getCellFromKey("calResultTs").getValue();

                    var msEditor = igedit_getById(gridRow.getCellFromKey("resultMs").getElement().children[gridRow.getCellFromKey("resultMs").getElement().children.length - 3].id);
                    msEditor.setValue(calMsVal);

                    var tsEditor = igedit_getById(gridRow.getCellFromKey("resultTs").getElement().children[gridRow.getCellFromKey("resultTs").getElement().children.length - 3].id);
                    tsEditor.setValue(calTsVal);

                    resultCount = resultCount + 1;
                }
            }

            var msg = "자동계산은 입력방식이\r\nSystem(System Data Interface)일때 동작합니다.";

            if (resultCount > 0)
                msg = resultCount + "건이 적용 되었습니다.";

            alert(msg);
        }

        function UpdateResults(gridId) {
            var grid;
            grid = igtbl_getGridById(gridId);

            if (grid.Rows.length > 0) {
                return true;
            } else {
                return false;
            }
        }

        
    </script>
    <table cellpadding="0" cellspacing="2" border="0"  style="width:100%; height:100%;" >
	    <tr>
            <td>
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="cssTblTitle">평가기간</td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="65%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" 
                            /><asp:dropdownlist id="ddlEstTermMonth" runat="server" class="box01" width="33%"></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">평가조직</td>
                        <td class="cssTblContent">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:textbox id="txtDeptName" runat="server" width="100%" ></asp:textbox>
                                    </td>
                                    <td  class="cssTblContent" style="width:60px;" align="right">
                                        <asp:HiddenField ID="txtDeptCode" runat="server" />
                                        <img alt="" src='../images/btn/b_094.gif' onclick="OpenEstDept();" style="cursor:hand; vertical-align:middle" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
	        <td class="cssPopBtnLine">
	             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width:50%;">
                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                             <asp:ImageButton id="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" OnClick="iBtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td valign="top">
                <ig:UltraWebGrid runat="server" ID="ugridKpiTargetList" Width="100%" Height="100%" EnableViewState="true" 
                    OnInitializeRow="ugridKpiTargetList_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand ColHeadersVisible="Yes" GridLines="Both" HeaderTitleModeDefault="Always" >
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="estTermRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="estDeptRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MAP_VERSION_ID" Key="mapVersionId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MAP_VERSION_NAME" Key="mapVersionName" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="estYmd" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_VISION" Key="deptVision" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" Key="stgRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="kpiRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SORT_ORDER" Key="sortOrder" Hidden="true"></ig:UltraGridColumn>                                
                                <ig:TemplatedColumn Key="selchk" Width="25px">
                                  <HeaderTemplate >
                                    <asp:CheckBox ID="cBox_header" alt="전제선택/해제" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'ugridKpiTargetList');" />
                                  </HeaderTemplate>
                                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                  <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" style="cursor:pointer;"/>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="kpiCode" Width="50px">
                                    <Header Caption="지표" />
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" Key="kpiPoolRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="kpiName" Width="160px">
                                    <Header Caption="지표 이름" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_ACHIEVEMENT_TYPE" Key="resultAchievementType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE" Key="resultInputType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="INPUT_TYPE_NAME" Key="inputTypeName" Width="50px">
                                    <Header Caption="입력" />
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TERM_TYPE" Key="resultTermType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TERM_NAME" Key="resultTermName" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TS_CALC_TYPE" Key="resultTsCalcType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TS_NAME" Key="resultTsName" Width="60px">
                                    <Header Caption="누적방식" />
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_TYPE_REF_ID" Key="unitTypeRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="unitName" Width="50px">
                                    <Header Caption="단위" />
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ROLLUP_SCORE_YN" Key="rollupScoreYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ROLLUP_TARGET_YN" Key="rollupTargetYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="championEmpId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMP_EMP_NAME" Key="championEmpName" Width="80px">
                                    <Header Caption="담당자" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="weight" Width="50px" DataType="Double" Format="###.00">
                                    <Header Caption="가중치" />
                                    <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ORG_DEPT_NAME" Key="orgDeptName" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET_MS" Key="targetMs" Width="80px" FieldLen="20" DataType="Double" Format="###,###.00">
                                    <Header Caption="당월목표" />
                                     <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="targetTs" Width="80px" DataType="Double" Format="###,###.00">
                                    <Header Caption="누적목표" />
                                     <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CAL_RESULT_MS" Key="calResultMs" Width="80px" DataType="Double" Format="###,###.00">
                                    <Header Caption="당월I/F" />
                                     <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CAL_RESULT_TS" Key="calResultTs" Width="80px" DataType="Double" Format="###,###.00">
                                    <Header Caption="누적I/F" />
                                     <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="resultMs" Width="80px">
                                    <Header Caption="당월실적" />
                                    <CellTemplate>
                                        <ig:webnumericedit id="txtResultMs" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" EnableAppStyling="False" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="resultTs" Width="80px">
                                    <Header Caption="누적실적" />
                                    <CellTemplate>
                                        <ig:webnumericedit id="txtResultTs" runat="server" Width="100%" Nullable="False" ValueText="0.00"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="누적실적" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" EnableAppStyling="False"  >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="CLOSE_YN" Key="closeYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RELEASE_YN" Key="releaseYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="APP_REF_ID" Key="APP_REF_ID" Hidden="true"></ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" 
                        AllowColSizingDefault="Free" 
                        AllowDeleteDefault="No" 
                        AllowAddNewDefault="No" 
                        AllowColumnMovingDefault="None"
                        BorderCollapseDefault="Separate" 
                        AllowSortingDefault="No"
                        HeaderClickActionDefault="NotSet" 
                        Name="ugridKpiTargetList" 
                        RowHeightDefault="30px"
                        RowSelectorsDefault="No" 
                        SelectTypeRowDefault="Single" 
                        Version="4.00" 
                        CellClickActionDefault="RowSelect" 
                        TableLayout="Fixed" 
                        StationaryMargins="Header"
                        AutoGenerateColumns="False" 
                        AllowUpdateDefault="RowTemplateOnly" 
                        SelectTypeCellDefault="Single" 
                        SelectTypeColDefault="Single">
                        <%--<RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" >
                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <ClientSideEvents  />
                        <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="25px">
                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="1px" Height="100%" Width="100%">
                        </FrameStyle>--%>
                        
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                        <Images>
                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                        </Images>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
		</tr>
        <tr valign="top">
            <td class="cssPopBtnLine">
                <table width="100%">
                    <tr>
                        <td style="width:50%;">
                           <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hdViewType" runat="server" />
                            
                        </td>            
                        <td align="right">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                            <asp:ImageButton ID="iBtnApply" runat="server" ImageUrl="../images/btn/b_014.gif" AlternateText="Calculate" />
                            <asp:ImageButton ID="iBtnUpdate" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="iBtnUpdate_Click" AlternateText="UpdateAll" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</asp:Content>

