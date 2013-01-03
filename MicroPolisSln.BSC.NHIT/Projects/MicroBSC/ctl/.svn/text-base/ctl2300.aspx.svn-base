<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl2300.aspx.cs" Inherits="ctl_ctl2300" MasterPageFile="~/_common/lib/MicroBSC.master" %>

<asp:Content ID="cttContents" runat="server" ContentPlaceHolderID="Contents">

<!--- MAIN START --->
    <script type="text/javascript">
        function checkPossibleCopy() {
            var termID1 = document.getElementById("<% =this.ddlEstTermInfo.ClientID.Replace('_','$') %>").value;
            var termID2 = document.getElementById("<% =this.ddlEstTermInfo2.ClientID.Replace('_','$') %>").value;

            if (termID1 == termID2) {
                alert('동일한 평가기간을 복사할 수 없습니다.');
                return false;
            }

            var isPossible = '<%= this.IPOSSIBLE_COPY %>';
            if (isPossible.toUpperCase() == 'FALSE') {
                alert('이미 해당평가기간에 등록된 평가부서가 존재하여 내보낼 수 없습니다!');
                return false;
            }

            return confirm('내보내시겠습니까?');
        }
    </script>
    <table border="0" cellpadding="0" cellspacing="" width="100%" style="height: 100%;">
        <tr><td style="width: 900px;"></td></tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%;">
                    <tr>
                        <td  width="48%">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:100%; width:100%;">
                                <tr>
                                    <td>
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="평가 부서"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="ddlEstTermInfo" runat="server" CssClass="box01"></asp:DropDownList>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/btn/b_033.gif" align=absmiddle OnClick="ImageButton1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="20">
                            <SJ:SmartScroller ID="SmartScroller1" runat="server" TargetObject="tree1">
                            </SJ:SmartScroller>
                            <SJ:SmartScroller ID="SmartScroller2" runat="server" TargetObject="tree2">
                            </SJ:SmartScroller>
                        </td>
                        <td >
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="인사 부서"/></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td><b><font color='red'>
                            <asp:Literal ID="ltrEstDeptPath" runat="server"></asp:Literal>
                            <asp:Literal ID="ltrEstDeptID" runat="server" Visible="False"></asp:Literal></font>
                            </b>
                        </td>
                        <td>&nbsp;</td>
                        <td><b><font color='red'>
                            <asp:Literal ID="ltrDeptPath" runat="server"></asp:Literal>
                            <asp:Literal ID="ltrDeptID" runat="server" Visible="False"></asp:Literal></font>
                            </b>
                         </td>
                    </tr>
                    <tr valign=top>
                        <td style="padding-left:0;height:100%" class="box01" >
                            <div style="border:none; overflow: auto; width: 100%;  height: 100%" id="tree1">
                                <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </div>
                        </td>
                        <td align="center" valign="middle">
                            <asp:ImageButton ID="btnOut" runat="server" OnClick="btnOut_Click" Height="14px" ImageUrl="~/images/btn/b_arrow2.gif" />
                                <br />
                                <br />
                            <asp:ImageButton ID="btnIn" runat="server" OnClick="btnIn_Click" Height="14px" ImageUrl="~/images/btn/b_arrow1.gif" />
                        <td style="padding-left:0" class="box01">
                        <div style="border:none; overflow: hidden;width:1px;height:1px;">
                        </div>
                        <div style="border:none; overflow: auto; width: 100%; height: 100%" id="tree2">
                            &nbsp;
                            <asp:TreeView ID="TreeView2" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="TreeView2_SelectedNodeChanged">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 25px;">
                <table width="100%" cellpadding="0" cellspacing="0" runat="server" id="tbSetup">
                    <tr>
                        <td runat="server" id="tdEstDeptGroup">
                            <img src='../images/icon/sel2.gif'> <b>설정 부문</b> : <asp:DropDownList ID="ddlDeptGroup" runat="server" CssClass="box01"></asp:DropDownList>
                            평가중인 평가대상기간&nbsp;:&nbsp;<asp:dropdownlist ID="ddlEstTermInfo2" runat="server" class="box01" AutoPostBack="true" OnSelectedIndexChanged="ddlEstTermInfo2_SelectedIndexChanged"></ASP:dropdownlist>
                            <asp:imagebutton id="ibtnCopy" runat="server" align="absmiddle" height="19px" imageurl="../images/btn/b_054.gif" OnClientClick="return checkPossibleCopy();" onclick="ibtnCopy_Click"></asp:imagebutton>
                        </td>
                        <td height=30 align="right" runat="server" id="tdEstDeptButton">
                            <a href="#null" onclick="gfOpenWindow('ctl2301.aspx?mode=New&estterm_ref_id=<%=ESTTERM_REF_ID %>&CCB1=<%=this.ICCB1 %>', 600, 470,'yes');">
                            <img src="../images/btn/b_035.gif" /></a>&nbsp;
                            <a href="#null" onclick="gfOpenWindow('ctl2301.aspx?mode=Rename&estterm_ref_id=<%=ESTTERM_REF_ID %>&CCB1=<%=this.ICCB1 %>', 600, 470,'yes');">
                            <img src="../images/btn/b_036.gif" /></a>&nbsp;
                            <a href="#null" onclick="gfOpenWindow('ctl2302.aspx?estterm_ref_id=<%=ESTTERM_REF_ID %>&CCB1=<%=this.ICCB1 %>', 600, 470,'yes');">
                            <img src="../images/btn/b_038.gif" /></a>&nbsp;
                            <a href="#null" onclick="gfOpenWindow('ctl2301.aspx?mode=Remove&estterm_ref_id=<%=ESTTERM_REF_ID %>&CCB1=<%=this.ICCB1 %>', 600, 470,'yes');">
                            <img src="../images/btn/b_004.gif" /></a>&nbsp; &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>    
        </table>
    <ASP:LINKBUTTON id="lBtnReload" runat="server" onclick="lBtnReload_Click"></ASP:LINKBUTTON>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
<!--- MAIN END --->

</asp:Content>