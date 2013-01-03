<%@ Page Language="C#" AutoEventWireup="true" CodeFile="USR1006S.aspx.cs" Inherits="usr_USR1006S" %>

<asp:Repeater runat="server" ID="rpList">
<ItemTemplate>
    <div class="dept" onclick="fnClick('<%#Eval("DEPT_LEVEL") %>', '<%#Eval("DEPT_REF_ID") %>', this);">
        <%#Eval("DEPT_NAME")%>
    </div>
</ItemTemplate>    
</asp:Repeater>    
<div runat="server" id="divMessage" class="dept">
    하위조직이 없습니다.
</div>


