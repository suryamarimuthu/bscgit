<%
	Set Conn = Server.CreateObject("ADODB.Connection")
	Conn.Open("dsn=kdhrm;uid=sa;pwd=kdgas")
	userid=request.cookies("login")("HR_EMPNO")
	If userid="" Then
		save_id_checkd=""
	Else
		save_id_checkd="checked"
	End If
	lr=request("lr")	
	Function SubStr(str, length)
		
		if len(str) > length then
			SubStr = left(str, length) & "..."
		else
			SubStr = str
		end if
	End Function
%>
<html>

<head>
<meta http-equiv="content-type" content="text/html; charset=euc-kr">
<title> ▒ KD PIN - 역량 중심 인재육성 네트워크 ▒ </title>
<link href="http://hr.kdgas.co.kr/common/Css/style.css" rel="stylesheet" type="text/css">
<script language="JavaScript">
<!--

	function form_check(){
		if(fm.ID.value==""){
			alert('아이디를 입력하십시오.');
			fm.ID.focus();
			return;
		}
		if(fm.PWD.value==""){
			alert('비밀번호를 입력하십시오.');
			fm.PWD.focus();
			return;
		}
		fm.mode.value="";
		fm.submit();
	}
	function enter(){
	    if(event.keyCode == 13){
	        form_check();
	    }
	}
	function Notice_view(seq_no){	
		window.open('http://hr.kdgas.co.kr/support/Notice_view.asp?seq_no='+seq_no,'cgpopup','location=0,directories=0,resizable=0,status=0,toolbar=0,menubar=0,scrollbars=yes,width=416,height=300');
	}

// -->
</script>
<script language="JavaScript">
<!--
function na_restore_img_src(name, nsdoc)
{
  var img = eval((navigator.appName.indexOf('Netscape', 0) != -1) ? nsdoc+'.'+name : 'document.all.'+name);
  if (name == '')
    return;
  if (img && img.altsrc) {
    img.src    = img.altsrc;
    img.altsrc = null;
  } 
}

function na_preload_img()
{ 
  var img_list = na_preload_img.arguments;
  if (document.preloadlist == null) 
    document.preloadlist = new Array();
  var top = document.preloadlist.length;
  for (var i=0; i < img_list.length; i++) {
    document.preloadlist[top+i]     = new Image;
    document.preloadlist[top+i].src = img_list[i+1];
  } 
}

function na_change_img_src(name, nsdoc, rpath, preload)
{ 
  var img = eval((navigator.appName.indexOf('Netscape', 0) != -1) ? nsdoc+'.'+name : 'document.all.'+name);
  if (name == '')
    return;
  if (img) {
    img.altsrc = img.src;
    img.src    = rpath;
  } 
}

// -->
</script>
</head>

