<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST010700.aspx.cs" Inherits="EST_EST010700" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

	<table style="width:100%; height:100%;" cellpadding="0" cellspacing="0" border="0">
	    <tr>
	        <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                            평가방식
                        </td>
                        <td class="cssTblContent" style="border-right:none;">
                            <asp:DropDownList ID="ddlScaleID" runat="server" class="box01" AutoPostBack="True" width="100%" OnSelectedIndexChanged="ddlScaleID_SelectedIndexChanged" />
                        </td>
                        <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                        <td class="cssTblContent">&nbsp;</td>
                    </tr>
                </table>
            </td>
	    </tr>
        <%--<tr style="vertical-align: top; height:expression(eval(document.body.clientHeight) - 310);">--%>
        <tr style="vertical-align: top; height:100%;">
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                    <tr style="height:100%;">
                        <td valign="top" style="width: 50%;">
				            <!-- 메뉴 -- 시작 -->
                            <table cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                                <tr>
                                    <td style="height: 100%" valign="top">
							            <div id="leftLayer" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; width: 100%;  height:expression(eval(document.body.clientHeight)- 200); padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
								            <asp:TreeView ID="TreeView1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" runat="server"  Font-Names="Dotum" Font-Size="8pt" ImageSet="XPFileExplorer" ShowLines="False" NodeIndent="15">
									            <ParentNodeStyle Font-Bold="False" />
									            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />									
								            </asp:TreeView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
				            <!-- 메뉴 -- 끝 -->
                        </td>
                        <td valign="top"> 
				            <table cellpadding="0" cellspacing="0" width="100%" style="width:100%; height:100%">
					            <tr>
						            <td valign="TOP" style="height:100%">
							            <!-- 내용 -- 시작 -->
							            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
								            <Bands>
									            <ig:UltraGridBand>
										            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									            <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									            </RowTemplateStyle>
									            <Columns>
									                <ig:UltraGridColumn BaseColumnName="SCALE_ID" Key="SCALE_ID" Hidden="true">
										            </ig:UltraGridColumn>
										            <ig:UltraGridColumn BaseColumnName="GRADE_ID" Key="GRADE_ID" Hidden="true">
										            </ig:UltraGridColumn>
										            <ig:UltraGridColumn BaseColumnName="START_SCOPE" Key="START_SCOPE" Hidden="true">
										            </ig:UltraGridColumn>
										            <ig:UltraGridColumn BaseColumnName="END_SCOPE" Key="END_SCOPE"  Hidden="true">
										            </ig:UltraGridColumn>
										            <ig:UltraGridColumn BaseColumnName="SCOPE_UNIT_ID" Key="SCOPE_UNIT_ID" Hidden="true">
										            </ig:UltraGridColumn>
										            <ig:UltraGridColumn BaseColumnName="GRADE_TO_POINT" Key="GRADE_TO_POINT" Hidden="true">
										            </ig:UltraGridColumn>
            										
										            <ig:UltraGridColumn BaseColumnName="GRADE_DESC" Key="GRADE_DESC" Width="150px">
											            <Header Caption="등급명"></Header>
											            <HeaderStyle HorizontalAlign="Center" />
											            <CellStyle HorizontalAlign="Center"/>
										            </ig:UltraGridColumn>
										            <ig:TemplatedColumn Key="DDLSCALE_ID" Width="100px" Hidden="true">
											            <Header Caption="평가방법"/>
											            <HeaderStyle HorizontalAlign="Center"/>
											            <CellStyle HorizontalAlign="Center"/>
											            <CellTemplate>
												            <asp:DropDownList ID="ddlScaleId" runat="server" class="box01" />
											            </CellTemplate>
										            </ig:TemplatedColumn>										
										            <ig:TemplatedColumn Key="TXTSTART_SCOPE" Width="100px">
											            <Header Caption="시작 범위"/>
											            <HeaderStyle HorizontalAlign="Center"/>
											            <CellTemplate>
												            <asp:TextBox ID="txtStartScope" runat="server" Width="80" />
											            </CellTemplate>
											            <CellStyle HorizontalAlign="Center"/>
										            </ig:TemplatedColumn>
										            <ig:TemplatedColumn Key="TXTEND_SCOPE" Width="100px">
											            <Header Caption="끝 범위"/>
											            <HeaderStyle HorizontalAlign="Center"/>
											            <CellTemplate>
												            <asp:TextBox ID="txtEndScope" runat="server"  Width="80" />
											            </CellTemplate>											
											            <CellStyle HorizontalAlign="Center"/>
										            </ig:TemplatedColumn>
										            <ig:TemplatedColumn Key="DDLSCOPE_UNIT_ID" Width="100px" Hidden="true">
											            <Header Caption="단위"/>
											            <HeaderStyle HorizontalAlign="Center"/>
											            <CellStyle HorizontalAlign="Center"/>
											            <CellTemplate>
												            <asp:DropDownList ID="ddlScopeUnitId" runat="server" class="box01" Width="80" />
											            </CellTemplate>
										            </ig:TemplatedColumn>
										            <ig:TemplatedColumn Key="TXTGRADE_TO_POINT" Width="100px" Hidden="true">
											            <Header Caption="환산시 점수"/>
											            <HeaderStyle HorizontalAlign="Center"/>
											            <CellTemplate>
												            <asp:TextBox ID="txtGradeToPoint" runat="server" Width="80"/>
											            </CellTemplate>											
											            <CellStyle HorizontalAlign="Center"/>
										            </ig:TemplatedColumn>
									            </Columns>
								            </ig:UltraGridBand>
							            </Bands>
							            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="25px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="CellSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
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
							            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="white">
								            <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
							            </HeaderStyleDefault>
							            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
							            <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
							            <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>--%>
							            
							            <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
							            </DisplayLayout>
						            </ig:UltraWebGrid>
            							
							            <!-- 내용 -- 끝 -->
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="cssPopBtnLine">
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        (절대평가 : 점수, 상대평가 : 퍼센트(%))
                        &nbsp;
                        <asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" align="absmiddle"></asp:ImageButton>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    
<asp:HiddenField ID="hdfEstID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>
