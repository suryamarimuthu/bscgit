<!------------------------------------------------------------!>
<!-- DESCRIPTION : 키보드 버튼 ASCII Code					--!>
<!------------------------------------------------------------!>
var ENTER_KEY = 13;
var ESC_KEY   = 27;
var F1_KEY    = 112;
var F2_KEY    = 113;
var F3_KEY    = 114;
var F4_KEY    = 115;
var F5_KEY    = 116;
var F6_KEY    = 117;
var F7_KEY    = 118;
var F8_KEY    = 119;
var F9_KEY    = 120;
var F10_KEY   = 121;
var F11_KEY   = 122;
var F12_KEY   = 123;
var A_KEY     = 65;
var B_KEY     = 66;
var E_KEY     = 69;
var P_KEY     = 80;
var N_KEY     = 78;
var F_KEY     = 70;
var M_KEY     = 77;
var P_KEY     = 80;
var S_KEY     = 83;
var V_KEY     = 86
var Z_KEY     = 90;
var a_KEY     = 97;
var z_KEY     = 122;

var PAD_0_KEY = 96;
var PAD_9_KEY = 105;
var NUM_0_KEY = 48;
var NUM_9_KEY = 57;
var BACK_KEY  = 8;

var PAD_MI_KEY  = 109; //마이너스
var PAD_DOT_KEY = 110; //도트

var TAB_KEY   = 9;   //tab
var PGUP_KEY  = 33;  //page up
var PGDN_KEY  = 34;  //page down
var END_KEY   = 35;  //end
var HOME_KEY  = 36;  //home
var LEFT_KEY  = 37;  //left
var UP_KEY    = 38;  //right
var RIGHT_KEY = 39;  //up
var DOWN_KEY  = 40;  //down
var INS_KEY   = 45;  //insert
var DEL_KEY   = 46;  //delete

var COL_KEY   = 186; //:
var COMMA_KEY = 188; //컴마
var MI_KEY    = 189; //마이너스
var DOT_KEY   = 190; //도트
var QUAT_KEY  = 222; //' (작은따옴표)
var HAN_KEY   = 229; //한영,한자

var SHIFT_KEY	= 16;
var CTRL_KEY	= 17;
var ALT_KEY		= 18;


// Link Define

DeployUrl = "";

home   = DeployUrl+"/base/main.aspx"; // HOME
//home   = DeployUrl+"/usr/usr2000.aspx"; // TEST HOME
login  = DeployUrl+"/base/login.aspx"; // Login
logout = DeployUrl+"/base/logout.aspx"; // Log Out
com1000 = DeployUrl+"/base/com1000.aspx"; // HOME

// Approval Process
app0000 = DeployUrl+"/app/app0000.aspx"; // HOME
app1000 = DeployUrl+"/app/app1000.aspx"; // HOME
app2000 = DeployUrl+"/app/app2000.aspx"; // HOME

// User Process
usr0000 = DeployUrl+"/usr/usr0000.aspx"; // HOME
usr1000 = DeployUrl+"/usr/usr1000.aspx"; // HOME
usr1001 = DeployUrl+"/usr/usr1001.aspx"; // HOME
usr1002 = DeployUrl+"/usr/usr1002.aspx"; // HOME
usr1003 = DeployUrl+"/usr/usr1003.aspx"; // HOME
usr1004 = DeployUrl+"/usr/usr1004.aspx"; // HOME
usr1005 = DeployUrl+"/usr/usr1005.aspx"; // 조직상황판

usr2000 = DeployUrl+"/usr/usr2000.aspx"; // HOME
usr2100 = DeployUrl+"/usr/usr2100.aspx"; // HOME
usr2001 = DeployUrl+"/usr/usr2001.aspx"; // KPI LIST
usr2002 = DeployUrl+"/usr/usr2002.aspx"; // KPI DETAIL
usr2003 = DeployUrl+"/usr/usr2003.aspx"; // KPI DETAIL DATA

usr3000 = DeployUrl+"/eis/eis0000.aspx"; // KPI MAIN
usr3001 = DeployUrl+"/eis/eis0004.aspx"; // KPI MAIN
usr3002 = DeployUrl+"/eis/eis0003.aspx"; // KPI MAIN
usr3003 = DeployUrl+"/eis/eis0002.aspx"; // KPI MAIN
usr3004 = DeployUrl+"/eis/eis0007.aspx"; // KPI MAIN
usr3005 = DeployUrl+"/eis/eis0006.aspx"; // KPI MAIN
usr3006 = DeployUrl+"/eis/eis0001.aspx"; // KPI MAIN


usr3010 = DeployUrl+"/usr/usr3010.aspx"; // KPI LIST
usr3020 = DeployUrl+"/usr/usr3020.aspx"; // KPI DETAIL
usr3030 = DeployUrl+"/usr/usr3030.aspx"; // KPI DETAIL DATA
usr3040 = DeployUrl+"/usr/usr3040.aspx"; // KPI DETAIL DATA

//usr3000 = DeployUrl+"/usr/usr3000.aspx"; // KPI MAIN
usr3100 = DeployUrl+"/usr/usr3100.aspx"; // KPI MAIN
usr3200 = DeployUrl+"/usr/usr3200.aspx"; // KPI LIST
usr3300 = DeployUrl+"/usr/usr3300.aspx"; // KPI DETAIL

usr4000 = DeployUrl+"/usr/usr4000.aspx"; // EIS Analysis

// Manager Process
svr0000 = DeployUrl+"/mgr/svr0000.aspx"; // BSC MGR::
svr1000 = DeployUrl+"/mgr/svr1000.aspx"; // BSC MGR::STG Manager
svr1001 = DeployUrl+"/mgr/svr1001.aspx"; // BSC MGR::STG Manager::CREATE
svr1002 = DeployUrl+"/mgr/svr1002.aspx"; // BSC MGR::STG Manager::MODIFY
svr1003 = DeployUrl+"/mgr/svr1003.aspx"; // BSC MGR::STG Manager::DELETE
svr1004 = DeployUrl+"/mgr/svr1004.aspx"; // BSC MGR::KPI Manager::DELETE

svr1100 = DeployUrl+"/mgr/svr1100.aspx"; // BSC MGR::STG-DEPT JOIN

svr2000 = DeployUrl+"/mgr/svr2000.aspx"; // BSC MGR::STG MAP Manager
svr2001 = DeployUrl+"/mgr/svr2001.aspx"; // BSC MGR::STG MAP Manager::CREATE
svr2002 = DeployUrl+"/mgr/svr2002.aspx"; // BSC MGR::STG MAP Manager::MODIFY
svr2003 = DeployUrl+"/mgr/svr2003.aspx"; // BSC MGR::STG MAP Manager::DELETE
svr2005 = DeployUrl+"/mgr/svr2005.aspx"; // BSC MGR::STG MAP Manager::Add Target

svr3000 = DeployUrl+"/mgr/svr3000.aspx"; // BSC MGR::KPI Manager
svr3001 = DeployUrl+"/mgr/svr3001.aspx"; // BSC MGR::KPI Manager::CREATE
svr3002 = DeployUrl+"/mgr/svr3002.aspx"; // BSC MGR::KPI Manager::MODIFY
svr3003 = DeployUrl+"/mgr/svr3003.aspx"; // BSC MGR::KPI Manager::DELETE
svr3004 = DeployUrl+"/mgr/svr3004.aspx"; // BSC MGR::KPI Manager::DELETE
svr3005 = DeployUrl+"/mgr/svr3005.aspx"; // BSC MGR::KPI Manager::SEL EMP LIST

svr3010 = DeployUrl+"/mgr/svr3010.aspx"; // BSC MGR::KPI Manager::Detail Modify
svr3020 = DeployUrl+"/mgr/svr3020.aspx"; // BSC MGR::KPI Manager::Threshold Modify
svr3030 = DeployUrl+"/mgr/svr3030.aspx"; // BSC MGR::KPI Manager::Term Modify
svr3040 = DeployUrl+"/mgr/svr3040.aspx"; // BSC MGR::KPI Manager::Target Modify

svr3100 = DeployUrl+"/mgr/svr3100.aspx"; // BSC MGR::KPI-DEPT JOIN
svr3101 = DeployUrl+"/mgr/svr3101.aspx"; // BSC MGR::KPI-DEPT JOIN::DUMMY
svr3102 = DeployUrl+"/mgr/svr3102.aspx"; // BSC MGR::KPI-DEPT JOIN::STG LIST
svr3103 = DeployUrl+"/mgr/svr3103.aspx"; // BSC MGR::KPI-DEPT JOIN::KPI LIST
svr3104 = DeployUrl+"/mgr/svr3104.aspx"; // BSC MGR::KPI-DEPT JOIN::SEL KPI LIST

