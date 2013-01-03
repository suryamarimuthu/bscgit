<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060602.aspx.cs" Inherits="EST_EST060602" %>

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
                            <td height="40">
					            <!-- 타이틀시작 -->
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr> 
                                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr> 
                                                    <td height="40" valign="top"><img src="../images/title/popup_t89.gif" /></td>
                                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr> 
                                                    <td width="50%" height="4" bgcolor="#FFFFFF"></td>
                                                    <td width="50%" bgcolor="#FFFFFF"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="box_td03">
                                <table style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0" class="box_ta01">
                                    <tr>
                                        <td valign="top" align="center" height="300">
                                            <div>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%:height:100%">
                                                    <tr>
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" class="tableOutBorder" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table class="tableBorder" cellpadding="0" cellspacing="1" width="350">
                                                                                        <tr>
                                                                                            <td class="cssTblTitle" width="80px">반영대상</td> 
                                                                                            <td class="cssTblContent"> 
                                                                                                <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01"></asp:dropdownlist>
                                                                                                <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01"></asp:dropdownlist>
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
                                                    <tr align="right">
                                                        <td style="height: 40px">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
	                                                            <tr>
                                                                    <td style="height: 40px" align="right">
                                                                        <asp:ImageButton ID="ibnSave" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/btn/b_202.gif" OnClick="ibnSave_Click" />
                                                                        <a href="#null" onclick="window.close();"><img src="../images/btn/b_003.gif" border="0" align="absmiddle"/></a>
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                                                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01"></asp:dropdownlist>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>      

    <script>gfWinFocus();</script>
    <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server"></ig:UltraWebGridExcelExporter>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
    </form>
</body>
</html>
