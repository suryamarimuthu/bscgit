<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2500.aspx.cs" Inherits="ctl2500" MasterPageFile="~/_common/lib/MicroBSC.master"  validateRequest="false" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
    var param1;
    function checkSave() {
        if (document.getElementById('<%= txtSCORE_NAME.ClientID %>').value.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '') == '') {
            alert('등급명을 입력하세요!');
            return false;
        }
        if (document.getElementById('<%= txtSCORE_CODE.ClientID %>').value.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '') == '') {
            alert('시그널을 입력하세요!');
            return false;
        }
        if (document.getElementById('<%= txtMIN_VALUE.ClientID %>').value.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '') == '') {
            alert('최소 등급값을 입력하세요!');
            return false;
        }
        if (document.getElementById('<%= txtMAX_VALUE.ClientID %>').value.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '') == '') {
            alert('최대 등급값을 입력하세요!');
            return false;
        }
        return confirm('저장하시겠습니까');
    }
    
    function clearControl() {
        document.getElementById('<%= txtSCORE_NAME.ClientID %>').value = '';
        document.getElementById('<%= txtSCORE_CODE.ClientID %>').value = '';
        document.getElementById('<%= txtMIN_VALUE.ClientID %>').value = '';
        document.getElementById('<%= txtMAX_VALUE.ClientID %>').value = '';
        return false;
    }
    
    function selectChkBox(chkChild) {
        var _elements = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                if (param1) {
                    _elements[i].checked = false;
                }
                else {
                    _elements[i].checked = true;
                }
            }
        }
        param1 = (param1 == true) ? false : true;
    }

    function checkPossibleCopy() {
        var termID1 = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
        var termID2 = document.getElementById("<% =this.ddlEstTermInfo2.ClientID.Replace('_','$') %>").value;

        if (termID1 == termID2) {
            alert('동일한 평가기간을 복사할 수 없습니다.');
            return false;
        }

        var isPossible = '<%= this.IPOSSIBLE_COPY %>';
        if (isPossible.toUpperCase() == 'FALSE') {
            alert('이미 해당평가기간에 등록된 조직상황판 등급이 존재하여 내보낼 수 없습니다!');
            return false;
        }

        return confirm('내보내시겠습니까?');
    }

    function checkDelete() {
        var isSelected = false;
        var ugrd = igtbl_getGridById('<%= UltraWebGrid1.ClientID %>');

        for (var i = 0; i < ugrd.Rows.length; i++) {
            var tRow = ugrd.Rows.getRow(i);
            var e = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
            if (e.checked) {
                isSelected = true;
                break;
            }
        }
        if (!isSelected) {
            alert("삭제할 등급을 선택하세요");
            return false;
        }
        if (confirm("선택한 등급을 삭제하시겠습니까?"))
            return true;
        return false;
    }
</script>

<!--- MAIN START --->
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%; padding-top: 5px;">
    <tr>
        <td valign="top" style="height: 40px;">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td valign="middle" style="height: 20px;">
                        &nbsp;<img align="absMiddle" src="../images/arrow/arrow.gif" alt="" />
                        <b>조직상황 등급관리</b>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
                <tr>
                    <td class="tableTitle" style="width: 100px;" align="center">
                        평가기간
                    </td>
                    <td class="tableContent">
                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" CssClass="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" Width="200px"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                <tr>
                    <td valign="top" style="height: 200px;">
                        <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="100%">
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">                                    
                                    </AddNewRow>
                                    <Columns>
                                        <ig:TemplatedColumn Key="selchk" Width="25px">
                                            <HeaderTemplate>
                                                <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('UltraWebGrid1')" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="center"></CellStyle>
                                            <CellTemplate>
                                                <asp:checkbox id="cBox" runat="server" />
                                            </CellTemplate>
                                        </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="SCORE_NAME" Key="SCORE_NAME" Width="150px" HeaderText="등급명">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle horizontalalign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="SCORE_CODE" Key="SCORE_CODE" Width="150px" HeaderText="시그널">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle horizontalalign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="MIN_VALUE" Key="MIN_VALUE" Width="150px" HeaderText="최소 등급값">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle horizontalalign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="MAX_VALUE" Key="MAX_VALUE" Width="150px" HeaderText="최대 등급값">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle horizontalalign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout CellPaddingDefault="2" 
                                    Version="4.00" 
                                    AllowSortingDefault="No"
                                    AllowColSizingDefault="Free" 
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    BorderCollapseDefault="Separate" 
                                    AllowDeleteDefault="No" 
                                    RowSelectorsDefault="No" 
                                    RowHeightDefault="23px" 
                                    AllowColumnMovingDefault="None" 
                                    SelectTypeRowDefault="Single" 
                                    AutoGenerateColumns="False" 
                                    CellClickActionDefault="RowSelect" 
                                    SelectTypeCellDefault="Single" 
                                    SelectTypeColDefault="Single" 
                                    StationaryMargins="Header" 
                                    StationaryMarginsOutlookGroupBy="True" 
                                    TableLayout="Fixed">
                                <GroupByBox>
                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">                            </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                    Width="100%">                            </FrameStyle>
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
                                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                            </DisplayLayout>
                        </ig:ultrawebgrid>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top" style="height: 100px;">
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 20px;">
                <tr>
                    <td align="left">
                        <asp:imagebutton id="ibtnDelete" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_004.gif" OnClientClick="return checkDelete();" onclick="ibtnDelete_Click"></asp:imagebutton>
                    </td>
                    <td align="right" style="padding-right: 10px;">
                        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                        평가중인 평가대상기간&nbsp;:&nbsp;<asp:dropdownlist ID="ddlEstTermInfo2" runat="server" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo2_SelectedIndexChanged"></ASP:dropdownlist>
                        <asp:imagebutton id="ibtnCopy" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_054.gif" OnClientClick="return checkPossibleCopy();" onclick="ibtnCopy_Click"></asp:imagebutton>
                    </td>
                </tr>
            </table>
            <hr style="border-bottom: 1px solid gray;" />
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
                <colgroup>
                    <col width="100px" align="center" />
                    <col width="200px" />
                    <col width="100px" align="center" />
                    <col width="200px" />
                </colgroup>
                <tr>
                    <td class="tableTitle">
                        등급명
                    </td>
                    <td class="tableContent">
                        <asp:TextBox ID="txtSCORE_NAME" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="tableTitle">
                        시그널
                    </td>
                    <td class="tableContent">
                        <asp:TextBox ID="txtSCORE_CODE" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tableTitle">
                        최소 등급값
                    </td>
                    <td class="tableContent">
                        <asp:TextBox ID="txtMIN_VALUE" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="tableTitle">
                        최대 등급값
                    </td>
                    <td class="tableContent">
                        <asp:TextBox ID="txtMAX_VALUE" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-bottom: 5px; padding-top: 5px;">
                <tr>
                    <td align="right" style="padding-right: 10px; height: 25px;">
                        <asp:imagebutton id="ibtnNew" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_075.gif" OnClientClick="return clearControl();"></asp:imagebutton>
                        <asp:imagebutton id="ibtnSave" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_001.gif" OnClientClick="return checkSave();" onclick="ibtnSave_Click"></asp:imagebutton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<!--- MAIN END --->
</asp:Content>