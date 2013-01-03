<%@ Page Language="C#" AutoEventWireup="true" CodeFile="app1000.aspx.cs" Inherits="app_app1000" %>


    
    
<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html; " />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    </head>
    <body style="margin:0 0 0 0 ; background-color:#FFFFFF"onload="document.focus();">
        <form id="form1" runat="server">
            <!--- MAIN START --->	
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr> 
                                            <td height="40" valign="top"><img src="../images/title/popup_t17.gif" width="230" height="40"></td>
                                            <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr> 
                                            <td width="50%" height="4" bgcolor="FFFFFF"></td>
                                            <td width="50%" bgcolor="FFFFFF"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="cssPopContent">
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                            <tr>
	                            <td class="tableLeftSpace" align=right>
                                    <table cellpadding=0 cellspacing=0 border=0 class="tableBorder">
                                        <tr>
                                            <td class="cssTblTitle" width="18%" align="center">작성자</td>
                                            <td class="cssTblContent" width="120"><asp:Literal ID="Literal1" runat="server"></asp:Literal>&nbsp;</td>
                                            <td class="cssTblTitle" width="18%" align="center">결재자</td>
                                            <td class="cssTblContent" width="120"><asp:Literal ID="Literal2" runat="server"></asp:Literal>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="cssTblTitle" width="18%" align="center">작성일</td>
                                            <td class="cssTblContent">2006/02/19</td>
                                            <td class="cssTblTitle" width="18%" align="center">결재일</td>
                                            <td class="cssTblContent">2006/02/19</td>
                                        </tr>
                                    </table>	
	                            </td>
                            </tr>
                            <tr class="cssPopTblBottomSpace"><td>&nbsp;</td></tr>
                            <tr style="height:100%;">
	                            <td>
	                                <table cellpadding=0 cellspacing=0 border=0 width=100% height="100%">
	                                    <tr valign=top>
		                                    <td>
		                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server"  Width="100%" Height="100%" Browser="Xml" >
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
                                                                    HeaderText="KPI ID" IsBound="True" Key="KPI_REF_ID" Hidden="True">
                                                                    <Header Caption="KPI ID">
                                                                        <RowLayoutColumnInfo OriginX="1" />
                                                                    </Header>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="1" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText=""
                                                                    Format="" HeaderText="KPI 코드" IsBound="True" Key="KPI_CODE" Width="60px">
                                                                    <Header Caption="KPI 코드">
                                                                        <RowLayoutColumnInfo OriginX="2" />
                                                                    </Header>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="2" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:TemplatedColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText="" Format=""
                                                                    HeaderText="KPI 명" IsBound="True" Key="KPI_NAME" Width="400px">
                                                                    <Header Caption="KPI 명">
                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                    </Header>
                                                                    <ValueList DisplayStyle="NotSet">
                                                                    </ValueList>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                    </Footer>
                                                                </ig:TemplatedColumn>
                                                                <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_METHOD" HeaderText="실적 방식" Key="RESULT_INPUT_METHOD" Width="60px">
                                                                    <Header Caption="실적 방식">
                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" EditorControlID="" FooterText=""
                                                                    Format="" HeaderText="부서명" IsBound="True" Key="DEPT_NAME">
                                                                    <Header Caption="부서명">
                                                                        <RowLayoutColumnInfo OriginX="5" />
                                                                    </Header>
                                                                    <Footer Caption="">
                                                                        <RowLayoutColumnInfo OriginX="5" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="UNIT" HeaderText="단위" IsBound="True" Key="UNIT" Width="60px">
                                                                    <Header Caption="단위">
                                                                        <RowLayoutColumnInfo OriginX="6" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="6" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn HeaderText="계획" BaseColumnName="planVal" IsBound="True" Key="planVal" Width="60px">
                                                                    <Header Caption="계획">
                                                                        <RowLayoutColumnInfo OriginX="7" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="7" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn HeaderText="실적" BaseColumnName="actVal" IsBound="True" Key="actVal" Width="60px">
                                                                    <Header Caption="실적">
                                                                        <RowLayoutColumnInfo OriginX="8" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="8" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn HeaderText="차이" Width="60px" Hidden="true">
                                                                    <Header Caption="차이">
                                                                        <RowLayoutColumnInfo OriginX="9" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="9" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn HeaderText="신호" Key="chk_status" Width="60px">
                                                                    <Header Caption="신호">
                                                                        <RowLayoutColumnInfo OriginX="10" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="10" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn HeaderText="추세" Key="chk_arow" Width="60px">
                                                                    <Header Caption="추세">
                                                                        <RowLayoutColumnInfo OriginX="11" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="11" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" IsBound="True"
                                                                    Key="EMP_NAME">
                                                                    <Header Caption="챔피언">
                                                                        <RowLayoutColumnInfo OriginX="12" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="12" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="DAILY_PHONE" HeaderText="연락처" IsBound="True"
                                                                    Key="DAILY_PHONE">
                                                                    <Header Caption="연락처">
                                                                        <RowLayoutColumnInfo OriginX="13" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="13" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="EMP_EMAIL" HeaderText="E-Mail" IsBound="True"
                                                                    Key="EMP_EMAIL">
                                                                    <Header Caption="E-Mail">
                                                                        <RowLayoutColumnInfo OriginX="14" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="14" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="CHECK_STEP" HeaderText="측정단계" IsBound="True" Hidden="true"
                                                                    Key="CHECK_STEP" Width="60px">
                                                                    <Header Caption="측정단계">
                                                                        <RowLayoutColumnInfo OriginX="15" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="15" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                                <ig:UltraGridColumn BaseColumnName="GRAPTH_TYPE" HeaderText="그래프" IsBound="True" Hidden="true"
                                                                    Key="GRAPTH_TYPE" Width="60px">
                                                                    <Header Caption="그래프">
                                                                        <RowLayoutColumnInfo OriginX="16" />
                                                                    </Header>
                                                                    <Footer>
                                                                        <RowLayoutColumnInfo OriginX="16" />
                                                                    </Footer>
                                                                </ig:UltraGridColumn>
                                                            </Columns>
                                                            <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                            </RowTemplateStyle>
                                                        </ig:UltraGridBand>
                                                    </Bands>
                                                    <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                            AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                            HeaderClickActionDefault="SortMulti" Name="UltraWebGrid1" RowHeightDefault="20px"
                                                            RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" CellClickActionDefault="RowSelect" TableLayout="Fixed" StationaryMargins="Header">

                                                        <%--<GroupByBox>
                                                            <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                                                        </GroupByBox>
                                                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                            <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                        </GroupByRowStyleDefault>
                                                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthTop="1px" />
                                                        </FooterStyleDefault>
                                                        
                                                            
                                                        
                                                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                            <Padding Left="3px" />
                                                        </RowStyleDefault>
                                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="white">
                                                            <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                        </HeaderStyleDefault>
                                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                        </EditCellStyleDefault>
                                                        <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                            BorderWidth="2px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                            Width="99%">
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
                                                        </AddNewBox>--%>
                                                        <ClientSideEvents MouseOverHandler="MouseOverHandler" AfterSelectChangeHandler="AfterSelectChangeHandler" />
                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                    </DisplayLayout>
                                                </ig:UltraWebGrid>
		                                    </td>
	                                    </tr>
	                                </table>
	                            </td>
                            </tr>
                            <tr class="cssPopBtnLine">
	                            <td align="right"><br/>
		                            <a href="javascript:window.close();"><img src="../images/btn/b_022.gif" border=0/></a>
		                            <a href="javascript:window.close();"><img src="../images/btn/b_003.gif" border=0/></a>
	                            </td>
                            </tr>
                        </TABLE>
                    </td>
                </tr>
            </table>
            <!--- MAIN END --->
        </form>
    </body>
</html>
