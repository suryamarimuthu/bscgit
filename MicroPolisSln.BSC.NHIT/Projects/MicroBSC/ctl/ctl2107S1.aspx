<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2107S1.aspx.cs" Inherits="ctl_ctl2107s1" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
            <tr>
                <td valign="top" style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 180px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                                class="cssPopTitleArea">
                                <asp:Label ID="Label1" runat="server" Text="조직/사용자 변경현황" CssClass="cssPopTitleTxt"></asp:Label>
                            </td>
                            <td align="right" valign="top">
                                <img alt="" src="../images/title/popup_img.gif" />
                            </td>
                        </tr>
                    </table>
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
            <tr class="cssPopContent">
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                        <tr>
                            <td>
                                <table class="tableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="cssTblTitle">
                                            부서/사용자
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:RadioButton runat="server" ID="radioDept" GroupName="Dept_User" Checked="true"
                                                Text="부서" CssClass="select" />
                                            <asp:RadioButton runat="server" ID="radioUser" GroupName="Dept_User" Text="사용자" CssClass="select" />
                                        </td>
                                        <td class="cssTblTitle">
                                            구분
                                        </td>
                                        <td class="cssTblContent">
                                            <asp:DropDownList runat="server" ID="searchOption" Width="100%">
                                                <asp:ListItem Selected="True" Value="TOTAL">전체</asp:ListItem>
                                                <asp:ListItem Value="MATCH">일치</asp:ListItem>
                                                <asp:ListItem Value="NOTMATCH">불일치</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 25px;">
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <img style="vertical-align: middle;" src="../Images/etc/lis_t01.gif" alt="" />
                                            <asp:Label ID="lblRowCount" runat="server" Text="0"></asp:Label>
                                            <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton runat="server" ID="ibtnSearch" ImageUrl="../images/btn/b_033.gif"
                                                ImageAlign="AbsMiddle" OnClick="ibtnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 100%;">
                            <td>
                                <ig:UltraWebGrid ID="ugrdDept" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdDept_InitializeLayout"
                                    OnInitializeRow="ugrdDept_InitializeRow">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="STATUS_IMG" HeaderText="STATUS_IMG" Key="STATUS_IMG"
                                                    Width="5%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상태" />
                                                    <CellStyle HorizontalAlign="Center" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_DEPT_CODE" HeaderText="TARGET_DEPT_CODE"
                                                    Key="TARGET_DEPT_CODE" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="부서코드" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_DEPT_NAME" HeaderText="TARGET_DEPT_NAME"
                                                    Key="TARGET_DEPT_NAME" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="부서명칭" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_UP_DEPT_CODE" HeaderText="TARGET_UP_DEPT_CODE"
                                                    Key="TARGET_UP_DEPT_CODE" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상위부서코드" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_UP_DEPT_NAME" HeaderText="TARGET_UP_DEPT_NAME"
                                                    Key="TARGET_UP_DEPT_NAME" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상위부서명칭" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_DEPT_CODE" HeaderText="SRC_DEPT_CODE" Key="SRC_DEPT_CODE"
                                                    Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="부서코드" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_DEPT_NAME" HeaderText="SRC_DEPT_NAME" Key="SRC_DEPT_NAME"
                                                    Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="부서명칭" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_UP_DEPT_CODE" HeaderText="SRC_UP_DEPT_CODE"
                                                    Key="SRC_UP_DEPT_CODE" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상위부서코드" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_UP_DEPT_NAME" HeaderText="SRC_UP_DEPT_NAME"
                                                    Key="SRC_UP_DEPT_NAME" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상위부서명칭" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STATUS" HeaderText="STATUS" Key="STATUS" Width="15%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="비고" />
                                                    <CellStyle HorizontalAlign="Center" />
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout ReadOnly="LevelTwo" AutoGenerateColumns="False" RowSelectorsDefault="No"
                                        TableLayout="Fixed" NoDataMessage=" " NullTextDefault=" " RowHeightDefault="20px"
                                        OptimizeCSSClassNamesOutput="False">
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" />
                                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                        <RowStyleDefault CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" />
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle" />
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand" />
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                                <ig:UltraWebGrid ID="ugrdUser" runat="server" Width="100%" Height="100%" Visible="false"
                                    OnInitializeLayout="ugrdUser_InitializeLayout" OnInitializeRow="ugrdUser_InitializeRow"
                                    OnPreRender="ugrdUser_PreRender" OnPageIndexChanged="ugrdUser_PageIndexChanged">
                                    <Bands>
                                        <ig:UltraGridBand>
                                            <Columns>
                                                <ig:UltraGridColumn BaseColumnName="STATUS_IMG" HeaderText="STATUS_IMG" Key="STATUS_IMG"
                                                    Width="5%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="상태" />
                                                    <CellStyle HorizontalAlign="Center" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_EMP_CODE" HeaderText="TARGET_EMP_CODE"
                                                    Key="TARGET_EMP_CODE" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="사원번호(코드)" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_EMP_NAME" HeaderText="TARGET_EMP_NAME"
                                                    Key="TARGET_EMP_NAME" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="이름" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_DEPT_CODE" HeaderText="TARGET_DEPT_CODE"
                                                    Key="TARGET_DEPT_CODE" Width="10%">
                                                    <Header Caption="소속부서코드" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="TARGET_DEPT_NAME" HeaderText="TARGET_DEPT_NAME"
                                                    Key="TARGET_DEPT_NAME" Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="소속부서명칭" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_EMP_CODE" HeaderText="SRC_EMP_CODE" Key="SRC_EMP_CODE"
                                                    Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="사원번호(코드)" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_EMP_NAME" HeaderText="SRC_EMP_NAME" Key="SRC_EMP_NAME"
                                                    Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="이름" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_DEPT_CODE" HeaderText="SRC_DEPT_CODE" Key="SRC_DEPT_CODE"
                                                    Width="10%">
                                                    <Header Caption="소속부서코드" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="SRC_DEPT_NAME" HeaderText="SRC_DEPT_NAME" Key="SRC_DEPT_NAME"
                                                    Width="10%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="소속부서명칭" />
                                                    <CellStyle HorizontalAlign="Left" />
                                                </ig:UltraGridColumn>
                                                <ig:UltraGridColumn BaseColumnName="STATUS" HeaderText="STATUS" Key="STATUS" Width="15%">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <Header Caption="비고" />
                                                    <CellStyle HorizontalAlign="Center" />
                                                </ig:UltraGridColumn>
                                            </Columns>
                                        </ig:UltraGridBand>
                                    </Bands>
                                    <DisplayLayout AutoGenerateColumns="False" RowSelectorsDefault="No" TableLayout="Fixed"
                                        NoDataMessage=" " NullTextDefault=" " RowHeightDefault="20px" OptimizeCSSClassNamesOutput="False">
                                        <HeaderStyleDefault CssClass="GridHeaderStyle" />
                                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                        <RowStyleDefault CssClass="GridRowStyle" />
                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" />
                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle" />
                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand" />
                                        <Pager PagerAppearance="Bottom" PageSize="20" Alignment="Center" AllowPaging="true"
                                            StyleMode="PrevNext" AllowCustomPaging="true">
                                            <PagerStyle BorderWidth="1px" BorderStyle="None" ForeColor="RoyalBlue" BackColor="LightGray"
                                                Height="20px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" />
                                            </PagerStyle>
                                        </Pager>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
                            </td>
                        </tr>
                        <tr class="cssPopBtnLine">
                            <td align="right">
                                <asp:ImageButton runat="server" ID="ibtnSync" Text="동기화" ImageAlign="AbsMiddle" ImageUrl="../images/btn/btn_enter.gif"
                                    OnClick="ibtnSync_Click" />
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
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
