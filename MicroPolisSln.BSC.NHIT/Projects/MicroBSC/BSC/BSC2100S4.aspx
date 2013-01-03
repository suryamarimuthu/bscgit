<%@ Page Title="" Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC2100S4.aspx.cs" Inherits="BSC_BSC2100S4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contents" Runat="Server">
<script type="text/javascript">
    function MappingDept() {
        gfOpenWindow("BSC2100M1.aspx?COMP_ID=1"
                                + "&ESTTERM_REF_ID=<%=IEstTermRefID %>"
                                + "&POSTBACK_CTRL_NAME=" + "<%=lbnDeptReload.ClientID %>"
                                + "&POOL=" + document.getElementById("<%=hdkpipool.ClientID %>").value
                                + "&STG=" + document.getElementById("<%=hdkpistg.ClientID %>").value
                                + "&VIEW=" + document.getElementById("<%=hdkpiview.ClientID %>").value
                               , 700
                               , 400
                               , false
                               , false
                               , "popup_dept_mapping");
        return false;
    }
</script>
 <table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:100%;" >
 <tr>
    <td>
        <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
            <tr>
                <td class="cssTblTitle">
                    평가기간
                </td>
                <td class="cssTblContent">
                    <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01"  width="100%" />
                </td>
                <td class="cssTblTitle">
                    KPI 명
                </td>
                <td class="cssTblContent">
                    <asp:TextBox ID="txtKpiName" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </table>
    </td>
 </tr>
  <tr class="cssPopBtnLine">
    <td>
        <asp:ImageButton ID="ibnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" onclick="ibnSearch_Click" />
    </td>
</tr>
<tr style="height: 100%">
    <td>
        <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
        <tr style="height:18px;">
            <td style="width:50%;" >
                <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="KPI 풀 목록"/></td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;&nbsp;</td>
            <td style="width:50%;" >
                <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="조직KPI 생성 부서(KPI담당자)"/></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Height="90%" Width="100%" OnSelectedRowsChange="ugrdKpiList_SelectedRowsChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" HeaderText="KPI명" Key="KPI_NAME" Width="300px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI명">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CNT" HeaderText="KPI배포 부서수" Key="KPI_CNT" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI배포 부서수">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn> 
                                <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" HeaderText="KPI_POOL_REF_ID" Hidden="True" Key="KPI_POOL_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STG_REF_ID" HeaderText="STG_REF_ID" Hidden="True" Key="STG_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="VIEW_REF_ID" HeaderText="VIEW_REF_ID" Hidden="True" Key="VIEW_REF_ID">
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer"
                                    TableLayout="Fixed"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    SelectTypeRowDefault="Extended" 
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px" 
                                    Version="4.00" 
                                    AutoGenerateColumns="False" 
                                    CellClickActionDefault="RowSelect" 
                                    OptimizeCSSClassNamesOutput="False"
                                    RowSelectorsDefault="No">
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        <Images>
                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                        </Images>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
            <td>&nbsp;&nbsp;</td>
            <td>
                <ig:UltraWebGrid ID="ugrdKpiDept" runat="server" Height="100%" Width="100%" style="left: 181px; top: 18px">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" Style="cursor: pointer" runat="server" onclick="selectChkBox(this,'ugrdKpiDept');" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                                    </CellTemplate>
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="운영조직" Key="DEPT_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="운영조직" Title="">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="KPI담당자" Key="EMP_NAME" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="담당자" Title="">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" HeaderText="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID"  Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI_POOL_REF_ID" Title="">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Key="KPI_REF_ID" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="KPI_REF_ID" Title="">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdClose" RowHeightDefault="18px" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    AutoGenerateColumns="False" 
                                    CellClickActionDefault="RowSelect" 
                                    RowSelectorsDefault="No"
                                    OptimizeCSSClassNamesOutput="False" 
                                    JavaScriptFileName="" 
                                    JavaScriptFileNameCommon="">
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                        <Images>
                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                        </Images>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr class="cssPopBtnLine">
    <td>
        <table cellpadding="0" cellspacing="0" border="0"  style="width:100%;" >
        <tr>
             <td style="text-align:right;">
               <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../images/btn/b_004.gif" ImageAlign="AbsMiddle" OnClick="btnDelete_Click" />
               <input type="button" value="일괄생성" id="btnCreate" onclick="MappingDept();" />
             </td>
        </tr>
        </table>
    </td>
</tr>
 </table>
  <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
  <asp:hiddenfield id="hdfEstDept" runat="server"></asp:hiddenfield>
  <asp:hiddenfield id="hdkpipool" runat="server" Value="0"></asp:hiddenfield>
  <asp:hiddenfield id="hdkpiview" runat="server" Value="0"></asp:hiddenfield>
  <asp:hiddenfield id="hdkpistg" runat="server" Value="0"></asp:hiddenfield>
  <asp:linkbutton id="lbnDeptReload" runat="server" onclick="lbnDeptReload_Click"></asp:linkbutton>
</asp:Content>

