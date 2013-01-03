<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0409S2.aspx.cs" Inherits="BSC_BSC0409S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" ContentPlaceHolderID="Contents" Runat="Server">
    <script type="text/javascript">
        function OpenEstDept() {
            var EsttermRefID = "<%= this.EstTermRefId.ToString() %>"
            var intEstDeptID = "<%= this.txtDeptCode.ClientID %>"
            var strEstDeptNM = "<%= this.txtDeptName.ClientID %>"

            var strURL = "../BSC/BSC0406S2.aspx?ESTTERM_REF_ID=" + EsttermRefID + "&CCB1=" + intEstDeptID + "&CCB2=" + strEstDeptNM;

            gfOpenWindow(strURL, 350, 500, 0, 0, 'BSC0381M1');
        }
    </script>
    <table cellpadding="0" cellspacing="2" border="0"  style="width:100%; height:100%;" >
	    <tr valign="top" style="height: 20px">
            <td colspan="2" style="height: 20px;">
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="cssTblTitle">평가기간&nbsp;</td>
                        <td class="cssTblContent" >
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlestterm_selectedindexchanged"></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">평가조직</td>
                        <td class="cssTblContent">
                            
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:220px;">
                                        <asp:textbox id="txtDeptName" runat="server" width="100%" ></asp:textbox>                                        
                                    </td>
                                    <td>
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
        <tr style="height:25px;">
            <td>
                <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                <asp:label id="lblRowCount" runat="server" Text="0"></asp:label>
                <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
            </td>
            <td align="right" > 
                <asp:ImageButton id="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" OnClick="iBtnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2" style="height: 100%"  > 
                <ig:UltraWebGrid runat="server" ID="ugridKpiTargetList" Width="100%" Height="100%" 
                    OnInitializeRow="ugridKpiTargetList_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand ColHeadersVisible="Yes" GridLines="Both" HeaderTitleModeDefault="Always" >
                            <Columns>
                                
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="kpiCode" Width="60px">
                                    <Header Caption="지표코드" Fixed="true"/>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="kpiName" Width="160px">
                                    <Header Caption="지표명" Fixed="true"/>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="INPUT_TYPE_NAME" Key="inputTypeName" Width="60px">
                                    <Header Caption="입력방법" Fixed="true"/>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="RESULT_TS_NAME" Key="resultTsName" Width="60px">
                                    <Header Caption="누적방식" Fixed="true"/>
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="unitName" Width="50px" >
                                    <Header Caption="단위" Fixed="true" />
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="CHAMP_EMP_NAME" Key="championEmpName" Width="80px">
                                    <Header Caption="담당자" Fixed="true" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="weight" Width="50px" DataType="Double" Format="###.00">
                                    <Header Caption="가중치" Fixed="true" />
                                    <CellStyle TextOverflow="Clip" HorizontalAlign="Right" />
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M01" Key="M01" Width="110px">
                                    <Header Caption="1월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M02" Key="M02" Width="110px">
                                    <Header Caption="2월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M03" Key="M03" Width="110px">
                                    <Header Caption="3월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M04" Key="M04" Width="110px">
                                    <Header Caption="4월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M05" Key="M05" Width="110px">
                                    <Header Caption="5월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M06" Key="M06" Width="110px">
                                    <Header Caption="6월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M07" Key="M07" Width="110px">
                                    <Header Caption="7월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M08" Key="M08" Width="110px">
                                    <Header Caption="8월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M09" Key="M09" Width="110px">
                                    <Header Caption="9월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M10" Key="M10" Width="110px">
                                    <Header Caption="10월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M11" Key="M11" Width="110px">
                                    <Header Caption="11월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="M12" Key="M12" Width="110px">
                                    <Header Caption="12월"></Header>
                                    <CellStyle HorizontalAlign="Right" Wrap="true"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="THRESHOLD_ENAME" Key="THRESHOLD_ENAME" Hidden="true"></ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  AllowColSizingDefault="Free"
                                    UseFixedHeaders="true"
                                    Name="ugridKpiTargetList"
                                    RowHeightDefault="35px" 
                                    SelectTypeRowDefault="Single"
                                    Version="4.00"
                                    AutoGenerateColumns="false"
                                    RowSelectorsDefault="No"
                                    CellClickActionDefault="RowSelect"
                                    TableLayout="Fixed"
                                    StationaryMargins="Header"
                                    OptimizeCSSClassNamesOutput="False">
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
                        
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                    </DisplayLayout>
                </ig:UltraWebGrid>
                <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport" OnEndExport="ugrdEEP_EndExport" OnCellExported="ugrdEEP_CellExported">
                </ig:UltraWebGridExcelExporter>
            </td>
		</tr>
        <tr valign="top">
            <!--
            <td valign ="middle" align="left" style="width: 387px; height: 25px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="110">
                            
                        </td>
                    </tr>
                </table>
            </td>
            -->
            
            <td valign ="middle" colspan="2" align="right">
                <asp:ImageButton ID="ibtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClick="ibtnPrint_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
    <asp:HiddenField ID="hdViewType" runat="server" />
</asp:Content>