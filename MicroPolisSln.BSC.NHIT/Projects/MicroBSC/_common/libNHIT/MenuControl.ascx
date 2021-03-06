﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl.ascx.cs" Inherits="_common_libNHIT_MenuControl" %>
<%@ Register Src="MenuControl_Tree.ascx" TagName="MenuControl_Tree" TagPrefix="uc2" %>
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
    
    function siteNavigete(strGubun)
    {
        if (strGrbun = 'B')
        {
            history.back();
        }
        else
        {
            history.forward();
        }
    }
    
    function getCookie(name)
	{
		var arg = name + "=";
		var alen = arg.length;
		var clen=document.cookie.length;
		var i=0;
		        
		while(i< clen)
		{
			var j = i+alen;
			if(document.cookie.substring(i,j)==arg)
			{
				var end = document.cookie.indexOf(";",j);
				if(end== -1)
					end = document.cookie.length;
				return unescape(document.cookie.substring(j,end));
			}
			i=document.cookie.indexOf(" ",i)+1;
			if (i==0) 
			break;
		}
		return null;
	}
    
    function showNotice()
    {
       //try
       //{
        var noticeCookie = getCookie("NOTICE_EST");

            if("<%= this.NOTICE_BOARD_ID %>" != "0")
            {
                if(noticeCookie == null)
                {
                     var today      = "<%= this._todayDate %>";
                     var startDay   = "<%= this.NOTICE_START_DATE %>";
                     var endDay     = "<%= this.NOTICE_END_DATE %>";
                        
                    if(dateCompare(startDay,today,"-") == true && dateCompare(today,endDay,"-") == true)
                    {
                       gfOpenWindow('../EST/EST_NOTICE.aspx?BOARD_ID=' + '<%= this.NOTICE_BOARD_ID %>' ,350,250,false,false);
                    }
                }
            }
       //}
       //catch(e) {}
       
        return false;
    }
    
    /*
     * 분리자를 이용하여 날짜의 유효성 체크
     * 예) 2000.03.24 -> '.'을 이용하여 체크한다.
     *@param inputDate 체크할 날짜
     *@param point 년,월,일 분리자
     */
    function dateCheck(inputDate, point){
        var dateElement = new Array(3);
        
        if(point != ""){
            dateElement = inputDate.split(point);
            if(inputDate.length != 10 || dateElement.length != 3){
                return false;
            }
        }else{
            dateElement[0] = inputDate.substring(0,4);
            dateElement[1] = inputDate.substring(4,6);
            dateElement[2] = inputDate.substring(6,9);
        }
        //년도 검사
        if( !( 1800 <= dateElement[0] && dateElement[0] <= 4000 ) ) {
            return false;
        }

        //달 검사
        if( !( 0 < dateElement[1] &&  dateElement[1] < 13  ) ) {
            return false;
        }

        // 해당 년도 월의 마지막 날
        var tempDate = new Date(dateElement[0], dateElement[1], 0);
        var endDay = tempDate.getDate();

        //일 검사
        if( !( 0 < dateElement[2] && dateElement[2] <= endDay ) ) {
             return false;
        }

        return true;
    }
     /*
     * 날짜 비교
     * 종료일이 시작일 보다 작을때 false를
     * 정상 기간일 경우 true를 리턴한다.
     * @param startDate 시작일
     * @param endDate 종료일
     * @param point 날짜 구분자
     */
     function dateCompare(startDate, endDate, point){
        //정상 날짜인지 체크한다.
        var startDateChk = dateCheck(startDate, point);
        if(!startDateChk){
            return false;
        }
        var endDateChk = dateCheck(endDate, point, "end");
        
        if(!endDateChk){
            return false;
        }

        //년 월일로 분리 한다.
        var start_Date = new Array(3);
        var end_Date = new Array(3);

        if(point != ""){
            start_Date = startDate.split(point);
            end_Date = endDate.split(point);
            if(start_Date.length != 3 && end_Date.length != 3){
                return false;
            }
        }else{
            start_Date[0] = startDate.substring(0,4);
            start_Date[1] = startDate.substring(4,6);
            start_Date[2] = startDate.substring(6,9);

            end_Date[0] = endDate.substring(0,4);
            end_Date[1] = endDate.substring(4,6);
            end_Date[2] = endDate.substring(6,9);
        }

        //Date 객체를 생성한다.
        var sDate = new Date(start_Date[0], start_Date[1], start_Date[2]);
        var eDate = new Date(end_Date[0], end_Date[1], end_Date[2]);

        if(sDate > eDate){
            return false;
        }

        return true;
    }


    function ShowMenu() {
        var objLeft = document.getElementById("<%=tdMenuLeft.ClientID.Replace('$','_') %>");
        var objImg = document.getElementById("<%=iBtnShowMenu.ClientID.Replace('$','_') %>");
        var objMenu = document.getElementById("<%=hdfMenuStatus.ClientID.Replace('$','_') %>");

        if (objLeft) {
            if (objLeft.style.display == "none") {
                //objImg.src = "../images/left/menu_open.gif";
                objImg.src = "../images/NHIT/leftmenu_close.gif";
                //objLeft.style.width = "16%";
                objLeft.style.display = "block";
                objMenu.value = "O";
            }
            else {
                //objImg.src = "../images/left/menu_close.gif";
                objImg.src = "../images/NHIT/leftmenu_open.gif";
                objLeft.style.display = "none";
                objMenu.value = "C";
            }
        }

        return false;
    }
