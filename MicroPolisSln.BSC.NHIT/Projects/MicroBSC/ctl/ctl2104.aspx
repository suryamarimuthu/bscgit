<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2104.aspx.cs" Inherits="ctl_ctl2104" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>부서이동 선택</title>
    <link href="../_common/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 100px; background-color: #efefef">부서코드 선택
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <div style="border-right: 1px solid; border-top: 1px solid; overflow: auto; border-left: 1px solid;
                        width: 98%; border-bottom: 1px solid; height: 300px">
                        &nbsp;<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                            OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td>
                    <a href="#" onclick="self.close();"><img src="../images/btn/b_016.gif" border="0" /></a></td>
            </tr>
        </table>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
    </form>
</body>
</html>
