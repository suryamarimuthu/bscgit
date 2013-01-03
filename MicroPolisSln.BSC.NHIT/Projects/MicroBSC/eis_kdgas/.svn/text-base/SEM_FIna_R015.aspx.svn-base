<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_FIna_R015.aspx.cs" Inherits="SEM_FIna_R015" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html xmlns="http://www.w3.org/1999/xhtml">
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
                <!--- TITLE --->
                <table width="800px" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF"  class="box_tt01">
                    <tr> 
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">년/월</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            ~
                            <asp:DropDownList ID="ddlTYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlTMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">사업장</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            </td>
                        <td class="box_td01" align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="800px" >
	                <tr>
	                    <td style="padding-left:5px;">
	                        <table border="0" width="100%">
	                            <tr>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="손익이익원단위상세 " src="../images/title_ic01.gif" align="left" /><font color="408BEF"><strong>손익이익원단위상세 </strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단위 : 백만㎥,백만원</strong></font></td>
                                            </tr>
                                    </table>
	                                </td>
	                            </tr>
                            </table>
                        </td>
	                </tr>
	                <tr>
		                <td align="center">
		                  <table cellpadding="0" cellspacing="0">
		                    <tr>
    	                       <td colspan="2" style="height: 450" valign=top>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="100%"
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                            <ig:UltraGridColumn BaseColumnName="T_2_NAME" Key="T_2_NAME" Width="130px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="구분">
                                                    
                                                    <RowLayoutColumnInfo OriginX="1" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ACTUAL_PRICE" Format="#,##0.##" Key="ACTUAL_PRICE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="금액">
                                                    
                                                    <RowLayoutColumnInfo OriginX="2" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ACTUAL_CONSIST" Format="#,##0.##" Key="ACTUAL_CONSIST" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="구성">
                                                    
                                                    <RowLayoutColumnInfo OriginX="3" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="ACTUAL_UNIT" Format="#,##0.##" Key="ACTUAL_UNIT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="원단위(원)">
                                                    
                                                    <RowLayoutColumnInfo OriginX="4" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="PLAN_PRICE" Format="#,##0.##" Key="ACTUAL_PRICE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="금액">
                                                    
                                                    <RowLayoutColumnInfo OriginX="5" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="PLAN_CONSIST" Format="#,##0.##" Key="ACTUAL_CONSIST" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="구성">
                                                    
                                                    <RowLayoutColumnInfo OriginX="6" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="PLAN_UNIT" Format="#,##0.##" Key="ACTUAL_UNIT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="원단위(원)">
                                                    
                                                    <RowLayoutColumnInfo OriginX="7" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="P_ACTUAL_PRICE" Format="#,##0.##" Key="ACTUAL_PRICE" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="금액">
                                                    
                                                    <RowLayoutColumnInfo OriginX="8" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="P_ACTUAL_CONSIST" Format="#,##0.##" Key="ACTUAL_CONSIST" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="구성">
                                                    
                                                    <RowLayoutColumnInfo OriginX="9" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="P_ACTUAL_UNIT" Format="#,##0.##" Key="ACTUAL_UNIT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="원단위(원)">
                                                    
                                                    <RowLayoutColumnInfo OriginX="10" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="P_RATE_COUNT" Format="#,##0.##" Key="P_RATE_COUNT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="증감">
                                                    
                                                    <RowLayoutColumnInfo OriginX="11" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="P_RATE_PERCENT" Format="#,##0.##" Key="P_RATE_PERCENT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="%">
                                                    
                                                    <RowLayoutColumnInfo OriginX="12" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="PLAN_RATE_COUNT" Format="#,##0.##" Key="PLAN_RATE_COUNT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="증감">
                                                    
                                                    <RowLayoutColumnInfo OriginX="13" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                            <ig:UltraGridColumn BaseColumnName="PLAN_RATE_PERCENT" Format="#,##0.##" Key="PLAN_RATE_PERCENT" Width="70px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <Header Caption="%">
                                                    
                                                    <RowLayoutColumnInfo OriginX="14" />
                                                </Header>
                                                <CellStyle HorizontalAlign="Right"></CellStyle>
                                            </ig:UltraGridColumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                AllowSortingDefault="No" BorderCollapseDefault="Separate"
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
                                        </ig:UltraWebGrid>
    	                       </td>
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