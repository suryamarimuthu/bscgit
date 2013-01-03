<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0100S1.aspx.cs" Inherits="BSC_BSC0100S1" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
    <form id="form1" runat="server">
    <div>
<MenuControl:MenuControl ID="MenuControl1" runat="server" /--%>
<!--- MAIN START --->
    <table cellpadding="0" cellspacing="2" border="0" width="100%" style="height: 100%;">
        <tr>
            <td style="padding: 0; width: 100%; height: 100%; text-align:center;">
                <%--<div id="prcmap1" name="prcmap1" style="display:block; padding: 0; width: 100%; height: 100%;">
                    <span>--%>
                        <img src="../images/process_01.gif" usemap="#prclink" border="0" alt="" width="830px" />
                    <%--</span>
                </div>--%>
                <!--div id="prcmap2" name="prcmap2" style="display:none"><img src="../images/process_02.gif" usemap="#prclink" border="0" /></div>
                <div id="prcmap3" name="prcmap3" style="display:none"><img src="../images/process_03.gif" usemap="#prclink" border="0" /></div>
                <map name="prclink" id="prclink">
                <area shape="rect" coords="12,12,159,101" href="#" onmouseover="javascript:prcmap1.style.display='block';prcmap2.style.display='none';prcmap3.style.display='none';">
                <area shape="rect" coords="189,14,339,102" href="#" onmouseover="javascript:prcmap1.style.display='none';prcmap2.style.display='block';prcmap3.style.display='none';">
                <area shape="rect" coords="376,14,707,127" href="#" onmouseover="javascript:prcmap1.style.display='none';prcmap2.style.display='none';prcmap3.style.display='block';">
                </map-->
                <!--TEST-->
            </td>
        </tr>
    </table>
        
<!--- MAIN END --->
</asp:Content>