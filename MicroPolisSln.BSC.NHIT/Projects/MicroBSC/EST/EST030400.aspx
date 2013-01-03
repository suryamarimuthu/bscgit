<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST030400.aspx.cs" Inherits="EST_EST030400"
    ValidateRequest="false" %>

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript" src="../_common/js/DropDownLib.js"></script>

<script type="text/javascript">

    function FocusCtrl() {
        if (document.forms[0].txtQSbjName.value == "")
            document.forms[0].txtQSbjName.focus();
        else
            document.forms[0].txtQSbjName.select();
    }

    function chkOK() {
        var f = document.forms[0];

        if (f.rblMode_0.checked) {
            if (confirm('신규로 등록하시겠습니까?')) {
                if (f.txtDfnName.value == '') {
                    alert('질의정의명을 입력하세요.');
                    f.txtDfnName.focus();
                    return false;
                }

                return true;
            }
        }
        else {
            if (confirm('수정하시겠습니까?')) {
                if (f.txtDfnName.value == '') {
                    alert('질의정의명을 입력하세요.');
                    f.txtDfnName.focus();
                    return false;
                }

                return true;
            }
        }

        return false;
    }

    function chkDelete() {
        var f = document.forms[0];

        if (confirm('삭제하시겠습니까?')) {

            if (f.txtDfnName.value == '') {
                alert('질의정의명을 선택해주세요.');
                f.txtDfnName.focus();
                return false;
            }

            return true;
        }

        return false;
    }

    function chkRBtn() {
        var f = document.forms[0];

        if (f.rblMode_0.checked) {
            f.hdfDfnID.value = '';
            f.txtDfnID.value = '';
            f.txtDfnName.value = '';
            f.txtDfnDefine.value = '';
            f.txtDfnNotice.value = '';
            f.txtDfnDesc.value = '';
            f.txtNum.value = '';
            //		f.txtSearchEstName.value    = '';
            //		f.hdfSearchEstID.value      = '';
            f.txtDfnID.disabled = false;

            document.getElementById("btnDelete").disabled = true;
            //f.btnDelete.disabled = true;
        }
        else {
            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
            f.txtDfnID.disabled = true;
        }

        f.txtDfnName.select();
    }

    function GetSurveyGroups(est_id
                        , dfn_id
                        , dfn_name
                        , dfn_define
                        , dfn_notice
                        , dfn_desc
                        , num
                        , est_name) {
        var f = document.forms[0];


        if (!f.rblMode_0.checked) {
            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
            f.txtDfnID.disabled = false;
        }
        else {
            f.rblMode_1.checked = true;
            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
            f.txtDfnID.disabled = true;
        }

        f.hdfDfnID.value = dfn_id;
        f.txtDfnID.value = dfn_id;
        f.txtDfnName.value = dfn_name;
        f.txtDfnDefine.value = ReplaceAbnormalSpace(dfn_define);
        f.txtDfnNotice.value = ReplaceAbnormalSpace(dfn_notice);
        f.txtDfnDesc.value = ReplaceAbnormalSpace(dfn_desc);
        f.txtNum.value = num;
        f.hdfSearchEstID.value = est_id;
        f.txtSearchEstName.value = est_name;

        f.txtDfnName.select();
    }

    function SearchEstID() {
        gfOpenWindow("EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
	                        + "&CTRL_VALUE_NAME=" + "hdfSearchEstID"
                            + "&CTRL_TEXT_NAME=" + "txtSearchEstName"
                            + "&CHECKBOX_YN=" + "N"
                            + "&CTRL_VALUE_VALUE=" + ""
                           , 430
                           , 400
                           , false
                           , false
                           , "popup_est_scheId");
        //return false;
    }

    function Search() {
        if (document.getElementById('hdfSearchEstID').value == "") {
            alert('평가를 선택하세요.');
            return false;
        }

        return true;
    }

    function ReplaceAbnormalSpace(srcStr) {
        var rtnStr = "";
        for (var i = 0; i < srcStr.length; i++) {
            if (srcStr.charCodeAt(i) == 160)
                rtnStr += " "
            else
                rtnStr += srcStr.charAt(i);
        }
        return rtnStr;
    }
</script>

