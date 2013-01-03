<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0503S1.aspx.cs" Inherits="BSC_BSC0503S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);
            var termName = row.getCellFromKey("KPI_NAME").getValue();
            cell.style.cursor = 'hand';
           
            var label = igtbl_getElementById("Label2");
            var parts = id.split("_");
            if(label && parts.length>=3)
            label.innerHTML = "Current Row:" + parts[1] + " - Current Column:" + parts[2];
        }
    }
    function UltraWebGrid1_DblClickHandler(gridName, id){
        
        var cell   = igtbl_getElementById(id);
        var row    = igtbl_getRowById(id);
        var kpiID  = row.getCellFromKey("KPI_REF_ID").getValue();
        var termID = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var ymd    = row.getCellFromKey("YMD").getValue();
        var url   = "../BSC/BSC0304S2.aspx?ESTTERM_REF_ID="+ termID +"&KPI_REF_ID="+ kpiID +"&YMD="+ymd;

//        document.location.href = url;

        gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID=' + termID + '&KPI_REF_ID=' + kpiID + '&YMD=' + ymd, 840, 600, 'no', 'no');
    }
    
    function AfterSelectChangeHandler(gridName, id)
    {
//        var cell = igtbl_getElementById(id);
//        var row = igtbl_getRowById(id);
//        var kpiID = row.getCellFromKey("KPI_REF_ID").getValue();
//        document.location.href='../usr/usr3001.aspx?eid='+kpiID+'&eid2='+document.form1.ddlMonthInfo.value;
        //document.location.href='http://localhost:8080/MicroBSC/usr/usr3011.jsp?eid='+kpiID;
        //winpopID('svr1002',stgID,'650','300','yes');
    }
// -->
</script>

    

<!--- MAIN START --->	
	
	<table cellpadding="0" cellspacing="2" border="0" width="100%" style="height: 100%;">
		<tr valign="top">
			<td colspan="2" height="20">
	             <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">평가기간<%--<img src="../images/title/se_ti03.gif">--%></td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" Width="100%" class="box01" AutoPostBack="True"></asp:dropdownlist>
                        </td>	
                        <td class="cssTblTitle">측정 월<%--<img src="../images/title/se_ti07.gif">--%></td>
                        <td class="cssTblContent"><asp:dropdownlist id="ddlMonthInfo" runat="server" Width="100%" CssClass="box01"></asp:dropdownlist></td>	
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
                <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr style="height:100%;">
            <td colspan="2">
             <ig:UltraWebGrid ID="ugrdPaReport" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdPaReport_InitializeRow">
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
                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                            FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI_REF_ID">
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="YMD" EditorControlID="" FooterText=""
                            Format="" HeaderText="YMD" Key="YMD" Width="60px" Hidden="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="YMD">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                            Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="60px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI코드">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="280px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI 명">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn HeaderText="결재완료" Key="CONFIRM_YN" BaseColumnName="CONFIRM_YN" Width="60px">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <Header Caption="결재완료">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn EditorControlID="" FooterText="" Format="" HeaderText="작성여부"
                            Key="PA_YN" BaseColumnName="PA_YN" Width="60px">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <Header Caption="작성여부">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" DataType="System.Int32" EditorControlID=""
                            FooterText="" Format="" HeaderText="운영조직ID" Hidden="True" Key="DEPT_REF_ID" Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="운영조직ID">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="운영조직" Key="DEPT_NAME">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="운영조직">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" DataType="System.Int32" EditorControlID=""
                            FooterText="" Format="" HeaderText="CHAMPION_EMP_ID" Hidden="True" Key="CHAMPION_EMP_ID" Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="CHAMPION_EMP_ID">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText=""
                            Format="" HeaderText="KPI담당자" Key="EMP_NAME">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KPI담당자">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="REPORT_DATE" Hidden="false" Key="REPORT_DATE" Width="150px">
                            <Header Caption="작성일자">
                                <RowLayoutColumnInfo OriginX="13" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="13" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                    </RowTemplateStyle>
                </ig:UltraGridBand>
            </Bands>
            <DisplayLayout  CellPaddingDefault="2"
                            AllowColSizingDefault="Free"
                            AllowColumnMovingDefault="OnServer"
                            AllowDeleteDefault="Yes"
                            AllowSortingDefault="Yes"
                            BorderCollapseDefault="Separate"
                            HeaderClickActionDefault="SortMulti"
                            Name="ugrdPaReport"
                            RowHeightDefault="20px"
                            RowSelectorsDefault="No"
                            SelectTypeRowDefault="Extended"
                            Version="4.00"
                            ViewType="Flat"
                            CellClickActionDefault="RowSelect"
                            TableLayout="Fixed"
                            StationaryMargins="Header"
                            AutoGenerateColumns="False"
                            JavaScriptFileName=""
                            JavaScriptFileNameCommon=""
                            OptimizeCSSClassNamesOutput="False">
                    <%--
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                        <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </Style>
                    </Pager>
                    <AddNewBox Hidden="False">
                        <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                    </Style>
                    </AddNewBox>
                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                    </SelectedRowStyleDefault>
                    <ImageUrls  BlankImage=""
                                CollapseImage=""
                                CurrentEditRowImage=""
                                CurrentRowImage=""
                                ExpandImage=""
                                FixedHeaderOffImage=""
                                FixedHeaderOnImage=""
                                GridCornerImage=""
                                GroupByImage=""
                                GroupDownArrow=""
                                GroupUpArrow=""
                                ImageDirectory=""
                                NewRowImage=""
                                RowLabelBlankImage=""
                                SortAscending=""
                                SortDescending=""
                                UnGroupByImage="" />
                                --%>
                    
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    <ClientSideEvents MouseOverHandler="MouseOverHandler" RowSelectorClickHandler="RowSelectorClickHandler" DblClickHandler="UltraWebGrid1_DblClickHandler" AfterSelectChangeHandler="AfterSelectChangeHandler"/>
                </DisplayLayout>
        </ig:UltraWebGrid>
        
        </td>
		</tr>
		</table>
		
                
<!--- MAIN END --->
</asp:Content>