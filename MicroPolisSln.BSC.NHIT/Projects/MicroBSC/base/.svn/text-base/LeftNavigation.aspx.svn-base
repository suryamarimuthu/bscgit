<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftNavigation.aspx.cs" Inherits="base_LeftNavigation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BSC</title>  
    <meta http-equiv="Content-Type" content="text/html; " />
    <script type="text/javascript" src="/_common/js/common.js"></script>
    <script type="text/javascript" src="/_common/js/picker.js"></script>
    <script src="/_common/js/Navigation.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/_common/css/bsc.css" type="text/css" />
    <link rel="stylesheet" href="/_common/css/treeStyle.css" type="text/css" />
    <link href="/_common/css/navigation.css" rel="stylesheet" type="text/css" />
</head>
<body style=" margin:0;background-color:#FFFFFF;">
    <form id="form1" runat="server">    
    <table cellpadding="0" cellspacing="0" border="0" style=" width:100%; height:100%;">
        <tr>
            <td>
                <table class="MainMenu" id="Table1" cellspacing="0" cellpadding="0">
                    <tr class="MainMenuGripper">
                        <td class="MainMenuGripper">
                            <table id="dotdot" style="height:29px;background-image: url(/images/navigation/onyxBar.gif);" cellspacing="0" cellpadding="0" border="0" >
                                <tr>
                                    <td>
                                        <img alt=" " src="/images/navigation/move.gif" /></td>
                                    <td id="theMainMenuText" class="Text">
                                        <!--<span>&nbsp;Search</span>-->
                                    </td>
                                    <td id="Mainbg" style="background-image: url(/images/navigation/onyxBar.gif)" align="right">
                                        <img alt="Click to Close" id="theDockPanelImage" onclick="toggleDockPanel();" src="/images/navigation/pushPin.gif" />
                                    </td>
                                    <td style="background-image:url(/images/navigation/onyxbar_right_round.gif); width:4px;overflow:hidden; ">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 100%; width: 100%">
                        <td style="width: 100%; height: 100%">
                            <ig:ultraweblistbar id="wb" runat="server" backcolor="White" font-size="11pt"
                                font-names="Tahoma" bordercolor="#CCCCCC" itemselectionstyle="IconOnlySelection"
                                mergestyles="True" borderstyle="Solid" height="100%" width="100%" barwidth="100%"
                                borderwidth="1px">
                                <defaultgroupstyle cursor="Default" height="100%"></defaultgroupstyle>
                                <defaultitemstyle cursor="Default" font-size="8pt" font-names="Verdana" backcolor="White">
						                    <Padding Left="5px"></Padding><Margin Bottom="2px"></Margin>
				                </defaultitemstyle>
                                <defaultitemhoverstyle borderwidth="1px" borderstyle="None" forecolor="Black" backcolor="#DDDDDD">
						                    <Margin Left="0px"></Margin> <Margin Bottom="2px"></Margin>
				                 </defaultitemhoverstyle>
                                <clientsideevents initializelistbar="wb_InitializeListbar"></clientsideevents>
                                <defaultgroupbuttonselectedstyle cursor="Default" font-names="Lucida Sans" font-bold="True"
                                    forecolor="White" backgroundimage="/images/navigation/royaleBar.gif">
				                <BorderDetails ColorTop="White" WidthLeft="0px" ColorBottom="White" WidthTop="0px" ColorRight="#6B6B6B" WidthRight="1px" WidthBottom="0px"></BorderDetails>
				                </defaultgroupbuttonselectedstyle>
                                <groups>
				                    <ig:Group TextAlign="Left" Text="Group">
					                    <GroupStyle Height="800px" BorderColor="#396799" BorderStyle="None" BackColor="#396799"></GroupStyle>
				                    </ig:Group>
				                </groups>
                                <defaultitemselectedstyle cursor="Default" borderwidth="1px" backcolor="#DEE6F3">
						                    <Margin Left="0px"></Margin>
				                </defaultitemselectedstyle>
                                <defaultgroupbuttonstyle cursor="Default" height="30px" borderwidth="5px" font-size="9pt"
                                    font-names="Lucida Sans" font-bold="True" borderstyle="Solid" forecolor="#3E6E03"
                                    backgroundimage="/images/navigation/greyBar.gif">
						                    <Padding Bottom="2px" Left="20px" Top="2px" Right="2px"></Padding>
						                    <BorderDetails ColorTop="White" WidthLeft="0px" ColorBottom="White" WidthTop="0px" ColorRight="#EBE9ED" WidthRight="1px" WidthBottom="0px"></BorderDetails>
				                </defaultgroupbuttonstyle>
                                <defaultgroupbuttonhoverstyle cursor="Hand" borderstyle="Solid" backgroundimage="/images/navigation/greenBar_Hover.gif"
                                    backcolor="white"></defaultgroupbuttonhoverstyle>
                            </ig:ultraweblistbar>
                        </td>
                    </tr>
               </table>            
            </td>        
        </tr>
    </table>
    </form>
</body>
</html>
