<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST010900.aspx.cs" Inherits="EST_EST010900" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<script>
	
		function CheckForm()
		{
			if ( document.all.txtPosID.value.length == 0 )
			{
				alert( "POS_ID를 입력해주세요." );
				return false;
			}	
			else if ( document.all.txtPosName.value.length == 0 )
			{
				alert( "POS_NAME을 입력해주세요." );
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
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
    <tr style="height:50%">
        <td>
            <table cellspacing="0" cellpadding="0" border="0" style="width:100%; height:100%;">
	            <tr style="height:100%;">
		            <td>
			            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange1">
				            <Bands>
					            <ig:UltraGridBand>
						            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
					            <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
						            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
					            </RowTemplateStyle>
					            <Columns>
			                        <ig:UltraGridColumn BaseColumnName="POS_TABLE_NAME" Key="POS_TABLE_NAME" Hidden="True">
						            </ig:UltraGridColumn>
						            <ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Width="80px" Hidden="True">
						            </ig:UltraGridColumn>
						            <ig:UltraGridColumn BaseColumnName="POS_ID" Key="POS_ID" Width="100px" HeaderText="POS_ID">
							            <Header Caption="유형ID"></Header>
							            <HeaderStyle HorizontalAlign="Center" />
							            <CellStyle HorizontalAlign="Center"/>
						            </ig:UltraGridColumn>
            						
						            <ig:UltraGridColumn BaseColumnName="POS_NAME" Key="POS_NAME" Width="150px" HeaderText="POS_NAME">
							            <Header Caption="유형명">
								            <RowLayoutColumnInfo OriginX="1" />
							            </Header>
							            <HeaderStyle HorizontalAlign="Center" />
							            <CellStyle HorizontalAlign="Center"/>
							            <Footer>
								            <RowLayoutColumnInfo OriginX="1" />
							            </Footer>
						            </ig:UltraGridColumn>
						            <ig:TemplatedColumn Key="CHK_BOX" Width="80px" HeaderText="사용여부">
							            <Header Caption="사용여부">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
							            <CellTemplate>
								            <asp:CheckBox ID="cBox" runat="server" />
							            </CellTemplate>
							            <HeaderStyle HorizontalAlign="Center" />
							            <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
						            </ig:TemplatedColumn>				
					            </Columns>
					            </ig:UltraGridBand>
				            </Bands>
				            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">			
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
		            </td>
	            </tr>
	            <tr class="cssPopBtnLine">
		            <td align="right">
			            <asp:ImageButton id="ibtnDataMove" runat="server" ImageUrl="../images/btn/b_002.gif" OnClick="ibtnDataMove_Click"></asp:ImageButton>&nbsp;
		            </td>
	            </tr>
            </table>
        </td>
    </tr>
    <tr style="height:50%;">
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
	            <tr>
		            <td>
			            <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid2_InitializeRow" OnSelectedRowsChange="UltraWebGrid2_SelectedRowsChange">
				            <Bands>
					            <ig:UltraGridBand>
						            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
					            <RowTemplateStyle BorderColor="White" BorderStyle="Ridge" BackColor="White">
						            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"/>
					            </RowTemplateStyle>
					            <Columns>
						            <ig:UltraGridColumn BaseColumnName="POS_ID" Key="POS_ID" Width="100px">
							            <Header Caption="데이터ID"></Header>
							            <HeaderStyle HorizontalAlign="Center" />
							            <CellStyle HorizontalAlign="Center"/>
						            </ig:UltraGridColumn>
						            <ig:UltraGridColumn BaseColumnName="POS_NAME" Key="POS_NAME" Width="200px">
							            <Header Caption="데이터명">
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
				            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="rowselect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
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
				            <FrameStyle Cursor="hand" BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
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
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
	            <tr>
		            <td>
			            <!-- 내용 -- 시작 -->
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
				            <tr>
					            <TD class="cssTblTitle">데이터ID</td>
					            <td class="cssTblContent">
					                <table width="100%" border="0" cellspacing="0" cellpadding="0">
					                    <tr>
					                        <td>
					                            <asp:textbox id="txtPosID" runat="server" MaxLength="4" Width="100%" onkeydown="javascript:if ( event.keyCode ==13 ) return CheckForm();"></asp:textbox>
					                        </td>
					                        <td style="width:90px;" align="right">
					                            <asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>						
					                        </td>
					                    </tr>
					                </table>
					            </td>
					            <TD class="cssTblTitle">데이터명</td>
					            <td class="cssTblContent">
						            <asp:textbox id="txtPosName" runat="server" MaxLength="25" onkeydown="javascript:if ( event.keyCode ==13 ) return CheckForm();" width="100%"></asp:textbox>
					            </td>
				            </tr>
			            </table>
			            <!-- 내용 -- 끝 -->
		            </td>
	            </tr>
	            <tr class="cssPopBtnLine">
	                <td>
	                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
				            <tr>
					            <td colspan="2" align="right" height="40">
						            <asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
						            <asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>
						            <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>						
					            </td>
				            </tr>				
			            </table>
	                </td>
	            </tr>
            </table>
        </td>
    </tr>
</table>

<asp:HiddenField ID="hdfPosInfoID" runat="server" />
<asp:HiddenField ID="hdfPosID" runat="server" />
<asp:literal id="ltrScript" runat="server"></asp:literal>
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>