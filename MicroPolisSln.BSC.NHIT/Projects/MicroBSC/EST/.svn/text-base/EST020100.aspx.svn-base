<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST020100.aspx.cs" Inherits="EST_EST020100" ValidateRequest="False" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>
<form id="form1" runat="server">
<script>
	function CheckForm()
	{
		if ( document.all.txtEstName.value.length == 0 )
		{
			alert( "평가를 선택해주세요." );
			return false;
		}
		return true;
	}
	
	function SaveCheckForm()
	{
		if ( document.all.txtEstName.value.length == 0 )
		{
			alert( "평가를 선택해주세요." );
			return false;
		}
		
		if ( document.all.txtColKey.value.length == 0 )
		{
			alert( "컬럼키를 입력하세요." );
			return false;
		}
		return true;
	}
	
	function CheckID()
	{
		if ( document.all.txtColKey.value.length == 0 )
		{
			alert( "컬럼키를 입력하세요." );
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

	function ShowUpEstID()
	{
		gfOpenWindow( "EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
		                        + "&CTRL_VALUE_NAME="	+ "hdfEstID"
                                + "&CTRL_TEXT_NAME="	+ "txtEstName"
                                + "&CHECKBOX_YN="	    + "N"
                               , 430
                               , 400
                               , false
                               , false
                               , "popup_est_scheId" );
		//return false;
	}
</script>
<div>
	
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
<table style="width:100%; height:100%;" cellpadding="0" cellspacing="0" border="0">
  <tr valign="top">
        <td colspan="3">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder">
                <tr>
                    <td class="cssTblTitle">
                        평가유형
                    </td>
                    <td class="cssTblContent" style="border-right:none;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:label id="lblCompTitle" runat="server"></asp:label>
                                    <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                                    <asp:TextBox ID="txtEstName" runat="server" onclick="ShowUpEstID();" onfocus="this.blur();" Style="cursor: hand" Width="100%" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td style="width:90px;">
                                    <a href="javascript:ShowUpEstID();"><img src="../images/btn/b_143.gif" border="0" align="absmiddle" /></a>
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
    <tr class="cssPopBtnLine">
        <td colspan="3">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left">
                        <img align='absmiddle' src='../Images/etc/lis_t01.gif' />
                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                        <img align='absmiddle' src='../Images/etc/lis_t02.gif' />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ibnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" OnClick="ibnSearch_Click"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="vertical-align:top; width:100%;height:100%">
        <td valign="top" style="width: 50%;">
			<!-- 메뉴 -- 시작 -->
            <table cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                <tr>
                    <td>
                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                            OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange" Width="100%">
                            <Bands>
                                <ig:UltraGridBand>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                    </RowTemplateStyle>
                                    <Columns>
                                        <ig:UltraGridColumn BaseColumnName="EST_ID" HeaderText="평가아이디" Hidden="True" Key="EST_ID">
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn Key="VISIBLE_YN_IMG" Width="60px">
                                            <Header Caption="Visible">
                                                <RowLayoutColumnInfo OriginX="17" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="17" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="SEQ" HeaderText="순서" Key="SEQ" Width="30px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="순서">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COL_NAME" HeaderText="컬럼명" Hidden="True" Key="COL_NAME"
                                            Width="100px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="컬럼명">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COL_KEY" Key="COL_KEY" Width="150px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="컬럼 KEY">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CAPTION" Key="CAPTION" Width="100px">
                                            <Header Caption="그리드 컬럼명">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COL_STYLE_ID" HeaderText="컬럼스타일아이디" Hidden="True"
                                            Key="COL_STYLE_ID">
                                            <Header Caption="컬럼 스타일 ID">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COL_STYLE_NAME" HeaderText="컬럼스타일명" Key="COL_STYLE_NAME" Width="110px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="컬럼스타일명">
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                            <CellStyle HorizontalAlign="Left">
                                            </CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="WIDTH" HeaderText="컬럼넓이" Hidden="True" Key="WIDTH">
                                            <Header Caption="컬럼넓이">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="DATA_TYPE" HeaderText="컬럼타입" Hidden="True"
                                            Key="DATA_TYPE">
                                            <Header Caption="컬럼타입">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="HALIGN" HeaderText="컬럼정렬" Hidden="True" Key="HALIGN">
                                            <Header Caption="컬럼정렬">
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="BACK_COLOR" HeaderText="컬럼색상" Hidden="True"
                                            Key="BACK_COLOR">
                                            <Header Caption="컬럼색상">
                                                <RowLayoutColumnInfo OriginX="10" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="10" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="FORMAT" HeaderText="컬럼포맷" Hidden="True" Key="FORMAT">
                                            <Header Caption="컬럼포맷">
                                                <RowLayoutColumnInfo OriginX="11" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="11" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="FORMULA" HeaderText="컬럼산식" Hidden="True" Key="FORMULA">
                                            <Header Caption="컬럼산식">
                                                <RowLayoutColumnInfo OriginX="12" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="12" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COL_DESC" HeaderText="컬럼설명" Hidden="True"
                                            Key="COL_DESC">
                                            <Header Caption="컬럼설명">
                                                <RowLayoutColumnInfo OriginX="13" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="13" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="BACK_COLOR_YN" HeaderText="컬럼색상사용유무" Hidden="True"
                                            Key="BACK_COLOR_YN">
                                            <Header Caption="컬럼색상사용유무">
                                                <RowLayoutColumnInfo OriginX="14" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="14" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="FORMAT_YN" HeaderText="컬럼포맷사용유무" Hidden="True"
                                            Key="FORMAT_YN">
                                            <Header Caption="컬럼포맷사용유무">
                                                <RowLayoutColumnInfo OriginX="15" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="15" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="FORMULA_YN" HeaderText="컬럼산식사용유무" Hidden="True"
                                            Key="FORMULA_YN">
                                            <Header Caption="컬럼산식사용유무">
                                                <RowLayoutColumnInfo OriginX="16" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="16" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="VISIBLE_YN" HeaderText="컬럼보이기여부"  Hidden="True"
                                            Key="VISIBLE_YN">
                                            <Header Caption="컬럼보이기여부">
                                                <RowLayoutColumnInfo OriginX="17" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="17" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        
                                    </Columns>
                                </ig:UltraGridBand>
                            </Bands>
                            <DisplayLayout  AllowSortingDefault="Yes" 
                                            AutoGenerateColumns="False"
                                            BorderCollapseDefault="Separate"
                                            CellClickActionDefault="RowSelect"
                                            HeaderClickActionDefault="SortMulti"
                                            Name="UltraWebGrid1"
                                            RowSelectorsDefault="No"
                                            SelectTypeRowDefault="Single"
                                            StationaryMargins="Header"
                                            TableLayout="Fixed"
                                            RowHeightDefault="20px"
                                            OptimizeCSSClassNamesOutput="False"
                                            Version="4.00">
                                <%--<GroupByBox>
                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                </GroupByBox>
                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                </GroupByRowStyleDefault>
                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                </FooterStyleDefault>
                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                    <Padding Left="3px" />
                                </RowStyleDefault>
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
                                </AddNewBox>
                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                </SelectedRowStyleDefault>
                                <ActivationObject BorderColor="" BorderWidth="">
                                </ActivationObject>--%>
                                
                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                <RowStyleDefault  CssClass="GridRowStyle" />
                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                <Images>   
	                                <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                </Images>
                            </DisplayLayout>
                        </ig:UltraWebGrid>
                    </td>
                </tr>
            </table>
			<!-- 메뉴 -- 끝 -->
        </td>
        <td width="5px">
            &nbsp;
        </td>
        <td valign="top" > 
			<table cellpadding="0" cellspacing="0" width="100%" style="width:100%; height:100%">
				<tr>
					<td>
						<!-- 내용 -- 시작 -->
						<DIV class="cssDivLayout" id="Div1">
                            <table cellpadding="0" cellspacing="0" class="tableBorder" style="width: 100%;">
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼키</td>
								    <td class="cssTblContent">
                                        <asp:TextBox ID="txtColKey" runat="server" Width="60%"></asp:TextBox>
                                        <asp:imagebutton id="ibnCheckID" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_039.gif"
                                            onclick="ibnCheckID_Click"></asp:imagebutton>
                                    </td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼보이기유무</td>
								    <td class="cssTblContent" >
                                        <asp:RadioButtonList ID="rbnVisibleYN" runat="server" RepeatColumns="2" Width="100%" Height="15px" RepeatLayout="Flow" style="cursor:pointer;"></asp:RadioButtonList></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼제목</td>
								    <td class="cssTblContent">
                                        <asp:TextBox ID="txtCaption" runat="server" Width="100%"></asp:TextBox></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼명</td>
								    <td class="cssTblContent" >
                                        <asp:TextBox ID="txtColName" runat="server" Width="100%"></asp:TextBox></td>
							    </tr>                            
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼순서</td>
								    <td class="cssTblContent">
                                        <asp:textbox id="txtSeq" runat="server" width="50px"></asp:textbox>
                                    </td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼넓이</td>
								    <td class="cssTblContent">
                                        <asp:TextBox ID="txtWidth" runat="server" Width="50px"></asp:TextBox></td>
							    </tr>	
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼데이타타입</td>
								    <td class="cssTblContent" ><asp:DropDownList ID="ddlDataType" runat="server" class="box01" Width="140px"/></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼정렬</td>
								    <td class="cssTblContent" ><asp:DropDownList ID="ddlHAlign" runat="server" class="box01" Width="140px"/></td>
							    </tr>	
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼색상</td>
								    <td class="cssTblContent">
                                        <asp:checkbox id="ckbBackColorYN" runat="server" style="cursor:pointer;"></asp:checkbox>
                                        <asp:TextBox ID="txtBackColor" runat="server" Width="70%"></asp:TextBox></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼포맷</td>
								    <td class="cssTblContent">
                                        <asp:checkbox id="ckbFormatYN" runat="server" style="cursor:pointer;"></asp:checkbox>
                                        <asp:textbox id="txtFormat" runat="server" width="70%"></asp:textbox>
                                    </td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼산식</td>
								    <td class="cssTblContent">
                                        <asp:checkbox id="ckbFormularYN" runat="server" style="cursor:pointer;"></asp:checkbox>
                                        <asp:TextBox ID="txtFormula" runat="server" Width="70%"></asp:TextBox></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        기본값</td>
								    <td class="cssTblContent">
                                        <asp:checkbox id="ckbDefaultValueYN" runat="server" style="cursor:pointer;"></asp:checkbox>
                                        <asp:TextBox ID="txtDefaultValue" runat="server" Width="70%"></asp:TextBox></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        사원주체만 보임</td>
								    <td class="cssTblContent">
                                        <asp:RadioButtonList ID="rbnColEmpVisibleYN" runat="server" RepeatColumns="2" Width="100%" Height="15px" RepeatLayout="Flow" style="cursor:pointer;"></asp:RadioButtonList></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼설명</td>
								    <td class="cssTblContent">
                                        <asp:TextBox ID="txtColDesc" runat="server" Width="100%"></asp:TextBox></td>
							    </tr>
							    <tr>
								    <td class="cssTblTitle">
                                        컬럼스타일</td>
								    <td class="cssTblContent">
                                        <asp:dropdownlist id="ddlColStyleID" runat="server" width="140px" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlColStyleID_SelectedIndexChanged"></asp:dropdownlist>
                                    </td>
							    </tr>
							    <tr>
							        <td colspan="2" style="height:180px;width:100%;" id="trEstJob" runat="server" visible="false">
							            - 평가별 작업 내용 설정<br />
							            <ig:UltraWebGrid id="UltraWebGrid2" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid2_InitializeRow">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px"   />
                                                    </RowTemplateStyle>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="EST_JOB_ID" Key="EST_JOB_ID" Hidden="True">
                                                        </ig:UltraGridColumn>
                                                        <ig:TemplatedColumn Key="selchk" Width="30px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="cBox" runat="server" />
                                                            </CellTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
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
                                                        <ig:UltraGridColumn BaseColumnName="EST_JOB_NAME" Key="EST_JOB_NAME" Width="300px" HeaderText="평가작업명">
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
                                            <DisplayLayout  CellPaddingDefault="2" 
                                                            AllowColSizingDefault="Free" 
                                                            AllowDeleteDefault="Yes"
                                                            AllowSortingDefault="NotSet" 
                                                            BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="SortMulti" 
                                                            Name="UltraWebGrid2" 
                                                            RowHeightDefault="20px"
                                                            RowSelectorsDefault="No" 
                                                            SelectTypeRowDefault="Extended" 
                                                            CellClickActionDefault="RowSelect" 
                                                            TableLayout="Fixed" 
                                                            StationaryMargins="Header" 
                                                            AutoGenerateColumns="False"
                                                            OptimizeCSSClassNamesOutput="False"
                                                            Version="4.00">
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
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="340px"
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
                                                
                                                <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />                                
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                <%--<ClientSideEvents DblClickHandler="DblClickHandler"/>--%>
                                                <Images>   
	                                                <CurrentRowImage url="../images/icon/arrow_red_beveled.gif" />
	                                                <CurrentEditRowImage url="../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
							        </td>
							    </tr>
                            </table>
                        </DIV>
                        <SJ:SmartScroller id="SmartScroller1" runat="server" TargetObject="Div1" MaintainScrollX="true" MaintainScrollY="true"></SJ:SmartScroller>
						<!-- 내용 -- 끝 -->
                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="cssPopBtnLine">
        <td>
            <table id="tblViewStatus" cellspacing="0" cellpadding="0" border="0">
	            <tr>
	                <td style="padding-right:5px;">
	                    <img src='../images/icon/color/blue.gif'/> Visible : True
                    </td>
		            <td style="padding-right:5px;">
		                <img src='../images/icon/color/red.gif'/> Visible : False
                    </td>
	            </tr>
            </table>
        </td>
        <td width="5">&nbsp;&nbsp;</td>
        <td align="right">
			<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
			<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>
			<asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="itnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>
            &nbsp;
        </td>
    </tr>
</table>
    
<asp:HiddenField ID="hdfEstID" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</form>
<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>
