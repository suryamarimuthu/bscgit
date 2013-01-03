<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS_COMMENT.aspx.cs" Inherits="EIS_EIS_COMMENT" %>

<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

        <script type="text/javascript">

        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtTextData" runat="server" TextMode="MultiLine" Width="100%" Height="100%" MaxLength="2000"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="35px" align="right" runat="server" id="tr01">
                            <td>
                                <asp:ImageButton ID="ibnSave" runat="server" 
                                    ImageUrl="~/images/btn/b_tp07.gif" onclick="ibnSave_Click" 
                                    CommandName="EIS_SAVE_COMMENT" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
        <asp:literal id="ltrScript" runat="server"></asp:literal>     
        <!--- MAIN END --->
    </form>
</body>
</html>
