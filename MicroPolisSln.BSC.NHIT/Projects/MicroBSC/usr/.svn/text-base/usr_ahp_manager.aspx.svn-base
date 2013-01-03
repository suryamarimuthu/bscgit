<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_ahp_manager.aspx.cs" Inherits="usr_usr_ahp_manager" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>

<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script language="javascript">
   function Resize_Frame(name)
   {
    var Frame_Body  = document.frames(name).document.body;
    var Frame_name  = document.all(name);

    Frame_name.style.width  = Frame_Body.scrollWidth + (Frame_Body.offsetWidth-Frame_Body.clientWidth);
    Frame_name.style.height = Frame_Body.scrollHeight + (Frame_Body.offsetHeight-Frame_Body.clientHeight);

    if (Frame_name.style.height == "0px" 
        || Frame_name.style.width == "0px")
    {
        Frame_name.style.width  = "650px";
        Frame_name.style.height = "300px";
    }
    
    window.scrollTo (0, 0);
   }

  </script>
  

    <form id="form1" runat="server">
    <div>
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
    <iframe src="usr_ahp.aspx" 
            onload="Resize_Frame('ahp_frame');" 
            name = "ahp_frame";
            width="100%" 
            height="300" 
            align="center" 
            valign="top" 
            frameborder="0" 
            scrolling="no"></iframe> 

    <SJ:SmartScroller ID="SmartScroller1" runat="server" MaintainScrollX="true" MaintainScrollY="true"></SJ:SmartScroller>
<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
