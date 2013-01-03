<%@ Page Language="C#" AutoEventWireup="true" CodeFile="com1000.aspx.cs" Inherits="base_com1000" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>

<script id="Infragistics" type="text/javascript">
<!--
function ugrdKpiResultList_MouseOverHandler(gridName, id, objectType)
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

function showEmailForm()
{
    var intEST = form1.ddlEstTermInfo.options[form1.ddlEstTermInfo.selectedIndex].value;        
    var intMM  = form1.ddlMonthInfo.options[form1.ddlMonthInfo.selectedIndex].value;        
    //window.open('com1001.aspx?eid=' + intEST+'&tmcode='+intMM, 'WinPop11','width=500, height=580'); 
    var url     = 'com1001.aspx?eid=' + intEST+'&tmcode='+intMM;

    gfOpenWindow(url,500,580,'no','no','com1000');
}
// -->
</script>
    
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<form id="form1" runat="server">
<div>
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td class="tableoutBorder">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td class="tableTitle" width="80" style="width: 100px">
                        평가기간</td>
                    <td class="tableContent" colspan="3">
                        <asp:dropdownlist id="ddlEstTermInfo" runat="server" class="box01" width="100%" meta:resourcekey="ddlEstTermInfoResource1"></asp:dropdownlist>
                    </td>
                    <td class="tableTitle" align="center">계획월</td>
                    <td style="background-color:White" colspan="5">&nbsp;<asp:dropdownlist id="ddlMonthInfo" runat="server" class="box01" meta:resourcekey="ddlMonthInfoResource1" OnSelectedIndexChanged="ddlMonthInfo_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist></td>
                </tr>
                <tr>
                    <td class="tableTitle" style="width: 100px">총&nbsp;KPI수</td>
                    <td class="tableContent">&nbsp;<asp:label id="lblTotKpi" runat="server" Width="70px"></asp:label></td>
                    <td class="tableTitle" style="width: 110px">
                        측정대상<br />
                        KPI수</td>
                    <td class="tableContent" colspan="" rowspan="">&nbsp;<asp:label id="lblEstKpi" runat="server" Width="70px"></asp:label></td>
                    <td class="tableTitle" colspan="" rowspan="" style="width: 110px">
                        실적확정<br />
                        KPI수</td>
                    <td class="tableContent">&nbsp;<asp:label id="lblCfmKpi" runat="server" Width="70px"></asp:label></td>
                    <td class="tableTitle" style="width: 95px;" align="center">측정율</td>
                    <td class="tableContent"><asp:label id="lblEstRate" runat="server" Width="70px"></asp:label></td>
                    <td class="tableTitle" style="width: 95px" rowspan="" align="center">확정율</td>
                    <td class="tableContent"><asp:label id="lblCfmRate" runat="server" Width="70px"></asp:label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="overflow-y: scroll; overflow-x: hidden; height: expression(eval(document.body.clientHeight)-230)">
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
                            <ig:UltraGridColumn BaseColumnName="APPROVAL_EMP_NAME" HeaderText="확정자" Key="APPROVAL_EMP_NAME" Width="75px">
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
                                Width="60px">
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
                    <ClientSideEvents RowSelectorClickHandler="RowSelectorClickHandler" DblClickHandler="ugrdKpiResultList_DblClickHandler"/>
                    </DisplayLayout>
            </ig:UltraWebGrid>
        </td>
    </tr>
    <tr>
        <td height="40" align="right">
            &nbsp;<asp:literal id="ltlMsg" runat="server" meta:resourcekey="ltlMsgResource1"></asp:literal>
            <asp:imagebutton id="iBtnSearch" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_033.gif"
                            onclick="iBtnSearch_Click" meta:resourcekey="iBtnSearchResource1" Enabled="False" Visible="False"></asp:imagebutton>&nbsp;&nbsp;
            <a href='#null' onclick="showEmailForm();"><img alt="" style="vertical-align:inherit" src="../images/btn/b_051.gif" border=0 /></a> 
             &nbsp;&nbsp;
        </td>
    </tr>
</table>


<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder></div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
