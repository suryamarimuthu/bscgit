<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Mana_R104P.aspx.cs" Inherits="eis_SEM_Mana_R104P" %>

<!--%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %-->
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
    
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    </head>
    
    <body style="margin:0 0 0 0 ; background-color:#FFFFFF">
        <form id="form1" runat="server">
            <div>
                <MenuControl:MenuControl ID="MenuControl1" runat="server" />
                <table class="box_tt01">
                    <tr>
                        <td width="100%" height="100%">
                          <iframe name="topmenufrm" id="topmenufrm" width="800px" height="500px" scrolling="no" frameborder="0" marginheight="0" marginwidth="0" src="SEM_Mana_R104F.aspx"></iframe>
                        </td>
                    </tr>
                </table>
                <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
            </div>
        </form>
    </body>
</html>