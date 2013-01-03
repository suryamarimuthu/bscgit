<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2101.aspx.cs" Inherits="ctl_ctl2100_1" %>

<html>
<head id="Head1" runat="server">
    <title>BSC</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />

    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

    <script type="text/javascript" language="javascript" src="../_common/js/image_check.js"></script>

    <script type="text/javascript">
<!--



        // 창닫기
        function imgClose_onclick() {
            self.close();
        }


        function CallbackFun() {
            var loginId = document.forms[0].txtLoginID.value;
            Callback1.Callback(loginId);
        }
        function OpenEstDept() {
            var dept_Ctl1 = "<%= txtDeptName.ClientID%>";
            var dept_Ctl2 = "<%= txtDeptID.ClientID%>";
            var url = 'ctl2102.aspx?DeptNM=' + dept_Ctl1 + "&DeptID=" + dept_Ctl2;
            gfOpenWindow(url, 310, 400);
        }
        function PopUpCllFunction(deptId, deptName) {
            document.getElementById("<%= txtDeptID.ClientID%>").value = deptId;
            document.getElementById("<%= txtDeptName.ClientID%>").value = deptName;
        }
// -->
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF" onload="document.focus();">
    <form id="form1" enctype="multipart/form-data" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="40" valign="top">
                                        <img src="../images/title/popup_t23.gif">
                                    </td>
                                    <td align="right" valign="top">
                                        <img src="../images/title/popup_img.gif">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="50%" height="4" bgcolor="#FFFFFF">
                                    </td>
                                    <td width="50%" bgcolor="#FFFFFF">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopContent">
            <td valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table class="tableBorder" cellpadding="0" cellspacing="0" border="0" width="100%"
                                style="height: 100%;">
                                <tr>
                                    <td class="cssTblTitle">
                                        소속부서코드 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:HiddenField ID="hfPrevDeptID" runat="server" />
                                        <!-- 이전부서저장 -->
                                        <asp:TextBox ID="txtDeptID" runat="server" Width="50px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        소속부서명 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                                        <a href="#null" onclick="OpenEstDept();">
                                            <img src="../images/btn/b_033.gif" id="imgDeptSearch" border="0" align="middle" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        사용자아이디 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtLoginID" runat="server"></asp:TextBox>&nbsp;<a href="#null" onclick="CallbackFun()"><asp:Literal
                                            ID="ltrCheckLoginID" runat="server"></asp:Literal></a>
                                           
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        성명 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="trLoginID" runat="server" visible="false">
                                    <td class="cssTblTitle" style="width: 120px">
                                        로그인 IP
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtLoginIP" runat="server"></asp:TextBox>
                                        (2개 이상일 때 -&gt; 127.0.0.1,192.168.0.1)
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        직책 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlPositionDuty" runat="server" Width="200px" class="box01">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        직위 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlPositionRank" runat="server" Width="200px" class="box01">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        직군 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlPositionGrp" runat="server" Width="200px" class="box01">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        직급 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlPositionClass" runat="server" Width="200px" class="box01">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        직종 *
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:DropDownList ID="ddlPositionKind" runat="server" Width="200px" class="box01">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        이메일
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        전화번호
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtDaily" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        팩스번호
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        휴대폰번호
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtCell" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        우편번호
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtZipcode1" runat="server" Columns="6" MaxLength="3"></asp:TextBox>
                                        - &nbsp;<asp:TextBox ID="txtZipcode2" runat="server" Columns="6" MaxLength="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cssTblTitle">
                                        주소
                                    </td>
                                    <td class="cssTblContent">
                                        <asp:TextBox ID="txtAddr1" runat="server" Width="300px"></asp:TextBox><br />
                                        <asp:TextBox ID="txtAddr2" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                    
            <tr>
                <td   class="cssTblTitle" >
                    결재서명파일</td>
                <td class="cssTblContent">
                    <input id="fileSign" type="file" runat="server" size="40" /></td>
            </tr>
            <tr>
                <td   class="cssTblTitle" >
                    결재도장파일</td>
                <td class="cssTblContent">
                    <input id="fileStamp" type="file" runat="server" size="40" /></td>
            </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="40">
                            <asp:ImageButton ID="iBtnInitPasswd" runat="server" OnClick="iBtnInitPasswd_Click"
                                Height="19px" ImageUrl="~/images/btn/b_050.gif" />
                            <asp:ImageButton ID="iBtnSave" runat="server" OnClick="ibtnSave_Click" Height="19px"
                                ImageUrl="../images/btn/b_tp07.gif" />
                            <a href='#null' onclick="return imgClose_onclick()">
                                <img src="../images/btn/b_003.gif" border="0" id="imgClose" /></a> &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="4" bgcolor="#FFFFFF">
                        </td>
                        <td width="50%" bgcolor="#FFFFFF">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <SJ:CallBack ID="Callback1" runat="server" OnCallback="Callback1_Callback">
        <Content />
    </SJ:CallBack>
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <input type="hidden" name="imgWidth">
    <input type="hidden" name="imgHeight">
    </form>
</body>
</html>
