<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST030100.aspx.cs" Inherits="EST_EST030100"
    ValidateRequest="false" %>

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript">

    function FocusCtrl() {
        if (document.forms[0].txtQObjName.value == "")
            document.forms[0].txtQObjName.focus();
        else
            document.forms[0].txtQObjName.select();
    }

    function chkOK() {
        var f = document.forms[0];

        if (f.rblMode_0.checked) {
            if (confirm('신규로 등록하시겠습니까?')) {
                if (document.getElementById('hdfSearchEstID').value == "") {
                    alert('평가를 선택하세요.');
                    return false;
                }

                if (f.txtQObjName.value == '') {
                    alert('질의그룹명을 입력하세요.');
                    f.txtQObjName.focus();
                    return false;
                }

                return true;
            }
        }
        else {
            if (confirm('수정하시겠습니까?')) {
                if (document.getElementById('hdfSearchEstID').value == "") {
                    alert('평가를 선택하세요.');
                    return false;
                }

                if (f.txtQObjID.value == '') {
                    alert('질의그룹을 선택해 주세요.');
                    f.txtQObjName.select();
                    return false;
                }

                if (f.txtQObjName.value == '') {
                    alert('질의그룹명을 입력하세요.');
                    f.txtQObjName.select();
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
            if (f.hdfEstID.value == '') {
                alert('평가명을 선택해 주세요.');
                f.txtEstName.select();
                return false;
            }

            if (f.txtQObjID.value == '') {
                alert('질의그룹을 선택해 주세요.');
                f.txtQObjName.select();
                return false;
            }

            return true;
        }

        return false;
    }

    function chkRBtn() {
        var f = document.forms[0];

        if (f.rblMode_0.checked) {
            f.hdfEstID.value = '';
            f.txtEstName.value = '';
            f.txtQObjID.value = '';
            f.hdfQObjID.value = '';
            f.txtQObjName.value = '';
            f.txtQObjTitle.value = '';
            f.txtQObjPreface.value = '';

            document.getElementById("btnDelete").disabled = true;
            //f.btnDelete.disabled = true;

            f.txtQObjID.disabled = false;
        }
        else {
            f.txtQObjID.disabled = true;

            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
        }

        f.txtQObjName.select();
    }

    function GetQuestionObjects(est_id, est_name, id, name, title, preface) {
        var f = document.forms[0];

        f.rblMode_1.checked = true;

        document.getElementById("btnDelete").disabled = false;
        //f.btnDelete.disabled = false;

        f.txtQObjID.disabled = true;

        f.hdfEstID.value = est_id;
        f.txtEstName.value = est_name;
        f.txtQObjID.value = id;
        f.hdfQObjID.value = id;
        f.txtQObjName.value = name;
        f.txtQObjTitle.value = title;

        var tmp = "";
        for (var i = 0; i < preface.length; i++) {
            if (preface.charCodeAt(i) == 160)
                tmp += " "
            else
                tmp += preface.charAt(i);
        }
        preface = tmp;


        f.txtQObjPreface.value = preface;

        f.txtQObjName.select();
    }

    function ShowEstID(ctrl_value_name, ctrl_text_name, ctrl_value_value) {
        gfOpenWindow("EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
		                        + "&CTRL_VALUE_NAME=" + ctrl_value_name
                                + "&CTRL_TEXT_NAME=" + ctrl_text_name
                                + "&CHECKBOX_YN=" + "Y"
                                + "&CTRL_VALUE_VALUE=" + ctrl_value_value
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_est_scheId");
        return false;
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

    function ViewQPage() {
        if (document.getElementById('hdfSearchEstID').value == "") {
            alert('평가를 선택하세요.');
            return false;
        }

        if (document.getElementById("hdfQObjID").value == "") {
            alert('선택된 질의그룹이 없습니다.');
            return false;
        }

        if (document.getElementById("hdfQStylePageName").value == "") {
            alert('설정된 질의 페이지가가 없습니다.');
            return false;
        }

        gfOpenWindow(document.getElementById("hdfQStylePageName").value + '?COMP_ID=<%=COMP_ID%>'
                                                                        + '&EST_ID=' + document.getElementById('hdfSearchEstID').value
                                                                        + '&Q_OBJ_ID=' + document.getElementById("hdfQObjID").value
                                                                        + '&READ_ONLY_YN=' + 'Y'
                                                                        , 700
                                                                        , 600
                                                                        , 'yes'
                                                                        , 'no');
        return false;
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
                        <img src="../images/title/ma_t05.gif" />
                    </td>
                    <td align="right">
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                        <asp:dropdownlist id="ddlCompID" runat="server" autopostback="True" class="box01"
                            onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                        <asp:literal runat="server" id="ltrCopyGroup"></asp:literal>
                        <a href="#null" onclick="return ViewQPage();">
                            <img src="../images/btn/b_164.gif" border="0" /></a> &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="height:100%;">
        <td style="vertical-align: top;">
            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                        </RowTemplateStyle>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" Key="Q_OBJ_ID" Hidden="True">
                            </ig:UltraGridColumn>
                            <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No">
                                <CellTemplate>
                                    <asp:checkbox id="cBox" runat="server" />
                                </CellTemplate>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <HeaderTemplate>
                                    <asp:checkbox id="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" HeaderText="평가질의그룹명" Key="Q_OBJ_NAME"
                                Width="300px">
                                <Header Caption="평가질의그룹명">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_TITLE" HeaderText="평가질의그룹 타이틀" Key="Q_OBJ_TITLE"
                                Width="300px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="평가질의그룹 타이틀">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_PREFACE" HeaderText="Q_OBJ_PREFACE" Key="Q_OBJ_PREFACE"
                                Width="100px" Hidden="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="Q_OBJ_PREFACE">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="LAYOUT_TYPE" HeaderText="LAYOUT_TYPE" Key="LAYOUT_TYPE"
                                Hidden="True">
                                <Header Caption="LAYOUT_TYPE">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer"
                    AllowDeleteDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti"
                    Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                    Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                    AutoGenerateColumns="False">
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
                    <RowStyleDefault CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                    </SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                    </RowAlternateStyleDefault>
                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                    </HeaderStyleDefault>
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                    </FrameStyle>
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder">
                <tr>
                    <td class="cssTblTitleSingle">
                        평가 선택
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px" width="200px"></asp:textbox>
                        <a href="#null" onclick="SearchEstID();"><img src="../images/btn/b_143.gif" border="0" align="absmiddle" /></a>
                        <asp:imagebutton id="ibnSearch" runat="server" height="19px" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click" imagealign="AbsMiddle"></asp:imagebutton>
                        <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        맵핑되는 평가
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtEstName" runat="server" bordercolor="Silver" borderwidth="1px" width="200px" backcolor="#F3F3F3" readonly="True"></asp:textbox>
                        <a href="#null" onclick="ShowEstID('hdfEstID', 'txtEstName', document.forms[0].hdfEstID.value);"><img src="../images/btn/b_094.gif" border="0" align="absmiddle" /></a>
                        <asp:hiddenfield id="hdfEstID" runat="server"></asp:hiddenfield>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의평가그룹명
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtQObjName" runat="server" bordercolor="Silver" borderwidth="1px" width="200px"></asp:textbox>
                        <asp:textbox id="txtQObjID" runat="server" width="0px" bordercolor="Silver" borderwidth="0px" backcolor="White" maxlength="10"></asp:textbox>                        
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의평가그룹 타이틀
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtQObjTitle" runat="server" borderwidth="1px" bordercolor="Silver"
                            width="100%"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitleSingle">
                        질의평가그룹 머릿말
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtQObjPreface" runat="server" borderwidth="1px" bordercolor="Silver"
                            width="100%" height="60px" textmode="MultiLine"></asp:textbox>
                    </td>
                </tr>
            </table>
            <table runat="server" id="tbSetup" style="width: 100%" class="cssPopBtnLine">
                <tr>
                    <td width="50%" align="left">
                        <asp:imagebutton id="ibnCopyQObj" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_171.gif" onclick="ibnCopyQObj_Click"></asp:imagebutton>
                    </td>
                    <td align="right">
                        <asp:imagebutton id="btnNew" runat="server" onclick="btnNew_Click" imageurl="../images/btn/b_016.gif"></asp:imagebutton>
                        <asp:imagebutton id="btnDelete" runat="server" enabled="False" onclick="btnDelete_Click" imageurl="../images/btn/b_004.gif"></asp:imagebutton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:hiddenfield id="hdfQStylePageName" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfQObjID" runat="server"></asp:hiddenfield>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:linkbutton id="lbnReload" runat="server" onclick="lbnReload_Click"></asp:linkbutton>
<!--- MAIN END --->
<asp:placeholder runat="server" id="phdBottom"></asp:placeholder>
</form>
<% Response.WriteFile("../_common/html/CommonBottom.htm");%>