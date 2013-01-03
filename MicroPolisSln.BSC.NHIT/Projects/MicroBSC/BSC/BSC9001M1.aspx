<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC9001M1.aspx.cs" Inherits="BSC_BSC9001M1" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템::메일보내기</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript" language="javascript">
        var divWidth = 700;
        var divHeight = 500;
        function ShowUser(sender) {
            //var rect = sender.getBoundingClientRect();

            //alert(rect.right);

            //        ret.left   = rect.left   + (document.documentElement.scrollLeft || document.body.scrollLeft); 
            //        ret.top    = rect.top    + (document.documentElement.scrollTop || document.body.scrollTop); 
            //        ret.width  = rect.right  - rect.left;
            //        ret.height = rect.bottom - rect.top;

            var objLine = window.document.getElementById("divAreaAppLine");
            var rect = objLine.getBoundingClientRect();

            if (objLine != null) {
                objLine.style.display = "block";
                objLine.style.position = "absolute";
                //objLine.style.left   = (window.document.body.offsetWidth - divWidth)/2;
                //objLine.style.top    = (window.document.body.offsetHeight - divHeight) / 2;
                //objLine.style.width  = divWidth;
                //objLine.style.height = divHeight;
            }

            return false;
        }

        function HiddenUser() {
            var objLine = window.document.getElementById("divAreaAppLine");
            if (objLine != null) {
                objLine.style.display = "none";
            }

            return false;
        }

        // 결재선에 선택된 사용자 추가
        function getSelectEmp() {
            var EmpGrd = igtbl_getGridById("ugrdEmpList");
            var LinGrd = igtbl_getGridById("ugrdAppLine");

            //---------------------------------------------- 결재선에 추가
            var EmpRow = EmpGrd.getActiveRow();

            if (EmpRow == null) {
                alert("사원을 선택해주십시오");
                return false;
            }
            else if (getIsAddEmp(EmpRow.getCellFromKey("EMP_REF_ID").getValue(), LinGrd)) {
                alert("이미 추가된 사원입니다.");
                return false;
            }
            else {
                var nRow = LinGrd.Rows.addNew();

                nRow.getCell(0).setValue(EmpRow.getCell(0).getValue());
                nRow.getCell(1).setValue(EmpRow.getCell(1).getValue());
                nRow.getCell(2).setValue(EmpRow.getCell(2).getValue());
                nRow.getCell(3).setValue(EmpRow.getCell(3).getValue());
                nRow.getCell(4).setValue(EmpRow.getCell(4).getValue());

                nRow.activate();
            }

            return false;
        }

        // 추가된 사용자인지의 구분
        function getIsAddEmp(add_emp_id, pGrid) {
            var iRow = pGrid.Rows.length;
            var emp_id = "";
            for (var i = 0; i < iRow; i++) {
                emp_id = pGrid.Rows.getRow(i).getCellFromKey("EMP_REF_ID").getValue();
                if (add_emp_id == emp_id) {
                    return true;
                }
            }

            return false;
        }

        function DeleteEmp() {
            var objGrd = igtbl_getGridById("ugrdAppLine");
            var cntRow = (objGrd != null) ? objGrd.Rows.length - 1 : 0;

            //---------------------------------------------- 현재, 이전, 다음,다다음행
            var CurrRow = objGrd.getActiveRow();
            var PrevRow = (CurrRow != null) ? CurrRow.getPrevRow() : null;
            var NextRow = (CurrRow != null) ? CurrRow.getNextRow() : null;
            var NNxtRow = (NextRow != null) ? NextRow.getNextRow() : null;
            //---------------------------------------------- 현재, 이전, 다음셀 순서
            var CurrNo = (CurrRow != null) ? CurrRow.getCell(0).getValue() : 0;
            var PrevNo = (PrevRow != null) ? PrevRow.getCell(0).getValue() : 0;
            var NextNo = (NextRow != null) ? NextRow.getCell(0).getValue() : 0;
            //---------------------------------------------- 현재, 이전, 다음행의 Index
            var PrevIdx = (PrevRow != null) ? PrevRow.getIndex() : null;
            var CurrIdx = (CurrRow != null) ? CurrRow.getIndex() : null;
            var NextIdx = (NextRow != null) ? NextRow.getIndex() : null;

            if (CurrRow) {
                CurrRow.remove();
            }

            if (NextRow) {
                NextRow.setSelected();
                NextRow.activate();
            }

            return false;
        }
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="40" valign="top">
                                        <img src="../images/title/popup_t4.gif">
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
                    <tr style="height: 100%;">
                        <td>
                            <table border="0" width="100%" cellpadding="0" cellspacing="0" style="height: 100%;">
                                <tr>
                                    <td rowspan="2" align="center">
                                        <asp:Button runat="server" ID="btnSendMail" Text="보내기" Width="100px" Height="65px" />
                                    </td>
                                    <td style="width: 120px;">
                                        <asp:Button runat="server" ID="Button1" Text="제       목" Width="118px" Height="100%"
                                            OnClientClick="return false;" BackColor="Transparent" BorderColor="White" BorderWidth="0px"
                                            BorderStyle="None" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtTitle" Text="" Width="550px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; height: 40px; padding: 0px 0px 0px 0px;">
                                        <asp:Button runat="server" ID="btnMailFrom" Text="받는사람" Width="118px" Height="45px"
                                            OnClientClick="return ShowUser(this)" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMailTo" Text="" Width="98%" ReadOnly="true" TextMode="MultiLine"
                                            Height="40px" BackColor="WhiteSmoke"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 100%;">
                                    <td colspan="3">
                                        <ig:WebHtmlEditor runat="server" ID="wheMail" Width="100%" Height="100%" ImageDirectory="~/_common/infragistics/HtmlEditor">
                                        </ig:WebHtmlEditor>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divAreaAppLine" runat="server" style="width: 100%; height: 100%; position: absolute;
                                top: 40px; left: 80px;">
                                <table border="1" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;
                                    background-color: #D6E3F2; border-collapse: collapse;">
                                    <tr>
                                        <td colspan="2" style="height: 20px; background-image: url(../images/bg/bg_heading.png);">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; font-weight: bold;">
                                            &nbsp;☞조직정보
                                        </td>
                                        <td style="text-align: left; font-weight: bold;">
                                            &nbsp;☞사원명
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%; vertical-align: top; empty-cells: show;" rowspan="2">
                                            <div id="divDeptTree" style="width: 100%; height: 380px; overflow: scroll;">
                                                <asp:TreeView ID="trvDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                                    BorderWidth="0px" Width="92%" Height="100%" ShowLines="false">
                                                    <ParentNodeStyle Font-Bold="False" BorderWidth="0px" />
                                                    <SelectedNodeStyle BackColor="#E0E0E0" Font-Underline="False" HorizontalPadding="1px"
                                                        VerticalPadding="0px" />
                                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                                        NodeSpacing="0px" VerticalPadding="0px" BorderWidth="0px" />
                                                    <RootNodeStyle BorderWidth="0px" />
                                                    <LeafNodeStyle BorderWidth="0px" />
                                                    <HoverNodeStyle BorderWidth="0px" />
                                                </asp:TreeView>
                                            </div>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="vertical-align: top;">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="divEmpList" style="width: 100%; height: 180px; overflow: hidden; vertical-align: top;">
                                                            <ig:UltraWebGrid ID="ugrdEmpList" runat="server" Width="100%" Height="100%">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" Width="70px"
                                                                                Hidden="false">
                                                                                <Header Caption="부서">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME" Width="60px">
                                                                                <Header Caption="성명">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" HeaderText="직책" Key="POSITION_RANK_NAME"
                                                                                Width="50px">
                                                                                <Header Caption="직책">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EMP_EMail" HeaderText="EMP_EMail" Key="EMP_EMail"
                                                                                NullText="-" Width="130px" Hidden="false">
                                                                                <Header Caption="E-Mail">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle" TextOverflow="Ellipsis">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" HeaderText="empid">
                                                                                <Header Caption="empid">
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                        </Columns>
                                                                    </ig:UltraGridBand>
                                                                </Bands>
                                                                <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowSortingDefault="Yes" AllowColSizingDefault="Free"
                                                                    HeaderClickActionDefault="NotSet" SortingAlgorithmDefault="NotSet" Name="ugrdEmpList"
                                                                    BorderCollapseDefault="Separate" RowHeightDefault="16px" AllowColumnMovingDefault="OnServer"
                                                                    SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect"
                                                                    ColHeadersVisibleDefault="No" SelectTypeCellDefault="Single" SelectTypeColDefault="Single"
                                                                    StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
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
                                                                    <RowStyleDefault BackColor="White" BorderColor="White" BorderStyle="Solid" BorderWidth="0px"
                                                                        Cursor="Hand">
                                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                        <Padding Left="0px" />
                                                                    </RowStyleDefault>
                                                                    <RowSelectorStyleDefault BackColor="WhiteSmoke" BorderColor="White" Width="15px">
                                                                        <Padding Bottom="0px" Left="0px" Right="0px" Top="0px" />
                                                                    </RowSelectorStyleDefault>
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center"
                                                                        BorderColor="#E5E5E5" ForeColor="White">
                                                                        <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="0px"
                                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                                                    </FrameStyle>
                                                                    <Pager>
                                                                        <style backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" />
                                                                        </style>
                                                                    </Pager>
                                                                    <AddNewBox Hidden="true">
                                                                        <style backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" borderwidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" />
                                                                        </style>
                                                                    </AddNewBox>
                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                    </SelectedRowStyleDefault>
                                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                                    </ActivationObject>
                                                                    <Images ImageDirectory="">
                                                                    </Images>--%>
                                                                    <ClientSideEvents DblClickHandler="getSelectEmp" />
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
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:ImageButton ID="btnLineSelect" runat="server" ImageUrl="~/images/btn/btn_add_04.gif"
                                                            OnClientClick="return getSelectEmp();" />
                                                        <asp:ImageButton ID="btnRemove" runat="server" ImageUrl="~/images/btn/btn_add_03.gif"
                                                            OnClientClick="return DeleteEmp();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <div id="divAppLine" style="width: 100%; height: 130px; overflow: hidden;">
                                                            <ig:UltraWebGrid ID="ugrdAppLine" runat="server" Width="100%" Height="100%">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" Width="70px"
                                                                                AllowUpdate="No">
                                                                                <Header Caption="부서">
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="whitesmoke">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME" Width="60px"
                                                                                AllowUpdate="No">
                                                                                <Header Caption="성명">
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="whitesmoke">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" HeaderText="직책" Key="POSITION_RANK_NAME"
                                                                                Width="50px" AllowUpdate="No">
                                                                                <Header Caption="직책">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="whitesmoke">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EMP_EMail" HeaderText="EMP_EMail" Key="EMP_EMail"
                                                                                NullText="-" Width="110px" Hidden="false">
                                                                                <Header Caption="E-Mail">
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Header>
                                                                                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle" TextOverflow="Ellipsis">
                                                                                </CellStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="3" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" HeaderText="EMP_REF_ID">
                                                                                <Header Caption="EMP_REF_ID">
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Header>
                                                                                <Footer>
                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                </Footer>
                                                                            </ig:UltraGridColumn>
                                                                        </Columns>
                                                                    </ig:UltraGridBand>
                                                                </Bands>
                                                                <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowSortingDefault="Yes" AllowColSizingDefault="Free"
                                                                    HeaderClickActionDefault="NotSet" SortingAlgorithmDefault="NotSet" Name="ugrdAppLine"
                                                                    BorderCollapseDefault="Separate" AllowDeleteDefault="No" AllowRowNumberingDefault="None"
                                                                    AllowAddNewDefault="Yes" AllowUpdateDefault="Yes" RowSelectorsDefault="Yes" RowHeightDefault="16px"
                                                                    AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" AutoGenerateColumns="False"
                                                                    CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single"
                                                                    StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
                                                                    <GroupByBox>
                                                                        <style backcolor="ActiveBorder" bordercolor="Window">
                                                                            </style>
                                                                    </GroupByBox>
                                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                        <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                    </GroupByRowStyleDefault>
                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                    </FooterStyleDefault>
                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px"
                                                                        Cursor="hand">
                                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                        <Padding Left="2px" />
                                                                    </RowStyleDefault>
                                                                    <RowSelectorStyleDefault BackColor="whitesmoke" BorderColor="white" Width="15px">
                                                                        <Padding Bottom="0" Left="0" Right="0" Top="0" />
                                                                    </RowSelectorStyleDefault>
                                                                    <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                                                        ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                                                        GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                                                        RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center"
                                                                        BorderColor="#E5E5E5" ForeColor="White">
                                                                        <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="0px"
                                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                                                    </FrameStyle>
                                                                    <Pager>
                                                                        <style backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" /></style>
                                                                    </Pager>
                                                                    <AddNewBox Hidden="true">
                                                                        <style backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" borderwidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" /></style>
                                                                    </AddNewBox>
                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                    </SelectedRowStyleDefault>
                                                                </DisplayLayout>
                                                            </ig:UltraWebGrid>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr class="cssPopBtnLine">
                                        <td align="right" colspan="2">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" style="text-align: right;">
                                                        <asp:ImageButton ID="btnLineConfirm" runat="server" ImageUrl="~/images/btn/b_094.gif" />
                                                        <asp:ImageButton ID="btnLineClose" runat="server" ImageUrl="~/images/btn/b_003.gif"
                                                            OnClientClick="return HiddenUser();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
