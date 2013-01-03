<%@ Page Language="C#" AutoEventWireup="true" CodeFile="com1001.aspx.cs" Inherits="base_com1001" %>
    

<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html; " />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
        <script>
        function selectChkBox(chkAll, chkChild)
        {
            var param1      = chkAll.checked;
            var _elements   = document.forms[0].elements;
 
            for (var i = 0; i < _elements.length; i++)
            {
                if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
                {
                    if (param1 == false)
                        _elements[i].checked = false;
                    else
                        _elements[i].checked = true;
                }
            }
        }
        </script>
    </head>
<body topmargin=0 leftmargin=0>
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top"></td>
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
                </td>
            </tr>
            <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align=center style="height:100%;">
                        <tr>
                            <td>
                                <table class="box_tt01" width="100%">
                                    <tr>
                                        <td class="tableTitle" style="width: 100px">실적월</td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblMM" runat="server"></asp:Label></td>
                                        <td class="tableTitle" style="width: 100px">실적입력여부</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlApplyYN" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlApplyYN_SelectedIndexChanged" class="box01">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                        <tr style="height:100%;">
                            <td>
                                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <AddNewRow View="NotSet" Visible="NotSet">
                                            </AddNewRow>
                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                            </RowTemplateStyle>
                                            <Columns>
                                                <ig:TemplatedColumn Key="selchk" Width="30px">
                                                    <CellTemplate>
                                                        <asp:CheckBox ID="cBox" runat="server" />
                                                    </CellTemplate>
                                                </ig:TemplatedColumn>
                                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="True" HeaderText="사용자ID">
                                                    <Header Caption="사용자ID">
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="1" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" HeaderText="부서명" Width="120px">
                                                    <Header Caption="부서명">
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="2" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" HeaderText="챔피언명">
                                                    <Header Caption="챔피언명">
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="3" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" Key="EMP_EMAIL" Width="220px" HeaderText="이메일주소">
                                                    <Header Caption="이메일주소">
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Header>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                    <Footer>
                                                        <RowLayoutColumnInfo OriginX="4" />
                                                    </Footer>
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                        AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                        CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                        Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                        StationaryMargins="Header" TableLayout="Fixed" Version="4.00">
                                        <GroupByBox>
                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                                            ForeColor="White" HorizontalAlign="Left">
                                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
                                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                        </FrameStyle>
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" align=center>
                                    <tr valign=top>
	                                    <td align="right" valign="top"><br/>
                                            <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectChkBox(this, 'UltraWebGrid1')"
                                                Text="전체 선택/해제" />&nbsp;
	                                        <ASP:IMAGEBUTTON id="iBtnSend" runat="server" imageurl="../images/btn/b_051.gif" onclick="iBtnRoleDel_Click" />
	                                        <a href="javascript:window.close();"><img src="../images/btn/b_003.gif" border=0/></a>&nbsp; &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        </table>
        <!--- MAIN END --->
        <asp:HiddenField ID="hdnTerm" runat="server" />
        <asp:HiddenField ID="hdnMM" runat="server" />
    </form>
</body>
</html>
