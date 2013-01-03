<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST040103.aspx.cs" Inherits="EST_EST040103" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>EST040103</title>
	<link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
	<link rel="stylesheet" href="/_common/css/treeStyle.css" type="text/css" />
	<script type="text/javascript" src="../_common/js/common.js"></script>
	<script type="text/javascript" src="/_common/js/picker.js"></script>
	<script type="text/javascript" src="/_common/js/iezn_embed_patch.js" ></script>
	<script type="text/javascript">

	    function MouseOverHandler(gridName, id, objectType) {
	        if (objectType == 0) {
	            var cell = igtbl_getElementById(id);
	            var row = igtbl_getRowById(id);
	            var band = igtbl_getBandById(id);
	            var active = igtbl_getActiveRow(id);
	            cell.style.cursor = 'hand';
	        }
	    }

	    function ShowEstDeptID() {
	        gfOpenWindow("EST_DEPT.aspx?COMP_ID=<%=COMP_ID%>"
	                                + "&ESTTERM_REF_ID=<%= ESTTERM_REF_ID.ToString() %>"
									+ "&CTRL_VALUE_NAME=" + "hdfEstDept"
									+ "&CTRL_TEXT_NAME=" + "txtEstDept"
									+ "&CHECKBOX_YN=" + "Y"
									+ "&CTRL_VALUE_VALUE=" + document.getElementById('hdfEstDept').value
								   , 430
								   , 400
								   , false
								   , false
								   , "popup_est_dept");
	        return false;
	    }

	    function ValidRelGrp() {
	        if (document.getElementById('hdfRelGrpID').value == '') {
	            alert('상대평가 그룹 직급정보를 선택하세요.');
	            return false;
	        }

	        return true;
	    }

	    function ValidRelGrpPosData() {
	        if (document.getElementById('hdfRelGrpPosID').value == '') {
	            alert('상대평가 그룹 직급정보를 선택하세요.');
	            return false;
	        }

	        return true;
	    }

	    function ViewRefGrp() {
	        gfOpenWindow("EST060101.aspx?COMP_ID=<%=COMP_ID%>"
	                                    + "&EST_ID=" + document.getElementById('hdfSearchEstID').value
                                        + "&ESTTERM_REF_ID=" + document.getElementById('ddlEstTermRefID').value
                                        + "&ESTTERM_SUB_ID=" + document.getElementById('ddlEstTermSubID').value
                                       , 620
                                       , 450
                                       , true
                                       , true
                                       , "popup_est_tgt_map");
	        return false;
	    }

	    function ViewEmpList(comp_id, est_id, estterm_ref_id, rel_grp_id) {
	        gfOpenWindow("EST040105.aspx?COMP_ID=" + comp_id
	                                    + "&EST_ID=" + est_id
                                        + "&ESTTERM_REF_ID=" + estterm_ref_id
                                        + "&REL_GRP_ID=" + rel_grp_id
                                       , 680
                                       , 450
                                       , true
                                       , true
                                       , "popup_est_tgt_map");
	        return false;
	    }

	    function doDeletingDownLevel(obj) {
	        var reval = doChecking(obj);
	        if (reval)
	            return confirm("하위 항목까지 전부 삭제 됩니다.\r\n\r\n계속 진행 할까요?");

	        return reval
	    }

	    function doDeleting(obj) {
	        var reval = doChecking(obj);
	        if (reval)
	            return confirm("선택한 항목을 삭제 할까요?");

	        return reval
	    }

	    function doChecking(obj) {
	        var _elements = document.forms[0].elements;
	        var chkCnt = 0;

	        for (var i = 0; i < _elements.length; i++) {
	            if (_elements[i].id.indexOf(obj) >= 0 && _elements[i].type == "checkbox") {
	                if (_elements[i].checked)
	                    chkCnt++;
	            }
	        }

	        if (chkCnt == 0) {
	            alert("삭제할 항목을 선택하세요.");
	            return false;
	        }

	        return true;
	    }
	</script>
