<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060200.aspx.cs" Inherits="EST_EST060200" %>

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript">

    function MouseOverHandler(gridName, id, objectType) {
        if (objectType == 0) {
            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);
            cell.style.cursor = 'hand';
        }
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

    function MappingEmp() {
        gfOpenWindow("EST_Q_EMP.aspx?COMP_ID=<%= COMP_ID %>"
                                + "&ESTTERM_REF_ID=" + document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID=" + document.getElementById('ddlEstTermSubID').value
                                + "&EST_ID=" + document.getElementById('hdfSearchEstID').value
                                + "&Q_OBJ_ID=" + document.getElementById('hdfQObjID').value
                               , 700
                               , 400
                               , false
                               , false
                               , "popup_emp_mapping");
        return false;
    }

    function MappingDept() {
        gfOpenWindow("EST_DEPT.aspx?COMP_ID=<%=COMP_ID%>"
                                + "&ESTTERM_REF_ID=" + document.getElementById('ddlEstTermRefID').value
                                + "&CTRL_VALUE_NAME=" + "hdfEstDept"
                                + "&CHECKBOX_YN=" + "Y"
                                + "&CTRL_VALUE_VALUE=" + document.getElementById('hdfEstDept').value
                                + "&POSTBACK_YN=" + "Y"
                                + "&POSTBACK_CTRL_NAME=" + "lbnDeptReload"
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_dept_mapping");
        return false;
    }

    function ViewQTgtView() {
        gfOpenWindow("EST060201.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&EST_ID=" + document.getElementById('hdfSearchEstID').value
                                + "&ESTTERM_REF_ID=" + document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID=" + document.getElementById('ddlEstTermSubID').value
                                + "&Q_OBJ_ID=" + document.getElementById('hdfQObjID').value
                               , 620
                               , 450
                               , true
                               , true
                               , "popup_est_tgt_map");
        return false;
    }

    function ViewCoptType(type) {
        gfOpenWindow("EST060601.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&TYPE=" + type
                               , 500
                               , 170
                               , true
                               , true
                               , "popup_type");
        return false;
    }

    function Search() {
        if (document.getElementById('hdfSearchEstID').value == "") {
            alert('평가를 선택하세요.');
            return false;
        }

        return true;
    }

</script>

<form id="form1" runat="server">
<div>
    <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" id="phdLayout"></asp:placeholder>
    <asp:literal runat="server" id="ltrJScript"></asp:literal>
    <table width="100%" height="100%">
        <tr>
            <td colspan="2">
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" autopostback="True"
                                onselectedindexchanged="ddlEstTermRefID_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" autopostback="True"
                                onselectedindexchanged="ddlEstTermSubID_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermStepID" runat="server" class="box01" visible="False"
                                autopostback="True" onselectedindexchanged="ddlEstTermStepID_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">
                            평가유형
                        </td>
                        <td class="cssTblContent">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px"
                                            width="100%"></asp:textbox>
                                    </td>
                                    <td style="width: 85px;">
                                        <a href="#null" onclick="SearchEstID();">
                                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True"
                                onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                    <tr>
                        <td style="width: 1%;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:label id="lblTitle" runat="server" font-bold="true" text="질의 리스트" />
                        </td>
                    </tr>
                </table>
                <td>
                    <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                        <tr>
                            <td style="width: 1%;">
                                <img src="../images/title/ma_t14.gif" alt="" />
                            </td>
                            <td>
                                <asp:label id="lblTitle1" runat="server" font-bold="true" text="질의 응답 부서 리스트" />
                            </td>
                            <td align="right">
                                <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle"
                                    imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                            </td>
                        </tr>
                    </table>
                </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%;">
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                    Width="100%" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="EST_ID" HeaderText="EST_ID" Hidden="True" Key="EST_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" HeaderText="Q_OBJ_ID" Hidden="True"
                                    Key="Q_OBJ_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" HeaderText="질의평가그룹" Key="Q_OBJ_NAME"
                                    Width="300px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="질의평가그룹">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_TITLE" HeaderText="질의평가그룹 타이틀" Key="Q_OBJ_TITLE"
                                    Width="200px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="질의평가그룹 타이틀">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                        Name="UltraWebGrid1" RowHeightDefault="22px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        StationaryMargins="Header" TableLayout="Fixed" Version="4.00">
                        <%--<GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                        </GroupByRowStyleDefault>
                        <ActivationObject BorderColor="" BorderWidth="">
                        </ActivationObject>
                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorTop="White" WidthTop="1px" />
                        </FooterStyleDefault>
                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                            <Padding Left="3px" />
                        </RowStyleDefault>
                        <ClientSideEvents/>
                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                        </SelectedRowStyleDefault>
                        <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                            ForeColor="White" HorizontalAlign="Center">
                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                        </HeaderStyleDefault>
                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                        </EditCellStyleDefault>
                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                            Cursor="Hand" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                        </AddNewBox>--%>
                        <RowStyleDefault CssClass="GridRowStyle_02" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                        </HeaderStyleDefault>
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                        </FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
            <td valign="top" style="height: 183px">
                <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Height="100%" Width="100%">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="EST_ID" Hidden="True" Key="EST_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Hidden="True" Key="TGT_DEPT_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Hidden="True" Key="TGT_EMP_ID">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" />
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <asp:checkbox id="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                                    </HeaderTemplate>
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" Key="Q_OBJ_NAME" Width="150px" Hidden="true">
                                    <Header Caption="질의그룹명" Title="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Footer Caption="" Title="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="부서명">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="사원명">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_CLS_NAME" Key="POS_CLS_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직급">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_RNK_NAME" Key="POS_RNK_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직위">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_DUT_NAME" Key="POS_DUT_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직책">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POS_GRP_NAME" Key="POS_GRP_NAME" Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="직군">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                        AllowSortingDefault="NotSet" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti"
                        Name="UltraWebGrid2" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                        AutoGenerateColumns="False">
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
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
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                        </FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right" colspan="2">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td runat="server" id="pnlEmp" visible="false" align="right">
                            <a onclick="MappingEmp();" href="#null">
                                <img id="IMG1" src="../images/btn/b_005.gif" border="0" align="absmiddle" /></a>
                            <asp:imagebutton id="iBtnEmpRemove" onclick="iBtnEmpRemove_Click" runat="server"
                                imageurl="../images/btn/b_004.gif" imagealign="AbsMiddle"></asp:imagebutton>
                            &nbsp;
                        </td>
                        <td runat="server" id="pnlDept" visible="false" align="right">
                            <a onclick="MappingDept();" href="#null">
                                <img src="../images/btn/b_005.gif" align="absMiddle" border="0" /></a>
                            <asp:imagebutton id="iBtnDeptRemove" onclick="iBtnDeptRemove_Click" runat="server"
                                imageurl="../images/btn/b_004.gif" imagealign="AbsMiddle"></asp:imagebutton>
                            &nbsp;
                        </td>
                        <td align="right">
                            <a href="#null" onclick="ViewQTgtView();">
                                <img align="absMiddle" border="0" src="../images/btn/b_191.gif" id="imgQDeptEmpMap"
                                    runat="server" visible="false" /></a> <a href="#null" onclick="ViewCoptType('5');">
                                        <img align="absMiddle" border="0" src="../images/btn/b_081.gif" /></a>
                            <asp:imagebutton id="ibnDownExcel" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif"
                                onclick="ibnDownExcel_Click" visible="False" />
                            <asp:imagebutton id="ibnConfirm" runat="server" imageurl="../images/btn/b_015.gif"
                                onclick="ibnConfirm_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            <asp:imagebutton id="ibnConfirmCancel" runat="server" imageurl="../images/btn/b_019.gif"
                                onclick="ibnConfirmCancel_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    <asp:hiddenfield id="hdfEstDept" runat="server"></asp:hiddenfield>
    <asp:hiddenfield id="hdfQObjID" runat="server"></asp:hiddenfield>
    <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
    </ig:UltraWebGridExcelExporter>
    <asp:linkbutton id="lbnEmpReload" runat="server" onclick="lbnEmpReload_Click"></asp:linkbutton>
    <asp:linkbutton id="lbnDeptReload" runat="server" onclick="lbnDeptReload_Click"></asp:linkbutton>
    <asp:placeholder runat="server" id="phdBottom"></asp:placeholder>
    <!--- MAIN END --->
</div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