svr3200 = DeployUrl+"/mgr/svr3200.aspx"; // BSC MGR::KPI-EMP JOIN
svr3201 = DeployUrl+"/mgr/svr3201.aspx"; // BSC MGR::KPI-EMP JOIN::DUMMY
svr3202 = DeployUrl+"/mgr/svr3202.aspx"; // BSC MGR::KPI-EMP JOIN::EMP LIST
svr3203 = DeployUrl+"/mgr/svr3203.aspx"; // BSC MGR::KPI-EMP JOIN::KPI LIST
svr3204 = DeployUrl+"/mgr/svr3204.aspx"; // BSC MGR::KPI-EMP JOIN::SEL KPI LIST

svr4000 = DeployUrl+"/mgr/svr4000.aspx"; // BSC MGR::KPI-DEPT-Result
svr4001 = DeployUrl+"/mgr/svr4001.aspx"; // BSC MGR::KPI-DEPT-Result::DUMMY
svr4002 = DeployUrl+"/mgr/svr4002.aspx"; // BSC MGR::KPI-DEPT-Result::MODIFY
svr4003 = DeployUrl+"/mgr/svr4003.aspx"; // BSC MGR::KPI-DEPT-Result::DELETE

svr4100 = DeployUrl+"/mgr/svr4100.aspx"; // BSC MGR::KPI-EMP-Result
svr4101 = DeployUrl+"/mgr/svr4101.aspx"; // BSC MGR::KPI-EMP-Result::DUMMY
svr4102 = DeployUrl+"/mgr/svr4102.aspx"; // BSC MGR::KPI-EMP-Result::MODIFY
svr4103 = DeployUrl+"/mgr/svr4103.aspx"; // BSC MGR::KPI-EMP-Result::DELETE

// Estimate Process
est0000 = DeployUrl+"/est/est0000.aspx"; // Estimate MGR::

est1000 = DeployUrl+"/est/est1000.aspx"; // Estimate MGR::
est1100 = DeployUrl+"/est/est1100.aspx"; // Estimate MGR::
est1200 = DeployUrl+"/est/est1200.aspx"; // Estimate MGR::
est1201 = DeployUrl+"/est/est1201.aspx"; // Estimate MGR::
est1210 = DeployUrl+"/est/est1210.aspx"; // Estimate MGR::

est1300 = DeployUrl+"/est/est1300.aspx"; // Estimate MGR::?
est1301 = DeployUrl+"/est/est1301.aspx"; // Estimate MGR::?

est1400 = DeployUrl+"/est/est1400.aspx"; // Estimate MGR::?
est1401 = DeployUrl+"/est/est1401.aspx"; // Estimate MGR::?

est2000 = DeployUrl+"/est/est2000.aspx"; // Estimate MGR::
est2100 = DeployUrl+"/est/est2100.aspx"; // Estimate MGR::
est2101 = DeployUrl+"/est/est2101.aspx"; // Estimate MGR::
est2102 = DeployUrl+"/est/est2102.aspx"; // Estimate MGR::

est2200 = DeployUrl+"/est/est2200.aspx"; // Estimate MGR::
est2300 = DeployUrl+"/est/est2300.aspx"; // Estimate MGR::
est2301 = DeployUrl+"/est/est2301.aspx"; // Estimate MGR::

est2400 = DeployUrl+"/est/est2400.aspx"; // Estimate MGR::

est3000 = DeployUrl+"/est/est3000.aspx"; // Estimate MGR::
est3100 = DeployUrl+"/est/est3100.aspx"; // Estimate MGR::
est3200 = DeployUrl+"/est/est3200.aspx"; // Estimate MGR::
est3300 = DeployUrl+"/est/est3300.aspx"; // Estimate MGR::
est3301 = DeployUrl+"/est/est3301.aspx"; // Estimate MGR::
est3400 = DeployUrl+"/est/est3400.aspx"; // Estimate MGR::

// Control Process
ctl0000 = DeployUrl+"/ctl/ctl0000.aspx"; // Control System::ORG Manager

ctl1000 = DeployUrl+"/ctl/ctl1110.aspx"; // Control System::ORG Manager

ctl1110 = DeployUrl+"/ctl/ctl1110.aspx"; // 평가 관리::기간 관리::성과 평가
ctl1120 = DeployUrl+"/ctl/ctl1120.aspx"; // 평가 관리::기간 관리::정량 평가
ctl1130 = DeployUrl+"/ctl/ctl1130.aspx"; // 평가 관리::기간 관리::정성 평가
ctl1140 = DeployUrl+"/ctl/ctl1140.aspx"; // 평가 관리::기간 관리::역량 평가
ctl1150 = DeployUrl+"/ctl/ctl1150.aspx"; // 평가 관리::기간 관리::역량 평가 조정

ctl1210 = DeployUrl+"/ctl/ctl1210.aspx"; // 평가 관리::평가 기준 관리
ctl1700 = DeployUrl+"/ctl/ctl3200.aspx"; // 평가 관리::평가 기준 관리

ctl1300 = DeployUrl+"/ctl/ctl1300.aspx"; // 평가 관리::피 평가자 관리
ctl1400 = DeployUrl+"/ctl/ctl1400.aspx"; // 평가 관리::정성 평가 질의 관리
ctl1401 = DeployUrl+"/ctl/ctl1401.aspx"; // 평가 관리::정성 평가 질의 관리
ctl1402 = DeployUrl+"/ctl/ctl1402.aspx"; // 평가 관리::정성 평가 질의 관리
ctl1404 = DeployUrl+"/ctl/ctl1404.aspx"; // 평가 관리::질의 부서 관리
ctl1500 = DeployUrl+"/ctl/ctl1500.aspx"; // 평가 관리::역량 평가 질의 관리

ctl2000 = DeployUrl+"/ctl/ctl2000.aspx"; // 조직 관리
ctl2100 = DeployUrl+"/ctl/ctl2100.aspx"; // 조직 관리::부서및 사원 관리
ctl2200 = DeployUrl+"/ctl/ctl2200.aspx"; // 조직 관리::결제선 관리
ctl2202 = DeployUrl+"/ctl/ctl2202.aspx"; // 조직 관리::결제선 관리
ctl2203 = DeployUrl+"/ctl/ctl2203.aspx"; // 조직 관리::결제선 관리
ctl2300 = DeployUrl+"/ctl/ctl2300.aspx"; // 조직 관리::평가 조직 관리

ctl3100 = DeployUrl+"/ctl/ctl3100.aspx"; // 권한 관리::시스템 권한 관리
ctl3200 = DeployUrl+"/ctl/ctl3200.aspx"; // 권한 관리::평가 권한 관리

ctl4100 = DeployUrl+"/ctl/ctl4100.aspx"; // 시스템 정보::시스템 정보
ctl4200 = DeployUrl+"/ctl/ctl4200.aspx"; // 시스템 정보::DB 정보


function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function GoUrl(name, target) {	
	if(eval(name) == "") {
			alert("준비 중 입니다.");
			return;	
		}else{
		if(target == null) {
			document.location.href = eval(name);
		}else{
			target.location.href = eval(name);
		}
	}
}

function GoUrlID(name, EID) {	
  if (eval(name) == "") {
		alert("준비 중 입니다.");
		return;	
	} else {
		document.location.href = eval(name)+"?eid="+EID;
	}
}

function winpop(name,width,height,scroll,resizable) {
    if(resizable){}else{resizable = 0;}
	if (eval(name) == "") {
		alert("준비 중 입니다.");
		return;	
	} else {
		var scheight = screen.height; 
		var scwidth = screen.width; 
		var leftpos = scwidth / 2 - width/2; 
		var toppos = scheight / 2 - height/2; 
		window.open(eval(name), 'WinPop'+name,'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars='+scroll+',resizable='+resizable+',width='+width+',height='+height+',left='+leftpos+',left='+toppos); 
	}
}

function winpopID(name,EID,width,height,scroll,resizable) {
    if(resizable){}else{resizable = 0;}
	if (eval(name) == "") {
		alert("준비 중 입니다.");
		return;	
	} else {
		var scheight = screen.height; 
		var scwidth = screen.width; 
		var leftpos = scwidth / 2 - width/2; 
		var toppos = scheight / 2 - height/2; 
		window.open(eval(name)+"?eid="+EID, 'WinPop'+name,'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars='+scroll+',resizable='+resizable+',width='+width+',height='+height+',left='+leftpos+',left='+toppos); 
	}
}


function winpopID2(name,EID,EID2,width,height,scroll,resizable) {
    if(resizable){}else{resizable = 0;}
	if (eval(name) == "") {
		alert("준비 중 입니다.");
		return;	
	} else {
		var scheight = screen.height; 
		var scwidth = screen.width; 
		var leftpos = scwidth / 2 - width/2; 
		var toppos = scheight / 2 - height/2; 
		window.open(eval(name)+"?eid="+EID+"&eid2="+EID2, 'WinPop'+name,'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars='+scroll+',resizable='+resizable+',width='+width+',height='+height+',left='+leftpos+',left='+toppos); 
	}
}

