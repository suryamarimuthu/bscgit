<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1101M1.aspx.cs" Inherits="PRJ_PRJ1101M1" ValidateRequest="false" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    
    function Valid() 
    {
        var f = document.forms[0];
        
        if(f.txtWorkCode.value == '') 
        {
            alert('중점과제 Code를 입력하세요.');
            f.txtWorkCode.focus();
            return false;
        }
        if(f.txtWorkName.value == '') 
        {
            alert('중점과제 명을 입력하세요.');
            f.txtWorkName.focus();
            return false;
        }
        
        return true;
    }
    
    var param1 = true;
    function selectChkBox(chkChild)
    {
        var _elements   = document.forms[0].elements;
        
        for (var i = 0; i < _elements.length; i++)
        {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type=="checkbox")
            {
                if(!_elements[i].disabled)
                {
                    if (param1 == false)
                    {
                        _elements[i].checked = false;
                    }
                    else
                    {
                        _elements[i].checked = true;
                    }
                }
            }
        }
        
        if (param1)
        {
            param1 = false;
        }
        else
        {
            param1 = true;
        }
    }


    function CheckKeys() // 문자입력 금지 함수 설정
    {
        event.keyCode = 0;
    }
</script>
</head>

<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">

<form id="form1" runat="server">
<div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                    <td style=" height:40;" valign="top" background="../images/title/popup_t_bg.gif"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td height="40" valign="top"><img alt="" src="../images/title/popup_t100.gif"/></td>
                                <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif"/></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                                <td width="50%" height="4" bgcolor="FFC600"></td>
                                <td width="50%" bgcolor="00549C"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<center>

<table border="0" cellspacing="0" cellpadding="0" style="height:99%; width:100%;">
    <tr>
        <td class="tableBorder" style="vertical-align:top">
	        <table cellpadding="2" cellspacing="0" border="0" style="height:86%; width:100%;">
	            <tr>
		            <td class="tableBorder">
		                <table class="tableOutBorder" cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
		                    <tr>
			                    <td class="tableTitle" align="center" style="height:20px; width:120px;"><b>중점과제&nbsp;ID</b></td>
			                    <td class="tableContent">
			                        <asp:TextBox ID="txtWorkPoolRefID" runat="server" Width="98%"  OnKeyPress="CheckKeys()" ></asp:TextBox>
			                    </td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style="height:20px; width:120px;"><b>중&nbsp;점&nbsp;과&nbsp;제&nbsp;&nbsp;명</b></td>
			                    <td class="tableContent">
			                        <asp:TextBox ID="txtWorkName" runat="server" Width="98%"></asp:TextBox>
			                    </td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style="height:400px; width:120px;"><b>중&nbsp;점&nbsp;과&nbsp;제&nbsp;설명</b></td>
			                    <td class="tableContent" valign="top" style="height:400px;">
                                    <FCKeditorV2:FCKeditor ID="txtWorkDesc" runat="server" BasePath="../_common/FCKeditor/"
                                        Height="400px" Width="100%">
                                    </FCKeditorV2:FCKeditor>
                                    
                                    
                                
			                    </td>
		                    </tr>

                            <tr>
                                <td align="center" class="tableTitle"  style="height:20px; width:120px;"><b>사&nbsp;&nbsp;용&nbsp;&nbsp;여&nbsp;&nbsp;부</b></td>
                                <td class="tableContent" align="left" >
                                    <asp:CheckBox ID="chkUseYn" runat="server" Text="사용합니다." />
                                </td>
                            </tr>
		                </table>
	                </td>
                </tr>
            </table>
            <br />
	        <table cellpadding="0" cellspacing="0" border="0" width="100%">
	            <tr style="height:5">
	                <td colspan="2">
	                    <img alt="" src="../images/blank.gif" width="1" height="5"/><br />
                        <asp:HiddenField ID="oldWorkCode" runat="server" />
                    </td>
                </tr>
	            <tr>
	                <td class="tableContent" align="left" style="width:50%;">
	                	<asp:ImageButton ID="iBtnNew" ImageUrl="../images/btn/b_141.gif" runat="server" 
                            onclick="iBtnNew_Click" />
	                </td>
		            <td class="tableContent" align="right" style="width:50%;">
		                <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server" OnClick="iBtnInsert_Click" />
		                <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click" />
		                <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" OnClick="iBtnClose_Click" />
		            </td>
		            <td style="width:5px;"></td>
	            </tr>
	        </table>
	        <br />
	           <%-- 사용안함--%>
                                    <asp:DropDownList ID="ddlPriority" Width="200px"  runat="server" CssClass="box01" Visible="false" />
                               
                                    <asp:DropDownList ID="ddlWorkType" Width="200px" runat="server" CssClass="box01" Visible="false" />
                                     
                                   <%-- 사용안함--%>
	    </td>
    </tr>
</table>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</center>
</div>
</form>
</body>
</html>
