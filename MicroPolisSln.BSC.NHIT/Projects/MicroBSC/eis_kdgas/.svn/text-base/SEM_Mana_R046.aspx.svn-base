<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R046.aspx.cs" Inherits="eis_SEM_Mana_R046" %>

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
        <td align="center" bgcolor="A6C5D1" width="15%"><strong><font color="#FFFFFF">구분</font></strong></td>
            <td class="box_td01">
                <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                </asp:DropDownList>
            </td>
            <td align="right" class="box_td01" width="15%">
                <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" OnClick="iBtnSearch_Click" />&nbsp;
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
                                Width="100%" OnInitializeRow = "UltraWebGrid1_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet">
                                        </AddNewRow>
                                        <Columns>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_NAME" Format=""  Key="CENTER_NAME" Width="50px">
	                                        <Header Caption="성명">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_POSITION" Format=""  Key="CENTER_POSITION" Width="40px">
	                                        <Header Caption="직급">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_JOB" Format=""  Key="CENTER_JOB" Width="90px">
	                                        <Header Caption="담당업무">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_ENTER_DATE" Format=""  Key="CENTER_ENTER_DATE" Width="60px">
	                                        <Header Caption="입사일">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_HPNO" Format=""  Key="CENTER_HPNO" Width="80px">
	                                        <Header Caption="핸드폰번호">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_HMNO" Format=""  Key="CENTER_HMNO" Width="80px">
	                                        <Header Caption="집전화 번호">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_LICENSE1" Format=""  Key="CENTER_LICENSE1" Width="60px">
	                                        <Header Caption="자격증1">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_LICENSE2" Format=""  Key="CENTER_LICENSE2" Width="60px">
	                                        <Header Caption="자격증2">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_LICENSE3" Format=""  Key="CENTER_LICENSE3" Width="60px">
	                                        <Header Caption="자격증3">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_SCHOOL" Format=""  Key="CENTER_SCHOOL" Width="60px">
	                                        <Header Caption="최종학력">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_STUDY" Format=""  Key="CENTER_STUDY" Width="60px">
	                                        <Header Caption="전공">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
	                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_ADDR" Format=""  Key="CENTER_ADDR" Width="200px">
	                                        <Header Caption="주소">
		                                        <RowLayoutColumnInfo OriginX="2" />
	                                        </Header>
	                                        <HeaderStyle HorizontalAlign="Center" />
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="CENTER_EMAIL" Format=""  Key="CENTER_EMAIL" Width="100px">
	                                        <Header Caption="Email">
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
                                    <RowAlternateStyleDefault BackColor="#E7E7E7">
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
