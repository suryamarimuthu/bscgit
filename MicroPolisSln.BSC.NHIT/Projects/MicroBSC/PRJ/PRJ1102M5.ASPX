<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1102M5.ASPX.cs" Inherits="PRJ_PRJ1102M5" %>


<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" src="/_common/js/common.js"></script>
    
<style type="text/css">
    body, html{
        height: 100%;
        width: 100%;

    }
</style>
<script type="text/javascript">

    function MouseOverHandler(gridName, id, objectType) {
        if (objectType == 0) {

            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);

            cell.style.cursor = 'hand';
        }
    }

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

    function openDeptEmp(strDeptKey, strDeptVal, strEmpKey, strEmpVal) {
        var estterm_ref_id = "";
        var url = "../ctl/ctl2109.aspx?DEPT_KEY=" + strDeptKey + "&DEPT_VAL=" + strDeptVal + "&EMP_KEY=" + strEmpKey + "&EMP_VAL=" + strEmpVal;

        gfOpenWindow(url, 750, 400, 'yes', 'no', 'svr2002_3');
        var f = document.forms[0];

    }

    //세부일정 수정화면 호출
    function OpenTaskModifyWindow() {

        var ugrd = igtbl_getGridById('<%= ugrdWorkTaskList.ClientID %>');
        var oRow = igtbl_getActiveRow(ugrd.Id);
        var EXEC_REF_ID = oRow.getCellFromKey("EXEC_REF_ID").getValue();
        var TASK_REF_ID = oRow.getCellFromKey("TASK_REF_ID").getValue();

        var workYN = 'U';

        var ICCB1 = "<%= this.ICCB4 %>";

        if (TASK_REF_ID == 0) {
            alert('실행과제 선택 후 수정 바랍니다.');
            return false;

        }
        else {

            var strURL = 'PRJ1102M3.aspx?iType=' + workYN + '&EXEC_REF_ID=' + EXEC_REF_ID + '&TASK_REF_ID=' + TASK_REF_ID + '&CCB1=' + ICCB1;
            gfOpenWindow(strURL, 720, 650, 'yes','no', 'PRJ1102M3');

            return false;
        }
    }

    //세부일정 추가화면 호출
    function OpenTaskInsertWindow() {

        var ESTTERM_REF_ID = "<%= this.IEstterm_Ref_ID %>";
        var EST_DEPT_REF_ID = "<%= this.IEst_Dept_Ref_ID %>";
        var EXEC_REF_ID = '<%= this.IExec_Ref_ID %>';
        var TASK_REF_ID = '';
        var workYN = 'A';

        var ICCB1 = "<%= this.ICCB4 %>";

        var strURL = 'PRJ1102M3.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&EXEC_REF_ID=' + EXEC_REF_ID + '&TASK_REF_ID=' + TASK_REF_ID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 720, 650, 'yes', 'no', 'PRJ1102M3');

        return false;
    }

    //관리항목 수정화면 호출
    function OpenItemModifyWindow() {

        var ESTTERM_REF_ID = "<%= this.IEstterm_Ref_ID %>";
        var EST_DEPT_REF_ID = "<%= this.IEst_Dept_Ref_ID %>";

        var ugrd = igtbl_getGridById('<%= ugrdWorkItemList.ClientID %>');
        var oRow = igtbl_getActiveRow(ugrd.Id);
        var EXEC_REF_ID = oRow.getCellFromKey("EXEC_REF_ID").getValue();
        var TASK_REF_ID = oRow.getCellFromKey("TASK_REF_ID").getValue();
        var ITEM_REF_ID = oRow.getCellFromKey("ITEM_REF_ID").getValue();
        var workYN = 'U';

        var ICCB1 = "<%= this.ICCB5 %>";

        if (ITEM_REF_ID == 0) {
            alert('관리항목 선택 후 수정 바랍니다.');
            return false;

        }
        else {

            var strURL = 'PRJ1102M4.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&EXEC_REF_ID=' + EXEC_REF_ID + '&TASK_REF_ID=' + TASK_REF_ID + '&ITEM_REF_ID=' + ITEM_REF_ID + '&CCB1=' + ICCB1;
            gfOpenWindow(strURL, 720, 720, 'yes', 'no', 'PRJ1102M4');

            return false;
        }
    }

    //관리항목 추가화면 호출
    function OpenItemInsertWindow() {

        var ESTTERM_REF_ID = "<%= this.IEstterm_Ref_ID %>";
        var EST_DEPT_REF_ID = "<%= this.IEst_Dept_Ref_ID %>";

        var EXEC_REF_ID = '<%= this.IExec_Ref_ID %>';
        var TASK_REF_ID = '';
        var ITEM_REF_ID = '';
        var workYN = 'A';

        var ICCB1 = "<%= this.ICCB5 %>";

        var strURL = 'PRJ1102M4.aspx?iType=' + workYN + '&ESTTERM_REF_ID=' + ESTTERM_REF_ID + '&EST_DEPT_REF_ID=' + EST_DEPT_REF_ID + '&EXEC_REF_ID=' + EXEC_REF_ID + '&TASK_REF_ID=' + TASK_REF_ID + '&ITEM_REF_ID=' + ITEM_REF_ID + '&CCB1=' + ICCB1;
        gfOpenWindow(strURL, 720, 720, 'yes', 'no', 'PRJ1102M4');

        return false;
    }

    function CheckKeys() // 문자입력 금지 함수 설정
    {
        event.keyCode = 0;
    }

    function CheckKeysUse() //상황에 따라 조절
    {
        var f = document.forms[0];
        if (f.chkUseYN.checked == false) {
            event.keyCode = 0;
        }
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

<body style="margin:0 0 0 0 ; background-color:#FFFFFF" onload="document.focus(); ">
<form id="form1" name="form1" runat="server" style="height:100%; width:100%;"  >
<div >
<table style="height: 100%; width: 100%;"  border="0" cellspacing="0" cellpadding="0">
    <tr style="height: 44px;">
        <td style="height: 44px;">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                    <td  valign="top" background="../images/title/popup_t_bg.gif"> 
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td style="height: 40px;" valign="top"><img alt="" src="../images/title/popup_t102.gif"/></td>
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
    <tr style="height: 60px;">
        <td  style="height: 60px; vertical-align:top">
	        <table  class="tableBorder" cellpadding="1" cellspacing="0" style="height:100%; width:100%;">
                <tr>
                    <td  class="tableContent" style="height: 20px;" colspan="4" align="left" >중점과제정보</td>
                </tr>
                <tr>
                    <td class="tableTitle2" align="center" style=" width:100px; height: 20px;"><b>평가기간</b></td>
                    <td class="tableContent"  align="left" style="width:300px;">
                        <asp:TextBox ID="txtEstTermRefIdName" Width="200px" runat="server"  OnKeyPress="CheckKeys()"  ></asp:TextBox>
                    </td>
                    <td class="tableTitle2" align="center" style=" width:100px; height: 20px;"><b>주관부서</b></td>
                    <td class="tableContent"  align="left">
                        <asp:TextBox ID="txtEstDeptRefIdName" Width="200px" runat="server" OnKeyPress="CheckKeys()"  ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tableTitle2" align="center" style=" width:100px; height: 20px;" ><b>중점과제</b></td>
                    <td class="tableContent" align="left" style="width: 300px;">
                        <asp:TextBox ID="txtWorkCode" Width="100px" runat="server"  OnKeyPress="CheckKeys()" ></asp:TextBox>
                        <asp:TextBox ID="txtWorkRefIdName" Width="180px" runat="server"  OnKeyPress="CheckKeys()" ></asp:TextBox>
                     </td>
                    <td class="tableTitle2" align="center" style="width: 100px; height: 20px;" ><b>관리자</b></td>
                    <td class="tableContent" align="left" >
                        <asp:TextBox ID="txtWorkEmp" Width="200px" runat="server"  OnKeyPress="CheckKeys()" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr >
        <td style="height:100%; vertical-align: top;">
         <div id="leftLayer" style="border: #F4F4F4 0 solid; DISPLAY: block; overflow: auto; position: static; width: 100%;  height: 100%;  ">
           <table class="tableBorder" cellpadding="1" cellspacing="0" style="height:100%; width:100%;">
                <colgroup>
                    <col width="100px" />
                    <col width="300px" />
                    <col width="100px" />
                    <col />
                </colgroup>
                <tr>
                    <td class="tableContent" colspan="4" align="left" >&nbsp;실행과제 기본정보</td>
                </tr>
                <tr style="height: 20px;">
                    <td class="tableTitle2" align="center"  style="height: 20px;"><b>실행과제 코드</b> </td>
                    <td class="tableContent"  align="left" style=" vertical-align: middle; "   >
                        <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                            <tr>
                              <asp:Panel ID="pnlExecCode" runat="server">
                              
                                <td style="width: 110px;">
                                    <asp:TextBox ID="txtExecCode" runat="server" Width="100px" OnKeyPress="CheckKeysIn()" ></asp:TextBox>
                                    <asp:HiddenField ID="hdfchkExecCode" runat="server" Value="" />
                                </td>
                              </asp:Panel>
                                <td style="width: 170px;">
                                    <asp:ImageButton ID="imgExecCodeSearch"   ImageUrl="../images/btn/b_039.gif" 
                                        runat="server" onclick="imgExecCodeSearch_Click" style="vertical-align:middle;" />
                                    <asp:HiddenField ID="hdfExecRefID" runat="server" Value=""  />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="tableTitle2" align="center" ><b>실행과제 명칭</b></td>
                    <td class="tableContent" align="left" valign="middle" >
                        <asp:TextBox ID="txtExecName" runat="server" Width="250px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="tableTitle2"   style="height:35px; "><b>실행과제 정의</b></td>
                    <td class="tableContent" align="left" colspan="3">
                        <asp:TextBox ID="txtExecDesc" runat="server" Width="99%" TextMode="MultiLine" Height="35px" OnKeyPress="CheckKeysUse()" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="tableTitle2"  style="height: 20px;"><b>실행과제 관리자</b></td>
                    <td class="tableContent" align="left" colspan="3" >
                        <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                            <tr>
                                <td align="left" valign="middle" style="width:410px;">
                                    <asp:HiddenField ID="hdfExecEmpDeptId" runat="server" />
                                    <asp:TextBox ID="txtExecEmpDeptIdName" runat="server" Width="200px"  OnKeyPress="CheckKeys()" ></asp:TextBox>
                                    <asp:HiddenField ID="hdfExecEmpId" runat="server" />
                                    <asp:TextBox ID="txtExecEmpIdName" runat="server" Width="200px"  OnKeyPress="CheckKeys()" ></asp:TextBox>
                                </td>
                                <td align="left" valign="middle" >
                                    <img id="Img1" alt="" src="../images/btn/b_008.gif" style="cursor:hand; vertical-align:middle;" 
                                        onclick="openDeptEmp('hdfExecEmpDeptId','txtExecEmpDeptIdName','hdfExecEmpId','txtExecEmpIdName')" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="tableTitle2" style="height: 150px;"><b>세부일정관리</b></td>
                    <td class="tableContent" colspan="3" style="vertical-align: top; height: 150px;">
                        <asp:Panel ID="pnlWorkTaskNotice" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="실행과제 등록 후 입력가능합니다." Font-Size="Larger" ForeColor="Red"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlWorkTaskList" runat="server">
                            
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                                <tr>
                                    <td class="tableContent" style="height: 100%; width: 100%;" >
                                        <ig:UltraWebGrid ID="ugrdWorkTaskList" runat="server"  Width="100%" 
                                            Height="100%" oninitializerow="ugrdWorkTaskList_InitializeRow" 
                                            oninitializelayout="ugrdWorkTaskList_InitializeLayout" >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                    
                                                        <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" 
                                                            EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부"  >
                                                            <Header Caption="사용여부">
                                                                <RowLayoutColumnInfo OriginX="0" />
                                                            </Header>
                                                            <HeaderStyle Wrap="True" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                            <CellTemplate>
                                                                <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" 
                                                                    imageurl="../images/icon_x.gif"></asp:image>
                                                            </CellTemplate>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="0" />
                                                            </Footer>
                                                        </ig:TemplatedColumn>
                                                        
                                                                                                          
                                                         <ig:TemplatedColumn BaseColumnName="TASK_NAME" 
                                                                            FooterText="" 
                                                                            HeaderText="세부일정명" 
                                                                            Key="TASK_NAME" 
                                                                            Width="200px"
                                                                            Hidden="false"  >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="세부일정명">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="TASK_WEIGHT" 
                                                                            FooterText="TASK_WEIGHT" 
                                                                            HeaderText="TASK_WEIGHT" 
                                                                            Key="TASK_WEIGHT" 
                                                                            Width="80px" Hidden="false" Format="#,###,###,###,###,###,##0.0" 
                                                                            DataType="System.Double"  >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="가중치(%)">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="TGT_STR_DATE" 
                                                                            FooterText="TGT_STR_DATE" 
                                                                            HeaderText="TGT_STR_DATE" 
                                                                            Key="TGT_STR_DATE" 
                                                                            Width="80px" Hidden="false"  Format="yyyy-MM-dd" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="시작일자">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                           
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="TGT_END_DATE" 
                                                                            FooterText="TGT_END_DATE" 
                                                                            HeaderText="TGT_END_DATE" 
                                                                            Key="TGT_END_DATE" 
                                                                            Width="80px" Hidden="false"  Format="yyyy-MM-dd">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="종료일자">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="TGT_COST" 
                                                                            FooterText="TGT_COST" 
                                                                            HeaderText="TGT_COST" 
                                                                            Key="TGT_COST" 
                                                                            Width="80px" Hidden="false" Format="#,###,###,###,###,###,##0" 
                                                                            DataType="System.Double">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="예산(원)">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="RST_STR_DATE" 
                                                                            FooterText="RST_STR_DATE" 
                                                                            HeaderText="RST_STR_DATE" 
                                                                            Key="RST_STR_DATE" 
                                                                            Width="80px" Hidden="false"  Format="yyyy-MM-dd">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="시작일자">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="RST_END_DATE" 
                                                                            FooterText="RST_END_DATE" 
                                                                            HeaderText="RST_END_DATE" 
                                                                            Key="RST_END_DATE" 
                                                                            Width="80px" Hidden="false"  Format="yyyy-MM-dd">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="종료일자">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="RST_COST" 
                                                                            FooterText="RST_COST" 
                                                                            HeaderText="RST_COST" 
                                                                            Key="RST_COST" 
                                                                            Width="80px" Hidden="false" Format="#,###,###,###,###,###,##0" 
                                                                            DataType="System.Double">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="비용(원)">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                           
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="PROG_RATE" 
                                                                            FooterText="PROG_RATE" 
                                                                            HeaderText="PROG_RATE" 
                                                                            Key="PROG_RATE" 
                                                                            Width="80px" Hidden="false" Format="#,###,###,###,###,###,##0.00" 
                                                                            DataType="System.Double" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="집행율(%)">
                                                                <RowLayoutColumnInfo OriginX="9" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                          
                                                        </ig:TemplatedColumn>
                                                       
                                                        <ig:TemplatedColumn BaseColumnName="ITEM_COUNT" 
                                                                            CellMultiline="Yes" 
                                                                            HeaderText="관리항목수"
                                                                            Key="ITEM_COUNT" 
                                                                            Width="80px" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="관리항목수">
                                                                <RowLayoutColumnInfo OriginX="10" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                            
                                                        </ig:TemplatedColumn>

                                                      
                                                        
                                                        <ig:TemplatedColumn BaseColumnName="EXEC_REF_ID" 
                                                                            FooterText="EXEC_REF_ID" 
                                                                            HeaderText="EXEC_REF_ID" 
                                                                            Key="EXEC_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true"  >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="EXEC_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="11" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </ig:TemplatedColumn>
                                                        
                                                         <ig:TemplatedColumn BaseColumnName="TASK_REF_ID" 
                                                                            FooterText="TASK_REF_ID" 
                                                                            HeaderText="TASK_REF_ID" 
                                                                            Key="TASK_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true"  >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="TASK_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="12" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                           
                                                        </ig:TemplatedColumn>
                                                        
                                                        
                                                    </Columns>
                                                    <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" 
                                                AllowDeleteDefault="Yes"  ReadOnly = "NotSet" 
                                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" Name="ugrdWorkTaskList" RowHeightDefault="20px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" 
                                                CellClickActionDefault="RowSelect" 
                                                TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                <GroupByBox>
                                                    <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                    Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </PagerStyle>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </BoxStyle>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <ClientSideEvents MouseOverHandler="MouseOverHandler" DblClickHandler="OpenTaskModifyWindow"  />
                                           </DisplayLayout>    
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableContent" style="height: 20px;" >
                                        <asp:Panel ID="pnlTaskBtn" runat="server">
                                            <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                                <tr>
                                                    <td class="tableContent"  style="width:80%;" align="left" >
                                                        <asp:ImageButton runat="server"  ID="iBtnWorkTaskRefresh" ImageUrl="../images/btn/b_133.gif" 
                                                                ImageAlign="AbsMiddle" onclick="iBtnWorkTaskRefresh_Click" />
                                                        <asp:Label ID="Label3" runat="server" Text="가중치 합계 : "></asp:Label>
                                                        <asp:Label ID="lblToWeight" runat="server" Text="0" ForeColor="Red" Font-Bold="True"></asp:Label>        
                                                    </td>
                                                    <td class="tableContent"  style="width:20%;" align="right" >
                                                        <asp:ImageButton ID="iBtnWorkTaskInsert" runat="server" ImageUrl="../images/btn/b_005.gif"  style="cursor:hand; vertical-align:middle;" OnClientClick="return OpenTaskInsertWindow();"/>
                                                       <%-- <img id="iBtnWorkTaskInsert" alt="" src="../images/btn/b_005.gif" style="cursor:hand; vertical-align:middle;" 
                                                                onclick="return OpenTaskInsertWindow();" runat="server" />--%>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="tableTitle2" style="height: 150px;"><b>업무기준<br/>(관리항목)</b></td>
                    <td class="tableContent" colspan="3" style="vertical-align: top; height: 150px;">
                        <asp:Panel ID="pnlWorkItemNotice" runat="server">
                            <asp:Label ID="Label2" runat="server" Text="실행과제 등록 후 입력가능합니다." Font-Size="Larger" ForeColor="Red"></asp:Label>
                        </asp:Panel>

                        <asp:Panel ID="pnlWorkItemList" runat="server">
                           
                            <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" style="width: 100%; height: 100%;">
                                <tr>
                                    <td  class="tableContent" style="height: 100%;" >
                                        <ig:UltraWebGrid ID="ugrdWorkItemList" runat="server"  Width="100%" 
                                            Height="100%" 
                                            oninitializerow="ugrdWorkItemList_InitializeRow" 
                                             >
                                            <Bands>
                                                <ig:UltraGridBand>
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                    
                                                        <ig:TemplatedColumn BaseColumnName="USE_YN" Key="USE_YN" 
                                                            EditorControlID="" Width="35px" FooterText="" HeaderText="사용여부">
                                                            <Header Caption="사용여부">
                                                                <RowLayoutColumnInfo OriginX="0" />
                                                            </Header>
                                                            <HeaderStyle Wrap="True" />
                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                            <CellTemplate>
                                                                <asp:image runat="server" id="imgUseYn" alt="" imagealign="AbsMiddle" 
                                                                    imageurl="../images/icon_x.gif"></asp:image>
                                                            </CellTemplate>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="0" />
                                                            </Footer>
                                                        </ig:TemplatedColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="EXEC_REF_ID" 
                                                                            FooterText="EXEC_REF_ID" 
                                                                            HeaderText="EXEC_REF_ID" 
                                                                            Key="EXEC_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="EXEC_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="TASK_REF_ID" 
                                                                            FooterText="TASK_REF_ID" 
                                                                            HeaderText="TASK_REF_ID" 
                                                                            Key="TASK_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="TASK_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="TASK_NAME" 
                                                                            FooterText="TASK_NAME" 
                                                                            HeaderText="TASK_NAME" 
                                                                            Key="TASK_NAME" 
                                                                            Width="200px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="세부일정명">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ITEM_REF_ID" 
                                                                            FooterText="ITEM_REF_ID" 
                                                                            HeaderText="ITEM_REF_ID" 
                                                                            Key="ITEM_REF_ID" 
                                                                            Width="80px"
                                                                            Hidden="true" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="ITEM_REF_ID">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ITEM_YMD" 
                                                                            FooterText="" 
                                                                            HeaderText="기준년월" 
                                                                            Key="ITEM_YMD" 
                                                                            Width="80px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="기준년월">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ITEM_NAME" 
                                                                            FooterText="" 
                                                                            HeaderText="관리항목명" 
                                                                            Key="ITEM_NAME" 
                                                                            Width="200px"
                                                                            Hidden="false" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="관리항목명">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ITEM_UNIT" 
                                                                            FooterText="ITEM_UNIT" 
                                                                            HeaderText="ITEM_UNIT" 
                                                                            Key="ITEM_UNIT" 
                                                                            Width="80px" Hidden="false">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="단위">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ITEM_TGT" 
                                                                            FooterText="ITEM_TGT" 
                                                                            HeaderText="ITEM_TGT" 
                                                                            Key="ITEM_TGT" 
                                                                            Width="80px" Hidden="false">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="목표값">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                        
                                                        <ig:UltraGridColumn BaseColumnName="ITEM_RST" 
                                                                            FooterText="ITEM_RST" 
                                                                            HeaderText="ITEM_RST" 
                                                                            Key="ITEM_RST" 
                                                                            Width="80px" Hidden="false">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"/>
                                                            <Header Caption="실적값">
                                                                <RowLayoutColumnInfo OriginX="9" />
                                                            </Header>
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                            <Footer Caption="">
                                                                <RowLayoutColumnInfo OriginX="9" />
                                                            </Footer>
                                                        </ig:UltraGridColumn>
                                                       
                                                        
                                                    </Columns>
                                                    <RowTemplateStyle  BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                    </RowTemplateStyle>
                                                </ig:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" 
                                                AllowDeleteDefault="Yes"
                                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate"
                                                HeaderClickActionDefault="SortMulti" Name="ugrdWorkItemList" RowHeightDefault="20px"
                                                RowSelectorsDefault="No" SelectTypeRowDefault="Extended" Version="4.00" ViewType="Flat" 
                                                CellClickActionDefault="RowSelect"
                                                TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                <GroupByBox>
                                                    <BoxStyle BackColor="whitesmoke" BorderColor="Window"></BoxStyle>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" BorderColor="#E5E5E5" ForeColor="White" Height="20px">
                                                    <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                    BorderWidth="3px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                    Width="100%">
                                                </FrameStyle>
                                                <Pager>
                                                    <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </PagerStyle>
                                                </Pager>
                                                <AddNewBox Hidden="False">
                                                    <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                    </BoxStyle>
                                                </AddNewBox>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <ClientSideEvents   MouseOverHandler="MouseOverHandler" DblClickHandler="OpenItemModifyWindow" />
                                            </DisplayLayout>    
                                        </ig:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableContent" style="height: 20px;" >
                                        <asp:Panel ID="pnlItemBtn" runat="server">
                                            <table cellpadding="0" cellspacing="0" border="0" style="height:100%; width:100%;">
                                                <tr>
                                                    <td class="tableContent"  style="width:50%;" align="left" >
                                                        <asp:ImageButton runat="server" ID="iBtnWorkItemRefresh" ImageUrl="../images/btn/b_133.gif" 
                                                            ImageAlign="AbsMiddle" onclick="iBtnWorkItemRefresh_Click" />
                                                    </td>
                                                    <td class="tableContent"  style="width:50%;" align="right" >
                                                        <asp:ImageButton ID="iBtnWorkItemInsert" runat="server" ImageUrl="../images/btn/b_005.gif" 
                                                            style="cursor:hand; vertical-align:middle;" OnClientClick="return OpenItemInsertWindow();" />
                                                        <%--<img id="iBtnWorkItemInsert" alt="" src="../images/btn/b_005.gif" style="cursor:hand; vertical-align:middle;" 
                                                                        onclick="return OpenItemInsertWindow();" runat="server"/>--%>
                                                       
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                   </td>
                                </tr>
                            </table> 
                        </asp:Panel>
                    </td>
                </tr>
                
                <tr>
                    <td align="center" class="tableTitle2" style="height:35px; "><b>이슈사항</b></td>
                    <td class="tableContent" align="left" colspan="3" >
                        <asp:TextBox ID="txtExecIssue" runat="server" Width="99%" TextMode="MultiLine" Height="35px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="tableTitle2"  ><b>관련파일</b></td>
                    <td class="tableContent" align="left" colspan="3" >
                        <asp:ListBox id="lbFileList" runat="server" height="45px" width="450px"></asp:ListBox>
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
                    <td align="center" class="tableTitle2"  style="height: 20px;" ><b>사용여부</b></td>
                    <td class="tableContent" align="left" colspan="3"  >
                        <asp:CheckBox ID="chkUseYN" runat="server" Text="사용합니다." oncheckedchanged="chkUseYN_CheckedChanged" AutoPostBack="True" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="tableTitle2"  style="height: 20px;" ><b>완료여부</b></td>
                    <td class="tableContent" align="left" colspan="3"  >
                        <asp:CheckBox ID="chkCompleteYN" runat="server" Text="완료되었습니다." />
                    </td>
                </tr>
                <tr>
                    <td  class="tableContent" colspan="4"  style="height: 20px;">
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
                                    <asp:ImageButton ID="iBtnUndo" AlternateText="완료취소" ImageUrl="../images/btn/b_217.gif" runat="server" 
                                        OnClick="iBtnUndo_Click" Visible="false" />
                                    <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" 
                                        OnClick="iBtnClose_Click" />       
                                           
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
         </div>
	    </td>
    </tr>
</table>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</div>


</form>
</body>
</html>