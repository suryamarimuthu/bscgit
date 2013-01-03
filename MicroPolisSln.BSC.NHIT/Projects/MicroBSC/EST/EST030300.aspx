<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST030300.aspx.cs" Inherits="EST_EST030300"
    ValidateRequest="False" EnableEventValidation="false" %>

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
                if (f.ddlQObjID.value == '') {
                    alert('질의평가그룹을 선택해 주세요.');
                    f.ddlQObjID.focus();
                    return false;
                }

                if (f.ddlQSbjID.value == '') {
                    alert('질의평가를 선택해 주세요.');
                    f.ddlQSbjID.focus();
                    return false;
                }

                if (f.txtQItmName.value == '') {
                    alert('질의항목명을 입력하세요.');
                    f.txtQItmName.focus();
                    return false;
                }

                f.B.value = f.ddlQSbjID.value;

                return true;
            }
        }
        else {
            if (confirm('수정하시겠습니까?')) {
                if (f.ddlQObjID.value == '') {
                    alert('질의평가그룹을 선택해 주세요.');
                    f.ddlQObjID.focus();
                    return false;
                }

                if (f.ddlQSbjID.value == '') {
                    alert('질의평가를 선택해 주세요.');
                    f.ddlQSbjID.focus();
                    return false;
                }

                if (f.txtQItmName.value == '') {
                    alert('질의항목명을 입력하세요.');
                    f.txtQItmName.focus();
                    return false;
                }

                f.B.value = f.ddlQSbjID.value;

                return true;
            }
        }

        return false;
    }

    function chkDelete() {
        var f = document.forms[0];

        if (confirm('삭제하시겠습니까?')) {
            if (f.txtQItmName.value == '') {
                alert('질의항목을 선택해주세요.');
                f.txtQItmName.focus();
                return false;
            }

            f.B.value = f.ddlQSbjID.value;

            return true;
        }

        return false;
    }

    function chkRBtn() {
        var f = document.forms[0];

        if (f.rblMode_0.checked) {
            f.txtQItmID.value = '';
            f.hdfQSbjID.value = '';
            f.txtQItmName.value = '';
            f.txtNum.value = '';
            f.txtPoint.value = '';
            f.txtComment.value = '';
            f.hdfQDfnID.value = '';
            //f.rblSubjectItemYN_0.checked    = true;

            document.getElementById("btnDelete").disabled = true;
            //f.btnDelete.disabled = true;

        }
        else {
            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
        }

        f.txtQItmName.select();
    }

    function GetQuestionSubjects(sbj_id, obj_id) {
        var f = document.forms[0];

        if (f.rblMode_1.checked)
            f.rblMode_0.checked = true;

        document.getElementById("btnDelete").disabled = true;
        //f.btnDelete.disabled = true;

        GetDataSet('GetDataSet.aspx', 'ddlQSbjID', 'Q_SBJ_NAME', 'Q_SBJ_ID', 'Survey', 'B', obj_id);

        f.txtQItmID.value = '';
        f.ddlQObjID.value = obj_id;
        f.hdfQSbjID.value = sbj_id;
        f.ddlQSbjID.value = sbj_id;
        f.txtNum.value = '';
        f.txtQItmName.value = '';
        f.hdfQDfnID.value = '';

        f.txtPoint.value = '';
        f.txtComment.value = '';

        //f.rblSubjectItemYN_0.checked = true;

        f.txtQItmName.select();
    }

    function GetQuestionItems(itm_id, sbj_id, num, item_name, point, comment, subject_item_yn, obj_id) {
        var f = document.forms[0];

        if (!f.rblMode_0.checked) {
            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
            //f.rblSubjectItemYN_0.checked    = true;
        }
        else {
            f.rblMode_1.checked = true;
            document.getElementById("btnDelete").disabled = false;
            //f.btnDelete.disabled = false;
        }

        GetDataSet('GetDataSet.aspx', 'ddlQSbjID', 'Q_SBJ_NAME', 'Q_SBJ_ID', 'Survey', 'B', obj_id);

        f.txtQItmID.value = itm_id;
        f.ddlQObjID.value = obj_id;
        f.hdfQSbjID.value = sbj_id;
        f.ddlQSbjID.value = sbj_id;
        f.txtNum.value = num;
        f.txtQItmName.value = item_name;

        f.txtPoint.value = point;
        f.txtComment.value = ReplaceAbnormalSpace(comment);

        //	    if(subject_item_yn == "0")
        //           f.rblSubjectItemYN_0.checked = true;
        //        else 
        //           f.rblSubjectItemYN_1.checked = true;

        f.txtQItmName.select();
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

    function SearchQObjID() {
        if (document.getElementById('hdfSearchEstID').value == "") {
            alert('평가를 선택하세요.');
            return false;
        }

        if (document.getElementById('ddlQObjID').value == "") {
            alert('질의그룹을 선택하세요.');
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
                        <asp:dropdownlist id="ddlCompID" runat="server" autopostback="True" class="box01"
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
            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                        </RowTemplateStyle>
                        <Columns>
                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" Hidden="True" Key="Q_OBJ_ID">
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_ID" Hidden="True" Key="Q_SBJ_ID">
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_ITM_ID" Hidden="True" Key="Q_ITM_ID">
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" HeaderText="질의그룹명" Key="Q_OBJ_NAME"
                                MergeCells="True" Width="150">
                                <Header Caption="질의그룹명">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_NAME" HeaderText="질의문항명" Key="Q_SBJ_NAME"
                                MergeCells="True" Width="150">
                                <Header Caption="질의문항명">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="NUM" HeaderText="번호" Key="NUM" Width="80px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="항목번호">
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_ITEM_NAME" HeaderText="질의항목명" Key="Q_ITEM_NAME"
                                Width="150">
                                <Header Caption="질의항목명">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="POINT" HeaderText="점수" Key="POINT" Width="60">
                                <Header Caption="점수">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <CellStyle HorizontalAlign="Right">
                                </CellStyle>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="COMMENT" HeaderText="설명" Key="COMMENT" Width="200">
                                <Header Caption="설명">
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="SUBJECT_ITEM_YN" HeaderText="SUBJECT_ITEM_YN"
                                Hidden="True" Key="SUBJECT_ITEM_YN">
                                <Header Caption="SUBJECT_ITEM_YN">
                                    <RowLayoutColumnInfo OriginX="9" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="9" />
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
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px"
                            width="120px"></asp:textbox>
                        <a href="#null" onclick="SearchEstID();">
                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" class="box01" /></a>
                        <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle"
                            imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click" class="box01"></asp:imagebutton>
                        <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                    </td>
                </tr>
                <tr>
                    <TD class="cssTblTitleSingle">
                        질의평가그룹
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:dropdownlist id="ddlQObjID" runat="server" class="box01" width="120px"></asp:dropdownlist>
                        <asp:imagebutton id="ibnSearchQObjID" runat="server" height="19px" imagealign="AbsMiddle"
                            imageurl="~/images/btn/b_033.gif" onclick="ibnSearchQObjID_Click" class="box01"></asp:imagebutton>
                    </td>
                </tr>
                <tr>
                    <TD class="cssTblTitleSingle">
                        질의
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:dropdownlist id="ddlQSbjID" runat="server" class="box01" width="120px"></asp:dropdownlist>
                        <input id="B" runat="server" name="Hidden1" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <TD class="cssTblTitleSingle">
                        질의항목명
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtQItmName" runat="server" bordercolor="Silver" borderwidth="1px"
                            width="99%"></asp:textbox>
                        <asp:textbox id="txtQItmID" runat="server" width="0px" bordercolor="Silver" borderwidth="0px"
                            backcolor="White" maxlength="10"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <TD class="cssTblTitleSingle">
                        질의항목번호
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtNum" runat="server" bordercolor="Silver" borderwidth="1px" width="120px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <TD class="cssTblTitleSingle">
                        질문항목값(점수)
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtPoint" runat="server" backcolor="White" bordercolor="Silver"
                            borderwidth="1px" maxlength="10" width="120px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <TD class="cssTblTitleSingle">
                        설 명
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:textbox id="txtComment" runat="server" borderwidth="1px" bordercolor="Silver"
                            width="100%" height="40px" textmode="MultiLine"></asp:textbox>
                    </td>
                </tr>
                <tr id="trSubjectItem" runat="server">
                    <TD class="cssTblTitleSingle">
                        주관식여부
                    </td>
                    <td class="cssTblContentSingle">
                        <asp:radiobuttonlist id="rblSubjectItemYN" runat="server" width="159px" repeatdirection="Horizontal"
                            repeatlayout="Flow" height="22px"><asp:ListItem Selected="True" Value="0">객관식</asp:ListItem>
                                <asp:ListItem Value="1">주관식</asp:ListItem>
                                </asp:radiobuttonlist>
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
        </td>
    </tr>
</table>
<asp:hiddenfield id="hdfQSbjID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfQDfnID" runat="server"></asp:hiddenfield>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:linkbutton id="lbnReload" runat="server" onclick="lbnReload_Click"></asp:linkbutton>
<!--- MAIN END --->
<asp:placeholder runat="server" id="phdBottom"></asp:placeholder>
</form>
<%
    Response.WriteFile("../_common/html/CommonBottom.htm");
%>
