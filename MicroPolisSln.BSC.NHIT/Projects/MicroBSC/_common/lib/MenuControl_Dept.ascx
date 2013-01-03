<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl_Dept.ascx.cs" Inherits="_common_lib_MenuControl_Dept" %>
<%@ Register Src="CheckInOutControl.ascx" TagName="CheckInOutControl" TagPrefix="uc1" %>
<%@ Register TagPrefix="TitleControl" TagName="TitleControl" Src="~/_common/lib/ServiceTitleControl.ascx" %>
<%@ Register TagPrefix="ApprovalList" TagName="ApprovalListControl" Src="~/_common/lib/ApprovalListControl.ascx" %>

<script type="text/javascript">
    var saMenu = new Array();
    var sMenu = "";
    
    function mfStartMenu()
    {
        try
        {
            for (var i=0; i<saMenu.length; i++)
            {
                var oMenu = gfGetFindObj(saMenu[i]);
                
                if (oMenu != null)
                {
                    if (oMenu.length == undefined)
                        oMenu.style.display = "none";
                    else
                    {
                        for (var j=0; j<oMenu.length; j++)
                        {
                            oMenu[j].style.display = "none";
                        }
                    }
                }
            }
        }
        catch(e){}
        
        mfStatusMenu();
    }
    
    function mfStatusMenu()
    {
        try
        {
            for (var i=0; i<saMenu.length; i++)
            {
                if (sMenu == saMenu[i])
                {
                    var oMenu = gfGetFindObj(saMenu[i]);
                    
                    if (oMenu != null)
                    {
                        if (oMenu.length == undefined)
                            oMenu.style.display = "block";
                        else
                        {
                            for (var j=0; j<oMenu.length; j++)
                            {
                                oMenu[j].style.display = "block";
                            }
                        }
                    }
                }
            }
        }
        catch(e){}
    }
    
    function mfToggleMenu(sMenuID)
    {
        try
        {
            for (var i=0; i<saMenu.length; i++)
            {
                var oMenu = gfGetFindObj(saMenu[i]);
                
                if (sMenuID == saMenu[i])
                {
                    if (oMenu != null)
                    {
                        if (oMenu.length == undefined)
                            oMenu.style.display = "block";
                        else
                        {
                            for (var j=0; j<oMenu.length; j++)
                            {
                                oMenu[j].style.display = "block";
                            }
                        }
                    }
                }
                else
                {
                    if (oMenu != null)
                    {
                        if (oMenu.length == undefined)
                            oMenu.style.display = "none";
                        else
                        {
                            for (var j=0; j<oMenu.length; j++)
                            {
                                oMenu[j].style.display = "none";
                            }
                        }
                    }
                }
            }
        }
        catch(e) {}
        
        mfStatusMenu();
        
        return false;
    }
    
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
                    <td height="65" colspan="2" background="/images/top/skip_1/sk_bg2.gif">
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
                                                        <td width="30">&nbsp;</td>
                                                        <td width="190" align="center">
                                                            &nbsp;<a href="<%=GetRootPagePath("/mgr/svr4100.aspx")%>"><img ID="ImageButton1" src="~/images/btn/top_bu_k01_b.gif" runat="server"  /></a>
                                                            <a href="<%=GetRootPagePath("/usr/usr3010.aspx")%>"><img ID="ImageButton2" src="~/images/btn/top_bu_k02_b.gif"  runat="server" /></a></td>
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
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                <tr>
               
                    <td  align="left" valign="top" width="130px">
                      <div id="leftLayer" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; 
                                width: 100%;  height: 100%; padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px; ">
                                <asp:TreeView ID="trvDeptScore" runat="server"></asp:TreeView>
                      </div>
                    </td>
                
                    <td valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                            <tr>
                                <td  height="4" style="width: 4px"><img src="/images/blank.gif" width="4"/><br/></td>
                            </tr>
                            <tr valign="top">
                                <td style="width: 4px"><img src="/images/blank.gif" width="4"></td>
                                <td width="100%">