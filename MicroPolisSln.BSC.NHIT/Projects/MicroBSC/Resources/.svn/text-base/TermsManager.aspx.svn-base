<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TermsManager.aspx.cs" Inherits="Resources_TermsManager" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

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
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:expression(eval(document.body.clientHeight) - 310); ">
            <td  valign="top">
                <table cellpadding="0" cellspacing="0" height="100%" width="100%">
                    <tr>
                        <td style="height: 100%" valign="top">
                            <ig:UltraWebGrid id="ugrdResources" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
										<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
									<RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
										<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
									</RowTemplateStyle>
									<Columns>                                    
                                        <ig:UltraGridColumn BaseColumnName="name" HeaderText="KEY"
                                             Type="Custom" Width="100px" Key="KEY">
                                            <Header Caption="KEY">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>                                    
                                        <ig:UltraGridColumn BaseColumnName="value" HeaderText="VALUE"
                                              Type="Custom" Width="300px" AllowUpdate="NO" Key="VALUE">                                       
                                            
                                            <Header Caption="VALUE">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="LEFT"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>                                 
                                    </Columns>
								</ig:UltraGridBand>
								</Bands>
								<DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
								<GroupByBox>
									<Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
								<FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px" Font-Names="Malgun Gothic" Font-Size="8.25pt" Height="100%" Width="100%">
								</FrameStyle>
								<Pager>
									<Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
										<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
									</Style>
								</Pager>

								<AddNewBox Hidden="False">
									<Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
										<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
									</Style>
								</AddNewBox>
								<SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
								<ClientSideEvents />
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
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                    
                                        <table class="tableBorder" cellpadding="0" cellspacing="1" width="100%">
                                            <tr>
                                                <td class="tableTitle" width="120px">KEY</td> 
                                                <td class="tdBorder" colspan="3"> 
                                                    <asp:TextBox id="txtKey" runat="server" Width="100px" ></asp:TextBox>
													<asp:ImageButton  id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td class="tableTitle" width="120px">VALUE</td> 
                                                <td class="tdBorder" colspan="3"> 
                                                     <asp:TextBox id="txtResources" runat="server" Width="400px" ></asp:TextBox>
                                                </td> 
                                            </tr>
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
            <td colspan="3" height="40">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" width="50%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
							<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click"></asp:ImageButton>
                            <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click"></asp:ImageButton>
                            &nbsp;
                        </td>
                    </tr>
                </table></td>
        </tr>
    </table><asp:HiddenField ID="hdfScaleInfo" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>
