<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R021.aspx.cs" Inherits="eis_SEM_Mana_R021" %>

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
                             <asp:DropDownList ID="cboGbn" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                             </asp:DropDownList>
                        </td>
                        <td colspan="2" align="right" class="box_td01">
                            <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
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
                                                <td><img alt="매출비중" src="../images/title_ic01.gif" align="left" /><font color="408BEF"><strong>매출액상세</strong></font></td>
                                                <td align="right"><font color="408BEF"><strong>단 위 : 백만, %</strong></font></td>
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
		        <td align="center">
		                <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" >
    		    	        <tr>
    		    		        <td>
                                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="420px" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                        <Bands>
                                            <ig:UltraGridBand>
                                                <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                                <Columns>
                                                    <ig:TemplatedColumn BaseColumnName="serNo" EditorControlID="" FooterText=""
                                                           Format="" HeaderText="년도" Key="serNo" Width="30px" Hidden="true">
                                                        <Header Caption="년도">
                                                          
                                                        </Header>
                                                        <Footer Caption=""></Footer>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="sYY" EditorControlID="" FooterText="" MergeCells="true"
                                                           Format="" HeaderText="년도" Key="sYY" Width="30px" Hidden="true">
                                                        <Header Caption="년도">
                                                          
                                                        </Header>
                                                        <Footer Caption=""></Footer>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </ig:TemplatedColumn>
                                                    <ig:TemplatedColumn BaseColumnName="sTYPE" EditorControlID="" FooterText=""  MergeCells="true"
                                                           Format="" HeaderText="구분" Hidden="false" Key="sTYPE" Width="65px">
                                                        <Header Caption="구분">
                                                          
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Header>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="1" />
                                                        </Footer>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </ig:TemplatedColumn>
                                                    <ig:UltraGridColumn BaseColumnName="SGBUN_CD" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="구분코드" Key="SGBUN_CD" Width="100px" Hidden="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="구분코드">
                                                            
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <CellStyle Font-Bold="True" HorizontalAlign="Center"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="SGBUN_NM" EditorControlID="" FooterText="" Format=""
                                                        HeaderText="구분명" Key="SGBUN_NM" Width="100px" Hidden="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="구분명">
                                                            
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Header>
                                                        <CellStyle Font-Bold="True" HorizontalAlign="Left"></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="2" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_01" EditorControlID="AMT_01" FooterText="" Format="#,##0"
                                                        HeaderText="1월" Key="AMT_01" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="1월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="3" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_02" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="2월" Key="AMT_02" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="2월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="4" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_03" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="3월" Key="AMT_03" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="3월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="5" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_04" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="4월" Key="AMT_04" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="4월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="6" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_05" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="5월" Key="AMT_05" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="5월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="7" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_06" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="6월" Key="AMT_06" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="6월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="8" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_07" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="7월" Key="AMT_07" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="7월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_08" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="8월" Key="AMT_08" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="8월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="10" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_09" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="9월" Key="AMT_09" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="9월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="11" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_10" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="10월" Key="AMT_10" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="10월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="12" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_11" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="11월" Key="AMT_11" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="11월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="13" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>
                                                    <ig:UltraGridColumn BaseColumnName="AMT_12" EditorControlID="" FooterText="" Format="#,##0"
                                                        HeaderText="12월" Key="AMT_12" NullText="0" Width="55px">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Header Caption="12월">
                                                            
                                                            <RowLayoutColumnInfo OriginX="14" />
                                                        </Header>
                                                        <CellStyle HorizontalAlign="Right"><Padding Right="2px" /></CellStyle>
                                                        <Footer Caption="">
                                                            <RowLayoutColumnInfo OriginX="14" />
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
                                                HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="18px"
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