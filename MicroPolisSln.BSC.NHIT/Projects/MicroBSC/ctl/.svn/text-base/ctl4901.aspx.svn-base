<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4901.aspx.cs" Inherits="ctl_ctl4901" %>
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
        <table id="Table1" cellspacing="5" cellpadding="0" border="0" style=" width: 100%;">                  
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
	                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" class="tableBorder" style="padding-left:5px; padding-right:5px; padding-bottom:2px; padding-top:2px;">				                
		                <tr> 					                
			                <td class="tableTitle"  align="right" style=" width: 35%; ">
                                순서
			                </td>
			                <td class="tableContent">
			                    &nbsp;
			                    <ASP:DropDownList id="ddlSequence" runat="server" style=" width: 60px;" CssClass="box01"></ASP:DropDownList>
			                </td>
		                </tr>
		                <tr>
			                <td class="tableTitle"  align="right">
                                사용여부
			                </td>
			                <td class="tableContent">
			                    <asp:radiobuttonlist id="rBtnList" runat="server" repeatdirection="Horizontal">
			                    <asp:ListItem Value="Y">사용함</asp:ListItem>
                                <asp:ListItem Value="N" Selected="true">사용안함</asp:ListItem>
                                </asp:radiobuttonlist>
			                </td>
			            </tr>
		                <tr>
			                <td class="tableTitle"  align="right">
                                영문명
			                </td>
			                <td class="tableContent">
			                    <ASP:TEXTBOX id="txtThresholdEName" style=" width:70%;" runat="server"></ASP:TEXTBOX>
			                </td>
			            </tr>
			            <tr>
			                <td class="tableTitle"  align="right">
                                한글명
			                </td>
			                <td class="tableContent">
			                    <ASP:TEXTBOX id="txtThresholdKName" style=" width:70%;" runat="server"></ASP:TEXTBOX>
			                </td>
		                </tr>
		                <tr>
		                    <td class="tableTitle" align="right">
		                        이미지파일
		                    </td>
		                    <td class="tableContent">
		                        <input id="fileUpload" runat="server" size="30" type="file" />
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
