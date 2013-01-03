<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2109.aspx.cs" Inherits="ctl_ctl2109" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html; " />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/jscript" language="JavaScript" src="../_common/js/common.js"></script>

    <script id="Infragistics" type="text/javascript">
    <!--

        function MouseOverHandler(gridName, id, objectType) {
            if (objectType == 0) {
                var cell = igtbl_getElementById(id);
                var row = igtbl_getRowById(id);
                var band = igtbl_getBandById(id);
                var active = igtbl_getActiveRow(id);
                cell.style.cursor = 'hand';
            }
        }

        function SetValue(deptId, deptName, empId, empName) {
            var DeptKey = eval("opener.document.forms[0]." + document.forms[0].strDeptKey.value);
            var DeptVal = eval("opener.document.forms[0]." + document.forms[0].strDeptVal.value);
            var EmpKey = eval("opener.document.forms[0]." + document.forms[0].strEmpKey.value);
            var EmpVal = eval("opener.document.forms[0]." + document.forms[0].strEmpVal.value);

            DeptKey.value = deptId;
            DeptVal.value = deptName;
            EmpKey.value = empId;
            EmpVal.value = empName;
            window.close();
        }        
        
    // -->
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table style="width: 100%; height: 100%;" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image: url(../images/title/popup_t_bg.gif);">
                        <td height="40px" valign="top">
                            <img alt="" src="../images/title/popup_t23.gif" />
                        </td>
                        <td align="right" valign="top">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="4px;" bgcolor="#FFFFFF">
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
                    <tr style="height: 100%;">
                        <td width="250">
                            <div style="border: #F4F4F4 3px solid; overflow: auto; width: 240; height: 100%;">
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
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="250px" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn Key="SELECT" Width="40px" FooterText="" HeaderText="선택">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="선택" Title="">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>
                                                <Footer Caption="" Title="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME">
                                                <Header Caption="성명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" Width="150px">
                                                <Header Caption="부서">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="POSITION_CLASS_NAME" HeaderText="직급" Key="POSITION_CLASS_NAME">
                                                <Header Caption="직급">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" HeaderText="empid">
                                                <Header Caption="empid">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="DEPT_REF_ID" Hidden="True" Key="DEPT_REF_ID"
                                                HeaderText="deptid">
                                                <Header Caption="deptid">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="POSITION_ID" Hidden="True" Key="POSITION_ID"
                                                HeaderText="jobcode">
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
                                    StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed"
                                    OptimizeCSSClassNamesOutput="False">
                                    <%--<GroupByBox>
                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                        <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                        ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                        GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                        RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="center" BorderColor="#E5E5E5" ForeColor="White">
                        <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                        BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="250px"
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
                    <Images  ImageDirectory=""></Images>
                    <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
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
                    <tr class="cssPopBtnLine">
                        <td colspan="2">
                            <a href="javascript:window.close();">
                                <img alt="" src="../images/btn/b_003.gif" border="0" /></a>
                            <asp:HiddenField ID="strDeptKey" runat="server" />
                            <asp:HiddenField ID="strDeptVal" runat="server" />
                            <asp:HiddenField ID="strEmpKey" runat="server" />
                            <asp:HiddenField ID="strEmpVal" runat="server" />
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
    </table>
    </form>
</body>
</html>
