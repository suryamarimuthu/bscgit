﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Fina_R025.aspx.cs" Inherits="eis_SEM_Fina_R025" %>

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
        <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">년/월</font></strong></td>
            <td class="box_td01">
                <asp:DropDownList ID="cboYY" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
                <asp:DropDownList ID="cboMM" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
            </td>
        <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">은행</font></strong></td>
            <td class="box_td01">
                <asp:DropDownList ID="cboBank" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
            </td>
            <td align="right" class="box_td01" width="15%">
                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr>
          <td height="5"></td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="800px" height="95%" >
    	<tr>
    		<td>
    		    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="95%" >
    		    	<tr>
    		    		<td width=50% valign="top" align=center>
                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="135px"
                                Width="100%" oninitializelayout="UltraWebGrid1_InitializeLayout" OnInitializeRow = "UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                        <ig:UltraGridColumn BaseColumnName="은행명" Format=""  Key="은행명" Width="100px">
	                                        <Header Caption="은행명">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="차입유형" Format=""  Key="차입유형" Width="140px">
	                                        <Header Caption="차입유형">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="차입일자" Format=""  Key="차입일자" Width="80px">
	                                        <Header Caption="차입일자">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="만기일자" Format=""  Key="만기일자" Width="80px">
	                                        <Header Caption="만기일자">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="차입금액"  Key="차입금액" Width="100px" Format="#,##0">
	                                        <Header Caption="차입금액">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Right"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="차입잔액"   Key="차입잔액" Width="100px" Format="#,##0">
	                                        <Header Caption="차입잔액">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Right"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="납입일" Format=""  Key="납입일" Width="60px">
	                                        <Header Caption="납입일">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="이율" Format=""  Key="이율" Width="60px">
	                                        <Header Caption="이율">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="이율구분" Format=""  Key="이율구분" Width="60px">
	                                        <Header Caption="이율구분">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                    <GroupByBox>
                        <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                    </GroupByBox>
                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                    </GroupByRowStyleDefault>
                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorTop="White" WidthTop="1px" />
                    </FooterStyleDefault>
                    <RowAlternateStyleDefault BackColor="#F9F9F7">
                        <BorderDetails  ColorLeft="249, 249, 247" ColorTop="249, 249, 247" />
                    </RowAlternateStyleDefault>
                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                        <Padding Left="3px" />
                    </RowStyleDefault>
                    <HeaderStyleDefault BackColor="#55A2B0" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7"
                         ForeColor="white">
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
                                    <RowAlternateStyleDefault BackColor="#FFFFFF">
                                    </RowAlternateStyleDefault>
                                </DisplayLayout>
                            </ig:UltraWebGrid>&nbsp;</td>
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
