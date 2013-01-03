<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST010300.aspx.cs" Inherits="EST_EST010300" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">

	function CheckForm()
	{
		if ( document.all.txtEstID.value.length == 0 )
		{
			alert( "평가ID를 입력해주세요." );
			return false;
		}	
		else if ( document.all.txtEstName.value.length == 0 )
		{
			alert( "평가명을 입력해주세요." );
			return false;
		}
//		else if ( document.all.txtUpEstID.value.length == 0 )
//		{
//			alert( "상위평가ID를 입력해주세요." );
//			return false;
//		}	
		
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

	function ShowUpEstID( ctrl_value_name, ctrl_text_name )
	{
		gfOpenWindow( "EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
		                        + "&CTRL_VALUE_NAME="	+ ctrl_value_name
                                + "&CTRL_TEXT_NAME="	+ ctrl_text_name
                                + "&CHECKBOX_YN="	    + "N"
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_est_Id" );
		//return false;
	}
	
	function enableCheckBox(ckb_main_id, ckb_client_id, txt_client_id) 
    {
        var isChecked = document.getElementById(ckb_main_id).checked;
        
        if(isChecked)
        {
            if(ckb_client_id != '')
                document.getElementById(ckb_client_id).disabled = false;
                
            document.getElementById(txt_client_id).disabled = false;
            document.getElementById(txt_client_id).select();
        }
        else
        {
            if(ckb_client_id != '')
                document.getElementById(ckb_client_id).disabled = true;

            document.getElementById(txt_client_id).disabled = true;
        }
    }

    function displayDashboarDDL(displayYN) {
        if (displayYN == 'Y')
            document.getElementById('<%= ddlDashBoardTYPE.ClientID %>').style.display = "block";
        else
            document.getElementById('<%= ddlDashBoardTYPE.ClientID %>').style.display = "none";   
        
        return false;
    }

    function displayPreviousStepDDL(ddlid) {
        var sIndex = ddlid.selectedIndex;
        var sValue = ddlid.options[sIndex].value;
        if (sValue == 'BLK') {
            document.getElementById('<%= divQPSYN.ClientID %>').style.display = "none";
        }
        else {
            document.getElementById('<%= divQPSYN.ClientID %>').style.display = "block";
        }
    }

</script>

<form id="form1" runat="server">
<div>
	
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

	<table style="width:100%; height:100%;" cellpadding="1" cellspacing="1" border="0">
	    <tr style="display:none;">
	        <td>
	        </td>
	        <td align="right">
	            <asp:Label id="lblCompTitle" runat="server"></asp:label>
                <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
	        </td>
	    </tr>
        <tr>
            <td valign="top" style="width: 20%;height:100%" class="cssTreeLayout">
				<!-- tree -->
					<asp:TreeView ID="TreeView1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" runat="server"  Font-Names="Dotum" Font-Size="8pt" ImageSet="XPFileExplorer" ShowLines="False" NodeIndent="15">
					    <SelectedNodeStyle HorizontalPadding="1px" VerticalPadding="0px" />
						<ParentNodeStyle Font-Bold="False" />
					</asp:TreeView>
            </td>
            <td valign="top" style="width:80%; height:100%;"> 
				<div class="cssDivLayout" id="Div1">
                    <table cellpadding="0" cellspacing="0" class="tableBorder" style="width: 100%; height:100%;">
		                <tr>
			                <td class="cssTblTitle">평가 ID</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:textbox id="txtEstID" runat="server" width="70%"></asp:textbox>
				                <asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibtnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
			                </td>
			            </tr>
			            <tr>								    
			                <td class="cssTblTitle"">평가명</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:textbox id="txtEstName" runat="server" width="70%"></asp:textbox>
			                </td>
		                </tr>                            
		                <tr>
			                <td class="cssTblTitle">상위평가</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:textbox id="txtUpEstID" runat="server" width="70%" ReadOnly OnClick="ShowUpEstID( 'hdfUpEstID', 'txtUpEstID' );" style="cursor:pointer"></asp:textbox>
				                <asp:ImageButton id="imgUpEstID" runat="server" ImageUrl="../images/btn/b_142.gif" OnClientClick="return ShowUpEstID( 'hdfUpEstID', 'txtUpEstID' );" style="cursor:pointer;"  ImageAlign="AbsMiddle"></asp:ImageButton>
				                <asp:HiddenField ID="hdfUpEstID" runat="server" />
			                </td>
			            </tr>
		                <tr>
			                <td class="cssTblTitle">컬럼해더 색상</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:TextBox ID="txtHeaderColor" runat="server" CssClass="txt" MaxLength="10" Width="70%"></asp:TextBox>
			                </td>
		                </tr>
					    
		                <tr>
			                <td class="cssTblTitle" style="width:20%;">Bias 조정 타입</td>
			                <td class="cssTblContent" style="width:30%;">
				                <asp:DropDownList ID="ddlBiasTypeID" runat="server" class="box01"/>
			                </td>
			                <td class="cssTblTitle" style="width:20%;">Bias 적용</td>
			                <td class="cssTblContent" style="width:30%;">
				                <asp:RadioButtonList ID="rblBiasYN" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblBiasYN_SelectedIndexChanged"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">Bias 부서간에<br />조정 </td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblBiasDeptUseID" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
			                <td class="cssTblTitle">등급확정 </td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblGradeConfirmYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">피평가자 의견<br />수렴 방식</td>
			                <td class="cssTblContent"  colspan="3">
				                <asp:RadioButtonList ID="rblTgtSendType" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
					   
						    
		                </tr>
		                <tr>
			                <td class="cssTblTitle">평가주기</td>
			                <td class="cssTblContent" colspan="3" style="height:100px;">
				                <asp:CheckBoxList ID="cblEstTermSub" runat="server"  RepeatDirection="Horizontal"></asp:CheckBoxList>
							    
				                <ig:UltraWebGrid ID="uGridSub" runat="server" Height="100px" OnInitializeRow="uGridSub_InitializeRow" Width="100%">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" Hidden="True">
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" Hidden="True">
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn Key="USE_YN" Width="40px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="사용">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <CellTemplate>
                                                        <asp:CheckBox ID="cBox" runat="server" />
                                                    </CellTemplate>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_NAME" Key="ESTTERM_SUB_NAME" Width="60px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="주기">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn Key="WEIGHT" Width="80px" HeaderText="가중치">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="가중치">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <CellTemplate>
                                                        <asp:TextBox ID="txtWeight" Runat="server" Width="100%"></asp:TextBox>
                                                    </CellTemplate>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes" 
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="uGridSub" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    ReadOnly="LevelTwo"
                                                    CellClickActionDefault="NotSet" 
                                                    TableLayout="Fixed" 
                                                    StationaryMargins="Header" 
                                                    OptimizeCSSClassNamesOutput = "False"
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
                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100px"
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
                                        <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                        <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                        <Images>
                                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        </Images>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
			                </td>
		                </tr>
					    
		                <tr>
			                <td class="cssTblTitle">상향평가 적용<br /></td>
			                <td class="cssTblContent" colspan="3">
			                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
			                        <tr>
                            <td style="width:25%;">
			                                <asp:RadioButtonList ID="rblFixedWeightUseYN" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblFixedWeightUseYN_SelectedIndexChanged"></asp:RadioButtonList>
			                            </td>
			                            <td runat="server" id="tdFixedWeight" style="width:75%;">
			                               ( 가중치 : <asp:TextBox ID="txtFixedWeight" runat="server" width="70%"></asp:TextBox> )
			                            </td>
			                        </tr>
			                    </table>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">평가차수</td>
			                <td class="cssTblContent" colspan="3" style="height:100px;">
				                <asp:CheckBoxList ID="cblEstTermStep" runat="server"  RepeatDirection="Horizontal"></asp:CheckBoxList>
							    
				                <ig:UltraWebGrid ID="uGridStep" runat="server" Height="100%" OnInitializeRow="uGridStep_InitializeRow" Width="100%">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" Hidden="True">
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" Hidden="True">
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn Key="USE_YN" Width="40px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="사용">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <CellTemplate>
                                                        <asp:CheckBox ID="cBox" runat="server" />
                                                    </CellTemplate>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" Width="60px" HeaderText="차수">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="차수">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn Key="FIXED_WEIGHT_YN" Width="120px" HeaderText="고정된 가중치 ">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상향평가 ">
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Header>
                                                    <CellTemplate>
                                                        <asp:CheckBox ID="ckbFixedWeightYN" runat="server" />
                                                    </CellTemplate>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="5" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:TemplatedColumn Key="WEIGHT" Width="80px" HeaderText="가중치">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="가중치">
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Header>
                                                    <CellTemplate>
                                                        <asp:TextBox ID="txtWeight" Runat="server" Width="100%"></asp:TextBox>
                                                    </CellTemplate>
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="6" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                            </Columns>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  AllowColSizingDefault="Free" 
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="Yes" 
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="uGridStep" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    ReadOnly="LevelTwo"
                                                    CellClickActionDefault="NotSet" 
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
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                            BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="120px"
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
                                        <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                        <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                        <Images>
                                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        </Images>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
			                </td>
		                </tr>	
		                <tr>
			                <td class="cssTblTitle">점수조정 차수</td>
			                <td class="cssTblContent">
				                <asp:DropDownList ID="ddlPointCtrlStep" runat="server" class="box01"/>
			                </td>
					   
			                <td class="cssTblTitle">등급조정 차수</td>
			                <td class="cssTblContent" style="padding-left:10; height: 25px;">
				                <asp:DropDownList ID="ddlGradeCtrlStep" runat="server" class="box01"/>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">피평가주체<br />(부서/개인)</td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblOwnerType" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
			                <td class="cssTblTitle">링크된 평가</td>
			                <td class="cssTblContent">
				                <asp:textbox id="txtLinkEstID" runat="server" ReadOnly></asp:textbox>
				                <img id="imgLinkEstID" runat="server" src="../images/btn/b_143.gif" OnClick="ShowUpEstID( 'hdfLinkEstId', 'txtLinkEstID' );" style="cursor:hand" align="absmiddle" />
				                <asp:HiddenField ID="hdfLinkEstID" runat="server" />
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">평가 성격</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:RadioButtonList ID="rblEstStyle" runat="server" style="cursor:pointer" RepeatDirection="Horizontal" RepeatColumns="3" AutoPostBack="True" OnSelectedIndexChanged="rblEstStyle_SelectedIndexChanged"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">평가 가중치</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:RadioButtonList ID="rblWeightType" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">평가방식 설정</td>
			                <td class="cssTblContent" colspan="3">
				                <asp:RadioButtonList ID="rblScaleType" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
		                </tr>
					    
		                <tr>
			                <td class="cssTblTitle">평가질의지<br />(OR 팝업페이지)</td>
			                <td class="cssTblContent" colspan="3">
			                    <table border="0" cellpadding="0" cellspacing="0">
			                        <tr>
			                            <td>
				                            <asp:DropDownList ID="ddlQuestionStyleID" onchange="displayPreviousStepDDL(this);" runat="server" class="box01"/>
				                        </td>
				                        <td>
				                            <div id="divQPSYN" runat="server">
				                                <asp:Label ID="lblCaptionQPSYN" runat="server">&nbsp;&nbsp;이전차수 평가</asp:Label>&nbsp;<asp:DropDownList ID="ddlPreviousStempYN" runat="server" class="box01" />
				                            </div>
				                        </td>
				                    </tr>
				                </table>
			                </td>
		                </tr>
		                <tr>
			                <td class="cssTblTitle">평가질의항목설명 보기 </td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblQItemDescUseYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
					   
			                <td class="cssTblTitle">사원 직무 질의 사용 </td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblQTgtPosBizUseYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
				            <td width="140" class="cssTblTitle">
					            하위차수평가정보 보이기
				            </td>
				            <td class="cssTblContent">
					            <asp:radiobuttonlist id="rblAllStepVisibleYN" runat="server" repeatdirection="Horizontal"></asp:radiobuttonlist>
				            </td>
						
				            <td width="140" class="cssTblTitle">
					            권한 부서만 보여주기
				            </td>
				            <td class="cssTblContent">
					            <asp:radiobuttonlist id="rblEmpComDeptYN" runat="server" repeatdirection="Horizontal"></asp:radiobuttonlist>
				            </td>
			            </tr>
			            <tr>
			                <td width="120" class="cssTblTitle">과거년도 개인점수<br />보이기</td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblVisiblePastPointYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
					    
			                <td width="120" class="cssTblTitle">계량지표 MBO<br />평가하기</td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblEstQTTMBOYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
			                <td width="120" class="cssTblTitle">평가점수로 MBO<br />평가하기</td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblMboScoreEstimateYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
					    
			                <td width="120" class="cssTblTitle">개인평가 DashBoard 설정</td>
			                <td class="cssTblContent">
			                    <table border="0" cellpadding="0" cellspacing="0">
			                        <tr>
			                            <td>
				                            <asp:RadioButtonList ID="rblDashBoardTYPE" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
				                        </td>
				                        <td>
				                            <asp:DropDownList ID="ddlDashBoardTYPE" runat="server" class="box01" />
				                        </td>
				                    </tr>
				                </table>
			                </td>
		                </tr>
		                <tr>
		                    
			                <td class="cssTblTitle">진행상태 타입</td>
			                <td class="cssTblContent">
				                <asp:DropDownList ID="ddlStatusStyleID" runat="server" class="box01"/>
			                </td>
			                <td class="cssTblTitle">사용 </td>
			                <td class="cssTblContent">
				                <asp:RadioButtonList ID="rblUseYN" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
		                    <td class="cssTblTitle" colspan="2">
		                        사용될 작업 선택 (작업에 따른 컬럼 사용 로 적용됨)
		                    </td>
		                    <td class="cssTblTitle" colspan="2">
		                        외부데이터 쿼리 스트링
		                    </td>
		                </tr>
		                <tr>
		                    <td class="cssTblContent" colspan="2"  style="height:200px;padding:0px;">
		                        <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                                            </RowTemplateStyle>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="EST_JOB_ID" Key="EST_JOB_ID" Hidden="True">
                                                </ig:UltraGridColumn>
                                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellTemplate>
                                                        <asp:CheckBox ID="cBox" runat="server" style="cursor:pointer"/>
                                                    </CellTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cBox_header" style="cursor:pointer" runat="server" onclick="selectChkBox(this,'UltraWebGrid2');" />
                                                    </HeaderTemplate>
                                                    <Header>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="EST_JOB_NAME" Key="EST_JOB_NAME" Width="250px" HeaderText="평가작업명">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="평가작업명">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout  AllowColSizingDefault="Free" 
                                                    AllowDeleteDefault="Yes"
                                                    AllowSortingDefault="NotSet" 
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet" 
                                                    Name="UltraWebGrid2" 
                                                    RowHeightDefault="20px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    CellClickActionDefault="RowSelect" 
                                                    TableLayout="Fixed" 
                                                    StationaryMargins="Header" 
                                                    OptimizeCSSClassNamesOutput="False"
                                                    ReadOnly="LevelTwo"
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
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="340px"
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
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>--%>
                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                        <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                        <Images>
                                            <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
                                            <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                        </Images>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
		                    </td>
		                    <td class="cssTblContent" colspan="2">
		                        <asp:TextBox id="txtQueryString" runat="server"  TextMode="MultiLine" Height="100%" Width="100%" ></asp:TextBox>
		                    </td>
		                </tr>
                    </table>
                </div>
                <%--<SJ:SmartScroller id="SmartScroller1" runat="server" TargetObject="Div1" MaintainScrollX="true" MaintainScrollY="true"></SJ:SmartScroller>--%>
				<!-- 내용 -- 끝 -->
            </td>
        </tr>
        <tr style="height:25px">
            <td>
                <asp:HiddenField ID="hdfEstID" runat="server" />
                <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
            </td>
            <td align="right">
				<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
				<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>
				<asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="itnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>
                &nbsp;
            </td>
        </tr>
    </table>
    
	

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>
