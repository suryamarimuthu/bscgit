﻿<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="EST110104_02.aspx.cs" Inherits="EST_EST110104_02" %>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>


<form id="form1" runat="server">
    <script id="Infragistics" type="text/javascript">    
        var reasonid;
        
        function resultClick(obj)
        {
            var aRow = igtbl_getRowById(igtbl_getRowIdFromCellId(obj.parentElement.id));
            if (aRow.getCellFromKey("KPI_CLASS_REF_ID").getValue() == "SCO")
            {
                var kpiID      = aRow.getCellFromKey("KPI_REF_ID").getValue();
                var strMM      = aRow.getCellFromKey("YMD").getValue();
                var intEST     = aRow.getCellFromKey("ESTTERM_REF_ID").getValue();
                
                var url = '../BSC/BSC0501M1.aspx?KPI_REF_ID=' + kpiID+'&YMD='+strMM+'&ESTTERM_REF_ID='+intEST + '&closeRefresh=F';
                gfOpenWindow(url
                            , 870
                            , 690
                            , 'no'
                            , 'no'
                            , 'BSC0501M1' + kpiID);
            }
            else
            {
                var kpiID      = aRow.getCellFromKey("KPI_REF_ID").getValue();
                //var Est_YN     = row.getCellFromKey("CHECK_YN").getValue();
                var Confirm_YN = "N";
                var strMM      = aRow.getCellFromKey("YMD").getValue();
                var intEST     = aRow.getCellFromKey("ESTTERM_REF_ID").getValue();
                
                var url = '../BSC/BSC0501M3.aspx?KPI_REF_ID=' + kpiID+'&YMD='+strMM+'&ESTTERM_REF_ID='+intEST + '&closeRefresh=F';

                gfOpenWindow(url
                            ,870
                            ,690
                            ,'no'
                            ,'no'
                            ,'Win5');
            }
            return false;
        }
        
        function kpiClick(obj)
        {
            var aRow = igtbl_getRowById(igtbl_getRowIdFromCellId(obj.parentElement.id));
            if (aRow.getCellFromKey("KPI_CLASS_REF_ID").getValue() == "SCO")
            {
                var kpiID           = aRow.getCellFromKey("KPI_REF_ID").getValue();
                var estterm_ref_id  = aRow.getCellFromKey("ESTTERM_REF_ID").getValue();
                
                var url             = '../BSC/BSC0302M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + "&closeRefresh=F";
                gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M1_' + kpiID);
            }
            else
            {
                var kpiID = aRow.getCellFromKey("KPI_REF_ID").getValue();
                var estterm_ref_id = aRow.getCellFromKey("ESTTERM_REF_ID").getValue();

                var url = '../BSC/BSC0302M2.aspx?iType=U&IS_TEAM_KPI=N&ESTTERM_REF_ID=' + estterm_ref_id + "&KPI_REF_ID=" + kpiID + "&closeRefresh=F";
                gfOpenWindow(url, 900, 645, 'yes', 'no', 'BSC0302M2');
            }
            return false;
        }
        
        function changeReason()
        {
            document.getElementById('<%= ibtnSave.ClientID %>').style.display = "block";
            document.getElementById('<%= ibtnSaveEst.ClientID %>').style.display = "none";
            document.getElementById('<%= ibtnConfirmEst.ClientID %>').style.display = "none";
        }
        
        function closeProcess(objid)
        {
            if (objid == "1") //종합실적보고
            {
                document.getElementById('<%= tdReport.ClientID %>').style.display = "none";
                document.getElementById('<%= ibtnViewReport.ClientID %>').style.display = "block";
                document.getElementById('<%= ibtnCloseReport.ClientID %>').style.display = "none";
            }
            if (objid == "3") //종합평가의견
            {
                document.getElementById('<%= tdEst.ClientID %>').style.display = "none";
                document.getElementById('<%= ibtnViewOpinion.ClientID %>').style.display = "block";
                document.getElementById('<%= ibtnCloseOpinion.ClientID %>').style.display = "none";
            }
            if (objid == "4") //피평가자의견
            {
                document.getElementById('<%= tdFeedBack.ClientID %>').style.display = "none";
                document.getElementById('<%= ibtnViewFeedBack.ClientID %>').style.display = "block";
                document.getElementById('<%= ibtnCloseFeedBack.ClientID %>').style.display = "none";
            }
            return false;
        }
        
        function viewProcess(objid)
        {
            if (objid == "1") //종합실적보고
            {
                document.getElementById('<%= tdReport.ClientID %>').style.display = "block";
                document.getElementById('<%= ibtnViewReport.ClientID %>').style.display = "none";
                document.getElementById('<%= ibtnCloseReport.ClientID %>').style.display = "block";
            }
            if (objid == "3") //종합평가의견
            {
                document.getElementById('<%= tdEst.ClientID %>').style.display = "block";
                document.getElementById('<%= ibtnViewOpinion.ClientID %>').style.display = "none";
                document.getElementById('<%= ibtnCloseOpinion.ClientID %>').style.display = "block";
            }
            if (objid == "4") //피평가자의견
            {
                document.getElementById('<%= tdFeedBack.ClientID %>').style.display = "block";
                document.getElementById('<%= ibtnViewFeedBack.ClientID %>').style.display = "none";
                document.getElementById('<%= ibtnCloseFeedBack.ClientID %>').style.display = "block";
            }
            return false;
        }
        
        function saveClick(objid)
        {
            switch (objid)
            {
                case "1_1"://종합실적보고저장
                    var target = FCKeditorAPI.GetInstance('txtReport'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("실적보고 내용을 입력하세요.");
                        return false;
                    }
                    return confirm("실적보고를 저장하시겠습니까?");
                    break;
                case "1_2": //종합실적보고확정
                    var target = FCKeditorAPI.GetInstance('txtReport'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("실적보고 내용을 입력하세요.");
                        return false;
                    }
                    return confirm("실적보고를 확정하시겠습니까?");
                    break;
                case "1_3": //종합실적보고확정 취소
                    return confirm("실적보고를 확정취소하시겠습니까?");
                    break;
                case "2_1": //평가의견 저장
                    var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
                    if (ugrd.Rows.length == 0)
                    {
                        alert("저장할 평가내용이 없습니다.");
                        return false;
                    }
                    for (var i = 0; i < ugrd.Rows.length; i++)
                    {
                        var tRow = ugrd.Rows.getRow(i);
                        var e = igtbl_getElementById(tRow.getCellFromKey("GRADE").Id).children(0);
                        if (e.selectedIndex == 0)
                        {
                            alert((i + 1).toString() + "번째 MBO가 선택된 등급이 없습니다. 등급을 선택하세요.");
                            return false;
                        }
                        if (e.selectedIndex == 1 || e.selectedIndex == e.length - 1)
                        {
                            if (tRow.getCellFromKey("GRADE_REASON").getValue() == null)
                            {
                                alert((i + 1).toString() + "번째 MBO의 등급이 최고 또는 최저등급입니다. 평가근거를 입력하세요.");
                                return false;
                            }
                            if (tRow.getCellFromKey("GRADE_REASON").getValue().replace(" ", "").length == 0)
                            {
                                alert((i + 1).toString() + "번째 MBO의 등급이 최고 또는 최저등급입니다. 평가근거를 입력하세요.");
                                return false;
                            }
                        }
                    }
                    var target = FCKeditorAPI.GetInstance('txtOpinion'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("종합 평가의견의 내용을 입력하세요.");
                        return false;
                    }
                    return confirm("현재 평가정보를 저장하시겠습니까?");
                    break;
                case "2_2": //평가의견 확정
                    var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
                    if (ugrd.Rows.length == 0)
                    {
                        alert("저장할 평가내용이 없습니다.");
                        return false;
                    }
                    for (var i = 0; i < ugrd.Rows.length; i++)
                    {
                        var tRow = ugrd.Rows.getRow(i);
                        var e = igtbl_getElementById(tRow.getCellFromKey("GRADE").Id).children(0);
                        if (e.selectedIndex == 0)
                        {
                            alert((i + 1).toString() + "번째 MBO가 선택된 등급이 없습니다. 등급을 선택하세요.");
                            return false;
                        }
                        if (e.selectedIndex == 1 || e.selectedIndex == e.length - 1)
                        {
                            if (tRow.getCellFromKey("GRADE_REASON").getValue() == null)
                            {
                                alert((i + 1).toString() + "번째 MBO의 등급이 최고 또는 최저등급입니다. 평가근거를 입력하세요.");
                                return false;
                            }
                            if (tRow.getCellFromKey("GRADE_REASON").getValue().replace(" ", "").length == 0)
                            {
                                alert((i + 1).toString() + "번째 MBO의 등급이 최고 또는 최저등급입니다. 평가근거를 입력하세요.");
                                return false;
                            }
                        }
                    }
                    var target = FCKeditorAPI.GetInstance('txtOpinion'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("종합 평가의견의 내용을 입력하세요.");
                        return false;
                    }
                    return confirm("현재 평가를 확정하시겠습니까?");
                    break;
                case "2_3": //평가의견 확정 취소
                    return confirm("종합 평가의견 확정취소하시겠습니까?");
                    break;
                case "3_1": //피평가자의견 저장
                    var target = FCKeditorAPI.GetInstance('txtFeedBack'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("의견내용을 입력하세요.");
                        return false;
                    }
                    return confirm("피평가자 의견을 저장하시겠습니까?");
                    break;
                case "3_2": //피드백의견 확정
                    var target = FCKeditorAPI.GetInstance('txtFeedBack'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("의견내용을 입력하세요.");
                        return false;
                    }
                    return confirm("피평가자 의견을 확정하시겠습니까?");
                    break;
                case "3_3": //피드백의견 거절(이의신청)
                    var target = FCKeditorAPI.GetInstance('txtFeedBack'); 
                    var c = target.GetXHTML(true);
                    if (c.length == 0)
                    {
                        alert("이의신쳥 내용을 입력하세요.");
                        return false;
                    }
                    return confirm("현재평가에 대해 이의신청 하시겠습니까?");
                    break;
                default:
                    return false;
                    break;
            }
        }
        
        function mboSave()
        {
            //검증(최고, 최저평가등급에 대한 평가근거 등록여부
            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            var gradeCnt = 0;
            for (var i = 0; i < ugrd.Rows.length; i++)
            {
                var tRow = ugrd.Rows.getRow(i);
                var e = igtbl_getElementById(tRow.getCellFromKey("GRADE").Id).children(0);
                if (e.selectedIndex > 0)
                    gradeCnt++;
                if (e.selectedIndex == 1 || e.selectedIndex == e.length - 1)
                {
                    if (tRow.getCellFromKey("GRADE_REASON").getValue() == null)
                    {
                        alert((i + 1).toString() + "번째 MBO의 등급이 최고 또는 최저등급입니다. 평가근거를 입력하세요.");
                        return false;
                    }
                    if (tRow.getCellFromKey("GRADE_REASON").getValue().replace(" ", "").length == 0)
                    {
                        alert((i + 1).toString() + "번째 MBO의 등급이 최고 또는 최저등급입니다. 평가근거를 입력하세요.");
                        return false;
                    }
                }
            }
            if (gradeCnt == 0)
            {
                alert("평가된 정보가 없습니다.");
                return false;
            }
            return confirm('평가된 정보를 저장하시겠습니까?');
        }
        
        function processClick(objID)
        {
            if (objID == "1") //종합실적보고 진행
            {
                if (document.getElementById('<%= tdReport.ClientID %>').style.display == "none")
                {
                    if ('<%= this.IRESULT_APP_GET %>' != "1")
                    {
                        alert("해당 KPI중 실적결재가 미완료된 내역이 있습니다.");
                        return false;
                    }
                    document.getElementById('<%= tdReport.ClientID %>').style.display = "block";
                    if ('<%= IREPORT_STATUS %>' != "C")
                    {
                        var target = FCKeditorAPI.GetInstance('txtReport')
                        target.Focus();
                    }
                    document.getElementById('<%= ibtnReport.ClientID %>').src = "../images/btn/b_003.gif";
                }
                else
                {
                    document.getElementById('<%= tdReport.ClientID %>').style.display = "none";
                    document.getElementById('<%= ibtnReport.ClientID %>').src = "../images/btn/b_001.gif";
                }
                return false;
            }
            else if (objID == "2") //평가 진행
            {
                return confirm("평가를 시작하시겠습니까?");
            }
            else if (objID == "3") //종합평가의견 확정
            {
                if (document.getElementById('<%= tdEst.ClientID %>').style.display == "block")
                {
                    document.getElementById('<%= tdEst.ClientID %>').style.display = "none";
                    document.getElementById('<%= ibtnOpinion.ClientID %>').src = "../images/btn/b_001.gif";
                }
                else
                {
                    document.getElementById('<%= tdEst.ClientID %>').style.display = "block";
                    document.getElementById('<%= ibtnOpinion.ClientID %>').src = "../images/btn/b_003.gif";
                }
                return false;
            }            
            else if (objID == "4") //피드백평가 진행
            {
                if (document.getElementById('<%= tdFeedBack.ClientID %>').style.display == "block")
                {
                    document.getElementById('<%= tdFeedBack.ClientID %>').style.display = "none";
                    document.getElementById('<%= ibtnFeedBack.ClientID %>').src = "../images/btn/b_001.gif";
                    return false;
                }
                else
                {
                    document.getElementById('<%= tdFeedBack.ClientID %>').style.display = "block";
                    document.getElementById('<%= ibtnFeedBack.ClientID %>').src = "../images/btn/b_003.gif";
                    return false;
                }
            }
        }
        
        function mfUpload(hAttachNo, strUpDown)
        {
            <%
            /*
                Argument설명
                    : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                    : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
            */
            %>
            //수정(20060707 이승주)
            //var oAttach = gfGetFindObj("hAttachNo");
            var oAttach = gfGetFindObj(hAttachNo);
            var oaArg   = new Array("FILE", "MBOREP", (oAttach==null ? "" : oAttach.value));
            
            var oReturn = "";
            if (strUpDown == "UP")
            {
                oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 485, 307);
            }
            else
            {
                oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307);
            }
            
            if (oReturn != "" && oReturn != undefined && oReturn.length > 5)
            {
                oAttach.value = oReturn;
                //__doPostBack('lBtnReload', '');
            }
            else
            {
                alert("파일첨부를 하지 않았습니다!");
            }
            return false;
        }
        
        function SelectEmp()
        {
            gfOpenWindow( "EST_EMP.aspx?ESTTERM_REF_ID="	    + '<%= IESTTERM_REF_ID %>'
                                    + "&CTRL_DEPT_VALUE_NAME="	+ "hdfDeptRefId"
                                    + "&CTRL_DEPT_TEXT_NAME="	+ "txtDeptName"
                                    + "&CTRL_EMP_VALUE_NAME="	+ "hdfEmpRefId"
                                    + "&CTRL_EMP_TEXT_NAME="	+ "txtEmpName"
                                   , 700
                                   , 400
                                   , false
                                   , false
                                   , "popup_select_emp" );
            return false;
        }
        
        function gradeChange(obj)
        {
            document.getElementById('<%= ibtnSaveEst.ClientID %>').style.display = "none";
            document.getElementById('<%= ibtnConfirmEst.ClientID %>').style.display = "none";
            document.getElementById('<%= ibtnSave.ClientID %>').style.display = "block";
            var ugrd = igtbl_getGridById('<%= ugrdMBO.ClientID %>');
            var aRow = igtbl_getRowById(igtbl_getRowIdFromCellId(obj.parentElement.id));
            
            var e = document.getElementById(obj.id);
            
            var e2 = document.getElementById('<%= ddlGradePoint_hdf.ClientID %>');
            var oripoint = parseFloat(e2.options[e.selectedIndex].text);
            var weight = parseFloat(aRow.getCellFromKey("WEIGHT").getValue());
            aRow.getCellFromKey("SCORE_WEIGHT").setValue(oripoint * weight / 100);
            aRow.getCellFromKey("SCORE_ORI").setValue(oripoint);
            
            if (e.selectedIndex == 1 || e.selectedIndex == e.length - 1)
            {
                var btn = igtbl_getElementById(aRow.getCellFromKey("EST_REASON").Id).children(0);
                //btn.style.backgroundColor = "#1A72AC";
                //btn.value = "입력";
                btn.style.display = "block";
            }
            else
            {
                var btn = igtbl_getElementById(aRow.getCellFromKey("EST_REASON").Id).children(0);
                //btn.style.backgroundColor = "White";
                //btn.value = "";
                btn.style.display = "none";
                aRow.getCellFromKey("GRADE_REASON").setValue("");
            }
            
            var tottalvalue = 0.0;
            for (var i = 0; i < ugrd.Rows.length; i++)
            {
                var tRow = ugrd.Rows.getRow(i);
                tottalvalue += parseFloat((tRow.getCellFromKey("SCORE_WEIGHT").getValue() == null ? 0 : tRow.getCellFromKey("SCORE_WEIGHT").getValue()));
            }
            document.getElementById('lblTotalPoint').innerText = tottalvalue;
        }
        
        function reasonClick(obj)
        {
            var aRow = igtbl_getRowById(igtbl_getRowIdFromCellId(obj.parentElement.id));
            var e = igtbl_getElementById(aRow.getCellFromKey("GRADE").Id).children(0);
            if (e.selectedIndex == 0)
                return false;
            document.getElementById('txtGRADE_REASON').value = (aRow.getCellFromKey("GRADE_REASON").getValue() == null ? "" : aRow.getCellFromKey("GRADE_REASON").getValue().replace('/\r\n/g', "<br />"));
            var divReason = document.getElementById('divReason');
            divReason.style.zIndex = 1;
            divReason.style.display = "block";
            reasonid = obj;
            document.getElementById('<%= txtGRADE_REASON.ClientID %>').focus();
            return false;
        }
        
        function reasonConfirm()
        {
            var divReason = document.getElementById('divReason');
            divReason.style.zIndex = -1;
            divReason.style.display = "none";
            var aRow = igtbl_getRowById(igtbl_getRowIdFromCellId(reasonid.parentElement.id));
            aRow.getCellFromKey("GRADE_REASON").setValue(document.getElementById('txtGRADE_REASON').value);
            return false;
        }
    </script>
    <div style="position: absolute; z-index: 1; width: 100%; height: 100%;">
        <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
        <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
        <!--- MAIN START --->
        <table cellpadding="0" cellspacing="2" border="0" style="width: 100%; height: 100%;">
            <tr style="height: 95%;">
                <td style="height: 100%;" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                        <tr>
                            <td style="height: 25px; width: 100%;">
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 25px">
                                    <tr>
                                        <td style="height: 25px;" align="left" valign="middle" colspan="3">
                                            <img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>MBO 평가</b>
                                        </td>
                                        <td align="right" colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%;" valign="top">
                                <div style="overflow: auto; height: 100%; vertical-align: top; ">
                                <table cellpadding="0" cellspacing="0" border="0" style="height: 100%; width: 100%; vertical-align: top;">
                                    <tr valign="top">
                                        <td style="height: 20px; padding-bottom: 1px;" class="tableBorder">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td width="90px" align="center" class="tableTitle">평가기간</td>
                                                    <td width="320px" class="tableContent">
                                                        <asp:label id="lblCompTitle" runat="server"></asp:label>
                                                        <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" onselectedindexchanged="ddlCompID_SelectedIndexChanged" width="0%"></asp:dropdownlist>
                                                        <asp:dropdownlist id="ddlEstTerm" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTerm_SelectedIndexChanged" runat="server" width="70%" Enabled="false"></asp:dropdownlist><asp:DropDownList id="ddlEstTermSubID" runat="server" class="box01" AutoPostBack="True" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" width="29%" Enabled="false"></asp:dropdownlist>
                                                    </td>
                                                    <td width="90px" align="center" class="tableTitle">피평가자</td>
                                                    <td width="230px" class="tableContent">
                                                        <asp:TextBox id="txtDEPTNAME" ReadOnly="true" runat="server" width="64%"></asp:TextBox>
                                                        <asp:TextBox id="txtEMPNAME" ReadOnly="true" runat="server" width="32%"></asp:TextBox>
                                                        <asp:HiddenField id="hdfDeptRefId" runat="server"></asp:HiddenField>
                                                        <asp:HiddenField id="hdfEmpRefId" runat="server"></asp:HiddenField>
                                                        <asp:HiddenField id="hdfEmpName" runat="server"></asp:HiddenField>
                                                        <asp:HiddenField id="hdfDeptName" runat="server"></asp:HiddenField>
                                                    </td>
                                                    <td width="90px" style="padding-left: 3px;">
                                                        <asp:ImageButton id="ibtnEmpSearch" runat="server" imageUrl="../images/btn/b_008.gif" onClientClick="return SelectEmp();" ImageAlign="AbsMiddle"></asp:ImageButton>
                                                    </td>
                                                    <td align="left" style="padding-right: 8px;">
                                                        <asp:ImageButton id="ibtnSearch" onclick="ibtnSearch_Click" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="padding-top: 1px; padding-right: 8px; width: 100%; height: 100%;">
                                            <ig:UltraWebGrid ID="ugrdMBO" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdMBO_InitializeRow" OnInitializeLayout="ugrdMBO_InitializeLayout" >
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_CODE" Key="KPI_CODE" Width="40px" HeaderText="CODE">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="0" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="COM_DEPT_NAME" Key="COM_DEPT_NAME" Width="100px" HeaderText="운영조직">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="1" /></Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_NAME" Key="KPI_NAME" Width="230px" HeaderText="KPI명">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="2" /></Header>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EMP_NAME" Key="EMP_NAME" Width="45px" HeaderText="담당자">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="3" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" Key="KPI_GROUP_NAME" Width="60px" HeaderText="지표유형">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="4" /></Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CLASS_NAME" Key="CLASS_NAME" Width="60px" HeaderText="지표구분">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="5" /></Header>
                                                                <CellStyle HorizontalAlign="Left">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="CATEGORY_NAME" Key="CATEGORY_NAME" Width="60px" HeaderText="직무분류">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="6" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="UNIT_NAME" Key="UNIT_NAME" Width="30px" HeaderText="단위">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="7" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WEIGHT" Key="WEIGHT" Width="40px" Format="###,###,##0.####" HeaderText=" 가중치">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="8" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TARGET_TS" Key="TARGET_TS" Width="40px" Format="###,###,##0.####" HeaderText="목표">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header><RowLayoutColumnInfo OriginX="9" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="RESULT_TS" Key="RESULT_TS" Width="40px" Format="###,###,##0.####" HeaderText="실적">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="10" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ACHIEVEMENT_RATE" Key="ACHIEVEMENT_RATE" Width="45px" Format="###,###,##0.#" HeaderText="달성율">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="11" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="GRADE_S" Key="GRADE_S" Width="50px" Format="###,###,##0.####" HeaderText="S">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="12" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="GRADE_A" Key="GRADE_A" Width="50px" Format="###,###,##0.####" HeaderText="A">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="13" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="GRADE_B" Key="GRADE_B" Width="50px" Format="###,###,##0.####" HeaderText="B">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="14" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="GRADE_C" Key="GRADE_C" Width="50px" Format="###,###,##0.####" HeaderText="C">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="15" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="GRADE_D" Key="GRADE_D" Width="50px" Format="###,###,##0.####" HeaderText="D">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="16" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" Width="30px" HeaderText="결재<br />상태">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="17" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="SCORE_WEIGHT" Key="SCORE_WEIGHT" Format="###,###,##0.####" Width="30px" HeaderText="점수">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="18" /></Header>
                                                                <CellStyle HorizontalAlign="Right">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:TemplatedColumn BaseColumnName="GRADE" Key="GRADE" Width="60px" HeaderText="등급">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="19" /></Header>
                                                                <CellTemplate>
                                                                    <asp:dropdownlist id="ddlGrade" runat="server" width="100%" class="box01" onchange="gradeChange(this)"></asp:DropDownList>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="EST_REASON" Key="EST_REASON" Width="70px" HeaderText="평가근거">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="20" /></Header>
                                                                <CellTemplate>
                                                                    <%--<asp:button id="btnReason222" OnClientClick="return reasonClick(this);" Text="입력" runat="server" Width="100%" Height="18px" BackColor="#1A72AC" ForeColor="White" />--%>
                                                                    <asp:Image id="btnReason" OnClick="return reasonClick(this);" imageUrl="../images/btn/b_001.gif" runat="server" style="cursor: pointer;"></asp:Image>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="RESULT" Key="RESULT" Width="70px" HeaderText="실적">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="21" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <%--<asp:button id="btnResult222" OnClientClick="return resultClick(this);" Text="실적" runat="server" Width="100%" Height="18px" BackColor="#1A72AC" ForeColor="White" />--%>
                                                                    <asp:Image id="btnResult" OnClick="return resultClick(this);" imageUrl="../images/btn/b_307.gif" runat="server" style="cursor: pointer;"></asp:Image>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            <ig:TemplatedColumn BaseColumnName="TARGET" Key="TARGET" Width="80px" HeaderText="정의서">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                <Header><RowLayoutColumnInfo OriginX="22" /></Header>
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <CellTemplate>
                                                                    <%--<asp:button id="btnKpi222" OnClientClick="return kpiClick(this);" Text="정의서" runat="server" Width="100%" Height="18px" BackColor="#1A72AC" ForeColor="White" />--%>
                                                                    <asp:Image id="btnKpi" OnClick="return kpiClick(this);" imageUrl="../images/btn/b_306.gif" runat="server" style="cursor: pointer;"></asp:Image>
                                                                </CellTemplate>
                                                            </ig:TemplatedColumn>
                                                            
                                                            <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Key="EST_DEPT_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="SCORE_ORI" Key="SCORE_ORI" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="GRADE_REASON" Key="GRADE_REASON" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_CLASS_REF_ID" Key="KPI_CLASS_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="KPI_GROUP_REF_ID" Key="KPI_GROUP_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="#E5E5E5" BorderStyle="Solid">
                                                            <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout CellPaddingDefault="0" 
                                                    AllowColSizingDefault="Free"
                                                    AllowColumnMovingDefault="None" 
                                                    AllowDeleteDefault="No"
                                                    AllowSortingDefault="Yes" 
                                                    BorderCollapseDefault="Separate"
                                                    HeaderClickActionDefault="NotSet"
                                                    Name="ugrdMBO" 
                                                    RowHeightDefault="22px" 
                                                    HeaderStyleDefault-Height="23px"
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended" 
                                                    Version="4.00" 
                                                    CellClickActionDefault="CellSelect"
                                                    TableLayout="Fixed" 
                                                    StationaryMargins="No"
                                                    AutoGenerateColumns="False"
                                                    UseFixedHeaders="true">
                                                    <FixedCellStyleDefault>
                                                        <Padding Right="2px" />
                                                    </FixedCellStyleDefault>
                                                    <RowStyleDefault><Padding Right="2px" /></RowStyleDefault>
                                                    <GroupByBox>
                                                        <BoxStyle BackColor="whitesmoke" BorderColor="Window" BorderStyle="Solid"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderStyle="Solid" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="2px" />
                                                    </RowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                        <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                                    </HeaderStyleDefault>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
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
                                                    <ClientSideEvents />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="height: 20px; padding-right: 10px; padding-top: 5px;">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="width: 70%;" align="left">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="110">
                                                                    <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                                                                    <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                                                    <img align="absmiddle" src="../Images/etc/lis_t02.gif" /></td>
                                                                <td>
                                                                    <asp:table id="tblViewStatus" runat="server" EnableViewState="true"></asp:table></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 30%;" align="right"><asp:ImageButton id="ibtnSave" runat="server" imageUrl="../images/btn/b_tp07.gif" OnClientClick="return mboSave();" OnClick="ibtnSave_Click"></asp:ImageButton></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdMap" runat="server" style="height: 60px; padding-right: 10px; padding-top: 5px; width: 100%;" align="center">
                                            <table border="0" cellpadding="0" cellspacing="0" width="600px" class="tableBorder">
                                                <tr style="height: 20px;">
                                                    <td class="tableTitle" style="width: 15%;" align="center">
                                                        평가점수
                                                    </td>
                                                    <td class="tableTitle" style="width: 17%;" align="center">
                                                        종합실적보고
                                                    </td>
                                                    <td class="tableTitle" style="width: 17%;" align="center">
                                                        평가
                                                    </td>
                                                    <td class="tableTitle" style="width: 17%;" align="center">
                                                        종합평가의견
                                                    </td>
                                                    <td class="tableTitle" style="width: 17%;" align="center">
                                                        피평가자의견
                                                    </td>
                                                    <td id="tdStep" runat="server" visible="false" class="tableTitle" style="width: 17%;" align="center">
                                                        <asp:Label id="lblStep" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 20px;">
                                                    <td rowspan="2" class="tableContent" align="right">
                                                        <b><span id="lblTotalPoint" runat="server"></span>&nbsp;</b>
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <img id="img1" runat="server" alt="" src="../images/status/01_3.gif" />
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <img id="img2" runat="server" alt="" src="../images/status/01_3.gif" />
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <img id="img3" runat="server" alt="" src="../images/status/01_3.gif" />
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <img id="img4" runat="server" alt="" src="../images/status/01_3.gif" />
                                                    </td>
                                                    <td runat="server" id="tdStepDesc" class="tableContent" align="center" rowspan="2" visible="false">
                                                        <asp:Label id="lblStepDesc" Font-Bold="true" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            <%--</table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdMap2" runat="server" style="height: 10px; padding-right: 10px; width: 100%;" align="center">
                                            <table border="0" cellpadding="0" cellspacing="0" width="80%">--%>
                                                <tr style="height: 10px; padding-top: 2px; padding-bottom: 2px;">
                                                    <td class="tableContent" align="center">
                                                        <asp:ImageButton id="ibtnReport" runat="server" imageUrl="../images/btn/b_001.gif" OnClientClick="return processClick('1');"></asp:ImageButton><asp:ImageButton id="ibtnViewReport" runat="server" imageUrl="../images/btn/b_305.gif" OnClientClick="return viewProcess('1');"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCloseReport" runat="server" imageUrl="../images/btn/b_003.gif" OnClientClick="return closeProcess('1');"></asp:ImageButton>
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <asp:ImageButton id="ibtnEst" runat="server" imageUrl="../images/btn/b_143.gif" OnClientClick="return processClick('2');" OnClick="ibtnEst_Click"></asp:ImageButton>
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <asp:ImageButton id="ibtnOpinion" runat="server" imageUrl="../images/btn/b_001.gif" OnClientClick="return processClick('3');" ></asp:ImageButton><asp:ImageButton id="ibtnViewOpinion" runat="server" imageUrl="../images/btn/b_305.gif" OnClientClick="return viewProcess('3');"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCloseOpinion" runat="server" imageUrl="../images/btn/b_003.gif" OnClientClick="return closeProcess('3');"></asp:ImageButton>
                                                    </td>
                                                    <td class="tableContent" align="center">
                                                        <asp:ImageButton id="ibtnFeedBack" runat="server" imageUrl="../images/btn/b_001.gif" OnClientClick="return processClick('4');" ></asp:ImageButton><asp:ImageButton id="ibtnViewFeedBack" runat="server" imageUrl="../images/btn/b_305.gif" OnClientClick="return viewProcess('4');"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCloseFeedBack" runat="server" imageUrl="../images/btn/b_003.gif" OnClientClick="return closeProcess('4');"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                
                                                <!--피평가자가 평가를 이의신청한 내용이 있다면-->
                                                <tr id="trReject" runat="server" visible="false" style="height: 10px; padding-top: 2px; padding-bottom: 2px;">
                                                    <td class="tableTitle" align="center">
                                                        피평가자</br>이의신청
                                                    </td>
                                                    <td class="tableContent" align="left" colspan="5">
                                                        <asp:Label id="lblReject" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="tdReport" align="center" style="width: 100%; height: 120px; padding-right: 10px; padding-top: 5px;">
                                            <table border="0" cellpadding="0" cellspacing="0" class="" style="width: 80%;">
                                                <tr style="height: 100px;">
                                                    <td class="tableTitle" style="width: 10%; height: 100px;" align="center" valign="middle"">
                                                        종합<br />실적보고<br /><asp:ImageButton ID="iBtnTargetFile_Up"   ImageUrl="../images/icon/gr_po05.gif" runat="server" OnClientClick="return mfUpload('hdfTargetReasonFile','UP')" />
                                                                    <asp:ImageButton ID="iBtnTargetFile_Down" ImageUrl="../images/icon/gr_po04.gif" runat="server" OnClientClick="return mfUpload('hdfTargetReasonFile','DOWN')" />
                                                    </td>
                                                    <td class="tableContent" style="width: 90%;" valign="middle">
                                                        <FCKeditorV2:FCKeditor ID="txtReport" runat="server" BasePath="../_common/FCKeditor/" Height="100%" Width="100%">
                                                        </FCKeditorV2:FCKeditor>
                                                        <span id="spnReport" runat="server" style="height: 100px; width: 100%; overflow: auto;" ></span>
                                                    </td>
                                                </tr>
                                                <tr style="height: 20px;">
                                                    <td colspan="2" class="" align="right" style="padding-right: 10px; padding-top: 5px;">
                                                        <asp:ImageButton id="ibtnSaveReport" runat="server" imageUrl="../images/btn/b_tp07.gif" OnClientClick="return saveClick('1_1');" OnClick="ibtnSaveReport_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnConfirmReport" runat="server" imageUrl="../images/btn/b_045.gif" OnClientClick="return saveClick('1_2');" OnClick="ibtnConfirmReport_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCancelReport" runat="server" imageUrl="../images/btn/b_178.gif" OnClientClick="return saveClick('1_3');" OnClick="ibtnCancelReport_Click"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="tdEst" align="center" style="width: 100%; height: 120px; padding-right: 10px; padding-top: 5px;">
                                            <table border="0" cellpadding="0" cellspacing="0" class="" style="width: 80%;">
                                                <tr style="height: 100px;">
                                                    <td class="tableTitle" style="width: 10%;" align="center">
                                                        <asp:Label id="lblEstOpinion" runat="server">XX차 종합<br />평가의견</asp:Label>
                                                    </td>
                                                    <td class="tableContent" style="width: 90%;">
                                                        <FCKeditorV2:FCKeditor ID="txtOpinion" runat="server" BasePath="../_common/FCKeditor/" Height="100%" Width="100%">
                                                        </FCKeditorV2:FCKeditor>
                                                        <span id="spnOpinion" runat="server" style="height: 100px; width: 100%; overflow: auto;" ></span>
                                                    </td>
                                                </tr>
                                                <tr style="height: 20px;">
                                                    <td colspan="2" class="" align="right" style="padding-right: 10px; padding-top: 5px;">
                                                        <asp:ImageButton id="ibtnSaveEst" runat="server" imageUrl="../images/btn/b_tp07.gif" OnClientClick="return saveClick('2_1');" OnClick="ibtnSaveEst_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnConfirmEst" runat="server" imageUrl="../images/btn/b_160.gif" OnClientClick="return saveClick('2_2');" OnClick="ibtnConfirmEst_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCancelEst" runat="server" imageUrl="../images/btn/b_178.gif" OnClientClick="return saveClick('2_3');" OnClick="ibtnCancelEst_Click"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="tdFeedBack" align="center" style="width: 100%; height: 120px; padding-right: 10px; padding-top: 5px;">
                                            <table border="0" cellpadding="0" cellspacing="0" class="" style="width: 80%;">
                                                <tr style="height: 100px;">
                                                    <td class="tableTitle" style="width: 10%;" align="center">
                                                        피평가자</br>의견
                                                    </td>
                                                    <td class="tableContent" style="width: 90%;">
                                                        <FCKeditorV2:FCKeditor ID="txtFeedBack" runat="server" BasePath="../_common/FCKeditor/" Height="100%" Width="100%">
                                                        </FCKeditorV2:FCKeditor>
                                                        <span id="spnFeedBack" runat="server" style="height: 100px; width: 100%; overflow: auto;" ></span>
                                                    </td>
                                                </tr>
                                                <tr style="height: 20px;">
                                                    <td colspan="2" class="" align="right" style="padding-right: 10px; padding-top: 5px;">
                                                        <asp:ImageButton id="ibtnSaveFeedBack" runat="server" imageUrl="../images/btn/b_tp07.gif" OnClientClick="return saveClick('3_1');" OnClick="ibtnSaveFeedBack_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnConfirmFeedBack" runat="server" imageUrl="../images/btn/b_177.gif" OnClientClick="return saveClick('3_2');" OnClick="ibtnConfirmFeedBack_Click"></asp:ImageButton>
                                                        <asp:ImageButton id="ibtnCancelFeedBack" runat="server" imageUrl="../images/btn/b_175.gif" OnClientClick="return saveClick('3_3');" OnClick="ibtnCancelFeedBack_Click"></asp:ImageButton>
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
                </td>
            </tr>
            <tr style="height: 5%;">
                <td align="right" valign="top">
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                    <asp:LinkButton ID="lnkReload" runat="server" OnClick="lnkReload_Click"></asp:LinkButton>
                    <asp:HiddenField ID = "hdfTargetReasonFile" runat="server" Value="" />
                    <asp:DropDownList id="ddlGrade_hdf" runat="server" visible="false"></asp:DropDownList>
                    <asp:DropDownList id="ddlGradePoint_hdf" runat="server" width="0"></asp:DropDownList>
                </td>
            </tr>
        </table>
        
        <!--- MAIN END --->
        <asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    <div id="divReason" style="position: absolute; z-index: -1; display: none; width: 100%; height: 100%;">
        <table width="100%" style="height: 100%;">
            <tr>
                <td valign="middle" align="center">
                    <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="500px" style="height: 200px;">
                        <tr>
                            <td class="tableTitle" style="width: 100%; height: 20px; background-color: #1A72AC;">
                                <img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>평가등급근거</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%;">
                                <asp:TextBox id="txtGRADE_REASON" runat="server" TextMode="MultiLine" onchange="changeReason()" width="100%" height="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-right: 20px; padding-top: 3px;">
                                <asp:ImageButton id="ibtnConfirm" runat="server" imageUrl="../images/btn/b_305.gif" OnClientClick="return reasonConfirm();"></asp:ImageButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>

