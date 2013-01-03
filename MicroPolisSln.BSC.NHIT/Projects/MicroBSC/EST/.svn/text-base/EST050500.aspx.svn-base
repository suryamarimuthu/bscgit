<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST050500.aspx.cs" Inherits="EST_EST050500" ValidateRequest="false" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<form id="form1" runat="server">
	<script>
	
	function CheckForm()
	{
	    
		if ( document.all.txtSubjectText.value.length == 0 )
		{
			alert( "공지사항 제목을 입력해주세요." );
			document.all.txtSubjectText.focus();
			return false;
		}	
		
		if( document.all.cbPopupYN.checked == true)
		{
		    if ( document.all.wdcStartDate.value.length == 0 )
		    {
			    alert( "공지 시작일을 선택해주세요." );
			    return false;
		    }
		    else if	( document.all.wdcEndDate.value.length == 0 )
		    {
			    alert( "공지 종료일을 선택해주세요." );
			    return false;
		    }
		    else if ( document.all.ddlMenuRefID.value.length == 0 )
		    {
			    alert( "팝업설정메뉴를 선택해주세요." );
			    return false;
		    }
		}
		else
		{
		 
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
                        <td align="left">
                            <img align='absmiddle' src='../Images/etc/lis_t01.gif' />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img align='absmiddle' src='../Images/etc/lis_t02.gif' />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="vertical-align: top; height:30%">
            <td>
                <table cellpadding="0" cellspacing="0" height="100%" width="100%">
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
                                        <ig:UltraGridColumn BaseColumnName="BOARD_ID" HeaderText="번호" Key="BOARD_ID" Width="50px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="번호">
                                            </Header>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="SUBJECT_TEXT" HeaderText="제 목" Key="SUBJECT_TEXT"
                                            Width="350px">
                                            <Header Caption="제 목">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="START_DATE" Format="yyyy-MM-dd" HeaderText="공지시작일"
                                            Key="START_DATE" Width="80px">
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="공지시작일">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="END_DATE" Format="yyyy-MM-dd" HeaderText="공지종료일"
                                            Key="END_DATE" Width="80px">
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="공지종료일">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POP_UP_YN" HeaderText="팝업유무" Key="POP_UP_YN"
                                            Width="80px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="팝업유무">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="WRITE_EMP_NAME" HeaderText="작성자" Key="WRITE_EMP_NAME"
                                            Width="100px">
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="작성자">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="WRITE_EMP_ID" Hidden="True" Key="WRITE_EMP_ID">
                                            <Header>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="BOARD_CATEGORY_ID" HeaderText="BOARD_CATEGORY_ID"
                                            Hidden="True" Key="BOARD_CATEGORY_ID" Width="200px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="BOARD_CATEGORY_ID">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
								    </Columns>
								</ig:UltraGridBand>
								</Bands>
								<DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
								<%--    <GroupByBox>
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
                </table>
            </td>
        </tr>
        <tr style="height:70%; padding-top:10px;">
            <td>
                <table class="tableBorder" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td class="cssTblTitle">
                            공지사항제목</td> 
                        <td class="cssTblContent" colspan="3">
                            <asp:textbox id="txtSubjectText" runat="server" MaxLength="100" Width="100%"></asp:textbox>
                        </td> 
                    </tr>
                    <tr style="height:100%;">
                        <td class="cssTblTitle">
                            공지사항내용</td> 
                        <td class="cssTblContent" colspan="3">
                        <FCKeditorV2:FCKeditor ID="txtContentText" runat="server" Width="100%" BasePath="../_common/FCKeditor/" Height="100%" ToolbarSet="Basic">
                            </FCKeditorV2:FCKeditor>
                        </td> 
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            팝업사용여부</td> 
                        <td class="cssTblContent">
                            <asp:checkbox id="cbPopupYN" runat="server" AutoPostBack="True" OnCheckedChanged="cbPopupYN_CheckedChanged" ></asp:checkbox>
                        </td> 
                        <td class="cssTblTitle">
                            공지기간
                        </td>
                         <td class="cssTblContent">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                               <tr>
                                 <td style="width:50%;">
                                    <ig:WebDateChooser ID="wdcStartDate" runat="server" NullDateLabel="" Format="Short" Enabled="False" Width="100%">
                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                    </ig:WebDateChooser> 
                                 </td>
                                 <td style="width:10px;" align="center">&nbsp;~&nbsp;</td>
                                 <td align="left" style="width:50%;">
                                    <ig:WebDateChooser ID="wdcEndDate" runat="server" NullDateLabel="" Enabled="False" Width="100%">
                                        <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                    </ig:WebDateChooser>
                                 </td>
                               </tr>
                            </table>
                        </td> 
                    </tr>
                    <tr>
                        <td class="cssTblTitle">
                            팝업설정메뉴</td> 
                        <td class="cssTblContent">
                            <asp:dropdownlist id="ddlMenuRefID" runat="server" class="box01" width="100%" Enabled="False"></asp:dropdownlist>
                        </td> 
                        <td class="cssTblTitle">
                            작성자
                        </td>
                        <td class="cssTblContent"> 
                            <asp:label id="lblWriteEmpName" runat="server"></asp:label>&nbsp;
                        </td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right">
							<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
							<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click"></asp:ImageButton>
                            <asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdfBoardID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

	</div>
   <asp:literal id="ltrScript" runat="server"></asp:literal>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>