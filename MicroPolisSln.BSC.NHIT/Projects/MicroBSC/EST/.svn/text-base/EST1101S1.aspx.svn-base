<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST1101S1.aspx.cs" Inherits="EST_EST1101S1" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script id="Infragistics" type="text/javascript">

    function btnClick(clickValue) {
        switch (clickValue) {
            case "1":
                if ('<%= this.IEST_STATUS %>' == "Y") {
                    alert('이미 확정된 평가입니다.');
                    return false;
                }
                if ('<%= this.IEST_COMPLETE %>' == "Y") {
                    alert('평가확정버튼을 이용하세요.');
                    return false;
                }
                return confirm('강제확정 하시겠습니까?');
                break;
            case "2":
                if ('<%= this.IEST_STATUS %>' == "Y") {
                    alert('이미 확정된 평가입니다.');
                    return false;
                }
                if ('<%= this.IEST_COMPLETE %>' == "N") {
                    alert('완료되지 않은 평가가 존재합니다. 확정할 수 없습니다.');
                    return false;
                }
                return confirm('평가확정 하시겠습니까?');
                break;
            case "3":
                if ('<%= this.IEST_STATUS %>' != "Y") {
                    alert('확정되지않은 평가입니다.');
                    return false;
                }
                return confirm('확정취소 하시겠습니까?');
                break;
        }
        return false;
    }
    
    function DblClickHandler(gridName, id) 
    {
        var cell             = igtbl_getElementById(id);
        var row              = igtbl_getRowById(id);
        
        var est_id           = row.getCellFromKey("EST_ID").getValue();
        var estterm_ref_id   = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var estterm_sub_id   = row.getCellFromKey("ESTTERM_SUB_ID").getValue();
        var estterm_step_id  = row.getCellFromKey("ESTTERM_STEP_ID").getValue();
        var est_dept_id      = row.getCellFromKey("EST_DEPT_ID").getValue();
        var est_emp_id       = row.getCellFromKey("EST_EMP_ID").getValue();
        var tgt_dept_id      = row.getCellFromKey("TGT_DEPT_ID").getValue();
        var tgt_emp_id       = row.getCellFromKey("TGT_EMP_ID").getValue();
        var status_id        = row.getCellFromKey("STATUS_ID").getValue();
        
        var q_style_page_name  = row.getCellFromKey("Q_STYLE_PAGE_NAME").getValue();
        
        if('<%=EST_TGT_TYPE%>' == '') 
        {
            alert('설정된 평가 방법이 없습니다.');
            return;
        }
        else if('<%=EST_TGT_TYPE%>' == 'EST') 
        {
            
        }
        else if('<%=EST_TGT_TYPE%>' == 'TGT') 
        {
            
        }
        
        if(q_style_page_name != null) 
        {
            var year_yn   = '<%=REPORT_YN %>';
            var merge_yn  = '<%=MERGE_YN %>';
            var report_yn = '<%=REPORT_YN %>';
            
            var width  = 700;
            var height = 600;
            var scroll = 'yes';
                    
            if(   (year_yn   == 'N' && merge_yn == 'N')
                || report_yn == 'Y' ) 
            {
                if(report_yn == 'Y') 
                {
                    width  = 900;
                    height = 690;
                    scroll = 'no';
                }
            
                gfOpenWindow(q_style_page_name  + '?COMP_ID=<%=COMP_ID%>'
                                                + '&EST_ID='            + est_id
                                                + '&ESTTERM_REF_ID='    + estterm_ref_id
                                                + '&ESTTERM_SUB_ID='    + estterm_sub_id 
                                                + '&ESTTERM_STEP_ID='   + estterm_step_id 
                                                + '&EST_DEPT_ID='       + est_dept_id
                                                + '&EST_EMP_ID='        + est_emp_id
                                                + '&TGT_DEPT_ID='       + tgt_dept_id
                                                + '&TGT_EMP_ID='        + tgt_emp_id
                                                + '&EST_TGT_TYPE=<%=EST_TGT_TYPE%>'
                                                ,width
                                                ,height
                                                ,scroll
                                                ,'no'
                                                ,'pop_up_est_common');    
            }
        }
    }

    function MouseOverHandler(gridName, id, objectType) 
    {
        var cell, row, band, active;
        
        if (objectType == 0) {
            cell = igtbl_getElementById(id);
            row = igtbl_getRowById(id);
            band = igtbl_getBandById(id);
            active = igtbl_getActiveRow(id);

            try {
                var q_style_page_name = row.getCellFromKey("Q_STYLE_PAGE_NAME").getValue();

                if (q_style_page_name != null) {
                    if (('<%=YEAR_YN %>' == 'N' && '<%=MERGE_YN %>' == 'N')
                    || '<%=REPORT_YN %>' == 'Y') {
                        cell.style.cursor = 'hand';
                    }
                }
            }
            catch (ex) {
            }
        }
    }

