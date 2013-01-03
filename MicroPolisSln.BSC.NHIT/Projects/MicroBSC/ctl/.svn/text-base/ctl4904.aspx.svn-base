<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4904.aspx.cs" Inherits="ctl_ctl4904" %>

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
        <table id="Table1" style=" width:100%;" cellSpacing="5" cellPadding="0" border="0">            
            <tr>
                <td style=" height:5px;"></td>
            </tr>
            <tr>
                <td style="FONT-WEIGHT: bold; COLOR: #006699" width="200">
			        <img src="../images/title/ma_t06.gif" />  
		        </td>
	        </tr>
            <tr>
                <td style=" height:5px;"></td>
            </tr> 
            <tr>
                <td valign="top" align="center" width="100%" >           
	                <table id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" class="tableBorder" style="padding-left:5px; padding-right:5px; padding-bottom:2px; padding-top:2px;">				                
		                <tr>	
		                    <td class="tableTitle" align="right" >
			                    Threshold등급&nbsp;
			                </td>
			                <td class="tableContent">
			                    <asp:DropDownList id="ddlThresholdLevel" runat="server" style="width:120px;" CssClass="box01"></asp:DropDownList>
			                </td>						                
		                </tr>
		                <tr>
			                <td class="tableTitle"  align="right">
                                Threshold코드&nbsp;
			                </td>
			                <td class="tableContent">
			                    <asp:DropDownList id="ddlThresholdCode" runat="server" style="width:120px;" CssClass="box01"></asp:DropDownList> 
			                </td>
			            </tr>
			            <tr>
			                <td class="tableTitle"  align="right">
                                Point&nbsp;
			                </td>
			                <td class="tableContent">
			                    <ASP:TEXTBOX id="txtPoint" style=" width:150px;" runat="server"></ASP:TEXTBOX>
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
                    <ASP:IMAGEBUTTON ID="iBtnAdd" runat="server" Height="19px" ImageUrl="~/images/btn/b_001.gif" onclick="iBtnAdd_Click" />
                    <img src="../images/btn/b_003.gif" id="hBtnClose" style="cursor:hand" onclick="mfClose()" />
                </td>
            </tr>
            
            <SJ:CallBack ID="Callback1" runat="server">
                <Content />
            </SJ:CallBack>
         </table>
        <!--- MAIN END --->
    </div>
</form>
