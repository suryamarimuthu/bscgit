<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="base_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
</head>
<body style="margin:0 0 0 0 ;background-image:url(../images/bg.jpg); background-color:#FFFFFF" oncontextmenu='return false'>
    <form id="form1" runat="server">
<div id="loginDiv" runat="server" style="position:absolute;width:192px;height:490px;background-image:url(../images/login.gif); top: 1px;">
    <div style="position:absolute;top:214px;left:26px;">
    <asp:TextBox ID="txtLoginID" runat="server" BackColor="#F2F2F2" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="138px"></asp:TextBox><br />
    </div>
    <div style="position:absolute;top:253px;left:26px;">
    <asp:TextBox ID="txtPasswd" runat="server" TextMode="Password" AutoCompleteType="None" BackColor="#F2F2F2" BorderColor="#D2D2D2" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="138px"></asp:TextBox></div>
    <div style="position:absolute;top:284px;left:71px;">
    <asp:imagebutton id="loginbtn" runat="server" OnClick="loginbtn_Click" ImageUrl="../images/login_btn.gif" Height="53px" Width="53px"></asp:imagebutton>
    <%--<a href="http://localhost:1808/base/Login.aspx?loginid=admin" >test</a>--%>
    </div>
    </div>
        </form>
        <script language="javascript" type="text/javascript">
	        var leftpos = document.documentElement.clientWidth/2 - parseInt(loginDiv.style.width,10)/2; 
	        var toppos = document.documentElement.clientHeight/2 - parseInt(loginDiv.style.height,10)/2;

            loginDiv.style.top  = toppos;
            loginDiv.style.left = leftpos;
        </script>
    <%= POPUP %>
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
</body>
</html>
