<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501M3.aspx.cs"
    Inherits="BSC_BSC0501M3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.3)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.3)" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript" language="javascript">  
<!--    
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
          
    function openBatchSave()
    {        
        var kpiID      = "<%= this.IKpiRefID %>";
        var strMM      = "<%= this.IYMD %>";
        var intEST     = "<%= this.IEstTermRefID %>";
        
        var url = 'BSC0501M2.aspx?KPI_REF_ID=' + kpiID+'&YMD='+strMM+'&ESTTERM_REF_ID='+intEST;
        
        gfOpenWindow(url
                    ,870
                    ,500
                    ,'no'
                    ,'no'
                    ,'Win6');
        return false;
    }
        
    function mfUpload(hAttachNo)
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
        var oaArg   = new Array("FILE", "PCAUSE", (oAttach==null ? "" : oAttach.value));
        var isConfirm      = "<%= this.IConfirmStatus %>";   // 확정여부
        var isCloseDay     = "<%= this.IisPassCloseDay %>";  // 예비마감일 경과여부
        var isMonthlyClose = "<%= this.IMontylyClose_YN %>"; // 월마감여부
        var isYearlyClose  = "<%= this.IYearlyClose_YN %>";  // 년마감여부
        var isAdmin        = "<%= this.IisAdmin %>"
        
        var confirmFlag = 'T';
        if (isConfirm=='Y' || isCloseDay=='Y' || isMonthlyClose=='Y' || isYearlyClose=='Y')
        {
            confirmFlag = 'F';
        }
        
        if (isAdmin == 'Y')
        {
            confirmFlag = 'T';
        }
        
        // 외부지표의 파일사이즈 크기 조정
        var url = "";
        if (hAttachNo == "hdfInitiativeDocNo" && "<%=this.IKpiExternalType %>" == "EXT")
        {
            url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG="+confirmFlag+"&SIZE=L";
        }
        else
        {
            url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG="+confirmFlag;
        }
        
        var oReturn = gfOpenDialog(url, oaArg, 485, 307);
        
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
        
    function mfDownload(hAttachNo)
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
        var oaArg   = new Array("FILE", "PCAUSE", (oAttach==null ? "" : oAttach.value));

        url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG=F";
        
        var oReturn = gfOpenDialog(url, oaArg, 485, 307);
        
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
    
    function isMoDraftMsg()
    {
        if(confirm("수정상신이 진행되는 동안은 해당지표 및 상위지표 점수산출이 진행되지 않습니다. 수정상신을 진행하시겠습니까?"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    function doCompute()
    {
        if("<%=this.IResultTsCalcType %>" == "SUM" || "<%=this.IResultTsCalcType %>" == "AVG")
        {
            var returnVal = 0;
            var ugrd = igtbl_getGridById('<%= ugrdResult.ClientID %>');
            var tot = 0;
            var cnt = 0;
            
            for (var i = 0; i < ugrd.Rows.length; i++) {
            
                var tRow = ugrd.Rows.getRow(i);
                var cellValue = tRow.getCellFromKey("RESULT_MS").getValue();
                
                if("<%=this.IResultTsCalcType %>" == "AVG")
                {
                    cnt = i + 1;
                }
                
                var ymd = tRow.getCellFromKey("YMD_DESC").getValue().replace('/','');
                if('<%=this.IYMD %>' == ymd)
                {
                    //alert('a');
                    break;
                }
                else
                {
                    //alert('<%=this.IYMD %>' );
                    //alert(ymd );
                }
                
                tot += cellValue;
            }
            
            tot += new Number(document.getElementById('igtxtugrdKpiResultTab__ctl0_txtMSResult').value);
            
            //alert(tot);
            
            returnVal = tot;
            
            if("<%=this.IResultTsCalcType %>" == "AVG")
            {
                returnVal = tot/cnt;
            }
            
            //alert("<% =this.txtTSResult.ClientID %>");
            
            document.getElementById('<%=this.hdfTSResult.ClientID %>').value = returnVal;
            document.getElementById('igtxtugrdKpiResultTab__ctl0_txtTSResult').value = returnVal;
            document.getElementById('ugrdKpiResultTab__ctl0_txtTSResult').value = returnVal;
            
            //alert(returnVal);
        }
        else
        {
        
        }
    }
    
    function getTsSumMsg()
    {
        
        
        //변경된 값을 누적실적에 적용시키기 위한 포커스 이동    
        var objTxtTsResult = document.getElementById("igtxtugrdKpiResultTab__ctl0_txtTSResult");
        objTxtTsResult.focus();
        
        //마우스 오버 이벤트 발생시키는 법 없나...
        var whilecnt = 0;
        while(document.activeElement!=objTxtTsResult)
        { 
            whilecnt++;
            if(whilecnt==5000)
                return false;
        }
            
        if('<%=this.IYearlyClose_YN %>' == 'Y')
        {
            alert('해당 평가기간은 이미 마감되었습니다.');
            return false;
        }
        
        if('<%=this.IisPassPreCloseDay %>' == 'Y')
        {
            alert('예비마감일자가 지났습니다.\r\n실적입력을 할 수 없습니다.');
            return false;
        }
        
//        if('<%=this.IConfirm_Status %>' == 'Y')
//        {
//            alert('해당 월의 실적은 이미 확정되었습니다');
//            return false;
//        }
        
        if('<%=this.IMontylyClose_YN %>' == 'Y')
        {
            alert('해당 월은 이미 마감되었습니다.');
            return false;
        }
        
        if('<%=this.IRelease_YN %>' == 'N')
        {
            alert('실적입력월이 아닙니다.');
            return false;
        }
        
        if('<%=this.IisEstMonth %>' == 'N')
        {
            alert('실적측정월이 아닙니다.');
            return false;
        }
        
        
        if(!confirm("저장하시겠습니까?"))
            return false;
        
    
        if("<%=this.IResultTsCalcType %>" == "SUM" || "<%=this.IResultTsCalcType %>" == "AVG")
        {
            
        
            return true;
        }
        else
        {
            var msg = "누적실적 계산방식이 단순합계나 단순평균이 아니므로 누적실적이 수기로 입력되어야 합니다. \n입력된 누적실적을 적용하시겠습니까?";
            if (confirm(msg))
            {
                return true;
            }
            else
            {
                return false
            }
        }
    }
        
   /*=========================================================================
     호출 파라미터 결재상신, 재상신 처리
     estterm_ref_id : 결재원문파라미터
     kpi_ref_id     : 결재원문파라미터
     ymd            : 결재원문파라미터
     app_ref_id     : 결재문서가 최초버젼일 아닐경우
     biz_type       : KDA:지표정의서 결재, KRA:지표실적결재, PMA:사업관리
     app_ccb        : 결재처리후 호출화면에서 처리시 컨트롤 client id 넘겨줌
   //========================================================================*/
   function OpenDraft(draftStatus)
   {
        var estterm_ref_id  = "<%= this.IEstTermRefID %>";
        var kpi_ref_id      = "<%= this.IKpiRefID %>";
        var ymd             = "<%= this.IYMD %>";
        var app_ref_id      = "<%= this.IApp_Ref_Id %>";
        var app_ccb         = "<%= this.IAPP_CCB %>";
        var biz_type        = "<%= Biz_Type.biz_type_target_result %>";
        var draft_emp_id    = parseInt("<%= this.IDraftEmpID %>",10);
        
        if (draft_emp_id=="NaN" || draft_emp_id  < 1)
        {
            alert("기안자 정보를 알수 없습니다.");
            return false;
        }
        
        var url             = "BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&POPUP_TYPE=A"+"&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+ "&YMD="+ ymd +"&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id+"&DRAFT_EMP_ID="+draft_emp_id;

<% if (this.IAPPROVAL_GATEWAY == true) { %>       
        var url = "ApprovalGateway.aspx?DRAFT_STATUS=" + draftStatus
                + "&POPUP_TYPE=A"+"&ESTTERM_REF_ID=" + estterm_ref_id 
                + "&KPI_REF_ID=" + kpi_ref_id 
                + "&YMD=" + ymd 
                + "&BIZ_TYPE=" + biz_type 
                + "&APP_CCB=" + app_ccb 
                + "&APP_REF_ID=" + app_ref_id 
                + "&DRAFT_EMP_ID=" + draft_emp_id;
<% } %>   
        gfOpenWindow(url, 900, 680, 'BSC0901M1');
        
        return false;
   }
   
   function OpenDraftPrint(draftStatus)
   {
        var estterm_ref_id  = "<%= this.IEstTermRefID %>";
        var kpi_ref_id      = "<%= this.IKpiRefID %>";
        var app_ref_id      = "<%= this.IApp_Ref_Id %>";
        var app_ccb         = "<%= this.IAPP_CCB %>";
        var biz_type        = "<%= Biz_Type.biz_type_target_result %>";
        var url             = "BSC0901P1.aspx?DRAFT_STATUS="+draftStatus+"&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+"&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id;

        gfOpenWindow(url, 900, 650, 'BSC0901P1');
        
        return false;
   }
        
//-->  
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();"
    id="iBtnQtnList">
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
                                        <img alt="" src="../images/title/popup_t12.gif" />
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
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%">
                                <%--<colgroup>
                    <col width="10%" style="height: 19px;" />
                    <col width="10%" />
                    <col width="10%" />
                    <col width="53%" />
                    <col width="8%" />
                    <col width="9%" />
                </colgroup>--%>
                                <tr>
                                    <td class="cssTblTitle">
                                        KPI 코드
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKPICode" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        KPI 명
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKPIName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        KPI 유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblRESULT_ACHIEVEMENT_TYPE" runat="server"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        단위
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        누적실적유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblRESULT_TS_CALC_TYPE" runat="server"></asp:Label>
                                        <span style="color: #003C3F;">(단순합산, 단순평균의 누계실적은 자동계산)</span>
                                    </td>
                                    <td class="cssTblTitle">
                                        직무분류
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblCATEGORY_NAME" runat="server" Text="Label"></asp:Label>
                                        <asp:HiddenField ID="hdfCauseDocNo" Value="" runat="server" />
                                        <asp:HiddenField ID="hdfMeasureDocNo" Value="" runat="server" />
                                        <asp:HiddenField ID="hdfInitiativeDocNo" Value="" runat="server" />
                                        <asp:HiddenField ID="hdfRESULT_DIFF_FILE_ID" runat="server" Value="" />
                                        <asp:HiddenField ID="hdfEXPECT_REASON_FILE_ID" runat="server" Value="" />
                                        <asp:DropDownList ID="ddlScoreGrade" runat="server" Visible="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopTblBottomSpace">
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebTab runat="server" ID="ugrdKpiResultTab" ThreeDEffect="False" Width="100%"
                                Height="100%" AutoPostBack="false">
                                <Tabs>
                                    <ig:Tab Text="실적입력" Key="1">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="height: 100%;">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <td style="width: 1%">
                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <span style="font-weight: bold;">계획/실적 현황</span>
                                                            </td>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="height: 100%;">
                                                    <td>
                                                        <ig:UltraWebGrid ID="ugrdResult" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdResult_InitializeLayout"
                                                            OnInitializeRow="ugrdResult_InitializeRow" OnDblClick="ugrdResult_DblClick">
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="년/월" Key="YMD_DESC" Width="10%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="년/월">
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="#94BAC9" ForeColor="Black">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS" HeaderText="계획" Key="TARGET_MS" Width="15%"
                                                                            Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS" HeaderText="실적" Key="RESULT_MS" Width="15%"
                                                                            Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="AC_RATE_MS" HeaderText="달성율" Key="AC_RATE_MS"
                                                                            Width="5%" Format="#,###,##0.##" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Right" BackColor="WhiteSmoke">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS" HeaderText="계획" Key="TARGET_TS" Width="15%"
                                                                            Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS" HeaderText="실적" Key="RESULT_TS" Width="15%"
                                                                            Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="AC_RATE_TS" HeaderText="달성율" Key="AC_RATE_TS"
                                                                            Width="5%" Format="#,###,##0.##" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHECKSTATUS" HeaderText="입력" Key="CHECKSTATUS"
                                                                            Width="5%">
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="APP_STATUS" HeaderText="결재" Key="APP_STATUS"
                                                                            Width="5%">
                                                                            <HeaderStyle Wrap="True" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <CellTemplate>
                                                                                <asp:Image runat="server" ID="imgApp" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                                                                </asp:Image>
                                                                            </CellTemplate>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL_MS" HeaderText="당월" Key="SIGNAL_MS" Width="5%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL_TS" HeaderText="누계" Key="SIGNAL_TS" Width="5%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="평가기간" Key="ESTTERM_REF_ID"
                                                                            Hidden="True" DataType="System.Int">
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Key="KPI_REF_ID"
                                                                            Hidden="True" DataType="System.Int">
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Key="YMD" Width="10px"
                                                                            Hidden="True">
                                                                        </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                                    </RowTemplateStyle>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                                CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                                Name="ugrdResult" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00" ViewType="OutlookGroupBy">
                                                                <%--
                                                <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                    <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                </SelectedRowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                    ForeColor="White" HorizontalAlign="Left">
                                                    <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                </HeaderStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="2px"
                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="85%">
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
                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                </RowAlternateStyleDefault>
                                                                <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                </HeaderStyleDefault>
                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%">
                                                                </FrameStyle>
                                                                <ClientSideEvents MouseOutHandler="MouseOverHandler" />
                                                            </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table id="pnlDesc" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td style="width: 15px">
                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <span style="font-weight: bold;">실적입력 및
                                                                                    <%=this.GetText("LBL_00005", "PA Report")%></span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tableBorder"
                                                                        style="height: 100%;">
                                                                        <tr>
                                                                            <td rowspan="2" style="text-align: center;" class="cssTblTitle">
                                                                                [<asp:Label ID="lblMM_MS" runat="server" Font-Bold="true" />]<br />
                                                                                실적입력
                                                                            </td>
                                                                            <td style="width: 330px; text-align: center;" class="cssTblTitle">
                                                                                <span>[ 당월실적입력 ]</span>
                                                                            </td>
                                                                            <td style="width: 330px; text-align: center;" class="cssTblTitle">
                                                                                <span>[ 누적실적입력 ]</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center;" class="cssTblContent">
                                                                                <ig:WebNumericEdit ID="txtMSResult" runat="server" Width="100%" Nullable="False"
                                                                                    ValueText="0.0000" BorderColor="red" BorderWidth="2px" MaxValue="999999999999999"
                                                                                    MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" onblur="doCompute();"
                                                                                    Font-Size="10pt" Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="Three">
                                                                                </ig:WebNumericEdit>
                                                                            </td>
                                                                            <td style="text-align: center;" class="cssTblContent">
                                                                                <ig:WebNumericEdit ID="txtTSResult" runat="server" Width="100%" Nullable="False"
                                                                                    ValueText="0" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="Range of values: from -100 to 10000"
                                                                                    NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                                                                    NullText="0" MinDecimalPlaces="Three">
                                                                                </ig:WebNumericEdit>
                                                                                <asp:HiddenField ID="hdfTSResult" runat="server" Value="" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center;" class="cssTblTitle">
                                                                                원인분석<br />
                                                                                <br />
                                                                                <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfCauseDocNo')" />
                                                                                <asp:ImageButton runat="server" ID="imgHdfCauseDocNo" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                    OnClientClick="return mfDownload('hdfCauseDocNo')" />
                                                                            </td>
                                                                            <td align="center" class="cssTblContent">
                                                                                <asp:TextBox ID="txtCAUSE_TEXT_MS" runat="server" Height="60px" Width="100%" Rows="100"
                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" class="cssTblContent">
                                                                                <asp:TextBox ID="txtCAUSE_TEXT_TS" runat="server" Height="60px" Width="100%" Rows="100"
                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="text-align: center;" class="cssTblTitle">
                                                                                대책검토<br />
                                                                                <br />
                                                                                <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfMeasureDocNo')" />
                                                                                <asp:ImageButton runat="server" ID="imgHdfMeasureDocNo" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                    OnClientClick="return mfDownload('hdfMeasureDocNo')" />
                                                                            </td>
                                                                            <td align="center" class="cssTblContent">
                                                                                <asp:TextBox ID="txtMEASURE_TEXT_MS" runat="server" Height="60px" Width="100%" Rows="100"
                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" class="cssTblContent">
                                                                                <asp:TextBox ID="txtMEASURE_TEXT_TS" runat="server" Height="60px" Width="100%" Rows="100"
                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="cssPopBtnLine">
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:ImageButton ID="iBtnPastTotal" runat="server" ImageUrl="../images/btn/b_tp02_b.gif" />
                                                                </td>
                                                                <td align="right">
                                                                    <asp:ImageButton ID="iBtnPrint" ImageUrl="../images/btn/b_080.gif" Visible="false"
                                                                        runat="server" />
                                                                    <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_tp07.gif" runat="server"
                                                                        OnClick="iBtnInsert_Click" OnClientClick="return getTsSumMsg();" />
                                                                    <asp:ImageButton ID="iBtnConfirm" ImageUrl="../images/btn/b_015.gif" runat="server"
                                                                        OnClick="iBtnConfirm_Click" />
                                                                    <asp:ImageButton ID="iBtnCancel" ImageUrl="../images/btn/b_019.gif" runat="server"
                                                                        OnClick="iBtnCancel_Click" />
                                                                    <asp:ImageButton ID="iBtnDraft" ImageUrl="../images/btn/btn021.gif" runat="server"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="iBtnReDraft" ImageUrl="../images/draft/redraft.gif" runat="server"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="iBtnMoDraft" ImageUrl="../images/draft/modraft.gif" runat="server"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="iBtnReqModify" ImageUrl="../images/draft/morequest.gif" runat="server"
                                                                        Visible="false" OnClick="iBtnReqModify_Click" />
                                                                    <asp:ImageButton ID="iBtnReWrite" ImageUrl="../images/draft/rewrite.gif" runat="server"
                                                                        Visible="false" />
                                                                    <asp:ImageButton ID="iBtnClose" ImageUrl="../images/btn/b_003.gif" runat="server"
                                                                        OnClick="iBtnClose_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                    <ig:TabSeparator>
                                        <Style Width="1px">
                                            </Style>
                                    </ig:TabSeparator>
                                    <ig:Tab Text="Initiative 입력" Key="2">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                            <tr style="height: 25px;">
                                                                <td style="width: 50%">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 1%">
                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <b>Initiative 추진계획</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 50%">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 1%">
                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <b>Initiative 추진내용</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 100%;">
                                                                <td>
                                                                    <asp:TextBox ID="txtINITIATIVE_PLAN" runat="server" Height="100%" Width="100%" BackColor="whitesmoke"
                                                                        TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtINITIATIVE_DO" runat="server" Height="100%" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr class="cssPopBtnLine">
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 140px;">
                                                                                Initiative 실적 파일첨부
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;<img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfInitiativeDocNo')" />
                                                                                <asp:ImageButton runat="server" ID="imgHdfInitiativeDocNo" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                    OnClientClick="return mfDownload('hdfInitiativeDocNo')" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                </Tabs>
                                <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff">
                                </DefaultTabStyle>
                                <SelectedTabStyle CssClass="cssTabStyleOn">
                                </SelectedTabStyle>
                                <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif"
                                    SelectedImage="../images/tab/ig_tab_blueb2.gif" />
                            </ig:UltraWebTab>
                            <asp:Literal ID="ltrScript" runat="server" Text=""></asp:Literal>
                            <asp:LinkButton ID="linkBtnDraft" runat="server" Visible="false" OnClick="linkBtnDraft_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkRefresh" runat="server" Visible="false" OnClick="lnkRefresh_Click"></asp:LinkButton>
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
                            <asp:HiddenField ID="hdfResultTS" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
