<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST030501.aspx.cs" Inherits="EST_EST030501" %>
    
<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
    
    function ViewQPage()
	{
	    if('<%=EST_ID %>' == "") 
	    {
	        alert('평가를 선택하세요.');
	        return false;
	    }
	
	    if(document.getElementById("hdfTgtEmpID").value == "") 
	    {
	        alert('피평가자를 선택하세요.');
	        return false;
	    }
	    
	    if('<%=QUESTION_PAGE_NAME %>' == "") 
	    {
	        alert('설정된 질의 페이지가가 없습니다.');
	        return false;
	    }
	
		gfOpenWindow('<%=QUESTION_PAGE_NAME %>?COMP_ID=<%=COMP_ID%>'
                                            + '&EST_ID=<%=EST_ID %>'
                                            + '&TGT_EMP_ID='        + document.getElementById("hdfTgtEmpID").value
                                            + '&READ_ONLY_YN='      + 'Y'
                                            ,700
                                            ,600
                                            ,'yes'
                                            ,'no');
		return false;
	}
    
    </script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
<!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40">
					            <!-- 타이틀시작 -->
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t88.gif" /></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                                                    <td width="50%" bgcolor="#FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr class="cssPopContent">
                            <td valign="top" class="box_td03">
                                <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0" class="tableBorder">
                                    <tr>
                                        <td valign="top" align="center" height="300px">
                                            <div>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;height:100%">
                                                    <tr>
                                                        <td valign="top" width="450">
                                                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="300px" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%" OnInitializeLayout="UltraWebGrid1_InitializeLayout" OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
					                                            <Bands>
						                                            <ig:UltraGridBand>
							                                            <AddNewRow View="NotSet" Visible="NotSet">
							                                            </AddNewRow>
							                                            <Columns>
								                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="True">
								                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn BaseColumnName="POS_KND_ID" Key="POS_KND_ID" Hidden="True">
                                                                                <Header>
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn BaseColumnName="STATUS" Key="STATUS" Width="40px" HeaderText="상태">
									                                            <HeaderStyle HorizontalAlign="Center" />
									                                            <Header Caption="상태">
										                                            <RowLayoutColumnInfo OriginX="2" />
									                                            </Header>
									                                            <CellStyle HorizontalAlign="Center"></CellStyle>
									                                            <Footer>
										                                            <RowLayoutColumnInfo OriginX="2" />
									                                            </Footer>
								                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="80px" HeaderText="피평가자명">
									                                            <HeaderStyle HorizontalAlign="Center" />
									                                            <Header Caption="사원명">
										                                            <RowLayoutColumnInfo OriginX="3" />
									                                            </Header>
									                                            <CellStyle HorizontalAlign="Center"></CellStyle>
									                                            <Footer>
										                                            <RowLayoutColumnInfo OriginX="3" />
									                                            </Footer>
								                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn BaseColumnName="TGT_POS_CLS_NAME" Key="POS_CLS_NAME" Width="60px" FooterText="" HeaderText="직급">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="직급">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TGT_POS_RNK_NAME" Key="POS_RNK_NAME" Width="60px" FooterText="" HeaderText="직위">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="직위">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TGT_POS_DUT_NAME" Key="POS_DUT_NAME" Width="60px" FooterText="" HeaderText="직책">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="직책">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                </Footer>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TGT_POS_GRP_NAME" Key="POS_GRP_NAME" Width="60px" FooterText="" HeaderText="직군">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="직군">
                                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                                </Footer>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="TGT_POS_KND_NAME" Key="POS_KND_NAME" Width="60px" FooterText="" HeaderText="직종">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Header Caption="직종">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Header>
                                                                                <Footer Caption="">
                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                </Footer>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
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
                                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                    </GroupByRowStyleDefault>
                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                    </FooterStyleDefault>
                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
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
                                                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                                                                    <ClientSideEvents DblClickHandler="DblClickHandler"/>
                                                                    
                                                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>
                                                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>
                                                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                                </DisplayLayout>
				                                            </ig:UltraWebGrid>
                                                        </td>
                                                        <td valign="top">
                                                            <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Height="300px" OnInitializeRow="UltraWebGrid2_InitializeRow" Width="100%">
					                                            <Bands>
						                                            <ig:UltraGridBand>
							                                            <AddNewRow View="NotSet" Visible="NotSet">
							                                            </AddNewRow>
							                                            <Columns>
								                                            <ig:UltraGridColumn BaseColumnName="POS_BIZ_ID" Key="POS_BIZ_ID" Hidden="true">
								                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="true">
								                                            </ig:UltraGridColumn>
								                                            <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No">
                                                                                <CellTemplate>
                                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                                </CellTemplate>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid2');" />
                                                                                </HeaderTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </ig:TemplatedColumn>
								                                            <ig:UltraGridColumn BaseColumnName="POS_BIZ_NAME" Key="POS_BIZ_NAME" Width="100px">
									                                            <HeaderStyle HorizontalAlign="Center" />
									                                            <Header Caption="직무">
										                                            <RowLayoutColumnInfo OriginX="2" />
									                                            </Header>
									                                            <Footer>
										                                            <RowLayoutColumnInfo OriginX="2" />
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
                                                                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                                                                    
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
                                                    <tr align="right">
                                                        <td style="height: 40px" colspan="2">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
	                                                            <tr>
	                                                                <td width="120">
	                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    &nbsp;
                                                                                    <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                                                                                    <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                                                                    <img align="absmiddle" src="../Images/etc/lis_t02.gif" /></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td style="padding-right:5px"><img src="../images/icon/est_i02.gif" align="absmiddle" /> 설정완료 </td>
                                                                                <td style="padding-right:5px"><img src="../images/icon/est_i03.gif" align="absmiddle" /> 미설정 </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="height: 40px" align="right">
                                                                        &nbsp;<asp:imagebutton id="ibnViewQ" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_164.gif" OnClientClick="return ViewQPage();" Visible="false"></asp:imagebutton>
                                                                        <asp:ImageButton ID="ibnSave" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" />
                                                                        <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" border="0" align="absmiddle"/></a>
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      

    <script>gfWinFocus();</script>
    <asp:hiddenfield id="hdfTgtEmpID" runat="server"></asp:hiddenfield>
    <asp:hiddenfield id="hdfTgtPosKndID" runat="server"></asp:hiddenfield>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
