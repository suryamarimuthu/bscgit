<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Main_1280_N1.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Main_Table_1280_N1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">


<style>
body{margin:0;padding:0;font-family:"dotum";font-size:12px;color:#747474;}
div,p,ul,li{margin:0;padding:0;font-family:"dotum";font-size:12px;color:#747474;}
img{border:none;}
a{text-decoration:none;outline:none;}
li{list-style:none}
input{border:1px solid #DFDFDF;font-family:dotum;font-size:12px;color:#666666;}
.txt_D{clear:both;text-align:center; width:230px; height:30px;font-size:20px;font-weight:bold;color:#8dbfd6}
.txt_C
{
    clear:both;width:230px;
    height:130px;
    text-align:center;
    font-family:'verdana';
    font-size:120px;
    font-weight:bold;
}

.txt_01{width:200px;font-family:"gulim";font-size:16px;font-weight:bold; padding-left:100px;}
.txt_02{width:200px;font-family:"verdana";font-size:20px;font-weight:bold;text-align:right;padding-right:50px;}
.txt_03
{
    width:270px;
    background:url('../images/dashboard/back_gr_D.gif') no-repeat;
    padding:0px 6px 6px 4px;
}

.txt_R
{
    text-align:right;
    height:12px;
    font-weight:bold;
    color:#000;
    background:url(../images/dashboard/back_gr_R.gif);
}

.txt_B{text-align:right;height:14px;font-weight:bold;color:#000;background:url(../images/dashboard/back_gr_B.gif);}
.ul_A{margin:0;padding:0;}
.li_L{margin:0;padding:0;float:left;width:50%;font-weight:bold;color:#000;}
.li_R{margin:0;padding:0;float:left;text-align:right;width:45%;padding-top:3px;font-size:11px;}
</style>

<script id="Script1" type="text/javascript">
    function doPoppingUp() {
        var ddlYear = document.getElementById('ctl01_Contents_ddlYear');
        var ddlMonth = document.getElementById('ctl01_Contents_ddlMonth');

        var cr_year = ddlYear.options[ddlYear.selectedIndex].value;
        var cr_month = ddlMonth.options[ddlMonth.selectedIndex].value;

        var url = 'NHIT_Main_TablePop.aspx?CR_YEAR=' + cr_year + '&CR_MONTH=' + cr_month;

        gfOpenWindow(url, 1040, 710, 'yes', 'no', 'DASHBOARD_TABLE');

        return false;
    }

    function doPoppingUpWin1() {
        var ddlYear = document.getElementById('ctl01_Contents_ddlYear');
        var ddlMonth = document.getElementById('ctl01_Contents_ddlMonth');

        var cr_year = ddlYear.options[ddlYear.selectedIndex].value;
        var cr_month = ddlMonth.options[ddlMonth.selectedIndex].value;

        var url = 'NHIT_Main_Popup1.aspx?CR_YEAR=' + cr_year + '&CR_MONTH=' + cr_month;

        gfOpenWindow(url, 1140, 710, 'yes', 'no', 'DASHBOARD_TABLE');

        return false;
    }
    function doPoppingUpWin2() {
        var ddlYear = document.getElementById('ctl01_Contents_ddlYear');
        var ddlMonth = document.getElementById('ctl01_Contents_ddlMonth');

        var cr_year = ddlYear.options[ddlYear.selectedIndex].value;
        var cr_month = ddlMonth.options[ddlMonth.selectedIndex].value;

        var url = 'NHIT_Main_Popup2.aspx?CR_YEAR=' + cr_year + '&CR_MONTH=' + cr_month;
        
        gfOpenWindow(url, 1140, 710, 'yes', 'no', 'DASHBOARD_TABLE');

        return false;
    }
    window.onload = function() {

        //        var width = window.screen.width;
        //        var height = window.screen.height;

        var width = document.body.clientWidth;
        var height = document.body.clientHeight;

        var url = 'NHIT_Main_Screen.aspx?WIDTH=' + width + '&HEIGHT=' + height;

        //        document.getElementById('ctl00_Contents_hdfChartWidth').value = width;
        //        document.getElementById('ctl00_Contents_hdfChartHeight').value = height;

        //document.location.href = url;
    }

    function doClicking() {
        alert(window.screen.width);
        alert(window.screen.height);

        return false;
    }
</script>
<table cellpadding="0" cellspacing="0" border="0" width="100%"  >
    <tr>
        <td>
            <table cellspacing="0" border="0" width="100%"> 
                <tr>
                    <td>
                        <asp:DropDownList id="ddlEstTermRefID" runat="server" class="box01" Visible="False" />
                         <asp:Literal ID="ltrScript" runat="server" />
                        <asp:HiddenField ID="hdfRefresh" runat="server" />
                        <asp:HiddenField ID="hdfChartWidth" runat="server" />
                        <asp:HiddenField ID="hdfChartHeight" runat="server" />
                        &nbsp;&nbsp;<asp:Label ID="Label22" runat="server" Font-Bold="true" Text="해상도 : " Visible="false"/>
                        <asp:DropDownList ID="ddlResolution" runat="server" CssClass="box01" style="cursor:pointer;"  Visible="false">
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Font-Bold="true" Text="차트 : " Visible="false"/>
                        <asp:RadioButtonList ID="rdoChartType" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer; " Visible="false">
                            <asp:ListItem Text="2D" Value="2D" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="3D" Value="3D"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:ImageButton ID="ImageButton2" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_305.gif" OnClientClick="return doClicking();" Visible="false"/>
                        <asp:RadioButtonList ID="rdoGoalTong" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;" >
                            <asp:ListItem Text="목표(Target)" Value="TARGET" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="의지목표(Goal)" Value="GOAL"></asp:ListItem>
                        </asp:RadioButtonList>&nbsp;&nbsp;  
                    </td>
                    <td class="cssPopBtnLine">
                        <asp:TextBox ID="txtWidth" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtHeight" runat="server" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box01" style="cursor:pointer;"></asp:DropDownList>
                        <asp:ImageButton ID="iBtnSearch" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_033.gif" OnClick="iBtnSearch_Click" ImageAlign="AbsMiddle"/>
                        <asp:ImageButton ID="ImageButton1" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_305.gif" OnClientClick="return doPoppingUp();" ImageAlign="AbsMiddle"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<!-- 조회 끝-->

<!-- 높이조절 끝 -->

<div style="vertical-align:text-top; text-align:center; height:100%;">
<table cellpadding="0px" cellspacing="0px" border="0px" style="width:1300px; height:500px; " >
    <tr>
        <td valign="top" >
            <div style="width:650px; height:252px; margin-bottom:2px; border:solid 1px gray;">
		    <table  cellpadding="0px" cellspacing="0px" border="0px" >
		        <tr >
		            <td style="width:230px; " valign="top" nowrap>
		                 <table cellpadding="0px" cellspacing="0px" border="0px" >
					        <tr>
						        <td class="txt_C"><asp:Label ID="lblG" runat="server" Text="D" ForeColor="#b8b8b8" /></td>
					        </tr>
					        <tr>
						        <td class="txt_D"><asp:Label ID="lblYearMonth" runat="server" Text="2012년 9월"/></td>
					        </tr>
                        </table>
		            </td>
		            <td>
		                <div style="margin-top:10px;"></div>
		                <table width="400px" cellpadding="0px" cellspacing="0px" border="0px"  >
					        <tr>
						        <td class="txt_01" style="color:#3b87dd"><img src="../images/dashboard/icon_k3.gif"/>매출액</td>
						        <td class="txt_02" style="color:#3b87dd"><asp:Label ID="lblMeDon" runat="server" Text="0"/></td>
					        </tr>
					        <tr>
						        <td class="txt_01" style="color:#3b87dd"><img src="../images/dashboard/icon_k3.gif"/>영업이익</td>
						        <td class="txt_02" style="color:#3b87dd"><asp:Label ID="lblYoungDon" runat="server" Text="0"/></td>
					        </tr>
					        <tr>
						        <td class="txt_01" style="color:#3b87dd"><img src="../images/dashboard/icon_k3.gif"/>당기순이익</td>
						        <td class="txt_02" style="color:#3b87dd"><asp:Label ID="lblDangDon" runat="server" Text="0"/></td>
					        </tr>
					        <tr>
					            <td colspan="2">
					                <DCWC:Chart ID="chart6" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  
					                    Height="100px"  Width="100px" >
                                        <ChartAreas>
                                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="false" Interval="1">
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisX>
                                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="false" Enabled="True"  >
                                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                            </AxisY>
                                            
                                            </DCWC:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                            LegendStyle="Row" Name="Default" ShadowOffset="0" Enabled = "false">
                                            </DCWC:Legend>
                                        </Legends>
                                    </DCWC:Chart>
					            </td>
					        </tr>
				        </table>
		            </td>
		        </tr>
		    </table>
		    </div>
        </td>
        <td valign="top" >
			<div style="width:320px; height: 250px; margin-bottom:2px;  border:solid 1px gray;">
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin2();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" >
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label10" runat="server" Font-Bold="true" Text="고객별 매출현황"/></td>
                                </tr>
                            </table>
					    </li>
					    <li class="li_R">(단위 : 백만원)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin2();">
				    <DCWC:Chart ID="chart3" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="100px"  Width="100" >
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisY>
                            
                            </DCWC:ChartArea>
                        </ChartAreas>
                        <Legends>
                             <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="0">
                            </DCWC:Legend>
                        </Legends>
                    </DCWC:Chart>
				</div>
			</div>        
		</td>
        <td  valign="top">
			<div style="width:320px; height:250px; margin-bottom:2px; margin-left: 2px; border:solid 1px gray;">
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin2();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label14" runat="server" Font-Bold="true" Text="본부별 매출현황"/></td>
                                </tr>
                            </table>
					    </li>
					    <li class="li_R">(단위 : 백만원)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin2();">
					    
					    <DCWC:Chart ID="chart5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="100px"  Width="100" >
                            <ChartAreas>
                                <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisX>
                                <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                </AxisY>
                                
                                </DCWC:ChartArea>
                            </ChartAreas>
                            <Legends>
                                 <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                LegendStyle="Row" Name="Default" ShadowOffset="0">
                                </DCWC:Legend>
                            </Legends>
                        </DCWC:Chart>
  				   
				</div>
			</div>
        </td>
       
    </tr>
    <tr>
        <td valign="top" >
			<div style="width:650px; height:252px; border:solid 1px gray;">
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin1();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label16" runat="server" Font-Bold="true" Text="경영실적"/></td>
                                </tr>
                            </table>
					    </li>
					    <li class="li_R">(단위 : 백만원)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin1();">

				    <table  cellpadding="0" cellspacing="0" border="0" >
				        <tr>
				            <td style="width:280px;" valign="top" >
				                <DCWC:Chart ID="chart1" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="100px"  Width="100" >
                                    <ChartAreas>
                                        <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                                        BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                                        <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisX>
                                        <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                                        <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                                        <LabelStyle font="Tahoma, 10px"></LabelStyle>
                                        <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                                        </AxisY>
                                        
                                        </DCWC:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                        LegendStyle="Row" Name="Default" ShadowOffset="0">
                                        </DCWC:Legend>
                                    </Legends>
                                </DCWC:Chart>
				            </td>
				            <td style="width:360px; height:100%;" valign="top">
				            	<div style="height:20px;"> &nbsp;</div>
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
                                                    <FooterStyle HorizontalAlign="Center" Height="40px" />
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
                                                   RowHeightDefault="40px"
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
                                        <FrameStyle BorderWidth="0px" Width="100%" Height="100%" ></FrameStyle>
                                        <Images>
                                            <CurrentRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                            <CurrentEditRowImage url="../../images/icon/arrow_red_beveled.gif" />
                                        </Images>
                                    </DisplayLayout>
                                </ig:UltraWebGrid>
				            </td>
				        </tr>
				    </table>
				</div>
			</div>	
        </td>
       
			<%--<div>
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label17" runat="server" Font-Bold="true" Text="월별 당기순이익"/></td>
                                </tr>
                            </table>
                        </li>
					    <li class="li_R">(단위 : 백만원)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    
				    <DCWC:Chart ID="chartMM" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="100px"  Width="100" >
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisY>
                            
                            </DCWC:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="0">
                            </DCWC:Legend>
                        </Legends>
                    </DCWC:Chart>
                   
				</div>
			</div>		--%>
      
        <td style="width:320px" valign="top">
			<div style="width:320px; height:250px; margin-bottom:2px;  border:solid 1px gray;">
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWin2();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label12" runat="server" Font-Bold="true" Text="사업유형별 매출현황"/></td>
                                </tr>
                            </table>
					    </li>
					    <li class="li_R">(단위 : 백만원)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUpWIn2();">
				    
				    <DCWC:Chart ID="chart4" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="100px"  Width="100" >
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" >
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisY>
                            
                            </DCWC:ChartArea>
                        </ChartAreas>
                        <Legends>
                             <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="0">
                            </DCWC:Legend>
                        </Legends>
                    </DCWC:Chart>
  				   
				</div>
			</div>
        </td>
        <td valign="top">
			<div style="width:320px;margin-bottom:2px; margin-left:2px; border:solid 1px gray;">
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label20" runat="server" Font-Bold="true" Text="인력정산"/></td>
                                </tr>
                            </table>
					    </li>
					    <li class="li_R">(단위 : %)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    
				    <DCWC:Chart ID="chart2" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="Dundas"  Height="100px"  Width="100" >
                        <ChartAreas>
                            <DCWC:ChartArea Name="Default" BorderColor="196, 196, 196"
                            BackGradientEndColor="White" BackColor="White" ShadowColor="Transparent">
                            <AxisX linecolor="196, 196, 196" LabelsAutoFit="False" Interval="1">
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisX>
                            <Area3DStyle XAngle="15" YAngle="10" WallWidth="5" Enable3D="false"/>
                            <AxisY linecolor="196, 196, 196" LabelsAutoFit="False" Enabled="True" StartFromZero = "false" >
                            <LabelStyle font="Tahoma, 10px"></LabelStyle>
                            <MajorGrid linecolor="196, 196, 196" ></MajorGrid>
                            </AxisY>
                            
                            </DCWC:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <DCWC:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                            LegendStyle="Row" Name="Default" ShadowOffset="0">
                            </DCWC:Legend>
                        </Legends>
                        </DCWC:Chart>
  				   
				</div>
			</div>
        </td>
    </tr>
</table> 
</div>

</asp:Content>