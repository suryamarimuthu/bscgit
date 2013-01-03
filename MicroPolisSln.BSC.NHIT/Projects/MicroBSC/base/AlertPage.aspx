<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlertPage.aspx.cs" Inherits="base_AlertPage" %>

<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>


<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
    <div>

<!--- MAIN START --->
<table width="100%" height=100%>
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td style="width: 610px">
                            <table  widht="610" height="260" background="../images/stamp/log_isi01.jpg">
                                <tr>
                                    <td valign=top style="width: 610px">
                                        <table>
                                            <tr>
                                                <td colspan=3 align="center" style="height: 50px">
                                                    <span style="font-size: 32pt; color: #ff3300; font-family: 돋움체"></span></td>
                                            </tr>
                                            <tr style="font-size: 12pt; color: #000000">
                                                <td style="height: 149px; width: 215px;"></td>
                                                <td width=323 valign="middle" style="height: 149px">
                                                    <span style="font-size: 8pt;">
                                                    <b>- 본 시스템은 회사의 핵심정보를 담은 <span style="color: #0000ff">중요정보시스템</span>&nbsp;<br />
                                                        &nbsp; 입니다.
                                                        <br />
                                                        <table border="0"><tr><td height="1"></td></tr></table>
                                                        - 이와 관련된 정보가 외부로 유출될 경우 우리 회사에&nbsp;<span style="color: #ff0033"><br />
                                                            &nbsp; 심각한 손해</span>를 끼칠 수
                                                        있습니다.<br />
                                                        <table border="0"><tr><td height="1"></td></tr></table>
                                                        - 본 시스템의 데이터를 <span style="color: #0000ff">다운로드</span> 하거나 <span style="color: #0000ff">
                                                            Copy</span>할 경우 
                                                        <br />
                                                        &nbsp; 이력이 시스템에 기록됩니다.</b></span></td>
                                                <td style="width: 11px; height: 149px"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                         </td>
                     </tr>
                <tr style="font-size: 12pt; color: #000000">
                    <td style="width: 603px">
                        <table width=600>
                            <tr>
                                <td align=center>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/stamp/log_bts02.gif" OnClick="ImageButton1_Click" />
                                    &nbsp;
                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/stamp/log_bts01.gif" OnClick="ImageButton2_Click" />
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table>
            </td>
        </tr>
    </table>

<!--- MAIN END --->

    </div>
    </form>
