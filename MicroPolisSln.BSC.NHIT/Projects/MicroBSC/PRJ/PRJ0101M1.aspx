<%@ Page Language="C#"  CodeFile="PRJ0101M1.aspx.cs" Inherits="PRJ_PRJ0101M1"  enableEventValidation="false" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>사업관리입력</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
    <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
    
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
  <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height:40px;">
      <tr>
       <td style="height: 40px" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td>
                   <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td  valign="top" background="../images/title/popup_t_bg.gif"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr> 
                                    <td valign="top"><img alt="" src="../images/title/popup_t79.gif" width="269" height="40"></td>
                                    <td align="right" valign="top"><img alt="" src="../images/title/popup_img.gif"></td>
                                </tr>
                            </table>
                        </td>
                      </tr>
                     </table>
                </td>
              </tr>
            </table>
       </td>
      </tr>
   </table>
   <table cellpadding="2" cellspacing="0" border="0" width="100%"> 
    <tr>
        <td><img alt="" src="../images/blank.gif" width="0" height="7px" /></td>
    </tr>
   </table>
   <table border="0" cellspacing="0" cellpadding="0" style="width:100%; height:610px; padding-left:2px;">
        <tr class="cssPopContent"> 
            <td valign="top" style="height:600px;">
              <ig:UltraWebTab runat="server" ID="ugrdKpiStatusTab" Height="100%" ThreeDEffect="False" Width="100%" AutoPostBack="True" OnTabClick="ugrdKpiStatusTab_TabClick">
                  <Tabs>
                        <ig:Tab Text="PartⅠ 기본정보" Key="1">
                        <Style Width="160px" Height="25px" ForeColor="Navy" Font-Bold="True" />
                          <ContentTemplate>
                       <iframe runat="server" width="100%" height="100%" frameborder="no" id="ifmContent1"></iframe>
                          </ContentTemplate>
                      </ig:Tab>
                      <ig:TabSeparator>
                        <Style Width="1px"></Style>
                      </ig:TabSeparator>
                      <ig:Tab Text="PartⅡ 일정관리" Key="2" >
                        <Style Width="160px"  Height="25px" ForeColor="Navy" Font-Bold="True" />
                          <ContentTemplate>
                           <iframe runat="server" width="100%" height="100%" frameborder="no" id="ifmContent2"></iframe>
                          </ContentTemplate>
                      </ig:Tab>
                      <ig:TabSeparator>
                        <Style Width="1px"></Style>
                      </ig:TabSeparator>
                      <ig:Tab Text="PartⅢ 비용관리" Key="3">
                        <Style Width="160px"  Height="25px" ForeColor="Navy" Font-Bold="True" />
                          <ContentTemplate>
                         <iframe runat="server" width="100%" height="100%" frameborder="no" scrolling="no" id="ifmContent3"></iframe>      
                          </ContentTemplate>
                      </ig:Tab>
                      <ig:TabSeparator>
                        <Style Width="1px"></Style>
                      </ig:TabSeparator>
                      <ig:Tab Text="Part Ⅳ 관련지표" Key="4">
                        <Style Width="160px"  Height="25px" ForeColor="Navy" Font-Bold="True" />
                        <ContentTemplate>
                         <iframe runat="server" width="100%" height="100%" frameborder="no" scrolling="no" id="ifmContent4"></iframe>
                        </ContentTemplate>
                        
                      </ig:Tab>
                      <ig:TabSeparator>
                        <Style Width="1px"></Style>
                      </ig:TabSeparator>
                  </Tabs>
                  <DefaultTabStyle BackColor="White" Height="20px" CssClass="cssTabStyleOff">
                  </DefaultTabStyle>
                  <SelectedTabStyle CssClass="cssTabStyleOn" />
                  <RoundedImage FillStyle="LeftMergedWithCenter" NormalImage="../images/tab/ig_tab_blueb1.gif" SelectedImage="../images/tab/ig_tab_blueb2.gif" />
              </ig:UltraWebTab>
            </td>
        </tr>
        
   </table>
   <asp:Literal ID="ltrScript" Text="" runat="server"></asp:Literal>
  </form>
</body>
</html>
