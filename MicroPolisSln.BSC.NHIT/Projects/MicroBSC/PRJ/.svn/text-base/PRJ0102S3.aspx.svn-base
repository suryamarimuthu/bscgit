<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ0102S3.aspx.cs" Inherits="PRJ_PRJ0102S3" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<%@ Register Assembly="DundasWebChart, Version=5.0.0.1692, Culture=neutral, PublicKeyToken=90d06b0c62d592d0"
    Namespace="Dundas.Charting.WebControl" TagPrefix="DCWC" %>

<%--@ Register Assembly="Infragistics2.WebUI.UltraWebChart.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebChart" TagPrefix="igchart" --%>
<%--@ Register Assembly="Infragistics2.WebUI.UltraWebChart.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.UltraChart.Resources.Appearance" TagPrefix="igchartprop" --%>
<%--@ Register Assembly="Infragistics2.WebUI.UltraWebChart.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.UltraChart.Data" TagPrefix="igchartdata" --%>

<%--@ Register Assembly="Infragistics2.WebUI.WebSchedule.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="ig_sched" --%>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">
<script id="Infragistics" type="text/javascript">
<!--

function OpenSchedule(taskRefID)
{
            var prjRefID        = "<%= this.IPrjRefID %>";
            var ICCB1           = "<%= this.ICCB1 %>";
            var READ_ONLY_YN    = "<%= this.READ_ONLY_YN %>";
            var PAGE_TYPE       = "<%= this.PAGE_TYPE %>";
            
//            if(PAGE_TYPE == "N")
//                READ_ONLY_YN = "N";

            //alert(taskRefID);
            var url             = "PRJ0102M1.aspx?PRJ_REF_ID="+ prjRefID + "&TASK_REF_ID=" + taskRefID + "&CCB1=" + ICCB1 + "&READ_ONLY_YN=" + READ_ONLY_YN;
            if(taskRefID != null)
            {
                gfOpenWindow(url, 700, 480, 'yes', 'no', 'PRJ0102M1');
            }
}
-->
</script>

<!--- MAIN START --->
    <asp:Panel ID="pnlPrjSearch" runat="server">
        <table cellpadding="0" cellspacing="0" border="0"  style="width:100%; height:20px;" >
          <tr>
            <td align="left" valign="top">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                   <tbody>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tableBorder">
                                <tr>
                                  <td class="cssTblTitle">사업유형&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:dropdownlist id="ddlPrjType" class="box01" runat="server" width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPrjType_SelectedIndexChanged"></asp:dropdownlist>
                                    <asp:Label ID="lblPrjTypeName" runat="server" Visible="False" Width="150px"></asp:Label></td>
                                  <td class="cssTblTitle">사업년도&nbsp;</td>
                                  <td class="cssTblContent">
                                        <ig:webmaskedit id="txtYear" runat="server" InputMask="####" RealText="&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;&#2;" AutoPostBack="true"
                                               HorizontalAlign="Center" Width="100%" ToolTip="YYYY" Font-Names="Verdana" Font-Size="9pt" DataMode="RawText"></ig:webmaskedit>
                                  </td>
                                </tr>
                                <tr>
                                  <td class="cssTblTitle" style="border-right:none;">사 업 명&nbsp;</td>
                                  <td class="cssTblContent">
                                    <asp:DropDownList id="ddlPrjName" class="box01" runat="server" width="100%" AutoPostBack="false" OnSelectedIndexChanged="ddlPrjName_SelectedIndexChanged"></asp:DropDownList>
                                  </td>
                                  <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                                  <td class="cssTblContent">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:25px;">
                        <td align="right">
                            <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" OnClick="iBtnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                      <td align="right">
                        <a href="javascript:window.close();"><img alt="" visible="false" runat="server" src="../images/btn/b_003.gif" id="ImgClose"/></a>
                      </td>
                    </tr>
                  </tbody>
                </table>
            </td>
          </tr>
        </table>
    </asp:Panel>
   
    <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
      <asp:Panel ID="pnlPrjInfo" runat="server" Visible="true">
      <tr>
        <td style="text-align:center; font-size:large; font-weight:bold; text-decoration:underline; height:50px;">
            <asp:Literal ID="lblPrjName" runat="server" Visible="true"></asp:Literal>
        </td>
      </tr>
      <tr>
        <td style="height:30px; font-size:small; font-weight:bold;">
          &nbsp;<img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" />&nbsp;기본정보
        </td>
      </tr>
      <tr>
        <td style="margin-left:10px;">
          <table border="0" cellpadding="1px" cellspacing="0px" width="100%" class="tableBorder">
            <tr>
              <th class="tableTitle" style="width:10%; font-weight:bold;">진&nbsp;행&nbsp;율</th>
              <td class="tableContent" style="width:40%;"><asp:Label ID="lblPROCEED_RATE" runat="server"></asp:Label>&nbsp;</td>
              <th class="tableTitle" style="width:10%; font-weight:bold;">사업유형&nbsp;</th>
              <td class="tableContent" style="width:40%;"><asp:Label ID="lblPRJ_TYPE" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr>
              <th class="tableTitle" style="font-weight:bold;">계획기간</th>
              <td class="tableContent"><asp:Label ID="lblplanSDate" runat="server" Text=""></asp:Label>~<asp:Label ID="lblplanEDate" runat="server" Text="" />&nbsp;</td>
              <th class="tableTitle" style="font-weight:bold;">실행기간</th>
              <td class="tableContent"><asp:Label ID="lblActualSDate" runat="server" Text=""></asp:Label>~<asp:Label ID="lblActualEDate" runat="server" Text="" />&nbsp;</td>
            </tr>
            <tr>
              <th class="tableTitle" style="font-weight:bold;">주관부서</th>
              <td class="tableContent"><asp:Label ID="lblOWNER_DEPT_NAME" runat="server" ></asp:Label>&nbsp;</td>
              <th class="tableTitle" style="font-weight:bold;">책&nbsp;임&nbsp;자</th>
              <td class="tableContent"><asp:Label ID="lblOWNER_EMP_NAME" runat="server" ></asp:Label>&nbsp;</td>
            </tr>
            <tr>
              <th class="tableTitle" style="font-weight:bold;">중&nbsp;요&nbsp;도</th>
              <td class="tableContent">
                <asp:Label ID="lblPRIORITY" runat="server" Text="" ></asp:Label>&nbsp;
                <asp:DropDownList ID="ddlPRIORITY" runat="server" class="box01" Visible="false"></asp:DropDownList>
              </td>
              <th class="tableTitle" style="font-weight:bold;">총사업비</th>
              <td class="tableContent"><asp:Label ID="lblTOTAL_BUDGET" runat="server" Text="" ></asp:Label></td>
            </tr>
            <tr>
              <th class="tableTitle" style="width:10%; font-weight:bold;">전략목표</th>
              <td class="tableContent" style="width:90%;" colspan="3"><asp:Label ID="lblREF_STG" runat="server" Text="" ></asp:Label>&nbsp;</td>
            </tr>
            <tr>
              <th class="tableTitle" style="width:10%; font-weight:bold;">기대효과</th>
              <td class="tableContent" style="width:90%;" colspan="3"><asp:Label ID="lblEFFECTIVENESS" runat="server" Text="" ></asp:Label>&nbsp;</td>
            </tr>
            <tr>
              <th class="tableTitle" style="width:10%; font-weight:bold;">사업범위</th>
              <td class="tableContent" style="width:90%;" colspan="3"><asp:Label ID="lblRANGE" runat="server" Text="" ></asp:Label>&nbsp;</td>
            </tr>
          </table>
        </td>
        </tr>
      <tr>
          <td style="height:30px; font-size:small; font-weight:bold; vertical-align:middle;">
            &nbsp;<img src="../images/icon/subtitle.gif" alt="" style="vertical-align:middle;" />&nbsp;진행일정
          </td>
        </tr>
      </asp:Panel>
      <tr>
          <td style="text-align:center;">
