<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110401.ASPX.cs" Inherits="EST_EST110401" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script type="text/javascript">
    function confirmTran(objID) {
        if (objID == '1')
            return confirm('Bias 조정점수 계산을 실행하시겠습니까?');
        else if (objID == '2')
            return confirm('선택한 점수로 Bias점수를 적용하시겠습니까?');
        else if (objID == '3')
            return confirm('Bias 조정점수를 확정하시겠습니까?');
        return false;
    }
    
    function biasSet(objID) {
        if (objID == '1') {
            gfOpenWindow("../resources/BiasManager.aspx?NAME=BIAS_AVG_METHOD&CCB1=<%= ICCB1 %>"
                               , 500
                               , 300
                               , false
                               , false
                               , "popup_est_bias_setup");
        }
        else {
            gfOpenWindow("../resources/BiasManager.aspx?NAME=BIAS_STD_METHOD&CCB1=<%= ICCB1 %>"
                               , 500
                               , 300
                               , false
                               , false
                               , "popup_est_bias_setup");
        }
    }
</script>
<form id="form1" runat="server">
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="2" border="0" width="100%" style="height: 100%;">
        <tr>
	        <td>
	            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tableBorder">
	                <tr>
	                    <td class="cssTblTitle">
	                        평가기간
	                    </td>
	                    <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" autopostback="True" onselectedindexchanged="ddlEstTermRefID_SelectedIndexChanged" class="box01" width="33%" 
                            /><asp:dropdownlist id="ddlEstTermSubID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermSubID_SelectedIndexChanged" width="33%" 
                            /><asp:dropdownlist id="ddlEstTermStepID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlEstTermStepID_SelectedIndexChanged" width="32%" Visible="False" />
                        </td>
                        <td class="cssTblTitle">
                            평가그룹
                        </td>
                        <td class="cssTblContent">
                            <asp:DropDownList id="ddlGroup" runat="server" autopostback="True" cssClass="box01" onselectedindexchanged="ddlGroup_SelectedIndexChanged" width="100%"></asp:DropDownList>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
	                </tr>
	            </table>
            </td>
        </tr>
        <tr>
            <td style="height: 100%;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                    <tr>
                        <td style="padding-right: 5px;" align="left">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="Bias 계산실행 및 확정" />
                                    </td>
                                    <td align="right">
                                        <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 100%;">
                            <ig:UltraWebGrid ID="ugrdBias" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdBias_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" 
                                    AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="None" 
                                    AllowDeleteDefault="No"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="ugrdBias" 
                                    RowHeightDefault="20px" 
                                    HeaderStyleDefault-Height="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    OptimizeCSSClassNamesOutput="False">
                                    <%--<GroupByBox>
                                        <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
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
                                    </SelectedRowStyleDefault>
                                    <ClientSideEvents />--%>
                                    
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
                    <tr>
                        <td style="height: 25px;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:imagebutton id="ibtnCalc" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_187.gif" CommandArgument="JOB_04" onclick="ibtnCalc_Click" onclientclick="return confirmTran('1');"></asp:imagebutton>
                                        &nbsp;&nbsp;<asp:DropDownList id="ddlPointType" runat="server" cssClass="box01"></asp:DropDownList>
                                        <asp:imagebutton id="ibtnInsert" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_186.gif" CommandArgument="JOB_04" onclick="ibtnInsert_Click" onclientclick="return confirmTran('2');"></asp:imagebutton>
                                        <asp:imagebutton id="ibtnConfirm" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_185.gif" CommandArgument="JOB_04" onclick="ibtnConfirm_Click" onclientclick="return confirmTran('3');" visible="false"></asp:imagebutton>
                                        <asp:imagebutton id="ibtnDownload" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif" onclick="ibtnDownload_Click"></asp:imagebutton>
                                        <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport">
                                        </ig:UltraWebGridExcelExporter>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-bottom: 10px;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder" style="height: 40px;">
                                <tr>
                                    <td style="width: 55px;">
                                        <img id="ibtnSetCalc1" runat="server" src="~/images/btn/b_007.gif" onclick="biasSet('1')" style="cursor: pointer;" />
                                    </td>
                                    <td class="tableTitle" style="width: 140px;">
                                        평균조정 산식
                                    </td>
                                    <td class="tableContent">
                                        <asp:Label id="lblCalc1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img id="ibtnSetCalc2" runat="server" src="~/images/btn/b_007.gif" onclick="biasSet('2')" style="cursor: pointer;" />
                                    </td>
                                    <td class="tableTitle">
                                        평균.표준편차조정 산식
                                    </td>
                                    <td class="tableContent">
                                        <asp:Label id="lblCalc2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
	        </td>
        </tr>
    </table>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    <asp:linkbutton id="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:linkbutton>
    <!--- MAIN END --->
    <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>