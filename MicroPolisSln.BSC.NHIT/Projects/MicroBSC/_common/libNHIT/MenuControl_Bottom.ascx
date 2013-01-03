<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl_Bottom.ascx.cs" Inherits="_common_libNHIT_MenuControl_Bottom" %>




                                </td>
                            </tr>
                        </table>    
                    </td>
                </tr>
            </table>    
	    </td>
    </tr>
    <!--onclick="gfOpenWindow('http://172.16.2.240/_common/Manual 성과 분석 메뉴얼.doc', 10, 10);"-->
    <%--<tr id="dvMenuBottom" style=" display:block;" runat="server">
        <td colspan=3 height="25" background="/images/left/copy_bg.gif">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Image runat="server" ID="imgBottomCopy" ImageUrl="~/images/logo/copy.gif" />
                    </td>
                    
                    <td align="right" style="padding-right:10px">
                        <table border="0" cellpadding="0" cellspacing="0">
				            <tr>
				                <td>
					                &nbsp;<asp:ImageButton ID="ibnManual_down" runat="server" ImageUrl="/images/btn/manual_down01.gif" OnClientClick="return manual_down()" />
					                <asp:HiddenField ID="hdfManual_url" runat="server" />
                                </td>
                                <td valign="middle">
				                    <asp:Label ID="lblSysVer" runat="server"></asp:Label>
				                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>            
        </td>
    </tr>--%>
    <tr id="trMenuBottom" runat="server">
        <td style="height:43px; vertical-align: top; padding-top:5px;" align="left">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border-top-width: 2px; border-top-color: #F9F9F9; border-top-style: solid; height:100%;">
                <tr>
                    <td>
                        <asp:Image runat="server" ID="imgBottomCopy" ImageUrl="~/images/logo/copy.gif" />
                    </td>
                    <td align="right" style="padding-right: 10px">
                        <table border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                            <tr>
                                <td>
                                    &nbsp;<asp:ImageButton ID="ibnManual_down" runat="server" ImageUrl="/images/btn/manual_down01.gif" OnClientClick="return manual_down()" />
                                    <asp:HiddenField ID="hdfManual_url" runat="server" />
                                </td>
                                <td valign="middle">
                                    <asp:Label ID="lblSysVer" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <script type="text/javascript">
            function manual_down() {
                var url = "<%=this.hdfManual_url.Value.ToString() %>";
                //alert(url);
                gfOpenWindow(url, 10, 10);

                return false;
            }
    </script>
</table>