function winpoplink(name,width,height,scroll,resizable){
    if(resizable){}else{resizable = 0;}
	var scheight = screen.height; 
	var scwidth = screen.width; 
	var leftpos = scwidth / 2 - width/2; 
	var toppos = scheight / 2 - height/2; 
	window.open(name, 'WinPop'+width,'toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars='+scroll+',resizable='+resizable+',width='+width+',height='+height+',left='+leftpos+',left='+toppos); 
}

function getComponent ( id )
{
	if ( document.all )
	{
		return document.all ( id );
	}
	else if ( document.getElementById )
	{
		return document.getElementByID ( id );
	}
}


function addEscape(value)
{
        var index = -1;
        var search_key =  value;
        for (; ;)
        {
            if ((index = search_key.indexOf("'", index + 1)) != -1)
            {
                search_key1 = search_key.substring(0, ++index);
                search_key2 = search_key.substring(index, search_key.length);
                search_key = search_key1 + "'" + search_key2;
            }
            else
                break;
        }
        return search_key;
}

function isDigit(value)
{
        if (value.length== 0)
                return false;

        for (var i = 0; i < value.length; i++)
            if (value.charAt(i) < '0' || value.charAt(i) > '9')
                return false;
        return true;
}

function isVersionData(value)
{
        if (value.length == 0)
                return false;

        var firstDigit = value.substring(0,1);
        if (firstDigit < '0' || firstDigit > '9')
                return false;

        for (var i = 0; i < value.length; i++)
            if ((value.charAt(i) < '0' || value.charAt(i) > '9') && value.charAt(i) != '.')
                return false;

        var index = 0;
        if ((index = value.indexOf('.')) != -1)
        {
                major = value.substring(0, index);
                //alert('major : ' + major);
                //alert('length: ' + major.length);
                if (major.length < 1 || major.length > 4)
                        return false;
                minor = value.substring(index+1, value.length);
                if (minor.indexOf('.') != -1)
                        return false;
                //alert('minor : ' + minor);
                //alert('length: ' + minor.length);
                if (minor.length < 1 || minor.length > 2)
                        return false;
        }
        else if (value.length > 4)
        {
                return false;
        }
        return true;
}

function isAlphaNumeric(value)
{
        for (var i = 0; i < value.length; i++)
        {
                if (!((value.charAt(i) >= '0' && value.charAt(i) <= '9') ||
                      (value.charAt(i) >= 'a' && value.charAt(i) <= 'z') ||
                      (value.charAt(i) >= 'A' && value.charAt(i) <= 'Z')))
                {
                        return false;
                }

        }
        return true;
}

function isHangul(value)
{
        var temp = value;
        var len =  value.length;

        // '가'~'히'
        for (i = 0; i < len; i++)
        {
            if (!((value.charAt(i) >= '0' && value.charAt(i) <= '9') ||
                  (value.charAt(i) >= 'a' && value.charAt(i) <= 'z') ||
                  (value.charAt(i) >= 'A' && value.charAt(i) <= 'Z')) &&
                (escape(temp.charAt(i)) < '%u3131' ||
                 escape(temp.charAt(i)) > '%ud7a3'))
                {
                    return false;
                }
        }
        return true;
}

function isSpecialChar(value)
{
        var temp = value;
        var len =  value.length;
        for (i = 0; i < len; i++)
        {
            if (!((value.charAt(i) >= ' ' && value.charAt(i) <= '&') ||
                  (value.charAt(i) >= '(' && value.charAt(i) <= '@') ||
                  (value.charAt(i) >= '[' && value.charAt(i) <= '`') ||
                  (value.charAt(i) >= '{' && value.charAt(i) <= '~')))
            {
                return false;
            }
        }
        return true;
}

function isAllowChar(value)
{
        var temp = value;
        var len =  value.length;
        for (i = 0; i < len; i++)
        {
            if (!((value.charAt(i) >= '0' && value.charAt(i) <= '9') ||
                  (value.charAt(i) >= 'a' && value.charAt(i) <= 'z') ||
                  (value.charAt(i) >= 'A' && value.charAt(i) <= 'Z')) &&
                (escape(temp.charAt(i)) < '%u3131' ||
                 escape(temp.charAt(i)) > '%ud7a3') &&
                !((value.charAt(i) >= ' ' && value.charAt(i) <= '&') ||
                  (value.charAt(i) >= '(' && value.charAt(i) <= '@') ||
                  (value.charAt(i) >= '[' && value.charAt(i) <= '`') ||
                  (value.charAt(i) >= '{' && value.charAt(i) <= '~')))
                {
                    return false;
                }
        }
        return true;
}

function isValidFirstChar(value)
{
        /* 아이디의 첫글자 확인 */
        var firstChar =  value.substring(0,1);
        if (!((firstChar >= 'a' && firstChar <= 'z') ||
              (firstChar >= 'A' && firstChar <= 'Z')))
        {
                return false;
        }
        return true;
}

String.prototype.trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

function isEmpty ( string )
{
	if ( ( string == null )
		|| ( string.trim() == "" ) 
		|| ( string == "null" ) )
	{
		return true;
	}
	return false;
}

