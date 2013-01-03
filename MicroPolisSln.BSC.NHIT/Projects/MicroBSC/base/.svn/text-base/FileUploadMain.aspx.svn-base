<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadMain.aspx.cs" Inherits="base_FileUploadMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>첨부파일관리</title>
    <link href="../_Common/css/bsc.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../_Common/js/Common.js"></script>
    
    <script type="text/javascript">
        function mfReturnValue(psReturn)
        {
            window.returnValue = psReturn;
        }
        
        function mfXClose()
        {
            var objSaveAttachNo = gfGetFindObj("hSaveAttachNo");
            var objFileList     = gfGetFindObj("lbFileList");
            var objChgFlag      = gfGetFindObj("hChangeFlag");
            
            mfReturnValue(objSaveAttachNo.value + ";" + objFileList.length + ";" + objChgFlag.value);
        }
    </script>
</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px; height:100%;" onbeforeunload="mfXClose();">

<table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:100%;">
    <tr>
        <td>
            <iframe id='ifrFileUpload' runat="server" frameborder="no" scrolling="yes" style="width:100%; height:307px;"></iframe>
        </td>
    </tr>
</table>
        <%--<div>
            <iframe id='ifrFileUpload' runat="server" frameborder="no" scrolling="yes" style="width:100%;height:100%"></iframe>
        </div>--%>

    <script type="text/javascript">
        var i;
        var argArray    = window.dialogArguments;
        var oargArray   = gfGetFindObj("hArgArray");
        var sArgs       = "";
        
        for (i=0; i<(argArray.length - 1); i++)
        {
            sArgs += argArray[i] + ";";
        }
        sArgs += argArray[i];
       
        
        var ifr = gfGetFindObj("ifrFileUpload");
        //ifr.src = "FileUpload.aspx?TBLINFO=" + argArray[0] + "&SAVEINFO=" + argArray[1] + "&ATTACHNO=" + argArray[2];
        ifr.src = "FileUploadNew.aspx?ARGS=" + sArgs + "&UP_FLAG=" + Request.QueryString("UP_FLAG") + "&DOWN_FLAG=" + Request.QueryString("DOWN_FLAG")+"&SIZE="+Request.QueryString("SIZE");
    </script>
</body>
</html>
