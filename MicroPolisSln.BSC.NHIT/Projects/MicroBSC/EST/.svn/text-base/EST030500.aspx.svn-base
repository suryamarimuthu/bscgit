<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST030500.aspx.cs" Inherits="EST_EST030500" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">
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
                           , "popup_est_scheId" );
	//return false;
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

function ShowAssignPosBiz()
{
    if(document.getElementById('hdfSearchEstID').value == "") 
    {
        alert('평가를 선택하세요.');
        return false;
    }

	gfOpenWindow(  "EST030501.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&EST_ID=<%=EST_ID%>"
                           , 660
                           , 400
                           , false
                           , false
                           , "popup_est_assign_pos_biz" );
	return false;
}

</script>

<form id="form1" runat="server">
    <div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    
	<table cellpadding="0" cellspacing="0" border="0" style="width:100%;height:100%">
		<tr>
			<td>
			    <table cellpadding="0" cellspacing="0" border="0" style="width:100%;">
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
			                            <a href="#null" onclick="SearchEstID();"><img align="absMiddle" border="0" src="../images/btn/b_143.gif" /></a>
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
		<tr>
		    <td class="cssPopBtnLine">
		        <asp:imagebutton id="ibnSearch" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif" onclick="ibnSearch_Click"></asp:imagebutton>
		    </td>
		</tr>
        <tr style="vertical-align: top; height:100%">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" style="width:100%;height:100%">
	                <tr>        
                        <td style="width:200;" valign="top">
                            <div style="border:#F4F4F4 3px solid; overflow: auto; width: 100%; height: 100%" id="Div1">
                                <asp:TreeView ID="TreeView1"  runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Dotum" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                            <SJ:SmartScroller id="SmartScroller2" runat="server" TargetObject="Div1" MaintainScrollX="true" MaintainScrollY="true"></SJ:SmartScroller>
                        </td>
                        <td valign="top">
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%" style="left: 0px; top: 233px">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="True">
	                                            <HeaderStyle HorizontalAlign="Center" />
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_ID" Key="Q_OBJ_ID" Hidden="True">
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_ID" Key="Q_SBJ_ID" Hidden="True">
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No">
                                                <CellTemplate>
                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                </CellTemplate>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="Q_OBJ_NAME" Key="Q_OBJ_NAME" Width="200px">
	                                            <HeaderStyle HorizontalAlign="Center" />
	                                            <Header Caption="질의그룹명">
		                                            <RowLayoutColumnInfo OriginX="4" />
	                                            </Header>
	                                            <Footer>
		                                            <RowLayoutColumnInfo OriginX="4" />
	                                            </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="Q_SBJ_NAME" Key="Q_SBJ_NAME" Width="300px">
	                                            <HeaderStyle HorizontalAlign="Center" />
	                                            <Header Caption="질의문항명">
		                                            <RowLayoutColumnInfo OriginX="4" />
	                                            </Header>
	                                            <Footer>
		                                            <RowLayoutColumnInfo OriginX="4" />
	                                            </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout  AllowColSizingDefault="Free" 
                                                AllowColumnMovingDefault="OnServer" 
                                                AllowDeleteDefault="Yes"
                                                AutoGenerateColumns="False" 
                                                BorderCollapseDefault="Separate"
                                                CellClickActionDefault="NotSet" 
                                                CellPaddingDefault="2" 
                                                HeaderClickActionDefault="SortMulti"
                                                Name="UltraWebGrid1" 
                                                RowHeightDefault="22px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended"
                                                StationaryMargins="Header" 
                                                TableLayout="Fixed" 
                                                Version="4.00">
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
                    </tr>
	            </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td align="right">
                <asp:imagebutton id="ibnSave" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_tp07.gif" onclick="ibnSave_Click"></asp:imagebutton>
                <asp:imagebutton id="ibnAssignPosBiz" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_196.gif" OnClientClick="return ShowAssignPosBiz();"></asp:imagebutton>
            </td>
        </tr>
	</table>

    <!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>