</head>
<body style="margin:0 0 0 0">
    <form id="form1" runat="server">
    <div>
    
		<table cellpadding="0" cellspacing="0" width="100%" style="width:100%; height:100%">
			<tr>
				<td>
					<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
						<tr style="height:100px;">
							<td>
								<ig:UltraWebGrid id="uwgRelGroup" runat="server" Height="100%" Width="100%" OnInitializeRow="uwgRelGroup_InitializeRow" OnSelectedRowsChange="uwgRelGroup_SelectedRowsChange">
									<Bands>
										<ig:UltraGridBand>
											<AddNewRow View="NotSet" Visible="NotSet">
											</AddNewRow>
											<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
												<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
											</RowTemplateStyle>
											<Columns>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_ID" Key="REL_GRP_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
													<Header>
														<RowLayoutColumnInfo OriginX="1" />
													</Header>
													<Footer>
														<RowLayoutColumnInfo OriginX="1" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
													<Header>
														<RowLayoutColumnInfo OriginX="2" />
													</Header>
													<Footer>
														<RowLayoutColumnInfo OriginX="2" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_NAME" Key="REL_GRP_NAME" Width="230px" HeaderText="상대평가 그룹명">
													<Header Caption="상대평가 그룹명">
														<RowLayoutColumnInfo OriginX="3" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Left"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="3" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_DESC" Key="REL_GRP_DESC" Width="250px" HeaderText="상대평가 그룹 설명">
													<Header Caption="상대평가 그룹 설명">
														<RowLayoutColumnInfo OriginX="4" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<Footer>
														<RowLayoutColumnInfo OriginX="4" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="" Key="EMP_LIST" Width="15%" HeaderText="평가대상자" >
													<Header Caption="대상자 보기">
														<RowLayoutColumnInfo OriginX="4" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<Footer>
														<RowLayoutColumnInfo OriginX="4" />
													</Footer>
													<CellStyle HorizontalAlign="Center"></CellStyle>
												</ig:UltraGridColumn>
											</Columns>
										</ig:UltraGridBand>
									</Bands>
									<DisplayLayout  CellPaddingDefault="2" 
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
                                                    CellClickActionDefault="RowSelect" 
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
                                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
										<ClientSideEvents />--%>
										
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
						<tr style="padding-bottom:20px;">
					        <td>
					            <table width="100%" cellpadding="0" cellspacing="0">
					                <tr>
					                    <td>
					                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
					                            <tr>
					                                <td class="cssTblTitle">그룹명</td>
					                                <td class="cssTblContent"><asp:textbox id="txtRelGrpName" runat="server" Width="99%" MaxLength="25"></asp:textbox></td>
					                                <td class="cssTblTitle">그룹설명</td>
					                                <td class="cssTblContent">
					                                    <asp:textbox id="txtRelGrpDesc" runat="server" Width="99%" MaxLength="100"></asp:textbox>
											            <asp:hiddenfield id="hdfRelGrpID" runat="server"></asp:hiddenfield>
					                                </td>
					                            </tr>
					                        </table>
					                    </td>
					                </tr>
					                <tr>
					                    <td align="right">
						                    <asp:ImageButton ID="ibnValidCheck" runat="server" ImageUrl="../images/btn/b_168.gif" ImageAlign="AbsMiddle" OnClick="ibnValidCheck_Click"/>
                                            <asp:ImageButton ID="ibnRelGrpTgtMap" runat="server" ImageUrl="../images/btn/b_169.gif" ImageAlign="AbsMiddle" OnClick="ibnRelGrpTgtMap_Click"/>
                                            <asp:imagebutton id="ibnNewRelGrp" runat="server" imageurl="../images/btn/b_156.gif" OnClick="ibnNewRelGrp_Click" ImageAlign="AbsMiddle"/>
							                <asp:imagebutton id="ibnSaveRelGrp" runat="server" imageurl="../images/btn/b_002.gif" OnClick="ibnSaveRelGrp_Click" ImageAlign="AbsMiddle"/>
							                <asp:ImageButton ID="ibnDeleteRelGrp" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDeleteRelGrp_Click" ImageAlign="AbsMiddle" OnClientClick="return confirm('하위 항목까지 전부 삭제 됩니다.\r\n\r\n계속 진행 할까요?');"/>
					                    </td>
					                </tr>
					            </table>
					        </td>
					    </tr>
					    
					    
					    
					    
					    
						<tr style="height:100px;">
							<td>
								<ig:UltraWebGrid id="uwgRelGroupDept" runat="server" Height="100%" Width="100%">
									<Bands>
										<ig:UltraGridBand>
											<AddNewRow View="NotSet" Visible="NotSet">
											</AddNewRow>
											<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
												<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
											</RowTemplateStyle>
											<Columns>
												<ig:TemplatedColumn Key="selchk" Width="30px">
													<CellTemplate>
														<asp:CheckBox ID="cBox" runat="server" />
													</CellTemplate>
													<CellStyle HorizontalAlign="Center">
													</CellStyle>
													<HeaderTemplate>
														<asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'uwgRelGroupDept');" />
													</HeaderTemplate>
													<HeaderStyle HorizontalAlign="Center" />
												</ig:TemplatedColumn>
												<ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_ID" Key="REL_GRP_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="100%" HeaderText="부서명">
													<Header Caption="부서명">
														<RowLayoutColumnInfo OriginX="4" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Left"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="4" />
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
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="UltraWebGrid1" 
                                                    ReadOnly="LevelTwo"
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
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
                                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>--%>
                                        
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
						<tr style="padding-bottom:20px;">
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
                                                <tr>
                                                    <td class="cssTblTitle">선택부서</td>
                                                    <td class="cssTblContent" style="border-right:none;">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:textbox id="txtEstDept" runat="server" maxlength="100" width="100%"></asp:textbox>
                                                                    <asp:hiddenfield id="hdfEstDept" runat="server"></asp:hiddenfield>
                                                                </td>
                                                                <td style="width:90px;" align="right">
                                                                    <a href="#" onclick="return ShowEstDeptID()"><IMG src="../images/btn/b_147.gif" align="absMiddle" border="0" /></a>
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
							            <td align="right">
								            <asp:imagebutton id="ibnSaveRelGrpDept" runat="server" imageurl="../images/btn/b_tp07.gif" OnClick="ibnSaveRelGrpDept_Click" ImageAlign="AbsMiddle"/>
								            <asp:ImageButton ID="ibnDeleteRelGrpDept" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDeleteRelGrpDept_Click" ImageAlign="AbsMiddle" OnClientClick="return doDeleting('uwgRelGroupDept');"/>
							            </td>
						            </tr>
                                </table>
                            </td>
                        </tr>
						
						
						
						
						
						<tr style="height:100px;">
							<td>
								<ig:UltraWebGrid id="uwgRelGrpPosInfo" runat="server" Height="100%" Width="100%" OnSelectedRowsChange="uwgRelGrpPos_SelectedRowsChange">
									<Bands>
										<ig:UltraGridBand>
											<AddNewRow View="NotSet" Visible="NotSet">
											</AddNewRow>
											<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
												<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
											</RowTemplateStyle>
											<Columns>
												<ig:TemplatedColumn Key="selchk" Width="30px">
													<CellTemplate>
														<asp:CheckBox ID="cBox" runat="server" />
													</CellTemplate>
													<CellStyle HorizontalAlign="Center">
													</CellStyle>
													<HeaderTemplate>
														<asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'uwgRelGrpPosInfo');" />
													</HeaderTemplate>
													<HeaderStyle HorizontalAlign="Center" />
												</ig:TemplatedColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_POS_ID" Key="REL_GRP_POS_ID" Hidden="True">
													<Header>
														<RowLayoutColumnInfo OriginX="1" />
													</Header>
													<Footer>
														<RowLayoutColumnInfo OriginX="1" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_ID" Key="REL_GRP_ID" Hidden="True">
													<Header>
														<RowLayoutColumnInfo OriginX="2" />
													</Header>
													<Footer>
														<RowLayoutColumnInfo OriginX="2" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
													<Header>
														<RowLayoutColumnInfo OriginX="3" />
													</Header>
													<Footer>
														<RowLayoutColumnInfo OriginX="3" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
													<Header>
														<RowLayoutColumnInfo OriginX="4" />
													</Header>
													<Footer>
														<RowLayoutColumnInfo OriginX="4" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="OPT_VALUE" Key="OPT_VALUE" Width="60px" HeaderText="연산자">
													<Header Caption="연산자">
														<RowLayoutColumnInfo OriginX="5" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Center"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="5" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_POS_NAME" Key="REL_GRP_POS_NAME" Width="120px" HeaderText="직급군 그룹명">
													<Header Caption="직급군 그룹명">
														<RowLayoutColumnInfo OriginX="6" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Center"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="6" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_POS_NAME" Key="REL_GRP_POS_DESC" Width="50%" HeaderText="직급군 그룹 설명">
													<Header Caption="직급군 그룹 설명">
														<RowLayoutColumnInfo OriginX="7" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Center"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="7" />
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
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="UltraWebGrid1" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    CellClickActionDefault="RowSelect" 
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
                                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
										<ClientSideEvents />--%>
										
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
						<tr id="trRelPos" runat="server" style="padding-bottom:20px;">
							<td>
								<table width="100%" cellpadding="0" cellspacing="0">
									<tr>
										<td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
                                                <tr>
                                                    <td class="cssTblTitle">연산자</td>
                                                    <td class="cssTblContent">
                                                        <asp:dropdownlist id="ddlOptValue" runat="server" class="box01" Width="99%">
                                                            <asp:ListItem>AND</asp:ListItem>
											                <asp:ListItem>OR</asp:ListItem>
										                </asp:dropdownlist>
                                                    </td>
                                                    <td class="cssTblTitle">그룹명</td>
                                                    <td class="cssTblContent"><asp:textbox id="txtRelGrpPosName" runat="server" width="99%"></asp:textbox></td>
                                                </tr>
                                                <tr>
                                                    <td class="cssTblTitle">그룹설명</td>
                                                    <td class="cssTblContent">
                                                        <asp:textbox id="txtRelGrpPosDesc" runat="server" width="99%"></asp:textbox>
                                                        <asp:hiddenfield id="hdfRelGrpPosID" runat="server"></asp:hiddenfield>
                                                    </td>
                                                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                                    <td class="cssTblContent">&nbsp;</td>
                                                </tr>
                                            </table>
										</td>
									</tr>
									<tr>
										<td align="right">
											<asp:imagebutton id="ibnNewRelGrpPos" runat="server" imageurl="../images/btn/b_156.gif" OnClick="ibnNewRelGrpPos_Click" ImageAlign="AbsMiddle"/>
											<asp:imagebutton id="ibnSaveRelGrpPos" runat="server" imageurl="../images/btn/b_002.gif" OnClick="ibnSaveRelGrpPos_Click" ImageAlign="AbsMiddle"/>
											<asp:ImageButton ID="ibnDeleteRelGrpPos" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="iBtnRemoveGroupPosition_Click" ImageAlign="AbsMiddle" OnClientClick="return doDeletingDownLevel('uwgRelGrpPosInfo');"/>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						
						
						
						
						
						<tr style="height:100px;">
							<td>
								<ig:UltraWebGrid id="uwgRelGrpPosData" runat="server" Height="100%" Width="100%" OnInitializeRow="uwgRelGrpPosData_InitializeRow">
									<Bands>
										<ig:UltraGridBand>
											<AddNewRow View="NotSet" Visible="NotSet">
											</AddNewRow>
											<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
												<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
											</RowTemplateStyle>
											<Columns>
												<ig:TemplatedColumn Key="selchk" Width="30px">
													<CellTemplate>
														<asp:CheckBox ID="cBox" runat="server" />
													</CellTemplate>
													<CellStyle HorizontalAlign="Center">
													</CellStyle>
													<HeaderTemplate>
														<asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'uwgRelGrpPosData');" />
													</HeaderTemplate>
													<HeaderStyle HorizontalAlign="Center" />
												</ig:TemplatedColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_POS_DATA_ID" Key="REL_GRP_POS_DATA_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="REL_GRP_POS_ID" Key="REL_GRP_POS_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
												</ig:UltraGridColumn>

												<ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="POS_ID" Key="POS_ID" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="POS_VALUE" Key="POS_VALUE" Hidden="True">
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="OPT_VALUE" Key="OPT_VALUE" Width="60px" HeaderText="연산자">
													<Header Caption="연산자">
														<RowLayoutColumnInfo OriginX="7" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Center"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="7" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="POS_ID_NAME" Key="POS_ID_NAME" Width="120px" HeaderText="직급군 타입">
													<Header Caption="구분인자 타입">
														<RowLayoutColumnInfo OriginX="8" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Center"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="8" />
													</Footer>
												</ig:UltraGridColumn>
												<ig:UltraGridColumn BaseColumnName="POS_VALUE_NAME" Key="POS_VALUE_NAME" Width="50%" HeaderText="직급군 설정값">
													<Header Caption="구분인자 설정값">
														<RowLayoutColumnInfo OriginX="9" />
													</Header>
													<HeaderStyle HorizontalAlign="Center" />
													<CellStyle HorizontalAlign="Center"/>
													<Footer>
														<RowLayoutColumnInfo OriginX="9" />
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
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="UltraWebGrid1" 
                                                    ReadOnly="LevelTwo"
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
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
										<HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
											<BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
										</HeaderStyleDefault>
										<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
											BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
										<SelectedRowStyleDefault BackColor="#E2ECF4">
										</SelectedRowStyleDefault>
										<ClientSideEvents />--%>
										
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
						<tr id="trRelPosData" runat="server">
							<td>
								<table cellspacing="0" cellpadding="0" width="100%">
									<tr>
										<td>
										    <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
                                                        <tr>
                                                            <td class="cssTblTitle">연산자</td>
                                                            <td class="cssTblContent">
                                                                <asp:DropDownList id="ddlOptValueData" class="box01" runat="server" Width="99%">
							                                        <asp:ListItem>AND</asp:ListItem>
							                                        <asp:ListItem>OR</asp:ListItem>
						                                        </asp:DropDownList>
						                                    </td>
                                                            <td class="cssTblTitle">타입</td>
                                                            <td class="cssTblContent"><asp:DropDownList id="ddlPosID" class="box01" runat="server" OnSelectedIndexChanged="ddlPosID_SelectedIndexChanged" AutoPostBack="True" Width="99%"></asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssTblTitle">설정값</td>
                                                            <td class="cssTblContent" style="border-right:none;"><asp:DropDownList id="ddlPosValue" class="box01" runat="server" Width="99%"></asp:DropDownList></td>
                                                            <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                                            <td class="cssTblContent">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
										</td>
									</tr>
									<tr>
										<td align="right">
											<asp:imagebutton id="ibnSaveRelGrpPosData" runat="server" OnClick="ibnSaveRelGrpPosData_Click" ImageUrl="../images/btn/b_tp07.gif" ImageAlign="AbsMiddle"></asp:imagebutton>
											<asp:ImageButton ID="ibnDeleteRelGrpPosData" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDeleteRelGrpPosData_Click" ImageAlign="AbsMiddle" OnClientClick="return doDeleting('uwgRelGrpPosData');" />
											<!--a href="#null" onclick="ViewRefGrp();"><img src="../images/btn/b_104.gif" align="absmiddle" /></a--> 
											<asp:label id="lblCompTitle" runat="server"></asp:label>
                                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
										</td> 
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    
    </div>
    
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>    
    
<asp:HiddenField ID="hdfEstId" runat="server" />
<asp:HiddenField ID="hdfWeightType" runat="server" />
<asp:HiddenField ID="hdfDeptRefID" runat="server" />    
    
    </form>
</body>
</html>
