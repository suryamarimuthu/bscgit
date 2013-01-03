<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="base_FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>첨부파일관리</title>
        <link href="../_Common/css/bsc.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../_Common/js/Common.js"></script>
        
        <script type="text/javascript">
            document.onkeydown = function ()
		    {	
			    var oSource = window.event.srcElement ;
    	
			    if (oSource.id == 'FindFile')
			    {
			        return false;
			    }
                
                return true;
		    }
    		
            function mfCheckFile()
            {
                var oFile = gfGetFindObj("FindFile");
                var oDel  = gfGetFindObj("btnDelFile");
                
                oFile.style.visibility = "hidden";
                oDel.style.visibility = "hidden";
                
                if (oFile != null)
                {
                    if (oFile.value != "")
                    {
                       __doPostBack('lbnAdd', '');
                    }
                }
            }
            
            function hbtnFindFile_Click()
            {
                var oFile = gfGetFindObj("FindFile");
                
                if (oFile != null)
                {
                    oFile.click();
                    return true;
                }
                
                return false;
            }
        </script>
    </head>
    <body leftmargin="0" rightmargin="0" topmargin="0" bottommargin="0">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0"  background="../images/etc/pop_ti_bg02.gif" >
            <tr> 
                <td height="538" valign="top" align=center> <table width="100%" border="0" cellpadding="0" cellspacing="0" align=center>
                        <tr> 
                            <td height="25" > 
                                <!-- 타이틀시작 -->
                                <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0" background="../images/etc/pop_ti_bg01.gif">
                                    <tr> 
                                        <td width="63"><img src="../images/etc/pop_ti01.gif" /></td>
                                        <td> <font color=white>첨부파일관리</font></td>
                                        <td width="102"> <a href="#null" onclick="javascript:self.close();"><img src="../images/etc/pop_ti02.gif" border="0" /></a></td>
                                    </tr>
                                </table>
                                <!-- 타이틀끝 -->
                            </td>
                        </tr>
                        <tr> 
                            <td valign="top" class="box_td03"> <table width="460" border="0" cellpadding="0" cellspacing="0" class="box_ta01">
                                    
                                    <tr> 
                                        <td valign="top"  align=center> 
                                            <!-- 내용시작 -->
                                            <br />
									         <form id="attachme" runat="server">
                                                <div>
                                                    <ASP:LINKBUTTON id="lbnAdd" runat="server" onclick="lbnAdd_Click"></ASP:LINKBUTTON>
                                                    <table cellpadding="1" cellspacing="1" align="center" width="460" bgcolor=#dadada>
                                                        <tr> 
                                                            <td width="90%" align="center" bgcolor="#f2f2f2">
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td bgcolor="#F2F2F2" bordercolordark="#6D6D6D" bordercolorlight="#C0C0C0" align="right">
                                                                            <input id="FindFile" runat="server" style="width:100%" type="file" />
                                                                            <!--
                                                                            <input id="hbtnFindFile" runat="server" class="buttons" onclick="document.all.FindFile.click();" type="button" value="파일찾기" />
                                                                            -->
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bgcolor="#F2F2F2" bordercolordark="#6D6D6D" bordercolorlight="#C0C0C0">
                                                                            <ASP:LISTBOX id="lbFileList" runat="server" height="100px" width="450px"></ASP:LISTBOX>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height:30px;" align="right">
                                                                            <ASP:BUTTON id="btnDownFile" runat="server" cssclass="button" text="다운로드" onclick="btnDownFile_Click" />
                                                                            <ASP:BUTTON id="btnDelFile" runat="server" cssclass="button" onclick="btnDelFile_Click" text="파일삭제" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bgcolor="#dadada" style="height:1px;"></td></tr>
                                                                   
                                                                    <tr>
                                                                        <td bgcolor="#FAFAFA" bordercolordark="#6D6D6D" bordercolorlight="#C0C0C0">
                                                                            <ASP:LABEL id="lblStatus" runat="server" cssclass="navycolor" height="40px" width="100%"></ASP:LABEL>
                                                                        </td>
                                                                    </tr>
                                                                    </table>
                                                                
                                                             
                                                                  </td></tr></table>
                                                          
                                                    
                                                    <ASP:HIDDENFIELD id="hSaveFiles"    runat="server" />
                                                    <ASP:HIDDENFIELD id="hSaveAttachNo" runat="server" />
                                                    <ASP:HIDDENFIELD id="hChangeFlag"   runat="server" />
                                                    <ASP:HIDDENFIELD id="hArgArray"     runat="server" />
                                                </div>
                
                
                                            </form>
                                        </td>
                                    </tr>
                                    <tr> 
                                        <td style="height:16px; background-image:url(../images/etc/pop_ti03.gif);">
                                            첨부가능용량 : <asp:Label ID="lblEnableAttKbyte" runat="server" Text="0"></asp:Label> KB
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <!-- 팝업타이틀시작 -->
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td bgcolor="#76BAB2" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td bgcolor="#E6E6E6" colspan="2" height="4">
                </td>
            </tr>
            <tr>
                <td bgcolor="#F5F5F5" height="35">
                    &nbsp;</td>
                <td align="right" bgcolor="#F5F5F5">
                    &nbsp;</td>
            </tr>
        </table>
        
    </body>
</html>