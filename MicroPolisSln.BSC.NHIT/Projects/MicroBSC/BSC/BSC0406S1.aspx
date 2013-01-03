<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0406S1.aspx.cs" Inherits="BSC_BSC0406S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">

    function MouseOverHandler(gridName, id, objectType)
    {
        if(objectType == 0) 
        {
           var cell             = igtbl_getElementById(id);
           cell.style.cursor    = 'hand';
        }
    }
   
</script>

 <!--- MAIN START --->	
     <asp:hiddenfield id="hdfDeptID" runat="server" Value="-1"></asp:hiddenfield>    
     <table width="100%" style="height: 100%;" border="0" cellpadding="0" cellspacing="0">
        <tr>
	        <td colspan="2" valign="top" style="height: 20px;">
	            <table border="0" cellpadding="0" class="tableBorder" cellspacing="0" width="100%">
	                 <tr>
	                    <td class="cssTblTitle">
	                        평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="65%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" 
                            /><asp:dropdownlist id="ddlMonthInfo" runat="server" class="box01" width="33%" ></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">
                            실적구분
                        </td>
                        <td align="left" class="cssTblContent" style="width:100%;">
                            <asp:dropdownlist id="ddlSumType" runat="server" class="box01" width="100%" ></asp:dropdownlist>
                        </td> 
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            평가조직
                        </td>
                        <td class="cssTblContent">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="width: 80%;">
                                        <asp:DropDownList ID="ddlDeptList" runat="server" Width="100%" CssClass="box01" />
                                    </td>
                                
                                </tr>
                            </table>
                        </td>                
                        <td align="center"  class="cssTblTitle" style="width:60px" > 시그널</td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlSignal" runat="server" class="box01" width="100%" Visible="true"></asp:dropdownlist>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:25px;">
            <td>
                <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
            </td>
            <td align="right">
                <asp:ImageButton id="iBtnSearch" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click"/>
            </td>
        </tr>
        <tr>
          <td colspan="2" valign="top">
	        <ig:UltraWebGrid ID="ugrdResultStatus" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdResultStatus_InitializeRow" >
                  <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                                    Hidden="True" Width="40px">
                                    <Header Caption="선택">
                                    </Header>
                                    <Footer Caption="">
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" HeaderText="평가부서"
                                    Key="EST_DEPT_NAME" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="평가부서">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="VIEW_NAME" HeaderText="VIEW_NAME"
                                    Key="VIEW_NAME" MergeCells="true" Width="130px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="관점명">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                    Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="75px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI 코드">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
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
                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" HeaderText="실적 방식"
                                    Key="RESULT_INPUT_TYPE_NAME" Width="80px">
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
                                <ig:UltraGridColumn HeaderText="측정대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="80px">
                                    <Header Caption="측정대상">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <HeaderStyle Wrap="true" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="THRESHOLD_IMG" HeaderText="신호" Key="THRESHOLD_IMG"
                                    Width="50px">
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
                               
                                <ig:UltraGridColumn BaseColumnName="TREND" HeaderText="추세" Key="TREND" Width="50px">
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
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                    <Header Caption="ESTTERM_REF_ID">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                                    <Header Caption="KPI_REF_ID">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True" >
                                    <Header Caption="YMD">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  AllowColSizingDefault="Free" 
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
                                    StationaryMargins="Header"
                                    ReadOnly="LevelTwo"
                                    OptimizeCSSClassNamesOutput="False">
                           
                            <GroupByBox>
                                <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <RowStyleDefault  CssClass="GridRowStyle" />
                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>                            
                            <%--<ClientSideEvents DblClickHandler="UltraWebGrid1_DblClickHandler" />--%>
                        </DisplayLayout>
                </ig:UltraWebGrid>
         </td>
       </tr>
       <tr>
         <td style="height:25px;">
             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" width="110">
                        
                    </td>
                </tr>
            </table>
         </td>
       </tr>
     </table>
     <asp:Literal ID="ltrScript" runat="server" Text = ""></asp:Literal>
<!--- MAIN END --->
</asp:Content>