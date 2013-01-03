<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Main_TablePop.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Main_TablePop" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../../_common/js/common.js"></script>
<script id="Script1" type="text/javascript">
    function doPoppingUp(cr_year, cr_month) {
        var url = 'NHIT_Emp_TablePop.aspx?CR_YEAR=' + cr_year + '&CR_MONTH=' + cr_month;

        gfOpenWindow(url, 950, 600, 'yes', 'no', 'DASHBOARD_EMP');

        return false;
    }

    function doPoppingUpProject(cr_year, grp_one_b_code, grp_one_c_code, grp_one_d_code) {
        var url = 'NHIT_Project_TablePop.aspx?CR_YEAR='        + cr_year
                                          + '&GRP_ONE_B_CODE=' + grp_one_b_code
                                          + '&GRP_ONE_C_CODE=' + grp_one_c_code
                                          + '&GRP_ONE_D_CODE=' + grp_one_d_code;
                                         

        gfOpenWindow(url, 1025, 600, 'yes', 'no', 'DASHBOARD_PROJECT');

        return false;
    }

</script>
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
                                <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
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
            
            
  <table cellpadding="0" cellspacing="0" border="0" width="100%;" style="height:100%;">
    <tr>
      <td align="left" style="vertical-align:top;">
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
                        <td style="width:36%;height:100%;">
                            <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="전사 매출/손익"/></td>
                                                <td align="right"><asp:Label ID="Label3" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:27%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdInPower_InitializeLayout">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_THREE_NAME" Key="GRP_THREE_NAME" Width="75px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                                <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center"/>
                                                            <Footer Caption="합계/평균">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TARGET_YEAR" Key="TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="0"  SpanY="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="2" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="3" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DAL_RATE_100" Key="DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="4" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
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
                                                           Name="UltraWebGrid1" 
                                                           RowHeightDefault="20px"
                                                           RowSelectorsDefault="No" 
                                                           SelectTypeRowDefault="Extended" 
                                                           Version="4.00" 
                                                           CellClickActionDefault="RowSelect" 
                                                           TableLayout="Fixed" 
                                                           StationaryMargins="Header" 
                                                           OptimizeCSSClassNamesOutput="False"
                                                           ReadOnly = "LevelTwo"
                                                           ColFootersVisibleDefault="No"
                                                           AutoGenerateColumns="False">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  Cursor="Hand" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:5px;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="인력정산"/></td>
                                                <td align="right"><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="(단위:%)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:73%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" Height="100%" 
                                                         OnInitializeLayout="ugrdInPower_InitializeLayout"
                                                         OnInitializeRow = "ugrdInPower_InitializeRow">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="CR_MONTH_NAME" Key="CR_MONTH_NAME" Width="50px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                                <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="평균">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="TARGET_FULL_RATE" Key="TARGET_FULL_RATE" Width="80px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표 가득율">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="0" SpanY="2"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_FULL_RATE" Key="RESULT_FULL_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="가득율">
                                                                <RowLayoutColumnInfo OriginX="2" OriginY="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_DONG_RATE" Key="RESULT_DONG_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="가동율">
                                                                <RowLayoutColumnInfo OriginX="3" OriginY="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="RESULT_BDONG_RATE" Key="RESULT_BDONG_RATE" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="비가동">
                                                                <RowLayoutColumnInfo OriginX="4" OriginY="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Hidden="true">
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
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  Cursor="Hand" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
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
                        <td style="width:63%;">
                            <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label4" runat="server" Font-Bold="true" Text="고객별 매출현황"/></td>
                                                <td align="right"><asp:Label ID="Label5" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:29%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid3" runat="server" Width="100%" Height="100%" 
                                                         OnInitializeLayout="ugrdETC_InitializeLayout"
                                                         OnInitializeRow="ugrdETC_InitializeRow">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="65px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                                <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계/평균">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_YEAR" Key="ME_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_TS" Key="ME_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_RESULT_TS" Key="ME_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_DAL_RATE_100" Key="ME_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>                                                       
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_TS" Key="YG_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_RESULT_TS" Key="YG_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_DAL_RATE_100" Key="YG_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_TARGET_TS" Key="DN_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_RESULT_TS" Key="DN_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_DAL_RATE_100" Key="DN_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_CODE" Key="GRP_TWO_CODE" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Hidden="true">
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
                                                           Name="UltraWebGrid3" 
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
                                                           AutoGenerateColumns="False"
                                                           ScrollBar="Auto">
                                                <RowStyleDefault  CssClass="GridRowStyle" />
                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  Cursor="Hand" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:5px;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label6" runat="server" Font-Bold="true" Text="사업유형별 매출현황"/></td>
                                                <td align="right"><asp:Label ID="Label7" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:29%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid4" runat="server" Width="100%" Height="100%" 
                                                         OnInitializeLayout="ugrdETC_InitializeLayout"
                                                         OnInitializeRow="ugrdETC_InitializeRow">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="65px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                                <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계/평균">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_YEAR" Key="ME_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_TS" Key="ME_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_RESULT_TS" Key="ME_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_DAL_RATE_100" Key="ME_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>                                                       
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_TS" Key="YG_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_RESULT_TS" Key="YG_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_DAL_RATE_100" Key="YG_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_TARGET_TS" Key="DN_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_RESULT_TS" Key="DN_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_DAL_RATE_100" Key="DN_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_CODE" Key="GRP_TWO_CODE" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Hidden="true">
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
                                                           Name="UltraWebGrid4" 
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
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  Cursor="Hand"  ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
                                                <Images>
                                                    <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                    <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                                </Images>
                                            </DisplayLayout>
                                        </ig:UltraWebGrid>
                                    </td>
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="Label8" runat="server" Font-Bold="true" Text="본부별 매출현황"/></td>
                                                <td align="right"><asp:Label ID="Label9" runat="server" Font-Bold="true" Text="(단위:백만원)"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:42%;">
                                        <ig:UltraWebGrid ID="UltraWebGrid5" runat="server" Width="100%" Height="100%" 
                                                         OnInitializeLayout="ugrdETC_InitializeLayout" 
                                                         OnInitializeRow="ugrdETC_InitializeRow">
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <Columns>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_NAME" Key="GRP_TWO_NAME" Width="65px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="구분">
                                                                <RowLayoutColumnInfo OriginX="0" OriginY="0" SpanY="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Footer Caption="합계/평균">
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_YEAR" Key="ME_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1"  OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1"/>
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_TARGET_TS" Key="ME_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_RESULT_TS" Key="ME_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="ME_DAL_RATE_100" Key="ME_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>                                                       
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_YEAR" Key="YG_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_TARGET_TS" Key="YG_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_RESULT_TS" Key="YG_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="YG_DAL_RATE_100" Key="YG_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_TARGET_YEAR" Key="DN_TARGET_YEAR" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="년간목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_TARGET_TS" Key="DN_TARGET_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="목표">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_RESULT_TS" Key="DN_RESULT_TS" Width="70px" Format="#,##0.##">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="실적">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Sum">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="DN_DAL_RATE_100" Key="DN_DAL_RATE_100" Width="70px" Format="#,##0.#0">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="달성율(%)">
                                                                <RowLayoutColumnInfo OriginX="1" OriginY="1"/>
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <Footer Total="Avg">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="GRP_TWO_CODE" Key="GRP_TWO_CODE" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Hidden="true">
                                                        </ig:UltraGridColumn>
                                                        <ig:UltraGridColumn BaseColumnName="CR_MONTH" Key="CR_MONTH" Hidden="true">
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
                                                           Name="UltraWebGrid5" 
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
                                                <HeaderStyleDefault CssClass="GridHeaderStyle"  Cursor="Hand" ></HeaderStyleDefault>                                   
                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
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