<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0302M5.aspx.cs"
    Inherits="BSC_BSC0302M5" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템::KPI 수정</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script id="Infragistics" type="text/javascript">
    var isCounting = false;
    
    function doPoppingUpGoalTong()
    {
        var estterm_ref_id = document.getElementById('hdfEstTermRefID').value;
        var kpi_pool_ref_id = document.getElementById('hdfKpiPoolRefID').value;
        var kpi_ref_id = document.getElementById('hdfKpiRefID').value;
        
        
        var url = 'BSC0302M1M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + '&KPI_POOL_REF_ID=' + kpi_pool_ref_id +'&KPI_REF_ID=' + kpi_ref_id ;

        gfOpenWindow(url, 600, 500, 'no', 'no', 'BSC0302M1M1');
        return false;
    
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
    
    function checkInitPlan(el, termID, planID)
    {
        if (el.checked == false)
        {
            var aRow = igtbl_getActiveRow(termID);
            var uGrid = igtbl_getGridById(planID);
            if (document.form1.hdfinitial_version_yn.value == "Y")
            {
                if (uGrid.Rows.getRow(aRow.FirstRow.rowIndex - 1).getCellFromKey("MS_PLAN").getValue() != null)
                {
                    if (uGrid.Rows.getRow(aRow.FirstRow.rowIndex - 1).getCellFromKey("MS_PLAN").getValue() != "0")
                    {
                        el.checked = true;
                        alert("해당월에 등록된 계획 데이터가 있습니다.\n계획값을 [0]으로 초기화 후 해제하시기 바랍니다.");
                    }
                }
            }
            else
            {
                if (uGrid.Rows.getRow(aRow.FirstRow.rowIndex - 1).getCellFromKey("MM_PLAN").getValue() != null)
                {
                    if (uGrid.Rows.getRow(aRow.FirstRow.rowIndex - 1).getCellFromKey("MM_PLAN").getValue() != "0")
                    {
                        el.checked = true;
                        alert("해당월에 등록된 계획 데이터가 있습니다.\n계획값을 [0]으로 초기화 후 해제하시기 바랍니다.");
                    }
                }
            }
        }
    }
    /////////////////////////////////////////////////// >> 달성율계산
    function calcAchvRate(tableName, itemName)
    {
        var dblRate = 0.00;
        var dblini = 0.00;
        var dblCur = 0.00;
        var cntCol = 0;
        var cntRow = 0;
        var curRow = 0;

        var objTbl = igtbl_getGridById(tableName);
        var objCol = igtbl_getColumnById(itemName);
        var objRow = igtbl_getRowById(itemName);
	    var isMinus = true;
        
        cntCur = objRow.getIndex()+1;
        cntRow = objTbl.Rows.length;
        
        if (cntCur < 1)
        {
            return;
        }

        var tab = igtab_getTabById("ugrdKpiStatusTab");

        var objColType  = tab.findControl("ddlResultAchievementType"); 
        var strColType  = objColType.value; 
        var sBaseLineYn = "";
        
        for (var i = 0; i < cntRow; i++)
        {
            var objTmpRow   = objTbl.Rows.getRow(i);
            var sBaseLineYn = objTmpRow.getCellFromKey("BASE_LINE_YN").getValue();

            if (sBaseLineYn=="Y") 
            {
                dblini = parseFloat(objTmpRow.getCell(3).getValue());
                break;
            }   
        }

	    for (var i = 0; i < cntRow; i++)
        {
            var objTmpRow   = objTbl.Rows.getRow(i);
	        if(!isNaN(parseFloat(objTmpRow.getCell(3).getValue())))
            {
                if (parseFloat(objTmpRow.getCell(3).getValue()) >= 0)
                {
		            isMinus = false;
		            break;
		        }
            }
            else
            {
                isMinus = false;         
                break;
            }
        }

        if (((strColType=='ATY' || strColType=='BTY') && isMinus))      //부경양돈농협때문에 전체가 마이너스일때는 달성율 분자분모 반대
        {
            for (var i = 0; i < cntRow; i++)
            {
                var objTmpRow   = objTbl.Rows.getRow(i);
                
                dblCur  = parseFloat(objTmpRow.getCell(3).getValue());
                dblRate = (dblCur==0) ? 0 : (dblini/dblCur)*100;
                objTbl.Rows.getRow(i).getCell(4).setValue(dblRate);
            }
        }
        else
        {
            for (var i = 0; i < cntRow; i++)
            {
                var objTmpRow   = objTbl.Rows.getRow(i);
                
                if(isNaN(parseFloat(objTmpRow.getCell(3).getValue())))
                {
                    objTbl.Rows.getRow(i).getCell(4).setValue(0);
                }
                else
                {
                    if (strColType=='ATY' || strColType=='BTY')      //A Type
                    {
                        dblCur  = parseFloat(objTmpRow.getCell(3).getValue());
                        dblRate = (dblini==0) ? 0 : (dblCur/dblini)*100;
                        objTbl.Rows.getRow(i).getCell(4).setValue(dblRate);
                    }
                    else
                    {
                        objTbl.Rows.getRow(i).getCell(4).setValue("");
                    }
                }
            }
        }
        
    }

    /////////////////////////////////////////////////// >> 계획자동계산
    function AfterCellUpdate(tableName, itemName)
    {
        if (isCounting)
            return;
        isCounting = true;
        var dblPlan = 0.00;
        var intDiv = 0;

        var oGrid = igtbl_getGridById(tableName);
        
        var strMS  = "";
        var strTS  = "";
        var strCK  = "";
        
        var tab = igtab_getTabById("ugrdKpiStatusTab");

        var objColType = tab.findControl("ddlResultTsCalcType"); //igtab_getElementById("ddlResultTsCalcType");
        var strColType = objColType.value;
        
        if (document.form1.hdfinitial_version_yn.value == "Y")
        {
            strMS = "MS_PLAN";
            strTS = "TS_PLAN";
            strCK = "ORI_CHECK_YN";
        }
        else
        {
            strMS = "MM_PLAN";
            strTS = "TM_PLAN";
            strCK = "MOD_CHECK_YN";
        }
//alert(strColType);
        oRows = oGrid.Rows;
        for (var i = 0; i < oRows.length; i++)
        {
            var oRow = oRows.getRow(i);
                intDiv += (oRow.getCellFromKey(strCK).getValue()=='Y') ? 1 : 0;
  
            if(isNaN(parseFloat(oRow.getCellFromKey(strMS).getValue())) || (oRow.getCellFromKey(strCK).getValue() == 'N'))
            {
                oRow .getCellFromKey(strMS).setValue(0);
                oRow .getCellFromKey(strTS).setValue(0);
                
                if (strColType=="SUM")      //단순합계
                {
                    oRow.getCellFromKey(strTS).setValue(dblPlan);
                }
                else if (strColType=="OTS") // 누적만측정
                {
                        //oRow.getCellFromKey(strMS).setValue(0);
                }
                else if (strColType=="AVG") // 단순평균
                {
                    dblPlan += parseFloat(oRow.getCellFromKey(strMS).getValue());
                    if (intDiv == 0)
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan);
                    }
                    else
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan/intDiv);
                    }
                }
            }
            else
            {
                if (strColType=="SUM")      //단순합계
                {
                    dblPlan += parseFloat(oRow.getCellFromKey(strMS).getValue());
                    oRow.getCellFromKey(strTS).setValue(dblPlan);
                }
                else if (strColType=="AVG") // 단순평균
                {
                    dblPlan += parseFloat(oRow.getCellFromKey(strMS).getValue());
                    if (intDiv == 0)
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan);
                    }
                    else
                    {
                        oRow.getCellFromKey(strTS).setValue(dblPlan/intDiv);
                    }
                }
            }
        }
        isCounting = false;
   }
   
   function OpenTargetForm()
   {
        var estterm_ref_id  = document.form1.hdfEstTermRefID.value; //<%= this.IEstTermRefID %>;
        var kpi_ref_id      = document.form1.hdfKpiRefID.value;     //<%= this.IKpiRefID %>;
        var url             = "BSC0303M1.aspx?iTYPE=A&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id;
        
        gfOpenWindow(url, 700, 500, 'yes', 'no', 'BSC0303M1');
        
        return false;
   }
   
   /*=========================================================================
     호출 파라미터 결재상신, 재상신 처리
     estterm_ref_id : 결재원문파라미터
     kpi_ref_id     : 결재원문파라미터
     app_ref_id     : 결재문서가 최초버젼일 아닐경우
     biz_type       : KDA:지표정의서 결재, KRA:지표실적결재, PMA:사업관리
     app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
   //========================================================================*/
   function OpenDraft(draftStatus)
   {
        var estterm_ref_id  = document.form1.hdfEstTermRefID.value; //<%= this.IEstTermRefID %>;
        var kpi_ref_id      = document.form1.hdfKpiRefID.value;     //<%= this.IKpiRefID %>;
        var app_ref_id      = "<%= this.IApp_Ref_Id %>";
        var app_ccb         = "<%= this.IAPP_CCB %>";
        var biz_type        = "<%= Biz_Type.biz_type_kpi_doc %>";
        var draft_emp_id    = parseInt("<%= this.IDraftEmpID %>",10);
       
        if (draft_emp_id=="NaN" || draft_emp_id  < 1)
        {
            alert("기안자 정보를 알수 없습니다.");
            return false;
        }
        
        var url             = "BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+"&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id+"&DRAFT_EMP_ID="+draft_emp_id;

<% if (this.ExternalApproval == true) { %>
        var url = "ApprovalGateway.aspx?DRAFT_STATUS=" + draftStatus
                + "&POPUP_TYPE=A"+"&ESTTERM_REF_ID=" + estterm_ref_id 
                + "&KPI_REF_ID=" + kpi_ref_id 
                + "&YMD=" + "" 
                + "&BIZ_TYPE=" + biz_type 
                + "&APP_CCB=" + app_ccb 
                + "&APP_REF_ID=" + app_ref_id 
                + "&DRAFT_EMP_ID=" + draft_emp_id;
<% } %>
        gfOpenWindow(url, 900, 680, 'BSC0901M1'); // 728
        
        return false;
   }
   
   function OpenDraftPrint(draftStatus)
   {
        var estterm_ref_id  = document.form1.hdfEstTermRefID.value; //<%= this.IEstTermRefID %>;
        var kpi_ref_id      = document.form1.hdfKpiRefID.value;     //<%= this.IKpiRefID %>;
        var app_ref_id      = "<%= this.IApp_Ref_Id %>";
        var app_ccb         = "<%= this.IAPP_CCB %>";
        var biz_type        = "<%= Biz_Type.biz_type_kpi_doc %>";
        var url             = "BSC0901P1.aspx?DRAFT_STATUS="+draftStatus+"&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+"&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id;

        gfOpenWindow(url, 900, 650, 'BSC0901P1');
        
        return false;
   }
   
    function openDeptEmp(strKeyObj, strValObj)
    {
        var tab = igtab_getTabById("ugrdKpiStatusTab");
        var objKey = tab.findControl(strKeyObj);
        var objVal = tab.findControl(strValObj);
        
        strKeyObj = objKey.name;
        strValObj = objVal.name;

        var estterm_ref_id  = document.form1.hdfEstTermRefID.value;
        var url             = "../ctl/ctl2106.aspx?ESTTERM_REF_ID="+ estterm_ref_id +"&OBJ_KEY="+ strKeyObj + "&OBJ_VAL=" + strValObj;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'ctl2106');
    }
    
    function OpenChildKpiForm()
    {
        var estterm_ref_id  = document.form1.hdfEstTermRefID.value; //<%= this.IEstTermRefID %>;
        var kpi_ref_id      = document.form1.hdfKpiRefID.value;     //<%= this.IKpiRefID %>;
        var url             = "BSC0305M1.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id;
        
        gfOpenWindow(url, 1000, 650, 'yes', 'no', 'BSC0305M1');
        
        return false;
    }
    
    function openInterfaceInfo()
    {
        var estterm_ref_id  = document.form1.hdfEstTermRefID.value; //<%= this.IEstTermRefID %>;
        var kpi_ref_id      = document.form1.hdfKpiRefID.value;     //<%= this.IKpiRefID %>;
        var url             = "BSC0603S1.aspx?ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+"&YMD=000000";
        
        gfOpenWindow(url, 800, 680, 'yes', 'no', 'BSC0603S1');
        
        return false;
    }
    
    function openKpiPoolList(strObjKey, strObjVal)
    {
        var url             = "BSC0301S2.aspx?OBJ_KEY="+strObjKey+"&OBJ_VAL="+strObjVal;
        gfOpenWindow(url, 850, 550, 'yes', 'no', 'BSC0301S2');
        
        return false;
    }
    
    function ugrdEstLevel_DblClickHandler(gridName, cellId)
    {
        var cell    = igtbl_getElementById(cellId);
        var row     = igtbl_getRowById(cellId);
        var kpiID   = row.getCellFromKey("KPI_POOL_REF_ID").getValue();
        
        //EST_EMP_ID/EST_USER_NAME;
        
        var strURL = 'BSC0301M1.aspx?iType=U&KPI_POOL_REF_ID='+ kpiID;
        //gfOpenWindow(strURL, 720, 670,"BSC0301M1");
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
        var oaArg   = new Array("FILE", "KPIREA", (oAttach==null ? "" : oAttach.value));
        
        var oReturn = "";
        if (strUpDown == "UP")
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 485, 307, true);
        }
        else
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 485, 307, true);
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
        return false;
    }
    
    // 지표코드 입력시 전 평가가간에서 지표코드 체크
    function isExistsKpi(objTxtKpiCode)
    {
        var kpicode = objTxtKpiCode.value;
        if (kpicode == "")
        {
            objTxtKpiCode.focus();
            return;
        }
        else
        {
            __doPostBack('iBtnExistsKpi', '');
        }
    }
    
    function CheckKeyVal(objTxtKpiCode)
    {
        if(event.keyCode==13)
        {
            CopyKpi(objTxtKpiCode);
        }
    }
    
    function DeleteKpi()
    {
        if(confirm("삭제하시겠습니까?"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    function isMoDraftMsg()
    {
        if(confirm("수정상신이 진행되는 동안은 실적입력 및 점수산출이 진행되지 않습니다. 수정상신을 진행하시겠습니까?"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    function ugrdPrjList_DblClickHandler(gridName, cellId)
    {
        var cell            = igtbl_getElementById(cellId);
        var row             = igtbl_getRowById(cellId);
        var prjID           = row.getCellFromKey("PRJ_REF_ID").getValue();
        var viewYN          = "S";//row.getCellFromKey("ISDELETE").getValue() =='Y'? 'D':'U';
        var ICCB1           = "<%= this.ICCB1 %>";
        
        var url             = '../PRJ/PRJ0101M1.aspx?iType=' + viewYN + '&PRJ_REF_ID=' + prjID+'&CCB1='+ICCB1 ;
        gfOpenWindow(url, 900, 680, 'yes', 'no', 'PRJ0101M1');
    }
    
    </script>

    <script src="../_common/js/iezn_embed_patch.js" type="text/javascript"></script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" style="background-image: url(../images/title/popup_t_bg.gif); height: 40px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 40px;" valign="top">
                                        <img alt="" src="../images/title/popup_t5.gif" />
                                    </td>
                                    <td align="right" valign="top">
                                        <img alt="" src="../images/title/popup_img.gif" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                                    </td>
                                    <td style="width: 50%; background-color: #FFFFFF">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td class="cssTblTitle">
                                                    KPI 코드
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:TextBox ID="txtKpiCode" Width="100%" runat="server" BorderWidth="0"></asp:TextBox>
                                                </td>
                                                <td class="cssTblTitle">
                                                    KPI 명
                                                </td>
                                                <td class="cssTblContent">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtKpiName" runat="server" Width="100%" BorderWidth="0" ReadOnly="True"
                                                                    BackColor="whitesmoke"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 20px;">
                                                                <%--<asp:Label ID="lblKpiName" runat="server" Width="450px"></asp:Label>--%>
                                                                <asp:ImageButton ID="iBtnKpiPoolList" runat="server" ImageUrl="../images/btn/b_034.gif"
                                                                    OnClientClick="return openKpiPoolList('hdfKpiPoolRefID','txtKpiName');" ImageAlign="AbsMiddle" />
                                                                <asp:HiddenField ID="hdfKpiPoolRefID" runat="server" Value="" />
                                                                <asp:HiddenField ID="hdfEstTermRefID" runat="server" Value="" />
                                                                <asp:HiddenField ID="hdfKpiRefID" runat="server" Value="" />
                                                                <asp:HiddenField ID="hdfinitial_version_yn" runat="server" Value="" />
                                                                <asp:HiddenField ID="hdfkpi_target_version_id" runat="server" Value="" />
                                                                <asp:HiddenField ID="hdfTargetReasonFile" runat="server" Value="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssTblTitle">
                                                    KPI 유형
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:Label ID="lblKpiType" Width="100%" runat="server" BorderWidth="0"></asp:Label>
                                                </td>
                                                <td class="cssTblTitle">
                                                    지표분류
                                                </td>
                                                <td class="cssTblContent">
                                                    <asp:Label ID="lblKpiCatName" runat="server" Width="100%"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img alt="" src="../images/blank.gif" width="0" height="7px" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 100%;">
                                <tr>
                                    <td>
                                        <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False"
                                            Width="100%" SelectedTab="3" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                                            <Tabs>
                                                <ig:Tab Text="PARTⅠ KPI 정의" Key="1">
                                                    <Style Width="160px" Height="25px" />
                                                    <ContentTemplate>
                                                        <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%"
                                                            style="height: 100%;">
                                                            <tr>
                                                                <td class="cssTblTitle" style="width: 20%;">
                                                                    <%=GetText("LBL_00001", "챔피언") %>
                                                                </td>
                                                                <td class="cssTblContent" style="width: 80%;">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdfChampionEmpId" runat="server" />
                                                                                <asp:TextBox ID="txtChampionEmpName" runat="server" Width="100%" BorderWidth="0"></asp:TextBox>
                                                                            </td>
                                                                            <td align="right" style="width: 83px;">
                                                                                <img alt="" src="../images/btn/b_008.gif" style="cursor: hand;" onclick="openDeptEmp('hdfChampionEmpId','txtChampionEmpName');" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 100%;">
                                                                <td class="cssTblTitle">
                                                                    지표 및 용어정의
                                                                </td>
                                                                <td class="cssTblContent">
                                                                    <asp:TextBox ID="txtWordDefinition" runat="server" Width="100%" TextMode="MultiLine"
                                                                        Height="100%" Visible="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="cssTblTitle">
                                                                    당월산식
                                                                </td>
                                                                <td class="cssTblContent">
                                                                    <asp:TextBox ID="txtCalcFormMs" runat="server" Width="100%" TextMode="MultiLine"
                                                                        Height="40px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="cssTblTitle">
                                                                    누계산식
                                                                </td>
                                                                <td class="cssTblContent">
                                                                    <asp:TextBox ID="txtCalcFormTs" runat="server" Height="40px" TextMode="MultiLine"
                                                                        Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
			                                                <td class="tableTitle" align="center" width="100">용어정의</td>
			                                                <td class="tableContent" colspan="3">
			                                                </td>
		                                                </tr>--%>
                                                            <tr>
                                                                <td class="cssTblTitle">
                                                                    관련이슈
                                                                </td>
                                                                <td class="cssTblContent">
                                                                    <asp:TextBox ID="txtRelatedIssue" runat="server" Width="100%" TextMode="MultiLine"
                                                                        Height="40px" Visible="true"></asp:TextBox>
                                                                    <asp:TextBox ID="txtMeasurementPurpose" runat="server" Width="100%" TextMode="MultiLine"
                                                                        Height="40px" Visible="false"></asp:TextBox>
                                                                    <asp:FileUpload ID="fileDefinition" runat="server" Width="300px" Visible="false" /><asp:HyperLink
                                                                        ID="linkDefinition" runat="server" Visible="false"></asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
			                                                <td class="tableTitle" align="center" style="height:0px;"></td>
			                                                <td class="tableContent" colspan="3">
			                                                </td>
		                                                </tr>--%>
                                                        </table>
                                                    </ContentTemplate>
                                                </ig:Tab>
                                                <ig:TabSeparator>
                                                    <Style Width="1px" />
                                                </ig:TabSeparator>
                                                <ig:Tab Text="PARTⅡ KPI측정" Key="2">
                                                    <Style Width="160px" Height="25px" />
                                                    <ContentTemplate>
                                                        <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%"
                                                            style="height: 100%;">
                                                            <tr>
                                                                <td class="cssTblTitle" style="width: 10%;">
                                                                    <%=GetText("LBL_00002", "측정조직 담당자")%>
                                                                </td>
                                                                <td class="cssTblContent" style="width: 90%;">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdfMeasurementEmpId" Value="" runat="server" />
                                                                                <asp:TextBox ID="txtMeasurementEmpName" runat="server" Width="100%" BorderWidth="0"
                                                                                    BorderStyle="None"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 83px;">
                                                                                <img alt="" src="../images/btn/b_008.gif" style="cursor: hand;" onclick="openDeptEmp('hdfMeasurementEmpId','txtMeasurementEmpName');" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="cssTblTitle">
                                                                    측정유형
                                                                </td>
                                                                <td class="cssTblContent">
                                                                    <asp:DropDownList ID="ddlResultInputType" Width="100%" runat="server" CssClass="box01">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                            <td align="center" class="tableTitle" style="height: 20px; width:100px;">결재자</td>
                                                            <td class="tableContent" colspan="4" style="height: 20px">
                                                                <asp:TextBox ID="txtApprovalEmpName" runat="server" BorderStyle="None" BorderWidth="0"></asp:TextBox>
                                                                <img alt="" src="../images/btn/b_008.gif" style="cursor:hand;" onclick="openDeptEmp('hdfApprovalEmpId','txtApprovalEmpName');" />
                                                                <asp:ImageButton ID="imgBtnEmp" runat="server" ImageUrl="../images/btn/b_016.gif" Enabled="False" Visible="False" />
                                                                <asp:Label ID="lblUserDesc" runat="server" ForeColor="Red"></asp:Label>
                                                                <asp:HiddenField ID="hdfApprovalEmpId" Value="" runat="server" />
                                                            </td>
                                                        </tr>--%>
                                                            <tr>
                                                                <td class="cssTblTitle" style="width: 20%;">
                                                                    데이터집계방법
                                                                </td>
                                                                <td class="cssTblContent" style="width: 80%;">
                                                                    <asp:TextBox ID="txtDataGetheringMethod" runat="server" Width="100%" Height="80px"
                                                                        TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="cssTblTitle">
                                                                    데이터상세정의
                                                                </td>
                                                                <td style="height: 150PX;">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%;">
                                                                        <tr>
                                                                            <td style="height: 100%;">
                                                                                <ig:UltraWebGrid ID="ugrdDetail" runat="server" Height="100%" Width="100%" OnInitializeRow="ugrdDetail_InitializeRow"
                                                                                    OnInitializeLayout="ugrdDetail_InitializeLayout">
                                                                                    <Bands>
                                                                                        <ig:UltraGridBand>
                                                                                            <AddNewRow View="NotSet" Visible="NotSet">
                                                                                            </AddNewRow>
                                                                                            <Columns>
                                                                                                <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="입력구분" Key="ITYPE" DataType="System.String"
                                                                                                    Hidden="true" Width="40px">
                                                                                                    <Header Caption="입력구분">
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:TemplatedColumn Key="selchk" Width="25px">
                                                                                                    <HeaderTemplate>
                                                                                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor: hand; vertical-align: middle;"
                                                                                                            onclick="selectChkBox('ugrdDetail')" />
                                                                                                    </HeaderTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                    </CellStyle>
                                                                                                    <CellTemplate>
                                                                                                        <asp:CheckBox ID="cBox" runat="server" />
                                                                                                    </CellTemplate>
                                                                                                </ig:TemplatedColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                                    Key="ESTTERM_REF_ID">
                                                                                                    <Header Caption="ESTTERM_REF_ID">
                                                                                                        <RowLayoutColumnInfo OriginX="1" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="1" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Hidden="True"
                                                                                                    Key="KPI_REF_ID">
                                                                                                    <Header Caption="KPI_REF_ID">
                                                                                                        <RowLayoutColumnInfo OriginX="2" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="2" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="DATASOURCE_ID" HeaderText="DATASOURCE_ID" Hidden="True"
                                                                                                    Key="DATASOURCE_ID">
                                                                                                    <Header Caption="DATASOURCE_ID">
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="LEVEL1" HeaderText="Level1" Key="LEVEL1" Width="80px"
                                                                                                    NullText="">
                                                                                                    <Header Caption="Level1">
                                                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="LEVEL2" HeaderText="Level2" Key="LEVEL2" Width="80px"
                                                                                                    NullText="">
                                                                                                    <Header Caption="Level2">
                                                                                                        <RowLayoutColumnInfo OriginX="5" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="5" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="LEVEL3" HeaderText="Level3" Key="LEVEL3" Width="80px"
                                                                                                    NullText="">
                                                                                                    <Header Caption="Level3">
                                                                                                        <RowLayoutColumnInfo OriginX="6" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="6" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="RESULT_SOURCE" HeaderText="실적데이터원천" Key="RESULT_SOURCE"
                                                                                                    Width="150px" NullText="">
                                                                                                    <Header Caption="실적데이터원천">
                                                                                                        <RowLayoutColumnInfo OriginX="7" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="7" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="RESULT_CREATE_TIME" HeaderText="실적생성시기" Key="RESULT_CREATE_TIME"
                                                                                                    Width="130px" NullText="">
                                                                                                    <Header Caption="실적생성시기">
                                                                                                        <RowLayoutColumnInfo OriginX="8" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="8" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="TARGET_SOURCE" HeaderText="데이터원천" Key="TARGET_SOURCE"
                                                                                                    Width="130px" NullText="">
                                                                                                    <Header Caption="데이터원천">
                                                                                                        <RowLayoutColumnInfo OriginX="9" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="9" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:TemplatedColumn BaseColumnName="UNIT_TYPE_REF_ID" Key="UNIT_TYPE_REF_ID" EditorControlID=""
                                                                                                    Width="65px" FooterText="" HeaderText="단위" NullText="0">
                                                                                                    <Header Caption="단위">
                                                                                                        <RowLayoutColumnInfo OriginX="10" />
                                                                                                    </Header>
                                                                                                    <HeaderStyle Wrap="True" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                    <CellTemplate>
                                                                                                        <asp:DropDownList ID="ddlDataUnit" CssClass="box01" runat="server" Width="100%">
                                                                                                        </asp:DropDownList>
                                                                                                    </CellTemplate>
                                                                                                    <Footer Caption="">
                                                                                                        <RowLayoutColumnInfo OriginX="10" />
                                                                                                    </Footer>
                                                                                                </ig:TemplatedColumn>
                                                                                            </Columns>
                                                                                        </ig:UltraGridBand>
                                                                                    </Bands>
                                                                                    <DisplayLayout Version="4.00" AllowUpdateDefault="Yes" HeaderClickActionDefault="NotSet"
                                                                                        Name="ugrdDetail" BorderCollapseDefault="Separate" RowSelectorsDefault="No" RowHeightDefault="20px"
                                                                                        SelectTypeRowDefault="Single" TableLayout="Fixed" AutoGenerateColumns="False"
                                                                                        AllowRowNumberingDefault="Continuous" StationaryMargins="HeaderAndFooter">
                                                                                        <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                                    <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                                </GroupByRowStyleDefault>
                                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left">
                                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                                </FooterStyleDefault>                                                
                                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                                    <Padding Left="3px" />
                                                                                </RowStyleDefault>
                                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                                    <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                                </HeaderStyleDefault>
                                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                                </EditCellStyleDefault>
                                                                                <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                                                    Width="100%">
                                                                                </FrameStyle>
                                                                                <Pager>
                                                                                    <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                    </PagerStyle>
                                                                                </Pager>
                                                                                <AddNewBox Hidden="False" Prompt="행추가">
                                                                                <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                </BoxStyle>
                                                                                </AddNewBox>
                                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                                </SelectedRowStyleDefault>
                                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                                </ActivationObject>--%>
                                                                                        <GroupByBox>
                                                                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                                                            </BoxStyle>
                                                                                        </GroupByBox>
                                                                                        <RowStyleDefault CssClass="GridRowStyle" />
                                                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                        </SelectedRowStyleDefault>
                                                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                        </RowAlternateStyleDefault>
                                                                                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                        </HeaderStyleDefault>
                                                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                        </FrameStyle>
                                                                                        <ClientSideEvents AfterRowInsertHandler="ugrdDetail_AfterRowInsertHandler" />
                                                                                    </DisplayLayout>
                                                                                </ig:UltraWebGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cssTblContent" align="right">
                                                                                <img alt="" src="../Images/btn/b_i001.gif" onclick="openInterfaceInfo();" style="cursor: hand;" />
                                                                                <asp:ImageButton ID="ImgBtnAddRow" ImageUrl="../images/btn/b_005.gif" runat="server"
                                                                                    OnClick="ImgBtnAddRow_Click" />
                                                                                <asp:ImageButton ID="ImgBtnDelRow" ImageUrl="../images/btn/b_004.gif" runat="server"
                                                                                    OnClick="ImgBtnDelRow_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 100%;">
                                                                <td class="cssTblTitle">
                                                                    주기설정
                                                                </td>
                                                                <td style="height: 100%;">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                측정 주기:<asp:DropDownList ID="ddlResultTermType" runat="server" CssClass="box01">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 100%;">
                                                                                <ig:UltraWebGrid ID="ugrdTerm" runat="server" Height="100%" Width="600px" ImageDirectory=""
                                                                                    OnInitializeRow="ugrdTerm_InitializeRow" OnInitializeLayout="ugrdTerm_InitializeLayout">
                                                                                    <Bands>
                                                                                        <ig:UltraGridBand>
                                                                                            <AddNewRow View="NotSet" Visible="NotSet">
                                                                                            </AddNewRow>
                                                                                            <Columns>
                                                                                                <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="평가년월" Key="YMD" DataType="System.String"
                                                                                                    Hidden="true">
                                                                                                    <Header Caption="평가년월">
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="평가년월" Key="YMD_DESC">
                                                                                                    <Header Caption="평가년월">
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:TemplatedColumn BaseColumnName="CHECK_YN" Key="CHECK_YN">
                                                                                                    <Header Caption="측정주기">
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblTerm" runat="server" Text="측정주기"></asp:Label>
                                                                                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor: hand; vertical-align: middle;"
                                                                                                            onclick="selectChkBox('ugrdTerm')" />
                                                                                                    </HeaderTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                    <CellTemplate>
                                                                                                        <asp:CheckBox ID="chkCheckTerm" runat="server" />
                                                                                                    </CellTemplate>
                                                                                                </ig:TemplatedColumn>
                                                                                                <ig:TemplatedColumn BaseColumnName="REPORT_YN" Key="REPORT_YN">
                                                                                                    <Header Caption="보고주기">
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                    <CellTemplate>
                                                                                                        <asp:CheckBox ID="chkReportTerm" runat="server" />
                                                                                                    </CellTemplate>
                                                                                                </ig:TemplatedColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="CLOSE_YN" DataType="System.String" HeaderText="마감여부"
                                                                                                    Hidden="false" Key="CLOSE_YN">
                                                                                                    <Header Caption="마감여부">
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Center">
                                                                                                    </CellStyle>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                                    Hidden="True" Key="KPI_REF_ID">
                                                                                                    <Header Caption="KPI_REF_ID">
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                                    Key="ESTTERM_REF_ID">
                                                                                                    <Header Caption="ESTTERM_REF_ID">
                                                                                                        <RowLayoutColumnInfo OriginX="1" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="1" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="typecode" DataType="System.Int32" HeaderText="typecode"
                                                                                                    Hidden="True" Key="typecode">
                                                                                                    <Header Caption="typecode">
                                                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                            </Columns>
                                                                                        </ig:UltraGridBand>
                                                                                    </Bands>
                                                                                    <DisplayLayout CellPaddingDefault="2" Version="4.00" AutoGenerateColumns="false"
                                                                                        HeaderClickActionDefault="NotSet" Name="ugrdTerm" BorderCollapseDefault="Separate"
                                                                                        RowSelectorsDefault="No" ScrollBarView="Both" RowHeightDefault="20px" SelectTypeRowDefault="Single"
                                                                                        JavaScriptFileName="" JavaScriptFileNameCommon="" FixedHeaderIndicatorDefault="Button"
                                                                                        TableLayout="Fixed" StationaryMargins="Header">
                                                                                        <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                                        <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                                    </GroupByRowStyleDefault>
                                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                                    </FooterStyleDefault>
                                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                                        <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                                        <Padding Left="3px" />
                                                                                    </RowStyleDefault>
                                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False">
                                                                                        <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                                    </HeaderStyleDefault>
                                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                                    </EditCellStyleDefault>
                                                                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%"
                                                                                        Width="600px">
                                                                                    </FrameStyle>
                                                                                    <Pager>
                                                                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                        </PagerStyle>
                                                                                    </Pager>
                                                                                    <AddNewBox>
                                                                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                        </BoxStyle>
                                                                                    </AddNewBox>
                                                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                                    </SelectedRowStyleDefault>
                                                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                                                    </ActivationObject>
                                                                                    <FilterOptionsDefault FilterUIType="HeaderIcons">
                                                                                    </FilterOptionsDefault>
                                                                                    <Images ImageDirectory="">
                                                                                    </Images>--%>
                                                                                        <GroupByBox Hidden="True">
                                                                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                                                            </BoxStyle>
                                                                                        </GroupByBox>
                                                                                        <RowStyleDefault CssClass="GridRowStyle" />
                                                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                        </SelectedRowStyleDefault>
                                                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                        </RowAlternateStyleDefault>
                                                                                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                        <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                        </HeaderStyleDefault>
                                                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                        </FrameStyle>
                                                                                        <ClientSideEvents />
                                                                                    </DisplayLayout>
                                                                                </ig:UltraWebGrid>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ig:Tab>
                                                <ig:TabSeparator>
                                                    <Style Width="1px" />
                                                </ig:TabSeparator>
                                                <ig:Tab Text="PARTⅢ KPI계획 및 평가" Key="3">
                                                    <Style />
                                                    <ContentTemplate>
                                                        <div style="height: 460px; overflow: auto;">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
                                                                <tr>
                                                                    <td style="width: 100%;" valign="top" colspan="2">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableBorder">
                                                                            <tr>
                                                                                <td class="cssTblTitle" align="center" style="width: 80px;" rowspan="3">
                                                                                    KPI 유형
                                                                                </td>
                                                                                <td style="background-color: White;" rowspan="3">
                                                                                    <asp:DropDownList ID="ddlResultAchievementType" runat="server" CssClass="box01">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="cssTblTitle" align="center" style="width: 90px;" rowspan="3">
                                                                                    누적실적유형
                                                                                </td>
                                                                                <td style="background-color: White;" rowspan="3">
                                                                                    <asp:DropDownList ID="ddlResultTsCalcType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlResultTsCalcType_SelectedIndexChanged"
                                                                                        CssClass="box01">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="cssTblTitle" align="center" style="width: 90px;" rowspan="3">
                                                                                    구간산정방법
                                                                                </td>
                                                                                <td style="background-color: White;" rowspan="3">
                                                                                    <asp:DropDownList ID="ddlMeasurementGradeType" runat="server" CssClass="box01">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="cssTblTitle" align="center" style="width: 80px;" rowspan="3">
                                                                                    단위
                                                                                </td>
                                                                                <td style="background-color: White;" rowspan="3">
                                                                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="box01">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="center" class="cssTblTitle" rowspan="3" style="width: 80px;">
                                                                                    <%=this.GetText("LBL_00003", "평가단계") %>
                                                                                </td>
                                                                                <td rowspan="3" style="background-color: white">
                                                                                    <asp:DropDownList ID="ddlResultMeasurementStep" runat="server" AutoPostBack="True"
                                                                                        CssClass="box01" OnSelectedIndexChanged="ddlResultMeasurementStep_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="10">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" rowspan="2" style="padding-top: 5px; height: 100%;">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                                                                            <tr>
                                                                                <td style="height: 310px;">
                                                                                    <!------- 당초/수정계획 그리드 ---------------------------->
                                                                                    <ig:UltraWebGrid ID="ugrdPlan" runat="server" Height="100%" Width="99%" OnInitializeLayout="ugrdPlan_InitializeLayout"
                                                                                        OnInitializeRow="ugrdPlan_InitializeRow" Visible="false">
                                                                                        <Bands>
                                                                                            <ig:UltraGridBand>
                                                                                                <Columns>
                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="목표&lt;BR /&gt;시기" Key="YMD_DESC"
                                                                                                        Width="50px">
                                                                                                        <Header Caption="목표&lt;BR /&gt;시기">
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="MS_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누적" Key="TS_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="누적">
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MM_PLAN" HeaderText="당월" Key="MM_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="TM_PLAN" HeaderText="누적" Key="TM_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="누적">
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                                        Key="ESTTERM_REF_ID">
                                                                                                        <Header Caption="ESTTERM_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                                        Hidden="True" Key="KPI_REF_ID">
                                                                                                        <Header Caption="KPI_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" DataType="System.Int32"
                                                                                                        HeaderText="KPI_TARGET_VERSION_ID" Hidden="True" Key="KPI_TARGET_VERSION_ID">
                                                                                                        <Header Caption="KPI_TARGET_VERSION_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="50px"
                                                                                                        Hidden="True">
                                                                                                        <Header Caption="YMD">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ORI_CHECK_YN" HeaderText="ORI_CHECK_YN" Hidden="True"
                                                                                                        Key="ORI_CHECK_YN">
                                                                                                        <Header Caption="ORI_CHECK_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MOD_CHECK_YN" HeaderText="MOD_CHECK_YN" Hidden="True"
                                                                                                        Key="MOD_CHECK_YN">
                                                                                                        <Header Caption="MOD_CHECK_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MONTHLY_CLOSE_YN" HeaderText="MONTHLY_CLOSE_YN"
                                                                                                        Hidden="True" Key="MONTHLY_CLOSE_YN">
                                                                                                        <Header Caption="MONTHLY_CLOSE_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                </Columns>
                                                                                            </ig:UltraGridBand>
                                                                                        </Bands>
                                                                                        <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowColSizingDefault="Free"
                                                                                            AllowUpdateDefault="Yes" AutoGenerateColumns="False" HeaderClickActionDefault="NotSet"
                                                                                            Name="ugrdPlan" BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Vertical"
                                                                                            RowHeightDefault="22px" JavaScriptFileName="" JavaScriptFileNameCommon="" CellClickActionDefault="Edit"
                                                                                            StationaryMargins="Header" OptimizeCSSClassNamesOutput="False" TableLayout="Fixed">
                                                                                            <%--<GroupByBox>
                                                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                            </GroupByBox>
                                                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                                <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                            </GroupByRowStyleDefault>
                                                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                            </FooterStyleDefault>
                                                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                                <Padding Left="2px" />
                                                                            </RowStyleDefault>
                                                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                                <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                            </HeaderStyleDefault>
                                                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                            </EditCellStyleDefault>
                                                                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="310px" Width="100%">
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
                                                                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate"  />
                                                                            <ActivationObject BorderColor="" BorderWidth="">
                                                                            </ActivationObject>
                                                                            <Images ImageDirectory="">
                                                                            </Images>--%>
                                                                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                                            </GroupByRowStyleDefault>
                                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                            </SelectedRowStyleDefault>
                                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                            </RowAlternateStyleDefault>
                                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                            </HeaderStyleDefault>
                                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                            </FrameStyle>
                                                                                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate" />
                                                                                        </DisplayLayout>
                                                                                    </ig:UltraWebGrid>
                                                                                    <ig:UltraWebGrid ID="ugrdPlanA" runat="server" Height="100%" Width="100%" OnInitializeLayout="ugrdPlanA_InitializeLayout"
                                                                                        OnInitializeRow="ugrdPlanA_InitializeRow">
                                                                                        <Bands>
                                                                                            <ig:UltraGridBand>
                                                                                                <Columns>
                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="목표시기" Key="YMD_DESC" Width="50px">
                                                                                                        <Header Caption="목표시기">
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="당월" Key="MS_TARGET" DataType="System.Double"
                                                                                                        Type="Custom" Width="70px" Format="###,###.####">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="누계" Key="TS_TARGET" DataType="System.Double"
                                                                                                        Type="Custom" Width="70px" Format="###,###.####">
                                                                                                        <Header Caption="누계">
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="MS_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="70px" Format="###,###.####">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누계" Key="TS_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="70px" Format="###,###.####">
                                                                                                        <Header Caption="누계">
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MM_PLAN" HeaderText="당월" Key="MM_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####" Hidden="true">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="TM_PLAN" HeaderText="누계" Key="TM_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####" Hidden="true">
                                                                                                        <Header Caption="누계">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="측정주기" AllowUpdate="NotSet" Key="CHECK_YN"
                                                                                                        Width="30px">
                                                                                                        <Header Caption="측정">
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Footer>
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="마감여부" AllowUpdate="No" Key="CLOSE_YN"
                                                                                                        Width="30px">
                                                                                                        <Header Caption="마감">
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Footer>
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="보고주기" AllowUpdate="NotSet" Key="REPORT_YN"
                                                                                                        Width="98px" Hidden="true">
                                                                                                        <Header Caption="보고주기">
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Footer>
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                                        Key="ESTTERM_REF_ID">
                                                                                                        <Header Caption="ESTTERM_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                                        Hidden="True" Key="KPI_REF_ID">
                                                                                                        <Header Caption="KPI_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" DataType="System.Int32"
                                                                                                        HeaderText="KPI_TARGET_VERSION_ID" Hidden="True" Key="KPI_TARGET_VERSION_ID">
                                                                                                        <Header Caption="KPI_TARGET_VERSION_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="50px"
                                                                                                        Hidden="True">
                                                                                                        <Header Caption="YMD">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ORI_CHECK_YN" HeaderText="ORI_CHECK_YN" Hidden="True"
                                                                                                        Key="ORI_CHECK_YN">
                                                                                                        <Header Caption="ORI_CHECK_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MOD_CHECK_YN" HeaderText="MOD_CHECK_YN" Hidden="True"
                                                                                                        Key="MOD_CHECK_YN">
                                                                                                        <Header Caption="MOD_CHECK_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MONTHLY_CLOSE_YN" HeaderText="MONTHLY_CLOSE_YN"
                                                                                                        Hidden="True" Key="MONTHLY_CLOSE_YN">
                                                                                                        <Header Caption="MONTHLY_CLOSE_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="OO_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####" Hidden="true">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                </Columns>
                                                                                            </ig:UltraGridBand>
                                                                                        </Bands>
                                                                                        <DisplayLayout Version="4.00" AllowColSizingDefault="Free" AllowUpdateDefault="Yes"
                                                                                            AutoGenerateColumns="False" HeaderClickActionDefault="NotSet" Name="ugrdPlan"
                                                                                            BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Vertical"
                                                                                            RowHeightDefault="22px" JavaScriptFileName="" JavaScriptFileNameCommon="" CellClickActionDefault="Edit"
                                                                                            StationaryMargins="Header" OptimizeCSSClassNamesOutput="False" TableLayout="Fixed">
                                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                            </SelectedRowStyleDefault>
                                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                            </RowAlternateStyleDefault>
                                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                            </HeaderStyleDefault>
                                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                            </FrameStyle>
                                                                                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate" />
                                                                                        </DisplayLayout>
                                                                                    </ig:UltraWebGrid>
                                                                                    <ig:UltraWebGrid ID="ugrdPlanB" runat="server" Height="100%" Width="99%" Visible="false">
                                                                                        <Bands>
                                                                                            <ig:UltraGridBand>
                                                                                                <Columns>
                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="목표&lt;BR /&gt;시기" Key="YMD_DESC"
                                                                                                        Width="50px">
                                                                                                        <Header Caption="목표&lt;BR /&gt;시기">
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="MS_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누계" Key="TS_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="누계">
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MM_PLAN" HeaderText="당월" Key="MM_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="당월">
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="TM_PLAN" HeaderText="누계" Key="TM_PLAN" DataType="System.Double"
                                                                                                        Type="Custom" Width="98px" Format="###,###.####">
                                                                                                        <Header Caption="누계">
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                                        Key="ESTTERM_REF_ID">
                                                                                                        <Header Caption="ESTTERM_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                                        Hidden="True" Key="KPI_REF_ID">
                                                                                                        <Header Caption="KPI_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_TARGET_VERSION_ID" DataType="System.Int32"
                                                                                                        HeaderText="KPI_TARGET_VERSION_ID" Hidden="True" Key="KPI_TARGET_VERSION_ID">
                                                                                                        <Header Caption="KPI_TARGET_VERSION_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="50px"
                                                                                                        Hidden="True">
                                                                                                        <Header Caption="YMD">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                        </CellStyle>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ORI_CHECK_YN" HeaderText="ORI_CHECK_YN" Hidden="True"
                                                                                                        Key="ORI_CHECK_YN">
                                                                                                        <Header Caption="ORI_CHECK_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MOD_CHECK_YN" HeaderText="MOD_CHECK_YN" Hidden="True"
                                                                                                        Key="MOD_CHECK_YN">
                                                                                                        <Header Caption="MOD_CHECK_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="MONTHLY_CLOSE_YN" HeaderText="MONTHLY_CLOSE_YN"
                                                                                                        Hidden="True" Key="MONTHLY_CLOSE_YN">
                                                                                                        <Header Caption="MONTHLY_CLOSE_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                </Columns>
                                                                                            </ig:UltraGridBand>
                                                                                        </Bands>
                                                                                        <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowColSizingDefault="Free"
                                                                                            AllowUpdateDefault="Yes" AutoGenerateColumns="False" HeaderClickActionDefault="NotSet"
                                                                                            Name="ugrdPlan" BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Vertical"
                                                                                            RowHeightDefault="22px" JavaScriptFileName="" JavaScriptFileNameCommon="" CellClickActionDefault="Edit"
                                                                                            StationaryMargins="Header" OptimizeCSSClassNamesOutput="False" TableLayout="Fixed">
                                                                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                                            </GroupByRowStyleDefault>
                                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                            </SelectedRowStyleDefault>
                                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                            </RowAlternateStyleDefault>
                                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                            </HeaderStyleDefault>
                                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                            </FrameStyle>
                                                                                            <ClientSideEvents AfterCellUpdateHandler="AfterCellUpdate" />
                                                                                        </DisplayLayout>
                                                                                    </ig:UltraWebGrid>
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="cssPopBtnLine">
                                                                                <td>
                                                                                    <asp:ImageButton ID="iBtnSave" runat="server" OnClick="ibtnSave_Click" Height="19px"
                                                                                        ImageUrl="~/images/btn/b_tp07.gif" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 140px;">
                                                                                    <!--------------------------------- 점수구간 그리드 ---------------------------->
                                                                                    <ig:UltraWebGrid ID="ugrdSignal" runat="server" Height="100%" Width="100%" OnInitializeLayout="ugrdSignal_InitializeLayout"
                                                                                        OnInitializeRow="ugrdSignal_InitializeRow">
                                                                                        <Bands>
                                                                                            <ig:UltraGridBand>
                                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                                </AddNewRow>
                                                                                                <Columns>
                                                                                                    <ig:UltraGridColumn BaseColumnName="SIGNAL" HeaderText="상태" Key="SIGNAL" Width="30px">
                                                                                                        <Header Caption="상태">
                                                                                                        </Header>
                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="IMAG_PATH" HeaderText="신호" Key="IMAG_PATH" DataType="System.Double"
                                                                                                        Type="Custom" Width="80px">
                                                                                                        <Header Caption="신호">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="THRS_DESC" HeaderText="구간" Key="THRS_DESC" DataType="System.Double"
                                                                                                        Type="Custom" Width="80px">
                                                                                                        <Header Caption="구간">
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="SET_MIN_VALUE" HeaderText="계획" Key="SET_MIN_VALUE"
                                                                                                        DataType="System.Double" Type="Custom" Width="80px" Format="##,##0.00">
                                                                                                        <Header Caption="계획">
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" HeaderText="달성율" Key="ACHIEVE_RATE"
                                                                                                        DataType="System.Double" Type="Custom" Width="80px">
                                                                                                        <Header Caption="달성율">
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="POINT" HeaderText="점수" Key="POINT" DataType="System.Double"
                                                                                                        Type="Custom" Width="70px">
                                                                                                        <Header Caption="점수">
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="SET_MAX_VALUE" HeaderText="계획" Key="SET_MAX_VALUE"
                                                                                                        DataType="System.Double" Type="Custom" Width="80px" Hidden="true">
                                                                                                        <Header Caption="계획">
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Header>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                                        Key="ESTTERM_REF_ID">
                                                                                                        <Header Caption="ESTTERM_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                                        Hidden="True" Key="KPI_REF_ID">
                                                                                                        <Header Caption="KPI_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="THRESHOLD_REF_ID" DataType="System.Int32" HeaderText="THRESHOLD_REF_ID"
                                                                                                        Hidden="True" Key="THRESHOLD_REF_ID">
                                                                                                        <Header Caption="THRESHOLD_REF_ID">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="THRESHOLD_LEVEL" DataType="System.String" HeaderText="THRESHOLD_LEVEL"
                                                                                                        Hidden="True" Key="THRESHOLD_LEVEL">
                                                                                                        <Header Caption="THRESHOLD_LEVEL">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="BASE_LINE_YN" DataType="System.String" HeaderText="BASE_LINE_YN"
                                                                                                        Hidden="True" Key="BASE_LINE_YN">
                                                                                                        <Header Caption="BASE_LINE_YN">
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                    <ig:UltraGridColumn BaseColumnName="T_CODE" DataType="System.Int32" HeaderText="T_CODE"
                                                                                                        Hidden="True" Key="T_CODE">
                                                                                                        <Header Caption="T_CODE">
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Header>
                                                                                                        <Footer>
                                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                                        </Footer>
                                                                                                    </ig:UltraGridColumn>
                                                                                                </Columns>
                                                                                            </ig:UltraGridBand>
                                                                                        </Bands>
                                                                                        <DisplayLayout CellPaddingDefault="2" Version="4.00" AllowColSizingDefault="Free"
                                                                                            AllowUpdateDefault="Yes" AutoGenerateColumns="False" HeaderClickActionDefault="NotSet"
                                                                                            Name="ugrdSignal" BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Both"
                                                                                            RowHeightDefault="20px" JavaScriptFileName="" JavaScriptFileNameCommon="" OptimizeCSSClassNamesOutput="False"
                                                                                            TabDirection="TopToBottom" CellClickActionDefault="Edit">
                                                                                            <%--<GroupByBox>
                                                                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                                            </GroupByBox>
                                                                                            <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                                                <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                                            </GroupByRowStyleDefault>
                                                                                            <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                                                <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                                            </FooterStyleDefault>
                                                                                            <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                                                <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                                                <Padding Left="2px" />
                                                                                            </RowStyleDefault>
                                                                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                                                <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                                            </HeaderStyleDefault>
                                                                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                                            </EditCellStyleDefault>
                                                                                            <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="140px" Width="100%">
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
                                                                                            <ClientSideEvents AfterCellUpdateHandler="calcAchvRate"  />
                                                                                            <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                                                                             ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                                                                             GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                                                                             RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />--%>
                                                                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                                            </GroupByRowStyleDefault>
                                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                            </SelectedRowStyleDefault>
                                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                            </RowAlternateStyleDefault>
                                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                            </HeaderStyleDefault>
                                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                            </FrameStyle>
                                                                                            <ClientSideEvents AfterCellUpdateHandler="calcAchvRate" />
                                                                                        </DisplayLayout>
                                                                                    </ig:UltraWebGrid>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="tableLeftSpace" style="width: 35%; height: 100%; padding-top: 5px;" valign="top">
                                                                        <!--------------------------------- 목표/실적, 점수 기울기 그래프 ---------------------------->
                                                                        <ig:UltraWebTab runat="server" ID="ugrdGraphTab" Height="311px" ThreeDEffect="false"
                                                                            Width="100%">
                                                                            <Tabs>
                                                                                <ig:Tab Text="5년간 목표추이" Key="1">
                                                                                    <Style Width="150px" Height="20px" Font-Bold="True" />
                                                                                    <ContentTemplate>
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tr>
                                                                                                <td style="height: 200px; vertical-align: top;">
                                                                                                    <asp:Chart ID="chartTarget" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                                                                                        Palette="None" Height="150px" Width="400px">
                                                                                                        <ChartAreas>
                                                                                                            <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" ShadowColor="Transparent">
                                                                                                                <AxisX IsLabelAutoFit="False" LineColor="196, 196, 196" Interval="1">
                                                                                                                    <LabelStyle Font="Tahoma, 9px" />
                                                                                                                    <MajorGrid LineColor="196, 196, 196" />
                                                                                                                </AxisX>
                                                                                                                <Area3DStyle WallWidth="2" />
                                                                                                                <AxisY LineColor="196, 196, 196" IsLabelAutoFit="False">
                                                                                                                    <LabelStyle Font="Tahoma, 9px" />
                                                                                                                    <MajorGrid LineColor="196, 196, 196" />
                                                                                                                </AxisY>
                                                                                                            </asp:ChartArea>
                                                                                                        </ChartAreas>
                                                                                                        <Legends>
                                                                                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                                                                                Enabled="False" LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                                                                            </asp:Legend>
                                                                                                        </Legends>
                                                                                                    </asp:Chart>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 100px; vertical-align: top;">
                                                                                                    <ig:UltraWebGrid ID="ugrdTRStatus" runat="server" OnInitializeRow="ugrdTRStatus_InitializeRow"
                                                                                                        OnInitializeLayout="ugrdTRStatus_InitializeLayout" Width="100%" Height="100%">
                                                                                                        <DisplayLayout RowHeightDefault="18px" Version="3.00" SelectTypeRowDefault="Single"
                                                                                                            RowSelectorsDefault="No" BorderCollapseDefault="NotSet" AllowColSizingDefault="Free"
                                                                                                            Name="ugrdTRStatus" TableLayout="Fixed" ReadOnly="LevelTwo" OptimizeCSSClassNamesOutput="False"
                                                                                                            CellClickActionDefault="RowSelect">
                                                                                                            <%--<AddNewBox Hidden="False" ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                                                                                                    <BoxStyle BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                                                                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                                                                                        </BorderDetails>
                                                                                                    </BoxStyle>
                                                                                                    <ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
                                                                                                </AddNewBox>
                                                                                                <HeaderStyleDefault BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif" BorderStyle="Solid" HorizontalAlign="Center"
                                                                                                    ForeColor="White" BackColor="#94BAC9" Font-Bold="False">
                                                                                                    <Padding Left="0px" Right="0px"></Padding>
                                                                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                                </HeaderStyleDefault>
                                                                                                <GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
                                                                                                <RowSelectorStyleDefault BorderWidth="0px" BorderStyle="None" BackColor="White"></RowSelectorStyleDefault>
                                                                                                <FrameStyle Width="100%" Cursor="Hand" BorderWidth="1px" Font-Size="9pt" Font-Names="Microsoft Sans Serif"
                                                                                                    BorderStyle="Solid" BackColor="#FFFFFF" Height="70px"></FrameStyle>
                                                                                                <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                                                                                    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                                                </FooterStyleDefault>
                                                                                                <ActivationObject BorderColor="170, 184, 131" BorderWidth=""></ActivationObject>
                                                                                                <GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
                                                                                                    <BoxStyle BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
                                                                                                    </BoxStyle>
                                                                                                    <BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
                                                                                                </GroupByBox>
                                                                                                <RowExpAreaStyleDefault BackColor="WhiteSmoke"></RowExpAreaStyleDefault>
                                                                                                <EditCellStyleDefault VerticalAlign="Middle" BorderWidth="0px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderStyle="None"
                                                                                                    HorizontalAlign="Left"></EditCellStyleDefault>
                                                                                                <SelectedRowStyleDefault ForeColor="White" BackColor="#BECA98"></SelectedRowStyleDefault>
                                                                                                <SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
                                                                                                <RowStyleDefault VerticalAlign="Middle" BorderWidth="1px" Font-Size="8pt" Font-Names="Microsoft Sans Serif" BorderColor="#AAB883"
                                                                                                    BorderStyle="Solid" HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
                                                                                                    <Padding Left="3px" Right="3px"></Padding>
                                                                                                    <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                                                                                                </RowStyleDefault>
                                                                                                <ClientSideEvents DblClickHandler="AfterSelectChangeHandler"  />
                                                                                                <Images>
                                                                                                    <CollapseImage Url="../images/tree/ig_treeMinus.gif" />
                                                                                                    <ExpandImage Url="../images/tree/ig_treePlus.gif" />
                                                                                                    <CurrentRowImage Url="../images/tree/arrow_brown.gif" />
                                                                                                    <CurrentEditRowImage Url="../images/tree/arrow_brown.gif" />
                                                                                                </Images>--%>
                                                                                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                                                            </GroupByRowStyleDefault>
                                                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                                            </SelectedRowStyleDefault>
                                                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                                            </RowAlternateStyleDefault>
                                                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                                            </HeaderStyleDefault>
                                                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                                            </FrameStyle>
                                                                                                        </DisplayLayout>
                                                                                                        <Bands>
                                                                                                            <ig:UltraGridBand>
                                                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                                                </AddNewRow>
                                                                                                            </ig:UltraGridBand>
                                                                                                        </Bands>
                                                                                                    </ig:UltraWebGrid>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </ig:Tab>
                                                                                <ig:TabSeparator>
                                                                                    <Style Width="0px">
                                                                                        </Style>
                                                                                </ig:TabSeparator>
                                                                                <ig:Tab Text="평가 그래프" Key="2">
                                                                                    <Style Width="150px" Height="20px" Font-Bold="True" />
                                                                                    <ContentTemplate>
                                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td style="height: 145px; vertical-align: top;">
                                                                                                    <asp:Chart ID="chartScore" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                                                                                        Palette="None" Height="150px" Width="400px">
                                                                                                        <ChartAreas>
                                                                                                            <asp:ChartArea BackColor="White" BorderColor="196, 196, 196" Name="Default" ShadowColor="Transparent">
                                                                                                                <AxisX IsLabelAutoFit="False" LineColor="196, 196, 196" Interval="1">
                                                                                                                    <LabelStyle Font="Tahoma, 9px" />
                                                                                                                    <MajorGrid LineColor="196, 196, 196" />
                                                                                                                </AxisX>
                                                                                                                <Area3DStyle WallWidth="2" />
                                                                                                                <AxisY LineColor="196, 196, 196" IsLabelAutoFit="False">
                                                                                                                    <LabelStyle Font="Tahoma, 9px" />
                                                                                                                    <MajorGrid LineColor="196, 196, 196" />
                                                                                                                </AxisY>
                                                                                                            </asp:ChartArea>
                                                                                                        </ChartAreas>
                                                                                                        <Legends>
                                                                                                            <asp:Legend Alignment="Center" BackColor="White" BorderColor="26, 59, 105" Docking="Top"
                                                                                                                Enabled="False" LegendStyle="Row" Name="Default" ShadowOffset="2">
                                                                                                            </asp:Legend>
                                                                                                        </Legends>
                                                                                                    </asp:Chart>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </ig:Tab>
                                                                            </Tabs>
                                                                            <DefaultTabStyle BackColor="White" Height="20px">
                                                                            </DefaultTabStyle>
                                                                            <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif"
                                                                                SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                                                                        </ig:UltraWebTab>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="tableLeftSpace" colspan="2" style="width: 35%; height: 50%" valign="top">
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="height: 140px; width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                                                                                        <tr>
                                                                                            <td style="width: 1%;">
                                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="목표 및 등급구간 설정근거" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 75px; vertical-align: top;">
                                                                                    <asp:TextBox ID="txtTargetReason" runat="server" TextMode="MultiLine" Height="100%"
                                                                                        Width="100%"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 20px; vertical-align: top;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 20px; vertical-align: top;">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                                                                                                    <tr>
                                                                                                        <td style="width: 1%;">
                                                                                                            <img src="../images/title/ma_t14.gif" alt="" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="첨부파일" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;
                                                                                                <asp:ImageButton ID="iBtnTargetFile_Up" ImageUrl="../images/icon/gr_po05.gif" runat="server"
                                                                                                    OnClientClick="return mfUpload('hdfTargetReasonFile','UP')" />
                                                                                                <asp:ImageButton ID="iBtnTargetFile_Down" ImageUrl="../images/icon/gr_po04.gif" runat="server"
                                                                                                    OnClientClick="return mfUpload('hdfTargetReasonFile','DOWN')" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </ig:Tab>
                                                <ig:TabSeparator>
                                                    <Style Width="1px" />
                                                </ig:TabSeparator>
                                                <ig:Tab Text="PART Ⅳ Initiative 관리" Key="4">
                                                    <Style Width="160px" Height="25px" />
                                                    <ContentTemplate>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                            <%--<tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="width:1%"><img src="../images/title/ma_t14.gif" alt="" /></td>
                                                                    <td>관련 Initiative</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>--%>
                                                            <tr>
                                                                <td style="width: 90%; height: 460px;" valign="top">
                                                                    <ig:UltraWebGrid ID="ugrdInitiative" runat="server" Width="100%" Height="98%" OnInitializeRow="ugrdInitiative_InitializeRow">
                                                                        <Bands>
                                                                            <ig:UltraGridBand>
                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                </AddNewRow>
                                                                                <Columns>
                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Key="ESTTERM_REF_ID"
                                                                                        Width="80px" Hidden="true">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="ESTTERM_REF_ID">
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                        Hidden="True" Key="KPI_REF_ID">
                                                                                        <Header Caption="KPI_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" FooterText="" HeaderText="년월" Key="YMD"
                                                                                        Width="40px" Hidden="True">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="년월">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" FooterText="" HeaderText="년월" Key="YMD_DESC"
                                                                                        Width="60px" AllowUpdate="No">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="년월">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Center" BackColor="WhiteSmoke">
                                                                                        </CellStyle>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:TemplatedColumn BaseColumnName="INITIATIVE_PLAN" FooterText="" HeaderText="추진계획"
                                                                                        Key="INITIATIVE_PLAN" Width="500px" CellMultiline="Yes">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="추진계획">
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Left" Wrap="True">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" ID="txtINITIATIVE_PLAN"
                                                                                                runat="server"></asp:TextBox>
                                                                                        </CellTemplate>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Footer>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:TemplatedColumn BaseColumnName="INITIATIVE_DO" FooterText="" HeaderText="추진내용"
                                                                                        Key="INITIATIVE_DO" Width="250px" CellMultiline="Yes" Hidden="True">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="추진내용">
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Left" Wrap="True">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" ID="txtINITIATIVE_DO"
                                                                                                runat="server"></asp:TextBox>
                                                                                        </CellTemplate>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Footer>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:TemplatedColumn BaseColumnName="INITIATIVE_DESC" FooterText="" HeaderText="특이사항"
                                                                                        Key="INITIATIVE_DESC" Width="250px" CellMultiline="Yes" Hidden="true">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="특이사항">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Left" Wrap="True">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" ID="txtINITIATIVE_DESC"
                                                                                                runat="server"></asp:TextBox>
                                                                                        </CellTemplate>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="CHECK_YN" FooterText="" HeaderText="CHECK_YN"
                                                                                        Key="CHECK_YN" Width="40px" Hidden="true">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Header Caption="CHECK_YN">
                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                        </Header>
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                </Columns>
                                                                                <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                                    <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                                </RowTemplateStyle>
                                                                            </ig:UltraGridBand>
                                                                        </Bands>
                                                                        <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False"
                                                                            BorderCollapseDefault="Separate" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                                            Name="ugrdInitiative" RowHeightDefault="150px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                            StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy"
                                                                            AllowUpdateDefault="Yes">
                                                                            <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="0px" Bottom="0px" Top="0px" Right="0px" />
                                                                </RowStyleDefault>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                </SelectedRowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                    ForeColor="White" HorizontalAlign="Left" Height="23px">
                                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px" Wrap="True">
                                                                </EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="98%">
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
                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                </ActivationObject>--%>
                                                                            <GroupByBox Hidden="True">
                                                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                                                </BoxStyle>
                                                                            </GroupByBox>
                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                            </SelectedRowStyleDefault>
                                                                            <%--<RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>--%>
                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                            </HeaderStyleDefault>
                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                            </FrameStyle>
                                                                        </DisplayLayout>
                                                                    </ig:UltraWebGrid>
                                                                    <asp:Panel ID="pnlPrj" runat="server" Width="100%" Height="100%" Visible="true">
                                                                        <ig:UltraWebGrid ID="ugrdPrjList" runat="server" Width="100%" Height="100%" OnInitializeRow="ugrdPrjList_InitializeRow"
                                                                            OnInitializeLayout="ugrdPrjList_InitializeLayout">
                                                                            <Bands>
                                                                                <ig:UltraGridBand>
                                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                                    </AddNewRow>
                                                                                    <Columns>
                                                                                        <ig:TemplatedColumn Hidden="True" Key="selchk" Width="30px">
                                                                                            <HeaderTemplate>
                                                                                                <asp:CheckBox ID="cBox_header" runat="server" onclick="selectChkBox(this, 'ugrdPrjList');" />
                                                                                            </HeaderTemplate>
                                                                                            <CellTemplate>
                                                                                                <asp:CheckBox ID="cBox" runat="server" />
                                                                                            </CellTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                        </ig:TemplatedColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PRJ_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                                            FooterText="" Format="" HeaderText="PRJ_REF_ID" Hidden="True" Key="PRJ_REF_ID"
                                                                                            Width="40px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="PRJ_REF_ID">
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PRJ_CODE" HeaderText="코드" Hidden="false" Key="PRJ_CODE"
                                                                                            Width="70px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="코드">
                                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PRJ_NAME" EditorControlID="" FooterText="" Format=""
                                                                                            HeaderText="사업명" Key="PRJ_NAME" Width="170px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ValueList DisplayStyle="NotSet">
                                                                                            </ValueList>
                                                                                            <CellStyle HorizontalAlign="Left">
                                                                                            </CellStyle>
                                                                                            <Header Caption="사업명">
                                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PROCEED_RATE" Format="##0.00" HeaderText="진행율(%)"
                                                                                            Key="PROCEED_RATE" Width="70px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Right">
                                                                                            </CellStyle>
                                                                                            <Header Caption="진행율(%)">
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="TASK_OWNER_NAME" HeaderText="수행담당자" Key="TASK_OWNER_NAME"
                                                                                            Width="200px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle Wrap="True">
                                                                                            </CellStyle>
                                                                                            <Header Caption="수행담당자">
                                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PLAN_START_DATE" DataType="System.DateTime" EditorControlID=""
                                                                                            FooterText="" Format="yyyy-MM-dd" HeaderText="시작일자" Key="PLAN_START_DATE" Width="70px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="시작일자">
                                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PLAN_END_DATE" DataType="System.DateTime" EditorControlID=""
                                                                                            FooterText="" Format="yyyy-MM-dd" HeaderText="종료일자" Key="PLAN_END_DATE" Width="70px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="종료일자">
                                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="TOTAL_BUDGET" Format="###,##0.00" HeaderText="예상비용"
                                                                                            Key="TOTAL_BUDGET">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Right">
                                                                                            </CellStyle>
                                                                                            <Header Caption="예상비용">
                                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="SUM_BUDGET" Format="###,##0.00" HeaderText="소요비용"
                                                                                            Key="SUM_BUDGET">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Right">
                                                                                            </CellStyle>
                                                                                            <Header Caption="소요비용">
                                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="OWNER_DEPT_NAME" EditorControlID="" FooterText=""
                                                                                            Format="" HeaderText="주관부서" Hidden="True" Key="OWNER_DEPT_NAME" Width="120px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Left">
                                                                                            </CellStyle>
                                                                                            <Header Caption="주관부서">
                                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="DEFINITION" HeaderText="사업정의" Hidden="True" Key="DEFINITION">
                                                                                            <Header Caption="사업정의">
                                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="REF_STG" HeaderText="전략목표" Hidden="True" Key="REF_STG">
                                                                                            <Header Caption="전략목표">
                                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="RANGE" HeaderText="사업범위" Hidden="True" Key="RANGE">
                                                                                            <Header Caption="사업범위">
                                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="INTERESTED_PARTIES" HeaderText="이해관계자" Hidden="True"
                                                                                            Key="INTERESTED_PARTIES">
                                                                                            <Header Caption="이해관계자">
                                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="REQUEST_DEPT" HeaderText="요청부서기관" Hidden="True"
                                                                                            Key="REQUEST_DEPT">
                                                                                            <Header Caption="요청부서기관">
                                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PRIORITY" HeaderText="중요도" Hidden="True" Key="PRIORITY">
                                                                                            <Header Caption="중요도">
                                                                                                <RowLayoutColumnInfo OriginX="17" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="17" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="OWNER_EMP_NAME" HeaderText="책임자" Hidden="True"
                                                                                            Key="OWNER_EMP_NAME" Width="50px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="책임자">
                                                                                                <RowLayoutColumnInfo OriginX="18" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="18" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PRJ_TYPE_NAME" HeaderText="사업유형" Hidden="True"
                                                                                            Key="PRJ_TYPE_NAME" Width="90px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Left">
                                                                                            </CellStyle>
                                                                                            <Header Caption="사업유형">
                                                                                                <RowLayoutColumnInfo OriginX="19" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="19" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="PRJ_TYPE" HeaderText="사업유형" Hidden="True" Key="PRJ_TYPE">
                                                                                            <Header Caption="사업유형">
                                                                                                <RowLayoutColumnInfo OriginX="20" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="20" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="ACTUAL_START_DATE" DataType="System.DateTime"
                                                                                            EditorControlID="" FooterText="" HeaderText="시작일자" Hidden="True" Key="ACTUAL_START_DATE"
                                                                                            Width="70px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="시작일자">
                                                                                                <RowLayoutColumnInfo OriginX="21" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="21" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="ACTUAL_END_DATE" DataType="System.DateTime" EditorControlID=""
                                                                                            FooterText="" HeaderText="종료일자" Hidden="True" Key="ACTUAL_END_DATE" Width="70px">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                            <Header Caption="종료일자">
                                                                                                <RowLayoutColumnInfo OriginX="22" />
                                                                                            </Header>
                                                                                            <Footer Caption="">
                                                                                                <RowLayoutColumnInfo OriginX="22" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                    </Columns>
                                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                                    </RowTemplateStyle>
                                                                                </ig:UltraGridBand>
                                                                            </Bands>
                                                                            <DisplayLayout CellPaddingDefault="2" AllowColSizingDefault="Free" AllowDeleteDefault="Yes"
                                                                                AllowSortingDefault="Yes" BorderCollapseDefault="Separate" HeaderClickActionDefault="NotSet"
                                                                                Name="ugrdPrjList" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                                Version="4.00" CellClickActionDefault="RowSelect" OptimizeCSSClassNamesOutput="False"
                                                                                TableLayout="Fixed" StationaryMargins="Header" AutoGenerateColumns="False">
                                                                                <%--<GroupByBox>
                                                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                        </GroupByBox>
                                                                        <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                            <BorderDetails  ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                        </GroupByRowStyleDefault>
                                                                        <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                            <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                        </FooterStyleDefault>
                                                                        <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="Hand">
                                                                            <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                            <Padding Left="3px" />
                                                                        </RowStyleDefault>
                                                                        <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
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
                                                                        <ClientSideEvents  DblClickHandler="ugrdPrjList_DblClickHandler" />
                                                                     <ActivationObject BorderColor="" BorderWidth="">
                                                                     </ActivationObject>--%>
                                                                                <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                                </GroupByRowStyleDefault>
                                                                                <RowStyleDefault CssClass="GridRowStyle" />
                                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                                </SelectedRowStyleDefault>
                                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                                </RowAlternateStyleDefault>
                                                                                <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                                <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                                </HeaderStyleDefault>
                                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                                </FrameStyle>
                                                                                <ClientSideEvents DblClickHandler="ugrdPrjList_DblClickHandler" />
                                                                            </DisplayLayout>
                                                                        </ig:UltraWebGrid>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ig:Tab>
                                                <ig:TabSeparator>
                                                    <Style Width="1px" />
                                                </ig:TabSeparator>
                                                <ig:Tab Text="PARTⅤ 정성평가기준 관리" Key="5" Visible="false">
                                                    <Style Width="170px" Height="25px" />
                                                    <ContentTemplate>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                            <tr>
                                                                <td style="height: 25px;">
                                                                    <img src="../images/icon/subtitle.gif" alt="" />평가차수정보
                                                                </td>
                                                                <td style="height: 25px;">
                                                                    <img src="../images/icon/subtitle.gif" alt="" />평가주기별 가중치
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 60%; height: 450px;" valign="top">
                                                                    <ig:UltraWebGrid ID="ugrdEstLevel" runat="server" Height="100%" Width="100%" ImageDirectory=""
                                                                        OnInitializeGroupByRow="ugrdEstLevel_InitializeGroupByRow">
                                                                        <Bands>
                                                                            <ig:UltraGridBand>
                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                </AddNewRow>
                                                                                <Columns>
                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간코드" Key="ESTTERM_REF_ID"
                                                                                        Width="38px" Hidden="True">
                                                                                        <Header Caption="평가기간코드">
                                                                                        </Header>
                                                                                        <HeaderStyle Wrap="True" />
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_REF_ID" HeaderText="지표군 코드" Key="KPI_GROUP_REF_ID"
                                                                                        Type="Custom" Width="70px" Hidden="True">
                                                                                        <Header Caption="지표군 코드">
                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_GROUP_NAME" HeaderText="지표군명" Key="KPI_GROUP_NAME"
                                                                                        Type="Custom" Width="100px" Hidden="True">
                                                                                        <Header Caption="지표군명">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL" HeaderText="평가차수ID" Key="EST_LEVEL"
                                                                                        Type="Custom" Width="70px" Hidden="True">
                                                                                        <Header Caption="평가차수ID">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" HeaderText="평가차수명" Key="EST_LEVEL_NAME"
                                                                                        Type="Custom" Width="100px">
                                                                                        <Header Caption="평가차수명">
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:TemplatedColumn BaseColumnName="SETTLE_MEAN_YN" Key="SETTLE_MEAN_YN" EditorControlID=""
                                                                                        Width="35px" FooterText="" HeaderText="평균조정여부" Hidden="false">
                                                                                        <Header Caption="평균조정여부">
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Header>
                                                                                        <HeaderStyle Wrap="True" />
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:CheckBox runat="server" ID="chkUse" Enabled="false"></asp:CheckBox>
                                                                                        </CellTemplate>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Footer>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:TemplatedColumn BaseColumnName="SETTLE_DEVIATION_YN" Key="SETTLE_DEVIATION_YN"
                                                                                        EditorControlID="" Width="35px" FooterText="" HeaderText="편차조정여부" Hidden="false">
                                                                                        <Header Caption="편차조정여부">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <HeaderStyle Wrap="True" />
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:CheckBox runat="server" ID="chkUse" Enabled="false"></asp:CheckBox>
                                                                                        </CellTemplate>
                                                                                        <Footer Caption="">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" Type="Custom"
                                                                                        Width="60px" DataType="System.Double">
                                                                                        <Header Caption="가중치">
                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle HorizontalAlign="Right">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_ORDER" HeaderText="평가순서" Key="EST_ORDER"
                                                                                        Type="Custom" Width="60px" DataType="System.Int32">
                                                                                        <Header Caption="평가순서">
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle HorizontalAlign="Right">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_DEPT_NAME" HeaderText="평가부서" Key="EST_DEPT_NAME"
                                                                                        Width="100px" Hidden="True">
                                                                                        <Header Caption="평가부서">
                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="9" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_USER_NAME" HeaderText="평가자" Key="EST_USER_NAME"
                                                                                        Width="100px" Hidden="True">
                                                                                        <Header Caption="평가자">
                                                                                            <RowLayoutColumnInfo OriginX="10" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="10" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" HeaderText="EST_EMP_ID" Key="EST_EMP_ID"
                                                                                        Width="100px" Hidden="True">
                                                                                        <Header Caption="EST_EMP_ID">
                                                                                            <RowLayoutColumnInfo OriginX="11" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="11" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="DESCRIPTINS" HeaderText="기타사항" Key="DESCRIPTINS"
                                                                                        Width="210px" Hidden="false">
                                                                                        <Header Caption="기타사항">
                                                                                            <RowLayoutColumnInfo OriginX="13" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="13" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                </Columns>
                                                                            </ig:UltraGridBand>
                                                                        </Bands>
                                                                        <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                                            CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="NotSet"
                                                                            JavaScriptFileName="" JavaScriptFileNameCommon="" Name="ugrdEstLevel" RowHeightDefault="20px"
                                                                            RowSelectorsDefault="No" OptimizeCSSClassNamesOutput="False" ScrollBarView="Horizontal"
                                                                            Version="4.00">
                                                                            <%--<GroupByBox>
                                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                    </GroupByBox>
                                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                        <BorderDetails ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                    </GroupByRowStyleDefault>
                                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                    </FooterStyleDefault>
                                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                        <Padding Left="3px" />
                                                                    </RowStyleDefault>
                                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                        ForeColor="White" HorizontalAlign="Center">
                                                                        <BorderDetails ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                    </HeaderStyleDefault>
                                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                    </EditCellStyleDefault>
                                                                    <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid" BorderWidth="1px"
                                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                                                                    <ClientSideEvents  DblClickHandler="ugrdEstLevel_DblClickHandler" />
                                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                                    </ActivationObject>
                                                                    <Images ImageDirectory="">
                                                                    </Images>--%>
                                                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                            </GroupByRowStyleDefault>
                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                            </SelectedRowStyleDefault>
                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                            </RowAlternateStyleDefault>
                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                            </HeaderStyleDefault>
                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                            </FrameStyle>
                                                                            <ClientSideEvents DblClickHandler="ugrdEstLevel_DblClickHandler" />
                                                                        </DisplayLayout>
                                                                    </ig:UltraWebGrid>
                                                                </td>
                                                                <td style="width: 40%; height: 450px;" valign="top">
                                                                    <ig:UltraWebGrid ID="ugrdQuestionTerm" runat="server" Height="100%" Width="100%"
                                                                        OnInitializeRow="ugrdQuestionTerm_InitializeRow">
                                                                        <Bands>
                                                                            <ig:UltraGridBand>
                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                </AddNewRow>
                                                                                <Columns>
                                                                                    <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="입력구분" Key="ITYPE" DataType="System.String"
                                                                                        Hidden="true" Width="40px">
                                                                                        <Header Caption="입력구분">
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:TemplatedColumn Key="selchk" Width="25px">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor: hand; vertical-align: middle;"
                                                                                                onclick="selectChkBox('ugrdQuestionItem')" />
                                                                                        </HeaderTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:CheckBox ID="cBox" runat="server" />
                                                                                        </CellTemplate>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간코드" Key="ESTTERM_REF_ID"
                                                                                        Width="38px" Hidden="True">
                                                                                        <Header Caption="평가기간코드">
                                                                                        </Header>
                                                                                        <HeaderStyle Wrap="True" />
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Hidden="True"
                                                                                        Key="KPI_REF_ID">
                                                                                        <Header Caption="KPI_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL" HeaderText="EST_LEVEL" Hidden="true"
                                                                                        Key="EST_LEVEL" Width="40px">
                                                                                        <Header Caption="EST_LEVEL">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" HeaderText="EST_LEVEL_NAME" Hidden="false"
                                                                                        Key="EST_LEVEL_NAME" Width="120px" MergeCells="false">
                                                                                        <Header Caption="차수명">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <CellStyle BackColor="whitesmoke">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Hidden="false" Key="YMD"
                                                                                        Width="60px">
                                                                                        <Header Caption="평가년월">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <CellStyle BackColor="whitesmoke">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="WEIGHT" Key="WEIGHT" DataType="System.Double"
                                                                                        NullText="0" Width="60px" AllowUpdate="Yes">
                                                                                        <Header Caption="가중치">
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle HorizontalAlign="Right">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="CHECK_YN" HeaderText="CHECK_YN" Hidden="true"
                                                                                        Key="CHECK_YN" Width="60px">
                                                                                        <Header Caption="CHECK_YN">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                </Columns>
                                                                            </ig:UltraGridBand>
                                                                        </Bands>
                                                                        <DisplayLayout Version="4.00" AllowUpdateDefault="No" HeaderClickActionDefault="NotSet"
                                                                            Name="ugrdQuestionTerm" BorderCollapseDefault="Separate" RowSelectorsDefault="No"
                                                                            RowHeightDefault="20px" HeaderStyleDefault-Height="30px" SelectTypeRowDefault="Single"
                                                                            TableLayout="Fixed" AutoGenerateColumns="False" AllowRowNumberingDefault="Continuous"
                                                                            OptimizeCSSClassNamesOutput="False" StationaryMargins="HeaderAndFooter">
                                                                            <%--<GroupByBox>
                                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                </GroupByBox>
                                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                                    <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>                                                
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="3px" />
                                                                </RowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White">
                                                                    <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                </EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
                                                                </FrameStyle>
                                                                <Pager>
                                                                <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                </PagerStyle>
                                                                </Pager>
                                                                <AddNewBox Hidden="False" Prompt="행추가">
                                                                <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                                </BoxStyle>
                                                                </AddNewBox>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                                </SelectedRowStyleDefault>
                                                                    <ClientSideEvents  AfterRowInsertHandler="ugrdDetail_AfterRowInsertHandler" />
                                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                                    </ActivationObject>
                                                                --%>
                                                                            <GroupByRowStyleDefault CssClass="GridGroupBoxStyle">
                                                                            </GroupByRowStyleDefault>
                                                                            <RowStyleDefault CssClass="GridRowStyle" />
                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                            </SelectedRowStyleDefault>
                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                            </RowAlternateStyleDefault>
                                                                            <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                            </HeaderStyleDefault>
                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                            </FrameStyle>
                                                                        </DisplayLayout>
                                                                    </ig:UltraWebGrid>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ig:Tab>
                                            </Tabs>
                                            <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff" />
                                            <SelectedTabStyle CssClass="cssTabStyleOn" />
                                            <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif"
                                                SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                                        </ig:UltraWebTab>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="content" align="left">
                                        &nbsp;
                                        <asp:ImageButton ID="iBtnAddTarget" ImageUrl="../images/btn/b_090.gif" runat="server"
                                            OnClientClick="return OpenTargetForm()" Visible="false" />
                                        <asp:ImageButton ID="iBtnAddChildKpi" ImageUrl="../images/btn/b_092.gif" runat="server"
                                            OnClientClick="return OpenChildKpiForm()" Visible="false" />
                                        <%--<a href="#null" onclick = "return doPoppingUpGoalTong();">골통팝업</a>--%>
                                        <asp:ImageButton ID="iBtnGoalTong" ImageUrl="../images/btn/btn_goalinput.gif" runat="server"
                                            OnClientClick="return doPoppingUpGoalTong()" Visible="false" />
                                    </td>
                                    <td class="cssPopBtnLine">
                                        <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif"
                                            Visible="false" OnClick="ImgBtnPrint_Click" />
                                        <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server"
                                            OnClick="iBtnInsert_Click" />
                                        <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server"
                                            OnClick="iBtnUpdate_Click" />
                                        <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_004.gif" runat="server"
                                            OnClick="iBtnDelete_Click" OnClientClick="return DeleteKpi();" />
                                        <asp:ImageButton ID="iBtnUsed" ImageUrl="../images/btn/b_138.gif" runat="server"
                                            OnClick="iBtnUsed_Click" />
                                        <asp:ImageButton ID="iBtnDraft" ImageUrl="../images/draft/draft.gif" runat="server"
                                            Visible="false" />
                                        <asp:ImageButton ID="iBtnReDraft" ImageUrl="../images/draft/redraft.gif" runat="server"
                                            Visible="false" />
                                        <asp:ImageButton ID="iBtnReWrite" ImageUrl="../images/draft/rewrite.gif" runat="server"
                                            Visible="false" />
                                        <asp:ImageButton ID="iBtnMoDraft" ImageUrl="../images/draft/modraft.gif" runat="server"
                                            Visible="false" />
                                        <asp:ImageButton ID="iBtnReqModify" ImageUrl="../images/draft/morequest.gif" runat="server"
                                            Visible="false" OnClick="iBtnReqModify_Click" />
                                        <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server"
                                            OnClick="iBtnClose_Click" />
                                        <asp:Button ID="iBtnKpiCopy" runat="server" OnClick="iBtnKpiCopy_Click" Visible="false" />
                                        <asp:Button ID="iBtnExistsKpi" runat="server" OnClick="iBtnExistsKpi_Click" Visible="false" />
                                        <asp:LinkButton ID="linkBtnRegTarget" runat="server" Visible="false" OnClick="linkBtnRegTarget_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkBtnSelKpiPool" runat="server" Visible="false" OnClick="linkBtnSelKpiPool_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkBtnDraft" runat="server" Visible="false" OnClick="linkBtnDraft_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; background-color: #FFFFFF">
                        </td>
                    </tr>
                </table>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:HiddenField ID="hdfImagePath" runat="server" Value="" />
                <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport"
                    OnCellExporting="ugrdEEP_CellExporting" OnCellExported="ugrdEEP_CellExported" />
                <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
