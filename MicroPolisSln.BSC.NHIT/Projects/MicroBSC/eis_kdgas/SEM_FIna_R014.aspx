<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_FIna_R014.aspx.cs" Inherits="SEM_FIna_R014" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<!--META http-equiv="Page-Enter" content="blendTrans(Duration=0.3)">
<META http-equiv="Page-Exit" content="blendTrans(Duration=0.3)"-->
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
<!--- MAIN START --->
    <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF" class="box_tt01">
        <tr>
            <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">년월</font></strong></td>
            <td class="box_td01">
                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
            </td>
            <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">사업장</font></strong></td>
            <td class="box_td01">
                <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
            </td>
             <td align="right" class="box_td01">
                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
            </td>
        </tr>
    </table>
    <table width="800px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td><img alt="계획대비실적" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>토지보유 현황</strong></font></td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width=800px" height="95%" >
    	<tr>
    		<td>
    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="95%" >
    		    	<tr>
    		    		<td width=50% valign="top" align=center>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="LAND_ASSETS_ID_T" FooterText="" HeaderText="자산번호"
                                                Key="LAND_ASSETS_ID_T" Width="60px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="자산번호">
                                                    
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_ASSETS_NAME" FooterText="" HeaderText="소재지"
                                                Key="LAND_ASSETS_NAME" Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="소재지">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_USE" FooterText="" HeaderText="용도" Key="LAND_USE"
                                                Width="80px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="용도">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_TOTAL_AREA" FooterText="" Format="#,##0.##"
                                                HeaderText="총면적" Key="LAND_TOTAL_AREA" Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="총면적">
                                                    
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_PRICE" DataType="System.Double" FooterText=""
                                                Format="#,##0.##" HeaderText="공시지가" Key="LAND_PRICE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="공시지가">
                                                    
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_REGISTER_DATE" FooterText="" HeaderText="등기일자"
                                                Key="LAND_REGISTER_DATE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="등기일자">
                                                    
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_GET_DATE" FooterText="" HeaderText="취득일자"
                                                Key="LAND_GET_DATE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="취득일자">
                                                    
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_BOOK_AMOUNT" FooterText="" Format="#,##0.##"
                                                HeaderText="장부가액" Key="LAND_BOOK_AMOUNT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="장부가액">
                                                    
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_DATE_T" FooterText="" HeaderText="년월"
                                                Key="LAND_DATE_T" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="년월">
                                                    
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_OFFICE_T" FooterText="" HeaderText="사업장"
                                                Key="LAND_OFFICE_T" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="사업장">
                                                    
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="LAND_CHANGE_REASON" FooterText="" HeaderText="변동사유"
                                                Key="LAND_CHANGE_REASON" Width="120px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="변동사유">
                                                    
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Left">
                                                </CellStyle>
                                                <Footer Caption="">
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Footer>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                         ForeColor="White">
                        <BorderDetails  ColorLeft="85, 162, 176" ColorTop="85, 162, 176" />
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
                    </SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault BackColor="#E7E7E7">
                                    </RowAlternateStyleDefault>
                                </DisplayLayout>
                            </ig:UltraWebGrid></td>
    		    	</tr>
    		    </table>
    		</td>
    	</tr>
    </table>
<!--- MAIN END --->
<%Response.WriteFile("../_common/html/MenuBottom.htm");%>
    </div>
    </form>
</body>
</html>
