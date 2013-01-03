<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4303.aspx.cs" Inherits="ctl_ctl4303" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<script type="text/javascript">
    function checkPossibleCopy() {
        var termID1 = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
        var termID2 = document.getElementById("<% =this.ddlEstTermInfo2.ClientID.Replace('_','$') %>").value;

        if (termID1 == termID2) {
            alert('동일한 평가기간을 복사할 수 없습니다.');
            return false;
        }

        var isPossible = '<%= this.IPOSSIBLE_COPY %>';
        if (isPossible.toUpperCase() == 'FALSE') {
            alert('이미 해당평가기간에 등록된 지표그룹이 존재하여 내보낼 수 없습니다!');
            return false;
        }

        return confirm('내보내시겠습니까?');
    }

    function DoBinding() {
        var ugrd = igtbl_getGridById('<%= ugrdGroupList.ClientID %>');
        var selectedRow = igtbl_getActiveRow(ugrd.Id);
        if (selectedRow != null) {
            document.getElementById('<%= txtGROUP_CODE.ClientID %>').value = selectedRow.getCellFromKey("GROUP_CODE").getValue();
            document.getElementById('<%= txtGROUP_NAME.ClientID %>').value = selectedRow.getCellFromKey("GROUP_NAME").getValue();
        }
    }

    function InitControl() {
        document.getElementById('<%= txtGROUP_CODE.ClientID %>').value = '';
        document.getElementById('<%= txtGROUP_NAME.ClientID %>').value = '';
        return false;
    }

    function checkDelete() {
        var tCode = document.getElementById('<%= txtGROUP_CODE.ClientID %>').value;

        if (tCode == '') {
            alert('삭제할 그룹을 선택하세요!');
            return false;
        }
        return confirm('삭제하시겠습니까?');
    }
    
    function checkSave() {
        var tCode = document.getElementById('<%= txtGROUP_CODE.ClientID %>').value;
        var tName = document.getElementById('<%= txtGROUP_NAME.ClientID %>').value;

        if (tName == '') {
            alert('그룹 명칭을 입력하세요!');
            return false;
        }
        if (tCode == '')
            return confirm('저장하시겠습니까?');
        else
            return confirm('수정하시겠습니까?');
    }
</script>

<!--- MAIN START --->        
<table cellpadding="0" cellspacing="2" border="0"  style="width:100%; height:100%;" >
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td style="width:15px;">
                        <img src="../images/title/ma_t14.gif" alt="" />
                    </td>
                    <td>
                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="그룹 등록" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
                <tr>
                    <td class="cssTblTitle" >
                        평가기간
                    </td>
                    <td class="cssTblContent" style="border-right:none;">
                        <asp:dropdownlist id="ddlEstTermInfo" CssClass="box01" runat="server" width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                    </td>
                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                    <td class="cssTblContent">&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:100%;">
        <td>
            <ig:UltraWebGrid ID="ugrdGroupList" runat="server" Width="100%" Height="100%">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="GROUP_CODE" HeaderText="그룹코드" Key="GROUP_CODE" Width="100px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="GROUP_NAME" HeaderText="그룹명" Key="GROUP_NAME" Width="300px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
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
                    OptimizeCSSClassNamesOutput="False">
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
                    <ClientSideEvents CellClickHandler="DoBinding" />
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                </DisplayLayout>
            </ig:UltraWebGrid>       
        </td>
    </tr>
    <tr style="padding-top: 5px;">
        <td>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td style="width:15px;">
                                    <img src="../images/title/ma_t14.gif" alt="" />
                                </td>
                                <td>
                                    <asp:Label id="Label1" runat="server" style="font-weight:bold" text="그룹 등록" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right">
                        평가대상기간&nbsp;<asp:dropdownlist id="ddlEstTermInfo2" CssClass="box01" runat="server" width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo2_SelectedIndexChanged"></asp:dropdownlist>
                        &nbsp;<asp:ImageButton ID="ibtnCopy" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_054.gif" OnClientClick="return checkPossibleCopy();" onclick="ibtnCopy_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder">
                <tr>
                    <td class="cssTblTitle" align="center" style="width: 100px;">
                        지표그룹 코드
                    </td>
                    <td class="cssTblContent">
                        <asp:TextBox ID="txtGROUP_CODE" runat="server" Width="100%" BackColor="WhiteSmoke"></asp:TextBox>
                    </td>
                    <td class="cssTblTitle" align="center">
                        지표그룹 명칭
                    </td>
                    <td class="cssTblContent">
                        <asp:TextBox ID="txtGROUP_NAME" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
	<tr class="cssPopBtnLine">
        <td>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="ibtnNew" runat="server" ImageUrl="../images/btn/b_156.gif" OnClientClick="return InitControl();" />
                        <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClientClick="return checkSave();" OnClick="ibtnSave_Click" />
                        <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClientClick="return checkDelete();" OnClick="ibtnDelete_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table> 
<asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
<!--- MAIN END --->
</asp:Content>