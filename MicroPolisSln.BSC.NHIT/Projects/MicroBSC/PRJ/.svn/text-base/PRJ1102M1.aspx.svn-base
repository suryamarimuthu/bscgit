<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1102M1.aspx.cs" Inherits="PRJ_PRJ1102M1" ValidateRequest="false" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">

    function Valid() {
        var f = document.forms[0];

        if (f.txtWorkCode.value == '') {
            alert('중점과제 Code를 입력하세요.');
            f.txtWorkCode.focus();
            return false;
        }
        if (f.txtWorkName.value == '') {
            alert('중점과제 명을 입력하세요.');
            f.txtWorkName.focus();
            return false;
        }

        return true;
    }

    var param1 = true;
    function selectChkBox(chkChild) {
        var _elements = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                if (!_elements[i].disabled) {
                    if (param1 == false) {
                        _elements[i].checked = false;
                    }
                    else {
                        _elements[i].checked = true;
                    }
                }
            }
        }

        if (param1) {
            param1 = false;
        }
        else {
            param1 = true;
        }
    }

    function openWorkPool(strWorkPoolKey, strWorkPoolVal) {
        var url = "../ctl/ctl2108.aspx?WORK_POOL_KEY=" + strWorkPoolKey + "&WORK_POOL_VAL=" + strWorkPoolVal;


        gfOpenWindow(url, 750, 400, 'yes', 'no', 'svr2002_3');
        var f = document.forms[0];
        f.txtWorkCode.focus();
    }

    function openDeptEmp(strDeptKey, strDeptVal, strEmpKey, strEmpVal) {
        var estterm_ref_id = "";
        var url = "../ctl/ctl2109.aspx?DEPT_KEY=" + strDeptKey + "&DEPT_VAL=" + strDeptVal + "&EMP_KEY=" + strEmpKey + "&EMP_VAL=" + strEmpVal;

        gfOpenWindow(url, 750, 400, 'yes', 'no', 'svr2002_3');
        var f = document.forms[0];

    }

    function CheckKeys() // 문자입력 금지 함수 설정
    {
        event.keyCode = 0;
    }

    function CheckKeysUse() // 상황에 따라 문자입력 금지 함수 설정
    {
        var f = document.forms[0];

        if (f.chkUseYN.checked == true) {
            event.keyCode = 0;
        }
    }

    function CheckKeysIn() {

        var box = eval("document.form1.hdfchkWorkCode");
        box.value = '';

    }
    
    
    function mfUpload(hAttachNo, strUpDown)
    {
        
        /*
            Argument설명
                : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
        */
        
        //수정(20060707 이승주)
        var oAttach = gfGetFindObj(hAttachNo);
        var oaArg   = new Array("FILE", "PRJREA", (oAttach==null ? "" : oAttach.value));
        
        var oReturn = "";
        if (strUpDown == "UP")
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 485, 307);
        }
        else
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307);
        }
        
        if (oReturn != "" && oReturn != undefined)
        {
            oAttach.value = oReturn;
            //__doPostBack('lBtnReload', '');
        }
        else
        {
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
<table width="100%" border="0" cellspacing="2" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                    <td style=" height:40;" valign="top" background="../images/title/popup_t_bg.gif"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td height="40" valign="top"><img alt="" src="../images/title/popup_t101.gif"/></td>
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



<table border="0" cellspacing="0" cellpadding="0" style="width:100%;">
    <tr>
        <td  style="vertical-align:top">
	        <table cellpadding="2" cellspacing="0" border="0" style="height:100%; width:100%;">
	            <tr>
		            <td class="tableBorder">
		                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
		                    <tr>
		                        <td class="tableTitle" colspan="2" align="left" ><b>&nbsp;주관부서(평가조직)</b></td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style=" width:120px;"><b>평가기간</b></td>
			                    <td class="tableContent"  align="left">
			                        <asp:TextBox ID="txtEstTermRefId" runat="server" Width="100%" OnKeyPress="CheckKeys()" ReadOnly="true"></asp:TextBox>
			                    </td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style=" width:120px;" ><b>주관부서</b></td>
			                    <td class="tableContent" align="left">
			                        <asp:TextBox ID="txtEstDeptRefId" runat="server" Width="100%" OnKeyPress="CheckKeys()" ReadOnly="true"></asp:TextBox>
                                </td>
		                    </tr>
		                    <tr>
		                        <td class="tableTitle" colspan="2" align="left" ><b>&nbsp;중점과제 기본정보</b></td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:120px;"><b>중점과제 명칭 </b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <asp:Panel ID="pnlWorkPool" Width="100%" runat="server">
                                        <table  cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                            <tr>
                                                <td  align="left" valign="middle" style="width:100%;">
                                                    <asp:HiddenField ID="hdfWorkPoolRefId" runat="server" Value="" 
                                                        />
                                                    <asp:TextBox ID="txtWorkName" runat="server" Width="100%"  OnKeyPress="CheckKeys()" ReadOnly="true"></asp:TextBox> 
                                                       
                                                </td>
                                                <td align="left" valign="middle">
                                                    <img name="imgopenWorkPool" id="imgopenWorkPool" alt="" src="../images/btn/b_034.gif" 
                                                        style="cursor:hand; vertical-align:middle;" 
                                                        onclick="openWorkPool('hdfWorkPoolRefId','txtWorkName')" runat="server"/>
                                                </td>
                                            </tr>
                                        </table> 
                                    </asp:Panel>   
			                    </td>
			                </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style=" width:120px;"><b>중점과제 코드 </b></td>
			                    <td class="tableContent"  align="left">
                                    <asp:Panel ID="pnlWorkCode" runat="server" Width="100%">
                                        <table   cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                           <tr>
                                                <td  align="left" valign="middle" style="width:100%;">
                                                    <asp:TextBox ID="txtWorkCode" runat="server" Width="100%" 
                                                         OnKeyPress="CheckKeysIn()" ></asp:TextBox>
                                                    <asp:HiddenField ID="hdfchkWorkCode" runat="server" Value="" />    
                                                </td>
                                                <td align="left" valign="middle" > 

                                                    <asp:ImageButton ID="imgWorkCodeSearch"   ImageUrl="../images/btn/b_039.gif" 
                                                        runat="server" onclick="imgWorkCodeSearch_Click"  style="vertical-align:middle;"/>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
			                    </td>
		                    </tr>
                            <tr>
                                <td align="center" class="tableTitle"   style="height:200px; width:120px;"><b>중점과제 정의</b></td>
                                <td class="tableContent" align="left">
                                    <asp:Panel ID="pnlWorkDesc" runat="server" Width="100%">
                                        <FCKeditorV2:FCKeditor ID="txtWorkDesc" runat="server" BasePath="../_common/FCKeditor/"
                                            Height="200px" Width="100%" >
                                        </FCKeditorV2:FCKeditor>
                                        <span id="spnWorkDesc" visible="false" runat="server" style="height: 200px; width: 100%; overflow: auto;" ></span>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle" style=" width:120px;"><b>중점과제 관리자</b></td>
                                <td class="tableContent" align="left" >
                                    <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                        <tr>
                                            <td align="left" valign="middle" style="width:210px;">

                                                <asp:HiddenField ID="hdfWorkEmpDeptId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdfWorkEmpDeptIdName" runat="server" Value="" />
                                                <asp:HiddenField ID="hdfWorkEmpId" runat="server" Value="" />
                                                <asp:TextBox ID="txtWorkEmpIdName" runat="server" Width="200px"  OnKeyPress="CheckKeys()" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td  align="left" valign="middle" >
                                            
                                                <asp:Panel ID="pnlDeptEmp" runat="server" Width="100%">
                                                    <img id="imgDeptEmp" runat="server" alt="" src="../images/btn/b_008.gif" style="cursor:hand; vertical-align:middle;" 
                                                        onclick="openDeptEmp('hdfWorkEmpDeptId','hdfWorkEmpDeptIdName','hdfWorkEmpId','txtWorkEmpIdName')" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle" style=" width:120px;"><b>우선순위(중요도)</b></td>
                                <td class="tableContent" align="left" >
                                    <asp:DropDownList ID="ddlWorkPriority" runat="server" 
                                        CssClass="box01" 
                                        AutoPostBack="True" Width="210px" >
                                    </asp:DropDownList>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle" style=" width:120px;"><b>과제유형</b></td>
                                <td class="tableContent" align="left">
                                    <asp:DropDownList ID="ddlWorkType" runat="server" 
                                        CssClass="box01" 
                                        AutoPostBack="True" Width="210px"   >
                                    </asp:DropDownList>
                                            
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle" style="height:55px; width:120px;"><b>이슈사항</b></td>
                                <td class="tableContent" align="left" >
			                        <asp:TextBox ID="txtWorkIssue" runat="server" Width="99%" TextMode="MultiLine" Height="55"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle"  style="width:120px;">
                                    <b>관련파일</b><br />
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
                                <td class="tableContent" align="left"  >
                                    <asp:ListBox id="lbFileList" runat="server" height="71px" width="100%"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle"  style=" width:120px;"><b>사용여부</b></td>
                                <td class="tableContent" align="left"  >
                                    <asp:CheckBox ID="chkUseYN" runat="server" Text="사용합니다." AutoPostBack="True" 
                                        oncheckedchanged="chkUseYN_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="tableTitle"  style=" width:120px;"><b>완료여부</b></td>
                                <td class="tableContent" align="left"  >
                                    <asp:CheckBox ID="chkCompleteYN" runat="server" Text="완료합니다." />
                                </td>
                            </tr>
                           
                            <tr>
                                <td  class="tableContent" colspan="2" style="padding-bottom: 10px; padding-top: 10px; padding-right: 5px;">
                                    <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                        <tr>
                                            <td align="left" style="width:50%;">
                                	            <asp:ImageButton ID="iBtnNew" ImageUrl="../images/btn/b_141.gif" runat="server" onclick="iBtnNew_Click" />
                                            </td>
                                            <td align="right"  style="width:50%; padding: 0;">
                                               
                                                <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server" 
                                                    OnClick="iBtnInsert_Click" />
                                                <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" 
                                                    OnClick="iBtnUpdate_Click" />
                                                <asp:ImageButton ID="iBtnUndo" AlternateText="완료취소" ImageUrl="../images/btn/b_217.gif" runat="server" 
                                                    OnClick="iBtnUndo_Click" />
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

</div>


</form>
</body>
</html>