<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0901M3.aspx.cs" Inherits="BSC_BSC0901M3" EnableEventValidation="false" EnableViewState="true" ValidateRequest="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>:: Sanction ::</title>
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    <script type="text/javascript" language="javascript">

        function OpenDraftPrint(estterm_ref_id, kpi_ref_id) {
            var app_ref_id = "0";
            var biz_type = "<%= Biz_Type.biz_type_kpi_doc %>";
            var url = "/BSC/BSC0901P1.aspx?DRAFT_STATUS=" + '<%= Biz_Type.app_draft_select %>' + "&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id + "&BIZ_TYPE=" + biz_type + "&APP_REF_ID=" + app_ref_id;
            //var url = "/BSC/BSC0901P1.aspx?DRAFT_STATUS=SS&ESTTERM_REF_ID=1000&KPI_REF_ID=1042&BIZ_TYPE=KRA&APP_CCB=linkBtnDraft&APP_REF_ID=0
            //gfOpenWindow(url, 900, 650, 'BSC0901P1');
            gfOpenWindow(url, 900, 650, 'no', 'no', 'BSC0901P1');

            return false;
        }
        function OpenResultDraftPrint(estterm_ref_id, kpi_ref_id, ymd) {
            var app_ref_id = "0";
            var biz_type = "<%= Biz_Type.biz_type_kpi_rst %>";
            var url = "/BSC/BSC0901P1.aspx?DRAFT_STATUS=" + '<%= Biz_Type.app_draft_select %>' + "&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id + "&BIZ_TYPE=" + biz_type + "&APP_REF_ID=" + app_ref_id + "&YMD=" + ymd;
            //gfOpenWindow(url, 900, 650, 'BSC0901P1');
            gfOpenWindow(url, 900, 650, 'yes', 'no', 'BSC0901P1');

            return false;            
        }
        
        function confirmReason() {
            if ('<%= this.IHISTORY_YN %>' == 'Y') {
                var objGrd = igtbl_getGridById("ugrdAppLine");
                var modifyLine = "";
                for (var i = 0; i < objGrd.Rows.length; i++) {
                    modifyLine += objGrd.Rows.getRow(i).getCellFromKey("EMP_REF_ID").getValue().toString() + ";"
                }
                if (modifyLine != '<%= this.IORIGINAL_LINE %>' && document.getElementById('txtUPDATE_REASON').value.replace(/^\s*|\s*$/g, '').replace(/\n/g, '').replace(/\r/g, '') == "") {
                    alert('결재라인 변경사유를 입력하세요!');
                    return false;
                }
            }
            if ('<%= this.IAPP_SELF_NOTUSE_YN %>' == 'y') {
                var objGrd = igtbl_getGridById("ugrdAppLine");
                var modifyLine = "";
                if (objGrd.Rows.length == 1) {
                    alert('자가결재가 허용되지 않았습니다.\n결재자를 지정해야합니다.');
                    return false;
                }
            }
            return true;
        }
        function ShowAppline()
        {
            var objLine = window.document.getElementById("divAreaAppLine");

            if (objLine != null)
            {
                if (objLine.style.display == "block")
                {
                    objLine.style.display    = "none";
                }
                else {
                    objLine.style.display    = "block";
                }
            }
            
            return false;
        }
        
        function AppLineMove(iType)
        {
            var objGrd = igtbl_getGridById("ugrdAppLine");
            var cntRow = (objGrd != null) ? objGrd.Rows.length-1 : 0;

            //---------------------------------------------- 현재, 이전, 다음,다다음행
            var CurrRow = objGrd.getActiveRow();
            var PrevRow = (CurrRow != null) ? CurrRow.getPrevRow() : null;
            var NextRow = (CurrRow != null) ? CurrRow.getNextRow() : null;
            var NNxtRow = (NextRow != null) ? NextRow.getNextRow() : null;
            //---------------------------------------------- 현재, 이전, 다음셀 순서
            var CurrNo  = (CurrRow != null) ? CurrRow.getCell(0).getValue() : 0;
            var PrevNo  = (PrevRow != null) ? PrevRow.getCell(0).getValue() : 0;
            var NextNo  = (NextRow != null) ? NextRow.getCell(0).getValue() : 0;
            //---------------------------------------------- 현재, 이전, 다음행의 Index
            var PrevIdx = (PrevRow != null) ? PrevRow.getIndex() : null;
            var CurrIdx = (CurrRow != null) ? CurrRow.getIndex() : null;
            var NextIdx = (NextRow != null) ? NextRow.getIndex() : null;
            
            if (CurrRow == null)
            {
                alert("결재선을 선택해주십시오");
                return false;
            }
            
            var CurrFlag = CurrRow.getCellFromKey("DEFAULT_YN").getValue();
            
            if (CurrFlag == "Y")
            {
                alert("필수결재선은 변경될 수 없습니다..");
                return false;
            }
            
            if (NextRow == null)
            {
                alert("기안자의 순서는 변경될 수 없습니다..");
                return false;
            }
            else
            {
                CurrFlag = NextRow.getCellFromKey("DEFAULT_YN").getValue();
                if (CurrFlag == "Y" && iType=="D")
                {
                    alert("필수결재선은 변경될 수 없습니다..");
                    return false;
                }
            }
            
            if (iType == "U") // Toward Up
            {
                if (PrevRow == null)
                {
                    alert("최상위결재선입니다.");
                    return false;
                }
                else
                {
                    PrevRow.getCell(0).setValue(CurrNo);
                    CurrRow.getCell(0).setValue(PrevNo);
                    
                    var dRowPrev = PrevRow.remove();
                    var dRowCurr = CurrRow.remove();
                    
                    objGrd.Rows.insert(dRowCurr, PrevIdx);
                    objGrd.Rows.insert(dRowPrev, CurrIdx);
                    
                    setLineType(objGrd);

                    var modifyLine = "";
                    for (var i = 0; i < objGrd.Rows.length; i++) {
                        modifyLine += objGrd.Rows.getRow(i).getCellFromKey("EMP_REF_ID").getValue().toString() + ";"
                    }
                    if ('<%= this.IHISTORY_YN %>' == 'Y') {
                        if (modifyLine != '<%= this.IORIGINAL_LINE %>') {
                            document.getElementById('divReason').style.display = "block";
                        }
                        else {
                            document.getElementById('divReason').style.display = "none";
                            document.getElementById('txtUPDATE_REASON').value = '';
                        }
                    }
                    
                    return false
                }
            }
            else if (iType=="D") // Toward Down
            {
                if (NNxtRow == null)
                {
                    alert("기안자의 순서는 변경될 수 없습니다..");
                    return false;
                }
                
                CurrRow.getCell(0).setValue(NextNo);
                NextRow.getCell(0).setValue(CurrNo);
                
                var dRowCurr = CurrRow.remove();
                var dRowNext = NextRow.remove();
                
                if (PrevIdx == null)
                {
                    objGrd.Rows.insert(CurrRow, 0);
                    objGrd.Rows.insert(NextRow, 0);
                }
                else
                {
                    //objGrd.Rows.insert(CurrRow, PrevIdx+1);
                    //objGrd.Rows.insert(NextRow, PrevIdx+1);
                    objGrd.Rows.insert(dRowNext, CurrIdx);
                    objGrd.Rows.insert(dRowCurr, NextIdx);
                    
                }
            }
            else if (iType == "R")
            {
                CurrRow.remove();
                NextRow.setSelected();
                NextRow.activate();
                
                var iRow = objGrd.Rows.length;
                for (var i=0; i < iRow; i++)
                {
                    objGrd.Rows.getRow(i).getCell(0).setValue(i+1);
                }
            }

            setLineType(objGrd);

            var modifyLine = "";
            for (var i = 0; i < objGrd.Rows.length; i++) {
                modifyLine += objGrd.Rows.getRow(i).getCellFromKey("EMP_REF_ID").getValue().toString() + ";"
            }
            if ('<%= this.IHISTORY_YN %>' == 'Y') {
                if (modifyLine != '<%= this.IORIGINAL_LINE %>') {
                    document.getElementById('divReason').style.display = "block";
                }
                else {
                    document.getElementById('divReason').style.display = "none";
                    document.getElementById('txtUPDATE_REASON').value = '';
                }
            }
            
            return false;
        }
        
        // 결재선에 선택된 사용자 추가
        function getSelectEmp()
        {
            var EmpGrd = igtbl_getGridById("ugrdEmpList");
            var LinGrd = igtbl_getGridById("ugrdAppLine");

            //---------------------------------------------- 결재선에 추가
            var EmpRow = EmpGrd.getActiveRow();
            
            if (EmpRow == null)
            {
                alert("사원을 선택해주십시오");
                return false;
            }
            else if (getIsAddEmp(EmpRow.getCellFromKey("EMP_REF_ID").getValue(), LinGrd))
            {
                alert("이미 추가된 사원입니다.");
                return false;
            }
            else
            {
                var nRow = LinGrd.Rows.addNew();
                
                if(LinGrd.Rows.insert(nRow.remove(),0))
                {
                    nRow.getCell(0).setValue(EmpRow.getCell(0).getValue());
                    nRow.getCell(1).setValue(EmpRow.getCell(1).getValue());
                    nRow.getCell(2).setValue(EmpRow.getCell(2).getValue());
                    nRow.getCell(3).setValue(EmpRow.getCell(3).getValue());
                    nRow.getCell(4).setValue("A");
                    nRow.getCell(5).setValue("N");
                    nRow.getCell(6).setValue("/");
                    nRow.getCell(7).setValue(EmpRow.getCell(7).getValue());
                    nRow.getCell(8).setValue("N");
                }
                
                setRowNum(LinGrd);
                setLineType(LinGrd);

                var modifyLine = "";
                for (var i = 0; i < LinGrd.Rows.length; i++) {
                    modifyLine += LinGrd.Rows.getRow(i).getCellFromKey("EMP_REF_ID").getValue().toString() + ";"
                }
                if ('<%= this.IHISTORY_YN %>' == 'Y') {
                    if (modifyLine != '<%= this.IORIGINAL_LINE %>') {
                        document.getElementById('divReason').style.display = "block";
                    }
                    else {
                        document.getElementById('divReason').style.display = "none";
                        document.getElementById('txtUPDATE_REASON').value = '';
                    }
                }
            }
            
            return false;
        }
        
        // 결재선 번호재지정
        function setRowNum(pGrid)
        {
            var iRow = pGrid.Rows.length;

            for (var i=0; i < iRow; i++)
            {
                pGrid.Rows.getRow(i).getCell(0).setValue(i+1);
            }
        }
        
        // 결재선 상태지정
        function setLineType(pGrid)
        {
            var iRow = pGrid.Rows.length;
            
            if (iRow == 1)
            {
                return;
            }
            
            for (var i=0; i < iRow; i++)
            {
                if (i == 0)
                {
                    pGrid.Rows.getRow(i).getCellFromKey("LINE_TYPE").setValue("A"); // 승인
                    pGrid.Rows.getRow(i).getCellFromKey("LINE_TYPE").setEditable(false);
                }
                else if (i == (iRow-1))
                {
                    pGrid.Rows.getRow(i).getCellFromKey("LINE_TYPE").setValue("D"); // 기안
                    pGrid.Rows.getRow(i).getCellFromKey("LINE_TYPE").setEditable(false);
                }
                else
                {
                    pGrid.Rows.getRow(i).getCellFromKey("LINE_TYPE").setValue("R") // 검토
                    pGrid.Rows.getRow(i).getCellFromKey("LINE_TYPE").setEditable(true);
                }
            }
        }
        
        // 추가된 사용자인지의 구분
        function getIsAddEmp(add_emp_id, pGrid)
        {
            var iRow   = pGrid.Rows.length;
            var emp_id = "";
            for (var i=0; i < iRow; i++)
            {
                emp_id = pGrid.Rows.getRow(i).getCellFromKey("EMP_REF_ID").getValue();
                if (add_emp_id == emp_id)
                {
                    return true;
                }
            }
            
            return false;
        }
        
        // 기안확정여부 확인
        function isConfirmDraft(App_Type) {
            if ('<%= this.IAPP_SELF_NOTUSE_YN %>' == 'Y') {
                var objGrd = igtbl_getGridById("ugrdAppLine");
                var modifyLine = "";
                if (objGrd.Rows.length == 1) {
                    alert('자가결재가 허용되지 않았습니다.\n결재자를 지정해야합니다.');
                    return false;
                }
            }
            
            if (document.form1.txtTitle.value == "")
            {
                alert("문서제목을 입력해주십시오");
                document.form1.txtTitle.focus();
                return false;
            }
            
            var status_name = "";
            if (App_Type == "D")
            {
                status_name = "상신";
            }
            else if (App_Type == "S")
            {
                status_name = "결재";
            }
            else if (App_Type == "R")
            {
                status_name = "반려";
            }
            
            // 상신시 의견입력만 필수입력사항
            // 결재시는 제외 (App_Type == "S" || )
            if (App_Type == "D")
            {
//                if (document.form1.txtAppOpinion.value == "")
//                {
//                    alert(status_name+"의견을 입력해주십시오")
//                    document.form1.txtAppOpinion.focus();
//                    return false;
//                }
                
                var iCol = parseInt('<%= (grvLineTable.HeaderRow ==null) ? 0 : grvLineTable.HeaderRow.Cells.Count %>');

                if (iCol < 1)
                {
                    alert("결재선을 지정해주십시오");
                    return false;
                }
            }
            else if (App_Type == "R")
            {
                if (document.form1.txtRtnReason.value == "")
                {
                    alert("반려사유을 입력해주십시오")
                    document.form1.txtRtnReason.focus();
                    return false;
                }
            }
            
            var msg = "문서를 "+ status_name +"하시겠습니까?";
            if (confirm(msg))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>

    <style type="text/css">
        /* 결재선 정보 */
        #divArea_T
        {
            position:absolute;
            height:120px;
            width:893px;
            left:0px;
            top:0px;
            background:#F0F0F0;
            margin-top:3px;
            margin-bottom:0px;
            margin-left:4px;
            margin-right:2px;
        }
            #divArea_T #divTitle 
            {
                position:absolute;
                top:20px;
                left:50px;
                vertical-align:middle;
                font-size:20pt;
                text-decoration:none;
                padding-top:5px;
            }
            #divArea_T #divSmallTitle 
            {
                position:absolute;
                left:5px;
                top:95px;
                vertical-align:middle;
                font-size:11pt;
                text-decoration:none;
                padding-top:5px;
            }
            #divArea_T #divAppLine
            {
                position:absolute;
                text-align:right;
                top:5px;
                right:5px;
                text-decoration:none;
                font-size:9pt;
                background-color:Transparent;
                border-width:0px;
            }
                #divArea_T #divAppLine table
                {
                    border-collapse:collapse;
                    border-width:0px;
                    background-color:Transparent;
                }
                #divArea_T #divAppLine th
                {
                    border-collapse:collapse;
                    text-align:center;
                    text-decoration:none;
                    font-size:9pt;
                    width:80px;
                    background-color:Transparent;
                    border:0px solid #333333;
                }                
                #divArea_T #divAppLine td
                {
                    border-collapse:collapse;
                    text-align:center;
                    text-decoration:none;
                    font-size:9pt;
                    width:80px;
                    background-color:#ffffff;
                    border:1px solid #C1CED4;
                }
        
        /* 결재 원문 */
        #divArea_M
        {
            border-collapse:collapse;
            position:absolute;
            height:415px;
            width:892px;
            left:0px;
            top:122px;
            background-color:white;
            margin-top:3px;
            margin-bottom:5px;
            margin-left:3px;
            margin-right:5px;
            border:1px outset #ddd;
            text-align:center;
            overflow:scroll;
        }
        #divArea_M table 
        {
            /* table-layout:fixed; 그리드가 깨짐으로 사용금지*/
            border-collapse:collapse;
            border:1px solid #ddd;
        }

        #divArea_M td 
        {
            border-collapse:collapse;
            text-align:center;
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            line-height:1.5em;
        }

        #divArea_M th 
        {
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            text-align:center;
            background:#f1f1f7;
            line-height:1.5em;
            padding:3px;
            height:22px;
            font-weight:normal;
        }
        
        #divArea_M table tr th 
        {
            border:1px solid #ccc;
            border-left:1px solid #ddd;
            border-right:1px solid #ddd;
            text-align:center;
            background:#F8F8F8;
            line-height:1.5em;
            padding:3px;
            height:18px;
            font-weight:normal;
        }
        
        #divArea_M td span
        {
            border:0px solid #ccc;
            text-align:left;
            background:#ffffff;
            line-height:1.5em;
            padding:1px;
            width:98%;
            display:inline;
        }
        
        /* 결재정보 입력란 */
        #divArea_B
        {
            position:absolute;
            height:103px;
            width:893px;
            left:0px;
            bottom:0px;
            background:#F0F0F0;
            margin-top:0px;
            margin-bottom:3px;
            margin-left:3px;
            margin-right:3px;
            border-top-width:3px;
            border-bottom-width:0px;            
        }
        #divArea_B #divAreaInput
        {
            position:absolute;
            height:103px;
            width:89%;
            left:0px;
            bottom:0px;
            background:#F0F0F0;
            margin-top:0px;
            margin-bottom:0px;
            margin-left:0px;
            margin-right:0px;
            border-top-width:1px;
            border-bottom-width:0px;
        }
            #divArea_B #divAreaInput input
            {
                position:relative;
                width:99%;
                height:99%;
                background:Transparent;
                margin-top:0px;
                margin-bottom:0px;
                margin-left:0px;
                margin-right:0px;
                border-width:1px;
                border-style:outset;
                text-decoration:underline;
                vertical-align:middle;
            }   
            #divArea_B #divAreaInput textarea
            {
                position:relative;
                width:99%;
                height:70px;
                background:Transparent;
                margin-top:0px;
                margin-bottom:0px;
                margin-left:0px;
                margin-right:0px;
                border-width:1px;
                border-top-width:0px;
                border-left-width:0px;
                border-right-width:0px;
                border-style:ridge;
                border-color:whitesmoke;
            }
            #divArea_B #divAreaInput input
            {
                position:relative;
                width:auto;
                height:auto;
                margin-top:0px;
                margin-bottom:0px;
                margin-left:0px;
                margin-right:0px;
                border-width:0px;
            }
        
        /* 결재선지정 */
        #divArea_B #divAreaAppLine
        {
            position:absolute;
            height:380px;
            width:650px;
            right:5px;
            bottom:110px;
            margin-top:0px;
            margin-bottom:0px;
            margin-left:0px;
            margin-right:0px;
            border-width:2px;
            border-color:#D3DBDE;
            display:none;
            border-collapse:collapse;
            background-color:#ffffff;
            text-align:left;
        }
            #divArea_B #divAreaAppLine table
            {
                border-collapse:collapse;
                border-width:2px;
                background-color:Transparent;
            }
            #divArea_B #divAreaAppLine th
            {
                border-collapse:collapse;
                text-align:center;
                text-decoration:none;
                font-size:9pt;
                background-color:#D3DBDE;
                border:0px solid #333333;
                font-weight:bold;
            } 
            #divArea_B #divAreaAppLine td
            {
                border-collapse:collapse;
                text-align:left;
                text-decoration:none;
                font-size:9pt;
                background-color:#ffffff;
                border:0px solid #C1CED4;
            }
        
        #divArea_B #divAreaButton
        {
            position:absolute;
            right:2px;
            bottom:0px;
            width:10%;
            height:100px;
            vertical-align:middle;
            background:Transparent;
            margin-top:0px;
            margin-bottom:0px;
            margin-left:0px;
            margin-right:0px;
            border-width:0px;
            border-style:none;
            text-align:right;
        }
            #divArea_B #divAreaButton input
            {
                position:relative;
                margin-top:0px;
                margin-bottom:0px;
                margin-left:0px;
                margin-right:5px;
                border-width:0px;
                border-style:none;
                display:block;
            }
        
        /* 테이블 스타일 지정 */
        .appTable
        { 
		    border-collapse: collapse;
		    text-align:center;
		    background-color:#ffffff;
		    cursor:hand;
		    border-width:0px;
        }
        .appTr
        {
            text-aligh:right;
            background-color:#D3DBDE;
        }        
        .appTh
        {
            text-aligh:right;
        }
        .appTd
        {
            text-aligh:left;
        }        
    </style>
</head>

<%--:#f5f5f5, D3DBDE--%>

  <body style="margin-top:0px; margin-left:0px; margin-bottom:0px; margin-right:0px; background-color:#ABB6CA;">
    <form id="form1" runat="server">
      <div id="divArea_T">
          <div id="divTitle" runat="server">
            <asp:Label ID="lblAppTitle" runat="server" Text="▒ 지표정의서 일괄결재 ▒"></asp:Label>
          </div>
          <div id="divSmallTitle">
            <img alt="" src="../images/icon/icon_kpi.gif" style="vertical-align:middle;" /> 결재항목 리스트
          </div>
          <div id="divAppLine">
              <asp:GridView ID="grvLineTable" runat="server" UseAccessibleHeader="false" AutoGenerateColumns="true" OnLoad="grvLineTable_Load" OnRowCreated="grvLineTable_RowCreated"></asp:GridView>                    
         </div>
      </div>
      <div id="divArea_M" runat="server">

      </div>
      <div id="divArea_B">
         <div id="divAreaInput">
             <table cellpadding="0" cellspacing="0" style="height:100%; width:100%; empty-cells:show; outline-style:solid; border-width:2px;">
               <tr>
                 <th style="width:90px; text-align:center; font-weight:bold;">문&nbsp;서&nbsp;번&nbsp;호</th>
                 <td style="width:130px;"><asp:TextBox ID="txtDocNo" runat="server" Text="-" ReadOnly="true" Width="98%"></asp:TextBox></td>
                 <th style="width:90px; text-align:center; font-weight:bold;">제&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;목</th>
                 <td><asp:TextBox ID="txtTitle" runat="server" Text="" Width="98%"></asp:TextBox></td>
               </tr>
               <tr>
                 <td colspan="4">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                      <tr>
                         <th id="th1" runat="server" style="width:60px; text-align:center; font-weight:bold;">결&nbsp;재&nbsp;의&nbsp;견</th>
                         <td id="td01" runat="server" style="width: 34%;"><asp:TextBox ID="txtAppOpinion" runat="server" Text="" TextMode="MultiLine"></asp:TextBox></td>
                         <th id="th2" runat="server" style="width:60px; text-align:center; font-weight:bold;">반&nbsp;려&nbsp;사&nbsp;유</th>
                         <td id="td02" runat="server" style="width: 33%;"><asp:TextBox ID="txtRtnReason" runat="server" Text="" TextMode="MultiLine"></asp:TextBox></td>
                         <th id="th3" runat="server" style="width:60px; text-align:center; font-weight:bold;" align="center">결&nbsp;&nbsp;재&nbsp;&nbsp;선<br />변&nbsp;경&nbsp;사&nbsp;유</th>
                         <td id="td03" runat="server" style="width: 33%;"><asp:TextBox ID="txtUPDATE_REASON2" runat="server" Text="" TextMode="MultiLine" ReadOnly="true"></asp:TextBox></td>
                      </tr>
                    </table>
                 </td>
               </tr>
             </table>
         </div>
         <div id="divAreaAppLine" runat="server">
           <table border="2" cellpadding="0" cellspacing="0" width="100%" style="height:100%;" class="appTable">
             <tr class="appTr">
               <td colspan="3" style="height:25px; background-image:url(../images/bg/bg_heading.png);"></td>
             </tr>
             <tr class="appTr">
               <td style="text-align:left; font-weight:bold;">&nbsp;☞조직정보</td>
               <td style="width:5%; vertical-align:middle; text-align:center;" align="center" rowspan="3">
                  <asp:ImageButton id="btnLineSelect" runat="server" ImageUrl="~/images/btn/btn_add_01.gif" OnClientClick="return getSelectEmp();" />
                  <asp:ImageButton id="btnRemove" runat="server" ImageUrl="~/images/btn/btn_add_02.gif" OnClientClick="return AppLineMove('R');" />
               </td>
               <td style="text-align:left; font-weight:bold;">&nbsp;☞결재선</td>
             </tr>
             <tr>
               <td style="width:38%; vertical-align:top; empty-cells:show;" rowspan="2">
                 <div id="divDeptTree" style="width:100%; height:180px; overflow:scroll;">
                     <asp:TreeView ID="trvDept" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" BorderWidth="0px"
                            OnSelectedNodeChanged="trvDept_SelectedNodeChanged" Width="100%" Height="100%" OnTreeNodeCheckChanged="trvDept_TreeNodeCheckChanged" ShowLines="false" >
                            <ParentNodeStyle Font-Bold="False" BorderWidth="0px" />
                            <SelectedNodeStyle BackColor="#E0E0E0" Font-Underline="False" HorizontalPadding="1px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px"
                                NodeSpacing="0px" VerticalPadding="0px" BorderWidth="0px" />
                            <RootNodeStyle BorderWidth="0px" />
                            <LeafNodeStyle BorderWidth="0px" />
                            <HoverNodeStyle BorderWidth="0px" />
                        </asp:TreeView>
                 </div>
                 <div id="divEmpList" style="width:100%; height:150px; overflow:scroll;">
	               <ig:ultrawebgrid id="ugrdEmpList" runat="server" width="100%" Height="100%" OnInitializeRow="ugrdAppLine_InitializeRow">
	                <Bands>
                        <ig:UltraGridBand>
                        <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                      <Columns>
                        <ig:UltraGridColumn Key="LINE_STEP" BaseColumnName="LINE_STEP" Width="20px" FooterText="" HeaderText="NO" SortingAlgorithm="QuickSort">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="NO" Title=""></Header>
                            <CellStyle horizontalalign="Center" verticalalign="Middle"></CellStyle>
                            <Footer Caption="">
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" Width="70px" Hidden="false">
                            <Header Caption="부서">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle horizontalalign="Left" verticalalign="Middle"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME" Width="60px">
                            <Header Caption="성명">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <CellStyle horizontalalign="Left" verticalalign="Middle"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" HeaderText="직책" Key="POSITION_RANK_NAME" Width="50px">
                            <Header Caption="직책">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <CellStyle horizontalalign="Left" verticalalign="Middle"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:TemplatedColumn Key="LINE_TYPE" BaseColumnName="LINE_TYPE" Width="0px" NullText="ZZZ" Hidden="True" HeaderText="유형">
                          <Header Caption="유형">
                              <RowLayoutColumnInfo OriginX="4" />
                          </Header>
                          <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                          <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            <CellTemplate>
                                <asp:DropDownList ID="ddlScore" runat="server" Width="100%"></asp:DropDownList>
                            </CellTemplate>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </ig:TemplatedColumn>
                        <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" HeaderText="COMPLETE_YN" Key="COMPLETE_YN" NullText="N" Width="60px" Hidden="true">
                            <Header Caption="처리여부">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <CellStyle horizontalalign="Center" verticalalign="Middle"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="TXR_DATE" HeaderText="TXR_DATE" Key="TXR_DATE" NullText="/" Width="60px" Hidden="true">
                            <Header Caption="처리일자">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <CellStyle horizontalalign="Center" verticalalign="Middle"></CellStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </ig:UltraGridColumn>
                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" HeaderText="empid">
                            <Header Caption="empid">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </ig:UltraGridColumn>
                    </Columns>
                   </ig:UltraGridBand>
                      </Bands>
                        <DisplayLayout CellPaddingDefault="2" Version="4.00" 
                         AllowSortingDefault="Yes" AllowColSizingDefault="Free" HeaderClickActionDefault="NotSet" SortingAlgorithmDefault="NotSet"
                         Name="ugrdEmpList" BorderCollapseDefault="Separate" RowHeightDefault="16px" AllowColumnMovingDefault="OnServer"
                         SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect" ColHeadersVisibleDefault="No"
                         SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header"
                         StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
                            <GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                            </GroupByBox>
                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                            </GroupByRowStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                <BorderDetails ColorTop="White" WidthTop="1px" />
                            </FooterStyleDefault>
                            <RowStyleDefault BackColor="White" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Cursor="Hand">
                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                <Padding Left="0px" />
                            </RowStyleDefault>
                            <RowSelectorStyleDefault BackColor="WhiteSmoke" BorderColor="White" Width="15px">
                               <Padding Bottom="0px" Left="0px" Right="0px" Top="0px" />
                            </RowSelectorStyleDefault>
                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                            </HeaderStyleDefault>
                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                            </EditCellStyleDefault>
                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                            </FrameStyle>
                            <Pager>
                                <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                </PagerStyle>
                            </Pager>
                            <AddNewBox Hidden="true">
                                <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                </BoxStyle>
                            </AddNewBox>
                            <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                            <ClientSideEvents DblClickHandler="getSelectEmp" />
                            <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>
                            <Images ImageDirectory="">
                            </Images>
                        </DisplayLayout>
                    </ig:ultrawebgrid>
                 </div>
               </td>
               <td style="width:57%; height: 280px; padding-right: 8px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 200px; vertical-align: top;">
                        <tr valign="top">
                            <td id="td1" valign="top" style="width: 100%; height: 230px;">
	                            <ig:ultrawebgrid id="ugrdAppLine" runat="server" width="100%" Height="100%" OnInitializeRow="ugrdAppLine_InitializeRow" OnInitializeLayout="ugrdAppLine_InitializeLayout">
                                    <Bands>
                                        <ig:UltraGridBand>
                                        <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                      <Columns>
                                        <ig:UltraGridColumn Key="LINE_STEP" BaseColumnName="LINE_STEP" Width="20px" FooterText="" HeaderText="선택" Hidden="false" AllowUpdate="No">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="NO" Title=""></Header>
                                            <CellStyle horizontalalign="Center" BackColor="whitesmoke" verticalalign="Middle"></CellStyle>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="부서" Key="DEPT_NAME" Width="120px" AllowUpdate="No">
                                            <Header Caption="부서">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <CellStyle horizontalalign="Left" verticalalign="Middle" BackColor="whitesmoke"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EMP_NAME" HeaderText="성명" Key="EMP_NAME" Width="45px" AllowUpdate="No">
                                            <Header Caption="성명">
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Header>
                                            <CellStyle horizontalalign="Center" verticalalign="Middle" BackColor="whitesmoke"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="1" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="POSITION_RANK_NAME" HeaderText="직책" Key="POSITION_RANK_NAME" Width="45px" AllowUpdate="No">
                                            <Header Caption="직책">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle horizontalalign="Center" verticalalign="Middle" BackColor="whitesmoke"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="LINE_TYPE" HeaderText="LINE_TYPE" Key="LINE_TYPE" Type="DropDownList" Width="60px">
                                            <Header Caption="유형">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle HorizontalAlign="Center" verticalalign="Middle"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ValueList Key="ddlLineType"></ValueList>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" HeaderText="COMPLETE_YN" Key="COMPLETE_YN" NullText="N" Width="60px" Hidden="true">
                                            <Header Caption="처리여부">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle horizontalalign="Center" verticalalign="Middle"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="TXR_DATE" HeaderText="TXR_DATE" Key="TXR_DATE" NullText="/" Width="60px" Hidden="true">
                                            <Header Caption="처리일자">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <CellStyle horizontalalign="Center" verticalalign="Middle"></CellStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="EMP_REF_ID" Hidden="True" Key="EMP_REF_ID" HeaderText="EMP_REF_ID">
                                            <Header Caption="EMP_REF_ID">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="DEFAULT_YN" Hidden="True" Key="DEFAULT_YN" HeaderText="DEFAULT_YN">
                                            <Header Caption="DEFAULT_YN">
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </ig:UltraGridColumn>
                                        <ig:UltraGridColumn BaseColumnName="LINE_TYPE_ORG" Hidden="true" Key="LINE_TYPE_ORG"></ig:UltraGridColumn>
                                    </Columns>
                                   </ig:UltraGridBand>
                                  </Bands>
                                    <DisplayLayout CellPaddingDefault="2" Version="4.00" 
                                     AllowSortingDefault="Yes" AllowColSizingDefault="Free" HeaderClickActionDefault="NotSet" SortingAlgorithmDefault="NotSet"
                                     Name="ugrdAppLine" BorderCollapseDefault="Separate" AllowDeleteDefault="No" AllowRowNumberingDefault="None" AllowAddNewDefault="Yes" AllowUpdateDefault="Yes"
                                     RowSelectorsDefault="Yes" RowHeightDefault="16px" AllowColumnMovingDefault="OnServer"
                                     SelectTypeRowDefault="Single" AutoGenerateColumns="False" CellClickActionDefault="RowSelect"
                                     SelectTypeCellDefault="Single" SelectTypeColDefault="Single" StationaryMargins="Header"
                                     StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed">
                                        <GroupByBox>
                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                        </GroupByBox>
                                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                            <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                        </GroupByRowStyleDefault>
                                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                            <BorderDetails ColorTop="White" WidthTop="1px" />
                                        </FooterStyleDefault>
                                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                            <Padding Left="2px" />
                                        </RowStyleDefault>
                                        <RowSelectorStyleDefault BackColor="whitesmoke" BorderColor="white" Width="15px">
                                           <Padding Bottom="0" Left="0" Right="0" Top="0" />
                                        </RowSelectorStyleDefault>
                                        <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                            ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                            GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                            RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />
                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White">
                                            <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                        </HeaderStyleDefault>
                                        <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                        </EditCellStyleDefault>
                                        <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                            BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="200px" Width="100%">
                                        </FrameStyle>
                                        <Pager>
                                            <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </PagerStyle>
                                        </Pager>
                                        <AddNewBox Hidden="true">
                                            <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                            </BoxStyle>
                                        </AddNewBox>
                                        <SelectedRowStyleDefault BackColor="#E2ECF4">
                                        </SelectedRowStyleDefault>
                                        <ClientSideEvents />
                                    </DisplayLayout>
                                </ig:ultrawebgrid>
                            </td>
                        </tr>
                        <tr valign="top" id="divReason" runat="server">
                            <td style="height: 70px; padding-bottom: 3px; padding-right: 3px; padding-top: 3px; width: 100%;" align="center">
                                <b style="color: Red;">&nbsp;☞변경사유</b>
                                <asp:TextBox ID="txtUPDATE_REASON" runat="server" TextMode="MultiLine" Width="98%" Height="40px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>         
                </td>
             </tr>
             <tr>
               <td align="right">
                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                   <tr>
                     <td align="left">
                         &nbsp;
                     </td>
                     <td align="right" style="text-align:right; padding-right: 5px;">
                         <asp:ImageButton id="btnToUp" runat="server" ImageUrl="~/images/btn/btn_add_03.gif" OnClientClick="return AppLineMove('U');" />
                         <asp:ImageButton id="btnToDown" runat="server" ImageUrl="~/images/btn/btn_add_04.gif" OnClientClick="return AppLineMove('D');"  />
                         <asp:ImageButton id="btnLineConfirm" runat="server" ImageUrl="~/images/btn/b_032.gif" OnClientClick="return confirmReason();" OnClick="btnLineConfirm_Click" />
                         <asp:ImageButton id="btnLineClose" runat="server" ImageUrl="~/images/btn/b_003.gif" OnClientClick="return ShowAppline();" />
                     </td>
                   </tr>
                 </table>
               </td>
             </tr>
           </table>
         </div>
         <div id="divAreaButton">
           <asp:ImageButton id="btnShowLine" runat="server" OnClientClick="return ShowAppline();" ImageUrl="~/images/btn/b_032.gif" Visible="false"  Width="89px" Height="19px" />
           <asp:ImageButton id="btnDraft" runat="server" ImageUrl="~/images/btn/b_021.gif" OnClick="btnDraft_Click" Visible="false" Width="83px" Height="19px" />
           <asp:ImageButton id="btnSanction" runat="server" ImageUrl="~/images/btn/b_022.gif" OnClick="btnSanction_Click" Visible="false" Width="61px" Height="19px" />
           <asp:ImageButton id="btnReturn" runat="server" ImageUrl="~/images/btn/b_024.gif" OnClick="btnReturn_Click" Visible="false" Width="61px" Height="19px" />
           <asp:ImageButton id="btnCancel" runat="server" ImageUrl="~/images/btn/b_003.gif" OnClientClick="window.close(); return false;" Width="61px" Height="19px" />
           <asp:DropDownList ID="ddlLineType" runat="server" Visible="false" ></asp:DropDownList>
           <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
         </div>
      </div>
    </form>
  </body>
</html>
