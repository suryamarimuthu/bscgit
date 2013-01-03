<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEM_Empl_R001.aspx.cs" Inherits="eis_kdgas_SEM_Empl_R001" %>
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
    <div>
        <MenuControl:MenuControl ID="MenuControl1" runat="server" />
        <table>
            <tr>
                <td width="8"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="800px" >
            <tr>
                <td style="padding-left:5px;" runat="server" id="tdDigm">
<%--                    <asp:ImageMap ID="imgMap" runat="server" ImageUrl="~/eis_kdgas/경동조직도.jpg">
                        
                    </asp:ImageMap>--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
