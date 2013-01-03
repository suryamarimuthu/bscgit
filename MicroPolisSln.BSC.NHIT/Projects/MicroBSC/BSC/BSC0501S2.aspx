<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501S2.aspx.cs" Inherits="BSC_BSC0501S2" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script id="Infragistics" type="text/javascript">
<!--
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
            var cell            = igtbl_getElementById(id);
            var row             = igtbl_getRowById(id);
            var band            = igtbl_getBandById(id);
            var active          = igtbl_getActiveRow(id);
            var termName        = row.getCellFromKey("KPI_NAME").getValue();
            cell.style.cursor   = 'hand';
           
//            var label = igtbl_getElementById("Label2");
//            var parts = id.split("_");
//            if(label && parts.length>=3)
//            label.innerHTML = "Current Row:" + parts[1] + " - Current Column:" + parts[2];
        }
    }
    function ugrdKpiResultList_DblClickHandler(gridName, cellId){
        
        var row        = igtbl_getRowById(cellId);
        var kpiID      = row.getCellFromKey("KPI_REF_ID").getValue();
        var Est_YN     = row.getCellFromKey("CHECK_YN").getValue();
        var Confirm_YN = row.getCellFromKey("CONFIRMSTATUS").getValue();
        var strMM      = row.getCellFromKey("YMD").getValue();
        var intEST     = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var ICCB1      = "<%= this.ICCB1 %>";
        
        var url = 'BSC0501M1.aspx?KPI_REF_ID=' + kpiID+'&YMD='+strMM+'&ESTTERM_REF_ID='+intEST+'&CCB1='+ICCB1;
        
        gfOpenWindow(url
                    ,870
                    ,670
                    ,'no'
                    ,'no'
                    ,'Win5');
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
// -->
</script>
    
<!--- MAIN START --->	
	
	<table cellpadding=0 cellspacing=0 border=0 width=99% height=100%>
	    <tr valign=top>
		    <td width=30%>
		         <table cellpadding=0 cellspacing=0 border=0 width=100% height=100%>
		                    <tr>
			                    <td height="20">
	                                <table border=0 cellpadding=0 cellspacing=0 width=100%>
	                                    <tr>
	                                        <td class="tableoutBorder">
	                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
	                                                <tr>
	                                                    <td width="60" class="tableTitle" align="center">평가기간</td>
                                                        <td style="width:200px;" class="tableContent">
                                                            <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="60%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                                                            <asp:dropdownlist id="ddlEstTermMonth" runat="server" class="box01" width="35%"></asp:dropdownlist>
                                                        </td>
                                                        <td width="60" class="tableTitle" align="center"><%=this.GetText("LBL_00009", "KPI CODE") %></td>
                                                        <td style="width:110px;" class="tableContent">
                                                            <asp:TextBox ID="txtKPICode" runat="server" class="box01" width="100%"></asp:TextBox>
                                                        </td>	
                                                        <td width="60" class="tableTitle" align="center">KPI 명</td>
                                                        <td class="tableContent">
                                                            <asp:TextBox ID="txtKPIName" runat="server" class="box01" width="100%"></asp:TextBox>
                                                        </td>
                                                        <td width="60" class="tableTitle" align="center"><%=this.GetText("LBL_00001", "챔피언") %></td>
                                                        <td class="tableContent" style="width:80px;">
                                                            <asp:TextBox ID="txtChamName" runat="server" class="box01" width="100%"></asp:TextBox>
                                                        </td>	
                                                    </tr>
                                                    <tr>
                                                        <td class="tableTitle" align="center">운영조직</td>
                                                        <td class="tableContent">
                                                            <asp:dropdownlist id="ddlEstDept" runat="server" class="box01" width="97%"></asp:dropdownlist>
                                                        </td>
	                                                    <td class="tableTitle" align="center">지표유형</td>
                                                        <td class="tableContent">
                                                            <asp:dropdownlist id="ddlKpiGroupRefID" runat="server" class="box01" width="100%"></asp:dropdownlist>
                                                        </td>	
	                                                    <td class="tableTitle" align="center">실적방식</td>
                                                        <td class="tableContent">
                                                            <asp:dropdownlist id="ddlResultMethod" runat="server" class="box01" width="100%"></asp:dropdownlist>
                                                        </td>
                                                        <td colspan="2" align="right" bgcolor="white" > 
                                                            <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../images/btn/b_033.gif"
                                                                OnClick="iBtnSearch_Click" />&nbsp</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5px">
                                            </td>
                                        </tr>
                                     </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ig:UltraWebGrid ID="ugrdKpiResultList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiResultList_InitializeRow" >
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
                                                                FooterText="" Format="" HeaderText="KPI 코드" Key="KPI_CODE" Width="50px">
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
                                                            <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="운영조직" Key="OP_DEPT_NAME">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="운영조직">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText=""
                                                                Format="" HeaderText="KPI 명" Key="KPI_NAME" Width="270px">
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
                                                            <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                                                Width="60px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="KPI담당자">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="APPROVAL_EMP_NAME" HeaderText="확정자" Key="APPROVAL_EMP_NAME" Width="70px">
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
                                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="KPI담당자" Key="KPI_GROUP_NAME" Width="80px">
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
                                                            <ig:UltraGridColumn HeaderText="평가대상" Key="CHECK_YN" BaseColumnName="CHECK_YN" Width="33px">
                                                                <Header Caption="평가대상">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <HeaderStyle Wrap="true" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn HeaderText="실적입력" Key="CHECKSTATUS" BaseColumnName="CHECKSTATUS" Width="33px">
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
                                                            <ig:UltraGridColumn HeaderText="확정여부" Key="CONFIRMSTATUS" BaseColumnName="CONFIRMSTATUS" Width="33px">
                                                                <Header Caption="확정여부">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <HeaderStyle Wrap="true" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
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

                                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                        HeaderClickActionDefault="SortMulti" Name="ugrdKpiResultList" RowHeightDefault="20px"
                                                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="OutlookGroupBy" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                        <GroupByBox>
                                                            <Style BackColor="WhiteSmoke" BorderColor="Window"></Style>
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
                                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                                            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                        </HeaderStyleDefault>
                                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                        </EditCellStyleDefault>
                                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" RowSelectorClickHandler="RowSelectorClickHandler" DblClickHandler="ugrdKpiResultList_DblClickHandler"/>
                                                    </DisplayLayout>
                                            </ig:UltraWebGrid>
			                    </td>
		                    </tr>
		                    <tr>
			                    <td height="40" align=right>
                                    <asp:LinkButton ID="lBtnReload" Visible="false" runat="server" OnClick="lBtnReload_Click">Refresh Result Grid</asp:LinkButton>
		                            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                    <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectChkBox(this, 'ugrdKpiResultList')" Text="전체 선택/해제" Visible="False" />
                                    <asp:imagebutton id="iBtnConfirm" imageurl="../images/btn/b_045.gif"  runat="server" OnClick="iBtnConfirm_Click" Visible="False"></asp:imagebutton>
                                    <asp:ImageButton ID="iBtnCancel" runat="server" ImageUrl="../images/btn/b_019.gif" OnClick="iBtnCancel_Click" Visible="False" />
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