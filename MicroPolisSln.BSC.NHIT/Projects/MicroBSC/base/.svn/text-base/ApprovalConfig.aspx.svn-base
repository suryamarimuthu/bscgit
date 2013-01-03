<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApprovalConfig.aspx.cs" Inherits="BASE_ApprovalConfig" %>


    

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>결재선 지정</title>
    <link href="../_common/css/style.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        결재선 지정<br />
        <table style="width: 100%">
            <tr>
                <td rowspan="2" style="width: 100px" valign="top">
                    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="XPFileExplorer" NodeIndent="15">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                            VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
                <td style="width: 591px">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 579px; background-color: #efefef">
                                사용자</td>
                        </tr>
                        <tr>
                            <td style="width: 579px">
                    <ig:ultrawebgrid id="UltraWebGrid1" runat="server" width="100%" Height="180px"><Bands>
<ig:UltraGridBand>
<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
    <Columns>
        <ig:TemplatedColumn HeaderText="선택" Key="selchk1" Width="30px">
            <CellTemplate>
                <asp:CheckBox ID="selchk1" runat="server" />
            </CellTemplate>
            <Header Caption="선택">
            </Header>
        </ig:TemplatedColumn>
        <ig:UltraGridColumn BaseColumnName="empname" HeaderText="성명" Key="empname">
            <Header Caption="성명">
                <RowLayoutColumnInfo OriginX="1" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="deptname" HeaderText="부서" Key="deptname">
            <Header Caption="부서">
                <RowLayoutColumnInfo OriginX="2" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="2" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="jobname" HeaderText="직책" Key="jobname">
            <Header Caption="직책">
                <RowLayoutColumnInfo OriginX="3" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="3" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="empid" HeaderText="empid" Hidden="True" Key="empid">
            <Header Caption="empid">
                <RowLayoutColumnInfo OriginX="4" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="4" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="deptid" HeaderText="deptid" Hidden="True"
            Key="deptid">
            <Header Caption="deptid">
                <RowLayoutColumnInfo OriginX="5" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="5" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="jobcode" HeaderText="jobcode" Hidden="True"
            Key="jobcode">
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

<DisplayLayout CellPaddingDefault="2" ViewType="Flat" Version="4.00" AllowSortingDefault="Yes" AllowColSizingDefault="Free" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
<GroupByBox>
<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
</GroupByBox>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</FooterStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="Window" ColorLeft="Window"></BorderDetails>

<Padding Left="3px"></Padding>
</RowStyleDefault>

<HeaderStyleDefault HorizontalAlign="Left" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</HeaderStyleDefault>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FrameStyle BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif" BackColor="Window" Width="100%" Height="180px"></FrameStyle>

<Pager>
<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</Pager>

<AddNewBox Hidden="False">
<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</AddNewBox>
</DisplayLayout>
</ig:ultrawebgrid></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 579px">
                    <asp:ImageButton ID="ibtnSelect" runat="server" ImageUrl="~/image/btn/b_007.gif" OnClick="ibtnSelect_Click" /></td>
                        </tr>
                    </table>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 591px">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 579px; background-color: #efefef">
                                결재선</td>
                        </tr>
                        <tr>
                            <td style="width: 579px">
                    <ig:ultrawebgrid id="UltraWebGrid2" runat="server" width="100%" Height="180px"><Bands>
<ig:UltraGridBand>
<AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
    <Columns>
        <ig:TemplatedColumn HeaderText="선택" Key="selchk2" Width="30px">
            <CellTemplate>
                <asp:CheckBox ID="selchk2" runat="server" />
            </CellTemplate>
            <Header Caption="선택">
            </Header>
        </ig:TemplatedColumn>
        <ig:UltraGridColumn BaseColumnName="app_path_seq" HeaderText="결재순서" Key="app_path_seq">
            <Header Caption="결재순서">
                <RowLayoutColumnInfo OriginX="1" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="app_name" HeaderText="결재자명" Key="app_name">
            <Header Caption="결재자명">
                <RowLayoutColumnInfo OriginX="2" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="2" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="deptname" HeaderText="부서" Key="deptname">
            <Header Caption="부서">
                <RowLayoutColumnInfo OriginX="3" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="3" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="jobname" HeaderText="직위" Key="jobname">
            <Header Caption="직위">
                <RowLayoutColumnInfo OriginX="4" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="4" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="empid" HeaderText="empid" Hidden="True" Key="empid">
            <Header Caption="empid">
                <RowLayoutColumnInfo OriginX="5" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="5" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="deptid" HeaderText="deptid" Hidden="True"
            Key="deptid">
            <Header Caption="deptid">
                <RowLayoutColumnInfo OriginX="6" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="6" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn BaseColumnName="jobcode" HeaderText="jobcode" Hidden="True"
            Key="jobcode">
            <Header Caption="jobcode">
                <RowLayoutColumnInfo OriginX="7" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="7" />
            </Footer>
        </ig:UltraGridColumn>
        <ig:UltraGridColumn HeaderText="apptype" Hidden="True" Key="apptype">
            <Header Caption="apptype">
                <RowLayoutColumnInfo OriginX="8" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="8" />
            </Footer>
        </ig:UltraGridColumn>
    </Columns>
</ig:UltraGridBand>
</Bands>

<DisplayLayout CellPaddingDefault="2" ViewType="Flat" Version="4.00" AllowSortingDefault="Yes" AllowColSizingDefault="Free" HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" BorderCollapseDefault="Separate" AllowDeleteDefault="Yes" RowSelectorsDefault="No" RowHeightDefault="20px" AllowColumnMovingDefault="OnServer" SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect" SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
<GroupByBox>
<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
</GroupByBox>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</FooterStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="Window" ColorLeft="Window"></BorderDetails>

<Padding Left="3px"></Padding>
</RowStyleDefault>

<HeaderStyleDefault HorizontalAlign="Left" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</HeaderStyleDefault>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FrameStyle BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif" BackColor="Window" Width="100%" Height="180px"></FrameStyle>

<Pager>
<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</Pager>

<AddNewBox Hidden="False">
<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
</Style>
</AddNewBox>
</DisplayLayout>
</ig:ultrawebgrid></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 579px">
                    <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="~/image/btn/b_001.gif" OnClick="ibtnSave_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/image/btn/b_004.gif" OnClick="ibtnDelete_Click" />
                    <a href="#" onclick="self.close();"><img src="../images/btn/b_016.gif" border="0" /></a></td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
