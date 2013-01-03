<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintView.aspx.cs" Inherits="PrintView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=Request["header_title"] %></title>
    <link href="../_common/css/bsc.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../_Common/js/Common.js"></script>
    <script type="text/javascript">
    function printWindow() 
    {
        var f = document.form1;
        //f.factory.printing.header = '<%=Request["header_title"] %>';
        f.factory.printing.header = 'MicroBSC::성과관리 시스템 : 프린트 출력'
        f.factory.printing.footer = '';
        f.factory.printing.portrait = true; // false - landscape
        f.factory.printing.leftMargin = 1.0;
        f.factory.printing.topMargin = 1.0;
        f.factory.printing.rightMargin = 1.0;
        f.factory.printing.bottomMargin = 1.0;
        f.factory.printing.Print(true);
    }
    function printPage() 
    {
        try
        {
            document.all.content.innerHTML = opener.content.innerHTML;
        }
        catch(e)
        {
            document.all.content.innerHTML = document.all.hidden_content.innerHTML;
        }
        
        printWindow();
    }
    </script>
</head>
<body style="margin:0;">
    <form id="form1" runat="server">
    <script src="PrintObject.js"></script>
    <div id="content"></div>
    <div id="hidden_content" style="display:none;">
        프린트 페이지 오류 발생
    </div>
    <script type="text/javascript">printPage();</script>
    <!--<input type="button" value="프린트" onclick="printPage();" />-->
    </form>
</body>
</html>
