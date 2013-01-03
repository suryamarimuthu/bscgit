<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0406S3.aspx.cs" Inherits="BSC_BSC0406S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>

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

function doPoppingUp_Grid(estterm_ref_id, kpi_ref_id, ymd) {
    gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID=' + estterm_ref_id + '&KPI_REF_ID=' + kpi_ref_id + '&YMD=' + ymd, 840, 600, 'no', 'no');
//    location.href = 'BSC0304S2.aspx?ESTTERM_REF_ID=' + estterm_ref_id
//                                + '&KPI_REF_ID=' + kpi_ref_id
//                                + '&YMD=' + ymd;
}// -->

</script>

 <!--- MAIN START --->	
     <table width="100%" height="100%">
        <tr>
	        <td height="20">
	              <table border="0" cellpadding="2" cellspacing="0" width="100%" class="tableBorder">
	                 <tr>
	                    <td class="cssTblTitle" >
	                        평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width=117px AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" Enabled="False"></asp:dropdownlist></td>
                        <td class="cssTblTitle" >
                            평가조직
                        </td>
                        <td align="left" class="cssTblContent">
                            &nbsp;<asp:Label ID="lblEst_Dept_Name" runat="server" Text="Label"></asp:Label></td>
                        
                    </tr>
                    <tr>
                        
                        <td class="cssTblTitle"   >
                            계획년월
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlMonthInfo" runat="server" class="box01" Width="80px" Enabled="False" ></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle" >
                            실적구분
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlSumType" runat="server" class="box01" Width="50px" ></asp:dropdownlist></td>
                        
                       
                    </tr>
                    <tr>
                        <td class="cssTblTitle" >
                            전략명</td>
                        <td class="cssTblContent" colspan="3">
                            <asp:Label ID="lblStg_Name" runat="server" Text="Label"></asp:Label></td>
                    
                        
                    </tr>
                  </table>
            </td>
        </tr>
        <tr>
            <td class="cssPopBtnLine">
                <asp:ImageButton id="iBtnSearch" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click"/>
            </td>
        </tr>
        <tr>
          <td valign="top" style="height: 100%">
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
                                    Format="" HeaderText="코드" Key="KPI_CODE" Width="40px">
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
                                    Key="OP_DEPT_NAME">
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
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                    Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI담당자">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="180px">
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
                                    Key="KPI_GROUP_NAME" Width="80px" Hidden="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="지표유형">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="40px">
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
                                <ig:UltraGridColumn BaseColumnName="TARGET" DataType="System.Decimal" Format="###,###,##0.####"
                                    HeaderText="계획" Key="TARGET" Width="80px">
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
                                <ig:UltraGridColumn BaseColumnName="RESULT" DataType="System.Decimal" Format="###,###,##0.####"
                                    HeaderText="실적" Key="RESULT" Width="80px">
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
                                <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" Format="#,##0.#0"
                                    HeaderText="달성율" Key="ACHIEVE_RATE" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="달성율">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
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
                                <ig:UltraGridColumn BaseColumnName="SIGNAL_IMAGE" HeaderText="신호" Key="SIGNAL_IMAGE"
                                    Width="35px">
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
                                <ig:UltraGridColumn BaseColumnName="TREND" HeaderText="추세" Key="TREND" Width="35px">
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
                            </Columns>
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
                            RowSelectorsDefault="No" 
                            SelectTypeRowDefault="Extended" 
                            Version="4.00" 
                            CellClickActionDefault="RowSelect" 
                            TableLayout="Fixed" 
                            OptimizeCSSClassNamesOutput = "False" 
                            ReadOnly = "LevelTwo"
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
                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        <ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />--%>
                        <GroupByBox>
                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                </GroupByBox>
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                                <ClientSideEvents DblClickHandler="DblClickHandler"/>
                                <Images>
	                                <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                </Images>
                        </DisplayLayout>
                </ig:UltraWebGrid>
         </td>
       </tr>
     </table>
<!--- MAIN END --->
</asp:Content>