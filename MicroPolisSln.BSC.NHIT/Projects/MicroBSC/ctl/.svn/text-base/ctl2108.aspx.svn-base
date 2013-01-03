<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2108.aspx.cs" Inherits="ctl_ctl2108" %>

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


        function SetValue(poolid, poolname) {
            var WorkPoolKey = eval("opener.document.forms[0]." + document.forms[0].WorkPoolKey.value);
            var WorkPoolVal = eval("opener.document.forms[0]." + document.forms[0].WorkPoolVal.value);

            WorkPoolKey.value = poolid;
            WorkPoolVal.value = poolname;

            window.close();
        }

        function UltraWebGrid1_DblClickHandler(gridName, cellId) {
            var row = igtbl_getRowById(cellId);
            var poolid = row.getCellFromKey("WORK_POOL_REF_ID").getValue();
            var poolname = row.getCellFromKey("WORK_NAME").getValue();
            var poolchk = 'Y';



            WorkPoolKey.value = poolid;
            WorkPoolVal.value = poolname;
            window.close();
        }

// -->
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <!--- MAIN START --->
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image:url(../images/title/popup_t_bg.gif);">
                        <td>
                            <img alt="" src="../images/title/popup_t106.gif" />
                        </td>
                        <td align="right" valign="top">
                            <img alt="" src="../images/title/popup_img.gif" />
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
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableBorder">
                                <tr>
                                    <td class="cssTblTitle">
                                        중점과제명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtWorkName" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="cssTblTitle">
                                        중요도
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlWorkPriority" runat="server" CssClass="box01" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        과제유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlWorkType" runat="server" CssClass="box01" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="cssTblTitle">
                                        사용여부
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlUseYN" runat="server" CssClass="box01" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif"
                                            OnClick="ibtnSearch_Click" ImageAlign="AbsMiddle" />
                        </td>
                    </tr>
                    <tr style="height:100%;">
                        <td>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
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
                                            <ig:UltraGridColumn BaseColumnName="WORK_POOL_REF_ID" EditorControlID="" FooterText=""
                                                Format="" HeaderText="WORK_POOL_REF_ID" Key="WORK_POOL_REF_ID" Width="100px"
                                                Hidden="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="WORK_POOL_REF_ID">
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_NAME" Key="WORK_NAME" Width="340px">
                                                <Header Caption="중점과제 명">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_PRIORITY" Key="WORK_PRIORITY" Width="140px"
                                                Hidden="true">
                                                <Header Caption="WORK_PRIORITY">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_PRIORITY_NAME" Key="WORK_PRIORITY_NAME"
                                                Width="160px">
                                                <Header Caption="중점과제 우선순위(중요도)">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE" Key="WORK_TYPE" Width="120px" Hidden="true">
                                                <Header Caption="WORK_TYPE">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE_NAME" Key="WORK_TYPE_NAME" Width="120px">
                                                <Header Caption="중점과제 유형">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ValueList DisplayStyle="NotSet">
                                                </ValueList>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" EditorControlID="" Width="35px"
                                                FooterText="" HeaderText="사용여부">
                                                <Header Caption="사용여부">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <HeaderStyle Wrap="True" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <CellTemplate>
                                                    <asp:Image runat="server" ID="imgUseYn" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                                    </asp:Image>
                                                </CellTemplate>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:TemplatedColumn>
                                            <ig:UltraGridColumn BaseColumnName="WORK_DESC" HeaderText="중점과제 설명" Key="WORK_DESC"
                                                Width="400px" Hidden="true">
                                                <Header Caption="중점과제 설명">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer>
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                        </RowTemplateStyle>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowSortingDefault="Yes" AllowColSizingDefault="Free"
                                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" BorderCollapseDefault="Separate"
                                    AllowDeleteDefault="Yes" RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer"
                                    SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect"
                                    SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header"
                                    StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
                                    <%--<GroupByBox>
                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                        </BoxStyle>
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
                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="center"
                                        BorderColor="#E5E5E5" ForeColor="White">
                                        <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                    </HeaderStyleDefault>
                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                    </EditCellStyleDefault>
                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="290px" Width="100%">
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
                                    </SelectedRowStyleDefault>--%>
                                    <ClientSideEvents MouseOverHandler="MouseOverHandler" />
                                    
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
                            <a href="javascript:window.close();">
                                <img alt="" src="../images/btn/b_003.gif" border="0" /></a>
                            <asp:HiddenField ID="WorkPoolKey" runat="server" />
                            <asp:HiddenField ID="WorkPoolVal" runat="server" />
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
    </form>
</body>
</html>
