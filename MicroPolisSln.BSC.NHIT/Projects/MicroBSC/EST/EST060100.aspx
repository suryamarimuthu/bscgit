<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST060100.aspx.cs" Inherits="EST_EST060100" %>

<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script type="text/javascript">
    function MouseOverHandler(gridName, id, objectType) {
        if (objectType == 0) {
            var cell = igtbl_getElementById(id);
            var row = igtbl_getRowById(id);
            var band = igtbl_getBandById(id);
            var active = igtbl_getActiveRow(id);
            cell.style.cursor = 'hand';
        }
    }

    function SearchEstID() {
        gfOpenWindow("EST_EST.aspx?COMP_ID=<%=COMP_ID%>"
	                        + "&CTRL_VALUE_NAME=" + "hdfSearchEstID"
                            + "&CTRL_TEXT_NAME=" + "txtSearchEstName"
                            + "&CHECKBOX_YN=" + "N"
                            + "&CTRL_VALUE_VALUE=" + ""
                           , 430
                           , 400
                           , false
                           , false
                           , "popup_est_scheId");
        //return false;
    }

    function ViewEstTgtView() {
        gfOpenWindow("EST060101.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&EST_ID=" + document.getElementById('hdfSearchEstID').value
                                + "&ESTTERM_REF_ID=" + document.getElementById('ddlEstTermRefID').value
                                + "&ESTTERM_SUB_ID=" + document.getElementById('ddlEstTermSubID').value
                               , 620
                               , 450
                               , true
                               , true
                               , "popup_est_tgt_map");
        return false;
    }

    function ViewCoptType(type) {
        gfOpenWindow("EST060601.aspx?COMP_ID=<%=COMP_ID%>"
	                            + "&TYPE=" + type
                               , 500
                               , 170
                               , true
                               , true
                               , "popup_type");
        return false;
    }

    function ConfirmMsg() {
        if (document.getElementById('rblConfirmAllAndPart_0').checked) {
            return confirm('부분확정을 하시겠습니까? 부분확정은 기존 평가데이터를 제외한 새롭게 맵핑된 정보로 데이터가 갱신됩니다.');
        }
        else if (document.getElementById('rblConfirmAllAndPart_1').checked) {
            return confirm('전체확정을 하시겠습니까? 전체확정은 기존 평가데이터를 모두 삭제하고 맵핑된 정보로 다시 데이터가 갱신됩니다.');
        }

        return false;
    }

    function Search() {
        if (document.getElementById('hdfSearchEstID').value == '') {
            alert('평가를 선택하세요.');
            return false;
        }

        //    if(document.getElementById('ddlEstTermInfo').value == '')
        //    {
        //        alert('설정된 평가기간이 없습니다.');
        //        return false;
        //    }
        //    
        //    if(document.getElementById('ddlEstTermSub').value == '')
        //    {
        //        alert('설정된 평가주기가 없습니다.');
        //        return false;
        //    }
        //    
        //    if(document.getElementById('ddlEstTermStep').value == '')
        //    {
        //        alert('설정된 평가차수가 없습니다.');
        //        return false;
        //    }

        return true;
    }

</script>

