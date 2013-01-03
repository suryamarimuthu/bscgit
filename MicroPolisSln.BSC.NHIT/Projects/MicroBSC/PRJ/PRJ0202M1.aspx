<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0202M1.aspx.cs" Inherits="PRJ_PRJ0202M1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
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
	gfOpenWindow( "../EST/EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
	                        + "&CTRL_VALUE_NAME="	+ "hdfSearchEstID"
                            + "&CTRL_TEXT_NAME="	+ "txtSearchEstName"
                            + "&CHECKBOX_YN="	    + "N"
                            + "&CTRL_VALUE_VALUE="  + ""
                           , 430
                           , 400
                           , false
                           , false
                           , "popup_est_scheId" );
	return false;
}

function MappingPrj()
{

  if(document.getElementById('hdfQObjID').value == "")
  {
     alert('질의를 선택하세요.');
     return false;
  }
  
   var ICCB1           = "<%= this.ICCB1 %>";
   
    gfOpenWindow( "./PRJ0202S1.aspx?COMP_ID=<%= COMP_ID %>"
                                + "&CTRL_VALUE_NAME="	+ "hdfPrjRefID"
                                + "&ESTTERM_REF_ID="	+ document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID="	+ document.getElementById('ddlEstTermSubID').value
                                + "&EST_ID="    	    + document.getElementById('hdfSearchEstID').value
                                + "&Q_OBJ_ID="          + document.getElementById('hdfQObjID').value
                                + "&CCB1="              + ICCB1
                               , 700
                               , 400
                               , false
                               , false
                               , "popup_prj_mapping" );
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
            <td colspan="2">
                <table width="100%" cellpadding="0" cellspacing="0" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                            <%--<img src="../images/title/se_ti01.gif" align=absmiddle>--%>
                        </td>
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged" 
                            /><asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" 
                            /><asp:dropdownlist id="ddlEstTermStepID" runat="server" class="box01" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermStepID_SelectedIndexChanged" />
                        </td>
                        <td class="cssTblTitle">
                            평가유형
                        </td>
                        <td  class="cssTblContent">
                            <asp:DropDownList id="ddlEstList" runat="server" widht="100%" class="box01"/>
                            <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged" Visible="False"></asp:dropdownlist>
                            <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:textbox id="txtSearchEstName" runat="server" width="100%" bordercolor="Silver" borderwidth="1px" ></asp:textbox>
                                    </td>
                                    <td style="width:90px;" align="right">
                                        <a href="#null" onclick="SearchEstID();">
                                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td style="width: 209px">
                <%--&nbsp;<asp:image id="imgQTitle" runat="server" imageurl="../images/title/ta_t33.gif" ImageAlign="AbsBottom"></asp:image>--%>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="질의 리스트" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <%--&nbsp;<asp:image id="imgTitle" runat="server" imageurl="../images/title/ta_t36.gif" Height="17px" Width="94px" ImageAlign="AbsBottom"></asp:image>--%>
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="width:15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="사업명 리스트" />
                        </td>
                        <td align="right">
                            <asp:imagebutton id="ibnSearch" runat="server" height="19px" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td style="vertical-align: top; height:expression(eval(document.body.clientHeight)- 310); width: 209px;">
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%" style="left: -4px; top: 233px" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                    <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="EST_ID" HeaderText="EST_ID" Hidden="True"
                                    Key="EST_ID">
                                    <Header Caption="EST_ID">
                                    </Header>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" HeaderText="Q_OBJ_ID" Hidden="True"
                                    Key="Q_OBJ_ID">
                                    <Header Caption="Q_OBJ_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" HeaderText="질의평가그룹" Key="Q_OBJ_NAME"
                                    Width="100%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="질의평가그룹">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_OBJ_TITLE" HeaderText="질의평가그룹 타이틀" Hidden="True"
                                    Key="Q_OBJ_TITLE" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="질의평가그룹 타이틀">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                        Name="UltraWebGrid1" RowHeightDefault="22px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                        StationaryMargins="Header" TableLayout="Fixed" Version="4.00"
                        OptimizeCSSClassNamesOutput="False">
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
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
            <td valign="top">
                <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Height="100%" OnInitializeRow="ugrdPrjList_InitializeRow"
                    Width="100%">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                    <HeaderTemplate>
                                        <asp:checkbox id="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdPrjList');"></asp:checkbox>
                                    </HeaderTemplate>
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server"></asp:checkbox>
                                    </CellTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                    FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID"
                                    Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="PRJ_REF_ID">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="코드" Key="PRJ_CODE" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="코드">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OWNER_DEPT_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="주관부서" Key="OWNER_DEPT_NAME" Width="90px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="주관부서">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText=""
                                    Format="" HeaderText="사업명" Key="PRJ_NAME" Width="160px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ValueList DisplayStyle="NotSet">
                                    </ValueList>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="사업명">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="사업정의" Hidden="True"
                                    Key="DEFINITION">
                                    <Header Caption="사업정의">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="REF_STG" HeaderText="전략목표" Hidden="True" Key="REF_STG">
                                    <Header Caption="전략목표">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EFFECTIVENESS" HeaderText="기대효과" Hidden="True"
                                    Key="EFFECTIVENESS">
                                    <Header Caption="기대효과">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RANGE" HeaderText="사업범위" Hidden="True" Key="RANGE">
                                    <Header Caption="사업범위">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="REQUEST_DEPT" HeaderText="요청부서기관" Hidden="True"
                                    Key="REQUEST_DEPT">
                                    <Header Caption="요청부서기관">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRIORITY" HeaderText="중요도" Hidden="True" Key="PRIORITY">
                                    <Header Caption="중요도">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TOTAL_BUDGET" HeaderText="총사업비" Hidden="True"
                                    Key="TOTAL_BUDGET">
                                    <Header Caption="총사업비">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="INTERESTED_PARTIES" HeaderText="이해관계자" Hidden="True"
                                    Key="INTERESTED_PARTIES">
                                    <Header Caption="이해관계자">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Key="OWNER_EMP_NAME"
                                    Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="책임자">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_TYPE_NAME" HeaderText="사업유형" Key="PRJ_TYPE_NAME"
                                    Width="90px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                    <Header Caption="사업유형">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PRJ_TYPE" HeaderText="사업유형" Hidden="True"
                                    Key="PRJ_TYPE">
                                    <Header Caption="사업유형">
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PLAN_START_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="시작일자" Key="PLAN_START_DATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="시작일자">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="PLAN_END_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="종료일자" Key="PLAN_END_DATE" Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="종료일자">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ACTUAL_START_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="시작일자" Hidden="True" Key="ACTUAL_START_DATE"
                                    Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="시작일자">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ACTUAL_END_DATE" DataType="System.DateTime"
                                    EditorControlID="" FooterText="" HeaderText="종료일자" Hidden="True" Key="ACTUAL_END_DATE"
                                    Width="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="종료일자">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="19" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="ISDELETE" EditorControlID="" FooterText=""
                                    HeaderText="사용여부" Hidden="True" Key="ISDELETE" Width="35px">
                                    <CellTemplate>
                                        <asp:image id="imgUseYn" runat="server" alt="" imagealign="AbsMiddle" imageurl="../images/icon_x.gif"></asp:image>
                                    </CellTemplate>
                                    <HeaderStyle Wrap="True" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="사용여부">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Header>
                                    <Footer Caption="">
                                        <RowLayoutColumnInfo OriginX="20" />
                                    </Footer>
                                </ig:TemplatedColumn>
                            </Columns>
                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                            </RowTemplateStyle>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                        </ig:UltraGridBand>
                    </Bands>
                    
                     <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                        AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                        Name="ugrdPrjList" RowHeightDefault="22px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
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
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
                    
                </ig:UltraWebGrid></td>
        </tr>
        <tr height="40px">
            <td align=right style="width: 209px;" >
                <asp:hiddenfield id="hdfPrjRefID" runat="server"></asp:hiddenfield>
                <asp:hiddenfield id="hdfQObjID" runat="server"></asp:hiddenfield>
                &nbsp;
            </td>
            <td align="right">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td runat="server" id="pnlPrj" visible="false" align="right" style="height: 38px">
                            <A onclick="MappingPrj();" href="#null"><IMG src="../images/btn/b_005.gif" align="absMiddle" border=0 /></A>
                            <asp:imagebutton id="iBtnPrjRemove" onclick="iBtnPrjRemove_Click" runat="server" ImageUrl="../images/btn/b_004.gif" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;
                        </td>
                        <td align="right" style="height: 38px">
                            <asp:imagebutton id="ibnConfirm" runat="server" imageurl="../images/btn/b_015.gif" OnClick="ibnConfirm_Click" Visible="False" ImageAlign="AbsMiddle"></asp:imagebutton>
                            <asp:imagebutton id="ibnConfirmCancel" runat="server" imageurl="../images/btn/b_019.gif" OnClick="ibnConfirmCancel_Click" Visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            &nbsp;            
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
<asp:literal id="ltrScript" runat="server"></asp:literal>
        <asp:linkbutton id="lbnPrjReload" runat="server" onclick="lbnPrjReload_Click"></asp:linkbutton>
<%--<MenuControl:MenuControl_Bottom id="MenuControl_Bottom1" runat="server" />--%>
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    <!--- MAIN END --->
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

