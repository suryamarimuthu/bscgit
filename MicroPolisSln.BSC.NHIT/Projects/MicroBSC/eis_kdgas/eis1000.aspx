<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eis1000.aspx.cs" Inherits="eis_eis1000" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html>
<head id="Head1" runat="server">
<title> ▒ KD JUMP - 성과관리 네트웍 </title>
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
<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
<tr valign=top>
    <td colspan="2" style="height: 30px">
    <table border="0" cellpadding="2" cellspacing="0" width="100%" class="tableBorder">
    <tr>
        <td class="tableTitle" width="100">도시가스 공급량</td>
        <td class="tableContent">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
        <td>
        </td>
        <td><select style="width:100px;">
        <option>사업장</option>
        <option>울산</option>
        <option>양산</option>
        </select>
        </td>
        <td align=right>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btn/b_033.gif" Height="19" />
        </td>
        </tr>
        </table>
        </td>
    </tr>
    </table>
    </td>
</tr>
<tr><td height=3></td></tr>
<tr valign=top>
<td width="50%">
    &nbsp;<DCWC:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" BackGradientEndColor="White"
        BackGradientType="DiagonalLeft" BorderLineColor="255, 128, 255" BorderLineStyle="Solid"
        DataSourceID="SqlDataSource1"  Palette="Dundas" Width="380px">
        <BorderSkin FrameBackColor="CornflowerBlue" FrameBackGradientEndColor="CornflowerBlue"
            PageColor="Control" />
        <Series>
            <DCWC:Series BorderColor="26, 59, 105" Name="Series1" ShadowOffset="2" ShowLabelAsValue="True"
                XValueType="Double" YValueType="Double">
            </DCWC:Series>
            <DCWC:Series BorderColor="26, 59, 105" Name="Series2" ShadowOffset="2" ShowLabelAsValue="True"
                XValueType="Double" YValueType="Double">
            </DCWC:Series>
            <DCWC:Series ChartType="Line" Name="Series3" XValueType="Double" YValueType="Double">
            </DCWC:Series>
            <DCWC:Series ChartType="Line" Name="Series4" XValueType="Double" YValueType="Double">
            </DCWC:Series>
        </Series>
        <UI>
            <Toolbar BorderColor="26, 59, 105">
                <BorderSkin PageColor="Transparent" SkinStyle="Emboss" />
            </Toolbar>
        </UI>
        <ChartAreas>
            <DCWC:ChartArea BackColor="White" BorderColor="26, 59, 105" BorderStyle="Solid" Name="Default"
                ShadowOffset="2">
                <AxisX>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisX>
                <Area3DStyle Enable3D="True" Light="Realistic" XAngle="10" YAngle="10" />
                <AxisY>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisY>
                <AxisX2>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisX2>
                <AxisY2>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisY2>
            </DCWC:ChartArea>
        </ChartAreas>
        <Titles>
            <DCWC:Title Name="Title1">
            </DCWC:Title>
        </Titles>
        <Legends>
            <DCWC:Legend BackColor="White" BorderColor="26, 59, 105" Enabled="False" Name="Default"
                ShadowOffset="2">
            </DCWC:Legend>
        </Legends>
    </DCWC:Chart>

</td>
<td width="50%">
    &nbsp;<DCWC:Chart ID="Chart2" runat="server" BackColor="WhiteSmoke" BackGradientEndColor="White"
        BackGradientType="DiagonalLeft" BorderLineColor="255, 128, 255" BorderLineStyle="Solid"
        Palette="Dundas" Width="380px">
        <BorderSkin FrameBackColor="CornflowerBlue" FrameBackGradientEndColor="CornflowerBlue"
            PageColor="Control" />
        <Series>
            <DCWC:Series BorderColor="26, 59, 105" Name="Series1" ShadowOffset="2" XValueType="Double"
                YValueType="Double">
            </DCWC:Series>
            <DCWC:Series BorderColor="26, 59, 105" Name="Series2" ShadowOffset="2" XValueType="Double"
                YValueType="Double">
            </DCWC:Series>
            <DCWC:Series BorderColor="26, 59, 105" Name="Series3" ShadowOffset="2" XValueType="Double"
                YValueType="Double">
            </DCWC:Series>
            <DCWC:Series BorderColor="26, 59, 105" Name="Series4" ShadowOffset="2" XValueType="Double"
                YValueType="Double">
            </DCWC:Series>
        </Series>
        <UI>
            <Toolbar BorderColor="26, 59, 105">
                <BorderSkin PageColor="Transparent" SkinStyle="Emboss" />
            </Toolbar>
        </UI>
        <ChartAreas>
            <DCWC:ChartArea BackColor="White" BorderColor="26, 59, 105" BorderStyle="Solid" Name="Default"
                ShadowOffset="2">
                <AxisX>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisX>
                <AxisY>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisY>
                <AxisX2>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisX2>
                <AxisY2>
                    <MinorGrid LineColor="Silver" />
                    <MajorGrid LineColor="Silver" />
                </AxisY2>
            </DCWC:ChartArea>
        </ChartAreas>
        <Titles>
            <DCWC:Title Name="Title1">
            </DCWC:Title>
        </Titles>
        <Legends>
            <DCWC:Legend BackColor="White" BorderColor="26, 59, 105" Enabled="False" Name="Default"
                ShadowOffset="2">
            </DCWC:Legend>
        </Legends>
    </DCWC:Chart>

