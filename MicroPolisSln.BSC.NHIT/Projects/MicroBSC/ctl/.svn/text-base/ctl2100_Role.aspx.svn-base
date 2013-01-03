<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2100_Role.aspx.cs" Inherits="ctl_ctl2100_Role" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
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
                                    <td height="40" valign="top">
                                        <img src="../images/title/popup_t50.gif" width="230" height="40">
                                    </td>
                                    <td align="right" valign="top">
                                        <img src="../images/title/popup_img.gif">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="50%" height="4" bgcolor="#FFFFFF">
                                    </td>
                                    <td width="50%" bgcolor="#FFFFFF">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                                <tr>
                                    <td class="cssTblTitle">
                                        사용자
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:HiddenField ID="hfEmpRefID" runat="server" />
                                        <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        ROLE
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlRole" runat="server" class="box01" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPopBtnLine">
                            <asp:ImageButton ID="iBtnAdd" runat="server" ImageUrl="../images/btn/b_005.gif" OnClick="iBtnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: expression(eval(document.body.clientHeight)-150);">
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%" Width="100%" OnInitializeLayout="UltraWebGrid1_InitializeLayout"
                                OnInitializeRow="UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:TemplatedColumn HeaderText="" Key="SelChk" Width="40px" FooterText="" AllowUpdate="Yes"
                                                Type="CheckBox" AllowGroupBy="No">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, '');" />
                                                </HeaderTemplate>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Hidden="true">
                                                <Header Caption="사용자명" Title="">
                                                </Header>
                                                <Footer Caption="" Title="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ROLE_NAME" Key="ROLE_NAME" Width="150">
                                                <Header Caption="보유권한" Title="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle>
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="사용자아이디" Hidden="True" Key="EMP_REF_ID">
                                                <Header Caption="사용자아이디" Title="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ROLE_REF_ID" EditorControlID="" FooterText=""
                                                Format="" FormulaErrorValue="" HeaderText="upjukrate" Hidden="True" Key="ROLE_REF_ID">
                                                <Header Caption="upjukrate" Title="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <Footer Caption="" Title="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="NotSet"
                                    Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                    Version="4.00" ViewType="Flat" CellClickActionDefault="NotSet" TableLayout="Fixed"
                                    StationaryMargins="Header" OptimizeCSSClassNamesOutput="False" AutoGenerateColumns="False">
                                    <%--<GroupByBox>
                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
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
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="center" BorderColor="#E5E5E5" ForeColor="white">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                Width="100%">
                            </FrameStyle>
                            <Pager>
                                <Style BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                </Style>
                            </Pager>
                            <AddNewBox Hidden="False">
                                <Style BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                </Style>
                            </AddNewBox>
                            <SelectedRowStyleDefault BackColor="#E2ECF4">
                            </SelectedRowStyleDefault>--%>
                                    <RowStyleDefault CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                    </RowAlternateStyleDefault>
                                    <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle">
                                    </HeaderStyleDefault>
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                    </FrameStyle>
                                    <Images>
                                        <CurrentRowImage Url="../images/icon/arrow_red_beveled.gif" />
                                        <CurrentEditRowImage Url="../images/icon/arrow_red_beveled.gif" />
                                    </Images>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td align="right">
                            <asp:ImageButton ID="iBtnRoleDel" runat="server" ImageUrl="../images/btn/b_006.gif"
                                OnClick="iBtnRoleDel_Click" />
                            <img alt="" src="../images/btn/b_003.gif" style="border: 0px; cursor: hand;" onclick="opener.__doPostBack('<%=this.ICCB1 %>');self.close();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script type="text/javascript">        gfWinFocus();</script>

    <!--- MAIN END --->
    </form>
</body>
</html>
