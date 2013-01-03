<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4903.aspx.cs" Inherits="ctl_ctl4903" %>

<%Response.WriteFile("../_common/html/CommonTop.htm");%>
        
<script type="text/javascript">
function mfClose()
{
    gfCloseWindow();
}
</script>
        
<form id="form1" runat="server">
    <div>
        <!--- MAIN START --->
        <table id="Table1" style=" width:100%;" cellspacing="5" cellpadding="0" border="0">
          <tr>
                <td style=" height:5px;"></td>
            </tr>
            <tr>
                <td style="FONT-WEIGHT: bold; COLOR: #006699" width="200">
			        <img alt="" src="../images/title/threshold_step_title.gif" />  
		        </td>
	        </tr>
            <tr>
                <td style=" height:5px;"></td>
            </tr> 
            <tr>
                <td valign="top" align="center" width="100%" >           
	                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder" style=" padding-left:5px; padding-right:5px; padding-bottom:2px; padding-top:2px;">				                   
		                <tr>
			                <td class="tableTitle"  align="right" style=" width:35%;">
                                평가등급
			                </td>
			                <td class="tableContent">
			                    <asp:Label id="lblLevel" runat="server"></asp:Label>
			                </td>
			            </tr>                
		                <tr>
			                <td class="tableTitle"  align="right">
                                순서
			                </td>
			                <td class="tableContent">
			                     <asp:DropDownList id="ddlSequence" runat="server" style=" width: 60px;" CssClass="box01"></asp:DropDownList>
			                </td>
			            </tr>
		                <tr>
			                <td class="tableTitle"  align="right">
                                등급코드명
			                </td>
			                <td class="tableContent" colspan="3">
			                    <asp:Label id="lblThresholdEName" style=" width:70%;" runat="server"></asp:Label>
			                </td>
			            </tr>
			            <tr>
			                <td class="tableTitle"  align="right">
                                Point
			                </td>
			                <td class="tableContent">
			                    <asp:textbox id="txtPoint" style=" width:70%;" runat="server"></asp:textbox>
			                </td>
		                </tr>
			            <tr>
			                <td class="tableTitle"  align="right">
                                달성율 기준선
			                </td>
			                <td class="tableContent">
			                    <asp:CheckBox id="chkBaseLineYn" runat="server" ></asp:CheckBox>
			                </td>
		                </tr>
		            </table>
                </td>
            </tr>     
            <tr>
                <td style=" height:10px;"></td>
            </tr>             
            <tr>
                <td align="right">
                    <sj:callback id="Callback1" runat="server"></sj:callback>
                    &nbsp;<ASP:IMAGEBUTTON ID="iBtnUpdate" runat="server" Height="19px" ImageUrl="~/images/btn/b_002.gif" onclick="iBtnUpdate_Click" />
                    <img src="../images/btn/b_003.gif" id="hBtnClose" style="cursor:hand" onclick="mfClose()" />
                </td>
            </tr>
         </table>
        <!--- MAIN END --->
    </div>
</form>
