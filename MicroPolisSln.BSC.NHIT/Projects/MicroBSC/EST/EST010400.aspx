﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST010400.aspx.cs" Inherits="EST_EST010400" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<script language="javascript">

	function CheckForm()
	{
		if ( document.all.txtEstTermSubID.value.length == 0 )
		{
			alert( "평가주기ID를 입력해주세요." );
			return false;
		}	
		else if ( document.all.txtEstTermSubName.value.length == 0 )
		{
			alert( "평가주기명을 입력해주세요." );
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
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:100%; ">
            <td  valign="top">
                <table cellpadding="0" cellspacing="0" height="100%" width="100%">
                    <tr>
                        <td style="height: 100%" valign="top">
                            <ig:UltraWebGrid id="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
								<Bands>
									<ig:UltraGridBand>
									<Columns>
										<ig:UltraGridColumn BaseColumnName="SCALE_ID" Key="SCALE_ID" Width="100px">
											<Header Caption="평가방식ID"></Header>
											<HeaderStyle HorizontalAlign="Center" />
											<CellStyle HorizontalAlign="Center"/>
										</ig:UltraGridColumn>
										<ig:UltraGridColumn BaseColumnName="SCALE_NAME" Key="SCALE_NAME" Width="200px">
											<Header Caption="평가방식명">
												<RowLayoutColumnInfo OriginX="1" />
											</Header>
											<HeaderStyle HorizontalAlign="Center" />
											<CellStyle HorizontalAlign="Center"/>
											<Footer>
												<RowLayoutColumnInfo OriginX="1" />
											</Footer>
										</ig:UltraGridColumn>
										<ig:UltraGridColumn BaseColumnName="USE_YN" Key="USE_YN" Width="100px">
											<Header Caption="사용여부">
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
        <tr style="height:10px;"><td>&nbsp;</td></tr>
        <tr>
            <td style="height: 60px;">
                <table cellpadding="0" cellspacing="0" width="100%" class="tableBorder" style="height:100%;">
                    <tr>
                        <td class="cssTblTitle">평가방법 ID</td> 
                        <td class="tdBorder" colspan="3"> 
                            <asp:textbox id="txtScaleID" runat="server" MaxLength="10" Width="60%" Enabled="false"></asp:textbox>
							<asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
                        </td> 
                    </tr>
                    <tr>
                        <td class="cssTblTitle">평가방법</td> 
                        <td class="tdBorder" colspan="3"> 
                            <asp:textbox id="txtScaleName" runat="server" MaxLength="50" Width="98%"></asp:textbox>
                        </td> 
                    </tr>
                    <tr>
                        <td class="cssTblTitle">사용여부</td> 
                        <td class="tdBorder" colspan="3"> 
                            <asp:checkbox id="cbUseYN" runat="server"></asp:checkbox>
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