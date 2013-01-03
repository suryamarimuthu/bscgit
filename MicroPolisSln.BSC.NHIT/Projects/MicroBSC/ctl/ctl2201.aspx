<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2201.aspx.cs" Inherits="ctl_ctl2201" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../_common/css/style.css" rel="stylesheet" type="text/css" />
    <title>결재선 지정</title>
    
    
    
</head>

<body style="width: 760px; font-weight: bold; font-size: 9pt; font-family: Verdana;">
    <form id="form1" runat="server">
        <div>
            <br />
            <table cellpadding="0" cellspacing="0" border="1" width="100%">
                <tr>
                    <td style="width: 100px;" class="tabletitle">
                        결재선종류</td>
                    <td>
                        <asp:DropDownList ID="ddlBizInfoList" runat="server">
                        </asp:DropDownList>
                        <a href="#null" onclick="OpenAppLine();"><img alt="결재선지정" border="0" id="imgAssign" style="width: 114px; height: 25px" /></a></td>
                    <td style="width: 100px;" class="tabletitle">
                        부서</td>
                    <td>
                        <asp:TextBox ID="txtDeptID" runat="server" Width="50px"></asp:TextBox>
                        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                        <a href="#null" onclick="gfOpenWindow('ctl2102.aspx', 310, 400)"><img src="../images/btn/go.gif" id="imgDeptSearch" border="0"/></a></td>
                </tr>
                <tr>
                    <td style="width: 100px;" class="tabletitle">
                        직책</td>
                    <td>
                        <asp:DropDownList ID="ddlPosition" runat="server">
                        </asp:DropDownList><a href="#" onclick="openwindow1();"></a></td>
                    <td style="width: 100px;" class="tabletitle">
                        사원명</td>
                    <td>
                        <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <asp:ImageButton ID="ibtnSearch" runat="server" Height="21px" ImageUrl="~/images/btn/b_010.gif" OnClick="ibtnSearch_Click" /></td>
                </tr>
            </table>
            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="300px" OnInitializeRow="UltraWebGrid1_InitializeRow"
                Width="100%">
                <Bands>
                    <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet">
                        </AddNewRow>
                        <Columns>
                            <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                                Key="selchk" Width="30px">
                                <CellTemplate>
                                    <asp:CheckBox ID="selchk" runat="server" />
                                </CellTemplate>
                                <Header Caption="선택">
                                </Header>
                                <Footer Caption="">
                                </Footer>
                            </ig:TemplatedColumn>
                            <ig:UltraGridColumn HeaderText="수정" Key="MODIFY" Type="HyperLink" Width="30px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="수정">
                                    
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="1" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="부서" Key="DEPT_NAME">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="부서">
                                    
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="2" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="성명" Key="EMP_NAME" Width="50px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="성명">
                                    
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="3" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="POSITION_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="직책" Key="POSITION_NAME" Width="50px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="직책">
                                    
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="4" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_NAME" EditorControlID="" FooterText=""
                                Format="" HeaderText="결재선종류" Key="BIZ_TYPE_NAME" Width="220px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="결재선종류">
                                    
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Header>
                                <Footer Caption="">
                                    <RowLayoutColumnInfo OriginX="5" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="APP_CNT" HeaderText="결재단계수" Key="APP_CNT">
                                <HeaderStyle HorizontalAlign="Center" />
                                <Header Caption="결재단계수">
                                    
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Header>
                                <Footer>
                                    <RowLayoutColumnInfo OriginX="6" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="BIZ_TYPE_CODE" FooterText="app_path_seq" HeaderText=""
                                Hidden="True" Key="BIZ_TYPE_CODE">
                                <Header Caption="">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Header>
                                <Footer Caption="app_path_seq">
                                    <RowLayoutColumnInfo OriginX="7" />
                                </Footer>
                            </ig:UltraGridColumn>
                            <ig:UltraGridColumn BaseColumnName="REP_EMP_ID" FooterText="deptid" Hidden="True"
                                Key="REP_EMP_ID">
                                <Header>
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Header>
                                <Footer Caption="deptid">
                                    <RowLayoutColumnInfo OriginX="8" />
                                </Footer>
                            </ig:UltraGridColumn>
                        </Columns>
                    </ig:UltraGridBand>
                </Bands>
                <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                    CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" JavaScriptFileName=""
                    JavaScriptFileNameCommon="" Name="UltraWebGrid1" RowHeightDefault="20px" RowSelectorsDefault="No"
                    SelectTypeCellDefault="Single" SelectTypeColDefault="Single" SelectTypeRowDefault="Single"
                    StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed"
                    Version="4.00">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                        ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                        GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                        RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                    <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Left">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                    </HeaderStyleDefault>
                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                    </EditCellStyleDefault>
                    <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="300px"
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
                    </SelectedRowStyleDefault>
                </DisplayLayout>
            </ig:UltraWebGrid></div>
        <table style="width: 100%">
            <tr>
                <td style="width: 100px">
                
                </td>
                <td align="right">
                    &nbsp;
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/btn/b_004.gif" OnClick="ibtnDelete_Click" /></td>
            </tr>
        </table>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>