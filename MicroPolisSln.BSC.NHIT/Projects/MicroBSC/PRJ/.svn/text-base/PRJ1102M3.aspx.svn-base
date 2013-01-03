<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1102M3.aspx.cs" Inherits="PRJ_PRJ1102M3" ValidateRequest="false"  %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script src="../_common/js/jQuery/jquery-1.6.4.js" type="text/javascript"></script>
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

    function TextChanged() {
//        var tgt = document.getElementById('igtxttxtTgtCost').value;
//        var rst = document.getElementById('igtxttxtRstCost').value;
//        var rate = 0;

//        tgt = parseInt(tgt.toString().replace(',', ''));
//        rst = parseInt(rst.toString().replace(',', ''));

//        
//        if (tgt != 0 && rst != 0 )
//        {
//            rate = rst / tgt * 100;
//        }

////        document.getElementById('igtxttxtCostRate').value = rate;
//        document.getElementById('txtCostRate').value =  rate.toFixed(2);
       
        return true;
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

<table style="height: 100%; width: 100%;"  border="0" cellspacing="0" cellpadding="0">
    <tr style="height: 44px;">
        <td style="height: 44px;">
            <table style="width: 100%;  height: 100%;" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                    <td  valign="top" background="../images/title/popup_t_bg.gif"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td style="height: 40px;" valign="top"><img alt="" src="../images/title/popup_t103.gif"/></td>
                                <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif"/></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr> 
                                <td width="50%" height="4px;" bgcolor="FFC600"></td>
                                <td width="50%" bgcolor="00549C"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td   style="vertical-align:top">
	        <table cellpadding="2" cellspacing="0" border="0" style="height: 100%; width:100%;">
	            <tr>
		            <td class="tableOutBorder">
		                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
		                    <tr>
		                        <td colspan="4" align="left" >실행과제정보</td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center" style=" width:110px;" ><b>실행과제</b></td>
			                    <td class="tableContent" align="left" colspan="3">
			                        <asp:TextBox ID="txtExecRefIdName" runat="server" Width="90%" OnKeyPress="CheckKeys()" 
			                          class="textReadOnly" ></asp:TextBox>
                                </td>
		                    </tr>
		                    <tr>
		                        <td colspan="4" align="left" >&nbsp;세부일정 기본정보</td>
		                    </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>세부일정 명칭</b></td>
			                    <td class="tableContent" align="left" valign="middle" colspan="3">
			                        <asp:TextBox ID="txtTaskName" runat="server" Width="90%" ></asp:TextBox> 
			                    </td>
			                </tr>
                            <tr>
                                <td align="center" class="tableTitle"   style="height:250px; width:110px;"><b>세부일정 정의</b></td>
                                <td class="tableContent" align="left" colspan="3">
                                    <FCKeditorV2:FCKeditor ID="txtTaskDesc" runat="server" BasePath="../_common/FCKeditor/"
                                        Height="250px" Width="100%">
                                    </FCKeditorV2:FCKeditor>
                                    <span id="spnTaskDesc" visible="false" runat="server" style="height: 200px; width: 100%; overflow: auto;" ></span>
                                </td>
                            </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>세부일정 가중치</b></td>
			                    <td class="tableContent" align="left" valign="middle" colspan="3">
                                    <ig:WebNumericEdit ID="txtTaskWeight" runat="server" Width="120px" 
                                        Nullable="False" ValueText="0.0" 
                                        BorderColor="red" BorderWidth="2px" MaxValue="999999999999" MinValue="0" 
                                        ToolTip="가중치" NegativeForeColor="Magenta"
                                        Height="100%" NullText="0" MinDecimalPlaces="One" DataMode="Int">
                                    </ig:WebNumericEdit>
			                    </td>
			                </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>예산금액</b></td>
			                    <td class="tableContent" align="left" valign="middle" style="width: 130px;" >
			                        <ig:WebNumericEdit ID="txtTgtCost" runat="server" Width="120px"
                                        Nullable="False" 
                                        BorderColor="red" BorderWidth="2px" MaxValue="999999999999" MinValue="0" 
                                        ToolTip="예산금액" NegativeForeColor="Magenta"
                                        Height="100%" NullText="0" RegisterInitJavaScript="False">
                                        <ClientSideEvents TextChanged="TextChanged()" />
                                    </ig:WebNumericEdit>
			                    </td>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>목표기간</b></td>
			                    <td class="tableContent" align="left" valign="middle" >
			                        <table style="width:98%;">
                                        <tr>
                                            <td class="tableContent" align="left" valign="middle" style="width:120px;">
                                                <ig:WebDateChooser ID="calTgtStrDate" runat="server" NullDateLabel="" 
                                                    Format="Short" Value="">
                                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                </ig:WebDateChooser> 
                                            </td>
                                            <td class="tableContent" align="left" valign="middle" style="width:10px;">~</td>
                                            <td class="tableContent" align="left" valign="middle">
                                                <ig:WebDateChooser ID="calTgtEndDate" runat="server" NullDateLabel="" 
                                                    Format="Short" Value="" onvaluechanged="calTgtEndDate_ValueChanged" >
                                                    <AutoPostBack ValueChanged="True" />
                                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                </ig:WebDateChooser>  
                                            </td>
                                        </tr>
                                    </table>
			                    </td>
			                </tr>

		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>집행예산</b></td>
			                    <td class="tableContent" align="left" valign="middle" style="width: 130px;">
                                    <ig:WebNumericEdit ID="txtRstCost" runat="server" Width="120px"  
                                        Nullable="False" ValueText="0.0" 
                                        BorderColor="red" BorderWidth="2px" MaxValue="999999999999" MinValue="0" 
                                        ToolTip="집행예산" NegativeForeColor="Magenta"
                                        Height="100%" NullText="0">
                                         <ClientSideEvents TextChanged="TextChanged()" />
                                    </ig:WebNumericEdit>
			                    </td>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>실적 기간</b></td>
			                    <td class="tableContent" align="left" valign="middle">
			                        <table style="width:98%;">
                                        <tr>
                                            <td class="tableContent" align="left" valign="middle" style="width:120px;">
                                                <ig:WebDateChooser ID="calRstStrDate" runat="server" NullDateLabel="" Format="Short">
                                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                </ig:WebDateChooser>  
                                            </td>
                                            <td class="tableContent" align="left" valign="middle" style="width:10px;">~</td>
                                            <td class="tableContent" align="left" valign="middle" >
                                                <ig:WebDateChooser ID="calRstEndDate" runat="server" NullDateLabel="" 
                                                    Format="Short" onvaluechanged="calRstEndDate_ValueChanged">
                                                    <AutoPostBack ValueChanged="True" />
                                                    <CalendarLayout ShowMonthDropDown="False" ShowYearDropDown="False"></CalendarLayout>
                                                </ig:WebDateChooser> 
                                            </td>
                                        </tr>
                                    </table>
			                    </td>
			                </tr>
		                    <tr>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>예산집행율(%)</b></td>
			                    <td class="tableContent" align="left" valign="middle" style="width: 130px; " >
<%--			                        <ig:WebNumericEdit ID="txtCostRate" runat="server" Width="120px" 
                                        Nullable="False" ValueText="0.0" 
                                        BorderColor="red" BorderWidth="2px" MaxValue="999999999999" MinValue="0" 
                                        ToolTip="집행예산" NegativeForeColor="Magenta"
                                        Height="100%" NullText="0">
                                       
                                    </ig:WebNumericEdit>--%>
                                    <asp:TextBox ID="txtCostRate" runat="server" 
                              style="text-align: right; " class="textReadOnly" Width="120px" 
                              OnKeyPress="CheckKeys()"  ></asp:TextBox>
			                    </td>
			                    <td class="tableTitle" align="center"  style=" width:110px;"><b>진척율(%)</b></td>
			                    <td class="tableContent" align="left" valign="middle" >
			                        <ig:WebNumericEdit ID="txtDoRate" runat="server" Width="90px" 
                                        Nullable="False" ValueText="0.0" 
                                        BorderColor="red" BorderWidth="2px" MaxValue="100" MinValue="0" 
                                        ToolTip="진척율" NegativeForeColor="Magenta"
                                        Height="100%" NullText="0">
                                    </ig:WebNumericEdit>
			                    </td>
			                </tr>
			                
                            <tr>
                                <td align="center" class="tableTitle"  style="width:120px;"><b>관련파일</b></td>
                                <td class="tableContent" align="left"   colspan="3">
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
                                <td class="tableContent" align="left"  colspan="3" >
                                    <asp:CheckBox ID="chkUseYN" runat="server" Text="사용합니다." AutoPostBack="True" 
                                        oncheckedchanged="chkUseYN_CheckedChanged" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            
                            <tr>
                                <td  class="tableContent" colspan="4">
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

</div>


</form>
</body>
</html>

