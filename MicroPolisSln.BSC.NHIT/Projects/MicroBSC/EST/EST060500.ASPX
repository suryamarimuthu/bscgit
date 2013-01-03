<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060500.aspx.cs" Inherits="EST_EST060500" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

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

function ValidCheck() 
{
    var f = document.forms[0];
    
    if(f.hdfEmpRefID.value == '')
    {
        alert('사원을 선택하세요.');
        f.txtEmpName.focus();
        return false;
    }
    
//    if(f.txtScope.value == '')
//    {
//        alert('범위값을 입력하세요.');
//        f.txtScope.focus();
//        return false;
//    }
    
    return true;
}

function SelectEmp()
{
    gfOpenWindow( "EST_EMP.aspx?ESTTERM_REF_ID="	    + document.getElementById('ddlEstTermRefID').value
                            + "&CTRL_DEPT_VALUE_NAME="	+ ""
                            + "&CTRL_DEPT_TEXT_NAME="	+ ""
                            + "&CTRL_EMP_VALUE_NAME="	+ "hdfEmpRefID"
                            + "&CTRL_EMP_TEXT_NAME="	+ "txtEmpName"
                           , 700
                           , 400
                           , false
                           , false
                           , "popup_select_emp" );
	return false;
}

function MappingCtrlEst()
{
    gfOpenWindow( "EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
		                        + "&CTRL_VALUE_NAME="	+ "hdfEstIDArr"
                                + "&CHECKBOX_YN="	    + "Y"
                                + "&CTRL_VALUE_VALUE="  + document.getElementById('hdfEstIDArr').value
                                + "&POSTBACK_YN="       + "Y"
                                + "&POSTBACK_CTRL_NAME="+ "lbnReload_Est"
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_est_scheId" );

	return false;
}

function MappingCtrlEstDept()
{
    gfOpenWindow( "EST_DEPT.aspx?COMP_ID=<%=COMP_ID%>"
                            + "&ESTTERM_REF_ID="    + document.getElementById('ddlEstTermRefID').value
                            + "&CTRL_VALUE_NAME="	+ "hdfDeptRefIDArr"
                            + "&CHECKBOX_YN="	    + "Y"
                            + "&CTRL_VALUE_VALUE="  + document.getElementById('hdfDeptRefIDArr').value
                            + "&POSTBACK_YN="       + "Y"
                            + "&POSTBACK_CTRL_NAME="+ "lbnReload_EstDept"
                           , 430
                           , 400
                           , false
                           , false
                           , "popup_dept_mapping" );
    return false;
}

</script>

    <form id="form1" runat="server">
    <div>
  
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
		<!--- ESTTERM_REF_ID, PRIORITY_IDX, TABLE_NAME, COLUMN_NAME, COLUMN_VALUE, POSITION_TYPE, POSITION_TYPE_NAME, POSITION_CODE, POSITION_NAME --->	
<table width="100%" height="100%">
    <tr>
        <td>
            <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="cssTblTitle">평가기간</td> 
                    <td class="cssTblContent" > 
                        <asp:dropdownlist id="ddlEstTermRefID" runat="server" autopostback="True" onselectedindexchanged="ddlEstTermRefID_SelectedIndexChanged" class="box01"></asp:dropdownlist>
                        <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" Visible="False"></asp:dropdownlist>
                    </td> 
                    <td class="cssTblTitle">구분</td> 
                    <td class="cssTblContent" > 
                        <asp:radiobuttonlist id="rblPointGradeType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPointGradeType_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:radiobuttonlist>
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                    <asp:dropdownlist id="ddlCompID" runat="server" autopostback="True" class="box01" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                    </td> 
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height:100%;">
            <table width="100%" cellpadding="0" cellspacing="0" height="100%">
                <tr>
                    <td  style="vertical-align: top; height:100%;">
                        <ig:UltraWebGrid id="uwgCtrlInfo" runat="server" Height="100%" Width="100%" OnInitializeRow="uwgCtrlInfo_InitializeRow" OnSelectedRowsChange="uwgCtrlInfo_SelectedRowsChange">
                            <Bands>
                                <ig:UltraGridBand>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="CTRL_ID" Key="CTRL_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CTRL_EMP_ID" Key="CTRL_EMP_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:TemplatedColumn Key="selchk" Width="30px" Hidden="true">
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            <Header>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:TemplatedColumn>
                                        <ig:UltraGridColumn BaseColumnName="CTRL_ORDER" Key="CTRL_ORDER" Width="60px" Hidden="True">
                                            <Header Caption="조정순서">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"/>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CTRL_EMP_NAME" Key="CTRL_EMP_NAME" Width="100px">
                                            <Header Caption="조정자명">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"/>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="SCOPE" Key="SCOPE" Width="60px" Hidden="True">
                                            <Header Caption="조정범위">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Right"/>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="SCOPE_UNIT_ID" Key="SCOPE_UNIT_ID" Width="60px" Hidden="True">
                                            <Header Caption="범위타입">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"/>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
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
                                <ClientSideEvents/>
                                <ActivationObject BorderColor="" BorderWidth="">
                                </ActivationObject>--%>
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                    </td>
                    <td width="5px">&nbsp;</td>
                    <td valign="top" width="25%">
                        <ig:UltraWebGrid id="uwgCtrlEstMap" runat="server" Height="100%" Width="100%" OnInitializeRow="uwgCtrlEstMap_InitializeRow">
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                                    </RowTemplateStyle>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="CTRL_ID" Key="CTRL_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'uwgCtrlEstMap');" />
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
                                        <ig:UltraGridColumn BaseColumnName="EST_NAME" Key="EST_NAME" Width="150px" HeaderText="조정범위명">
                                            <Header Caption="평가명">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"/>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout  CellPaddingDefault="2" 
                                            AllowColSizingDefault="Free" 
                                            AllowDeleteDefault="Yes"
                                            AllowSortingDefault="NotSet" 
                                            BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="SortMulti" 
                                            Name="UltraWebGrid2" 
                                            RowHeightDefault="20px"
                                            RowSelectorsDefault="No" 
                                            SelectTypeRowDefault="Extended" 
                                            Version="4.00" 
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
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                </DisplayLayout>
                        </ig:UltraWebGrid>
                    </td>
                    <td width="5px">&nbsp;</td>
                    <td valign="top"  width="25%">
                        <ig:UltraWebGrid id="uwgCtrlEstDeptMap" runat="server" Height="100%" Width="100%" OnInitializeRow="uwgCtrlEstDeptMap_InitializeRow">
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                                    </RowTemplateStyle>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="CTRL_ID" Key="CTRL_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="True">
                                        </ig:UltraGridColumn>
                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellTemplate>
                                                <asp:CheckBox ID="cBox" runat="server" />
                                            </CellTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'uwgCtrlEstDeptMap');" />
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
                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="150px" HeaderText="조정범위명">
                                            <Header Caption="부서명">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center"/>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout  CellPaddingDefault="2" 
                                            AllowColSizingDefault="Free" 
                                            AllowDeleteDefault="Yes"
                                            AllowSortingDefault="NotSet" 
                                            BorderCollapseDefault="Separate"
                                            HeaderClickActionDefault="SortMulti" 
                                            Name="UltraWebGrid2" 
                                            RowHeightDefault="20px"
                                            RowSelectorsDefault="No" 
                                            SelectTypeRowDefault="Extended" 
                                            Version="4.00" 
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
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                </DisplayLayout>
                        </ig:UltraWebGrid>
                    </td>
                </tr>
                <tr height="30">
                    <td style="height: 30px">
                        * 최상위 설정자가 마지막 조정자 입니다.
                    </td>
                    <td style="height: 30px"></td>
                    <td style="height: 30px">
                        * 선택된 평가 없으면 모든 평가에서 참여 가능</td>
                    <td style="height: 30px"></td>
                    <td style="height: 30px">
                        * 선택된 부서가 없으면 모든 부서 참여 가능</td>
                </tr>
                <tr height="20">
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td valign="top" height="50">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <table class="tableBorder" width="100%" cellpadding="0" cellspacing="0" runat="server" id="tbControl">
                                    <tr>
                                        <td class="cssTblTitle" width="120">
                                            &nbsp;확정자명
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:textbox id="txtEmpName" runat="server" Width="100px" MaxLength="25"></asp:textbox>
                                            <a href="#null" onclick="SelectEmp();"><img align="absMiddle" border="0" src="../images/btn/b_008.gif" /></a></td>
                                    </tr>
                                    <tr visible="true" id="trScope" runat="server">
                                        <td class="cssTblTitle">
                                            &nbsp;모든 범위 적용
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:checkbox id="ckbAllEstYN" runat="server" Text="모든 평가"></asp:checkbox>
                                            <asp:checkbox id="ckbAllEstDeptYN" runat="server" Text="모든 부서"></asp:checkbox>
                                            <asp:checkbox id="ckbConfirmEmpYN" runat="server" text="확정자 여부"></asp:checkbox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:textbox id="txtScope" runat="server" Width="50px" MaxLength="100" Visible="False"></asp:textbox>
                                <asp:dropdownlist id="ddlScopeUnitID" runat="server" Visible="False" class="box01"></asp:dropdownlist>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" width="100%" border="0" height="40">
                            <tr>
                                <td align="right">
                                    <asp:imagebutton id="ibnNew" runat="server" imageurl="../images/btn/b_141.gif" onclick="ibnNew_Click" imagealign="AbsMiddle"></asp:imagebutton>
                                    <asp:imagebutton id="ibnSave" runat="server" imageurl="../images/btn/b_tp07.gif" onclick="ibnSave_Click" imagealign="AbsMiddle"></asp:imagebutton>
                                    <asp:imagebutton id="ibnDelete" runat="server" imageurl="../images/btn/b_004.gif" onclick="ibnDelete_Click" imagealign="AbsMiddle"></asp:imagebutton>
                                    <asp:imagebutton id="ibnConfirm" runat="server" imageurl="../images/btn/b_015.gif" onclick="ibnConfirm_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                                    <asp:imagebutton id="ibnConfirmCancel" runat="server" imageurl="../images/btn/b_019.gif" onclick="ibnConfirmCancel_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:hiddenfield id="hdfEmpRefID" runat="server"></asp:hiddenfield>
                    </td>
                    <td></td>
                    <td valign="top" align="right">
                        <table width="100%" cellpadding="0" cellspacing="0" runat="server" id="tblEst">
                            <tr>
                                <td align="right" style="height: 40px">
                                    <a href="#null" onclick="MappingCtrlEst();">
                                        <img align="absMiddle" border="0" src="../images/btn/b_005.gif" /></a>
                                    <asp:imagebutton id="ibnDeleteCtrlEstMap" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_004.gif" OnClick="ibnDeleteCtrlEstMap_Click"></asp:imagebutton>
                                </td>
                            </tr>
                        </table>
                        <asp:hiddenfield id="hdfEstIDArr" runat="server"></asp:hiddenfield>
                        <asp:linkbutton id="lbnReload_Est" runat="server" OnClick="lbnReload_Est_Click"></asp:linkbutton>
                    </td>
                    <td></td>
                    <td valign="top" align="right">
                        <table width="100%" cellpadding="0" cellspacing="0" runat="server" id="tblEstDept">
                            <tr>
                                <td align="right" style="height: 40px">
                                    <a href="#null" onclick="MappingCtrlEstDept();">
                                        <img align="absMiddle" border="0" src="../images/btn/b_005.gif" /></a>
                                    <asp:imagebutton id="ibnDeleteCtrlEstDeptMap" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_004.gif" OnClick="ibnDeleteCtrlEstDeptMap_Click"></asp:imagebutton>
                                </td>
                            </tr>
                        </table>
                        <asp:hiddenfield id="hdfDeptRefIDArr" runat="server"></asp:hiddenfield>
                        <asp:linkbutton id="lbnReload_EstDept" runat="server" OnClick="lbnReload_EstDept_Click"></asp:linkbutton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:hiddenfield id="hdfCtlID" runat="server"></asp:hiddenfield>
<asp:hiddenfield id="hdfPointGradeType" runat="server"></asp:hiddenfield>
<asp:Literal id="ltrScript" runat="server"></asp:Literal>

<!--- MAIN END --->
    <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>