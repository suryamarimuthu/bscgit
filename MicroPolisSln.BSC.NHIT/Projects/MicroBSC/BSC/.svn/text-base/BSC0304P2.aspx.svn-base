<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0304P2.aspx.cs" Inherits="BSC_BSC0304P2" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>::BSC::</title>
    <link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
    <link rel="stylesheet" href="/_common/css/treeStyle.css" type="text/css" />
    <script type="text/javascript" src="/_common/js/common.js"></script>
    <script type="text/javascript" src="/_common/js/picker.js"></script>
    <script type="text/javascript" src="/_common/js/iezn_embed_patch.js" ></script>
    <script type="text/javascript" src="/_common/js/LayerShowHide.js"></script>
    <link type="text/css" rel="stylesheet" href="/_common/js/yahoo/container.css" />
    <link type="text/css" rel="Stylesheet" href="/_common/js/yahoo/styles.css" />
    <style type="text/css" media="screen">
       input
       {
            display:inline;
       }
    </style>
    <style type="text/css" media="print">
       input
       {
            display:none;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <div>
           <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
             <tr>
               <td>
                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="tableTitle" align="center" width="70">
                                KPI 코드
                            </td>
                            <td class="tableContent" width="40">
                                <asp:Label ID="lblKpiCode" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="tableTitle" align="center" width="70">
                                KPI 명
                            </td>
                            <td class="tableContent">
                                <asp:Label ID="lblKpiName" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="tableTitle" align="center" width="50" rowspan="2">
                                계획월
                            </td>
                            <td class="tableContent" width="180px" rowspan="2" valign="middle">
                                <asp:DropDownList ID="ddlMonthInfo" runat="server" CssClass="box01" Visible="false"></asp:DropDownList>
                                <asp:Label ID="lblMonthInfo" runat="server" Text=""></asp:Label>
                                <asp:ImageButton ID="iBtnSearch" runat="server" CssClass="ButtonOnScreen" ImageUrl="../images/btn/b_080.gif" Visible="false"  OnClientClick="window.print(); return false;" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="tableTitle" align="center" width="50" style="height: 19px" >단위</td>
                            <td class="tableContent" style="height: 19px" >&nbsp;<asp:Label ID="lblUnitName" runat="server" Text="Label"></asp:Label></td>
                            <td class="tableTitle" align="center" width="70" style="height: 19px">누적형태</td>
                            <td class="tableContent" colspan="1" style="height: 19px">&nbsp;<asp:Label ID="lblPNUType" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
               </td>
             </tr>
             <tr>
               <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="height:5px;" colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="width:385px">
                                <DCWC:Chart ID="chartMM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                    <ChartAreas>
                                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                        BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                        <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisX>
                                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="True"/>
                                        <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisY>
                                        <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisY2>
                                        </DCWC:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                        LegendStyle="Row" Name="Default" ShadowOffset="2">
                                        </DCWC:Legend>
                                    </Legends>
                                </DCWC:Chart>
                            </td>
                            <td align="left">
                                <DCWC:Chart ID="chartTM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas" Width="200px" Height="220px" >
                                    <ChartAreas>
                                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                        BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                        <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisX>
                                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="True"/>
                                        <AxisY linecolor="196, 196, 196" LabelsAutoFit="False"  Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisY>
                                        <AxisY2 linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisY2>
                                        </DCWC:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                        LegendStyle="Row" Name="Default" ShadowOffset="2">
                                        </DCWC:Legend>
                                    </Legends>
                                </DCWC:Chart>
                            </td>
                        </tr>
                    </table>
               </td>
             </tr>
             <tr>
               <td>
                    <ig:UltraWebGrid ID="ugrdKpiResultStatus" runat="server" Width="100%" OnInitializeLayout="ugrdKpiResultStatus_InitializeLayout" OnInitializeRow="ugrdKpiResultStatus_InitializeRow" >
                        <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="None" AllowDeleteDefault="No"
                        AllowSortingDefault="No" BorderCollapseDefault="Separate"
                        HeaderClickActionDefault="NotSet" Name="ugrdKpiResultStatus" RowHeightDefault="20px"
                        RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" CellClickActionDefault="NotSet" TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                            <GroupByBox>
                                <Style BackColor="ActiveBorder" BorderColor="Window"></Style>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="3px" />
                            </RowStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="772px">
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
                            <ClientSideEvents DblClickHandler="UltraWebGrid2_DblClickHandler" />
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                        </DisplayLayout>
                        <Bands>
                        <ig:UltraGridBand>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="MM" HeaderText="월" Key="MM" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="월">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET_MS" DataType="System.Decimal" Format="#,##0.00"
                                    HeaderText="계획" Key="TARGET_MS" Width="101px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="계획">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_MS" DataType="System.Decimal" Format="#,##0.00"
                                    HeaderText="실적" Key="RESULT_MS" Width="101px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IMAGE_FILE_NAME_MS" HeaderText="상태" Key="IMAGE_FILE_NAME_MS"
                                    Width="30px">
                                    <Header Caption="상태">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="THRESHOLD_KNAME_MS" HeaderText="상태" Hidden="True"
                                    Key="THRESHOLD_KNAME_MS">
                                    <Header Caption="상태">
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TREND_MS" HeaderText="추세" Key="TREND_MS" Width="30px">
                                    <Header Caption="추세">
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="5" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TREND_MS_NAME" HeaderText="추세" Hidden="True"
                                    Key="TREND_MS_NAME">
                                    <Header Caption="추세">
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="6" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="AC_RATE_MS" DataType="System.Decimal" Format="#,##0.00"
                                    HeaderText="달성율" Key="AC_RATE_MS" Width="50px">
                                    <Header Caption="달성율">
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="7" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINTS_MS" DataType="System.Decimal" Format="#,##0.00"
                                    HeaderText="점수" Key="POINTS_MS" Width="50px">
                                    <Header Caption="점수">
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="8" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn AllowGroupBy="No" Width="12px" Key="SPLITER" BaseColumnName="SPLITER" HeaderText="">
                                    <HeaderStyle BackColor="White">
                                        <BorderDetails ColorBottom="White" ColorTop="White" />
                                    </HeaderStyle>
                                    <Header Caption="">
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="9" />
                                    </Footer>
                                    <CellStyle BackColor="White">
                                        <BorderDetails ColorBottom="White" ColorTop="White" />
                                    </CellStyle>
                                    <FooterStyle BackColor="White">
                                        <BorderDetails ColorBottom="White" ColorTop="White" />
                                    </FooterStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TARGET_TS" DataType="System.Decimal" Format="###,###,##0.##"
                                    HeaderText="계획" Key="TARGET_TS" Width="101px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="계획">
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="10" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="RESULT_TS" DataType="System.Decimal" Format="###,###,##0.##"
                                    HeaderText="실적" Key="RESULT_TS" Width="101px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="실적">
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="11" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="IMAGE_FILE_NAME_TS" HeaderText="상태" Key="IMAGE_FILE_NAME_TS"
                                    Width="30px">
                                    <Header Caption="상태">
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="12" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="THRESHOLD_KNAME_TS" HeaderText="상태" Hidden="True"
                                    Key="THRESHOLD_KNAME_TS">
                                    <Header Caption="상태">
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="13" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TREND_TS" HeaderText="추세" Key="TREND_TS" Width="30px">
                                    <Header Caption="추세">
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="14" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TREND_TS_NAME" HeaderText="추세" Hidden="True"
                                    Key="TREND_TS_NAME">
                                    <Header Caption="추세">
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="15" />
                                    </Footer>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="AC_RATE_TS" DataType="System.Decimal" Format="#,##0.00"
                                    HeaderText="달성율" Key="AC_RATE_TS" Width="50px">
                                    <Header Caption="달성율">
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="16" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINTS_TS" DataType="System.Decimal" Format="#,##0.00"
                                    HeaderText="점수" Key="POINTS_TS" Width="50px">
                                    <Header Caption="점수">
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="17" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="CHECK_YN" HeaderText="측정여부" Hidden="true"
                                    Key="CHECK_YN" Width="30px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="측정여부">
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="18" />
                                    </Footer>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="30px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="YMD">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                        </Bands>
                    </ig:UltraWebGrid> 
               </td>
             </tr>
             
             
             
             
             <tr>
               <td style="padding-top: 3px; padding-bottom: 3px;">
                 <img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" /><b>&nbsp;원인분석</b>
               </td>
             </tr>
             <tr>
               <td>
                  <table border="0" width="100%" cellpadding="0" cellspacing="0" >
                    <tr>
                      <td>
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" style="background-color:#C2D2D6;height:100%; overflow:auto;">
                            <tr> 
                                <td align="center" style="background-color:#94bac9; width:80px; color:#ffffff; vertical-align: middle;">원인분석                           
                                    <asp:imagebutton ID="iBtnCauseFileID" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                    <asp:HiddenField ID="hdfCauseDocNo"   Value="" runat="server" />
                                </td>
                                <td align="center" style="background-color:#D1E2E9; width:40px;">당월</td>
                                <td style="width:300px; background-color:#ffffff" align="center">
                                    <asp:Label ID="txtReason_Month" runat="server" Height="100%" Width="100%"></asp:Label>
                                </td>
                                <td align="center" style="background-color:#D1E2E9; width:40px;">누적</td>
                                <td style="height:100%; background-color:#FFFFFF" align="center">
                                    <asp:Label ID="txtReason_Sum" runat="server" Height="100%" Width="300px"></asp:Label></td>
                            </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" style="background-color:#C2D2D6; height:100%; overflow:auto;">
                            <tr> 
                                <td style="background-color:#9FB0D5; width:80px; color:#ffffff; vertical-align: middle;" align="center">대책검토
                                    <asp:imagebutton ID="iBtnMeasureFileID" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                                    <asp:HiddenField ID="hdfMeasureDocNo" Value="" runat="server" />
                                </td>
                                <td align="center" style="width: 40px; background-color:#CED8EA">당월</td>
                                <td style="height:100%; width:300px; background-color:#ffffff"> 
                                    <asp:Label ID="txtPlan_Month" runat="server" Height="100%" Width="100%"></asp:Label>
                                </td>
                                <td style="width:40px; background-color:#CED8EA" align="center">누적</td>
                                <td style="height:100%; background-color:#FFFFFF" align="center">
                                    <asp:Label ID="txtPlan_Sum" runat="server" Height="100%" Width="300px"></asp:Label>
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
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                      <tr>
                        <td style="height:25px; width:385px;">
                            <img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" /><b>&nbsp;Initiative 추진계획</b>
                        </td>
                        <td style="height:25px;">
                            <img src="../images/icon/subtitle.gif" alt="" /><b>&nbsp;Initiative 추진내용</b>
                            <asp:imagebutton ID="iBtnInitiativeFile" ImageUrl="../images/icon/gr_po04.gif" runat="server"></asp:imagebutton>
                            <asp:HiddenField ID="hdfInitiativeDocNo"   Value="" runat="server" />
                        </td>
                      </tr>
                      <tr>
                        <td style="height:100%;  width:390px;">
                           <asp:Label ID="txtINITIATIVE_PLAN" runat="server" Height="100%" Width="390px" ></asp:Label>
                        </td>
                        <td style="height:100%;">
                           <asp:Label ID="txtINITIATIVE_DO" runat="server" Height="100%" Width="380px"></asp:Label>
                        </td>
                      </tr>
                    </table>
                    
                    <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdPrjList_InitializeRow" OnInitializeLayout="ugrdPrjList_InitializeLayout" >
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:TemplatedColumn Hidden="True" Key="selchk" Width="30px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdPrjList');" />
                                        </HeaderTemplate>
                                        <CellTemplate>
                                            <asp:CheckBox ID="cBox" runat="server" />
                                        </CellTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                        FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID"
                                        Width="40px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="PRJ_REF_ID">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="코드" Key="PRJ_CODE" Width="60px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="코드">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText=""
                                        Format="" HeaderText="사업명" Key="PRJ_NAME" Width="170px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Header Caption="사업명">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PROCEED_RATE" Format="##0.00" HeaderText="진행율(%)"
                                        Key="PROCEED_RATE" Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right">
                                        </CellStyle>
                                        <Header Caption="진행율(%)">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="OWNER_NAME" HeaderText="PM" Key="OWNER_NAME"
                                        Width="80px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle Wrap="True">
                                        </CellStyle>
                                        <Header Caption="PM">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="EFFECTIVENESS" HeaderText="기대효과" Key="EFFECTIVENESS"
                                        Width="250px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="기대효과">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PLAN_START_DATE" DataType="System.DateTime"
                                        EditorControlID="" FooterText="" Format="yyyy-MM-dd" HeaderText="시작일자" Key="PLAN_START_DATE"
                                        Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="시작일자">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PLAN_END_DATE" DataType="System.DateTime"
                                        EditorControlID="" FooterText="" Format="yyyy-MM-dd" HeaderText="종료일자" Key="PLAN_END_DATE"
                                        Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="종료일자">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="TOTAL_BUDGET" Format="###,##0.00" HeaderText="예상비용"
                                        Key="TOTAL_BUDGET" Hidden="true">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right">
                                        </CellStyle>
                                        <Header Caption="예상비용">
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="SUM_BUDGET" Format="###,##0.00" HeaderText="소요비용"
                                        Key="SUM_BUDGET" Hidden="true">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right">
                                        </CellStyle>
                                        <Header Caption="소요비용">
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="OWNER_DEPT_NAME" EditorControlID="" FooterText=""
                                        Format="" HeaderText="주관부서" Hidden="True" Key="OWNER_DEPT_NAME" Width="120px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Header Caption="주관부서">
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="사업정의" Hidden="True"
                                        Key="DEFINITION">
                                        <Header Caption="사업정의">
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="REF_STG" HeaderText="전략목표" Hidden="True" Key="REF_STG">
                                        <Header Caption="전략목표">
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="RANGE" HeaderText="사업범위" Hidden="True" Key="RANGE">
                                        <Header Caption="사업범위">
                                            <RowLayoutColumnInfo OriginX="14" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="14" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="INTERESTED_PARTIES" HeaderText="이해관계자" Hidden="True"
                                        Key="INTERESTED_PARTIES">
                                        <Header Caption="이해관계자">
                                            <RowLayoutColumnInfo OriginX="15" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="15" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="REQUEST_DEPT" HeaderText="요청부서기관" Hidden="True"
                                        Key="REQUEST_DEPT">
                                        <Header Caption="요청부서기관">
                                            <RowLayoutColumnInfo OriginX="16" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="16" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PRIORITY" HeaderText="중요도" Hidden="True" Key="PRIORITY">
                                        <Header Caption="중요도">
                                            <RowLayoutColumnInfo OriginX="17" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="17" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Hidden="True"
                                        Key="OWNER_EMP_NAME" Width="50px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="책임자">
                                            <RowLayoutColumnInfo OriginX="18" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="18" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PRJ_TYPE_NAME" HeaderText="사업유형" Hidden="True"
                                        Key="PRJ_TYPE_NAME" Width="90px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Header Caption="사업유형">
                                            <RowLayoutColumnInfo OriginX="19" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="19" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="PRJ_TYPE" HeaderText="사업유형" Hidden="True"
                                        Key="PRJ_TYPE">
                                        <Header Caption="사업유형">
                                            <RowLayoutColumnInfo OriginX="20" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="20" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="ACTUAL_START_DATE" DataType="System.DateTime"
                                        EditorControlID="" FooterText="" HeaderText="시작일자" Hidden="True" Key="ACTUAL_START_DATE"
                                        Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="시작일자">
                                            <RowLayoutColumnInfo OriginX="21" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="21" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="ACTUAL_END_DATE" DataType="System.DateTime"
                                        EditorControlID="" FooterText="" HeaderText="종료일자" Hidden="True" Key="ACTUAL_END_DATE"
                                        Width="70px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="종료일자">
                                            <RowLayoutColumnInfo OriginX="22" />
                                        </Header>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="22" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                </Columns>
                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                </RowTemplateStyle>
                            </ig:UltraGridBand>
                        </Bands>
                         <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                HeaderClickActionDefault="NotSet" Name="ugrdPrjList" RowHeightDefault="20px"
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
                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                    <Padding Left="3px" />
                                </RowStyleDefault>
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
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
                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                </SelectedRowStyleDefault>
                                <ClientSideEvents DblClickHandler="ugrdPrjList_DblClickHandler" />
                             <ActivationObject BorderColor="" BorderWidth="">
                             </ActivationObject>
                            </DisplayLayout>
                    </ig:UltraWebGrid>
               </td>
             </tr>
             
             <tr>
               <td>
                  <table style="border-width:0px; width:100%;">
                    <tr>
                      <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
                          <img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" /><b />&nbsp;익월실적예측
                      </td>
                    </tr>
                  </table>
                  <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color:#C2D2D6">
                    <tr>
                        <th align="center" style="background-color:#94bac9; width:80px; color:#ffffff; height:25px;">구 &nbsp;분</th>
                        <th align="center" style="background-color:#C2D2D6;">
                            (<asp:Label ID="lblNextYmd_Ms" runat="server"></asp:Label>)월 당월예측실적</th>
                        <th align="center" style="background-color:#C2D2D6;">
                            (<asp:Label ID="lblNextYmd_Ts" runat="server"></asp:Label>)월 누적예측실적</th>
                    </tr>
                    <tr> 
                        <th align="center" style="width:80px;background-color:#94bac9; color:#ffffff">예&nbsp;상&nbsp;실&nbsp;적<br /></th>
                        <td align="center" style="height:100%;">
                            <asp:Label ID="lblExtResult_MS" runat="server" Width="100%" Height="100%" BackColor="white"></asp:Label></td>
                        <td align="center" style="height:100%;">
                            <asp:Label ID="lblExtResult_TS" runat="server" Width="100%" Height="100%" BackColor="white"></asp:Label>
                        </td>
                    </tr>
                    <tr> 
                        <th align="center" style="width:80px;background-color:#94bac9; color:#ffffff">예&nbsp;상&nbsp;근&nbsp;거<br />
                            <br />
                            <asp:ImageButton runat="server" ID="iBtnExtData" ImageUrl="~/images/icon/gr_po05.gif" OnClientClick="mfUpload('hdfEXPECT_REASON_FILE_ID'); return false;" />
                        </th>
                        <td align="center" style="height:80px;">
                            <asp:Label ID="lblEXPECT_REASON_MS" runat="server" Width="100%" BackColor="white" Height="100%"></asp:Label></td>
                        <td align="center" style="height:80px;">
                            <asp:Label ID="lblEXPECT_REASON_TS" runat="server" Width="100%" BackColor="white" Height="100%"></asp:Label>
                        </td>
                    </tr>
                  </table>
               </td>
             </tr>
             <tr>
               <td>
                  <table style="border-width:0px; width:100%;">
                    <tr>
                      <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
                          <img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" /><b />&nbsp;예측차이분석
                      </td>
                    </tr>
                  </table>
                  <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color:#C2D2D6">
                    <tr>
                      <td colspan="2">
                        <asp:GridView ID="grvResultExpt" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCreated="grvResultExpt_RowCreated" OnRowDataBound="grvResultExpt_RowDataBound">
                          <Columns>
                              <asp:BoundField HeaderText="구분" DataField="GUBUN">
                                  <HeaderStyle Width="80px" />
                                  <ItemStyle BackColor="#94bac9" HorizontalAlign="center" ForeColor="white" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="계획" DataField="TARGET_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="실적" DataField="RESULT_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="달성율" DataField="AC_RATE_MS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="80px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="계획" DataField="TARGET_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="실적" DataField="RESULT_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                              <asp:BoundField HeaderText="달성율" DataField="AC_RATE_TS" DataFormatString="{0:#,##0.####}" HtmlEncode="False" >
                                  <HeaderStyle Width="80px" />
                                  <ItemStyle HorizontalAlign="Right" />
                              </asp:BoundField>
                          </Columns>
                          <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
                          <RowStyle ForeColor="Black" BackColor="White" HorizontalAlign="Left"></RowStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:GridView> 
                      </td>
                    </tr>
                    <tr>
                        <th align="center" style="background-color:#94bac9; width:12%; color:white">원&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;인<br /><br />
                            <asp:ImageButton runat="server" ID="iBtnCause" ImageUrl="~/images/icon/gr_po05.gif" OnClientClick="mfUpload('hdfRESULT_DIFF_FILE_ID'); return false;" />
                        </th>
                        <td align="center" style="height:100%;">
                            <asp:Label ID="lbltxtRESULT_DIFF_CAUSE" runat="server" Width="100%" BackColor="white" Height="100%"></asp:Label></td>
                    </tr>
                  </table>
               </td>
             </tr>
             <tr>
               <td style="height:300px;">
                  <table style="border-width:0px; width:100%;">
                    <tr>
                      <td style="height:25px; border-width:0px; vertical-align:bottom; text-align:left; font-weight:bold;">
                          <img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" /><b />&nbsp;<%=this.GetText("LBL_00004", "Communication")%>
                      </td>
                    </tr>
                  </table>
                     <ig:UltraWebGrid ID="ugrdCommunication" runat="server" Width="100%" Height="99%" OnInitializeRow="ugrdCommunication_InitializeRow" >
                        <Bands>
                            <ig:UltraGridBand>
                                <AddNewRow View="NotSet" Visible="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <ig:UltraGridColumn BaseColumnName="READ_YN" Key="READ_YN" Hidden="true" Width="20px">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Header>
                                        <CellStyle HorizontalAlign="center"></CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" HeaderText="No" Key="NUM_TEXT" Width="50px" FooterText="">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="글번호">
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Footer Caption="">
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="130px" HeaderText="제목">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="KPI 명">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="TITLE" Key="TITLE" Width="272px" HeaderText="제목">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="제목">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:TemplatedColumn BaseColumnName="ATTACH_NO" Key="ATTACH_NO" Width="40px" FooterText="" HeaderText="첨부" Hidden="true">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="첨부">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="OWNER_NAME" Key="OWNER_NAME" Width="70px" FooterText="" HeaderText="작성자">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="작성자">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px" FooterText="" HeaderText="조직">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="운영조직">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Left">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="READ_COUNT" Key="READ_COUNT" Width="50px" FooterText="" HeaderText="조회수" Hidden="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="조회수">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:TemplatedColumn BaseColumnName="CREATE_DATE" Key="CREATE_DATE" Width="70px" Format="yyyy-MM-dd" FooterText="" HeaderText="작성일자">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="작성일자">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <ValueList DisplayStyle="NotSet">
                                        </ValueList>
                                        <Footer Caption="">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </ig:TemplatedColumn>
                                    <ig:UltraGridColumn BaseColumnName="IDX" Key="IDX" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="BOARD_CATEGORY" Key="BOARD_CATEGORY" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="LIST_REF_ID" Key="LIST_REF_ID" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="COM_DEPT_REF_ID" Key="COM_DEPT_REF_ID" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="OWNER_EMP_ID" Key="OWNER_EMP_ID" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Footer>
                                    </ig:UltraGridColumn>
                                    <ig:UltraGridColumn BaseColumnName="TREE_LEVEL" Key="TREE_LEVEL" Hidden="True">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="13" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="13" />
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
                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                    <Padding Left="3px" />
                                </RowStyleDefault>
                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                </HeaderStyleDefault>
                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                </EditCellStyleDefault>
                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="99%"
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
                            <ClientSideEvents DblClickHandler="DblClickHandler" />
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                            </DisplayLayout>
                    </ig:UltraWebGrid>
               </td>
             </tr>
           </table>
      </div>
    </form>
</body>
</html>
