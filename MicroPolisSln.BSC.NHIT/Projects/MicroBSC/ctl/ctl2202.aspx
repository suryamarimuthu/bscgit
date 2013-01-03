<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2202.aspx.cs" Inherits="usr_usr2202" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html; " />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
<!--
        // 창닫기
        function imgClose_onclick() {
            self.close();
        }
-->
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td>
                            <img src="../images/title/popup_t24.gif">
                        </td>
                        <td align="right">
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
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td width="250">
                            <div style="border: #F4F4F4 3px solid; overflow: auto; width: 240; height: 495">
                                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                    ImageSet="XPFileExplorer" NodeIndent="15">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr runat="server" id="trEmpID">
                                                <td class="cssTblTitleSingle" align="center">
                                                    상신자 선택
                                                </td>
                                                <td class="cssTblcontentSingle">
                                                    <asp:TextBox ID="txtEmpID" runat="server" Width="0px" BorderWidth="0px"></asp:TextBox>
                                                    <asp:TextBox ID="txtEmpName" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:Literal ID="ltrEmpButton" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitleSingle" align="center">
                                                    결재선 타입
                                                </td>
                                                <td class="cssTblcontentSingle">
                                                    <asp:Label ID="lblBizTypeName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                                <tr>
                                    <td>
                                        <img src="../images/sst_11.gif">
                                    </td>
                                </tr>
                                <tr style="height:50%;">
                                    <td>
                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn HeaderText="선택" Key="selchk1" Width="30px">
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="selchk1" runat="server" />
                                                            </CellTemplate>
                                                            <Header Caption="선택">
                                                            </Header>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME">
                                                            <Header Caption="성명">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME">
                                                            <Header Caption="부서">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" HeaderText="직책" Key="POSITION_NAME">
                                                            <Header Caption="직책">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" HeaderText="empid" Hidden="True"
                                                            Key="EMP_REF_ID">
                                                            <Header Caption="empid">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" HeaderText="deptid" Hidden="True"
                                                            Key="DEPT_REF_ID">
                                                            <Header Caption="deptid">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POSITION_ID" HeaderText="jobcode" Hidden="True"
                                                            Key="POSITION_ID">
                                                            <Header Caption="jobcode">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowSortingDefault="Yes" AllowColSizingDefault="Free"
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" BorderCollapseDefault="Separate"
                                                AllowDeleteDefault="Yes" RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer"
                                                SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect"
                                                SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header"
                                                StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
                                                <%--<GroupByBox>
                                                    <style backcolor="ActiveBorder" bordercolor="Window">
                                                        </style>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                    <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                                    ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                                    GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                                    RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left"
                                                    BorderColor="#E5E5E5" ForeColor="White">
                                                    <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="2px"
                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="175px" Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <style backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                                        <
                                                        BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </
                                                        BorderDetails ></style>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <style backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" borderwidth="1px">
                                                        <
                                                        BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </
                                                        BorderDetails ></style>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>--%>
                                                
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
                                        <asp:ImageButton ID="ibtnSelect" runat="server" ImageUrl="~/images/btn/b_007.gif"
                                            Height="19px" OnClick="ibtnSelect_Click" />
                                        <asp:ImageButton ID="ibtnDelete" Visible="false" runat="server" ImageUrl="~/images/btn/b_006.gif"
                                            Height="19px" OnClick="ibtnDelete_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../images/sst_12.gif">
                                    </td>
                                </tr>
                                <tr style="height:50%;">
                                    <td>
                                        <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" Height="175px">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <ig:TemplatedColumn HeaderText="선택" Key="selchk2" Width="30px">
                                                            <CellTemplate>
                                                                <asp:CheckBox ID="selchk2" runat="server" />
                                                            </CellTemplate>
                                                            <Header Caption="선택">
                                                            </Header>
                                                        </ig:TemplatedColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APP_STEP" HeaderText="결재순서" Key="APP_STEP">
                                                            <Header Caption="결재순서">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="결재자명" Key="EMP_NAME">
                                                            <Header Caption="결재자명">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME">
                                                            <Header Caption="부서">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="POSITION_NAME" HeaderText="직위" Key="POSITION_NAME">
                                                            <Header Caption="직위">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="APP_EMP_ID" HeaderText="" Hidden="True" Key="APP_EMP_ID">
                                                            <Header Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_CODE" HeaderText="" Hidden="True" Key="BIZ_TYPE_CODE">
                                                            <Header Caption="">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                    </Columns>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" ViewType="Flat" Version="4.00" AllowSortingDefault="Yes"
                                                AllowColSizingDefault="Free" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2"
                                                BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" RowSelectorsDefault="No"
                                                RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single"
                                                AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single"
                                                SelectTypeColDefault="Single" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True"
                                                TableLayout="Fixed">
                                                <%--<GroupByBox>
                                                    <style backcolor="ActiveBorder" bordercolor="Window">
                                                        </style>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                    <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                                    ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                                    GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                                    RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left"
                                                    BorderColor="#E5E5E5" ForeColor="white">
                                                    <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="2px"
                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="192px" Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <style backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                                        <
                                                        BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </
                                                        BorderDetails ></style>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <style backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" borderwidth="1px">
                                                        <
                                                        BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </
                                                        BorderDetails ></style>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>--%>
                                                
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
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td align="left">
                            <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="~/images/btn/b_032.gif" OnClick="ibtnSave_Click" />
                            <asp:ImageButton ID="ibtnRemove" runat="server" ImageUrl="~/images/btn/b_073.gif" OnClick="ibtnRemove_Click" />
                        </td>
                        <td align="right">
                            <br />
                            <img src="../images/btn/b_003.gif" border="0" id="imgClose" onclick="return imgClose_onclick()" />
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
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
