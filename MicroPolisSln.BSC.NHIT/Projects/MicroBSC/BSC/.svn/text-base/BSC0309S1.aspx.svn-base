<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0309S1.aspx.cs" Inherits="BSC_BSC0309S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>
<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
    function checkboxCnt(elemId) {
        var eqtID = "<%=this.txtEqtValue.ClientID %>";
        var eqlID = "<%=this.txtEqlValue.ClientID %>";

        var eqtValue = document.getElementById(eqtID).value * 1;
        var eqlValue = document.getElementById(eqlID).value * 1;

        //alert(eqtValue + ", " + eqlValue);
        if (doChecking(elemId)) {
            if (eqtValue + eqlValue == 0) {
                alert("정량평가, 정성평가 중 하나는 0보다 큰 값이어야 합니다.");
                return false;
            }
                
            return true;
        }

        return false;
    }

    function chkSrchCondition() {
        var dept_ref_id = document.getElementById("<%=this.hdfDept_Ref_Id.ClientID %>").value;
        //alert(dept_ref_id);
        if (trim(dept_ref_id).length == 0) {
            alert("부서 선택 후 조회하세요.");
            return false;
        }

        var champion_emp_ref_id = document.getElementById("<%=this.hdfChampion_Emp_Ref_Id.ClientID %>").value;
        //alert(champion_emp_ref_id);
        if (trim(champion_emp_ref_id).length == 0) {
            alert("KPI담장자 선택 후 조회하세요.");
            return false;
        }

        return true;
    }

    function openDeptEmp(strKeyObj, strValObj) {
        var estterm_ref_id = document.getElementById("<%=this.ddlEstTermRefID.ClientID %>").value;
        var dept_ref_id = document.getElementById("<%=this.hdfDept_Ref_Id.ClientID %>").value;

        if (trim(dept_ref_id).length == 0) {
            alert("부서 선택 후 조회하세요.");
            return;
        }
        
        var url = "../ctl/ctl2106.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&OBJ_KEY=" + strKeyObj + "&OBJ_VAL=" + strValObj + "&DEPT_ID=" + dept_ref_id;

        gfOpenWindow(url, 750, 400, 'yes', 'no', 'ctl2106');
    }


    var param1 = true;
    function selectChkBox(chkChild) {
        var _elements = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                if (!_elements[i].disabled) {
                    if (param1 == false) {
                        _elements[i].checked = false;
                    }
                    else {
                        _elements[i].checked = true;
                    }
                }
            }
        }

        if (param1) {
            param1 = false;
        }
        else {
            param1 = true;
        }
    }
</script>
        
    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:100%;" >
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" />
                            <asp:label id="lblCompTitle" runat="server" visible="false" />
                            
                            <asp:dropdownlist id="ddlEstTermRefID" CssClass="box01" runat="server" width="100%" />
                        </td>
                        <td class="cssTblTitle">
                            평가유형
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstType" CssClass="box01" runat="server" width="100%" >
                                <asp:ListItem Selected="True" Value="EQT">정량평가</asp:ListItem>
                                <asp:ListItem Value="EQL">정성평가</asp:ListItem>
                            </asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            부서
                        </td>
                        <td class="cssTblContent">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDept_Name" runat="server" Width="100%"></asp:TextBox>
                                        <asp:HiddenField ID="hdfDept_Ref_Id" runat="server" Value="" />
                                    </td>
                                    <td style="width:65px;" align="right">
                                        <a href="javascript:gfOpenWindow('../ctl/ctl2102.aspx?DEPT_ID=<%=this.hdfDept_Ref_Id.ClientID %>&DEPT_NAME=<%=this.txtDept_Name.ClientID %>', 310, 400);">
                                            <img src="../images/btn/b_033.gif" id="imgDeptSearch" border="0" align="middle"/>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="cssTblTitle">
                            KPI 담당자
                        </td>
                        <td class="cssTblContent">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtChampion_Emp_Name" runat="server" Width="100%"></asp:TextBox>
                                        <asp:HiddenField ID="hdfChampion_Emp_Ref_Id" runat="server" Value="" />
                                    </td>
                                    <td style="width:85px;" align="right">
                                        <a href="javascript:openDeptEmp('<%=this.hdfChampion_Emp_Ref_Id.ClientID %>','<%=this.txtChampion_Emp_Name.ClientID %>');">
                                            <img alt="" src="../images/btn/b_008.gif" style="cursor:hand;"  />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            KPI 구분
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlIsTeamKpi" CssClass="box01" runat="server" width="100%" >
                                <asp:ListItem Selected="True" Value="Y">조직 KPI</asp:ListItem>
                                <asp:ListItem Value="N">개인 KPI</asp:ListItem>
                            </asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">
                            KPI 명
                        </td>
                        <td class="cssTblContent">
                            <!--<asp:TextBox ID="txtKpiCode" runat="server" Width="100%" />-->
                            <asp:TextBox ID="txtKpiName" runat="server" Width="100%" />
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
                <ig:UltraWebGrid ID="ugrdKpiList" runat="server" Width="100%" Height="100%">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:TemplatedColumn BaseColumnName="selchk" Key="selchk" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderTemplate>
                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox('ugrdKpiList')" />
                                    </HeaderTemplate>
                                    <CellTemplate>
                                       <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer; "/> 
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" HeaderText="KPI 코드" Width="80px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" HeaderText="KPI 명" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="KPI_DESC" Key="KPI_DESC" HeaderText="KPI 설명" Width="260px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IS_TEAM_KPI" Key="IS_TEAM_KPI" HeaderText="KPI 구분" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_ID" Key="CHAMPION_EMP_ID" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" HeaderText="주관부서" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" HeaderText="KPI 담당자" Width="170px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EQT" Key="EQT" HeaderText="정량평가" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EQL" Key="EQL" HeaderText="정성평가" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="NotSet" Name="ugrdGroupList" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False"
                        ReadOnly="LevelTwo">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
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
                        </SelectedRowStyleDefault>--%>
                        
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
                        <td align="left" style="width:60px;">
                            정량:정성
                        </td>
                        <td style="width:120px">
                            <ig:webnumericedit id="txtEqtValue" runat="server" Width="50px" MinDecimalPlaces="None" 
                                   NullText="0" Font-Names="Verdana" Font-Size="10pt" NegativeForeColor="Magenta" 
                                   ToolTip="정량평가" MinValue="0" MaxValue="100" 
                                   ValueText="0" Nullable="False" SpinWrap="true">
                            </ig:webnumericedit>
                            :
                            <ig:webnumericedit id="txtEqlValue" runat="server" Width="50px" MinDecimalPlaces="None" 
                                   NullText="0" Font-Names="Verdana" Font-Size="10pt" NegativeForeColor="Magenta" 
                                   ToolTip="정성평가" MinValue="0" MaxValue="100" 
                                   ValueText="0" Nullable="False" SpinWrap="true">
                            </ig:webnumericedit>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="ibnAllSave" runat="server" 
                                ImageUrl="../images/btn/b_tp07.gif" 
                                OnClientClick="return checkboxCnt('ugrdKpiList')" onclick="ibnAllSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table> 
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    <!--- MAIN END --->
</asp:Content>