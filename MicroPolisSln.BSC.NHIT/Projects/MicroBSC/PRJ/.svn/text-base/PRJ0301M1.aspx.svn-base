<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0301M1.aspx.cs" Inherits="PRJ_PRJ0301M1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script id="Infragistics" type="text/javascript">

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
        var prj_ref_id       = row.getCellFromKey("PRJ_REF_ID").getValue();
        var status_id        = row.getCellFromKey("STATUS_ID").getValue();
        
        var q_style_page_name  = row.getCellFromKey("Q_STYLE_PAGE_NAME").getValue();
        
        //alert(q_style_page_name);
        
        if(q_style_page_name != null)
            gfOpenWindow('EST_Q_PAGE_03.aspx' + '?COMP_ID=<%=COMP_ID%>'
                                        + '&EST_ID='            + est_id
                                        + '&ESTTERM_REF_ID='    + estterm_ref_id
                                        + '&ESTTERM_SUB_ID='    + estterm_sub_id 
                                        + '&ESTTERM_STEP_ID='   + estterm_step_id 
                                        + '&EST_DEPT_ID='       + est_dept_id
                                        + '&EST_EMP_ID='        + est_emp_id
                                        + '&PRJ_REF_ID='        + prj_ref_id
                                        + '&EST_TGT_TYPE=<%=EST_TGT_TYPE%>'
                                        ,700
                                        ,600
                                        ,'yes'
                                        ,'no');
    }

    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    {
           var cell             = igtbl_getElementById(id);
           var row              = igtbl_getRowById(id);
           var band             = igtbl_getBandById(id);
           var active           = igtbl_getActiveRow(id);

           try {
               var q_style_page_name = row.getCellFromKey("Q_STYLE_PAGE_NAME").getValue();

               if (q_style_page_name != null)
                   cell.style.cursor = 'hand';
           }
           catch (ex) {
           }
        }
    }
    
    function SearchEstID()
    {
	    gfOpenWindow( "../EST/EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
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
	    gfOpenWindow( "../EST/EST_CTRL.aspx?CTRL_ID="	        + ctrl_id
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
<TABLE cellpadding="0" cellspacing="0" border="0" height="100%" Width="100%">
    <tr>
        <td height="20">
            <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td  class="cssTblTitle" style="width:15%;">
                        평가기간
                    </td>
                    <td  class="cssTblContent" style="width:85%;">
                        <%--<img src="../images/title/se_ti01.gif" align="absmiddle" id="IMG1" runat="server">--%>
                        <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermStepID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermStepID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                    </td>
                </tr>
            </table>
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
                        <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; height:90%;">
            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                <Bands>
                    <ig:UltraGridBand>
                        <Columns>
                            <ig:TemplatedColumn AllowGroupBy="No" Key="selchk" Width="30px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                </HeaderTemplate>
                                <CellTemplate>
                                    <asp:CheckBox ID="cBox" style="cursor:pointer" runat="server" />
                                </CellTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn BaseColumnName="COMP_ID" Hidden="True" Key="COMP_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_ID" Hidden="True" Key="EST_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Hidden="True" Key="ESTTERM_SUB_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Hidden="True" Key="ESTTERM_STEP_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Hidden="True" Key="EST_DEPT_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Hidden="True" Key="EST_EMP_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="POINT_DATE" Hidden="True" Key="POINT_DATE">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="9" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="9" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="STATUS_ID" Hidden="True" Key="STATUS_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="10" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="10" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="STATUS_DATE" Hidden="True" Key="STATUS_DATE">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="11" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="11" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="Q_STYLE_PAGE_NAME" Hidden="True" Key="Q_STYLE_PAGE_NAME">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="12" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="12" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_NAME" HeaderText="주기" Key="ESTTERM_SUB_NAME"
                                Width="80px">
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Header Caption="주기">
                                    <RowLayoutColumnInfo OriginX="13" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="13" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" HeaderText="차수" Key="ESTTERM_STEP_NAME"
                                Width="50px">
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Header Caption="차수">
                                    <RowLayoutColumnInfo OriginX="14" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="14" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" HeaderText="평가자부서" Key="EST_DEPT_NAME"
                                Width="140px">
                                <Header Caption="평가자부서">
                                    <RowLayoutColumnInfo OriginX="15" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="15" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" HeaderText="평가자" Key="EST_EMP_NAME"
                                Width="80px">
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Header Caption="평가자">
                                    <RowLayoutColumnInfo OriginX="16" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="16" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="사업코드" Key="PRJ_CODE"
                                Width="80px">
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Header Caption="사업코드">
                                    <RowLayoutColumnInfo OriginX="17" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="17" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="PRJ_NAME" HeaderText="사업명" Key="PRJ_NAME"
                                Width="170px">
                                <Header Caption="사업명">
                                    <RowLayoutColumnInfo OriginX="18" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="18" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="POINT" Format="#,##0.00" HeaderText="점수" Key="POINT"
                                Width="60px">
                                <CellStyle HorizontalAlign="Right">
                                </CellStyle>
                                <Header Caption="점수">
                                    <RowLayoutColumnInfo OriginX="19" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="19" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="STATUS_IMG_PATH" HeaderText="상태" Key="STATUS_IMG_PATH"
                                Width="50px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                                <Header Caption="상태">
                                    <RowLayoutColumnInfo OriginX="20" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="20" />
                                </Footer>
                            </ig:UltraGridColumn>
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
                                AllowSortingDefault="NotSet" 
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
                    <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="DblClickHandler"/>
                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                    <GroupByBox>
                        <BoxStyle CssClass="GridGroupBoxStyle"></BoxStyle>
                    </GroupByBox>
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand" ></FrameStyle>
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
	                <td width="40%">
                        <asp:table id="tblViewStatus" runat="server"></asp:table>
                    </td>
		            <td align="right" runat="server" id="tdImgBox">
		                <asp:imagebutton id="ibnSearchAll" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_165.gif" onclick="ibnSearchAll_Click" CommandName="BIZ_PRJ_SEARCH_ALL" Visible="False"></asp:imagebutton>
		                <asp:imagebutton id="ibnConfirmEstQ" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_163.gif" onclick="ibnConfirmEstQ_Click" CommandArgument="JOB_25" CommandName="BIZ_PRJ_CONFIRM_EST_Q" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="ibnCancelEstQ" runat="server" commandargument="JOB_25" commandname="BIZ_PRJ_CONFIRM_EST_Q" imagealign="AbsMiddle" imageurl="../images/btn/b_178.gif" onclick="ibnCancelEstQ_Click" visible="false"></asp:imagebutton>
                        <asp:imagebutton id="ibnAggEstTermStep" runat="server" commandargument="JOB_27"  imagealign="AbsMiddle" onclick="ibnAggEstTermStep_Click" imageurl="../images/btn/b_150.gif" commandname="BIZ_PRJ_AGG_ESTTERM_STEP" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="ibnProjectToEmpData" runat="server" commandargument="JOB_26" imagealign="AbsMiddle" onclick="ibnProjectToEmpData_Click" imageurl="../images/btn/b_155.gif" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="ibnGetPrjPoint" runat="server" commandargument="JOB_33" imagealign="AbsMiddle" imageurl="~/images/btn/b_197.gif" onclick="ibnGetPrjPoint_Click" visible="False"></asp:imagebutton>
                        <asp:imagebutton id="ibnDownExcel" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif" onclick="ibnDownExcel_Click" CommandName="BIZ_DOWN_EXCEL" Visible="False"></asp:imagebutton>
                        &nbsp;
		            </td>
	            </tr>
	        </table>
	    </td>
	</tr>
</table>

<ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
</ig:UltraWebGridExcelExporter>

<asp:hiddenfield id="hdfEstID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermRefID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermSubID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfEstTermStepID" runat="server"></asp:hiddenfield>
<asp:literal id="ltrScript" runat="server"></asp:literal>
<asp:linkbutton id="lbnReload" runat="server" OnClick="lbnReload_Click"></asp:linkbutton>

        <!--- MAIN END --->
        
        <MenuControl:MenuControl_Bottom id="MenuControl_Bottom1" runat="server" />
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

