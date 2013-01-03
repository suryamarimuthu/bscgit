<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4101.aspx.cs" Inherits="ctl_ctl4101" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
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
                <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
                    <TR>
                        <TD vAlign="top" align="center" width="100%">
		                    <TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#c7c6c6" cellSpacing="0"
			                    cellPadding="2" width="100%" align="center" border="0">
			                    <TR>
				                    <TD style="FONT-WEIGHT: bold; COLOR: #006699" width="200">
					                    <img src="../images/title/ma_t06.gif" />  
				                    </TD>
				                    <TD align="right">&nbsp;</TD>
			                    </TR>
		                    </TABLE>
		                    
			                <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
				                <TR>
					                <TD>
						                <TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" class="tableBorder">
							                <tr>
								                <td class="tableTitle"  align="right">
                                                    측정 단계
								                </td>
								                <td class="tableContent" >
								                    &nbsp;
								                    <ASP:LABEL id="lblType" runat="server"></ASP:LABEL>
								                </td>
							                </tr>
							                <tr>
								                <td class="tableTitle"  align="right">
                                                    THRESHOLD 명
								                </td>
								                <td class="tableContent" >
								                    <ASP:TEXTBOX id="txtThresholdName" runat="server"></ASP:TEXTBOX>
								                </td>
							                </tr>
							                <TR>
								                <TD class="tableTitle" align="right">
                                                    최저 수치
								                </TD>
								                <TD class="tableContent">
								                    <ASP:TEXTBOX id="txtMinValue" runat="server"></ASP:TEXTBOX>
								                </TD>
							                </TR>
							                <tr>
							                    <TD class="tableTitle" align="right">
							                        표시 색상
							                    </td>
							                    <td class="tableContent">
							                        <ASP:TEXTBOX id="txtColor" runat="server"></ASP:TEXTBOX>
							                        <img width="15" height="13" border="0" alt="Click Here to Pick up the color" src="../images/icon/sel2.gif" style="cursor:hand"
							                             onclick="TCP.popup(gfGetFindObj('txtColor'))"
							                        >
							                    </td>
							                </tr>
							                <tr>
							                    <TD class="tableTitle" align="right">
							                        이미지파일
							                    </td>
							                    <td class="tableContent">
							                        <input id="fileUpload" runat="server" size="40" type="file" />
							                    </td>
							                </tr>
							                <tr>
							                    <TD class="tableTitle" align="right">
							                        평가 점수
							                    </td>
							                    <td class="tableContent">
							                        <ASP:TEXTBOX id="txtPoint" runat="server"></ASP:TEXTBOX>
							                    </td>
							                </tr>
						                </TABLE>
					                </TD>
				                </TR>
			                </TABLE>
		                </TD>
	                </TR>
	                
	                <tr>
	                    <td height="10px">&nbsp;</td>
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
	             </TABLE>
                <!--- MAIN END --->
                </div>
            </form>
