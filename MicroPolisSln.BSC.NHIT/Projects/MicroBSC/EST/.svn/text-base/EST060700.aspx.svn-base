<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060700.aspx.cs" Inherits="EST_EST060700" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">

function MouseOverHandler(gridName, id, objectType)
{
    if(objectType == 0) 
    {
       var cell             = igtbl_getElementById(id);
       var row              = igtbl_getRowById(id);
       var band             = igtbl_getBandById(id);
       var active           = igtbl_getActiveRow(id);
       cell.style.cursor    = 'hand';
    }
}

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
                           , "popup_est_scheId");

	//return false;
}

function MappingEmp()
{
    gfOpenWindow( "EST_Q_EMP.aspx?COMP_ID=<%= COMP_ID %>"
                                + "&ESTTERM_REF_ID="	+ document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID="	+ document.getElementById('ddlEstTermSubID').value
                                + "&EST_ID="    	    + document.getElementById('hdfSearchEstID').value
                                + "&Q_OBJ_ID="          + document.getElementById('hdfQObjID').value
                               , 700
                               , 400
                               , false
                               , false
                               , "popup_emp_mapping" );
	return false;
}


function ViewQTgtView()
{
	gfOpenWindow( "EST060201.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&EST_ID="	        + document.getElementById('hdfSearchEstID').value
                                + "&ESTTERM_REF_ID="	+ document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID="	+ document.getElementById('ddlEstTermSubID').value
                                + "&Q_OBJ_ID="	        + document.getElementById('hdfQObjID').value
                               , 620
                               , 450
                               , true
                               , true
                               , "popup_est_tgt_map" );
	return false;
}

function ViewCoptType(type)
{
	gfOpenWindow( "EST060601.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&TYPE=" + type
                               , 500
                               , 170
                               , true
                               , true
                               , "popup_type" );
	return false;
}

function SelectEmp(hdf, txt, dept_ref_id)
{
    gfOpenWindow( "EST_EMP.aspx?CTRL_DEPT_VALUE_NAME="	+ ""
                            + "&CTRL_DEPT_TEXT_NAME="	+ ""
                            + "&CTRL_EMP_VALUE_NAME="	+ hdf
                            + "&CTRL_EMP_TEXT_NAME="	+ txt
                            + "&SELECT_DEPT_REF_ID="    + dept_ref_id
                           , 700
                           , 400
                           , false
                           , false
                           , "popup_select_emp" );
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
    <form id="form1" runat="server">
    <div>
        
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
        <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
        <asp:literal runat="server" ID="ltrJScript"></asp:literal>
    <table width="100%" height="100%">
        <tr>
            <td>
                <table cellpadding=0 cellspacing=0 border=0 width="100%" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            평가유형
                        </td>
                        <td class="cssTblContent" style="border-right:none;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px" width="100%"></asp:textbox>
                                        <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                                    </td>
                                    <td style="width:90px;" align="right">
                                        <a href="javascript:SearchEstID();"><img align="absMiddle" border="0" src="../images/btn/b_143.gif" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                        <td class="cssTblContent">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                        </td>
                        <td align="right">
                            <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td>
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn Key="TGT_DEPT_ID" Hidden="True">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn Key="TGT_EMP_ID" Hidden="True">
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" Hidden="true">
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <HeaderTemplate>
                                        <%--<asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />--%>
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="250px" HeaderText="부서명">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="부서명">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn Key="CTRL_EMP" Width="200px">
                                    <HeaderStyle Wrap="True" />
                                    <CellTemplate>
                                        <asp:HiddenField runat="server" ID="hdfTgtEmpID"></asp:HiddenField>
                                        <asp:TextBox ID="txtTgtEmpName" runat="server" Width="80"></asp:TextBox>
                                        <asp:Literal ID="ltrImage" runat="server"></asp:Literal>
                                    </CellTemplate>
                                    <Header Caption="의견상신 담당자">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:TemplatedColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  AllowColSizingDefault="Free" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate"
                                    HeaderClickActionDefault="NotSet" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px"
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Extended" 
                                    Version="4.00" 
                                    ReadOnly="LevelTwo"
                                    CellClickActionDefault="NotSet" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False">
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
                        <ClientSideEvents />
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
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <asp:imagebutton id="ibnSave" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_tp07.gif" onclick="ibnSave_Click" Visible="False"></asp:imagebutton>
                <asp:imagebutton id="ibnUpdateEmpRole" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_206.gif" Visible="False" OnClick="ibnUpdateEmpRole_Click"></asp:imagebutton>
                &nbsp;
            </td>
        </tr>
    </table>
<asp:literal id="ltrScript" runat="server"></asp:literal>

<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    <!--- MAIN END --->
    </div>
        
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

