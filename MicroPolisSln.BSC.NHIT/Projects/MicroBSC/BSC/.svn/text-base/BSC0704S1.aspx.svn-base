<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="BSC0704S1.aspx.cs" Inherits="BSC_BSC0704S1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>::공지사항::</title>
</head>
<body style="margin:0,0,0,0;">
    <form id="form1" runat="server">
      <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%; vertical-align:top; background-image:url(../images/etc/pop_ti_bg02.gif);" >
        <tr>
          <td align="center">
              <table border="0" cellpadding="0" cellspacing="0" style="width:98%; height:100%; vertical-align:top; background-image:url(../images/etc/pop_ti_bg02.gif);" >
                <tr> 
                    <td style="height:9%;"> 
                        <!-- 타이틀시작 -->
                        <table width="100%" style="height:25px; background-image:url(../images/etc/pop_ti_bg01.gif);" border="0" cellpadding="0" cellspacing="0">
                            <tr> 
                                <td style="width:63px;"><img src="../images/etc/pop_ti01.gif" alt="" /></td>
                                <td><font color="white"><asp:Label ID="lblTitle" runat="server" Width="100%" Text=" "></asp:Label></font></td>
                                <td style="width:102px;"><img src="../images/etc/pop_ti02.gif" onclick="self.close();" style="cursor:hand;" alt="" /></td>
                            </tr>
                        </table>
                        <!-- 타이틀끝 -->
                    </td>
                </tr>
                <tr style="height:86%;">
                  <td valign="top" style="background-color:White;" class="box_td03">
                    <table border="1" cellpadding="0" cellspacing="0" style="width:100%; height:100%; border-style:inset;">
                      <tr>
                        <td>
                            <div id="leftLayer" runat="server" style="border:#F4F4F4 2 solid; DISPLAY:block; overflow:auto; background-color:White;
                                width: 100%;  height: 100%; padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px; ">
                                 <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                            </div>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>          
          </td>
        </tr>
        <tr>
          <td style="height:5%;" align="right">
            &nbsp;<asp:CheckBox ID="chkToDay" runat="server" AutoPostBack="true" Text="오늘은 한번만 보기" OnCheckedChanged="chkToDay_CheckedChanged" />
          </td>
        </tr>
      </table>
      <asp:Literal ID="ltrScript" runat="server" ></asp:Literal>
    </form>
</body>
</html>
