<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501S1.aspx.cs" Inherits="BSC_BSC0501S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
<script id="Infragistics" type="text/javascript">
<!--
    function draftBatch() {
        var estterm_ref_id = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
        var ICCB1 = "<%= this.ICCB1 %>";

        var url = "BSC0501M4.aspx?IS_TEAM_KPI=Y&CCB1=" + ICCB1;

        gfOpenWindow(url, 810, 645, 'yes', 'no', 'BSC0501M4');
        return false;
    }
    
    function ugrdKpiResultList_DblClickHandler(gridName, cellId){
        
        var row        = igtbl_getRowById(cellId);
        var kpiID      = row.getCellFromKey("KPI_REF_ID").getValue();
        var strMM      = row.getCellFromKey("YMD").getValue();
        var intEST     = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var ICCB1      = "<%= this.ICCB1 %>";
        
        var url = 'BSC0501M1.aspx?KPI_REF_ID=' + kpiID+'&YMD='+strMM+'&ESTTERM_REF_ID='+intEST+'&CCB1='+ICCB1;
        /* 2011-08-17 수정 : KPI의 ID가 다른 경우 새로운 창이 열리도록 수정
        gfOpenWindow(url
                    ,870
                    ,690
                    ,'no'
                    ,'no'
                    ,'Win5'); */
        gfOpenWindow(url
                    , 880
                    , 640
                    , 'no'
                    , 'no'
                    , 'BSC0501M1' + kpiID);
    }

    function doPoppingUp_ResultList(kpiID, strMM, intEST, ICCB1) {

        var url = 'BSC0501M1.aspx?KPI_REF_ID=' + kpiID
                              + '&YMD=' + strMM
                              + '&ESTTERM_REF_ID=' + intEST 
                              + '&CCB1=' + ICCB1;
        /* 2011-08-17 수정 : KPI의 ID가 다른 경우 새로운 창이 열리도록 수정
        gfOpenWindow(url
        ,870
        ,690
        ,'no'
        ,'no'
        ,'Win5'); */
        gfOpenWindow(url
                    , 880
                    , 640
                    , 'no'
                    , 'no'
                    , 'BSC0501M1' + kpiID);
    }
    
    
    
    function selectChkBox(chkAll, chkChild)
        {
            var param1      = chkAll.checked;
            var _elements   = document.forms[0].elements;
 
            for (var i = 0; i < _elements.length; i++)
            {
                if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
                {
                    if (param1 == false)
                        _elements[i].checked = false;
                    else
                        _elements[i].checked = true;
                }
            }
        }
-->
</script>
    
<!--- MAIN START --->	
	
	<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
	    <tr valign="top">
		    <td width="30%">
		         <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
		                    <tr>
			                    <td height="20">
	                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
	                                    <tr>
	                                        <td>
	                                            <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
	                                                <tr>
	                                                    <td class="cssTblTitle">평가기간</td>
                                                        <td class="cssTblContent">
                                                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="65%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" />
                                                            <asp:dropdownlist id="ddlEstTermMonth" runat="server" class="box01" width="34%"></asp:dropdownlist>
                                                        </td>
                                                        <td class="cssTblTitle">실적방식</td>
                                                        <td class="cssTblContent" style="border-right:none;">
                                                            <asp:dropdownlist id="ddlResultMethod" runat="server" class="box01" width="100%"></asp:dropdownlist>
                                                        </td>
                                                        <!--
                                                        <td class="cssTblTitle"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                                        <td class="cssTblContent">
                                                            <asp:TextBox ID="txtKPICode" runat="server" class="box01" width="100%"></asp:TextBox>
                                                        </td>	
                                                        -->
                                                    </tr>
                                                    <tr>
                                                        <td class="cssTblTitle">KPI 명</td>
                                                        <td class="cssTblContent">
                                                            <asp:TextBox ID="txtKPIName" runat="server" class="box01" width="100%"></asp:TextBox>
                                                        </td>
                                                        <td class="cssTblTitle"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                                        <td class="cssTblContent">
                                                            <asp:TextBox ID="txtChamName" runat="server" class="box01" width="100%"></asp:TextBox>
                                                        </td>	
                                                    </tr>
                                                    <tr>
                                                        <td class="cssTblTitle">운영조직</td>
                                                        <td class="cssTblContent">
                                                            <asp:dropdownlist id="ddlEstDept" runat="server" class="box01" width="100%"></asp:dropdownlist>
                                                        </td>
	                                                    <td class="cssTblTitle">지표유형</td>
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
                            <tr class="cssPopBtnLine">
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                                <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                                <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                            </td>
                                            <td align="right"> 
                                                <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ig:UltraWebGrid ID="ugrdKpiResultList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiResultList_InitializeRow" OnInitializeLayout="ugrdKpiResultList_InitializeLayout" >
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:TemplatedColumn Hidden="True" Key="selchk" Width="30px">
                                                                <CellTemplate>
                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="view_name" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="관점" Key="view_name" Width="100px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="관점">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="stg_name" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="전략" Key="stg_name" Width="130px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="전략">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="250px">
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
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn HeaderText="입력대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="60px">
                                                                <Header Caption="입력대상">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <HeaderStyle Wrap="true" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn HeaderText="당월목표" Key="TARGET_MS" BaseColumnName="TARGET_MS" Width="100px"  Format="#,##0.00" Hidden="true" >
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn> 
                                                            <ig:UltraGridColumn HeaderText="당월실적" Key="RESULT_MS" BaseColumnName="RESULT_MS" Width="100px"  Format="#,##0.00" Hidden="true" >
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Center"/>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn HeaderText="경영목표" Key="TARGET_TS" BaseColumnName="TARGET_TS" Width="100px"  Format="#,##0.00" >
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn> 
                                                            <ig:UltraGridColumn HeaderText="의지목표" Key="TARGET_TS_G" BaseColumnName="TARGET_TS_G" Width="100px"  Format="#,##0.00" >
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn> 
                                                            <ig:UltraGridColumn HeaderText="실적" Key="RESULT_TS" BaseColumnName="RESULT_TS" Width="100px"  Format="#,##0.00" >
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Center"/>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
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
                                                            <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" Width="60px" DataType="System.Int32">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="가중치">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
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
                                                             <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="평가조직" Key="EST_DEPT_NAME" Width="130px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="평가조직">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="130px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="운영조직">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI 담당자" Key="CHAMPION_EMP_NAME"
                                                                Width="170px">
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
                                                            
                                                            
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="전략ID" Hidden="True" Key="KPI_REF_ID">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="전략ID">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" DataType="System.Int16" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="75px" Hidden="True">
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
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="운영 부서" Hidden="True"
                                                                Key="DEPT_NAME">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="운영 부서">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="APPROVAL_EMP_NAME" HeaderText="확정자" Key="APPROVAL_EMP_NAME" Width="60px" Hidden="true">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="확정자">
                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="10" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI담당자" Key="KPI_GROUP_NAME" Width="90px" Hidden="True">
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
                                                                FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="70px" Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="실적방식">
                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="11" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn HeaderText="실적입력" Key="CHECKSTATUS" BaseColumnName="CHECKSTATUS" Width="60px" Hidden="True">
                                                                <Header Caption="실적입력">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <HeaderStyle Wrap="true" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
