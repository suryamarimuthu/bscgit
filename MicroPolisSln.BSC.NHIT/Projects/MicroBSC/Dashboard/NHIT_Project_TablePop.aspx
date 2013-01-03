<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Project_TablePop.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Project_TablePop" %>
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
            
            
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:100%;">
                      <tr>
                        <td>
                            <table cellspacing="0" border="0" width="100%"> 
                                <tr>
                                    <td class="cssPopBtnLine">
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box01" style="cursor:pointer;" Visible="false"></asp:DropDownList>
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
                                    <td style="width:100%;height:100%;">
                                        <table cellspacing="0" border="0" width="100%" style="height:100%;"> 
                                            <tr>
                                                <td>
                                                    <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                                        <tr>
                                                            <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                                            <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="프로젝트 세부현황"/></td>
                                                            <td align="right"><asp:Label ID="lblProjectTotal" runat="server" Font-Bold="true" Text=""/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height:100%;">
                                                    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow">
                                                        <Bands>
                                                            <ig:UltraGridBand>
                                                                <Columns>
                                                                    <ig:UltraGridColumn BaseColumnName="" Key="NO" Width="30px" >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="No.">
                                                                            <RowLayoutColumnInfo OriginX="1" OriginY="0"  />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="PROJECT_NAME" Key="PROJECT_NAME" Width="170px" >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="프로젝트">
                                                                            <RowLayoutColumnInfo OriginX="1" OriginY="0"  />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer >
                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_C_NAME" Key="GRP_ONE_C_NAME" Width="70px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="사업유형">
                                                                            <RowLayoutColumnInfo OriginX="2" OriginY="0"/>
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer >
                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_B_NAME" Key="GRP_ONE_B_NAME" Width="70px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="고객사">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer >
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_D_NAME" Key="GRP_ONE_D_NAME" Width="85px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="본부">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer >
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="TEAM_NAME" Key="TEAM_NAME" Width="80px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="팀">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer >
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="PLAN_STR" Key="PLAN_STR" Width="78px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="계획시작일">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Center">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer >
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="PLAN_END" Key="PLAN_END" Width="78px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="계획종료일">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Center">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Center" />
                                                                        <Footer >
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="MECHUL" Key="MECHUL" Width="100px" Format="#,##0.##">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="매출액">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer   Total="Sum">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="MECHUL_TOT" Key="MECHUL_TOT" Width="100px" Format="#,##0.##">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="매출총이익">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer   Total="Sum">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="YOUNGUP" Key="YOUNGUP" Width="100px" Format="#,##0.##">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <Header Caption="영업이익">
                                                                            <RowLayoutColumnInfo OriginX="0" OriginY="0" />
                                                                        </Header>
                                                                        <CellStyle HorizontalAlign="Right">
                                                                        </CellStyle>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <Footer  Total="Sum">
                                                                        </Footer>
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="CR_YEAR" Key="CR_YEAR" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_C_CODE" Key="GRP_ONE_C_CODE" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_B_CODE" Key="GRP_ONE_B_CODE" Hidden="true">
                                                                    </ig:UltraGridColumn>
                                                                    <ig:UltraGridColumn BaseColumnName="GRP_ONE_D_CODE" Key="GRP_ONE_D_CODE" Hidden="true">
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
                                                                       ColFootersVisibleDefault ="Yes"
                                                                       OptimizeCSSClassNamesOutput="False"
                                                                       ReadOnly="LevelTwo"
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