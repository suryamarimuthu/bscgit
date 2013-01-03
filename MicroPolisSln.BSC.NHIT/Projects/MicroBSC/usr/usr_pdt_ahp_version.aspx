<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_pdt_ahp_version.aspx.cs" Inherits="usr_pdt_ahp_version" %>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript">
    
    function nodeMove(sourceNode, targetNode)
    {
//        var doMove = false;
//      
//        if (document.getElementById('chkConfirm').checked)
//        {
//            if(targetNode)
//                doMove = confirm("Move '" + sourceNode.Text + "' to '" + targetNode.Text + "'?"); 
//            else
//                doMove = confirm("Move '" + sourceNode.Text + "' into a root position?"); 
//        } 
//        else
//            doMove = true; 

//        if (sourceNode.Text == "Droppable into Tasks Only" && (targetNode == null || targetNode.Text != 'Tasks'))
//        {
//            document.getElementById('lblFeedback').innerText = "Can only move into Tasks";
//            return false; 
//        }

//        if (sourceNode.Text == "Droppable into Inbox Only" && (targetNode == null || targetNode.Text != "Inbox")) 
//        {
//            document.getElementById('lblFeedback').innerText = "Can only move into Inbox";
//            return false; 
//        }
//      
//        if (doMove) 
//        {
//            if(targetNode)
//                document.getElementById('lblFeedback').innerText = "Moved '" + sourceNode.Text + "' into '" +         targetNode.Text + "'";
//            else
//                document.getElementById('lblFeedback').innerText = "Moved '" + sourceNode.Text + "' into root position";      
//            return true; 
//        }

        return true;
    }
    </script>

    <form id="form2" runat="server">
    <div>
<%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
<!--- MAIN START --->

    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td height="40" valign="top" background="../images/title/popup_t_bg.gif"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr> 
                                    <td height="40" valign="top"><img src="../images/title/popup_t63.gif"/></td>
                                    <td align="right" valign="top"><img src="../images/title/popup_img.gif"/></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr> 
                                    <td width="50%" height="4" bgcolor="FFC600"></td>
                                    <td width="50%" bgcolor="00549C"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
        </td>
      </tr>
    </table>
    <br />--%>
    <table width="100%" cellpadding="0" cellspacing="0" class="tableBorder">
        <tr>
            <td width="20%" class="tableTitle" align="right">평가기간 :&nbsp;</td>
            <td class="tableContent">
                &nbsp;<asp:DropDownList ID="ddlEstTermInfo" runat="server" Width="125px" OnSelectedIndexChanged="ddlEstTermInfo_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>
            </td> 
            <td width="20%" class="tableTitle" align="right">버젼 :&nbsp;</td>
            <td class="tableContent">
                &nbsp;<asp:DropDownList ID="ddlStgVersion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStgVersion_SelectedIndexChanged" CssClass="box01"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="20%" class="tableTitle" align="right">전략 버젼명 :&nbsp;</td>
            <td class="tableContent">
                &nbsp;<asp:TextBox ID="txtStgName" runat="server" Width="200px"></asp:TextBox>
            </td> 
            <td width="20%" class="tableTitle" align="right">전략 버젼 설명 :&nbsp;</td>
            <td class="tableContent">
                &nbsp;<asp:TextBox ID="txtStgDesc" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right" height="50px">
                <asp:ImageButton
                    ID="iBtnSave" runat="server" ImageUrl="~/images/btn/b_tp07.gif" OnClick="iBtnSave_Click" />
                <asp:ImageButton ID="iBtnRemove" runat="server" ImageUrl="~/images/btn/b_004.gif"
                    OnClick="iBtnRemove_Click" />&nbsp;<asp:HiddenField ID="hdfStatus" runat="server" />
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0"  class="tableBorder">
        <tr height="25">
            <td width="50%" align="center" class="tableTitle">전략리스트
            </td>
            <td  align="center" class="tableTitle">선택된 평가기간, 버젼 전략 관계
            </td>
        </tr>
        <tr>
            <td valign="top">
                <SJ:TreeView id="TreeView1" Height="300px" Width="400px" 
                      DragAndDropEnabled="true" 
                      NodeEditingEnabled="false"
                      KeyboardEnabled="false"
                      CssClass="TreeView" 
                      NodeCssClass="TreeNode" 
                      SelectedNodeCssClass="SelectedTreeNode" 
                      HoverNodeCssClass="HoverTreeNode"
                      NodeEditCssClass="NodeEdit"
                      LineImageWidth="19" 
                      LineImageHeight="20"
                      DefaultImageWidth="16" 
                      DefaultImageHeight="16"
                      ItemSpacing="0" 
                      NodeLabelPadding="0"
                      ParentNodeImageUrl="../images/tree/folders.gif" 
                      LeafNodeImageUrl="../images/tree/folder.gif" 
                      ShowLines="true" 
                      LineImagesFolderUrl="../images/lines"
                      EnableViewState="true"
                      ClientSideOnNodeMove="nodeMove"
                      runat="server" DragAndDropAcrossTreesEnabled="True" />
                      <SJ:SmartScroller ID="SmartScroller1" runat="server" TargetObject = "TreeView1_div">
                    </SJ:SmartScroller>
                      </td>
            <td valign="top" align="right">
                <SJ:TreeView id="TreeView2" Height="300px" Width="400px" 
                      DragAndDropEnabled="true" 
                      NodeEditingEnabled="false"
                      KeyboardEnabled="false"
                      CssClass="TreeView" 
                      NodeCssClass="TreeNode" 
                      SelectedNodeCssClass="SelectedTreeNode" 
                      HoverNodeCssClass="HoverTreeNode"
                      NodeEditCssClass="NodeEdit"
                      LineImageWidth="19" 
                      LineImageHeight="20"
                      DefaultImageWidth="16" 
                      DefaultImageHeight="16"
                      ItemSpacing="0" 
                      NodeLabelPadding="0"
                      ParentNodeImageUrl="../images/tree/folders.gif" 
                      LeafNodeImageUrl="../images/tree/folder.gif" 
                      ShowLines="true" 
                      LineImagesFolderUrl="../images/lines"
                      EnableViewState="true"
                      ClientSideOnNodeMove="nodeMove"
                      AllowTextSelection="true"
                      runat="server" DragAndDropAcrossTreesEnabled="True" />
                      <SJ:SmartScroller ID="SmartScroller2" runat="server" TargetObject = "TreeView2_div">
                    </SJ:SmartScroller>
            </td>
        </tr>
        <tr height="50">
            <td width="50%" align="right">
                <asp:ImageButton ID="iBtnRefresh" runat="server" ImageUrl="~/images/btn/b_133.gif"
                    OnClick="iBtnRefresh_Click" />&nbsp; </td>
            <td align="right"><asp:ImageButton ID="iBtnSetRel" runat="server" ImageUrl="~/images/btn/b_007.gif" OnClick="iBtnSetRel_Click" />&nbsp;
            </td>
        </tr>
    </table>
        <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
    <!--- MAIN END --->
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
    </div>
    </form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
