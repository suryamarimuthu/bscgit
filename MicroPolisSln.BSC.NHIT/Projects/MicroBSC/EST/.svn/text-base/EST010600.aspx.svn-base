<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST010600.aspx.cs" Inherits="EST_EST010600" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<script>

	function CheckForm()
	{
		if ( document.all.txtStatusID.value.length == 0 )
		{
			alert( "상태ID를 입력해주세요." );
			return false;
		}	
		else if ( document.all.txtStatusName.value.length == 0 )
		{
			alert( "상태명을 입력해주세요." );
			return false;
		}

		return true;
	}

	function ConfirmYN()
	{
		if ( confirm( "삭제하시겠습니까 ?" ) == true )
		{
			return true;
		}
		
		return false;
	}

	</script>
	<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

   <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            <img align='absmiddle' src='../Images/etc/lis_t01.gif' />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img align='absmiddle' src='../Images/etc/lis_t02.gif' />
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:100%; ">
            <td  valign="top">
                <table cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td>
							<ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
										<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									    <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									    </RowTemplateStyle>
									    <Columns>
									        <ig:UltraGridColumn BaseColumnName="STATUS_STYLE_ID" Key="STATUS_STYLE_ID" Hidden="true">
										    </ig:UltraGridColumn>
									        <ig:UltraGridColumn BaseColumnName="STATUS_STYLE_NAME" Key="STATUS_STYLE_NAME" Width="150px" MergeCells="true">
											    <Header Caption="상태 성격">
												    <RowLayoutColumnInfo OriginX="1" />
											    </Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Center"/>
											    <Footer>
												    <RowLayoutColumnInfo OriginX="1" />
											    </Footer>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="STATUS_ID" Key="STATUS_ID" Width="100px">
											    <Header Caption="상태 ID"></Header>
											    <HeaderStyle HorizontalAlign="Center" />
											    <CellStyle HorizontalAlign="Center"/>
										    </ig:UltraGridColumn>
										    <ig:UltraGridColumn BaseColumnName="STATUS_NAME" Key="STATUS_NAME" Width="200px">
											    <Header Caption="상태명">
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
								<DisplayLayout CellPaddingDefault="2" 
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
								               ViewType="Flat" 
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
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                    <Images>
                                        <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
								</DisplayLayout>
							</ig:UltraWebGrid>						
										
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="height: 40px;">
				            <table class="tableBorder" cellpadding="0" cellspacing="0" width="100%">
					            <tr>
						            <td class="cssTblTitle">상태 ID&nbsp;</td>
						            <td class="cssTblContent" colspan="3">
							            <asp:textbox id="txtStatusID" runat="server" MaxLength="10" Width="60%"></asp:textbox>
							            <asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
						            </td>
					                <td class="cssTblTitle">상태명 &nbsp;</td>
						            <td class="cssTblContent" colspan="3">
							            <asp:textbox id="txtStatusName" runat="server" MaxLength="50" Width="100%"></asp:textbox>
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
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                        <td align="right">
							<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>
                            <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

<asp:HiddenField ID="hdfStatusID" runat="server" /><asp:HiddenField ID="hdfStatusStyleID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>