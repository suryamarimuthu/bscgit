<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Main_1280.aspx.cs" EnableEventValidation="false" Inherits="Dashboard_NHIT_Main_Table_1280" MasterPageFile="~/_common/lib/MicroBSC.master" %>

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
.txt_D{position:relative;top:60px;left:90px;font-size:14px;font-weight:bold;color:#8dbfd6}
.txt_C
{
    position:relative;
    top:105px;
    left:90px;
    font-family:'verdana';
    font-size:90px;
    font-weight:bold;
}

.txt_01{width:100px;font-family:"gulim";font-size:16px;font-weight:bold;}
.txt_02{width:132px;font-family:"verdana";font-size:26px;font-weight:bold;text-align:right;padding-right:8px;}
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
                        &nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Font-Bold="true" Text="차트 : "/>
                        <asp:RadioButtonList ID="rdoChartType" runat="server" RepeatLayout="Flow" RepeatColumns="2" style="cursor:pointer;">
                            <asp:ListItem Text="2D" Value="2D" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="3D" Value="3D"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:ImageButton ID="ImageButton2" runat="server" align="absmiddle" Height="19px" ImageUrl="../../images/btn/b_305.gif" OnClientClick="return doClicking();" Visible="false"/>
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
<table width="830px" cellpadding="0px" cellspacing="0px" border="0px" style="height:100%;">
	<tr>
		<td valign="top" nowrap>
			<%--<p style="height:5px"></p>--%>
		<!-- 경영현황 -->
			<table width="830px" height="258px" cellpadding="0px" cellspacing="0px" border="0px" style="background:url('../images/dashboard/back_dashb1.jpg') no-repeat;margin-top:18px;">
				<tr>
					<td width="281px;" valign="top" nowrap>
						<div class="txt_D"><asp:Label ID="lblYearMonth" runat="server" Text="2012년 9월"/></div>
						<div class="txt_C"><asp:Label ID="lblG" runat="server" Text="D" ForeColor="#b8b8b8" /></div>
					</td>
					<td width="543px" valign="top">
						<table width="520px" cellpadding="0px" cellspacing="0px" border="0" style="margin-top:98px;">
							<tr>
								<td class="txt_01" style="color:#f85607"><img src="../images/dashboard/icon_k3.gif"/>매출액</td>
								<td class="txt_02" style="color:#f85607"><asp:Label ID="lblMeDon" runat="server" Text="21,000"/></td>
								<td class="txt_03"><div class="txt_R" style="width:100%" id="divMe" runat="server"><asp:Label ID="lblMePer" runat="server" Text="100%"/></div></td>
							</tr>
							<tr>
								<td class="txt_01" style="color:#3b87dd"><img src="../images/dashboard/icon_k3.gif"/>영업이익</td>
								<td class="txt_02" style="color:#3b87dd"><asp:Label ID="lblYoungDon" runat="server" Text="185,120"/></td>
								<td class="txt_03"><div class="txt_B" style="width:95%" id="divYoung" runat="server"><asp:Label ID="lblYoungPer" runat="server" Text="95%"/></div></td>
							</tr>
							<tr>
								<td class="txt_01" style="color:#3b87dd"><img src="../images/dashboard/icon_k3.gif"/>당기순이익</td>
								<td class="txt_02" style="color:#3b87dd"><asp:Label ID="lblDangDon" runat="server" Text="65,520"/></td>
								<td class="txt_03"><div class="txt_B" style="width:1%" id="divDang" runat="server"><asp:Label ID="lblDangPer" runat="server" Text="5%"/></div></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		<!-- 경영현황 끝 -->
			<p style="height:5px"></p>
			<div style="float:left;width:310px">
				<div>
				    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
					    <ul class="ul_A">
						    <li class="li_L">
						        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                    <tr>
                                        <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                        <td><asp:Label ID="Label16" runat="server" Font-Bold="true" Text="매출/손익"/></td>
                                    </tr>
                                </table>
						    </li>
						    <li class="li_R">(단위 : 백만원)</li>
					    </ul>
					</div>
					<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
					    <asp:Chart ID="chart1" runat="server" Height="100" 
                             ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100">
                             <ChartAreas>
                                 <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" 
                                     ShadowColor="Transparent">
                                     <AxisX Interval="1" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                         <LabelStyle font="Tahoma, 10px" />
                                         <MajorGrid linecolor="196, 196, 196" />
                                     </AxisX>
                                     <Area3DStyle Enable3D="false" WallWidth="5" />
                                     <AxisY Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                         <LabelStyle font="Tahoma, 10px" />
                                         <MajorGrid linecolor="196, 196, 196" />
                                     </AxisY>
                                     <AxisY2 Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                         <LabelStyle font="Tahoma, 10px" />
                                         <MajorGrid linecolor="196, 196, 196" />
                                     </AxisY2>
                                 </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                 <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" 
                                     Docking="Top" LegendStyle="Row" Name="Default" ShadowOffset="2">
                                 </asp:Legend>
                             </Legends>
                         </asp:Chart>
					</div>
				</div>	
			</div>	

		
			<div style="float:left;width:510px;margin-left:10px;">
				<div>
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
					    <asp:Chart ID="chartMM" runat="server" Height="100" 
                             ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100">
                             <ChartAreas>
                                 <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" 
                                     ShadowColor="Transparent">
                                     <AxisX Interval="1" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                         <LabelStyle font="Tahoma, 10px" />
                                         <MajorGrid linecolor="196, 196, 196" />
                                     </AxisX>
                                     <Area3DStyle Enable3D="True" WallWidth="5" />
                                     <AxisY Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                         <LabelStyle font="Tahoma, 10px" />
                                         <MajorGrid linecolor="196, 196, 196" />
                                     </AxisY>
                                     <AxisY2 Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                         <LabelStyle font="Tahoma, 10px" />
                                         <MajorGrid linecolor="196, 196, 196" />
                                     </AxisY2>
                                 </asp:ChartArea>
                             </ChartAreas>
                             <Legends>
                                 <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" 
                                     Docking="Top" LegendStyle="Row" Name="Default" ShadowOffset="2" >
                                 </asp:Legend>
                             </Legends>
                         </asp:Chart>
					</div>
				</div>		
			</div>
		</td>
		<td style="width:15px;"><img src="../images/dashboard/space.gif" width="10px"></td>
		<td valign="top">

			<div style="width:340px;margin-bottom:5px;">
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    <ul class="ul_A">
					    <li class="li_L">
					        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label10" runat="server" Font-Bold="true" Text="고객별 매출현황"/></td>
                                </tr>
                            </table>
					    </li>
					    <li class="li_R">(단위 : 백만원)</li>
				    </ul>
				</div>
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    <asp:Chart ID="chart3" runat="server" Height="100" 
                         ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100">
                         <ChartAreas>
                             <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" 
                                 ShadowColor="Transparent">
                                 <AxisX Interval="1" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisX>
                                 <Area3DStyle Enable3D="true" WallWidth="5" />
                                 <AxisY Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisY>
                                 <AxisY2 Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisY2>
                             </asp:ChartArea>
                         </ChartAreas>
                         <Legends>
                             <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" 
                                 Docking="Top" LegendStyle="Row" Name="Default" ShadowOffset="2">
                             </asp:Legend>
                         </Legends>
                     </asp:Chart>
				</div>
			</div>

			<div style="width:340px;margin-bottom:5px;">
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
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
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    <asp:Chart ID="chart4" runat="server" Height="100" 
                         ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100">
                         <ChartAreas>
                             <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" 
                                 ShadowColor="Transparent">
                                 <AxisX Interval="1" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisX>
                                 <Area3DStyle Enable3D="true" WallWidth="5" />
                                 <AxisY Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisY>
                                 <AxisY2 Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisY2>
                             </asp:ChartArea>
                         </ChartAreas>
                         <Legends>
                             <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" 
                                 Docking="Top" LegendStyle="Row" Name="Default" ShadowOffset="2">
                             </asp:Legend>
                         </Legends>
                     </asp:Chart>
				</div>
			</div>
		</td>
		<td style="width:15px;"><img src="../images/dashboard/space.gif" width="10px"></td>
		<td valign="top">
			<div style="width:340px;margin-bottom:5px;">
			    <div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
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
				<div style="clear:both; cursor:pointer;" onclick="return doPoppingUp();">
				    <asp:Chart ID="chart5" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100" Height="100" >
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

			<div style="width:340px;margin-bottom:5px;">
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
				    <asp:Chart ID="chart2" runat="server" Height="100" 
                         ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Palette="None" Width="100">
                         <ChartAreas>
                             <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" 
                                 ShadowColor="Transparent">
                                 <AxisX Interval="1" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisX>
                                 <Area3DStyle Enable3D="true" WallWidth="5" />
                                 <AxisY Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisY>
                                 <AxisY2 Enabled="True" IsLabelAutoFit="False" linecolor="196, 196, 196">
                                     <LabelStyle font="Tahoma, 10px" />
                                     <MajorGrid linecolor="196, 196, 196" />
                                 </AxisY2>
                             </asp:ChartArea>
                         </ChartAreas>
                         <Legends>
                             <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" 
                                 Docking="Top" LegendStyle="Row" Name="Default" ShadowOffset="2">
                             </asp:Legend>
                         </Legends>
                     </asp:Chart>
				</div>
			</div>
		</td>
	</tr>
</table>






</asp:Content>