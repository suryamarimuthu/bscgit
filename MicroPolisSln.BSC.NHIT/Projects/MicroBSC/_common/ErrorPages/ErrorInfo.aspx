<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorInfo.aspx.cs" Inherits="_common_ErrorPages_ErrorInfo" ValidateRequest="false" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
<%Response.WriteFile("/_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
        <div>
        <MenuControl:MenuControl ID="MenuControl1" runat="server" />
        
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <table width="721" height="252" border="0" cellpadding="0" cellspacing="0" background="/images/err_b01.gif">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr> 
                                        <td height="33">&nbsp;</td>
                                    </tr>
                                    <tr> 
                                        <td width="100%">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="390">&nbsp;</td>
                                                    <td><strong><ASP:LABEL id="lblErrTitle" runat="server" text="ERROR 메시지"></ASP:LABEL></strong></td>
                                                </tr>
                                            </table>
                                        </td> 
                                    </tr>
                                    
                                    <tr> 
                                        <td height="25">&nbsp;</td>
                                    </tr>
                                    
                                    <tr> 
                                        <td width="100%">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="371">&nbsp;</td>
                                                    <td height="150">
                                                        <div style="width:100%;height:100%;overflow:auto">
                                                            <strong>
                                                                <font color="C60000">
                                                                    <ASP:LABEL id="lblErrMsg" runat="server" text="오류가 발생하였습니다.<br/></br/>관리자에게 문의하십시요!"></ASP:LABEL>
                                                                </font>
                                                            </strong>
                                                        </div>
                                                    </td>
                                                    <td width="45">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr> 
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td height="13"></td>
                        </tr>
                        <tr>
                            <td align="center"><img src="/images/err_b02.gif" width="108" height="25" style="cursor:hand" onclick="history.go(-1);"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <!--- MAIN END --->
        <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("/_common/html/CommonBottom.htm");%>