function getDateYearOption()
{
	var sDate = new Date(); 
	var sCurYear = sDate.getFullYear(); 

	for(var i =(sCurYear-10);i<(sCurYear+2);i++){
		document.write("<option");
		if(i == sCurYear){
			document.write(" selected");
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
}

function getDateSel(HeadName)
{
	getDateSelS(HeadName, 0, '', '', '');
}

function flashScript(src, w, h)
{
	html = '';
	html += '<object type="application/x-shockwave-flash" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" id="param" width="' + w + '" height="' + h + '">';
	html += '<param name="movie" value="' + src + '">';
	html += '<param name="quality" value="high">';
	html += '<param name="bgcolor" value="#ffffff">';
	html += '<param name="menu" value="false">';
	html += '<param name=wmode value="transparent">';
	html += '<param name="swliveconnect" value="true">';
	html += '<embed src="' + src + '" quality=high bgcolor="#ffffff" menu="false" width="' + w + '" height="' + h + '" swliveconnect="true" id="param" name="param" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer"><\/embed>';
	html += '<\/object>';
	document.write(html);
}

function getDateYear(HeadName, fselYearName, baseVal, selVal, fselMonthName, fselDayName0, fselDayName1, fselDayName2, fselDayName3)
{
	var check=0;
	document.write("<select name='"+fselYearName+"' id='"+fselYearName+"' class=input onChange='selYearObj("+HeadName+", "+fselYearName+", "+fselMonthName+", "+fselDayName0+", "+fselDayName1+", "+fselDayName2+", "+fselDayName3+");'>");
	for(var i =(baseVal-10);i<(baseVal+2);i++){
		document.write("<option");
		if(i == selVal && check==0){
			document.write(" selected");
 			check=1;
		}else if(i == baseVal && check==0){
			document.write(" selected");
 			check=1;
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
	document.write("</select>");
}

function getDateMonth(HeadName, fselMonthName, baseVal, selVal, fselYearName, fselDayName0, fselDayName1, fselDayName2, fselDayName3)
{
	var check=0;
	document.write("<select name='"+fselMonthName+"' id='"+fselMonthName+"' class=input onChange='selMonObj("+HeadName+", "+fselYearName+", "+fselMonthName+", "+fselDayName0+", "+fselDayName1+", "+fselDayName2+", "+fselDayName3+");'>");
	for(var i =1;i<13;i++){
		document.write("<option");
		if(i == selVal && check==0){
			document.write(" selected");
 			check=1;
		}else if(i == baseVal && check==0){
			document.write(" selected");
 			check=1;
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
	document.write("</select>");
}

function getDateDay(HeadName, fselDayName0, fselDayName1, fselDayName2, fselDayName3, baseVal, selVal, fselYearName, fselMonthName)
{
	var check=0;

	document.write("<select name='"+fselDayName0+"' id='"+fselDayName0+"' class=hidden onChange='selDayObj("+HeadName+", "+fselYearName+", "+fselMonthName+", "+fselDayName0+", "+fselDayName1+", "+fselDayName2+", "+fselDayName3+");'>");
	for(var i =1;i<=28;i++){
		document.write("<option");
		if(i == selVal && check==0){
			document.write(" selected");
 			check=1;
		}else if(i == baseVal && check==0){
			document.write(" selected");
 			check=1;
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
	document.write("</select>");

	check=0;
	document.write("<select name='"+fselDayName1+"' id='"+fselDayName1+"' class=hidden onChange='selDayObj("+HeadName+", "+fselYearName+", "+fselMonthName+", "+fselDayName0+", "+fselDayName1+", "+fselDayName2+", "+fselDayName3+");'>");
	for(var i =1;i<=29;i++){
		document.write("<option");
		if(i == selVal && check==0){
			document.write(" selected");
 			check=1;
		}else if(i == baseVal && check==0){
			document.write(" selected");
 			check=1;
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
	document.write("</select>");

	check=0;
	document.write("<select name='"+fselDayName2+"' id='"+fselDayName2+"' class=hidden onChange='selDayObj("+HeadName+", "+fselYearName+", "+fselMonthName+", "+fselDayName0+", "+fselDayName1+", "+fselDayName2+", "+fselDayName3+");'>");
	for(var i =1;i<=30;i++){
		document.write("<option");
		if(i == selVal && check==0){
			document.write(" selected");
 			check=1;
		}else if(i == baseVal && check==0){
			document.write(" selected");
 			check=1;
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
	document.write("</select>");

	check=0;
	document.write("<select name='"+fselDayName3+"' id='"+fselDayName3+"' class=hidden onChange='selDayObj("+HeadName+", "+fselYearName+", "+fselMonthName+", "+fselDayName0+", "+fselDayName1+", "+fselDayName2+", "+fselDayName3+");'>");
	for(var i =1;i<=31;i++){
		document.write("<option");
		if(i == selVal && check==0){
			document.write(" selected");
 			check=1;
		}else if(i == baseVal && check==0){
			document.write(" selected");
 			check=1;
		}
		document.write(" value='");
		document.write(i);
		document.write("'>"+i+"</option>");
	}
	document.write("</select>");
}


function getDateSelS(HeadName, depth, selYearVal, selMonthVal, selDayVal)
{
	var sDate = new Date(); 
	var sCurYear = sDate.getFullYear(); 
	var sCurMonth = sDate.getMonth()+1; 
	var sCurDayOfMonth = sDate.getDate(); 

	var fselYearName	= "year_" + depth;
	var fselMonthName	= "month_" + depth;
	var fselDayName0	= "day0_" + depth;
	var fselDayName1	= "day1_" + depth;
	var fselDayName2	= "day2_" + depth;
	var fselDayName3	= "day3_" + depth;

	document.write("<table cellpadding=0 cellspacing=0 border=0>");
	document.write("<tr><td>");
	getDateYear(HeadName, fselYearName, sCurYear, selYearVal, fselMonthName, fselDayName0, fselDayName1, fselDayName2, fselDayName3);
	document.write("년</td><td>");
	getDateMonth(HeadName, fselMonthName, sCurMonth, selMonthVal, fselYearName, fselDayName0, fselDayName1, fselDayName2, fselDayName3);
	document.write("월</td><td>");
	getDateDay(HeadName, fselDayName0, fselDayName1, fselDayName2, fselDayName3, sCurDayOfMonth, selDayVal, fselYearName, fselMonthName);
	document.write("</td><td>일");
	document.write("</td></tr>");
	document.write("<input type='hidden' name='"+HeadName+"' value=''>");
	document.write("</table>");

	var fselYearObj	 = getComponent ( fselYearName );
	var fselMonthObj = getComponent ( fselMonthName );
	var fselDay0Obj	 = getComponent ( fselDayName0 );
	var fselDay1Obj	 = getComponent ( fselDayName1 );
	var fselDay2Obj	 = getComponent ( fselDayName2 );
	var fselDay3Obj	 = getComponent ( fselDayName3 );
	var HeadNameObj	 = getComponent ( HeadName );

	fselDay0Obj.className='hidden';
	fselDay1Obj.className='hidden';
	fselDay2Obj.className='hidden';
	fselDay3Obj.className='hidden';

	var checkDataVal = "";

	if(!isEmpty(selYearVal)){
		checkDataVal = checkDataVal+selYearVal+"";
		if(selMonthVal < 10)
			checkDataVal = checkDataVal+"0"+selMonthVal+"";
		else	
			checkDataVal = checkDataVal+selMonthVal+"";

		if(selDayVal < 10)
			checkDataVal = checkDataVal+"0"+selDayVal;
		else	
			checkDataVal = checkDataVal+selDayVal;
		
		if(selMonthVal == 2){
			if(((selYearVal % 4 == 0) && (selYearVal % 100 != 0)) || (selYearVal % 400 == 0)){
				fselDay1Obj.className='shown';
			}else{
				fselDay0Obj.className='shown';
			}
		}else if((selMonthVal == 4) ||(selMonthVal == 6) ||(selMonthVal == 9) ||(selMonthVal == 11)){
			fselDay2Obj.className='shown';
		}else{
			fselDay3Obj.className='shown';
		}
	}else{
		checkDataVal = checkDataVal+sCurYear+"";
		if(sCurMonth < 10)
			checkDataVal = checkDataVal+"0"+sCurMonth+"";
		else	
			checkDataVal = checkDataVal+sCurMonth+"";

		if(sCurDayOfMonth < 10)
			checkDataVal = checkDataVal+"0"+sCurDayOfMonth;
		else	
			checkDataVal = checkDataVal+sCurDayOfMonth;

		if(sCurMonth+1 == 2){
			if(((sCurYear % 4 == 0) && (sCurYear % 100 != 0)) || (sCurYear % 400 == 0)){
				fselDay1Obj.className='shown';
			}else{
				fselDay0Obj.className='shown';
			}
		}else if((sCurMonth == 4) ||(sCurMonth == 6) ||(sCurMonth == 9) ||(sCurMonth == 11)){
			fselDay2Obj.className='shown';
		}else{
			fselDay3Obj.className='shown';
		}
	}
	HeadNameObj.value=checkDataVal;
}

function selYearObj(HeadName, fselYearObj, fselMonthObj, fselDay0Obj, fselDay1Obj, fselDay2Obj, fselDay3Obj){
	var fselYearVal = fselYearObj.options[fselYearObj.selectedIndex].value;
	var fselVal = fselMonthObj.options[fselMonthObj.selectedIndex].value;

	var checkDataVal = "";
	checkDataVal = checkDataVal+fselYearVal+"";

	if(fselVal < 10)
		checkDataVal = checkDataVal+"0"+fselVal+"";
	else	
		checkDataVal = checkDataVal+fselVal+"";

	if(fselVal == 2){
		if(((fselYearVal % 4 == 0) && (fselYearVal % 100 != 0)) || (fselYearVal % 400 == 0)){
			checkDataVal = checkDataVal+fselDay1Obj.options[fselDay1Obj.selectedIndex].value;
		}else{
			checkDataVal = checkDataVal+fselDay0Obj.options[fselDay0Obj.selectedIndex].value;
		}
	}else if((fselVal == 4) ||(fselVal == 6) ||(fselVal == 9) ||(fselVal == 11)){
		checkDataVal = checkDataVal+fselDay2Obj.options[fselDay2Obj.selectedIndex].value;
	}else{
		checkDataVal = checkDataVal+fselDay3Obj.options[fselDay3Obj.selectedIndex].value;
	}

	HeadName.value=checkDataVal;
}

function selDayObj(HeadName, fselYearObj, fselMonthObj, fselDay0Obj, fselDay1Obj, fselDay2Obj, fselDay3Obj){
	var fselYearVal = fselYearObj.options[fselYearObj.selectedIndex].value;
	var fselVal = fselMonthObj.options[fselMonthObj.selectedIndex].value;

	var checkDataVal = "";
	checkDataVal = checkDataVal+fselYearVal+"";

	if(fselVal < 10)
		checkDataVal = checkDataVal+"0"+fselVal+"";
	else	
		checkDataVal = checkDataVal+fselVal+"";

	if(fselVal == 2){
		if(((fselYearVal % 4 == 0) && (fselYearVal % 100 != 0)) || (fselYearVal % 400 == 0)){
			checkDataVal = checkDataVal+fselDay1Obj.options[fselDay1Obj.selectedIndex].value;
		}else{
			checkDataVal = checkDataVal+fselDay0Obj.options[fselDay0Obj.selectedIndex].value;
		}
	}else if((fselVal == 4) ||(fselVal == 6) ||(fselVal == 9) ||(fselVal == 11)){
		checkDataVal = checkDataVal+fselDay2Obj.options[fselDay2Obj.selectedIndex].value;
	}else{
		checkDataVal = checkDataVal+fselDay3Obj.options[fselDay3Obj.selectedIndex].value;
	}

	HeadName.value=checkDataVal;
}

function selMonObj(HeadName, fselYearObj, fselMonthObj, fselDay0Obj, fselDay1Obj, fselDay2Obj, fselDay3Obj){
	
	var fselYearVal = fselYearObj.options[fselYearObj.selectedIndex].value;
	var fselVal = fselMonthObj.options[fselMonthObj.selectedIndex].value;
	
	var checkDataVal = "";

	fselDay0Obj.className='hidden';
	fselDay1Obj.className='hidden';
	fselDay2Obj.className='hidden';
	fselDay3Obj.className='hidden';

	checkDataVal = checkDataVal+fselYearVal+"";

	if(fselVal < 10)
		checkDataVal = checkDataVal+"0"+fselVal+"";
	else	
		checkDataVal = checkDataVal+fselVal+"";

	if(fselVal == 2){
		if(((fselYearVal % 4 == 0) && (fselYearVal % 100 != 0)) || (fselYearVal % 400 == 0)){
			fselDay1Obj.className='shown';
			checkDataVal = checkDataVal+fselDay1Obj.options[fselDay1Obj.selectedIndex].value;
		}else{
			fselDay0Obj.className='shown';
			checkDataVal = checkDataVal+fselDay0Obj.options[fselDay0Obj.selectedIndex].value;
		}
	}else if((fselVal == 4) ||(fselVal == 6) ||(fselVal == 9) ||(fselVal == 11)){
		fselDay2Obj.className='shown';
		checkDataVal = checkDataVal+fselDay2Obj.options[fselDay2Obj.selectedIndex].value;
	}else{
		fselDay3Obj.className='shown';
		checkDataVal = checkDataVal+fselDay3Obj.options[fselDay3Obj.selectedIndex].value;
	}

	HeadName.value=checkDataVal;
}

// 작성 : 이승주 (2006.04.17)
function commaSplit(srcNumber) 
{

	var txtNumber = '' + srcNumber;
	var txtNumber_1 = Number(txtNumber.replace(',',''));
	if (isNaN(txtNumber_1) || txtNumber_1 == "") 
	{
		//alert("숫자만 입력 하세요");
		return 0;
	}
	else 
	{
		txtNumber = String(txtNumber).replace(',','');
		//txtNumber = String(Double(txtNumber));
		var rxSplit = new RegExp('([0-9])([0-9][0-9][0-9][,.])');
		var arrNumber = txtNumber.split('.');
		arrNumber[0] += '.';
		do {
			arrNumber[0] = arrNumber[0].replace(rxSplit, '$1,$2');
		} while (rxSplit.test(arrNumber[0]));
		if (arrNumber.length > 1) 
		{
			return arrNumber.join('');
		}
		else 
		{
			return arrNumber[0].split('.')[0];
	    }
	}
}

// 윈도우 오픈시 윈타입 리턴함수 (강신규)
function gfRetWinType(aiWidth, aiHeight)
{
    var argv = gfRetWinType.arguments;
	var argc = argv.length;
	
	var sScroll = "no";
	var sResize = "no";
	
	var bScroll = false;
	var bResize = false;
	
//	alert('argc : ' + argc);
//	alert(argv[2] + '_' + argv[3]);
	
	if (argc >= 3) bScroll = argv[2];
	if (argc >= 4) bResize = argv[3];
	
	//alert(bScroll + ' ' + bResize);
	//alert(sScroll + ' ' + sResize);
	
//	(bScroll ? sScroll = "yes" : sScroll = "no");
//	(bResize ? sResize = "yes" : sResize = "no");

    if(bScroll == "yes") 
    {
        sScroll = "yes";
    }
    
    if(bResize == "yes")
    {
        sResize = "yes";
    }
	
	//alert(sScroll + ' ' + sResize);
	
	var topValue = (((screen.height - aiHeight) / 2) - 50);
	
	if (topValue < 0)
	    topValue = 0;
	    
    var argString = "width=" + aiWidth + "px,height=" + aiHeight + "px,left=" + ((screen.width - aiWidth) / 2) + ", top=" + topValue + ",scrollbars=" + sScroll + ",resizable=" + sResize;
    
    //alert(argString);

	return argString;
}

function gfRetDialogType(aiWidth, aiHeight)
{
    var argv = gfRetDialogType.arguments;
    var argc = argv.length;
	
    var sScroll = "no";
    var sResize = "no";
	
    var bScroll = false;
    var bResize = false;
	
    if (argc >= 3) bScroll = argv[2];
    if (argc >= 4) bResize = argv[3];
	
    (bScroll ? sScroll = "yes" : sScroll = "no");
    (bResize ? sResize = "yes" : sResize = "no");

    return "dialogWidth=" + aiWidth + "px;dialogHeight=" + aiHeight + "px;status=no;center:yes;scrollbars=" + sScroll + ";resizable=" + sResize ;
}

function gfOpenDialog(psForm, psaArg, piWidth, piHeight)
 {
    var iWidth = 300;
    var iHeight= 400;
	
    var bScroll = false;
    var bResize = false;
	
    var argv = gfOpenDialog.arguments;
    var argc = argv.length;
    var sForm= argv[0];
	
    iWidth = piWidth;
    iHeight= piHeight;
	
    if (argc >= 5) bScroll= argv[4];
    if (argc >= 6) bResize= argv[5];

    return window.showModalDialog(sForm, psaArg, gfRetDialogType(iWidth, iHeight, bScroll, bResize));
 }


var mWin;
/*
    gfOpenWindow (주소URL, Optional int width, Optional int Height, Optional bool 스크롤여부, Optional bool 리사이즈여부)
    : 윈도우오픈 (강신규)
*/
function gfOpenWindow()
{
    var iWidth = 300;
    var iHeight= 400;
	
    var bScroll = false, bResize = false;
    var sWinName= "";
    
    //alert(location.href);
	
    var argv = gfOpenWindow.arguments;
    var argc = argv.length;
    var sForm= argv[0];
	
    if (argc >= 2) iWidth = argv[1];
    if (argc >= 3) iHeight= argv[2];
    if (argc >= 4) bScroll= argv[3];
    if (argc >= 5) bResize= argv[4];
    if (argc >= 6) sWinName = argv[5];
	
    if (sWinName == "")
    {
        try
        {
            mWin.focus();
            mWin.navigate(sForm);
        }
        catch(e)
        {
            mWin = window.open(sForm, null, gfRetWinType(iWidth, iHeight, bScroll, bResize));
        }
    }
    else
    {
        var oWin = window.open(sForm, sWinName, gfRetWinType(iWidth, iHeight, bScroll, bResize));
        oWin.focus();
    }
}

function gfWinFocus()
{
    // 팝업창일때 처음열릴경우 뒤로 숨는부분 수정
    if (opener)
    {
        var orgOpener = opener;
        opener=self; 
        window.focus();
        
        opener = orgOpener;
    }
}

// 페이지 내부 및 페이지에 포함된 document에서 객체찾아 리턴	(강신규)
// 사용례 : var obj = gfGetFindObj("ibtnSearch")
function gfGetFindObj(aObjName, aDoc) 
{
	var liParent, lli, loRet, loDoc;
	if(!aDoc) aDoc=document; 
	
	loDoc = aDoc; 
	
	try
	{
	    if(
	        (liParent=aObjName.indexOf("?")) > 0 &&
	        parent.frames.length
	      ) 
	    {
		    loDoc       = parent.frames[aObjName.substring(liParent+1)].document; 
		    aObjName    = aObjName.substring(0,liParent);
	    }
    	
	    // 페이지내부 찾기
	    if(!(loRet=loDoc[aObjName])&&loDoc.all) 
		    loRet=loDoc.all[aObjName]; 
    	
	    // 페이지내의 iframe내부에서 찾기
	    for (i=0; (!loRet && i<loDoc.frames.length); i++) 
		    loRet = loDoc.frames[i].document.all[aObjName];
    	
	    // 폼 내부 찾기
	    for (i=0; (!loRet && i<loDoc.forms.length); i++) 
		    loRet=loDoc.forms[i][aObjName];
    	
	    // 각 레이어에서 찾기
	    for(i=0; (!loRet && loDoc.layers && i<loDoc.layers.length); i++) 
		    loRet = MM_findObj(aObjName,loDoc.layers[i].document);
        
        if(
	        !loRet && 
	        document.getElementById
	      ) 
		    loRet=document.getElementById(aObjName);
	}
	catch(e){}; 
	
	return loRet;
}

<!----------------------------------------------------------------------------!>
<!-- 함 수 명 : gfGetSelect()											    --!>
<!-- 설    명 :	SelectBox에서 선택된 값을 가져옴                            --!>
<!-- 전달인수 : oSelect : SelectBox id명칭                                  --!>
<!-- 작성일자 : 2006.03.09 (강신규)                                         --!>
<!-- 반 환 값 : None                                                        --!>
<!----------------------------------------------------------------------------!>      
function gfGetSelect(oSelect)
{
    var sReturn = "";
    
    try
    {
        if (oSelect.type.indexOf("select") >= 0)
        {
            for (var i=0; oSelect.options.length; i++)
            {
                if (oSelect.options[i].selected == true)
                {
                    sReturn = oSelect.options[i].value;
                    break;
                }
            }
        }
    }
    catch (e){}
    
    return sReturn;
}  

function gfGetRadio(sRadio)
{
    var sReturn = "";
    var oRadio = gfGetFindObj(sRadio);
    
    if (oRadio)
    {
        if (oRadio.length != undefined)
        {
            
            for (var i=0; i<oRadio.length; i++)
            {
                if (oRadio[i].tagName.toUpperCase() == "INPUT")
                {
                    if (oRadio[i].type.indexOf("radio") >= 0)
                    {
                        if (oRadio[i].checked)
                        {
                            sReturn = oRadio[i].value;
                            break;
                        }
                    }
                }
            }
        }
    }
    
    return sReturn;
}

function selSTGlist(estterm_ref_id, est_dept_ref_id, stg_ref_id, tmcode)
{
    if(window.parent.parent.name=="score") 
    {
        if(opener)
        {
            opener.location.href="../BSC/BSC0406S3.aspx?ESTTERM_REF_ID="      + estterm_ref_id 
                                                        + "&EST_DEPT_REF_ID=" + est_dept_ref_id 
                                                        + "&STG_REF_ID="      + stg_ref_id
                                                        + "&YMD="             + tmcode;
            
            window.close();
        }
        else 
        {
            window.parent.document.location.href="../BSC/BSC0406S3.aspx?ESTTERM_REF_ID="  + estterm_ref_id 
                                                                    + "&EST_DEPT_REF_ID=" + est_dept_ref_id 
                                                                    + "&STG_REF_ID="      + stg_ref_id
                                                                    + "&YMD="             + tmcode;
        }
    }
    else 
    {
        if(opener)
        {
            opener.location.href="../BSC/BSC0406S3.aspx?ESTTERM_REF_ID=" + estterm_ref_id 
                                                 + "&EST_DEPT_REF_ID="   + est_dept_ref_id 
                                                 + "&STG_REF_ID="        + stg_ref_id
                                                 + "&YMD="               + tmcode;
            
            window.close();
        }
        else 
        {
            window.parent.document.location.href="../BSC/BSC0406S3.aspx?ESTTERM_REF_ID=" + estterm_ref_id 
                                                            + "&EST_DEPT_REF_ID="        + est_dept_ref_id 
                                                            + "&STG_REF_ID="             + stg_ref_id
                                                            + "&YMD="                    + tmcode;
        }                                                                    
    }
}
    
function selKPIlist(estterm_ref_id, kpi_ref_id, tmcode)
{
    if(parent.parent.window.name=="score") 
    {
        if(opener)
        {
            opener.location.href="../BSC/BSC0304S2.aspx?ESTTERM_REF_ID="    + estterm_ref_id 
                                                    + "&KPI_REF_ID="        + kpi_ref_id
                                                    + "&YMD="               + tmcode;
            
            window.close();
        }
        else 
        {
            window.parent.document.location.href="../BSC/BSC0304S2.aspx?ESTTERM_REF_ID="    + estterm_ref_id 
                                                                        + "&KPI_REF_ID="    + kpi_ref_id
                                                                        + "&YMD="           + tmcode;
        }                                                                        
    }
    else
    {
        if(opener)
        {
            opener.location.href="../BSC/BSC0304S2.aspx?ESTTERM_REF_ID="    + estterm_ref_id 
                                                         + "&KPI_REF_ID="   + kpi_ref_id
                                                         + "&YMD="          + tmcode;
                                                      
            window.close();
        }
        else 
        {
            window.parent.document.location.href="../BSC/BSC0304S2.aspx?ESTTERM_REF_ID="        + estterm_ref_id 
                                                                            + "&KPI_REF_ID="    + kpi_ref_id
                                                                            + "&YMD="           + tmcode;
        }
    }
}   

function trim(strIn)
{
	var strOut = "";

	if (strIn)
		strOut = strIn.replace(/^\s*/,'').replace(/\s*$/, ''); 
	
	return strOut;
}

function viewPopUp(stgMapLink, kpiLink, drillDownLink, scoreLink)
{
    alert(scoreLink);
	// 사용 구분 선택
	var objStgMap 	    = document.getElementById ("trStgMap");
	var objKpi 	        = document.getElementById ("trKpi"); 
	var objScore        = document.getElementById ("trScore"); 
	var objDrillDown 	= document.getElementById ("trDrillDown"); 
	
	if (trim(stgMapLink) == '')
	{
		objStgMap.style.display = "none";
	}
	else
	{
	    objStgMap.style.display = "block";
		var lnkStgMap 	        = document.getElementById ("lnkStgMap");
		lnkStgMap.href          = stgMapLink;
	}
	
	if (trim(kpiLink) == '')
	{
		objKpi.style.display = "none";
	}
	else
	{
	    objKpi.style.display = "block";
		var lnkKpi 	         = document.getElementById ("lnkKpi");
		lnkKpi.href          = kpiLink;
	}
	
	if (trim(drillDownLink) == '')
	{
		objDrillDown.style.display = "none";
	}
	else
	{
	    objDrillDown.style.display  = "block";
		var lnkDrillDown 	        = document.getElementById ("lnkDrillDown"); 
		lnkDrillDown.href 	        = drillDownLink;
	}
	
	if (trim(scoreLink) == '')
	{
		objScore.style.display = "none";
	}
	else
	{
	    objScore.style.display = "block";
		var lnkScore 	       = document.getElementById ("lnkScore");
		lnkScore.href          = scoreLink;
	}

	var x, y;
	
	// 마우스 위치 확인
	x = (document.layers) ? loc.pageX : event.clientX;
	y = (document.layers) ? loc.pageY : event.clientY;
	
	// 스크롤 영역 보정
	x = document.body.scrollLeft + x;
	y = document.body.scrollTop + y;
	
	var objNamePopUp = document.getElementById("divPopUp");
	
	if (objNamePopUp)
	{
		objNamePopUp.style.pixelTop		= y - 10;
		objNamePopUp.style.pixelLeft 	= x + 15;
		//objNamePopUp.style.display 		= (objNamePopUp.style.display == "block") ? "none" : "block";
		objNamePopUp.style.display 		= "block";
	}
}

function zoom(pobj, dobj, iw)
{
    var hh=0;
    if(pobj!=null)
        ww=pobj.Width/iw;
    else
        ww=window.screen.Width/iw;
        
    dobj.style.zoom=ww;
}

function zoomin(pobj, obj)
{
    if(pobj!=null) 
        obj.style.zoom='140%';
    else
        obj.style.zoom='120%';
}

function zoomout(obj)
{
    obj.style.zoom='normal';
}

<!----------------------------------------------------------------------------!>
<!-- 함 수 명 : gfSetFocus()											    --!>
<!-- 설    명 :	해당컨트롤에 포커스                                         --!>
<!-- 전달인수 : oSelect : SelectBox id명칭                                  --!>
<!-- 작성일자 : 2006.06.09 (강신규)                                         --!>
<!-- 반 환 값 : None                                                        --!>
<!----------------------------------------------------------------------------!>
function gfSetFocus(sObj)
{
    var obj = gfGetFindObj(sObj);
    
    try
    {
        if (obj)
        {
            obj.select();
            obj.focus();
        }
    }
    catch (e) {}
}

// 숫자만 입력중 연속된 숫자가 일정갯수 넘지 않도록
// iPrevChk = -1 무한, >0 숫자제한
// iPostChk = -1 무한, >0 숫자제한
function gfChkInputNum()
{
    //debugger;
    var argv = gfChkInputNum.arguments;
    var argc = argv.length;
    var iPrevChk = argv[0];
    var iPostChk = argv[1];
    
    var iPoint = 0;
    
    if (isNaN(iPrevChk)) iPrevChk = -1;
    if (isNaN(iPostChk)) iPostChk = -1;
    
    var oSource = event.srcElement;
    msPrev = oSource.value;
    
    // 소수점 까지의 위치정보
    iPoint = oSource.value.indexOf(".") + 1;
    
    
    if (
        (event.keyCode < NUM_0_KEY) ||
        (event.keyCode > PAD_9_KEY) ||
        (event.keyCode > NUM_9_KEY && event.keyCode < PAD_0_KEY) 
       )
    {
        switch(event.keyCode)
        {
            case MI_KEY:
            case PAD_MI_KEY :
                
                if (oSource.value.indexOf("-") == -1)
                {
                    var prevValue = oSource.value;
        
                    oSource.onkeyup = function ()
                    {	
                        var miPrev = oSource.value.substring(0, oSource.value.indexOf("-"));
                        
                        if (miPrev != "")
                            oSource.value = prevValue;
                    }
                }
                else
                    event.returnValue = false;
                

                break;
            case BACK_KEY	:
            case DEL_KEY	:
                break;
            case LEFT_KEY	:
            case RIGHT_KEY	:
            case END_KEY	:
            case HOME_KEY	:
            case SHIFT_KEY	:
            case CTRL_KEY	:
            case ALT_KEY	:
            case ENTER_KEY	:
            case TAB_KEY	:
                break;
            case PAD_DOT_KEY:
            case DOT_KEY	:
                if (iPostChk != 0)
                {
                    if (oSource.value.length >= 1)
                    {
                        if (oSource.value.indexOf(".") == -1)
                        {
                            var prevValue = oSource.value;
                
                            oSource.onkeyup = function ()
                            {	
                                var miPrev = oSource.value.substring(0, oSource.value.indexOf("."));
                                

                                if (miPrev == "-")
                                    oSource.value = prevValue;
                            }
                        }
                        else
                            event.returnValue = false;

                    }
                    else
                        event.returnValue = false;
                }

                break;
            default:
                event.returnValue = false;
                break;
        }
        return;	
    
        
    }
    else
    {
        // 소수점이상이 0이면 입력은 없다.
        if (iPrevChk == 0)
        {
            event.returnValue = false;
            return;
        }
        
        if (iPrevChk > 0)
        {
            var chkPrev = oSource.value.replace("-", "");

            if (chkPrev.length >= iPrevChk)
            {
                if (chkPrev.indexOf(".") == -1)
                {
                    event.returnValue = false;
                    return;
                }
            }
        }
        
        var prevValue = oSource.value;
        
        oSource.onkeyup = function ()
        {	
            var pointPrev = oSource.value.substring(0, oSource.value.indexOf("."));
            var pointPost = oSource.value.substring(oSource.value.indexOf(".")+1);
            
            if (iPrevChk != -1) 
            {
                if (pointPrev.substring(0,1) == "-")
                    pointPrev = pointPrev.substring(0, iPrevChk+1);
                else
                    pointPrev = pointPrev.substring(0, iPrevChk);
            }

            if (iPostChk != -1) pointPost = pointPost.substring(0, iPostChk);
            
            if (
                ((oSource.value.length - (oSource.value.length-iPoint+1)) >= iPrevChk && iPoint > 0) &&
                ((oSource.value.length-iPoint) >= iPostChk && iPoint > 0)
               )
            {
                if (iPrevChk == -1 && iPostChk == -1)
                {
                    return true;
                }
                else if (iPrevChk == -1)
                {
                    // 소숫점뒤 검사
                    if (oSource.value.indexOf(".") != -1)
                    {
                        if (oSource.value.substring(oSource.value.indexOf(".")+1).length <= iPostChk)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (iPostChk == -1)
                {
                    // 소숫점앞 검사
                    if (oSource.value.indexOf(".") != -1)
                    {
                        if (oSource.value.substring(0, oSource.value.indexOf(".")).length <= iPrevChk)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (oSource.value.length <= iPrevChk)
                        {
                            return true;
                        }
                    }
                }
                
                oSource.value = pointPrev + "." + pointPost;
            }
        }
    }
    
    
}

// 숫자만 입력되도록 함(순수숫자).  (onkeydown 이벤트 강신규)
function gfChkInputNum_Std()
{
	if (
		(event.keyCode < NUM_0_KEY) ||
		(event.keyCode > PAD_9_KEY) ||
		(event.keyCode > NUM_9_KEY && event.keyCode < PAD_0_KEY)
	   )
	{
		var oSource = event.srcElement;
		
		switch(event.keyCode)
		{
			case BACK_KEY	:
			case DEL_KEY	:
			case LEFT_KEY	:
			case RIGHT_KEY	:
			case END_KEY	:
			case HOME_KEY	:
			case SHIFT_KEY	:
			case CTRL_KEY	:
			case ALT_KEY	:
			case ENTER_KEY	:
			case TAB_KEY	:
			    break;
			default:
			    event.returnValue = false;
				break;
		}
		
		return;				
	}
}

<!----------------------------------------------------------------------------!>
<!-- 함 수 명 : gfCloseWindow()										        --!>
<!-- 설    명 :	현재윈도우를 닫는다.                                        --!>
<!-- 전달인수 : asConfirm : 해당인수가 있다면 해당문자열로 물어본후 닫는다. --!>
<!-- 작성일자 : 2006.03.08 (강신규)                                         --!>
<!-- 반 환 값 : None                                                        --!>
<!----------------------------------------------------------------------------!>
function gfCloseWindow()
{
    var argv = gfCloseWindow.arguments;
	var argc = argv.length;
	
	if (argc >= 1) 
	    if (!confirm(argv[0])) return false;
	
    opener = self;
    window.close();
}

function gfReload()
{
    location.reload();
}

// Client확인이 필요한 서버객체 처리함수 (강신규)
function gfConfirmWait(obj, asMsg)
{
	if (confirm(asMsg))
	{
		obj.setAttribute("value","Please Wait...");  
		document.body.style.cursor="wait"; 
		return true;
	}
	
	return false;
}

<!----------------------------------------------------------------------------!>
<!-- 용    도 : UltraWebGrid에서 사용될 스크립트                            --!>
<!-- 작    성 : 강신규    										            --!>
<!-- 설    명 :                                                             --!>
<!-- 변경사유 : UltraWebGrid의 자체스크립트의 오류 수정                     --!>
<!----------------------------------------------------------------------------!>
    // 현재셀이 데이타 셀인가?
    function gfWG_isCell(itemName)
    {
        var parts = itemName.split("_");
        if(parts[1].charAt(parts[1].length-2)=="r" && parts[1].charAt(parts[1].length-1)=="c")
            return true;
        return false;
    }
    
    // 현재셀이 헤더인가?
    function gfWG_isColumnHeader(itemName)
    {
        var parts = itemName.split("_");
        if(parts[1].charAt(parts[1].length-1)=="c" && !gfWG_isCell(itemName))
            return true;
        return false;
    }

<!----------------------------------------------------------------------------!>
<!-- 용    도 : Request Client                                              --!>
<!-- 작    성 : 강신규    										            --!>
<!-- 설    명 : Request객체를 클라이언트에서 접근 처리                      --!>
<!-- 변경사유 :                                                             --!>
<!----------------------------------------------------------------------------!>

    function RObj(ea) {
	    var LS	= "";
	    var QS	= new Object();
	    var un	= "undefined";
	    var x	= null; // On platforms that understand the 'undefined' keyword replace 'null' with 'undefined' for maximum ASP-like behaviour.
	    var f	= "function";
	    var n	= "number";
	    var r	= "string";
	    var e1	= "ERROR: Index out of range in\r\nRequest.QueryString";
	    var e2	= "ERROR: Wrong number of arguments or invalid property assignment\r\nRequest.QueryString";
	    var e3	= "ERROR: Object doesn't support this property or method\r\nRequest.QueryString.Key";

	    function Err(arg) {
		    if (ea) {
			    alert("Request Object:\r\n" + arg);
		    }
	    }
	    function URID(t) {
		    var d = "";
		    if (t) {
			    for (var i = 0; i < t.length; ++i) {
				    var c = t.charAt(i);
				    d += (c  ==  "+" ? " " : c);
			    }
		    }
		    return unescape(d);
	    }
	    function OL(o) {
		    var l = 0;
		    for (var i in o) {
			    if (typeof o[i] != f) {
				    l++;
			    }
		    }
		    return l;
	    }
	    function AK(key) {
		    var auk = true;
		    for (var u in QS) {
			    if (typeof QS[u] != f && u.toString().toLowerCase() == key.toLowerCase()) {
				    auk = false;
				    return u;
			    }
		    }
		    if (auk) {
			    QS[key] = new Object();
			    QS[key].toString = function() {
				    return TS(QS[key]);
			    }
			    QS[key].Count = function() {
				    return OL(QS[key]);
			    }
			    QS[key].Count.toString = function() {
				    return OL(QS[key]).toString();
			    }
			    QS[key].Item = function(e) {
				    if (typeof e == un) {
					    return QS[key];
				    }
				    else {
					    if (typeof e == n) {
						    var a = QS[key][Math.ceil(e)];
						    if (typeof a == un) {
							    Err(e1 + "(\"" + key + "\").Item(" + e + ")");
						    }
						    return a;
					    }
					    else {
						    Err("ERROR: Expecting numeric input in\r\nRequest.QueryString(\"" + key + "\").Item(\"" + e + "\")");
					    }
				    }
			    }
			    QS[key].Item.toString = function(e) {
				    if (typeof e == un) {
					    return QS[key].toString();
				    }
				    else {
					    var a = QS[key][e];
					    if (typeof a == un) {
						    Err(e1 + "(\"" + key + "\").Item(" + e + ")");
					    }
					    return a.toString();
				    }
			    }
			    QS[key].Key = function(e) {
				    var t = typeof e;
				    if (t == r) {
					    var a = QS[key][e];
					    return (typeof a != un && a && a.toString() ? e : "");
				    }
				    else {
					    Err(e3 + "(" + (e ? e : "") + ")");
				    }
			    }
			    QS[key].Key.toString = function() {
				    return x;
			    }
		    }
		    return key;
	    }
	    function AVTK(key, val) {
		    if (key != "") {
			    var key = AK(key);
			    var l = OL(QS[key]);
			    QS[key][l + 1] = val;
		    }
	    }
	    function TS(o) {
		    var s = "";
		    for (var i in o) {
			    var ty = typeof o[i];
			    if (ty == "object") {
				    s += TS(o[i]);
			    }
			    else if (ty != f) {
				    s += o[i] + ", ";
			    }
		    }
		    var l = s.length;
		    if (l > 1) {
			    return (s.substring(0, l-2));
		    }
		    return (s == "" ? x : s);
	    }
	    function KM(k, o) {
		    var k = k.toLowerCase();
		    for (var u in o) {
			    if (typeof o[u] != f && u.toString().toLowerCase() == k) {
				    return u;
			    }
		    }
	    }
	    if (window.location && window.location.search) {
		    LS = window.location.search;
		    var l = LS.length;
		    if (l > 0) {
			    LS = LS.substring(1,l);
			    var preAmpAt = 0;
			    var ampAt = -1;
			    var eqAt = -1;
			    var k = 0;
			    var skip = false;
			    for (var i = 0; i < l; ++i) {
				    var c = LS.charAt(i);
				    if (LS.charAt(preAmpAt) == "=" || (preAmpAt == 0 && i == 0 && c == "=")) {
					    skip=true;
				    }
				    if (c == "=" && eqAt == -1 && !skip) {
					    eqAt=i;
				    }
				    if (c == "&" && ampAt == -1) {
					    if (eqAt!=-1) {
						    ampAt=i;
					    }
					    if (skip) {
						    preAmpAt = i + 1;
					    }
					    skip = false;
				    }
				    if (ampAt>eqAt) {
					    AVTK(URID(LS.substring(preAmpAt, eqAt)), URID(LS.substring(eqAt + 1, ampAt)));
					    preAmpAt = ampAt + 1;
					    eqAt = ampAt = -1;
					    ++k;
				    }
			    }
			    if (LS.charAt(preAmpAt) != "=" && (preAmpAt != 0 || i != 0 || c != "=")) {
				    if (preAmpAt != l) {
					    if (eqAt != -1) {
						    AVTK(URID(LS.substring(preAmpAt,eqAt)), URID(LS.substring(eqAt + 1,l)));
					    }
					    else if (preAmpAt != l - 1) {
						    AVTK(URID(LS.substring(preAmpAt, l)), "");
					    }
				    }
				    if (l == 1) {
					    AVTK(LS.substring(0,1),"");
				    }
			    }
		    }
	    }
	    var TC = OL(QS);
	    if (!TC) {
		    TC=0;
	    }
	    QS.toString = function() {
		    return LS.toString();
	    }
	    QS.Count = function() {
		    return (TC ? TC : 0);
	    }
	    QS.Count.toString = function() {
		    return (TC ? TC.toString() : "0");
	    }
	    QS.Item = function(e) {
		    if (typeof e == un) {
			    return LS;
		    }
		    else {
			    if (typeof e == n) {
				    var e = Math.ceil(e);
				    var c = 0;
				    for (var i in QS) {
					    if (typeof QS[i] != f && ++c == e) {
						    return QS[i];
					    }
				    }
				    Err(e1 + "().Item(" + e + ")");
			    }
			    else {
				    return QS[KM(e, QS)];
			    }
		    }
		    return x;
	    }
	    QS.Item.toString = function() {
		    return LS.toString();
	    }
	    QS.Key = function(e) {
		    var t = typeof e;
		    if (t == n) {
			    var e = Math.ceil(e);
			    var c = 0;
			    for (var i in QS) {
				    if (typeof QS[i] != f && ++c == e) {
					    return i;
				    }
			    }
		    }
		    else if (t == r) {
			    var e = KM(e, QS);
			    var a = QS[e];
			    return (typeof a != un && a && a.toString() ? e : "");
		    }
		    else {
			    Err(e2 + "().Key(" + (e ? e : "") + ")");
		    }
		    Err(e1 + "().Item(" + e + ")");
	    }
	    QS.Key.toString = function() {
		    Err(e2 + "().Key");
	    }
	    this.QueryString = function(k) {
		    if (typeof k == un) {
			    return QS;
		    }
		    else {
			    var k = KM(k, QS);
			    if (typeof QS[k] == un) {
				    t = new Object();
				    t.Count = function() {
					    return 0;
				    }
				    t.Count.toString = function() {
					    return "0";
				    }
				    t.toString = function() {
					    return x;
				    }
				    t.Item = function(e) {
					    return x;
				    }
				    t.Item.toString = function() {
					    return x;
				    }
				    t.Key = function(e) {
					    Err(e3 + "(" + (e ? e : "") + ")");
				    }
				    t.Key.toString = function() {
					    return x;
				    }
				    return t;
			    }
			    if (typeof k == n) {
				    return QS.Item(k);
			    }
			    else {
				    return QS[k];
			    }
		    }
	    }
	    this.QueryString.toString = function() {
		    return LS.toString();
	    }
	    this.QueryString.Count = function() {
		    return (TC ? TC : 0);
	    }
	    this.QueryString.Count.toString = function() {
		    return (TC ? TC.toString() : "0");
	    }
	    this.QueryString.Item = function(e) {
		    if (typeof e == un) {
			    return LS.toString();
		    }
		    else {
			    if (typeof e == n) {
				    var e = Math.ceil(e);
				    var c = 0;
				    for (var i in QS) {
					    if (typeof QS[i] != f && ++c == e) {
						    return QS[i];
					    }
				    }
				    Err(e1 + ".Item(" + e + ")");
			    }
			    else {
				    return QS[KM(e, QS)];
			    }
		    }
		    if (typeof e == n) {
			    Err(e1 + ".Item(" + e + ")");
		    }
		    return x;
	    }
	    this.QueryString.Item.toString = function() {
		    return LS.toString();
	    }
	    this.QueryString.Key = function(e) {
		    var t = typeof e;
		    if (t == n) {
			    var e = Math.ceil(e);
			    var c = 0;
			    for (var i in QS) {
				    if (typeof QS[i] == "object" && (++c == e)) {
					    return i;
				    }
			    }
		    }
		    else if (t == r) {
			    var e = KM(e, QS);
			    var a = QS[e];
			    return (typeof a != un && a && a.toString() ? e : "");
		    }
		    else {
			    Err(e2 + ".Key(" + (e ? e : "") + ")");
		    }
		    Err(e1 + ".Item(" + e + ")");
	    }
	    this.QueryString.Key.toString = function() {
		    Err(e2 + ".Key");
	    }
	    this.Version = 1.3;
	    this.Author = "Andrew Urquhart (www.andrewu.co.uk)";
    }
    var Request = new RObj(false);
    
    // 체크 여부 확인
    function doChecking(chkbox)
    {
        var _elements   = document.forms[0].elements;
        var chkCnt      = 0;
        
        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkbox) >= 0 && _elements[i].type=="checkbox")
            {
                if(_elements[i].checked)
                    chkCnt++;
            }
        }
        
        if(chkCnt == 0)
        {   
            // 선택된 항목이 없습니다.
			var strChoiceMsg = "선택된 항목이 없습니다.";
            alert( strChoiceMsg );
            return false;            
        }
        
        return true;
    }
    
    // 그리드에서 체크박스로 된 Cell를 전체선택/해제 할 수 있는 함수
    function selectChkBox(chkAll, chkChild)
    {
        var param1      = chkAll.checked;
        var _elements   = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                if (param1 == false)
                    _elements[i].checked = false;
                else
                    _elements[i].checked = true;
            }
        }
    }
    
    // 하나만 체크됨
    function OneChek(chkOne, chkChild)
    {
        var param1      = chkOne.checked;
        var _elements   = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                _elements[i].checked = false;
            }
        }
        
        chkOne.checked = true;
    }
    
    function ValidQuestion(q_name, ctrls) 
    {
        var ctrl = ctrls.split(';');
        var id;
        var returnVal = 0;
        
        for(i = 0; i < ctrl.length; i++) 
        {
            if(document.getElementById(ctrl[i]).checked == false) 
            {
                returnVal += 0;    
            }
            else
            {
                returnVal += 1;
            }
        }
        
        if(returnVal == 0) 
        {
            if(ctrl.length > 0)
                document.getElementById(ctrl[0]).focus();
            
            alert('[' + q_name + '] 항목을 선택해 주세요');
            return false;
        }
        
        return true;
    }
    
    function ValidQuestion(q_name, ctrls, txt) 
    {
        var ctrl = ctrls.split(';');
        var id;
        var returnVal = 0;
        
        for(i = 0; i < ctrl.length; i++) 
        {
            if(document.getElementById(ctrl[i]).checked == false) 
            {
                returnVal += 0;    
            }
            else
            {
                returnVal += 1;
            }
        }
        
        if(returnVal == 0) 
        {
            if(ctrl.length > 0)
                document.getElementById(ctrl[0]).focus();
            
            alert('[' + q_name + '] 항목을 선택해 주세요');
            return false;
        }
        
        if(txt != undefined)
        {
            try 
            {
                if(document.getElementById(txt).value == '')
                {
                    //alert('[' + q_name + '] 항목의 평가자 의견을 등록하세요.');
                    alert('평가자 의견을 등록하세요.');
                    document.getElementById(txt).focus();
                    return false;
                }
            }
            catch(e) 
            {
                
            }
            
        }
        
        return true;
    }

