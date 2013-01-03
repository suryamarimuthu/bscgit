<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl_Bottom.ascx.cs" Inherits="_common_lib_MenuControl_Bottom" %>
                            </td>
                            </tr>
                        </table>    
                    </td>
                </tr>
            </table>    
	    </TD>
    </TR>
    <div id="dvMenuBottom" style=" display:block;" runat="server">
    <!--onclick="gfOpenWindow('http://172.16.2.240/_common/Manual 성과 분석 메뉴얼.doc', 10, 10);"-->
    <tr>
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
						            <%--<img src="/images/btn/manual_down01.gif" style="cursor:hand" alt="메뉴얼 다운로드" />--%>
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
    </div>
</TABLE>