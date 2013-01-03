<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="nhit_sso.aspx.cs" Inherits="nhit_sso" %>
<html>
<head>
<title>BSC</title>
<script language="javascript" type="text/jscript">
 
    function doOnloading() {

        var login_status = "-4";
        var user_id = "-1";

        var ncapi = document.getElementById("ncapi");

        try {
            login_status = ncapi.IsLogin3();
            user_id = ncapi.GetLoginID();

            if (login_status > 0) {
                document.getElementById("hdfStatus").value = login_status;
                document.getElementById("hdfCustomer").value = user_id;
            }
            else {
                document.location.href = "../../base/NHIT_Login.aspx";            
            }
        }
        catch (e) {
            //alert(e.message);

            document.location.href = "../../base/NHIT_Login.aspx";
        }

        document.getElementById("hdfStatus").value = login_status;
        document.getElementById("hdfCustomer").value = user_id;

        //alert(login_status);

        __doPostBack('lBtnReload', '');
    }

</script>
</head>
<body style="margin:0 0 0 0 ;background-color:#FFFFFF" onload="doOnloading()">
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField ID="hdfStatus" runat="server" />
    <asp:HiddenField ID="hdfCustomer" runat="server" />
          <object id="ncapi" classid="CLSID:D4F62B67-8BA3-4A8D-94F6-777A015DB612"></object>
          <%--<br />
          <br />
          object id 이용하여.
          <br />
          <input type="button" value="로그인 상태확인 방법1 : isLogin()" onclick="return doClicking_isLogin();" />
          <input type="button" value="로그인 상태확인 방법2 : isLogin3()" onclick="return doClicking_isLogin3();" />
          <input type="button" value="로그인 아이디 확인 : GetLoginID()" onclick="return doClicking_GetLoginID();" />
          <br />
          <br />
          CreateObject 이용하여.
          <br />
          <input type="button" value="로그인 상태확인 방법1 : isLogin()" onclick="return doClicking1();" />
          <input type="button" value="로그인 상태확인 방법2 : isLogin3()" onclick="return doClicking2();" />
          <input type="button" value="로그인 아이디 확인 : GetLoginID()" onclick="return doClicking3();" />--%>
    </div>
    
    <asp:linkbutton id="lBtnReload" runat="server" OnClick="lBtnReload_Click"></asp:linkbutton>
    </form>
</body>
</html>
