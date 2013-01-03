<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST050400.aspx.cs" Inherits="EST_EST050400" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">

	function CheckForm()
	{
		if ( document.all.txtEstTermSubID.value.length == 0 )
		{
			alert( "평가주기ID를 입력해주세요." );
			document.all.txtEstTermSubID.focus();
			return false;
		}	
		else if ( document.all.txtEstTermSubName.value.length == 0 )
		{
			alert( "평가주기명을 입력해주세요." );
			document.all.txtEstTermSubName.focus();			
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

<form id="form1" runat="server">
	<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr height="25" valign="bottom" width="50%">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;
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
        <tr style="vertical-align: top; height:expression(eval(document.body.clientHeight)- 280); ">
            <td  valign="top">
                <table cellpadding="0" cellspacing="0" height="100%" width="100%">
                    <tr>
                        <td style="height: 100%" valign="top">
                            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
										<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									<RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									</RowTemplateStyle>
									<Columns>
                                        <ig:UltraGridColumn BaseColumnName="COL_STYLE_ID" HeaderText="컬럼스타일ID" Key="COL_STYLE_ID"
                                            Width="100px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="컬럼스타일ID">
                                            </Header>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COL_STYLE_NAME" HeaderText="컬럼스타일명" Key="COL_STYLE_NAME"
                                            Width="200px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="컬럼스타일명">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
																				
										</Columns>
									</ig:UltraGridBand>
								</Bands>
								<DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
								<GroupByBox>
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
									<BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
								</HeaderStyleDefault>
								<EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
								<FrameStyle Cursor="Hand" BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
								<SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
								<ClientSideEvents />
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>
								</DisplayLayout>
							</ig:UltraWebGrid>	                                                       
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="tableOutBorder" width="100%">
                    <tr>
                        <td>
                            <%--<table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table class="tableBorder" cellpadding="0" cellspacing="1" width="100%">
                                            <tr>
                                                <td class="tableTitle" width="120px">
                                                    컬럼스타일 ID</td> 
                                                <td class="tdBorder" colspan="3"> 
                                                    <asp:textbox id="txtColStyleID" runat="server" MaxLength="10" Width="60%" Enabled="false"></asp:textbox>
													<asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td class="tableTitle" width="120px">
                                                    컬럼스타일명</td> 
                                                <td class="tdBorder" colspan="3"> 
                                                    <asp:textbox id="txtColStyleName" runat="server" MaxLength="50" Width="98%"></asp:textbox>
                                                </td> 
                                            </tr>
                                        </table>
                                     </td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" height="40">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
							
                            &nbsp;
                        </td>
                    </tr>
                </table></td>
        </tr>
    </table>

    <asp:HiddenField ID="hdfColStyleID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>