<body bgcolor="#FBFBF4" text="black" link="blue" vlink="purple" alink="red" OnLoad="fm.ID.focus();na_preload_img(false, 'kd_img/kdpro_button_o.jpg', 'kd_img/kdpro_billing_button_o.jpg', 'kd_img/kdpro_gis_button_o.jpg', 'kd_img/kdpin_button_o.jpg', 'kd_img/kdnet_button_o.jpg', 'kd_img/kdjump_button_o.jpg');">
<table align="center" cellpadding="0" cellspacing="0" width="829" height="539">
    <tr>
        <td width="829" height="6" background="kd_img/top_line1.jpg">
            <p></p>
        </td>
    </tr>
    <tr>
        <td width="829" height="528" background="kd_img/main_bg1.jpg">
            <table align="center" cellpadding="0" cellspacing="0" width="784" bordercolordark="black" bordercolorlight="black">
                <tr>
                    <td width="784" colspan="3">
                        <p></p>
                    </td>
                </tr>
                <tr>
                    <td width="784" colspan="3">
                        <p><img src="kd_img/kdpin.jpg" width="251" height="42" border="0"></p>
                    </td>
                </tr>
                <tr>
                    <td width="551" height="436">
                        <p><img src="./kd_img/2.jpg" width="551" height="436" border="0"></p>
                    </td>
                    <td width="14" height="467" rowspan="2">
                        <p>&nbsp;</p>
                    </td>
                    <td width="219"  rowspan="2" valign="top">
                        <table cellpadding="0" cellspacing="0" width="222">
                            <tr>
                                <td width="222" colspan="2">
                                    <p><img src="./kd_img/navigator.jpg" width="222" height="26" border="0"></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" height="15" colspan="2">
                                    <p></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="40" rowspan="8">
                                    <p><img src="./kd_img/navigator_img.jpg" width="40" height="153" border="0"></p>
                                </td>
                                <td width="182" height="20">
                                    <p><a href="index.html" OnMouseOut="na_restore_img_src('image3', 'document')" OnMouseOver="na_change_img_src('image3', 'document', './kd_img/kdpro_button_o.jpg', true);"><img src="./kd_img/kdpro_button.jpg" align="absmiddle" width="154" height="16" border="0" name="image3" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p style="margin-left:30;"><a href="billing.html" OnMouseOut="na_restore_img_src('image2', 'document')" OnMouseOver="na_change_img_src('image2', 'document', './kd_img/kdpro_billing_button_o.jpg', true);"><img src="./kd_img/kdpro_billing_button.jpg" align="absmiddle" width="50" height="14" border="0" name="image2" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p style="margin-left:30;"><a href="gis.html" OnMouseOut="na_restore_img_src('image1', 'document')" OnMouseOver="na_change_img_src('image1', 'document', './kd_img/kdpro_gis_button_o.jpg', true);"><img src="./kd_img/kdpro_gis_button.jpg" align="absmiddle" width="50" height="14" border="0" name="image1" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p><a href="pin.asp" OnMouseOut="na_restore_img_src('image4', 'document')" OnMouseOver="na_change_img_src('image4', 'document', './kd_img/kdpin_button_o.jpg', true);"><img src="./kd_img/kdpin_button.jpg" align="absmiddle" width="154" height="16" border="0" name="image4" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p><a href="net.asp" OnMouseOut="na_restore_img_src('image5', 'document')" OnMouseOver="na_change_img_src('image5', 'document', './kd_img/kdnet_button_o.jpg', true);"><img src="./kd_img/kdnet_button.jpg" align="absmiddle" width="154" height="16" border="0" name="image5" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p><a href="jump.html" OnMouseOut="na_restore_img_src('image6', 'document')" OnMouseOver="na_change_img_src('image6', 'document', './kd_img/kdjump_button_o.jpg', true);"><img src="./kd_img/kdjump_button.jpg" align="absmiddle" width="154" height="16" border="0" name="image6" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p><a href="./kdscada.html" OnMouseOut="na_restore_img_src('image7', 'document')" OnMouseOver="na_change_img_src('image7', 'document', './kd_img/kdscada_button_o.jpg', true);"><img src="./kd_img/kdscada_button.jpg" align="absmiddle" width="154" height="16" border="0" name="image7" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="182" height="20">
                                    <p><a href="kdicm.html" OnMouseOut="na_restore_img_src('image8', 'document')" OnMouseOver="na_change_img_src('image8', 'document', './kd_img/kdicm_button_o.jpg', true);"><img src="./kd_img/kdicm_button.jpg" align="absmiddle" width="154" height="16" border="0" name="image8" style="filter:blendTrans(duration=1)"></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" colspan="2">
                                    <p>&nbsp;</p>
                                </td>
                            </tr>
						</form>
                        </table>
                        <table cellpadding="0" cellspacing="0" width="222" background="kd_img/login_bg1.jpg">
							<form name=fm method=post action="http://hr.kdgas.co.kr/support/Login_Proc.asp">
							<input type=hidden name=mode value=''>
							<input type=hidden name=prokdgas value='PIN'>
                            <tr>
                                <td width="222" colspan="3">
                                    <p><img src="kd_img/login_top_line1.jpg" width="222" height="3" border="0"></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" colspan="3">
                                    <p><img src="kd_img/login_title.jpg" width="222" height="29" border="0"></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" height="15" colspan="3">
                                    <p></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="72" height="22">
                                    <p><img src="kd_img/id.jpg" align="absmiddle" width="72" height="10" border="0"></p>
                                </td>
                                <td width="78" height="22">
                                        <p><input type="text" name="ID" size="8" style="background-color:rgb(250,248,240); border-width:1; border-color:rgb(196,196,196); border-style:solid;height:18px;width:70px;" tabindex=1 onkeypress="if(event.keyCode==13){form_check(); return false;}"></p>
                                </td>
                                <td width="72" height="45" rowspan="2">
                                    <p><a href="javascript:form_check();"><img src="kd_img/login_btn_1.gif" align="absmiddle" width="65" height="46" border="0" tabindex=3></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="72" height="22">
                                    <p><img src="kd_img/passwd.jpg" align="absmiddle" width="72" height="10" border="0"></p>
                                </td>
                                <td width="78" height="22">
                                    <p><input type="password" name="PWD" size="8" style="background-color:rgb(250,248,240); border-width:1; border-color:rgb(196,196,196); border-style:solid;height:18px;width:70px;" tabindex=2 onkeypress="if(event.keyCode==13){form_check(); return false;}"></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" height="10" colspan="3">
                                    <p></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" colspan="3" height="9">
                                    <p><img src="kd_img/login_mid_line1.jpg" align="absmiddle" width="222" height="6" border="0"></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="72" height="20">
