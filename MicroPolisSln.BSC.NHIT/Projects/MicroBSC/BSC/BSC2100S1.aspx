<%@ Page Title="" Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC2100S1.aspx.cs" Inherits="BSC_BSC3001S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contents" Runat="Server">
<script type="text/javascript">
    function openDeptEmp() {

        var estterm_ref_id = "<%= IEstTermRefID %>";
        var strKeyObj = "<%=hdfChampionEmpId.ClientID %>";
        var strValObj = "<%=txtChampionEmpName.ClientID %>";
        var url = "../ctl/ctl2106.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&OBJ_KEY=" + strKeyObj + "&OBJ_VAL=" + strValObj;

        gfOpenWindow(url, 750, 400, 'yes', 'no', 'bsc2100s1');
    }
    function Validation() {
        var emp = document.getElementById("<%=hdfChampionEmpId.ClientID %>").value;
        if (emp == "") {alert("사원을 선택하세요.");return false;}
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
        <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdKpiList_InitializeRow">
        <Bands>
        <ig:UltraGridBand>
        <Columns>
            <ig:TemplatedColumn Key="selchk" Width="30px">
                <HeaderTemplate>
                    <asp:CheckBox ID="cBox_header" Style="cursor: pointer" runat="server" onclick="selectChkBox(this,'ugrdKpiList');" />
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <CellTemplate>
                    <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                </CellTemplate>
                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                </CellStyle>
            </ig:TemplatedColumn>
            <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" Key="KPI_POOL_REF_ID" HeaderText="KPI 코드" Width="80px" Hidden="true"></ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" HeaderText="KPI 명" Width="300px">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="KPI_CNT" Key="KPI_CNT" HeaderText="KPI 수" Width="80px">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TARGET_SUB_EMP_NAME" Key="TARGET_SUB_EMP" HeaderText="목표관리 담당자" Width="150px">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_SUB_EMP_NAME" Key="RESULT_SUB_EMP" HeaderText="실적관리 담당자" Width="150px">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="TARGET_WRITE" Key="TARGET_WRITE" HeaderText="목표입력" Width="100px">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
            <ig:UltraGridColumn BaseColumnName="RESULT_WRITE" Key="RESULT_WRITE" HeaderText="실적입력" Width="100px">
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </ig:UltraGridColumn>
        </Columns>
        </ig:UltraGridBand>
        </Bands>
        <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
            HeaderClickActionDefault="NotSet" Name="ugrdGroupList" RowHeightDefault="20px"
            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
            ReadOnly="LevelTwo">
            <RowStyleDefault  CssClass="GridRowStyle" />
            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
        </DisplayLayout>
        </ig:UltraWebGrid>
    </td>
</tr>
<tr class="cssPopBtnLine">
    <td>
        <table cellpadding="0" cellspacing="0" border="0"  style="width:100%;" >
        <tr>
            <td align="left" style="width:230px">
                <asp:RadioButtonList runat="server" ID="rdoTarget" RepeatDirection="Horizontal">
                <asp:ListItem Text="목표입력담당자" Value="0" Selected></asp:ListItem>
                <asp:ListItem Text="실적입력담당자" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
             </td>
             <td>
                <asp:TextBox ID="txtChampionEmpName" runat="server" BorderWidth="0" ReadOnly="true" Width="150px"></asp:TextBox>
               <img alt="" id="ibtnChampion" runat="server" src="../images/btn/b_008.gif" style="vertical-align:inherit; cursor:hand;" onclick="openDeptEmp();" />
               <asp:HiddenField ID="hdfChampionEmpId" runat="server" />
               <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../images/btn/b_tp07.gif" OnClick="btnSave_Click" OnClientClick="return Validation();" />
             </td>
                
        </tr>
        </table>
    </td>
</tr>
 </table>
 <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>


