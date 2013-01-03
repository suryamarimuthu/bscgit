<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftTop.aspx.cs" Inherits="base_LeftTop" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>BSC</title>  
        <meta http-equiv="Content-Type" content="text/html; " />
        <script type="text/javascript" src="/_common/js/common.js"></script>
        <script type="text/javascript" src="/_common/js/picker.js"></script>
        <link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
        <link rel="stylesheet" href="/_common/css/treeStyle.css" type="text/css" />
        <script language="javascript" type="text/javascript">
            function MainBindPage(url)
            {
                top.document.all["frMain"].src = ""+url;
            }
            
                        
            function sGoUrl(name, target) {	    
                    top.document.location.href = eval("logout");
            }
        </script>
    </head>
    <body style=" margin:0;background-color:#FFFFFF;">        
    <form id="form1" runat="server">    
        <table cellpadding="0" cellspacing="0" border="0" style=" width:1000px; height:100%;">
            <tr>
                <td style=" width:100%; height:32px;">                
                     <table width="100%" style="height:32" border="0" cellpadding="0" cellspacing="0" background="/images/main_top/top_bgit010.gif">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr> 
                                        <td width="25"><img alt="" src="/images/main_top/top_logo010.gif" width="215" height="32"></td>
                                        <td align="center">
					                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td align="center"><img src="/images/main_top/top_ico01.gif" width="13" height="16" align="absbottom"> 
                                                        <span class="stext_w">
                                                        <A HREF="javascript:gfOpenWindow('../base/com2000.aspx',300,310,false,false);">
                                                        [<ASP:LABEL id="lblEmpName" runat="server"></ASP:LABEL>]</A> 님이 로그인 하셨습니다.
                                                        </span></td>
                                                    <td>
                                                        <a href="javascript:sGoUrl('logout')">
                                                         <img src="/images/icon/top_icon02.gif" width="53" height="12" border="0" align="absmiddle"/></a>
                                                     </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="200" align="center"> 
                                            <table border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td><img src="/images/main_top/top_kpi010.gif" width="14" height="22"></td>
                                                    <td width="170" align="center" background="/images/main_top/top_kpi012.gif" class="mipolis1">
                                                     <font color="d8ff00">
                                                        <ASP:LABEL id="lblFinishMonth" runat="server"></ASP:LABEL> 월 KPI실적마감율 : 
                                                        <font color="#d8ff00">
                                                            <ASP:LABEL id="lblFinishRate" runat="server"></ASP:LABEL>%
                                                        </font>
                                                  </td>
                                                    <td><img src="/images/main_top/top_kpi011.gif" width="14" height="22"></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right"> 
                                            <table border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td>
                                                         &nbsp;<a href="javascript:MainBindPage('/mgr/svr4100.aspx');"><img ID="ImageButton1" src="/images/btn/top_bu_k01_1.gif" runat="server" height="25"  /></a>&nbsp;
                                                         <a href="javascript:MainBindPage('/usr/usr3010_embed.aspx');"><img ID="ImageButton2" src="/images/btn/top_bu_k02_1.gif"  runat="server"  height="25"/></a>&nbsp;&nbsp;
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
    </form>
    </body>
</html>