</td>
</tr>
<tr><td height=3></td></tr>
<tr>
    <td height="50%" colspan=2>
    		<ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="750" Height="100%">
            <Bands>
                <ig:UltraGridBand>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <Columns>
                        <ig:TemplatedColumn EditorControlID="" FooterText="" Format="" HeaderText="선택"
                            Width="40px" Hidden="True">
                            <Header Caption="선택">
                            </Header>
                            <Footer Caption="">
                            </Footer>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" EditorControlID="" FooterText="" Format=""
                            HeaderText="전략ID" Key="KPI_REF_ID" DataType="System.Int32" Hidden="True">
                            <Header Caption="전략ID">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SAUPJANG" HeaderText="KPI 코드" Key="SAUPJANG" Width="60px" Hidden="true">
                            <Header Caption="KPI 코드">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:TemplatedColumn BaseColumnName="SAUPJANG" HeaderText="사업장" Key="SAUPJANG" Width="60px">
                            <Header Caption="사업장">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <ValueList DisplayStyle="NotSet">
                            </ValueList>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="SPLYY" HeaderText="년" Key="SPLYY" Width="60px">
                            <Header Caption="년">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SPLMM" HeaderText="월" Key="SPLMM" Width="40px">
                            <Header Caption="월">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SPLDD" HeaderText="일" Key="SPLDD" Width="40px">
                            <Header Caption="일">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <Footer Caption="">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SPLDDQTY" HeaderText="일별 공급계획 량" Key="SPLDDQTY" Width="90px">
                            <Header Caption="일별 공급계획 량">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SPLMMQTY" HeaderText="월별 공급계획 량" Key="SPLMMQTY" Width="90px">
                            <Header Caption="월별 공급계획 량">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SPLYYQTY" HeaderText="년별 공급계획 량 " Key="SPLYYQTY" Width="90px">
                            <Header Caption="년별 공급계획 량 ">
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SUMDDQTY" HeaderText="일별 공급 실적량 " Key="SUMDDQTY" Width="90px">
                            <Header Caption="일별 공급 실적량 ">
                                <RowLayoutColumnInfo OriginX="10" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="10" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SUMMMQTY" HeaderText="월별 공급 실적량 " Width="90px" Key="SUMMMQTY">
                            <Header Caption="월별 공급 실적량 ">
                                <RowLayoutColumnInfo OriginX="11" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="11" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="SUMYYQTY" HeaderText="년별 공급 실적량 " Width="90px" Key="SUMYYQTY">
                            <Header Caption="년별 공급 실적량 ">
                                <RowLayoutColumnInfo OriginX="12" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="12" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                    </RowTemplateStyle>
                </ig:UltraGridBand>
            </Bands>

            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                    AllowSortingDefault="OnClient" BorderCollapseDefault="Separate" AutoGenerateColumns="False" 
                    HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                    RowSelectorsDefault="No" SelectTypeRowDefault="Single" Version="4.00" ViewType="Hierarchical" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header">
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
                    <HeaderStyleDefault BackColor="#EEEEEE" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#C7C7C7">
                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
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
                <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="UltraWebGrid1_DblClickHandler" />
                </DisplayLayout>
        </ig:UltraWebGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bscConnectionString %>"
            SelectCommand="SELECT splyy as tmcode , sum(splddqty) as target , sum(sumddqty) as result FROM uz5plan WHERE saupjang=21 group by splyy" ProviderName="<%$ ConnectionStrings:bscConnectionString.ProviderName %>">
        </asp:SqlDataSource>
        
    </td>
</tr>
</table>
        
        
<!--- MAIN END --->
<%Response.WriteFile("../_common/html/MenuBottom.htm");%>
    </div>
    </form>
</body>
</html>
