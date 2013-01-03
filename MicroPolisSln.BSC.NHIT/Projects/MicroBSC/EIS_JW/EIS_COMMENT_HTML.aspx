<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EIS_COMMENT_HTML.aspx.cs" Inherits="EIS_EIS_COMMENT_HTML" ValidateRequest="false" %>


<html>
    <head id="Head1" runat="server">
        <title>BSC</title>
        <meta http-equiv="Content-Type" content="text/html;" />
        <link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
        <script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>

        <script type="text/javascript">

        </script>
    </head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <!--- MAIN START --->	
        <table id="ctrlTblOuter" runat="server" style="width: 100%; height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 100%" valign="top">
                    <table style="width: 100%;height:100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <ig:WebHtmlEditor ID="txtContent" runat="server" Width="100%" 
                                    Height="100%" 
                                    FontFormattingList="Heading 1=&lt;h1&gt;&amp;Heading 2=&lt;h2&gt;&amp;Heading 3=&lt;h3&gt;&amp;Heading 4=&lt;h4&gt;&amp;Heading 5=&lt;h5&gt;&amp;Normal=&lt;p&gt;" 
                                    FontNameList="굴림,Arial,Verdana,Tahoma,Courier New,Georgia" 
                                    FontSizeList="1,2,3,4,5,6,7" 
                                    FontStyleList="Blue Underline=color:blue;text-decoration:underline;&amp;Red Bold=color:red;font-weight:bold;&amp;ALL CAPS=text-transform:uppercase;&amp;all lowercase=text-transform:lowercase;&amp;Reset=" 
                                    
                                    
                                    
                                    SpecialCharacterList="&amp;#937;,&amp;#931;,&amp;#916;,&amp;#934;,&amp;#915;,&amp;#936;,&amp;#928;,&amp;#920;,&amp;#926;,&amp;#923;,&amp;#958;,&amp;#956;,&amp;#951;,&amp;#966;,&amp;#969;,&amp;#949;,&amp;#952;,&amp;#948;,&amp;#950;,&amp;#968;,&amp;#946;,&amp;#960;,&amp;#963;,&amp;szlig;,&amp;thorn;,&amp;THORN;,&amp;#402,&amp;#1046;,&amp;#1064;,&amp;#1070;,&amp;#1071;,&amp;#1078;,&amp;#1092;,&amp;#1096;,&amp;#1102;,&amp;#1103;,&amp;#12362;,&amp;#12354;,&amp;#32117;,&amp;AElig;,&amp;Aring;,&amp;Ccedil;,&amp;ETH;,&amp;Ntilde;,&amp;Ouml;,&amp;aelig;,&amp;aring;,&amp;atilde;,&amp;ccedil;,&amp;eth;,&amp;euml;,&amp;ntilde;,&amp;cent;,&amp;pound;,&amp;curren;,&amp;yen;,&amp;#8470;,&amp;#153;,&amp;copy;,&amp;reg;,&amp;#151;,@,&amp;#149;,&amp;iexcl;,&amp;#14;,&amp;#8592;,&amp;#8593;,&amp;#8594;,&amp;#8595;,&amp;#8596;,&amp;#8597;,&amp;#8598;,&amp;#8599;,&amp;#8600;,&amp;#8601;,&amp;#18;,&amp;brvbar;,&amp;sect;,&amp;uml;,&amp;ordf;,&amp;not;,&amp;macr;,&amp;para;,&amp;deg;,&amp;plusmn;,&amp;laquo;,&amp;raquo;,&amp;middot;,&amp;cedil;,&amp;ordm;,&amp;sup1;,&amp;sup2;,&amp;sup3;,&amp;frac14;,&amp;frac12;,&amp;frac34;,&amp;iquest;,&amp;times;,&amp;divide;" 
                                    ImageDirectory="/_common/infragistics/htmleditor/" 
                                    UploadedFilesDirectory="/_common/upload">
                                    <RightClickMenu>
                                        <ig:HtmlBoxMenuItem runat="server" Act="Cut"></ig:HtmlBoxMenuItem>
                                        <ig:HtmlBoxMenuItem runat="server" Act="Copy"></ig:HtmlBoxMenuItem>
                                        <ig:HtmlBoxMenuItem runat="server" Act="Paste"></ig:HtmlBoxMenuItem>
                                        <ig:HtmlBoxMenuItem runat="server" Act="PasteHtml"></ig:HtmlBoxMenuItem>
                                        <ig:HtmlBoxMenuItem runat="server" Act="CellProperties">
                                            <Dialog InternalDialogType="CellProperties"></Dialog>
                                        </ig:HtmlBoxMenuItem>
                                        <ig:HtmlBoxMenuItem runat="server" Act="TableProperties">
                                            <Dialog InternalDialogType="ModifyTable"></Dialog>
                                        </ig:HtmlBoxMenuItem>
                                        <ig:HtmlBoxMenuItem runat="server" Act="InsertImage"></ig:HtmlBoxMenuItem>
                                    </RightClickMenu>

                                    <Toolbar>
                                        <ig:ToolbarImage runat="server" Type="DoubleSeparator"></ig:ToolbarImage>
                                        <ig:ToolbarButton runat="server" Type="Bold"></ig:ToolbarButton>
                                        
                                        <ig:ToolbarButton runat="server" Type="Underline"></ig:ToolbarButton>
                                        <ig:ToolbarImage runat="server" Type="Separator"></ig:ToolbarImage>
                                        <ig:ToolbarButton runat="server" Type="JustifyLeft"></ig:ToolbarButton>
                                        <ig:ToolbarButton runat="server" Type="JustifyCenter"></ig:ToolbarButton>
                                        <ig:ToolbarButton runat="server" Type="JustifyRight"></ig:ToolbarButton>
                                        <ig:ToolbarButton runat="server" Type="JustifyFull"></ig:ToolbarButton>
                                        
                                        <ig:ToolbarImage runat="server" Type="DoubleSeparator"></ig:ToolbarImage>
                                        <ig:ToolbarDialogButton runat="server" Type="FontColor"></ig:ToolbarDialogButton>
                                        <ig:ToolbarDialogButton runat="server" Type="FontHighlight"></ig:ToolbarDialogButton>
                                        
                                        <ig:ToolbarMenuButton runat="server" Type="InsertTable">
                                        <Menu>
                                            <ig:HtmlBoxMenuItem runat="server" Act="TableProperties">
                                                <Dialog InternalDialogType="InsertTable"></Dialog>
                                            </ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="InsertColumnRight"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="InsertColumnLeft"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="InsertRowAbove"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="InsertRowBelow"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="DeleteRow"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="DeleteColumn"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="IncreaseColspan"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="DecreaseColspan"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="IncreaseRowspan"></ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="DecreaseRowspan"></ig:HtmlBoxMenuItem>
                                            
                                            <ig:HtmlBoxMenuItem runat="server" Act="CellProperties">
                                                <Dialog InternalDialogType="CellProperties"></Dialog>
                                            </ig:HtmlBoxMenuItem>
                                            <ig:HtmlBoxMenuItem runat="server" Act="TableProperties">
                                            <Dialog InternalDialogType="ModifyTable"></Dialog>
                                            </ig:HtmlBoxMenuItem>
                                        </Menu>
                                        </ig:ToolbarMenuButton>
                                        <ig:ToolbarButton runat="server" Type="ToggleBorders"></ig:ToolbarButton>
                                        <ig:ToolbarImage runat="server" Type="Separator"></ig:ToolbarImage>
                                        <ig:ToolbarButton runat="server" Type="Preview"></ig:ToolbarButton>
                                        <ig:ToolbarImage runat="server" Type="Separator"></ig:ToolbarImage>
                                        
                                        <ig:ToolbarImage runat="server" Type="DoubleSeparator"></ig:ToolbarImage>
                                        <ig:ToolbarDropDown runat="server" Type="FontSize"></ig:ToolbarDropDown>
                                    </Toolbar>
                                </ig:WebHtmlEditor>
                            </td>
                            
                        </tr>
                        <tr height="35px" align="right" runat="server" id="tr01">
                            <td>
                                <asp:ImageButton ID="ibnEdit" runat="server" ImageUrl="~/images/btn/b_002.gif" onclick="ibnEdit_Click" CommandName="EIS_SAVE_COMMENT" Visible="false" />
                                <asp:ImageButton ID="ibnSave" runat="server" ImageUrl="~/images/btn/b_tp07.gif" onclick="ibnSave_Click" Visible="false" />
                                <asp:ImageButton ID="ibnCancel" runat="server" ImageUrl="~/images/btn/b_044.gif" onclick="ibnCancel_Click" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
        <asp:literal id="ltrScript" runat="server"></asp:literal>     
        <!--- MAIN END --->
    </form>
</body>
</html>
