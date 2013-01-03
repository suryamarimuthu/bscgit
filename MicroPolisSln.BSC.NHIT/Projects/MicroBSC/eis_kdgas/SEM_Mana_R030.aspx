<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R030.aspx.cs" Inherits="eis_SEM_Mana_R030" %>

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
    <table border="0" cellspacing="1" cellpadding="2" width="800px" style="height:100%" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" style="height:1" align="left">
                <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF"  class="box_tt01">
                    <tr> 
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">년/월</font></strong></td>
                        <td class="box_td01">
                            <asp:DropDownList ID="cboYY" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cboMM" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                            </asp:DropDownList>
                        </td>
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">사업장</font></strong></td>
                        <td class="box_td01">
                             <asp:DropDownList ID="cboCom" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                             </asp:DropDownList>
                        </td>
                        <td width="15%" align="center" bgcolor="A6C5D1"><strong><font color="#FFFFFF">구 분</font></strong></td>
                        <td class="box_td01">
                             <asp:DropDownList ID="cboGbn" runat="server">
                             </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
	                <tr>
	                    <td style="padding-left:5px;">
	                        <table border="0" width="100%">
	                            <tr>
	                                <td align="center">
	                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><img alt="매출비중" src="../images/title_ic01.gif" align="left" /><font color="408BEF"><strong>소비자요금현황</strong></font></td>
                                            <td align="right"><font color="408BEF"><strong>단위 : 원, %</strong></font></td>
                                        </tr>
                                    </table>
	                                </td>
	                            </tr>
                            </table>
                            </td>
	                            </tr>
                            </table>
                        </td>
	                </tr>
	                <tr>
		                <td>
		                  <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
		                    <tr>
    	                       <td colspan="2">
                                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Height="350px" Width="800px" OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                                <Columns>
                                                    <ig:TemplatedColumn BaseColumnName="T_CODE" EditorControlID="" FooterText=""
                                                           Format="" HeaderText="대구분" Key="T_CODE" Width="30px" Hidden="True" MergeCells="True">
                                                        <Header Caption="대구분">
                                                          
                                                          <RowLayoutColumnInfo OriginX="1" OriginY="1" />
                                                        </Header>
                                                        <Footer Caption="">
                                                          <RowLayoutColumnInfo OriginX="1" OriginY="1" />
                                                        </Footer>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="T_NAME" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="대구분" Key="T_NAME" Width="90px" MergeCells="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="대구분">
                                                            
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <CellStyle Font-Bold="True" HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="M_CODE" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="소구분" Key="M_CODE" Width="80px" MergeCells="True" Hidden="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소구분">
                                                            
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <CellStyle Font-Bold="True" HorizontalAlign="Left"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:TemplatedColumn BaseColumnName="M_NAME" EditorControlID="" FooterText="" MergeCells="True"
                                                           Format="" HeaderText="소구분" Key="M_NAME" Width="90px">
                                                        <Header Caption="소구분">
                                                          
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y01_COST" EditorControlID="Y01_COST" FooterText="" Format="###,##0.#0"
                                                        HeaderText="원료가격" Key="Y01_COST" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="원료가격">
                                                            
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y01_EXPS" EditorControlID="Y01_EXPS" FooterText="" Format="###,##0.#0"
                                                        HeaderText="공급비용" Key="Y01_EXPS" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y01_PRIC" EditorControlID="Y01_PRIC" FooterText="" Format="###,##0.#0"
                                                        HeaderText="소비자가" Key="Y01_PRIC" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소비자가">
                                                            
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y02_COST" EditorControlID="Y02_COST" FooterText="" Format="###,##0.#0"
                                                        HeaderText="원료가격" Key="Y02_COST" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="원료가격">
                                                            
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y02_EXPS" EditorControlID="Y02_EXPS" FooterText="" Format="###,##0.#0"
                                                        HeaderText="공급비용" Key="Y02_EXPS" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y03_PRIC" EditorControlID="Y02_PRIC" FooterText="" Format="###,##0.#0"
                                                        HeaderText="소비자가" Key="Y02_PRIC" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소비자가">
                                                            
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y03_COST" EditorControlID="Y03_COST" FooterText="" Format="###,##0.#0"
                                                        HeaderText="원료가격" Key="Y03_COST" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="원료가격">
                                                            
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y03_EXPS" EditorControlID="Y03_EXPS" FooterText="" Format="###,##0.#0"
                                                        HeaderText="공급비용" Key="Y03_EXPS" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y03_PRIC" EditorControlID="Y02_PRIC" FooterText="" Format="###,##0.#0"
                                                        HeaderText="소비자가" Key="Y02_PRIC" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소비자가">
                                                            
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y04_COST" EditorControlID="Y04_COST" FooterText="" Format="###,##0.#0"
                                                        HeaderText="원료가격" Key="Y04_COST" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="원료가격">
                                                            
                                                            <RowLayoutColumnInfo OriginX="14" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="14" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y04_EXPS" EditorControlID="Y04_EXPS" FooterText="" Format="###,##0.#0"
                                                        HeaderText="공급비용" Key="Y04_EXPS" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="15" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="15" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y04_PRIC" EditorControlID="Y04_PRIC" FooterText="" Format="###,##0.#0"
                                                        HeaderText="소비자가" Key="Y04_PRIC" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소비자가">
                                                            
                                                            <RowLayoutColumnInfo OriginX="16" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="16" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y05_COST" EditorControlID="Y05_COST" FooterText="" Format="###,##0.#0"
                                                        HeaderText="원료가격" Key="Y01_COST" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="원료가격">
                                                            
                                                            <RowLayoutColumnInfo OriginX="17" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="17" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y05_EXPS" EditorControlID="Y05_EXPS" FooterText="" Format="###,##0.#0"
                                                        HeaderText="공급비용" Key="Y05_EXPS" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="18" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="18" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y05_PRIC" EditorControlID="Y05_PRIC" FooterText="" Format="###,##0.#0"
                                                        HeaderText="소비자가" Key="Y05_PRIC" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소비자가">
                                                            
                                                            <RowLayoutColumnInfo OriginX="19" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="19" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y06_COST" EditorControlID="Y06_COST" FooterText="" Format="###,##0.#0"
                                                        HeaderText="원료가격" Key="Y06_COST" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="원료가격">
                                                            
                                                            <RowLayoutColumnInfo OriginX="20" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="20" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y06_EXPS" EditorControlID="Y06_EXPS" FooterText="" Format="###,##0.#0"
                                                        HeaderText="공급비용" Key="Y06_EXPS" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="공급비용">
                                                            
                                                            <RowLayoutColumnInfo OriginX="21" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="21" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="Y06_PRIC" EditorControlID="Y06_PRIC" FooterText="" Format="###,##0.#0"
                                                        HeaderText="소비자가" Key="Y06_PRIC" NullText="0" Width="60px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="소비자가">
                                                            
                                                            <RowLayoutColumnInfo OriginX="22" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="22" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                </Columns>
                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                    <BorderDetails WidthBottom="2px" WidthLeft="2px" WidthRight="2px" WidthTop="2px" />
                                                </RowTemplateStyle>
                                            </ig:UltraGridBand>
                                        </Bands>
                                        <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                AllowSortingDefault="OnClient" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="22px"
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
                                                    Width="800px">
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
                                                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault BackColor="#E7E7E7"></RowAlternateStyleDefault>
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