<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftCopyright.aspx.cs" Inherits="base_LeftCopyright" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
</head>
<body style=" margin:0; background-color:#FFFFFF;">
    <form id="form1" runat="server">    
			<table style=" width:100%; height:100%;" cellpadding="0" cellspacing="0" border="0">
			    <tr>
				    <td style=" height:25px; background-image :url(/images/left/copy_bg.gif);">
                        <table cellpadding="0" cellspacing="0" border="0" style=" width:100%;">
                            <tr>
                                <td>
                                    <img src="/images/left/copy_01.gif" width="513" height="25"/>
                                </td>                        
                                <td align="right" style="padding-right:10px">
                                    <img src="/images/btn/manual_down01.gif" style="cursor:hand"
                                         alt="메뉴얼 다운로드"
                                         onclick="gfOpenWindow('http://172.16.2.240/_common/Manual 성과 분석 메뉴얼.doc', 10, 10);"
                                     />
                                </td>
                            </tr>
                        </table>             
                    </td>
                </tr>
            </table>      
    </form>
</body>
</html>
