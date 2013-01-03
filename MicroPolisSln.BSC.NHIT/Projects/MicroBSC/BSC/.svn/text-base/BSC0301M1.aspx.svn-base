<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0301M1.aspx.cs" Inherits="BSC_BSC0301M1" ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>성과관리 시스템::KPI 수정</title>
<meta http-equiv="Content-Type" content="text/html;" />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script type="text/javascript">
    function Valid() {
        
        var f = document.forms[0];
         
        if (f.txtKpiCode.value == '') {
            alert('KPI Code를 입력하세요.');
            f.txtKpiCode.focus();
            return false;
        }
        if (f.txtKpiName.value == '') {
            alert('KPI 명을 입력하세요.');
            f.txtKpiName.focus();
            return false;
        }
        if (f.hdfChampion_Emp_Id.value == '') {
            alert('<%=this.GetText("LBL_00001", "챔피언") %>를 선택하세요..');
            return false;
        }
        if (f.hdfEst_Dept_Id.value == '') {
            alert('평가부서를 선택하세요.');
            return false;
        }

        return true;
    }

    function totalSumValidate() {
        var ugrd = igtbl_getGridById('<%= ugrdQuestionItem.ClientID %>');
        var sumWeight = 0;

        if (ugrd.Rows.length > 0) {
            for (var i = 0; i < ugrd.Rows.length; i++) {
                var tRow = ugrd.Rows.getRow(i);
                var weight = tRow.getCellFromKey("WEIGHT").getValue() * 1;

                if (weight == null)
                    weight = 0;

                sumWeight += weight;
            }
        }

        if (sumWeight > 100) {
            alert('합계는 100이하여야 합니다.'); return false;
        }
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
    function calcAchvRate(tableName, itemName) {
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

        cntCur = objRow.getIndex() + 1;
        cntRow = objTbl.Rows.length;

        if (cntCur < 1) {
            return;
        }

        var tab = igtab_getTabById("ugrdKpiStatusTab");

        //var objColType = tab.findControl("ddlResultAchievementType");
        //var strColType = objColType.value;
        var strColType = "ATY";
        var sBaseLineYn = "";

        for (var i = 0; i < cntRow; i++) {
            var objTmpRow = objTbl.Rows.getRow(i);
            var sBaseLineYn = objTmpRow.getCellFromKey("BASE_LINE_YN").getValue();

            if (sBaseLineYn == "Y") {
                dblini = parseFloat(objTmpRow.getCell(3).getValue());
                break;
            }
        }

        for (var i = 0; i < cntRow; i++) {
            var objTmpRow = objTbl.Rows.getRow(i);
            if (!isNaN(parseFloat(objTmpRow.getCell(3).getValue()))) {
                if (parseFloat(objTmpRow.getCell(3).getValue()) >= 0) {
                    isMinus = false;
                    break;
                }
            }
            else {
                isMinus = false;
                break;
            }
        }

        if (((strColType == 'ATY' || strColType == 'BTY') && isMinus))      //부경양돈농협때문에 전체가 마이너스일때는 달성율 분자분모 반대
        {
            for (var i = 0; i < cntRow; i++) {
                var objTmpRow = objTbl.Rows.getRow(i);

                dblCur = parseFloat(objTmpRow.getCell(3).getValue());
                dblRate = (dblCur == 0) ? 0 : (dblini / dblCur) * 100;
                objTbl.Rows.getRow(i).getCell(4).setValue(dblRate);
            }
        }
        else {
            for (var i = 0; i < cntRow; i++) {
                var objTmpRow = objTbl.Rows.getRow(i);

                if (isNaN(parseFloat(objTmpRow.getCell(3).getValue()))) {
                    objTbl.Rows.getRow(i).getCell(4).setValue(0);
                }
                else {
                    if (strColType == 'ATY' || strColType == 'BTY')      //A Type
                    {
                        dblCur = parseFloat(objTmpRow.getCell(3).getValue());
                        dblRate = (dblini == 0) ? 0 : (dblCur / dblini) * 100;
                        objTbl.Rows.getRow(i).getCell(4).setValue(dblRate);
                    }
                    else {
                        objTbl.Rows.getRow(i).getCell(4).setValue("");
                    }
                }
            }
        }

    }
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF; overflow:scroll" onload="document.focus();">

<form id="form1" runat="server">
    <div>
        <table valign="top" width="100%" style="height:100%" border="0" cellspacing="0" cellpadding="0">
            <tr> 
                <td valign="top" style="background-image:url(../images/title/popup_t_bg.gif); height:40px;"> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                            <td  style="height:40px;" valign="top"><img alt="" src="../images/title/popup_t4.gif" /></td>
                            <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif" /></td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="cssPopContent">
                <td  valign="top" >
                    <div style="height:570px; overflow:auto;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                        <tr>
                            <td>
                                <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                                    <tr>
                                        <td class="cssTblTitle" style="width:10%;">전략명</td>
                                        <td class="cssTblContent" style="width:90%;">
                                            <asp:DropDownList ID="ddlTargetName" runat="server" Width="40%" CssClass="box01" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle" >KPI명</td>
                                        <td class="cssTblContent">
                                            <asp:TextBox ID="txtKpiName" runat="server" Width="100%" MaxLength="40"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle" >지표구분</td>
                                        <td class="cssTblContent">
                                            <asp:DropDownList ID="ddlExternalType" runat="server" Width="100%" CssClass="box01" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle" >지표유형</td>
                                        <td class="cssTblContent">
                                            <asp:DropDownList ID="ddlKpiType" Width="100%" runat="server" CssClass="box01" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle" >직무분류</td>
                                        <td class="cssTblContent">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlKpiCategoryTop" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryTop_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                                    /><asp:DropDownList ID="ddlKpiCategoryMid" Width="33%" runat="server" OnSelectedIndexChanged="ddlKpiCategoryMid_SelectedIndexChanged" AutoPostBack="True" CssClass="box01" 
                                                    /><asp:DropDownList ID="ddlKpiCategoryLow" Width="33%" runat="server" CssClass="box01" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle" >평가방식</td>
                                        <td class="cssTblContent">
                                            <asp:DropDownList ID="ddlBASIS_USE_YN" Width="100%" runat="server" CssClass="box01" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="cssTblTitle" >사용여부</td>
                                        <td class="cssTblContent">
                                            <asp:CheckBox ID="chkUseYn" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="cssTblTitle" >KPI 설명</td>
                                        <td class="cssTblContent">
                                            <asp:TextBox ID="txtKPIDesc" runat="server" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height:100%;">
                                        <td class="cssTblTitle" >정성지표 평가기준</td>
                                        <td class="cssTblContent">
                                            <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                                                <tr>
                                                    <td>
                                                        <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False" Width="100%" SelectedTab="0" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                                                            <Tabs>
                                                                <ig:Tab Text="PART1. KPI정의서 기본 속성" Key="0">
                                                                <Style Width="200px" Height="25px" />
                                                                <ContentTemplate>
                                                                    <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                                                                    <tr>
                                                                        <td class="cssTblTitle" style="width:10%;">KPI유형</td>
                                                                        <td class="cssTblContent" style="width:23%;">
                                                                            <asp:DropDownList ID="tab_ddl_kpiType" runat="server" Width="100%" CssClass="box01" />
                                                                        </td>
                                                                        <td class="cssTblTitle" style="width:10%;">누적실적유형</td>
                                                                        <td class="cssTblContent" style="width:23%;">
                                                                            <asp:DropDownList ID="tab_ddl_scoreType" runat="server" Width="100%" CssClass="box01" />
                                                                        </td>
                                                                        <td class="cssTblTitle" style="width:10%;">구간산정방법</td>
                                                                        <td class="cssTblContent" style="width:23%;">
                                                                            <asp:DropDownList ID="tab_ddl_caMethod" runat="server" Width="100%" CssClass="box01" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cssTblTitle" style="width:10%;">단위</td>
                                                                        <td class="cssTblContent" style="width:23%;">
                                                                            <asp:DropDownList ID="tab_ddl_type" runat="server" Width="100%" CssClass="box01" />
                                                                        </td>
                                                                        <td class="cssTblTitle" style="width:10%;">등급단계</td>
                                                                        <td class="cssTblContent" style="width:23%;">
                                                                            <asp:DropDownList ID="tab_ddl_grade" runat="server" Width="100%" CssClass="box01" AutoPostBack="true" OnSelectedIndexChanged="tab_ddl_grade_SelectedIndexChanged" />
                                                                        </td>
                                                                        <td class="cssTblTitle" style="width:10%;">측정주기</td>
                                                                        <td class="cssTblContent" style="width:23%;">
                                                                            <asp:DropDownList ID="tab_ddl_reiod" runat="server" Width="100%" CssClass="box01" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cssTblTitle">지표 및 용어정의</td>
                                                                        <td class="cssTblContent" colspan="5">
                                                                            <asp:TextBox ID="tab_txt_word" runat="server" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cssTblTitle">당월산식</td>
                                                                        <td class="cssTblContent" colspan="2">
                                                                            <asp:TextBox ID="tab_txt_MonthCa" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td class="cssTblTitle">누적산식</td>
                                                                        <td class="cssTblContent" colspan="2">
                                                                            <asp:TextBox ID="tab_txt_fillCa" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                     
                                                                    <tr>
                                                                        <td class="cssTblTitle">측정월</td>
                                                                        <td class="cssTblContent" colspan="5">
                                                                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" style="width:100%;height:100%;">
                                                                            <tr>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">1월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">2월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">3월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">4월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">5월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">6월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">7월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">8월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">9월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">10월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">11월</td>
                                                                                <td class="cssTblTitle1" style="width:8%; text-align:center;">12월</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_1" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_2" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_3" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_4" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_5" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_6" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_7" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_8" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_9" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_10" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_11" /></td>
                                                                                <td class="cssTblContent1" style="width:8%; text-align:center;"><asp:CheckBox runat="server" ID="tab_ck_12" /></td>
                                                                            </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cssTblTitle">
                                                                            등급구간
                                                                        </td>
                                                                        <td class="cssTblContent"  colspan="5" style="height:140px;">
                                                                            <ig:UltraWebGrid id="ugrdSignal" runat="server" height="100%" width="99%" OnInitializeLayout="ugrdSignal_InitializeLayout" OnInitializeRow="ugrdSignal_InitializeRow" >
                                                                        <Bands>
                                                                            <ig:UltraGridBand>
                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                </AddNewRow>
                                                                                <Columns>
                                                                                    <ig:UltraGridColumn BaseColumnName="SIGNAL" HeaderText="상태" Key="SIGNAL" Width="50px">
                                                                                        <Header Caption="상태"></Header>
                                                                                        <HeaderStyle Wrap="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="IMAG_PATH" HeaderText="신호" Key="IMAG_PATH" DataType="System.Double" Type="Custom" Width="80px">
                                                                                        <Header Caption="신호">
                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="THRS_DESC" HeaderText="구간" Key="THRS_DESC" DataType="System.Double" Type="Custom" Width="80px" >
                                                                                        <Header Caption="구간">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="SET_MIN_VALUE" HeaderText="계획" Key="SET_MIN_VALUE" DataType="System.Double" Type="Custom" Width="80px" Format="#,###,###,###,####.0000">
                                                                                        <Header Caption="계획">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="ACHIEVE_RATE" HeaderText="달성율" Key="ACHIEVE_RATE" DataType="System.Double" Type="Custom" Width="80px">
                                                                                        <Header Caption="달성율">
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="POINT" HeaderText="점수" Key="POINT" DataType="System.Double" Type="Custom" Width="70px">
                                                                                        <Header Caption="점수">
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="SET_MAX_VALUE" HeaderText="계획" Key="SET_MAX_VALUE" DataType="System.Double" Type="Custom" Width="80px" Hidden="true">
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
                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" HeaderText="KPI_REF_ID" Hidden="True"  Key="KPI_REF_ID">
                                                                                        <Header Caption="KPI_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="THRESHOLD_REF_ID" DataType="System.Int32" HeaderText="THRESHOLD_REF_ID" Hidden="True"  Key="THRESHOLD_REF_ID">
                                                                                        <Header Caption="THRESHOLD_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="THRESHOLD_LEVEL" DataType="System.String" HeaderText="THRESHOLD_LEVEL" Hidden="True"  Key="THRESHOLD_LEVEL">
                                                                                        <Header Caption="THRESHOLD_LEVEL">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="BASE_LINE_YN" DataType="System.String" HeaderText="BASE_LINE_YN" Hidden="True"  Key="BASE_LINE_YN">
                                                                                        <Header Caption="BASE_LINE_YN">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="T_CODE" DataType="System.Int32" HeaderText="T_CODE" Hidden="True"  Key="T_CODE">
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
                                                                        <DisplayLayout CellPaddingDefault="2" 
                                                                                       Version="4.00"
                                                                                       AllowColSizingDefault="Free" 
                                                                                       AllowUpdateDefault="Yes" 
                                                                                       AutoGenerateColumns="False" 
                                                                                       HeaderClickActionDefault="NotSet" 
                                                                                       Name="ugrdSignal" 
                                                                                       BorderCollapseDefault="Separate" 
                                                                                       RowSelectorsDefault="No" 
                                                                                       ScrollBarView="Vertical" 
                                                                                       RowHeightDefault="20px" 
                                                                                       JavaScriptFileName="" 
                                                                                       JavaScriptFileNameCommon="" 
                                                                                       OptimizeCSSClassNamesOutput="False"
                                                                                       TabDirection="TopToBottom"
                                                                                       CellClickActionDefault="Edit">
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
                                                                             <GroupByRowStyleDefault CssClass="GridGroupBoxStyle"></GroupByRowStyleDefault>
                                                                            <RowStyleDefault  CssClass="GridRowStyle" />
                                                                            <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                            <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                            <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                            <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                                                            <ClientSideEvents AfterCellUpdateHandler="calcAchvRate"  />
                                                                        </DisplayLayout>
                                                                    </ig:UltraWebGrid>
                                                                        
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        
                                                                    </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                                </ig:Tab>
                                                                <ig:Tab Text="PAR2. 평가기준정의" Key="1">
                                                                    <Style Width="200px" Height="25px" />
                                                                    <ContentTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                                                                            <tr>
                                                                                <td>
                                                                                    <FCKeditorV2:FCKeditor ID="txtValuationBasis" runat="server" BasePath="../_common/FCKeditor/" Height="100%" Width="100%" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </ig:Tab>
                                                                <ig:Tab Text="PAR3. 평가항목정의" Key="2">
                                                                    <Style Width="200px" Height="25px" />
                                                                    <ContentTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:100%;">
                                                                            <tr>
                                                                              <td>
                                                                                <ig:ultrawebgrid id="ugrdQuestionItem" runat="server" height="100%"  OnInitializeRow="ugrdQuestionItem_InitializeRow">
                                                                                    <Bands>
                                                                                        <ig:UltraGridBand>
                                                                                            <AddNewRow View="NotSet" Visible="NotSet"></AddNewRow>
                                                                                            <Columns>
                                                                                                <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="입력구분" Key="ITYPE" DataType="System.String" Hidden="true" Width="40px">
                                                                                                    <Header Caption="입력구분"></Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:TemplatedColumn Key="selchk" Width="25px">
                                                                                                    <HeaderTemplate>
                                                                                                        <img src="../images/checkbox.gif" alt="전제선택/해제" style="cursor:hand; vertical-align:middle;" onclick="selectChkBox('ugrdQuestionItem')" />
                                                                                                    </HeaderTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                                                                    <CellTemplate>
                                                                                                        <asp:checkbox id="cBox" runat="server" />
                                                                                                    </CellTemplate>
                                                                                                </ig:TemplatedColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="KPI_POOL_REF_ID" HeaderText="KPI_POOL_REF_ID" Hidden="True" Key="KPI_POOL_REF_ID">
                                                                                                    <Header Caption="KPI_POOL_REF_ID">
                                                                                                        <RowLayoutColumnInfo OriginX="2" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="2" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="QUESTION_REF_ID" HeaderText="QUESTION_REF_ID" Hidden="true"
                                                                                                Key="QUESTION_REF_ID" Width="40px">
                                                                                                    <Header Caption="평가항목ID">
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Header>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="QUESTION_ORDER" HeaderText="QUESTION_ORDER" DataType="System.Int32" Hidden="false"
                                                                                                    Key="QUESTION_ORDER" Width="60px">
                                                                                                    <Header Caption="항목순서">
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="ITEM_NAME" HeaderText="ITEM_NAME" Hidden="false"
                                                                                                    Key="ITEM_NAME" Width="300px">
                                                                                                    <Header Caption="평가항목명">
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="3" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="WEIGHT" Key="WEIGHT" DataType="System.Double" NullText="0" Width="80px">
                                                                                                    <Header Caption="가중치">
                                                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                                                    </Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                                                                                    <Footer>
                                                                                                        <RowLayoutColumnInfo OriginX="4" />
                                                                                                    </Footer>
                                                                                                </ig:UltraGridColumn>
                                                                                                <ig:TemplatedColumn Key="USE_YN" BaseColumnName="USE_YN" Width="60px">
                                                                                                    <Header Caption="사용유무"></Header>
                                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                                                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                                                                                    <CellTemplate>
                                                                                                        <asp:checkbox id="chkUseYn" runat="server" />
                                                                                                    </CellTemplate>
                                                                                                </ig:TemplatedColumn>
                                                                                            </Columns>
                                                                                        </ig:UltraGridBand>
                                                                                    </Bands>
                                                                                    <DisplayLayout Version="4.00" AllowUpdateDefault="Yes" 
                                                                                                    HeaderClickActionDefault="NotSet" Name="ugrdQuestionItem" BorderCollapseDefault="Separate" RowSelectorsDefault="No" 
                                                                                                    RowHeightDefault="20px" SelectTypeRowDefault="Single" TableLayout="Fixed" AutoGenerateColumns="False" 
                                                                                                    AllowRowNumberingDefault="Continuous" StationaryMargins="HeaderAndFooter"
                                                                                                    OptimizeCSSClassNamesOutput="False">
                                                                                        
                                                                                      
                                                                                        
                                                                                        <GroupByBox>
                                                                                            <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                                                        </GroupByBox>
                                                                                        <RowStyleDefault  CssClass="GridRowStyle" />
                                                                                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                                                                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                                                                        <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                                                                        <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                                                                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"></FrameStyle>
                                                                                        <ClientSideEvents AfterRowInsertHandler="ugrdDetail_AfterRowInsertHandler" />
                                                                                    </DisplayLayout>
                                                                                </ig:ultrawebgrid>
                                                                              </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height:20px;">
                                                                                    <asp:ImageButton ID="ImgBtnAddRow" ImageUrl="../images/btn/b_005.gif" runat="server" OnClick="ImgBtnAddRow_Click" />
                                                                                    <asp:ImageButton ID="ImgBtnDelRow" ImageUrl="../images/btn/b_004.gif" runat="server" OnClick="ImgBtnDelRow_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </ig:Tab>
                                                            </Tabs>
                                                            <DefaultTabStyle BackColor="White" Height="20px" CssClass="cssTabStyleOff" />
                                                            <SelectedTabStyle CssClass="cssTabStyleOn" />
                                                            <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                                                        </ig:UltraWebTab>
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
                    <div style="height:30px; overflow:auto;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
                        <tr>
	                        <td class="cssPopBtnLine">
	                            <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server" OnClick="iBtnInsert_Click" OnClientClick="return totalSumValidate();" />
	                            <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server" OnClick="iBtnUpdate_Click" OnClientClick="return totalSumValidate();" />
	                            <asp:ImageButton ID="iBtnDelete" ImageUrl="../images/btn/b_208.gif" runat="server" OnClick="iBtnDelete_Click" />
                                <asp:ImageButton ID="iBtnReUsed" ImageUrl="../images/btn/b_138.gif" runat="server" OnClick="iBtnReUsed_Click" />
	                            <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server" OnClick="iBtnClose_Click" />
                                <asp:HiddenField ID="oldKPICode" runat="server" />		        
	                        </td>
                        </tr>
                    </table>
</div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                            <td style="width:50%; background-color:#FFFFFF"></td>
                        </tr>
                    </table>
                    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hdfImagePath" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>
