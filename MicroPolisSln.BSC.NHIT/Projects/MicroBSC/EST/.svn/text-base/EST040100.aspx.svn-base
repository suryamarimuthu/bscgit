<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST040100.aspx.cs" Inherits="EST_EST040100" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>
<body>
<form id="form1" runat="server">
<script type="text/javascript">

	function CheckForm()
	{
		if (document.all.hdfEstID.value.length == 0 )
		{
			alert( "평가명을 선택해주세요." );
			return false;
		}
	}
	
	function ViewCoptType()
    {
        if(document.getElementById('hdfTabKey').value == '')
        {
            alert('항목을 먼저 선택하세요.')
            return false;
        }
    
	    gfOpenWindow( "EST060601.aspx?COMP_ID=<%=COMP_ID%>"
	                                + "&TYPE=" + document.getElementById('hdfTabKey').value
                                   , 500
                                   , 170
                                   , true
                                   , true
                                   , "popup_type" );
	    return false;
    }

</script>
<div>
	
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

<table style="width:100%; height:100%;" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tableBorder">
                <tr>
                    <td class="cssTblTitle">
                        평가기간
                    </td>
                    <td class="cssTblContent" style="border-right:none;">
                        <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged"></asp:dropdownlist>
                        <asp:DropDownList ID="ddlBScale" runat="server" Visible="False" class="box01"></asp:DropDownList>
                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
                    </td>
                    <td class="cssTblContent" style="width:15%; border-left:none; border-right:none;">&nbsp;</td>
                    <td class="cssTblContent">&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="cssPopBtnLine">
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr style="text-align:right">
                    <td><img src="../images/icon/est_i02.gif" align="absmiddle" />설정완료</td>
                    <td style="width:60px;"><img src="../images/icon/est_i03.gif" align="absmiddle" />미설정</td>
                    <td style="width:110px;">
                        <a href="#" onclick="return ViewCoptType();"><img align="absMiddle" border="0" src="../images/btn/b_081.gif" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="vertical-align:top; width:100%; height:100%;">
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                <tr>
                    <td valign="top" style="width: 200px;">
			            <!-- 메뉴 -- 시작 -->
                        <table cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                            <tr style="height:100%;">
                                <td valign="top">
						            <div id="leftLayer" style="border:#F4F4F4 1 solid; DISPLAY:block; overflow: auto; width: 100%;  height:100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
							            <asp:TreeView ID="TreeView1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" runat="server"  Font-Names="Dotum" Font-Size="8pt" ImageSet="XPFileExplorer" ShowLines="False" NodeIndent="15">
							             <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />		
								            <ParentNodeStyle Font-Bold="False" />	                                        
							            </asp:TreeView>
                                    </div>
                                </td>
                            </tr>
                            <tr class="cssPopBtnLine">
                                <td>&nbsp;</td>
                            </tr>
                        </table>
			            <!-- 메뉴 -- 끝 -->
                    </td>
                    <td style="width: 5px">

                    </td>
                    <td>
			            <table cellpadding="0" cellspacing="0" width="100%" style="width:100%; height:100%">
			                <tr>
			                    <td align="left">
						            <asp:ImageButton ID="ibnEst1" runat="server" ToolTip="상대/절대평가설정" OnClick="SetTab_Click" CommandArgument="1" ImageAlign="AbsMiddle" />
						            <asp:ImageButton ID="ibnEst2" runat="server" ToolTip="가중치설정" OnClick="SetTab_Click" CommandArgument="2" ImageAlign="AbsMiddle" />
						            <asp:ImageButton ID="ibnEst3" runat="server" ToolTip="상대평가그룹 설정" OnClick="SetTab_Click" CommandArgument="3" ImageAlign="AbsMiddle" />
                                </td>
		                    </tr>
		                    <tr style="height:100%;">
		                        <td>
		                            <iframe id="ifmContent" runat="server" style="width:100%;height:100%" frameborder="0" scrolling="auto"></iframe>
		                        </td>
		                    </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<asp:HiddenField id="hdfTabKey" runat="server" />
<asp:HiddenField ID="hdfEstID" runat="server" />
<asp:HiddenField ID="hdfWeightType" runat="server" />
<asp:HiddenField ID="hdfScaleType" runat="server" />
<asp:literal id="ltrTabPage" runat="server"></asp:literal>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal></div>

<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>

</form>
</body>

<%Response.WriteFile( "../_common/html/CommonBottom.htm" );%>