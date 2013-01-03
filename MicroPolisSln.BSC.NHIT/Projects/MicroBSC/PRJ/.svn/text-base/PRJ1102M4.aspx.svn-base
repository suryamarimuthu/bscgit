<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1102M4.aspx.cs" Inherits="PRJ_PRJ1102M4" ValidateRequest="false"  %>

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

    function CheckKeysIn() {

        var box = eval("document.form1.hdfchkExecCode");
        box.value = '';

    }

    function mfUpload(hAttachNo, strUpDown) {

        /*
        Argument설명
        : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
        : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
        */

        //수정(20060707 이승주)
        var oAttach = gfGetFindObj(hAttachNo);
        var oaArg = new Array("FILE", "PRJREA", (oAttach == null ? "" : oAttach.value));

        var oReturn = "";
        if (strUpDown == "UP") {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 485, 307);
        }
        else {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307);
        }

        if (oReturn != "" && oReturn != undefined) {
            oAttach.value = oReturn;
            //__doPostBack('lBtnReload', '');
        }
        else {
            alert("파일첨부를 하지 않았습니다!");
        }

        document.getElementById('<%=btnAddFileSearch.ClientID.Replace("_", "$")%>').click();

        return false;
    }

</script>

    </head>

<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus();">
<form id="form1" name="form1" runat="server">
<div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                    <td style=" height:40;" valign="top" background="../images/title/popup_t_bg.gif"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td height="40" valign="top"><img alt="" src="../images/title/popup_t104.gif"/></td>
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

<table border="0" cellspacing="0" cellpadding="0" style="height:99%; width:98%;">
    <tr>
        <td  style="vertical-align:top">
	        <table cellpadding="2" cellspacing="0" border="0" style="height:86%; width:100%;">
	            <tr>
		            <td class="tableOutBorder">
		                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
		                    <tr>
		                        <td colspan="2" align="left" >세부일정정보</td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style=" width:120px;" ><b>실행과제</b></td>
			                    <td class="tableContent" align="left">
			                        <asp:TextBox ID="txtExecRefIdName" runat="server" Width="90%" OnKeyPress="CheckKeys()" class="textReadOnly"></asp:TextBox>
                                </td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style=" width:120px;" ><b>세부일정</b></td>
			                    <td class="tableContent" align="left">
			                        <asp:TextBox ID="txtTaskRefIdName" runat="server" Width="200px" OnKeyPress="CheckKeys()" class="textReadOnly"></asp:TextBox> 
			                        <asp:DropDownList ID="ddlTask" Width="200px"  runat="server" CssClass="box01" 
                                        AutoPostBack="True" onselectedindexchanged="ddlTask_SelectedIndexChanged" />
                                </td>
		                    </tr>
		                    <tr>
		                        <td colspan="2" align="left" >&nbsp;관리항목 기본정보</td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:120px;"><b>관리항목 명칭</b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <asp:TextBox ID="txtItemName" runat="server" Width="200px" ></asp:TextBox> 
			                    </td>
			                </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:120px;"><b>관리항목 기준년월</b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <asp:TextBox ID="txtItemYMD" runat="server" Width="200px" ></asp:TextBox> 
			                    </td>
			                </tr>
                            <tr>
                                <td align="center" class="tableTitle"   style="height:250px; width:120px;"><b>관리항목 정의</b></td>
                                <td class="tableContent" align="left">
                                    <FCKeditorV2:FCKeditor ID="txtItemDesc" runat="server" BasePath="../_common/FCKeditor/"
                                        Height="250px" Width="100%">
                                    </FCKeditorV2:FCKeditor>
                                    <span id="spnItemDesc" visible="false" runat="server" style="height: 200px; width: 100%; overflow: auto;" ></span>
                                </td>
                            </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:120px;"><b>관리항목 단위</b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <asp:TextBox ID="txtItemUnit" runat="server" Width="200px" ></asp:TextBox> 
			                    </td>
			                </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:120px;"><b>관리항목 목표값</b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <asp:TextBox ID="txtItemTgt" runat="server" Width="200px" ></asp:TextBox> 
			                    </td>
			                </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:120px;"><b>관리항목 실적값</b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <asp:TextBox ID="txtItemRst" runat="server" Width="200px" ></asp:TextBox> 
			                    </td>
			                </tr>
                            <tr>
                                <td align="center" class="tableTitle"  style="width:120px;"><b>관련파일</b></td>
                                <td class="tableContent" align="left"  >
                                    <asp:ListBox id="lbFileList" runat="server" height="100px" width="450px"></asp:ListBox>
                                    <asp:ImageButton ID="iBtnTargetFile_Up"   
                                        ImageUrl="../images/icon/gr_po05.gif" runat="server" 
                                        OnClientClick="return mfUpload('hdfTargetReasonFile','UP')" />
                                    <asp:ImageButton ID="iBtnTargetFile_Down" 
                                        ImageUrl="../images/icon/gr_po04.gif" runat="server" 
                                        OnClientClick="return mfUpload('hdfTargetReasonFile','DOWN')" />
                                    <asp:HiddenField ID="hdfTargetReasonFile" runat="server" Value="" />
                                    <asp:Button ID="btnAddFileSearch" runat="server" style="display:none;" 
                                        onclick="btnAddFileSearch_Click"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle"  style=" width:120px;"><b>사용여부</b></td>
                                <td class="tableContent" align="left"  >
                                    <asp:CheckBox ID="chkUseYN" runat="server" Text="사용합니다." AutoPostBack="True" 
                                        oncheckedchanged="chkUseYN_CheckedChanged" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td  class="tableContent" colspan="2">
                                    <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                        <tr>
                                            <td class="tableContent"  align="left" style="width:50%;">
                                	            <asp:ImageButton ID="iBtnNew" ImageUrl="../images/btn/b_141.gif" runat="server" onclick="iBtnNew_Click" />
                                            </td>
                                            <td class="tableContent"  align="right"  style="width:50%;">
                                               
                                                <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server" 
                                                    OnClick="iBtnInsert_Click" />
                                                <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" 
                                                    OnClick="iBtnUpdate_Click" />
                                                <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" 
                                                    OnClick="iBtnClose_Click" />       
                                                       
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
		                </table>
	                </td>
                </tr>
            </table>
	    </td>
    </tr>
</table>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</center>
</div>


</form>
</body>
</html>

