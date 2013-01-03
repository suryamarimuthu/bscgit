<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMS0300S1.aspx.cs" Inherits="PMS_PMS0300S1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">
    var param1 = false;
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


    function openEstPopup(url
                        , PRJ_REF_ID
                        , PRJ_CODE
                        , COMP_ID
                        , EST_ID
                        , ESTTERM_REF_ID
                        , ESTTERM_SUB_ID
                        , ESTTERM_STEP_ID
                        , EST_DEPT_ID
                        , EST_EMP_ID) {
        var querystring = "?PRJ_REF_ID=" + PRJ_REF_ID
                        + "&PRJ_CODE=" + PRJ_CODE
                        + "&COMP_ID=" + COMP_ID
                        + "&EST_ID=" + EST_ID
                        + "&ESTTERM_REF_ID=" + ESTTERM_REF_ID
                        + "&ESTTERM_SUB_ID=" + ESTTERM_SUB_ID
                        + "&ESTTERM_STEP_ID=" + ESTTERM_STEP_ID
                        + "&EST_DEPT_ID=" + EST_DEPT_ID
                        + "&EST_EMP_ID=" + EST_EMP_ID;

                         
        var openURL = url + querystring;

        gfOpenWindow(openURL, 940, 700, 'no', 'no');
    }


    function checkGrid() {
        if (doChecking('UltraWebGrid1')) {
            return true;
        }

        return false;
    }
</script>

<form id="form1" runat="server">
<div>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle">프로젝트 종료일</td> 
                        <td class="cssTblContent"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                               <tr>
                                 <td style="width:45%;">
                                    <ig:WebDateChooser CssClass="box01" ID="prj_sDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="99%">
                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                    </ig:WebDateChooser> 
                                 </td>
                                 <td style="width:10%; text-align:center;">&nbsp;~&nbsp;</td>
                                 <td style="width:45%;">
                                    <ig:WebDateChooser CssClass="box01" ID="prj_eDate" runat="server" NullDateLabel="" Format="Short" AllowNull="false" Width="99%">
                                        <CalendarLayout CalendarStyle-Height="15px" ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                    </ig:WebDateChooser>
                                 </td>
                               </tr>
                             </table>
                        </td> 
                        <td class="cssTblTitle">프로젝트 명칭</td>
                        <td class="cssTblContent">
                            <asp:TextBox runat="server" id="txtPRJ_NAME" width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssTblTitle">평가대상</td>
                        <td class="cssTblContent">
                            <asp:DropDownList runat="server" id="GUBUN" width="100%" class="box01" >
                                <asp:listItem selected="true" value="TOTAL">전체</asp:listItem>
                                <asp:listItem value="INCLUDE">지정</asp:listItem>
                                <asp:listItem value="EXCLUDE">미지정</asp:listItem>
                            </asp:DropDownList>
                        </td>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        
        <tr class="cssPopBtnLine">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td align="left">
                            <img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                        </td>
                        <td align="right">
                            <asp:RadioButton id="rdo_prj_select" runat="server" groupname="radiogrp" checked="true" text="프로젝트 선정" />
                            <asp:RadioButton id="rdo_prj_est" runat="server" groupname="radiogrp" text="프로젝트 평가" />
                            <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" onclick="iBtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr style="height:100%;">
            <td>
                <ig:UltraWebGrid    id="UltraWebGrid1" runat="server"
                                    Width="100%" Height="100%" 
                                    oninitializerow="UltraWebGrid1_InitializeRow">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:templatedcolumn basecolumnname="selchk" key="selchk" width="30px">
                                    <HeaderTemplate>
                                        <img alt="전제선택/해제" onclick="selectChkBox('UltraWebGrid1')" src="../images/checkbox.gif" style="cursor:hand; vertical-align:middle;" />
                                    </HeaderTemplate>
                                    <celltemplate>
                                        <asp:CheckBox  id="cBox" runat="server" /> 
                                    </celltemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                </ig:templatedcolumn>
                                <ig:ultragridcolumn basecolumnname="PRJ_ID" hidden="True" key="PRJ_ID">
                                    <header caption="PRJ_ID" />
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="EST_DEPT_ID" hidden="True" key="EST_DEPT_ID">
                                    <header caption="EST_DEPT_ID" />
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="EST_EMP_ID" hidden="True" key="EST_EMP_ID">
                                    <header caption="EST_EMP_ID" />
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="PRJ_NAME" key="PRJ_NAME" Width="300px">
                                    <header caption="프로젝트명" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Left"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="DEPT_NAME" key="DEPT_NAME" Width="200px">
                                    <header caption="수행부서명" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Left"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="PM_EMP_NAME" key="PM_EMP_NAME" Width="60px">
                                    <header caption="PM" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="EMP_WORK_MM" key="EMP_WORK_MM" Width="80px">
                                    <header caption="투입인원수" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Right"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="PRJ_REF_ID" key="PRJ_REF_ID" Hidden="true">
                                    <header caption="PRJ_REF_ID" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="PRJ_REF_ID_YN" key="PRJ_REF_ID_YN" Width="60px">
                                    <header caption="평가대상" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                                 <ig:ultragridcolumn basecolumnname="PRJ_STARTDATE" key="PRJ_STARTDATE" Width="100px">
                                    <header caption="시작일자" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="PRJ_ENDDATE" key="PRJ_ENDDATE" Width="100px">
                                    <header caption="종료일자" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="STATUS_ICON" key="STATUS_ICON" Width="60px">
                                    <header caption="평가상태" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                                <ig:ultragridcolumn basecolumnname="PRJ_EST_STATUS" key="PRJ_EST_STATUS" Hidden="true">
                                    <header caption="PRJ_EST_STATUS" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <cellstyle horizontalalign="Center"></cellstyle>
                                </ig:ultragridcolumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    
                    <DisplayLayout  CellPaddingDefault="2"
                                        AllowColSizingDefault="Free"
                                        AllowColumnMovingDefault="OnServer"
                                        AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes"
                                        BorderCollapseDefault="Separate"
                                        HeaderClickActionDefault="SortMulti"
                                        Name="UltraWebGrid1"
                                        RowHeightDefault="20px"
                                        RowSelectorsDefault="No"
                                        SelectTypeRowDefault="Extended"
                                        Version="4.00"
                                        TableLayout="Fixed"
                                        StationaryMargins="Header"
                                        AutoGenerateColumns="False">
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        
        
        <tr class="cssPopBtnLine">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                <tr>
                                    <td style="width:15px;" align="center"><img src="../images/icon/color/green.gif" /></td>
                                    <td style="width:40px;">평가중</td>
                                    <td style="width:15px;" align="center"><img src="../images/icon/color/blue.gif" /></td>
                                    <td>평가완료</td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                            
                            <asp:ImageButton id="ibnSetTarget" runat="server" imageurl="../images/btn/btn_setup.gif" imagealign="absmiddle" onclick="ibnSetTarget_Click" onclientclick="return checkGrid()" />
                            <asp:ImageButton id="ibnUnSetTarger" runat="Server" imageurl="../images/btn/btn_except.gif" imagealign="absmiddle" onclick="ibnUnSetTarger_Click" onclientclick="return checkGrid()" />
                            <asp:literal id="ltrScript" runat="server"></asp:literal>
                            <asp:label id="lblCompTitle" runat="server" visible="false" />
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile( "../_common/html/CommonBottom.htm" );%>