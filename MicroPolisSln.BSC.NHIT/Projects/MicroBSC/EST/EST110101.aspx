<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST110101.aspx.cs" Inherits="EST_EST110101" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
    
    function enableCheckBox(ckb_client_id, txt_client_id) 
    {
        var isChecked = document.getElementById(ckb_client_id).checked;
        
        if(isChecked)
        {
            document.getElementById(txt_client_id).disabled = false;
            document.getElementById(txt_client_id).select();
        }
        else
        {
            document.getElementById(txt_client_id).disabled = true;
        } 
    }
    
    </script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
<!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0"  background="/MicroFCMWeb/Images/etc/pop_ti_bg02.gif" >
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
                                                    <td height="40" valign="top"><img src="../images/title/popup_t82.gif" /></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="FFFFFF"></td>
                                                    <td width="50%" bgcolor="FFFFFF"></td>
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
                                <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0" class="box_ta01">
                                    <tr>
                                        <td valign="top" align="center" height="300px">
                                            <div>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 98%;height:100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="300px" OnInitializeRow="UltraWebGrid1_InitializeRow" Width="100%" style="left: 0px; top: 233px">
					                                            <Bands>
						                                            <ig:UltraGridBand>
							                                            <AddNewRow View="NotSet" Visible="NotSet">
							                                            </AddNewRow>
							                                            <Columns>
								                                            <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Key="DEPT_REF_ID" Hidden="True">
									                                            <HeaderStyle HorizontalAlign="Center" />
								                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn Key="TGT_DEPT_ID" Hidden="true">
								                                            </ig:UltraGridColumn>
								                                            <ig:UltraGridColumn Key="POINT" Hidden="true">
								                                            </ig:UltraGridColumn>
								                                            <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No">
                                                                                <CellTemplate>
                                                                                    <asp:CheckBox ID="cBox" runat="server" />
                                                                                </CellTemplate>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                                <HeaderTemplate>
                                                                                    <%--<asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1');" />--%>
                                                                                </HeaderTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </ig:TemplatedColumn>
								                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="200px">
									                                            <HeaderStyle HorizontalAlign="Center" />
									                                            <Header Caption="부서명">
										                                            <RowLayoutColumnInfo OriginX="2" />
									                                            </Header>
									                                            <Footer>
										                                            <RowLayoutColumnInfo OriginX="2" />
									                                            </Footer>
								                                            </ig:UltraGridColumn>
								                                            <ig:TemplatedColumn Key="CTRL_POINT" Width="120px">
									                                            <HeaderStyle Wrap="True" />
									                                            <CellTemplate>
									                                                <asp:Label ID="lblPoint" runat="server"></asp:Label>
										                                            <asp:TextBox ID="txtPoint" runat="server" Width="100%"></asp:TextBox>
									                                            </CellTemplate>
									                                            <Header Caption="부서점수">
										                                            <RowLayoutColumnInfo OriginX="3" />
									                                            </Header>
									                                            <CellStyle HorizontalAlign="Right">
									                                            </CellStyle>
									                                            <Footer Caption="">
										                                            <RowLayoutColumnInfo OriginX="3" />
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
						                                            <ClientSideEvents MouseOverHandler="MouseOverHandler" />
						                                            <SelectedRowStyleDefault BackColor="#E2ECF4">
						                                            </SelectedRowStyleDefault>
						                                            <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
							                                            ForeColor="White" HorizontalAlign="Center">
							                                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
						                                            </HeaderStyleDefault>
						                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
						                                            </EditCellStyleDefault>
						                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
							                                            Cursor="Hand" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="300px"
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
                                                    <tr align="right">
                                                        <td style="height: 40px">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
	                                                            <tr>
	                                                                <td>
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
                                                                    <td style="height: 40px" align="right">
                                                                        <asp:ImageButton ID="ibnAllowUpdate" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_181.gif" Visible="false" OnClick="ibnAllowUpdate_Click" CommandName="BIZ_ALLOW_UPDATE_ASSIGN_DEPT_POINT" />
                                                                        <asp:ImageButton ID="ibnSave" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" />
                                                                        <asp:ImageButton ID="ibnConfirmAssingDeptPoint" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_182.gif" Visible="false" OnClick="ibnConfirmAssingDeptPoint_Click" CommandName="BIZ_CONFIRM_ASSIGN_DEPT_POINT"/>
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
                                        <td style="height: 16px" background="/MicroFCMWeb/Images/etc/pop_ti03.gif">
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
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
