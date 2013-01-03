<%@ Page Title="" Language="C#" MasterPageFile="~/_common/libNHIT/MicroBSC.master" AutoEventWireup="true" CodeFile="BSC2100S2.aspx.cs" Inherits="BSC_BSC2100S2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contents" Runat="Server">
<script id="Infragistics" type="text/javascript">
    function onDraft() {
        var kpi_ref_id = "";
        var ugrd = igtbl_getGridById('<%=ugrdKpiResultList.ClientID %>');

        for (var i = 0; i < ugrd.Rows.length; i++) {
            var tRow = ugrd.Rows.getRow(i);
            var colId = tRow.getCellFromKey("selchk").Id;
            var ck = $("#" + colId + " input:checkbox:checked");
            if (ck.length > 0) {
                kpi_ref_id += tRow.getCellFromKey("KPI_REF_ID").getValue() + ",";
            }
        }

        if (kpi_ref_id == "") {
            alert('일괄결재할 KPI를 선택하세요!');
            return false;
        }
        var estterm_ref_id = "<%=IESTTERM_REF_ID %>";
        var biz_type = "<%= Biz_Type.biz_type_kpi_docbatch %>";

        kpi_ref_id = kpi_ref_id.substring(0, kpi_ref_id.length - 1);
        var app_ccb = "<%= lBtnReload2.ClientID.Replace('_', '$') %>";
        var url = "BSC0901M3.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id + "&APP_CCB=" + app_ccb + "&BIZ_TYPE=" + biz_type;
        gfOpenWindow(url, 900, 680, 'BSC0901M3'); // 728

        return false;
    }

</script>
<script type="text/javascript">
    function openDeptEmp(type) {
        var estterm_ref_id = "";
        var strKeyObj = "";
        var strValObj = "";
        var url = "";
        if (type == 0) {
            estterm_ref_id = "<%= IESTTERM_REF_ID %>";
            strKeyObj = "<%=hdfChampionEmpId0.ClientID %>";
            strValObj = "<%=txtChampionEmpName0.ClientID %>";
            url = "../ctl/ctl2106.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&OBJ_KEY=" + strKeyObj + "&OBJ_VAL=" + strValObj;
        }
        else {
            estterm_ref_id = "<%= IESTTERM_REF_ID %>";
            strKeyObj = "<%=hdfChampionEmpId.ClientID %>";
            strValObj = "<%=txtChampionEmpName.ClientID %>";
            url = "../ctl/ctl2106.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&OBJ_KEY=" + strKeyObj + "&OBJ_VAL=" + strValObj;
        }
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'bsc2100s1');
    }

    function AllGoalInsertValidation() {
//        var thisMonth = document.getElementById("<%=txtThis.ClientID %>").value;
//        var allAdd = document.getElementById("<%=txtFill.ClientID %>").value;
//        if (thisMonth == "") {
//            alert("당월목표를 입력하세요.");return false;
//        }
//        if (allAdd == "") {
//            alert("누적목표를 입력하세요."); return false;
//        }
    }
    
    
</script>

