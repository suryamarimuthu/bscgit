<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R056.aspx.cs" Inherits="eis_SEM_Mana_R056" %>

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
                            <asp:DropDownList ID="cboYY" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cboMM" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">구 분</font></strong></td>
                        <td class="box_td01">
                             <asp:DropDownList ID="cboGbn" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                             </asp:DropDownList>
                             <asp:DropDownList ID="cboPQ" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                             </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="800px" >
	                <tr>
		                <td align="center">
		                  <table cellpadding="0" cellspacing="0">
	                            <tr>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="가스보일러판매현황" src="../images/title_ic02.gif" align="left" /><font color="408BEF"><strong>가스보일러판매현황</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단 위 : 천원, 대</strong></font>&nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
		                    <tr>
    	                       <td colspan="2" style="height: 167px">
    		                            <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeLayout="UltraWebGrid1_InitializeLayout" OnInitializeRow="UltraWebGrid1_InitializeRow1" >
                                          <Bands>
                                            <ig:UltraGridBand>
                                                <Columns>
                                                    <ig:TemplatedColumn BaseColumnName="MM" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="월" Key="MM" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="월">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                   
                                                    <ig:TemplatedColumn BaseColumnName="COL1" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="계획" Key="COL1" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="계획">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="COL2" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="실적" Key="COL2" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="실적">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>                       
                                                    <ig:TemplatedColumn BaseColumnName="COL3" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="계획" Key="COL3" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="계획">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="COL4" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="실적" Key="COL4" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="실적">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="COL5" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="계획" Key="COL5" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="계획">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="COL6" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="실적" Key="COL6" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="실적">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:TemplatedColumn>
                                                    
                                                    <ig:UltraGridColumn BaseColumnName="COL7" EditorControlID="" FooterText="" Format="###,###,0"
                                                        HeaderText="계획" Key="COL7" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="계획">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="COL8" EditorControlID="" FooterText="" Format="###,###,0"
                                                        HeaderText="실적" Key="COL8" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="실적">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="COL9" EditorControlID="" FooterText="" Format="###,###,0"
                                                        HeaderText="증감" Key="COL9" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="증감">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="COL10" EditorControlID="" FooterText="" Format="###,###,0"
                                                        HeaderText="비율" Key="COL10" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="달성율(%)">
                                                            
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="3" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                                
                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid2" RowHeightDefault="20px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                <GroupByBox>
                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="450px"
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