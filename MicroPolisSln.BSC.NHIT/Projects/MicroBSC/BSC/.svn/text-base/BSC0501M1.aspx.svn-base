<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BSC0501M1.aspx.cs"
    Inherits="BSC_BSC0501M1" %>

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
                        ,520
                        ,'no'
                        ,'no'
                        ,'Win6');
            return false;
        }
        
        function clickshow(num)  
        {  
                for (i=0;i<4;i++)  
                {  
                    menu=eval("document.all.block"+i+".style");          
                    imgch=eval("document.bar"+i);                                            
                    if (num==i)  
                    {  
                        if (menu.display=="block")  
                        { 
                            menu.display="none"; 
                        }  
                        else 
                        {  
                            menu.display="block"; 
                            
                        }  
                    }  
                }  
                
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
        
        function mfUpload_Review(hAttachNo)
        {
        
            <%
            /*
                Argument설명
                    : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                    : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
            */
            %>
            //수정(20060707 이승주)
            var oAttach = gfGetFindObj(hAttachNo);
            
            var oaArg   = new Array("FILE", "REVIEW", (oAttach==null ? "" : oAttach.value));
            var isMonthlyClose = "<%= this.IMontylyClose_YN %>"; // 월마감여부
            var isYearlyClose  = "<%= this.IYearlyClose_YN %>";  // 년마감여부
            var isAdmin        = "<%= this.IisAdmin %>"
            var isCompleteEst  = "<%= this.IEstStatus %>";
            
            var confirmFlag = 'T';
            if (isMonthlyClose=='Y' || isYearlyClose=='Y' || isCompleteEst=='Y')
            {
                confirmFlag = 'F';
            }
            
            if (isAdmin == 'Y')
            {
                confirmFlag = 'T';
            }
            
            var url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG="+confirmFlag+"&SIZE=L";
            
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
        
        function openInterfaceDataAdd()
        {
            var intKpi  = "<%= this.IKpiRefID %>";
            var intEst  = document.form1.hdnEstTermID.value;
            var ymd     = document.form1.hdnYMD.value;
            
            var url = '/BSC/BSC0603S1.aspx?ESTTERM_REF_ID=' + intEst + '&KPI_REF_ID='+intKpi + "&YMD=" + ymd;
            
            gfOpenWindow(url,800,680,'no','no','BSC0603S1');
        }
        
        function showKPI()
        {
            var intKpi = document.form1.hdnKpiId.value;
            var intEst = document.form1.hdnEstTermID.value;
            //window.open('svr2002.aspx?iType=S&eid=' + intKpi + '&ESTTERM_REF_ID='+intEst, 'KpiMaster','width=900, height=620,scrollbars=no'); 
            var url = 'svr2002.aspx?iType=S&eid=' + intKpi + '&ESTTERM_REF_ID='+intEst;
            gfOpenWindow(url,900,650,'no','no','Win2');
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
        
        function getTsSumMsg()
        {
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
        var biz_type        = "<%= Biz_Type.biz_type_kpi_rst %>";
        var draft_emp_id    = parseInt("<%= this.IDraftEmpID %>",10);
        
        if (draft_emp_id=="NaN" || draft_emp_id  < 1)
        {
            alert("기안자 정보를 알수 없습니다.");
            return false;
        }
        
        var url             = "BSC0901M1.aspx?DRAFT_STATUS="+draftStatus+"&POPUP_TYPE=A"+"&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+ "&YMD="+ ymd +"&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id+"&DRAFT_EMP_ID="+draft_emp_id;

<% if (this.ExternalApproval == true) { %>       
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
        var biz_type        = "<%= Biz_Type.biz_type_kpi_rst %>";
        var ymd             = "<%= this.IYMD %>";
        var url             = "BSC0901P1.aspx?DRAFT_STATUS="+draftStatus+"&ESTTERM_REF_ID=" + estterm_ref_id + "&KPI_REF_ID=" + kpi_ref_id+"&BIZ_TYPE="+biz_type+"&APP_CCB="+app_ccb+"&APP_REF_ID="+app_ref_id+"&YMD="+ymd;

        gfOpenWindow(url, 900, 650, 'BSC0901P1');
        
        return false;
   }
        
//-->  
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();"
    id="iBtnQtnList">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
        <asp:HiddenField ID="hdnEstTermID" runat="server" />
        <asp:HiddenField ID="hdnKpiId" runat="server" />
        <asp:HiddenField ID="hdnYMD" runat="server" />
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
                                        단위
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        측정유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblRESULT_INPUT_TYPE" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        누적실적유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblRESULT_TS_CALC_TYPE" runat="server"></asp:Label>
                                        <span style="color: #03C3FF;">(단순합산, 단순평균의 누계실적은 자동계산)
                                    </td>
                                    <td class="cssTblTitle">
                                        KPI 유형
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblRESULT_ACHIEVEMENT_TYPE" runat="server"></asp:Label>
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
                    <tr style="height: 10px;">
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 100%;">
                        <td>
                            <ig:UltraWebTab runat="server" ID="ugrdKpiResultTab" Height="100%" ThreeDEffect="False" Width="100%" AutoPostBack="false">
                                <Tabs>
                                    <ig:Tab Text="실적입력" Key="1">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td style="width: 1%">
                                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                                </td>
                                                                <td>
                                                                    <span style="font-weight: bold;">계획/실적 현황
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="height: 100%;">
                                                    <td>
                                                        <ig:UltraWebGrid ID="ugrdResult" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdResult_InitializeLayout"
                                                            OnInitializeRow="ugrdResult_InitializeRow" OnDblClick="ugrdResult_DblClick">
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <Columns>
                                                                        <ig:UltraGridColumn BaseColumnName="YMD_DESC" HeaderText="년/월" Key="YMD_DESC" Width="65px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="년/월">
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center" BackColor="#94BAC9" ForeColor="Black">
                                                                            </CellStyle>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_MS" FooterText="" HeaderText="계획" Key="TARGET_MS"
                                                                            Width="90px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="계획">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS" FooterText="" HeaderText="실적" Key="RESULT_MS"
                                                                            Width="90px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="2" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CAL_RESULT_MS" FooterText="" HeaderText="인터페이스실적"
                                                                            Key="CAL_RESULT_MS" Width="95px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="인터페이스실적">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="3" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="AC_RATE_MS" FooterText="" HeaderText="달성율" Key="AC_RATE_MS"
                                                                            Width="70px" Format="#,###,##0.##" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="달성율">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="4" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="TARGET_TS" FooterText="" HeaderText="계획" Key="TARGET_TS"
                                                                            Width="90px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="계획">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS" FooterText="" HeaderText="실적" Key="RESULT_TS"
                                                                            Width="90px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="6" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CAL_RESULT_TS" FooterText="" HeaderText="인터페이스실적"
                                                                            Key="CAL_RESULT_TS" Width="95px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="인터페이스실적">
                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="7" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="AC_RATE_TS" FooterText="" HeaderText="달성율" Key="AC_RATE_TS"
                                                                            Width="70px" Format="#,###,##0.##" DataType="System.Double">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="달성율">
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="8" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHECKSTATUS" FooterText="" HeaderText="입력" Key="CHECKSTATUS"
                                                                            Width="20px">
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                                            <Header Caption="입력">
                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="9" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID=""
                                                                            Width="20px" FooterText="" HeaderText="APP_STATUS">
                                                                            <Header Caption="결재">
                                                                                <RowLayoutColumnInfo OriginX="5" />
                                                                            </Header>
                                                                            <HeaderStyle Wrap="True" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <CellTemplate>
                                                                                <asp:Image runat="server" ID="imgApp" alt="" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                                                                </asp:Image>
                                                                            </CellTemplate>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="10" />
                                                                            </Footer>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL_MS" FooterText="" HeaderText="당" Key="SIGNAL_MS"
                                                                            Width="20px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="당">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="SIGNAL_TS" FooterText="" HeaderText="누" Key="SIGNAL_TS"
                                                                            Width="20px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="누">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="ESTTERM_REF_ID" FooterText="" HeaderText="평가기간"
                                                                            Key="ESTTERM_REF_ID" Width="10px" Hidden="True" DataType="System.Int">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="평가기간">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Footer>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="KPI_REF_ID" FooterText="" HeaderText="KPI_REF_ID"
                                                                            Key="KPI_REF_ID" Width="10px" Hidden="True" DataType="System.Int">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI_REF_ID">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Footer>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="YMD" FooterText="" HeaderText="YMD" Key="YMD"
                                                                            Width="10px" Hidden="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="YMD">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <ValueList DisplayStyle="NotSet">
                                                                            </ValueList>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Footer>
                                                                        </ig:TemplatedColumn>
                                                                    </Columns>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                AllowSortingDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                                CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" Name="ugrdResult"
                                                                RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                StationaryMargins="Header" TableLayout="Fixed" Version="4.00">
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
                                                <tr style="height: 200px;">
                                                    <td style="width: 100%;">
                                                        <asp:Panel ID="pnlDesc" runat="server" Width="100%" Height="100%" ScrollBars="auto">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
                                                                <tr>
                                                                    <td style="width: 100%;">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td style="width: 1%">
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
                                                                                <td style="width: 100%;">
                                                                                    <table class="tableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td align="center" rowspan="3" class="cssTblTitle" style="width: 25%;">
                                                                                                [<asp:Label ID="lblMM_MS" runat="server" Font-Bold="true"></asp:Label>]<br />
                                                                                                실적입력
                                                                                            </td>
                                                                                            <td align="center" colspan="2" class="cssTblTitle" style="width: 25%;">
                                                                                                당월실적입력
                                                                                            </td>
                                                                                            <td align="center" colspan="2" class="cssTblTitle" style="width: 25%;">
                                                                                                누적실적입력
                                                                                            </td>
                                                                                            <td align="center" rowspan="2" class="cssTblTitle" style="width: 25%;">
                                                                                                인터페이스실적 적용 및 사유
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                적용실적
                                                                                            </td>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                인터페이스실적
                                                                                            </td>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                적용실적
                                                                                            </td>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                인터페이스실적
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="cssTblContent" style="width: 25%;">
                                                                                                <ig:WebNumericEdit ID="txtMSResult" runat="server" Width="100%" Nullable="False"
                                                                                                    ValueText="0.0000" BorderColor="red" BorderWidth="2px" MaxValue="999999999999999"
                                                                                                    MinValue="-999999999999999" ToolTip="당월실적" NegativeForeColor="Magenta" Font-Size="10pt"
                                                                                                    Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="Three">
                                                                                                </ig:WebNumericEdit>
                                                                                            </td>
                                                                                            <td class="cssTblContent" style="width: 25%;">
                                                                                                <ig:WebNumericEdit ID="txtMsCalcResult" runat="server" Width="100%" Nullable="False"
                                                                                                    ValueText="0.0000" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월실적"
                                                                                                    NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                                                                                    NullText="0" MinDecimalPlaces="Three" ReadOnly="true" BackColor="whitesmoke">
                                                                                                </ig:WebNumericEdit>
                                                                                            </td>
                                                                                            <td class="cssTblContent" style="width: 25%;">
                                                                                                <ig:WebNumericEdit ID="txtTSResult" runat="server" Width="100%" Nullable="False"
                                                                                                    ValueText="0" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="Range of values: from -100 to 10000"
                                                                                                    NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                                                                                    NullText="0" MinDecimalPlaces="Three">
                                                                                                </ig:WebNumericEdit>
                                                                                            </td>
                                                                                            <td class="cssTblContent" style="width: 25%;">
                                                                                                <ig:WebNumericEdit ID="txtTsCalcResult" runat="server" Width="100%" Nullable="False"
                                                                                                    ValueText="0" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="Range of values: from -100 to 10000"
                                                                                                    NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                                                                                    NullText="0" MinDecimalPlaces="Three" ReadOnly="true" BackColor="whitesmoke">
                                                                                                </ig:WebNumericEdit>
                                                                                            </td>
                                                                                            <td class="cssTblContent">
                                                                                                <asp:CheckBox ID="ChkApplyItfsResult" runat="server" AutoPostBack="True" OnCheckedChanged="ChkApplyItfsResult_CheckedChanged" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" style="width: 100px;" class="cssTblTitle">
                                                                                                원인분석<br />
                                                                                                <br />
                                                                                                <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfCauseDocNo')" />
                                                                                                <asp:ImageButton runat="server" ID="imgHdfCauseDocNo" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                                    OnClientClick="return mfDownload('hdfCauseDocNo')" />
                                                                                            </td>
                                                                                            <td colspan="2" align="center" style="background-color: #ffffff; height: 60px;" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtCAUSE_TEXT_MS" runat="server" Height="100%" Width="300px" Rows="100"
                                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                                            </td>
                                                                                            <td colspan="2" align="center" style="background-color: #ffffff; height: 60px;" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtCAUSE_TEXT_TS" runat="server" Height="100%" Width="300px" Rows="100"
                                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="background-color: #ffffff; width: 100px;" rowspan="2" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtNotApplyReason" Width="100px" Height="140px" MaxLength="10000"
                                                                                                    TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                대책검토<br />
                                                                                                <br />
                                                                                                <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfMeasureDocNo')" />
                                                                                                <asp:ImageButton runat="server" ID="imgHdfMeasureDocNo" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                                    OnClientClick="return mfDownload('hdfMeasureDocNo')" />
                                                                                            </td>
                                                                                            <td colspan="2" style="background-color: #ffffff; height: 50px;" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtMEASURE_TEXT_MS" runat="server" Height="100%" Width="300px" Rows="100"
                                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                                            </td>
                                                                                            <td colspan="2" align="center" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtMEASURE_TEXT_TS" runat="server" Height="100%" Width="100%" Rows="100"
                                                                                                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%;">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td style="width: 1%">
                                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <span style="font-weight: bold;">익월실적예측
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%;">
                                                                                    <table class="tableBorder" width="100%" border="0" cellpadding="0" cellspacing="0"
                                                                                        style="">
                                                                                        <tr>
                                                                                            <td align="center" style="width: 16%;" class="cssTblTitle">
                                                                                                구분
                                                                                            </td>
                                                                                            <td align="center" style="width: 42%;" class="cssTblTitle">
                                                                                                <span>(<asp:Label ID="lblNextYmd_Ms" runat="server"></asp:Label>)월 당월 예측실적
                                                                                            </td>
                                                                                            <td align="center" style="width: 42%;" class="cssTblTitle">
                                                                                                <span>(<asp:Label ID="lblNextYmd_Ts" runat="server"></asp:Label>)월 누적 예측실적
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                예상실적
                                                                                            </td>
                                                                                            <td align="center" class="cssTblContent">
                                                                                                <ig:WebNumericEdit ID="txtExtResult_MS" runat="server" Width="50%" Nullable="False"
                                                                                                    ValueText="0.0000" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="당월예측실적"
                                                                                                    NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                                                                                    NullText="0" MinDecimalPlaces="Three">
                                                                                                </ig:WebNumericEdit>
                                                                                            </td>
                                                                                            <td align="center" class="cssTblContent">
                                                                                                <ig:WebNumericEdit ID="txtExtResult_TS" runat="server" Width="50%" Nullable="False"
                                                                                                    ValueText="0.0000" MaxValue="999999999999999" MinValue="-999999999999999" ToolTip="누적예측실적"
                                                                                                    NegativeForeColor="Magenta" Font-Size="10pt" Font-Names="Verdana" Height="100%"
                                                                                                    NullText="0" MinDecimalPlaces="Three">
                                                                                                </ig:WebNumericEdit>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" class="cssTblTitle">
                                                                                                예상근거<br />
                                                                                                <br />
                                                                                                <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfEXPECT_REASON_FILE_ID')" />
                                                                                                <asp:ImageButton runat="server" ID="imgHdfEXPECT_REASON_FILE_ID" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                                    OnClientClick="return mfDownload('hdfEXPECT_REASON_FILE_ID')" />
                                                                                            </td>
                                                                                            <td align="center" style="background-color: #ffffff; height: 80px;" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtEXPECT_REASON_MS" runat="server" Height="100px" Width="100%"
                                                                                                    Rows="120" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                                            </td>
                                                                                            <td align="center" style="background-color: #ffffff; height: 80px;" class="cssTblContent">
                                                                                                <asp:TextBox ID="txtEXPECT_REASON_TS" runat="server" Height="100px" Width="100%"
                                                                                                    Rows="120" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
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
                                                                                <td>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td style="width: 1%">
                                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <span style="font-weight: bold;">예측차이분석
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <td>
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tableBorder">
                                                                                    <tr>
                                                                                        <td style="height: 120px;">
                                                                                            <ig:UltraWebGrid ID="ugrdExpectGrid" runat="server" Width="100%" Height="100%" OnInitializeLayout="ugrdExpectGrid_InitializeLayout"
                                                                                                OnInitializeRow="ugrdExpectGrid_InitializeRow">
                                                                                                <Bands>
                                                                                                    <ig:UltraGridBand>
                                                                                                        <Columns>
                                                                                                            <ig:UltraGridColumn BaseColumnName="GUBUN" HeaderText="구분" Key="GUBUN" Width="138px">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="구분">
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Left" BackColor="#94BAC9" ForeColor="White">
                                                                                                                </CellStyle>
                                                                                                            </ig:UltraGridColumn>
                                                                                                            <ig:UltraGridColumn BaseColumnName="TARGET_MS" FooterText="" HeaderText="계획" Key="TARGET_MS"
                                                                                                                Width="115px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="계획">
                                                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                                                                </CellStyle>
                                                                                                                <Footer Caption="">
                                                                                                                    <RowLayoutColumnInfo OriginX="1" />
                                                                                                                </Footer>
                                                                                                            </ig:UltraGridColumn>
                                                                                                            <ig:UltraGridColumn BaseColumnName="RESULT_MS" FooterText="" HeaderText="실적" Key="RESULT_MS"
                                                                                                                Width="115px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="실적">
                                                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                                                                </CellStyle>
                                                                                                                <Footer Caption="">
                                                                                                                    <RowLayoutColumnInfo OriginX="2" />
                                                                                                                </Footer>
                                                                                                            </ig:UltraGridColumn>
                                                                                                            <ig:UltraGridColumn BaseColumnName="AC_RATE_MS" FooterText="" HeaderText="달성율" Key="AC_RATE_MS"
                                                                                                                Width="115px" Format="#,###,###,###,###,###,##0.##" DataType="System.Double">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="달성율">
                                                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Right" BackColor="whitesmoke">
                                                                                                                </CellStyle>
                                                                                                                <Footer Caption="">
                                                                                                                    <RowLayoutColumnInfo OriginX="4" />
                                                                                                                </Footer>
                                                                                                            </ig:UltraGridColumn>
                                                                                                            <ig:UltraGridColumn BaseColumnName="TARGET_TS" FooterText="" HeaderText="계획" Key="TARGET_TS"
                                                                                                                Width="115px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="계획">
                                                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                                                                </CellStyle>
                                                                                                                <Footer Caption="">
                                                                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                                                                </Footer>
                                                                                                            </ig:UltraGridColumn>
                                                                                                            <ig:UltraGridColumn BaseColumnName="RESULT_TS" FooterText="" HeaderText="실적" Key="RESULT_TS"
                                                                                                                Width="115px" Format="#,###,###,###,###,###,##0.####" DataType="System.Double">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="실적">
                                                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                                                                </CellStyle>
                                                                                                                <Footer Caption="">
                                                                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                                                                </Footer>
                                                                                                            </ig:UltraGridColumn>
                                                                                                            <ig:UltraGridColumn BaseColumnName="AC_RATE_TS" FooterText="" HeaderText="달성율" Key="AC_RATE_TS"
                                                                                                                Width="115px" Format="#,###,###,###,###,###,##0.##" DataType="System.Double">
                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                <Header Caption="달성율">
                                                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                                                </Header>
                                                                                                                <CellStyle HorizontalAlign="Right" BackColor="Lavender">
                                                                                                                </CellStyle>
                                                                                                                <Footer Caption="">
                                                                                                                    <RowLayoutColumnInfo OriginX="8" />
                                                                                                                </Footer>
                                                                                                            </ig:UltraGridColumn>
                                                                                                        </Columns>
                                                                                                    </ig:UltraGridBand>
                                                                                                </Bands>
                                                                                                <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AllowDeleteDefault="Yes"
                                                                                                    AllowSortingDefault="No" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                                                                    CellClickActionDefault="RowSelect" CellPaddingDefault="2" HeaderClickActionDefault="SortMulti"
                                                                                                    Name="ugrdExpectGrid" RowHeightDefault="20px" RowSelectorsDefault="No" SelectTypeRowDefault="Extended"
                                                                                                    StationaryMargins="Header" TableLayout="Fixed" Version="4.00" OptimizeCSSClassNamesOutput="False"
                                                                                                    ViewType="OutlookGroupBy">
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
                                                                                                </DisplayLayout>
                                                                                            </ig:UltraWebGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table class="tableBorder" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td class="cssTblTitle" align="center" style="width: 135px;">
                                                                                                        원인<br />
                                                                                                        <br />
                                                                                                        <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfRESULT_DIFF_FILE_ID')" />
                                                                                                        <asp:ImageButton runat="server" ID="imgHdfRESULT_DIFF_FILE_ID" ImageUrl="~/images/icon/icon_gr_po04.gif"
                                                                                                            OnClientClick="return mfDownload('hdfRESULT_DIFF_FILE_ID')" />
                                                                                                    </td>
                                                                                                    <td align="right" style="background-color: #ffffff; height: 80px; width: 740px;">
                                                                                                        <asp:TextBox ID="txtRESULT_DIFF_CAUSE" runat="server" Height="100px" Width="100%"
                                                                                                            Rows="120" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
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
                                                                    <asp:ImageButton ID="iBtnInterfaceDataAdd" ImageUrl="../images/btn/b_i006.gif" runat="server" />
                                                                    <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_tp07.gif" runat="server"
                                                                        OnClick="iBtnInsert_Click" OnClientClick="return getTsSumMsg();" />
                                                                    <asp:ImageButton ID="iBtnConfirm" ImageUrl="../images/btn/b_015.gif" runat="server"
                                                                        OnClick="iBtnConfirm_Click" />
                                                                    <asp:ImageButton ID="iBtnCancel" ImageUrl="../images/btn/b_019.gif" runat="server"
                                                                        OnClick="iBtnCancel_Click" />
                                                                    <asp:ImageButton ID="iBtnDraft" ImageUrl="../images/draft/draft.gif" runat="server"
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
                                        <Style Width="1px" />
                                    </ig:TabSeparator>
                                    <ig:Tab Text="Initiative 입력" Key="2">
                                        <Style Width="200px" Height="25px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                            <tr style="height: 25px;">
                                                                <td style="width: 50%">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                                                <img alt="" src="../images/icon/gr_po05.gif" style="cursor: hand;" onclick="mfUpload('hdfInitiativeDocNo')" />
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
                                    <ig:TabSeparator>
                                        <Style Width="1px" />
                                    </ig:TabSeparator>
                                    <ig:Tab Text="정성지표 평가" Key="3">
                                        <Style Width="200px" Height="23px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                            <tr>
                                                                <td style="width: 15px;">
                                                                    <img src="../images/title/ma_t14.gif" alt="" />
                                                                </td>
                                                                <td>
                                                                    <b>평가기준</b>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlBasis" BorderWidth="1px" BorderColor="whitesmoke" Width="100%"
                                                            Height="200px" runat="server" ScrollBars="auto">
                                                            <asp:Literal runat="server" ID="ltrEstBasis"></asp:Literal>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="height: 100%;">
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                            <tr>
                                                                <td style="width: 40%;">
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 15px;">
                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <b>평가항목</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                        <tr>
                                                                            <td style="width: 15px;">
                                                                                <img src="../images/title/ma_t14.gif" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <b>검토의견</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 100%;">
                                                                <td>
                                                                    <ig:UltraWebGrid ID="ugrdQuestionList" runat="server" Height="100%" Width="100%"
                                                                        OnInitializeLayout="ugrdQuestionList_InitializeLayout" OnInitializeRow="ugrdQuestionList_InitializeRow">
                                                                        <Bands>
                                                                            <ig:UltraGridBand>
                                                                                <AddNewRow View="NotSet" Visible="NotSet">
                                                                                </AddNewRow>
                                                                                <Columns>
                                                                                    <ig:UltraGridColumn BaseColumnName="ITYPE" HeaderText="입력구분" Key="ITYPE" Hidden="True"
                                                                                        Width="40px" AllowUpdate="No">
                                                                                        <Header Caption="입력구분">
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="True"
                                                                                        Key="ESTTERM_REF_ID" AllowUpdate="No">
                                                                                        <Header Caption="ESTTERM_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="1" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" HeaderText="KPI_REF_ID" Hidden="True"
                                                                                        Key="KPI_REF_ID" AllowUpdate="No">
                                                                                        <Header Caption="KPI_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" HeaderText="EST_EMP_ID" Hidden="True"
                                                                                        Key="EST_EMP_ID" AllowUpdate="No">
                                                                                        <Header Caption="EST_EMP_ID">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="GROUP_REF_ID" HeaderText="GROUP_REF_ID" Hidden="True"
                                                                                        Key="GROUP_REF_ID" AllowUpdate="No">
                                                                                        <Header Caption="GROUP_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="2" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="YMD" HeaderText="YMD" Hidden="True" Key="YMD"
                                                                                        AllowUpdate="No">
                                                                                        <Header Caption="YMD">
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="3" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL" HeaderText="EST_LEVEL" Hidden="True"
                                                                                        Key="EST_LEVEL" Width="40px" AllowUpdate="No">
                                                                                        <Header Caption="EST_LEVEL">
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="4" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="EST_LEVEL_NAME" HeaderText="차수명" Key="EST_LEVEL_NAME"
                                                                                        Width="70px" MergeCells="True" AllowUpdate="No">
                                                                                        <Header Caption="차수명">
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle BackColor="WhiteSmoke">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="5" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="QUESTION_REF_ID" HeaderText="QUESTION_REF_ID"
                                                                                        Hidden="True" Key="QUESTION_REF_ID" Width="60px" AllowUpdate="No">
                                                                                        <Header Caption="QUESTION_REF_ID">
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Header>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="6" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="ITEM_NAME" HeaderText="평가항목" Key="ITEM_NAME"
                                                                                        Width="120px" AllowUpdate="No">
                                                                                        <Header Caption="평가항목">
                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle BackColor="WhiteSmoke">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="7" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <ig:UltraGridColumn BaseColumnName="WEIGHT" HeaderText="가중치" Key="WEIGHT" DataType="System.Double"
                                                                                        NullText="0" Width="45px" AllowUpdate="No">
                                                                                        <Header Caption="가중치">
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <CellStyle HorizontalAlign="Right" BackColor="WhiteSmoke">
                                                                                        </CellStyle>
                                                                                        <Footer>
                                                                                            <RowLayoutColumnInfo OriginX="8" />
                                                                                        </Footer>
                                                                                    </ig:UltraGridColumn>
                                                                                    <%--                                                        <ig:UltraGridColumn BaseColumnName="SCORE" HeaderText="점수" Key="SCORE" DataType="System.Double" NullText="0" Width="50px" AllowUpdate="Yes">
                                                        <Header Caption="점수" >
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Header>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <CellStyle HorizontalAlign="Right"></CellStyle>
                                                        <Footer>
                                                            <RowLayoutColumnInfo OriginX="9" />
                                                        </Footer>
                                                    </ig:UltraGridColumn>--%>
                                                                                    <ig:TemplatedColumn Key="TXTSCORE" BaseColumnName="SCORE" Width="80px">
                                                                                        <Header Caption="점수">
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <ig:WebNumericEdit ID="txtScore" runat="server" Width="100%" Nullable="False" ValueText="0.0000"
                                                                                                MaxValue="1000000000" MinValue="0" ToolTip="평가점수" NegativeForeColor="Magenta"
                                                                                                Font-Size="10pt" Font-Names="Verdana" Height="100%" NullText="0" MinDecimalPlaces="Two">
                                                                                            </ig:WebNumericEdit>
                                                                                        </CellTemplate>
                                                                                    </ig:TemplatedColumn>
                                                                                    <ig:TemplatedColumn Key="DDLSCORE" BaseColumnName="SCORE_GRADE" Width="80px" NullText="ZZZ">
                                                                                        <Header Caption="점수">
                                                                                        </Header>
                                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                                                        </CellStyle>
                                                                                        <CellTemplate>
                                                                                            <asp:DropDownList ID="ddlScore" runat="server" Width="100%">
                                                                                            </asp:DropDownList>
                                                                                        </CellTemplate>
                                                                                    </ig:TemplatedColumn>
                                                                                </Columns>
                                                                            </ig:UltraGridBand>
                                                                        </Bands>
                                                                        <DisplayLayout Version="4.00" AllowUpdateDefault="Yes" HeaderClickActionDefault="NotSet"
                                                                            Name="ugrdQuestionList" BorderCollapseDefault="Separate" RowSelectorsDefault="No"
                                                                            RowHeightDefault="23px" SelectTypeRowDefault="Single" TableLayout="Fixed" AutoGenerateColumns="False"
                                                                            AllowRowNumberingDefault="Continuous" StationaryMargins="HeaderAndFooter" CellClickActionDefault="Edit">
                                                                            <%--<GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#D2D2D2" ForeColor="DimGray">
                                                    <BorderDetails  ColorLeft="210, 210, 210" ColorTop="210, 210, 210" />
                                                </GroupByRowStyleDefault>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left">
                                                    <BorderDetails ColorTop="White" WidthTop="1px" />
                                                </FooterStyleDefault>                                                
                                                <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px" Cursor="hand">
                                                    <BorderDetails  ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
                                                <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Left" BorderColor="#E5E5E5" ForeColor="White" Height="30px">
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
                                                    <ClientSideEvents AfterRowInsertHandler="ugrdDetail_AfterRowInsertHandler" />
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
                                                                            <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                                                            </FrameStyle>
                                                                        </DisplayLayout>
                                                                    </ig:UltraWebGrid>
                                                                </td>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                                                        <tr style="height: 100%;">
                                                                            <td colspan="2">
                                                                                <asp:TextBox ID="txtEstOpinion" runat="server" Height="100%" Width="100%" TextMode="multiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: middle; width: 60px;">
                                                                                파일첨부
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="iBtnReviewFile" runat="server" ImageUrl="../images/icon/gr_po05.gif" />
                                                                                <asp:HiddenField ID="hdfReviewFile" runat="server" Value="" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="cssPopBtnLine" align="right" colspan="2">
                                                                    <asp:ImageButton ID="iBtnSaveOpnion" runat="server" ImageUrl="../images/btn/b_tp07.gif"
                                                                        OnClick="iBtnSaveOpnion_Click" />
                                                                    <asp:ImageButton ID="iBtnConfirmOpinion" runat="server" ImageUrl="../images/btn/b_015.gif"
                                                                        OnClick="iBtnConfirmOpinion_Click" />
                                                                    <asp:ImageButton ID="iBtnCancelOpinion" runat="server" ImageUrl="../images/btn/b_019.gif"
                                                                        OnClick="iBtnCancelOpinion_Click" />
                                                                    <asp:ImageButton ID="iBtnCloseEstForm" ImageUrl="../images/btn/b_003.gif" runat="server"
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
                                        <Style Width="1px" />
                                    </ig:TabSeparator>
                                    <ig:Tab Text="하위지표 실적" Key="4">
                                        <Style Width="200px" Height="23px" />
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                                                <tr style="height: 100%;">
                                                    <td>
                                                        <ig:UltraWebGrid ID="ugrdChildKpiResult" runat="server" Width="100%" Height="100%"
                                                            OnInitializeLayout="ugrdChildKpiResult_InitializeLayout" OnInitializeRow="ugrdChildKpiResult_InitializeRow">
                                                            <Bands>
                                                                <ig:UltraGridBand>
                                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                                    </AddNewRow>
                                                                    <Columns>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_CODE" EditorControlID="" FooterText="" Format=""
                                                                            HeaderText="KPI 코드" Key="KPI_CODE" Width="30px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 코드" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_NAME" EditorControlID="" FooterText="" Format=""
                                                                            HeaderText="KPI 명" Key="KPI_NAME" Width="150px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI 명" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_LEVEL" EditorControlID="" FooterText="" Format=""
                                                                            HeaderText="L" Key="KPI_LEVEL" Width="20px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="L" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UP_KPI_WEIGHT" EditorControlID="" FooterText=""
                                                                            AllowUpdate="No" Format="" HeaderText="가중치" Key="UP_KPI_WEIGHT" DataType="System.Double"
                                                                            NullText="0" Width="60px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="가중치" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="OP_DEPT_NAME" EditorControlID="" FooterText=""
                                                                            Format="" HeaderText="운영조직" Key="OP_DEPT_NAME" Width="100px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="운영조직" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="CHAMPION_EMP_NAME" HeaderText="KPI담당자" Key="CHAMPION_EMP_NAME"
                                                                            Width="50px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI담당자" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="UNIT_NAME" HeaderText="단위" Key="UNIT_NAME" Width="50px"
                                                                            AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="단위" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_INPUT_TYPE_NAME" EditorControlID="" Hidden="false"
                                                                            FooterText="" Format="" HeaderText="실적방식" Key="RESULT_INPUT_TYPE_NAME" Width="60px"
                                                                            AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="실적방식" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:TemplatedColumn BaseColumnName="APP_STATUS" Key="APP_STATUS" EditorControlID=""
                                                                            Width="30px" FooterText="" HeaderText="APP_STATUS">
                                                                            <Header Caption="결재상태" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <CellTemplate>
                                                                                <asp:Image runat="server" ID="imgApp" ImageAlign="AbsMiddle" ImageUrl="../images/icon_x.gif">
                                                                                </asp:Image>
                                                                            </CellTemplate>
                                                                        </ig:TemplatedColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_01" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="01월" Key="RESULT_MS_01"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="01월" />
                                                                            <CellStyle HorizontalAlign="Right" />
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_02" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="02월" Key="RESULT_MS_02"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="02월">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="11" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_03" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="03월" Key="RESULT_MS_03"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="03월">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="12" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_04" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="04월" Key="RESULT_MS_04"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="04월">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="13" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_05" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="05월" Key="RESULT_MS_05"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="05월">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="14" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_06" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="06월" Key="RESULT_MS_06"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="06월">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="15" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_07" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="07월" Key="RESULT_MS_07"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="07월">
                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="16" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_08" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="08월" Key="RESULT_MS_08"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="08월">
                                                                                <RowLayoutColumnInfo OriginX="17" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="17" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_09" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="09월" Key="RESULT_MS_09"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="09월">
                                                                                <RowLayoutColumnInfo OriginX="18" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="18" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_10" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="10월" Key="RESULT_MS_10"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="10월">
                                                                                <RowLayoutColumnInfo OriginX="19" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="19" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_11" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="11월" Key="RESULT_MS_11"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="11월">
                                                                                <RowLayoutColumnInfo OriginX="20" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="20" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_MS_12" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="12월" Key="RESULT_MS_12"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="12월">
                                                                                <RowLayoutColumnInfo OriginX="21" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="21" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_01" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="01월" Key="RESULT_TS_01"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="01월">
                                                                                <RowLayoutColumnInfo OriginX="22" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="22" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_02" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="02월" Key="RESULT_TS_02"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="02월">
                                                                                <RowLayoutColumnInfo OriginX="23" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="23" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_03" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="03월" Key="RESULT_TS_03"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="03월">
                                                                                <RowLayoutColumnInfo OriginX="24" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="24" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_04" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="04월" Key="RESULT_TS_04"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="04월">
                                                                                <RowLayoutColumnInfo OriginX="25" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="25" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_05" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="05월" Key="RESULT_TS_05"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="05월">
                                                                                <RowLayoutColumnInfo OriginX="26" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="26" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_06" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="06월" Key="RESULT_TS_06"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="06월">
                                                                                <RowLayoutColumnInfo OriginX="27" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="27" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_07" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="07월" Key="RESULT_TS_07"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="07월">
                                                                                <RowLayoutColumnInfo OriginX="28" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="28" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_08" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="08월" Key="RESULT_TS_08"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="08월">
                                                                                <RowLayoutColumnInfo OriginX="29" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="29" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_09" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="09월" Key="RESULT_TS_09"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="09월">
                                                                                <RowLayoutColumnInfo OriginX="30" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="30" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_10" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="10월" Key="RESULT_TS_10"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="10월">
                                                                                <RowLayoutColumnInfo OriginX="31" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="31" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_11" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="11월" Key="RESULT_TS_11"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="11월">
                                                                                <RowLayoutColumnInfo OriginX="32" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="32" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="RESULT_TS_12" EditorControlID="" DataType="System.Double"
                                                                            Format="#,###,###,###,###,###,##0.####" FooterText="" HeaderText="12월" Key="RESULT_TS_12"
                                                                            Width="80px" AllowUpdate="No">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="12월">
                                                                                <RowLayoutColumnInfo OriginX="33" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Right">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="33" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                            FooterText="" Format="" HeaderText="ESTTERM_REF_ID" Hidden="True" Key="ESTTERM_REF_ID">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="ESTTERM_REF_ID">
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                        <ig:UltraGridColumn BaseColumnName="KPI_REF_ID" DataType="System.Int32" EditorControlID=""
                                                                            NullText="0" FooterText="" Format="" HeaderText="KPI_REF_ID" Hidden="True" Key="KPI_REF_ID">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Header Caption="KPI_REF_ID">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Header>
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                            <Footer Caption="">
                                                                                <RowLayoutColumnInfo OriginX="1" />
                                                                            </Footer>
                                                                        </ig:UltraGridColumn>
                                                                    </Columns>
                                                                    <%--<RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                <BorderDetails WidthBottom="1px" WidthLeft="1px" WidthRight="1px" WidthTop="1px" />
                                            </RowTemplateStyle>--%>
                                                                </ig:UltraGridBand>
                                                            </Bands>
                                                            <DisplayLayout AllowColSizingDefault="Free" BorderCollapseDefault="Separate" HeaderClickActionDefault="NotSet"
                                                                Name="ugrdChildKpiTarget" RowHeightDefault="20px" CellClickActionDefault="RowSelect"
                                                                RowSelectorsDefault="No" Version="4.00" TableLayout="Fixed" AutoGenerateColumns="False">
                                                                <%--<GroupByBox>
                                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
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
                                            <HeaderStyleDefault BackColor="#94BAC9" BorderStyle="Solid" HorizontalAlign="Center" BorderColor="#E5E5E5" ForeColor="White" Height="23px">
                                                <BorderDetails  ColorLeft="238, 238, 238" ColorTop="199, 199, 199" />
                                            </HeaderStyleDefault>
                                            <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                            </EditCellStyleDefault>
                                            <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid"
                                                BorderWidth="0px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="100%" Width="100%">
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
                                            <ActivationObject BorderColor="" BorderWidth="">
                                            </ActivationObject>--%>
                                                                <RowStyleDefault CssClass="GridRowStyle" />
                                                                <SelectedRowStyleDefault CssClass="GridSelectedRowStyle">
                                                                </SelectedRowStyleDefault>
                                                                <RowAlternateStyleDefault CssClass="GridRowAlternateStyle">
                                                                </RowAlternateStyleDefault>
                                                                <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                                                                <HeaderStyleDefault CssClass="GridHeaderStyle">
                                                                </HeaderStyleDefault>
                                                                <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand">
                                                                </FrameStyle>
                                                            </DisplayLayout>
                                                        </ig:UltraWebGrid>
                                                    </td>
                                                </tr>
                                                <tr class="cssPopBtnLine">
                                                    <td align="right">
                                                        <asp:Literal ID="ltrAppLegend" runat="server" Text=""></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ig:Tab>
                                </Tabs>
                                <DefaultTabStyle BackColor="White" CssClass="cssTabStyleOff" />
                                <SelectedTabStyle CssClass="cssTabStyleOn" />
                                <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb2.gif"
                                    SelectedImage="../images/tab/ig_tab_blueb1.gif" />
                            </ig:UltraWebTab>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
