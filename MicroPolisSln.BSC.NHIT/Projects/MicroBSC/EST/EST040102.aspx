<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST040102.aspx.cs" Inherits="EST_EST040102" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EST040102</title>
	<link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
	<link rel="stylesheet" href="/_common/css/treeStyle.css" type="text/css" />
	<script type="text/javascript" src="/_common/js/common.js"></script>
	<script type="text/javascript" src="/_common/js/picker.js"></script>
	<script type="text/javascript" src="/_common/js/iezn_embed_patch.js" ></script>
	
	<script type="text/javascript">
	
	function SaveDeptData()
    {
        if('<%=WEIGHT_TYPE %>' == 'DPT') 
        {
            if(document.getElementById('txtWeightAll').value == '')
            {
                alert('선택부서에 적용할 가중치를 입력하세요.');
                return;
            }
        }
    
        gfOpenWindow( "EST_DEPT.aspx?COMP_ID=<%=COMP_ID%>"
                                    + "&ESTTERM_REF_ID=<%=ESTTERM_REF_ID %>"
                                    + "&CTRL_VALUE_NAME="	+ "hdfDeptID"
                                    + "&CHECKBOX_YN="	    + "Y"
                                    + "&CTRL_VALUE_VALUE="  + document.getElementById('hdfDeptID').value
                                    + "&POSTBACK_YN="       + "Y"
                                    + "&POSTBACK_CTRL_NAME="+ "lbnSave<%=WEIGHT_TYPE %>"
                                   , 430
                                   , 400
                                   , false
                                   , false
                                   , "popup_save_weigth_type" );
		    return false;
    }
    
//    function selectChkBox(chkAll, chkChild)
//    {
//        var param1      = chkAll.checked;
//        var _elements   = document.forms[0].elements;

//        for (var i = 0; i < _elements.length; i++)
//        {
//            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
//            {
//                if (param1 == false)
//                    _elements[i].checked = false;
//                else
//                    _elements[i].checked = true;
//            }
//        }
//    }
	    
	</script>
	