<%--                                                            <ig:UltraGridColumn HeaderText="확정여부" Key="CONFIRMSTATUS" BaseColumnName="CONFIRMSTATUS" Width="33px">
                                                                <Header Caption="확정여부">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <HeaderStyle Wrap="true" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>--%>
                                                           
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="관리부서ID" Hidden="True" Key="DEPT_REF_ID">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="관리부서ID">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="12" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="UNIT_TYPE" HeaderText="단위" Hidden="True" Key="UNIT_TYPE"
                                                                Width="60px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="단위">
                                                                    <RowLayoutColumnInfo OriginX="15" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="15" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="RESULT_MEASUREMENT_STEP_NAME" HeaderText="측정단계" Key="RESULT_MEASUREMENT_STEP_NAME"
                                                                Width="60px" Hidden="true">
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
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                <Header>
                                                                    <RowLayoutColumnInfo OriginX="18" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="18" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                <Header>
                                                                    <RowLayoutColumnInfo OriginX="19" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="19" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="YMD" Hidden="true" Key="YMD">
                                                                <Header>
                                                                    <RowLayoutColumnInfo OriginX="19" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="19" />
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
                                    Name="ugrdKpiResultList" 
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
                        <ClientSideEvents RowSelectorClickHandler="RowSelectorClickHandler" DblClickHandler="ugrdKpiResultList_DblClickHandler"/>
                    </DisplayLayout>
                                               
                                            </ig:UltraWebGrid>
			                    </td>
		                    </tr>
		                    <tr>
			                    <td height="25">
			                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
			                            <tr>
			                                <td>
			                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>                                                        
                                                        <td align="right" style="padding-right: 5px;">
                                                            <asp:ImageButton runat="server" ID="ibtnDraftBatch" ImageUrl="../images/btn/btn_draft_batch.gif" ImageAlign="AbsMiddle" OnClientClick="return draftBatch();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left">
                                                <asp:LinkButton ID="lBtnReload" Visible="false" runat="server" OnClick="lBtnReload_Click">Refresh Result Grid</asp:LinkButton>
		                                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                                <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectChkBox(this, 'ugrdKpiResultList')" Text="전체 선택/해제" Visible="False" />
                                                <asp:imagebutton id="iBtnConfirm" imageurl="../images/btn/b_045.gif"  runat="server" OnClick="iBtnConfirm_Click" Visible="False"></asp:imagebutton>
                                                <asp:ImageButton ID="iBtnCancel" runat="server" ImageUrl="../images/btn/b_019.gif" OnClick="iBtnCancel_Click" Visible="False" />
			                                </td>
			                            </tr>
			                        </table>
			                    </td>
		                    </tr>
		                <!--tr>
			                <td align=right height=20>
			                <a href="javascript:winpoplink('svr4010.aspx',790,600,'no');"><img src="../images/btn/b_020.gif" border=0 class="imgbtn" id="IMG1" /></a>&nbsp;
			                </td>
		                </tr-->
		                </table>
                </td>
            </tr>
    </table>
<!--- MAIN END --->
</asp:Content>