<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl4201.aspx.cs" Inherits="ctl_ctl4201" %>
<%@ Register Assembly="SJ.Web.UI" Namespace="SJ.Web.UI" TagPrefix="SJ" %>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>
        
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
					                    <img src="../images/title/ma_t10.gif" id="IMG1" runat="server" /><br />
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
                                                    컬럼명
								                </td>
								                <td class="tableContent" >
								                    <ASP:TEXTBOX id="txtDimensionName" runat="server"></ASP:TEXTBOX>
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
                            <ASP:IMAGEBUTTON ID="iBtnUpdate" runat="server" Height="19px" ImageUrl="~/images/btn/b_002.gif" onclick="iBtnUpdate_Click" />
                            <ASP:IMAGEBUTTON ID="iBtnDelete" runat="server" Height="19px" ImageUrl="~/images/btn/b_004.gif" onclick="iBtnDelete_Click" />
                            <img src="../images/btn/b_003.gif" id="hBtnClose" style="cursor:hand" onclick="window.close()" />
                        </td>
                    </tr>
                    
                    <sj:callback ID="Callback1" runat="server">
                        <Content />
                    </sj:callback>
	             </TABLE>
	             <script>gfWinFocus();</script> 
                <!--- MAIN END --->
                </div>
                <asp:literal id="ltrScript" runat="server"></asp:literal>
            </form>


