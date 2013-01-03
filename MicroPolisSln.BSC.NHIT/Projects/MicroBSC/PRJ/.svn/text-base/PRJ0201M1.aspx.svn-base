<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0201M1.aspx.cs" Inherits="PRJ_PRJ0201M1" %>
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
	//return false;
}

function MappingPrj()
{

  if(document.getElementById('hdfEstEmpID').value == "")
  {
     alert('평가자를 선택하세요.');
     return false;
  }

   var ICCB1           = "<%= this.ICCB1 %>";
   
    gfOpenWindow( "./PRJ0202S1.aspx?COMP_ID=<%= COMP_ID %>"
                                + "&CTRL_VALUE_NAME="	+ "hdfPrjRefID"
                                + "&ESTTERM_REF_ID="	+ document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID="	+ document.getElementById('ddlEstTermSubID').value
                                + "&EST_ID="    	    + document.getElementById('hdfSearchEstID').value
                                + "&CCB1="              + ICCB1
                               , 750
                               , 400
                               , false
                               , false
                               , "popup_prj_mapping" );
	return false;
}



function ViewEstPrjView()
{

	gfOpenWindow( "PRJ0201S1.aspx?COMP_ID=<%=COMP_ID%>"
	                              + "&EST_ID="	        + document.getElementById('hdfSearchEstID').value
                                + "&ESTTERM_REF_ID="	+ document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID="	+ document.getElementById('ddlEstTermSubID').value
                               , 620
                               , 450
                               , true
                               , true
                               , "popup_est_tgt_map" );
	return false;
}

