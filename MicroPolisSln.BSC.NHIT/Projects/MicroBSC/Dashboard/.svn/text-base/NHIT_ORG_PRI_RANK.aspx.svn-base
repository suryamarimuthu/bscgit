<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_ORG_PRI_RANK.aspx.cs" Inherits="NHIT_ORG_PRI_RANK" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<link href="../_common/css/Intro.css" rel="stylesheet" type="text/css" />
<style>
body{margin:0;padding:0;font-family:"dotum";font-size:12px;color:#747474;}
div,p,ul,li{margin:0;padding:0;font-family:"dotum";font-size:12px;color:#747474;}
img{border:none;}
a{text-decoration:none;outline:none;}
li{list-style:none}
input{border:1px solid #DFDFDF;font-family:dotum;font-size:12px;color:#666666;}
select{border:1px solid #DFDFDF;font-family:dotum;font-size:12px;color:#666666;}
.txt_D{position:relative;top:60px;left:90px;font-size:14px;font-weight:bold;color:#8dbfd6}
.txt_C{position:relative;top:63px;left:90px;font-family:'verdana';font-size:90px;font-weight:bold;}
.txt_01{width:100px;font-family:"gulim";font-size:16px;font-weight:bold;}
.txt_02{width:132px;font-family:"verdana";font-size:26px;font-weight:bold;text-align:right;padding-right:8px;}
.txt_03{width:270px;background:url('../images/Intro/back_gr_D.gif') no-repeat;padding:0px 6px 0px 3px;}
.txt_R{text-align:right;height:14px;font-weight:bold;color:#000;background:url(../images/Intro/back_gr_R.gif);}
.txt_B{text-align:right;height:14px;font-weight:bold;color:#000;background:url(../images/Intro/back_gr_B.gif);}
.G_title{font-size:12px;font-weight:bold;color:#000;}
</style>

<script language="javascript" type="text/javascript" >

    

</script>

<table width="100%" cellpadding="3px" cellspacing="0px" border="1px" style="min-width:1195px;border-collapse:collapse;border:1px solid #9eb0d8; vertical-align: top;">
 <tr>
    <td style="width:150px;background:#d5ebf8;color:#75a0e4;font-weight:bold;font-size:11px;">평가기간</td>
    <td class="cssTblContentSingle">
        <asp:DropDownList ID="ddlEstTermInfo" class="box01" runat="server" 
            AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlMonthInfo" class="box01" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonthInfo_SelectedIndexChanged" ></asp:DropDownList>
    </td>

 </tr>
</table>


<!-- 높이조절 -->
<table width="100%" cellpadding="0px" cellspacing="0px" border="0px">
	<tr>
		<td style="height:10px"></td>
	</tr>
</table>
<!-- 높이조절 끝 -->

<!-- 조직별  -->
<table width="1103px" cellpadding="0px" cellspacing="0px" border="0px">
	<tr>
		<td valign="top" nowrap>
			<div style="width:330px">
				<div class="G_title">
					<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                        <tr>
                            <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                            <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="조직별 등급분포"/></td>
                        </tr>
                    </table>
				</div>
				<div>
                    <asp:Chart ID="chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" 
                                Width="100" Height="100" >
                        <ChartAreas>
                            <asp:ChartArea Name="Default" BorderColor="196, 196, 196"
                                BackColor="White" ShadowColor="Transparent">
                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX>
                                <Area3DStyle WallWidth="3" Enable3D="true"/>
                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisY>
                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisY2>
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
				</div>		
			</div>
		</td>
		<td style="width:24px;">
			<img src="../images/Intro/space.gif" width="24px">
		</td>
		<td valign="top" >
			<div class="G_title">
				<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label16" runat="server" Font-Bold="true" Text="팀별 순위"/></td>
                    </tr>
                </table>
			</div>
			<div style="width:385px; height:290px;">                            
			    <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" 
			        OnInitializeRow="UltraWebGrid1_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="RANK_ID" Key="RANK_ID" Width="38px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="순위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="134px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="팀">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_DEPT_NAME" Key="UP_DEPT_NAME" Width="134px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="본부">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SCORE_TS" Key="SCORE_TS" Width="60px" Format="#,##0.#0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="점수">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    AutoGenerateColumns="False"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="UltraWebGrid1" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Single" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="HeaderAndFooter" 
                                    OptimizeCSSClassNamesOutput="False"
                                    ReadOnly="LevelTwo"
                                    ViewType="Flat">
                                           
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
 
                    </DisplayLayout>
                
                </ig:UltraWebGrid>

			</div>
		</td>
		<td style="width:32px;">
			<img src="../images/Intro/space.gif" width="32px">
		</td>
		<td valign="top">
			<div class="G_title">
				<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="BEST 5"/></td>
                    </tr>
                </table>
			</div>
			<div style="width:240px; height:125px;">
                <ig:UltraWebGrid ID="UltraWebGrid2" runat="server" Width="100%" Height="100%" 
                     OnInitializeRow="UltraWebGrid2_InitializeRow" >
                    <Bands>
                        <ig:UltraGridBand>
                           <Columns>
                                <ig:UltraGridColumn BaseColumnName="RANK_ID" Key="RANK_ID" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="순위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="134px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="팀">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SCORE_TS" Key="SCORE_TS" Width="60px" Format="#,##0.#0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="점수">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    

                   
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    AutoGenerateColumns="False"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="UltraWebGrid2" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Single" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="HeaderAndFooter" 
                                    OptimizeCSSClassNamesOutput="False"
                                    ReadOnly="LevelTwo"
                                    ViewType="Flat">
                                           
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
 
                    </DisplayLayout>
                </ig:UltraWebGrid>
			</div>
			<p style="height:14px"></p>
			<div class="G_title">
				<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label3" runat="server" Font-Bold="true" Text="WORST 5"/></td>
                    </tr>
                </table>

			</div>
			<div style="width:240px; height:125px;">
               <ig:UltraWebGrid ID="UltraWebGrid3" runat="server" Width="100%" Height="100%" 
                    OnInitializeRow="UltraWebGrid3_InitializeRow" 
                    OnInitializeLayout="UltraWebGrid3_InitializeLayout" >
                   <Bands>
                        <ig:UltraGridBand>
                           <Columns>
                                <ig:UltraGridColumn BaseColumnName="RANK_ID" Key="RANK_ID" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="순위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="134px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="팀">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="SCORE_TS" Key="SCORE_TS" Width="60px" Format="#,##0.#0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="점수">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>

                    
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    AutoGenerateColumns="False"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="UltraWebGrid3" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Single" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="HeaderAndFooter" 
                                    OptimizeCSSClassNamesOutput="False"
                                    ReadOnly="LevelTwo"
                                    ViewType="Flat">
                                           
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
 
                    </DisplayLayout>
                </ig:UltraWebGrid>
			</div>
		</td>
	</tr>
</table>
<!-- 조직별 끝 -->
<hr size="1px" color="#e3e3e3" style="border:0px solid #e3e3e3;margin:15px 0px;">
<!-- 개인별 -->
<table width="1103px" cellpadding="0px" cellspacing="0px" border="0px">
	<tr>
		<td valign="top" nowrap>
			<div style="width:330px">
				<div class="G_title">
				<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label4" runat="server" Font-Bold="true" Text="개인별 등급분포"/></td>
                    </tr>
                </table>

				</div>
				<div>
                    <asp:Chart ID="chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" 
                                Width="100" Height="100" >
                        <ChartAreas>
                            <asp:ChartArea Name="Default" BorderColor="196, 196, 196"
                                BackColor="White" ShadowColor="Transparent">
                                <AxisX linecolor="196, 196, 196" IsLabelAutoFit="False" Interval="1">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX>
                                <Area3DStyle WallWidth="3" Enable3D="true"/>
                                <AxisY linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True" >
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisY>
                                <AxisY2 linecolor="196, 196, 196" IsLabelAutoFit="False" Enabled="True">
                                    <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                    <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisY2>
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="2">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
				</div>		
			</div>
		</td>
		<td style="width:24px;">
			<img src="../images/Intro/space.gif" width="24px">
		</td>
		<td valign="top" >
			<div class="G_title">
				<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label5" runat="server" Font-Bold="true" Text="본부별 순위"/></td>
                    </tr>
                </table>

			</div>
			<div style="width:385px; height:260px;">
       	        <ig:UltraWebGrid ID="UltraWebGrid4" runat="server" Width="100%" Height="100%" 
                 OnInitializeRow="UltraWebGrid4_InitializeRow" 
                 OnInitializeLayout="UltraWebGrid4_InitializeLayout" 
                 OnSelectedRowsChange ="UltraWebGrid4_SelectedRowsChange">
                     <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="RANK_ID" Key="RANK_ID" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="순위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_NAME" Key="DEPT_NAME" Width="260px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="본부">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                               
                                <ig:UltraGridColumn BaseColumnName="TS_SCORE" Key="TS_SCORE" Width="60px" Format="#,##0.#0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="점수">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_REF_ID" Key="EST_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                   
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    AutoGenerateColumns="False"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="UltraWebGrid4" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Single" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="HeaderAndFooter" 
                                    OptimizeCSSClassNamesOutput="False"

                                    ViewType="Flat">
                                           
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
 
                    </DisplayLayout>
            </ig:UltraWebGrid>
			</div>
		</td>
		<td style="width:32px;">
			<img src="../images/Intro/space.gif" width="32px">
		</td>
		<td valign="top">
			<div class="G_title">
				<table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                    <tr>
                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                        <td><asp:Label ID="Label6" runat="server" Font-Bold="true" Text="개인별 순위"/></td>
                    </tr>
                </table>

			</div>
			<div style="width:240px; height:260px;">
            <ig:UltraWebGrid ID="UltraWebGrid5" runat="server" Width="100%" Height="100%" 
                 OnInitializeRow="UltraWebGrid5_InitializeRow" 
                 OnInitializeLayout="UltraWebGrid5_InitializeLayout" >
                     <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:UltraGridColumn BaseColumnName="RANK_ID" Key="RANK_ID" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <Header Caption="순위">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="120px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="사원">
                                    </Header>
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                               
                                <ig:UltraGridColumn BaseColumnName="TS_SCORE" Key="TS_SCORE" Width="60px" Format="#,##0.#0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="점수">
                                    </Header>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" DataType="System.Int32" Hidden="true"></ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Key="EMP_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                   
                    <DisplayLayout AllowColSizingDefault="Free" 
                                    AllowColumnMovingDefault="OnServer" 
                                    AllowDeleteDefault="Yes"
                                    AllowSortingDefault="Yes" 
                                    BorderCollapseDefault="Separate" 
                                    AutoGenerateColumns="False"
                                    HeaderClickActionDefault="SortMulti" 
                                    Name="UltraWebGrid5" 
                                    RowHeightDefault="20px" 
                                    RowSelectorsDefault="No" 
                                    SelectTypeRowDefault="Single" 
                                    Version="4.00" 
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed" 
                                    StationaryMargins="HeaderAndFooter" 
                                    OptimizeCSSClassNamesOutput="False"
                                    ReadOnly="LevelTwo"
                                    ViewType="Flat">
                                           
                        <GroupByBox>
                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                        </GroupByBox>
                        <RowStyleDefault  CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" ></FrameStyle>
 
                    </DisplayLayout>
            </ig:UltraWebGrid>
			</div>
		</td>
	</tr>
</table>
<!-- 개인별 끝 -->


</asp:Content>
