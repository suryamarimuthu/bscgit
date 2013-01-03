<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0302M6.aspx.cs"
    Inherits="BSC_BSC0302M6" ValidateRequest="false" %>

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
    
    
    function doPoppingUpGoalTong()
    {
        var estterm_ref_id  = "<%= IEstTermRefID %>";
        var kpi_ref_id      = "<%= IKpiRefID %>";
        var kpi_pool_ref_id = document.getElementById('hdfKpiPoolRefID').value;
        
        
        var url = 'BSC0302M1M1.aspx?iType=U&IS_TEAM_KPI=Y&ESTTERM_REF_ID=' + estterm_ref_id + '&KPI_POOL_REF_ID=' + kpi_pool_ref_id +'&KPI_REF_ID=' + kpi_ref_id ;

        gfOpenWindow(url, 600, 500, 'no', 'no', 'BSC0302M1M1');
        return false;
    
    }
    
    function MouseOverHandler(gridName, id, objectType)
    {
	    if(objectType == 0) 
	    { // Are we over a cell
           var cell = igtbl_getElementById(id);
           var row = igtbl_getRowById(id);
           var band = igtbl_getBandById(id);
           var active = igtbl_getActiveRow(id);
           cell.style.cursor = 'hand';
        }
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
        
        SetTermToTarget();
        
        return false;
    }
    
    function SetTermToTarget()
    {
        if (isCounting)
            return;
        isCounting = true;
        
        var calcType = document.getElementById('<%= ddlResultTsCalcType.ClientID %>');
        var calcTypeValue = calcType.options[calcType.selectedIndex].value;
        
        var ugrd = igtbl_getGridById('<%= ugrdTerm.ClientID %>');
        if (ugrd.Rows.length < 1)
            return false;

        var chkRowCnt = 0;
        var planTotal = 0.0000;
        var chkTerm = "";
        var closeYN = "";

        for (var i = 0; i < ugrd.Rows.length; i++)
        {
            var tRow = ugrd.Rows.getRow(i);
            closeYN = (tRow.getCellFromKey("CLOSE_YN").getValue() == null ? "N" : tRow.getCellFromKey("CLOSE_YN").getValue());
            var chkYN = igtbl_getElementById(tRow.getCellFromKey("CHECK_YN").Id).children(0);
            if (chkYN.checked)
            {
                planTotal += parseFloat((tRow.getCellFromKey("MS_PLAN").getValue() == null ? 0 : tRow.getCellFromKey("MS_PLAN").getValue()));
                chkRowCnt += 1;
                chkTerm = "Y";
            }
            else
                chkTerm = "N";
            
            if (closeYN == "Y")
            {            
                igtbl_getCellById(tRow.getCellFromKey("MS_PLAN").Id).setEditable(false);
                igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable(false);
                igtbl_getElementById(tRow.getCellFromKey("MS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
                igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
            }
            else
            {
                if (chkTerm == "N")
                {
                    igtbl_getCellById(tRow.getCellFromKey("MS_PLAN").Id).setEditable(false);
                    igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable(false);
                    igtbl_getElementById(tRow.getCellFromKey("MS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
                    igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
                    tRow.getCellFromKey("MS_PLAN").setValue(0);
                    tRow.getCellFromKey("TS_PLAN").setValue(0);
                    
                    switch (calcTypeValue)
                    {
                        case "SUM": // 단순합계
                            tRow.getCellFromKey("TS_PLAN").setValue(parseFloat(planTotal.toFixed(4)));
                            break;
                        case "AVG": // 단순평균
                            tRow.getCellFromKey("TS_PLAN").setValue((chkRowCnt == 0) ? planTotal : parseFloat((planTotal / chkRowCnt).toFixed(4)));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    igtbl_getCellById(tRow.getCellFromKey("MS_PLAN").Id).setEditable(true);
                    igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable(true);
                    igtbl_getElementById(tRow.getCellFromKey("MS_PLAN").Id).style.backgroundColor = "White";
                    igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = "White";

                    //var calcType = document.getElementById('<%= ddlResultTsCalcType.ClientID %>');
                    var tmpSval = (tRow.getCellFromKey("MS_PLAN").getValue() == null ? 0 : parseFloat(tRow.getCellFromKey("MS_PLAN").getValue()).toFixed(4));
                    tRow.getCellFromKey("MS_PLAN").setValue(tmpSval);
                    switch (calcTypeValue)
                    {
                        case "SUM": // 단순합계
                            tRow.getCellFromKey("TS_PLAN").setValue(parseFloat(planTotal.toFixed(4)));
                            igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable(false);
                            igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
                            break;
                        case "AVG": // 단순평균
                            tRow.getCellFromKey("TS_PLAN").setValue((chkRowCnt == 0) ? planTotal : parseFloat((planTotal / chkRowCnt).toFixed(4)));
                            igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable(false);
                            igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
                            break;
                        case "OTS": // 누적만측정
                            igtbl_getCellById(tRow.getCellFromKey("MS_PLAN").Id).setEditable(false);
                            igtbl_getElementById(tRow.getCellFromKey("MS_PLAN").Id).style.backgroundColor = "WhiteSmoke";
                            igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable((chkTerm == "N" ? false : true));
                            igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = (chkTerm == "N" ? "WhiteSmoke" : "White");
                            tRow.getCellFromKey("MS_PLAN").setValue(0);
                            break;
                        default:
                            igtbl_getCellById(tRow.getCellFromKey("TS_PLAN").Id).setEditable((chkTerm == "N" ? false : true));
                            igtbl_getElementById(tRow.getCellFromKey("TS_PLAN").Id).style.backgroundColor = (chkTerm == "N" ? "WhiteSmoke" : "White");
                            break;
                    }
                }
            }
        }
        isCounting = false;
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
            
            if(isNaN(parseFloat(objTmpRow.getCell(3).getValue())))
            {
                objTbl.Rows.getRow(i).getCell(5).setValue(0);
            }
            else
            {
                if (strColType=='ATY' || strColType=='BTY')      //A Type
                {
                    dblCur  = parseFloat(objTmpRow.getCell(3).getValue());
                    dblRate = (dblini==0) ? 0 : (dblCur/dblini)*100;
                    objTbl.Rows.getRow(i).getCell(5).setValue(dblRate);
                }
                else
                {
                    objTbl.Rows.getRow(i).getCell(5).setValue("");
                }
            }
        }
        
    }
   
   function OpenTargetForm()
   {
        var estterm_ref_id  = "<%= IEstTermRefID %>";
        var kpi_ref_id      = "<%= IKpiRefID %>";
        var url             = "BSC0303M1.aspx?iTYPE=A&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id;
        
        gfOpenWindow(url, 700, 500, 'yes', 'no', 'BSC0303M1');
        
        return false;
   }
   
    function openDeptEmp(strKeyObj, strValObj)
    {
        var tab = igtab_getTabById("ugrdKpiStatusTab");
        var objKey = tab.findControl(strKeyObj);
        var objVal = tab.findControl(strValObj);
        
        strKeyObj = objKey.name;
        strValObj = objVal.name;

        var estterm_ref_id  = "<%= IEstTermRefID %>";
        var url             = "../ctl/ctl2106.aspx?ESTTERM_REF_ID="+ estterm_ref_id +"&OBJ_KEY="+ strKeyObj + "&OBJ_VAL=" + strValObj;
        
        gfOpenWindow(url, 750, 400, 'yes', 'no', 'ctl2106');
    }
    
    function openKpiPoolList(strObjKey, strObjVal)
    {
        var url             = "BSC0301S2.aspx?OBJ_KEY="+strObjKey+"&OBJ_VAL="+strObjVal;
        gfOpenWindow(url, 850, 550, 'yes', 'no', 'BSC0301S2');
        
        return false;
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
        
        //alert(oAttach.value);
        
        var oReturn = "";
        if (strUpDown == "UP")
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=T", oaArg, 450, 307);
        }
        else
        {
            oReturn = gfOpenDialog("../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F", oaArg, 450, 307);
        }
        
        //alert(oReturn);
        
        if (oReturn != "" && oReturn != undefined && oReturn.length > 5)
        {
        var temp = oReturn.split(',');
            oAttach.value = temp;
            //__doPostBack('lBtnReload', '');
        }
        else
        {
            oAttach.value = "";
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
    
    function TranKpi(mType)
    {
        switch (mType)
        {
            case "D":
                return confirm("삭제 하시겠습니까?");
            case "I":
                if (document.getElementById('hdfKpiPoolRefID').value == "0" || document.getElementById('hdfKpiPoolRefID').value == "")
                {
                    alert("KPI POOL을 선택해주세요.");
                    return false;
                }
                return confirm("저장 하시겠습니까?");
            case "U":
                if (document.getElementById('hdfKpiPoolRefID').value == "0" || document.getElementById('hdfKpiPoolRefID').value == "")
                {
                    alert("KPI POOL을 선택해주세요.");
                    return false;
                }
                return confirm("수정 하시겠습니까?");
            case "C":
                return confirm("확정 하시겠습니까?");
            case "R":
                return confirm("확정취소 하시겠습니까?");
            case "S":
                return confirm("사용처리 하시겠습니까?");
            default:
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="width: 100%;">
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
                                    <asp:HiddenField ID="hdnEstTermID" runat="server" />
                                    <asp:HiddenField ID="hdnKpiId" runat="server" />
                                    <asp:HiddenField ID="hdnYMD" runat="server" />
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
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="cssTblTitle">
                                        KPI 코드
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtKpiCode" runat="server" BorderWidth="0" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="cssTblTitle">
                                        KPI 명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtKpiName" runat="server" Width="70%" BorderWidth="0" ReadOnly="True"
                                            BackColor="whitesmoke"></asp:TextBox>
                                        <asp:ImageButton ID="iBtnKpiPoolList" runat="server" ImageUrl="../images/btn/b_034.gif"
                                            OnClientClick="return openKpiPoolList('hdfKpiPoolRefID','txtKpiName');" ImageAlign="AbsMiddle" />
                                        <asp:LinkButton ID="linkBtnSelKpiPool" runat="server" Visible="false" OnClick="linkBtnSelKpiPool_Click"></asp:LinkButton>
                                        <asp:HiddenField ID="hdfTargetReasonFile" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfKpiPoolRefID" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfinitial_version_yn" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfkpi_target_version_id" runat="server" Value="" />
                                        <asp:LinkButton ID="linkBtnRegTarget" runat="server" Visible="false" OnClick="linkBtnRegTarget_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        KPI 유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKpiType" runat="server" Width="100%" BorderWidth="0"></asp:Label>
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
                    <tr class="cssPopTblBottomSpace">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False"
                                Width="100%" SelectedTab="0" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                                <Tabs>
                                    <ig:Tab Text="PARTⅠ KPI_기본정보" Key="1">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <div style="overflow: auto; height: 490px;">
                                                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="cssTblTitle">
                                                            KPI담당자
                                                        </td>
                                                        <td class="cssTblContent">
                                                            <asp:TextBox ID="txtChampionEmpName" runat="server" BorderWidth="0" ReadOnly="true"
                                                                Width="69%"></asp:TextBox>
                                                            <img alt="" id="ibtnChampion" runat="server" src="../images/btn/b_008.gif" style="vertical-align: inherit;
                                                                cursor: hand;" onclick="openDeptEmp('hdfChampionEmpId','txtChampionEmpName');" />
                                                            <asp:HiddenField ID="hdfChampionEmpId" runat="server" />
                                                        </td>
                                                        <td class="cssTblTitle">
                                                            KPI 측정 유형
                                                        </td>
                                                        <td class="cssTblContent">
                                                            <asp:DropDownList ID="ddlResultAchievementType" runat="server" CssClass="box01">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssTblTitle">
                                                            누적실적유형
                                                        </td>
                                                        <td class="cssTblContent">
                                                            <asp:DropDownList ID="ddlResultTsCalcType" runat="server" AutoPostBack="True" onChange="return SetTermToTarget();"
                                                                CssClass="box01">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="cssTblTitle">
                                                            구간산정방법
                                                        </td>
                                                        <td class="cssTblContent">
                                                            <asp:DropDownList ID="ddlMeasurementGradeType" runat="server" CssClass="box01">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssTblTitle">
                                                            <%=this.GetText("LBL_00003", "평가단계")%>
                                                        </td>
                                                        <td class="cssTblContent">
                                                            <asp:DropDownList ID="ddlResultMeasurementStep" runat="server" AutoPostBack="True"
                                                                CssClass="box01" OnSelectedIndexChanged="ddlResultMeasurementStep_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="cssTblTitle">
                                                            단위
                                                        </td>
                                                        <td class="cssTblContent">
                                                            <asp:DropDownList ID="ddlUnit" runat="server" CssClass="box01">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssTblTitle" align="center">
                                                            지표 및 용어정의
                                                        </td>
                                                        <td class="cssTblContent" colspan="3">
                                                            <%--<asp:TextBox ID="txtWordDefinition" runat="server" Width="100%" TextMode="MultiLine" Height="310px" Visible="true"></asp:TextBox>--%>
                                                            <FCKeditorV2:FCKeditor ID="txtWordDefinition" runat="server" BasePath="../_common/FCKeditor/"
                                                                Height="150px" Width="100%" ToolbarSet="Min">
                                                            </FCKeditorV2:FCKeditor>
                                                            <span id="spnWordDefinition" runat="server" style="height: 150px; width: 100%; overflow: auto;">
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 285px;">
                                                        <td class="cssTblTitle" align="center">
                                                            주기 및 목표설정
                                                        </td>
                                                        <td class="cssTblContent" colspan="3" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="overflow: auto; width: 460px; height: 285px;" class="tableBorder">
                                                                                        <table style="height: 320px; width: 440px; border-collapse: collapse;">
                                                                                            <tr>
                                                                                                <td style="width: 140px; padding: 0 0 0 0;">
                                                                                                    <ig:UltraWebGrid ID="ugrdTerm" runat="server" Height="100%" Width="100%" ImageDirectory=""
                                                                                                        OnInitializeRow="ugrdTerm_InitializeRow" OnInitializeLayout="ugrdTerm_InitializeLayout">
                                                                                                        <Bands>
                                                                                                            <ig:UltraGridBand>
                                                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                                                </AddNewRow>
                                                                                                                <Columns>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="평가년월" Key="YMD_DESC" Width="60px"
                                                                                                                        AllowUpdate="No">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" Height="43px" />
                                                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                                                        </CellStyle>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:TemplatedColumn BaseColumnName="CHECK_YN" Key="CHECK_YN" Width="80px">
                                                                                                                        <Header Caption="측정주기">
                                                                                                                        </Header>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <HeaderTemplate>
                                                                                                                            <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor: hand; vertical-align: middle;"
                                                                                                                                onclick="selectChkBox('ugrdTerm')" />
                                                                                                                            <asp:Label ID="lblTerm" runat="server" Text="측정주기"></asp:Label>
                                                                                                                        </HeaderTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                                                        </CellStyle>
                                                                                                                        <CellTemplate>
                                                                                                                            <asp:CheckBox ID="chkCheckTerm" runat="server" onclick="SetTermToTarget()" />
                                                                                                                        </CellTemplate>
                                                                                                                    </ig:TemplatedColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월계획" Key="MS_PLAN" DataType="System.Double"
                                                                                                                        Type="Custom" Width="20px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <CellStyle HorizontalAlign="Right" BackColor="WhiteSmoke">
                                                                                                                        </CellStyle>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누적계획" Key="TS_PLAN" DataType="System.Double"
                                                                                                                        Type="Custom" Width="20px" AllowUpdate="No" Format="###,###,##0.####" Hidden="true">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <CellStyle HorizontalAlign="Right" BackColor="WhiteSmoke">
                                                                                                                        </CellStyle>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="CLOSE_YN" DataType="System.String" HeaderText="마감"
                                                                                                                        Key="CLOSE_YN" Width="10px" Hidden="true">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                                                        </CellStyle>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" Key="KPI_REF_ID"
                                                                                                                        Hidden="true">
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" Key="ESTTERM_REF_ID"
                                                                                                                        Hidden="true">
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" DataType="System.String" Hidden="true">
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                </Columns>
                                                                                                            </ig:UltraGridBand>
                                                                                                        </Bands>
                                                                                                        <DisplayLayout CellPaddingDefault="2" Version="4.00" AutoGenerateColumns="false"
                                                                                                            HeaderClickActionDefault="NotSet" Name="ugrdTerm" BorderCollapseDefault="Separate"
                                                                                                            RowSelectorsDefault="No" ScrollBarView="Both" RowHeightDefault="22px" SelectTypeRowDefault="Single"
                                                                                                            JavaScriptFileName="" JavaScriptFileNameCommon="" FixedHeaderIndicatorDefault="Button"
                                                                                                            TableLayout="Fixed" StationaryMargins="No" OptimizeCSSClassNamesOutput="False"
                                                                                                            TabDirection="TopToBottom" CellClickActionDefault="Edit" ScrollBar="Never">
                                                                                                            <%--<GroupByBox Hidden="True">
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
                                                                                                    <Padding Left="3px" />
                                                                                                </RowStyleDefault>
                                                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False">
                                                                                                    <BorderDetails  ColorLeft="93, 171, 192" ColorTop="93, 171, 192" />
                                                                                                </HeaderStyleDefault>
                                                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                                                                </EditCellStyleDefault>
                                                                                                <FrameStyle BackColor="Window" BorderColor="#E7E7E7" BorderStyle="Solid"
                                                                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="265px"
                                                                                                    Width="100%">
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
                                                                                                <ClientSideEvents AfterCellUpdateHandler="SetTermToTarget" MouseOverHandler="MouseOverHandler" />
                                                                                                <ActivationObject BorderColor="" BorderWidth="">
                                                                                                </ActivationObject>
                                                                                                <FilterOptionsDefault FilterUIType="HeaderIcons">
                                                                                                </FilterOptionsDefault>--%>
                                                                                                            <GroupByBox>
                                                                                                                <BoxStyle CssClass="GridGroupBoxStyle">
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
                                                                                                            <ClientSideEvents AfterCellUpdateHandler="SetTermToTarget" />
                                                                                                        </DisplayLayout>
                                                                                                    </ig:UltraWebGrid>
                                                                                                </td>
                                                                                                <td style="padding: 0 0 0 0;">
                                                                                                    <ig:UltraWebGrid ID="ugrdPlan" runat="server" Height="100%" Width="100%" OnInitializeLayout="ugrdPlan_InitializeLayout"
                                                                                                        OnInitializeRow="ugrdPlan_InitializeRow">
                                                                                                        <Bands>
                                                                                                            <ig:UltraGridBand>
                                                                                                                <Columns>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="목표시기" Key="YMD_DESC" Width="100px"
                                                                                                                        Hidden="true">
                                                                                                                        <Header Caption="목표시기">
                                                                                                                        </Header>
                                                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                                                        </CellStyle>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="당월" Key="MS_TARGET" DataType="System.Double"
                                                                                                                        Type="Custom" Width="55px" Format="###,###.####">
                                                                                                                        <Header Caption="당월">
                                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                                        </Header>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <Footer>
                                                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                                                        </Footer>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="" HeaderText="누계" Key="TS_TARGET" DataType="System.Double"
                                                                                                                        Type="Custom" Width="55px" Format="###,###.####">
                                                                                                                        <Header Caption="누계">
                                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                                        </Header>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <Footer>
                                                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                                                        </Footer>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="MS_PLAN" HeaderText="당월" Key="MS_PLAN" DataType="System.Double"
                                                                                                                        Type="Custom" Width="55px" Format="###,###.####">
                                                                                                                        <Header Caption="당월">
                                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                                        </Header>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                                        <Footer>
                                                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                                                        </Footer>
                                                                                                                    </ig:UltraGridColumn>
                                                                                                                    <ig:UltraGridColumn BaseColumnName="TS_PLAN" HeaderText="누계" Key="TS_PLAN" DataType="System.Double"
                                                                                                                        Type="Custom" Width="55px" Format="###,###.####">
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
                                                                                                                        Width="35px">
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
                                                                                                                        Width="35px">
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
                                                                                                            StationaryMargins="Header" OptimizeCSSClassNamesOutput="False" TableLayout="Fixed"
                                                                                                            ScrollBar="Never">
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
                                                                                                    <ig:UltraWebGrid ID="ugrdBPlan" runat="server" Height="100%" Width="99%" Visible="false">
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
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="cssPopBtnLine">
                                                                                <td>
                                                                                    <asp:ImageButton ID="iBtnSave" runat="server" OnClick="ibtnSave_Click" Height="19px"
                                                                                        ImageUrl="~/images/btn/b_tp07.gif" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 250px; text-align: right;">
                                                                        <asp:Chart ID="chartScore" runat="server" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                                                                            Palette="None" Height="283" Width="250px">
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssTblTitle">
                                                            등급구간설정
                                                        </td>
                                                        <td class="cssTblContent" colspan="3">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="width: 50%; height: 100%;">
                                                                        <ig:UltraWebGrid ID="ugrdSignal" runat="server" Height="170px" Width="100%" OnInitializeLayout="ugrdSignal_InitializeLayout"
                                                                            OnInitializeRow="ugrdSignal_InitializeRow">
                                                                            <Bands>
                                                                                <ig:UltraGridBand>
                                                                                    <Columns>
                                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL" HeaderText="상태" Key="SIGNAL" Width="15%">
                                                                                            <Header Caption="상태">
                                                                                            </Header>
                                                                                            <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                            <CellStyle HorizontalAlign="Center">
                                                                                            </CellStyle>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="IMAG_PATH" HeaderText="표시" Key="IMAG_PATH" DataType="System.Double"
                                                                                            Type="Custom" Width="12%">
                                                                                            <Header Caption="표시">
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="THRS_DESC" HeaderText="구간" Key="THRS_DESC" DataType="System.Double"
                                                                                            Type="Custom" Width="20%">
                                                                                            <Header Caption="구간">
                                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="SET_MIN_VALUE" HeaderText="계량" Key="SET_MIN_VALUE"
                                                                                            DataType="System.Double" Type="Custom" Width="12%">
                                                                                            <Header Caption="계량">
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="SET_TXT_VALUE" HeaderText="비계량" Key="SET_TXT_VALUE"
                                                                                            DataType="System.String" Type="Custom" Width="18%">
                                                                                            <Header Caption="비계량">
                                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" HeaderText="달성율" Key="ACHIEVE_RATE"
                                                                                            DataType="System.Double" Type="Custom" Width="12%">
                                                                                            <Header Caption="달성율">
                                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="POINT" HeaderText="점수" Key="POINT" DataType="System.Double"
                                                                                            Type="Custom" Width="10%">
                                                                                            <Header Caption="점수">
                                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="SET_MAX_VALUE" HeaderText="계획" Key="SET_MAX_VALUE"
                                                                                            DataType="System.Double" Type="Custom" Hidden="true">
                                                                                            <Header Caption="계획">
                                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                                            </Header>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                            Key="ESTTERM_REF_ID">
                                                                                            <Header Caption="ESTTERM_REF_ID">
                                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID"
                                                                                            Hidden="True" Key="KPI_REF_ID">
                                                                                            <Header Caption="KPI_REF_ID">
                                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_REF_ID" DataType="System.Int32" HeaderText="THRESHOLD_REF_ID"
                                                                                            Hidden="True" Key="THRESHOLD_REF_ID">
                                                                                            <Header Caption="THRESHOLD_REF_ID">
                                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="THRESHOLD_LEVEL" DataType="System.String" HeaderText="THRESHOLD_LEVEL"
                                                                                            Hidden="True" Key="THRESHOLD_LEVEL">
                                                                                            <Header Caption="THRESHOLD_LEVEL">
                                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="BASE_LINE_YN" DataType="System.String" HeaderText="BASE_LINE_YN"
                                                                                            Hidden="True" Key="BASE_LINE_YN">
                                                                                            <Header Caption="BASE_LINE_YN">
                                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                        <ig:UltraGridColumn BaseColumnName="T_CODE" DataType="System.Int32" HeaderText="T_CODE"
                                                                                            Hidden="True" Key="T_CODE">
                                                                                            <Header Caption="T_CODE">
                                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                                            </Header>
                                                                                            <Footer>
                                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                                            </Footer>
                                                                                        </ig:UltraGridColumn>
                                                                                    </Columns>
                                                                                </ig:UltraGridBand>
                                                                            </Bands>
                                                                            <DisplayLayout Version="4.00" AllowColSizingDefault="Free" AllowUpdateDefault="Yes"
                                                                                AutoGenerateColumns="False" HeaderClickActionDefault="NotSet" Name="ugrdSignal"
                                                                                BorderCollapseDefault="Separate" RowSelectorsDefault="No" ScrollBarView="Vertical"
                                                                                RowHeightDefault="20px" JavaScriptFileName="" JavaScriptFileNameCommon="" CellClickActionDefault="Edit"
                                                                                OptimizeCSSClassNamesOutput="False" TabDirection="TopToBottom" TableLayout="Fixed">
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
                                                                                BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="170px" Width="100%">
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
                                                                            <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                                                                            <ClientSideEvents AfterCellUpdateHandler="calcAchvRate" MouseOverHandler="MouseOverHandler" />
                                                                            <ImageUrls BlankImage="" CollapseImage="" CurrentEditRowImage="" CurrentRowImage=""
                                                                                ExpandImage="" FixedHeaderOffImage="" FixedHeaderOnImage="" GridCornerImage=""
                                                                                GroupByImage="" GroupDownArrow="" GroupUpArrow="" ImageDirectory="" NewRowImage=""
                                                                                RowLabelBlankImage="" SortAscending="" SortDescending="" UnGroupByImage="" />--%>
                                                                                <GroupByBox>
                                                                                    <BoxStyle CssClass="GridGroupBoxStyle">
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
                                                                                <ClientSideEvents AfterCellUpdateHandler="calcAchvRate" />
                                                                            </DisplayLayout>
                                                                        </ig:UltraWebGrid>
                                                                    </td>
                                                                    <td>
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                                                                                        <tr>
                                                                                            <td style="width: 1%;">
                                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="측정산식" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 45px; vertical-align: top;">
                                                                                    <asp:TextBox ID="txtCalcFormMs" runat="server" Width="100%" TextMode="MultiLine"
                                                                                        Height="45px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                                                                                        <tr>
                                                                                            <td style="width: 1%;">
                                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="목표 및 등급구간 설정근거" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 50px; vertical-align: top;">
                                                                                    <asp:TextBox ID="txtTargetReason" runat="server" TextMode="MultiLine" Height="100%"
                                                                                        Width="100%"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 20px; vertical-align: top;">
                                                                                    <table cellpadding="0" cellspacing="1" border="0" style="height: 98%; width: 100%;">
                                                                                        <tr>
                                                                                            <td style="width: 1%;">
                                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="첨부파일" />
                                                                                            </td>
                                                                                            <td style="width: 70%;">
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
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:FileUpload ID="fileDefinition" runat="server" Width="300px" Visible="false" /><asp:HyperLink
                                                    ID="linkDefinition" runat="server" Visible="false"></asp:HyperLink>
                                            </div>
                                        </ContentTemplate>
                                    </ig:Tab>
                                    <ig:TabSeparator>
                                        <Style Width="1px">
                                            </Style>
                                    </ig:TabSeparator>
                                    <ig:Tab Text="PARTⅡ KPI_Initiative 관리" Key="2">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <div style="overflow: auto; height: 490px;">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 550px;" valign="top">
                                                            <ig:UltraWebGrid ID="ugrdInitiative" runat="server" Width="100%" Height="98%" OnInitializeRow="ugrdInitiative_InitializeRow">
                                                                <Bands>
                                                                    <ig:UltraGridBand>
                                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                                        </AddNewRow>
                                                                        <Columns>
                                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true">
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" Key="KPI_REF_ID" Hidden="true">
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="YMD" Key="YMD" Hidden="true">
                                                                            </ig:UltraGridColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="YMD_DESC" FooterText="" HeaderText="년월" Key="YMD_DESC"
                                                                                Width="10%" AllowUpdate="No">
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
                                                                                Key="INITIATIVE_PLAN" Width="90%" CellMultiline="Yes">
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
                                                                            <ig:TemplatedColumn BaseColumnName="INITIATIVE_DO" Key="INITIATIVE_DO" Hidden="true">
                                                                                <CellTemplate>
                                                                                    <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" ID="txtINITIATIVE_DO"
                                                                                        runat="server"></asp:TextBox>
                                                                                </CellTemplate>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:TemplatedColumn BaseColumnName="INITIATIVE_DESC" Key="INITIATIVE_DESC" Hidden="true">
                                                                                <CellTemplate>
                                                                                    <asp:TextBox TextMode="MultiLine" Width="100%" Height="100%" ID="txtINITIATIVE_DESC"
                                                                                        runat="server"></asp:TextBox>
                                                                                </CellTemplate>
                                                                            </ig:TemplatedColumn>
                                                                            <ig:UltraGridColumn BaseColumnName="CHECK_YN" Key="CHECK_YN" Hidden="true">
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
                                                                    StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ReadOnly="LevelTwo"
                                                                    OptimizeCSSClassNamesOutput="False" AllowUpdateDefault="Yes">
                                                                    <%--<GroupByBox Hidden="True">
                                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                </GroupByBox>
                                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                                </GroupByRowStyleDefault>
                                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                                </FooterStyleDefault>
                                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                                    <Padding Left="0px" Bottom="0px" Top="0px" Right="0px" />
                                                                </RowStyleDefault>
                                                                <SelectedRowStyleDefault BackColor="#E2ECF4"></SelectedRowStyleDefault>
                                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                                    ForeColor="White" HorizontalAlign="Left" Height="23px">
                                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                                </HeaderStyleDefault>
                                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px" Wrap="True"></EditCellStyleDefault>
                                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="3px"
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
                                                                <ActivationObject BorderColor="" BorderWidth=""></ActivationObject>--%>
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
                                            </div>
                                        </ContentTemplate>
                                    </ig:Tab>
                                </Tabs>
                                <DefaultTabStyle BackColor="White" Height="20px" CssClass="cssTabStyleOff">
                                </DefaultTabStyle>
                                <SelectedTabStyle CssClass="cssTabStyleOn" />
                                <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif"
                                    SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                            </ig:UltraWebTab>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        <asp:ImageButton ID="iBtnAddTarget" ImageUrl="../images/btn/b_090.gif" runat="server"
                                            OnClientClick="return OpenTargetForm()" Visible="false" />
                                        <asp:ImageButton ID="iBtnGoalTong" ImageUrl="../images/btn/btn_goalinput.gif" runat="server"
                                            OnClientClick="return doPoppingUpGoalTong()" Visible="false" />
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server"
                                            OnClientClick="return TranKpi('I');" OnClick="iBtnInsert_Click" />
                                        <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server"
                                            OnClientClick="return TranKpi('U');" OnClick="iBtnUpdate_Click" />
                                        <asp:ImageButton ID="iBtnConfirm" ImageUrl="../images/btn/b_015.gif" runat="server"
                                            OnClientClick="return TranKpi('C');" OnClick="iBtnConfirm_Click" />
                                        <asp:ImageButton ID="iBtnConfirmCancel" ImageUrl="../images/btn/b_178.gif" runat="server"
                                            OnClientClick="return TranKpi('R');" OnClick="iBtnConfirmCancel_Click" />
                                        <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_004.gif" runat="server"
                                            OnClick="iBtnDelete_Click" OnClientClick="return TranKpi('D');" />
                                        <asp:ImageButton ID="iBtnUsed" ImageUrl="../images/btn/b_138.gif" runat="server"
                                            OnClientClick="return TranKpi('S');" OnClick="iBtnUsed_Click" />
                                        <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="../images/btn/b_080.gif"
                                            Visible="false" OnClick="ImgBtnPrint_Click" />
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
            </td>
        </tr>
    </table>
    <ig:UltraWebGridExcelExporter ID="ugrdEEP" runat="server" OnBeginExport="ugrdEEP_BeginExport"
        OnCellExporting="ugrdEEP_CellExporting" />
    <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
    </form>
</body>
</html>
