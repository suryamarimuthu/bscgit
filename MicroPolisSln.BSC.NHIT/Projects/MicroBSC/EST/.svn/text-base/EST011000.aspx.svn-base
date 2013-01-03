<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST011000.aspx.cs" Inherits="EST_EST011000" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<div>

<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

<TABLE cellSpacing="0" cellPadding="0" border="0" style="width:100%; height:100%;">
    <tr>
     <td>
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td style="width:15px;">
                    <img src="../images/title/ma_t14.gif" alt="" />
                </td>
                <td>
                    <asp:Label id="lblTitle1" runat="server" style="font-weight:bold" text="직종" />
                </td>
            </tr>
        </table>
      </td>
      <td>
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td style="width:15px;">
                    <img src="../images/title/ma_t14.gif" alt="" />
                </td>
                <td>
                    <asp:Label id="lblTitle2" runat="server" style="font-weight:bold" text="직무" />
                </td>
            </tr>
        </table>
      </td>
      <td>
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td style="width:15px;">
                    <img src="../images/title/ma_t14.gif" alt="" />
                </td>
                <td>
                    <asp:Label id="lblTitle3" runat="server" style="font-weight:bold" text="직종&amp;직무매핑" />
                </td>
            </tr>
        </table>
      </td>
    </tr>
	<TR style="vertical-align: top; height:100%">
		<TD vAlign="top" style="width: 30%">
		<div id="leftLayer">
			<ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
				<Bands>
					<ig:UltraGridBand>
						<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
					<RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
						<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
					</RowTemplateStyle>
					<Columns>
                        <ig:UltraGridColumn BaseColumnName="POS_KND_ID" HeaderText="직종ID" Key="POS_KND_ID"
                            Width="70px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="직종ID">
                            </Header>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POS_KND_NAME" HeaderText="직종명" Key="POS_KND_NAME"
                            Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="직종명">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
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
				                AllowSortingDefault="Yes" 
				                BorderCollapseDefault="Separate" 
				                HeaderClickActionDefault="SortMulti" 
				                Name="UltraWebGrid1" 
				                RowHeightDefault="20px" 
				                RowSelectorsDefault="No" 
				                SelectTypeRowDefault="Extended" 
				                Version="4.00" 
				                CellClickActionDefault="RowSelect" 
				                TableLayout="Fixed" 
				                StationaryMargins="Header" 
				                AutoGenerateColumns="False"
				                OptimizeCSSClassNamesOutput="False">			
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
				<HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
					<BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
				</HeaderStyleDefault>
				<EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
				<FrameStyle Cursor="Hand" BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
			BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
				<SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                    <ActivationObject BorderColor="" BorderWidth="">
                    </ActivationObject>--%>
                    
                    <RowStyleDefault  CssClass="GridRowStyle" />
                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
				</DisplayLayout>
			</ig:UltraWebGrid>
			</div>
			<SJ:SmartScroller id="SmartScroller1" runat="server" MaintainScrollY="true" MaintainScrollX="true" TargetObject="leftLayer"></SJ:SmartScroller>			
		</TD>
		<TD vAlign="top" width="35%" >
			<ig:UltraWebGrid id="UltraWebGrid3" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid3_InitializeRow" OnInitializeLayout="UltraWebGrid3_InitializeLayout" >
				<Bands>
					<ig:UltraGridBand>
						<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
					<RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
						<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
					</RowTemplateStyle>
					<Columns>
                        <ig:TemplatedColumn Key="CHK_BOX" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No">
                            <CellTemplate>
                                <asp:CheckBox ID="cBox" runat="server" />
                            </CellTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid3');" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center"  />
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="POS_BIZ_ID" Key="POS_BIZ_ID" Width="60px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="직무ID">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POS_BIZ_NAME" Key="POS_BIZ_NAME" Width="160px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="직무명">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
					</Columns>
					</ig:UltraGridBand>
				</Bands>
				<DisplayLayout CellPaddingDefault="2" 
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
                                ReadOnly="LevelTwo"
                                CellClickActionDefault="NotSet" 
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
				    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
					    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
				    </HeaderStyleDefault>
				    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
				    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
		</TD>
		<TD width="35%">
		<ig:UltraWebGrid id="UltraWebGrid2" runat="server" Width="280px" Height="100%" OnInitializeRow="UltraWebGrid2_InitializeRow" OnInitializeLayout="UltraWebGrid2_InitializeLayout">
				<Bands>
					<ig:UltraGridBand>
						<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
					<RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
						<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
					</RowTemplateStyle>
					<Columns>
                        <ig:UltraGridColumn BaseColumnName="POS_KND_ID" HeaderText="POS_KND_ID" Hidden="True"
                            Key="POS_KND_ID" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="POS_KND_ID">
                            </Header>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POS_BIZ_ID" HeaderText="POS_BIZ_ID" Hidden="True"
                            Key="POS_BIZ_ID" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="POS_BIZ_ID">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POS_KND_NAME" HeaderText="직종명" Key="POS_KND_NAME"
                            MergeCells="True" Width="130px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="직종명">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POS_BIZ_NAME" HeaderText="직무명" Key="POS_BIZ_NAME"
                            Width="130px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                            <Header Caption="직무명">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
					</Columns>
					</ig:UltraGridBand>
				</Bands>
				<DisplayLayout CellPaddingDefault="2" 
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
                                ReadOnly="LevelTwo"
                                CellClickActionDefault="NotSet" 
                                TableLayout="Fixed" 
                                StationaryMargins="Header" 
                                AutoGenerateColumns="False"
                                OptimizeCSSClassNamesOutput="False">
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
				    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
					    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
				    </HeaderStyleDefault>
				    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px"></EditCellStyleDefault>
				    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="280px">
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
		</TD>
	</tr>
	<tr class="cssPopBtnline">
		<td colspan="3" align="right">
            <asp:HiddenField ID="hdfPoskndID" runat="server" />
            <asp:HiddenField ID="hdfPosID" runat="server" />
            <asp:literal id="ltrScript" runat="server"></asp:literal>
			<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" ></asp:ImageButton>&nbsp;
		</td>
	</tr>
</TABLE>

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>