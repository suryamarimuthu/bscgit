<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eisCheck.aspx.cs" Inherits="eis_eisCheck" %>


<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>

    
        <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
        <%Response.WriteFile("../_common/html/CommonTop.htm");%>
            <form id="form1" runat="server">
                <div>
                    <MenuControl:MenuControl ID="MenuControl1" runat="server" />
                    <!--- MAIN START --->
                    
                    <table border="0" cellspacing="0" cellpadding="0" width="100%"  >
	                    <tr>
		                    <td >
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <table cellpadding="1" cellspacing="1" class="tableBorder" width="100%">
                                                <tr>
                                                    <td class="tableTitle" style="width: 100px">
                                                        생산현황
                                                    </td>
                                                    <td class="tdBorder">
                                                        <table cellSpacing=0 cellpadding="0" borderColorDark=#ffffff width=100% height="100%" borderColorLight=#A2A2A2 border=0>
                                                            <tr>
                                                                <td width="10%" class="tableTitle"  align="center">
                                                                    년월
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="10%" class="tableTitle" align="center">
                                                                    공장
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlGong" runat="server" AppendDataBoundItems="True" EnableTheming="False">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                
                                                                <td align="right" style="height: 23px">
                                                                    <asp:ImageButton ID="iBtnSearch" runat="server" Height="19" ImageUrl="~/images/btn/b_033.gif" />&nbsp;
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
                        <td width="10px"></td>
	                </tr>
	            </table>        
                    
                    <!--- MAIN END --->
                    <%Response.WriteFile("../_common/html/MenuBottom.htm");%>
                </div>
            </form>
        <%Response.WriteFile("../_common/html/CommonBottom.htm");%>