<form id="form1" runat="server">
<div>
    <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" id="phdLayout"></asp:placeholder>
    <table cellspacing="0" cellpadding="0" border="0" style="height: 100%;" width="99%">
        <tr>
            <td valign="top" align="center" width="100%" colspan="2" height="30">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableBorder">
                    <tr>
                        <td class="cssTblTitle">
                            평가기간
                        </td>
                        <td class="cssTblContent">
                            <%--<img alt="" src="../images/title/se_ti01.gif" align="absmiddle" />--%>
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" autopostback="True" onselectedindexchanged="ddlEstTermInfo_SelectedIndexChanged"
                                class="box01"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" autopostback="True"
                                onselectedindexchanged="ddlEstTermSub_SelectedIndexChanged"></asp:dropdownlist>
                            <%--<img src="../images/title/opt_s03.gif" align="absMiddle" alt="" />--%>
                            <asp:dropdownlist id="ddlEstTermStepID" class="box01" runat="server" autopostback="True"
                                onselectedindexchanged="ddlEstTermStepID_SelectedIndexChanged"></asp:dropdownlist>
                        </td>
                        <td class="cssTblTitle">
                            평가유형
                        </td>
                        <td align="right" class="tableContent">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:textbox id="txtSearchEstName" runat="server" bordercolor="Silver" borderwidth="1px"
                                            width="100%"></asp:textbox>
                                    </td>
                                    <td style="width: 85px;">
                                        <a href="#null" onclick="SearchEstID();">
                                            <img align="absMiddle" border="0" src="../images/btn/b_143.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                            <asp:hiddenfield id="hdfSearchEstID" runat="server"></asp:hiddenfield>
                            <asp:literal id="ltrClearEmpMapping" runat="server"></asp:literal>
                            <asp:literal runat="server" id="ltrMapping"></asp:literal>
                            <asp:literal id="ltrBeforeRef" runat="server"></asp:literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td width="50%">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td style="width: 15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:label id="lblTitle1" runat="server" style="font-weight: bold" text="평가자" />
                        </td>
                        <td align="right">
                            <a href="#null" onclick="ViewEstTgtView();">
                                <img alt="" align="absMiddle" border="0" src="../images/btn/b_117.gif" id="imgEstTgtMap"
                                    runat="server" visible="false" /></a> &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td style="width: 15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:label id="lblTitle2" runat="server" style="font-weight: bold" text="피평가자" />
                        </td>
                        <td align="right">
                            <asp:imagebutton id="ibnUpdateEmpRole" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_206.gif"
                                visible="False" onclick="ibnUpdateEmpRole_Click"></asp:imagebutton>
                            <a href="#null" onclick="ViewCoptType('4');">
                                <img align="absMiddle" border="0" src="../images/btn/b_081.gif" /></a>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True"
                                onselectedindexchanged="ddlCompID_SelectedIndexChanged"></asp:dropdownlist>
                            <asp:imagebutton id="ibnSearch" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_033.gif"
                                onclick="ibnSearch_Click"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 200;">
            <td valign="top" align="center" width="50%">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tbody>
                        <tr>
                            <td width="170px" valign="top">
                                <div style="border-right: #f4f4f4 1px solid; padding-right: 2px; border-top: #f4f4f4 1px solid;
                                    display: block; padding-left: 2px; padding-bottom: 2px; overflow: auto; border-left: #f4f4f4 1px solid;
                                    width: 170px; padding-top: 2px; border-bottom: #f4f4f4 1px solid; height: 200px"
                                    id="Div1">
                                    <asp:treeview id="TreeView1" runat="server" onselectednodechanged="TreeView1_SelectedNodeChanged"
                                        nodeindent="15" imageset="XPFileExplorer">
                                    <ParentNodeStyle Font-Bold="False"  />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px"  />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px"  />
                                </asp:treeview>
                                </div>
                                <SJ:SmartScroller ID="SmartScroller2" runat="server" TargetObject="Div1" MaintainScrollX="true"
                                    MaintainScrollY="true">
                                </SJ:SmartScroller>
                            </td>
                            <td valign="top">
                                <div style="border-right: #f4f4f4 1px solid; padding-right: 1px; border-top: #f4f4f4 1px solid;
                                    display: block; padding-left: 2px; padding-bottom: 2px; overflow: auto; border-left: #f4f4f4 1px solid;
                                    width: 100%; padding-top: 2px; border-bottom: #f4f4f4 1px solid; height: 200px"
                                    id="Div3">
                                    <asp:datagrid id="TreeGrid_1" runat="server" width="100%" onitemdatabound="TreeGrid_ItemDataBound"
                                        onitemcommand="TreeGrid_ItemCommand" datakeyfield="EST_EMP_ID" autogeneratecolumns="False">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderTemplate>
                                                <input type="checkbox" id="chkAll_1" onclick="javascript:return selectChkBox(this, 'TreeGrid_1_ctl');">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox id="cBox_1" runat="server"></asp:CheckBox> 
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="tableTitle"></HeaderStyle>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="선택">
                                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:LinkButton id="lBtnSelect_1" runat="server" CommandName="Select">선택</asp:LinkButton> 
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="EST_EMP_NAME" HeaderText="성명">
                                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_DEPT_ID" HeaderText="부서ID">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_DEPT_NAME" HeaderText="부서명">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_CLS_ID" HeaderText="직급ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_CLS_NAME" HeaderText="직급">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_DUT_ID" HeaderText="직책ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_DUT_NAME" HeaderText="직책">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_GRP_ID" HeaderText="직군ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_GRP_NAME" HeaderText="직군">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_RNK_ID" HeaderText="직위ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_RNK_NAME" HeaderText="직위">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_KND_ID" HeaderText="직종ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EST_POS_KND_NAME" HeaderText="직종">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                </asp:datagrid>
                                </div>
                                <SJ:SmartScroller ID="SmartScroller4" runat="server" TargetObject="Div3" MaintainScrollX="true"
                                    MaintainScrollY="true">
                                </SJ:SmartScroller>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td valign="top" align="center">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tbody>
                        <tr>
                            <td width="170">
                                <div style="border-right: #f4f4f4 1px solid; padding-right: 2px; border-top: #f4f4f4 1px solid;
                                    display: block; padding-left: 2px; padding-bottom: 2px; overflow: auto; border-left: #f4f4f4 1px solid;
                                    width: 170px; padding-top: 2px; border-bottom: #f4f4f4 1px solid; height: 200px"
                                    id="Div2">
                                    <asp:treeview id="TreeView2" runat="server" onselectednodechanged="TreeView1_SelectedNodeChanged"
                                        nodeindent="15" imageset="XPFileExplorer">
                                    <ParentNodeStyle Font-Bold="False"  />
                                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px"  />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px"  />
                                </asp:treeview>
                                </div>
                                <SJ:SmartScroller ID="SmartScroller3" runat="server" TargetObject="Div2" MaintainScrollX="true"
                                    MaintainScrollY="true">
                                </SJ:SmartScroller>
                            </td>
                            <td valign="top">
                                <div style="border-right: #f4f4f4 1px solid; padding-right: 2px; border-top: #f4f4f4 1px solid;
                                    display: block; padding-left: 2px; padding-bottom: 2px; overflow: auto; border-left: #f4f4f4 1px solid;
                                    width: 100%; padding-top: 2px; border-bottom: #f4f4f4 1px solid; height: 200px"
                                    id="Div4">
                                    <asp:datagrid id="TreeGrid_2" runat="server" width="100%" onitemdatabound="TreeGrid_ItemDataBound"
                                        onitemcommand="TreeGrid_ItemCommand" datakeyfield="TGT_EMP_ID" autogeneratecolumns="False">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderTemplate>
                                                <input type="checkbox" id="chkAll_2" onclick="javascript:return selectChkBox(this, 'TreeGrid_2_ctl');">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox id="cBox_2" runat="server"></asp:CheckBox> 
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="선택">
                                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:LinkButton id="lBtnSelect_2" runat="server" CommandName="Select">선택</asp:LinkButton> 
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="TGT_EMP_NAME" HeaderText="성명">
                                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_DEPT_ID" HeaderText="부서ID">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_DEPT_NAME" HeaderText="부서명">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_CLS_ID" HeaderText="직급ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_CLS_NAME" HeaderText="직급">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_DUT_ID" HeaderText="직책ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_DUT_NAME" HeaderText="직책">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_GRP_ID" HeaderText="직군ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_GRP_NAME" HeaderText="직군">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_RNK_ID" HeaderText="직위ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_RNK_NAME" HeaderText="직위">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_KND_ID" HeaderText="직종ID">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TGT_POS_KND_NAME" HeaderText="직종">
                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                </asp:datagrid>
                                </div>
                                <SJ:SmartScroller ID="SmartScroller5" runat="server" TargetObject="Div4" MaintainScrollX="true"
                                    MaintainScrollY="true">
                                </SJ:SmartScroller>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <asp:imagebutton id="iBtnAdd_1" onclick="iBtnAdd_Click" runat="server" imageurl="../images/btn/b_005.gif"
                                imagealign="AbsMiddle"></asp:imagebutton>
                        </td>
                        <td align="right">
                            <asp:radiobuttonlist id="rblDirectionType" runat="server" repeatdirection="Horizontal"
                                repeatlayout="Flow" autopostback="True" onselectedindexchanged="rblDirectionType_SelectedIndexChanged"
                                visible="False"></asp:radiobuttonlist>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;<asp:imagebutton id="iBtnAdd_2" onclick="iBtnAdd_Click" runat="server" imageurl="../images/btn/b_005.gif"
                                imagealign="AbsMiddle"></asp:imagebutton>
                        </td>
                        <td align="right">
                            <asp:radiobuttonlist id="rblConfirmAllAndPart" runat="server" repeatlayout="Flow"
                                repeatdirection="Horizontal"></asp:radiobuttonlist>
                            <asp:imagebutton id="ibnConfirm" runat="server" imageurl="../images/btn/b_184.gif"
                                onclick="ibnConfirm_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            <asp:imagebutton id="ibnConfirmCancel" runat="server" imageurl="../images/btn/b_019.gif"
                                onclick="ibnConfirmCancel_Click" visible="False" imagealign="AbsMiddle"></asp:imagebutton>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 30;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td style="width: 15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:label id="lblTitle3" runat="server" style="font-weight: bold" text="선택된 평가자" />
                            <asp:label id="lblEst_1_Cnt" runat="server" forecolor="#2080D0" font-bold="True"></asp:label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td style="width: 15px;">
                            <img src="../images/title/ma_t14.gif" alt="" />
                        </td>
                        <td>
                            <asp:label id="lblTitle4" runat="server" style="font-weight: bold" text="선택된 피평가자" />
                            <asp:label id="lblEst_2_Cnt" runat="server" forecolor="#2080D0" font-bold="True"></asp:label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:datagrid id="DataGrid1" runat="server" onitemdatabound="DataGrid_ItemDataBound"
                    onitemcommand="DataGrid_ItemCommand" width="99%" datakeyfield="EST_EMP_ID" autogeneratecolumns="False">
                <Columns>
                    <asp:BoundColumn DataField="EST_EMP_NAME" HeaderText="성명">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center" Width="40px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_DEPT_NAME" HeaderText="부서명">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_CLS_ID" HeaderText="직급ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_CLS_NAME" HeaderText="직급">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_DUT_ID" HeaderText="직책ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_DUT_NAME" HeaderText="직책">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_GRP_ID" HeaderText="직군ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_GRP_NAME" HeaderText="직군">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_RNK_ID" HeaderText="직위ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_RNK_NAME" HeaderText="직위">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_KND_ID" HeaderText="직종ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EST_POS_KND_NAME" HeaderText="직종">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ESTTERM_STEP_NAME" HeaderText="차수">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="삭제">
                        <ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                        <ItemTemplate>
                            <asp:LinkButton id="lBtnDelete_1" runat="server" CommandName="Delete">삭제</asp:LinkButton> 
                        </ItemTemplate>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                </Columns>
            </asp:datagrid>
            </td>
            <td valign="top">
                <asp:datagrid id="DataGrid2" runat="server" width="99%" onitemdatabound="DataGrid_ItemDataBound"
                    onitemcommand="DataGrid_ItemCommand" datakeyfield="TGT_EMP_ID" autogeneratecolumns="False">
                <Columns>
                    <asp:BoundColumn DataField="TGT_EMP_NAME" HeaderText="성명">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center" Width="40px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_DEPT_NAME" HeaderText="부서명">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_CLS_ID" HeaderText="직급ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_CLS_NAME" HeaderText="직급">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_DUT_ID" HeaderText="직책ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_DUT_NAME" HeaderText="직책">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_GRP_ID" HeaderText="직군ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_GRP_NAME" HeaderText="직군">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_RNK_ID" HeaderText="직위ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_RNK_NAME" HeaderText="직위">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_KND_ID" HeaderText="직종ID">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TGT_POS_KND_NAME" HeaderText="직종">
                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="삭제">
                        <ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                        <ItemTemplate>
                            <asp:LinkButton id="lBtnDelete_2" runat="server" CommandName="Delete">삭제</asp:LinkButton> 
                        </ItemTemplate>
                        <HeaderStyle CssClass="tableTitle" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                </Columns>
            </asp:datagrid>
            </td>
        </tr>
    </table>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    <%--<SJ:SmartScroller ID="SmartScroller1" runat="server"></SJ:SmartScroller>--%>
    <!--- MAIN END --->
    <asp:placeholder runat="server" id="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>
