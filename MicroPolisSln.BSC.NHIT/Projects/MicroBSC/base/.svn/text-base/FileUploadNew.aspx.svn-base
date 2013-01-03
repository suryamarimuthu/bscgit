<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadNew.aspx.cs" Inherits="base_FileUploadNew" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::BSC::</title>
    <link href="../_Common/css/bsc.css" rel="stylesheet" type="text/css" />

    <script src="/_common/js/jQuery/jquery-1.6.4.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $("#btnAdd").click(function() {
                var img = "<input type=\"file\" name=\"files\" style=\"width:100%;\" />";
                $("#divFile").append(img);
            });
        });
        //function
        var Page = {
            Validate: function() {
                var files = $("[name='files']");
                for (var i = 0; i < files.length; i++) {
                    var full = files[i].value;
                    if (full != "") {
                        var arrFull = full.split('\\');
                        var filename = arrFull[arrFull.length - 1];
                        var arrExtension = filename.split('.');
                        var extension = arrExtension[arrExtension.length - 1];
                        if (extension == "gul" || extension == "hwp" || extension == "jpg" ||
                       extension == "bmp" || extension == "gif" || extension == "png" ||
                       extension == "tif" || extension == "xls" || extension == "xlsx" ||
                       extension == "ppt" || extension == "pptx" || extension == "doc" ||
                       extension == "docx" || extension == "pdf" || extension == "zip" ||
                       extension == "txt" ) {
                            return;
                        }
                        else {
                            alert("업로드 되지않는 파일 입니다.");
                            return false;
                        }
                    }
                }
            }
        }   
    </script>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF; height:100%;">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
        <tr>
            <td style="vertical-align: top;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style=" height: 40px;">
                        <%--<td style="width: 170px; height: 40px; background-image: url(../images/title/popup_title.gif);" class="cssPopTitleArea">
                            <span class="cssPopTitleTxt" style="padding-left: 20px;">파일업로드</span>
                        </td>
                        <td style="width: 140px; height: 40px; background-image: url(../images/title/popup_img.gif);
                            vertical-align: middle;">
                        </td>--%>
                        
                        <td style="background-image:url(../images/title/popup_title.gif);" class="cssPopTitleArea">
                            <asp:Label ID="Label2" runat="server" CssClass="cssPopTitleTxt" Text="파일업로드"></asp:Label>
                        </td>
                        <td align="right" valign="top" style="width:221px;"><img alt="" src="../images/title/popup_img.gif" /></td>
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
        <tr>
            <td style="vertical-align: top">
                <table cellpadding="0" cellspacing="1" border="0" style="width: 100%;">
                    <%--<tr>
                        <td style="text-align: right;">
                            <img src="/Images/btn/b_005.gif" style="cursor: pointer;" id="btnAdd" alt="추가" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <div id="divFile">
                                <input type="file" name="files" style="width: 100%;" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 16px; background-image: url(../images/etc/pop_ti03.gif); vertical-align:middle; line-height:16px; padding-left:5px;">
                첨부 가능 용량 :
                <asp:Label ID="lblEnableAttKbyte" runat="server" Text="0"></asp:Label>
                KB
            </td>
        </tr>
        <tr style="height:100%;">
            <td bgcolor="#F2F2F2" bordercolordark="#6D6D6D" bordercolorlight="#C0C0C0">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:100%;">
                    <tr style="height:100%;">
                        <td>
                            <asp:ListBox ID="lbFileList" runat="server" Height="164px" Width="100%"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            상태:<asp:Label runat="server" ID="lblStatus" Text="-"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton runat="server" ID="btnSave" ImageUrl="/images/btn/b_001.gif" OnClick="btnSave_Click"
                    OnClientClick="return Page.Validate();" />
                <asp:ImageButton runat="server" ID="btnDel" ImageUrl="/images/btn/b_004.gif" OnClick="btnDel_Click" />
                <asp:ImageButton runat="server" ID="btnDown" ImageUrl="/images/btn/b_041.gif" OnClick="btnDown_Click" />
                <img src="/images/btn/b_044.gif" alt="취소" style="cursor: pointer;" onclick="window.close();" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hSaveFiles" runat="server" />
    <asp:HiddenField ID="hSaveAttachNo" runat="server" />
    <asp:HiddenField ID="hChangeFlag" runat="server" />
    <asp:HiddenField ID="hArgArray" runat="server" />
    </form>
</body>
</html>
