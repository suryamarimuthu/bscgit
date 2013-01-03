<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl_NotLeftMenu.ascx.cs" Inherits="_common_lib_MenuControl_Dept_NotLeft" %>
<%@ Register Src="CheckInOutControl.ascx" TagName="CheckInOutControl" TagPrefix="uc1" %>
<%@ Register TagPrefix="TitleControl" TagName="TitleControl" Src="~/_common/lib/ServiceTitleControl.ascx" %>
<%@ Register TagPrefix="ApprovalList" TagName="ApprovalListControl" Src="~/_common/lib/ApprovalListControl.ascx" %>

<script type="text/javascript">
    var saMenu = new Array();
    var sMenu = "";
    
    function mfLeftTopTitle(sImgUrl)
    {
        var oImg = gfGetFindObj("leftTopTitle");
        if (oImg)
        {
            try
            {
                oImg.src = sImgUrl;
            }
            
            catch(e)
            {
            
            }
        }
    }
</script>

<table border="0" height="100%" width="100%" CELLPADDING="0" CELLSPACING="0">
    <tr>
        <td align="center" valign="top" height="68">

            <!-- 탑 시작-->
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="2" background="/images/top/skip_1/sk_bg2.gif" style="height: 65px">
                        <table width="992" height="68" border="0" cellpadding="0" cellspacing="0" background="/images/top/skip_1/sk_bg1.gif">
                            <tr>
                                <td width="250" rowspan="2"><a href="javascript:GoUrl('home');"><img src="/images/top/px_no.gif" width="225" height="50" border="0"></a></td>
                                <td align="right" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="26" align="right"><img src="/images/icon/top_icon01.gif" width="9" height="11" align="absmiddle"> 
                                                <span class="stext">
                                                    <A HREF="javascript:gfOpenWindow('../base/com2000.aspx',300,310,false,false);">
                                                    [<ASP:LABEL id="lblEmpName" runat="server"></ASP:LABEL>]</A> 님이 로그인 하셨습니다.
                                                </span>
                                            </td>
                                            <td width="110" align="center"><a href="javascript:GoUrl('logout')"><img src="/images/icon/top_icon02.gif" width="53" height="12" border="0" align="absmiddle"></a> </td>
                                            <td width="190" align="center" class="left_menu3" style="cursor:hand;" onclick="GoUrl('com1000')">
                                                <div id="KPI_RESULT_RATE_Tbl" runat="server">
                                                    <strong>
                                                        <font color="#FFFFFF">
                                                            <ASP:LABEL id="lblFinishMonth" runat="server"></ASP:LABEL> KPI실적마감율 : 
                                                            <font color="9CFF00">
                                                                <ASP:LABEL id="lblFinishRate" runat="server"></ASP:LABEL>%
                                                            </font>
                                                        </font>
                                                    </strong>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom">
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="522" height="30">
                                                            <ASP:LITERAL id="litTopMenu" runat="server"></ASP:LITERAL>
                                                        </td>
                                                        <td width="20">&nbsp;</td>
                                                        <td width="200" align="right">
                                                            <a href="<%=GetRootPagePath("/mgr/svr4100.aspx")%>"><img ID="ImageButton1" src="~/images/btn/top_bu_k01_b.gif" runat="server"   /></a>
                                                            <a href="<%=GetRootPagePath("/usr/usr3010.aspx")%>"><img ID="ImageButton2" src="~/images/btn/top_bu_k02_b.gif"  runat="server"  /></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <!-- 탑 끝-->
        </td>
    </tr>
    <tr>
        <td height="26">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="26" width="170"><asp:Image ID="leftTopTitle" runat="server" width="170" height="26" ImageUrl="~/images/left/le_c02.gif" /><br/></td>
                    <td height="26" background="/images/top/skip_1/sk_bg4.gif">
                        <table width='100%' border='0' cellpadding='0' cellspacing='0'>
                            <tr>
                                <td width='15' height='27'>&nbsp;</td>
                                <td width='25'><img src='/images/icon/mtt_icon01.gif' id="imgTitle" runat="server"></td>
                                <td>
                                    <table cellpadding=0 cellspacing=0 width=100%>
                                        <tr>
                                            <td width=30%>
                                            &nbsp;
                                                <strong>
                                                    <ASP:LABEL id="lblTitle" runat="server"></ASP:LABEL>
                                                </strong>
                                            </td>
                                            <td align=right>
                                                <uc1:CheckInOutControl ID="CheckInOutControl1" runat="server" /></td>
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
    </tr>
    <tr>
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                <tr>
                    <td valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                            <tr valign="top">
                                <td width="100%">