</script>

<table border="0" height="100%" width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center" valign="top" height="68"><!-- 탑 시작-->
            <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" runat="server">
                <tr style="height:32px;">
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;"><!--1열-->
                            <tr>
                                <td style="width:200px; background-repeat:no-repeat;" id="tblTopMenu" runat="server"><!--로고-->
                                    <a href="javascript:GoUrl('home');">
									    <img alt="" src="../images/top/px_no.gif" width="200px" height="30px" style="border:0;" />
									</a>
                                </td>
                                <td><!--공백-->
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <table border="0" cellspacing="0" cellpadding="0" style="height:100%;"><!--로그인상태-->
                                        <tr>
                                            <td style="width:79px; background-image:url(../images/NHIT/Top_back_scoreLeft.gif); background-repeat:no-repeat; text-align:right;">
                                                &nbsp;
                                            </td>
                                            <td style="background-image:url(../images/NHIT/Top_back_scoreC.gif); background-repeat:repeat-x; text-align:right;">
                                                <table border="0" cellspacing="0" cellpadding="0" style="text-align:right; height:100%;">
                                                    <tr>
                                                        <td style="text-align:right; width:10px; padding-bottom:5px;"><img alt="" src="/images/NHIT/Icon_man.gif" style="vertical-align:middle;" /></td>
                                                        <td style="text-align:left; padding-bottom:5px;">
                                                            <span class="stext" style="font-family:dotum; font-size:11px; font-weight:bold; color:#6C6C6C; letter-spacing:-1px; padding-right:3px;">
									                            <a href="javascript:gfOpenWindow('../base/com2000.aspx',400,310,false,false);" style="color:#00A736;">
									                                <asp:Label id="lblEmpName" runat="server"></asp:Label>
									                            </a>
									                            님이 로그인 하셨습니다.
									                        </span>
                                                        </td>
                                                        <td style="width:60px; text-align:center; padding-bottom:5px;">
                                                            <a href="javascript:GoUrl('logout')">
                                                                <img src="../images/NHIT/btn_logout.gif" />
                                                            </a>
                                                        </td>
                                                        <td style="width:80px; text-align:center; padding-right:15px; padding-bottom:5px;">
                                                            <a href="javascript:gfOpenWindow('../est/EST110100M1.aspx',400,500,false,false);">
								                                <img src="../images/NHIT/Btn_score.gif" />
								                            </a>
                                                        </td>
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
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0"><!--2열-->
                            <tr>
                                <td style="width:230px; background-image:url(../images/NHIT/Logo_nhit.gif); background-position:bottom left; background-repeat:no-repeat; vertical-align:middle;"><!--실적마감율-->
                                <%--<td style="width:190px; text-align:left; padding-bottom:3px;" onclick="GoUrl('com1000');">--%>
						            <span style="font-family:dotum; font-size:11px; font-weight:bold; color:#6A93D2; letter-spacing:-1px; padding-left:20px;">
						                <ASP:LABEL id="lblFinishMonth" runat="server"></ASP:LABEL>
						                실적마감율 : 
						            </span>
						            <span style="font-family:dotum; font-size:11px; font-weight:bold; color:#A6CF00; letter-spacing:-1px;">
						                <ASP:LABEL id="lblFinishRate" runat="server"></ASP:LABEL>%
						            </span>
                                </td>
                                <td style="background-image:url(../images/NHIT/back_topmenu.gif); background-repeat:repeat-x; background-position:bottom; vertical-align:bottom;"><!--대메뉴-->
                                    <asp:Literal id="ltrTopMenu" runat="server"></asp:Literal>
                                </td>
                                <td style="background-image:url(../images/NHIT/back_topmenu.gif); background-repeat:repeat-x; background-position:bottom; text-align:right;"><!--결제함, 실적의견-->
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="text-align:right; padding-right:15px;">
                                                <a id="lnkChartPage" runat="server" visible="false" style="cursor:pointer;">
                                                    <img src="../../images/btn/btn_top_00.gif" alt="경영관리" />
                                                </a>
                                            </td>
                                            <td style="text-align:right; padding-right:15px;">
                                                <a href="/BSC/BSC0901S1.ASPX">
								                    <img alt="" id="iBtnConfirm" src="../images/NHIT/btn_top_01.gif"  runat="server" />
								                </a>
                                            </td> 
                                            <td style="text-align:right; padding-right:15px;">
                                                <a href="/BSC/BSC0706S1.ASPX">
								                    <img alt="" id="iBtnCommunication" src="../images/NHIT/btn_top_02.gif"  runat="server"  />
								                </a>
                                            </td> 
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:12px; background-image:url(../images/NHIT/back_topmenu_end.gif); background-repeat:no-repeat; background-position:bottom;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="cPageInfo_Area" runat="server">
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;"><!--3열(현재 페이지 정보)-->
                            <tr>
                                <td style="width:170px;">
                                    <asp:ImageButton ID="leftTopTitle" runat="server" Height="28px" Width="140px" ImageUrl="~/images/NHIT/leftTitle_01.gif" OnClientClick="return false;" 
                                    /><asp:ImageButton id="iBtnShowMenu" ImageUrl="~/images/NHIT/leftmenu_close.gif" runat="server" OnClientClick="return ShowMenu();" />    
                                </td>
                                <td style="padding-left:7px;">
                                    <asp:Image runat="server" ImageUrl="~/images/NHIT/bul_title.gif" ID="imgTitle" ImageAlign="AbsMiddle" Height="14px" />
                                    <span style="font-family:dotum; font-size:14px; font-weight:bold; color:#4A75CD">
                                        <ASP:LABEL id="lblTitle" runat="server" Font-Bold="true"></ASP:LABEL>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="65" colspan="2" background="/images/top/skip_1/sk_bg2.gif">
                        <table id="tblTopMenu" runat="server" width="986px" height="68" border="0" cellpadding="0" cellspacing="0" background="/images/top/skip_1/sk_bg1.old.gif">
                            <tr>
                                <td width="250" rowspan="2"><a href="javascript:GoUrl('home');"><img src="/images/top/px_no.gif" width="225" height="50" border="0"></a></td>
                                <td align="right" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="26" align="right"><img src="/images/icon/top_icon01.gif" width="9" height="11" align="absmiddle"> 
                                                <span class="stext">
                                                    <A HREF="javascript:gfOpenWindow('../base/com2000.aspx',300,310,false,false);">
                                                    [<ASP:LABEL id="lblEmpName" runat="server"></ASP:LABEL>]</A> bbb님이 로그인 하셨습니다.
                                                </span>
                                                <span class="stext"><a href="javascript:gfOpenWindow('../est/EST110100M1.aspx',400,500,false,false);"><asp:Label id="lblEstFinalFantasy" ForeColor="Red" runat="server" Text="[평가점수 확인]"></asp:Label></a></span>
                                            </td>
                                            <td width="110" align="center"><a href="javascript:GoUrl('logout')"><img src="/images/icon/top_icon02.gif" width="53" height="12" border="0" align="absmiddle"></a> </td>
                                            <td width="190" align="center" class="left_menu3" style="cursor:hand;" onclick="GoUrl('com1000')">
                                                <div id="KPI_RESULT_RATE_Tbl" runat="server">
                                                    <strong>
                                                        <font color="#FFFFFF">
                                                            <ASP:LABEL id="lblFinishMonth" runat="server"></ASP:LABEL> 실적마감율 : 
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
                                                            <a href="/BSC/BSC0901S1.ASPX"><img alt="" id="iBtnConfirm"       src="~/images/btn/top_bu_k01_b.gif"  runat="server" /></a>
                                                            <a href="/BSC/BSC0703S1.ASPX"><img alt="" id="iBtnCommunication" src="~/images/btn/top_bu_k02_b.gif"  runat="server"  /></a>
                                                        </td>
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
        </td>
    </tr>
    <tr>
        <td height="26">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="26" width="170"><asp:Image ID="leftTopTitle" runat="server" width="170" height="26" ImageUrl="~/images/left/le_c01.gif"/><br/></td>
                    <td height="26" background="/images/top/skip_1/sk_bg4.gif" align="right">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="15" height="27">&nbsp;</td>
                                <td width="25"><img src='/images/icon/mtt_icon01.gif' id="imgTitle" runat="server"></td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="250px">
                                                <strong>
                                                    <ASP:LABEL id="lblTitle" runat="server"></ASP:LABEL>
                                                </strong>
                                            </td>
                                            <td align="right">
                                                <uc1:CheckInOutControl ID="CheckInOutControl1" runat="server" /></td>
                                            <td width="50px">
                                              <img src="/images/arrow/his_back.jpg" id="img1" alt="뒤로가기"   style="cursor:hand;" onclick="siteNavigete('B');" />
                                              <img src="/images/arrow/his_fowd.jpg" id="img2" alt="앞으로가기" style="cursor:hand;" onclick="siteNavigete('F');" />
                                            </td>
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
        </td>
    </tr><!-- 탑 끝-->
    <tr style="height:100%;">
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                <tr>
                    <%--<td align="center" valign="top" width="170" background="/images/left/left_mbg1.gif" style="padding-left:3;padding-top:3">--%>
                    <td id="tdMenuLeft" runat="server" style="width:170px;" align="left"><!--width:16%-->
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;background-color:#FFFFFF">
                        <tr>
                          <td align="left" style="vertical-align: top; width: 170px;">
                            <asp:HiddenField ID="hdfMenuStatus" runat="server" Value="O" />
			                <uc2:MenuControl_Tree id="MenuControl_Tree1" runat="server" />
                          </td>
                        </tr>
                      </table>
                    </td>
                    <%--<td align="center" valign="top" width="170px">
                        <!-- 왼쪽메뉴추가 08.03.20 류승태
                        <ASP:LITERAL id="litSubMenu" runat="server"></ASP:LITERAL>
                        -->
						<uc2:MenuControl_Tree id="MenuControl_Tree1" runat="server"/>
					</td>--%>
                    <td valign="top" style="padding-left:7px; padding-right:7px; vertical-align:top;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
                            <%--<tr>
                                <td  height="4" style="width: 4px"><img src="/images/blank.gif" width="4"/><br/></td>
                            </tr>--%>
                            <tr valign="top">
                                <%--<td style="width: 4px"><img src="/images/blank.gif" width="4"></td>--%>
                                <td>