&nbsp;                                </td>
                                <td width="78" height="20">
                                        <p>&nbsp;</p>
                                </td>
                                <td width="72" height="20">
&nbsp;                                </td>
                            </tr>
                            <tr>
                                <td width="222" height="5" colspan="3">
                                    <p></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="222" colspan="3">
                                    <p><img src="kd_img/login_bottom_line1.jpg" width="222" height="3" border="0"></p>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" width="222">
                            <tr>
                                <td width="212" height="18">                                    <p>&nbsp;</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="212" height="10">
<p><img src="kd_img/notice.jpg" align="absmiddle" width="80" height="16" border="0"></p>
                                </td>
                            </tr>
                            <tr>
                                <td width="212" height="12" valign="top" style="font-size:1px;">
                                    <p>&nbsp;</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="212" valign="top">
                                   <table width="207" border="0" cellspacing="0" cellpadding="0">
									<%
											Sql1 = "SELECT top 4 title,seq_no,write_date from NOTICE where use_state='1'  order by seq_no desc "
											set rs1= Conn.execute(Sql1)
											nu = 0
											Dim i
											Do Until rs1.EOF= true
											nu = nu + 1
											i = i + 1										
											title = SubStr(rs1("title"),15)
											seq_no = rs1("seq_no")
											write_date = rs1("write_date")
									%>
											<tr> 
								                <td width="13"><img src="http://hr.kdgas.co.kr/images/ic_notice.gif" width="11" height="13"></td>
								                <td height="15" align="top"><a href="javascript:Notice_view('<%=seq_no%>');" class=mke004284><%=title%></a><%week_show = dateadd("w",-7,now)%><%if write_date > week_show then %> <img src="http://hr.kdgas.co.kr/images/ico_n.gif" align="abstop"><%end if%></td>
								            </tr>
																
									<%
										rs1.movenext
										loop
									%>
									</table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="551" height="31">
                        <p align="center"><img src="kd_img/copyright.jpg" width="305" height="21" border="0" align="absbottom"></p>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td width="829" height="5" background="kd_img/bottom_line1.jpg">
            <p></p>
        </td>
    </tr>
</table>
<p align="center">&nbsp;</p>
                                </td>
    </tr>
</table>
</body>

</html>
