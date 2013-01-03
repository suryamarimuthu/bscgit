<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2107.aspx.cs" Inherits="ctl_ctl2107" %>

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
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td style="width: 180px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" CssClass="cssPopTitleTxt" Text="조직/사용자 변경현황"></asp:Label>
                        </td>
                        <td align="right">
                            <img src="../images/title/popup_img.gif" alt="" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                    <tr>
                        <td style="width: 390px;">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="width: 15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTitle1" runat="server" Style="font-weight: bold" Text="부서현황" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="width: 15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Style="font-weight: bold" Text="사용자 현황" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <ig:UltraWebGrid ID="ugrdDept" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDept_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="BSC_DEPT_NAME" HeaderText="BSC_DEPT_NAME" Key="BSC_DEPT_NAME"
                                                Width="130px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="현재조직명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_DEPT_NAME" HeaderText="LOW_DEPT_NAME" Key="LOW_DEPT_NAME"
                                                Width="130px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="기간계조직명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STATUS" HeaderText="STATUS" Key="STATUS" Width="90px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="상태">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BSC_DEPT_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="BSC_DEPT_REF_ID" Hidden="True" Key="BSC_DEPT_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="BSC_DEPT_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_DEPT_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="LOW_DEPT_REF_ID" Hidden="True" Key="LOW_DEPT_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="LOW_DEPT_REF_ID    ">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <%--<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>--%>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" BorderCollapseDefault="Separate"
                                    AutoGenerateColumns="False" HeaderClickActionDefault="SortMulti" Name="ugrdDept"
                                    RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Single"
                                    Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                                    OptimizeCSSClassNamesOutput="False">
                                    <%--<GroupByBox>
                                            <style backcolor="ActiveBorder" bordercolor="Window">
                                                </style>
                                        </GroupByBox>
                                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                            <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                        </GroupByRowStyleDefault>
                                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthTop="1px" />
                                        </FooterStyleDefault>
                                        <RowAlternateStyleDefault BackColor="#F9F9F7">
                                            <BorderDetails ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                                        </RowAlternateStyleDefault>
                                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                            Cursor="hand">
                                            <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                            <Padding Left="3px" />
                                        </RowStyleDefault>
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left"
                                            BorderColor="#E5E5E5" ForeColor="White" Height="35px">
                                            <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="2px"
                                            Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="90%" Width="100%">
                                        </FrameStyle>
                                        <Pager>
                                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                                </BorderDetails>
                                            </PagerStyle>
                                        </Pager>
                                        <AddNewBox Hidden="False">
                                            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                                </BorderDetails>
                                            </BoxStyle>
                                        </AddNewBox>
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                        <ActivationObject BorderColor="" BorderWidth="">
                                        </ActivationObject>--%>
                                    <ClientSideEvents DblClickHandler="DblClickHandler" />
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
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                        <td>
                            <ig:UltraWebGrid ID="ugrdDeptEmp" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdDeptEmp_InitializeRow"
                                OnInitializeLayout="ugrdDeptEmp_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="BSC_DEPT_NAME" HeaderText="BSC_DEPT_NAME" Key="BSC_DEPT_NAME"
                                                Width="140px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="조직명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BSC_EMP_NAME" HeaderText="BSC_EMP_NAME" Key="BSC_EMP_NAME"
                                                Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="사용자명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_DEPT_NAME" HeaderText="LOW_DEPT_NAME" Key="LOW_DEPT_NAME"
                                                Width="140px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="조직명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_EMP_REF_ID" HeaderText="LOW_EMP_REF_ID" Key="LOW_EMP_REF_ID"
                                                Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="사용자ID">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_EMP_NAME" HeaderText="LOW_EMP_NAME" Key="LOW_EMP_NAME"
                                                Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="사용자명">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="STATUS" HeaderText="STATUS" Key="STATUS" Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="상태">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BSC_DEPT_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="BSC_DEPT_REF_ID" Hidden="True" Key="BSC_DEPT_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="BSC_DEPT_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_DEPT_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="LOW_DEPT_REF_ID" Hidden="True" Key="LOW_DEPT_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="LOW_DEPT_REF_ID    ">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="BSC_EMP_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="BSC_EMP_REF_ID" Hidden="True" Key="BSC_EMP_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="BSC_EMP_REF_ID">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LOW_EMP_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="LOW_EMP_REF_ID" Hidden="True" Key="LOW_EMP_REF_ID" Width="40px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="LOW_EMP_REF_ID    ">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" BorderCollapseDefault="Separate"
                                    AutoGenerateColumns="False" HeaderClickActionDefault="SortMulti" Name="ugrdDeptEmp"
                                    RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Single"
                                    Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                                    OptimizeCSSClassNamesOutput="False">
                                    <%--<GroupByBox>
                                        <style backcolor="ActiveBorder" bordercolor="Window">
                                            </style>
                                    </GroupByBox>
                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                    </GroupByRowStyleDefault>
                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                    </FooterStyleDefault>
                                    <RowAlternateStyleDefault BackColor="#F9F9F7">
                                        <BorderDetails ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                                    </RowAlternateStyleDefault>
                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                        Cursor="hand">
                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                        <Padding Left="3px" />
                                    </RowStyleDefault>
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left"
                                        BorderColor="#E5E5E5" ForeColor="White" Height="18px">
                                        <BorderDetails ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="2px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="90%" Width="100%">
                                    </FrameStyle>
                                    <Pager>
                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                            </BorderDetails>
                                        </PagerStyle>
                                    </Pager>
                                    <AddNewBox Hidden="False">
                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                            </BorderDetails>
                                        </BoxStyle>
                                    </AddNewBox>
                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                    </SelectedRowStyleDefault>
                                    <ActivationObject BorderColor="" BorderWidth="">
                                    </ActivationObject>--%>
                                    <ClientSideEvents DblClickHandler="DblClickHandler" />
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
                                </DisplayLayout>
                            </ig:UltraWebGrid>
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
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