function Search() 
{
    if(document.getElementById('hdfSearchEstID').value == '')
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

<TABLE cellSpacing="0" cellPadding="0" border="0" height="100%" width="100%">
    <TR>
        <TD vAlign="top" align="center" width="100%" colspan="4" height="10">
            <table cellpadding=0 cellspacing=0 border=0 width="100%" class="tableBorder">
                <tr>
                    <td class="cssTblTitle">
                        <%--<img src="../images/title/se_ti01.gif" align=absmiddle>--%>
                        평가기간
                    </td>
                    <td class="cssTblContent">
                        <asp:dropdownlist id="ddlEstTermRefID" runat="server" width="49%" autopostback="True" onselectedindexchanged="ddlEstTermInfo_SelectedIndexChanged" class="box01" 
                        /><asp:dropdownlist id="ddlEstTermSubID" runat="server" width="49%" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSub_SelectedIndexChanged" />
                    </td>
                    <td class="cssTblTitle">
                        <%--<IMG src="../images/title/opt_s03.gif" align=absMiddle />&nbsp;--%>
                        선택차수
                    </td>
                    <td class="cssTblContent">
                        <asp:dropdownlist id="ddlEstTermStepID" runat="server" width="100%" autopostback="True" class="box01"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td class="cssTblTitle">
                        평가종류
                    </td>
                    <td class="cssTblContent" style="border-right:none;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" style="background-color:#cccccc;" borderwidth="1px" width="100%" Text="프로젝트평가"></asp:textbox>
                                </td>
                                <td style="width:90px; padding-right:10px;" align="right">
                                    <a href="#null" onclick="SearchEstID();">
                                        <img align="absMiddle" border="0" src="../images/btn/b_143.gif" style="display:none;" />
                                    </a>
                                </td>
                            </tr>
                        </table>
                        <%-- <a href="#null" onclick="SearchEstID();">
                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" /></a>--%>
                    </td>
                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                    <td class="cssTblContent">&nbsp;</td>
                </tr>
            </table>
        </TD>
    </TR>
    <TR height="30">
        <TD width="50%" style="height: 9px">
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td style="width:15px;">
                        <img src="../images/title/ma_t14.gif" alt="" />
                    </td>
                    <td>
                        <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="평가자" />
                    </td>
                </tr>
            </table>
        </TD>
        <TD style="height: 9px">
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td style="width:15px;">
                        <img src="../images/title/ma_t14.gif" alt="" />
                    </td>
                    <td>
                        <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="선택된 사업명" />
                    </td>
                    <td align="right">
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                    </td>
                    <td align="right" style="padding-right:0px;">
                        <asp:imagebutton id="ibnSearch" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
                        <asp:hiddenfield id="hdfSearchEstID" runat="server" Value="3P"></asp:hiddenfield>
                        <asp:literal id="ltrClearEmpMapping" runat="server"></asp:literal><asp:literal runat="server" id="ltrMapping"></asp:literal><asp:literal id="ltrBeforeRef" runat="server"></asp:literal>&nbsp;
                    </td>
                </tr>
            </table>
        </TD>
    </TR>
    <TR>
        <TD vAlign=top align=center width="50%"  >
         <TABLE width="100%" cellpadding="0" cellspacing="0" border="0" height="100%" >
                <TBODY>
                    <TR>
                        <TD width="30%" vAlign=top style="vertical-align: top; height: expression(eval(document.body.clientHeight)- 310)" >
                            <DIV style="BORDER-RIGHT: #bacfec 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #bacfec 1px solid; DISPLAY: block; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; OVERFLOW: auto; BORDER-LEFT: #bacfec 1px solid; WIDTH: 170px; PADDING-TOP: 2px; BORDER-BOTTOM: #bacfec 1px solid; HEIGHT: 100%" id="Div1">
                                <asp:treeview id="TreeView1" runat="server" onselectednodechanged="TreeView1_SelectedNodeChanged" nodeindent="15" imageset="XPFileExplorer">
                                    <ParentNodeStyle Font-Bold="False"  />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px"  />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px"  />
                                </asp:treeview>
                              
                                <SJ:SmartScroller ID="SmartScroller2" runat="server" MaintainScrollX="true" MaintainScrollY="true"
                                    TargetObject="Div1">
                                    <input name="SmartScroller1_ScrollY" type="hidden" value="0"><input name="SmartScroller1_ScrollX"
                                        type="hidden" value="0"></SJ:SmartScroller>
                            </DIV>
                        </TD>
                            <TD style="vertical-align: top; height:expression(eval(document.body.clientHeight)- 310);" align="center">
                                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="98%" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Hidden="True" Key="EST_DEPT_ID">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Hidden="True" Key="EST_EMP_ID">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_CLS_ID" Hidden="True" Key="EST_POS_CLS_ID">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_DUT_ID" Hidden="True" Key="EST_POS_DUT_ID">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_GRP_ID" Hidden="True" Key="EST_POS_GRP_ID">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_RNK_ID" Hidden="True" Key="EST_POS_RNK_ID">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_CLS_NAME" Hidden="True" Key="EST_POS_CLS_NAME">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="7" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_DUT_NAME" Hidden="True" Key="EST_POS_DUT_NAME">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="8" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_GRP_NAME" Hidden="True" Key="EST_POS_GRP_NAME">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="9" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_EMP_NAME" HeaderText="성명" Key="EST_EMP_NAME"
                                                    Width="50px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="성명">
                                                        <RowLayoutColumnInfo OriginX="10" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="10" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" HeaderText="부서명" Key="EST_DEPT_NAME"
                                                    Width="110px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="부서명">
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="11" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_POS_RNK_NAME" HeaderText="직책" Key="EST_POS_RNK_NAME"
                                                    Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Header Caption="직책">
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="12" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
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
                            </TD>
                        </TR>
                </TBODY>
            </TABLE>
            
        </TD>
        <TD vAlign=top align=center style="vertical-align: top; height: expression(eval(document.body.clientHeight)- 310)">
            <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Height="100%" Width="98%">
                <Bands>
                    <ig:UltraGridBand>
                        <Columns>
                            <ig:TemplatedColumn Key="selchk" Width="30px">
                                <HeaderTemplate>
                                    <asp:checkbox id="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdPrjList');">
</asp:checkbox>
                                </HeaderTemplate>
                                <CellTemplate>
                                    <asp:checkbox id="cBox" runat="server">
</asp:checkbox>
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
                            <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="코드" Key="PRJ_CODE" Width="50px">
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
                                Format="" HeaderText="주관부서" Key="OWNER_DEPT_NAME" Width="130px">
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
                                Format="" HeaderText="사업명" Key="PRJ_NAME" Width="175px">
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
                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Hidden="True" Key="EST_DEPT_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="21" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="21" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Hidden="True" Key="EST_EMP_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="22" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="22" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="STATUS_ID" Hidden="True" Key="STATUS_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="23" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="23" />
                                </Footer>
                            </ig:UltraGridColumn>
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
                        <ClientSideEvents MouseOverHandler="MouseOverHandler" />
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
                        <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                    </DisplayLayout>
            </ig:UltraWebGrid></TD>
               
    </TR>
     <tr>
     <td align="right" style="height: 50px" valign="top">
         &nbsp;</td>
     <td  align="right" style="height: 19px;">
      <a href="#null" onclick="ViewEstPrjView();">
     <img align="absMiddle" border="0" src="../images/btn/b_172.gif" id="imgEstTgtMap" runat="server" /></a>&nbsp;<A onclick="MappingPrj();" href="#null"><IMG src="../images/btn/b_005.gif" align="absMiddle" border=0 id="imgAdd" runat="server" /></A>&nbsp;<asp:imagebutton
                id="iBtnPrjRemove" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_004.gif"
                onclick="iBtnPrjRemove_Click"></asp:imagebutton>
                 <asp:imagebutton id="ibnConfirm" runat="server" imageurl="../images/btn/b_015.gif" OnClick="ibnConfirm_Click" ImageAlign="AbsMiddle"></asp:imagebutton>
             &nbsp;
     
     
     </td>
     </tr>
   
</TABLE>
    
    <asp:literal id="ltrScript" runat="server"></asp:literal>
        <asp:linkbutton id="lbnPrjReload" runat="server" onclick="lbnPrjReload_Click"></asp:linkbutton>
        <asp:hiddenfield id="hdfPrjRefID" runat="server"></asp:hiddenfield>
        <asp:hiddenfield id="hdfEstDeptID" runat="server"></asp:hiddenfield>
        <asp:hiddenfield id="hdfEstEmpID" runat="server"></asp:hiddenfield>
        <%--<SJ:SmartScroller ID="SmartScroller1" runat="server"></SJ:SmartScroller>--%><!--- MAIN END ---><MenuControl:MenuControl_Bottom id="MenuControl_Bottom1" runat="server" /></div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