</head>
<body style="margin:0 0 0 0">
    <form id="form1" runat="server">
    <div>

	<asp:Panel ID="plDept" runat="server">
	<table cellpadding="0" cellspacing="0" width="100%" style="width:100%; height:100%">
		<tr height="100%">
			<td valign="top">
				<ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%" style="left: -4px; top: 233px">
					<Bands>
						<ig:UltraGridBand>
							<AddNewRow View="NotSet" Visible="NotSet">
							</AddNewRow>
							<Columns>
								<ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="true">
								</ig:UltraGridColumn>
								<ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No" Hidden="true">
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center"  />
                                </ig:TemplatedColumn>
								<ig:UltraGridColumn Key="STATUS" Width="40">
									<Header Caption="상태">
										<RowLayoutColumnInfo OriginX="9" />
									</Header>
									<CellStyle HorizontalAlign="center"></CellStyle>
									<Footer>
										<RowLayoutColumnInfo OriginX="9" />
									</Footer>
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서명" Key="DEPT_NAME" Width="400px">
									<HeaderStyle HorizontalAlign="Center" />
									<Header Caption="부서명">
										<RowLayoutColumnInfo OriginX="4" />
									</Header>
									<Footer>
										<RowLayoutColumnInfo OriginX="4" />
									</Footer>
								</ig:UltraGridColumn>
								<ig:TemplatedColumn BaseColumnName="TXT_WEIGHT" EditorControlID="" FooterText=""
									HeaderText="가중치" Key="TXT_WEIGHT" NullText="0" Width="120px">
									<HeaderStyle Wrap="True" />
									<CellTemplate>
										<asp:TextBox ID="txtWeightDept" runat="server" Width="100%"></asp:TextBox>
									</CellTemplate>
									<Header Caption="가중치">
										<RowLayoutColumnInfo OriginX="5" />
									</Header>
									<CellStyle HorizontalAlign="Center">
									</CellStyle>
									<Footer Caption="">
										<RowLayoutColumnInfo OriginX="5" />
									</Footer>
								</ig:TemplatedColumn>
							</Columns>
							<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
								<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
							</RowTemplateStyle>
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
                                    ReadOnly="LevelTwo"
                                    CellClickActionDefault="NotSet" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False">
						<%--<GroupByBox>
							<BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
						</GroupByBox>
						<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
							<BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
						</GroupByRowStyleDefault>
						<ActivationObject BorderColor="" BorderWidth="">
						</ActivationObject>
						<FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
							<BorderDetails ColorTop="White" WidthTop="1px" />
						</FooterStyleDefault>
						<RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
							<BorderDetails ColorLeft="Window" ColorTop="Window" />
							<Padding Left="3px" />
						</RowStyleDefault>
						<ClientSideEvents />
						<SelectedRowStyleDefault BackColor="#E2ECF4">
						</SelectedRowStyleDefault>
						<HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
							ForeColor="White" HorizontalAlign="Center">
							<BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
						</HeaderStyleDefault>
						<EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
						</EditCellStyleDefault>
						<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
							Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
						</AddNewBox>--%>
						
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
			<td>
				<table cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
					<tr>
						<td align="left">
							<asp:TextBox ID="txtWeightAll" runat="server" Width="60px"></asp:TextBox>%
							<asp:ImageButton id="ibnSaveAll2" runat="server" ImageUrl="../images/btn/b_198.gif" OnClick="ibnSaveAll2_Click" ImageAlign="AbsMiddle" Visible="False"></asp:ImageButton>
							<asp:imagebutton id="ibnSaveDept2" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_199.gif" OnClientClick="return SaveDeptData();"></asp:imagebutton>
						</td>
						<td align="right">
							<asp:ImageButton id="ibnSave2" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave2_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
							<asp:imagebutton id="ibnConfirm2" runat="server" imageurl="../images/btn/b_015.gif" onclick="ibnConfirm_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            <asp:imagebutton id="ibnConfirmCancel2" runat="server" imageurl="../images/btn/b_019.gif" onclick="ibnConfirmCancel_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            <asp:ImageButton id="ibnInit1" runat="server" ImageUrl="../images/btn/b_200.gif" ImageAlign="AbsMiddle" OnClick="ibnInit1_Click" Visible="False"></asp:ImageButton>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	</asp:Panel>

	<asp:Panel ID="plPos" runat="server" Visible="false">
	<table cellpadding="0" cellspacing="0" style="width:100%;height:100%">
		<tr style="height:50%">
			<td valign="top">
				<ig:UltraWebGrid ID="UltraWebGrid2" runat="server" OnSelectedRowsChange="UltraWebGrid2_SelectedRowsChange" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
					<Bands>
						<ig:UltraGridBand>
							<AddNewRow View="NotSet" Visible="NotSet">
							</AddNewRow>
							<Columns>
								<ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="true">
								</ig:UltraGridColumn>
								<ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No" Hidden="true">
                                    <CellTemplate>
                                        <asp:CheckBox ID="cBox" runat="server" />
                                    </CellTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center"  />
                                </ig:TemplatedColumn>
								<ig:UltraGridColumn Key="STATUS" Width="40">
									<Header Caption="상태">
										<RowLayoutColumnInfo OriginX="9" />
									</Header>
									<CellStyle HorizontalAlign="center"></CellStyle>
									<Footer>
										<RowLayoutColumnInfo OriginX="9" />
									</Footer>
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서명" Key="DEPT_NAME" Width="400px">
									<HeaderStyle HorizontalAlign="Center" />
									<Header Caption="부서명">
										<RowLayoutColumnInfo OriginX="4" />
									</Header>
									<Footer>
										<RowLayoutColumnInfo OriginX="4" />
									</Footer>
								</ig:UltraGridColumn>
							</Columns>
							<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
								<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
							</RowTemplateStyle>
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
							<BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
						</GroupByRowStyleDefault>
						<ActivationObject BorderColor="" BorderWidth="">
						</ActivationObject>
						<FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
							<BorderDetails ColorTop="White" WidthTop="1px" />
						</FooterStyleDefault>
						<RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
							<BorderDetails ColorLeft="Window" ColorTop="Window" />
							<Padding Left="3px" />
						</RowStyleDefault>
						<ClientSideEvents />
						<SelectedRowStyleDefault BackColor="#E2ECF4">
						</SelectedRowStyleDefault>
						<HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
							ForeColor="White" HorizontalAlign="Center">
							<BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
						</HeaderStyleDefault>
						<EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
						</EditCellStyleDefault>
						<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
							Cursor="Hand" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
						</AddNewBox>--%>
						
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
		<tr style="height:50%">
			<td>
				<ig:UltraWebGrid ID="UltraWebGrid3" runat="server" OnInitializeRow="UltraWebGrid3_InitializeRow" OnSelectedRowsChange="UltraWebGrid3_SelectedRowsChange" Width="100%" Height="100%">
					<Bands>
						<ig:UltraGridBand>
							<AddNewRow View="NotSet" Visible="NotSet">
							</AddNewRow>
							<Columns>
								<ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true">
								</ig:UltraGridColumn>                                                                
								<ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="true">
								</ig:UltraGridColumn>                             
								<ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true">
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="POS_ID" Key="POS_ID" Hidden="true">
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="POS_VALUE" Key="POS_VALUE" Hidden="true">
								</ig:UltraGridColumn>
								<ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No">
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
								<ig:UltraGridColumn BaseColumnName="SEQ" Key="SEQ" Width="80px">
									<HeaderStyle HorizontalAlign="Center" />
									<Header Caption="우선순위">
										<RowLayoutColumnInfo OriginX="4" />
									</Header>
									<Footer>
										<RowLayoutColumnInfo OriginX="4" />
									</Footer>
									<CellStyle HorizontalAlign="center"></CellStyle>
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="NAMEPOS_NAME" Key="NAMEPOS_NAME" Width="100px">
									<HeaderStyle HorizontalAlign="Center" />
									<Header Caption="구분">
										<RowLayoutColumnInfo OriginX="4" />
									</Header>
									<Footer>
										<RowLayoutColumnInfo OriginX="4" />
									</Footer>
									<CellStyle HorizontalAlign="center"></CellStyle>
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="NAMEPOS_VALUE" Key="NAMEPOS_VALUE" Width="120px">
									<HeaderStyle HorizontalAlign="Center" />
									<Header Caption="값">
										<RowLayoutColumnInfo OriginX="4" />
									</Header>
									<Footer>
										<RowLayoutColumnInfo OriginX="4" />
									</Footer>
									<CellStyle HorizontalAlign="center"></CellStyle>
								</ig:UltraGridColumn>
								<ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="80px">
									<HeaderStyle HorizontalAlign="Center" />
									<Header Caption="가중치"></Header>
									<CellStyle HorizontalAlign="Right"></CellStyle>
								</ig:UltraGridColumn>                                                                    
							</Columns>
							<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
								<BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
							</RowTemplateStyle>
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
							<BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
						</GroupByRowStyleDefault>
						<ActivationObject BorderColor="" BorderWidth="">
						</ActivationObject>
						<FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
							<BorderDetails ColorTop="White" WidthTop="1px" />
						</FooterStyleDefault>
						<RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
							<BorderDetails ColorLeft="Window" ColorTop="Window" />
							<Padding Left="3px" />
						</RowStyleDefault>
						<ClientSideEvents />
						<SelectedRowStyleDefault BackColor="#E2ECF4">
						</SelectedRowStyleDefault>
						<HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
							ForeColor="White" HorizontalAlign="Center">
							<BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
						</HeaderStyleDefault>
						<EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
						</EditCellStyleDefault>
						<FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
							Cursor="Hand" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
						</AddNewBox>--%>
						
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
			<td>
				<table id="Table1" width="100%" runat="server" border="0" style="height:100%;">
					<tr>
					    <td width="25px" align="left">
							구분
						</td>															
						<td>
							<asp:DropDownList ID="ddlPositionType" runat="server" Width="35%" AutoPostBack="True" OnSelectedIndexChanged="ddlPositionType_SelectedIndexChanged" class="box01" 
							/><asp:DropDownList ID="ddlPositionValue" runat="server" Width="35%" class="box01" 
							/><asp:TextBox ID="txtWeightPos" runat="server" Width="20%" />%
						</td>	
						<td align="right" valign="middle" style="width:70%">
                            <asp:ImageButton ID="ibnSavePosAll" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_198.gif" OnClick="ibnSavePosAll_Click" Visible="False" />
                            <asp:imagebutton id="ibnSaveDept1" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_199.gif" OnClientClick="return SaveDeptData();"></asp:imagebutton>
							<asp:imagebutton id="ibnSave3" runat="server" OnClick="ibnSave3_Click" ImageUrl="../images/btn/b_tp07.gif"></asp:imagebutton>
							<asp:ImageButton ID="ibnRemove" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnRemove_Click" />
							<asp:imagebutton id="ibnConfirm1" runat="server" imageurl="../images/btn/b_015.gif" onclick="ibnConfirm_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            <asp:imagebutton id="ibnConfirmCancel1" runat="server" imageurl="../images/btn/b_019.gif" onclick="ibnConfirmCancel_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            <asp:ImageButton id="ibnInit2" runat="server" ImageUrl="../images/btn/b_200.gif" ImageAlign="AbsMiddle" OnClick="ibnInit2_Click" Visible="False"></asp:ImageButton>
                            &nbsp;
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>										
	</asp:Panel>
      
    </div>
    
<asp:HiddenField id="hdfTabKey" runat="server" />
<asp:HiddenField ID="hdfEstID" runat="server" />
<asp:HiddenField ID="hdfWeightType" runat="server" />
<asp:HiddenField ID="hdfDeptRefID" runat="server" />
<asp:HiddenField ID="hdfEstPosEstTermRefID" runat="server" />
<asp:HiddenField ID="hdfEstPosEstDeptRefID" runat="server" />
<asp:HiddenField ID="hdfEstPosEstID" runat="server" />
<asp:HiddenField ID="hdfEstPosSeq" runat="server" />
<asp:HiddenField ID="hdfDeptID" runat="server" />
<asp:linkbutton id="lbnSaveDPT" runat="server" OnClick="lbnSaveDPT_Click"></asp:linkbutton>
<asp:linkbutton id="lbnSavePOS" runat="server" OnClick="lbnSavePOS_Click"></asp:linkbutton>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>

    </form>    
</body>
</html>