<form id="form1" runat="server">
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
<asp:placeholder runat="server" id="phdLayout"></asp:placeholder>
<!--- MAIN START --->
<table cellspacing="0" cellpadding="0" border="0" height="100%">
    <tr>
        <td valign="top" align="center" width="100%">
            <table id="Table2" style="border-collapse: collapse" bordercolor="#c7c6c6" cellspacing="0"
                cellpadding="2" width="100%" align="center" border="0">
                <tr>
                    <td style="font-weight: bold; color: #006699" width="200">
                        <img src="../images/title/ma_t07.gif" />
                    </td>
                    <td align="right">
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True"
                            onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                        &nbsp;
                        <asp:literal runat="server" id="ltrCopyGroup"></asp:literal>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:100%;">
        <td style="vertical-align: top;">
            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                Style="left: 0px">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                        </RowTemplateStyle>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="Q_DFN_ID" HeaderText="질의정의ID" Key="Q_DFN_ID"
                                Hidden="True">
                                <Header Caption="질의정의ID">
                                </Header>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="NUM" Key="NUM" Width="60px">
                                <Header Caption="번호">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_DFN_NAME" Key="Q_DFN_NAME" Width="100px">
                                <Header Caption="질의정의명">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_DFN_NOTICE" Key="Q_DFN_NOTICE" Width="150px">
                                <Header Caption="질의정의 제목">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_DFN_DEFINE" Key="Q_DFN_DEFINE" Width="150px">
                                <Header Caption="정의">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_DFN_DESC" Key="Q_DFN_DESC" Width="200px">
                                <Header Caption="질의정의 설명">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
                                <Header Caption="EST_ID">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_NAME" Key="EST_NAME" Hidden="True">
                                <Header Caption="EST_NAME">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer"
                    AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect"
                    TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False" OptimizeCSSClassNamesOutput="False">
                    <%--<GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                        </BoxStyle>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center"
                        BorderColor="#E5E5E5" ForeColor="White">
                        <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                    </FrameStyle>
                    <Pager>
                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </PagerStyle>
                    </Pager>
                    <AddNewBox Hidden="False">
                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </BoxStyle>
                    </AddNewBox>
                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                    </SelectedRowStyleDefault>
                    <ActivationObject BorderColor="" BorderWidth="">
                    </ActivationObject>--%>
                    
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
        <td align="center">
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:radiobuttonlist id="rblMode" runat="server" width="200px" height="22px" repeatlayout="Flow"
                            repeatdirection="Horizontal"><asp:ListItem Selected="True" Value="0">신규</asp:ListItem><asp:ListItem Value="1">수정</asp:ListItem></asp:radiobuttonlist>
                    </td>
                </tr>
            </table>
            <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
                <tr>
                    <td class="cssTblTitleSingle">
                        평가 선택
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px"
                            width="120px"></asp:textbox>
                        <a href="#null" onclick="SearchEstID();">
                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" /></a>
                        <asp:imagebutton id="ibnSearch" runat="server" height="19px" imageurl="~/images/btn/b_033.gif"
                            onclick="ibnSearch_Click" imagealign="AbsMiddle"></asp:imagebutton>
                        <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의정의명
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtDfnID" runat="server" width="1px" bordercolor="Silver" borderwidth="1px"
                            backcolor="White" maxlength="10"></asp:textbox>
                        <asp:textbox id="txtDfnName" runat="server" bordercolor="Silver" borderwidth="1px"
                            width="97%"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의정의제목
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtDfnNotice" runat="server" bordercolor="Silver" borderwidth="1px"
                            height="28px" textmode="MultiLine" width="100%"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의정의
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtDfnDefine" runat="server" bordercolor="Silver" borderwidth="1px"
                            height="27px" textmode="MultiLine" width="100%"></asp:textbox>
                    </td>
                </tr>
                <tr runat="server">
                    <td class="cssTblTitleSingle">
                        질의정의번호
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtNum" runat="server" bordercolor="Silver" borderwidth="1px" width="120px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의정의설명
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtDfnDesc" runat="server" borderwidth="1px" bordercolor="Silver"
                            width="100%" height="27px" textmode="MultiLine"></asp:textbox>
                    </td>
                </tr>
            </table>
            <table runat="server" id="tbSetup" style="width: 100%; text-align: right">
                <tr class="cssPopBtnLine">
                    <td>
                        <asp:imagebutton id="btnNew" runat="server" onclick="btnNew_Click" imageurl="../images/btn/b_016.gif"></asp:imagebutton>
                        <asp:imagebutton id="btnDelete" runat="server" enabled="False" onclick="btnDelete_Click"
                            imageurl="../images/btn/b_004.gif"></asp:imagebutton>
                    </td>
                </tr>
            </table>
            <asp:linkbutton id="lbnReload" runat="server" onclick="lbnReload_Click"></asp:linkbutton>
            <asp:literal id="ltrScript" runat="server"></asp:literal>
            <asp:hiddenfield id="hdfDfnID" runat="server"></asp:hiddenfield>
        </td>
    </tr>
</table>
<!--- MAIN END --->
<asp:placeholder runat="server" id="phdBottom"></asp:placeholder>
</form>
<%
    Response.WriteFile("../_common/html/CommonBottom.htm");
%>