<%--            <asp:Panel ID="Panel1" runat="server" Width="800px"  HorizontalAlign="Center" ScrollBars="Auto" BorderWidth="1px" BorderColor="WhiteSmoke">--%>
              <DCWC:CHART id="Chart1" runat="server" BackColor="#90D0E8" BackGradientEndColor="144, 208, 232" Width="790px" Height="430px" BorderLineStyle="Solid" Palette="Dundas" BackGradientType="TopBottom" BorderLineColor="SteelBlue" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" OnPostPaint="Chart1_PostPaint">
	                <Legends>
		                <dcwc:Legend LegendStyle="Row" Enabled="False" AutoFitText="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
			                <Position Y="85" Height="9.054053" Width="36.26765" X="54.46494"></Position>
		                </dcwc:Legend>
	                </Legends>
	                <BorderSkin SkinStyle="Emboss"></BorderSkin>
	                <Series>
		                <dcwc:Series YValuesPerPoint="2" LegendText="계획" Name="Tasks" ChartType="Gantt" CustomAttributes="PointWidth=0.7" BorderColor="43, 184, 218" Color="43, 184, 218"></dcwc:Series>
		                <dcwc:Series YValuesPerPoint="2" LegendText="실적" Name="Progress" ChartType="Gantt" CustomAttributes="DrawSideBySide=false, PointWidth=0.5" BorderColor="255, 166, 35" Color="255, 166, 35"></dcwc:Series>
	                </Series>
	                <ChartAreas>
		                <dcwc:ChartArea Name="Default" BorderColor="0, 107, 156" BorderStyle="Solid" BackGradientEndColor="14, 151, 199" BackColor="White" ShadowColor="Transparent">
			                <Area3DStyle YAngle="10" Perspective="10" XAngle="15" RightAngleAxes="False" WallWidth="0"></Area3DStyle>
			                <Position Y="6" Height="80" Width="87" X="5"></Position>
			                <AxisY LineColor="64, 64, 64, 64" StartFromZero="False" labelsautofit="False">
				                <LabelStyle Font="DotumChe, 8pt"></LabelStyle>
				                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
			                </AxisY>
			                <AxisX LineColor="64, 64, 64, 64" >
				                <LabelStyle Font="DotumChe, 8pt" ShowEndLabels="False"></LabelStyle>
				                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
			                </AxisX>
		                </dcwc:ChartArea>
	                </ChartAreas>
                </DCWC:CHART>
<%--            </asp:Panel>--%>
          </td>
        </tr>
      <tr>
          <td align="right">
            <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
            <img alt="" runat="server" src="../images/btn/b_080.gif" Visible="false"  id="Img2" onclick="window.print();" />
            <img alt="" visible="false" runat="server" src="../images/btn/b_003.gif" id="Img1" onclick="self.close();" />
          </td>
        </tr>
    </table>
<!--- MAIN END --->

<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>