<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
<tr>
    <td>
        <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList ID="ddlEstTermInfo" runat="server" class="box01" Width="59%" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" />
                            <asp:DropDownList ID="ddlEstTermMonth" runat="server" class="box01" Width="39%">
                            </asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            KPI 명
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtKPIName" runat="server" class="box01" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            <%=this.GetText("LBL_00001", "KPI 담당자") %>
                        </td>
                        <td class="cssTblContent">
                            <asp:TextBox ID="txtChampionEmpName0" runat="server" BorderWidth="0" ReadOnly="true" Width="200px"></asp:TextBox>
                           <img alt="" id="ibtnChampion0" runat="server" src="../images/btn/b_008.gif" style="vertical-align:inherit; cursor:hand;" onclick="openDeptEmp(0);" />
                           <asp:HiddenField ID="hdfChampionEmpId0" runat="server" />
                        </td>
                        <td class="cssTblTitle">
                            목표일괄입력담당자
                        </td>
                        <td class="cssTblContent">
                           <asp:TextBox ID="txtChampionEmpName" runat="server" BorderWidth="0" ReadOnly="true" Width="200px"></asp:TextBox>
                           <img alt="" id="ibtnChampion" runat="server" src="../images/btn/b_008.gif" style="vertical-align:inherit; cursor:hand;" onclick="openDeptEmp(1);" />
                           <asp:HiddenField ID="hdfChampionEmpId" runat="server" />
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
        <ig:UltraWebGrid ID="ugrdKpiResultList" runat="server" Width="100%" Height="100%"
            OnInitializeRow="ugrdKpiResultList_InitializeRow" OnInitializeLayout="ugrdKpiResultList_InitializeLayout">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <Columns>
                           <ig:TemplatedColumn Key="selchk" Width="30px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="cBox_header" Style="cursor: pointer" runat="server" onclick="selectChkBox(this,'ugrdKpiResultList');" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <CellTemplate>
                                <asp:CheckBox ID="cBox" runat="server" Style="cursor: pointer" />
                            </CellTemplate>
                            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                            </CellStyle>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI풀" Key="KPI_REF_ID" Width="100px" Hidden="true">
                            <HeaderStyle HorizontalAlign="Center" />
                        </ig:UltraGridColumn>
                        <ig:TemplatedColumn BaseColumnName="KPI_NAME" HeaderText="KPI 명" Key="KPI_NAME" Width="250px" AllowUpdate="No">
                            <HeaderStyle HorizontalAlign="Center" />
                        </ig:TemplatedColumn>  
                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="운영조직" Key="DEPT_NAME" Width="200px"  AllowUpdate="No">
                            <HeaderStyle HorizontalAlign="Center" />
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="KPIEMP" HeaderText="KPI담당자" Key="KPIEMP"  AllowUpdate="No"
                            Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ALLEMP" HeaderText="목표 일괄 입력 담당자" Key="ALLEMP"  AllowUpdate="No"
                            Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="UNIT" HeaderText="단위" Key="UNIT" Width="80px"  AllowUpdate="No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </ig:UltraGridColumn>
                         <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Width="60px" HeaderText="결재상태"  AllowUpdate="No">
                            <HeaderStyle Wrap="True" HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <CellTemplate>
                                <asp:Image runat="server" ID="imgApp" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                </asp:Image>
                            </CellTemplate>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn HeaderText="당월목표" Key="TARGET_MS" BaseColumnName="TARGET_MS" Width="100px"  Format="#,##0.00" Type="Custom" DataType="System.Double">
                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn HeaderText="누적목표" Key="TARGET_TS" BaseColumnName="TARGET_TS" Width="100px"  Format="#,##0.00" Type="Custom" DataType="System.Double">
                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Right">
                            </CellStyle>
                        </ig:UltraGridColumn>

                         
                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" DataType="System.Int16" HeaderText="KPI 코드"
                            Key="KPI_CODE" Width="75px" Hidden="true">
                            <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" DataType="System.Int32"
                            Key="ESTTERM_REF_ID">
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Hidden="True" DataType="System.Int32"
                            Key="KPI_REF_ID">
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="YMD" Hidden="true" Key="YMD">
                        </ig:UltraGridColumn>
                    </Columns>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                    </RowTemplateStyle>
                </ig:UltraGridBand>
            </Bands>
            <DisplayLayout CellPaddingDefault="2" 
                                                                                       Version="4.00"
                                                                                       AllowColSizingDefault="Free" 
                                                                                       AllowUpdateDefault="Yes" 
                                                                                       AutoGenerateColumns="False" 
                                                                                       HeaderClickActionDefault="NotSet" 
                                                                                       Name="ugrdSignal" 
                                                                                       BorderCollapseDefault="Separate" 
                                                                                       RowSelectorsDefault="No" 
                                                                                       ScrollBarView="Vertical" 
                                                                                       RowHeightDefault="20px" 
                                                                                       JavaScriptFileName="" 
                                                                                       JavaScriptFileNameCommon="" 
                                                                                       OptimizeCSSClassNamesOutput="False"
                                                                                       TabDirection="TopToBottom"
                                                                                       CellClickActionDefault="Edit">
                                                                            
                                                                             <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                                                            <ClientSideEvents   />
                                                                        </DisplayLayout>
          
        </ig:UltraWebGrid>
    </td>
</tr>
<tr class="cssPopBtnLine">
    <td>
        <table cellpadding="0" cellspacing="0" border="0"  style="width:100%;" >
        <tr>
            <td align="center">
                당월/누적
                <asp:TextBox runat="server" ID="txtThis" Width="50px"></asp:TextBox>/
                <asp:TextBox runat="server" ID="txtFill" Width="50px"></asp:TextBox>
                <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../images/btn/b_tp07.gif" OnClick="btnSave_Click" OnClientClick="return AllGoalInsertValidation();" ImageAlign="AbsMiddle" />
                <img src="../images/btn/btn_draft_batch.gif" onclick="onDraft();" style="cursor:pointer; vertical-align:top;" /> 
             </td>
                
        </tr>
        </table>
    </td>
</tr>
</table>
 <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
  <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
<asp:linkbutton id="lBtnReload2" runat="server" OnClick="lBtnReload2_Click"></asp:linkbutton>
</asp:Content>


