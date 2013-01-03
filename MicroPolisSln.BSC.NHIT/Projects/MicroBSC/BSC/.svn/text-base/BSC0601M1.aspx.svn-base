<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0601M1.aspx.cs" Inherits="BSC_BSC0601M1" %>

<!--DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script id="Infragistics" type="text/javascript">
        function OpenPreviewWindow() {
            var Dicode = "<%= this.IDiCode %>";
            var ICCB1 = "<%= this.ICCB1 %>";

            var strURL = 'BSC0601S1.aspx?iType=P&DICODE=' + Dicode + '&CCB1=' + ICCB1;

            gfOpenWindow(strURL, 800, 600, 'BSC0601S1');

            return false;
        }

        function doSaving() {
            return confirm("저장하시겠습니까?");
        }
    </script>

</head>
<body style="margin-bottom: 0px; margin-left: 0px; margin-right: 0px; margin-top: 0px;">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%;" border="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="height: 40px; background-image: url(../images/title/popup_t_bg.gif);">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                                        class="cssPopTitleArea">
                                        <asp:Label ID="lblPopUpTitle" runat="server" Text="Data Interface Code" CssClass="cssPopTitleTxt"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        <img alt="" src="../images/title/popup_img.gif" />
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
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%;" border="0">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                <tr>
                                    <td style="width: 15px;">
                                        <img src="../images/title/ma_t14.gif" alt="" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTitle1" runat="server" Style="font-weight: bold" Text="Data Interface 기본정보" />
                                    </td>
                                </tr>
                            </table>
                            <%--<img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" />&nbsp;Data Interface 기본정보--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%" border="0"
                                class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle" align="center">
                                        Data Source
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlSOURCE_ID" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblTitle" align="center">
                                        Interface Type
                                    </td>
                                    <td class="cssTblContent">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 150px;">
                                                    <asp:DropDownList ID="ddlINPUT_TYPE" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkDailyResultKpi" runat="server" Text="일일실적지표 대상" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle" style="width: 10%;" align="center">
                                        CODE
                                    </td>
                                    <td class="cssTblContent" style="width: 15%;">
                                        <asp:TextBox ID="txtDICODE" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="cssTblTitle" style="width: 10%;" align="center">
                                        NAME
                                    </td>
                                    <td class="cssTblContent" style="width: 35%;">
                                        <asp:TextBox ID="txtDINAME" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle" style="width: 10%;" align="center">
                                        사용여부
                                    </td>
                                    <td class="cssTblContent" style="width: 10%;">
                                        <asp:Label runat="server" ID="lblUseYN" Width="100%"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle" style="width: 10%;" align="center">
                                        정의
                                    </td>
                                    <td class="cssTblContent" colspan="5">
                                        <asp:TextBox runat="server" ID="txtDEFINITION" TextMode="MultiLine" Width="100%"
                                            Height="70px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td style="margin-left: 5px; vertical-align: top;">
                            <ig:UltraWebTab runat="server" ID="ugrdDiCodeTab" Height="100%" ThreeDEffect="False"
                                Width="100%" SelectedTab="0" AutoPostBack="True" OnTabClick="ugrdDiCodeTab_TabClick">
                                <Tabs>
                                    <ig:Tab Text="Data Interface 컬럼정의" Key="1">
                                        <Style Width="180px" Height="25px" />
                                        <ContentTemplate>
                                            <ig:UltraWebGrid ID="ugrdDIColumn" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdDIColumn_InitializeLayout"
                                                OnInitializeRow="ugrdDIColumn_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="DICODE" DataType="System.String" EditorControlID=""
                                                                FooterText="" Format="" HeaderText="DICODE" Key="DICODE" Width="80px" MergeCells="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="CODE">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke" Wrap="true">
                                                                </CellStyle>
                                                                <Footer Caption="">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Footer>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="S_USE_YN" HeaderText="S_USE_YN" Hidden="false"
                                                                Key="S_USE_YN" Width="40px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="사용">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <asp:CheckBox runat="server" ID="chkUseYn" BackColor="whitesmoke" />
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="S_SORT_ORDER" HeaderText="S_SORT_ORDER" Hidden="false"
                                                                Key="S_SORT_ORDER" Width="40px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="순서">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <ig:WebNumericEdit ID="txtSortOrder" runat="server" Width="100%" Height="100%" Nullable="False"
                                                                        ValueText="0" MaxValue="20" MinValue="0" ToolTip="" NegativeForeColor="Magenta"
                                                                        HorizontalAlign="center" BackColor="whitesmoke" Font-Size="9pt" Font-Names="Verdana"
                                                                        NullText="0" MinDecimalPlaces="None">
                                                                    </ig:WebNumericEdit>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="S_COL_NAME" HeaderText="S_COL_NAME" Hidden="false"
                                                                Key="S_COL_NAME" Width="180px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="열명">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <asp:TextBox runat="server" ID="txtColumnName" Width="100%" Height="100%" BackColor="whitesmoke"></asp:TextBox>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="S_GRID_WIDTH" HeaderText="S_GRID_WIDTH" Hidden="false"
                                                                Key="S_GRID_WIDTH" Width="50px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="너비">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="whitesmoke">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <ig:WebNumericEdit ID="txtGridWidth" runat="server" Width="96%" Height="100%" Nullable="False"
                                                                        ValueText="0" MaxValue="500" MinValue="0" ToolTip="Grid Width" NegativeForeColor="Magenta"
                                                                        BackColor="whitesmoke" Font-Size="9pt" Font-Names="Verdana" NullText="0" MinDecimalPlaces="None">
                                                                    </ig:WebNumericEdit>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="D_USE_YN" HeaderText="D_USE_YN" Hidden="false"
                                                                Key="D_USE_YN" Width="40px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="사용">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="lavender">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <asp:CheckBox runat="server" ID="chkUseYn" BackColor="lavender" />
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="D_SORT_ORDER" HeaderText="D_SORT_ORDER" Hidden="false"
                                                                Key="D_SORT_ORDER" Width="40px">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="순서">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="lavender">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <ig:WebNumericEdit ID="txtSortOrder" runat="server" Width="100%" Height="100%" Nullable="False"
                                                                        ValueText="0" MaxValue="20" MinValue="0" ToolTip="" NegativeForeColor="Magenta"
                                                                        HorizontalAlign="center" BackColor="lavender" Font-Size="9pt" Font-Names="Verdana"
                                                                        NullText="0" MinDecimalPlaces="None">
                                                                    </ig:WebNumericEdit>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="D_COL_NAME" HeaderText="D_COL_NAME" Hidden="false"
                                                                Key="D_COL_NAME" Width="180px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="열명">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="lavender">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <asp:TextBox runat="server" ID="txtColumnName" Width="100%" Height="100%" BackColor="lavender"></asp:TextBox>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="D_UNIT_REF_ID" HeaderText="D_UNIT_REF_ID" Hidden="false"
                                                                Key="D_UNIT_REF_ID" Width="100px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="단위">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="lavender">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <asp:DropDownList ID="ddlUnit" runat="server" Width="98%">
                                                                    </asp:DropDownList>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="D_DECIMAL_POINTS" HeaderText="D_DECIMAL_POINTS"
                                                                Hidden="false" Key="D_DECIMAL_POINTS" Width="45px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="소수점">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="lavender">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <ig:WebNumericEdit ID="txtDecimalPoints" runat="server" Width="100%" Height="100%"
                                                                        Nullable="False" ValueText="0" MaxValue="20" MinValue="0" ToolTip="" NegativeForeColor="Magenta"
                                                                        HorizontalAlign="center" BackColor="lavender" Font-Size="9pt" Font-Names="Verdana"
                                                                        NullText="0" MinDecimalPlaces="None">
                                                                    </ig:WebNumericEdit>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="D_GRID_WIDTH" HeaderText="D_GRID_WIDTH" Hidden="false"
                                                                Key="D_GRID_WIDTH" Width="50px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="너비">
                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Left" BackColor="lavender">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <ig:WebNumericEdit ID="txtGridWidth" runat="server" Width="96%" Height="100%" Nullable="False"
                                                                        ValueText="0" MaxValue="500" MinValue="0" ToolTip="" NegativeForeColor="Magenta"
                                                                        HorizontalAlign="Right" BackColor="lavender" Font-Size="9pt" Font-Names="Verdana"
                                                                        NullText="0" MinDecimalPlaces="None">
                                                                    </ig:WebNumericEdit>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn BaseColumnName="S_COLUMN_ID" DataType="System.String" EditorControlID=""
                                                                Hidden="true" FooterText="" Format="" HeaderText="S_COLUMN_ID" Key="S_COLUMN_ID"
                                                                Width="50px" MergeCells="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="S_COLUMN_ID">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="D_COLUMN_ID" DataType="System.String" EditorControlID=""
                                                                Hidden="true" FooterText="" Format="" HeaderText="D_COLUMN_ID" Key="D_COLUMN_ID"
                                                                Width="50px" MergeCells="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="D_COLUMN_ID">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="S_INSERTED_YN" DataType="System.String" EditorControlID=""
                                                                Hidden="true" FooterText="" Format="" HeaderText="S_INSERTED_YN" Key="S_INSERTED_YN"
                                                                Width="50px" MergeCells="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="S_INSERTED_YN">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="D_INSERTED_YN" DataType="System.String" EditorControlID=""
                                                                Hidden="true" FooterText="" Format="" HeaderText="D_INSERTED_YN" Key="D_INSERTED_YN"
                                                                Width="50px" MergeCells="true">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header Caption="D_INSERTED_YN">
                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                </Header>
                                                                <CellStyle HorizontalAlign="Center" BackColor="whitesmoke">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout Name="ugrdDicode" Version="4.00" CellPaddingDefault="2" AllowColSizingDefault="Free"
                                                    AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes" AllowSortingDefault="Yes"
                                                    BorderCollapseDefault="Separate" HeaderClickActionDefault="SortMulti" RowHeightDefault="23px"
                                                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" ViewType="Flat" CellClickActionDefault="CellSelect"
                                                    TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                    <%--<GroupByBox>
                                                    <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="0px" Bottom="0px" Right="0px" Top="0px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="22px">
                                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="420px"
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
                                                    <%--<ClientSideEvents RowSelectorClickHandler="RowSelectorClickHandler" 
                                                                        DblClickHandler="ugrdKpiResultList_DblClickHandler"/>--%>
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
                                        </ContentTemplate>
                                    </ig:Tab>
                                    <ig:TabSeparator>
                                        <Style Width="0px">
                                            </Style>
                                    </ig:TabSeparator>
                                    <ig:Tab Text="Data Interface Query" Key="2">
                                        <Style Width="180px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td style="width: 20%;">
                                                        <asp:ListBox ID="lstField" CssClass="box01" runat="server" Height="100%" Width="100%"
                                                            SelectionMode="Single" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="lstListField_SelectedIndexChanged">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                            <tr style="height: 50%;">
                                                                <td>
                                                                    <asp:TextBox ID="txtQUERY" runat="server" TextMode="MultiLine" Height="100%" Width="100%"
                                                                        Wrap="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                                                                        OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                                                        <Bands>
                                                                            <ig:UltraGridBand>
                                                                            </ig:UltraGridBand>
                                                                        </Bands>
                                                                        <DisplayLayout CellPaddingDefault="2" BorderCollapseDefault="Separate" HeaderClickActionDefault="NotSet"
                                                                            Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No" Version="4.00"
                                                                            ReadOnly="LevelTwo" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header"
                                                                            AutoGenerateColumns="true" OptimizeCSSClassNamesOutput="False">
                                                                            <%--<GroupByBox>
                                                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                            </GroupByBox>
                                                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                            </GroupByRowStyleDefault>
                                                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                            </FooterStyleDefault>
                                                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt">
                                                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                                <Padding Left="3px" />
                                                                            </RowStyleDefault>
                                                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False">
                                                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                                            </HeaderStyleDefault>
                                                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                            </EditCellStyleDefault>
                                                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                                                BorderWidth="1px" Font-Names="Arial" Font-Size="8pt" Height="100%"
                                                                                Width="100%" Font-Bold="False">
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
                                                
                                                
                                                <%--<tr style="height: 50%;">
                                                    <td style="vertical-align: top; width: 20%; padding-top: 1px;" rowspan="2">
                                                    </td>
                                                    <td style="vertical-align: top;">
                                                    </td>
                                                </tr>
                                                <tr style="height: 50%;">
                                                    <td style="vertical-align: top; background-color: Red;">
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                    <ig:TabSeparator>
                                        <Style Width="0px">
                                            </Style>
                                    </ig:TabSeparator>
                                    <ig:Tab Text="Data Preview" Key="3">
                                        <Style Width="180px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; height: 100%;">
                                                        <ig:UltraWebGrid ID="ugrdPreview" runat="server" Visible="false" Width="100%" Height="100%"
                                                            OnInitializeLayout="ugrdPreview_InitializeLayout">
                                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" RowHeightDefault="18px"
                                                                Version="4.00" SelectTypeRowDefault="Single" BorderCollapseDefault="Separate"
                                                                Name="ugrdPreview" TableLayout="Fixed" ViewType="Flat" StationaryMargins="Header"
                                                                AutoGenerateColumns="False">
                                                                <%--<GroupByBox>
                                                        <BoxStyle BackColor="WhiteSmoke" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    
                                                    <RowSelectorStyleDefault BorderWidth="1px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="0px" Bottom="0px" Right="0px" Top="0px" />
                                                    </RowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="22px">
                                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                    </HeaderStyleDefault>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="420px"
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
                                                    <ClientSideEvents />--%>
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
                                                                    <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                                                    <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                                                    <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                                                    <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                                                                </Images>
                                                            </DisplayLayout>
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                        </ig:UltraWebGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                </Tabs>
                                <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff">
                                </DefaultTabStyle>
                                <SelectedTabStyle CssClass="cssTabStyleOn">
                                </SelectedTabStyle>
                                <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif"
                                    SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                            </ig:UltraWebTab>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td style="margin-left: 5px; padding-right: 5px;" align="right">
                            <%/** 2011-06-03 수정 시작 **/ %>
                            <%/** 2011-06-03 수정 완료 **/ %>
                            <table cellpadding="0" cellspacing="0" style="height: 100%; width: 100%;" border="0">
                                <tr>
                                    <%--<td runat="server" id="tdtitle1" style="width:70px; height:13px; margin-left:5px; vertical-align:middle;" align="left" class="tableTitle">
                                    평가기간&nbsp;
                                </td>--%>
                                    <%--<td style="width: 200px; height:13px; margin-left:5px; vertical-align:middle;" align="right">                        
                                </td>--%>
                                    <td style="margin-left: 5px; vertical-align: middle;" align="right">
                                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" class="box01" Width="00" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" Visible="false">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlEstTermMonth" runat="server" class="box01" Width="0" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlEstTermMonth_SelectedIndexChanged" Visible="false">
                                        </asp:DropDownList>
                                        &nbsp;<asp:FileUpload ID="fldExcelFile" runat="server" Width="450px" CssClass="txt"
                                            Visible="false" />&nbsp;
                                    </td>
                                    <td style="margin-left: 5px; vertical-align: middle;" align="right">
                                        <asp:ImageButton ID="iBtnClear" runat="server" ImageUrl="~/images/btn/b_075.gif"
                                            OnClick="iBtnClear_Click" />
                                        <asp:ImageButton ID="iBtnUpload" ImageUrl="~/images/btn/b_040.gif" runat="server"
                                            OnClick="iBtnUpload_Click" AlternateText="업로드" Visible="false" />
                                        <asp:ImageButton ID="iBtnDownload" ImageUrl="~/images/btn/b_041.gif" runat="server"
                                            OnClick="iBtnDownload_Click" AlternateText="다운로드" Visible="false" />
                                        <asp:ImageButton ID="iBtnSave" ImageUrl="~/images/btn/b_tp07.gif" runat="server"
                                            OnClick="iBtnSave_Click" OnClientClick="return doSaving();" AlternateText="저장"
                                            Visible="false" />
                                        <asp:ImageButton ID="iBtnInsert" ImageUrl="~/images/btn/b_001.gif" runat="server"
                                            OnClick="iBtnInsert_Click" AlternateText="등록" />
                                        <asp:ImageButton ID="iBtnUpdate" ImageUrl="~/images/btn/b_002.gif" runat="server"
                                            OnClick="iBtnUpdate_Click" AlternateText="수정" />
                                        <asp:ImageButton ID="iBtnDelete" ImageUrl="~/images/btn/b_208.gif" runat="server"
                                            OnClick="iBtnDelete_Click" AlternateText="사용안함" />
                                        <asp:ImageButton ID="iBtnReUse" ImageUrl="~/images/btn/b_138.gif" runat="server"
                                            OnClick="iBtnReUse_Click" />
                                        <asp:ImageButton ID="iBtnPreView" runat="server" ImageUrl="~/images/btn/b_209.gif"
                                            OnClientClick="return OpenPreviewWindow();" AlternateText="미리보기" />
                                        <asp:ImageButton ID="iBtnClose" ImageUrl="~/images/btn/b_003.gif" runat="server"
                                            OnClick="iBtnClose_Click" AlternateText="닫기" />
                                    </td>
                                </tr>
                            </table>
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
    <asp:DropDownList ID="ddlUnit_Hdf" runat="server" Visible="false">
    </asp:DropDownList>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
