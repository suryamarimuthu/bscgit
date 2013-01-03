<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST010500.aspx.cs" Inherits="EST_EST010500" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<script>

	function CheckForm()
	{
		if ( document.all.txtGradeID.value.length == 0 )
		{
			alert( "등급ID를 입력해주세요." );
			return false;
		}	
		else if ( document.all.txtGradeName.value.length == 0 )
		{
			alert( "등급명을 입력해주세요." );
			return false;
		}
		else if ( document.all.txtGradeDesc.value.length == 0 )
		{
			alert( "등급설명을 입력해주세요." );
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
        <tr height="25" valign="bottom" width="50%">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            <img align='absmiddle' src='../Images/etc/lis_t01.gif' />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img align='absmiddle' src='../Images/etc/lis_t02.gif' />
                        </td>
                        <td align="right">
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:100%; ">
            <td  valign="top">

				<TABLE id="Table1" style="width:100%;height:100%;" cellSpacing="0" cellPadding="0">
					<TR>
						<TD vAlign="top" align="center" width="100%">
												
							<ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
									<Columns>
									
										<ig:UltraGridColumn BaseColumnName="GRADE_ID" Key="GRADE_ID" Width="100px">
											<Header Caption="등급ID"></Header>
											<HeaderStyle HorizontalAlign="Center" />
											<CellStyle HorizontalAlign="Center"/>
										</ig:UltraGridColumn>
										
										<ig:UltraGridColumn BaseColumnName="GRADE_NAME" Key="GRADE_NAME" Width="100px">
											<Header Caption="등급명">
												<RowLayoutColumnInfo OriginX="1" />
											</Header>
											<HeaderStyle HorizontalAlign="Center" />
											<CellStyle HorizontalAlign="Center"/>
											<Footer>
												<RowLayoutColumnInfo OriginX="1" />
											</Footer>
										</ig:UltraGridColumn>
										
										<ig:UltraGridColumn BaseColumnName="GRADE_DESC" Key="GRADE_DESC" Width="300px" HeaderText="등급설명">
											<Header Caption="등급설명">
												<RowLayoutColumnInfo OriginX="2" />
											</Header>
											<HeaderStyle HorizontalAlign="Center" />
											<CellStyle HorizontalAlign="Left"/>
											<Footer>
												<RowLayoutColumnInfo OriginX="2" />
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
            <td style="height: 60px;">
                <table cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
		
							<table class="tableBorder" cellPadding="0" cellSpacing="0" width="100%">
								<tr>
									<TD class="cssTblTitle"> 등급 ID&nbsp;</td>
									<td class="cssTblContent" colspan="3">
										<asp:textbox id="txtGradeID" runat="server" MaxLength="10" Width="60%"></asp:textbox>
										<asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
									</td>
								</tr>
								<tr>
								    <td class="cssTblTitle">등급명 &nbsp;</td>
									<td class="cssTblContent" colspan="3">
										<asp:textbox id="txtGradeName" runat="server" MaxLength="50" Width="98%"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td class="cssTblTitle"> 등급설명 &nbsp;</td>
									<td class="cssTblContent" style="height: 22px">
										<asp:textbox id="txtGradeDesc" runat="server" TextMode="MultiLine" MaxLength="1000" Width="100%" Height="60px"></asp:textbox>
									</td>
								</TR>
							</table>
							
                                     </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" height="25">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">

							<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>
                            <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>
                            &nbsp;
							
                        </td>
                    </tr>
                </table></td>
        </tr>
    </table>

<asp:HiddenField ID="hdfGradeID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>