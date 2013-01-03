<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0401S2.aspx.cs" Inherits="BSC_BSC0401S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">   
    <script type="text/javascript" src="../_common/js/yahoo/scripts.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/yahoo.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/dom.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/event.js"></script>
    <script type="text/javascript" src="../_common/js/yahoo/container.js"></script>

    <script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);
           cell.style.cursor    = 'hand';
        }
    }
    
    function ugrdMapKpi_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var kpiID           = row.getCellFromKey("KPI_REF_ID").getValue();
        var kpiName         = row.getCellFromKey("KPI_NAME").getValue();
        var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();

        var url             = "BSC0302M1.aspx?iType=S&KPI_REF_ID=" + kpiID + "&ESTTERM_REF_ID=" + estterm_ref_id
        
        gfOpenWindow(url,900, 645,'yes','no');
    }



    function doPoppingUp_KPI(estterm_ref_id, kpiID) {

        var url = "BSC0302M1.aspx?iType=S&KPI_REF_ID=" + kpiID + "&ESTTERM_REF_ID=" + estterm_ref_id

        gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1_' + kpiID);
    }
    </script>

<!--- MAIN START --->	
		<table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
		    <tr valign="top">
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                          <td>
                            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                  <td class="cssTblTitle">평가기간</td>
                                  <td class="cssTblContent">
                                     <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" width="65%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"/>
                                     <asp:dropdownlist id="ddlEstTermMonth" CssClass="box01" runat="server" width="34%" ></asp:dropdownlist>
                                  </td>
                                  <td class="cssTblTitle">실적방식</td>
                                  <td class="cssTblContent" style="border-right:none;"><asp:dropdownlist id="ddlResultInput" class="box01" runat="server" width="100%"></asp:dropdownlist></td>
                                  <!--<td class="cssTblTitle">KPI 코드</td>
                                  <td class="cssTblContent"><asp:TextBox id="txtKPICode" runat="server" width="100%"></asp:TextBox></td>-->
                                </tr>
                                <tr>
                                  <td class="cssTblTitle">KPI 명</td>
                                  <td class="cssTblContent"><asp:TextBox id="txtKPIName" runat="server" width="100%"></asp:TextBox></td>
                                  <td class="cssTblTitle"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                  <td class="cssTblContent">
                                    <asp:TextBox id="txtChamName" class="box01" runat="server" width="100%" Visible="true"></asp:TextBox>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle">평가조직
                                  </td>
                                  <td class="cssTblContent"><asp:dropdownlist id="ddlEstDept" class="box01" runat="server" width="100%"></asp:dropdownlist></td>
                                  <td class="cssTblTitle">지표유형&nbsp;</td>
                                  <td class="cssTblContent">
                                      <asp:dropdownlist id="ddlKpiGroupRefID" runat="server" class="box01" width="100%"></asp:dropdownlist>
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
                <table width="100%">
                    <tr>
                        <td align="left">
                          <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                          <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                          <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                          <asp:ImageButton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" Height="19px" ImageAlign="AbsMiddle"></asp:ImageButton>
                            <asp:ImageButton id="iBtnMoonChart" onclick="iBtnMoonChart_Click" runat="server" ImageUrl="../images/btn/b_136.gif" Height="19px" ImageAlign="AbsMiddle" Visible="false"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td valign="top">
		        <ig:UltraWebGrid ID="ugrdMapKpi" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMapKpi_InitializeRow" OnInitializeLayout="ugrdMapKpi_InitializeLayout" >
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="ESTTERM_REF_ID">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="EST_DEPT_REF_ID" Hidden="True" Key="EST_DEPT_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="EST_DEPT_REF_ID">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="평가부서명" Key="EST_DEPT_NAME" Width="80px" MergeCells="false" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="평가부서명">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STGMAP_VIEW_TYPE" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="STGMAP_VIEW_TYPE" Hidden="True" Key="STGMAP_VIEW_TYPE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="STGMAP_VIEW_TYPE">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="VIEW_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="관점명" Key="VIEW_NAME" Width="100px" MergeCells="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="관점명">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="STG_REF_ID" Hidden="True" Key="STG_REF_ID" Width="90px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="STG_REF_ID">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="전략명" Key="STG_NAME" Width="140px" MergeCells="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="전략명">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="75px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 코드">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <HeaderStyle Wrap="true" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET" DataType="System.Double" EditorControlID=""
                                    FooterText="" HeaderText="TARGET" Hidden="false" Key="TARGET" Format="#,##0.00" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="목표">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="WEIGHT" DataType="System.Double" EditorControlID=""
                                    FooterText="" HeaderText="가중치" Hidden="false" Key="WEIGHT" Format="#,##0.00" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="가중치">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI 담당자" Key="CHAMPION_EMP_NAME" Width="180px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 담당자">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
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
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID=""
                                    FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px">
                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                    <Header Caption="실적방식">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID="" Width="60px" FooterText="" HeaderText="APP_STATUS">
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
                                <ig:UltraGridColumn BaseColumnName="APPROVAL_STATUS" EditorControlID=""
                                    FooterText="" Format="" HeaderText="승인여부" Key="APPROVAL_STATUS" Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="승인여부">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>

                    <DisplayLayout CellPaddingDefault="1" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="None" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdMapKpi" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
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

                </ig:UltraWebGrid>
                
                <ig:ultrawebgrid id="ugrdMoonChartForPrint" runat="server" 
                                 Visible="false" Width="100%" Height="100%" 
                                 OnInitializeLayout="ugrdMoonChartForPrint_InitializeLayout">
                        <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single" 
                            BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
                            Name="ugrdMoonChartForPrint" TableLayout="Fixed" CellClickActionDefault="RowSelect"
                            StationaryMargins="Header" UseFixedHeaders="True" >
                            <AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
                                <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                    </BorderDetails>
                                </BoxStyle>
                                <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" 
                                       BackColor="Gray">
                                </ButtonStyle>
                            </AddNewBox>
                            <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                                ForeColor="White" BackColor="#94BAC9">
                                <Padding Left="0px" Right="0px"></Padding>
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </HeaderStyleDefault>
                            <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                            <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                            <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                BorderStyle="Solid" BackColor="#FAFCF1" Height="100%"></FrameStyle>
                            <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                            </FooterStyleDefault>
                            <ActivationObject BorderColor="170, 184, 131" BorderWidth=""></ActivationObject>
                            <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                                <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                                </BoxStyle>
                                <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
                            </GroupByBox>
                            <RowExpAreaStyleDefault BackColor="WhiteSmoke"></RowExpAreaStyleDefault>
                            <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderStyle="None"
                                HorizontalAlign="Left"></EditCellStyleDefault>
                            <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98"></SelectedRowStyleDefault>
                            <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
                            <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="#AAB883"
                                BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                                <Padding Left="3px" Right="3px"></Padding>
                                <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                            </RowStyleDefault>
                            <ClientSideEvents DblClickHandler="AfterSelectChangeHandler"  />
                            <Images>
                                <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                            </Images>
                        </DisplayLayout>
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                            </ig:UltraGridBand>
                        </Bands>
                    </ig:ultrawebgrid>
        
		    </td>
		</tr>
		<tr style="height:25px;">
		    <td>
		        <table width="100%">
		            <tr>
		                <td align="left" style="height: 30px">
                            <a href="#null" onclick="openInstWindow()">
                            <img alt="" src="../images/btn/b_005.gif" style="visibility:hidden"/></a>&nbsp;
                        </td>
			            <td align="right">
                            <asp:checkbox id="CheckBox1" runat="server" onclick="selectChkBox(this, 'ugrdMapKpi')" text="전체 선택/해제" Visible="False" Enabled="False"></asp:checkbox>
                            <asp:imagebutton id="iBtnConfirm" runat="server" imageurl="../images/btn/b_045.gif" OnClick="iBtnConfirm_Click" Visible="False"></asp:imagebutton>
                            <asp:imagebutton id="iBtnCancel" runat="server" imageurl="../images/btn/b_019.gif" onclick="iBtnCancel_Click" Enabled="False" Visible="False"></asp:imagebutton>
                            <asp:imagebutton id="iBtnPrint" runat="server" imageurl="../images/btn/b_080.gif" Visible="false"  onclick="iBtnPrint_Click"></asp:imagebutton>
                            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
			            </td>
		            </tr>
		        </table>
		    </td>
		</tr>
      </table>
      
<%--출력을 위한 그리드 숨김--%>
       
        <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" >
        </ig:UltraWebGridExcelExporter>
      
	  <asp:Literal ID="ltrScript" runat="server"></asp:Literal>

<!--- MAIN END --->
</asp:Content>