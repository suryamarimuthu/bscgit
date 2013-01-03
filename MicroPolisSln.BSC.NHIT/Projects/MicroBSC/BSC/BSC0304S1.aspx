<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0304S1.aspx.cs" Inherits="BSC_BSC0304S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--

function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
       var cell         = igtbl_getElementById(id);
       cell.style.cursor = 'hand';
    }
}

function UltraWebGrid1_DblClickHandler(gridName, id)
{
	var cell            = igtbl_getElementById(id);
    var row             = igtbl_getRowById(id);
    var estterm_ref_id  = row.getCellFromKey("ESTTERM_REF_ID").getValue();
    var kpi_ref_id      = row.getCellFromKey("KPI_REF_ID").getValue();
    var ymd             = row.getCellFromKey("YMD").getValue();
    
    location.href = 'BSC0304S2.aspx?ESTTERM_REF_ID='    + estterm_ref_id 
                                + '&KPI_REF_ID='        + kpi_ref_id 
                                + '&YMD='               + ymd;
}// -->
</script>

 <!--- MAIN START --->	
     <table width="100%" cellpadding="0" border="0" cellspacing="0" style="height: 100%;">
        
        <tr>
	        <td valign="top">
	            <table border="0" cellpadding="0" class="tableBorder" cellspacing="0" width="100%">
	                
	                <tr>
	                    <td class="cssTblTitle">평가기간</td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" CssClass="box01" width="69%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="ddlMonthInfo" runat="server" CssClass="box01" Width="30%" ></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">지표유형</td>
                        <td class="cssTblContent" align="left">
                            <asp:dropdownlist id="ddlKpiGroupRefID" CssClass="box01" runat="server" width="99%"></asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                        <td class="cssTblContent">
                            <asp:textbox id="txtKPICode" runat="server" CssClass="box01" width="100%"></asp:textbox></td>
                        <td class="cssTblTitle">KPI 명</td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtKPIName" runat="server" CssClass="box01" width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            지표그룹
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="box01" Width="100%"></asp:DropDownList>
                        </td>
                    
                        <td class="cssTblTitle">실적구분</td>
                        <td align="left" class="cssTblContent">
                            <asp:dropdownlist id="ddlSumType" runat="server" CssClass="box01" Width="60px"></asp:dropdownlist><asp:dropdownlist id="ddlResultInput" runat="server" CssClass="box01" width="90px"></asp:dropdownlist><asp:dropdownlist id="ddlExternalType" runat="server" CssClass="box01" width="90px"></asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle"><%=this.GetText("LBL_00001", "챔피언") %></td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtChamName" runat="server" CssClass="box01" width="100%"></asp:TextBox>
                        </td>	
                        <td  class="cssTblTitle">시그널</td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlSignal" runat="server" CssClass="box01" width="100%" Visible="true"></asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">순위</td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlOrderType" runat="server" CssClass="box01" width="45px"></asp:dropdownlist>
                            <asp:TextBox ID="txtCntKpi" runat="server" width="20px" MaxLength="2"></asp:TextBox>건</td>
                        <td class="cssTblTitle">
                            평가대상
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstYN" runat="server" CssClass="box01" width="100%"></asp:dropdownlist>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 5px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="110">
                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                            <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;" Visible="false">
                                <asp:ListItem Text="Target" Value="TARGET" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Goal" Value="GOAL"></asp:ListItem>
                            </asp:RadioButtonList>&nbsp;&nbsp;
                            <asp:ImageButton id="iBtnSearch" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
          <td valign="top" style="height: 100%;">
	        <ig:UltraWebGrid ID="ugrdResultStatus" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdResultStatus_InitializeRow" OnInitializeLayout="ugrdResultStatus_InitializeLayout" >
                  <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                                    Hidden="True" Width="40px">
                                    <Header Caption="선택">
                                    </Header>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="RANK" Key="RANK" Width="30px" Hidden="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="순위">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="코드" Key="KPI_CODE" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="코드">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" HeaderText="운영부서"
                                    Key="OP_DEPT_NAME" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영부서">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Justify">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="운영조직" Key="DEPT_NAME" Hidden="True">
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
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI 담당자" Key="CHAMPION_EMP_NAME"
                                    Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 담당자">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 명">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" HeaderText="실적 방식"
                                    Key="RESULT_INPUT_TYPE_NAME" Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적 방식">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표유형"
                                    Key="KPI_GROUP_NAME" Width="70px" Hidden="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="단위">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET" DataType="System.Decimal" Format="#,###,###,###,###,###,###,##0.00"
                                    HeaderText="계획" Key="TARGET" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="계획">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT" DataType="System.Decimal" Format="#,###,###,###,###,###,###,##0.00"
                                    HeaderText="실적" Key="RESULT" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="ACHIEVE_RATE" DataType="System.Double" Format="##,##0.00"
                                    HeaderText="달성율" Key="ACHIEVE_RATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="달성율">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right" >
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:TemplatedColumn>
                               <%-- <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" DataType="System.Double" Format="##,##0.00"
                                    HeaderText="달성율" Key="ACHIEVE_RATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="달성율">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>--%>
                                <ig:UltraGridColumn BaseColumnName="PACT" DataType="System.Double" HeaderText="차이"
                                    Hidden="True" Key="PACT" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="차이">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHECK_STEP" HeaderText="측정단계" IsBound="True"
                                    Key="CHECK_STEP" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="측정단계">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn HeaderText="측정대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="60px">
                                    <Header Caption="평가대상">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SIGNAL_IMAGE" HeaderText="신호" Key="SIGNAL_IMAGE"
                                    Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="신호">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TREND" HeaderText="추세" Key="TREND" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="추세">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PN_UTYPE" Hidden="True" Key="PN_UTYPE">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                                    Format="" HeaderText="YMD" Hidden="True" Key="YMD">
                                    <Header Caption="YMD">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TREND" Key="TREND_CODE" Hidden="true" />
                                <ig:UltraGridColumn BaseColumnName="CHECK_YN" Key="CHECK_YN_CODE" Hidden="true" />
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" 
                                   AllowColumnMovingDefault="OnServer" 
                                   AllowDeleteDefault="Yes"
                                   AllowSortingDefault="Yes" 
                                   BorderCollapseDefault="Separate" 
                                   AutoGenerateColumns="False" 
                                   HeaderClickActionDefault="SortMulti" 
                                   Name="ugrdResultStatus" 
                                   RowHeightDefault="20px" 
                                   ReadOnly="LevelTwo"
                                   RowSelectorsDefault="No" 
                                   SelectTypeRowDefault="Extended" 
                                   Version="4.00" 
                                   ViewType="OutlookGroupBy" 
                                   CellClickActionDefault="RowSelect" 
                                   TableLayout="Fixed" 
                                   OptimizeCSSClassNamesOutput="False"
                                   StationaryMargins="Header">
                            <%--<GroupByBox>
                                <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
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
                                <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
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
                        <ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>--%>
                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                        </DisplayLayout>
                </ig:UltraWebGrid>
                
                <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" 
                    OnBeginExport="ugrdEEP_BeginExport" OnCellExporting="ugrdEEP_CellExporting" />
         </td>
       </tr>
       <tr>
         <td style="height:25px; width: 100%;">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td align="left" style="width: 50%;">
                        
                    </td>
                    <td align="right" style="width: 50%;">
                        <asp:ImageButton ID="iBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClick="iBtnPrint_Click" ImageAlign="Middle"  />
                    </td>
                </tr>
            </table>
         </td>
       </tr>
     </table>
<!--- MAIN END --->
</asp:Content>