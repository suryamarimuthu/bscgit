<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST_NOTICE.aspx.cs" Inherits="EST_NOTICE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
      <title>To be replaced.</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<!-- 오늘 하루 이 창 열지 않기 -->
<SCRIPT language="JavaScript">
function setCookie( name, value, expiredays )
{
     var todayDate = new Date();
     todayDate.setDate( todayDate.getDate() + expiredays );
     document.cookie = name + "=" + escape( value ) + "; path=/; expires=" + todayDate.toGMTString() + ";"
 
}

function closeWin() 
{ 
 if ( document.forms[0].Notice.checked ) 
   setCookie( "NOTICE_EST", "<%=this.BOARD_ID %>" , 1); 

 self.close(); 
}

</SCRIPT>
<style type="text/css">
    <!-- 
	.tex01/*일반텍스*/
{
    font:Dotum;
	font-size: 13px;		
	color:#ffffff;
	line-height:17px;
	font-weight:bold;	
}
 	.tex02/*일반텍스*/
{
    font:Dotum;
	font-size: 12px;		
	color:#ffffff;
	line-height:17px;		
}
 	.tex03/*일반텍스*/
{
    font:Dotum;
	font-size: 12px;		
	color:#000000;
	line-height:17px;		
}
   -->
  </style>

</head>

<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<form id="form1" runat="server">
<table width="350" height="250" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td height="37" valign="top">
        <table width="350" height="37" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td width="43"><img src="../images/notice/img01.gif" width="43" height="37"></td>
          <td background="../images/notice/img02.gif" class="tex01"> <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
          <td width="19"><img src="../images/notice/img03.gif" width="19" height="37"></td>
        </tr>
      </table>
     </td>
  </tr>
  <tr>
    <td style="padding: 5 0 5 10">
         <table width="330" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td width="7px"></td>
              <td height="170px" valign="top">
                    <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
              </td>
            </tr>
          </table>
      </td>
  </tr>
  <tr>
    <td height="26">
        <table width="350" height="26" border="0" cellpadding="0" cellspacing="0">
            <tr bgcolor="#000000">
              <td width="11">&nbsp;</td>
              <td width="270" class="tex02"><input type="checkbox" name="Notice"  onclick="closeWin()">
                오늘 하루 페이지를 열지 않습니다.</td>
              <td width="69"><a href="#null" onclick="self.close()"><img border="0" src="../images/notice/img04.gif" height="19px" /></a></td>
            </tr>
          </table>
      </td>
  </tr>
</table>

</form>
</body>
</html>
