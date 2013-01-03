<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_ana_view.aspx.cs" Inherits="usr_ana_view" %>
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl_NotLeftMenu_BSC.ascx" %>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
<script language="javascript">
function showMemo() 
{
    document.all.imgShow.style.display      = "none";
    document.all.imgHide.style.display      = "block";
	document.all.leftLayer.style.display    = "block";
}

function hiddenMemo() 
{
    document.all.imgShow.style.display      = "block";
    document.all.imgHide.style.display      = "none";
	document.all.leftLayer.style.display    = "none";
}
</script>
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" />
    <%--<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>--%>
<!--- MAIN START --->
<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
    <%--<tr>
        <td colspan="2" height="26">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="26" width="170"><asp:Image ID="leftTopTitle" runat="server" width="170" height="26" ImageUrl="~/images/left/le_c06.gif" /><br/></td>
                    <td height="26" background="/MicroBSC/images/top/skip_1/sk_bg4.gif">
                        <table width='100%' border='0' cellpadding='0' cellspacing='0'>
                            <tr>
                                <td width='2' height='27'>&nbsp;</td>
                                <td width='2'></td>
                                <td>
                                    <table cellpadding=0 cellspacing=0 width=100%>
                                        <tr>
                                            <td width="50%">
                                            &nbsp;
                                                <strong>
                                                    <ASP:LABEL id="lblTitle" runat="server"></ASP:LABEL></strong>
                                                    <b>평가기간</b> : 
                                                    <asp:DropDownList ID="ddlEstTermInfo" runat="server"
                                                        Width="125px">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMonthInfo" runat="server" class="box01"
                                                        Width="48px">
                                                    </asp:DropDownList>
                                                <b>월</b>&nbsp;</td>
                                            <td align=right>
                                                <asp:Label ID="lblDeptPath" runat="server" ForeColor="#2080D0"></asp:Label>&nbsp;
                                                </td>
                                            <td width=20></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>--%>
    <tr>
        
        <td align="left" valign="top" width="160px"><DIV style="BORDER-RIGHT: #f4f4f4 3px solid; PADDING-RIGHT: 2px; BORDER-TOP: #f4f4f4 3px solid; DISPLAY: block; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; OVERFLOW: auto; BORDER-LEFT: #f4f4f4 3px solid; WIDTH: 169px; PADDING-TOP: 2px; BORDER-BOTTOM: #f4f4f4 3px solid; HEIGHT: 100%" id="leftLayer">
                <asp:TreeView ID="trvEstDept" runat="server" OnSelectedNodeChanged="trvEstDept_SelectedNodeChanged" NodeIndent="5">
                    <SelectedNodeStyle BackColor="Silver"></SelectedNodeStyle>
                </asp:TreeView>
              </div>
              <SJ:SmartScroller ID="SmartScroller1" runat="server" TargetObject="leftLayer"></SJ:SmartScroller>
        </td>
        <%--<td style="width: 9px">
                    <a href="javascript:hiddenMemo('leftLayer');"><img src="../images/btn/btn_Hide.gif" id="imgHide" border="0"/></a><br /><a href="javascript:showMemo('leftLayer');"><img src="../images/btn/btn_Show.gif" id="imgShow" style="display:none" border="0" /></a>   
                </td>--%>
        <td valign="top">
        <ig:UltraWebTab id="UltraWebTab1" runat="server" Width="100%" Height="100%" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True" ThreeDEffect="False" OnTabClick="UltraWebTab1_TabClick" SpaceOnLeft="4" AutoPostBack="True" SelectedTab="1">
	        <DisabledTabStyle BackColor="Silver"></DisabledTabStyle>
	        <DefaultTabStyle Height="22px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="Silver" ForeColor="#E4E4E2" BackColor="#FEFCFD" Font-Bold="True">
		        <Padding Top="2px"></Padding>
	        </DefaultTabStyle>
	        <RoundedImage LeftSideWidth="7" RightSideWidth="6" ShiftOfImages="2" SelectedImage="../images/tab/ig_tab_red.gif" NormalImage="../images/tab/ig_tab_blue.gif" HoverImage="../images/tab/ig_tab_red.gif" FillStyle="LeftMergedWithCenter"></RoundedImage>
	        <SelectedTabStyle ForeColor="#F7F7F7" Font-Bold="True">
		        <Padding Bottom="2px"></Padding>
	        </SelectedTabStyle>
	        <HoverTabStyle ForeColor="#E4E4E2" Font-Bold="True"></HoverTabStyle>
	        <Tabs>
	            <ig:Tab Key="DEPT_ORG" Text="조직상황판" Tooltip="조직상황판">
                    <ContentTemplate>
                        <iframe id="ifm_1" runat="server" frameborder="0" style="overflow: auto; width: 100%; height: 100%"></iframe>
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
		        </ig:Tab>
		        <ig:Tab Key="STG_MAP" Text="전략체계도" Tooltip="전략체계도">
                    <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
		        </ig:Tab>
		        <ig:Tab Key="GROUP_VIEW" Text="관점별현황" Tooltip="관점별현황">
		            <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
                <ig:Tab Key="STG_LIST" Text="전략리스트" Tooltip="전략리스트">
                    <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
		        <ig:Tab Key="KPI_LIST" Text="KPI리스트" Tooltip="KPI리스트">
		            <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
                <ig:Tab Key="DATE_SCORE_CARD" Text="기간별점수" Tooltip="기간별점수">
                    <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
                <ig:Tab Key="DEPT_SCORE_CARD" Text="부서별점수" Tooltip="부서별점수">
                    <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
                <ig:Tab Key="PAREPORT" Text="PA리포트" Tooltip="PA리포트">
                    <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
                <ig:Tab Key="CEO_COM" Text="Communication" Tooltip="Communication">
                    <ContentTemplate>
                        
                    </ContentTemplate>
                    <ContentPane BorderStyle="None"></ContentPane>
                </ig:Tab>
	        </Tabs>
        </ig:UltraWebTab>
        </td>
    </tr>
</table>
<asp:literal id="ltrScript" runat="server"></asp:literal>

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

