<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BSC0505M1.aspx.cs" Inherits="BSC_BSC0505M1"
    ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC::성과관리 시스템::KPI 수정</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript" language="javascript">  
<!--    
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
            var oAttach     = gfGetFindObj(hAttachNo);
            var oaArg       = new Array("FILE", "REPORT", (oAttach==null ? "" : oAttach.value));
            var isAdmin     = "<%= this.IisAdmin %>"
            var confirmFlag = "F";
            
            if (isAdmin == 'Y')
            {
                confirmFlag = 'T';
            }
            
            var url = "../base/FileUploadMain.aspx?DOWN_FLAG=T&UP_FLAG="+confirmFlag;
            
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
       
//-->  
    </script>

</head>
<body style="margin: 0,0,0,0;">
    <form id="form1" runat="server" style="margin-top: 0px; margin-left: 0px">
    <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: top; width: 100%;
        height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-image:url(../images/title/popup_t_bg.gif);">
                        <td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);"
                            class="cssPopTitleArea">
                            <asp:Label ID="lblPopUpTitle" runat="server" Text="종합분석" CssClass="cssPopTitleTxt"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td align="right">
                            <img alt="" src="../images/title/popup_img.gif" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
                        </td>
                        <td style="width: 50%; height: 4px; background-color: #FFFFFF">
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
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlWrite" runat="server" ScrollBars="Auto" Width="100%" Height="100%">
                                            <FCKeditorV2:FCKeditor ID="txtTotalOpinion" runat="server" BasePath="../_common/FCKeditor/"
                                                Height="100%" Width="100%" >
                                            </FCKeditorV2:FCKeditor>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlRead" runat="server" ScrollBars="Auto" Width="100%" Height="100%"
                                            BorderWidth="1px" BorderColor="DarkGray">
                                            <asp:Literal ID="ltrTotalOpinion" runat="server"></asp:Literal>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="cssPopBtnLine">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="padding-right: 5px; vertical-align: middle; text-align: right; width: 100px;">
                                        첨부파일
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:ImageButton ID="iBtnReportFile" runat="server" ImageUrl="../images/icon/gr_po05.gif"
                                            OnClientClick="return mfUpload('hdfReportFile');" />
                                        <asp:HiddenField ID="hdfReportFile" runat="server" Value="" />
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:ImageButton ID="iBtnInsert" ImageUrl="../images/btn/b_001.gif" runat="server"
                                            OnClick="iBtnInsert_Click" />
                                        <asp:ImageButton ID="iBtnUpdate" ImageUrl="../images/btn/b_002.gif" runat="server"
                                            OnClick="iBtnUpdate_Click" />
                                        <img alt="" src="../images/btn/b_003.gif" style="cursor: hand;" onclick="self.close();" />
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
                        <td style="width:50%; height:4px; background-color:#FFFFFF"></td>
                        <td style="width:50%; background-color:#FFFFFF"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
    </form>
</body>
</html>
