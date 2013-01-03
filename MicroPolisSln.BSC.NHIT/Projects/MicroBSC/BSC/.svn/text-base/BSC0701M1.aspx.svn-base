<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" ValidateRequest="false"
    CodeFile="BSC0701M1.aspx.cs" Inherits="BSC_BSC0701M1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템</title>
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript">
    function ViewEmp() 
    {
        var url             = "../BSC/BSC0702M1.aspx?ESTTERM_REF_ID=<%= this.IEstTermRefID %>";
        var receiver_arr    = document.getElementById("hdfReceiver").value;
        var emp_ref_id_arr  = '';
        
        if(receiver_arr != '')
        {
            var receiver_col = receiver_arr.split(';');
            var isFirst      = 1;
            
            for(i = 0; i < receiver_col.length; i++) 
            {
                if(isFirst == 1)
                {
                    isFirst = 0;
                }
                else 
                {
                    emp_ref_id_arr += ";";
                }
            
                emp_ref_id_arr += receiver_col[i].substring(0, receiver_col[i].indexOf('(')) 
            }
        
            url += '&iType=U&RECEIVER_ARR=' + emp_ref_id_arr;
        }
        else 
        {
            url += '&iType=A';
        }
        
        gfOpenWindow(url, 700, 450, false, false, 'Emp')
        
        return false;
    }
    
    function mfUpload(hAttachNo, sUpFlag)
    {
        <%
        /*
            Argument설명
                : ICM_FILE / ICM_PROCFILE 어느쪽에 셋팅하는가? (FILE / PROCFILE)
                : 파일첨부시 어떤 프로젝트 소속인가? 해당폴더및 ATTACHNO추출시 접두어로 사용됨 (ICM, DCM, ....)
        */
        %>
            var oAttach     = gfGetFindObj(hAttachNo);
            var oaArg       = new Array("FILE", "COMMNI", (oAttach==null ? "" : oAttach.value));
            
            var url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG="+sUpFlag;
            
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
    
    function ReloadParentForm()
    {
        opener.__doPostBack("<%=this.ICCB1%>");
        window.close();
    }
    
    function GoKPI(estterm_ref_id, kpi_ref_id, tmcode) 
    {
        opener.parent.location.href='usr3001_embed.aspx?ESTTERM_REF_ID='    + estterm_ref_id 
                                                + '&KPI_REF_ID='            + est_dept_ref_id 
                                                + '&TMCODE='                + tmcode;
                            
        window.close();
    }
    </script>

</head>
<body style="margin: 0,0,0,0;">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="vertical-align: top; height:100%;">
        <tr>
            <td style="height: 44px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 44px; background-image: url(../images/title/popup_t_bg.gif);"
                            valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 40px;" valign="top">
                                        <img src="../images/title/popup_t62.gif" alt="" />
                                    </td>
                                    <td align="right" valign="top">
                                        <img src="../images/title/popup_img.gif" alt="" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="height: 4px; width: 50%; background-color: #FFFFFF">
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
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" width="100%" style="height:100%;">
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>KPI명</b>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblKpiName" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        <b>평가기간</b>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblTMCode" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>작성자</b>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblWriterName" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        <b>조회수</b>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblReadCount" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>조직</b>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblDeptName" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="cssTblTitle">
                                        <b>작성일</b>
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:Label ID="lblCreateDate" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>제목</b>
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <asp:TextBox ID="txtSubject" runat="server" Height="20" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 100%;">
                                    <td class="cssTblTitle">
                                        <b>내용</b>
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" BasePath="../_common/FCKeditor/"
                                            Height="100%">
                                        </FCKeditorV2:FCKeditor>
                                        <div id="leftLayer" runat="server" style="border: #F4F4F4 1 solid; display: block;
                                            overflow: auto; width: 100%; height: 100%; padding-bottom: 0px; padding-left: 0px;
                                            padding-right: 0px; padding-top: 0px;">
                                            <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>첨부파일</b>
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <asp:ImageButton ID="iBtnDownload" runat="server" ImageUrl="../images/icon/icon_gr_po04.gif"
                                            OnClientClick="return mfUpload('hAttachNo','F');" />
                                        <asp:ImageButton ID="iBtnUpload" runat="server" ImageUrl="../images/icon/icon_gr_po05.gif"
                                            OnClientClick="return mfUpload('hAttachNo','T');" />
                                        <asp:HiddenField ID="hAttachNo" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>받는사람</b>
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtReceiver" runat="server" Height="54px" TextMode="MultiLine" Width="99%"
                                                        ReadOnly="true" BackColor="whitesmoke"></asp:TextBox>
                                                    <asp:HiddenField ID="hdfReceiver" runat="server" />
                                                </td>
                                                <td align="right" runat="server" id="tdAddEmp" style="width: 85px;">
                                                    <asp:ImageButton ID="iBtnFindEmp" runat="server" ImageUrl="~/images/btn/b_008.gif"
                                                        OnClientClick="return ViewEmp();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        <b>기타설정</b>
                                    </td>
                                    <td class="cssTblContent" colspan="3">
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td style="width: 50%;" align="left">
                                                    <asp:CheckBox ID="chkPublicYN" runat="server" Text="모든사람에게 글내용 공개" />
                                                </td>
                                                <td align="left" runat="server" id="td1">
                                                    <asp:CheckBox ID="chkMailSend" runat="server" Text="최초 저장시 수신자에게 메일보내기" />
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
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltrGoKPI" runat="server"></asp:Literal>
                                        <asp:ImageButton ID="iBtnSave" runat="server" Height="19px" ImageUrl="../images/btn/b_tp07.gif"
                                            OnClick="iBtnSave_Click" />
                                        <asp:ImageButton ID="iBtnModify" runat="server" Height="19px" ImageUrl="../images/btn/b_002.gif"
                                            OnClick="iBtnModify_Click" />
                                        <asp:ImageButton ID="iBtnFeedback" runat="server" Height="19px" ImageUrl="../images/btn/b_128.gif"
                                            OnClick="iBtnFeedback_Click" />
                                        <asp:ImageButton ID="iBtnDelete" runat="server" Height="19px" ImageUrl="../images/btn/b_004.gif"
                                            OnClick="iBtnDelete_Click" />
                                        <img alt="" src="../images/btn/b_003.gif" onclick="ReloadParentForm();" style="cursor: hand;" />
                                    </td>
                                    <td style="width: 5px;">
                                        &nbsp;
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
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
