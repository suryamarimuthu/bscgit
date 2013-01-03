<%@ Page Title="" Language="C#" MasterPageFile="~/_common/lib/MicroBSC.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="BSC0381M1.aspx.cs" Inherits="BSC_BSC0381M1" %>

<asp:Content ID="cttContents" ContentPlaceHolderID="Contents" Runat="Server">
    <script type="text/javascript">
        function OpenEstDept() {
            var EsttermRefID = "<%= this.EstTermRefId.ToString() %>"
            var intEstDeptID = "<%= this.txtDeptCode.ClientID %>"
            var strEstDeptNM = "<%= this.txtDeptName.ClientID %>"

            var strURL = "../BSC/BSC0406S2.aspx?ESTTERM_REF_ID=" + EsttermRefID + "&CCB1=" + intEstDeptID + "&CCB2=" + strEstDeptNM;

            gfOpenWindow(strURL, 350, 500, 0, 0, 'BSC0381M1');
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

        function doCheckingListCount() {
//            alert(document.getElementById('ctl00_Contents_lblRowCount').innerHTML);

            var rowCnt = document.getElementById('ctl00_Contents_lblRowCount').innerHTML;

            return (rowCnt > 0);

        }

        function doAutoCulcuration(obj, type) {

            var temp = obj.id.split('_');

            //var objColNo = temp[3];
            var rowNo = temp[4];
            var startColNo = 6;
            
            //var startLoop = objColNo - startColNo;

            var resultMs = 0;
            var resultTs = 0;
            
            for (i = 1; i < 13; i++) {

                var colNo = startColNo + i;
            
                var loopNo = i;
                if (loopNo < 10)
                    loopNo = '0' + i.toString();

                var idMs = 'igtxtctl00_Contents_ugridKpiTargetList_ci_0_' + colNo + '_' + rowNo + '_txtM' + loopNo + 'Ms';
                var idTs = 'igtxtctl00_Contents_ugridKpiTargetList_ci_0_' + colNo + '_' + rowNo + '_txtM' + loopNo + 'Ts';


                var txtMs = parseFloat(document.getElementById(idMs).value);
                var txtTs = parseFloat();

                resultMs += txtMs;

                if (type == "SUM") {

                    resultTs = resultMs;
                }

                if (type == "AVG") {
                    resultTs = resultMs / i;
                }

                document.getElementById(idTs).value = resultTs;
            }


            //alert('a');
        }
    </script>
    <table cellpadding="0" cellspacing="1" border="0"  style="width:100%; height:100%;" >
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
                                    <td  class="cssTblContent" style="width:59px">
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
        <tr>
            <td valign="top" style="height: 100%"  > 
                <ig:UltraWebGrid runat="server" ID="ugridKpiTargetList" Width="100%" Height="100%" 
                    OnInitializeRow="ugridKpiTargetList_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand >
                            <Columns>
                                
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="kpiCode" Width="50px">
                                    <Header Caption="지표"/>
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="kpiName" Width="160px">
                                    <Header Caption="지표 이름"/>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="INPUT_TYPE_NAME" Key="inputTypeName" Width="50px">
                                    <Header Caption="입력"/>
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="RESULT_TS_NAME" Key="resultTsName" Width="60px">
                                    <Header Caption="누적방식"/>
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="unitName" Width="50px" >
                                    <Header Caption="단위" />
                                    <CellStyle HorizontalAlign="Center" />
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="CHAMP_EMP_NAME" Key="championEmpName" Width="80px">
                                    <Header Caption="담당자" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="weight" Width="50px" DataType="Double" Format="###.00">
                                    <Header Caption="가중치" />
                                    <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="m01Target" Width="80px">
                                    <Header Caption="M01" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget01" style="display:none;" runat="server" />
                                        <ig:webnumericedit id="txtM01Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two"  EnableAppStyling="False">
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM01Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" EnableAppStyling="False" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m02Target" Width="80px">
                                    <Header Caption="M02" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget02" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM02Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM02Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m03Target" Width="80px">
                                    <Header Caption="M03" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget03" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM03Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM03Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m04Target" Width="80px">
                                    <Header Caption="M04" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget04" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM04Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM04Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m05Target" Width="80px">
                                    <Header Caption="M05" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget05" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM05Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM05Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m06Target" Width="80px">
                                    <Header Caption="M06" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget06" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM06Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM06Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m07Target" Width="80px">
                                    <Header Caption="M07" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget07" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM07Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM07Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m08Target" Width="80px">
                                    <Header Caption="M08" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget08" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM08Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM08Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m09Target" Width="80px">
                                    <Header Caption="M09" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget09" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM09Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM09Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m10Target" Width="80px">
                                    <Header Caption="M10" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget10" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM10Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM10Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m11Target" Width="80px">
                                    <Header Caption="M11" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget11" runat="server" style="display:none;" />
                                        <ig:webnumericedit id="txtM11Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM11Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:TemplatedColumn Key="m12Target" Width="80px">
                                    <Header Caption="M12" />
                                    <CellTemplate>
                                        <input type="text" id="txtTarget12" style="display:none;" runat="server" />
                                        <ig:webnumericedit id="txtM12Ms" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                        <ig:webnumericedit id="txtM12Ts" runat="server" Width="100%" Nullable="False" ValueText="0.00" BorderColor="red" BorderWidth="2px"
                                                MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" MaxLength="20"
                                                Height="100%" NullText="0" MinDecimalPlaces="Two" >
                                        </ig:webnumericedit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="CLOSE_YN" Key="closeYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RELEASE_YN" Key="releaseYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="estTermRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="estDeptRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="deptName"  Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MAP_VERSION_ID" Key="mapVersionId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="MAP_VERSION_NAME" Key="mapVersionName" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="estYmd" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PER_YEAR" Key="perYear" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_VISION" Key="deptVision" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" Key="stgRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="kpiRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SORT_ORDER" Key="sortOrder" Hidden="true"></ig:UltraGridColumn>                                
                                <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" Key="kpiPoolRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_ACHIEVEMENT_TYPE" Key="resultAchievementType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE" Key="resultInputType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TERM_TYPE" Key="resultTermType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TERM_NAME" Key="resultTermName" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TS_CALC_TYPE" Key="resultTsCalcType" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_TYPE_REF_ID" Key="unitTypeRefId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ROLLUP_SCORE_YN" Key="rollupScoreYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ROLLUP_TARGET_YN" Key="rollupTargetYn" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="championEmpId" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ORG_DEPT_NAME" Key="orgDeptName" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" Key="kpiTargetVersionId" Hidden="true"></ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" 
                                   UseFixedHeaders="true"
                                   Name="ugridKpiTargetList" 
                                   RowHeightDefault="50px" 
                                   SelectTypeRowDefault="Single" 
                                   Version="4.00" 
                                   AutoGenerateColumns="false" 
                                   RowSelectorsDefault="No"
                                   CellClickActionDefault="RowSelect" 
                                   TableLayout="Fixed" 
                                   StationaryMargins="Header"
                                   ReadOnly="LevelTwo" >
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
                            <asp:ImageButton ID="iBtnUpdate" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="iBtnUpdate_Click" AlternateText="UpdateAll" OnClientClick="return doCheckingListCount();"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</asp:Content>