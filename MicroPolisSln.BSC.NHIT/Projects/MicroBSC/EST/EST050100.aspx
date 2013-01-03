<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST050100.aspx.cs" Inherits="EST_EST050100" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">

	function CheckForm()
	{
		if ( document.all.txtEstScheID.value.length == 0 )
		{
			alert( "일정ID를 입력해주세요." );
			document.all.txtEstScheID.focus();
			return false;
		}	
		else if ( document.all.txtEstScheName.value.length == 0 )
		{
			alert( "일정명을 입력해주세요." );
			document.all.txtEstScheName.focus();			
			return false;
		}
		else if ( document.all.txtEstScheDesc.value.length == 0 )
		{
			alert( "일정설명을 입력해주세요." );
			document.all.txtEstScheDesc.focus();			
			return false;
		}
		else if ( document.all.txtSortOrder.value.length == 0 )
		{
			alert( "정렬순서를 입력해주세요." );
			document.all.txtSortOrder.focus();			
			return false;
		}
		
		return true;
	}

	function ConfirmYN()
	{
		if ( confirm( "삭제하시겠습니까 ?" ) == true )
		{
			return true;
		}
		
		return false;
	}

	function ShowUpEstScheId( ctrl_value_name, ctrl_text_name )
	{
		gfOpenWindow( "EST_SCHE_INFO.aspx?COMP_ID=<%=COMP_ID%>"
		                                + "&CTRL_VALUE_NAME="	+ ctrl_value_name
                                        + "&CTRL_TEXT_NAME="	+ ctrl_text_name
									    + "&CHECKBOX_YN="	    + "N"                                                    
                                       , 400
                                       , 400
                                       , false
                                       , false
                                       , "popup_est_scheId" );
		return false;
	}

	function ShowEstId( ctrl_value_name, ctrl_text_name )
	{
		gfOpenWindow( "EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
		                        + "&CTRL_VALUE_NAME="	    + ctrl_value_name
                                + "&CTRL_TEXT_NAME="	    + ctrl_text_name
								+ "&CHECKBOX_YN="	        + "N"
								+ "&POSTBACK_YN="	        + "Y"
								+ "&POSTBACK_CTRL_NAME="	+ "lbnEstJobMap"
                               , 400
                               , 400
                               , false
                               , false
                               , "popup_est_Id" );
                               
       

                               
                               
		//return false;
	}

</script>

<form id="form1" runat="server">
	<div>
<%-- <MenuControl:MenuControl ID="MenuControl1" runat="server" /> --%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->
	<table style="width:100%; height:100%;" cellpadding="1" cellspacing="1" border="0">
	    <tr height="20">
	        <td>
	        </td>
	        <td>
	        </td>
	        <td align="right"> 
	            <asp:label id="lblCompTitle" runat="server"></asp:label>
                <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
	        </td>
	    </tr>
        <tr style="vertical-align:top; width:100%;height:85%">
            <td valign="top" style="width: 300px;">
				<!-- 메뉴 -- 시작 -->
                <table cellpadding="0" cellspacing="0" width="310" style="height: 100%">
                    <tr>
                        <td style="height: 100%" valign="top">
							<div id="leftLayer" style="border:#F4F4F4 3 solid; DISPLAY:block; overflow: auto; width: 100%;  height:expression(eval(document.body.clientHeight)- 200); padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
								<asp:TreeView ID="TreeView1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" runat="server"  Font-Names="Dotum" Font-Size="8pt" ImageSet="XPFileExplorer" ShowLines="False" NodeIndent="15">
									<ParentNodeStyle Font-Bold="False" />
									<SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />									  
								</asp:TreeView>
                            </div>
                        </td>
                    </tr>
                </table>
				<!-- 메뉴 -- 끝 -->
            </td>
            <td width="5">
                &nbsp;
            </td>
            <td valign="top" style="height:40%;"> 
				<table cellpadding="0" cellspacing="0" width="100%" style="width:100%; height:100%">
					<tr>
						<td valign=TOP style="height:100%">
                        
							<!-- 내용 -- 시작 -->
							
                            <table cellpadding="0" cellspacing="1" class="tableBorder" style="width: 100%;">
								<tr>
									<TD width="150" class="tableTitle">일정ID</td>
									<td class="tableContent">
										<asp:textbox id="txtEstScheID" runat="server"></asp:textbox>
										<asp:ImageButton id="ibnCheckID" runat="server" ImageUrl="../images/btn/b_039.gif" OnClick="ibnCheckID_Click" ImageAlign="AbsMiddle"></asp:ImageButton>
									</td>
								</tr>
								<tr>
									<TD class="tableTitle">일정명</td>
									<td class="tableContent">
										<asp:textbox id="txtEstScheName" runat="server"></asp:textbox>
									</td>
								</tr>                            
								<tr>
									<TD class="tableTitle">상위일정</td>
									<td class="tableContent">
										<asp:textbox id="txtUpEstScheID" runat="server"></asp:textbox>
										<a href="#null" onclick="ShowUpEstScheId( 'hdfUpEstScheId', 'txtUpEstScheID' );"><img runat="server" id="imgUpEstScheID" src="../images/btn/b_152.gif" align="absmiddle" border="0"/></a>
										<asp:HiddenField ID="hdfUpEstScheID" runat="server" />
									</td>
								</tr>                            
								<tr>
									<TD class="tableTitle">평가 ID</td>
									<td class="tableContent">
										<asp:textbox id="txtEstID" runat="server" ReadOnly style="cursor:hand"></asp:textbox>
										<img id="imgEstID" runat="server" src="../images/btn/b_143.gif" OnClick="ShowEstId( 'hdfEstId', 'txtEstID' );" style="cursor:hand" align="absmiddle" />
										<asp:HiddenField ID="hdfEstID" runat="server" />
									</td>
								</tr>
								<tr>
									<TD class="tableTitle">평가작업 매핑</td>
									<td class="tableContent">
										<asp:dropdownlist id="ddlEstJobID" runat="server" class="box01"></asp:dropdownlist>
									</td>
								</tr>
								<tr>
									<TD class="tableTitle">일정설명</td>
									<td class="tableContent">
										<asp:TextBox ID="txtEstScheDesc" runat="server" CssClass="txt"  Width="98%"  Height="50" TextMode="MultiLine"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<TD class="tableTitle">정렬순서</td>
									<td class="tableContent">
										<asp:textbox id="txtSortOrder" runat="server" Width="42px"></asp:textbox>
									</td>
								</tr>
                            </table>

							<!-- 내용 -- 끝 -->
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:15%">
            <td></td>
            <td width="5">&nbsp;&nbsp;</td>
            <td align="right">
				<asp:ImageButton id="ibnNew" runat="server" ImageUrl="../images/btn/b_141.gif" OnClick="ibnNew_Click"></asp:ImageButton>
				<asp:ImageButton id="ibnSave" runat="server" ImageUrl="../images/btn/b_tp07.gif" OnClick="ibnSave_Click" OnClientClick="return CheckForm();"></asp:ImageButton>
				<asp:ImageButton id="ibnDelete" runat="server" ImageUrl="../images/btn/b_004.gif" OnClick="ibnDelete_Click" onClientClick="return ConfirmYN();"></asp:ImageButton>
            </td>
        </tr>
    </table>

<asp:HiddenField ID="hdfEstScheId" runat="server" />

<!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
	</div>
	<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <asp:linkbutton id="lbnEstJobMap" runat="server" onclick="lbnEstJobMap_Click"></asp:linkbutton>
</form>

<%
      Response.WriteFile( "../_common/html/CommonBottom.htm" );
%>