//    function AfterSelectChangeHandler(gridName, id)
//    {
//        var cell            = igtbl_getElementById(id);
//        var row             = igtbl_getRowById(id);
//    }
    
    function SearchEstID()
    {
	    gfOpenWindow( "EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&CTRL_VALUE_NAME="	+ "hdfSearchEstID"
                                + "&CTRL_TEXT_NAME="	+ "txtSearchEstName"
                                + "&CHECKBOX_YN="	    + "N"
                                + "&CTRL_VALUE_VALUE="  + ""
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_est_est_id" );
	    //return false;
    }
    
    function ShowAssignDeptPoint()
	{
		gfOpenWindow(  "EST110101.aspx?COMP_ID=<%=COMP_ID%>"
		                            + "&EST_ID=<%=EST_ID%>"
                                    + "&ESTTERM_REF_ID=<%=ESTTERM_REF_ID%>"
                                    + "&ESTTERM_SUB_ID=<%=ESTTERM_SUB_ID%>"
                                    + "&ESTTERM_STEP_ID=<%=ESTTERM_STEP_ID%>"
                                    + "&YEAR_YN=<%=YEAR_YN%>"
                                    + "&MERGE_YN=<%=MERGE_YN%>"
                               , 530
                               , 400
                               , false
                               , false
                               , "popup_est_dept_assign" );
		return false;
	}
	
	function ShowAssignEmpPoint()
	{
		gfOpenWindow(  "EST110102.aspx?COMP_ID=<%=COMP_ID%>"
		                            + "&EST_ID=<%=EST_ID%>"
                                    + "&ESTTERM_REF_ID=<%=ESTTERM_REF_ID%>"
                                    + "&ESTTERM_SUB_ID=<%=ESTTERM_SUB_ID%>"
                                    + "&ESTTERM_STEP_ID=<%=ESTTERM_STEP_ID%>"
                                    + "&YEAR_YN=<%=YEAR_YN%>"
                                    + "&MERGE_YN=<%=MERGE_YN%>"
                               , 760
                               , 400
                               , false
                               , false
                               , "popup_est_emp_assign" );
		return false;
	}
	
	function ShowAssignPosBiz()
	{
		gfOpenWindow(  "EST110103.aspx?COMP_ID=<%=COMP_ID%>"
		                            + "&EST_ID=<%=EST_ID%>"
                                    + "&ESTTERM_REF_ID=<%=ESTTERM_REF_ID%>"
                                    + "&ESTTERM_SUB_ID=<%=ESTTERM_SUB_ID%>"
                                    + "&ESTTERM_STEP_ID=<%=ESTTERM_STEP_ID%>"
                                    + "&YEAR_YN=<%=YEAR_YN%>"
                                    + "&MERGE_YN=<%=MERGE_YN%>"
                               , 660
                               , 400
                               , false
                               , false
                               , "popup_est_assign_pos_biz" );
		return false;
	}
    
    function ViewCtrlPage(ctrl_id
                        , comp_id
                        , est_id
                        , estterm_ref_id
                        , estterm_sub_id
                        , estterm_step_id
                        , est_dept_id
                        , est_emp_id
                        , ctrl_emp_id
                        , tgt_dept_id
                        , tgt_emp_id
                        , point_grade_type)
    {
	    gfOpenWindow( "EST_CTRL.aspx?CTRL_ID="	        + ctrl_id
	                            + "&COMP_ID="           + comp_id
	                            + "&EST_ID="            + est_id
	                            + "&ESTTERM_REF_ID="	+ estterm_ref_id
                                + "&ESTTERM_SUB_ID="	+ estterm_sub_id
                                + "&ESTTERM_STEP_ID="	+ estterm_step_id
                                + "&EST_DEPT_ID="	    + est_dept_id
                                + "&EST_EMP_ID="	    + est_emp_id
                                + "&CTRL_EMP_ID="	    + ctrl_emp_id
                                + "&TGT_DEPT_ID="	    + tgt_dept_id
                                + "&TGT_EMP_ID="	    + tgt_emp_id
                                + "&POINT_GRADE_TYPE="	+ point_grade_type
                               , 500
                               , 350
                               , false
                               , false
                               , "popup_ctrl" );
	    return false;
    }
    
    function Search() 
    {
        if(document.getElementById('hdfSearchEstID').value == "") 
        {
            alert('평가를 선택하세요.');
            return false;
        }
        
        return true;
    }
    
</script>

<form id="form2" runat="server">
    <div>
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
<table cellpadding="0" cellspacing="0" border="0" height="100%" Width="100%">
    <tr>
        <td>
            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td  class="cssTblTitle" style="width:15%;">
                        <%--<img src="../images/title/se_ti01.gif" align="absmiddle" id="IMG1" runat="server">--%>
                        평가기간
                    </td>
                    <td  class="cssTblContent" style="width:85%;">
                        <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermStepID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermStepID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        <asp:DropDownList id="ddlTgtDept" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlTgtDept_SelectedIndexChanged"></asp:dropdownlist>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="cssPopBtnLine">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                        <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                    </td>
                    <td align="right">
                        <asp:Literal id="ltrConfirmStatus" runat="server"></asp:Literal>
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px" width="120px"></asp:textbox>
                        <a href="#null" onclick="SearchEstID();">
                        <img align="absMiddle" border="0" src="../images/btn/b_143.gif" id="imgEstButton" runat="server" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; height:90%">
            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                <Bands>
                    <ig:UltraGridBand>
                        <Columns>
                            <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No">
                                <CellTemplate>
                                    <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                </CellTemplate>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cBox_header" runat="server" style="cursor:pointer" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center"  />
                            </ig:TemplatedColumn>
                        </Columns>
                        <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                        <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
                            <BorderDetails WidthRight="3px" WidthLeft="3px" WidthTop="3px" WidthBottom="3px"></BorderDetails>
                        </RowTemplateStyle>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout  CellPaddingDefault="2" 
                                AllowColSizingDefault="Free" 
                                AllowDeleteDefault="Yes"
                                AllowSortingDefault="Yes" 
                                BorderCollapseDefault="Separate"
                                HeaderClickActionDefault="NotSet" 
                                Name="UltraWebGrid1" 
                                RowHeightDefault="20px"
                                RowSelectorsDefault="No" 
                                SelectTypeRowDefault="Extended" 
                                Version="4.00" 
                                ViewType="OutlookGroupBy" 
                                CellClickActionDefault="RowSelect" 
                                TableLayout="Fixed" 
                                StationaryMargins="Header"
                                OptimizeCSSClassNamesOutput="False"
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
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                        <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
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
                    <ClientSideEvents DblClickHandler="DblClickHandler"/>
                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                    <GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                    </GroupByBox>
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                    <Images>
                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                    </Images>
                    <ClientSideEvents DblClickHandler="DblClickHandler"/>
                </DisplayLayout>
            </ig:UltraWebGrid>
	    </td>
	</tr>
	<tr>
	    <td height="30">
	        <table cellpadding="0" cellspacing="0" width="100%" height="100%">
	            <tr>
	                <td>
	                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left">
                                    <asp:table id="tblViewStatus" runat="server"></asp:table>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
		            <td align="right" runat="server" id="tdImgBox">
		                <asp:imagebutton id="ibnSearchAll" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_165.gif" onclick="ibnSearchAll_Click" CommandName="BIZ_SEARCH_ALL" Visible="false"></asp:imagebutton>
		                <asp:imagebutton id="ibnSearchEmp" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_215.gif" onclick="ibnSearchEmp_Click" CommandName="BIZ_SEARCH_EMP" Visible="false"></asp:imagebutton>
		                <asp:imagebutton id="ibnConfirmByForce" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_207.gif" onclick="ibnConfirmByForce_Click" CommandName="BIZ_CONFIRM_BY_FORCE" Visible="false"></asp:imagebutton>
		                <asp:imagebutton id="ibnGetOuterData" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_154.gif" onclick="ibnGetOuterData_Click" CommandArgument="JOB_12" CommandName="BIZ_GET_OUTER_DATA" Visible="false"></asp:imagebutton>
                        <asp:imagebutton id="ibnDownExcel" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif" onclick="ibnDownExcel_Click" CommandName="BIZ_DOWN_EXCEL" Visible="false"></asp:imagebutton>                        
                        &nbsp;
		            </td>
	            </tr>
	        </table>
	    </td>
	</tr>
</table>
<ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server"></ig:UltraWebGridExcelExporter>
<asp:hiddenfield id="hdfEstID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermRefID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermSubID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermStepID" runat="server"></asp:hiddenfield>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:linkbutton id="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:linkbutton>

        <!--- MAIN END --->
        
        <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

