<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Emp_TablePop.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Emp_TablePop" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../../_common/js/common.js"></script>
</head>
<body style="margin:0,0,0,0;">
    <form id="form1" runat="server" style="margin-top:0px;margin-left:0px">
    <!--- MAIN START --->

<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr> 
                    <td valign="top" style="background-image:url(../../images/title/popup_t_bg.gif); height:40px;"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td  style="height:40px;" valign="top"><img alt="" src="../../images/title/popup_t79.gif" /></td>
                                <td align="right" valign="top"><img alt="" src="../../images/title/popup_img.gif" /></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                                <td style="width:50%; height:4px; background-color:#FFFFFF"></td> <%--FFC600,00549C--%>
                                <td style="width:50%; background-color:#FFFFFF"></td>
                            </tr>
                        </table>
                    </td>
                  </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td  style="height:100%;">
            
            
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
                      <tr>
                        <td>
                            <table cellspacing="0" border="0" width="100%"> 
                                <tr>
                                    <td class="cssPopBtnLine">
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                      </tr>
                      <tr>
                        <td style="height:100%;">
                            <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                <tr>
                                    <td style="width:62%;height:100%;">
                                        <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                            <tr>
                                                <td>
                                                    <table  cellpadding="0" cellspacing="1" border="0" style="height:100%; width:100%;">
                                                        <tr>
                                                            <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                            <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="프로젝트 목록"/></td>
                                                            <td align="right"><asp:Label ID="lblProjectTotal" runat="server" Font-Bold="true" Text=""/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height:100%;">
                                                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" 
                                                                     OnInitializeLayout="ugrdInPower_InitializeLayout"
                                                                     OnSelectedRowsChange ="ugrdInPower_SelectedRowsChange">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="BONBU_NAME" Key="BONBU_NAME" Width="90px" >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="본부">
                                                                            <RowLayoutColumnInfo OriginX="1" OriginY="0"  />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer Total="Sum">
                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="TEAM_NAME" Key="TEAM_NAME" Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="팀">
                                                                            <RowLayoutColumnInfo OriginX="2" OriginY="0"/>
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer Total="Sum">
                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="PROJECT_NAME" Key="PROJECT_NAME" Width="300px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="프로젝트">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer Caption="합계/평균">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="EMP_COUNT" Key="EMP_COUNT" Width="50px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="인원수">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer Caption="합계/평균">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    
                                                                    <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_B_NAME" Key="GRP_ONE_B_NAME" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_C_NAME" Key="GRP_ONE_C_NAME" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                </Columns>
                                                            </ig:UltraGridBand>
                                                        </Bands>
                                                        <DisplayLayout AllowColSizingDefault="Free" 
                                                                       AllowColumnMovingDefault="OnServer" 
                                                                       AllowDeleteDefault="Yes"
                                                                       AllowSortingDefault="Yes" 
                                                                       BorderCollapseDefault="Separate"
                                                                       HeaderClickActionDefault="SortMulti" 
                                                                       Name="UltraWebGrid1" 
                                                                       RowHeightDefault="20px"
                                                                       RowSelectorsDefault="No" 
                                                                       SelectTypeRowDefault="Extended" 
                                                                       Version="4.00" 
                                                                       CellClickActionDefault="RowSelect" 
                                                                       TableLayout="Fixed" 
                                                                       StationaryMargins="Header" 
                                                                       OptimizeCSSClassNamesOutput="False"
                                                                       AutoGenerateColumns="False">
                                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                            <Images>
                                                                <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                                <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                            </Images>
                                                        </DisplayLayout>
                                                    </ig:UltraWebGrid>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </td>
                                    <td style="width:1%;">
                                    </td>
                                    <td style="width:37%;">
                                        <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                            <tr>
                                                <td>
                                                    <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                                        <tr>
                                                            <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                            <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="인력현황"/></td>
                                                            <td align="right"><asp:Label ID="lblEmpTotal" runat="server" Font-Bold="true" Text=""/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height:100%;">
                                                    <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdInPower_InitializeLayout">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="이름">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0"/>
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Center">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer Caption="평균">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="RESULT_FULL" Key="RESULT_FULL" Width="80px" Format="#,##0.#0">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="가득율">
                                                                            <RowLayoutColumnInfo OriginX="1" OriginY="0"/>
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer Total="Avg">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="RESULT_DONG" Key="RESULT_DONG" Width="70px" Format="#,##0.#0">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="가동율">
                                                                            <RowLayoutColumnInfo OriginX="2" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer Total="Avg">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="RESULT_BDONG" Key="RESULT_BDONG" Width="70px" Format="#,##0.#0">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="비가동율">
                                                                            <RowLayoutColumnInfo OriginX="3" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer Total="Avg">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    
                                                                </Columns>
                                                            </ig:UltraGridBand>
                                                        </Bands>
                                                        <DisplayLayout AllowColSizingDefault="Free" 
                                                                       AllowColumnMovingDefault="OnServer" 
                                                                       AllowDeleteDefault="Yes"
                                                                       AllowSortingDefault="Yes" 
                                                                       BorderCollapseDefault="Separate"
                                                                       HeaderClickActionDefault="SortMulti" 
                                                                       Name="UltraWebGrid2" 
                                                                       RowHeightDefault="20px"
                                                                       RowSelectorsDefault="No" 
                                                                       SelectTypeRowDefault="Extended" 
                                                                       Version="4.00" 
                                                                       CellClickActionDefault="RowSelect" 
                                                                       TableLayout="Fixed" 
                                                                       StationaryMargins="Header" 
                                                                       OptimizeCSSClassNamesOutput="False"
                                                                       ReadOnly = "LevelTwo"
                                                                       ColFootersVisibleDefault="Yes"
                                                                       AutoGenerateColumns="False">
                                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                                            <Images>
                                                                <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                                <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                            </Images>
                                                        </DisplayLayout>
                                                    </ig:UltraWebGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                      </tr>
                      <tr>  
                        <td class="cssPopBtnLine">    
                            <asp:ImageButton ID="iBtnClose" ImageUrl="~/images/btn/b_003.gif" runat="server" OnClientClick="window.close();return false;" AlternateText="닫기" />
                            
                        </td>
                      </tr>
                    </table>
  
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                        <td style="width:50%; background-color:#FFFFFF"></td>
                    </tr>
                </table>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Literal ID="ltrScript" runat="server" Text="" ></asp:Literal>
            </td>
        </tr>
    </table>

<!--- MAIN END --->
    </form>
</body>
</html>