<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NHIT_Login.aspx.cs" Inherits="base_NHIT_Login" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
</html>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=euc-kr" />
    <!--link href="css/nh_style.css" type="text/css" rel="stylesheet"/-->
    <title>≥Û«˘¡§∫∏Ω√Ω∫≈€ BSC</title>
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script src="/_common/js/jQuery/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function FnLogin() {
            var loginId = "#<%=loginbtn.ClientID %>";
            $(loginId).hide();
        }
    </script>
    <%= POPUP %>
    <style type="text/css">
        html{
        overflow:auto;
        }
        body
        {
            margin: 0;
            padding: 0;
        }
        div, p
        {
            margin: 0;
            padding: 0;
        }
        input
        {
            border: 1px solid #DFDFDF;
            font-family: dotum;
            font-size: 12px;
            color: #666666;
        }
        .cssUserID
        {
            width: 126px;
            height: 18px;
        }
        .cssPassWord
        {
            width: 126px;
            height: 18px;
            margin-top: 6px;
        }
        .cssImg
        {
            border-style: none;
        }
    </style>
</head>
<body style="background: url('../images/NHIT/login/back_login.jpg') repeat-x;">
    <form id="form1" runat="server">
    <div style="width: 100%; background: url('../images/NHIT/login/back_login_img.jpg') center top no-repeat;
        padding-top: 160px;">
        <div style="width: 469px; height: 274px; background: url('../images/NHIT/login/back_input.png') no-repeat;
            margin: 0 auto;">
            <div style="float: left; position: relative; left: 155px; top: 185px;">
                <asp:TextBox ID="txtLoginID" runat="server" CssClass="cssUserID" />
                <%--<input type="text" style="width:126px;height:18px;">--%><br />
                <asp:TextBox ID="txtPasswd" runat="server" TextMode="Password" Height="18px" Width="126px"
                    CssClass="cssPassWord" />
                <%--<input type="password" style="width:126px;height:18px;margin-top:6px">--%>
            </div>
            <div style="float: left; position: relative; top: 185px; left: 163px;">
                <asp:ImageButton ID="loginbtn" runat="server" OnClick="loginbtn_Click" ImageUrl="../images/NHIT/login/btn_login.gif" CssClass="cssImg" OnClientClick="return FnLogin();" />
                <%--<a href="#"><img src="images/btn_login.gif" border="0" /></a>--%>
            </div>
        </div>
        <div style="width: 646px; margin: 0 auto; position: relative; top: 160px;">
            <img src="../images/NHIT/login/login_footer.gif" alt="NHIT" />
        </div>
        <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </div>
    </form>
</body>
</html>
